using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Netx.Dui
{
    /// <summary> 线程安全的Actions执行集合
    /// </summary>
    internal static class DuiThreadSaveActions
    {
        private static ActionCollection actions = null;
        private static ActionCollection Actions => actions ?? (actions = new ActionCollection());
        /// <summary> 执行检测间隔
        /// </summary>
        static DuiThreadSaveActions()
        {
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Actions.Do();
                }
            })
            { IsBackground = true, Name = "DuiThreadSaveActions" }.Start();
        }
        /// <summary> 添加一个待执行的Action
        /// </summary>
        /// <param name="loadingAction">加载函数</param>
        /// <param name="callback">完成加载的回调函数</param>
        public static void Add(Action loadingAction, Action callback = null)
        {
            Actions.Add(new AsynLoadingAction(loadingAction, callback));
        }
        private class ActionCollection
        {
            private readonly object lockObj = new object();
            /// <summary> 追加的Action，不直接向doingActions因为线程不是安全的
            /// </summary>
            private List<AsynLoadingAction> appendActions = new List<AsynLoadingAction>();
            /// <summary> 执行的Action集合
            /// </summary>
            private List<AsynLoadingAction> doingActions = new List<AsynLoadingAction>();
            /// <summary> 添加一个待执行的Action
            /// </summary>
            /// <param name="item"></param>
            public void Add(AsynLoadingAction item)
            {
                lock (lockObj)
                {
                    if (appendActions.Exists(a => a.Equals(item)) || doingActions.Exists(a => a.Equals(item)))
                    {
                        return;
                    }
                    this.appendActions.Add(item);
                }
            }
            /// <summary> 执行Action
            /// </summary>
            internal void Do()
            {
                lock (lockObj)
                {
                    this.doingActions.AddRange(this.appendActions);
                    this.appendActions.Clear();
                }
                foreach (AsynLoadingAction a in this.doingActions)
                {
                    a.Invoke();
                }
                this.doingActions.Clear();
            }
        }
        #region AsynLoadingAction
        /// <summary> 异步加载动作对象
        /// </summary>
        private class AsynLoadingAction
        {
            private Action loadingAction = null;
            private Action callback = null;
            /// <summary> 构造函数
            /// </summary>
            /// <param name="loadingAction">加载函数</param>
            /// <param name="callback">完成加载的回调函数</param>
            public AsynLoadingAction(Action loadingAction, Action callback = null)
            {
                this.loadingAction = loadingAction;
                this.callback = callback;
            }
            /// <summary> 执行加载动作
            /// </summary>
            public void Invoke()
            {
                if (this.loadingAction != null)
                {
                    this.loadingAction.Invoke();
                }
                if (this.callback != null)
                {
                    this.callback.Invoke();
                }
            }
            /// <summary> 是否存在一样的动作
            /// </summary>
            /// <param name="asynLoadingAction"></param>
            /// <returns></returns>
            public bool Equals(AsynLoadingAction asynLoadingAction)
            {
                return this.loadingAction == asynLoadingAction.loadingAction && this.callback == asynLoadingAction.callback;
            }
        }
        #endregion
    }
}

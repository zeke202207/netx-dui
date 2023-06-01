using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui
{
    public delegate void SkinManagerEventHandler(object sender);

    public class DxSkinManager
    {
        private static Lazy<DxSkinManager> instance = new Lazy<DxSkinManager>(()=>new DxSkinManager());

        /// <summary>
        /// 配色方案改变事件
        /// </summary>
        public event SkinManagerEventHandler ColorSchemeChanged;

        private DxSkinManager() 
        { 
            _scheme = new DefaultScheme();
        }

        public static DxSkinManager Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// 配色方案
        /// </summary>
        private BaseScheme _scheme;

        /// <summary>
        /// 配色方案
        /// </summary>
        public BaseScheme Scheme
        {
            get { return _scheme; }
        }

        /// <summary>
        /// 换肤
        /// </summary>
        /// <param name="scheme"></param>
        public void Apply(BaseScheme scheme)
        {
            _scheme = scheme;
            UpdateSkin();
            ColorSchemeChanged?.Invoke(this);
        }

        /// <summary>
        /// 更新换色
        /// </summary>
        private void UpdateSkin()
        {
            foreach(Form form in Application.OpenForms)
            {
                if (null == form)
                    continue;
                foreach (Control control in form.Controls)
                {
                    foreach(var ctl in GetControl(control))
                    {
                        ctl.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// 遍历所有控件
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private IEnumerable<Control> GetControl(Control control)
        {
            yield return control;
            foreach(Control ctl in control.Controls)
            {
                GetControl(ctl);
            }
        }
    }
}

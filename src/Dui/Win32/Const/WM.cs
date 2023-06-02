using System;

namespace Netx.Dui.Win32
{
    internal static class WM
    {
        internal const int WM_NULL = 0x0000; //   
        internal const int WM_CREATE = 0x0001; //Ӧ�ó��򴴽�һ������   
        internal const int WM_DESTROY = 0x0002; //һ�����ڱ�����   
        internal const int WM_MOVE = 0x0003; //�ƶ�һ������   
        internal const int WM_SIZE = 0x0005; //�ı�һ�����ڵĴ�С   
        internal const int WM_ACTIVATE = 0x0006; //һ�����ڱ������ʧȥ����״̬��   
        internal const int WM_SETFOCUS = 0x0007; //��ý����   
        internal const int WM_KILLFOCUS = 0x0008; //ʧȥ����   
        internal const int WM_ENABLE = 0x000A; //�ı�enable״̬   
        internal const int WM_SETREDRAW = 0x000B; //���ô����Ƿ����ػ�   
        internal const int WM_SETTEXT = 0x000C; //Ӧ�ó����ʹ���Ϣ������һ�����ڵ��ı�   
        internal const int WM_GETTEXT = 0x000D; //Ӧ�ó����ʹ���Ϣ�����ƶ�Ӧ���ڵ��ı���������   
        internal const int WM_GETTEXTLENGTH = 0x000E; //�õ���һ�������йص��ı��ĳ��ȣ����������ַ���   
        internal const int WM_PAINT = 0x000F; //Ҫ��һ�������ػ��Լ�   
        internal const int WM_CLOSE = 0x0010; //��һ�����ڻ�Ӧ�ó���Ҫ�ر�ʱ����һ���ź�   
        internal const int WM_QUERYENDSESSION = 0x0011; //���û�ѡ������Ի��������Լ�����ExitWindows����   
        internal const int WM_QUIT = 0x0012; //���������������л򵱳������postquitmessage����   
        internal const int WM_QUERYOPEN = 0x0013; //���û����ڻָ���ǰ�Ĵ�Сλ��ʱ���Ѵ���Ϣ���͸�ĳ��ͼ��   
        internal const int WM_ERASEBKGND = 0x0014; //�����ڱ������뱻����ʱ�����ڴ��ڸı��Сʱ��   
        internal const int WM_SYSCOLORCHANGE = 0x0015; //��ϵͳ��ɫ�ı�ʱ�����ʹ���Ϣ�����ж�������   
        internal const int WM_ENDSESSION = 0x0016; // ��ϵͳ���̷���WM_QUERYENDSESSION��Ϣ�󣬴���Ϣ���͸�Ӧ�ó���֪ͨ���Ի��Ƿ����   
        internal const int WM_SYSTEMERROR = 0x0017; //   
        internal const int WM_SHOWWINDOW = 0x0018; //�����ػ���ʾ�����Ƿ��ʹ���Ϣ���������   
        internal const int WM_ACTIVATEAPP = 0x001C; //������Ϣ��Ӧ�ó����ĸ������Ǽ���ģ��ĸ��ǷǼ���ģ�   
        internal const int WM_FONTCHANGE = 0x001D; //��ϵͳ��������Դ��仯ʱ���ʹ���Ϣ�����ж�������   
        internal const int WM_TIMECHANGE = 0x001E; //��ϵͳ��ʱ��仯ʱ���ʹ���Ϣ�����ж�������   
        internal const int WM_CANCELMODE = 0x001F; //���ʹ���Ϣ��ȡ��ĳ�����ڽ��е���̬��������   
        internal const int WM_SETCURSOR = 0x0020; //��������������ĳ���������ƶ����������û�б�����ʱ���ͷ���Ϣ��ĳ������  
        internal const int WM_MOUSEACTIVATE = 0x0021; //�������ĳ���Ǽ���Ĵ����ж��û�����������ĳ�������ʹ���Ϣ����ǰ����   
        internal const int WM_CHILDACTIVATE = 0x0022; //���ʹ���Ϣ��MDI�Ӵ��ڵ��û�����˴��ڵı��������򵱴��ڱ�����ƶ����ı��С   
        internal const int WM_QUEUESYNC = 0x0023; //����Ϣ�ɻ��ڼ������ѵ�������ͣ�ͨ��WH_JOURNALPALYBACK��hook���������û�������Ϣ   
        internal const int WM_GETMINMAXINFO = 0x0024; //����Ϣ���͸����ڵ�����Ҫ�ı��С��λ�ã�   
        internal const int WM_PAINTICON = 0x0026; //���͸���С�����ڵ���ͼ�꽫Ҫ���ػ�   
        internal const int WM_ICONERASEBKGND = 0x0027; //����Ϣ���͸�ĳ����С�����ڣ��������ڻ�ͼ��ǰ���ı������뱻�ػ�   
        internal const int WM_NEXTDLGCTL = 0x0028; //���ʹ���Ϣ��һ���Ի������ȥ���Ľ���λ��   
        internal const int WM_SPOOLERSTATUS = 0x002A; //ÿ����ӡ�����ж����ӻ����һ����ҵʱ��������Ϣ   
        internal const int WM_DRAWITEM = 0x002B; //��button��combobox��listbox��menu�Ŀ�����۸ı�ʱ���ʹ���Ϣ����Щ�ռ���������   
        internal const int WM_MEASUREITEM = 0x002C; //��button, combo box, list box, list view control, or menu item ������ʱ���ʹ���Ϣ���ؼ���������   
        internal const int WM_DELETEITEM = 0x002D; // ��the list box ��combo box �����ٻ�ĳЩ�ɾ��ͨ��LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT ��Ϣ   
        internal const int WM_VKEYTOITEM = 0x002E; //����Ϣ��һ��LBS_WANTKEYBOARDINPUT���ķ�������������������ӦWM_KEYDOWN��Ϣ   
        internal const int WM_CHARTOITEM = 0x002F; //����Ϣ��һ��LBS_WANTKEYBOARDINPUT�����б���͸���������������ӦWM_CHAR��Ϣ   
        internal const int WM_SETFONT = 0x0030; //�������ı�ʱ�����ʹ���Ϣ�õ��ؼ�Ҫ�õ���ɫ   
        internal const int WM_GETFONT = 0x0031; //Ӧ�ó����ʹ���Ϣ�õ���ǰ�ؼ������ı�������   
        internal const int WM_SETHOTKEY = 0x0032; //Ӧ�ó����ʹ���Ϣ��һ��������һ���ȼ������   
        internal const int WM_GETHOTKEY = 0x0033; //Ӧ�ó����ʹ���Ϣ���ж��ȼ���ĳ�������Ƿ��й���   
        internal const int WM_QUERYDRAGICON = 0x0037; //����Ϣ���͸���С�����ڣ����˴��ڽ�Ҫ���ϷŶ���������û�ж���ͼ�꣬Ӧ�ó�����   
        //����һ��ͼ�����ľ�������û��Ϸ�ͼ��ʱϵͳ��ʾ���ͼ�����   
        internal const int WM_COMPAREITEM = 0x0039; //���ʹ���Ϣ���ж�combobox��listbox�����ӵ�������λ��   
        internal const int WM_GETOBJECT = 0x003D; //WM_COMPACTING = 0x0041; //��ʾ�ڴ��Ѿ�������   
        internal const int WM_WINDOWPOSCHANGING = 0x0046; //���ʹ���Ϣ���Ǹ����ڵĴ�С��λ�ý�Ҫ���ı�ʱ��������setwindowpos�������������ڹ�����   
        internal const int WM_WINDOWPOSCHANGED = 0x0047; //���ʹ���Ϣ���Ǹ����ڵĴ�С��λ���Ѿ����ı�ʱ��������setwindowpos�������������ڹ�����   
        internal const int WM_POWER = 0x0048; //��������16λ��windows����ϵͳ��Ҫ������ͣ״̬ʱ���ʹ���Ϣ   
        internal const int WM_COPYDATA = 0x004A; //��һ��Ӧ�ó��򴫵����ݸ���һ��Ӧ�ó���ʱ���ʹ���Ϣ   
        internal const int WM_CANCELJOURNAL = 0x004B; //��ĳ���û�ȡ��������־����״̬���ύ����Ϣ������   
        internal const int WM_NOTIFY = 0x004E; //��ĳ���ؼ���ĳ���¼��Ѿ�����������ؼ���Ҫ�õ�һЩ��Ϣʱ�����ʹ���Ϣ�����ĸ�����   
        internal const int WM_INPUTLANGCHANGEREQUEST = 0x0050; //���û�ѡ��ĳ���������ԣ����������Ե��ȼ��ı�   
        internal const int WM_INPUTLANGCHANGE = 0x0051; //��ƽ̨�ֳ��Ѿ����ı���ʹ���Ϣ����Ӱ����������   
        internal const int WM_TCARD = 0x0052; //�������Ѿ���ʼ��windows��������ʱ���ʹ���Ϣ��Ӧ�ó���   
        internal const int WM_HELP = 0x0053; //����Ϣ��ʾ�û�������F1�����ĳ���˵��Ǽ���ģ��ͷ��ʹ���Ϣ���˴��ڹ����Ĳ˵��������   
        //���͸��н���Ĵ��ڣ������ǰ��û�н��㣬�ͰѴ���Ϣ���͸���ǰ����Ĵ���   
        internal const int WM_USERCHANGED = 0x0054; //���û��Ѿ�������˳����ʹ���Ϣ�����еĴ��ڣ����û�������˳�ʱϵͳ�����û��ľ���   
        //������Ϣ�����û���������ʱϵͳ���Ϸ��ʹ���Ϣ��   
        internal const int WM_NOTIFYformAT = 0x0055; //���ÿؼ����Զ���ؼ������ǵĸ�����ͨ������Ϣ���жϿؼ���ʹ��ANSI����UNICODE�ṹ   
        //��WM_NOTIFY��Ϣ��ʹ�ô˿ؼ���ʹĳ���ؼ������ĸ��ؼ�֮������໥ͨ��   
        internal const int WM_CONTEXTMENU = 0x007B; //���û�ĳ�������е����һ���Ҽ��ͷ��ʹ���Ϣ���������   
        internal const int WM_STYLECHANGING = 0x007C;//������SETWINDOWLONG������Ҫ�ı�һ���������ڵķ��ʱ���ʹ���Ϣ���Ǹ�����   
        internal const int WM_STYLECHANGED = 0x007D;//������SETWINDOWLONG����һ���������ڵķ����ʹ���Ϣ���Ǹ�����   
        internal const int WM_DISPLAYCHANGE = 0x007E; //����ʾ���ķֱ��ʸı���ʹ���Ϣ�����еĴ���   
        internal const int WM_GETICON = 0x007F; //����Ϣ���͸�ĳ��������������ĳ�������й����Ĵ�ͼ���Сͼ��ľ����   
        internal const int WM_SETICON = 0x0080; //�����ʹ���Ϣ��һ���µĴ�ͼ���Сͼ����ĳ�����ڹ�����   
        internal const int WM_NCCREATE = 0x0081; //��ĳ�����ڵ�һ�α�����ʱ������Ϣ��WM_CREATE��Ϣ����ǰ���ͣ�   
        internal const int WM_NCDESTROY = 0x0082; //����Ϣ֪ͨĳ�����ڣ��ǿͻ�����������   
        internal const int WM_NCCALCSIZE = 0x0083; //��ĳ�����ڵĿͻ�������뱻����ʱ���ʹ���Ϣ   
        internal const int WM_NCHITTEST = 0x0084; //�ƶ���꣬��ס���ͷ����ʱ����   
        internal const int WM_NCPAINT = 0x0085; //�����ʹ���Ϣ��ĳ�����ڵ��������ڣ��Ŀ�ܱ��뱻����ʱ��   
        internal const int WM_NCACTIVATE = 0x0086; //����Ϣ���͸�ĳ�����ڽ������ķǿͻ�����Ҫ���ı�����ʾ�Ǽ���ǷǼ���״̬��   
        internal const int WM_GETDLGCODE = 0x0087; //���ʹ���Ϣ��ĳ����Ի����������Ŀؼ���widdows���Ʒ�λ����TAB��ʹ�������˿ؼ�   
        //ͨ����ӦWM_GETDLGCODE��Ϣ��Ӧ�ó�����԰�������һ�����������ؼ����ܴ�����   
        internal const int WM_SYNCPAINT = 0x0088;
        internal const int WM_NCMOUSEMOVE = 0x00A0; //�������һ�����ڵķǿͻ������ƶ�ʱ���ʹ���Ϣ���������//�ǿͻ���Ϊ������ı����������ı߿���   
        internal const int WM_NCLBUTTONDOWN = 0x00A1; //   
        //�������һ�����ڵķǿͻ���ͬʱ����������ʱ�ύ����Ϣ   
        internal const int WM_NCLBUTTONUP = 0x00A2; //���û��ͷ�������ͬʱ���ĳ�������ڷǿͻ���ʮ���ʹ���Ϣ��   
        internal const int WM_NCLBUTTONDBLCLK = 0x00A3; //���û�˫��������ͬʱ���ĳ�������ڷǿͻ���ʮ���ʹ���Ϣ   
        internal const int WM_NCRBUTTONDOWN = 0x00A4; //���û���������Ҽ�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ   
        internal const int WM_NCRBUTTONUP = 0x00A5; //���û��ͷ�����Ҽ�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ   
        internal const int WM_NCRBUTTONDBLCLK = 0x00A6; //���û�˫������Ҽ�ͬʱ���ĳ�������ڷǿͻ���ʮ���ʹ���Ϣ   
        internal const int WM_NCMBUTTONDOWN = 0x00A7; //���û���������м�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ   
        internal const int WM_NCMBUTTONUP = 0x00A8; //���û��ͷ�����м�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ   
        internal const int WM_NCMBUTTONDBLCLK = 0x00A9; //���û�˫������м�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ   
        internal const int WM_NCUAHDRAWCAPTION = 0x00AE;
        internal const int WM_NCUAHDRAWFRAME = 0x00AF;
        internal const int WM_KEYFIRST = 0x0100; //   
        internal const int WM_KEYDOWN = 0x0100; //����һ����   
        internal const int WM_KEYUP = 0x0101; //�ͷ�һ����   
        internal const int WM_CHAR = 0x0102; //����ĳ�������ѷ���WM_KEYDOWN��WM_KEYUP��Ϣ   
        internal const int WM_DEADCHAR = 0x0103; //����translatemessage��������WM_KEYUP��Ϣʱ���ʹ���Ϣ��ӵ�н���Ĵ���   
        internal const int WM_SYSKEYDOWN = 0x0104; //���û���סALT��ͬʱ����������ʱ�ύ����Ϣ��ӵ�н���Ĵ��ڣ�   
        internal const int WM_SYSKEYUP = 0x0105; //���û��ͷ�һ����ͬʱALT ��������ʱ�ύ����Ϣ��ӵ�н���Ĵ���   
        internal const int WM_SYSCHAR = 0x0106; //��WM_SYSKEYDOWN��Ϣ��TRANSLATEMESSAGE����������ύ����Ϣ��ӵ�н���Ĵ���   
        internal const int WM_SYSDEADCHAR = 0x0107; //��WM_SYSKEYDOWN��Ϣ��TRANSLATEMESSAGE����������ʹ���Ϣ��ӵ�н���Ĵ���   
        internal const int WM_KEYLAST = 0x0108; //   
        internal const int WM_INITDIALOG = 0x0110; //��һ���Ի��������ʾǰ���ʹ���Ϣ������ͨ���ô���Ϣ��ʼ���ؼ���ִ����������   
        internal const int WM_COMMAND = 0x0111; //���û�ѡ��һ���˵��������ĳ���ؼ�����һ����Ϣ�����ĸ����ڣ�һ����ݼ�������   
        internal const int WM_SYSCOMMAND = 0x0112; //���û�ѡ�񴰿ڲ˵���һ��������û�ѡ����󻯻���С��ʱ�Ǹ����ڻ��յ�����Ϣ   
        internal const int WM_TIMER = 0x0113; //�����˶�ʱ���¼�   
        internal const int WM_HSCROLL = 0x0114; //��һ�����ڱ�׼ˮƽ����������һ�������¼�ʱ���ʹ���Ϣ���Ǹ����ڣ�Ҳ���͸�ӵ�����Ŀؼ�   
        internal const int WM_VSCROLL = 0x0115; //��һ�����ڱ�׼��ֱ����������һ�������¼�ʱ���ʹ���Ϣ���Ǹ�����Ҳ�����͸�ӵ�����Ŀؼ�   
        internal const int WM_INITMENU = 0x0116;
        //��һ���˵���Ҫ������ʱ���ʹ���Ϣ�����������û��˵����е�ĳ�����ĳ���˵�����������   
        //��������ʾǰ���Ĳ˵�   
        internal const int WM_INITMENUPOPUP = 0x0117; //��һ�������˵����Ӳ˵���Ҫ������ʱ���ʹ���Ϣ�����������������ʾǰ���Ĳ˵�������Ҫ   
        // �ı�ȫ��   
        internal const int WM_MENUSELECT = 0x011F; //���û�ѡ��һ���˵���ʱ���ʹ���Ϣ���˵��������ߣ�һ���Ǵ��ڣ�   
        internal const int WM_MENUCHAR = 0x0120; //���˵��ѱ������û�������ĳ��������ͬ�ڼ��ټ��������ʹ���Ϣ���˵��������ߣ�   
        internal const int WM_ENTERIDLE = 0x0121; //��һ��ģ̬�Ի����˵��������״̬ʱ���ʹ���Ϣ�����������ߣ�һ��ģ̬�Ի����˵��������״̬�����ڴ�����һ��������ǰ����Ϣ��û����Ϣ�����ж��еȴ�   
        internal const int WM_MENURBUTTONUP = 0x0122; //   
        internal const int WM_MENUDRAG = 0x0123; //   
        internal const int WM_MENUGETOBJECT = 0x0124; //   
        internal const int WM_UNINITMENUPOPUP = 0x0125; //   
        internal const int WM_MENUCOMMAND = 0x0126; //   
        internal const int WM_CHANGEUISTATE = 0x0127; //   
        internal const int WM_UPDATEUISTATE = 0x0128; //   
        internal const int WM_QUERYUISTATE = 0x0129; //   
        internal const int WM_CTLCOLORMSGBOX = 0x0132; //��windows������Ϣ��ǰ���ʹ���Ϣ����Ϣ��������ߴ��ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ����������Ϣ����ı��ͱ�����ɫ   
        internal const int WM_CTLCOLOREDIT = 0x0133; //��һ���༭�Ϳؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ����ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ�������ñ༭����ı��ͱ�����ɫ   
        internal const int WM_CTLCOLORLISTBOX = 0x0134; //��һ���б��ؼ���Ҫ������ǰ���ʹ���Ϣ�����ĸ����ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ���������б����ı��ͱ�����ɫ   
        internal const int WM_CTLCOLORBTN = 0x0135; //��һ����ť�ؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ����ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ�������ð�Ŧ���ı��ͱ�����ɫ   
        internal const int WM_CTLCOLORDLG = 0x0136; //��һ���Ի���ؼ���Ҫ������ǰ���ʹ���Ϣ�����ĸ����ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ�������öԻ�����ı�������ɫ   
        internal const int WM_CTLCOLORSCROLLBAR = 0x0137; //��һ���������ؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ����ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ�������ù������ı�����ɫ   
        internal const int WM_CTLCOLORSTATIC = 0x0138; //��һ����̬�ؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ����ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���   
        //ͨ��ʹ�ø����������ʾ�豸�ľ�������þ�̬�ؼ����ı��ͱ�����ɫ   
        internal const int WM_MOUSEFIRST = 0x0200; //   
        internal const int WM_MOUSEMOVE = 0x0200; //�ƶ����   
        internal const int WM_LBUTTONDOWN = 0x0201; //����������   
        internal const int WM_LBUTTONUP = 0x0202; //�ͷ�������   
        internal const int WM_LBUTTONDBLCLK = 0x0203; //˫��������   
        internal const int WM_RBUTTONDOWN = 0x0204; //��������Ҽ�   
        internal const int WM_RBUTTONUP = 0x0205; //�ͷ�����Ҽ�   
        internal const int WM_RBUTTONDBLCLK = 0x0206; //˫������Ҽ�   
        internal const int WM_MBUTTONDOWN = 0x0207; //��������м�   
        internal const int WM_MBUTTONUP = 0x0208; //�ͷ�����м�   
        internal const int WM_MBUTTONDBLCLK = 0x0209; //˫������м�   
        internal const int WM_MOUSEWHEEL = 0x020A; //���������ת��ʱ���ʹ���Ϣ����ǰ�н���Ŀؼ�   
        internal const int WM_MOUSELAST = 0x020A; //   
        internal const int WM_PARENTNOTIFY = 0x0210; //��MDI�Ӵ��ڱ����������٣����û�����һ��������������Ӵ�����ʱ���ʹ���Ϣ�����ĸ�����   
        internal const int WM_ENTERMENULOOP = 0x0211; //���ʹ���Ϣ֪ͨӦ�ó����������that�Ѿ������˲˵�ѭ��ģʽ   
        internal const int WM_EXITMENULOOP = 0x0212; //���ʹ���Ϣ֪ͨӦ�ó����������that���˳��˲˵�ѭ��ģʽ   
        internal const int WM_NEXTMENU = 0x0213; //   
        internal const int WM_SIZING = 532; //���û����ڵ������ڴ�Сʱ���ʹ���Ϣ�����ڣ�ͨ������ϢӦ�ó�����Լ��Ӵ��ڴ�С��λ��  
        //Ҳ�����޸�����   
        internal const int WM_CAPTURECHANGED = 533; //���ʹ���Ϣ�����ڵ���ʧȥ��������ʱ��   
        internal const int WM_MOVING = 534; //���û����ƶ�����ʱ���ʹ���Ϣ��ͨ������ϢӦ�ó�����Լ��Ӵ��ڴ�С��λ��   
        //Ҳ�����޸����ǣ�   
        internal const int WM_POWERBROADCAST = 536; //����Ϣ���͸�Ӧ�ó�����֪ͨ���йص�Դ�����¼���   
        internal const int WM_DEVICECHANGE = 537; //���豸��Ӳ�����øı�ʱ���ʹ���Ϣ��Ӧ�ó�����豸��������   
        internal const int WM_IME_STARTCOMPOSITION = 0x010D; //   
        internal const int WM_IME_ENDCOMPOSITION = 0x010E; //   
        internal const int WM_IME_COMPOSITION = 0x010F; //   
        internal const int WM_IME_KEYLAST = 0x010F; //   
        internal const int WM_IME_SETCONTEXT = 0x0281; //   
        internal const int WM_IME_NOTIFY = 0x0282; //   
        internal const int WM_IME_CONTROL = 0x0283; //   
        internal const int WM_IME_COMPOSITIONFULL = 0x0284; //   
        internal const int WM_IME_SELECT = 0x0285; //   
        internal const int WM_IME_CHAR = 0x0286; //   
        internal const int WM_IME_REQUEST = 0x0288; //   
        internal const int WM_IME_KEYDOWN = 0x0290; //   
        internal const int WM_IME_KEYUP = 0x0291; //   
        internal const int WM_MDICREATE = 0x0220; //Ӧ�ó����ʹ���Ϣ�����ĵ��Ŀͻ�����������һ��MDI �Ӵ���   
        internal const int WM_MDIDESTROY = 0x0221; //Ӧ�ó����ʹ���Ϣ�����ĵ��Ŀͻ��������ر�һ��MDI �Ӵ���   
        internal const int WM_MDIACTIVATE = 0x0222; //Ӧ�ó����ʹ���Ϣ�����ĵ��Ŀͻ�����֪ͨ�ͻ����ڼ�����һ��MDI�Ӵ��ڣ����ͻ������յ�   
        //����Ϣ��������WM_MDIACTIVE��Ϣ��MDI�Ӵ��ڣ�δ�����������   
        internal const int WM_MDIRESTORE = 0x0223; //�����ʹ���Ϣ��MDI�ͻ��������Ӵ��ڴ������С���ָ���ԭ����С   
        internal const int WM_MDINEXT = 0x0224; //�����ʹ���Ϣ��MDI�ͻ����ڼ�����һ����ǰһ������   
        internal const int WM_MDIMAXIMIZE = 0x0225; //�����ʹ���Ϣ��MDI�ͻ����������һ��MDI�Ӵ��ڣ�   
        internal const int WM_MDITILE = 0x0226; //�����ʹ���Ϣ��MDI�ͻ�������ƽ�̷�ʽ������������MDI�Ӵ���   
        internal const int WM_MDICASCADE = 0x0227; //�����ʹ���Ϣ��MDI�ͻ������Բ����ʽ������������MDI�Ӵ���   
        internal const int WM_MDIICONARRANGE = 0x0228; //�����ʹ���Ϣ��MDI�ͻ�������������������С����MDI�Ӵ���   
        internal const int WM_MDIGETACTIVE = 0x0229; //�����ʹ���Ϣ��MDI�ͻ��������ҵ�������Ӵ��ڵľ��   
        internal const int WM_MDISETMENU = 0x0230; //�����ʹ���Ϣ��MDI�ͻ�������MDI�˵������Ӵ��ڵĲ˵�   
        internal const int WM_ENTERSIZEMOVE = 0x0231; //   
        internal const int WM_EXITSIZEMOVE = 0x0232; //   
        internal const int WM_DROPFILES = 0x0233; //   
        internal const int WM_MDIREFRESHMENU = 0x0234; //   
        internal const int WM_MOUSEHOVER = 0x02A1; //   
        internal const int WM_NCMOUSEHOVER = 0x02A0;
        internal const int WM_NCMOUSELEAVE = 0x02A2;
        internal const int WM_MOUSELEAVE = 0x02A3; //   
        internal const int WM_CUT = 0x0300; //�����ʹ���Ϣ��һ���༭���combobox��ɾ����ǰѡ����ı�   
        internal const int WM_COPY = 0x0301; //�����ʹ���Ϣ��һ���༭���combobox�����Ƶ�ǰѡ����ı���������   
        internal const int WM_PASTE = 0x0302; //�����ʹ���Ϣ��editcontrol��combobox�Ӽ������еõ�����   
        internal const int WM_CLEAR = 0x0303; //�����ʹ���Ϣ��editcontrol��combobox�����ǰѡ������ݣ�   
        internal const int WM_UNDO = 0x0304; //�����ʹ���Ϣ��editcontrol��combobox�������һ�β���   
        internal const int WM_RENDERformAT = 0x0305; //   
        internal const int WM_RENDERALLformATS = 0x0306; //   
        internal const int WM_DESTROYCLIPBOARD = 0x0307; //������ENPTYCLIPBOARD����ʱ���ʹ���Ϣ���������������   
        internal const int WM_DRAWCLIPBOARD = 0x0308; //������������ݱ仯ʱ���ʹ���Ϣ��������۲����ĵ�һ�����ڣ��������ü�����۲촰����   
        //��ʾ������������ݣ�   
        internal const int WM_PAINTCLIPBOARD = 0x0309; //�����������CF_OWNERDIPLAY��ʽ�����ݲ��Ҽ�����۲촰�ڵĿͻ�����Ҫ�ػ���   
        internal const int WM_VSCROLLCLIPBOARD = 0x030A; //   
        internal const int WM_SIZECLIPBOARD = 0x030B; //�����������CF_OWNERDIPLAY��ʽ�����ݲ��Ҽ�����۲촰�ڵĿͻ�����Ĵ�С�Ѿ��ı��Ǵ���Ϣͨ��������۲촰�ڷ��͸�������������ߣ�   
        internal const int WM_ASKCBformATNAME = 0x030C; //ͨ��������۲촰�ڷ��ʹ���Ϣ���������������������һ��CF_OWNERDISPLAY��ʽ�ļ����������   
        internal const int WM_CHANGECBCHAIN = 0x030D; //��һ�����ڴӼ�����۲�������ȥʱ���ʹ���Ϣ��������۲����ĵ�һ�����ڣ�   
        internal const int WM_HSCROLLCLIPBOARD = 0x030E; //   
        //����Ϣͨ��һ��������۲촰�ڷ��͸�������������ߣ��������ڵ����������CFOWNERDISPALY��ʽ�����ݲ����и��¼��ڼ�����۲촰��ˮƽ�������ϣ�������Ӧ����������ͼ�󲢸��¹�������ֵ��   
        internal const int WM_QUERYNEWPALETTE = 0x030F; //����Ϣ���͸���Ҫ�յ�����Ĵ��ڣ�����Ϣ��ʹ�������յ�����ʱͬʱ�л���ʵ�������߼���ɫ��   
        internal const int WM_PALETTEISCHANGING = 0x0310; //��һ��Ӧ�ó�����Ҫʵ�������߼���ɫ��ʱ������Ϣ֪ͨ���е�Ӧ�ó���   
        internal const int WM_PALETTECHANGED = 0x0311; //����Ϣ��һ��ӵ�н���Ĵ���ʵ�������߼���ɫ����ʹ���Ϣ�����ж������ص��Ĵ��ڣ��Դ�   
        //���ı�ϵͳ��ɫ��   
        internal const int WM_HOTKEY = 0x0312; //���û�������REGISTERHOTKEY����ע����ȼ�ʱ�ύ����Ϣ   
        internal const int WM_PRINT = 791; //Ӧ�ó����ʹ���Ϣ����WINDOWS������Ӧ�ó��򷢳�һ������Ҫ�����һ��Ӧ�ó����һ���֣�   
        internal const int WM_PRINTCLIENT = 792; //   
        internal const int WM_HANDHELDFIRST = 856; //   
        internal const int WM_HANDHELDLAST = 863; //   
        internal const int WM_PENWINFIRST = 0x0380; //   
        internal const int WM_PENWINLAST = 0x038F; //   
        internal const int WM_COALESCE_FIRST = 0x0390; //   
        internal const int WM_COALESCE_LAST = 0x039F; //   
        internal const int WM_DDE_FIRST = 0x03E0; //   
        internal const int WM_DDE_INITIATE = WM_DDE_FIRST + 0; //һ��DDE�ͻ������ύ����Ϣ��ʼһ�������������ĻỰ����Ӧ�Ǹ�ָ���ĳ������������   
        internal const int WM_DDE_TERMINATE = WM_DDE_FIRST + 1; //һ��DDEӦ�ó��������ǿͻ����Ƿ��������ύ����Ϣ����ֹһ���Ự��   
        internal const int WM_DDE_ADVISE = WM_DDE_FIRST + 2; //һ��DDE�ͻ������ύ����Ϣ��һ��DDE������������������ÿ��������ı�ʱ������   
        internal const int WM_DDE_UNADVISE = WM_DDE_FIRST + 3; //һ��DDE�ͻ�����ͨ������Ϣ֪ͨһ��DDE������򲻸���ָ�������һ������ļ������ʽ����   
        internal const int WM_DDE_ACK = WM_DDE_FIRST + 4; //����Ϣ֪ͨһ��DDE����̬���ݽ������������յ������ڴ���WM_DDE_POKE, WM_DDE_EXECUTE, WM_DDE_DATA, WM_DDE_ADVISE, WM_DDE_UNADVISE, or WM_DDE_INITIAT��Ϣ   
        internal const int WM_DDE_DATA = WM_DDE_FIRST + 5; //һ��DDE��������ύ����Ϣ��DDE�ͻ����������ݸ�һ��������ͻ���֪ͨ�ͻ���һ������������   
        internal const int WM_DDE_REQUEST = WM_DDE_FIRST + 6; //һ��DDE�ͻ������ύ����Ϣ��һ��DDE�������������һ���������ֵ��   
        internal const int WM_DDE_POKE = WM_DDE_FIRST + 7; //һ��DDE�ͻ������ύ����Ϣ��һ��DDE������򣬿ͻ�ʹ�ô���Ϣ���������������һ��δ��ͬ��������������ͨ����WM_DDE_ACK��Ϣ��ʾ�Ƿ���������������   
        internal const int WM_DDE_EXECUTE = WM_DDE_FIRST + 8; //һ��DDE�ͻ������ύ����Ϣ��һ��DDE�������������һ���ַ�����������������������һ��������������ͨ���ύWM_DDE_ACK��Ϣ������Ӧ��   
        internal const int WM_DDE_LAST = WM_DDE_FIRST + 8; //   
        internal const int WM_APP = 0x8000; //   
        internal const int WM_USER = 0x0400; //����Ϣ�ܰ���Ӧ�ó����Զ���˽����Ϣ�� 
        internal const int WM_THEMECHANGED = 0x31A;
    }
}

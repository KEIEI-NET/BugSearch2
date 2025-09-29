//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仮想プリンタダイアログ制御
// プログラム概要   : 仮想プリンタダイアログ制御
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 3H 仰亮亮
// 作 成 日  2022/04/24 修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Threading;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仮想プリンタダイアログ制御
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仮想プリンタダイアログ制御</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/04/24</br>
    /// <br>管理番号   : 11870080-00</br>
    /// </remarks>
    public partial class VirtualPrinterControllerUCA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members

        private const int BM_CLICK = 0xF5;
        private const int WM_SETTEXT = 0x000C;
        private const int WM_GETTEXT = 0x000D;
        private const int WM_GETTEXTLENGTH = 0x000E;

        /// <summary>プログラム名称</summary>
        private const string ctPgName = "仮想プリンタダイアログ制御PG";
        /// <summary>デフォルト総時間 60秒</summary>
        private const int ctTotalTime = 60000;
        /// <summary>デフォルト間隔時間 50ミリ秒</summary>
        private const int ctIntervalTime = 50;
        /// <summary>PDFファイル名(「得意先コード>_「得意先名称」_「伝票区分名>_「伝票番号>_「出力日時」.pdf) </summary>
        private string _pdfFileName;
        /// <summary> PDFファイル保存先フォルダ名</summary>
        private string _pdfOutPutFolderPath = string.Empty;
        /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
        private int _pdfIntervalPara;
        /// <summary>起動元情報(売上伝票:１/得意先電子元帳:２)</summary>
        private int _pgStartKbn;
        /// <summary>初回フラグ</summary>
        private bool _firstFlg;
        /// <summary>実行中フラグ</summary>
        private bool _doFlg;
        /// <summary>PDF出力制御 フラグ</summary>
        private bool _doPdfOutFlg;
        /// <summary>検索実施 フラグ</summary>
        private bool _recursionOutFlg;
        /// <summary>コントロールハンドル</summary>
        private int _controlHandle;
        /// <summary>今回の電子帳簿対応ではダイアログ表示を使用しない</summary>
        private bool _fileDialogDisplay = false;
        /// <summary>作業用フォルダパス</summary>
        private string _sWorkFolderPath = string.Empty;
        /// <summary>作業用フォルダ名 Rename</summary>
        private const string _sWorkFolderName = "Rename";
        /// <summary>"*.pdf" 検索文字列</summary>
        private const string searchPattern = "*.pdf";
        /// <summary>日付書式指定文字列</summary>
        private const string dateFormat = "yyyyMMddHHmmssfff";
        /// <summary>PDFファイルコネクタ</summary>
        private const string pdfConnector = "_";
        /// <summary>今回の電子帳簿対応ではダイアログ表示を使用しない（売上伝票入力）</summary>
        private const string XML_MAHNB01001U_PDFPRINTERSETTINGENABLE = "MAHNB01001U_PDFPrinterSettingEnable.xml";
        /// <summary>今回の電子帳簿対応ではダイアログ表示を使用しない（得意先電子元帳）</summary>
        private const string XML_PMKAU04001U_PDFPRINTERSETTINGENABLE = "PMKAU04001U_PDFPrinterSettingEnable.xml";
        /// <summary>PDF出力設定の設定項目（売上伝票入力）</summary>
        private const string ctPrint_MAHNB01001U_PDFOutputSettings_Xml = "MAHNB01001U_PDFOutputSettings.xml";
        /// <summary>PDF出力設定の設定項目（得意先電子元帳）</summary>
        private const string ctPrint_PMKAU04001U_PDFOutputSettings_Xml = "PMKAU04001U_PDFOutputSettings.xml";
        /// <summary>スクリプトファイル名(Windows標準)</summary>
        private const string ctPrint_BaseSetting_Xml = "SalesSlipPDF1.xml";
        /// <summary>スクリプトファイル名(その他)</summary>
        private const string ctPrint_OtherSetting_Xml = "SalesSlipPDF2.xml";
        /// <summary>スクリプトファイル名</summary>
        private string _printSettingXmlName;
        /// <summary>PDF出力設定ファイル構造体</summary>
        private eBooksOutputSetting _eBooksOutputSetting;
        /// <summary>PDFプリンタ項目設定情報</summary>
        private WindowControll[] _windowControllInfo;
        /// <summary>スクリプトEnum(0:Windows標準/1:その他)</summary>
        private enum pdfPrinterEnum : int
        {
            BaseSetting_Xml = 0,　　// Windows標準
            OtherSetting_Xml = 1,   // その他
        }
        /// <summary>起動元情報(売上伝票:１/得意先電子元帳:２)</summary>
        private enum pgStratEnum : int
        {
            MAHNB01001U_Start = 1,　// 売上伝票入力
            PMKAU04001U_Start = 2,  // 得意先電子元帳
        }
        #endregion

        #region[Windows Api]
        /// <summary>親ウィンドウハンドル取得</summary>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]        
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string lpClassName, string lpWindowName);

        /// <summary>ハンドルクラス名取得</summary>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder ClassName, int nMaxCount);

        /// <summary>ハンドル設定</summary>
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, Byte[] lParam);

        /// <summary>ハンドル設定</summary>
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>ハンドル設定</summary>
        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, IntPtr wParam, string lParam);

        /// <summary>ハンドル設定</summary>
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 構造関数
        /// </summary>
        public VirtualPrinterControllerUCA(string[] args)
        {
            // 初期化処理
            InitializeComponent();
            _firstFlg = false;
            _doPdfOutFlg = false;
            _recursionOutFlg = false;
            // PDFファイル保存先フォルダ名
            _pdfOutPutFolderPath = args[0];
            // PDFファイル名「<得意先コード>_<得意先名称>_<伝票区分名>_<伝票番号>_<出力日時>.pdf」
            _pdfFileName = args[1].ToString() + "_" + args[2].ToString() + "_" + args[3].ToString() + "_" + args[4].ToString() + "_";
            // ダイアログ待ち時間（ミリ秒）
            _pdfIntervalPara = Convert.ToInt32(args[5].ToString());
            if (_pdfIntervalPara == 0) 
            {
                _pdfIntervalPara = 1; //　最小単位1ミリ秒
            }
            // 起動元情報(売上伝票:１/得意先電子元帳:２)
            _pgStartKbn = Convert.ToInt32(args[6].ToString());
            // ファイル保存ダイアログ表示制御
            GetFileDialogDisplay();

        }
        #endregion

        // ===================================================================================== //
        // 画面操作処理ラクタ
        // ===================================================================================== //
        #region Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void VirtualPrinterControllerUCA_Load(object sender, EventArgs e)
        {
            // 画面表示しない
            this.Visible = false;
        }

        /// <summary>
        ///  フォーム起動後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VirtualPrinterControllerUCA_Shown(object sender, EventArgs e)
        {
            // スクリプトファイル名[Windows標準] 
            _printSettingXmlName = ctPrint_BaseSetting_Xml;
            try
            {
                // ファイル移動処理を実施
                if (!_fileDialogDisplay)
                {
                    // PDFファイル保存先フォルダ
                    if (!Directory.Exists(_pdfOutPutFolderPath))
                    {
                        Directory.CreateDirectory(_pdfOutPutFolderPath);
                    }
                    // 作業用フォルダ
                    _sWorkFolderPath = Path.Combine(_pdfOutPutFolderPath, _sWorkFolderName);
                    if (!Directory.Exists(_sWorkFolderPath))
                    {
                        Directory.CreateDirectory(_sWorkFolderPath);
                    }
                    // デフォルト総時間 60秒
                    timer2.Interval = ctTotalTime;
                    timer2.Enabled = true;
                    timer1.Interval = _pdfIntervalPara;
                    timer1.Enabled = true;
                    timer3.Interval = 1;
                    timer3.Enabled = true;
                }
                else
                {
                    // ファイル保存ダイアログ表示制御
                    // 起動PG元
                    string sPdfOutputSettingXmlFileName;
                    switch (_pgStartKbn)
                    {
                        case (int)pgStratEnum.MAHNB01001U_Start:
                            sPdfOutputSettingXmlFileName = ctPrint_MAHNB01001U_PDFOutputSettings_Xml;
                            break;
                        case (int)pgStratEnum.PMKAU04001U_Start:
                            sPdfOutputSettingXmlFileName = ctPrint_PMKAU04001U_PDFOutputSettings_Xml;
                            break;
                        default:
                            sPdfOutputSettingXmlFileName = ctPrint_MAHNB01001U_PDFOutputSettings_Xml;
                            break;
                    }
                    // 売上伝票入力・得意先電子元帳のPDF出力設定ファイル情報取得
                    _eBooksOutputSetting = geteBooksOutputSetting(sPdfOutputSettingXmlFileName);
                    if (_eBooksOutputSetting != null)
                    {
                        // 仮想プリンタ
                        // Windows標準
                        if (Convert.ToInt32(_eBooksOutputSetting.PDFPrinter) == (Int32)pdfPrinterEnum.BaseSetting_Xml)
                        {
                            _printSettingXmlName = ctPrint_BaseSetting_Xml;
                        }
                        // その他
                        else
                        {
                            _printSettingXmlName = ctPrint_OtherSetting_Xml;
                        }

                        // PDFプリンタ項目設定情報取得
                        _windowControllInfo = GetWindowControllInfo(_printSettingXmlName);
                        // 情報なし
                        if (_windowControllInfo.Length == 0)
                        {
                            // プログラム終了
                            this.Close();
                            return;
                        }

                        // デフォルト総時間 60秒
                        timer2.Interval = ctTotalTime;
                        timer2.Enabled = true;
                        timer1.Interval = _pdfIntervalPara;
                        timer1.Enabled = true;
                        timer3.Interval = 1;
                        timer3.Enabled = true;
                    }
                    else
                    {
                        // プログラム終了
                        this.Close();
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // プログラム終了
                this.Close();
                return;
            }
        }

        #endregion

        #region timer処理
        /// <summary>
        /// timer処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            _doFlg = false;

            // 60秒間に一度でもダイアログがない 
            if ((!_doPdfOutFlg) && (_firstFlg))
            {
                this.Close();
            }
            else
            {
                timer1.Enabled = true;
                timer3.Enabled = true;
            }
        }   

        /// <summary>
        /// 60秒間 timer処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;    
            // 60秒間に一度でもダイアログがない
            if (!_firstFlg)
            {
                _doFlg = false;
                // プログラム終了
                this.Close();
            }
        }

        /// <summary>
        /// timer処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;

            if (_fileDialogDisplay)
            {
                sendMessageToDialog();
            }
            else
            {
                pdfFileMove();
            }
        }
        #endregion

        #region [PDFファイル移動]
        /// <summary>
        /// PDFファイル移動
        /// </summary>
        private void pdfFileMove()
        {
            // 実行中
            _doFlg = true;
            _doPdfOutFlg = false;

            while (_doFlg)
            {
                DirectoryInfo _directoryInfo = new DirectoryInfo(_pdfOutPutFolderPath);

                // ソースフォルダのすべてのPDFファイルを取得
                foreach (FileInfo file in _directoryInfo.GetFiles(searchPattern))
                {
                    string pdfExtension = file.Extension;
                    string destFileName = Path.GetFileNameWithoutExtension(file.Name) + pdfConnector + DateTime.Now.ToString(dateFormat) + pdfExtension;
                    try
                    {
                        // PDFファイル移動
                        File.Move(file.FullName, Path.Combine(_sWorkFolderPath, destFileName));
                    }
                    catch (Exception)
                    {
                        // 影響無し
                    }

                    _firstFlg = true;
                    _doPdfOutFlg = true;
                }

                // 50ミリ秒間隔で再検索
                Thread.Sleep(ctIntervalTime);
                System.Windows.Forms.Application.DoEvents();
            }
        }
        #endregion

        #region [ダイアログ情報変更]
        /// <summary>
        /// ダイアログ情報変更
        /// </summary>
        private void sendMessageToDialog()
        {
            // 親ウィンドウハンドルを取得
            int mainHandle;
            // テキストウハンドルを取得
            int textHandle;
            // 保存ボタンウハンドルを取得
            int buttonHandle;
            // 実行中
            _doFlg = true;
            _doPdfOutFlg = false;

            while (_doFlg)
            {
                for (int i = 0; i < _windowControllInfo.Length; i++)
                {
                    mainHandle = FindWindow(_windowControllInfo[i].WindowClass.ToString(), _windowControllInfo[i].WindowName.ToString());
                    // 親ウィンドウハンドル存在
                    if (mainHandle != 0)
                    {
                        // 保存ボタンハンドル取得
                        _recursionOutFlg = false;
                        _controlHandle = 0;
                        buttonHandle = getChildHwd(mainHandle, _windowControllInfo[i].Field2Class.ToString(), _windowControllInfo[i].Field2Name.ToString());
                        // テキスト入力ハンドル取得
                        _recursionOutFlg = false;
                        _controlHandle = 0;
                        textHandle = getChildHwd(mainHandle, _windowControllInfo[i].Field1Class.ToString(), _windowControllInfo[i].Field1Name.ToString());
                        if (textHandle != 0)
                        {
                            string sFileName = Path.Combine(_pdfOutPutFolderPath, _pdfFileName + DateTime.Now.ToString(dateFormat) + ".pdf");
                            SendMessage(textHandle, WM_SETTEXT, IntPtr.Zero, sFileName);
                            if (buttonHandle != 0)
                            {
                                // 保存ボタン実行
                                SendMessage(buttonHandle, BM_CLICK, 0, 0);
                                _firstFlg = true;
                                _doPdfOutFlg = true;
                            }
                        }

                    }
                    // 50ミリ秒間隔で再検索
                    Thread.Sleep(ctIntervalTime);
                }
                System.Windows.Forms.Application.DoEvents();
            }

        }
        #endregion

        #region 「子ウィンドウハンドルを取得」
        /// <summary>
        /// 子ウィンドウハンドルを取得
        /// </summary>
        /// <param name="parent_hwd"></param>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        private int getChildHwd(int parent_hwd, string lpClassName, string lpWindowName)
        {
            if (_recursionOutFlg)
            {
                return _controlHandle;
            }
            int past_hwd = 0;
            int i = 1;
            List<int> list = new List<int>();
            string sClassNm = lpClassName.ToUpper();
            string sWindowNm = lpWindowName;
            while ((past_hwd != 0 || i == 1) && (!_recursionOutFlg))
            {
                i++;
                past_hwd = FindWindowEx(parent_hwd, past_hwd, null, null);
                if (past_hwd > 0)
                {
                    StringBuilder sb = new StringBuilder(256);
                    IntPtr intsb = new IntPtr(past_hwd);
                    GetClassName(intsb, sb, 255);
                    string classname = sb.ToString().ToUpper(); ;
                    if (classname.ToString().Equals(sClassNm))
                    {
                        //　Windowsテキストを取得
                        int textLen;
                        textLen = SendMessage(intsb, WM_GETTEXTLENGTH, 0, 0);
                        Byte[] byt = new Byte[textLen];
                        SendMessage(intsb, WM_GETTEXT, textLen + 1, byt);
                        String txt = Encoding.Default.GetString(byt);
                        if (sClassNm.Contains("BUTTON"))
                        {
                            if (txt.Contains(lpWindowName))
                            {
                                _recursionOutFlg = true;
                                _controlHandle = past_hwd;
                                break;
                            }
                        }
                        else
                        {
                            if (txt.Equals(lpWindowName))
                            {
                                _recursionOutFlg = true;
                                _controlHandle = past_hwd;
                                break;
                            }
                        }
                    }
                    getChildHwd(past_hwd, sClassNm, lpWindowName);
                }
            }
            return _controlHandle;

        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region Private Methods
        # region[PDFプリンタ項目設定情報取得]
        /// <summary>
        /// PDFプリンタ項目設定情報取得
        /// </summary>
        /// <param name="sXmlFileName">スクリプトファイル</param>
        private static WindowControll[] GetWindowControllInfo(string sXmlFileName)
        {
            WindowControll[] windowControll = new WindowControll[0];
            // PDFプリンタ項目設定XMLファイル存在の判断           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlFileName)))
            {
                windowControll = UserSettingController.DeserializeUserSetting<WindowControll[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlFileName));

            }
            return windowControll;
        }
        # endregion

        # region[売上伝票入力・得意先電子元帳のPDF出力設定ファイル情報取得]
        /// <summary>
        /// 売上伝票入力・得意先電子元帳のPDF出力設定ファイル情報取得
        /// </summary>
        /// <param name="sXmlFileName">スクリプトファイル</param>
        private static eBooksOutputSetting geteBooksOutputSetting(string sXmlFileName)
        {
            eBooksOutputSetting settings = null;
            // PDFプリンタ項目設定XMLファイル存在の判断           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlFileName)))
            {
                settings = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlFileName));
            }
            return settings;
        }
        # endregion

        #region[ファイル保存ダイアログ表示を制御]
        /// <summary>
        /// ファイル保存ダイアログ表示を制御
        /// </summary>
        /// <remarks>
        /// 今回の電子帳簿対応ではダイアログ表示を使用しない
        /// </remarks>
        private void GetFileDialogDisplay()
        {

            // 起動PG元
            string sPDFPrinterSettingEnableXmlFileName;
            switch (_pgStartKbn)
            {
                case (int)pgStratEnum.MAHNB01001U_Start:
                    sPDFPrinterSettingEnableXmlFileName = XML_MAHNB01001U_PDFPRINTERSETTINGENABLE;
                    break;
                case (int)pgStratEnum.PMKAU04001U_Start:
                    sPDFPrinterSettingEnableXmlFileName = XML_PMKAU04001U_PDFPRINTERSETTINGENABLE;
                    break;
                default:
                    sPDFPrinterSettingEnableXmlFileName = XML_MAHNB01001U_PDFPRINTERSETTINGENABLE;
                    break;
             }

            try
            {
                // ファイル保存ダイアログ表示を制御
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sPDFPrinterSettingEnableXmlFileName)))
                {
                    this._fileDialogDisplay = true;
                }
                else
                {
                    this._fileDialogDisplay = false;
                }
            }
            catch
            {
                this._fileDialogDisplay = false;
            }
        }
        #endregion
        #endregion

        # region [PDFプリンタ項目設定情報XML]
        /// <summary>
        /// PDFプリンタ項目設定情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class WindowControll
        {
            /// <summary>
            /// PDFプリンタ項目設定情報アイテムリスト
            /// </summary>
            public WindowControll()
            {

            }

            /// <summary>親ウィンドウのキャプション</summary>
            private string _windowName;

            /// <summary>親ウィンドウのクラス名</summary>
            private string _windowClass;

            /// <summary>テキスト入力のキャプション</summary>
            private string _field1Name;

            /// <summary>テキスト入力のクラス名</summary>
            private string _field1Class;

            /// <summary>テキスト入力の親ウィンドウからの相対インデックス値</summary>
            private string _field1Index;

            /// <summary>ボタンのキャプション</summary>
            private string _field2Name;

            /// <summary>ボタンのクラス名</summary>
            private string _field2Class;

            /// <summary>ボタンの親ウィンドウからの相対インデックス値</summary>
            private string _field2Index;

            /// <summary>次の処理を実行するまでの待機時間（ミリ秒）</summary>
            private string _interval;

            /// <summary>親ウィンドウのキャプション</summary>
            public string WindowName
            {
                get { return _windowName; }
                set { _windowName = value; }
            }

            /// <summary>親ウィンドウのクラス名</summary>
            public string WindowClass
            {
                get { return _windowClass; }
                set { _windowClass = value; }
            }

            /// <summary>テキスト入力のキャプション</summary>
            public string Field1Name
            {
                get { return _field1Name; }
                set { _field1Name = value; }
            }

            /// <summary>テキスト入力のクラス名</summary>
            public string Field1Class
            {
                get { return _field1Class; }
                set { _field1Class = value; }
            }

            /// <summary>テキスト入力の親ウィンドウからの相対インデックス値</summary>
            public string Field1Index
            {
                get { return _field1Index; }
                set { _field1Index = value; }
            }

            /// <summary>ボタンのキャプション</summary>
            public string Field2Name
            {
                get { return _field2Name; }
                set { _field2Name = value; }
            }

            /// <summary>ボタンのクラス名</summary>
            public string Field2Class
            {
                get { return _field2Class; }
                set { _field2Class = value; }
            }
            /// <summary>ボタンの親ウィンドウからの相対インデックス値</summary>
            public string Field2Index
            {
                get { return _field2Index; }
                set { _field2Index = value; }
            }

            /// <summary>次の処理を実行するまでの待機時間（ミリ秒）</summary>
            public string Interval
            {
                get { return _interval; }
                set { _interval = value; }
            }
        }
        #endregion

        # region [PDFプリンタ項目設定情報XML]
        /// <summary>
        /// PDFプリンタ項目設定情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class eBooksOutputSetting
        {
            /// <summary>PDFプリンタ項目設定情報</summary>
            public eBooksOutputSetting()
            {

            }

            /// <summary>伝票PDF出力</summary>
            private string _outputMode;
            /// <summary>出力伝票区分</summary>
            private string _outputSlipType;
            /// <summary>PDFプリンタ [Windows標準／その他] </summary>
            private string _pDFPrinter;
            /// <summary>割り当て済みのプリンタ管理番号 </summary>
            private string _pDFPrinterNumber;
            /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
            private string _pDFPrinterWait;

            /// <summary>伝票PDF出力</summary>
            public string OutputMode
            {
                get { return _outputMode; }
                set { _outputMode = value; }
            }

            /// <summary>出力伝票区分</summary>
            public string OutputSlipType
            {
                get { return _outputSlipType; }
                set { _outputSlipType = value; }
            }
            /// <summary>PDFプリンタ [Windows標準／その他] </summary>
            public string PDFPrinter
            {
                get { return _pDFPrinter; }
                set { _pDFPrinter = value; }
            }

            /// <summary>割り当て済みのプリンタ管理番号 </summary>
            public string PDFPrinterNumber
            {
                get { return _pDFPrinterNumber; }
                set { _pDFPrinterNumber = value; }
            }

            /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
            public string PDFPrinterWait
            {
                get { return _pDFPrinterWait; }
                set { _pDFPrinterWait = value; }
            }

        }
        #endregion        
    }
}

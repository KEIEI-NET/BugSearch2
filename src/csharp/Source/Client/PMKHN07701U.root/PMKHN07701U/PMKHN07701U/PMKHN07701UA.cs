//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力（ＴＭＹ）
// プログラム概要   : 売上データテキスト出力（ＴＭＹ）　フォームクラス 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン
// 作 成 日  2011/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン 							
// 修 正 日  2012/11/21  修正内容 : Redmine#33560　 							
//　　　　　　　　　　　　　　　　　①TMY-IDについての仕様変更	
//                                  ②対象日付は記憶するようにする仕様変更
//                                  ③F9：取消は現場要望で削除する仕様変更
//                                  ④TMY-IDと出力フォルダ設定へのフォーカス移動をする仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン 							
// 修 正 日  2012/11/27  修正内容 : 自動送信の追加仕様変更
//----------------------------------------------------------------------------//
// 管理番号  　　　　　  作成担当 : 王君 							
// 修 正 日  2013/04/09  修正内容 : Redmine#35305 辰巳屋テキスト作成
//----------------------------------------------------------------------------//
// 管理番号  　　　　　  作成担当 : zhuhh 							
// 修 正 日  2013/04/18  修正内容 : Redmine#35368 自動送信区分の記憶を対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上データテキスト出力（ＴＭＹ）フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力（ＴＭＹ）フォームクラス</br>										
    /// <br>Programmer : 鄧潘ハン</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>管理番号   : 10805731-00</br>
    /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br>             Redmine#33560</br>
    /// <br>             ①TMY-IDについての仕様変更</br>
    /// <br>　　　　　　 ②対象日付は記憶するようにする仕様変更</br> 
    /// <br>　　　　　　 ③F9：取消は現場要望で削除する仕様変更</br> 
    /// <br>　　　　　　 ④TMY-IDと出力フォルダ設定へのフォーカス移動をする仕様変更</br> 
    /// <br>Update Note: 2012/11/27 鄧潘ハン</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br>             自動送信の追加仕様変更</br>
    /// <br>UpDate Note: 2013/04/09 王君</br>
    /// <br>           : Redmine#35305 辰巳屋テキスト作成</br>
    /// <br>UpDate Note: 2013/04/18 zhuhh</br>
    /// <br>           : Redmine#35368 自動送信区分の記憶を対応</br>
    /// </remarks>
    public partial class PMKHN07701UA : Form
    {
        // ===================================================================================== //
        // プライベートConst
        // ===================================================================================== //
        # region Private Constant
        
        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_EXTRACTTEXTBUTTON_KEY = "ButtonTool_ExtractText";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guid";
        //private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";//DEL　鄧潘ハン　2012/11/21 Redmine33560
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        // ガイド名称
        private const string ctGUIDE_NAME_CarMngNo = "uButton_CarMngNoGuide";
        private const string ctGUIDE_NAME_Supplier = "uButton_SupplierGuide";
        private const string ctGUIDE_NAME_FileName = "ultraButton_FileName";

        //入力メッセージ
        private const string MESSAGE_ApplyStaDate = "開始対象日付を入力して下さい。";
        private const string MESSAGE_ApplyEndDate = "終了対象日付を入力して下さい。";
        private const string MESSAGE_SendDiv = "自動送信を入力して下さい。";//ADD　鄧潘ハン　2012/11/27
        private const string MESSAGE_Note = "得意先分析コードを入力して下さい。";
        private const string MESSAGE_CarMngCode = "管理番号を入力して下さい。";
        private const string MESSAGE_SlipNote = "備考を入力して下さい。";
        private const string MESSAGE_SlipNote2 = "備考２を入力して下さい。";
        private const string MESSAGE_SlipNote3 = "備考３を入力して下さい。";
        private const string MESSAGE_PartySaleSlipNum = "仮伝番号/指示書NO.を入力して下さい。";
        private const string MESSAGE_SupplierCd = "仕入先を入力して下さい。";
        private const string MESSAGE_TMY_ID = "TMY-IDを入力して下さい。";
        private const string MESSAGE_FilePath = "出力先を入力して下さい。";

        // クラス名
        private const string ct_PRINTNAME = "売上データテキスト出力（TMY)";

        private const string ctSupprName = "未登録";

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _extractTextButton;			// テキスト出力ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;					// ガイドボタン
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// クリアボタン		//DEL　鄧潘ハン　2012/11/21 Redmine33560			
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private CarMngInputAcs _carMngInputAcs;            // 車輌管理マスタアクセスクラス
        private SupplierAcs _supplierAcs;
        private string _enterpriseCode;                    // 企業コード
        private string _loginSectionCode;                  // 拠点
        private DateGetAcs _dateGetAcs = null;                    // 日付取得部品
        private Dictionary<Int32, Supplier> _supInfoSetDic;
        private int _preSupprCode = -1;
        private string _fileName = string.Empty;

        //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
        private string _xmlfileName = string.Empty;　　　　//XMLファイル名称 
        private string _xmlfileDir = string.Empty;         //ファイルパス
        private string _fileNamePara = string.Empty;       //ファイル名
        //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<

        private Control _prevControl = null;									// 現在のコントロール
        private ControlScreenSkin _controlScreenSkin;                           // スキン設定用クラス

        private SalesSliptextAcs _salesSliptextAcs = null;
        private SalesSliptextCndtn _salesSliptextCndtn = null;
        private string _guideKey;
        private SFCMN00299CA msgForm = null;
        private FileInfo info = null;
        private FileStream f = null;
        private FormattedTextWriter _formattedTextWriter;

        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region　Constructor

        /// <summary>
        /// 売上データテキスト出力（ＴＭＹ）フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 売上データテキスト出力（ＴＭＹ）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 鄧潘ハン</br>										
        /// <br>Date        : 2012/10/31</br>										
        /// <br>管理番号    : 10805731-00</br>
        /// <br>Update Note : 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号    : 10805731-00</br>
        /// <br>              Redmine#33560</br>
        /// <br>              ①TMY-IDについての仕様変更</br>
        /// <br>　　　　　　  ②対象日付は記憶するようにする仕様変更</br> 
        /// <br>　　　　　　  ③F9：取消は現場要望で削除する仕様変更</br> 
        /// <br>Update Note: 2012/11/27 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加仕様変更</br>
        /// </remarks>
        public PMKHN07701UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._extractTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_EXTRACTTEXTBUTTON_KEY];
            //this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];//DEL　鄧潘ハン　2012/11/21 Redmine33560
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                       //企業コード
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;         //拠点コード
            this._carMngInputAcs = new CarMngInputAcs();                                      //車輌管理 アクセスクラス
            this._formattedTextWriter = new FormattedTextWriter();                            //CSV書き込み
            this._supplierAcs = new SupplierAcs();
            this._salesSliptextAcs = SalesSliptextAcs.GetInstance();                          //売上データテキスト出力（ＴＭＹ）　アクセスクラス
            this._dateGetAcs = DateGetAcs.GetInstance();                                      //日付チェック アクセスクラス
            this._controlScreenSkin = new ControlScreenSkin();                                //スキンをロード
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tNedit_CustAnalysCode1); // 得意先分析コード1
            ctrlList.Add(this.tNedit_CustAnalysCode2); // 得意先分析コード2
            ctrlList.Add(this.tNedit_CustAnalysCode3); // 得意先分析コード3
            ctrlList.Add(this.tNedit_CustAnalysCode4); // 得意先分析コード4
            ctrlList.Add(this.tNedit_CustAnalysCode5); // 得意先分析コード5
            ctrlList.Add(this.tNedit_CustAnalysCode6); // 得意先分析コード6
            ctrlList.Add(this.tEdit_CarMngCode);       // 管理番号
            ctrlList.Add(this.tEdit_SlipNote);         // 備考
            ctrlList.Add(this.tEdit_SlipNote2);        // 備考２
            ctrlList.Add(this.tEdit_SlipNote3);        // 備考３
            ctrlList.Add(this.tEdit_PartySaleSlipNum); // 仮伝番号/指示書№
            ctrlList.Add(this.tNedit_SupplierCd);      // 仕入先指定
            ctrlList.Add(this.uLabel_SupplierName);    // 仕入先名称
            //ctrlList.Add(this.tNedit_TMY_ID);        // TMY-ID //DEL　鄧潘ハン　2012/11/21 Redmine33560
            ctrlList.Add(this.tEdit_FilePath);         // 出力先	
            //---ADD　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
            ctrlList.Add(this.tEdit_TMY_ID);           // TMY-ID
            ctrlList.Add(this.ApplyStaDate_TDateEdit); // 開始対象日付
            ctrlList.Add(this.ApplyEndDate_TDateEdit); // 終了対象日付
            //---ADD　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<
            ctrlList.Add(this.uos_DataSendDiv);        //自動送信区分//ADD　鄧潘ハン　2012/11/27
            uiMemInput1.TargetControls = ctrlList;
            uiMemInput1.ReadOnLoad = false;

            // 仕入先マスタ読込
            ReadSupInfoSet();
        }

        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region　Private Methods
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>UpDate Note: 2013/04/09 王君</br>
        /// <br>           : Redmine#35305 辰巳屋テキスト作成</br>
        /// <br>UpDate Note: 2013/04/18 zhuhh</br>
        /// <br>           : Redmine#35368 自動送信区分の記憶を対応</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            this.uos_DataSendDiv.CheckedIndex = 1;// ADD zhuhh 2013/04/18 Redmine#35368
            this.ToolBarInitilSetting();       // ツールバー初期設定処理
            this.SetGuidButtonIcon();          // ボタンアイコン設定
            this.InitialScreenData();          //初期画面データ設定
            this.uiMemInput1.ReadMemInput();   //データ取込
            this.suppInit();                   //仕入先初期画面
            //this.uos_DataSendDiv.CheckedIndex = 1;   // 画面初期化時自動送信区分は「しない」をセットする　// ADD 王君 2013/04/10 Redmine#35305 // DEL zhuhh 2013/04/18 Redmine#35368
        }

        /// <summary>
        /// 仕入先初期画面
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先初期画面</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void suppInit()
        {
            string iniSupprName = "";
            if (this.tNedit_SupplierCd.GetInt() != 0)
            {
                iniSupprName = GetSupplierName(this.tNedit_SupplierCd.GetInt());
                this.uLabel_SupplierName.Text = iniSupprName;
            }
            else
            {
                this.uLabel_SupplierName.Text = string.Empty;
            }
        }

        #region ③F9：取消は現場要望で削除する仕様変更
        //---DEL　鄧潘ハン　2012/11/21 Redmine33560 ------------------->>>>>
        ///// <summary>
        ///// 画面初期化
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 画面初期化</br>										
        ///// <br>Programmer : 鄧潘ハン</br>										
        ///// <br>Date       : 2012/10/31</br>										
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        ///// <br>管理番号   : 10805731-00</br>
        ///// <br>             Redmine#33560</br>
        ///// <br>             ③F9：取消は現場要望で削除する仕様変更</br>
        ///// </remarks>
        //private void Clear()
        //{
        //    this.InitialScreenData();                         //画面初期化
        //    this.tNedit_CustAnalysCode1.Text = string.Empty;  //得意先分析コード1
        //    this.tNedit_CustAnalysCode2.Text = string.Empty;  //得意先分析コード2
        //    this.tNedit_CustAnalysCode3.Text = string.Empty;  //得意先分析コード3
        //    this.tNedit_CustAnalysCode4.Text = string.Empty;  //得意先分析コード4
        //    this.tNedit_CustAnalysCode5.Text = string.Empty;  //得意先分析コード5
        //    this.tNedit_CustAnalysCode6.Text = string.Empty;  //得意先分析コード6
        //    this.tEdit_CarMngCode.Text = string.Empty;        // 管理番号
        //    this.tEdit_SlipNote.Text = string.Empty;          // 備考
        //    this.tEdit_SlipNote2.Text = string.Empty;         // 備考２
        //    this.tEdit_SlipNote3.Text = string.Empty;         // 備考３
        //    this.tEdit_PartySaleSlipNum.Text = string.Empty;  // 仮伝番号/指示書№
        //    this.tNedit_SupplierCd.Text = string.Empty;       // 仕入先指定
        //    this.uLabel_SupplierName.Text = string.Empty;     // 仕入先名称
        //    this.tNedit_TMY_ID.Text = string.Empty;           // TMY-ID
        //    this.tEdit_FilePath.Text = string.Empty;          // 出力先	
        //    this.tEdit_ResultSlipCount.Text = "0";            //抽出伝票件数の初期化
        //    this.Initial_Timer.Enabled = true;
        //    this._preSupprCode = -1;
        //}
        //---DEL　鄧潘ハン　2012/11/21 Redmine33560 -------------------<<<<<
        #endregion

        /// <summary>
        /// 画面の日付と抽出伝票件数の初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の日付と抽出伝票件数の初期化</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void InitialScreenData()
        {
            this.ApplyStaDate_TDateEdit.SetDateTime(DateTime.Now);  //開始対象日付
            this.ApplyEndDate_TDateEdit.SetDateTime(DateTime.Now);  //終了対象日付
            this.tEdit_ResultSlipCount.Text = "0";                  //抽出伝票件数の初期化
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバー初期設定処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>　　　　　　 ③F9：取消は現場要望で削除する仕様変更</br> 
        /// </remarks>
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            this._extractTextButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.GUIDE;
            //this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;//DEL　鄧潘ハン　2012/11/21 Redmine33560
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタンのアイコン設定処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            //管理番号
            this.uButton_CarMngNoGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //仕入先指定
            this.uButton_SupplierGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //仕入先パス
            this.ultraButton_FileName.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// ボタンツール有効無効設定処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        /// <remarks>
        /// <br>Note       : ボタンツール有効無効設定処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                //なし。
            }

            if (targetControl.Name == "tEdit_CarMngCode"
                || targetControl.Name == "tNedit_SupplierCd")
            {
                this._guideButton.SharedProps.Enabled = true;
                this._guideKey = targetControl.Name;
            }
            else
            {
                this._guideButton.SharedProps.Enabled = false;
            }
        }

        /// <summary>
        /// 「ガイド」処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 「ガイド」処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void ExecuteGuide()
        {
            switch (this._guideKey)
            {
                // 管理番号
                case "tEdit_CarMngCode":
                    {
                        this.uButton_CarMngNoGuide_Click(this.uButton_CarMngNoGuide, new EventArgs());
                        break;
                    }

                //仕入先指定
                case "tNedit_SupplierCd":
                    {
                        this.uButton_SupplierGuide_Click(this.uButton_SupplierGuide, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面更新前チェック
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面更新前チェック</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560　辰巳屋テキストのTMY-IDについての仕様変更</br>
        /// </remarks>
        private bool BeforeSearchCheck()
        {
            // 得意先分析コード1
            int inputNote1Value = 0;
            this.tNedit_CustAnalysCode1.Text = this.tNedit_CustAnalysCode1.GetInt().ToString();
            // 得意先分析コード2
            int inputNote2Value = 0;
            this.tNedit_CustAnalysCode2.Text = this.tNedit_CustAnalysCode2.GetInt().ToString();
            // 得意先分析コード3
            int inputNote3Value = 0;
            this.tNedit_CustAnalysCode3.Text = this.tNedit_CustAnalysCode3.GetInt().ToString();
            // 得意先分析コード4
            int inputNote4Value = 0;
            this.tNedit_CustAnalysCode4.Text = this.tNedit_CustAnalysCode4.GetInt().ToString();
            // 得意先分析コード5
            int inputNote5Value = 0;
            this.tNedit_CustAnalysCode5.Text = this.tNedit_CustAnalysCode5.GetInt().ToString();
            // 得意先分析コード6
            int inputNote6Value = 0;
            this.tNedit_CustAnalysCode6.Text = this.tNedit_CustAnalysCode6.GetInt().ToString();
            //仕入先コード
            int inputSupplierCdValue = 0;
            int supprCode = this.tNedit_SupplierCd.GetInt();
            string supprName = string.Empty;
            //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
            //TMY_ID
            //int inputTmyidValue = 0;
            //this.tNedit_TMY_ID.Text = this.tNedit_TMY_ID.GetInt().ToString();
            //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<
            //相手先伝票番号
            int inputPartySaleSlipNumValue = 0;
         
            //得意先分析コード1F10の場合のチェック
            if (Int32.TryParse(this.tNedit_CustAnalysCode1.Text.Trim(), out inputNote1Value))
            {
                if (inputNote1Value == 0)
                {
                    this.tNedit_CustAnalysCode1.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_CustAnalysCode1.Clear();
            }

            //得意先分析コード2F10の場合のチェック
            if (Int32.TryParse(this.tNedit_CustAnalysCode2.Text.Trim(), out inputNote2Value))
            {
                if (inputNote2Value == 0)
                {
                    this.tNedit_CustAnalysCode2.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_CustAnalysCode2.Clear();
            }


            //得意先分析コード3F10の場合のチェック
            if (Int32.TryParse(this.tNedit_CustAnalysCode3.Text.Trim(), out inputNote3Value))
            {
                if (inputNote3Value == 0)
                {
                    this.tNedit_CustAnalysCode3.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_CustAnalysCode3.Clear();
            }

            //得意先分析コード4F10の場合のチェック
            if (Int32.TryParse(this.tNedit_CustAnalysCode4.Text.Trim(), out inputNote4Value))
            {
                if (inputNote4Value == 0)
                {
                    this.tNedit_CustAnalysCode4.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_CustAnalysCode4.Clear();
            }

            //得意先分析コード5F10の場合のチェック
            if (Int32.TryParse(this.tNedit_CustAnalysCode5.Text.Trim(), out inputNote5Value))
            {
                if (inputNote5Value == 0)
                {
                    this.tNedit_CustAnalysCode5.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_CustAnalysCode5.Clear();
            }

            //得意先分析コード6F10の場合のチェック
            if (Int32.TryParse(this.tNedit_CustAnalysCode6.Text.Trim(), out inputNote6Value))
            {
                if (inputNote6Value == 0)
                {
                    this.tNedit_CustAnalysCode6.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_CustAnalysCode6.Clear();
            }

            //仕入先コードF10の場合のチェック
            if (Int32.TryParse(this.tNedit_SupplierCd.Text.Trim(), out inputSupplierCdValue))
            {
                if (inputSupplierCdValue == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                }
                else
                {
                    //なし。
                }
            }
            else
            {
                this.tNedit_SupplierCd.Clear();
            }
            if (supprCode != 0 && supprCode != _preSupprCode)
            {
                _preSupprCode = supprCode;
                supprName = GetSupplierName(supprCode);
                this.uLabel_SupplierName.Text = supprName;
            }
            else if (supprCode == 0)
            {
                _preSupprCode = supprCode; //ADD　鄧潘ハン　2012/11/21 Redmine33560
                this.uLabel_SupplierName.Text = string.Empty;
            }
            else
            {
                //なし。
            }
            //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
            //TMY_IDF10の場合のチェック
            //if (Int32.TryParse(this.tNedit_TMY_ID.Text.Trim(), out inputTmyidValue))
            //{
            //    if (inputTmyidValue == 0)
            //    {
            //        this.tNedit_TMY_ID.Clear();
            //    }
            //    else
            //    {
            //        //なし。
            //    }
            //}
            //else
            //{
            //    this.tNedit_TMY_ID.Clear();

            //}
            //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<

            //相手先伝票番号
            if (Int32.TryParse(this.tEdit_PartySaleSlipNum.Text.Trim(), out inputPartySaleSlipNumValue))
            {
                if (inputPartySaleSlipNumValue != 0 && this.tEdit_PartySaleSlipNum.Text.ToString().Trim().Length < 9)
                {
                    this.tEdit_PartySaleSlipNum.Text = Convert.ToInt32(this.tEdit_PartySaleSlipNum.Text.Trim()).ToString("000000000");
                }
                else
                {
                    this.tEdit_PartySaleSlipNum.Text = this.tEdit_PartySaleSlipNum.Text.Trim();
                }
            }
            else
            {
                this.tEdit_PartySaleSlipNum.Text = this.tEdit_PartySaleSlipNum.Text.Trim();
            }

            DateGetAcs.CheckDateResult cdResult;
            // 適用開始日
            if (CallCheckDate(out cdResult, ref this.ApplyStaDate_TDateEdit) == false)
            {
                // 処理日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // 不正値を入力時エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "開始対象日付の入力が不正です。",                   // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                            // フォーカス設定
                            this.ApplyStaDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // 未入力の場合エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "開始対象日付を入力してください。",                 // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);
                            // フォーカス設定
                            this.ApplyStaDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }
            else
            {
                //なし。
            }

            // 適用終了日
            if (CallCheckDate(out cdResult, ref this.ApplyEndDate_TDateEdit) == false)
            {
                // 処理日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // 不正値を入力時エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "終了対象日付の入力が不正です。",                   // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                           
                            // フォーカス設定
                            this.ApplyEndDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // 未入力の場合エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "終了対象日付を入力してください。",                 // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                            // フォーカス設定
                            this.ApplyEndDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }
            else
            {
                //なし。
            }

            // 対象日付の入力
            if (this.ApplyStaDate_TDateEdit.GetLongDate() > this.ApplyEndDate_TDateEdit.GetLongDate())
            {
                // 開始＞終了
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "対象日付の範囲に誤りがあります。",               　// 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.ApplyStaDate_TDateEdit.Focus();
                this._prevControl = this.ApplyStaDate_TDateEdit;
                return false;
            }
            else
            {
                //なし。
            }

            // 対象日付の範囲
            if (!(this.ApplyEndDate_TDateEdit.GetDateMonth() == this.ApplyStaDate_TDateEdit.GetDateMonth()
                && this.ApplyEndDate_TDateEdit.GetDateYear() == this.ApplyStaDate_TDateEdit.GetDateYear()))
            {
                //入力日付の範囲は同一月内ではない
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "日付の範囲が違います。",    　　　　　　　　　　　 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.ApplyStaDate_TDateEdit.Focus();
                this._prevControl = this.ApplyStaDate_TDateEdit;
                return false;
            }
            else
            {
                //なし。
            }

            if (string.IsNullOrEmpty(this.tNedit_CustAnalysCode1.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode2.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode3.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode4.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode5.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode6.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_CarMngCode.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_SlipNote2.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_SlipNote3.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_PartySaleSlipNum.Text.Trim()))
            {
            
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "項目が未設定です。",    　                         // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);
                // フォーカス設定
                this.tNedit_CustAnalysCode1.Focus();
                this._prevControl = this.tNedit_CustAnalysCode1; 
                return false;
            }
            else
            {
                //なし。
            }

            //if (string.IsNullOrEmpty(this.tNedit_TMY_ID.Text.Trim()))//DEL　鄧潘ハン　2012/11/21 Redmine33560
            if (string.IsNullOrEmpty(this.tEdit_TMY_ID.Text.Trim()))//ADD　鄧潘ハン　2012/11/21 Redmine33560
            {
            
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "TMY-IDを入力してください。",    　                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560----->>>>>
                //this.tNedit_TMY_ID.Focus();
                //this._prevControl = this.tNedit_TMY_ID;
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560-----<<<<<
                //---ADD　鄧潘ハン　2012/11/21 Redmine33560----->>>>>
                this.tEdit_TMY_ID.Focus();
                this._prevControl = this.tEdit_TMY_ID;
                //---ADD　鄧潘ハン　2012/11/21 Redmine33560-----<<<<<
                return false;
            }
            else
            {
                //なし。
            }

            if(string.IsNullOrEmpty(this.tEdit_FilePath.Text.Trim()))
            {
            
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "出力先を入力してください。",    　                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);
                // フォーカス設定
                this.tEdit_FilePath.Focus();
                this._prevControl = this.tEdit_FilePath;  
                return false;
            }
            else
            {
                //なし。
            }
            return true;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult">cdResult</param>
        /// <param name="targetDateEdit">targetDateEdit</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 日付チェック処理呼び出し</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = this._dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// 仕入先マスタ読込
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）仕入先マスタ読込</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void ReadSupInfoSet()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            this._supInfoSetDic = new Dictionary<Int32, Supplier>();
            ArrayList suppList = null;
            status = this._supplierAcs.SearchAll(out suppList, this._enterpriseCode);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Supplier supplier in suppList)
                {
                    if (supplier.LogicalDeleteCode == 0)
                    {
                        this._supInfoSetDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            else
            {
                //なし。
            }
        }


        #region[文字列　バイト数指定切り抜き]
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        /// <remarks>
        /// <br>Note       : 文字列　バイト数指定切り抜き</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }
            else
            {
                //なし。
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount)
                {
                    break;
                }
                else
                {
                    //なし。
                } 
            }

            // 終端の空白は削除
            return resultString;

        }
        #endregion

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージ表示処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMKHN07701UA",						// アセンブリＩＤまたはクラスＩＤ
                ct_PRINTNAME,				        // プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        ///	Form.Load イベント(PMKHN07701U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Form.Load イベント(PMKHN07701U)</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07701UA_Load(object sender, EventArgs e)
        {
            // 画面初期化
            InitialScreenSetting();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             ③F9：取消は現場要望で削除する仕様変更</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                // CSV出力
                case TOOLBAR_EXTRACTTEXTBUTTON_KEY:
                    {
                        this.ExtractText();
                        break;
                    }
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560------>>>>>
                // クリア
                //case TOOLBAR_CLEARBUTTON_KEY:
                //    {
                //        // クリア処理
                //        this.Clear();
                //        break;
                //    }
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560------<<<<<
                // ガイド
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.ExecuteGuide();
                        break;
                    }
                  
            }
        }

        /// <summary>
        /// データ抽出して、テキスト生成
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ抽出して、テキスト生成</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560　辰巳屋テキストのTMY-IDについての仕様変更</br>
        /// <br>Update Note: 2012/11/27 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加仕様変更</br>
        /// </remarks>
        private void ExtractText()
        {
             int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
             int _totalCount = 0;
             string ex = string.Empty;
             //---ADD　鄧潘ハン　2012/11/27 ------>>>>>
             int deleteFlag = -1;
             int insertFlag = -1;
             //---ADD　鄧潘ハン　2012/11/27 ------<<<<<
             

             // オフライン状態チェック
             if (!CheckOnline())
             {
                 TMsgDisp.Show(
                     emErrorLevel.ERR_LEVEL_STOP,
                     this.Text,
                     this.Text + "画面更新処理に失敗しました。",
                     (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                 return;

             }
             else
             {
                 //なし。
             } 

             // チェック
             bool isUpdate = this.BeforeSearchCheck();
             if ((this._prevControl != null) && (this._prevControl.TabStop))
             {
                 this.SettingGuideButtonToolEnabled(this._prevControl);
                 this.StatusBarMessageSettingProc(this._prevControl);
             }
             else
             {
                 //なし。
             } 

             if (!isUpdate)
             {
                 return;
             }
             else
             {
                 //なし。
             } 

             //this._fileName = this.tEdit_FilePath.DataText.ToString().Trim() + "\\" + this.tNedit_TMY_ID.Text.Trim()//DEL　鄧潘ハン　2012/11/21 Redmine33560
             this._fileName = this.tEdit_FilePath.DataText.ToString().Trim() + "\\" + this.tEdit_TMY_ID.Text.Trim()//ADD　鄧潘ハン　2012/11/21 Redmine33560
              + ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00") + ".CSV";
             //---ADD　鄧潘ハン　2012/11/27  ------------->>>>>
             this._xmlfileName =  this.tEdit_FilePath.DataText.ToString().Trim() + "\\" + this.tEdit_TMY_ID.Text.Trim()
              + ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00") + ".XML";
             this._xmlfileDir = this.tEdit_FilePath.DataText.ToString().Trim();
             this._fileNamePara = this.tEdit_TMY_ID.Text.Trim()+ ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00");
             //---ADD　鄧潘ハン　2012/11/27  -------------<<<<<
             // 画面→抽出条件クラス
             status = this.SetExtraInfoFromScreen();

             if (status != 0)
             {
                 return;
             }
             else
             {
                 //なし。
             } 

             if (!Directory.Exists(System.IO.Path.GetDirectoryName(this._fileName)))
             {
                 TMsgDisp.Show(
                 this,
                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                 this.Name,
                  "CSVファイルパスが不正です。",
                 status,
                 MessageBoxButtons.OK);
                 this._prevControl = this.tEdit_FilePath;
                 this.tEdit_FilePath.Focus();
                 this.SettingGuideButtonToolEnabled(this.tEdit_FilePath);
                 this.StatusBarMessageSettingProc(this.tEdit_FilePath);
                 return;
             }
             else
             {
                 //なし。
             } 
             if (File.Exists(this._fileName))
             {
                 // 確認メッセージを表示する。
                 DialogResult result = TMsgDisp.Show(
                             emErrorLevel.ERR_LEVEL_QUESTION,                               // エラーレベル
                             "PMKHN07701UA",						                        // アセンブリＩＤまたはクラスＩＤ
                             ct_PRINTNAME,				                                    // プログラム名称
                             "", 								                            // 処理名称
                             "",									                        // オペレーション
                             "同一名の出力ファイルが既に存在します。処理を続行しますか？",	// 表示するメッセージ
                             -1, 							                                // ステータス値
                             null, 								                            // エラーが発生したオブジェクト
                             MessageBoxButtons.YesNo, 				                        // 表示するボタン
                             MessageBoxDefaultButton.Button1);	                            // 初期表示ボタン
                 // 入力画面へ戻る。
                 if (result == DialogResult.No)
                 {
                     return;
                 }
                 else
                 {
                     //なし。
                 } 
             }
             else
             {
                 //なし。
             } 
             //CreateFile();//DEL　鄧潘ハン　2012/11/27
             int resultCount = 0;
             // 抽出中画面部品のインスタンスを作成
             msgForm = new SFCMN00299CA();
             msgForm.Title = "抽出中";
             msgForm.Message = "現在、データ抽出中です。                  ￥nしばらくお待ちください";
             string messages = string.Empty;
             try
             {
                 msgForm.Show();
                 // 検索
                 //status = this._salesSliptextAcs.SearchData(this._salesSliptextCndtn, this.tNedit_TMY_ID.Text.Trim(), ref resultCount, ref messages);//DEL　鄧潘ハン　2012/11/21 Redmine33560
                 status = this._salesSliptextAcs.SearchData(this._salesSliptextCndtn, this.tEdit_TMY_ID.Text.Trim(), ref resultCount, ref messages);//ADD　鄧潘ハン　2012/11/21 Redmine33560

                 msgForm.Close();
                 //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
                 deleteFlag = DeleteFile();
                 if (deleteFlag == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                 {
                     CreateFile();
                 }
                 else
                 {
                     //該当なし。
                 }
                 //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
                 switch (status)
                 {
                     case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                         //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
                         if (deleteFlag != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                         {
                             break;
                         }
                         else
                         {
                             if (resultCount != 0 && uos_DataSendDiv.CheckedIndex == 0)
                             {
                                 insertFlag = SaveNetSendSetting();
                                 if (insertFlag != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                 {
                                     break;
                                 }
                                 else
                                 {
                                     //該当なし。
                                 }
                             }
                             else
                             {
                                 //該当なし。
                             }
                         }
                         //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
                         this.tEdit_ResultSlipCount.DataText = string.Format("{0:###,###,##0}", resultCount);
                         SetFormattedTextWriter();
                         string resultMessage = "";
                         try
                         {
                             status = _formattedTextWriter.TextOut(out _totalCount);
                         }
                         catch
                         {
                             status = -1;
                         }
                         if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                         {
                             resultMessage = "CSVデータを作成しました。";
                             MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, resultMessage, status);
                             //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
                             if (insertFlag == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                             {
                                 this._salesSliptextAcs.SendAndReceive(this._salesSliptextCndtn, this._xmlfileDir, this._fileNamePara);
                             }
                             //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
                         }
                         else
                         {
                             resultMessage = "テキストファイルの書き込みに失敗しました。";
                             MsgDispProc(emErrorLevel.ERR_LEVEL_STOP,resultMessage, 9);
                         }
                         break;

                     case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                         this.tEdit_ResultSlipCount.DataText = "0";
                         MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "検索条件に該当するデータは存在しません。", (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                         break;

                     default:
                         if (string.IsNullOrEmpty(messages))
                         {
                             MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "検索に失敗しました。", -1);
                         }
                         else
                         {
                             MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, messages, status);
                         }
                         break;
                 }
             }
             finally
             {
                 //該当なし。
             } 
        }

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件設定処理(画面→抽出条件)</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._salesSliptextCndtn = new SalesSliptextCndtn();
            try
            {
                // 企業コード
                this._salesSliptextCndtn.EnterpriseCode = this._enterpriseCode;

                //対象日の開始日
                this._salesSliptextCndtn.SalesDateSt = this.ApplyStaDate_TDateEdit.GetLongDate();

                //対象日の終了日
                this._salesSliptextCndtn.SalesDateEd = this.ApplyEndDate_TDateEdit.GetLongDate();

                //車輌管理コード
                this._salesSliptextCndtn.CarMngNo1 = this.tEdit_CarMngCode.Text.Trim();

                //仕入先コード
                this._salesSliptextCndtn.SupplierCd = this.tNedit_SupplierCd.GetInt();

                //相手先伝票番号
                this._salesSliptextCndtn.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text.Trim();
               
                //得意先分析コード1
                this._salesSliptextCndtn.CustAnalysCode1 = this.tNedit_CustAnalysCode1.GetInt();

                //得意先分析コード2
                this._salesSliptextCndtn.CustAnalysCode2 = this.tNedit_CustAnalysCode2.GetInt();

                //得意先分析コード3
                this._salesSliptextCndtn.CustAnalysCode3 = this.tNedit_CustAnalysCode3.GetInt();

                //得意先分析コード4
                this._salesSliptextCndtn.CustAnalysCode4 = this.tNedit_CustAnalysCode4.GetInt();

                //得意先分析コード5
                this._salesSliptextCndtn.CustAnalysCode5 = this.tNedit_CustAnalysCode5.GetInt();

                //得意先分析コード6
                this._salesSliptextCndtn.CustAnalysCode6 = this.tNedit_CustAnalysCode6.GetInt();

                //伝票備考
                this._salesSliptextCndtn.SlipNote = this.tEdit_SlipNote.Text.Trim();

                //伝票備考２
                this._salesSliptextCndtn.SlipNote2 = this.tEdit_SlipNote2.Text.Trim();

                //伝票備考３
                this._salesSliptextCndtn.SlipNote3 = this.tEdit_SlipNote3.Text.Trim();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        # endregion
       
        /// <summary>
        /// CSV書き込みデータ取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : CSV書き込みデータ取得</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560　辰巳屋テキストのTMY-IDについての仕様変更</br>
        /// </remarks>
        private void SetFormattedTextWriter()
        {
            List<string> schemeList = new List<string>();
            // データ区分
            schemeList.Add("DATADIV");
            // TMY-ID
            schemeList.Add("TMYID");
            // 得意先ｺｰﾄﾞ
            schemeList.Add("CUSTOMERCODE");
            // 売上日付
            schemeList.Add("SALESDATE");
            // 売上伝票番号
            schemeList.Add("SALESSLIPNUM");
            // 売上行番号
            schemeList.Add("SALESROWNO");
            // 商品番号
            schemeList.Add("GOODSNO");
            // 商品メーカーコード
            schemeList.Add("GOODSMAKERCD");
            // BL商品コード
            schemeList.Add("BLGOODSCODE");
            // 出荷数
            schemeList.Add("SHIPMENTCNT");
            // 仕入先コード
            schemeList.Add("SUPPLIERCD");
            
            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();

            // データ区分
            maxLengthList.Add("DATADIV", 2);
            // TMY-ID
            maxLengthList.Add("TMYID", 7);
            // 得意先ｺｰﾄﾞ
            maxLengthList.Add("CUSTOMERCODE", 8);
            // 売上日付
            maxLengthList.Add("SALESDATE", 8);
            // 売上伝票番号
            maxLengthList.Add("SALESSLIPNUM", 9);
            // 売上行番号
            maxLengthList.Add("SALESROWNO", 2);
            // 商品番号
            maxLengthList.Add("GOODSNO", 20);
            // 商品メーカーコード
            maxLengthList.Add("GOODSMAKERCD", 4);
            // BL商品コード
            maxLengthList.Add("BLGOODSCODE", 5);
            // 出荷数
            maxLengthList.Add("SHIPMENTCNT", 8);
            // 仕入先コード
            maxLengthList.Add("SUPPLIERCD", 6);

            _formattedTextWriter.DataSource = this._salesSliptextAcs.SalesSliptextCsv;
            _formattedTextWriter.DataMember = String.Empty;
            //_formattedTextWriter.OutputFileName = this.tEdit_FilePath.DataText.ToString() + "\\" + this.tNedit_TMY_ID.Text.Trim()//DEL　鄧潘ハン　2012/11/21 Redmine33560
            _formattedTextWriter.OutputFileName = this.tEdit_FilePath.DataText.ToString() + "\\" + this.tEdit_TMY_ID.Text.Trim()//ADD　鄧潘ハン　2012/11/21 Redmine33560
               + ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00") + ".CSV";
            //テキスト出力する項目名のリスト
            _formattedTextWriter.SchemeList = schemeList;
            _formattedTextWriter.Splitter = ",";
            _formattedTextWriter.Encloser = "\"";
            _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            _formattedTextWriter.FormatList = null;
            _formattedTextWriter.CaptionOutput = false;
            _formattedTextWriter.FixedLength = false;
            _formattedTextWriter.ReplaceList = null;
            _formattedTextWriter.MaxLengthList = maxLengthList;

        }

   
        /// <summary>
        /// ファイルの作成
        /// </summary>
        /// <returns>スタータス</returns>
        /// <remarks>
        /// <br>Note       : ファイルの作成</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private int CreateFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // ファイル
                info = new FileInfo(this._fileName);
                f = info.Create();
                //メモリクリア
                f.Close();

            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// フォーカス設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : フォーカス設定</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.ApplyStaDate_TDateEdit.Focus();
            this.SettingGuideButtonToolEnabled(this.ApplyStaDate_TDateEdit);
            this.StatusBarMessageSettingProc(this.ApplyStaDate_TDateEdit);
            this._guideKey = this.ApplyStaDate_TDateEdit.Name;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ChangeFocus イベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             ①TMY-IDについての仕様変更</br>
        /// <br>　　　　　　 ④TMY-IDと出力フォルダ設定へのフォーカス移動をする仕様変更</br> 
        /// <br>Update Note: 2012/11/27 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加仕様変更</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }
            else
            {
                //なし。
            }
            this._prevControl = e.NextCtrl;
            switch (e.PrevCtrl.Name)
            {
                // 対象日付開始
                case "ApplyStaDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.ApplyEndDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                // フォーカス設定
                                //this._prevControl = this.tNedit_CustAnalysCode1;//DEL　鄧潘ハン　2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//ADD　鄧潘ハン　2012/11/27
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        break;
                    }

                // 対象日付終了  
                case "ApplyEndDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                //this._prevControl = this.tNedit_CustAnalysCode1;//DEL　鄧潘ハン　2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//ADD　鄧潘ハン　2012/11/27
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = this.ApplyEndDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.ApplyEndDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                // フォーカス設定
                                //this._prevControl = this.tNedit_CustAnalysCode6;//DEL　鄧潘ハン　2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//DEL　鄧潘ハン　2012/11/27
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }
                //---ADD　鄧潘ハン　2012/11/27  ------------->>>>>
                // 自動送信  
                case "uos_DataSendDiv":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.uos_DataSendDiv;
                            }
                            else
                            {
                              //なし。
                            }
                        }
                        else
                        {
                            //なし。
                        }
                        break;
                    }
                //---ADD　鄧潘ハン　2012/11/27  ------------<<<<<
                //　得意先分析コード1
                case "tNedit_CustAnalysCode1":
                    {
                        this.tNedit_CustAnalysCode1.Text = this.tNedit_CustAnalysCode1.GetInt().ToString();
                        int inputNote1Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode1.Text.Trim(), out inputNote1Value))
                        {
                            if (inputNote1Value == 0)
                            {
                                this.tNedit_CustAnalysCode1.Clear();
                            }
                            else
                            {
                               //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode1.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode2;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                //this._prevControl = this.ApplyEndDate_TDateEdit;//DEL　鄧潘ハン　2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//ADD　鄧潘ハン　2012/11/27
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　得意先分析コード2
                case "tNedit_CustAnalysCode2":
                    {
                        this.tNedit_CustAnalysCode2.Text = this.tNedit_CustAnalysCode2.GetInt().ToString();
                        int inputNote2Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode2.Text.Trim(), out inputNote2Value))
                        {
                            if (inputNote2Value == 0)
                            {
                                this.tNedit_CustAnalysCode2.Clear();
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode2.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode3;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode1;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　得意先分析コード3
                case "tNedit_CustAnalysCode3":
                    {
                        this.tNedit_CustAnalysCode3.Text = this.tNedit_CustAnalysCode3.GetInt().ToString();
                        int inputNote3Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode3.Text.Trim(), out inputNote3Value))
                        {
                            if (inputNote3Value == 0)
                            {
                                this.tNedit_CustAnalysCode3.Clear();
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode3.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode4;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode2;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　得意先分析コード4
                case "tNedit_CustAnalysCode4":
                    {
                        this.tNedit_CustAnalysCode4.Text = this.tNedit_CustAnalysCode4.GetInt().ToString();
                        int inputNote4Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode4.Text.Trim(), out inputNote4Value))
                        {
                            if (inputNote4Value == 0)
                            {
                                this.tNedit_CustAnalysCode4.Clear();
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode4.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode5;
                            }
                            if (e.Key == Keys.Down)
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode3;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　得意先分析コード5
                case "tNedit_CustAnalysCode5":
                    {
                        this.tNedit_CustAnalysCode5.Text = this.tNedit_CustAnalysCode5.GetInt().ToString();
                        int inputNote5Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode5.Text.Trim(), out inputNote5Value))
                        {
                            if (inputNote5Value == 0)
                            {
                                this.tNedit_CustAnalysCode5.Clear();
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode5.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode6;
                            }
                            if (e.Key == Keys.Down)
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode4;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }
                //　得意先分析コード6
                case "tNedit_CustAnalysCode6":
                    {
                        this.tNedit_CustAnalysCode6.Text = this.tNedit_CustAnalysCode6.GetInt().ToString();
                        int inputNote6Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode6.Text.Trim(), out inputNote6Value))
                        {
                            if (inputNote6Value == 0)
                            {
                                this.tNedit_CustAnalysCode6.Clear();
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode6.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode6;
                            }
                            if (e.Key == Keys.Down)
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            //---ADD　鄧潘ハン　2012/11/27 ---------->>>>>
                            if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = this.uos_DataSendDiv;
                            }
                            //---ADD　鄧潘ハン　2012/11/27 ----------<<<<<
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode5;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }
                //　管理番号
                case "tEdit_CarMngCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (string.IsNullOrEmpty(this.tEdit_CarMngCode.Text.Trim()))
                                {
                                    // フォーカス設定
                                    this._prevControl = this.uButton_CarMngNoGuide;
                                }
                                else
                                {
                                    // フォーカス設定
                                    this._prevControl = this.tEdit_SlipNote;
                                }

                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.uButton_CarMngNoGuide;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode1;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_CustAnalysCode6;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　管理番号ガイド
                case "uButton_CarMngNoGuide":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_SlipNote;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.uButton_CarMngNoGuide;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                 //　備考　（先頭一致）
                case "tEdit_SlipNote":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_SlipNote2;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = tEdit_SlipNote;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = tEdit_CarMngCode;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.uButton_CarMngNoGuide;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　備考２（先頭一致）
                case "tEdit_SlipNote2":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_SlipNote3;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = tEdit_SlipNote2;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_SlipNote;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　備考３（先頭一致）
                case "tEdit_SlipNote3":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = tEdit_SlipNote3;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_SlipNote2;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                //　仮伝番号/指示書№
                case "tEdit_PartySaleSlipNum":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_SupplierCd;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = tEdit_PartySaleSlipNum;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_SlipNote3;
                            }
                            else
                            {
                                //なし。
                            }

                        }
                        break;
                    }

                 //　仕入先指定
                case "tNedit_SupplierCd":
                    {
                        int inputSupplierCdValue = 0;
                        if (Int32.TryParse(this.tNedit_SupplierCd.Text.Trim(), out inputSupplierCdValue))
                        {
                            if (inputSupplierCdValue == 0)
                            {
                                this.tNedit_SupplierCd.Clear();
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            this.tNedit_SupplierCd.Clear();
                        }

                        int supprCode = this.tNedit_SupplierCd.GetInt();
                        string supprName = string.Empty;


                        if (supprCode != 0 && supprCode != _preSupprCode)
                        {
                            _preSupprCode = supprCode;
                            supprName = GetSupplierName(supprCode);
                            this.uLabel_SupplierName.Text = supprName;
                        }
                        else if (supprCode == 0)
                        {
                            _preSupprCode = supprCode; //ADD　鄧潘ハン　2012/11/21 Redmine33560
                            this.uLabel_SupplierName.Text = string.Empty;
                        }
                        else
                        {
                            //なし。
                        }

                        if (e.ShiftKey == false)
                        {
                            //if ((e.Key == Keys.Tab) ||( e.Key == Keys.Enter))//DEL　鄧潘ハン　2012/11/21 Redmine33560
                            if (e.Key == Keys.Tab)//ADD　鄧潘ハン　2012/11/21 Redmine33560
                            {
                                if (this.tNedit_SupplierCd.GetInt() == 0)
                                {
                                    // フォーカス設定
                                    this._prevControl = this.uButton_SupplierGuide;
                                }
                                else
                                {
                                    // フォーカス設定
                                    //this._prevControl = this.tNedit_TMY_ID;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                                    this._prevControl = this.tEdit_TMY_ID;//ADD　鄧潘ハン　2012/11/21 Redmine33560
                                }
                            }
                            //---ADD　鄧潘ハン　2012/11/21 Redmine33560------>>>>>
                            else if (e.Key == Keys.Enter)
                            {
                                if (this.tNedit_SupplierCd.GetInt() == 0)
                                {
                                    // フォーカス設定
                                    this._prevControl = this.uButton_SupplierGuide;
                                }
                                else
                                {
                                    // フォーカス設定
                                    this._prevControl = this.ApplyStaDate_TDateEdit;
                                }
                            }
                            //---ADD　鄧潘ハン　2012/11/21 Redmine33560------<<<<<
                            else if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.uButton_SupplierGuide;
                            }
                            else if (e.Key == Keys.Down) 
                            {
                                // フォーカス設定
                                //this._prevControl = this.tNedit_TMY_ID;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                                this._prevControl = this.ApplyStaDate_TDateEdit;//ADD　鄧潘ハン　2012/11/21 Redmine33560
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            else
                            {
                                //なし。
                            } 

                        }
                        break;
                    }
                 //　仕入先指定ガイド
                case "uButton_SupplierGuide":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            //---ADD　鄧潘ハン　2012/11/21 Redmine33560------>>>>>
                            else if ((e.Key == Keys.Enter) || (e.Key == Keys.Down) || (e.Key == Keys.Right))
                            {
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            //---ADD　鄧潘ハン　2012/11/21 Redmine33560------<<<<<
                            else if (e.Key == Keys.Left)
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_SupplierCd;
                            }
                            //---DEL　鄧潘ハン　2012/11/21 Redmine33560------>>>>>
                            //else if (e.Key == Keys.Right)
                            //{
                            //    // フォーカス設定
                            //    this._prevControl = this.uButton_SupplierGuide;
                            //}
                            //else if ((e.Key == Keys.Enter)|| (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            //{
                            //    // フォーカス設定
                            //    //this._prevControl = this.tNedit_TMY_ID;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                            //    this._prevControl = this.tEdit_TMY_ID;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                            //}
                            //---DEL　鄧潘ハン　2012/11/21 Redmine33560------<<<<<
                            else
                            {
                                //なし。
                            }
                        }
                        break;
                    }
                //　TMY_ID
                //case "tNedit_TMY_ID"://DEL　鄧潘ハン　2012/11/21 Redmine33560
                case "tEdit_TMY_ID"://ADD　鄧潘ハン　2012/11/21 Redmine33560
                    {
                        //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
                        //this.tNedit_TMY_ID.Text = this.tNedit_TMY_ID.GetInt().ToString();
                        //int inputTmyidValue = 0;
                        //if (Int32.TryParse(this.tNedit_TMY_ID.Text.Trim(), out inputTmyidValue))  
                        //{
                        //    if (inputTmyidValue == 0)
                        //    {
                        //        this.tNedit_TMY_ID.Clear();
                        //    }
                        //    else
                        //    {
                        //        //なし。
                        //    }
                        //}
                        //else
                        //{
                        //    this.tNedit_TMY_ID.Clear();

                        //}
                        //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Up) || (e.Key == Keys.Left))
                            {
                                // フォーカス設定
                                this._prevControl = this.tNedit_SupplierCd;
                            }
                            if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                //this._prevControl = this.tNedit_TMY_ID;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                                this._prevControl = this.tEdit_TMY_ID;//ADD　鄧潘ハン　2012/11/21 Redmine33560
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        break;
                    }
                //　出力先
                case "tEdit_FilePath":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                // フォーカス設定
                                this._prevControl = this.ultraButton_FileName;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        break;
                    }
                 //　出力先ガイド
                case "ultraButton_FileName":
                      {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Left)
                            {
                                // フォーカス設定
                                this._prevControl = this.tEdit_FilePath;
                            }
                            else
                            {
                                //なし。
                            }
                        }
                        break;
                    }
                  
            }


            e.NextCtrl = this._prevControl;
            //ガイドボタンツール有効無効設定処理
            if ((this._prevControl != null) && (this._prevControl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(this._prevControl);
                this.StatusBarMessageSettingProc(this._prevControl);
            }
            else
            {
                //なし。
            } 
        }

        # region ■ StatusBarメッセージ表示処理 ■
        /// <summary>
        /// StatusBarメッセージ表示処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        /// <remarks>
        /// <br>Note		: 売上データテキスト出力（ＴＭＹ）StatusBarメッセージ表示処理</br>
        /// <br>Programmer  : 鄧潘ハン</br>										
        /// <br>Date        : 2012/10/31</br>										
        /// <br>管理番号    : 10805731-00</br>
        /// <br>Update Note : 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号    : 10805731-00</br>
        /// <br>              Redmine#33560　辰巳屋テキストのTMY-IDについての仕様変更</br>
        /// <br>Update Note : 2012/11/27 鄧潘ハン</br>
        /// <br>管理番号    : 10805731-00</br>
        /// <br>              自動送信の追加仕様変更</br>
        /// </remarks>
        private void StatusBarMessageSettingProc(Control nextControl)
        {
            string message = "";

            if (nextControl.Name == ApplyStaDate_TDateEdit.Name)
            {
                message = MESSAGE_ApplyStaDate;
            }
            else if (nextControl.Name == ApplyEndDate_TDateEdit.Name)
            {
                message = MESSAGE_ApplyEndDate;
            }
            //---ADD　鄧潘ハン　2012/11/27 ------------>>>>>
            else if (nextControl.Name == uos_DataSendDiv.Name)
            {
                message = MESSAGE_SendDiv;
            }
            //---ADD　鄧潘ハン　2012/11/27 ------------<<<<<
            else if (nextControl.Name == tNedit_CustAnalysCode1.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode2.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode3.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode4.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode5.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode6.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tEdit_CarMngCode.Name)
            {
                message = MESSAGE_CarMngCode;
            }
            else if (nextControl.Name == tEdit_SlipNote.Name)
            {
                message = MESSAGE_SlipNote;
            }
            else if (nextControl.Name == tEdit_SlipNote2.Name)
            {
                message = MESSAGE_SlipNote2;
            }
            else if (nextControl.Name == tEdit_SlipNote3.Name)
            {
                message = MESSAGE_SlipNote3;
            }
            else if (nextControl.Name == tEdit_PartySaleSlipNum.Name)
            {
                message = MESSAGE_PartySaleSlipNum;
            }
            else if (nextControl.Name == tNedit_SupplierCd.Name)
            {
                message = MESSAGE_SupplierCd;
            }
            //else if (nextControl.Name == tNedit_TMY_ID.Name)//DEL　鄧潘ハン　2012/11/21 Redmine33560
            else if (nextControl.Name == tEdit_TMY_ID.Name)//ADD　鄧潘ハン　2012/11/21 Redmine33560
            {
                message = MESSAGE_TMY_ID;
            }
            else if (nextControl.Name == tEdit_FilePath.Name)
            {
                message = MESSAGE_FilePath;
            }
            else
            {
                message = "";
            }
            StockDetailInput_StatusBarMessageSetting(this, message);
        }
        # endregion ■  StatusBarメッセージ表示処理 ■

        # region ■ ステータスバーメッセージ表示イベント ■
        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note		: 売上データテキスト出力（ＴＭＹ）ステータスバーメッセージ表示イベント</br>
        /// <br>Programmer  : 鄧潘ハン</br>										
        /// <br>Date        : 2012/10/31</br>										
        /// <br>管理番号    : 10805731-00</br>
        /// </remarks>
        private void StockDetailInput_StatusBarMessageSetting(object sender, string message)
        {
            this.ultraStatusBar2.Panels[0].Text = message;
        }

        # endregion ■ ステータスバーメッセージ表示イベント ■

        /// <summary>
        /// 仕入先名の取得
        /// </summary>
        /// <param name="supprCode">仕入先コード</param>
        /// <returns>仕入先名</returns>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）仕入先名の取得</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private string GetSupplierName(int supprCode)
        {
            if (this._supInfoSetDic.ContainsKey(supprCode))
            {
                return SubStringOfByte(this._supInfoSetDic[supprCode].SupplierNm1, 20);
            }
            else
            {
                return ctSupprName;
            }
        }

        /// <summary>
        /// GroupCollapsing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : GroupCollapsing イベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
          if ((e.Group.Key == "ResultGroup") ||
            (e.Group.Key == "OutPutGroup") ||
            (e.Group.Key == "ResultConditionGroup") ||
            (e.Group.Key == "OutPutConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// GroupExpanding イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : GroupExpanding イベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
             if ((e.Group.Key == "ResultGroup") ||
                (e.Group.Key == "OutPutGroup") ||
                (e.Group.Key == "ResultConditionGroup") ||
                (e.Group.Key == "OutPutConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : Button_Click イベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FilePath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 管理番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 管理番号ガイドボタンクリックイベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private void uButton_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
            CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

            paramInfo.EnterpriseCode = this._enterpriseCode;

            // ガイドイベントフラグ
            paramInfo.IsGuideClick = true;
            // 「新規登録」行表示なし
            paramInfo.IsDispNewRow = false;
            // 得意先表示有り
            paramInfo.IsDispCustomerInfo = true;
            //得意先コード絞り込みなし
            paramInfo.IsCheckCustomerCode = false;
            // 管理番号絞り込み無し
            paramInfo.IsCheckCarMngCode = false;
            // 車輌管理区分チェック有り
            paramInfo.IsCheckCarMngDivCd = true;
            int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_CarMngCode.Text = selectedInfo.CarMngCode;
                this.tEdit_SlipNote.Focus();
                this.SettingGuideButtonToolEnabled(this.tEdit_SlipNote);
                this.StatusBarMessageSettingProc(this.tEdit_SlipNote);
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先ガイドボタンクリックイベント</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560　辰巳屋テキストのTMY-IDについての仕様変更</br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            Supplier retSupplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd.Text = retSupplier.SupplierCd.ToString("000000");
                this.uLabel_SupplierName.Text = SubStringOfByte(retSupplier.SupplierNm1, 20);
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
                //this.tNedit_TMY_ID.Focus();
                //this.SettingGuideButtonToolEnabled(this.tNedit_TMY_ID);
                //this.StatusBarMessageSettingProc(this.tNedit_TMY_ID);
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<
                //---ADD　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
                this.ApplyStaDate_TDateEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ApplyStaDate_TDateEdit);
                this.StatusBarMessageSettingProc(this.ApplyStaDate_TDateEdit);
                //---ADD　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<

            }
            else
            {
                //なし。
            } 
        }
        # endregion

        // ===================================================================================== //
        // オフライン状態チェック処理
        // ===================================================================================== //
        #region ◎ オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
                else
                {
                    //なし。
                }
            }
            return true;
        }

        /// <summary>				
        /// リモート接続可能判定				
        /// </summary>				
        /// <returns>判定結果</returns>				
        /// <remarks>
        /// <br>Note       : リモート接続可能判定</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態				
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        # region 自動送信の追加
        //---ADD　鄧潘ハン　2012/11/27 ---------------->>>>>
        /// <summary>
        /// 自動送信XML生成
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自動送信XML生成</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/11/27</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             自動送信の追加仕様変更</br>
        /// <br>UpDate Note: 2013/04/09 王君</br>
        /// <br>           : Redmine#35305 辰巳屋テキスト作成</br>
        /// </remarks>
        private int SaveNetSendSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            try
            {
                int rowsCount = this._salesSliptextAcs.SalesSliptextCsv.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // データ区分初期化
                XmlElement dtkbn = null;
                // TMY-ID分初期化
                XmlElement pmwscd = null;
                // 得意先ｺｰﾄﾞ初期化
                XmlElement kjcd = null;
                // 売上日付初期化
                XmlElement dndt = null;
                // 売上伝票番号初期化
                XmlElement dnno = null;
                // 売上行番号初期化
                XmlElement dngyno = null;
                // 商品番号初期化
                XmlElement pmncd = null;
                // 商品メーカーコード初期化
                XmlElement mkcd = null;
                // BL商品コード初期化
                XmlElement blcd = null;
                // 出荷数初期化
                XmlElement sksu = null;
                // 仕入先コード初期化
                XmlElement psicd = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // データ区分
                    dtkbn = xmldoc.CreateElement("DTKBN");
                    dtkbn.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["DATADIV"].ToString();
                    data.AppendChild(dtkbn);

                    // TMY-ID
                    pmwscd = xmldoc.CreateElement("PMWSCD");
                    pmwscd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["TMYID"].ToString();
                    data.AppendChild(pmwscd);

                    // 得意先ｺｰﾄﾞ
                    kjcd = xmldoc.CreateElement("KJCD");
                    //kjcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["CUSTOMERCODE"]).ToString(); // DEL 王君　2013/04/09 Redmine#35305
                    kjcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["CUSTOMERCODE"]).ToString().PadLeft(8, '0');// ADD 王君　2013/04/09 Redmine#35305
                    data.AppendChild(kjcd);

                    // 売上日付
                    dndt = xmldoc.CreateElement("DNDT");
                    dndt.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SALESDATE"].ToString();
                    data.AppendChild(dndt);

                    // 売上伝票番号
                    dnno = xmldoc.CreateElement("DNNO");
                    dnno.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SALESSLIPNUM"].ToString();
                    data.AppendChild(dnno);

                    // 売上行番号
                    dngyno = xmldoc.CreateElement("DNGYNO");
                    dngyno.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SALESROWNO"].ToString();
                    data.AppendChild(dngyno);

                    // 商品番号
                    pmncd = xmldoc.CreateElement("PHNCD");
                    pmncd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["GOODSNO"].ToString();
                    data.AppendChild(pmncd);

                    // 商品メーカーコード
                    mkcd = xmldoc.CreateElement("MKCD");
                    //mkcd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["GOODSMAKERCD"].ToString(); // DEL 王君　2013/04/09 Redmine#35305
                    mkcd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["GOODSMAKERCD"].ToString().PadLeft(4, '0');// ADD 王君　2013/04/09 Redmine#35305
                    data.AppendChild(mkcd);

                    // BL商品コード
                    blcd = xmldoc.CreateElement("BLCD");
                    if (this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["BLGOODSCODE"] == DBNull.Value)
                    {
                        blcd.InnerText = string.Empty;
                    }
                    else
                    {
                        //blcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["BLGOODSCODE"]).ToString(); // DEL 王君　2013/04/09 Redmine#35305
                        blcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["BLGOODSCODE"]).ToString().PadLeft(5, '0');// ADD 王君　2013/04/09 Redmine#35305
                    }
                    data.AppendChild(blcd);

                    // 出荷数
                    sksu = xmldoc.CreateElement("SKSU");
                    sksu.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SHIPMENTCNT"].ToString();
                    data.AppendChild(sksu);

                    // 仕入先コード
                    psicd = xmldoc.CreateElement("PSICD");
                    psicd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SUPPLIERCD"].ToString();
                    data.AppendChild(psicd);

                    root.AppendChild(data);
                }

                //XML書き込み
                xmldoc.Save(this._xmlfileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageIn = "XMLファイルの書き込みに失敗しました。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageIn, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

            return status;
        }

        /// <summary>
        /// XMLの削除
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLの削除 </br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/11/27</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        private int DeleteFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            ArrayList fileList = new ArrayList();

            try
            {
                // ファイルを削除
                FileInfo info = new FileInfo(this._xmlfileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageDe = "XMLファイルの削除に失敗しました。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageDe, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            return status;
        }
        //---ADD　鄧潘ハン　2012/11/27 ----------------<<<<<
        # endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;  // 2010/06/15 Add

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using System.IO;//ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上入力用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br>Update Note: </br>
    /// <br>2009.07.15 22018 鈴木 正臣 MANTIS[0013801] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br>Update Note : 2009/12/23 張凱</br>
    /// <br>              PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>              出荷数入力最大桁数、受注数入力最大桁数を追加</br>
    /// <br>              フッタ部のフォーカス制御を追加</br>
    /// <br>Update Note  : 2010/01/27 高峰</br>
    /// <br>               PM1003-A・ＰＭ．ＮＳ　４次改良</br>
    /// <br>               ＰＭ．ＮＳ　４次改良の対応</br>
    /// <br>Update Note: 2010/02/02 張凱</br>
    /// <br>           : Redmine#2757の対応</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note: 2010/06/15 山路 芳郎</br>
    /// <br>             RC連携対応</br>
    /// <br>             ①SCM情報自動展開の削除</br>
    ///                  ②検索制御タブの削除（結合検索制御のみ入力制御へ移動</br>
    /// <br>             ③オプション制御タブの追加</br>
    /// <br>             ④RC連携用フォルダを追加</br>
    /// <br>Update Note : 2010/07/22 對馬 大輔 </br>
    /// <br>              SCM情報自動展開を常に０とする(不要な為)</br>
    /// <br>Update Note: 2010/08/06 20056 對馬 大輔 </br>
    /// <br>             担当者、受注者、発行者の表示制御を変更</br>
    /// <br>Update Note: 2011/08/08 連番1002 許雁波 </br>
    /// <br>             「入力後のカーソル位置」のドロプダアウを追加</br>
    /// <br>Update Note: 2011/08/09 連番4,979 梁森東</br>
    /// <br>               ユーザー設定の入力制御にアクティブ色項目を追加</br>
    /// <br>Update Note: 2012/04/11 No.594 脇田 靖之 </br>
    /// <br>             「商品検索後のフォーカス位置」項目追加</br>
    /// <br>Update Note: 2012/05/21 福田 康夫 </br>
    /// <br>             No.594障害対応不備のためもとに戻す</br>
    /// <br>Update Note: 2013/02/14 宮本 利明</br>
    /// <br>             仕入先(仕入情報)のフォーカス制御を追加</br>
    /// <br>Update Note: 2013/04/23 脇田 靖之</br>
    /// <br>             入力後のカーソル位置項目の順番、値を入れ替え</br>
    /// <br>             ＰＭＮＳタイプ：DataValue　1⇒0</br>
    /// <br>             ＰＭ７タイプ　：DataValue　0⇒1</br>
    /// <br>Update Note: 2013/11/05 脇田 靖之</br>
    /// <br>             仕掛一覧№1492(№594)対応</br>
    /// <br>             「商品検索後のフォーカス位置」項目追加し、受注伝票を入力しやすくする</br>
    /// <br>Update Note: 2014/02/24 脇田 靖之</br>
    /// <br>             仕掛一覧 №2307</br>
    /// <br>             ユーザー設定に「伝票種別の記憶」項目追加</br>     
    /// <br>Update Note : 2017/01/22 王飛</br>
    /// <br>管理番号    : 11270046-00</br>
    /// <br>            : Redmine#48967 車輌検索改良の対応</br>
    /// <br>Update Note: 2018/09/04 譚洪</br>
    /// <br>管理番号   : 11470152-00</br>
    /// <br>           : 『設定』画面で画面制御タブの変更</br>
    /// <br>Update Note: 2021/03/16 陳艶丹</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
    /// <br>Update Note: 2021/04/12 陳艶丹</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
    /// <br>Update Note: 2021/06/21 譚洪</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先ガイド表示の対応</br>
    /// <br>Update Note: 2021/09/10 呉元嘯</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応</br> 
    /// <br>Update Note: 2022/04/26 陳艶丹</br>
    /// <br>管理番号   : 11870080-00</br>
    /// <br>           : PMKOBETSU-4208 電子帳簿対応</br> 
    /// <br>Update Note: 2022/10/05 田村顕成</br>
    /// <br>管理番号   : 11870141-00</br>
    /// <br>           : インボイス残対応</br> 
    /// </remarks>
    public partial class SalesSlipInputSetup : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private SalesSlipInputConstructionAcs _salesSlipInputConstructionAcs;
        private ControlScreenSkin _controlScreenSkin;
        private HeaderFocusConstructionList _headerFocusConstructionList;
        private FunctionConstructionList _functionConstructionList;// ADD 2010/07/06
        private FunctionDetailConstructionList _functionDetailConstructionList;// ADD 2010/08/13
        private Dictionary<string, Control> _headerItemsDictionary;
        private Dictionary<string, Control> _functionItemsDictionary;// ADD 2010/07/06
        private Dictionary<string, Control> _functionDetailItemsDictionary;// ADD 2010/08/13
        private FooterFocusConstructionList _footerFocusConstructionList;// ADD 2009/12/23
        private Dictionary<string, Control> _footerItemsDictionary;// ADD 2009/12/23
        private SalesSlipInputSetupDataSet.HeaderFocusDataTable _headerFocusDataTable;
        private SalesSlipInputSetupDataSet.FunctionDataTable _functionDataTable;// ADD 2010/07/06
        private SalesSlipInputSetupDataSet.FunctionDetailDataTable _functionDetailDataTable;// ADD 2010/08/13
        private SalesSlipInputSetupDataSet.DetailFocusDataTable _detailFocusDataTable;
        private SalesSlipInputSetupDataSet.FooterFocusDataTable _footerFocusDataTable; // ADD 2009/12/23
        private DataView _headerFocusView = null;
        private DataView _functionView = null;// ADD 2010/07/06
        private DataView _functionDetailView = null;// ADD 2010/08/13
        private DataView _detailFocusView = null;
        private DataView _footerFocusView = null;// ADD 2009/12/23
        private List<string> _optionList = new List<string>();   // 2010/06/15 Add
        private PMKEN08020UF ModelSelectionSetting;// ADD 2017/01/22 王飛 Redmine#48967
        // --- ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 ----->>>>>
        private const string CusGuidDisChangeMsg = "得意先ガイド表示機能はワイドモニタのご使用を推奨いたします。";
        private const int CusGuidDisChangeMsgValue = 0;
        // --- ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 -----<<<<<
        //--- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
        private const string PRINTCHECKMSG = "プリンタ設定で、PDFプリンタを正しく登録してください。";
        private const string PRINTER_NORMAL = "Microsoft Print to PDF";
        private const string PRINTER_CUBE = "CubePDF";
        private const int MODE_NONE = 0; //「PDF出力しない」モード
        private const string XML_PDFPRINTERSETTINGENABLE = "MAHNB01001U_PDFPrinterSettingEnable.xml";
        //--- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<

        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        /// <summary>返品･赤伝制御設定XMLファイル</summary>
        private const string XML_RETURNREDSETTINGS = "MAHNB01001U_ReturnRedSetting.xml";
        /// <summary>返品･赤伝制御 備考欄使用モード</summary>
        private const int ReturnRedNote_BLANK = 0;//空白
        private const int ReturnRedNote_SLIPNUM = 1;//取引日付＋元黒伝票番号
        private const int ReturnRedNote_ORIGINAL = 2;//元黒伝票番号
        private const int ReturnRedNote_OPTIONAL = 3;//任意
         private string _returnRedNote1 = string.Empty;
        private string _returnRedNote2 = string.Empty;
        private string _returnRedNote3 = string.Empty;
        /// <summary>返品･赤伝制御 備考欄空白チェックモード</summary>
        private const int ReturnRedBlankCheck_OFF = 0;//チェック無し
        private const int ReturnRedBlankCheck_ON = 1;//チェックあり
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 連番1002 許雁波</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : 連番4,979 梁森東</br>
        /// <br>Date       : 2011/08/09</br>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00</br>
        /// <br>           : Redmine#48967 車輌検索改良の対応</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 『設定』画面で画面制御タブの変更</br>
        /// <br>Update Note: 2021/03/16 陳艶丹</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// <br>Update Note: 2022/10/05 田村顕成功</br>
        /// <br>管理番号   : 11870141-00</br>
        /// <br>           : インボイス残対応</br>
        /// </remarks>
        public SalesSlipInputSetup()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._salesSlipInputConstructionAcs = SalesSlipInputConstructionAcs.GetInstance();
            this._controlScreenSkin = new ControlScreenSkin();
            this._headerFocusConstructionList = new HeaderFocusConstructionList();
            this._headerItemsDictionary = new Dictionary<string, Control>();
            this._functionItemsDictionary = new Dictionary<string, Control>();// ADD 2010/07/06
            this._functionDetailItemsDictionary = new Dictionary<string, Control>();// ADD 2010/08/13
            this._footerFocusConstructionList = new FooterFocusConstructionList();// ADD 2009/12/23
            this._footerItemsDictionary = new Dictionary<string, Control>();// ADD 2009/12/23
            this._headerFocusDataTable = new SalesSlipInputSetupDataSet.HeaderFocusDataTable();
            this._functionDataTable = new SalesSlipInputSetupDataSet.FunctionDataTable();// ADD 2010/07/06
            this._functionDetailDataTable = new SalesSlipInputSetupDataSet.FunctionDetailDataTable();// ADD 2010/08/13
            this._detailFocusDataTable = new SalesSlipInputSetupDataSet.DetailFocusDataTable();
            this._footerFocusDataTable = new SalesSlipInputSetupDataSet.FooterFocusDataTable();// ADD 2009/12/23
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPosition, this._salesSlipInputConstructionAcs.FocusPositionValue, 0);
            this.tNedit_DataInputCount.SetInt(this._salesSlipInputConstructionAcs.DataInputCountValue);
            this.SetComboEditorItemIndex(this.tComboEditor_FontSize, this._salesSlipInputConstructionAcs.FontSizeValue, 11);
            this.SetComboEditorItemIndex(this.tComboEditor_Colors, this._salesSlipInputConstructionAcs.ColorsValue, 0); // ADD 2011/08/09
            this.SetOptionSetItemIndex(this.uOptionSet_ClearAfterSave, this._salesSlipInputConstructionAcs.ClearAfterSaveValue);
            this.SetOptionSetItemIndex(this.uOptionSet_UltraOptionSet, this._salesSlipInputConstructionAcs.UltraOptionSetValue); //ADD 2010/01/27
            this.SetOptionSetItemIndex(this.uOptionSet_SaveInfoStore, this._salesSlipInputConstructionAcs.SaveInfoStoreValue);
            this.SetOptionSetItemIndex(this.uOptionSet_PartySaleSlipDiv, this._salesSlipInputConstructionAcs.PartySaleSlipValue);
            //>>>2010/08/06
            this.SetComboEditorItemIndex(this.tComboEditor_EmployeeCdDiv, this._salesSlipInputConstructionAcs.EmployeeCdDivValue, 0);
            this.SetComboEditorItemIndex(this.tComboEditor_FrontEmployeeCdDiv, this._salesSlipInputConstructionAcs.FrontEmployeeCdDivValue, 0);
            this.SetComboEditorItemIndex(this.tComboEditor_SalesInputCdDiv, this._salesSlipInputConstructionAcs.SalesInputCdDivValue, 0);
            this.tEdit_EmployeeCode.Text = this._salesSlipInputConstructionAcs.EmployeeCdValue;
            //<<<2010/08/06
            this.tEdit_FrontEmployeeCd.Text = this._salesSlipInputConstructionAcs.FrontEmployeeCdValue;
            this.tEdit_SalesInputCd.Text = this._salesSlipInputConstructionAcs.SalesInputCdValue;
//2010/06/18 yamaji DEL
//DEL            this.SetComboEditorItemIndex(this.tComboEditor_SearchUICntDivCd, this._salesSlipInputConstructionAcs.SearchUICntDivCdValue, 0);
//DEL            this.SetComboEditorItemIndex(this.tComboEditor_EnterProcDivCd, this._salesSlipInputConstructionAcs.EnterProcDivCdValue, 0);
//DEL            this.SetComboEditorItemIndex(this.tComboEditor_PartsNoSearchDivCd, this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue, 0);
//2010/06/18 yamaji DEL
            this.tEdit_PartsJoinCntDivCd.Text = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterCarSearch, this._salesSlipInputConstructionAcs.FocusPositionAfterCarSearchValue, 2);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            this.SetComboEditorItemIndex( this.tComboEditor_BLGuideMode, this._salesSlipInputConstructionAcs.BLGuideModeValue, 0 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
            //this.SetOptionSetItemIndex(this.uOptionSet_scm, this._salesSlipInputConstructionAcs.ScmValue);// 2010/02/26 // 2010/07/22
            this.SetComboEditorItemIndex(this.tComboEditor_CursorPos, this._salesSlipInputConstructionAcs.CursorPosValue, 0);  //ADD 連番1002 2011/08/08
            // --- DEL 2012/05/21 ---------->>>>>
            //this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterBLCodeSearch, this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue, 0);   //ADD 2012/04/11 No.594
            // --- DEL 2012/05/21 ----------<<<<<
            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_FocusPositionAfterBLCodeSearch, this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue, 0);
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
            // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_AcptAnOdrStatusMemory, this._salesSlipInputConstructionAcs.AcptAnOdrStatusMemoryValue, 0);
            // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_CustomerGuidDisplay, this._salesSlipInputConstructionAcs.CustomerGuidDisplayValue, 0);
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            // --- ADD 2009/12/23 ---------->>>>>
            this.tNedit_ShipmentMaxCnt.SetInt(this._salesSlipInputConstructionAcs.ShipmentMaxCntValue);
            this.tNedit_AcceptAnOrderMaxCnt.SetInt(this._salesSlipInputConstructionAcs.AcceptAnOrderMaxCntValue);
            // --- ADD 2009/12/23 ----------<<<<<

            // 2010/06/15 Add >>>
            this.tEdit_RCLinkDirectory.Text = this._salesSlipInputConstructionAcs.RCLinkDirectoryValue;
            // 2010/06/15 Add <<<

            // 2010/06/15 Add >>>
            this._optionList = new List<string>();

            // RC連携フォルダは、RC連動オプションが有効な場合のみ有効
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Trial_Contract || ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optionList.Add(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
                this.pnlOption_RCLink.Visible = true;
            }
            else
            {
                this.pnlOption_RCLink.Visible = false;
            }
            //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更------->>>>>
            this.tNedit_Month.SetInt(this._salesSlipInputConstructionAcs.InputMonthValue);
            //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更-------<<<<<

            // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
            this.SetOptionSetItemIndex(this.uOptionSet_SaveUnitCostCheckDiv, this._salesSlipInputConstructionAcs.SaveUnitCostCheckDivValue);
            // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<
            //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応------->>>>>
            this.SetComboEditorItemIndex(this.tComboEditor_OutputMode, this._salesSlipInputConstructionAcs.OutputMode, 0);
            if (this._salesSlipInputConstructionAcs.SalesOutputDiv == 1)
            {
                this.ultraCheckEditor_SalesOutputDiv.Checked = true;
            }
            else
            {
                this.ultraCheckEditor_SalesOutputDiv.Checked = false;
            }
            if (this._salesSlipInputConstructionAcs.EstimateOutputDiv == 1)
            {
                this.ultraCheckEditor_EstimateOutputDiv.Checked = true;
            }
            else
            {
                this.ultraCheckEditor_EstimateOutputDiv.Checked = false;
            }
            SetPdfPrinter();
            this.tNedit_PdfPrinterWait.Value = this._salesSlipInputConstructionAcs.PdfPrinterWait;

            // 電子帳簿連携オプション判定が有効な場合「電子帳簿連携」タブを表示する
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this.uTabControl_Setup.Tabs["EBooksControl"].Visible = true;
            }
            else
            {
                this.uTabControl_Setup.Tabs["EBooksControl"].Visible = false;
            }
            
            //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応-------<<<<<

            //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
            this._salesSlipInputConstructionAcs.GetReturnRedSettings();
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedNote1, this._salesSlipInputConstructionAcs.ReturnRedNote1Mode);
            this.tEdit_ReturnRedNote1.Text = this._salesSlipInputConstructionAcs.ReturnRedNote1;
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedNote2, this._salesSlipInputConstructionAcs.ReturnRedNote2Mode);
            this.tEdit_ReturnRedNote2.Text = this._salesSlipInputConstructionAcs.ReturnRedNote2;
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedNote3, this._salesSlipInputConstructionAcs.ReturnRedNote3Mode);
            this.tEdit_ReturnRedNote3.Text = this._salesSlipInputConstructionAcs.ReturnRedNote3;
            this.SetOptionSetItemIndex(this.ultraOptionSet_ReturnRedBlankCheck, this._salesSlipInputConstructionAcs.ReturnRedBlankCheckMode);
            //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<

            // オプション用パネルに表示する項目が存在する場合はタブを表示する
            this.uTabControl_Setup.Tabs["OptionControl"].Visible = ( this._optionList.Count > 0 );
            // 2010/06/15 Add <<<

            if (this.uTabControl_Setup.Tabs.Count > 1)
            {
                this.uTabControl_Setup.TabStop = true;
            }
            else
            {
                this.uTabControl_Setup.TabStop = false;
            }
//2010/06/15 yamaji DEL
//DEL            this.SettingPartsJoinCntDivCdEnable((int)tComboEditor_PartsNoSearchDivCd.Value);
//2010/06/15 yamaji DEL

            // --- ADD 2010/06/02 ---------->>>>>
            this.ultraButton2.Enabled = false;
            this.ultraButton1.Enabled = false;
            // --- ADD 2010/06/02 ----------<<<<<
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            this.ModelSelectionSetting = new PMKEN08020UF();
            this.ModelSelectionSetting.Deserialize();
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<
        }
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Method
        #region 全般処理
        /// <summary>
        /// コンボエディタアイテムインデックス設定処理
        /// </summary>
        /// <param name="sender">対象となるコンボエディタ</param>
        /// <param name="dataValue">設定値</param>
        /// <param name="defaultIndex">初期値</param>
        private void SetComboEditorItemIndex(TComboEditor sender, int dataValue, int defaultIndex)
        {
            int index = defaultIndex;

            for (int i = 0; i < sender.Items.Count; i++)
            {
                if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
                {
                    index = i;
                    break;
                }
            }

            sender.SelectedIndex = index;

            if ((index == -1) && (sender.DropDownStyle == Infragistics.Win.DropDownStyle.DropDown))
            {
                sender.Text = dataValue.ToString();
            }
        }

        /// <summary>
        /// オプションセットアイテムインデックス設定処理
        /// </summary>
        /// <param name="sender">対象となるオプションセット</param>
        /// <param name="dataValue">設定値</param>
        private void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
        {
            int index = -1;
            for (int i = 0; i < sender.Items.Count; i++)
            {
                if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
                {
                    index = i;
                    break;
                }
            }

            sender.CheckedIndex = index;
        }

        /// <summary>
        /// オプションセット選択値取得処理
        /// </summary>
        /// <param name="sender">対象となるオプションセット</param>
        /// <returns>選択値</returns>
        private int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
        {
            if (sender.CheckedIndex >= 0)
            {
                return (int)sender.CheckedItem.DataValue;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// コンボエディタ選択値取得処理
        /// </summary>
        /// <param name="sender">対象となるコンボエディタ</param>
        /// <returns>選択値</returns>
        private int GetComboEditorValue(TComboEditor sender)
        {
            if (sender.SelectedIndex >= 0)
            {
                return (int)sender.SelectedItem.DataValue;
            }
            else
            {
                int index = -1;

                // 数値のみが入力されている場合は、入力値とvalueを比較する。
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                if (regex.IsMatch(sender.Text.Trim()))
                {
                    int dataValue = 0;

                    try
                    {
                        dataValue = Convert.ToInt32(sender.Text.Trim());
                    }
                    catch (OverflowException)
                    {
                        // 
                    }

                    for (int i = 0; i < sender.Items.Count; i++)
                    {
                        if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
                        {
                            index = i;
                            break;
                        }
                    }
                }

                // 上記の比較で該当データが存在しなかった場合は、入力値とDisplayTextを比較する。
                if (index == -1)
                {
                    string selectText = sender.Text.Trim();

                    for (int i = 0; i < sender.Items.Count; i++)
                    {
                        if (sender.Items[i].DisplayText.Trim() == selectText)
                        {
                            index = i;
                            break;
                        }
                    }
                }

                // 該当データが存在しない場合は0とする。
                if (index == -1)
                {
                    return 0;
                }
                else
                {
                    return (int)sender.Items[index].DataValue;
                }
            }
        }

        /// <summary>
        /// 入力データチェック処理
        /// </summary>
        /// <returns>true:チェックOK false:チェックNG</returns>
        private bool InputDataCheck()
        {
            bool check = true;

            //---------------------------------------
            // 入力桁数
            //---------------------------------------
            if ((this.tNedit_DataInputCount.GetInt() <= 0) || (this.tNedit_DataInputCount.GetInt() > 999))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "入力行数は1から999の値を入力して下さい。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                this.tNedit_DataInputCount.Focus();
                check = false;
                return check;
            }
            // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            if (this.tNedit_PdfPrinterNumber.GetInt() <= 0)
            {
                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = 
                    LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    //「PDF出力しない」以外の場合
                    if (this.GetComboEditorValue(this.tComboEditor_OutputMode) != MODE_NONE)
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        TMsgDisp.Show(
                                form,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                PRINTCHECKMSG,
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                        form.TopMost = false;
                        check = false;
                        return check;
                    }
                    else
                    { 
                        //「オプションあり　かつ　PDF出力しない」場合、仮想プリンタのチェックはしない
                    }
                }
                else
                {
                    // 電子帳簿連携オプション判定が無効な場合、仮想プリンタのチェックはしない
                }
            }
            // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

            return check;

        }
        #endregion

        #region 明細項目制御関係
        /// <summary>
        /// フォーカス設定表示用テーブル作成処理
        /// </summary>
        /// <param name="enterMoveTable"></param>
        /// <param name="nameTable"></param>
        /// <param name="retTable"></param>
        private void GetDisplayTable(Dictionary<string, EnterMoveValue> enterMoveTable, Hashtable nameTable, ArrayList effectiveList, out ArrayList retList)
        {
            ArrayList retKeyList = new ArrayList();
            Dictionary<string, DisplayTableInfo>displayTableInfoDic = new Dictionary<string, DisplayTableInfo>();
            DisplayTableInfo settingDisplayTableInfo = new DisplayTableInfo();

            string keyName = "";
            string endPosittion = enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion].Key;     // 終了位置
            settingDisplayTableInfo.KeyName = enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            settingDisplayTableInfo.Caption = nameTable[settingDisplayTableInfo.KeyName].ToString();

            for (int i = 0; i < enterMoveTable.Count; i++)
            {

                if (i == 0)
                {
                    settingDisplayTableInfo.Enabled = enterMoveTable[settingDisplayTableInfo.KeyName].Enabled;
                    settingDisplayTableInfo.EnabledControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnabledControl;
                    settingDisplayTableInfo.EnterStopControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnterStopControl;
                }

                // 項目設定
                if (settingDisplayTableInfo.KeyName != "")
                {
                    DisplayTableInfo displayTableInfo = new DisplayTableInfo();
                    displayTableInfo = settingDisplayTableInfo;
                    displayTableInfo.EnterStop = true;
                    // 存在時はセットしない
                    if (!retKeyList.Contains(settingDisplayTableInfo.KeyName))
                    {
                        retKeyList.Add(settingDisplayTableInfo.KeyName);
                        displayTableInfoDic.Add(settingDisplayTableInfo.KeyName, displayTableInfo);
                    }
                }

                // 終了判定
                if (settingDisplayTableInfo.KeyName == endPosittion) break;

                // 設定情報取得
                if (enterMoveTable.ContainsKey(settingDisplayTableInfo.KeyName))
                {
                    keyName = settingDisplayTableInfo.KeyName;
                    settingDisplayTableInfo = new DisplayTableInfo();
                    settingDisplayTableInfo.KeyName = enterMoveTable[keyName].Key;
                    settingDisplayTableInfo.Caption = nameTable[settingDisplayTableInfo.KeyName].ToString(); ;
                    settingDisplayTableInfo.Enabled = enterMoveTable[settingDisplayTableInfo.KeyName].Enabled;
                    settingDisplayTableInfo.EnabledControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnabledControl;
                    settingDisplayTableInfo.EnterStopControl = enterMoveTable[settingDisplayTableInfo.KeyName].EnterStopControl;
                }
                else
                {
                    keyName = settingDisplayTableInfo.KeyName;
                    settingDisplayTableInfo = new DisplayTableInfo();
                    settingDisplayTableInfo.KeyName = "";
                    settingDisplayTableInfo.Caption = nameTable[keyName].ToString();
                    settingDisplayTableInfo.Enabled = false;
                    settingDisplayTableInfo.EnabledControl = false;
                    settingDisplayTableInfo.EnterStopControl = false;
                }
            }

            //-----------------------------------------------
            // 有効項目存在チェック
            //-----------------------------------------------
            // 算出した表示用テーブルに有効項目が全て存在するかどうかチェック
            // 存在しない場合は、フォーカス無効で設定
            //-----------------------------------------------
            string caption = "";
            foreach (string effectiveName in effectiveList)
            {
                caption = nameTable[effectiveName].ToString();
                if (!retKeyList.Contains(effectiveName))
                {
                    retKeyList.Add(effectiveName);
                    DisplayTableInfo displayTableInfo = new DisplayTableInfo();
                    displayTableInfo.KeyName = effectiveName;
                    displayTableInfo.Caption = caption;
                    displayTableInfo.EnterStop = false;
                    displayTableInfo.Enabled = enterMoveTable[effectiveName].Enabled;
                    displayTableInfo.EnabledControl = enterMoveTable[effectiveName].EnabledControl;
                    displayTableInfo.EnterStopControl = enterMoveTable[effectiveName].EnterStopControl;
                    displayTableInfoDic.Add(effectiveName, displayTableInfo);
                }
            }

            retList = new ArrayList();
            foreach (string key in retKeyList)
            {
                // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                //retList.Add(displayTableInfoDic[key]);
                if (key != "SupplierCdForStock")
                {
                    retList.Add(displayTableInfoDic[key]);
                }
                // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
            }
            // ADD 2013/02/14 T.Miyamoto ------------------------------>>>>>
            // 仕入先(仕入情報)を最終行に追加
            retList.Add(displayTableInfoDic["SupplierCdForStock"]);
            // ADD 2013/02/14 T.Miyamoto ------------------------------<<<<<
        }

        /// <summary>
        /// 明細データテーブル設定処理
        /// </summary>
        /// <param name="headerFocusConstructionList"></param>
        private void SettingDataTableFromDisplayTableInfoList(ArrayList displayTableInfoList)
        {
            int rowNo = 1;
            this._detailFocusDataTable.Clear();
            this._detailFocusDataTable.DefaultView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;

            foreach (DisplayTableInfo displayTableInfo in displayTableInfoList)
            {
                SalesSlipInputSetupDataSet.DetailFocusRow row = this._detailFocusDataTable.NewDetailFocusRow();
                row.RowNo = rowNo;
                row.Key = displayTableInfo.KeyName;
                row.Caption = displayTableInfo.Caption;
                row.Enabled = displayTableInfo.Enabled;
                row.EnterStop = displayTableInfo.EnterStop;
                row.EnabledControl = displayTableInfo.EnabledControl;
                row.EnterStopControl = displayTableInfo.EnterStopControl;
                this._detailFocusDataTable.AddDetailFocusRow(row);
                rowNo++;
            }
        }

        /// <summary>
        /// Enterキー入力時移動テーブル取得
        /// </summary>
        /// <param name="enterMoveTable"></param>
        /// <param name="enterMoveTableInit"></param>
        /// <param name="nameTable"></param>
        /// <param name="effectiveList"></param>
        /// <param name="endKeyNameList"></param>
        /// <returns></returns>
        private Dictionary<string, EnterMoveValue> GetEnterMoveTable(Dictionary<string, EnterMoveValue> enterMoveTable, Dictionary<string,EnterMoveValue> enterMoveTableInit, Hashtable nameTable, ArrayList effectiveList, ArrayList endKeyNameList)
        {
            List<DisplayTableInfo> retList = new List<DisplayTableInfo>();

            ArrayList retKeyList = new ArrayList();
            Dictionary<string, DisplayTableInfo> displayTableInfoDic = new Dictionary<string, DisplayTableInfo>();

            DataRow[] rows = this._detailFocusDataTable.Select(string.Format("{0}={1}", this._detailFocusDataTable.EnterStopColumn.ColumnName, true), string.Format("{0}", this._detailFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.DetailFocusRow row in rows)
            {
                DisplayTableInfo item = new DisplayTableInfo();
                item.KeyName = row.Key;
                item.Caption = row.Caption;
                item.Enabled = row.Enabled;
                item.EnterStop = row.EnterStop;
                item.EnabledControl = row.EnabledControl;
                item.EnterStopControl = row.EnterStopControl;
                retKeyList.Add(row.Key);
                displayTableInfoDic.Add(row.Key, item);
            }
            rows = this._detailFocusDataTable.Select(string.Format("{0}={1}", this._detailFocusDataTable.EnterStopColumn.ColumnName, false), string.Format("{0}", this._detailFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.DetailFocusRow row in rows)
            {
                DisplayTableInfo item = new DisplayTableInfo();
                item.KeyName = row.Key;
                item.Caption = row.Caption;
                item.Enabled = row.Enabled;
                item.EnterStop = row.EnterStop;
                item.EnabledControl = row.EnabledControl;
                item.EnterStopControl = row.EnterStopControl;
                retKeyList.Add(row.Key);
                displayTableInfoDic.Add(row.Key, item);
            }

            //-----------------------------------------------
            // テーブル作成
            //-----------------------------------------------
            string movePosittion = enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            string endPosittion = enterMoveTable[SalesSlipInputConstructionAcs.ct_EndPosittion].Key;

            Dictionary<string, EnterMoveValue> retTable = new Dictionary<string, EnterMoveValue>();
            EnterMoveValue enterMoveValue = null;

            int i = 0;
            DisplayTableInfo svDisplayTableInfo = new DisplayTableInfo();
            DisplayTableInfo svEndDisplayTableInfo = new DisplayTableInfo();
            bool startFlg = false;
            bool endFlg = false;

            foreach (string key in retKeyList)
            {
                DisplayTableInfo displayTableInfo = displayTableInfoDic[key];

                //-----------------------------------------------
                // 先頭項目情報設定
                //-----------------------------------------------
                if (startFlg == false)
                {
                    // 先頭項目
                    enterMoveValue = new EnterMoveValue();
                    enterMoveValue.Key = displayTableInfo.KeyName;
                    enterMoveValue.Enabled = displayTableInfo.Enabled;
                    enterMoveValue.EnabledControl = displayTableInfo.EnabledControl;
                    enterMoveValue.EnterStopControl = displayTableInfo.EnterStopControl;
                    retTable[SalesSlipInputConstructionAcs.ct_StartPosittion] = enterMoveValue;
                    svDisplayTableInfo = displayTableInfo;
                    startFlg = true;
                    i++;
                    continue;
                }

                //-----------------------------------------------
                // 移動可能最終項目情報保持
                //-----------------------------------------------
                // 無効項目該当時
                if (displayTableInfo.EnterStop == false)
                {
                    if (endFlg == false)
                    {
                        svEndDisplayTableInfo = svDisplayTableInfo;
                        endFlg = true;
                    }
                }
                // リスト最終レコード(全項目有効時)
                // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                //else if (i == retList.Count - 1)
                else if (i == (retKeyList.Count - 1))
                // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
                {
                    // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                    //if (endFlg == false)
                    //{
                    //    svEndDisplayTableInfo = displayTableInfo;
                    //    endFlg = true;
                    //}
                    svEndDisplayTableInfo = displayTableInfo;
                    // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
                }

                //-----------------------------------------------
                // テーブル情報設定
                //-----------------------------------------------
                if (svDisplayTableInfo.EnterStop == true)
                {
                    // 有効
                    enterMoveValue = new EnterMoveValue();
                    // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
                    //if (endKeyNameList.Contains(svDisplayTableInfo.KeyName))
                    if (endFlg == true)
                    // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
                    {
                        enterMoveValue.Key = enterMoveTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
                    }
                    else
                    {
                        enterMoveValue.Key = displayTableInfo.KeyName;
                    }
                    enterMoveValue.Enabled = svDisplayTableInfo.Enabled;
                    enterMoveValue.EnabledControl = svDisplayTableInfo.EnabledControl;
                    enterMoveValue.EnterStopControl = svDisplayTableInfo.EnterStopControl;
                    retTable[svDisplayTableInfo.KeyName] = enterMoveValue;
                    svDisplayTableInfo = displayTableInfo;
                }
                else
                {
                    // 無効(初期状態へ)
                    if (endFlg == true)
                    {
                        enterMoveValue = new EnterMoveValue();
                        enterMoveValue.Key = enterMoveTableInit[svDisplayTableInfo.KeyName].Key;
                        enterMoveValue.Enabled = displayTableInfoDic[svDisplayTableInfo.KeyName].Enabled;
                        enterMoveValue.EnabledControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnabledControl;
                        enterMoveValue.EnterStopControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnterStopControl;
                        retTable[svDisplayTableInfo.KeyName] = enterMoveValue;
                    }
                    else
                    {
                        retTable[svDisplayTableInfo.KeyName] = enterMoveTable[svDisplayTableInfo.KeyName];
                    }
                    svDisplayTableInfo = displayTableInfo;
                }
                i++;
            }

            //-----------------------------------------------
            // リスト最終項目設定
            //-----------------------------------------------
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = retTable[SalesSlipInputConstructionAcs.ct_StartPosittion].Key;
            enterMoveValue.Enabled = displayTableInfoDic[svDisplayTableInfo.KeyName].Enabled;
            enterMoveValue.EnabledControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnabledControl;
            enterMoveValue.EnterStopControl = displayTableInfoDic[svDisplayTableInfo.KeyName].EnterStopControl;
            retTable[svDisplayTableInfo.KeyName] = enterMoveValue;

            //-----------------------------------------------
            // 移動可能最終項目情報設定
            //-----------------------------------------------
            enterMoveValue = new EnterMoveValue();
            enterMoveValue.Key = svEndDisplayTableInfo.KeyName;
            enterMoveValue.Enabled = svEndDisplayTableInfo.Enabled;
            enterMoveValue.EnabledControl = svEndDisplayTableInfo.EnabledControl;
            enterMoveValue.EnterStopControl = svEndDisplayTableInfo.EnterStopControl;
            retTable[SalesSlipInputConstructionAcs.ct_EndPosittion] = enterMoveValue;

            return retTable;
        }

        /// <summary>
        /// 行移動処理
        /// </summary>
        /// <param name="mode">0:上に移動,0以外:下に移動</param>
        /// <param name="rowIndex">対象行番号</param>
        /// <returns></returns>
        private bool UpDownDetailRow(int mode, int rowIndex)
        {
            if (this._detailFocusView[rowIndex] == null) return false;

            // 対象行の情報を取得する
            string key = (string)this._detailFocusView[rowIndex][this._detailFocusDataTable.KeyColumn.ColumnName];
            int no = (int)this._detailFocusView[rowIndex][this._detailFocusDataTable.RowNoColumn.ColumnName];

            if (no == 0) return false;

            string formatString = (mode == 0) ? "{0}<{1}" : "{0}>{1}";
            string sortString = (mode == 0) ? "{0} DESC" : "{0}";

            DataRow[] rows = this._detailFocusDataTable.Select(string.Format(formatString, this._detailFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._detailFocusDataTable.RowNoColumn.ColumnName));

            if ((rows != null) && (rows.Length > 0))
            {
                ChangeDetailRowNo(key, (int)rows[0][this._detailFocusDataTable.RowNoColumn.ColumnName]);
                ChangeDetailRowNo((string)rows[0][this._detailFocusDataTable.KeyColumn.ColumnName], no);
            }
            return true;
        }

        /// <summary>
        /// 行番号変更処理
        /// </summary>
        /// <param name="key">対象キー</param>
        /// <param name="no">変更する番号</param>
        /// <param name="visiblePosition">列表示位置</param>
        private void ChangeDetailRowNo(string key, int no)
        {
            DataRow[] rows = this._detailFocusDataTable.Select(string.Format("{0}='{1}'", this._detailFocusDataTable.KeyColumn.ColumnName, key));
            if (rows != null)
            {
                rows[0][this._detailFocusDataTable.RowNoColumn.ColumnName] = no;
            }
        }

        /// <summary>
        /// グリッドセル設定処理
        /// </summary>
        private void SettingDetailControlGrid()
        {
            // 各行ごとの設定
            for (int i = 0; i < this.uGrid_DetailControl.Rows.Count; i++)
            {
                this.SettingDetailControlGridRow(i);
            }
        }

        /// <summary>
        /// グリッド行設定処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        private void SettingDetailControlGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_DetailControl.DisplayLayout.Bands[0];
            if (editBand == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_DetailControl.Rows[rowIndex];

            row.Cells[this._detailFocusDataTable.EnabledColumn.ColumnName].Activation = ((bool)row.Cells[this._detailFocusDataTable.EnabledControlColumn.ColumnName].Value) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
            row.Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName].Activation = ((bool)row.Cells[this._detailFocusDataTable.EnterStopControlColumn.ColumnName].Value) ? Infragistics.Win.UltraWinGrid.Activation.AllowEdit : Infragistics.Win.UltraWinGrid.Activation.Disabled;
        }
        #endregion

        // --- ADD 2010/07/06 ---------->>>>>
        /// <summary>
        /// ヘッダ項目制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        private void SettingFunctionConstructionListFromDictionary(Dictionary<string, Control> functionItemsDictionary, ref List<FunctionConstruction> functionConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in functionItemsDictionary.Keys)
            {
                Control control = functionItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FunctionConstruction functionConstruction = new FunctionConstruction();
                Control control = functionItemsDictionary[key];
                functionConstruction.Key = control.Name;
                functionConstruction.Caption = key;
                functionConstruction.Checked = true;
                functionConstructionList.Add(functionConstruction);
            }
            this._functionConstructionList.functionConstruction = functionConstructionList;
        }
        // --- ADD 2010/07/06 ----------<<<<<

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>
        /// ヘッダ項目制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        private void SettingFunctionDetailConstructionListFromDictionary(Dictionary<string, Control> functionDetailItemsDictionary, ref List<FunctionDetailConstruction> functionDetailConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in functionDetailItemsDictionary.Keys)
            {
                Control control = functionDetailItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FunctionDetailConstruction functionDetailConstruction = new FunctionDetailConstruction();
                Control control = functionDetailItemsDictionary[key];
                functionDetailConstruction.Key = control.Name;
                functionDetailConstruction.Caption = key;
                functionDetailConstruction.Checked = true;
                functionDetailConstructionList.Add(functionDetailConstruction);
            }
            this._functionDetailConstructionList.functionDetailConstruction = functionDetailConstructionList;
        }
        // --- ADD 2010/08/13 ----------<<<<<

        # region ヘッダ項目制御
        /// <summary>
        /// ヘッダ項目制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        private void SettingHeaderFocusConstructionListFromDictionary(Dictionary<string, Control> headerItemsDictionary, ref List<HeaderFocusConstruction> headerFocusConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in headerItemsDictionary.Keys)
            {
                Control control = headerItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                Control control = headerItemsDictionary[key];
                headerFocusConstruction.Key = control.Name;
                headerFocusConstruction.Caption = key;
                headerFocusConstruction.EnterStop = true;
                headerFocusConstructionList.Add(headerFocusConstruction);
            }
            this._headerFocusConstructionList.headerFocusConstruction = headerFocusConstructionList;
        }

        /// <summary>
        /// ヘッダ項目設定処理(DataTable)
        /// </summary>
        /// <param name="headerFocusDataTableDataTable"></param>
        private void SettingHeaderFocusConstructionListFromDataTable(SalesSlipInputSetupDataSet.HeaderFocusDataTable headerFocusDataTable)
        {
            List<HeaderFocusConstruction> headerFocusConstructionList = new List<HeaderFocusConstruction>();
            DataRow[] rows = headerFocusDataTable.Select("", string.Format("{0}", headerFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.HeaderFocusRow row in rows)
            {
                HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                headerFocusConstruction.Key = row.Key;
                headerFocusConstruction.Caption = row.Caption;
                headerFocusConstruction.EnterStop = row.EnterStop;
                headerFocusConstructionList.Add(headerFocusConstruction);
            }
            this._headerFocusConstructionList.headerFocusConstruction = headerFocusConstructionList;
        }
        //---ADD 2010/07/06---------->>>>>
        /// <summary>
        /// ヘッダ項目設定処理(DataTable)
        /// </summary>
        /// <param name="headerFocusDataTableDataTable"></param>
        private void SettingFunctionConstructionListFromDataTable(SalesSlipInputSetupDataSet.FunctionDataTable functionDataTable)
        {
            List<FunctionConstruction> functionConstructionList = new List<FunctionConstruction>();
            DataRow[] rows = functionDataTable.Select("", string.Format("{0}", functionDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.FunctionRow row in rows)
            {
                FunctionConstruction functionConstruction = new FunctionConstruction();
                functionConstruction.Key = row.Key;
                functionConstruction.Caption = row.Caption;
                functionConstruction.Checked = row.Checked;
                functionConstructionList.Add(functionConstruction);
            }
            this._functionConstructionList.functionConstruction = functionConstructionList;
        }
        //---ADD 2010/07/06----------<<<<<

        //---ADD 2010/08/13---------->>>>>
        /// <summary>
        /// ヘッダ項目設定処理(DataTable)
        /// </summary>
        /// <param name="functionDetailDataTable"></param>
        private void SettingFunctionDetailConstructionListFromDataTable(SalesSlipInputSetupDataSet.FunctionDetailDataTable functionDetailDataTable)
        {
            List<FunctionDetailConstruction> functionDetailConstructionList = new List<FunctionDetailConstruction>();
            DataRow[] rows = functionDetailDataTable.Select("", string.Format("{0}", functionDetailDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.FunctionDetailRow row in rows)
            {
                FunctionDetailConstruction functionDetailConstruction = new FunctionDetailConstruction();
                functionDetailConstruction.Key = row.Key;
                functionDetailConstruction.Caption = row.Caption;
                functionDetailConstruction.Checked = row.Checked;
                functionDetailConstructionList.Add(functionDetailConstruction);
            }
            this._functionDetailConstructionList.functionDetailConstruction = functionDetailConstructionList;
        }
        //---ADD 2010/08/13----------<<<<<

        /// <summary>
        /// 明細データテーブル設定処理
        /// </summary>
        /// <param name="headerFocusConstructionList"></param>
        private void SettingDataTableFromHeaderFocusConstructionList(HeaderFocusConstructionList headerFocusConstructionList)
        {
            int rowNo = 1;
            this._headerFocusDataTable.Clear();
            this._headerFocusDataTable.DefaultView.Sort = this._headerFocusDataTable.RowNoColumn.ColumnName;

            foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
            {
                SalesSlipInputSetupDataSet.HeaderFocusRow row = this._headerFocusDataTable.NewHeaderFocusRow();
                row.RowNo = rowNo;
                row.Key = headerFocusConstruction.Key;
                row.Caption = headerFocusConstruction.Caption;
                row.EnterStop = headerFocusConstruction.EnterStop;
                this._headerFocusDataTable.AddHeaderFocusRow(row);
                rowNo++;
            }
        }

        // --- ADD 2010/07/06 ---------->>>>>
        /// <summary>
        /// 明細データテーブル設定処理
        /// </summary>
        /// <param name="headerFocusConstructionList"></param>
        private void SettingDataTableFromFunctionConstructionList(FunctionConstructionList functionConstructionList)
        {
            int rowNo = 1;
            this._functionDataTable.Clear();
            this._functionDataTable.DefaultView.Sort = this._functionDataTable.RowNoColumn.ColumnName;

            foreach (FunctionConstruction functionConstruction in functionConstructionList.functionConstruction)
            {
                SalesSlipInputSetupDataSet.FunctionRow row = this._functionDataTable.NewFunctionRow();
                row.RowNo = rowNo;
                row.Key = functionConstruction.Key;
                row.Caption = functionConstruction.Caption;
                row.Checked = functionConstruction.Checked;
                this._functionDataTable.AddFunctionRow(row);
                rowNo++;
            }
        }
        // --- ADD 2010/07/06 ----------<<<<<

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>
        /// 明細データテーブル設定処理
        /// </summary>
        /// <param name="functionDetailDataTable"></param>
        private void SettingDataTableFromFunctionDetailConstructionList(FunctionDetailConstructionList functionDetailConstructionList)
        {
            int rowNo = 1;
            this._functionDetailDataTable.Clear();
            this._functionDetailDataTable.DefaultView.Sort = this._functionDetailDataTable.RowNoColumn.ColumnName;

            foreach (FunctionDetailConstruction functionDetailConstruction in functionDetailConstructionList.functionDetailConstruction)
            {
                SalesSlipInputSetupDataSet.FunctionDetailRow row = this._functionDetailDataTable.NewFunctionDetailRow();
                row.RowNo = rowNo;
                row.Key = functionDetailConstruction.Key;
                row.Caption = functionDetailConstruction.Caption;
                row.Checked = functionDetailConstruction.Checked;
                this._functionDetailDataTable.AddFunctionDetailRow(row);
                rowNo++;
            }
        }
        // --- ADD 2010/08/13 ----------<<<<<

        /// <summary>
        /// 行移動処理
        /// </summary>
        /// <param name="mode">0:上に移動,0以外:下に移動</param>
        /// <param name="rowIndex">対象行番号</param>
        /// <returns></returns>
        private bool UpDownHeaderRow(int mode, int rowIndex)
        {
            if (this._headerFocusView[rowIndex] == null) return false;

            // 対象行の情報を取得する
            string key = (string)this._headerFocusView[rowIndex][this._headerFocusDataTable.KeyColumn.ColumnName];
            int no = (int)this._headerFocusView[rowIndex][this._headerFocusDataTable.RowNoColumn.ColumnName];

            if (no == 0) return false;

            string formatString = (mode == 0) ? "{0}<{1}" : "{0}>{1}";
            string sortString = (mode == 0) ? "{0} DESC" : "{0}";

            DataRow[] rows = this._headerFocusDataTable.Select(string.Format(formatString, this._headerFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._headerFocusDataTable.RowNoColumn.ColumnName));

            if ((rows != null) && (rows.Length > 0))
            {
                ChangeHeaderRowNo(key, (int)rows[0][this._headerFocusDataTable.RowNoColumn.ColumnName]);
                ChangeHeaderRowNo((string)rows[0][this._headerFocusDataTable.KeyColumn.ColumnName], no);
            }
            return true;
        }
        /// <summary>
        /// 行番号変更処理
        /// </summary>
        /// <param name="key">対象キー</param>
        /// <param name="no">変更する番号</param>
        /// <param name="visiblePosition">列表示位置</param>
        private void ChangeHeaderRowNo(string key, int no)
        {
            DataRow[] rows = this._headerFocusDataTable.Select(string.Format("{0}='{1}'", this._headerFocusDataTable.KeyColumn.ColumnName, key));
            if (rows != null)
            {
                rows[0][this._headerFocusDataTable.RowNoColumn.ColumnName] = no;
            }
        }
        # endregion

        // --- ADD 2009/12/23 ---------->>>>>
        # region フッタ項目制御
        /// <summary>
        /// フッタ項目制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="footerItemsDictionary"></param>
        private void SettingFooterFocusConstructionListFromDictionary(Dictionary<string, Control> footerItemsDictionary, ref List<FooterFocusConstruction> footerFocusConstructionList)
        {
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in footerItemsDictionary.Keys)
            {
                Control control = footerItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FooterFocusConstruction footerFocusConstruction = new FooterFocusConstruction();
                Control control = footerItemsDictionary[key];
                footerFocusConstruction.Key = control.Name;
                footerFocusConstruction.Caption = key;
                footerFocusConstruction.EnterStop = true;
                footerFocusConstructionList.Add(footerFocusConstruction);
            }
            this._footerFocusConstructionList.footerFocusConstruction = footerFocusConstructionList;
        }

        /// <summary>
        /// フッタ項目設定処理(DataTable)
        /// </summary>
        /// <param name="footerFocusDataTable"></param>
        private void SettingFooterFocusConstructionListFromDataTable(SalesSlipInputSetupDataSet.FooterFocusDataTable footerFocusDataTable)
        {
            List<FooterFocusConstruction> footerFocusConstructionList = new List<FooterFocusConstruction>();
            DataRow[] rows = footerFocusDataTable.Select("", string.Format("{0}", footerFocusDataTable.RowNoColumn.ColumnName));
            foreach (SalesSlipInputSetupDataSet.FooterFocusRow row in rows)
            {
                FooterFocusConstruction footerFocusConstruction = new FooterFocusConstruction();
                footerFocusConstruction.Key = row.Key;
                footerFocusConstruction.Caption = row.Caption;
                footerFocusConstruction.EnterStop = row.EnterStop;
                footerFocusConstructionList.Add(footerFocusConstruction);
            }
            this._footerFocusConstructionList.footerFocusConstruction = footerFocusConstructionList;
        }

        /// <summary>
        /// 明細データテーブル設定処理
        /// </summary>
        /// <param name="footerFocusConstructionList"></param>
        private void SettingDataTableFromFooterFocusConstructionList(FooterFocusConstructionList footerFocusConstructionList)
        {
            int rowNo = 1;
            this._footerFocusDataTable.Clear();
            this._footerFocusDataTable.DefaultView.Sort = this._footerFocusDataTable.RowNoColumn.ColumnName;

            foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
            {
                SalesSlipInputSetupDataSet.FooterFocusRow row = this._footerFocusDataTable.NewFooterFocusRow();
                row.RowNo = rowNo;
                row.Key = footerFocusConstruction.Key;
                row.Caption = footerFocusConstruction.Caption;
                row.EnterStop = footerFocusConstruction.EnterStop;
                this._footerFocusDataTable.AddFooterFocusRow(row);
                rowNo++;
            }
        }

        /// <summary>
        /// 行移動処理
        /// </summary>
        /// <param name="mode">0:上に移動,0以外:下に移動</param>
        /// <param name="rowIndex">対象行番号</param>
        /// <returns></returns>
        private bool UpDownFooterRow(int mode, int rowIndex)
        {
            if (this._footerFocusView[rowIndex] == null) return false;

            // 対象行の情報を取得する
            string key = (string)this._footerFocusView[rowIndex][this._footerFocusDataTable.KeyColumn.ColumnName];
            int no = (int)this._footerFocusView[rowIndex][this._footerFocusDataTable.RowNoColumn.ColumnName];

            if (no == 0) return false;

            string formatString = (mode == 0) ? "{0}<{1}" : "{0}>{1}";
            string sortString = (mode == 0) ? "{0} DESC" : "{0}";

            DataRow[] rows = this._footerFocusDataTable.Select(string.Format(formatString, this._footerFocusDataTable.RowNoColumn.ColumnName, no), string.Format(sortString, this._footerFocusDataTable.RowNoColumn.ColumnName));

            if ((rows != null) && (rows.Length > 0))
            {
                ChangeFooterRowNo(key, (int)rows[0][this._footerFocusDataTable.RowNoColumn.ColumnName]);
                ChangeFooterRowNo((string)rows[0][this._footerFocusDataTable.KeyColumn.ColumnName], no);
            }
            return true;
        }

        /// <summary>
        /// 行番号変更処理
        /// </summary>
        /// <param name="key">対象キー</param>
        /// <param name="no">変更する番号</param>
        /// <param name="visiblePosition">列表示位置</param>
        private void ChangeFooterRowNo(string key, int no)
        {
            DataRow[] rows = this._footerFocusDataTable.Select(string.Format("{0}='{1}'", this._footerFocusDataTable.KeyColumn.ColumnName, key));
            if (rows != null)
            {
                rows[0][this._footerFocusDataTable.RowNoColumn.ColumnName] = no;
            }
        }
        # endregion
        // --- ADD 2009/12/23 ----------<<<<<
        # endregion
        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2017/01/22 王飛</br>
        /// <br>管理番号    : 11270046-00</br>
        /// <br>            : Redmine#48967 車輌検索改良の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// </remarks>
        private void SalesInputSetup_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.uButton_Ok.ImageList = this._imageList16;
            this.uButton_Cancel.ImageList = this._imageList16;
            this.uButton_EmployeeGuide.ImageList = this._imageList16; // 2010/08/06
            this.uButton_FrontEmployeeGuide.ImageList = this._imageList16;
            this.uButton_SalesInputGuide.ImageList = this._imageList16;

            this.uButton_Ok.Appearance.Image = (int)Size16_Index.DECISION;
            this.uButton_Cancel.Appearance.Image = (int)Size16_Index.BEFORE;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1; // 2010/08/06
            this.uButton_FrontEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // 2010/06/15 Add >>>
            this.uButton_RCLinkDirGuide.ImageList = this._imageList16;
            this.uButton_RCLinkDirGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // 2010/06/15 Add <<<
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            this.ultraButton_CustomerGuidDisplaySetting.ImageList = this._imageList16;
            this.ultraButton_CustomerGuidDisplaySetting.Appearance.Image = (int)Size16_Index.STAR1;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            //------------------------------------------------------
            // ヘッダ項目制御
            //------------------------------------------------------
            this._headerFocusView = this._headerFocusDataTable.DefaultView;
            this.uGrid_HeaderControl.DataSource = this._headerFocusView;
            this._headerFocusConstructionList = this._salesSlipInputConstructionAcs.HeaderFocusConstructionListValue;
            this._headerItemsDictionary = this._salesSlipInputConstructionAcs.HeaderItemsDictionary;
            if (this._headerFocusConstructionList.headerFocusConstruction.Count == 0)
            {
                this.SettingHeaderFocusConstructionListFromDictionary(this._headerItemsDictionary, ref this._headerFocusConstructionList.headerFocusConstruction);
            }
            this.SettingDataTableFromHeaderFocusConstructionList(this._headerFocusConstructionList);

            //---ADD 2010/07/06---------->>>>>
            //------------------------------------------------------
            // ファンクション制御
            //------------------------------------------------------
            this._functionView = this._functionDataTable.DefaultView;
            this.uGrid_FunctionControl.DataSource = this._functionView;
            this._functionConstructionList = this._salesSlipInputConstructionAcs.FunctionConstructionListValue;
            this._functionItemsDictionary = this._salesSlipInputConstructionAcs.FunctionItemsDictionary;
            if (this._functionConstructionList.functionConstruction.Count == 0)
            {
                this.SettingFunctionConstructionListFromDictionary(this._functionItemsDictionary, ref this._functionConstructionList.functionConstruction);
            }
            this.SettingDataTableFromFunctionConstructionList(this._functionConstructionList);
            //---ADD 2010/07/06----------<<<<<

            //---ADD 2010/08/13---------->>>>>
            //------------------------------------------------------
            // ファンクション制御
            //------------------------------------------------------
            this._functionDetailView = this._functionDetailDataTable.DefaultView;
            this.uGrid_FunctionDetailControl.DataSource = this._functionDetailView;
            this._functionDetailConstructionList = this._salesSlipInputConstructionAcs.FunctionDetailConstructionListValue;
            this._functionDetailItemsDictionary = this._salesSlipInputConstructionAcs.FunctionDetailItemsDictionary;
            if (this._functionDetailConstructionList.functionDetailConstruction.Count == 0)
            {
                this.SettingFunctionDetailConstructionListFromDictionary(this._functionDetailItemsDictionary, ref this._functionDetailConstructionList.functionDetailConstruction);
            }
            this.SettingDataTableFromFunctionDetailConstructionList(this._functionDetailConstructionList);
            //---ADD 2010/08/13----------<<<<<

            //------------------------------------------------------
            // 明細部フォーカス設定
            //------------------------------------------------------
            // フォーカス設定表示用テーブル取得
            Dictionary<string, EnterMoveValue> enterMoveTable = this._salesSlipInputConstructionAcs.EnterMoveTable;
            Hashtable nameTable = this._salesSlipInputConstructionAcs.NameTable;
            ArrayList effectiveList = this._salesSlipInputConstructionAcs.EffectiveList;
            ArrayList retList = new ArrayList();
            GetDisplayTable(enterMoveTable, nameTable, effectiveList, out retList);
            this._detailFocusView = this._detailFocusDataTable.DefaultView;
            this.uGrid_DetailControl.DataSource = this._detailFocusView;
            this.SettingDataTableFromDisplayTableInfoList(retList);

            // --- ADD 2009/12/23 ---------->>>>>
            //------------------------------------------------------
            // フッタ項目制御
            //------------------------------------------------------
            this._footerFocusView = this._footerFocusDataTable.DefaultView;
            this.ultraGrid_FooterControl.DataSource = this._footerFocusView;
            this._footerFocusConstructionList = this._salesSlipInputConstructionAcs.FooterFocusConstructionListValue;
            this._footerItemsDictionary = this._salesSlipInputConstructionAcs.FooterItemsDictionary;
            if (this._footerFocusConstructionList.footerFocusConstruction.Count == 0)
            {
                this.SettingFooterFocusConstructionListFromDictionary(this._footerItemsDictionary, ref this._footerFocusConstructionList.footerFocusConstruction);
            }
            this.SettingDataTableFromFooterFocusConstructionList(this._footerFocusConstructionList);
            // --- ADD 2009/12/23 ----------<<<<<
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            if (this.ModelSelectionSetting != null
                && this.ModelSelectionSetting.SettingItemInfo != null)
            {
                this.tComboEditor_FocusPositionDiv.SelectedIndex = this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv;
                this.tComboEditor_EnterActionDiv.SelectedIndex = this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv;
            }
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<

            this.timer_Initial.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(uButton_Ok)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Programmer : 連番1002 許雁波</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : 連番4,979 梁森東</br>
        /// <br>Date       : 2011/08/09</br>
        /// <br>Update Note: 2017/01/22 王飛</br>
        /// <br>管理番号   : 11270046-00</br>
        /// <br>           : Redmine#48967 車輌検索改良の対応</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 『設定』画面で画面制御タブの変更</br>
        /// <br>Update Note: 2021/03/16 陳艶丹</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// <br>Update Note: 2021/09/10 呉元嘯</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応</br> 
        /// <br>Update Note: 2022/04/26 陳艶丹</br>
        /// <br>管理番号   : 11870080-00</br>
        /// <br>           : PMKOBETSU-4208 電子帳簿対応</br> 
        /// <br>Update Note: 2022/10/05 田村顕成功</br>
        /// <br>管理番号   : 11870141-00</br>
        /// <br>           : インボイス残対応</br>
        /// </remarks>
        private void uButton_Ok_Click(object sender, EventArgs e)
        {
            if (!this.InputDataCheck())
            {
                this.DialogResult = DialogResult.Retry;
                return;
            }

            this._salesSlipInputConstructionAcs.FocusPositionValue = this.GetComboEditorValue(this.tComboEditor_FocusPosition);
            this._salesSlipInputConstructionAcs.DataInputCountValue = this.tNedit_DataInputCount.GetInt();
            this._salesSlipInputConstructionAcs.InputMonthValue = this.tNedit_Month.GetInt();// ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更
            this._salesSlipInputConstructionAcs.SaveUnitCostCheckDivValue = this.GetOptionSetValue(this.uOptionSet_SaveUnitCostCheckDiv);// ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133
            this._salesSlipInputConstructionAcs.FontSizeValue = this.GetComboEditorValue(this.tComboEditor_FontSize);
            this._salesSlipInputConstructionAcs.ColorsValue = this.GetComboEditorValue(this.tComboEditor_Colors);// ADD 2011/08/09
            this._salesSlipInputConstructionAcs.ClearAfterSaveValue = this.GetOptionSetValue(this.uOptionSet_ClearAfterSave);
            this._salesSlipInputConstructionAcs.UltraOptionSetValue = this.GetOptionSetValue(this.uOptionSet_UltraOptionSet); // ADD 2010/01/27
            this._salesSlipInputConstructionAcs.SaveInfoStoreValue = this.GetOptionSetValue(this.uOptionSet_SaveInfoStore);
            this._salesSlipInputConstructionAcs.PartySaleSlipValue = this.GetOptionSetValue(this.uOptionSet_PartySaleSlipDiv);
            this._salesSlipInputConstructionAcs.PartySaleSlipValue = this.GetOptionSetValue(this.uOptionSet_PartySaleSlipDiv);
            //>>>2010/08/06
            this._salesSlipInputConstructionAcs.EmployeeCdDivValue = this.GetComboEditorValue(this.tComboEditor_EmployeeCdDiv);
            this._salesSlipInputConstructionAcs.FrontEmployeeCdDivValue = this.GetComboEditorValue(this.tComboEditor_FrontEmployeeCdDiv);
            this._salesSlipInputConstructionAcs.SalesInputCdDivValue = this.GetComboEditorValue(this.tComboEditor_SalesInputCdDiv);
            this._salesSlipInputConstructionAcs.EmployeeCdValue = this.tEdit_EmployeeCode.Text.Trim();
            //<<<2010/08/06
            this._salesSlipInputConstructionAcs.FrontEmployeeCdValue = this.tEdit_FrontEmployeeCd.Text.Trim();
            this._salesSlipInputConstructionAcs.SalesInputCdValue = this.tEdit_SalesInputCd.Text.Trim();
//2010/06/15 yamaji ADD
//DEL            this._salesSlipInputConstructionAcs.SearchUICntDivCdValue = this.GetComboEditorValue(this.tComboEditor_SearchUICntDivCd);
//DEL            this._salesSlipInputConstructionAcs.EnterProcDivCdValue = this.GetComboEditorValue(this.tComboEditor_EnterProcDivCd);
//DEL            this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue = this.GetComboEditorValue(this.tComboEditor_PartsNoSearchDivCd);
//2010/06/15 yamaji ADD

            this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue = this.tEdit_PartsJoinCntDivCd.Text.Trim();
            this._salesSlipInputConstructionAcs.FocusPositionAfterCarSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterCarSearch);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            this._salesSlipInputConstructionAcs.BLGuideModeValue = this.GetComboEditorValue( this.tComboEditor_BLGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
            this._salesSlipInputConstructionAcs.CursorPosValue = this.GetComboEditorValue(this.tComboEditor_CursorPos);  //ADD 連番1002 2011/08/08
            // --- DEL 2012/05/21 ---------->>>>>
            //this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterBLCodeSearch);   // ADD 2012/04/11 No.594
            // --- DEL 2012/05/21 ----------<<<<<
            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            this._salesSlipInputConstructionAcs.FocusPositionAfterBLCodeSearchValue = this.GetComboEditorValue(this.tComboEditor_FocusPositionAfterBLCodeSearch);
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
            // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
            this._salesSlipInputConstructionAcs.AcptAnOdrStatusMemoryValue = this.GetComboEditorValue(this.tComboEditor_AcptAnOdrStatusMemory);
            // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            this._salesSlipInputConstructionAcs.CustomerGuidDisplayValue = this.GetComboEditorValue(this.tComboEditor_CustomerGuidDisplay);
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            //>>>2010/07/22
            //this._salesSlipInputConstructionAcs.ScmValue = this.GetOptionSetValue(this.uOptionSet_scm);//2010/02/16
            this._salesSlipInputConstructionAcs.ScmValue = 0;
            //<<<2010/07/22

            // --- ADD 2009/12/23 ---------->>>>>
            this._salesSlipInputConstructionAcs.ShipmentMaxCntValue = this.tNedit_ShipmentMaxCnt.GetInt();
            this._salesSlipInputConstructionAcs.AcceptAnOrderMaxCntValue = this.tNedit_AcceptAnOrderMaxCnt.GetInt();
            // --- ADD 2009/12/23 ----------<<<<<

// 2010/06/15 Add >>>
            this._salesSlipInputConstructionAcs.RCLinkDirectoryValue = this.tEdit_RCLinkDirectory.Text.Trim();
// 2010/06/15 Add <<<

            // ヘッダ項目制御
            this.SettingHeaderFocusConstructionListFromDataTable(this._headerFocusDataTable);
            this._salesSlipInputConstructionAcs.HeaderFocusConstructionListValue = this._headerFocusConstructionList;

            //---ADD 2010/07/06---------->>>>>
            // ファンクション制御
            this.SettingFunctionConstructionListFromDataTable(this._functionDataTable);
            this._salesSlipInputConstructionAcs.FunctionConstructionListValue = this._functionConstructionList;
            //---ADD 2010/07/06----------<<<<<

            //---ADD 2010/08/13---------->>>>>
            // ファンクション制御
            this.SettingFunctionDetailConstructionListFromDataTable(this._functionDetailDataTable);
            this._salesSlipInputConstructionAcs.FunctionDetailConstructionListValue = this._functionDetailConstructionList;
            //---ADD 2010/08/13----------<<<<<

            // フォーカス設定表示用テーブル
            Dictionary<string, EnterMoveValue> enterMoveTable = this._salesSlipInputConstructionAcs.EnterMoveTable;
            Dictionary<string, EnterMoveValue> enterMoveTableInit = this._salesSlipInputConstructionAcs.EnterMoveTableInit;
            Hashtable nameTable = this._salesSlipInputConstructionAcs.NameTable;
            ArrayList effectiveList = this._salesSlipInputConstructionAcs.EffectiveList;
            //ArrayList endKeyNameList = this._salesSlipInputConstructionAcs.EndKeyNameList;
            ArrayList endKeyNameList = this._salesSlipInputConstructionAcs.EndKeyNameListInit;
            this._salesSlipInputConstructionAcs.EnterMoveTable = this.GetEnterMoveTable(enterMoveTable, enterMoveTableInit, nameTable, effectiveList, endKeyNameList);

            // --- ADD 2009/12/23 ---------->>>>>
            // フッタ項目制御
            this.SettingFooterFocusConstructionListFromDataTable(this._footerFocusDataTable);
            this._salesSlipInputConstructionAcs.FooterFocusConstructionListValue = this._footerFocusConstructionList;
            // --- ADD 2009/12/23 ----------<<<<<

            this._salesSlipInputConstructionAcs.Serialize();
            //----- ADD 2017/01/22 王飛 Redmine#48967 ----->>>>>
            if (this.ModelSelectionSetting != null
                && this.ModelSelectionSetting.SettingItemInfo != null)
            {
                this.ModelSelectionSetting.SettingItemInfo.FocusPositionDiv = this.tComboEditor_FocusPositionDiv.SelectedIndex;
                this.ModelSelectionSetting.SettingItemInfo.EnterActionDiv = this.tComboEditor_EnterActionDiv.SelectedIndex;
                this.ModelSelectionSetting.Serialize();
            }
            //----- ADD 2017/01/22 王飛 Redmine#48967 -----<<<<<
            // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
            // 原単価チェック設定ファイル更新
            this._salesSlipInputConstructionAcs.SaveUnitCostCheckSetting();
            // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
            // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            this._salesSlipInputConstructionAcs.OutputMode = this.GetComboEditorValue(this.tComboEditor_OutputMode);
            if (this.ultraCheckEditor_SalesOutputDiv.Checked)
            {
                this._salesSlipInputConstructionAcs.SalesOutputDiv = 1;
            }
            else
            {
                this._salesSlipInputConstructionAcs.SalesOutputDiv = 0;
            }
            if (this.ultraCheckEditor_EstimateOutputDiv.Checked)
            {
                this._salesSlipInputConstructionAcs.EstimateOutputDiv = 1;
            }
            else
            {
                this._salesSlipInputConstructionAcs.EstimateOutputDiv = 0;
            }
            this._salesSlipInputConstructionAcs.PdfPrinter = this.GetComboEditorValue(this.tComboEditor_PdfPrinter);
            this._salesSlipInputConstructionAcs.PdfPrinterNumber = this.tNedit_PdfPrinterNumber.GetInt();
            this._salesSlipInputConstructionAcs.PdfPrinterWait = this.tNedit_PdfPrinterWait.GetInt();

            // 電子帳簿出力設定ファイル更新
            this._salesSlipInputConstructionAcs.SaveEBooksOutputSetting();
            // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

            //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
            this._salesSlipInputConstructionAcs.ReturnRedNote1Mode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote1);
            this._salesSlipInputConstructionAcs.ReturnRedNote1 = this.tEdit_ReturnRedNote1.Text;
            this._salesSlipInputConstructionAcs.ReturnRedNote2Mode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote2);
            this._salesSlipInputConstructionAcs.ReturnRedNote2 = this.tEdit_ReturnRedNote2.Text;
            this._salesSlipInputConstructionAcs.ReturnRedNote3Mode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote3);
            this._salesSlipInputConstructionAcs.ReturnRedNote3 = this.tEdit_ReturnRedNote3.Text;
            this._salesSlipInputConstructionAcs.ReturnRedBlankCheckMode = this.GetOptionSetValue(this.ultraOptionSet_ReturnRedBlankCheck);
            this._salesSlipInputConstructionAcs.SaveReturnRedControlSetting();
            //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
        }

        /// <summary>
        /// 初期処理タイマー起動処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_Initial_Tick(object sender, EventArgs e)
        {
            this.timer_Initial.Enabled = false;

            this.SettingDetailControlGrid();
            
            this.tComboEditor_FocusPosition.Focus();

            //>>>2010/08/06
            this.EmployeeCdDiv_ValueChanged();
            this.FrontEmployeeCdDiv_ValueChanged();
            this.SalesInputCdDiv_ValueChanged();
            //<<<2010/08/06
        }

        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void SalesInputSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._salesSlipInputConstructionAcs.EnterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //>>>2010/08/06
                // 担当者コード
                if (sender == this.uButton_EmployeeGuide)
                {
                    this.tEdit_EmployeeCode.Text = employee.EmployeeCode;
                }
                //<<<2010/08/06
                // 受注者コード
                if (sender == this.uButton_FrontEmployeeGuide)
                {
                    this.tEdit_FrontEmployeeCd.Text = employee.EmployeeCode;
                }
                // 発行者コード
                if (sender == this.uButton_SalesInputGuide)
                {
                    this.tEdit_SalesInputCd.Text = employee.EmployeeCode;
                }
            }
        }

        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        /// <summary>
        /// 得意先ガイド表示ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// </remarks>
        private void ultraButton_CustomerGuidDisplaySetting_Click(object sender, EventArgs e)
        {
            //得意先ガイド表示設定画面起動
            PMKHN02840UA form = new PMKHN02840UA();
            try
            {
                form.ShowDialog();
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>Update Note: 2010/02/02 張凱 redmine#2757対応</br>
        /// <br>Note       : 2010/06/02 高峰 PM.NS障害・改良対応（７月リリース案件）No.1</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            Control nextCtrl = null;

            switch (e.PrevCtrl.Name)
            {

                //>>>2010/08/06
                #region 担当者
                //---------------------------------------------------------------
                // 担当者
                //---------------------------------------------------------------
                case "tEdit_EmployeeCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_EmployeeCode.Text.Trim();

                        canChangeFocus = this.ChangeEmployee(code);

                        #region NextCtrl制御
                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        nextCtrl = this.tComboEditor_EmployeeCdDiv;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_EmployeeCode.Text.Trim() == "")
                                        {
                                            nextCtrl = this.uButton_EmployeeGuide;
                                        }
                                        else
                                        {
                                            nextCtrl = tComboEditor_FrontEmployeeCdDiv;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
                #endregion
                //<<<2010/08/06

                #region 受注者
                //---------------------------------------------------------------
                // 受注者
                //---------------------------------------------------------------
                case "tEdit_FrontEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_FrontEmployeeCd.Text.Trim();

                        canChangeFocus = this.ChangeFrontEmployee(code);

                        #region NextCtrl制御
                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        //>>>2010/08/06
                                        //nextCtrl = this.uOptionSet_PartySaleSlipDiv;
                                        nextCtrl = this.tComboEditor_FrontEmployeeCdDiv;
                                        //<<<2010/08/06
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_FrontEmployeeCd.Text.Trim() == "")
                                        {
                                            nextCtrl = this.uButton_FrontEmployeeGuide;
                                        }
                                        else
                                        {
                                            //>>>2010/08/06
                                            //nextCtrl = tEdit_SalesInputCd;
                                            nextCtrl = tComboEditor_SalesInputCdDiv;
                                            //<<<2010/08/06
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
                #endregion

                #region 発行者
                //---------------------------------------------------------------
                // 発行者
                //---------------------------------------------------------------
                case "tEdit_SalesInputCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesInputCd.Text.Trim();

                        canChangeFocus = this.ChangeSalesInput(code);

                        #region NextCtrl制御
                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        //>>>2010/08/06
                                        //nextCtrl = this.tEdit_FrontEmployeeCd;
                                        nextCtrl = this.tComboEditor_SalesInputCdDiv;
                                        //<<<2010/08/06
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_SalesInputCd.Text.Trim() == "")
                                        {
                                            nextCtrl = this.uButton_SalesInputGuide;
                                        }
                                        else
                                        {
                                            // ---------- UPD 2010/01/27 ---------- >>>>>>>>>>
                                            // nextCtrl = this.uButton_Ok;
                                            nextCtrl = this.tComboEditor_FocusPositionAfterCarSearch;
                                            // ---------- UPD 2010/01/27 ---------- <<<<<<<<<<
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
                #endregion

                // --- ADD 2009/12/23 ---------->>>>>
                #region 出荷数入力最大桁数
                //---------------------------------------------------------------
                // 出荷数入力最大桁数
                //---------------------------------------------------------------
                case "tNedit_ShipmentMaxCnt":
                    {   // --- UPD 2010/02/02 ---------->>>>>
                        //if (this.tNedit_ShipmentMaxCnt.GetInt() > 7)
                        if (this.tNedit_ShipmentMaxCnt.GetInt() > 7 || this.tNedit_ShipmentMaxCnt.GetInt() == 0)
                        // --- UPD 2010/02/02 ----------<<<<<
                        {
                            this.tNedit_ShipmentMaxCnt.SetInt(7);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion

                #region 受注数入力最大桁数
                //---------------------------------------------------------------
                // 受注数入力最大桁数
                //---------------------------------------------------------------
                case "tNedit_AcceptAnOrderMaxCnt":
                    {
                        // --- UPD 2010/02/02 ---------->>>>>
                        //if (this.tNedit_AcceptAnOrderMaxCnt.GetInt() > 7)
                        if (this.tNedit_AcceptAnOrderMaxCnt.GetInt() > 7 || this.tNedit_AcceptAnOrderMaxCnt.GetInt() == 0)
                        // --- UPD 2010/02/02 ----------<<<<<
                        {
                            this.tNedit_AcceptAnOrderMaxCnt.SetInt(7);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion
                // --- ADD 2009/12/23 ----------<<<<<

                // --- ADD 2010/06/02 ---------->>>>>
                #region 「▼」
                case "ultraButton1":
                    {
                        setButtonEnable();
                        break;
                    }
                #endregion
                // --- ADD 2010/06/02 ----------<<<<<

            }
        }

        /// <summary>
        /// tComboEditor_PartsNoSearchDivCd_SelectionChangeCommitted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PartsNoSearchDivCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
//2010/06/15 yamajiDEL
//DEL            this.SettingPartsJoinCntDivCdEnable((int)tComboEditor_PartsNoSearchDivCd.Value);
//2010/06/15 yamajiDEL
        }
        # endregion

        # region Event Methods(ヘッダ項目制御関係(Grid))
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Header_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_HeaderControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.uGrid_HeaderControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._headerFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 項目名
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._headerFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 移動有無
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._headerFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 固定列区切り線設定
            this.uGrid_HeaderControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        //---ADD 2010/07/06---------->>>>>
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Function_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_FunctionControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.uGrid_FunctionControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._functionDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 項目名
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._functionDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 表示有無
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Width = 40;
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._functionDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 固定列区切り線設定
            this.uGrid_HeaderControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }
        //---ADD 2010/07/06----------<<<<<

        /// <summary>
        /// ▲ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_UpHeader_Click(object sender, EventArgs e)
        {
            if (this.uGrid_HeaderControl.ActiveRow != null)
            {
                uGrid_HeaderControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                    if (this.UpDownHeaderRow(0, this.uGrid_HeaderControl.ActiveRow.Index))
                        {
                            this.uGrid_HeaderControl.ActiveCell = this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Cells[this._headerFocusDataTable.EnterStopColumn.ColumnName];
                            this.uGrid_HeaderControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.uGrid_HeaderControl.ActiveCell = null;
                            this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Selected = true;
                        }
                    //}
                }
                finally
                {
                    uGrid_HeaderControl.EndUpdate();
                }
            }
        }

        /// <summary>
        /// ▼ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_DownHeader_Click(object sender, EventArgs e)
        {
            if (this.uGrid_HeaderControl.ActiveRow != null)
            {
                uGrid_HeaderControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                        if (this.UpDownHeaderRow(1, this.uGrid_HeaderControl.ActiveRow.Index))
                        {
                            this.uGrid_HeaderControl.ActiveCell = this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Cells[this._headerFocusDataTable.EnterStopColumn.ColumnName];
                            this.uGrid_HeaderControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.uGrid_HeaderControl.ActiveCell = null;
                            this.uGrid_HeaderControl.Rows[this.uGrid_HeaderControl.ActiveRow.Index].Selected = true;
                        }
                    //}
                }
                finally
                {
                    uGrid_HeaderControl.EndUpdate();
                }
            }
        }

        /// <summary>
        /// 初期設定に戻すボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_HeaderFocusUndo_Click(object sender, EventArgs e)
        {
            this._headerFocusConstructionList.headerFocusConstruction.Clear();
            this.SettingHeaderFocusConstructionListFromDictionary(this._headerItemsDictionary, ref this._headerFocusConstructionList.headerFocusConstruction);
            this.SettingDataTableFromHeaderFocusConstructionList(this._headerFocusConstructionList);
            this._headerFocusView = this._headerFocusDataTable.DefaultView;
            this.uGrid_HeaderControl.DataSource = this._headerFocusView;
        }

        //---ADD 2010/07/06---------->>>>>
        /// <summary>
        /// 初期設定に戻すボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FunctionUndo_Click(object sender, EventArgs e)
        {
            this._functionConstructionList.functionConstruction.Clear();
            this.SettingFunctionConstructionListFromDictionary(this._functionItemsDictionary, ref this._functionConstructionList.functionConstruction);
            this.SettingDataTableFromFunctionConstructionList(this._functionConstructionList);
            this._functionView = this._functionDataTable.DefaultView;
            this.uGrid_FunctionControl.DataSource = this._functionView;
        }
        //---ADD 2010/07/06----------<<<<<

        //---ADD 2010/08/13---------->>>>>
        /// <summary>
        /// 初期設定に戻すボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FunctionDetailUndo_Click(object sender, EventArgs e)
        {
            this._functionDetailConstructionList.functionDetailConstruction.Clear();
            this.SettingFunctionDetailConstructionListFromDictionary(this._functionDetailItemsDictionary, ref this._functionDetailConstructionList.functionDetailConstruction);
            this.SettingDataTableFromFunctionDetailConstructionList(this._functionDetailConstructionList);
            this._functionDetailView = this._functionDetailDataTable.DefaultView;
            this.uGrid_FunctionDetailControl.DataSource = this._functionDetailView;
        }
        //---ADD 2010/08/13----------<<<<<
        # endregion

        # region Event Methods(明細制御関係(Grid))
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Detail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_DetailControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.uGrid_DetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._detailFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 項目名
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._detailFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 表示有無
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Hidden = true;
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Width = 40;
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._detailFocusDataTable.EnabledColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 移動有無
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._detailFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 固定列区切り線設定
            this.uGrid_DetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// ▲ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : 2010/06/02 高峰 PM.NS障害・改良対応（７月リリース案件）No.1</br>
        private void uButton_UpDetail_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow != null)
            {
                uGrid_DetailControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                    if (this.UpDownDetailRow(0, this.uGrid_DetailControl.ActiveRow.Index))
                    {
                        this.uGrid_DetailControl.ActiveCell = this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName];
                        this.uGrid_DetailControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.uGrid_DetailControl.ActiveCell = null;
                        this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Selected = true;
                    }
                    //}
                }
                finally
                {
                    uGrid_DetailControl.EndUpdate();
                    // --- ADD 2010/06/02 ---------->>>>>
                    setButtonEnable();
                    // --- ADD 2010/06/02 ----------<<<<<
                }
            }
        }

        /// <summary>
        /// ▼ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : 2010/06/02 高峰 PM.NS障害・改良対応（７月リリース案件）No.1</br>
        private void uButton_DownDetail_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow != null)
            {
                uGrid_DetailControl.BeginUpdate();
                try
                {
                    //if (VisiblePositionChangeCheck(this.uGrid_DetailControl.ActiveRow.Index))
                    //{
                    if (this.UpDownDetailRow(1, this.uGrid_DetailControl.ActiveRow.Index))
                    {
                        this.uGrid_DetailControl.ActiveCell = this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Cells[this._detailFocusDataTable.EnterStopColumn.ColumnName];
                        this.uGrid_DetailControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.uGrid_DetailControl.ActiveCell = null;
                        this.uGrid_DetailControl.Rows[this.uGrid_DetailControl.ActiveRow.Index].Selected = true;
                    }
                    //}
                }
                finally
                {
                    uGrid_DetailControl.EndUpdate();
                    // --- ADD 2010/06/02 ---------->>>>>
                    setButtonEnable();
                    // --- ADD 2010/06/02 ----------<<<<<
                }
            }
        }

        /// <summary>
        /// 初期設定に戻すボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_DetailFocusUndo_Click(object sender, EventArgs e)
        {
            Dictionary<string, EnterMoveValue> enterMoveTable = this._salesSlipInputConstructionAcs.EnterMoveTableInit;
            Hashtable nameTable = this._salesSlipInputConstructionAcs.NameTable;
            ArrayList effectiveList = this._salesSlipInputConstructionAcs.EffectiveList;
            ArrayList retList = new ArrayList();
            GetDisplayTable(enterMoveTable, nameTable, effectiveList, out retList);
            this.SettingDataTableFromDisplayTableInfoList(retList);
            this._detailFocusView = this._detailFocusDataTable.DefaultView;
            this.uGrid_DetailControl.DataSource = this._detailFocusView;
            this.SettingDetailControlGrid();
        }
        # endregion


        //>>>2010/08/06
        /// <summary>
        /// 担当者変更処理
        /// </summary>
        /// <param name="code">担当者コード</param>
        /// <returns></returns>
        private bool ChangeEmployee(string code)
        {
            bool ret = true;

            if (code == "")
            {
                this.tEdit_EmployeeCode.Text = code;
            }
            else
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
                Employee employee;
                int status = employeeAcs.Read(out employee, this._salesSlipInputConstructionAcs.EnterpriseCode, code);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "従業員が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_EmployeeCode.Clear();
                    ret = false;
                }
                else
                {
                    this.tEdit_EmployeeCode.Text = code;
                }
            }
            return ret;
        }
        //<<<2010/08/06

        /// <summary>
        /// 受注者変更処理
        /// </summary>
        /// <param name="code">受注者コード</param>
        /// <returns></returns>
        private bool ChangeFrontEmployee(string code)
        {
            bool ret = true;

            if (code == "")
            {
                this.tEdit_FrontEmployeeCd.Text = code;
            }
            else
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
                Employee employee;
                int status = employeeAcs.Read(out employee, this._salesSlipInputConstructionAcs.EnterpriseCode, code);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "従業員が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_FrontEmployeeCd.Clear(); // 2010/08/06
                    ret = false;
                }
                else
                {
                    this.tEdit_FrontEmployeeCd.Text = code;
                }
            }

            return ret;
        }

        /// <summary>
        /// 発行者変更処理
        /// </summary>
        /// <param name="code">発行者コード</param>
        /// <returns></returns>
        private bool ChangeSalesInput(string code)
        {
            bool ret = true;

            if (code == "")
            {
                this.tEdit_SalesInputCd.Text = code;
            }
            else
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.IsLocalDBRead = this._salesSlipInputConstructionAcs.IsLocalDBRead;
                Employee employee;
                int status = employeeAcs.Read(out employee, this._salesSlipInputConstructionAcs.EnterpriseCode, code);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "従業員が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_SalesInputCd.Clear(); // 2010/08/06
                    ret = false;
                }
                else
                {
                    this.tEdit_SalesInputCd.Text = code;
                }
            }

            return ret;
        
        }

        /// <summary>
        /// 品番結合制御Enabled設定処理
        /// </summary>
        /// <param name="partsNoSearchDivCd"></param>
        private void SettingPartsJoinCntDivCdEnable(int partsNoSearchDivCd)
        {
            if (partsNoSearchDivCd == 0) // 品番検索区分(0:PM7(セットのみ) 1:結合・セット・代替)
            {
                tEdit_PartsJoinCntDivCd.Enabled = true;
                uLabel_PartsJoinCntDivCd.Enabled = true;
            }
            else
            {
                tEdit_PartsJoinCntDivCd.Enabled = false;
                uLabel_PartsJoinCntDivCd.Enabled = false;
            }
        }

        /// <summary>
        /// uLabel_MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uLabel_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            StringBuilder tipString = new StringBuilder();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;

// 2010/06/15 >>>
/*
            if (ctrl.Name == this.uLabel_SearchUICntDivCd.Name)
            {
                this.uLabel_SearchUICntDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "検索画面制御";
                tipString = tipString.Append("検索後、表示される各選択画面の表示方式を指定します。\r\n");
                tipString = tipString.Append("  PM7  ：各選択画面間を戻ることはできません。\r\n");
                tipString = tipString.Append("  PM.NS：各選択画面間を自由に戻ることができます。");
            }
            else if (ctrl.Name == this.uLabel_EnterProcDivCd.Name)
            {
                this.uLabel_EnterProcDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "エンターキー処理";
                tipString = tipString.Append("各選択画面でエンターキー押下時の動作を指定します。\r\n");
                tipString = tipString.Append("  PM7   ：選択後、次画面へ切り替わります。\r\n");
                tipString = tipString.Append("          ※セット選択は、選択のみ\r\n");
                tipString = tipString.Append("  選択  ：複数選択が可能です。\r\n");
                tipString = tipString.Append("  次画面：選択後、次画面へ切り替わります。\r\n");
                tipString = tipString.Append("          但し、セット選択のみ検索画面制御に従い動作が異なります。\r\n");
                tipString = tipString.Append("            ・検索画面制御[PM7]：選択後、メイン画面へ\r\n");
                tipString = tipString.Append("            ・検索画面制御[PM.NS]：選択後、前画面へ");
            }
            else if (ctrl.Name == this.uLabel__PartsNoSearchDivCd.Name)
            {
                this.uLabel__PartsNoSearchDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "品番検索区分";
                tipString = tipString.Append("品番検索時の検索対象を指定します。\r\n");
                tipString = tipString.Append("  PM7(セットのみ)   ：セットのみ対象\r\n");
                tipString = tipString.Append("  結合・セット・代替：結合・セット・代替まで対象\r\n");
                tipString = tipString.Append("※[PM7(セットのみ)]の場合、品番結合制御が有効になります。");
            }
            else if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "品番結合制御";
                tipString = tipString.Append("品番検索区分が[PM7(セットのみ)]の場合、\r\n品番結合制御で指定されている文字が\r\n品番の最後に付加されていると\r\n結合・セット・代替までの検索を行います。");

            }
            if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Help;

                ultraToolTipInfo.ToolTipTitle = "品番結合制御";
                tipString = tipString.Append("指定した文字が品番の最後に付加されていると\r\n結合・セット・代替の検索を行います。");

            }
 */ 
// 2010/06/15 <<<

            ultraToolTipInfo.ToolTipText = tipString.ToString();

            this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
            this.uToolTipManager_Information.SetUltraToolTip(ctrl, ultraToolTipInfo);
            this.uToolTipManager_Information.Enabled = true;
        }

        /// <summary>
        /// uLabel_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uLabel_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
//2010/06/15 yamaji UPD>>>>>
/*
            if (ctrl.Name == this.uLabel_SearchUICntDivCd.Name)
            {
                this.uLabel_SearchUICntDivCd.Cursor = Cursors.Default;
            }
            else if (ctrl.Name == this.uLabel_EnterProcDivCd.Name)
            {
                this.uLabel_EnterProcDivCd.Cursor = Cursors.Default;
            }
            else if (ctrl.Name == this.uLabel__PartsNoSearchDivCd.Name)
            {
                this.uLabel__PartsNoSearchDivCd.Cursor = Cursors.Default;
            }
            else if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Default;
            }
*/
            if (ctrl.Name == this.uLabel_PartsJoinCntDivCd.Name)
            {
                this.uLabel_PartsJoinCntDivCd.Cursor = Cursors.Default;
            }
// 2010/06/15 <<<

            uToolTipManager_Information.Enabled = false;
        }

        // --- ADD 2009/12/23 ---------->>>>>
        # region Event Methods(フッタ項目制御関係(Grid))
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid_FooterControl_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_FooterControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.ultraGrid_FooterControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_HeaderControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._footerFocusDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 項目名
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._footerFocusDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 移動有無
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Hidden = false;
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Width = 40;
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._footerFocusDataTable.EnterStopColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 固定列区切り線設定
            this.ultraGrid_FooterControl.DisplayLayout.Override.FixedCellSeparatorColor = this.ultraGrid_FooterControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// 初期設定に戻すボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FooterFocusUndo_Click(object sender, EventArgs e)
        {
            this._footerFocusConstructionList.footerFocusConstruction.Clear();
            this.SettingFooterFocusConstructionListFromDictionary(this._footerItemsDictionary, ref this._footerFocusConstructionList.footerFocusConstruction);
            this.SettingDataTableFromFooterFocusConstructionList(this._footerFocusConstructionList);
            this._footerFocusView = this._footerFocusDataTable.DefaultView;
            this.ultraGrid_FooterControl.DataSource = this._footerFocusView;
        }

        /// <summary>
        /// ▲ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_UpFooter_Click(object sender, EventArgs e)
        {
            if (this.ultraGrid_FooterControl.ActiveRow != null)
            {
                ultraGrid_FooterControl.BeginUpdate();
                try
                {
                    if (this.UpDownFooterRow(0, this.ultraGrid_FooterControl.ActiveRow.Index))
                    {
                        this.ultraGrid_FooterControl.ActiveCell = this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Cells[this._footerFocusDataTable.EnterStopColumn.ColumnName];
                        this.ultraGrid_FooterControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.ultraGrid_FooterControl.ActiveCell = null;
                        this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Selected = true;
                    }
                }
                finally
                {
                    ultraGrid_FooterControl.EndUpdate();
                }
            }
        }

        /// <summary>
        /// ▼ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_DownFooter_Click(object sender, EventArgs e)
        {
            if (this.ultraGrid_FooterControl.ActiveRow != null)
            {
                ultraGrid_FooterControl.BeginUpdate();
                try
                {
                    if (this.UpDownFooterRow(1, this.ultraGrid_FooterControl.ActiveRow.Index))
                    {
                        this.ultraGrid_FooterControl.ActiveCell = this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Cells[this._footerFocusDataTable.EnterStopColumn.ColumnName];
                        this.ultraGrid_FooterControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.ultraGrid_FooterControl.ActiveCell = null;
                        this.ultraGrid_FooterControl.Rows[this.ultraGrid_FooterControl.ActiveRow.Index].Selected = true;
                    }
                }
                finally
                {
                    ultraGrid_FooterControl.EndUpdate();
                }
            }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        // 2010/06/15 Add >>>
        /// <summary>
        /// RC連携フォルダガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RCLinkDirGuide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを選択して下さい。";
            //fbd.RootFolder = Environment.SpecialFolder.;
            fbd.SelectedPath = this.tEdit_RCLinkDirectory.Text.Trim();
            fbd.ShowNewFolderButton = true;
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.tEdit_RCLinkDirectory.Text = fbd.SelectedPath;
            }
        }
        // 2010/06/15 Add <<<

        // --- ADD 2010/06/02 ---------->>>>>

        /// <summary>
        /// 明細制御ActiveRow変更クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 2010/06/02 高峰 PM.NS障害・改良対応（７月リリース案件）No.1</br>
        /// </remarks>
        private void uGrid_DetailControl_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            setButtonEnable();

        }

        /// <summary>
        /// ボタンの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 2010/06/02 高峰 PM.NS障害・改良対応（７月リリース案件）No.1</br>
        /// </remarks>
        private void setButtonEnable()
        {
            // UPD 2013/02/14 T.Miyamoto ------------------------------>>>>>
            //if (this.uGrid_DetailControl.ActiveRow.Index == 0 || this.uGrid_DetailControl.ActiveRow.Index == 1 || this.uGrid_DetailControl.ActiveRow.Index == 2)
            if (this.uGrid_DetailControl.ActiveRow.Index == 0 || 
                this.uGrid_DetailControl.ActiveRow.Index == 1 || 
                this.uGrid_DetailControl.ActiveRow.Index == 2 ||
                this.uGrid_DetailControl.ActiveRow.Index == (this._salesSlipInputConstructionAcs.EffectiveList.Count - 1))
            // UPD 2013/02/14 T.Miyamoto ------------------------------<<<<<
            {
                this.ultraButton2.Enabled = false;
                this.ultraButton1.Enabled = false;
            }
            else if (this.uGrid_DetailControl.ActiveRow.Index == 3)
            {
                this.ultraButton2.Enabled = false;
                this.ultraButton1.Enabled = true;
            }
            // ADD 2013/02/14 T.Miyamoto ------------------------------>>>>>
            else if (this.uGrid_DetailControl.ActiveRow.Index == (this._salesSlipInputConstructionAcs.EffectiveList.Count - 2))
            {
                this.ultraButton2.Enabled = true;
                this.ultraButton1.Enabled = false;
            }
            // ADD 2013/02/14 T.Miyamoto ------------------------------<<<<<
            else
            {
                this.ultraButton2.Enabled = true;
                this.ultraButton1.Enabled = true;
            }
        }
        // --- ADD 2010/06/02 ----------<<<<<

        // --- ADD 2010/07/16 ---------->>>>>
        private void uGrid_DetailControl_AfterCellActivate(object sender, EventArgs e)
        {
            setButtonEnable();
        }

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 2010/08/13 譚洪 障害・改良対応(８月リリース案件)No.14</br>
        /// </remarks>
        private void uGrid_FunctionDetailControl_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_FunctionDetailControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.uGrid_FunctionDetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._functionDetailDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 項目名
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Hidden = false;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Width = 100;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._functionDetailDataTable.CaptionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 表示有無
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Width = 40;
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._functionDetailDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 固定列区切り線設定
            this.uGrid_FunctionDetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_FunctionDetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }
        // --- ADD 2010/08/13 ----------<<<<<
        // --- ADD 2010/07/16 ----------<<<<<

        //>>>2010/08/06
        /// <summary>
        /// tComboEditor_EmployeeCdDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_EmployeeCdDiv_ValueChanged(object sender, EventArgs e)
        {
            this.EmployeeCdDiv_ValueChanged();
        }

        /// <summary>
        /// 従業員区分変更時イベント
        /// </summary>
        private void EmployeeCdDiv_ValueChanged()
        {
            int employeeCdDiv = this.GetComboEditorValue(this.tComboEditor_EmployeeCdDiv);

            switch (employeeCdDiv)
            {
                case 0:
                    this.tEdit_EmployeeCode.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                    this.tEdit_EmployeeCode.Enabled = false;
                    this.uButton_EmployeeGuide.Enabled = false;
                    break;
                case 1:
                    this.tEdit_EmployeeCode.Clear();
                    this.tEdit_EmployeeCode.Enabled = false;
                    this.uButton_EmployeeGuide.Enabled = false;
                    break;
                case 2:
                    this.tEdit_EmployeeCode.Enabled = true;
                    this.uButton_EmployeeGuide.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// tComboEditor_FrontEmployeeCdDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_FrontEmployeeCdDiv_ValueChanged(object sender, EventArgs e)
        {
            this.FrontEmployeeCdDiv_ValueChanged();
        }

        /// <summary>
        /// 受注者区分変更時イベント
        /// </summary>
        private void FrontEmployeeCdDiv_ValueChanged()
        {
            int employeeCdDiv = this.GetComboEditorValue(this.tComboEditor_FrontEmployeeCdDiv);

            switch (employeeCdDiv)
            {
                case 0:
                    this.tEdit_FrontEmployeeCd.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                    this.tEdit_FrontEmployeeCd.Enabled = false;
                    this.uButton_FrontEmployeeGuide.Enabled = false;
                    break;
                case 1:
                    this.tEdit_FrontEmployeeCd.Clear();
                    this.tEdit_FrontEmployeeCd.Enabled = false;
                    this.uButton_FrontEmployeeGuide.Enabled = false;
                    break;
                case 2:
                    this.tEdit_FrontEmployeeCd.Enabled = true;
                    this.uButton_FrontEmployeeGuide.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// tComboEditor_SalesInputCdDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SalesInputCdDiv_ValueChanged(object sender, EventArgs e)
        {
            this.SalesInputCdDiv_ValueChanged();
        }

        /// <summary>
        /// 発行者区分変更時イベント
        /// </summary>
        private void SalesInputCdDiv_ValueChanged()
        {
            int employeeCdDiv = this.GetComboEditorValue(this.tComboEditor_SalesInputCdDiv);

            switch (employeeCdDiv)
            {
                case 0:
                    this.tEdit_SalesInputCd.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                    this.tEdit_SalesInputCd.Enabled = false;
                    this.uButton_SalesInputGuide.Enabled = false;
                    break;
                case 1:
                    this.tEdit_SalesInputCd.Clear();
                    this.tEdit_SalesInputCd.Enabled = false;
                    this.uButton_SalesInputGuide.Enabled = false;
                    break;
                case 2:
                    this.tEdit_SalesInputCd.Enabled = true;
                    this.uButton_SalesInputGuide.Enabled = true;
                    break;
            }
        }
        //<<<2010/08/06

        // --- ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 ----->>>>>
        /// <summary>
        /// 得意先情報ガイド表示区分変更時イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <remarks>
        /// <br>Note       : 2021/06/21 譚洪</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示の対応</br>
        /// </remarks>
        private void tComboEditor_CustomerGuidDisplay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tComboEditor_CustomerGuidDisplay.SelectedIndex == CusGuidDisChangeMsgValue)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    CusGuidDisChangeMsg,
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        // --- ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 -----<<<<<
        //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応------->>>>>
        /// <summary>
        /// pdfプリンタ変更時イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <remarks>
        /// <br>Update Note: 2022/04/26 陳艶丹</br>
        /// <br>管理番号   : 11870080-00</br>
        /// <br>           : PMKOBETSU-4208 電子帳簿対応</br> 
        /// </remarks>
        private void tComboEditor_PdfPrinter_ValueChanged(object sender, EventArgs e)
        {
            // pdfプリンター番号
            this.tNedit_PdfPrinterNumber.SetInt(_salesSlipInputConstructionAcs.GetPrinterNumber(tComboEditor_PdfPrinter.SelectedIndex));
        }
        /// <summary>
        /// 特定ファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 特定ファイル取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private void SetPdfPrinter()
        {
            try
            {
                // PDFプリンタを制御
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFPRINTERSETTINGENABLE)))
                {
                    this.tComboEditor_PdfPrinter.Enabled = true;
                    this.SetComboEditorItemIndex(this.tComboEditor_PdfPrinter, this._salesSlipInputConstructionAcs.PdfPrinter, 0);
                    this.tNedit_PdfPrinterNumber.Value = this._salesSlipInputConstructionAcs.PdfPrinterNumber;
                }
                else
                {
                    this.tComboEditor_PdfPrinter.Enabled = false;
                    //デフォルト値：「0:Windows標準」
                    this.tComboEditor_PdfPrinter.SelectedIndex = 0;
                    // pdfプリンター番号
                    this.tNedit_PdfPrinterNumber.SetInt(_salesSlipInputConstructionAcs.GetPrinterNumber(tComboEditor_PdfPrinter.SelectedIndex));
                }
            }
            catch
            {
                this.tComboEditor_PdfPrinter.Enabled = false;
                this.tComboEditor_PdfPrinter.SelectedIndex = 0;
                // pdfプリンター番号
                this.tNedit_PdfPrinterNumber.SetInt(_salesSlipInputConstructionAcs.GetPrinterNumber(tComboEditor_PdfPrinter.SelectedIndex));
            }
        }

        //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応-------<<<<<

        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        private void ultraOptionSet_ReturnRedNote1_ValueChanged(object sender, EventArgs e)
        {
            if (this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote1) != ReturnRedNote_OPTIONAL)
            {
                tEdit_ReturnRedNote1.Enabled = false;
            }
            else
            {
                tEdit_ReturnRedNote1.Enabled = true;
            }
        }

        private void ultraOptionSet_ReturnRedNote2_ValueChanged(object sender, EventArgs e)
        {
            if (this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote2) != ReturnRedNote_OPTIONAL)
            {
                tEdit_ReturnRedNote2.Enabled = false;
            }
            else
            {
                tEdit_ReturnRedNote2.Enabled = true;
            }
        }

        private void ultraOptionSet_ReturnRedNote3_ValueChanged(object sender, EventArgs e)
        {
            if (this.GetOptionSetValue(this.ultraOptionSet_ReturnRedNote3) != ReturnRedNote_OPTIONAL)
            {
                tEdit_ReturnRedNote3.Enabled = false;
            }
            else
            {
                tEdit_ReturnRedNote3.Enabled = true;
            }
        }
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<

        # endregion
    }
}
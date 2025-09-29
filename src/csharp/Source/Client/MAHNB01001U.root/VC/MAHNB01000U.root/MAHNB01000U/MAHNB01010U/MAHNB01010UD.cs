using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources; // ADD T.Miyamoto 2012/11/13

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上伝票番号入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上伝票番号の入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 20056 對馬　大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
    /// <br>2009/09/10 20056 對馬 大輔 MANTIS[0014027] 伝票照会終了時、Disposeを追加</br>
    /// <br>UpdateNote : K2011/08/12 yangyi</br>
    /// <br>管理番号   : 10703874-00</br>
    /// <br>作成内容   : イスコ個別対応</br>
    /// <br>Update Note: K2011/12/09 鄧潘ハン</br>
    /// <br>管理番号   : 10703874-00</br>
    /// <br>作成内容   : イスコ個別対応</br>
    /// <br>Update Note: 2011/12/14 yangmj</br>
    /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
    /// <br>             redmine#27359 伝票検索の画面表示の対応</br>
    /// <br>Update Note: 2012/11/13 宮本 利明</br>
    /// <br>管理番号   : 10801804-00 №1668</br>
    /// <br>             売上過去日付制御を個別オプション化（イスコまたはオプションありで日付制御）</br>
    /// <br>Update Note: 2015/05/12  イン晶晶</br>
    /// <br>管理番号   : 11175123-00</br>
    /// <br>           : Redmine#45799 アライ商会様 №12 デュアルモニタで使用した際のガイドウィンドの表示位置の対応</br>
    /// <br>Update Note: 2015/11/27 時シン</br>
    /// <br>管理番号   : 11170204-00 売上伝票入力の障害対応</br>
    /// <br>           : Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応</br>
    /// </remarks>
    public partial class MAHNB01010UD : Form
    {
        public MAHNB01010UD(int acptAnOdrStatus, string salesSlipNum, bool canAcptAnOdrStatusChange, int mode)
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._canAcptAnOdrStatusChange = canAcptAnOdrStatusChange;
            this._mode = mode;
        }

        private ImageList _imageList16 = null;

        private SalesSlipInputAcs _salesSlipInputAcs;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string login_EnterpriseCode = "0123130012020600"; // ADD K2011/12/09
        private bool _canAcptAnOdrStatusChange = false;
        private int _mode = ct_MODE_Normal;
        private SalesSlip _salesSlip = null;
        private SalesSlip _baseSalesSlip = null;
        private List<SalesDetail> _salesDetailList = null;
        private List<SalesDetail> _addUpSrcDetailList = null;
        private SearchDepsitMain _depsitMain = null;
        private SearchDepositAlw _depositAlw = null;
        private List<StockWork> _stockWorkList = null;
        private List<AcceptOdrCar> _acceptOdrCarList = null;

        private List<StockSlipWork> _stockSlipWorkList = null;
        private List<StockDetailWork> _stockDetailWorkList = null;
        private List<AddUpOrgStockDetailWork> _addUpOrgStockDetailList = null;
        private List<PaymentSlpWork> _paymentSlpWorkList = null;
        private List<UOEOrderDtlWork> _uoeOrderDtlWorkList = null;
        //>>>2010/02/26
        private UserSCMOrderHeaderRecord _scmHeader = null;
        private UserSCMOrderCarRecord _scmCar = null;
        private List<UserSCMOrderDetailRecord> _scmDetailList = null;
        private List<UserSCMOrderAnswerRecord> _scmAnswerList = null;
        //<<<2010/02/26

        private int _acptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales;
        private string _salesSlipNum = "";
        public static readonly int ct_MODE_Normal = 0;
        public static readonly int ct_MODE_RetGoods = 1;
        public static readonly int ct_MODE_Estimate = 2;
        public static readonly int ct_MODE_RedSlip = 3;

        public static readonly bool ct_AcptAnOdrStatusEnable_True = true;
        public static readonly bool ct_AcptAnOdrStatusEnable_False = false;

        DialogResult _result = DialogResult.Cancel;

        /// <summary>売上データプロパティ</summary>
        internal SalesSlip SalesSlip
        {
            get { return _salesSlip; }
        }
        /// <summary>再取得前売上データプロパティ</summary>
        internal SalesSlip BaseSalesSlip
        {
            get { return _baseSalesSlip; }
        }
        /// <summary>売上明細データリストプロパティ</summary>
        internal List<SalesDetail> SalesDetailList
        {
            get { return _salesDetailList; }
        }
        /// <summary>計上元明細リストプロパティ</summary>
        internal List<SalesDetail> AddUpSrcDetailList
        {
            get { return _addUpSrcDetailList; }
        }
        /// <summary>入金データプロパティ</summary>
        internal SearchDepsitMain DepsitMain
        {
            get { return _depsitMain; }
        }
        /// <summary>入金引当データプロパティ</summary>
        internal SearchDepositAlw DepositAlw
        {
            get { return _depositAlw; }
        }
        /// <summary>在庫ワークリストプロパティ</summary>
        internal List<StockWork> StockWorkList
        {
            get { return _stockWorkList; }
        }
        /// <summary>受注マスタ（車両）リストプロパティ</summary>
        internal List<AcceptOdrCar> AcceptOdrCarList
        {
            get { return _acceptOdrCarList; }
        }
        /// <summary>仕入データリストプロパティ</summary>
        internal List<StockSlipWork> StockSlipWorkList
        {
            get { return _stockSlipWorkList; }
        }
        /// <summary>仕入明細データリストプロパティ</summary>
        internal List<StockDetailWork> StockDetailWorkList
        {
            get { return _stockDetailWorkList; }
        }
        /// <summary>計上元仕入明細データリストプロパティ</summary>
        internal List<AddUpOrgStockDetailWork> addUpOrgStockDetailList
        {
            get { return _addUpOrgStockDetailList; }
        }
        /// <summary>支払データリストプロパティ</summary>
        internal List<PaymentSlpWork> paymentSlpWorkList
        {
            get { return _paymentSlpWorkList; }
        }
        /// <summary>UOE発注データワークリストプロパティ</summary>
        internal List<UOEOrderDtlWork> uoeOrderDtlWorkList
        {
            get { return _uoeOrderDtlWorkList; }
        }
// add yangmj
        /// <summary>売上データプロパティ</summary>
        public SalesSlip DfSalesSlip
        {
            get { return _salesSlip; }
        }
        /// <summary>再取得前売上データプロパティ</summary>
        public SalesSlip DfBaseSalesSlip
        {
            get { return _baseSalesSlip; }
        }
        /// <summary>売上明細データリストプロパティ</summary>
        public List<SalesDetail> DfSalesDetailList
        {
            get { return _salesDetailList; }
        }
        /// <summary>計上元明細リストプロパティ</summary>
        public List<SalesDetail> DfAddUpSrcDetailList
        {
            get { return _addUpSrcDetailList; }
        }
        /// <summary>入金データプロパティ</summary>
        public SearchDepsitMain DfDepsitMain
        {
            get { return _depsitMain; }
        }
        /// <summary>入金引当データプロパティ</summary>
        public SearchDepositAlw DfDepositAlw
        {
            get { return _depositAlw; }
        }
        /// <summary>在庫ワークリストプロパティ</summary>
        public List<StockWork> DfStockWorkList
        {
            get { return _stockWorkList; }
        }
        /// <summary>受注マスタ（車両）リストプロパティ</summary>
        public List<AcceptOdrCar> DfAcceptOdrCarList
        {
            get { return _acceptOdrCarList; }
        }
        /// <summary>仕入データリストプロパティ</summary>
        public List<StockSlipWork> DfStockSlipWorkList
        {
            get { return _stockSlipWorkList; }
        }
        /// <summary>仕入明細データリストプロパティ</summary>
        public List<StockDetailWork> DfStockDetailWorkList
        {
            get { return _stockDetailWorkList; }
        }
        /// <summary>計上元仕入明細データリストプロパティ</summary>
        public List<AddUpOrgStockDetailWork> DfaddUpOrgStockDetailList
        {
            get { return _addUpOrgStockDetailList; }
        }
        /// <summary>支払データリストプロパティ</summary>
        public List<PaymentSlpWork> DfpaymentSlpWorkList
        {
            get { return _paymentSlpWorkList; }
        }
        /// <summary>UOE発注データワークリストプロパティ</summary>
        public List<UOEOrderDtlWork> DfuoeOrderDtlWorkList
        {
            get { return _uoeOrderDtlWorkList; }
        }
        // end add yangmj
        //>>>2010/02/26
        /// <summary>SCM受注データプロパティ</summary>
        public UserSCMOrderHeaderRecord scmHeader
        {
            get { return _scmHeader; }
        }
        /// <summary>SCM受注データ(車両情報)プロパティ</summary>
        public UserSCMOrderCarRecord scmCar
        {
            get { return _scmCar; }
        }
        /// <summary>SCM受注明細データ(問合せ・発注)プロパティ</summary>
        public List<UserSCMOrderDetailRecord> scmDetailList
        {
            get { return _scmDetailList; }
        }
        /// <summary>SCM受注明細データ(回答)プロパティ</summary>
        public List<UserSCMOrderAnswerRecord> scmAnswerList
        {
            get { return _scmAnswerList; }
        }
        //<<<2010/02/26

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>true:保存成功 false:保存失敗</returns>
        /// <br>Update Note: K2011/12/09 鄧潘ハン</br>
        /// <br>管理番号   : 10703874-00</br>
        /// <br>作成内容   : イスコ個別対応</br>
        private bool Save()
        {
            if (this.tNedit_SalesSlipNum.GetInt() == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "伝票番号が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            else
            {
                bool customerError = false;
                SalesSlip salesSlip;
                SalesSlip baseSalesSlip;
                List<SalesDetail> salesDetailList;
                List<SalesDetail> addUpSrcDetailList;
                SearchDepsitMain depsitMain;
                SearchDepositAlw depositAlw;
                List<StockWork> stockWorkList;
                List<StockSlipWork> stockSlipWorkList;
                List<StockDetailWork> stockDetailWorkList;
                List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
                List<AcceptOdrCar> acceptOdrCarList;
                List<UOEOrderDtlWork> uoeOrderDtlWorkList;
                //>>>2010/02/26
                UserSCMOrderHeaderRecord scmHeader;
                UserSCMOrderCarRecord scmCar;
                List<UserSCMOrderDetailRecord> scmDetailList;
                List<UserSCMOrderAnswerRecord> scmAnswerList;
                //<<<2010/02/26
                int acptAnOdrStatus = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_AcptAnOdrStatus);
                int svAcptAnOdrStatus = acptAnOdrStatus;
                if ((acptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate) ||
                    (acptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)) acptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate;

                // データリード処理
                //>>>2010/02/26
                //int status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, this.tNedit_SalesSlipNum.Text.PadLeft(9, '0'), false, true, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList);
                int status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, this.tNedit_SalesSlipNum.Text.PadLeft(9, '0'), false, true, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
                //<<<2010/02/26

                // 見積は通常見積のみ、単価見積は単価見積のみ、検索見積は検索見積のみ読み込み可能とする
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (svAcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate)
                    {
                        if (salesSlip.EstimateDivide != (int)SalesSlipInputAcs.EstimateDivide.Estimate) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else if (svAcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate)
                    {
                        if (salesSlip.EstimateDivide != (int)SalesSlipInputAcs.EstimateDivide.UnitPriceEstimate) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else if (svAcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.SearchEstimate)
                    {
                        if (salesSlip.EstimateDivide != (int)SalesSlipInputAcs.EstimateDivide.SearchEstimate)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        else
                        {
                            if (salesSlip.CustomerCode == 0)
                            {
                                customerError = true;
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._result = DialogResult.OK;
                    this._salesSlip = salesSlip;
                    this._baseSalesSlip = baseSalesSlip;
                    this._salesDetailList = salesDetailList;
                    this._addUpSrcDetailList = addUpSrcDetailList;
                    this._depsitMain = depsitMain;
                    this._depositAlw = depositAlw;
                    this._stockWorkList = stockWorkList;
                    this._acceptOdrCarList = acceptOdrCarList;

                    this._stockSlipWorkList = stockSlipWorkList;
                    this._stockDetailWorkList = stockDetailWorkList;
                    this._addUpOrgStockDetailList = addUpOrgStockDetailList;

                    this._uoeOrderDtlWorkList = uoeOrderDtlWorkList;
                    //>>>2010/02/26
                    this._scmHeader = scmHeader;
                    this._scmCar = scmCar;
                    this._scmDetailList = scmDetailList;
                    this._scmAnswerList = scmAnswerList;
                    //<<<2010/02/26
                }
                else
                {
                    if (customerError)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先が設定されていない伝票は指定できません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    else
                    {
                        // ----- ADD K2011/12/09 --------------------------->>>>>
                        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
                        //if (this._enterpriseCode == login_EnterpriseCode)
                        Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                        ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesDateControl);
                        if ((ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract) ||
                            (this._enterpriseCode == login_EnterpriseCode))
                        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
                        {
                            if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false) return false;
                        }
                        // ----- ADD K2011/12/09 ---------------------------<<<<<
                        //if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false) return false; // ADD K2011/08/12 // DEL K2011/12/09
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "該当データが存在しません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 売上伝票番号 ============================================ //
                case "tNedit_SalesSlipNum":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    int code = this.tNedit_SalesSlipNum.GetInt();

                                    if (code != 0)
                                    {
                                        bool canSave = this.Save();

                                        if (canSave)
                                        {
                                            this.Close();
                                        }
                                        else
                                        {
                                            this.uButton_SalesSlipGuide.Focus();
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// 確定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            bool canSave = this.Save();

            if (canSave)
            {
                this.Close();
            }
            else
            {
                this.tNedit_SalesSlipNum.Focus();
            }
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// フォームクローズ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAKON01110UD_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = this._result;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAKON01110UD_Load(object sender, EventArgs e)
        {
            this.uButton_SalesSlipGuide.ImageList = this._imageList16;
            this.uButton_SalesSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.SettingAcptAnOdrStatusComboEditor(this._mode);

            ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AcptAnOdrStatus, this._acptAnOdrStatus, true);
            this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(this._salesSlipNum, 0));

            if (this._canAcptAnOdrStatusChange)
            {
                this.tComboEditor_AcptAnOdrStatus.Enabled = true;
            }
            else
            {
                this.tComboEditor_AcptAnOdrStatus.Enabled = false;
            }

            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// 受注ステータスComboEditor設定
        /// </summary>
        /// <param name="mode"></param>
        private void SettingAcptAnOdrStatusComboEditor(int mode)
        {
            if (mode == ct_MODE_RetGoods)
            {
                // 返品モード時は「売上、貸出」のみ選択可
                this.tComboEditor_AcptAnOdrStatus.Items.Clear();
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 0;
                item0.DataValue = 30;
                item0.DisplayText = "売上";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 1;
                item1.DataValue = 40;
                item1.DisplayText = "貸出";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item1);
            }
            else if (mode == ct_MODE_Estimate)
            {
                // 見積モード時は「見積、単価見積、検索見積」のみ選択可
                this.tComboEditor_AcptAnOdrStatus.Items.Clear();
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 0;
                item0.DataValue = 10;
                item0.DisplayText = "見積";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 1;
                item1.DataValue = 15;
                item1.DisplayText = "単価見積";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item1);
                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                item2.Tag = 2;
                item2.DataValue = 16;
                item2.DisplayText = "検索見積";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item2);
            }
            else
            {
                // 通常モード
                this.tComboEditor_AcptAnOdrStatus.Items.Clear();
                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                item0.Tag = 0;
                item0.DataValue = 30;
                item0.DisplayText = "売上";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item0);
                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
                item1.Tag = 1;
                item1.DataValue = 40;
                item1.DisplayText = "貸出";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item1);
                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                item2.Tag = 2;
                item2.DataValue = 20;
                item2.DisplayText = "受注";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item2);
                Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
                item3.Tag = 3;
                item3.DataValue = 10;
                item3.DisplayText = "見積";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item3);
                Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
                item4.Tag = 4;
                item4.DataValue = 15;
                item4.DisplayText = "単価見積";
                this.tComboEditor_AcptAnOdrStatus.Items.Add(item4);
            }
        }

        /// <summary>
        /// 初期フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            this.tNedit_SalesSlipNum.Focus();
        }

        // ----- DEL 2015/11/27 時シン Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応 ----->>>>>
        ////------ ADD START イン晶晶 2015/05/12 for Redmine#45799のアライ商会No.12  デュアルモニタで使用した際のガイドウィンドの表示位置の対応 ------>>>>>
        ///// <summary>
        ///// IWin32Windowクラスのラッパークラス
        ///// メインウインドウ(delphiの画面　MAHNB01001U.exe)のハンドルを設定するために作成
        ///// 使用箇所はデュアルモニタで使用した際のガイドウィンドの表示位置
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 使用箇所はデュアルモニタで使用した際のガイドウィンドの表示位置を設定する。</br>
        ///// <br>Programmer : イン晶晶</br>
        ///// <br>Date       : 2015/05/12</br>
        ///// </remarks>
        //private class IWin32WindowWrapper : System.Windows.Forms.IWin32Window
        //{
        //    private IntPtr _handle;
        //    public IntPtr Handle
        //    {
        //        get { return _handle; }
        //    }

        //    public IWin32WindowWrapper(IntPtr handle)
        //    {
        //        _handle = handle;
        //    }
        //}
        ////------ ADD END イン晶晶 2015/05/12 for Redmine#45799のアライ商会No.12  デュアルモニタで使用した際のガイドウィンドの表示位置の対応 ------<<<<<
        // ----- DEL 2015/11/27 時シン Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応 -----<<<<<

        /// <summary>
        /// 売上伝票検索ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/12/14 yangmj</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
        /// <br>             redmine#27359 伝票検索の画面表示の対応</br>
        /// <br>Update Note: 2015/05/12  イン晶晶</br>
        /// <br>管理番号   : 11175123-00</br>
        /// <br>           : Redmine#45799 アライ商会様 №12 デュアルモニタで使用した際のガイドウィンドの表示位置の対応</br>
        /// <br>Update Note: 2015/11/27 時シン</br>
        /// <br>管理番号   : 11170204-00 売上伝票入力の障害対応</br>
        /// <br>           : Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応</br>
        private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            int acptAnOdrStatusDisplay = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_AcptAnOdrStatus);
            int acptAnOdrStatus = acptAnOdrStatusDisplay;
            int estimateDivide;
            SalesSlipInputAcs.GetAcptAnOdrStatusAndEstimateDivideFromDisplay(acptAnOdrStatusDisplay, ref acptAnOdrStatus, out estimateDivide);
            
            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            // 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region 2009/09/10 DEL
            //salesSlipGuide.TComboEditor_SalesFormalCode = false;
            //salesSlipGuide.AutoSearch = true;
            //salesSlipGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
            //salesSlipGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
            //salesSlipGuide.AcptAnOdrStatus = acptAnOdrStatusDisplay;
            //switch (this._mode)
            //{
            //    case 0: // 通常
            //        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
            //        salesSlipGuide.SalesSlipCd = 0;
            //        break;
            //    case 2: // 見積
            //        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
            //        salesSlipGuide.SalesSlipCd = 0;
            //        break;
            //    case 1: // 返品
            //    case 3: // 赤伝
            //        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.Sales;
            //        salesSlipGuide.SalesSlipCd = 0;
            //        break;
            //}

            //SalesSlipSearchResult searchResult;
            //DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult);

            //if (result == DialogResult.OK)
            //{
            //    if (searchResult != null)
            //    {
            //        this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(searchResult.SalesSlipNum, 0));

            //        bool canSave = this.Save();

            //        if (canSave)
            //        {
            //            this.Close();
            //        }
            //        else
            //        {
            //            this.tNedit_SalesSlipNum.Focus();
            //        }
            //    }
            //}
            #endregion
            try
            {
                salesSlipGuide.TComboEditor_SalesFormalCode = false;
                //salesSlipGuide.AutoSearch = true;//DEL 2011/12/14 YANGMJ REDMINE#27359
                salesSlipGuide.AutoSearch = false;//ADD 2011/12/14 YANGMJ REDMINE#27359
                salesSlipGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
                salesSlipGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
                salesSlipGuide.AcptAnOdrStatus = acptAnOdrStatusDisplay;
                salesSlipGuide.StartMode = 1;//ADD 2011/12/14 YANGMJ REDMINE#27359
                switch (this._mode)
                {
                    case 0: // 通常
                        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
                        salesSlipGuide.SalesSlipCd = 0;
                        break;
                    case 2: // 見積
                        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.All;
                        salesSlipGuide.SalesSlipCd = 0;
                        break;
                    case 1: // 返品
                    case 3: // 赤伝
                        salesSlipGuide.ExtractSlipCdType = ExtractSlipCdType.Sales;
                        salesSlipGuide.SalesSlipCd = 0;
                        break;
                }

                SalesSlipSearchResult searchResult;
                //DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult); // DEL イン晶晶 2015/05/12 for Redmine#45799
                //------ ADD START イン晶晶 2015/05/12 for Redmine#45799のアライ商会No.12  デュアルモニタで使用した際のガイドウィンドの表示位置の対応 ------>>>>>
                // ウィンドの表示位置をセットする
                salesSlipGuide.StartPosition = FormStartPosition.CenterScreen;
                // ----- DEL 2015/11/27 時シン Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応 ----->>>>>
                //IntPtr handle;
                //try
                //{
                //    handle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                //}
                //catch
                //{

                //}
                //DialogResult result;
                //if (handle != null)
                //{
                //    // IWin32Windowラッパークラスのインスタンスに、メインウィンドウのハンドルを設定
                //    IWin32WindowWrapper wrp = new IWin32WindowWrapper(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
                //    result = salesSlipGuide.ShowGuide(wrp, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult);
                //}
                //else
                //{
                //    result = salesSlipGuide.ShowGuide(this._salesSlipInputAcs.Owner, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult);
                //}
                // ----- DEL 2015/11/27 時シン Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応 -----<<<<<
                //------ ADD END イン晶晶 2015/05/12 for Redmine#45799のアライ商会No.12  デュアルモニタで使用した際のガイドウィンドの表示位置の対応 ------<<<<<
                DialogResult result = salesSlipGuide.ShowGuide(this._salesSlipInputAcs.Owner, _enterpriseCode, acptAnOdrStatusDisplay, estimateDivide, out searchResult); // ADD 2015/11/27 時シン Redmine#45799 #67でデュアルモニタで使用した際のガイドウィンドの表示位置の対応

                if (result == DialogResult.OK)
                {
                    if (searchResult != null)
                    {
                        this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(searchResult.SalesSlipNum, 0));

                        bool canSave = this.Save();

                        if (canSave)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.tNedit_SalesSlipNum.Focus();
                        }
                    }
                }
            }
            finally
            {
                salesSlipGuide.Dispose();
            }
            // 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上年間実績照会テキスト出力条件設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上年間実績照会覧テキスト出力設定UIクラスです。</br>
    /// <br>Programmer : 徐後継</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/08/12 chenyd</br>
    /// <br>            ・障害ID:13021 テキスト出力対応</br>
    /// <br>Update Note: 2010/08/25 chenyd</br>
    /// <br>            ・障害ID:13278 テキスト出力対応</br>
    /// <br>Update Note: 2010/09/09 楊明俊</br>
    /// <br>            ・障害ID:13278 PM1010Fテキスト出力対応</br>
    /// <br>Update Note: 2024/11/29 陳艶丹</br>
    /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// </remarks>
    public partial class DCHNB04180UE : Form
    {
        #region プライベートメン

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;                  

        /// <summary>企業コード</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>集計区分</summary>
        private bool _excelFlg;

        /// <summary>集計区分</summary>
        private int _totalDiv = 0;

        /// <summary>対象年度</summary>
        private int _financialYear = 0;

        /// <summary>出力ファイル名</summary>
        private string _settingFileName = string.Empty;

        /// <summary>拠点コードリスト</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>SelectionCodeリスト</summary>
        private List<string[]> _selectionCodeList = new List<string[]>();

        /// <summary>拠点名称</summary>
        private string _sectionName = string.Empty;

        /// <summary>SelectionName</summary>
        private string _selectionName = string.Empty;
        /// <summary>会計年度</summary>
        private int _financialYearsd;
        /// <summary>前回値保持</summary>
        PrevInputValue _prevInputValue = new PrevInputValue();
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始拠点コード「ログオペレーションデータ」</summary>
        private string _sectionCodeSt = string.Empty;
        /// <summary>終了拠点コード「ログオペレーションデータ」</summary>
        private string _sectionCodeEd = string.Empty;
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        // --- ADD 2010/08/25 -------------------------------->>>>>
        /// <summary>stSelectionName</summary>
        private string _st_selectionCode = string.Empty;

        /// <summary>edSelectionName</summary>
        private string _ed_selectionCode = string.Empty;

        // --- ADD 2010/10/09 ---------->>>>>
        # region Delegate
        /// <summary>
        /// データを出力
        /// </summary>
        /// <returns>出力結果</returns>
        internal delegate bool OutputDataEvent();
        #endregion

        # region Event
        /// <summary>データを出力イベント</summary>
        internal event OutputDataEvent OutputData;
        #endregion
        // --- ADD 2010/10/09 ----------<<<<<

        /// <summary>_searDiv</summary>
        private int _searDiv;
        // --- ADD 2010/08/25 --------------------------------<<<<<
        private const string TOTALDIV_ALL = "全社";
        private const string TOTALDIV_SECT = "拠点";
        private const string TOTALDIV_CUST = "得意先";
        private const string TOTALDIV_SEMP = "担当者";
        private const string TOTALDIV_FEMP = "受注者";
        private const string TOTALDIV_INPU = "発行者";
        private const string TOTALDIV_AREA = "地区";
        private const string TOTALDIV_TYPE = "業種";

        private const int SELECT_CUST = 77;
        private const int SELECT_EMP = 44;
        private const int SELECT_AREA = 44;
        private const int SELECT_TYPE = 44;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// テキスト出力条件設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力条件設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public DCHNB04180UE()
        {
            InitializeComponent();
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 集計区分
        /// </summary>
        public int TotalDiv
        {
            get { return this._totalDiv; }
            set { this._totalDiv = value; }
        }

        /// <summary>
        /// 対象年月
        /// </summary>
        public int FinancialYear
        {
            get { return this._financialYear; }
            set { this._financialYear = value; }
        }
        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

        /// <summary>
        /// フォーム終了ステータス
        /// </summary>
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { this._dialogResult = value; }
        }

        /// <summary>
        /// 出力形式
        /// </summary>
        public bool ExcelFlg
        {
            get { return _excelFlg; }
            set { this._excelFlg = value; }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }

        /// <summary>
        /// SelectionCodeリスト
        /// </summary>
        public List<string[]> SelectionCodeList
        {
            get { return this._selectionCodeList; }
            set { this._selectionCodeList = value; }
        }
        // --- ADD 2010/08/25 -------------------------------->>>>>
        /// <summary>
        /// 検索区分
        /// </summary>
        public int SearDiv
        {
            get { return this._searDiv; }
            set { this._searDiv = value; }
        }

        /// <summary>
        /// St_SelectionCode
        /// </summary>
        public string St_SelectionCode
        {
            get { return _st_selectionCode; }
            set { this._st_selectionCode = value; }
        }
        /// <summary>
        /// Ed_SelectionCode
        /// </summary>
        public string Ed_SelectionCode
        {
            get { return _ed_selectionCode; }
            set { this._ed_selectionCode = value; }
        }
        // --- ADD 2010/08/25 --------------------------------<<<<<
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始拠点コード「ログオペレーションデータ」</summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// <summary>終了拠点コード「ログオペレーションデータ」</summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        #endregion

        #region イベント
        /// <summary>
        /// テキスト出力条件設定ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : テキスト出力条件設定ロードイベントです。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void DCHNB04180UE_Load(object sender, EventArgs e)
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeSt.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.ImageList = this._imageList16;
            this.uButton_SelectionCodeSt.ImageList = this._imageList16;
            this.uButton_SelectionCodeEd.ImageList = this._imageList16;
            this.uButton_FileSelect.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1;

            // コンボボックスに情報セット
            this.tComboEditor_TotalDiv1.Items.Clear();
            this.tComboEditor_TotalDiv1.Items.Add(0, TOTALDIV_SECT);
            this.tComboEditor_TotalDiv1.Items.Add(1, TOTALDIV_CUST);
            this.tComboEditor_TotalDiv1.Items.Add(2, TOTALDIV_SEMP);
            this.tComboEditor_TotalDiv1.Items.Add(3, TOTALDIV_FEMP);
            this.tComboEditor_TotalDiv1.Items.Add(4, TOTALDIV_INPU);
            this.tComboEditor_TotalDiv1.Items.Add(5, TOTALDIV_AREA);
            this.tComboEditor_TotalDiv1.Items.Add(6, TOTALDIV_TYPE);
            this.tComboEditor_TotalDiv1.MaxDropDownItems = this.tComboEditor_TotalDiv1.Items.Count;

            // 集計区分の初期化の設定
            this.tComboEditor_TotalDiv1.SelectedIndex = this._totalDiv;
            // 対象年月の初期化の設定
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);
            int _companyBiginMonthsd = 0;
            SelesAnnualDataAcs _SelesAnnualDataAcs = new SelesAnnualDataAcs();
            // 会計年度取得
            _SelesAnnualDataAcs.GetCompanyInf(this._enterpriseCode, out _financialYearsd, out _companyBiginMonthsd);
            
            // 出力ファイル名の初期化の設定
            this.ChangeFileName();
        }

        /// <summary>
        /// 選択が変更されたイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : 選択が変更された場合に発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void tComboEditor_TotalDiv_SelectionChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Height = this.tNedit_SectionCodeSt.Size.Height;
            int totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;
            switch (totalDiv)
            {
                case 0: // 拠点
                    {
                        this.tNedit_SelectionCode_St.Visible = false;
                        this.tNedit_SelectionCode_Ed.Visible = false;
                        this.uLabel_SelectionCode.Visible = false;
                        this.ultraLabel11.Visible = false;
                        this.uButton_SelectionCodeSt.Visible = false;
                        this.uButton_SelectionCodeEd.Visible = false;
                        break;
                    }
                case 1: // 得意先
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        this.uLabel_SelectionCode.Text = TOTALDIV_CUST;
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 8;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 8;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = false;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = false;
                        break;
                    }
                case 2: // 担当者
                case 3: // 受注者
                case 4: // 発行者
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        if (totalDiv == 2) { this.uLabel_SelectionCode.Text = TOTALDIV_SEMP; }
                        else if (totalDiv == 3) { this.uLabel_SelectionCode.Text = TOTALDIV_FEMP; }
                        else if (totalDiv == 4) { this.uLabel_SelectionCode.Text = TOTALDIV_INPU; }
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 4;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 4;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = false;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = false;
                        break;
                    }
                case 5: // 地区
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        this.uLabel_SelectionCode.Text = TOTALDIV_AREA;
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 4;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 4;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = true;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = true;
                        break;
                    }
                case 6: // 業種
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        this.uLabel_SelectionCode.Text = TOTALDIV_TYPE;
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 4;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 4;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = true;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = true;
                        break;
                    }
            }
            // 出力ファイル名の設定
            this.ChangeFileName();
            this.Clear();
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
                this.DResult = DialogResult.OK;
                // --- UPD 2010/10/09 ---------->>>>>
                //this.Close();
                bool outputRslt = true;
                if (this.OutputData != null)
                {
                    outputRslt = this.OutputData();
                }
                if (outputRslt)
                {
                    this.Close();
                }
                // --- UPD 2010/10/09 ----------<<<<<
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();   
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SectionCode_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((Control)sender).Name.EndsWith("St"))
                {
                    this.tNedit_SectionCodeSt.Text = sectionInfo.SectionCode.Trim();
                    this._sectionName = sectionInfo.SectionGuideNm;
                    this._prevInputValue.SectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/09/15
                }
                else
                {
                    this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                    this._prevInputValue.SectionCodeEd = this.tNedit_SectionCodeEd.Text; // ADD 2010/09/15
                }
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SelectionCode_Click(object sender, EventArgs e)
        {
            int totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;

            if (totalDiv == 1)
            {

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                if (((Control)sender).Name.EndsWith("St"))
                {
                    customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerStSelect);
                }
                else
                {
                    customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerEdSelect);
                }
                customerSearchForm.ShowDialog(this);
            }
            else if ((totalDiv == 2) || (totalDiv == 3) || (totalDiv == 4))
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                Employee employee;
                int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (((Control)sender).Name.EndsWith("St"))
                    {
                        this.tNedit_SelectionCode_St.Text = employee.EmployeeCode.Trim();
                        this._selectionName = employee.Name;
                        this._prevInputValue.SelectionCodeSt = this.tNedit_SelectionCode_St.Text; // ADD 2010/09/15
                    }
                    else
                    {
                        this.tNedit_SelectionCode_Ed.Text = employee.EmployeeCode.Trim();
                        this._prevInputValue.SelectionCodeEd = this.tNedit_SelectionCode_Ed.Text; // ADD 2010/09/15
                    }
                }
            }
            else if ((totalDiv == 5) || (totalDiv == 6))
            {
                int userGuideDivCd;

                if (totalDiv == 5)
                {
                    userGuideDivCd = 21; // 地区（販売エリア）
                } 
                else
                {
                    userGuideDivCd = 33; // 業種
                }

                UserGuideAcs _userGuideAcs = new UserGuideAcs();
                UserGdHd userGdHd = new UserGdHd();
                UserGdBd userGdBd = new UserGdBd();
                int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (((Control)sender).Name.EndsWith("St"))
                    {
                        this.tNedit_SelectionCode_St.SetInt(userGdBd.GuideCode);
                        this._selectionName = userGdBd.GuideName;
                        this._prevInputValue.SelectionCodeSt = this.tNedit_SelectionCode_St.DataText; // ADD 2010/09/15
                    }
                    else
                    {
                        this.tNedit_SelectionCode_Ed.SetInt(userGdBd.GuideCode);
                        this._prevInputValue.SelectionCodeEd = this.tNedit_SelectionCode_Ed.DataText; // ADD 2010/09/15
                    }
                }
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excelファイル(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            }
            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <br>Note       : 得意先が選択された時ときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void CustomerSearchForm_CustomerStSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            this.tNedit_SelectionCode_St.SetInt(customerInfo.CustomerCode);
            this._selectionName = customerInfo.Name;
            this._prevInputValue.SelectionCodeSt = this.tNedit_SelectionCode_St.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <br>Note       : 得意先が選択された時ときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void CustomerSearchForm_CustomerEdSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            this.tNedit_SelectionCode_Ed.SetInt(customerInfo.CustomerCode);
            this._selectionName = customerInfo.Name;
            this._prevInputValue.SelectionCodeEd = this.tNedit_SelectionCode_Ed.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォーカスが変更された時ときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            ・障害ID:13021 テキスト出力対応</br>
        /// <br>Update Note: 2010/09/20 tianjw</br>
        /// <br>            ・テキスト出力対応</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            string errMessage = string.Empty;
            int totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;
            switch (prevCtrl.Name)
            {
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, true);
                        if (status)
                        {
                            this.tNedit_SectionCodeSt.Text = code;
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SectionCodeSt.Text.Trim() == "00")
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeEd;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始拠点コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            // コード戻す
                            this.tNedit_SectionCodeSt.Text = code;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, false);
                        if (status)
                        {
                            this.tNedit_SectionCodeEd.Text = code;
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SectionCodeEd.Text.Trim() == "00")
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeEd;
                                            }
                                            else
                                            {
                                                if (this.tNedit_SelectionCode_St.Visible == true)
                                                {
                                                    e.NextCtrl = this.tNedit_SelectionCode_St;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tDateEdit_FinancialYear;
                                                }
                                                
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "終了拠点コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            // コード戻す
                            this.tNedit_SectionCodeEd.Text = code;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SelectionCode_St":
                    {
                        // ---------- UPD 2010/09/20 ------------------------------>>>>>
                        //int inputValue = this.tNedit_SelectionCode_Ed.GetInt();
                        string inputValueStr = this.tNedit_SelectionCode_St.DataText;
                        // ---------- UPD 2010/09/20 ------------------------------<<<<<
                        int code;
                        // ---------- UPD 2010/09/21 ------------------------------>>>>>
                        //if (inputValue != 0)
                        if (!string.IsNullOrEmpty(inputValueStr))
                        // ---------- UPD 2010/09/21 ------------------------------<<<<<
                        {
                            int inputValue = Convert.ToInt32(inputValueStr); // ADD 2010/09/21
                            if (totalDiv == 1)
                            {
                                // 得意先
                                // ---------- UPD 2010/09/21 ------------------------------>>>>>
                                string customerCode = string.Empty;
                                //bool status = ReadCustomerName(out code, inputValue, true, totalDiv);
                                bool status = ReadCustomerName(out customerCode, inputValue, true, totalDiv);
                                // ---------- UPD 2010/09/21 ------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_St.SetInt(code); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = customerCode; //ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeSt;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_SelectionCode_Ed;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "開始得意先コード [" + inputValue + "] に該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    //this.tNedit_SelectionCode_St.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = customerCode; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                            else if ((totalDiv == 5) || (totalDiv == 6))
                            {
                                int userGuideDivCd = 0;
                                if (totalDiv == 5)
                                {
                                    // 地区（販売エリア）
                                    userGuideDivCd = 21;
                                    errMessage = "開始地区コード [" + inputValue + "] に該当するデータが存在しません。";
                                }
                                else
                                {
                                    // 業種
                                    userGuideDivCd = 33;
                                    errMessage = "開始業種コード [" + inputValue + "] に該当するデータが存在しません。";
                                }
                                // --------- UPD 2010/09/21 ------------------------------------------------->>>>>
                                string codeStr = string.Empty;
                                //bool status = ReadSelectionName(out code, inputValue, true, userGuideDivCd);
                                bool status = ReadSelectionName(out codeStr, inputValue, true, userGuideDivCd);
                                // --------- UPD 2010/09/21 -------------------------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_St.SetInt(code); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = codeStr; // ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeSt;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_SelectionCode_Ed;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    //this.tNedit_SelectionCode_St.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = codeStr; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            else
                            {
                                string employeeInputValue = this.tNedit_SelectionCode_St.Text.Trim().PadLeft(4, '0');// ADD 2010/08/12 障害ID:13021対応
                                string employeeCode;// ADD 2010/08/12 障害ID:13021対応

                                // 担当者・受注者・発行者
                                //bool status = ReadCustomerName(out code, inputValue, true, totalDiv);// DEL 2010/08/12 障害ID:13021対応
                                bool status = ReadEmployee(out employeeCode, employeeInputValue, true);// ADD 2010/08/12 障害ID:13021対応
                                if (!status)
                                {
                                    if (totalDiv == 2)
                                    {
                                        errMessage = "開始担当者コード [" + inputValue + "] に該当するデータが存在しません。";
                                    }
                                    else if (totalDiv == 3)
                                    {
                                        errMessage = "開始受注者コード [" + inputValue + "] に該当するデータが存在しません。";
                                    }
                                    else if (totalDiv == 4)
                                    {
                                        errMessage = "開始発行者コード [" + inputValue + "] に該当するデータが存在しません。";
                                    }
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    //this.tNedit_SelectionCode_St.Text = code.ToString();// DEL 2010/08/12 障害ID:13021対応
                                    this.tNedit_SelectionCode_St.Text = employeeCode;// ADD 2010/08/12 障害ID:13021対応
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    //this.tNedit_SelectionCode_St.SetInt(code);// DEL 2010/08/12 障害ID:13021対応
                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeSt;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_SelectionCode_Ed;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SelectionCode_Ed":
                    {
                        // ---------- UPD 2010/09/20 ------------------------------>>>>>
                        //int inputValue = this.tNedit_SelectionCode_Ed.GetInt();
                        string inputValueStr = this.tNedit_SelectionCode_Ed.DataText;
                        // ---------- UPD 2010/09/20 ------------------------------<<<<<
                        int code;
                        // ---------- UPD 2010/09/21 ------------------------------>>>>>
                        //if (inputValue != 0)
                        if (!string.IsNullOrEmpty(inputValueStr))
                        // ---------- UPD 2010/09/21 ------------------------------<<<<<
                        {
                            int inputValue = Convert.ToInt32(inputValueStr); // ADD 2010/09/21
                            if (totalDiv == 1)
                            {
                                // ---------- UPD 2010/09/21 ------------------------------>>>>>
                                string customerCode = string.Empty;
                                //bool status = ReadCustomerName(out code, inputValue, false, totalDiv);
                                bool status = ReadCustomerName(out customerCode, inputValue, false, totalDiv);
                                // ---------- UPD 2010/09/21 ------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_Ed.SetInt(code); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = customerCode; // ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeEd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tDateEdit_FinancialYear;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        //"開始得意先コード [" + inputValue + "] に該当するデータが存在しません。", // DEL 2010/08/12 障害ID:13021対応
                                        "終了得意先コード [" + inputValue + "] に該当するデータが存在しません。",   // ADD 2010/08/12 障害ID:13021対応
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    //this.tNedit_SelectionCode_Ed.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = customerCode; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                            else if ((totalDiv == 5) || (totalDiv == 6))
                            {
                                int userGuideDivCd = 0;
                                if (totalDiv == 5)
                                {
                                    // 地区（販売エリア）
                                    userGuideDivCd = 21;
                                    //errMessage = "開始地区コード [" + inputValue + "] に該当するデータが存在しません。";// DEL 2010/08/12 障害ID:13021対応
                                    errMessage = "終了地区コード [" + inputValue + "] に該当するデータが存在しません。";// ADD 2010/08/12 障害ID:13021対応
                                }
                                else
                                {
                                    // 業種
                                    userGuideDivCd = 33;
                                    //errMessage = "開始業種コード [" + inputValue + "] に該当するデータが存在しません。";// DEL 2010/08/12 障害ID:13021対応
                                    errMessage = "終了業種コード [" + inputValue + "] に該当するデータが存在しません。";// ADD 2010/08/12 障害ID:13021対応
                                }
                                // --------- UPD 2010/09/21 ---------------------------------------------------->>>>>
                                string codeStr = string.Empty;
                                //bool status = ReadSelectionName(out code, inputValue, false, userGuideDivCd);
                                bool status = ReadSelectionName(out codeStr, inputValue, false, userGuideDivCd);
                                // --------- UPD 2010/09/21 ----------------------------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_Ed.SetInt(code);  // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = codeStr; // ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeEd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tDateEdit_FinancialYear;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    // コード戻す
                                    //this.tNedit_SelectionCode_Ed.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = codeStr; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            else
                            {
                                string employeeInputValue = this.tNedit_SelectionCode_Ed.Text.Trim().PadLeft(4, '0');// ADD 2010/08/12 障害ID:13021対応
                                string employeeCode;// ADD 2010/08/12 障害ID:13021対応
                                
                                // 担当者・受注者・発行者
                                //bool status = ReadCustomerName(out code, inputValue, false, totalDiv);// DEL 2010/08/12 障害ID:13021対応
                                bool status = ReadEmployee(out employeeCode, employeeInputValue, false);// ADD 2010/08/12 障害ID:13021対応
                                if (!status)
                                {
                                    if (totalDiv == 2)
                                    {
                                        //errMessage = "開始担当者コード [" + inputValue + "] に該当するデータが存在しません。";// DEL 2010/08/12 障害ID:13021対応
                                        errMessage = "終了担当者コード [" + inputValue + "] に該当するデータが存在しません。";// ADD 2010/08/12 障害ID:13021対応
                                    }
                                    else if (totalDiv == 3)
                                    {
                                        //errMessage = "開始受注者コード [" + inputValue + "] に該当するデータが存在しません。";// DEL 2010/08/12 障害ID:13021対応
                                        errMessage = "終了受注者コード [" + inputValue + "] に該当するデータが存在しません。";// ADD 2010/08/12 障害ID:13021対応
                                    }
                                    else if (totalDiv == 4)
                                    {
                                        //errMessage = "開始発行者コード [" + inputValue + "] に該当するデータが存在しません。";// DEL 2010/08/12 障害ID:13021対応
                                        errMessage = "終了発行者コード [" + inputValue + "] に該当するデータが存在しません。";// ADD 2010/08/12 障害ID:13021対応
                                    }
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    //this.tNedit_SelectionCode_Ed.Text = code.ToString();// DEL 2010/08/12 障害ID:13021対応
                                    this.tNedit_SelectionCode_Ed.Text = employeeCode;// ADD 2010/08/12 障害ID:13021対応
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    //this.tNedit_SelectionCode_Ed.SetInt(code);// DEL 2010/08/12 障害ID:13021対応

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeEd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tDateEdit_FinancialYear;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                // 対象年度
                case "tDateEdit_FinancialYear":
                    {
                        int code = this.tDateEdit_FinancialYear.GetDateYear();
                        if (code == 0 || code == 1)
                        {
                            this.tDateEdit_FinancialYear.SetLongDate(this._financialYearsd * 10000);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tEdit_SettingFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = ultraButton_OK;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 画面のクリア
        /// </summary>
        /// <br>Note       : 画面のクリア処理。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void Clear()
        {
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();

            this.tNedit_SelectionCode_St.Clear();
            this.tNedit_SelectionCode_Ed.Clear();

            this._sectionName = string.Empty;
            this._selectionName = string.Empty;
        }

        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <br>Note       : 画面入力チェックです。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             ・障害報告 #14643 テキスト出力対応</br>
        private bool InputCheck()
        {
            // 拠点
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                _prevInputValue.SectionCodeSt = "00";
            }
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                _prevInputValue.SectionCodeEd = "00";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd))
            if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始拠点コードの値が終了拠点コードの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            // SelectionCode
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text))
            {
                _prevInputValue.SelectionCodeSt = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text))
            {
                _prevInputValue.SelectionCodeEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SelectionCodeSt) > Convert.ToInt32(_prevInputValue.SelectionCodeEd) && this.tComboEditor_TotalDiv1.SelectedIndex != 0)
            if (Convert.ToInt32(_prevInputValue.SelectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SelectionCodeSt) > Convert.ToInt32(_prevInputValue.SelectionCodeEd) && this.tComboEditor_TotalDiv1.SelectedIndex != 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                string errMessage = string.Empty;
                switch (this.tComboEditor_TotalDiv1.SelectedIndex)
                {
                    case 1:
                        {
                            errMessage = "開始得意先コードの値が終了得意先コードの値を上回っています。";
                            break;
                        }
                    case 2:
                        {
                            errMessage = "開始担当者コードの値が終了担当者コードの値を上回っています。";
                            break;
                        }
                    case 3:
                        {
                            errMessage = "開始受注者コードの値が終了受注者コードの値を上回っています。";
                            break;
                        }
                    case 4:
                        {
                            errMessage = "開始発行者コードの値が終了発行者コードの値を上回っています。";
                            break;
                        }
                    case 5:
                        {
                            errMessage = "開始地区コードの値が終了地区コードの値を上回っています。";
                            break;
                        }
                    case 6:
                        {
                            errMessage = "開始業種コードの値が終了業種コードの値を上回っています。";
                            break;
                        }
                }
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            
            // 対象年月
            if (_financialYearsd < this.tDateEdit_FinancialYear.GetDateYear())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "翌年度は入力出来ません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            // 出力ファイル名
            if (string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "出力ファイル名を設定してください。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code">入力値</param>
        /// <param name="name">返り値</param>
        /// <param name="stFlg">画面拠点コード(開始)、拠点コード(終了)</param>
        /// <returns>bool</returns>
        /// <br>Note       : 拠点名称取得処理です。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private bool ReadSectionCodeAllowZero(out string code, string inputValue, bool stFlg)
        {
            // 入力値を取得
            string sectionCode = inputValue.Trim().PadLeft(2, '0');
            code = sectionCode;

            if (stFlg)
            {
                if (_prevInputValue.SectionCodeSt == sectionCode)
                {
                    this.tNedit_SectionCodeSt.Text = sectionCode;
                    return true;
                }
            }
            else
            {
                if (_prevInputValue.SectionCodeEd == sectionCode)
                {
                    this.tNedit_SectionCodeEd.Text = sectionCode;
                    return true;
                }
            }

            // 00:全社
            if (sectionCode == "00")
            {
                sectionCode = "00";
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = sectionCode;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = sectionCode;
                }
                code = sectionCode;
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --------------- UPD 2010/09/20 ------------>>>>>
                    if (sectionInfo.LogicalDeleteCode == 0)
                    {
                        code = sectionInfo.SectionCode.TrimEnd();
                        if (stFlg)
                        {
                            _prevInputValue.SectionCodeSt = code;
                        }
                        else
                        {
                            _prevInputValue.SectionCodeEd = code;
                        }
                        return true;
                    }
                    else
                    {
                        if (stFlg)
                        {
                            code = _prevInputValue.SectionCodeSt;
                        }
                        else
                        {
                            code = _prevInputValue.SectionCodeEd;
                        }
                        return false;
                    }
                    //code = sectionInfo.SectionCode.TrimEnd();
                    //if (stFlg)
                    //{
                    //    _prevInputValue.SectionCodeSt = code;
                    //}
                    //else
                    //{
                    //    _prevInputValue.SectionCodeEd = code;
                    //}
                    //return true;
                    // --------------- UPD 2010/09/20 ------------<<<<<
                }
                else
                {
                    if (stFlg)
                    {
                        code = _prevInputValue.SectionCodeSt;
                    }
                    else
                    {
                        code = _prevInputValue.SectionCodeEd;
                    }
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = code;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = code;
                }
                return true;
            }
        }

        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="code">検索取得SelectionCode</param>
        /// <param name="inputValue">画面SelectionCode</param>
        /// <param name="stFlg">画面開始コード、終了コード</param>
        /// <param name="totalDiv">区分</param>
        /// <returns>true、false</returns>
        /// <br>Note       : 名称取得処理です。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            ・障害ID:13021 テキスト出力対応</br>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            ・テキスト出力対応</br>
        // ------------ UPD 2010/09/21 ----------------------------------------------------->>>>>
        //private bool ReadCustomerName(out int code, int inputValue, bool stFlg, int totalDiv)
        private bool ReadCustomerName(out string code, int inputValue, bool stFlg, int totalDiv)
        // ------------ UPD 2010/09/21 -----------------------------------------------------<<<<<
        {
            int customerCode = inputValue;
            code = customerCode.ToString();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (stFlg)
            {
                if (_prevInputValue.SelectionCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.SelectionCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode > 0)
            {
                if (totalDiv == 1)
                {
                    CustomerInfo customerInfo;
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        this._selectionName = customerInfo.Name;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                }
                // --- DEL 2010/08/12 障害ID:13021対応-------------------------------->>>>>
                //else if (totalDiv == 2 || totalDiv == 3 || totalDiv == 4)
                //{
                //    // 担当者・受注者・発行者
                //    EmployeeAcs employeeAcs = new EmployeeAcs();
                //    Employee employee;
                //    status = employeeAcs.Read(out employee, this._enterpriseCode, inputValue.ToString());
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        this._selectionName = employee.Name;
                //    }
                //}
                // --- DEL 2010/08/12 障害ID:13021対応-------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stFlg)
                    {
                        _prevInputValue.SelectionCodeSt = customerCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.SelectionCodeEd = customerCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeSt); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeSt; // ADD 2010/09/21
                    }
                    else
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeEd); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeEd; // ADD 2010/09/21
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SelectionCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.SelectionCodeEd = customerCode.ToString();
                }
                return true;
            }
        }
        // --- ADD 2010/08/12 障害ID:13021対応-------------------------------->>>>>
        /// <summary>
        /// 担当者名称取得
        /// </summary>
        /// <param name="code">検索取得SelectionCode</param>
        /// <param name="inputValue">画面SelectionCode</param>
        /// <param name="stFlg">画面開始コード、終了コード</param>
        /// <returns>true、false</returns>
        /// <br>Note       : 名称取得処理です。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/12</br>
        private bool ReadEmployee(out string code, string inputValue, bool stFlg)
        {
            string customerCode = inputValue;
            code = customerCode;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (stFlg)
            {
                if (_prevInputValue.SelectionCodeSt == customerCode) return true;
            }
            else
            {
                if (_prevInputValue.SelectionCodeEd == customerCode) return true;
            }

            if (customerCode != string.Empty)
            {
                // 担当者・受注者・発行者
                EmployeeAcs employeeAcs = new EmployeeAcs();
                Employee employee;
                status = employeeAcs.Read(out employee, this._enterpriseCode, inputValue);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ------- UPD 2010/09/20 ----------------------------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    if (employee.LogicalDeleteCode == 0)
                    {
                        this._selectionName = employee.Name;
                        if (stFlg)
                        {
                            _prevInputValue.SelectionCodeSt = customerCode;
                        }
                        else
                        {
                            _prevInputValue.SelectionCodeEd = customerCode;
                        }
                        return true;
                    }
                    else
                    {
                        if (stFlg)
                        {
                            code = _prevInputValue.SelectionCodeSt;
                        }
                        else
                        {
                            code = _prevInputValue.SelectionCodeEd;
                        }
                        return false;
                    }
                    //this._selectionName = employee.Name;
                    //if (stFlg)
                    //{
                    //    _prevInputValue.SelectionCodeSt = customerCode;
                    //}
                    //else
                    //{
                    //    _prevInputValue.SelectionCodeEd = customerCode;
                    //}
                    //return true;
                    // ------- UPD 2010/09/20 -----------------------------<<<<<  
                }
                else
                {
                    if (stFlg)
                    {
                        code = _prevInputValue.SelectionCodeSt;
                    }
                    else
                    {
                        code = _prevInputValue.SelectionCodeEd;
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SelectionCodeSt = customerCode;
                }
                else
                {
                    _prevInputValue.SelectionCodeEd = customerCode;
                }
                return true;
            }
        }
        // --- ADD 2010/08/12 障害ID:13021対応--------------------------------<<<<<
        /// <summary>
        /// 地区業種取得
        /// </summary>
        /// <param name="code">検索取得SelectionCode</param>
        /// <param name="inputValue">画面SelectionCode</param>
        /// <param name="stFlg">画面開始コード、終了コード</param>
        /// <param name="totalDiv">区分</param>
        /// <param name="userGuideDivCd">区分</param>
        /// <returns>true、false</returns>
        /// <br>Note       : 地区業種取得処理です。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/20 tianjw</br>
        /// <br>            ・テキスト出力対応</br>
        // ------------ UPD 2010/09/21 ------------------------------------------------------------->>>>>
        //private bool ReadSelectionName(out int code, int inputValue, bool stFlg, int userGuideDivCd)
        private bool ReadSelectionName(out string code, int inputValue, bool stFlg, int userGuideDivCd)
        // ------------ UPD 2010/09/21 -------------------------------------------------------------<<<<<
        {
            int customerCode = inputValue;
            //code = customerCode; // DEL 2010/09/21
            code = customerCode.ToString(); // ADD 2010/09/21
            bool chkflg = false;

            if (stFlg)
            {
                if (_prevInputValue.SelectionCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.SelectionCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode >= 0)
            {
                UserGuideAcs _userGuideAcs = new UserGuideAcs();
                UserGdHd userGdHd = new UserGdHd();
                ArrayList userGdBdList = new ArrayList();
                int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UserGdBd userGdBd in userGdBdList)
                    {
                        // ---------- UPD 2010/09/21 ----------------------------------------------------->>>>>
                        //if ((userGdBd.UserGuideDivCd == userGuideDivCd) && (userGdBd.GuideCode == code))
                        if ((userGdBd.UserGuideDivCd == userGuideDivCd) && (userGdBd.GuideCode == Convert.ToInt32(code)))
                        // ---------- UPD 2010/09/21 -----------------------------------------------------<<<<<
                        {
                            this._selectionName = userGdBd.GuideName;
                            chkflg = true;
                            break;
                        }
                    }
                    if (chkflg)
                    {
                        if (stFlg)
                        {
                            _prevInputValue.SelectionCodeSt = customerCode.ToString();
                        }
                        else
                        {
                            _prevInputValue.SelectionCodeEd = customerCode.ToString();
                        }
                        return true;
                    }
                    else
                    {
                        if (stFlg)
                        {
                            //code = Convert.ToInt32(_prevInputValue.SelectionCodeSt); // DEL 2010/09/21
                            code = _prevInputValue.SelectionCodeSt; // ADD 2010/09/21
                        }
                        else
                        {
                            //code = Convert.ToInt32(_prevInputValue.SelectionCodeEd); // DEL 2010/09/21
                            code = _prevInputValue.SelectionCodeEd; // ADD 2010/09/21
                        }
                        return false;
                    }
  
                }
                else
                {
                    if (stFlg)
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeSt); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeSt; // ADD 2010/09/21
                    }
                    else
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeEd); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeEd; // ADD 2010/09/21
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SelectionCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.SelectionCodeEd = customerCode.ToString();
                }
                return true;
            }
        }


        /// <summary>
        /// 前回値保持
        /// </summary>
        /// <remarks>
        /// <br>Note       : 前回値保持処理します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/16</br>
        /// </remarks>
        private struct PrevInputValue
        {
            /// <summary>開始拠点コード</summary>
            private string _sectionCodeSt;
            /// <summary>終了拠点コード</summary>
            private string _sectionCodeEd;
            /// <summary>開始SelectionCode</summary>
            private string _selectionCodeSt;
            /// <summary>終了SelectionCode</summary>
            private string _selectionCodeEd;

            /// <summary>開始拠点コード</summary>
            public string SectionCodeSt
            {
                get { return _sectionCodeSt; }
                set { _sectionCodeSt = value; }
            }

            /// <summary>終了拠点コード</summary>
            public string SectionCodeEd
            {
                get { return _sectionCodeEd; }
                set { _sectionCodeEd = value; }
            }

            /// <summary>開始仕入先コード</summary>
            public string SelectionCodeSt
            {
                get { return _selectionCodeSt; }
                set { _selectionCodeSt = value; }
            }

            /// <summary>終了仕入先コード</summary>
            public string SelectionCodeEd
            {
                get { return _selectionCodeEd; }
                set { _selectionCodeEd = value; }
            }
        }

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            DCHNB04180UC userSettingFrm = new DCHNB04180UC();
            userSettingFrm.AnalysisChartSettingAcs.Deserialize();
            switch(this.tComboEditor_TotalDiv1.SelectedIndex)
            {
                case 0:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SectionFileNameValue;
                        break;
                    }
                case 1:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.CustomerFileNameValue;
                        break;
                    }
                case 2:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SalesEmployeeFileNameValue;
                        break;
                    }
                case 3:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.FrontEmployeeFileNameValue;
                        break;
                    }
                case 4:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SalesInputFileNameValue;
                        break;
                    }
                case 5:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SalesAreaFileNameValue;
                        break;
                    }
                case 6:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.BusinessTypeFileNameValue;
                        break;
                    }
                case 7:
                    {
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (this._excelFlg)
                {
                    // 拡張子をXLSにする
                    fileName += ".xls";
                }
                else
                {
                    // 拡張子をCSVにする
                    fileName += ".CSV";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }

        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/09 楊明俊</br>
        /// <br>            ・障害ID:13278 PM1010Fテキスト出力対応</br>
        /// <br>Update Note: 2024/11/29 陳艶丹</br>
        /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private void SetExtratConst()
        {
            // 対象拠点コード
            List<string[]> sectionCodeList = new List<string[]>();
            // SelectionCodeリスト
            List<string[]> selectionCodeList = new List<string[]>();
            //string selectName = null; // DEL 2010/08/30

            // 拠点の取得
            // ---------------- UPD 2010/09/19 ----------------------------------------------->>>>>
            //if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt())
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt() ||
                this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
            // ---------------- UPD 2010/09/19 -----------------------------------------------<<<<<
            {
                // ---------------- UPD 2010/09/19 ----------------------->>>>>
                //if (this.tNedit_SectionCodeSt.GetInt() == 0)
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                // ---------------- UPD 2010/09/19 -----------------------<<<<<
                {
                    // 全社指定
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    ArrayList relList = new ArrayList();
                    int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in relList)
                        {
                            // --------------- UPD 2010/09/19 -------------------------------------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeEd.GetInt() == 0 && this.tNedit_SectionCodeSt.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0)
                            {
                                // 全社指定
                                string[] sectionArr = new string[2];
                                sectionArr[0] = sectionInfo.SectionCode;
                                //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                sectionCodeList.Add(sectionArr);
                            }
                            //string[] sectionArr = new string[2];
                            //sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm;
                            //sectionCodeList.Add(sectionArr);
                            // --------------- UPD 2010/09/19 --------------------------------------------------<<<<<

                        }
                    }
                }
                else
                {
                    string[] sectionArr = new string[2];
                    sectionArr[0] = this.tNedit_SectionCodeSt.Text;
                    if (!string.IsNullOrEmpty(this._sectionName))
                    {
                        sectionArr[1] = this._sectionName;
                    }
                    else
                    {
                        // 拠点情報を取得
                        SecInfoSet sectionInfo;
                        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tNedit_SectionCodeSt.Text);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                            sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09

                        }
                    }
                    
                    sectionCodeList.Add(sectionArr);
                }
            }
            else
            {
                // --- UPD 2010/09/20 ---------->>>>>
                //string code;
                //SecInfoSet sectionInfo;
                //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                //int status = 0;

                //for (int i = this.tNedit_SectionCodeSt.GetInt(); i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                //{
                //    code = i.ToString();
                //    code = code.Trim().PadLeft(2, '0');
                //    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        //-----ADD 2010/09/09---------->>>>>
                //        if (sectionInfo.LogicalDeleteCode != 0)
                //        {
                //            continue;
                //        }
                //        //-----ADD 2010/09/09----------<<<<<
                //        string[] sectionArr = new string[2];
                //        sectionArr[0] = code;
                //        sectionArr[1] = sectionInfo.SectionGuideNm;
                //        sectionCodeList.Add(sectionArr);
                //    }
                //}
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                ArrayList relList = new ArrayList();
                int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet sectionInfo in relList)
                    {
                        if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode) && this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode))
                        {
                            string[] sectionArr = new string[2];
                            sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                            sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                            sectionCodeList.Add(sectionArr);
                        }
                    }
                }
                // --- UPD 2010/09/20 ----------<<<<<
            }
            this._sectionCodeList = sectionCodeList;

            // --- DEL 2010/08/25 -------------------------------->>>>>
            // SelectionCodeの取得
            //if (this.tNedit_SelectionCode_St.GetInt() == this.tNedit_SelectionCode_Ed.GetInt())
            //{
            //    if (this.tNedit_SelectionCode_St.GetInt() == 0)
            //    {
            //        // SelectionCode全取得
            //        this.GetALLSelectionCodeList(out selectionCodeList, this.tComboEditor_TotalDiv1.SelectedIndex);
            //    }
            //    else
            //    {
            //        string[] selectionArray = new string[2];
            //        selectionArray[0] = this.tNedit_SelectionCode_St.Text;
            //        if (!string.IsNullOrEmpty(this._selectionName))
            //        {
            //            selectionArray[1] = this._selectionName;
            //        }
            //        else
            //        {
            //            this.GetSelectionName(out selectName, this.tNedit_SelectionCode_St.Text, this.tComboEditor_TotalDiv1.SelectedIndex);
            //            selectionArray[1] = _selectionName;
            //        }
            //        selectionCodeList.Add(selectionArray);
            //    }
            //}
            //else
            //{
            //    this.GetSelectionCodeList(out selectionCodeList, this.tNedit_SelectionCode_St.Text, this.tNedit_SelectionCode_Ed.Text, this.tComboEditor_TotalDiv1.SelectedIndex);
            //}
            //this._selectionCodeList = selectionCodeList;
            // --- DEL 2010/08/25 --------------------------------<<<<<

            this._ed_selectionCode = this.tNedit_SelectionCode_Ed.Text.Trim();

            this._st_selectionCode = this.tNedit_SelectionCode_St.Text.Trim();

            // 集計区分
            this._totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;
            // 対象年度
            this._financialYear = this.tDateEdit_FinancialYear.GetDateYear();
            // 出力ファイル名
            this._settingFileName = this.tEdit_SettingFileName.Text;
            //検索区分
            this.SearDiv = 1; // ADD 2010/08/25
            //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // 開始拠点コード「ログオペレーションデータ」
            SectionCodeSt = this.tNedit_SectionCodeSt.Text.Trim();
            // 終了拠点コード「ログオペレーションデータ」
            SectionCodeEd = this.tNedit_SectionCodeEd.Text.Trim();
            //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        }

        /// <summary>
        /// SelectionCode全取得
        /// </summary>
        /// <param name="selectionCodeList">SelectionCodeリスト</param>
        /// <param name="totalDiv">集計区分</param>
        /// <br>Note       : SelectionCode全取得処理を行う。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void GetALLSelectionCodeList(out List<string[]> selectionCodeList, int totalDiv)
        {
            selectionCodeList = new List<string[]>();
            switch (totalDiv)
            {
                case 1:
                    {
                        // 得意先
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            string[] customerArray = new string[2];
                            customerArray[0] = ret.CustomerCode.ToString();
                            customerArray[1] = ret.Name;
                            selectionCodeList.Add(customerArray);
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        // 担当者・受注者・発行者
                        EmployeeAcs employeeAcs = new EmployeeAcs();
                        ArrayList retList;
                        ArrayList retList2;
                        int status = employeeAcs.Search(out retList, out retList2, this._enterpriseCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (Employee employee in retList)
                            {
                                if (employee.LogicalDeleteCode == 0)
                                {
                                    string[] employeeArray = new string[2];
                                    employeeArray[0] = employee.EmployeeCode;
                                    employeeArray[1] = employee.Name;
                                    selectionCodeList.Add(employeeArray);
                                }
                            }
                        }
                        break;
                    }
                case 5:
                case 6:
                    {
                        UserGuideAcs _userGuideAcs = new UserGuideAcs();
                        UserGdHd userGdHd = new UserGdHd();
                        ArrayList userGdBdList = new ArrayList();
                        int userGuideDivCd;
                        if (totalDiv == 5)
                        {
                            // 地区（販売エリア）
                            userGuideDivCd = 21;
                        }
                        else
                        {
                            // 業種
                            userGuideDivCd = 33;
                        }
                        int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData, userGuideDivCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (UserGdBd userGdBd in userGdBdList)
                            {
                                string[] userArray = new string[2];
                                userArray[0] = userGdBd.GuideCode.ToString();
                                userArray[1] = userGdBd.GuideName;
                                selectionCodeList.Add(userArray);
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// SelectionCode全取得
        /// </summary>
        /// <param name="selectionCodeList">SelectionCodeリスト</param>
        /// <param name="selectionCodeSt">SelectionCodeSt</param>
        /// <param name="selectionCodeEd">SelectionCodeEd</param>
        /// <param name="totalDiv">集計区分</param>
        /// <returns>bool</returns>
        /// <br>Note       : SelectionCode全取得処理を行う。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void GetSelectionCodeList(out List<string[]> selectionCodeList, string selectionCodeSt, string selectionCodeEd, int totalDiv)
        {
            selectionCodeList = new List<string[]>();
            switch (totalDiv)
            {
                case 1:
                    {
                        // 得意先
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                            {
                                string[] customerAyyary = new string[2];
                                customerAyyary[0] = ret.CustomerCode.ToString();
                                customerAyyary[1] = ret.Name;
                                selectionCodeList.Add(customerAyyary);
                            }
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        // 担当者・受注者・発行者
                        EmployeeAcs employeeAcs = new EmployeeAcs();
                        ArrayList retList;
                        ArrayList retList2;
                        int status = employeeAcs.Search(out retList, out retList2, this._enterpriseCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (Employee employee in retList)
                            {
                                if (employee.LogicalDeleteCode == 0)
                                {
                                    if (employee.EmployeeCode.CompareTo(selectionCodeSt) >= 0 && employee.EmployeeCode.CompareTo(selectionCodeEd) <= 0)
                                    {
                                        string[] employeeArray = new string[2];
                                        employeeArray[0] = employee.EmployeeCode;
                                        employeeArray[1] = employee.Name;
                                        selectionCodeList.Add(employeeArray);
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 5:
                case 6:
                    {
                        UserGuideAcs _userGuideAcs = new UserGuideAcs();
                        UserGdHd userGdHd = new UserGdHd();
                        ArrayList userGdBdList = new ArrayList();
                        int userGuideDivCd;
                        if (totalDiv == 5)
                        {
                            // 地区（販売エリア）
                            userGuideDivCd = 21;
                        }
                        else
                        {
                            // 業種
                            userGuideDivCd = 33;
                        }
                        int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData, userGuideDivCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (UserGdBd userGdBd in userGdBdList)
                            {
                                if (userGdBd.GuideCode >= Convert.ToInt32(selectionCodeSt) && userGdBd.GuideCode <= Convert.ToInt32(selectionCodeEd))
                                {
                                    string[] userArray = new string[2];
                                    userArray[0] = userGdBd.GuideCode.ToString();
                                    userArray[1] = userGdBd.GuideName;
                                    selectionCodeList.Add(userArray);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// SelectionName取得
        /// </summary>
        /// <param name="selectionName">SelectionName</param>
        /// <param name="selectionCode">SelectionCode</param>
        /// <param name="totalDiv">集計区分</param>
        /// <br>Note       : SelectionName取得取得処理を行う。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        private void GetSelectionName(out string selectName, string selectionCode, int totalDiv)
        {
            selectName = null;
            switch (totalDiv)
            {
                case 1:
                    {
                        // 得意先
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            if (ret.CustomerCode == Convert.ToInt64(selectionCode))
                            {
                                selectName = ret.Name;
                                break;

                            }
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        // 担当者・受注者・発行者
                        EmployeeAcs employeeAcs = new EmployeeAcs();
                        ArrayList retList;
                        ArrayList retList2;
                        int status = employeeAcs.Search(out retList, out retList2, this._enterpriseCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (Employee employee in retList)
                            {
                                if (employee.LogicalDeleteCode == 0)
                                {
                                    if (employee.EmployeeCode == selectionCode)
                                    {
                                        selectName = employee.Name;
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 5:
                case 6:
                    {
                        UserGuideAcs _userGuideAcs = new UserGuideAcs();
                        UserGdHd userGdHd = new UserGdHd();
                        ArrayList userGdBdList = new ArrayList();
                        int userGuideDivCd;
                        if (totalDiv == 5)
                        {
                            // 地区（販売エリア）
                            userGuideDivCd = 21;
                        }
                        else
                        {
                            // 業種
                            userGuideDivCd = 33;
                        }
                        int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData, userGuideDivCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (UserGdBd userGdBd in userGdBdList)
                            {
                                if (userGdBd.GuideCode == Convert.ToInt64(selectionCode))
                                {
                                    selectName = userGdBd.GuideName;
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }
        }
        #endregion

        /// <summary>
        /// tComboEditor中の値を変化する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : tComboEditor中の値を変化する処理。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2010/09/21</br>
        private void tComboEditor_TotalDiv1_ValueChanged(object sender, EventArgs e)
        {
            this._prevInputValue.SelectionCodeSt = string.Empty;
            this._prevInputValue.SelectionCodeEd = string.Empty;
        }
    }
}
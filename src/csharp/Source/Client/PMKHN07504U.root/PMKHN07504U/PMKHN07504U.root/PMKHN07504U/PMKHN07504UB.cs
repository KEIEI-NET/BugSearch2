using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;



namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ユーザー設定画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザー設定情報を入力します。</br>
    /// <br>Programmer : 980035 金沢　貞義</br>
    /// <br>Date       : 2010.05.25</br>
    /// </remarks>
    public partial class PMKHN07504UB : Form
    {
        #region Constructor
        /// <summary>
        /// ユーザー設定画面クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー設定画面クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public PMKHN07504UB()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;

            this._analysisMailSettingAcs = new AnalysisMailSettingAcs();

            this._mailInfoBase = new MailInfoBase(MailServiceInfoCreateMode.Default);
        }
        #endregion

        #region Private Members
        private ImageList _imageList16 = null;
        private AnalysisMailSettingAcs _analysisMailSettingAcs = null;
        private MailInfoBase _mailInfoBase;
        #endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
		/// </remarks>
		private void PMKHN07504UB_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;
            this.ub_EmployeeGuide.ImageList                             = this._imageList16;
			this.Ok_ultraButton.Appearance.Image						= Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image					= Size16_Index.BEFORE;
            this.ub_EmployeeGuide.Appearance.Image                      = Size16_Index.STAR1;

            // 宛名初期値
            this.AddressInitialDivValue.Value = this._analysisMailSettingAcs.AddressInitialDivValue;
            this.AddressInitialDivValue.FocusedIndex = this.AddressInitialDivValue.CheckedIndex;
            // 宛名初期値（任意名称）
            this.tEdit_EmployeeName.Value = this._analysisMailSettingAcs.AddressInitialNameValue;
            // 件名初期値
            this.SubjectInitialDivValue.Value = this._analysisMailSettingAcs.SubjectInitialDivValue;
            this.SubjectInitialDivValue.FocusedIndex = this.SubjectInitialDivValue.CheckedIndex;
            // 件名初期値（任意）
            this.SubjectInitialValue.Value = this._analysisMailSettingAcs.SubjectInitialValue;
            // CC設定（本社）
            this.uCheckEditor_CompanyCCDivValue.Checked = this._analysisMailSettingAcs.CompanyCCDivValue;
            // 署名設定
            this.uCheckEditor_SignatureDisplayDivValue.Checked = this._analysisMailSettingAcs.SignatureDisplayDivValue;
            // 署名初期値
            this.richTextBox_SignatureInitialValue.Text = this._analysisMailSettingAcs.SignatureInitialValue;
            // 入力可能最大文字数
            this.tNedit_MailDocMaxSizeValue.Value = this._analysisMailSettingAcs.MailDocMaxSizeValue;
            // 入力可能最大文字数（１行）
            this.tNedit_MailLineStrMaxSizeValue.Value = this._analysisMailSettingAcs.MailLineStrMaxSizeValue;

            // 取込_得意先
            this.uCheckEditor_CustomerDiv.Checked = this._analysisMailSettingAcs.CustomerDiv;
            // 取込_伝票番号
            this.uCheckEditor_SalesSlipNumDiv.Checked = this._analysisMailSettingAcs.SalesSlipNumDiv;
            // 取込_伝票種別
            this.uCheckEditor_AcptAnOdrStatusDiv.Checked = this._analysisMailSettingAcs.AcptAnOdrStatusDiv;
            // 取込_売上日
            this.uCheckEditor_SalesDateDiv.Checked = this._analysisMailSettingAcs.SalesDateDiv;
            // 取込_種別
            this.uCheckEditor_CategoryNoDiv.Checked = this._analysisMailSettingAcs.CategoryNoDiv;
            // 取込_型式
            this.uCheckEditor_FullModelDiv.Checked = this._analysisMailSettingAcs.FullModelDiv;
            // 取込_車種
            this.uCheckEditor_ModelCodeDiv.Checked = this._analysisMailSettingAcs.ModelCodeDiv;
            // 取込_BLコード
            this.uCheckEditor_BLGoodsCodeDiv.Checked = this._analysisMailSettingAcs.BLGoodsCodeDiv;
            // 取込_品名
            this.uCheckEditor_GoodsNameDiv.Checked = this._analysisMailSettingAcs.GoodsNameDiv;
            // 取込_品番
            this.uCheckEditor_GoodsNoDiv.Checked = this._analysisMailSettingAcs.GoodsNoDiv;
            // 取込_メーカー
            this.uCheckEditor_GoodsMakerDiv.Checked = this._analysisMailSettingAcs.GoodsMakerDiv;
            // 取込_出荷数
            this.uCheckEditor_ShipmentCntDiv.Checked = this._analysisMailSettingAcs.ShipmentCntDiv;
            // 取込_標準価格
            this.uCheckEditor_PriceDiv.Checked = this._analysisMailSettingAcs.PriceDiv;
            // 取込_売単価
            this.uCheckEditor_SalesMoneyDiv.Checked = this._analysisMailSettingAcs.SalesMoneyDiv;
        }

		/// <summary>
		/// UltraButton.Click イベント（Ok_ultraButton）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : コントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
            // 宛名初期値
            this._analysisMailSettingAcs.AddressInitialDivValue = (int)this.AddressInitialDivValue.Value;
            // 宛名初期値（任意名称）
            this._analysisMailSettingAcs.AddressInitialNameValue = (string)this.tEdit_EmployeeName.Value;
            // 件名初期値
            this._analysisMailSettingAcs.SubjectInitialDivValue = (int)this.SubjectInitialDivValue.Value;
            // 件名初期値（任意）
            this._analysisMailSettingAcs.SubjectInitialValue = (string)this.SubjectInitialValue.Value;
            // CC設定（本社）
            this._analysisMailSettingAcs.CompanyCCDivValue = (bool)this.uCheckEditor_CompanyCCDivValue.Checked;
            // 署名設定
            this._analysisMailSettingAcs.SignatureDisplayDivValue = (bool)this.uCheckEditor_SignatureDisplayDivValue.Checked;
            // 署名初期値
            this._analysisMailSettingAcs.SignatureInitialValue = (string)this.richTextBox_SignatureInitialValue.Text;
            // 入力可能最大文字数
            this._analysisMailSettingAcs.MailDocMaxSizeValue = this.tNedit_MailDocMaxSizeValue.GetInt();
            // 入力可能最大文字数（１行）
            this._analysisMailSettingAcs.MailLineStrMaxSizeValue = this.tNedit_MailLineStrMaxSizeValue.GetInt();

            // 取込_得意先
            this._analysisMailSettingAcs.CustomerDiv = this.uCheckEditor_CustomerDiv.Checked;
            // 取込_伝票番号
            this._analysisMailSettingAcs.SalesSlipNumDiv = this.uCheckEditor_SalesSlipNumDiv.Checked;
            // 取込_伝票種別
            this._analysisMailSettingAcs.AcptAnOdrStatusDiv = this.uCheckEditor_AcptAnOdrStatusDiv.Checked;
            // 取込_売上日
            this._analysisMailSettingAcs.SalesDateDiv = this.uCheckEditor_SalesDateDiv.Checked;
            // 取込_種別
            this._analysisMailSettingAcs.CategoryNoDiv = this.uCheckEditor_CategoryNoDiv.Checked;
            // 取込_型式
            this._analysisMailSettingAcs.FullModelDiv = this.uCheckEditor_FullModelDiv.Checked;
            // 取込_車種
            this._analysisMailSettingAcs.ModelCodeDiv = this.uCheckEditor_ModelCodeDiv.Checked;
            // 取込_BLコード
            this._analysisMailSettingAcs.BLGoodsCodeDiv = this.uCheckEditor_BLGoodsCodeDiv.Checked;
            // 取込_品名
            this._analysisMailSettingAcs.GoodsNameDiv = this.uCheckEditor_GoodsNameDiv.Checked;
            // 取込_品番
            this._analysisMailSettingAcs.GoodsNoDiv = this.uCheckEditor_GoodsNoDiv.Checked;
            // 取込_メーカー
            this._analysisMailSettingAcs.GoodsMakerDiv = this.uCheckEditor_GoodsMakerDiv.Checked;
            // 取込_出荷数
            this._analysisMailSettingAcs.ShipmentCntDiv = this.uCheckEditor_ShipmentCntDiv.Checked;
            // 取込_標準価格
            this._analysisMailSettingAcs.PriceDiv = this.uCheckEditor_PriceDiv.Checked;
            // 取込_売単価
            this._analysisMailSettingAcs.SalesMoneyDiv = this.uCheckEditor_SalesMoneyDiv.Checked;

            this._analysisMailSettingAcs.Serialize();
		}

        #region 区分変更 イベント
        /// <summary>
        /// 宛先変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void AddressInitialDivValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.AddressInitialDivValue.CheckedIndex == 2)
            {
                this.tEdit_EmployeeName.Enabled = true;
                this.ub_EmployeeGuide.Enabled = true;
            }
            else
            {
                this.tEdit_EmployeeName.Enabled = false;
                this.ub_EmployeeGuide.Enabled = false;
            }
        }

        /// <summary>
        /// 宛先変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void SubjectInitialDivValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.SubjectInitialDivValue.CheckedIndex == 1)
            {
                this.SubjectInitialValue.Enabled = true;
            }
            else
            {
                this.SubjectInitialValue.Enabled = false;
            }
        }
        #endregion

        #region 担当者入力 イベント
        private void tEdit_EmployeeName_Leave(object sender, EventArgs e)
        {
            string code = this.tEdit_EmployeeName.Text.Trim();
            string name = this.tEdit_EmployeeName.Text.Trim();
            int codeInt;

            #region マスタ読込
            if ((code != "") &&
                (code.Length <= 4) &&
                (Int32.TryParse(code, out codeInt) == true))
            {
                // 従業員マスタ
                Employee employee;
                EmployeeDtl employeeDtl;
                int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, codeInt.ToString("0000"));

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._analysisMailSettingAcs.AddressInitialCodeValue = employee.EmployeeCode.Trim();
                    this._analysisMailSettingAcs.AddressInitialMailValue = employeeDtl.MailAddress2;
                    this.tEdit_EmployeeName.Value = employee.Name.Trim();
                    if (employeeDtl.MailAddress2 == string.Empty)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "携帯用メールアドレスが設定されていません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "担当者が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this._analysisMailSettingAcs.AddressInitialCodeValue = string.Empty;
                    this._analysisMailSettingAcs.AddressInitialMailValue = string.Empty;
                    this.tEdit_EmployeeName.Value = string.Empty;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "担当者の取得に失敗しました。",
                        status,
                        MessageBoxButtons.OK);

                    this._analysisMailSettingAcs.AddressInitialCodeValue = string.Empty;
                    this._analysisMailSettingAcs.AddressInitialMailValue = string.Empty;
                    this.tEdit_EmployeeName.Value = string.Empty;
                }
            }
            #endregion
        }
        #endregion

        #region ガイドボタン イベント
        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ub_EmployeeGuide_Click(object sender, EventArgs e)
        {
            Employee employee;
            EmployeeDtl employeeDtl;

            // 従業員マスタ読込
            int status = _mailInfoBase.GetEmployeeGuid(out employee, out employeeDtl);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._analysisMailSettingAcs.AddressInitialCodeValue = employee.EmployeeCode.Trim();
                this._analysisMailSettingAcs.AddressInitialMailValue = employeeDtl.MailAddress2;
                this.tEdit_EmployeeName.Value = employee.Name.Trim();
                if (employeeDtl.MailAddress2 == string.Empty)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "携帯用メールアドレスが設定されていません。",
                        -1,
                        MessageBoxButtons.OK);
                }
            }
        }
        #endregion

        #region ChangeFocus イベント
        /// <summary>
        /// tRetKeyControl1_ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //署名文書の場合
            if (e.PrevCtrl == this.richTextBox_SignatureInitialValue)
            {
                //エディタ内でEnterKeyが押された場合
                if (e.Key == Keys.Enter)
                {
                    //改行文字を挿入します
                    this.richTextBox_SignatureInitialValue.SelectedText += System.Environment.NewLine;
                    this.richTextBox_SignatureInitialValue.AcceptsTab = true;
                    e.NextCtrl = null;
                }
                //エディタ内で TabKeyが押された場合
                else if (e.Key == Keys.Tab)
                {
                    //タブを挿入
                    this.richTextBox_SignatureInitialValue.SelectedText += "\t";
                    e.NextCtrl = null;
                }
            }
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 表示設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : シリアル化する表示設定クラスです。</br>
    /// <br>Programmer : 980035 金沢　貞義</br>
    /// <br>Date       : 2010.05.25</br>
    /// </remarks>
    [Serializable]
    public class AnalysisMailSetting
    {
        #region Constructor
        /// <summary>
        /// 表示設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public AnalysisMailSetting()
        {
            this._addressInitialDivValue = DEFAULT_ADDRESSINITIALDIV_VALUE;
            this._addressInitialCodeValue = DEFAULT_ADDRESSINITIALCODE_VALUE;
            this._addressInitialNameValue = DEFAULT_ADDRESSINITIALNAME_VALUE;
            this._addressInitialNameValue = DEFAULT_ADDRESSINITIALMAIL_VALUE;
            this._subjectInitialDivValue = DEFAULT_SUBJECTINITIALDIV_VALUE;
            this._subjectInitialValue = DEFAULT_SUBJECTINITIAL_VALUE;
            this._companyCCDivValue = DEFAULT_COMPANYCCDIV_VALUE;
            this._signatureDisplayDivValue = DEFAULT_SIGNATUREDISPLAYDIV_VALUE;
            this._signatureInitialValue = DEFAULT_SIGNATUREINITIAL_VALUE;
            this._mailDocMaxSizeValue = DEFAULT_MAILDOCMAXSIZE_VALUE;
            this._mailLineStrMaxSizeValue = DEFAULT_MAILLINESTRMAXSIZE_VALUE;

            this._customerDiv = DEFAULT_CUSTOMERDIV_VALUE;
            this._salesSlipNumDiv = DEFAULT_SALESSLIPNUMDIV_VALUE;
            this._acptAnOdrStatusDiv = DEFAULT_ACPTANODRSTATUSDIV_VALUE;
            this._salesDateDiv = DEFAULT_SALESDATEDIV_VALUE;
            this._categoryNoDiv = DEFAULT_CATEGORYNODIV_VALUE;
            this._fullModelDiv = DEFAULT_FULLMODELDIV_VALUE;
            this._modelCodeDiv = DEFAULT_MODELCODEDIV_VALUE;
            this._blGoodsCodeDiv = DEFAULT_BLGOODSCODEDIV_VALUE;
            this._goodsNameDiv = DEFAULT_GOODSNAMEDIV_VALUE;
            this._goodsNoDiv = DEFAULT_GOODSNODIV_VALUE;
            this._goodsMakerDiv = DEFAULT_GOODSMAKERDIV_VALUE;
            this._shipmentCntDiv = DEFAULT_SHIPMENTCNTDIV_VALUE;
            this._priceDiv = DEFAULT_PRICEDIV_VALUE;
            this._salesMoneyDiv = DEFAULT_SALESMONEYDIV_VALUE;
        }

        /// <summary>
        /// 表示設定クラスコンストラクタ
        /// </summary>
        /// <param name="addressInitialDivValue"></param>
        /// <param name="addressInitialCodeValue"></param>
        /// <param name="addressInitialNameValue"></param>
        /// <param name="addressInitialMailValue"></param>
        /// <param name="subjectInitialDivValue"></param>
        /// <param name="subjectInitialValue"></param>
        /// <param name="companyCCDivValue"></param>
        /// <param name="signatureDisplayDivValue"></param>
        /// <param name="signatureInitialValue"></param>
        /// <param name="mailDocMaxSizeValue"></param>
        /// <param name="mailLineStrMaxSizeValue"></param>
        /// <remarks>
        /// <br>Note       : 表示設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public AnalysisMailSetting(int addressInitialDivValue, string addressInitialCodeValue, string addressInitialNameValue, string addressInitialMailValue, int subjectInitialDivValue, string subjectInitialValue, bool companyCCDivValue, bool signatureDisplayDivValue, string signatureInitialValue, int mailDocMaxSizeValue, int mailLineStrMaxSizeValue)
        {
            this._addressInitialDivValue    = addressInitialDivValue;
            this._addressInitialCodeValue   = addressInitialCodeValue;
            this._addressInitialNameValue   = addressInitialNameValue;
            this._addressInitialMailValue   = addressInitialMailValue;
            this._subjectInitialDivValue    = subjectInitialDivValue;
            this._subjectInitialValue       = subjectInitialValue;
            this._companyCCDivValue         = companyCCDivValue;
            this._signatureDisplayDivValue  = signatureDisplayDivValue;
            this._signatureInitialValue     = signatureInitialValue;
            this._mailDocMaxSizeValue       = mailDocMaxSizeValue;
            this._mailLineStrMaxSizeValue   = mailLineStrMaxSizeValue;
        }
        #endregion

        #region Private Member

        /// <summary>宛名初期値</summary>
        private int _addressInitialDivValue;
        /// <summary>宛名初期値（任意コード）</summary>
        private string  _addressInitialCodeValue;
        /// <summary>宛名初期値（任意名称）</summary>
        private string _addressInitialNameValue;
        /// <summary>宛名初期値（任意メールアドレス）</summary>
        private string _addressInitialMailValue;
        /// <summary>件名初期値</summary>
        private int _subjectInitialDivValue;
        /// <summary>件名初期値（任意）</summary>
        private string _subjectInitialValue;
        /// <summary>CC設定（本社）</summary>
        private bool _companyCCDivValue;
        /// <summary>署名設定</summary>
        private bool _signatureDisplayDivValue;
        /// <summary>署名初期値</summary>
        private string _signatureInitialValue;
        /// <summary>入力可能最大文字数</summary>
        private int _mailDocMaxSizeValue;
        /// <summary>入力可能最大文字数（１行）</summary>
        private int _mailLineStrMaxSizeValue;

        /// <summary>取込_得意先</summary>
        private bool _customerDiv;
        /// <summary>取込_伝票番号</summary>
        private bool _salesSlipNumDiv;
        /// <summary>取込_伝票種別</summary>
        private bool _acptAnOdrStatusDiv;
        /// <summary>取込_売上日</summary>
        private bool _salesDateDiv;
        /// <summary>取込_種別</summary>
        private bool _categoryNoDiv;
        /// <summary>取込_型式</summary>
        private bool _fullModelDiv;
        /// <summary>取込_車種</summary>
        private bool _modelCodeDiv;
        /// <summary>取込_BLコード</summary>
        private bool _blGoodsCodeDiv;
        /// <summary>取込_品名</summary>
        private bool _goodsNameDiv;
        /// <summary>取込_品番</summary>
        private bool _goodsNoDiv;
        /// <summary>取込_メーカー</summary>
        private bool _goodsMakerDiv;
        /// <summary>取込_出荷数</summary>
        private bool _shipmentCntDiv;
        /// <summary>取込_標準価格</summary>
        private bool _priceDiv;
        /// <summary>取込_売単価</summary>
        private bool _salesMoneyDiv;


        /// <summary>宛名初期値</summary>
        private const int DEFAULT_ADDRESSINITIALDIV_VALUE = 1;
        /// <summary>宛名初期値（任意）</summary>
        private const string DEFAULT_ADDRESSINITIALCODE_VALUE = "0000";
        /// <summary>宛名初期値（任意）</summary>
        private const string DEFAULT_ADDRESSINITIALNAME_VALUE = null;
        /// <summary>宛名初期値（任意メールアドレス）</summary>
        private const string DEFAULT_ADDRESSINITIALMAIL_VALUE = null;
        /// <summary>件名初期値</summary>
        private const int DEFAULT_SUBJECTINITIALDIV_VALUE = 0;
        /// <summary>件名初期値（任意）</summary>
        private const string DEFAULT_SUBJECTINITIAL_VALUE = null;
        /// <summary>CC設定（本社）</summary>
        private const bool DEFAULT_COMPANYCCDIV_VALUE = false;
        /// <summary>署名設定</summary>
        private const bool DEFAULT_SIGNATUREDISPLAYDIV_VALUE = true;
        /// <summary>署名初期値</summary>
        private const string DEFAULT_SIGNATUREINITIAL_VALUE = null;
        /// <summary>入力可能最大文字数</summary>
        private const int DEFAULT_MAILDOCMAXSIZE_VALUE = 0;
        /// <summary>入力可能最大文字数（１行）</summary>
        private const int DEFAULT_MAILLINESTRMAXSIZE_VALUE = 0;

        /// <summary>取込_得意先</summary>
        private bool DEFAULT_CUSTOMERDIV_VALUE = false;
        /// <summary>取込_伝票番号</summary>
        private bool DEFAULT_SALESSLIPNUMDIV_VALUE = false;
        /// <summary>取込_伝票種別</summary>
        private bool DEFAULT_ACPTANODRSTATUSDIV_VALUE = false;
        /// <summary>取込_売上日</summary>
        private bool DEFAULT_SALESDATEDIV_VALUE = false;
        /// <summary>取込_種別</summary>
        private bool DEFAULT_CATEGORYNODIV_VALUE = false;
        /// <summary>取込_型式</summary>
        private bool DEFAULT_FULLMODELDIV_VALUE = false;
        /// <summary>取込_車種</summary>
        private bool DEFAULT_MODELCODEDIV_VALUE = false;
        /// <summary>取込_BLコード</summary>
        private bool DEFAULT_BLGOODSCODEDIV_VALUE = false;
        /// <summary>取込_品名</summary>
        private bool DEFAULT_GOODSNAMEDIV_VALUE = false;
        /// <summary>取込_品番</summary>
        private bool DEFAULT_GOODSNODIV_VALUE = false;
        /// <summary>取込_メーカー</summary>
        private bool DEFAULT_GOODSMAKERDIV_VALUE = false;
        /// <summary>取込_出荷数</summary>
        private bool DEFAULT_SHIPMENTCNTDIV_VALUE = false;
        /// <summary>取込_標準価格</summary>
        private bool DEFAULT_PRICEDIV_VALUE = false;
        /// <summary>取込_売単価</summary>
        private bool DEFAULT_SALESMONEYDIV_VALUE = false;
        #endregion

        #region Propaty
        /// <summary>宛名初期値プロパティ</summary>
        public int AddressInitialDivValue
        {
            get { return this._addressInitialDivValue; }
            set { this._addressInitialDivValue = value; }
        }

        /// <summary>宛名初期値（任意コード）プロパティ</summary>
        public string AddressInitialCodeValue
        {
            get { return this._addressInitialCodeValue; }
            set { this._addressInitialCodeValue = value; }
        }

        /// <summary>宛名初期値（任意名称）プロパティ</summary>
        public string AddressInitialNameValue
        {
            get { return this._addressInitialNameValue; }
            set { this._addressInitialNameValue = value; }
        }

        /// <summary>宛名初期値（任意メールアドレス）プロパティ</summary>
        public string AddressInitialMailValue
        {
            get { return this._addressInitialMailValue; }
            set { this._addressInitialMailValue = value; }
        }

        /// <summary>件名初期値プロパティ</summary>
        public int SubjectInitialDivValue
        {
            get { return this._subjectInitialDivValue; }
            set { this._subjectInitialDivValue = value; }
        }

        /// <summary>件名初期値（任意）プロパティ</summary>
        public string SubjectInitialValue
        {
            get { return this._subjectInitialValue; }
            set { this._subjectInitialValue = value; }
        }

        /// <summary>CC設定（本社）プロパティ</summary>
        public bool CompanyCCDivValue
        {
            get { return this._companyCCDivValue; }
            set { this._companyCCDivValue = value; }
        }

        /// <summary>署名設定プロパティ</summary>
        public bool SignatureDisplayDivValue
        {
            get { return this._signatureDisplayDivValue; }
            set { this._signatureDisplayDivValue = value; }
        }

        /// <summary>署名初期値プロパティ</summary>
        public string SignatureInitialValue
        {
            get { return this._signatureInitialValue; }
            set { this._signatureInitialValue = value; }
        }

        /// <summary>入力可能最大文字数プロパティ</summary>
        public int MailDocMaxSizeValue
        {
            get { return this._mailDocMaxSizeValue; }
            set { this._mailDocMaxSizeValue = value; }
        }

        /// <summary>入力可能最大文字数（１行）プロパティ</summary>
        public int MailLineStrMaxSizeValue
        {
            get { return this._mailLineStrMaxSizeValue; }
            set { this._mailLineStrMaxSizeValue = value; }
        }

        /// <summary>取込_得意先プロパティ</summary>
        public bool CustomerDiv
        {
            get { return this._customerDiv; }
            set { this._customerDiv = value; }
        }

        /// <summary>取込_伝票番号プロパティ</summary>
        public bool SalesSlipNumDiv
        {
            get { return this._salesSlipNumDiv; }
            set { this._salesSlipNumDiv = value; }
        }

        /// <summary>取込_伝票種別プロパティ</summary>
        public bool AcptAnOdrStatusDiv
        {
            get { return this._acptAnOdrStatusDiv; }
            set { this._acptAnOdrStatusDiv = value; }
        }

        /// <summary>取込_売上日プロパティ</summary>
        public bool SalesDateDiv
        {
            get { return this._salesDateDiv; }
            set { this._salesDateDiv = value; }
        }

        /// <summary>取込_種別プロパティ</summary>
        public bool CategoryNoDiv
        {
            get { return this._categoryNoDiv; }
            set { this._categoryNoDiv = value; }
        }

        /// <summary>取込_型式プロパティ</summary>
        public bool FullModelDiv
        {
            get { return this._fullModelDiv; }
            set { this._fullModelDiv = value; }
        }

        /// <summary>取込_車種プロパティ</summary>
        public bool ModelCodeDiv
        {
            get { return this._modelCodeDiv; }
            set { this._modelCodeDiv = value; }
        }

        /// <summary>取込_BLコードプロパティ</summary>
        public bool BLGoodsCodeDiv
        {
            get { return this._blGoodsCodeDiv; }
            set { this._blGoodsCodeDiv = value; }
        }

        /// <summary>取込_品名プロパティ</summary>
        public bool GoodsNameDiv
        {
            get { return this._goodsNameDiv; }
            set { this._goodsNameDiv = value; }
        }

        /// <summary>取込_品番プロパティ</summary>
        public bool GoodsNoDiv
        {
            get { return this._goodsNoDiv; }
            set { this._goodsNoDiv = value; }
        }

        /// <summary>取込_メーカープロパティ</summary>
        public bool GoodsMakerDiv
        {
            get { return this._goodsMakerDiv; }
            set { this._goodsMakerDiv = value; }
        }

        /// <summary>取込_出荷数プロパティ</summary>
        public bool ShipmentCntDiv
        {
            get { return this._shipmentCntDiv; }
            set { this._shipmentCntDiv = value; }
        }

        /// <summary>取込_標準価格</summary>
        public bool PriceDiv
        {
            get { return this._priceDiv; }
            set { this._priceDiv = value; }
        }

        /// <summary>取込_売単価</summary>
        public bool SalesMoneyDiv
        {
            get { return this._salesMoneyDiv; }
            set { this._salesMoneyDiv = value; }
        }

        #endregion
    }

    /// <summary>
    /// 表示設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示設定クラスのアクセス制御を行います。</br>
    /// <br>Programmer : 980035 金沢　貞義</br>
    /// <br>Date       : 2010.05.25</br>
    /// </remarks>
    public class AnalysisMailSettingAcs
    {
        #region Constructor
        /// <summary>
        /// 表示設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public AnalysisMailSettingAcs()
        {
            if (_analysisMailSetting == null)
            {
                _analysisMailSetting = new AnalysisMailSetting();
            }
            this.Deserialize();
        }
        #endregion

        #region Private Member
        /// <summary>起動モード</summary>
        private int _startMode = 0;
        /// <summary>表示設定クラス</summary>
        private static AnalysisMailSetting _analysisMailSetting;

        /// <summary>表示設定保存ファイル名称</summary>
        private const string XML_FILE_NAME = "PMKHN07504U_MailSetting?.XML";
        #endregion

        #region Events
        /// <summary>表示設定変更後イベント</summary>
        public static event EventHandler AnalysisMailSettingChanged;
        #endregion

        #region Properties
        /// <summary>宛名初期値プロパティ</summary>
        public int AddressInitialDivValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.AddressInitialDivValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.AddressInitialDivValue = value;
            }
        }

        /// <summary>宛名初期値（任意コード）プロパティ</summary>
        public string AddressInitialCodeValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.AddressInitialCodeValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.AddressInitialCodeValue = value;
            }
        }

        /// <summary>宛名初期値（任意名称）プロパティ</summary>
        public string AddressInitialNameValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.AddressInitialNameValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.AddressInitialNameValue = value;
            }
        }

        /// <summary>宛名初期値（任意メールアドレス）プロパティ</summary>
        public string AddressInitialMailValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.AddressInitialMailValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.AddressInitialMailValue = value;
            }
        }

        /// <summary>件名初期値プロパティ</summary>
        public int SubjectInitialDivValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SubjectInitialDivValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SubjectInitialDivValue = value;
            }
        }

        /// <summary>件名初期値（任意）プロパティ</summary>
        public string SubjectInitialValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SubjectInitialValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SubjectInitialValue = value;
            }
        }

        /// <summary>CC設定（本社）プロパティ</summary>
        public bool CompanyCCDivValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.CompanyCCDivValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.CompanyCCDivValue = value;
            }
        }

        /// <summary>署名設定プロパティ</summary>
        public bool SignatureDisplayDivValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SignatureDisplayDivValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SignatureDisplayDivValue = value;
            }
        }

        /// <summary>署名初期値プロパティ</summary>
        public string SignatureInitialValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SignatureInitialValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SignatureInitialValue = value;
            }
        }

        /// <summary>入力可能最大文字数</summary>
        public int MailDocMaxSizeValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.MailDocMaxSizeValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.MailDocMaxSizeValue = value;
            }
        }

        /// <summary>入力可能最大文字数（１行）</summary>
        public int MailLineStrMaxSizeValue
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.MailLineStrMaxSizeValue;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.MailLineStrMaxSizeValue = value;
            }
        }

        /// <summary>取込_得意先プロパティ</summary>
        public bool CustomerDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.CustomerDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.CustomerDiv = value;
            }
        }

        /// <summary>取込_伝票番号プロパティ</summary>
        public bool SalesSlipNumDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SalesSlipNumDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SalesSlipNumDiv = value;
            }
        }

        /// <summary>取込_伝票種別プロパティ</summary>
        public bool AcptAnOdrStatusDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.AcptAnOdrStatusDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.AcptAnOdrStatusDiv = value;
            }
        }

        /// <summary>取込_売上日プロパティ</summary>
        public bool SalesDateDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SalesDateDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SalesDateDiv = value;
            }
        }

        /// <summary>取込_種別プロパティ</summary>
        public bool CategoryNoDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.CategoryNoDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.CategoryNoDiv = value;
            }
        }

        /// <summary>取込_型式プロパティ</summary>
        public bool FullModelDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.FullModelDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.FullModelDiv = value;
            }
        }

        /// <summary>取込_車種プロパティ</summary>
        public bool ModelCodeDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.ModelCodeDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.ModelCodeDiv = value;
            }
        }

        /// <summary>取込_BLコードプロパティ</summary>
        public bool BLGoodsCodeDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.BLGoodsCodeDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.BLGoodsCodeDiv = value;
            }
        }

        /// <summary>取込_品名プロパティ</summary>
        public bool GoodsNameDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.GoodsNameDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.GoodsNameDiv = value;
            }
        }

        /// <summary>取込_品番プロパティ</summary>
        public bool GoodsNoDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.GoodsNoDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.GoodsNoDiv = value;
            }
        }

        /// <summary>取込_メーカープロパティ</summary>
        public bool GoodsMakerDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.GoodsMakerDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.GoodsMakerDiv = value;
            }
        }

        /// <summary>取込_出荷数プロパティ</summary>
        public bool ShipmentCntDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.ShipmentCntDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.ShipmentCntDiv = value;
            }
        }

        /// <summary>取込_標準価格</summary>
        public bool PriceDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.PriceDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.PriceDiv = value;
            }
        }

        /// <summary>取込_売単価</summary>
        public bool SalesMoneyDiv
        {
            get
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                return _analysisMailSetting.SalesMoneyDiv;
            }
            set
            {
                if (_analysisMailSetting == null)
                {
                    _analysisMailSetting = new AnalysisMailSetting();
                }
                _analysisMailSetting.SalesMoneyDiv = value;
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// 表示設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public void Serialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            UserSettingController.SerializeUserSetting(_analysisMailSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));

            // 受注検索検索画面用ユーザー設定変更後イベント
            if (AnalysisMailSettingChanged != null)
            {
                AnalysisMailSettingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 表示設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public void Deserialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
            {
                try
                {
                    _analysisMailSetting = UserSettingController.DeserializeUserSetting<AnalysisMailSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
            }
        }
        #endregion
    }
}
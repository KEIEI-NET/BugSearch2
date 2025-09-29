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
    /// ���[�U�[�ݒ��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[�ݒ������͂��܂��B</br>
    /// <br>Programmer : 980035 ����@��`</br>
    /// <br>Date       : 2010.05.25</br>
    /// </remarks>
    public partial class PMKHN07504UB : Form
    {
        #region Constructor
        /// <summary>
        /// ���[�U�[�ݒ��ʃN���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
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
		/// Form.Load �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
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

            // ���������l
            this.AddressInitialDivValue.Value = this._analysisMailSettingAcs.AddressInitialDivValue;
            this.AddressInitialDivValue.FocusedIndex = this.AddressInitialDivValue.CheckedIndex;
            // ���������l�i�C�Ӗ��́j
            this.tEdit_EmployeeName.Value = this._analysisMailSettingAcs.AddressInitialNameValue;
            // ���������l
            this.SubjectInitialDivValue.Value = this._analysisMailSettingAcs.SubjectInitialDivValue;
            this.SubjectInitialDivValue.FocusedIndex = this.SubjectInitialDivValue.CheckedIndex;
            // ���������l�i�C�Ӂj
            this.SubjectInitialValue.Value = this._analysisMailSettingAcs.SubjectInitialValue;
            // CC�ݒ�i�{�Ёj
            this.uCheckEditor_CompanyCCDivValue.Checked = this._analysisMailSettingAcs.CompanyCCDivValue;
            // �����ݒ�
            this.uCheckEditor_SignatureDisplayDivValue.Checked = this._analysisMailSettingAcs.SignatureDisplayDivValue;
            // ���������l
            this.richTextBox_SignatureInitialValue.Text = this._analysisMailSettingAcs.SignatureInitialValue;
            // ���͉\�ő啶����
            this.tNedit_MailDocMaxSizeValue.Value = this._analysisMailSettingAcs.MailDocMaxSizeValue;
            // ���͉\�ő啶�����i�P�s�j
            this.tNedit_MailLineStrMaxSizeValue.Value = this._analysisMailSettingAcs.MailLineStrMaxSizeValue;

            // �捞_���Ӑ�
            this.uCheckEditor_CustomerDiv.Checked = this._analysisMailSettingAcs.CustomerDiv;
            // �捞_�`�[�ԍ�
            this.uCheckEditor_SalesSlipNumDiv.Checked = this._analysisMailSettingAcs.SalesSlipNumDiv;
            // �捞_�`�[���
            this.uCheckEditor_AcptAnOdrStatusDiv.Checked = this._analysisMailSettingAcs.AcptAnOdrStatusDiv;
            // �捞_�����
            this.uCheckEditor_SalesDateDiv.Checked = this._analysisMailSettingAcs.SalesDateDiv;
            // �捞_���
            this.uCheckEditor_CategoryNoDiv.Checked = this._analysisMailSettingAcs.CategoryNoDiv;
            // �捞_�^��
            this.uCheckEditor_FullModelDiv.Checked = this._analysisMailSettingAcs.FullModelDiv;
            // �捞_�Ԏ�
            this.uCheckEditor_ModelCodeDiv.Checked = this._analysisMailSettingAcs.ModelCodeDiv;
            // �捞_BL�R�[�h
            this.uCheckEditor_BLGoodsCodeDiv.Checked = this._analysisMailSettingAcs.BLGoodsCodeDiv;
            // �捞_�i��
            this.uCheckEditor_GoodsNameDiv.Checked = this._analysisMailSettingAcs.GoodsNameDiv;
            // �捞_�i��
            this.uCheckEditor_GoodsNoDiv.Checked = this._analysisMailSettingAcs.GoodsNoDiv;
            // �捞_���[�J�[
            this.uCheckEditor_GoodsMakerDiv.Checked = this._analysisMailSettingAcs.GoodsMakerDiv;
            // �捞_�o�א�
            this.uCheckEditor_ShipmentCntDiv.Checked = this._analysisMailSettingAcs.ShipmentCntDiv;
            // �捞_�W�����i
            this.uCheckEditor_PriceDiv.Checked = this._analysisMailSettingAcs.PriceDiv;
            // �捞_���P��
            this.uCheckEditor_SalesMoneyDiv.Checked = this._analysisMailSettingAcs.SalesMoneyDiv;
        }

		/// <summary>
		/// UltraButton.Click �C�x���g�iOk_ultraButton�j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
            // ���������l
            this._analysisMailSettingAcs.AddressInitialDivValue = (int)this.AddressInitialDivValue.Value;
            // ���������l�i�C�Ӗ��́j
            this._analysisMailSettingAcs.AddressInitialNameValue = (string)this.tEdit_EmployeeName.Value;
            // ���������l
            this._analysisMailSettingAcs.SubjectInitialDivValue = (int)this.SubjectInitialDivValue.Value;
            // ���������l�i�C�Ӂj
            this._analysisMailSettingAcs.SubjectInitialValue = (string)this.SubjectInitialValue.Value;
            // CC�ݒ�i�{�Ёj
            this._analysisMailSettingAcs.CompanyCCDivValue = (bool)this.uCheckEditor_CompanyCCDivValue.Checked;
            // �����ݒ�
            this._analysisMailSettingAcs.SignatureDisplayDivValue = (bool)this.uCheckEditor_SignatureDisplayDivValue.Checked;
            // ���������l
            this._analysisMailSettingAcs.SignatureInitialValue = (string)this.richTextBox_SignatureInitialValue.Text;
            // ���͉\�ő啶����
            this._analysisMailSettingAcs.MailDocMaxSizeValue = this.tNedit_MailDocMaxSizeValue.GetInt();
            // ���͉\�ő啶�����i�P�s�j
            this._analysisMailSettingAcs.MailLineStrMaxSizeValue = this.tNedit_MailLineStrMaxSizeValue.GetInt();

            // �捞_���Ӑ�
            this._analysisMailSettingAcs.CustomerDiv = this.uCheckEditor_CustomerDiv.Checked;
            // �捞_�`�[�ԍ�
            this._analysisMailSettingAcs.SalesSlipNumDiv = this.uCheckEditor_SalesSlipNumDiv.Checked;
            // �捞_�`�[���
            this._analysisMailSettingAcs.AcptAnOdrStatusDiv = this.uCheckEditor_AcptAnOdrStatusDiv.Checked;
            // �捞_�����
            this._analysisMailSettingAcs.SalesDateDiv = this.uCheckEditor_SalesDateDiv.Checked;
            // �捞_���
            this._analysisMailSettingAcs.CategoryNoDiv = this.uCheckEditor_CategoryNoDiv.Checked;
            // �捞_�^��
            this._analysisMailSettingAcs.FullModelDiv = this.uCheckEditor_FullModelDiv.Checked;
            // �捞_�Ԏ�
            this._analysisMailSettingAcs.ModelCodeDiv = this.uCheckEditor_ModelCodeDiv.Checked;
            // �捞_BL�R�[�h
            this._analysisMailSettingAcs.BLGoodsCodeDiv = this.uCheckEditor_BLGoodsCodeDiv.Checked;
            // �捞_�i��
            this._analysisMailSettingAcs.GoodsNameDiv = this.uCheckEditor_GoodsNameDiv.Checked;
            // �捞_�i��
            this._analysisMailSettingAcs.GoodsNoDiv = this.uCheckEditor_GoodsNoDiv.Checked;
            // �捞_���[�J�[
            this._analysisMailSettingAcs.GoodsMakerDiv = this.uCheckEditor_GoodsMakerDiv.Checked;
            // �捞_�o�א�
            this._analysisMailSettingAcs.ShipmentCntDiv = this.uCheckEditor_ShipmentCntDiv.Checked;
            // �捞_�W�����i
            this._analysisMailSettingAcs.PriceDiv = this.uCheckEditor_PriceDiv.Checked;
            // �捞_���P��
            this._analysisMailSettingAcs.SalesMoneyDiv = this.uCheckEditor_SalesMoneyDiv.Checked;

            this._analysisMailSettingAcs.Serialize();
		}

        #region �敪�ύX �C�x���g
        /// <summary>
        /// ����ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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
        /// ����ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
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

        #region �S���ғ��� �C�x���g
        private void tEdit_EmployeeName_Leave(object sender, EventArgs e)
        {
            string code = this.tEdit_EmployeeName.Text.Trim();
            string name = this.tEdit_EmployeeName.Text.Trim();
            int codeInt;

            #region �}�X�^�Ǎ�
            if ((code != "") &&
                (code.Length <= 4) &&
                (Int32.TryParse(code, out codeInt) == true))
            {
                // �]�ƈ��}�X�^
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
                            "�g�їp���[���A�h���X���ݒ肳��Ă��܂���B",
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
                        "�S���҂����݂��܂���B",
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
                        "�S���҂̎擾�Ɏ��s���܂����B",
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

        #region �K�C�h�{�^�� �C�x���g
        /// <summary>
        /// �]�ƈ��K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void ub_EmployeeGuide_Click(object sender, EventArgs e)
        {
            Employee employee;
            EmployeeDtl employeeDtl;

            // �]�ƈ��}�X�^�Ǎ�
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
                        "�g�їp���[���A�h���X���ݒ肳��Ă��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                }
            }
        }
        #endregion

        #region ChangeFocus �C�x���g
        /// <summary>
        /// tRetKeyControl1_ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //���������̏ꍇ
            if (e.PrevCtrl == this.richTextBox_SignatureInitialValue)
            {
                //�G�f�B�^����EnterKey�������ꂽ�ꍇ
                if (e.Key == Keys.Enter)
                {
                    //���s������}�����܂�
                    this.richTextBox_SignatureInitialValue.SelectedText += System.Environment.NewLine;
                    this.richTextBox_SignatureInitialValue.AcceptsTab = true;
                    e.NextCtrl = null;
                }
                //�G�f�B�^���� TabKey�������ꂽ�ꍇ
                else if (e.Key == Keys.Tab)
                {
                    //�^�u��}��
                    this.richTextBox_SignatureInitialValue.SelectedText += "\t";
                    e.NextCtrl = null;
                }
            }
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// �\���ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V���A��������\���ݒ�N���X�ł��B</br>
    /// <br>Programmer : 980035 ����@��`</br>
    /// <br>Date       : 2010.05.25</br>
    /// </remarks>
    [Serializable]
    public class AnalysisMailSetting
    {
        #region Constructor
        /// <summary>
        /// �\���ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
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
        /// �\���ݒ�N���X�R���X�g���N�^
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
        /// <br>Note       : �\���ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
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

        /// <summary>���������l</summary>
        private int _addressInitialDivValue;
        /// <summary>���������l�i�C�ӃR�[�h�j</summary>
        private string  _addressInitialCodeValue;
        /// <summary>���������l�i�C�Ӗ��́j</summary>
        private string _addressInitialNameValue;
        /// <summary>���������l�i�C�Ӄ��[���A�h���X�j</summary>
        private string _addressInitialMailValue;
        /// <summary>���������l</summary>
        private int _subjectInitialDivValue;
        /// <summary>���������l�i�C�Ӂj</summary>
        private string _subjectInitialValue;
        /// <summary>CC�ݒ�i�{�Ёj</summary>
        private bool _companyCCDivValue;
        /// <summary>�����ݒ�</summary>
        private bool _signatureDisplayDivValue;
        /// <summary>���������l</summary>
        private string _signatureInitialValue;
        /// <summary>���͉\�ő啶����</summary>
        private int _mailDocMaxSizeValue;
        /// <summary>���͉\�ő啶�����i�P�s�j</summary>
        private int _mailLineStrMaxSizeValue;

        /// <summary>�捞_���Ӑ�</summary>
        private bool _customerDiv;
        /// <summary>�捞_�`�[�ԍ�</summary>
        private bool _salesSlipNumDiv;
        /// <summary>�捞_�`�[���</summary>
        private bool _acptAnOdrStatusDiv;
        /// <summary>�捞_�����</summary>
        private bool _salesDateDiv;
        /// <summary>�捞_���</summary>
        private bool _categoryNoDiv;
        /// <summary>�捞_�^��</summary>
        private bool _fullModelDiv;
        /// <summary>�捞_�Ԏ�</summary>
        private bool _modelCodeDiv;
        /// <summary>�捞_BL�R�[�h</summary>
        private bool _blGoodsCodeDiv;
        /// <summary>�捞_�i��</summary>
        private bool _goodsNameDiv;
        /// <summary>�捞_�i��</summary>
        private bool _goodsNoDiv;
        /// <summary>�捞_���[�J�[</summary>
        private bool _goodsMakerDiv;
        /// <summary>�捞_�o�א�</summary>
        private bool _shipmentCntDiv;
        /// <summary>�捞_�W�����i</summary>
        private bool _priceDiv;
        /// <summary>�捞_���P��</summary>
        private bool _salesMoneyDiv;


        /// <summary>���������l</summary>
        private const int DEFAULT_ADDRESSINITIALDIV_VALUE = 1;
        /// <summary>���������l�i�C�Ӂj</summary>
        private const string DEFAULT_ADDRESSINITIALCODE_VALUE = "0000";
        /// <summary>���������l�i�C�Ӂj</summary>
        private const string DEFAULT_ADDRESSINITIALNAME_VALUE = null;
        /// <summary>���������l�i�C�Ӄ��[���A�h���X�j</summary>
        private const string DEFAULT_ADDRESSINITIALMAIL_VALUE = null;
        /// <summary>���������l</summary>
        private const int DEFAULT_SUBJECTINITIALDIV_VALUE = 0;
        /// <summary>���������l�i�C�Ӂj</summary>
        private const string DEFAULT_SUBJECTINITIAL_VALUE = null;
        /// <summary>CC�ݒ�i�{�Ёj</summary>
        private const bool DEFAULT_COMPANYCCDIV_VALUE = false;
        /// <summary>�����ݒ�</summary>
        private const bool DEFAULT_SIGNATUREDISPLAYDIV_VALUE = true;
        /// <summary>���������l</summary>
        private const string DEFAULT_SIGNATUREINITIAL_VALUE = null;
        /// <summary>���͉\�ő啶����</summary>
        private const int DEFAULT_MAILDOCMAXSIZE_VALUE = 0;
        /// <summary>���͉\�ő啶�����i�P�s�j</summary>
        private const int DEFAULT_MAILLINESTRMAXSIZE_VALUE = 0;

        /// <summary>�捞_���Ӑ�</summary>
        private bool DEFAULT_CUSTOMERDIV_VALUE = false;
        /// <summary>�捞_�`�[�ԍ�</summary>
        private bool DEFAULT_SALESSLIPNUMDIV_VALUE = false;
        /// <summary>�捞_�`�[���</summary>
        private bool DEFAULT_ACPTANODRSTATUSDIV_VALUE = false;
        /// <summary>�捞_�����</summary>
        private bool DEFAULT_SALESDATEDIV_VALUE = false;
        /// <summary>�捞_���</summary>
        private bool DEFAULT_CATEGORYNODIV_VALUE = false;
        /// <summary>�捞_�^��</summary>
        private bool DEFAULT_FULLMODELDIV_VALUE = false;
        /// <summary>�捞_�Ԏ�</summary>
        private bool DEFAULT_MODELCODEDIV_VALUE = false;
        /// <summary>�捞_BL�R�[�h</summary>
        private bool DEFAULT_BLGOODSCODEDIV_VALUE = false;
        /// <summary>�捞_�i��</summary>
        private bool DEFAULT_GOODSNAMEDIV_VALUE = false;
        /// <summary>�捞_�i��</summary>
        private bool DEFAULT_GOODSNODIV_VALUE = false;
        /// <summary>�捞_���[�J�[</summary>
        private bool DEFAULT_GOODSMAKERDIV_VALUE = false;
        /// <summary>�捞_�o�א�</summary>
        private bool DEFAULT_SHIPMENTCNTDIV_VALUE = false;
        /// <summary>�捞_�W�����i</summary>
        private bool DEFAULT_PRICEDIV_VALUE = false;
        /// <summary>�捞_���P��</summary>
        private bool DEFAULT_SALESMONEYDIV_VALUE = false;
        #endregion

        #region Propaty
        /// <summary>���������l�v���p�e�B</summary>
        public int AddressInitialDivValue
        {
            get { return this._addressInitialDivValue; }
            set { this._addressInitialDivValue = value; }
        }

        /// <summary>���������l�i�C�ӃR�[�h�j�v���p�e�B</summary>
        public string AddressInitialCodeValue
        {
            get { return this._addressInitialCodeValue; }
            set { this._addressInitialCodeValue = value; }
        }

        /// <summary>���������l�i�C�Ӗ��́j�v���p�e�B</summary>
        public string AddressInitialNameValue
        {
            get { return this._addressInitialNameValue; }
            set { this._addressInitialNameValue = value; }
        }

        /// <summary>���������l�i�C�Ӄ��[���A�h���X�j�v���p�e�B</summary>
        public string AddressInitialMailValue
        {
            get { return this._addressInitialMailValue; }
            set { this._addressInitialMailValue = value; }
        }

        /// <summary>���������l�v���p�e�B</summary>
        public int SubjectInitialDivValue
        {
            get { return this._subjectInitialDivValue; }
            set { this._subjectInitialDivValue = value; }
        }

        /// <summary>���������l�i�C�Ӂj�v���p�e�B</summary>
        public string SubjectInitialValue
        {
            get { return this._subjectInitialValue; }
            set { this._subjectInitialValue = value; }
        }

        /// <summary>CC�ݒ�i�{�Ёj�v���p�e�B</summary>
        public bool CompanyCCDivValue
        {
            get { return this._companyCCDivValue; }
            set { this._companyCCDivValue = value; }
        }

        /// <summary>�����ݒ�v���p�e�B</summary>
        public bool SignatureDisplayDivValue
        {
            get { return this._signatureDisplayDivValue; }
            set { this._signatureDisplayDivValue = value; }
        }

        /// <summary>���������l�v���p�e�B</summary>
        public string SignatureInitialValue
        {
            get { return this._signatureInitialValue; }
            set { this._signatureInitialValue = value; }
        }

        /// <summary>���͉\�ő啶�����v���p�e�B</summary>
        public int MailDocMaxSizeValue
        {
            get { return this._mailDocMaxSizeValue; }
            set { this._mailDocMaxSizeValue = value; }
        }

        /// <summary>���͉\�ő啶�����i�P�s�j�v���p�e�B</summary>
        public int MailLineStrMaxSizeValue
        {
            get { return this._mailLineStrMaxSizeValue; }
            set { this._mailLineStrMaxSizeValue = value; }
        }

        /// <summary>�捞_���Ӑ�v���p�e�B</summary>
        public bool CustomerDiv
        {
            get { return this._customerDiv; }
            set { this._customerDiv = value; }
        }

        /// <summary>�捞_�`�[�ԍ��v���p�e�B</summary>
        public bool SalesSlipNumDiv
        {
            get { return this._salesSlipNumDiv; }
            set { this._salesSlipNumDiv = value; }
        }

        /// <summary>�捞_�`�[��ʃv���p�e�B</summary>
        public bool AcptAnOdrStatusDiv
        {
            get { return this._acptAnOdrStatusDiv; }
            set { this._acptAnOdrStatusDiv = value; }
        }

        /// <summary>�捞_������v���p�e�B</summary>
        public bool SalesDateDiv
        {
            get { return this._salesDateDiv; }
            set { this._salesDateDiv = value; }
        }

        /// <summary>�捞_��ʃv���p�e�B</summary>
        public bool CategoryNoDiv
        {
            get { return this._categoryNoDiv; }
            set { this._categoryNoDiv = value; }
        }

        /// <summary>�捞_�^���v���p�e�B</summary>
        public bool FullModelDiv
        {
            get { return this._fullModelDiv; }
            set { this._fullModelDiv = value; }
        }

        /// <summary>�捞_�Ԏ�v���p�e�B</summary>
        public bool ModelCodeDiv
        {
            get { return this._modelCodeDiv; }
            set { this._modelCodeDiv = value; }
        }

        /// <summary>�捞_BL�R�[�h�v���p�e�B</summary>
        public bool BLGoodsCodeDiv
        {
            get { return this._blGoodsCodeDiv; }
            set { this._blGoodsCodeDiv = value; }
        }

        /// <summary>�捞_�i���v���p�e�B</summary>
        public bool GoodsNameDiv
        {
            get { return this._goodsNameDiv; }
            set { this._goodsNameDiv = value; }
        }

        /// <summary>�捞_�i�ԃv���p�e�B</summary>
        public bool GoodsNoDiv
        {
            get { return this._goodsNoDiv; }
            set { this._goodsNoDiv = value; }
        }

        /// <summary>�捞_���[�J�[�v���p�e�B</summary>
        public bool GoodsMakerDiv
        {
            get { return this._goodsMakerDiv; }
            set { this._goodsMakerDiv = value; }
        }

        /// <summary>�捞_�o�א��v���p�e�B</summary>
        public bool ShipmentCntDiv
        {
            get { return this._shipmentCntDiv; }
            set { this._shipmentCntDiv = value; }
        }

        /// <summary>�捞_�W�����i</summary>
        public bool PriceDiv
        {
            get { return this._priceDiv; }
            set { this._priceDiv = value; }
        }

        /// <summary>�捞_���P��</summary>
        public bool SalesMoneyDiv
        {
            get { return this._salesMoneyDiv; }
            set { this._salesMoneyDiv = value; }
        }

        #endregion
    }

    /// <summary>
    /// �\���ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���ݒ�N���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 980035 ����@��`</br>
    /// <br>Date       : 2010.05.25</br>
    /// </remarks>
    public class AnalysisMailSettingAcs
    {
        #region Constructor
        /// <summary>
        /// �\���ݒ�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���ݒ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
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
        /// <summary>�N�����[�h</summary>
        private int _startMode = 0;
        /// <summary>�\���ݒ�N���X</summary>
        private static AnalysisMailSetting _analysisMailSetting;

        /// <summary>�\���ݒ�ۑ��t�@�C������</summary>
        private const string XML_FILE_NAME = "PMKHN07504U_MailSetting?.XML";
        #endregion

        #region Events
        /// <summary>�\���ݒ�ύX��C�x���g</summary>
        public static event EventHandler AnalysisMailSettingChanged;
        #endregion

        #region Properties
        /// <summary>���������l�v���p�e�B</summary>
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

        /// <summary>���������l�i�C�ӃR�[�h�j�v���p�e�B</summary>
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

        /// <summary>���������l�i�C�Ӗ��́j�v���p�e�B</summary>
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

        /// <summary>���������l�i�C�Ӄ��[���A�h���X�j�v���p�e�B</summary>
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

        /// <summary>���������l�v���p�e�B</summary>
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

        /// <summary>���������l�i�C�Ӂj�v���p�e�B</summary>
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

        /// <summary>CC�ݒ�i�{�Ёj�v���p�e�B</summary>
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

        /// <summary>�����ݒ�v���p�e�B</summary>
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

        /// <summary>���������l�v���p�e�B</summary>
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

        /// <summary>���͉\�ő啶����</summary>
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

        /// <summary>���͉\�ő啶�����i�P�s�j</summary>
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

        /// <summary>�捞_���Ӑ�v���p�e�B</summary>
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

        /// <summary>�捞_�`�[�ԍ��v���p�e�B</summary>
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

        /// <summary>�捞_�`�[��ʃv���p�e�B</summary>
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

        /// <summary>�捞_������v���p�e�B</summary>
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

        /// <summary>�捞_��ʃv���p�e�B</summary>
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

        /// <summary>�捞_�^���v���p�e�B</summary>
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

        /// <summary>�捞_�Ԏ�v���p�e�B</summary>
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

        /// <summary>�捞_BL�R�[�h�v���p�e�B</summary>
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

        /// <summary>�捞_�i���v���p�e�B</summary>
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

        /// <summary>�捞_�i�ԃv���p�e�B</summary>
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

        /// <summary>�捞_���[�J�[�v���p�e�B</summary>
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

        /// <summary>�捞_�o�א��v���p�e�B</summary>
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

        /// <summary>�捞_�W�����i</summary>
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

        /// <summary>�捞_���P��</summary>
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
        /// �\���ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public void Serialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            UserSettingController.SerializeUserSetting(_analysisMailSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));

            // �󒍌���������ʗp���[�U�[�ݒ�ύX��C�x���g
            if (AnalysisMailSettingChanged != null)
            {
                AnalysisMailSettingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// �\���ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
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
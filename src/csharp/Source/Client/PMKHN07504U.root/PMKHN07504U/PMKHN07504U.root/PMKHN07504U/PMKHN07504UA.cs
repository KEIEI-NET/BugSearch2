using System;
using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using System.Text.RegularExpressions;

using Broadleaf.Library.Windows.Forms; 
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// e-mail���͍쐬�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: e-mail���͂̍쐬���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br> 
    ///                   IMailEditor���������Ă��܂��B
    /// <br>Programmer  : 980035 ����@��`</br>
    /// <br>Date        : 2010.05.25</br>
    /// </remarks>
    public partial class PMKHN07504UA : Form
    {
        #region Constractor
        /// <summary>
        /// e-mail���͍쐬�t�H�[���N���X�R���X�g���N�^�[
        /// </summary> 
        /// <remarks>
        /// <br>Note�@�@�@ : e-mail���͍쐬�N���X�̕ϐ������������܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public PMKHN07504UA()
        {
            InitializeComponent();

            #region ����

            //��ƃR�[�h�擾
			//this._enterpriseCode			= LoginInfoAcquisition.EnterpriseCode;
             //������
            this._mailInfoBase				= new MailInfoBase(MailServiceInfoCreateMode.Default);
            this._mailFactoryBase           = new MailFactoryBase(MailServiceInfoCreateMode.Default); 
           
            #endregion

            MailFactoryBase mailFactoryBase = new MailFactoryBase(MailServiceInfoCreateMode.Default);
            _mailSender = mailFactoryBase.GetMailSenderInterface();
        }
        #endregion
        
        #region Private Member

        #region Const
      
        //PGID
        private const string PGID               = "PMKHN07504U";
        //�ő���͕�����
        private int maxCountPc                  = 0;
        //�f�[�^�������ꍇ�p
        private const int MAXCOUNT_PC           = 30000;
        private const int MAXCOUNT_MOBILE       = 500;

        //DM���
        private const string DMKIND_MAIL    �@  = "���[������";
        private const string DMKIND_SIGNATURE   = "����";
                                                
        //�G�f�B�^�o�[�W����(�ݒ���@�����܂�܂ŌŒ�)
        private const string EDITERVERTION      = ".NS MailService 1.1.1.0";
        //DataSet�̃J������
        private const string MAILDOCUMENTCNTS   = "MailDocumentCnts";
        private const string MAILTITLE_TITLE    = "MailTitle";
        //ToolBar�̖���
        private const string TOOLBARMENU_END    = "End";
        private const string TOOLBARMENU_SETUP  = "Tool_Setup";
        private const string TOOLBARMENU_SEND   = "Tool_Send";
             
        #endregion 

        #region Member
       
        #region ����

        //private string			_enterpriseCode;

        private int _sizeDifferenceAddress = 800 - 647;
        private int _sizeDifferenceSubject = 800 - 685;
        private int _sizeDifferenceQRCode = 800 - 647;

        //���[���T�[�r�X�֘A Infomation Base �N���X
        MailInfoBase _mailInfoBase ;
        //���[���T�[�r�X �I�u�W�F�N�g�Ǘ��N���X 
        MailFactoryBase _mailFactoryBase ; 
 
        private Control _control;

        //���[���A�h���X�ۑ��p
        private Dictionary<string, string> mailAddressList = new Dictionary<string, string>();
        private Dictionary<string, string> ccAddressList = new Dictionary<string, string>();

        //���[�U�[�ݒ���
        private PMKHN07504UB _userSetupFrm;
        private bool _defaultStartFlg;

        private MailInfoSetting _mailInfoSetting = null;

        private AnalysisMailSettingAcs _analysisMailSettingAcs = null;
        private MailDefaultDataAcs _mailDefaultDataAcs = null;
        private MailDefaultHeader _mailDefaultHeader = null;
        private MailDefaultCar _mailDefaultCar = null;
        private List<MailDefaultDetail> _mailDefaultDetailList = null;

        private IMailSender _mailSender;

        // ���[�����M�{�^���������t���O
        private bool _isClickSendMail = true;

        // ���ڕۑ��p
        private string _address_tEdit = null;
        private string _carbonCopy_tEdit = null;

        #endregion

        #endregion

        #endregion

        #region Delegate
        /// <summary>
        /// �N���p�����[�^�擾�f���Q�[�g
        /// </summary>
        /// <param name="param"></param>
        public delegate void GetStartParameterEventHandler(out string param);
        #endregion

        #region Events
        /// <summary>
        /// �N���p�����[�^�擾�f���Q�[�g
        /// </summary>
        public GetStartParameterEventHandler GetStartParameterEvent;
        #endregion

        #region IMailEditor �����o

        ///// <summary>
        ///// �G�f�B�^�N������
        ///// </summary>  
        ///// <remarks>
        ///// <br>Note�@�@�@ : ���[�h�ɉ����ăG�f�B�^���N�����܂�</br>
        ///// <br>Programmer : 980035 ����@��`</br>
        ///// <br>Date       : 2010.05.25</br>
        ///// </remarks>
        //public bool ShowEditor()
        //{           
        //    bool result ;
        //    try
        //    {
                
        //        //�Ƃ肠�����V�K���[�h�ŋN��
        //        ScreenPermissionControl(0);
        //        this.ShowDialog();
        //        result = true;
        //        return result;
        //    }
        //    catch(Exception)
        //    {
        //        result = false;
        //        return result;
        //    }                                                    
        //}

        /// <summary>
		/// �G�f�B�^Vertion�v���p�e�B
		/// </summary>
		/// <returns>EDITERVERTION</returns>
		/// <remarks>
		/// <br>Note       : �G�f�B�^�̃o�[�W������Ԃ��܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
		/// </remarks>
        public string Version
        {
            get { return EDITERVERTION; }
        }

        #endregion

        # region Main
        /// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN07504UA());
		}
		# endregion

     	#region Events

		#endregion

        #region Public Methods

		#endregion

        #region Private Method

        #region ��ʏ����ݒ菈��

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ��ʍ\�z
            this.QRCodePath_ultraLabel.Visible = false;
            this.QRCodePath_tEdit.Visible = false;
            this.uButton_QRCodePath.Visible = false;

            //�ݒ���e�Ǎ�
            this._analysisMailSettingAcs = new AnalysisMailSettingAcs();

            // �N���p�����[�^�擾
            string param;
            this.GetStartParameterDelegateCall(out param);

            //�󂯓n�����Ǎ�
            this._mailDefaultDataAcs = new MailDefaultDataAcs();
            this._mailDefaultHeader = new MailDefaultHeader();
            this._mailDefaultCar = new MailDefaultCar();
            this._mailDefaultDetailList = new List<MailDefaultDetail>();
            this._defaultStartFlg = true;
            if (!string.IsNullOrEmpty(param))
            {
                // �����l�t�@�C�������݂��邩�H
                int st = _mailDefaultDataAcs.Read(param, out _mailDefaultHeader, out _mailDefaultCar, out _mailDefaultDetailList);
                if (st == 0)
                {
                    // �����l�t�@�C���폜
                    _mailDefaultDataAcs.Delete(param);
                }
                else
                {
                    // �����l�t�@�C�������݂��Ȃ�
                    _defaultStartFlg = false;
                }
            }
            else
            {
                // �����l�t�@�C���̃p�X������
                _defaultStartFlg = false;
            }
        }

        #endregion

        #region ��ʍč\�z����
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>           : ��ʂ̓��e������ϐ��ɕێ����܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            #region �w�b�_������
            // ���������l
            switch ((int)this._analysisMailSettingAcs.AddressInitialDivValue)
            {
                case 1:     // ���`����\��
                    {
                        if (_defaultStartFlg)
                        {
                            //if (_mailDefaultHeader.SalesEmployeeNm != string.Empty)
                            //{
                            //    // �f�[�^�t�@�C���̖��̂�\��
                            //    this.Address_tEdit.Text = _mailDefaultHeader.SalesEmployeeNm;
                            //}
                            //else if (_mailDefaultHeader.SalesEmployeeCd.Trim() != string.Empty)
                            if (_mailDefaultHeader.SalesEmployeeCd.Trim() != string.Empty)
                            {
                                // �f�[�^�t�@�C���̃R�[�h���疼�̂��擾
                                Employee employee;
                                EmployeeDtl employeeDtl;
                                int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, _mailDefaultHeader.SalesEmployeeCd.Trim());

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this.mailAddressList.Clear();
                                    this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                    //if (employeeDtl.MailAddress2 == string.Empty)
                                    //{
                                    //    this.Address_tEdit.Text = employee.Name.Trim() + "<���[���A�h���X���ݒ�>";
                                    //}
                                    //else
                                    //{
                                    //    this.Address_tEdit.Text = employee.Name.Trim() + "<" + employeeDtl.MailAddress2 + ">";
                                    //}
                                    this.Address_tEdit.Text = employee.Name.Trim();
                                }
                            }
                            else
                            {
                                // �R�[�h������
                                this.Address_tEdit.Text = string.Empty;
                            }
                        }
                        else
                        {
                            // �f�[�^�t�@�C�������݂��Ȃ�
                            this.Address_tEdit.Text = string.Empty;
                        }
                        break;
                    }
                case 2:     // �C�Ӑݒ肩��\��
                    {
                        if (this._analysisMailSettingAcs.AddressInitialCodeValue.Trim() != string.Empty)
                        {
                            // �]�ƈ��ڍ׃}�X�^�Ǎ�
                            Employee employee;
                            EmployeeDtl employeeDtl;
                            int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, this._analysisMailSettingAcs.AddressInitialCodeValue.Trim());

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.mailAddressList.Clear();
                                this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                //if (employeeDtl.MailAddress2 == string.Empty)
                                //{
                                //    this.Address_tEdit.Text = employee.Name.Trim() + "<���[���A�h���X���ݒ�>";
                                //}
                                //else
                                //{
                                //    this.Address_tEdit.Text = employee.Name.Trim() + "<" + employeeDtl.MailAddress2 + ">";
                                //}
                                this.Address_tEdit.Text = employee.Name.Trim();
                            }
                        }
                        break;
                    }
                default:    //  ��\��
                    {
                        this.Address_tEdit.Text = string.Empty;
                        break;
                    }
            }

            // ���������l
            if ((int)this._analysisMailSettingAcs.SubjectInitialDivValue == 1)
            {
                this.Subject_tEdit.Text = (string)this._analysisMailSettingAcs.SubjectInitialValue;
            }
            else if (_defaultStartFlg)
            {
                //this.Subject_tEdit.Text = "�e�X�g�����y���Ӑ�z";
                if (_mailDefaultHeader.CustomerSnm != string.Empty)
                {
                    // �f�[�^�t�@�C���̖��̂�\��
                    this.Subject_tEdit.Text = _mailDefaultHeader.CustomerSnm;
                }
                else
                {
                    // ���̖�����
                    this.Subject_tEdit.Text = string.Empty;
                }
            }
            else
            {
                // �f�[�^�t�@�C�������݂��Ȃ�
                this.Subject_tEdit.Text = string.Empty;
            }

            // CC�����l
            if ((bool)this._analysisMailSettingAcs.CompanyCCDivValue == true)
            {
                this.ccAddressList.Clear();
                this.ccAddressList.Add("�y���Ёz", _mailInfoSetting.MailAddress);
                //this.CarbonCopy_tEdit.Text = "�y���Ёz<" + _mailInfoSetting.MailAddress + ">";
                this.CarbonCopy_tEdit.Text = "�y���Ёz";

                this.CarbonCopy_tEdit.Enabled = false;
                this.uButton_CarbonCopyGuide.Visible = false;
            }
            else
            {
                this.CarbonCopy_tEdit.Enabled = true;
                this.uButton_CarbonCopyGuide.Visible = true;
            }

            // QR�R�[�h�����l
            if ((_defaultStartFlg) && (_mailDefaultHeader.Mode == 1))
            {
                this.QRCodePath_tEdit.Text = _mailDefaultHeader.AttachedFilePath;
            }
            if (_mailDefaultHeader.Mode == 1)
            {
                this.QRCodePath_ultraLabel.Visible = true;
                this.QRCodePath_tEdit.Visible = true;
                this.uButton_QRCodePath.Visible = true;
                //this.EMailInfo_panel.Height = 135;
                //this.PcEditor_richTextBox.Height = 341;
            }
            else
            {
                //this.EMailInfo_panel.Height = 105;
                //this.PcEditor_richTextBox.Height = 371;
            }

            #endregion

            #region ���[���{���ҏW
            string mailText = string.Empty;
            if (_defaultStartFlg)
            {
                #region �`�[�w�b�_���
                // ���Ӑ�
                if ((bool)this._analysisMailSettingAcs.CustomerDiv == true)
                {
                    mailText = mailText + "���Ӑ�:" + _mailDefaultHeader.CustomerSnm + "\r\n";
                }
                // �`�[�ԍ�
                if ((bool)this._analysisMailSettingAcs.SalesSlipNumDiv == true)
                {
                    mailText = mailText + "�`�[�ԍ�:" + _mailDefaultHeader.SalesSlipNum + "\r\n";
                }
                // �`�[���
                if ((bool)this._analysisMailSettingAcs.AcptAnOdrStatusDiv == true)
                {
                    switch (_mailDefaultHeader.AcptAnOdrStatus)
                    {
                        case 10:
                            {
                                if (_mailDefaultHeader.EstimateDivide == 2)
                                {
                                    mailText = mailText + "���:�P������\r\n";
                                }
                                else if (_mailDefaultHeader.EstimateDivide == 3)
                                {
                                    mailText = mailText + "���:��������\r\n";
                                }
                                else
                                {
                                    mailText = mailText + "���:����\r\n";
                                }
                                break;
                            }
                        case 20:
                            {
                                mailText = mailText + "���:��\r\n";
                                break;
                            }
                        case 30:
                            {
                                mailText = mailText + "���:����\r\n";
                                break;
                            }
                        case 40:
                            {
                                mailText = mailText + "���:�ݏo\r\n";
                                break;
                            }
                    }
                }
                // ������t
                if ((bool)this._analysisMailSettingAcs.SalesDateDiv == true)
                {
                    mailText = mailText + "�����:" + _mailDefaultHeader.SalesDate.ToShortDateString() + "\r\n";
                }
                #endregion

                #region �`�[���q���
                // �ޕ�
                if ((bool)this._analysisMailSettingAcs.CategoryNoDiv == true)
                {
                    mailText = mailText + "�ޕ�:" + _mailDefaultCar.ModelDesignationNo.ToString("00000") + "-" + _mailDefaultCar.CategoryNo.ToString("0000") + "\r\n";
                }
                // �^��
                if ((bool)this._analysisMailSettingAcs.FullModelDiv == true)
                {
                    mailText = mailText + "�^��:" + _mailDefaultCar.FullModel + "\r\n";
                }
                // �Ԏ�
                if ((bool)this._analysisMailSettingAcs.ModelCodeDiv == true)
                {
                    mailText = mailText + "�Ԏ�:" + _mailDefaultCar.ModelFullName + "\r\n";
                }
                #endregion

                #region �`�[���׏��
                if (((bool)this._analysisMailSettingAcs.BLGoodsCodeDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.GoodsNameDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.GoodsNoDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.GoodsMakerDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.ShipmentCntDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.PriceDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.SalesMoneyDiv == true))
                {
                    for (int ix = 0; ix < this._mailDefaultDetailList.Count; ix++)
                    {
                        MailDefaultDetail mailDefaultDetail = _mailDefaultDetailList[ix];
                        mailText = mailText + "\r\n";

                        // BL�R�[�h
                        if ((bool)this._analysisMailSettingAcs.BLGoodsCodeDiv == true)
                        {
                            mailText = mailText + "BL�R�[�h:" + mailDefaultDetail.BLGoodsCode.ToString("00000") + "\r\n";
                        }
                        // �i��
                        if ((bool)this._analysisMailSettingAcs.GoodsNameDiv == true)
                        {
                            mailText = mailText + "�i��:" + mailDefaultDetail.GoodsName + "\r\n";
                        }
                        // �i��
                        if ((bool)this._analysisMailSettingAcs.GoodsNoDiv == true)
                        {
                            mailText = mailText + "�i��:" + mailDefaultDetail.GoodsNo + "\r\n";
                        }
                        // ���[�J�[
                        if ((bool)this._analysisMailSettingAcs.GoodsMakerDiv == true)
                        {
                            mailText = mailText + "���[�J�[:" + mailDefaultDetail.MakerName + "\r\n";
                        }
                        // �o�א�
                        if ((bool)this._analysisMailSettingAcs.ShipmentCntDiv == true)
                        {
                            mailText = mailText + "�o�א�:" + mailDefaultDetail.ShipmentCnt.ToString() + "\r\n";
                        }
                        // �W�����i
                        if ((bool)this._analysisMailSettingAcs.PriceDiv == true)
                        {
                            mailText = mailText + "�W�����i:" + mailDefaultDetail.ListPriceTaxExcFl.ToString() + "\r\n";
                        }
                        // ���P��
                        if ((bool)this._analysisMailSettingAcs.SalesMoneyDiv == true)
                        {
                            mailText = mailText + "���P��:" + mailDefaultDetail.SalesUnPrcTaxExcFl.ToString() + "\r\n";
                        }
                    }
                }
                #endregion
            }

            // ���������l
            if ((bool)this._analysisMailSettingAcs.SignatureDisplayDivValue == true)
            {
                string signatureText = (string)this._analysisMailSettingAcs.SignatureInitialValue;
                this.PcEditor_richTextBox.Text = mailText + "\r\n" + signatureText;
            }
            #endregion

            // ���͍��ڂ̕ۑ�
            this._address_tEdit = this.Address_tEdit.Text.Trim();
            this._carbonCopy_tEdit = this.CarbonCopy_tEdit.Text.Trim();

            // ���[�������ݒ�Z�b�g
            GetMailDocSet(this._analysisMailSettingAcs);

            //StatusBar�ɓ��͂���Ă��镶������\������
            SetWordsCountToUltraStatusBar(this.PcEditor_richTextBox);

        }
        #endregion

        #region ���͕������\������
        
        /// <summary>
        /// ���͕������\������
        /// </summary> 
        /// <param name="richTextBox">richTextBox�R���g���[��</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���͂��ꂽ��������ultraStatusBar�ɕ\�����܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void SetWordsCountToUltraStatusBar(RichTextBox richTextBox)
        {
            int length = 0;

            //���������擾����ꍇ        
            length = richTextBox.Text.Length;

            string msg = String.Format("���͕������@"+"{0}/{1}",length,maxCountPc);
            this.ultraStatusBar1.SetStatusBarText(richTextBox, msg);
            this.ultraStatusBar1.Text = ultraStatusBar1.GetStatusBarText(richTextBox);
            //���͐����`�F�b�N
        }

        #endregion

        #region ���[�������ݒ菈��
        /// <summary>
        /// ���[�������ݒ菈��
        /// </summary>
        /// <param name="mailDocSet">���[���ݒ���</param>
        /// <remarks>
        /// <br>Note       : �G�f�B�^�̓��͐���ݒ���s���܂� </br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void GetMailDocSet(AnalysisMailSettingAcs mailDocSet)
        {
            //��s�ӂ�̍ő���͕�����PC�p(���p)
            float limitChar_Pc ;
            //��s�ӂ�̍ő���͕�����MOBILE�p(���p)
            //float limitChar_Mobile;

            //MS�S�V�b�N11.25�ňꕶ��������ɕK�v�ȃ}�[�W��
            float margin = 8.158F;
            
            #region PC

            //���[�������ő�T�C�Y�A�s�ő�T�C�Y���Z�b�g����B
            //0�̏ꍇ�͋K��l������
            if (mailDocSet.MailDocMaxSizeValue == 0)
            {
                //���e����(500����)
                //this.maxCountPc = MAXCOUNT_PC;
                this.maxCountPc = MAXCOUNT_MOBILE;
                this.PcEditor_richTextBox.MaxLength     =  this.maxCountPc;         //PC�p               
            }
            else
            {
                //�ő���͕��������擾����
                this.maxCountPc = mailDocSet.MailDocMaxSizeValue;
                this.PcEditor_richTextBox.MaxLength     =  this.maxCountPc;      //PC�p
            }
            
            //��s�ӂ�̍ő���͕�����PC�p(���p)
            if (mailDocSet.MailLineStrMaxSizeValue == 0)
            {
                ////���e����(72����)
                //limitChar_Pc     = 72F;  //PC�p              
                //���e����(24����)
                limitChar_Pc = 24F;  //�g�їp     
            }
            else
            {
                //��s�ӂ�̕��������擾
                limitChar_Pc = (float)mailDocSet.MailLineStrMaxSizeValue;   //PC�p
            }

            //�]���ݒ�(PC)
            if((int)limitChar_Pc < 57)
            {               
                this.PcEditor_richTextBox.RightMargin = (int)(margin*limitChar_Pc);
            }
            else if((int)limitChar_Pc == 57)
            {
                //57�̎��͂��܂��s���Ȃ��̂ŁB�B�B             
                this.PcEditor_richTextBox.RightMargin = (int)(margin*limitChar_Pc - margin);
            }
            else
            {
                //56��������Ɩ�1margin���덷���ł�̂�
                this.PcEditor_richTextBox.RightMargin = (int)(margin*limitChar_Pc - margin);
            }

            #endregion
        }
        #endregion

        #region �@��ˑ������`�F�b�N
        /// <summary>
        /// �@��ˑ������`�F�b�N����
        /// </summary>
        /// <param name="text">�`�F�b�N�Ώۂ̕���</param>       
        /// <param name="halfKanaIndexes">���p�ł�����index</param>
        /// <param name="addictIndexes">�@��ˑ�����������index</param>      
        /// <returns>result(True:���� false:�ُ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : �@��ˑ������̃`�F�b�N���s���܂�</br>
        /// <br>Programmer : 23010 ����  �m</br>
        /// <br>Date       : 2006.10.02</br>
        /// </remarks>
        private bool CheckText(string text, ref int[] halfKanaIndexes, ref int[] addictIndexes)
        {
            bool result = true;
            byte[] byteArray;

            byteArray = TStrConv.UnicodeToSJis(text);

            List<int> halfKanaIndexList = new List<int>();
            List<int> addictIndexList = new List<int>();

            int textIndex = 0;
            int ix = 0;
            while (ix < byteArray.Length)
            {
                switch (ByteType(byteArray[ix]))
                {
                    case 1:
                        {
                            //�Pbyte����
                            if (CheckHalfKana(byteArray[ix]) == false)
                            {
                                halfKanaIndexList.Add(textIndex);
                                result = false;
                            }
                            ix += 1;
                            break;
                        }
                    case 2:
                        {
                            //�Qbyte����
                            if (ix + 1 >= byteArray.Length)
                            {
                                addictIndexList.Add(textIndex);
                                result = false;
                            }

                            if (CheckAddictWord(byteArray[ix], byteArray[ix + 1]) == false)
                            {
                                addictIndexList.Add(textIndex);
                                result = false;
                            }
                            ix += 2;
                            break;
                        }
                    default:
                        {
                            addictIndexList.Add(textIndex);
                            result = false;
                            break;
                        }
                }
                textIndex++;
            }

            if (result == false)
            {
                halfKanaIndexes = halfKanaIndexList.ToArray();
                addictIndexes = addictIndexList.ToArray();
            }
            return result;
        }

        /// <summary>
        /// �����̃o�C�g������
        /// </summary> 
        /// <param name="byteChar">�`�F�b�N�Ώۂ̃o�C�g������</param>
        /// <returns>0:1byte���� 1:2byte����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : �n���ꂽ�����̃o�C�g���𔻒肵�܂��B</br>
        /// <br>Programmer : 23010 ����  �m</br>
        /// <br>Date       : 2006.10.02</br>
        /// </remarks>
        private int ByteType(byte byteChar)
        {
            //�P�o�C�g����
            //�P�o�C�g�����̗̈�Ɋ܂܂�Ă��邩���肷��
            if ((byteChar <= 0x7e) || (0xa1 <= byteChar && byteChar <= 0xdf))
            {
                return 1;
            }
            //�Q�o�C�g����
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// ���p�ł̔���
        /// </summary> 
        /// <param name="byteChar">�`�F�b�N�Ώۂ̃o�C�g����</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �n���ꂽ�o�C�g���������p�łł��邩���肵�܂�</br>
        /// <br>Programmer : 23010 ����  �m</br>
        /// <br>Date       : 2006.10.02</br>
        /// </remarks>
        private bool CheckHalfKana(byte byteChar)
        {
            //if(lChar >= #161) and (lChar <= #223) then
            // 10�� �E�E�E ���p�J�^�J�i��(�V�t�gJIS��00A1 �` 00DF)
            bool result = true;
            //���p�J�i�̏ꍇ
            if ((0xa1 <= byteChar) && (byteChar <= 0xdf))
            {
                result = false;
                return result;
            }
            return result;
        }


        /// <summary>
        /// �@��ˑ������̔���
        /// </summary> 
        /// <param name="byteChar1">2byte������1byte��</param>
        /// <param name="byteChar2">2byte������1byte��</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �n���ꂽ�o�C�g�����񂪋@��ˑ������ł��邩���肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private bool CheckAddictWord(byte byteChar1, byte byteChar2)
        {
            bool result = false;

            // 13�� �E�E�E �@�A���� ��(�V�t�gJIS��0x8540 �` 0x889E)
            if ((0x85 <= byteChar1) && (byteChar1 <= 0x88)) //(133�`136 :10�i��)
            {
                if (((byteChar1 == 0x85) && (byteChar2 < 0x40)) || (byteChar1 == 0x88) && (byteChar2 > 0x9e))
                {
                    result = true;
                }
            }

            // 92�� �E�E�E ����Ȋ����A�@�A ��
            else if ((0xeb <= byteChar1) && (byteChar1 <= 0xef))
            {
                if (((byteChar1 == 0xeb) && (byteChar2 < 0x40)) || (byteChar1 == 0xef) && (byteChar2 > 0xfc))
                {
                    result = true;
                }
            }
            else if ((0xf0 <= byteChar1) && (byteChar2 >= 0x40))
            {

            }
            else
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region �@��ˑ������`�F�b�N����
        /// <summary>
		/// �@��ˑ������`�F�b�N����
		/// </summary> 
        /// <returns>����</returns>
		/// <remarks>
		/// <br>Note       : �@��ˑ������`�F�b�N���s���܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private bool TextCheckProc()
        {         
            bool result = false;

            this.Back_richTextBox.Text  = ""; 
            //PC�p���[������////////////////////////////////////////
            string text_pc = this.PcEditor_richTextBox.Text;
            //�����ʒu�ɖ߂�
            this.PcEditor_richTextBox.SelectAll();
            this.PcEditor_richTextBox.SelectionColor = Color.Black;
            this.PcEditor_richTextBox.Select( 0, 0 );
            //�`�F�b�N�Ɋ|������������index������B
            int[] halfKanaIndexes = null;
            int[] addictIndexes   = null;

            //�`�F�b�N���ʗp�t���O         
            bool checkResult_Pc             = true;

            checkResult_Pc  = CheckText(text_pc,ref halfKanaIndexes,ref addictIndexes);   
                                                         
            if(checkResult_Pc == true)
            {
                //����
                result = true;
            }
            else
            {                               
                //�m�F���b�Z�[�W
				DialogResult ret  = TMsgDisp.Show(
			    this,            
				emErrorLevel.ERR_LEVEL_INFO,                            // �G���[���x��
				PGID, 						                            // �A�Z���u���h�c�܂��̓N���X�h�c
				 "���͂��ꂽ���͒��ɋ@��ˑ�����(���p�ł�L��)���܂܂�Ă��܂��B"
                + System.Environment.NewLine
                + "���̂܂ܕۑ������𑱂��Ă�낵���ł����H",           // �\�����郁�b�Z�[�W
				0, 									                    // �X�e�[�^�X�l
				MessageBoxButtons.YesNo);				            // �\������{�^��

                if(ret == DialogResult.Yes)
                {
                    //�ۑ��������s
                    result = true;
                }
                else
                {
                    //�L�����Z��
                    //�L�����Z�����ɋ@��ˑ������̕����F��ύX���Ă݂�
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        //�����F�̂ݕύX
                        #region PC�p���̓`�F�b�N����
                        //�\�����Ă���RichText�ŏ������s�Ȃ��Ɖ�ʂ�������̂Ŕ�\����RichText���ŏ���
                        this.Back_richTextBox.Text  = this.PcEditor_richTextBox.Text;                               
                      
                            
                        //���p�Ł��S�p�J�i
                        if( halfKanaIndexes != null) 
                        {
                            for( int ix = 0; ix < halfKanaIndexes.Length; ix++ ) 
                            {                                                                                              
                                this.Back_richTextBox.SelectionStart  = halfKanaIndexes[ ix ];
                                this.Back_richTextBox.SelectionLength = 1;
                                this.Back_richTextBox.SelectionColor  = Color.Red;                                               
                            }
                        }
                        //�@��ˑ������̕����F��Black��Red�ɕύX
                        if( addictIndexes != null ) 
                        {
                            for( int ix = 0; ix < addictIndexes.Length; ix++ ) 
                            {                                                                
                                this.Back_richTextBox.SelectionStart  = addictIndexes[ ix ];
                                this.Back_richTextBox.SelectionLength = 1;                                  
                                this.Back_richTextBox.SelectionColor  = Color.Red;                
                            }
                        }
                       
                        
                        #endregion 

                        //�����F���K�v�Ȃ̂�Rtf�`���Ŗ߂�
                        this.PcEditor_richTextBox.Rtf = this.Back_richTextBox.Rtf;
                        this.PcEditor_richTextBox.SelectionColor = Color.Black;                                   
                    }
                    catch(Exception)
                    {
                        //�m�F���b�Z�[�W
                        TMsgDisp.Show(
                        this,            
                        emErrorLevel.ERR_LEVEL_STOP,                            // �G���[���x��
                        PGID, 						                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�����`�F�b�N�������ɗ�O���������܂���",               // �\�����郁�b�Z�[�W
                        -1, 								                    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);		                            // �\������{�^��
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                   
                }
            }          
            return result;
        }
        #endregion

        #region ImeMode�̏���������

        /// <summary>
		/// ImeMode�̏���������
		/// </summary>    		
		/// <remarks>
		/// <br>Note       : ImeMode�̏��������s���܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void ImeModeClear()
        {
            this.PcEditor_richTextBox.ImeMode       = ImeMode.Hiragana;
            //this.MobileEditor_richTextBox.ImeMode   = ImeMode.Hiragana;

            if(this._control != null)
            {
                //PC�p���[���^�C�g��
                if((TEdit)this._control == this.CarbonCopy_tEdit)
                {
                    //Ime��Off�ɂȂ��Ă���̂ň�xOn�ɂ��Ȃ��Ƒʖڂ݂����ł�
                    this.CarbonCopy_tEdit.ImeMode = ImeMode.On;
                    this.CarbonCopy_tEdit.ImeMode = ImeMode.Hiragana;
                }
                //�g�їp���[���^�C�g��
                if((TEdit)this._control == this.Address_tEdit)
                {
                    this.Address_tEdit.ImeMode = ImeMode.On;
                    this.Address_tEdit.ImeMode = ImeMode.Hiragana;
                }
                //���[�������t�@�C����
                //if((TEdit)this._control == this.EmailtextName_tEdit)
                //{
                //    this.EmailtextName_tEdit.ImeMode = ImeMode.On;
                //    this.EmailtextName_tEdit.ImeMode = ImeMode.Hiragana;
                //}

                //�v���r���[�N���p���[���^�C�g��
                if((TEdit)this._control == this.MailTitle_tEdit)
                {
                    this.MailTitle_tEdit.ImeMode = ImeMode.On;
                    this.MailTitle_tEdit.ImeMode = ImeMode.Hiragana;
                }
            }                                     
        }

        #endregion

        #region �N���p�����[�^�擾�f���Q�[�g�R�[��
        /// <summary>
        /// �N���p�����[�^�擾�f���Q�[�g�R�[��
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameterDelegateCall(out string param)
        {
            param = string.Empty;
            if (this.GetStartParameterEvent != null)
            {
                this.GetStartParameterEvent(out param);
            }
        }
        #endregion

        #endregion

        #region Event

        #region Load�C�x���g
        /// <summary>
        /// Form Load�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : Form�����[�h���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PMKHN07504UA_Load(object sender, EventArgs e)
        {
            //�}�X�����N�����̃c�[���o�[�ݒ�
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            //ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;             
            //TODO:�K�؂ȃA�C�R����ݒ肷��B               
            this.MainToolbarsManager.ImageListSmall = imageList16;
            this.MainToolbarsManager.Tools[TOOLBARMENU_END].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.MainToolbarsManager.Tools[TOOLBARMENU_SETUP].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            this.MainToolbarsManager.Tools[TOOLBARMENU_SEND].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MAIL;

            //��ʏ����ݒ菈��
            ScreenInitialSetting();

            this.Initial_Timer.Enabled = true;
        }

     
        #endregion
              
        #region RichTextBox_Enter�C�x���g
        /// <summary>
        /// RichTextBox_Enter �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : RichTextBox_Enter���A�N�e�B�u�ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PcEditor_richTextBox_Enter(object sender, EventArgs e)
        {                      
            //StatusBar�ɓ��͂���Ă��镶������\������
            SetWordsCountToUltraStatusBar(this.PcEditor_richTextBox);
            //IMEMode���Ђ炪�Ȃɂ���
            this.PcEditor_richTextBox.ImeMode = ImeMode.Hiragana;
        }
        #endregion

        #region RichTextBox_TextChanged�C�x���g
        /// <summary>
        /// RichTextBox_TextChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : Text�̃v���p�e�B�l���R���g���[���ŕύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PcEditor_richTextBox_TextChanged(object sender, EventArgs e)
        {           
            //�t�H���g��MS�S�V�b�N11.25�ɌŒ肵�܂��B
            //�\��t���Ȃǂ����ꂽ���̑Ή��B
            //�@�\�g�����āA�t�H���g�T�C�Y�̕ύX�Ȃǂ��\�ɂȂ�����͂����Ă�������
            //2006/10/26 Undo���@�\���Ȃ��Ȃ�̂ō폜
            this.PcEditor_richTextBox.Font = new Font("�l�r �S�V�b�N", 11.25F);               
            //this.PcEditor_richTextBox.SelectionColor = Color.Black; 
            //StatusBar�ɓ��͂���Ă��镶������\������
            SetWordsCountToUltraStatusBar(this.PcEditor_richTextBox);
        }
        #endregion

        #region RichTextBox_KeyDown�C�x���g
         /// <summary>
        /// RichTextBox_KeyDown�@�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : PcEditor_richTextBox���key�������ꂽ���ɔ���</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((RichTextBox)sender == this.PcEditor_richTextBox)
            {
                //SelectionColor��Black�Ŗ������Black���Z�b�g����B
                if(this.PcEditor_richTextBox.SelectionColor != Color.Black)
                {
                    this.PcEditor_richTextBox.SelectionColor = Color.Black;
                }
            }

            //�摜�f�[�^�̓\��t������      
            if ( e.Control )
            {
                if ( e.KeyCode == Keys.V )
                {                          
                    //�N���b�v�{�[�h�ɂ���f�[�^���e�L�X�g�`���ɕϊ��\���H
                    if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                    {                          
                       //�e�L�X�g�f�[�^�Ƃ��Ď��o��
                       object ob = Clipboard.GetDataObject().GetData(DataFormats.Text);
                       string words = ob.ToString();
                       if(this.PcEditor_richTextBox.Focused)
                       {
                           //richText����rtf�`���œǂݍ��ނ悤�Ȃ̂Ńe�L�X�g�`���ɕύX����
                           //�\��t����悤�ɂ��A�{���̏����̓L�����Z������
                           //�ő���͌����𒴂��Ă���ꍇ�͖���
                           if(this.maxCountPc > this.PcEditor_richTextBox.Text.Length)
                           {
                                //���݂̕������ƒǉ����镶�����̍��v���ő���͕������𒴂���ꍇ���L�����Z��
                                int totalLength = this.PcEditor_richTextBox.Text.Length + words.Length;
                                if(totalLength > this.maxCountPc)
                                {
                                    int overLength = totalLength - this.maxCountPc;
                                    string editWords = words.Remove(words.Length - overLength ,overLength);
                        �@�@        this.PcEditor_richTextBox.SelectedText = editWords;
                                }
                                else
                                {
                                    this.PcEditor_richTextBox.SelectedText = words;
                                }                              
                           }                          
                           //�{���̓\��t������������̂ł�����L�����Z������
                           e.Handled = true;
                       }
                    }
                    else
                    {
                        //bitmap���̉摜�f�[�^�̏ꍇ�̓L�����Z������B
                        e.Handled = true;
                    }
                }
            }

            //Control+Z�̑Ή�               
            if ( e.Control )
            {
                if ( e.KeyCode == Keys.Z )
                {
                    if((RichTextBox)sender == this.PcEditor_richTextBox)
                    {       
                        if(this.PcEditor_richTextBox.CanUndo)
                        {
                            this.PcEditor_richTextBox.Undo();
                        }
                      
                    }
                }
            }

        }
    
        #endregion

        #region tRetKeyControl1_ChangeFocus �C�x���g

        /// <summary>
        /// tRetKeyControl1_ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : EnterKey�ɂ��t�H�[�J�X���J�ڂ���Ăɔ������܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //�w�b�_�����̎擾
            switch (e.PrevCtrl.Name)
            {
                // �S���ҁi����j
                case "Address_tEdit":
                    {
                        // ���͒l�ύX�`�F�b�N
                        if (this._address_tEdit == this.Address_tEdit.Text.Trim())
                        {
                            break;
                        }

                        bool canChangeFocus = true;
                        string code = this.Address_tEdit.Text.Trim();
                        string name = this.Address_tEdit.Text.Trim();
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
                                name = employee.Name.Trim();
                                this.mailAddressList.Clear();
                                this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                if (employeeDtl.MailAddress2 == string.Empty)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "�g�їp���[���A�h���X���ݒ肳��Ă��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                    //name = name + "<���[���A�h���X���ݒ�>";
                                }
                                //else
                                //{
                                //    name = name + "<" + employeeDtl.MailAddress2 + ">";
                                //}
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

                                //code = "";
                                canChangeFocus = false;
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

                                //code = "";
                                canChangeFocus = false;
                            }
                        }
                        else
                        {
                            // ���[���A�h���X�����
                            this.mailAddressList.Clear();
                            this.mailAddressList.Add(this.Address_tEdit.Text, this.Address_tEdit.Text);
                        }

                        // �R�[�h�E���̃Z�b�g
                        //this.tEdit_EmployeeCode.Text = code;
                        this.Address_tEdit.Text = name;

                        // ���͒l�̕ۑ�
                        this._address_tEdit = this.Address_tEdit.Text.Trim();
                        #endregion

                        #region NextCtrl����
                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.Address_tEdit.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_AddressGuide;
                                        }
                                        else if (this.CarbonCopy_tEdit.Enabled == true)
                                        {
                                            e.NextCtrl = this.CarbonCopy_tEdit;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.Subject_tEdit;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }

                // �S���ҁiCC�j
                case "CarbonCopy_tEdit":
                    {
                        // ���͒l�ύX�`�F�b�N
                        if (this._carbonCopy_tEdit == this.CarbonCopy_tEdit.Text.Trim())
                        {
                            break;
                        }

                        bool canChangeFocus = true;
                        string code = this.CarbonCopy_tEdit.Text.Trim();
                        string name = this.CarbonCopy_tEdit.Text.Trim();
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
                                name = employee.Name.Trim();
                                this.ccAddressList.Clear();
                                this.ccAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                if (employeeDtl.MailAddress2 == string.Empty)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "�g�їp���[���A�h���X���ݒ肳��Ă��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                    //name = name + "<���[���A�h���X���ݒ�>";
                                }
                                //else
                                //{
                                //    name = name + "<" + employeeDtl.MailAddress2 + ">";
                                //}
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

                                //code = "";
                                canChangeFocus = false;
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

                                //code = "";
                                canChangeFocus = false;
                            }
                        }
                        else
                        {
                            // ���[���A�h���X�����
                            this.ccAddressList.Clear();
                            this.ccAddressList.Add(this.CarbonCopy_tEdit.Text, this.CarbonCopy_tEdit.Text);
                        }

                        // �R�[�h�E���̃Z�b�g
                        //this.tEdit_EmployeeCode.Text = code;
                        this.CarbonCopy_tEdit.Text = name;

                        // ���͒l�̕ۑ�
                        this._carbonCopy_tEdit = this.CarbonCopy_tEdit.Text.Trim();
                        #endregion

                        #region NextCtrl����
                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.CarbonCopy_tEdit.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_CarbonCopyGuide;
                                        }
                                        else if (this.QRCodePath_tEdit.Visible == true)
                                        {
                                            e.NextCtrl = this.QRCodePath_tEdit;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.PcEditor_richTextBox;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
            }

            //PC�p���[�������̏ꍇ
            if(e.PrevCtrl == this.PcEditor_richTextBox)
            {
                //�G�f�B�^����EnterKey�������ꂽ�ꍇ
                if(e.Key == Keys.Enter)
                {
                    if(this.PcEditor_richTextBox.Text.Length < this.maxCountPc)
                    {
                        e.NextCtrl = null;
                        //���s������}�����܂�
                        this.PcEditor_richTextBox.SelectedText += System.Environment.NewLine;
                        this.PcEditor_richTextBox.AcceptsTab = true;
                    }
                   
                }
                //�G�f�B�^���� TabKey�������ꂽ�ꍇ
                else if(e.Key == Keys.Tab)
                {
                     if(this.PcEditor_richTextBox.Text.Length < this.maxCountPc)
                     {
                         //�^�u��}��
                         this.PcEditor_richTextBox.SelectedText += "\t";
                         e.NextCtrl = null;
                     }                   

                }
              
            }
        }

        #endregion

        #region MainToolbarsManager_ToolClick�C�x���g
        /// <summary>
        /// Main_ToolbarsManager_ToolClick�@�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : Main_ToolbarsManager���N���b�N���ꂽ���ɔ���</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void MainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //TEdit�Ƀt�H�[�J�X�������ԂŃK�C�h�����N�����A���̉�ʂɖ߂��
            //IME��off�ɂȂ��Ă���B
            //�����`�F�b�N�{�^�����������Ƀt�H�[�J�X���������R���g���[����ۑ�

            //�R���g���[���̏�����
            this._control = null;
            
            //PC�p���[���^�C�g���Ƀt�H�[�J�X���������ꍇ
            if(this.CarbonCopy_tEdit.Focused)
            {
                this._control = this.CarbonCopy_tEdit;
            }

            //�g�їp���[���^�C�g���Ƀt�H�[�J�X���������ꍇ
            if(this.Address_tEdit.Focused)
            {
                this._control = this.Address_tEdit;
            }
           
            //�v���r���[�N���p���[���^�C�g��
            if(this.MailTitle_tEdit.Focused)
            {
                this._control = this.MailTitle_tEdit;
            }
            
            switch(e.Tool.Key)
            {
                #region �I��
                case TOOLBARMENU_END:
                {
                    this.Close();
                    break;
                }
                #endregion

                #region �ݒ�
                case TOOLBARMENU_SETUP:
                {
                    if (this._userSetupFrm == null)
                        this._userSetupFrm = new PMKHN07504UB();

                    this._userSetupFrm.ShowDialog();
                    break;
                }
                #endregion

                #region ���M
                case TOOLBARMENU_SEND:
                {
                    //bool boolCheck = false;
                    //int cnt = 0;
                    int cntMail = 0;

                    #region ���[�����M
                    if (!this._isClickSendMail) break;
                    try
                    {
                        this._isClickSendMail = false;

                        // �@��ˑ������`�F�b�N
                        bool checkResult = TextCheckProc();

                        if (checkResult == false)
                        {
                            return;
                        }

                        // �{���`�F�b�N
                        if (this.PcEditor_richTextBox.Text == string.Empty)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, "�{���������͂ł�", 0, MessageBoxButtons.OK);
                            return;
                        }

                        // ���M��`�F�b�N
                        if ((this.Address_tEdit.Text != string.Empty) &&
                            (this.mailAddressList.Count != 0))
                        {
                            foreach (string values in this.mailAddressList.Values)
                            {
                                if (values.Trim() == string.Empty) continue;
                                if (values.Contains("@") == false) continue;
                                cntMail++;
                            }
                        }
                        if (cntMail == 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, "���M�Ώۂ�����܂���", 0, MessageBoxButtons.OK);
                            return;
                        }

                        // ���[�����쐬���܂�
                        MailSourceData mailSourceData = new MailSourceData();
                        DataSet mailDocMngSet = mailSourceData.CreateNewMailDataList();
                        int ix = 0;

                        DataRow row_Pc = mailDocMngSet.Tables[0].NewRow();
                        mailDocMngSet.Tables[0].Rows.Add(row_Pc);
                        mailDocMngSet.Tables[0].Rows[ix][MAILDOCUMENTCNTS]  = this.PcEditor_richTextBox.Text;   //���[���{��(PC)
                        mailDocMngSet.Tables[0].Rows[ix][MAILTITLE_TITLE]   = this.Subject_tEdit.Text;          //���[���^�C�g��(PC)

                        //mailDocMngSet.Tables[0].Rows[ix]["EnterpriseCode"] = this._enterpriseCode;    //��ƃR�[�h
                        mailDocMngSet.Tables[0].Rows[ix]["LogicalDeleteCode"] = 0;                      //�_���폜�敪
                        mailDocMngSet.Tables[0].Rows[ix]["MailSendCode1"] = 1;                          //���[�����M�敪�R�[�h(0�ȊO���Z�b�g)

                        mailDocMngSet.Tables[0].Rows[ix]["AttachFile"] = this.QRCodePath_tEdit.Text;    //�Y�t�t�@�C��

                        foreach (string values in this.mailAddressList.Values)
                        {
                            if (values.Trim() == string.Empty) continue;
                            if (values.Contains("@") == false) continue;
                            mailDocMngSet.Tables[0].Rows[ix]["MailAddress"] = values.Trim();            //���[���A�h���X
                            break;
                        }
                        foreach (string values in this.ccAddressList.Values)
                        {
                            if (values.Trim() == string.Empty) continue;
                            if (values.Contains("@") == false) continue;
                            mailDocMngSet.Tables[0].Rows[ix]["CarbonCopy"] = values.Trim();             //CC
                            break;
                        }
                        ix++;

                        //�������͂���Ă��Ȃ�
                        if (mailDocMngSet.Tables[0].Rows.Count == 0)
                        {
                            //�������Ȃ�
                            return;
                        }
                        else
                        {
                            mailSourceData.MailDataList = mailDocMngSet;
                        }

                        // ���[���𑗐M���܂�
                        //MailFactoryBase mailFactoryBase = new MailFactoryBase(MailServiceInfoCreateMode.Default);
                        //IMailSender _mailSender = mailFactoryBase.GetMailSenderInterface();

                        MailSenderOperationInfo mailSenderOperationInfo = new MailSenderOperationInfo(0);

                        // ���M�`�Ԃ�ݒ肵�܂�
                        // �v���O���X�o�[�̕\��
                        mailSenderOperationInfo.DispProgressDialog = true;
                        // �a�b�b���̑��M
                        //mailSenderOperationInfo.SendBccBackup = SendBCCBackup_CheckEditor.Checked;
                        mailSenderOperationInfo.SendBccBackup = false;
                        // �I�y���[�V�������[�h
                        mailSenderOperationInfo.OperationMode = 0; // �f�t�H���g�ݒ�
                        // �X�e�[�^�X�i�߂�l�j
                        mailSenderOperationInfo.SendStatus = 0;
                        // ���b�Z�[�W�i�߂�l�j
                        mailSenderOperationInfo.StatusMessage = "";

                        DateTime nowTime = Broadleaf.Library.Globarization.TDateTime.GetSFDateNow();
                        //int st = mailSender.SendMail(ref mailSenderOperationInfo, this._mailSourceData);
                        int st = _mailSender.SendMail(ref mailSenderOperationInfo, mailSourceData);
                        switch (st)
                        {
                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                {
                                    this.DialogResult = DialogResult.OK;

                                    // �{���̃e�L�X�g�o��
                                    string sNowDate = nowTime.Year.ToString("00") + nowTime.Month.ToString("00") + nowTime.Day.ToString("00");
                                    string sNowTime = nowTime.Hour.ToString("00") + nowTime.Minute.ToString("00");
                                    string fileName = "PMNSQR_" + sNowDate + "_" + sNowTime + nowTime.Second.ToString("00") + ".txt";
                                    string fullpath = _mailInfoSetting.FilePathNm;
                                    if ((fullpath.Trim() != string.Empty) && (fullpath.EndsWith("\\") == false))
                                    {
                                        fullpath = fullpath + "\\";
                                    }

                                    StreamWriter outfile = new StreamWriter(fullpath + fileName, true, Encoding.Default);
                                    outfile.Write(this.PcEditor_richTextBox.Text);
                                    outfile.Close();
                                    
                                    // ���O�̏o��
                                    MailHist mailHist = new MailHist();
                                    List<MailHist> mailHistList = new List<MailHist>();
                                    MailSendHistAcs mailSendHistAcs = new MailSendHistAcs();

                                    mailHist.FileName = fileName;                       //�{���t�@�C����
                                    mailHist.QRCode = this.QRCodePath_tEdit.Text;       //�Y�t�t�@�C��
                                    mailHist.TransmitDate = sNowDate;                   //���M���t
                                    mailHist.TransmitTime = sNowTime;                   //���M����
                                    mailHist.EmployeeName = string.Empty;
                                    foreach (string keys in this.mailAddressList.Keys)
                                    {
                                        if (keys.Trim() == string.Empty) continue;
                                        mailHist.EmployeeName = keys.Trim();            //��M��
                                        break;
                                    }
                                    mailHist.CCInfo = string.Empty;
                                    foreach (string keys in this.ccAddressList.Keys)
                                    {
                                        if (keys.Trim() == string.Empty) continue;
                                        mailHist.CCInfo = keys.Trim();                  //CC
                                        break;
                                    }
                                    mailHist.Title = this.Subject_tEdit.Text;           //����

                                    mailSendHistAcs.Read(out mailHistList);
                                    mailHistList.Add(mailHist);
                                    mailSendHistAcs.Write(mailHistList);

                                    // �I���`�F�b�N�J�n
                                    EndChk_Timer.Enabled = true;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                                        mailSenderOperationInfo.StatusMessage, st, MessageBoxButtons.OK);
                                    this.DialogResult = DialogResult.Abort;
                                    break;
                                }
                        }
                    }
                    finally
                    {
                        this._isClickSendMail = true;
                    }
                    #endregion

                    break;
                }
                #endregion

                #region ���̑�
                default:
                {
                    break;
                }
                #endregion
            }
        }
        
        #endregion

        #region Timer_Tick�C�x���g

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // �����l�t�H�[�J�X�ݒ�
            //this.PcEditor_richTextBox.Focus();
            this.Address_tEdit.Focus();

            // ��ʏ����ݒ菈��
            //�A�C�R��(��) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_AddressGuide.ImageList = imageList16;
            this.uButton_CarbonCopyGuide.ImageList = imageList16;
            this.uButton_QRCodePath.ImageList = imageList16;
            this.uButton_AddressGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_CarbonCopyGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_QRCodePath.Appearance.Image = Size16_Index.STAR1;

            //���[�����ݒ�}�X�^�Ǎ�
            int status = _mailInfoBase.GetMailInfoSetting(out _mailInfoSetting);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���[�����ݒ肪���o�^�ł��B\n�o�^��A�ēx�������ĉ������B",
                    -1,
                    MessageBoxButtons.OK);
                Close();
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���[�����ݒ�̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);
                Close();
            }

            //// ��ʏ����l�擾����
            ScreenReconstruction();
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(EndChk_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void EndChk_Timer_Tick(object sender, EventArgs e)
        {
            // ���[�����M��A�v���O�������I�����܂��B
            if (this._mailSender.SendEndFlg == true)
            {
                EndChk_Timer.Enabled = false;
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "���[�����M���������܂����B",
                //    -1,
                //    MessageBoxButtons.OK);
                Close();
            }
        }

        #endregion

        #region Form.Closing �C�x���g
        /// <summary>
		/// Form.Closing �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PMKHN07504UA_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion         

        #region �t�H�[���T�C�Y�ύX�C�x���g
        /// <summary>
        /// �t�H�[���T�C�Y�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKHN07504UA_Resize(object sender, EventArgs e)
        {
            // anchor�̐ݒ�ł͐��퓮�삵�Ȃ��������߂����ŕ��̒������s��
            this.Address_tEdit.Width = this.Size.Width - this._sizeDifferenceAddress;
            this.CarbonCopy_tEdit.Width = this.Size.Width - this._sizeDifferenceAddress;
            this.Subject_tEdit.Width = this.Size.Width - this._sizeDifferenceSubject;
            this.QRCodePath_tEdit.Width = this.Size.Width - this._sizeDifferenceQRCode;
        }
        #endregion

        #region �K�C�h�{�^�� �C�x���g
        /// <summary>
        /// �]�ƈ��K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_AddressGuide_Click(object sender, EventArgs e)
        {
            Employee employee;
            EmployeeDtl employeeDtl;

            // �]�ƈ��}�X�^�Ǎ�
            int status = _mailInfoBase.GetEmployeeGuid(out employee, out employeeDtl);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �]�ƈ��ڍ׃}�X�^�Ǎ�
                string name = employee.Name.Trim();
                this.mailAddressList.Clear();
                this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                if (employeeDtl.MailAddress2 == string.Empty)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�g�їp���[���A�h���X���ݒ肳��Ă��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    //name = name + "<���[���A�h���X���ݒ�>";
                }
                //else
                //{
                //    name = name + "<" + employeeDtl.MailAddress2 + ">";
                //}

                // �Z�b�g��`�F�b�N
                if ((UltraButton)sender == this.uButton_AddressGuide)
                {
                    Address_tEdit.Text = name;

                    // ���͒l�̕ۑ�
                    this._address_tEdit = this.Address_tEdit.Text.Trim();
                }
                else if ((UltraButton)sender == this.uButton_CarbonCopyGuide)
                {
                    CarbonCopy_tEdit.Text = name;

                    // ���͒l�̕ۑ�
                    this._carbonCopy_tEdit = this.CarbonCopy_tEdit.Text.Trim();
                }
            }
        }

        /// <summary>
        /// QR�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_QRCodePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = _mailInfoSetting.FilePathNm;
            openFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true ;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                QRCodePath_tEdit.Text = openFileDialog.FileName;
            }
        }

        #endregion

        #endregion

    }
}
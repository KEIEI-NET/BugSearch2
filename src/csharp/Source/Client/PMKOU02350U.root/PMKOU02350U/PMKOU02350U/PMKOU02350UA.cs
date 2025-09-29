//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\ UI�t�H�[���N���X
// �v���O�����T�v   : ���׍��ٕ\ UI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00  �쐬�S�� : 杍^
// �� �� ��  K2019/08/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���׍��ٕ\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���׍��ٕ\UI�t�H�[���N���X</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public partial class PMKOU02350UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���׍��ٕ\UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׍��ٕ\UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public PMKOU02350UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this.EnterpriseCd = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_�R�[�h�擾
            this.LoginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            // ���t�擾���i
            GateGetAccess = DateGetAcs.GetInstance();

            this.ArrGoodsDiffAccess = new ArrGoodsDiffAcs();
        }

        /// <summary>
        /// ���׍��ٕ\UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׍��ٕ\UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02350UA(string para)
        {
            if ("NUnit".Equals(para))
            {
                InitializeComponent();
            }
        }
        #endregion

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool CanExtractField = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool CanPdfField = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool CanPrintField = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool VisibledExtractButtonField = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool VisibledPdfButtonField = true;
        // ����{�^���\���L���v���p�e�B
        private bool VisibledPrintButtonField = true;

        #endregion �� Interface member

        // ��ƃR�[�h
        private string EnterpriseCd = "";

        // ���_�R�[�h
        private string LoginSectionCd = "";

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin ControlSreSkin = new ControlScreenSkin();

        // ���t�擾���i
        private DateGetAcs GateGetAccess;

        // ���׍��ٕ\�A�N�Z�X
        private ArrGoodsDiffAcs ArrGoodsDiffAccess;
        
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ClassID = "PMKOU02350UA";
        // �v���O����ID
        private const string PgId = "PMKOU02350U";
        // ���[����
        private const string PrintNm = "���׍��ٕ\";
        // ���[�L�[	
        private const string PrintKeyValue = "52a4913e-2c26-42b8-8ea9-3942c2ff9ff9";

        private const string InputError = "�̓��͂��s���ł��B";
        private const string NoInput = "����͂��ĉ������B";
        private const string NotFound = "�Y������f�[�^������܂���B";
        private const string NotFoundSupplier = "�����悪���݂��܂���B";
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
        #endregion

        # region �� Properties
        # region UOE������}�X�^�A�N�Z�X�N���X
        /// <summary>
        /// UOE������}�X�^�A�N�Z�X�N���X
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return ArrGoodsDiffAccess.uOESupplierAcs; }
        }
        # endregion
        # endregion �� Properties

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this.CanExtractField; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this.CanPdfField; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this.CanPrintField; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this.VisibledExtractButtonField; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this.VisibledPdfButtonField; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this.VisibledPrintButtonField; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this.EnterpriseCd;
            // �N��PGID
            printInfo.kidopgid = PgId;				

            // PDF�o�͗���p
            printInfo.key = PrintKeyValue;
            printInfo.prpnm = PrintNm;
            printInfo.PrintPaperSetCd = 0;

            // �v���r���[�L��:�L��
            printInfo.prevkbn = 1;
            // PDF��Ɨp�p�X
            printInfo.pdftemppath = string.Empty;                   

            // �����N���X
            ArrGoodsDiffCndtnWork extrInfo = new ArrGoodsDiffCndtnWork();

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            printInfo.jyoken = extrInfo;

            // ���[�I���K�C�h
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �Y���f�[�^�������ꍇ
            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, NotFound, 0);
            }
            return printInfo.status;
        }
        #endregion

        #region �� �N���X�C���X�^���X��
        /// <summary>
        /// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note �@�@  : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
            this.Show();
            return;
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return PrintKeyValue; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return PrintNm; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tde_InspectDateTime.SetDateTime(DateTime.Today);// ���i��
                this.tNedit_SupplierCd.Clear();// ������R�[�h
                this.uLabel_UOESupplierName.Text = string.Empty;// �����於
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateResult cdResult;

            //���i��
            if (CallCheckDate(out cdResult, ref tde_InspectDateTime) == false)
            {
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("���i��{0}", InputError);
                            errComponent = this.tde_InspectDateTime;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("���i��{0}", NoInput);
                            errComponent = this.tde_InspectDateTime;
                        }
                        break;
                }
                status = false;

            }

            return status;
        }

        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : 杍^</br>                                    
        /// <br>Date        : K2019/08/14</br>                                        
        /// </remarks>
        private void WordCopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // ���i���͐����ł͂Ȃ��ꍇ
            if (!this.IsNumber(this.tde_InspectDateTime.Controls["YearEdit"].Text)
                           || !this.IsNumber(this.tde_InspectDateTime.Controls["MonthEdit"].Text)
                           || !this.IsNumber(this.tde_InspectDateTime.Controls["DayEdit"].Text))
            {
                this.tde_InspectDateTime.Clear();
            }
            // ������
            if (!String.IsNullOrEmpty(this.tNedit_SupplierCd.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_SupplierCd.DataText))
            {
                this.tNedit_SupplierCd.Text = String.Empty;
                this.uLabel_UOESupplierName.Text = String.Empty;
            }
        }

        /// <summary>
        /// ��������������̃`�F�b�N
        /// </summary>
        /// <param name="inputStr">�`�F�b�N����</param>
        /// <returns>true:�������������� false:��������������܂���</returns>
        /// <remarks>
        /// <br>Note		: ���������`�F�b�N�����B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: K2019/08/14</br>
        /// </remarks>
        public bool IsNumber(string inputStr)
        {
            string reg = "^[0-9]*$";
            Regex regex = new Regex(reg);
            return regex.IsMatch(inputStr);
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo���i�������p �P�Ɓj
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = GateGetAccess.CheckDate(ref targetDateEdit);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <param name="extrInfo">���o�����N���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ArrGoodsDiffCndtnWork extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                extrInfo.EnterpriseCode = this.EnterpriseCd;

                // ���_�R�[�h
                extrInfo.LoginSectionCode = this.LoginSectionCd;

                // ���i��
                extrInfo.InspectDate = this.tde_InspectDateTime.GetDateTime();

                // ������
                extrInfo.UOESupplierCd = this.tNedit_SupplierCd.GetInt();
                extrInfo.UOESupplierNm = this.uLabel_UOESupplierName.Text.Trim();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #endregion �� ����O����
        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                PrintNm,						// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                PrintNm,						// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� �G���[���b�Z�[�W�\��
        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        # region �� ������K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// ������K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ������K�C�h�{�^���N���b�N�C�x���g�Ƃ��ɔ�������</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
        {
            int status = -1;
            // �C���X�^���X����
            UOESupplier uOESupplier = null;

            // �K�C�h�N��
            status = uOESupplierAcs.ExecuteGuid(EnterpriseCd, LoginSectionCd, out uOESupplier);

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd.SetInt(uOESupplier.UOESupplierCd);
                this.uLabel_UOESupplierName.Text = uOESupplier.UOESupplierName;
            }
        }
        # endregion �� ������K�C�h�{�^���N���b�N�C�x���g
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMKOU02350UA
        #region �� PMKOU02350UA_Load Event
        /// <summary>
        /// PMKOU02350UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        /// 
        private void PMKOU02350UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this.ControlSreSkin.LoadSkin();

            // ��ʃX�L���ύX
            this.ControlSreSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion
        #endregion �� PMKOU02350UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region �� GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }
        #endregion
        #endregion �� ueb_MainExplorerBar Event

        #region �� tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���L�[�ATAB�L�[�AENTER�L�[���������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            
            bool canChangeFocus;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tde_InspectDateTime":
                    // Coopy�`�F�b�N
                    WordCopyCheck();
                    break;

                case "tNedit_SupplierCd":
                    #region [ tNedit_SupplierCd ]
                    canChangeFocus = true;
                    // Coopy�`�F�b�N
                    WordCopyCheck();

                    int code = this.tNedit_SupplierCd.GetInt();

                    //������N���A
                    if (code == 0)
                    {
                        this.uLabel_UOESupplierName.Text = "";
                    }
                    else if (ArrGoodsDiffAccess.UOESupplierExists(code) == true)
                    {
                        //���̃Z�b�g
                        string uoeSupplierName = ArrGoodsDiffAccess.GetName_FromUOESupplier(code).Trim();
                        this.uLabel_UOESupplierName.Text = uoeSupplierName;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            NotFoundSupplier,
                            -1,
                            MessageBoxButtons.OK);
                        this.tNedit_SupplierCd.Text = String.Empty;
                        this.uLabel_UOESupplierName.Text = String.Empty;
                        canChangeFocus = false;
                    }

                    // NextCtrl����
                    if (canChangeFocus)
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SupplierCd.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_UOESupplierGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tde_InspectDateTime;
                                        }
                                        break;
                                    }
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
        #endregion
        #endregion �� Control Event

        #region �� Initialize_Timer
        #region �� Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʏ������^�C�}�C�x���g�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R���g���[��������
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // �K�C�h�{�^���̃A�C�R���ݒ�
                this.SetIconImage(this.uButton_UOESupplierGuide, Size16_Index.STAR1);
                ParentToolbarSettingEvent(this);	// �c�[���o�[�ݒ�C�x���g
            }
            finally
            {
                // �����t�H�[�J�X
                this.tde_InspectDateTime.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion �� Initialize_Timer
    }
}

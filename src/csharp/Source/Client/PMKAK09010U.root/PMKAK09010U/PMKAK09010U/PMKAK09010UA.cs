//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\ UI�t�H�[���N���X
// �v���O�����T�v   : �d���摍���}�X�^�ꗗ�\ UI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07   �C�����e : �V�K�쐬
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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    // <summary>
    /// �d���摍���}�X�^�ꗗ�\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���摍���}�X�^�ꗗ�\UI�t�H�[���N���X</br>
    /// <br>Programmer : FSI�����@�v</br>
    /// <br>Date       : 2012/09/07</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMKAK09010UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {

        #region �� Constructor
        /// <summary>
        /// �d���摍���}�X�^�ꗗ�\UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���摍���}�X�^�ꗗ�\UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// <br></br>
        /// </remarks>
        public PMKAK09010UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_���ݒ�A�d����A�N�Z�X�N���X�擾
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();

        }
        #endregion

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        #endregion �� Interface member

        // ���_�R�[�h
        private string _enterpriseCode = "";
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �K�C�h�p�A�N�Z�X�N���X
        // ���_���ݒ�}�X�^�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;
        // �d����}�X�^�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;
        
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMKAK09010UA";
        // �v���O����ID
        private const string ct_PGID = "PMKAK09010U";
        // ���[����
        private const string ct_PrintName = "�d���摍���}�X�^�ꗗ�\";
        // ���[�L�[	
        private const string ct_PrintKey = "55a4913e-2c26-42b8-8ea9-3942c2ff9ff9";
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            // �N��PGID
            printInfo.kidopgid = ct_PGID;				

            // PDF�o�͗���p
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // �v���r���[�L��:�L��
            printInfo.prevkbn = 1;
            // PDF��Ɨp�p�X
            printInfo.pdftemppath = string.Empty;                   

            // �����N���X
            SumSuppStPrintUIParaWork extrInfo = new SumSuppStPrintUIParaWork();

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
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
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
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
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
            get { return ct_PrintKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �������_
                this.tEdit_SectionCode_St.Clear();
                this.tEdit_SectionCode_Ed.Clear();
                // �����d����
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            int SectionCodeSt = 0;
            int SectionCodeEd = 99;
            int SupplierCdSt = 0;
            int SupplierCdEd = 999999;

            #region [���l�`�F�b�N]
            // �������_�J�n�����l���`�F�b�N
            if (!tEdit_SectionCode_St.Text.Equals(string.Empty) &&
                 !int.TryParse(tEdit_SectionCode_St.Text, out SectionCodeSt))
            {
                errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                errComponent = tEdit_SectionCode_St;
                status = false;
            }
            // �������_�I�������l���`�F�b�N
            else if (!tEdit_SectionCode_Ed.Text.Equals(string.Empty) &&
                     !int.TryParse(tEdit_SectionCode_Ed.Text, out SectionCodeEd))
            {
                errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                errComponent = tEdit_SectionCode_Ed;
                status = false;
            }
            // �����d����J�n�����l���`�F�b�N
            else if (!tNedit_SupplierCd_St.Text.Equals(string.Empty) &&
                 !int.TryParse(tNedit_SupplierCd_St.Text, out SupplierCdSt))
            {
                errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                errComponent = tNedit_SupplierCd_St;
                status = false;
            }
            // �����d����I�������l���`�F�b�N
            else if (!tNedit_SupplierCd_Ed.Text.Equals(string.Empty) &&
                     !int.TryParse(tNedit_SupplierCd_Ed.Text, out SupplierCdEd))
            {
                errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                errComponent = tNedit_SupplierCd_Ed;
                status = false;
            }
            #endregion

            #region [�����l�`�F�b�N]
            // �������_�J�n�����l�ŁA���̒l�ł��邩�`�F�b�N
            if (!tEdit_SectionCode_St.Text.Equals(string.Empty) &&
                 int.TryParse(tEdit_SectionCode_St.Text, out SectionCodeSt))
            {
                if (SectionCodeSt <= 0)
                {
                    errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                    errComponent = tEdit_SectionCode_St;
                    return false;
                }
            }
            // �������_�I�������l�ŁA���̒l�ł��邩�`�F�b�N
            else if (!tEdit_SectionCode_Ed.Text.Equals(string.Empty) &&
                     int.TryParse(tEdit_SectionCode_Ed.Text, out SectionCodeEd))
            {
                if (SectionCodeEd <= 0)
                {
                    errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                    errComponent = tEdit_SectionCode_Ed;
                    return false;
                }
            }
            // �����d����J�n�����l�ŁA���̒l�ł��邩�`�F�b�N
            else if (!tNedit_SupplierCd_St.Text.Equals(string.Empty) &&
                    int.TryParse(tNedit_SupplierCd_St.Text, out SupplierCdSt))
            {
                if (SupplierCdSt <= 0)
                {
                    errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                    errComponent = tNedit_SupplierCd_St;
                    return false;
                }
            }
            // �����d����I�������l�ŁA���̒l�ł��邩�`�F�b�N
            else if (!tNedit_SupplierCd_Ed.Text.Equals(string.Empty) &&
                     int.TryParse(tNedit_SupplierCd_Ed.Text, out SupplierCdEd))
            {
                if (SupplierCdEd <= 0)
                {
                    errMessage = "���͂��ꂽ�R�[�h���s���ł��B";
                    errComponent = tNedit_SupplierCd_Ed;
                    return false;
                }
            }
            #endregion
            
            #region [�召�`�F�b�N]
            // �������_�̑召�`�F�b�N
            if (SectionCodeEd < SectionCodeSt)
            {
                errMessage = "���͂��ꂽ�������_�͈̔͂��s���ł��B";
                errComponent = tEdit_SectionCode_St;
                status = false;
            }
            // �����d����̑召�`�F�b�N
            else if (SupplierCdEd < SupplierCdSt)
            {
                errMessage = "���͂��ꂽ�����d����͈̔͂��s���ł��B";
                errComponent = tNedit_SupplierCd_St;
                status = false;
            }
            #endregion

            return status;
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">���o�����N���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(SumSuppStPrintUIParaWork extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                extrInfo.EnterpriseCode = this._enterpriseCode;

                // �������_�i�J�n�j
                if (this.tEdit_SectionCode_St.Text.Equals(string.Empty))
                {
                    extrInfo.SumSectionCodeSt = "";
                }
                else
                {
                    extrInfo.SumSectionCodeSt = this.tEdit_SectionCode_St.Text.ToString();
                }

                // �������_�i�I���j
                if (this.tEdit_SectionCode_Ed.Text.Equals(string.Empty))
                {
                    extrInfo.SumSectionCodeEd = "";
                }
                else
                {
                    extrInfo.SumSectionCodeEd = this.tEdit_SectionCode_Ed.Text.ToString();
                }

                // �����d����i�J�n�j
                if (this.tNedit_SupplierCd_St.Text.Equals(string.Empty))
                {
                    extrInfo.SumSupplierCdSt = 0;
                }
                else
                {
                    extrInfo.SumSupplierCdSt = int.Parse(this.tNedit_SupplierCd_St.Text);
                }

                // �����d����i�I���j
                if (this.tNedit_SupplierCd_Ed.Text.Equals(string.Empty))
                {
                    extrInfo.SumSupplierCdEd = 0;
                }
                else
                {
                    extrInfo.SumSupplierCdEd = int.Parse(this.tNedit_SupplierCd_Ed.Text);
                }

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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
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
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMKAK09010UA
        #region �� PMKAK09010UA_Load Event
        /// <summary>
        /// PMKAK09010UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        /// 
        private void PMKAK09010UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion
        #endregion �� PMZAI02020UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
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
        /// <br>Programmer  : FSI�����@�v</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }
        #endregion
        #endregion �� ueb_MainExplorerBar Event

        #region �� �K�C�h�{�^��
        /// <summary>�������_�J�n�K�C�h�{�^���C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �������_�J�n�K�C�h�{�^�����������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SectionCodeStartGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �擾�p�p�����[�^����
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                // �K�C�h���擾
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tEdit_SectionCode_St.Text = secInfoSet.SectionCode.Trim();
                    tEdit_SectionCode_Ed.Focus();
                }
            }
            catch
            {
            }

            return;
        }

        /// <summary>�������_�I���K�C�h�{�^���C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �������_�I���K�C�h�{�^�����������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SectionCodeEndGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �擾�p�p�����[�^����
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                // �K�C�h���擾
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tEdit_SectionCode_Ed.Text = secInfoSet.SectionCode.Trim();
                    tNedit_SupplierCd_St.Focus();
                }
            }
            catch
            {
            }

            return;
        }

        /// <summary>�����d����J�n�K�C�h�{�^���C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����d����J�n�K�C�h�{�^�����������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SupplierCodeStartGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �擾�p�p�����[�^����
            Supplier supplierInfo;

            try
            {
                // �K�C�h���擾
                status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tNedit_SupplierCd_St.SetInt(supplierInfo.SupplierCd);
                    tNedit_SupplierCd_Ed.Focus();
                }
            }
            catch
            {
            }
        }
        /// <summary>�����d����I���K�C�h�{�^���C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����d����I���K�C�h�{�^�����������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void ub_SupplierCodeEndGuideButton_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �擾�p�p�����[�^����
            Supplier supplierInfo;

            try
            {
                // �K�C�h���擾
                status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    tNedit_SupplierCd_Ed.SetInt(supplierInfo.SupplierCd);
                    tEdit_SectionCode_St.Focus();
                }
            }
            catch
            {
            }

            return;
        }
        #endregion

        #region �� tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���L�[�ATAB�L�[�AENTER�L�[���������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // �������_(�J�n)���������_(�I��)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // �������_(�I��)�������d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �����d����(�J�n)�������d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �����d����(�I��)���������_(�J�n)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �����d����(�I��)�������d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �����d����(�J�n)���������_(�I��)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // �������_(�I��)���������_(�J�n)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // �������_(�J�n)�������d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                }
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
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
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
                this.SetIconImage(this.ub_SectionCodeStartGuideButton, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SectionCodeEndGuideButton, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SupplierCodeStartGuideButton, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SupplierCodeEndGuideButton, Size16_Index.STAR1);

                ParentToolbarSettingEvent(this);	// �c�[���o�[�ݒ�C�x���g
            }
            finally
            {
                // �����t�H�[�J�X
                this.tEdit_SectionCode_St.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion �� Initialize_Timer



    }
}

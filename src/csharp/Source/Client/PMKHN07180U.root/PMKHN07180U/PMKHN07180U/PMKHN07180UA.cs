//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ʃ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���ʃ}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���ʃ}�X�^�i�G�N�X�|�[�g�j
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ʃ}�X�^�i�G�N�X�|�[�g�j�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public partial class PMKHN07180UA : Form, IExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07180UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _partsPosCodeExportAcs = new PartsPosCodeExportAcs();
            _partsPosCodeExportWork = new PartsPosCodeExportWork();
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
            
        }
        #endregion

        #region �� Private member
        // ���ʃ}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X
        private PartsPosCodeExportAcs _partsPosCodeExportAcs;
        // ���ʃ}�X�^�i�G�N�X�|�[�g�j�N���X
        private PartsPosCodeExportWork _partsPosCodeExportWork;

        // ��ƃR�[�h
        private string _enterpriseCode;

        private bool _customerGuid;

        #endregion �� Private member

        #region  �� Private cost
        //�G���[�������b�Z�[�W
        private const string ct_INPUTERROR = "���s���ł��B";
        private const string ct_NOINPUT = "����͂��Ă��������B";
        private const string ct_RANGEERROR = "�͈͎̔w��Ɍ�肪����܂��B";
        // �N���XID
        private const string ct_CLASSID = "PMKHN07180UA";

        private const string PMKHN07180U_PRPID = "PMKHN07180U.xml";
        private const string PRINTSET_TABLE = "PartsPosExp";
        #endregion

        #region �� IExportConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Method
        /// <summary>
        /// ����߰đO�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ����߰đO�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool ExportBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            // ���̓`�F�b�N����
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

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���o�f�[�^����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this.uLabel_OutPutNum.Text = "0";
            // ��ʁ����o�����N���X
            this.SetExtraInfoFromScreen();
            this.Bind_DataSet.Tables.Clear();
            DataTable dataTable;
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�G�N�X�|�[�g��";
            form.Message = "���݁A�f�[�^���G�N�X�|�[�g���ł��B";

            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                // ����
                status = this._partsPosCodeExportAcs.Search(_partsPosCodeExportWork, out dataTable);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }
           
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BL�R�[�h�N���X���f�[�^�Z�b�g�֓W�J����
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN07180U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ʃ}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._partsPosCodeExportAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07180U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.uiMemInput1.OptionCode = "0";
            // ��ʕ\��
            this.Show();
            return;
        }

        /// <summary>
        /// ����߰Ċ�������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ����߰Ċ����������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");
        }
        #endregion  �� Public Method
        #endregion �� IExportConditionInpType �����o

        #region �� Private Event
        #region �� �K�C�h����
        /// <summary>
        /// ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�J�n)�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_CustomerCodeStGuid_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            if (_customerGuid)
            {
                Control nextControl = null;
                nextControl = this.tNedit_CustomerCode_Ed;
                // �t�H�[�J�X
                nextControl.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�(�J�n)�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�J�n)�K�C�h�N���b�N���ɔ����C�x���g</br>
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }


        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�I��)�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_CustomerCodeEdGuid_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            if (_customerGuid)
            {
                Control nextControl = null;
                nextControl = this.tNedit_PartsPosCode_St;
                // �t�H�[�J�X
                nextControl.Focus();
            }
        }
        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <remarks>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�J�n)�K�C�h�N���b�N���ɔ����C�x���g</br>
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

      
        #endregion

        #region �� �t�@�C���_�C�A���O
        /// <summary>
        /// CSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : CSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // �^�C�g���o�[�̕�����
                saveFileDialog.Title = "�o�̓t�@�C���I��";
                saveFileDialog.RestoreDirectory = true;

                if (String.IsNullOrEmpty(this.tEdit_TextFileName.Text.Trim()))
                {
                    saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }

                //�u�t�@�C���̎�ށv���w��
                saveFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }
        #endregion

        #region �� ChangeFocus
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���L�[�ł̃t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)������(�J�n)
                        e.NextCtrl = this.tNedit_PartsPosCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_PartsPosCode_St)
                    {
                        // ����(�J�n)������(�I��)
                        e.NextCtrl = this.tNedit_PartsPosCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PartsPosCode_Ed)
                    {
                        // ����(�I��)�� ÷��̧�ٖ�
                        e.NextCtrl = tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O�� ���Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)���t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_PartsPosCode_St)
                    {
                        // ����(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PartsPosCode_Ed)
                    {
                        // ����(�I��)�� ����(�J�n)
                        e.NextCtrl = tNedit_PartsPosCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� ����(�I��)
                        e.NextCtrl = this.tNedit_PartsPosCode_Ed;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O�� ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion�@�� Private Event

        #region �� Control Event
        /// <summary>
        /// PMKHN07180UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void PMKHN07180UA_Load(object sender, EventArgs e)
        {
            this.InitializeScreen();
            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N�� 
        }
        #endregion

        #region �� Private Method
        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        /// <summary>�G���[���b�Z�[�W�\������</summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                "���ʃ}�X�^�i����߰āj",			// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
                #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ��ʏ������������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ����
            this.tNedit_PartsPosCode_St.Clear();
            this.tNedit_PartsPosCode_Ed.Clear();
            // ���Ӑ�
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();

            this.SetIconImage(this.ub_CustomerCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput();
            this.tNedit_CustomerCode_St.Focus();

        }
        #endregion

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region �� ������񏈗�
        /// <summary>
        /// ������񏈗�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ������񏈗����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // ��ƃR�[�h
            _partsPosCodeExportWork.EnterpriseCode = this._enterpriseCode;
            // ���ʃR�[�h�J�n
            _partsPosCodeExportWork.SearchPartsPosCodeSt = this.tNedit_PartsPosCode_St.GetInt();

            // ���ʃR�[�h�I��
            _partsPosCodeExportWork.SearchPartsPosCodeEd = this.tNedit_PartsPosCode_Ed.GetInt();

            // ���Ӑ�R�[�h�J�n
            _partsPosCodeExportWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();

            // ���Ӑ�R�[�h�I��
            _partsPosCodeExportWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
        }
        #endregion

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // Coopy�`�F�b�N
            WordCoopyCheck();
            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = "�e�L�X�g�t�@�C��������͂��Ă��������B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            {
                errMessage = "CSV�t�@�C���p�X���s���ł��B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }
            // ���Ӑ�i�J�n�`�I���j
            if (!string.IsNullOrEmpty(this.tNedit_CustomerCode_St.DataText.TrimEnd())
                && !string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.DataText.TrimEnd()))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    errMessage = string.Format("���Ӑ�{0}", ct_RANGEERROR);
                    errComponent = this.tNedit_CustomerCode_St;
                    status = false;
                    return status;
                }
            }

            // ���ʁi�J�n�`�I���j
            if (!string.IsNullOrEmpty(this.tNedit_PartsPosCode_St.DataText.TrimEnd())
                && !string.IsNullOrEmpty(this.tNedit_PartsPosCode_Ed.DataText.TrimEnd()))
            {
                if (this.tNedit_PartsPosCode_St.GetInt() > this.tNedit_PartsPosCode_Ed.GetInt())
                {
                    errMessage = string.Format("����{0}", ct_RANGEERROR);
                    errComponent = this.tNedit_PartsPosCode_St;
                    status = false;
                    return status;
                }
            }
            
            return status;
        }

        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            int customerStCode = this.tNedit_CustomerCode_St.GetInt();
            int customerEdCode = this.tNedit_CustomerCode_Ed.GetInt();
            if (customerStCode == 0 && this.tNedit_CustomerCode_St.Text.Trim().Length > 0)
            {
                this.tNedit_CustomerCode_St.Text = String.Empty;
            }
            if (customerEdCode == 0 && this.tNedit_CustomerCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_CustomerCode_Ed.Text = String.Empty;
            }

            int partsPosStCode = this.tNedit_PartsPosCode_St.GetInt();
            int partsPosEdCode = this.tNedit_PartsPosCode_Ed.GetInt();
            if (partsPosStCode == 0 && this.tNedit_PartsPosCode_St.Text.Trim().Length > 0)
            {
                this.tNedit_PartsPosCode_St.Text = String.Empty;
            }
            if (partsPosEdCode == 0 && this.tNedit_PartsPosCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_PartsPosCode_Ed.Text = String.Empty;
            }
            
        }

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #endregion�@�� Private Method


    }
}
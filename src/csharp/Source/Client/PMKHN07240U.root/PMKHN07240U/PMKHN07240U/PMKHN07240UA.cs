//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �I���}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/23  �C�����e : PVCS252 �\�[�g���s��
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
    /// �I���}�X�^�i�G�N�X�|�[�g�j
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���}�X�^�i�G�N�X�|�[�g�j�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public partial class PMKHN07240UA : Form, IExportConditionInpType
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
        public PMKHN07240UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _inventoryExportAcs = new InventoryExportAcs();
            _inventoryExportWork = new InventoryExportWork();
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
            
        }
        #endregion

        #region �� Private member
        // �I���}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X
        private InventoryExportAcs _inventoryExportAcs;
        // �I���}�X�^�i�G�N�X�|�[�g�j�N���X
        private InventoryExportWork _inventoryExportWork;

        // ��ƃR�[�h
        private string _enterpriseCode;
        #endregion �� Private member

        #region  �� Private cost
        //�G���[�������b�Z�[�W
        private const string ct_INPUTERROR = "���s���ł��B";
        private const string ct_NOINPUT = "����͂��Ă��������B";
        private const string ct_RANGEERROR = "�͈͎̔w��Ɍ�肪����܂��B";
        // �N���XID
        private const string ct_CLASSID = "PMKHN07240UA";
        private const string PMKHN07240U_PRPID = "PMKHN07240U.xml";
        private const string PRINTSET_TABLE = "InventoryExp";
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
                status = this._inventoryExportAcs.Search(_inventoryExportWork, out dataTable);
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
                        // ADD 2009/06/23 --->>>
                        // �\�[�g���s��
                        this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Sort = "InventorySeqNoRF";
                        // ADD 2009/06/23 ---<<<
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN07240U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�I���}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._inventoryExportAcs, 				// �G���[�����������I�u�W�F�N�g
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
            printInfo.prpid = PMKHN07240U_PRPID;
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
        /// <br>Date        : 2009.04.01</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_InventorySeqCd_St)
                    {
                        // �I���ʔ�(�J�n)���I���ʔ�(�I��)
                        e.NextCtrl = this.tNedit_InventorySeqCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_InventorySeqCd_Ed)
                    {
                        // �I���ʔ�(�I��)��÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O�� �I���ʔ�(�J�n)
                        e.NextCtrl = this.tNedit_InventorySeqCd_St;
                    }

                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tNedit_InventorySeqCd_St)
                    {
                        // �I���ʔ�(�J�n)���t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tNedit_InventorySeqCd_Ed)
                    {
                        // �I���ʔ�(�I��)���I���ʔ�(�J�n)
                        e.NextCtrl = this.tNedit_InventorySeqCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �I���ʔ�(�I��)
                        e.NextCtrl = this.tNedit_InventorySeqCd_Ed;
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
        /// PMKHN07240UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void PMKHN07240UA_Load(object sender, EventArgs e)
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
                "�I���}�X�^�i����߰āj",			// �v���O��������
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
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // �I���ʔ�
            this.tNedit_InventorySeqCd_St.Clear();
            this.tNedit_InventorySeqCd_Ed.Clear();
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput();
            this.tNedit_InventorySeqCd_St.Focus();
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
        /// <param name="condtionWork">�������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ������񏈗����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // ��ƃR�[�h
            _inventoryExportWork.EnterpriseCode = this._enterpriseCode;
            // ���[�J�[�J�n
            _inventoryExportWork.InventorySeqNoSt = this.tNedit_InventorySeqCd_St.GetInt();

            // ���[�J�[�I��
            _inventoryExportWork.InventorySeqNoEd = this.tNedit_InventorySeqCd_Ed.GetInt();

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
            // �I���ʔ�
            if ((this.tNedit_InventorySeqCd_St.GetInt() != 0) &&
                (this.tNedit_InventorySeqCd_Ed.GetInt() != 0) &&
                this.tNedit_InventorySeqCd_St.GetInt() > this.tNedit_InventorySeqCd_Ed.GetInt())
            {
                errMessage = string.Format("�I���ʔ�{0}", ct_RANGEERROR);
                errComponent = this.tNedit_InventorySeqCd_St;
                status = false;
                return status;
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
            int goodsMakerStCode = this.tNedit_InventorySeqCd_St.GetInt();
            int goodsMakerEdCode = this.tNedit_InventorySeqCd_Ed.GetInt();
            if (goodsMakerStCode == 0 && this.tNedit_InventorySeqCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_InventorySeqCd_St.Text = String.Empty;
            }
            if (goodsMakerEdCode == 0 && this.tNedit_InventorySeqCd_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_InventorySeqCd_Ed.Text = String.Empty;
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
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
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
        private void tNedit_InventorySeqCd_St_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            int invertorySeqCdst = this.tNedit_InventorySeqCd_St.GetInt();
            if (invertorySeqCdst == 0)
            {
                this.tNedit_InventorySeqCd_St.Text = string.Empty;
            }
            else
            {
                this.tNedit_InventorySeqCd_St.Text = Convert.ToString(invertorySeqCdst);
            }
        }
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
        private void tNedit_InventorySeqCd_Ed_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            int invertorySeqCded = this.tNedit_InventorySeqCd_Ed.GetInt();
            if (invertorySeqCded == 0)
            {
                this.tNedit_InventorySeqCd_Ed.Text = string.Empty;
            }
            else
            {
                this.tNedit_InventorySeqCd_Ed.Text = Convert.ToString(invertorySeqCded);
            }
        }
        #endregion�@�� Private Method
    }
}
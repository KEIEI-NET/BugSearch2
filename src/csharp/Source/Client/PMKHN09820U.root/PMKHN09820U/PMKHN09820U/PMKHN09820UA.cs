//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �|���}�X�^�i�C���|�[�g�j�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�i�C���|�[�g�j UI�t�H�[���N���X</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br>UpdateNote : </br>
    /// <br></br>
    /// <br>Update Note: �|�����}�X�^�C���|�[�g�E�G�N�X�|�[�g�@�\�ǉ��Ή�</br>
    /// <br>Programmer : 30521 T.MOTOYAMA</br>
    /// <br>Date       : 2013.10.28</br>
    /// </remarks>
    public partial class PMKHN09820UA : Form, ICSVImportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �|���}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�i�C���|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09820UA()
        {
            InitializeComponent();

            // �|���}�X�^�i�C���|�[�g�j�̃A�N�Z�X
            this._DepsitMainRfImportAcs = new DepsitMainRfImportAcs();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--ICSVImportConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        #endregion �� Interface member
        // �|���}�X�^�i�C���|�[�g�j�̃A�N�Z�X
        private DepsitMainRfImportAcs _DepsitMainRfImportAcs;
        // ��ƃR�[�h
        private string _enterpriseCode = string.Empty;
        // �Ǎ�����
        private Int32 _readCnt = 0;
        // �쐬����
        private Int32 _addCnt = 0;
        // �G���[����
        private Int32 _errCnt = 0;
        // CSV���ڐ�
        private const Int32 _csvItemCnt = 24;
        #endregion �� Private Member

        #region �� Private Const
        // �N���XID
        private const string ct_ClassID = "PMKHN09820UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN09820U";
        // �v���O��������
        private const string ct_PGNAME = "�|���}�X�^�C���|�[�g";
        // �v�����g�L�[
        private const string ct_PRINTKEY = "39d707bb-f0b8-489f-b9e0-a95654b2998e";
        #endregion

        #region �� IImportConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Method
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
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
        /// �x�[�X�Ń`�F�b�N�������s�����ǂ����B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �x�[�X�Ń`�F�b�N�������s�����ǂ����B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public bool IsUseBaseCheck()
        {
            // �x�[�X�Ń`�F�b�N�������s���B
            return true;
        }

        /// <summary>
        /// �`�F�b�N�������e�L�X�g�t�@�C����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �`�F�b�N�������e�L�X�g�t�@�C������߂�B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public string ImportFileName()
        {
            return this.tEdit_TextFileName.DataText;
        }

        /// <summary>
        /// ���Ƀ`�F�b�N������Ύ�������B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���Ƀ`�F�b�N������Ύ�������A�Ȃ����True��߂�B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            // �������Ȃ�
            return true;
        }

        /// <summary>
        /// CSV�Ǎ����ڐ��`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �ǂݍ���CSV��1�s�ڂ̍��ڐ����Ó����ǂ����`�F�b�N������B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public bool ItemCntCheck(int csvDataRowCnt)
        {
            if (csvDataRowCnt != _csvItemCnt)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ���s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = Properties.Resources.LabelTxtInportNum;
            this.uLabel_AddCnt.Text = Properties.Resources.LabelTxtInportNum;
            this.uLabel_ErrCnt.Text = Properties.Resources.LabelTxtInportNum;
            // �e�L�X�g�t�@�C���̃t�H�[�J�X�̐ݒ�
            this.tEdit_TextFileName.Focus();
            return;
        }

        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="csvDataList">CSV�t�@�C��</param>
        /// <remarks>
        /// <br>Note	   : �C���|�[�g�������s���B��PG����R�[�������</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMsg = string.Empty;

            // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = Properties.Resources.TitleStrProgress;
            form.Message = Properties.Resources.MsgStrProgress;

            try
            {
                List<SetUpControlInfo> list = new List<SetUpControlInfo>();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, Properties.Resources.PrpID)))
                {
                    list = UserSettingController.DeserializeUserSetting<List<SetUpControlInfo>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, Properties.Resources.PrpID));
                }
                List<int[]> setUpControlInfoList = new List<int[]>();
                int[] setUpControlItem;
                for (int i = 0; i < list.Count; i++)
                {
                    setUpControlItem = new int[2] { list[i].ItemId, list[i].UpdateDiv };
                    setUpControlInfoList.Add(setUpControlItem);
                }

                // �_�C�A���O�\��
                form.Show();

                this.uLabel_ReadCnt.Text = Properties.Resources.LabelTxtInportNum;
                this.uLabel_AddCnt.Text = Properties.Resources.LabelTxtInportNum;
                this.uLabel_ErrCnt.Text = Properties.Resources.LabelTxtInportNum;

                // ���̎��_��csvDataList�̒���CSV�f�[�^�����̂܂܊i�[����Ă���
                // �`�F�b�NOK�̃��X�g
                List<string[]> checkOKArrList = null;

                // �f�[�^�Ó����`�F�b�N���s��
                // bool errFlg = this._DepsitMainRfImportAcs.ImportCheck(csvDataList, out checkOKArrList, out this._readCnt, out this._errCnt);            // Del 2013.10.28 T.MOTOYAMA
                bool errFlg = this._DepsitMainRfImportAcs.ImportCheck(csvDataList, out checkOKArrList, out this._readCnt, out this._errCnt, out errMsg);   // Add 2013.10.28 T.MOTOYAMA

                if (errFlg == true)
                {
                    // �f�[�^�̑Ó����`�F�b�N��NG�̏ꍇ��DB�ւ̃C���|�[�g�����͍s��Ȃ��̂ŃG���[�ݒ�
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                else
                {
                    // CSV�f�[�^��ݒ肷��
                    DepsitMainRfImportWorkTbl importWorkTbl = new DepsitMainRfImportWorkTbl();
                    importWorkTbl.EnterpriseCode = this._enterpriseCode;

                    // �f�[�^�`�F�b�N��̃��X�g���C���X�^���X�ɓn��
                    importWorkTbl.CsvDataInfoList = (List<string[]>)checkOKArrList;

                    // A�N���X��Import���\�b�h
                    // status = this._DepsitMainRfImportAcs.Import(importWorkTbl, out this._addCnt, out errMsg);  // Del 2013.10.28 T.MOTOYAMA
                    status = this._DepsitMainRfImportAcs.Import(importWorkTbl, (int)this.ultraOptionSet_TakeInCond.CheckedItem.DataValue, out this._addCnt, out this._errCnt, out errMsg);  // Add 2013.10.28 T.MOTOYAMA

                }
                // �_�C�A���O�����
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // �Ǎ�����
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0)
                        {
                            // �捞������ɉ�ʂ̐ݒ荀�ڂ�ۑ�����(PM7����)
                            this.uiMemInput1.WriteMemInput();

                            // �ǉ�����
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);

                            // �G���[����
                            this.uLabel_ErrCnt.Text = NumberFormat(this._errCnt);
                            
                            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                            if (errMsg != "")
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                        }
                        else
                        {
                            // �ǉ��������[���̏ꍇ�A���b�Z�[�W��\������
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, Properties.Resources.MsgStrNotExistData, 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, Properties.Resources.MsgStrAlreadyDelet, 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, Properties.Resources.MsgStrAlreadyUpdate, 0);
                        break;
                    //case (int)ConstantManagement.MethodResult.ctFNC_ERROR: // Del 2013.10.28 T.MOTOYAMA
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:       // Add 2013.10.28 T.MOTOYAMA
                        // �f�[�^�`�F�b�N��NG�ƂȂ����ꍇ
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, (int)ConstantManagement.MethodResult.ctFNC_ERROR);  // Add 2013.10.28 T.MOTOYAMA

                        #region Del 2013.10.28 T.MOTOYAMA
                        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
                        //if (this._errCnt > 0)
                        //{
                        //    // �f�[�^�d���̃G���[�ƂȂ��Ă�����ł͉������Ȃ�
                        //}
                        //else
                        //{
                        //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, Properties.Resources.MsgStrFailedImport, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        //}
                        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
                        #endregion
                        break;
                    default:
                        // �Ǎ�����
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0)
                        {
                            // �捞������ɉ�ʂ̐ݒ荀�ڂ�ۑ�����(PM7����)
                            this.uiMemInput1.WriteMemInput();

                            // �ǉ�����
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);

                            // �G���[����
                            this.uLabel_ErrCnt.Text = NumberFormat(this._errCnt);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            // �ǉ��������[���̏ꍇ�A���b�Z�[�W��\������
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, Properties.Resources.MsgStrNotExistData, 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, Properties.Resources.MsgStrFailedImport, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                form.Close();
            }
            return status;
        }

        #endregion �� Public Method

        #endregion �� IImportConditionInpType �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ÷��̧�ٖ�
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;

                this.ultraOptionSet_TakeInCond.CheckedIndex = 0; // Add 2013.10.28 T.MOTOYAMA 

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� ��ʏ���������

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer	: FSI���� �f��</br>
        /// <br>Date		: 2013/06/12</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.ultraOptionSet_TakeInCond);  // Add 2013.10.28 T.MOTOYAMA
            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;

            // ���Close���ɉ�ʏ���ۑ����Ȃ�(PM7����)
            this.uiMemInput1.WriteOnClose = false;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� �����̃t�H�[�}�b�g
        /// <summary>
        /// �����̃t�H�[�}�b�g
        /// </summary>
        /// <param name="number">����</param>
        /// <remarks>
        /// <br>Note		: �����̃t�H�[�}�b�g(999,999,999)��ϊ�����</br>
        /// <br>Programmer	: FSI���� �f��</br>
        /// <br>Date		: 2013/06/12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format(Properties.Resources.LabelFmtImportNum, number);
            }
            else
            {
                ret = number.ToString();
            }

            return ret;
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                Properties.Resources.ClassID,		// �A�Z���u���h�c�܂��̓N���X�h�c
                Properties.Resources.ProgramName,	// �v���O��������
                string.Empty, 						// ��������
                string.Empty,						// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + System.Environment.NewLine + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                Properties.Resources.ClassID,		// �A�Z���u���h�c�܂��̓N���X�h�c
                Properties.Resources.ProgramName,	// �v���O��������
                procnm, 							// ��������
                string.Empty,						// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion �� �G���[���b�Z�[�W�\������
        #endregion �� Private Method

        #region �� Control Event
        /// <summary>
        /// PMKHN09820UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09820UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }

        /// <summary>
        /// CSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : CSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : FSI���� �f��</br>
        /// <br>Date        : 2013/06/12</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // �^�C�g���o�[�̕�����
                openFileDialog.Title = "�C���|�[�g�t�@�C���I��";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }
                //�u�t�@�C���̎�ށv���w��
                openFileDialog.Filter = Properties.Resources.FilterStrLoadFileDialog;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = openFileDialog.FileName;
                }
            }
        }

        #region �t�H�[�J�X�ړ��C�x���g
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���L�[�ł̃t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���w�q</br>                                   
        /// <br>Date        : 2013/06/12</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �t�@�C���_�C�A���O�� ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �t�@�C���_�C�A���O���e�L�X�g�t�@�C����
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // �e�L�X�g�t�@�C������ �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                }
            }
        }
        #endregion
        #endregion �� Control Event

    }
}
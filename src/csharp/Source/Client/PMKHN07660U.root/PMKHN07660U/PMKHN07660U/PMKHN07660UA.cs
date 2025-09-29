//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�Ǘ����}�X�^�i�C���|�[�g�j�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/06/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2012/07/03  �C�����e : ���q�l�̎w�E�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/19  �C�����e : ��Q�ꗗ�̎w�ENO.110�̑Ή�
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�Ǘ����}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j UI�t�H�[���N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07660UA : Form, IImportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07660UA()
        {
            InitializeComponent();

            // ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃A�N�Z�X
            this._goodsMngImportAcs = new GoodsMngImportAcs();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--IImportConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        #endregion �� Interface member
        // ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃A�N�Z�X
        private GoodsMngImportAcs _goodsMngImportAcs;
        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // �Ǎ�����
        private Int32 _readCnt = 0;
        // �ǉ�����
        private Int32 _addCnt = 0;
        // �X�V����
        private Int32 _updCnt = 0;
        // �G���[����
        private Int32 _errCnt = 0;
        // �G���[���O�t�@�C���p�X
        private string textFilePath = "";
        //�G���[���O�t�@�C���p�X+�G���[���O�t�@�C����
        private string textFilePathName = "";

        #endregion �� Private Member

        #region �� Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "�ǉ��X�V";
        private const string ct_AddNm = "�ǉ�";
        private const string ct_UpdNm = "�X�V";
        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
        private const int ct_CheckCd = 0;
        private const int ct_NoCheckCd = 1;
        private const string ct_CheckNm = "����";
        private const string ct_NoCheckNm = "�Ȃ�";
        // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
        // �G���[���O���o�͂��鎞�A�m�F���b�Z�[�W
        private const string ERRORLOG_EXPORT_MSG = "�C���|�[�g�Ɏ��s�����s������܂��B\r\n{0}���Q�Ƃ��ĉ������B";
        // �e�[�u������
        private const string PRINTSET_TABLE = "GoodsMngExp";
        // �N���XID
        private const string ct_ClassID = "PMKHN07660UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07660U";
        // CSV����
        private string _printName = "���i�Ǘ����}�X�^�i�C���|�[�g�j";
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // ��ʕ\��
            this.Show();
            
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.uiMemInput1.OptionCode = "0";

            return;
        }

        /// <summary>
        /// �x�[�X�Ń`�F�b�N�������s�����ǂ����B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �x�[�X�Ń`�F�b�N�������s�����ǂ����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            // �������Ȃ�
            return true;
        }

        /// <summary>
        /// �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_ErroCnt.Text = "0";
            // �e�L�X�g�t�@�C���̃t�H�[�J�X�̐ݒ�
            this.tEdit_TextFileName.Focus();
            return;
        }

        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="csvDataList">CSV�t�@�C��</param>
        /// <remarks>
        /// <br>Note	   : �C���|�[�g�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

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

                return status;
            }

            try
            {
                // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "�C���|�[�g��";
                form.Message = "���݁A�f�[�^���C���|�[�g���ł��B";
                // �_�C�A���O�\��
                form.Show();

                this.uLabel_ReadCnt.Text = "0";
                this.uLabel_AddCnt.Text = "0";
                this.uLabel_UpdCnt.Text = "0";
                this.uLabel_ErroCnt.Text = "0";

                // �����敪��CSV�f�[�^��ݒ肷��
                ExtrInfo_GoodsMngImportWorkTbl importWorkTbl = new ExtrInfo_GoodsMngImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                importWorkTbl.CheckKbn = (int)this.tComboEditor_CheckKbn.Value;
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.ErrorLogFileName = this.tEdit_LogFileName.DataText.Trim();

                string errMsg = string.Empty;
                // �C���|�[�g����
                status = this._goodsMngImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out _errCnt, out errMsg);
                
                // �_�C�A���O�����
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // �Ǎ�����
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0 || this._updCnt > 0)
                        {
                            // �ǉ�����
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);
                            // �X�V����
                            this.uLabel_UpdCnt.Text = NumberFormat(this._updCnt);
                            //�G���[����
                            this.uLabel_ErroCnt.Text = NumberFormat(this._errCnt);
                            if (this._errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);
                            }
                        }
                        else
                        {
                            //�G���[����
                            this.uLabel_ErroCnt.Text = NumberFormat(this._errCnt);
                            if (this._errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);
                            }
                            // �ǉ������ƍX�V�������S�ă[���̏ꍇ�A���b�Z�[�W��\������
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y���f�[�^����", 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��폜����Ă��܂��B", 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��X�V����Ă��܂��B", 0);
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "���i�Ǘ����}�X�^�̃C���|�[�g�Ɏ��s���܂����B", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "���i�Ǘ����}�X�^�̃C���|�[�g�Ɏ��s���܂����B", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

            return status;
        }
        #endregion  �� Public Method
        #endregion �� IImportConditionInpType �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ProcessKbn.BeginUpdate();

                Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
                // �ǉ��X�V
                listItem0.DataValue = ct_AddUpdCd;
                listItem0.DisplayText = ct_AddUpdNm;

                // �ǉ�
                Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
                listItem1.DataValue = ct_AddCd;
                listItem1.DisplayText = ct_AddNm;

                // �X�V
                Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
                listItem2.DataValue = ct_UpdCd;
                listItem2.DisplayText = ct_UpdNm;

                this.tComboEditor_ProcessKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });

                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                this.tComboEditor_CheckKbn.BeginUpdate();

                // ����
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                listItem3.DataValue = ct_CheckCd;
                listItem3.DisplayText = ct_CheckNm;

                // �Ȃ�
                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_NoCheckCd;
                listItem4.DisplayText = ct_NoCheckNm;

                this.tComboEditor_CheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<

                // �u�ǉ��X�V�v��I������Ă��܂�
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                this.tComboEditor_CheckKbn.SelectedIndex = 0;
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                this.uButton_LogFileGuide.ImageList = IconResourceManagement.ImageList16;

                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                this.uButton_LogFileGuide.Appearance.Image = Size16_Index.STAR1;

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
                this.tComboEditor_CheckKbn.EndUpdate();
                // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2012/06/04</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388-------->>>>>
            saveCtrAry.Add(this.tComboEditor_CheckKbn);
            // ------------ADD �L�w�� 2012/07/19 FOR Redmine#30388---------<<<<<
            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2012/06/04</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format("{0:0,0}", number);
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion �� �G���[���b�Z�[�W�\������

        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            string fileName = tEdit_TextFileName.DataText.Trim();
            string errorLogFileName = tEdit_LogFileName.DataText.Trim();

            if (errorLogFileName == string.Empty)
            {
                errMessage = "�G���[���O�t�@�C��������͂��Ă��������B";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(errorLogFileName)))
            {
                //errMessage = "�G���[���O�t�@�C���p�X�s���ł��B";//---DEL 2012/07/03�@����
                errMessage = "CSV�t�@�C���p�X���s���ł��B";       //---ADD 2012/07/03�@����
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            string fileNameU = fileName.ToUpper();
            string fileNameL = fileName.ToLower();

            string errorLogFileNameU = errorLogFileName.ToUpper();
            string errorLogFileNameL = errorLogFileName.ToLower();

            if (fileNameU.Equals(errorLogFileNameU) || fileNameL.Equals(errorLogFileNameL))
            {
                errMessage = "�e�L�X�g�t�@�C�����ƃG���[���O�t�@�C�����͓���̎w��͏o���܂���B";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            return true;
        }
        #endregion �� ���̓`�F�b�N����
        #endregion �� Private Method

        #region �� Control Event
        /// <summary>
        /// PMKHN07620UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private void PMKHN07660UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2012/06/04</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // �^�C�g���o�[�̕�����
                openFileDialog.Title = "�捞�t�@�C���I��";
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
                openFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = openFileDialog.FileName;
                    if (openFileDialog.FileName != string.Empty)
                    {
                        this.tEdit_LogFileName.DataText = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf(".")) + "_Error" + openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf("."));
                    }
                }                
            }
        }

        /// <summary>
        /// �G���[���OCSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �G���[���OCSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2012/06/04</br>
        /// </remarks>
        private void uButton_LogFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // �^�C�g���o�[�̕�����
                openFileDialog.Title = "�G���[���O�t�@�C���I��";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_LogFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_LogFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_LogFileName.Text);
                }
                //�u�t�@�C���̎�ށv���w��
                openFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_LogFileName.DataText = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// �e�L�X�g�t�@�C�����ύX���ꂽ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�t�@�C�����ύX���ꂽ���������܂��B</br> 
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2012/06/04</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.tEdit_TextFileName.DataText != string.Empty)
                {
                    textFilePath = this.tEdit_TextFileName.DataText.Substring(0, this.tEdit_TextFileName.DataText.LastIndexOf('\\'));
                    string textFileUpName = this.tEdit_TextFileName.DataText.Substring(this.tEdit_TextFileName.DataText.LastIndexOf('\\') + 1, this.tEdit_TextFileName.DataText.Length - 5 - this.tEdit_TextFileName.DataText.LastIndexOf('\\'));
                    textFilePathName = textFilePath + "\\" + textFileUpName + "_Error.CSV";
                    this.tEdit_LogFileName.DataText = textFilePathName;
                }
            }
            catch
            {
                return;
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
        /// <br>Programmer  : ����</br>                                   
        /// <br>Date        : 2012/06/04</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // �����敪���e�L�X�g�t�@�C����
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // �e�L�X�g�t�@�C�������e�L�X�g�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �e�L�X�g�t�@�C���_�C�A���O�� �G���[���O�t�H���_��
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // �G���[���O�t�H���_���� ���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        // �e�L�X�g�t�@�C���_�C�A���O��  �����敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // �����敪�����O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        // ���O�t�@�C���_�C�A���O���G���[���O�t�H���_��
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // �G���[���O�t�H���_�����e�L�X�g�t�@�C����
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �e�L�X�g�t�@�C�������e�L�X�g�t�@�C���_�C�A���O
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // �e�L�X�g�t�@�C������ �����敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
            }
        }
        #endregion

        #endregion �� Control Event

    }
}
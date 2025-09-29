//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�C���|�[�g�j�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/06/12  �C�����e �F��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/06/28  �C�����e �F���������o�b�O�̑Ή��F�召�ʂɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/06/28  �C�����e �F���������o�b�O�̑Ή��F���O�t�@�C���`�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/06/28  �C�����e : ���������o�b�O�̑Ή��F���O�t�@�C���̖��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/03  �C�����e �F��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/20  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.108�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/26  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.119�̑Ή� ���b�Z�[�W�̏C��
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
using System.IO;// ADD  2012/06/12  ������ Redmine#30393

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2012/06/12 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
    /// <br>Update Note: 2012/06/28 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             ���������o�b�O�̑Ή��F�召�ʂɂ���</br>
    /// <br>Update Note: 2012/06/28 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             ���������o�b�O�̑Ή��F���O�t�@�C���`�ɂ���</br>
    /// <br>Update Note: 2012/06/28 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             ���������o�b�O�̑Ή��F���O�t�@�C���̖��ɂ���</br>
    /// <br>Update Note: 2012/07/03 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
    /// <br>Update Note: 2012/07/20 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
    /// <br>Update Note: 2012/07/26 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.119�̑Ή� ���b�Z�[�W�̏C��</br>
    /// </remarks>

    public partial class PMKHN07640UA : Form, IImportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07640UA()
        {
            InitializeComponent();

            // ���Ӑ�}�X�^�i�C���|�[�g�j�̃A�N�Z�X
            this._customerImportAcs = new CustomerImportAcs();

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
        // ���Ӑ�}�X�^�i�C���|�[�g�j�̃A�N�Z�X
        private CustomerImportAcs _customerImportAcs;
        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // �Ǎ�����
        private Int32 _readCnt = 0;
        // �ǉ�����
        private Int32 _addCnt = 0;
        // �X�V����
        private Int32 _updCnt = 0;
        //�G���[�X�V����
        private Int32 _logCnt = 0;// ADD  2012/06/12  ������ Redmine#30393
        #endregion �� Private Member

        #region �� Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "�ǉ��X�V";
        private const string ct_AddNm = "�ǉ�";
        private const string ct_UpdNm = "�X�V";

        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
        private const int ct_CheckCd = 0;
        private const int ct_UnCheckCd = 1;
        private const string ct_CheckCdNm = "����";
        private const string ct_UnCheckNm = "�Ȃ�";
        // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<
        // �N���XID
        private const string ct_ClassID = "PMKHN07640UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07640U";
        // CSV����
        private string _printName = "���Ӑ�}�X�^�i�C���|�[�g�j";
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            //�������Ȃ�
            return true;
        }

        /// <summary>
        /// �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ���s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_LogCnt.Text = "0";// ADD  2012/06/12  ������ Redmine#30393
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2012/06/28 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393  ���������o�b�O�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        /// <br>Update Note: 2012/07/26 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.119�̑Ή�</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
            string errMessage = "";
            Control errComponent = null;
            string errorFile = "";//ADD ������ 2012/06/28 FOR ���������o�b�O�̑Ή�
            // ���̓`�F�b�N����
            //if (!this.ScreenInputCheck(ref errMessage, ref errComponent))// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent, ref errorFile))// ADD  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
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

            // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<

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
                this.uLabel_LogCnt.Text = "0";// ADD  2012/06/12  ������ Redmine#30393
                // �����敪��CSV�f�[�^��ݒ肷��
                ExtrInfo_CustomerImportWorkTbl importWorkTbl = new ExtrInfo_CustomerImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.CheckKbn = (int)this.tComboEditor_CheckKbn.Value;// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                //importWorkTbl.ErrorLogFileName = this.tEdit_LogFileName.Text;// ADD  2012/06/12  ������ Redmine#30393// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�


                // --------------- ADD START 2012/06/28  ������ FOR ���������o�b�O�̑Ή�-------->>>>
                if (!string.IsNullOrEmpty(errorFile))
                {
                    importWorkTbl.ErrorLogFileName = errorFile;

                }
                else
                {
                    importWorkTbl.ErrorLogFileName = this.tEdit_LogFileName.Text;
                }
                // --------------- ADD END 2012/06/28  ������ FOR ���������o�b�O�̑Ή�--------<<<<
                string errMsg = string.Empty;
                // �C���|�[�g����
                // status = this._customerImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errMsg);// DEL  2012/06/12  ������ Redmine#30393
                status = this._customerImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out this._logCnt, out errMsg);// ADD  2012/06/12  ������ Redmine#30393 
                // �_�C�A���O�����
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // �Ǎ�����
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                        // �G���[����
                        this.uLabel_LogCnt.Text = NumberFormat(this._logCnt);
                        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                        if (this._addCnt > 0 || this._updCnt > 0)
                        {
                            // �ǉ�����
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);
                            // �X�V����
                            this.uLabel_UpdCnt.Text = NumberFormat(this._updCnt);
                            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                            //if (this._logCnt != 0)// DEL  2012/07/26  ������ Redmine#30393
                            if (this._logCnt > 0)// ADD  2012/07/26  ������ Redmine#30393
                            {
                                //�G���[����̏ꍇ�A���b�Z�[�W��\������
                                // MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�C���|�[�g�Ɏ��s�����s������܂��B\r\n" + this.tEdit_LogFileName.DataText + "���Q�Ƃ��ĉ������B", 0);// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�C���|�[�g�Ɏ��s�����s������܂��B\r\n" + importWorkTbl.ErrorLogFileName + "���Q�Ƃ��ĉ������B", 0);// ADD  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            }
                            // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                        }
                        else
                        {
                            // --------------- DEL START 2012/06/12 Redmine#30393 ������-------->>>>
                            //// �ǉ������ƍX�V�������S�ă[���̏ꍇ�A���b�Z�[�W��\������
                            //   MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y���f�[�^����", 0);
                            //   status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            // --------------- DEl END 2012/06/12 Redmine#30393 ������--------<<<<

                            // ------ DEL START 2012/07/26 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.119�̑Ή�-------->>>>
                            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                            //if (this._logCnt == 0)
                            //{ // �ǉ������ƍX�V�������S�ă[���̏ꍇ�A���b�Z�[�W��\������
                            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y���f�[�^����", 0);
                            //    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            //}
                            //else
                            //{
                            //    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�C���|�[�g�Ɏ��s�����s������܂��B\r\n" + this.tEdit_LogFileName.DataText + "���Q�Ƃ��ĉ������B", 0);// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
                            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�C���|�[�g�Ɏ��s�����s������܂��B\r\n" + importWorkTbl.ErrorLogFileName + "���Q�Ƃ��ĉ������B", 0);// ADD  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
                            //    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            //}
                            // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                            // ------ DEL END 2012/07/26 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.119�̑Ή�--------<<<<

                            // ------ ADD START 2012/07/26 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.119�̑Ή�-------->>>>
                            // �G���[����
                            this.uLabel_LogCnt.Text = NumberFormat(this._logCnt);
                            if (this._logCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�C���|�[�g�Ɏ��s�����s������܂��B\r\n" + importWorkTbl.ErrorLogFileName + "���Q�Ƃ��ĉ������B", 0);
                            }
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y���f�[�^����", 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            // ------ ADD END 2012/07/26 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.119�̑Ή�--------<<<<

                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��폜����Ă��܂��B", 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��X�V����Ă��܂��B", 0);
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "���Ӑ�}�X�^�̃C���|�[�g�Ɏ��s���܂����B", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "���Ӑ�}�X�^�̃C���|�[�g�Ɏ��s���܂����B", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        /// </remarks>

        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ProcessKbn.BeginUpdate();
                this.tComboEditor_CheckKbn.BeginUpdate(); // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
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

                // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                listItem3.DataValue = ct_CheckCd;
                listItem3.DisplayText = ct_CheckCdNm;

                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_UnCheckCd;
                listItem4.DisplayText = ct_UnCheckNm;

                this.tComboEditor_CheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });

                this.tComboEditor_CheckKbn.SelectedIndex = 0;
                // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<

                // �u�ǉ��X�V�v��I������Ă��܂�
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ÷��̧�ٖ�
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;

                // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                this.uButton_LogFileGuide.ImageList = IconResourceManagement.ImageList16;
                //�G���[���O�i�[�t�H���_
                this.uButton_LogFileGuide.Appearance.Image = Size16_Index.STAR1;
                // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                
                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
                this.tComboEditor_CheckKbn.EndUpdate();// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�

                // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                if (string.IsNullOrEmpty(this.tEdit_LogFileName.DataText.Trim()))
                {
                    this.tEdit_LogFileName.DataText = this.tEdit_TextFileName.DataText;
                }
                // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                
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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.05.12</br>
        /// <br>Update Note : 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 ��z�Č�</br>
        /// <br>              Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note : 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 ��z�Č�</br>
        /// <br>              Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            saveCtrAry.Add(this.tEdit_TextFileName);
            saveCtrAry.Add(this.tEdit_LogFileName);// ADD  2012/06/12  ������ Redmine#30393
            saveCtrAry.Add(this.tComboEditor_CheckKbn);// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.05.12</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
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
        #endregion �� Private Method
        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <param name="errorFile">�G���[���O�̃p�X</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2012/06/12</br>
        /// </remarks>
        //private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent, ref string errorFile)// ADD  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
        {
            bool status = true;

            string fileName = tEdit_TextFileName.DataText.Trim();
            string errorLogFileName = tEdit_LogFileName.DataText.Trim();

            //�p�X���͂��Ȃ��ꍇ
            if (errorLogFileName == string.Empty)
            {
                errMessage = "�G���[���O�t�@�C��������͂��Ă��������B";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }
            //�f�B���N�g�����݂��Ȃ��ꍇ
            int dir_index = errorLogFileName.LastIndexOf("\\");
            int file_index = errorLogFileName.LastIndexOf(".");
            if (!Directory.Exists(errorLogFileName))
            {
                //if (dir_index > 0 && file_index > 0 && errorLogFileName.Substring(file_index + 1).ToUpper().Equals("CSV"))// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
                if (dir_index > 0 && file_index > 0) // ADD  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
                {
                    string errorLogFileDir = string.Empty;
                    if (file_index > dir_index)
                    {
                        errorLogFileDir = errorLogFileName.Substring(0, dir_index);
                    }
                    else
                    {
                        errorLogFileDir = errorLogFileName;
                    }
                    if (!Directory.Exists(errorLogFileDir))
                    {
                        //errMessage = "�G���[���O�t�@�C���p�X���s���ł��B";//DEL 2012/07/03 Redmine#30393 ������
                        errMessage = "CSV�t�@�C���p�X���s���ł��B";//ADD 2012/07/03 Redmine#30393 ������
                        errComponent = this.tEdit_LogFileName;
                        status = false;
                        return status;
                    }
                }
                else
                {
                    //errMessage = "�G���[���O�t�@�C���p�X���s���ł��B";//DEL 2012/07/03 Redmine#30393 ������
                    errMessage = "CSV�t�@�C���p�X���s���ł��B";//ADD 2012/07/03 Redmine#30393 ������
                    errComponent = this.tEdit_LogFileName;
                    status = false;
                    return status;
                }
            }
            else
            {
                // --------------- DEL START 2012/06/28 ������ FOR ���������o�b�O�̑Ή�-------->>>>
                //if (dir_index + 1 == errorLogFileName.Length)
                //    this.tEdit_LogFileName.DataText = errorLogFileName + "_Error.CSV";
                //else
                //    this.tEdit_LogFileName.DataText = errorLogFileName + "\\_Error.CSV";
                // --------------- DEL END 2012/06/28 ������ FOR ���������o�b�O�̑Ή�--------<<<<
                // --------------- ADD START 2012/06/28 ������ FOR ���������o�b�O�̑Ή�-------->>>>
                if (dir_index + 1 == errorLogFileName.Length)
                {
                    errorFile = errorLogFileName + Guid.NewGuid().ToString() + ".CSV";
                }
                else
                {
                    this.tEdit_LogFileName.DataText = errorLogFileName + "\\";
                    errorFile = errorLogFileName + "\\" + Guid.NewGuid().ToString() + ".CSV";
                }
                // --------------- ADD END 2012/06/28 ������ FOR ���������o�b�O�̑Ή�--------<<<<
               

            }
            //�����p�X�̏ꍇ
            //if (fileName.Equals(errorLogFileName))// DEL  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
            if ((fileName.ToLower()).Equals(errorLogFileName.ToLower())) // ADD  2012/06/28  ������ FOR ���������o�b�O�̑Ή�
            {
                errMessage = "�e�L�X�g�t�@�C�����ƃG���[���O�t�@�C�����͓���̎w��͏o���܂���B";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            return true;
        }
        #endregion �� ���̓`�F�b�N����
        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
        #region �� Control Event
        /// <summary>
        /// PMKHN07640UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void PMKHN07640UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.05.12</br>
        /// <br>Update Note : 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 ��z�Č�</br>
        /// <br>              Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
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
                    this.tEdit_LogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim()); // ADD  2012/06/12  ������ Redmine#30393
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
        /// <br>Date        : 2009.06.03</br>                                       
        /// <br>Update Note : 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 ��z�Č�</br>
        /// <br>              Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note : 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00 ��z�Č�</br>
        /// <br>              Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
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
                        // ------ DEL START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                        //// �����敪���e�L�X�g�t�@�C����
                        //e.NextCtrl = this.tEdit_TextFileName;
                        // ------ DEL END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<
                        e.NextCtrl = this.tComboEditor_CheckKbn;// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                    }
                    // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                    else if (e.PrevCtrl == this.tComboEditor_CheckKbn)
                    {
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // --------------- DEL START 2012/06/12 Redmine#30393 ������-------->>>>
                        // �t�@�C���_�C�A���O��  �q��(�J�n)
                        // e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // --------------- DEL END 2012/06/12 Redmine#30393 ������--------<<<<
                        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                        // �t�@�C���_�C�A���O��  �G���[���O�t�@�C����
                        e.NextCtrl = this.tEdit_LogFileName;
                        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                    }
                    // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // �G���[���O�t�@�C������  �G���[���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �G���[���O�t�@�C���_�C�A���O��  �����敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // --------------- DEL START 2012/06/12 Redmine#30393 ������-------->>>>
                        // �����敪���t�@�C���_�C�A���O
                        //e.NextCtrl = this.uButton_TextFileGuide;
                        // --------------- DEl END 2012/06/12 Redmine#30393 ������--------<<<<
                        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                        // �����敪���G���[���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_LogFileGuide;
                        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                    }
                    // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        // �G���[���O�t�@�C���_�C�A���O���G���[���O�t�@�C����
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // �G���[���O�t�@�C�������t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �t�@�C���_�C�A���O���e�L�X�g�t�@�C����
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ------ DEL START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                        //// �e�L�X�g�t�@�C������ �����敪
                        //e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // ------ DEL END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<
                        e.NextCtrl = this.tComboEditor_CheckKbn;// ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
                    }
                    // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
                    else if (e.PrevCtrl == this.tComboEditor_CheckKbn)
                    {
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<
                }
            }
        }
        #endregion
        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        /// <summary>
        /// CSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : CSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2012/06/12</br>
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
        /// �G���[���O�i�[�t�H���_�l���ύX���ꂽ
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �G���[���O�i�[�t�H���_�l���ύX���ɔ������܂��B</br> 
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2012/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            this.tEdit_LogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim());
        }
        /// <summary>
        /// �G���[���O�t�@�C�����O�擾
        /// </summary>
        /// <param name="textName">�e�L�X�g�t�@�C�����O</param>
        /// <returns>�G���[���O�t�@�C�����O</returns>
        /// <remarks>
        /// <br>Note        : �G���[���O�t�@�C�����O�擾������s���B</br> 
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private string GetErroLogFileNameFromTextFileName(string textName)
        {
            string errorLogFileName = this.tEdit_LogFileName.DataText.Trim();
            if (string.IsNullOrEmpty(textName.Trim())) return errorLogFileName;
            try
            {
                string textFilePath = textName.Substring(0, textName.LastIndexOf('\\'));
                string textFileName = textName.Substring(textName.LastIndexOf('\\') + 1, textName.Length - 5 - textName.LastIndexOf('\\'));
                errorLogFileName = textFilePath + "\\" + textFileName + "_Error.CSV";
                return errorLogFileName;
            }
            catch
            {
                return errorLogFileName;
            }
        }
        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
        #endregion �� Control Event

       

    }
}
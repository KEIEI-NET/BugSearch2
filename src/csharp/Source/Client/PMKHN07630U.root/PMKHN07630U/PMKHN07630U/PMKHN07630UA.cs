//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�C���|�[�g�j�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/03/31  �C�����e : Mantis.15256 ���i�}�X�^�C���|�[�g�̑Ώۍ��ڐݒ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/12  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/27  �C�����e : ���������o�b�O�̑Ή��F�召�ʂɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/28  �C�����e : ���������o�b�O�̑Ή��F�G���[���b�Z�[�W�s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/28  �C�����e : ���������o�b�O�̑Ή��F���O�t�@�C���`�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/29  �C�����e : ���������o�b�O�̑Ή��F���O�t�@�C���̖��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/03  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�
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
// 2010/03/31 Add >>>
using System.IO;
using Broadleaf.Application.Resources;
// 2010/03/31 Add <<<
using Broadleaf.Application.Remoting.ParamData; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>UpdateNote : </br>
    /// <br>Update Note: 2012/07/20 wangf </br>
    /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
    /// </remarks>
    public partial class PMKHN07630UA : Form, IImportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07630UA()
        {
            InitializeComponent();

            // ���i�}�X�^�i�C���|�[�g�j�̃A�N�Z�X
            this._goodsUImportAcs = new GoodsUImportAcs();

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
        // ���i�}�X�^�i�C���|�[�g�j�̃A�N�Z�X
        private GoodsUImportAcs _goodsUImportAcs;
        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // �Ǎ�����
        private Int32 _readCnt = 0;
        // �ǉ�����
        private Int32 _addCnt = 0;
        // �X�V����
        private Int32 _updCnt = 0;
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        // ���t�擾���i
        private DateGetAcs _dateGetAcs;
        // �����`�F�b�N���i
        private TotalDayCalculator _totalDayCalculator;
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        #endregion �� Private Member

        #region �� Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "�ǉ��X�V";
        private const string ct_AddNm = "�ǉ�";
        private const string ct_UpdNm = "�X�V";
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
        private const int ct_DataCheckOn = 0;
        private const int ct_DataCheckOff = 1;
        private const string ct_DataCheckOnNm = "����";
        private const string ct_DataCheckOffNm = "�Ȃ�";
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        // �G���[���O���o�͂��鎞�A�m�F���b�Z�[�W
        private const string ERRORLOG_EXPORT_MSG = "�C���|�[�g�Ɏ��s�����s������܂��B\r\n{0}���Q�Ƃ��ĉ������B";
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // �N���XID
        private const string ct_ClassID = "PMKHN07630UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07630U";
        // CSV����
        private string _printName = "���i�}�X�^�i�C���|�[�g�j";
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
            // �������Ȃ�
            return true;
        }

        /// <summary>
        /// �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �x�[�X�Ƀ`�F�b�N�G���[������΁A�t�H�[�J�X�̐ݒ���s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_ErrorCnt.Text = "0"; // ADD wangf 2012/06/12 FOR Redmine#30387
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
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>

            string errMessage = "";
            Control errComponent = null;

            string errorLogPath = "";//ADD wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
            // ���̓`�F�b�N����
            //if (!this.ScreenInputCheck(ref errMessage, ref errComponent))//DEL wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
            if (!this.ScreenInputCheck(ref errMessage, out errorLogPath, ref errComponent))//ADD wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
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
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<

            try
            {
                // 2010/03/31 Add >>>
                List<SetUpControlInfo> list = new List<SetUpControlInfo>();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKHN07630U_Construction.XML")))
                {
                    list = UserSettingController.DeserializeUserSetting<List<SetUpControlInfo>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKHN07630U_Construction.XML"));
                }
                List<int[]> setUpControlInfoList = new List<int[]>();
                int[] setUpControlItem;
                for (int i = 0; i < list.Count; i++)
                {
                    setUpControlItem = new int[2] { list[i].ItemId, list[i].UpdateDiv };
                    setUpControlInfoList.Add(setUpControlItem);
                }
                // 2010/03/31 Add <<<

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
                this.uLabel_ErrorCnt.Text = "0"; // ADD wangf 2012/06/12 FOR Redmine#30387

                // �����敪��CSV�f�[�^��ݒ肷��
                ExtrInfo_GoodsUImportWorkTbl importWorkTbl = new ExtrInfo_GoodsUImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.SetUpInfoList = setUpControlInfoList; // 2010/03/31 Add
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                //importWorkTbl.ErrorLogFileName = this.tEdit_ErrorLogFileName.DataText.Trim();//DEL wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
                importWorkTbl.ErrorLogFileName = errorLogPath;//ADD wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
                importWorkTbl.PriceStartDate = this.GetPriceStartDate();
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                importWorkTbl.DataCheckKbn = (int)this.tComboEditor_DataCheckKbn.Value; // ADD wangf 2012/07/20 FOR Redmine#30387

                string errMsg = string.Empty;
                int errCnt = 0;  // ADD wangf 2012/06/12 FOR Redmine#30387
                // �C���|�[�g����
                //status = this._goodsUImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errMsg); // DEL wangf 2012/06/12 FOR Redmine#30387
                status = this._goodsUImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errCnt, out errMsg); // ADD wangf 2012/06/12 FOR Redmine#30387

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
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                            // �G���[����
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);// DEL wangf 2012/06/12 FOR Redmine#30387
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, this.tEdit_ErrorLogFileName.DataText.Trim()), 0);// ADD wangf 2012/06/12 FOR Redmine#30387
                            }
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                        }
                        else
                        {
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                            // �G���[����
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);
                            }
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
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
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "���i�}�X�^�̃C���|�[�g�Ɏ��s���܂����B", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "���i�}�X�^�̃C���|�[�g�Ɏ��s���܂����B", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
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
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
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

                // �u�ǉ��X�V�v��I������Ă��܂�
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                this.tComboEditor_DataCheckKbn.BeginUpdate();
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                // ����
                listItem3.DataValue = ct_DataCheckOn;
                listItem3.DisplayText = ct_DataCheckOnNm;
                // �Ȃ�
                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_DataCheckOff;
                listItem4.DisplayText = ct_DataCheckOffNm;
                this.tComboEditor_DataCheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });
                // �u����v��I������Ă��܂�
                this.tComboEditor_DataCheckKbn.SelectedIndex = 0;
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ÷��̧�ٖ�
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                // �G���[���O�t�@�C����
                this.uButton_ErrorLogFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ÷��̧�ٖ�
                this.uButton_ErrorLogFileGuide.Appearance.Image = Size16_Index.STAR1;
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
                this.tComboEditor_DataCheckKbn.EndUpdate(); // ADD wangf 2012/07/20 FOR Redmine#30387
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                if (string.IsNullOrEmpty(this.tEdit_ErrorLogFileName.DataText.Trim()))
                {
                    this.tEdit_ErrorLogFileName.DataText = this.tEdit_TextFileName.DataText;
                }
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
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
        /// <br>Update Note : 2012/06/12 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            saveCtrAry.Add(this.tEdit_TextFileName);
            saveCtrAry.Add(this.tEdit_ErrorLogFileName);�@// ADD wangf 2012/06/12 FOR Redmine#30387
            saveCtrAry.Add(this.tComboEditor_DataCheckKbn);�@// ADD wangf 2012/07/20 FOR Redmine#30387
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
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="filePath">�G���[���O�t�@�C���o�X</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: 2012/06/12</br>
        /// <br>Update Note : 2012/07/03 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// </remarks>
        //private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        private bool ScreenInputCheck(ref string errMessage,out string filePath, ref Control errComponent)
        {
            bool status = true;

            string fileName = tEdit_TextFileName.DataText.Trim();
            string errorLogFileName = tEdit_ErrorLogFileName.DataText.Trim();

            filePath = tEdit_ErrorLogFileName.DataText.Trim();//ADD wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
            //�p�X���͂��Ȃ��ꍇ
            if (errorLogFileName == string.Empty)
            {
                //errMessage = "�G���[���O�t�H���_����͂��Ă��������B";//DEL wangf 2012/06/28 FOR ���������o�b�O�̑Ή�
                errMessage = "�G���[���O�t�@�C��������͂��Ă��������B";//ADD wangf 2012/06/28 FOR ���������o�b�O�̑Ή�
                errComponent = this.tEdit_ErrorLogFileName;
                status = false;
                return status;
            }
            //�f�B���N�g�����݂��Ȃ��ꍇ
            int dir_index = errorLogFileName.LastIndexOf("\\");
            int file_index = errorLogFileName.LastIndexOf(".");
            if (!Directory.Exists(errorLogFileName))
            {
                //if (dir_index > 0 && file_index > 0 && errorLogFileName.Substring(file_index + 1).ToUpper().Equals("CSV"))//DEL wangf 2012/06/28 FOR ���������o�b�O�̑Ή�
                if (dir_index > 0 && file_index > 0)//ADD wangf 2012/06/28 FOR ���������o�b�O�̑Ή�
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
                        //errMessage = "�G���[���O�t�H���_�p�X�s���ł��B";//DEL wangf 2012/06/28 FOR ���������o�b�O�̑Ή�
                        //errMessage = "�G���[���O�t�@�C���p�X���s���ł��B";//ADD wangf 2012/06/28 FOR ���������o�b�O�̑Ή� // DEL wangf 2012/07/03 FOR Redmine#30387
                        errMessage = "CSV�t�@�C���p�X���s���ł��B"; // ADD wangf 2012/07/03 FOR Redmine#30387
                        errComponent = this.tEdit_ErrorLogFileName;
                        status = false;
                        return status;
                    }
                }
                else
                {
                    //errMessage = "�G���[���O�t�H���_�p�X�s���ł��B";//DEL wangf 2012/06/28 FOR ���������o�b�O�̑Ή�
                    //errMessage = "�G���[���O�t�@�C���p�X���s���ł��B";//ADD wangf 2012/06/28 FOR ���������o�b�O�̑Ή� // DEL wangf 2012/07/03 FOR Redmine#30387
                    errMessage = "CSV�t�@�C���p�X���s���ł��B"; // ADD wangf 2012/07/03 FOR Redmine#30387
                    errComponent = this.tEdit_ErrorLogFileName;
                    status = false;
                    return status;
                }
            }
            else
            {
                if (dir_index + 1 == errorLogFileName.Length)
                    //this.tEdit_ErrorLogFileName.DataText = errorLogFileName + "_Error.CSV";//DEL wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
                    filePath = errorLogFileName + Guid.NewGuid().ToString() + ".CSV";//ADD wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
                else
                    //this.tEdit_ErrorLogFileName.DataText = errorLogFileName + "\\_Error.CSV";//DEL wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
                    filePath = errorLogFileName + "\\" + Guid.NewGuid().ToString() + ".CSV";//ADD wangf 2012/06/29 FOR ���������o�b�O�̑Ή�
            }
            //�����p�X�̏ꍇ
            //if (fileName.Equals(errorLogFileName))//DEL wangf 2012/06/27 FOR ���������o�b�O�̑Ή�
            if (fileName.ToUpper().Equals(errorLogFileName.ToUpper()))//ADD wangf 2012/06/27 FOR ���������o�b�O�̑Ή�
            {
                errMessage = "�e�L�X�g�t�@�C�����ƃG���[���O�t�@�C�����͓���̎w��͏o���܂���B";
                errComponent = this.tEdit_ErrorLogFileName;
                status = false;
                return status;
            }

            return true;
        }
        #endregion �� ���̓`�F�b�N����
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        #endregion �� Private Method

        #region �� Control Event
        /// <summary>
        /// PMKHN07620UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void PMKHN07630UA_Load(object sender, EventArgs e)
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
        /// <br>Update Note : 2012/06/12 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
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
                    this.tEdit_ErrorLogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim()); // ADD wangf 2012/06/12 FOR Redmine#30387
                }
            }
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// <summary>
        /// �G���[���OCSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �G���[���OCSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private void uButton_ErrorLogFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // �^�C�g���o�[�̕�����
                openFileDialog.Title = "�G���[���O�t�@�C���I��";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_ErrorLogFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_ErrorLogFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_ErrorLogFileName.Text);
                }
                //�u�t�@�C���̎�ށv���w��
                openFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_ErrorLogFileName.DataText = openFileDialog.FileName;
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
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            this.tEdit_ErrorLogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim());
        }
        /// <summary>
        /// �G���[���O�t�@�C�����O�擾
        /// </summary>
        /// <param name="textName">�e�L�X�g�t�@�C�����O</param>
        /// <returns>�G���[���O�t�@�C�����O</returns>
        /// <remarks>
        /// <br>Note        : �G���[���O�t�@�C�����O�擾������s���B</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private string GetErroLogFileNameFromTextFileName(string textName)
        {
            string errorLogFileName = this.tEdit_ErrorLogFileName.DataText.Trim();
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
        /// <summary>
        /// ���i�J�n���擾����
        /// </summary>
        /// <returns>���i�J�n��</returns>
        /// <remarks>
        /// <br>Note        : ���i�J�n���擾�������s���B</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private DateTime GetPriceStartDate()
        {
            try
            {
                //--------------------------------------------------
                // �ʏ�́A�O�񌎎��X�V���̗���
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if (prevTotalDay != DateTime.MinValue)
                {
                    // �O�񌎎��X�V���̗���
                    return prevTotalDay.AddDays(1);
                }

                //--------------------------------------------------
                // �i���V�K�������Ĉ�x�������X�V�����Ă��Ȃ��悤�ȏꍇ�j����.�����
                //--------------------------------------------------
                if (_dateGetAcs == null)
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // �K���Ď擾����
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if (companyInf != null && companyInf.CompanyBiginDate != 0)
                {
                    _dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList);
                    if (startMonthDateList != null && startMonthDateList.Count > 0)
                    {
                        // ��������ŏ��̌��̊J�n��
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            // ���ʏ�͔������Ȃ�����������擾�ł��Ȃ������ꍇ�͊��������Ɠ��l�B
            return DateTime.Now;
        }
        /// <summary>
        /// �O�񌎎��X�V���擾����
        /// </summary>
        /// <returns>�O�񌎎��X�V��</returns>
        /// <remarks>
        /// <br>Note        : �O�񌎎��X�V���擾�������s���B</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private DateTime GetHisTotalDayMonthly()
        {
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // �����Z�o���W���[���̃L���b�V���N���A
            this._totalDayCalculator.ClearCache();

            // ���|�I�v�V��������
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // ���|�I�v�V��������
                // ���㌎���������A�d�������������̌Â��N���擾
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // ���㌎���������擾
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // �d�������������擾
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay);
                    }
                }
            }
            else
            {
                // ���|�I�v�V�����Ȃ�
                // ���㌎���������擾
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
            }

            return prevTotalDay;
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<

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
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
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
                        /* ------------DEL wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // �����敪���e�L�X�g�t�@�C����
                        e.NextCtrl = this.tEdit_TextFileName;
                        // ------------DEL wangf 2012/07/20 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // �����敪���`�F�b�N�敪
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                    if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // �`�F�b�N�敪��÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // �t�@�C���_�C�A���O��  �q��(�J�n)
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // �t�@�C���_�C�A���O��  �G���[���O�t�@�C����
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // �G���[���O�t�@�C������  �G���[���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_ErrorLogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �G���[���O�t�@�C���_�C�A���O��  �����敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // �����敪���t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                        // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // �����敪���G���[���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    else if (e.PrevCtrl == this.uButton_ErrorLogFileGuide)
                    {
                        // �G���[���O�t�@�C���_�C�A���O���G���[���O�t�@�C����
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // �G���[���O�t�@�C�������t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �t�@�C���_�C�A���O���e�L�X�g�t�@�C����
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        /* ------------DEL wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // �e�L�X�g�t�@�C������ �����敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // ------------DEL wangf 2012/07/20 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // �e�L�X�g�t�@�C������ �`�F�b�N�敪
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                    else if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // �`�F�b�N�敪�������敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                }
            }
        }
        #endregion
        #endregion �� Control Event

    }
}
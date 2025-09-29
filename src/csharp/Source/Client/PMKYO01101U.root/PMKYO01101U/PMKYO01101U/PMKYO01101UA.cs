//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/07/28  �C�����e : SCM�Ή� ���_�Ǘ�(10704767-00) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/24  �C�����e : Redmine #23808�\�[�X���r���[���ʂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/27  �C�����e : Redmine #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/29  �C�����e : Redmine #8136 ���_�Ǘ��^��M�����̒��`�F�b�N�����ύX
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Threading;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��M�f�[�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͂̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate     : ���m 2009.04.30 �f�[�^�ǉ�</br>
    /// <br>2008.05.21 men �V�K�쐬(DC.NS���痬�p)</br>
    /// </remarks>
    public partial class PMKYO01101UA : Form
    {

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// ��M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKYO01101UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoginName"];
            // ���O�C���S����
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();

            // ��ʏ�����
            this._dataReceiveInputAcs.ReadInitData();
            this._dataReceiveInputAcs.GetSecMngSendData(this._erterpriseCode);

            // ��ʃO���b�h
            this._dataReceiveResult = new PMKYO01101UB();
            this._dataReceiveCondition = new PMKYO01101UC();

            this._controlScreenSkin = new ControlScreenSkin();
        }

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private PMKYO01101UB _dataReceiveResult;
        private PMKYO01101UC _dataReceiveCondition;
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private Control _prevControl = null;									// ���݂̃R���g���[��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;            // �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;             // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ���O�C���S���Җ���
        private ControlScreenSkin _controlScreenSkin;
        private int _connectPointDiv = 0;
        private string _erterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        #endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region ��Const Members
        private const string ctTOOLBAR_BUTTONTOOL_CLOSE_KEY = "ButtonTool_Close";
        private const string ctTOOLBAR_BUTTONTOOL_UPDATE_KEY = "ButtonTool_Update";
        private const string ctTOOLBAR_BUTTONTOOL_CLEAR_KEY = "ButtonTool_Clear";

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        private void Clear()
        {
            // ��ʏ�����
            this._dataReceiveInputAcs.ReadInitData();
            this._dataReceiveInputAcs.GetSecMngSendData(this._erterpriseCode);
            // �O���b�h���X�V����
            this._dataReceiveInputAcs.DataSetAgain();

            // ��ʏ���������
            this._dataReceiveResult.Clear();
            this._dataReceiveCondition.Clear();

            // �O���b�h�ݒ�
            this._dataReceiveResult.uGrid_Result.DataSource = this._dataReceiveInputAcs.DataReceive.Tables["DataReceiveResult"];
            this._dataReceiveCondition.uGrid_Condition.DataSource = this._dataReceiveInputAcs.DataReceive.DataReceiveCondition;

            // �������t�H�[�J�X�ݒ�
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
        }

        /// <summary>
        /// ��ʕۑ�
        /// </summary>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
            if (this._dataReceiveCondition.uGrid_Condition.ActiveCell != null)
            {
                this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            // �ۑ��`�F�b�N
            bool check = this.CheckSaveData();

            if (!check)
            {
                return;
            }

            //ADD 2011/07/28 SCM�Ή�-���_�Ǘ� ----------------->>>>>
            ArrayList errMsgList;
            string errMsg = "";
            check = this._dataReceiveInputAcs.CheckData(out errMsgList, ref errMsg);
            if (!check)
            {
                PMKYO01101UD errForm = new PMKYO01101UD(errMsgList);  // ADD 2011/11/29

                if (errMsgList.Count > 0)
                {
                    //PMKYO01101UD errForm = new PMKYO01101UD(errMsgList);  // DEL 2011/11/29
                    //errForm.Show();     // DEL 2011/11/29
                    errForm.ShowDialog();  // ADD 2011/11/29
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        errMsg,
                        status,
                        MessageBoxButtons.OK);
                }

                // --- ADD 2011/11/29 --- >>>
                if (!errForm._continueFlg)
                {
                    return;
                }
                // --- ADD 2011/11/29 --- <<<
            }            
            //ADD 2011/07/28 SCM�Ή�-���_�Ǘ� -----------------<<<<<

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "��M������";
            msgForm.Message = "��M�������ł�";

            try
            {
                msgForm.Show();
                // �ύX����
                //status = this._dataReceiveInputAcs.SaveData(this._connectPointDiv);            // DEL 2011/11/29
                status = this._dataReceiveInputAcs.SaveData(errMsgList, this._connectPointDiv);  // ADD 2011/11/29
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                msgForm.Close();
            }


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    //"���o�Ώۂ̃f�[�^�����݂��܂���B",//DEL 2011/08/27  �C�����e : #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                    "��M�Ώۂ̃f�[�^�����݂��܂���B",//ADD 2011/08/27  �C�����e : #23890 ��M�f�[�^���Ȃ��ꍇ�ɂ���
                    status,
                    MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r\n"
                   + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                   status,
                   MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   "�r�������Ɏ��s���܂����B",
                   status,
                   MessageBoxButtons.OK);

            }
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N
        /// </summary>
        public bool CheckSaveData()
        {
            #region DEL 2011/07/28 SCM�Ή�-���_�Ǘ�
            //DEL 2011/07/28 SCM�Ή�-���_�Ǘ� -------------------------------------------------------------------------------------------------------<<<<< 
            //// �X�V���ʃ`�F�b�N
            //if (this._dataReceiveResult.uGrid_Result.Rows.Count == 0)
            //{
            //    TMsgDisp.Show(
            //      this,
            //      emErrorLevel.ERR_LEVEL_INFO,
            //      this.Name,
            //      "����M�Ώېݒ�}�X�^���ݒ肳��Ă��܂���B",
            //      -1,
            //      MessageBoxButtons.OK);
            //    return false;
            //}

            //// ���_�`�F�b�N
            //if (this._dataReceiveInputAcs.SecMngSetWorkList.Count == 0)
            //{
            //    TMsgDisp.Show(
            //      this,
            //      emErrorLevel.ERR_LEVEL_INFO,
            //      this.Name,
            //      "��M�Ώۋ��_���ݒ肳��Ă��܂���B",
            //      -1,
            //      MessageBoxButtons.OK);
            //    return false;
            //}

            //if (this._dataReceiveInputAcs.DataReceive.DataReceiveCondition != null)
            //{
            //    this.ultraTabControl2.Tabs[1].Selected = true;

            //    int rowIndex = 0;
            //    // ���_�`�F�b�N
            //    foreach (DataReceive.DataReceiveConditionRow row in this._dataReceiveInputAcs.DataReceive.DataReceiveCondition)
            //    {
            //        // �J�n���t�����̓`�F�b�N
            //        if (this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2].Value is DBNull)
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "���o�J�n���t�������͂ł��B",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2];
            //            return false;
            //        }

            //        // �J�n���Ԗ����̓`�F�b�N
            //        if (string.IsNullOrEmpty(this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[3].Value.ToString()))
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "���o�J�n���Ԃ������͂ł��B",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[3];
            //            return false;
            //        }

            //        // �I�����t�����̓`�F�b�N
            //        if (this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[4].Value is DBNull)
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "���o�I�����t�������͂ł��B",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[4];
            //            return false;
            //        }

            //        // �I�����Ԗ����̓`�F�b�N
            //        if (string.IsNullOrEmpty(this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[5].Value.ToString()))
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "���o�I�����Ԃ������͂ł��B",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[5];
            //            return false;
            //        }

            //        // ���Ԕ͈̓`�F�b�N
            //        // �V�b�N���ԃ`�F�b�N
                    
            //        APSecMngSetWork secMngSetWork = (APSecMngSetWork)this._dataReceiveInputAcs.SecMngSetWorkList[rowIndex];                    
            //        DateTime startDateTime = new DateTime();
            //        if (secMngSetWork..SyncExecDate.Year == row.ConditionStartDate.Year
            //            && secMngSetWork.SyncExecDate.Month == row.ConditionStartDate.Month
            //            && secMngSetWork.SyncExecDate.Day == row.ConditionStartDate.Day
            //            && secMngSetWork.SyncExecDate.Hour == Convert.ToInt32(row.ConditionStartTime.Substring(0, 2))
            //            && secMngSetWork.SyncExecDate.Minute == Convert.ToInt32(row.ConditionStartTime.Substring(3, 2))
            //            && secMngSetWork.SyncExecDate.Second == Convert.ToInt32(row.ConditionStartTime.Substring(6, 2)))
            //        {
            //            startDateTime = secMngSetWork.SyncExecDate;
            //        }
            //        else
            //        {
            //            startDateTime = new DateTime(row.ConditionStartDate.Year, row.ConditionStartDate.Month, row.ConditionStartDate.Day,
            //                Convert.ToInt32(row.ConditionStartTime.Substring(0, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(3, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(6, 2)));
            //        }
            //        DateTime endDateTime = new DateTime(row.ConditionEndDate.Year, row.ConditionEndDate.Month, row.ConditionEndDate.Day,
            //            Convert.ToInt32(row.ConditionEndTime.Substring(0, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(3, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(6, 2)));
            //        if (startDateTime > endDateTime)                    
            //        {
            //            TMsgDisp.Show(
            //               this,
            //               emErrorLevel.ERR_LEVEL_INFO,
            //               this.Name,
            //               "���o���t�͈̔͂��s���ł��B",
            //               -1,
            //               MessageBoxButtons.OK);
            //            this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2];
            //            return false;
            //        }

            //        // �����Ď擾����
            //        this._dataReceiveInputAcs.ReadInitData();

            //        bool isExistFlg = false;
            //        foreach (APSecMngSetWork secMngSet in this._dataReceiveInputAcs.SecMngSetWorkList)                   
            //        {
            //            if (secMngSet.SectionCode == row.ConditionSectionCd)
            //            {
            //                isExistFlg = true;
            //                secMngSetWork = secMngSet;
            //            }
            //        }

            //        // �擾�Ȃ��̏ꍇ
            //        if (!isExistFlg)
            //        {
            //            TMsgDisp.Show(
            //             this,
            //             emErrorLevel.ERR_LEVEL_INFO,
            //             this.Name,
            //             "��M�Ώۋ��_���ݒ肳��Ă��܂���B",
            //             -1,
            //             MessageBoxButtons.OK);
            //            return false;
            //        }

            //        // �J�n���t�̕ύX���͓��ꌎ���̂ݐݒ肪�\�ł�
            //        if (startDateTime < secMngSetWork.SyncExecDate)
            //        {
            //            if (startDateTime.Month != endDateTime.Month
            //                || startDateTime.Year != endDateTime.Year)
            //            {
            //                TMsgDisp.Show(
            //                  this,
            //                  emErrorLevel.ERR_LEVEL_INFO,
            //                  this.Name,
            //                  "�J�n���t�̕ύX���͓��ꌎ���̂ݐݒ肪�\�ł��B",
            //                  -1,
            //                  MessageBoxButtons.OK);
            //                this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[rowIndex].Cells[2];
            //                return false;
            //            }
            //        }                    
            //        rowIndex++;
            //    }

            //    this.ultraTabControl2.Tabs[0].Selected = true;
            //}
            //DEL 2011/07/28 SCM�Ή�-���_�Ǘ� -------------------------------------------------------------------------------------------------------<<<<<
            #endregion

            // �� 2009.04.30 liuyang add
            // �ڑ���`�F�b�N
            string errMessage = null;
            if (!_dataReceiveInputAcs.CheckConnect(_erterpriseCode, out _connectPointDiv, out errMessage, 0))
            {
                TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_INFO,
                  this.Name,
                  errMessage,
                  -1,
                  MessageBoxButtons.OK);
                return false;
            }
            return true;
            // �� 2009.04.30 liuyang add
        }
        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region ��Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKYO01101UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._dataReceiveResult);
            this._controlScreenSkin.SettingScreenSkin(this._dataReceiveCondition);

            // �O���b�h�ݒ�
            this.panel_Result.Controls.Add(this._dataReceiveResult);
            this.panel_Condition.Controls.Add(this._dataReceiveCondition);
            this._dataReceiveResult.Dock = DockStyle.Fill;
            this._dataReceiveCondition.Dock = DockStyle.Fill;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ��ʏ���������
            // this._dataReceiveInputAcs.ReadInitData();

            // ���׃O���b�h�ݒ�
            this._dataReceiveResult.Clear();
            this._dataReceiveCondition.Clear();

            // �������t�H�[�J�X�ݒ�
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];

            // �� 2009.04.30 liuyang add
            this.timer_Slide.Enabled = true;
            // �� 2009.04.30 liuyang add
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case ctTOOLBAR_BUTTONTOOL_CLOSE_KEY:
                    {
                        this.Close();
                        break;
                    }
                case ctTOOLBAR_BUTTONTOOL_UPDATE_KEY:
                    {
                        this.Save();
                        break;
                    }
                case ctTOOLBAR_BUTTONTOOL_CLEAR_KEY:
                    {
                        this.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            //DEL 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------>>>>>
            //switch (e.PrevCtrl.Name)
            //{
            //    case "uGrid_Condition":
            //        {
            //            switch (e.Key)
            //            {
            //                case Keys.Return:
            //                    {
            //                        if (this._dataReceiveCondition.uGrid_Condition.ActiveCell != null)
            //                        {
            //                            if (this._dataReceiveCondition.ReturnKeyDown())
            //                            {
            //                                e.NextCtrl = null;
            //                            }
            //                            else if (this._dataReceiveCondition.uGrid_Condition.Rows[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.Count - 1].Cells[5].Activated)
            //                            {
            //                                e.NextCtrl = null;
            //                                this._dataReceiveCondition.uGrid_Condition.Rows[0].Cells[2].Activate();
            //                                this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //                            }
            //                            else
            //                            {
            //                                e.NextCtrl = e.PrevCtrl;
            //                            }
            //                        }

            //                        break;
            //                    }
            //                case Keys.Tab:
            //                    {
            //                        if (this._dataReceiveCondition.ReturnKeyDown())
            //                        {
            //                            e.NextCtrl = null;
            //                        }
            //                        else if (this._dataReceiveCondition.uGrid_Condition.Rows[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.Count - 1].Cells[5].Activated)
            //                        {
            //                            e.NextCtrl = null;
            //                            this._dataReceiveCondition.uGrid_Condition.Rows[0].Cells[2].Activate();
            //                            this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //                        }
            //                        else
            //                        {
            //                            e.NextCtrl = e.PrevCtrl;
            //                        }

            //                        break;
            //                    }
            //            }
            //            break;
            //        }
            //}
            //DEL 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            if (e.Tab == this.ultraTabControl2.Tabs[1])
            {
                if (this._dataReceiveCondition.uGrid_Condition.Rows.Count != 0)
                {
                    this._dataReceiveCondition.uGrid_Condition.Focus();
                    this._dataReceiveCondition.uGrid_Condition.ActiveCell = this._dataReceiveCondition.uGrid_Condition.Rows[0].Cells[2];
                    this._dataReceiveCondition.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }

			// ADD 2011.08.24---------->>>>>
			if (e.Tab.Key.Equals("ReceivedInfo"))
			{
				ultraLabel1.Visible = true;
			}
			else
			{
				ultraLabel1.Visible = false;
			}
			// ADD 2011.08.24----------<<<<<
        }


        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_Slide_Tick(object sender, EventArgs e)
        {

            this.timer_Slide.Enabled = false;

            // �ڑ���`�F�b�N
            string errMsg = null;
            if (!_dataReceiveInputAcs.CheckConnect(LoginInfoAcquisition.EnterpriseCode, out _connectPointDiv, out errMsg, 0))
            {
                TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_INFO,
                  this.Name,
                  errMsg,
                  -1,
                  MessageBoxButtons.OK);
                return;
            }
        }

        #endregion
    }
}
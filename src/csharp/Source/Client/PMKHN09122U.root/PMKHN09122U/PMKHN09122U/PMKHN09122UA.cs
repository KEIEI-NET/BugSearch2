//****************************************************************************//
// �V�X�e��         : ���엚��\��
// �v���O��������   : ���엚��\�����C���t���[��
// �v���O�����T�v    : �Z�L�����e�B�Ǘ��̑��엚��\���^�G���[���O�\���݂̂Ɍ��肵���Q�Ɨp�o�f
//                  : �@�@���엚��\���̌Ăяo��
//                  : �@�A�G���[���O�\���̌Ăяo��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/02/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11202046-00 �쐬�S�� : ���V��
// �� �� ��  K2016/10/28 �C�����e : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00 �쐬�S�� : ���O
// �� �� ��  2021/12/15  �C�����e : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
// ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ---->>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Library.Windows.Forms;
// ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ----<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// ���엚��\�����C���t���[���̃t�H�[���N���X
	/// </summary>
    /// <remarks>
    /// <br>Note         : ���엚��\���E���O�\�����s���܂��B</br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2010.02.22</br>
    /// <br>Update Note  : K2016/10/28  ���V��</br>
    /// <br>�Ǘ��ԍ�     : 11202046-00</br>
    /// <br>             : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή�</br>
    /// <br>Update Note  : 2021/12/15  ���O</br>
    /// <br>�Ǘ��ԍ�     : 11770181-00</br>
    /// <br>             : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09122UA : Form
	{
        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ---------->>>>>
        private PMKHN09122UC PMKHN09122UCObj;
        /*DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ ----->>>>>
        /// <summary>�_�P�Y�Ƈ�-���엚��\���I�v�V����</summary>
        private PurchaseStatus ShinkiOperahistoryOpt;
        //DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ -----<<<<<*/
        /// <summary> �ݒ��� </summary>
        private ExtractionConditionSet ExtractionConditionSetObj;

        /// <summary>�ݒ�t�@�C����</summary>
        private const string CT_XML_FILE = "PMKHN09122U_UserSetting.xml";
        /// <summary>�v���O����ID</summary>
        private const string PROGRAM_ID = "PMKHN09122";
        /// <summary>�ُ�</summary>
        private const int ERROR_STATUS = -1;
        /// <summary>XML�t�@�C���G���[</summary>
        private const string MSG_START_ERR = "�ݒ�t�@�C��({0})�Ɍ�肪����܂��B�ݒ���e�𐳂����ݒ肵�A�ēx�N�����ĉ������B";
        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----------<<<<<
        //----- ADD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� ----->>>>>
        private const int MINTIME = 0;
        private const int HSEC = 3600;
        private const int MSEC = 60;
        private const int INPUTMAXHOUR = 30;
        //----- ADD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� -----<<<<<
        #region <�c�[���o�[/>
        
        #region <[����]�c�[���{�^��/>

        /// <summary>[����]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_CLOSE_KEY = "Close";
        /// <summary>[����]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_CLOSE_ICON_INDEX = (int)Size16_Index.CLOSE;

        /// <summary>
        /// ����c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>����c�[���{�^��</value>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_CLOSE_KEY]; }
        }

        #endregion  // <[����]�c�[���{�^��/>

        #region <[�\���X�V]�c�[���{�^��/>

        /// <summary>[�\���X�V]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_UPDATE_KEY = "Update";
        /// <summary>[�\���X�V]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_UPDATE_ICON_INDEX = (int)Size16_Index.VIEW;

        /// <summary>
        /// �\���X�V�c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>�\���X�V�c�[���{�^��</value>
        private ButtonTool UpdateToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_UPDATE_KEY]; }
        }

        #endregion  // <[�\���X�V]�c�[���{�^��/>

        #region <[�ۑ�]�c�[���{�^��/>

        /// <summary>�ۑ��c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_SAVE_KEY = "Save";
        /// <summary>�ۑ��c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_SAVE_ICON_INDEX = (int)Size16_Index.SAVE;

        /// <summary>
        /// �ۑ��c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>�ۑ��c�[���{�^��</value>
        private ButtonTool SaveToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_SAVE_KEY]; }
        }

        #endregion

        // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ---->>>>>
        #region <[�e�L�X�g�o��]�c�[���{�^��/>
        /// <summary>[�e�L�X�g�o��]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_TEXTOUT_KEY = "TextOut";
        /// <summary>[�e�L�X�g�o��]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_TEXTOUT_ICON_INDEX = (int)Size16_Index.CSVOUTPUT;

        /// <summary>
        /// �e�L�X�g�o�̓c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>�e�L�X�g�o�̓c�[���{�^��</value>
        private ButtonTool TextOutToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_TEXTOUT_KEY]; }
        }
        #endregion
        // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ----<<<<<

        /// <summary>
        /// �c�[���o�[��ToolClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  ���V��</br>
        /// <br>�Ǘ��ԍ�     : 11202046-00</br>
        /// <br>             : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή�</br>
        /// </remarks>
        private void mainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case TOOL_BUTTON_CLOSE_KEY: // [����]
                    {
                        Close();
                        break;
                    }
                case TOOL_BUTTON_UPDATE_KEY:// [�\���X�V]
                    {
                        #region <Guard Phrase/>

                        if (CurrentChildForm == null) break;

                        #endregion  // <Guard Phrase/>

                        CurrentChildForm.UpdateDisplay();
                        break;
                    }
                // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ---->>>>>
                case TOOL_BUTTON_TEXTOUT_KEY:
                    {
                        if (CurrentChildForm == null) break;

                        // �q�t�H�[��
                        this.PMKHN09122UCObj.GetSubForm = CurrentChildForm;

                        // �e�L�X�g�o�͊m�F��ʋN��
                        this.PMKHN09122UCObj.ShowDialog();
                        break;
                    }
                // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ----<<<<<
                // --- DEL m.suzuki 2010/02/22 ---------->>>>>
                //case TOOL_BUTTON_SAVE_KEY:  // [�ۑ�]
                //    {
                //        #region <Guard Phrase/>

                //        const string TEXT = "�ۑ����܂����H";   // LITERAL:
                //        const string CAPTION = "�m�F";          // LITERAL:
                //        if (!MessageBox.Show(
                //            TEXT, CAPTION,
                //            MessageBoxButtons.YesNo,
                //            MessageBoxIcon.Question).Equals(DialogResult.Yes)
                //        ) break;

                //        if (CurrentChildForm == null) break;

                //        #endregion  // <Guard Phrase/>

                //        if (!CurrentChildForm.Write().Equals((int)ResultCode.Normal))
                //        {
                //            MessageBox.Show(
                //                "�ۑ��Ɏ��s���܂����B", // LITERAL:
                //                "���Z�L�����e�B�Ǘ���", // LITERAL:
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information
                //            );
                //        }
                //        break;
                //    }
                // --- DEL m.suzuki 2010/02/22 ----------<<<<<
            }
        }

        #endregion  // <�c�[���o�[/>

        #region <�^�u/>

        /// <summary>�^�u�̃L�[�z��</summary>
        /// <remarks>�^�u��ǉ�����ꍇ�͂����ɒǉ�</remarks>
        private readonly string[] _entryTabKeys = new string[]
        {
            // TODO:�^�u��ǉ�����ꍇ�͂����ɒǉ�
            // --- DEL m.suzuki 2010/02/22 ---------->>>>>
            //TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY,
            //TabConfigForRef.SECURITY_MANAGEMENT_VIEW_KEY,
            // --- DEL m.suzuki 2010/02/22 ----------<<<<<
            TabConfigForRef.OPERATION_LOG_VIEW_KEY,
            TabConfigForRef.ERROR_LOG_VIEW_KEY
        };

        /// <summary>�^�u�\���̃}�b�v</summary>
        private readonly Dictionary<string, TabConfigForRef> _tabConfigMap = new Dictionary<string, TabConfigForRef>();

        /// <summary>
        /// ���݂̎q�t�H�[�����擾���܂��B
        /// </summary>
        /// <value>���݂̎q�t�H�[��</value>
        private ISecurityManagementForm CurrentChildForm
        {
            get { return this._tabConfigMap[this.mainTabControl.ActiveTab.Key].Form as ISecurityManagementForm; }
        }

        /// <summary>
        /// �^�u��SelectedTabChanged�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// �I���^�u�ɉ������c�[���o�[������s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  ���V��</br>
        /// <br>�Ǘ��ԍ�     : 11202046-00</br>
        /// <br>             : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή�</br>
        /// </remarks>
        private void mainTabControl_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            if (CurrentChildForm != null)
            {
                UpdateToolButton.SharedProps.Visible= CurrentChildForm.CanUpdateDisplay;
                SaveToolButton.SharedProps.Visible  = CurrentChildForm.CanWrite;
            }
            else
            {
                UpdateToolButton.SharedProps.Visible= false;
                SaveToolButton.SharedProps.Visible  = false;
            }

            if (CurrentChildForm is ISecurityManagementForm)
            {
                ((ISecurityManagementForm)CurrentChildForm).Active();
            }

            // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ---->>>>>
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)mainToolbarsManager.Tools[TOOL_BUTTON_TEXTOUT_KEY];
            // ���엚���^�O
            if (this.mainTabControl.ActiveTab.Key.Equals(TabConfigForRef.OPERATION_LOG_VIEW_KEY))
            {
                // �{�^������������
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = true;
                }

            }
            // �G���[���O�\���^�O
            else
            {
                // �{�^���������Ȃ�
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
            // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ----<<<<<
        }

        #endregion  // <�^�u/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  ���V��</br>
        /// <br>�Ǘ��ԍ�     : 11202046-00</br>
        /// <br>             : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή�</br>
        /// <br>Update Note  : 2021/12/15  ���O</br>
        /// <br>�Ǘ��ԍ�     : 11770181-00</br>
        /// <br>             : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
        /// </remarks>
        public PMKHN09122UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ---->>>>>
            /* DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ ----->>>>>
            // �e�L�X�g�o�̓{�^���I�v�V����
            ShinkiOperahistoryOpt = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinkiOperationhistoryCtl);

            //�e�L�X�g�o�̓{�^��
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)mainToolbarsManager.Tools[TOOL_BUTTON_TEXTOUT_KEY];
            // �_���
            // �̌��Ō_���
            if (ShinkiOperahistoryOpt == PurchaseStatus.Contract || ShinkiOperahistoryOpt == PurchaseStatus.Trial_Contract)
            {
                //��ʕ\�����Ȃ�
                this.Opacity = 0.0;
                this.ShowInTaskbar = false;

                // �e�L�X�g�o�̓{�^���I�v�V����������ꍇ
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Visible = true;
                    buttonTool.SharedProps.Enabled = true;
                }
            }
            else
            {
                // �e�L�X�g�o�̓{�^���I�v�V�������Ȃ��ꍇ
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Visible = false;
                    buttonTool.SharedProps.Enabled = false;
                }

            }
            DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ -----<<<<<*/

            this.PMKHN09122UCObj = new PMKHN09122UC(); // �e�L�X�g�o�͉�ʏ�����
            // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ----<<<<<
        }

        #endregion  // <Constructor/>

        #region <�t�H�[��/>

        /// <summary>
		/// �Z�L�����e�B�Ǘ����C���t���[����Load�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Update Note  : ���V�� K2016/10/28</br>
        /// <br>�Ǘ��ԍ�     : 11202046-00</br>
        /// <br>             : �_�P�Y�Ƈ� �������������̒ǉ�</br>
        /// <br>Update Note  : 2021/12/15  ���O</br>
        /// <br>�Ǘ��ԍ�     : 11770181-00</br>
        /// <br>             : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
        /// </remarks>
        private void PMKHN09122UA_Load(object sender, EventArgs e)
        {
            // ���݂̃J�[�\����ێ�
            Cursor localCursor = Cursor;
			try
			{
                //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
                // ----- DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ ----->>>>>
                // // �_���
                // // �̌��Ō_���
                // if (ShinkiOperahistoryOpt == PurchaseStatus.Contract || ShinkiOperahistoryOpt == PurchaseStatus.Trial_Contract)
                // {
                // ----- DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ -----<<<<<
                    // XML�t�@�C���ǂݍ���
                    this.Deserialize();
                    string errMessage = string.Format(MSG_START_ERR, CT_XML_FILE);

                    if (this.ExtractionConditionSetObj != null)
                    {
                        /*----- DEL ���O 2021/12/15 �[�鎞�ԑяI�����ԃ`�F�b�N�̔p�~ ----->>>>>
                        // �[�鎞�ԑяI������
                        int latenightTimezoneEndHour = 0;
                        int latenightTimezoneEndMinute = 0;
                        int latenightTimezoneEndSecond = 0;
                        string latenightTimezoneEnd = string.Empty;
                        bool isLatenightTimezoneEndOk = this.CheckTime(this.ExtractionConditionSetObj.LatenightTimezoneEnd,
                            out latenightTimezoneEndHour, out latenightTimezoneEndMinute, out latenightTimezoneEndSecond);
                        // ���o���
                        int endTimeHour = 0;
                        int endTimeMinute = 0;
                        int endTimeSecond = 0;
                        string endTime = string.Empty;
                        bool isEndTimeOk = this.CheckTime(this.ExtractionConditionSetObj.EndTime, out endTimeHour, out endTimeMinute, out endTimeSecond);

                        if (!isLatenightTimezoneEndOk || !isEndTimeOk)
                        {
                            ShowMessage(errMessage);
                        }
                        else
                        {
                            // �[�鎞�ԑяI������:06:00:00�`23:59:59�̏ꍇ�A�G���[�Ƃ���
                            if (latenightTimezoneEndHour >= 6 && latenightTimezoneEndHour <= 23 &&
                                latenightTimezoneEndMinute >= 0 && latenightTimezoneEndMinute <= 59 &&
                                latenightTimezoneEndSecond >= 0 && latenightTimezoneEndSecond <= 59)
                            {
                                ShowMessage(errMessage);
                            }
                            else
                            {
                                //��ʕ\��
                                this.Opacity = 1.0;
                                this.ShowInTaskbar = true;
                            }
                        }
                        //----- DEL ���O 2021/12/15 �[�鎞�ԑяI�����ԃ`�F�b�N�̔p�~ -----<<<<<*/
                        //----- ADD ���O 2021/12/15 �[�鎞�ԑяI�����ԃ`�F�b�N�̔p�~ ----->>>>>
                        // �I�����ԃ`�F�b�N
                        int endTimeHour = MINTIME;
                        int endTimeMinute = MINTIME;
                        int endTimeSecond = MINTIME;
                        bool isEndTimeOk = this.CheckTime(this.ExtractionConditionSetObj.EndTime, out endTimeHour, out endTimeMinute, out endTimeSecond);
                        if (!isEndTimeOk)
                        {
                            ShowMessage(errMessage);
                        }
                        else
                        {
                            int totalSeconds = endTimeHour * HSEC + endTimeMinute * MSEC + endTimeSecond;
                            if (totalSeconds > INPUTMAXHOUR * HSEC)
                            {
                                ShowMessage(errMessage);
                            }
                            else
                            {
                                //��ʕ\��
                                this.Opacity = 1.0;
                                this.ShowInTaskbar = true;                            
                            }
                        }
                        //----- ADD ���O 2021/12/15 �[�鎞�ԑяI�����ԃ`�F�b�N�̔p�~ -----<<<<<
                    }
                    // ----- DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ ----->>>>>
                    //else
                    //{
                    //    ShowMessage(errMessage);
                    //}
                    // ----- DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ -----<<<<<
                //} // DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~
                //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<

                // �J�[�\���������v�ɐݒ�
                Cursor = Cursors.WaitCursor;

                // �c�[���o�[��������
                InitializeToolbar();

                // �^�u��������
                InitializeTab();

                // --- DEL m.suzuki 2010/02/22 ---------->>>>>
                //// �C�x���g�n���h����ǉ�
                //ISecurityManagementView
                //    viewForm = this._tabConfigMap[TabConfigForRef.SECURITY_MANAGEMENT_VIEW_KEY].Form
                //        as ISecurityManagementView;
                //if (viewForm != null)
                //{
                //    viewForm.Selected += new GridSelectedEventHandler(this.SecurityManagementViewGridSelected);
                //}

                //IStatusBarShowable settingForm = this._tabConfigMap[TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY].Form
                //        as IStatusBarShowable;
                //if (settingForm != null)
                //{
                //    settingForm.ShowStatusBar += new ValueIsInvalidEventHandler(this.ShowStatusBar);
                //}
                // --- DEL m.suzuki 2010/02/22 ----------<<<<<
			}
			finally
			{
                // �J�[�\����߂�
                Cursor = localCursor;
			}
		}

        /// <summary>
        /// �Z�L�����e�B�Ǘ����C���t���[����KeyDown�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// [Escape]�L�[�������ɏI���������s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void PMKHN09122UA_KeyDown(object sender, KeyEventArgs e)
        {
            #region <Guard Phrase/>
            
            if (!e.KeyCode.Equals(Keys.Escape)) return;

            #endregion  // <Guard Phrase/>

            const string TEXT = "�I�����܂����H";   // LITERAL:
            const string CAPTION = "�m�F";          // LITERAL:
            if (MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) Close();
        }

        #endregion  // <�t�H�[��/>

        #region <���쌠���ꗗ�\���̃O���b�h���I�����ꂽ�Ƃ��̃C�x���g/>
        // --- DEL m.suzuki 2010/02/22 ---------->>>>>
        ///// <summary>
        ///// ���쌠���ꗗ�\���̃O���b�h���I�����ꂽ�Ƃ��̃C�x���g�n���h��
        ///// </summary>
        ///// <param name="sender">�O���b�h�̐e�I�u�W�F�N�g</param>
        ///// <param name="operationSt">�I�����ꂽ�s�ɑ΂���I�y���[�V�������</param>
        //private void SecurityManagementViewGridSelected(
        //    object sender,
        //    OperationSt operationSt
        //)
        //{
        //    ISecurityManagementSetting
        //        settingForm = this._tabConfigMap[TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY].Form
        //            as ISecurityManagementSetting;
        //    if (settingForm == null) return;

        //    this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[TabConfigForRef.SECURITY_MANAGEMENT_SETTING_KEY];

        //    settingForm.Select(operationSt);
        //}
        // --- DEL m.suzuki 2010/02/22 ----------<<<<<
        #endregion  // <���쌠���ꗗ�\���̃O���b�h���I�����ꂽ�Ƃ��̃C�x���g/>

        #region <�c�[���o�[�̍\�z/>

        /// <summary>
        /// �c�[���o�[�����������܂��B
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28  ���V��</br>
        /// <br>�Ǘ��ԍ�     : 11202046-00</br>
        /// <br>             : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή�</br>
        /// </remarks>
        private void InitializeToolbar()
        {
            // �C���[�W���X�g��ݒ肷��
            this.mainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            //--------------------------------------------------------------
            // ���C�� �c�[���o�[
            //--------------------------------------------------------------
            // ���O�C���S���҂̃A�C�R���ݒ�
            LabelTool loginEmployeeLabel = (LabelTool)this.mainToolbarsManager.Tools["LOGINTITLE"];
            loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ���O�C����
            LabelTool loginName = (LabelTool)this.mainToolbarsManager.Tools["LoginName_LabelTool"];
            if (LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            //--------------------------------------------------------------
            // �W�� �c�[���o�[
            //--------------------------------------------------------------
            // ����c�[���{�^���̃A�C�R���ݒ�
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_CLOSE_ICON_INDEX;

            // �\���X�V�c�[���{�^���̃A�C�R���ݒ�
            UpdateToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_UPDATE_ICON_INDEX;

            // �ۑ��c�[���{�^���̃A�C�R���ݒ�
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_SAVE_ICON_INDEX;

            // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ---->>>>>
            // �e�L�X�g�o�̓{�^���̃A�C�R���ݒ�
            TextOutToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_TEXTOUT_ICON_INDEX;
            // ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή� ----<<<<<
        }

        #endregion  // <�c�[���o�[�̍\�z/>

        #region <�^�u�̍\�z/>

        /// <summary>
        /// �^�u�����������܂��B
        /// </summary>
        private void InitializeTab()
        {
            // �^�u�ɃC���[�W���X�g��ݒ�
            this.mainTabControl.ImageList = TabConfigForRef.ImageList;

            this._tabConfigMap.Clear();
            foreach (string tabKey in this._entryTabKeys)
            {
                // �^�u�\���}�b�v���\�z
                this._tabConfigMap.Add(tabKey, TabConfigForRef.CreateInstance(tabKey));

                // �^�u�Ɏq�t�H�[����ǉ�
                AddChildFormToTab(this._tabConfigMap[tabKey]);
            }

            // �擪�^�u��I��
            this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[0];
        }

        /// <summary>
        /// �^�u�Ɏq�t�H�[����ǉ����܂��B
        /// </summary>
        /// <param name="config">�^�u�\��</param>
        /// <remarks>
        /// <br>Update Note  : ���V�� K2016/10/28</br>
        /// <br>�Ǘ��ԍ�     : 11202046-00</br>
        /// <br>             : �_�P�Y�Ƈ� �������������̒ǉ�</br>
        /// <br>Update Note  : 2021/12/15  ���O</br>
        /// <br>�Ǘ��ԍ�     : 11770181-00</br>
        /// <br>             : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
        /// </remarks>
        private void AddChildFormToTab(TabConfigForRef config)
        {
            #region <Guard Phrase/>

            if (config.Form == null) return;

            #endregion  // <Guard Phrase/>

            // �Ή�����t�H�[���R���g���[���̃v���p�e�B��ύX
            config.Form.Name = config.Key;
            config.Form.TopLevel = false;
            config.Form.FormBorderStyle = FormBorderStyle.None;
            config.Form.Dock = DockStyle.Fill;

            // �^�u�y�[�W�R���g���[���̃C���X�^���X�𐶐�
            UltraTabPageControl uTabPageControl = new UltraTabPageControl();
            uTabPageControl.Controls.Add(config.Form);

            // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�
            UltraTab uTab = new UltraTab();
            uTab.TabPage = uTabPageControl;

            uTab.Key = config.Key;				    // �L�[
            uTab.Text = config.Text;				// �^�C�g��
            uTab.Tag = config.Form;				    // �Ή�����t�H�[���R���g���[��
            uTab.Appearance.Image = config.Icon;    // �A�C�R��

            uTab.Appearance.BackColor = Color.White;
            uTab.Appearance.BackColor2 = Color.Lavender;
            uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            uTab.ActiveAppearance.BackColor = Color.White;
            uTab.ActiveAppearance.BackColor2 = Color.LightPink;
            uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

            this.mainTabControl.Controls.Add(uTabPageControl);
            this.mainTabControl.Tabs.AddRange(new UltraTab[] { uTab });
            this.mainTabControl.SelectedTab = uTab;

            //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
            //----- DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ ----->>>>>
            // �_���
            // �̌��Ō_���
            // if (ShinkiOperahistoryOpt == PurchaseStatus.Contract || ShinkiOperahistoryOpt == PurchaseStatus.Trial_Contract)
            // {
            //----- DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~ -----<<<<<
            // ���엚��\���^�u�̏ꍇ
            if (config.Key.Equals(TabConfigForRef.OPERATION_LOG_VIEW_KEY))
            {
                if (config.Form is IDoTextOutForm)
                {
                    ((IDoTextOutForm)config.Form).TransferSettingInfo(true, this.ExtractionConditionSetObj);
                }
            }
            // } // DEL ���O 2021/12/15 �_�P�Y�Ƈ��I�v�V�����̔p�~
            //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<
            config.Form.Show();
        }

        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
        /// <summary>
        /// XML�t�@�C������ǂݍ��ޏ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : XML�t�@�C������ǂݍ��ޏ����B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XML_FILE)))
            {
                try
                {
                    this.ExtractionConditionSetObj = UserSettingController.DeserializeUserSetting<ExtractionConditionSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XML_FILE));
                }
                catch
                {
                    this.ExtractionConditionSetObj = null;
                }
            }
        }

        /// <summary>
        /// �����̃`�F�b�N
        /// </summary>
        /// <param name="inputTime">���͂̎����iXX:XX:XX�j</param>
        /// <param name="hour">�߂鎞���i���j</param>
        /// <param name="minute">�߂鎞���i���j</param>
        /// <param name="second">�߂鎞���i�b�j</param>
        /// <returns>�`�F�b�N���ʁiTrue:OK False:NG�j</returns>
        /// <remarks>
        /// <br>Note       : �����̃`�F�b�N���s���B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool CheckTime(string inputTime, out int hour, out int minute, out int second)
        {
            bool isOK = false;
            hour = 0;
            minute = 0;
            second = 0;

            if (!string.IsNullOrEmpty(inputTime))
            {
                string[] time = inputTime.Split(new char[] { ':' });
                if (time != null && time.Length == 3)
                {
                    string hourStr = time[0];
                    string minuteStr = time[1];
                    string secondStr = time[2];

                    // ���̃`�F�b�N
                    isOK = CheckTime(hourStr, 0, out hour);
                    // ���̃`�F�b�N
                    if (isOK)
                    {
                        isOK = CheckTime(minuteStr, 1, out minute);
                    }
                    // �b�̃`�F�b�N
                    if (isOK)
                    {
                        isOK = CheckTime(secondStr, 2, out second);
                    }
                }
            }

            return isOK;
        }

        /// <summary>
        /// �����̃`�F�b�N
        /// </summary>
        /// <param name="timeStr">���͂̎���(��/��/�b)</param>
        /// <param name="mode">���[�h�i0:�� 1:�� 2:�b�j</param>
        /// <param name="timeInt">�߂鎞��(��/��/�b)</param>
        /// <returns>�`�F�b�N���ʁiTrue:OK False:NG�j</returns>
        /// <remarks>
        /// <br>Note       : �����̃`�F�b�N���s���B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool CheckTime(string timeStr, int mode, out int timeInt)
        {
            bool isOK = false;
            timeInt = 0;

            if (string.IsNullOrEmpty(timeStr.Trim()))
            {
                isOK = true;
            }
            else
            {
                switch (mode)
                {
                    case 0: // ���̃`�F�b�N
                        if (int.TryParse(timeStr, out timeInt))
                        {
                            // --- UPD �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� ----->>>>>
                            //if (timeInt >= 0 && timeInt <= 23)
                            if (timeInt >= MINTIME && timeInt <= INPUTMAXHOUR)
                            // --- UPD �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� -----<<<<<
                            {
                                isOK = true;
                            }
                        }
                        break;
                    case 1: // ���̃`�F�b�N
                    case 2: // �b�̃`�F�b�N
                        if (int.TryParse(timeStr, out timeInt))
                        {
                            if (timeInt >= 0 && timeInt <= 59)
                            {
                                isOK = true;
                            }
                        }
                        break;
                    default:
                        isOK = false;
                        break;
                }
            }

            return isOK;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�̕\���Ɖ�ʂ̏I��
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\���Ɖ�ʂ̏I�����s���B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void ShowMessage(string errMessage)
        {
            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PROGRAM_ID, errMessage, ERROR_STATUS, MessageBoxButtons.OK);

            //��ʕ\�����Ȃ�
            this.Opacity = 0.0;
            this.ShowInTaskbar = false;

            //exit
            System.Windows.Forms.Application.Exit();
        }
        //----- ADD K2016/10/28 ���V�� �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<

        #endregion  // <�^�u�̍\�z/>

        #region <�X�e�[�^�X�o�[/>

        /// <summary>
        /// �X�e�[�^�X�o�[�ɕ\������C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ShowStatusBar(
            object sender,
            StatusBarMsg e
        )
        {
            this.ultraStatusBar.Panels["Text"].Text = e.Msg;
        }

        #endregion  // <�X�e�[�^�X�o�[/>
    }
}
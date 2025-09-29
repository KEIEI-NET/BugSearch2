using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.IO;
using Microsoft.VisualBasic;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �D�ǐݒ�}�X�^���C���t���[��
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 �ēc �ύK ���p/�@�\�ǉ��ׁ̈A�C��</br>
    /// <br>UpdateNote : 2009.04.06 20056 ���n ��� ��13066 ���_���ޒǉ��Ή�</br>
    /// <br>UpdateNote : 2010/01/13 30517 �Ė� �x�� Mantis�F14889�@���_�R�[�h�����l���g00�h�S�Ђ֕ύX</br>
    /// <br>                                        Mantis�F14715�@���_�ύX���ɕs�����`�F�b�N���������s�����悤�ɕύX</br>
    /// </remarks>
	public partial class PMKEN09010UA :Form
	{
		# region ��Constructor
		public PMKEN09010UA()
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin(); // 2009.04.06
		}
		# endregion

		# region ��Private Members

        /// <summary>�D�ǐݒ�R���g���[��</summary>
        //public PrimeSettingController _PrimeSettingController;  // DEL 2008/07/01
        public PrimeSettingAcs _PrimeSettingController;           // ADD 2008/07/01

		/// <summary>��ƃR�[�h</summary>
		private string _enterpriseCode;
		/// <summary>�N���V�X�e���R�[�h</summary>
		private int _systemCode;
		/// <summary>�e�L�X�g�o�͗p�q��ʐ���N���X</summary>
		private FormControlInfo _formControlInfo;
		// HACK:�^�u��ǉ�����ꍇ�͂����ɒǉ�
		/// <summary>�^�u���̔z��</summary>
        private string[] TAB_KEYS = new string[] { TAB_MAIN, TAB_ORDER ,TAB_DETAIL, TAB_VIEW };
		/// <summary>�e�L�X�g�o�͗p�t�H�[���R���g���[���N���XHashtable</summary>
		private Hashtable _formControlInfoTable;

        // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ---------->>>>>
        /// <summary>�D�ǐݒ�p���l�̊Ǘ����</summary>
        private IPrimeSettingNoteChanger _noteChangerView;
        /// <summary>
        /// �D�ǐݒ�p���l�̊Ǘ���ʂ̃A�N�Z�T
        /// </summary>
        /// <value>�D�ǐݒ�p���l�̊Ǘ����</value>
        private IPrimeSettingNoteChanger NoteChangerView
        {
            get { return _noteChangerView; }
            set { _noteChangerView = value; }
        }

        /// <summary>�D�ǐݒ�p���l�̕ω��ɉe�����󂯂��ʂ̃��X�g</summary>
        private readonly IList<IPrimeSettingNoteChangedEventHandler> _noteChangedEventHandlerList = new List<IPrimeSettingNoteChangedEventHandler>();
        /// <summary>
        /// �D�ǐݒ�p���l�̕ω��ɉe�����󂯂��ʂ̃��X�g���擾���܂��B
        /// </summary>
        /// <value>�D�ǐݒ�p���l�̕ω��ɉe�����󂯂��ʂ̃��X�g</value>
        public IList<IPrimeSettingNoteChangedEventHandler> NoteChangedEventHandlerList
        {
            get { return _noteChangedEventHandlerList; }
        }
        // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ----------<<<<<

        private ControlScreenSkin _controlScreenSkin; // 2009.04.06
        private bool _leaveEventCancel = false; // 2009.04.06

        private bool _bCode = false;// 2010/01/13 Add

		# endregion 

		# region ��Const
        
		//--------------------------------------------------------------------------
		//	���C����ʗp
		//--------------------------------------------------------------------------
		# region �����ށE���[�J�[�E�i�ڐݒ�
        private const string TAB_MAIN = "TAB_MAIND";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_MAIN_ID = "NSKEN90101U";
        //private const string TAB_MAIN_NS = "Broadleaf.Windows.Forms.NSKEN90101UA";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_MAIN_ID = "PMKEN09011U";
        private const string TAB_MAIN_NS = "Broadleaf.Windows.Forms.PMKEN09011UA";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        private const string TAB_MAIN_NAME = "��{�ݒ�";

        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B"; // 2009.04.06
        private const string SECCODE_ALL = "00"; // 2009.04.06
        private const string SECNAME_ALL = "�S��"; // 2009.04.06
		# endregion

        //--------------------------------------------------------------------------
        //	�ڍ׉�ʗp 
        //--------------------------------------------------------------------------
        # region �\������
        private const string TAB_ORDER = "TAB_ORDER";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_SORT_ID = "NSKEN90107U";
        //private const string TAB_SORT_NS = "Broadleaf.Windows.Forms.NSKEN90107UA";
        //private const string TAB_SORT_NAME = "�\�����ʐݒ�";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_SORT_ID = "PMKEN09014U";
        private const string TAB_SORT_NS = "Broadleaf.Windows.Forms.PMKEN09014UA";
        private const string TAB_SORT_NAME = "�\�����E�d����ݒ�";
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        # endregion
        //--------------------------------------------------------------------------
		//	�ڍ׉�ʗp 
		//--------------------------------------------------------------------------
	    # region �ڍ׉��
		private const string TAB_DETAIL = "TAB_DETAIL";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_DETAIL_ID = "NSKEN90102U";
        //private const string TAB_DETAIL_NS = "Broadleaf.Windows.Forms.NSKEN90102UA";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_DETAIL_ID = "PMKEN09012U";
        private const string TAB_DETAIL_NS = "Broadleaf.Windows.Forms.PMKEN09012UA";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
		private const string TAB_DETAIL_NAME = "�ڍאݒ�";

        # endregion

        //--------------------------------------------------------------------------
        //	�ꗗ��ʗp 
        //--------------------------------------------------------------------------
        # region �ݒ���e�ꗗ
        private const string TAB_VIEW = "TAB_VIEW";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_VIEW_ID = "NSKEN90103U";
        //private const string TAB_VIEW_NS = "Broadleaf.Windows.Forms.NSKEN90103UA";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_VIEW_ID = "PMKEN09013U";
        private const string TAB_VIEW_NS = "Broadleaf.Windows.Forms.PMKEN09013UA";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        private const string TAB_VIEW_NAME = "�ݒ���e�ꗗ";
        # endregion

        //--------------------------------------------------------------------------
		//	�W��ToolBar
		//--------------------------------------------------------------------------
		# region ��Const-�W��ToolBar
		/// <summary>�W���O���[�v</summary>
		private const string GROUP_NORMAL = "Button_UltraToolbar";
		/// <summary>�I�� �{�^�� Key</summary>
		private const string BUTTON_CLOSE = "Close";
		/// <summary>�t�@�C���o�� �{�^�� Key</summary>
		private const string BUTTON_OUTPUT = "Output";
		/// <summary>�N���A �{�^�� Key</summary>
		private const string BUTTON_CLEAR = "Clear";
		/// <summary>�ۑ��{�^�� Key</summary>
		private const string BUTTON_SAVE = "Save";
        /// <summary>�i�ރ{�^�� Key</summary>
        //private const string BUTTON_NEXT = "Next";  // DEL 2008/07/01
        /// <summary>�߂�{�^�� Key</summary>
        //private const string BUTTON_BACK = "Back";  // DEL 2008/07/01
        /// <summary>����{�^�� Key</summary>
        private const string BUTTON_PRINT = "Print";
        /// <summary>�V�[�N���b�g</summary>
        private const string SECRET = "Secret";
        # endregion

		//--------------------------------------------------------------------------
		//	���o����ToolBar
		//--------------------------------------------------------------------------
		# region ��Const-���o����ToolBar
		/// <summary>���o�����O���[�v</summary>
		private const string GROUP_EXTRACTCONDITION	= "ExtractCondition_Toolbar";
		/// <summary>�V�X�e�� �R���{�{�b�N�X Key</summary>
		private const string COMBOBOXTOOL_SYSTEM = "DataInputSystem_tComboEditor";
		/// <summary>�o�͑Ώۋ��_ ���x�� Key</summary>
		private const string LABEL_OUTPUTSEC = "OutPutSecTitle_Label";
		/// <summary>�o�͑Ώۋ��_ �R���{�{�b�N�X Key</summary>
		private const string COMBOBOXTOOL_OUTPUTSEC = "OutPutSec_ComboEditor";
		# endregion

		//--------------------------------------------------------------------------
		//	���̑�
		//--------------------------------------------------------------------------
		# region ��Const-���̑�
		/// <summary>���_-[�S��]�R�[�h</summary>
		private const string SEC_ALLSEC_CD = "000000";
		/// <summary>���_-[�S��]����</summary>
		private const string SEC_ALLSEC_NM = "�S��";
		/// <summary>�^�u�Ȃ�</summary>
		private const string NO_TAB = "";

        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string PROGRAM_NAME = "�D�ǐݒ�}�X�^";
        private const string PROGRAM_ID = "PMKEN09010U";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
		# endregion
   
        # endregion

        # region ��Events

        /// <remarks>�^�u�ύX�Ŕ�������C�x���g</remarks>
       public event MainTabChangeEventHandler TabIndexChange;

       /// <remarks>�c�[���{�^���Ŏq�ɏ������������ꍇ�ɔ���������C�x���g</remarks>
       public event FrameNotifyEventHandler _frameNotifyEvent;

       # region Load�C�x���g
        /// <summary>
		/// PMKEN09010UA Load�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
        private void PMKEN09010UA_Load(object sender, EventArgs e)
        {
			try
			{
                // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this._controlScreenSkin.LoadSkin();
                // �X�L���ύX���O�ݒ�
                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add(this.Standard_UGroupBox.Name);
                this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
                this._controlScreenSkin.SettingScreenSkin(this);
                // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				if (LoginInfoAcquisition.EnterpriseCode != null)
					_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

				if ((Program._param != null) && (Program._param.Length > (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOM1))
				{
					// �N���V�X�e���R�[�h���擾
					_systemCode = Convert.ToInt32(Program._param[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOM1]);
				}

				// ultraTabControl��ImageList��ݒ�
				this.Main_TabControl.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
				// �c�[���o�[��ݒ肷��
				this.SettingToolbar();

                // --- ADD 2009/03/10 ��QID:12270�Ή�------------------------------------------------------>>>>>
                // �^�u�X�^�C���ݒ�
                Main_TabControl.UseOsThemes = DefaultableBoolean.False;
                Main_TabControl.Appearance.BackColor = Color.WhiteSmoke;
                Main_TabControl.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
                Main_TabControl.Appearance.BackGradientStyle = GradientStyle.Vertical;
                Main_TabControl.ActiveTabAppearance.BackColor = Color.White;
                Main_TabControl.ActiveTabAppearance.BackColor2 = Color.Pink;
                Main_TabControl.ActiveTabAppearance.BackGradientStyle = GradientStyle.Vertical;
                Main_TabControl.Style = UltraTabControlStyle.VisualStudio2005;
                Main_TabControl.ViewStyle = ViewStyle.Office2003;
                // --- ADD 2009/03/10 ��QID:12270�Ή�------------------------------------------------------<<<<<

                // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this.uButton_SectionGuide.ImageList = IconResourceManagement.ImageList16;
                this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
                SecInfoSet secInfoSet = this.GetSecInfo(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                // 2010/01/13 >>>
                //this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                //this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim(); ;
                this.tEdit_SectionCode.Text = SECCODE_ALL;
                this.uLabel_SectionNm.Text = SECNAME_ALL;
                // 2010/01/13 <<<
                this.tEdit_SectionCode.Focus();
                // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				// ���݂̃J�[�\����ێ�
				Cursor localCursor = this.Cursor;
				// �J�[�\���������v��
				this.Cursor = Cursors.WaitCursor;

                //_PrimeSettingController = new PrimeSettingController();  // DEL 2008/07/01
                _PrimeSettingController = new PrimeSettingAcs();           // ADD 2008/07/01
                _PrimeSettingController.EnterPriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 2010/01/13 >>>
                //_PrimeSettingController.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();  // ADD 2008/07/04
                _PrimeSettingController.SectionCode = SECCODE_ALL;
                // 2010/01/13 <<<

                // �Y���f�[�^�擾
                int status = _PrimeSettingController.DataSearch();

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            foreach (string wkString in this.TAB_KEYS)
                            {
                                // �t�H�[������e�[�u���𐶐�����
                                this.FormControlInfoCreate(wkString);
                                // MDI�q��ʐ���
                                this.CreateMdiChildForm(wkString, _formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
                            }
                            // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ---------->>>>>
                            // �D�ǐݒ�p���l�̕\���p����
                            if (NoteChangerView != null)
                            {
                                foreach (IPrimeSettingNoteChangedEventHandler handler in NoteChangedEventHandlerList)
                                {
                                    NoteChangerView.NoteChanged += handler.PrimeSettingNoteChanged;
                                }
                            }
                            // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ----------<<<<<
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            break;
                        }
                    default:
                        {
                            // �T�[�`
                            TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                                PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                PROGRAM_NAME, 			            // �v���O��������
                                "PMKEN09010UA_Load", 			    // ��������
                                TMsgDisp.OPE_GET, 					// �I�y���[�V����
                                "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                                status, 							// �X�e�[�^�X�l
                                this._PrimeSettingController, 	    // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK, 				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��

                            break;
                        }
                }

				// �J�[�\����߂�
				this.Cursor = localCursor;

				// �擪Tab��I��
				this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
			}
			finally
			{
				// �N���p�t���[�e�B���O�E�B���h�E(Close)
				//Program._floatingWindow.Close();  // DEL 2008/07/01
			}
		}
		# endregion

		# region FormClosing�C�x���g
        private void PMKEN09010UA_FormClosing(object sender, FormClosingEventArgs e)
        {

			// MDI�q��ʂ��W�J����Ă��Ȃ���exit
			if (this.Main_TabControl.Tabs.Count <= 0)
				return;

			// �ҏW��ʂ̓��e��Static�̈�ɃX�g�A����
//			StoreMdiChild();
		}
		# endregion

		# region �c�[���o�[�N���b�N�C�x���g
		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
            int status = 0;  // ADD 2008/07/01

            switch (e.Tool.Key)
            {
                // �I���{�^��
                case BUTTON_CLOSE:
                    {
                        // ���C����ʂ̃N���[�Y
                        this.Close();
                        break;
                    }

                // �e�L�X�g�o�̓{�^��
                case BUTTON_OUTPUT:
                    {
                        // �e�L�X�g�o�͏���
                        this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
                        break;
                    }

                // �N���A�{�^��
                case BUTTON_CLEAR:
                    {
                        // �N���A����
                        //this.ExConditionClear();
                        break;
                    }

                // TODO:�ۑ��{�^��
                case BUTTON_SAVE:
                    {
                        if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,PROGRAM_ID, "�X�V���܂����H", 0, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.ultraStatusBar1.Panels["Text"].Text = string.Empty;    // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{����

                            // ADD 2008/10/29 �s��Ή�[6962] �d�l�ύX ---------->>>>>
                            // �d����R�[�h�̓��̓`�F�b�N
                            string errorMessage = string.Empty;
                            IPrimeSettingCheckable checker = this.Main_TabControl.ActiveTab.Tag as IPrimeSettingCheckable;
                            if (checker != null)
                            {
                                if (!checker.CanSave(out errorMessage))
                                {
                                    this.ultraStatusBar1.Panels["Text"].Text = errorMessage;
                                    TMsgDisp.Show(
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        PROGRAM_ID,
                                        errorMessage,
                                        status,
                                        MessageBoxButtons.OK
                                    );
                                    break;
                                }
                            }
                            // ADD 2008/10/29 �s��Ή�[6962] �d�l�ύX ----------<<<<<

                            // DEL 2008/11/25 �s��Ή�[6962] ���d�l�ύX �d����R�[�h�͑S�̂ŕK�{����
                            //status = _PrimeSettingController.updatePrimeSettingList();
                            // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{���� ---------->>>>>
                            status = _PrimeSettingController.updatePrimeSettingList(out errorMessage);
                            if (status.Equals(PrimeSettingAcs.UPDATE_CHECK_ERROR) && !string.IsNullOrEmpty(errorMessage))
                            {
                                this.ultraStatusBar1.Panels["Text"].Text = errorMessage;
                                TMsgDisp.Show(
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    PROGRAM_ID,
                                    errorMessage,
                                    status,
                                    MessageBoxButtons.OK
                                );
                                break;
                            }
                            // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{���� ----------<<<<<
                            // ----- ADD 2012/09/25 xupz for redmine#32367----->>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                            {
                                TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                "PMKEN09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,							// �v���O��������
                                "ExclusiveTransaction",				// ��������
                                TMsgDisp.OPE_UPDATE,							// �I�y���[�V����
                                "���ɑ��[�����X�V����Ă��܂�",						// �\�����郁�b�Z�[�W 
                                status,								// �X�e�[�^�X�l
                                "",							// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��
                                break;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                            {
                                TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                "PMKEN09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                                "���ɑ��[�����X�V����Ă��܂�",                        // �\�����郁�b�Z�[�W
                                status,								// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��
                                break;
                            }
                            // ----- ADD 2012/09/25 xupz for redmine#32367-----<<<<<
                            //if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && // DEL 2012/09/25 xupz for redmine#32367
                            else if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && // ADD 2012/09/25 xupz for redmine#32367
                                (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                                (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                // �o�^���s
                                TMsgDisp.Show(
                                    this, 								// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                                    PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                    PROGRAM_NAME, 		     	        // �v���O��������
                                    "Main_ToolbarsManager_ToolClick", 	// ��������
                                    TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                                    "�X�V�Ɏ��s���܂����B", 			// �\�����b�Z�[�W
                                    status, 							// �X�e�[�^�X�l
                                    this._PrimeSettingController,	    // �G���[�����������I�u�W�F�N�g
                                    MessageBoxButtons.OK, 				// �\������{�^��
                                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
                            }
                            else
                            {
                                SaveCompletionDialog dialog = new SaveCompletionDialog();
                                dialog.ShowDialog(2);  // �A�j���[�V����2�b
                            }
                        }
                        break;
                    }
            }
		}
		# endregion

		# region SelectedTabChanged�C�x���g
		/// <summary>
		/// �^�u SelectedTabChanged�C�x���g
		/// </summary>
		private void Main_TabControl_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ��ʔ�\���C�x���g
                if (TabIndexChange != null)
                {
                    int TabIndex = ((SelectedTabChangedEventArgs)e).Tab.Index;
                    TabIndexChange(this, TabIndex);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		# endregion

        # region �q��ʒʒm�C�x���g
        /// <summary>
        /// �^�u SelectedTabChanged�C�x���g
        /// </summary>
        private void FrameNotifyEvent( string key)
        {
            // ��ʔ�\���C�x���g
            if (_frameNotifyEvent != null)
            {
                _frameNotifyEvent(this, this.Main_TabControl.SelectedTab.Index, key);
            }

        }
        # endregion


		# endregion

		# region ��Private Methods
        # region ���^�u�\�z�֘A
        
		/// <summary>
		/// �t�H�[���R���g���[���N���X�N���G�C�g����
		/// </summary>
		/// <param name="nexViewFormname">���ɕ\������t�H�[��</param>
		private void FormControlInfoCreate(string nexViewFormname)
		{
			_formControlInfo = null;

            switch (nexViewFormname)
            {
                // �^�u�A�C�R��
                case (TAB_MAIN):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_MAIN_ID, TAB_MAIN_NS,
                            TAB_MAIN_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN], TAB_SORT_ID, NO_TAB);
                        break;
                    }
                case (TAB_ORDER):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_SORT_ID, TAB_SORT_NS,
                            TAB_SORT_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.SUBMENU], TAB_DETAIL_ID, TAB_MAIN_ID);
                        break;
                    }
                case (TAB_DETAIL):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_DETAIL_ID, TAB_DETAIL_NS,
                            TAB_DETAIL_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS], TAB_VIEW_ID, TAB_SORT_ID);
                        break;
                    }
                case (TAB_VIEW):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_VIEW_ID, TAB_VIEW_NS,
                            TAB_VIEW_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.ALLSELECT], NO_TAB, TAB_DETAIL_ID);
                        break;
                    }
            }

			// �t�H�[���R���g���[���N���XHashtabel��Add
			if (this._formControlInfoTable == null)
			{
				this._formControlInfoTable = new Hashtable();
			}
			this._formControlInfoTable[nexViewFormname] = _formControlInfo;
		}
        

		/// <summary>
		/// MDI�q��ʂ𐶐�����
		/// </summary>
		/// <param name="key">�t�H�[���N���X����Key</param>
		/// <param name="frmAssemblyName">�t�H�[���A�Z���u����</param>
		/// <param name="frmClassName">�t�H�[���N���X����</param>
		/// <param name="frmName">�t�H�[����</param>
		/// <param name="title">�^�u����</param>
		/// <param name="icon">�A�C�R���E�C���[�W</param>
		/// <param name="info">�t�H�[��������</param>
		/// <returns>none</returns>								
		private Form CreateMdiChildForm(string key, string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info)
		{
			Form form = null;

			// �t�H�[���̃C���X�^���X��
			form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(frmAssemblyName, frmClassName, typeof(System.Windows.Forms.Form));
			// �e�L�X�g�o�͗p�t�H�[���R���g���[���N���X�ɃC���^�[�t�F�[�X�I�u�W�F�N�g���Z�b�g
			//((FormControlInfo)this._formControlInfoTable[key]).TextOutInterface = (ITextOutForm)form;

			if (form != null)
			{
				// �t�H�[���v���p�e�B�ύX
				form.Name = frmName;

				// �^�u�y�[�W�R���g���[�����C���X�^���X
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = title;				// ����
				uTab.Key = frmName;				// Key
				uTab.Tag = form;				// �t�H�[���̃C���X�^���X
				uTab.Appearance.Image = icon;	// �A�C�R��
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
				uTab.ActiveAppearance.BackColor = Color.White;
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

				this.Main_TabControl.Controls.Add(uTabPageControl);
				this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { uTab });
				this.Main_TabControl.SelectedTab = uTab;

				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
                /*
				// IEntryTbsMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
                if ((form is IEntryTbsMDIChild))
                {
                    // �����̃I�u�W�F�N�g�ɂ́A�N������V�X�e���R�[�h������
                    ((IEntryTbsMDIChild)form).Show(_systemCode);
                }
                else
                 */
                if ((form is IPrimeSettingController))
                {
                    ((IPrimeSettingController)form).objPrimeSettingController = (object)_PrimeSettingController;
                    TabIndexChange += ((IPrimeSettingController)form).MainTabIndexChange;
                    _frameNotifyEvent += ((IPrimeSettingController)form).FrameNotifyEvent;
                    form.Show();
                }
                else
                {
                    form.Show();
                }
               
				uTabPageControl.Controls.Add(form);
				form.Dock = System.Windows.Forms.DockStyle.Fill;

                // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ---------->>>>>
                // �D�ǐݒ�p���l�̒l���Ǘ������ʂ�ێ�
                IPrimeSettingNoteChanger noteChangerForm = form as IPrimeSettingNoteChanger;
                if (noteChangerForm != null)
                {
                    NoteChangerView = noteChangerForm;
                }

                // �D�ǐݒ�p���l�̕ω��ɉe�����󂯂��ʂ�ێ�
                IPrimeSettingNoteChangedEventHandler noteChangedForm = form as IPrimeSettingNoteChangedEventHandler;
                if (noteChangedForm != null)
                {
                    NoteChangedEventHandlerList.Add(noteChangedForm);
                }
                // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ----------<<<<<
			}
			info.Form = form;

			return form;
		}
		# endregion

		# region ���c�[���o�[�֘A
		/// <summary>
		/// �c�[���o�[�̐ݒ�
		/// </summary>
		/// <remarks>�e�L�X�g�o�̓t���[���̃c�[���o�[�̐ݒ���s���܂��B</remarks>
		private void SettingToolbar()
		{
			// �C���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;

			//--------------------------------------------------------------
			// ���C�� �c�[���o�[
			//--------------------------------------------------------------
			// ���O�C���S���҂ւ̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LOGINTITLE"];
			if (loginEmployeeLabel != null)
				loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// ���O�C����
			Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginName != null && LoginInfoAcquisition.Employee != null)
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				LoginName.SharedProps.Caption = employee.Name;
			}

            // --- ADD 2008/07/01 -------------------------------->>>>>
            // ���_���̎擾
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            // ���_���̎擾
            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (status == 0)
            {
                // ���_���̐ݒ�
                Infragistics.Win.UltraWinToolbars.LabelTool SectionName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["SectionName_LabelTool"];
                SectionName.SharedProps.Caption = secInfoSet.SectionGuideNm;
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 

			//--------------------------------------------------------------
			// �W�� �c�[���o�[
			//--------------------------------------------------------------
			// �I���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_CLOSE];
			if (closeButton != null)
				closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // --- DEL 2008/07/01 -------------------------------->>>>>
            //// �i�ނ̃A�C�R���ݒ�
            //Infragistics.Win.UltraWinToolbars.ButtonTool nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_NEXT];
            //if (nextButton != null)
            //    nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;

            //// �߂�̃A�C�R���ݒ�
            //Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_BACK];
            //if (backButton != null)
            //    backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // ����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_PRINT];
            if (printButton != null)
            {
                printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
                // ADD 2008/10/28 �s��Ή�[6966] [���]�{�^���͕s�v ---------->>>>>
                printButton.SharedProps.Enabled = false;
                printButton.SharedProps.Visible = false;
                // ADD 2008/10/28 �s��Ή�[6966] [���]�{�^���͕s�v ----------<<<<<
            }
            
            // �ۑ��̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_SAVE];
            if (saveButton != null)
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

			// �o�͂̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool outputButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_OUTPUT];
            if (outputButton != null)
            {
                outputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
                // ADD 2008/10/28 �s��Ή�[6966] [�t�@�C���o��]�{�^���͕s�v ---------->>>>>
                outputButton.SharedProps.Enabled = false;
                outputButton.SharedProps.Visible = false;
                // ADD 2008/10/28 �s��Ή�[6966] [�t�@�C���o��]�{�^���͕s�v ----------<<<<<
            }

            // --- DEL 2008/07/01 -------------------------------->>>>>
			// �N���A�̃A�C�R���ݒ�
            //Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_CLEAR];
            //if (clearButton != null)
            //    clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // --- DEL 2008/07/01 --------------------------------<<<<< 

			// �P�i�ڂɔz�u
			//Main_ToolbarsManager.Toolbars["ExtractCondition_Toolbar"].DockedRow = 1;   
		}

		# endregion
        /*
		/// <summary>
		/// �q��ʂ̕ۑ�����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>�q��ʂɑ΂��āAStatic�ɕۑ������鏈�������s�����܂��B</remarks>
		private int StoreMdiChild()
		{
			int st = -1;

			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IEntryTbsMDIChildEdit)
				{
					// �X�^�e�B�b�N�ۑ�����
					st = ((IEntryTbsMDIChildEdit)_formControlInfo.Form).SaveStaticMemoryData(this);
				}
			}

			return st;
		}
        */
		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>�A�Z���u�������[�h���܂��B</remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (System.IO.FileNotFoundException er)
			{
				// �ΏۃA�Z���u���Ȃ��i�x���j
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, er.StackTrace, 0, MessageBoxButtons.OK);
			}
			catch (System.Exception er)
			{
				// �ΏۃA�Z���u���Ȃ��i�x��)
				string _msg = "Message=" + er.Message + "\r\n" + "Trace  =" + er.StackTrace + "\r\n" + "Source =" + er.Source;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, _msg, 0, MessageBoxButtons.OK);
			}

			return obj;
		}


		# endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKEN09010UA_KeyDown(object sender, KeyEventArgs e)
        {
            // DEL 2008/10/28 �s��Ή�[6971]��
            /*
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("�I�����܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
            }
            else*/ 
            if ((e.Control) && (e.KeyCode == Keys.S))
            {
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //if (_PrimeSettingController.SecretMode == false) return;
                //if ("051231" == Interaction.InputBox("�p�X���[�h����", "�V�[�N���b�g���[�h�ڍs", "",0,0))
                //{
                //    _PrimeSettingController.SecretMode = false;
                //    FrameNotifyEvent(SECRET);
                //}

                InputPassword inputPass = new InputPassword();
                DialogResult result = inputPass.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    if ("051231" == inputPass.Password)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        PROGRAM_ID,
                                        "�V�[�N���b�g���[�J�[��\�����܂��B",
                                        0,
                                        MessageBoxButtons.OK);

                        _PrimeSettingController.SecretMode = false;
                        FrameNotifyEvent(SECRET);
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        PROGRAM_ID,
                                        "�p�X���[�h���Ԉ���Ă��܂��B",
                                        0,
                                        MessageBoxButtons.OK);
                    }
                }
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
            }
        }

        // TODO:�폜���
        private void PMKEN09010UA_Shown(object sender, EventArgs e)
        {
            int status;

            if (_PrimeSettingController.UserPrimeSettingTable.Rows.Count > 0)
            {
                Form frm = new PMKEN09010UD(_PrimeSettingController.UserPrimeSettingTable.DefaultView);

                if (frm.ShowDialog() == DialogResult.Cancel) return;

                // ���[�U�[�o�^���ɂ����Ē񋟂ɂȂ��f�[�^���폜����
                status = _PrimeSettingController.updateUserDeleteList();

                if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status)
                {
                    TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                    PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    PROGRAM_NAME, 				        // �v���O��������
                    "PMKEN09010UA_Shown", 				// ��������
                    TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                    "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._PrimeSettingController,	    // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
                }
            }
        }

        // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            this._leaveEventCancel = false;

            // PrevCtrl�ݒ�
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

            switch (prevCtrl.Name)
            {
                #region ���_�R�[�h
                //---------------------------------------------------------------
                // ���_�R�[�h
                //---------------------------------------------------------------
                case "tEdit_SectionCode":
                    {
                        this._leaveEventCancel = true;
                        string code = this.tEdit_SectionCode.Text.Trim();
                        code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);

                        if (string.IsNullOrEmpty(code))
                        {
                            this.tEdit_SectionCode.Text = SECCODE_ALL;
                            this.uLabel_SectionNm.Text = SECNAME_ALL;
                            this.ReSettingPrmInfo();
                            // 2010/01/13 Add >>>
                            if (_bCode == true)
                            {
                                this.PMKEN09010UA_Shown(sender, e);
                                _bCode = false;
                            }
                            // 2010/01/13 Add <<<
                        }
                        else
                        {
                            SecInfoSet secInfoSet = this.GetSecInfo(code);

                            if (secInfoSet == null)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���_�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_SectionCode.Text = SECCODE_ALL;
                                this.uLabel_SectionNm.Text = SECNAME_ALL;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                                this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                                this.ReSettingPrmInfo();
                                // 2010/01/13 Add >>>
                                if (_bCode==true)
                                {
                                    this.PMKEN09010UA_Shown(sender, e);
                                    _bCode = false;
                                }
                                // 2010/01/13 Add <<<
                            }
                        }
                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;

            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                this.ReSettingPrmInfo();
            }
        }

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        public SecInfoSet GetSecInfo(string sectionCode)
        {
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSet retSecInfoSet = null;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs(secInfoAcs);

            if (secInfoAcs.SecInfoSetList != null)
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim())
                    {
                        retSecInfoSet = secInfoSet;
                        break;
                    }
                }

            }
            return retSecInfoSet;
        }

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        /// <param name="secInfoSetAcs"></param>
        public void CreateSecInfoAcs(SecInfoAcs secInfoAcs)
        {
            if (secInfoAcs == null)
            {
                secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// tEdit_SectionCode_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            if (this._leaveEventCancel)
            {
                this._leaveEventCancel = false;
                return;
            }

            string code = this.tEdit_SectionCode.Text.Trim();
            code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);

            if (string.IsNullOrEmpty(code))
            {
                this.tEdit_SectionCode.Text = SECCODE_ALL;
                this.uLabel_SectionNm.Text = SECNAME_ALL;
                this.ReSettingPrmInfo();
            }
            else
            {
                SecInfoSet secInfoSet = this.GetSecInfo(code);

                if (secInfoSet == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���_�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    this.tEdit_SectionCode.Text = SECCODE_ALL;
                    this.uLabel_SectionNm.Text = SECNAME_ALL;
                    this.tEdit_SectionCode.Focus();
                }
                else
                {
                    this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                    this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                    this.ReSettingPrmInfo();
                }
            }
        }

        /// <summary>
        /// �D�Ǐ��Đݒ菈��
        /// </summary>
        private void ReSettingPrmInfo()
        {
            // �D�ǐݒ�Đݒ�
            if (this._PrimeSettingController.SectionCode != this.tEdit_SectionCode.Text.Trim())
            {
                SFCMN00299CA processingDialog = new SFCMN00299CA();
                try
                {
                    processingDialog.Title = "�D�ǐݒ�擾";
                    processingDialog.Message = "���݁A�D�ǐݒ�擾���ł��B";
                    processingDialog.DispCancelButton = false;
                    processingDialog.Show((Form)this.Parent);

                    this._PrimeSettingController.SectionCode = this.tEdit_SectionCode.Text.Trim();

                    _bCode = true;// 2010/01/13 Add

                    // �Y���f�[�^�擾
                    int status = _PrimeSettingController.DataSearchOnlyPrmInfo();

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.Main_TabControl.Tabs.Clear();

                        foreach (string wkString in this.TAB_KEYS)
                        {
                            // �t�H�[������e�[�u���𐶐�����
                            this.FormControlInfoCreate(wkString);
                            // MDI�q��ʐ���
                            this.CreateMdiChildForm(wkString, _formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
                        }
                        // �D�ǐݒ�p���l�̕\���p����
                        if (NoteChangerView != null)
                        {
                            foreach (IPrimeSettingNoteChangedEventHandler handler in NoteChangedEventHandlerList)
                            {
                                NoteChangerView.NoteChanged += handler.PrimeSettingNoteChanged;
                            }
                        }
                    }
                }
                finally
                {
                    processingDialog.Dispose();
                }
            }
            // �擪Tab��I��
            this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
        }
        // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
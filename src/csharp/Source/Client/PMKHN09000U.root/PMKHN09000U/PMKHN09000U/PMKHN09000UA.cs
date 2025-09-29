//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�}�X�^
// �v���O�����T�v   �F���Ӑ�̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2008/04/30     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30452 ��� �r��
// �C����    2008/09/04     �C�����e�F���S�폜�A���������ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30452 ��� �r��
// �C����    2008/12/01     �C�����e�F���S�폜�A�����������A�c�[���o�[�̕\���E��\�����䏈���ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V�m��
// �C����    2008/12/05     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V�m��
// �C����    2008/12/10     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V�m��
// �C����    2008/12/26     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/03     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2009/07/30     �C�����e�FLoginInfoAcquisition.OnlineFlag���Q�Ƃ��ď������s��Ȃ��B
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fcaowj
// �C����    2010/08/10     �C�����e�F���Ӑ�}�X�^��Q���ǑΉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�� ��
// �C����    2010/12/06     �C�����e�F��Q���ǑΉ�12��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���Fcaohh
// �C����    2011/08/04     �C�����e�FNS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10970681-00    �쐬�S���F��
// �C����    2014/03/07     �C�����e�FRedmine#42174 �����\���^�u�̑Ή�
// ---------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ���o�^�t���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ���o�^�t�H�[���̃t���[���N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2208.04.30</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.09.04 30452 ��� �r��</br>
    /// <br>             ���S�폜�A���������ǉ�</br>
    /// <br>Update Note: 2008.12.01 30452 ��� �r��</br>
    /// <br>             ���S�폜�A�����������A�c�[���o�[�̕\���E��\�����䏈���ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote  : 2008/12/05 30462 �s�V�m���@�o�O�C��</br>
    /// <br>UpdateNote  : 2008/12/10 30462 �s�V�m���@�o�O�C��</br>
    /// <br>UpdateNote  : 2008/12/26 30462 �s�V�m���@�o�O�C��</br>
    /// <br>UpdateNote  : 2010/08/10 caowj</br>
    /// <br>              ���Ӑ�}�X�^��Q���ǑΉ�</br>
    /// <br>UpdateNote�@: 2011/08/04 caohh</br>
    /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
	/// </remarks>
	public partial class PMKHN09000UA : System.Windows.Forms.Form
	{
		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
		#region Const
		private const int    SAVE_DIALOG_YES	= 0;
		private const int    SAVE_DIALOG_NO		= 1;
		private const int    SAVE_DIALOG_CANCEL	= 2;
		private const string TITLE = "���Ӑ�}�X�^";
		private const string OFFLINE_TITLE = " [Offline]";
		# endregion

		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		#region Const
        /// <summary>�ҏW���[�h</summary>
		public static readonly int EXEC_MODE_EDIT = 1;				// �ҏW���[�h
        /// <summary>�Q�ƃ��[�h</summary>
        public static readonly int EXEC_MODE_VIEWER = 2;			// �r���[�A���[�h
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		PMKHN09010UA _inputForm = null;
		private string _key = Guid.NewGuid().ToString();							// ���j�[�N�L�[������
		private int _execMode = 0;													// �N�����[�h
		private string _enterpriseCode = string.Empty;
		private ImageList _imageList16;
		private CustomerInfo _customerInfo;											// ���Ӑ�N���X
		private CustomerInfoAcs _customerInfoAcs;									// ���Ӑ�A�N�Z�X�N���X
		private CustomerInputAcs _customerInputAcs;									// ���Ӑ��ʗp�A�N�Z�X�N���X
		private CustomerSectionInfoControl _sectionInfoControl;						// ���_���R���g���[���N���X
		private delegate void InitialDataReadHandler();
		InitialDataReadHandler _initialDataRead;
		private CustomerInputSetUp _customerInputSetUp;
		private int _initialReadStatus = 0;
		private Hashtable _initToolTipTextTable = new Hashtable();							// �c�[���o�[�p�����q���g������i�[�p
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;	// ���O�C�����_�R�[�h
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Save;			// �ۑ��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Retry;			// ���ɖ߂��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Setup;			// ���ɖ߂��{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_New;			// �V�K�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Delete;			// �폜�{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Search;			// �����{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Close;			// �I���{�^��
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Edit;			// �ҏW�{�^��
        // --- ADD 2008/09/04 -------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Revive;			// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_CompleteDelete;	// �ҏW�{�^��
        // --- ADD 2008/09/04 --------------------------------<<<<< 
        // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Renewal;			// �ŐV���{�^��
        // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
        // --- ADD 2010/08/10 ------------------------------------>>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Guide;			// �K�C�h�{�^��
        private CustomerInputConstructionAcs _customerInputConstructionAcs = null;
        // --- ADD 2010/08/10 ------------------------------------<<<<< 
		private ControlScreenSkin _controlScreenSkin;
        // --- ADD 2010/12/06 ------------------------------------>>>>>
        private BillAllStAcs _billAllStAcs = null; // �����S�̐ݒ�A�N�Z�X�N���X
        private ArrayList _billAllStList; // �����S�̐ݒ�ۑ��p
        private ArrayList _customerTotalDayList;// ���Ӑ����
        // --- ADD 2010/12/06 ------------------------------------<<<<<
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        // ===================================================================================== //
        // �f���Q�[�g��`
        // ===================================================================================== //
        # region Delegates
        /// <summary>
        /// ���Ӑ惌�R�[�h�X�V��C�x���g�f���Q�[�g
        /// </summary>
        /// <param name="sender">�C�x���g������</param>
        /// <param name="customerSearchRet">�X�V�Ώۓ��Ӑ���</param>
        public delegate void AfterCustomerRecordUpdateEventHandler( object sender, CustomerSearchRet customerSearchRet );
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
        
        // ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// �e�t�H�[���őO�ʉ��C�x���g
		/// </summary>
		public event EventHandler OwnerFormBringToFront;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// ���Ӑ惌�R�[�h�X�V��C�x���g
        /// </summary>
        public event AfterCustomerRecordUpdateEventHandler AfterCustomerRecordUpdate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

		# endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// ���Ӑ���o�^�t�H�[���t���[���N���X�f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKHN09000UA()
        {
            InitializeComponent();

            // �v���C�x�[�g�ϐ�������
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._customerInfoAcs = new CustomerInfoAcs( this._key );
            this._customerInputAcs = new CustomerInputAcs( this._key );
            this._initialDataRead = new InitialDataReadHandler( this.InitialDataRead );
            this._customerInputSetUp = new CustomerInputSetUp();
            this._sectionInfoControl = new CustomerSectionInfoControl();
            this._execMode = EXEC_MODE_EDIT;
            this._controlScreenSkin = new ControlScreenSkin();

            this.buttonTool_Save = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Save_ButtonTool"];						// �ۑ��{�^��
            this.buttonTool_Retry = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Retry_ButtonTool"];					// ���ɖ߂��{�^��
            this.buttonTool_Setup = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Setup_ButtonTool"];					// ���ɖ߂��{�^��
            this.buttonTool_New = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["New_ButtonTool"];						// �V�K�{�^��
            this.buttonTool_Delete = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Delete_ButtonTool"];				// �폜�{�^��
            this.buttonTool_Search = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Search_ButtonTool"];				// �����{�^��
            this.buttonTool_Close = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Close_ButtonTool"];					// �I���{�^��
            this.buttonTool_Edit = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Edit_ButtonTool"];					// �ҏW�{�^��
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this.buttonTool_CompleteDelete = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["CompleteDelete_ButtonTool"];
            this.buttonTool_Revive = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Revive_ButtonTool"];
            // --- ADD 2008/09/04 --------------------------------<<<<< 
            // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.buttonTool_Renewal = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Renewal_ButtonTool"];            
            // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.buttonTool_Guide = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Guide_ButtonTool"];			        // �K�C�h�{�^��
            // --- ADD 2010/08/10 ------------------------------------<<<<< 

            // �f���Q�[�g�N�����C�x���g�o�^
            this._customerInfoAcs.AddInfoCustomerChangeEvent( new CustomerInfoChangeEventHandler( this.CustomerInfoChange ) );
            this._customerInfoAcs.AddInfoDeleteCustomerEvent( new CustomerInfoDeleteEventHandler( this.CustomerInfoDelete ) );

            // StaticMemory����������
            this._customerInputAcs.InitialStaticMemory( 0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo );

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this._customerInputConstructionAcs = new CustomerInputConstructionAcs();
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            // --- ADD 2010/12/06 ------------------------------------>>>>>
            this._billAllStAcs = new BillAllStAcs(); // �����S�̐ݒ�A�N�Z�X�N���X
            this._customerTotalDayList = new ArrayList();
            // --- ADD 2010/12/06 ------------------------------------<<<<<
        }

        /// <summary>
        /// ���Ӑ���o�^�t�H�[���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="mode">0:�ҏW���[�h 1:�Q�ƃ��[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public PMKHN09000UA( int mode, string enterpriseCode, int customerCode )
            : this()
        {
            this._execMode = mode;

            CustomerInfo customerInfo;
            // --- DEL 2008/09/04 -------------------------------->>>>>
            //this._initialReadStatus = this._customerInfoAcs.ReadDBData( enterpriseCode, customerCode, out customerInfo );
            // --- DEL 2008/09/04 --------------------------------<<<<<
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this._initialReadStatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData01, enterpriseCode, customerCode, out customerInfo);
            // --- ADD 2008/09/04 --------------------------------<<<<<

            if ( this._initialReadStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                this._customerInfo = customerInfo;
            }
        }
        # endregion
        
        // ===================================================================================== //
		// �f���Q�[�g�p���\�b�h
		// ===================================================================================== //
		# region Delegate Method
		/// <summary>
		/// ���Ӑ���ύX�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="frameKey">�t���[���̃��j�[�N�L�[</param>
        /// <param name="customerInfo">���Ӑ�N���X</param>
		private void CustomerInfoChange(object sender, string frameKey, ref CustomerInfo customerInfo)
		{
			// ����t���[�����ɂē��Ӑ��񂪕ύX���ꂽ
			if (frameKey == this._key)
			{
				this._customerInfo = customerInfo.Clone();

                //// ���_�R���{�G�f�B�^�I��l�ݒ菈��
                //this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);

				// �c�[���o�[�{�^���L�������ݒ菈��
				this.ToolBarButtonEnabledSetting();
			}
			// ���t���[���ɂē��Ӑ��񂪕ύX���ꂽ
			else
			{
				// �n����Ă������Ӑ���N���X�̓��Ӑ�R�[�h��0�̏ꍇ�͉������Ȃ�
				if (customerInfo.CustomerCode == 0) return;

				// �n����Ă������Ӑ���N���X�̓��Ӑ�R�[�h�ƕێ����Ă��链�Ӑ�R�[�h������̏ꍇ��
				// �ŐV�̏��ɉ�ʂ��X�V����
				if (this._customerInfo.CustomerCode == customerInfo.CustomerCode)
				{
					this._customerInfo = customerInfo.Clone();

                    //// ���_�R���{�G�f�B�^�I��l�ݒ菈��
                    //this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);

					if (this._execMode == EXEC_MODE_EDIT)
					{
						// Static��������ʏ��\������
						this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);
					}
					else
					{
						//this._viewerForm.RepaintWebBrowser(false, this._trustContInfo);
					}

					// �c�[���o�[�{�^���L�������ݒ菈��
					this.ToolBarButtonEnabledSetting();
				}
			}
		}

		/// <summary>
		/// ���Ӑ���폜�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="frameKey">�t���[���L�[������</param>
        /// <param name="customerInfo">���Ӑ�N���X</param>
		private void CustomerInfoDelete(object sender, string frameKey, ref CustomerInfo customerInfo)
		{
			// ����t���[�����ɂē��Ӑ��񂪕ύX���ꂽ
			if (frameKey == this._key)
			{
				// �c�[���o�[�{�^���L�������ݒ菈��
				this.ToolBarButtonEnabledSetting();
			}
			// ���t���[���ɂē��Ӑ��񂪕ύX���ꂽ
			else
			{
				// �n����Ă������Ӑ���N���X�̓��Ӑ�R�[�h��0�̏ꍇ�͉������Ȃ�
				if (customerInfo.CustomerCode == 0) return;

				// �n����Ă������Ӑ���N���X�̓��Ӑ�R�[�h�ƕێ����Ă��链�Ӑ�R�[�h������̏ꍇ��
				// �ŐV�̏��ɉ�ʂ��X�V����
				if (this._customerInfo.CustomerCode == customerInfo.CustomerCode)
				{
					// �c�[���o�[�{�^���L�������ݒ菈��
					this.ToolBarButtonEnabledSetting();
				}
			}
		}

		/// <summary>
		/// �I���R�[�h�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SelectCodeChangedEvent(object sender, EventArgs e)
		{
			if (this.IsDisposed) return;

			if (!(e is CustomerSelectCodeChangeCtlEventArgs))
			{
				return;
			}

			CustomerSelectCodeChangeCtlEventArgs csa = (CustomerSelectCodeChangeCtlEventArgs)e;

			if (csa.Code != 0)
			{
				CustomerInfo customerInfo;
				int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, csa.Code, out customerInfo);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this._customerInfo = customerInfo.Clone();
					
					// Static��������ʏ��\������
					this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

					// �c�[���o�[�{�^���L�������ݒ菈��
					this.ToolBarButtonEnabledSetting();
				}
			}
		}

		/// <summary>
		/// �Ǘ��R�[�h�]���C�x���g����
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		private void TransmitMngSectionCode(object sender, string sectionCode)
		{
            //bool isSetting = false;

            //if ((sectionCode != null) && (sectionCode.ToString() != ""))
            //{
            //    isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, sectionCode);
            //}
            //else
            //{
            //    isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._loginSectionCode);
            //}

            //if (isSetting)
            //{
            //    // �Ǘ����_�R�[�h�W�J����
            //    this.MngSectionCodeBroadCast();
            //}
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region Public Methods
		/// <summary>
		/// �L�[�v���p�e�B
		/// </summary>
		public string Key
		{
			get { return _key; }
		}

		/// <summary>
		/// �I�����i��ƃR�[�h�E���Ӑ�R�[�h�j�擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:�擾���� 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���ݑI�𒆂̊�ƃR�[�h�A���Ӑ�R�[�h���擾���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int GetSelectInfo(out string enterpriseCode, out int customerCode)
		{
			int status;

			// �X�V����MinValue�̏ꍇ�́ADB�Ƀf�[�^���o�^����Ă��Ȃ��Ɣ��f����
			if ((this._customerInfo == null) || (this._customerInfo.UpdateDateTime == DateTime.MinValue))
			{
				enterpriseCode = string.Empty;
				customerCode = 0;

				status = -1;
			}
			else
			{
				enterpriseCode = this._customerInfo.EnterpriseCode;
				customerCode = this._customerInfo.CustomerCode;

				status = 0;
			}

			return status;
		}

		/// <summary>
		/// �ҏW��Ԏ擾����
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <returns>true:�ҏW�� false:���ҏW</returns>
		public bool IsEditting(out string message)
		{
			bool result = false;

			int status = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (status != 0)
			{
				result = true;
				if (this._customerInfo.CustomerCode == 0)
				{
					message = "'���Ӑ�R�[�h�F������'";
				}
				else
				{
					message = "'���Ӑ�R�[�h�F" + this._customerInfo.CustomerCode.ToString() + "'";
				}

				if (this._customerInfo.Name == "")
				{
					message += "\r\n" + "'���Ӑ於�F������'";
				}
				else
				{
					message += "\r\n" + "'���Ӑ於�F" + this._customerInfo.Name + "'";
				}
			}
			else
			{
				message = string.Empty;
			}

			return result;
		}

		/// <summary>
		/// ��ʏI������
		/// </summary>
		/// <returns>0:�I������ 1:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �I���`�F�b�N������A��ʂ��I�����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int DispClose()
		{
			// �f�[�^�ۑ��m�F����
			if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL)
			{
				return 1;
			}

			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory����������
				this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);
			}
			else
			{
				// ���Ӑ�f�[�^�߂�����
				this._customerInfoAcs.CopyStaticMemory(1, this._enterpriseCode, this._customerInfo.CustomerCode);
			}

			this.Close();
			return 0;
		}

		/// <summary>
		/// ��ʏI���`�F�b�N����
		/// </summary>
		/// <returns>0:�I���� 1:�I���s��</returns>
		/// <remarks>
		/// <br>Note       : �I���`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int DispCloseCheck()
		{
			// �f�[�^�ۑ��m�F����
			if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL)
			{
				return 1;
			}

			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory����������
				this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);
			}
			else
			{
				// ���Ӑ�f�[�^�߂�����
				this._customerInfoAcs.CopyStaticMemory(1, this._enterpriseCode, this._customerInfo.CustomerCode);
			}

			return 0;
		}

		/// <summary>
		/// ���Ӑ�V�K����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ��ʂ�V�K�̏�Ԃŕ\�����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void CustomerNew(string enterpriseCode)
		{
			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory����������
				this._customerInputAcs.InitialStaticMemory(0, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);
			}
			else
			{
				// ���Ӑ�f�[�^�߂�����
				this._customerInfoAcs.CopyStaticMemory(1, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);
			}

			// StaticMemory����������
			this._customerInputAcs.InitialStaticMemory(0, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);

            //// �Ǘ����_�R�[�h��ݒ肷��
            //bool isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);
            //if (isSetting) this.MngSectionCodeBroadCast();

			// Static��������ʏ��\������
			this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			// �t�H�[�J�X�����ݒ菈��
			this.SetInitFocus();
		}

		/// <summary>
		/// �I���{�^���\����\���ݒ�v���p�e�B
		/// </summary>
		/// <remarks>
		/// <br>Note       :  �I���{�^���̕\����\����ݒ肵�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public bool IsClosedButtonDisplay
		{
			get
			{
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				return closeButton.SharedProps.Visible;
			}
			set
			{
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				closeButton.SharedProps.Visible = value;
			}
		}

		/// <summary>
		/// �I�����L�[�擾����
		/// </summary>
		/// <returns>�e�t�H�[�����̑I�����L�[������</returns>
		public string GetSelectedInfoKey()
		{
			if (this._customerInfo.CustomerCode == 0)
			{
				return this._key;
			}
			else
			{
				return this._customerInfo.EnterpriseCode + "-" + this._customerInfo.CustomerCode.ToString();
			}
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// Tab��������
		/// </summary>
		private void TabCreate(int mode)
		{
			if (mode == EXEC_MODE_EDIT)
			{
				this._inputForm = new PMKHN09010UA(this._key, this._customerInfo);

				// �t�H�[���v���p�e�B�ύX
				this._inputForm.TopLevel = false;
				this._inputForm.FormBorderStyle = FormBorderStyle.None;
                this.Form1_Fill_Panel.Controls.Add( this._inputForm );
                this._inputForm.Show();
				this._inputForm.Dock = System.Windows.Forms.DockStyle.Fill;

				this._inputForm.SelectCodeChanged += new EventHandler(this.SelectCodeChangedEvent);
				this._inputForm.TransmitMngSectionCode += new CustomerCarSectionCodeTransmitEventHandler(this.TransmitMngSectionCode);
				this._inputForm.OwnSectionCode = this._loginSectionCode;

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                // --- ADD ���J�M�m 2021/05/10 ------------------------------------>>>>>
                //this._inputForm.DataSave += new DataSaveEventHandler(this.Save);
                // --- ADD ���J�M�m 2021/05/10 ------------------------------------<<<<<
                this._inputForm.SetGuideEnabled += new SetGuideEnableEventHandler(this.SetGuideEnabled);
                // --- ADD 2010/08/10 ------------------------------------<<<<<
			}
			else if (mode == EXEC_MODE_VIEWER)
			{
			}
		}

		/// <summary>
		/// �����ݒ�n�f�[�^���[�h����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ�n�f�[�^�����[�h���܂��B�񓯊������ł��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void InitialDataRead()
		{
			// �I�t���C�����[�h�̏ꍇ�͏������Ȃ�
			if (!LoginInfoAcquisition.OnlineFlag)
			{
				return;
			}
		}

		/// <summary>
		/// �����ݒ�n�f�[�^���[�h�����R�[���o�b�N���\�b�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ�n�f�[�^���[�h����������������Ɏ��s����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void InitialDataReadCallBack(IAsyncResult ar)
		{
			InitialDataReadHandler initialDataReadHandler = (InitialDataReadHandler)ar.AsyncState;
			initialDataReadHandler.EndInvoke(ar);
		}

		/// <summary>
		/// �c�[���o�[�p�����q���g������i�[�pHashtable�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�p�����q���g������i�[�pHashtable�ݒ菈���ɏ����q���g���i�[���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void ToolTipTextTableSetting()
		{
			foreach (object tool in this.Main_ToolbarsManager.Tools.All)
			{
				if (tool is Infragistics.Win.UltraWinToolbars.PopupMenuTool)
				{
					this._initToolTipTextTable.Add(((Infragistics.Win.UltraWinToolbars.PopupMenuTool)tool).Key, 
						((Infragistics.Win.UltraWinToolbars.PopupMenuTool)tool).SharedProps.ToolTipText);
				}
				else if (tool is Infragistics.Win.UltraWinToolbars.ButtonTool)
				{
					this._initToolTipTextTable.Add(((Infragistics.Win.UltraWinToolbars.ButtonTool)tool).Key,
						((Infragistics.Win.UltraWinToolbars.ButtonTool)tool).SharedProps.ToolTipText);
				}
			}
		}

		/// <summary>
		/// �c�[���o�[�p�����q���g������擾����
		/// </summary>
		/// <param name="key">�c�[���{�^���pKey</param>
		/// <returns>�c�[���o�[�p�����q���g������</returns>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�p�����q���g��������擾���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private string GetInitToolTipText(string key)
		{
			if (this._initToolTipTextTable.ContainsKey(key))
			{
				return this._initToolTipTextTable[key].ToString();
			}
			else
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�̏����ݒ���s���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             ���Ӑ�}�X�^��Q���ǑΉ�</br>
        /// </remarks>
		private void SetToolbar()
		{
			// �C���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = this._imageList16;

			// ���O�C���S���҂ւ̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
			loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			
			// �V�K�̃A�C�R���ݒ�
			this.buttonTool_New.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			
			// �ۑ��̃A�C�R���ݒ�
			this.buttonTool_Save.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

			// �I���̃A�C�R���ݒ�
			this.buttonTool_Close.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            //// �`�[�ɔ��f�̃A�C�R���ݒ�
            //this.buttonTool_Reflect.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPREFLECT;

			// �����̃A�C�R���ݒ�
			this.buttonTool_Search.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

			// �ݒ�̃A�C�R���ݒ�
			this.buttonTool_Setup.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

			// ���ɖ߂��̃A�C�R���ݒ�
			this.buttonTool_Retry.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

			// �폜�̃A�C�R���ݒ�
			this.buttonTool_Delete.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERDELETE;

			// �ҏW�̃A�C�R���ݒ�
			this.buttonTool_Edit.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // �����̃A�C�R���ݒ�
            this.buttonTool_Revive.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // ���S�폜�̃A�C�R���ݒ�
            this.buttonTool_CompleteDelete.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // --- ADD 2008/09/04 --------------------------------<<<<< 
            
            // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.buttonTool_Renewal.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.buttonTool_Guide.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // --- ADD 2010/08/10 ------------------------------------<<<<< 

            //// �����̃A�C�R���ݒ�
            //this.buttonTool_Memo.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.FREEMEMO;

            //// �d��������͂̃A�C�R���^�\����\���ݒ�
            //this.buttonTool_CustSuppli.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERCORP1;

			// �Ǘ����_�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.LabelTool sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools["SectionTitle_LabelTool"];
			sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

            //// �Ǘ����_�R���{�{�b�N�X�̐ݒ�
            //try
            //{
            //    this._sectionInfoControl.SetSectionComboEditor(ref this.comboBoxTool_Section, false);

            //    // ���_�R���{�G�f�B�^�I��l�ݒ菈��
            //    this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._loginSectionCode);
            //}
            //catch (ApplicationException ex)
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_STOP,
            //        this.Name,
            //        ex.Message,
            //        0,
            //        MessageBoxButtons.OK);

            //    this.Close();
            //    return;
            //}

            //Infragistics.Win.UltraWinToolbars.ControlContainerTool sectionContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools["SectionCode_ControlContainerTool"];

            //if (CustomerSectionInfoControl.IsSectionOptionIntroduce)
            //{
            //    sectionTitleLabel.SharedProps.Visible = true;
            //    sectionContainer.SharedProps.Visible = true;
            //    this.comboBoxTool_Section.SharedProps.Visible = true;
            //}
            //else
            //{
            //    sectionTitleLabel.SharedProps.Visible = false;
            //    sectionContainer.SharedProps.Visible = false;
            //    this.comboBoxTool_Section.SharedProps.Visible = false;
            //}
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void InitialSetting()
		{
			// �c�[���o�[�����ݒ菈��
			this.SetToolbar();

			// �e�R���g���[�������ݒ�
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;

			Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginInfoAcquisition.Employee != null)
			{
				if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}
		}

		/// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�{�^���L�������ݒ���s���܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             ���Ӑ�}�X�^��Q���ǑΉ�</br>
        /// </remarks>
		private void ToolBarButtonEnabledSetting()
		{
			// StaticMemory�ύX�L���`�F�b�N 
			int compareFlg = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (compareFlg == 0)
			{
				// �߂�{�^���𖳌��ɂ���
				this.buttonTool_Retry.SharedProps.Enabled = false;
			}
			else
			{
				// �߂�{�^����L���ɂ���
				this.buttonTool_Retry.SharedProps.Enabled = true;
			}

			// �V�Kor�X�V�ɂă{�^���̗L�������𐧌䂷��
			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				this.buttonTool_Delete.SharedProps.Enabled = false;				// �폜
                // --- ADD 2008/09/04 -------------------------------->>>>>
                this.buttonTool_CompleteDelete.SharedProps.Enabled = false;
                this.buttonTool_Revive.SharedProps.Enabled = false;
                // --- ADD 2008/09/04 --------------------------------<<<<<
			}
			else
			{
				this.buttonTool_Delete.SharedProps.Enabled = true;				// �폜
                // --- ADD 2008/09/04 -------------------------------->>>>>
                this.buttonTool_CompleteDelete.SharedProps.Enabled = true;
                this.buttonTool_Revive.SharedProps.Enabled = true;
                // --- ADD 2008/09/04 --------------------------------<<<<<
			}

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // �_���폜�ɂėL�������𐧌䂷��
            if (_customerInfo.LogicalDeleteCode == 0)
            {
                this.buttonTool_Save.SharedProps.Enabled = true;
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Enabled = true;
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            }
            else
            {
                this.buttonTool_Save.SharedProps.Enabled = false;
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Enabled = false;
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            }
            // --- ADD 2008/09/04 --------------------------------<<<<<

            //// �Q�Ɖ�ʂ̏ꍇ�͊Ǘ����_�𖳌��ɂ���
            //// �Q�Ɖ�ʂŃ��������蓖�Ă��Ă��Ȃ��ꍇ�́A�����{�^���𖳌��ɂ���
            //if (this._execMode == EXEC_MODE_EDIT)
            //{
            //    if (this._sectionInfoControl.IsMainOfficeFunc())
            //    {
            //        this.comboBoxTool_Section.SharedProps.Enabled = true;
            //    }
            //    else
            //    {
            //        this.comboBoxTool_Section.SharedProps.Enabled = false;
            //    }


            //    //if (this._customerInfo.TakeInImageGroupCd == Guid.Empty)
            //    //{
            //    //    this.buttonTool_Memo.SharedProps.Enabled = false;
            //    //}
            //    //else
            //    //{
            //    //    this.buttonTool_Memo.SharedProps.Enabled = true;
            //    //}
            //}
            //else
            //{
            //    this.comboBoxTool_Section.SharedProps.Enabled = false;
            //    this.buttonTool_Memo.SharedProps.Enabled = false;
            //}

            //// �d����敪���S��0�̏ꍇ�͎d��������̓{�^���𖳌�������
            //if ((this._customerInfo.SupplierDiv == 0) && (this._customerInfo.SupplierDiv == 0))
            //{
            //    this.buttonTool_CustSuppli.SharedProps.Enabled = false;

            //    // ToolTipText��L�������p�ɕύX����
            //    this.buttonTool_CustSuppli.SharedProps.ToolTipText = TOOL_TIP_TEXT_ENABLED_CUSTSUPPLI;
            //}
            //else
            //{
            //    this.buttonTool_CustSuppli.SharedProps.Enabled = true;

            //    // ToolTipText�����ɖ߂�
            //    this.buttonTool_CustSuppli.SharedProps.ToolTipText = this.GetInitToolTipText(this.buttonTool_CustSuppli.Key);
            //}

            // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�t���C�����[�h�ł͎g�p�ł��Ȃ��{�^���𖳌�������
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    this.buttonTool_Save.SharedProps.Enabled = false;						// �ۑ��{�^��
            //    this.buttonTool_New.SharedProps.Enabled = false;						// �V�K
            //    //this.buttonTool_CustSuppli.SharedProps.Enabled = false;					// �d��������̓{�^��
            //    this.buttonTool_Edit.SharedProps.Enabled = false;						// �ҏW�{�^��
            //    // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            //    this.buttonTool_Renewal.SharedProps.Enabled = false;						// �ŐV�{�^��
            //    // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            //}
            // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// �t�H�[���e�L�X�g�ݒ菈��


            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.buttonTool_Guide.SharedProps.Enabled = false;
            // --- ADD 2010/08/10 ------------------------------------<<<<<
			this.SetFormText();
		}

		/// <summary>
		/// �c�[���o�[�{�^���\����\���R���g���[������
		/// </summary>
		private void ToolBarButtonVisibleControl()
		{
			if (this._execMode == EXEC_MODE_EDIT)
			{
				this.buttonTool_New.SharedProps.Visible = true;
				this.buttonTool_Save.SharedProps.Visible = true;
				this.buttonTool_Setup.SharedProps.Visible = true;
				this.buttonTool_Retry.SharedProps.Visible = true;
                // --- DEL 2008/09/04 -------------------------------->>>>>
				//this.buttonTool_Delete.SharedProps.Visible = true;
                // --- DEL 2008/09/04 --------------------------------<<<<<
				this.buttonTool_Edit.SharedProps.Visible = false;
                //this.buttonTool_Memo.SharedProps.Visible = true;
                //this.buttonTool_CustSuppli.SharedProps.Visible = true;
                
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Visible = true;
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                // --- ADD 2008/09/04 -------------------------------->>>>>
                // �폜�Ɗ��S�폜�E�����͕\�����䂷��
                if (this._customerInfo.LogicalDeleteCode == 0)
                {
                    this.buttonTool_Delete.SharedProps.Visible = true;
                    this.buttonTool_Revive.SharedProps.Visible = false;
                    this.buttonTool_CompleteDelete.SharedProps.Visible = false;
                }
                else if (this._customerInfo.LogicalDeleteCode == 1)
                {
                    this.buttonTool_Delete.SharedProps.Visible = false;
                    this.buttonTool_Revive.SharedProps.Visible = true;
                    this.buttonTool_CompleteDelete.SharedProps.Visible = true;
                }
                else
                {
                    this.buttonTool_Delete.SharedProps.Visible = false;
                    this.buttonTool_Revive.SharedProps.Visible = false;
                    this.buttonTool_CompleteDelete.SharedProps.Visible = false;
                }

                // --- ADD 2008/09/04 --------------------------------<<<<< 
			}
			else
			{
				this.buttonTool_New.SharedProps.Visible = false;
				this.buttonTool_Save.SharedProps.Visible = false;
				this.buttonTool_Setup.SharedProps.Visible = false;
				this.buttonTool_Retry.SharedProps.Visible = false;
				this.buttonTool_Delete.SharedProps.Visible = false;
				this.buttonTool_Edit.SharedProps.Visible = true;
                // --- ADD 2008/09/04 -------------------------------->>>>>
                this.buttonTool_Revive.SharedProps.Visible = false;
                this.buttonTool_CompleteDelete.SharedProps.Visible = false;
                // --- ADD 2008/09/04 --------------------------------<<<<< 
                //this.buttonTool_Memo.SharedProps.Visible = true;
                //this.buttonTool_CustSuppli.SharedProps.Visible = false;

                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Visible = false;
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
			}

			this.buttonTool_Search.SharedProps.Visible = false;
            //this.buttonTool_Reflect.SharedProps.Visible = false;

			// �C�x���g��null�̏ꍇ�͊Y������{�^�����\���Ƃ���
			if (this.OwnerFormBringToFront == null)
			{
				this.buttonTool_Search.SharedProps.Visible = false;
			}

			// PopupMenu����Tool�����݂��Ȃ��ꍇ��PopupMenu���\���Ƃ���
			Infragistics.Win.UltraWinToolbars.PopupMenuTool[] popupMenuToolArray = new Infragistics.Win.UltraWinToolbars.PopupMenuTool[5];
			popupMenuToolArray[0] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["File_PopupMenuTool"];
			popupMenuToolArray[1] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["AddInfo_PopupMenuTool"];
			popupMenuToolArray[2] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["Guide_PopupMenuTool"];
			popupMenuToolArray[3] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["Tool_PopupMenuTool"];
			popupMenuToolArray[4] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["Window_PopupMenuTool"];

			foreach(Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool in popupMenuToolArray)
			{
				if (popupMenuTool != null)
				{
					int count = 0;
					foreach(Infragistics.Win.UltraWinToolbars.ToolBase toolBase in popupMenuTool.Tools)
					{
						if (toolBase.SharedProps.Visible)
						{
							count++;
						}
					}

					if (count == 0)
					{
						popupMenuTool.SharedProps.Visible = false;
					}
					else
					{
						popupMenuTool.SharedProps.Visible = true;
					}
				}
			}
		}

		/// <summary>
		/// �f�[�^�߂��m�F����
		/// </summary>
		/// <param name="isCompare">��r���s�t���O[true:��r���� false:��r���Ȃ�]</param>
		/// <returns>true:�`�F�b�N���䊮�� false:�L�����Z��</returns>
		private bool DataBackDialogCheck(bool isCompare)
		{
			bool result = true;

			int status = 1;
			if (isCompare)
			{
				status = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);
			}

			if (status != 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" +
					"������Ԃɖ߂��܂����H",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				switch (dialogResult)
				{
					case (DialogResult.Yes):
					{
						break;
					}
					default:
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = true;
			}

			return result;
		}

		/// <summary>
		/// �f�[�^�폜�m�F����
		/// </summary>
		/// <returns>TRUE:�`�F�b�N���䊮�� FALSE:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�폜�m�F���������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private bool DataDeleteDialogCheck()
		{
			bool result = true;

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"���ݕ\�����̓��Ӑ���폜���܂��B" + "\r\n" +
				"��낵���ł����H",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			switch (dialogResult)
			{
				case (DialogResult.Yes):
				{
					result = true;
					break;
				}
				case (DialogResult.No):
				{
					result = false;
					break;
				}
				default:
				{
					result = false;
					break;
				}
			}

			return result;
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// �f�[�^�����m�F����
        /// </summary>
        /// <returns>TRUE:�`�F�b�N���䊮�� FALSE:�L�����Z��</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�����m�F���������s���܂��B</br>
        /// <br>Programmer : 30452 ���r��</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private bool DataReviveDialogCheck()
        {
            bool result = true;

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "���ݕ\�����̓��Ӑ�𕜊����܂��B" + "\r\n" +
                "��낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            switch (dialogResult)
            {
                case (DialogResult.Yes):
                    {
                        result = true;
                        break;
                    }
                case (DialogResult.No):
                    {
                        result = false;
                        break;
                    }
                default:
                    {
                        result = false;
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// �f�[�^���S�폜�m�F����
        /// </summary>
        /// <returns>TRUE:�`�F�b�N���䊮�� FALSE:�L�����Z��</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���S�폜�m�F���������s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private bool DataCompleteDeleteDialogCheck()
        {
            bool result = true;

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "���ݕ\�����̓��Ӑ�����S�폜���܂��B" + "\r\n" +
                "��낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            switch (dialogResult)
            {
                case (DialogResult.Yes):
                    {
                        result = true;
                        break;
                    }
                case (DialogResult.No):
                    {
                        result = false;
                        break;
                    }
                default:
                    {
                        result = false;
                        break;
                    }
            }

            return result;
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		/// <summary>
		/// �f�[�^�o�^����
		/// </summary>
		/// <param name="saveCompletionDialogDisp">�ۑ������_�C�A���O�\���t���O</param>
		/// <returns>STATUS</returns>
        /// <remarks>
        /// <br>UpdateNote�@: 2011/08/04 caohh</br>
        /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// </remarks>
        private int Save(bool saveCompletionDialogDisp)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
			ArrayList duplicationItemList = new ArrayList();
			ArrayList itemList = new ArrayList();

			// �\�����f�[�^StaticMemory�o�^����
			this._inputForm.SaveStaticMemoryData(this);

			// Static���̎擾����
			CustomerInfo customerInfo;
			status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
               
                #region DEL 2008/12/12
                //// ���Ӑ�N���X���̓f�[�^�`�F�b�N����
                //if (!this._customerInfoAcs.CustomerInputDataCheck(customerInfo, out duplicationItemList, out itemList))
                //{
                //    StringBuilder message = new StringBuilder();
                //    message.Append("�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B" + "\r\n" + "\r\n");

                //    foreach (string s in duplicationItemList)
                //    {
                //        message.Append(s + "\r\n");
                //    }
						
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        message.ToString(),
                //        status,
                //        MessageBoxButtons.OK);

                //    string itemName = string.Empty;
                //    if (itemList.Count > 0)
                //    {
                //        itemName = itemList[0].ToString();

                //        // �w��t�H�[�J�X�ݒ菈��
                //        this.SetFocus(itemName);
                //    }

                //    return -1;
                //}

                //// ADD 2008/12/03 �s��Ή�[8548] ---------->>>>>
                //// ���_���݃`�F�b�N����
                //string sectionCode = customerInfo.MngSectionCode;
                //StringBuilder Sectionmessage = new StringBuilder();
                //bool errFlg = false;
                //bool errFlg2 = false;

                //SecInfoSet secInfoSet;
                //int CkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, sectionCode);
                //if (CkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    errFlg = true;
                //}

                //sectionCode = customerInfo.ClaimSectionCode;

                //CkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, sectionCode);
                //if (CkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    errFlg2 = true;
                    
                //}
                //if (errFlg == true ||
                //    errFlg2==true)
                //{
                //    Sectionmessage.Append("���_���폜����Ă��܂��B" + "\r\n" + "\r\n");

                //    if (errFlg == true)
                //    {
                //        Sectionmessage.Append("�Ǘ����_" + "\r\n");
                //    }
                //    if (errFlg2 == true)
                //    {
                //        Sectionmessage.Append("�������_" + "\r\n");
                //    }
                //    TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //            this.Name,
                //            Sectionmessage.ToString(),
                //            status,
                //            MessageBoxButtons.OK);

                //    if (errFlg == true)
                //    {
                //        // �w��t�H�[�J�X�ݒ菈��
                //        this.SetFocus("ClaimSectionCode");
                //    }
                //    else
                //    {
                //        // �w��t�H�[�J�X�ݒ菈��
                //        this.SetFocus("MngSectionCode");
                //    }

                //    return -1;
                //}
                //// ADD 2008/12/03 �s��Ή�[8548] ----------<<<<<


                //// ADD 2008/12/05 �s��Ή�[8763] ---------->>>>>
                //// �D��q�ɑ��݃`�F�b�N����

                //// ���ޕϊ�
                //string warehouseCode = customerInfo.CustWarehouseCd;

                //Warehouse warehouse = null;
                //int WarehouseStatus = this._customerInputAcs.GetWarehouseFromWarehouseCode(out warehouse, customerInfo.MngSectionCode, warehouseCode);

                //// ADD 2008/12/10 �s��Ή�[8763] ---------->>>>>
                //if (warehouseCode != null &&
                //    !warehouseCode.Trim().Equals(string.Empty) &&
                //    !warehouseCode.Trim().Equals("0"))
                //{
                //// ADD 2008/12/10 �s��Ή�[8763] ----------<<<<<
                //    if (WarehouseStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //            this.Name,
                //            // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //            //"�D��q�ɂ��폜����Ă��܂��B",
                //            "�D��q�ɂ��}�X�^�ɖ��o�^�A�܂��͍폜����Ă��܂��B",
                //            // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                //            status,
                //            MessageBoxButtons.OK);

                //        // �w��t�H�[�J�X�ݒ菈��
                //        this.SetFocus("CustWarehouseCd");

                //        return -1;
                //    }
                //// ADD 2008/12/10 �s��Ή�[8763] ---------->>>>>
                //}
                //// ADD 2008/12/10 �s��Ή�[8763] ----------<<<<<
                //// ADD 2008/12/05 �s��Ή�[8763] ----------<<<<<


                //// ���Ӑ�N���X�s���f�[�^�`�F�b�N����
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
                ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 DEL
                //////if (!this._customerInfoAcs.CustomerUnJustDataCheck(customerInfo, out duplicationItemList, out itemList))
                ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 DEL
                ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
                ////if ( !this.CustomerUnJustDataCheckScreen( customerInfo, out duplicationItemList, out itemList ) )
                ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                //if ( !this._inputForm.CustomerUnJustDataCheck( out duplicationItemList, out itemList ) )
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                //{
                //    StringBuilder message = new StringBuilder();
                //    message.Append("���͒l���s���ȍ��ڂ����݂��邽�߁A�o�^�ł��܂���B" + "\r\n" + "\r\n");

                //    foreach (string s in duplicationItemList)
                //    {
                //        message.Append(s + "\r\n");
                //    }
						
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        message.ToString(),
                //        status,
                //        MessageBoxButtons.OK);

                //    string itemName = string.Empty;
                //    if (itemList.Count > 0)
                //    {
                //        itemName = itemList[0].ToString();

                //        // �w��t�H�[�J�X�ݒ菈��
                //        this.SetFocus(itemName);
                //    }

                //    return -1;
                //}

                //// �����摶�݃`�F�b�N����
                //if ((customerInfo.ClaimCode != 0) && (customerInfo.CustomerCode != customerInfo.ClaimCode))
                //{
                //    int existStatus = this._customerInfoAcs.ExistData(customerInfo.EnterpriseCode, customerInfo.ClaimCode, ConstantManagement.LogicalMode.GetData0);

                //    if (existStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //            this.Name,
                //            "�����悪�폜����Ă��܂��B",
                //            status,
                //            MessageBoxButtons.OK);

                //        // �w��t�H�[�J�X�ݒ菈��
                //        this.SetFocus("ClaimName");

                //        return -1;
                //    }
                //}
                #endregion DEL 2008/12/12

                // ���Ӑ�N���X���̓f�[�^�`�F�b�N����
                this._customerInfoAcs.CustomerInputDataCheck(customerInfo, out duplicationItemList, out itemList);

                if (!customerInfo.IsReceiver)
                {
                    // ���_���݃`�F�b�N����
                    bool mngSectionCheck = false;
                    bool claimSectionCheck = false;
                    foreach (string name in duplicationItemList)
                    {
                        if (name == "�Ǘ����_")
                        {
                            mngSectionCheck = true;
                        }
                        if (name == "�������_")
                        {
                            claimSectionCheck = true;
                        }

                        if ((mngSectionCheck == true) && (claimSectionCheck == true))
                        {
                            break;
                        }
                    }

                    SecInfoSet secInfoSet;
                    if (!mngSectionCheck)
                    {
                        int chkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, customerInfo.MngSectionCode);
                        if (chkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            duplicationItemList.Add("�Ǘ����_");
                            itemList.Add("MngSectionCode");
                        }
                    }
                    if (!claimSectionCheck)
                    {
                        int chkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, customerInfo.ClaimSectionCode);
                        if (chkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            duplicationItemList.Add("�������_");
                            itemList.Add("ClaimSectionCode");
                        }
                    }
                }

                // ���Ӑ�S���`�F�b�N����
                if ((customerInfo.CustomerAgentCd != null) && (customerInfo.CustomerAgentCd.Trim() != ""))
                {
                    Employee employee;
                    int employeeStatus = this._customerInputAcs.GetEmployeeFromEmployeeCode(customerInfo.CustomerAgentCd.Trim(), out employee);
                    if (employeeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("���Ӑ�S��");
                        itemList.Add("CustomerAgentCd");
                    }
                }

                // ���S���`�F�b�N����
                if ((customerInfo.OldCustomerAgentCd != null) && (customerInfo.OldCustomerAgentCd.Trim() != ""))
                {
                    Employee employee;
                    int employeeStatus = this._customerInputAcs.GetEmployeeFromEmployeeCode(customerInfo.OldCustomerAgentCd.Trim(), out employee);
                    if (employeeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("���S��");
                        itemList.Add("OldCustomerAgentCd");
                    }
                }

                // �W���S���`�F�b�N����
                if ((customerInfo.BillCollecterCd != null) && (customerInfo.BillCollecterCd.Trim() != ""))
                {
                    Employee employee;
                    int employeeStatus = this._customerInputAcs.GetEmployeeFromEmployeeCode(customerInfo.BillCollecterCd.Trim(), out employee);
                    if (employeeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("�W���S��");
                        itemList.Add("BillCollecterCd");
                    }
                }

                // �D��q�ɑ��݃`�F�b�N����
                if ((customerInfo.CustWarehouseCd != null) && (customerInfo.CustWarehouseCd.Trim() != ""))
                {
                    Warehouse warehouse;
                    int warehouseStatus = this._customerInputAcs.GetWarehouseFromWarehouseCode(out warehouse, customerInfo.MngSectionCode, customerInfo.CustWarehouseCd);
                    if (warehouseStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("�D��q��");
                        itemList.Add("CustWarehouseCd");
                    }
                }

                // --- ADD 2010/12/06 ------------------------------------>>>>>
                // �����̓��̓`�F�b�N
                if (this._inputForm.CheckTotalDay(this._customerTotalDayList) < 0)
                {
                    duplicationItemList.Add("����");
                    itemList.Add("TotalDay");
                }
                // --- ADD 2010/12/06 ------------------------------------<<<<<

                ArrayList duplicationItemList2 = new ArrayList();
                ArrayList itemList2 = new ArrayList();
                this._inputForm.CustomerUnJustDataCheck(out duplicationItemList2, out itemList2);

                // �����摶�݃`�F�b�N����
                bool claimCheck = false;
                foreach (string name in duplicationItemList)
                {
                    if (name == "������R�[�h")
                    {
                        claimCheck = true;
                        break;
                    }
                }

                if (!claimCheck)
                {
                    if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                    {
                        int existStatus = this._customerInfoAcs.ExistData(customerInfo.EnterpriseCode, customerInfo.ClaimCode, ConstantManagement.LogicalMode.GetData0);
                        if (existStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            duplicationItemList2.Add("������R�[�h");
                            itemList2.Add("ClaimName");
                        }
                    }
                }

                //ADD 2008/12/26 �s��Ή�[9531] ---------->>>>>
                //��������̃`�F�b�N
                string fildname = "";
                if (customerInfo.AccRecDivCd == 0)
                {
                    if(customerInfo.ConsTaxLayMethod == 2){
                        fildname = "�����e";
                    }else if(customerInfo.ConsTaxLayMethod == 3){
                        fildname = "�����q";
                    }

                    if (fildname.Equals(string.Empty) == false)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    fildname + "�ɂȂ��Ă���ׁA���|�Ȃ��̎w��͂ł��܂���B",
                                    status,
                                    MessageBoxButtons.OK);

                        // �w��t�H�[�J�X�ݒ菈��
                        this.SetFocus("AccRecDivCd");

                        return -1;
                    }
                }
                //ADD 2008/12/26 �s��Ή�[9531] ----------<<<<<

                // ADD 2009/06/03 ------>>>
                if (customerInfo.OnlineKindDiv != 0)
                {
                    // �I�����C���ڑ��敪��"�Ȃ�"�ȊO
                    if (customerInfo.CustomerEpCode == string.Empty)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "���Ӑ��ƃR�[�h����͂��ĉ������B",
                                    status,
                                    MessageBoxButtons.OK);
                        // �w��t�H�[�J�X�ݒ菈��
                        this.SetFocus("CustomerEpCode");
                        return -1;
                    }
                    else if (customerInfo.CustomerEpCode.Length != 16)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "���Ӑ��ƃR�[�h�͂P�U���œ��͂��ĉ������B",
                                    status,
                                    MessageBoxButtons.OK);
                        // �w��t�H�[�J�X�ݒ菈��
                        this.SetFocus("CustomerEpCode");
                        return -1;
                    }

                    if (customerInfo.CustomerSecCode == string.Empty)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "���Ӑ拒�_�R�[�h����͂��ĉ������B",
                                    status,
                                    MessageBoxButtons.OK);
                        // �w��t�H�[�J�X�ݒ菈��
                        this.SetFocus("CustomerSecCode");
                        return -1;
                    }
                }
                // ADD 2009/06/03 ------<<<

                Dictionary<string, string> duplicationItemDic = new Dictionary<string, string>();
                foreach (string itemName in duplicationItemList)
                {
                    if (!duplicationItemDic.ContainsKey(itemName))
                    {
                        duplicationItemDic.Add(itemName, itemName);
                    }
                }
                foreach (string itemName in duplicationItemList2)
                {
                    if (!duplicationItemDic.ContainsKey(itemName))
                    {
                        duplicationItemDic.Add(itemName, itemName);
                    }
                }


                Dictionary<string, string> itemListDic = new Dictionary<string, string>();
                foreach (string itemName in itemList)
                {
                    if (!itemListDic.ContainsKey(itemName))
                    {
                        itemListDic.Add(itemName, itemName);
                    }
                }
                foreach (string itemName in itemList2)
                {
                    if (!itemListDic.ContainsKey(itemName))
                    {
                        itemListDic.Add(itemName, itemName);
                    }
                }

                if (duplicationItemDic.Count > 0)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("���͒l���s���ȍ��ڂ����݂��邽�߁A�o�^�ł��܂���B" + "\r\n" + "\r\n");

                    foreach (string s in duplicationItemDic.Values)
                    {
                        message.Append(s + "\r\n");
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        status,
                        MessageBoxButtons.OK);

                    string itemName = string.Empty;
                    if (itemList.Count > 0)
                    {
                        itemName = itemList[0].ToString();

                        // �w��t�H�[�J�X�ݒ菈��
                        this.SetFocus(itemName);
                    }

                    return -1;
                }

                // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<

				// StaticMemory�c�a�������ݏ���
				status = this._customerInfoAcs.WriteDBData(this, false, ref customerInfo, out duplicationItemList);
				
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this._customerInfo = customerInfo.Clone();

					// Static��������ʏ��\������
					this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

					// �c�[���o�[�{�^���L�������ݒ菈��
					this.ToolBarButtonEnabledSetting();

					StringBuilder message = new StringBuilder();

					foreach(string s in duplicationItemList)
					{
						if (s.Trim() != "")
						{
							message.Append(s + "\r\n");
						}
					}

					if (message.ToString().Trim() != "")
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							message.ToString(),
							0,
							MessageBoxButtons.OK);
					}

					if (saveCompletionDialogDisp)
					{
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // �f�[�^�X�V�C�x���g�R�[��
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // �\���f�[�^�N���[������
                    CustomerInfo customerInfoDispBuffer = _customerInfo.Clone();
                    customerInfoDispBuffer.CustomerCode = 0;
                    customerInfoDispBuffer.ClaimCode = 0;
                    customerInfoDispBuffer.ClaimName = string.Empty;
                    customerInfoDispBuffer.ClaimName2 = string.Empty;
                    customerInfoDispBuffer.ClaimSnm = string.Empty;
                    customerInfoDispBuffer.UpdateDateTime = DateTime.MinValue;

                    // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                    //�u1�F���Ӑ�R�[�h��ێ��v�̏ꍇ�A���Ӑ�R�[�h���擾����
                    int customerCodeTmp = 0;
                    if (_customerInputConstructionAcs.KeepOnInfoSetting == 1)
                    {
                        customerCodeTmp = this._customerInfo.CustomerCode;
                    }
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<

                    // StaticMemory����������
                    this._customerInputAcs.InitialStaticMemory( 0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo );

                    // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                    //�u1�F���Ӑ�R�[�h��ێ��v�̏ꍇ�A���Ӑ�R�[�h�����Z�b�g����
                    if (_customerInputConstructionAcs.KeepOnInfoSetting == 1)
                    {
                        customerInfoDispBuffer = this._customerInfo;
                    }
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<

                    // ��ʏ��\������
                    this._inputForm.ShowCustomerBuffer( this, this._enterpriseCode, customerInfoDispBuffer );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                    //�u1�F���Ӑ�R�[�h��ێ��v�̏ꍇ�A��ʂɓ��Ӑ�R�[�h���Z�b�g����
                    if (_customerInputConstructionAcs.KeepOnInfoSetting == 1)
                    {
                        if (customerCodeTmp != 0)
                        {
                            this._inputForm.SetCustomerCode(customerCodeTmp);
                        }
                    }
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                    // �����t�H�[�J�X
                    SetInitFocus();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
				{
					foreach(string strItem in duplicationItemList)
					{
						switch (strItem)
						{
							case "CustomerSubCode":
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"���̓��Ӑ�T�u�R�[�h�͊��ɓo�^�ς݂ł��B",
									status,
									MessageBoxButtons.OK);

								break;
							}
							default:
							{
								break;
							}
						}
					}
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
				{
					if (duplicationItemList.Count > 0)
					{
						StringBuilder message = new StringBuilder();

						foreach(string s in duplicationItemList)
						{
							if (s.Trim() != "")
							{
								message.Append(s + "\r\n");
							}
						}

						if (message.ToString().Trim() != "")
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								message.ToString(),
								0,
								MessageBoxButtons.OK);
						}
					}
					else
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"���݁A�ҏW���̓��Ӑ�f�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
							"�ŐV�̏����擾���܂����H",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							// �I���R�[�h�ύX�㔭���C�x���g
							this.SelectCodeChangedEvent(this, new EventArgs());
						}
					}
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
				{
					string errorMsg = string.Empty;

					foreach (string strItem in duplicationItemList)
					{
						switch (strItem)
						{
							case "CustomerSubCode":
							{
								break;
							}
							default:
							{
								errorMsg = strItem;
								break;
							}
						}

						if (errorMsg != "")
						{
							break;
						}
					}

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"�f�[�^�T�[�o�[�̐ڑ����^�C���A�E�g�ɂȂ�܂����B" + "\r\n" + "\r\n" +
						errorMsg,
						status,
						MessageBoxButtons.OK);
				}
				else
				{
					string errorMsg = string.Empty;

					foreach(string strItem in duplicationItemList)
					{
						switch (strItem)
						{
							case "CustomerSubCode":
							{
								break;
							}
							default:
							{
								errorMsg = strItem;
								break;
							}
						}

						if (errorMsg != "")
						{
							break;
						}
					}

					if (errorMsg != "")
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"���Ӑ���̓o�^�Ɏ��s���܂����B" + "\r\n" + 
							errorMsg,
							status,
							MessageBoxButtons.OK);
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"���Ӑ���̓o�^�Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK);
					}
				}
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�o�^�Ώۃf�[�^�����݂��܂���B",
					status,
					MessageBoxButtons.OK);
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
        ///// <summary>
        ///// ���̓`�F�b�N�����i�t�h�N���X�{�A�N�Z�X�N���X�j
        ///// </summary>
        ///// <param name="customerInfo"></param>
        ///// <param name="duplicationItemList"></param>
        ///// <param name="itemList"></param>
        ///// <returns></returns>
        //private bool CustomerUnJustDataCheckScreen( CustomerInfo customerInfo, out ArrayList duplicationItemList, out ArrayList itemList )
        //{
        //    ArrayList duplicationItemListUI;
        //    ArrayList itemListUI;
        //    ArrayList duplicationItemListAcs;
        //    ArrayList itemListAcs;

        //    // UI��ł����`�F�b�N�ł��Ȃ����e
        //    bool statusU = this._inputForm.CustomerUnJustDataCheck( out duplicationItemListUI, out itemListUI );
        //    // �A�N�Z�X�N���X�Ń`�F�b�N������e
        //    bool statusA = this._customerInfoAcs.CustomerUnJustDataCheck( customerInfo, out duplicationItemListAcs, out itemListAcs );

        //    duplicationItemList = duplicationItemListUI;
        //    duplicationItemList.AddRange( duplicationItemListAcs );
        //    itemList = itemListUI;
        //    itemList.AddRange( itemListAcs );

        //    // ����true�łȂ���true��Ԃ��Ȃ�
        //    return (statusU && statusA);
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL

		/// <summary>
		/// �_���폜����
		/// </summary>
		/// <returns>STATUS</returns>
		private int LogicalDelete()
		{
			// Static���̎擾����
			CustomerInfo customerInfo;
			int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// ���Ӑ�폜�`�F�b�N����
				string message = string.Empty;
				bool checkFlg = false;
				status = this._customerInfoAcs.DeleteCheck(customerInfo.EnterpriseCode, customerInfo.CustomerCode, out message, out checkFlg);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					if (!checkFlg)
					{
						// Static��������ʏ��\������
						this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"���Ӑ���폜���邱�Ƃ��o���܂���B" + "\r\n" + "\r\n" + 
							message,
							status,
							MessageBoxButtons.OK);

						return -1;
					}
				}
				else
				{
					return status;
				}

				status = this._customerInfoAcs.LogicalDeleteDBData(this, false, ref customerInfo, true);

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�폜���܂����B",
						status,
						MessageBoxButtons.OK);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // �f�[�^�X�V�C�x���g�R�[��
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        _customerInfo.LogicalDeleteCode = 1;
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

					// �폜������́A�u�V�K�v�Ɠ��l�̏��������s����

					// StaticMemory����������
					this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

					// Static��������ʏ��\������
					this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

					// �c�[���o�[�{�^���L�������ݒ菈��
					this.ToolBarButtonEnabledSetting();
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"���݁A�ҏW���̓��Ӑ�f�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
						"�ŐV�̏����擾���܂����H",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult == DialogResult.Yes)
					{
						// �I���R�[�h�ύX�㔭���C�x���g
						this.SelectCodeChangedEvent(this, new EventArgs());
					}
				}
				else if (status == -1)														// 2006.12.15 men add
				{
					// ���[�U�[�ɂ��L�����Z���̏ꍇ�͉����\�����Ȃ�
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"���Ӑ�̍폜�Ɏ��s���܂����B",
						status,
						MessageBoxButtons.OK);
				}
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�폜�Ώۃf�[�^�����݂��܂���B",
					status,
					MessageBoxButtons.OK);
			}

			return status;
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// ���S�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        private int CompleteDelete()
        {
            // Static���̎擾����
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���Ӑ�폜�`�F�b�N����
                string message = string.Empty;
                bool checkFlg = false;

                status = this._customerInfoAcs.CompleteDeleteCheck(customerInfo.EnterpriseCode, customerInfo.CustomerCode, out message, out checkFlg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!checkFlg)
                    {
                        // Static��������ʏ��\������
                        this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���Ӑ���폜���邱�Ƃ��o���܂���B" + "\r\n" + "\r\n" +
                            message,
                            status,
                            MessageBoxButtons.OK);

                        return -1;
                    }
                }
                else
                {
                    return status;
                }

                status = this._customerInfoAcs.CompleteDeleteDBData(this, false, ref customerInfo);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�폜���܂����B",
                        status,
                        MessageBoxButtons.OK);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // �f�[�^�X�V�C�x���g�R�[��
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        _customerInfo.LogicalDeleteCode = 3;
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                    // �폜������́A�u�V�K�v�Ɠ��l�̏��������s����

                    // StaticMemory����������
                    this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

                    // Static��������ʏ��\������
                    this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                    // --- ADD 2008/12/01 -------------------------------->>>>>
                    // �c�[���o�[�{�^���\����\���R���g���[������
                    this.ToolBarButtonVisibleControl();
                    // --- ADD 2008/12/01 --------------------------------<<<<<

                    // �c�[���o�[�{�^���L�������ݒ菈��
                    this.ToolBarButtonEnabledSetting();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "���݁A�ҏW���̓��Ӑ�f�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
                        "�ŐV�̏����擾���܂����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // �I���R�[�h�ύX�㔭���C�x���g
                        this.SelectCodeChangedEvent(this, new EventArgs());
                    }
                }
                else if (status == -1)														// 2006.12.15 men add
                {
                    // ���[�U�[�ɂ��L�����Z���̏ꍇ�͉����\�����Ȃ�
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "���Ӑ�̍폜�Ɏ��s���܂����B",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "�폜�Ώۃf�[�^�����݂��܂���B",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>STATUS</returns>
        private int Revive()
        {
            // Static���̎擾����
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���Ӑ�폜�`�F�b�N����
                string message = string.Empty;

                // �����������s
                status = this._customerInfoAcs.RevivalDBData(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�������܂����B",
                        status,
                        MessageBoxButtons.OK);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // �f�[�^�X�V�C�x���g�R�[��
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        _customerInfo.LogicalDeleteCode = 0;
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                    // ������́A�u�V�K�v�Ɠ��l�̏��������s����

                    // StaticMemory����������
                    this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

                    // Static��������ʏ��\������
                    this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                    // --- ADD 2008/12/01 -------------------------------->>>>>
                    // �c�[���o�[�{�^���\����\���R���g���[������
                    this.ToolBarButtonVisibleControl();
                    // --- ADD 2008/12/01 --------------------------------<<<<<

                    // �c�[���o�[�{�^���L�������ݒ菈��
                    this.ToolBarButtonEnabledSetting();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "���݁A�ҏW���̓��Ӑ�f�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
                        "�ŐV�̏����擾���܂����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // �I���R�[�h�ύX�㔭���C�x���g
                        this.SelectCodeChangedEvent(this, new EventArgs());
                    }
                }
                else if (status == -1)
                {
                    // ���[�U�[�ɂ��L�����Z���̏ꍇ�͉����\�����Ȃ�
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "���Ӑ�̕����Ɏ��s���܂����B",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "�����Ώۃf�[�^�����݂��܂���B",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		/// <summary>
		/// ���ɖ߂�����
		/// </summary>
		private void Retry()
		{
			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory����������
				this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

			}
			else
			{
				// ���Ӑ�f�[�^�߂�����
				this._customerInfoAcs.CopyStaticMemory(1, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

				// Static���̎擾����
				CustomerInfo customerInfo;
				int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    this._customerInfo = customerInfo.Clone();
                //    bool isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);
                //    if (isSetting) this.MngSectionCodeBroadCast();
                //}
			}

			// Static��������ʏ��\������
			this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			// �t�H�[�J�X�����ݒ菈��
			this.SetInitFocus();
		}

		/// <summary>
		/// �f�[�^�ۑ��m�F����
		/// </summary>
		/// <returns>0:�o�^���� 1:�o�^������ 2:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�ۑ��m�F���������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp)
		{
			return this.DataSaveDialogCheck(saveCompletionDialogDisp, false, MessageBoxButtons.YesNoCancel);
		}

		/// <summary>
		/// �f�[�^�ۑ��m�F����
		/// </summary>
		/// <returns>0:�o�^���� 1:�o�^������ 2:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�ۑ��m�F���������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp, bool codeZeroCheck)
		{
			return this.DataSaveDialogCheck(saveCompletionDialogDisp, codeZeroCheck, MessageBoxButtons.YesNoCancel);
		}

		/// <summary>
		/// �f�[�^�ۑ��m�F����
		/// </summary>
		/// <returns>0:�o�^���� 1:�o�^������ 2:�L�����Z��</returns>
		/// <param name="saveCompletionDialogDisp">�ۑ������_�C�A���O�\���t���O</param>
        /// <param name="messageBoxButtons">���b�Z�[�W�{�b�N�X�\���{�^��</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�ۑ��m�F���������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp, MessageBoxButtons messageBoxButtons)
		{
			return this.DataSaveDialogCheck(saveCompletionDialogDisp, false, messageBoxButtons);
		}

		/// <summary>
		/// �f�[�^�ۑ��m�F����
		/// </summary>
		/// <param name="saveCompletionDialogDisp">�ۑ������_�C�A���O�\���t���O</param>
		/// <param name="codeZeroCheck">�R�[�h�[���`�F�b�N�t���O</param>
        /// <param name="messageBoxButtons">���b�Z�[�W�{�b�N�X�\���{�^��</param>
		/// <returns>0:�o�^���� 1:�o�^������ 2:�L�����Z��</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�ۑ��m�F���������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp, bool codeZeroCheck, MessageBoxButtons messageBoxButtons)
		{
			// �Q�Ɖ�ʂ̏ꍇ�̓`�F�b�N���Ȃ�
			if (this._execMode == EXEC_MODE_VIEWER)
			{
				return SAVE_DIALOG_NO;
			}

			int result = SAVE_DIALOG_YES;

			// �\�����f�[�^StaticMemory�o�^����
			//this._inputForm.SaveStaticMemoryData(this);

			int status = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			string message = "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "�o�^���Ă���낵���ł����H";

			if ((status == 0) && (codeZeroCheck) && (this._customerInfo.CustomerCode == 0))
			{
				status = -1;
				message = "���Ӑ��񂪊m�肵�Ă��܂���B" + "\r\n" + "�o�^���Ă���낵���ł����H";
			}

			if (status != 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					message,
					0,
					messageBoxButtons,
					MessageBoxDefaultButton.Button1);

				switch (dialogResult)
				{
					case (DialogResult.Yes):
					{
						// �f�[�^�o�^����
						status = this.Save(saveCompletionDialogDisp);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							result = SAVE_DIALOG_YES;
							break;
						}
						else
						{
							result = SAVE_DIALOG_CANCEL;
							break;
						}
					}
					case (DialogResult.No):
					{
						result = SAVE_DIALOG_NO;
						break;
					}
					default:
					{
						result = SAVE_DIALOG_CANCEL;
						break;
					}
				}
			}
			else
			{
				result = SAVE_DIALOG_YES;
			}

			return result;
		}

		/// <summary>
		/// �����t�H�[�J�X�ݒ菈��
		/// </summary>
		private void SetInitFocus()
		{
			if (this._execMode == EXEC_MODE_EDIT)
			{
				this._inputForm.SetFocus("CustomerCode");
			}
		}

		/// <summary>
		/// �w��t�H�[�J�X�ݒ菈��
		/// </summary>
		private void SetFocus(string ddID)
		{
			if (this._execMode == EXEC_MODE_EDIT)
			{
				this._inputForm.SetFocus(ddID);
			}
		}

		/// <summary>
		/// �t�H�[���e�L�X�g�ݒ菈��
		/// </summary>
		private void SetFormText()
		{
			string kana = string.Empty;

			if (this._customerInfo.CustomerCode == 0)
			{
				kana = "[�V�K]";
			}
			else
			{
				kana = "[" + this._customerInfo.Kana + "]";
			}

            // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �^�C�g���ݒ�
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    this.Text = TITLE + " �| " + kana;
            //}
            //else
            //{
            //    this.Text = TITLE + OFFLINE_TITLE + " �| " + kana;
            //}

            // �^�C�g���ݒ�
            this.Text = TITLE + " �| " + kana;
            // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// �K�C�h�iF5�j�\���ݒ菈��
        /// </summary>
        private void SetGuideEnabled(bool enabled)
        {
            this.buttonTool_Guide.SharedProps.Enabled = enabled;
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        /// <summary>
        /// �����S�̐ݒ�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�����擾���s���܂��B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/12/06</br>
        /// </remarks>
        private int GetBillAllSt()
        {
            int status = this._billAllStAcs.SearchAll(out this._billAllStList, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._customerTotalDayList.Clear();
                foreach (BillAllSt billAllSt in this._billAllStList)
                {
                    // �S�Ћ��ʂ̏ꍇ
                    if ("0".Equals(billAllSt.SectionCode.Trim()) || "00".Equals(billAllSt.SectionCode.Trim()))
                    {
                        // �����̎擾
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay1);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay2);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay3);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay4);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay5);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay6);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay7);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay8);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay9);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay10);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay11);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay12);
                    }
                }
            }
            return status;
        }
		# endregion

		// ===================================================================================== //
		// ���_���䃍�W�b�N
		// ===================================================================================== //
		# region Section Control Methods
		/// <summary>
		/// �Ǘ����_�R�[�h�W�J����
		/// </summary>
		private void MngSectionCodeBroadCast()
		{
            //string mngSectionCode = this.comboBoxTool_Section.ValueList.ValueListItems[this.comboBoxTool_Section.SelectedIndex].DataValue.ToString();

            //if (this._execMode == EXEC_MODE_EDIT)
            //{
            //    if (this._inputForm != null)
            //    {
            //        this._inputForm.MngSectionCode = mngSectionCode;
            //    }
            //}
		}
		# endregion

		// ===================================================================================== //
		// �e�R���|�[�l���g�C�x���g����
		// ===================================================================================== //
		# region Conponent Event Methods
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void PMKHN09000UA_Load(object sender, System.EventArgs e)
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			// �N���`�F�b�N����
			try
			{
				this._sectionInfoControl.CheckSectionInfo();
			}
			catch (ApplicationException ex)
			{
				// �x�����b�Z�[�W��\������i�����_���Ȃ��j
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					ex.Message,
					0,
					MessageBoxButtons.OK);

				if (!this.IsMdiChild)
				{
					this.Close();
					return;
				}
			}

			if (this._initialReadStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// OK
			} 
			else if (this._initialReadStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                //        0,
                //        MessageBoxButtons.OK);
                //}
                //else
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "�I�t���C�����[�h�ׁ̈A�������s���܂���B",
                //        0,
                //        MessageBoxButtons.OK);
                //}

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    0,
                    MessageBoxButtons.OK);
                // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				this.Close();
				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"���Ӑ���̎擾�Ɏ��s���܂����B",
					this._initialReadStatus,
					MessageBoxButtons.OK);
				
				this.Close();
				return;
			}
            // --- ADD 2010/12/06 ------------------------------------>>>>>
            // �����S�̐ݒ�����擾����
            int status = this.GetBillAllSt();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �����S�̐ݒ�����擾�Ɏ��s
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�����S�̐ݒ肪�擾�ł��܂���ł����B" + "\r\n" + 
                    "�����S�̐ݒ��ݒ肵�Ă���N�����ĉ������B",
                    status,
                    MessageBoxButtons.OK);

                this.Close();
                return;
            }
            // --- ADD 2010/12/06 ------------------------------------<<<<<
			// �c�[���o�[�p�����q���g������i�[�pHashtable�ݒ菈��
			this.ToolTipTextTableSetting();

			// ��ʏ���������
			this.InitialSetting();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			// Tab��������
			this.TabCreate(this._execMode);

			// �Ǘ����_�R�[�h�W�J����
			this.MngSectionCodeBroadCast();

			// Static��������ʏ��\������
			this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			// �c�[���o�[�{�^���\����\���R���g���[������
			this.ToolBarButtonVisibleControl();

			// �c�[���o�[�{�^���L�������ݒ菈��
			this.ToolBarButtonEnabledSetting();

			// �t�H�[�J�X�����ݒ菈��
			this.SetInitFocus();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// �^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			IAsyncResult iRet = this._initialDataRead.BeginInvoke(new AsyncCallback(this.InitialDataReadCallBack), this._initialDataRead);

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            try
            {
                // DEL �� 2014/03/07 ---------------------------------------------------------------------------->>>>>
                //this._customerInputConstructionAcs.FirstDisplayTab = this._customerInputConstructionAcs.InputType;
                // DEL �� 2014/03/07 ----------------------------------------------------------------------------<<<<<
            }
            catch
            {
                this._customerInputConstructionAcs.FirstDisplayTab = CustomerInputConstructionAcs.FIRST_DISPLAY_TAB_DEFAULT;
            }
            this._customerInputConstructionAcs.Serialize();
            // --- ADD 2010/08/10 ------------------------------------<<<<<
		}

		/// <summary>
		/// �c�[���o�[�c�[���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Close_ButtonTool":			// �I���{�^��
				{
                    // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    // �f�[�^�ۑ��m�F����
                    //    if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL)
                    //    {
                    //        return;
                    //    }
                    //}

                    // �f�[�^�ۑ��m�F����
                    if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL) return;
                    // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // ���ɖ߂�����
                    this.Retry();

					this.Close();
					break;
				}
				case "Save_ButtonTool":				// �ۑ��{�^��
				{
					// ���Ӑ���o�^����
					this.Save(true);

					break;
				}
				case "Retry_ButtonTool":			// ���ɖ߂��{�^��
				{
					if (!this.DataBackDialogCheck(false))
					{
						return;
					}

					// ���ɖ߂�����
					this.Retry();

                    // �t�H�[�J�X�����ݒ菈��
                    this.SetInitFocus();

					break;
				}
				case "Setup_ButtonTool":			// ���[�U�[�ݒ�{�^��
				{
					this._customerInputSetUp.ShowDialog();
					break;
				}
				case "New_ButtonTool":				// �V�K�{�^��
				{
					// �f�[�^�ۑ��m�F����
					if (this.DataSaveDialogCheck(true) == SAVE_DIALOG_CANCEL)
					{
						return;
					}

					// �V�K���Ӑ��ʕ\������
					this.CustomerNew(this._enterpriseCode);

					break;
				}
                // --- DEL 2010/08/10 ------------------------------------>>>>>
                //case "Delete_ButtonTool":			// �폜�{�^��
                //{
                //    if (!this.buttonTool_Delete.VisibleResolved)
                //    {
                //        return;
                //    }
                //    // �f�[�^�폜�m�F����
                //    if (!this.DataDeleteDialogCheck())
                //    {
                //        return;
                //    }

                //    // ���Ӑ�_���폜����
                //    this.LogicalDelete();

                //    // �t�H�[�J�X�����ݒ菈��
                //    this.SetInitFocus();

                //    break;
                //}
                // --- DEL 2010/08/10 ------------------------------------<<<<<
				case "Edit_ButtonTool":				// �ҏW�{�^��
				{

					break;
				}
				case "OfflineDataOutput_ButtonTool":	// �f�[�^�o��
				{
					// �f�[�^�ۑ��m�F����
					int checkRet = this.DataSaveDialogCheck(true, true, MessageBoxButtons.YesNo);
					 
					if ((checkRet == SAVE_DIALOG_CANCEL) || (checkRet == SAVE_DIALOG_NO))
					{
						return;
					}

					int status = this._customerInfoAcs.WriteOfflineData(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, sender);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"���Ӑ���̃f�[�^�o�͂Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK);

						return;
					}

					break;
				}
				case "Search_ButtonTool":				// ����
				{
					if (this.OwnerFormBringToFront != null)
					{
						this.OwnerFormBringToFront(this, new EventArgs());
					}

					break;
				}
				case "Reflect_ButtonTool":				// �`�[�ɔ��f
				{
					// �f�[�^�ۑ��m�F����
					int checkRet = this.DataSaveDialogCheck(false, true, MessageBoxButtons.YesNo);

					if ((checkRet == SAVE_DIALOG_CANCEL) || (checkRet == SAVE_DIALOG_NO))
					{
						return;
					}

					if (this.OwnerFormBringToFront != null)
					{
						this.OwnerFormBringToFront(this, new EventArgs());
					}

					break;
				}
            // --- ADD 2008/09/04 -------------------------------->>>>>
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //case "CompleteDelete_ButtonTool":
            //    {
            //        // �f�[�^���S�폜�O�m�F����
            //        if (!this.DataCompleteDeleteDialogCheck())
            //        {
            //            return;
            //        }

            //        // ���Ӑ抮�S�폜����
            //        this.CompleteDelete();

            //        // �t�H�[�J�X�����ݒ菈��
            //        this.SetInitFocus();

            //        break;
            //    }
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            case "Delete_ButtonTool":			 // �폜�{�^��
            case "CompleteDelete_ButtonTool":    // ���S�폜�{�^��
                {
                    if (!this.buttonTool_CompleteDelete.VisibleResolved && this.buttonTool_Delete.VisibleResolved)
                    {
                        // �f�[�^�폜�m�F����
                        if (!this.DataDeleteDialogCheck())
                        {
                            return;
                        }

                        // ���Ӑ�_���폜����
                        this.LogicalDelete();
                    }

                    if (this.buttonTool_CompleteDelete.VisibleResolved && !this.buttonTool_Delete.VisibleResolved)
                    {
                        // �f�[�^���S�폜�O�m�F����
                        if (!this.DataCompleteDeleteDialogCheck())
                        {
                            return;
                        }

                        // ���Ӑ抮�S�폜����
                        this.CompleteDelete();
                    }

                    // �t�H�[�J�X�����ݒ菈��
                    this.SetInitFocus();

                    break;
                }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            case "Revive_ButtonTool":
                {
                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    // logicalcode=0�̏ꍇ�A���������ł��܂���
                    if (!this.buttonTool_CompleteDelete.VisibleResolved && this.buttonTool_Delete.VisibleResolved)
                    {
                        return;
                    }
                    // --- ADD 2010/08/10 ------------------------------------<<<<<

                    // �f�[�^�����O�m�F����
                    if (!this.DataReviveDialogCheck())
                    {
                        return;
                    }

                    // ���Ӑ抮�S�폜����
                    this.Revive();

                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    this._inputForm.OnlineKindCheck();
                    // --- ADD 2010/08/10 ------------------------------------<<<<< 

                    // �t�H�[�J�X�����ݒ菈��
                    this.SetInitFocus();

                    break;
                }
            // --- ADD 2008/09/04 --------------------------------<<<<< 
            
            // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            case "Renewal_ButtonTool":
                {
                    // --- ADD 2010/12/06 ------------------------------------>>>>>
                    // �����S�̐ݒ�����擾����
                    int status = this.GetBillAllSt();
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �����S�̐ݒ�����擾�Ɏ��s
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�����S�̐ݒ肪�擾�ł��܂���ł����B" + "\r\n" +
                            "�����S�̐ݒ��ݒ肵�Ă���N�����ĉ������B",
                            status,
                            MessageBoxButtons.OK);

                        this.Close();
                        return;
                    }
                    // --- ADD 2010/12/06 ------------------------------------<<<<<
                    // �ŐV���擾
                    this._inputForm.Renewal();
                    break;
                }
            // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            case "Guide_ButtonTool":         // �K�C�h�{�^��
                {
                    this._inputForm.ExecuteGuide();
                    break;
                }
            // --- ADD 2010/08/10 ------------------------------------<<<<< 
			}
		}

		/// <summary>
		/// �c�[���o�[�c�[���l�ύX�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "SectionCode_ComboBoxTool":			// ���_�R���{�{�b�N�X
				{
					// �Ǘ����_�R�[�h�W�J����
					this.MngSectionCodeBroadCast();

					break;
				}
			}
		}
		# endregion

		// ===================================================================================== //
		// �l�ύX�C�x���g
		// ===================================================================================== //
		# region Value Changed Event Method
		/// <summary>
		/// ���_�R���{�G�f�B�^�I���m��C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void SectionCode_TComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			// �Ǘ����_�R�[�h�W�J����
			this.MngSectionCodeBroadCast();
		}
		# endregion
	}
}

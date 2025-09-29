using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �݌Ɏd�����̓��C���t���[��
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɏd�����͂̊e�q��ʂ𐧌䂷�郁�C���t���[���ł��B</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.03.12</br>
	/// <br>Update Date: 2008/07/24 30414 �E �K�j</br>
    /// <br>           : Partsman�p�ɕύX</br>
    /// <br>Update Date: 2009/11/16 30434 �H�� �b�D</br>
    /// <br>           : 3���Ή��� �݌ɓo�^�@�\��ǉ�</br>
    /// <br>Update Note: 2009/12/16 ��r��</br>
    /// <br>               PM.NS-5</br>
    /// <br>               �݌Ɏd�����͂ŕW�����i�ƌ��P���̓��͐���̏C��</br>
    /// </remarks>
	public partial class MAZAI04350UA : Form
	{
		//----------------------------------------------------------------------------------------------------
		//  �R���X�g���N�^
		//----------------------------------------------------------------------------------------------------
		# region �R���X�g���N�^
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// �R���X�g���N�^
        ///// </summary>
        //public MAZAI04350UA()
        //{
        //    InitializeComponent();

        //    AdjustStockAcs.GetStockSectionCode += new AdjustStockAcs.GetStockSectionCodeEventHandler(this.GetStockSectionCode);
        //    MAZAI04360UA.GetSection += new MAZAI04360UA.GetSectionEventHandler(this.GetSection);
        //    AdjustStockAcs.GetDate += new AdjustStockAcs.GetDateEventHandler(this.GetDate);
        //    AdjustStockAcs.GetStockPointWay += new AdjustStockAcs.GetStockPointWayEventHandler(this.GetStockPointWayCD);
        //    AdjustStockAcs.GetFractionProcCd += new AdjustStockAcs.GetFractionProcCdEventHandler(this.GetFractionProcCd);
        //    MAZAI04360UA.GetStockPointWay += new MAZAI04360UA.GetStockPointWayCDEventHandler(this.GetStockPointWayCD);
        //    MAZAI04360UA.GetFractionProcCD += new MAZAI04360UA.GetFractionProcCdEventHandler(this.GetFractionProcCd);
        //    MAZAI04360UA.GetEmpList += new MAZAI04360UA.GetEmpListEventHandler(this.GetEmpList);
        //    MAZAI04360UA.GetEmployee += new MAZAI04360UA.GetEmployeeEventHandler(this.GetEmployee);
        //    AdjustStockAcs.GetSubttlPrice += new AdjustStockAcs.GetSubttlPriceEventHandler(this.GetSubttlPrice);
        //    AdjustStockAcs.GetBlGoodsName += new AdjustStockAcs.GetBlGoodsNameEventHandler(this.GetBlGoodsName);

        //    // ��ƃR�[�h�擾
        //    if (LoginInfoAcquisition.EnterpriseCode != null)
        //    {
        //        this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //    }

        //    this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();

        //    // �݌ɕ]�����@�擾
        //    StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
        //    StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();

        //    stockMngTtlStAcs.Read(out stockMngTtlSt, _enterpriseCode, 0);

        //    _stockPointWay = stockMngTtlSt.StockPointWay;

        //    MAZAI04360UA _mazai04360UA = MAZAI04360UA.GetInstance();
        //    MAZAI04360UA.ChangeToolbarSetting += new MAZAI04360UA.ChangeToolbarSettingEventHandler(ToolbarEnableChange);
        //    InitialProc();
        //}

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAZAI04350UA()
        {
            InitializeComponent();

            AdjustStockAcs.GetStockSectionCode += new AdjustStockAcs.GetStockSectionCodeEventHandler(this.GetStockSectionCode);
            AdjustStockAcs.GetDate += new AdjustStockAcs.GetDateEventHandler(this.GetDate);
            AdjustStockAcs.GetSubttlPrice += new AdjustStockAcs.GetSubttlPriceEventHandler(this.GetSubttlPrice);
            AdjustStockAcs.GetSlipNote += new AdjustStockAcs.GetSlipNoteEventHandler(this.GetSlipNote);
            MAZAI04360UA.ChangeToolbarSetting += new MAZAI04360UA.ChangeToolbarSettingEventHandler(ToolbarEnableChange);
            MAZAI04360UA.changeFocusFooter += new MAZAI04360UA.ChangeFocusFooterEventHandler(ChangeFocusFooter);
            // 2009.04.02 30413 ���� �ۑ��p�C�x���g�ǉ� >>>>>>START
            MAZAI04360UA.save += new MAZAI04360UA.SaveEventHandler(Save);
            // 2009.04.02 30413 ���� �ۑ��p�C�x���g�ǉ� <<<<<<END
            // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
            MAZAI04360UA.EnabledToInputStock += new MAZAI04360UA.OnEnabledToInputStock(EnabledToInputStock);
            // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

            MAZAI04360UA _mazai04360UA = MAZAI04360UA.GetInstance();

            this._adjustStockAcs = AdjustStockAcs.GetInstance();
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        # endregion

        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>�C��</summary>
            Revision = 10,
            /// <summary>�폜</summary>
            Delete = 11,
        }
		//----------------------------------------------------------------------------------------------------
		//  �v���C�x�C�g�����o
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�C�g�����o

        private AdjustStockAcs _adjustStockAcs = null;

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>��ƃR�[�h</summary>
		private string _enterpriseCode;
		/// <summary>�����_�R�[�h</summary>
		private string _ownSectionCode;
		/// <summary>���_�I�v�V�����L���t���O</summary>
		private bool _optSection = false;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>�\�����[�h</summary>
		private int _dispMode = 0;
		/// <summary>�^�u�`�F���W�C�x���g����t���O</summary>
		private bool _enableTabChange = false;
		/// <summary>�C�x���g����t���O</summary>
		private bool _cancelEventFlg = false;

        //private int _fractionProcCd; 
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private int _fractionProcCd = 0;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�݌ɕ]�����@</summary>
        private int _stockPointWay;
        //private MAZAI04360UA _mazai04360UA;

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>�艿�����X�V�敪</summary>
        private int _priceCostUpdtDiv;
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		/// <summary>�q��ʐ���N���X</summary>
		private FormControlInfo _formControlInfo;

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>�ۑ������</summary>
		private SFCMN00299CA _WaitingDialog;

        private IEmployeeDB _iEmployeeDB;
        public ArrayList _employeeList = new ArrayList();
        public string _employeeCd = "";
        public string _employeeNm = "";
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        // ��ʃf�U�C���ύX�N���X
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //private BLGoodsCdAcs _blGoodsCdAcs;
        //private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g

        private bool _saveFlg;

		# endregion

		//----------------------------------------------------------------------------------------------------
		//  �萔�錾
		//----------------------------------------------------------------------------------------------------
		# region �萔�錾
		/// <summary>�擪�^�uKEY����</summary>
		private const string NO0_TOP_TAB = "TOP_TAB";
		/// <summary>�^�u�Ȃ�</summary>
		private const string NO_TAB = "";

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>���i�d������</summary>
		private const int ctInputPartsStock = 1;
		/// <summary>�ԗ��d������</summary>
		private const int ctInputCarStock = 2;
		/// <summary>�O����������</summary>
		private const int ctInputOutsourcing = 3;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>PGID</summary>
		private const string ctPGID = "MAZAI04350U";
		# endregion

        // ���쌠���̐���I�u�W�F�N�g�ۗ̕L
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAZAI04350U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// ���_�擾
        /// </summary>
        /// <returns>���_�R�[�h</returns>
        public string GetStockSectionCode()
        {
            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            //Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            //return (string)cmbOwnSection.Value;
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            return mazai04360UA.GetStockSectionCode();
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �쐬���擾
        /// </summary>
        /// <returns>�쐬��</returns>
        public DateTime GetDate()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            return mazai04360UA.GetDate();
        }

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        public int GetFractionProcCd()
        {
            return _fractionProcCd;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// �݌ɕ]�����@�擾
        /// </summary>
        /// <returns>�݌ɕ]�����@</returns>
        public int GetStockPointWayCD()
        {
            return _stockPointWay;
        }

        /// <summary>
        /// �d�����z�v�擾
        /// </summary>
        /// <returns>�d�����z�v</returns>
        public Int64 GetSubttlPrice()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            return mazai04360UA.GetSubttlPrice();
        }

        /// <summary>
        /// �`�[���l�擾����
        /// </summary>
        /// <returns>�`�[���l</returns>
        public string GetSlipNote()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            return mazai04360UA.GetSlipNote();
        }

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        public ArrayList GetEmpList()
        {
            return _employeeList;
        }
        public string GetEmployee()
        {
            return _employeeCd;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // �`�[�폜�{�^��
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Visible = false;
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Shortcut = Shortcut.None;
            }
        }

        //----------------------------------------------------------------------------------------------------
		//  �R���g���[���C�x���g�n���h��
		//----------------------------------------------------------------------------------------------------
		# region �R���g���[���C�x���g�n���h��
        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �t�H�[�����[�h�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������[�h���ꂽ���ɔ������܂�</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2009/12/16 ��r��</br>
        /// <br>             PM.NS-5</br>
        /// <br>             �݌Ɏd�����͂ŕW�����i�ƌ��P���̓��͐���̏C��</br>
        /// </remarks>
        private void MAZAI04350UA_Load(object sender, EventArgs e)
        {
            try
            {
                // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
                this._controlScreenSkin.LoadSkin();

                // ��ʃX�L���ύX
                this._controlScreenSkin.SettingScreenSkin(this);

                // �c�[���o�[�̐ݒ�
                SettingToolbar();

                // �c�[���o�[�̗L�������ݒ�
                ToolbarEnableChange(0);

                // �Z�L�����e�B�����ɂ�鐧��J�n(�c�[���o�[�{�^��)
                BeginControllingByOperationAuthority();
                
                // �݌ɕ]�����@�擾
                GetStockPointWay();

                // �艿�����X�V�敪�擾
                GetPriceCostUpdtDiv();

                // �t�H�[������e�[�u���𐶐�����
                FormControlInfoCreate("");

                // �擪�^�u����
                TabCreate(NO0_TOP_TAB);

                // �擪�^�u�A�N�e�B�u��
                TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);

                // ��ʂɕ\���������e�������l�ɂ���
                StoreTabChild();

                // �^�u�`�F���W�C�x���gON
                this._enableTabChange = true;

                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
                // TSP�o�[�R�[�h�I�v�V�������擾
                PurchaseStatus purchaseStatus =
                    LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeTspInput);
                
                // ���_�񎞂̓{�^���͔�\���Ƃ���
                if ((purchaseStatus == PurchaseStatus.Contract) ||
                    (purchaseStatus == PurchaseStatus.Trial_Contract))
                {
                    // �o�[�R�[�h�ǎ�@�\��ON
                    tBarcodeReader1.Monitoring = true;
                }
                else
                {
                    // �o�[�R�[�h�ǎ�@�\��OFF�ɂ���
                    tBarcodeReader1.Monitoring = false;
                }
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
          
                // --- ADD 2009/12/16 ---------->>>>>
                // �艿���͋敪�擾
                GetListPriceInpDiv();

                // �P�����͋敪�擾
                GetUnitPriceInpDiv();
                // --- ADD 2009/12/16 ----------<<<<<
            }
            finally
            {
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �t�H�[�����[�h�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������[�h���ꂽ���ɔ������܂�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void MAZAI04350UA_Load(object sender, EventArgs e)
		{
			try
            {
                // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
                this._controlScreenSkin.LoadSkin();

                // ��ʃX�L���ύX
                this._controlScreenSkin.SettingScreenSkin(this);

                // ���_���̎擾
				SecInfoSet secInfoSet;
				SecInfoAcs secInfoAcs = new SecInfoAcs();

				// ���Џ��擾
				secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

				// ���_�R���{�{�b�N�X�ɋ��_���X�g��ݒ肷��
				Infragistics.Win.ValueList secInfoList = new Infragistics.Win.ValueList();
				foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
					secInfoItem.DataValue = secInfoSetWk.SectionCode;
					secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
					secInfoList.ValueListItems.Add(secInfoItem);
				}
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"]).ValueList = secInfoList;

				// �{�Ћ@�\����or���_�I�v�V���������Ȃ狒�_��ύX�ł��Ȃ��悤�ɂ���
				this._optSection = !((secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) || (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0));
				this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
                
                // �c�[���o�[�̐ݒ�
				this.SettingToolbar();

				// �c�[���o�[�̗L�������ݒ�
				this.ToolbarEnableChange(0);
                // 
                //this._adjustStockAcs = new AdjustStockAcs();
                this._adjustStockAcs = AdjustStockAcs.GetInstance();

				// �d���Ǘ��A�N�Z�X�N���X��������
				string sectionCode = "";
				Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"];
				if (cmbOwnSection.Value is string)
				{
					sectionCode = (string)cmbOwnSection.Value;
				}

				// �����_����ݒ肷��
				cmbOwnSection.Value = secInfoSet.SectionCode;
				this._ownSectionCode = secInfoSet.SectionCode;

				// �\�����[�h�����ݒ�
				this.SettingDispMode((int)ChildFormDispMode.Normal);
                
                // �t�H�[������e�[�u���𐶐�����
				this.FormControlInfoCreate("");

				// �擪�^�u����
				this.TabCreate(NO0_TOP_TAB);

				// �擪�^�u�A�N�e�B�u��
				this.TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);

				// ��ʂɕ\���������e�������l�ɂ���
				this.StoreTabChild();

				// �^�u�`�F���W�C�x���gON
				this._enableTabChange = true;

				// TSP�o�[�R�[�h�I�v�V�������擾
				PurchaseStatus purchaseStatus =
					LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeTspInput);
				// ���_�񎞂̓{�^���͔�\���Ƃ���
				if ((purchaseStatus == PurchaseStatus.Contract) ||
					(purchaseStatus == PurchaseStatus.Trial_Contract))
				{
					// �o�[�R�[�h�ǎ�@�\��ON
					tBarcodeReader1.Monitoring = true;
				}
				else
				{
					// �o�[�R�[�h�ǎ�@�\��OFF�ɂ���
					tBarcodeReader1.Monitoring = false;
				}
			}
			finally
			{
			}
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �t�H�[��Close�O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�����I������O�ɔ������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void MAZAI04350UA_FormClosing(object sender, FormClosingEventArgs e)
		{

		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// �I������
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <param name="sender"></param>
        private void Close(bool isConfirm,object sender)
        {
            if ((isConfirm) && (this._adjustStockAcs.IsDataChanged))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                    //this.Save(true, sender);
                    MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
                    mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

                    // �`�[�C����
                    if (mazai04360UA.GetEnabledSupplierSlipNo() == false)
                    {
                        if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  ctPGID,
                                  "�Z�L�����e�B�ɂ��`�[�C������������Ă��܂��B",
                                  0,
                                  MessageBoxButtons.OK);
                            return;
                        }
                    }
                    this.Save();
                    // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }


		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
        /// <br>Update Note: 2009/12/16 ��r��</br>
        /// <br>               PM.NS-5</br>
        /// <br>               �݌Ɏd�����͂ŕW�����i�ƌ��P���̓��͐���̏C��</br>
        /// </remarks>
		private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
		{
			if (this._cancelEventFlg) return;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();

			switch (e.Tool.Key)
			{
				case "ButtonTool_Close":
					//--------------------------------------------------------------
					// �I���{�^��
					//--------------------------------------------------------------
					// ���C����ʂ̃N���[�Y
					this.Close(true,sender);
					break;
				case "ButtonTool_Save":

					//--------------------------------------------------------------
					// �ۑ��{�^��
					//--------------------------------------------------------------
                    // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                    //Save(true, sender);

                    mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

                    if (ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Caption == "�m��(F10)")
                    {
                        if (mazai04360UA.ActiveControl.Parent == mazai04360UA.StockGrid)
                        {
                            mazai04360UA.edtNote1.Focus();
                            ChangeFocusFooter(true);
                        }
                        else
                        {
                            mazai04360UA.StockGrid.Focus();
                        }
                        return;
                    }

                    // �`�[�C����
                    if (mazai04360UA.GetEnabledSupplierSlipNo() == false)
                    {
                        if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  ctPGID,
                                  "�Z�L�����e�B�ɂ��`�[�C������������Ă��܂��B",
                                  0,
                                  MessageBoxButtons.OK);
                            return;
                        }
                    }

                    DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                    ctPGID,
                                                    "�o�^���Ă���낵���ł����H",
                                                    0,
                                                    MessageBoxButtons.YesNo);

                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    Save();
                    // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
                    this._adjustStockAcs.IsDataChanged = false;
					break;
				case "ButtonTool_New":
					//--------------------------------------------------------------
					// �V�K�{�^��
					//--------------------------------------------------------------
					// �V�K����
					this.NewEditTabChild(true);
                    this._adjustStockAcs.IsDataChanged = false;
					break;
                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
				case "ButtonTool_Undo":
					//--------------------------------------------------------------
					// ���ɖ߂��{�^��
					//--------------------------------------------------------------
					// ���A����
					this.RetryEditTabChild();
					break;
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
                case "ButtonTool_Delete":
					//--------------------------------------------------------------
					// �폜�{�^��
					//--------------------------------------------------------------
					// �폜����
					this.DeleteEditTabChild();
					break;
                // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
                case "ButtonTool_Load":
                    //--------------------------------------------------------------
                    // �`�[�ďo�{�^��
                    //--------------------------------------------------------------
                    // �`�[�ďo����
                    LoadSlip();
                    break;
                case "ButtonTool_OrderAddUp":
                    //--------------------------------------------------------------
                    // �����v��{�^��
                    //--------------------------------------------------------------
                    // �����v�㏈��
                    AddUpOrder();
                    break;
                case "ButtonTool_Setup":
                    //--------------------------------------------------------------
                    // �ݒ�{�^��
                    //--------------------------------------------------------------
                    // �ݒ菈��
                    SetUp();
                    break;
                // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
                case "ButtonTool_Renewal":
                    {
                        mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
                        mazai04360UA.Renewal();
                        // --- ADD 2009/12/16 ---------->>>>>
                        // �艿���͋敪�̍Ď擾
                        GetListPriceInpDiv();
                        // �P�����͋敪�̍Ď擾
                        GetUnitPriceInpDiv();
                        // --- ADD 2009/12/16 -----------<<<<<
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�ŐV�����擾���܂����B",
                                      0,
                                      MessageBoxButtons.OK);
                        break;
                    }
                // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                case "ButtonTool_InputStock":
                    {
                        InputStock();
                        break;
                    }
                // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<
			}
		}

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^�̓o�^���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void Save()
        {
			this._cancelEventFlg = true;
                                
            string retMessage;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            // ���̓`�F�b�N
            bool bStatus = mazai04360UA.CheckInputData(out retMessage);
            if (!bStatus)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              ctPGID,
                              retMessage,
                              0,
                              MessageBoxButtons.OK);

                ChangeFocusFooter(false);
                this._cancelEventFlg = false;

                return;
            }

            bool priceUpdateFlg;

            // �艿�����X�V�敪�`�F�b�N
            switch (this._priceCostUpdtDiv)
            {
                case 0:
                    // ��X�V
                    priceUpdateFlg = false;
                    break;
                case 1:
                    // �������X�V
                    priceUpdateFlg = true;
                    break;
                case 2:
                    // �m�F�X�V
                    DialogResult result = TMsgDisp.Show(this,
                                                        emErrorLevel.ERR_LEVEL_QUESTION,
                                                        this.Name,
                                                        "���i�E�������X�V���܂����H",
                                                        0,
                                                        MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        priceUpdateFlg = true;
                    }
                    else if (result == DialogResult.No)
                    {
                        priceUpdateFlg = false;
                    }
                    else
                    {
                        mazai04360UA.SetDefaultFocus();
                        this._cancelEventFlg = false;
                        return;
                    }
                    break;
                default:
                    priceUpdateFlg = false;
                    break;
            }

            // �����c�����C���t���O
            bool orderListResultFlg = mazai04360UA.GetOrderListResultFlg();

            // �o�^����
            bool isNew;
            int stockAdjustSlipNo;
            int status = _adjustStockAcs.SaveDBData(out stockAdjustSlipNo, out retMessage, out isNew, priceUpdateFlg, orderListResultFlg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (!isNew)
                        {
                            // ���O�o��
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Revision",
                                    (int)OperationCode.Revision,
                                    0,
                                    string.Format("{0}�`�[�A�`�[�ԍ�:{1}���C��", "�݌Ɏd��", stockAdjustSlipNo.ToString("000000000")));
                            }
                        }

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        this._saveFlg = true;

                        this.NewEditTabChild(true);
                        this._adjustStockAcs.IsDataChanged = false;

                        mazai04360UA.SetStockAdjustSlipNo(stockAdjustSlipNo);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "���݁A�ҏW���̍݌Ƀf�[�^�͊��ɍ폜����Ă��܂��B" + "\r\n" + "\r\n" +
                                      "�݌ɏ����ēx�擾���Ȃ����Ă�������",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "���݁A�ҏW���̍݌Ƀf�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
                                      "�݌ɏ����ēx�擾���Ȃ����Ă�������",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                // ��ƃ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n" + 
                                      "�����X�V���A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                      "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // ���_���b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n" +
                                      "���X�V���A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B�B" + "\r\n" +
                                      "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // �q�Ƀ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n" +
                                      "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                      "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOP,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      retMessage,
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
            }

			this._cancelEventFlg = false;
        }

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private void Save(bool isShowSaveCompletionDialog, object sender)
        {
            this._cancelEventFlg = true;

            string retMessage;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();

            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            int mode = mazai04360UA.ModetCmbEditor.SelectedIndex;

            string slipnote = mazai04360UA.GetSlipNote();

            //�o�^
            int status = mazai04360UA.CheckInputData(sender);
            if (status != 0)
            {
                if (status == -1)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ctPGID,
                        "���i��1�����o�^����Ă��܂���B",
                        0,
                        MessageBoxButtons.OK);
                    this._cancelEventFlg = false;
                    return;
                }
                else if (status == -2)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ctPGID,
                        "�������̓��͂��Ȃ��s������܂��B",
                        0,
                        MessageBoxButtons.OK);
                    this._cancelEventFlg = false;
                    return;
                }
                else if (status == -3)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ctPGID,
                        "���͒S�������͂���Ă��܂���B",
                        0,
                        MessageBoxButtons.OK);
                    this._cancelEventFlg = false;
                    return;
                }
            }

            status = _adjustStockAcs.SaveDBData(out retMessage, mode, slipnote, GetDate());
            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                //GRID������
                _adjustStockAcs.DBDataClear();
                _adjustStockAcs.StockDataClear();

                AdjustStockAcs.RepaintProductStock();
                mazai04360UA.SetSlipNote("");
                mazai04360UA.SetDefaultFocus();
                mazai04360UA.ClrDsp(false);
            }
            else
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// �r���i�ʒ[���X�V�ρj
                {

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���݁A�ҏW���̍݌Ƀf�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
                        "�݌ɏ����ēx�擾���Ȃ����Ă�������",
                        -1,
                        MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("�X�V�Ɏ��s���܂����B" + "(" + status.ToString() + ")");
                }
            }
            this._cancelEventFlg = false;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        /// <summary>
		/// �I���^�u�`�F���W��C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void TabControl_Main_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
		{
			if (!this._enableTabChange) return;

			// �q��ʂ̃A�N�e�B�u����
			this.TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);
		}

		/// <summary>
		/// �I���^�u�`�F���W�O�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void TabControl_Main_SelectedTabChanging(object sender, SelectedTabChangingEventArgs e)
		{
			if (!this._enableTabChange) return;

			if (this.TabControl_Main.SelectedTab == null || this.TabControl_Main.SelectedTab.Key == null) return;

			// �q��ʂ̔�A�N�e�B�u����
			if (this.TabDeactivattingProc(this.TabControl_Main.SelectedTab.Tag as Form) != 0)
			{
				e.Cancel = true;
			}
        }

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �c�[���o�[�l�ύX���C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolbarsManager_Main_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "ComboBoxTool_Section":
					//--------------------------------------------------------------
					// ���͋��_��ύX����
					//--------------------------------------------------------------
					Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
					if (cmbOwnSection.Value is string)
					{

						// �I���������_�R�[�h���擾����
						string sectionCode = (string)cmbOwnSection.Value;			// ���_�R�[�h

					}
					break;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        /// <summary>
		/// �o�[�R�[�h�ǂݎ��C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tBarcodeReader1_BarcodeReaded(object sender, BarcodeReadedEventArgs e)
		{
			int st;

			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IStockEntryTbsCtrlChildResponse)
				{
					// �q��ʃA�N�V�����ʒm����
					st = ((IStockEntryTbsCtrlChildResponse)_formControlInfo.Form).ChildResponse(this, _formControlInfo.Form, "BarcodeRead", e.BarcodeString);
				}
			}
		}
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  �v���C�x�[�g���\�b�h
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�[�g���\�b�h
        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �V�K�쐬����
		/// </summary>
		/// <param name="comparer">�ҏW���`�F�b�N�L��</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �V�K�{�^���������ꂽ���ɔ������āA�S�f�[�^�����������܂��B</br>
		/// <br>Programer  : 30414 �E �K�j</br>
		/// <br>Date       : 2008/07/24</br>
		/// </remarks>
		private int NewEditTabChild(bool comparer)
		{
			// �^�u�q��ʂ��W�J����Ă��Ȃ���exit
			if (this.TabControl_Main.Tabs.Count <= 0) return -1;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            if (!this._saveFlg)
            {
                if (!mazai04360UA.CompareScreen())
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                        "������Ԃɖ߂��܂����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2);

                    if (dialogResult != DialogResult.Yes)
                    {
                        return -1;
                    }
                }
            }

			if (comparer)
			{
				// �q��ʂɑ΂��ĕۑ��������s��
				this.StoreTabChild();
			}

			// ���݂̃J�[�\����ޔ�����
			Cursor bufCursor = this.Cursor;
			try
			{
				// �J�[�\�����wWait�x�ɂ���
				this.Cursor = Cursors.WaitCursor;

				// �q��ʂɑ΂��čĕ\�������s������
				this.ShowTabChild();

				//��������������������������������������������������������������������������
				// ��ʌn�̏��������s��
				//��������������������������������������������������������������������������
				try
				{
                    // �c�[���o�[����
					this.ToolbarEnableChange(0);
				}
				finally
				{
					// ��ʂɕ\���������e�������l�ɂ���
					this.StoreTabChild();
				}
			}
			finally // �}�E�X�J�[�\���ɑ΂���finally
			{
				// �}�E�X�J�[�\�������ɖ߂�
				this.Cursor = bufCursor;
			}
            //GRID������
            _adjustStockAcs.DBDataClear();

            mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.ClrDsp(true);
            mazai04360UA.SetDefaultFocus();

            AdjustStockAcs.RepaintProductStock();

			return 0;
		}
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �V�K�쐬����
        /// </summary>
        /// <param name="comparer">�ҏW���`�F�b�N�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���������ꂽ���ɔ������āA�S�f�[�^�����������܂��B</br>
        /// <br>Programer  : 19077 �n糋M�T</br>
        /// <br>Date       : 2007.03.12</br>
        /// </remarks>
        private int NewEditTabChild(bool comparer)
        {
            // �^�u�q��ʂ��W�J����Ă��Ȃ���exit
            if (this.TabControl_Main.Tabs.Count <= 0) return -1;

            if (comparer)
            {
                // �q��ʂɑ΂��ĕۑ��������s��
                this.StoreTabChild();

                //// �ҏW��ʂɕω��������Ă��邩�H
                //if (this._stockMngAcs.CompareStaticMemory(this) != 0)
                //{
                //    // �ύX����ׁ̈A�ۑ��m�F�̃_�C�A���O��\������	
                //    DialogResult retResult = TMsgDisp.Show(
                //        emErrorLevel.ERR_LEVEL_QUESTION,
                //        ctPGID,
                //        "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H",
                //        0,
                //        MessageBoxButtons.YesNoCancel);

                //    switch (retResult)
                //    {
                //        case DialogResult.Yes:
                //            // �͂�
                //            if (this.SaveEditTabChild() != 0) return -1;
                //            break;
                //        case DialogResult.No:
                //            // ������
                //            break;
                //        case DialogResult.Cancel:
                //            // �L�����Z��
                //            return -1;
                //    }
                //}
            }

            // ���݂̃J�[�\����ޔ�����
            Cursor bufCursor = this.Cursor;
            try
            {
                // �J�[�\�����wWait�x�ɂ���
                this.Cursor = Cursors.WaitCursor;

				// �\�����[�h������
				this.SettingDispMode((int)ChildFormDispMode.Normal);

                //��������������������������������������������������������������������������
                // �֘A����A�N�Z�X�N���X������������
                //��������������������������������������������������������������������������
                // �d���Ǘ��A�N�Z�X�N���X������
                // this._stockMngAcs.InitStaticMemory(0, this._enterpriseCode, this._ownSectionCode, 1, (int)ConstantManagement_SF_SIR.SupplierSlipKind.PartsSuplSlip);

                // �q��ʂɑ΂��čĕ\�������s������
                this.ShowTabChild();

                //��������������������������������������������������������������������������
                // ��ʌn�̏��������s��
                //��������������������������������������������������������������������������
                try
                {

                    // ���_���\��
                    //					this.ShowToolBarSection();

					// �d����̃c�[���o�[��ݒ肷��
					this.ShowToolbarSupplier();

                    // �c�[���o�[����
                    this.ToolbarEnableChange(0);
                }
                finally
                {
                    // ��ʂɕ\���������e�������l�ɂ���
                    this.StoreTabChild();
                    // this._stockMngAcs.CopyStaticMemory(this, 0);	// 0:Main��Undo
                }
            }
			finally // �}�E�X�J�[�\���ɑ΂���finally
            {
                // �}�E�X�J�[�\�������ɖ߂�
                this.Cursor = bufCursor;
            }
            //GRID������
            _adjustStockAcs.DBDataClear();

            _adjustStockAcs.StockDataClear();

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.ClrDsp(true);
            AdjustStockAcs.RepaintProductStock();

            return 0;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�̕ۑ��������s���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int SaveEditTabChild()
		{
			if (_formControlInfo.Form != null)
			{
				int st = 0;


				// �q��ʓ��̓`�F�b�N
				if (this.CheckEditTabChild() != 0) return 1;

				// �ҏW��ʂ̃f�[�^��Static�ȗ̈�ɕۑ�����
				this.StoreTabChild();

				// ���݂̃J�[�\����ޔ�����
				Cursor localCursor = this.Cursor;
				//string retMsg = "", retItemInfo;
                string retMsg = "";

				try
				{
					// �J�[�\�����wWait�x�ɂ���
					this.Cursor = Cursors.WaitCursor;
					// ��ʂ̍ĕ`��
					Refresh();

					this._WaitingDialog = new SFCMN00299CA();
					this._WaitingDialog.Title = "�ۑ���";							// ��ʂ̃^�C�g���o�[�ɕ\�����镶����
					this._WaitingDialog.Message = "�`�[�f�[�^�̕ۑ����ł��D�D�D";	// ��ʂ̃v���O���X�o�[�̏�ɕ\�����镶����
					this._WaitingDialog.Show(this);

					// Static�ȃf�[�^��DB�ɏ�������
//*					st = this._stockMngAcs.WriteDBData(this, out retMsg, out retItemInfo, false);
				}
				finally
				{
					// �o�^����ʂ̔�\��
					this._WaitingDialog.Close();

					// �J�[�\�������ɖ߂�
					this.Cursor = localCursor;
				}

				switch (st)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

						// �`�[�ԍ��\���p
						this.ShowToolbarSupplier();
#if true
                        // �ۑ��m�F�̃_�C�A���O��\������

						// ��ʃN���A
						this.NewEditTabChild(false);
#else
						// �q��ʂɑ΂��čĕ\�������s������
						this.ShowTabChild();

						// �ۑ��m�F�̃_�C�A���O��\������
						SaveCompletionDialog saveDialog = new SaveCompletionDialog();
						saveDialog.Owner = this;
						saveDialog.ShowDialog("RED", 2);

						// �c�[���o�[����
						this.ToolbarEnableChange(1);

						// ��ʂɕ\���������e�������l�ɂ���
						this._stockMngAcs.CopyStaticMemory(this, 0);	// 0:Main��Undo
#endif
					break;

					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE :
						// �d���Ǘ��̏������݂Ŏd����`�[�ԍ����d��
						retMsg = "���͂��ꂽ�d����`�[�ԍ��͊��ɓo�^�ς݂ł��B\n\n���̎d����`�[�ԍ���ݒ肵�Ă��������B";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, retMsg, st, MessageBoxButtons.OK);
						if ((_formControlInfo != null) && (_formControlInfo.Form is IStockEntryTbsCtrlChildResponse))
						{
							// �q��ʃA�N�V�����ʒm����(�d����`�[�ԍ��Ƀt�H�[�J�X�J��)
							((IStockEntryTbsCtrlChildResponse)_formControlInfo.Form).ChildResponse(this, _formControlInfo.Form, "SetFocus_SlipNo", null);
						}
						return st;

					case (int)ConstantManagement.DB_Status.ctDB_WARNING :
						// �d���Ǘ��̏����݂Œ��`�F�b�NNG
						// (���ς݂ɑ΂���X�V�`�F�b�N���ŏI�������ߋ��̎d�����t�`�F�b�N)
						// �d����t���O�`�F�b�NNG
						// (���Ӑ���ɕ��i�d���̎�ʂ�ON�ɂȂ��Ă��Ȃ�)
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;

					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE :
						// ���ɍX�V����Ă���
						retMsg = "�ҏW���̎d���`�[�́A���ɑ��̒[���ōX�V����Ă��܂��B\n\n�ēx�A���̎d���`�[���Ăяo���ĕҏW���Ă��������B";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;

					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
						// ���ɍ폜����Ă���
						retMsg = "�ҏW���̎d���`�[�́A���ɑ��̒[���ō폜����Ă��܂��B";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;

					default:
						// �d���Ǘ��̏������݂ŃG���[������
						retMsg = "�d���`�[�̏������݂ŃG���[���������܂����B\n\n" + retMsg;
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;
				}
			}

			return 0;
        }

		/// <summary>
		/// ���ɖ߂�����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����\���̃f�[�^�ɖ߂��܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int RetryEditTabChild()
		{
			// �q��ʂ̌��݂̏���ۑ�������
			this.StoreTabChild();
			return 0;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �`�[�ďo����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�K�C�h��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private int LoadSlip()
        {
            // ��ʏ��擾
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            // �݌Ɏd���`�[�Ɖ��ʋN��
            mazai04360UA.ShowStockSlipGuide();

            return 0;
        }

        /// <summary>
        /// �����v�㏈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����v���ʂ�\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private int AddUpOrder()
        {
            // ��ʏ��擾
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            // �����c�Ɖ��ʋN��
            mazai04360UA.ShowOrderHisGuide();
            ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = false;
            return 0;
        }

        /// <summary>
        /// ���[�U�[�ݒ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ��ʂ�\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SetUp()
        {
            ArrayList userSettingList;

            // ��ʏ��擾
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.GetUserSetting(out userSettingList);

            MAZAI04350UC mazai04350UC = new MAZAI04350UC(userSettingList);
            DialogResult res = mazai04350UC.ShowDialog();
            if (res == DialogResult.OK)
            {
                // ���[�U�[�ݒ��񔽉f
                userSettingList = mazai04350UC.UserSettingList;
                mazai04360UA.SetUserSetting(userSettingList);
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�̕ۑ��������s���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int DeleteEditTabChild()
		{
			DialogResult Dresult = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_QUESTION,
				ctPGID,
				"�I�𒆂̎d���`�[���폜���܂��B\n\n��낵���ł����H",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			if (Dresult == DialogResult.Yes)
			{
                MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
                mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

                DateTime targetDate;
                if (!mazai04360UA.CheckHisTotalDayMonthly(mazai04360UA.GetStockSectionCode(), mazai04360UA.GetDate(), out targetDate))
                {
                    string errMsg = "�d�������O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�폜�ł��܂���B" + "\r\n\r\n" + "  �O�񌎎��X�V���F" + targetDate.ToString("yyyy�NMM��dd��");
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  0,
                                  MessageBoxButtons.OK);
                    return (0);
                }

                int st = 0; //*
                // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
                int slipNo;
                st = this._adjustStockAcs.DeleteDBData(out slipNo);
                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // ���O�o��
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Delete))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Delete",
                                    (int)OperationCode.Delete,
                                    0,
                                    string.Format("{0}�`�[�A�`�[�ԍ�:{1}���폜", "�݌Ɏd��", slipNo.ToString("000000000")));
                            }

                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "�݌Ɏd���`�[���폜���܂����B",
                                          0,
                                          MessageBoxButtons.OK);

                            this.NewEditTabChild(true);
                            this._adjustStockAcs.IsDataChanged = false;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "���݁A�ҏW���̍݌Ƀf�[�^�͊��ɍ폜����Ă��܂��B" + "\r\n" + "\r\n" +
                                          "�݌ɏ����ēx�擾���Ȃ����Ă�������",
                                          st,
                                          MessageBoxButtons.OK);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "���݁A�ҏW���̍݌Ƀf�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
                                          "�݌ɏ����ēx�擾���Ȃ����Ă�������",
                                          st,
                                          MessageBoxButtons.OK);
                            break;
                        }
                    // ��ƃ��b�N�^�C���A�E�g
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "MAZAI04350U",
                                          "DeleteEditTabChild",
                                          TMsgDisp.OPE_DELETE,
                                          "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n" +
                                          "�����X�V���A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                          "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                          st,
                                          this._adjustStockAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            break;
                        }
                    // ���_���b�N�^�C���A�E�g
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "MAZAI04350U",
                                          "DeleteEditTabChild",
                                          TMsgDisp.OPE_DELETE,
                                          "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n" +
                                          "���X�V���A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B�B" + "\r\n" +
                                          "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                          st,
                                          this._adjustStockAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            break;
                        }
                    // �q�Ƀ��b�N�^�C���A�E�g
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "MAZAI04350U",
                                          "DeleteEditTabChild",
                                          TMsgDisp.OPE_DELETE,
                                          "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n" +
                                          "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                          "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                          st,
                                          this._adjustStockAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOP,
                                      this.Name,
                                      "MAZAI04350U",
                                      "DeleteEditTabChild",
                                      TMsgDisp.OPE_DELETE,
                                      "�폜�Ɏ��s���܂����B" + "(" + st.ToString() + ")",
                                      st,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
                // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
                return st;
			}

			return 0;
        }

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �d������擾�E�X�V����
		/// </summary>
		/// <param name="mode">�f�[�^�R�s�[���[�h[0:����, 1:���A���̂�]</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns></returns>
		private int ReadNewEntry(int mode, int customerCode)
		{
			if (customerCode == 0) return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��ŃR�����g�A�E�g

        /// <summary>
		/// �q��ʂ̕ۑ�����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �q��ʂɑ΂��āAStatic�ɕۑ������鏈�������s�����܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int StoreTabChild()
		{
			int st = -1;

			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IStockEntryTbsCtrlChildEdit)
				{
					// �X�^�e�B�b�N�ۑ�����
					st = ((IStockEntryTbsCtrlChildEdit)_formControlInfo.Form).SaveStaticMemoryData(this);
				}
			}

			return st;
		}

		/// <summary>
		/// �q��ʂ�Static����\��������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �q��ʂɑ΂��āAStatic�ɕێ�����Ă���f�[�^��\������悤�ɗv�����܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void ShowTabChild()
		{
			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IStockEntryTbsCtrlChild)
				{
					// �X�^�e�B�b�N�\������
					((IStockEntryTbsCtrlChild)_formControlInfo.Form).ShowStaticMemoryData(this, this._dispMode);
				}
			}
		}

		/// <summary>
		/// �q��ʁi�ҏW��ʁj�̓��̓`�F�b�N����
		/// </summary>
		/// <returns>0=���̓G���[����,1=���̓G���[�L��</returns>
		/// <remarks>
		/// <br>Note       : MDI�t�H�[��(�ҏW��ʁj�̓��̓`�F�b�N����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int CheckEditTabChild()
		{
			if (_formControlInfo != null)
			{
				// ��ʂɑ΂��ē��͓��e�̃`�F�b�N���s��
				if (_formControlInfo.Form is IStockEntryTbsCtrlChildCheck)
				{
					if (((IStockEntryTbsCtrlChildCheck)_formControlInfo.Form).CheckInputData(this) != 0)
						return 1;
				}                
			}

			return 0;
		}

		/// <summary>
		/// �^�u�A�N�e�B�u����
		/// </summary>
		/// <param name="form"></param>
		private void TabActivatedProc(Form form)
		{
			if (form != null)
			{
				if (this._formControlInfo == null) return;

				// �q��ʂɃA�N�e�B�u�C�x���g��ʒm����
				if (form is IStockEntryTbsCtrlChildEvent)
				{
					((IStockEntryTbsCtrlChildEvent)form).EntryTabChildFormActivated(this, EventArgs.Empty);
				}

				// �q��ʂ̕`���������
				this.RefreshTabChild(form);
			}
		}

		/// <summary>
		/// �^�u��A�N�e�B�u����
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		private int TabDeactivattingProc(Form form)
		{
			if (form != null)
			{
				// �q��ʂɔ�A�N�e�B�u�C�x���g��ʒm����
				if (form is IStockEntryTbsCtrlChildEvent)
				{
					((IStockEntryTbsCtrlChildEvent)form).EntryTabChildFormDeactivate(this, EventArgs.Empty);
				}
			}

			return 0;
		}

		/// <summary>
		/// MDI�q��ʂ̍ĕ`��w���istatic�ȗ̈悩��f�[�^���擾���ĕ\���j
		/// </summary>
		/// <param name="form">MDI�q���(�ҏW���)</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI�q��ʂ̍ĕ`��w���istatic�ȗ̈悩��f�[�^���擾���ĕ\���j</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void RefreshTabChild(Form form)
		{
			if (form != null)
			{
				// IStockEntryTbsCtrlChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
				if ((form is IStockEntryTbsCtrlChild))
				{
					((IStockEntryTbsCtrlChild)form).ShowStaticMemoryData(this, this._dispMode);
				}
			}
		}

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɕ]�����@�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����݌ɕ]�����@���擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GetStockPointWay()
        {
            int status;
            StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
            ArrayList retList;

            try
            {
                status = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockMngTtlSt stockMngTtlSt in retList)
                    {
                        if (stockMngTtlSt.SectionCode.Trim() == "00")
                        {
                            this._stockPointWay = stockMngTtlSt.StockPointWay;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// �艿�����X�V�敪�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�}�X�^����艿�����X�V�敪���擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GetPriceCostUpdtDiv()
        {
            int status;
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
            ArrayList retList;

            try
            {
                status = stockTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockTtlSt stockTtlSt in retList)
                    {
                        if (stockTtlSt.SectionCode.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                        {
                            this._priceCostUpdtDiv = stockTtlSt.PriceCostUpdtDiv;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
        /// <summary>
        /// �݌ɂ���͂��܂��B
        /// </summary>
        private void InputStock()
        {
            MAZAI04360UA mainForm = (MAZAI04360UA)_formControlInfo.Form;
            mainForm.InputStock();
        }
        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<


        // --- ADD 2009/12/16 ---------->>>>>
        /// <summary>
        /// �艿���͋敪�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�}�X�^����艿���͋敪���擾���܂��B</br>
        /// <br>Programer  : ��r��</br>
        /// <br>Date       : 2009/12/16</br>
        /// </remarks>
        private void GetListPriceInpDiv()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.GetListPriceInpDiv();
        }

        /// <summary>
        /// �P�����͋敪�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�}�X�^����P�����͋敪���擾���܂��B</br>
        /// <br>Programer  : ��r��</br>
        /// <br>Date       : 2009/12/16</br>
        /// </remarks>
        private void GetUnitPriceInpDiv()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.GetUnitPriceInpDiv();
        }
        // --- ADD 2009/12/16 -----------<<<<<

		# endregion

		//----------------------------------------------------------------------------------------------------
		//  �v���C�x�[�g���\�b�h(�^�u�\�z�֘A)
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�[�g���\�b�h(�^�u�\�z�֘A)
		/// <summary>
		/// �t�H�[���R���g���[���N���X�N���G�C�g����
		/// </summary>
		/// <param name="NexViewFormname">���ɕ\������t�H�[��</param>
		/// <remarks>
		/// <br>Note       : �t���[�����N������t�H�[���N���X�e�[�u���𐶐����܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void FormControlInfoCreate(string NexViewFormname)
		{
			_formControlInfo = null;

			_formControlInfo = new FormControlInfo(
				NO0_TOP_TAB,
				"MAZAI04360U",
				"Broadleaf.Windows.Forms.MAZAI04360UA",
				"�݌Ɏd������",
				IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
				NO_TAB,
				NO_TAB);
		}

		/// <summary>
		/// �^�u�N���G�C�g����
		/// </summary>
		/// <param name="key">�^�u�Ǘ��L�[</param>
		/// <remarks>
		/// <br>Note       : �t���[���̃^�u���N���G�C�g���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			Cursor localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				switch (key)
				{
					case NO0_TOP_TAB:
						// �擪��ʐ���
						if (_formControlInfo == null) return;

						this.CreateTabChildForm(_formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
						break;
				}
			}
			finally
			{
				this.Cursor = localCursor;
			}
		}

		/// <summary>
		/// TAB�q��ʂ𐶐�����
		/// </summary>
		/// <param name="frmAssemblyName">�t�H�[���A�Z���u����</param>
		/// <param name="frmClassName">�t�H�[���N���X����</param>
		/// <param name="title">�\���^�C�g��</param>
		/// <param name="frmName">�t�H�[����</param>
		/// <param name="icon">�A�C�R���E�C���[�W</param>
		/// <param name="info">�t�H�[��������</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : TAB�q��ʂ𐶐�����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info)
		{
			Form form = null;
			form = (Form)this.LoadAssemblyFrom(frmAssemblyName, frmClassName, typeof(Form));

			if (form == null)
			{
//				ErrorForm ef = new ErrorForm();
//				form = (System.Windows.Forms.Form)ef;
			}
			else
			{
				// �t�H�[���v���p�e�B�ύX
				form.Name = frmName;

				// �^�u�y�[�W�R���g���[�����C���X�^���X
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = title;												// ����
				uTab.Key = frmName;												// Key
				uTab.Tag = form;												// �t�H�[���̃C���X�^���X
				uTab.Appearance.Image = icon;									// �A�C�R��
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
				uTab.ActiveAppearance.BackColor = Color.White;
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

				this.TabControl_Main.Controls.Add(uTabPageControl);
				this.TabControl_Main.Tabs.AddRange(new UltraTab[] { uTab });
				this.TabControl_Main.SelectedTab = uTab;

				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				// IStockEntryTbsCtrlChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
				if ((form is IStockEntryTbsCtrlChild))
				{
					// ���̂Ƃ���p�����[�^�͓��ɖ���
					((IStockEntryTbsCtrlChild)form).Show(null);
				}
				else
				{
					form.Show();
				}

				uTabPageControl.Controls.Add(form);
				form.Dock = DockStyle.Fill;
			}

			info.Form = form;
			return form;
		}

		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �A�Z���u�������[�h���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				Assembly asm = Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (FileNotFoundException ex)
			{
				// �ΏۃA�Z���u���Ȃ��i�x���j
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, ex.StackTrace, 0, MessageBoxButtons.OK);
			}
			catch (System.Exception ex)
			{
				// �ΏۃA�Z���u���Ȃ��i�x��)
				string _msg = "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, _msg, 0, MessageBoxButtons.OK);
			}
			return obj;
        }

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private void InitialProc()
        {
            // �S�]�ƈ������擾
            object returnEmployee;
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = _enterpriseCode;

            int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnEmployee is ArrayList)
                {                    
                    foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                    {
                        _employeeList.Add(employeeWork);
                    }
                }
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        # endregion


        //----------------------------------------------------------------------------------------------------
		//  �v���C�x�[�g���\�b�h(��ʐݒ�֘A)
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�[�g���\�b�h(��ʐݒ�֘A)

        #region DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �c�[���o�[�d�����\������
		/// </summary>
		private void ShowToolbarSupplier()
		{
		}

		/// <summary>
		/// ��ʕ\�����[�h�ݒ菈��
		/// </summary>
		/// <param name="dispMode">�\�����[�h</param>
		private void SettingDispMode(int dispMode)
		{
			this._dispMode = dispMode;

			switch (dispMode)
			{
				case (int)ChildFormDispMode.Normal:
				case (int)ChildFormDispMode.RefNormal:
//					this.DockManager_Main.Enabled = true;
					// ���_�ύX��
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
					break;
				case (int)ChildFormDispMode.ReadOnly:
//					this.DockManager_Main.Enabled = false;
					// ���_�ύX�s��
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
					break;
				case (int)ChildFormDispMode.RefNew:
//					this.DockManager_Main.Enabled = true;
					// ���_�ύX��
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
					break;
				case (int)ChildFormDispMode.RefRed:
//					this.DockManager_Main.Enabled = false;
					// ���_�ύX�s��
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
					break;
			}

			// �X�e�[�^�X�o�[�\��
			if (dispMode == (int)ChildFormDispMode.ReadOnly)
			{
				this.ultraStatusBar1.Panels["Text"].Text = "�ǂݎ���p";
			}
			else
			{
				this.ultraStatusBar1.Panels["Text"].Text = "";
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �c�[���o�[�̃A�C�R���ݒ�
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���̃c�[���o�[�̐ݒ���s���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void SettingToolbar()
		{
			//--------------------------------------------------------------
			// ���C���c�[���o�[
			//--------------------------------------------------------------
			// �C���[�W���X�g��ݒ肷��
			this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
			// ���_�̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["LabelTool_SectionTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
            // ���O�C���S���҂̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// �I���̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// �ۑ��̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// �V�K�̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            // �폜�̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // �`�[�ďo�̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            // �����v��̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_OrderAddUp"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // �ݒ�̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

            // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
            // �݌ɂ̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PACKAGEINPUT;
            // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

			// ���O�C����
			ToolBase LoginName = ToolbarsManager_Main.Tools["LabelTool_LoginName"];
			if (LoginName != null && LoginInfoAcquisition.Employee != null)
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				LoginName.SharedProps.Caption = employee.Name;

                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
                _employeeCd = employee.EmployeeCode;
                _employeeNm = employee.Name;                
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
            }

		}

        /// <summary>
        /// �c�[���o�[�L�������ύX����
        /// </summary>
        /// <param name="mode">���[�h[0:�����\��, 1:�X�V��]</param>
        private void ToolbarEnableChange(int mode)
        {
            switch (mode)
            {
                case 0:
                    // �폜�{�^������
                    ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                    ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_OrderAddUp"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = true;

                    // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                    // �݌Ƀ{�^���͔�݌ɕi����͎��̂ݗL��
                    ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.Enabled = false;
                    // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

                    break;
                case 1:
                    // �폜�{�^���L��
                    ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_OrderAddUp"].SharedProps.Enabled = false;
                    ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = false;

                    // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
                    // �݌Ƀ{�^���͔�݌ɕi����͎��̂ݗL��
                    ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.Enabled = false;
                    // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

                    break;
            }
        }

        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ---------->>>>>
        /// <summary>
        /// �݌ɓo�^�����L���i�����j�ɂ���C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void EnabledToInputStock(
            object sender,
            MAZAI04360UA.EnabledToInputStockEventArgs e
        )
        {
            ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.Enabled = e.Enabled;
        }
        // ADD 2009/11/16 3�����Ή� �݌ɓo�^�@�\��ǉ� ----------<<<<<

        private void ChangeFocusFooter(Boolean changeFlg)
        {
            if (changeFlg == true)
            {
                ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Caption = "�ۑ�(F10)";
            }
            else
            {
                ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Caption = "�m��(F10)";
            }
        }

        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^�����uVisible = False�v�ɂ���ƁA�C�x���g���������Ȃ����߁A
            // �T�C�Y���u1, 1�v�ɂ��A�����I�Ɍ����Ȃ��悤�ɂ���

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�I�����Ă���낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close(true, sender);
            }
        }

        #region DEL 2008/07/24 Partsman�p�ɕύX
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �c�[���o�[�L�������ύX����
		/// </summary>
		/// <param name="mode">���[�h[0:�����\��, 1:�ďo��, 2:�ǂݎ���p]</param>
		private void ToolbarEnableChange(int mode)
		{
			switch (mode)
			{
				case 0:
					// �ۑ��{�^���L��
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// �폜�{�^������
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
				case 1:
					// �ۑ��{�^���L��
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// �폜�{�^���L��
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
					break;
				case 2:
					// �ۑ��{�^������
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
					// �폜�{�^������
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman�p�ɕύX

        # endregion
    }
}
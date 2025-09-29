//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �I������
// �v���O�����T�v   : �I�����͏��i�ҏWUI��ʃN���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����@�m
// �� �� ��  2007/04/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/02/14  �C�����e : �I�����{���Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/09/01  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : ��Q�Ή�13109
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/14  �C�����e : �s��Ή�[13260]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �C �� ��  2009/10/08  �C�����e : MANTIS[0014384]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/03  �C�����e : PM.NS�@�ێ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/01/11  �C�����e : ���i�}�X�^�ɑ��݂��Ȃ��f�[�^���V�K�o�^�o����s��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/01/30  �C�����e : ��Q�� #18764
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/02/10  �C�����e : ��Q�� #18869
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2012/06/11  �C�����e : 2012/07/25�z�M���ARedmine#30238�̑Ή��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  1002677-00  �쐬�S�� : xuyb
// �C �� ��  2014/10/31  �C�����e : �d�|��2133 Redmine#40336
//                                  ��Q���ۇA�������C�����ĐV�K�쐬����ƒI���f�[�^�D�I���݌Ɋz��0�ɂȂ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinToolbars;
using System.Collections;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �I�����͏��i�ҏWUI��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Programer  : 23010 �����@�m</br>
    /// <br>Note       : ���i�̐V�K�ǉ��A�ҏW���s���N���X�ł�</br>
    /// <br>Date       : 2007/04/18</br>
    /// <br>Update Note: 2008.02.14 980035 ���� ��`</br>
    /// <br>			 �E�I�����{���Ή��iDC.NS�Ή��j</br>
    /// <br>Update Note: 2008/09/01 30414 �E �K�j</br>
    /// <br>			 �EPartsman�p�ɕύX</br>
    /// <br>Update Note: 2009/04/13 30452 ��� �r��</br>
    /// <br>			    �E��Q�Ή�13109</br>
    /// <br>           : 2009/05/14       �Ɠc �M�u�@�s��Ή�[13260]</br>
    /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
    /// <br>             �V�K���͎��̍��ڎ擾���@��ύX����</br>
    /// <br>UpdateNote : 2011/01/11 ���N�n��</br>
    /// <br>             ���i�}�X�^�ɑ��݂��Ȃ��f�[�^���V�K�o�^�o����s��C��</br>
    /// <br>UpdateNote : 2011/01/30 ���N�n��</br>
    /// <br>             ��Q�� #18764</br>
    /// <br>UpdateNote : 2011/02/10 ���N�n��</br>
    /// <br>             ��Q�� #18869</br>
    /// <br>UpdateNote : 2014/10/31 xuyb</br>
    /// <br>             Redmine#40336 ��Q���ۇA�������C�����ĐV�K�쐬����ƒI���f�[�^�D�I���݌Ɋz��0�ɂȂ�</br>
    /// </remarks>
    public partial class MAZAI05130UD : Form
    {
        #region Constructor
        /// <summary>
        /// �I�����͏��i�ҏW��ʃN���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Programer	: 23010 �����@�m</br>
        /// <br>Note		: �I�����͏��i�ҏW��ʃN���X�̃C���X�^���X�����������܂�</br>
        /// <br>Date		: 2007/04/18</br>
        /// <br>UpdateNote	: 2007.07.25 22013 kubo</br>
        /// <br>			:	�E�ҏW���[�h�ǉ�</br>
        /// <br>UpdateNote	: 2007.07.31 22013 kubo</br>
        /// <br>			:	�E�������^�C�~���O��ύX�B</br>
		/// <br>			:	  Load���Timer_Tick�C�x���g�ł�2��ڈȍ~�ɋN����������</br>
		/// <br>			:	  �O����e����u�\�������̂�Load�O�ɏ��������s���悤�ύX</br>
        /// <br>UpdateNote :  2011/01/11 ���N�n��</br>
        /// <br>              ���i�}�X�^�ɑ��݂��Ȃ��f�[�^���V�K�o�^�o����s��C��</br>
        /// </remarks>
        public MAZAI05130UD()
        {
            InitializeComponent();
            //�ϐ����C���X�^���X��
            //�I�������̓f�[�^�p�����[�^�N���X
            this._inventoryDataUpdateWorkBefore = new InventoryDataUpdateWork();
            this._inventoryDataUpdateWorkAfter  = new InventoryDataUpdateWork();
            
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            //���i�K�C�h
            this._goodsGuide = new MAKHN04110UA();

            //���Ӑ���A�N�Z�X�N���X
            this._customerInfoAcs = new CustomerInfoAcs();
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            //�q�ɃA�N�Z�X�N���X
            this._warehouseGuideAcs = new WarehouseAcs();

            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            this._goodsAcs = new GoodsAcs();
            string errMsg;
            this._goodsAcs.IsGetSupplier = true;        //ADD 2009/05/14 �s��Ή�[13260]      ���d����񌟍��̍�����
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out errMsg);

            this._inventInputAcs = new InventInputAcs();

            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>            
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ҃A�N�Z�X�N���X
            //this._carrierEpAcs = new CarrierEpAcs();
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //�q�ɃR�[�h�Q�Ɨp�t���O
            this._changFlagWarehouse = false;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ҃R�[�h�Q�Ɨp�t���O
            //this._changeFlagCarrierEp = false;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //�i�ԎQ�Ɨp�t���O
            this._changFlagGoods = false;

            //���Ӑ�(�d����)�R�[�h�Q�ƃt���O
            this._changFlagCustomer = false;
            //�o�א擾�Ӑ�(�ϑ���)�R�[�h�Q�ƃt���O
            this._changFlagShipCustomer = false;
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        }
        #endregion

        #region Const

        //�N�����[�h
        private const string ctNEW_MODE = "�V�K";
        private const string ctEDIT_MODE = "�X�V";
        private const string ctREADONLY_MODE = "�Q��";
        //�N���X��
        private string CT_CLASSID = "MAZAI05130UDA";

        #endregion

        #region PrivateMember

        //��ƃR�[�h
        private string _enterpriseCode;
        //���_�R�[�h
        private string _loginSectionCode;
        //�N�����[�h
        private int _dispMode;

        //�I�������̓f�[�^�p�����[�^�N���X
        private InventoryDataUpdateWork _inventoryDataUpdateWorkBefore;
        private InventoryDataUpdateWork _inventoryDataUpdateWorkAfter;

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        //���i�K�C�h
        private MAKHN04110UA _goodsGuide;
        //���Ӑ���A�N�Z�X�N���X
        private CustomerInfoAcs _customerInfoAcs;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        //�q�ɃA�N�Z�X�N���X
        private WarehouseAcs _warehouseGuideAcs;

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        private GoodsAcs _goodsAcs;
        private InventInputAcs _inventInputAcs;

        private List<InventoryDataUpdateWork> _inventoryDataUpdateWorkList;
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        //// ���Ǝ҃A�N�Z�X�N���X
        //private CarrierEpAcs _carrierEpAcs = null;
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        //�q�ɃR�[�h�Q�Ɨp�t���O
        private bool _changFlagWarehouse;
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ////���Ǝ҃R�[�h�Q�Ɨp�t���O
        //private bool _changeFlagCarrierEp;
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        //�i�ԎQ�Ɨp�t���O
        private bool _changFlagGoods;

        //���Ӑ�(�d����)�R�[�h�Q�ƃt���O
        private bool _changFlagCustomer;
        //�o�א擾�Ӑ�(�ϑ���)�R�[�h�Q�ƃt���O
        private bool _changFlagShipCustomer;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        
        // ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 2007.07.25 kubo add --------------------------->
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        //// ���ԊǗ��敪�@0�F�Ǘ����Ȃ��@1:�Ǘ�����
		//private int _prdNumMngDiv = 0;
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        // �O���X�敪 -1:�֌W�Ȃ�(�V�K��), 0:���Ԗ�, 1:���i��
		private int _grossDiv = -1;
		// 2007.07.25 kubo add --------------------------->

        // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------->>>>>
        private string beforeWarehouseCode = " ";   //�O����͑q��
        private string beforeGoodsNo = " ";         //�O����͕i��
        // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------<<<<<

        private int GoodsNoFlag = 0;  // ADD 2011/01/11

        private double ListPrice = 0; // ADD 2011/01/30
        #endregion

        #region �� Public Property
		/// <summary> ��ƃR�[�h�v���p�e�B </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> ���_�R�[�h�v���p�e�B </summary>
		public string SectionCode
		{
			set { this._loginSectionCode = value; }
		}
		#endregion

        #region �� PublicEnum
		/// <summary>
		/// �\�����[�h
		/// </summary>
		public enum DispModeState
		{
			/// <summary> �V�K�쐬 </summary>
			CreateNew = 0, 
			/// <summary> �V�K�ҏW </summary>
			EditNew = 1,
			/// <summary> �����ҏW </summary>
			EditOld = 2
		}
		#endregion

        #region PublicMethod

        /// <summary>
        /// ��ʋN������
        /// </summary>
		/// <param name="work">���ʃ��X�g</param>
		/// <param name="mode">�N�����[�h</param>
        /// <remarks>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Note       : ���������ɉ�ʂ̋N�����s���܂�</br>
        /// <br>Date       : 2007/04/18</br>
        /// </remarks>
        public DialogResult ShowEditor(ref InventoryDataUpdateWork work,int mode)
        {
            //�I���������ʃN���X
            this._inventoryDataUpdateWorkBefore = work;
            //�N�����[�h
            this._dispMode = mode;      
			// 2007.07.25 kubo add
			// �O���X�敪
			this._grossDiv = -1;

			// 2007.07.31 kubo add ----------->
            // ��ʏ����ݒ菈��
			ScreenInitialSetting();
			// 2007.07.31 kubo add <-----------

            DialogResult ret = this.ShowDialog();

			if ( ret == DialogResult.OK )
			{
				work = this._inventoryDataUpdateWorkAfter;
			}

            return ret;
        }
       
         /// <summary>
        /// ��ʋN������
        /// </summary>
		/// <param name="work">���ʃ��X�g</param>
		/// <param name="mode">�N�����[�h</param>
		/// <param name="grossDiv">�O���X�敪</param>
        /// <remarks>
        /// <br>Note       : ���������ɉ�ʂ̋N�����s���܂�</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks>
        public DialogResult ShowEditor(ref InventoryDataUpdateWork work, int mode, int grossDiv)
        {
            //�I���������ʃN���X
            this._inventoryDataUpdateWorkBefore = work;
            //�N�����[�h
            this._dispMode = mode;          
			// 2007.07.25 kubo add
			// �O���X�敪
			this._grossDiv = grossDiv;

            // ��ʏ����ݒ菈��
			ScreenInitialSetting();

            DialogResult ret = this.ShowDialog();

			if ( ret == DialogResult.OK )
			{
				work = this._inventoryDataUpdateWorkAfter;
			}

            return ret;
        }
        #endregion

        #region PrivateMethod

        #region ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        private void ClearScreen()
        {
            // �q��
            this.tEdit_WarehouseCode.Clear();
            this.tEdit_WarehouseName.Clear();
            // �i��
            this.tEdit_GoodsNo.Clear();
            // ���i�֘A���
            ClearGoodsInfo();
            // �I����
            this.tNedit_InventoryStockCnt.Clear();
            // ���P��
            this.tNedit_StockUnitPrice.Clear();
            // �I��
            this.tEdit_WarehouseShelfNo.Clear();
            // �d���I��1
            this.tEdit_DuplicationShelfNo1.Clear();
            // �d���I��2
            this.tEdit_DuplicationShelfNo2.Clear();
            // �I�����{��
            this.EnforcementDay_tDateEdit.SetDateTime(new DateTime());
            // �I����
            this.InventoryDay_tDateEdit.SetDateTime(new DateTime());

            //-------------------------------------------
            // ��\������
            //-------------------------------------------
            // JAN�R�[�h
            this.tEdit_Jan.Clear();
            // ���Е��ރR�[�h
            this.tNedit_EnterpriseGanreCode.Clear();
            // �ύX�O���P��
            this.BfStockUnitPrice_tNedit.Clear();

            // ---ADD 2009/05/14 �s��Ή�[13260] --------------------->>>>>
            //�����p�v�Z����
            this.tNedit_AdjustCalcCost.Clear();
            //�݌ɋ敪
            this.tNedit_StockDiv.Clear();
            //�ŏI�d���N����
            this.LastStockDate_tDateEdit.Clear();
            // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------<<<<<
        }
        #endregion ��ʏ���������

        #region ��ʏ����ݒ菈��
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ菈�����s���܂�</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �R���g���[���T�C�Y�ݒ�
            this.tEdit_WarehouseCode.Size = new Size(60, 24);
            this.tEdit_WarehouseName.Size = new Size(290, 24);
            this.tEdit_GoodsNo.Size = new Size(385, 24);
            this.tEdit_GoodsName.Size = new Size(385, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(60, 24);
            this.tEdit_MakerName.Size = new Size(209, 122);
            this.tEdit_SectionCode.Size = new Size(60, 24);
            this.tEdit_SectionName.Size = new Size(209, 122);
            this.tNedit_SupplierCd.Size = new Size(60, 24);
            this.tEdit_SupplierName.Size = new Size(209, 122);
            this.tNedit_GoodsLGroup.Size = new Size(60, 24);
            this.tEdit_GoodsLGroupName.Size = new Size(209, 122);
            this.tNedit_GoodsMGroup.Size = new Size(60, 24);
            this.tEdit_GoodsMGroupName.Size = new Size(209, 122);
            this.tNedit_BLGloupCode.Size = new Size(60, 24);
            this.tEdit_BLGroupName.Size = new Size(209, 122);
            this.tNedit_BLGoodsCode.Size = new Size(60, 24);
            this.tEdit_BLGoodsName.Size = new Size(209, 122);
            this.tNedit_InventoryStockCnt.Size = new Size(115, 24);
            this.tNedit_StockUnitPrice.Size = new Size(115, 24);
            this.tEdit_WarehouseShelfNo.Size = new Size(74, 24);
            this.tEdit_DuplicationShelfNo1.Size = new Size(74, 24);
            this.tEdit_DuplicationShelfNo2.Size = new Size(74, 24);

            // �C���[�W���X�g��ݒ肷��
            ImageList imageList16 = IconResourceManagement.ImageList16;
			this.Main_ToolbarsManager.ImageListSmall = imageList16;          

			// �I���̃A�C�R���ݒ�
			ButtonTool closeButton = (ButtonTool)Main_ToolbarsManager.Tools["ctCLOSE_BUTTONTOOLKEY"];
            if (closeButton != null)
            {
                closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            }
			// �ۑ��̃A�C�R���ݒ�
            ButtonTool saveButton = (ButtonTool)Main_ToolbarsManager.Tools["ctSAVE_BUTTONTOOLKEY"];
            if (saveButton != null)
            {
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            }

            // �q�ɃK�C�h
            this.WarehouseGuide_Button.ImageList = imageList16;
            this.WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // ��ʏ�����
            ClearScreen();

            // ���t�o�b�N�J���[�ݒ�
            this.InventoryDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;
            this.EnforcementDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;

            // ��ʂɏ����f�[�^��W�J
            SetScreenFromInventoryDataUpdateWork(this._inventoryDataUpdateWorkBefore);

            this._inventInputAcs.SearchAll(out _inventoryDataUpdateWorkList, this._enterpriseCode, this._inventoryDataUpdateWorkBefore.InventoryDate);
            
            // �N�����[�h�ɂ���ď������s��
            switch(this._dispMode)
            {
                // �V�K
                case (int)DispModeState.CreateNew:
                {
                    // �I�����{��
                    this.EnforcementDay_tDateEdit.SetDateTime(this._inventoryDataUpdateWorkBefore.InventoryDay);

                    // �I����
                    this.InventoryDay_tDateEdit.SetDateTime(this._inventoryDataUpdateWorkBefore.InventoryDate);

                    this.Mode_Title.Text = ctNEW_MODE;
                    break;
                }
                // �V�K���ҏW
                case (int)DispModeState.EditNew:
                {
                    this.Mode_Title.Text = ctEDIT_MODE;
                    break;
                }
                // �ҏW
                case (int)DispModeState.EditOld:
                {
                    // �ۗ�
                    this.Mode_Title.Text = ctREADONLY_MODE;
                    
                    // ��ʂ�ReadOnly��Ԃɂ���
                    ScreenSettingReadOnly(false);
                    break;
                }
            }

            this.beforeWarehouseCode = " ";         //ADD 2009/05/14 �s��Ή�[13260]
            this.beforeGoodsNo = " ";               //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Note       : ��ʂ̏����ݒ菈�����s���܂�</br>
        /// <br>Date       : 2007/04/18</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �C���[�W���X�g��ݒ肷��
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Main_ToolbarsManager.ImageListSmall = imageList16;

            // �I���̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["ctCLOSE_BUTTONTOOLKEY"];
            if (closeButton != null)
                closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // �ۑ��̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["ctSAVE_BUTTONTOOLKEY"];
            if (saveButton != null)
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

            //�q�ɃK�C�h
            this.WarehouseGuide_Button.ImageList = imageList16;
            this.WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ҃K�C�h
            //this.CarrierEpGuide_Button.ImageList = imageList16;         
            //this.CarrierEpGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���Ӑ�(�d����)�K�C�h
            this.CustomerGuide_Button.ImageList = imageList16;
            this.CustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //�o�א擾�Ӑ�(�ϑ���)�K�C�h
            this.ShipCustomerGuide_Button.ImageList = imageList16;
            this.ShipCustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //���i�K�C�h
            this.GoodsGuide_Button.ImageList = imageList16;
            this.GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //���t�o�b�N�J���[�ݒ�
            this.InventoryDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;
            this.EnforcementDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<


            //��ʂ̓��͐���
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���ԊǗ��敪�������̏ꍇ�͐��ԁA�g�єԍ�����͂ł��Ȃ��悤�ɂ���
            //if(this._inventoryDataUpdateWorkBefore.PrdNumMngDiv == 0)
            //{
            //    //�����ԍ����N���A����
            //    ProductNumberClear();
            //    ScreeParmitionControl(false);
            //
            //	if ( this._grossDiv == (int)InventInputSearchCndtn.GrossDivState.Goods )
            //		this.tNedit_InventoryStockCnt.Enabled = false;
            //
            //}
            //else
            //{
            //    ScreeParmitionControl(true);
            //
            //	if ( this._grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product )
            //	{
            //		if ( this._inventoryDataUpdateWorkBefore.ProductNumber == "" && 
            //			this._inventoryDataUpdateWorkBefore.StockTelNo1 == "" && 
            //			this._inventoryDataUpdateWorkBefore.StockTelNo2 == "" )
            //		{
            //			this.tNedit_InventoryStockCnt.Enabled = true;
            //		}
            //		else
            //		{
            //			this.tNedit_InventoryStockCnt.Enabled = false;
            //		}
            //
            //	}
            //	else
            //	{
            //		if ( this._dispMode == (int)DispModeState.EditNew )
            //			this.tNedit_InventoryStockCnt.Enabled = false;
            //		else
            //			this.tNedit_InventoryStockCnt.Enabled = true;
            //
            //		this.ProductNumber_tEdit.Enabled = false;
            //		this.StockTelNo1_tEdit.Enabled = false;
            //		this.StockTelNo2_tEdit.Enabled = false;
            //	}
            //}
            //
            //// 2007.07.25 kubo add
            //this._prdNumMngDiv = this._inventoryDataUpdateWorkBefore.PrdNumMngDiv;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //��ʂɏ����f�[�^��W�J
            SetScreenFromInventoryDataUpdateWork(this._inventoryDataUpdateWorkBefore);

            //�N�����[�h�ɂ���ď������s��
            switch (this._dispMode)
            {
                //�V�K
                case (int)DispModeState.CreateNew:
                    {
                        //�V�K�̏ꍇ�A�d�����A�o�ד��A�I�����{���Ɍ��݂̓��t���Z�b�g
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�d����
                        //this.StockDate_tDateEdit.SetDateTime(DateTime.Now);
                        ////���ד�
                        //this.ArrivalGoodsDay_tDateEdit.SetDateTime(DateTime.Now);
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�I����
                        //this.InventoryDay_tDateEdit.SetDateTime(DateTime.Now);
                        //�I�����{��
                        this.EnforcementDay_tDateEdit.SetDateTime(DateTime.Now);

                        //�I����
                        this.InventoryDay_tDateEdit.SetDateTime(this._inventoryDataUpdateWorkBefore.InventoryDay);
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

                        this.Mode_Title.Text = ctNEW_MODE;
                        break;
                    }
                //�V�K���ҏW
                case (int)DispModeState.EditNew:
                    {
                        this.Mode_Title.Text = ctEDIT_MODE;
                        break;
                    }
                //�ҏW
                case (int)DispModeState.EditOld:
                    {
                        //�ۗ�
                        this.Mode_Title.Text = ctREADONLY_MODE;
                        //��ʂ�ReadOnly��Ԃɂ���
                        ScreenSettingReadOnly(false);
                        break;
                    }
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �Q�ƃ��[�h��ʐݒ菈��
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �Q�ƃ��[�h��ʐݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Q�ƃ��[�h�p�̉�ʐݒ菈�����s���܂�</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void ScreenSettingReadOnly(bool para)
        {
            //�q��
            this.tEdit_WarehouseCode.Enabled = para;
            this.WarehouseGuide_Button.Enabled = para;
            //���i
            this.tEdit_GoodsNo.Enabled = para;
            //�d����
            this.tNedit_SupplierCd.Enabled = para;
            //���P��
            this.tNedit_StockUnitPrice.Enabled = para;
            //�I����
            this.tNedit_InventoryStockCnt.Enabled = para;
            //�I��
            this.tEdit_WarehouseShelfNo.Enabled = para;
            //�d���I�ԂP
            this.tEdit_DuplicationShelfNo1.Enabled = para;
            //�d���I�ԂQ
            this.tEdit_DuplicationShelfNo2.Enabled = para;
            //�I�����{��
            this.InventoryDay_tDateEdit.Enabled = para;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �Q�ƃ��[�h��ʐݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Note       : �Q�ƃ��[�h�p�̉�ʐݒ菈�����s���܂�</br>
        /// <br>Date       : 2007/04/24</br>
        /// </remarks>
        private void ScreenSettingReadOnly(bool para)
        {
            //�q��
            this.tEdit_WarehouseCode.Enabled = para;
            this.WarehouseGuide_Button.Enabled = para;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ�
            //this.CarrierCode_tNedit.Enabled = para;
            //this.CarrierEpGuide_Button.Enabled = para;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���i
            this.tEdit_GoodsNo.Enabled = para;
            this.GoodsGuide_Button.Enabled = para;
            //�d����
            this.tNedit_SupplierCd.Enabled = para;
            this.CustomerGuide_Button.Enabled = para;
            //�ϑ���
            this.ShipCustomerCode_tNedit.Enabled = para;
            this.ShipCustomerGuide_Button.Enabled = para;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�݌ɋ敪
            //this.StockExtraDiv_ultraOptionSet.Enabled = para;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���P��
            this.tNedit_StockUnitPrice.Enabled = para;
            //�I����
            this.tNedit_InventoryStockCnt.Enabled = para;
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////����
            //this.ProductNumber_tEdit.Enabled = para;
            ////�d�b�ԍ��P
            //this.StockTelNo1_tEdit.Enabled = para;
            ////�d�b�ԍ��P
            //this.StockTelNo2_tEdit.Enabled = para;
            ////�d����
            //this.StockDate_tDateEdit.Enabled = para;
            ////���ד�
            //this.ArrivalGoodsDay_tDateEdit.Enabled = para;
            //�I��
            this.tEdit_WarehouseShelfNo.Enabled = para;
            //�d���I�ԂP
            this.tEdit_DuplicationShelfNo1.Enabled = para;
            //�d���I�ԂQ
            this.tEdit_DuplicationShelfNo2.Enabled = para;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //�I�����{��
            this.InventoryDay_tDateEdit.Enabled = para;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �����f�[�^��ʓW�J����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����f�[�^��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂւ̏����f�[�^�W�J���s���܂�</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void SetScreenFromInventoryDataUpdateWork(InventoryDataUpdateWork work)
        {                                         
            // �q�ɃR�[�h
            this.tEdit_WarehouseCode.DataText = work.WarehouseCode.Trim();
            // �q�ɖ���
            if (work.WarehouseCode.Trim() == "")
            {
                this.tEdit_WarehouseName.Clear();
            }
            else
            {
                this.tEdit_WarehouseName.DataText = this._inventInputAcs.GetWarehouseName(work.WarehouseCode);
            }
            // �i��
            this.tEdit_GoodsNo.DataText = work.GoodsNo.TrimEnd();
            // �i��
            if ((work.GoodsMakerCd == 0) || (work.GoodsNo.Trim() == ""))
            {
                this.tEdit_GoodsName.Clear();
            }
            else
            {
                this.tEdit_GoodsName.DataText = this._inventInputAcs.GetGoodsName(work.GoodsMakerCd, work.GoodsNo);
            }
            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.SetInt(work.GoodsMakerCd);
            // ���[�J�[����
            if (work.GoodsMakerCd == 0)
            {
                this.tEdit_MakerName.Clear();
            }
            else
            {
                this.tEdit_MakerName.DataText = this._inventInputAcs.GetMakerName(work.GoodsMakerCd);
            }
            // �Ǘ����_�R�[�h
            this.tEdit_SectionCode.DataText = work.SectionCode;
            // �Ǘ����_����
            if (work.SectionCode.Trim() == "")
            {
                this.tEdit_SectionName.Clear();
            }
            else
            {
                this.tEdit_SectionName.DataText = this._inventInputAcs.GetSectionName(work.SectionCode);
            }
            // ���i�啪�ރR�[�h
            this.tNedit_GoodsLGroup.SetInt(work.GoodsLGroup);
            // ���i�啪�ޖ���
            if (work.GoodsLGroup == 0)
            {
                this.tEdit_GoodsLGroupName.Clear();
            }
            else
            {
                this.tEdit_GoodsLGroupName.DataText = this._inventInputAcs.GetGoodsLGroupName(work.GoodsLGroup);
            }
            // ���i�����ރR�[�h
            this.tNedit_GoodsMGroup.SetInt(work.GoodsMGroup);
            // ���i�����ޖ���
            if (work.GoodsMGroup == 0)
            {
                this.tEdit_GoodsMGroupName.Clear();
            }
            else
            {
                this.tEdit_GoodsMGroupName.DataText = this._inventInputAcs.GetGoodsMGroupName(work.GoodsMGroup);
            }
            // �O���[�v�R�[�h�R�[�h
            this.tNedit_BLGloupCode.SetInt(work.BLGroupCode);
            // �O���[�v�R�[�h����
            if (work.BLGroupCode == 0)
            {
                this.tEdit_BLGroupName.Clear();
            }
            else
            {
                this.tEdit_BLGroupName.DataText = this._inventInputAcs.GetBLGroupName(work.BLGroupCode);
            }
            // BL�R�[�h
            this.tNedit_BLGoodsCode.SetInt(work.BLGoodsCode);
            // BL�R�[�h����
            if (work.BLGoodsCode == 0)
            {
                this.tEdit_BLGoodsName.Clear();
            }
            else
            {
                this.tEdit_BLGoodsName.DataText = this._inventInputAcs.GetBLGoodsName(work.BLGoodsCode);
            }
            // ���Е��ރR�[�h
            this.tNedit_EnterpriseGanreCode.SetInt(work.EnterpriseGanreCode);
            // �d����R�[�h
            this.tNedit_SupplierCd.SetInt(work.SupplierCd);
            // �d���於��(�\���p)
            // �d���於��1
            // �d���於��2
            if (work.SupplierCd == 0)
            {
                this.tEdit_SupplierName.Clear();
                this.tEdit_SupplierName1.Clear();
                this.tEdit_SupplierName2.Clear();
            }
            else
            {
                int status;
                string supplierName1;
                string supplierName2;
                status = this._inventInputAcs.GetSupplierName(work.SupplierCd, out supplierName1, out supplierName2);
                this.tEdit_SupplierName.DataText = supplierName1 + " " + supplierName2;
                this.tEdit_SupplierName1.DataText = supplierName1;
                this.tEdit_SupplierName2.DataText = supplierName2;
            }
            // �I��
            this.tEdit_WarehouseShelfNo.DataText = work.WarehouseShelfNo.TrimEnd();
            // �d���I��1
            this.tEdit_DuplicationShelfNo1.DataText = work.DuplicationShelfNo1.TrimEnd();
            // �d���I��2
            this.tEdit_DuplicationShelfNo2.DataText = work.DuplicationShelfNo2.TrimEnd();
            // JAN�R�[�h
            this.tEdit_Jan.DataText = work.Jan.TrimEnd();
            // ���P��
            this.tNedit_StockUnitPrice.SetValue((double)work.StockUnitPriceFl);
            // �ύX�O���P��
            this.BfStockUnitPrice_tNedit.SetValue((double)work.BfStockUnitPriceFl);
            // �I���݌ɐ�
            this.tNedit_InventoryStockCnt.SetValue(work.InventoryStockCnt);
            // �I����
            this.InventoryDay_tDateEdit.SetDateTime(work.InventoryDate);
            // �I�����{��
            this.EnforcementDay_tDateEdit.SetDateTime(work.InventoryDay);
            // �����p�v�Z����
            this.tNedit_AdjustCalcCost.SetValue(work.AdjstCalcCost);        //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����f�[�^��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Note       : ��ʂւ̏����f�[�^�W�J���s���܂�</br>
        /// <br>Date       : 2007/04/19</br>
        /// </remarks>
        private void SetScreenFromInventoryDataUpdateWork(InventoryDataUpdateWork work)
        {
            //�q�ɃR�[�h
            this.tEdit_WarehouseCode.DataText = work.WarehouseCode.TrimEnd();
            //�q�ɖ���
            this.tEdit_WarehouseName.DataText = work.WarehouseName.TrimEnd();
            //�i��
            this.tEdit_GoodsNo.DataText = work.GoodsNo.TrimEnd();
            //�i��
            this.tEdit_GoodsName.DataText = work.GoodsName.TrimEnd();
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�R�[�h
            //this.CarrierCode_tNedit.SetInt(work.CarrierCode);
            ////�L�����A����
            //this.CarrierName_tEdit.DataText = work.CarrierName.TrimEnd();
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���[�J�[�R�[�h
            this.MakerCode_tNedit.SetInt(work.GoodsMakerCd);
            //���[�J�[����
            this.tEdit_MakerName.DataText = work.MakerName.TrimEnd();
            //���i�啪�ރR�[�h
            this.LgGoodsCode_tEdit.DataText = work.LargeGoodsGanreCode;
            //���i�啪�ޖ���
            this.LargeGoodsGanreName_tEdit.DataText = work.LargeGoodsGanreName.TrimEnd();
            //���i�����ރR�[�h
            this.MdGoodsCode_tEdit.DataText = work.MediumGoodsGanreCode;
            //���i�����ޖ���
            this.MediumGoodsGanreName_tEdit.DataText = work.MediumGoodsGanreName.TrimEnd();
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�@��R�[�h
            //this.CellphonModelCode_tEdit.DataText = work.CellphoneModelCode.TrimEnd();
            ////�@�햼��
            //this.CellphonModelName_tEdit.DataText = work.CellphoneModelName.TrimEnd();
            ////�n���F�R�[�h
            //this.SystematicColorCode_tNedit.SetInt(work.SystematicColorCd);
            ////�n���F����
            //this.SystematicColorName_tEdit.DataText = work.SystematicColorNm.TrimEnd();
            ////���Ǝ҃R�[�h
            //this.CarrierEpCode_tNedit.SetInt(work.CarrierEpCode);
            ////���ƎҖ���
            //this.CarrierEpName_tEdit.DataText = work.CarrierEpName.TrimEnd();
            //�O���[�v�R�[�h
            this.DtGoodsGanreCode_tEdit.DataText = work.DetailGoodsGanreCode;
            //�O���[�v�R�[�h����
            this.tEdit_BLGroupName.DataText = work.DetailGoodsGanreName.TrimEnd();
            //�a�k�i��
            this.tNedit_BLGoodsCode.SetInt(work.BLGoodsCode);
            //�a�k�i��
            //            this.tEdit_BLGoodsName.DataText = work.BLGoodsName.TrimEnd();
            //���Е��ރR�[�h
            this.tNedit_EnterpriseGanreCode.SetInt(work.EnterpriseGanreCode);
            //���Е��ޖ���
            this.EnterpriseGanreName_tEdit.DataText = work.EnterpriseGanreName.TrimEnd();
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //���Ӑ�(�d����)�R�[�h
            this.tNedit_SupplierCd.SetInt(work.CustomerCode);
            //���Ӑ�(�d����)���̂P
            this.tEdit_SupplierName.DataText = work.CustomerName.TrimEnd();
            //���Ӑ�(�d����)���̂Q
            this.CustomerName2_tEdit.DataText = work.CustomerName2.TrimEnd();
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�d����
            //this.StockDate_tDateEdit.SetDateTime(work.StockDate);
            ////���ד�
            //this.ArrivalGoodsDay_tDateEdit.SetDateTime(work.ArrivalGoodsDay);
            ////�����ԍ�
            //this.ProductNumber_tEdit.DataText = work.ProductNumber.TrimEnd();
            ////���i�d�b�ԍ�1
            //this.StockTelNo1_tEdit.DataText = work.StockTelNo1.TrimEnd();
            ////�ύX�O�d�b�ԍ�1
            //this.BfStockTelNo1_tEdit.DataText = work.BfStockTelNo1.TrimEnd();
            ////���i�d�b�ԍ�2
            //this.StockTelNo2_tEdit.DataText = work.StockTelNo2.TrimEnd();
            ////�ύX�O�d�b�ԍ�2
            //this.BfStockTelNo2_tEdit.DataText = work.BfStockTelNo2.TrimEnd();
            //�I��
            this.tEdit_WarehouseShelfNo.DataText = work.WarehouseShelfNo.TrimEnd();
            //�d���I��1
            this.tEdit_DuplicationShelfNo1.DataText = work.DuplicationShelfNo1.TrimEnd();
            //�d���I��2
            this.tEdit_DuplicationShelfNo2.DataText = work.DuplicationShelfNo2.TrimEnd();
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //JAN�R�[�h
            this.tEdit_Jan.DataText = work.Jan.TrimEnd();
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�d���P��
            //this.tNedit_StockUnitPrice.SetValue((long)work.StockUnitPrice);
            ////�ύX�O�d���P��
            //this.BfStockUnitPrice_tNedit.SetValue((long)work.BfStockUnitPrice);
            //�d���P��
            this.tNedit_StockUnitPrice.SetValue((double)work.StockUnitPriceFl);
            //�ύX�O�d���P��
            this.BfStockUnitPrice_tNedit.SetValue((double)work.BfStockUnitPriceFl);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�݌ɋ敪           
            //switch(work.StockDiv)
            //{
            //    //����
            //    case 0:
            //    {
            //        //�݌ɏ��
            //        switch(work.StockState)
            //        {
            //            //����
            //            case 0:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 0;
            //                break;
            //            }
            //            //�ϑ���
            //            case 20:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 2;
            //                break;
            //            }
            //        }
            //        break;
            //    }
            //    //���
            //    case 1:
            //    {
            //         //�݌ɏ��
            //        switch(work.StockState)
            //        {
            //            //����
            //            case 0:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 1;
            //                break;
            //            }
            //            //�ϑ���
            //            case 20:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 3;
            //                break;
            //            }
            //        }
            //        break;   
            //    }
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���ԊǗ��敪
            //this.PrdNumMngDiv_tNedit.SetInt(work.PrdNumMngDiv);
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //�o�א擾�Ӑ�(�ϑ���)�R�[�h
            this.ShipCustomerCode_tNedit.SetInt(work.ShipCustomerCode);
            //�o�א擾�Ӑ�(�ϑ���)���̂P
            this.ShipCustomerName1_tEdit.DataText = work.ShipCustomerName.TrimEnd();
            //�o�א擾�Ӑ�(�ϑ���)���̂Q
            this.ShipCustomerName2_tEdit.DataText = work.ShipCustomerName2.TrimEnd();
            //�I���݌ɐ�
            this.tNedit_InventoryStockCnt.SetValue(work.InventoryStockCnt);
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�I�����{��
            //this.InventoryDay_tDateEdit.SetDateTime(work.InventoryDay);
            //�I����
            this.InventoryDay_tDateEdit.SetDateTime(work.InventoryDate);
            //�I�����{��
            this.EnforcementDay_tDateEdit.SetDateTime(work.InventoryDay);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<


            // 2007.07.30 kubo del 
            // Enabled�ݒ�
            //if ( work.ProductNumber == "" )
            //    this.ProductNumber_tEdit.Enabled = true;
            //else
            //    this.ProductNumber_tEdit.Enabled = false;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ���Ӑ�(�d����)�I���������C�x���g
        /// <summary>
		/// ���Ӑ�(�d����)�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        :���Ӑ�K�C�h�œ��Ӑ��I���������ɔ������܂�</br>
        /// <br>Programmer  :23010 �����@�m</br>
        /// <br>Date        :2007.04.17</br>
        /// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustSuppli custSuppli;

            //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
			int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //TODO:�K�v���H�H
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I�������d����͎d��������͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status,
                        MessageBoxButtons.OK);

                    //��ʏ����N���A
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierName.Clear();
                    this.CustomerName2_tEdit.Clear();

                    return;
                }
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I�������d����͊��ɍ폜����Ă��܂��B",
					status,
					MessageBoxButtons.OK);

                //��ʏ����N���A
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�d������̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

                //��ʏ����N���A
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}
         
            //���Ӑ�(�d����)�R�[�h���Z�b�g          
            this.tNedit_SupplierCd.SetInt(customerSearchRet.CustomerCode);
            this.tEdit_SupplierName.DataText = customerSearchRet.Name.TrimEnd();
            this.CustomerName2_tEdit.DataText = customerSearchRet.Name2.TrimEnd();
		}
        #endregion

        #region �o�א擾�Ӑ�(�ϑ���)�I���������C�x���g

        /// <summary>
		/// �o�א擾�Ӑ�(�ϑ���)�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        :���Ӑ�K�C�h�ŏo�א擾�Ӑ��I���������ɔ������܂�</br>
        /// <br>Programmer  :23010 �����@�m</br>
        /// <br>Date        :2007.04.17</br>
        /// </remarks>
		private void CustomerSearchForm_ShipCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			
            //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{             
                //�Ȃɂ����Ȃ�             
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
					status,
					MessageBoxButtons.OK);

                //�N���A
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"���Ӑ���̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

                //�N���A
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}

            //�ϑ���              
            this.ShipCustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
            this.ShipCustomerName1_tEdit.DataText = customerSearchRet.Name.TrimEnd();
            this.ShipCustomerName2_tEdit.DataText = customerSearchRet.Name2.TrimEnd();
	          
		}
    
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region ���i�f�[�^��ʓW�J����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���i�f�[�^��ʓW�J����(��ʁ����i)
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h���瓾��������ʂɓW�J���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �V�K���͎��̍��ڎ擾���@��ύX����</br>
        /// <br>UpdateNote : 2012/06/11 ������</br>
        /// <br>             Redmine#30238</br>
        /// </remarks>       
        private void SetGoodsUnitForScreen(GoodsUnitData goodsUnitData)
        {
            string sectionCode = string.Empty;

            // --- ADD 2009/12/03 ---------->>>>>
            this.tNedit_StockUnitPrice.Clear();
            this.BfStockUnitPrice_tNedit.Clear();
            this.tNedit_StockTotal.Clear();
            // --- ADD 2009/12/03 ----------<<<<<

            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo.TrimEnd();                                      // �i��
            this.tEdit_GoodsName.DataText = goodsUnitData.GoodsName.TrimEnd();                                  // �i��
            this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);                                        // ���[�J�[�R�[�h
            this.tEdit_MakerName.DataText = goodsUnitData.MakerName.TrimEnd();                                  // ���[�J�[����
            //this.tEdit_SectionCode.DataText = goodsUnitData.SectionCode.Trim();                                 // �Ǘ����_�R�[�h                     //DEL 2009/05/14 �s��Ή�[13260]
            //this.tEdit_SectionName.DataText = this._inventInputAcs.GetSectionName(goodsUnitData.SectionCode.Trim().PadLeft(2, '0')); // �Ǘ����_����  //DEL 2009/05/14 �s��Ή�[13260]
            // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------------------------------------>>>>>
            //���i�݌ɏ�񂩂�擾
             Stock stock = this.GetSectionCodeFromGoodsUnitData(goodsUnitData);
            if (stock == null)
            {
                //�q�Ƀ}�X�^����擾
                sectionCode = this.GetSectionCodeFromWarehouseInfo();               //���_�R�[�h

                //�����l
                this.tNedit_StockDiv.SetInt(0);                                     //�݌ɋ敪
                this.LastStockDate_tDateEdit.SetDateTime(DateTime.MinValue);        //�ŏI�d���N����
            }
            else
            {
                //�݌Ƀ}�X�^����擾
                sectionCode = stock.SectionCode;                                    //���_�R�[�h
                this.tNedit_StockDiv.SetInt(stock.StockDiv);                        //�݌ɋ敪
                if (stock.LastStockDate != null)
                {
                    this.LastStockDate_tDateEdit.SetDateTime(stock.LastStockDate);  //�ŏI�d���N����
                }

                // --- ADD 2009/12/03 ---------->>>>>
                this.tEdit_WarehouseShelfNo.Text = stock.WarehouseShelfNo;
                this.tEdit_DuplicationShelfNo1.Text = stock.DuplicationShelfNo1;
                this.tEdit_DuplicationShelfNo2.Text = stock.DuplicationShelfNo2;
                this.tNedit_StockUnitPrice.SetValue(stock.StockUnitPriceFl);
                this.BfStockUnitPrice_tNedit.SetValue(stock.StockUnitPriceFl);
                this.tNedit_StockTotal.SetValue(this._inventInputAcs.GetStockTotal(stock,
                        this.InventoryDay_tDateEdit.GetDateTime())); // �݌ɑ���
                // --- ADD 2009/12/03 ----------<<<<<
            }

            this.tEdit_SectionCode.DataText = sectionCode;
            this.tEdit_SectionName.DataText = this._inventInputAcs.GetSectionName(sectionCode.Trim().PadLeft(2, '0'));
            //-----ADD BY ������ on 2012/06/11 for Redmine#30238 ------>>>>>>
            this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode);
            this.tNedit_GoodsMGroup.SetInt(goodsUnitData.GoodsMGroup);
            //-----ADD BY ������ on 2012/06/11 for Redmine#30238 ------<<<<<<
            int supplierCd = 0;
            string supplierNm1 = string.Empty;
            string supplierNm2 = string.Empty;
            this.GetGoodsMngInfo(out supplierCd, out supplierNm1,out supplierNm2);
            this.tNedit_SupplierCd.SetInt(supplierCd);
            this.tEdit_SupplierName.DataText = supplierNm1 + " " + supplierNm2;
            this.tEdit_SupplierName1.DataText = supplierNm1;
            this.tEdit_SupplierName2.DataText = supplierNm2;

            this.tNedit_AdjustCalcCost.SetValue(this._inventInputAcs.GetAdjustCalcCost(goodsUnitData));         // �����p�v�Z����

            // --- ADD 2009/12/03 ---------->>>>>
            if (this.tNedit_StockUnitPrice.GetValue() == 0)
            {
                this.tNedit_StockUnitPrice.SetValue(this.tNedit_AdjustCalcCost.GetValue());
                this.BfStockUnitPrice_tNedit.SetValue(this.tNedit_AdjustCalcCost.GetValue());
            }
            // --- ADD 2009/12/03 ----------<<<<<

            // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------------------------------------<<<<<

            this.tNedit_GoodsLGroup.DataText = goodsUnitData.GoodsLGroup.ToString();                            // ���i�啪�ރR�[�h
            this.tEdit_GoodsLGroupName.DataText = goodsUnitData.GoodsLGroupName.TrimEnd();                      // ���i�啪�ޖ���
            this.tNedit_GoodsMGroup.DataText = goodsUnitData.GoodsMGroup.ToString();                            // ���i�����ރR�[�h
            this.tEdit_GoodsMGroupName.DataText = goodsUnitData.GoodsMGroupName.TrimEnd();                      // ���i�����ޖ���
            this.tNedit_BLGloupCode.DataText = goodsUnitData.BLGroupCode.ToString();                            // �O���[�v�R�[�h
            this.tEdit_BLGroupName.DataText = goodsUnitData.BLGroupName.TrimEnd();                              // �O���[�v�R�[�h����
            this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode);                                          // �a�k�i��
            this.tEdit_BLGoodsName.DataText = goodsUnitData.BLGoodsFullName.TrimEnd();                          // �a�k�i��
            this.tNedit_EnterpriseGanreCode.SetInt(goodsUnitData.EnterpriseGanreCode);                          // ���Е��ރR�[�h
            this.tEdit_Jan.DataText = goodsUnitData.Jan.TrimEnd();                                              // JAN�R�[�h
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------->>>>>
        #region GetSectionCodeFromGoodsUnitData(���i�݌ɏ�񂩂狒�_�R�[�h���擾)
        /// <summary>
        /// ���_�R�[�h�擾(���i�݌ɏ��x�[�X)
        /// </summary>
        /// <param name="goodsUnitData">���i�݌ɏ��</param>
        /// <returns>�݌ɏ��</returns>
        /// <remarks>
        /// <br>Note       : ���i�݌ɏ�񂩂狒�_�R�[�h���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks> 
        private Stock GetSectionCodeFromGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            string sectionCode = string.Empty;

            //���i���Ȃ�
            if (goodsUnitData == null)
            {
                return null;
            }
            //�݌ɏ��Ȃ�
            if ((goodsUnitData.StockList == null) || (goodsUnitData.StockList.Count == 0))
            {
                return null;
            }

            for (int i = 0; i < goodsUnitData.StockList.Count; i++)
            {
                if (goodsUnitData.StockList[i].WarehouseCode.Trim().PadLeft(4, '0') == this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0'))
                {
                    return goodsUnitData.StockList[i];
                }
            }

            //���i�݌ɂɑΏۂ̑q�ɂ�����
            return null;
        }
        #endregion

        #region GetSectionCodeFromWarehouseInfo(�q�Ƀ}�X�^���狒�_�R�[�h���擾)
        /// <summary>
        /// ���_�R�[�h�擾(�q�Ƀ}�X�^�x�[�X)
        /// </summary>
        /// <returns>���_�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^���狒�_�R�[�h���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks> 
        private string GetSectionCodeFromWarehouseInfo()
        {
            string warehouseCode = tEdit_WarehouseCode.Text;

            if (string.IsNullOrEmpty(warehouseCode.Trim()))
            {
                return string.Empty;
            }

            ArrayList arrayList = null;
            int status = this._warehouseGuideAcs.Search(out arrayList, this._enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return string.Empty;
            }

            Warehouse warehouse = null;
            for (int i = 0; i < arrayList.Count; i++)
            {
                warehouse = (Warehouse)arrayList[i];
                if (warehouseCode.Trim().PadLeft(4, '0') == warehouse.WarehouseCode.Trim().PadLeft(4, '0'))
                {
                    return warehouse.SectionCode;
                }
            }

            return string.Empty;
        }
        #endregion

        #region GetGoodsMngInfo(���i�Ǘ����擾)
        /// <summary>
        /// ���i�Ǘ����}�X�^�擾
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ������擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2012/06/11 ������</br>
        /// <br>             Redmine#30238</br>
        /// </remarks> 
        private void GetGoodsMngInfo(out int supplierCd, out string supplierNm1, out string supplierNm2)
        {
            supplierCd = 0;
            supplierNm1 = string.Empty;
            supplierNm2 = string.Empty;

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = this._enterpriseCode;
            goodsUnitData.SectionCode = this.tEdit_SectionCode.DataText;
            goodsUnitData.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            goodsUnitData.GoodsNo = this.tEdit_GoodsNo.DataText;
            goodsUnitData.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            goodsUnitData.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();//ADD BY ������ on 2012/06/11 for Redmine#30238
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            supplierCd = goodsUnitData.SupplierCd;
            if (supplierCd == 0)
            {
                supplierNm1 = string.Empty;
                supplierNm2 = string.Empty;
            }
            else
            {
                SupplierWork supplierWork = null;
                int status = this._goodsAcs.GetSupplier(LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd, out supplierWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    supplierNm1 = supplierWork.SupplierNm1;
                    supplierNm2 = supplierWork.SupplierNm2;
                }
                else
                {
                    supplierNm1 = string.Empty;
                    supplierNm2 = string.Empty;
                }
            }
        }
        #endregion

        // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���i�f�[�^��ʓW�J����(��ʁ����i)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h���瓾��������ʂɓW�J���܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>       
        private void SetGoodsUnitForScreen(GoodsUnitData goodsUnitData)
        {
            //���ԁA�d�b�ԍ����N���A

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���ԊǗ��敪�������̎��͐��ԁA�d�b�ԍ�����͕s�ɂ���
            //if(goodsUnitData.PrdNumMngDiv == 0)
            //{
            //    ProductNumberClear();
            //    ScreeParmitionControl(false);
            //    //�I��������͉ɂ���
            //    this.tNedit_InventoryStockCnt.Enabled = true;
            //}
            //else
            //{              
            //    ScreeParmitionControl(true);
            //    //����or�d�b�ԍ������͂���Ă��邩�H
            //    if(this.ProductNumber_tEdit.DataText.TrimEnd() == "" && this.StockTelNo1_tEdit.DataText.TrimEnd() == "" && this.StockTelNo2_tEdit.DataText.TrimEnd() == "")
            //    {
            //        //�I��������͉ɂ���
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //�I��������͉ɂ���
            //		if ( tNedit_InventoryStockCnt.GetInt() > 0 )
            //			this.tNedit_InventoryStockCnt.Enabled = false;
            //		else
            //			this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //}
            //
            //// 2007.07.25 kubo add
            //this._prdNumMngDiv = goodsUnitData.PrdNumMngDiv;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //�i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsCode.TrimEnd();
            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo.TrimEnd();
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //�i��
            this.tEdit_GoodsName.DataText = goodsUnitData.GoodsName.TrimEnd();
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�R�[�h
            //this.CarrierCode_tNedit.SetInt(goodsUnitData.CarrierCode);
            ////�L�����A����
            //this.CarrierName_tEdit.DataText = goodsUnitData.CarrierName.TrimEnd();
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���[�J�[�R�[�h
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.MakerCode_tNedit.SetInt(goodsUnitData.MakerCode);
            this.MakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //���[�J�[����
            this.tEdit_MakerName.DataText = goodsUnitData.MakerName.TrimEnd();
            //���i�啪�ރR�[�h
            this.LgGoodsCode_tEdit.DataText = goodsUnitData.LargeGoodsGanreCode;
            //���i�啪�ޖ���
            this.LargeGoodsGanreName_tEdit.DataText = goodsUnitData.LargeGoodsGanreName.TrimEnd();
            //���i�����ރR�[�h
            this.MdGoodsCode_tEdit.DataText = goodsUnitData.MediumGoodsGanreCode;
            //���i�����ޖ���
            this.MediumGoodsGanreName_tEdit.DataText = goodsUnitData.MediumGoodsGanreName.TrimEnd();
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�@��R�[�h
            //this.CellphonModelCode_tEdit.DataText = goodsUnitData.CellphoneModelCode.TrimEnd();
            ////�@�햼��
            //this.CellphonModelName_tEdit.DataText = goodsUnitData.CellphoneModelName.TrimEnd();
            ////�n���F�R�[�h
            //this.SystematicColorCode_tNedit.SetInt(goodsUnitData.SystematicColorCd);
            ////�n���F����
            //this.SystematicColorName_tEdit.DataText= goodsUnitData.SystematicColorNm.TrimEnd();
            ////���ԊǗ��敪
            //this.PrdNumMngDiv_tNedit.SetInt(goodsUnitData.PrdNumMngDiv);
            //�O���[�v�R�[�h
            this.DtGoodsGanreCode_tEdit.DataText = goodsUnitData.DetailGoodsGanreCode;
            //�O���[�v�R�[�h����
            this.tEdit_BLGroupName.DataText = goodsUnitData.DetailGoodsGanreName.TrimEnd();
            //�a�k�i��
            this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode);
            //�a�k�i��
            this.tEdit_BLGoodsName.DataText = goodsUnitData.BLGoodsFullName.TrimEnd();
            //���Е��ރR�[�h
            this.tNedit_EnterpriseGanreCode.SetInt(goodsUnitData.EnterpriseGanreCode);
            //���Е��ޖ���
            this.EnterpriseGanreName_tEdit.DataText = goodsUnitData.EnterpriseGanreName.TrimEnd();
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //JAN�R�[�h
            this.tEdit_Jan.DataText = goodsUnitData.Jan.TrimEnd();
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ��ʓ��͐��䏈��

        ///// <summary>
        ///// ��ʓ��͐��䏈��
        ///// </summary>
        ///// <param name="flag"></param>
        ///// <remarks>
        ///// <br>Note       : ��ʓ��͐��䏈�����s���܂�</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.04.19</br>
        ///// </remarks>       
        //private void ScreeParmitionControl(bool flag)
        //{
        //    //����
        //    this.ProductNumber_tEdit.Enabled = flag;
        //    //�d�b�ԍ��P
        //    this.StockTelNo1_tEdit.Enabled = flag;
        //    //�d�b�ԍ��P
        //    this.StockTelNo2_tEdit.Enabled = flag;
        //}

        #endregion

        #region ���Ԋ֘A���N���A����

        ///// <summary>
        ///// ���Ԋ֘A���N���A����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ���Ԋ֘A�����N���A���܂�</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.04.23</br>
        ///// </remarks>       
        //private void ProductNumberClear()
        //{
        //    //����
        //    this.ProductNumber_tEdit.Clear();
        //    //�d�b�ԍ��P
        //    this.StockTelNo1_tEdit.Clear();
        //    //�d�b�ԍ��P
        //    this.StockTelNo2_tEdit.Clear();
        //}

        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        #endregion

        #region ��ʏ��i�[����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ��i�[����(���ʃN���X�����)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������ʃN���X�ɓW�J���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �V�K���͎��̍��ڎ擾���@��ύX����</br>
        /// <br>UpdateNote : 2011/01/30 ���N�n��</br>
        /// <br>             ��Q�� #18764</br>
        /// <br>UpdateNote : 2014/10/31 xuyb</br>
        /// <br>             Redmine#40336 ��Q���ۇA �������C�����ĐV�K�쐬����ƒI���f�[�^�D�I���݌Ɋz��0�ɂȂ�</br>
        /// </remarks>       
        private void SetInventResultWorkFromScreen()
        {
            switch(this._dispMode)
            {
                case (int)DispModeState.CreateNew:  // �V�K���[�h
                case (int)DispModeState.EditNew:    // �V�K���ҏW���[�h
                {   
                    
                    // ��ƃR�[�h
                    this._inventoryDataUpdateWorkAfter.EnterpriseCode = this._inventoryDataUpdateWorkBefore.EnterpriseCode;
                    // ���_�R�[�h
                    this._inventoryDataUpdateWorkAfter.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                    // �q�ɃR�[�h
                    this._inventoryDataUpdateWorkAfter.WarehouseCode = this.tEdit_WarehouseCode.DataText.TrimEnd();
                    // �i��
                    this._inventoryDataUpdateWorkAfter.GoodsNo = this.tEdit_GoodsNo.DataText.TrimEnd();
                    // �i��                                                                                         //ADD 2009/04/21 �s��Ή�[13075]
                    this._inventoryDataUpdateWorkAfter.GoodsName = this.tEdit_GoodsName.DataText.TrimEnd();         //ADD 2009/04/21 �s��Ή�[13075]
                    // �艿                                                                //ADD 2011/01/30
                    this._inventoryDataUpdateWorkAfter.ListPrice = this.ListPrice;         //ADD 2011/01/30
                    // ���[�J�[�R�[�h
                    this._inventoryDataUpdateWorkAfter.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                    // ���i�啪�ރR�[�h
                    this._inventoryDataUpdateWorkAfter.GoodsLGroup = this.tNedit_GoodsLGroup.GetInt();
                    // ���i�����ރR�[�h
                    this._inventoryDataUpdateWorkAfter.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                    // �O���[�v�R�[�h
                    this._inventoryDataUpdateWorkAfter.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
                    // �a�k�i��
                    this._inventoryDataUpdateWorkAfter.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                    // ���Е��ރR�[�h
                    this._inventoryDataUpdateWorkAfter.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                    // �d����R�[�h
                    this._inventoryDataUpdateWorkAfter.SupplierCd = this.tNedit_SupplierCd.GetInt();
                    // �I��
                    this._inventoryDataUpdateWorkAfter.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText.TrimEnd();
                    // �d���I��1
                    this._inventoryDataUpdateWorkAfter.DuplicationShelfNo1 = this.tEdit_DuplicationShelfNo1.DataText.TrimEnd();
                    // �d���I��2
                    this._inventoryDataUpdateWorkAfter.DuplicationShelfNo2 = this.tEdit_DuplicationShelfNo2.DataText.TrimEnd();
                    // JAN�R�[�h
                    this._inventoryDataUpdateWorkAfter.Jan = this.tEdit_Jan.DataText.TrimEnd();
                    // �d���P��
                    this._inventoryDataUpdateWorkAfter.StockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                    // �I���݌ɐ�
                    this._inventoryDataUpdateWorkAfter.InventoryStockCnt = this.tNedit_InventoryStockCnt.GetValue();
                    // �I���ߕs����(�I���݌ɐ��Ɠ������̂�Ԃ�)
                    this._inventoryDataUpdateWorkAfter.InventoryTolerancCnt = this.tNedit_InventoryStockCnt.GetValue();
                    // �I�����{��
                    this._inventoryDataUpdateWorkAfter.InventoryDay = this.EnforcementDay_tDateEdit.GetDateTime();
                    // �I����
                    this._inventoryDataUpdateWorkAfter.InventoryDate = this.InventoryDay_tDateEdit.GetDateTime();

                    if (this._dispMode == (int)DispModeState.CreateNew)
                    {
                        // �_���폜�敪(�V�K�Ȃ̂�0�Œ�)
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = 0;
                        // �ʔ�(0�Œ�)
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = 0;
                        // �ύX�O�d���P��
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        // �d���P���ύX�t���O(0:�����A1:�L��)
                        this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;
                        // �ŏI�d���N����
                        //this._inventoryDataUpdateWorkAfter.LastStockDate = DateTime.MinValue;                         //DEL 2009/05/14 �s��Ή�[13260]
                        this._inventoryDataUpdateWorkAfter.LastStockDate = this.LastStockDate_tDateEdit.GetDateTime();  //ADD 2009/05/14 �s��Ή�[13260]
                        // �݌ɋ敪
                        this._inventoryDataUpdateWorkAfter.StockDiv = this.tNedit_StockDiv.GetInt();                    //ADD 2009/05/14 �s��Ή�[13260]
                        // �݌ɑ���(0�Œ�)
                        //this._inventoryDataUpdateWorkAfter.StockTotal = 0D;                                           //DEL 2009/05/14 �s��Ή�[13260]
                        //this._inventoryDataUpdateWorkAfter.StockTotal = this.tNedit_InventoryStockCnt.GetValue();       //ADD 2009/05/14 �s��Ή�[13260] // 2009/10/08 DEL
                        //this._inventoryDataUpdateWorkAfter.StockTotal = 0;                                              // 2009/10/08 ADD  // DEL 2009/12/03
                        this._inventoryDataUpdateWorkAfter.StockTotal = this.tNedit_StockTotal.GetValue();   // ADD 2009/12/03
                        // �}�V���݌Ɋz
                        //this._inventoryDataUpdateWorkAfter.StockMashinePrice =
                        //    this._inventInputAcs.GetTotalPriceToLong(this.tNedit_InventoryStockCnt.GetValue(), this.tNedit_StockUnitPrice.GetValue());  //ADD 2009/05/14 �s��Ή�[13260] // DEL 2009/12/03
                        this._inventoryDataUpdateWorkAfter.StockMashinePrice =
                            this._inventInputAcs.GetTotalPriceToLong(this.tNedit_StockTotal.GetValue(), this.tNedit_StockUnitPrice.GetValue());  // ADD 2009/12/03
                        
                        // �I�������������t
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = DateTime.MinValue;
                        // �I��������������
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = 0;
                        // �I���X�V��
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = DateTime.MinValue;
                        // �I���V�K�ǉ��敪(0:�����쐬�A1:�V�K�쐬)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = 1;

                        // �����p�v�Z����
                        // ���I���݌Ɋz�Ɋւ��Ă̓}�V���݌Ɋz�Ɠ��l�̒l�ƂȂ邪�A�O���b�h�̒l�ݒ莞�C�x���g�ɂĎ擾���Ă���ׁA�����ɂ͏����Ȃ�
                        this._inventoryDataUpdateWorkAfter.AdjstCalcCost = this.tNedit_AdjustCalcCost.GetValue();       //ADD 2009/05/14 �s��Ή�[13260]
                    }
                    else
                    {
                        // �_���폜�敪
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = this._inventoryDataUpdateWorkBefore.LogicalDeleteCode;
                        // �ʔ�
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = this._inventoryDataUpdateWorkBefore.InventorySeqNo;
                        // �ύX�O�d���P��
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this._inventoryDataUpdateWorkBefore.StockUnitPriceFl;
                        // �d���P���ύX�t���O(0:�����A1:�L��)
                        if (this._inventoryDataUpdateWorkBefore.StockUnitPriceFl.Equals(this.tNedit_StockUnitPrice.GetValue()))
                        {
                            // �ύX����
                            // �܂��t���O�������Ă��Ȃ�
                            if (this._inventoryDataUpdateWorkBefore.StkUnitPriceChgFlg == 0)
                            {
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;
                            }
                            else
                            {
                                // �ύX�L��
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                            }
                        }
                        else
                        {
                            // �ύX�L��
                            this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                        }
                        // �ŏI�d���N����
                        this._inventoryDataUpdateWorkAfter.LastStockDate = this._inventoryDataUpdateWorkBefore.LastStockDate;
                        // �݌ɑ���(0�Œ�)
                        this._inventoryDataUpdateWorkAfter.StockTotal = this._inventoryDataUpdateWorkBefore.StockTotal;
                        // �I�������������t
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = this._inventoryDataUpdateWorkBefore.InventoryPreprDay;
                        // �I��������������
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = this._inventoryDataUpdateWorkBefore.InventoryPreprTim;
                        // �I���X�V��
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = this._inventoryDataUpdateWorkBefore.LastInventoryUpdate;
                        // �I���V�K�ǉ��敪(0:�����쐬�A1:�V�K�쐬)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = this._inventoryDataUpdateWorkBefore.InventoryNewDiv;
                    }
                    // �I���݌Ɋz
                    this._inventoryDataUpdateWorkAfter.InventoryStockPrice = this._inventInputAcs.GetTotalPriceToLong(this._inventoryDataUpdateWorkAfter.InventoryStockCnt, this._inventoryDataUpdateWorkAfter.StockUnitPriceFl); // ADD 2014/10/31 xuyb FOR Redmine#40336 ��Q���ۇA�Ή�
                    break;
                }
                case (int)DispModeState.EditOld:
                {
                    //�Q��
                    this._inventoryDataUpdateWorkAfter = this._inventoryDataUpdateWorkBefore;
                    break;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ��i�[����(���ʃN���X�����)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������ʃN���X�ɓW�J���܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>       
        private void SetInventResultWorkFromScreen()
        {
            switch (this._dispMode)
            {
                //�V�K���[�h
                case (int)DispModeState.CreateNew:
                    {
                        #region �V�K���[�h
                        //�_���폜�敪(�V�K�Ȃ̂�0�Œ�)
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = 0;
                        //��ƃR�[�h
                        this._inventoryDataUpdateWorkAfter.EnterpriseCode = this._inventoryDataUpdateWorkBefore.EnterpriseCode;
                        //���_�R�[�h
                        this._inventoryDataUpdateWorkAfter.SectionCode = this._inventoryDataUpdateWorkBefore.SectionCode;
                        //���_�K�C�h����
                        //                    this._inventoryDataUpdateWorkAfter.SectionGuideNm = this._inventoryDataUpdateWorkBefore.SectionGuideNm;
                        //�ʔ�(0�Œ�)
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = 0;
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////���ԍ݌Ƀ}�X�^Guid
                        //this._inventoryDataUpdateWorkAfter.ProductStockGuid = Guid.NewGuid();
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //�q�ɃR�[�h
                        this._inventoryDataUpdateWorkAfter.WarehouseCode = this.tEdit_WarehouseCode.DataText.TrimEnd();
                        //�q�ɖ���
                        this._inventoryDataUpdateWorkAfter.WarehouseName = this.tEdit_WarehouseName.DataText.TrimEnd();
                        //�i��
                        this._inventoryDataUpdateWorkAfter.GoodsNo = this.tEdit_GoodsNo.DataText.TrimEnd();
                        //�i��
                        this._inventoryDataUpdateWorkAfter.GoodsName = this.tEdit_GoodsName.DataText.TrimEnd();
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�L�����A�R�[�h
                        //this._inventoryDataUpdateWorkAfter.CarrierCode = this.CarrierCode_tNedit.GetInt();
                        ////�L�����A����
                        //this._inventoryDataUpdateWorkAfter.CarrierName = this.CarrierName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //���[�J�[�R�[�h
                        this._inventoryDataUpdateWorkAfter.GoodsMakerCd = this.MakerCode_tNedit.GetInt();
                        //���[�J�[����
                        this._inventoryDataUpdateWorkAfter.MakerName = this.tEdit_MakerName.DataText.TrimEnd();
                        //���i�啪�ރR�[�h
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreCode = this.LgGoodsCode_tEdit.DataText.TrimEnd();
                        //���i�啪�ޖ���
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreName = this.LargeGoodsGanreName_tEdit.DataText.TrimEnd();
                        //���i�����ރR�[�h
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreCode = this.MdGoodsCode_tEdit.DataText.TrimEnd();
                        //���i�����ޖ���
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreName = this.MediumGoodsGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�@��R�[�h
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelCode = this.CellphonModelCode_tEdit.DataText.TrimEnd();
                        ////�@�햼��
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelName = this.CellphonModelName_tEdit.DataText.TrimEnd();
                        ////�n���F�R�[�h
                        //this._inventoryDataUpdateWorkAfter.SystematicColorCd = this.SystematicColorCode_tNedit.GetInt();
                        ////�n���F����
                        //this._inventoryDataUpdateWorkAfter.SystematicColorNm = this.SystematicColorName_tEdit.DataText.TrimEnd();
                        ////���Ǝ҃R�[�h
                        //this._inventoryDataUpdateWorkAfter.CarrierEpCode = this.CarrierEpCode_tNedit.GetInt();
                        ////���ƎҖ���
                        //this._inventoryDataUpdateWorkAfter.CarrierEpName = this.CarrierEpName_tEdit.DataText.TrimEnd();
                        //�O���[�v�R�[�h
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreCode = this.DtGoodsGanreCode_tEdit.DataText.TrimEnd();
                        //�O���[�v�R�[�h����
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreName = this.tEdit_BLGroupName.DataText.TrimEnd();
                        //�a�k�i��
                        this._inventoryDataUpdateWorkAfter.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        //�a�k�i��
                        //this._inventoryDataUpdateWorkAfter.BLGoodsName = this.tEdit_BLGoodsName.DataText.TrimEnd();
                        //���Е��ރR�[�h
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        //���Е��ޖ���
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreName = this.EnterpriseGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        //���Ӑ�(�d����)�R�[�h
                        this._inventoryDataUpdateWorkAfter.CustomerCode = this.tNedit_SupplierCd.GetInt();
                        //���Ӑ�(�d����)���̂P
                        this._inventoryDataUpdateWorkAfter.CustomerName = this.tEdit_SupplierName.DataText.TrimEnd();
                        //���Ӑ�(�d����)���̂Q
                        this._inventoryDataUpdateWorkAfter.CustomerName2 = this.CustomerName2_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�d����
                        //this._inventoryDataUpdateWorkAfter.StockDate = this.StockDate_tDateEdit.GetDateTime();
                        ////���ד�
                        //this._inventoryDataUpdateWorkAfter.ArrivalGoodsDay = this.ArrivalGoodsDay_tDateEdit.GetDateTime();
                        ////�����ԍ�
                        //this._inventoryDataUpdateWorkAfter.ProductNumber = this.ProductNumber_tEdit.DataText.TrimEnd();
                        ////���i�d�b�ԍ�1
                        //this._inventoryDataUpdateWorkAfter.StockTelNo1 = this.StockTelNo1_tEdit.DataText.TrimEnd();
                        ////�ύX�O�d�b�ԍ�1
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo1 = this.StockTelNo1_tEdit.DataText.TrimEnd();
                        ////���i�d�b�ԍ�1�ύX�t���O(0:�����A1:�L��)
                        //this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 0;
                        ////���i�d�b�ԍ�2
                        //this._inventoryDataUpdateWorkAfter.StockTelNo2 = this.StockTelNo2_tEdit.DataText.TrimEnd();
                        ////�ύX�O�d�b�ԍ�2
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo2 = this.StockTelNo2_tEdit.DataText.TrimEnd();
                        ////���i�d�b�ԍ�2�ύX�t���O(0:�����A1:�L��)
                        //this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 0;
                        //�I��
                        this._inventoryDataUpdateWorkAfter.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText.TrimEnd();
                        //�d���I��1
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo1 = this.tEdit_DuplicationShelfNo1.DataText.TrimEnd();
                        //�d���I��2
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo2 = this.tEdit_DuplicationShelfNo2.DataText.TrimEnd();
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        //JAN�R�[�h
                        this._inventoryDataUpdateWorkAfter.Jan = this.tEdit_Jan.DataText.TrimEnd();
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�d���P��
                        //this._inventoryDataUpdateWorkAfter.StockUnitPrice = (long)this.tNedit_StockUnitPrice.GetValue();
                        ////�ύX�O�d���P��
                        //this._inventoryDataUpdateWorkAfter.BfStockUnitPrice = (long)this.tNedit_StockUnitPrice.GetValue();
                        //�d���P��
                        this._inventoryDataUpdateWorkAfter.StockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        //�ύX�O�d���P��
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        //�d���P���ύX�t���O(0:�����A1:�L��)
                        this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;

                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�݌ɋ敪
                        //switch(this.StockExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    //����
                        //    case 0:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 0;
                        //        break;                   
                        //    }
                        //    //���
                        //    case 1:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 10;
                        //        break;                   
                        //    }
                        //    //�ϑ�(����)
                        //    case 2:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;                   
                        //    }
                        //    //�ϑ�(���)
                        //    case 3:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;
                        //    }
                        //
                        //}
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�ړ����
                        //this._inventoryDataUpdateWorkAfter.MoveStatus = 0;
                        ////���i���
                        //this._inventoryDataUpdateWorkAfter.GoodsCodeStatus = 0;
                        ////���ԊǗ��敪
                        //this._inventoryDataUpdateWorkAfter.PrdNumMngDiv = this.PrdNumMngDiv_tNedit.GetInt();
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //�ŏI�d���N����
                        this._inventoryDataUpdateWorkAfter.LastStockDate = DateTime.MinValue;
                        //�݌ɑ���(0�Œ�)
                        this._inventoryDataUpdateWorkAfter.StockTotal = 0D;
                        //�o�א擾�Ӑ�(�ϑ���)�R�[�h
                        this._inventoryDataUpdateWorkAfter.ShipCustomerCode = this.ShipCustomerCode_tNedit.GetInt();
                        //�o�א擾�Ӑ�(�ϑ���)���̂P
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName = this.ShipCustomerName1_tEdit.DataText.TrimEnd();
                        //�o�א擾�Ӑ�(�ϑ���)���̂Q
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName2 = this.ShipCustomerName2_tEdit.DataText.TrimEnd();
                        //�I���݌ɐ�
                        this._inventoryDataUpdateWorkAfter.InventoryStockCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //�I���ߕs����(�I���݌ɐ��Ɠ������̂�Ԃ�)
                        this._inventoryDataUpdateWorkAfter.InventoryTolerancCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //�I�������������t
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = DateTime.MinValue;
                        //�I��������������
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = 0;
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�I�����{��
                        //this._inventoryDataUpdateWorkAfter.InventoryDay = this.InventoryDay_tDateEdit.GetDateTime();
                        //�I�����{��
                        this._inventoryDataUpdateWorkAfter.InventoryDay = this.EnforcementDay_tDateEdit.GetDateTime();
                        //�I����
                        this._inventoryDataUpdateWorkAfter.InventoryDate = this.InventoryDay_tDateEdit.GetDateTime();
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        //�I���X�V��
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = DateTime.MinValue;
                        //�I���V�K�ǉ��敪(0:�����쐬�A1:�V�K�쐬)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = 1;
                        #endregion
                        break;
                    }
                //�V�K���ҏW���[�h
                case (int)DispModeState.EditNew:
                    {
                        #region �V�K���ҏW���[�h
                        //�_���폜�敪
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = this._inventoryDataUpdateWorkBefore.LogicalDeleteCode;
                        //��ƃR�[�h
                        this._inventoryDataUpdateWorkAfter.EnterpriseCode = this._inventoryDataUpdateWorkBefore.EnterpriseCode;
                        //���_�R�[�h
                        this._inventoryDataUpdateWorkAfter.SectionCode = this._inventoryDataUpdateWorkBefore.SectionCode;
                        //���_�K�C�h����
                        //                    this._inventoryDataUpdateWorkAfter.SectionGuideNm = this._inventoryDataUpdateWorkBefore.SectionGuideNm;
                        //�ʔ�(0�Œ�)
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = this._inventoryDataUpdateWorkBefore.InventorySeqNo;
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////���ԍ݌Ƀ}�X�^Guid
                        //this._inventoryDataUpdateWorkAfter.ProductStockGuid = this._inventoryDataUpdateWorkBefore.ProductStockGuid;
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //�q�ɃR�[�h
                        this._inventoryDataUpdateWorkAfter.WarehouseCode = this.tEdit_WarehouseCode.DataText.TrimEnd();
                        //�q�ɖ���
                        this._inventoryDataUpdateWorkAfter.WarehouseName = this.tEdit_WarehouseName.DataText.TrimEnd();
                        //�i��
                        this._inventoryDataUpdateWorkAfter.GoodsNo = this.tEdit_GoodsNo.DataText.TrimEnd();
                        //�i��
                        this._inventoryDataUpdateWorkAfter.GoodsName = this.tEdit_GoodsName.DataText.TrimEnd();
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�L�����A�R�[�h
                        //this._inventoryDataUpdateWorkAfter.CarrierCode = this.CarrierCode_tNedit.GetInt();
                        ////�L�����A����
                        //this._inventoryDataUpdateWorkAfter.CarrierName = this.CarrierName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //���[�J�[�R�[�h
                        this._inventoryDataUpdateWorkAfter.GoodsMakerCd = this.MakerCode_tNedit.GetInt();
                        //���[�J�[����
                        this._inventoryDataUpdateWorkAfter.MakerName = this.tEdit_MakerName.DataText.TrimEnd();
                        //���i�啪�ރR�[�h
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreCode = this.LgGoodsCode_tEdit.DataText.TrimEnd();
                        //���i�啪�ޖ���
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreName = this.LargeGoodsGanreName_tEdit.DataText.TrimEnd();
                        //���i�����ރR�[�h
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreCode = this.MdGoodsCode_tEdit.DataText.TrimEnd();
                        //���i�����ޖ���
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreName = this.MediumGoodsGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�@��R�[�h
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelCode = this.CellphonModelCode_tEdit.DataText.TrimEnd();
                        ////�@�햼��
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelName = this.CellphonModelName_tEdit.DataText.TrimEnd();
                        ////�n���F�R�[�h
                        //this._inventoryDataUpdateWorkAfter.SystematicColorCd = this.SystematicColorCode_tNedit.GetInt();
                        ////�n���F����
                        //this._inventoryDataUpdateWorkAfter.SystematicColorNm = this.SystematicColorName_tEdit.DataText.TrimEnd();
                        ////���Ǝ҃R�[�h
                        //this._inventoryDataUpdateWorkAfter.CarrierEpCode = this.CarrierEpCode_tNedit.GetInt();
                        ////���ƎҖ���
                        //this._inventoryDataUpdateWorkAfter.CarrierEpName = this.CarrierEpName_tEdit.DataText.TrimEnd();
                        //�O���[�v�R�[�h
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreCode = this.DtGoodsGanreCode_tEdit.DataText.TrimEnd();
                        //�O���[�v�R�[�h����
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreName = this.tEdit_BLGroupName.DataText.TrimEnd();
                        //�a�k�i��
                        this._inventoryDataUpdateWorkAfter.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        //�a�k�i��
                        //this._inventoryDataUpdateWorkAfter.BLGoodsName = this.tEdit_BLGoodsName.DataText.TrimEnd();
                        //���Е��ރR�[�h
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        //���Е��ޖ���
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreName = this.EnterpriseGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        //���Ӑ�(�d����)�R�[�h
                        this._inventoryDataUpdateWorkAfter.CustomerCode = this.tNedit_SupplierCd.GetInt();
                        //���Ӑ�(�d����)���̂P
                        this._inventoryDataUpdateWorkAfter.CustomerName = this.tEdit_SupplierName.DataText.TrimEnd();
                        //���Ӑ�(�d����)���̂Q
                        this._inventoryDataUpdateWorkAfter.CustomerName2 = this.CustomerName2_tEdit.DataText.TrimEnd();
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�d����
                        //this._inventoryDataUpdateWorkAfter.StockDate = this.StockDate_tDateEdit.GetDateTime();
                        ////���ד�
                        //this._inventoryDataUpdateWorkAfter.ArrivalGoodsDay = this.ArrivalGoodsDay_tDateEdit.GetDateTime();
                        ////�����ԍ�
                        //this._inventoryDataUpdateWorkAfter.ProductNumber = this.ProductNumber_tEdit.DataText.TrimEnd();
                        ////���i�d�b�ԍ�1
                        //this._inventoryDataUpdateWorkAfter.StockTelNo1 = this.StockTelNo1_tEdit.DataText.TrimEnd();
                        ////�ύX�O�d�b�ԍ�1
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo1 = this._inventoryDataUpdateWorkBefore.StockTelNo1.TrimEnd();
                        ////���i�d�b�ԍ�1�ύX�t���O(0:�����A1:�L��)
                        //if(this._inventoryDataUpdateWorkBefore.StockTelNo1.Equals(this.StockTelNo1_tEdit.DataText.TrimEnd()))
                        //{
                        //    //�ύX����
                        //    //�܂��t���O�������Ă��Ȃ�
                        //    if(this._inventoryDataUpdateWorkBefore.StkTelNo1ChgFlg == 0)
                        //    {
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 0;
                        //    }
                        //    else
                        //    {
                        //        //�ύX�L��
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 1;
                        //    }
                        //}
                        //else
                        //{
                        //    //�ύX�L��
                        //    this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 1;
                        //}                               
                        ////���i�d�b�ԍ�2
                        //this._inventoryDataUpdateWorkAfter.StockTelNo2 = this.StockTelNo2_tEdit.DataText.TrimEnd();
                        ////�ύX�O�d�b�ԍ�2
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo2 = this._inventoryDataUpdateWorkBefore.StockTelNo1.TrimEnd();
                        ////���i�d�b�ԍ�2�ύX�t���O(0:�����A1:�L��)
                        //if(this._inventoryDataUpdateWorkBefore.StockTelNo2.Equals(this.StockTelNo2_tEdit.DataText.TrimEnd()))
                        //{
                        //    //�ύX����
                        //    //�܂��t���O�������Ă��Ȃ�
                        //    if(this._inventoryDataUpdateWorkBefore.StkTelNo2ChgFlg == 0)
                        //    {
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 0;
                        //    }
                        //    else
                        //    {
                        //        //�ύX�L��
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 1;
                        //    }
                        //    
                        //}
                        //else
                        //{
                        //    //�ύX�L��
                        //    this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 1;
                        //}                           
                        //�I��
                        this._inventoryDataUpdateWorkAfter.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText.TrimEnd();
                        //�d���I��1
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo1 = this.tEdit_DuplicationShelfNo1.DataText.TrimEnd();
                        //�d���I��2
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo2 = this.tEdit_DuplicationShelfNo2.DataText.TrimEnd();
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        //JAN�R�[�h
                        this._inventoryDataUpdateWorkAfter.Jan = this.tEdit_Jan.DataText.TrimEnd();
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�d���P��
                        //this._inventoryDataUpdateWorkAfter.StockUnitPrice = (long)this.tNedit_StockUnitPrice.GetValue();
                        ////�ύX�O�d���P��
                        //this._inventoryDataUpdateWorkAfter.BfStockUnitPrice = this._inventoryDataUpdateWorkBefore.StockUnitPrice;
                        ////�d���P���ύX�t���O(0:�����A1:�L��)
                        //if(this._inventoryDataUpdateWorkBefore.StockUnitPrice.Equals((long)this.tNedit_StockUnitPrice.GetValue()))
                        //�d���P��
                        this._inventoryDataUpdateWorkAfter.StockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        //�ύX�O�d���P��
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this._inventoryDataUpdateWorkBefore.StockUnitPriceFl;
                        //�d���P���ύX�t���O(0:�����A1:�L��)
                        if (this._inventoryDataUpdateWorkBefore.StockUnitPriceFl.Equals(this.tNedit_StockUnitPrice.GetValue()))
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        {
                            //�ύX����
                            //�܂��t���O�������Ă��Ȃ�
                            if (this._inventoryDataUpdateWorkBefore.StkUnitPriceChgFlg == 0)
                            {
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;
                            }
                            else
                            {
                                //�ύX�L��
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                            }
                        }
                        else
                        {
                            //�ύX�L��
                            this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                        }
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�݌ɋ敪
                        //switch(this.StockExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    //����
                        //    case 0:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 0;
                        //        break;                   
                        //    }
                        //    //���
                        //    case 1:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 10;
                        //        break;                   
                        //    }
                        //    //�ϑ�(����)
                        //    case 2:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;                   
                        //    }
                        //    //�ϑ�(���)
                        //    case 3:
                        //    {
                        //        //�݌ɋ敪
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //�݌ɏ��
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;                   
                        //    }
                        //}
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�ړ����
                        //this._inventoryDataUpdateWorkAfter.MoveStatus = this._inventoryDataUpdateWorkBefore.MoveStatus;
                        ////���i���
                        //this._inventoryDataUpdateWorkAfter.GoodsCodeStatus = this._inventoryDataUpdateWorkBefore.GoodsCodeStatus;
                        ////���ԊǗ��敪
                        //this._inventoryDataUpdateWorkAfter.PrdNumMngDiv = this.PrdNumMngDiv_tNedit.GetInt();
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //�ŏI�d���N����
                        this._inventoryDataUpdateWorkAfter.LastStockDate = this._inventoryDataUpdateWorkBefore.LastStockDate;
                        //�݌ɑ���(0�Œ�)
                        this._inventoryDataUpdateWorkAfter.StockTotal = this._inventoryDataUpdateWorkBefore.StockTotal;
                        //�o�א擾�Ӑ�(�ϑ���)�R�[�h
                        this._inventoryDataUpdateWorkAfter.ShipCustomerCode = this.ShipCustomerCode_tNedit.GetInt();
                        //�o�א擾�Ӑ�(�ϑ���)���̂P
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName = this.ShipCustomerName1_tEdit.DataText.TrimEnd();
                        //�o�א擾�Ӑ�(�ϑ���)���̂Q
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName2 = this.ShipCustomerName2_tEdit.DataText.TrimEnd();
                        //�I���݌ɐ�
                        this._inventoryDataUpdateWorkAfter.InventoryStockCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //�I���ߕs����(�I���݌ɐ��Ɠ������̂�Ԃ�)
                        this._inventoryDataUpdateWorkAfter.InventoryTolerancCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //�I�������������t
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = this._inventoryDataUpdateWorkBefore.InventoryPreprDay;
                        //�I��������������
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = this._inventoryDataUpdateWorkBefore.InventoryPreprTim;
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////�I�����{��
                        //this._inventoryDataUpdateWorkAfter.InventoryDay = this.InventoryDay_tDateEdit.GetDateTime();
                        //�I�����{��
                        this._inventoryDataUpdateWorkAfter.InventoryDay = this.EnforcementDay_tDateEdit.GetDateTime();
                        //�I����
                        this._inventoryDataUpdateWorkAfter.InventoryDate = this.InventoryDay_tDateEdit.GetDateTime();
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        //�I���X�V��
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = this._inventoryDataUpdateWorkBefore.LastInventoryUpdate;
                        //�I���V�K�ǉ��敪(0:�����쐬�A1:�V�K�쐬)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = this._inventoryDataUpdateWorkBefore.InventoryNewDiv;

                        #endregion
                        break;
                    }
                case (int)DispModeState.EditOld:
                    {
                        //�Q��
                        this._inventoryDataUpdateWorkAfter = this._inventoryDataUpdateWorkBefore;
                        break;
                    }
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɃR�����g�A�E�g

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �q�ɏ��擾����
        /// <summary>
        /// �q�ɏ��擾����
        /// </summary>
        /// <param name="code">�q�ɃR�[�h</param>
        /// <remarks>
        /// <br>Note       : �q�ɏ��̎擾���s���܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void GetWarehouseInfo(string code)
        {
            Warehouse warehouseData = null;
            //�q�ɏ��Read
            int status = this._warehouseGuideAcs.Read(out warehouseData,this._enterpriseCode,this._loginSectionCode,code);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
               //�������Ȃ�
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                //�R�[�h���̂��N���A
                this.tEdit_WarehouseCode.Clear();
                this.tEdit_WarehouseName.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�q�ɏ��̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

                //�R�[�h���̂��N���A
                this.tEdit_WarehouseCode.Clear();
                this.tEdit_WarehouseName.Clear();

				return;
			}

            if(warehouseData != null)
            {
                //�q�ɏ����Z�b�g
                this.tEdit_WarehouseCode.DataText = warehouseData.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseName.DataText = warehouseData.WarehouseName.TrimEnd();
            }
        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���Ǝҏ��擾����
		///// <summary>
		///// ���Ǝҏ��擾����
		///// </summary>
		///// <param name="code">���Ǝ҃R�[�h</param>
		///// <remarks>
		///// <br>Note       : ���Ǝҏ��̎擾���s���܂�</br>
		///// <br>Programmer : 23001 �����@�m</br>
		///// <br>Date       : 2007.04.19</br>
		///// </remarks>    
		//private void GetCarrierEpInfo(int code)
		//{
		//    CarrierEp carrierEp = null;
		//    //���Ǝҏ��Read
		//    int status = this._carrierEpAcs.Read(out carrierEp, this._enterpriseCode, code);
        //
		//    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//    {
		//       //�������Ȃ�
		//    }
		//    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
		//    {
		//        //�R�[�h���̂��N���A
		//        this.CarrierEpCode_tNedit.Clear();
		//        this.CarrierEpName_tEdit.Clear();
        //
		//        return;
		//    }
		//    else
		//    {
		//        TMsgDisp.Show(
		//            this,
		//            emErrorLevel.ERR_LEVEL_STOPDISP,
		//            this.Name,
		//            "���Ǝҏ��̎擾�Ɏ��s���܂����B",
		//            status,
		//            MessageBoxButtons.OK);
        //
		//        //�R�[�h���̂��N���A
		//        this.CarrierEpCode_tNedit.Clear();
		//        this.CarrierEpName_tEdit.Clear();
        //
		//        return;
		//    }
        //
		//    if(carrierEp != null)
		//    {
		//        //�q�ɏ����Z�b�g
		//        this.CarrierEpCode_tNedit.SetInt(carrierEp.CarrierEpCode);
		//        this.CarrierEpName_tEdit.DataText = carrierEp.CarrierEpName.TrimEnd();
		//    }
		//}
        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ���i���擾����

        /// <summary>
        /// ���i���擾����
        /// </summary>
        /// <param name="code">���Ǝ҃R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���i����̎擾���s���܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void GetGoodsInfo(string code)
        {
            string msg ="";
            List<GoodsUnitData> goodsUnitDataList = null;
            //�q�ɏ��Read
            int status = this._goodsGuide.ReadGoods(this,false,this._enterpriseCode,0,code,out goodsUnitDataList,out msg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
               //�������Ȃ�
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                //���i�ɕR�t���R�[�h�A���̂��N���A
                GoodsInfoClear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"���i���̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

                //���i�ɕR�t���R�[�h�A���̂��N���A
                GoodsInfoClear();
				return;
			}

            if(goodsUnitDataList != null)
            {
                //TODO:�v�ύX
                //�����i��(���[�J�[�Ⴂ)�����݂����ꍇ�ɂǂ��炩���I������
                //�����ʂ��K�v�B���̂Ƃ���Ȃ��̂ŁAList�̍ŏ��̏��i��߂��B
                GoodsUnitData goods = goodsUnitDataList[0];

                //���i�ɕR�t���R�[�h�A���̂��Z�b�g
                SetGoodsUnitForScreen(goods);
               
            }
        }

        #endregion
        
        #region �d������擾����

        /// <summary>
        /// �d������擾����
        /// </summary>
        /// <param name="code">���Ӑ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �d������̎擾���s���܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>   
        private void GetCustomerInfo(int code)
        {
            CustomerInfo customerInfo;
			CustSuppli custSuppli;

            //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
			int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo, out custSuppli);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //TODO:�K�v���H�H
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I�������d����͎d��������͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status,
                        MessageBoxButtons.OK);

                    //��ʏ����N���A
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierName.Clear();
                    this.CustomerName2_tEdit.Clear();

                    return;
                }
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I�������d����͊��ɍ폜����Ă��܂��B",
					status,
					MessageBoxButtons.OK);

                //��ʏ����N���A
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"�d������̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

                //��ʏ����N���A
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}

            if(customerInfo != null)
            {
                //���Ӑ�(�d����)�R�[�h���Z�b�g          
                this.tNedit_SupplierCd.SetInt(customerInfo.CustomerCode);
                this.tEdit_SupplierName.DataText = customerInfo.Name.TrimEnd();
                this.CustomerName2_tEdit.DataText = customerInfo.Name2.TrimEnd();
            }
			
        }      

        #endregion

        #region �ϑ�����擾����
        /// <summary>
        /// �ϑ�����擾����
        /// </summary>
        /// <param name="code">���Ӑ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �ϑ�����̎擾���s���܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>   
        private void GetShipCustomerInfo(int code)
        {
            CustomerInfo customerInfo;
			
            //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo);
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{             
                //�Ȃɂ����Ȃ�             
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
					status,
					MessageBoxButtons.OK);

                //�N���A
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"���Ӑ���̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

                //�N���A
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}

            if(customerInfo != null)
            {
                //�ϑ���              
                this.ShipCustomerCode_tNedit.SetInt(customerInfo.CustomerCode);
                this.ShipCustomerName1_tEdit.DataText = customerInfo.Name.TrimEnd();
                this.ShipCustomerName2_tEdit.DataText = customerInfo.Name2.TrimEnd();
            }

        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region ��ʓ��̓`�F�b�N
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʕK�{���ړ��̓`�F�b�N
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        /// <remarks>
        /// <br>Note       : �K�{���̓`�F�b�N���s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 ���N�n��</br>
        /// <br>             ���i�}�X�^�ɑ��݂��Ȃ��f�[�^���V�K�o�^�o����s��C��</br>
        /// <br>UpdateNote : 2011/02/10 ���N�n��</br>
        /// <br>             ��Q�� #18869</br>
        /// </remarks> 
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // �q��
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                control = this.tEdit_WarehouseCode;
                message = "�q�ɃR�[�h����͂��ĉ������B";
                return (false);
            }
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            if (this._inventInputAcs.GetWarehouseName(warehouseCode) == "")
            {
                control = this.tEdit_WarehouseCode;
                message = "�}�X�^�ɓo�^����Ă��܂���B";
                return (false);
            }

            // ���i
            if (this.tEdit_GoodsNo.DataText.Trim() == "")
            {
                control = this.tEdit_GoodsNo;
                message = "�i�Ԃ���͂��ĉ������B";
                return (false);
            }

            //���[�J�[
            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                control = this.tEdit_GoodsNo;
                //message = "�}�X�^�ɓo�^����Ă��܂���B";// DEL 2011/01/11
                message = "���i�}�X�^�ɓo�^����Ă��܂���B";// ADD 2011/01/11
                return (false);
            }

            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
            int makerCode = this.tNedit_GoodsMakerCd.GetInt();

         
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = makerCode;
            goodsCndtn.GoodsNo = goodsNo;
            
            List<GoodsUnitData> goodsUnitDataList;
            string msg;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg);//DEL 2011/01/11 // ADD 2011/02/10
            //int status = this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out msg);//ADD 2011/01/11 // DEL 2011/02/10
            //---ADD 2011/02/10----------------------------------->>>>>
            if (status == 0 && goodsUnitDataList[0].OfferKubun >= 3)
            {
                    status = -1;
            }
            //---ADD 2011/02/10-----------------------------------<<<<<
            if (status != 0 ) 
            {
                control = this.tEdit_GoodsNo;
                //message = "�}�X�^�ɓo�^����Ă��܂���B";// DEL 2011/01/11
                message = "���i�}�X�^�ɓo�^����Ă��܂���B";// ADD 2011/01/11

                // ���i�֘A��񏉊���
                ClearGoodsInfo();
                
                return (false);
            }

            // �I�����{��
            if (IsErrorTDateEdit(this.EnforcementDay_tDateEdit, out message) == false)
            {
                control = this.EnforcementDay_tDateEdit;
                return (false);
            }

            // �I����
            if (this.tNedit_InventoryStockCnt.GetValue() == 0.00)
            {
                control = this.tNedit_InventoryStockCnt;
                message = "�I��������͂��ĉ������B";
                return (false);
            }

            // �I����
            if (IsErrorTDateEdit(this.InventoryDay_tDateEdit, out message) == false)
            {
                control = this.InventoryDay_tDateEdit;
                return (false);
            }

            this._inventInputAcs.SearchAll(out this._inventoryDataUpdateWorkList, this._enterpriseCode, this._inventoryDataUpdateWorkBefore.InventoryDate);
            bool exist = this._inventoryDataUpdateWorkList.Exists(delegate(InventoryDataUpdateWork target)
            {
                if ((target.GoodsMakerCd == this.tNedit_GoodsMakerCd.GetInt()) &&
                    (target.GoodsNo.Trim() == this.tEdit_GoodsNo.DataText.Trim()) &&
                    (target.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (exist)
            {
                control = this.tEdit_WarehouseCode;
                message = "�I���f�[�^���d�����Ă܂��B";
                return (false);
            }

            return (true);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʕK�{���ړ��̓`�F�b�N
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        /// <remarks>
        /// <br>Note       : �K�{���̓`�F�b�N���s���܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks> 
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            //�K�{���ڃ`�F�b�N
            //�q��
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                control = this.tEdit_WarehouseCode;
                message = this.Warehouse_Title.Text + "����͂��ĉ������B";
                result = false;
                return result;
            }
            //���Ǝ�
            //if (this.CarrierEpCode_tNedit.GetInt() == 0)
            //{
            //    control = this.CarrierEpCode_tNedit;
            //    message = this.CarrierEp_Title.Text + "����͂��ĉ������B";
            //    result = false;
            //    return result;
            //}
            //���i
            if (this.tEdit_GoodsNo.DataText.Trim() == "")
            {
                control = this.tEdit_GoodsNo;
                message = this.Goods_Title.Text + "����͂��ĉ������B";
                result = false;
                return result;
            }
            //�d����
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                control = this.tNedit_SupplierCd;
                message = this.CustomerCode_Title.Text + "����͂��ĉ������B";
                result = false;
                return result;
            }

            //�ϑ���
            //�ϑ��݌ɂ̎�
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (this.StockExtraDiv_ultraOptionSet.CheckedIndex == 2 || this.StockExtraDiv_ultraOptionSet.CheckedIndex == 3)
            //{
            //    //�ϑ���(�K�{����Ȃ��C������)
            //    if (this.ShipCustomerCode_tNedit.GetInt() == 0)
            //    {
            //        control = this.ShipCustomerCode_tNedit;
            //        message = this.ShipCustomer_Title.Text + "����͂��ĉ������B";
            //        result = false;
            //        return result;
            //    }
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //�݌ɒI����
            if (this.tNedit_InventoryStockCnt.GetValue() == 0.00)
            {
                control = this.tNedit_InventoryStockCnt;
                message = this.InventoryStockCnt_Title.Text + "����͂��ĉ������B";
                result = false;
                return result;
            }

            //���t�̑Ó����`�F�b�N
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�d����
            //result = IsErrorTDateEdit(this.StockDate_tDateEdit,true);
            //if(result == false)
            //{
            //    control = this.StockDate_tDateEdit;
            //    message = "���t�̓��͂Ɍ�肪����܂��B";
            //    return result;
            //}
            ////���ד�
            //result = IsErrorTDateEdit(this.ArrivalGoodsDay_tDateEdit,true);
            //if(result == false)
            //{
            //    control = this.ArrivalGoodsDay_tDateEdit;
            //    message = "���t�̓��͂Ɍ�肪����܂��B";
            //    return result;
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //�I����
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //result = IsErrorTDateEdit(this.InventoryDay_tDateEdit, true);
            result = IsErrorTDateEdit(this.InventoryDay_tDateEdit, false);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            if (result == false)
            {
                control = this.InventoryDay_tDateEdit;
                message = "���t�̓��͂Ɍ�肪����܂��B";
                return result;
            }

            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //�I�����{��
            result = IsErrorTDateEdit(this.EnforcementDay_tDateEdit, false);
            if (result == false)
            {
                control = this.EnforcementDay_tDateEdit;
                message = "���t�̓��͂Ɍ�肪����܂��B";
                return result;
            }
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            return result;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region ���t���̓`�F�b�N����

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="canEmpty">�����̓t���O(true:�����͉�,false:�����͕s��)</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool canEmpty)
        {
            if (tDateEdit.CheckInputData() != null) return false;

            // ���t�𐔒l�^�Ŏ擾
            int date = tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // �����̓t���O�`�F�b�N
            if (canEmpty)
            {
                // �����͉Ŗ����͂̏ꍇ�͐���
                if (date == 0) return true;
            }

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if ((yy > 0) && (yy < 1900)) return false;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (tDateEdit.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    {
                        if (yy == 0 || mm == 0 || dd == 0) return false;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date);
                        if (TDateTime.IsAvailableDate(dt) == false) return false;
                        break;
                    }
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    {
                        if (yy == 0 || mm == 0) return false;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
                        if (TDateTime.IsAvailableDate(dt) == false) return false;
                        break;
                    }
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    {
                        if (yy == 0) return false;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
                        break;
                    }
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    {
                        if (mm == 0 || dd == 0) return false;
                        break;
                    }
                // ��        �\����
                case emDateFormat.df2M:
                    {
                        if (mm == 0) return false;
                        break;
                    }
                // ��        �\����
                case emDateFormat.df2D:
                    {
                        if (dd == 0) return false;
                        break;
                    }
            }

            return true;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if ((year == 0) || (month == 0) || (day == 0))
            {
                errMsg = "���t���w�肵�Ă��������B";
                return (false);
            }

            if (year < 1900)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            return (true);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region ���i�֘A���N���A����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���i�֘A���N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�ɕR�t���R�[�h�A���̂��N���A���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void ClearGoodsInfo()
        {
            //���i�ɕR�t���R�[�h�A���̂��N���A
            this.tEdit_GoodsName.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierName.Clear();
            this.tNedit_GoodsLGroup.Clear();
            this.tEdit_GoodsLGroupName.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tEdit_GoodsMGroupName.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_BLGroupName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            this.tNedit_EnterpriseGanreCode.Clear();
            this.tEdit_Jan.Clear();
            this.tEdit_SupplierName1.Clear();
            this.tEdit_SupplierName2.Clear();
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���i�֘A���N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�ɕR�t���R�[�h�A���̂��N���A���܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.23</br>
        /// </remarks>
        private void GoodsInfoClear()
        {
            //���i�ɕR�t���R�[�h�A���̂��N���A
            this.tEdit_GoodsNo.Clear();
            this.tEdit_GoodsName.Clear();
            this.MakerCode_tNedit.Clear();
            this.tEdit_MakerName.Clear();
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.CarrierCode_tNedit.Clear();
            //this.CarrierName_tEdit.Clear();
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            this.LgGoodsCode_tEdit.Clear();
            this.LargeGoodsGanreName_tEdit.Clear();
            this.MdGoodsCode_tEdit.Clear();
            this.MediumGoodsGanreName_tEdit.Clear();
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.CellphonModelCode_tEdit.Clear();
            //this.CellphonModelName_tEdit.Clear();
            //this.SystematicColorCode_tNedit.Clear();
            //this.SystematicColorName_tEdit.Clear();
            this.DtGoodsGanreCode_tEdit.Clear();
            this.tEdit_BLGroupName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            this.tNedit_EnterpriseGanreCode.Clear();
            this.EnterpriseGanreName_tEdit.Clear();
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            this.tEdit_Jan.Clear();
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.PrdNumMngDiv_tNedit.Clear();
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #endregion

        #region Event

        #region FormLoad

        /// <summary>
        /// Form.Load �C�x���g (MAZAI05130UDA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������߂ĕ\������钼�O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void MAZAI05130UDA_Load(object sender, EventArgs e)
        {
			// ��ʃC���[�W����
            //this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            //this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            //�^�C�}�[ON
            this.Initial_Timer.Enabled = true;
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
            // �t�H�[�J�X�ݒ�
            this.tEdit_WarehouseCode.Focus();
            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        }

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region Initial_Timer_Tick
        /// <summary>
        /// Initial_Timer_Tick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���Ԃ̊Ԋu���o�߂������ɔ������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks> 
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            //�^�C�}�[OFF
            this.Initial_Timer.Enabled = false;

			#region // 2007.07.31 kubo del
			//// ��ʏ����ݒ菈��
			//ScreenInitialSetting();
			#endregion
		}

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �K�C�h�Ăяo���C�x���g

        #region �q�ɃK�C�h

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>UpdateNote : 2012/06/11 ������</br>
        /// <br>             Redmine#30238</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;

            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData,this._enterpriseCode,this._loginSectionCode);
            if(status == 0)
            {
                if(warehouseData != null)
                {
                    //�R�[�h�A���̂�W�J                                    
                    this.tEdit_WarehouseCode.DataText = warehouseData.WarehouseCode.TrimEnd();
                    this.tEdit_WarehouseName.DataText = warehouseData.WarehouseName.TrimEnd();

                    //-----ADD BY ������ on 2012/06/11 for Redmine#30238 ------>>>>>>
                    GoodsUnitData goodsUnitData;
                    string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
                    int  makerCode = this.tNedit_GoodsMakerCd.GetInt();
                    status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
                    if (status == 0)
                    {
                        // ���i�A���f�[�^��ʓW�J
                        SetGoodsUnitForScreen(goodsUnitData);
                    }
                    else
                    {
                        // ���i�֘A��񏉊���
                        ClearGoodsInfo();
                    }
                    //-----ADD BY ������ on 2012/06/11 for Redmine#30238 ------<<<<<<
                    // �t�H�[�J�X�ݒ�
                    this.tEdit_GoodsNo.Focus();
                }
            }
        }

        #endregion

        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region ���Ǝ҃K�C�h
        ///// <summary>
        ///// ���Ǝ҃K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���Ǝ҃K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>    
        //private void CarrierEpGuide_Button_Click(object sender, EventArgs e)
        //{
        //	if ( this._carrierEpAcs == null ) this._carrierEpAcs = new CarrierEpAcs();
        //
        //	CarrierEp carrierEp = null;
        //
        //	int status = this._carrierEpAcs.ExecuteGuid( this._enterpriseCode, out carrierEp );
        //
        //    switch(status)
        //    {
        //        //�擾
        //        case 0:
        //        {                  
        //            if(carrierEp != null)
        //            {
        //				this.CarrierEpCode_tNedit.SetInt( carrierEp.CarrierEpCode );
        //				this.CarrierEpName_tEdit.DataText = carrierEp.CarrierEpName.TrimEnd();
        //            }
        //            break;
        //        }
        //        //�L�����Z��
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }      
        //}
        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ���i�K�C�h

        /// <summary>
        /// ���i�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void GoodsGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsUnitData goodsUnitData = null;

            DialogResult ret = this._goodsGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

            if (ret == DialogResult.OK)
            {
                if (goodsUnitData != null)
                {
                    //���i�K�C�h���瓾��������ʂɓW�J
                    SetGoodsUnitForScreen(goodsUnitData);
                }
            }
        }

        #endregion

        #region �d����K�C�h

        /// <summary>
        /// �d����K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
        }

        #endregion

        #region �ϑ���K�C�h

        /// <summary>
        /// �ϑ���K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void ShipCustomerGuide_Button_Click(object sender, EventArgs e)
        {
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ShipCustomerSelect);
			customerSearchForm.ShowDialog(this);
        }        

        #endregion    

        #region �� ���l���̓`�F�b�N����
        /// <summary>
		/// ���l���̓`�F�b�N����
		/// </summary>
		/// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
		/// <param name="priod">�����_�ȉ�����</param>
		/// <param name="prevVal">���݂̕�����</param>
		/// <param name="key">���͂��ꂽ�L�[�l</param>
		/// <param name="selstart">�J�[�\���ʒu</param>
		/// <param name="sellength">�I�𕶎���</param>
		/// <param name="minusFlg">�}�C�i�X���͉H</param>
		/// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note       : ���l���̓`�F�b�N�����B</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks>
		public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(key) == true)
			{
				return true;
			}
			// ���l�ȊO�́A�m�f
			if (Char.IsNumber(key) == false)
			{
				return false;
			}

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string	_strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// �}�C�i�X�̃`�F�b�N
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// �L�[�������ꂽ���ʂ̕�����𐶐�����B
			_strResult = prevVal.Substring(0, selstart) 
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));

			// ���͒l�`�F�b�N
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (this._prdNumMngDiv == 1 && this._grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product)
            //{
			//	// ���ԊǗ�����Ő��Ԗ��f�[�^�̏ꍇ�͓��͂�1��0�̂�
			//	if ( ( key != '1' ) && ( key != '0' ) )
			//	{
			//		return false;
			//	}
			//	keta = 1;
			//}
			//else
			//{
            //    // ���ԊǗ����� or ���Ԗ����͂Ȃ���͐�������
			//	keta = 9;
			//}
            // ���ԊǗ����� or ���Ԗ����͂Ȃ���͐�������
            keta = 9;
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>

			// �����`�F�b�N�I
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// �����_�ȉ��̃`�F�b�N
			if (priod > 0)
			{
				// �����_�̈ʒu����
				int _pointPos = _strResult.IndexOf('.');

				// �������ɓ��͉\�Ȍ���������I
				int	_Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					// �������̌������v�Z
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region TEdit Leave�C�x���g
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// WarehouseCode_tEdit_Leave
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�G�f�B�b�g���A�N�e�B�u�łȂ��Ȃ������ɔ������܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void WarehouseCode_tEdit_Leave(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            //�q�ɂ̏ꍇ
            if(tEdit.Equals(this.tEdit_WarehouseCode))
            {
                // �R�[�h�Q��
			    if( this.tEdit_WarehouseCode.DataText.TrimEnd() == "" ) 
                {
                    //������
				    this.tEdit_WarehouseCode.Clear();
                    this.tEdit_WarehouseName.Clear();
			    }
			    else 
                {
				    if( this._changFlagWarehouse == true )
                    {
					    this._changFlagWarehouse = false;
					    //�q�ɏ��擾����
                        GetWarehouseInfo(this.tEdit_WarehouseCode.DataText.TrimEnd());
				    }
			    }
            }

            //���i�̏ꍇ
            if(tEdit.Equals(this.tEdit_GoodsNo))
            {
                // �R�[�h�Q��
			    if( this.tEdit_GoodsNo.DataText.TrimEnd() == "" ) 
                {
                    //������
                    //���i���N���A
				    GoodsInfoClear();
			    }
			    else 
                {
				    if( this._changFlagGoods == true )
                    {
					    this._changFlagGoods = false;
					    //���i���擾����
                        GetGoodsInfo(this.tEdit_GoodsNo.DataText.TrimEnd());
				    }
			    }
            }

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�����ԍ��̏ꍇ
            //if(tEdit.Equals(this.tEdit_WarehouseShelfNo))
            //{
            //    //�����ԍ��A���i�d�b�ԍ��P�A�Q���ǂ�����͂���Ă��Ȃ�
            //    if(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == "")
            //    {
            //        //�I���݌ɐ���Enable��True��
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //�����ԍ������͂���Ă���
            //        //�I���݌ɐ���Enable��false��
            //        this.tNedit_InventoryStockCnt.Enabled = false;
            //        //�I���݌ɐ���1�ɕύX
            //        this.tNedit_InventoryStockCnt.SetInt(1);
            //    }
            //}
            //
            ////���i�d�b�ԍ��P�̏ꍇ
            //if(tEdit.Equals(this.tEdit_DuplicationShelfNo1))
            //{
            //    //�����ԍ��A���i�d�b�ԍ��P�A�Q���ǂ�����͂���Ă��Ȃ�
            //    if(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == "")
            //    {
            //        //�����ԍ������͂���Ă��Ȃ�
            //        //�I���݌ɐ���Enable��True��
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //�����ԍ������͂���Ă���
            //        //�I���݌ɐ���Enable��false��
            //        this.tNedit_InventoryStockCnt.Enabled = false;
            //        //�I���݌ɐ���1�ɕύX
            //        this.tNedit_InventoryStockCnt.SetInt(1);
            //    }
            //}
            ////���i�d�b�ԍ��Q�̏ꍇ
            //if(tEdit.Equals(this.tEdit_DuplicationShelfNo2))
            //{
            //    //�����ԍ��A���i�d�b�ԍ��P�A�Q���ǂ�����͂���Ă��Ȃ�
            //    if(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == "")
            //    {
            //        //�����ԍ������͂���Ă��Ȃ�
            //        //�I���݌ɐ���Enable��True��
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //�����ԍ������͂���Ă���
            //        //�I���݌ɐ���Enable��false��
            //        this.tNedit_InventoryStockCnt.Enabled = false;
            //        //�I���݌ɐ���1�ɕύX
            //        this.tNedit_InventoryStockCnt.SetInt(1);
            //    }
            //}
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        }     

        #endregion

        #region TEdit Enter�C�x���g

        /// <summary>
        /// tEdit_WarehouseCode.Enter �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �q�ɃR�[�h�G�f�B�b�g�Ƀt�H�[�J�X���ڂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 23010 �����@�m</br>
        /// <br>Date        : 2007.04.19</br>
        /// </remarks>
        private void WarehouseCode_tEdit_Enter(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            //�q��
            if(tEdit.Equals(this.tEdit_WarehouseCode))
            {
                //�R�[�h�Q�Ɨp�t���O
                this._changFlagWarehouse = false;
            } 
            //���i�̏ꍇ
            if(tEdit.Equals(this.tEdit_GoodsNo))
            {
                //�R�[�h�Q�Ɨp�t���O
                this._changFlagGoods = false;
            } 
        }

        #endregion

        #region TEdit ValueChanged�C�x���g
        /// <summary>
        /// tEdit_WarehouseCode.ValueChanged �C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃e�L�X�g���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.06.06</br>
        /// </remarks>
        private void WarehouseCode_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            //�q��
            if(tEdit.Equals(this.tEdit_WarehouseCode))
            {
                //���[�U�[�̎�ɂ��ύX���ꂽ
                if (this.tEdit_WarehouseCode.Modified == true)
                {
                    this._changFlagWarehouse = true;
                }
            }
            //���i
            if(tEdit.Equals(this.tEdit_GoodsNo))
            {
                //���[�U�[�̎�ɂ��ύX���ꂽ
                if (this.tEdit_GoodsNo.Modified == true)
                {
                    this._changFlagGoods = true;
                }
            }
        }

        #endregion

        #region TNedit Leave�C�x���g

        /// <summary>
        /// CarrierEpCode_tNedit_Leave
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ǝ҃R�[�h�G�f�B�b�g���A�N�e�B�u�łȂ��Ȃ������ɔ������܂�</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void CarrierEpCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ҂̏ꍇ
            //if(tNedit.Equals(this.CarrierEpCode_tNedit))
            //{
            //    // �R�[�h�Q��
            //    if( this.CarrierEpCode_tNedit.GetInt() == 0) 
            //    {
            //        //������
            //        this.CarrierEpCode_tNedit.Clear();
            //        this.CarrierEpName_tEdit.Clear();
            //    }
            //    else 
            //    {
            //        if( this._changeFlagCarrierEp == true )
            //        {
            //            this._changeFlagCarrierEp = false;
            //            //���Ǝҏ��擾����
            //            GetCarrierEpInfo(this.CarrierEpCode_tNedit.GetInt());
            //        }
            //    }
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //���Ӑ�(�d����)�̏ꍇ
            if(tNedit.Equals(this.tNedit_SupplierCd))
            {            
                if(this.tNedit_SupplierCd.GetInt() == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierName.Clear();
                    this.CustomerName2_tEdit.Clear();
                }
                else
                {
                    if(this._changFlagCustomer == true)
                    {
                        this._changFlagCustomer = false;
                        //���Ӑ�(�d����)���擾����
                        GetCustomerInfo(this.tNedit_SupplierCd.GetInt());
                    }
                }
            }

            //�o�א擾�Ӑ�(�ϑ���)�̏ꍇ
            if(tNedit.Equals(this.ShipCustomerCode_tNedit))
            {            
                if(this.ShipCustomerCode_tNedit.GetInt() == 0)
                {
                    this.ShipCustomerCode_tNedit.Clear();
                    this.ShipCustomerName1_tEdit.Clear();
                    this.ShipCustomerName2_tEdit.Clear();
                }
                else
                {
                    if(this._changFlagShipCustomer == true)
                    {
                        this._changFlagShipCustomer = false;
                        //���Ӑ�(�d����)���擾����
                        GetShipCustomerInfo(this.ShipCustomerCode_tNedit.GetInt());
                    }
                }               
            }

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�I�����̏ꍇ
            //if(tNedit.Equals(this.tNedit_InventoryStockCnt))
            //{
            //    if(this.tNedit_InventoryStockCnt.GetInt() > 1)
            //    {
            //        //���ԂƓd�b�ԍ����N���A
            //        this.tEdit_WarehouseShelfNo.Clear();
            //        this.tEdit_DuplicationShelfNo1.Clear();
            //        this.tEdit_DuplicationShelfNo2.Clear();
            //    }
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        }

        #endregion

        #region TNedit Enter�C�x���g
        /// <summary>
        /// CarrierEpCode_tNedit Enter �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ǝ҃G�f�B�b�g�Ƀt�H�[�J�X���ڂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 23010 �����@�m</br>
        /// <br>Date        : 2007.04.19</br>
        /// </remarks>
        private void CarrierEpCode_tNedit_Enter(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ�
            //if(tNedit.Equals(this.CarrierEpCode_tNedit))
            //{            
            //    this._changeFlagCarrierEp = false;               
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���Ӑ�(�d����)�̏ꍇ
            if(tNedit.Equals(this.tNedit_SupplierCd))
            {            
                this._changFlagCustomer = false;               
            }
            //�o�א擾�Ӑ�(�ϑ���)�̏ꍇ
            if(tNedit.Equals(this.ShipCustomerCode_tNedit))
            {            
                this._changFlagShipCustomer = false;               
            }
        }
       
        #endregion    

        #region TNedit ValueChanged�C�x���g
        /// <summary>
        /// CarrierEpCode_tNedit_ValueChanged �C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃e�L�X�g���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        private void CarrierEpCode_tNedit_ValueChanged(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////���Ǝ�
            //if(tNedit.Equals(this.CarrierEpCode_tNedit))
            //{
            //    //���[�U�[�̎�ɂ��ύX���ꂽ
            //    if (this.CarrierEpCode_tNedit.Modified == true)
            //    {
            //        this._changeFlagCarrierEp = true;
            //    }
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //���Ӑ�(�d����)�̏ꍇ
            if(tNedit.Equals(this.tNedit_SupplierCd))
            {           
                //���[�U�[�̎�ɂ��ύX���ꂽ
                if (this.tNedit_SupplierCd.Modified == true)
                {
                    this._changFlagCustomer = true;
                }                         
            }
            //�o�א擾�Ӑ�(�ϑ���)�̏ꍇ
            if(tNedit.Equals(this.ShipCustomerCode_tNedit))
            {            
                //���[�U�[�̎�ɂ��ύX���ꂽ
                if (this.ShipCustomerCode_tNedit.Modified == true)
                {
                    this._changFlagShipCustomer = true;
                }                                          
            }
        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region Main_ToolbarsManager_ToolClick�C�x���g
        /// <summary>
        /// Main_ToolbarsManager_ToolClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Main_ToolbarsManager��Tool���N���b�N���ꂽ���ɔ������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// <br>UpdateNote : 2011/01/30 ���N�n��</br>
        /// <br>             ��Q�� #18764</br>
        /// </remarks> 
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
			{
                //�m��
				case "ctSAVE_BUTTONTOOLKEY":
				{	
					Control activeControl = this.ActiveControl;

					this.ActiveControl = null;

	                //��ʓ��̓`�F�b�N
				    Control control = null;
                    string message = null;
                    
                    if (!ScreenDataCheck(ref control, ref message))
                    {
                        //���b�Z�[�W
                        TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                        CT_CLASSID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message, 							// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                      
                        control.Focus();
                        return;
                    }

					// --- DEL 2011/02/17 ---------->>>>>
					////---ADD 2011/01/11-------------------------------------------->>>>>
					//GoodsUnitData goodsUnitData;
					//string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
					//int makerCode = 0;
					//int status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
					//if (status != 0)
					//{
					//    GoodsNoFlag = -1;
					//    //���b�Z�[�W
					//    TMsgDisp.Show(
					//    this, 								// �e�E�B���h�E�t�H�[��
					//    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					//    CT_CLASSID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
					//    "���i�}�X�^�ɓo�^����Ă��܂���B", 							// �\�����郁�b�Z�[�W
					//    0, 									// �X�e�[�^�X�l
					//    MessageBoxButtons.OK);				// �\������{�^��

					//    // ���i�֘A��񏉊���
					//    ClearGoodsInfo();
					//    return;
					//}
					////---ADD 2011/01/30-------------------------------------------->>>>>
					//switch (goodsUnitData.OfferKubun)
					//{
					//    case 0: // ���[�U�[�o�^
					//    case 1: // �񋟏����ҏW
					//    case 2: // �񋟗D�ǕҏW
					//        if (goodsUnitData.LogicalDeleteCode == 0)
					//        {
					//            if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
					//            {
					//                if (goodsUnitData.GoodsPriceList.Count > 0)
					//                {
					//                    GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(this.EnforcementDay_tDateEdit.GetDateTime(), goodsUnitData.GoodsPriceList);
					//                    if (goodsPrice != null)
					//                    {
					//                        this.ListPrice = goodsPrice.ListPrice;
					//                    }
					//                }
					//            }
					//        }
					//        break;
					//    default:
					//        break;
					//}
					////---ADD 2011/01/30--------------------------------------------<<<<<
					////---ADD 2011/01/11--------------------------------------------<<<<<
					// --- DEL 2011/02/17 ----------<<<<<

                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    ////�I���݌ɐ���1�ȏ�ŁA����or�g�єԍ�����ꂽ�܂܃}�E�X�Ŋm�����������
                    ////�������Ԃ̏��i���ł��Ă��܂��BLeave����肭����Ȃ��B
                    ////����ă`�F�b�N������
                    //if(this.tNedit_InventoryStockCnt.GetInt() > 1)
                    //{
                    //    //�����ԍ��A���i�d�b�ԍ��P�A�Q���ǂꂩ��ł������Ă���ꍇ
                    //    if(!(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == ""))
                    //    {
                    //        //�I������1�ɂ���
                    //        this.tNedit_InventoryStockCnt.SetInt(1);
                    //    }                     
                    //}
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>

                    //��ʏ����i�[����
                    SetInventResultWorkFromScreen();
					
					this.ActiveControl = activeControl;

					this.DialogResult = DialogResult.OK;

					break;
				}
                //�I��
				case "ctCLOSE_BUTTONTOOLKEY":
					{
						this.DialogResult = DialogResult.Cancel;						
						break;
					}			
			}

        }

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region StockExtraDiv_ultraOptionSet_ValueChanged�C�x���g
        /// <summary>
        /// StockExtraDiv_ultraOptionSet_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : StockExtraDiv_ultraOptionSet�̒l���ω��������ɔ������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks> 
        private void StockExtraDiv_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        {
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�݌ɋ敪���ϑ��ɂȂ鎞�͈ϑ����Edit��K�{���͐F�ɕς���
            //if(this.StockExtraDiv_ultraOptionSet.CheckedIndex == 2 || this.StockExtraDiv_ultraOptionSet.CheckedIndex == 3)
            //{
            //    this.ShipCustomerCode_tNedit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            //}
            //else
            //{
            //    this.ShipCustomerCode_tNedit.Appearance.BackColor = Color.White;
            //}
            //
            ////����݌ɂ̏ꍇ�͎d���P���̍��ڂ���͕s��
            //if(this.StockExtraDiv_ultraOptionSet.CheckedIndex == 1 || this.StockExtraDiv_ultraOptionSet.CheckedIndex == 3)
            //{
            //    this.tNedit_StockUnitPrice.Clear();
            //    this.tNedit_StockUnitPrice.Enabled = false;
            //}
            //else
            //{
            //    this.tNedit_StockUnitPrice.Enabled = true;
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        }

        #endregion

        #region InventoryStockCnt_tNedit_KeyPress�C�x���g
		/// <summary>
		/// InventoryStockCnt_tNedit_KeyPress
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : InventoryStockCnt_tNedit���t�H�[�J�X�������Ă��āA���[�U�[���L�[�������Ęb�����Ƃ��ɔ�������</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks> 
		private void InventoryStockCnt_tNedit_KeyPress ( object sender, KeyPressEventArgs e )
		{
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (this._prdNumMngDiv == 0)
			//	return;
			//if ( this._dispMode == (int)DispModeState.EditNew )
			//{
			//	string prevVal = tNedit_InventoryStockCnt.DataText.TrimEnd();
			//	int selStart = tNedit_InventoryStockCnt.SelectionStart;
			//	int selLength = tNedit_InventoryStockCnt.SelectionLength;
            //
			//	if (KeyPressCheck( 0, 0, prevVal, e.KeyChar, selStart, selLength, false ) == false)
			//	{
			//		e.Handled = true;
			//		return;
			//	}
			//}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���i�A���f�[�^�擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 ���N�n��</br>
        /// <br>             ���i�}�X�^�ɑ��݂��Ȃ��f�[�^���V�K�o�^�o����s��C��</br>
        /// <br>UpdateNote : 2011/02/10 ���N�n��</br>
        /// <br>             ��Q�� #18869</br>
        /// </remarks> 
        private int GetGoodsUnitData(out GoodsUnitData goodsUnitData, int makerCode, string goodsNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            goodsUnitData = new GoodsUnitData();

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = makerCode;
            goodsCndtn.GoodsNo = goodsNo;

            List<GoodsUnitData> goodsUnitDataList;

            string errMsg;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);//DEL 2011/01/11 // ADD 2011/02/10
                //status = this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);//ADD 2011/01/11 // DEL 2011/02/10
                //---ADD 2011/02/10----------------------------------->>>>>
                if (status == 0 && goodsUnitDataList[0].OfferKubun >= 3)
                {
                    status = -1;
                }
                //---ADD 2011/02/10-----------------------------------<<<<<
                if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    goodsUnitData = goodsUnitDataList[0];
                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);         
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    goodsUnitData = new GoodsUnitData();
                }
            }
            catch
            {
                goodsUnitData = new GoodsUnitData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X���ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 ���N�n��</br>
        /// <br>             ���i�}�X�^�ɑ��݂��Ȃ��f�[�^���V�K�o�^�o����s��C��</br>
        /// </remarks> 
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tEdit_WarehouseCode":
                        {
                            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
                            {
                                this.tEdit_WarehouseName.Clear();
                                // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------------->>>>>
                                //���_
                                this.tEdit_SectionCode.DataText = string.Empty;
                                this.tEdit_SectionName.DataText = string.Empty;
                                //�d����
                                this.tNedit_SupplierCd.SetInt(0);
                                this.tEdit_SupplierName.DataText = string.Empty;
                                this.beforeWarehouseCode = this.tEdit_WarehouseCode.DataText;
                                // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------<<<<<
                                return;
                            }

                            // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------------->>>>>
                            if (this.tEdit_WarehouseCode.DataText == this.beforeWarehouseCode)
                            {
                                return;
                            }
                            this.beforeWarehouseCode = this.tEdit_WarehouseCode.DataText;
                            // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------------<<<<<

                            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');

                            // �q�ɖ��̎擾
                            this.tEdit_WarehouseName.DataText = this._inventInputAcs.GetWarehouseName(warehouseCode);

                            // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------------->>>>>
                            GoodsUnitData goodsUnitData;
                            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
                            int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                            int status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
                            if (status == 0)
                            {
                                // ���i�A���f�[�^��ʓW�J
                                SetGoodsUnitForScreen(goodsUnitData);
                            }
                            else
                            {
                                // ���i�֘A��񏉊���
                                ClearGoodsInfo();
                            }
                            // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------------<<<<<

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    if (this.tEdit_WarehouseName.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                }
                            }

                            break;
                        }
                    case "tEdit_GoodsNo":
                        {
                            if (this.tEdit_GoodsNo.DataText.Trim() == "")
                            {
                                // ���i�֘A��񏉊���
                                ClearGoodsInfo();
                                this.beforeGoodsNo = this.tEdit_GoodsNo.DataText;       //ADD 2009/05/14 �s��Ή�[13260]
                                return;
                            }

                            // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------------->>>>>
                            //if (this.tEdit_GoodsNo.DataText == this.beforeGoodsNo) // DEL 2011/01/11
                            if (this.tEdit_GoodsNo.DataText == this.beforeGoodsNo && GoodsNoFlag == 0) // ADD 2011/01/11
                            {
                                return;
                            }
                            this.beforeGoodsNo = this.tEdit_GoodsNo.DataText;
                            // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------------<<<<<

                            GoodsUnitData goodsUnitData;
                            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
                            //int makerCode = this.tNedit_GoodsMakerCd.GetInt();        //DEL 2009/05/14 �s��Ή�[13260]
                            int makerCode = 0;

                            int status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
                            if (status == 0)
                            {
                                // ���i�A���f�[�^��ʓW�J
                                SetGoodsUnitForScreen(goodsUnitData);
                            }
                            else
                            {
                                
                                //---ADD 2011/01/11-------------------------------------------->>>>>
                                if (e.NextCtrl is Infragistics.Win.Misc.UltraButton || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TDateEdit)
                                {
                                    GoodsNoFlag = -1;
                                    //���b�Z�[�W
                                    TMsgDisp.Show(
                                    this, 								// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                                    CT_CLASSID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                    "���i�}�X�^�ɓo�^����Ă��܂���B", 							// �\�����郁�b�Z�[�W
                                    0, 									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				// �\������{�^��
                                    e.NextCtrl = tEdit_GoodsNo;
                                    //---ADD 2011/01/11--------------------------------------------<<<<<
                                    // ���i�֘A��񏉊���
                                    ClearGoodsInfo();
                                } // ADD 2011/01/11
                                return;
                            }

							//---ADD 2011/02/17-------------------------------------------->>>>>
							switch (goodsUnitData.OfferKubun)
							{
								case 0: // ���[�U�[�o�^
								case 1: // �񋟏����ҏW
								case 2: // �񋟗D�ǕҏW
									if (goodsUnitData.LogicalDeleteCode == 0)
									{
										if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
										{
											if (goodsUnitData.GoodsPriceList.Count > 0)
											{
												GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(this.EnforcementDay_tDateEdit.GetDateTime(), goodsUnitData.GoodsPriceList);
												if (goodsPrice != null)
												{
													this.ListPrice = goodsPrice.ListPrice;
												}
											}
										}
									}
									break;
								default:
									break;
							}
							//---ADD 2011/02/17--------------------------------------------<<<<<

                            break;
                        }
                    default:
                        break;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo.Text.Length - (this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_DuplicationShelfNo1_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_DuplicationShelfNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo1.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo1.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo1.Text.Length - (this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_DuplicationShelfNo2_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_DuplicationShelfNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo2.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo2.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo2.Text.Length - (this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion
    }
}
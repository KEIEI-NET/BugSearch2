//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �I������
// �v���O�����T�v   : �I�������� ���o���ʓ��͉�ʃN���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �� �� ��  2007/04/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �C �� ��  2007/07/19  �C�����e : ���o�A�ꊇ�ݒ�A�ۑ����̑��x����
//                                  Grid��UpdateData���\�b�h���g�p���Ȃ��悤�ɕύX
//                                  �e�[�u���̃v���C�}���L�[��ύX���̂ɔ����A�e�f�[�^�̌�����Find���\�b�h��p���čs���悤�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �C �� ��  2007/07/24  �C�����e : ���ԊǗ��f�[�^�̐��Ԗ��O���X�s���쐬���Ȃ��悤�ύX
//                                  �폜�@�\�ǉ��i�V�K�s�̂ݍ폜�\)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �C �� ��  2007/07/25  �C�����e : �ҏW�@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �C �� ��  2007/07/26  �C�����e : ���ԓ��͋@�\ �ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �C �� ��  2007/07/30  �C�����e : �S�Ă�DataView�̃t�B���^�����Ɂu�_���폜�敪=0�v��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007/09/11  �C�����e : DC.NS�Ή�
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
// �C �� ��  2009/04/21  �C�����e : �s��Ή�[13075]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/14  �C�����e : �s��Ή�[13260]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �C �� ��  2009/09/11  �C�����e : MANTIS�Ή�[13915]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/03  �C�����e : PM.NS�@�ێ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/01/30  �C�����e : ��Q�� #18764
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/02/10  �C�����e : ��Q�� #18870
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2011/04/07  �C�����e : Mantis.17206 ���됔�[���̍݌ɂɑ΂��ĒI�����[������͂���ƕۑ����Ɍx�����b�Z�[�W���\�������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangyi
// �� �� ��  2012/10/29  �C�����e : 2012/11/14�z�M�� #32868 No.1198 �I���\ �I������/�\�������Ⴄ
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00    �쐬�S�� : yangyi
// �C �� ��  2013/03/01     �C�����e : 20130326�z�M���̑Ή��ARedmine#34175
//                                     �I���Ɩ��̃T�[�o�[���׌y��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  1002677-00     �쐬�S�� : xuyb
// �C �� ��  2014/10/31     �C�����e : �d�|��2133 Redmine#40336
//                                     ��Q���ۇA �������C�����ĐV�K�쐬����ƒI���f�[�^�D�I���݌Ɋz��0�ɂȂ�
//                                     ��Q���ۇB �I�Ԃ�ύX����Ǝ��s�ȍ~�̓��͕����X�V����Ȃ���Q�C��
//                                    �u��Q���ۇA�v�̏C���Łu��Q���ۇB�v�̏�Q�������ł���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  1002677-00     �쐬�S�� : �e�c ���V
// �C �� ��  2014/12/04     �C�����e : �d�|��2133 Redmine#40336 �V�X�e���e�X�g��QNo.154
//                                     �X�V�G���[������ɊY���s�̕����̐F��ύX����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00     �쐬�S�� : ��
// �C �� ��  2015/04/27     �C�����e : Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ�����
//                                  �@�@Redmine#45747 �I�����͉�ʂ��~�{�^���ŕ���ۂɖ��ۑ��̓��̓f�[�^������ꍇ�͌x�����b�Z�[�W��\������
//----------------------------------------------------------------------------//
// �I���f�[�^�̍\��
// - ���ԊǗ� ���Ȃ��@
//		- �O���X�f�[�^(��ɕ\�� �I�������͉� �I�������ύX���ꂽ�琻�ԒP�ʃf�[�^�ɔ��f)
//		- ���ԒP�ʃf�[�^(��ɔ�\�� �I���}�X�^�ɓ����Ă���P�� �I�����͐e���甽�f����邱�ƂŕύX)
// - ���ԊǗ� ����
//		- �O���X�f�[�^(�\�����@:���i���̂Ƃ��\�� �I�������͉� �I�������ύX���ꂽ�琻�ԒP�ʃf�[�^�ɔ��f)
//		- ���ԒP�ʃf�[�^(�\�����@:���Ԗ��̂Ƃ��\�� �I�������͉� �ύX���ꂽ��O���X�f�[�^�ɔ��f)
#region // 2007.07.24 kubo del ( �f�[�^�\���̎d�l�ύX�ɔ����A���ԒP�ʃf�[�^�͏�ɑS�ĕ\�� )
//		- ���ԒP�ʃf�[�^
//			- ���ԓ��͍ς݃f�[�^(�\�����@:���Ԗ��̂Ƃ��\�� �I�������͉� �ύX���ꂽ��O���X�f�[�^�ɔ��f)
////			- ���Ԗ����̓f�[�^
////				- �O���X�f�[�^(�\�����@:���Ԗ��̂Ƃ��\�� �I�������͉� �ύX���ꂽ��e�f�[�^�Ɛ��Ԗ����� ���ԒP�ʃf�[�^�ɔ��f)
////				- ���ŒP�ʃf�[�^(��ɔ�\�� �I���}�X�^�ɓ����Ă���P�� �I�����͐e���甽�f����邱�ƂŕύX)
#endregion

using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using System.Globalization;  //ADD 2012/10/29 yangyi redmine #32868 

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �I�������� ���o���ʓ��͉�ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I�������� ���o���ʓ��͉�ʃN���X</br>
	/// <br>Programmer : 22013 kubo</br>
	/// <br>Date       : 2007.04.11</br>
	/// <br>Update Note: 2007.07.19 2007.07.20 22013 kubo</br>
	/// <br>			:	�E���o�A�ꊇ�ݒ�A�ۑ����̑��x����</br>
	/// <br>			:	�@�@Grid��UpdateData���\�b�h���g�p���Ȃ��悤�ɕύX</br>
	/// <br>			:	�@�@�e�[�u���̃v���C�}���L�[��ύX���̂ɔ����A�e�f�[�^�̌�����Find���\�b�h��p���čs���悤�ύX</br>
	/// <br>Update Note: 2007.07.24 22013 kubo</br>
	/// <br>			:	�E���ԊǗ��f�[�^�̐��Ԗ��O���X�s���쐬���Ȃ��悤�ύX</br>
	/// <br>			:	�E�폜�@�\�ǉ��i�V�K�s�̂ݍ폜�\)</br>
	/// <br>Update Note: 2007.07.25 22013 kubo</br>
	/// <br>			:	�E�ҏW�@�\�ǉ�</br>
	/// <br>Update Note: 2007.07.26,27 22013 kubo</br>
	/// <br>			:	�E���ԓ��͋@�\ �ǉ�</br>
	/// <br>Update Note: 2007.07.30 22013 kubo</br>
	/// <br>			:	�E�S�Ă�DataView�̃t�B���^�����Ɂu�_���폜�敪=0�v��ǉ�</br>
    /// <br>Update Note : 2007.09.11 980035 ���� ��`</br>
    /// <br>			    �EDC.NS�Ή�</br>
    /// <br>Update Note : 2008.02.14 980035 ���� ��`</br>
    /// <br>			    �E�I�����{���Ή��iDC.NS�Ή��j</br>
    /// <br>Update Note : 2008/09/01 30414 �E �K�j</br>
    /// <br>			    �EPartsman�p�ɕύX</br>
    /// <br>Update Note : 2009/04/13 30452 ��� �r��</br>
    /// <br>			    �E��Q�Ή�13109</br>
    /// <br>Update Note : 2009/04/21       �Ɠc �M�u</br>
    /// <br>			    �E�s��Ή�[13075]</br>
    /// <br>Update Note : 2009/05/14       �Ɠc �M�u</br>
    /// <br>			    �E�s��Ή�[13260]</br>
    /// <br>UpdateNote  : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
    /// <br>UpdateNote  : 2011/02/10 ���N�n��</br>
    /// <br>                �E��Q�� #18870</br>
    /// </remarks>
	public partial class MAZAI05130UB : Form, IInventInputMdiChild
	{
		#region �� Constructor
		/// <summary>
		/// �I�������� ���o���ʓ��͉�ʃN���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �I�������� ���o���ʓ��͉�ʃN���X�̃C���X�^���X���쐬</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public MAZAI05130UB ()
		{
			InitializeComponent();
			this._inventInputAcs = new InventInputAcs();		// �I�������̓A�N�Z�X�N���X

            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //this._inventoryMenuForm = new MAZAI05130UA();
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // �O���b�h�ݒ胍�[�h
			this._gridStateController = new GridStateController();
			this._gridStateController.LoadGridState(ct_FileName_ColDisplayStatus);
		}
		#endregion �� Constructor

		#region �� Private Member
		// IInventInputMdiChild �����o�p �ϐ� ---------------------------------------
		private string _enterpriseCode				= "";					// ��ƃR�[�h
		private string _sectionCode					= "";					// ���_�R�[�h
		private string _sectionName					= "";					// ���_����
		private bool _isCansel						= true;					// ����{�^��Enabled
		private bool _isSave						= true;					// �ۑ��{�^��Enabled
		private bool _isExtract						= false;				// ���o�{�^��Enabled
		private bool _isNewInvent					= true;					// �V�K�{�^��Enabled
		private bool _isDetail						= true;					// �ڍ׃{�^��Enabled
        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //private bool _isBarcodeRead               = true;					// �o�[�R�[�h�Ǎ��{�^��Enabled
        private bool _isBarcodeRead                 = false;				// �o�[�R�[�h�Ǎ��{�^��Enabled
        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
        // 2007.07.25 kubo add
		private bool _isDataEdit					= false;				// �ҏW�{�^��Enabled
        private bool _isGoodsSearch = true;	�@�@�@�@�@�@�@�@// �i�Ԍ����{�^��Enabled (true:�i�Ԍ����{�^���N���b�N���ł���@false:�i�Ԍ����{�^���N���b�N���ł��Ȃ�)// ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ�����

		// Private �ϐ� ---------------------------------------
		private bool _isFirstsetting				= true;					// �����������t���O
		private InventInputAcs _inventInputAcs		= new InventInputAcs();	// �I�������̓A�N�Z�X�N���X
		private bool _isEventAutoFillColumn			= true;					// ��T�C�Y�����C�x���g�\�t���O(T:��,F:�s��)
		private bool _isChangeInventStcCnt			= false;				// �I�����ύX�t���O
        private string _isDownKey = string.Empty;                           // �����L�[(�L�[��������F"ANYKEY"�A�L�[�����Ȃ��F"")           //ADD 2009/05/14 �s��Ή�[13260]
                                                                            // ������A�L�[���ɔ��肷��K�v�����������ׂ̈�string�Ƃ��Ă���
		private bool _isChangeInventDate			= false;				// ���t�ύX�t���O
		//private MAZAI05130UC _productInvInputForm	= null;					// ���Ԗ��I�������͉��
        // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private bool _isChangeWarehouseShelfNo      = false;				// �I�ԕύX�t���O
        private bool _isChangeDuplicationShelfNo1   = false;				// �d���I��1�ύX�t���O
        private bool _isChangeDuplicationShelfNo2   = false;				// �d���I��2�ύX�t���O
        // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
        // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private bool _isChangeStockUnitPrice        = false;				// ���P���ύX�t���O
        // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
        private bool _addingKey = true;					                    // �L�[�̒ǉ��t���O   //ADD yangyi 2013/03/01 Redmine#34175 

        private MAZAI05140UA _readBarcodeForm = null;					    // �o�[�R�[�h�Ǎ����
		private MAZAI05130UD _createNewInventForm	= null;					// �V�K���
        private MAZAI05130UE _goodsSearchForm = null;					    // �i�Ԍ��� // ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ�����
        // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
        //private MAZAI05130UA _inventoryMenuForm = null;                     // �������͉��;
        // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
	
		private GridStateController _gridStateController = null;			// �O���b�h�ݒ萧��N���X

		// ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 2007.07.19 kubo add 
		private DataView _inventInputView = null;							// �I��DataView

		// 2007.07.26 kubo add --------------->
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        //private bool _isChangeInventProductNum = false;				// �����ԍ��ύX�t���O
		//private bool _isChangeInventStockTelNo1		= false;				// �d�b�ԍ�1�ύX�t���O
		//private bool _isChangeInventStockTelNo2		= false;				// �d�b�ԍ�2�ύX�t���O
		//private string _BfoerStockTelNo1			= "";					// �ύX�O�d�b�ԍ�1
		//private string _BfoerStockTelNo2			= "";					// �ύX�O�d�b�ԍ�2
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

		private ProductNumInput _productNumInput	= null;

		private ArrayList _defProdNumList = new ArrayList();

        private InventInputSearchCndtn _extrInfo;

		private string _strNowSort = "";
		// 2007.07.26 kubo add <---------------
		#endregion �� Private Member

		#region �� Private Const
		/// <summary> ��\����ԃZ�b�e�B���OXML�t�@�C���� </summary>
		private const string ct_FileName_ColDisplayStatus =  "MAZAI05120U_ColSetting.DAT";

		/// <summary> �I�����ꊇ���̓R���e�i </summary>
		private const string ct_tool_InventoryAllInput = "tool_InventAllInput";

		/// <summary> �I�����{���R���e�i </summary>
		private const string ct_tool_InventoryDate = "tool_InventoryDate";

        // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
		/// <summary> �I�����R���e�i </summary>
		private const string ct_tool_InventoryExeDate = "tool_InventoryExeDate";
        // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

        /// <summary> �\�����@�c�[���R���e�i </summary>
		private const string ct_tool_ViewStyleContainer = "tool_ViewStyleContainer";

		/// <summary> �\�[�g���c�[���R���e�i </summary>
		private const string ct_tool_SortOrderContainer = "tool_SortOrderContainer";

		// 2007.07.24 kubo add
		/// <summary> �\�[�g���c�[���R���e�i </summary>
		private const string ct_tool_RowDelete = "tool_RowDelete";

        #region DEL 2009/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		// ��\���ؑ֗p�c�[��
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> �d�b�ԍ�1 </summary>
		//private const string ct_tool_Hidden_TEL1 = InventInputResult.ct_Col_StockTelNo1;
		///// <summary> �d�b�ԍ�2 </summary>
		//private const string ct_tool_Hidden_TEL2 = InventInputResult.ct_Col_StockTelNo2;
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary> �q�� </summary>
		private const string ct_tool_Hidden_Warehouse = InventInputResult.ct_Col_WarehouseName;
        // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
		private const string ct_tool_Hidden_WarehouseShelfNo = InventInputResult.ct_Col_WarehouseShelfNo;
		private const string ct_tool_Hidden_DuplicationShelfNo1 = InventInputResult.ct_Col_DuplicationShelfNo1;
		private const string ct_tool_Hidden_DuplicationShelfNo2 = InventInputResult.ct_Col_DuplicationShelfNo2;
        // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
		/// <summary> ���[�J�[ </summary>
		private const string ct_tool_Hidden_Maker = InventInputResult.ct_Col_MakerName;
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> ���Ǝ� </summary>
		//private const string ct_tool_Hidden_CarrierEp = InventInputResult.ct_Col_CarrierEpName;
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary> �d���� </summary>
        private const string ct_tool_Hidden_Customer = InventInputResult.ct_Col_CustomerName;
        /// <summary> �ϑ��� </summary>
		private const string ct_tool_Hidden_ShipCustomer = InventInputResult.ct_Col_ShipCustomerName;
        /// <summary> �݌ɋ敪 </summary>
		private const string ct_tool_Hidden_StockTrtEntDiv = InventInputResult.ct_Col_StockTrtEntDivName;
		/// <summary> �����\����� </summary>
		private const string ct_tool_Hidden_Initialize = "tool_Hidden_Initialize";
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2009/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        //----------------------
        // ��\���ؑ֗p�c�[��
        //----------------------
        /// <summary> �q�� </summary>
        private const string ct_tool_Hidden_Warehouse = InventInputResult.ct_Col_WarehouseName;
        /// <summary> �I�� </summary>
        private const string ct_tool_Hidden_WarehouseShelfNo = InventInputResult.ct_Col_WarehouseShelfNo;
        /// <summary> �d���I��1 </summary>
        private const string ct_tool_Hidden_DuplicationShelfNo1 = InventInputResult.ct_Col_DuplicationShelfNo1;
        /// <summary> �d���I��2 </summary>
        private const string ct_tool_Hidden_DuplicationShelfNo2 = InventInputResult.ct_Col_DuplicationShelfNo2;
        /// <summary> ���[�J�[ </summary>
        private const string ct_tool_Hidden_Maker = InventInputResult.ct_Col_MakerName;
        /// <summary> �d���� </summary>
        private const string ct_tool_Hidden_Supplier = InventInputResult.ct_Col_SupplierName;
        /// <summary> �݌ɋ敪 </summary>
        private const string ct_tool_Hidden_StockTrtEntDiv = InventInputResult.ct_Col_StockTrtEntDivName;
        /// <summary> �����\����� </summary>
        private const string ct_tool_Hidden_Initialize = "tool_Hidden_Initialize";
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		#region // 2007.07.25 kubo del
		///// <summary> �\�[�g��(�q��-���i-����) </summary>
		//private const string ct_SortOrder_Goods = 
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_MakerCode + "," +
		//    InventInputResult.ct_Col_GoodsCode			+ "," + InventInputResult.ct_Col_StockTrtEntDiv + "," +
		//    InventInputResult.ct_Col_StockUnitPrice		+ "," + InventInputResult.ct_Col_CustomerCode + "," +
		//    InventInputResult.ct_Col_ShipCustomerCode	+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_ProductNumber;
		///// <summary> �\�[�g��(�q��-���Ǝ�-����) </summary>
		//private const string ct_SortOrder_CarrierEp = 
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_MakerCode			+ "," + InventInputResult.ct_Col_GoodsCode + "," + 
		//    InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
		//    InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode	+ "," +
		//    InventInputResult.ct_Col_ProductNumber;
		///// <summary> �\�[�g��(�q��-�d����-���i-����) </summary>
		//private const string ct_SortOrder_Customer =
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CustomerCode + "," +
		//    InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
		//    InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
		//    InventInputResult.ct_Col_ShipCustomerCode	+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_ProductNumber;
		///// <summary> �\�[�g��(�q��-�ϑ���-���i-����) </summary>
		//private const string ct_SortOrder_ShipCustomer = 
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode + "," +
		//    InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
		//    InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
		//    InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_ProductNumber;
		#endregion
        
        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
        
        #region // 2007.09.11 �폜
        //// 2007.07.27 kubo add (�V�K�敪���\�[�g���ɒǉ�)------------------->
		///// <summary> �\�[�g��(�q��-���i-����) </summary>
        //private const string ct_SortOrder_Goods =
        //    InventInputResult.ct_Col_WarehouseCode      + "," + InventInputResult.ct_Col_MakerCode + "," +
        //    InventInputResult.ct_Col_GoodsCode          + "," + InventInputResult.ct_Col_StockTrtEntDiv + "," +
        //    InventInputResult.ct_Col_StockUnitPrice     + "," + InventInputResult.ct_Col_CustomerCode + "," +
        //    InventInputResult.ct_Col_ShipCustomerCode   + "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //    InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;
        ///// <summary> �\�[�g��(�q��-���Ǝ�-����) </summary>
        //private const string ct_SortOrder_CarrierEp = 
        //	InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //	InventInputResult.ct_Col_MakerCode			+ "," + InventInputResult.ct_Col_GoodsCode + "," + 
        //	InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
        //	InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode	+ "," +
        //	InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;
        ///// <summary> �\�[�g��(�q��-�d����-���i-����) </summary>
        //private const string ct_SortOrder_Customer =
        //	InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CustomerCode + "," +
        //	InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
        //	InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
        //	InventInputResult.ct_Col_ShipCustomerCode	+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //	InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;
        ///// <summary> �\�[�g��(�q��-�ϑ���-���i-����) </summary>
        //private const string ct_SortOrder_ShipCustomer = 
        //	InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode + "," +
        //	InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
        //	InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
        //	InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //	InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;

        // 2007.07.27 kubo add ------------------->
        #endregion

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary> �\�[�g��(�q�Ɂ��I��) </summary>
        private const string ct_SortOrder_ShelfNo =
            //InventInputResult.ct_Col_WarehouseCode + "," + ct_Col_WarehouseShelfNo + "," +
            //InventInputResult.ct_Col_MakerCode + "," + InventInputResult.ct_Col_GoodsNo;
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo;
        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
        private const string ct_SortOrder_GoodsDiv =
            InventInputResult.ct_Col_WarehouseCode        + "," + InventInputResult.ct_Col_WarehouseShelfNo     + "," +
            InventInputResult.ct_Col_MakerCode            + "," + InventInputResult.ct_Col_LargeGoodsGanreCode  + "," +
            InventInputResult.ct_Col_MediumGoodsGanreCode + "," + InventInputResult.ct_Col_DetailGoodsGanreCode + "," +
            InventInputResult.ct_Col_GoodsNo;
        private const string ct_SortOrder_Goods =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo + "," +
            InventInputResult.ct_Col_MakerCode     + "," + InventInputResult.ct_Col_GoodsNo;
        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary> �\�[�g��(�q�Ɂ��d����) </summary>
        private const string ct_SortOrder_Customer =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_CustomerCode;
        /// <summary> �\�[�g��(�q�Ɂ��a�k�R�[�h) </summary>
        private const string ct_SortOrder_BLGoods =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGoodsCode;
        /// <summary> �\�[�g��(�q�Ɂ����[�J�[) </summary>
        private const string ct_SortOrder_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode;
        /// <summary> �\�[�g��(�q�Ɂ��d���恨�I��) </summary>
        private const string ct_SortOrder_Cus_ShelfNo =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_CustomerCode + "," +
            InventInputResult.ct_Col_WarehouseShelfNo;
        /// <summary> �\�[�g��(�q�Ɂ��d���恨���[�J�[) </summary>
        private const string ct_SortOrder_Cus_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_CustomerCode + "," +
            InventInputResult.ct_Col_MakerCode;
        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        //----------------------
        // �\�[�g��
        //----------------------
        /// <summary>�I�ԏ�(�q�Ɂ��I�ԁ��i�ԁ����[�J�[)</summary>
        /// <value></value>
        private const string ct_SortOrder_ShelfNo =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>�d���揇(�q�Ɂ��d���恨�i�ԁ����[�J�[)</summary>
        private const string ct_SortOrder_Supplier =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>�a�k�R�[�h��(�q�Ɂ��a�k�R�[�h���i�ԁ����[�J�[)</summary>
        private const string ct_SortOrder_BLGoods =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGoodsCode + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>�O���[�v�R�[�h��(�q�Ɂ��O���[�v�R�[�h���i�ԁ����[�J�[)</summary>
        private const string ct_SortOrder_BLGroup =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGroupCode + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>���[�J�[��(�q�Ɂ����[�J�[���i��)</summary>
        private const string ct_SortOrder_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode + "," +
            InventInputResult.ct_Col_GoodsNo;

        /// <summary>�d����E�I�ԏ�(�q�Ɂ��d���恨�I�ԁ��i�ԁ����[�J�[)</summary>
        private const string ct_SortOrder_Sup_ShelfNo =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
            InventInputResult.ct_Col_WarehouseShelfNo + "," + InventInputResult.ct_Col_GoodsNo + "," +
            InventInputResult.ct_Col_MakerCode;

        /// <summary>�d����E���[�J�[��(�q�Ɂ��d���恨���[�J�[���i��)</summary>
        private const string ct_SortOrder_Sup_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
            InventInputResult.ct_Col_MakerCode + "," + InventInputResult.ct_Col_GoodsNo;
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		#region // 2007.07.25 kubo del
		///// <summary> �t�B���^����(���i��) </summary>
		//private string ct_Filter_Goods = 
		//    InventInputResult.ct_Col_GrossDiv + "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
		//    InventInputResult.ct_Col_ViewDiv + "= 0";
		///// <summary> �t�B���^����(���Ԗ�) </summary>
		//private string ct_Filter_Product = 
		//    "(("+
		//        InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
		//        InventInputResult.ct_Col_PrdNumMngDiv	+ "=" + ((int)InventInputSearchCndtn.PrdNumMngDivState.NoProduct).ToString() +
		//    ")" +" or "+
		//    "("+
		//        InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Product).ToString() + 
		//    "))" + " and " +
		//    InventInputResult.ct_Col_ViewDiv + "= 0";
		#endregion

        // 2007.07.25 kubo add -------------------------->
		/// <summary> �t�B���^����(���i��) </summary>
		private string ct_Filter_Goods = 
			InventInputResult.ct_Col_GrossDiv + "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
			InventInputResult.ct_Col_ViewDiv + "=0 and " + InventInputResult.ct_Col_LogicalDeleteCode + "=0";

        #region 2007.09.11 �폜
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> �t�B���^����(���Ԗ�) </summary>
		//private string ct_Filter_Product = 
		//    "(("+
		//		InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
		//		InventInputResult.ct_Col_PrdNumMngDiv	+ "=" + ((int)InventInputSearchCndtn.PrdNumMngDivState.NoProduct).ToString() +
		//	")" +" or "+
		//    "("+
		//		InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Product).ToString() + 
		//	"))" + " and " +
		//	InventInputResult.ct_Col_ViewDiv + "= 0 and " + InventInputResult.ct_Col_LogicalDeleteCode + "=0";
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        // 2007.07.25 kubo add <--------------------------
        #endregion 2007.09.11 �폜

        #endregion

        #region �� IInventInputMdiChild �����o

        #region �� Public Property
        /// <summary> ��ƃR�[�h�v���p�e�B </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> ���_�R�[�h�v���p�e�B </summary>
		public string SectionCode
		{
			set { this._sectionCode = value; }
		}

		/// <summary> ���_���̃v���p�e�B </summary>
		public string SectionName
		{
			set { this._sectionName = value; }
		}

		/// <summary> ����{�^��Enabled�v���p�e�B </summary>
		public bool IsCansel
		{
			get { return this._isCansel; }
		}

		/// <summary> �ۑ��{�^��Enabled�v���p�e�B </summary>
		public bool IsSave
		{
			get { return this._isSave; }
		}

		/// <summary> ���o�{�^��Enabled�v���p�e�B </summary>
		public bool IsExtract
		{
			get { return this._isExtract; }
		}

		/// <summary> �V�K�{�^��Enabled�v���p�e�B </summary>
		public bool IsNewInvent
		{
			get { return this._isNewInvent; }
		}

		/// <summary> �ڍ׃{�^��Enabled�v���p�e�B </summary>
		public bool IsDetail
		{
			get { return this._isDetail; }
		}

		/// <summary> �o�[�R�[�h�Ǎ��{�^��Enabled�v���p�e�B </summary>
		public bool IsBarcodeRead
		{
			get { return this._isBarcodeRead; }
		}

		/// <summary> �ڍ׃{�^��Enabled�v���p�e�B </summary>
		public bool IsDataEdit
		{
			get { return this._isDataEdit; }
		}

        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� ----->>>>>
        /// <summary> �i�Ԍ����{�^��Enabled�v���p�e�B(true:�i�Ԍ����{�^���N���b�N���ł���@false:�i�Ԍ����{�^���N���b�N���ł��Ȃ�) </summary>
        public bool IsGoodsSearch
        {
            get { return this._isGoodsSearch; }
        }
        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� -----<<<<<
		#endregion �� Public Property

		#region �� Public Method
		#region �� ��ʕ\������
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �^�u���ύX�����O�Ɏ��s�����</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
        /// <br>UpdateNote : 2009/12/03 ����� �o�l�D�m�r�ێ�˗��B</br>
        /// <br>             REDMINE:2018�@������Q�̏C��</br>
		/// </remarks>
		public int ShowData ( object parameter )
		{
			try
			{
				this.uGrid_InventInput.BeginUpdate();
                this._extrInfo = (InventInputSearchCndtn)parameter;

                //this._isFirstsetting = true;        //ADD 2009/05/14 �s��Ή�[13260]  // DEL 2009/12/03
                this._addingKey = true;               //ADD yangyi 2013/03/01 Redmine#34175 
				ShowDataProc();
			}
			finally
			{
				this.uGrid_InventInput.EndUpdate();
			}
			return 0;
		}
		#endregion

		#region �� �^�u�ύX�O����
		/// <summary>
		/// �^�u�ύX�O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �^�u���ύX�����O�Ɏ��s�����</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeTabChange ( object parameter )
		{
			return 0;
		}
		#endregion

		#region �� �I���O����
		/// <summary>
		/// �I���O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �I���O�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeClose ( object parameter )
		{
			return 0;
		}
		#endregion

		#region �� ����O����
		/// <summary>
		/// ����O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����O�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeCansel ( object parameter )
		{
			return 0;
		}
		#endregion

		#region �� �������
		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int Cansel ( object parameter )
		{
			// ���b�Z�[�W�Ŏ���̊m�F
			string strMsg = "���ݕҏW���̃f�[�^�����݂��܂��B\n\n������Ԃɖ߂��܂����H";

			// Ok�Ȃ珉�񒊏o���A�ۑ����̃f�[�^�ɖ߂�
			DialogResult dlgRes = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_INFO,        //�G���[���x��
				"MAZAI05130UB",                     //UNIT�@ID
				"�I������",                        //�v���O��������
				"���",		                        //�v���Z�XID
				"",                                 //�I�y���[�V����
				strMsg,                             //���b�Z�[�W
				0,									//�X�e�[�^�X
				null,								//�I�u�W�F�N�g
				MessageBoxButtons.YesNo,               //�_�C�A���O�{�^���w��
				MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
				);

			switch( dlgRes )
			{
				case DialogResult.Yes:
					// ���݂̃e�[�u���Ƀo�b�t�@�e�[�u�����R�s�[
					try
					{
                        this.uGrid_InventInput.BeginUpdate();
						this._inventInputAcs.Remove();

                        this._isFirstsetting = true;        //ADD 2009/05/14�@�s��Ή�[13260]
                        this.ShowDataProc();                //ADD 2009/05/14�@�s��Ή�[13260]
					}
					finally
					{
						this.uGrid_InventInput.EndUpdate();

                        if (this.uGrid_InventInput.Rows.Count > 0)
                        {
                            this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
					#region //	2007.07.19 kubo del
					//ChangeViewStyle();
					//InitialInventInputGrid( this.uGrid_InventInput.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ] );	// �O���b�h�̐ݒ肵�Ȃ���
					//this.uGrid_InventInput.Refresh(); // �O���b�h����������N���A
					#endregion
					break;
				case DialogResult.No:
					// �������Ȃ�
					break;
			}
			return 0;
		}
		#endregion

		#region �� ���o�O����
		/// <summary>
		/// ���o�O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ���o�O�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeExtract ( object parameter )
		{
			return 0;
		}
		#endregion

		#region �� ���o����
		/// <summary>
		/// ���o����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ���o�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int Extract (ref object parameter )
		{
			return 0;
		}
		#endregion

		#region �� �V�K����
		/// <summary>
		/// �V�K����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �V�K�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int NewInvent ( object parameter )
		{
			return NewInventProc();
		}
		#endregion

		#region �� �ۑ�����
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ۑ��������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int Save ( object parameter )
		{
			string errMsg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			UltraGridRow activeRow = null;

			try
			{
				// �G�f�B�b�g���[�h�ɂȂ��Ă���Z���𔲂��邽�߂̏���
				this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

				this.uGrid_InventInput.BeginUpdate();	// �`���~

				if ( this.uGrid_InventInput.ActiveRow != null )
					activeRow = this.uGrid_InventInput.ActiveRow;

				this.uGrid_InventInput.ActiveRow = null;
				
                #region // 2007.07.19 kubo del
				// this.uGrid_InventInput.UpdateData();	// �ύX�̃R�~�b�g 
				#endregion

				this.uGrid_InventInput.Selected.Rows.Clear();
				this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
				this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

				status = this._inventInputAcs.WriteInvent(out errMsg);

				this.uGrid_InventInput.ActiveRow = activeRow;

				emErrorLevel errLv = emErrorLevel.ERR_LEVEL_INFO;
				switch ( status )
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						// ����I��
						this.uGrid_InventInput.Refresh();
                        errLv = emErrorLevel.ERR_LEVEL_INFO;
                        break;
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						// �X�V�G���[����
						errLv = emErrorLevel.ERR_LEVEL_EXCLAMATION;
						break;
					default:
						// ��O�Ȃ�
						errLv = emErrorLevel.ERR_LEVEL_STOPDISP;
						break;
				}

				#region // 2007.07.19 kubo del
				// �f�[�^�ĕ`��
				//ChangeViewStyle();
				//this.uGrid_InventInput.DataBind();
				//if ( this.uGrid_InventInput.Rows.Count > 0 )
				//{
				//    this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
				//}
				//this.uGrid_InventInput.PerformAction( UltraGridAction.EnterEditMode );
				#endregion

				// ���b�Z�[�W�\��
				this.MsgDispProc(errMsg, status, "Save", errLv);
			}
			finally
			{
				this.uGrid_InventInput.EndUpdate();	// �`��ĊJ
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------>>>>>
        /// <summary>
        /// �ۑ��O����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0�F����A0�ȊO�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s��</br>
        /// <br>Programer  : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �u�s�폜�v�݂̂��s�����ꍇ�ł��ۑ��\�ɕύX����</br>
        /// </remarks>
        public int BeforeSave(object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // �Z���̃G�f�B�b�g���[�h����
            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

            int CheckCount = 0;
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                // --- ADD 2009/12/03 ---------->>>>>
                // �u�s�폜�v�ꍇ
                if ((int)gridRow.Cells[InventInputResult.ct_Col_DeleteDiv].Value == 1)
                {
                    CheckCount++;
                    continue;
                }
                // --- ADD 2009/12/03 ----------<<<<<

                if ((string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value.ToString())) &&
                    (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString())) &&
                    (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString())) &&
                    (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString())))
                {
                    continue;
                }

                // �I����
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("�I��������͂��ĉ������B", status, InventInputResult.ct_Col_InventoryStockCnt, gridRow);
                    return status;
                }
                // �I�����{��
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("�I�����{��(�N)����͂��ĉ������B", status, InventInputResult.ct_Col_InventoryDay_Year, gridRow);
                    return status;
                }
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("�I�����{��(��)����͂��ĉ������B", status, InventInputResult.ct_Col_InventoryDay_Month, gridRow);
                    return status;
                }
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("�I�����{��(��)����͂��ĉ������B",status, InventInputResult.ct_Col_InventoryDay_Day,gridRow);
                    return status;
                }
                CheckCount++;
            }

            // �Ώۃf�[�^�Ȃ�
            if (CheckCount == 0)
            {
                this.BeforeSaveErrorProc("�Ώۃf�[�^������܂���B", status, string.Empty, null);
                return status;
            }

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        /// <summary>
        /// ���̓G���[����������
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[���̃X�e�[�^�X</param>
        /// <param name="cellName">�G���[������(�O���b�h�ȊO�̏ꍇ��string.Empty��ݒ�)</param>
        /// <param name="gridRow">�G���[�����s(�O���b�h�ȊO�̏ꍇ��Null��ݒ�)</param>
        /// <remarks>
        /// <br>Note       : �G���[�������Ƀ��b�Z�[�W�\������A�t�H�[�J�X�𓖂Ă铙�̊e�������s��</br>
        /// <br>Programer  : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks>
        private void BeforeSaveErrorProc(string msg, int status, string cellName, UltraGridRow gridRow)
        {
            //�G���[���b�Z�[�W
            this.MsgDispProc(msg, status, "BeforeSave", emErrorLevel.ERR_LEVEL_EXCLAMATION);

            //�t�B���^����
            this.uGrid_InventInput.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

            if (gridRow != null)
            {
                //�t�H�[�J�X�ݒ�
                gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activated = true;
                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------>>>>>

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        public int Save(object parameter)
        {
            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�ۑ���";
            msgForm.Message = "�I���f�[�^�̕ۑ����ł��B";

            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            string errMsg = "";

            try
            {
                msgForm.Show();

                UltraGridRow activeRow = null;

                try
                {
                    // �G�f�B�b�g���[�h�ɂȂ��Ă���Z���𔲂��邽�߂̏���
                    this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

                    // �`���~
                    this.uGrid_InventInput.BeginUpdate();	

                    if (this.uGrid_InventInput.ActiveRow != null)
                    {
                        activeRow = this.uGrid_InventInput.ActiveRow;
                    }

                    this.uGrid_InventInput.ActiveRow = null;
                    this.uGrid_InventInput.Selected.Rows.Clear();
                    this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
                    //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

                    // �ۑ�����
                    status = this._inventInputAcs.WriteInvent(this._extrInfo.DifCntExtraDiv, out errMsg);

                    // --- ADD 2014/12/04 Y.Wakita ---------->>>>>
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �s�̕����F��ύX
                        RowForeColorChange();
                    }
                    // --- ADD 2014/12/04 Y.Wakita ----------<<<<<

                    this.uGrid_InventInput.ActiveRow = activeRow;

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.uGrid_InventInput.Refresh();
                    }
                }
                finally
                {
                    // �`��ĊJ
                    this.uGrid_InventInput.EndUpdate();	
                }
            }
            finally
            {
                msgForm.Close();
            }

            emErrorLevel errLv = emErrorLevel.ERR_LEVEL_INFO;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    // ����I��
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);

                    this.MAZAI05130UB_FormClosing(this, null); // ADD 2009/12/03


                    return (status);
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    // �X�V�G���[����
                    errLv = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                    break;
                default:
                    // ��O�Ȃ�
                    errLv = emErrorLevel.ERR_LEVEL_STOPDISP;
                    break;
            }

            // ���b�Z�[�W�\��
            this.MsgDispProc(errMsg, status, "Save", errLv);
            
            return (status);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

		#region �� �ڍו\������
		/// <summary>
		/// �ڍו\������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ڍו\���������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int ShowDetail ( object parameter )
		{
			return 0;
		}
		#endregion

		#region �� �o�[�R�[�h�Ǎ�����
		/// <summary>
		/// �o�[�R�[�h�Ǎ�����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�h�Ǎ��������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BarcodeRead ( object parameter )
		{
			ReadBarCodeMain();
			return 0;
		}
		#endregion

		#region �� �ҏW����
		/// <summary>
		/// �ҏW����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ҏW�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		public int DataEdit ( object parameter )
		{
			return this.DataEditProc();
		}
		#endregion

        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� ----->>>>>
        #region �� �i�Ԍ���
        /// <summary>
        /// �i�Ԍ�������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �i�Ԍ������s��</br>
        /// <br>Programer  : ��</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/27 �i�Ԍ�����ǉ�</br>
        /// </remarks>
        public int GoodsSearch(object parameter)
        {
            return GoodsSearchProc();
        }
        #endregion

        #region �� �i�Ԍ������C��
        /// <summary>
        /// �i�Ԍ������C��
        /// </summary>
        /// <returns>������ԁi�����i�Ԍ��������ꍇ�ActFNC_NORMAL��߂�j</returns>
        private int GoodsSearchProc()
        {
            // �������ݒ�
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                if ((this._goodsSearchForm == null) || (false == this._goodsSearchForm.Visible))
                {
                    this._goodsSearchForm = new MAZAI05130UE();
                }
                else
                {
                    return status;
                }

                // �e��ʂ�Grid�f�[�^�ݒ�
                _goodsSearchForm.UltraGrid = this.uGrid_InventInput;
                this._goodsSearchForm.ShowEditor();

                _goodsSearchForm.Show(this);

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                this.MsgDispProc("�I���f�[�^�̕i�Ԍ����Ɏ��s���܂����B", status, "NewInventProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            return status;
        }
        #endregion
        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� -----<<<<<

        // --- ADD �� 2015/04/27 Redmine#45747 �I�����͉�ʂ��~�{�^���ŕ���ۂɖ��ۑ��̓��̓f�[�^������ꍇ�͌x�����b�Z�[�W��\������ ----->>>>>
        #region �� ����O�`�F�b�N
        /// <summary>
        /// ����O�`�F�b�N
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>bool(TRUE: ��ʕ���@FALSE:��ʕ���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note       : ����O�`�F�b�N���s��</br>
        /// <br>Programer  : ��</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/27 ����O�`�F�b�N��ǉ�</br>
        /// </remarks>
        public bool ClosingCheck()
        {
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                if ((int)gridRow.Cells[InventInputResult.ct_Col_ChangeDiv].Value == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                {
                    string msg = "���ݕҏW���̃f�[�^�����݂��܂��B\n\n�I�����Ă���낵���ł����H";
                    DialogResult diaLog = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "", msg, 
                        0, MessageBoxButtons.YesNo,MessageBoxDefaultButton.Button2);
                    if (diaLog == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion �� ����O�`�F�b�N
        // --- ADD �� 2015/04/27 Redmine#45747 �I�����͉�ʂ��~�{�^���ŕ���ۂɖ��ۑ��̓��̓f�[�^������ꍇ�͌x�����b�Z�[�W��\������ -----<<<<<
		#endregion �� Public Method

		#region IInventInputMdiChild �����o
		/// <summary>
		/// �c�[���o�[�ݒ�
		/// </summary>
		public event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;
		#endregion
		#endregion �� IInventInputMdiChild �����o

		#region �� Private Method
		#region �� �������������C��
		/// <summary>
		/// �������������C��
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: ��ʏ��������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private int InitialLoadScreen ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				// ����N�����̂݉�ʐݒ�

				// Toolbars Setting
				this.InitialToolBarsSetting();

				// StatusBarsSetting
				this.InitializeStatusBarSetting();

				// �R���|�[�l���g��������
				this.InitialPrintSetCompornent();

				// ��ʃC���[�W����
                this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
                this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

				// �A�C�R���ݒ�
				this.ub_RowDelete.ImageList = IconResourceManagement.ImageList16;
				this.ub_RowDelete.Appearance.Image = Size16_Index.ROWDELETE;
			}
			finally
			{
			}

			return status;
		}
		#endregion

		#region �� �c�[���o�[�ݒ菈��
		/// <summary>
		/// �c�[���o�[�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̐ݒ���s���B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialToolBarsSetting ()
		{
			// �ꊇ���̓{�^��
			this.utb_InventDataToolBar.Tools[ct_tool_InventoryAllInput].Control = this.ub_InventoryAllInput;
			// �I�����{��
            this.utb_InventDataToolBar.Tools[ct_tool_InventoryDate].Control = this.tde_InventoryDate;

            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I����
            this.utb_InventDataToolBar.Tools[ct_tool_InventoryExeDate].Control = this.tde_InventoryExeDate;
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // �\�����@�R���e�i�ɒǉ�
			this.utb_InventDataToolBar.Tools[ct_tool_ViewStyleContainer].Control = this.tce_ViewStyle;

			// �\�[�g���R���e�i�ɒǉ�
			this.utb_InventDataToolBar.Tools[ct_tool_SortOrderContainer].Control = this.tce_SortOrder;

			// 2007.07.24 kubo add
			this.utb_InventDataToolBar.Tools[ct_tool_RowDelete].Control = this.ub_RowDelete;

		}
		#endregion

		#region �� �X�e�[�^�X�o�[��������
		/// <summary>
		/// �X�e�[�^�X�o�[����������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �X�e�[�^�X�o�[���������s��</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitializeStatusBarSetting ()
		{
			// �t�H���g�T�C�Y�ύX�R���{�{�b�N�X�̐ݒ�
			this.tce_FontSize.MaxDropDownItems = this.tce_FontSize.Items.Count;
			this.tce_FontSize.Value = 10;
		}

		#region �� ��������ݒ�R���|�[�l���g��������
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ��������ݒ�R���|�[�l���g��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ�������B</br>
		/// <br>Programmer	: 30414 �E �K�j</br>
		/// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote  : 2009/11/23 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>              �I�����{���̓��̓~�X��h���ׁA�I�����{���̏����\����ύX����</br>
		/// </remarks>
		private void InitialPrintSetCompornent()
		{
			// �I�����{��
			//this.tde_InventoryDate.SetDateTime( DateTime.Now ); // DEL 2009/12/03
			// �\�����@
			this.tce_ViewStyle.Items.Add( (int)InventInputSearchCndtn.ViewStyleState.Product, "�����ԍ���");
			this.tce_ViewStyle.Items.Add( (int)InventInputSearchCndtn.ViewStyleState.Goods	, "���i��");
			this.tce_ViewStyle.MaxDropDownItems = this.tce_ViewStyle.Items.Count;

			// �\�[�g��
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.ShelfNo, "�I�ԏ�");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Customer, "�d���揇");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.BLGoods,"BL���ޏ�");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.BLGroup, "��ٰ�ߺ��ޏ�");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Maker, "���[�J�[��");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo, "�d����E�I�ԏ�");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_Maker, "�d����E���[�J�[��");
			this.tce_SortOrder.MaxDropDownItems = this.tce_SortOrder.Items.Count;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��������ݒ�R���|�[�l���g��������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void InitialPrintSetCompornent()
        {
            // �I�����{��
            this.tde_InventoryDate.SetDateTime(DateTime.Now);
            // �\�����@
            this.tce_ViewStyle.Items.Add((int)InventInputSearchCndtn.ViewStyleState.Product, "�����ԍ���");
            this.tce_ViewStyle.Items.Add((int)InventInputSearchCndtn.ViewStyleState.Goods, "���i��");
            this.tce_ViewStyle.MaxDropDownItems = this.tce_ViewStyle.Items.Count;

            // �\�[�g��
            // 2007.06.28 22013 kubo Edit ( �n�C�t���������ɕύX�@)�@------------------------------->
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.Goods, "�q�Ɂ����i");
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.CarrierEP		, "�q�Ɂ����Ǝҁ����i");
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.Customer		, "�q�Ɂ��d���恨���i");
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.ShipCustomer	, "�q�Ɂ��ϑ��恨���i");
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.ShelfNo, "�q�Ɂ��I��");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.SNo_GoodsDiv, "�q�Ɂ��I�ԁ����[�J�[�����i�敪�����i");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.SNo_Goods, "�q�Ɂ��I�ԁ����[�J�[�����i");
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Customer, "�q�Ɂ��d����");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.BLGoods, "�q�Ɂ��a�k�R�[�h");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Maker, "�q�Ɂ����[�J�[");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo, "�q�Ɂ��d���恨�I��");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_Maker, "�q�Ɂ��d���恨���[�J�[");
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.06.28 22013 kubo Edit ------------------------------->
            this.tce_SortOrder.MaxDropDownItems = this.tce_SortOrder.Items.Count;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �L�[�}�b�s���O�ݒ菈��
        /// <summary>
		/// �O���b�h�L�[�}�b�s���O�쐬����
		/// </summary>
		/// <param name="grid">�ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�ɑ΂��ăL�[�}�b�s���O���쐬���܂��B</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void MakeGridKeyMapping( UltraGrid grid )
		{
			// wkKeyMapping = new GridKeyActionMapping( 
			//		Keys.Enter,							// �ΏۂƂȂ�Key�B����Key���w�肵���Ƃ��̓�������߂�
			//		UltraGridAction.NextCellByTab,		// �Ώۂ�Key�������ꂽ�Ƃ��̓���
			//		UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox,	// Key��������Ă��ΏۊO�ƂȂ�ꍇ�̎w��
			//		UltraGridState.Cell,				// �����ꂽ��̃O���b�h�̏��
			//		SpecialKeys.All,					// �����ɉ�����Ă���������Key�B(����Key��������Ă���Ɠ�������s���Ȃ��B)
			//		SpecialKeys.Shift );				// �����ɉ�����Ȃ��Ɠ�������Ȃ�Key�B(����Key�𓯎��ɉ������Ƃ���������s����B)
			//grid.KeyActionMappings.Add( wkKeyMapping );

			
			GridKeyActionMapping wkKeyMapping = null;

			// Enter�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.NextCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Shift + Enter�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.PrevCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.AltCtrl, 
				SpecialKeys.Shift );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ���L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Up, 
				UltraGridAction.AboveCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ���L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Down, 
				UltraGridAction.BelowCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageUp�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Prior, 
				UltraGridAction.PageUpCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageDown�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Next, 
				UltraGridAction.PageDownCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Space�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Space, 
				UltraGridAction.ToggleRowSel, 
				0, 
				0, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

		}
		#endregion

		#endregion �� ����������

		#region �� �f�[�^�\��UltraGrid��������
        /// <summary>
        /// �f�[�^�\��UltraGrid��������
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid(UltraGridBand band)
        {
            // ��U���ׂĂ̗���\���ɂ��A�\���ʒu�𓝈ꂳ����
            foreach (UltraGridColumn column in band.Columns)
            {
                column.Hidden = true;
                column.CellAppearance.TextHAlign = HAlign.Left;
                column.CellAppearance.ImageHAlign = HAlign.Left;
                column.CellAppearance.ImageVAlign = VAlign.Middle;
                column.TabStop = true;
            }

            InitialInventInputGrid_Hidden(band);			// �\����Ԑݒ�
            InitialInventInputGrid_Tag(band);				// Tag
            InitialInventInputGrid_CellActivation(band);    // ���͐ݒ�
            InitialInventInputGrid_Width(band);			    // ���ݒ�
            InitialInventInputGrid_CellAppearance(band);	// �e�L�X�g�\���ʒu
            InitialInventInputGrid_CellClickAction(band);	// CellClickAction
            InitialInventInputGrid_Style(band);			    // ��X�^�C��
            InitialInventInputGrid_Format(band);			// Format
            InitialInventInputGrid_GroupSetting(band);		// �O���[�v�ݒ�

            // ��ړ��ݒ�
            band.Override.AllowColMoving = AllowColMoving.WithinGroup;

            // �t�B���^�ݒ�
            band.Override.AllowRowFiltering = DefaultableBoolean.True;

            // �O���b�h�ݒ���擾
            GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_InventInput);
            if (gridStateInfo != null)
            {
                // �O���b�h�ݒ�
                this._gridStateController.SetGridStateToGrid(ref this.uGrid_InventInput);
                this.tce_FontSize.Value = (int)gridStateInfo.FontSize;
                this.uce_ColSizeAutoSetting.Checked = gridStateInfo.AutoFit;

                // �O���b�h�̐ݒ肩��c�[���o�[�̃`�F�b�N�ɔ��f����
                SettingHiddenToolChecked(ct_tool_Hidden_Warehouse, InventInputResult.ct_Col_WarehouseName);	                // �q��
                SettingHiddenToolChecked(ct_tool_Hidden_WarehouseShelfNo, InventInputResult.ct_Col_WarehouseShelfNo);	    // �q�ɒI��
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo1, InventInputResult.ct_Col_DuplicationShelfNo1);	// �d���I�ԂP
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo2, InventInputResult.ct_Col_DuplicationShelfNo2);	// �d���I�ԂQ
                SettingHiddenToolChecked(ct_tool_Hidden_Maker, InventInputResult.ct_Col_MakerName);	                        // ���[�J�[
                SettingHiddenToolChecked(ct_tool_Hidden_Supplier, InventInputResult.ct_Col_SupplierName);	                // �d����
                SettingHiddenToolChecked(ct_tool_Hidden_StockTrtEntDiv, InventInputResult.ct_Col_StockTrtEntDivName);	    // �݌ɋ敪
            }
        }

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �f�[�^�\��UltraGrid��������
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid( UltraGridBand band )
		{
			// ��U���ׂĂ̗���\���ɂ��A�\���ʒu�𓝈ꂳ����
			foreach( UltraGridColumn column in band.Columns ) {
                column.Hidden = true;
                column.CellAppearance.TextHAlign = HAlign.Left;
                column.CellAppearance.ImageHAlign = HAlign.Left;
                column.CellAppearance.ImageVAlign = VAlign.Middle;
                column.TabStop = true;
			}

            this.InitialInventInputGrid_Hidden(band);				// �\����Ԑݒ�
            this.InitialInventInputGrid_Tag(band);				// Tag
            this.InitialInventInputGrid_CellActivation(band);		// ���͐ݒ�
            this.InitialInventInputGrid_Width(band);				// ���ݒ�
            this.InitialInventInputGrid_CellAppearance(band);		// �e�L�X�g�\���ʒu
            this.InitialInventInputGrid_CellClickAction(band);	// CellClickAction
            this.InitialInventInputGrid_Style(band);				// ��X�^�C��
            //this.InitialInventInputGrid_TabStop( band );			// TabStop
            this.InitialInventInputGrid_Format(band);				// Format
			this.InitialInventInputGrid_GroupSetting( band );		// �O���[�v�ݒ�

            // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ��w�b�_���\���ɂ���B
            //band.ColHeadersVisible = false;
            // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // ��ړ��ݒ�
            band.Override.AllowColMoving = AllowColMoving.WithinGroup;

            // �t�B���^�ݒ�
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            
            // �O���b�h�ݒ���擾
			GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_InventInput);
			if (gridStateInfo != null)
			{
				// �O���b�h�ݒ�
				this._gridStateController.SetGridStateToGrid(ref this.uGrid_InventInput);
				this.tce_FontSize.Value = (int)gridStateInfo.FontSize;
				this.uce_ColSizeAutoSetting.Checked = gridStateInfo.AutoFit;

				// �O���b�h�̐ݒ肩��c�[���o�[�̃`�F�b�N�ɔ��f����
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //SettingHiddenToolChecked( ct_tool_Hidden_TEL1             , InventInputResult.ct_Col_StockTelNo1          );	// TEL1
				//SettingHiddenToolChecked( ct_tool_Hidden_TEL2			    , InventInputResult.ct_Col_StockTelNo2			);	// TEL2
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                SettingHiddenToolChecked( ct_tool_Hidden_Warehouse          , InventInputResult.ct_Col_WarehouseName        );	// �q��
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                SettingHiddenToolChecked(ct_tool_Hidden_WarehouseShelfNo    , InventInputResult.ct_Col_WarehouseShelfNo     );	// �q�ɒI��
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo1 , InventInputResult.ct_Col_DuplicationShelfNo1  );	// �d���I�ԂP
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo2 , InventInputResult.ct_Col_DuplicationShelfNo2  );	// �d���I�ԂQ
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                SettingHiddenToolChecked(ct_tool_Hidden_Maker               , InventInputResult.ct_Col_MakerName            );	// ���[�J�[
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //SettingHiddenToolChecked(ct_tool_Hidden_CarrierEp         , InventInputResult.ct_Col_CarrierEpName        );	// ���Ǝ�
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                SettingHiddenToolChecked(ct_tool_Hidden_Customer            , InventInputResult.ct_Col_CustomerName         );	// �d����
				SettingHiddenToolChecked( ct_tool_Hidden_ShipCustomer	    , InventInputResult.ct_Col_ShipCustomerName		);	// �ϑ���
				SettingHiddenToolChecked( ct_tool_Hidden_StockTrtEntDiv	    , InventInputResult.ct_Col_StockTrtEntDivName	);	// �݌ɋ敪
            }
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        /// <summary>
		/// �c�[���`�F�b�N�X�V����
		/// </summary>
		/// <param name="toolKey"></param>
		/// <param name="columnKey"></param>
		private void SettingHiddenToolChecked( string toolKey, string columnKey)
		{
			((StateButtonTool)this.utb_InventDataToolBar.Tools[toolKey]).Checked = 
				!this.uGrid_InventInput.Rows.Band.Columns[ columnKey ].Hidden;
		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(Hidden�v���p�e�B)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(Hidden�v���p�e�B)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/30 ���N�n��</br>
        /// <br>             ��Q�� #18764</br>
        /// </remarks>
        private void InitialInventInputGrid_Hidden(UltraGridBand band)
        {
            band.Columns[InventInputResult.ct_Col_InventoryNewDiv].Hidden = true;           // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Hidden = false;      // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_GoodsNo].Hidden = false;                  // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].Hidden = false;                // �i��
            band.Columns[InventInputResult.ct_Col_ListPrice].Hidden = true;                // �艿                  //ADD 2011/01/30          
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Hidden = false;           // �d���P��
            band.Columns[InventInputResult.ct_Col_StockTotal].Hidden = false;               // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Hidden = false;        // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Hidden = false;     // ���ِ�
            band.Columns[InventInputResult.ct_Col_BfChgInventoryToleCnt].Hidden = true;     // �ύX�O���ِ�
            band.Columns[InventInputResult.ct_Col_InventoryDay].Hidden = true;              // �I�����{��
            band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime].Hidden = true;		// �I�����{��(DateTime)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Hidden = false;		// �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Hidden = true;		// �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Hidden = false;		// �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Hidden = true;		// �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Hidden = false;		    // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Hidden = true;			// �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_Button].Hidden = true;                    // �{�^���p�J����
            band.Columns[InventInputResult.ct_Col_WarehouseCode].Hidden = true;             // �q�ɃR�[�h
            //band.Columns[InventInputResult.ct_Col_WarehouseName].Hidden = true;             // �q�ɖ���           //DEL 2009/05/14 �s��Ή�[13260]
            //band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Hidden = true;          // �I��               //DEL 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_WarehouseName].Hidden = false;            // �q�ɖ���             //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Hidden = false;         // �I��                 //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Hidden = true;       // �d���I��1
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Hidden = true;       // �d���I��2
            band.Columns[InventInputResult.ct_Col_MakerCode].Hidden = true;                 // ���[�J�[�R�[�h
            //band.Columns[InventInputResult.ct_Col_MakerName].Hidden = true;                 // ���[�J�[����       //DEL 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_MakerName].Hidden = false;                // ���[�J�[����         //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_SupplierCode].Hidden = true;              // �d����R�[�h
            band.Columns[InventInputResult.ct_Col_SupplierName].Hidden = true;              // �d���於��
            band.Columns[InventInputResult.ct_Col_SupplierName2].Hidden = true;             // �d���於��2
            band.Columns[InventInputResult.ct_Col_ShipCustomerCode].Hidden = true;          // �ϑ���R�[�h
            band.Columns[InventInputResult.ct_Col_StockTrtEntDiv].Hidden = true;            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Hidden = true;        // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_No].Hidden = false;                       // No                   //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Hidden = true;            // �����p�v�Z����       //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCntBf].Hidden = true;    // �I���ߕs����         //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(Hidden�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Hidden( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// �\����Ԑݒ�(Hidden)
			// �\������ ------------------------------------------------------
			// �I���V�K�ǉ��敪
			band.Columns[ InventInputResult.ct_Col_InventoryNewDiv ].Hidden = true;
			// �I���V�K�ǉ��敪
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].Hidden = false;

			// �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].Hidden = false;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Hidden = false;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<

			// �i��
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Hidden = false;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Hidden = false;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �d���P��
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].Hidden = false;

			// �݌ɐ�
			band.Columns[ InventInputResult.ct_Col_StockTotal ].Hidden = false;

			// �I���݌ɐ�
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Hidden = false;

            // ���ِ�
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Hidden = false;
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Hidden = true;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            // �ύX�O���ِ�
			band.Columns[ InventInputResult.ct_Col_BfChgInventoryToleCnt ].Hidden = true;

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            // �I����
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Hidden = true;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

			// �I�����{��
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Datetime ].Hidden = true;		// �I�����{��(DateTime)
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Hidden = false;			// �I�����{��(�N ����)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Hidden = false;			// �I�����{��(�N ���x��)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Hidden = false;			// �I�����{��(�� ����)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Hidden = false;		// �I�����{��(�� ���x��)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Hidden = false;			// �I�����{��(�� ����)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Hidden = false;			// �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Hidden     = false;		// �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Hidden    = true;			// �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Hidden    = false;		// �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Hidden   = true;		    // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Hidden      = false;		// �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Hidden     = true;			// �I�����{��(�� ���x��)
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

			// �{�^���p�J����
			band.Columns[ InventInputResult.ct_Col_Button ].Hidden = true;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d�b�ԍ�1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ].Hidden = true;
            //
			//// �d�b�ԍ�2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ].Hidden = true;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �q��
			band.Columns[ InventInputResult.ct_Col_WarehouseCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Hidden = true;

            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].Hidden = true;
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].Hidden = true;
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].Hidden = true;
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // ���[�J�[
			band.Columns[ InventInputResult.ct_Col_MakerCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_MakerName ].Hidden = true;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ�
			//band.Columns[ InventInputResult.ct_Col_CarrierEpCode ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Hidden = true;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// ���Ӑ�
			band.Columns[ InventInputResult.ct_Col_CustomerCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_CustomerName2 ].Hidden = true;

			// �ϑ���
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Hidden = true;

			// �݌Ɉϑ�����敪
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Hidden = true;

			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �f�[�^�\��UltraGrid��������(Tag�v���p�e�B)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(Tag�v���p�e�B)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/30 ���N�n��</br>
        /// <br>             ��Q�� #18764</br>
        /// </remarks>
        private void InitialInventInputGrid_Tag(UltraGridBand band)
        {
            // �쐬����
            band.Columns[InventInputResult.ct_Col_CreateDateTime].Tag = InventInputResult.ct_Col_CreateDateTime;
            // �X�V����
            band.Columns[InventInputResult.ct_Col_UpdateDateTime].Tag = InventInputResult.ct_Col_UpdateDateTime;
            // ��ƃR�[�h
            band.Columns[InventInputResult.ct_Col_EnterpriseCode].Tag = InventInputResult.ct_Col_EnterpriseCode;
            // GUID
            band.Columns[InventInputResult.ct_Col_FileHeaderGuid].Tag = InventInputResult.ct_Col_FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            band.Columns[InventInputResult.ct_Col_UpdEmployeeCode].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId1].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId2].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
            // �_���폜�敪
            band.Columns[InventInputResult.ct_Col_LogicalDeleteCode].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
            // ���_�R�[�h
            band.Columns[InventInputResult.ct_Col_SectionCode].Tag = InventInputResult.ct_Col_SectionCode;
            // �q�ɃR�[�h
            band.Columns[InventInputResult.ct_Col_WarehouseCode].Tag = InventInputResult.ct_Col_WarehouseCode;
            // �q�ɖ���
            band.Columns[InventInputResult.ct_Col_WarehouseName].Tag = InventInputResult.ct_Col_WarehouseName;
            // ���[�J�[�R�[�h
            band.Columns[InventInputResult.ct_Col_MakerCode].Tag = InventInputResult.ct_Col_MakerCode;
            // ���[�J�[����
            band.Columns[InventInputResult.ct_Col_MakerName].Tag = InventInputResult.ct_Col_MakerName;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].Tag = InventInputResult.ct_Col_GoodsNo;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].Tag = InventInputResult.ct_Col_GoodsName;
            // --- ADD 2011/01/30 --------------------------------------------------------------------->>>>>
            // �艿
            band.Columns[InventInputResult.ct_Col_ListPrice].Tag = InventInputResult.ct_Col_ListPrice;
            // --- ADD 2011/01/30 ---------------------------------------------------------------------<<<<<
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // ���i�啪�ރR�[�h
            band.Columns[InventInputResult.ct_Col_LargeGoodsGanreCode].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
            // ���i�����ރR�[�h
            band.Columns[InventInputResult.ct_Col_MediumGoodsGanreCode].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
            // �O���[�v�R�[�h
            band.Columns[InventInputResult.ct_Col_BLGroupCode].Tag = InventInputResult.ct_Col_BLGroupCode;
            // �O���[�v�R�[�h����
            band.Columns[InventInputResult.ct_Col_BLGroupName].Tag = InventInputResult.ct_Col_BLGroupName;
            // ���Е��ރR�[�h
            band.Columns[InventInputResult.ct_Col_EnterpriseGanreCode].Tag = InventInputResult.ct_Col_EnterpriseGanreCode;
            // �a�k�i��
            band.Columns[InventInputResult.ct_Col_BLGoodsCode].Tag = InventInputResult.ct_Col_BLGoodsCode;
            // �a�k�i��
            band.Columns[InventInputResult.ct_Col_BLGoodsName].Tag = InventInputResult.ct_Col_BLGoodsName;
            // �d����R�[�h
            band.Columns[InventInputResult.ct_Col_SupplierCode].Tag = InventInputResult.ct_Col_SupplierCode;
            // �d���於��
            band.Columns[InventInputResult.ct_Col_SupplierName].Tag = InventInputResult.ct_Col_SupplierName;
            // �d���於��2
            band.Columns[InventInputResult.ct_Col_SupplierName2].Tag = InventInputResult.ct_Col_SupplierName2;
            // JAN�R�[�h
            band.Columns[InventInputResult.ct_Col_Jan].Tag = InventInputResult.ct_Col_Jan;
            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Tag = InventInputResult.ct_Col_StockUnitPrice;
            // �ύX�O�d���P��
            band.Columns[InventInputResult.ct_Col_BfStockUnitPrice].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
            // �d���P���ύX�t���O
            band.Columns[InventInputResult.ct_Col_StkUnitPriceChgFlg].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
            // �݌ɋ敪
            band.Columns[InventInputResult.ct_Col_StockDiv].Tag = InventInputResult.ct_Col_StockDiv;
            // �ŏI�d���N����
            band.Columns[InventInputResult.ct_Col_LastStockDate].Tag = InventInputResult.ct_Col_LastStockDate;
            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Tag = InventInputResult.ct_Col_StockTotal;
            // �ϑ���R�[�h
            band.Columns[InventInputResult.ct_Col_ShipCustomerCode].Tag = InventInputResult.ct_Col_ShipCustomerCode;
            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Tag = InventInputResult.ct_Col_InventoryStockCnt;
            // �I���ߕs����
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            // �I����
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Datetime].Tag = InventInputResult.ct_Col_InventoryExeDay_Datetime;
            // �I�������������t
            band.Columns[InventInputResult.ct_Col_InventoryPreprDay_Datetime].Tag = InventInputResult.ct_Col_InventoryPreprDay_Datetime;
            // �I��������������
            band.Columns[InventInputResult.ct_Col_InventoryPreprTim].Tag = InventInputResult.ct_Col_InventoryPreprTim;
            // �I�����{��
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // �I�����{��
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // �I�����{��(DateTime)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Tag = InventInputResult.ct_Col_InventoryDay_Year;
            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Tag = InventInputResult.ct_Col_InventoryDay_Month;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Tag = InventInputResult.ct_Col_InventoryDay_Day;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Tag = InventInputResult.ct_Col_InventoryDay_DayL;
            // �I���X�V��
            band.Columns[InventInputResult.ct_Col_LastInventoryUpdate].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDiv].Tag = InventInputResult.ct_Col_InventoryNewDiv;
            // �I���V�K�ǉ��敪����
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Tag = InventInputResult.ct_Col_InventoryNewDivName;
            // �}�V���݌Ɋz
            band.Columns[InventInputResult.ct_Col_StockMashinePrice].Tag = InventInputResult.ct_Col_StockMashinePrice;
            // �I���݌Ɋz
            band.Columns[InventInputResult.ct_Col_InventoryStockPrice].Tag = InventInputResult.ct_Col_InventoryStockPrice;
            // �I���ߕs�����z
            band.Columns[InventInputResult.ct_Col_InventoryTlrncPrice].Tag = InventInputResult.ct_Col_InventoryTlrncPrice;
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDiv].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
            // �݌Ɉϑ�����敪����
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
            // �W�v�敪
            band.Columns[InventInputResult.ct_Col_GrossDiv].Tag = InventInputResult.ct_Col_GrossDiv;
            // �{�^���p�J����
            band.Columns[InventInputResult.ct_Col_Button].Tag = InventInputResult.ct_Col_Button;
            // ���s
            band.Columns[InventInputResult.ct_Col_RowSelf].Tag = InventInputResult.ct_Col_RowSelf;
            // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------------------------------->>>>>
            // No
            band.Columns[InventInputResult.ct_Col_No].Tag = InventInputResult.ct_Col_No;
            // �����p�v�Z����
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Tag = InventInputResult.ct_Col_AdjustCalcCost;
            // �I���ߕs����(DB�̒l���̂܂�)
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCntBf].Tag = InventInputResult.ct_Col_InventoryTolerancCntBf;
            // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------------------------------------------------<<<<<
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        private DataRow GetBindDataRow(UltraGridRow row)
        {
            Object bindObject = row.ListObject;
            if (bindObject is DataRow)
            {
                return (DataRow)row.ListObject;
            }
            else if (bindObject is DataRowView)
            {
                return ((DataRowView)row.ListObject).Row;
            }
            else
            {
                return null;
            }            
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �f�[�^�\��UltraGrid��������(Tag�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Tag( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// �\����Ԑݒ�(Tag)
			// �\������ ------------------------------------------------------
			// �쐬����
			band.Columns[ InventInputResult.ct_Col_CreateDateTime ].Tag = InventInputResult.ct_Col_CreateDateTime;
			// �X�V����
			band.Columns[ InventInputResult.ct_Col_UpdateDateTime ].Tag = InventInputResult.ct_Col_UpdateDateTime;
			// ��ƃR�[�h
			band.Columns[ InventInputResult.ct_Col_EnterpriseCode ].Tag = InventInputResult.ct_Col_EnterpriseCode;
			// GUID
			band.Columns[ InventInputResult.ct_Col_FileHeaderGuid ].Tag = InventInputResult.ct_Col_FileHeaderGuid;
			// �X�V�]�ƈ��R�[�h
			band.Columns[ InventInputResult.ct_Col_UpdEmployeeCode ].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
			// �X�V�A�Z���u��ID1
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId1 ].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
			// �X�V�A�Z���u��ID2
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId2 ].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
			// �_���폜�敪
			band.Columns[ InventInputResult.ct_Col_LogicalDeleteCode ].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
			// ���_�R�[�h
			band.Columns[ InventInputResult.ct_Col_SectionCode ].Tag = InventInputResult.ct_Col_SectionCode;
			// ���_�K�C�h����
			band.Columns[ InventInputResult.ct_Col_SectionGuideNm ].Tag = InventInputResult.ct_Col_SectionGuideNm;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԍ݌Ƀ}�X�^GUID
			//band.Columns[ InventInputResult.ct_Col_ProductStockGuid ].Tag = InventInputResult.ct_Col_ProductStockGuid;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // �q�ɃR�[�h
			band.Columns[ InventInputResult.ct_Col_WarehouseCode ].Tag = InventInputResult.ct_Col_WarehouseCode;
			// �q�ɖ���
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Tag = InventInputResult.ct_Col_WarehouseName;
			// ���[�J�[�R�[�h
			band.Columns[ InventInputResult.ct_Col_MakerCode ].Tag = InventInputResult.ct_Col_MakerCode;
			// ���[�J�[����
			band.Columns[ InventInputResult.ct_Col_MakerName ].Tag = InventInputResult.ct_Col_MakerName;
			// �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].Tag = InventInputResult.ct_Col_GoodsCode;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Tag = InventInputResult.ct_Col_GoodsNo;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // �i��
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Tag = InventInputResult.ct_Col_GoodsName;
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �@��R�[�h
			//band.Columns[ InventInputResult.ct_Col_CellphoneModelCode ].Tag = InventInputResult.ct_Col_CellphoneModelCode;
			//// �@�햼��
			//band.Columns[ InventInputResult.ct_Col_CellphoneModelName ].Tag = InventInputResult.ct_Col_CellphoneModelName;
			//// �L�����A�R�[�h
			//band.Columns[ InventInputResult.ct_Col_CarrierCode ].Tag = InventInputResult.ct_Col_CarrierCode;
			//// �L�����A����
			//band.Columns[ InventInputResult.ct_Col_CarrierName ].Tag = InventInputResult.ct_Col_CarrierName;
			//// �n���F�R�[�h
			//band.Columns[ InventInputResult.ct_Col_SystematicColorCd ].Tag = InventInputResult.ct_Col_SystematicColorCd;
			//// �n���F����
			//band.Columns[ InventInputResult.ct_Col_SystematicColorNm ].Tag = InventInputResult.ct_Col_SystematicColorNm;
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���i�啪�ރR�[�h
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreCode ].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
			// ���i�啪�ޖ���
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreName ].Tag = InventInputResult.ct_Col_LargeGoodsGanreName;
			// ���i�����ރR�[�h
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreCode ].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
			// ���i�����ޖ���
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreName ].Tag = InventInputResult.ct_Col_MediumGoodsGanreName;
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ҃R�[�h
			//band.Columns[ InventInputResult.ct_Col_CarrierEpCode ].Tag = InventInputResult.ct_Col_CarrierEpCode;
			//// ���ƎҖ���
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Tag = InventInputResult.ct_Col_CarrierEpName;
            // �O���[�v�R�[�h
            band.Columns[ InventInputResult.ct_Col_DetailGoodsGanreCode ].Tag = InventInputResult.ct_Col_DetailGoodsGanreCode;
            // �O���[�v�R�[�h����
            band.Columns[ InventInputResult.ct_Col_DetailGoodsGanreName ].Tag = InventInputResult.ct_Col_DetailGoodsGanreName;
            // ���Е��ރR�[�h
            band.Columns[ InventInputResult.ct_Col_EnterpriseGanreCode ].Tag = InventInputResult.ct_Col_EnterpriseGanreCode;
            // ���Е��ޖ���
            band.Columns[ InventInputResult.ct_Col_EnterpriseGanreName ].Tag = InventInputResult.ct_Col_EnterpriseGanreName;
            // �a�k�i��
            band.Columns[ InventInputResult.ct_Col_BLGoodsCode ].Tag = InventInputResult.ct_Col_BLGoodsCode;
            // �a�k�i��
            band.Columns[ InventInputResult.ct_Col_BLGoodsName ].Tag = InventInputResult.ct_Col_BLGoodsName;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���Ӑ�R�[�h
			band.Columns[ InventInputResult.ct_Col_CustomerCode ].Tag = InventInputResult.ct_Col_CustomerCode;
			// ���Ӑ於��
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Tag = InventInputResult.ct_Col_CustomerName;
			// ���Ӑ於��2
			band.Columns[ InventInputResult.ct_Col_CustomerName2 ].Tag = InventInputResult.ct_Col_CustomerName2;
			// �ϑ���R�[�h
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// �ϑ��於��
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// �ϑ��於��2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d����
			//band.Columns[ InventInputResult.ct_Col_StockDate ].Tag = InventInputResult.ct_Col_StockDate;
			//// ���ד�
			//band.Columns[ InventInputResult.ct_Col_ArrivalGoodsDay ].Tag = InventInputResult.ct_Col_ArrivalGoodsDay;
            //// �����ԍ�
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Tag = InventInputResult.ct_Col_ProductNumber;
            //// ���i�d�b�ԍ�1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Tag = InventInputResult.ct_Col_StockTelNo1;
            //// �ύX�O���i�d�b�ԍ�1
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ].Tag = InventInputResult.ct_Col_BfStockTelNo1;
            //// ���i�d�b�ԍ�1�ύX�t���O
            //band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo1ChgFlg;
            //// ���i�d�b�ԍ�2
            //band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Tag = InventInputResult.ct_Col_StockTelNo2;
            //// �ύX�O���i�d�b�ԍ�2
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ].Tag = InventInputResult.ct_Col_BfStockTelNo2;
            //// ���i�d�b�ԍ�2�ύX�t���O
            //band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo2ChgFlg;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // JAN�R�[�h
			band.Columns[ InventInputResult.ct_Col_Jan ].Tag = InventInputResult.ct_Col_Jan;
			// �d���P��
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].Tag = InventInputResult.ct_Col_StockUnitPrice;
			// �ύX�O�d���P��
			band.Columns[ InventInputResult.ct_Col_BfStockUnitPrice ].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
			// �d���P���ύX�t���O
			band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
			// �݌ɋ敪
			band.Columns[ InventInputResult.ct_Col_StockDiv ].Tag = InventInputResult.ct_Col_StockDiv;
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �݌ɏ��
            //band.Columns[ InventInputResult.ct_Col_StockState ].Tag = InventInputResult.ct_Col_StockState;
            //// �ړ����
            //band.Columns[ InventInputResult.ct_Col_MoveStatus ].Tag = InventInputResult.ct_Col_MoveStatus;
            //// ���i���
            //band.Columns[InventInputResult.ct_Col_GoodsCodeStatus].Tag = InventInputResult.ct_Col_GoodsCodeStatus;
            //// ���ԊǗ��敪
			//band.Columns[ InventInputResult.ct_Col_PrdNumMngDiv ].Tag = InventInputResult.ct_Col_PrdNumMngDiv;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // �ŏI�d���N����
			band.Columns[ InventInputResult.ct_Col_LastStockDate ].Tag = InventInputResult.ct_Col_LastStockDate;
			// �݌ɐ�
			band.Columns[ InventInputResult.ct_Col_StockTotal ].Tag = InventInputResult.ct_Col_StockTotal;
			// �ϑ���R�[�h
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// �ϑ��於��
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// �ϑ��於��2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
			// �I���݌ɐ�
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Tag = InventInputResult.ct_Col_InventoryStockCnt;
			// �I���ߕs����
			band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            // �I����
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Tag = InventInputResult.ct_Col_InventoryExeDay_Str;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            // �I�������������t
			band.Columns[ InventInputResult.ct_Col_InventoryPreprDay ].Tag = InventInputResult.ct_Col_InventoryPreprDay;
			// �I��������������
			band.Columns[ InventInputResult.ct_Col_InventoryPreprTim ].Tag = InventInputResult.ct_Col_InventoryPreprTim;
			// �I�����{��
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// �I�����{��
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// �I�����{��(DateTime)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Datetime ].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
			// �I�����{��(�N ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].Tag = InventInputResult.ct_Col_InventoryDay_Year;
			// �I�����{��(�N ���x��)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
			// �I�����{��(�� ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Tag = InventInputResult.ct_Col_InventoryDay_Month;
			// �I�����{��(�� ���x��)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
			// �I�����{��(�� ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Tag = InventInputResult.ct_Col_InventoryDay_Day;
			// �I�����{��(�� ���x��)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Tag = InventInputResult.ct_Col_InventoryDay_DayL;

			// �I���X�V��
			band.Columns[ InventInputResult.ct_Col_LastInventoryUpdate ].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
			// �I���V�K�ǉ��敪
			band.Columns[ InventInputResult.ct_Col_InventoryNewDiv ].Tag = InventInputResult.ct_Col_InventoryNewDiv;
			// �I���V�K�ǉ��敪����
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].Tag = InventInputResult.ct_Col_InventoryNewDivName;
            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �}�V���݌Ɋz
            band.Columns[ InventInputResult.ct_Col_StockMashinePrice ].Tag = InventInputResult.ct_Col_StockMashinePrice;
            // �I���݌Ɋz
            band.Columns[ InventInputResult.ct_Col_InventoryStockPrice ].Tag = InventInputResult.ct_Col_InventoryStockPrice;
            // �I���ߕs�����z
            band.Columns[ InventInputResult.ct_Col_InventoryTlrncPrice ].Tag = InventInputResult.ct_Col_InventoryTlrncPrice;
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // �݌Ɉϑ�����敪
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
			// �݌Ɉϑ�����敪����
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
			// �W�v�敪
			band.Columns[ InventInputResult.ct_Col_GrossDiv ].Tag = InventInputResult.ct_Col_GrossDiv;
			// �{�^���p�J����
			band.Columns[ InventInputResult.ct_Col_Button ].Tag = InventInputResult.ct_Col_Button;
			// ���s
			band.Columns[ InventInputResult.ct_Col_RowSelf ].Tag = InventInputResult.ct_Col_RowSelf;
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �f�[�^�\��UltraGrid��������(CellActivation�v���p�e�B)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(CellActivation�v���p�e�B)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_CellActivation(UltraGridBand band)
        {
            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].CellActivation = Activation.NoEdit;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].CellActivation = Activation.NoEdit;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].CellActivation = Activation.NoEdit;
            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].CellActivation = Activation.NoEdit;
            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].CellActivation = Activation.AllowEdit;
            // �ߕs����
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].CellActivation = Activation.NoEdit;
            // �I����
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Datetime].CellActivation = Activation.NoEdit;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].CellActivation = Activation.AllowEdit;
            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].CellActivation = Activation.Disabled;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].CellActivation = Activation.AllowEdit;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].CellActivation = Activation.Disabled;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].CellActivation = Activation.AllowEdit;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].CellActivation = Activation.Disabled;
            // �{�^���p�J����
            band.Columns[InventInputResult.ct_Col_Button].CellActivation = Activation.ActivateOnly;
            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].CellActivation = Activation.AllowEdit;
            // �q��
            band.Columns[InventInputResult.ct_Col_WarehouseName].CellActivation = Activation.NoEdit;
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].CellActivation = Activation.AllowEdit;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].CellActivation = Activation.AllowEdit;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].CellActivation = Activation.AllowEdit;
            // ���[�J�[
            band.Columns[InventInputResult.ct_Col_MakerName].CellActivation = Activation.NoEdit;
            // �d���於��
            band.Columns[InventInputResult.ct_Col_SupplierName].CellActivation = Activation.NoEdit;
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].CellActivation = Activation.NoEdit;
            // No                                                                               //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_No].CellActivation = Activation.NoEdit;       //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �f�[�^�\��UltraGrid��������(CellActivation�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_CellActivation( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// ���͐ݒ�
			// ���͐ݒ� ------------------------------------------------------
			// �I���V�K�ǉ��敪
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryNewDivName );

			// �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_GoodsCode);
            SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_GoodsNo);
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<

			// �i��
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_GoodsName );

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_ProductNumber );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �݌ɐ�
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTotal );

			// �I���݌ɐ�
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryStockCnt );

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���ِ�
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryTolerancCnt );

            // �I����
            SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryExeDay_Str);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

            // �I�����{��(�N ����)
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryDay_Year );
			// �I�����{��(�N ���x��)
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryDay_YearL);
            SetCellClickAction(band.Columns, Activation.Disabled, InventInputResult.ct_Col_InventoryDay_YearL);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            // �I�����{��(�� ����)
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryDay_Month );
			// �I�����{��(�� ���x��)
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryDay_MonthL);
            SetCellClickAction(band.Columns, Activation.Disabled, InventInputResult.ct_Col_InventoryDay_MonthL);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            // �I�����{��(�� ����)
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryDay_Day );
			// �I�����{��(�� ���x��)
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryDay_DayL);
            SetCellClickAction(band.Columns, Activation.Disabled, InventInputResult.ct_Col_InventoryDay_DayL);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

			// �{�^���p�J����
			SetCellClickAction( band.Columns, Activation.ActivateOnly, InventInputResult.ct_Col_Button );

			// �d���P��
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockUnitPrice);
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockUnitPrice);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d�b�ԍ�1
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo1 );
		    //
			//// �d�b�ԍ�2
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �q��
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_WarehouseName );

            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_WarehouseShelfNo);

            // �d���I�ԂP
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_DuplicationShelfNo1);

            // �d���I�ԂQ
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_DuplicationShelfNo2);
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            
            // ���[�J�[
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_MakerName );

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ�
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_CarrierEpName );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// ���Ӑ於��
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_CustomerName );

			// �ϑ��於��
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_ShipCustomerName );

			// �݌Ɉϑ�����敪
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTrtEntDivName );
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �f�[�^�\��UltraGrid��������(Width�v���p�e�B)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(Width�v���p�e�B)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote  : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>              �I���V�K�ǉ��敪��Width�̏C��</br>
        /// </remarks>
        private void InitialInventInputGrid_Width(UltraGridBand band)
        {
            // �I���V�K�ǉ��敪
            //band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 55; // DEL 2009/12/03
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 90;  // ADD 2009/12/03
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].Width = 120;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].Width = 255;
            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Width = 100;
            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Width = 100;
            // �ߕs����
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Width = 100;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 90;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 50;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 50;
            // �{�^���p�J����
            band.Columns[InventInputResult.ct_Col_Button].Width = 20;
            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Width = 111;
            // �q��
            band.Columns[InventInputResult.ct_Col_WarehouseName].Width = 120;
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Width = 120;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Width = 120;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Width = 120;
            // ���[�J�[
            band.Columns[InventInputResult.ct_Col_MakerName].Width = 120;
            // �d���於��
            band.Columns[InventInputResult.ct_Col_SupplierName].Width = 120;
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Width = 80;
            // No                                                           //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_No].Width = 60;           //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �f�[�^�\��UltraGrid��������(Width�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Width( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// ���ݒ�

			// Todo:���ݒ�R�����g�A�E�g�� ------------------------------------------------------
			// �I���V�K�ǉ��敪
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 40;
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 55;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

			// �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].Width = 120;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Width = 120;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<

			// �i��
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Width = 255;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Width = 150;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �݌ɐ�
            //band.Columns[ InventInputResult.ct_Col_StockTotal ].Width = 60;

            //// �I���݌ɐ�
            //band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Width = 60;

            //// ���ِ�
            //band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Width = 60;

            //// �I�����{��(�N ����)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 50;
            //// �I�����{��(�N ���x��)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Width = 20;
            //// �I�����{��(�� ����)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 30;
            //// �I�����{��(�� ���x��)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Width = 20;
            //// �I�����{��(�� ����)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 30;
            //// �I�����{��(�� ���x��)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Width = 20;

            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Width = 90;

            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Width = 90;

            // �I����
            //band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Width = 120;
            
            //// �I�����{��(�N ����)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].Width = 42;
            //// �I�����{��(�N ���x��)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Width = 25;
            //// �I�����{��(�� ����)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Width = 26;
            //// �I�����{��(�� ���x��)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Width = 25;
            //// �I�����{��(�� ����)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Width = 26;
            //// �I�����{��(�� ���x��)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Width = 25;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 90;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 50;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 50;
            // �I�����{��(�N ���x��)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Width = 25;
            // �I�����{��(�� ���x��)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Width = 25;
            // �I�����{��(�� ���x��)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Width = 25;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

			// �{�^���p�J����
			band.Columns[ InventInputResult.ct_Col_Button ].Width = 20;

			// �d���P��
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_StockUnitPrice].Width = 80;
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Width = 111;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d�b�ԍ�1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Width = 120;
		    //
			//// �d�b�ԍ�2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Width = 120;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �q��
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Width = 120;

            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].Width = 120;

            // �d���I�ԂP
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].Width = 120;

            // �d���I�ԂQ
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].Width = 120;
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // ���[�J�[
			band.Columns[ InventInputResult.ct_Col_MakerName ].Width = 120;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ�
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Width = 120;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// ���Ӑ於��
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Width = 120;

			// �ϑ��於��
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Width = 120;

			// �݌Ɉϑ�����敪
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Width = 80;
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �f�[�^�\��UltraGrid��������(CellAppearance�v���p�e�B)
        /// <summary>
		/// �f�[�^�\��UltraGrid��������(CellAppearance�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_CellAppearance( UltraGridBand band )
		{
			#region// �e�L�X�g�\���ʒu
			// �e�L�X�g�\���ʒu ------------------------------------------------------
			// �݌ɐ�
			band.Columns[ InventInputResult.ct_Col_StockTotal ].CellAppearance.TextHAlign = HAlign.Right;
			// �I���݌ɐ�
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].CellAppearance.TextHAlign = HAlign.Right;
            // ���ِ�
			band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].CellAppearance.TextHAlign = HAlign.Right;
            // �ύX�O���ِ�
			band.Columns[ InventInputResult.ct_Col_BfChgInventoryToleCnt ].CellAppearance.TextHAlign = HAlign.Right;
            // �I�����{��
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].CellAppearance.TextHAlign = HAlign.Right;
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].CellAppearance.TextHAlign = HAlign.Right;
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].CellAppearance.TextHAlign = HAlign.Right;
			// �{�^���p�J����
			band.Columns[ InventInputResult.ct_Col_Button ].CellAppearance.TextHAlign = HAlign.Center;
			// �d���P��
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].CellAppearance.TextHAlign = HAlign.Right;
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �I����
            //band.Columns[ InventInputResult.ct_Col_InventoryExeDay_Datetime ].CellAppearance.TextHAlign = HAlign.Center;
            //// 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Datetime].CellAppearance.TextHAlign = HAlign.Center;
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
            //No                                                                                    //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_No].CellAppearance.TextHAlign = HAlign.Right;     //ADD 2009/05/14 �s��Ή�[13260]
            #endregion
		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(CellClickAction�v���p�e�B)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(CellClickAction�v���p�e�B)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_CellClickAction(UltraGridBand band)
        {
            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].CellClickAction = CellClickAction.CellSelect;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].CellClickAction = CellClickAction.CellSelect;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].CellClickAction = CellClickAction.CellSelect;
            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].CellClickAction = CellClickAction.CellSelect;
            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].CellClickAction = CellClickAction.EditAndSelectText;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].CellClickAction = CellClickAction.EditAndSelectText;
            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].CellClickAction = CellClickAction.CellSelect;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].CellClickAction = CellClickAction.EditAndSelectText;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].CellClickAction = CellClickAction.CellSelect;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].CellClickAction = CellClickAction.EditAndSelectText;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].CellClickAction = CellClickAction.CellSelect;
            // �{�^���p�J����
            band.Columns[InventInputResult.ct_Col_Button].CellClickAction = CellClickAction.EditAndSelectText;
            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].CellClickAction = CellClickAction.CellSelect;
            // �q��
            band.Columns[InventInputResult.ct_Col_WarehouseName].CellClickAction = CellClickAction.CellSelect;
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].CellClickAction = CellClickAction.CellSelect;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].CellClickAction = CellClickAction.CellSelect;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].CellClickAction = CellClickAction.CellSelect;
            // ���[�J�[
            band.Columns[InventInputResult.ct_Col_MakerName].CellClickAction = CellClickAction.CellSelect;
            // �d���於��
            band.Columns[InventInputResult.ct_Col_SupplierName].CellClickAction = CellClickAction.CellSelect;
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].CellClickAction = CellClickAction.CellSelect;
            // No                                                                                       //ADD 2009/05/14 �s��Ή�[13260]
            band.Columns[InventInputResult.ct_Col_No].CellClickAction = CellClickAction.CellSelect;     //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(CellClickAction�v���p�e�B)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_CellClickAction( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// CellClickAction
			// CellClickAction ------------------------------------------------------
			// ���͐ݒ� ------------------------------------------------------
			// �I���V�K�ǉ��敪
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryNewDivName );

			// �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //SetCellActivation(band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_GoodsCode);
            SetCellActivation(band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_GoodsNo);
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<

			// �i��
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_GoodsName );

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_ProductNumber );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �݌ɐ�
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTotal );

			// �I���݌ɐ�
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryStockCnt );

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���ِ�
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryTolerancCnt );
            // �I����
            //SetCellActivation(band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryExeDay_Str);
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            
            // �I�����{��(�N ����)
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryDay_Year );
			// �I�����{��(�N ���x��)
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryDay_YearL );
			// �I�����{��(�� ����)
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryDay_Month );
			// �I�����{��(�� ���x��)
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryDay_MonthL );
			// �I�����{��(�� ����)
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryDay_Day );
			// �I�����{��(�� ���x��)
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryDay_DayL );

			// �{�^���p�J����
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_Button );

			// �d���P��
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockUnitPrice );

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d�b�ԍ�1
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo1 );
		    //
			//// �d�b�ԍ�2
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �q��
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_WarehouseName );

            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_WarehouseShelfNo );

            // �d���I�ԂP
            SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_DuplicationShelfNo1 );

            // �d���I�ԂQ
            SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_DuplicationShelfNo2 );
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // ���[�J�[
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_MakerName );

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ�
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_CarrierEpName );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// ���Ӑ於��
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_CustomerName );

			// �ϑ��於��
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_ShipCustomerName );

			// �݌Ɉϑ�����敪
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTrtEntDivName );

			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �f�[�^�\��UltraGrid��������(Style�v���p�e�B�֘A)
        /// <summary>
		/// �f�[�^�\��UltraGrid��������(Style�v���p�e�B�֘A)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Style( UltraGridBand band )
		{
			#region// ��X�^�C��
 			// �{�^���p�J����
            band.Columns[ InventInputResult.ct_Col_Button ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            band.Columns[ InventInputResult.ct_Col_Button ].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            band.Columns[ InventInputResult.ct_Col_Button ].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            band.Columns[ InventInputResult.ct_Col_Button ].CellButtonAppearance.ImageHAlign = HAlign.Center;
            band.Columns[ InventInputResult.ct_Col_Button ].Header.Caption = "";
			#endregion
		}
		#endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �� �f�[�^�\��UltraGrid��������(TabStop�v���p�e�B)
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(TabStop�v���p�e�B�֘A)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_TabStop( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// TabStop

			// �\������ ------------------------------------------------------
			// �I���V�K�ǉ��敪
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].TabStop = true;

			// �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].TabStop = true;
            band.Columns[InventInputResult.ct_Col_GoodsNo].TabStop = true;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<

			// �i��
			band.Columns[ InventInputResult.ct_Col_GoodsName ].TabStop = true;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����ԍ�
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].TabStop = true;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �݌ɐ�
			band.Columns[ InventInputResult.ct_Col_StockTotal ].TabStop = true;

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���ِ�
			//band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].TabStop = true;
            //// �I����
            //band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].TabStop = true;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

			// �d���P��
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].TabStop = true;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d�b�ԍ�1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].TabStop = true;
            //
			//// �d�b�ԍ�2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].TabStop = true;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// �q��
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].TabStop = true;

            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].TabStop = true;

            // �d���I�ԂP
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].TabStop = true;

            // �d���I�ԂQ
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].TabStop = true;
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // ���[�J�[
			band.Columns[ InventInputResult.ct_Col_MakerName ].TabStop = true;

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ�
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].TabStop = true;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			// ���Ӑ�
			band.Columns[ InventInputResult.ct_Col_CustomerName ].TabStop = true;

			// �ϑ���
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].TabStop = true;

			// �݌Ɉϑ�����敪
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].TabStop = true;

            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].TabStop = true;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].TabStop = true;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].TabStop = true;

			// �I���݌ɐ�
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].TabStop = true;
			// �I�����{��(�N ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].TabStop = true;
			// �I�����{��(�� ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].TabStop = true;
			// �I�����{��(�� ����)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].TabStop = true;
			#endregion
		}
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� �f�[�^�\��UltraGrid��������(Format�v���p�e�B)
        /// <summary>
		/// �f�[�^�\��UltraGrid��������(Format�v���p�e�B�֘A)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Format( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// Format
            // �d���P��
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_StockUnitPrice].Format = "#,##0;-#,##0;0";
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Format        = "#,##0.00;-#,##0.00;0.00";

            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Format            = "#,##0.00;-#,##0.00;0.00";

            // �I����
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Format     = "#,##0.00;-#,##0.00;0.00";

            // ���ِ�
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Format = "#,##0.00;-#,##0.00;0.00";

            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Format     = "0000�N;0000�N;''";

            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Format    = "#0��;#0��;''";

            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Format      = "#0��;#0��;''";
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

		#region �� �f�[�^�\��UltraGrid��������(GroupSetting�v���p�e�B�֘A)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�\��UltraGrid��������(GroupSetting�v���p�e�B�֘A)
        /// </summary>
        /// <param name="band">�f�[�^��̃Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_GroupSetting(UltraGridBand band)
        {
            int vPosition = 1;

            // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------------------------------->>>>>
            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_No].Header.Caption = "No";
            band.Columns[InventInputResult.ct_Col_No].Header.VisiblePosition = vPosition++;
            // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------------------------------------<<<<<
            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.Caption = "�敪";
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.VisiblePosition = vPosition++;
            // ���[�J�[
            band.Columns[InventInputResult.ct_Col_MakerName].Header.Caption = "���[�J�[";
            band.Columns[InventInputResult.ct_Col_MakerName].Header.VisiblePosition = vPosition++;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.VisiblePosition = vPosition++;
            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsName].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.VisiblePosition = vPosition++;
            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.Caption = band.Columns[InventInputResult.ct_Col_StockTotal].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.VisiblePosition = vPosition++;
            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.Caption = band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.Caption;
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.VisiblePosition = vPosition++;
            // �ߕs����
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Header.Caption = band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Header.Caption;
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Header.VisiblePosition = vPosition++;
            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.Caption = "���{�� �N";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.VisiblePosition = vPosition++;
            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Header.VisiblePosition = vPosition++;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.Caption = "��";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.VisiblePosition = vPosition++;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Header.VisiblePosition = vPosition++;
            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.Caption = "��";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.VisiblePosition = vPosition++;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Header.VisiblePosition = vPosition++;
            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.Caption = band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.VisiblePosition = vPosition++;
            // �q��
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.Caption = "�q��";
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.VisiblePosition = vPosition++;
            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.Caption = "�I��";
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.VisiblePosition = vPosition++;
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.Caption = "�d���I�ԂP";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.VisiblePosition = vPosition++;
            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.Caption = "�d���I�ԂQ";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.VisiblePosition = vPosition++;
            // �d����
            band.Columns[InventInputResult.ct_Col_SupplierName].Header.Caption = "�d����";
            band.Columns[InventInputResult.ct_Col_SupplierName].Header.VisiblePosition = vPosition++;
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.Caption = "�݌ɋ敪";
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.VisiblePosition = vPosition++;

            // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------------------------------->>>>>
            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Header.Caption = "�����p�v�Z����";
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Header.VisiblePosition = vPosition++;
            // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------------<<<<<
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �f�[�^�\��UltraGrid��������(GroupSetting�v���p�e�B�֘A)
		/// </summary>
		/// <param name="band">�f�[�^��̃Z�b�g</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_GroupSetting( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            int vPosition = 1;

            // �I���V�K�ǉ��敪
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.Caption = "�敪";
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.VisiblePosition = vPosition++;

            // ���[�J�[
            band.Columns[InventInputResult.ct_Col_MakerName].Header.Caption = "���[�J�[";
            band.Columns[InventInputResult.ct_Col_MakerName].Header.VisiblePosition = vPosition++;

            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.VisiblePosition = vPosition++;

            // �i��
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsName ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.VisiblePosition = vPosition++;

            // �݌ɐ�
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.Caption = band.Columns[InventInputResult.ct_Col_StockTotal ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.VisiblePosition = vPosition++;

            // �I���݌ɐ�
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.Caption = band.Columns[InventInputResult.ct_Col_InventoryStockCnt ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.VisiblePosition = vPosition++;

            // �I�����{��(�N ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.Caption = "���{�� �N";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.VisiblePosition = vPosition++;
            // �I�����{��(�N ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Header.VisiblePosition = vPosition++;

            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.Caption = "��";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.VisiblePosition = vPosition++;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Header.VisiblePosition = vPosition++;

            // �I�����{��(�� ����)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.Caption = "��";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.VisiblePosition = vPosition++;
            // �I�����{��(�� ���x��)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Header.VisiblePosition = vPosition++;

            // �d���P��
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.Caption = band.Columns[InventInputResult.ct_Col_StockUnitPrice ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.VisiblePosition = vPosition++;

            // �q��
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.Caption = "�q��";
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.VisiblePosition = vPosition++;

            // �I��
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.Caption = "�I��";
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.VisiblePosition = vPosition++;
           
            // �d���I�ԂP
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.Caption = "�d���I�ԂP";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.VisiblePosition = vPosition++;

            // �d���I�ԂQ
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.Caption = "�d���I�ԂQ";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.VisiblePosition = vPosition++;

            // ���Ӑ�
            band.Columns[InventInputResult.ct_Col_CustomerName].Header.Caption = "�d����";
            band.Columns[InventInputResult.ct_Col_CustomerName].Header.VisiblePosition = vPosition++;

            // �ϑ���
            band.Columns[InventInputResult.ct_Col_ShipCustomerName].Header.Caption = "�ϑ���";
            band.Columns[InventInputResult.ct_Col_ShipCustomerName].Header.VisiblePosition = vPosition++;

            // �݌Ɉϑ�����敪
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.Caption = "�݌ɋ敪";
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.VisiblePosition = vPosition++;
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            #region// GroupSetting
            //Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup;
            //// �V�K�敪
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_InventoryNewDiv), "�敪");
            //ultraGridGroup = band.Groups.Add();
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryNewDiv]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryNewDivName]);
            //ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryNewDiv;

            //// 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���[�J�[
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_MakerCode), "���[�J�[");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_MakerCode]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_MakerName]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_MakerCode;
            //// 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            
            //// �i��
            //// 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            ////ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_GoodsCode), band.Columns[InventInputResult.ct_Col_GoodsCode].Header.Caption);
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_GoodsCode ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_GoodsCode;
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_GoodsNo), band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_GoodsNo]);
            //ultraGridGroup.Tag = InventInputResult.ct_Col_GoodsNo;
            //// 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<

            //// �i��
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_GoodsName ), band.Columns[InventInputResult.ct_Col_GoodsName ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_GoodsName ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_GoodsName;

            //// 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// �����ԍ�
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_ProductNumber ), band.Columns[InventInputResult.ct_Col_ProductNumber ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ProductNumber ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_ProductNumber;
            //// 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //// 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// �P��
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockUnitPrice ), band.Columns[InventInputResult.ct_Col_StockUnitPrice ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockUnitPrice ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_StockUnitPrice;
            //// 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<

            //// ���됔
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTotal ), band.Columns[InventInputResult.ct_Col_StockTotal ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTotal ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTotal;

            //// �I���݌ɐ�
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_InventoryStockCnt ), band.Columns[InventInputResult.ct_Col_InventoryStockCnt ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryStockCnt;

            //// 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// ���ِ�
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_InventoryTolerancCnt ), band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfChgInventoryToleCnt ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            //// 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<

            //// �I�����{��
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_InventoryDay), band.Columns[InventInputResult.ct_Col_InventoryDay].Header.Caption);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Year]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_YearL]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Month]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Day]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_DayL]);
            //ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryDay;

            //ultraGridGroup.CellAppearance.BorderColor = Color.FromArgb(1, 68, 208);

            //// 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �P��
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockUnitPrice ), band.Columns[InventInputResult.ct_Col_StockUnitPrice ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockUnitPrice ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockUnitPrice;

            ////// �I����
            ////ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_InventoryExeDay_Str), band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Header.Caption);
            ////ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str]);
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryExeDay_Str;
            //// 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            //// 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// �d�b�ԍ�1
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo1 ), band.Columns[InventInputResult.ct_Col_StockTelNo1 ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo1 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo1;
            ////
            ////// �d�b�ԍ�2
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo2 ), band.Columns[InventInputResult.ct_Col_StockTelNo2 ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo2 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo2;
            //// 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //// �q��
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_WarehouseCode ), "�q��" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_WarehouseCode ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_WarehouseName ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_WarehouseCode;

            //// 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// �I��
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_WarehouseShelfNo), "�I��");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_WarehouseShelfNo]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_WarehouseShelfNo;

            //// �d���I�ԂP
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_DuplicationShelfNo1), "�d���I�ԂP");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_DuplicationShelfNo1;

            //// �d���I�ԂQ
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_DuplicationShelfNo2), "�d���I�ԂQ");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            //// 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            //// 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// ���[�J�[
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_MakerCode ), "���[�J�[" );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_MakerCode ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_MakerName ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_MakerCode;
            //// 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<

            //// 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// ���Ǝ�
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_CarrierEpCode ), "���Ǝ�" );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CarrierEpCode ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CarrierEpName ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_CarrierEpCode;
            //// 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            //// �d����
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_CustomerCode ), "�d����" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CustomerCode ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CustomerName ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CustomerName2 ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_CustomerCode;

            //// �ϑ���
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_ShipCustomerCode ), "�ϑ���" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ShipCustomerName ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_CustomerCode;

            //// �݌Ɉώ���敪
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTrtEntDiv ), "�݌ɋ敪" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTrtEntDiv;
			#endregion
            // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region [Grid�ߕs���X�V�ςݍsEnable����]
        // -- ADD 2009/09/11 ------------------------------------>>>
        /// <summary>
        /// Grid�ߕs���X�V�ςݍsEnable����
		/// </summary>
        private void SetGridEnabledTolUpd()
        {
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                // �ߕs���X�V�ς݂̃��R�[�h�͕ҏW�s�Ƃ���
                if ((Int32)gridRow.Cells[InventInputResult.ct_Col_ToleranceUpdateCd].Value == 1)
                {
                    gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_StockUnitPrice].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo1].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo2].Activation = Activation.NoEdit;
                }
                else
                {
                    gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_StockUnitPrice].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo1].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo2].Activation = Activation.AllowEdit;
                }
            }
        }
        // -- ADD 2009/09/11 ------------------------------------<<<
        #endregion

        #region �� �o�[�R�[�h���͎�����
        #region �� �o�[�R�[�h���̓��C������
        /// <summary>
		/// �o�[�R�[�h���̓��C������
		/// </summary>
		private int ReadBarCodeMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			try
			{
				// �W�J�pDictionary�̍쐬
				Dictionary<Guid, InventoryStockInputBarCode> barCodeDic = MakeReadBarCodeDictionary();
				// ��ʌĂяo��
				if ( this._readBarcodeForm == null )
				{
					this._readBarcodeForm = new MAZAI05140UA();
				}

				DialogResult dlgResult = this._readBarcodeForm.ShowDialog( this, ref barCodeDic );
				// �f�[�^�W�J
				if ( dlgResult == DialogResult.OK )
				{
					//this.uGrid_InventInput.BeginUpdate();

					Dictionary<Guid, InventoryStockInputBarCode> newBarCodeDic = new Dictionary<Guid,InventoryStockInputBarCode>();
					// �f�[�^�W�J
					// DataView divDataDv; // 2007.07.19 kubo del
					DataRow divDataDr;
					InventoryStockInputBarCode isiBarCode;
					Guid keyGuid;

					// 2007.07.27 kubo add -------------->
					double addnewRowCnt = 0; 
					double defInventStock = 0; 
					// 2007.07.27 kubo add <--------------

					foreach( KeyValuePair<Guid, InventoryStockInputBarCode> dic in barCodeDic )
					{
						keyGuid = (Guid)dic.Key;
						isiBarCode = (InventoryStockInputBarCode)dic.Value;

						// �f�[�^���V�K�s�Ȃ�ΐV�K�sDictionary�ɒǉ�����continue�B
						if ( isiBarCode.Status == 1 )
						{
							newBarCodeDic.Add( keyGuid, isiBarCode );
							continue;
						}

						// �Ώۍs�̎擾(Guid�͈�ӂ̂��̂Ȃ̂ŁAGuid�����w�肷���OK!)
						#region // 2007.07.19 kubo del
						//divDataDv = new DataView( 
						//    this._inventInputAcs.InventDataTable, 
						//    string.Format("{0}='{1}'", InventInputResult.ct_Col_ProductStockGuid, keyGuid ),
						//    "", DataViewRowState.CurrentRows );

						//// �Y���s��������Ȃ��Ƃ��͏I��
						//if ( divDataDv.Count <= 0 )
						//{
						//    continue;
						//}
						#endregion

						// 2007.07.19 kubo add --------------------------->
						#region // 2007.07.30 kubo del
						//this._inventInputView.RowFilter = string.Format("{0}='{1}'", InventInputResult.ct_Col_key, keyGuid );
						#endregion
						// 2007.07.30 kubo add ------>
						this._inventInputView.RowFilter = string.Format("{0}='{1}' and {2}={3}", InventInputResult.ct_Col_key, keyGuid, InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0 );
						// 2007.07.30 kubo add <------
						this._inventInputView.Sort = "";
						this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

						if ( this._inventInputView.Count <= 0 )
							continue;
						// 2007.07.19 kubo add <---------------------------

						// DataRow�擾
						#region // 2007.07.19 kubo del
						// divDataDr = divDataDv[0].Row;			
						#endregion
						divDataDr = this._inventInputView[0].Row;	// 2007.07.19 kubo add 

						// 2007.07.27 kubo add ----------->
						if ( divDataDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
							defInventStock = (double)divDataDr[InventInputResult.ct_Col_InventoryStockCnt];
						else
							defInventStock = 0;

						// �I���������됔��菬���������炻�̂܂܁A�傫��������V�K�Œǉ�
						if ( isiBarCode.InventoryStockCnt <= isiBarCode.StockTotal )
						{
							// �I�����W�J
							divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.InventoryStockCnt;
							addnewRowCnt = 0;
						}
						else
						{
							// ���됔=0 (�V�K�f�[�^)�̔��f
							if ( isiBarCode.StockTotal == 0 )
							{
								// ���Ƃ��Ƃ̒I�������A���Ă����I�������傫���ꍇ�͐V�K�ǉ�
								if ( defInventStock > isiBarCode.InventoryStockCnt )
								{
									// �I�����W�J
									divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.InventoryStockCnt;
									addnewRowCnt = defInventStock - isiBarCode.InventoryStockCnt - isiBarCode.StockTotal;
								}
								else
								{
									// �I�����W�J
									divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.InventoryStockCnt;
									addnewRowCnt = 0;
								}
							}
							else
							{
								// �I�����W�J
								divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.StockTotal;
								addnewRowCnt = isiBarCode.InventoryStockCnt - isiBarCode.StockTotal;
							}
						}
						// 2007.07.27 kubo add <-----------

						// �I����e�E�q�ɓW�J
						bool isShowProduct = false;
						AfterInputInventryToleCnt( ref divDataDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );
						AfterInputInventoryDate( ref divDataDr, this.tde_InventoryDate.GetDateTime() );

						this.uGrid_InventInput.EndUpdate();

						// 2007.07.27 kubo add ----------->
						if ( addnewRowCnt > 0 )
						{
							InventoryDataUpdateWork invUpdateWork = new InventoryDataUpdateWork();
							CreateInventUpdateWorkFromRow( out invUpdateWork, divDataDr );
							invUpdateWork.InventoryStockCnt = addnewRowCnt;
							invUpdateWork.StockTotal = 0;
							NewInventProc( invUpdateWork, false, true );
						}
						// 2007.07.27 kubo add <-----------

					}
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
			}
			catch( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				MsgDispProc( "�o�[�R�[�h�Ǎ��f�[�^�̓W�J�Ɏ��s���܂����B", status, "ReadBarCodeMain",ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
				if ( this.uGrid_InventInput.IsUpdating )
					this.uGrid_InventInput.EndUpdate();
			}

			return status;
		}

		#endregion

		#region �� �o�[�R�[�h���̓��C������
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �o�[�R�[�h���̓��C������
		/// </summary>
		/// <returns>�o�[�R�[�h���͗p����</returns>
		private Dictionary<Guid, InventoryStockInputBarCode> MakeReadBarCodeDictionary()
		{
			Dictionary<Guid, InventoryStockInputBarCode> barCodeDic = new Dictionary<Guid,InventoryStockInputBarCode>();
			// �\���\�f�[�^��DataView���쐬
			// �@�E�\���\�f�[�^
			//   �E���ԊǗ��L�̃O���X�f�[�^�͓n���Ȃ�
			string sortOrder = "";
			// �\�[�g������
			switch ( (int)this.tce_SortOrder.SelectedItem.DataValue )
			{
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //case (int)InventInputSearchCndtn.SortOrderState.CarrierEP:		// �q��-���Ǝ�-���i-����
				//	sortOrder = ct_SortOrder_CarrierEp;
				//	break;
				//case (int)InventInputSearchCndtn.SortOrderState.Customer:		// �q��-�d����-���i-����
				//	sortOrder = ct_SortOrder_Customer;
				//	break;
				//case (int)InventInputSearchCndtn.SortOrderState.ShipCustomer:	// �q��-�ϑ���-���i-����
				//	sortOrder = ct_SortOrder_ShipCustomer;
				//	break;
				//default:														// �q��-���i-����
				//	sortOrder = ct_SortOrder_Goods;
				//	break;
                // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                //case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:		// �q�Ɂ��I��
                //    sortOrder = ct_SortOrder_ShelfNo;
                //    break;
                case (int)InventInputSearchCndtn.SortOrderState.SNo_GoodsDiv:	// �q�Ɂ��I�ԁ����[�J�[�����i�敪�����i
                    sortOrder = ct_SortOrder_GoodsDiv;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.SNo_Goods:		// �q�Ɂ��I�ԁ����[�J�[�����i
                    sortOrder = ct_SortOrder_Goods;
                    break;
                // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                case (int)InventInputSearchCndtn.SortOrderState.Customer:		// �q�Ɂ��d����
					sortOrder = ct_SortOrder_Customer;
					break;
				case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// �q�Ɂ��a�k�R�[�h
					sortOrder = ct_SortOrder_BLGoods;
					break;
				case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // �q�Ɂ����[�J�[
					sortOrder = ct_SortOrder_Maker;
					break;
                case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // �q�Ɂ��d���恨�I��
					sortOrder = ct_SortOrder_Cus_ShelfNo;
					break;
				case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // �q�Ɂ��d���恨���[�J�[
					sortOrder = ct_SortOrder_Cus_Maker;
					break;
				default:														// �q�Ɂ��I��
					sortOrder = ct_SortOrder_ShelfNo;
					break;
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
			}

			#region // 2007.07.19 kubo del
			//DataView barCodeView = new DataView( this._inventInputAcs.InventDataTable, ct_Filter_Product, sortOrder, DataViewRowState.CurrentRows );
			#endregion
			//// 2007.07.19 kubo add ------------------>
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._inventInputView.RowFilter = ct_Filter_Product;
            this._inventInputView.RowFilter = ct_Filter_Goods;
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            this._inventInputView.Sort = sortOrder;
			this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
			//// 2007.07.19 kubo add <------------------

			InventoryStockInputBarCode invStkInpBarCode;
			Guid rowGuid;
			#region // 2007.07.19 kubo del
			//for( int index = 0; index < barCodeView.Count; index++ )
			//{
			//    //rowGuid = (Guid)barCodeView[index][InventInputResult.ct_Col_ProductStockGuid];	// 2007.07.20 kubo del
			//    rowGuid = (Guid)barCodeView[index][InventInputResult.ct_Col_key];		// 2007.07.20 kubo add
			//    invStkInpBarCode = new InventoryStockInputBarCode();
			//    invStkInpBarCode.RowGuid			= rowGuid;// �s����GUID
			//    invStkInpBarCode.InventorySeqNo		= (Int32)barCodeView[index][InventInputResult.ct_Col_InventorySeqNo];// �I���ʔ�
			//    invStkInpBarCode.Jan				= (string)barCodeView[index][InventInputResult.ct_Col_Jan];// JAN�R�[�h
			//    invStkInpBarCode.ProductNumber		= (string)barCodeView[index][InventInputResult.ct_Col_ProductNumber];// �����ԍ�
			//    invStkInpBarCode.StockTotal			= (Double)barCodeView[index][InventInputResult.ct_Col_StockTotal];// �݌ɑ���
			//    if ( barCodeView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value )
			//        invStkInpBarCode.InventoryStockCnt	= 0;// �I���݌ɐ�
			//    else
			//        invStkInpBarCode.InventoryStockCnt	= (Double)barCodeView[index][InventInputResult.ct_Col_InventoryStockCnt];// �I���݌ɐ�
			//    invStkInpBarCode.MakerCode			= (Int32)barCodeView[index][InventInputResult.ct_Col_MakerCode];// ���[�J�[�R�[�h
			//    invStkInpBarCode.MakerName			= (string)barCodeView[index][InventInputResult.ct_Col_MakerName];// ���[�J�[����
			//    invStkInpBarCode.GoodsCode			= (string)barCodeView[index][InventInputResult.ct_Col_GoodsCode];// �i��
			//    invStkInpBarCode.GoodsName			= (string)barCodeView[index][InventInputResult.ct_Col_GoodsName];// �i��
			//    invStkInpBarCode.WarehouseCode		= (string)barCodeView[index][InventInputResult.ct_Col_WarehouseCode];// �q�ɃR�[�h
			//    invStkInpBarCode.WarehouseName		= (string)barCodeView[index][InventInputResult.ct_Col_WarehouseName];// �q�ɖ���
			//    invStkInpBarCode.CarrierEpCode		= (Int32)barCodeView[index][InventInputResult.ct_Col_CarrierEpCode];// ���Ǝ҃R�[�h
			//    invStkInpBarCode.CarrierEpName		= (string)barCodeView[index][InventInputResult.ct_Col_CarrierEpName];// ���ƎҖ���
			//    invStkInpBarCode.CustomerCode		= (Int32)barCodeView[index][InventInputResult.ct_Col_CustomerCode];// ���Ӑ�R�[�h
			//    invStkInpBarCode.CustomerName		= (string)barCodeView[index][InventInputResult.ct_Col_CustomerName];// ���Ӑ於��
			//    invStkInpBarCode.CustomerName2		= (string)barCodeView[index][InventInputResult.ct_Col_CustomerName2];// ���Ӑ於��2
			//    invStkInpBarCode.ShipCustomerCode	= (Int32)barCodeView[index][InventInputResult.ct_Col_ShipCustomerCode];// �o�א擾�Ӑ�R�[�h
			//    invStkInpBarCode.ShipCustomerName	= (string)barCodeView[index][InventInputResult.ct_Col_ShipCustomerName];// �o�א擾�Ӑ於��
			//    invStkInpBarCode.ShipCustomerName2	= (string)barCodeView[index][InventInputResult.ct_Col_ShipCustomerName2];// �o�א擾�Ӑ於��2
			//    invStkInpBarCode.StockTrtEntDiv		= (Int32)barCodeView[index][InventInputResult.ct_Col_StockTrtEntDiv];// �݌ɋ敪
			//    invStkInpBarCode.StockTrtEntName	= (string)barCodeView[index][InventInputResult.ct_Col_StockTrtEntDivName];// �݌ɋ敪����
			//    invStkInpBarCode.StockUnitPrice		= (Int64)barCodeView[index][InventInputResult.ct_Col_StockUnitPrice];// �d���P��
			//    invStkInpBarCode.Status				= 0;// �X�e�[�^�X

			//    barCodeDic.Add( rowGuid, invStkInpBarCode );
			//}
			#endregion

			//// 2007.07.19 kubo add ------------->
			for ( int index = 0; index < _inventInputView.Count; index++ )
			{
			    rowGuid = (Guid)_inventInputView[index][InventInputResult.ct_Col_key];
			    invStkInpBarCode = new InventoryStockInputBarCode();
			    invStkInpBarCode.RowGuid			= rowGuid;// �s����GUID
			    invStkInpBarCode.InventorySeqNo		= (Int32)this._inventInputView[index][InventInputResult.ct_Col_InventorySeqNo];// �I���ʔ�
			    invStkInpBarCode.Jan				= (string)this._inventInputView[index][InventInputResult.ct_Col_Jan];// JAN�R�[�h
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //invStkInpBarCode.ProductNumber = (string)this._inventInputView[index][InventInputResult.ct_Col_ProductNumber];// �����ԍ�
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                invStkInpBarCode.StockTotal = (Double)this._inventInputView[index][InventInputResult.ct_Col_StockTotal];// �݌ɑ���
			    if ( this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value )
			        invStkInpBarCode.InventoryStockCnt	= 0;// �I���݌ɐ�
			    else
			        invStkInpBarCode.InventoryStockCnt	= (Double)this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt];// �I���݌ɐ�
			    invStkInpBarCode.MakerCode			= (Int32)this._inventInputView[index][InventInputResult.ct_Col_MakerCode];// ���[�J�[�R�[�h
			    invStkInpBarCode.MakerName			= (string)this._inventInputView[index][InventInputResult.ct_Col_MakerName];// ���[�J�[����
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //invStkInpBarCode.GoodsCode        = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsCode];// �i��
                invStkInpBarCode.GoodsCode          = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsNo];// �i��
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                invStkInpBarCode.GoodsName          = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsName];// �i��
			    invStkInpBarCode.WarehouseCode		= (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseCode];// �q�ɃR�[�h
			    invStkInpBarCode.WarehouseName		= (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseName];// �q�ɖ���
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
//                invStkInpBarCode.WarehouseShelfNo   = (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseShelfNo];// �I��
//                invStkInpBarCode.DuplicationShelfNo1= (string)this._inventInputView[index][InventInputResult.ct_Col_DuplicationShelfNo1];// �d���I�ԂP
//                invStkInpBarCode.DuplicationShelfNo2= (string)this._inventInputView[index][InventInputResult.ct_Col_DuplicationShelfNo2];// �d���I�ԂQ
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //invStkInpBarCode.CarrierEpCode        = (Int32)this._inventInputView[index][InventInputResult.ct_Col_CarrierEpCode];// ���Ǝ҃R�[�h
			    //invStkInpBarCode.CarrierEpName		= (string)this._inventInputView[index][InventInputResult.ct_Col_CarrierEpName];// ���ƎҖ���
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                invStkInpBarCode.CustomerCode       = (Int32)this._inventInputView[index][InventInputResult.ct_Col_CustomerCode];// ���Ӑ�R�[�h
			    invStkInpBarCode.CustomerName		= (string)this._inventInputView[index][InventInputResult.ct_Col_CustomerName];// ���Ӑ於��
			    invStkInpBarCode.CustomerName2		= (string)this._inventInputView[index][InventInputResult.ct_Col_CustomerName2];// ���Ӑ於��2
			    invStkInpBarCode.ShipCustomerCode	= (Int32)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerCode];// �o�א擾�Ӑ�R�[�h
			    invStkInpBarCode.ShipCustomerName	= (string)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerName];// �o�א擾�Ӑ於��
			    invStkInpBarCode.ShipCustomerName2	= (string)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerName2];// �o�א擾�Ӑ於��2
			    invStkInpBarCode.StockTrtEntDiv		= (Int32)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDiv];// �݌ɋ敪
			    invStkInpBarCode.StockTrtEntName	= (string)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDivName];// �݌ɋ敪����
                invStkInpBarCode.StockUnitPrice     = (Int64)this._inventInputView[index][InventInputResult.ct_Col_StockUnitPrice];// �d���P��
			    invStkInpBarCode.Status				= 0;// �X�e�[�^�X

			    barCodeDic.Add( rowGuid, invStkInpBarCode );
			}
			//// 2007.07.19 kubo add <-------------
			return barCodeDic;
			
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�[�R�[�h���̓��C������
        /// </summary>
        /// <returns>�o�[�R�[�h���͗p����</returns>
        private Dictionary<Guid, InventoryStockInputBarCode> MakeReadBarCodeDictionary()
        {
            Dictionary<Guid, InventoryStockInputBarCode> barCodeDic = new Dictionary<Guid, InventoryStockInputBarCode>();
            // �\���\�f�[�^��DataView���쐬
            // �@�E�\���\�f�[�^
            //   �E���ԊǗ��L�̃O���X�f�[�^�͓n���Ȃ�
            string sortOrder = "";
            // �\�[�g������
            switch ((int)this.tce_SortOrder.SelectedItem.DataValue)
            {
                case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:	    // �q�Ɂ��I��
                    sortOrder = ct_SortOrder_ShelfNo;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Customer:		// �q�Ɂ��d����
                    sortOrder = ct_SortOrder_Supplier;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// �q�Ɂ��a�k�R�[�h
                    sortOrder = ct_SortOrder_BLGoods;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.BLGroup:    	// �q�Ɂ��O���[�v�R�[�h
                    sortOrder = ct_SortOrder_BLGroup;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // �q�Ɂ����[�J�[
                    sortOrder = ct_SortOrder_Maker;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // �q�Ɂ��d���恨�I��
                    sortOrder = ct_SortOrder_Sup_ShelfNo;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // �q�Ɂ��d���恨���[�J�[
                    sortOrder = ct_SortOrder_Sup_Maker;
                    break;
                default:														// �q�Ɂ��I��
                    sortOrder = ct_SortOrder_ShelfNo;
                    break;
            }

            this._inventInputView.RowFilter = ct_Filter_Goods;
            this._inventInputView.Sort = sortOrder;
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            InventoryStockInputBarCode invStkInpBarCode;
            Guid rowGuid;

            for (int index = 0; index < _inventInputView.Count; index++)
            {
                rowGuid = (Guid)_inventInputView[index][InventInputResult.ct_Col_key];
                invStkInpBarCode = new InventoryStockInputBarCode();
                // �s����GUID
                invStkInpBarCode.RowGuid = rowGuid;
                // �I���ʔ�
                invStkInpBarCode.InventorySeqNo = (Int32)this._inventInputView[index][InventInputResult.ct_Col_InventorySeqNo];
                // JAN�R�[�h
                invStkInpBarCode.Jan = (string)this._inventInputView[index][InventInputResult.ct_Col_Jan];
                // �݌ɑ���
                invStkInpBarCode.StockTotal = (Double)this._inventInputView[index][InventInputResult.ct_Col_StockTotal];
                // �I���݌ɐ�
                if (this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
                {
                    invStkInpBarCode.InventoryStockCnt = 0;
                }
                else
                {
                    invStkInpBarCode.InventoryStockCnt = (Double)this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt];
                }
                // ���[�J�[�R�[�h
                invStkInpBarCode.MakerCode = (Int32)this._inventInputView[index][InventInputResult.ct_Col_MakerCode];
                // ���[�J�[����
                invStkInpBarCode.MakerName = (string)this._inventInputView[index][InventInputResult.ct_Col_MakerName];
                // �i��
                invStkInpBarCode.GoodsCode = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsNo];
                // �i��
                invStkInpBarCode.GoodsName = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsName];
                // �q�ɃR�[�h
                invStkInpBarCode.WarehouseCode = (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseCode];
                // �q�ɖ���
                invStkInpBarCode.WarehouseName = (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseName];
                // �d����R�[�h
                invStkInpBarCode.CustomerCode = (Int32)this._inventInputView[index][InventInputResult.ct_Col_SupplierCode];
                // �d���於��
                invStkInpBarCode.CustomerName = (string)this._inventInputView[index][InventInputResult.ct_Col_SupplierName];
                // �d���於��2
                invStkInpBarCode.CustomerName2 = (string)this._inventInputView[index][InventInputResult.ct_Col_SupplierName2];
                // �o�א擾�Ӑ�R�[�h
                invStkInpBarCode.ShipCustomerCode = (Int32)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerCode];
                // �݌ɋ敪
                invStkInpBarCode.StockTrtEntDiv = (Int32)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDiv];
                // �݌ɋ敪����
                invStkInpBarCode.StockTrtEntName = (string)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDivName];
                // �d���P��
                invStkInpBarCode.StockUnitPrice = (Int64)this._inventInputView[index][InventInputResult.ct_Col_StockUnitPrice];
                // �X�e�[�^�X
                invStkInpBarCode.Status = 0;

                barCodeDic.Add(rowGuid, invStkInpBarCode);
            }
            return barCodeDic;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		#endregion

		#region �� �o�[�R�[�h���̓f�[�^�W�J���� // 2007.07.20 kubo del ���g�p�̂��߃R�����g�A�E�g
		///// <summary>
		///// 
		///// </summary>
		///// <param name="barcodeDic"></param>
		//private void DivReadBarcodeData( Dictionary<Guid, InventoryStockInputBarCode> barcodeDic )
		//{
		//    // Todo:�W�J�������L�q
		//    // DataView barCodeView; // �W�J�Ώ�Row
		//    InventoryStockInputBarCode invStkInpBarCode;
		//    Guid retGuid;
		//    //Guid r
		//    foreach( KeyValuePair<Guid, InventoryStockInputBarCode> retDic in barcodeDic )
		//    {
		//        retGuid = retDic.Key;
		//        invStkInpBarCode = retDic.Value;

		//        if ( invStkInpBarCode.Status != 0 )
		//        {
		//            continue;
		//        }
		//        else
		//        {
		//            // �X�V�s�̎擾(Guid�Ŏw�肷�邩�猋�ʂ͕K���P�s�ɂȂ�)
		//            #region // 2007.07.19 kubo del
		//            //barCodeView = new DataView( 
		//            //    this._inventInputAcs.InventDataTable, 
		//            //    string.Format("{0}={1}", InventInputResult.ct_Col_ProductStockGuid, retGuid),
		//            //    "", 
		//            //    DataViewRowState.CurrentRows );
		//            #endregion

		//            // 2007.07.19 kubo add ------------->
		//            //this._inventInputView.RowFilter = string.Format("{0}={1}", InventInputResult.ct_Col_ProductStockGuid, retGuid);
		//            this._inventInputView.RowFilter = string.Format("{0}={1}", InventInputResult.ct_Col_key, retGuid);
		//            this._inventInputView.Sort = "";
		//            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
		//            // 2007.07.19 kubo add ------------->


		//            #region // 2007.07.19 kubo del
		//            //if ( barCodeView.Count == 1 )
		//            //{
		//            //    // �I���݌ɐ�
		//            //    barCodeView[0][InventInputResult.ct_Col_InventoryStockCnt] = invStkInpBarCode.InventoryStockCnt;
		//            //    // ���ِ�
		//            //    barCodeView[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
		//            //        (double)barCodeView[0][InventInputResult.ct_Col_InventoryStockCnt] - (double)barCodeView[0][InventInputResult.ct_Col_StockTotal];

		//            //    // ���Ԃ̐e�f�[�^�ɍ��ِ������Z
		//            //    // �e�ɔ��f����Ƃ����ِ��ƒ��됔�͊֌W�Ȃ�����[���Œ�
		//            //    DataRow dr = barCodeView[0].Row;
		//            //    ChangeCommitToleranceCnt( ref dr, 0, 0, true );

		//            //}
		//            #endregion
		//            if ( this._inventInputView.Count == 1 )
		//            {
		//                // �I���݌ɐ�
		//                this._inventInputView[0][InventInputResult.ct_Col_InventoryStockCnt] = invStkInpBarCode.InventoryStockCnt;
		//                // ���ِ�
		//                this._inventInputView[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
		//                    (double)this._inventInputView[0][InventInputResult.ct_Col_InventoryStockCnt] - (double)this._inventInputView[0][InventInputResult.ct_Col_StockTotal];

		//                // ���Ԃ̐e�f�[�^�ɍ��ِ������Z
		//                // �e�ɔ��f����Ƃ����ِ��ƒ��됔�͊֌W�Ȃ�����[���Œ�
		//                DataRow dr = this._inventInputView[0].Row;
		//                ChangeCommitToleranceCnt( ref dr, 0, 0, true );

		//            }

		//        }
		//    }
		//}
		#endregion
		#endregion
	
		#region �� �V�K�������C��
		/// <summary>
		/// �V�K�������C��
		/// </summary>
		/// <returns></returns>
		private int NewInventProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			try
			{
				if ( this._createNewInventForm == null )
				{
					this._createNewInventForm = new MAZAI05130UD();
					this._createNewInventForm.EnterpriseCode = this._enterpriseCode;
					this._createNewInventForm.SectionCode = this._sectionCode;
				}
				InventoryDataUpdateWork invUpdWork = new InventoryDataUpdateWork();
				invUpdWork.EnterpriseCode = this._enterpriseCode;
				invUpdWork.SectionCode = this._sectionCode;
//				invUpdWork.SectionGuideNm = this._sectionName;
                // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
                // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //// �I�����ݒ�
                //invUpdWork.InventoryDay = this.tde_InventoryExeDate.GetDateTime();
                // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // �I�����ݒ�
                invUpdWork.InventoryDate = this.tde_InventoryExeDate.GetDateTime();
                // �I�����{���ݒ�
                invUpdWork.InventoryDay = this.tde_InventoryDate.GetDateTime();
                // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
                
				DialogResult dlgRes = this._createNewInventForm.ShowEditor( ref invUpdWork, (int)MAZAI05130UD.DispModeState.CreateNew );

				switch ( dlgRes )
				{
					case DialogResult.OK:
                        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                        status = this._inventInputAcs.CheckRecord(invUpdWork);
                        if (status != 0)
                        {
                            this.MsgDispProc("�I���f�[�^���d�����Ă܂��B", status, "NewInventProc", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                            return status;
                        }
                        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

						this._defProdNumList.Add( invUpdWork );
						status = NewInventProc( invUpdWork, true, true);


						break;
					default :
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
				}
			}
			catch( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "�I���f�[�^�̐V�K�쐬�Ɏ��s���܂����B", status, "NewInventProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
			}
			return status;
		}
		#endregion

		#region �� �V�K�������C��
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �V�K�������C��(�V�K��ʔ�\��)
		/// </summary>
		/// <param name="invUpdWork">�V�K�f�[�^</param>
		/// <param name="isProductInput">���ԓ��͉�ʋN���敪(true:�N������, false:�N�����Ȃ�)</param>
		/// <param name="isSelectRow">�s�I���t���O(true:�I������, false:�I�����Ȃ�</param>
		/// <returns></returns>
		private int NewInventProc( InventoryDataUpdateWork invUpdWork, bool isProductInput, bool isSelectRow )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				ArrayList invUpdWorkList;

                // �V�K�s�쐬
				CreateNewInvent( invUpdWork, out invUpdWorkList );

				// ���Ԑݒ��ʋN��
                if (this._productNumInput == null)
                {
                    this._productNumInput = new ProductNumInput();
                }

				this.uGrid_InventInput.BeginUpdate();

                if (invUpdWorkList.Count <= 0)
                {
                    return (status);
                }

                //--------------------------------------
				// �ǉ����L��ꍇ�̓e�[�u���ɓW�J����
                //--------------------------------------

                string errMsg = "";
                string warehouseCode;
                string goodsNo;
                int makerCode;
                int supplierCode;
                int stockDiv;

                status = this._inventInputAcs.DevSearchResult(invUpdWorkList, (int)InventInputSearchCndtn.ChangeFlagState.Change, ref errMsg, true);
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        if (isSelectRow == false)
                        {
                            break;
                        }

                        invUpdWork = invUpdWorkList[0] as InventoryDataUpdateWork;

                        int rowCount = 0;
                        this.uGrid_InventInput.ActiveRow = null;
                        for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                        {
                            // �q�ɃR�[�h
                            warehouseCode = this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd();
                            // �i��
                            goodsNo = this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd();
                            // ���[�J�[�R�[�h
                            makerCode = (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value;
                            // �d����R�[�h
                            supplierCode = (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_SupplierCode].Value;
                            // �݌ɋ敪
                            stockDiv = (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockDiv].Value;

                            if ((warehouseCode == invUpdWork.WarehouseCode.ToString().TrimEnd()) && (makerCode == invUpdWork.GoodsMakerCd) &&
                                (goodsNo == invUpdWork.GoodsNo.ToString().TrimEnd()) && (supplierCode == invUpdWork.SupplierCd) &&
                                (stockDiv == invUpdWork.StockDiv))
                            {
                                if (rowCount == 0)
                                {
                                    rowCount = gridIndex;
                                    this.uGrid_InventInput.Selected.Rows.Clear();

                                    if (this.uGrid_InventInput.ActiveRow == null)
                                    {
                                        this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                    }

                                    this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                    this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;
                                }

                                this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);
                            }
                        }

                        // �X�N���[��
                        if (this.uGrid_InventInput.Selected.Rows.Count > 0)
                        {
                            this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.Selected.Rows[0];
                        }

                        break;
                    default:
                        this.MsgDispProc(errMsg, status, "NewInventProc", emErrorLevel.ERR_LEVEL_STOPDISP);
                        break;
                }
			}
			finally
			{
				this.uGrid_InventInput.EndUpdate();
			}
			return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �V�K�������C��(�V�K��ʔ�\��)
        /// </summary>
        /// <param name="invUpdWork">�V�K�f�[�^</param>
        /// <param name="isProductInput">���ԓ��͉�ʋN���敪(true:�N������, false:�N�����Ȃ�)</param>
        /// <param name="isSelectRow">�s�I���t���O(true:�I������, false:�I�����Ȃ�</param>
        /// <returns></returns>
        private int NewInventProc(InventoryDataUpdateWork invUpdWork, bool isProductInput, bool isSelectRow)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                ArrayList invUpdWorkList;
                CreateNewInvent(invUpdWork, out invUpdWorkList);

                // 2007.07.26 kubo add --------------->
                // ���Ԑݒ��ʋN��
                if (this._productNumInput == null)
                    this._productNumInput = new ProductNumInput();

                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //ArrayList productNumList = null;
                //
                //int prdStatus = 0;
                //// ���ԓ��͉�ʋN������
                //// ���ԊǗ��敪�F�Ǘ����� ���� ���Ԗ����� ���� �I�������[�����傫���A�N���敪�F�N������̂Ƃ�
                //if ( invUpdWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product && 
                //	invUpdWork.ProductNumber.TrimEnd() == "" &&
                //	invUpdWork.InventoryStockCnt > 1 && 
                //	isProductInput)
                //{
                //	this._productNumInput.DefPrdTelList = this._defProdNumList;
                //	prdStatus = this._productNumInput.ShowProductInventInput( out productNumList, invUpdWork.InventoryStockCnt, this );
                //
                //	if ( productNumList != null && prdStatus == 0 )
                //	{
                //		for( int localIndex = 0; localIndex < productNumList.Count; localIndex++ )
                //		{
                //			if ( localIndex < invUpdWorkList.Count )
                //			{
                //                ((InventoryDataUpdateWork)invUpdWorkList[localIndex]).ProductNumber = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo1 = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo2 = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
                //            }
                //		}
                //	}
                //    //if ( prdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL && prdStatus == (int)ConstantManagement.MethodResult.ctFNC_CANCEL )
                //	//    return prdStatus;
                //}
                //else
                //{
                //	if ( this._defProdNumList.Count > 0 && invUpdWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
                //	{
                //		for( int localIndex = 0; localIndex < this._defProdNumList.Count; localIndex++ )
                //		{
                //			if ( localIndex < invUpdWorkList.Count )
                //			{
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).ProductNumber = ((InventoryDataUpdateWork)this._defProdNumList[localIndex]).ProductNumber.TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo1 = ((InventoryDataUpdateWork)this._defProdNumList[localIndex]).StockTelNo1.TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo2 = ((InventoryDataUpdateWork)this._defProdNumList[localIndex]).StockTelNo2.TrimEnd();
                //			}
                //		}
                //	}
                //}
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

                // 2007.07.26 kubo add --------------->

                this.uGrid_InventInput.BeginUpdate();

                // �ǉ����L��ꍇ�̓e�[�u���ɓW�J����
                if (invUpdWorkList.Count > 0)
                {
                    string errMsg = "";
                    status = this._inventInputAcs.DevSearchResult(invUpdWorkList, (int)InventInputSearchCndtn.ChangeFlagState.Change, ref errMsg, true);

                    invUpdWork = invUpdWorkList[0] as InventoryDataUpdateWork;
                    switch (status)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            if (isSelectRow)
                            {
                                int rowCount = 0;
                                this.uGrid_InventInput.ActiveRow = null;
                                for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                                {
                                    if (
                                        (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd() ==	// �q��
                                          invUpdWork.WarehouseCode.ToString().TrimEnd()) &&
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value == // ���[�J�[
                                          invUpdWork.GoodsMakerCd) &&
                                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                        //( this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsCode].Value.ToString().TrimEnd() == // �i��
                                        (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd() == // �i��
                                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                                          invUpdWork.GoodsNo.ToString().TrimEnd()) &&
                                        // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                                        //( (long)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockUnitPrice].Value == // ���P��
                                        //  invUpdWork.StockUnitPriceFl) &&
                                        // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CustomerCode].Value == // �d����R�[�h
                                          invUpdWork.CustomerCode) &&
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_ShipCustomerCode].Value == // �ϑ���R�[�h
                                          invUpdWork.ShipCustomerCode) &&
                                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                        //((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CarrierEpCode].Value == // ���Ǝ�
                                        //  invUpdWork.CarrierEpCode ) &&
                                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockDiv].Value == // �݌ɋ敪
                                          invUpdWork.StockDiv) //&&
                                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                        //((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockDiv].Value == // �݌ɏ��
                                        //  invUpdWork.StockState ) //&&
                                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                        //( (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryNewDiv].Value == // �V�K�敪
                                        //  (int)InventInputSearchCndtn.NewRowState.New )
                                    )
                                    {
                                        if (rowCount == 0)
                                        {
                                            rowCount = gridIndex;
                                            this.uGrid_InventInput.Selected.Rows.Clear();
                                            //this.uGrid_InventInput.ActiveRow = this.uGrid_InventInput.Rows[gridIndex];
                                            //this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                            if (this.uGrid_InventInput.ActiveRow == null)
                                                this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                                            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;
                                        }

                                        this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);
                                    }
                                }

                                //// �X�N���[��
                                if (this.uGrid_InventInput.Selected.Rows.Count > 0)
                                    this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.Selected.Rows[0];

                            }
                            break;
                        default:
                            this.MsgDispProc(errMsg, status, "NewInventProc", emErrorLevel.ERR_LEVEL_STOPDISP);
                            break;
                    }
                }
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
            }
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �V�K�s�쐬����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �V�K�s�쐬����
		/// </summary>
		/// <param name="baseInvUpdWork">�V�K�s�쐬����</param>
		/// <param name="invUpdWorkList">�ǉ����X�g</param>
        /// <br>UpdateNote : 2011/01/30 ���N�n�� </br>
        /// <br>             ��Q�� #18764</br>
        /// <returns>Status</returns>
		private void CreateNewInvent( InventoryDataUpdateWork baseInvUpdWork, out ArrayList invUpdWorkList )
		{
			// ���[�J���e�[�u���ɒǉ����邽�߂ɐV�K�쐬��ʂœ��͂��ꂽ���ڂ𐻔ԒP�ʂŕ�������

			invUpdWorkList = new ArrayList();
			InventoryDataUpdateWork invUpdPrd;
            double newRowCounter = 1;	// �V�K�쐬�s��

			for ( int index = 0; index < newRowCounter; index++ )
			{
				invUpdPrd = new InventoryDataUpdateWork();
                invUpdPrd.InventoryStockCnt     = baseInvUpdWork.InventoryStockCnt;     // �I����
                invUpdPrd.InventoryTolerancCnt  = baseInvUpdWork.InventoryStockCnt;     // ���ِ�
				invUpdPrd.CreateDateTime		= baseInvUpdWork.CreateDateTime;        // �쐬����
				invUpdPrd.UpdateDateTime		= baseInvUpdWork.UpdateDateTime;        // �X�V����
				invUpdPrd.EnterpriseCode		= baseInvUpdWork.EnterpriseCode;        // ��ƃR�[�h
				invUpdPrd.FileHeaderGuid		= baseInvUpdWork.FileHeaderGuid;        // GUID
				invUpdPrd.UpdEmployeeCode		= baseInvUpdWork.UpdEmployeeCode;       // �X�V�]�ƈ��R�[�h
				invUpdPrd.UpdAssemblyId1		= baseInvUpdWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
				invUpdPrd.UpdAssemblyId2		= baseInvUpdWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
				invUpdPrd.LogicalDeleteCode		= baseInvUpdWork.LogicalDeleteCode;     // �_���폜�敪
				invUpdPrd.SectionCode			= baseInvUpdWork.SectionCode;           // ���_�R�[�h
				invUpdPrd.InventorySeqNo		= baseInvUpdWork.InventorySeqNo;        // �I���ʔ�
				invUpdPrd.WarehouseCode			= baseInvUpdWork.WarehouseCode;         // �q�ɃR�[�h
				invUpdPrd.GoodsMakerCd			= baseInvUpdWork.GoodsMakerCd;          // ���[�J�[�R�[�h
				invUpdPrd.GoodsNo				= baseInvUpdWork.GoodsNo;               // �i��
                invUpdPrd.GoodsName             = baseInvUpdWork.GoodsName;             // �i��     //ADD 2009/04/21 �s��Ή�[13075]
                invUpdPrd.WarehouseShelfNo      = baseInvUpdWork.WarehouseShelfNo;      // �q�ɒI��
                invUpdPrd.DuplicationShelfNo1   = baseInvUpdWork.DuplicationShelfNo1;   // �d���I��2
                invUpdPrd.DuplicationShelfNo2   = baseInvUpdWork.DuplicationShelfNo2;   // �d���I��1
                invUpdPrd.GoodsLGroup           = baseInvUpdWork.GoodsLGroup;           // ���i�啪�ރR�[�h
				invUpdPrd.GoodsMGroup	        = baseInvUpdWork.GoodsMGroup;           // ���i�����ރR�[�h
                invUpdPrd.BLGroupCode           = baseInvUpdWork.BLGroupCode;           // �O���[�v�R�[�h
                invUpdPrd.EnterpriseGanreCode   = baseInvUpdWork.EnterpriseGanreCode;   // ���Е��ރR�[�h
                invUpdPrd.BLGoodsCode           = baseInvUpdWork.BLGoodsCode;           // �a�k�i��
                invUpdPrd.SupplierCd            = baseInvUpdWork.SupplierCd;            // �d����R�[�h
                invUpdPrd.Jan                   = baseInvUpdWork.Jan;                   // JAN�R�[�h
                invUpdPrd.StockUnitPriceFl      = baseInvUpdWork.StockUnitPriceFl;      // �d���P��
                invUpdPrd.BfStockUnitPriceFl    = baseInvUpdWork.BfStockUnitPriceFl;    // �ύX�O�d���P��
				invUpdPrd.StkUnitPriceChgFlg	= baseInvUpdWork.StkUnitPriceChgFlg;    // �d���P���ύX�t���O
				invUpdPrd.StockDiv				= baseInvUpdWork.StockDiv;              // �݌ɋ敪
                invUpdPrd.LastStockDate         = baseInvUpdWork.LastStockDate;         // �ŏI�d���N����
				invUpdPrd.StockTotal			= baseInvUpdWork.StockTotal;            // �݌ɑ���
				invUpdPrd.ShipCustomerCode		= baseInvUpdWork.ShipCustomerCode;      // �o�א擾�Ӑ�R�[�h
				invUpdPrd.InventoryPreprDay		= baseInvUpdWork.InventoryPreprDay;     // �I�������������t
				invUpdPrd.InventoryPreprTim		= baseInvUpdWork.InventoryPreprTim;     // �I��������������
				invUpdPrd.InventoryDay			= baseInvUpdWork.InventoryDay;          // �I�����{��
				invUpdPrd.LastInventoryUpdate	= baseInvUpdWork.LastInventoryUpdate;   // �ŏI�I���X�V��
				invUpdPrd.InventoryNewDiv		= baseInvUpdWork.InventoryNewDiv;       // �I���V�K�ǉ��敪
                invUpdPrd.StockMashinePrice     = baseInvUpdWork.StockMashinePrice;     // �}�V���݌Ɋz
                invUpdPrd.InventoryStockPrice   = baseInvUpdWork.InventoryStockPrice;   // �I���݌Ɋz
                invUpdPrd.InventoryTlrncPrice   = baseInvUpdWork.InventoryTlrncPrice;   // �I���ߕs�����z
                invUpdPrd.InventoryDate         = baseInvUpdWork.InventoryDate;         // �I����
                invUpdPrd.Status                = baseInvUpdWork.Status;                // �X�e�[�^�X

                invUpdPrd.AdjstCalcCost         = baseInvUpdWork.AdjstCalcCost;         // �����p�v�Z����   //ADD 2009/05/14 �s��Ή�[13260]

                invUpdPrd.ListPrice = baseInvUpdWork.ListPrice;                         // �艿             //ADD 2011/01/30

				invUpdWorkList.Add( invUpdPrd );	// �ǉ����X�g��Add
			}
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �V�K�s�쐬����
        /// </summary>
        /// <param name="baseInvUpdWork">�V�K�s�쐬����</param>
        /// <param name="invUpdWorkList">�ǉ����X�g</param>
        /// <returns>Status</returns>
        private void CreateNewInvent(InventoryDataUpdateWork baseInvUpdWork, out ArrayList invUpdWorkList)
        {
            // ���[�J���e�[�u���ɒǉ����邽�߂ɐV�K�쐬��ʂœ��͂��ꂽ���ڂ𐻔ԒP�ʂŕ�������

            invUpdWorkList = new ArrayList();
            InventoryDataUpdateWork invUpdPrd;
            double newRowCounter = 1;	// �V�K�쐬�s��

            for (int index = 0; index < newRowCounter; index++)
            {
                invUpdPrd = new InventoryDataUpdateWork();
                // �s�̃R�s�[
                // Guid�̓L�[�ɂȂ�̂ŐV�����U��Ȃ���
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.ProductStockGuid = Guid.NewGuid(); // ���ԍ݌Ƀ}�X�^GUID
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.InventoryStockCnt = baseInvUpdWork.InventoryStockCnt;     // �I����
                invUpdPrd.InventoryTolerancCnt = baseInvUpdWork.InventoryStockCnt;     // ���ِ�

                #region
                invUpdPrd.CreateDateTime = baseInvUpdWork.CreateDateTime;        // �쐬����
                invUpdPrd.UpdateDateTime = baseInvUpdWork.UpdateDateTime;        // �X�V����
                invUpdPrd.EnterpriseCode = baseInvUpdWork.EnterpriseCode;        // ��ƃR�[�h
                invUpdPrd.FileHeaderGuid = baseInvUpdWork.FileHeaderGuid;        // GUID
                invUpdPrd.UpdEmployeeCode = baseInvUpdWork.UpdEmployeeCode;       // �X�V�]�ƈ��R�[�h
                invUpdPrd.UpdAssemblyId1 = baseInvUpdWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
                invUpdPrd.UpdAssemblyId2 = baseInvUpdWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
                invUpdPrd.LogicalDeleteCode = baseInvUpdWork.LogicalDeleteCode;     // �_���폜�敪
                invUpdPrd.SectionCode = baseInvUpdWork.SectionCode;           // ���_�R�[�h
                //				invUpdPrd.SectionGuideNm		= baseInvUpdWork.SectionGuideNm;        // ���_�K�C�h����
                invUpdPrd.InventorySeqNo = baseInvUpdWork.InventorySeqNo;        // �I���ʔ�
                invUpdPrd.WarehouseCode = baseInvUpdWork.WarehouseCode;         // �q�ɃR�[�h
                invUpdPrd.WarehouseName = baseInvUpdWork.WarehouseName;         // �q�ɖ���
                invUpdPrd.GoodsMakerCd = baseInvUpdWork.GoodsMakerCd;          // ���[�J�[�R�[�h
                invUpdPrd.MakerName = baseInvUpdWork.MakerName;             // ���[�J�[����
                invUpdPrd.GoodsNo = baseInvUpdWork.GoodsNo;               // �i��
                invUpdPrd.GoodsName = baseInvUpdWork.GoodsName;             // �i��
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.CellphoneModelCode  = baseInvUpdWork.CellphoneModelCode;    // �@��R�[�h
                //invUpdPrd.CellphoneModelName	= baseInvUpdWork.CellphoneModelName;    // �@�햼��
                //invUpdPrd.CarrierCode			= baseInvUpdWork.CarrierCode; // �L�����A�R�[�h
                //invUpdPrd.CarrierName			= baseInvUpdWork.CarrierName; // �L�����A����
                //invUpdPrd.SystematicColorCd		= baseInvUpdWork.SystematicColorCd; // �n���F�R�[�h
                //invUpdPrd.SystematicColorNm		= baseInvUpdWork.SystematicColorNm; // �n���F����
                invUpdPrd.WarehouseShelfNo = baseInvUpdWork.WarehouseShelfNo;      // �q�ɒI��
                invUpdPrd.DuplicationShelfNo1 = baseInvUpdWork.DuplicationShelfNo1;   // �d���I��2
                invUpdPrd.DuplicationShelfNo2 = baseInvUpdWork.DuplicationShelfNo2;   // �d���I��1
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.LargeGoodsGanreCode = baseInvUpdWork.LargeGoodsGanreCode;   // ���i�啪�ރR�[�h
                invUpdPrd.LargeGoodsGanreName = baseInvUpdWork.LargeGoodsGanreName;   // ���i�啪�ޖ���
                invUpdPrd.MediumGoodsGanreCode = baseInvUpdWork.MediumGoodsGanreCode;  // ���i�����ރR�[�h
                invUpdPrd.MediumGoodsGanreName = baseInvUpdWork.MediumGoodsGanreName;  // ���i�����ޖ���
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.CarrierEpCode			= baseInvUpdWork.CarrierEpCode;     // ���Ǝ҃R�[�h
                //invUpdPrd.CarrierEpName			= baseInvUpdWork.CarrierEpName;     // ���ƎҖ���
                invUpdPrd.DetailGoodsGanreCode = baseInvUpdWork.DetailGoodsGanreCode;  // �O���[�v�R�[�h
                invUpdPrd.DetailGoodsGanreName = baseInvUpdWork.DetailGoodsGanreName;  // �O���[�v�R�[�h����
                invUpdPrd.EnterpriseGanreCode = baseInvUpdWork.EnterpriseGanreCode;   // ���Е��ރR�[�h
                invUpdPrd.EnterpriseGanreName = baseInvUpdWork.EnterpriseGanreName;   // ���Е��ޖ���
                invUpdPrd.BLGoodsCode = baseInvUpdWork.BLGoodsCode;           // �a�k�i��
                //                invUpdPrd.BLGoodsName           = baseInvUpdWork.BLGoodsName;         // �a�k�i��
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.CustomerCode = baseInvUpdWork.CustomerCode;          // ���Ӑ�R�[�h
                invUpdPrd.CustomerName = baseInvUpdWork.CustomerName;          // ���Ӑ於��
                invUpdPrd.CustomerName2 = baseInvUpdWork.CustomerName2;         // ���Ӑ於��2
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.StockDate             = baseInvUpdWork.StockDate;           // �d����
                //invUpdPrd.ArrivalGoodsDay		= baseInvUpdWork.ArrivalGoodsDay;       // ���ד�
                //invUpdPrd.ProductNumber			= baseInvUpdWork.ProductNumber;     // �����ԍ�
                //invUpdPrd.StockTelNo1			= baseInvUpdWork.StockTelNo1;           // ���i�d�b�ԍ�1
                //invUpdPrd.BfStockTelNo1			= baseInvUpdWork.BfStockTelNo1;     // �ύX�O���i�d�b�ԍ�1
                //invUpdPrd.StkTelNo1ChgFlg		= baseInvUpdWork.StkTelNo1ChgFlg;       // ���i�d�b�ԍ�1�ύX�t���O
                //invUpdPrd.StockTelNo2			= baseInvUpdWork.StockTelNo2;           // ���i�d�b�ԍ�2
                //invUpdPrd.BfStockTelNo2			= baseInvUpdWork.BfStockTelNo2;     // �ύX�O���i�d�b�ԍ�2
                //invUpdPrd.StkTelNo2ChgFlg		= baseInvUpdWork.StkTelNo2ChgFlg;       // ���i�d�b�ԍ�2�ύX�t���O
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.Jan = baseInvUpdWork.Jan;                   // JAN�R�[�h
                invUpdPrd.StockUnitPriceFl = baseInvUpdWork.StockUnitPriceFl;      // �d���P��
                invUpdPrd.BfStockUnitPriceFl = baseInvUpdWork.BfStockUnitPriceFl;    // �ύX�O�d���P��
                invUpdPrd.StkUnitPriceChgFlg = baseInvUpdWork.StkUnitPriceChgFlg;    // �d���P���ύX�t���O
                invUpdPrd.StockDiv = baseInvUpdWork.StockDiv;              // �݌ɋ敪
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.StockState            = baseInvUpdWork.StockState;          // �݌ɏ��
                //invUpdPrd.MoveStatus			= baseInvUpdWork.MoveStatus;            // �ړ����
                //invUpdPrd.GoodsCodeStatus		= baseInvUpdWork.GoodsCodeStatus;       // ���i���
                //invUpdPrd.PrdNumMngDiv			= baseInvUpdWork.PrdNumMngDiv;      // ���ԊǗ��敪
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.LastStockDate = baseInvUpdWork.LastStockDate;         // �ŏI�d���N����
                invUpdPrd.StockTotal = baseInvUpdWork.StockTotal;            // �݌ɑ���
                invUpdPrd.ShipCustomerCode = baseInvUpdWork.ShipCustomerCode;      // �o�א擾�Ӑ�R�[�h
                invUpdPrd.ShipCustomerName = baseInvUpdWork.ShipCustomerName;      // �o�א擾�Ӑ於��
                invUpdPrd.ShipCustomerName2 = baseInvUpdWork.ShipCustomerName2;     // �o�א擾�Ӑ於��2
                invUpdPrd.InventoryPreprDay = baseInvUpdWork.InventoryPreprDay;     // �I�������������t
                invUpdPrd.InventoryPreprTim = baseInvUpdWork.InventoryPreprTim;     // �I��������������
                invUpdPrd.InventoryDay = baseInvUpdWork.InventoryDay;          // �I�����{��
                invUpdPrd.LastInventoryUpdate = baseInvUpdWork.LastInventoryUpdate;   // �ŏI�I���X�V��
                invUpdPrd.InventoryNewDiv = baseInvUpdWork.InventoryNewDiv;       // �I���V�K�ǉ��敪
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                invUpdPrd.StockMashinePrice = baseInvUpdWork.StockMashinePrice;     // �}�V���݌Ɋz
                invUpdPrd.InventoryStockPrice = baseInvUpdWork.InventoryStockPrice;   // �I���݌Ɋz
                invUpdPrd.InventoryTlrncPrice = baseInvUpdWork.InventoryTlrncPrice;   // �I���ߕs�����z
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                invUpdPrd.InventoryDate = baseInvUpdWork.InventoryDate;         // �I����
                // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.Status = baseInvUpdWork.Status; // �X�e�[�^�X
                #endregion

                invUpdWorkList.Add(invUpdPrd);	// �ǉ����X�g��Add
            }
        }
		   --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �� �J�����v���p�e�B�ݒ菈��
        #region �� CellActivation�v���p�e�B�ݒ菈��
        /// <summary>
		/// CellActivation�v���p�e�B�ݒ菈��
		/// </summary>
		/// <param name="columns">�ݒ�ΏۃJ����</param>
		/// <param name="action">�ݒ�l</param>
		/// <param name="columnName">�J������</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void SetCellActivation( ColumnsCollection columns, CellClickAction action, string columnName )
		{
			columns[ columnName ].CellClickAction = action;
		}
		#endregion

		#region �� CellClickAction�v���p�e�B�ݒ菈��
		/// <summary>
		/// CellClickAction�v���p�e�B�ݒ菈��
		/// </summary>
		/// <param name="columns">�ݒ�ΏۃJ����</param>
		/// <param name="activation">�ݒ�l</param>
		/// <param name="columnName">�J������</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\���p��UltraGrid�̏������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void SetCellClickAction( ColumnsCollection columns, Activation activation, string columnName )
		{
			columns[ columnName ].CellActivation = activation;
		}
		#endregion
		#endregion �� �J�����v���p�e�B�ݒ菈��
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� ��ʕ\��������
        /// <summary>
		/// ��ʕ\��������
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: ��ʕ\�������������s����B</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date        : 2007.04.11</br>
        /// <br>UpdateNote  : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>              �I�����{���̏����\����ύX����</br>
        /// <br>              REDMINE:2018�@������Q�̏C��</br>
        /// <br>UpdateNote : 2011/02/10 ���N�n��</br>
        /// <br>             ��Q�� #18870</br>
        /// </remarks>
		private int ShowDataProc ( )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				if ( this._isFirstsetting )
				{
					this.tce_ViewStyle.SelectedIndex = 0;	// �\�����@(�O��\����Ԃ��擾���Ă�����Z�b�g����)
                    //this.tce_SortOrder.SelectedIndex = 0;	// �\�[�g�� // DEL 2009/12/03
                    this.tce_SortOrder.SelectedIndex = this._inventInputAcs.SortOrde;	// �\�[�g�� // ADD 2009/12/03

					// �f�[�^�o�C���h
					this._isFirstsetting = false;	// �f�[�^���o�C���h���邽�߂Ɉꎞ�I��off
					ChangeViewStyle();
					this._isFirstsetting = true;	// ���ɖ߂�

					// ����N�����̂݉�ʐݒ�
					// �O���b�h�L�[�}�b�s���O�쐬
					this.MakeGridKeyMapping( this.uGrid_InventInput);

					// Grid Setting
					this.InitialInventInputGrid( this.uGrid_InventInput.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ] );

					// �J������
					// �����T�C�Y
					this._isFirstsetting = false;
					this._isEventAutoFillColumn = true;
				}
				else
				{
					//// �f�[�^�o�C���h
					//ChangeViewStyle();
                    ChangeViewStyle(); // ADD 2009/12/03
                    // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------------------------->>>>>
                    //No�����蓖��
                    int idx = 1;
                    foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
                    {
                        gridRow.Cells[InventInputResult.ct_Col_No].Value = idx;
                        gridRow.Update();
                        idx++;
                    }
                    // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------<<<<<
				}

                if (this.uGrid_InventInput.Rows.Count > 0)
                {
                    //this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                    // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    // �I�����Z�b�g
                    this.tde_InventoryExeDate.SetDateTime((DateTime)this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryExeDay_Datetime].Value);
                    // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

                    // --- ADD 2009/12/03 ---------->>>>>
                    // �I�����{���Z�b�g
                    this.tde_InventoryDate.SetDateTime(this.tde_InventoryExeDate.GetDateTime());
                    // --- ADD 2009/12/03 ----------<<<<<

                    // -- ADD 2009/09/11 -------------------->>>
                    // �ߕs���X�V�ςݍs��Enabled����
                    SetGridEnabledTolUpd();
                    // -- ADD 2009/09/11 --------------------<<<
                }

                tde_InventoryDate.Focus();
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "�I���f�[�^�̕\���Ɏ��s���܂����B", status, "ShowDataProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
			}
            //---ADD 2011/02/10---------------------------------------------->>>>>
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                if("���޼".Equals(gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Value) || ("���޼".Equals(gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Value)))
                {
                     gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Activation = Activation.NoEdit;
                }
            }
            //---ADD 2011/02/10----------------------------------------------<<<<<
			return status;
		}
		#endregion

        #region �� �Z���ύX������
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �Z���ύX������
        /// </summary>
        /// <param name="activeCell">�A�N�e�B�u�Z��</param>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="isChangeInventStcCnt">�I�����ύX�t���O</param>
        /// <param name="isChangeInventDate">�I�����ύX�t���O</param>
        /// <param name="isShowProduct">�q��ʕ\���t���O(���g�p)</param>
        /// <br>UpdateNote : 2009/12/03 ����� �o�l�D�m�r�ێ�˗��B</br>
        /// <br>             ���됔��0�̍s�̌��P����ύX���ɃG���[���������Ȃ��悤�ɕύX����</br>
        public void AfterExitEditModeProc(UltraGridCell activeCell, object sender, bool isChangeInventStcCnt, bool isChangeInventDate, bool isShowProduct)
        {
            string errMsg = "";
            // DataRow targetDr = (DataRow)activeCell.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;  //DEL yangyi 2013/03/01 Redmine#34175
            DataRow targetDr = GetBindDataRow(activeCell.Row);                                            //ADD yangyi 2013/03/01 Redmine#34175 
            try
            {
                errMsg = "�I�����̓��͂Ɏ��s���܂����B\r\n";

                // �I���������͂��ꂽ�Ƃ�
                if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0)
                {
                    // �I�������ݒ�
                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!isChangeInventStcCnt)
                    {
                        return;
                    }

                    if (activeCell.Text.TrimEnd() == "")
                    {
                        // ���됔
                        if (targetDr == null)
                        {
                            return;
                        }

                        double stockTotal = (double)targetDr[InventInputResult.ct_Col_StockTotal];
                        //activeCell.Value = DBNull.Value;
                        activeCell.Value = stockTotal;
                        //return;
                    }

                    // 2011/04/07 Del >>>
                    //// �I�������͌㏈��
                    //AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    // 2011/04/07 Del <<<

                    // �I�����W�J����
                    //AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());      //DEL 2009/05/14 �s��Ή�[13260]�@���łɓ��͂���Ă���l�܂ŕύX����Ă��܂���
                    // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------------------------------->>>>>
                    if (targetDr[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value)
                    {
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    else if ((DateTime)targetDr[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue)
                    {
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // ---ADD 2009/05/14 �s��Ή�[13260] -----------------------------------------------------<<<<<

                    // 2011/04/07 Add >>>
                    // �I�������͌㏈��
                    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    // 2011/04/07 Add <<<

                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // �I���X�V�������͂��ꂽ�Ƃ�( ActiveCell���N�E���E���̂����ꂩ�̏ꍇ )
                else if ((activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                          (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
                          (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                {
                    errMsg = "�I�����̓��͂Ɏ��s���܂����B\r\n";
                    // �N�����̓��͂��������Ă��Ȃ��ꍇ�͏����L�����Z��
                    if ((activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value == DBNull.Value) ||
                        (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value == DBNull.Value) ||
                        (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value == DBNull.Value))
                    {
                        return;
                    }
                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!isChangeInventDate)
                    {
                        return;
                    }

                    // ���͂����������t���H
                    int inputDate_int =
                        ((int)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value * 10000) +
                        ((int)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value * 100) +
                        ((int)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value);

                    DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);

                    // 2011/04/07 Del >>>
                    //// �I�����X�V
                    //// �I���������͂̏ꍇ�̂ݒI������W�J����
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // �I�������͌㏈��
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    DateTime devDateTime = DateTime.MinValue;

                    if (inputDate != DateTime.MinValue)
                    {
                        devDateTime = inputDate;
                    }
                    else
                    {
                        devDateTime = this.tde_InventoryDate.GetDateTime();
                    }

                    // �I�����W�J����
                    AfterInputInventoryDate(ref targetDr, devDateTime);

                    // 2011/04/07 Add >>>
                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // �I�������͌㏈��
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // �q�ɒI�Ԃ����͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    errMsg = "�I�Ԃ̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeWarehouseShelfNo)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// �I�����X�V
                    //// �I���������͂̏ꍇ�̂ݒI������W�J����
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // �I�������͌㏈��
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    // �I�ԓ��͌㏈��
                    AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_WarehouseShelfNo].ToString(), InventInputResult.ct_Col_WarehouseShelfNo);

                    // ���t�X�V
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // �I�����W�J����
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // �I�������͌㏈��
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // �d���I�ԂP�����͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    errMsg = "�d���I�ԂP�̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeDuplicationShelfNo1)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// �I�����X�V
                    //// �I���������͂̏ꍇ�̂ݒI������W�J����
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    // �I�ԓ��͌㏈��
                    AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo1].ToString(), InventInputResult.ct_Col_DuplicationShelfNo1);

                    // ���t�X�V
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // �I�����W�J����
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // �d���I�ԂQ�����͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    errMsg = "�d���I�ԂQ�̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeDuplicationShelfNo2)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// �I�����X�V
                    //// �I���������͂̏ꍇ�̂ݒI������W�J����
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // �I�������͌㏈��
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    // �I�ԓ��͌㏈��
                    AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo2].ToString(), InventInputResult.ct_Col_DuplicationShelfNo2);

                    // ���t�X�V
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // �I�����W�J����
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // �I�������͌㏈��
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // ���P�������͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    errMsg = "���P���̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeStockUnitPrice)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// �I�����X�V
                    //// �I���������͂̏ꍇ�̂ݒI������W�J����
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // �I�������͌㏈��
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    double stockTotal = (double)activeCell.Row.Cells[InventInputResult.ct_Col_StockTotal].Value;
                    // --- UPD 2009/12/03 ---------->>>>>
                    //double invStockCnt = (double)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                    double invStockCnt = 0;
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                    {
                        invStockCnt = (double)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                    }
                    // --- UPD 2009/12/03 ----------<<<<<

                    double stockUnitPrice = (double)activeCell.Row.Cells[InventInputResult.ct_Col_StockUnitPrice].Value;

                    // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------------------------------------------------->>>>>
                    targetDr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = 1;                                                                      //�d���P���ύX�t���O
                    targetDr[InventInputResult.ct_Col_StockMashinePrice] = this._inventInputAcs.GetTotalPriceToLong(stockTotal,stockUnitPrice);     //�}�V���݌Ɋz
                    targetDr[InventInputResult.ct_Col_InventoryStockPrice] = this._inventInputAcs.GetTotalPriceToLong(invStockCnt, stockUnitPrice); //�I���݌Ɋz
                    // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------------------------------------------------------------------<<<<<

                    // ���P���X�V
                    //this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_StockUnitPrice].ToString(), InventInputResult.ct_Col_StockUnitPrice);     //DEL 2009/05/14 �s��Ή�[13260]
                    this.AfterInputStockUnitPrice(ref targetDr, (double)targetDr[InventInputResult.ct_Col_StockUnitPrice], InventInputResult.ct_Col_StockUnitPrice);            //ADD 2009/05/14 �s��Ή�[13260]

                    // ���t�X�V
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // �I�����W�J����
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // �I�������͌㏈��
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc(errMsg,
                                 (int)ConstantManagement.MethodResult.ctFNC_CANCEL,
                                 "uGrid_InventInput_CellChange",
                                 ex,
                                 emErrorLevel.ERR_LEVEL_STOPDISP);
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �Z���ύX������
		/// </summary>
		/// <param name="activeCell">�A�N�e�B�u�Z��</param>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="isChangeInventStcCnt">�I�����ύX�t���O</param>
		/// <param name="isChangeInventDate">�I�����ύX�t���O</param>
		/// <param name="isShowProduct">�q��ʕ\���t���O(���g�p)</param>
        public void AfterExitEditModeProc(Infragistics.Win.UltraWinGrid.UltraGridCell activeCell, object sender, bool isChangeInventStcCnt, bool isChangeInventDate, bool isShowProduct)
        {
			string errMsg = "";
			DataRow targetDr = (DataRow)activeCell.Row.Cells[ InventInputResult.ct_Col_RowSelf ].Value;
			try
			{
				errMsg = "�I�����̓��͂Ɏ��s���܂����B\r\n";
				// �I���������͂��ꂽ�Ƃ�
				if ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt ) == 0 )
				{
					// �I�������ݒ�
					// �ύX����Ă��Ȃ��ꍇ�͖�����
					if ( !isChangeInventStcCnt ) return;

					if ( activeCell.Text.TrimEnd() == "" )
					{
						activeCell.Value = DBNull.Value;

						return;
					}
					// TODO:
					#region // 2007.07.19 kubo del 
					//((UltraGrid)sender).UpdateMode = UpdateMode.OnUpdate;
					//((UltraGrid)sender).UpdateData();	// �O���b�h���X�V
					#endregion

					// �I�����X�V
					this.AfterInputInventryToleCnt( 
						ref targetDr,
						(int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );

					// 2007.07.30 kubo add -------->
					//DateTime devData = this.tde_InventoryDate.GetDateTime();
					//if ( targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value && 
					//    (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt] == 0 &&
					//    (int)targetDr[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods &&
					//    (int)targetDr[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
					//{
					//    devData = DateTime.MinValue;
					//}
					//this.AfterInputInventoryDate( ref targetDr, devData );
					// 2007.07.30 kubo add <--------

					// ���t�X�V
					#region // 2007.07.30 kubo del
					this.AfterInputInventoryDate( ref targetDr, this.tde_InventoryDate.GetDateTime() );
					#endregion
					// �ύX�敪���Z�b�g
					targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				}
				// �I���X�V�������͂��ꂽ�Ƃ�( ActiveCell���N�E���E���̂����ꂩ�̏ꍇ )
				else if ( ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
						  ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
						  ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day) == 0 ) )
				{
					errMsg = "�I�����̓��͂Ɏ��s���܂����B\r\n";
					// �N�����̓��͂��������Ă��Ȃ��ꍇ�͏����L�����Z��
					if ( ( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value == DBNull.Value ) ||
						( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value == DBNull.Value ) ||
						( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value == DBNull.Value ) )
					{
						return;
					}
					// �ύX����Ă��Ȃ��ꍇ�͖�����
					if ( !isChangeInventDate ) return;

					#region // 2007.07.19 kubo del -------------------------->
					//((UltraGrid)sender).UpdateMode = UpdateMode.OnUpdate;
					//((UltraGrid)sender).UpdateData();	// �O���b�h���X�V
					#endregion

					// ���͂����������t���H
					int inputDate_int = 
						( (int)activeCell.Row.Cells[ InventInputResult.ct_Col_InventoryDay_Year ].Value * 10000 ) +
						( (int)activeCell.Row.Cells[ InventInputResult.ct_Col_InventoryDay_Month ].Value * 100 ) +
						( (int)activeCell.Row.Cells[ InventInputResult.ct_Col_InventoryDay_Day ].Value);

					DateTime inputDate = TDateTime.LongDateToDateTime( inputDate_int );

					// �I�����X�V
					// �I���������͂̏ꍇ�̂ݒI������W�J����
					if ( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value )
					{
						this.AfterInputInventryToleCnt(
							ref targetDr, 
							(int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );
					}

					DateTime devDateTime = DateTime.MinValue;

					if ( inputDate != DateTime.MinValue )
					{
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
						devDateTime = inputDate;
                        //DateTime workDate = this.tde_InventoryExeDate.GetDateTime();
                        //if (inputDate > workDate.AddMonths(2))
                        //{
                        //    this.MsgDispProc("�s���ȓ��t�ł� �I��������Q�����ȓ��œ��͂��ĉ�����", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                        //    //this.tde_InventoryDate.Focus();
                        //    return;
                        //}
                        //else
                        //{
                        //    devDateTime = inputDate;
                        //}
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
					}
					else
					{
						devDateTime = this.tde_InventoryDate.GetDateTime();
					}
					
					// ���t�X�V
					this.AfterInputInventoryDate( ref targetDr, devDateTime );
					// �ύX�敪���Z�b�g
					targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				}
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                // �q�ɒI�Ԃ����͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    errMsg = "�I�Ԃ̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeWarehouseShelfNo) return;

                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // �I�ԍX�V
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_WarehouseShelfNo].ToString(), InventInputResult.ct_Col_WarehouseShelfNo);
                    // ���t�X�V
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // �d���I�ԂP�����͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    errMsg = "�d���I�ԂP�̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeDuplicationShelfNo1) return;

                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // �I�ԍX�V
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo1].ToString(), InventInputResult.ct_Col_DuplicationShelfNo1);
                    // ���t�X�V
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // �d���I�ԂQ�����͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    errMsg = "�d���I�ԂQ�̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeDuplicationShelfNo2) return;

                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // �I�ԍX�V
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo2].ToString(), InventInputResult.ct_Col_DuplicationShelfNo2);
                    // ���t�X�V
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                // ���P�������͂��ꂽ�Ƃ�
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    errMsg = "���P���̓��͂Ɏ��s���܂����B\r\n";

                    // �ύX����Ă��Ȃ��ꍇ�͖�����
                    if (!_isChangeStockUnitPrice) return;

                    // �I�����X�V
                    // �I���������͂̏ꍇ�̂ݒI������W�J����
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // ���P���X�V
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_StockUnitPrice].ToString(), InventInputResult.ct_Col_StockUnitPrice);

                    // ���t�X�V
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // 2007.07.25 kubo add ---------->
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_ProductNumber) == 0)
				//{
				//	errMsg = "�����ԍ��̓��͂Ɏ��s���܂����B\r\n";
				//	if ( this._isChangeInventProductNum )
				//		targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//}
				//else if ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo1 ) == 0 )
				//{
				//	errMsg = "�d�b�ԍ�1�̓��͂Ɏ��s���܂����B\r\n";
				//	if ( this._isChangeInventStockTelNo1 )
				//		targetDr[InventInputResult.ct_Col_BfStockTelNo1] = this._BfoerStockTelNo1;
				//		targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//}
				//else if ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo2 ) == 0 )
				//{
				//	errMsg = "�d�b�ԍ�2�̓��͂Ɏ��s���܂����B\r\n";
				//	if ( this._isChangeInventStockTelNo2 )
				//		targetDr[InventInputResult.ct_Col_BfStockTelNo2] = this._BfoerStockTelNo2;
				//		targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//}
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.07.25 kubo add <----------
			}
			catch ( Exception ex )
			{
				this.MsgDispProc( 
					errMsg,
					(int)ConstantManagement.MethodResult.ctFNC_CANCEL,
					"uGrid_InventInput_CellChange",
					ex,
					emErrorLevel.ERR_LEVEL_STOPDISP);
			}
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �I�������͌㏈��
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I�������͌㏈��
        /// </summary>
        /// <param name="targetDr"></param>
        /// <param name="viewState"></param>
        /// <param name="isShowSelectProduct"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �I�����̓��͌㏈�����s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int AfterInputInventryToleCnt(ref DataRow targetDr, int viewState, ref bool isShowSelectProduct)
        {
            double invStcCnt = 0;

            // �I�����擾
            if (targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
            {
                invStcCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
            }
            else
            {
                invStcCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];
            }

            // ���ِ��ݒ�
            //double toleCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal] - invStcCnt;       //DEL 2009/05/14 �s��Ή�[13260]
            double toleCnt = invStcCnt - (double)targetDr[InventInputResult.ct_Col_StockTotal];         //ADD 2009/05/14 �s��Ή�[13260]

            // ���s�ɍ��ِ���W�J
            ChangeCommitToleranceCnt(ref targetDr, toleCnt, invStcCnt);

            // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
            //// �e�E�q�s�擾Query�쐬
            //this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
            //            MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
            //            viewState);
            //this._inventInputView.Sort = string.Format("{0} Desc, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal);
            //this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            //DataRow childRow;
            //for (int index = 0; index < this._inventInputView.Count; index++)
            //{
            //    childRow = this._inventInputView[index].Row;
                
            //    // �q�s�ɍ��ِ���W�J
            //    ChangeCommitToleranceCnt(ref childRow, toleCnt, invStcCnt);
            //}
            // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
            //---------- ADD 2013/02/25 #34175 yangyi------------------->>>>>
            this._inventInputView.Sort = InventInputResult.ct_Col_SectionCode + "," + InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode
                                        + "," + InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_SupplierCode + "," + InventInputResult.ct_Col_ShipCustomerCode
                                        + "," + InventInputResult.ct_Col_StockDiv + "," + InventInputResult.ct_Col_GrossDiv;
            object[] primaryKeyObjList = new object[]{
				targetDr[InventInputResult.ct_Col_SectionCode].ToString(),			// ���_�R�[�h
				targetDr[InventInputResult.ct_Col_WarehouseCode].ToString(),			// �q�ɃR�[�h
				(int)targetDr[InventInputResult.ct_Col_MakerCode],				// ���[�J�[�R�[�h
                targetDr[InventInputResult.ct_Col_GoodsNo].ToString(),             // �i��
				(int)targetDr[InventInputResult.ct_Col_SupplierCode],		// �d����R�[�h
				(int)targetDr[InventInputResult.ct_Col_ShipCustomerCode],		// �ϑ���R�[�h
				(int)targetDr[InventInputResult.ct_Col_StockDiv],				// �݌ɋ敪
				(int)InventInputSearchCndtn.GrossDivState.Product// �W�v�敪
				};

            // �t�B���^�N���A
            this._inventInputView.RowFilter = string.Empty; // ADD by xuyb 2014/10/31 for ��Q���ۇA�̑Ή�

            DataRowView[] drv = this._inventInputView.FindRows(primaryKeyObjList);

            DataRow childRow;
            foreach (DataRowView dataRowView in drv)
            {
                childRow = dataRowView.Row;
                // �q�s�ɍ��ِ���W�J
                ChangeCommitToleranceCnt(ref childRow, toleCnt, invStcCnt);
            }
            //---------- ADD 2013/02/25 #34175 yangyi-------------------<<<<<

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �I�������͌㏈��
		/// </summary>
		/// <param name="targetDr"></param>
		/// <param name="viewState"></param>
		/// <param name="isShowSelectProduct"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �I�����̓��͌㏈�����s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private int AfterInputInventryToleCnt( ref DataRow targetDr, int viewState, ref bool isShowSelectProduct )
		{
			double invStcCnt = 0;
			// �I�����擾
			if ( targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
				invStcCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
			else
				invStcCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];

			// ���ِ��ݒ�
			double toleCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal] - invStcCnt;

			// ���s�ɍ��ِ���W�J
			ChangeCommitToleranceCnt( ref targetDr, toleCnt, invStcCnt, false );

            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
                        viewState);
            this._inventInputView.Sort = string.Format("{0} Desc, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal);
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            DataRow childRow;
            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                childRow = this._inventInputView[index].Row;
                // �q�s�ɍ��ِ���W�J
                ChangeCommitToleranceCnt(ref childRow, toleCnt, invStcCnt, false);
            }
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            #region 2007.09.11 �폜
            //// �f�[�^�̏W�v�敪������
			//if ( (int)targetDr[ InventInputResult.ct_Col_GrossDiv ] == (int)InventInputSearchCndtn.GrossDivState.Goods )
			//{
            //    // �q�s�ɒI������W�J
			//	if ( ((int)targetDr[ InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product) )
			//	{
			//		// ���Ԗ����̓f�[�^�ւ̓W�J�Ƃ��F�X���邩��ʃ��\�b�h�ɂ���B
			//		DevInventStockCntToProductGoodsChildRow( ref targetDr );
            //    
			//	}
			//	else
			//	{
			//		// ���i�̎q�f�[�^������
			//		DevInventStockCntToChildRow( ref targetDr, (int)InventInputSearchCndtn.ViewState.NotView );
			//	}
				#region
				//// �q��ʕ\�����f
				//if ( isShowSelectProduct )
				//{
				//    // ���ԊǗ��敪������
				//    if ( (int)targetDr[ InventInputResult.ct_Col_PrdNumMngDiv ] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
				//    {
				//        // ���ِ����[���ȊO�̂Ƃ��\���̉\��������
				//        if ( (double)targetDr[ InventInputResult.ct_Col_InventoryTolerancCnt] != 0 )
				//        {
				//            isShowSelectProduct = true;
				//        }
				//        else
				//        {
				//            isShowSelectProduct = false;
				//        }
				//    }
				//    else
				//    {
				//        isShowSelectProduct = false;
				//    }
				//}
				#endregion
			//}
			//else
			//{
				// ���ԃf�[�^���I�΂�Ă���ꍇ
				#region // 2007.07.24 kubo del
				//// ���Ԗ����͂̃O���X�f�[�^�H
				//if ( targetDr[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
				//{
				//    // ��\���ɂȂ��Ă��鐻�Ԗ����̓f�[�^�ɒI�����𔽉f
				//    // �q�s�ɒI������W�J
				//    DevInventStockCntToChildRow( ref targetDr, (int)InventInputSearchCndtn.ViewState.NotView );
				//}
				#endregion
			//	// ���Ԃ̐e�f�[�^�ɍ��ِ������Z
			//	ChangeCommitToleranceCnt( ref targetDr, toleCnt, invStcCnt, true );
            //
			//	isShowSelectProduct = false;
			//}
            #endregion
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region 2007.09.11 �폜
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region �� �e���q�I�����W�J����
        /*
		/// <summary>
		/// �e���q�I�����W�J����
		/// </summary>
		/// <param name="targetDr">�Ώ�DataRow</param>
		/// <param name="viewState">�\���敪</param>
		private void DevInventStockCntToChildRow( ref DataRow targetDr, int viewState )
		{
			// �q�s���擾
			// �V�K�s��������ĂĂ���
			#region // 2007.07.19 kubo del
			//DataView childDv = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            viewState ),
			//        //string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
			//        string.Format( "{0} Desc, {1} Desc, {2}", InventInputResult.ct_Col_InventoryNewDiv,InventInputResult.ct_Col_StockTotal, InventInputResult.ct_Col_ProductNumber ),
			//        DataViewRowState.CurrentRows);

			//// �q�s�ɍ��ِ��𔽉f
			//double stockCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];				// ����݌ɐ�
			//double inventCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];	// �I���݌ɐ�
			//double remInventCnt = inventCnt;
			//for( int index = 0; index < childDv.Count; index++ )
			//{
			//    if ( ChangeChildRowInvent( ref childDv, index, stockCnt, inventCnt ) )
			//    {
			//        remInventCnt--;
			//    }
			//    else
			//    {
			//        break;
			//    }
			//}
		
			//if ( childDv.Count > 0 )
			//{
			//    double addRowCnt = inventCnt - childDv.Count;
			//    bool isView = false;

			//    if ( (int)childDv[0][InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
			//        isView = true;
			//    else
			//        isView = false;

			//    // ���됔���I���݌ɐ��ȏ�̏ꍇ
			//    // �V�K�s�̒ǉ�
			//    DataRow childRow;
			//    for ( int localIndex = 0; localIndex < addRowCnt; localIndex++ )
			//    {			
			//        childRow = this._inventInputAcs.InventDataTable.NewRow();

			//        this._inventInputAcs.CopyRowToRow( childDv[0].Row, ref childRow, isView );

			//        childRow[InventInputResult.ct_Col_MoveStatus] = 0;
			//        childRow[InventInputResult.ct_Col_MoveStockCount] = 0;
			//        childRow[InventInputResult.ct_Col_InventoryNewDiv] = (int)targetDr[InventInputResult.ct_Col_InventoryNewDiv];
			//        childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
			//        childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

			//        this._inventInputAcs.InventDataTable.Rows.Add( childRow );
			//    }
			//}
			#endregion	
			// 2007.07.19 kubo add ------------->
			this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						viewState );
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._inventInputView.Sort = string.Format("{0} Desc, {1} Desc, {2}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal, InventInputResult.ct_Col_ProductNumber);
            this._inventInputView.Sort = string.Format("{0} Desc, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal);
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
			// 2007.07.19 kubo add <-------------

			// �q�s�ɍ��ِ��𔽉f
			double stockCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];				// ����݌ɐ�
			double inventCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];	// �I���݌ɐ�
			double remInventCnt = inventCnt;
			for( int index = 0; index < this._inventInputView.Count; index++ )
			{
				if ( ChangeChildRowInvent( ref this._inventInputView, index, stockCnt, inventCnt ) )
				{
					remInventCnt--;
				}
				else
				{
					break;
				}
			}
		
			double addRowCnt = 0;
			// 2007.07.30 kubo add ------------------>
			bool isProductMng = false;
			DataRow baseRow = null;	

			if ( this._inventInputView.Count > 0 )
			{
				baseRow = this._inventInputView[0].Row;
				addRowCnt = inventCnt - this._inventInputView.Count;
				isProductMng = true;
			}
			else
			{
				baseRow = targetDr;
				addRowCnt = inventCnt;
				isProductMng = false;
			}
			// 2007.07.30 kubo add <------------------

			// if ( this._inventInputView.Count > 0 ) // 2007.07.30 kubo del
			if ( addRowCnt > 0 ) // 2007.07.30 kubo add
			{
				bool isView = false;

				//if ( (int)this._inventInputView[0][InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //if ((int)baseRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
				//	isView = true;
				//else
				//	isView = false;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

				// ���됔���I���݌ɐ��ȏ�̏ꍇ
				// 2007.07.26 kubo add --------------->
				// ���Ԑݒ��ʋN��
				if ( this._productNumInput == null )
					this._productNumInput = new ProductNumInput();
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //ArrayList productNumList = null;
				//int prdStatus = 0;
                //
                //if ((int)targetDr[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
				//	prdStatus = this._productNumInput.ShowProductInventInput( out productNumList, addRowCnt, this );
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

				//if ( prdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				//    return;
				// 2007.07.26 kubo add <---------------

				// �V�K�s�̒ǉ�
				DataRow childRow;
				for ( int localIndex = 0; localIndex < addRowCnt; localIndex++ )
				{			
					childRow = this._inventInputAcs.InventDataTable.NewRow();

					this._inventInputAcs.CopyRowToRow( targetDr, ref childRow, isView );

                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //childRow[InventInputResult.ct_Col_MoveStatus] = 0;
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    childRow[InventInputResult.ct_Col_MoveStockCount] = 0;
					childRow[InventInputResult.ct_Col_InventoryNewDiv] = (int)targetDr[InventInputResult.ct_Col_InventoryNewDiv];
					childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
					childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

					// 2007.07.30 kubo add --------->
					if ( !isProductMng )
					{
						childRow[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.NotView;	// ��\��
					}
					// 2007.07.30 kubo add <---------

					// 2007.07.26 kubo add --------------->
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if (productNumList != null && localIndex < productNumList.Count)
					//{
                    //    if (((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
					//		childRow[InventInputResult.ct_Col_ProductNumber] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_ProductNumber] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = "";
					//}
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.26 kubo add --------------->
					this._inventInputAcs.InventDataTable.Rows.Add( childRow );
				}
			}
		}
        */
        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region �� �e���q�I�����W�J����(���ԊǗ��L-���i���f�[�^�p����)
        /*
        /// <summary>
		/// �e���q�I�����W�J����(���ԊǗ��L-���i���f�[�^�p����)
		/// </summary>
		/// <param name="targetDr">�Ώ�DataRow</param>
		private void DevInventStockCntToProductGoodsChildRow( ref DataRow targetDr )
		{
			//object sumInvStkCnt;
			//bool isChildChg = false;
			int prd_Old_Count = 0;	// ���ԊǗ��L ����
			int noPrd_Old_Count = 0;	// ���ԊǗ��� ����
			int prd_New_Count = 0;	// ���ԊǗ��L �V�K
			int noPrd_New_Count = 0;	// ���ԊǗ��� �V�K
			DataRow childRow;

            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //string sortOrder = string.Format("{0} Desc, {1} Desc, {2}", 
			//	InventInputResult.ct_Col_InventoryNewDiv,
			//	InventInputResult.ct_Col_StockTotal,
			//	InventInputResult.ct_Col_ProductNumber );
            string sortOrder = string.Format("{0} Desc, {1}", 
            	InventInputResult.ct_Col_InventoryNewDiv,
            	InventInputResult.ct_Col_StockTotal );
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<


			// �q�s���擾
			// �����f�[�^�擾 --------------------------------------------------
			#region
			// ���ԓ��͍ς݂̍s���擾 --------------------------------------------------
			#region // 2007.07.24 kubo del
			//string strFilter_Prd_Old = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.View );
			//if ( strFilter_Prd_Old.CompareTo("") != 0 )
			//{
			//    strFilter_Prd_Old = strFilter_Prd_Old + " and ";
			//}
			//// ���Ԃ����͍ς݂̊����f�[�^���擾
			//strFilter_Prd_Old = strFilter_Prd_Old + string.Format("{0}<>''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old);
			//// View�擾
			//// �\�[�g�͐V�K�敪(�~��),�I����,���ԁi�V�K�敪�͊����������Ƃ��ĂȂ�����Ӗ��������ǂ��������B�j
			//DataView childDv_Prd_Old = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_Prd_Old,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add ------------------------->
			StringBuilder strFilter_Prd_Old = new StringBuilder(
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ));
			if ( strFilter_Prd_Old.ToString().CompareTo("") != 0 )
			{
				strFilter_Prd_Old.Append(" and " );
			}
			// ���Ԃ����͍ς݂̊����f�[�^���擾
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //strFilter_Prd_Old.Append(string.Format("{0}<>''", InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old) );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // View�擾
			// �\�[�g�͐V�K�敪(�~��),�I����,���ԁi�V�K�敪�͊����������Ƃ��ĂȂ�����Ӗ��������ǂ��������B�j
			DataView childDv_Prd_Old = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_Prd_Old.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <-------------------------

			prd_Old_Count = childDv_Prd_Old.Count;



			// ���Ԗ����͂̍s���擾 --------------------------------------------------
			#region // 2007.07.24 kubo del
			//string strFilter_NoPrd_Old = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.NotView );
			//if ( strFilter_NoPrd_Old.CompareTo("") != 0 )
			//{
			//    strFilter_NoPrd_Old = strFilter_NoPrd_Old + " and ";
			//}
			//strFilter_NoPrd_Old = strFilter_NoPrd_Old + string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old);
			//// View�擾
			//DataView childDv_NoPrd_Old = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_NoPrd_Old,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add -------------------------->
			StringBuilder strFilter_NoPrd_Old = new StringBuilder( 
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ) );
			if ( strFilter_NoPrd_Old.ToString().CompareTo("") != 0 )
			{
				strFilter_NoPrd_Old.Append( " and " );
			}
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //strFilter_NoPrd_Old.Append(string.Format("{0}=''", InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old));
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // View�擾
			DataView childDv_NoPrd_Old = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_NoPrd_Old.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <--------------------------
			noPrd_Old_Count = childDv_NoPrd_Old.Count;
			#endregion

			// �V�K�f�[�^�擾--------------------------------------------------
			#region
			#region // 2007.07.24 kubo del
			// ���ԓ��͍ς݂̍s���擾 --------------------------------------------------
			//string strFilter_Prd_New = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.View );
			//if ( strFilter_Prd_New.CompareTo("") != 0 )
			//{
			//    strFilter_Prd_New = strFilter_Prd_New + " and ";
			//}

			//// ���Ԃ����͍ς݂̊����f�[�^���擾 --------------------------------------------------
			//strFilter_Prd_New = strFilter_Prd_New + 
			//    string.Format("{0}<>''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New);
			//// View�擾
			//DataView childDv_Prd_New = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_Prd_New,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add -------------------------->
			StringBuilder strFilter_Prd_New = new StringBuilder ( 
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ) );
			if ( strFilter_Prd_New.ToString().CompareTo("") != 0 )
			{
				strFilter_Prd_New.Append( " and " );
			}

			// ���Ԃ����͍ς݂̊����f�[�^���擾 --------------------------------------------------
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //strFilter_Prd_New.Append(
			//	string.Format("{0}<>''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New) );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // View�擾
			DataView childDv_Prd_New = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_Prd_New.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <--------------------------
			prd_New_Count = childDv_Prd_New.Count;



			// ���Ԗ����͂̍s���擾
			#region // 2007.07.24 kubo del
			//string strFilter_NoPrd_New = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.NotView );
			//if ( strFilter_NoPrd_New.CompareTo("") != 0 )
			//{
			//    strFilter_NoPrd_New = strFilter_NoPrd_New + " and ";
			//}
			//strFilter_NoPrd_New = strFilter_NoPrd_New + string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New);
			//// View�擾
			//DataView childDv_NoPrd_New = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_NoPrd_New,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add -------------------------->
			StringBuilder strFilter_NoPrd_New = new StringBuilder(
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ));
			if ( strFilter_NoPrd_New.ToString().CompareTo("") != 0 )
			{
				strFilter_NoPrd_New.Append( " and " );
			}
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //strFilter_NoPrd_New.Append(string.Format("{0}=''", InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New) );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // View�擾
			DataView childDv_NoPrd_New = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_NoPrd_New.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <--------------------------

			noPrd_New_Count = childDv_NoPrd_New.Count;
			#endregion

			// �q�s�ɍ��ِ��𔽉f
			double stockCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];			// ����݌ɐ�
			double inventCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];	// �I���݌ɐ�
			
			// �W�J����s�̑������擾
			double remInventCnt = inventCnt;

			// ��RowCount
			double totalRowCnt = prd_Old_Count + noPrd_Old_Count + prd_New_Count + noPrd_New_Count;
			double newInventCnt = inventCnt - totalRowCnt;


			// ���ԓ��͍� ���� -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < prd_Old_Count; index++ )
			{
			    // �q�s�ɔ��f
				if ( remInventCnt > 0 )
				{
					if ( ChangeChildRowInvent( ref childDv_Prd_Old, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// �W�J�c�� = �W�J�c�� - (�V�K�ǉ��s��)
						//remInventCnt = remInventCnt - prd_Old_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_Prd_Old[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
				}
			}
			inventCnt = remInventCnt;
			#endregion

			// ���Ԗ����� ���� -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < noPrd_Old_Count; index++ )
			{
				
				// �܂���\���ɂȂ��Ă���ŏ��P�ʂ̃f�[�^�ɒI������W�J����B
				// �W�J������A�Ō�ɐe�f�[�^�ɓW�J��������
			    // �q�s�ɔ��f
				if ( remInventCnt > 0 )
				{
					//isChildChg = true;
					if ( ChangeChildRowInvent( ref childDv_NoPrd_Old, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// �W�J�c�� = �W�J�c�� - (�V�K�ǉ��s��)
						//remInventCnt = remInventCnt - noPrd_Old_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_NoPrd_Old[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
					//isChildChg = true;
				}
			}

			// �V�K�s�쐬���f
			// �I���������s����葽��������V�K�s��ǉ�
			if ( ( newInventCnt > 0 ) && ( remInventCnt > 0 ) )
			{
				DataRow parentRow;
				bool isView = false;

				if ( childDv_Prd_Old.Count > 0 )
					parentRow = childDv_Prd_Old[0].Row;
				else if ( childDv_NoPrd_Old.Count > 0 )
					parentRow = childDv_NoPrd_Old[0].Row;
				else
					parentRow = targetDr;


                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //if ((int)parentRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
				//	isView = true;
				//else
				//	isView = false;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

				// ���됔���I���݌ɐ��ȏ�̏ꍇ
				// 2007.07.26 kubo add --------------->
				// ���Ԑݒ��ʋN��
				if ( this._productNumInput == null )
					this._productNumInput = new ProductNumInput();
				
				ArrayList productNumList = null;

                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //int prdStatus = 0;
				//if ( (int)parentRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
				//	prdStatus = this._productNumInput.ShowProductInventInput( out productNumList, newInventCnt, this );
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

				//if ( prdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				//    return;
				// 2007.07.26 kubo add <---------------

				// �V�K�s�̒ǉ�
				childRow = null;
				for ( int localIndex = 0; localIndex < newInventCnt; localIndex++ )
				{			
					CreateNewRowToRow( parentRow, ref childRow, (int)InventInputSearchCndtn.NewRowState.New, isView );

					// 2007.07.26 kubo add --------------->
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if (productNumList != null && localIndex < productNumList.Count)
					//{
                    //    if (((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
					//		childRow[InventInputResult.ct_Col_ProductNumber] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_ProductNumber] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = "";
					//}
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.26 kubo add --------------->

					//isChildChg = true;

					// �O���X�f�[�^���
					this._inventInputAcs.MakeGrossData( childRow, false );

					remInventCnt--;
				}
			}
			inventCnt = remInventCnt;

			#region // 2007.07.24 kubo del
			//// �e�s�擾
			//// ���Ԗ����͂̍s���擾
			//if ( isChildChg )
			//{
			//    string strFilter_parentNoPrd_Old = MakeParentOrChildRowGetQuery( 
			//                MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//                (int)InventInputSearchCndtn.ViewState.View );
			//    if ( strFilter_parentNoPrd_Old.CompareTo("") != 0 )
			//    {
			//        strFilter_parentNoPrd_Old = strFilter_parentNoPrd_Old + " and ";
			//    }
			//    strFilter_parentNoPrd_Old = strFilter_parentNoPrd_Old + 
			//        string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//        string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old);
			//    // View�擾
			//    DataView parentDv_NoPrd_Old = 
			//        new DataView( 
			//            this._inventInputAcs.InventDataTable, 
			//            strFilter_parentNoPrd_Old,
			//            string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
			//            DataViewRowState.CurrentRows);

			//    if ( parentDv_NoPrd_Old.Count > 0 )
			//    {
			//        // �e�s�͈�s���������Ă��Ȃ��͂��Ȃ̂�DataView�̗v�f��Index��0�ŌŒ�
			//        // �q�s�̒I�������擾
			//        sumInvStkCnt = this._inventInputAcs.InventDataTable.Compute(
			//            string.Format("Sum({0})",InventInputResult.ct_Col_InventoryStockCnt),strFilter_NoPrd_Old);
						
			//        if ( sumInvStkCnt != DBNull.Value )
			//        {
			//            parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryStockCnt] = (double)sumInvStkCnt;
			//        }
			//        else
			//        {
			//            parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryStockCnt] = 0;
			//        }

			//        // ���ِ��̓W�J
			//        parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
			//            (double)parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryStockCnt] -
			//            (double)parentDv_NoPrd_Old[0][InventInputResult.ct_Col_StockTotal];
			//    }
			//    else
			//    {

			//        this.MsgDispProc( "�I�����̓W�J�Ɏ��s���܂���", -1, "DevInventStockCntToProductGoodChildRow", emErrorLevel.ERR_LEVEL_STOPDISP );
			//        return;
			//    }
			//}
			#endregion
			//isChildChg = false;
			#endregion

			// ���ԓ��͍� �V�K -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < prd_New_Count; index++ )
			{
			    // �q�s�ɔ��f
				if ( remInventCnt > 0 )
				{
					if ( ChangeChildRowInvent( ref childDv_Prd_New, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// �W�J�c�� = �W�J�c�� - (�V�K�ǉ��s��)
						//remInventCnt = remInventCnt - prd_New_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_Prd_New[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
				}
			}
			inventCnt = remInventCnt;
			#endregion

			// ���Ԗ����� �V�K -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < noPrd_New_Count; index++ )
			{
				// �܂���\���ɂȂ��Ă���ŏ��P�ʂ̃f�[�^�ɒI������W�J����B
				// �W�J������A�Ō�ɐe�f�[�^�ɓW�J��������
			    // �q�s�ɔ��f
				if ( remInventCnt > 0 )
				{
					//isChildChg = true;
					if ( ChangeChildRowInvent( ref childDv_NoPrd_New, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// �W�J�c�� = �W�J�c�� - (�V�K�ǉ��s��)
						//remInventCnt = remInventCnt - noPrd_New_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_NoPrd_New[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
					//isChildChg = true;
				}
			}
			inventCnt = remInventCnt;

			#region // 2007.07.24 kubo del
			//if ( isChildChg )
			//{
			//    // �e�s�擾
			//    // ���Ԗ����͂̍s���擾
			//    string strFilter_parentNoPrd_New = MakeParentOrChildRowGetQuery( 
			//                MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//                (int)InventInputSearchCndtn.ViewState.View );
			//    if ( strFilter_parentNoPrd_New.CompareTo("") != 0 )
			//    {
			//        strFilter_parentNoPrd_New = strFilter_parentNoPrd_New + " and ";
			//    }
			//    strFilter_parentNoPrd_New = strFilter_parentNoPrd_New + 
			//        string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//        string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New);
			//    // View�擾
			//    DataView parentDv_NoPrd_New = 
			//        new DataView( 
			//            this._inventInputAcs.InventDataTable, 
			//            strFilter_parentNoPrd_New,
			//            string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
			//            DataViewRowState.CurrentRows);

			//    if ( parentDv_NoPrd_New.Count > 0 )
			//    {
			//        // �e�s�͈�s���������Ă��Ȃ��͂��Ȃ̂�DataView�̗v�f��Index��0�ŌŒ�
			//        // �q�s�̒I�������擾
			//        sumInvStkCnt = this._inventInputAcs.InventDataTable.Compute(
			//            string.Format("Sum({0})",InventInputResult.ct_Col_InventoryStockCnt), strFilter_NoPrd_New);
						
			//        if ( sumInvStkCnt != DBNull.Value )
			//        {
			//            parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryStockCnt] = (double)sumInvStkCnt;
			//        }
			//        else
			//        {
			//            parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryStockCnt] = 0;
			//        }

			//        // ���ِ��̓W�J
			//        parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
			//            (double)parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryStockCnt] -
			//            (double)parentDv_NoPrd_New[0][InventInputResult.ct_Col_StockTotal];
			//    }
			//    else
			//    {
			//        this.MsgDispProc( "�I�����̓W�J�Ɏ��s���܂���", -1, "DevInventStockCntToProductGoodChildRow", emErrorLevel.ERR_LEVEL_STOPDISP );
			//        return;
			//    }
			//}
			#endregion
			inventCnt = inventCnt - remInventCnt;
			#endregion
		}
        */
        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region �� �V�K�s�쐬����
        /*
        /// <summary>
		/// �V�K�s�쐬����
		/// </summary>
		/// <param name="parentRow">�e�s</param>
		/// <param name="childRow">�q�s</param>
		/// <param name="newRowDiv">�V�K�s�敪</param>
		/// <param name="isView">�\���敪</param>
		private void CreateNewRowToRow( DataRow parentRow, ref DataRow childRow, int newRowDiv, bool isView )
		{
			childRow = this._inventInputAcs.InventDataTable.NewRow();

			// �f�[�^�̃R�s�[
			this._inventInputAcs.CopyRowToRow(parentRow, ref childRow, isView);

			// �t�@�C���w�b�_������
			Guid newRowGuid = Guid.NewGuid();
			// �쐬����
			childRow[InventInputResult.ct_Col_CreateDateTime] = DateTime.MinValue;
			// �X�V����
			childRow[InventInputResult.ct_Col_UpdateDateTime] = DateTime.MinValue;
			// GUID
			childRow[InventInputResult.ct_Col_FileHeaderGuid] = Guid.Empty;
			// �X�V�]�ƈ��R�[�h
			childRow[InventInputResult.ct_Col_UpdEmployeeCode] = "";
			// �X�V�A�Z���u��ID1
			childRow[InventInputResult.ct_Col_UpdAssemblyId1] = "";
			// �X�V�A�Z���u��ID2
			childRow[InventInputResult.ct_Col_UpdAssemblyId2] = "";
			// �_���폜�敪
			childRow[InventInputResult.ct_Col_LogicalDeleteCode] = 0;

			// �ړ����
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //childRow[InventInputResult.ct_Col_MoveStatus] = 0;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            childRow[InventInputResult.ct_Col_MoveStockCount] = 0;

			// �L�[����
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //childRow[InventInputResult.ct_Col_ProductNumber] = "";
            //childRow[InventInputResult.ct_Col_ProductStockGuid] = newRowGuid;
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            childRow[InventInputResult.ct_Col_key] = newRowGuid;
			#region // 2007.07.24 kubo del
			//childRow[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.NotView;
			#endregion

			childRow[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 2007.07.24 kubo add

			childRow[InventInputResult.ct_Col_UpdateDiv] = 0; // �X�V�Ώ�
			childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
			childRow[InventInputResult.ct_Col_InventoryNewDiv] = newRowDiv;
			childRow[InventInputResult.ct_Col_InventoryNewDivName] = "";

			this._inventInputAcs.InventDataTable.Rows.Add(childRow);
		}
        */
        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        #region �� �e���q�I�����W�J����(���ԊǗ��L-���i���f�[�^�p����)
        /*
        /// <summary>
		/// �e���q�I�����W�J����(���ԊǗ��L-���i���f�[�^�p����)
		/// </summary>
		/// <param name="childDv">�W�JDataView</param>
		/// <param name="index">index</param>
		/// <param name="stockCnt">���됔</param>
		/// <param name="inventCnt"></param>
		/// <returns>true:���̂܂ܑ��s, false:�����I��</returns>
		private bool ChangeChildRowInvent( ref DataView childDv, int index, double stockCnt, double inventCnt )
		{
			
			bool isReturn = true;
			DataRow childRow;
			if ( index >= childDv.Count )
				return false;
		    // �q�s�ɔ��f
			childRow = childDv[index].Row;
			if ( index < inventCnt )
			{
				// index���݌ɒI������菬�����ꍇ
				if ( inventCnt == 0 )
					ChangeCommitToleranceCnt( 
						ref childRow, 
						0 - (double)childRow[InventInputResult.ct_Col_StockTotal], 
						0, 
						false );
				else
					ChangeCommitToleranceCnt( 
						ref childRow, 
						1 - (double)childRow[InventInputResult.ct_Col_StockTotal], 
						1, 
						false );
			}
			else
			{
				// index���݌ɒI�������傫���ꍇ
				ChangeCommitToleranceCnt( 
					ref childRow, 
					0 - (double)childRow[InventInputResult.ct_Col_StockTotal], 
					0, 
					false );
			}
			isReturn = true;
			return isReturn;
		}
        */
        #endregion
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region �� ���ِ����f����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���ِ����f����
        /// </summary>
        /// <param name="childDr">�q�s</param>
        /// <param name="toleCnt">���ِ�</param>
        /// <param name="invStcCnt">�I����</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �q���e�֍��ِ��𔽉f����</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int ChangeCommitToleranceCnt(ref DataRow childDr, double toleCnt, double invStcCnt)
        {
            DataRow targetDr;

            // ���i���̂Ƃ��͈�����DataRow�ɓ���
            targetDr = childDr;

            // �O�񍷈ِ��ɍ��񍷈ِ����Z�b�g
            double bfInvToleCnt = 0;
            if (targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value)
            {
                bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
            }
            else
            {
                bfInvToleCnt = 0;
            }
            // �O�񍷈ِ�
            targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;
            // �I����
            targetDr[InventInputResult.ct_Col_InventoryStockCnt] = invStcCnt;
            // �ύX�敪���Z�b�g
            targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

            // ���ِ�
            //targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] =
            //    (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetDr[InventInputResult.ct_Col_StockTotal];
            targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] = toleCnt;

            // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------->>>>>
            double stockUnitPrice = (double)targetDr[InventInputResult.ct_Col_StockUnitPrice];
            targetDr[InventInputResult.ct_Col_InventoryStockPrice] = this._inventInputAcs.GetTotalPriceToLong(invStcCnt, stockUnitPrice);
            // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------------------------<<<<<

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// ���ِ����f����
		/// </summary>
		/// <param name="childDr">�q�s</param>
		/// <param name="toleCnt">���ِ�</param>
		/// <param name="invStcCnt">�I����</param>
		/// <param name="isProductFlg">���Ԗ��s�t���O(true:���Ԗ�, false:���i��)</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �q���e�֍��ِ��𔽉f����</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private int ChangeCommitToleranceCnt( ref DataRow childDr, double toleCnt, double invStcCnt, bool isProductFlg )
		{
			DataRow targetDr;
			if ( isProductFlg )
			{
				double parentToleCnt = 0;
				// ���Ԃ̂Ƃ��̏���
				// ���Ԏq�s���ύX���ꂽ�Ƃ��͐e�s��{��
				// �e�s�̎擾
				#region // 2007.07.19 kubo del
				//DataView parentDv = 
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods, childDr ),
				//            (int)InventInputSearchCndtn.ViewState.View),
				//        "",
				//        DataViewRowState.CurrentRows);
				//if ( parentDv.Count > 0 )
				//{
				//    // �e�s�͈�s���������Ă��Ȃ��͂��Ȃ̂�DataView�̗v�f��Index��0�ŌŒ�
				//    targetDr = parentDv[0].Row;
				//}
				//else
				//{
				//    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				//}
				#endregion

				// 2007.07.19 kubo add ------------->
				targetDr = this._inventInputAcs.InventDataTable.Rows.Find( 
					this._inventInputAcs.GetPrimaryKeyList(childDr, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));

				if ( targetDr == null )
				{
					// �ҏW�̂Ƃ��Ƃ��e�s�������f�[�^���ł����肷��̂ŐV�K�ɐe�s�����
					this._inventInputAcs.MakeGrossData( childDr, true );
					return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				}
				else
				{
					#region 2007.07.19 kubo del
					//this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
					//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods, childDr ),
					//            (int)InventInputSearchCndtn.ViewState.View );
					//this._inventInputView.Sort = "";
					//this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

					//if ( _inventInputView.Count > 0 )
					//{
					//    // �e�s�͈�s���������Ă��Ȃ��͂��Ȃ̂�DataView�̗v�f��Index��0�ŌŒ�
					//    targetDr = _inventInputView[0].Row;
					//}
					//else
					//{
					//    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
					//}
					#endregion
					// 2007.07.19 kubo add <-------------

					// �e�̍��ِ����擾���邽�߂Ɏq�s�̒I�����̍��v���擾����
					object sumInvStkCnt = this._inventInputAcs.InventDataTable.Compute(
						string.Format("Sum({0})",InventInputResult.ct_Col_InventoryStockCnt),
						MakeParentOrChildRowGetQuery( 
							MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, childDr ),
							(int)InventInputSearchCndtn.ViewState.View)	);
					
					if ( sumInvStkCnt == DBNull.Value )
					{
						parentToleCnt = 0;
					}
					else
					{
						parentToleCnt = (double)sumInvStkCnt;
					}

					double bfInvToleCnt = 0;
					if ( targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value )
					{
						bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
					}
					else
					{
						bfInvToleCnt = 0;
					}
					// �O�񍷈ِ�
					targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;
					// �I����
					targetDr[InventInputResult.ct_Col_InventoryStockCnt] = parentToleCnt;
					// �ύX�敪���Z�b�g
					targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				}
			}
			else
			{
				// ���i���̂Ƃ��̏���
				// ���i���̂Ƃ��͈�����DataRow�ɓ���
				targetDr = childDr;

				// �O�񍷈ِ��ɍ��񍷈ِ����Z�b�g
				double bfInvToleCnt = 0;
				if ( targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value )
				{
					bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
				}
				else
				{
					bfInvToleCnt = 0;
				}
				// �O�񍷈ِ�
				targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;
				// �I����
				targetDr[InventInputResult.ct_Col_InventoryStockCnt] = invStcCnt;
				// �ύX�敪���Z�b�g
				targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

			}

			// ���ِ�
			targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] =
				(double)targetDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetDr[InventInputResult.ct_Col_StockTotal];
			
			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �I�����W�J����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I�����W�J����
        /// </summary>
        /// <param name="targetRow">�Ώ�Row</param>
        /// <param name="viewDate">�ݒ���t</param>
        /// <returns>Status</returns>
        private int AfterInputInventoryDate(ref DataRow targetRow, DateTime viewDate)
        {
            DateTime invDate = viewDate;

            // �ύX��������ꂽRow���g�̕ύX
            this._inventInputAcs.DevInventoryDay(targetRow, invDate);

            // �e�s���q�s���𔻒f���Ă��ꂼ��ɓW�J����
            if ((int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods)
            {
                // ���i�ɓ��͂��ꂽ�ꍇ
                // �q�s���擾���I���������͂���Ă���q�s�̓��t���X�V����
                // �q�s���擾
                // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                //this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                //            MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetRow),
                //            (int)InventInputSearchCndtn.ViewState.Both);
                //this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
                //this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

                //DataRow childRow;
                //for (int index = 0; index < this._inventInputView.Count; index++)
                //{
                //    childRow = this._inventInputView[index].Row;
                //    // �q�s�̓��t�̕ύX
                //    this._inventInputAcs.DevInventoryDay(childRow, invDate);

                //    // �ύX�敪���Z�b�g
                //    childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                //}
                // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                this._inventInputView.Sort = InventInputResult.ct_Col_SectionCode + "," + InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode
                                            + "," + InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_SupplierCode + "," + InventInputResult.ct_Col_ShipCustomerCode
                                            + "," + InventInputResult.ct_Col_StockDiv + "," + InventInputResult.ct_Col_GrossDiv;
                object[] primaryKeyObjList = new object[]{
				targetRow[InventInputResult.ct_Col_SectionCode].ToString(),			// ���_�R�[�h
				targetRow[InventInputResult.ct_Col_WarehouseCode].ToString(),			// �q�ɃR�[�h
				(int)targetRow[InventInputResult.ct_Col_MakerCode],				// ���[�J�[�R�[�h
                targetRow[InventInputResult.ct_Col_GoodsNo].ToString(),             // �i��
				(int)targetRow[InventInputResult.ct_Col_SupplierCode],		// �d����R�[�h
				(int)targetRow[InventInputResult.ct_Col_ShipCustomerCode],		// �ϑ���R�[�h
				(int)targetRow[InventInputResult.ct_Col_StockDiv],				// �݌ɋ敪
				(int)InventInputSearchCndtn.GrossDivState.Product// �W�v�敪
				};

                // �t�B���^�N���A
                this._inventInputView.RowFilter = string.Empty; // ADD by xuyb 2014/10/31 for ��Q���ۇA�̑Ή�

                DataRowView[] drv = this._inventInputView.FindRows(primaryKeyObjList);

                DataRow childRow;
                foreach (DataRowView dataRowView in drv)
                {
                    childRow = dataRowView.Row;
                    // �q�s�̓��t�̕ύX
                    this._inventInputAcs.DevInventoryDay(childRow, invDate);

                    // �ύX�敪���Z�b�g
                    childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
            }
            else
            {
                // �e�s���擾���e�s�̓��t�Ǝq�s�̓��t���r���q�s�̓��t���V�����Ȃ�ΐe�s�ɔ��f
                ChangeCommitInventoryDay(ref targetRow, invDate, true);
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �I�����W�J����
		/// </summary>
		/// <param name="targetRow">�Ώ�Row</param>
		/// <param name="viewDate">�ݒ���t</param>
		/// <returns>Status</returns>
		private int AfterInputInventoryDate( ref DataRow targetRow, DateTime viewDate )
		{
			DateTime invDate = viewDate;

			//if ( invDate == DateTime.MinValue ) invDate = viewDate;
			// �ύX��������ꂽRow���g�̕ύX
			this._inventInputAcs.DevDate( targetRow, invDate,
				InventInputResult.ct_Col_InventoryDay,
				InventInputResult.ct_Col_InventoryDay_Datetime,
				InventInputResult.ct_Col_InventoryDay_Year,
				InventInputResult.ct_Col_InventoryDay_Month,
				InventInputResult.ct_Col_InventoryDay_Day);

			// �e�s���q�s���𔻒f���Ă��ꂼ��ɓW�J����
			if ( (int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
			{
				// ���i�ɓ��͂��ꂽ�ꍇ
				// �q�s���擾���I���������͂���Ă���q�s�̓��t���X�V����
				// �q�s���擾
				#region // 2007.07.19 kubo del
				//DataView childDv = 
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
				//            (int)InventInputSearchCndtn.ViewState.Both ),
				//        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//        DataViewRowState.CurrentRows);
				#endregion

				// 2007.07.19 kubo add ------------->
				this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
							MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
							(int)InventInputSearchCndtn.ViewState.Both );
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //this._inventInputView.Sort = string.Format("{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber);
                this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
				// 2007.07.19 kubo add <-------------

				DataRow childRow;
				// for( int index = 0; index < childDv.Count; index++ )	// 2007.07.19 kubo del
				for( int index = 0; index < this._inventInputView.Count; index++ ) // 2007.07.19 kubo add
				{
					// childRow = childDv[index].Row;	// 2007.07.19 kubo del
					childRow = this._inventInputView[index].Row;	// 2007.07.19 kubo add
					// �q�s�̓��t�̕ύX
					this._inventInputAcs.DevDate( childRow, invDate,
						InventInputResult.ct_Col_InventoryDay,
						InventInputResult.ct_Col_InventoryDay_Datetime,
						InventInputResult.ct_Col_InventoryDay_Year,
						InventInputResult.ct_Col_InventoryDay_Month,
						InventInputResult.ct_Col_InventoryDay_Day);
					#region�@// 2007.07.19 kubo del
					//if ( ( childRow[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value ) || 
					//     ( (DateTime)childRow[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue) )	// TODO:DBNull.Value �Ƃ̔�r��������
					//{
					//    // �q�s�̓��t�̕ύX
					//    this._inventInputAcs.DevDate( childRow, invDate,
					//        InventInputResult.ct_Col_InventoryDay,
					//        InventInputResult.ct_Col_InventoryDay_Datetime,
					//        InventInputResult.ct_Col_InventoryDay_Year,
					//        InventInputResult.ct_Col_InventoryDay_Month,
					//        InventInputResult.ct_Col_InventoryDay_Day);
					//}
					#endregion
					// �ύX�敪���Z�b�g
					childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

				}

			}
			else
			{
				// ���Ԃɓ��͂��ꂽ�ꍇ

				// ���Ԗ����́H
				#region // 2007.07.24 kubo del
				//if ( targetRow[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
				//{
				//    #region // 2007.07.19 kubo del
				//    //DataView childDv = 
				//    //    new DataView( 
				//    //        this._inventInputAcs.InventDataTable, 
				//    //        MakeParentOrChildRowGetQuery( 
				//    //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
				//    //            (int)InventInputSearchCndtn.ViewState.NotView ),
				//    //        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//    //        DataViewRowState.CurrentRows);
				//    #endregion

				//    // 2007.07.19 kubo add ------------->
				//    this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
				//                MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
				//                (int)InventInputSearchCndtn.ViewState.NotView );
				//    this._inventInputView.Sort = string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber );
				//    this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
				//    // 2007.07.19 kubo add <-------------

				//    DataRow childRow;
				//    //for( int index = 0; index < childDv.Count; index++ )	// 2007.07.19 kubo del
				//    for( int index = 0; index < this._inventInputView.Count; index++ )	// 2007.07.19 kubo add
				//    {
				//        //childRow = childDv[index].Row;	// 2007.07.19 kubo del
				//        childRow = this._inventInputView[index].Row;		// 2007.07.19 kubo add

				//        // �q�s�̓��t�̕ύX
				//        this._inventInputAcs.DevDate( childRow, invDate,
				//            InventInputResult.ct_Col_InventoryDay,
				//            InventInputResult.ct_Col_InventoryDay_Datetime,
				//            InventInputResult.ct_Col_InventoryDay_Year,
				//            InventInputResult.ct_Col_InventoryDay_Month,
				//            InventInputResult.ct_Col_InventoryDay_Day);
				//        #region
				//        //if ( ( (DateTime)childRow[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue) || 
				//        //     ( childRow[InventInputResult.ct_Col_InventoryDay] == DBNull.Value ) )	// TODO:DBNull.Value �Ƃ̔�r��������
				//        //{
				//        //    // �q�s�̓��t�̕ύX
				//        //    this._inventInputAcs.DevDate( childRow, invDate,
				//        //        InventInputResult.ct_Col_InventoryDay,
				//        //        InventInputResult.ct_Col_InventoryDay_Datetime,
				//        //        InventInputResult.ct_Col_InventoryDay_Year,
				//        //        InventInputResult.ct_Col_InventoryDay_Month,
				//        //        InventInputResult.ct_Col_InventoryDay_Day);
				//        //}
				//        #endregion
				//        // �ύX�敪���Z�b�g
				//        childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

				//    }
				//}
				#endregion
				// �e�s���擾���e�s�̓��t�Ǝq�s�̓��t���r���q�s�̓��t���V�����Ȃ�ΐe�s�ɔ��f
				ChangeCommitInventoryDay( ref targetRow, invDate, true );
			}
			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        #region �� �I�ԓ��͌㏈��
        /// <summary>
        /// �I�ԓ��͌㏈��
        /// </summary>
        /// <param name="targetDr"></param>
        /// <param name="shelfNo"></param>
        /// <param name="targetCol"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �I�Ԃ̓��͌㏈�����s��</br>
        /// <br>Programer  : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.11</br>
        /// </remarks>
        private int AfterInputWarehouseShelfNo(ref DataRow targetDr, string shelfNo, string targetCol)
        {
            // �I��
            //targetDr[InventInputResult.ct_Col_WarehouseShelfNo] = shelfNo;
            targetDr[targetCol] = shelfNo;

            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
                        (int)InventInputSearchCndtn.ViewState.Both);
            this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            DataRow childRow;
            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                childRow = this._inventInputView[index].Row;
                // �I��
                //childRow[InventInputResult.ct_Col_WarehouseShelfNo] = shelfNo;
                childRow[targetCol] = shelfNo;

                // �ύX�敪���Z�b�g
                childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion
        // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

        // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------->>>>>
        #region �� �d���P��(����)���͌㏈��
        /// <summary>
        /// �d���P��(����)���͌㏈��
        /// </summary>
        /// <param name="targetDr">�ΏۂƂȂ�s</param>
        /// <param name="stockUnitPrice">�d���P��(����)</param>
        /// <param name="targetCol">�ΏۂƂȂ��</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �d���P��(����)�̓��͌㏈�����s��</br>
        /// <br>Programer  : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2009/12/03 ����� �o�l�D�m�r�ێ�˗��B</br>
        /// <br>             ���됔��0�̍s�̌��P����ύX���ɃG���[���������Ȃ��悤�ɕύX����</br>
        /// </remarks>
        private int AfterInputStockUnitPrice(ref DataRow targetDr, double stockUnitPrice, string targetCol)
        {
            // �d���P��
            targetDr[targetCol] = stockUnitPrice;

            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
                        (int)InventInputSearchCndtn.ViewState.Both);
            this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            DataRow childRow;
            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                childRow = this._inventInputView[index].Row;
                // �d���P��
                childRow[targetCol] = stockUnitPrice;

                // �d���P���ύX�ɔ����X�V
                double stockTotal = (double)targetDr[InventInputResult.ct_Col_StockTotal];

                // --- UPD 2009/12/03 ---------->>>>>
                //double invStockCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
                double invStockCnt = 0;
                if (targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
                {
                    invStockCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
                }
                // --- UPD 2009/12/03 ----------<<<<<

                childRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] = 1;                                                                          //�d���P���ύX�t���O
                // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------------------------------------------------->>>>>
                childRow[InventInputResult.ct_Col_StockMashinePrice] = this._inventInputAcs.GetTotalPriceToLong(stockTotal, stockUnitPrice);        //�}�V���݌Ɋz
                childRow[InventInputResult.ct_Col_InventoryStockPrice] = this._inventInputAcs.GetTotalPriceToLong(invStockCnt,  stockUnitPrice);    //�I���݌Ɋz
                // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------------------------------------------------------------------<<<<<

                // �ύX�敪���Z�b�g
                childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion
        // ---ADD 2009/05/14 �s��Ή�[13260] -----------------------------<<<<<

        #region �� �I�������f����
        /// <summary>
        /// �I�������f����
        /// </summary>
        /// <param name="childDr">���ɂȂ�Row</param>
        /// <param name="inventoryDay">�I����</param>
        /// <param name="isProductFlg">���Ԗ��s�t���O(true:���Ԗ�, false:���i��)</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �I�������f�������s��</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private int ChangeCommitInventoryDay(ref DataRow childDr, DateTime inventoryDay, bool isProductFlg)
        {
            DataRow targetDr;
            if (isProductFlg)
            {
                // ���Ԃ̂Ƃ��̏���

                // ���Ԏq�s���ύX���ꂽ�Ƃ��͐e�s��{��
                // �e�s�̎擾
                #region // 2007.07.19 kubo del
                //DataView targetDv = 
                //    new DataView( 
                //        this._inventInputAcs.InventDataTable, 
                //        MakeParentOrChildRowGetQuery( 
                //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods, childDr ),
                //            (int)InventInputSearchCndtn.ViewState.Both),
                //        "",
                //        DataViewRowState.CurrentRows);
                //if ( targetDv.Count > 0 )
                //{
                //    // �e�s�͈�s���������Ă��Ȃ��͂��Ȃ̂�DataView�̗v�f��Index��0�ŌŒ�
                //    if ( targetDv[0] == null )
                //    {
                //        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //    }
                //    targetDr = targetDv[0].Row;
                //}
                //else
                //{
                //    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //}
                #endregion

                // 2007.07.19 kubo add ------------->
                targetDr = this._inventInputAcs.InventDataTable.Rows.Find(
                    this._inventInputAcs.GetPrimaryKeyList(childDr, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty));

                if (targetDr == null)
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                // 2007.07.19 kubo add <-------------

                // �q�s�̓��t���e�s�̓��t���V���������ꍇ�̂ݐe�s�̓��t���X�V
                if ((targetDr[InventInputResult.ct_Col_InventoryDay] == DBNull.Value) ||
                    ((targetDr[InventInputResult.ct_Col_InventoryDay] == null) ||
                      ((int)childDr[InventInputResult.ct_Col_InventoryDay] > (int)targetDr[InventInputResult.ct_Col_InventoryDay])
                    )
                )
                {
                    this._inventInputAcs.DevInventoryDay(targetDr, inventoryDay);
                }
            }
            else
            {
                // ���i���̂Ƃ��̏���
                // ���i���̂Ƃ��͈�����DataRow�ɓ���
                targetDr = childDr;

                this._inventInputAcs.DevInventoryDay(targetDr, inventoryDay);
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion

        #region �� query�쐬�pDictionary�쐬����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// query�쐬�pDictionary�쐬����
        /// </summary>
        /// <param name="grossDiv">�O���X�敪</param>
        /// <param name="dr">DataRow</param>
        /// <returns>query�쐬�pDictionary</returns>
        private Dictionary<string, object> MakeDictionary(int grossDiv, DataRow dr)
        {
            Dictionary<string, object> queryDic = new Dictionary<string, object>();

            // ���_�R�[�h
            queryDic.Add(InventInputResult.ct_Col_SectionCode, dr[InventInputResult.ct_Col_SectionCode].ToString());
            // �q�ɃR�[�h
            queryDic.Add(InventInputResult.ct_Col_WarehouseCode, dr[InventInputResult.ct_Col_WarehouseCode].ToString());
            // ���[�J�[�R�[�h
            queryDic.Add(InventInputResult.ct_Col_MakerCode, (int)dr[InventInputResult.ct_Col_MakerCode]);
            // �i��
            queryDic.Add(InventInputResult.ct_Col_GoodsNo, dr[InventInputResult.ct_Col_GoodsNo].ToString());
            // �d����R�[�h
            queryDic.Add(InventInputResult.ct_Col_SupplierCode, (int)dr[InventInputResult.ct_Col_SupplierCode]);
            // �ϑ���R�[�h
            queryDic.Add(InventInputResult.ct_Col_ShipCustomerCode, (int)dr[InventInputResult.ct_Col_ShipCustomerCode]);
            // �݌ɋ敪
            queryDic.Add(InventInputResult.ct_Col_StockDiv, (int)dr[InventInputResult.ct_Col_StockDiv]);
            // �W�v�敪
            queryDic.Add(InventInputResult.ct_Col_GrossDiv, grossDiv);

            return queryDic;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// query�쐬�pDictionary�쐬����
        /// </summary>
        /// <param name="grossDiv">�O���X�敪</param>
        /// <param name="dr">DataRow</param>
        /// <returns>query�쐬�pDictionary</returns>
        private Dictionary<string, object> MakeDictionary(int grossDiv, DataRow dr)
        {
            Dictionary<string, object> queryDic = new Dictionary<string, object>();

            // ���_�R�[�h
            queryDic.Add(InventInputResult.ct_Col_SectionCode, dr[InventInputResult.ct_Col_SectionCode].ToString());
            // �q�ɃR�[�h
            queryDic.Add(InventInputResult.ct_Col_WarehouseCode, dr[InventInputResult.ct_Col_WarehouseCode].ToString());
            // ���[�J�[�R�[�h
            queryDic.Add(InventInputResult.ct_Col_MakerCode, (int)dr[InventInputResult.ct_Col_MakerCode]);
            // �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //queryDic.Add( InventInputResult.ct_Col_GoodsCode			, dr[InventInputResult.ct_Col_GoodsCode			].ToString() );
            queryDic.Add(InventInputResult.ct_Col_GoodsNo, dr[InventInputResult.ct_Col_GoodsNo].ToString());
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���Ǝ҃R�[�h
            //queryDic.Add( InventInputResult.ct_Col_CarrierEpCode		, (int)dr[InventInputResult.ct_Col_CarrierEpCode		] );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // �d����R�[�h
            queryDic.Add(InventInputResult.ct_Col_CustomerCode, (int)dr[InventInputResult.ct_Col_CustomerCode]);
            // �ϑ���R�[�h
            queryDic.Add(InventInputResult.ct_Col_ShipCustomerCode, (int)dr[InventInputResult.ct_Col_ShipCustomerCode]);
            // �d���P��
            // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //queryDic.Add( InventInputResult.ct_Col_StockUnitPrice		, (long)dr[InventInputResult.ct_Col_StockUnitPrice		] );
            // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
            // �݌ɋ敪
            queryDic.Add(InventInputResult.ct_Col_StockDiv, (int)dr[InventInputResult.ct_Col_StockDiv]);
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �݌ɏ��
            //queryDic.Add( InventInputResult.ct_Col_StockState			, (int)dr[InventInputResult.ct_Col_StockState			] );
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            //// �V�K�敪
            //queryDic.Add( InventInputResult.ct_Col_InventoryNewDiv		, (int)dr[InventInputResult.ct_Col_InventoryNewDiv		] );
            // �W�v�敪
            queryDic.Add(InventInputResult.ct_Col_GrossDiv, grossDiv);

            return queryDic;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� KeyDownProc����
		/// <summary>
		/// KeyDownProc����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g(Grid KeyDown Event��sender)</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		public void KeyDownProc( object sender, ref KeyEventArgs e )
		{
			// �ҏW���̏ꍇ
			UltraGrid targetGrid = (UltraGrid)sender;
			if( ( targetGrid.ActiveCell != null ) && ( targetGrid.ActiveCell.IsInEditMode == true ) ) 
			{
				// �Z���X�^�C���Ŕ���
				switch( e.KeyData ) 
				{
					case Keys.Up	:	// ���L�[
					{								
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
						// �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Down:
					{
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
						// �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					// ���L�[
					case Keys.Left:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// �ҏW���Ȃ牽�����Ȃ�
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart != 0)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab );
						e.Handled = true;
						break;
					}
					// ���L�[
					case Keys.Right:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// �ҏW���Ȃ牽�����Ȃ�
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart < targetGrid.ActiveCell.Text.Length)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab );
						e.Handled = true;
						break;
					}
					case Keys.Enter:
					{
						// EnterKey�������ꂽ�Ƃ���TRetKeyContorol�Ő��䂳���
						// �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Escape:	// ESC�L�[
					{
						// 2007.07.30 kubo add ------->
						Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.uGrid_InventInput.ActiveCell;
						// �I�����A�I���X�V���ȊO��ESC�������ꂽ�Ƃ�
						if (
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt	) != 0 || 
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt	) != 0 ||
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year	) != 0 ||
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Month ) != 0 ||
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day	) != 0 )
						{
							this._isChangeInventStcCnt = true;
							this._isChangeInventDate = true;
                            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                            this._isChangeWarehouseShelfNo = true;
                            this._isChangeDuplicationShelfNo1 = true;
                            this._isChangeDuplicationShelfNo2 = true;
                            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                            this._isChangeStockUnitPrice = true;
                            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

							activeCell = this.uGrid_InventInput.ActiveCell;

							if ( targetGrid.ActiveRow != null )
								targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

							targetGrid.PerformAction(UltraGridAction.EnterEditMode);
						}
						// 2007.07.30 kubo add <-------
						this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

						UltraGridRow targetGridRow;
						targetGridRow = targetGrid.ActiveCell.Row;
						double bfInventStkCnt = 0;	// �ύX�O�I����
						// �I����
						if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value )
							bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
						if ( ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value ) )
						{
							targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
							targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}

							// �I����
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value )
								bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
						
							InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );

							e.Handled = true;
							break;
						}

						targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
						// ���ِ�
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
						// �I����
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
						
						InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );
						
						targetGrid.ActiveCell = activeCell;
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

						e.Handled = true;
						break;
					}
				}
			}
			else
			{
				switch( e.KeyData )
				{
					case Keys.Escape:	// ESC�L�[
					{
						this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
						UltraGridRow targetGridRow;
						targetGridRow = targetGrid.ActiveRow;
						if ( targetGrid.ActiveRow != null )
						{
							targetGridRow = targetGrid.ActiveRow;
						}
						else if ( targetGrid.Selected.Rows[0] != null )
						{
							targetGridRow = targetGrid.Selected.Rows[0];
						}
						else
						{
							e.Handled = false;
							break;
						}
						double bfInventStkCnt = 0;	// �ύX�O�I����
						// �I����
						if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value )
							bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
						if ( ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value ) )
						{

							targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
							targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
						
							InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );

							e.Handled = true;
							break;
						}

						// �I����
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
						// ���ِ�
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
						// �I����
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;

						InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );


						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

						e.Handled = true;
						break;
					}
				}
			}
		}
		#endregion

		#region �� KeyPress����
		/// <summary>
		/// KeyPress����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g(Grid KeyDown Event��sender)</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		public void KeyPressProc( object sender, ref KeyPressEventArgs e )
		{
			//�A�N�e�B�u�Z��
			Infragistics.Win.UltraWinGrid.UltraGridCell	activeCell = ((UltraGrid)sender).ActiveCell;

			// �O���X�敪
			//�A�N�e�B�u�Z������������
			if (activeCell != null)
			{
                // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                //int grossDiv = (int)activeCell.Row.Cells[InventInputResult.ct_Col_GrossDiv].Value;
                // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //string productNum = activeCell.Row.Cells[InventInputResult.ct_Col_ProductNumber].Value.ToString();
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

				if (activeCell.IsInEditMode == false) return;

				switch ( activeCell.Column.Key )
				{
					case InventInputResult.ct_Col_InventoryStockCnt		:	// �I����
						// 2007.07.31 kubo Edit -------------------->
						#region
						// if (KeyPressCheck( 0, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true, grossDiv, productNum ) == false)
						#endregion
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
						//if (KeyPressCheck( 0, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true, grossDiv, productNum, true ) == false)
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(0, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true, grossDiv, true) == false)
                        if (KeyPressCheck(11, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.07.31 kubo Edit <--------------------
						{
							e.Handled = true;
							return;
						}
						break;

					case InventInputResult.ct_Col_InventoryDay_Year		:	//�I�����t�NEdit
						// 2007.07.31 kubo Edit -------------------->
						#region
						//if ( KeyPressCheck( 4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum) == false )
						#endregion
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, true) == false)
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, true) == false)
                        if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.07.31 kubo Edit <--------------------
						{
							e.Handled = true;
							return;
						}
						break;
					case InventInputResult.ct_Col_InventoryDay_Month	:	//�I�����t��Edit
					case InventInputResult.ct_Col_InventoryDay_Day		:	//�I�����t��Edit
						// 2007.07.31 kubo Edit -------------------->
						#region
						//if ( KeyPressCheck( 2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum) == false )
						#endregion
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, true) == false)
                        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, true) == false)
                        if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.07.31 kubo Edit <--------------------
						{
							e.Handled = true;
							return;
						}
						break;
                    // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    case InventInputResult.ct_Col_StockUnitPrice        :   //�d���P��Edit
                        if (KeyPressCheck(11, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.31 kubo Add -------------------->
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //case InventInputResult.ct_Col_ProductNumber:
					//	// ���͕�������������
					//	if ( Char.IsLower( e.KeyChar ) )
					//	{
					//		e.KeyChar = Char.ToUpper( e.KeyChar );
					//	}
					//	if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, false ) == false)
					//	{
					//		e.Handled = true;
					//		return;
					//	}
					//	break;
					//case InventInputResult.ct_Col_StockTelNo1			:	// �d�b�ԍ�1
					//case InventInputResult.ct_Col_StockTelNo2			:	// �d�b�ԍ�2
					//	if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, false ) == false)
					//	{
					//		e.Handled = true;
					//		return;
					//	}
					//	break;
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.31 kubo Add -------------------->
				}
			}	
		}
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� ���l���̓`�F�b�N����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
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
        /// <param name="isNumOnly">���l�̂݋敪(true:���l�̂�, false:���l�ȊO��)</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isNumOnly)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key) == true)
            {
                return true;
            }

            if (isNumOnly)
            {
                // ���l�ȊO�́A�m�f
                if (Char.IsNumber(key) == false)
                {
                    // �����_�܂��́A�}�C�i�X�ȊO
                    if ((key != '.') && (key != '-'))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
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

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

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
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;

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
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
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
        /// <param name="isNumOnly">���l�̂݋敪(true:���l�̂�, false:���l�ȊO��)</param>
		/// <returns>true=���͉�,false=���͕s��</returns>
        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isInvStk, int grossDiv, string productNum, bool isNumOnly)
        // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isInvStk, int grossDiv, bool isNumOnly)
        public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isNumOnly)
        // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
        // 2007.07.31 kubo Edit
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(key) == true)
			{
                return true;
            }

			if( isNumOnly )
			{
				// ���l�ȊO�́A�m�f
				if (Char.IsNumber(key) == false)
				{
                    // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                    //return false;
                    // �����_�ȊO
                    if (key != '.')
                    {
                        return false;
                    }
                    // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                }
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

			//// �}�C�i�X�̃`�F�b�N
			//if (key == '-')
			//{
			//    if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
			//    {
			//        return false;
			//    }
			//}

            // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
			_strResult = prevVal.Substring(0, selstart) 
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));

            // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �I���������͂��ꂽ��
            //if ( isInvStk )
            //{
            //    // ���͒l�`�F�b�N
            //    // if ( ( grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product ) && ( productNum.CompareTo("") != 0 ) )
            //    if ( grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product )
            //    {
            //        // ���ԊǗ�����Ő��ԓ��͍ςȂ���͂�1or0�̂�
            //        if ( ( key != '1' ) && ( key != '0' ) )
            //        {
            //            return false;
            //        }
            //        keta = 1;
            //    }
            //    else
            //    {
            //        // ���ԊǗ����� or ���Ԗ����͂Ȃ���͂�0�ȏ�
            //        keta = 9;
            //    }
            //}
            // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<

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
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� ���t���̓`�F�b�N����
        #region DEL 2008/0901 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="targetDate">�`�F�b�N�ΏۃR���g���[��</param>
        /// <param name="allowEmpty">�����͋���[true:����, false:�s����]</param>
        /// <returns>�`�F�b�N����(true/false)</returns>
        /// <remarks>
        /// <br>Note		: ���t���͂̃`�F�b�N���s���B</br>
        /// <br>Programmer	: 22013 �v�� ����</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
        private bool DateEditInputCheck(DateTime targetDate, bool allowEmpty)
        {
            bool status = true;

            // ���͓��t�𐔒l�^�Ŏ擾
            int date = TDateTime.DateTimeToLongDate(targetDate);
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            // ���t�����̓`�F�b�N
            if (targetDate == DateTime.MinValue)
            {
                if (allowEmpty == true)
                {
                    return status;
                }
                else
                {
                    status = false;
                }
            }
            // �V�X�e���T�|�[�g�`�F�b�N
            else if (yy < 1900)
            {
                status = false;
            }
            // �N�����ʓ��̓`�F�b�N
            else if ((yy == 0) || (mm == 0) || (dd == 0))
            {
                status = false;
            }
            // �P�����t�Ó����`�F�b�N
            else if (TDateTime.IsAvailableDate(targetDate) == false)
            {
                status = false;
            }

            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/0901 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="targetDate">�`�F�b�N�ΏۃR���g���[��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true/false)</returns>
        /// <remarks>
        /// <br>Note		: ���t���͂̃`�F�b�N���s���B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/09/01</br>
        /// </remarks>
        private bool DateEditInputCheck(TDateEdit tDateEdit, out string errMsg)
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

        #region �� ���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 22013 �v�� ����</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string message, emErrorLevel iLevel)
        {
            // ���b�Z�[�W�\��
            return TMsgDisp.Show(
                this,                            // �e�E�B���h�E�t�H�[��
                iLevel,                             // �G���[���x��
                this.GetType().ToString(),          // �A�Z���u���h�c�܂��̓N���X�h�c
                message,                            // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);             // �\������{�^��
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="msg">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="proc">���������\�b�hID</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <remarks>
        /// <br>Programmer : 22013 �v�� ����</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, emErrorLevel iLevel)
        {
            return TMsgDisp.Show(
                iLevel,						        //�G���[���x��
                "MAZAI05130UB",                       //UNIT�@ID
                "�I������",                            //�v���O��������
                proc,                               //�v���Z�XID
                "",                                 //�I�y���[�V����
                msg,                                //���b�Z�[�W
                status,                             //�X�e�[�^�X
                null,                               //�I�u�W�F�N�g
                MessageBoxButtons.OK,               //�_�C�A���O�{�^���w��
                MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
                );
        }

        /// <summary>
        /// �G���[MSG�\������(Exception)
        /// </summary>
        /// <param name="msg">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="proc">���������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <remarks>
        /// <br>Programmer : 22013 �v�� ����</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, Exception ex, emErrorLevel iLevel)
        {
            return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
        }
        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �� �I���f�[�^�ύX�L������
        /// <summary>
        /// �I���f�[�^�ύX�L������
        /// </summary>
        /// <param name="dr">�Ώ�DataRow</param>
        /// <returns>(int)InventInputSearchCndtn.ChangeFlagState</returns>
        private int CheckChangeData(DataRow dr)
        {
            //// �d�b�ԍ�1���ς���Ă���ꍇ
            //if ( (int)dr[InventInputResult.ct_Col_StkTelNo1ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //    return (int)InventInputSearchCndtn.ChangeFlagState.Change;
            //// �d�b�ԍ�2���ς���Ă���ꍇ
            //if ( (int)dr[InventInputResult.ct_Col_StkTelNo2ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //    return (int)InventInputSearchCndtn.ChangeFlagState.Change;
            //// �d���P�����ύX����Ă���ꍇ
            //if ( (int)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //    return (int)InventInputSearchCndtn.ChangeFlagState.Change;
            // �ړ��݌ɂ�����ꍇ
            if ((int)dr[InventInputResult.ct_Col_MoveStockCount] > 0)
                return (int)InventInputSearchCndtn.ChangeFlagState.Change;

            return (int)InventInputSearchCndtn.ChangeFlagState.NotChange;
        }
        #endregion

        #region �� Row�\���F�ύX����
        /// <summary>
        /// Row�\���F�ύX����
        /// </summary>
        /// <param name="ugr">UltraGridRow</param>
        private void ChangeRowColor(UltraGridRow ugr)
        {
            DataRow targetRow = (DataRow)ugr.Cells[InventInputResult.ct_Col_RowSelf].Value;
            // �G���[�X�e�[�^�X�𔻒f���čs�̐F��ύX����
            if ((int)targetRow[InventInputResult.ct_Col_Status] != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ChangeRowColor(ugr, Color.Red);
            }
            else if (CheckChangeData(targetRow) == (int)InventInputSearchCndtn.ChangeFlagState.Change)
            {
                ChangeRowColor(ugr, Color.Blue);
            }
            else
            {
                ChangeRowColor(ugr, Color.Black);
            }
        }
        
		/// <summary>
		/// Row�\���F�ύX����
		/// </summary>
		/// <param name="ugr">UltraGridRow</param>
		/// <param name="setColor">�ݒ�F</param>
		private void ChangeRowColor( UltraGridRow ugr, Color setColor )
		{
			ugr.Appearance.ForeColor = setColor;
			ugr.Appearance.ForeColor = setColor;
		}
        
        #endregion

           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� �e�E�q�s�擾query�쐬
        /// <summary>
        /// �e�E�q�s�擾query�쐬
        /// </summary>
        /// <param name="queryDic">�N�G���[�쐬�pDictionary</param>
        /// <param name="viewDiv">�\���敪</param>
        private string MakeParentOrChildRowGetQuery(Dictionary<string, object> queryDic, int viewDiv)
        {
            // �N�G���̍쐬

            StringBuilder strQuery = new StringBuilder();

            foreach (KeyValuePair<string, object> dic in queryDic)
            {
                if (strQuery.ToString() != "")
                {
                    strQuery.Append(" and ");
                }

                if ((dic.Value.GetType() == typeof(string)) || (dic.Value.GetType() == typeof(char)))
                {
                    strQuery.Append(string.Format("{0}='{1}'", dic.Key.ToString(), dic.Value.ToString()));
                }
                else if (dic.Value.GetType() == typeof(int))
                {
                    strQuery.Append(string.Format("{0}={1}", dic.Key.ToString(), (int)dic.Value));
                }
                else if (dic.Value.GetType() == typeof(long))
                {
                    strQuery.Append(string.Format("{0}={1}", dic.Key.ToString(), (long)dic.Value));
                }
                else if (dic.Value.GetType() == typeof(double))
                {
                    strQuery.Append(string.Format("{0}={1}", dic.Key.ToString(), (double)dic.Value));
                }
            }

            // �\�����
            if (viewDiv != (int)InventInputSearchCndtn.ViewState.Both)
            {
                if (strQuery.ToString() != "")
                {
                    strQuery.Append(" and ");
                }
                strQuery.Append(string.Format("{0}={1}", InventInputResult.ct_Col_ViewDiv, viewDiv));
            }

            // 2007.07.30 kubo add --------------------------->
            if (strQuery.ToString() != "")
            {
                strQuery.Append(" and ");
            }
            strQuery.Append(string.Format("{0}={1}", InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0));
            // 2007.07.30 kubo add <---------------------------


            return strQuery.ToString();
        }
        #endregion

        #region �� Grid�\����ԕύX������
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Grid�\����ԕύX������
        /// </summary>
        /// <br>Update Note: 2012/10/29 yangyi</br>
        /// <br>             redmine#32868  �I���\ �I������/�\�������Ⴄ</br>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/06�z�M���ً̋}�Ή�</br>
        /// <br>           : Redmine#34175 �@�I���Ɩ��̃T�[�o�[���׌y���΍�</br>
        private void ChangeViewStyle()
        {
            // �����������I������܂ő҂�
            if (this._isFirstsetting)
            {
                return;
            }
            // �\�����@�E�\�[�g�����I������Ă��Ȃ��ꍇ�͏����I��
            if ((this.tce_ViewStyle.SelectedIndex == -1) || (this.tce_SortOrder.SelectedIndex == -1))
            {
                this._inventInputAcs.InventDataTable.CaseSensitive = true;                                      //ADD 2009/05/14 �s��Ή�[13260]

                this._isFirstsetting = true;
                this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable);
                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);
                // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------------->>>>>
                //No�����߂�
                int idx = 1;
                foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
                {
                    gridRow.Cells[InventInputResult.ct_Col_No].Value = idx.ToString();
                    gridRow.Update();
                    idx++;
                }
                // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------------------<<<<<

                this._strNowSort = "";
                return;
            }

            string sortOrder = "";	// �\�[�g��
            string viewStyle = "";	// �\�����@

            try
            {
                // �\�����@����
                viewStyle = ct_Filter_Goods;	// ���i��
                // �\�[�g������
                switch ((int)this.tce_SortOrder.SelectedItem.DataValue)
                {
                    case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:	    // �q�Ɂ��I��
                        sortOrder = ct_SortOrder_ShelfNo;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Customer:		// �q�Ɂ��d����
                        sortOrder = ct_SortOrder_Supplier;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// �q�Ɂ��a�k�R�[�h
                        sortOrder = ct_SortOrder_BLGoods;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.BLGroup:    	// �q�Ɂ��O���[�v�R�[�h
                        sortOrder = ct_SortOrder_BLGroup;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // �q�Ɂ����[�J�[
                        sortOrder = ct_SortOrder_Maker;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // �q�Ɂ��d���恨�I��
                        sortOrder = ct_SortOrder_Sup_ShelfNo;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // �q�Ɂ��d���恨���[�J�[
                        sortOrder = ct_SortOrder_Sup_Maker;
                        break;
                    default:														// �q�Ɂ��I��
                        sortOrder = ct_SortOrder_ShelfNo;
                        break;
                }

                this._inventInputAcs.InventDataTable.CaseSensitive = true;          //ADD 2009/05/14 �s��Ή�[13260]
                // �\�����@�E�\�[�g�����Ďw�肵�ăO���b�h�`��
                //this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable, viewStyle, sortOrder, DataViewRowState.CurrentRows); //DEL 2012/10/29 yangyi redmine #32868 
                // ----- ADD 2012/10/29 yangyi redmine #32868 ---------->>>>>
                int printSortIdv = (int)this.tce_SortOrder.SelectedItem.DataValue;

                if (printSortIdv == 0 || printSortIdv == 5)
                {
                    this.uGrid_InventInput.BeginUpdate();
                    List<DataRow> al = new List<DataRow>();
                    foreach (DataRow dr in this._inventInputAcs.InventDataTable.Rows)
                    {
                        al.Add(dr);
                    }
                    Array arr = al.ToArray();
                    MyStringComparer myComp = new MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.Ordinal, printSortIdv);
                    Array.Sort(arr, myComp);

                    DataTable tab = this._inventInputAcs.InventDataTable.Clone();
                    tab.BeginLoadData();   //ADD yangyi 2013/03/01 Redmine#34175 
                    foreach (DataRow dataRo in arr)
                    {
                        tab.ImportRow(dataRo);
                    }
                    tab.EndLoadData();   //ADD yangyi 2013/03/01 Redmine#34175

                    this._inventInputAcs.InventDataTable = tab;

                    //this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable, viewStyle, "", DataViewRowState.CurrentRows);  //DEL yangyi 2013/03/01 Redmine#34175
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    DataView dataView = new DataView(this._inventInputAcs.InventDataTable, viewStyle, "", DataViewRowState.CurrentRows);
                    int idx = 1;
                    this._inventInputAcs.InventDataTable.BeginLoadData();
                    foreach (DataRowView rowView in dataView)
                    {
                        rowView.Row[InventInputResult.ct_Col_No] = idx;
                        idx++;
                    }
                    this._inventInputAcs.InventDataTable.EndLoadData();
                    this.uGrid_InventInput.DataSource = dataView;
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                    // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    // Row�̃J�������������g�ɐݒ�
                    //foreach (DataRow copyRow in _inventInputAcs.InventDataTable.Rows)
                    //{
                    //    copyRow[InventInputResult.ct_Col_RowSelf] = copyRow;
                    //}
                    // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                    //�s�폜�̑Ή�
                    for (int index = 0; index < this.uGrid_InventInput.Rows.Count; index++)
                    {
                        int deleteDiv = (Int32)uGrid_InventInput.Rows[index].Cells[InventInputResult.ct_Col_DeleteDiv].Value;

                        if (deleteDiv == 1)
                        {
                            this.uGrid_InventInput.Rows[index].Appearance.BackColor = Color.Pink;
                        }
                    }
                    this.uGrid_InventInput.EndUpdate();

                }
                else
                {
                    DataView dataView = new DataView(this._inventInputAcs.InventDataTable, viewStyle, sortOrder, DataViewRowState.CurrentRows);
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    int idx = 1;
                    foreach (DataRowView rowView in dataView)
                    {
                        rowView[InventInputResult.ct_Col_No] = idx;
                        idx++;
                    }
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                    this.uGrid_InventInput.DataSource = dataView;
                }
                // ----- ADD 2012/10/29  yangyi redmine #32868 ----------<<<<<

                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);

                // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                // ---ADD 2009/05/14 �s��Ή�[13260] --------------------------------------------->>>>>
                //No�����߂�
                //int idx = 1;
                //foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
                //{
                //    gridRow.Cells[InventInputResult.ct_Col_No].Value = idx;
                //    gridRow.Update();
                //    idx++;
                //}
                //((DataView)this.uGrid_InventInput.DataSource).Sort = InventInputResult.ct_Col_No;
                // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------------<<<<<
                // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                this._strNowSort = sortOrder;

                // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                if (_addingKey)
                {
                    SetTableKey(this._inventInputAcs.InventDataTable);
                    SetTableKey(this._inventInputAcs.InventDataTable_Buf);
                    _addingKey = false;
                }
                // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
            }
            catch (Exception ex)
            {
                this.MsgDispProc("�I���f�[�^�ݒ莞�ɃG���[���������܂����B", -1, "ChangeViewStyle", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        /// <summary>
        /// �f�[�^�e�[�u���̗���쐬����
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="type">�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <returns></returns>
        private void SetTableKey(DataTable dt)
        {
            DataColumn[] primaryKeys = new DataColumn[10];

            // ���_�R�[�h
            primaryKeys[0] = dt.Columns[InventInputResult.ct_Col_SectionCode];
            primaryKeys[0].DefaultValue = "";

            // �q�ɃR�[�h
            primaryKeys[1] = dt.Columns[InventInputResult.ct_Col_WarehouseCode];
            primaryKeys[1].DefaultValue = "";
            // ���[�J�[�R�[�h
            primaryKeys[2] = dt.Columns[InventInputResult.ct_Col_MakerCode];
            primaryKeys[2].DefaultValue = 0;
            // �i��
            primaryKeys[3] = dt.Columns[InventInputResult.ct_Col_GoodsNo];
            primaryKeys[3].DefaultValue = "";
            // ���Ӑ�R�[�h
            primaryKeys[4] = dt.Columns[InventInputResult.ct_Col_SupplierCode];
            primaryKeys[4].DefaultValue = 0;
            // �o�א擾�Ӑ�R�[�h
            primaryKeys[5] = dt.Columns[InventInputResult.ct_Col_ShipCustomerCode];
            primaryKeys[5].DefaultValue = 0;
            // ���P��
            primaryKeys[6] = dt.Columns[InventInputResult.ct_Col_StockUnitPrice];
            primaryKeys[6].DefaultValue = 0;
            // �݌ɋ敪
            primaryKeys[7] = dt.Columns[InventInputResult.ct_Col_StockDiv];
            primaryKeys[7].DefaultValue = 0;
            // �W�v�敪
            primaryKeys[8] = dt.Columns[InventInputResult.ct_Col_GrossDiv];
            primaryKeys[8].DefaultValue = 0;
            // �I��
            primaryKeys[9] = dt.Columns[InventInputResult.ct_Col_WarehouseShelfNo];
            primaryKeys[9].DefaultValue = "";

            //DataTable��Key��ǉ�
            dt.PrimaryKey = primaryKeys;
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        // ----- ADD 2012/10/29 yangyi redmine #32868  ---------->>>>>
        /// <summary>
        /// �I�������\����p�N���X
        /// </summary>
        private class MyStringComparer : IComparer
        {
            private CompareInfo myComp;
            private CompareOptions myOptions = CompareOptions.None;
            private int sortDiv = -1;
            public MyStringComparer(CompareInfo cmpi, CompareOptions options, int sortDiv)
            {
                myComp = cmpi;
                this.myOptions = options;
                this.sortDiv = sortDiv;
            }
            public int Compare(Object a, Object b)
            {
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;
                string stringA = "";
                string stringB = "";
                if (sortDiv == 0)// �I�ԏ�
                {
                    //�q��
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //�I��
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //�i��
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_GoodsNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_GoodsNo].ToString();
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //���[�J�[
                    int intC = (Int32)((DataRow)a)[InventInputResult.ct_Col_MakerCode];
                    int intD = (Int32)((DataRow)b)[InventInputResult.ct_Col_MakerCode];
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                else if (sortDiv == 5)// �d����E�I�ԏ�
                {
                    //�q��
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //�d����
                    int intA = (Int32)((DataRow)a)[InventInputResult.ct_Col_SupplierCode];
                    int intB = (Int32)((DataRow)b)[InventInputResult.ct_Col_SupplierCode];
                    int comePareSupplierCd = intA.CompareTo(intB);
                    if (comePareSupplierCd != 0)
                    {
                        return comePareSupplierCd;
                    }
                    //�I��
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //�i��
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_GoodsNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_GoodsNo].ToString();
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //���[�J�[
                    int intC = (Int32)((DataRow)a)[InventInputResult.ct_Col_MakerCode];
                    int intD = (Int32)((DataRow)b)[InventInputResult.ct_Col_MakerCode];
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                return 0;
            }
            // ----- ADD 2012/10/29 yangyi redmine #32868 ----------<<<<<
        }

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Grid�\����ԕύX������
        /// </summary>
        private void ChangeViewStyle()
        {
            // �����������I������܂ő҂�
            if (this._isFirstsetting)
            {
                return;
            }
            // �\�����@�E�\�[�g�����I������Ă��Ȃ��ꍇ�͏����I��
            if ((this.tce_ViewStyle.SelectedIndex == -1) || (this.tce_SortOrder.SelectedIndex == -1))
            {
                this._isFirstsetting = true;
                this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable);
                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);
                this._strNowSort = "";
                return;
            }
            string sortOrder = "";	// �\�[�g��
            string viewStyle = "";	// �\�����@

            try
            {
                // �\�����@����
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //switch ((int)this.tce_ViewStyle.SelectedItem.DataValue)
                //{
                //	case (int)InventInputSearchCndtn.ViewStyleState.Goods:
                //		viewStyle = ct_Filter_Goods;	// ���i��
                //		break;
                //	default:
                //		viewStyle = ct_Filter_Product;	// ���Ԗ�
                //		break;
                //}
                viewStyle = ct_Filter_Goods;	// ���i��
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                // �\�[�g������
                switch ((int)this.tce_SortOrder.SelectedItem.DataValue)
                {
                    // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //case (int)InventInputSearchCndtn.SortOrderState.CarrierEP:		// �q��-���Ǝ�-���i-����
                    //	sortOrder = ct_SortOrder_CarrierEp;
                    //	break;
                    //case (int)InventInputSearchCndtn.SortOrderState.Customer:		// �q��-�d����-���i-����
                    //	sortOrder = ct_SortOrder_Customer;
                    //	break;
                    //case (int)InventInputSearchCndtn.SortOrderState.ShipCustomer:	// �q��-�ϑ���-���i-����
                    //	sortOrder = ct_SortOrder_ShipCustomer;
                    //	break;
                    ////case (int)InventInputSearchCndtn.SortOrderState.SeqNo:			// �ʔ�
                    ////    sortOrder = ct_SortOrder_SeqNo;
                    ////	break;
                    //default:														// �q��-���i-����
                    //    sortOrder = ct_SortOrder_Goods;// + " , " + InventInputResult.ct_Col_ProductNumber;
                    //    break;
                    // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                    //case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:		// �q�Ɂ��I��
                    //    sortOrder = ct_SortOrder_ShelfNo;
                    //    break;
                    case (int)InventInputSearchCndtn.SortOrderState.SNo_GoodsDiv:	// �q�Ɂ��I�ԁ����[�J�[�����i�敪�����i
                        sortOrder = ct_SortOrder_GoodsDiv;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.SNo_Goods:		// �q�Ɂ��I�ԁ����[�J�[�����i
                        sortOrder = ct_SortOrder_Goods;
                        break;
                    // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                    case (int)InventInputSearchCndtn.SortOrderState.Customer:		// �q�Ɂ��d����
                        sortOrder = ct_SortOrder_Customer;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// �q�Ɂ��a�k�R�[�h
                        sortOrder = ct_SortOrder_BLGoods;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // �q�Ɂ����[�J�[
                        sortOrder = ct_SortOrder_Maker;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // �q�Ɂ��d���恨�I��
                        sortOrder = ct_SortOrder_Cus_ShelfNo;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // �q�Ɂ��d���恨���[�J�[
                        sortOrder = ct_SortOrder_Cus_Maker;
                        break;
                    default:														// �q�Ɂ��I��
                        sortOrder = ct_SortOrder_ShelfNo;
                        break;
                    // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                }
                // Todo:
                //this.uGrid_InventInput.UpdateData();	// �O���b�h�̕ύX���R�~�b�g	// 2007.07.19 kubo del
                // �\�����@�E�\�[�g�����Ďw�肵�ăO���b�h�`��
                this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable, viewStyle, sortOrder, DataViewRowState.CurrentRows);

                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);
                this._strNowSort = sortOrder;
            }
            catch (Exception ex)
            {
                this.MsgDispProc("�I���f�[�^�ݒ莞�ɃG���[���������܂����B", -1, "ChangeViewStyle", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                //this.uGrid_InventInput.Refresh();
            }

        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �� �J�����񕝒���
        /// <summary>
        /// �J�����񕝒���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �J�����̗񕝂𒲐����܂��B</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.24</br>
        /// </remarks>
        private void ColumnPerformAutoResize()
        {
            this._isEventAutoFillColumn = false;

            try
            {
                bool isAutoCol = this.uce_ColSizeAutoSetting.Checked;

                this.uce_ColSizeAutoSetting.Checked = false;

                for (int i = 0; i < this.uGrid_InventInput.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                }

                // �I�����{��(�N ����)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 50;
                // �I�����{��(�N ���x��)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_YearL].Width = 20;
                // �I�����{��(�� ����)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 30;
                // �I�����{��(�� ���x��)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Width = 20;
                // �I�����{��(�� ����)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 30;
                // �I�����{��(�� ���x��)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_DayL].Width = 20;


                this.uce_ColSizeAutoSetting.Checked = isAutoCol;
            }
            finally
            {
                this._isEventAutoFillColumn = true;
            }
        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� ��ݒ�̍X�V
        /// <summary>
        /// ��ݒ�̍X�V
        /// </summary>
        private void UpdGridColumnSetting(string columKey, bool hidden, int width)
        {
            // �o���h���擾
            UltraGridBand band = this.uGrid_InventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput];

            if (band.Columns.Exists(columKey) == true)
            {
                // ��̕\���^��\��
                band.Columns[columKey].Hidden = hidden;

                // �O���[�v�̗񂪑S�Ĕ�\���Ȃ�O���[�v���\���ɂ���
                UltraGridGroup ugg = band.Columns[columKey].Group;
                if (ugg != null)
                {
                    bool uggHidden = true;
                    foreach (UltraGridColumn col in ugg.Columns)
                    {
                        if (col.Hidden == false)
                        {
                            uggHidden = false;
                            break;
                        }
                    }
                    ugg.Hidden = uggHidden;
                }

                // �� 0�ȉ��̎w��͖���
                if (width > 0)
                {
                    band.Columns[columKey].Width = width;
                }
            }
        }
        #endregion

        #region �� ���͏��������C��
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���͏��������C��(ESC�L�[�������ꂽ�Ƃ��̏���)
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="bfInventStcCnt"></param>
        private void InventInitializeForESC(DataRow targetRow, double bfInventStcCnt)
        {
            // �ύX�敪���Z�b�g
            targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

            // �\�����@�𔻒f
            if ((int)this.tce_ViewStyle.SelectedItem.DataValue == (int)InventInputSearchCndtn.ViewStyleState.Goods)
            {
                InventInitializeParentToChild(targetRow, (int)InventInputSearchCndtn.ViewState.Both);
            }
            else
            {
                DataRow parentDr = this._inventInputAcs.InventDataTable.Rows.Find(
                    this._inventInputAcs.GetPrimaryKeyList(targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty));

                if (parentDr == null) return;

                // �I����
                if (parentDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
                {
                    parentDr[InventInputResult.ct_Col_InventoryStockCnt] =
                        (double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - bfInventStcCnt;
                    // ���ِ�
                    parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] =
                        (double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentDr[InventInputResult.ct_Col_StockTotal];
                }

                // �q�s���擾���āA�����ꂩ�̍s�ɒI���������͂���Ă��邩���`�F�b�N
                DataView childView =
                    new DataView(
                            this._inventInputAcs.InventDataTable,
                            MakeParentOrChildRowGetQuery(
                            MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, parentDr),
                            (int)InventInputSearchCndtn.ViewState.View),
                            string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv),
                            DataViewRowState.CurrentRows);

                bool isNoInput = true; // true:�S�q�s������
                for (int index = 0; index < childView.Count; index++)
                {
                    // �I�����A���ِ��A�I�������N���A
                    childView[index][InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;

                    // �I�����A�I�����̂ǂꂩ��DBNull�Ȃ瑱�s
                    if ((childView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value) ||
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Year] == DBNull.Value) ||
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Month] == DBNull.Value) ||
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Day] == DBNull.Value))
                    {
                        continue;
                    }

                    if ((childView[index][InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value) &&
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Year] != DBNull.Value) &&
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Month] != DBNull.Value) &&
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Day] != DBNull.Value))
                    {
                        isNoInput = false;
                        break;
                    }

                    if (((double)childView[index][InventInputResult.ct_Col_InventoryStockCnt] != 0) &&
                        ((int)childView[index][InventInputResult.ct_Col_InventoryDay_Year] != 0) &&
                        ((int)childView[index][InventInputResult.ct_Col_InventoryDay_Month] != 0) &&
                        ((int)childView[index][InventInputResult.ct_Col_InventoryDay_Day] != 0))
                    {
                        isNoInput = false;
                        break;
                    }
                }

                if (isNoInput)
                {
                    // �I�����A���ِ��A�I�������N���A
                    parentDr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
                }

                // �ύX�敪���Z�b�g
                //parentDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;        //DEL 2009/05/14 �s��Ή�[13260]�@ESC�������̈ꊇ�X�V���ł��Ȃ��Ȃ��
                parentDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.NotChange;       //ADD 2009/05/14 �s��Ή�[13260]
            }

            this.uGrid_InventInput.Refresh();			// 2007.07.19 kubo del
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���͏��������C��(ESC�L�[�������ꂽ�Ƃ��̏���)
		/// </summary>
		/// <param name="targetRow"></param>
		/// <param name="bfInventStcCnt"></param>
		private void InventInitializeForESC( DataRow targetRow, double bfInventStcCnt )
		{
			// �ύX�敪���Z�b�g
			targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

			// �\�����@�𔻒f
			if ( (int)this.tce_ViewStyle.SelectedItem.DataValue == (int)InventInputSearchCndtn.ViewStyleState.Goods )
			{
				InventInitializeParentToChild( targetRow, (int)InventInputSearchCndtn.ViewState.Both );
			}
			else
			{
				// ���Ԗ�
				#region // 2007.07.24 kubo del
				//// ���œ��͂���Ă��邩
				//// ���Ԗ����́H
				//if ( targetRow[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
				//{
				//    InventInitializeParentToChild( targetRow, (int)InventInputSearchCndtn.ViewState.NotView );
				//}
				#endregion
				// �e�s�ɔ��f
				#region // 2007.07.19 kubo del
				//DataView parentView = 		
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods , targetRow ), 
				//            (int)InventInputSearchCndtn.ViewState.View),
				//        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//        DataViewRowState.CurrentRows);
				//if ( parentView == null )
				//{
				//    return;
				//}

				//if ( parentView.Count <= 0 )
				//{
				//    return;
				//}
				//// �I����
				//if ( parentView[0][InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
				//{
				//    parentView[0][InventInputResult.ct_Col_InventoryStockCnt] = 
				//        (double)parentView[0][InventInputResult.ct_Col_InventoryStockCnt] - bfInventStcCnt;
				//    // ���ِ�
				//    parentView[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
				//        (double)parentView[0][InventInputResult.ct_Col_InventoryStockCnt] - (double)parentView[0][InventInputResult.ct_Col_StockTotal];
				//}

				//// �q�s���擾���āA�����ꂩ�̍s�ɒI���������͂���Ă��邩���`�F�b�N
				//DataView childView = 
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , parentView[0].Row ), 
				//            (int)InventInputSearchCndtn.ViewState.View),
				//        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//        DataViewRowState.CurrentRows);
				#endregion

				// 2007.07.19 kubo add ------------------->
				DataRow parentDr = this._inventInputAcs.InventDataTable.Rows.Find( 
					this._inventInputAcs.GetPrimaryKeyList(targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));

				if ( parentDr == null )
					return ;


				// �I����
				if ( parentDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
				{
					parentDr[InventInputResult.ct_Col_InventoryStockCnt] = 
						(double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - bfInventStcCnt;
					// ���ِ�
					parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] = 
						(double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentDr[InventInputResult.ct_Col_StockTotal];
				}

				// �q�s���擾���āA�����ꂩ�̍s�ɒI���������͂���Ă��邩���`�F�b�N
				DataView childView =
                    new DataView( 
						    this._inventInputAcs.InventDataTable, 
						    MakeParentOrChildRowGetQuery( 
							MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , parentDr ), 
							(int)InventInputSearchCndtn.ViewState.View),
                            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                            //string.Format("{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber),
                            string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv),
                            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            DataViewRowState.CurrentRows);
                // 2007.07.19 kubo add <-------------------

				bool isNoInput = true; // true:�S�q�s������
				for ( int index = 0; index < childView.Count; index++ )
				{
					// �I�����A�I�����̂ǂꂩ��DBNull�Ȃ瑱�s
					if ( ( childView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value ) ||
						( childView[index][InventInputResult.ct_Col_InventoryDay_Year] == DBNull.Value ) ||
						( childView[index][InventInputResult.ct_Col_InventoryDay_Month] == DBNull.Value ) ||
						( childView[index][InventInputResult.ct_Col_InventoryDay_Day] == DBNull.Value ) )
					{
						continue;
					}

					if ( ( childView[index][InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value ) &&
						( childView[index][InventInputResult.ct_Col_InventoryDay_Year] != DBNull.Value ) &&
						( childView[index][InventInputResult.ct_Col_InventoryDay_Month] != DBNull.Value ) &&
						( childView[index][InventInputResult.ct_Col_InventoryDay_Day] != DBNull.Value ) )
					{
						isNoInput = false;
						break;
					}

					if ( ( (double)childView[index][InventInputResult.ct_Col_InventoryStockCnt] != 0 ) &&
						( (int)childView[index][InventInputResult.ct_Col_InventoryDay_Year] != 0 ) &&
						( (int)childView[index][InventInputResult.ct_Col_InventoryDay_Month] != 0 ) &&
						( (int)childView[index][InventInputResult.ct_Col_InventoryDay_Day] != 0 ) )
					{
						isNoInput = false;
						break;
					}
				}

				// �S�Ė�����
				#region // 2007.07.19 kubo del
				//if ( isNoInput )
				//{
				//    // �I�����A���ِ��A�I�������N���A
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
				//}
				//// �ύX�敪���Z�b�g
				//parentView[0][InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				#endregion

				// 2007.07.19 kubo add ------------------->
				if ( isNoInput )
				{
					// �I�����A���ِ��A�I�������N���A
					parentDr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
				}

				// �ύX�敪���Z�b�g
				parentDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				// 2007.07.19 kubo add <-------------------
			}

			//this.uGrid_InventInput.UpdateData();		// 2007.07.19 kubo del
			this.uGrid_InventInput.Refresh();			// 2007.07.19 kubo del
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� ����������(�e���q�s)
        /// <summary>
        /// ����������(�e���q�s)
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="viewState"></param>
        private void InventInitializeParentToChild(DataRow targetRow, int viewState)
        {
            // �ύX�敪���Z�b�g
            targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

            // ���i��
            // �q�s�ɔ��f
            // �q�s���擾
            #region // 2007.07.19 kubo del
            //DataView childDv = 
            //    new DataView( 
            //        this._inventInputAcs.InventDataTable, 
            //        MakeParentOrChildRowGetQuery( 
            //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetRow ), 
            //            viewState),
            //        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
            //        DataViewRowState.CurrentRows);
            //for( int index = 0; index < childDv.Count; index++ )
            //{
            //    // �q�s�ɒl�𔽉f(�I�����A���ِ��A���t������)
            //    // �I����
            //    childDv[index][InventInputResult.ct_Col_InventoryStockCnt] = 0;
            //    // ���ِ�
            //    childDv[index][InventInputResult.ct_Col_InventoryTolerancCnt] = 0;
            //    // �I����
            //    childDv[index][InventInputResult.ct_Col_InventoryDay] = 0;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Datetime] = DateTime.MinValue;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Month] = 0;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
            //    // �ύX�敪���Z�b�g
            //    childDv[index][InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            //}		
            #endregion

            // 2007.07.19 kubo add ------------->
            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetRow),
                        viewState);
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._inventInputView.Sort = string.Format("{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber);
            this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
            // 2007.07.19 kubo add ------------->

            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                // �q�s�ɒl�𔽉f(�I�����A���ِ��A���t������)
                // �I����
                this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt] = 0;
                // ���ِ�
                this._inventInputView[index][InventInputResult.ct_Col_InventoryTolerancCnt] = 0;
                // �I����
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay] = 0;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Datetime] = DateTime.MinValue;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Month] = 0;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
                // �ύX�敪���Z�b�g
                this._inventInputView[index][InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            }
        }
        #endregion

		#region �� �s�폜����
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �s�폜����
        /// </summary>
        /// <param name="targetRow">�폜�s</param>
        /// <param name="activeRowIndex">�sIndex</param>
        /// <param name="mode">���샂�[�h</param>
        /// <remarks>
        /// <br>Note       : �s�폜����</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int RowDeleteProc(DataRow targetRow, int activeRowIndex, int mode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                this.uGrid_InventInput.BeginUpdate();

                bool isTargetAfterSave = false;	// �ۑ��ς݋敪�@true:�ۑ��ς�, false:���ۑ�

                // �o�^�ς݃f�[�^�����o�^�f�[�^�̔��f
                if ((DateTime)targetRow[InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                    isTargetAfterSave = false;
                else
                    isTargetAfterSave = true;

                string rowFilter = "";

                // ActiveRow�폜
                this.uGrid_InventInput.ActiveRow = null;

                // ���i�敪�𔻒f
                if ((int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods)
                {
                    DataRow[] childRows = null;
                    // ���i���̂Ƃ�
                    // �q�s���擾
                    rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                        InventInputResult.ct_Col_SectionCode, targetRow[InventInputResult.ct_Col_SectionCode],			// ���_�R�[�h
                        InventInputResult.ct_Col_WarehouseCode, targetRow[InventInputResult.ct_Col_WarehouseCode],		// �q�ɃR�[�h
                        InventInputResult.ct_Col_MakerCode, targetRow[InventInputResult.ct_Col_MakerCode],			// ���[�J�[�R�[�h
                        InventInputResult.ct_Col_GoodsNo, targetRow[InventInputResult.ct_Col_GoodsNo],			    // �i��
                        InventInputResult.ct_Col_SupplierCode, targetRow[InventInputResult.ct_Col_SupplierCode],			// �d����R�[�h
                        InventInputResult.ct_Col_ShipCustomerCode, targetRow[InventInputResult.ct_Col_ShipCustomerCode],		// �ϑ���R�[�h
                        InventInputResult.ct_Col_StockDiv, targetRow[InventInputResult.ct_Col_StockDiv],				// �݌ɋ敪
                        InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Product,		// �O���X�敪(���ԍ݌ɂ���)
                        InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0				// �_���폜�敪
                    );

                    childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);

                    if (childRows != null && childRows.Length > 0)
                    {
                        bool isChildAfterSave = false;
                        // �o�^�ς݃f�[�^�����o�^�f�[�^�̔��f
                        if ((DateTime)childRows[0][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                            isChildAfterSave = false;
                        else
                            isChildAfterSave = true;

                        // �q�s���폜
                        foreach (DataRow childRow in childRows)
                        {
                            if ((isChildAfterSave) && (mode == 0))
                            {
                                // �o�^�ς݃f�[�^�͍폜�t���O�𗧂Ă�
                                childRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                                childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                                childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
                                childRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
                            }
                            else
                            {
                                this._inventInputAcs.InventDataTable.Rows.Remove(childRow);
                            }
                        }
                    }
                }
                else
                {
                    // ���Ԗ��̂Ƃ�
                    // �e�s�擾
                    DataRow parentRow = this._inventInputAcs.InventDataTable.Rows.Find(this._inventInputAcs.GetPrimaryKeyList(targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty));

                    if (parentRow != null)
                    {
                        // ���s�̒I������ύX
                        targetRow[InventInputResult.ct_Col_InventoryStockCnt] = 0;	// �I����
                        targetRow[InventInputResult.ct_Col_InventoryTolerancCnt] =	// ���ِ�
                            (double)targetRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetRow[InventInputResult.ct_Col_StockTotal];

                        // �e�s���玩�s�̒I����������
                        bool isShowProduct = false;
                        AfterInputInventryToleCnt(
                            ref targetRow,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);

                        if ((double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] == 0 &&
                             (int)parentRow[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
                        {
                            if (isTargetAfterSave)
                            {
                                // �o�^�ς݃f�[�^�͍폜�t���O�𗧂Ă�
                                parentRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                                parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                                parentRow[InventInputResult.ct_Col_UpdateDiv] = 0;
                                parentRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
                            }
                            else
                            {
                                // �e���폜
                                this._inventInputAcs.InventDataTable.Rows.Remove(parentRow);
                            }
                        }
                    }
                }

                if (isTargetAfterSave)
                {
                    // �o�^�ς݃f�[�^�͍폜�t���O�𗧂Ă�
                    targetRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                    targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                    targetRow[InventInputResult.ct_Col_UpdateDiv] = 0;
                    targetRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
                }
                else
                {
                    // ���s���폜
                    this._inventInputAcs.InventDataTable.Rows.Remove(targetRow);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                this.MsgDispProc("�I���f�[�^�̍폜�Ɏ��s���܂����B", status, "RowDeleteProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                if (this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex)
                    this.uGrid_InventInput.Rows[activeRowIndex].Activate();

                this.uGrid_InventInput.EndUpdate();
            }
            return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �s�폜����
		/// </summary>
		/// <param name="targetRow">�폜�s</param>
		/// <param name="activeRowIndex">�sIndex</param>
        /// <param name="mode">���샂�[�h</param>
        /// <remarks>
		/// <br>Note       : �s�폜����</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.07.24</br>
		/// </remarks>
        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
		//private int RowDeleteProc( DataRow targetRow, int activeRowIndex )
		private int RowDeleteProc( DataRow targetRow, int activeRowIndex, int mode )
        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				this.uGrid_InventInput.BeginUpdate();

				bool isTargetAfterSave = false;	// �ۑ��ς݋敪�@true:�ۑ��ς�, false:���ۑ�

				// �o�^�ς݃f�[�^�����o�^�f�[�^�̔��f
				if ( (DateTime)targetRow[InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue )
					isTargetAfterSave = false;
				else
					isTargetAfterSave = true;

				string rowFilter = "";

				// ActiveRow�폜
				this.uGrid_InventInput.ActiveRow = null;

				// ���i�敪�𔻒f
				if ( (int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
				{
					DataRow[] childRows = null;
					// ���i���̂Ƃ�
					// �q�s���擾
                    // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19} and {20}={21} and {22}={23}",
                    // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                    //rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19}",
                    rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                    // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_SectionCode        , targetRow[InventInputResult.ct_Col_SectionCode],			// ���_�R�[�h
						InventInputResult.ct_Col_WarehouseCode		, targetRow[InventInputResult.ct_Col_WarehouseCode],		// �q�ɃR�[�h
						InventInputResult.ct_Col_MakerCode			, targetRow[InventInputResult.ct_Col_MakerCode],			// ���[�J�[�R�[�h
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
						//InventInputResult.ct_Col_GoodsCode		, targetRow[InventInputResult.ct_Col_GoodsCode],			// �i��
                        InventInputResult.ct_Col_GoodsNo            , targetRow[InventInputResult.ct_Col_GoodsNo],			    // �i��
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_CarrierEpCode    , targetRow[InventInputResult.ct_Col_CarrierEpCode],		// ���Ǝ҃R�[�h
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_CustomerCode       , targetRow[InventInputResult.ct_Col_CustomerCode],			// ���Ӑ�R�[�h
                        InventInputResult.ct_Col_ShipCustomerCode   , targetRow[InventInputResult.ct_Col_ShipCustomerCode],		// �ϑ���R�[�h
                        // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockUnitPrice     , targetRow[InventInputResult.ct_Col_StockUnitPrice],		// �d���P��
                        // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_StockDiv           , targetRow[InventInputResult.ct_Col_StockDiv],				// �݌ɋ敪
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockState       , targetRow[InventInputResult.ct_Col_StockState],			// �݌ɏ��
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //InventInputResult.ct_Col_InventoryNewDiv	, (int)InventInputSearchCndtn.NewRowState.New,				// �V�K�敪
						InventInputResult.ct_Col_GrossDiv			, (int)InventInputSearchCndtn.GrossDivState.Product,		// �O���X�敪(���ԍ݌ɂ���)
						InventInputResult.ct_Col_LogicalDeleteCode	, (int)ConstantManagement.LogicalMode.GetData0				// �_���폜�敪
					);

					// string sortOrder = string.Format( "{0} Asc, {1} Asc", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_SortProductNumber );

					childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);

					if ( childRows != null && childRows.Length > 0 )
					{
                        bool isChildAfterSave = false;
						// �o�^�ς݃f�[�^�����o�^�f�[�^�̔��f
						if ( (DateTime)childRows[0][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue )
							isChildAfterSave = false;
                        else
                        	isChildAfterSave = true;
                        
                        // �q�s���폜
						foreach( DataRow childRow in childRows )
                        {
                            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                            //if (isChildAfterSave)
                            if ((isChildAfterSave) && (mode == 0))
                            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                            {
								// �o�^�ς݃f�[�^�͍폜�t���O�𗧂Ă�
								childRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
								childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
								childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
								childRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
							}
							else
							{
                        		this._inventInputAcs.InventDataTable.Rows.Remove( childRow );
                        	}
                        }
                    }
				}
				else
				{
					// ���Ԗ��̂Ƃ�
					// �e�s�擾
					DataRow parentRow = this._inventInputAcs.InventDataTable.Rows.Find( this._inventInputAcs.GetPrimaryKeyList( targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty) );

					if ( parentRow != null ) 
					{

						// ���s�̒I������ύX
						targetRow[InventInputResult.ct_Col_InventoryStockCnt] = 0;	// �I����
						targetRow[InventInputResult.ct_Col_InventoryTolerancCnt] =	// ���ِ�
							(double)targetRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetRow[InventInputResult.ct_Col_StockTotal];

						// �e�s���玩�s�̒I����������
						bool isShowProduct = false;
						this.AfterInputInventryToleCnt( 
							ref targetRow,
							(int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );

						if ( (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] == 0 && 
							 (int)parentRow[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
						{
							if ( isTargetAfterSave )
							{
								// �o�^�ς݃f�[�^�͍폜�t���O�𗧂Ă�
								parentRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
								parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
								parentRow[InventInputResult.ct_Col_UpdateDiv] = 0;
								parentRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
							}
							else
							{
								// �e���폜
								this._inventInputAcs.InventDataTable.Rows.Remove( parentRow );
							}
						}
					}
				}

				if ( isTargetAfterSave )
				{
					// �o�^�ς݃f�[�^�͍폜�t���O�𗧂Ă�
					targetRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
					targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
					targetRow[InventInputResult.ct_Col_UpdateDiv] = 0;
					targetRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
				}
				else
				{
					// ���s���폜
					this._inventInputAcs.InventDataTable.Rows.Remove( targetRow );
				}
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "�I���f�[�^�̍폜�Ɏ��s���܂����B", status, "RowDeleteProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
				//if ( this.uGrid_InventInput.Rows.Count > activeRowIndex )
				//    activeRowIndex = this.uGrid_InventInput.Rows.Count - 1;

				if ( this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex )
				    this.uGrid_InventInput.Rows[activeRowIndex].Activate();

				this.uGrid_InventInput.EndUpdate();
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �ҏW�������C��
        /// <summary>
        /// �ҏW�������C��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ҏW�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int DataEditProc()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int activeRowIndex = 0;

            try
            {
                if (this.uGrid_InventInput.ActiveRow != null)
                {
                    activeRowIndex = this.uGrid_InventInput.ActiveRow.Index;
                }

                if (this.uGrid_InventInput.ActiveRow == null)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // �I���s�擾
                // DataRow editRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;   //DEL yangyi 2013/03/01 Redmine#34175
                DataRow editRow = GetBindDataRow(this.uGrid_InventInput.ActiveRow);                                             //ADD yangyi 2013/03/01 Redmine#34175 

                // �C���p�N���X�쐬
                InventoryDataUpdateWork invEditWork = null;
                CreateInventUpdateWorkFromRow(out invEditWork, editRow);

                // �ʃC���X�^���X�̍s���ق����̂ŃR�s�[
                int defGrossDiv = (int)editRow[InventInputResult.ct_Col_GrossDiv];

                if (invEditWork == null)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // ��ʋN��
                if (this._createNewInventForm == null)
                {
                    this._createNewInventForm = new MAZAI05130UD();
                    this._createNewInventForm.EnterpriseCode = this._enterpriseCode;
                    this._createNewInventForm.SectionCode = this._sectionCode;
                }

                this._defProdNumList.Clear();
                DataRow[] childRows = null;
                // ���i���̂Ƃ�
                if ((int)editRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods)
                {
                    // �q�s���擾
                    string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                        InventInputResult.ct_Col_SectionCode, editRow[InventInputResult.ct_Col_SectionCode],		// ���_�R�[�h
                        InventInputResult.ct_Col_WarehouseCode, editRow[InventInputResult.ct_Col_WarehouseCode],		// �q�ɃR�[�h
                        InventInputResult.ct_Col_MakerCode, editRow[InventInputResult.ct_Col_MakerCode],			// ���[�J�[�R�[�h
                        InventInputResult.ct_Col_GoodsNo, editRow[InventInputResult.ct_Col_GoodsNo],			// �i��
                        InventInputResult.ct_Col_SupplierCode, editRow[InventInputResult.ct_Col_SupplierCode],		// �d����R�[�h
                        InventInputResult.ct_Col_ShipCustomerCode, editRow[InventInputResult.ct_Col_ShipCustomerCode],	// �ϑ���R�[�h
                        InventInputResult.ct_Col_StockDiv, editRow[InventInputResult.ct_Col_StockDiv],			// �݌ɋ敪
                        InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Product,	// �O���X�敪(���ԍ݌ɂ���)
                        InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0			// �_���폜�敪
                    );

                    childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);
                }

                DialogResult dlgRes = this._createNewInventForm.ShowEditor(ref invEditWork, (int)MAZAI05130UD.DispModeState.EditNew, defGrossDiv);

                // ��ʂ���̖߂�l�𔻒f
                if (dlgRes == DialogResult.OK)
                {
                    InventResetWorkFromRow(invEditWork, ref childRows[0]);
                    InventResetWorkFromRow(invEditWork, ref editRow);
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc("�I���f�[�^�̕ҏW�Ɏ��s���܂����B", -1, "DataEditProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                this._defProdNumList.Clear();

                if (this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex)
                {
                    this.uGrid_InventInput.Rows[activeRowIndex].Activate();
                }
            }
            return status;
        }

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �ҏW�������C��
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �ҏW�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		private int DataEditProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			int activeRowIndex = 0;
            //bool isNewLine = false;   // 2008.02.14 �폜

			try
			{
				if ( this.uGrid_InventInput.ActiveRow != null )
					activeRowIndex = this.uGrid_InventInput.ActiveRow.Index;

				if ( this.uGrid_InventInput.ActiveRow == null )
					return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				// �I���s�擾
				DataRow editRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;

				// �C���p�N���X�쐬
				InventoryDataUpdateWork invEditWork = null;
				CreateInventUpdateWorkFromRow( out invEditWork, editRow );

				// �ʃC���X�^���X�̍s���ق����̂ŃR�s�[
				int defGrossDiv = (int)editRow[InventInputResult.ct_Col_GrossDiv];
				//DataRow defaultRow = this._inventInputAcs.InventDataTable.NewRow();
				//this._inventInputAcs.DevSearchResultProc( invEditWork, defaultRow, true, (int)InventInputSearchCndtn.ChangeFlagState.Change );


				if ( invEditWork == null )
					return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

				// ��ʋN��
				if ( this._createNewInventForm == null )
				{
					this._createNewInventForm = new MAZAI05130UD();
					this._createNewInventForm.EnterpriseCode = this._enterpriseCode;
					this._createNewInventForm.SectionCode = this._sectionCode;
				}

                this._defProdNumList.Clear();
				DataRow[] childRows = null;
				// ���i���̂Ƃ�
				if ( (int)editRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
				{
					// �q�s���擾
                    // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19} and {20}={21} and {22}={23}",
                    // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                    //string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19}",
                    string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                    // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_SectionCode        , editRow[InventInputResult.ct_Col_SectionCode],		// ���_�R�[�h
						InventInputResult.ct_Col_WarehouseCode		, editRow[InventInputResult.ct_Col_WarehouseCode],		// �q�ɃR�[�h
						InventInputResult.ct_Col_MakerCode			, editRow[InventInputResult.ct_Col_MakerCode],			// ���[�J�[�R�[�h
                        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_GoodsCode        , editRow[InventInputResult.ct_Col_GoodsCode],			// �i��
                        InventInputResult.ct_Col_GoodsNo            , editRow[InventInputResult.ct_Col_GoodsNo],			// �i��
                        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_CarrierEpCode    , editRow[InventInputResult.ct_Col_CarrierEpCode],		// ���Ǝ҃R�[�h
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_CustomerCode       , editRow[InventInputResult.ct_Col_CustomerCode],		// ���Ӑ�R�[�h
						InventInputResult.ct_Col_ShipCustomerCode	, editRow[InventInputResult.ct_Col_ShipCustomerCode],	// �ϑ���R�[�h
                        // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockUnitPrice   , editRow[InventInputResult.ct_Col_StockUnitPrice],		// �d���P��
                        // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_StockDiv           , editRow[InventInputResult.ct_Col_StockDiv],			// �݌ɋ敪
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockState       , editRow[InventInputResult.ct_Col_StockState],			// �݌ɏ��
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        //InventInputResult.ct_Col_InventoryNewDiv	, (int)InventInputSearchCndtn.NewRowState.New,			// �V�K�敪
						InventInputResult.ct_Col_GrossDiv			, (int)InventInputSearchCndtn.GrossDivState.Product,	// �O���X�敪(���ԍ݌ɂ���)
						InventInputResult.ct_Col_LogicalDeleteCode	, (int)ConstantManagement.LogicalMode.GetData0			// �_���폜�敪
                
					);
                
					//string sortOrder = string.Format( "{0} Asc, {1} Asc", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_SortProductNumber );
                    
                    childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);//, sortOrder);
					if ( childRows != null && childRows.Length > 0 )
					{
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        #region 2007.09.11 �폜
                        //string prdNum = "";
                        //string tel1 = "";
                        //string tel2 = "";
                        //
                        //InventoryDataUpdateWork defInv = null;
                        //for( int rowIndex = 0; rowIndex < childRows.Length; rowIndex++ )
                        //{
                        //	defInv = new InventoryDataUpdateWork();
                        //
                        //    if (childRows[rowIndex][InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
                        //		prdNum = childRows[rowIndex][InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
                        //	else
                        //		prdNum = "";
                        //
                        //	if ( childRows[rowIndex][InventInputResult.ct_Col_StockTelNo1] != DBNull.Value )
                        //		tel1 = childRows[rowIndex][InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
                        //	else
                        //		tel1 = "";
                        //
                        //	if ( childRows[rowIndex][InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
                        //		tel2 = childRows[rowIndex][InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
                        //	else
                        //		tel2 = "";
                        //
                        //	//if ( prdNum != "" || tel1 != "" || tel2 != "" )
                        //	//{
                        //		defInv.ProductNumber = prdNum.TrimEnd();
                        //		defInv.StockTelNo1 = tel1.TrimEnd();
                        //		defInv.StockTelNo2 = tel2.TrimEnd();
                        //		this._defProdNumList.Add( defInv );
                        //	//}
                        //}
                        #endregion
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

                        // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                        // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                        //// �o�^�ς݃f�[�^�����o�^�f�[�^�̔��f
                        //if ((DateTime)childRows[0][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                        //    isNewLine = true;
                        //else
                        //    isNewLine = false;
                        // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    }
                }
				
				DialogResult dlgRes = this._createNewInventForm.ShowEditor( ref invEditWork, (int)MAZAI05130UD.DispModeState.EditNew, defGrossDiv );

				//this.uGrid_InventInput.BeginUpdate();
				// ��ʂ���̖߂�l�𔻒f
				if ( dlgRes == DialogResult.OK )
				{
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //// OK�̂Ƃ�
                    //if ( this._defProdNumList.Count > 0 )
                    //{
                    //	if ( invEditWork.ProductNumber.TrimEnd() != "" )
                    //		((InventoryDataUpdateWork)this._defProdNumList[0]).ProductNumber = invEditWork.ProductNumber.TrimEnd();
                    //	if ( invEditWork.StockTelNo1.TrimEnd() != "" )
                    //		((InventoryDataUpdateWork)this._defProdNumList[0]).StockTelNo1 = invEditWork.StockTelNo1.TrimEnd();
                    //	if ( invEditWork.StockTelNo2.TrimEnd() != "" )
                    //		((InventoryDataUpdateWork)this._defProdNumList[0]).StockTelNo2 = invEditWork.StockTelNo2.TrimEnd();
                    //}
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                    //// ���̍s���폜
                    //status = RowDeleteProc(editRow, this.uGrid_InventInput.ActiveRow.Index);
                    //
					////if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
					////    return status;
                    //
					//// �V�����s���쐬
					//NewInventProc( invEditWork , true, false);

                    // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                    //if (isNewLine == true)
                    //{
                    //    // ���̍s���폜
                    //    RowDeleteProc(editRow, this.uGrid_InventInput.ActiveRow.Index, 1);
                    //    // �V�����s���쐬
                    //    NewInventProc( invEditWork , true, false);
                    //}
                    //else
                    //{
                    // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                        //foreach (DataRow childRow in childRows)
                        InventResetWorkFromRow(invEditWork, ref childRows[0]);
                        InventResetWorkFromRow(invEditWork, ref editRow);
                    // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                    //}
                    // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<

                    // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                }
				#region
				//    this._inventInputAcs.DevSearchResultProc( invEditWork, editRow, true, (int)InventInputSearchCndtn.ChangeFlagState.Change );
				//    editRow[InventInputResult.ct_Col_GrossDiv] = defGrossDiv;

				//    bool isShowProduct = false;

				//    this.AfterInputInventryToleCnt( ref editRow, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );
				//    this.AfterInputInventoryDate( ref editRow, this.tde_InventoryDate.GetDateTime() );

				//    if ( defGrossDiv == (int)InventInputSearchCndtn.GrossDivState.Product )
				//    {
						
				//        // PrimaryKey�����̃f�[�^�ƈ������e�f�[�^����I�������폜���Ȃ���΂Ȃ�Ȃ��B
				//        // �e�s����
				//        DataRow parentRow = this._inventInputAcs.InventDataTable.Rows.Find( 
				//            this._inventInputAcs.GetPrimaryKeyList(editRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));

				//        // �e�Ƃ����邩 = �L�[���ς���Ă��邩
				//        if ( parentRow != null )
				//        {
				//            // �L�[���ς���Ă��Ȃ��ꍇ
				//            // �O�񍷈ِ��p�ɍ��ِ����擾
				//            bfchgInvToleCnt = (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt];	

				//            // �I����
				//            // �e�s����I����������
				//            parentRow[InventInputResult.ct_Col_InventoryStockCnt] = 
				//                (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - 
				//                (double)defaultRow[InventInputResult.ct_Col_InventoryStockCnt];// - (double)editRow[InventInputResult.ct_Col_InventoryStockCnt]);

				//            if ( (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] == 0 )
				//            {
				//                RowDeleteProc( parentRow, this.uGrid_InventInput.ActiveRow.Index );
				//            }
				//            else
				//            {
				//                parentRow[InventInputResult.ct_Col_InventoryTolerancCnt] = 
				//                    (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentRow[InventInputResult.ct_Col_StockTotal];
				//                // �O�񍷈ِ�
				//                parentRow[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfchgInvToleCnt;
				//                // �ύX�敪���Z�b�g
				//                parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//                // �e�s�̒I���X�V����ύX
				//                this.AfterInputInventoryDate( ref parentRow, this.tde_InventoryDate.GetDateTime() );
				//            }
				//        }
				//        else
				//        {
				//            // �L�[���ς���Ă���ꍇ
				//            // ���̐e�s�擾
				//            // PrimaryKey�����̃f�[�^�ƈ������e�f�[�^����I�������폜���Ȃ���΂Ȃ�Ȃ��B
				//            // �e�s����
				//            parentRow = this._inventInputAcs.InventDataTable.Rows.Find( 
				//                this._inventInputAcs.GetPrimaryKeyList(defaultRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));
				//            bfchgInvToleCnt = (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt];	// �O�񍷈ِ�

				//            // ���̐e�s�̒I�����A���ِ���ύX
				//            if ( parentRow != null )
				//            {
				//                // �O�񍷈ِ��p�ɍ��ِ����擾
				//                bfchgInvToleCnt = (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt];	

				//                // �I����
				//                // �e�s����I����������
				//                parentRow[InventInputResult.ct_Col_InventoryStockCnt] = 
				//                    (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - 
				//                    ((double)defaultRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)editRow[InventInputResult.ct_Col_InventoryStockCnt]);
				//                parentRow[InventInputResult.ct_Col_InventoryTolerancCnt] = 
				//                    (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentRow[InventInputResult.ct_Col_StockTotal];
				//                // �O�񍷈ِ�
				//                parentRow[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfchgInvToleCnt;
				//                // �ύX�敪���Z�b�g
				//                parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//            }

				//            // �V�����e�s���쐬
				//            this._inventInputAcs.MakeGrossData( editRow, false );
				//        }
				//    }
				//    else
				//    {
				//        // ���s�A�q�s���ۂ��ƍ폜�B�V�K�̍s���쐬����
				//    }
				//}
				#endregion
			}
			catch (Exception ex)
			{
				this.MsgDispProc( "�I���f�[�^�̕ҏW�Ɏ��s���܂����B", -1, "DataEditProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
				this._defProdNumList.Clear();

				if ( this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex )
					this.uGrid_InventInput.Rows[activeRowIndex].Activate();

				//this.uGrid_InventInput.EndUpdate();
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� �I���f�[�^�Đݒ�
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I���f�[�^�Đݒ�
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ҏW��ʂ���̒I���f�[�^�X�V���ăZ�b�g����</br>
        /// <br>Programer  : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.11</br>
        /// </remarks>
        private void InventResetWorkFromRow(InventoryDataUpdateWork invEditWork, ref DataRow editRow)
        {
            #region
            editRow[InventInputResult.ct_Col_InventorySeqNo] = invEditWork.InventorySeqNo;  // �I���ʔ�
            editRow[InventInputResult.ct_Col_WarehouseCode] = invEditWork.WarehouseCode;  // �q�ɃR�[�h
            editRow[InventInputResult.ct_Col_WarehouseName] = invEditWork.WarehouseName;  // �q�ɖ���

            editRow[InventInputResult.ct_Col_MakerCode] = invEditWork.GoodsMakerCd;  // ���[�J�[�R�[�h
            editRow[InventInputResult.ct_Col_MakerName] = invEditWork.MakerName;  // ���[�J�[����
            editRow[InventInputResult.ct_Col_GoodsNo] = invEditWork.GoodsNo;  // �i��
            editRow[InventInputResult.ct_Col_GoodsName] = invEditWork.GoodsName;  // �i��
            editRow[InventInputResult.ct_Col_WarehouseShelfNo] = invEditWork.WarehouseShelfNo;   // �I��
            editRow[InventInputResult.ct_Col_DuplicationShelfNo1] = invEditWork.DuplicationShelfNo1;// �d���I�ԂP
            editRow[InventInputResult.ct_Col_DuplicationShelfNo2] = invEditWork.DuplicationShelfNo2;// �d���I�ԂQ
            editRow[InventInputResult.ct_Col_LargeGoodsGanreCode] = invEditWork.LargeGoodsGanreCode;  // ���i�啪�ރR�[�h
            editRow[InventInputResult.ct_Col_LargeGoodsGanreName] = invEditWork.LargeGoodsGanreName;  // ���i�啪�ޖ���
            editRow[InventInputResult.ct_Col_MediumGoodsGanreCode] = invEditWork.MediumGoodsGanreCode;  // ���i�����ރR�[�h
            editRow[InventInputResult.ct_Col_MediumGoodsGanreName] = invEditWork.MediumGoodsGanreName;  // ���i�����ޖ���
            editRow[InventInputResult.ct_Col_DetailGoodsGanreCode] = invEditWork.DetailGoodsGanreCode;   // �O���[�v�R�[�h
            editRow[InventInputResult.ct_Col_DetailGoodsGanreName] = invEditWork.DetailGoodsGanreName;       // �O���[�v�R�[�h����
            editRow[InventInputResult.ct_Col_EnterpriseGanreCode] = invEditWork.EnterpriseGanreCode;    // ���Е��ރR�[�h
            editRow[InventInputResult.ct_Col_EnterpriseGanreName] = invEditWork.EnterpriseGanreName;    // ���Е��ޖ���
            editRow[InventInputResult.ct_Col_BLGoodsCode] = invEditWork.BLGoodsCode;    // �a�k�i��
            //          editRow[InventInputResult.ct_Col_BLGoodsName] = invEditWork.BLGoodsName        ;    // �a�k�i��
            //editRow[InventInputResult.ct_Col_CustomerCode] = invEditWork.CustomerCode;  // ���Ӑ�R�[�h
            editRow[InventInputResult.ct_Col_CustomerName] = invEditWork.CustomerName;  // ���Ӑ於��
            editRow[InventInputResult.ct_Col_CustomerName2] = invEditWork.CustomerName2;  // ���Ӑ於��2

            editRow[InventInputResult.ct_Col_Jan] = invEditWork.Jan;  // JAN�R�[�h
            editRow[InventInputResult.ct_Col_StockUnitPrice] = invEditWork.StockUnitPriceFl;  // �d���P��
            editRow[InventInputResult.ct_Col_BfStockUnitPrice] = invEditWork.BfStockUnitPriceFl;  // �ύX�O�d���P��
            editRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] = invEditWork.StkUnitPriceChgFlg;  // �d���P���ύX�t���O
            editRow[InventInputResult.ct_Col_StockDiv] = invEditWork.StockDiv;  // �݌ɋ敪
            editRow[InventInputResult.ct_Col_LastStockDate] = invEditWork.LastStockDate;  // �ŏI�d���N����
            editRow[InventInputResult.ct_Col_StockTotal] = invEditWork.StockTotal;  // �݌ɑ���
            editRow[InventInputResult.ct_Col_ShipCustomerCode] = invEditWork.ShipCustomerCode;  // �o�א擾�Ӑ�R�[�h
            editRow[InventInputResult.ct_Col_ShipCustomerName] = invEditWork.ShipCustomerName;  // �o�א擾�Ӑ於��
            editRow[InventInputResult.ct_Col_ShipCustomerName2] = invEditWork.ShipCustomerName2;  // �o�א擾�Ӑ於��2

            editRow[InventInputResult.ct_Col_InventoryStockCnt] = invEditWork.InventoryStockCnt; // �I���݌ɐ�
            editRow[InventInputResult.ct_Col_InventoryTolerancCnt] = invEditWork.InventoryTolerancCnt;  // �I���ߕs����
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            editRow[InventInputResult.ct_Col_InventoryExeDay_Str] = TDateTime.DateTimeToLongDate(invEditWork.InventoryDate).ToString(); // �I����
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            editRow[InventInputResult.ct_Col_InventoryPreprDay] = TDateTime.DateTimeToLongDate(invEditWork.InventoryPreprDay);  // �I�������������t
            editRow[InventInputResult.ct_Col_InventoryPreprTim] = invEditWork.InventoryPreprTim;  // �I��������������
            editRow[InventInputResult.ct_Col_InventoryDay] = TDateTime.DateTimeToLongDate(invEditWork.InventoryDay);  // �I�����{��
            editRow[InventInputResult.ct_Col_LastInventoryUpdate] = invEditWork.LastInventoryUpdate;  // �ŏI�I���X�V��
            editRow[InventInputResult.ct_Col_InventoryNewDiv] = invEditWork.InventoryNewDiv;  // �I���V�K�ǉ��敪
            editRow[InventInputResult.ct_Col_StockMashinePrice] = invEditWork.StockMashinePrice;   // �}�V���݌Ɋz
            editRow[InventInputResult.ct_Col_InventoryStockPrice] = invEditWork.InventoryStockPrice; // �I���݌Ɋz
            editRow[InventInputResult.ct_Col_InventoryTlrncPrice] = invEditWork.InventoryTlrncPrice; // �I���ߕs�����z
            editRow[InventInputResult.ct_Col_Status] = invEditWork.Status;  // �X�e�[�^�X	

            editRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            editRow[InventInputResult.ct_Col_UpdateDiv] = 0;
            #endregion
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I���f�[�^�Đݒ�
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ҏW��ʂ���̒I���f�[�^�X�V���ăZ�b�g����</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void InventResetWorkFromRow(InventoryDataUpdateWork invEditWork, ref DataRow dr)
        {
            // �I���ʔ�
            dr[InventInputResult.ct_Col_InventorySeqNo] = invEditWork.InventorySeqNo;
            // �q�ɃR�[�h                 
            dr[InventInputResult.ct_Col_WarehouseCode] = invEditWork.WarehouseCode;
            // �q�ɖ���                
            if (invEditWork.WarehouseCode.Trim() == "")
            {
                dr[InventInputResult.ct_Col_WarehouseName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_WarehouseName] = this._inventInputAcs.GetWarehouseName(invEditWork.WarehouseCode);
            }
            // ���[�J�[�R�[�h
            dr[InventInputResult.ct_Col_MakerCode] = invEditWork.GoodsMakerCd;
            // ���[�J�[����
            if (invEditWork.GoodsMakerCd == 0)
            {
                dr[InventInputResult.ct_Col_MakerName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_MakerName] = this._inventInputAcs.GetMakerName(invEditWork.GoodsMakerCd);
            }
            // �i��
            dr[InventInputResult.ct_Col_GoodsNo] = invEditWork.GoodsNo;
            // �i��
            if ((invEditWork.GoodsMakerCd == 0) || (invEditWork.GoodsNo.Trim() == ""))
            {
                dr[InventInputResult.ct_Col_GoodsName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_GoodsName] = this._inventInputAcs.GetGoodsName(invEditWork.GoodsMakerCd, invEditWork.GoodsNo);
            }
            // �I��
            dr[InventInputResult.ct_Col_WarehouseShelfNo] = invEditWork.WarehouseShelfNo;
            // �d���I�ԂP           
            dr[InventInputResult.ct_Col_DuplicationShelfNo1] = invEditWork.DuplicationShelfNo1;
            // �d���I�ԂQ
            dr[InventInputResult.ct_Col_DuplicationShelfNo2] = invEditWork.DuplicationShelfNo2;
            // ���i�啪�ރR�[�h
            dr[InventInputResult.ct_Col_LargeGoodsGanreCode] = invEditWork.GoodsLGroup;
            // ���i�����ރR�[�h
            dr[InventInputResult.ct_Col_MediumGoodsGanreCode] = invEditWork.GoodsMGroup;
            // �O���[�v�R�[�h
            dr[InventInputResult.ct_Col_BLGroupCode] = invEditWork.BLGroupCode;
            // �O���[�v�R�[�h����
            if (invEditWork.BLGroupCode == 0)
            {
                dr[InventInputResult.ct_Col_BLGroupName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_BLGroupName] = this._inventInputAcs.GetBLGroupName(invEditWork.BLGroupCode);
            }
            // ���Е��ރR�[�h
            dr[InventInputResult.ct_Col_EnterpriseGanreCode] = invEditWork.EnterpriseGanreCode;
            // �a�k�R�[�h   
            dr[InventInputResult.ct_Col_BLGoodsCode] = invEditWork.BLGoodsCode;
            // �a�k�R�[�h����
            if (invEditWork.BLGoodsCode == 0)
            {
                dr[InventInputResult.ct_Col_BLGoodsName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_BLGoodsName] = this._inventInputAcs.GetBLGoodsName(invEditWork.BLGoodsCode);
            }
            // �d����R�[�h
            dr[InventInputResult.ct_Col_SupplierCode] = invEditWork.SupplierCd;
            // �d���於��
            // �d���於��2
            if (invEditWork.SupplierCd == 0)
            {
                dr[InventInputResult.ct_Col_SupplierName] = "";
                dr[InventInputResult.ct_Col_SupplierName2] = "";
            }
            else
            {
                int status;
                string supplierName1;
                string supplierName2;
                status = this._inventInputAcs.GetSupplierName(invEditWork.SupplierCd, out supplierName1, out supplierName2);
                if (status == 0)
                {
                    dr[InventInputResult.ct_Col_SupplierName] = supplierName1;
                    dr[InventInputResult.ct_Col_SupplierName2] = supplierName2;
                }
                else
                {
                    dr[InventInputResult.ct_Col_SupplierName] = "";
                    dr[InventInputResult.ct_Col_SupplierName2] = "";
                }
            }
            // JAN�R�[�h
            dr[InventInputResult.ct_Col_Jan] = invEditWork.Jan;
            // �d���P��             
            dr[InventInputResult.ct_Col_StockUnitPrice] = invEditWork.StockUnitPriceFl;
            // �ύX�O�d���P��     
            dr[InventInputResult.ct_Col_BfStockUnitPrice] = invEditWork.BfStockUnitPriceFl;
            // �d���P���ύX�t���O
            dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = invEditWork.StkUnitPriceChgFlg;
            // �݌ɋ敪
            dr[InventInputResult.ct_Col_StockDiv] = invEditWork.StockDiv;
            // �ŏI�d���N����
            dr[InventInputResult.ct_Col_LastStockDate] = invEditWork.LastStockDate;
            // �݌ɑ���
            dr[InventInputResult.ct_Col_StockTotal] = invEditWork.StockTotal;
            // �o�א擾�Ӑ�R�[�h
            dr[InventInputResult.ct_Col_ShipCustomerCode] = invEditWork.ShipCustomerCode;
            // �I���݌ɐ�
            dr[InventInputResult.ct_Col_InventoryStockCnt] = invEditWork.InventoryStockCnt;
            // �I���ߕs����
            dr[InventInputResult.ct_Col_InventoryTolerancCnt] = invEditWork.InventoryTolerancCnt;
            // �I����
            dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] = invEditWork.InventoryDate;
            // �I�������������t
            dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] = invEditWork.InventoryPreprDay;
            // �I��������������
            dr[InventInputResult.ct_Col_InventoryPreprTim] = invEditWork.InventoryPreprTim;
            // �I�����{��
            dr[InventInputResult.ct_Col_InventoryDay] = TDateTime.DateTimeToLongDate(invEditWork.InventoryDay);
            // �ŏI�I���X�V��
            dr[InventInputResult.ct_Col_LastInventoryUpdate] = invEditWork.LastInventoryUpdate;
            // �I���V�K�ǉ��敪
            dr[InventInputResult.ct_Col_InventoryNewDiv] = invEditWork.InventoryNewDiv;
            // �}�V���݌Ɋz
            dr[InventInputResult.ct_Col_StockMashinePrice] = invEditWork.StockMashinePrice;
            // �I���݌Ɋz
            dr[InventInputResult.ct_Col_InventoryStockPrice] = invEditWork.InventoryStockPrice;
            // �I���ߕs�����z
            dr[InventInputResult.ct_Col_InventoryTlrncPrice] = invEditWork.InventoryTlrncPrice;
            // �X�e�[�^�X
            dr[InventInputResult.ct_Col_Status] = invEditWork.Status;  	
            dr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            dr[InventInputResult.ct_Col_UpdateDiv] = 0;

            // �����p�v�Z����
            dr[InventInputResult.ct_Col_AdjustCalcCost] = invEditWork.AdjstCalcCost;        //ADD 2009/05/14 �s��Ή�[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region �� �ҏW�p�I���f�[�^�X�V�N���X�쐬
        /// <summary>
        /// �ҏW�p�I���f�[�^�X�V�N���X�쐬
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ҏW��ʂɓn���I���f�[�^�X�V�N���X���쐬����</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int CreateInventUpdateWorkFromRow(out InventoryDataUpdateWork invEditWork, DataRow dr)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            invEditWork = new InventoryDataUpdateWork();

            // �쐬����
            if (dr[InventInputResult.ct_Col_CreateDateTime] == DBNull.Value)
            {
                invEditWork.CreateDateTime = DateTime.MinValue;
            }
            else
            {
                invEditWork.CreateDateTime = (DateTime)dr[InventInputResult.ct_Col_CreateDateTime];
            }
            // �X�V����
            if (dr[InventInputResult.ct_Col_UpdateDateTime] == DBNull.Value)
            {
                invEditWork.UpdateDateTime = DateTime.MinValue;
            }
            else
            {
                invEditWork.UpdateDateTime = (DateTime)dr[InventInputResult.ct_Col_UpdateDateTime];                 
            }
            // ��ƃR�[�h
            if (dr[InventInputResult.ct_Col_EnterpriseCode] == DBNull.Value)
            {
                invEditWork.EnterpriseCode = "";
            }
            else
            {
                invEditWork.EnterpriseCode = (string)dr[InventInputResult.ct_Col_EnterpriseCode];                   
            }
            // GUID
            if (dr[InventInputResult.ct_Col_FileHeaderGuid] == DBNull.Value)
            {
                invEditWork.FileHeaderGuid = Guid.Empty;
            }
            else
            {
                invEditWork.FileHeaderGuid = (Guid)dr[InventInputResult.ct_Col_FileHeaderGuid];                     
            }
            // �X�V�]�ƈ��R�[�h
            if (dr[InventInputResult.ct_Col_UpdEmployeeCode] == DBNull.Value)
            {
                invEditWork.UpdEmployeeCode = "";
            }
            else
            {
                invEditWork.UpdEmployeeCode = (string)dr[InventInputResult.ct_Col_UpdEmployeeCode];                 
            }
            // �X�V�A�Z���u��ID1
            if (dr[InventInputResult.ct_Col_UpdAssemblyId1] == DBNull.Value)
            {
                invEditWork.UpdAssemblyId1 = "";
            }
            else
            {
                invEditWork.UpdAssemblyId1 = (string)dr[InventInputResult.ct_Col_UpdAssemblyId1];                   
            }
            // �X�V�A�Z���u��ID2
            if (dr[InventInputResult.ct_Col_UpdAssemblyId2] == DBNull.Value)
            {
                invEditWork.UpdAssemblyId2 = "";
            }
            else
            {
                invEditWork.UpdAssemblyId2 = (string)dr[InventInputResult.ct_Col_UpdAssemblyId2];                   
            }
            // �_���폜�敪
            if (dr[InventInputResult.ct_Col_LogicalDeleteCode] == DBNull.Value)
            {
                invEditWork.LogicalDeleteCode = 0;
            }
            else
            {
                invEditWork.LogicalDeleteCode = (Int32)dr[InventInputResult.ct_Col_LogicalDeleteCode];              
            }
            // ���_�R�[�h
            if (dr[InventInputResult.ct_Col_SectionCode] == DBNull.Value)
            {
                invEditWork.SectionCode = "";
            }
            else
            {
                invEditWork.SectionCode = (string)dr[InventInputResult.ct_Col_SectionCode];                         
            }
            // �I���ʔ�
            if (dr[InventInputResult.ct_Col_InventorySeqNo] == DBNull.Value)
            {
                invEditWork.InventorySeqNo = 0;
            }
            else
            {
                invEditWork.InventorySeqNo = (Int32)dr[InventInputResult.ct_Col_InventorySeqNo];                    
            }
            // �q�ɃR�[�h
            if (dr[InventInputResult.ct_Col_WarehouseCode] == DBNull.Value)
            {
                invEditWork.WarehouseCode = "";
            }
            else
            {
                invEditWork.WarehouseCode = (string)dr[InventInputResult.ct_Col_WarehouseCode];                     
            }
            // ���[�J�[�R�[�h
            if (dr[InventInputResult.ct_Col_MakerCode] == DBNull.Value)
            {
                invEditWork.GoodsMakerCd = 0;
            }
            else
            {
                invEditWork.GoodsMakerCd = (Int32)dr[InventInputResult.ct_Col_MakerCode];                           
            }
            // �i��
            if (dr[InventInputResult.ct_Col_GoodsNo] == DBNull.Value)
            {
                invEditWork.GoodsNo = "";
            }
            else
            {
                invEditWork.GoodsNo = (string)dr[InventInputResult.ct_Col_GoodsNo];                                 
            }
            // �I��
            if (dr[InventInputResult.ct_Col_WarehouseShelfNo] == DBNull.Value)
            {
                invEditWork.WarehouseShelfNo = "";
            }
            else
            {
                invEditWork.WarehouseShelfNo = (string)dr[InventInputResult.ct_Col_WarehouseShelfNo];               
            }
            // �d���I�ԂP
            if (dr[InventInputResult.ct_Col_DuplicationShelfNo1] == DBNull.Value)
            {
                invEditWork.DuplicationShelfNo1 = "";
            }
            else
            {
                invEditWork.DuplicationShelfNo1 = (string)dr[InventInputResult.ct_Col_DuplicationShelfNo1];         
            }
            // �d���I�ԂQ
            if (dr[InventInputResult.ct_Col_DuplicationShelfNo2] == DBNull.Value)
            {
                invEditWork.DuplicationShelfNo2 = "";
            }
            else
            {
                invEditWork.DuplicationShelfNo2 = (string)dr[InventInputResult.ct_Col_DuplicationShelfNo2];         
            }
            // ���i�啪�ރR�[�h
            if (dr[InventInputResult.ct_Col_LargeGoodsGanreCode] == DBNull.Value)
            {
                invEditWork.GoodsLGroup = 0;
            }
            else
            {
                invEditWork.GoodsLGroup = (Int32)dr[InventInputResult.ct_Col_LargeGoodsGanreCode];                    
            }
            // ���i�����ރR�[�h
            if (dr[InventInputResult.ct_Col_MediumGoodsGanreCode] == DBNull.Value)
            {
                invEditWork.GoodsMGroup = 0;
            }
            else
            {
                invEditWork.GoodsMGroup = (Int32)dr[InventInputResult.ct_Col_MediumGoodsGanreCode];
            }
            // �O���[�v�R�[�h
            if (dr[InventInputResult.ct_Col_BLGroupCode] == DBNull.Value)
            {
                invEditWork.BLGroupCode = 0;
            }
            else
            {
                invEditWork.BLGroupCode = (Int32)dr[InventInputResult.ct_Col_BLGroupCode];
            }
            // ���Е��ރR�[�h
            if (dr[InventInputResult.ct_Col_EnterpriseGanreCode] == DBNull.Value)
            {
                invEditWork.EnterpriseGanreCode = 0;
            }
            else
            {
                invEditWork.EnterpriseGanreCode = (Int32)dr[InventInputResult.ct_Col_EnterpriseGanreCode];
            }
            // �a�k�R�[�h
            if (dr[InventInputResult.ct_Col_BLGoodsCode] == DBNull.Value)
            {
                invEditWork.BLGoodsCode = 0;
            }
            else
            {
                invEditWork.BLGoodsCode = (Int32)dr[InventInputResult.ct_Col_BLGoodsCode];
            }
            // �d����R�[�h
            if (dr[InventInputResult.ct_Col_SupplierCode] == DBNull.Value)
            {
                invEditWork.SupplierCd = 0;
            }
            else
            {
                invEditWork.SupplierCd = (Int32)dr[InventInputResult.ct_Col_SupplierCode];
            }
            // JAN�R�[�h
            if (dr[InventInputResult.ct_Col_Jan] == DBNull.Value)
            {
                invEditWork.Jan = "";
            }
            else
            {
                invEditWork.Jan = (string)dr[InventInputResult.ct_Col_Jan];                                         
            }
            // �d���P��
            if (dr[InventInputResult.ct_Col_StockUnitPrice] == DBNull.Value)
            {
                invEditWork.StockUnitPriceFl = 0;
            }
            else
            {
                invEditWork.StockUnitPriceFl = (Double)dr[InventInputResult.ct_Col_StockUnitPrice];
            }
            // �ύX�O�d���P��
            if (dr[InventInputResult.ct_Col_BfStockUnitPrice] == DBNull.Value)
            {
                invEditWork.BfStockUnitPriceFl = 0;
            }
            else
            {
                invEditWork.BfStockUnitPriceFl = (Double)dr[InventInputResult.ct_Col_BfStockUnitPrice];
            }
            // �d���P���ύX�t���O
            if (dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] == DBNull.Value)
            {
                invEditWork.StkUnitPriceChgFlg = 0;
            }
            else
            {
                invEditWork.StkUnitPriceChgFlg = (Int32)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg];
            }
            // �݌ɋ敪
            if (dr[InventInputResult.ct_Col_StockDiv] == DBNull.Value)
            {
                invEditWork.StockDiv = 0;
            }
            else
            {
                invEditWork.StockDiv = (Int32)dr[InventInputResult.ct_Col_StockDiv];
            }
            // �ŏI�d���N����
            if (dr[InventInputResult.ct_Col_LastStockDate] == DBNull.Value)
            {
                invEditWork.LastStockDate = DateTime.MinValue;
            }
            else
            {
                invEditWork.LastStockDate = (DateTime)dr[InventInputResult.ct_Col_LastStockDate];
            }
            // �݌ɑ���
            if (dr[InventInputResult.ct_Col_StockTotal] == DBNull.Value)
            {
                invEditWork.StockTotal = 0;
            }
            else
            {
                invEditWork.StockTotal = (Double)dr[InventInputResult.ct_Col_StockTotal];
            }
            // �o�א擾�Ӑ�R�[�h
            if (dr[InventInputResult.ct_Col_ShipCustomerCode] == DBNull.Value)
            {
                invEditWork.ShipCustomerCode = 0;
            }
            else
            {
                invEditWork.ShipCustomerCode = (Int32)dr[InventInputResult.ct_Col_ShipCustomerCode];
            }
            // �I���݌ɐ�
            if (dr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
            {
                invEditWork.InventoryStockCnt = (Double)dr[InventInputResult.ct_Col_InventoryStockCnt];      
            }
            else
            {
                invEditWork.InventoryStockCnt = 0;
            }
            // ���ِ�
            if (dr[InventInputResult.ct_Col_InventoryTolerancCnt] == DBNull.Value)
            {
                invEditWork.InventoryTolerancCnt = 0;
            }
            else
            {
                invEditWork.InventoryTolerancCnt = (Double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];
            }
            // �I����
            if (dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] == DBNull.Value)
            {
                invEditWork.InventoryDate = DateTime.MinValue;
            }
            else
            {
                invEditWork.InventoryDate = (DateTime)dr[InventInputResult.ct_Col_InventoryExeDay_Datetime];
            }
            // �I�������������t
            if (dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] == DBNull.Value)
            {
                invEditWork.InventoryPreprDay = DateTime.MinValue;
            }
            else
            {
                invEditWork.InventoryPreprDay = (DateTime)dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime];
            }
            // �I��������������
            if (dr[InventInputResult.ct_Col_InventoryPreprTim] == DBNull.Value)
            {
                invEditWork.InventoryPreprTim = 0;
            }
            else
            {
                invEditWork.InventoryPreprTim = (Int32)dr[InventInputResult.ct_Col_InventoryPreprTim];
            }
            // �I�����{��
            if (dr[InventInputResult.ct_Col_InventoryDay] == DBNull.Value)
            {
                invEditWork.InventoryDay = DateTime.MinValue;
            }
            else
            {
                invEditWork.InventoryDay = TDateTime.LongDateToDateTime((int)dr[InventInputResult.ct_Col_InventoryDay]);
            }
            // �ŏI�I���X�V��
            if (dr[InventInputResult.ct_Col_LastInventoryUpdate] == DBNull.Value)
            {
                invEditWork.LastInventoryUpdate = DateTime.MinValue;
            }
            else
            {
                invEditWork.LastInventoryUpdate = (DateTime)dr[InventInputResult.ct_Col_LastInventoryUpdate];
            }
            // �I���V�K�ǉ��敪
            if (dr[InventInputResult.ct_Col_InventoryNewDiv] == DBNull.Value)
            {
                invEditWork.InventoryNewDiv = 0;
            }
            else
            {
                invEditWork.InventoryNewDiv = (Int32)dr[InventInputResult.ct_Col_InventoryNewDiv];
            }
            // �}�V���݌Ɋz
            if (dr[InventInputResult.ct_Col_StockMashinePrice] == DBNull.Value)
            {
                invEditWork.StockMashinePrice = 0;
            }
            else
            {
                invEditWork.StockMashinePrice = (Int64)dr[InventInputResult.ct_Col_StockMashinePrice];
            }
            // �I���݌Ɋz
            if (dr[InventInputResult.ct_Col_InventoryStockPrice] == DBNull.Value)
            {
                invEditWork.InventoryStockPrice = 0;
            }
            else
            {
                invEditWork.InventoryStockPrice = (Int64)dr[InventInputResult.ct_Col_InventoryStockPrice];
            }
            // �I���ߕs�����z
            if (dr[InventInputResult.ct_Col_InventoryTlrncPrice] == DBNull.Value)
            {
                invEditWork.InventoryTlrncPrice = 0;
            }
            else
            {
                invEditWork.InventoryTlrncPrice = (Int64)dr[InventInputResult.ct_Col_InventoryTlrncPrice];
            }
            // �X�e�[�^�X
            if (dr[InventInputResult.ct_Col_Status] == DBNull.Value)
            {
                invEditWork.Status = 0;
            }
            else
            {
                invEditWork.Status = (Int32)dr[InventInputResult.ct_Col_Status];
            }

            // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------------------------->>>>>
            // �݌ɑ���(���{��)
            if (dr[InventInputResult.ct_Col_StockTotalExec] == DBNull.Value)
            {
                invEditWork.StockTotalExec = 0;
            }
            else
            {
                invEditWork.StockTotalExec = (Double)dr[InventInputResult.ct_Col_StockTotalExec];
            }
            // �ߕs���X�V�敪
            if (dr[InventInputResult.ct_Col_ToleranceUpdateCd] == DBNull.Value)
            {
                invEditWork.ToleranceUpdateCd = 0;
            }
            else
            {
                invEditWork.ToleranceUpdateCd = (Int32)dr[InventInputResult.ct_Col_ToleranceUpdateCd];
            }
            // �����p�v�Z����
            if (dr[InventInputResult.ct_Col_AdjustCalcCost] == DBNull.Value)
            {
                invEditWork.AdjstCalcCost = 0;
            }
            else
            {
                invEditWork.AdjstCalcCost = (Double)dr[InventInputResult.ct_Col_AdjustCalcCost];
            }
            // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------------------<<<<<
            return status;
        }

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �ҏW�p�I���f�[�^�X�V�N���X�쐬
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ҏW��ʂɓn���I���f�[�^�X�V�N���X���쐬����</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks>
        private int CreateInventUpdateWorkFromRow(out InventoryDataUpdateWork invEditWork, DataRow editRow)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            invEditWork = new InventoryDataUpdateWork();

            #region
            invEditWork.CreateDateTime = (DateTime)editRow[InventInputResult.ct_Col_CreateDateTime];  // �쐬����
            invEditWork.UpdateDateTime = (DateTime)editRow[InventInputResult.ct_Col_UpdateDateTime];  // �X�V����
            invEditWork.EnterpriseCode = (string)editRow[InventInputResult.ct_Col_EnterpriseCode];  // ��ƃR�[�h
            invEditWork.FileHeaderGuid = (Guid)editRow[InventInputResult.ct_Col_FileHeaderGuid];  // GUID
            invEditWork.UpdEmployeeCode = (string)editRow[InventInputResult.ct_Col_UpdEmployeeCode];  // �X�V�]�ƈ��R�[�h
            invEditWork.UpdAssemblyId1 = (string)editRow[InventInputResult.ct_Col_UpdAssemblyId1];  // �X�V�A�Z���u��ID1
            invEditWork.UpdAssemblyId2 = (string)editRow[InventInputResult.ct_Col_UpdAssemblyId2];  // �X�V�A�Z���u��ID2
            invEditWork.LogicalDeleteCode = (Int32)editRow[InventInputResult.ct_Col_LogicalDeleteCode];  // �_���폜�敪
            invEditWork.SectionCode = (string)editRow[InventInputResult.ct_Col_SectionCode];  // ���_�R�[�h
            //			invEditWork.SectionGuideNm			= (string)editRow[InventInputResult.ct_Col_SectionGuideNm];  // ���_�K�C�h����
            invEditWork.InventorySeqNo = (Int32)editRow[InventInputResult.ct_Col_InventorySeqNo];  // �I���ʔ�
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.ProductStockGuid        = (Guid)editRow[InventInputResult.ct_Col_ProductStockGuid];  // ���ԍ݌Ƀ}�X�^GUID
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            invEditWork.WarehouseCode = (string)editRow[InventInputResult.ct_Col_WarehouseCode];  // �q�ɃR�[�h
            invEditWork.WarehouseName = (string)editRow[InventInputResult.ct_Col_WarehouseName];  // �q�ɖ���

            invEditWork.GoodsMakerCd = (Int32)editRow[InventInputResult.ct_Col_MakerCode];  // ���[�J�[�R�[�h
            invEditWork.MakerName = (string)editRow[InventInputResult.ct_Col_MakerName];  // ���[�J�[����
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //invEditWork.GoodsCode 				= (string)editRow[InventInputResult.ct_Col_GoodsCode];  // �i��
            invEditWork.GoodsNo = (string)editRow[InventInputResult.ct_Col_GoodsNo];  // �i��
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            invEditWork.GoodsName = (string)editRow[InventInputResult.ct_Col_GoodsName];  // �i��
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //invEditWork.CellphoneModelCode      = (string)editRow[InventInputResult.ct_Col_CellphoneModelCode];  // �@��R�[�h
            //invEditWork.CellphoneModelName		= (string)editRow[InventInputResult.ct_Col_CellphoneModelName];  // �@�햼��
            //invEditWork.CarrierCode 			= (Int32)editRow[InventInputResult.ct_Col_CarrierCode];  // �L�����A�R�[�h
            //invEditWork.CarrierName 			= (string)editRow[InventInputResult.ct_Col_CarrierName];  // �L�����A����
            //invEditWork.SystematicColorCd 		= (Int32)editRow[InventInputResult.ct_Col_SystematicColorCd];  // �n���F�R�[�h
            //invEditWork.SystematicColorNm 		= (string)editRow[InventInputResult.ct_Col_SystematicColorNm];  // �n���F����
            invEditWork.WarehouseShelfNo = (string)editRow[InventInputResult.ct_Col_WarehouseShelfNo];   // �I��
            invEditWork.DuplicationShelfNo1 = (string)editRow[InventInputResult.ct_Col_DuplicationShelfNo1];// �d���I�ԂP
            invEditWork.DuplicationShelfNo2 = (string)editRow[InventInputResult.ct_Col_DuplicationShelfNo2];// �d���I�ԂQ
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            invEditWork.LargeGoodsGanreCode = (string)editRow[InventInputResult.ct_Col_LargeGoodsGanreCode];  // ���i�啪�ރR�[�h
            invEditWork.LargeGoodsGanreName = (string)editRow[InventInputResult.ct_Col_LargeGoodsGanreName];  // ���i�啪�ޖ���
            invEditWork.MediumGoodsGanreCode = (string)editRow[InventInputResult.ct_Col_MediumGoodsGanreCode];  // ���i�����ރR�[�h
            invEditWork.MediumGoodsGanreName = (string)editRow[InventInputResult.ct_Col_MediumGoodsGanreName];  // ���i�����ޖ���
            // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //invEditWork.CarrierEpCode           = (Int32)editRow[InventInputResult.ct_Col_CarrierEpCode];  // ���Ǝ҃R�[�h
            //invEditWork.CarrierEpName			= (string)editRow[InventInputResult.ct_Col_CarrierEpName];  // ���ƎҖ���
            invEditWork.DetailGoodsGanreCode = (string)editRow[InventInputResult.ct_Col_DetailGoodsGanreCode];   // �O���[�v�R�[�h
            invEditWork.DetailGoodsGanreName = (string)editRow[InventInputResult.ct_Col_DetailGoodsGanreName];   // �O���[�v�R�[�h����
            invEditWork.EnterpriseGanreCode = (Int32)editRow[InventInputResult.ct_Col_EnterpriseGanreCode];    // ���Е��ރR�[�h
            invEditWork.EnterpriseGanreName = (string)editRow[InventInputResult.ct_Col_EnterpriseGanreName];    // ���Е��ޖ���
            invEditWork.BLGoodsCode = (Int32)editRow[InventInputResult.ct_Col_BLGoodsCode];    // �a�k�i��
            //invEditWork.BLGoodsName             = (string)editRow[InventInputResult.ct_Col_BLGoodsName];    // �a�k�i��
            // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            invEditWork.CustomerCode = (Int32)editRow[InventInputResult.ct_Col_CustomerCode];  // ���Ӑ�R�[�h
            invEditWork.CustomerName = (string)editRow[InventInputResult.ct_Col_CustomerName];  // ���Ӑ於��
            invEditWork.CustomerName2 = (string)editRow[InventInputResult.ct_Col_CustomerName2];  // ���Ӑ於��2
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.StockDate               = (DateTime)editRow[InventInputResult.ct_Col_StockDate];  // �d����
            //invEditWork.ArrivalGoodsDay			= (DateTime)editRow[InventInputResult.ct_Col_ArrivalGoodsDay];  // ���ד�
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (editRow[InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
            //	invEditWork.ProductNumber			= (string)editRow[InventInputResult.ct_Col_ProductNumber];  // �����ԍ�
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (editRow[InventInputResult.ct_Col_StockTelNo1] != DBNull.Value)
            //	invEditWork.StockTelNo1				= (string)editRow[InventInputResult.ct_Col_StockTelNo1];  // ���i�d�b�ԍ�1
            //
            //if ( editRow[InventInputResult.ct_Col_BfStockTelNo1] != DBNull.Value )
            //	invEditWork.BfStockTelNo1			= (string)editRow[InventInputResult.ct_Col_BfStockTelNo1];  // �ύX�O���i�d�b�ԍ�1
            //
            //invEditWork.StkTelNo1ChgFlg			= (Int32)editRow[InventInputResult.ct_Col_StkTelNo1ChgFlg];  // ���i�d�b�ԍ�1�ύX�t���O
            //
            //if ( editRow[InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
            //	invEditWork.StockTelNo2				= (string)editRow[InventInputResult.ct_Col_StockTelNo2];  // ���i�d�b�ԍ�2
            //
            //if ( editRow[InventInputResult.ct_Col_BfStockTelNo2] != DBNull.Value )
            //	invEditWork.BfStockTelNo2			= (string)editRow[InventInputResult.ct_Col_BfStockTelNo2];  // �ύX�O���i�d�b�ԍ�2
            //
            //invEditWork.StkTelNo2ChgFlg			= (Int32)editRow[InventInputResult.ct_Col_StkTelNo2ChgFlg];  // ���i�d�b�ԍ�2�ύX�t���O
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            invEditWork.Jan = (string)editRow[InventInputResult.ct_Col_Jan];  // JAN�R�[�h
            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //invEditWork.StockUnitPriceFl      = (Int64)editRow[InventInputResult.ct_Col_StockUnitPrice];      // �d���P��
            //invEditWork.BfStockUnitPriceFl    = (Int64)editRow[InventInputResult.ct_Col_BfStockUnitPrice];    // �ύX�O�d���P��
            invEditWork.StockUnitPriceFl = (Double)editRow[InventInputResult.ct_Col_StockUnitPrice];     // �d���P��
            invEditWork.BfStockUnitPriceFl = (Double)editRow[InventInputResult.ct_Col_BfStockUnitPrice];   // �ύX�O�d���P��
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            invEditWork.StkUnitPriceChgFlg = (Int32)editRow[InventInputResult.ct_Col_StkUnitPriceChgFlg];  // �d���P���ύX�t���O
            invEditWork.StockDiv = (Int32)editRow[InventInputResult.ct_Col_StockDiv];            // �݌ɋ敪
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.StockState            = (Int32)editRow[InventInputResult.ct_Col_StockState];          // �݌ɏ��
            //invEditWork.MoveStatus			= (Int32)editRow[InventInputResult.ct_Col_MoveStatus];          // �ړ����
            //invEditWork.GoodsCodeStatus		= (Int32)editRow[InventInputResult.ct_Col_GoodsCodeStatus];     // ���i���
            //invEditWork.PrdNumMngDiv			= (Int32)editRow[InventInputResult.ct_Col_PrdNumMngDiv];        // ���ԊǗ��敪
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            invEditWork.LastStockDate = (DateTime)editRow[InventInputResult.ct_Col_LastStockDate];    // �ŏI�d���N����
            invEditWork.StockTotal = (Double)editRow[InventInputResult.ct_Col_StockTotal];         // �݌ɑ���
            invEditWork.ShipCustomerCode = (Int32)editRow[InventInputResult.ct_Col_ShipCustomerCode];    // �o�א擾�Ӑ�R�[�h
            invEditWork.ShipCustomerName = (string)editRow[InventInputResult.ct_Col_ShipCustomerName];   // �o�א擾�Ӑ於��
            invEditWork.ShipCustomerName2 = (string)editRow[InventInputResult.ct_Col_ShipCustomerName2];  // �o�א擾�Ӑ於��2

            if (editRow[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)  // �I���݌ɐ�
                invEditWork.InventoryStockCnt = (Double)editRow[InventInputResult.ct_Col_InventoryStockCnt];      // �I���݌ɐ�
            else
                invEditWork.InventoryStockCnt = 0;

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (editRow[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value)  // �I���ߕs����
            //    invEditWork.InventoryTolerancCnt	= (Double)editRow[InventInputResult.ct_Col_InventoryTolerancCnt];   // �I���ߕs����
            //else
            //    invEditWork.InventoryTolerancCnt	= 0;
            invEditWork.InventoryTolerancCnt = 0;
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //invEditWork.InventoryDate           = (Int32)editRow[InventInputResult.ct_Col_InventoryExeDay];         // �I����
            invEditWork.InventoryDate = (DateTime)editRow[InventInputResult.ct_Col_InventoryExeDay_Datetime];         // �I����
            // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
            invEditWork.InventoryPreprDay = TDateTime.LongDateToDateTime((int)editRow[InventInputResult.ct_Col_InventoryPreprDay]);  // �I�������������t
            invEditWork.InventoryPreprTim = (Int32)editRow[InventInputResult.ct_Col_InventoryPreprTim];       // �I��������������

            if (editRow[InventInputResult.ct_Col_InventoryDay] != DBNull.Value)
                invEditWork.InventoryDay = TDateTime.LongDateToDateTime((int)editRow[InventInputResult.ct_Col_InventoryDay]);  // �I�����{��
            else
                invEditWork.InventoryDay = DateTime.MinValue;

            invEditWork.LastInventoryUpdate = (DateTime)editRow[InventInputResult.ct_Col_LastInventoryUpdate];  // �ŏI�I���X�V��
            invEditWork.InventoryNewDiv = (Int32)editRow[InventInputResult.ct_Col_InventoryNewDiv];         // �I���V�K�ǉ��敪
            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            invEditWork.StockMashinePrice = (Int64)editRow[InventInputResult.ct_Col_StockMashinePrice];       // �}�V���݌Ɋz
            invEditWork.InventoryStockPrice = (Int64)editRow[InventInputResult.ct_Col_InventoryStockPrice];     // �I���݌Ɋz
            invEditWork.InventoryTlrncPrice = (Int64)editRow[InventInputResult.ct_Col_InventoryTlrncPrice];     // �I���ߕs�����z
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            invEditWork.Status = (Int32)editRow[InventInputResult.ct_Col_Status];  // �X�e�[�^�X	
            #endregion
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        // --- ADD 2014/12/04 Y.Wakita ---------->>>>>
        #region �� �s�̕����F��ύX
        /// <summary>
        /// RowForeColorChange
        /// </summary>
        /// <remarks>
        /// <br>Note		: �s�����������ꂽ�Ƃ��ɔ�������B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date        : 2014/12/04</br>
        /// </remarks>
        private void RowForeColorChange()
        {
            UltraGridRow activeRow = null;

            for (int index = 0; index < this.uGrid_InventInput.Rows.Count; index++)
            {
                activeRow = this.uGrid_InventInput.Rows[index];

                // �s�̕����F��ύX
                if ((int)activeRow.Cells[InventInputResult.ct_Col_Status].Value != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    activeRow.Appearance.ForeColor = Color.Red;
                }
                else if ((int)activeRow.Cells[InventInputResult.ct_Col_MoveStockCount].Value > 0)
                {
                    activeRow.Appearance.ForeColor = Color.Blue;
                }
                else
                {
                    activeRow.Appearance.ForeColor = Color.Black;
                }
            }
        }
        #endregion
        // --- ADD 2014/12/04 Y.Wakita ----------<<<<<

        #endregion �� Private Method

        #region �� Control Event

        #region �� MAZAI05130UB_Load
        /// <summary>
        /// MAZAI05130UB_Load
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�@�C����ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private void MAZAI05130UB_Load(object sender, EventArgs e)
        {
            // �����ݒ�
            InitialLoadScreen();

            // ���t�R���g���[���̔w�i�F�������I�ɕύX
            this.tde_InventoryDate.BackColor = Color.Transparent;
            this.tde_InventoryExeDate.BackColor = Color.Transparent;
        }
        #endregion

        #region �� MAZAI05130UB_FormClosing
        /// <summary>
        /// MAZAI05130UB_FormClosing
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[�������Ƃ��ɔ�������</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.27</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private void MAZAI05130UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �O���b�h�ݒ�ۑ�
            if (this._gridStateController != null)
            {
                this._gridStateController.GetGridStateFromGrid(ref this.uGrid_InventInput);
                this._gridStateController.SaveGridState(ct_FileName_ColDisplayStatus);
            }

            if (this._productNumInput != null)
                this._productNumInput.Dispose();

            if (this._readBarcodeForm != null)					// �o�[�R�[�h�Ǎ����
                this._readBarcodeForm.Dispose();

            if (this._createNewInventForm != null)					// �V�K���
                this._createNewInventForm.Dispose();

        }
        #endregion

        #region �� uGrid_InventInput_AfterPerformAction
        /// <summary>
        /// uGrid_InventInput_AfterPerformAction
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: AfterPerformAction�C�x���g�́A�L�[�A�N�V�����̃}�b�s���O�Ɋ֘A�t����ꂽ�A�N�V���������s���ꂽ��ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case UltraGridAction.ActivateCell:
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.PrevCell:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:
                    {
                        // �A�N�e�B�u�Z�����L��
                        if (this.uGrid_InventInput.ActiveCell != null)
                        {
                            // �ҏW���[�h�ֈڍs
                            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        break;
                    }
            }
        }
        #endregion

        #region �� uGrid_InventInput_KeyDown
        /// <summary>
        /// uGrid_InventInput_KeyDown
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���Ƀt�H�[�J�X������Ƃ��ɃL�[���������Ɣ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_KeyDown(object sender, KeyEventArgs e)
        {
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //KeyDownProc(sender, ref e);
            this._isDownKey = "ANYKEY";     //ADD 2009/05/14 �s��Ή�[13260]
            // �ҏW���̏ꍇ
            UltraGrid targetGrid = (UltraGrid)sender;
            if ((targetGrid.ActiveCell != null) && (targetGrid.ActiveCell.IsInEditMode == true))
            {
                // �Z���X�^�C���Ŕ���
                switch (e.KeyData)
                {
                    case Keys.Up:	// ���L�[
                        {
                            targetGrid.PerformAction(UltraGridAction.AboveCell);

                            // �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
                            if (targetGrid.ActiveCell != null)
                            {
                                if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            e.Handled = true;
                            break;
                        }
                    case Keys.Down:
                        {
                            targetGrid.PerformAction(UltraGridAction.BelowCell);

                            // �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
                            if (targetGrid.ActiveCell != null)
                            {
                                if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                // �ҏW���Ȃ牽�����Ȃ�
                                if (targetGrid.ActiveCell.IsInEditMode == true)
                                {
                                    if (targetGrid.ActiveCell.SelStart != 0)
                                    {
                                        return;
                                    }
                                }
                            }
                            targetGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                // �ҏW���Ȃ牽�����Ȃ�
                                if (targetGrid.ActiveCell.IsInEditMode == true)
                                {
                                    if (targetGrid.ActiveCell.SelStart < targetGrid.ActiveCell.Text.Length)
                                    {
                                        return;
                                    }
                                }
                            }
                            targetGrid.PerformAction(UltraGridAction.NextCellByTab);
                            e.Handled = true;
                            break;
                        }
                    case Keys.Enter:
                        {
                            // EnterKey�������ꂽ�Ƃ���TRetKeyContorol�Ő��䂳���
                            // �A�N�e�B�u�ɂȂ����Z����ҏW���[�h�ɂ���
                            if (targetGrid.ActiveCell != null)
                            {
                                if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            e.Handled = true;
                            break;
                        }
                    case Keys.Escape:	// ESC�L�[
                        {
                            UltraGridCell activeCell = this.uGrid_InventInput.ActiveCell;

                            // �I�����A�I���X�V���ȊO��ESC�������ꂽ�Ƃ�
                            if (
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) != 0)
                            {
                                this._isChangeInventStcCnt = true;
                                this._isChangeInventDate = true;
                                this._isChangeWarehouseShelfNo = true;
                                this._isChangeDuplicationShelfNo1 = true;
                                this._isChangeDuplicationShelfNo2 = true;
                                this._isChangeStockUnitPrice = true;

                                activeCell = this.uGrid_InventInput.ActiveCell;

                                if (targetGrid.ActiveRow != null)
                                {
                                    targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                }

                                targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                            
                            UltraGridRow targetGridRow;
                            targetGridRow = targetGrid.ActiveCell.Row;
                            double bfInventStkCnt = 0;	// �ύX�O�I����

                            // �I����
                            if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                            {
                                bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                            }
                            if ((targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value))
                            {
                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }

                                // �I����
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                                {
                                    bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                                }

                                // InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt); //DEL yangyi 2013/03/01 Redmine#34175
                                InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                           //ADD yangyi 2013/03/01 Redmine#34175 

                                e.Handled = true;
                                break;
                            }

                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                            // ���ِ�
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                            // �I����
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;

                            // InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt);      //DEL yangyi 2013/03/01 Redmine#34175
                            InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                                //ADD yangyi 2013/03/01 Redmine#34175 

                            targetGrid.ActiveCell = activeCell;
                            targetGrid.PerformAction(UltraGridAction.EnterEditMode);

                            e.Handled = true;
                            break;
                        }
                }
            }
            else
            {
                switch (e.KeyData)
                {
                    case Keys.Escape:	// ESC�L�[
                        {
                            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                            UltraGridRow targetGridRow;
                            targetGridRow = targetGrid.ActiveRow;
                            if (targetGrid.ActiveRow != null)
                            {
                                targetGridRow = targetGrid.ActiveRow;
                            }
                            else if (targetGrid.Selected.Rows[0] != null)
                            {
                                targetGridRow = targetGrid.Selected.Rows[0];
                            }
                            else
                            {
                                e.Handled = false;
                                break;
                            }
                            double bfInventStkCnt = 0;	// �ύX�O�I����
                            // �I����
                            if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                                bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                            if ((targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value))
                            {

                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }

                                //InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt); //DEL yangyi 2013/03/01 Redmine#34175
                                InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                          //ADD yangyi 2013/03/01 Redmine#34175 
    
                                e.Handled = true;
                                break;
                            }

                            // �I����
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                            // ���ِ�
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                            // �I����
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;

                            //InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt);        //DEL yangyi 2013/03/01 Redmine#34175
                            InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                                 //ADD yangyi 2013/03/01 Redmine#34175 

                            targetGrid.PerformAction(UltraGridAction.EnterEditMode);

                            e.Handled = true;
                            break;
                        }
                }
            }
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region �� uGrid_InventInput_KeyPress
        /// <summary>
        /// uGrid_InventInput_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //KeyPressProc(sender, ref e);

            //�A�N�e�B�u�Z��
            UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;

            // �O���X�敪
            //�A�N�e�B�u�Z������������
            if (activeCell != null)
            {
                if (activeCell.IsInEditMode == false) return;

                switch (activeCell.Column.Key)
                {
                    case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
                        if (KeyPressCheck(9, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, true, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    case InventInputResult.ct_Col_InventoryDay_Year:	//�I�����t�NEdit
                        if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    case InventInputResult.ct_Col_InventoryDay_Month:	//�I�����t��Edit
                    case InventInputResult.ct_Col_InventoryDay_Day:	    //�I�����t��Edit
                        if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    case InventInputResult.ct_Col_StockUnitPrice:       //�d���P��Edit
                        if (KeyPressCheck(11, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    // --- ADD 2009/04/13 -------------------------------->>>>>
                    case InventInputResult.ct_Col_WarehouseShelfNo:       //�I��
                    case InventInputResult.ct_Col_DuplicationShelfNo1:    //�d���I��1
                    case InventInputResult.ct_Col_DuplicationShelfNo2:    //�d���I��2
                        if (!Char.IsControl(e.KeyChar))
                        {
                            string prevStr = activeCell.Text;
                            string resultStr = prevStr.Substring(0, activeCell.SelStart) // �I��O�̕���
                                             + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                             + prevStr.Substring(activeCell.SelStart + activeCell.SelLength, prevStr.Length - (activeCell.SelStart + activeCell.SelLength)); // �I����̕���

                            Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                            int byteLength = sjis.GetByteCount(resultStr);

                            // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                            if (byteLength > 8)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    // --- ADD 2009/04/13 --------------------------------<<<<<
                }
            }
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region �� uGrid_InventInput_CellDataError
        /// <summary>
        /// uGrid_InventInput_CellDataError
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �s���Ȓl�����͂��ꂽ��ԂŃZ�����X�V���悤�Ƃ���Ɣ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            // �A�N�e�B�u�Z�����L��
            if (this.uGrid_InventInput.ActiveCell != null)
            {
                // NetAdvantage �s��̂��߂̃��W�b�N

                // ���݂̃Z�����擾
                UltraGridCell currentCell = this.uGrid_InventInput.ActiveCell;

                // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit�̏ꍇ
                if (currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
                    if ((currentCell.Text == null) || (currentCell.Text.TrimEnd() == ""))
                    {
                        // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
                        if ((currentCell.Column.DataType == typeof(Int32)) ||
                            (currentCell.Column.DataType == typeof(Int64)) ||
                            (currentCell.Column.DataType == typeof(double)))
                        {
                            // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
                            currentCell.Value = 0;
                            // �l���󔒂Ƃ�����0���Z�b�g����
                            e.RaiseErrorEvent = false;
                            e.RestoreOriginalValue = true;
                            e.StayInEditMode = true;

                        }
                    }
                }
            }
        }
        #endregion

        #region �� uGrid_InventInput_Enter
        /// <summary>
        /// uGrid_InventInput_Enter
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �R���g���[�������͂����Ɣ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_InventInput.ActiveCell == null)
            {
                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion

        #region �� uGrid_InventInput_CellChange
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_CellChange
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �ҏW���[�h�ɂ���Z���̒l�����[�U�[���ύX�����Ƃ��ɔ�������B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void uGrid_InventInput_CellChange(object sender, CellEventArgs e)
        {
            // �A�N�e�B�u�Z�����L��
            if (this.uGrid_InventInput.ActiveCell != null)
            {
                // NetAdvantage �s��̂��߂̃��W�b�N

                // ���݂̃Z�����擾
                UltraGridCell currentCell = this.uGrid_InventInput.ActiveCell;

                // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit�̏ꍇ
                if (currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
                    if ((currentCell.Text == null) || (currentCell.Text.TrimEnd() == ""))
                    {
                        // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
                        if ((e.Cell.Column.DataType == typeof(Int32)) ||
                            (e.Cell.Column.DataType == typeof(Int64)) ||
                            (e.Cell.Column.DataType == typeof(double)))
                        {
                            // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
                            e.Cell.Value = 0;
                        }
                    }
                }

                // �I�������ύX����Ă���ꍇ�ɕύX�t���O��True�ɂ���
                if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0)
                {
                    this._isChangeInventStcCnt = true;
                    //this._isChangeInventDate = false;
                }
                // �I�������ύX����Ă���ꍇ�ɂ͕ύX�t���O��True�ɂ���
                else if ((currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                         (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
                         (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                {
                    this._isChangeInventDate = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    this._isChangeWarehouseShelfNo = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    this._isChangeDuplicationShelfNo1 = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    this._isChangeDuplicationShelfNo2 = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    this._isChangeStockUnitPrice = true;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_CellChange
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �ҏW���[�h�ɂ���Z���̒l�����[�U�[���ύX�����Ƃ��ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_CellChange(object sender, CellEventArgs e)
        {
            // �A�N�e�B�u�Z�����L��
            if (this.uGrid_InventInput.ActiveCell != null)
            {
                // NetAdvantage �s��̂��߂̃��W�b�N

                // ���݂̃Z�����擾
                UltraGridCell currentCell = this.uGrid_InventInput.ActiveCell;

                // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit�̏ꍇ
                if (currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
                    if ((currentCell.Text == null) || (currentCell.Text.TrimEnd() == ""))
                    {
                        // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
                        if ((e.Cell.Column.DataType == typeof(Int32)) ||
                            (e.Cell.Column.DataType == typeof(Int64)) ||
                            (e.Cell.Column.DataType == typeof(double)))
                        {
                            // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
                            e.Cell.Value = 0;
                        }
                    }
                }

                // �I�������ύX����Ă���ꍇ�ɕύX�t���O��True�ɂ���
                if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0)
                {
                    this._isChangeInventStcCnt = true;
                    //this._isChangeInventDate = false;
                }
                // �I�������ύX����Ă���ꍇ�ɂ͕ύX�t���O��True�ɂ���
                else if ((currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                    (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
                    (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                {
                    this._isChangeInventDate = true;
                    //this._isChangeInventStcCnt = false;
                }
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_ProductNumber) == 0)
                //{
                //	this._isChangeInventProductNum = true;
                //}
                //else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockTelNo1) == 0)
                //{
                //	this._isChangeInventStockTelNo1 = true;
                //}
                //else if ( currentCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo1 ) == 0 )
                //{
                //	this._isChangeInventStockTelNo2 = true;
                //}
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    this._isChangeWarehouseShelfNo = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    this._isChangeDuplicationShelfNo1 = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    this._isChangeDuplicationShelfNo2 = true;
                }
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    this._isChangeStockUnitPrice = true;
                }
                // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� uGrid_InventInput_InitializeRow
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_InitializeRow
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �s�����������ꂽ�Ƃ��ɔ�������B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void uGrid_InventInput_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            //DataRow targetRow = (DataRow)e.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;       //DEL yangyi 2013/03/01 Redmine#34175
            DataRow targetRow = GetBindDataRow(e.Row);                                                //ADD yangyi 2013/03/01 Redmine#34175

            // �����F�ݒ�

            // �����l�\�����f
            if ((e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value != DBNull.Value))
            {
                if (((DateTime)e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value == DateTime.MinValue) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == 0) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value == 0))
                {
                    e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                }
            }

            // �s�̕����F��ύX
            if ((int)e.Row.Cells[InventInputResult.ct_Col_Status].Value != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                e.Row.Appearance.ForeColor = Color.Red;
            }
            else if ((int)e.Row.Cells[InventInputResult.ct_Col_MoveStockCount].Value > 0)
            {
                e.Row.Appearance.ForeColor = Color.Blue;
            }
            else
            {
                e.Row.Appearance.ForeColor = Color.Black;
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_InitializeRow
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �s�����������ꂽ�Ƃ��ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            DataRow targetRow = (DataRow)e.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;

            // �����F�ݒ�

            // TODO
            #region // 2007.07.19 kubo del -------------------------->
            //// �q�f�[�^�擾
            //DataView childDv = 
            //    new DataView( 
            //        this._inventInputAcs.InventDataTable, 
            //        MakeParentOrChildRowGetQuery(
            //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetRow ), 
            //            (int)InventInputSearchCndtn.ViewState.View ),
            //        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
            //        DataViewRowState.CurrentRows);


            //// ���ԍ݌ɏڍ׉�ʕ\���{�^����Enabled����
            //if ( (int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
            //{
            //    // Row�����i���̏ꍇ
            //    // ���ԊǗ��L��������
            //    if ( (int)targetRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
            //    {
            //        // 1���R�[�h�����Ȃ��������\��(�ǂ�ɓW�J���邩��I������K�v����������)
            //        if ( childDv.Count == 1 )
            //        {
            //            e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.Disabled;
            //        }
            //        else
            //        {
            //            e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.ActivateOnly;
            //        }
            //    }
            //    else
            //    {
            //        e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.Disabled;
            //    }
            //}
            //else
            //{
            //    // Row�����Ԗ��̏ꍇ
            //    e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.Disabled;
            //}
            #endregion // 2007.07.19 kubo del <--------------------------

            // �����l�\�����f
            if ((e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value != DBNull.Value))
            {
                if (((DateTime)e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value == DateTime.MinValue) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == 0) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value == 0))
                {
                    e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                }
            }

            // �s�̕����F��ύX
            ChangeRowColor(e.Row);
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� uGrid_InventInput_AfterExitEditMode
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterExitEditMode
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����ҏW���[�h���I�������Ƃ��ɔ�������B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void uGrid_InventInput_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;

            if (activeCell == null) return;

            try
            {
                bool isShowProduct = true;

                // �Z���ύX������
                if (activeCell.Text.Trim() == "")
                {
                    this._isChangeInventStcCnt = true;
                }

                // ---ADD 2009/05/14 �s��Ή�[13260] ----------->>>>>
                // �}�E�X�N���b�N�Ŕ��������A�X�V�͂��Ȃ�
                if (string.IsNullOrEmpty(this._isDownKey))
                {
                    if (string.IsNullOrEmpty(activeCell.Text.Trim()))
                    {
                        this._isChangeInventStcCnt = false;
                    }
                    else
                    {
                        this._isChangeInventStcCnt = true;
                    }
                }
                // ---ADD 2009/05/14 �s��Ή�[13260] -----------<<<<<

                AfterExitEditModeProc(activeCell, sender, this._isChangeInventStcCnt, this._isChangeInventDate, isShowProduct);
            }
            finally
            {
                this.uGrid_InventInput.Refresh();

                this._isChangeInventStcCnt = false;
                this._isChangeInventDate = false;
                this._isChangeWarehouseShelfNo = false;
                this._isChangeDuplicationShelfNo1 = false;
                this._isChangeDuplicationShelfNo2 = false;
                this._isChangeStockUnitPrice = false;
                this._isDownKey = string.Empty;      //ADD 2009/05/14 �s��Ή�[13260]
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterExitEditMode
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����ҏW���[�h���I�������Ƃ��ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_AfterExitEditMode(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;

            if (activeCell == null) return;

            try
            {
                bool isShowProduct = true;
                AfterExitEditModeProc(activeCell, sender, this._isChangeInventStcCnt, this._isChangeInventDate, isShowProduct);
                //ChangeViewStyle();
            }
            finally
            {
                // todo:
                this.uGrid_InventInput.Refresh();	// 2007.07.19 kubo add
                #region // 2007.07.19 kubo del
                // this.uGrid_InventInput.UpdateData();	// �O���b�h���X�V
                //this.uGrid_InventInput.UpdateMode = UpdateMode.OnCellChange;
                #endregion
                this._isChangeInventStcCnt = false;
                this._isChangeInventDate = false;
                // 2007.07.26 kubo del ------------->
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //this._isChangeInventProductNum = false;
                //this._isChangeInventStockTelNo1 = false;
                //this._isChangeInventStockTelNo2 = false;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.07.26 kubo del <-------------
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                this._isChangeWarehouseShelfNo = false;
                this._isChangeDuplicationShelfNo1 = false;
                this._isChangeDuplicationShelfNo2 = false;
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                this._isChangeStockUnitPrice = false;
                // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }

        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �� uGrid_InventInput_BeforeEnterEditMode
        /// <summary>
        /// uGrid_InventInput_BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �s���A�N�e�B�u�ɂȂ�O�ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.07.26</br>
        /// </remarks>
        private void uGrid_InventInput_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //UltraGrid targetGrid = (UltraGrid)sender;
            //
            //// �Z�����A�N�e�B�u�ɂ���
            //if (targetGrid.ActiveCell == null )
            //	targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
            //
            //if ( targetGrid.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo1 ) == 0 )
            //{
            //	if ( targetGrid.ActiveCell.Value != DBNull.Value )
            //		this._BfoerStockTelNo1 = targetGrid.ActiveCell.Value.ToString().TrimEnd();
            //	else
            //		this._BfoerStockTelNo1 = "";
            //}
            //else if ( targetGrid.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo2 ) == 0 )
            //{
            //	if ( targetGrid.ActiveCell.Value != DBNull.Value )
            //		this._BfoerStockTelNo2 = targetGrid.ActiveCell.Value.ToString().TrimEnd();
            //	else
            //		this._BfoerStockTelNo2 = "";
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<

        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� uGrid_InventInput_AfterCellActivate
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterCellActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_AfterCellActivate(object sender, EventArgs e)
        {
            UltraGrid targetGrid = (UltraGrid)sender;

            // �Z�����A�N�e�B�u�ɂ���
            if (targetGrid.ActiveCell == null)
            {
                targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
            }

            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
            //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

            if ((targetGrid.ActiveCell != null) &&
                (targetGrid.ActiveCell.Activation == Activation.AllowEdit))
            {
                // �ҏW���[�h�ɂ���
                targetGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterCellActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_AfterCellActivate(object sender, EventArgs e)
        {
            UltraGrid targetGrid = (UltraGrid)sender;

            // �Z�����A�N�e�B�u�ɂ���

            if (targetGrid.ActiveCell == null)
                targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

            // 2007.07.25 kubo add ------------->
            // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԕҏW�����f
            //// ���Ԗ��\�������ԊǗ��f�[�^���V�K�f�[�^���H
            //if ( (int)this.tce_ViewStyle.SelectedItem.DataValue == (int)InventInputSearchCndtn.ViewStyleState.Product &&
            //	 (int)targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_PrdNumMngDiv].Value  == (int)InventInputSearchCndtn.PrdNumMngDivState.Product &&
            //	 (int)targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryNewDiv].Value  == (int)InventInputSearchCndtn.NewRowState.New )
            //{
            //    // �����ԍ�
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_ProductNumber );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.AllowEdit, InventInputResult.ct_Col_ProductNumber );
            //	// �d�b�ԍ�1
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo1 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo1 );
            //	// �d�b�ԍ�2
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo2 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo2 );
            //}
            //else
            //{
            //	// �����ԍ�
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_ProductNumber );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.NoEdit, InventInputResult.ct_Col_ProductNumber );
            //	// �d�b�ԍ�1
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo1 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo1 );
            //	// �d�b�ԍ�2
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo2 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo2 );
            //}
            // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2007.07.25 kubo add <-------------



            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            if ((targetGrid.ActiveCell != null) &&
                (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
            {
                // �ҏW���[�h�ɂ���
                targetGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region �� uGrid_InventInput_ClickCellButton Event
        /// <summary>
        /// uGrid_InventInput_ClickCellButton Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_ClickCellButton(object sender, CellEventArgs e)
        {
            // �K�C�h�{�^�����N���b�N���ꂽ��
            DataRow targetDr;
            if (e.Cell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_Button) == 0)
            {
                targetDr = (DataRow)e.Cell.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;

                //ShowSelcetProduct( ref targetDr );
            }
        }
        #endregion

        #region �� uGrid_InventInput_MouseEnterElement
        /// <summary>
        /// uGrid_InventInput_MouseEnterElement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseEnterElement(object sender, UIElementEventArgs e)
        {
            //// �݌ɕ��i�����|�b�v�A�b�v�\��
            //Infragistics.Win.UIElement element = e.Element;

            //// Rou���擾
            //object objRow = element.GetContext(typeof(UltraGridRow));
            //if (objRow != null)
            //{
            //    // Row��null�ł͂Ȃ��ꍇ�c�[���`�b�v�ɕ\���������\������B
            //    UltraGridRow row = (UltraGridRow)objRow;

            //    StringBuilder tipString = new StringBuilder();

            //    if (row.Cells[ InventInputResult.ct_Col_RowSelf ].Value != null)
            //    {
            //        DataRow targetRow = (DataRow)row.Cells[ InventInputResult.ct_Col_RowSelf ].Value;
            //        // �G���[�̕\��
            //        if ( (int)targetRow[InventInputResult.ct_Col_Status] != 0 )
            //        {
            //            tipString.Append( "�G���[ --------------------" );
            //            tipString.Append( "\r\n" );
            //            tipString.Append( string.Format( "    {0}", targetRow[InventInputResult.ct_Col_StatusDetail].ToString()) );
            //            tipString.Append("\r\n\r\n");
            //        }


            //        // �ύX�_�̕\��
            //        if ( CheckChangeData( targetRow ) == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //        {
            //            tipString.Append( "�ύX�_ --------------------" );
            //            tipString.Append( "\r\n" );
            //            // �d�b�ԍ�1�A2�A���ԁA�I�����̂����ꂩ���ύX����Ă�����\��
            //            // �d�b�ԍ�1���ς���Ă���ꍇ
            //            if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo1ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //            {
            //                tipString.Append( string.Format( "    {0}", "�d�b�ԍ�1���ύX����Ă��܂�" ) );
            //                tipString.Append("\r\n");
            //            }

            //            // �d�b�ԍ�2���ς���Ă���ꍇ
            //            if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo2ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //            {
            //                tipString.Append( string.Format( "    {0}", "�d�b�ԍ�2���ύX����Ă��܂�" ));
            //                tipString.Append("\r\n");
            //            }
            //            // �d���P�����ύX����Ă���ꍇ
            //            if ( (int)targetRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //            {
            //                tipString.Append( string.Format( "    {0}", "�d�b�ԍ�1���ύX����Ă��܂�" ));
            //                tipString.Append("\r\n");
            //            }
            //            //// �I�������ς���Ă���ꍇ
            //            //if ( (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt] == (double)dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] )
            //            //{
            //            //    tipString.Append( "�I�������ύX����Ă��܂�" );
            //            //    tipString.Append("\r\n");
            //            //}
            //        }

            //        // �ړ��݌ɐ��̕\��
            //        if ( (int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0 )
            //        {
            //            tipString.Append( "�ړ��݌ɐ� --------------------" );
            //            tipString.Append( "\r\n" );
            //            tipString.Append( string.Format( "    �ړ��݌ɐ� �F {0}", (int)targetRow[InventInputResult.ct_Col_MoveStockCount] ));
            //            tipString.Append("\r\n");
            //        }
            //    }

            //    // �\��������e������Ƃ�����
            //    if ( tipString.ToString() != "" )
            //    {
            //        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            //        ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            //        ultraToolTipInfo.ToolTipTitle = "�I�����";
            //        ultraToolTipInfo.ToolTipText = tipString.ToString();

            //        this.uttm_ViewGridInfoToolTip.Appearance.FontData.Name = "�l�r �S�V�b�N";
            //        this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, ultraToolTipInfo);
            //        this.uttm_ViewGridInfoToolTip.Enabled = true;
            //    }
            //    else
            //    {
            //        this.uttm_ViewGridInfoToolTip.Enabled = false;
            //    }
            //}
        }
        /// <summary>
        /// �Z�����擾(String)
        /// </summary>
        /// <param name="row">�Ώۍs</param>
        /// <param name="key">Key</param>
        /// <returns>�Z�����</returns>
        private string GetStringForTip(UltraGridRow row, string key)
        {
            return string.Format("{0}�F{1}",
                this.uGrid_InventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput].Columns[key].Header.Caption.PadRight(9, '�@'),
                row.Cells[key].Value.ToString());
        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �� uGrid_InventInput_MouseLeaveElement
        /// <summary>
        /// uGrid_InventInput_MouseLeaveElement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            this.uttm_ViewGridInfoToolTip.Enabled = false;	// �c�[���`�b�v��\��
            this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, null);
        }
        #endregion

        #region �� uGrid_InventInput_MouseClick
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseClick(object sender, MouseEventArgs e)
        {
            // �G�������g���擾
            UIElement uiElement = this.uGrid_InventInput.DisplayLayout.UIElement.ElementFromPoint(e.Location);

            // Row���擾
            UltraGridRow row = uiElement.GetContext(typeof(UltraGridRow)) as UltraGridRow;

            if (row != null)
            {
                // Row��null�ł͂Ȃ��ꍇ�c�[���`�b�v�ɕ\���������\������B
                StringBuilder tipString = new StringBuilder();

                //if (row.Cells[InventInputResult.ct_Col_RowSelf].Value != null)   //DEL yangyi 2013/03/01 Redmine#34175
                if (GetBindDataRow(row) != null)                                   //ADD yangyi 2013/03/01 Redmine#34175 
                {
                    // DataRow targetRow = (DataRow)row.Cells[InventInputResult.ct_Col_RowSelf].Value;    //DEL yangyi 2013/03/01 Redmine#34175
                    DataRow targetRow = GetBindDataRow(row);                                              //ADD yangyi 2013/03/01 Redmine#34175 
                    // �G���[�̕\��
                    if ((int)targetRow[InventInputResult.ct_Col_Status] != 0)
                    {
                        tipString.Append("�G���[ --------------------");
                        tipString.Append(string.Format("\r\n    {0}", targetRow[InventInputResult.ct_Col_StatusDetail].ToString()));
                        tipString.Append("\r\n\r\n");
                    }

                    // �ύX�_�̕\��
                    if ((int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0)
                    {
                        StringBuilder changeString = new StringBuilder();

                        // �d���P�����ύX����Ă���ꍇ
                        if ((int)targetRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                        {
                            changeString.Append(string.Format("\r\n    {0}", "�d���P�����ύX����Ă��܂�"));
                        }

                        if (changeString.ToString().TrimEnd() != "")
                        {
                            tipString.Append("�ύX�_ --------------------");
                            tipString.Append(changeString.ToString());
                            tipString.Append("\r\n\r\n");
                        }
                        // �ړ��݌ɐ��̕\��
                        if ((int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0)
                        {
                            tipString.Append("�ړ����݌ɐ� ----------------");
                            tipString.Append(string.Format("\r\n    �ړ����݌ɐ� �F {0}", (int)targetRow[InventInputResult.ct_Col_MoveStockCount]));
                        }
                    }
                }

                // �\��������e������Ƃ�����
                if (tipString.ToString().TrimEnd() != "")
                {
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
                    ultraToolTipInfo.ToolTipTitle = "�I�����";
                    ultraToolTipInfo.ToolTipText = "�@\r\n" + tipString.ToString() + "\r\n�@";

                    this.uttm_ViewGridInfoToolTip.Appearance.FontData.Name = "�l�r �S�V�b�N";
                    this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, ultraToolTipInfo);
                    this.uttm_ViewGridInfoToolTip.Enabled = true;
                }
                else
                {
                    this.uttm_ViewGridInfoToolTip.Enabled = false;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseClick(object sender, MouseEventArgs e)
        {
            //// �݌ɕ��i�����|�b�v�A�b�v�\��

            // �G�������g���擾
            UIElement uiElement = this.uGrid_InventInput.DisplayLayout.UIElement.ElementFromPoint(e.Location);

            // Row���擾
            UltraGridRow row = uiElement.GetContext(typeof(UltraGridRow)) as UltraGridRow;

            if (row != null)
            {
                // Row��null�ł͂Ȃ��ꍇ�c�[���`�b�v�ɕ\���������\������B
                StringBuilder tipString = new StringBuilder();

                if (row.Cells[InventInputResult.ct_Col_RowSelf].Value != null)
                {
                    DataRow targetRow = (DataRow)row.Cells[InventInputResult.ct_Col_RowSelf].Value;
                    // �G���[�̕\��
                    if ((int)targetRow[InventInputResult.ct_Col_Status] != 0)
                    {
                        tipString.Append("�G���[ --------------------");
                        tipString.Append(string.Format("\r\n    {0}", targetRow[InventInputResult.ct_Col_StatusDetail].ToString()));
                        tipString.Append("\r\n\r\n");
                    }


                    // �ύX�_�̕\��
                    if (CheckChangeData(targetRow) == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                    {
                        StringBuilder changeString = new StringBuilder();
                        // �d�b�ԍ�1�A2�A���ԁA�I�����̂����ꂩ���ύX����Ă�����\��
                        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                        //// �d�b�ԍ�1���ς���Ă���ꍇ
                        //if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo1ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
                        //{
                        //	changeString.Append( string.Format( "\r\n    {0}", "�d�b�ԍ�1���ύX����Ă��܂�" ) );
                        //}
                        //	
                        //// �d�b�ԍ�2���ς���Ă���ꍇ
                        //if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo2ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
                        //{
                        //	changeString.Append( string.Format( "\r\n    {0}", "�d�b�ԍ�2���ύX����Ă��܂�" ));
                        //}
                        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                        // �d���P�����ύX����Ă���ꍇ
                        if ((int)targetRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                        {
                            changeString.Append(string.Format("\r\n    {0}", "�d���P�����ύX����Ă��܂�"));
                        }

                        if (changeString.ToString().TrimEnd() != "")
                        {
                            tipString.Append("�ύX�_ --------------------");
                            tipString.Append(changeString.ToString());
                            tipString.Append("\r\n\r\n");
                        }
                        // �ړ��݌ɐ��̕\��
                        if ((int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0)
                        {
                            tipString.Append("�ړ����݌ɐ� ----------------");
                            tipString.Append(string.Format("\r\n    �ړ����݌ɐ� �F {0}", (int)targetRow[InventInputResult.ct_Col_MoveStockCount]));
                        }
                        //// �I�������ς���Ă���ꍇ
                        //if ( (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt] == (double)dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] )
                        //{
                        //    tipString.Append( "�I�������ύX����Ă��܂�" );
                        //    tipString.Append("\r\n");
                        //}
                    }
                }

                // �\��������e������Ƃ�����
                if (tipString.ToString().TrimEnd() != "")
                {
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
                    ultraToolTipInfo.ToolTipTitle = "�I�����";
                    ultraToolTipInfo.ToolTipText = "�@\r\n" + tipString.ToString() + "\r\n�@";

                    this.uttm_ViewGridInfoToolTip.Appearance.FontData.Name = "�l�r �S�V�b�N";
                    this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, ultraToolTipInfo);
                    this.uttm_ViewGridInfoToolTip.Enabled = true;
                }
                else
                {
                    this.uttm_ViewGridInfoToolTip.Enabled = false;
                }
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� uGrid_InventInput_AfterRowActivate
        /// <summary>
        /// uGrid_InventInput_AfterRowActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_AfterRowActivate(object sender, EventArgs e)
        {
            // 2007.07.25 kubo add ------------------------>
            if (ParentToolbarInventSettingEvent != null)
            {
                // �C���{�^����Enable�𔻒f
                if (this.uGrid_InventInput.ActiveRow != null)
                {
                    if ((int)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryNewDiv].Value ==
                        (int)InventInputSearchCndtn.NewRowState.New)
                    {
                        this._isDataEdit = true;
                    }
                    else
                    {
                        this._isDataEdit = false;
                    }

                    ParentToolbarInventSettingEvent(this);
                }
            }
            // 2007.07.25 kubo add <------------------------

            // --- DEL 2009/02/06 ��QID:10994�Ή�------------------------------------------------------>>>>>
            //// 2007.07.24 kubo add ------------------------>
            //if (this.uGrid_InventInput.ActiveRow != null)
            //{
            //    // �폜�{�^����Enabled�ݒ�
            //    if ((int)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryNewDiv].Value == (int)InventInputSearchCndtn.NewRowState.New)
            //    {
            //        this.ub_RowDelete.Enabled = true;
            //    }
            //    else
            //    {
            //        this.ub_RowDelete.Enabled = false;
            //    }
            //}
            //// 2007.07.24 kubo add <------------------------
            // --- DEL 2009/02/06 ��QID:10994�Ή�------------------------------------------------------<<<<<

            // �����F�ݒ�
            this.uGrid_InventInput.DisplayLayout.Override.ActiveRowAppearance.ForeColor = this.uGrid_InventInput.ActiveRow.Appearance.ForeColor;
        }
        #endregion

        //#region �� uGrid_InventInput_AfterSelectChange
        ///// <summary>
        ///// uGrid_InventInput_AfterSelectChange
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uGrid_InventInput_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        //{
        //    if (this.uGrid_InventInput.ActiveRow == null) return;

        //    if (uGrid_InventInput.Selected.Rows.Count > 1)
        //    {
        //        this.uGrid_InventInput.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
        //    }
        //    else
        //    {
        //        this.uGrid_InventInput.DisplayLayout.Override.ActiveRowAppearance.ForeColor = this.uGrid_InventInput.ActiveRow.Appearance.ForeColor;
        //    }
        //}
        //#endregion

        #region �� tce_ViewStyle_ValueChanged
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tce_ViewStyle_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tce_ViewStyle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.uGrid_InventInput.BeginUpdate();

                DataRow lastRow;
                if (this.uGrid_InventInput.ActiveRow != null)
                    lastRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;
                else
                    lastRow = null;

                ChangeViewStyle();
                if (this.uGrid_InventInput.Rows.Count > 0)
                {
                    // �O��\����ԂőI������Ă����s�Ɋ֘A����s��I��
                    // �q��, ���[�J�[, �i��, �݌ɋ敪, �d���P��, �d����R�[�h, �ϑ���R�[�h, ���Ǝ҃R�[�h��
                    // ��v���Ă����炻�̍s��I������

                    //UltraGridRow activeGridRow = null;

                    if (lastRow == null)
                    {
                        this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                        //activeGridRow = this.uGrid_InventInput.Rows[0];
                    }
                    else
                    {
                        for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                        {
                            if (
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd() ==	// �q��
                                  lastRow[InventInputResult.ct_Col_WarehouseCode].ToString().TrimEnd()) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value == // ���[�J�[
                                  (int)lastRow[InventInputResult.ct_Col_MakerCode]) &&
                                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                                //( this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsCode].Value.ToString().TrimEnd() == // �i��
                                //  lastRow[InventInputResult.ct_Col_GoodsCode].ToString().TrimEnd()) &&
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd() == // �i��
                                  lastRow[InventInputResult.ct_Col_GoodsNo].ToString().TrimEnd()) &&
                                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockTrtEntDiv].Value == // �ϑ�����敪
                                  (int)lastRow[InventInputResult.ct_Col_StockTrtEntDiv]) &&
                                // 2008.02.14 �폜 >>>>>>>>>>>>>>>>>>>>
                                //( (long)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockUnitPrice].Value == // ���P��
                                //  (long)lastRow[InventInputResult.ct_Col_StockUnitPrice] ) &&
                                // 2008.02.14 �폜 <<<<<<<<<<<<<<<<<<<<
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CustomerCode].Value == // �d����R�[�h
                                  (int)lastRow[InventInputResult.ct_Col_CustomerCode]) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_ShipCustomerCode].Value == // �ϑ���R�[�h
                                  (int)lastRow[InventInputResult.ct_Col_ShipCustomerCode]) //&&
                                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                                //((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CarrierEpCode].Value == // ���Ǝ�
                                //  (int)lastRow[InventInputResult.ct_Col_CarrierEpCode] ) //&&
                                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                                //( (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryNewDiv].Value == // �V�K�敪
                                //  (int)lastRow[InventInputResult.ct_Col_InventoryNewDiv] )
                            )
                            {
                                if (this.uGrid_InventInput.ActiveRow == null)
                                    this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;

                                this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);

                            }
                        }
                    }
                    //// �X�N���[��
                    this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.ActiveRow;

                    //if ( activeGridRow != null )
                    //    activeGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                    //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.None;
                    //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.None;

                }
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tce_ViewStyle_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tce_ViewStyle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.uGrid_InventInput.BeginUpdate();

                DataRow lastRow;
                if (this.uGrid_InventInput.ActiveRow != null)
                    //lastRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;  //DEL yangyi 2013/03/01 Redmine#34175
                    lastRow = GetBindDataRow(this.uGrid_InventInput.ActiveRow);                                           //ADD yangyi 2013/03/01 Redmine#34175 
                else
                    lastRow = null;

                ChangeViewStyle();
                if (this.uGrid_InventInput.Rows.Count > 0)
                {
                    // �O��\����ԂőI������Ă����s�Ɋ֘A����s��I��
                    // �q��, ���[�J�[, �i��, �݌ɋ敪, �d���P��, �d����R�[�h, �ϑ���R�[�h, ���Ǝ҃R�[�h��
                    // ��v���Ă����炻�̍s��I������

                    if (lastRow == null)
                    {
                        this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                    }
                    else
                    {
                        for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                        {
                            if (
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd() ==	// �q��
                                  lastRow[InventInputResult.ct_Col_WarehouseCode].ToString().TrimEnd()) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value == // ���[�J�[
                                  (int)lastRow[InventInputResult.ct_Col_MakerCode]) &&
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd() == // �i��
                                  lastRow[InventInputResult.ct_Col_GoodsNo].ToString().TrimEnd()) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockTrtEntDiv].Value == // �ϑ�����敪
                                  (int)lastRow[InventInputResult.ct_Col_StockTrtEntDiv]) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_SupplierCode].Value == // �d����R�[�h
                                  (int)lastRow[InventInputResult.ct_Col_SupplierCode]) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_ShipCustomerCode].Value == // �ϑ���R�[�h
                                  (int)lastRow[InventInputResult.ct_Col_ShipCustomerCode]) //&&
                            )
                            {
                                if (this.uGrid_InventInput.ActiveRow == null)
                                    this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;

                                this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);

                            }
                        }
                    }
                    // �X�N���[��
                    this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.ActiveRow;
                }
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region �� tce_SortOrder_ValueChanged
        /// <summary>
        /// tce_SortOrder_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tce_SortOrder_ValueChanged(object sender, EventArgs e)
        {
            // Grid�\����ԕύX
            ChangeViewStyle();

            if (this.uGrid_InventInput.Rows.Count > 0)
            {
                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
            }
        }
        #endregion

        #region �� tRetKeyControl_ChangeFocus
        ///// <summary>
        ///// tRetKeyControl_ChangeFocus Event
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �t�H�[�J�X���J�ڂ���ꍇ�ɔ�������B</br>
        ///// <br>Programmer	: 22013 kubo</br>
        ///// <br>date		: 2007.04.17</br>
        ///// </remarks>
        //private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        //{
        //    if ((e.PrevCtrl == null) ||
        //        (e.NextCtrl == null))
        //    {
        //        return;
        //    }

        //    // ���o���ʃO���b�h�̏ꍇ
        //    if (e.PrevCtrl.Equals(this.uGrid_InventInput) == true)
        //    {
        //        // �A�N�e�B�u�Z�����L��
        //        if (this.uGrid_InventInput.ActiveCell != null)
        //        {
        //            int rowIndex = this.uGrid_InventInput.ActiveCell.Row.Index;

        //            // ���͂��ꂽ�L�[�Ŕ���
        //            // Enter�L�[
        //            if (((e.Key == Keys.Enter) || (e.Key == Keys.Tab)) &&
        //                ((e.ShiftKey == false) && (e.ControlKey == false) && (e.AltKey == false)))
        //            {
        //                switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                {
        //                    // �I����
        //                    case InventInputResult.ct_Col_InventoryStockCnt:
        //                        this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //                        break;
        //                    // �N
        //                    case InventInputResult.ct_Col_InventoryDay_Year:
        //                        this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //                        break;
        //                    // ��
        //                    case InventInputResult.ct_Col_InventoryDay_Month:
        //                        this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //                        break;
        //                    // ��
        //                    case InventInputResult.ct_Col_InventoryDay_Day:	
        //                        // �N���A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
        //                        if (this.uGrid_InventInput.ActiveRow != null)
        //                        {
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                        }
        //                        break;
        //                    default:
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                        break;
        //                }

        //                if (this.uGrid_InventInput.ActiveRow.Index == this.uGrid_InventInput.Rows.Count - 1)
        //                {
        //                    // �ŏI�s�̒I�������A�{�^����������J�����T�C�Y�R���{�{�b�N�X�Ɉړ�
        //                    if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0) ||
        //                        (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
        //                    {
        //                        e.NextCtrl = null;
        //                    }
        //                    else
        //                    {
        //                        //// ���̃Z���ֈړ�
        //                        // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
        //                        switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                        {
        //                            case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// ���Ɉړ�
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Year:	// �N
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// �E�Ɉړ�
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Month:	// ��
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// �E�Ɉړ�
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Day:	// ��
        //                                // �N���A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
        //                                if (this.uGrid_InventInput.ActiveRow != null)
        //                                {
        //                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                                    this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                                }
        //                                break;
        //                            default:
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                                break;
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                    //// ���̃Z���ֈړ�
        //                    // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
        //                    switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                    {
        //                        case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// ���Ɉړ�
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Year:	// �N
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// �E�Ɉړ�
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Month:	// ��
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// �E�Ɉړ�
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Day:	// ��
        //                            // �N���A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
        //                            if (this.uGrid_InventInput.ActiveRow != null)
        //                            {
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                            }
        //                            break;
        //                        default:
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                            break;
        //                    }
        //                }

        //                e.NextCtrl = null;
        //            }
        //            // Shift + Enter�L�[
        //            else if ((e.Key == Keys.Enter) &&
        //                ((e.ShiftKey == true) && (e.ControlKey == false) && (e.AltKey == false)))
        //            {
        //                if (this.uGrid_InventInput.ActiveRow.Index == 0)
        //                {
        //                    if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
        //                        (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryTolerancCnt) == 0))
        //                    {
        //                        // �擪�s�̏ꍇ
        //                        this.tce_SortOrder.Focus();
        //                    }
        //                    else
        //                    {
        //                        //// �O�̃Z���ֈړ�
        //                        // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
        //                        switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                        {
        //                            case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// ���Ɉړ�
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Year:	// �N
        //                                // �����A�N�e�B�u�ɂ��Ă����Ɉړ�
        //                                if (this.uGrid_InventInput.ActiveRow != null)
        //                                {
        //                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
        //                                    this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                                }
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Month:	// ��
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Day:	// ��
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
        //                                break;
        //                            default:
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                                break;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //// �O�̃Z���ֈړ�
        //                    // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
        //                    switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                    {
        //                        case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// ���Ɉړ�
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Year:	// �N
        //                            // �����A�N�e�B�u�ɂ��Ă����Ɉړ�
        //                            if (this.uGrid_InventInput.ActiveRow != null)
        //                            {
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                            }
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Month:	// ��
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Day:	// ��
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
        //                            break;
        //                        default:
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                            break;
        //                    }
        //                }
        //                e.NextCtrl = null;
        //            }
        //        }
        //    }
        //    else if (e.NextCtrl.Equals(this.uGrid_InventInput))
        //    {
        //        // �O�̃R���g���[�����\�[�g���̂Ƃ�
        //        if (e.PrevCtrl.Equals(this.tce_SortOrder))
        //        {
        //            // �擪�s�̒I����
        //            if (this.uGrid_InventInput.ActiveCell == null)
        //            {
        //                this.uGrid_InventInput.ActiveCell =
        //                    this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt];
        //            }
        //            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //        }
        //        else if (e.PrevCtrl.Equals(this.tce_FontSize))
        //        {
        //            // �ŏI�s�̒I����
        //            if (this.uGrid_InventInput.ActiveCell == null)
        //            {
        //                this.uGrid_InventInput.ActiveCell =
        //                    this.uGrid_InventInput.Rows[this.uGrid_InventInput.Rows.Count - 1].Cells[InventInputResult.ct_Col_InventoryStockCnt];
        //            }
        //            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //        }
        //    }
        //}
        /// <summary>
        /// tRetKeyControl_ChangeFocus Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X���J�ڂ���ꍇ�ɔ�������B</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>date		: 2007.04.17</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) ||
                (e.NextCtrl == null))
            {
                return;
            }

            // ���o���ʃO���b�h�̏ꍇ
            if (e.PrevCtrl.Equals(this.uGrid_InventInput) == true)
            {
                // �A�N�e�B�u�Z�����L��
                if (this.uGrid_InventInput.ActiveCell != null)
                {
                    // ---ADD 2009/05/14 �s��Ή�[13260] -------------------->>>>>
                    if ((e.Key == Keys.LButton) || (e.Key == Keys.RButton))
                    {
                        this._isDownKey = string.Empty;
                    }
                    else
                    {
                        this._isDownKey = "ANYKEY";
                    }
                    // ---ADD 2009/05/14 �s��Ή�[13260] --------------------<<<<<

                    // ���͂��ꂽ�L�[�Ŕ���
                    // Enter�L�[
                    if (((e.Key == Keys.Enter) || (e.Key == Keys.Tab)) &&
                        ((e.ShiftKey == false) && (e.ControlKey == false) && (e.AltKey == false)))
                    {
                        if (this.uGrid_InventInput.ActiveRow.Index == this.uGrid_InventInput.Rows.Count - 1)
                        {
                            // �ŏI�s�̒I�������A�{�^����������J�����T�C�Y�R���{�{�b�N�X�Ɉړ�
                            if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0) ||
                                (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                            {
                                //this.uce_ColSizeAutoSetting.Focus();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                            }
                            //if ( this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day ) == 0 )
                            //{
                            //    // �ŏI�s�̔������Z���̏ꍇ
                            //    this.uce_ColSizeAutoSetting.Focus();
                            //}
                            else
                            {
                                this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                                ////// ���̃Z���ֈړ�
                                ////this.uGrid_InventInput.PerformAction( UltraGridAction.BelowCell );
                                //// �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
                                //switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                                //{
                                //    case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
                                //        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// ���Ɉړ�
                                //        break;
                                //    case InventInputResult.ct_Col_InventoryDay_Year:	// �N
                                //        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// �E�Ɉړ�
                                //        break;
                                //    case InventInputResult.ct_Col_InventoryDay_Month:	// ��
                                //        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// �E�Ɉړ�
                                //        break;
                                //    case InventInputResult.ct_Col_InventoryDay_Day:	// ��
                                //        // �N���A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
                                //        if (this.uGrid_InventInput.ActiveRow != null)
                                //        {
                                //            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                //            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                //        }
                                //        break;
                                //    default:
                                //        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                //        break;
                                //}

                            }
                        }
                        else
                        {
                            //// ���̃Z���ֈړ�
                            //this.uGrid_InventInput.PerformAction( UltraGridAction.BelowCell );
                            // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
                            switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                            {
                                case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// ���Ɉړ�
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Year:	// �N
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// �E�Ɉړ�
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Month:	// ��
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// �E�Ɉړ�
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Day:	// ��
                                    // �N���A�N�e�B�u�ɂ��Ă��牺�Ɉړ�
                                    if (this.uGrid_InventInput.ActiveRow != null)
                                    {
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                    }
                                    break;
                                default:
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                    break;
                            }
                        }

                        e.NextCtrl = null;
                    }
                    // Shift + Enter�L�[
                    else if ((e.Key == Keys.Enter) &&
                        ((e.ShiftKey == true) && (e.ControlKey == false) && (e.AltKey == false)))
                    {
                        if (this.uGrid_InventInput.ActiveRow.Index == 0)
                        {
                            if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                                (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryTolerancCnt) == 0))
                            {
                                // �擪�s�̏ꍇ
                                this.tce_SortOrder.Focus();
                            }
                            else
                            {
                                //// �O�̃Z���ֈړ�
                                //this.uGrid_InventInput.PerformAction( UltraGridAction.AboveCell );
                                // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
                                switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                                {
                                    case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// ���Ɉړ�
                                        break;
                                    case InventInputResult.ct_Col_InventoryDay_Year:	// �N
                                        // �����A�N�e�B�u�ɂ��Ă����Ɉړ�
                                        if (this.uGrid_InventInput.ActiveRow != null)
                                        {
                                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
                                            this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                        }
                                        break;
                                    case InventInputResult.ct_Col_InventoryDay_Month:	// ��
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                        break;
                                    case InventInputResult.ct_Col_InventoryDay_Day:	// ��
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
                                        break;
                                    default:
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            //// �O�̃Z���ֈړ�
                            //this.uGrid_InventInput.PerformAction( UltraGridAction.AboveCell );
                            // �L�[�������ꂽ�Ƃ���ActiveCell�ɂ���ē����ς���
                            switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                            {
                                case InventInputResult.ct_Col_InventoryStockCnt:	// �I����
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// ���Ɉړ�
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Year:	// �N
                                    // �����A�N�e�B�u�ɂ��Ă����Ɉړ�
                                    if (this.uGrid_InventInput.ActiveRow != null)
                                    {
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                    }
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Month:	// ��
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Day:	// ��
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
                                    break;
                                default:
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                    break;
                            }
                        }
                        e.NextCtrl = null;
                    }
                }
            }
            // �\�[�g��
            else if (e.PrevCtrl.Equals(this.tce_SortOrder))
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.uGrid_InventInput.Rows.Count > 0)
                        {
                            e.NextCtrl = null;
                            this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else if (e.NextCtrl.Equals(this.uGrid_InventInput))
            {
                // �O�̃R���g���[�����\�[�g���̂Ƃ�
                if (e.PrevCtrl.Equals(this.tce_SortOrder))
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            if (this.uGrid_InventInput.Rows.Count > 0)
                            {
                                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
                else if (e.PrevCtrl.Equals(this.tce_FontSize))
                {
                    e.NextCtrl = null;
                    // �ŏI�s�̒I����
                    if (this.uGrid_InventInput.ActiveCell == null)
                    {
                        this.uGrid_InventInput.ActiveCell =
                            this.uGrid_InventInput.Rows[this.uGrid_InventInput.Rows.Count - 1].Cells[InventInputResult.ct_Col_InventoryStockCnt];
                    }
                    //					this.uGrid_InventInput.ActiveCell.Activate();
                    this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                }
                // �I����
                else if (e.PrevCtrl.Equals(this.tde_InventoryDate))
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            if (this.uGrid_InventInput.Rows.Count > 0)
                            {
                                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
                // �ꊇ�ݒ�{�^��
                else if (e.PrevCtrl.Equals(this.ub_InventoryAllInput))
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            if (this.uGrid_InventInput.Rows.Count > 0)
                            {
                                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region �� tde_InventoryDate_Leave
        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tde_InventoryDate_Leave(object sender, EventArgs e)
        {
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //// ���t���̓`�F�b�N
            //if (((TDateEdit)sender).GetDateTime() == DateTime.MinValue)
            //{
            //    this.MsgDispProc("���t���w�肵�ĉ�����", emErrorLevel.ERR_LEVEL_EXCLAMATION);
            //    this.tde_InventoryDate.Focus();
            //}
            //else if (!DateEditInputCheck(((TDateEdit)sender).GetDateTime(), false))
            //{
            //    this.MsgDispProc("�s���ȓ��t�ł�", emErrorLevel.ERR_LEVEL_EXCLAMATION);
            //    this.tde_InventoryDate.Focus();
            //}
            //// 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //else
            //{
            //    DateTime targetDate = ((TDateEdit)sender).GetDateTime();
            //    DateTime workDate = this.tde_InventoryExeDate.GetDateTime();
            //    if (targetDate > workDate.AddMonths(2))
            //    {
            //        this.MsgDispProc("�s���ȓ��t�ł� �I��������Q�����ȓ��œ��͂��ĉ�����", emErrorLevel.ERR_LEVEL_EXCLAMATION);
            //        this.tde_InventoryDate.Focus();
            //    }
            //}
            //// 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // ���t���̓`�F�b�N
            string errMsg;
            if (!DateEditInputCheck((TDateEdit)sender, out errMsg))
            {
                MsgDispProc(errMsg, emErrorLevel.ERR_LEVEL_EXCLAMATION);
                this.tde_InventoryDate.Focus();
                return;
            }

            DateTime targetDate = ((TDateEdit)sender).GetDateTime();
            DateTime workDate = this.tde_InventoryExeDate.GetDateTime();
            if (targetDate > workDate.AddMonths(2))
            {
                this.MsgDispProc("�s���ȓ��t�ł� �I��������Q�����ȓ��œ��͂��ĉ�����", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                this.tde_InventoryDate.Focus();
                return;
            }

            this.utb_InventDataToolBar.ActiveTool = null;
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region �� ub_InventoryAllInput_Click
        /// <summary>
        /// �ꊇ�ݒ�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void ub_InventoryAllInput_Click(object sender, EventArgs e)
        {
            // ---ADD 2009/05/14 �s��Ή�[13260] ------------------------------------------------->>>>>
            //�m�F���b�Z�[�W
            string strMsg = "�I�����{����ݒ肵�܂��B��낵���ł����H\r\n�����łɐݒ�ς̓��t���X�V����܂�";
            DialogResult dlgRes = TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_INFO,        //�G���[���x��
                "MAZAI05130UB",                     //UNIT�@ID
                "�I������",                        //�v���O��������
                "�ꊇ�ݒ�",		                        //�v���Z�XID
                "",                                 //�I�y���[�V����
                strMsg.ToString(),                             //���b�Z�[�W
                0,									//�X�e�[�^�X
                null,								//�I�u�W�F�N�g
                MessageBoxButtons.YesNo,               //�_�C�A���O�{�^���w��
                MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
                );
            if (dlgRes == DialogResult.No)
            {
                return;
            }
            // ---ADD 2009/05/14 �s��Ή�[13260] -------------------------------------------------<<<<<

            DataView gridView = (DataView)uGrid_InventInput.DataSource;

            DataRow targetDr;
            //bool isShowProduct = false;           //DEL 2009/04/21 �s��Ή�[13075]
            SFCMN00299CA msgForm = new SFCMN00299CA();
            // ���o����ʕ��i�̃C���X�^���X���쐬
            msgForm.Title = "�ꊇ�ݒ蒆";
            //msgForm.Message = "�I�����̐ݒ蒆�ł��B";         //DEL 2009/05/14 �s��Ή�[13260]
            msgForm.Message = "�I�����{���̐ݒ蒆�ł��B";       //ADD 2009/05/14 �s��Ή�[13260]
            try
            {
                msgForm.Show();	// �_�C�A���O�\��

                this.uGrid_InventInput.BeginUpdate();	// �`���~

                /* ---DEL 2009/04/21 �s��Ή�[13075] -------------------------------------------------------------->>>>>
                for (int index = 0; index < gridView.Count; index++)
                {
                    Debug.WriteLine("InventAllInput Start:" + DateTime.Now.TimeOfDay.ToString());
                    targetDr = gridView[index].Row;
                    //// �I�����ƒI���������͍ς݂Ȃ珈�����Ȃ�
                    //if ((targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value) &&
                    //    targetDr[InventInputResult.ct_Col_InventoryDay_Datetime] != DBNull.Value)
                    //{
                    //    continue;
                    //}

                    // �I�����ݒ�(�I����=���됔)
                    if ((double)targetDr[InventInputResult.ct_Col_StockTotal] == 0)
                    {
                        this.uGrid_InventInput.Rows[index].Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = 0;
                        targetDr[InventInputResult.ct_Col_InventoryStockCnt] = 0;
                    }
                    else
                    {
                        targetDr[InventInputResult.ct_Col_InventoryStockCnt] = (double)targetDr[InventInputResult.ct_Col_StockTotal];
                    }
                    // �ύX�敪���Z�b�g
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

                    // �I�����X�V
                    this.AfterInputInventryToleCnt(
                        ref targetDr,
                        (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);

                    // ���t�X�V
                    this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());

                    Debug.WriteLine("InventAllInput End:" + DateTime.Now.TimeOfDay.ToString());

                }
                   ---DEL 2009/04/21 �s��Ή�[13075] --------------------------------------------------------------<<<<< */
                // ---ADD 2009/04/21 �s��Ή�[13075] -------------------------------------------------------------->>>>>
                this._inventInputView.RowFilter = string.Empty;         //ADD 2009/05/14 �s��Ή�[13260]�@�t�H�[�J�X�̓������Ă��鏊�����X�V�ł��Ȃ���
                for (int index = 0; index < this._inventInputView.Count; index++)
                {
                    targetDr = this._inventInputView[index].Row;

                    //���t�X�V
                    this._inventInputAcs.DevInventoryDay(targetDr, this.tde_InventoryDate.GetDateTime());

                    // ---DEL 2009/05/14 �s��Ή�[13260] -------------------------------------------------->>>>>
                    ////�I����
                    //if ((double)targetDr[InventInputResult.ct_Col_StockTotal] == 0)
                    //{
                    //    targetDr[InventInputResult.ct_Col_InventoryStockCnt] = 0;
                    //}
                    //else
                    //{
                    //    targetDr[InventInputResult.ct_Col_InventoryStockCnt] = (double)targetDr[InventInputResult.ct_Col_StockTotal];
                    //}

                    ////�O�񍷈ِ�    �����񍷈ِ����X�V����O�ɃZ�b�g���Ă���
                    //double bfInvToleCnt = 0;
                    //if (targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value)
                    //{
                    //    bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
                    //}

                    //targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;

                    ////���񍷈ِ�
                    //double toleCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal] - (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
                    //targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] = toleCnt;
                    // ---DEL 2009/05/14 �s��Ή�[13260] --------------------------------------------------<<<<<

                    //�ύX�敪
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }


                // ---ADD 2009/04/21 �s��Ή�[13075] --------------------------------------------------------------<<<<<
            }
            catch (Exception ex)
            {
                this.MsgDispProc("�I�����ꊇ�ݒ�Ɏ��s���܂����B", -1, "ub_InventoryAllInput_Click", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
                msgForm.Close();
            }
        }
        #endregion

        #region �� uce_ColSizeAutoSetting_CheckedChanged
        /// <summary>
        /// uce_ColSizeAutoSetting_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uce_ColSizeAutoSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (!this._isEventAutoFillColumn) return;

            this._isEventAutoFillColumn = false;

            try
            {
                if (this.uce_ColSizeAutoSetting.Checked)
                {
                    // �񕝂��I�[�g�ɐݒ�
                    this.uGrid_InventInput.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                }
                else
                {
                    this.uGrid_InventInput.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                    // �J�����T�C�Y����
                    this.InitialInventInputGrid_Width(this.uGrid_InventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput]);
                    //this.ColumnPerformAutoResize();
                }
            }
            finally
            {
                this._isEventAutoFillColumn = true;
            }
        }
        #endregion �� uce_ColSizeAutoSetting_CheckedChanged

        #region �� tce_FontSize_ValueChanged
        /// <summary>
        /// tce_FontSize_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tce_FontSize_ValueChanged(object sender, EventArgs e)
        {
            // �����T�C�Y��ύX
            this.uGrid_InventInput.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tce_FontSize.Value;
        }
        #endregion �� tce_FontSize_ValueChanged

        #region �� utb_InventDataToolBar_ToolClick
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// utb_InventDataToolBar_ToolClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utb_InventDataToolBar_ToolClick(object sender, ToolClickEventArgs e)
        {
            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

            switch (e.Tool.Key)
            {
                // �\�����j���[
                case ct_tool_Hidden_Warehouse:	// �q��
                case ct_tool_Hidden_WarehouseShelfNo:   // �I��
                case ct_tool_Hidden_DuplicationShelfNo1:// �d���I��1
                case ct_tool_Hidden_DuplicationShelfNo2:// �d���I��2
                case ct_tool_Hidden_Maker:	// ���[�J�[
                case ct_tool_Hidden_Supplier:	// �d����
                case ct_tool_Hidden_StockTrtEntDiv:	// �݌ɋ敪

                    // ��ݒ�i�\���^��\���j�̍X�V
                    bool hidden = !(((StateButtonTool)e.Tool).Checked);
                    UpdGridColumnSetting(e.Tool.Key, hidden, 0);
                    break;
                case ct_tool_Hidden_Initialize:	// �����\�����
                    // �q��
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Warehouse]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Warehouse, true, 0);
                    // �I��
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_WarehouseShelfNo]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_WarehouseShelfNo, true, 0);
                    // �d���I��1
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo1]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo1, true, 0);
                    // �d���I��2
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo2]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo2, true, 0);
                    // ���[�J�[
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Maker]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Maker, true, 0);
                    // �d����
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Supplier]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Supplier, true, 0);
                    // �݌ɋ敪
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_StockTrtEntDiv]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_StockTrtEntDiv, true, 0);
                    break;
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// utb_InventDataToolBar_ToolClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utb_InventDataToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.uGrid_InventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);

            switch (e.Tool.Key)
            {
                // �\�����j���[
                // ------------------------------------------------------------------------------------- //
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //case ct_tool_Hidden_TEL1          :	// TEL1
                //case ct_tool_Hidden_TEL2			:	// TEL2
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                case ct_tool_Hidden_Warehouse:	// �q��
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                case ct_tool_Hidden_WarehouseShelfNo:   // �I��
                case ct_tool_Hidden_DuplicationShelfNo1:// �d���I��1
                case ct_tool_Hidden_DuplicationShelfNo2:// �d���I��2
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                case ct_tool_Hidden_Maker:	// ���[�J�[
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //case ct_tool_Hidden_CarrierEp     :	// ���Ǝ�
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                case ct_tool_Hidden_Customer:	// �d����
                case ct_tool_Hidden_ShipCustomer:	// �ϑ���
                case ct_tool_Hidden_StockTrtEntDiv:	// �݌ɋ敪

                    // ��ݒ�i�\���^��\���j�̍X�V
                    bool hidden = !(((Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool).Checked);
                    UpdGridColumnSetting(e.Tool.Key, hidden, 0);
                    break;
                case ct_tool_Hidden_Initialize:	// �����\�����
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //// TEL1
                    //( (Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_TEL1]).Checked = false;
                    //UpdGridColumnSetting( ct_tool_Hidden_TEL1, true, 0 );
                    //// TEL2
                    //( (Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_TEL2]).Checked = false;
                    //UpdGridColumnSetting( ct_tool_Hidden_TEL2, true, 0 );
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    // �q��
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Warehouse]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Warehouse, true, 0);
                    // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                    // �I��
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_WarehouseShelfNo]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_WarehouseShelfNo, true, 0);
                    // �d���I��1
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo1]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo1, true, 0);
                    // �d���I��2
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo2]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo2, true, 0);
                    // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
                    // ���[�J�[
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Maker]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Maker, true, 0);
                    // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                    //// ���Ǝ�
                    //( (Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_CarrierEp]).Checked = false;
                    //UpdGridColumnSetting( ct_tool_Hidden_CarrierEp, true, 0 );
                    // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                    // �d����
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Customer]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Customer, true, 0);
                    // �ϑ���
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_ShipCustomer]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_ShipCustomer, true, 0);
                    // �݌ɋ敪
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_StockTrtEntDiv]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_StockTrtEntDiv, true, 0);
                    break;
#if false
				case "tool_lb_InventoryDay":
				    if ( this.uGrid_InventInput.ActiveRow != null )
				    {
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_Status].Value = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StatusDetail].Value = "���łɓo�^����Ă��܂�";
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StkTelNo1ChgFlg].Value = 1;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StkTelNo2ChgFlg].Value = 1;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StkUnitPriceChgFlg].Value = 1;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_MoveStockCount].Value = 5;
				    }
					break;
#endif
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion

        #region �� ub_RowDelete_Click
        /// <summary>
        /// ub_RowDelete_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �s�폜�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂�</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.07.24</br>
        /// </remarks>
        private void ub_RowDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //this.uGrid_InventInput.BeginUpdate();
            //    DialogResult dialogRes = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�s�폜", "�I���s���폜���܂����H", 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);

            //    if (dialogRes == DialogResult.No)
            //        return;

            //    DataRow targetRow = null;
            //    int activeRowIndex = 0;
            //    if (this.uGrid_InventInput.ActiveRow == null)
            //        return;
            //    else
            //    {
            //        targetRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;
            //        activeRowIndex = this.uGrid_InventInput.ActiveRow.Index;
            //    }

            //    // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //this.RowDeleteProc(targetRow, activeRowIndex);
            //    this.RowDeleteProc(targetRow, activeRowIndex, 0);
            //    // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
            //}
            //finally
            //{
            //    //this.uGrid_InventInput.EndUpdate();
            //}

            ArrayList deleteIndex = new ArrayList();

            if ((this.uGrid_InventInput.Selected.Rows != null) && (this.uGrid_InventInput.Selected.Rows.Count > 0))
            {
                for (int index = 0; index < this.uGrid_InventInput.Selected.Rows.Count; index++)
                {
                    deleteIndex.Add(this.uGrid_InventInput.Selected.Rows[index].Index);
                }
            }
            else
            {
                if ((this.uGrid_InventInput.ActiveCell == null) && (this.uGrid_InventInput.ActiveRow == null))
                {
                    return;
                }

                if (this.uGrid_InventInput.ActiveCell != null)
                {
                    deleteIndex.Add(this.uGrid_InventInput.ActiveCell.Row.Index);
                }
                else
                {
                    deleteIndex.Add(this.uGrid_InventInput.ActiveRow.Index);
                }
            }

            foreach (int rowIndex in deleteIndex)
            {
                int deleteDiv = (Int32)this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_DeleteDiv].Value;

                if (deleteDiv == 0)
                {
                    this.uGrid_InventInput.Rows[rowIndex].Appearance.BackColor = Color.Pink;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_DeleteDiv].Value = 1;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_ChangeDiv].Value = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_UpdateDiv].Value = 0;
                }
                else
                {
                    this.uGrid_InventInput.Rows[rowIndex].Appearance.BackColor = Color.Empty;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_DeleteDiv].Value = 0;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_ChangeDiv].Value = (int)InventInputSearchCndtn.ChangeFlagState.NotChange;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_UpdateDiv].Value = 1;
                }
                this.uGrid_InventInput.UpdateData();
            }
        }
        #endregion
		#endregion �� Control Event
	}
}

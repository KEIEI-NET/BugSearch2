using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// �I���֘A�ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summa ry>
	/// <remarks>
    /// <br>Note       : �I���֘A�ꗗ�\���o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : 23010�@�����@�m</br>
	/// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.14 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.02.13 980035 ���� ��`</br>
    /// <br>			 �E�I�����{���Ή��iDC.NS�Ή��j</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.10.14</br>
    /// <br>Update Note: 2009/12/07 ���M</br>
    /// <br>			 �s��Ή�(PM.NS�ێ�˗��B�Ή�)</br>
    /// <br>Update Note: 2010/02/20 ������</br>
    /// <br>			 �s��Ή�(PM1005)</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    ///	<br>			 �Ǘ��ԍ� 11000606-00 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
    /// </remarks>
	public class MAZAI02114EA
	{
		#region Public Members
		/// <summary>�f�[�^�Z�b�g��</summary>
        public const string InventoryListDataSet = "InventoryListDataSet";
		/// <summary>�f�[�^�e�[�u����</summary>
        public const string InventoryListDataTable = "InventoryListDataTable";
        /// <summary>�I���֘A�ꗗ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string InventoryListCommonBuffDataTable = "InventoryListCommonBuffDataTable";

        #region �I���֘A�ꗗ�\�J�������

        // 2008.10.14 30413 ���� �I���֘A�ꗗ�\�J��������S�X�V >>>>>>START
        ///// <summary>���_�R�[�h</summary>
        //public const string ctCol_SectionCode = "SectionCode";
        ///// <summary>���_�K�C�h����</summary>
        //public const string ctCol_SectionGuideNm = "SectionGuideNm";
        ///// <summary>�I���ʔ�</summary>
        //public const string ctCol_InventorySeqNo = "InventorySeqNo";
        ///// <summary>���[�J�[�R�[�h</summary>
        //public const string ctCol_MakerCode = "MakerCode";
        ///// <summary>���[�J�[����</summary>
        //public const string ctCol_MakerName = "MakerName";
        ///// <summary>���i�R�[�h</summary>
        //public const string ctCol_GoodsCode = "GoodsCode";
        ///// <summary>���i����</summary>
        //public const string ctCol_GoodsName = "GoodsName";
        //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�@��R�[�h</summary>
        ////public const string ctCol_CellphoneModelCode = "CellphoneModelCode";
        /////// <summary>�@�햼��</summary>
        ////public const string ctCol_CellphoneModelName = "CellphoneModelName";
        /////// <summary>�L�����A�R�[�h</summary>
        ////public const string ctCol_CarrierCode = "CarrierCode";
        /////// <summary>�L�����A����</summary>
        ////public const string ctCol_CarrierName = "CarrierName";
        /////// <summary>�n���F�R�[�h</summary>
        ////public const string ctCol_SystematicColorCd = "SystematicColorCd";
        /////// <summary>�n���F����</summary>
        ////public const string ctCol_SystematicColorNm = "SystematicColorNm";
        //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i�敪�O���[�v�R�[�h</summary>
        //public const string ctCol_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary>���i�敪�O���[�v����</summary>
        //public const string ctCol_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary>���i�敪�R�[�h</summary>
        //public const string ctCol_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary>���i�敪����</summary>
        //public const string ctCol_MediumGoodsGanreName = "MediumGoodsGanreName";
        //// 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���i�敪�ڍ׃R�[�h</summary>
        //public const string ctCol_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary>���i�敪�ڍז���</summary>
        //public const string ctCol_DetailGoodsGanreName = "DetailGoodsGanreName";
        ///// <summary>�a�k���i�R�[�h</summary>
        //public const string ctCol_BLGoodsCode = "BLGoodsCode";
        ///// <summary>�a�k���i����</summary>
        //public const string ctCol_BLGoodsName = "BLGoodsName";
        ///// <summary>���Е��ރR�[�h</summary>
        //public const string ctCol_EnterpriseGanreCode = "EnterpriseGanreCode";
        ///// <summary>���Е��ޖ���</summary>
        //public const string ctCol_EnterpriseGanreName = "EnterpriseGanreName";
        ///// <summary>�I��</summary>
        //public const string ctCol_WarehouseShelfNo = "WarehouseShelfNo";
        ///// <summary>�d���I��1</summary>
        //public const string ctCol_DuplicationShelfNo1 = "DuplicationShelfNo1";
        ///// <summary>�d���I��2</summary>
        //public const string ctCol_DuplicationShelfNo2 = "DuplicationShelfNo2";
        //// 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>JAN�R�[�h</summary>
        //public const string ctCol_Jan = "Jan";
        ///// <summary>�d���P��</summary>
        //public const string ctCol_StockUnitPrice = "StockUnitPrice";
        ///// <summary>�ύX�O�d���P��</summary>
        //public const string ctCol_BfStockUnitPrice = "BfStockUnitPrice";
        ///// <summary>�d���P���ύX�t���O</summary>
        //public const string ctCol_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
        //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�݌Ɉϑ�����敪</summary>
        ////public const string ctCol_StockTrtEntDiv = "StockTrtEntDiv";
        //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�I���݌ɐ�</summary>
        //public const string ctCol_InventoryStkCnt = "InventoryStkCnt";
        ///// <summary>�I���ߕs����</summary>
        //public const string ctCol_InventoryTolerancCnt = "InventoryTolerancCnt";
        ///// <summary>�I�������������t</summary>
        //public const string ctCol_InventoryPreprDay = "InventoryPreprDay";
        ///// <summary>�I�����{��</summary>
        //public const string ctCol_InventoryDay = "InventoryDay";
        ///// <summary>�I���X�V��</summary>
        //public const string ctCol_InventoryUpDate = "InventoryUpDate";
        ///// <summary>�I���V�K�ǉ��敪</summary>
        //public const string ctCol_InventoryNewDiv = "InventoryNewDiv";
        //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>���ԊǗ��敪</summary>
        ////public const string ctCol_PrdNumMngDiv = "PrdNumMngDiv";
        //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>�ŏI�d���N����</summary>
        //public const string ctCol_LastStockDate = "LastStockDate";
        ///// <summary>�݌ɐ�</summary>
        //public const string ctCol_StockCnt = "StockCnt";
        //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���{�����됔</summary>
        //public const string ctCol_StockTotalExec = "StockTotalExec";
        ///// <summary>�I����</summary>
        //public const string ctCol_InventoryDate = "InventoryDate";
        //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���ԍ݌Ƀ}�X�^GUID</summary>
        //public const string ctCol_ProductStockGuid = "ProductStockGuid";
        ///// <summary>�q�ɃR�[�h</summary>
        //public const string ctCol_WarehouseCode = "WarehouseCode";
        ///// <summary>�q�ɖ���</summary>
        //public const string ctCol_WarehouseName = "WarehouseName";
        //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>���Ǝ҃R�[�h</summary>
        ////public const string ctCol_CarrierEpCode = "CarrierEpCode";
        /////// <summary>���ƎҖ���</summary>
        ////public const string ctCol_CarrierEpName = "CarrierEpName";
        /////// <summary>�d����</summary>
        ////public const string ctCol_StockDate = "StockDate";
        /////// <summary>���ד�</summary>
        ////public const string ctCol_ArrivalGoodsDay = "ArrivalGoodsDay";
        /////// <summary>�����ԍ�</summary>
        ////public const string ctCol_ProductNumber = "ProductNumber";
        /////// <summary>���i�d�b�ԍ�1</summary>
        ////public const string ctCol_StockTelNo1 = "StockTelNo1";
        /////// <summary>�ύX�O���i�d�b�ԍ�1</summary>
        ////public const string ctCol_BfStockTelNo1 = "BfStockTelNo1";
        /////// <summary>���i�d�b�ԍ�1�ύX�t���O</summary>
        ////public const string ctCol_StkTelNo1ChgFlg = "StkTelNo1ChgFlg";
        /////// <summary>���i�d�b�ԍ�2</summary>
        ////public const string ctCol_StockTelNo2 = "StockTelNo2";
        /////// <summary>�ύX�O���i�d�b�ԍ�2</summary>
        ////public const string ctCol_BfStockTelNo2 = "BfStockTelNo2";
        /////// <summary>���i�d�b�ԍ�2�ύX�t���O</summary>
        ////public const string ctCol_StkTelNo2ChgFlg = "StkTelNo2ChgFlg";
        //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���חp���_����</summary>
        //public const string ctCol_SectionName_Detail = "SectionName_Detail";
        ///// <summary>���Ӑ�R�[�h(�d����)</summary>
        //public const string ctCol_CustomerCode = "CustomerCode";
        ///// <summary>���Ӑ於��(�d����)</summary>
        //public const string ctCol_CustomerName = "CustomerName";
        ///// <summary>���Ӑ於�̂Q(�d����)</summary>
        //public const string ctCol_CustomerName2 = "CustomerName2";
        ///// <summary>�o�א擾�Ӑ�R�[�h(�ϑ���)</summary>
        //public const string ctCol_ShipCustomerCode = "ShipCustomerCode";
        ///// <summary>�o�א擾�Ӑ於��(�ϑ���)</summary>
        //public const string ctCol_ShipCustomerName = "ShipCustomerName";
        ///// <summary>�o�א擾�Ӑ於�̂Q(�ϑ���)</summary>
        //public const string ctCol_ShipCustomerName2 = "ShipCustomerName2";
        ///// <summary>���ً��z</summary>
        //public const string ctCol_TolerancPrice = "TolerancPrice";
        ///// <summary>�݌ɋ��z(��)</summary>
        //public const string ctCol_StockPrice = "StockPrice";

        
        /// <summary> ���_�R�[�h </summary>
        public const string ctCol_SectionCode = "SectionCode";
        /// <summary> ���_�K�C�h���� </summary>
        public const string ctCol_SectionGuideNm = "SectionGuideNm";
        /// <summary> �I���ʔ� </summary>
        public const string ctCol_InventorySeqNo = "InventorySeqNo";
        /// <summary> �q�ɃR�[�h </summary>
        public const string ctCol_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ��� </summary>
        public const string ctCol_WarehouseName = "WarehouseName";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ctCol_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ctCol_MakerName = "MakerName";
        /// <summary> ���i�ԍ� </summary>
        public const string ctCol_GoodsNo = "GoodsNo";
        /// <summary> ���i���� </summary>
        public const string ctCol_GoodsName = "GoodsName";
        /// <summary> �q�ɒI�� </summary>
        public const string ctCol_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> �d���I��1 </summary>
        public const string ctCol_DuplicationShelfNo1 = "DuplicationShelfNo1";
        /// <summary> �d���I��2 </summary>
        public const string ctCol_DuplicationShelfNo2 = "DuplicationShelfNo2";
        /// <summary> ���i�啪�ރR�[�h </summary>
        public const string ctCol_GoodsLGroup = "GoodsLGroup";
        /// <summary> ���i�啪�ރR�[�h���� </summary>
        public const string ctCol_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> ���i�����ރR�[�h </summary>
        public const string ctCol_GoodsMGroup = "GoodsMGroup";
        /// <summary> ���i�����ރR�[�h���� </summary>
        public const string ctCol_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string ctCol_BLGroupCode = "BLGroupCode";
        /// <summary> BL�O���[�v�R�[�h���� </summary>
        public const string ctCol_BLGroupName = "BLGroupName";
        /// <summary> ���Е��ރR�[�h </summary>
        public const string ctCol_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary> ���Е��ޖ��� </summary>
        public const string ctCol_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary> �a�k���i�R�[�h </summary>
        public const string ctCol_BLGoodsCode = "BLGoodsCode";
        /// <summary> �a�k���i�R�[�h�}�� </summary>
        public const string ctCol_BLGoodsCdDerivedNo = "BLGoodsCdDerivedNo";
        /// <summary> �a�k���i���� </summary>
        public const string ctCol_BLGoodsName = "BLGoodsName";
        /// <summary> �d����R�[�h </summary>
        public const string ctCol_SupplierCd = "SupplierCd";
        /// <summary> �i�`�m�R�[�h </summary>
        public const string ctCol_Jan = "Jan";
        /// <summary> �d���P�� </summary>
        public const string ctCol_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �ύX�O�d���P�� </summary>
        public const string ctCol_BfStockUnitPriceFl = "BfStockUnitPriceFl";
        /// <summary> �d���P���ύX�t���O </summary>
        public const string ctCol_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
        /// <summary> �݌ɋ敪 </summary>
        public const string ctCol_StockDiv = "StockDiv";
        /// <summary> �ŏI�d���N���� </summary>
        public const string ctCol_LastStockDate = "LastStockDate";
        /// <summary> �݌ɑ��� </summary>
        public const string ctCol_StockTotal = "StockTotal";
        /// <summary> �o�א擾�Ӑ�R�[�h </summary>
        public const string ctCol_ShipCustomerCode = "ShipCustomerCode";
        /// <summary> �o�א擾�Ӑ於�� </summary>
        public const string ctCol_ShipCustomerName = "ShipCustomerName";
        /// <summary> �o�ד��Ӑ於��2 </summary>
        public const string ctCol_ShipCustomerName2 = "ShipCustomerName2";
        /// <summary> �I���݌ɐ� </summary>
        public const string ctCol_InventoryStockCnt = "InventoryStockCnt";
        /// <summary> �I���ߕs���� </summary>
        public const string ctCol_InventoryTolerancCnt = "InventoryTolerancCnt";
        /// <summary> �I�������������t </summary>
        public const string ctCol_InventoryPreprDay = "InventoryPreprDay";
        /// <summary> �I�������������� </summary>
        public const string ctCol_InventoryPreprTim = "InventoryPreprTim";
        /// <summary> �I�����{�� </summary>
        public const string ctCol_InventoryDay = "InventoryDay";
        /// <summary> �ŏI�I���X�V�� </summary>
        public const string ctCol_LastInventoryUpdate = "LastInventoryUpdate";
        /// <summary> �I���V�K�ǉ��敪 </summary>
        public const string ctCol_InventoryNewDiv = "InventoryNewDiv";
        /// <summary> �}�V���݌Ɋz </summary>
        public const string ctCol_StockMashinePrice = "StockMashinePrice";
        /// <summary> �I���݌Ɋz </summary>
        public const string ctCol_InventoryStockPrice = "InventoryStockPrice";
        /// <summary> �I���ߕs�����z </summary>
        public const string ctCol_InventoryTlrncPrice = "InventoryTlrncPrice";
        /// <summary> �艿�i�����j </summary>
        public const string ctCol_ListPriceFl = "ListPriceFl";
        /// <summary> �I���� </summary>
        public const string ctCol_InventoryDate = "InventoryDate";
        /// <summary> �݌ɑ����i���{���j </summary>
        public const string ctCol_StockTotalExec = "StockTotalExec";
        /// <summary> �ߕs���X�V�敪 </summary>
        public const string ctCol_ToleranceUpdateCd = "ToleranceUpdateCd";
        /// <summary> �Z�o�݌ɐ� </summary>
        public const string ctCol_StockAmount = "StockAmount";
        // 2008.10.14 30413 ���� �I���֘A�ꗗ�\�J��������S�X�V <<<<<<END

        /// <summary>�݌ɋ敪(UI)</summary>
        public const string ctCol_UiSotckDiv = "UiSotckDiv";


        //����p�J����
        /// <summary>�q�ɃR�[�h(����p)</summary>
        public const string ctCol_WarehouseCode_Print = "WarehouseCode_Print";
        /// <summary>�d����R�[�h(����p)</summary>
        public const string ctCol_SupplierCd_Print = "SupplierCd_Print";
        /// <summary>BL�R�[�h(����p)</summary>
        public const string ctCol_BLGoodsCode_Print = "BLGoodsCode_Print";
        /// <summary>�O���[�v�R�[�h(����p)</summary>
        public const string ctCol_BLGroupCode_Print = "BLGroupCode_Print";
        /// <summary>���[�J�[�R�[�h(����p)</summary>
        public const string ctCol_MakerCode_Print = "MakerCode_Print";
        // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�L�����A�R�[�h(����p)</summary>
        //public const string ctCol_CarrierCode_Print = "CarrierCode_Print";
        ///// <summary>�n���F�R�[�h(����p)</summary>
        //public const string ctCol_SystematicColorCd_Print = "SystematicColorCd_Print";
        // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>���i�敪�O���[�v�R�[�h(����p)</summary>
        public const string ctCol_LargeGoodsGanreCode_Print = "LargeGoodsGanreCode_Print";
        /// <summary>���i�敪�R�[�h(����p)</summary>
        public const string ctCol_MediumGoodsGanreCode_Print = "MediumGoodsGanreCode_Print";
        // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���Ǝ҃R�[�h(����p)</summary>
        //public const string ctCol_CarrierEpCode_Print = "CarrierEpCode_Print";
        // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>�I�������������t</summary>
        public const string ctCol_InventoryPreprDay_Print = "InventoryPreprDay_Print";
        /// <summary>�I�����{��</summary>
        public const string ctCol_InventoryDay_Print = "InventoryDay_Print";
        /// <summary>�I���X�V��</summary>
        public const string ctCol_InventoryUpDate_Print = "InventoryUpDate_Print";
        /// <summary>�ŏI�d���N����</summary>
        public const string ctCol_LastStockDate_Print = "LastStockDate_Print";
        // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�d����</summary>
        //public const string ctCol_StockDate_Print = "StockDate_Print";
        ///// <summary>���ד�</summary>
        //public const string ctCol_ArrivalGoodsDay_Print = "ArrivalGoodsDay_Print";
        // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>�݌ɋ敪</summary>
        public const string ctCol_StockDiv_Print = "StockDiv_Print";
        // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>�I�ԁi�I�ԃu���C�N�p�j</summary>
        public const string ctCol_WarehouseShelfNo_Print = "WarehouseShelfNo_Print";
        // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
        // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        /// <summary>�I����</summary>
        public const string ctCol_InventoryDate_Print = "InventoryDate_Print";
        // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<

        // 2008.11.04 30413 ���� �I�����ٕ\�̍��ُ��v�� >>>>>>START
        /// <summary> �v���X�̍��ِ� </summary>
        public const string ctCol_PlusInventoryTolerancCnt = "PlusInventoryTolerancCnt";
        /// <summary> �}�C�i�X�̍��ِ� </summary>
        public const string ctCol_MinusInventoryTolerancCnt = "MinusInventoryTolerancCnt";
        /// <summary> �v���X�̍��ً��z </summary>
        public const string ctCol_PlusInventoryTlrncPrice = "PlusInventoryTlrncPrice";
        /// <summary> �}�C�i�X�̍��ً��z </summary>
        public const string ctCol_MinusInventoryTlrncPrice = "MinusInventoryTlrncPrice";
        // 2008.11.04 30413 ���� �I�����ٕ\�̍��ُ��v�� <<<<<<END

        /// <summary> �I����(�󎚗p) </summary>
        public const string ctCol_StockCount_Print = "StockCount_Print";
        /// <summary> �W�����i(���i�}�X�^�̒艿)(�󎚗p) </summary>
        public const string ctCol_ListPrice_Print = "ListPrice_Print";
        /// <summary> ���P��(�d���P��)(�󎚗p) </summary>
        public const string ctCol_StockUnitPriceFl_Print = "StockUnitPriceFl_Print";
        /// <summary> �Z�o�I�����z(�󎚗p) </summary>
        public const string ctCol_StockAmountPrice_Print = "StockAmountPrice_Print";

        // -------ADD 2009/12/07------->>>>>
        /// <summary>�I�����A���P���A��������Flag</summary>
        public const string ctCol_BlankShowFlag_Print = "BlankShowFlag_Print";
        // -------ADD 2009/12/07-------<<<<<
        // -------ADD 2010/02/20------->>>>>
        /// <summary>�I������Flag</summary>
        public const string ctCol_InvStockCntFlag_Print = "InvStockCntFlag_Print";
        // -------ADD 2010/02/20-------<<<<<
        // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
        /// <summary>�I���݌ɐ��e�L�X�g�p</summary>
        public const string ctCol_InventoryStockCntTextOut = "InventoryStockCntTextOut";
        /// <summary>�W�����i�e�L�X�g�p</summary>
        public const string ctCol_ListPriceTextOut = "ListPriceTextOut";
        // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

		#endregion

		#endregion

		#region Constructor
		/// <summary>
        /// �I���֘A�ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �I���֘A�ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		public MAZAI02114EA()
		{
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.10</br>
        /// <br>Update Note: 2007.09.14 980035 ���� ��`</br>
        /// <br>			 �EDC.NS�Ή�</br>
        /// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(InventoryListDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[InventoryListDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 0);
			}

            // �݌Ɏԗ����o�ɊǗ��\���o���ʃo�b�t�@�f�[�^�e�[�u��------------------------------------------
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(InventoryListCommonBuffDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[InventoryListCommonBuffDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 1);
			}
		}
		
		
		/// <summary>
        /// �I���֘A�ꗗ�\���o���ʍ쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.10</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
		/// </remarks>
        private static void CreateRestListCommonTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// �X�L�[�}�ݒ�
                ds.Tables.Add(InventoryListDataTable);
                dt = ds.Tables[InventoryListDataTable];
			}
			else
			{
				// �X�L�[�}�ݒ�
                ds.Tables.Add(InventoryListCommonBuffDataTable);
                dt = ds.Tables[InventoryListCommonBuffDataTable];
            }

            // 2008.10.14 30413 ���� �I���֘A�ꗗ�\�J��������S�X�V >>>>>>START

            string defValuestring = "";
            Int32 defValueInt32 = 0;
            Int64 defValueInt64 = 0;
            double defValueDouble = 0.0;

            //// ���_�R�[�h
            //dt.Columns.Add(ctCol_SectionCode,typeof(string));
            //dt.Columns[ctCol_SectionCode].DefaultValue = "";
            //// ���_�K�C�h����
            //dt.Columns.Add(ctCol_SectionGuideNm,typeof(string));
            //dt.Columns[ctCol_SectionGuideNm].DefaultValue = "";
            //// �I���ʔ�
            //dt.Columns.Add(ctCol_InventorySeqNo,typeof(Int32));
            //dt.Columns[ctCol_InventorySeqNo].DefaultValue = 0;                       
            //// ���[�J�[�R�[�h
            //dt.Columns.Add(ctCol_MakerCode,typeof(Int32));
            //dt.Columns[ctCol_MakerCode].DefaultValue = 0;
            //// ���[�J�[����
            //dt.Columns.Add(ctCol_MakerName,typeof(string));
            //dt.Columns[ctCol_MakerName].DefaultValue = "";
            //// ���i�R�[�h
            //dt.Columns.Add(ctCol_GoodsCode,typeof(string));
            //dt.Columns[ctCol_GoodsCode].DefaultValue = "";
            //// ���i����
            //dt.Columns.Add(ctCol_GoodsName,typeof(string));
            //dt.Columns[ctCol_GoodsName].DefaultValue = "";
            //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// �@��R�[�h
            ////dt.Columns.Add(ctCol_CellphoneModelCode,typeof(string));
            ////dt.Columns[ctCol_CellphoneModelCode].DefaultValue = "";
            ////// �@�햼��
            ////dt.Columns.Add(ctCol_CellphoneModelName,typeof(string));
            ////dt.Columns[ctCol_CellphoneModelName].DefaultValue = "";
            ////// �L�����A�R�[�h
            ////dt.Columns.Add(ctCol_CarrierCode,typeof(Int32));
            ////dt.Columns[ctCol_CarrierCode].DefaultValue = 0;
            ////// �L�����A����
            ////dt.Columns.Add(ctCol_CarrierName,typeof(string));
            ////dt.Columns[ctCol_CarrierName].DefaultValue = "";
            ////// �n���F�R�[�h
            ////dt.Columns.Add(ctCol_SystematicColorCd,typeof(Int32));
            ////dt.Columns[ctCol_SystematicColorCd].DefaultValue = 0;
            ////// �n���F����
            ////dt.Columns.Add(ctCol_SystematicColorNm,typeof(string));
            ////dt.Columns[ctCol_SystematicColorNm].DefaultValue = "";
            //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            //// ���i�敪�O���[�v�R�[�h
            //dt.Columns.Add(ctCol_LargeGoodsGanreCode,typeof(string));
            //dt.Columns[ctCol_LargeGoodsGanreCode].DefaultValue = "";
            //// ���i�敪�O���[�v����
            //dt.Columns.Add(ctCol_LargeGoodsGanreName,typeof(string));
            //dt.Columns[ctCol_LargeGoodsGanreName].DefaultValue = "";
            //// ���i�敪�R�[�h
            //dt.Columns.Add(ctCol_MediumGoodsGanreCode,typeof(string));
            //dt.Columns[ctCol_MediumGoodsGanreCode].DefaultValue = "";
            //// ���i�敪����
            //dt.Columns.Add(ctCol_MediumGoodsGanreName,typeof(string));
            //dt.Columns[ctCol_MediumGoodsGanreName].DefaultValue = "";
            //// 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���i�敪�ڍ׃R�[�h
            //dt.Columns.Add(ctCol_DetailGoodsGanreCode,typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreCode].DefaultValue = "";
            //// ���i�敪�ڍז���
            //dt.Columns.Add(ctCol_DetailGoodsGanreName,typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreName].DefaultValue = "";
            //// �a�k���i�R�[�h
            //dt.Columns.Add(ctCol_BLGoodsCode,typeof(Int32));
            //dt.Columns[ctCol_BLGoodsCode].DefaultValue = 0;
            //// �a�k���i����
            //dt.Columns.Add(ctCol_BLGoodsName,typeof(string));
            //dt.Columns[ctCol_BLGoodsName].DefaultValue = "";
            //// ���Е��ރR�[�h
            //dt.Columns.Add(ctCol_EnterpriseGanreCode,typeof(Int32));
            //dt.Columns[ctCol_EnterpriseGanreCode].DefaultValue = 0;
            //// ���Е��ޖ���
            //dt.Columns.Add(ctCol_EnterpriseGanreName,typeof(string));
            //dt.Columns[ctCol_EnterpriseGanreName].DefaultValue = "";
            //// �I��
            //dt.Columns.Add(ctCol_WarehouseShelfNo,typeof(string));
            //dt.Columns[ctCol_WarehouseShelfNo].DefaultValue = "";
            //// �d���I��1
            //dt.Columns.Add(ctCol_DuplicationShelfNo1, typeof(string));
            //dt.Columns[ctCol_DuplicationShelfNo1].DefaultValue = "";
            //// �d���I��2
            //dt.Columns.Add(ctCol_DuplicationShelfNo2, typeof(string));
            //dt.Columns[ctCol_DuplicationShelfNo2].DefaultValue = "";
            //// 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //// JAN�R�[�h
            //dt.Columns.Add(ctCol_Jan,typeof(string));
            //dt.Columns[ctCol_Jan].DefaultValue = "";
            //// �d���P��
            //dt.Columns.Add(ctCol_StockUnitPrice,typeof(Int64));
            //dt.Columns[ctCol_StockUnitPrice].DefaultValue = 0L;
            //// �ύX�O�d���P��
            //dt.Columns.Add(ctCol_BfStockUnitPrice,typeof(Int64));
            //dt.Columns[ctCol_BfStockUnitPrice].DefaultValue = 0L;
            //// �d���P���ύX�t���O
            //dt.Columns.Add(ctCol_StkUnitPriceChgFlg,typeof(Int32));
            //dt.Columns[ctCol_StkUnitPriceChgFlg].DefaultValue = 0;
            //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// �݌Ɉϑ�����敪
            ////dt.Columns.Add(ctCol_StockTrtEntDiv,typeof(Int32));
            ////dt.Columns[ctCol_StockTrtEntDiv].DefaultValue = 0;
            //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            //// �I���݌ɐ�
            //dt.Columns.Add(ctCol_InventoryStkCnt,typeof(Double));
            //dt.Columns[ctCol_InventoryStkCnt].DefaultValue = 0D;
            //// �I���ߕs����
            //dt.Columns.Add(ctCol_InventoryTolerancCnt,typeof(Double));
            //dt.Columns[ctCol_InventoryTolerancCnt].DefaultValue = 0D;
            //// �I�������������t
            //dt.Columns.Add(ctCol_InventoryPreprDay,typeof(Int32));
            //dt.Columns[ctCol_InventoryPreprDay].DefaultValue = 0;
            //// �I�����{��
            //dt.Columns.Add(ctCol_InventoryDay,typeof(Int32));
            //dt.Columns[ctCol_InventoryDay].DefaultValue = 0;
            //// �I���X�V��
            //dt.Columns.Add(ctCol_InventoryUpDate,typeof(Int32));
            //dt.Columns[ctCol_InventoryUpDate].DefaultValue = 0;
            //// �I���V�K�ǉ��敪
            //dt.Columns.Add(ctCol_InventoryNewDiv,typeof(Int32));
            //dt.Columns[ctCol_InventoryNewDiv].DefaultValue = 0;
            //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// ���ԊǗ��敪
            ////dt.Columns.Add(ctCol_PrdNumMngDiv,typeof(Int32));
            ////dt.Columns[ctCol_PrdNumMngDiv].DefaultValue = 0;
            //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            //// �ŏI�d���N����
            //dt.Columns.Add(ctCol_LastStockDate,typeof(Int32));
            //dt.Columns[ctCol_LastStockDate].DefaultValue = 0;
            //// �݌ɐ�
            //dt.Columns.Add(ctCol_StockCnt,typeof(Double));
            //dt.Columns[ctCol_StockCnt].DefaultValue = 0D;
            //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���{�����됔
            //dt.Columns.Add(ctCol_StockTotalExec, typeof(Double));
            //dt.Columns[ctCol_StockTotalExec].DefaultValue = 0D;
            //// �I����
            //dt.Columns.Add(ctCol_InventoryDate, typeof(Int32));
            //dt.Columns[ctCol_InventoryDate].DefaultValue = 0;
            //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            //// ���ԍ݌Ƀ}�X�^GUID
            //dt.Columns.Add(ctCol_ProductStockGuid,typeof(Guid));
            //dt.Columns[ctCol_ProductStockGuid].DefaultValue = Guid.Empty;
            //// �q�ɃR�[�h
            //dt.Columns.Add(ctCol_WarehouseCode,typeof(string));
            //dt.Columns[ctCol_WarehouseCode].DefaultValue = "";
            //// �q�ɖ���
            //dt.Columns.Add(ctCol_WarehouseName,typeof(string));
            //dt.Columns[ctCol_WarehouseName].DefaultValue = "";
            //// 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////// ���Ǝ҃R�[�h
            ////dt.Columns.Add(ctCol_CarrierEpCode,typeof(Int32));
            ////dt.Columns[ctCol_CarrierEpCode].DefaultValue = 0;
            ////// ���ƎҖ���
            ////dt.Columns.Add(ctCol_CarrierEpName,typeof(string));
            ////dt.Columns[ctCol_CarrierEpName].DefaultValue = "";
            ////// �d����
            ////dt.Columns.Add(ctCol_StockDate,typeof(Int32));
            ////dt.Columns[ctCol_StockDate].DefaultValue = 0;
            ////// ���ד�
            ////dt.Columns.Add(ctCol_ArrivalGoodsDay,typeof(Int32));
            ////dt.Columns[ctCol_ArrivalGoodsDay].DefaultValue = 0;
            ////// �����ԍ�
            ////dt.Columns.Add(ctCol_ProductNumber,typeof(string));
            ////dt.Columns[ctCol_ProductNumber].DefaultValue = "";
            ////// ���i�d�b�ԍ�1
            ////dt.Columns.Add(ctCol_StockTelNo1,typeof(string));
            ////dt.Columns[ctCol_StockTelNo1].DefaultValue = "";
            ////// �ύX�O���i�d�b�ԍ�1
            ////dt.Columns.Add(ctCol_BfStockTelNo1,typeof(string));
            ////dt.Columns[ctCol_BfStockTelNo1].DefaultValue = "";
            ////// ���i�d�b�ԍ�1�ύX�t���O
            ////dt.Columns.Add(ctCol_StkTelNo1ChgFlg,typeof(Int32));
            ////dt.Columns[ctCol_StkTelNo1ChgFlg].DefaultValue = 0;
            ////// ���i�d�b�ԍ�2
            ////dt.Columns.Add(ctCol_StockTelNo2,typeof(string));
            ////dt.Columns[ctCol_StockTelNo2].DefaultValue = "";
            ////// �ύX�O���i�d�b�ԍ�2
            ////dt.Columns.Add(ctCol_BfStockTelNo2,typeof(string));
            ////dt.Columns[ctCol_BfStockTelNo2].DefaultValue = "";
            ////// ���i�d�b�ԍ�2�ύX�t���O
            ////dt.Columns.Add(ctCol_StkTelNo2ChgFlg,typeof(Int32));
            ////dt.Columns[ctCol_StkTelNo2ChgFlg].DefaultValue = 0;
            //// 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            //// ���Ӑ�R�[�h(�d����)
            //dt.Columns.Add(ctCol_CustomerCode,typeof(Int32));
            //dt.Columns[ctCol_CustomerCode].DefaultValue = 0;
            //// ���Ӑ於��(�d����)
            //dt.Columns.Add(ctCol_CustomerName,typeof(string));
            //dt.Columns[ctCol_CustomerName].DefaultValue = "";
            //// ���Ӑ於�̂Q(�d����)
            //dt.Columns.Add(ctCol_CustomerName2,typeof(string));
            //dt.Columns[ctCol_CustomerName2].DefaultValue = "";
            //// �o�א擾�Ӑ�R�[�h(�ϑ���)
            //dt.Columns.Add(ctCol_ShipCustomerCode,typeof(Int32));
            //dt.Columns[ctCol_ShipCustomerCode].DefaultValue = 0;
            //// �o�א擾�Ӑ於��(�ϑ���)
            //dt.Columns.Add(ctCol_ShipCustomerName,typeof(string));
            //dt.Columns[ctCol_ShipCustomerName].DefaultValue = "";
            //// �o�א擾�Ӑ於�̂Q(�ϑ���)
            //dt.Columns.Add(ctCol_ShipCustomerName2,typeof(string));
            //dt.Columns[ctCol_ShipCustomerName2].DefaultValue = "";
            //// ���ً��z
            //dt.Columns.Add(ctCol_TolerancPrice,typeof(Int64));
            //dt.Columns[ctCol_TolerancPrice].DefaultValue = 0L;
            //// �݌ɋ��z(��)
            //dt.Columns.Add(ctCol_StockPrice,typeof(Int64));
            //dt.Columns[ctCol_StockPrice].DefaultValue = 0L;

            // ���_�R�[�h
            dt.Columns.Add(ctCol_SectionCode, typeof(string));
            dt.Columns[ctCol_SectionCode].DefaultValue = defValuestring;
            // ���_�K�C�h����
            dt.Columns.Add(ctCol_SectionGuideNm, typeof(string));
            dt.Columns[ctCol_SectionGuideNm].DefaultValue = defValuestring;
            // �I���ʔ�
            dt.Columns.Add(ctCol_InventorySeqNo, typeof(Int32));
            dt.Columns[ctCol_InventorySeqNo].DefaultValue = defValueInt32;
            // �q�ɃR�[�h
            dt.Columns.Add(ctCol_WarehouseCode, typeof(string));
            dt.Columns[ctCol_WarehouseCode].DefaultValue = defValuestring;
            // �q�ɖ���
            dt.Columns.Add(ctCol_WarehouseName, typeof(string));
            dt.Columns[ctCol_WarehouseName].DefaultValue = defValuestring;
            // ���i���[�J�[�R�[�h
            dt.Columns.Add(ctCol_GoodsMakerCd, typeof(Int32));
            dt.Columns[ctCol_GoodsMakerCd].DefaultValue = defValueInt32;
            // ���[�J�[����
            dt.Columns.Add(ctCol_MakerName, typeof(string));
            dt.Columns[ctCol_MakerName].DefaultValue = defValuestring;
            // ���i�ԍ�
            dt.Columns.Add(ctCol_GoodsNo, typeof(string));
            dt.Columns[ctCol_GoodsNo].DefaultValue = defValuestring;
            // ���i����
            dt.Columns.Add(ctCol_GoodsName, typeof(string));
            dt.Columns[ctCol_GoodsName].DefaultValue = defValuestring;
            // �q�ɒI��
            dt.Columns.Add(ctCol_WarehouseShelfNo, typeof(string));
            dt.Columns[ctCol_WarehouseShelfNo].DefaultValue = defValuestring;
            // �d���I��1
            dt.Columns.Add(ctCol_DuplicationShelfNo1, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo1].DefaultValue = defValuestring;
            // �d���I��2
            dt.Columns.Add(ctCol_DuplicationShelfNo2, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo2].DefaultValue = defValuestring;
            // ���i�啪�ރR�[�h
            dt.Columns.Add(ctCol_GoodsLGroup, typeof(Int32));
            dt.Columns[ctCol_GoodsLGroup].DefaultValue = defValueInt32;
            // ���i�啪�ރR�[�h����
            dt.Columns.Add(ctCol_GoodsLGroupName, typeof(string));
            dt.Columns[ctCol_GoodsLGroupName].DefaultValue = defValuestring;
            // ���i�����ރR�[�h
            dt.Columns.Add(ctCol_GoodsMGroup, typeof(Int32));
            dt.Columns[ctCol_GoodsMGroup].DefaultValue = defValueInt32;
            // ���i�����ރR�[�h����
            dt.Columns.Add(ctCol_GoodsMGroupName, typeof(string));
            dt.Columns[ctCol_GoodsMGroupName].DefaultValue = defValuestring;
            // BL�O���[�v�R�[�h
            dt.Columns.Add(ctCol_BLGroupCode, typeof(Int32));
            dt.Columns[ctCol_BLGroupCode].DefaultValue = defValueInt32;
            // BL�O���[�v�R�[�h����
            dt.Columns.Add(ctCol_BLGroupName, typeof(string));
            dt.Columns[ctCol_BLGroupName].DefaultValue = defValuestring;
            // ���Е��ރR�[�h
            dt.Columns.Add(ctCol_EnterpriseGanreCode, typeof(Int32));
            dt.Columns[ctCol_EnterpriseGanreCode].DefaultValue = defValueInt32;
            // ���Е��ޖ���
            dt.Columns.Add(ctCol_EnterpriseGanreName, typeof(string));
            dt.Columns[ctCol_EnterpriseGanreName].DefaultValue = defValuestring;
            // �a�k���i�R�[�h
            dt.Columns.Add(ctCol_BLGoodsCode, typeof(Int32));
            dt.Columns[ctCol_BLGoodsCode].DefaultValue = defValueInt32;
            // �a�k���i�R�[�h�}��
            dt.Columns.Add(ctCol_BLGoodsCdDerivedNo, typeof(Int32));
            dt.Columns[ctCol_BLGoodsCdDerivedNo].DefaultValue = defValueInt32;
            // �a�k���i����
            dt.Columns.Add(ctCol_BLGoodsName, typeof(string));
            dt.Columns[ctCol_BLGoodsName].DefaultValue = defValuestring;
            // �d����R�[�h
            dt.Columns.Add(ctCol_SupplierCd, typeof(Int32));
            dt.Columns[ctCol_SupplierCd].DefaultValue = defValueInt32;
            // �i�`�m�R�[�h
            dt.Columns.Add(ctCol_Jan, typeof(string));
            dt.Columns[ctCol_Jan].DefaultValue = defValuestring;
            // �d���P��
            dt.Columns.Add(ctCol_StockUnitPriceFl, typeof(Double));
            dt.Columns[ctCol_StockUnitPriceFl].DefaultValue = defValueDouble;
            // �ύX�O�d���P��
            dt.Columns.Add(ctCol_BfStockUnitPriceFl, typeof(Double));
            dt.Columns[ctCol_BfStockUnitPriceFl].DefaultValue = defValueDouble;
            // �d���P���ύX�t���O
            dt.Columns.Add(ctCol_StkUnitPriceChgFlg, typeof(Int32));
            dt.Columns[ctCol_StkUnitPriceChgFlg].DefaultValue = defValueInt32;
            // �݌ɋ敪
            dt.Columns.Add(ctCol_StockDiv, typeof(Int32));
            dt.Columns[ctCol_StockDiv].DefaultValue = defValueInt32;
            // �ŏI�d���N����
            dt.Columns.Add(ctCol_LastStockDate, typeof(Int32));
            dt.Columns[ctCol_LastStockDate].DefaultValue = defValueInt32;
            // �݌ɑ���
            dt.Columns.Add(ctCol_StockTotal, typeof(Double));
            dt.Columns[ctCol_StockTotal].DefaultValue = defValueDouble;
            // �o�א擾�Ӑ�R�[�h
            dt.Columns.Add(ctCol_ShipCustomerCode, typeof(Int32));
            dt.Columns[ctCol_ShipCustomerCode].DefaultValue = defValueInt32;
            // �o�א擾�Ӑ於��
            dt.Columns.Add(ctCol_ShipCustomerName, typeof(string));
            dt.Columns[ctCol_ShipCustomerName].DefaultValue = defValuestring;
            // �o�ד��Ӑ於��2
            dt.Columns.Add(ctCol_ShipCustomerName2, typeof(string));
            dt.Columns[ctCol_ShipCustomerName2].DefaultValue = defValuestring;
            // �I���݌ɐ�
            dt.Columns.Add(ctCol_InventoryStockCnt, typeof(Double));
            dt.Columns[ctCol_InventoryStockCnt].DefaultValue = defValueDouble;
            // �I���ߕs����
            dt.Columns.Add(ctCol_InventoryTolerancCnt, typeof(Double));
            dt.Columns[ctCol_InventoryTolerancCnt].DefaultValue = defValueDouble;
            // �I�������������t
            dt.Columns.Add(ctCol_InventoryPreprDay, typeof(Int32));
            dt.Columns[ctCol_InventoryPreprDay].DefaultValue = defValueInt32;
            // �I��������������
            dt.Columns.Add(ctCol_InventoryPreprTim, typeof(Int32));
            dt.Columns[ctCol_InventoryPreprTim].DefaultValue = defValueInt32;
            // �I�����{��
            dt.Columns.Add(ctCol_InventoryDay, typeof(Int32));
            dt.Columns[ctCol_InventoryDay].DefaultValue = defValueInt32;
            // �ŏI�I���X�V��
            dt.Columns.Add(ctCol_LastInventoryUpdate, typeof(Int32));
            dt.Columns[ctCol_LastInventoryUpdate].DefaultValue = defValueInt32;
            // �I���V�K�ǉ��敪
            dt.Columns.Add(ctCol_InventoryNewDiv, typeof(Int32));
            dt.Columns[ctCol_InventoryNewDiv].DefaultValue = defValueInt32;
            // �}�V���݌Ɋz
            dt.Columns.Add(ctCol_StockMashinePrice, typeof(Int64));
            dt.Columns[ctCol_StockMashinePrice].DefaultValue = defValueInt64;
            // �I���݌Ɋz
            dt.Columns.Add(ctCol_InventoryStockPrice, typeof(Int64));
            dt.Columns[ctCol_InventoryStockPrice].DefaultValue = defValueInt64;
            // �I���ߕs�����z
            dt.Columns.Add(ctCol_InventoryTlrncPrice, typeof(Int64));
            dt.Columns[ctCol_InventoryTlrncPrice].DefaultValue = defValueInt64;
            // �艿�i�����j
            dt.Columns.Add(ctCol_ListPriceFl, typeof(Double));
            dt.Columns[ctCol_ListPriceFl].DefaultValue = defValueDouble;
            // �I����
            dt.Columns.Add(ctCol_InventoryDate, typeof(Int32));
            dt.Columns[ctCol_InventoryDate].DefaultValue = defValueInt32;
            // �݌ɑ����i���{���j
            dt.Columns.Add(ctCol_StockTotalExec, typeof(Double));
            dt.Columns[ctCol_StockTotalExec].DefaultValue = defValueDouble;
            // �ߕs���X�V�敪
            dt.Columns.Add(ctCol_ToleranceUpdateCd, typeof(Int32));
            dt.Columns[ctCol_ToleranceUpdateCd].DefaultValue = defValueInt32;
            // �Z�o�݌ɐ�
            dt.Columns.Add(ctCol_StockAmount, typeof(Double));
            dt.Columns[ctCol_StockAmount].DefaultValue = defValueDouble;
            // 2008.10.14 30413 ���� �I���֘A�ꗗ�\�J��������S�X�V <<<<<<END


            // �݌ɋ敪UI(�\�[�g�p)
            dt.Columns.Add(ctCol_UiSotckDiv,typeof(Int32));
            dt.Columns[ctCol_UiSotckDiv].DefaultValue = 0;          

            //// ���_����(���חp)
            //dt.Columns.Add(ctCol_SectionName_Detail,typeof(string));
            //dt.Columns[ctCol_SectionName_Detail].DefaultValue = "";
            // �q�ɃR�[�h(����p)
            dt.Columns.Add(ctCol_WarehouseCode_Print,typeof(string));
            dt.Columns[ctCol_WarehouseCode_Print].DefaultValue = "";
            // �d����R�[�h(����p)
            dt.Columns.Add(ctCol_SupplierCd_Print, typeof(string));
            dt.Columns[ctCol_SupplierCd_Print].DefaultValue = "";
            // BL�R�[�h(����p)
            dt.Columns.Add(ctCol_BLGoodsCode_Print, typeof(string));
            dt.Columns[ctCol_BLGoodsCode_Print].DefaultValue = "";
            // �O���[�v�R�[�h(����p)
            dt.Columns.Add(ctCol_BLGroupCode_Print, typeof(string));
            dt.Columns[ctCol_BLGroupCode_Print].DefaultValue = "";
            //���[�J�[�R�[�h(����p)
            dt.Columns.Add(ctCol_MakerCode_Print,typeof(string));
            dt.Columns[ctCol_MakerCode_Print].DefaultValue = "";
            // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�R�[�h(����p)
            //dt.Columns.Add(ctCol_CarrierCode_Print,typeof(string));
            //dt.Columns[ctCol_CarrierCode_Print].DefaultValue = "";
            ////���Ǝ҃R�[�h(����p)
            //dt.Columns.Add(ctCol_CarrierEpCode_Print,typeof(string));
            //dt.Columns[ctCol_CarrierEpCode_Print].DefaultValue = "";
            ////�n���F�R�[�h(����p)
            //dt.Columns.Add(ctCol_SystematicColorCd_Print,typeof(string));
            //dt.Columns[ctCol_SystematicColorCd_Print].DefaultValue = "";
            // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            //���i�敪�O���[�v�R�[�h(����p)
            dt.Columns.Add(ctCol_LargeGoodsGanreCode_Print,typeof(string));
            dt.Columns[ctCol_LargeGoodsGanreCode_Print].DefaultValue = "";
            //���i�敪�R�[�h(����p)
            dt.Columns.Add(ctCol_MediumGoodsGanreCode_Print,typeof(string));
            dt.Columns[ctCol_MediumGoodsGanreCode_Print].DefaultValue = "";
            // �I�������������t
            dt.Columns.Add(ctCol_InventoryPreprDay_Print,typeof(string));
            dt.Columns[ctCol_InventoryPreprDay_Print].DefaultValue = "";
            // �I�����{��
            dt.Columns.Add(ctCol_InventoryDay_Print,typeof(string));
            dt.Columns[ctCol_InventoryDay_Print].DefaultValue = "";
            // �I���X�V��
            dt.Columns.Add(ctCol_InventoryUpDate_Print,typeof(string));
            dt.Columns[ctCol_InventoryUpDate_Print].DefaultValue = "";
            // �ŏI�d���N����
            dt.Columns.Add(ctCol_LastStockDate_Print,typeof(string));
            dt.Columns[ctCol_LastStockDate_Print].DefaultValue = "";
            // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �d����
            //dt.Columns.Add(ctCol_StockDate_Print,typeof(string));
            //dt.Columns[ctCol_StockDate_Print].DefaultValue = "";
            //// ���ד�
            //dt.Columns.Add(ctCol_ArrivalGoodsDay_Print,typeof(string));
            //dt.Columns[ctCol_ArrivalGoodsDay_Print].DefaultValue = "";
            // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            // �݌ɋ敪
�@          dt.Columns.Add(ctCol_StockDiv_Print,typeof(string));
            dt.Columns[ctCol_StockDiv_Print].DefaultValue = "";
            // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I�ԁi�I�ԃu���C�N�p�j
            dt.Columns.Add(ctCol_WarehouseShelfNo_Print, typeof(string));
            dt.Columns[ctCol_WarehouseShelfNo_Print].DefaultValue = "";
            // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            // �I����
            dt.Columns.Add(ctCol_InventoryDate_Print, typeof(string));
            dt.Columns[ctCol_InventoryDate_Print].DefaultValue = "";
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.11.04 30413 ���� �I�����ٕ\�̍��ُ��v�� >>>>>>START
            // �v���X�̍��ِ�
            dt.Columns.Add(ctCol_PlusInventoryTolerancCnt, typeof(Double));
            dt.Columns[ctCol_PlusInventoryTolerancCnt].DefaultValue = defValueDouble;
            // �}�C�i�X�̍��ِ�
            dt.Columns.Add(ctCol_MinusInventoryTolerancCnt, typeof(Double));
            dt.Columns[ctCol_MinusInventoryTolerancCnt].DefaultValue = defValueDouble;
            // �v���X�̍��ً��z
            dt.Columns.Add(ctCol_PlusInventoryTlrncPrice, typeof(Int64));
            dt.Columns[ctCol_PlusInventoryTlrncPrice].DefaultValue = defValueInt64;
            // �}�C�i�X�̍��ً��z
            dt.Columns.Add(ctCol_MinusInventoryTlrncPrice, typeof(Int64));
            dt.Columns[ctCol_MinusInventoryTlrncPrice].DefaultValue = defValueInt64;
            // 2008.11.04 30413 ���� �I�����ٕ\�̍��ُ��v�� <<<<<<END

            // �I����(�󎚗p)
            dt.Columns.Add(ctCol_StockCount_Print, typeof(string));
            dt.Columns[ctCol_StockCount_Print].DefaultValue = defValuestring;
            // �W�����i(���i�}�X�^�̒艿)(�󎚗p)
            dt.Columns.Add(ctCol_ListPrice_Print, typeof(string));
            dt.Columns[ctCol_ListPrice_Print].DefaultValue = defValuestring;
            // ���P��(�d���P��)(�󎚗p)
            dt.Columns.Add(ctCol_StockUnitPriceFl_Print, typeof(string));
            dt.Columns[ctCol_StockUnitPriceFl_Print].DefaultValue = defValuestring;
            // �Z�o�I�����z
            dt.Columns.Add(ctCol_StockAmountPrice_Print, typeof(string));
            dt.Columns[ctCol_StockAmountPrice_Print].DefaultValue = defValuestring;
            // -------ADD 2009/12/07------->>>>>
            // �I�����A���P���A��������Flag
            dt.Columns.Add(ctCol_BlankShowFlag_Print, typeof(int));
            dt.Columns[ctCol_BlankShowFlag_Print].DefaultValue = defValueInt32;
            // -------ADD 2009/12/07-------<<<<<
            // -------ADD 2010/02/20------->>>>>
            // �I������Flag
            dt.Columns.Add(ctCol_InvStockCntFlag_Print, typeof(int));
            dt.Columns[ctCol_InvStockCntFlag_Print].DefaultValue = defValueInt32;
            // -------ADD 2010/02/20-------<<<<<

            // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
            // �I���݌ɐ��e�L�X�g�p
            dt.Columns.Add(ctCol_InventoryStockCntTextOut, typeof(Double));
            dt.Columns[ctCol_InventoryStockCntTextOut].DefaultValue = defValueDouble;
            // �W�����i�e�L�X�g�p
            dt.Columns.Add(ctCol_ListPriceTextOut, typeof(Double));
            dt.Columns[ctCol_ListPriceTextOut].DefaultValue = defValueDouble;
            // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<

        }

		#endregion
	}
}
//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I������
// �v���O�����T�v   : �I������UI���o���ʃN���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2007/04/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/02/14  �C�����e : �I�����{���Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/09/01  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/14  �C�����e : �s��Ή�[13260]�@No���ڒǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �C �� ��  2009/09/11  �C�����e : �s��Ή�[13914]�@�L�[�ɒI�Ԃ�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �C �� ��  2011/01/30  �C�����e : ��Q�� #18764
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00    �쐬�S�� : yangyi
// �C �� ��  2013/03/01     �C�����e : 20130326�z�M���̑Ή��ARedmine#34175
//                                     �I���Ɩ��̃T�[�o�[���׌y��
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// public class name:   InventInputResult
	/// <summary>
	/// �I��������UI���o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �I��������UI���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/4/2</br>
	/// <br>Genarated Date   :   2007/04/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008.02.14 980035 ���� ��`</br>
    /// <br>			         �E�I�����{���Ή��iDC.NS�Ή��j</br>
    /// <br>Update Note      :   2008/09/01 30414 �E �K�j</br>
    /// <br>			         �EPartsman�p�ɕύX</br>
    /// <br>                 :   2009/05/14 �Ɠc �M�u�@�s��Ή�[13260]</br>
    /// <br>UpdateNote       :   2011/01/30 ���N�n�� </br>
    /// <br>                     ��Q�� #18764</br>
    /// </remarks>
	public class InventInputResult
    {
        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region �� Public Const
		/// <summary>�e�[�u������</summary>
		public const string ct_Tbl_InventInput = "Tbl_InventInput";

		/// <summary>�쐬����</summary>
		public const string ct_Col_CreateDateTime = "CreateDateTime";
		/// <summary>�X�V����</summary>
		public const string ct_Col_UpdateDateTime = "UpdateDateTime";
		/// <summary>��ƃR�[�h</summary>
		public const string ct_Col_EnterpriseCode = "EnterpriseCode";
		/// <summary>GUID</summary>
		public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
		/// <summary>�X�V�A�Z���u��ID1</summary>
		public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
		/// <summary>�X�V�A�Z���u��ID2</summary>
		public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
		/// <summary>�_���폜�敪</summary>
		public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
		/// <summary>���_�R�[�h</summary>
		public const string ct_Col_SectionCode = "SectionCode";
		/// <summary>���_�K�C�h����</summary>
		public const string ct_Col_SectionGuideNm = "SectionGuideNm";
		/// <summary>�I���ʔ�</summary>
		public const string ct_Col_InventorySeqNo = "InventorySeqNo";
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���ԍ݌Ƀ}�X�^GUID</summary>
		//public const string ct_Col_ProductStockGuid = "ProductStockGuid";
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>�q�ɃR�[�h</summary>
		public const string ct_Col_WarehouseCode = "WarehouseCode";
		/// <summary>�q�ɖ���</summary>
		public const string ct_Col_WarehouseName = "WarehouseName";
		/// <summary>���[�J�[�R�[�h</summary>
		public const string ct_Col_MakerCode = "MakerCode";
		/// <summary>���[�J�[����</summary>
		public const string ct_Col_MakerName = "MakerName";
		/// <summary>�i��</summary>
        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //public const string ct_Col_GoodsCode = "GoodsCode";
        public const string ct_Col_GoodsNo = "GoodsNo";
        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary>�i��</summary>
		public const string ct_Col_GoodsName = "GoodsName";
        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�@��R�[�h</summary>
		//public const string ct_Col_CellphoneModelCode = "CellphoneModelCode";
		///// <summary>�@�햼��</summary>
		//public const string ct_Col_CellphoneModelName = "CellphoneModelName";
        ///// <summary>�L�����A�R�[�h</summary>
        //public const string ct_Col_CarrierCode = "CarrierCode";
        ///// <summary>�L�����A����</summary>
        //public const string ct_Col_CarrierName = "CarrierName";
        ///// <summary>�n���F�R�[�h</summary>
        //public const string ct_Col_SystematicColorCd = "SystematicColorCd";
        ///// <summary>�n���F����</summary>
        //public const string ct_Col_SystematicColorNm = "SystematicColorNm";
        /// <summary>�q�ɒI��</summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>�d���I��1</summary>
        public const string ct_Col_DuplicationShelfNo1 = "DuplicationShelfNo1";
        /// <summary>�d���I��2</summary>
        public const string ct_Col_DuplicationShelfNo2 = "DuplicationShelfNo2";
        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary>���i�啪�ރR�[�h</summary>
		public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
		/// <summary>���i�啪�ޖ���</summary>
		public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName";
		/// <summary>���i�����ރR�[�h</summary>
		public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
		/// <summary>���i�����ޖ���</summary>
		public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName";
        // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���Ǝ҃R�[�h</summary>
		//public const string ct_Col_CarrierEpCode = "CarrierEpCode";
		///// <summary>���ƎҖ���</summary>
		//public const string ct_Col_CarrierEpName = "CarrierEpName";
        /// <summary>�O���[�v�R�[�h</summary>
        public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        /// <summary>�O���[�v�R�[�h����</summary>
        public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName";
        /// <summary>���Е��ރR�[�h</summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary>���Е��ޖ���</summary>
        public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary>�a�k�i��</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>�a�k�i��</summary>
        public const string ct_Col_BLGoodsName = "BLGoodsName";
        // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary>���Ӑ�R�[�h</summary>
		public const string ct_Col_CustomerCode = "CustomerCode";
		/// <summary>���Ӑ於��</summary>
		public const string ct_Col_CustomerName = "CustomerName";
		/// <summary>���Ӑ於��2</summary>
		public const string ct_Col_CustomerName2 = "CustomerName2";
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�d����</summary>
        //public const string ct_Col_StockDate = "StockDate";
        ///// <summary>���ד�</summary>
        //public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";
        ///// <summary>�����ԍ�</summary>
        //public const string ct_Col_ProductNumber = "ProductNumber";
        ///// <summary>���i�d�b�ԍ�1</summary>
        //public const string ct_Col_StockTelNo1 = "StockTelNo1";
        ///// <summary>�ύX�O���i�d�b�ԍ�1</summary>
        //public const string ct_Col_BfStockTelNo1 = "BfStockTelNo1";
        ///// <summary>���i�d�b�ԍ�1�ύX�t���O</summary>
        //public const string ct_Col_StkTelNo1ChgFlg = "StkTelNo1ChgFlg";
        ///// <summary>���i�d�b�ԍ�2</summary>
        //public const string ct_Col_StockTelNo2 = "StockTelNo2";
		///// <summary>�ύX�O���i�d�b�ԍ�2</summary>
		//public const string ct_Col_BfStockTelNo2 = "BfStockTelNo2";
		///// <summary>���i�d�b�ԍ�2�ύX�t���O</summary>
		//public const string ct_Col_StkTelNo2ChgFlg = "StkTelNo2ChgFlg";
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>JAN�R�[�h</summary>
		public const string ct_Col_Jan = "Jan";
		/// <summary>�d���P��</summary>
		public const string ct_Col_StockUnitPrice = "StockUnitPrice";
		/// <summary>�ύX�O�d���P��</summary>
		public const string ct_Col_BfStockUnitPrice = "BfStockUnitPrice";
		/// <summary>�d���P���ύX�t���O</summary>
		public const string ct_Col_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
		/// <summary>�݌ɋ敪</summary>
		public const string ct_Col_StockDiv = "StockDiv";
        // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�݌ɏ��</summary>
		//public const string ct_Col_StockState = "StockState";
		///// <summary>�ړ����</summary>
		//public const string ct_Col_MoveStatus = "MoveStatus";
		///// <summary>���i���</summary>
		//public const string ct_Col_GoodsCodeStatus = "GoodsCodeStatus";
		///// <summary>���ԊǗ��敪</summary>
		//public const string ct_Col_PrdNumMngDiv = "PrdNumMngDiv";
        // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
        /// <summary>�ŏI�d���N����</summary>
		public const string ct_Col_LastStockDate = "LastStockDate";
		/// <summary>����݌ɐ�</summary>
		public const string ct_Col_StockTotal = "StockTotal";
		/// <summary>�o�א擾�Ӑ�R�[�h</summary>
		public const string ct_Col_ShipCustomerCode = "ShipCustomerCode";
		/// <summary>�o�א擾�Ӑ於��</summary>
		public const string ct_Col_ShipCustomerName = "ShipCustomerName";
		/// <summary>�o�א擾�Ӑ於��2</summary>
		public const string ct_Col_ShipCustomerName2 = "ShipCustomerName2";
		/// <summary>�I���݌ɐ�</summary>
		public const string ct_Col_InventoryStockCnt = "InventoryStockCnt";
		/// <summary>���ِ�</summary>
		public const string ct_Col_InventoryTolerancCnt = "InventoryTolerancCnt";
		/// <summary>�ύX�O���ِ�</summary>
		public const string ct_Col_BfChgInventoryToleCnt = "BfChgInventoryToleCnt";
        // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>�I����(int)</summary>
        public const string ct_Col_InventoryExeDay = "InventoryExeDay";
        /// <summary>�I����(DateTime)</summary>
        public const string ct_Col_InventoryExeDay_Datetime = "InventoryExeDay_Datetime";
        /// <summary>�I����(String)</summary>
        public const string ct_Col_InventoryExeDay_Str = "InventoryExeDay_Str";
        // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
		/// <summary>�I�������������t(int)</summary>
		public const string ct_Col_InventoryPreprDay = "InventoryPreprDay";
		/// <summary>�I�������������t(Datetime)</summary>
		public const string ct_Col_InventoryPreprDay_Datetime = "InventoryPreprDay_Datetime";
		/// <summary>�I�������������t(�N ����)</summary>
		public const string ct_Col_InventoryPreprDay_Year = "InventoryPreprDay_Year";
		/// <summary>�I�������������t(�N ���x��)</summary>
		public const string ct_Col_InventoryPreprDay_YearL = "InventoryPreprDay_YearL";
		/// <summary>�I�������������t(�� ����)</summary>
		public const string ct_Col_InventoryPreprDay_Month = "InventoryPreprDay_Month";
		/// <summary>�I�������������t(�� ���x��)</summary>
		public const string ct_Col_InventoryPreprDay_MonthL = "InventoryPreprDay_MonthL";
		/// <summary>�I�������������t(�� ����)</summary>
		public const string ct_Col_InventoryPreprDay_Day = "InventoryPreprDay_Day";
		/// <summary>�I�������������t(�� ���x��)</summary>
		public const string ct_Col_InventoryPreprDay_DayL = "InventoryPreprDay_DayL";
		/// <summary>�I��������������</summary>
		public const string ct_Col_InventoryPreprTim = "InventoryPreprTim";
		/// <summary>�I�����{��(int)</summary>
		public const string ct_Col_InventoryDay = "InventoryDay";
		/// <summary>�I�����{��(Datetime)</summary>
		public const string ct_Col_InventoryDay_Datetime = "InventoryDay_Datetime";
		/// <summary>�I�����{��(�N ����)</summary>
		public const string ct_Col_InventoryDay_Year = "InventoryDay_Year";
		/// <summary>�I�����{��(�N ���x��)</summary>
		public const string ct_Col_InventoryDay_YearL = "InventoryDay_YearL";
		/// <summary>�I�����{��(�� ����)</summary>
		public const string ct_Col_InventoryDay_Month = "InventoryDay_Month";
		/// <summary>�I�����{��(�� ���x��)</summary>
		public const string ct_Col_InventoryDay_MonthL = "InventoryDay_MonthL";
		/// <summary>�I�����{��(�� ����)</summary>
		public const string ct_Col_InventoryDay_Day = "InventoryDay_Day";
		/// <summary>�I�����{��(�� ���x��)</summary>
		public const string ct_Col_InventoryDay_DayL = "InventoryDay_DayL";
		/// <summary>�ŏI�I���X�V��</summary>
		public const string ct_Col_LastInventoryUpdate = "LastInventoryUpdate";
		/// <summary>�I���V�K�ǉ��敪</summary>
		public const string ct_Col_InventoryNewDiv = "InventoryNewDiv";
		/// <summary>�I���V�K�ǉ��敪����</summary>
		public const string ct_Col_InventoryNewDivName = "InventoryNewDivName";
        // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>�}�V���݌Ɋz</summary>
        public const string ct_Col_StockMashinePrice = "StockMashinePrice";
        /// <summary>�I���݌Ɋz</summary>
        public const string ct_Col_InventoryStockPrice = "InventoryStockPrice";
        /// <summary>�I���ߕs�����z</summary>
        public const string ct_Col_InventoryTlrncPrice = "InventoryTlrncPrice";
        // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

		/// <summary>�݌Ɉϑ�����敪</summary>
		public const string ct_Col_StockTrtEntDiv = "StockTrtEntDiv";
		/// <summary>�݌Ɉϑ�����敪����</summary>
		public const string ct_Col_StockTrtEntDivName = "StockTrtEntDivName";
		/// <summary>�W�v�敪</summary>
		public const string ct_Col_GrossDiv = "GrossDiv";
		/// <summary>�\���敪</summary>
		public const string ct_Col_ViewDiv = "ViewDiv";
		/// <summary>�X�V�Ώۋ敪</summary>
		public const string ct_Col_UpdateDiv = "UpdateDiv";
		/// <summary>�{�^���p�J����</summary>
		public const string ct_Col_Button = "Button";
		/// <summary>���s</summary>
		public const string ct_Col_RowSelf = "RowSelf";
		/// <summary>key</summary>
		public const string ct_Col_key = "key";
		/// <summary>�ړ��݌ɐ�</summary>
		public const string ct_Col_MoveStockCount = "MoveStockCount";
		/// <summary>Status</summary>
		public const string ct_Col_Status = "Status";
		/// <summary>Status���e</summary>
		public const string ct_Col_StatusDetail = "StatusDetail";
		/// <summary>�ύX�敪(0:�X�V�Ώ�, 1~:�X�V�ΏۊO)</summary>
		public const string ct_Col_ChangeDiv = "ChangeDiv";

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        ///// <summary>Status���e</summary>
        //public const string ct_Col_StatusDetail = "StatusDetail";
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		// 2007.07.31 kubo add
		/// <summary>�\�[�g�p�����ԍ�</summary>
		public const string ct_Col_SortProductNumber = "SortProductNumber";

		#endregion �� Public Const
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #region �� Public Const
        /// <summary>�e�[�u������</summary>
        public const string ct_Tbl_InventInput = "Tbl_InventInput";

        /// <summary>�쐬����</summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary>�X�V����</summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary>��ƃR�[�h</summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary>�X�V�A�Z���u��ID1</summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary>�X�V�A�Z���u��ID2</summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary>�_���폜�敪</summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary>���_�R�[�h</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>�I���ʔ�</summary>
        public const string ct_Col_InventorySeqNo = "InventorySeqNo";
        /// <summary>�q�ɃR�[�h</summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary>�q�ɖ���</summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary>���[�J�[�R�[�h</summary>
        public const string ct_Col_MakerCode = "MakerCode";
        /// <summary>���[�J�[����</summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary>�i��</summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary>�i��</summary>
        public const string ct_Col_GoodsName = "GoodsName";
        //---ADD 2011/01/30-------------------------------->>>>>
        /// <summary>�艿</summary>
        public const string ct_Col_ListPrice = "ListPrice";
        //---ADD 2011/01/30--------------------------------<<<<<
        /// <summary>�q�ɒI��</summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>�d���I��1</summary>
        public const string ct_Col_DuplicationShelfNo1 = "DuplicationShelfNo1";
        /// <summary>�d���I��2</summary>
        public const string ct_Col_DuplicationShelfNo2 = "DuplicationShelfNo2";
        /// <summary>���i�啪�ރR�[�h</summary>
        public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        /// <summary>�O���[�v�R�[�h</summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary>�O���[�v�R�[�h����</summary>
        public const string ct_Col_BLGroupName = "BLGroupName";
        /// <summary>���Е��ރR�[�h</summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary>�a�k�i��</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>�a�k�i��</summary>
        public const string ct_Col_BLGoodsName = "BLGoodsName";
        /// <summary>�d����R�[�h</summary>
        public const string ct_Col_SupplierCode = "SupplierCode";
        /// <summary>�d���於��</summary>
        public const string ct_Col_SupplierName = "SupplierName";
        /// <summary>�d���於��2</summary>
        public const string ct_Col_SupplierName2 = "SupplierName2";
        /// <summary>JAN�R�[�h</summary>
        public const string ct_Col_Jan = "Jan";
        /// <summary>�d���P��</summary>
        public const string ct_Col_StockUnitPrice = "StockUnitPrice";
        /// <summary>�ύX�O�d���P��</summary>
        public const string ct_Col_BfStockUnitPrice = "BfStockUnitPrice";
        /// <summary>�d���P���ύX�t���O</summary>
        public const string ct_Col_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
        /// <summary>�݌ɋ敪</summary>
        public const string ct_Col_StockDiv = "StockDiv";
        /// <summary>�ŏI�d���N����</summary>
        public const string ct_Col_LastStockDate = "LastStockDate";
        /// <summary>����݌ɐ�</summary>
        public const string ct_Col_StockTotal = "StockTotal";
        /// <summary>�o�א擾�Ӑ�R�[�h</summary>
        public const string ct_Col_ShipCustomerCode = "ShipCustomerCode";
        /// <summary>�I���݌ɐ�</summary>
        public const string ct_Col_InventoryStockCnt = "InventoryStockCnt";
        /// <summary>���ِ�</summary>
        public const string ct_Col_InventoryTolerancCnt = "InventoryTolerancCnt";
        /// <summary>�ύX�O���ِ�</summary>
        public const string ct_Col_BfChgInventoryToleCnt = "BfChgInventoryToleCnt";
        /// <summary>�I����(DateTime)</summary>
        public const string ct_Col_InventoryExeDay_Datetime = "InventoryExeDay_Datetime";
        /// <summary>�I�������������t(Datetime)</summary>
        public const string ct_Col_InventoryPreprDay_Datetime = "InventoryPreprDay_Datetime";
        /// <summary>�I��������������</summary>
        public const string ct_Col_InventoryPreprTim = "InventoryPreprTim";
        /// <summary>�I�����{��(int)</summary>
        public const string ct_Col_InventoryDay = "InventoryDay";
        /// <summary>�I�����{��(Datetime)</summary>
        public const string ct_Col_InventoryDay_Datetime = "InventoryDay_Datetime";
        /// <summary>�I�����{��(�N ����)</summary>
        public const string ct_Col_InventoryDay_Year = "InventoryDay_Year";
        /// <summary>�I�����{��(�N ���x��)</summary>
        public const string ct_Col_InventoryDay_YearL = "InventoryDay_YearL";
        /// <summary>�I�����{��(�� ����)</summary>
        public const string ct_Col_InventoryDay_Month = "InventoryDay_Month";
        /// <summary>�I�����{��(�� ���x��)</summary>
        public const string ct_Col_InventoryDay_MonthL = "InventoryDay_MonthL";
        /// <summary>�I�����{��(�� ����)</summary>
        public const string ct_Col_InventoryDay_Day = "InventoryDay_Day";
        /// <summary>�I�����{��(�� ���x��)</summary>
        public const string ct_Col_InventoryDay_DayL = "InventoryDay_DayL";
        /// <summary>�ŏI�I���X�V��</summary>
        public const string ct_Col_LastInventoryUpdate = "LastInventoryUpdate";
        /// <summary>�I���V�K�ǉ��敪</summary>
        public const string ct_Col_InventoryNewDiv = "InventoryNewDiv";
        /// <summary>�I���V�K�ǉ��敪����</summary>
        public const string ct_Col_InventoryNewDivName = "InventoryNewDivName";
        /// <summary>�}�V���݌Ɋz</summary>
        public const string ct_Col_StockMashinePrice = "StockMashinePrice";
        /// <summary>�I���݌Ɋz</summary>
        public const string ct_Col_InventoryStockPrice = "InventoryStockPrice";
        /// <summary>�I���ߕs�����z</summary>
        public const string ct_Col_InventoryTlrncPrice = "InventoryTlrncPrice";
        /// <summary>�݌Ɉϑ�����敪</summary>
        public const string ct_Col_StockTrtEntDiv = "StockTrtEntDiv";
        /// <summary>�݌Ɉϑ�����敪����</summary>
        public const string ct_Col_StockTrtEntDivName = "StockTrtEntDivName";
        /// <summary>�W�v�敪</summary>
        public const string ct_Col_GrossDiv = "GrossDiv";
        /// <summary>�\���敪</summary>
        public const string ct_Col_ViewDiv = "ViewDiv";
        /// <summary>�X�V�Ώۋ敪</summary>
        public const string ct_Col_UpdateDiv = "UpdateDiv";
        /// <summary>�{�^���p�J����</summary>
        public const string ct_Col_Button = "Button";
        /// <summary>���s</summary>
        public const string ct_Col_RowSelf = "RowSelf";
        /// <summary>key</summary>
        public const string ct_Col_key = "key";
        /// <summary>�ړ��݌ɐ�</summary>
        public const string ct_Col_MoveStockCount = "MoveStockCount";
        /// <summary>Status</summary>
        public const string ct_Col_Status = "Status";
        /// <summary>Status���e</summary>
        public const string ct_Col_StatusDetail = "StatusDetail";
        /// <summary>�ύX�敪(0:�X�V�Ώ�, 1~:�X�V�ΏۊO)</summary>
        public const string ct_Col_ChangeDiv = "ChangeDiv";
        /// <summary>�\�[�g�p�����ԍ�</summary>
        public const string ct_Col_SortProductNumber = "SortProductNumber";
        /// <summary>�폜�t���O</summary>
        public const string ct_Col_DeleteDiv = "DeleteDiv";

        // ---ADD 2009/05/14 �s��Ή�[13260] ------------>>>>>
        /// <summary>No</summary>
        public const string ct_Col_No = "No";
        /// <summary>�݌ɑ���(���{��)</summary>
        public const string ct_Col_StockTotalExec = "StockTotalExec";
        /// <summary>�ߕs���X�V�敪</summary>
        public const string ct_Col_ToleranceUpdateCd = "ToleranceUpdateCd";
        /// <summary>�����p�v�Z����</summary>
        public const string ct_Col_AdjustCalcCost = "AdjustCalcCost";
        /// <summary>�I���ߕs����(DB�̒l���̂܂�)</summary>
        public const string ct_Col_InventoryTolerancCntBf = "InventoryTolerancCntBf";
        // ---ADD 2009/05/14 �s��Ή�[13260] ------------<<<<<

        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
		/// �I��������UI���o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>InventInputResult�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   InventInputResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public InventInputResult()
		{
		}
		#endregion

		#region �� Public Method
		#region �� �e�[�u���X�L�[�}��`���\�b�h
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �e�[�u���X�L�[�}��`���\�b�h
		/// </summary>
		/// <param name="dt">DataTable</param>
        /// <br>UpdateNote       :   2011/01/30 ���N�n�� </br>
        /// <br>                     ��Q�� #18764</br>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/06�z�M���ً̋}�Ή�</br>
        /// <br>           : Redmine#34175 �@�I���Ɩ��̃T�[�o�[���׌y���΍�</br>
        static public void CreateDataTable( ref DataTable dt )
		{

			// �e�[�u���C���X�^���X�̃`�F�b�N
			if ( dt != null )
			{
				// �e�[�u���N���A
				dt.Clear();
                dt.PrimaryKey = null;  //ADD yangyi 2013/03/01 Redmine#34175
			}
			else
			{
				dt = new DataTable( ct_Tbl_InventInput );	// �e�[�u���C���X�^���X�쐬
				// ð��ٽ��ϒ�`
				// �쐬����
				dt.Columns.Add( CreateColumn( ct_Col_CreateDateTime, typeof(DateTime), "�쐬����" ) );
				dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
				// �X�V����
				dt.Columns.Add( CreateColumn( ct_Col_UpdateDateTime, typeof(DateTime), "�X�V����" ) );
				dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
				// ��ƃR�[�h
				dt.Columns.Add( CreateColumn( ct_Col_EnterpriseCode, typeof(string), "��ƃR�[�h" ) );
				dt.Columns[ct_Col_EnterpriseCode].DefaultValue = "";
				// GUID
				dt.Columns.Add( CreateColumn( ct_Col_FileHeaderGuid, typeof(Guid), "GUID" ) );
				dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
				// �X�V�]�ƈ��R�[�h
				dt.Columns.Add( CreateColumn( ct_Col_UpdEmployeeCode, typeof(string), "�X�V�]�ƈ��R�[�h" ) );
				dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = "";
				// �X�V�A�Z���u��ID1
				dt.Columns.Add( CreateColumn( ct_Col_UpdAssemblyId1, typeof(string), "�X�V�A�Z���u��ID1" ) );
				dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = "";
				// �X�V�A�Z���u��ID2
				dt.Columns.Add( CreateColumn( ct_Col_UpdAssemblyId2, typeof(string), "�X�V�A�Z���u��ID2" ) );
				dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = "";
				// �_���폜�敪
				dt.Columns.Add( CreateColumn( ct_Col_LogicalDeleteCode, typeof(Int32), "�_���폜�敪" ) );
				dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;
				// �I���ʔ�
				dt.Columns.Add( CreateColumn( ct_Col_InventorySeqNo, typeof(Int32), "�ʔ�" ) );
				dt.Columns[ct_Col_InventorySeqNo].DefaultValue = 0;
				// �q�ɖ���
				dt.Columns.Add( CreateColumn( ct_Col_WarehouseName, typeof(string), "�q�ɖ�" ) );
				dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
				// ���[�J�[����
				dt.Columns.Add( CreateColumn( ct_Col_MakerName, typeof(string), "���[�J�[��" ) );
				dt.Columns[ct_Col_MakerName].DefaultValue = "";
				// �i��
				dt.Columns.Add( CreateColumn( ct_Col_GoodsName, typeof(string), "�i��" ) );
                //---ADD 2011/01/30-------------------------------->>>>>
                // �艿
                dt.Columns.Add(CreateColumn(ct_Col_ListPrice, typeof(Double), "�艿"));
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;
				dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                //---ADD 2011/01/30--------------------------------<<<<<
                // -- DEL 2009/09/11 --------------------------------->>>
                // Primary�쐬���Ɉړ�
                //// �q�ɒI��
                //dt.Columns.Add( CreateColumn( ct_Col_WarehouseShelfNo, typeof(string), "�I��" ) );
                //dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                // -- DEL 2009/09/11 ---------------------------------<<<
                // �d���I��1
				dt.Columns.Add( CreateColumn( ct_Col_DuplicationShelfNo1, typeof(string), "�d���I�ԂP" ) );
				dt.Columns[ct_Col_DuplicationShelfNo1].DefaultValue = "";
                // �d���I��2
				dt.Columns.Add( CreateColumn( ct_Col_DuplicationShelfNo2, typeof(string), "�d���I�ԂQ" ) );
				dt.Columns[ct_Col_DuplicationShelfNo2].DefaultValue = "";
                // ���i�啪�ރR�[�h
                dt.Columns.Add(CreateColumn(ct_Col_LargeGoodsGanreCode, typeof(Int32), "���i�啪�ރR�[�h"));
				dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = 0;
				// ���i�����ރR�[�h
                dt.Columns.Add(CreateColumn(ct_Col_MediumGoodsGanreCode, typeof(Int32), "���i�����ރR�[�h"));
				dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = 0;
                // �O���[�v�R�[�h
                dt.Columns.Add(CreateColumn(ct_Col_BLGroupCode, typeof(Int32), "��ٰ�ߺ���"));
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;
                // �O���[�v�R�[�h����
				dt.Columns.Add( CreateColumn( ct_Col_BLGroupName, typeof(string), "��ٰ�ߺ��ޖ�" ) );
                dt.Columns[ct_Col_BLGroupName].DefaultValue = "";
                // ���Е��ރR�[�h
				dt.Columns.Add( CreateColumn( ct_Col_EnterpriseGanreCode, typeof(Int32), "���Е��ރR�[�h" ) );
				dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = 0;
                // �a�k�i��
				dt.Columns.Add( CreateColumn( ct_Col_BLGoodsCode, typeof(Int32), "BL����" ) );
				dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                // �a�k�i��
				dt.Columns.Add( CreateColumn( ct_Col_BLGoodsName, typeof(string), "BL���ޖ�" ) );
				dt.Columns[ct_Col_BLGoodsName].DefaultValue = "";
				// ���Ӑ於��
                dt.Columns.Add(CreateColumn(ct_Col_SupplierName, typeof(string), "�d���於"));
                dt.Columns[ct_Col_SupplierName].DefaultValue = "";
				// ���Ӑ於��2
                dt.Columns.Add(CreateColumn(ct_Col_SupplierName2, typeof(string), "�d���於2"));
                dt.Columns[ct_Col_SupplierName2].DefaultValue = "";
                // JAN�R�[�h
				dt.Columns.Add( CreateColumn( ct_Col_Jan, typeof(string), "JAN�R�[�h" ) );
				dt.Columns[ct_Col_Jan].DefaultValue = "";
                // �ύX�O�d���P��
                dt.Columns.Add(CreateColumn(ct_Col_BfStockUnitPrice, typeof(Double), "�ύX�O���P��"));
                dt.Columns[ct_Col_BfStockUnitPrice].DefaultValue = 0;
                // �d���P���ύX�t���O
				dt.Columns.Add( CreateColumn( ct_Col_StkUnitPriceChgFlg, typeof(Int32), "���P���ύX�t���O" ) );
				dt.Columns[ct_Col_StkUnitPriceChgFlg].DefaultValue = 0;
                // �ŏI�d���N����
				dt.Columns.Add( CreateColumn( ct_Col_LastStockDate, typeof(DateTime), "�ŏI�d���N����" ) );
				dt.Columns[ct_Col_LastStockDate].DefaultValue = DateTime.MinValue;
				// ����݌ɐ�
				dt.Columns.Add( CreateColumn( ct_Col_StockTotal, typeof(Double), "���됔" ) );
				dt.Columns[ct_Col_StockTotal].DefaultValue = 0;
				// �I���݌ɐ�
				dt.Columns.Add( CreateColumn( ct_Col_InventoryStockCnt, typeof(Double), "�I����" ) );
				dt.Columns[ct_Col_InventoryStockCnt].DefaultValue = 0;
				// ���ِ�
				dt.Columns.Add( CreateColumn( ct_Col_InventoryTolerancCnt, typeof(Double), "�ߕs����" ) );
				dt.Columns[ct_Col_InventoryTolerancCnt].DefaultValue = 0;
				// �ύX�O���ِ�
                dt.Columns.Add(CreateColumn(ct_Col_BfChgInventoryToleCnt, typeof(Double), "�ύX�O�ߕs����"));
				dt.Columns[ct_Col_BfChgInventoryToleCnt].DefaultValue = 0;
                // �I����(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay_Datetime, typeof(DateTime), "�I����"));
                dt.Columns[ct_Col_InventoryExeDay_Datetime].DefaultValue = DateTime.MinValue;
				// �I�������������t(DateTime)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryPreprDay_Datetime, typeof(DateTime), "�I�������������t" ) );
				dt.Columns[ct_Col_InventoryPreprDay_Datetime].DefaultValue = DateTime.MinValue;
				// �I�����{��(int)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay, typeof(Int32), "�I�����{��"));
                dt.Columns[ct_Col_InventoryDay].DefaultValue = 0;
				// �I�����{��(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Datetime, typeof(DateTime), "�I�����{��"));
                dt.Columns[ct_Col_InventoryDay_Datetime].DefaultValue = DateTime.MinValue;
				// �I�����{��(�N ����)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_Year, typeof(Int32), "�N" ) );
				dt.Columns[ct_Col_InventoryDay_Year].DefaultValue = 0;
				// �I�����{��(�N ���x��)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_YearL, typeof(string), "" ) );
				dt.Columns[ct_Col_InventoryDay_YearL].DefaultValue = "�N";
				// �I�����{��(�� ����)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_Month, typeof(Int32), "��" ) );
				dt.Columns[ct_Col_InventoryDay_Month].DefaultValue = 0;
				// �I�����{��(�� ���x��)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_MonthL, typeof(string), "" ) );
				dt.Columns[ct_Col_InventoryDay_MonthL].DefaultValue = "��";
				// �I�����{��(�� ����)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_Day, typeof(Int32), "��" ) );
				dt.Columns[ct_Col_InventoryDay_Day].DefaultValue = 0;
				// �I�����{��(�� ���x��)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_DayL, typeof(string), "" ) );
				dt.Columns[ct_Col_InventoryDay_DayL].DefaultValue = "��";
				// �I��������������
				dt.Columns.Add( CreateColumn( ct_Col_InventoryPreprTim, typeof(Int32), "�I��������������" ) );
				dt.Columns[ct_Col_InventoryPreprTim].DefaultValue = 0;
				// �I���X�V��
				dt.Columns.Add( CreateColumn( ct_Col_LastInventoryUpdate, typeof(DateTime), "�I���X�V��" ) );
				dt.Columns[ct_Col_LastInventoryUpdate].DefaultValue = DateTime.MinValue;
                // �I���V�K�ǉ��敪
				dt.Columns.Add( CreateColumn( ct_Col_InventoryNewDiv, typeof(Int32), "�敪" ) );
				dt.Columns[ct_Col_InventoryNewDiv].DefaultValue = 0;
				// �I���V�K�ǉ��敪����
				dt.Columns.Add( CreateColumn( ct_Col_InventoryNewDivName, typeof(string), "�V�K�敪" ) );
				dt.Columns[ct_Col_InventoryNewDivName].DefaultValue = "";
                // �݌Ɋz
				dt.Columns.Add( CreateColumn( ct_Col_StockMashinePrice, typeof(Int64), "�݌Ɋz" ) );
				dt.Columns[ct_Col_StockMashinePrice].DefaultValue = 0;
                // �I���݌Ɋz
				dt.Columns.Add( CreateColumn( ct_Col_InventoryStockPrice, typeof(Int64), "�I���݌Ɋz" ) );
				dt.Columns[ct_Col_InventoryStockPrice].DefaultValue = 0;
                // �I���ߕs�����z
				dt.Columns.Add( CreateColumn( ct_Col_InventoryTlrncPrice, typeof(Int64), "�I���ߕs�����z" ) );
				dt.Columns[ct_Col_InventoryTlrncPrice].DefaultValue = 0;
                // �݌Ɉϑ�����敪
				dt.Columns.Add( CreateColumn( ct_Col_StockTrtEntDiv, typeof(Int32), "�݌Ɉϑ�����敪" ) );
				dt.Columns[ct_Col_StockTrtEntDiv].DefaultValue = 0;
				// �݌Ɉϑ�����敪����
				dt.Columns.Add( CreateColumn( ct_Col_StockTrtEntDivName, typeof(string), "�݌ɋ敪" ) );
				dt.Columns[ct_Col_StockTrtEntDivName].DefaultValue = "";
				// �\���敪
				dt.Columns.Add( CreateColumn( ct_Col_ViewDiv, typeof(Int32), "�\���敪" ) );
				dt.Columns[ct_Col_ViewDiv].DefaultValue = 0;
				// �{�^���p�J����
				dt.Columns.Add( CreateColumn( ct_Col_Button, typeof(char), "" ) );
				// ���s
				dt.Columns.Add( CreateColumn( ct_Col_RowSelf, typeof(object), "" ) );
				dt.Columns[ct_Col_RowSelf].DefaultValue = null;			
				// �X�e�[�^�X
				dt.Columns.Add( CreateColumn( ct_Col_Status, typeof(Int32), "�X�e�[�^�X" ) );
				dt.Columns[ct_Col_Status].DefaultValue = 0;
				// �X�e�[�^�X���e
				dt.Columns.Add( CreateColumn( ct_Col_StatusDetail, typeof(string), "�X�e�[�^�X" ) );
				dt.Columns[ct_Col_StatusDetail].DefaultValue = "";
				// �ύX�敪
				dt.Columns.Add( CreateColumn( ct_Col_ChangeDiv, typeof(Int32), "�ύX�敪" ) );
				dt.Columns[ct_Col_ChangeDiv].DefaultValue = 0;
				// �X�V�Ώۋ敪
				dt.Columns.Add( CreateColumn( ct_Col_UpdateDiv, typeof(Int32), "�X�V�Ώ�" ) );
				dt.Columns[ct_Col_UpdateDiv].DefaultValue = 0;
				// �ړ��݌ɐ�
				dt.Columns.Add( CreateColumn( ct_Col_MoveStockCount, typeof(Int32), "�ړ��݌ɐ�" ) );
				dt.Columns[ct_Col_MoveStockCount].DefaultValue = 0;
				// Key(�o�[�R�[�h�Ǎ��Ɏg�p
				dt.Columns.Add( CreateColumn( ct_Col_key, typeof(Guid), "Key" ) );
				dt.Columns[ct_Col_key].DefaultValue = Guid.Empty;
				// �\�[�g�p�����ԍ�
				dt.Columns.Add( CreateColumn( ct_Col_SortProductNumber, typeof(string), "" ) );
				dt.Columns[ct_Col_SortProductNumber].DefaultValue = "";
                // �폜�t���O
                dt.Columns.Add(CreateColumn(ct_Col_DeleteDiv, typeof(Int32), ""));
                dt.Columns[ct_Col_DeleteDiv].DefaultValue = 0;

                // ---ADD 2009/05/14 �s��Ή�[13260] ---------------------->>>>>
                // No
                dt.Columns.Add(CreateColumn(ct_Col_No, typeof(Int32), "No"));
                dt.Columns[ct_Col_No].DefaultValue = 0;
                //�݌ɑ���(���{��)
                dt.Columns.Add(CreateColumn(ct_Col_StockTotalExec, typeof(Double), "�݌ɑ���(���{��)"));
                dt.Columns[ct_Col_StockTotalExec].DefaultValue = 0;
                //�ߕs���X�V�敪
                dt.Columns.Add(CreateColumn(ct_Col_ToleranceUpdateCd, typeof(Int32), "�ߕs���X�V�敪"));
                dt.Columns[ct_Col_ToleranceUpdateCd].DefaultValue = 0;
                //�����p�v�Z����
                dt.Columns.Add(CreateColumn(ct_Col_AdjustCalcCost, typeof(Double), "�����p�v�Z����"));
                dt.Columns[ct_Col_AdjustCalcCost].DefaultValue = 0;
                //�I���ߕs����(DB�̒l���̂܂�)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryTolerancCntBf, typeof(Double), "�I���ߕs����(DB�̒l���̂܂�)"));
                dt.Columns[ct_Col_InventoryTolerancCntBf].DefaultValue = 0;
                // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------<<<<<

                //  -- UPD 2009/09/11 ---------------------->>>
                //DataColumn[] primaryKeys = new DataColumn[9];
                DataColumn[] primaryKeys = new DataColumn[10];
                //  -- UPD 2009/09/11 ----------------------<<<
                for (int index = 0; index < primaryKeys.Length; index++)
				{
					primaryKeys[index] = new DataColumn();
				}

                // ���_�R�[�h
                primaryKeys[0] = CreateColumn(ct_Col_SectionCode, typeof(string), "���_�R�[�h");
                primaryKeys[0].DefaultValue = "";
                dt.Columns.Add(primaryKeys[0]); // DataTable��Column��ǉ�
                // �q�ɃR�[�h
                primaryKeys[1] = CreateColumn(ct_Col_WarehouseCode, typeof(string), "�q�ɃR�[�h");
                primaryKeys[1].DefaultValue = "";
                dt.Columns.Add(primaryKeys[1]); // DataTable��Column��ǉ�
                // ���[�J�[�R�[�h
                primaryKeys[2] = CreateColumn(ct_Col_MakerCode, typeof(Int32), "���[�J�[�R�[�h");
                primaryKeys[2].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[2]); // DataTable��Column��ǉ�
                // �i��
                primaryKeys[3] = CreateColumn(ct_Col_GoodsNo, typeof(string), "�i��");
                primaryKeys[3].DefaultValue = "";
                dt.Columns.Add(primaryKeys[3]); // DataTable��Column��ǉ�
                // ���Ӑ�R�[�h
                primaryKeys[4] = CreateColumn(ct_Col_SupplierCode, typeof(Int32), "�d����R�[�h");
                primaryKeys[4].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[4]); // DataTable��Column��ǉ�
                // �o�א擾�Ӑ�R�[�h
                primaryKeys[5] = CreateColumn(ct_Col_ShipCustomerCode, typeof(Int32), "�o�א擾�Ӑ�R�[�h");
                primaryKeys[5].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[5]); // DataTable��Column��ǉ�
                // ���P��
                primaryKeys[6] = CreateColumn(ct_Col_StockUnitPrice, typeof(Double), "���P��");
                primaryKeys[6].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[6]); // DataTable��Column��ǉ�
                // �݌ɋ敪
                primaryKeys[7] = CreateColumn(ct_Col_StockDiv, typeof(Int32), "�݌ɋ敪");
                primaryKeys[7].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[7]); // DataTable��Column��ǉ�
                // �W�v�敪
                primaryKeys[8] = CreateColumn(ct_Col_GrossDiv, typeof(Int32), "�W�v�敪");
                primaryKeys[8].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[8]); // DataTable��Column��ǉ�

                // -- UPD 2009/09/11 ----------------------------------->>>
                // �I��
                primaryKeys[9] = CreateColumn(ct_Col_WarehouseShelfNo, typeof(string), "�I��");
                primaryKeys[9].DefaultValue = "";
                dt.Columns.Add(primaryKeys[9]); // DataTable��Column��ǉ�
                // -- UPD 2009/09/11 -----------------------------------<<<
                
                
                // DataTable��Key��ǉ�
                //dt.PrimaryKey = primaryKeys; //DEL yangyi 2013/03/01 Redmine#34175
			}
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman�p�ɕύX
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �e�[�u���X�L�[�}��`���\�b�h
        /// </summary>
        /// <param name="dt">DataTable</param>
        static public void CreateDataTable(ref DataTable dt)
        {

            // �e�[�u���C���X�^���X�̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u���N���A
                dt.Clear();
            }
            else
            {
                dt = new DataTable(ct_Tbl_InventInput);	// �e�[�u���C���X�^���X�쐬
                // ð��ٽ��ϒ�`
                #region
                // �쐬����
                dt.Columns.Add(CreateColumn(ct_Col_CreateDateTime, typeof(DateTime), "�쐬����"));
                dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
                // �X�V����
                dt.Columns.Add(CreateColumn(ct_Col_UpdateDateTime, typeof(DateTime), "�X�V����"));
                dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
                // ��ƃR�[�h
                dt.Columns.Add(CreateColumn(ct_Col_EnterpriseCode, typeof(string), "��ƃR�[�h"));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = "";
                // GUID
                dt.Columns.Add(CreateColumn(ct_Col_FileHeaderGuid, typeof(Guid), "GUID"));
                dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
                // �X�V�]�ƈ��R�[�h
                dt.Columns.Add(CreateColumn(ct_Col_UpdEmployeeCode, typeof(string), "�X�V�]�ƈ��R�[�h"));
                dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = "";
                // �X�V�A�Z���u��ID1
                dt.Columns.Add(CreateColumn(ct_Col_UpdAssemblyId1, typeof(string), "�X�V�A�Z���u��ID1"));
                dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = "";
                // �X�V�A�Z���u��ID2
                dt.Columns.Add(CreateColumn(ct_Col_UpdAssemblyId2, typeof(string), "�X�V�A�Z���u��ID2"));
                dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = "";
                // �_���폜�敪
                dt.Columns.Add(CreateColumn(ct_Col_LogicalDeleteCode, typeof(Int32), "�_���폜�敪"));
                dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;
                //// ���_�R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_SectionCode, typeof(string), "���_�R�[�h" ) );
                //dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                // ���_�K�C�h����
                dt.Columns.Add(CreateColumn(ct_Col_SectionGuideNm, typeof(string), "���_�K�C�h����"));
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                // �I���ʔ�
                dt.Columns.Add(CreateColumn(ct_Col_InventorySeqNo, typeof(Int32), "�ʔ�"));
                dt.Columns[ct_Col_InventorySeqNo].DefaultValue = 0;
                //// ���ԍ݌Ƀ}�X�^GUID
                //dt.Columns.Add( CreateColumn( ct_Col_ProductStockGuid, typeof(Guid), "���ԍ݌Ƀ}�X�^GUID" ) );
                //dt.Columns[ct_Col_ProductStockGuid].DefaultValue = Guid.Empty;
                //// �q�ɃR�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_WarehouseCode, typeof(string), "�q�ɃR�[�h" ) );
                //dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                // �q�ɖ���
                dt.Columns.Add(CreateColumn(ct_Col_WarehouseName, typeof(string), "�q�ɖ���"));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                //// ���[�J�[�R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_MakerCode, typeof(Int32), "���[�J�[�R�[�h" ) );
                //dt.Columns[ct_Col_MakerCode].DefaultValue = 0;
                // ���[�J�[����
                dt.Columns.Add(CreateColumn(ct_Col_MakerName, typeof(string), "���[�J�[����"));
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
                //// �i��
                //dt.Columns.Add( CreateColumn( ct_Col_GoodsCode, typeof(string), "�i��" ) );
                //dt.Columns[ct_Col_GoodsCode].DefaultValue = "";
                // �i��
                dt.Columns.Add(CreateColumn(ct_Col_GoodsName, typeof(string), "�i��"));
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //// �@��R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_CellphoneModelCode, typeof(string), "�@��R�[�h" ) );
                //dt.Columns[ct_Col_CellphoneModelCode].DefaultValue = "";
                //// �@�햼��
                //dt.Columns.Add( CreateColumn( ct_Col_CellphoneModelName, typeof(string), "�@�햼��" ) );
                //dt.Columns[ct_Col_CellphoneModelName].DefaultValue = "";
                //// �L�����A�R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierCode, typeof(Int32), "�L�����A�R�[�h" ) );
                //dt.Columns[ct_Col_CarrierCode].DefaultValue = 0;
                //// �L�����A����
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierName, typeof(string), "�L�����A����" ) );
                //dt.Columns[ct_Col_CarrierName].DefaultValue = "";
                //// �n���F�R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_SystematicColorCd, typeof(Int32), "�n���F�R�[�h" ) );
                //dt.Columns[ct_Col_SystematicColorCd].DefaultValue = 0;
                //// �n���F����
                //dt.Columns.Add( CreateColumn( ct_Col_SystematicColorNm, typeof(string), "�n���F����" ) );
                //dt.Columns[ct_Col_SystematicColorNm].DefaultValue = "";
                // �q�ɒI��
                dt.Columns.Add(CreateColumn(ct_Col_WarehouseShelfNo, typeof(string), "�I��"));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                // �d���I��1
                dt.Columns.Add(CreateColumn(ct_Col_DuplicationShelfNo1, typeof(string), "�d���I�ԂP"));
                dt.Columns[ct_Col_DuplicationShelfNo1].DefaultValue = "";
                // �d���I��2
                dt.Columns.Add(CreateColumn(ct_Col_DuplicationShelfNo2, typeof(string), "�d���I�ԂQ"));
                dt.Columns[ct_Col_DuplicationShelfNo2].DefaultValue = "";
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                // ���i�啪�ރR�[�h
                dt.Columns.Add(CreateColumn(ct_Col_LargeGoodsGanreCode, typeof(string), "���i�啪�ރR�[�h"));
                dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = 0;
                // ���i�啪�ޖ���
                dt.Columns.Add(CreateColumn(ct_Col_LargeGoodsGanreName, typeof(string), "���i�啪�ޖ���"));
                dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = "";
                // ���i�����ރR�[�h
                dt.Columns.Add(CreateColumn(ct_Col_MediumGoodsGanreCode, typeof(string), "���i�����ރR�[�h"));
                dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = 0;
                // ���i�����ޖ���
                dt.Columns.Add(CreateColumn(ct_Col_MediumGoodsGanreName, typeof(string), "���i�����ޖ���"));
                dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = "";
                //// ���Ǝ҃R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierEpCode, typeof(Int32), "���Ǝ҃R�[�h" ) );
                //dt.Columns[ct_Col_CarrierEpCode].DefaultValue = 0;
                // 2007.09.11 �C�� >>>>>>>>>>>>>>>>>>>>
                //// ���ƎҖ���
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierEpName, typeof(string), "���ƎҖ���" ) );
                //dt.Columns[ct_Col_CarrierEpName].DefaultValue = "";
                // �O���[�v�R�[�h
                dt.Columns.Add(CreateColumn(ct_Col_DetailGoodsGanreCode, typeof(string), "�O���[�v�R�[�h"));
                dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = 0;
                // �O���[�v�R�[�h����
                dt.Columns.Add(CreateColumn(ct_Col_DetailGoodsGanreName, typeof(string), "�O���[�v�R�[�h����"));
                dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = "";
                // ���Е��ރR�[�h
                dt.Columns.Add(CreateColumn(ct_Col_EnterpriseGanreCode, typeof(Int32), "���Е��ރR�[�h"));
                dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = 0;
                // ���Е��ޖ���
                dt.Columns.Add(CreateColumn(ct_Col_EnterpriseGanreName, typeof(string), "���Е��ޖ���"));
                dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = "";
                // �a�k�i��
                dt.Columns.Add(CreateColumn(ct_Col_BLGoodsCode, typeof(Int32), "�a�k�i��"));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                // �a�k�i��
                dt.Columns.Add(CreateColumn(ct_Col_BLGoodsName, typeof(string), "�a�k�i��"));
                dt.Columns[ct_Col_BLGoodsName].DefaultValue = "";
                // 2007.09.11 �C�� <<<<<<<<<<<<<<<<<<<<
                //// ���Ӑ�R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_CustomerCode, typeof(Int32), "���Ӑ�R�[�h" ) );
                //dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                // ���Ӑ於��
                dt.Columns.Add(CreateColumn(ct_Col_CustomerName, typeof(string), "���Ӑ於��"));
                dt.Columns[ct_Col_CustomerName].DefaultValue = "";
                // ���Ӑ於��2
                dt.Columns.Add(CreateColumn(ct_Col_CustomerName2, typeof(string), "���Ӑ於��2"));
                dt.Columns[ct_Col_CustomerName2].DefaultValue = "";
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �d����
                //dt.Columns.Add( CreateColumn( ct_Col_StockDate, typeof(DateTime), "�d����" ) );
                //dt.Columns[ct_Col_StockDate].DefaultValue = DateTime.MinValue;
                //// ���ד�
                //dt.Columns.Add( CreateColumn( ct_Col_ArrivalGoodsDay, typeof(DateTime), "���ד�" ) );
                //dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = DateTime.MinValue;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                //// �����ԍ�
                //dt.Columns.Add( CreateColumn( ct_Col_ProductNumber, typeof(string), "�����ԍ�" ) );
                //dt.Columns[ct_Col_ProductNumber].DefaultValue = "";
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// ���i�d�b�ԍ�1
                //dt.Columns.Add( CreateColumn( ct_Col_StockTelNo1, typeof(string), "�d�b�ԍ�1" ) );
                //dt.Columns[ct_Col_StockTelNo1].DefaultValue = "";
                //// �ύX�O���i�d�b�ԍ�1
                //dt.Columns.Add( CreateColumn( ct_Col_BfStockTelNo1, typeof(string), "�ύX�O���i�d�b�ԍ�1" ) );
                //dt.Columns[ct_Col_BfStockTelNo1].DefaultValue = "";
                //// ���i�d�b�ԍ�1�ύX�t���O
                //dt.Columns.Add( CreateColumn( ct_Col_StkTelNo1ChgFlg, typeof(Int32), "���i�d�b�ԍ�1�ύX�t���O" ) );
                //dt.Columns[ct_Col_StkTelNo1ChgFlg].DefaultValue = 0;
                //// ���i�d�b�ԍ�2
                //dt.Columns.Add( CreateColumn( ct_Col_StockTelNo2, typeof(string), "�d�b�ԍ�2" ) );
                //dt.Columns[ct_Col_StockTelNo2].DefaultValue = "";
                //// �ύX�O���i�d�b�ԍ�2
                //dt.Columns.Add( CreateColumn( ct_Col_BfStockTelNo2, typeof(string), "�ύX�O���i�d�b�ԍ�2" ) );
                //dt.Columns[ct_Col_BfStockTelNo2].DefaultValue = "";
                //// ���i�d�b�ԍ�2�ύX�t���O
                //dt.Columns.Add( CreateColumn( ct_Col_StkTelNo2ChgFlg, typeof(Int32), "���i�d�b�ԍ�2�ύX�t���O" ) );
                //dt.Columns[ct_Col_StkTelNo2ChgFlg].DefaultValue = 0;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                // JAN�R�[�h
                dt.Columns.Add(CreateColumn(ct_Col_Jan, typeof(string), "JAN�R�[�h"));
                dt.Columns[ct_Col_Jan].DefaultValue = "";
                //// �d���P��
                //dt.Columns.Add( CreateColumn( ct_Col_StockUnitPrice, typeof(Int64), "���P��" ) );
                //dt.Columns[ct_Col_StockUnitPrice].DefaultValue = 0;
                // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                //// �ύX�O�d���P��
                //dt.Columns.Add( CreateColumn( ct_Col_BfStockUnitPrice, typeof(Int64), "�ύX�O���P��" ) );
                //dt.Columns[ct_Col_BfStockUnitPrice].DefaultValue = 0;
                // �ύX�O�d���P��
                dt.Columns.Add(CreateColumn(ct_Col_BfStockUnitPrice, typeof(Double), "�ύX�O���P��"));
                dt.Columns[ct_Col_BfStockUnitPrice].DefaultValue = 0;
                // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                // �d���P���ύX�t���O
                dt.Columns.Add(CreateColumn(ct_Col_StkUnitPriceChgFlg, typeof(Int32), "���P���ύX�t���O"));
                dt.Columns[ct_Col_StkUnitPriceChgFlg].DefaultValue = 0;
                //// �݌ɋ敪
                //dt.Columns.Add( CreateColumn( ct_Col_StockDiv, typeof(Int32), "�݌ɋ敪" ) );
                //dt.Columns[ct_Col_StockDiv].DefaultValue = 0;
                //// �݌ɏ��
                //dt.Columns.Add( CreateColumn( ct_Col_StockState, typeof(Int32), "�݌ɏ��" ) );
                //dt.Columns[ct_Col_StockState].DefaultValue = 0;
                // 2007.09.11 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �ړ����
                //dt.Columns.Add( CreateColumn( ct_Col_MoveStatus, typeof(Int32), "�ړ����" ) );
                //dt.Columns[ct_Col_MoveStatus].DefaultValue = 0;
                //// ���i���
                //dt.Columns.Add( CreateColumn( ct_Col_GoodsCodeStatus, typeof(Int32), "���i���" ) );
                //dt.Columns[ct_Col_GoodsCodeStatus].DefaultValue = 0;
                //// ���ԊǗ��敪
                //dt.Columns.Add( CreateColumn( ct_Col_PrdNumMngDiv, typeof(Int32), "���ԊǗ��敪" ) );
                //dt.Columns[ct_Col_PrdNumMngDiv].DefaultValue = 0;
                // 2007.09.11 �폜 <<<<<<<<<<<<<<<<<<<<
                // �ŏI�d���N����
                dt.Columns.Add(CreateColumn(ct_Col_LastStockDate, typeof(DateTime), "�ŏI�d���N����"));
                dt.Columns[ct_Col_LastStockDate].DefaultValue = DateTime.MinValue;
                // ����݌ɐ�
                dt.Columns.Add(CreateColumn(ct_Col_StockTotal, typeof(Double), "���됔"));
                dt.Columns[ct_Col_StockTotal].DefaultValue = 0;
                //// �o�א擾�Ӑ�R�[�h
                //dt.Columns.Add( CreateColumn( ct_Col_ShipCustomerCode, typeof(Int32), "�o�א擾�Ӑ�R�[�h" ) );
                //dt.Columns[ct_Col_ShipCustomerCode].DefaultValue = 0;
                // �o�א擾�Ӑ於��
                dt.Columns.Add(CreateColumn(ct_Col_ShipCustomerName, typeof(string), "�o�א擾�Ӑ於��"));
                dt.Columns[ct_Col_ShipCustomerName].DefaultValue = "";
                // �o�א擾�Ӑ於��2
                dt.Columns.Add(CreateColumn(ct_Col_ShipCustomerName2, typeof(string), "�o�א擾�Ӑ於��2"));
                dt.Columns[ct_Col_ShipCustomerName2].DefaultValue = "";
                // �I���݌ɐ�
                dt.Columns.Add(CreateColumn(ct_Col_InventoryStockCnt, typeof(Double), "�I����"));
                dt.Columns[ct_Col_InventoryStockCnt].DefaultValue = 0;
                // ���ِ�
                dt.Columns.Add(CreateColumn(ct_Col_InventoryTolerancCnt, typeof(Double), "���ِ�"));
                dt.Columns[ct_Col_InventoryTolerancCnt].DefaultValue = 0;
                // �ύX�O���ِ�
                dt.Columns.Add(CreateColumn(ct_Col_BfChgInventoryToleCnt, typeof(Double), "�ύX�O���ِ�"));
                dt.Columns[ct_Col_BfChgInventoryToleCnt].DefaultValue = 0;
                // 2008.02.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                // �I����(int)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay, typeof(Int32), "�I����"));
                dt.Columns[ct_Col_InventoryExeDay].DefaultValue = 0;
                // �I����(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay_Datetime, typeof(DateTime), "�I����"));
                dt.Columns[ct_Col_InventoryExeDay_Datetime].DefaultValue = DateTime.MinValue;
                // �I����(String)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay_Str, typeof(string), "�I����"));
                dt.Columns[ct_Col_InventoryExeDay_Str].DefaultValue = "";
                // 2008.02.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // �I�������������t(int)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay, typeof(Int32), "�I�������������t"));
                dt.Columns[ct_Col_InventoryPreprDay].DefaultValue = 0;
                // �I�������������t(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Datetime, typeof(DateTime), "�I�������������t"));
                dt.Columns[ct_Col_InventoryPreprDay_Datetime].DefaultValue = DateTime.MinValue;
                // �I�������������t(�N ����)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Year, typeof(Int32), "�N"));
                dt.Columns[ct_Col_InventoryPreprDay_Year].DefaultValue = 0;
                // �I�������������t(�N ���x��)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_YearL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryPreprDay_YearL].DefaultValue = "�N";
                // �I�������������t(�� ����)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Month, typeof(Int32), "��"));
                dt.Columns[ct_Col_InventoryPreprDay_Month].DefaultValue = 0;
                // �I�������������t(�� ���x��)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_MonthL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryPreprDay_MonthL].DefaultValue = "��";
                // �I�������������t(�� ����)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Day, typeof(Int32), "��"));
                dt.Columns[ct_Col_InventoryPreprDay_Day].DefaultValue = 0;
                // �I�������������t(�� ���x��)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_DayL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryPreprDay_DayL].DefaultValue = "��";
                // �I�����{��(int)
                // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(CreateColumn(ct_Col_InventoryDay, typeof(Int32), "�I����"));
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay, typeof(Int32), "�I�����{��"));
                // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ct_Col_InventoryDay].DefaultValue = 0;
                // �I�����{��(DateTime)
                // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Datetime, typeof(DateTime), "�I����"));
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Datetime, typeof(DateTime), "�I�����{��"));
                // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ct_Col_InventoryDay_Datetime].DefaultValue = DateTime.MinValue;
                // �I�����{��(�N ����)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Year, typeof(Int32), "�N"));
                dt.Columns[ct_Col_InventoryDay_Year].DefaultValue = 0;
                // �I�����{��(�N ���x��)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_YearL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryDay_YearL].DefaultValue = "�N";
                // �I�����{��(�� ����)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Month, typeof(Int32), "��"));
                dt.Columns[ct_Col_InventoryDay_Month].DefaultValue = 0;
                // �I�����{��(�� ���x��)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_MonthL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryDay_MonthL].DefaultValue = "��";
                // �I�����{��(�� ����)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Day, typeof(Int32), "��"));
                dt.Columns[ct_Col_InventoryDay_Day].DefaultValue = 0;
                // �I�����{��(�� ���x��)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_DayL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryDay_DayL].DefaultValue = "��";
                // �I��������������
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprTim, typeof(Int32), "�I��������������"));
                dt.Columns[ct_Col_InventoryPreprTim].DefaultValue = 0;
                // �I���X�V��
                dt.Columns.Add(CreateColumn(ct_Col_LastInventoryUpdate, typeof(DateTime), "�I���X�V��"));
                dt.Columns[ct_Col_LastInventoryUpdate].DefaultValue = DateTime.MinValue;
                // �I���V�K�ǉ��敪
                dt.Columns.Add(CreateColumn(ct_Col_InventoryNewDiv, typeof(Int32), "�敪"));
                dt.Columns[ct_Col_InventoryNewDiv].DefaultValue = 0;
                // �I���V�K�ǉ��敪����
                dt.Columns.Add(CreateColumn(ct_Col_InventoryNewDivName, typeof(string), "�V�K�敪"));
                dt.Columns[ct_Col_InventoryNewDivName].DefaultValue = "";
                // 2007.09.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
                // �݌Ɋz
                dt.Columns.Add(CreateColumn(ct_Col_StockMashinePrice, typeof(Int64), "�݌Ɋz"));
                dt.Columns[ct_Col_StockMashinePrice].DefaultValue = 0;
                // �I���݌Ɋz
                dt.Columns.Add(CreateColumn(ct_Col_InventoryStockPrice, typeof(Int64), "�I���݌Ɋz"));
                dt.Columns[ct_Col_InventoryStockPrice].DefaultValue = 0;
                // �I���ߕs�����z
                dt.Columns.Add(CreateColumn(ct_Col_InventoryTlrncPrice, typeof(Int64), "�I���ߕs�����z"));
                dt.Columns[ct_Col_InventoryTlrncPrice].DefaultValue = 0;
                // 2007.09.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

                // �݌Ɉϑ�����敪
                dt.Columns.Add(CreateColumn(ct_Col_StockTrtEntDiv, typeof(Int32), "�݌Ɉϑ�����敪"));
                dt.Columns[ct_Col_StockTrtEntDiv].DefaultValue = 0;
                // �݌Ɉϑ�����敪����
                dt.Columns.Add(CreateColumn(ct_Col_StockTrtEntDivName, typeof(string), "�݌ɋ敪"));
                dt.Columns[ct_Col_StockTrtEntDivName].DefaultValue = "";
                //// �W�v�敪
                //dt.Columns.Add( CreateColumn( ct_Col_GrossDiv, typeof(Int32), "�W�v�敪" ) );
                //dt.Columns[ct_Col_GrossDiv].DefaultValue = 0;
                // �\���敪
                dt.Columns.Add(CreateColumn(ct_Col_ViewDiv, typeof(Int32), "�\���敪"));
                dt.Columns[ct_Col_ViewDiv].DefaultValue = 0;
                // �{�^���p�J����
                dt.Columns.Add(CreateColumn(ct_Col_Button, typeof(char), ""));
                //dt.Columns[ct_Col_Button].DefaultValue = 0;
                // ���s
                dt.Columns.Add(CreateColumn(ct_Col_RowSelf, typeof(object), ""));
                dt.Columns[ct_Col_RowSelf].DefaultValue = null;
                // �X�e�[�^�X
                dt.Columns.Add(CreateColumn(ct_Col_Status, typeof(Int32), "�X�e�[�^�X"));
                dt.Columns[ct_Col_Status].DefaultValue = 0;
                // �X�e�[�^�X���e
                dt.Columns.Add(CreateColumn(ct_Col_StatusDetail, typeof(string), "�X�e�[�^�X"));
                dt.Columns[ct_Col_StatusDetail].DefaultValue = "";
                // �ύX�敪
                dt.Columns.Add(CreateColumn(ct_Col_ChangeDiv, typeof(Int32), "�ύX�敪"));
                dt.Columns[ct_Col_ChangeDiv].DefaultValue = 0;
                // �X�V�Ώۋ敪
                dt.Columns.Add(CreateColumn(ct_Col_UpdateDiv, typeof(Int32), "�X�V�Ώ�"));
                dt.Columns[ct_Col_UpdateDiv].DefaultValue = 0;
                // �ړ��݌ɐ�
                dt.Columns.Add(CreateColumn(ct_Col_MoveStockCount, typeof(Int32), "�ړ��݌ɐ�"));
                dt.Columns[ct_Col_MoveStockCount].DefaultValue = 0;

                // Key(�o�[�R�[�h�Ǎ��Ɏg�p
                dt.Columns.Add(CreateColumn(ct_Col_key, typeof(Guid), "Key"));
                dt.Columns[ct_Col_key].DefaultValue = Guid.Empty;

                // �\�[�g�p�����ԍ�
                dt.Columns.Add(CreateColumn(ct_Col_SortProductNumber, typeof(string), ""));
                dt.Columns[ct_Col_SortProductNumber].DefaultValue = "";


                // 2007.07.19 kubo add -------------------------------------->
                // 2007.09.11 �ύX >>>>>>>>>>>>>>>>>>>>
                //DataColumn[] primaryKeys = new DataColumn[13];
                DataColumn[] primaryKeys = new DataColumn[9];
                // 2007.09.11 �ύX <<<<<<<<<<<<<<<<<<<<
                for (int index = 0; index < primaryKeys.Length; index++)
                {
                    primaryKeys[index] = new DataColumn();
                }

                // 2007.09.11 �ύX >>>>>>>>>>>>>>>>>>>>
                #region // 2007.09.11 �ύX
                //// ���_�R�[�h
                //primaryKeys[0] = CreateColumn( ct_Col_SectionCode, typeof(string), "���_�R�[�h" );
                //primaryKeys[0].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[0]); // DataTable��Column��ǉ�
                //// �q�ɃR�[�h
                //primaryKeys[1] = CreateColumn( ct_Col_WarehouseCode, typeof(string), "�q�ɃR�[�h" );
                //primaryKeys[1].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[1]); // DataTable��Column��ǉ�
                //// ���[�J�[�R�[�h
                //primaryKeys[2] = CreateColumn( ct_Col_MakerCode, typeof(Int32), "���[�J�[�R�[�h" );
                //primaryKeys[2].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[2]); // DataTable��Column��ǉ�
                //// �i��
                //primaryKeys[3] = CreateColumn( ct_Col_GoodsCode, typeof(string), "�i��" );
                //primaryKeys[3].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[3]); // DataTable��Column��ǉ�
                //// ���Ǝ҃R�[�h
                //primaryKeys[4] = CreateColumn( ct_Col_CarrierEpCode, typeof(Int32), "���Ǝ҃R�[�h" );
                //primaryKeys[4].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[4]); // DataTable��Column��ǉ�
                //// ���Ӑ�R�[�h
                //primaryKeys[5] = CreateColumn( ct_Col_CustomerCode, typeof(Int32), "���Ӑ�R�[�h" );
                //primaryKeys[5].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[5]); // DataTable��Column��ǉ�
                //// �o�א擾�Ӑ�R�[�h
                //primaryKeys[6] = CreateColumn( ct_Col_ShipCustomerCode, typeof(Int32), "�o�א擾�Ӑ�R�[�h" );
                //primaryKeys[6].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[6]); // DataTable��Column��ǉ�
                //// ���P��
                //primaryKeys[7] = CreateColumn( ct_Col_StockUnitPrice, typeof(Int64), "���P��" );
                //primaryKeys[7].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[7]); // DataTable��Column��ǉ�
                //// �݌ɋ敪
                //primaryKeys[8] = CreateColumn( ct_Col_StockDiv, typeof(Int32), "�݌ɋ敪" );
                //primaryKeys[8].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[8]); // DataTable��Column��ǉ�
                //// �݌ɏ��
                //primaryKeys[9] = CreateColumn( ct_Col_StockState, typeof(Int32), "�݌ɏ��" );
                //primaryKeys[9].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[9]); // DataTable��Column��ǉ�
                ////// �I���V�K�ǉ��敪
                ////primaryKeys[10] = CreateColumn( ct_Col_InventoryNewDiv, typeof(Int32), "�敪" );
                ////primaryKeys[10].DefaultValue = 0;
                ////dt.Columns.Add(primaryKeys[10]); // DataTable��Column��ǉ�
                //// �����ԍ�
                //primaryKeys[10] = CreateColumn( ct_Col_ProductNumber, typeof(string), "�����ԍ�" );
                //primaryKeys[10].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[10]); // DataTable��Column��ǉ�
                //// �W�v�敪
                //primaryKeys[11] = CreateColumn( ct_Col_GrossDiv, typeof(Int32), "�W�v�敪" );
                //primaryKeys[11].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[11]); // DataTable��Column��ǉ�
                //// ���ԍ݌Ƀ}�X�^GUID
                //primaryKeys[12] = CreateColumn( ct_Col_ProductStockGuid, typeof(Guid), "���ԍ݌Ƀ}�X�^GUID" );
                //primaryKeys[12].DefaultValue = Guid.Empty;
                //dt.Columns.Add(primaryKeys[12]); // DataTable��Column��ǉ�
                //// 2007.07.19 kubo add <--------------------------------------
                #endregion
                // ���_�R�[�h
                primaryKeys[0] = CreateColumn(ct_Col_SectionCode, typeof(string), "���_�R�[�h");
                primaryKeys[0].DefaultValue = "";
                dt.Columns.Add(primaryKeys[0]); // DataTable��Column��ǉ�
                // �q�ɃR�[�h
                primaryKeys[1] = CreateColumn(ct_Col_WarehouseCode, typeof(string), "�q�ɃR�[�h");
                primaryKeys[1].DefaultValue = "";
                dt.Columns.Add(primaryKeys[1]); // DataTable��Column��ǉ�
                // ���[�J�[�R�[�h
                primaryKeys[2] = CreateColumn(ct_Col_MakerCode, typeof(Int32), "���[�J�[�R�[�h");
                primaryKeys[2].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[2]); // DataTable��Column��ǉ�
                // �i��
                primaryKeys[3] = CreateColumn(ct_Col_GoodsNo, typeof(string), "�i��");
                primaryKeys[3].DefaultValue = "";
                dt.Columns.Add(primaryKeys[3]); // DataTable��Column��ǉ�
                // ���Ӑ�R�[�h
                primaryKeys[4] = CreateColumn(ct_Col_CustomerCode, typeof(Int32), "���Ӑ�R�[�h");
                primaryKeys[4].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[4]); // DataTable��Column��ǉ�
                // �o�א擾�Ӑ�R�[�h
                primaryKeys[5] = CreateColumn(ct_Col_ShipCustomerCode, typeof(Int32), "�o�א擾�Ӑ�R�[�h");
                primaryKeys[5].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[5]); // DataTable��Column��ǉ�
                // 2008.02.14 �C�� >>>>>>>>>>>>>>>>>>>>
                //// ���P��
                //primaryKeys[6] = CreateColumn(ct_Col_StockUnitPrice, typeof(Int64), "���P��");
                //primaryKeys[6].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[6]); // DataTable��Column��ǉ�
                // ���P��
                primaryKeys[6] = CreateColumn(ct_Col_StockUnitPrice, typeof(Double), "���P��");
                primaryKeys[6].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[6]); // DataTable��Column��ǉ�
                // 2008.02.14 �C�� <<<<<<<<<<<<<<<<<<<<
                // �݌ɋ敪
                primaryKeys[7] = CreateColumn(ct_Col_StockDiv, typeof(Int32), "�݌ɋ敪");
                primaryKeys[7].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[7]); // DataTable��Column��ǉ�
                // �I���V�K�ǉ��敪
                //primaryKeys[8] = CreateColumn( ct_Col_InventoryNewDiv, typeof(Int32), "�敪" );
                //primaryKeys[8].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[8]); // DataTable��Column��ǉ�
                // �W�v�敪
                primaryKeys[8] = CreateColumn(ct_Col_GrossDiv, typeof(Int32), "�W�v�敪");
                primaryKeys[8].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[8]); // DataTable��Column��ǉ�
                // 2007.09.11 �ύX <<<<<<<<<<<<<<<<<<<<

                #region // 2007.07.19 kubo del -------------------------------------->
                //// key1:key
                //primaryKeys[14].ColumnName	= ct_Col_key;
                //primaryKeys[14].DataType		= System.Type.GetType("System.String");
                //primaryKeys[14].DefaultValue = "";
                //// DataTable��Column��ǉ�
                //dt.Columns.Add(primaryKeys[14]);
                #endregion // 2007.07.19 kubo del <--------------------------------------

                // DataTable��Key��ǉ�
                dt.PrimaryKey = primaryKeys;

                #endregion

            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman�p�ɕύX

        #endregion �� �e�[�u���X�L�[�}��`���\�b�h
        #endregion �� Public Method

        #region �� Public Method
        #region �� �f�[�^�e�[�u����쐬���\�b�h
        /// <summary>
        /// �f�[�^�e�[�u���̗���쐬����
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="type">�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <returns></returns>
        private static DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc;

            dc = new DataColumn();
            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;
            dc.ColumnMapping = MappingType.Element;
            return dc;
        }
		#endregion �� �f�[�^�e�[�u����쐬���\�b�h
		#endregion �� Public Method

	}
}

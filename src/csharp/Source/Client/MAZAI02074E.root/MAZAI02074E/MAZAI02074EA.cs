using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// �݌Ɉꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summa ry>
	/// <remarks>
    /// <br>Note       : �݌Ɉꗗ�\���o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : 23010�@�����@�m</br>
	/// <br>Date       : 2007.03.20</br>
    /// <br>Update Note: 2007.10.05 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.01.24 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή��i�s��Ή��j</br>
    /// <br>Update Note: 2008/10/08        �Ɠc �M�u</br>
    /// <br>			 �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// </remarks>
	public class MAZAI02074EA
	{
		#region Public Members
		/// <summary>�f�[�^�Z�b�g��</summary>
        public const string StockListDataSet = "StockListDataSet";
		/// <summary>�f�[�^�e�[�u����</summary>
        public const string StockListDataTable = "StockListDataTable";
        /// <summary>�݌Ɉꗗ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string StockListCommonBuffDataTable = "StockListCommonBuffDataTable";

        #region �݌Ɉꗗ�\�J�������

        /// <summary>���_�R�[�h</summary>
        public const string ctCol_SectionCode = "SectionCode";
        /// <summary>���_����</summary>
        public const string ctCol_SectionName = "SectionName";
        /// <summary>���[�J�[�R�[�h</summary>
        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //public const string ctCol_MakerCode = "MakerCode";
        public const string ctCol_GoodsMakerCd = "GoodsMakerCd";
        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary>���[�J�[����</summary>
        public const string ctCol_MakerName = "MakerName";
        /// <summary>���i�R�[�h</summary>
        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //public const string ctCol_GoodsCode = "GoodsCode";
        public const string ctCol_GoodsNo = "GoodsNo";
        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary>���i����</summary>
        public const string ctCol_GoodsName = "GoodsName";
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>�d���P��</summary>
        //public const string ctCol_StockUnitPrice = "StockUnitPrice";
        ///// <summary>�d���݌ɐ�</summary>
        //public const string ctCol_SupplierStock = "SupplierStock";
        //--- DEL 2008/08/01 ----------<<<<<
        // 2008.01.24 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�����</summary>
        //public const string ctCol_TrustCount = "TrustCount";
        // 2008.01.24 �폜 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�\��</summary>
        //public const string ctCol_ReservedCount = "ReservedCount";
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>�����݌ɐ�</summary>
        //public const string ctCol_AllowStockCnt = "AllowStockCnt";
        ///// <summary>�󒍐�</summary>
        //public const string ctCol_AcpOdrCount = "AcpOdrCount";
        ///// <summary>������</summary>
        //public const string ctCol_SalesOrderCount = "SalesOrderCount";
        ///// <summary>�d���݌ɕ��ϑ���</summary>
        //public const string ctCol_EntrustCnt = "EntrustCnt";
        //--- DEL 2008/08/01 ----------<<<<<
        // 2008.01.24 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>������ϑ���</summary>
        //public const string ctCol_TrustEntrustCnt = "TrustEntrustCnt";
        // 2008.01.24 �폜 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���ؐ�</summary>
        //public const string ctCol_SoldCnt = "SoldCnt";
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>�ړ����d���݌ɐ�</summary>
        //public const string ctCol_MovingSupliStock = "MovingSupliStock";
        //--- DEL 2008/08/01 ----------<<<<<
        // 2008.01.24 �C�� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�ړ�������݌ɐ�</summary>
        //public const string ctCol_MovingTrustStock = "MovingTrustStock";
        /// <summary>�o�א�(���v��)</summary>
        public const string ctCol_ShipmentCnt = "ShipmentCnt";
        /// <summary>���א�(���v��)</summary>
        public const string ctCol_ArrivalCnt = "ArrivalCnt";
        // 2008.01.24 �C�� <<<<<<<<<<<<<<<<<<<<
        /// <summary>�o�׉\��</summary>
        public const string ctCol_ShipmentPosCnt = "ShipmentPosCnt";
        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���ԊǗ��敪</summary>
        //public const string ctCol_PrdNumMngDiv = "PrdNumMngDiv";
        ///// <summary>���ԊǗ��敪</summary>
        //public const string ctCol_PrdNumMngDivName = "PrdNumMngDivName";
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>�ŏI�d���N����</summary>
        //public const string ctCol_LastStockDate = "LastStockDate";
        ///// <summary>�ŏI�����</summary>
        //public const string ctCol_LastSalesDate = "LastSalesDate";
        ///// <summary>�ŏI�I���X�V��</summary>
        //public const string ctCol_LastInventoryUpdate = "LastInventoryUpdate";
        //--- DEL 2008/08/01 ----------<<<<<
        /// <summary>�ŏI�d���N����(�\�[�g�p)</summary>
        public const string ctCol_LastStockDate_sort = "LastStockDate_sort";
        /// <summary>�ŏI�����(�\�[�g�p)</summary>
        public const string ctCol_LastSalesDate_sort = "LastSalesDate_sort";
        /// <summary>�ŏI�I���X�V��(�\�[�g�p)</summary>
        public const string ctCol_LastInventoryUpdate_sort = "LastInventoryUpdate_sort";
        /// <summary>�ŏI�d���N����(����p)</summary>
        public const string ctCol_LastStockDate_print = "LastStockDate_print";
        /// <summary>�ŏI�����(����p)</summary>
        public const string ctCol_LastSalesDate_print = "LastSalesDate_print";
        /// <summary>�ŏI�I���X�V��(����p)</summary>
        public const string ctCol_LastInventoryUpdate_print = "LastInventoryUpdate_print";
        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>�@��R�[�h</summary>
        //public const string ctCol_CellphoneModelCode = "CellphoneModelCode";
        ///// <summary>�@�햼��</summary>
        //public const string ctCol_CellphoneModelName = "CellphoneModelName";
        ///// <summary>�L�����A�R�[�h</summary>
        //public const string ctCol_CarrierCode = "CarrierCode";
        ///// <summary>�L�����A����</summary>
        //public const string ctCol_CarrierName = "CarrierName";
        ///// <summary>�n���F�R�[�h</summary>
        //public const string ctCol_SystematicColorCd = "SystematicColorCd";
        ///// <summary>�n���F����</summary>
        //public const string ctCol_SystematicColorNm = "SystematicColorNm";
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>���i�敪�O���[�v�R�[�h</summary>
        //public const string ctCol_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary>���i�敪�O���[�v����</summary>
        //public const string ctCol_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary>���i�敪�R�[�h</summary>
        //public const string ctCol_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary>���i�敪����</summary>
        //public const string ctCol_MediumGoodsGanreName = "MediumGoodsGanreName";
        //// 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���i�敪�ڍ׃R�[�h</summary>
        //public const string ctCol_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary>���i�敪�ڍז���</summary>
        //public const string ctCol_DetailGoodsGanreName = "DetailGoodsGanreName";
        ///// <summary>���Е��ރR�[�h</summary>
        //public const string ctCol_EnterpriseGanreCode = "EnterpriseGanreCode";
        ///// <summary>���Е��ޖ���</summary>
        //public const string ctCol_EnterpriseGanreName = "EnterpriseGanreName";
        //--- DEL 2008/08/01 ----------<<<<<
        /// <summary>�a�k���i�R�[�h</summary>
        public const string ctCol_BLGoodsCode = "BLGoodsCode";
        /// <summary>�a�k���i����</summary>
        public const string ctCol_BLGoodsName = "BLGoodsName";
        /// <summary>�q�ɃR�[�h</summary>
        public const string ctCol_WarehouseCode = "WarehouseCode";
        /// <summary>�q�ɖ���</summary>
        public const string ctCol_WarehouseName = "WarehouseName";
        // 2008.01.24 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>�q�ɒI��</summary>
        public const string ctCol_WarehouseShelfNo = "WarehouseShelfNo";
        // 2008.01.24 �ǉ� <<<<<<<<<<<<<<<<<<<<
        // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
        /// <summary>�Œ�݌ɐ�</summary>
        public const string ctCol_MinimumStockCnt = "MinimumStockCnt";
        /// <summary>�ō��݌ɐ�</summary>
        public const string ctCol_MaximumStockCnt = "MaximumStockCnt";
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>�������</summary>
        //public const string ctCol_NmlSalOdrCount = "NmlSalOdrCount";
        ///// <summary>�����P��</summary>
        //public const string ctCol_SalOdrLot = "SalOdrLot";
        ///// <summary>�݌ɕۗL���z</summary>
        //public const string ctCol_StockTotalPrice = "StockTotalPrice";
        ///// <summary>�\�[�g���u���C�N�L�[</summary>
        //public const string ctCol_SortTotalKey = "SortTotalKey";
        ///// <summary>���חp���_����</summary>
        //public const string ctCol_SectionName_Detail = "SectionName_Detail";
        ///// <summary>���[�J�[�R�[�h(����p)</summary>
        //public const string ctCol_MakerCode_Print = "MakerCode_Print";
        //// 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>�L�����A�R�[�h(����p)</summary>
        ////public const string ctCol_CarrierCode_Print = "CarrierCode_Print";
        /////// <summary>�n���F�R�[�h(����p)</summary>
        ////public const string ctCol_SystematicColorCd_Print = "SystematicColorCd_Print";
        //// 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>���i�敪�O���[�v�R�[�h(����p)</summary>
        //public const string ctCol_LargeGoodsGanreCode_Print = "LargeGoodsGanreCode_Print";
        ///// <summary>���i�敪�R�[�h(����p)</summary>
        //public const string ctCol_MediumGoodsGanreCode_Print = "MediumGoodsGanreCode_Print";     
        //// 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
        ///// <summary>���i�敪�ڍ׃R�[�h(����p)</summary>
        //public const string ctCol_DetailGoodsGanreCode_Print = "DetailGoodsGanreCode_Print";
        //// 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        /// <summary>�݌ɔ�����R�[�h</summary>
        public const string ctCol_StockSupplierCode = "StockSupplierCode";
        /// <summary>�d���旪��</summary>
        public const string ctCol_SupplierSnm = "SupplierSnm";
        /// <summary>���i�Ǘ��敪�P</summary>
        //public const string ctCol_DuplicationShelfNo1 = "DuplicationShelfNo1";        //DEL 2008/10/08 ID�ύX
        public const string ctCol_PartsManagementDivide1 = "PartsManagementDivide1";    //ADD 2008/10/08
        /// <summary>���i�Ǘ��敪�Q</summary>
        //public const string ctCol_DuplicationShelfNo2 = "DuplicationShelfNo2";        //DEL 2008/10/08 ID�ύX
        public const string ctCol_PartsManagementDivide2 = "PartsManagementDivide2";    //ADD 2008/10/08
        /// <summary>�݌ɓo�^��</summary>
        public const string ctCol_StockCreateDate = "StockCreateDate";
        /// <summary>�v��N��</summary>
        public const string ctCol_AddUpYearMonth = "AddUpYearMonth";
        /// <summary>�o�׋��z</summary>
        public const string ctCol_ShipmentPrice = "ShipmentPrice";

        /// <summary> �P�����O </summary>
        public const string ctCol_ShipmentCntBefore1 = "ShipmentCntBefore1";
        /// <summary> �Q�����O </summary>
        public const string ctCol_ShipmentCntBefore2 = "ShipmentCntBefore2";
        /// <summary> �R�����O </summary>
        public const string ctCol_ShipmentCntBefore3 = "ShipmentCntBefore3";
        /// <summary> �U�������v </summary>
        public const string ctCol_ShipmentCntBeforeTotal = "ShipmentCntBeforeTotal";

        /// <summary> �P�����O </summary>
        public const string ctCol_ShipmentPriceBefore1 = "ShipmentPriceBefore1";
        /// <summary> �Q�����O </summary>
        public const string ctCol_ShipmentPriceBefore2 = "ShipmentPriceBefore2";
        /// <summary> �R�����O </summary>
        public const string ctCol_ShipmentPriceBefore3 = "ShipmentPriceBefore3";
        /// <summary> �U�������v </summary>
        public const string ctCol_ShipmentPriceBeforeTotal = "ShipmentPriceBeforeTotal";

        /// <summary> �q�ɒI�ԃu���C�N </summary>
        public const string ctCol_WarehouseShelfNoBreak = "WarehouseShelfNoBreak";

        /// <summary> �\�[�g�p�@���_�R�[�h </summary>
        public const string ctCol_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> �\�[�g�p�@�q�ɃR�[�h </summary>
        public const string ctCol_Sort_WarehouseCode = "Sort_WarehouseCode";
        /// <summary> �\�[�g�p�@�d����R�[�h </summary>
        public const string ctCol_Sort_CustomerCode = "Sort_CustomerCode";
        /// <summary> �\�[�g�p�@���i���[�J�[�R�[�h </summary>
        public const string ctCol_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        /// <summary> �\�[�g�p�@���i�ԍ� </summary>
        public const string ctCol_Sort_GoodsNo = "Sort_GoodsNo";
        /// <summary> �\�[�g�p�@�q�ɒI�ԃu���C�N </summary>
        public const string ctCol_Sort_WarehouseShelfNoBreak = "Sort_WarehouseShelfNoBreak";
        /// <summary> �\�[�g�p�@�q�ɒI�� </summary>
        public const string ctCol_Sort_WarehouseShelfNo = "Sort_WarehouseShelfNo";
        //--- ADD 2008/08/01 ----------<<<<<
        #endregion

		#endregion

		#region Constructor
		/// <summary>
        /// �݌Ɉꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ɉꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public MAZAI02074EA()
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
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(StockListDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[StockListDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 0);
			}

            // �݌Ɏԗ����o�ɊǗ��\���o���ʃo�b�t�@�f�[�^�e�[�u��------------------------------------------
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(StockListCommonBuffDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[StockListCommonBuffDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 1);
			}
		}
		
		
		/// <summary>
        /// �݌Ɉꗗ�\���o���ʍ쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
        private static void CreateRestListCommonTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// �X�L�[�}�ݒ�
                ds.Tables.Add(StockListDataTable);
                dt = ds.Tables[StockListDataTable];
			}
			else
			{
				// �X�L�[�}�ݒ�
                ds.Tables.Add(StockListCommonBuffDataTable);
                dt = ds.Tables[StockListCommonBuffDataTable];
            }

            // ���_�R�[�h
            dt.Columns.Add(ctCol_SectionCode,typeof(string));
            dt.Columns[ctCol_SectionCode].DefaultValue = "";
            // ���_����
            dt.Columns.Add(ctCol_SectionName,typeof(string));
            dt.Columns[ctCol_SectionName].DefaultValue = "";
            // ���[�J�[�R�[�h
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //dt.Columns.Add(ctCol_MakerCode, typeof(Int32));
            //dt.Columns[ctCol_MakerCode].DefaultValue = 0;
            dt.Columns.Add(ctCol_GoodsMakerCd, typeof(Int32));
            dt.Columns[ctCol_GoodsMakerCd].DefaultValue = 0;
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���[�J�[����
            dt.Columns.Add(ctCol_MakerName,typeof(string));
            dt.Columns[ctCol_MakerName].DefaultValue = "";
            // ���i�R�[�h
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //dt.Columns.Add(ctCol_GoodsCode, typeof(string));
            //dt.Columns[ctCol_GoodsCode].DefaultValue = "";
            dt.Columns.Add(ctCol_GoodsNo, typeof(string));
            dt.Columns[ctCol_GoodsNo].DefaultValue = "";
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
            // ���i����
            dt.Columns.Add(ctCol_GoodsName,typeof(string));
            dt.Columns[ctCol_GoodsName].DefaultValue = "";
            //--- DEL 2008/08/01 ---------->>>>>
            //// �d���P��
            //dt.Columns.Add(ctCol_StockUnitPrice,typeof(Int64));
            //dt.Columns[ctCol_StockUnitPrice].DefaultValue = 0;
            //// �d���݌ɐ�
            //dt.Columns.Add(ctCol_SupplierStock,typeof(Double));
            //dt.Columns[ctCol_SupplierStock].DefaultValue = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.01.24 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����
            //dt.Columns.Add(ctCol_TrustCount,typeof(Double));
            //dt.Columns[ctCol_TrustCount].DefaultValue = 0;
            // 2008.01.24 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �\��
            //dt.Columns.Add(ctCol_ReservedCount,typeof(Int32));
            //dt.Columns[ctCol_ReservedCount].DefaultValue = 0;
            // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// �����݌ɐ�
            //dt.Columns.Add(ctCol_AllowStockCnt,typeof(Double));
            //dt.Columns[ctCol_AllowStockCnt].DefaultValue = 0;
            //// �󒍐�
            //dt.Columns.Add(ctCol_AcpOdrCount,typeof(Double));
            //dt.Columns[ctCol_AcpOdrCount].DefaultValue = 0;
            //// ������
            //dt.Columns.Add(ctCol_SalesOrderCount,typeof(Double));
            //dt.Columns[ctCol_SalesOrderCount].DefaultValue = 0;
            //// �d���݌ɕ��ϑ���
            //dt.Columns.Add(ctCol_EntrustCnt,typeof(Double));
            //dt.Columns[ctCol_EntrustCnt].DefaultValue = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.01.24 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ������ϑ���
            //dt.Columns.Add(ctCol_TrustEntrustCnt,typeof(Double));
            //dt.Columns[ctCol_TrustEntrustCnt].DefaultValue = 0;
            // 2008.01.24 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ؐ�
            //dt.Columns.Add(ctCol_SoldCnt,typeof(Double));
            //dt.Columns[ctCol_SoldCnt].DefaultValue = 0;
            // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// �ړ����d���݌ɐ�
            //dt.Columns.Add(ctCol_MovingSupliStock,typeof(Double));
            //dt.Columns[ctCol_MovingSupliStock].DefaultValue = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.01.24 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �ړ�������݌ɐ�
            //dt.Columns.Add(ctCol_MovingTrustStock,typeof(Double));
            //dt.Columns[ctCol_MovingTrustStock].DefaultValue = 0;
            // �o�א�(���v��)
            dt.Columns.Add(ctCol_ShipmentCnt, typeof(Double));
            dt.Columns[ctCol_ShipmentCnt].DefaultValue = 0;
            // ���א�(���v��)
            dt.Columns.Add(ctCol_ArrivalCnt, typeof(Double));
            dt.Columns[ctCol_ArrivalCnt].DefaultValue = 0;
            // 2008.01.24 �C�� <<<<<<<<<<<<<<<<<<<<
            // �o�׉\��
            dt.Columns.Add(ctCol_ShipmentPosCnt,typeof(Double));
            dt.Columns[ctCol_ShipmentPosCnt].DefaultValue = 0;
            // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԊǗ��敪
            //dt.Columns.Add(ctCol_PrdNumMngDiv,typeof(Int32));
            //dt.Columns[ctCol_PrdNumMngDiv].DefaultValue = 0;
            //// ���ԊǗ�����
            //dt.Columns.Add(ctCol_PrdNumMngDivName,typeof(string));
            //dt.Columns[ctCol_PrdNumMngDivName].DefaultValue = "";
            // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// �ŏI�d���N����
            //dt.Columns.Add(ctCol_LastStockDate,typeof(DateTime));
            //dt.Columns[ctCol_LastStockDate].DefaultValue = DateTime.MinValue;
            //// �ŏI�����
            //dt.Columns.Add(ctCol_LastSalesDate,typeof(DateTime));
            //dt.Columns[ctCol_LastSalesDate].DefaultValue = DateTime.MinValue;
            //// �ŏI�I���X�V��
            //dt.Columns.Add(ctCol_LastInventoryUpdate,typeof(DateTime));
            //dt.Columns[ctCol_LastInventoryUpdate].DefaultValue = DateTime.MinValue;
            //--- DEL 2008/08/01 ----------<<<<<
            // �ŏI�d���N����(�\�[�g)
            dt.Columns.Add(ctCol_LastStockDate_sort,typeof(Int32));
            dt.Columns[ctCol_LastStockDate_sort].DefaultValue = 0;
            // �ŏI�����(�\�[�g)
            dt.Columns.Add(ctCol_LastSalesDate_sort,typeof(Int32));
            dt.Columns[ctCol_LastSalesDate_sort].DefaultValue = 0;
            // �ŏI�I���X�V��(�\�[�g)
            dt.Columns.Add(ctCol_LastInventoryUpdate_sort,typeof(Int32));
            dt.Columns[ctCol_LastInventoryUpdate_sort].DefaultValue = 0;
            // �ŏI�d���N����(���)
            dt.Columns.Add(ctCol_LastStockDate_print,typeof(string));
            dt.Columns[ctCol_LastStockDate_print].DefaultValue = "";
            // �ŏI�����(���)
            dt.Columns.Add(ctCol_LastSalesDate_print,typeof(string));
            dt.Columns[ctCol_LastSalesDate_print].DefaultValue = "";
            // �ŏI�I���X�V��(���)
            dt.Columns.Add(ctCol_LastInventoryUpdate_print,typeof(string));
            dt.Columns[ctCol_LastInventoryUpdate_print].DefaultValue = "";
            // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �@��R�[�h
            //dt.Columns.Add(ctCol_CellphoneModelCode,typeof(string));
            //dt.Columns[ctCol_CellphoneModelCode].DefaultValue = "";
            //// �@�햼��
            //dt.Columns.Add(ctCol_CellphoneModelName,typeof(string));
            //dt.Columns[ctCol_CellphoneModelName].DefaultValue = "";
            //// �L�����A�R�[�h
            //dt.Columns.Add(ctCol_CarrierCode,typeof(Int32));
            //dt.Columns[ctCol_CarrierCode].DefaultValue = 0;
            //// �L�����A����
            //dt.Columns.Add(ctCol_CarrierName,typeof(string));
            //dt.Columns[ctCol_CarrierName].DefaultValue = "";
            //// �n���F�R�[�h
            //dt.Columns.Add(ctCol_SystematicColorCd,typeof(Int32));
            //dt.Columns[ctCol_SystematicColorCd].DefaultValue = 0;
            //// �n���F����
            //dt.Columns.Add(ctCol_SystematicColorNm,typeof(string));
            //dt.Columns[ctCol_SystematicColorNm].DefaultValue = "";
            // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
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
            //// 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //// ���i�敪�ڍ׃R�[�h
            //dt.Columns.Add(ctCol_DetailGoodsGanreCode, typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreCode].DefaultValue = "";
            //// ���i�敪�ڍז���
            //dt.Columns.Add(ctCol_DetailGoodsGanreName, typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreName].DefaultValue = "";
            //// ���Е��ރR�[�h
            //dt.Columns.Add(ctCol_EnterpriseGanreCode, typeof(Int32));
            //dt.Columns[ctCol_EnterpriseGanreCode].DefaultValue = 0;
            //// ���Е��ޖ���
            //dt.Columns.Add(ctCol_EnterpriseGanreName, typeof(string));
            //dt.Columns[ctCol_EnterpriseGanreName].DefaultValue = "";
            //--- DEL 2008/08/01 ----------<<<<<
            // �a�k���i�R�[�h
            dt.Columns.Add(ctCol_BLGoodsCode, typeof(Int32));
            dt.Columns[ctCol_BLGoodsCode].DefaultValue = 0;
            // �a�k���i����
            dt.Columns.Add(ctCol_BLGoodsName, typeof(string));
            dt.Columns[ctCol_BLGoodsName].DefaultValue = "";
            // �q�ɃR�[�h
            dt.Columns.Add(ctCol_WarehouseCode, typeof(string));
            dt.Columns[ctCol_WarehouseCode].DefaultValue = "";
            // �q�ɖ���
            dt.Columns.Add(ctCol_WarehouseName, typeof(string));
            dt.Columns[ctCol_WarehouseName].DefaultValue = "";
            // 2008.01.24 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �q�ɒI��
            dt.Columns.Add(ctCol_WarehouseShelfNo, typeof(string));
            dt.Columns[ctCol_WarehouseShelfNo].DefaultValue = "";
            // 2008.01.24 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // �Œ�݌ɐ�
            dt.Columns.Add(ctCol_MinimumStockCnt,typeof(Double));
            dt.Columns[ctCol_MinimumStockCnt].DefaultValue = 0;
            // �ō��݌ɐ�
            dt.Columns.Add(ctCol_MaximumStockCnt,typeof(Double));
            dt.Columns[ctCol_MaximumStockCnt].DefaultValue = 0;
            //--- DEL 2008/08/01 ---------->>>>>
            //// �������
            //dt.Columns.Add(ctCol_NmlSalOdrCount,typeof(Double));
            //dt.Columns[ctCol_NmlSalOdrCount].DefaultValue = 0;
            //// �����P��
            //dt.Columns.Add(ctCol_SalOdrLot,typeof(Int32));
            //dt.Columns[ctCol_SalOdrLot].DefaultValue = 0;
            //// �݌ɕۗL���z
            //dt.Columns.Add(ctCol_StockTotalPrice,typeof(Int64));
            //dt.Columns[ctCol_StockTotalPrice].DefaultValue = 0;
            //// �\�[�g���v�u���C�N�L�[
            //dt.Columns.Add(ctCol_SortTotalKey,typeof(string));
            //dt.Columns[ctCol_SortTotalKey].DefaultValue = "";
            //// ���_����(���חp)
            //dt.Columns.Add(ctCol_SectionName_Detail,typeof(string));
            //dt.Columns[ctCol_SectionName_Detail].DefaultValue = "";
            ////���[�J�[�R�[�h(����p)
            //dt.Columns.Add(ctCol_MakerCode_Print,typeof(string));
            //dt.Columns[ctCol_MakerCode_Print].DefaultValue = "";
            //--- DEL 2008/08/01 ----------<<<<<
            // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�R�[�h(����p)
            //dt.Columns.Add(ctCol_CarrierCode_Print,typeof(string));
            //dt.Columns[ctCol_CarrierCode_Print].DefaultValue = "";
            ////�n���F�R�[�h(����p)
            //dt.Columns.Add(ctCol_SystematicColorCd_Print,typeof(string));
            //dt.Columns[ctCol_SystematicColorCd_Print].DefaultValue = "";
            // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            ////���i�敪�O���[�v�R�[�h(����p)
            //dt.Columns.Add(ctCol_LargeGoodsGanreCode_Print,typeof(string));
            //dt.Columns[ctCol_LargeGoodsGanreCode_Print].DefaultValue = "";
            ////���i�敪�R�[�h(����p)
            //dt.Columns.Add(ctCol_MediumGoodsGanreCode_Print,typeof(string));
            //dt.Columns[ctCol_MediumGoodsGanreCode_Print].DefaultValue = "";                               
            //// 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            ////���i�敪�ڍ׃R�[�h(����p)
            //dt.Columns.Add(ctCol_DetailGoodsGanreCode_Print,typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreCode_Print].DefaultValue = "";                               
            //// 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ----------<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            // �݌ɔ�����R�[�h
            dt.Columns.Add(ctCol_StockSupplierCode, typeof(Int32));
            dt.Columns[ctCol_StockSupplierCode].DefaultValue = 0;

            // �d���旪��
            dt.Columns.Add(ctCol_SupplierSnm, typeof(string));
            dt.Columns[ctCol_SupplierSnm].DefaultValue = "";

            /* --- DEL 2008/10/08 ID�ύX�̈� ----------------------->>>>>
            // ���i�Ǘ��敪�P
            dt.Columns.Add(ctCol_DuplicationShelfNo1, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo1].DefaultValue = "";

            // ���i�Ǘ��敪�Q
            dt.Columns.Add(ctCol_DuplicationShelfNo2, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo2].DefaultValue = "";
               --- DEL 2008/10/08 ----------------------------------<<<<< */
            // --- ADD 2008/10/08 ---------------------------------->>>>>
            // ���i�Ǘ��敪�P
            dt.Columns.Add(ctCol_PartsManagementDivide1, typeof(string));
            dt.Columns[ctCol_PartsManagementDivide1].DefaultValue = "";

            // ���i�Ǘ��敪�Q
            dt.Columns.Add(ctCol_PartsManagementDivide2, typeof(string));
            dt.Columns[ctCol_PartsManagementDivide2].DefaultValue = "";
            // --- ADD 2008/10/08 ----------------------------------<<<<<

            // �݌ɓo�^��
            dt.Columns.Add(ctCol_StockCreateDate, typeof(string));
            dt.Columns[ctCol_StockCreateDate].DefaultValue = 0;

            // �v��N��
            dt.Columns.Add(ctCol_AddUpYearMonth, typeof(Int32));
            dt.Columns[ctCol_AddUpYearMonth].DefaultValue = 0;

            // �o�׋��z
            dt.Columns.Add(ctCol_ShipmentPrice, typeof(Int64));
            dt.Columns[ctCol_ShipmentPrice].DefaultValue = 0;

            // �P�����O
            dt.Columns.Add(ctCol_ShipmentCntBefore1, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBefore1].DefaultValue = 0;

            // �Q�����O
            dt.Columns.Add(ctCol_ShipmentCntBefore2, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBefore2].DefaultValue = 0;

            // �R�����O
            dt.Columns.Add(ctCol_ShipmentCntBefore3, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBefore3].DefaultValue = 0;

            // �U�������v
            dt.Columns.Add(ctCol_ShipmentCntBeforeTotal, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBeforeTotal].DefaultValue = 0;

            // �P�����O
            dt.Columns.Add(ctCol_ShipmentPriceBefore1, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBefore1].DefaultValue = 0;

            // �Q�����O
            dt.Columns.Add(ctCol_ShipmentPriceBefore2, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBefore2].DefaultValue = 0;

            // �R�����O
            dt.Columns.Add(ctCol_ShipmentPriceBefore3, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBefore3].DefaultValue = 0;

            // �U�������v
            dt.Columns.Add(ctCol_ShipmentPriceBeforeTotal, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBeforeTotal].DefaultValue = 0;

            dt.Columns.Add(ctCol_WarehouseShelfNoBreak, typeof(string)); // �q�ɒI�ԃu���C�N
            dt.Columns[ctCol_WarehouseShelfNoBreak].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_SectionCode, typeof(string)); // �\�[�g�p�@���_�R�[�h
            dt.Columns[ctCol_Sort_SectionCode].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_WarehouseCode, typeof(string)); // �\�[�g�p�@�q�ɃR�[�h
            dt.Columns[ctCol_Sort_WarehouseCode].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_CustomerCode, typeof(Int32)); // �\�[�g�p�@�d����R�[�h
            dt.Columns[ctCol_Sort_CustomerCode].DefaultValue = 0;

            dt.Columns.Add(ctCol_Sort_GoodsMakerCd, typeof(Int32)); // �\�[�g�p�@���i���[�J�[�R�[�h
            dt.Columns[ctCol_Sort_GoodsMakerCd].DefaultValue = 0;

            dt.Columns.Add(ctCol_Sort_GoodsNo, typeof(string)); // �\�[�g�p�@���i�ԍ�
            dt.Columns[ctCol_Sort_GoodsNo].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_WarehouseShelfNo, typeof(string)); // �\�[�g�p�@�q�ɒI��
            dt.Columns[ctCol_Sort_WarehouseShelfNo].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_WarehouseShelfNoBreak, typeof(string)); // �\�[�g�p�@�q�ɒI�ԃu���C�N
            dt.Columns[ctCol_Sort_WarehouseShelfNoBreak].DefaultValue = "";
            //--- ADD 2008/08/01 ----------<<<<<
        }

		#endregion
	}
}
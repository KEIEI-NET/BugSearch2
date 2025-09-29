using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �݌Ƀ}�X�^�ꗗ��� �e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�ꗗ����e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class RsltInfo_StockMasterTbl
    {

        /// <summary> �e�[�u������ </summary>
        public const string Col_Tbl_Result_StockMaster = "Tbl_Result_StockMaster";

        /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> �q�ɃR�[�h </summary>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> ���i�ԍ� </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> �d���P���i�Ŕ�,�����j </summary>
        public const string Col_StockUnitPriceFl = "StockUnitPriceFl";

        /// <summary> �d���݌ɐ� </summary>
        public const string Col_SupplierStock = "SupplierStock";

        /// <summary> �󒍐� </summary>
        public const string Col_AcpOdrCount = "AcpOdrCount";

        /// <summary> M/O������ </summary>
        public const string Col_MonthOrderCount = "MonthOrderCount";

        /// <summary> ������ </summary>
        public const string Col_SalesOrderCount = "SalesOrderCount";

        /// <summary> �݌ɋ敪 </summary>
        public const string Col_StockDiv = "StockDiv";

        /// <summary> �ړ����d���݌ɐ� </summary>
        public const string Col_MovingSupliStock = "MovingSupliStock";

        /// <summary> �o�׉\�� </summary>
        public const string Col_ShipmentPosCnt = "ShipmentPosCnt";

        /// <summary> �݌ɕۗL���z </summary>
        public const string Col_StockTotalPrice = "StockTotalPrice";

        /// <summary> �ŏI�d���N���� </summary>
        public const string Col_LastStockDate = "LastStockDate";

        /// <summary> �ŏI����� </summary>
        public const string Col_LastSalesDate = "LastSalesDate";

        /// <summary> �ŏI�I���X�V�� </summary>
        public const string Col_LastInventoryUpdate = "LastInventoryUpdate";

        /// <summary> �Œ�݌ɐ� </summary>
        public const string Col_MinimumStockCnt = "MinimumStockCnt";

        /// <summary> �ō��݌ɐ� </summary>
        public const string Col_MaximumStockCnt = "MaximumStockCnt";

        /// <summary> ������� </summary>
        public const string Col_NmlSalOdrCount = "NmlSalOdrCount";

        /// <summary> �����P�� </summary>
        public const string Col_SalesOrderUnit = "SalesOrderUnit";

        /// <summary> �݌ɔ�����R�[�h </summary>
        public const string Col_StockSupplierCode = "StockSupplierCode";

        /// <summary> �q�ɒI�� </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> �d���I�ԂP </summary>
        public const string Col_DuplicationShelfNo1 = "DuplicationShelfNo1";

        /// <summary> �d���I�ԂQ </summary>
        public const string Col_DuplicationShelfNo2 = "DuplicationShelfNo2";

        /// <summary> ���i�Ǘ��敪�P </summary>
        public const string Col_PartsManagementDivide1 = "PartsManagementDivide1";

        /// <summary> ���i�Ǘ��敪�Q </summary>
        public const string Col_PartsManagementDivide2 = "PartsManagementDivide2";

        /// <summary> �݌ɔ��l�P </summary>
        public const string Col_StockNote1 = "StockNote1";

        /// <summary> �݌ɔ��l�Q </summary>
        public const string Col_StockNote2 = "StockNote2";

        /// <summary> �o�א��i���v��j </summary>
        public const string Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> ���א��i���v��j </summary>
        public const string Col_ArrivalCnt = "ArrivalCnt";

        /// <summary> �݌ɓo�^�� </summary>
        public const string Col_StockCreateDate = "StockCreateDate";

        /// <summary> �X�V�N���� </summary>
        public const string Col_UpdateDate = "UpdateDate";

        /// <summary> ���_�K�C�h���� </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> �q�ɖ��� </summary>
        public const string Col_WarehouseName = "WarehouseName";

        /// <summary> ���[�J�[���� </summary>
        public const string Col_MakerShortName = "MakerShortName";

        /// <summary> �݌ɔ����於�� </summary>
        public const string Col_StockSupplierSnm = "StockSupplierSnm";

        /// <summary> ���i���� </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> BL���i�R�[�h </summary>
        public const string Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> BL���i�R�[�h���́i���p�j </summary>
        public const string Col_BLGoodsHalfName = "BLGoodsHalfName";

        /// <summary> ���i�啪�ރR�[�h </summary>
        public const string Col_GoodsLGroup = "GoodsLGroup";

        /// <summary> ���i�����ރR�[�h </summary>
        public const string Col_GoodsMGroup = "GoodsMGroup";

        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string Col_BLGroupCode = "BLGroupCode";

        /// <summary> BL�O���[�v�R�[�h�J�i���� </summary>
        public const string Col_BLGroupKanaName = "BLGroupKanaName";

        /// <summary> ���i�啪�ޖ��� </summary>
        public const string Col_GoodsLGroupName = "GoodsLGroupName";

        /// <summary> ���i�����ޖ��� </summary>
        public const string Col_GoodsMGroupName = "GoodsMGroupName";

        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> �d���旪�� </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> �艿�i�����j </summary>
        public const string Col_ListPrice = "ListPrice";

        /// <summary> �����P�� </summary>
        public const string Col_SalesUnitCost = "SalesUnitCost";


        /// <summary>
        /// �݌Ƀ}�X�^�ꗗ����e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�ꗗ����e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public RsltInfo_StockMasterTbl()
		{
		}

        /// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        static public void CreateDataTableResultStockMaster(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Col_Tbl_Result_StockMaster))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Col_Tbl_Result_StockMaster].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Col_Tbl_Result_StockMaster);

                DataTable dt = ds.Tables[Col_Tbl_Result_StockMaster];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_SectionCode, typeof(string));                // ���_�R�[�h
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));              // �q�ɃR�[�h
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));                // ���i���[�J�[�R�[�h
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                    // ���i�ԍ�
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockUnitPriceFl, typeof(Double));           // �d���P���i�Ŕ�,�����j
                dt.Columns[Col_StockUnitPriceFl].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SupplierStock, typeof(Double));              // �d���݌ɐ�
                dt.Columns[Col_SupplierStock].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AcpOdrCount, typeof(Double));                // �󒍐�
                dt.Columns[Col_AcpOdrCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_MonthOrderCount, typeof(Double));            // M/O������
                dt.Columns[Col_MonthOrderCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesOrderCount, typeof(Double));            // ������
                dt.Columns[Col_SalesOrderCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_StockDiv, typeof(Int32));                    // �݌ɋ敪
                dt.Columns[Col_StockDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MovingSupliStock, typeof(Double));           // �ړ����d���݌ɐ�
                dt.Columns[Col_MovingSupliStock].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ShipmentPosCnt, typeof(Double));             // �o�׉\��
                dt.Columns[Col_ShipmentPosCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_StockTotalPrice, typeof(Int64));             // �݌ɕۗL���z
                dt.Columns[Col_StockTotalPrice].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_LastStockDate, typeof(Int32));               // �ŏI�d���N����
                dt.Columns[Col_LastStockDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_LastSalesDate, typeof(Int32));               // �ŏI�����
                dt.Columns[Col_LastSalesDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_LastInventoryUpdate, typeof(Int32));         // �ŏI�I���X�V��
                dt.Columns[Col_LastInventoryUpdate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MinimumStockCnt, typeof(Double));            // �Œ�݌ɐ�
                dt.Columns[Col_MinimumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_MaximumStockCnt, typeof(Double));            // �ō��݌ɐ�
                dt.Columns[Col_MaximumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NmlSalOdrCount, typeof(Double));             // �������
                dt.Columns[Col_NmlSalOdrCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesOrderUnit, typeof(Int32));              // �����P��
                dt.Columns[Col_SalesOrderUnit].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StockSupplierCode, typeof(Int32));           // �݌ɔ�����R�[�h
                dt.Columns[Col_StockSupplierCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));           // �q�ɒI��
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DuplicationShelfNo1, typeof(string));        // �d���I�ԂP
                dt.Columns[Col_DuplicationShelfNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DuplicationShelfNo2, typeof(string));        // �d���I�ԂQ
                dt.Columns[Col_DuplicationShelfNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PartsManagementDivide1, typeof(string));     // ���i�Ǘ��敪�P
                dt.Columns[Col_PartsManagementDivide1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PartsManagementDivide2, typeof(string));     // ���i�Ǘ��敪�Q
                dt.Columns[Col_PartsManagementDivide2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockNote1, typeof(string));                 // �݌ɔ��l�P
                dt.Columns[Col_StockNote1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockNote2, typeof(string));                 // �݌ɔ��l�Q
                dt.Columns[Col_StockNote2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ShipmentCnt, typeof(Double));                // �o�א��i���v��j
                dt.Columns[Col_ShipmentCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ArrivalCnt, typeof(Double));                 // ���א��i���v��j
                dt.Columns[Col_ArrivalCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_StockCreateDate, typeof(Int32));             // �݌ɓo�^��
                dt.Columns[Col_StockCreateDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UpdateDate, typeof(Int32));                  // �X�V�N����
                dt.Columns[Col_UpdateDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));            // ���_�K�C�h����
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));              // �q�ɖ���
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MakerShortName, typeof(string));             // ���[�J�[����
                dt.Columns[Col_MakerShortName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockSupplierSnm, typeof(string));           // �݌ɔ����於��
                dt.Columns[Col_StockSupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));                  // ���i����
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGoodsCode, typeof(Int32));                 // BL���i�R�[�h
                dt.Columns[Col_BLGoodsCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGoodsHalfName, typeof(string));            // BL���i�R�[�h���́i���p�j
                dt.Columns[Col_BLGoodsHalfName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsLGroup, typeof(Int32));                 // ���i�啪�ރR�[�h
                dt.Columns[Col_GoodsLGroup].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsMGroup, typeof(Int32));                 // ���i�����ރR�[�h
                dt.Columns[Col_GoodsMGroup].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGroupCode, typeof(Int32));                 // BL�O���[�v�R�[�h
                dt.Columns[Col_BLGroupCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGroupKanaName, typeof(string));            // BL�O���[�v�R�[�h�J�i����
                dt.Columns[Col_BLGroupKanaName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsLGroupName, typeof(string));            // ���i�啪�ޖ���
                dt.Columns[Col_GoodsLGroupName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMGroupName, typeof(string));            // ���i�����ޖ���
                dt.Columns[Col_GoodsMGroupName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                  // �d����R�[�h
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                // �d���旪��
                dt.Columns[Col_SupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ListPrice, typeof(Double));                  // �艿�i�����j
                dt.Columns[Col_ListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesUnitCost, typeof(Double));              // �����P��
                dt.Columns[Col_SalesUnitCost].DefaultValue = defValueDouble;

            }
        }
    }
}

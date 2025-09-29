using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\ ���[�󎚗p�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\�̒��[�󎚗p�̂P�s�f�[�^��ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02145EB
    {
        #region �� Public�萔
        // --����--
        // �e�[�u������
        public const string ct_Tbl_ShipGdsPrimeListResultForPrint = "ShipGdsPrimeListResultForPrint";
        // ���_�R�[�h
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // ���_����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        // --����p--
        // 1�s�Ɋ܂܂��D�Ǖi��
        public const string ct_Col_PartsCount = "PartsCount";
        // �����ׂ̉��s�ڂ�
        public const string ct_Col_RowNumber = "RowNumber";
        
        // --�v�󎚗p--
        // 1�����i�̔��㐔�v(�݌�)���v
        public const string ct_Col_Pure_StockTotalSalesCountSum = "Pure_StockTotalSalesCountSum";
        // 1�����i�̔��㐔�v(���)���v
        public const string ct_Col_Pure_OrderTotalSalesCountSum = "Pure_OrderTotalSalesCountSum";
        // 1�s�̗D�Ǖi���㐔�v(�݌�)���v
        public const string ct_Col_Parts_StockTotalSalesCountSum = "Parts_StockTotalSalesCountSum";
        // 1�s�̗D�Ǖi���㐔�v(���)���v
        public const string ct_Col_Parts_OrderTotalSalesCountSum = "Parts_OrderTotalSalesCountSum";

        // --�����i�֘A--
        // �I��
        public const string ct_Col_Pure_WarehouseShelfNo = "Pure_WarehouseShelfNo";
        // �������[�J�[�R�[�h
        public const string ct_Col_Pure_MakerCode = "Pure_MakerCode";
        // �������[�J�[����
        public const string ct_Col_Pure_GoodsMakerName = "Pure_GoodsMakerName";
        // ���i�����ރR�[�h
        public const string ct_Col_Pure_GoodsMGroup = "Pure_GoodsMGroup";
        // ���i�����ޖ���
        public const string ct_Col_Pure_GoodsMGroupName = "Pure_GoodsMGroupName";
        // �O���[�v�R�[�h
        public const string ct_Col_Pure_BLGroupCode = "Pure_BLGroupCode";
        // �O���[�v�R�[�h����
        public const string ct_Col_Pure_BLGroupCodeName = "Pure_BLGroupCodeName";
        // �����i��
        public const string ct_Col_Pure_GoodsNo = "Pure_GoodsNo";
        // �i��
        public const string ct_Col_Pure_GoodsName = "Pure_GoodsName";
        // �e����
        public const string ct_Col_Pure_GrossProfitRate = "Pure_GrossProfitRate";
        // ���i
        public const string ct_Col_Pure_GoodsPrice = "Pure_GoodsPrice";
        // ���݌Ɂi�d���݌ɐ��j
        public const string ct_Col_Pure_SupplierStock = "Pure_SupplierStock";
        // ���㐔�v(�݌�)
        public const string ct_Col_Pure_StockTotalSalesCount = "Pure_StockTotalSalesCount";
        // ���㐔�v(���)
        public const string ct_Col_Pure_OrderTotalSalesCount = "Pure_OrderTotalSalesCount";

        // --�D�Ǖi��1�֘A--
        // �I��1
        public const string ct_Col_Parts1_WarehouseShelfNo = "Parts1_WarehouseShelfNo";
        // �O���[�v�R�[�h1
        public const string ct_Col_Parts1_BLGroupCode = "Parts1_BLGroupCode";
        // �Q�l�i��1
        public const string ct_Col_Parts1_GoodsNo = "Parts1_GoodsNo";
        // �d����1
        public const string ct_Col_Parts1_SuplierCode = "Parts1_SuplierCode";
        // ���[�J�[1
        public const string ct_Col_Parts1_MakerCode = "Parts1_MakerCode";
        // ���i1
        public const string ct_Col_Parts1_GoodsPrice = "Parts1_GoodsPrice";
        // �e����1
        public const string ct_Col_Parts1_GrossProfitRate = "Parts1_GrossProfitRate";
        // ���݌�1�i�d���݌ɐ��j
        public const string ct_Col_Parts1_SupplierStock = "Parts1_SupplierStock";
        // ���㐔�v1�i�݌Ɂj
        public const string ct_Col_Parts1_StockTotalSalesCount = "Parts1_StockTotalSalesCount";
        // ���㐔�v1�i���j
        public const string ct_Col_Parts1_OrderTotalSalesCount = "Parts1_OrderTotalSalesCount";

        // --�D�Ǖi��2�֘A--
        // �I��2
        public const string ct_Col_Parts2_WarehouseShelfNo = "Parts2_WarehouseShelfNo";
        // �O���[�v�R�[�h2
        public const string ct_Col_Parts2_BLGroupCode = "Parts2_BLGroupCode";
        // �Q�l�i��2
        public const string ct_Col_Parts2_GoodsNo = "Parts2_GoodsNo";
        // �d����2
        public const string ct_Col_Parts2_SuplierCode = "Parts2_SuplierCode";
        // ���[�J�[2
        public const string ct_Col_Parts2_MakerCode = "Parts2_MakerCode";
        // ���i2
        public const string ct_Col_Parts2_GoodsPrice = "Parts2_GoodsPrice";
        // �e����2
        public const string ct_Col_Parts2_GrossProfitRate = "Parts2_GrossProfitRate";
        // ���݌�2�i�d���݌ɐ��j
        public const string ct_Col_Parts2_SupplierStock = "Parts2_SupplierStock";
        // ���㐔�v2�i�݌Ɂj
        public const string ct_Col_Parts2_StockTotalSalesCount = "Parts2_StockTotalSalesCount";
        // ���㐔�v2�i���j
        public const string ct_Col_Parts2_OrderTotalSalesCount = "Parts2_OrderTotalSalesCount";
        
        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02145EB()
        {
        }

        #endregion

        #region �� public���\�b�h
        static public void CreateDataTable(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_ShipGdsPrimeListResultForPrint);

                // --����--
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // ���_����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // --����p--
                // 1�s�Ɋ܂܂��D�Ǖi��
                dt.Columns.Add(ct_Col_PartsCount, typeof(Int32));
                dt.Columns[ct_Col_PartsCount].DefaultValue = 0;

                // // �����ׂ̉��s�ڂ�
                dt.Columns.Add(ct_Col_RowNumber, typeof(Int32));
                dt.Columns[ct_Col_RowNumber].DefaultValue = 0;

                // --�v�󎚗p--
                // 1�����i�̔��㐔�v(�݌�)���v
                dt.Columns.Add(ct_Col_Pure_StockTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Pure_StockTotalSalesCountSum].DefaultValue = 0;

                // 1�����i�̔��㐔�v(���)���v
                dt.Columns.Add(ct_Col_Pure_OrderTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Pure_OrderTotalSalesCountSum].DefaultValue = 0;

                // 1�s�̗D�Ǖi���㐔�v(�݌�)���v
                dt.Columns.Add(ct_Col_Parts_StockTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Parts_StockTotalSalesCountSum].DefaultValue = 0;

                // 1�s�̗D�Ǖi���㐔�v(���)���v
                dt.Columns.Add(ct_Col_Parts_OrderTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Parts_OrderTotalSalesCountSum].DefaultValue = 0;

                // --�����i�֘A--
                // �I��
                dt.Columns.Add(ct_Col_Pure_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Pure_WarehouseShelfNo].DefaultValue = string.Empty;

                // �������[�J�[�R�[�h
                dt.Columns.Add(ct_Col_Pure_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Pure_MakerCode].DefaultValue = 0;

                // �������[�J�[����
                dt.Columns.Add(ct_Col_Pure_GoodsMakerName, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsMakerName].DefaultValue = string.Empty;

                // ���i�����ރR�[�h
                dt.Columns.Add(ct_Col_Pure_GoodsMGroup, typeof(Int32));
                dt.Columns[ct_Col_Pure_GoodsMGroup].DefaultValue = 0;

                // ���i�����ޖ���
                dt.Columns.Add(ct_Col_Pure_GoodsMGroupName, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsMGroupName].DefaultValue = string.Empty;

                // �O���[�v�R�[�h
                dt.Columns.Add(ct_Col_Pure_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Pure_BLGroupCode].DefaultValue = 0;

                // �O���[�v�R�[�h����
                dt.Columns.Add(ct_Col_Pure_BLGroupCodeName, typeof(string));
                dt.Columns[ct_Col_Pure_BLGroupCodeName].DefaultValue = string.Empty;

                // �����i��
                dt.Columns.Add(ct_Col_Pure_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsNo].DefaultValue = string.Empty;

                // �i��
                dt.Columns.Add(ct_Col_Pure_GoodsName, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsName].DefaultValue = string.Empty;

                // �e����
                dt.Columns.Add(ct_Col_Pure_GrossProfitRate, typeof(double));
                dt.Columns[ct_Col_Pure_GrossProfitRate].DefaultValue = 0;

                // ���i
                dt.Columns.Add(ct_Col_Pure_GoodsPrice, typeof(double));
                dt.Columns[ct_Col_Pure_GoodsPrice].DefaultValue = 0;

                // ���݌Ɂi�d���݌ɐ��j
                dt.Columns.Add(ct_Col_Pure_SupplierStock, typeof(double));
                dt.Columns[ct_Col_Pure_SupplierStock].DefaultValue = 0;

                // ���㐔�v(�݌�)
                dt.Columns.Add(ct_Col_Pure_StockTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Pure_StockTotalSalesCount].DefaultValue = 0;

                // ���㐔�v(���)
                dt.Columns.Add(ct_Col_Pure_OrderTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Pure_OrderTotalSalesCount].DefaultValue = 0;

                // --�D�Ǖi��1�֘A--
                // �I��1
                dt.Columns.Add(ct_Col_Parts1_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Parts1_WarehouseShelfNo].DefaultValue = string.Empty;
                
                // �O���[�v�R�[�h1
                dt.Columns.Add(ct_Col_Parts1_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Parts1_BLGroupCode].DefaultValue = 0;

                // �Q�l�i��1
                dt.Columns.Add(ct_Col_Parts1_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Parts1_GoodsNo].DefaultValue = string.Empty;

                // �d����1
                dt.Columns.Add(ct_Col_Parts1_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_Parts1_SuplierCode].DefaultValue = 0;

                // ���[�J�[1
                dt.Columns.Add(ct_Col_Parts1_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Parts1_MakerCode].DefaultValue = 0;

                // ���i1
                dt.Columns.Add(ct_Col_Parts1_GoodsPrice, typeof(double));
                dt.Columns[ct_Col_Parts1_GoodsPrice].DefaultValue = 0;

                // �e����1
                dt.Columns.Add(ct_Col_Parts1_GrossProfitRate, typeof(double));
                dt.Columns[ct_Col_Parts1_GrossProfitRate].DefaultValue = 0;

                // ���݌�1�i�d���݌ɐ��j
                dt.Columns.Add(ct_Col_Parts1_SupplierStock, typeof(double));
                dt.Columns[ct_Col_Parts1_SupplierStock].DefaultValue = 0;

                // ���㐔�v1�i�݌Ɂj
                dt.Columns.Add(ct_Col_Parts1_StockTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts1_StockTotalSalesCount].DefaultValue = 0;

                // ���㐔�v1�i���j
                dt.Columns.Add(ct_Col_Parts1_OrderTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts1_OrderTotalSalesCount].DefaultValue = 0;

                // --�D�Ǖi��2�֘A--
                // �I��2
                dt.Columns.Add(ct_Col_Parts2_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Parts2_WarehouseShelfNo].DefaultValue = string.Empty;

                // �O���[�v�R�[�h2
                dt.Columns.Add(ct_Col_Parts2_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Parts2_BLGroupCode].DefaultValue = 0;

                // �Q�l�i��2
                dt.Columns.Add(ct_Col_Parts2_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Parts2_GoodsNo].DefaultValue = string.Empty;

                // �d����2
                dt.Columns.Add(ct_Col_Parts2_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_Parts2_SuplierCode].DefaultValue = 0;

                // ���[�J�[2
                dt.Columns.Add(ct_Col_Parts2_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Parts2_MakerCode].DefaultValue = 0;

                // ���i2
                dt.Columns.Add(ct_Col_Parts2_GoodsPrice, typeof(double));
                dt.Columns[ct_Col_Parts2_GoodsPrice].DefaultValue = 0;

                // �e����2
                dt.Columns.Add(ct_Col_Parts2_GrossProfitRate, typeof(double));
                dt.Columns[ct_Col_Parts2_GrossProfitRate].DefaultValue = 0;

                // ���݌�2�i�d���݌ɐ��j
                dt.Columns.Add(ct_Col_Parts2_SupplierStock, typeof(double));
                dt.Columns[ct_Col_Parts2_SupplierStock].DefaultValue = 0;

                // ���㐔�v2�i�݌Ɂj
                dt.Columns.Add(ct_Col_Parts2_StockTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts2_StockTotalSalesCount].DefaultValue = 0;

                // ���㐔�v2�i���j
                dt.Columns.Add(ct_Col_Parts2_OrderTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts2_OrderTotalSalesCount].DefaultValue = 0;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �݌ɊŔ�� �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊŔ���̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMZAI02059EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_StockSignResult = "ct_Tbl_StockSignResult";
        // ��ƃR�[�h
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // �q�ɃR�[�h
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        // �q�ɒI��
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo = "GoodsNo";
        // ���i���̃J�i
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        // �Œ�݌ɐ�
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        // �ō��݌ɐ�
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";
        // �݌ɓo�^��
        public const string ct_Col_StockCreateDate = "StockCreateDate";
        // ���i�J�n��
        public const string ct_Col_PriceStartDate = "PriceStartDate";
        // �艿�i�����j
        public const string ct_Col_ListPrice = "ListPrice";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        // ���_�R�[�h
        public const string ct_Col_SectionCode = "SectionCode";
        // �d���݌ɐ�
        public const string ct_Col_SupplierStock = "SupplierStock";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMZAI02059EA()
        {
        }

        #endregion

        #region �� public���\�b�h
        /// <summary>
        /// �݌ɊŔ��DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �݌ɊŔ���f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
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
                dt = new DataTable(ct_Tbl_StockSignResult);

                // ��ƃR�[�h
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = string.Empty;

                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = string.Empty;

                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = string.Empty;

                // �Œ�݌ɐ�
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;

                // �ō��݌ɐ�
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;

                // �݌ɓo�^��
                dt.Columns.Add(ct_Col_StockCreateDate, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate].DefaultValue = DateTime.MinValue;

                // ���i�J�n��
                dt.Columns.Add(ct_Col_PriceStartDate, typeof(DateTime));
                dt.Columns[ct_Col_PriceStartDate].DefaultValue = DateTime.MinValue;

                // �艿�i�����j
                dt.Columns.Add(ct_Col_ListPrice, typeof(double));
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;

                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;

                // �d���݌ɐ�
                dt.Columns.Add(ct_Col_SupplierStock, typeof(double));
                dt.Columns[ct_Col_SupplierStock].DefaultValue = 0;
            }
        }
        #endregion
    }
}

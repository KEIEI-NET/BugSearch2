using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d�����͕\ �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͕\�̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKOU02025EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_SlipHistAnalyzeResult = "SlipHistAnalyzeResult";

        // �v�㋒�_�R�[�h
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // ���_�K�C�h����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // �d����R�[�h
        public const string ct_Col_SupplierCd = "SupplierCd";
        // �d���旪��
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // �d�����z���v(����)
        public const string ct_Col_TotalPrice = "TotalPrice";
        // �d���ԕi�z(����)
        public const string ct_Col_RetGoodsPrice = "RetGoodsPrice";
        // �d���l���v(����)
        public const string ct_Col_TotalDiscount = "TotalDiscount";
        // �d�����z���v(�����݌�)
        public const string ct_Col_TotalPriceStock = "TotalPriceStock";
        // �d�����z���v(�������v)
        public const string ct_Col_TotalPriceTotal = "TotalPriceTotal";

        // �d�����z���v(����)
        public const string ct_Col_AnnualTotalPrice = "AnnualTotalPrice";
        // �d���ԕi�z(����)
        public const string ct_Col_AnnualRetGoodsPrice = "AnnualRetGoodsPrice";
        // �d���l���v(����)
        public const string ct_Col_AnnualTotalDiscount = "AnnualTotalDiscount";
        // �d�����z���v(�����݌�)
        public const string ct_Col_AnnualTotalPriceStock = "AnnualTotalPriceStock";
        // �d�����z���v(�������v)
        public const string ct_Col_AnnualTotalPriceTotal = "AnnualTotalPriceTotal";

        // --���[�󎚍���--
        // ���d���i�����j
        public const string ct_Col_PureTotalPrice = "PureTotalPrice";
        // ���d�����v�i�����j (�\����p)
        public const string ct_Col_PureTotalPriceSum = "PureTotalPriceSum";
        // �݌Ɋz�i�����j
        public const string ct_Col_StockPrice = "StockPrice";
        // ���z�i�����j
        public const string ct_Col_OrderPrice = "OrderPrice";
        
        // ���d���i�����j
        public const string ct_Col_AnnualPureTotalPrice = "AnnualPureTotalPrice";
        // ���d�����v�i�����j (�\����p)
        public const string ct_Col_AnnualPureTotalPriceSum = "AnnualPureTotalPriceSum";
        // �݌Ɋz�i�����j
        public const string ct_Col_AnnualStockPrice = "AnnualStockPrice";
        // ���z�i�����j
        public const string ct_Col_AnnualOrderPrice = "AnnualOrderPrice";

        // --���v�Z�p����(���z�P�ʂ��l�����Ȃ��l)--
        // �d�����z���v(����)
        public const string ct_Col_TotalPriceOrg = "TotalPriceOrg";
        // �d���ԕi�z(����)
        public const string ct_Col_RetGoodsPriceOrg = "RetGoodsPriceOrg";
        // �d���l���v(����)
        public const string ct_Col_TotalDiscountOrg = "TotalDiscountOrg";
        // ���d���i�����j
        public const string ct_Col_PureTotalPriceOrg = "PureTotalPriceOrg";
        // �݌Ɋz�i�����j
        public const string ct_Col_StockPriceOrg = "StockPriceOrg";
        // ���z�i�����j
        public const string ct_Col_OrderPriceOrg = "OrderPriceOrg";

        // �d�����z���v(����)
        public const string ct_Col_AnnualTotalPriceOrg = "AnnualTotalPriceOrg";
        // �d���ԕi�z(����)
        public const string ct_Col_AnnualRetGoodsPriceOrg = "AnnualRetGoodsPriceOrg";
        // �d���l���v(����)
        public const string ct_Col_AnnualTotalDiscountOrg = "AnnualTotalDiscountOrg";
        // ���d���i�����j
        public const string ct_Col_AnnualPureTotalPriceOrg = "AnnualPureTotalPriceOrg";
        // �݌Ɋz�i�����j
        public const string ct_Col_AnnualStockPriceOrg = "AnnualStockPriceOrg";
        // ���z�i�����j
        public const string ct_Col_AnnualOrderPriceOrg = "AnnualOrderPriceOrg";
        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMKOU02025EA()
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
                dt = new DataTable(ct_Tbl_SlipHistAnalyzeResult);

                // �v�㋒�_�R�[�h
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // �d����R�[�h
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                // �d���旪��
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = string.Empty;

                // �d�����z���v(����)
                dt.Columns.Add(ct_Col_TotalPrice, typeof(Int64));
                dt.Columns[ct_Col_TotalPrice].DefaultValue = 0;

                // �d���ԕi�z(����)
                dt.Columns.Add(ct_Col_RetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_RetGoodsPrice].DefaultValue = 0;

                // �d���l���v(����)
                dt.Columns.Add(ct_Col_TotalDiscount, typeof(Int64));
                dt.Columns[ct_Col_TotalDiscount].DefaultValue = 0;

                // �d�����z���v(�����݌�)
                dt.Columns.Add(ct_Col_TotalPriceStock, typeof(Int64));
                dt.Columns[ct_Col_TotalPriceStock].DefaultValue = 0;

                // �d�����z���v(�������v)
                dt.Columns.Add(ct_Col_TotalPriceTotal, typeof(Int64));
                dt.Columns[ct_Col_TotalPriceTotal].DefaultValue = 0;

                // �d�����z���v(����)
                dt.Columns.Add(ct_Col_AnnualTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPrice].DefaultValue = 0;

                // �d���ԕi�z(����)
                dt.Columns.Add(ct_Col_AnnualRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualRetGoodsPrice].DefaultValue = 0;

                // �d���l���v(����)
                dt.Columns.Add(ct_Col_AnnualTotalDiscount, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalDiscount].DefaultValue = 0;

                // �d�����z���v(�����݌�)
                dt.Columns.Add(ct_Col_AnnualTotalPriceStock, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPriceStock].DefaultValue = 0;

                // �d�����z���v(�������v)
                dt.Columns.Add(ct_Col_AnnualTotalPriceTotal, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPriceTotal].DefaultValue = 0;

                // ���d���i�����j
                dt.Columns.Add(ct_Col_PureTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_PureTotalPrice].DefaultValue = 0;

                // ���d�����v�i�����j (�\����p)
                dt.Columns.Add(ct_Col_PureTotalPriceSum, typeof(Int64));
                dt.Columns[ct_Col_PureTotalPriceSum].DefaultValue = 0;

                // �݌Ɋz�i�����j
                dt.Columns.Add(ct_Col_StockPrice, typeof(Int64));
                dt.Columns[ct_Col_StockPrice].DefaultValue = 0;

                // ���z�i�����j
                dt.Columns.Add(ct_Col_OrderPrice, typeof(Int64));
                dt.Columns[ct_Col_OrderPrice].DefaultValue = 0;

                // ���d���i�����j
                dt.Columns.Add(ct_Col_AnnualPureTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureTotalPrice].DefaultValue = 0;

                // ���d�����v�i�����j (�\����p)
                dt.Columns.Add(ct_Col_AnnualPureTotalPriceSum, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureTotalPriceSum].DefaultValue = 0;

                // �݌Ɋz�i�����j
                dt.Columns.Add(ct_Col_AnnualStockPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualStockPrice].DefaultValue = 0;

                // ���z�i�����j
                dt.Columns.Add(ct_Col_AnnualOrderPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualOrderPrice].DefaultValue = 0;

                // --���v�Z�p����--
                // �d�����z���v(����)
                dt.Columns.Add(ct_Col_TotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalPriceOrg].DefaultValue = 0;

                // �d���ԕi�z(����)
                dt.Columns.Add(ct_Col_RetGoodsPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_RetGoodsPriceOrg].DefaultValue = 0;

                // �d���l���v(����)
                dt.Columns.Add(ct_Col_TotalDiscountOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalDiscountOrg].DefaultValue = 0;

                // ���d���i�����j
                dt.Columns.Add(ct_Col_PureTotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_PureTotalPriceOrg].DefaultValue = 0;

                // �݌Ɋz�i�����j
                dt.Columns.Add(ct_Col_StockPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_StockPriceOrg].DefaultValue = 0;

                // ���z�i�����j
                dt.Columns.Add(ct_Col_OrderPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_OrderPriceOrg].DefaultValue = 0;

                // �d�����z���v(����)
                dt.Columns.Add(ct_Col_AnnualTotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPriceOrg].DefaultValue = 0;

                // �d���ԕi�z(����)
                dt.Columns.Add(ct_Col_AnnualRetGoodsPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualRetGoodsPriceOrg].DefaultValue = 0;

                // �d���l���v(����)
                dt.Columns.Add(ct_Col_AnnualTotalDiscountOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalDiscountOrg].DefaultValue = 0;

                // ���d���i�����j
                dt.Columns.Add(ct_Col_AnnualPureTotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureTotalPriceOrg].DefaultValue = 0;

                // �݌Ɋz�i�����j
                dt.Columns.Add(ct_Col_AnnualStockPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualStockPriceOrg].DefaultValue = 0;

                // ���z�i�����j
                dt.Columns.Add(ct_Col_AnnualOrderPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualOrderPriceOrg].DefaultValue = 0;
            }
        }

        #endregion
    }
}

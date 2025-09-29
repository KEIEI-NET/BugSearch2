using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\ �f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\�̃f�[�^��ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br>Update Note: 2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02145EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_ShipGdsPrimeListResult = "ShipGdsPrimeListResult";
        // ��ƃR�[�h
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // �v�㋒�_�R�[�h
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // ���_�K�C�h����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // ���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        // ���[�J�[����
        public const string ct_Col_GoodsMakerName = "GoodsMakerName";
        // �i��
        public const string ct_Col_GoodsNo = "GoodsNo";
        //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
        // �Ή��i��
        public const string ct_Col_OldGoodsNo = "OldGoodsNo";
        //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<
        // ����񐔁i�݌Ɂj
        public const string ct_Col_St_SalesTimes = "St_SalesTimes";
        // ���㐔�v�i�݌Ɂj
        public const string ct_Col_St_TotalSalesCount = "St_TotalSalesCount";
        // ������z�i�݌Ɂj
        public const string ct_Col_St_SalesMoney = "St_SalesMoney";
        // �ԕi�z�i�݌Ɂj
        public const string ct_Col_St_SalesRetGoodsPrice = "St_SalesRetGoodsPrice";
        // �l�����z�i�݌Ɂj
        public const string ct_Col_St_DiscountPrice = "St_DiscountPrice";
        // �e�����z�i�݌Ɂj
        public const string ct_Col_St_GrossProfit = "St_GrossProfit";
        // ����񐔁i���j
        public const string ct_Col_Or_SalesTimes = "Or_SalesTimes";
        // ���㐔�v�i���j
        public const string ct_Col_Or_TotalSalesCount = "Or_TotalSalesCount";
        // ������z�i���j
        public const string ct_Col_Or_SalesMoney = "Or_SalesMoney";
        // �ԕi�z�i���j
        public const string ct_Col_Or_SalesRetGoodsPrice = "Or_SalesRetGoodsPrice";
        // �l�����z�i���j
        public const string ct_Col_Or_DiscountPrice = "Or_DiscountPrice";
        // �e�����z�i���j
        public const string ct_Col_Or_GrossProfit = "Or_GrossProfit";

        // ���ʕt�p����
        // ����
        public const string ct_Col_Order = "Order";
        // ���㐔�v�i�݌� + ���j
        public const string ct_Col_Sum_TotalSalesCount = "Sum_TotalSalesCount";

        // ���i�}�X�^(�݌Ƀ}�X�^�A���i�}�X�^)����̎擾����
        // �I��
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        // ���i�����ރR�[�h
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        // ���i�����ޖ���
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        // BL�O���[�v�R�[�h
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        // �O���[�v�R�[�h����
        public const string ct_Col_BLGroupCodeName = "BLGroupCodeName";
        // �d����
        public const string ct_Col_SuplierCode = "SuplierCode";
        // �i��
        public const string ct_Col_GoodsName = "GoodsName";
        // ���i
        public const string ct_Col_ListPrice = "ListPrice";
        // ���݌�
        public const string ct_Col_SupplierStock = "SupplierStock";

        // �����}�X�^����̎擾����
        // �D�Ǖi��
        public const string ct_Col_PartsCount = "PartsCount";
        // �D�Ǖi ���i��񃊃X�g
        public const string ct_Col_GoodsUnitDataList = "GoodsUnitDataList";
        // �D�Ǖi �����W�v��񃊃X�g
        public const string ct_Col_ShipGdsPrimeListResultList = "ShipGdsPrimeListResultList";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02145EA()
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
                dt = new DataTable(ct_Tbl_ShipGdsPrimeListResult);

                // ��ƃR�[�h
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // �v�㋒�_�R�[�h
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                // ���[�J�[����
                dt.Columns.Add(ct_Col_GoodsMakerName, typeof(string));
                dt.Columns[ct_Col_GoodsMakerName].DefaultValue = string.Empty;

                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_OldGoodsNo, typeof(string));
                dt.Columns[ct_Col_OldGoodsNo].DefaultValue = string.Empty;
                //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

                // ����񐔁i�݌Ɂj
                dt.Columns.Add(ct_Col_St_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_St_SalesTimes].DefaultValue = 0;

                // ���㐔�v�i�݌Ɂj
                dt.Columns.Add(ct_Col_St_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_St_TotalSalesCount].DefaultValue = 0;

                // ������z�i�݌Ɂj
                dt.Columns.Add(ct_Col_St_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_St_SalesMoney].DefaultValue = 0;

                // �ԕi�z�i�݌Ɂj
                dt.Columns.Add(ct_Col_St_SalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_St_SalesRetGoodsPrice].DefaultValue = 0;

                // �l�����z�i�݌Ɂj
                dt.Columns.Add(ct_Col_St_DiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_St_DiscountPrice].DefaultValue = 0;

                // �e�����z�i�݌Ɂj
                dt.Columns.Add(ct_Col_St_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_St_GrossProfit].DefaultValue = 0;

                // ����񐔁i���j
                dt.Columns.Add(ct_Col_Or_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Or_SalesTimes].DefaultValue = 0;

                // ���㐔�v�i���j
                dt.Columns.Add(ct_Col_Or_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Or_TotalSalesCount].DefaultValue = 0;

                // ������z�i���j
                dt.Columns.Add(ct_Col_Or_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_Or_SalesMoney].DefaultValue = 0;

                // �ԕi�z�i���j
                dt.Columns.Add(ct_Col_Or_SalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_Or_SalesRetGoodsPrice].DefaultValue = 0;

                // �l�����z�i���j
                dt.Columns.Add(ct_Col_Or_DiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_Or_DiscountPrice].DefaultValue = 0;

                // �e�����z�i���j
                dt.Columns.Add(ct_Col_Or_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_Or_GrossProfit].DefaultValue = 0;


                // ����
                dt.Columns.Add(ct_Col_Order, typeof(Int32));
                dt.Columns[ct_Col_Order].DefaultValue = 0;

                // ���㐔�v�i�݌� + ���j
                dt.Columns.Add(ct_Col_Sum_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Sum_TotalSalesCount].DefaultValue = 0;

                // �I��
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = string.Empty;

                // ���i�����ރR�[�h
                dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));
                dt.Columns[ct_Col_GoodsMGroup].DefaultValue = 0;

                // ���i�����ޖ���
                dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string));
                dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = string.Empty;

                // �a�k�O���[�v�R�[�h
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;

                // �a�k�O���[�v�R�[�h����
                dt.Columns.Add(ct_Col_BLGroupCodeName, typeof(string));
                dt.Columns[ct_Col_BLGroupCodeName].DefaultValue = string.Empty;

                // �d����R�[�h
                dt.Columns.Add(ct_Col_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_SuplierCode].DefaultValue = 0;

                // �i��
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = string.Empty;

                // ���i
                dt.Columns.Add(ct_Col_ListPrice, typeof(double));
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;

                // ���݌�
                dt.Columns.Add(ct_Col_SupplierStock, typeof(double));
                dt.Columns[ct_Col_SupplierStock].DefaultValue = 0;

                // ���݌�
                dt.Columns.Add(ct_Col_PartsCount, typeof(Int32));
                dt.Columns[ct_Col_PartsCount].DefaultValue = 0;

                // �D�Ǖi ���i��񃊃X�g
                dt.Columns.Add(ct_Col_GoodsUnitDataList, typeof(List<GoodsUnitData>));
                dt.Columns[ct_Col_GoodsUnitDataList].DefaultValue = new List<GoodsUnitData>();

                // �D�Ǖi �����W�v��񃊃X�g
                dt.Columns.Add(ct_Col_ShipGdsPrimeListResultList, typeof(ArrayList));
                dt.Columns[ct_Col_ShipGdsPrimeListResultList].DefaultValue = new ArrayList();
            }
        }

        #endregion

    }
}

using System;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���Ӑ�ʉߔN�x���v�\ �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʉߔN�x���v�\�̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02135EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_CustFinancialRsltList = "CustFinancialRsltList";
        // ��ƃR�[�h
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // �v�㋒�_�R�[�h
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // ���_�K�C�h����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // ���Ӑ�R�[�h
        public const string ct_Col_CustomerCode = "CustomerCode";
        // ���Ӑ旪��
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        // ������z
        public const string ct_Col_SalesMoney = "SalesMoney";
        // �ԕi�z
        public const string ct_Col_SalesRetGoodsPrice = "SalesRetGoodsPrice";
        // �l�����z
        public const string ct_Col_DiscountPrice = "DiscountPrice";
        // �e�����z
        public const string ct_Col_GrossProfit = "GrossProfit";
        // ��v�N�x
        public const string ct_Col_FinancialYear = "FinancialYear";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02135EA()
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
                dt = new DataTable(ct_Tbl_CustFinancialRsltList);

                // ��ƃR�[�h
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // �v�㋒�_�R�[�h
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // ���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;

                // ������z
                dt.Columns.Add(ct_Col_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = 0;

                // �ԕi�z
                dt.Columns.Add(ct_Col_SalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_SalesRetGoodsPrice].DefaultValue = 0;

                // �l�����z
                dt.Columns.Add(ct_Col_DiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_DiscountPrice].DefaultValue = 0;

                // �e�����z
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;

                // ��v�N�x
                dt.Columns.Add(ct_Col_FinancialYear, typeof(Int32));
                dt.Columns[ct_Col_FinancialYear].DefaultValue = 0;
            }
        }
        #endregion
    }
}

using System;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���Ӑ�ʉߔN�x���v�\ ���[�󎚗p�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʉߔN�x���v�\�̒��[�󎚗p�f�[�^��ێ��B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02135EB
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_CustFinancialRsltListForPrint = "CustFinancialRsltPrintListForPrint";
        // ���_�R�[�h
        public const string ct_Col_SectionCode = "SectionCode";
        // ���_����
        public const string ct_Col_SectionName = "SectionName";
        // ���Ӑ�R�[�h
        public const string ct_Col_CustomerCode = "CustomerCode";
        // ���Ӑ於��
        public const string ct_Col_CustomerName = "CustomerName";
        // ������z1
        public const string ct_Col_SalesMoney1 = "SalesMoney1";
        // ������z2
        public const string ct_Col_SalesMoney2 = "SalesMoney2";
        // ������z3
        public const string ct_Col_SalesMoney3 = "SalesMoney3";
        // ������z4
        public const string ct_Col_SalesMoney4 = "SalesMoney4";
        // ������z5
        public const string ct_Col_SalesMoney5 = "SalesMoney5";
        // ������z6
        public const string ct_Col_SalesMoney6 = "SalesMoney6";
        // ������z7
        public const string ct_Col_SalesMoney7 = "SalesMoney7";
        // ������z8
        public const string ct_Col_SalesMoney8 = "SalesMoney8";
        // �e�����z1
        public const string ct_Col_GrossProfit1 = "GrossProfit1";
        // �e�����z2
        public const string ct_Col_GrossProfit2 = "GrossProfit2";
        // �e�����z3
        public const string ct_Col_GrossProfit3 = "GrossProfit3";
        // �e�����z4
        public const string ct_Col_GrossProfit4 = "GrossProfit4";
        // �e�����z5
        public const string ct_Col_GrossProfit5 = "GrossProfit5";
        // �e�����z6
        public const string ct_Col_GrossProfit6 = "GrossProfit6";
        // �e�����z7
        public const string ct_Col_GrossProfit7 = "GrossProfit7";
        // �e�����z8
        public const string ct_Col_GrossProfit8 = "GrossProfit8";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02135EB()
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
                dt = new DataTable(ct_Tbl_CustFinancialRsltListForPrint);


                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionName, typeof(string));
                dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;

                // ���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerName, typeof(string));
                dt.Columns[ct_Col_CustomerName].DefaultValue = string.Empty;

                // ������z1
                dt.Columns.Add(ct_Col_SalesMoney1, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney1].DefaultValue = 0;

                // ������z2
                dt.Columns.Add(ct_Col_SalesMoney2, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney2].DefaultValue = 0;

                // ������z3
                dt.Columns.Add(ct_Col_SalesMoney3, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney3].DefaultValue = 0;

                // ������z4
                dt.Columns.Add(ct_Col_SalesMoney4, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney4].DefaultValue = 0;

                // ������z5
                dt.Columns.Add(ct_Col_SalesMoney5, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney5].DefaultValue = 0;

                // ������z6
                dt.Columns.Add(ct_Col_SalesMoney6, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney6].DefaultValue = 0;

                // ������z7
                dt.Columns.Add(ct_Col_SalesMoney7, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney7].DefaultValue = 0;

                // ������z8
                dt.Columns.Add(ct_Col_SalesMoney8, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney8].DefaultValue = 0;

                // �e�����z1
                dt.Columns.Add(ct_Col_GrossProfit1, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit1].DefaultValue = 0;

                // �e�����z2
                dt.Columns.Add(ct_Col_GrossProfit2, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit2].DefaultValue = 0;

                // �e�����z3
                dt.Columns.Add(ct_Col_GrossProfit3, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit3].DefaultValue = 0;

                // �e�����z4
                dt.Columns.Add(ct_Col_GrossProfit4, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit4].DefaultValue = 0;

                // �e�����z5
                dt.Columns.Add(ct_Col_GrossProfit5, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit5].DefaultValue = 0;

                // �e�����z6
                dt.Columns.Add(ct_Col_GrossProfit6, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit6].DefaultValue = 0;

                // �e�����z7
                dt.Columns.Add(ct_Col_GrossProfit7, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit7].DefaultValue = 0;

                // �e�����z8
                dt.Columns.Add(ct_Col_GrossProfit8, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit8].DefaultValue = 0;
            }
        }
        #endregion
    }
}

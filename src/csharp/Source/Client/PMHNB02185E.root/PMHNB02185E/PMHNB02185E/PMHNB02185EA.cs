using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���Ӑ�ʎ�����z�\ �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʎ�����z�\�̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02185EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_CustSalesDistributionReport = "CustSalesDistributionReport";
        // ��ƃR�[�h
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // ���_�R�[�h
        public const string ct_Col_SecCode = "SecCode";
        // ���_�K�C�h����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // ���Ӑ�R�[�h
        public const string ct_Col_CustomerCode = "CustomerCode";
        // ���Ӑ旪��
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        // �̔��]�ƈ��R�[�h
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        // �̔��]�ƈ�����
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        // �̔��G���A�R�[�h
        public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        // �̔��G���A����
        public const string ct_Col_SalesAreaName = "SalesAreaName";

        // �`�[����
        public const string ct_Col_SalesCount = "SalesCount";
        // ������
        public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        // �������z�v
        public const string ct_Col_TotalCost = "TotalCost";
        // ������t
        public const string ct_Col_SalesDate = "SalesDate";


        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02185EA()
        {
        }

        #endregion

        #region �� public���\�b�h
        /// <summary>
        /// ���Ӑ�ʎ�����z�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʎ�����z�\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.25</br>
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
                dt = new DataTable(ct_Tbl_CustSalesDistributionReport);

                // ��ƃR�[�h
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SecCode, typeof(string));
                dt.Columns[ct_Col_SecCode].DefaultValue = string.Empty;

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // ���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;

                // �̔��]�ƈ��R�[�h
                dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = string.Empty;

                // �̔��]�ƈ�����
                dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = string.Empty;

                // �̔��G���A�R�[�h
                dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
                dt.Columns[ct_Col_SalesAreaCode].DefaultValue = 0;

                // �̔��G���A����
                dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
                dt.Columns[ct_Col_SalesAreaName].DefaultValue = string.Empty;

                // �`�[����
                dt.Columns.Add(ct_Col_SalesCount, typeof(Int32));
                dt.Columns[ct_Col_SalesCount].DefaultValue = 0;
                // ������
                dt.Columns.Add(ct_Col_SalesTotalTaxExc, typeof(Int64));
                dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = 0;
                // �������z�v
                dt.Columns.Add(ct_Col_TotalCost, typeof(Int64));
                dt.Columns[ct_Col_TotalCost].DefaultValue = 0;
                // ������t
                dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
                dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            }
        }
        #endregion
    }
}

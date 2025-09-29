using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ������e���͕\ �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������e���͕\�̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02165EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_SalesHistAnalyzeResult = "ct_Tbl_SalesHistAnalyzeResult";
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

        // ������z(���v���)
        public const string ct_Col_SalesMoneyOrder = "SalesMoneyOrder";
        // ������z(���v�݌�)
        public const string ct_Col_SalesMoneyStock = "SalesMoneyStock";
        // ������z(���v����)
        public const string ct_Col_SalesMoneyGenuine = "SalesMoneyGenuine";
        // ������z(���v�D��)
        public const string ct_Col_SalesMoneyPrm = "SalesMoneyPrm";
        // ������z(���v�O��)
        public const string ct_Col_SalesMoneyOutside = "SalesMoneyOutside";
        // ������z(���v���̑�)
        public const string ct_Col_SalesMoneyOther = "SalesMoneyOther";
        // ������z(�݌v���)
        public const string ct_Col_MonthSalesMoneyOrder = "MonthSalesMoneyOrder";
        // ������z(�݌v�݌�)
        public const string ct_Col_MonthSalesMoneyStock = "MonthSalesMoneyStock";
        // ������z(�݌v����)
        public const string ct_Col_MonthSalesMoneyGenuine = "MonthSalesMoneyGenuine";
        // ������z(�݌v�D��)
        public const string ct_Col_MonthSalesMoneyPrm = "MonthSalesMoneyPrm";
        // ������z(�݌v�O��)
        public const string ct_Col_MonthSalesMoneyOutside = "MonthSalesMoneyOutside";
        // ������z(�݌v���̑�)
        public const string ct_Col_MonthSalesMoneyOther = "MonthSalesMoneyOther";

        // �e�����z(���v���)
        public const string ct_Col_GrossProfitOrder = "GrossProfitOrder";
        // �e�����z(���v�݌�)
        public const string ct_Col_GrossProfitStock = "GrossProfitStock";
        // �e�����z(���v����)
        public const string ct_Col_GrossProfitGenuine = "GrossProfitGenuine";
        // �e�����z(���v�D��)
        public const string ct_Col_GrossProfitPrm = "GrossProfitPrm";
        // �e�����z(���v�O��)
        public const string ct_Col_GrossProfitOutside = "GrossProfitOutside";
        // �e�����z(���v���̑�)
        public const string ct_Col_GrossProfitOther = "GrossProfitOther";
        // �e�����z(�݌v���)
        public const string ct_Col_MonthGrossProfitOrder = "MonthGrossProfitOrder";
        // �e�����z(�݌v�݌�)
        public const string ct_Col_MonthGrossProfitStock = "MonthGrossProfitStock";
        // �e�����z(�݌v����)
        public const string ct_Col_MonthGrossProfitGenuine = "MonthGrossProfitGenuine";
        // �e�����z(�݌v�D��)
        public const string ct_Col_MonthGrossProfitPrm = "MonthGrossProfitPrm";
        // �e�����z(�݌v�O��)
        public const string ct_Col_MonthGrossProfitOutside = "MonthGrossProfitOutside";
        // �e�����z(�݌v���̑�)
        public const string ct_Col_MonthGrossProfitOther = "MonthGrossProfitOther";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02165EA()
        {
        }

        #endregion

        #region �� public���\�b�h
        /// <summary>
        /// ������e���͕\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ������e���͕\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.11</br>
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
                dt = new DataTable(ct_Tbl_SalesHistAnalyzeResult);

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

                // ������z(���v���)
                dt.Columns.Add(ct_Col_SalesMoneyOrder, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOrder].DefaultValue = 0;
        
                // ������z(���v�݌�)
                dt.Columns.Add(ct_Col_SalesMoneyStock, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyStock].DefaultValue = 0;

                // ������z(���v����)
                dt.Columns.Add(ct_Col_SalesMoneyGenuine, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyGenuine].DefaultValue = 0;

                // ������z(���v�D��)
                dt.Columns.Add(ct_Col_SalesMoneyPrm, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyPrm].DefaultValue = 0;

                // ������z(���v�O��)
                dt.Columns.Add(ct_Col_SalesMoneyOutside, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOutside].DefaultValue = 0;

                // ������z(���v���̑�)
                dt.Columns.Add(ct_Col_SalesMoneyOther, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOther].DefaultValue = 0;

                // ������z(�݌v���)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOrder, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOrder].DefaultValue = 0;

                // ������z(�݌v�݌�)
                dt.Columns.Add(ct_Col_MonthSalesMoneyStock, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyStock].DefaultValue = 0;

                // ������z(�݌v����)
                dt.Columns.Add(ct_Col_MonthSalesMoneyGenuine, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyGenuine].DefaultValue = 0;

                // ������z(�݌v�D��)
                dt.Columns.Add(ct_Col_MonthSalesMoneyPrm, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyPrm].DefaultValue = 0;

                // ������z(�݌v�O��)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOutside, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOutside].DefaultValue = 0;

                // ������z(�݌v���̑�)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOther, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOther].DefaultValue = 0;

                // �e�����z(���v���)
                dt.Columns.Add(ct_Col_GrossProfitOrder, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitOrder].DefaultValue = 0;

                // �e�����z(���v�݌�)
                dt.Columns.Add(ct_Col_GrossProfitStock, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitStock].DefaultValue = 0;

                // �e�����z(���v����)
                dt.Columns.Add(ct_Col_GrossProfitGenuine, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitGenuine].DefaultValue = 0;

                // �e�����z(���v�D��)
                dt.Columns.Add(ct_Col_GrossProfitPrm, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitPrm].DefaultValue = 0;

                // �e�����z(���v�O��)
                dt.Columns.Add(ct_Col_GrossProfitOutside, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitOutside].DefaultValue = 0;

                // �e�����z(���v���̑�)
                dt.Columns.Add(ct_Col_GrossProfitOther, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitOther].DefaultValue = 0;

                // �e�����z(�݌v���)
                dt.Columns.Add(ct_Col_MonthGrossProfitOrder, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitOrder].DefaultValue = 0;

                // �e�����z(�݌v�݌�)
                dt.Columns.Add(ct_Col_MonthGrossProfitStock, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitStock].DefaultValue = 0;

                // �e�����z(�݌v����)
                dt.Columns.Add(ct_Col_MonthGrossProfitGenuine, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitGenuine].DefaultValue = 0;

                // �e�����z(�݌v�D��)
                dt.Columns.Add(ct_Col_MonthGrossProfitPrm, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitPrm].DefaultValue = 0;

                // �e�����z(�݌v�O��)
                dt.Columns.Add(ct_Col_MonthGrossProfitOutside, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitOutside].DefaultValue = 0;

                // �e�����z(�݌v���̑�)
                dt.Columns.Add(ct_Col_MonthGrossProfitOther, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitOther].DefaultValue = 0;



        
            }
        }
        #endregion
    }
}

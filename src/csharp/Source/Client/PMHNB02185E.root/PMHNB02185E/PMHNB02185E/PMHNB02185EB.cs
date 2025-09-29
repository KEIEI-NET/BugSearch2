using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���Ӑ�ʎ�����z�\ ���[�󎚗p�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʎ�����z�\�̒��[�󎚗p�f�[�^��ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02185EB
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_CustSalesDistributionReportForPrint = "CustSalesDistributionReportForPrint";
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
        // �e��
        public const string ct_Col_GrossProfit = "GrossProfit";
        // �c�Ɠ���
        public const string ct_Col_BusinessDays = "BusinessDays";

        // ������t1
        public const string ct_Col_SalesDate1 = "SalesDate1";
        // ������t2
        public const string ct_Col_SalesDate2 = "SalesDate2";
        // ������t3
        public const string ct_Col_SalesDate3 = "SalesDate3";
        // ������t4
        public const string ct_Col_SalesDate4 = "SalesDate4";
        // ������t5
        public const string ct_Col_SalesDate5 = "SalesDate5";
        // ������t6
        public const string ct_Col_SalesDate6 = "SalesDate6";
        // ������t7
        public const string ct_Col_SalesDate7 = "SalesDate7";
        // ������t8
        public const string ct_Col_SalesDate8 = "SalesDate8";
        // ������t9
        public const string ct_Col_SalesDate9 = "SalesDate9";
        // ������t10
        public const string ct_Col_SalesDate10 = "SalesDate10";
        // ������t11
        public const string ct_Col_SalesDate11 = "SalesDate11";
        // ������t12
        public const string ct_Col_SalesDate12 = "SalesDate12";
        // ������t13
        public const string ct_Col_SalesDate13 = "SalesDate13";
        // ������t14
        public const string ct_Col_SalesDate14 = "SalesDate14";
        // ������t15
        public const string ct_Col_SalesDate15 = "SalesDate15";
        // ������t16
        public const string ct_Col_SalesDate16 = "SalesDate16";
        // ������t17
        public const string ct_Col_SalesDate17 = "SalesDate17";
        // ������t18
        public const string ct_Col_SalesDate18 = "SalesDate18";
        // ������t19
        public const string ct_Col_SalesDate19 = "SalesDate19";
        // ������t20
        public const string ct_Col_SalesDate20 = "SalesDate20";
        // ������t21
        public const string ct_Col_SalesDate21 = "SalesDate21";
        // ������t22
        public const string ct_Col_SalesDate22 = "SalesDate22";
        // ������t23
        public const string ct_Col_SalesDate23 = "SalesDate23";
        // ������t24
        public const string ct_Col_SalesDate24 = "SalesDate24";
        // ������t25
        public const string ct_Col_SalesDate25 = "SalesDate25";
        // ������t26
        public const string ct_Col_SalesDate26 = "SalesDate26";
        // ������t27
        public const string ct_Col_SalesDate27 = "SalesDate27";
        // ������t28
        public const string ct_Col_SalesDate28 = "SalesDate28";
        // ������t29
        public const string ct_Col_SalesDate29 = "SalesDate29";
        // ������t30
        public const string ct_Col_SalesDate30 = "SalesDate30";
        // ������t31
        public const string ct_Col_SalesDate31 = "SalesDate31";

        // ����
        public const string ct_Col_Order = "Order";


        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02185EB()
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
                dt = new DataTable(ct_Tbl_CustSalesDistributionReportForPrint);

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
                // �e��
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
                // �c�Ɠ���
                dt.Columns.Add(ct_Col_BusinessDays, typeof(Int32));
                dt.Columns[ct_Col_BusinessDays].DefaultValue = 0;
                // ������t1
                dt.Columns.Add(ct_Col_SalesDate1, typeof(string));
                dt.Columns[ct_Col_SalesDate1].DefaultValue = string.Empty;
                // ������t2
                dt.Columns.Add(ct_Col_SalesDate2, typeof(string));
                dt.Columns[ct_Col_SalesDate2].DefaultValue = string.Empty;
                // ������t3
                dt.Columns.Add(ct_Col_SalesDate3, typeof(string));
                dt.Columns[ct_Col_SalesDate3].DefaultValue = string.Empty;
                // ������t4
                dt.Columns.Add(ct_Col_SalesDate4, typeof(string));
                dt.Columns[ct_Col_SalesDate4].DefaultValue = string.Empty;
                // ������t5
                dt.Columns.Add(ct_Col_SalesDate5, typeof(string));
                dt.Columns[ct_Col_SalesDate5].DefaultValue = string.Empty;
                // ������t6
                dt.Columns.Add(ct_Col_SalesDate6, typeof(string));
                dt.Columns[ct_Col_SalesDate6].DefaultValue = string.Empty;
                // ������t7
                dt.Columns.Add(ct_Col_SalesDate7, typeof(string));
                dt.Columns[ct_Col_SalesDate7].DefaultValue = string.Empty;
                // ������t8
                dt.Columns.Add(ct_Col_SalesDate8, typeof(string));
                dt.Columns[ct_Col_SalesDate8].DefaultValue = string.Empty;
                // ������t9
                dt.Columns.Add(ct_Col_SalesDate9, typeof(string));
                dt.Columns[ct_Col_SalesDate9].DefaultValue = string.Empty;
                // ������t10
                dt.Columns.Add(ct_Col_SalesDate10, typeof(string));
                dt.Columns[ct_Col_SalesDate10].DefaultValue = string.Empty;
                // ������t11
                dt.Columns.Add(ct_Col_SalesDate11, typeof(string));
                dt.Columns[ct_Col_SalesDate11].DefaultValue = string.Empty;
                // ������t12
                dt.Columns.Add(ct_Col_SalesDate12, typeof(string));
                dt.Columns[ct_Col_SalesDate12].DefaultValue = string.Empty;
                // ������t13
                dt.Columns.Add(ct_Col_SalesDate13, typeof(string));
                dt.Columns[ct_Col_SalesDate13].DefaultValue = string.Empty;
                // ������t14
                dt.Columns.Add(ct_Col_SalesDate14, typeof(string));
                dt.Columns[ct_Col_SalesDate14].DefaultValue = string.Empty;
                // ������t15
                dt.Columns.Add(ct_Col_SalesDate15, typeof(string));
                dt.Columns[ct_Col_SalesDate15].DefaultValue = string.Empty;
                // ������t16
                dt.Columns.Add(ct_Col_SalesDate16, typeof(string));
                dt.Columns[ct_Col_SalesDate16].DefaultValue = string.Empty;
                // ������t17
                dt.Columns.Add(ct_Col_SalesDate17, typeof(string));
                dt.Columns[ct_Col_SalesDate17].DefaultValue = string.Empty;
                // ������t18
                dt.Columns.Add(ct_Col_SalesDate18, typeof(string));
                dt.Columns[ct_Col_SalesDate18].DefaultValue = string.Empty;
                // ������t19
                dt.Columns.Add(ct_Col_SalesDate19, typeof(string));
                dt.Columns[ct_Col_SalesDate19].DefaultValue = string.Empty;
                // ������t20
                dt.Columns.Add(ct_Col_SalesDate20, typeof(string));
                dt.Columns[ct_Col_SalesDate20].DefaultValue = string.Empty;
                // ������t21
                dt.Columns.Add(ct_Col_SalesDate21, typeof(string));
                dt.Columns[ct_Col_SalesDate21].DefaultValue = string.Empty;
                // ������t22
                dt.Columns.Add(ct_Col_SalesDate22, typeof(string));
                dt.Columns[ct_Col_SalesDate22].DefaultValue = string.Empty;
                // ������t23
                dt.Columns.Add(ct_Col_SalesDate23, typeof(string));
                dt.Columns[ct_Col_SalesDate23].DefaultValue = string.Empty;
                // ������t24
                dt.Columns.Add(ct_Col_SalesDate24, typeof(string));
                dt.Columns[ct_Col_SalesDate24].DefaultValue = string.Empty;
                // ������t25
                dt.Columns.Add(ct_Col_SalesDate25, typeof(string));
                dt.Columns[ct_Col_SalesDate25].DefaultValue = string.Empty;
                // ������t26
                dt.Columns.Add(ct_Col_SalesDate26, typeof(string));
                dt.Columns[ct_Col_SalesDate26].DefaultValue = string.Empty;
                // ������t27
                dt.Columns.Add(ct_Col_SalesDate27, typeof(string));
                dt.Columns[ct_Col_SalesDate27].DefaultValue = string.Empty;
                // ������t28
                dt.Columns.Add(ct_Col_SalesDate28, typeof(string));
                dt.Columns[ct_Col_SalesDate28].DefaultValue = string.Empty;
                // ������t29
                dt.Columns.Add(ct_Col_SalesDate29, typeof(string));
                dt.Columns[ct_Col_SalesDate29].DefaultValue = string.Empty;
                // ������t30
                dt.Columns.Add(ct_Col_SalesDate30, typeof(string));
                dt.Columns[ct_Col_SalesDate30].DefaultValue = string.Empty;
                // ������t31
                dt.Columns.Add(ct_Col_SalesDate31, typeof(string));
                dt.Columns[ct_Col_SalesDate31].DefaultValue = string.Empty;

                // ����
                dt.Columns.Add(ct_Col_Order, typeof(Int32));
                dt.Columns[ct_Col_Order].DefaultValue = 0;
            }
        }
        #endregion
    }
}

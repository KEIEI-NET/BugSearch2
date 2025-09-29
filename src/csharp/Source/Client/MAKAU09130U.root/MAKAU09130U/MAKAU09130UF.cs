using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �c���\���p�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    internal class AccPayBalanceDispayTable
    {
        public AccPayBalanceDispayTable()
        {
        }

        public const string ctTableName = "AccPayBalanceDispayTable";

        /// <summary>�v��N��</summary>
        public const string ct_Col_ADDUPYEARMONTHJP = "ADDUPYEARMONTHJP";
        /// <summary>�v��N����</summary>
        public const string ct_Col_ADDUPDATEJP = "ADDUPDATEJP";
        /// <summary>�O�X�X��c��</summary>
        public const string ct_Col_TOTAL3_BEF = "TOTAL3_BEF";
        /// <summary>�O�X��c��</summary>
        public const string ct_Col_TOTAL2_BEF = "TOTAL2_BEF";
        /// <summary> �O��c��</summary>
        public const string ct_Col_TOTAL1_BEF = "TOTAL1_BEF";
        /// <summary>����d��</summary>
        public const string ct_Col_OFSTHISTIMESTOCK = "OFSTHISTIMESTOCK";
        /// <summary>�����</summary>
        public const string ct_Col_OFSTHISSTOCKTAX = "CONSTAX";
        /// <summary>����x��</summary>
        public const string ct_Col_THISTIMEPAYM = "THISTIMEPAYM";
        /// <summary>���|�c��</summary>
        public const string ct_Col_ACCRECBLNCE = "ACCRECBLNCE";

        static public void CreateTable(ref DataTable dt)
        {
            if (dt == null)
            {
                dt = new DataTable(ctTableName);
            }
            dt.Rows.Clear();

            // �v��N��
            dt.Columns.Add(ct_Col_ADDUPYEARMONTHJP, typeof(Int64));
            dt.Columns[ct_Col_ADDUPYEARMONTHJP].DefaultValue = 0;
            // �v��N����
            dt.Columns.Add(ct_Col_ADDUPDATEJP, typeof(Int64));
            dt.Columns[ct_Col_ADDUPDATEJP].DefaultValue = 0;
            // �O�X�X��c��
            dt.Columns.Add(ct_Col_TOTAL3_BEF, typeof(Int64));
            dt.Columns[ct_Col_TOTAL3_BEF].DefaultValue = 0;
            // �O�X��c��
            dt.Columns.Add(ct_Col_TOTAL2_BEF, typeof(Int64));
            dt.Columns[ct_Col_TOTAL2_BEF].DefaultValue = 0;
            // �O��c��
            dt.Columns.Add(ct_Col_TOTAL1_BEF, typeof(Int64));
            dt.Columns[ct_Col_TOTAL1_BEF].DefaultValue = 0;
            // ����d��
            dt.Columns.Add(ct_Col_OFSTHISTIMESTOCK, typeof(Int64));
            dt.Columns[ct_Col_OFSTHISTIMESTOCK].DefaultValue = 0;
            // �����
            dt.Columns.Add(ct_Col_OFSTHISSTOCKTAX, typeof(Int64));
            dt.Columns[ct_Col_OFSTHISSTOCKTAX].DefaultValue = 0;
            // ����x��
            dt.Columns.Add(ct_Col_THISTIMEPAYM, typeof(Int64));
            dt.Columns[ct_Col_THISTIMEPAYM].DefaultValue = 0;
            // ���|�c��
            dt.Columns.Add(ct_Col_ACCRECBLNCE, typeof(Int64));
            dt.Columns[ct_Col_ACCRECBLNCE].DefaultValue = 0;
        }
    }
}

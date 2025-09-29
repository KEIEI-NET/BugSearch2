//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���擾���i
// �v���O�����T�v   : ADO.NET�֘A�̋��ʏ������������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ADO.NET�̃��[�e�B���e�B
    /// </summary>
    public static class ADOUtil
    {
        /// <summary>=�L�[���[�h</summary>
        public const string EQ = "=";

        /// <summary>�����L�[���[�h</summary>
        public const string NOT_EQ = "<>";

        /// <summary>AND�L�[���[�h</summary>
        public const string AND = " AND ";

        /// <summary>OR�L�[���[�h</summary>
        public const string OR = " OR ";

        /// <summary>�~���̃L�[���[�h</summary>
        public const string DESC = " DESC";

        /// <summary>�J���}�L�[���[�h</summary>
        public const string COMMA = ",";

        /// <summary>LIKE�L�[���[�h</summary>
        public const string LIKE = " LIKE ";

        /// <summary>���C���h�J�[�h�L�[���[�h</summary>
        public const string WILD = "%";

        /// <summary>���L�[���[�h</summary>
        public const string LARGE_EQ = ">=";

        /// <summary>���L�[���[�h</summary>
        public const string LARGE = ">";

        /// <summary>���L�[���[�h</summary>
        public const string LESS_EQ = "<=";

        /// <summary>���L�[���[�h</summary>
        public const string LESS = "<";

        /// <summary>NOT�L�[���[�h</summary>
        public const string NOT = "<>";

        /// <summary>(�L�[���[�h</summary>
        public const string BEGIN_BLOCK = "(";

        /// <summary>)�L�[���[�h</summary>
        public const string END_BLOCK = ")";

        /// <summary>
        /// SQL�̕�����l�\�L���擾���܂��B
        /// </summary>
        /// <param name="val">������l</param>
        /// <returns>SQL�̕�����l�\�L</returns>
        public static string GetString(string val)
        {
            return "'" + val + "'";
        }

        /// <summary>
        /// SQL�̕�����l�\�L���擾���܂��B
        /// </summary>
        /// <param name="number">���l</param>
        /// <returns>SQL�̕�����l�\�L</returns>
        public static string GetString(int number)
        {
            return GetString(number.ToString());
        }

        /// <summary>
        /// SQL�̃��[���h�J�[�h�t��������\�L���擾���܂��B
        /// </summary>
        /// <param name="val">������l</param>
        /// <returns>SQL�̃��[���h�J�[�h�t��������\�L</returns>
        public static string GetWild(string val)
        {
            return GetString(WILD + val + WILD);
        }

        /// <summary>
        /// DataRow�̔z�񂩂�DataTable�𐶐����܂��B
        /// </summary>
        /// <typeparam name="TDataTable">DataTable�̌^</typeparam>
        /// <param name="dataRows">DataRow�̔z��</param>
        /// <returns>�V����DataTable�̃C���X�^���X</returns>
        public static TDataTable CreateDataTable<TDataTable>(DataRow[] dataRows) where TDataTable : DataTable, new()
        {
            TDataTable dataTable = new TDataTable();
            foreach (DataRow dataRow in dataRows)
            {
                dataTable.Rows.Add(dataRow.ItemArray);
            }
            return dataTable;
        }

        /// <summary>
        /// DataRow�z����^�t��DataRow�z��ɕϊ����܂��B
        /// </summary>
        /// <typeparam name="TDataRow">�^�t��DataRow�̌^</typeparam>
        /// <param name="dataRows">DataRow�z��</param>
        /// <returns>�^�t��DataRow�z��</returns>
        public static TDataRow[] ConvertAll<TDataRow>(DataRow[] dataRows) where TDataRow : DataRow
        {
            return Array.ConvertAll<DataRow, TDataRow>(dataRows, delegate(DataRow dataRow) { return (TDataRow)dataRow; });
        }
    }
}

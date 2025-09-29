//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^����p�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �v��
// �� �� ��  2013/02/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �|���}�X�^����p�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^����p�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �v��</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class PMKHN09903EC
    {
        #region �� Public Const

        public const string ct_Tbl_ReportData = "Tbl_ReportData"; // �e�[�u������

        public const int CNTPERPAGE = 31;                          // PDF�y�[�W�ōő�\�����׌���

        public const string ct_Col_Col1HeadValue = "Col1HeadValue"; // ���i�|��G or �w��
        public const string ct_Col_Col1ShowValue = "Col1ShowValue"; // �\���p�f�[�^
        public const string ct_Col_Col1HideValue = "Col1HideValue"; // �ݒ�p�f�[�^
        public const string ct_Col_Col2ShowGlcd = "Col2ShowGlcd"; // �\���pBL�R�[�h�f
        public const string ct_Col_Col2HideGlcd = "Col2HideGlcd"; // �ݒ�pBL�R�[�h�f
        public const string ct_Col_Col2Name = "Col2Name"; // ���́i���i�|��G���́j
        public const string ct_Col_Col3Blcd = "Col3Blcd"; // BL�R�[�h
        public const string ct_Col_Col3GlcdName = "Col3GlcdName"; // BL�R�[�h�f����
        public const string ct_Col_Col4BLCodeName = "Col4BLCodeName"; // BL�R�[�h����
        public const string ct_Col_Col5Maker = "Col5Maker"; // ���[�J�[
        public const string ct_Col_Col6CostRate = "Col6CostRate"; // �d����
        public const string ct_Col_Col7All = "Col7All"; // All
        public const string ct_Col_Row1Name = "Row1Name"; // ���́i������/����UP��/�e���m�ۗ��j
        public const string ct_Col_Col1InputHeadName = "Col1InputHeadName"; // �w�b�_��1�R�������͏������
        public const string ct_Col_Col2InputHeadName = "Col2InputHeadName"; // �w�b�_��2�R�������͏������
        public const string ct_Col_Col3InputHeadName = "Col3InputHeadName"; // �w�b�_��3�R�������͏������
        public const string ct_Col_Col4InputHeadName = "Col4InputHeadName"; // �w�b�_��4�R�������͏������
        public const string ct_Col_Col5InputHeadName = "Col5InputHeadName"; // �w�b�_��5�R�������͏������
        public const string ct_Col_Col6InputHeadName = "Col6InputHeadName"; // �w�b�_��6�R�������͏������
        public const string ct_Col_Col7InputHeadName = "Col7InputHeadName"; // �w�b�_��7�R�������͏������
        public const string ct_Col_Col8InputHeadName = "Col8InputHeadName"; // �w�b�_��8�R�������͏������
        public const string ct_Col_Col9InputHeadName = "Col9InputHeadName"; // �w�b�_��9�R�������͏������
        public const string ct_Col_Col10InputHeadName = "Col10InputHeadName"; // �w�b�_��10�R�������͏������
        public const string ct_Col_Col11InputHeadName = "Col11InputHeadName"; // �w�b�_��11�R�������͏������
        public const string ct_Col_Col12InputHeadName = "Col12InputHeadName"; // �w�b�_��12�R�������͏������
        public const string ct_Col_Col13InputHeadName = "Col13InputHeadName"; // �w�b�_��13�R�������͏������
        public const string ct_Col_Col14InputHeadName = "Col14InputHeadName"; // �w�b�_��14�R�������͏������
        public const string ct_Col_Col15InputHeadName = "Col15InputHeadName"; // �w�b�_��15�R�������͏������
        public const string ct_Col_Col16InputHeadName = "Col16InputHeadName"; // �w�b�_��16�R�������͏������
        public const string ct_Col_Col17InputHeadName = "Col17InputHeadName"; // �w�b�_��17�R�������͏������
        public const string ct_Col_Col18InputHeadName = "Col18InputHeadName"; // �w�b�_��18�R�������͏������
        public const string ct_Col_Col19InputHeadName = "Col19InputHeadName"; // �w�b�_��19�R�������͏������
        public const string ct_Col_Col20InputHeadName = "Col20InputHeadName"; // �w�b�_��20�R�������͏������
        public const string ct_Col_Col1InputValue = "Col1InputValue"; // 1�R�������̓f�[�^
        public const string ct_Col_Col2InputValue = "Col2InputValue"; // 2�R�������̓f�[�^
        public const string ct_Col_Col3InputValue = "Col3InputValue"; // 3�R�������̓f�[�^
        public const string ct_Col_Col4InputValue = "Col4InputValue"; // 4�R�������̓f�[�^
        public const string ct_Col_Col5InputValue = "Col5InputValue"; // 5�R�������̓f�[�^
        public const string ct_Col_Col6InputValue = "Col6InputValue"; // 6�R�������̓f�[�^
        public const string ct_Col_Col7InputValue = "Col7InputValue"; // 7�R�������̓f�[�^
        public const string ct_Col_Col8InputValue = "Col8InputValue"; // 8�R�������̓f�[�^
        public const string ct_Col_Col9InputValue = "Col9InputValue"; // 9�R�������̓f�[�^
        public const string ct_Col_Col10InputValue = "Col10InputValue"; // 10�R�������̓f�[�^
        public const string ct_Col_Col11InputValue = "Col11InputValue"; // 11�R�������̓f�[�^
        public const string ct_Col_Col12InputValue = "Col12InputValue"; // 12�R�������̓f�[�^
        public const string ct_Col_Col13InputValue = "Col13InputValue"; // 13�R�������̓f�[�^
        public const string ct_Col_Col14InputValue = "Col14InputValue"; // 14�R�������̓f�[�^
        public const string ct_Col_Col15InputValue = "Col15InputValue"; // 15�R�������̓f�[�^
        public const string ct_Col_Col16InputValue = "Col16InputValue"; // 16�R�������̓f�[�^
        public const string ct_Col_Col17InputValue = "Col17InputValue"; // 17�R�������̓f�[�^
        public const string ct_Col_Col18InputValue = "Col18InputValue"; // 18�R�������̓f�[�^
        public const string ct_Col_Col19InputValue = "Col19InputValue"; // 19�R�������̓f�[�^
        public const string ct_Col_Col20InputValue = "Col20InputValue"; // 20�R�������̓f�[�^

        public const string ct_Col_Col1InputHeadNm = "Col1InputHeadNm"; // �w�b�_��1�R�������͏����̖��̏��
        public const string ct_Col_Col2InputHeadNm = "Col2InputHeadNm"; // �w�b�_��2�R�������͏����̖��̏��
        public const string ct_Col_Col3InputHeadNm = "Col3InputHeadNm"; // �w�b�_��3�R�������͏����̖��̏��
        public const string ct_Col_Col4InputHeadNm = "Col4InputHeadNm"; // �w�b�_��4�R�������͏����̖��̏��
        public const string ct_Col_Col5InputHeadNm = "Col5InputHeadNm"; // �w�b�_��5�R�������͏����̖��̏��
        public const string ct_Col_Col6InputHeadNm = "Col6InputHeadNm"; // �w�b�_��6�R�������͏����̖��̏��
        public const string ct_Col_Col7InputHeadNm = "Col7InputHeadNm"; // �w�b�_��7�R�������͏����̖��̏��
        public const string ct_Col_Col8InputHeadNm = "Col8InputHeadNm"; // �w�b�_��8�R�������͏����̖��̏��
        public const string ct_Col_Col9InputHeadNm = "Col9InputHeadNm"; // �w�b�_��9�R�������͏����̖��̏��
        public const string ct_Col_Col10InputHeadNm = "Col10InputHeadNm"; // �w�b�_��10�R�������͏����̖��̏��
        public const string ct_Col_Col11InputHeadNm = "Col11InputHeadNm"; // �w�b�_��11�R�������͏����̖��̏��
        public const string ct_Col_Col12InputHeadNm = "Col12InputHeadNm"; // �w�b�_��12�R�������͏����̖��̏��
        public const string ct_Col_Col13InputHeadNm = "Col13InputHeadNm"; // �w�b�_��13�R�������͏����̖��̏��
        public const string ct_Col_Col14InputHeadNm = "Col14InputHeadNm"; // �w�b�_��14�R�������͏����̖��̏��
        public const string ct_Col_Col15InputHeadNm = "Col15InputHeadNm"; // �w�b�_��15�R�������͏����̖��̏��
        public const string ct_Col_Col16InputHeadNm = "Col16InputHeadNm"; // �w�b�_��16�R�������͏����̖��̏��
        public const string ct_Col_Col17InputHeadNm = "Col17InputHeadNm"; // �w�b�_��17�R�������͏����̖��̏��
        public const string ct_Col_Col18InputHeadNm = "Col18InputHeadNm"; // �w�b�_��18�R�������͏����̖��̏��
        public const string ct_Col_Col19InputHeadNm = "Col19InputHeadNm"; // �w�b�_��19�R�������͏����̖��̏��
        public const string ct_Col_Col20InputHeadNm = "Col20InputHeadNm"; // �w�b�_��20�R�������͏����̖��̏��
        #endregion

        #region �� Static Public Method
        #region �� �|���}�X�^���DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �|���}�X�^���DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^����f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_ReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_ReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_ReportData);

                DataTable dt = ds.Tables[ct_Tbl_ReportData];

                dt.Columns.Add(ct_Col_Col1HeadValue, typeof(string));
                dt.Columns[ct_Col_Col1HeadValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1ShowValue, typeof(string));
                dt.Columns[ct_Col_Col1ShowValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1HideValue, typeof(string));
                dt.Columns[ct_Col_Col1HideValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2ShowGlcd, typeof(string));
                dt.Columns[ct_Col_Col2ShowGlcd].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2HideGlcd, typeof(string));
                dt.Columns[ct_Col_Col2HideGlcd].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2Name, typeof(string));
                dt.Columns[ct_Col_Col2Name].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3Blcd, typeof(string));
                dt.Columns[ct_Col_Col3Blcd].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3GlcdName, typeof(string));
                dt.Columns[ct_Col_Col3GlcdName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4BLCodeName, typeof(string));
                dt.Columns[ct_Col_Col4BLCodeName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5Maker, typeof(string));
                dt.Columns[ct_Col_Col5Maker].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6CostRate, typeof(string));
                dt.Columns[ct_Col_Col6CostRate].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7All, typeof(string));
                dt.Columns[ct_Col_Col7All].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Row1Name, typeof(string));
                dt.Columns[ct_Col_Row1Name].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col1InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col2InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col3InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col4InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col5InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col6InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col7InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col8InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col8InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col9InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col9InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col10InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col10InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col11InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col11InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col12InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col12InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col13InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col13InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col14InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col14InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col15InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col15InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col16InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col16InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col17InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col17InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col18InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col18InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col19InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col19InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col20InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col20InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1InputValue, typeof(string));
                dt.Columns[ct_Col_Col1InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2InputValue, typeof(string));
                dt.Columns[ct_Col_Col2InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3InputValue, typeof(string));
                dt.Columns[ct_Col_Col3InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4InputValue, typeof(string));
                dt.Columns[ct_Col_Col4InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5InputValue, typeof(string));
                dt.Columns[ct_Col_Col5InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6InputValue, typeof(string));
                dt.Columns[ct_Col_Col6InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7InputValue, typeof(string));
                dt.Columns[ct_Col_Col7InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col8InputValue, typeof(string));
                dt.Columns[ct_Col_Col8InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col9InputValue, typeof(string));
                dt.Columns[ct_Col_Col9InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col10InputValue, typeof(string));
                dt.Columns[ct_Col_Col10InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col11InputValue, typeof(string));
                dt.Columns[ct_Col_Col11InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col12InputValue, typeof(string));
                dt.Columns[ct_Col_Col12InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col13InputValue, typeof(string));
                dt.Columns[ct_Col_Col13InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col14InputValue, typeof(string));
                dt.Columns[ct_Col_Col14InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col15InputValue, typeof(string));
                dt.Columns[ct_Col_Col15InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col16InputValue, typeof(string));
                dt.Columns[ct_Col_Col16InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col17InputValue, typeof(string));
                dt.Columns[ct_Col_Col17InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col18InputValue, typeof(string));
                dt.Columns[ct_Col_Col18InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col19InputValue, typeof(string));
                dt.Columns[ct_Col_Col19InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col20InputValue, typeof(string));
                dt.Columns[ct_Col_Col20InputValue].DefaultValue = string.Empty;



                dt.Columns.Add(ct_Col_Col1InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col1InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col2InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col3InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col4InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col5InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col6InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col7InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col8InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col8InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col9InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col9InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col10InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col10InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col11InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col11InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col12InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col12InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col13InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col13InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col14InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col14InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col15InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col15InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col16InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col16InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col17InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col17InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col18InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col18InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col19InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col19InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col20InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col20InputHeadNm].DefaultValue = string.Empty;
                

            }
        }
        #endregion
        #endregion
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ʗ\��\�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ��`���ʗ\��\�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ʗ\��\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class PMTEG02405EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_TegataTsukibetsuYoteListReportData = "Tbl_TegataTsukibetsuYoteListReportData";

		/// <summary> ��`��ʃR�[�h </summary>
		public const string ct_Col_DraftKindCd = "DraftKindCd";
		/// <summary> ��`��ʖ��� </summary>
		public const string ct_Col_DraftKindName = "DraftKindName";
		/// <summary> ��s�E�x�X�R�[�h </summary>
		public const string ct_Col_BankAndBranchCd = "BankAndBranchCd";
		/// <summary> ��s�E�x�X���� </summary>
		public const string ct_Col_BankAndBranchNm = "BankAndBranchNm";
        /// <summary> �J�n�����̍��v </summary>
        public const string ct_Col_SumMonth1 = "SumMonth1";
        /// <summary> �Q�����ڕ��̍��v </summary>
        public const string ct_Col_SumMonth2 = "SumMonth2";
        /// <summary> �R�����ڕ��̍��v </summary>
        public const string ct_Col_SumMonth3 = "SumMonth3";
        /// <summary> �S�����ڕ��̍��v </summary>
        public const string ct_Col_SumMonth4 = "SumMonth4";
        /// <summary> �T�����ڕ��̍��v </summary>
        public const string ct_Col_SumMonth5 = "SumMonth5";
        /// <summary> �U�����ڕ��̍��v </summary>
        public const string ct_Col_SumMonth6 = "SumMonth6";
        /// <summary> �U�����ȍ~���̍��v </summary>
        public const string ct_Col_SumMonthSpare = "SumMonthSpare";
        /// <summary> ���v </summary>
        public const string ct_Col_SumMonthAll = "SumMonthAll";
        /// <summary> ���� </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> �o�͏� </summary>
        public const string ct_Col_PrintType = "PrintType";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ��`���ʗ\��\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`���ʗ\��\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02405EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� ��`���ʗ\��\DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// ��`���ʗ\��\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ��`���ʗ\��\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_TegataTsukibetsuYoteListReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_TegataTsukibetsuYoteListReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_TegataTsukibetsuYoteListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataTsukibetsuYoteListReportData];
				// ��`��ʃR�[�h
				dt.Columns.Add(ct_Col_DraftKindCd, typeof(string));
				dt.Columns[ct_Col_DraftKindCd].DefaultValue = string.Empty;
				// ��`��ʖ���
				dt.Columns.Add(ct_Col_DraftKindName, typeof(string));
				dt.Columns[ct_Col_DraftKindName].DefaultValue = string.Empty;
				// ��s�E�x�X�R�[�h
				dt.Columns.Add(ct_Col_BankAndBranchCd, typeof(string));
				dt.Columns[ct_Col_BankAndBranchCd].DefaultValue = string.Empty;
				// ��s�E�x�X����
				dt.Columns.Add(ct_Col_BankAndBranchNm, typeof(string));
				dt.Columns[ct_Col_BankAndBranchNm].DefaultValue = string.Empty;
                // �J�n�����̍��v
                dt.Columns.Add(ct_Col_SumMonth1, typeof(long));
                dt.Columns[ct_Col_SumMonth1].DefaultValue = 0;
                // �Q�����ڕ��̍��v
                dt.Columns.Add(ct_Col_SumMonth2, typeof(long));
                dt.Columns[ct_Col_SumMonth2].DefaultValue = 0;
                // �R�����ڕ��̍��v
                dt.Columns.Add(ct_Col_SumMonth3, typeof(long));
                dt.Columns[ct_Col_SumMonth3].DefaultValue = 0;
                // �S�����ڕ��̍��v
                dt.Columns.Add(ct_Col_SumMonth4, typeof(long));
                dt.Columns[ct_Col_SumMonth4].DefaultValue = 0;
                // �T�����ڕ��̍��v
                dt.Columns.Add(ct_Col_SumMonth5, typeof(long));
                dt.Columns[ct_Col_SumMonth5].DefaultValue = 0;
                // �U�����ڕ��̍��v
                dt.Columns.Add(ct_Col_SumMonth6, typeof(long));
                dt.Columns[ct_Col_SumMonth6].DefaultValue = 0;
                // �U�����ȍ~���̍��v
                dt.Columns.Add(ct_Col_SumMonthSpare, typeof(long));
                dt.Columns[ct_Col_SumMonthSpare].DefaultValue = 0;
                // ���v
                dt.Columns.Add(ct_Col_SumMonthAll, typeof(long));
                dt.Columns[ct_Col_SumMonthAll].DefaultValue = 0;
                // ����
                dt.Columns.Add(ct_Col_ChangePage, typeof(string));
                dt.Columns[ct_Col_ChangePage].DefaultValue = string.Empty;
                // �o�͏�
                dt.Columns.Add(ct_Col_PrintType, typeof(string));
                dt.Columns[ct_Col_PrintType].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}
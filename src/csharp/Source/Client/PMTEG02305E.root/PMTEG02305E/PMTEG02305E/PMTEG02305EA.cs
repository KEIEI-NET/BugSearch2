//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�����ʕ\�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
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
    /// ��`�����ʕ\�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�����ʕ\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class PMTEG02305EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_TegataKibiListReportData = "Tbl_TegataKibiListReportData";

        /// <summary> ���t </summary>
        public const string ct_Col_Day = "Day";
        /// <summary> ��`��ʃR�[�h </summary>
        public const string ct_Col_DraftKindCd = "DraftKindCd";
        /// <summary> ��`��ʖ��� </summary>
        public const string ct_Col_DraftKindName = "DraftKindName";
        /// <summary> ��s�x�X�R�[�h </summary>
        public const string ct_Col_BankAndBranchCd = "BankAndBranchCd";
        /// <summary> ��s�x�X���� </summary>
        public const string ct_Col_BankAndBranchNm = "BankAndBranchNm";
        /// <summary> ��`��� + ��s�x�X </summary>
        public const string ct_Col_DraftKindAndBankCode = "DraftKindAndBankCode";

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

        /// <summary> �J�n�����̌������v </summary>
        public const string ct_Col_CountMonth1 = "CountMonth1";
        /// <summary> �Q�����ڕ��̌������v  </summary>
        public const string ct_Col_CountMonth2 = "CountMonth2";
        /// <summary> �R�����ڕ��̌������v  </summary>
        public const string ct_Col_CountMonth3 = "CountMonth3";
        /// <summary> �S�����ڕ��̌������v  </summary>
        public const string ct_Col_CountMonth4 = "CountMonth4";
        /// <summary> �T�����ڕ��̌������v  </summary>
        public const string ct_Col_CountMonth5 = "CountMonth5";
        /// <summary> �U�����ڕ��̌������v  </summary>
        public const string ct_Col_CountMonth6 = "CountMonth6";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ��`�����ʕ\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`�����ʕ\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02305EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� ��`�����ʕ\DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// ��`�����ʕ\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ��`�����ʕ\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_TegataKibiListReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_TegataKibiListReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_TegataKibiListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataKibiListReportData];
                // ���t
                dt.Columns.Add(ct_Col_Day, typeof(string));
                dt.Columns[ct_Col_Day].DefaultValue = string.Empty;
                // ��`��ʃR�[�h
                dt.Columns.Add(ct_Col_DraftKindCd, typeof(string));
                dt.Columns[ct_Col_DraftKindCd].DefaultValue = string.Empty;
                // ��`��ʖ���
                dt.Columns.Add(ct_Col_DraftKindName, typeof(string));
                dt.Columns[ct_Col_DraftKindName].DefaultValue = string.Empty;
                // ��s�x�X�R�[�h
                dt.Columns.Add(ct_Col_BankAndBranchCd, typeof(string));
                dt.Columns[ct_Col_BankAndBranchCd].DefaultValue = string.Empty;
                // ��s�x�X����
                dt.Columns.Add(ct_Col_BankAndBranchNm, typeof(string));
                dt.Columns[ct_Col_BankAndBranchNm].DefaultValue = string.Empty;
                // ��`��� + ��s�x�X
                dt.Columns.Add(ct_Col_DraftKindAndBankCode, typeof(string));
                dt.Columns[ct_Col_DraftKindAndBankCode].DefaultValue = string.Empty;

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

                // �J�n�����̌������v
                dt.Columns.Add(ct_Col_CountMonth1, typeof(long));
                dt.Columns[ct_Col_CountMonth1].DefaultValue = 0;
                // �Q�����ڕ��̌������v
                dt.Columns.Add(ct_Col_CountMonth2, typeof(long));
                dt.Columns[ct_Col_CountMonth2].DefaultValue = 0;
                // �R�����ڕ��̌������v
                dt.Columns.Add(ct_Col_CountMonth3, typeof(long));
                dt.Columns[ct_Col_CountMonth3].DefaultValue = 0;
                // �S�����ڕ��̌������v
                dt.Columns.Add(ct_Col_CountMonth4, typeof(long));
                dt.Columns[ct_Col_CountMonth4].DefaultValue = 0;
                // �T�����ڕ��̌������v
                dt.Columns.Add(ct_Col_CountMonth5, typeof(long));
                dt.Columns[ct_Col_CountMonth5].DefaultValue = 0;
                // �U�����ڕ��̌������v
                dt.Columns.Add(ct_Col_CountMonth6, typeof(long));
                dt.Columns[ct_Col_CountMonth6].DefaultValue = 0;

            }
        }
        #endregion
        #endregion
    }
}
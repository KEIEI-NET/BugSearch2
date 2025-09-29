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
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class PMTEG02505EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_TegataTorihikisakiListReportData = "Tbl_TegataTorihikisakiListReportData";

        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���_���� </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ於�� </summary>
        public const string ct_Col_CustomerName = "CustomerName";
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

        /// <summary> �J�n�����̍��v(���U) </summary>
        public const string ct_Col_SumMonth1Self = "SumMonth1Self";
        /// <summary> �Q�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth2Self = "SumMonth2Self";
        /// <summary> �R�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth3Self = "SumMonth3Self";
        /// <summary> �S�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth4Self = "SumMonth4Self";
        /// <summary> �T�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth5Self = "SumMonth5Self";
        /// <summary> �U�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth6Self = "SumMonth6Self";
        /// <summary> �U�����ȍ~���̍��v(���U)  </summary>
        public const string ct_Col_SumMonthSpareSelf = "SumMonthSpareSelf";
        /// <summary> ���v(���U)  </summary>
        public const string ct_Col_SumMonthAllSelf = "SumMonthAllSelf";

        /// <summary> �J�n�����̍��v(���U) </summary>
        public const string ct_Col_SumMonth1Else = "SumMonth1Else";
        /// <summary> �Q�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth2Else = "SumMonth2Else";
        /// <summary> �R�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth3Else = "SumMonth3Else";
        /// <summary> �S�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth4Else = "SumMonth4Else";
        /// <summary> �T�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth5Else = "SumMonth5Else";
        /// <summary> �U�����ڕ��̍��v(���U)  </summary>
        public const string ct_Col_SumMonth6Else = "SumMonth6Else";
        /// <summary> �U�����ȍ~���̍��v(���U)  </summary>
        public const string ct_Col_SumMonthSpareElse = "SumMonthSpareElse";
        /// <summary> ���v(���U)  </summary>
        public const string ct_Col_SumMonthAllElse = "SumMonthAllElse";

        /// <summary> ���� </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> �o�͏� </summary>
        public const string ct_Col_PrintType = "PrintType";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ��`�����ʕ\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`�����ʕ\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public PMTEG02505EA()
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
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_TegataTorihikisakiListReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_TegataTorihikisakiListReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_TegataTorihikisakiListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataTorihikisakiListReportData];
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;
                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionName, typeof(string));
                dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;
                // ���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = string.Empty;
                // ���Ӑ於��
                dt.Columns.Add(ct_Col_CustomerName, typeof(string));
                dt.Columns[ct_Col_CustomerName].DefaultValue = string.Empty;
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

                // �J�n�����̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth1Self, typeof(long));
                dt.Columns[ct_Col_SumMonth1Self].DefaultValue = 0;
                // �Q�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth2Self, typeof(long));
                dt.Columns[ct_Col_SumMonth2Self].DefaultValue = 0;
                // �R�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth3Self, typeof(long));
                dt.Columns[ct_Col_SumMonth3Self].DefaultValue = 0;
                // �S�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth4Self, typeof(long));
                dt.Columns[ct_Col_SumMonth4Self].DefaultValue = 0;
                // �T�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth5Self, typeof(long));
                dt.Columns[ct_Col_SumMonth5Self].DefaultValue = 0;
                // �U�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth6Self, typeof(long));
                dt.Columns[ct_Col_SumMonth6Self].DefaultValue = 0;
                // �U�����ȍ~���̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonthSpareSelf, typeof(long));
                dt.Columns[ct_Col_SumMonthSpareSelf].DefaultValue = 0;
                // ���v(���U)
                dt.Columns.Add(ct_Col_SumMonthAllSelf, typeof(long));
                dt.Columns[ct_Col_SumMonthAllSelf].DefaultValue = 0;

                // �J�n�����̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth1Else, typeof(long));
                dt.Columns[ct_Col_SumMonth1Else].DefaultValue = 0;
                // �Q�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth2Else, typeof(long));
                dt.Columns[ct_Col_SumMonth2Else].DefaultValue = 0;
                // �R�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth3Else, typeof(long));
                dt.Columns[ct_Col_SumMonth3Else].DefaultValue = 0;
                // �S�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth4Else, typeof(long));
                dt.Columns[ct_Col_SumMonth4Else].DefaultValue = 0;
                // �T�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth5Else, typeof(long));
                dt.Columns[ct_Col_SumMonth5Else].DefaultValue = 0;
                // �U�����ڕ��̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonth6Else, typeof(long));
                dt.Columns[ct_Col_SumMonth6Else].DefaultValue = 0;
                // �U�����ȍ~���̍��v(���U)
                dt.Columns.Add(ct_Col_SumMonthSpareElse, typeof(long));
                dt.Columns[ct_Col_SumMonthSpareElse].DefaultValue = 0;
                // ���v(���U)
                dt.Columns.Add(ct_Col_SumMonthAllElse, typeof(long));
                dt.Columns[ct_Col_SumMonthAllElse].DefaultValue = 0;

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
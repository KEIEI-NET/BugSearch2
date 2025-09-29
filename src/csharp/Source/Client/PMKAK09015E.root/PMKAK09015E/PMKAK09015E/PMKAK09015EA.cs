//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\�@�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//


using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d���摍���}�X�^�ꗗ�\�@�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���摍���}�X�^�ꗗ�\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : FSI�����@�v</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    public class PMKAK09015EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_SumSuppStReportData = "Tbl_SumSuppStReportData";

        /// <summary> �������_�R�[�h </summary>
        public const string ct_Col_SumSectionCd = "SumSectionCd";
        /// <summary> �������_�� </summary>
        public const string ct_Col_SumSectionGuideSnm = "SumSectionGuideSnm";
        /// <summary> �����d����R�[�h </summary>
        public const string ct_Col_SumSupplierCd = "SumSupplierCd";
        /// <summary> �����d���於�P </summary>
        public const string ct_Col_SumSupplierNm1 = "SumSupplierNm1";
        /// <summary> �����d���於�Q </summary>
        public const string ct_Col_SumSupplierNm2 = "SumSupplierNm2";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCd = "SectionCd";
        /// <summary> ���_�� </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���於�P </summary>
        public const string ct_Col_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於�Q </summary>
        public const string ct_Col_SupplierNm2 = "SupplierNm2";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �d�������}�X�^�ꗗ�\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�������}�X�^�ꗗ�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public PMKAK09015EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �d���摍���}�X�^�ꗗ�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �d���摍���}�X�^�ꗗ�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �d���摍���}�X�^�ꗗ�\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_SumSuppStReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_SumSuppStReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_SumSuppStReportData);

                DataTable dt = ds.Tables[ct_Tbl_SumSuppStReportData];


                // �������_�R�[�h
                dt.Columns.Add(ct_Col_SumSectionCd, typeof(string));
                dt.Columns[ct_Col_SumSectionCd].DefaultValue = string.Empty;

                // �������_��
                dt.Columns.Add(ct_Col_SumSectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SumSectionGuideSnm].DefaultValue = string.Empty;

                // �����d����R�[�h
                dt.Columns.Add(ct_Col_SumSupplierCd, typeof(int));
                dt.Columns[ct_Col_SumSupplierCd].DefaultValue = 0;

                // �����d���於�P
                dt.Columns.Add(ct_Col_SumSupplierNm1, typeof(string));
                dt.Columns[ct_Col_SumSupplierNm1].DefaultValue = string.Empty;

                // �����d���於�Q
                dt.Columns.Add(ct_Col_SumSupplierNm2, typeof(string));
                dt.Columns[ct_Col_SumSupplierNm2].DefaultValue = string.Empty;

                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCd, typeof(string));
                dt.Columns[ct_Col_SectionCd].DefaultValue = string.Empty;

                // ���_��
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // �d����R�[�h
                dt.Columns.Add(ct_Col_SupplierCd, typeof(int));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                // �d���於�P
                dt.Columns.Add(ct_Col_SupplierNm1, typeof(string));
                dt.Columns[ct_Col_SupplierNm1].DefaultValue = string.Empty;

                // �d���於�Q
                dt.Columns.Add(ct_Col_SupplierNm2, typeof(string));
                dt.Columns[ct_Col_SupplierNm2].DefaultValue = string.Empty;

            }
        }
        #endregion �� �d�������}�X�^�ꗗDataSet�e�[�u���X�L�[�}�ݒ�
        #endregion �� Static Public Method
    }
}
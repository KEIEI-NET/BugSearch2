using System;
using System.Data;
//using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �ڕW����Δ�\(����ڕW���z)�`���[�g�p���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڕW����Δ�\(����ڕW���z)�`���[�g�p���o���ʃe�[�u���X�L�[�}�ł��B</br>
    /// <br>Programmer : �l�v�R</br>
    /// <br>Date       : 2007.04.19</br>
    /// </remarks>
    public class MAMOK02123EB
    {
        #region Public Members
        /// <summary>�ڕW����Δ�\(����ڕW���z)�`���[�g�p�f�[�^�e�[�u����</summary>
        public const string CT_CsSalesTargetDataTable     = "CsSalesTargetDataTable";
        /// <summary>�ڕW����Δ�\(����ڕW���z)�`���[�g�p�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string CT_CsSalesTargetBuffDataTable = "CsSalesTargetBuffDataTable";

        #region �ڕW����Δ�\�`���[�g�p�J�������
        /// <summary>�K�p�J�n��</summary>
        public const string CT_CsSalesTarget_ApplyStaDate      = "��";
/*
        /// <summary>����ڕW���z(���t��)</summary>
        public const string CT_CsSalesTarget_SalesTargetMoney  = "����ڕW���z";

        /// <summary>������ы��z(���t��)</summary>
        public const string CT_CsSalesTarget_SalesMoney        = "������ы��z";

        /// <summary>����ڕW�e���z(���t��)</summary>
        public const string CT_CsSalesTarget_SalesTargetProfit = "����ڕW�e��";

        /// <summary>������ёe���z(���t��)</summary>
        public const string CT_CsSalesTarget_SalesProfit       = "������ёe��";

        /// <summary>����ڕW����(���t��)</summary>
        public const string CT_CsSalesTarget_SalesTargetCount  = "����ڕW����";

        /// <summary>������ѐ���(���t��)</summary>
        public const string CT_CsSalesTarget_SalesCount        = "������ѐ���";
*/
        /// <summary>�L�[�u���C�N</summary>
        public const string COL_KEYBREAK_AR = "KEYBREAK_AR";
        #endregion �ڕW����Δ�\�`���[�g�p�J�������
        #endregion Public Members

        #region Constructor
        /// <summary>
        /// �ڕW����Δ�\(����ڕW���z)�`���[�g�p���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڕW����Δ�\(����ڕW���z)���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : �l�v�R</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        public MAMOK02123EB()
        {
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �l�v�R</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(CT_CsSalesTargetDataTable)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[CT_CsSalesTargetDataTable].Clear();
            }
            else
            {
                CreateSalesTarget_MoneyTable(ref ds, 0);

            }

            // �o�b�t�@�f�[�^�e�[�u��------------------------------------------
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(CT_CsSalesTargetBuffDataTable)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[CT_CsSalesTargetBuffDataTable].Clear();
            }
            else
            {
                CreateSalesTarget_MoneyTable(ref ds, 1);
            }
        }
        #endregion Methods

        #region Private Methods

        /// <summary>
        /// �ڕW����Δ�\(����ڕW���z)�`���[�g�p���o���ʍ쐬����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <param name="buffCheck">�o�b�t�@�`�F�b�N</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �l�v�R</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        private static void CreateSalesTarget_MoneyTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(CT_CsSalesTargetDataTable);
                dt = ds.Tables[CT_CsSalesTargetDataTable];
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(CT_CsSalesTargetBuffDataTable);
                dt = ds.Tables[CT_CsSalesTargetBuffDataTable];
            }
/*
            // �K�p�J�n��
            dt.Columns.Add(CT_CsSalesTarget_ApplyStaDate, typeof(String));
            dt.Columns[CT_CsSalesTarget_ApplyStaDate].DefaultValue = "";

            // ����ڕW���z
            dt.Columns.Add(CT_CsSalesTarget_SalesTargetMoney, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesTargetMoney].DefaultValue = 0;

            // ������ы��z
            dt.Columns.Add(CT_CsSalesTarget_SalesMoney, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesMoney].DefaultValue = 0;

            // ����ڕW�e���z
            dt.Columns.Add(CT_CsSalesTarget_SalesTargetProfit, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesTargetProfit].DefaultValue = 0;

            // ������ёe���z
            dt.Columns.Add(CT_CsSalesTarget_SalesProfit, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesProfit].DefaultValue = 0;

            // ����ڕW����
            dt.Columns.Add(CT_CsSalesTarget_SalesTargetCount, typeof(Double));
            dt.Columns[CT_CsSalesTarget_SalesTargetCount].DefaultValue = 0.0;

            // ������ѐ���
            dt.Columns.Add(CT_CsSalesTarget_SalesCount, typeof(Double));
            dt.Columns[CT_CsSalesTarget_SalesCount].DefaultValue = 0.0;
*/
            // �L�[�u���C�N
            dt.Columns.Add(COL_KEYBREAK_AR, typeof(String));
            dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";

            // �K�p�J�n��
            dt.Columns.Add(CT_CsSalesTarget_ApplyStaDate, typeof(String));
            dt.Columns[CT_CsSalesTarget_ApplyStaDate].DefaultValue = "";
        }

        #endregion Methods
    }
}
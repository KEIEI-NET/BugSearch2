//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�m�F�\�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ��`�m�F�\�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�m�F�\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class PMTEG02005EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_TegataConfirmReportData = "Tbl_TegataConfirmReportData";

        /// <summary> ��`��ʃR�[�h </summary>
        public const string ct_Col_DraftKindCd = "DraftKindCd";
        /// <summary> ��`��ʖ��� </summary>
        public const string ct_Col_DraftKindName = "DraftKindName";
        /// <summary> ��s�E�x�X�R�[�h </summary>
        public const string ct_Col_BankAndBranchCd = "BankAndBranchCd";
        /// <summary> ��s�E�x�X���� </summary>
        public const string ct_Col_BankAndBranchNm = "BankAndBranchNm";
        /// <summary> ������/�x���� </summary>
        public const string ct_Col_DepositDate = "DepositDate";
        /// <summary> �U�o�� </summary>
        public const string ct_Col_DraftDrawingDate = "DraftDrawingDate";
        /// <summary> ������ </summary>
        public const string ct_Col_ValidityTerm = "ValidityTerm";
        /// <summary> ��`�敪 </summary>
        public const string ct_Col_DraftDivide = "DraftDivide";
        /// <summary> ����`�ԍ� </summary>
        public const string ct_Col_RcvDraftNo = "RcvDraftNo";
        /// <summary> �v�㋒�_�R�[�h </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> �������z/�x�����z </summary>
        public const string ct_Col_Deposit = "Deposit";
        /// <summary> �`�[�E�v1 </summary>
        public const string ct_Col_Outline1 = "Outline1";
        /// <summary> �`�[�E�v2 </summary>
        public const string ct_Col_Outline2 = "Outline2";
        /// <summary> �`�[�ԍ� </summary>
        public const string ct_Col_SlipNo = "SlipNo";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ��`�m�F�\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`�m�F�\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02005EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� ��`�m�F�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// ��`�m�F�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ��`�m�F�\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_TegataConfirmReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_TegataConfirmReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_TegataConfirmReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataConfirmReportData];
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
                // ������/�x����
                dt.Columns.Add(ct_Col_DepositDate, typeof(string));
                dt.Columns[ct_Col_DepositDate].DefaultValue = string.Empty;
                // �U�o��
                dt.Columns.Add(ct_Col_DraftDrawingDate, typeof(string));
                dt.Columns[ct_Col_DraftDrawingDate].DefaultValue = string.Empty;
                // ������
                dt.Columns.Add(ct_Col_ValidityTerm, typeof(string));
                dt.Columns[ct_Col_ValidityTerm].DefaultValue = string.Empty;
                // ��`�敪
                dt.Columns.Add(ct_Col_DraftDivide, typeof(string));
                dt.Columns[ct_Col_DraftDivide].DefaultValue = string.Empty;
                // ����`�ԍ�
                dt.Columns.Add(ct_Col_RcvDraftNo, typeof(string));
                dt.Columns[ct_Col_RcvDraftNo].DefaultValue = string.Empty;
                // �v�㋒�_�R�[�h 
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;
                // ���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = string.Empty;
                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;
                // �������z/�x�����z 
                dt.Columns.Add(ct_Col_Deposit, typeof(long));
                dt.Columns[ct_Col_Deposit].DefaultValue = 0;
                // �`�[�E�v1 
                dt.Columns.Add(ct_Col_Outline1, typeof(string));
                dt.Columns[ct_Col_Outline1].DefaultValue = string.Empty;
                // �`�[�E�v2
                dt.Columns.Add(ct_Col_Outline2, typeof(string));
                dt.Columns[ct_Col_Outline2].DefaultValue = string.Empty;
                // �`�[�ԍ�
                dt.Columns.Add(ct_Col_SlipNo, typeof(string));
                dt.Columns[ct_Col_SlipNo].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}
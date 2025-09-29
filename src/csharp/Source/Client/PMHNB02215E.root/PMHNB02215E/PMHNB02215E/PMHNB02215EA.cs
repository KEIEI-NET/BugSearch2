//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �ԕi���R�ꗗ�\�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi���R�ꗗ�\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    public class PMHNB02215EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_RetGoodsReasonReportData = "Tbl_RetGoodsReasonReportData";
        /// <summary> �ԕi���R�R�[�h </summary>
        public const string ct_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";
        /// <summary> �ԕi���R </summary>
        public const string ct_Col_RetGoodsReason = "RetGoodsReason";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���_���� </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ於�� </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> �S���҃R�[�h </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> �S���Җ��� </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> �ڍ׃R�[�h </summary>
        public const string ct_Col_DetailCode = "DetailCode";
        /// <summary> �ڍז��� </summary>
        public const string ct_Col_DetailNm = "DetailNm";
        /// <summary> �󒍎҃R�[�h </summary>
        public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> �󒍎Җ��� </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> ���s�҃R�[�h </summary>
        public const string ct_Col_SalesInputCode = "SalesInputCode";
        /// <summary> ���s�Җ��� </summary>
        public const string ct_Col_SalesInputName = "SalesInputName";
        /// <summary> ���z </summary>
        public const string ct_Col_MoneySum = "MoneySum";
        /// <summary> ���� </summary>
        public const string ct_Col_Count = "Count";
        /// <summary> �䗦 </summary>
        public const string ct_Col_Rate = "Rate";
        /// <summary> Detail�䗦 </summary>
        public const string ct_Col_DetailRate = "DetailRate";
        /// <summary> ���_�䗦 </summary>
        public const string ct_Col_SectionRate = "SectionRate";
        /// <summary> ���ьv�㋒�_�R�[�h </summary>
        public const string ct_Col_ResultsAddUpSecCd = "ResultsAddUpSecCd";
        /// <summary> ���� </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> �`�[��� </summary>
        public const string ct_Col_SlipKind = "SlipKind";
        /// <summary> �Ώ۔N�� </summary>
        public const string ct_Col_YearMonth = "YearMonth";
        /// <summary> �o�͏� </summary>
        public const string ct_Col_PrintType = "PrintType";
        /// <summary> ����s�ԍ� </summary>
        public const string ct_Col_SlipKey = "SlipKey";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �ԕi���R�ꗗ�\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ԕi���R�ꗗ�\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public PMHNB02215EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �ԕi���R�ꗗDataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �ԕi���R�ꗗDataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �ԕi���R�ꗗ�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_RetGoodsReasonReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_RetGoodsReasonReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_RetGoodsReasonReportData);

                DataTable dt = ds.Tables[ct_Tbl_RetGoodsReasonReportData];
                // �ԕi���R�R�[�h
                dt.Columns.Add(ct_Col_RetGoodsReasonDiv, typeof(string));
                dt.Columns[ct_Col_RetGoodsReasonDiv].DefaultValue = string.Empty;
                // �ԕi���R
                dt.Columns.Add(ct_Col_RetGoodsReason, typeof(string));
                dt.Columns[ct_Col_RetGoodsReason].DefaultValue = string.Empty;
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
                // �S���҃R�[�h
                dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = string.Empty;
                // �S���Җ���
                dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = string.Empty;
                // �󒍎҃R�[�h
                dt.Columns.Add(ct_Col_FrontEmployeeCd, typeof(string));
                dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = string.Empty;
                // �󒍎Җ���
                dt.Columns.Add(ct_Col_FrontEmployeeNm, typeof(string));
                dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = string.Empty;
                // ���s�҃R�[�h
                dt.Columns.Add(ct_Col_SalesInputCode, typeof(string));
                dt.Columns[ct_Col_SalesInputCode].DefaultValue = string.Empty;
                // ���s�Җ���
                dt.Columns.Add(ct_Col_SalesInputName, typeof(string));
                dt.Columns[ct_Col_SalesInputName].DefaultValue = string.Empty;
                // ���z
                dt.Columns.Add(ct_Col_MoneySum, typeof(Int64));
                dt.Columns[ct_Col_MoneySum].DefaultValue = 0;
                // ����
                dt.Columns.Add(ct_Col_Count, typeof(Int32));
                dt.Columns[ct_Col_Count].DefaultValue = 0;
                // �`�[���
                dt.Columns.Add(ct_Col_SlipKind, typeof(string));
                dt.Columns[ct_Col_SlipKind].DefaultValue = string.Empty;
                // �䗦
                dt.Columns.Add(ct_Col_Rate, typeof(double));
                dt.Columns[ct_Col_Rate].DefaultValue = 0;
                // Detail�䗦 
                dt.Columns.Add(ct_Col_DetailRate, typeof(double));
                dt.Columns[ct_Col_DetailRate].DefaultValue = 0;
                // ���_�䗦 
                dt.Columns.Add(ct_Col_SectionRate, typeof(double));
                dt.Columns[ct_Col_SectionRate].DefaultValue = 0;
                // ����
                dt.Columns.Add(ct_Col_ChangePage, typeof(string));
                dt.Columns[ct_Col_ChangePage].DefaultValue = string.Empty;
                // �Ώ۔N��
                dt.Columns.Add(ct_Col_YearMonth, typeof(string));
                dt.Columns[ct_Col_YearMonth].DefaultValue = string.Empty;
                // �o�͏�
                dt.Columns.Add(ct_Col_PrintType, typeof(string));
                dt.Columns[ct_Col_PrintType].DefaultValue = string.Empty;
                // ���ьv�㋒�_�R�[�h 
                dt.Columns.Add(ct_Col_ResultsAddUpSecCd, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCd].DefaultValue = string.Empty;
                // ����s�ԍ� 
                dt.Columns.Add(ct_Col_SlipKey, typeof(string));
                dt.Columns[ct_Col_SlipKey].DefaultValue = string.Empty;
                // �ڍ׃R�[�h 
                dt.Columns.Add(ct_Col_DetailCode, typeof(string));
                dt.Columns[ct_Col_DetailCode].DefaultValue = string.Empty;
                // �ڍז���
                dt.Columns.Add(ct_Col_DetailNm, typeof(string));
                dt.Columns[ct_Col_DetailNm].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}
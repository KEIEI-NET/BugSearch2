//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ��ԗ��ꗗ�\�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// Update Note  : 2010/05/08 ���C�� redmine #7156�̑Ή�
//�@�@�@�@�@�@�@: �Ԏ�Ɠ��Ӑ�R�[�h�̒��[�̈�
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����Ԍ��ԗ��ꗗ�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����Ԍ��ԗ��ꗗ�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �L�Q</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class PMSYA02105EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_MonthCarInspectListReportData = "Tbl_MonthCarInspectListReportData";

        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> �Ǘ����_�R�[�h </summary>
        public const string ct_Col_MngSectionCode = "MngSectionCode";
        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> �_���폜�敪 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> �ԗ��Ǘ��ԍ� </summary>
        public const string ct_Col_CarMngNo = "CarMngNo";
        /// <summary> ���q�Ǘ��R�[�h </summary>
        public const string ct_Col_CarMngCode = "CarMngCode";
        /// <summary> �o�^�ԍ� </summary>
        public const string ct_Col_NumberPlate = "NumberPlate";
        /// <summary> ���N�x </summary>
        public const string ct_Col_FirstEntryDate = "FirstEntryDate";
        /// <summary> �Ԏ�R�[�h </summary>
        public const string ct_Col_ModelCode = "ModelCode";
        /// <summary> �Ԏ피�p���� </summary>
        public const string ct_Col_ModelHalfName = "ModelHalfName";
        /// <summary> �^���i�t���^�j </summary>
        public const string ct_Col_FullModel = "FullModel";
        /// <summary> �ԑ�ԍ� </summary>
        public const string ct_Col_FrameNo = "FrameNo";
        /// <summary> �Ԍ������� </summary>
        public const string ct_Col_InspectMaturityDate = "InspectMaturityDate";
        /// <summary> �Ԍ����� </summary>
        public const string ct_Col_CarInspectYear = "CarInspectYear";
        /// <summary> ROW </summary>
        public const string ct_Col_Row = "Row";
        /// <summary> Group </summary>
        public const string ct_Col_Group = "Group";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �����Ԍ��ԗ��ꗗ�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����Ԍ��ԗ��ꗗ�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public PMSYA02105EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �ԕi���R�ꗗDataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �����Ԍ��ԗ��ꗗDataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �����Ԍ��ԗ��ꗗ�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// <br>Update Note: 2010/05/10 ���C�� �Ԏ�Ɠ��Ӑ�R�[�h�̒��[�̈�</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_MonthCarInspectListReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_MonthCarInspectListReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_MonthCarInspectListReportData);

                DataTable dt = ds.Tables[ct_Tbl_MonthCarInspectListReportData];

                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;
                // �Ǘ����_�R�[�h
                dt.Columns.Add(ct_Col_MngSectionCode, typeof(string));
                dt.Columns[ct_Col_MngSectionCode].DefaultValue = string.Empty;
                // ��ƃR�[�h
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;
                // �_���폜�敪
                dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
                dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;
                // ���Ӑ�R�[�h
                // --- UPD 2010/05/10 ---------->>>>>
                //dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                // --- UPD 2010/05/10 ----------<<<<<
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                // �ԗ��Ǘ��ԍ�
                dt.Columns.Add(ct_Col_CarMngNo, typeof(Int32));
                dt.Columns[ct_Col_CarMngNo].DefaultValue = 0;
                // ���q�Ǘ��R�[�h
                dt.Columns.Add(ct_Col_CarMngCode, typeof(string));
                dt.Columns[ct_Col_CarMngCode].DefaultValue = string.Empty;
                // �o�^�ԍ�
                dt.Columns.Add(ct_Col_NumberPlate, typeof(string));
                dt.Columns[ct_Col_NumberPlate].DefaultValue = string.Empty;
                // ���N�x
                dt.Columns.Add(ct_Col_FirstEntryDate, typeof(string));
                dt.Columns[ct_Col_FirstEntryDate].DefaultValue = string.Empty;
                // �Ԏ�R�[�h
                dt.Columns.Add(ct_Col_ModelCode, typeof(string));
                dt.Columns[ct_Col_ModelCode].DefaultValue = string.Empty;
                // �Ԏ피�p����
                dt.Columns.Add(ct_Col_ModelHalfName, typeof(string));
                dt.Columns[ct_Col_ModelHalfName].DefaultValue = string.Empty;
                // �^���i�t���^�j
                dt.Columns.Add(ct_Col_FullModel, typeof(string));
                dt.Columns[ct_Col_FullModel].DefaultValue = string.Empty;
                // �ԑ�ԍ�
                dt.Columns.Add(ct_Col_FrameNo, typeof(string));
                dt.Columns[ct_Col_FrameNo].DefaultValue = string.Empty;
                // �Ԍ�������
                dt.Columns.Add(ct_Col_InspectMaturityDate, typeof(string));
                dt.Columns[ct_Col_InspectMaturityDate].DefaultValue = string.Empty;
                // �Ԍ�����
                dt.Columns.Add(ct_Col_CarInspectYear, typeof(Int32));
                dt.Columns[ct_Col_CarInspectYear].DefaultValue = 0;
                // Row
                dt.Columns.Add(ct_Col_Row, typeof(Int32));
                dt.Columns[ct_Col_Row].DefaultValue = 1;
                // Group
                dt.Columns.Add(ct_Col_Group, typeof(string));
                dt.Columns[ct_Col_Group].DefaultValue = string.Empty;
            }
        }
        #endregion
        #endregion
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������ꗗ�\�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2010/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �� �� ��  2010/12/20  �C�����e : ���[���C�A�E�g��̓��t���ڂ𔄏�����ڂƓ��͓����ڂɕ�����
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �������ꗗ�\�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ꗗ�\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2010/07/01</br>
    /// </remarks>
    public class PMKAU02005EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_NoDepSalListData = "Tbl_NoDepSalListData";

        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> �����v�㋒�_�R�[�h </summary>
        public const string ct_Col_DemandAddUpSecCd = "DemandAddUpSecCd";
        /// <summary> �����v�㋒�_���� </summary>
        public const string ct_Col_DemandAddUpSecNm = "DemandAddUpSecNm";
        /// <summary> ������R�[�h </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";
        /// <summary> �����於�� </summary>
        public const string ct_Col_ClaimName = "ClaimName";
        /// <summary> �����於��2 </summary>
        public const string ct_Col_ClaimName2 = "ClaimName2";
        /// <summary> �����旪�� </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���_���� </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ於�� </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> ���Ӑ於��2 </summary>
        public const string ct_Col_CustomerName2 = "CustomerName2";
        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> ������t </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        ///// <summary> �`�[�������t </summary>
        //public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        // ---------------ADD 2010/12/20 ----------->>>>>
        /// <summary> �`�[�������t </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        // ---------------ADD 2010/12/20 -----------<<<<<
        /// <summary> ����`�[�ԍ� </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> ����`�[�敪 </summary>
        public const string ct_Col_SalesSlipCd = "SalesSlipCd";
        ///// <summary> ����`�[���v�i�ō��݁j </summary>
        //public const string ct_Col_SalesTotalTaxInc = "SalesTotalTaxInc";
        ///// <summary> ����`�[���v�i�Ŕ����j </summary>
        //public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        /// <summary> ����`�[���v�i�ō�/�Ŕ� ���f��̒l�j </summary>
        public const string ct_Col_SalesTotal = "SalesTotal";
        /// <summary> ������͎҃R�[�h </summary>
        public const string ct_Col_SalesInputCode = "SalesInputCode";
        /// <summary> ������͎Җ��� </summary>
        public const string ct_Col_SalesInputName = "SalesInputName";
        /// <summary> ��t�]�ƈ��R�[�h </summary>
        public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> ��t�]�ƈ����� </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> �̔��]�ƈ��R�[�h </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> �̔��]�ƈ����� </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> �`�[���l </summary>
        public const string ct_Col_SlipNote = "SlipNote";
        /// <summary> �`�[���l�Q </summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";
        /// <summary> �`�[���l�R </summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";
        /// <summary> ����`�[�敪���� </summary>
        public const string ct_Col_SalesSlipCdNm = "SalesSlipCdNm";
        /// <summary> ���������c�� </summary>
        public const string ct_Col_DepositAlwcBlnce = "DepositAlwcBlnce";
        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �������ꗗ�\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������ꗗ�\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public PMKAU02005EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �������ꗗ�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �������ꗗ�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �������ꗗ�\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>             ���[���C�A�E�g��̓��t���ڂ𔄏�����ڂƓ��͓����ڂɕ�����</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_NoDepSalListData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_NoDepSalListData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_NoDepSalListData);
                DataTable dt = ds.Tables[ct_Tbl_NoDepSalListData];

                // ��ƃR�[�h
                dt.Columns.Add( ct_Col_EnterpriseCode, typeof( string ) );
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;
                // �����v�㋒�_�R�[�h
                dt.Columns.Add( ct_Col_DemandAddUpSecCd, typeof( string ) );
                dt.Columns[ct_Col_DemandAddUpSecCd].DefaultValue = string.Empty;
                // �����v�㋒�_����
                dt.Columns.Add( ct_Col_DemandAddUpSecNm, typeof( string ) );
                dt.Columns[ct_Col_DemandAddUpSecNm].DefaultValue = string.Empty;
                // ������R�[�h
                dt.Columns.Add( ct_Col_ClaimCode, typeof( Int32 ) );
                dt.Columns[ct_Col_ClaimCode].DefaultValue = 0;
                // �����於��
                dt.Columns.Add( ct_Col_ClaimName, typeof( string ) );
                dt.Columns[ct_Col_ClaimName].DefaultValue = string.Empty;
                // �����於��2
                dt.Columns.Add( ct_Col_ClaimName2, typeof( string ) );
                dt.Columns[ct_Col_ClaimName2].DefaultValue = string.Empty;
                // �����旪��
                dt.Columns.Add( ct_Col_ClaimSnm, typeof( string ) );
                dt.Columns[ct_Col_ClaimSnm].DefaultValue = string.Empty;
                // ���_�R�[�h
                dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;
                // ���_����
                dt.Columns.Add( ct_Col_SectionName, typeof( string ) );
                dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;
                // ���Ӑ�R�[�h
                dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                // ���Ӑ於��
                dt.Columns.Add( ct_Col_CustomerName, typeof( string ) );
                dt.Columns[ct_Col_CustomerName].DefaultValue = string.Empty;
                // ���Ӑ於��2
                dt.Columns.Add( ct_Col_CustomerName2, typeof( string ) );
                dt.Columns[ct_Col_CustomerName2].DefaultValue = string.Empty;
                // ���Ӑ旪��
                dt.Columns.Add( ct_Col_CustomerSnm, typeof( string ) );
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;
                // ������t
                dt.Columns.Add( ct_Col_SalesDate, typeof( string ) );
                dt.Columns[ct_Col_SalesDate].DefaultValue = string.Empty;
                //// �`�[�������t
                //dt.Columns.Add( ct_Col_SearchSlipDate, typeof( Int32 ) );
                //dt.Columns[ct_Col_SearchSlipDate].DefaultValue = 0;
                // ---------------ADD 2010/12/20 ----------->>>>>
                // �`�[�������t
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(string));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = string.Empty;
                // ---------------ADD 2010/12/20 -----------<<<<<
                // ����`�[�ԍ�
                dt.Columns.Add( ct_Col_SalesSlipNum, typeof( string ) );
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = string.Empty;
                // ����`�[�敪
                dt.Columns.Add( ct_Col_SalesSlipCd, typeof( Int32 ) );
                dt.Columns[ct_Col_SalesSlipCd].DefaultValue = 0;
                //// ����`�[���v�i�ō��݁j
                //dt.Columns.Add( ct_Col_SalesTotalTaxInc, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxInc].DefaultValue = 0;
                //// ����`�[���v�i�Ŕ����j
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = 0;
                // ����`�[���v�i�ō�/�Ŕ� ���f��̒l�j
                dt.Columns.Add( ct_Col_SalesTotal, typeof( Int64 ) );
                dt.Columns[ct_Col_SalesTotal].DefaultValue = 0;
                // ������͎҃R�[�h
                dt.Columns.Add( ct_Col_SalesInputCode, typeof( string ) );
                dt.Columns[ct_Col_SalesInputCode].DefaultValue = string.Empty;
                // ������͎Җ���
                dt.Columns.Add( ct_Col_SalesInputName, typeof( string ) );
                dt.Columns[ct_Col_SalesInputName].DefaultValue = string.Empty;
                // ��t�]�ƈ��R�[�h
                dt.Columns.Add( ct_Col_FrontEmployeeCd, typeof( string ) );
                dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = string.Empty;
                // ��t�]�ƈ�����
                dt.Columns.Add( ct_Col_FrontEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = string.Empty;
                // �̔��]�ƈ��R�[�h
                dt.Columns.Add( ct_Col_SalesEmployeeCd, typeof( string ) );
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = string.Empty;
                // �̔��]�ƈ�����
                dt.Columns.Add( ct_Col_SalesEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = string.Empty;
                // �`�[���l
                dt.Columns.Add( ct_Col_SlipNote, typeof( string ) );
                dt.Columns[ct_Col_SlipNote].DefaultValue = string.Empty;
                // �`�[���l�Q
                dt.Columns.Add( ct_Col_SlipNote2, typeof( string ) );
                dt.Columns[ct_Col_SlipNote2].DefaultValue = string.Empty;
                // �`�[���l�R
                dt.Columns.Add( ct_Col_SlipNote3, typeof( string ) );
                dt.Columns[ct_Col_SlipNote3].DefaultValue = string.Empty;
                // ����`�[�敪����
                dt.Columns.Add( ct_Col_SalesSlipCdNm, typeof( string ) );
                dt.Columns[ct_Col_SalesSlipCdNm].DefaultValue = string.Empty;
                // ���������c��
                dt.Columns.Add( ct_Col_DepositAlwcBlnce, typeof( Int64 ) );
                dt.Columns[ct_Col_DepositAlwcBlnce].DefaultValue = 0;
            }
        }
        #endregion
        #endregion
    }
}
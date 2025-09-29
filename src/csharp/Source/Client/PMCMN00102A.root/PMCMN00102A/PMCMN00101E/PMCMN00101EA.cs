using System;
using System.Data;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����Z�o���W���[���^�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����Z�o���W���[���Ŏg�p����f�[�^�X�L�[�}�N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.07.31</br>
    /// <br></br>
    /// </remarks>
    public class PMCMN00101EA
    {
        # region [public const]
        /// <summary> �����敪 </summary>
        public const string ct_Col_ProcDiv = "ProcDiv";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �O��������� </summary>
        public const string ct_Col_PrevTotalDay = "PrevTotalDay";
        /// <summary> ����������� </summary>
        public const string ct_Col_CurrentTotalDay = "CurrentTotalDay";
        /// <summary> �O��������� </summary>
        public const string ct_Col_PrevTotalMonth = "PrevTotalMonth";
        /// <summary> ����������� </summary>
        public const string ct_Col_CurrentTotalMonth = "CurrentTotalMonth";
        /// <summary> �����[�g�����σt���O </summary>
        public const string ct_Col_RemotedFlag = "RemotedFlag";
        /// <summary> ����������Z�o�σt���O </summary>
        public const string ct_Col_CurrentCalcFlag = "CurrentCalcFlag";
        /// <summary> �R���o�[�g�����敪 </summary>
        public const string ct_Col_ConvertProcessDivCd = "ConvertProcessDivCd";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        /// <summary> �����X�V�J�n�N���� </summary>
        public const string ct_Col_StartCAddUpUpdDate = "StartCAddUpUpdDate";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

        /// <summary>
        /// �����敪�@�������|
        /// </summary>
        public const Int32 ct_ProcDiv_AccRec = 0;
        /// <summary>
        /// �����敪�@�x�����|
        /// </summary>
        public const Int32 ct_ProcDiv_AccPay = 1;

        # endregion

        # region [private const]
        /// <summary>Int32�����l</summary>
        private const Int32 defaultValueOfInt32 = 0;
        /// <summary>String�����l</summary>
        private const String defaultValueOfstring = "";
        # endregion

        # region [�e�[�u������]
        /// <summary>
        /// ���������e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfHisMonthly()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // �����敪
            dt.Columns.Add( ct_Col_ProcDiv, typeof( Int32 ) );
            dt.Columns[ct_Col_ProcDiv].DefaultValue = defaultValueOfInt32;
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalMonth].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalMonth].DefaultValue = DateTime.MinValue;
            // �R���o�[�g�����敪
            dt.Columns.Add( ct_Col_ConvertProcessDivCd, typeof( Int32 ) );
            dt.Columns[ct_Col_ConvertProcessDivCd].DefaultValue = defaultValueOfInt32;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_ProcDiv], dt.Columns[ct_Col_SectionCode] };

            return dt;
        }
        /// <summary>
        /// ���z�������|�e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcAccRec()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // ���Ӑ�R�[�h
            dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalMonth].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalMonth].DefaultValue = DateTime.MinValue;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_CustomerCode] };

            return dt;
        }
        /// <summary>
        /// ���z�������|�e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcAccPay()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // �d����R�[�h
            dt.Columns.Add( ct_Col_SupplierCd, typeof( Int32 ) );
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfInt32;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalMonth].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalMonth].DefaultValue = DateTime.MinValue;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_SupplierCd] };

            return dt;
        }
        /// <summary>
        /// ���𐿋��e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfHisDmdC()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �R���o�[�g�����敪
            dt.Columns.Add( ct_Col_ConvertProcessDivCd, typeof( Int32 ) );
            dt.Columns[ct_Col_ConvertProcessDivCd].DefaultValue = defaultValueOfInt32;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode] };

            return dt;
        }
        /// <summary>
        /// �����x���e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfHisPayment()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �R���o�[�g�����敪
            dt.Columns.Add( ct_Col_ConvertProcessDivCd, typeof( Int32 ) );
            dt.Columns[ct_Col_ConvertProcessDivCd].DefaultValue = defaultValueOfInt32;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode] };

            return dt;
        }
        /// <summary>
        /// ���z�����e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcDmdC()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // ���Ӑ�R�[�h
            dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_CustomerCode] };

            return dt;
        }
        /// <summary>
        /// ���z�x���e�[�u������
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcPayment()
        {
            DataTable dt = new DataTable();

            # region [���`]
            // ���_�R�[�h
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // �d����R�[�h
            dt.Columns.Add( ct_Col_SupplierCd, typeof( Int32 ) );
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfInt32;
            // �O���������
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // �����������
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // �����[�g�����σt���O
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // ����������Z�o�σt���O
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // �����X�V�J�n�N����
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // �v���C�}���L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_SupplierCd] };

            return dt;
        }
        # endregion
    }
}

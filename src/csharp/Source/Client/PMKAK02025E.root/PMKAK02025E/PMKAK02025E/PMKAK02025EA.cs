//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\�i�����j �e�[�u�����N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬 �d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ������
// �C �� ��  2020/04/10  �C�����e : �y���ŗ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870141-00 �쐬�S�� : 3H ����
// �C �� ��  2022/10/20  �C�����e : �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// ���|�c���ꗗ�\(����) �d���攃�|���z�f�[�^�p�e�[�u���X�L�[�}��`�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\(����) �d���攃�|���z�f�[�^�p�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : FSI�y�~ �їR��</br>
    /// <br>Date       : 2012/09/14</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : 3H ����</br>
    /// <br>Date       : 2022/10/20</br>
	/// </remarks>
	public class PMKAK02025EA
	{
		#region �� Public Const

		/// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_AccPaymentList = "Tbl_AccPaymentList";

        /// <summary> �����v�㋒�_�R�[�h </summary>
        public const string ct_Col_SumAddUpSecCode = "SumAddUpSecCode";
        /// <summary> �����v�㋒�_���� </summary>
        public const string ct_Col_SumSectionGuideNm = "SumSectionGuideNm";
        /// <summary> �v�㋒�_�R�[�h </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> �v�㋒�_���� </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> �����x����R�[�h </summary>
        public const string ct_Col_SumPayeeCode = "SumPayeeCode";
        /// <summary> �����x���旪�� </summary>
        public const string ct_Col_SumPayeeSnm = "SumPayeeSnm";
        /// <summary> �x����R�[�h </summary>
        public const string ct_Col_PayeeCode = "PayeeCode";
        /// <summary> �x���旪�� </summary>
        public const string ct_Col_PayeeSnm = "PayeeSnm";
        /// <summary> �O�񔃊|���z </summary>
        public const string ct_Col_LastTimeAccPay = "LastTimeAccPay";
        /// <summary> ����x�����z�i�ʏ�x���j </summary>
        public const string ct_Col_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> ����萔���z�i�ʏ�x���j </summary>
        public const string ct_Col_ThisTimeFeePayNrml = "ThisTimeFeePayNrml";
        /// <summary> ����l���z�i�ʏ�x���j </summary>
        public const string ct_Col_ThisTimeDisPayNrml = "ThisTimeDisPayNrml";
        /// <summary> ����J�z�c���i���|�v�j </summary>
        public const string ct_Col_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";
        /// <summary> ���E�㍡��d�����z </summary>
        public const string ct_Col_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> �ԕi�l�� </summary>
        public const string ct_Col_ThisRgdsDisPric = "ThisRgdsDisPric";
        /// <summary> ���E�㍡��d������� </summary>
        public const string ct_Col_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> ����d�����z </summary>
        public const string ct_Col_ThisTimeStockPrice = "ThisTimeStockPrice";
        /// <summary> �d�����v�c���i���|�v�j </summary>
        public const string ct_Col_StckTtlAccPayBalance = "StckTtlAccPayBalance";
        /// <summary> �d���`�[���� </summary>
        public const string ct_Col_StockSlipCount = "StockSlipCount";
        /// <summary> ����ԕi�l�����z </summary>
        public const string ct_Col_ThisStockPricRgdsDis = "ThisStockPricRgdsDis";
        /// <summary> ���񍇌v���z�i����p�j </summary>
        public const string ct_Col_StockPricTax = "StockPricTax";
        /// <summary> ���� </summary>
        public const string ct_Col_CashPayment = "CashPayment";
        /// <summary> �U�� </summary>
        public const string ct_Col_TrfrPayment = "TrfrPayment";
        /// <summary> ���؎� </summary>
        public const string ct_Col_CheckPayment = "CheckPayment";
        /// <summary> ��` </summary>
        public const string ct_Col_DraftPayment = "DraftPayment";
        /// <summary> ���E </summary>
        public const string ct_Col_OffsetPayment = "OffsetPayment";
        /// <summary> �����U�� </summary>
        public const string ct_Col_FundTransferPayment = "FundTransferPayment";
        /// <summary> ���̑� </summary>
        public const string ct_Col_OthsPayment = "OthsPayment";

        // ����p
        /// <summary> ���d���z </summary>
        public const string ct_Col_PureStock = "PureStock";

        /// <summary> ���������X�V </summary>
        public const string Col_MonAddUpNonProc = "MonAddUpNonProc";

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        /// <summary> �d���z(�v�ŗ�1) </summary>
        public const string ct_Col_TotalThisTimeStockPriceTaxRate1 = "TotalThisTimeStockPriceTaxRate1";

        /// <summary> �d���z(�v�ŗ�2) </summary>
        public const string ct_Col_TotalThisTimeStockPriceTaxRate2 = "TotalThisTimeStockPriceTaxRate2";

        /// <summary> �d���z(�v���̑�) </summary>
        public const string ct_Col_TotalThisTimeStockPriceOther = "TotalThisTimeStockPriceOther";

        /// <summary> �ԕi�l��(�v�ŗ�1) </summary>
        public const string ct_Col_TotalThisRgdsDisPricTaxRate1 = "TotalThisRgdsDisPricTaxRate1";

        /// <summary> �ԕi�l��(�v�ŗ�2) </summary>
        public const string ct_Col_TotalThisRgdsDisPricTaxRate2 = "TotalThisRgdsDisPricTaxRate2";

        /// <summary> �ԕi�l��(�v���̑�) </summary>
        public const string ct_Col_TotalThisRgdsDisPricOther = "TotalThisRgdsDisPricOther";

        /// <summary> ���d���z(�v�ŗ�1) </summary>
        public const string ct_Col_TotalPureStockTaxRate1 = "TotalPureStockTaxRate1";

        /// <summary> ���d���z(�v�ŗ�2) </summary>
        public const string ct_Col_TotalPureStockTaxRate2 = "TotalPureStockTaxRate2";

        /// <summary> ���d���z(�v���̑�) </summary>
        public const string ct_Col_TotalPureStockOther = "TotalPureStockOther";

        /// <summary> �����(�v�ŗ�1) </summary>
        public const string ct_Col_TotalStockPricTaxTaxRate1 = "TotalStockPricTaxTaxRate1";

        /// <summary> �����(�v�ŗ�2) </summary>
        public const string ct_Col_TotalStockPricTaxTaxRate2 = "TotalStockPricTaxTaxRate2";

        /// <summary> �����(�v���̑�) </summary>
        public const string ct_Col_TotalStockPricTaxOther = "TotalStockPricTaxOther";

        /// <summary> �������v(�v�ŗ�1) </summary>
        public const string ct_Col_TotalStckTtlAccPayBalanceTaxRate1 = "TotalStckTtlAccPayBalanceTaxRate1";

        /// <summary> �������v(�v�ŗ�2) </summary>
        public const string ct_Col_TotalStckTtlAccPayBalanceTaxRate2 = "TotalStckTtlAccPayBalanceTaxRate2";

        /// <summary> �������v(�v���̑�) </summary>
        public const string ct_Col_TotalStckTtlAccPayBalanceOther = "TotalStckTtlAccPayBalanceOther";

        /// <summary> ����(�v�ŗ�1) </summary>
        public const string ct_Col_TotalStockSlipCountTaxRate1 = "TotalStockSlipCountTaxRate1";

        /// <summary> ����(�v�ŗ�2) </summary>
        public const string ct_Col_TotalStockSlipCountTaxRate2 = "TotalStockSlipCountTaxRate2";

        /// <summary> ����(�v���̑�) </summary>
        public const string ct_Col_TotalStockSlipCountOther = "TotalStockSlipCountOther";

        /// <summary> �ŗ�1�^�C�g�� </summary>
        public const string ct_Col_TitleTaxRate1 = "TitleTaxRate1";

        /// <summary> �ŗ�2�^�C�g�� </summary>
        public const string ct_Col_TitleTaxRate2 = "TitleTaxRate2";
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

        // --- ADD START 3H ���� 2022/10/20 ----->>>>>
        /// <summary> �d���z(�v��ې�) </summary>
        public const string Col_TotalThisTimeStockPriceTaxFree = "TotalThisTimeStockPriceTaxFree";
        /// <summary> �ԕi�l��(�v��ې�) </summary>
        public const string Col_TotalThisRgdsDisPricTaxFree = "TotalThisRgdsDisPricTaxFree";
        /// <summary> ���d���z(�v��ې�) </summary>
        public const string Col_TotalPureStockTaxFree = "TotalPureStockTaxFree";
        /// <summary> �����(�v��ې�) </summary>
        public const string Col_TotalStockPricTaxTaxFree = "TotalStockPricTaxTaxFree";
        /// <summary> �������v(�v��ې�) </summary>
        public const string Col_TotalStckTtlAccPayBalanceTaxFree = "TotalStckTtlAccPayBalanceTaxFree";
        /// <summary> ����(�v��ې�) </summary>
        public const string Col_TotalStockSlipCountTaxFree = "TotalStockSlipCountTaxFree";
        // --- ADD END 3H ���� 2022/10/20 -----<<<<<
        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
        /// ���|�c���ꗗ�\(����) �d���攃�|���z�f�[�^�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���|�c���ꗗ�\(����) �d���攃�|���z�f�[�^�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		public PMKAK02025EA()
		{
		}
		#endregion

		#region �� Static Public Method
		#region �� CreateDataTable
		/// <summary>
        /// �d���攃�|���zDataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
        /// <br>Note       : �d���攃�|���z�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>s
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
		/// </remarks>
        static public void CreateDataTable(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_AccPaymentList))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_AccPaymentList].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_AccPaymentList);

                DataTable dt = ds.Tables[ct_Tbl_AccPaymentList];

                // �����v�㋒�_�R�[�h
                dt.Columns.Add(ct_Col_SumAddUpSecCode, typeof(string));
                dt.Columns[ct_Col_SumAddUpSecCode].DefaultValue = string.Empty;

                // �����v�㋒�_����
                dt.Columns.Add(ct_Col_SumSectionGuideNm, typeof(string));
                dt.Columns[ct_Col_SumSectionGuideNm].DefaultValue = string.Empty;

                // �v�㋒�_�R�[�h
                dt.Columns.Add( ct_Col_AddUpSecCode, typeof( string ) );
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // �v�㋒�_����
                dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = string.Empty;

                // �����x����R�[�h
                dt.Columns.Add(ct_Col_SumPayeeCode, typeof(Int32));
                dt.Columns[ct_Col_SumPayeeCode].DefaultValue = 0;

                // �����x���旪��
                dt.Columns.Add(ct_Col_SumPayeeSnm, typeof(string));
                dt.Columns[ct_Col_SumPayeeSnm].DefaultValue = string.Empty;

                // �x����R�[�h
                dt.Columns.Add( ct_Col_PayeeCode, typeof( Int32 ) );
                dt.Columns[ct_Col_PayeeCode].DefaultValue = 0;

                // �x���旪��
                dt.Columns.Add( ct_Col_PayeeSnm, typeof( string ) );
                dt.Columns[ct_Col_PayeeSnm].DefaultValue = string.Empty;

                // �O�񔃊|���z
                dt.Columns.Add( ct_Col_LastTimeAccPay, typeof( Int64 ) );
                dt.Columns[ct_Col_LastTimeAccPay].DefaultValue = 0;

                // ����x�����z�i�ʏ�x���j
                dt.Columns.Add( ct_Col_ThisTimePayNrml, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimePayNrml].DefaultValue = 0;

                // ����萔���z�i�ʏ�x���j
                dt.Columns.Add( ct_Col_ThisTimeFeePayNrml, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimeFeePayNrml].DefaultValue = 0;

                // ����l���z�i�ʏ�x���j
                dt.Columns.Add( ct_Col_ThisTimeDisPayNrml, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimeDisPayNrml].DefaultValue = 0;

                // ����J�z�c���i���|�v�j
                dt.Columns.Add( ct_Col_ThisTimeTtlBlcAcPay, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimeTtlBlcAcPay].DefaultValue = 0;

                // ���E�㍡��d�����z
                dt.Columns.Add( ct_Col_OfsThisTimeStock, typeof( Int64 ) );
                dt.Columns[ct_Col_OfsThisTimeStock].DefaultValue = 0;

                // �ԕi�l��
                dt.Columns.Add(ct_Col_ThisRgdsDisPric, typeof(Int64));
                dt.Columns[ct_Col_ThisRgdsDisPric].DefaultValue = 0;

                // ���E�㍡��d�������
                dt.Columns.Add( ct_Col_OfsThisStockTax, typeof( Int64 ) );
                dt.Columns[ct_Col_OfsThisStockTax].DefaultValue = 0;

                // ����d�����z
                dt.Columns.Add(ct_Col_ThisTimeStockPrice, typeof(Int64));
                dt.Columns[ct_Col_ThisTimeStockPrice].DefaultValue = 0;
                
                // �d�����v�c���i���|�v�j
                dt.Columns.Add( ct_Col_StckTtlAccPayBalance, typeof( Int64 ) );
                dt.Columns[ct_Col_StckTtlAccPayBalance].DefaultValue = 0;

                // �d���`�[����
                dt.Columns.Add( ct_Col_StockSlipCount, typeof( Int32 ) );
                dt.Columns[ct_Col_StockSlipCount].DefaultValue = 0;

                // ����
                dt.Columns.Add(ct_Col_CashPayment, typeof(Int64));
                dt.Columns[ct_Col_CashPayment].DefaultValue = 0;

                // �U��
                dt.Columns.Add(ct_Col_TrfrPayment, typeof(Int64));
                dt.Columns[ct_Col_TrfrPayment].DefaultValue = 0;

                // ���؎�
                dt.Columns.Add(ct_Col_CheckPayment, typeof(Int64));
                dt.Columns[ct_Col_CheckPayment].DefaultValue = 0;

                // ��`
                dt.Columns.Add(ct_Col_DraftPayment, typeof(Int64));
                dt.Columns[ct_Col_DraftPayment].DefaultValue = 0;

                // ���E
                dt.Columns.Add(ct_Col_OffsetPayment, typeof(Int64));
                dt.Columns[ct_Col_OffsetPayment].DefaultValue = 0;

                // �����U��
                dt.Columns.Add(ct_Col_FundTransferPayment, typeof(Int64));
                dt.Columns[ct_Col_FundTransferPayment].DefaultValue = 0;

                // ���̑�
                dt.Columns.Add(ct_Col_OthsPayment, typeof(Int64));
                dt.Columns[ct_Col_OthsPayment].DefaultValue = 0;

                // ����ԕi�l�����z�i����p�j
                dt.Columns.Add( ct_Col_ThisStockPricRgdsDis, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisStockPricRgdsDis].DefaultValue = 0;

                // ���񍇌v���z�i����p�j
                dt.Columns.Add( ct_Col_StockPricTax, typeof( Int64 ) );
                dt.Columns[ct_Col_StockPricTax].DefaultValue = 0;

                // ����p
                // ���d���z
                dt.Columns.Add(ct_Col_PureStock, typeof(Int64));
                dt.Columns[ct_Col_PureStock].DefaultValue = 0;

                // ���������X�V
                dt.Columns.Add(Col_MonAddUpNonProc, typeof(bool));
                dt.Columns[Col_MonAddUpNonProc].DefaultValue = false;

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                // �d���z(�v�ŗ�1)
                dt.Columns.Add(ct_Col_TotalThisTimeStockPriceTaxRate1, typeof(Int64));
                dt.Columns[ct_Col_TotalThisTimeStockPriceTaxRate1].DefaultValue = 0;

                // �d���z(�v�ŗ�2)
                dt.Columns.Add(ct_Col_TotalThisTimeStockPriceTaxRate2, typeof(Int64));
                dt.Columns[ct_Col_TotalThisTimeStockPriceTaxRate2].DefaultValue = 0;

                // �d���z(�v���̑�)
                dt.Columns.Add(ct_Col_TotalThisTimeStockPriceOther, typeof(Int64));
                dt.Columns[ct_Col_TotalThisTimeStockPriceOther].DefaultValue = 0;

                // �ԕi�l��(�v�ŗ�1)
                dt.Columns.Add(ct_Col_TotalThisRgdsDisPricTaxRate1, typeof(Int64));
                dt.Columns[ct_Col_TotalThisRgdsDisPricTaxRate1].DefaultValue = 0;

                // �ԕi�l��(�v�ŗ�2)
                dt.Columns.Add(ct_Col_TotalThisRgdsDisPricTaxRate2, typeof(Int64));
                dt.Columns[ct_Col_TotalThisRgdsDisPricTaxRate2].DefaultValue = 0;

                // �ԕi�l��(�v���̑�)
                dt.Columns.Add(ct_Col_TotalThisRgdsDisPricOther, typeof(Int64));
                dt.Columns[ct_Col_TotalThisRgdsDisPricOther].DefaultValue = 0;

                // ���d���z(�v�ŗ�1)
                dt.Columns.Add(ct_Col_TotalPureStockTaxRate1, typeof(Int64));
                dt.Columns[ct_Col_TotalPureStockTaxRate1].DefaultValue = 0;

                // ���d���z(�v�ŗ�2)
                dt.Columns.Add(ct_Col_TotalPureStockTaxRate2, typeof(Int64));
                dt.Columns[ct_Col_TotalPureStockTaxRate2].DefaultValue = 0;

                // ���d���z(�v���̑�)
                dt.Columns.Add(ct_Col_TotalPureStockOther, typeof(Int64));
                dt.Columns[ct_Col_TotalPureStockOther].DefaultValue = 0;

                // �����(�v�ŗ�1)
                dt.Columns.Add(ct_Col_TotalStockPricTaxTaxRate1, typeof(Int64));
                dt.Columns[ct_Col_TotalStockPricTaxTaxRate1].DefaultValue = 0;

                // �����(�v�ŗ�2)
                dt.Columns.Add(ct_Col_TotalStockPricTaxTaxRate2, typeof(Int64));
                dt.Columns[ct_Col_TotalStockPricTaxTaxRate2].DefaultValue = 0;

                // �����(�v���̑�)
                dt.Columns.Add(ct_Col_TotalStockPricTaxOther, typeof(Int64));
                dt.Columns[ct_Col_TotalStockPricTaxOther].DefaultValue = 0;

                // �������v(�v�ŗ�1)
                dt.Columns.Add(ct_Col_TotalStckTtlAccPayBalanceTaxRate1, typeof(Int64));
                dt.Columns[ct_Col_TotalStckTtlAccPayBalanceTaxRate1].DefaultValue = 0;

                // �������v(�v�ŗ�2)
                dt.Columns.Add(ct_Col_TotalStckTtlAccPayBalanceTaxRate2, typeof(Int64));
                dt.Columns[ct_Col_TotalStckTtlAccPayBalanceTaxRate2].DefaultValue = 0;

                // �������v(�v���̑�)
                dt.Columns.Add(ct_Col_TotalStckTtlAccPayBalanceOther, typeof(Int64));
                dt.Columns[ct_Col_TotalStckTtlAccPayBalanceOther].DefaultValue = 0;

                // ����(�v�ŗ�1)
                dt.Columns.Add(ct_Col_TotalStockSlipCountTaxRate1, typeof(Int32));
                dt.Columns[ct_Col_TotalStockSlipCountTaxRate1].DefaultValue = 0;

                // ����(�v�ŗ�2)
                dt.Columns.Add(ct_Col_TotalStockSlipCountTaxRate2, typeof(Int32));
                dt.Columns[ct_Col_TotalStockSlipCountTaxRate2].DefaultValue = 0;

                // ����(�v���̑�)
                dt.Columns.Add(ct_Col_TotalStockSlipCountOther, typeof(Int32));
                dt.Columns[ct_Col_TotalStockSlipCountOther].DefaultValue = 0;

                // �ŗ�1�^�C�g��
                dt.Columns.Add(ct_Col_TitleTaxRate1, typeof(string));
                dt.Columns[ct_Col_TitleTaxRate1].DefaultValue = string.Empty;

                // �ŗ�2�^�C�g��
                dt.Columns.Add(ct_Col_TitleTaxRate2, typeof(string));
                dt.Columns[ct_Col_TitleTaxRate2].DefaultValue = string.Empty;
                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
                // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                // �d���z(�v��ې�)
                dt.Columns.Add(Col_TotalThisTimeStockPriceTaxFree, typeof(Int64));
                dt.Columns[Col_TotalThisTimeStockPriceTaxFree].DefaultValue = 0;

                // �ԕi�l��(�v��ې�)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxFree, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxFree].DefaultValue = 0;

                // ���d���z(�v��ې�)
                dt.Columns.Add(Col_TotalPureStockTaxFree, typeof(Int64));
                dt.Columns[Col_TotalPureStockTaxFree].DefaultValue = 0;

                // �����(�v��ې�)
                dt.Columns.Add(Col_TotalStockPricTaxTaxFree, typeof(Int64));
                dt.Columns[Col_TotalStockPricTaxTaxFree].DefaultValue = 0;

                // �������v(�v��ې�)
                dt.Columns.Add(Col_TotalStckTtlAccPayBalanceTaxFree, typeof(Int64));
                dt.Columns[Col_TotalStckTtlAccPayBalanceTaxFree].DefaultValue = 0;

                // ����(�v��ې�)
                dt.Columns.Add(Col_TotalStockSlipCountTaxFree, typeof(Int32));
                dt.Columns[Col_TotalStockSlipCountTaxFree].DefaultValue = 0;
                // --- ADD END 3H ���� 2022/10/20 -----<<<<<
            }
		}
		#endregion
		#endregion
	}
}

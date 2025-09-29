using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RsltInfo_AccRecBalanceWork
	/// <summary>
	///                      ���|�c���������o���ʃ��[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���|�c���������o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RsltInfo_AccRecBalanceWork
	{
		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>�v�㋒�_����</summary>
		/// <remarks>�����[�g���ŎZ�o</remarks>
		private string _addUpSecName = "";

		/// <summary>������R�[�h</summary>
		/// <remarks>������e�R�[�h</remarks>
		private Int32 _claimCode;

		/// <summary>�����於��</summary>
		private string _claimName = "";

		/// <summary>�����於��2</summary>
		private string _claimName2 = "";

		/// <summary>�����旪��</summary>
		private string _claimSnm = "";

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
		private DateTime _addUpDate;

		/// <summary>�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�O�񔄊|���z</summary>
		private Int64 _lastTimeAccRec;

		/// <summary>��2��O�c���i���|�v�j</summary>
		private Int64 _acpOdrTtl2TmBfAccRec;

		/// <summary>��3��O�c���i���|�v�j</summary>
		private Int64 _acpOdrTtl3TmBfAccRec;

		/// <summary>����������z�i�ʏ�����j</summary>
		private Int64 _thisTimeDmdNrml;

		/// <summary>����萔���z�i�ʏ�����j</summary>
		private Int64 _thisTimeFeeDmdNrml;

		/// <summary>����l���z�i�ʏ�����j</summary>
		private Int64 _thisTimeDisDmdNrml;

		/// <summary>����J�z�c���i���|�v�j</summary>
		/// <remarks>����J�z�c�����O�񔄊|���z�|��������z���v�i�ʏ�����j</remarks>
		private Int64 _thisTimeTtlBlcAcc;

		/// <summary>���E�㍡�񔄏���z</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisTimeSales;

		/// <summary>���E�㍡�񔄏�����</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisSalesTax;

		/// <summary>���񔄏���z</summary>
		/// <remarks>�����p�F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
		private Int64 _thisTimeSales;

		/// <summary>���񔄏�����</summary>
		/// <remarks>�����p</remarks>
		private Int64 _thisSalesTax;

		/// <summary>���񔄏�ԕi���z</summary>
		/// <remarks>�ԕi�p�F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
		private Int64 _thisSalesPricRgds;

		/// <summary>���񔄏�ԕi�����</summary>
		/// <remarks>�ԕi�p�F�ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
		private Int64 _thisSalesPrcTaxRgds;

		/// <summary>���񔄏�l�����z</summary>
		/// <remarks>�l���p�F�Ŕ����̔���l�����z</remarks>
		private Int64 _thisSalesPricDis;

		/// <summary>���񔄏�l�������</summary>
		/// <remarks>�l���p�F�l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
		private Int64 _thisSalesPrcTaxDis;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>�v�Z�㓖�����|���z</summary>
		/// <remarks>�������̔��|���z �J�z�z�{���񏃔�����z�{���񏃔������Ł{���񌻋�����z�{���񔄏�ԕi�z�{���񌻋��l�����z�{���񌻋��������Ŋz�{����Œ����z�{�c�������z</remarks>
		private Int64 _afCalTMonthAccRec;

		/// <summary>����`�[����</summary>
		private Int32 _salesSlipCount;

		/// <summary>�������</summary>
		/// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
		private Int32 _collectCond;

		/// <summary>��������</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>������敪����</summary>
		/// <remarks>�����A�����A���X��</remarks>
		private string _collectMoneyName = "";

		/// <summary>�����</summary>
		/// <remarks>DD</remarks>
		private Int32 _collectMoneyDay;

		/// <summary>�W���S���]�ƈ��R�[�h</summary>
		private string _billCollecterCd = "";

		/// <summary>�W���S���]�ƈ�����</summary>
		private string _billCollecterNm = "";


		/// public propaty name  :  AddUpSecCode
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>�v�㋒�_���̃v���p�e�B</summary>
		/// <value>�����[�g���ŎZ�o</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// <value>������e�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  ClaimName
		/// <summary>�����於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ClaimName
		{
			get{return _claimName;}
			set{_claimName = value;}
		}

		/// public propaty name  :  ClaimName2
		/// <summary>�����於��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����於��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ClaimName2
		{
			get{return _claimName2;}
			set{_claimName2 = value;}
		}

		/// public propaty name  :  ClaimSnm
		/// <summary>�����旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ClaimSnm
		{
			get{return _claimSnm;}
			set{_claimSnm = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>�v��N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  LastTimeAccRec
		/// <summary>�O�񔄊|���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񔄊|���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LastTimeAccRec
		{
			get{return _lastTimeAccRec;}
			set{_lastTimeAccRec = value;}
		}

		/// public propaty name  :  AcpOdrTtl2TmBfAccRec
		/// <summary>��2��O�c���i���|�v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��2��O�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 AcpOdrTtl2TmBfAccRec
		{
			get{return _acpOdrTtl2TmBfAccRec;}
			set{_acpOdrTtl2TmBfAccRec = value;}
		}

		/// public propaty name  :  AcpOdrTtl3TmBfAccRec
		/// <summary>��3��O�c���i���|�v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��3��O�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 AcpOdrTtl3TmBfAccRec
		{
			get{return _acpOdrTtl3TmBfAccRec;}
			set{_acpOdrTtl3TmBfAccRec = value;}
		}

		/// public propaty name  :  ThisTimeDmdNrml
		/// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeDmdNrml
		{
			get{return _thisTimeDmdNrml;}
			set{_thisTimeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeFeeDmdNrml
		/// <summary>����萔���z�i�ʏ�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����萔���z�i�ʏ�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeFeeDmdNrml
		{
			get{return _thisTimeFeeDmdNrml;}
			set{_thisTimeFeeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDisDmdNrml
		/// <summary>����l���z�i�ʏ�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l���z�i�ʏ�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeDisDmdNrml
		{
			get{return _thisTimeDisDmdNrml;}
			set{_thisTimeDisDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcAcc
		/// <summary>����J�z�c���i���|�v�j�v���p�e�B</summary>
		/// <value>����J�z�c�����O�񔄊|���z�|��������z���v�i�ʏ�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����J�z�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcAcc
		{
			get{return _thisTimeTtlBlcAcc;}
			set{_thisTimeTtlBlcAcc = value;}
		}

		/// public propaty name  :  OfsThisTimeSales
		/// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
		/// <value>���E����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisTimeSales
		{
			get{return _ofsThisTimeSales;}
			set{_ofsThisTimeSales = value;}
		}

		/// public propaty name  :  OfsThisSalesTax
		/// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
		/// <value>���E����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisSalesTax
		{
			get{return _ofsThisSalesTax;}
			set{_ofsThisSalesTax = value;}
		}

		/// public propaty name  :  ThisTimeSales
		/// <summary>���񔄏���z�v���p�e�B</summary>
		/// <value>�����p�F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeSales
		{
			get{return _thisTimeSales;}
			set{_thisTimeSales = value;}
		}

		/// public propaty name  :  ThisSalesTax
		/// <summary>���񔄏����Ńv���p�e�B</summary>
		/// <value>�����p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesTax
		{
			get{return _thisSalesTax;}
			set{_thisSalesTax = value;}
		}

		/// public propaty name  :  ThisSalesPricRgds
		/// <summary>���񔄏�ԕi���z�v���p�e�B</summary>
		/// <value>�ԕi�p�F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�ԕi���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPricRgds
		{
			get{return _thisSalesPricRgds;}
			set{_thisSalesPricRgds = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxRgds
		/// <summary>���񔄏�ԕi����Ńv���p�e�B</summary>
		/// <value>�ԕi�p�F�ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�ԕi����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxRgds
		{
			get{return _thisSalesPrcTaxRgds;}
			set{_thisSalesPrcTaxRgds = value;}
		}

		/// public propaty name  :  ThisSalesPricDis
		/// <summary>���񔄏�l�����z�v���p�e�B</summary>
		/// <value>�l���p�F�Ŕ����̔���l�����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�l�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPricDis
		{
			get{return _thisSalesPricDis;}
			set{_thisSalesPricDis = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxDis
		/// <summary>���񔄏�l������Ńv���p�e�B</summary>
		/// <value>�l���p�F�l���O�Ŋz���v�{�l�����Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�l������Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxDis
		{
			get{return _thisSalesPrcTaxDis;}
			set{_thisSalesPrcTaxDis = value;}
		}

		/// public propaty name  :  TaxAdjust
		/// <summary>����Œ����z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����Œ����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TaxAdjust
		{
			get{return _taxAdjust;}
			set{_taxAdjust = value;}
		}

		/// public propaty name  :  BalanceAdjust
		/// <summary>�c�������z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c�������z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 BalanceAdjust
		{
			get{return _balanceAdjust;}
			set{_balanceAdjust = value;}
		}

		/// public propaty name  :  AfCalTMonthAccRec
		/// <summary>�v�Z�㓖�����|���z�v���p�e�B</summary>
		/// <value>�������̔��|���z �J�z�z�{���񏃔�����z�{���񏃔������Ł{���񌻋�����z�{���񔄏�ԕi�z�{���񌻋��l�����z�{���񌻋��������Ŋz�{����Œ����z�{�c�������z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�Z�㓖�����|���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 AfCalTMonthAccRec
		{
			get{return _afCalTMonthAccRec;}
			set{_afCalTMonthAccRec = value;}
		}

		/// public propaty name  :  SalesSlipCount
		/// <summary>����`�[�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCount
		{
			get{return _salesSlipCount;}
			set{_salesSlipCount = value;}
		}

		/// public propaty name  :  CollectCond
		/// <summary>��������v���p�e�B</summary>
		/// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectCond
		{
			get{return _collectCond;}
			set{_collectCond = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>���������v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  CollectMoneyName
		/// <summary>������敪���̃v���p�e�B</summary>
		/// <value>�����A�����A���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CollectMoneyName
		{
			get{return _collectMoneyName;}
			set{_collectMoneyName = value;}
		}

		/// public propaty name  :  CollectMoneyDay
		/// <summary>������v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectMoneyDay
		{
			get{return _collectMoneyDay;}
			set{_collectMoneyDay = value;}
		}

		/// public propaty name  :  BillCollecterCd
		/// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterCd
		{
			get{return _billCollecterCd;}
			set{_billCollecterCd = value;}
		}

		/// public propaty name  :  BillCollecterNm
		/// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterNm
		{
			get{return _billCollecterNm;}
			set{_billCollecterNm = value;}
		}


		/// <summary>
		/// ���|�c���������o���ʃ��[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>RsltInfo_AccRecBalanceWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RsltInfo_AccRecBalanceWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_AccRecBalanceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_AccRecBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_AccRecBalanceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_AccRecBalanceWork || graph is ArrayList || graph is RsltInfo_AccRecBalanceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_AccRecBalanceWork).FullName));

            if (graph != null && graph is RsltInfo_AccRecBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecBalanceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_AccRecBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_AccRecBalanceWork[])graph).Length;
            }
            else if (graph is RsltInfo_AccRecBalanceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�v�㋒�_����
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecName
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����於��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�O�񔄊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccRec
            //��2��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfAccRec
            //��3��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfAccRec
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //����萔���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //����l���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //����J�z�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcc
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //���񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //���񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //���񔄏�ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //���񔄏�ԕi�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxRgds
            //���񔄏�l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //���񔄏�l�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxDis
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�v�Z�㓖�����|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalTMonthAccRec
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //�������
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //��������
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //������敪����
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //�����
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //�W���S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_AccRecBalanceWork)
            {
                RsltInfo_AccRecBalanceWork temp = (RsltInfo_AccRecBalanceWork)graph;

                SetRsltInfo_AccRecBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_AccRecBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_AccRecBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_AccRecBalanceWork temp in lst)
                {
                    SetRsltInfo_AccRecBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_AccRecBalanceWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 33;

        /// <summary>
        ///  RsltInfo_AccRecBalanceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecBalanceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_AccRecBalanceWork(System.IO.BinaryWriter writer, RsltInfo_AccRecBalanceWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�v�㋒�_����
            writer.Write(temp.AddUpSecName);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����於��
            writer.Write(temp.ClaimName);
            //�����於��2
            writer.Write(temp.ClaimName2);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�O�񔄊|���z
            writer.Write(temp.LastTimeAccRec);
            //��2��O�c���i���|�v�j
            writer.Write(temp.AcpOdrTtl2TmBfAccRec);
            //��3��O�c���i���|�v�j
            writer.Write(temp.AcpOdrTtl3TmBfAccRec);
            //����������z�i�ʏ�����j
            writer.Write(temp.ThisTimeDmdNrml);
            //����萔���z�i�ʏ�����j
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //����l���z�i�ʏ�����j
            writer.Write(temp.ThisTimeDisDmdNrml);
            //����J�z�c���i���|�v�j
            writer.Write(temp.ThisTimeTtlBlcAcc);
            //���E�㍡�񔄏���z
            writer.Write(temp.OfsThisTimeSales);
            //���E�㍡�񔄏�����
            writer.Write(temp.OfsThisSalesTax);
            //���񔄏���z
            writer.Write(temp.ThisTimeSales);
            //���񔄏�����
            writer.Write(temp.ThisSalesTax);
            //���񔄏�ԕi���z
            writer.Write(temp.ThisSalesPricRgds);
            //���񔄏�ԕi�����
            writer.Write(temp.ThisSalesPrcTaxRgds);
            //���񔄏�l�����z
            writer.Write(temp.ThisSalesPricDis);
            //���񔄏�l�������
            writer.Write(temp.ThisSalesPrcTaxDis);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�v�Z�㓖�����|���z
            writer.Write(temp.AfCalTMonthAccRec);
            //����`�[����
            writer.Write(temp.SalesSlipCount);
            //�������
            writer.Write(temp.CollectCond);
            //��������
            writer.Write(temp.TotalDay);
            //������敪����
            writer.Write(temp.CollectMoneyName);
            //�����
            writer.Write(temp.CollectMoneyDay);
            //�W���S���]�ƈ��R�[�h
            writer.Write(temp.BillCollecterCd);
            //�W���S���]�ƈ�����
            writer.Write(temp.BillCollecterNm);

        }

        /// <summary>
        ///  RsltInfo_AccRecBalanceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_AccRecBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecBalanceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_AccRecBalanceWork GetRsltInfo_AccRecBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_AccRecBalanceWork temp = new RsltInfo_AccRecBalanceWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�v�㋒�_����
            temp.AddUpSecName = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����於��
            temp.ClaimName = reader.ReadString();
            //�����於��2
            temp.ClaimName2 = reader.ReadString();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�O�񔄊|���z
            temp.LastTimeAccRec = reader.ReadInt64();
            //��2��O�c���i���|�v�j
            temp.AcpOdrTtl2TmBfAccRec = reader.ReadInt64();
            //��3��O�c���i���|�v�j
            temp.AcpOdrTtl3TmBfAccRec = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //����萔���z�i�ʏ�����j
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //����l���z�i�ʏ�����j
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //����J�z�c���i���|�v�j
            temp.ThisTimeTtlBlcAcc = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //���񔄏���z
            temp.ThisTimeSales = reader.ReadInt64();
            //���񔄏�����
            temp.ThisSalesTax = reader.ReadInt64();
            //���񔄏�ԕi���z
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //���񔄏�ԕi�����
            temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
            //���񔄏�l�����z
            temp.ThisSalesPricDis = reader.ReadInt64();
            //���񔄏�l�������
            temp.ThisSalesPrcTaxDis = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�v�Z�㓖�����|���z
            temp.AfCalTMonthAccRec = reader.ReadInt64();
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //�������
            temp.CollectCond = reader.ReadInt32();
            //��������
            temp.TotalDay = reader.ReadInt32();
            //������敪����
            temp.CollectMoneyName = reader.ReadString();
            //�����
            temp.CollectMoneyDay = reader.ReadInt32();
            //�W���S���]�ƈ��R�[�h
            temp.BillCollecterCd = reader.ReadString();
            //�W���S���]�ƈ�����
            temp.BillCollecterNm = reader.ReadString();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>RsltInfo_AccRecBalanceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecBalanceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_AccRecBalanceWork temp = GetRsltInfo_AccRecBalanceWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (RsltInfo_AccRecBalanceWork[])lst.ToArray(typeof(RsltInfo_AccRecBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuplierPayInfGet
	/// <summary>
	///                      �d���挳���i�x�������j���o���ʃ��[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���挳���i�x�������j���o���ʃ��[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/01/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SuplierPayInfGet
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>�x����R�[�h</summary>
		/// <remarks>�x����̐e�R�[�h</remarks>
		private Int32 _payeeCode;

		/// <summary>�x���於��</summary>
		private string _payeeName = "";

		/// <summary>�x���於��2</summary>
		private string _payeeName2 = "";

		/// <summary>�x���旪��</summary>
		private string _payeeSnm = "";

		/// <summary>���ы��_�R�[�h</summary>
		/// <remarks>���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _resultsSectCd = "";

		/// <summary>�d����R�[�h</summary>
		/// <remarks>�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j</remarks>
		private Int32 _supplierCd;

		/// <summary>�d���於1</summary>
		private string _supplierNm1 = "";

		/// <summary>�d���於2</summary>
		private string _supplierNm2 = "";

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD �x�������s�Ȃ������i������j</remarks>
		private DateTime _addUpDate;

		/// <summary>�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�O��x�����z</summary>
		private Int64 _lastTimePayment;

		/// <summary>�d��2��O�c���i�x���v�j</summary>
		private Int64 _stockTtl2TmBfBlPay;

		/// <summary>�d��3��O�c���i�x���v�j</summary>
		private Int64 _stockTtl3TmBfBlPay;

		/// <summary>����x�����z�i�ʏ�x���j</summary>
		/// <remarks>�x���z�̍��v���z</remarks>
		private Int64 _thisTimePayNrml;

		/// <summary>����J�z�c���i�x���v�j</summary>
		/// <remarks>����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j</remarks>
		private Int64 _thisTimeTtlBlcPay;

		/// <summary>���E�㍡��d�����z</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisTimeStock;

		/// <summary>���E�㍡��d�������</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisStockTax;

		/// <summary>����ԕi���z</summary>
		/// <remarks>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</remarks>
		private Int64 _thisStckPricRgds;

		/// <summary>����ԕi�����</summary>
		/// <remarks>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
		private Int64 _thisStcPrcTaxRgds;

		/// <summary>����l�����z</summary>
		/// <remarks>�|�d���F�Ŕ����̎d���l�������z</remarks>
		private Int64 _thisStckPricDis;

		/// <summary>����l�������</summary>
		/// <remarks>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
		private Int64 _thisStcPrcTaxDis;

        /// <summary>����ԕi�E�l�����z</summary>
        /// <remarks>����p�@�ԕi�{�l��</remarks>
        private Int64 _thisStckPricRgdsDis;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>�d�����v�c���i�x���v�j</summary>
		/// <remarks>���񕪂̎x�����z ����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z</remarks>
		private Int64 _stockTotalPayBalance;

		/// <summary>�����X�V���s�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>�����X�V�J�n�N����</summary>
		/// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
		private DateTime _startCAddUpUpdDate;

		/// <summary>�O������X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>�d���`�[����</summary>
		private Int32 _stockSlipCount;

		/// <summary>���ς݃t���O</summary>
		/// <remarks>0:������,1:���ς�</remarks>
		private Int32 _closeFlg;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";


		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

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

		/// public propaty name  :  PayeeCode
		/// <summary>�x����R�[�h�v���p�e�B</summary>
		/// <value>�x����̐e�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  PayeeName
		/// <summary>�x���於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PayeeName
		{
			get{return _payeeName;}
			set{_payeeName = value;}
		}

		/// public propaty name  :  PayeeName2
		/// <summary>�x���於��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���於��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PayeeName2
		{
			get{return _payeeName2;}
			set{_payeeName2 = value;}
		}

		/// public propaty name  :  PayeeSnm
		/// <summary>�x���旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PayeeSnm
		{
			get{return _payeeSnm;}
			set{_payeeSnm = value;}
		}

		/// public propaty name  :  ResultsSectCd
		/// <summary>���ы��_�R�[�h�v���p�e�B</summary>
		/// <value>���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ы��_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ResultsSectCd
		{
			get{return _resultsSectCd;}
			set{_resultsSectCd = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// <value>�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierNm1
		/// <summary>�d���於1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���於1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
		}

		/// public propaty name  :  SupplierNm2
		/// <summary>�d���於2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���於2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm2
		{
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>�d���旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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

		/// public propaty name  :  AddUpDateJpFormal
		/// <summary>�v��N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateJpInFormal
		/// <summary>�v��N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateAdFormal
		/// <summary>�v��N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateAdInFormal
		/// <summary>�v��N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate);}
			set{}
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

		/// public propaty name  :  AddUpYearMonthJpFormal
		/// <summary>�v��N�� �a��v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpYearMonthJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthJpInFormal
		/// <summary>�v��N�� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpYearMonthJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthAdFormal
		/// <summary>�v��N�� ����v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpYearMonthAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthAdInFormal
		/// <summary>�v��N�� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpYearMonthAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  LastTimePayment
		/// <summary>�O��x�����z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O��x�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LastTimePayment
		{
			get{return _lastTimePayment;}
			set{_lastTimePayment = value;}
		}

		/// public propaty name  :  StockTtl2TmBfBlPay
		/// <summary>�d��2��O�c���i�x���v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d��2��O�c���i�x���v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtl2TmBfBlPay
		{
			get{return _stockTtl2TmBfBlPay;}
			set{_stockTtl2TmBfBlPay = value;}
		}

		/// public propaty name  :  StockTtl3TmBfBlPay
		/// <summary>�d��3��O�c���i�x���v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d��3��O�c���i�x���v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtl3TmBfBlPay
		{
			get{return _stockTtl3TmBfBlPay;}
			set{_stockTtl3TmBfBlPay = value;}
		}

		/// public propaty name  :  ThisTimePayNrml
		/// <summary>����x�����z�i�ʏ�x���j�v���p�e�B</summary>
		/// <value>�x���z�̍��v���z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����x�����z�i�ʏ�x���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimePayNrml
		{
			get{return _thisTimePayNrml;}
			set{_thisTimePayNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcPay
		/// <summary>����J�z�c���i�x���v�j�v���p�e�B</summary>
		/// <value>����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����J�z�c���i�x���v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcPay
		{
			get{return _thisTimeTtlBlcPay;}
			set{_thisTimeTtlBlcPay = value;}
		}

		/// public propaty name  :  OfsThisTimeStock
		/// <summary>���E�㍡��d�����z�v���p�e�B</summary>
		/// <value>���E����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisTimeStock
		{
			get{return _ofsThisTimeStock;}
			set{_ofsThisTimeStock = value;}
		}

		/// public propaty name  :  OfsThisStockTax
		/// <summary>���E�㍡��d������Ńv���p�e�B</summary>
		/// <value>���E����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisStockTax
		{
			get{return _ofsThisStockTax;}
			set{_ofsThisStockTax = value;}
		}

		/// public propaty name  :  ThisStckPricRgds
		/// <summary>����ԕi���z�v���p�e�B</summary>
		/// <value>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ԕi���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisStckPricRgds
		{
			get{return _thisStckPricRgds;}
			set{_thisStckPricRgds = value;}
		}

		/// public propaty name  :  ThisStcPrcTaxRgds
		/// <summary>����ԕi����Ńv���p�e�B</summary>
		/// <value>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ԕi����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisStcPrcTaxRgds
		{
			get{return _thisStcPrcTaxRgds;}
			set{_thisStcPrcTaxRgds = value;}
		}

		/// public propaty name  :  ThisStckPricDis
		/// <summary>����l�����z�v���p�e�B</summary>
		/// <value>�|�d���F�Ŕ����̎d���l�������z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisStckPricDis
		{
			get{return _thisStckPricDis;}
			set{_thisStckPricDis = value;}
		}

		/// public propaty name  :  ThisStcPrcTaxDis
		/// <summary>����l������Ńv���p�e�B</summary>
		/// <value>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l������Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisStcPrcTaxDis
		{
			get{return _thisStcPrcTaxDis;}
			set{_thisStcPrcTaxDis = value;}
		}

        /// public propaty name  :  ThisStckPricRgdsDis
        /// <summary>����ԕi�E�l�����z�v���p�e�B</summary>
        /// <value>����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi�E�l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricRgdsDis
        {
            get { return _thisStckPricRgdsDis; }
            set { _thisStckPricRgdsDis = value; }
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

		/// public propaty name  :  StockTotalPayBalance
		/// <summary>�d�����v�c���i�x���v�j�v���p�e�B</summary>
		/// <value>���񕪂̎x�����z ����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v�c���i�x���v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTotalPayBalance
		{
			get{return _stockTotalPayBalance;}
			set{_stockTotalPayBalance = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>�����X�V���s�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDateJpFormal
		/// <summary>�����X�V���s�N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CAddUpUpdExecDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  CAddUpUpdExecDateJpInFormal
		/// <summary>�����X�V���s�N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CAddUpUpdExecDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  CAddUpUpdExecDateAdFormal
		/// <summary>�����X�V���s�N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CAddUpUpdExecDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  CAddUpUpdExecDateAdInFormal
		/// <summary>�����X�V���s�N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CAddUpUpdExecDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDate
		/// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StartCAddUpUpdDate
		{
			get{return _startCAddUpUpdDate;}
			set{_startCAddUpUpdDate = value;}
		}

		/// public propaty name  :  StartCAddUpUpdDateJpFormal
		/// <summary>�����X�V�J�n�N���� �a��v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDateJpInFormal
		/// <summary>�����X�V�J�n�N���� �a��(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDateAdFormal
		/// <summary>�����X�V�J�n�N���� ����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDateAdInFormal
		/// <summary>�����X�V�J�n�N���� ����(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>�O������X�V�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get{return _lastCAddUpUpdDate;}
			set{_lastCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LastCAddUpUpdDateJpFormal
		/// <summary>�O������X�V�N���� �a��v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDateJpInFormal
		/// <summary>�O������X�V�N���� �a��(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDateAdFormal
		/// <summary>�O������X�V�N���� ����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDateAdInFormal
		/// <summary>�O������X�V�N���� ����(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StockSlipCount
		/// <summary>�d���`�[�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockSlipCount
		{
			get{return _stockSlipCount;}
			set{_stockSlipCount = value;}
		}

		/// public propaty name  :  CloseFlg
		/// <summary>���ς݃t���O�v���p�e�B</summary>
		/// <value>0:������,1:���ς�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ς݃t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CloseFlg
		{
			get{return _closeFlg;}
			set{_closeFlg = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>�v�㋒�_���̃v���p�e�B</summary>
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


		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SuplierPayInfGet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplierPayInfGet()
		{
		}

		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="payeeCode">�x����R�[�h(�x����̐e�R�[�h)</param>
		/// <param name="payeeName">�x���於��</param>
		/// <param name="payeeName2">�x���於��2</param>
		/// <param name="payeeSnm">�x���旪��</param>
		/// <param name="resultsSectCd">���ы��_�R�[�h(���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="supplierCd">�d����R�[�h(�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j)</param>
		/// <param name="supplierNm1">�d���於1</param>
		/// <param name="supplierNm2">�d���於2</param>
		/// <param name="supplierSnm">�d���旪��</param>
		/// <param name="addUpDate">�v��N����(YYYYMMDD �x�������s�Ȃ������i������j)</param>
		/// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
		/// <param name="lastTimePayment">�O��x�����z</param>
		/// <param name="stockTtl2TmBfBlPay">�d��2��O�c���i�x���v�j</param>
		/// <param name="stockTtl3TmBfBlPay">�d��3��O�c���i�x���v�j</param>
		/// <param name="thisTimePayNrml">����x�����z�i�ʏ�x���j(�x���z�̍��v���z)</param>
		/// <param name="thisTimeTtlBlcPay">����J�z�c���i�x���v�j(����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j)</param>
		/// <param name="ofsThisTimeStock">���E�㍡��d�����z(���E����)</param>
		/// <param name="ofsThisStockTax">���E�㍡��d�������(���E����)</param>
		/// <param name="thisStckPricRgds">����ԕi���z(�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z)</param>
		/// <param name="thisStcPrcTaxRgds">����ԕi�����(����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
		/// <param name="thisStckPricDis">����l�����z(�|�d���F�Ŕ����̎d���l�������z)</param>
		/// <param name="thisStcPrcTaxDis">����l�������(����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v)</param>
		/// <param name="taxAdjust">����Œ����z</param>
		/// <param name="balanceAdjust">�c�������z</param>
		/// <param name="stockTotalPayBalance">�d�����v�c���i�x���v�j(���񕪂̎x�����z ����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z)</param>
		/// <param name="cAddUpUpdExecDate">�����X�V���s�N����(YYYYMMDD)</param>
		/// <param name="startCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
		/// <param name="lastCAddUpUpdDate">�O������X�V�N����("YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����)</param>
		/// <param name="stockSlipCount">�d���`�[����</param>
		/// <param name="closeFlg">���ς݃t���O(0:������,1:���ς�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="addUpSecName">�v�㋒�_����</param>
		/// <returns>SuplierPayInfGet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SuplierPayInfGet(string enterpriseCode, string addUpSecCode, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, string resultsSectCd, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimePayment, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, Int64 thisTimePayNrml, Int64 thisTimeTtlBlcPay, Int64 ofsThisTimeStock, Int64 ofsThisStockTax, Int64 thisStckPricRgds, Int64 thisStcPrcTaxRgds, Int64 thisStckPricDis, Int64 thisStcPrcTaxDis, Int64 thisStckPricRgdsDis, Int64 taxAdjust, Int64 balanceAdjust, Int64 stockTotalPayBalance, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 stockSlipCount, Int32 closeFlg, string enterpriseName, string addUpSecName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCode = addUpSecCode;
			this._payeeCode = payeeCode;
			this._payeeName = payeeName;
			this._payeeName2 = payeeName2;
			this._payeeSnm = payeeSnm;
			this._resultsSectCd = resultsSectCd;
			this._supplierCd = supplierCd;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._supplierSnm = supplierSnm;
			this.AddUpDate = addUpDate;
			this.AddUpYearMonth = addUpYearMonth;
			this._lastTimePayment = lastTimePayment;
			this._stockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
			this._stockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
			this._thisTimePayNrml = thisTimePayNrml;
			this._thisTimeTtlBlcPay = thisTimeTtlBlcPay;
			this._ofsThisTimeStock = ofsThisTimeStock;
			this._ofsThisStockTax = ofsThisStockTax;
			this._thisStckPricRgds = thisStckPricRgds;
			this._thisStcPrcTaxRgds = thisStcPrcTaxRgds;
			this._thisStckPricDis = thisStckPricDis;
            this._thisStckPricRgdsDis = thisStckPricRgdsDis;
			this._thisStcPrcTaxDis = thisStcPrcTaxDis;
			this._taxAdjust = taxAdjust;
			this._balanceAdjust = balanceAdjust;
			this._stockTotalPayBalance = stockTotalPayBalance;
			this.CAddUpUpdExecDate = cAddUpUpdExecDate;
			this.StartCAddUpUpdDate = startCAddUpUpdDate;
			this.LastCAddUpUpdDate = lastCAddUpUpdDate;
			this._stockSlipCount = stockSlipCount;
			this._closeFlg = closeFlg;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N��������
		/// </summary>
		/// <returns>SuplierPayInfGet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuplierPayInfGet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplierPayInfGet Clone()
		{
            return new SuplierPayInfGet(this._enterpriseCode, this._addUpSecCode, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._resultsSectCd, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._addUpDate, this._addUpYearMonth, this._lastTimePayment, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, this._thisTimePayNrml, this._thisTimeTtlBlcPay, this._ofsThisTimeStock, this._ofsThisStockTax, this._thisStckPricRgds, this._thisStcPrcTaxRgds, this._thisStckPricDis, this._thisStckPricRgdsDis, this._thisStcPrcTaxDis, this._taxAdjust, this._balanceAdjust, this._stockTotalPayBalance, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._stockSlipCount, this._closeFlg, this._enterpriseName, this._addUpSecName);
		}

		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuplierPayInfGet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SuplierPayInfGet target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.PayeeName == target.PayeeName)
				 && (this.PayeeName2 == target.PayeeName2)
				 && (this.PayeeSnm == target.PayeeSnm)
				 && (this.ResultsSectCd == target.ResultsSectCd)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.AddUpDate == target.AddUpDate)
				 && (this.AddUpYearMonth == target.AddUpYearMonth)
				 && (this.LastTimePayment == target.LastTimePayment)
				 && (this.StockTtl2TmBfBlPay == target.StockTtl2TmBfBlPay)
				 && (this.StockTtl3TmBfBlPay == target.StockTtl3TmBfBlPay)
				 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
				 && (this.ThisTimeTtlBlcPay == target.ThisTimeTtlBlcPay)
				 && (this.OfsThisTimeStock == target.OfsThisTimeStock)
				 && (this.OfsThisStockTax == target.OfsThisStockTax)
				 && (this.ThisStckPricRgds == target.ThisStckPricRgds)
				 && (this.ThisStcPrcTaxRgds == target.ThisStcPrcTaxRgds)
				 && (this.ThisStckPricDis == target.ThisStckPricDis)
				 && (this.ThisStcPrcTaxDis == target.ThisStcPrcTaxDis)
				 && (this.TaxAdjust == target.TaxAdjust)
				 && (this.BalanceAdjust == target.BalanceAdjust)
				 && (this.StockTotalPayBalance == target.StockTotalPayBalance)
				 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
				 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
				 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
				 && (this.StockSlipCount == target.StockSlipCount)
				 && (this.CloseFlg == target.CloseFlg)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N��r����
		/// </summary>
		/// <param name="suplierPayInfGet1">
		///                    ��r����SuplierPayInfGet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="suplierPayInfGet2">��r����SuplierPayInfGet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SuplierPayInfGet suplierPayInfGet1, SuplierPayInfGet suplierPayInfGet2)
		{
			return ((suplierPayInfGet1.EnterpriseCode == suplierPayInfGet2.EnterpriseCode)
				 && (suplierPayInfGet1.AddUpSecCode == suplierPayInfGet2.AddUpSecCode)
				 && (suplierPayInfGet1.PayeeCode == suplierPayInfGet2.PayeeCode)
				 && (suplierPayInfGet1.PayeeName == suplierPayInfGet2.PayeeName)
				 && (suplierPayInfGet1.PayeeName2 == suplierPayInfGet2.PayeeName2)
				 && (suplierPayInfGet1.PayeeSnm == suplierPayInfGet2.PayeeSnm)
				 && (suplierPayInfGet1.ResultsSectCd == suplierPayInfGet2.ResultsSectCd)
				 && (suplierPayInfGet1.SupplierCd == suplierPayInfGet2.SupplierCd)
				 && (suplierPayInfGet1.SupplierNm1 == suplierPayInfGet2.SupplierNm1)
				 && (suplierPayInfGet1.SupplierNm2 == suplierPayInfGet2.SupplierNm2)
				 && (suplierPayInfGet1.SupplierSnm == suplierPayInfGet2.SupplierSnm)
				 && (suplierPayInfGet1.AddUpDate == suplierPayInfGet2.AddUpDate)
				 && (suplierPayInfGet1.AddUpYearMonth == suplierPayInfGet2.AddUpYearMonth)
				 && (suplierPayInfGet1.LastTimePayment == suplierPayInfGet2.LastTimePayment)
				 && (suplierPayInfGet1.StockTtl2TmBfBlPay == suplierPayInfGet2.StockTtl2TmBfBlPay)
				 && (suplierPayInfGet1.StockTtl3TmBfBlPay == suplierPayInfGet2.StockTtl3TmBfBlPay)
				 && (suplierPayInfGet1.ThisTimePayNrml == suplierPayInfGet2.ThisTimePayNrml)
				 && (suplierPayInfGet1.ThisTimeTtlBlcPay == suplierPayInfGet2.ThisTimeTtlBlcPay)
				 && (suplierPayInfGet1.OfsThisTimeStock == suplierPayInfGet2.OfsThisTimeStock)
				 && (suplierPayInfGet1.OfsThisStockTax == suplierPayInfGet2.OfsThisStockTax)
				 && (suplierPayInfGet1.ThisStckPricRgds == suplierPayInfGet2.ThisStckPricRgds)
				 && (suplierPayInfGet1.ThisStcPrcTaxRgds == suplierPayInfGet2.ThisStcPrcTaxRgds)
				 && (suplierPayInfGet1.ThisStckPricDis == suplierPayInfGet2.ThisStckPricDis)
				 && (suplierPayInfGet1.ThisStcPrcTaxDis == suplierPayInfGet2.ThisStcPrcTaxDis)
				 && (suplierPayInfGet1.TaxAdjust == suplierPayInfGet2.TaxAdjust)
				 && (suplierPayInfGet1.BalanceAdjust == suplierPayInfGet2.BalanceAdjust)
				 && (suplierPayInfGet1.StockTotalPayBalance == suplierPayInfGet2.StockTotalPayBalance)
				 && (suplierPayInfGet1.CAddUpUpdExecDate == suplierPayInfGet2.CAddUpUpdExecDate)
				 && (suplierPayInfGet1.StartCAddUpUpdDate == suplierPayInfGet2.StartCAddUpUpdDate)
				 && (suplierPayInfGet1.LastCAddUpUpdDate == suplierPayInfGet2.LastCAddUpUpdDate)
				 && (suplierPayInfGet1.StockSlipCount == suplierPayInfGet2.StockSlipCount)
				 && (suplierPayInfGet1.CloseFlg == suplierPayInfGet2.CloseFlg)
				 && (suplierPayInfGet1.EnterpriseName == suplierPayInfGet2.EnterpriseName)
				 && (suplierPayInfGet1.AddUpSecName == suplierPayInfGet2.AddUpSecName));
		}
		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuplierPayInfGet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SuplierPayInfGet target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.PayeeName != target.PayeeName)resList.Add("PayeeName");
			if(this.PayeeName2 != target.PayeeName2)resList.Add("PayeeName2");
			if(this.PayeeSnm != target.PayeeSnm)resList.Add("PayeeSnm");
			if(this.ResultsSectCd != target.ResultsSectCd)resList.Add("ResultsSectCd");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.AddUpYearMonth != target.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(this.LastTimePayment != target.LastTimePayment)resList.Add("LastTimePayment");
			if(this.StockTtl2TmBfBlPay != target.StockTtl2TmBfBlPay)resList.Add("StockTtl2TmBfBlPay");
			if(this.StockTtl3TmBfBlPay != target.StockTtl3TmBfBlPay)resList.Add("StockTtl3TmBfBlPay");
			if(this.ThisTimePayNrml != target.ThisTimePayNrml)resList.Add("ThisTimePayNrml");
			if(this.ThisTimeTtlBlcPay != target.ThisTimeTtlBlcPay)resList.Add("ThisTimeTtlBlcPay");
			if(this.OfsThisTimeStock != target.OfsThisTimeStock)resList.Add("OfsThisTimeStock");
			if(this.OfsThisStockTax != target.OfsThisStockTax)resList.Add("OfsThisStockTax");
			if(this.ThisStckPricRgds != target.ThisStckPricRgds)resList.Add("ThisStckPricRgds");
			if(this.ThisStcPrcTaxRgds != target.ThisStcPrcTaxRgds)resList.Add("ThisStcPrcTaxRgds");
			if(this.ThisStckPricDis != target.ThisStckPricDis)resList.Add("ThisStckPricDis");
			if(this.ThisStcPrcTaxDis != target.ThisStcPrcTaxDis)resList.Add("ThisStcPrcTaxDis");
			if(this.TaxAdjust != target.TaxAdjust)resList.Add("TaxAdjust");
			if(this.BalanceAdjust != target.BalanceAdjust)resList.Add("BalanceAdjust");
			if(this.StockTotalPayBalance != target.StockTotalPayBalance)resList.Add("StockTotalPayBalance");
			if(this.CAddUpUpdExecDate != target.CAddUpUpdExecDate)resList.Add("CAddUpUpdExecDate");
			if(this.StartCAddUpUpdDate != target.StartCAddUpUpdDate)resList.Add("StartCAddUpUpdDate");
			if(this.LastCAddUpUpdDate != target.LastCAddUpUpdDate)resList.Add("LastCAddUpUpdDate");
			if(this.StockSlipCount != target.StockSlipCount)resList.Add("StockSlipCount");
			if(this.CloseFlg != target.CloseFlg)resList.Add("CloseFlg");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// �d���挳���i�x�������j���o���ʃ��[�N��r����
		/// </summary>
		/// <param name="suplierPayInfGet1">��r����SuplierPayInfGet�N���X�̃C���X�^���X</param>
		/// <param name="suplierPayInfGet2">��r����SuplierPayInfGet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SuplierPayInfGet suplierPayInfGet1, SuplierPayInfGet suplierPayInfGet2)
		{
			ArrayList resList = new ArrayList();
			if(suplierPayInfGet1.EnterpriseCode != suplierPayInfGet2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suplierPayInfGet1.AddUpSecCode != suplierPayInfGet2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(suplierPayInfGet1.PayeeCode != suplierPayInfGet2.PayeeCode)resList.Add("PayeeCode");
			if(suplierPayInfGet1.PayeeName != suplierPayInfGet2.PayeeName)resList.Add("PayeeName");
			if(suplierPayInfGet1.PayeeName2 != suplierPayInfGet2.PayeeName2)resList.Add("PayeeName2");
			if(suplierPayInfGet1.PayeeSnm != suplierPayInfGet2.PayeeSnm)resList.Add("PayeeSnm");
			if(suplierPayInfGet1.ResultsSectCd != suplierPayInfGet2.ResultsSectCd)resList.Add("ResultsSectCd");
			if(suplierPayInfGet1.SupplierCd != suplierPayInfGet2.SupplierCd)resList.Add("SupplierCd");
			if(suplierPayInfGet1.SupplierNm1 != suplierPayInfGet2.SupplierNm1)resList.Add("SupplierNm1");
			if(suplierPayInfGet1.SupplierNm2 != suplierPayInfGet2.SupplierNm2)resList.Add("SupplierNm2");
			if(suplierPayInfGet1.SupplierSnm != suplierPayInfGet2.SupplierSnm)resList.Add("SupplierSnm");
			if(suplierPayInfGet1.AddUpDate != suplierPayInfGet2.AddUpDate)resList.Add("AddUpDate");
			if(suplierPayInfGet1.AddUpYearMonth != suplierPayInfGet2.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(suplierPayInfGet1.LastTimePayment != suplierPayInfGet2.LastTimePayment)resList.Add("LastTimePayment");
			if(suplierPayInfGet1.StockTtl2TmBfBlPay != suplierPayInfGet2.StockTtl2TmBfBlPay)resList.Add("StockTtl2TmBfBlPay");
			if(suplierPayInfGet1.StockTtl3TmBfBlPay != suplierPayInfGet2.StockTtl3TmBfBlPay)resList.Add("StockTtl3TmBfBlPay");
			if(suplierPayInfGet1.ThisTimePayNrml != suplierPayInfGet2.ThisTimePayNrml)resList.Add("ThisTimePayNrml");
			if(suplierPayInfGet1.ThisTimeTtlBlcPay != suplierPayInfGet2.ThisTimeTtlBlcPay)resList.Add("ThisTimeTtlBlcPay");
			if(suplierPayInfGet1.OfsThisTimeStock != suplierPayInfGet2.OfsThisTimeStock)resList.Add("OfsThisTimeStock");
			if(suplierPayInfGet1.OfsThisStockTax != suplierPayInfGet2.OfsThisStockTax)resList.Add("OfsThisStockTax");
			if(suplierPayInfGet1.ThisStckPricRgds != suplierPayInfGet2.ThisStckPricRgds)resList.Add("ThisStckPricRgds");
			if(suplierPayInfGet1.ThisStcPrcTaxRgds != suplierPayInfGet2.ThisStcPrcTaxRgds)resList.Add("ThisStcPrcTaxRgds");
			if(suplierPayInfGet1.ThisStckPricDis != suplierPayInfGet2.ThisStckPricDis)resList.Add("ThisStckPricDis");
			if(suplierPayInfGet1.ThisStcPrcTaxDis != suplierPayInfGet2.ThisStcPrcTaxDis)resList.Add("ThisStcPrcTaxDis");
			if(suplierPayInfGet1.TaxAdjust != suplierPayInfGet2.TaxAdjust)resList.Add("TaxAdjust");
			if(suplierPayInfGet1.BalanceAdjust != suplierPayInfGet2.BalanceAdjust)resList.Add("BalanceAdjust");
			if(suplierPayInfGet1.StockTotalPayBalance != suplierPayInfGet2.StockTotalPayBalance)resList.Add("StockTotalPayBalance");
			if(suplierPayInfGet1.CAddUpUpdExecDate != suplierPayInfGet2.CAddUpUpdExecDate)resList.Add("CAddUpUpdExecDate");
			if(suplierPayInfGet1.StartCAddUpUpdDate != suplierPayInfGet2.StartCAddUpUpdDate)resList.Add("StartCAddUpUpdDate");
			if(suplierPayInfGet1.LastCAddUpUpdDate != suplierPayInfGet2.LastCAddUpUpdDate)resList.Add("LastCAddUpUpdDate");
			if(suplierPayInfGet1.StockSlipCount != suplierPayInfGet2.StockSlipCount)resList.Add("StockSlipCount");
			if(suplierPayInfGet1.CloseFlg != suplierPayInfGet2.CloseFlg)resList.Add("CloseFlg");
			if(suplierPayInfGet1.EnterpriseName != suplierPayInfGet2.EnterpriseName)resList.Add("EnterpriseName");
			if(suplierPayInfGet1.AddUpSecName != suplierPayInfGet2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}

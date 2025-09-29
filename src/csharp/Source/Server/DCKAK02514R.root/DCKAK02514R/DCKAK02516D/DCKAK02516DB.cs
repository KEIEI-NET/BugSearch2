using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RsltInfo_PaymentTotalWork
	/// <summary>
	///                      �x���ꗗ�\���o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �x���ꗗ�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RsltInfo_PaymentTotalWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";

		/// <summary>�x����R�[�h</summary>
		/// <remarks>�x����̐e�R�[�h</remarks>
		private Int32 _payeeCode;

		/// <summary>�x���於��</summary>
		private string _payeeName = "";

		/// <summary>�x���於��2</summary>
		private string _payeeName2 = "";

		/// <summary>�x���旪��</summary>
		private string _payeeSnm = "";

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

		/// <summary>����ԕi���z</summary>
		/// <remarks>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</remarks>
		private Int64 _thisStckPricRgds;

		/// <summary>����l�����z</summary>
		/// <remarks>�|�d���F�Ŕ����̎d���l�������z</remarks>
		private Int64 _thisStckPricDis;

		/// <summary>���E�㍡��d�������</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisStockTax;

		/// <summary>�d�����v�c���i�x���v�j</summary>
		/// <remarks>���񕪂̎x�����z ����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z</remarks>
		private Int64 _stockTotalPayBalance;

		/// <summary>�d���`�[����</summary>
		private Int32 _stockSlipCount;

		/// <summary>����萔���z�i�ʏ�x���j</summary>
		private Int64 _thisTimeFeePayNrml;

		/// <summary>����l���z�i�ʏ�x���j</summary>
		private Int64 _thisTimeDisPayNrml;

		/// <summary>�x�����敪����</summary>
		/// <remarks>�����A�����A���X��</remarks>
		private string _paymentMonthName = "";

		/// <summary>�x����</summary>
		/// <remarks>DD</remarks>
		private Int32 _paymentDay;

		/// <summary>����R�[�h���X�g</summary>
		/// <remarks>RsltInfo_AccPayTotalWork�N���X�Ŋi�[</remarks>
		private ArrayList _moneyKindList;

        /// <summary>���ы��_�R�[�h</summary>
        private string _resultsSectCd = "";

        /// <summary>����d�����z</summary>
        private Int64 _thisTimeStockPrice;


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

		/// public propaty name  :  ThisTimeFeePayNrml
		/// <summary>����萔���z�i�ʏ�x���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����萔���z�i�ʏ�x���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeFeePayNrml
		{
			get{return _thisTimeFeePayNrml;}
			set{_thisTimeFeePayNrml = value;}
		}

		/// public propaty name  :  ThisTimeDisPayNrml
		/// <summary>����l���z�i�ʏ�x���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l���z�i�ʏ�x���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeDisPayNrml
		{
			get{return _thisTimeDisPayNrml;}
			set{_thisTimeDisPayNrml = value;}
		}

		/// public propaty name  :  PaymentMonthName
		/// <summary>�x�����敪���̃v���p�e�B</summary>
		/// <value>�����A�����A���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentMonthName
		{
			get{return _paymentMonthName;}
			set{_paymentMonthName = value;}
		}

		/// public propaty name  :  PaymentDay
		/// <summary>�x�����v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PaymentDay
		{
			get{return _paymentDay;}
			set{_paymentDay = value;}
		}

		/// public propaty name  :  MoneyKindList
		/// <summary>����R�[�h���X�g�v���p�e�B</summary>
		/// <value>RsltInfo_AccPayTotalWork�N���X�Ŋi�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����R�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ArrayList MoneyKindList
		{
			get{return _moneyKindList;}
			set{_moneyKindList = value;}
		}

        /// public propaty name  :  ResultsSectCd
        /// <summary>���ы��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ы��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsSectCd
        {
            get { return _resultsSectCd; }
            set { _resultsSectCd = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>����d�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
        }

		/// <summary>
		/// �x���ꗗ�\���o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>RsltInfo_PaymentTotalWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentTotalWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RsltInfo_PaymentTotalWork()
		{
		}

	}
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_PaymentTotalWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentTotalWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_PaymentTotalWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentTotalWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  RsltInfo_PaymentTotalWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is RsltInfo_PaymentTotalWork || graph is ArrayList || graph is RsltInfo_PaymentTotalWork[]) )
			throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_PaymentTotalWork).FullName ) );

		if( graph != null && graph is RsltInfo_PaymentTotalWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentTotalWork" );

		//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is RsltInfo_PaymentTotalWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((RsltInfo_PaymentTotalWork[])graph).Length;
		}
		else if( graph is RsltInfo_PaymentTotalWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		//��ƃR�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		//�v�㋒�_�R�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //AddUpSecCode
		//�v�㋒�_����
		serInfo.MemberInfo.Add( typeof(string) ); //AddUpSecName
		//�x����R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //PayeeCode
		//�x���於��
		serInfo.MemberInfo.Add( typeof(string) ); //PayeeName
		//�x���於��2
		serInfo.MemberInfo.Add( typeof(string) ); //PayeeName2
		//�x���旪��
		serInfo.MemberInfo.Add( typeof(string) ); //PayeeSnm
		//�d����R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierCd
		//�d���於1
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierNm1
		//�d���於2
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierNm2
		//�d���旪��
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierSnm
		//�v��N����
		serInfo.MemberInfo.Add( typeof(Int32) ); //AddUpDate
		//�v��N��
		serInfo.MemberInfo.Add( typeof(Int32) ); //AddUpYearMonth
		//�O��x�����z
		serInfo.MemberInfo.Add( typeof(Int64) ); //LastTimePayment
		//�d��2��O�c���i�x���v�j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtl2TmBfBlPay
		//�d��3��O�c���i�x���v�j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtl3TmBfBlPay
		//����x�����z�i�ʏ�x���j
		serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimePayNrml
		//����J�z�c���i�x���v�j
		serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeTtlBlcPay
		//���E�㍡��d�����z
		serInfo.MemberInfo.Add( typeof(Int64) ); //OfsThisTimeStock
		//����ԕi���z
		serInfo.MemberInfo.Add( typeof(Int64) ); //ThisStckPricRgds
		//����l�����z
		serInfo.MemberInfo.Add( typeof(Int64) ); //ThisStckPricDis
		//���E�㍡��d�������
		serInfo.MemberInfo.Add( typeof(Int64) ); //OfsThisStockTax
		//�d�����v�c���i�x���v�j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTotalPayBalance
		//�d���`�[����
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockSlipCount
		//����萔���z�i�ʏ�x���j
		serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeFeePayNrml
		//����l���z�i�ʏ�x���j
		serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeDisPayNrml
		//�x�����敪����
		serInfo.MemberInfo.Add( typeof(string) ); //PaymentMonthName
		//�x����
		serInfo.MemberInfo.Add( typeof(Int32) ); //PaymentDay
		//����R�[�h���X�g
        serInfo.MemberInfo.Add(typeof(ArrayList)); //MoneyKindList
        //���ы��_�R�[�h
        serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
        //����d�����z
        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice

			
		serInfo.Serialize( writer, serInfo );
		if( graph is RsltInfo_PaymentTotalWork )
		{
			RsltInfo_PaymentTotalWork temp = (RsltInfo_PaymentTotalWork)graph;

			SetRsltInfo_PaymentTotalWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is RsltInfo_PaymentTotalWork[])
			{
				lst = new ArrayList();
				lst.AddRange((RsltInfo_PaymentTotalWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(RsltInfo_PaymentTotalWork temp in lst)
			{
				SetRsltInfo_PaymentTotalWork(writer, temp);
			}

		}

		
	}


        /// <summary>
        /// RsltInfo_PaymentTotalWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  RsltInfo_PaymentTotalWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentTotalWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_PaymentTotalWork(System.IO.BinaryWriter writer, RsltInfo_PaymentTotalWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�v�㋒�_����
            writer.Write(temp.AddUpSecName);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���於��
            writer.Write(temp.PayeeName);
            //�x���於��2
            writer.Write(temp.PayeeName2);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�O��x�����z
            writer.Write(temp.LastTimePayment);
            //�d��2��O�c���i�x���v�j
            writer.Write(temp.StockTtl2TmBfBlPay);
            //�d��3��O�c���i�x���v�j
            writer.Write(temp.StockTtl3TmBfBlPay);
            //����x�����z�i�ʏ�x���j
            writer.Write(temp.ThisTimePayNrml);
            //����J�z�c���i�x���v�j
            writer.Write(temp.ThisTimeTtlBlcPay);
            //���E�㍡��d�����z
            writer.Write(temp.OfsThisTimeStock);
            //����ԕi���z
            writer.Write(temp.ThisStckPricRgds);
            //����l�����z
            writer.Write(temp.ThisStckPricDis);
            //���E�㍡��d�������
            writer.Write(temp.OfsThisStockTax);
            //�d�����v�c���i�x���v�j
            writer.Write(temp.StockTotalPayBalance);
            //�d���`�[����
            writer.Write(temp.StockSlipCount);
            //����萔���z�i�ʏ�x���j
            writer.Write(temp.ThisTimeFeePayNrml);
            //����l���z�i�ʏ�x���j
            writer.Write(temp.ThisTimeDisPayNrml);
            //�x�����敪����
            writer.Write(temp.PaymentMonthName);
            //�x����
            writer.Write(temp.PaymentDay);
            //����R�[�h���X�g
            // DEL 2008.11.10 >>>
            /*
            writer.Write(4);
            RsltInfo_AccPayTotalWork rsltInfo_AccPayTotalWork = new RsltInfo_AccPayTotalWork();
            for (int cnt = 0; cnt < 3; cnt++)                
            {
                if (cnt == 0)
                }
                    writer.Write(rsltInfo_AccPayTotalWork.MoneyKindCode);
                }
                if (cnt == 1)
                {
                    writer.Write(rsltInfo_AccPayTotalWork.MoneyKindName);
                }
                if (cnt == 2)
                {
                    writer.Write(rsltInfo_AccPayTotalWork.MoneyKindDiv);
                }
                if (cnt == 3)
                {
                    writer.Write(rsltInfo_AccPayTotalWork.Payment);
                }
             */
            // ADD 2008.11.10 >>>
            writer.Write(temp.MoneyKindList.Count);
            if (temp.MoneyKindList != null)
            {
                for (int cnt = 0; cnt < temp.MoneyKindList.Count; cnt++)
                {
                    writer.Write(((RsltInfo_AccPayTotalWork)temp.MoneyKindList[cnt]).MoneyKindCode);
                    writer.Write(((RsltInfo_AccPayTotalWork)temp.MoneyKindList[cnt]).MoneyKindName);
                    writer.Write(((RsltInfo_AccPayTotalWork)temp.MoneyKindList[cnt]).MoneyKindDiv);
                    writer.Write(((RsltInfo_AccPayTotalWork)temp.MoneyKindList[cnt]).Payment);
                }
            }
            // ADD 2008.11.10 <<<
            //���ы��_�R�[�h
            writer.Write(temp.ResultsSectCd);
            //����d�����z
            writer.Write(temp.ThisTimeStockPrice);
        }

        /// <summary>
        ///  RsltInfo_PaymentTotalWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_PaymentTotalWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentTotalWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_PaymentTotalWork GetRsltInfo_PaymentTotalWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_PaymentTotalWork temp = new RsltInfo_PaymentTotalWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�v�㋒�_����
            temp.AddUpSecName = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���於��
            temp.PayeeName = reader.ReadString();
            //�x���於��2
            temp.PayeeName2 = reader.ReadString();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�O��x�����z
            temp.LastTimePayment = reader.ReadInt64();
            //�d��2��O�c���i�x���v�j
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //�d��3��O�c���i�x���v�j
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //����x�����z�i�ʏ�x���j
            temp.ThisTimePayNrml = reader.ReadInt64();
            //����J�z�c���i�x���v�j
            temp.ThisTimeTtlBlcPay = reader.ReadInt64();
            //���E�㍡��d�����z
            temp.OfsThisTimeStock = reader.ReadInt64();
            //����ԕi���z
            temp.ThisStckPricRgds = reader.ReadInt64();
            //����l�����z
            temp.ThisStckPricDis = reader.ReadInt64();
            //���E�㍡��d�������
            temp.OfsThisStockTax = reader.ReadInt64();
            //�d�����v�c���i�x���v�j
            temp.StockTotalPayBalance = reader.ReadInt64();
            //�d���`�[����
            temp.StockSlipCount = reader.ReadInt32();
            //����萔���z�i�ʏ�x���j
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //����l���z�i�ʏ�x���j
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //�x�����敪����
            temp.PaymentMonthName = reader.ReadString();
            //�x����
            temp.PaymentDay = reader.ReadInt32();
            //����R�[�h���X�g
            int ReadCnt = reader.ReadInt32();

            temp.MoneyKindList = new ArrayList();
            for (int cnt = 0; cnt < ReadCnt; cnt++)
            {
                RsltInfo_AccPayTotalWork rsltInfo_AccPayTotalWork = new RsltInfo_AccPayTotalWork();
                rsltInfo_AccPayTotalWork.MoneyKindCode = reader.ReadInt32();
                rsltInfo_AccPayTotalWork.MoneyKindName = reader.ReadString();
                rsltInfo_AccPayTotalWork.MoneyKindDiv = reader.ReadInt32();
                rsltInfo_AccPayTotalWork.Payment = reader.ReadInt64();
                temp.MoneyKindList.Add(rsltInfo_AccPayTotalWork);
            }
            //���ы��_�R�[�h
            temp.ResultsSectCd = reader.ReadString();
            //����d�����z
            temp.ThisTimeStockPrice = reader.ReadInt64();

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
        /// <returns>RsltInfo_PaymentTotalWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentTotalWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_PaymentTotalWork temp = GetRsltInfo_PaymentTotalWork(reader, serInfo);
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
                    retValue = (RsltInfo_PaymentTotalWork[])lst.ToArray(typeof(RsltInfo_PaymentTotalWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

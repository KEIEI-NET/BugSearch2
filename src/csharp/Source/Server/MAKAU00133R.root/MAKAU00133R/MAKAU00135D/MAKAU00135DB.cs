using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuplAccPayWork
	/// <summary>
	///                      �d���攃�|���z���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���攃�|���z���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/06/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SuplAccPayWork : IFileHeader
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>�x����R�[�h</summary>
		/// <remarks>���|�̐e�R�[�h</remarks>
		private Int32 _payeeCode;

		/// <summary>�x���於��</summary>
		private string _payeeName = "";

		/// <summary>�x���於��2</summary>
		private string _payeeName2 = "";

		/// <summary>�x���旪��</summary>
		private string _payeeSnm = "";

		/// <summary>�d����R�[�h</summary>
		/// <remarks>���|�̎q�R�[�h</remarks>
		private Int32 _supplierCd;

		/// <summary>�d���於1</summary>
		private string _supplierNm1 = "";

		/// <summary>�d���於2</summary>
		private string _supplierNm2 = "";

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ���|�̌v����i���Њ�j</remarks>
		private DateTime _addUpDate;

		/// <summary>�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�O�񔃊|���z</summary>
		private Int64 _lastTimeAccPay;

		/// <summary>����萔���z�i�ʏ�x���j</summary>
		private Int64 _thisTimeFeePayNrml;

		/// <summary>����l���z�i�ʏ�x���j</summary>
		private Int64 _thisTimeDisPayNrml;

		/// <summary>����x�����z�i�ʏ�x���j</summary>
		/// <remarks>�x���z�̍��v���z</remarks>
		private Int64 _thisTimePayNrml;

		/// <summary>����J�z�c���i���|�v�j</summary>
		/// <remarks>����J�z�c�����O�񔃊|���z�|����x���z���v�i�ʏ�����j</remarks>
		private Int64 _thisTimeTtlBlcAcPay;

		/// <summary>���E�㍡��d�����z</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisTimeStock;

		/// <summary>���E�㍡��d�������</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisStockTax;

		/// <summary>���E��O�őΏۊz</summary>
		/// <remarks>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedOffsetOutTax;

		/// <summary>���E����őΏۊz</summary>
		/// <remarks>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedOffsetInTax;

		/// <summary>���E���ېőΏۊz</summary>
		/// <remarks>���E�p�F��ېŊz�̏W�v</remarks>
		private Int64 _itdedOffsetTaxFree;

		/// <summary>���E��O�ŏ����</summary>
		/// <remarks>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
		private Int64 _offsetOutTax;

		/// <summary>���E����ŏ����</summary>
		/// <remarks>���E�p�F���ŏ���ł̏W�v</remarks>
		private Int64 _offsetInTax;

		/// <summary>����d�����z</summary>
		/// <remarks>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</remarks>
		private Int64 _thisTimeStockPrice;

		/// <summary>����d�������</summary>
		/// <remarks>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</remarks>
		private Int64 _thisStcPrcTax;

		/// <summary>�d���O�őΏۊz���v</summary>
		private Int64 _ttlItdedStcOutTax;

		/// <summary>�d�����őΏۊz���v</summary>
		private Int64 _ttlItdedStcInTax;

		/// <summary>�d����ېőΏۊz���v</summary>
		private Int64 _ttlItdedStcTaxFree;

		/// <summary>�d���O�Ŋz���v</summary>
		private Int64 _ttlStockOuterTax;

		/// <summary>�d�����Ŋz���v</summary>
		/// <remarks>���ŏ��i�d���̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</remarks>
		private Int64 _ttlStockInnerTax;

		/// <summary>����ԕi���z</summary>
		/// <remarks>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</remarks>
		private Int64 _thisStckPricRgds;

		/// <summary>����ԕi�����</summary>
		/// <remarks>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
		private Int64 _thisStcPrcTaxRgds;

		/// <summary>�ԕi�O�őΏۊz���v</summary>
		private Int64 _ttlItdedRetOutTax;

		/// <summary>�ԕi���őΏۊz���v</summary>
		private Int64 _ttlItdedRetInTax;

		/// <summary>�ԕi��ېőΏۊz���v</summary>
		private Int64 _ttlItdedRetTaxFree;

		/// <summary>�ԕi�O�Ŋz���v</summary>
		private Int64 _ttlRetOuterTax;

		/// <summary>�ԕi���Ŋz���v</summary>
		/// <remarks>���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>����l�����z</summary>
		/// <remarks>�Ŕ����̎d���l�������z</remarks>
		private Int64 _thisStckPricDis;

		/// <summary>����l�������</summary>
		/// <remarks>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
		private Int64 _thisStcPrcTaxDis;

		/// <summary>�l���O�őΏۊz���v</summary>
		private Int64 _ttlItdedDisOutTax;

		/// <summary>�l�����őΏۊz���v</summary>
		private Int64 _ttlItdedDisInTax;

		/// <summary>�l����ېőΏۊz���v</summary>
		private Int64 _ttlItdedDisTaxFree;

		/// <summary>�l���O�Ŋz���v</summary>
		private Int64 _ttlDisOuterTax;

		/// <summary>�l�����Ŋz���v</summary>
		/// <remarks>���ŏ��i�l���̓��ŏ���Ŋz</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>�d�����v�c���i���|�v�j</summary>
		/// <remarks>�������̔��|�c�� + ����J�z�c���{���񏃎d�����z�{���񏃎d������Ł{����Œ����z�{�c�������z</remarks>
		private Int64 _stckTtlAccPayBalance;

		/// <summary>�d��2��O�c���i���|�v�j</summary>
		private Int64 _stckTtl2TmBfBlAccPay;

		/// <summary>�d��3��O�c���i���|�v�j</summary>
		private Int64 _stckTtl3TmBfBlAccPay;

		/// <summary>�����X�V���s�N����</summary>
		/// <remarks>YYYYMMDD�@�����X�V���s�N����</remarks>
		private DateTime _monthAddUpExpDate;

		/// <summary>�����X�V�J�n�N����</summary>
		/// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
		private DateTime _stMonCAddUpUpdDate;

		/// <summary>�O�񌎎��X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</remarks>
		private DateTime _laMonCAddUpUpdDate;

		/// <summary>�d���`�[����</summary>
		/// <remarks>�d���`�[�����i�|�d���{�����d���j</remarks>
		private Int32 _stockSlipCount;

		/// <summary>�d�������œ]�ŕ����R�[�h</summary>
		private Int32 _suppCTaxLayCd;

		/// <summary>�d�������Őŗ�</summary>
		private Double _supplierConsTaxRate;

		/// <summary>�[�������敪</summary>
		private Int32 _fractionProcCd;


		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  ResultsAddUpSecCd
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
		/// <value>���|�̐e�R�[�h</value>
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
		/// <value>���|�̎q�R�[�h</value>
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
		/// <value>YYYYMMDD ���|�̌v����i���Њ�j</value>
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

		/// public propaty name  :  SalesDate
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

		/// public propaty name  :  LastTimeAccPay
		/// <summary>�O�񔃊|���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񔃊|���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LastTimeAccPay
		{
			get{return _lastTimeAccPay;}
			set{_lastTimeAccPay = value;}
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

		/// public propaty name  :  ThisTimeTtlBlcAcPay
		/// <summary>����J�z�c���i���|�v�j�v���p�e�B</summary>
		/// <value>����J�z�c�����O�񔃊|���z�|����x���z���v�i�ʏ�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����J�z�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcAcPay
		{
			get{return _thisTimeTtlBlcAcPay;}
			set{_thisTimeTtlBlcAcPay = value;}
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

		/// public propaty name  :  ItdedOffsetOutTax
		/// <summary>���E��O�őΏۊz�v���p�e�B</summary>
		/// <value>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E��O�őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedOffsetOutTax
		{
			get{return _itdedOffsetOutTax;}
			set{_itdedOffsetOutTax = value;}
		}

		/// public propaty name  :  ItdedOffsetInTax
		/// <summary>���E����őΏۊz�v���p�e�B</summary>
		/// <value>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E����őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedOffsetInTax
		{
			get{return _itdedOffsetInTax;}
			set{_itdedOffsetInTax = value;}
		}

		/// public propaty name  :  ItdedOffsetTaxFree
		/// <summary>���E���ېőΏۊz�v���p�e�B</summary>
		/// <value>���E�p�F��ېŊz�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E���ېőΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedOffsetTaxFree
		{
			get{return _itdedOffsetTaxFree;}
			set{_itdedOffsetTaxFree = value;}
		}

		/// public propaty name  :  OffsetOutTax
		/// <summary>���E��O�ŏ���Ńv���p�e�B</summary>
		/// <value>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E��O�ŏ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OffsetOutTax
		{
			get{return _offsetOutTax;}
			set{_offsetOutTax = value;}
		}

		/// public propaty name  :  OffsetInTax
		/// <summary>���E����ŏ���Ńv���p�e�B</summary>
		/// <value>���E�p�F���ŏ���ł̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E����ŏ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OffsetInTax
		{
			get{return _offsetInTax;}
			set{_offsetInTax = value;}
		}

		/// public propaty name  :  ThisTimeStockPrice
		/// <summary>����d�����z�v���p�e�B</summary>
		/// <value>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����d�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeStockPrice
		{
			get{return _thisTimeStockPrice;}
			set{_thisTimeStockPrice = value;}
		}

		/// public propaty name  :  ThisStcPrcTax
		/// <summary>����d������Ńv���p�e�B</summary>
		/// <value>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����d������Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisStcPrcTax
		{
			get{return _thisStcPrcTax;}
			set{_thisStcPrcTax = value;}
		}

		/// public propaty name  :  TtlItdedStcOutTax
		/// <summary>�d���O�őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���O�őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedStcOutTax
		{
			get{return _ttlItdedStcOutTax;}
			set{_ttlItdedStcOutTax = value;}
		}

		/// public propaty name  :  TtlItdedStcInTax
		/// <summary>�d�����őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedStcInTax
		{
			get{return _ttlItdedStcInTax;}
			set{_ttlItdedStcInTax = value;}
		}

		/// public propaty name  :  TtlItdedStcTaxFree
		/// <summary>�d����ېőΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedStcTaxFree
		{
			get{return _ttlItdedStcTaxFree;}
			set{_ttlItdedStcTaxFree = value;}
		}

		/// public propaty name  :  TtlStockOuterTax
		/// <summary>�d���O�Ŋz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���O�Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlStockOuterTax
		{
			get{return _ttlStockOuterTax;}
			set{_ttlStockOuterTax = value;}
		}

		/// public propaty name  :  TtlStockInnerTax
		/// <summary>�d�����Ŋz���v�v���p�e�B</summary>
		/// <value>���ŏ��i�d���̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlStockInnerTax
		{
			get{return _ttlStockInnerTax;}
			set{_ttlStockInnerTax = value;}
		}

		/// public propaty name  :  ThisStckPricRgds
		/// <summary>����ԕi���z�v���p�e�B</summary>
		/// <value>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</value>
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

		/// public propaty name  :  TtlItdedRetOutTax
		/// <summary>�ԕi�O�őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi�O�őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedRetOutTax
		{
			get{return _ttlItdedRetOutTax;}
			set{_ttlItdedRetOutTax = value;}
		}

		/// public propaty name  :  TtlItdedRetInTax
		/// <summary>�ԕi���őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedRetInTax
		{
			get{return _ttlItdedRetInTax;}
			set{_ttlItdedRetInTax = value;}
		}

		/// public propaty name  :  TtlItdedRetTaxFree
		/// <summary>�ԕi��ېőΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi��ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedRetTaxFree
		{
			get{return _ttlItdedRetTaxFree;}
			set{_ttlItdedRetTaxFree = value;}
		}

		/// public propaty name  :  TtlRetOuterTax
		/// <summary>�ԕi�O�Ŋz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi�O�Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlRetOuterTax
		{
			get{return _ttlRetOuterTax;}
			set{_ttlRetOuterTax = value;}
		}

		/// public propaty name  :  TtlRetInnerTax
		/// <summary>�ԕi���Ŋz���v�v���p�e�B</summary>
		/// <value>���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlRetInnerTax
		{
			get{return _ttlRetInnerTax;}
			set{_ttlRetInnerTax = value;}
		}

		/// public propaty name  :  ThisStckPricDis
		/// <summary>����l�����z�v���p�e�B</summary>
		/// <value>�Ŕ����̎d���l�������z</value>
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

		/// public propaty name  :  TtlItdedDisOutTax
		/// <summary>�l���O�őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l���O�őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedDisOutTax
		{
			get{return _ttlItdedDisOutTax;}
			set{_ttlItdedDisOutTax = value;}
		}

		/// public propaty name  :  TtlItdedDisInTax
		/// <summary>�l�����őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�����őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedDisInTax
		{
			get{return _ttlItdedDisInTax;}
			set{_ttlItdedDisInTax = value;}
		}

		/// public propaty name  :  TtlItdedDisTaxFree
		/// <summary>�l����ېőΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l����ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedDisTaxFree
		{
			get{return _ttlItdedDisTaxFree;}
			set{_ttlItdedDisTaxFree = value;}
		}

		/// public propaty name  :  TtlDisOuterTax
		/// <summary>�l���O�Ŋz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l���O�Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlDisOuterTax
		{
			get{return _ttlDisOuterTax;}
			set{_ttlDisOuterTax = value;}
		}

		/// public propaty name  :  TtlDisInnerTax
		/// <summary>�l�����Ŋz���v�v���p�e�B</summary>
		/// <value>���ŏ��i�l���̓��ŏ���Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�����Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlDisInnerTax
		{
			get{return _ttlDisInnerTax;}
			set{_ttlDisInnerTax = value;}
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

		/// public propaty name  :  StckTtlAccPayBalance
		/// <summary>�d�����v�c���i���|�v�j�v���p�e�B</summary>
		/// <value>�������̔��|�c�� + ����J�z�c���{���񏃎d�����z�{���񏃎d������Ł{����Œ����z�{�c�������z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StckTtlAccPayBalance
		{
			get{return _stckTtlAccPayBalance;}
			set{_stckTtlAccPayBalance = value;}
		}

		/// public propaty name  :  StckTtl2TmBfBlAccPay
		/// <summary>�d��2��O�c���i���|�v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d��2��O�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StckTtl2TmBfBlAccPay
		{
			get{return _stckTtl2TmBfBlAccPay;}
			set{_stckTtl2TmBfBlAccPay = value;}
		}

		/// public propaty name  :  StckTtl3TmBfBlAccPay
		/// <summary>�d��3��O�c���i���|�v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d��3��O�c���i���|�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StckTtl3TmBfBlAccPay
		{
			get{return _stckTtl3TmBfBlAccPay;}
			set{_stckTtl3TmBfBlAccPay = value;}
		}

		/// public propaty name  :  MonthAddUpExpDate
		/// <summary>�����X�V���s�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD�@�����X�V���s�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime MonthAddUpExpDate
		{
			get{return _monthAddUpExpDate;}
			set{_monthAddUpExpDate = value;}
		}

		/// public propaty name  :  StMonCAddUpUpdDate
		/// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StMonCAddUpUpdDate
		{
			get{return _stMonCAddUpUpdDate;}
			set{_stMonCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LaMonCAddUpUpdDate
		/// <summary>�O�񌎎��X�V�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񌎎��X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LaMonCAddUpUpdDate
		{
			get{return _laMonCAddUpUpdDate;}
			set{_laMonCAddUpUpdDate = value;}
		}

		/// public propaty name  :  StockSlipCount
		/// <summary>�d���`�[�����v���p�e�B</summary>
		/// <value>�d���`�[�����i�|�d���{�����d���j</value>
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

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SuppCTaxLayCd
		{
			get{return _suppCTaxLayCd;}
			set{_suppCTaxLayCd = value;}
		}

		/// public propaty name  :  SupplierConsTaxRate
		/// <summary>�d�������Őŗ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������Őŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SupplierConsTaxRate
		{
			get{return _supplierConsTaxRate;}
			set{_supplierConsTaxRate = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>�[�������敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}


		/// <summary>
		/// �d���攃�|���z���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SuplAccPayWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPayWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplAccPayWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuplAccPayWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuplAccPayWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuplAccPayWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplAccPayWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplAccPayWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplAccPayWork || graph is ArrayList || graph is SuplAccPayWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuplAccPayWork).FullName));

            if (graph != null && graph is SuplAccPayWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplAccPayWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplAccPayWork[])graph).Length;
            }
            else if (graph is SuplAccPayWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���於��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //�x���於��2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�O�񔃊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccPay
            //����萔���z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //����l���z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //����x�����z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //����J�z�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcPay
            //���E�㍡��d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //���E�㍡��d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //���E��O�őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetOutTax
            //���E����őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetInTax
            //���E���ېőΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetTaxFree
            //���E��O�ŏ����
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetOutTax
            //���E����ŏ����
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetInTax
            //����d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //����d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTax
            //�d���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcOutTax
            //�d�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcInTax
            //�d����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcTaxFree
            //�d���O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlStockOuterTax
            //�d�����Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlStockInnerTax
            //����ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //����ԕi�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxRgds
            //�ԕi�O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetOutTax
            //�ԕi���őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetInTax
            //�ԕi��ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetTaxFree
            //�ԕi�O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetOuterTax
            //�ԕi���Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetInnerTax
            //����l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //����l�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxDis
            //�l���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisOutTax
            //�l�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisInTax
            //�l����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisTaxFree
            //�l���O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisOuterTax
            //�l�����Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisInnerTax
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�d�����v�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlAccPayBalance
            //�d��2��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl2TmBfBlAccPay
            //�d��3��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl3TmBfBlAccPay
            //�����X�V���s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate
            //�����X�V�J�n�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //StMonCAddUpUpdDate
            //�O�񌎎��X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LaMonCAddUpUpdDate
            //�d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d�������Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd


            serInfo.Serialize(writer, serInfo);
            if (graph is SuplAccPayWork)
            {
                SuplAccPayWork temp = (SuplAccPayWork)graph;

                SetSuplAccPayWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplAccPayWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplAccPayWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplAccPayWork temp in lst)
                {
                    SetSuplAccPayWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplAccPayWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 64;

        /// <summary>
        ///  SuplAccPayWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplAccPayWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSuplAccPayWork(System.IO.BinaryWriter writer, SuplAccPayWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
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
            //�O�񔃊|���z
            writer.Write(temp.LastTimeAccPay);
            //����萔���z�i�ʏ�x���j
            writer.Write(temp.ThisTimeFeePayNrml);
            //����l���z�i�ʏ�x���j
            writer.Write(temp.ThisTimeDisPayNrml);
            //����x�����z�i�ʏ�x���j
            writer.Write(temp.ThisTimePayNrml);
            //����J�z�c���i���|�v�j
            writer.Write(temp.ThisTimeTtlBlcAcPay);
            //���E�㍡��d�����z
            writer.Write(temp.OfsThisTimeStock);
            //���E�㍡��d�������
            writer.Write(temp.OfsThisStockTax);
            //���E��O�őΏۊz
            writer.Write(temp.ItdedOffsetOutTax);
            //���E����őΏۊz
            writer.Write(temp.ItdedOffsetInTax);
            //���E���ېőΏۊz
            writer.Write(temp.ItdedOffsetTaxFree);
            //���E��O�ŏ����
            writer.Write(temp.OffsetOutTax);
            //���E����ŏ����
            writer.Write(temp.OffsetInTax);
            //����d�����z
            writer.Write(temp.ThisTimeStockPrice);
            //����d�������
            writer.Write(temp.ThisStcPrcTax);
            //�d���O�őΏۊz���v
            writer.Write(temp.TtlItdedStcOutTax);
            //�d�����őΏۊz���v
            writer.Write(temp.TtlItdedStcInTax);
            //�d����ېőΏۊz���v
            writer.Write(temp.TtlItdedStcTaxFree);
            //�d���O�Ŋz���v
            writer.Write(temp.TtlStockOuterTax);
            //�d�����Ŋz���v
            writer.Write(temp.TtlStockInnerTax);
            //����ԕi���z
            writer.Write(temp.ThisStckPricRgds);
            //����ԕi�����
            writer.Write(temp.ThisStcPrcTaxRgds);
            //�ԕi�O�őΏۊz���v
            writer.Write(temp.TtlItdedRetOutTax);
            //�ԕi���őΏۊz���v
            writer.Write(temp.TtlItdedRetInTax);
            //�ԕi��ېőΏۊz���v
            writer.Write(temp.TtlItdedRetTaxFree);
            //�ԕi�O�Ŋz���v
            writer.Write(temp.TtlRetOuterTax);
            //�ԕi���Ŋz���v
            writer.Write(temp.TtlRetInnerTax);
            //����l�����z
            writer.Write(temp.ThisStckPricDis);
            //����l�������
            writer.Write(temp.ThisStcPrcTaxDis);
            //�l���O�őΏۊz���v
            writer.Write(temp.TtlItdedDisOutTax);
            //�l�����őΏۊz���v
            writer.Write(temp.TtlItdedDisInTax);
            //�l����ېőΏۊz���v
            writer.Write(temp.TtlItdedDisTaxFree);
            //�l���O�Ŋz���v
            writer.Write(temp.TtlDisOuterTax);
            //�l�����Ŋz���v
            writer.Write(temp.TtlDisInnerTax);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�d�����v�c���i���|�v�j
            writer.Write(temp.StckTtlAccPayBalance);
            //�d��2��O�c���i���|�v�j
            writer.Write(temp.StckTtl2TmBfBlAccPay);
            //�d��3��O�c���i���|�v�j
            writer.Write(temp.StckTtl3TmBfBlAccPay);
            //�����X�V���s�N����
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);
            //�����X�V�J�n�N����
            writer.Write((Int64)temp.StMonCAddUpUpdDate.Ticks);
            //�O�񌎎��X�V�N����
            writer.Write((Int64)temp.LaMonCAddUpUpdDate.Ticks);
            //�d���`�[����
            writer.Write(temp.StockSlipCount);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d�������Őŗ�
            writer.Write(temp.SupplierConsTaxRate);
            //�[�������敪
            writer.Write(temp.FractionProcCd);

        }

        /// <summary>
        ///  SuplAccPayWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuplAccPayWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplAccPayWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SuplAccPayWork GetSuplAccPayWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuplAccPayWork temp = new SuplAccPayWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
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
            //�O�񔃊|���z
            temp.LastTimeAccPay = reader.ReadInt64();
            //����萔���z�i�ʏ�x���j
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //����l���z�i�ʏ�x���j
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //����x�����z�i�ʏ�x���j
            temp.ThisTimePayNrml = reader.ReadInt64();
            //����J�z�c���i���|�v�j
            temp.ThisTimeTtlBlcAcPay = reader.ReadInt64();
            //���E�㍡��d�����z
            temp.OfsThisTimeStock = reader.ReadInt64();
            //���E�㍡��d�������
            temp.OfsThisStockTax = reader.ReadInt64();
            //���E��O�őΏۊz
            temp.ItdedOffsetOutTax = reader.ReadInt64();
            //���E����őΏۊz
            temp.ItdedOffsetInTax = reader.ReadInt64();
            //���E���ېőΏۊz
            temp.ItdedOffsetTaxFree = reader.ReadInt64();
            //���E��O�ŏ����
            temp.OffsetOutTax = reader.ReadInt64();
            //���E����ŏ����
            temp.OffsetInTax = reader.ReadInt64();
            //����d�����z
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //����d�������
            temp.ThisStcPrcTax = reader.ReadInt64();
            //�d���O�őΏۊz���v
            temp.TtlItdedStcOutTax = reader.ReadInt64();
            //�d�����őΏۊz���v
            temp.TtlItdedStcInTax = reader.ReadInt64();
            //�d����ېőΏۊz���v
            temp.TtlItdedStcTaxFree = reader.ReadInt64();
            //�d���O�Ŋz���v
            temp.TtlStockOuterTax = reader.ReadInt64();
            //�d�����Ŋz���v
            temp.TtlStockInnerTax = reader.ReadInt64();
            //����ԕi���z
            temp.ThisStckPricRgds = reader.ReadInt64();
            //����ԕi�����
            temp.ThisStcPrcTaxRgds = reader.ReadInt64();
            //�ԕi�O�őΏۊz���v
            temp.TtlItdedRetOutTax = reader.ReadInt64();
            //�ԕi���őΏۊz���v
            temp.TtlItdedRetInTax = reader.ReadInt64();
            //�ԕi��ېőΏۊz���v
            temp.TtlItdedRetTaxFree = reader.ReadInt64();
            //�ԕi�O�Ŋz���v
            temp.TtlRetOuterTax = reader.ReadInt64();
            //�ԕi���Ŋz���v
            temp.TtlRetInnerTax = reader.ReadInt64();
            //����l�����z
            temp.ThisStckPricDis = reader.ReadInt64();
            //����l�������
            temp.ThisStcPrcTaxDis = reader.ReadInt64();
            //�l���O�őΏۊz���v
            temp.TtlItdedDisOutTax = reader.ReadInt64();
            //�l�����őΏۊz���v
            temp.TtlItdedDisInTax = reader.ReadInt64();
            //�l����ېőΏۊz���v
            temp.TtlItdedDisTaxFree = reader.ReadInt64();
            //�l���O�Ŋz���v
            temp.TtlDisOuterTax = reader.ReadInt64();
            //�l�����Ŋz���v
            temp.TtlDisInnerTax = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�d�����v�c���i���|�v�j
            temp.StckTtlAccPayBalance = reader.ReadInt64();
            //�d��2��O�c���i���|�v�j
            temp.StckTtl2TmBfBlAccPay = reader.ReadInt64();
            //�d��3��O�c���i���|�v�j
            temp.StckTtl3TmBfBlAccPay = reader.ReadInt64();
            //�����X�V���s�N����
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());
            //�����X�V�J�n�N����
            temp.StMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�O�񌎎��X�V�N����
            temp.LaMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�d���`�[����
            temp.StockSlipCount = reader.ReadInt32();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d�������Őŗ�
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //�[�������敪
            temp.FractionProcCd = reader.ReadInt32();


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
        /// <returns>SuplAccPayWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplAccPayWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplAccPayWork temp = GetSuplAccPayWork(reader, serInfo);
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
                    retValue = (SuplAccPayWork[])lst.ToArray(typeof(SuplAccPayWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

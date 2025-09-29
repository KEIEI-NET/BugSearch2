using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuplAccPay
	/// <summary>
	///                      �d���攃�|���z�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���攃�|���z�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SuplAccPay
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

		/// <summary>���Ӑ�R�[�h</summary>
		/// <remarks>���|�̎q�R�[�h</remarks>
		private Int32 _customerCode;

		/// <summary>���Ӑ於��</summary>
		private string _customerName = "";

		/// <summary>���Ӑ於��2</summary>
		private string _customerName2 = "";

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

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
		private Int64 _ofsThisTimeSales;

		/// <summary>���E�㍡��d�������</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisSalesTax;

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

		/// <summary>��������z</summary>
		/// <remarks>���E�p�d�����v</remarks>
		private Int64 _thisRecvOffset;

		/// <summary>�����摊�E�����</summary>
		/// <remarks>���E�p�d������Ł����E�p�d���`�[�O�Ŋz�{���E�p�d���`�[���Ŋz</remarks>
		private Int64 _thisRecvOffsetTax;

		/// <summary>������O�őΏۊz���v</summary>
		/// <remarks>���E�p�d���`�[�̊O�őΏۊz</remarks>
		private Int64 _thisRecvOutTax;

		/// <summary>��������őΏۊz���v</summary>
		/// <remarks>���E�p�d���`�[�̓��őΏۊz</remarks>
		private Int64 _thisRecvInTax;

		/// <summary>�������ېőΏۊz���v</summary>
		/// <remarks>���E�p�d���`�[�̔�ېőΏۊz</remarks>
		private Int64 _thisRecvTaxFree;

		/// <summary>������O�Ŋz���v</summary>
		/// <remarks>���E�p�d���`�[�O�Ŋz</remarks>
		private Int64 _thisRecvOuterTax;

		/// <summary>��������Ŋz���v</summary>
		/// <remarks>���E�p�d���`�[���Ŋz</remarks>
		private Int64 _thisRecvInnerTax;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>�d�����v�c���i���|�v�j</summary>
		/// <remarks>�������̔��|�c������J�z�c���{���񏃎d�����z�{���񏃎d������Ł{����Œ����z�{�c�������z</remarks>
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

		/// <summary>�����ϋ��z�i���U�j</summary>
		private Int64 _nonStmntAppearance;

		/// <summary>�����ϋ��z�i�􂵁j</summary>
		private Int64 _nonStmntIsdone;

		/// <summary>���ϋ��z�i���U�j</summary>
		private Int64 _stmntAppearance;

		/// <summary>���ϋ��z�i�􂵁j</summary>
		private Int64 _stmntIsdone;

		/// <summary>�d�������œ]�ŕ����R�[�h</summary>
		private Int32 _suppCTaxLayCd;

		/// <summary>�d�������Őŗ�</summary>
		private Double _supplierConsTaxRate;

		/// <summary>�[�������敪</summary>
		private Int32 _fractionProcCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";

		/// <summary>�d�������œ]�ŕ�������</summary>
		/// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
		private string _suppCTaxLayMethodNm = "";


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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>���|�̎q�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerName
		/// <summary>���Ӑ於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  CustomerName2
		/// <summary>���Ӑ於��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerName2
		{
			get{return _customerName2;}
			set{_customerName2 = value;}
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>���Ӑ旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
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

		/// public propaty name  :  AddUpDateJpFormal
		/// <summary>�v��N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD ���|�̌v����i���Њ�j</value>
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
		/// <value>YYYYMMDD ���|�̌v����i���Њ�j</value>
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
		/// <value>YYYYMMDD ���|�̌v����i���Њ�j</value>
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
		/// <value>YYYYMMDD ���|�̌v����i���Њ�j</value>
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

		/// public propaty name  :  OfsThisTimeSales
		/// <summary>���E�㍡��d�����z�v���p�e�B</summary>
		/// <value>���E����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisTimeSales
		{
			get{return _ofsThisTimeSales;}
			set{_ofsThisTimeSales = value;}
		}

		/// public propaty name  :  OfsThisSalesTax
		/// <summary>���E�㍡��d������Ńv���p�e�B</summary>
		/// <value>���E����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisSalesTax
		{
			get{return _ofsThisSalesTax;}
			set{_ofsThisSalesTax = value;}
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

		/// public propaty name  :  ThisRecvOffset
		/// <summary>��������z�v���p�e�B</summary>
		/// <value>���E�p�d�����v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvOffset
		{
			get{return _thisRecvOffset;}
			set{_thisRecvOffset = value;}
		}

		/// public propaty name  :  ThisRecvOffsetTax
		/// <summary>�����摊�E����Ńv���p�e�B</summary>
		/// <value>���E�p�d������Ł����E�p�d���`�[�O�Ŋz�{���E�p�d���`�[���Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����摊�E����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvOffsetTax
		{
			get{return _thisRecvOffsetTax;}
			set{_thisRecvOffsetTax = value;}
		}

		/// public propaty name  :  ThisRecvOutTax
		/// <summary>������O�őΏۊz���v�v���p�e�B</summary>
		/// <value>���E�p�d���`�[�̊O�őΏۊz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������O�őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvOutTax
		{
			get{return _thisRecvOutTax;}
			set{_thisRecvOutTax = value;}
		}

		/// public propaty name  :  ThisRecvInTax
		/// <summary>��������őΏۊz���v�v���p�e�B</summary>
		/// <value>���E�p�d���`�[�̓��őΏۊz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvInTax
		{
			get{return _thisRecvInTax;}
			set{_thisRecvInTax = value;}
		}

		/// public propaty name  :  ThisRecvTaxFree
		/// <summary>�������ېőΏۊz���v�v���p�e�B</summary>
		/// <value>���E�p�d���`�[�̔�ېőΏۊz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvTaxFree
		{
			get{return _thisRecvTaxFree;}
			set{_thisRecvTaxFree = value;}
		}

		/// public propaty name  :  ThisRecvOuterTax
		/// <summary>������O�Ŋz���v�v���p�e�B</summary>
		/// <value>���E�p�d���`�[�O�Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������O�Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvOuterTax
		{
			get{return _thisRecvOuterTax;}
			set{_thisRecvOuterTax = value;}
		}

		/// public propaty name  :  ThisRecvInnerTax
		/// <summary>��������Ŋz���v�v���p�e�B</summary>
		/// <value>���E�p�d���`�[���Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisRecvInnerTax
		{
			get{return _thisRecvInnerTax;}
			set{_thisRecvInnerTax = value;}
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
		/// <value>�������̔��|�c������J�z�c���{���񏃎d�����z�{���񏃎d������Ł{����Œ����z�{�c�������z</value>
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

		/// public propaty name  :  MonthAddUpExpDateJpFormal
		/// <summary>�����X�V���s�N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD�@�����X�V���s�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MonthAddUpExpDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  MonthAddUpExpDateJpInFormal
		/// <summary>�����X�V���s�N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD�@�����X�V���s�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MonthAddUpExpDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  MonthAddUpExpDateAdFormal
		/// <summary>�����X�V���s�N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD�@�����X�V���s�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MonthAddUpExpDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  MonthAddUpExpDateAdInFormal
		/// <summary>�����X�V���s�N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD�@�����X�V���s�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MonthAddUpExpDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _monthAddUpExpDate);}
			set{}
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

		/// public propaty name  :  StMonCAddUpUpdDateJpFormal
		/// <summary>�����X�V�J�n�N���� �a��v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StMonCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDateJpInFormal
		/// <summary>�����X�V�J�n�N���� �a��(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StMonCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDateAdFormal
		/// <summary>�����X�V�J�n�N���� ����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StMonCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDateAdInFormal
		/// <summary>�����X�V�J�n�N���� ����(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StMonCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _stMonCAddUpUpdDate);}
			set{}
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

		/// public propaty name  :  LaMonCAddUpUpdDateJpFormal
		/// <summary>�O�񌎎��X�V�N���� �a��v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񌎎��X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateJpInFormal
		/// <summary>�O�񌎎��X�V�N���� �a��(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񌎎��X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateAdFormal
		/// <summary>�O�񌎎��X�V�N���� ����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񌎎��X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateAdInFormal
		/// <summary>�O�񌎎��X�V�N���� ����(��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񌎎��X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _laMonCAddUpUpdDate);}
			set{}
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

		/// public propaty name  :  NonStmntAppearance
		/// <summary>�����ϋ��z�i���U�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ϋ��z�i���U�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 NonStmntAppearance
		{
			get{return _nonStmntAppearance;}
			set{_nonStmntAppearance = value;}
		}

		/// public propaty name  :  NonStmntIsdone
		/// <summary>�����ϋ��z�i�􂵁j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ϋ��z�i�􂵁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 NonStmntIsdone
		{
			get{return _nonStmntIsdone;}
			set{_nonStmntIsdone = value;}
		}

		/// public propaty name  :  StmntAppearance
		/// <summary>���ϋ��z�i���U�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϋ��z�i���U�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StmntAppearance
		{
			get{return _stmntAppearance;}
			set{_stmntAppearance = value;}
		}

		/// public propaty name  :  StmntIsdone
		/// <summary>���ϋ��z�i�􂵁j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϋ��z�i�􂵁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StmntIsdone
		{
			get{return _stmntIsdone;}
			set{_stmntIsdone = value;}
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
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

		/// public propaty name  :  SuppCTaxLayMethodNm
		/// <summary>�d�������œ]�ŕ������̃v���p�e�B</summary>
		/// <value>�`�[�P�ʁA���גP�ʁA�����P��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������œ]�ŕ������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SuppCTaxLayMethodNm
		{
			get{return _suppCTaxLayMethodNm;}
			set{_suppCTaxLayMethodNm = value;}
		}


		/// <summary>
		/// �d���攃�|���z�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>SuplAccPay�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplAccPay()
		{
		}

		/// <summary>
		/// �d���攃�|���z�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="payeeCode">�x����R�[�h(���|�̐e�R�[�h)</param>
		/// <param name="payeeName">�x���於��</param>
		/// <param name="payeeName2">�x���於��2</param>
		/// <param name="payeeSnm">�x���旪��</param>
		/// <param name="customerCode">���Ӑ�R�[�h(���|�̎q�R�[�h)</param>
		/// <param name="customerName">���Ӑ於��</param>
		/// <param name="customerName2">���Ӑ於��2</param>
		/// <param name="customerSnm">���Ӑ旪��</param>
		/// <param name="addUpDate">�v��N����(YYYYMMDD ���|�̌v����i���Њ�j)</param>
		/// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
		/// <param name="lastTimeAccPay">�O�񔃊|���z</param>
		/// <param name="thisTimeFeePayNrml">����萔���z�i�ʏ�x���j</param>
		/// <param name="thisTimeDisPayNrml">����l���z�i�ʏ�x���j</param>
		/// <param name="thisTimePayNrml">����x�����z�i�ʏ�x���j(�x���z�̍��v���z)</param>
		/// <param name="thisTimeTtlBlcAcPay">����J�z�c���i���|�v�j(����J�z�c�����O�񔃊|���z�|����x���z���v�i�ʏ�����j)</param>
		/// <param name="ofsThisTimeSales">���E�㍡��d�����z(���E����)</param>
		/// <param name="ofsThisSalesTax">���E�㍡��d�������(���E����)</param>
		/// <param name="itdedOffsetOutTax">���E��O�őΏۊz(���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
		/// <param name="itdedOffsetInTax">���E����őΏۊz(���E�p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
		/// <param name="itdedOffsetTaxFree">���E���ېőΏۊz(���E�p�F��ېŊz�̏W�v)</param>
		/// <param name="offsetOutTax">���E��O�ŏ����(���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
		/// <param name="offsetInTax">���E����ŏ����(���E�p�F���ŏ���ł̏W�v)</param>
		/// <param name="thisTimeStockPrice">����d�����z(�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z)</param>
		/// <param name="thisStcPrcTax">����d�������(����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v)</param>
		/// <param name="ttlItdedStcOutTax">�d���O�őΏۊz���v</param>
		/// <param name="ttlItdedStcInTax">�d�����őΏۊz���v</param>
		/// <param name="ttlItdedStcTaxFree">�d����ېőΏۊz���v</param>
		/// <param name="ttlStockOuterTax">�d���O�Ŋz���v</param>
		/// <param name="ttlStockInnerTax">�d�����Ŋz���v(���ŏ��i�d���̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j)</param>
		/// <param name="thisStckPricRgds">����ԕi���z(�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z)</param>
		/// <param name="thisStcPrcTaxRgds">����ԕi�����(����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
		/// <param name="ttlItdedRetOutTax">�ԕi�O�őΏۊz���v</param>
		/// <param name="ttlItdedRetInTax">�ԕi���őΏۊz���v</param>
		/// <param name="ttlItdedRetTaxFree">�ԕi��ېőΏۊz���v</param>
		/// <param name="ttlRetOuterTax">�ԕi�O�Ŋz���v</param>
		/// <param name="ttlRetInnerTax">�ԕi���Ŋz���v(���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j)</param>
		/// <param name="thisStckPricDis">����l�����z(�Ŕ����̎d���l�������z)</param>
		/// <param name="thisStcPrcTaxDis">����l�������(����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v)</param>
		/// <param name="ttlItdedDisOutTax">�l���O�őΏۊz���v</param>
		/// <param name="ttlItdedDisInTax">�l�����őΏۊz���v</param>
		/// <param name="ttlItdedDisTaxFree">�l����ېőΏۊz���v</param>
		/// <param name="ttlDisOuterTax">�l���O�Ŋz���v</param>
		/// <param name="ttlDisInnerTax">�l�����Ŋz���v(���ŏ��i�l���̓��ŏ���Ŋz)</param>
		/// <param name="thisRecvOffset">��������z(���E�p�d�����v)</param>
		/// <param name="thisRecvOffsetTax">�����摊�E�����(���E�p�d������Ł����E�p�d���`�[�O�Ŋz�{���E�p�d���`�[���Ŋz)</param>
		/// <param name="thisRecvOutTax">������O�őΏۊz���v(���E�p�d���`�[�̊O�őΏۊz)</param>
		/// <param name="thisRecvInTax">��������őΏۊz���v(���E�p�d���`�[�̓��őΏۊz)</param>
		/// <param name="thisRecvTaxFree">�������ېőΏۊz���v(���E�p�d���`�[�̔�ېőΏۊz)</param>
		/// <param name="thisRecvOuterTax">������O�Ŋz���v(���E�p�d���`�[�O�Ŋz)</param>
		/// <param name="thisRecvInnerTax">��������Ŋz���v(���E�p�d���`�[���Ŋz)</param>
		/// <param name="taxAdjust">����Œ����z</param>
		/// <param name="balanceAdjust">�c�������z</param>
		/// <param name="stckTtlAccPayBalance">�d�����v�c���i���|�v�j(�������̔��|�c������J�z�c���{���񏃎d�����z�{���񏃎d������Ł{����Œ����z�{�c�������z)</param>
		/// <param name="stckTtl2TmBfBlAccPay">�d��2��O�c���i���|�v�j</param>
		/// <param name="stckTtl3TmBfBlAccPay">�d��3��O�c���i���|�v�j</param>
		/// <param name="monthAddUpExpDate">�����X�V���s�N����(YYYYMMDD�@�����X�V���s�N����)</param>
		/// <param name="stMonCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
		/// <param name="laMonCAddUpUpdDate">�O�񌎎��X�V�N����("YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����)</param>
		/// <param name="stockSlipCount">�d���`�[����(�d���`�[�����i�|�d���{�����d���j)</param>
		/// <param name="nonStmntAppearance">�����ϋ��z�i���U�j</param>
		/// <param name="nonStmntIsdone">�����ϋ��z�i�􂵁j</param>
		/// <param name="stmntAppearance">���ϋ��z�i���U�j</param>
		/// <param name="stmntIsdone">���ϋ��z�i�􂵁j</param>
		/// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h</param>
		/// <param name="supplierConsTaxRate">�d�������Őŗ�</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="addUpSecName">�v�㋒�_����</param>
		/// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
		/// <returns>SuplAccPay�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplAccPay(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string addUpSecCode,Int32 payeeCode,string payeeName,string payeeName2,string payeeSnm,Int32 customerCode,string customerName,string customerName2,string customerSnm,DateTime addUpDate,DateTime addUpYearMonth,Int64 lastTimeAccPay,Int64 thisTimeFeePayNrml,Int64 thisTimeDisPayNrml,Int64 thisTimePayNrml,Int64 thisTimeTtlBlcAcPay,Int64 ofsThisTimeSales,Int64 ofsThisSalesTax,Int64 itdedOffsetOutTax,Int64 itdedOffsetInTax,Int64 itdedOffsetTaxFree,Int64 offsetOutTax,Int64 offsetInTax,Int64 thisTimeStockPrice,Int64 thisStcPrcTax,Int64 ttlItdedStcOutTax,Int64 ttlItdedStcInTax,Int64 ttlItdedStcTaxFree,Int64 ttlStockOuterTax,Int64 ttlStockInnerTax,Int64 thisStckPricRgds,Int64 thisStcPrcTaxRgds,Int64 ttlItdedRetOutTax,Int64 ttlItdedRetInTax,Int64 ttlItdedRetTaxFree,Int64 ttlRetOuterTax,Int64 ttlRetInnerTax,Int64 thisStckPricDis,Int64 thisStcPrcTaxDis,Int64 ttlItdedDisOutTax,Int64 ttlItdedDisInTax,Int64 ttlItdedDisTaxFree,Int64 ttlDisOuterTax,Int64 ttlDisInnerTax,Int64 thisRecvOffset,Int64 thisRecvOffsetTax,Int64 thisRecvOutTax,Int64 thisRecvInTax,Int64 thisRecvTaxFree,Int64 thisRecvOuterTax,Int64 thisRecvInnerTax,Int64 taxAdjust,Int64 balanceAdjust,Int64 stckTtlAccPayBalance,Int64 stckTtl2TmBfBlAccPay,Int64 stckTtl3TmBfBlAccPay,DateTime monthAddUpExpDate,DateTime stMonCAddUpUpdDate,DateTime laMonCAddUpUpdDate,Int32 stockSlipCount,Int64 nonStmntAppearance,Int64 nonStmntIsdone,Int64 stmntAppearance,Int64 stmntIsdone,Int32 suppCTaxLayCd,Double supplierConsTaxRate,Int32 fractionProcCd,string enterpriseName,string updEmployeeName,string addUpSecName,string suppCTaxLayMethodNm)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._addUpSecCode = addUpSecCode;
			this._payeeCode = payeeCode;
			this._payeeName = payeeName;
			this._payeeName2 = payeeName2;
			this._payeeSnm = payeeSnm;
			this._customerCode = customerCode;
			this._customerName = customerName;
			this._customerName2 = customerName2;
			this._customerSnm = customerSnm;
			this.AddUpDate = addUpDate;
			this.AddUpYearMonth = addUpYearMonth;
			this._lastTimeAccPay = lastTimeAccPay;
			this._thisTimeFeePayNrml = thisTimeFeePayNrml;
			this._thisTimeDisPayNrml = thisTimeDisPayNrml;
			this._thisTimePayNrml = thisTimePayNrml;
			this._thisTimeTtlBlcAcPay = thisTimeTtlBlcAcPay;
			this._ofsThisTimeSales = ofsThisTimeSales;
			this._ofsThisSalesTax = ofsThisSalesTax;
			this._itdedOffsetOutTax = itdedOffsetOutTax;
			this._itdedOffsetInTax = itdedOffsetInTax;
			this._itdedOffsetTaxFree = itdedOffsetTaxFree;
			this._offsetOutTax = offsetOutTax;
			this._offsetInTax = offsetInTax;
			this._thisTimeStockPrice = thisTimeStockPrice;
			this._thisStcPrcTax = thisStcPrcTax;
			this._ttlItdedStcOutTax = ttlItdedStcOutTax;
			this._ttlItdedStcInTax = ttlItdedStcInTax;
			this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
			this._ttlStockOuterTax = ttlStockOuterTax;
			this._ttlStockInnerTax = ttlStockInnerTax;
			this._thisStckPricRgds = thisStckPricRgds;
			this._thisStcPrcTaxRgds = thisStcPrcTaxRgds;
			this._ttlItdedRetOutTax = ttlItdedRetOutTax;
			this._ttlItdedRetInTax = ttlItdedRetInTax;
			this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
			this._ttlRetOuterTax = ttlRetOuterTax;
			this._ttlRetInnerTax = ttlRetInnerTax;
			this._thisStckPricDis = thisStckPricDis;
			this._thisStcPrcTaxDis = thisStcPrcTaxDis;
			this._ttlItdedDisOutTax = ttlItdedDisOutTax;
			this._ttlItdedDisInTax = ttlItdedDisInTax;
			this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
			this._ttlDisOuterTax = ttlDisOuterTax;
			this._ttlDisInnerTax = ttlDisInnerTax;
			this._thisRecvOffset = thisRecvOffset;
			this._thisRecvOffsetTax = thisRecvOffsetTax;
			this._thisRecvOutTax = thisRecvOutTax;
			this._thisRecvInTax = thisRecvInTax;
			this._thisRecvTaxFree = thisRecvTaxFree;
			this._thisRecvOuterTax = thisRecvOuterTax;
			this._thisRecvInnerTax = thisRecvInnerTax;
			this._taxAdjust = taxAdjust;
			this._balanceAdjust = balanceAdjust;
			this._stckTtlAccPayBalance = stckTtlAccPayBalance;
			this._stckTtl2TmBfBlAccPay = stckTtl2TmBfBlAccPay;
			this._stckTtl3TmBfBlAccPay = stckTtl3TmBfBlAccPay;
			this.MonthAddUpExpDate = monthAddUpExpDate;
			this.StMonCAddUpUpdDate = stMonCAddUpUpdDate;
			this.LaMonCAddUpUpdDate = laMonCAddUpUpdDate;
			this._stockSlipCount = stockSlipCount;
			this._nonStmntAppearance = nonStmntAppearance;
			this._nonStmntIsdone = nonStmntIsdone;
			this._stmntAppearance = stmntAppearance;
			this._stmntIsdone = stmntIsdone;
			this._suppCTaxLayCd = suppCTaxLayCd;
			this._supplierConsTaxRate = supplierConsTaxRate;
			this._fractionProcCd = fractionProcCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._addUpSecName = addUpSecName;
			this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;

		}

		/// <summary>
		/// �d���攃�|���z�}�X�^��������
		/// </summary>
		/// <returns>SuplAccPay�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuplAccPay�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplAccPay Clone()
		{
			return new SuplAccPay(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._addUpSecCode,this._payeeCode,this._payeeName,this._payeeName2,this._payeeSnm,this._customerCode,this._customerName,this._customerName2,this._customerSnm,this._addUpDate,this._addUpYearMonth,this._lastTimeAccPay,this._thisTimeFeePayNrml,this._thisTimeDisPayNrml,this._thisTimePayNrml,this._thisTimeTtlBlcAcPay,this._ofsThisTimeSales,this._ofsThisSalesTax,this._itdedOffsetOutTax,this._itdedOffsetInTax,this._itdedOffsetTaxFree,this._offsetOutTax,this._offsetInTax,this._thisTimeStockPrice,this._thisStcPrcTax,this._ttlItdedStcOutTax,this._ttlItdedStcInTax,this._ttlItdedStcTaxFree,this._ttlStockOuterTax,this._ttlStockInnerTax,this._thisStckPricRgds,this._thisStcPrcTaxRgds,this._ttlItdedRetOutTax,this._ttlItdedRetInTax,this._ttlItdedRetTaxFree,this._ttlRetOuterTax,this._ttlRetInnerTax,this._thisStckPricDis,this._thisStcPrcTaxDis,this._ttlItdedDisOutTax,this._ttlItdedDisInTax,this._ttlItdedDisTaxFree,this._ttlDisOuterTax,this._ttlDisInnerTax,this._thisRecvOffset,this._thisRecvOffsetTax,this._thisRecvOutTax,this._thisRecvInTax,this._thisRecvTaxFree,this._thisRecvOuterTax,this._thisRecvInnerTax,this._taxAdjust,this._balanceAdjust,this._stckTtlAccPayBalance,this._stckTtl2TmBfBlAccPay,this._stckTtl3TmBfBlAccPay,this._monthAddUpExpDate,this._stMonCAddUpUpdDate,this._laMonCAddUpUpdDate,this._stockSlipCount,this._nonStmntAppearance,this._nonStmntIsdone,this._stmntAppearance,this._stmntIsdone,this._suppCTaxLayCd,this._supplierConsTaxRate,this._fractionProcCd,this._enterpriseName,this._updEmployeeName,this._addUpSecName,this._suppCTaxLayMethodNm);
		}

		/// <summary>
		/// �d���攃�|���z�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuplAccPay�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPay�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SuplAccPay target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.PayeeName == target.PayeeName)
				 && (this.PayeeName2 == target.PayeeName2)
				 && (this.PayeeSnm == target.PayeeSnm)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerName == target.CustomerName)
				 && (this.CustomerName2 == target.CustomerName2)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.AddUpDate == target.AddUpDate)
				 && (this.AddUpYearMonth == target.AddUpYearMonth)
				 && (this.LastTimeAccPay == target.LastTimeAccPay)
				 && (this.ThisTimeFeePayNrml == target.ThisTimeFeePayNrml)
				 && (this.ThisTimeDisPayNrml == target.ThisTimeDisPayNrml)
				 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
				 && (this.ThisTimeTtlBlcAcPay == target.ThisTimeTtlBlcAcPay)
				 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
				 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
				 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
				 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
				 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
				 && (this.OffsetOutTax == target.OffsetOutTax)
				 && (this.OffsetInTax == target.OffsetInTax)
				 && (this.ThisTimeStockPrice == target.ThisTimeStockPrice)
				 && (this.ThisStcPrcTax == target.ThisStcPrcTax)
				 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
				 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
				 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
				 && (this.TtlStockOuterTax == target.TtlStockOuterTax)
				 && (this.TtlStockInnerTax == target.TtlStockInnerTax)
				 && (this.ThisStckPricRgds == target.ThisStckPricRgds)
				 && (this.ThisStcPrcTaxRgds == target.ThisStcPrcTaxRgds)
				 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
				 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
				 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
				 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
				 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
				 && (this.ThisStckPricDis == target.ThisStckPricDis)
				 && (this.ThisStcPrcTaxDis == target.ThisStcPrcTaxDis)
				 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
				 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
				 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
				 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
				 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
				 && (this.ThisRecvOffset == target.ThisRecvOffset)
				 && (this.ThisRecvOffsetTax == target.ThisRecvOffsetTax)
				 && (this.ThisRecvOutTax == target.ThisRecvOutTax)
				 && (this.ThisRecvInTax == target.ThisRecvInTax)
				 && (this.ThisRecvTaxFree == target.ThisRecvTaxFree)
				 && (this.ThisRecvOuterTax == target.ThisRecvOuterTax)
				 && (this.ThisRecvInnerTax == target.ThisRecvInnerTax)
				 && (this.TaxAdjust == target.TaxAdjust)
				 && (this.BalanceAdjust == target.BalanceAdjust)
				 && (this.StckTtlAccPayBalance == target.StckTtlAccPayBalance)
				 && (this.StckTtl2TmBfBlAccPay == target.StckTtl2TmBfBlAccPay)
				 && (this.StckTtl3TmBfBlAccPay == target.StckTtl3TmBfBlAccPay)
				 && (this.MonthAddUpExpDate == target.MonthAddUpExpDate)
				 && (this.StMonCAddUpUpdDate == target.StMonCAddUpUpdDate)
				 && (this.LaMonCAddUpUpdDate == target.LaMonCAddUpUpdDate)
				 && (this.StockSlipCount == target.StockSlipCount)
				 && (this.NonStmntAppearance == target.NonStmntAppearance)
				 && (this.NonStmntIsdone == target.NonStmntIsdone)
				 && (this.StmntAppearance == target.StmntAppearance)
				 && (this.StmntIsdone == target.StmntIsdone)
				 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
				 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.AddUpSecName == target.AddUpSecName)
				 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm));
		}

		/// <summary>
		/// �d���攃�|���z�}�X�^��r����
		/// </summary>
		/// <param name="suplAccPay1">
		///                    ��r����SuplAccPay�N���X�̃C���X�^���X
		/// </param>
		/// <param name="suplAccPay2">��r����SuplAccPay�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPay�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SuplAccPay suplAccPay1, SuplAccPay suplAccPay2)
		{
			return ((suplAccPay1.CreateDateTime == suplAccPay2.CreateDateTime)
				 && (suplAccPay1.UpdateDateTime == suplAccPay2.UpdateDateTime)
				 && (suplAccPay1.EnterpriseCode == suplAccPay2.EnterpriseCode)
				 && (suplAccPay1.FileHeaderGuid == suplAccPay2.FileHeaderGuid)
				 && (suplAccPay1.UpdEmployeeCode == suplAccPay2.UpdEmployeeCode)
				 && (suplAccPay1.UpdAssemblyId1 == suplAccPay2.UpdAssemblyId1)
				 && (suplAccPay1.UpdAssemblyId2 == suplAccPay2.UpdAssemblyId2)
				 && (suplAccPay1.LogicalDeleteCode == suplAccPay2.LogicalDeleteCode)
				 && (suplAccPay1.AddUpSecCode == suplAccPay2.AddUpSecCode)
				 && (suplAccPay1.PayeeCode == suplAccPay2.PayeeCode)
				 && (suplAccPay1.PayeeName == suplAccPay2.PayeeName)
				 && (suplAccPay1.PayeeName2 == suplAccPay2.PayeeName2)
				 && (suplAccPay1.PayeeSnm == suplAccPay2.PayeeSnm)
				 && (suplAccPay1.CustomerCode == suplAccPay2.CustomerCode)
				 && (suplAccPay1.CustomerName == suplAccPay2.CustomerName)
				 && (suplAccPay1.CustomerName2 == suplAccPay2.CustomerName2)
				 && (suplAccPay1.CustomerSnm == suplAccPay2.CustomerSnm)
				 && (suplAccPay1.AddUpDate == suplAccPay2.AddUpDate)
				 && (suplAccPay1.AddUpYearMonth == suplAccPay2.AddUpYearMonth)
				 && (suplAccPay1.LastTimeAccPay == suplAccPay2.LastTimeAccPay)
				 && (suplAccPay1.ThisTimeFeePayNrml == suplAccPay2.ThisTimeFeePayNrml)
				 && (suplAccPay1.ThisTimeDisPayNrml == suplAccPay2.ThisTimeDisPayNrml)
				 && (suplAccPay1.ThisTimePayNrml == suplAccPay2.ThisTimePayNrml)
				 && (suplAccPay1.ThisTimeTtlBlcAcPay == suplAccPay2.ThisTimeTtlBlcAcPay)
				 && (suplAccPay1.OfsThisTimeSales == suplAccPay2.OfsThisTimeSales)
				 && (suplAccPay1.OfsThisSalesTax == suplAccPay2.OfsThisSalesTax)
				 && (suplAccPay1.ItdedOffsetOutTax == suplAccPay2.ItdedOffsetOutTax)
				 && (suplAccPay1.ItdedOffsetInTax == suplAccPay2.ItdedOffsetInTax)
				 && (suplAccPay1.ItdedOffsetTaxFree == suplAccPay2.ItdedOffsetTaxFree)
				 && (suplAccPay1.OffsetOutTax == suplAccPay2.OffsetOutTax)
				 && (suplAccPay1.OffsetInTax == suplAccPay2.OffsetInTax)
				 && (suplAccPay1.ThisTimeStockPrice == suplAccPay2.ThisTimeStockPrice)
				 && (suplAccPay1.ThisStcPrcTax == suplAccPay2.ThisStcPrcTax)
				 && (suplAccPay1.TtlItdedStcOutTax == suplAccPay2.TtlItdedStcOutTax)
				 && (suplAccPay1.TtlItdedStcInTax == suplAccPay2.TtlItdedStcInTax)
				 && (suplAccPay1.TtlItdedStcTaxFree == suplAccPay2.TtlItdedStcTaxFree)
				 && (suplAccPay1.TtlStockOuterTax == suplAccPay2.TtlStockOuterTax)
				 && (suplAccPay1.TtlStockInnerTax == suplAccPay2.TtlStockInnerTax)
				 && (suplAccPay1.ThisStckPricRgds == suplAccPay2.ThisStckPricRgds)
				 && (suplAccPay1.ThisStcPrcTaxRgds == suplAccPay2.ThisStcPrcTaxRgds)
				 && (suplAccPay1.TtlItdedRetOutTax == suplAccPay2.TtlItdedRetOutTax)
				 && (suplAccPay1.TtlItdedRetInTax == suplAccPay2.TtlItdedRetInTax)
				 && (suplAccPay1.TtlItdedRetTaxFree == suplAccPay2.TtlItdedRetTaxFree)
				 && (suplAccPay1.TtlRetOuterTax == suplAccPay2.TtlRetOuterTax)
				 && (suplAccPay1.TtlRetInnerTax == suplAccPay2.TtlRetInnerTax)
				 && (suplAccPay1.ThisStckPricDis == suplAccPay2.ThisStckPricDis)
				 && (suplAccPay1.ThisStcPrcTaxDis == suplAccPay2.ThisStcPrcTaxDis)
				 && (suplAccPay1.TtlItdedDisOutTax == suplAccPay2.TtlItdedDisOutTax)
				 && (suplAccPay1.TtlItdedDisInTax == suplAccPay2.TtlItdedDisInTax)
				 && (suplAccPay1.TtlItdedDisTaxFree == suplAccPay2.TtlItdedDisTaxFree)
				 && (suplAccPay1.TtlDisOuterTax == suplAccPay2.TtlDisOuterTax)
				 && (suplAccPay1.TtlDisInnerTax == suplAccPay2.TtlDisInnerTax)
				 && (suplAccPay1.ThisRecvOffset == suplAccPay2.ThisRecvOffset)
				 && (suplAccPay1.ThisRecvOffsetTax == suplAccPay2.ThisRecvOffsetTax)
				 && (suplAccPay1.ThisRecvOutTax == suplAccPay2.ThisRecvOutTax)
				 && (suplAccPay1.ThisRecvInTax == suplAccPay2.ThisRecvInTax)
				 && (suplAccPay1.ThisRecvTaxFree == suplAccPay2.ThisRecvTaxFree)
				 && (suplAccPay1.ThisRecvOuterTax == suplAccPay2.ThisRecvOuterTax)
				 && (suplAccPay1.ThisRecvInnerTax == suplAccPay2.ThisRecvInnerTax)
				 && (suplAccPay1.TaxAdjust == suplAccPay2.TaxAdjust)
				 && (suplAccPay1.BalanceAdjust == suplAccPay2.BalanceAdjust)
				 && (suplAccPay1.StckTtlAccPayBalance == suplAccPay2.StckTtlAccPayBalance)
				 && (suplAccPay1.StckTtl2TmBfBlAccPay == suplAccPay2.StckTtl2TmBfBlAccPay)
				 && (suplAccPay1.StckTtl3TmBfBlAccPay == suplAccPay2.StckTtl3TmBfBlAccPay)
				 && (suplAccPay1.MonthAddUpExpDate == suplAccPay2.MonthAddUpExpDate)
				 && (suplAccPay1.StMonCAddUpUpdDate == suplAccPay2.StMonCAddUpUpdDate)
				 && (suplAccPay1.LaMonCAddUpUpdDate == suplAccPay2.LaMonCAddUpUpdDate)
				 && (suplAccPay1.StockSlipCount == suplAccPay2.StockSlipCount)
				 && (suplAccPay1.NonStmntAppearance == suplAccPay2.NonStmntAppearance)
				 && (suplAccPay1.NonStmntIsdone == suplAccPay2.NonStmntIsdone)
				 && (suplAccPay1.StmntAppearance == suplAccPay2.StmntAppearance)
				 && (suplAccPay1.StmntIsdone == suplAccPay2.StmntIsdone)
				 && (suplAccPay1.SuppCTaxLayCd == suplAccPay2.SuppCTaxLayCd)
				 && (suplAccPay1.SupplierConsTaxRate == suplAccPay2.SupplierConsTaxRate)
				 && (suplAccPay1.FractionProcCd == suplAccPay2.FractionProcCd)
				 && (suplAccPay1.EnterpriseName == suplAccPay2.EnterpriseName)
				 && (suplAccPay1.UpdEmployeeName == suplAccPay2.UpdEmployeeName)
				 && (suplAccPay1.AddUpSecName == suplAccPay2.AddUpSecName)
				 && (suplAccPay1.SuppCTaxLayMethodNm == suplAccPay2.SuppCTaxLayMethodNm));
		}
		/// <summary>
		/// �d���攃�|���z�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuplAccPay�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPay�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SuplAccPay target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.PayeeName != target.PayeeName)resList.Add("PayeeName");
			if(this.PayeeName2 != target.PayeeName2)resList.Add("PayeeName2");
			if(this.PayeeSnm != target.PayeeSnm)resList.Add("PayeeSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerName != target.CustomerName)resList.Add("CustomerName");
			if(this.CustomerName2 != target.CustomerName2)resList.Add("CustomerName2");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.AddUpYearMonth != target.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(this.LastTimeAccPay != target.LastTimeAccPay)resList.Add("LastTimeAccPay");
			if(this.ThisTimeFeePayNrml != target.ThisTimeFeePayNrml)resList.Add("ThisTimeFeePayNrml");
			if(this.ThisTimeDisPayNrml != target.ThisTimeDisPayNrml)resList.Add("ThisTimeDisPayNrml");
			if(this.ThisTimePayNrml != target.ThisTimePayNrml)resList.Add("ThisTimePayNrml");
			if(this.ThisTimeTtlBlcAcPay != target.ThisTimeTtlBlcAcPay)resList.Add("ThisTimeTtlBlcAcPay");
			if(this.OfsThisTimeSales != target.OfsThisTimeSales)resList.Add("OfsThisTimeSales");
			if(this.OfsThisSalesTax != target.OfsThisSalesTax)resList.Add("OfsThisSalesTax");
			if(this.ItdedOffsetOutTax != target.ItdedOffsetOutTax)resList.Add("ItdedOffsetOutTax");
			if(this.ItdedOffsetInTax != target.ItdedOffsetInTax)resList.Add("ItdedOffsetInTax");
			if(this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree)resList.Add("ItdedOffsetTaxFree");
			if(this.OffsetOutTax != target.OffsetOutTax)resList.Add("OffsetOutTax");
			if(this.OffsetInTax != target.OffsetInTax)resList.Add("OffsetInTax");
			if(this.ThisTimeStockPrice != target.ThisTimeStockPrice)resList.Add("ThisTimeStockPrice");
			if(this.ThisStcPrcTax != target.ThisStcPrcTax)resList.Add("ThisStcPrcTax");
			if(this.TtlItdedStcOutTax != target.TtlItdedStcOutTax)resList.Add("TtlItdedStcOutTax");
			if(this.TtlItdedStcInTax != target.TtlItdedStcInTax)resList.Add("TtlItdedStcInTax");
			if(this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree)resList.Add("TtlItdedStcTaxFree");
			if(this.TtlStockOuterTax != target.TtlStockOuterTax)resList.Add("TtlStockOuterTax");
			if(this.TtlStockInnerTax != target.TtlStockInnerTax)resList.Add("TtlStockInnerTax");
			if(this.ThisStckPricRgds != target.ThisStckPricRgds)resList.Add("ThisStckPricRgds");
			if(this.ThisStcPrcTaxRgds != target.ThisStcPrcTaxRgds)resList.Add("ThisStcPrcTaxRgds");
			if(this.TtlItdedRetOutTax != target.TtlItdedRetOutTax)resList.Add("TtlItdedRetOutTax");
			if(this.TtlItdedRetInTax != target.TtlItdedRetInTax)resList.Add("TtlItdedRetInTax");
			if(this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree)resList.Add("TtlItdedRetTaxFree");
			if(this.TtlRetOuterTax != target.TtlRetOuterTax)resList.Add("TtlRetOuterTax");
			if(this.TtlRetInnerTax != target.TtlRetInnerTax)resList.Add("TtlRetInnerTax");
			if(this.ThisStckPricDis != target.ThisStckPricDis)resList.Add("ThisStckPricDis");
			if(this.ThisStcPrcTaxDis != target.ThisStcPrcTaxDis)resList.Add("ThisStcPrcTaxDis");
			if(this.TtlItdedDisOutTax != target.TtlItdedDisOutTax)resList.Add("TtlItdedDisOutTax");
			if(this.TtlItdedDisInTax != target.TtlItdedDisInTax)resList.Add("TtlItdedDisInTax");
			if(this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree)resList.Add("TtlItdedDisTaxFree");
			if(this.TtlDisOuterTax != target.TtlDisOuterTax)resList.Add("TtlDisOuterTax");
			if(this.TtlDisInnerTax != target.TtlDisInnerTax)resList.Add("TtlDisInnerTax");
			if(this.ThisRecvOffset != target.ThisRecvOffset)resList.Add("ThisRecvOffset");
			if(this.ThisRecvOffsetTax != target.ThisRecvOffsetTax)resList.Add("ThisRecvOffsetTax");
			if(this.ThisRecvOutTax != target.ThisRecvOutTax)resList.Add("ThisRecvOutTax");
			if(this.ThisRecvInTax != target.ThisRecvInTax)resList.Add("ThisRecvInTax");
			if(this.ThisRecvTaxFree != target.ThisRecvTaxFree)resList.Add("ThisRecvTaxFree");
			if(this.ThisRecvOuterTax != target.ThisRecvOuterTax)resList.Add("ThisRecvOuterTax");
			if(this.ThisRecvInnerTax != target.ThisRecvInnerTax)resList.Add("ThisRecvInnerTax");
			if(this.TaxAdjust != target.TaxAdjust)resList.Add("TaxAdjust");
			if(this.BalanceAdjust != target.BalanceAdjust)resList.Add("BalanceAdjust");
			if(this.StckTtlAccPayBalance != target.StckTtlAccPayBalance)resList.Add("StckTtlAccPayBalance");
			if(this.StckTtl2TmBfBlAccPay != target.StckTtl2TmBfBlAccPay)resList.Add("StckTtl2TmBfBlAccPay");
			if(this.StckTtl3TmBfBlAccPay != target.StckTtl3TmBfBlAccPay)resList.Add("StckTtl3TmBfBlAccPay");
			if(this.MonthAddUpExpDate != target.MonthAddUpExpDate)resList.Add("MonthAddUpExpDate");
			if(this.StMonCAddUpUpdDate != target.StMonCAddUpUpdDate)resList.Add("StMonCAddUpUpdDate");
			if(this.LaMonCAddUpUpdDate != target.LaMonCAddUpUpdDate)resList.Add("LaMonCAddUpUpdDate");
			if(this.StockSlipCount != target.StockSlipCount)resList.Add("StockSlipCount");
			if(this.NonStmntAppearance != target.NonStmntAppearance)resList.Add("NonStmntAppearance");
			if(this.NonStmntIsdone != target.NonStmntIsdone)resList.Add("NonStmntIsdone");
			if(this.StmntAppearance != target.StmntAppearance)resList.Add("StmntAppearance");
			if(this.StmntIsdone != target.StmntIsdone)resList.Add("StmntIsdone");
			if(this.SuppCTaxLayCd != target.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(this.SupplierConsTaxRate != target.SupplierConsTaxRate)resList.Add("SupplierConsTaxRate");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");
			if(this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
		}

		/// <summary>
		/// �d���攃�|���z�}�X�^��r����
		/// </summary>
		/// <param name="suplAccPay1">��r����SuplAccPay�N���X�̃C���X�^���X</param>
		/// <param name="suplAccPay2">��r����SuplAccPay�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccPay�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SuplAccPay suplAccPay1, SuplAccPay suplAccPay2)
		{
			ArrayList resList = new ArrayList();
			if(suplAccPay1.CreateDateTime != suplAccPay2.CreateDateTime)resList.Add("CreateDateTime");
			if(suplAccPay1.UpdateDateTime != suplAccPay2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(suplAccPay1.EnterpriseCode != suplAccPay2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suplAccPay1.FileHeaderGuid != suplAccPay2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(suplAccPay1.UpdEmployeeCode != suplAccPay2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(suplAccPay1.UpdAssemblyId1 != suplAccPay2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(suplAccPay1.UpdAssemblyId2 != suplAccPay2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(suplAccPay1.LogicalDeleteCode != suplAccPay2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(suplAccPay1.AddUpSecCode != suplAccPay2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(suplAccPay1.PayeeCode != suplAccPay2.PayeeCode)resList.Add("PayeeCode");
			if(suplAccPay1.PayeeName != suplAccPay2.PayeeName)resList.Add("PayeeName");
			if(suplAccPay1.PayeeName2 != suplAccPay2.PayeeName2)resList.Add("PayeeName2");
			if(suplAccPay1.PayeeSnm != suplAccPay2.PayeeSnm)resList.Add("PayeeSnm");
			if(suplAccPay1.CustomerCode != suplAccPay2.CustomerCode)resList.Add("CustomerCode");
			if(suplAccPay1.CustomerName != suplAccPay2.CustomerName)resList.Add("CustomerName");
			if(suplAccPay1.CustomerName2 != suplAccPay2.CustomerName2)resList.Add("CustomerName2");
			if(suplAccPay1.CustomerSnm != suplAccPay2.CustomerSnm)resList.Add("CustomerSnm");
			if(suplAccPay1.AddUpDate != suplAccPay2.AddUpDate)resList.Add("AddUpDate");
			if(suplAccPay1.AddUpYearMonth != suplAccPay2.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(suplAccPay1.LastTimeAccPay != suplAccPay2.LastTimeAccPay)resList.Add("LastTimeAccPay");
			if(suplAccPay1.ThisTimeFeePayNrml != suplAccPay2.ThisTimeFeePayNrml)resList.Add("ThisTimeFeePayNrml");
			if(suplAccPay1.ThisTimeDisPayNrml != suplAccPay2.ThisTimeDisPayNrml)resList.Add("ThisTimeDisPayNrml");
			if(suplAccPay1.ThisTimePayNrml != suplAccPay2.ThisTimePayNrml)resList.Add("ThisTimePayNrml");
			if(suplAccPay1.ThisTimeTtlBlcAcPay != suplAccPay2.ThisTimeTtlBlcAcPay)resList.Add("ThisTimeTtlBlcAcPay");
			if(suplAccPay1.OfsThisTimeSales != suplAccPay2.OfsThisTimeSales)resList.Add("OfsThisTimeSales");
			if(suplAccPay1.OfsThisSalesTax != suplAccPay2.OfsThisSalesTax)resList.Add("OfsThisSalesTax");
			if(suplAccPay1.ItdedOffsetOutTax != suplAccPay2.ItdedOffsetOutTax)resList.Add("ItdedOffsetOutTax");
			if(suplAccPay1.ItdedOffsetInTax != suplAccPay2.ItdedOffsetInTax)resList.Add("ItdedOffsetInTax");
			if(suplAccPay1.ItdedOffsetTaxFree != suplAccPay2.ItdedOffsetTaxFree)resList.Add("ItdedOffsetTaxFree");
			if(suplAccPay1.OffsetOutTax != suplAccPay2.OffsetOutTax)resList.Add("OffsetOutTax");
			if(suplAccPay1.OffsetInTax != suplAccPay2.OffsetInTax)resList.Add("OffsetInTax");
			if(suplAccPay1.ThisTimeStockPrice != suplAccPay2.ThisTimeStockPrice)resList.Add("ThisTimeStockPrice");
			if(suplAccPay1.ThisStcPrcTax != suplAccPay2.ThisStcPrcTax)resList.Add("ThisStcPrcTax");
			if(suplAccPay1.TtlItdedStcOutTax != suplAccPay2.TtlItdedStcOutTax)resList.Add("TtlItdedStcOutTax");
			if(suplAccPay1.TtlItdedStcInTax != suplAccPay2.TtlItdedStcInTax)resList.Add("TtlItdedStcInTax");
			if(suplAccPay1.TtlItdedStcTaxFree != suplAccPay2.TtlItdedStcTaxFree)resList.Add("TtlItdedStcTaxFree");
			if(suplAccPay1.TtlStockOuterTax != suplAccPay2.TtlStockOuterTax)resList.Add("TtlStockOuterTax");
			if(suplAccPay1.TtlStockInnerTax != suplAccPay2.TtlStockInnerTax)resList.Add("TtlStockInnerTax");
			if(suplAccPay1.ThisStckPricRgds != suplAccPay2.ThisStckPricRgds)resList.Add("ThisStckPricRgds");
			if(suplAccPay1.ThisStcPrcTaxRgds != suplAccPay2.ThisStcPrcTaxRgds)resList.Add("ThisStcPrcTaxRgds");
			if(suplAccPay1.TtlItdedRetOutTax != suplAccPay2.TtlItdedRetOutTax)resList.Add("TtlItdedRetOutTax");
			if(suplAccPay1.TtlItdedRetInTax != suplAccPay2.TtlItdedRetInTax)resList.Add("TtlItdedRetInTax");
			if(suplAccPay1.TtlItdedRetTaxFree != suplAccPay2.TtlItdedRetTaxFree)resList.Add("TtlItdedRetTaxFree");
			if(suplAccPay1.TtlRetOuterTax != suplAccPay2.TtlRetOuterTax)resList.Add("TtlRetOuterTax");
			if(suplAccPay1.TtlRetInnerTax != suplAccPay2.TtlRetInnerTax)resList.Add("TtlRetInnerTax");
			if(suplAccPay1.ThisStckPricDis != suplAccPay2.ThisStckPricDis)resList.Add("ThisStckPricDis");
			if(suplAccPay1.ThisStcPrcTaxDis != suplAccPay2.ThisStcPrcTaxDis)resList.Add("ThisStcPrcTaxDis");
			if(suplAccPay1.TtlItdedDisOutTax != suplAccPay2.TtlItdedDisOutTax)resList.Add("TtlItdedDisOutTax");
			if(suplAccPay1.TtlItdedDisInTax != suplAccPay2.TtlItdedDisInTax)resList.Add("TtlItdedDisInTax");
			if(suplAccPay1.TtlItdedDisTaxFree != suplAccPay2.TtlItdedDisTaxFree)resList.Add("TtlItdedDisTaxFree");
			if(suplAccPay1.TtlDisOuterTax != suplAccPay2.TtlDisOuterTax)resList.Add("TtlDisOuterTax");
			if(suplAccPay1.TtlDisInnerTax != suplAccPay2.TtlDisInnerTax)resList.Add("TtlDisInnerTax");
			if(suplAccPay1.ThisRecvOffset != suplAccPay2.ThisRecvOffset)resList.Add("ThisRecvOffset");
			if(suplAccPay1.ThisRecvOffsetTax != suplAccPay2.ThisRecvOffsetTax)resList.Add("ThisRecvOffsetTax");
			if(suplAccPay1.ThisRecvOutTax != suplAccPay2.ThisRecvOutTax)resList.Add("ThisRecvOutTax");
			if(suplAccPay1.ThisRecvInTax != suplAccPay2.ThisRecvInTax)resList.Add("ThisRecvInTax");
			if(suplAccPay1.ThisRecvTaxFree != suplAccPay2.ThisRecvTaxFree)resList.Add("ThisRecvTaxFree");
			if(suplAccPay1.ThisRecvOuterTax != suplAccPay2.ThisRecvOuterTax)resList.Add("ThisRecvOuterTax");
			if(suplAccPay1.ThisRecvInnerTax != suplAccPay2.ThisRecvInnerTax)resList.Add("ThisRecvInnerTax");
			if(suplAccPay1.TaxAdjust != suplAccPay2.TaxAdjust)resList.Add("TaxAdjust");
			if(suplAccPay1.BalanceAdjust != suplAccPay2.BalanceAdjust)resList.Add("BalanceAdjust");
			if(suplAccPay1.StckTtlAccPayBalance != suplAccPay2.StckTtlAccPayBalance)resList.Add("StckTtlAccPayBalance");
			if(suplAccPay1.StckTtl2TmBfBlAccPay != suplAccPay2.StckTtl2TmBfBlAccPay)resList.Add("StckTtl2TmBfBlAccPay");
			if(suplAccPay1.StckTtl3TmBfBlAccPay != suplAccPay2.StckTtl3TmBfBlAccPay)resList.Add("StckTtl3TmBfBlAccPay");
			if(suplAccPay1.MonthAddUpExpDate != suplAccPay2.MonthAddUpExpDate)resList.Add("MonthAddUpExpDate");
			if(suplAccPay1.StMonCAddUpUpdDate != suplAccPay2.StMonCAddUpUpdDate)resList.Add("StMonCAddUpUpdDate");
			if(suplAccPay1.LaMonCAddUpUpdDate != suplAccPay2.LaMonCAddUpUpdDate)resList.Add("LaMonCAddUpUpdDate");
			if(suplAccPay1.StockSlipCount != suplAccPay2.StockSlipCount)resList.Add("StockSlipCount");
			if(suplAccPay1.NonStmntAppearance != suplAccPay2.NonStmntAppearance)resList.Add("NonStmntAppearance");
			if(suplAccPay1.NonStmntIsdone != suplAccPay2.NonStmntIsdone)resList.Add("NonStmntIsdone");
			if(suplAccPay1.StmntAppearance != suplAccPay2.StmntAppearance)resList.Add("StmntAppearance");
			if(suplAccPay1.StmntIsdone != suplAccPay2.StmntIsdone)resList.Add("StmntIsdone");
			if(suplAccPay1.SuppCTaxLayCd != suplAccPay2.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(suplAccPay1.SupplierConsTaxRate != suplAccPay2.SupplierConsTaxRate)resList.Add("SupplierConsTaxRate");
			if(suplAccPay1.FractionProcCd != suplAccPay2.FractionProcCd)resList.Add("FractionProcCd");
			if(suplAccPay1.EnterpriseName != suplAccPay2.EnterpriseName)resList.Add("EnterpriseName");
			if(suplAccPay1.UpdEmployeeName != suplAccPay2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(suplAccPay1.AddUpSecName != suplAccPay2.AddUpSecName)resList.Add("AddUpSecName");
			if(suplAccPay1.SuppCTaxLayMethodNm != suplAccPay2.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
		}
	}
}

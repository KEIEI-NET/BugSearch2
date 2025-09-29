using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustAccRec
	/// <summary>
	///                      ���Ӑ攄�|���z�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ攄�|���z�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/06/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustAccRec
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

		/// <summary>������R�[�h</summary>
		/// <remarks>������e�R�[�h</remarks>
		private Int32 _claimCode;

		/// <summary>�����於��</summary>
		private string _claimName = "";

		/// <summary>�����於��2</summary>
		private string _claimName2 = "";

		/// <summary>�����旪��</summary>
		private string _claimSnm = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ於��</summary>
		private string _customerName = "";

		/// <summary>���Ӑ於��2</summary>
		private string _customerName2 = "";

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</remarks>
		private DateTime _addUpDate;

		/// <summary>�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�O�񔄊|���z</summary>
		private Int64 _lastTimeAccRec;

		/// <summary>����萔���z�i�ʏ�����j</summary>
		private Int64 _thisTimeFeeDmdNrml;

		/// <summary>����l���z�i�ʏ�����j</summary>
		private Int64 _thisTimeDisDmdNrml;

		/// <summary>����������z�i�ʏ�����j</summary>
		/// <remarks>�����z�̍��v���z</remarks>
		private Int64 _thisTimeDmdNrml;

		/// <summary>����J�z�c���i���|�v�j</summary>
		/// <remarks>����J�z�c�����O�񔄊|���z�|��������z���v�i�ʏ�����j</remarks>
		private Int64 _thisTimeTtlBlcAcc;

		/// <summary>���E�㍡�񔄏���z</summary>
		/// <remarks>���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�</remarks>
		private Int64 _ofsThisTimeSales;

		/// <summary>���E�㍡�񔄏�����</summary>
		/// <remarks>���E����</remarks>
		private Int64 _ofsThisSalesTax;

		/// <summary>���E��O�őΏۊz</summary>
		/// <remarks>���E���ʁF�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedOffsetOutTax;

		/// <summary>���E����őΏۊz</summary>
		/// <remarks>���E���ʁF���Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedOffsetInTax;

		/// <summary>���E���ېőΏۊz</summary>
		/// <remarks>���E���ʁF��ېŊz�̏W�v</remarks>
		private Int64 _itdedOffsetTaxFree;

		/// <summary>���E��O�ŏ����</summary>
		/// <remarks>���E���ʁF�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
		private Int64 _offsetOutTax;

		/// <summary>���E����ŏ����</summary>
		/// <remarks>���E���ʁF���ŏ���ł̏W�v</remarks>
		private Int64 _offsetInTax;

		/// <summary>���񔄏���z</summary>
		/// <remarks>�����p�F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
		private Int64 _thisTimeSales;

		/// <summary>���񔄏�����</summary>
		/// <remarks>�����p</remarks>
		private Int64 _thisSalesTax;

		/// <summary>����O�őΏۊz</summary>
		/// <remarks>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedSalesOutTax;

		/// <summary>������őΏۊz</summary>
		/// <remarks>�����p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedSalesInTax;

		/// <summary>�����ېőΏۊz</summary>
		/// <remarks>�����p�F��ېŊz�̏W�v</remarks>
		private Int64 _itdedSalesTaxFree;

		/// <summary>����O�Ŋz</summary>
		/// <remarks>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
		private Int64 _salesOutTax;

		/// <summary>������Ŋz</summary>
		/// <remarks>�����p�F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</remarks>
		private Int64 _salesInTax;

		/// <summary>���񔄏�ԕi���z</summary>
		/// <remarks>�ԕi�p�F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
		private Int64 _thisSalesPricRgds;

		/// <summary>���񔄏�ԕi�����</summary>
		/// <remarks>�ԕi�p�F�ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
		private Int64 _thisSalesPrcTaxRgds;

		/// <summary>�ԕi�O�őΏۊz���v</summary>
		/// <remarks>�ԕi�p</remarks>
		private Int64 _ttlItdedRetOutTax;

		/// <summary>�ԕi���őΏۊz���v</summary>
		/// <remarks>�ԕi�p</remarks>
		private Int64 _ttlItdedRetInTax;

		/// <summary>�ԕi��ېőΏۊz���v</summary>
		/// <remarks>�ԕi�p</remarks>
		private Int64 _ttlItdedRetTaxFree;

		/// <summary>�ԕi�O�Ŋz���v</summary>
		/// <remarks>�ԕi�p</remarks>
		private Int64 _ttlRetOuterTax;

		/// <summary>�ԕi���Ŋz���v</summary>
		/// <remarks>�ԕi�p�F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>���񔄏�l�����z</summary>
		/// <remarks>�l���p�F�Ŕ����̔���l�����z</remarks>
		private Int64 _thisSalesPricDis;

		/// <summary>���񔄏�l�������</summary>
		/// <remarks>�l���p�F�l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
		private Int64 _thisSalesPrcTaxDis;

		/// <summary>�l���O�őΏۊz���v</summary>
		/// <remarks>�l���p</remarks>
		private Int64 _ttlItdedDisOutTax;

		/// <summary>�l�����őΏۊz���v</summary>
		/// <remarks>�l���p</remarks>
		private Int64 _ttlItdedDisInTax;

		/// <summary>�l����ېőΏۊz���v</summary>
		/// <remarks>�l���p</remarks>
		private Int64 _ttlItdedDisTaxFree;

		/// <summary>�l���O�Ŋz���v</summary>
		/// <remarks>�l���p</remarks>
		private Int64 _ttlDisOuterTax;

		/// <summary>�l�����Ŋz���v</summary>
		/// <remarks>�l���p�F���ŏ��i�ԕi�̓��ŏ���Ŋz</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>�v�Z�㓖�����|���z</summary>
		/// <remarks>�������̔��|���z
        /// �J�z�z�{���񏃔�����z�{���񏃔������Ł{����Œ����z�{�c�������z</remarks>
		private Int64 _afCalTMonthAccRec;

		/// <summary>��2��O�c���i���|�v�j</summary>
		private Int64 _acpOdrTtl2TmBfAccRec;

		/// <summary>��3��O�c���i���|�v�j</summary>
		private Int64 _acpOdrTtl3TmBfAccRec;

		/// <summary>�����X�V���s�N����</summary>
		/// <remarks>YYYYMMDD�@�����X�V���s�N����</remarks>
		private DateTime _monthAddUpExpDate;

		/// <summary>�����X�V�J�n�N����</summary>
		/// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
		private DateTime _stMonCAddUpUpdDate;

		/// <summary>�O�񌎎��X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</remarks>
		private DateTime _laMonCAddUpUpdDate;

		/// <summary>����`�[����</summary>
		/// <remarks>����`�[�����i�|����{��������j</remarks>
		private Int32 _salesSlipCount;

		/// <summary>����œ]�ŕ���</summary>
		/// <remarks>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>����ŗ�</summary>
		/// <remarks>�ύX2007/8/22(�^,��) ����</remarks>
		private Double _consTaxRate;

		/// <summary>�[�������敪</summary>
		private Int32 _fractionProcCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";


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

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
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
		/// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
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
		/// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
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
		/// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
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
		/// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
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
		/// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
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

		/// public propaty name  :  ThisTimeDmdNrml
		/// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
		/// <value>�����z�̍��v���z</value>
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
		/// <value>���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�</value>
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

		/// public propaty name  :  ItdedOffsetOutTax
		/// <summary>���E��O�őΏۊz�v���p�e�B</summary>
		/// <value>���E���ʁF�O�Ŋz�i�Ŕ����j�̏W�v</value>
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
		/// <value>���E���ʁF���Ŋz�i�Ŕ����j�̏W�v</value>
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
		/// <value>���E���ʁF��ېŊz�̏W�v</value>
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
		/// <value>���E���ʁF�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
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
		/// <value>���E���ʁF���ŏ���ł̏W�v</value>
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

		/// public propaty name  :  ItdedSalesOutTax
		/// <summary>����O�őΏۊz�v���p�e�B</summary>
		/// <value>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedSalesOutTax
		{
			get{return _itdedSalesOutTax;}
			set{_itdedSalesOutTax = value;}
		}

		/// public propaty name  :  ItdedSalesInTax
		/// <summary>������őΏۊz�v���p�e�B</summary>
		/// <value>�����p�F���Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedSalesInTax
		{
			get{return _itdedSalesInTax;}
			set{_itdedSalesInTax = value;}
		}

		/// public propaty name  :  ItdedSalesTaxFree
		/// <summary>�����ېőΏۊz�v���p�e�B</summary>
		/// <value>�����p�F��ېŊz�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ېőΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedSalesTaxFree
		{
			get{return _itdedSalesTaxFree;}
			set{_itdedSalesTaxFree = value;}
		}

		/// public propaty name  :  SalesOutTax
		/// <summary>����O�Ŋz�v���p�e�B</summary>
		/// <value>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����O�Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesOutTax
		{
			get{return _salesOutTax;}
			set{_salesOutTax = value;}
		}

		/// public propaty name  :  SalesInTax
		/// <summary>������Ŋz�v���p�e�B</summary>
		/// <value>�����p�F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesInTax
		{
			get{return _salesInTax;}
			set{_salesInTax = value;}
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

		/// public propaty name  :  TtlItdedRetOutTax
		/// <summary>�ԕi�O�őΏۊz���v�v���p�e�B</summary>
		/// <value>�ԕi�p</value>
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
		/// <value>�ԕi�p</value>
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
		/// <value>�ԕi�p</value>
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
		/// <value>�ԕi�p</value>
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
		/// <value>�ԕi�p�F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
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

		/// public propaty name  :  TtlItdedDisOutTax
		/// <summary>�l���O�őΏۊz���v�v���p�e�B</summary>
		/// <value>�l���p</value>
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
		/// <value>�l���p</value>
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
		/// <value>�l���p</value>
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
		/// <value>�l���p</value>
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
		/// <value>�l���p�F���ŏ��i�ԕi�̓��ŏ���Ŋz</value>
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

		/// public propaty name  :  AfCalTMonthAccRec
		/// <summary>�v�Z�㓖�����|���z�v���p�e�B</summary>
		/// <value>�������̔��|���z
        /// �J�z�z�{���񏃔�����z�{���񏃔������Ł{����Œ����z�{�c�������z</value>
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

		/// public propaty name  :  SalesSlipCount
		/// <summary>����`�[�����v���p�e�B</summary>
		/// <value>����`�[�����i�|����{��������j</value>
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

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>����œ]�ŕ����v���p�e�B</summary>
		/// <value>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get{return _consTaxLayMethod;}
			set{_consTaxLayMethod = value;}
		}

		/// public propaty name  :  ConsTaxRate
		/// <summary>����ŗ��v���p�e�B</summary>
		/// <value>�ύX2007/8/22(�^,��) ����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ConsTaxRate
		{
			get{return _consTaxRate;}
			set{_consTaxRate = value;}
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


		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>CustAccRec�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustAccRec�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustAccRec()
		{
		}

		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^�R���X�g���N�^
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
		/// <param name="claimCode">������R�[�h(������e�R�[�h)</param>
		/// <param name="claimName">�����於��</param>
		/// <param name="claimName2">�����於��2</param>
		/// <param name="claimSnm">�����旪��</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerName">���Ӑ於��</param>
		/// <param name="customerName2">���Ӑ於��2</param>
		/// <param name="customerSnm">���Ӑ旪��</param>
		/// <param name="addUpDate">�v��N����(YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j)</param>
		/// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
		/// <param name="lastTimeAccRec">�O�񔄊|���z</param>
		/// <param name="thisTimeFeeDmdNrml">����萔���z�i�ʏ�����j</param>
		/// <param name="thisTimeDisDmdNrml">����l���z�i�ʏ�����j</param>
		/// <param name="thisTimeDmdNrml">����������z�i�ʏ�����j(�����z�̍��v���z)</param>
		/// <param name="thisTimeTtlBlcAcc">����J�z�c���i���|�v�j(����J�z�c�����O�񔄊|���z�|��������z���v�i�ʏ�����j)</param>
		/// <param name="ofsThisTimeSales">���E�㍡�񔄏���z(���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�)</param>
		/// <param name="ofsThisSalesTax">���E�㍡�񔄏�����(���E����)</param>
		/// <param name="itdedOffsetOutTax">���E��O�őΏۊz(���E���ʁF�O�Ŋz�i�Ŕ����j�̏W�v)</param>
		/// <param name="itdedOffsetInTax">���E����őΏۊz(���E���ʁF���Ŋz�i�Ŕ����j�̏W�v)</param>
		/// <param name="itdedOffsetTaxFree">���E���ېőΏۊz(���E���ʁF��ېŊz�̏W�v)</param>
		/// <param name="offsetOutTax">���E��O�ŏ����(���E���ʁF�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
		/// <param name="offsetInTax">���E����ŏ����(���E���ʁF���ŏ���ł̏W�v)</param>
		/// <param name="thisTimeSales">���񔄏���z(�����p�F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z)</param>
		/// <param name="thisSalesTax">���񔄏�����(�����p)</param>
		/// <param name="itdedSalesOutTax">����O�őΏۊz(�����p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
		/// <param name="itdedSalesInTax">������őΏۊz(�����p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
		/// <param name="itdedSalesTaxFree">�����ېőΏۊz(�����p�F��ېŊz�̏W�v)</param>
		/// <param name="salesOutTax">����O�Ŋz(�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
		/// <param name="salesInTax">������Ŋz(�����p�F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j)</param>
		/// <param name="thisSalesPricRgds">���񔄏�ԕi���z(�ԕi�p�F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z)</param>
		/// <param name="thisSalesPrcTaxRgds">���񔄏�ԕi�����(�ԕi�p�F�ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
		/// <param name="ttlItdedRetOutTax">�ԕi�O�őΏۊz���v(�ԕi�p)</param>
		/// <param name="ttlItdedRetInTax">�ԕi���őΏۊz���v(�ԕi�p)</param>
		/// <param name="ttlItdedRetTaxFree">�ԕi��ېőΏۊz���v(�ԕi�p)</param>
		/// <param name="ttlRetOuterTax">�ԕi�O�Ŋz���v(�ԕi�p)</param>
		/// <param name="ttlRetInnerTax">�ԕi���Ŋz���v(�ԕi�p�F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j)</param>
		/// <param name="thisSalesPricDis">���񔄏�l�����z(�l���p�F�Ŕ����̔���l�����z)</param>
		/// <param name="thisSalesPrcTaxDis">���񔄏�l�������(�l���p�F�l���O�Ŋz���v�{�l�����Ŋz���v)</param>
		/// <param name="ttlItdedDisOutTax">�l���O�őΏۊz���v(�l���p)</param>
		/// <param name="ttlItdedDisInTax">�l�����őΏۊz���v(�l���p)</param>
		/// <param name="ttlItdedDisTaxFree">�l����ېőΏۊz���v(�l���p)</param>
		/// <param name="ttlDisOuterTax">�l���O�Ŋz���v(�l���p)</param>
		/// <param name="ttlDisInnerTax">�l�����Ŋz���v(�l���p�F���ŏ��i�ԕi�̓��ŏ���Ŋz)</param>
		/// <param name="taxAdjust">����Œ����z</param>
		/// <param name="balanceAdjust">�c�������z</param>
		/// <param name="afCalTMonthAccRec">�v�Z�㓖�����|���z(�������̔��|���z
        /// �J�z�z�{���񏃔�����z�{���񏃔������Ł{����Œ����z�{�c�������z)</param>
		/// <param name="acpOdrTtl2TmBfAccRec">��2��O�c���i���|�v�j</param>
		/// <param name="acpOdrTtl3TmBfAccRec">��3��O�c���i���|�v�j</param>
		/// <param name="monthAddUpExpDate">�����X�V���s�N����(YYYYMMDD�@�����X�V���s�N����)</param>
		/// <param name="stMonCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
		/// <param name="laMonCAddUpUpdDate">�O�񌎎��X�V�N����("YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����)</param>
		/// <param name="salesSlipCount">����`�[����(����`�[�����i�|����{��������j)</param>
		/// <param name="consTaxLayMethod">����œ]�ŕ���(����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ)</param>
		/// <param name="consTaxRate">����ŗ�(�ύX2007/8/22(�^,��) ����)</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="addUpSecName">�v�㋒�_����</param>
		/// <returns>CustAccRec�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustAccRec�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustAccRec(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string addUpSecCode,Int32 claimCode,string claimName,string claimName2,string claimSnm,Int32 customerCode,string customerName,string customerName2,string customerSnm,DateTime addUpDate,DateTime addUpYearMonth,Int64 lastTimeAccRec,Int64 thisTimeFeeDmdNrml,Int64 thisTimeDisDmdNrml,Int64 thisTimeDmdNrml,Int64 thisTimeTtlBlcAcc,Int64 ofsThisTimeSales,Int64 ofsThisSalesTax,Int64 itdedOffsetOutTax,Int64 itdedOffsetInTax,Int64 itdedOffsetTaxFree,Int64 offsetOutTax,Int64 offsetInTax,Int64 thisTimeSales,Int64 thisSalesTax,Int64 itdedSalesOutTax,Int64 itdedSalesInTax,Int64 itdedSalesTaxFree,Int64 salesOutTax,Int64 salesInTax,Int64 thisSalesPricRgds,Int64 thisSalesPrcTaxRgds,Int64 ttlItdedRetOutTax,Int64 ttlItdedRetInTax,Int64 ttlItdedRetTaxFree,Int64 ttlRetOuterTax,Int64 ttlRetInnerTax,Int64 thisSalesPricDis,Int64 thisSalesPrcTaxDis,Int64 ttlItdedDisOutTax,Int64 ttlItdedDisInTax,Int64 ttlItdedDisTaxFree,Int64 ttlDisOuterTax,Int64 ttlDisInnerTax,Int64 taxAdjust,Int64 balanceAdjust,Int64 afCalTMonthAccRec,Int64 acpOdrTtl2TmBfAccRec,Int64 acpOdrTtl3TmBfAccRec,DateTime monthAddUpExpDate,DateTime stMonCAddUpUpdDate,DateTime laMonCAddUpUpdDate,Int32 salesSlipCount,Int32 consTaxLayMethod,Double consTaxRate,Int32 fractionProcCd,string enterpriseName,string updEmployeeName,string addUpSecName)
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
			this._claimCode = claimCode;
			this._claimName = claimName;
			this._claimName2 = claimName2;
			this._claimSnm = claimSnm;
			this._customerCode = customerCode;
			this._customerName = customerName;
			this._customerName2 = customerName2;
			this._customerSnm = customerSnm;
			this.AddUpDate = addUpDate;
			this.AddUpYearMonth = addUpYearMonth;
			this._lastTimeAccRec = lastTimeAccRec;
			this._thisTimeFeeDmdNrml = thisTimeFeeDmdNrml;
			this._thisTimeDisDmdNrml = thisTimeDisDmdNrml;
			this._thisTimeDmdNrml = thisTimeDmdNrml;
			this._thisTimeTtlBlcAcc = thisTimeTtlBlcAcc;
			this._ofsThisTimeSales = ofsThisTimeSales;
			this._ofsThisSalesTax = ofsThisSalesTax;
			this._itdedOffsetOutTax = itdedOffsetOutTax;
			this._itdedOffsetInTax = itdedOffsetInTax;
			this._itdedOffsetTaxFree = itdedOffsetTaxFree;
			this._offsetOutTax = offsetOutTax;
			this._offsetInTax = offsetInTax;
			this._thisTimeSales = thisTimeSales;
			this._thisSalesTax = thisSalesTax;
			this._itdedSalesOutTax = itdedSalesOutTax;
			this._itdedSalesInTax = itdedSalesInTax;
			this._itdedSalesTaxFree = itdedSalesTaxFree;
			this._salesOutTax = salesOutTax;
			this._salesInTax = salesInTax;
			this._thisSalesPricRgds = thisSalesPricRgds;
			this._thisSalesPrcTaxRgds = thisSalesPrcTaxRgds;
			this._ttlItdedRetOutTax = ttlItdedRetOutTax;
			this._ttlItdedRetInTax = ttlItdedRetInTax;
			this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
			this._ttlRetOuterTax = ttlRetOuterTax;
			this._ttlRetInnerTax = ttlRetInnerTax;
			this._thisSalesPricDis = thisSalesPricDis;
			this._thisSalesPrcTaxDis = thisSalesPrcTaxDis;
			this._ttlItdedDisOutTax = ttlItdedDisOutTax;
			this._ttlItdedDisInTax = ttlItdedDisInTax;
			this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
			this._ttlDisOuterTax = ttlDisOuterTax;
			this._ttlDisInnerTax = ttlDisInnerTax;
			this._taxAdjust = taxAdjust;
			this._balanceAdjust = balanceAdjust;
			this._afCalTMonthAccRec = afCalTMonthAccRec;
			this._acpOdrTtl2TmBfAccRec = acpOdrTtl2TmBfAccRec;
			this._acpOdrTtl3TmBfAccRec = acpOdrTtl3TmBfAccRec;
			this.MonthAddUpExpDate = monthAddUpExpDate;
			this.StMonCAddUpUpdDate = stMonCAddUpUpdDate;
			this.LaMonCAddUpUpdDate = laMonCAddUpUpdDate;
			this._salesSlipCount = salesSlipCount;
			this._consTaxLayMethod = consTaxLayMethod;
			this._consTaxRate = consTaxRate;
			this._fractionProcCd = fractionProcCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^��������
		/// </summary>
		/// <returns>CustAccRec�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustAccRec�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustAccRec Clone()
		{
			return new CustAccRec(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._addUpSecCode,this._claimCode,this._claimName,this._claimName2,this._claimSnm,this._customerCode,this._customerName,this._customerName2,this._customerSnm,this._addUpDate,this._addUpYearMonth,this._lastTimeAccRec,this._thisTimeFeeDmdNrml,this._thisTimeDisDmdNrml,this._thisTimeDmdNrml,this._thisTimeTtlBlcAcc,this._ofsThisTimeSales,this._ofsThisSalesTax,this._itdedOffsetOutTax,this._itdedOffsetInTax,this._itdedOffsetTaxFree,this._offsetOutTax,this._offsetInTax,this._thisTimeSales,this._thisSalesTax,this._itdedSalesOutTax,this._itdedSalesInTax,this._itdedSalesTaxFree,this._salesOutTax,this._salesInTax,this._thisSalesPricRgds,this._thisSalesPrcTaxRgds,this._ttlItdedRetOutTax,this._ttlItdedRetInTax,this._ttlItdedRetTaxFree,this._ttlRetOuterTax,this._ttlRetInnerTax,this._thisSalesPricDis,this._thisSalesPrcTaxDis,this._ttlItdedDisOutTax,this._ttlItdedDisInTax,this._ttlItdedDisTaxFree,this._ttlDisOuterTax,this._ttlDisInnerTax,this._taxAdjust,this._balanceAdjust,this._afCalTMonthAccRec,this._acpOdrTtl2TmBfAccRec,this._acpOdrTtl3TmBfAccRec,this._monthAddUpExpDate,this._stMonCAddUpUpdDate,this._laMonCAddUpUpdDate,this._salesSlipCount,this._consTaxLayMethod,this._consTaxRate,this._fractionProcCd,this._enterpriseName,this._updEmployeeName,this._addUpSecName);
		}

		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustAccRec�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustAccRec�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustAccRec target)
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
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.ClaimName == target.ClaimName)
				 && (this.ClaimName2 == target.ClaimName2)
				 && (this.ClaimSnm == target.ClaimSnm)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerName == target.CustomerName)
				 && (this.CustomerName2 == target.CustomerName2)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.AddUpDate == target.AddUpDate)
				 && (this.AddUpYearMonth == target.AddUpYearMonth)
				 && (this.LastTimeAccRec == target.LastTimeAccRec)
				 && (this.ThisTimeFeeDmdNrml == target.ThisTimeFeeDmdNrml)
				 && (this.ThisTimeDisDmdNrml == target.ThisTimeDisDmdNrml)
				 && (this.ThisTimeDmdNrml == target.ThisTimeDmdNrml)
				 && (this.ThisTimeTtlBlcAcc == target.ThisTimeTtlBlcAcc)
				 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
				 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
				 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
				 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
				 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
				 && (this.OffsetOutTax == target.OffsetOutTax)
				 && (this.OffsetInTax == target.OffsetInTax)
				 && (this.ThisTimeSales == target.ThisTimeSales)
				 && (this.ThisSalesTax == target.ThisSalesTax)
				 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
				 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
				 && (this.ItdedSalesTaxFree == target.ItdedSalesTaxFree)
				 && (this.SalesOutTax == target.SalesOutTax)
				 && (this.SalesInTax == target.SalesInTax)
				 && (this.ThisSalesPricRgds == target.ThisSalesPricRgds)
				 && (this.ThisSalesPrcTaxRgds == target.ThisSalesPrcTaxRgds)
				 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
				 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
				 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
				 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
				 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
				 && (this.ThisSalesPricDis == target.ThisSalesPricDis)
				 && (this.ThisSalesPrcTaxDis == target.ThisSalesPrcTaxDis)
				 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
				 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
				 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
				 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
				 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
				 && (this.TaxAdjust == target.TaxAdjust)
				 && (this.BalanceAdjust == target.BalanceAdjust)
				 && (this.AfCalTMonthAccRec == target.AfCalTMonthAccRec)
				 && (this.AcpOdrTtl2TmBfAccRec == target.AcpOdrTtl2TmBfAccRec)
				 && (this.AcpOdrTtl3TmBfAccRec == target.AcpOdrTtl3TmBfAccRec)
				 && (this.MonthAddUpExpDate == target.MonthAddUpExpDate)
				 && (this.StMonCAddUpUpdDate == target.StMonCAddUpUpdDate)
				 && (this.LaMonCAddUpUpdDate == target.LaMonCAddUpUpdDate)
				 && (this.SalesSlipCount == target.SalesSlipCount)
				 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				 && (this.ConsTaxRate == target.ConsTaxRate)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^��r����
		/// </summary>
		/// <param name="custAccRec1">
		///                    ��r����CustAccRec�N���X�̃C���X�^���X
		/// </param>
		/// <param name="custAccRec2">��r����CustAccRec�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustAccRec�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustAccRec custAccRec1, CustAccRec custAccRec2)
		{
			return ((custAccRec1.CreateDateTime == custAccRec2.CreateDateTime)
				 && (custAccRec1.UpdateDateTime == custAccRec2.UpdateDateTime)
				 && (custAccRec1.EnterpriseCode == custAccRec2.EnterpriseCode)
				 && (custAccRec1.FileHeaderGuid == custAccRec2.FileHeaderGuid)
				 && (custAccRec1.UpdEmployeeCode == custAccRec2.UpdEmployeeCode)
				 && (custAccRec1.UpdAssemblyId1 == custAccRec2.UpdAssemblyId1)
				 && (custAccRec1.UpdAssemblyId2 == custAccRec2.UpdAssemblyId2)
				 && (custAccRec1.LogicalDeleteCode == custAccRec2.LogicalDeleteCode)
				 && (custAccRec1.AddUpSecCode == custAccRec2.AddUpSecCode)
				 && (custAccRec1.ClaimCode == custAccRec2.ClaimCode)
				 && (custAccRec1.ClaimName == custAccRec2.ClaimName)
				 && (custAccRec1.ClaimName2 == custAccRec2.ClaimName2)
				 && (custAccRec1.ClaimSnm == custAccRec2.ClaimSnm)
				 && (custAccRec1.CustomerCode == custAccRec2.CustomerCode)
				 && (custAccRec1.CustomerName == custAccRec2.CustomerName)
				 && (custAccRec1.CustomerName2 == custAccRec2.CustomerName2)
				 && (custAccRec1.CustomerSnm == custAccRec2.CustomerSnm)
				 && (custAccRec1.AddUpDate == custAccRec2.AddUpDate)
				 && (custAccRec1.AddUpYearMonth == custAccRec2.AddUpYearMonth)
				 && (custAccRec1.LastTimeAccRec == custAccRec2.LastTimeAccRec)
				 && (custAccRec1.ThisTimeFeeDmdNrml == custAccRec2.ThisTimeFeeDmdNrml)
				 && (custAccRec1.ThisTimeDisDmdNrml == custAccRec2.ThisTimeDisDmdNrml)
				 && (custAccRec1.ThisTimeDmdNrml == custAccRec2.ThisTimeDmdNrml)
				 && (custAccRec1.ThisTimeTtlBlcAcc == custAccRec2.ThisTimeTtlBlcAcc)
				 && (custAccRec1.OfsThisTimeSales == custAccRec2.OfsThisTimeSales)
				 && (custAccRec1.OfsThisSalesTax == custAccRec2.OfsThisSalesTax)
				 && (custAccRec1.ItdedOffsetOutTax == custAccRec2.ItdedOffsetOutTax)
				 && (custAccRec1.ItdedOffsetInTax == custAccRec2.ItdedOffsetInTax)
				 && (custAccRec1.ItdedOffsetTaxFree == custAccRec2.ItdedOffsetTaxFree)
				 && (custAccRec1.OffsetOutTax == custAccRec2.OffsetOutTax)
				 && (custAccRec1.OffsetInTax == custAccRec2.OffsetInTax)
				 && (custAccRec1.ThisTimeSales == custAccRec2.ThisTimeSales)
				 && (custAccRec1.ThisSalesTax == custAccRec2.ThisSalesTax)
				 && (custAccRec1.ItdedSalesOutTax == custAccRec2.ItdedSalesOutTax)
				 && (custAccRec1.ItdedSalesInTax == custAccRec2.ItdedSalesInTax)
				 && (custAccRec1.ItdedSalesTaxFree == custAccRec2.ItdedSalesTaxFree)
				 && (custAccRec1.SalesOutTax == custAccRec2.SalesOutTax)
				 && (custAccRec1.SalesInTax == custAccRec2.SalesInTax)
				 && (custAccRec1.ThisSalesPricRgds == custAccRec2.ThisSalesPricRgds)
				 && (custAccRec1.ThisSalesPrcTaxRgds == custAccRec2.ThisSalesPrcTaxRgds)
				 && (custAccRec1.TtlItdedRetOutTax == custAccRec2.TtlItdedRetOutTax)
				 && (custAccRec1.TtlItdedRetInTax == custAccRec2.TtlItdedRetInTax)
				 && (custAccRec1.TtlItdedRetTaxFree == custAccRec2.TtlItdedRetTaxFree)
				 && (custAccRec1.TtlRetOuterTax == custAccRec2.TtlRetOuterTax)
				 && (custAccRec1.TtlRetInnerTax == custAccRec2.TtlRetInnerTax)
				 && (custAccRec1.ThisSalesPricDis == custAccRec2.ThisSalesPricDis)
				 && (custAccRec1.ThisSalesPrcTaxDis == custAccRec2.ThisSalesPrcTaxDis)
				 && (custAccRec1.TtlItdedDisOutTax == custAccRec2.TtlItdedDisOutTax)
				 && (custAccRec1.TtlItdedDisInTax == custAccRec2.TtlItdedDisInTax)
				 && (custAccRec1.TtlItdedDisTaxFree == custAccRec2.TtlItdedDisTaxFree)
				 && (custAccRec1.TtlDisOuterTax == custAccRec2.TtlDisOuterTax)
				 && (custAccRec1.TtlDisInnerTax == custAccRec2.TtlDisInnerTax)
				 && (custAccRec1.TaxAdjust == custAccRec2.TaxAdjust)
				 && (custAccRec1.BalanceAdjust == custAccRec2.BalanceAdjust)
				 && (custAccRec1.AfCalTMonthAccRec == custAccRec2.AfCalTMonthAccRec)
				 && (custAccRec1.AcpOdrTtl2TmBfAccRec == custAccRec2.AcpOdrTtl2TmBfAccRec)
				 && (custAccRec1.AcpOdrTtl3TmBfAccRec == custAccRec2.AcpOdrTtl3TmBfAccRec)
				 && (custAccRec1.MonthAddUpExpDate == custAccRec2.MonthAddUpExpDate)
				 && (custAccRec1.StMonCAddUpUpdDate == custAccRec2.StMonCAddUpUpdDate)
				 && (custAccRec1.LaMonCAddUpUpdDate == custAccRec2.LaMonCAddUpUpdDate)
				 && (custAccRec1.SalesSlipCount == custAccRec2.SalesSlipCount)
				 && (custAccRec1.ConsTaxLayMethod == custAccRec2.ConsTaxLayMethod)
				 && (custAccRec1.ConsTaxRate == custAccRec2.ConsTaxRate)
				 && (custAccRec1.FractionProcCd == custAccRec2.FractionProcCd)
				 && (custAccRec1.EnterpriseName == custAccRec2.EnterpriseName)
				 && (custAccRec1.UpdEmployeeName == custAccRec2.UpdEmployeeName)
				 && (custAccRec1.AddUpSecName == custAccRec2.AddUpSecName));
		}
		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustAccRec�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustAccRec�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CustAccRec target)
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
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.ClaimName != target.ClaimName)resList.Add("ClaimName");
			if(this.ClaimName2 != target.ClaimName2)resList.Add("ClaimName2");
			if(this.ClaimSnm != target.ClaimSnm)resList.Add("ClaimSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerName != target.CustomerName)resList.Add("CustomerName");
			if(this.CustomerName2 != target.CustomerName2)resList.Add("CustomerName2");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.AddUpYearMonth != target.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(this.LastTimeAccRec != target.LastTimeAccRec)resList.Add("LastTimeAccRec");
			if(this.ThisTimeFeeDmdNrml != target.ThisTimeFeeDmdNrml)resList.Add("ThisTimeFeeDmdNrml");
			if(this.ThisTimeDisDmdNrml != target.ThisTimeDisDmdNrml)resList.Add("ThisTimeDisDmdNrml");
			if(this.ThisTimeDmdNrml != target.ThisTimeDmdNrml)resList.Add("ThisTimeDmdNrml");
			if(this.ThisTimeTtlBlcAcc != target.ThisTimeTtlBlcAcc)resList.Add("ThisTimeTtlBlcAcc");
			if(this.OfsThisTimeSales != target.OfsThisTimeSales)resList.Add("OfsThisTimeSales");
			if(this.OfsThisSalesTax != target.OfsThisSalesTax)resList.Add("OfsThisSalesTax");
			if(this.ItdedOffsetOutTax != target.ItdedOffsetOutTax)resList.Add("ItdedOffsetOutTax");
			if(this.ItdedOffsetInTax != target.ItdedOffsetInTax)resList.Add("ItdedOffsetInTax");
			if(this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree)resList.Add("ItdedOffsetTaxFree");
			if(this.OffsetOutTax != target.OffsetOutTax)resList.Add("OffsetOutTax");
			if(this.OffsetInTax != target.OffsetInTax)resList.Add("OffsetInTax");
			if(this.ThisTimeSales != target.ThisTimeSales)resList.Add("ThisTimeSales");
			if(this.ThisSalesTax != target.ThisSalesTax)resList.Add("ThisSalesTax");
			if(this.ItdedSalesOutTax != target.ItdedSalesOutTax)resList.Add("ItdedSalesOutTax");
			if(this.ItdedSalesInTax != target.ItdedSalesInTax)resList.Add("ItdedSalesInTax");
			if(this.ItdedSalesTaxFree != target.ItdedSalesTaxFree)resList.Add("ItdedSalesTaxFree");
			if(this.SalesOutTax != target.SalesOutTax)resList.Add("SalesOutTax");
			if(this.SalesInTax != target.SalesInTax)resList.Add("SalesInTax");
			if(this.ThisSalesPricRgds != target.ThisSalesPricRgds)resList.Add("ThisSalesPricRgds");
			if(this.ThisSalesPrcTaxRgds != target.ThisSalesPrcTaxRgds)resList.Add("ThisSalesPrcTaxRgds");
			if(this.TtlItdedRetOutTax != target.TtlItdedRetOutTax)resList.Add("TtlItdedRetOutTax");
			if(this.TtlItdedRetInTax != target.TtlItdedRetInTax)resList.Add("TtlItdedRetInTax");
			if(this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree)resList.Add("TtlItdedRetTaxFree");
			if(this.TtlRetOuterTax != target.TtlRetOuterTax)resList.Add("TtlRetOuterTax");
			if(this.TtlRetInnerTax != target.TtlRetInnerTax)resList.Add("TtlRetInnerTax");
			if(this.ThisSalesPricDis != target.ThisSalesPricDis)resList.Add("ThisSalesPricDis");
			if(this.ThisSalesPrcTaxDis != target.ThisSalesPrcTaxDis)resList.Add("ThisSalesPrcTaxDis");
			if(this.TtlItdedDisOutTax != target.TtlItdedDisOutTax)resList.Add("TtlItdedDisOutTax");
			if(this.TtlItdedDisInTax != target.TtlItdedDisInTax)resList.Add("TtlItdedDisInTax");
			if(this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree)resList.Add("TtlItdedDisTaxFree");
			if(this.TtlDisOuterTax != target.TtlDisOuterTax)resList.Add("TtlDisOuterTax");
			if(this.TtlDisInnerTax != target.TtlDisInnerTax)resList.Add("TtlDisInnerTax");
			if(this.TaxAdjust != target.TaxAdjust)resList.Add("TaxAdjust");
			if(this.BalanceAdjust != target.BalanceAdjust)resList.Add("BalanceAdjust");
			if(this.AfCalTMonthAccRec != target.AfCalTMonthAccRec)resList.Add("AfCalTMonthAccRec");
			if(this.AcpOdrTtl2TmBfAccRec != target.AcpOdrTtl2TmBfAccRec)resList.Add("AcpOdrTtl2TmBfAccRec");
			if(this.AcpOdrTtl3TmBfAccRec != target.AcpOdrTtl3TmBfAccRec)resList.Add("AcpOdrTtl3TmBfAccRec");
			if(this.MonthAddUpExpDate != target.MonthAddUpExpDate)resList.Add("MonthAddUpExpDate");
			if(this.StMonCAddUpUpdDate != target.StMonCAddUpUpdDate)resList.Add("StMonCAddUpUpdDate");
			if(this.LaMonCAddUpUpdDate != target.LaMonCAddUpUpdDate)resList.Add("LaMonCAddUpUpdDate");
			if(this.SalesSlipCount != target.SalesSlipCount)resList.Add("SalesSlipCount");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.ConsTaxRate != target.ConsTaxRate)resList.Add("ConsTaxRate");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// ���Ӑ攄�|���z�}�X�^��r����
		/// </summary>
		/// <param name="custAccRec1">��r����CustAccRec�N���X�̃C���X�^���X</param>
		/// <param name="custAccRec2">��r����CustAccRec�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustAccRec�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CustAccRec custAccRec1, CustAccRec custAccRec2)
		{
			ArrayList resList = new ArrayList();
			if(custAccRec1.CreateDateTime != custAccRec2.CreateDateTime)resList.Add("CreateDateTime");
			if(custAccRec1.UpdateDateTime != custAccRec2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(custAccRec1.EnterpriseCode != custAccRec2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custAccRec1.FileHeaderGuid != custAccRec2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(custAccRec1.UpdEmployeeCode != custAccRec2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(custAccRec1.UpdAssemblyId1 != custAccRec2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(custAccRec1.UpdAssemblyId2 != custAccRec2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(custAccRec1.LogicalDeleteCode != custAccRec2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(custAccRec1.AddUpSecCode != custAccRec2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(custAccRec1.ClaimCode != custAccRec2.ClaimCode)resList.Add("ClaimCode");
			if(custAccRec1.ClaimName != custAccRec2.ClaimName)resList.Add("ClaimName");
			if(custAccRec1.ClaimName2 != custAccRec2.ClaimName2)resList.Add("ClaimName2");
			if(custAccRec1.ClaimSnm != custAccRec2.ClaimSnm)resList.Add("ClaimSnm");
			if(custAccRec1.CustomerCode != custAccRec2.CustomerCode)resList.Add("CustomerCode");
			if(custAccRec1.CustomerName != custAccRec2.CustomerName)resList.Add("CustomerName");
			if(custAccRec1.CustomerName2 != custAccRec2.CustomerName2)resList.Add("CustomerName2");
			if(custAccRec1.CustomerSnm != custAccRec2.CustomerSnm)resList.Add("CustomerSnm");
			if(custAccRec1.AddUpDate != custAccRec2.AddUpDate)resList.Add("AddUpDate");
			if(custAccRec1.AddUpYearMonth != custAccRec2.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(custAccRec1.LastTimeAccRec != custAccRec2.LastTimeAccRec)resList.Add("LastTimeAccRec");
			if(custAccRec1.ThisTimeFeeDmdNrml != custAccRec2.ThisTimeFeeDmdNrml)resList.Add("ThisTimeFeeDmdNrml");
			if(custAccRec1.ThisTimeDisDmdNrml != custAccRec2.ThisTimeDisDmdNrml)resList.Add("ThisTimeDisDmdNrml");
			if(custAccRec1.ThisTimeDmdNrml != custAccRec2.ThisTimeDmdNrml)resList.Add("ThisTimeDmdNrml");
			if(custAccRec1.ThisTimeTtlBlcAcc != custAccRec2.ThisTimeTtlBlcAcc)resList.Add("ThisTimeTtlBlcAcc");
			if(custAccRec1.OfsThisTimeSales != custAccRec2.OfsThisTimeSales)resList.Add("OfsThisTimeSales");
			if(custAccRec1.OfsThisSalesTax != custAccRec2.OfsThisSalesTax)resList.Add("OfsThisSalesTax");
			if(custAccRec1.ItdedOffsetOutTax != custAccRec2.ItdedOffsetOutTax)resList.Add("ItdedOffsetOutTax");
			if(custAccRec1.ItdedOffsetInTax != custAccRec2.ItdedOffsetInTax)resList.Add("ItdedOffsetInTax");
			if(custAccRec1.ItdedOffsetTaxFree != custAccRec2.ItdedOffsetTaxFree)resList.Add("ItdedOffsetTaxFree");
			if(custAccRec1.OffsetOutTax != custAccRec2.OffsetOutTax)resList.Add("OffsetOutTax");
			if(custAccRec1.OffsetInTax != custAccRec2.OffsetInTax)resList.Add("OffsetInTax");
			if(custAccRec1.ThisTimeSales != custAccRec2.ThisTimeSales)resList.Add("ThisTimeSales");
			if(custAccRec1.ThisSalesTax != custAccRec2.ThisSalesTax)resList.Add("ThisSalesTax");
			if(custAccRec1.ItdedSalesOutTax != custAccRec2.ItdedSalesOutTax)resList.Add("ItdedSalesOutTax");
			if(custAccRec1.ItdedSalesInTax != custAccRec2.ItdedSalesInTax)resList.Add("ItdedSalesInTax");
			if(custAccRec1.ItdedSalesTaxFree != custAccRec2.ItdedSalesTaxFree)resList.Add("ItdedSalesTaxFree");
			if(custAccRec1.SalesOutTax != custAccRec2.SalesOutTax)resList.Add("SalesOutTax");
			if(custAccRec1.SalesInTax != custAccRec2.SalesInTax)resList.Add("SalesInTax");
			if(custAccRec1.ThisSalesPricRgds != custAccRec2.ThisSalesPricRgds)resList.Add("ThisSalesPricRgds");
			if(custAccRec1.ThisSalesPrcTaxRgds != custAccRec2.ThisSalesPrcTaxRgds)resList.Add("ThisSalesPrcTaxRgds");
			if(custAccRec1.TtlItdedRetOutTax != custAccRec2.TtlItdedRetOutTax)resList.Add("TtlItdedRetOutTax");
			if(custAccRec1.TtlItdedRetInTax != custAccRec2.TtlItdedRetInTax)resList.Add("TtlItdedRetInTax");
			if(custAccRec1.TtlItdedRetTaxFree != custAccRec2.TtlItdedRetTaxFree)resList.Add("TtlItdedRetTaxFree");
			if(custAccRec1.TtlRetOuterTax != custAccRec2.TtlRetOuterTax)resList.Add("TtlRetOuterTax");
			if(custAccRec1.TtlRetInnerTax != custAccRec2.TtlRetInnerTax)resList.Add("TtlRetInnerTax");
			if(custAccRec1.ThisSalesPricDis != custAccRec2.ThisSalesPricDis)resList.Add("ThisSalesPricDis");
			if(custAccRec1.ThisSalesPrcTaxDis != custAccRec2.ThisSalesPrcTaxDis)resList.Add("ThisSalesPrcTaxDis");
			if(custAccRec1.TtlItdedDisOutTax != custAccRec2.TtlItdedDisOutTax)resList.Add("TtlItdedDisOutTax");
			if(custAccRec1.TtlItdedDisInTax != custAccRec2.TtlItdedDisInTax)resList.Add("TtlItdedDisInTax");
			if(custAccRec1.TtlItdedDisTaxFree != custAccRec2.TtlItdedDisTaxFree)resList.Add("TtlItdedDisTaxFree");
			if(custAccRec1.TtlDisOuterTax != custAccRec2.TtlDisOuterTax)resList.Add("TtlDisOuterTax");
			if(custAccRec1.TtlDisInnerTax != custAccRec2.TtlDisInnerTax)resList.Add("TtlDisInnerTax");
			if(custAccRec1.TaxAdjust != custAccRec2.TaxAdjust)resList.Add("TaxAdjust");
			if(custAccRec1.BalanceAdjust != custAccRec2.BalanceAdjust)resList.Add("BalanceAdjust");
			if(custAccRec1.AfCalTMonthAccRec != custAccRec2.AfCalTMonthAccRec)resList.Add("AfCalTMonthAccRec");
			if(custAccRec1.AcpOdrTtl2TmBfAccRec != custAccRec2.AcpOdrTtl2TmBfAccRec)resList.Add("AcpOdrTtl2TmBfAccRec");
			if(custAccRec1.AcpOdrTtl3TmBfAccRec != custAccRec2.AcpOdrTtl3TmBfAccRec)resList.Add("AcpOdrTtl3TmBfAccRec");
			if(custAccRec1.MonthAddUpExpDate != custAccRec2.MonthAddUpExpDate)resList.Add("MonthAddUpExpDate");
			if(custAccRec1.StMonCAddUpUpdDate != custAccRec2.StMonCAddUpUpdDate)resList.Add("StMonCAddUpUpdDate");
			if(custAccRec1.LaMonCAddUpUpdDate != custAccRec2.LaMonCAddUpUpdDate)resList.Add("LaMonCAddUpUpdDate");
			if(custAccRec1.SalesSlipCount != custAccRec2.SalesSlipCount)resList.Add("SalesSlipCount");
			if(custAccRec1.ConsTaxLayMethod != custAccRec2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(custAccRec1.ConsTaxRate != custAccRec2.ConsTaxRate)resList.Add("ConsTaxRate");
			if(custAccRec1.FractionProcCd != custAccRec2.FractionProcCd)resList.Add("FractionProcCd");
			if(custAccRec1.EnterpriseName != custAccRec2.EnterpriseName)resList.Add("EnterpriseName");
			if(custAccRec1.UpdEmployeeName != custAccRec2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(custAccRec1.AddUpSecName != custAccRec2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}

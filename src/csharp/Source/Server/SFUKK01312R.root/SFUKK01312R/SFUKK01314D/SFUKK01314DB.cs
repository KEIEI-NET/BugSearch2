using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SeiKingetParameter
	/// <summary>
	///                      ����KINGET�p���o�����p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����KINGET�p�̒��o�����p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/03/31</br>
	/// <br>Genarated Date   :   2005/07/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class SeiKingetParameter
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h���X�g</summary>
		/// <remarks>���o�ΏۂƂȂ��Ă���v�㋒�_�R�[�h�̃��X�g</remarks>
		private ArrayList _addUpSecCodeList;

		/// <summary>�S�БI��</summary>
		/// <remarks>true:�S�БI�� false:�e���_�I��</remarks>
		private bool _isSelectAllSection;

		/// <summary>���Ӑ�R�[�h�i�J�n�j</summary>
		private Int32 _startCustomerCode;

		/// <summary>���Ӑ�R�[�h�i�I���j</summary>
		private Int32 _endCustomerCode;

		/// <summary>����</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>����(�J�n)</summary>
		/// <remarks>DD</remarks>
		private Int32 _startTotalDay;

		/// <summary>����(�I��)</summary>
		/// <remarks>DD</remarks>
		private Int32 _endTotalDay;

		/// <summary>�v��N�����i�J�n�j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _startAddUpDate;

		/// <summary>�v��N�����i�J�n�j �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateJpFormal = "";

		/// <summary>�v��N�����i�J�n�j �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateJpInFormal = "";

		/// <summary>�v��N�����i�J�n�j ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateAdFormal = "";

		/// <summary>�v��N�����i�J�n�j ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateAdInFormal = "";

		/// <summary>�v��N�����i�I���j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _endAddUpDate;

		/// <summary>�v��N�����i�I���j �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateJpFormal = "";

		/// <summary>�v��N�����i�I���j �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateJpInFormal = "";

		/// <summary>�v��N�����i�I���j ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateAdFormal = "";

		/// <summary>�v��N�����i�I���j ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateAdInFormal = "";

		/// <summary>�v��N���i�J�n�j</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _startAddUpYearMonth;

		/// <summary>�v��N���i�I���j</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _endAddUpYearMonth;

		/// <summary>�c���O�o��</summary>
		/// <remarks>true:�����c�����O�̏ꍇ�ł����z�I�ɏ����쐬����Bfalse;�����c�����O�̏ꍇ�͍쐬���Ȃ�</remarks>
		private bool _isOutputZeroBlance;

		/// <summary>�S���_���R�[�h�o��</summary>
		/// <remarks>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</remarks>
		private bool _isOutputAllSecRec;

		/// <summary>���Ӑ�J�i�i�J�n�j</summary>
		private string _startKana = "";

		/// <summary>���Ӑ�J�i�i�I���j</summary>
		private string _endKana = "";

		/// <summary>�S�l�E�@�l�敪�t���O</summary>
		/// <remarks>true:�S�Ă̌l�E�@�l�敪��ΏۂƂ���,false:�l�E�@�l�敪���X�g�Ɋ�Â��Č�������</remarks>
		private bool _isAllCorporateDivCode;

		/// <summary>�l�E�@�l�敪���X�g</summary>
		/// <remarks>���o�ΏۂƂȂ��Ă���l�E�@�l�敪�̃��X�g</remarks>
		private ArrayList _corporateDivCodeList;

		/// <summary>�������o�͋敪���f</summary>
		/// <remarks>true:�������o�͋敪�����������ɓ����,false:�������o�͋敪�����������ɓ���Ȃ�</remarks>
		private bool _isJudgeBillOutputCode;

		/// <summary>�]�ƈ��敪</summary>
		/// <remarks>0:���Ӑ�,1:�W��</remarks>
		private Int32 _employeeKind;

		/// <summary>�]�ƈ��R�[�h�i�J�n�j</summary>
		private string _startEmployeeCode = "";

		/// <summary>�]�ƈ��R�[�h�i�I���j</summary>
		private string _endEmployeeCode = "";

		/// <summary>�J�n���Ӑ敪�̓R�[�h�P</summary>
		private Int32 _startCustAnalysCode1;

		/// <summary>�J�n���Ӑ敪�̓R�[�h�Q</summary>
		private Int32 _startCustAnalysCode2;

		/// <summary>�J�n���Ӑ敪�̓R�[�h�R</summary>
		private Int32 _startCustAnalysCode3;

		/// <summary>�J�n���Ӑ敪�̓R�[�h�S</summary>
		private Int32 _startCustAnalysCode4;

		/// <summary>�J�n���Ӑ敪�̓R�[�h�T</summary>
		private Int32 _startCustAnalysCode5;

		/// <summary>�J�n���Ӑ敪�̓R�[�h�U</summary>
		private Int32 _startCustAnalysCode6;

		/// <summary>�I�����Ӑ敪�̓R�[�h�P</summary>
		private Int32 _endCustAnalysCode1 = 999;

		/// <summary>�I�����Ӑ敪�̓R�[�h�Q</summary>
		private Int32 _endCustAnalysCode2 = 999;

		/// <summary>�I�����Ӑ敪�̓R�[�h�R</summary>
		private Int32 _endCustAnalysCode3 = 999;

		/// <summary>�I�����Ӑ敪�̓R�[�h�S</summary>
		private Int32 _endCustAnalysCode4 = 999;

		/// <summary>�I�����Ӑ敪�̓R�[�h�T</summary>
		private Int32 _endCustAnalysCode5 = 999;

		/// <summary>�I�����Ӑ敪�̓R�[�h�U</summary>
		private Int32 _endCustAnalysCode6 = 999;


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

		/// public propaty name  :  AddUpSecCodeList
		/// <summary>�v�㋒�_�R�[�h���X�g�v���p�e�B</summary>
		/// <value>���o�̑ΏۂƂȂ��Ă��鋒�_�R�[�h���X�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList AddUpSecCodeList
		{
			get{return _addUpSecCodeList;}
			set{_addUpSecCodeList = value;}
		}

		/// public propaty name  :  IsSelectAllSection
		/// <summary>�S�БI���v���p�e�B</summary>
		/// <value>true:�S�БI�� false:�e���_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S�БI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsSelectAllSection
		{
			get{return _isSelectAllSection;}
			set{_isSelectAllSection = value;}
		}

		/// public propaty name  :  StartCustomerCode
		/// <summary>���Ӑ�R�[�h�i�J�n�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustomerCode
		{
			get{return _startCustomerCode;}
			set{_startCustomerCode = value;}
		}

		/// public propaty name  :  EndCustomerCode
		/// <summary>���Ӑ�R�[�h�i�I���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustomerCode
		{
			get{return _endCustomerCode;}
			set{_endCustomerCode = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>�����v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  StartTotalDay
		/// <summary>����(�J�n)�v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartTotalDay
		{
			get{return _startTotalDay;}
			set{_startTotalDay = value;}
		}

		/// public propaty name  :  EndTotalDay
		/// <summary>����(�I��)�v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndTotalDay
		{
			get{return _endTotalDay;}
			set{_endTotalDay = value;}
		}

		/// public propaty name  :  StartAddUpDate
		/// <summary>�v��N�����i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StartAddUpDate
		{
			get{return _startAddUpDate;}
			set
			{
				_startAddUpDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._startAddUpDateJpFormal = dateTimes[0];
				this._startAddUpDateJpInFormal = dateTimes[1];
				this._startAddUpDateAdFormal = dateTimes[2];
				this._startAddUpDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  StartAddUpDateJpFormal
		/// <summary>�v��N�����i�J�n�j �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�J�n�j �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartAddUpDateJpFormal
		{
			get{return _startAddUpDateJpFormal;}
		}

		/// public propaty name  :  StartAddUpDateJpInFormal
		/// <summary>�v��N�����i�J�n�j �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�J�n�j �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartAddUpDateJpInFormal
		{
			get{return _startAddUpDateJpInFormal;}
		}

		/// public propaty name  :  StartAddUpDateAdFormal
		/// <summary>�v��N�����i�J�n�j ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�J�n�j ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartAddUpDateAdFormal
		{
			get{return _startAddUpDateAdFormal;}
		}

		/// public propaty name  :  StartAddUpDateAdInFormal
		/// <summary>�v��N�����i�J�n�j ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�J�n�j ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartAddUpDateAdInFormal
		{
			get{return _startAddUpDateAdInFormal;}
		}

		/// public propaty name  :  EndAddUpDate
		/// <summary>�v��N�����i�I���j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime EndAddUpDate
		{
			get{return _endAddUpDate;}
			set
			{
				_endAddUpDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._endAddUpDateJpFormal = dateTimes[0];
				this._endAddUpDateJpInFormal = dateTimes[1];
				this._endAddUpDateAdFormal = dateTimes[2];
				this._endAddUpDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  EndAddUpDateJpFormal
		/// <summary>�v��N�����i�I���j �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�I���j �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndAddUpDateJpFormal
		{
			get{return _endAddUpDateJpFormal;}
		}

		/// public propaty name  :  EndAddUpDateJpInFormal
		/// <summary>�v��N�����i�I���j �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�I���j �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndAddUpDateJpInFormal
		{
			get{return _endAddUpDateJpInFormal;}
		}

		/// public propaty name  :  EndAddUpDateAdFormal
		/// <summary>�v��N�����i�I���j ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�I���j ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndAddUpDateAdFormal
		{
			get{return _endAddUpDateAdFormal;}
		}

		/// public propaty name  :  EndAddUpDateAdInFormal
		/// <summary>�v��N�����i�I���j ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����i�I���j ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndAddUpDateAdInFormal
		{
			get{return _endAddUpDateAdInFormal;}
		}

		/// public propaty name  :  StartAddUpYearMonth
		/// <summary>�v��N���i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartAddUpYearMonth
		{
			get{return _startAddUpYearMonth;}
			set{_startAddUpYearMonth = value;}
		}

		/// public propaty name  :  EndAddUpYearMonth
		/// <summary>�v��N���i�I���j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndAddUpYearMonth
		{
			get{return _endAddUpYearMonth;}
			set{_endAddUpYearMonth = value;}
		}

		/// public propaty name  :  IsOutputZeroBlance
		/// <summary>�c���O�o�̓v���p�e�B</summary>
		/// <value>true:�����c�����O�̏ꍇ�ł����z�I�ɏ����쐬����Bfalse;�����c�����O�̏ꍇ�͍쐬���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���O�o�̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsOutputZeroBlance
		{
			get{return _isOutputZeroBlance;}
			set{_isOutputZeroBlance = value;}
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
		/// <value>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���_���R�[�h�o�̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsOutputAllSecRec
		{
			get{return _isOutputAllSecRec;}
			set{_isOutputAllSecRec = value;}
		}

		/// public propaty name  :  StartKana
		/// <summary>���Ӑ�J�i�i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�J�i�i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartKana
		{
			get{return _startKana;}
			set{_startKana = value;}
		}

		/// public propaty name  :  EndKana
		/// <summary>���Ӑ�J�i�i�I���j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�J�i�i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndKana
		{
			get{return _endKana;}
			set{_endKana = value;}
		}

		/// public propaty name  :  CorporateDivCodeList
		/// <summary>�S�l�E�@�l�敪�v���p�e�B</summary>
		/// <value>true:�S�Ă̌l�E�@�l�敪��ΏۂƂ���,false:�l�E�@�l�敪���X�g�Ɋ�Â��Č�������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S�l�E�@�l�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsAllCorporateDivCode
		{
			get{return _isAllCorporateDivCode;}
			set{_isAllCorporateDivCode = value;}
		}

		/// public propaty name  :  CorporateDivCodeList
		/// <summary>�l�E�@�l�敪���X�g�v���p�e�B</summary>
		/// <value>���o�ΏۂƂȂ��Ă���l�E�@�l�敪�̃��X�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�E�@�l�敪���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList CorporateDivCodeList
		{
			get{return _corporateDivCodeList;}
			set{_corporateDivCodeList = value;}
		}

		/// public propaty name  :  IsJudgeBillOutputCode
		/// <summary>�������o�͋敪���f�v���p�e�B</summary>
		/// <value>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������o�͋敪���f�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsJudgeBillOutputCode
		{
			get{return _isJudgeBillOutputCode;}
			set{_isJudgeBillOutputCode = value;}
		}

		/// public propaty name  :  EmployeeKind
		/// <summary>�]�ƈ��敪�v���p�e�B</summary>
		/// <value>0:���Ӑ�,1:�W��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployeeKind
		{
			get{return _employeeKind;}
			set{_employeeKind = value;}
		}

		/// public propaty name  :  StartEmployeeCode
		/// <summary>�]�ƈ��R�[�h�i�J�n�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h�i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartEmployeeCode
		{
			get{return _startEmployeeCode;}
			set{_startEmployeeCode = value;}
		}

		/// public propaty name  :  EndEmployeeCode
		/// <summary>�]�ƈ��R�[�h�i�I���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h�i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndEmployeeCode
		{
			get{return _endEmployeeCode;}
			set{_endEmployeeCode = value;}
		}

		/// public propaty name  :  StartCustAnalysCode1
		/// <summary>�J�n���Ӑ敪�̓R�[�h�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ敪�̓R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustAnalysCode1
		{
			get{return _startCustAnalysCode1;}
			set{_startCustAnalysCode1 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode2
		/// <summary>�J�n���Ӑ敪�̓R�[�h�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ敪�̓R�[�h�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustAnalysCode2
		{
			get{return _startCustAnalysCode2;}
			set{_startCustAnalysCode2 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode3
		/// <summary>�J�n���Ӑ敪�̓R�[�h�R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ敪�̓R�[�h�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustAnalysCode3
		{
			get{return _startCustAnalysCode3;}
			set{_startCustAnalysCode3 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode4
		/// <summary>�J�n���Ӑ敪�̓R�[�h�S�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ敪�̓R�[�h�S�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustAnalysCode4
		{
			get{return _startCustAnalysCode4;}
			set{_startCustAnalysCode4 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode5
		/// <summary>�J�n���Ӑ敪�̓R�[�h�T�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ敪�̓R�[�h�T�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustAnalysCode5
		{
			get{return _startCustAnalysCode5;}
			set{_startCustAnalysCode5 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode6
		/// <summary>�J�n���Ӑ敪�̓R�[�h�U�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ敪�̓R�[�h�U�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustAnalysCode6
		{
			get{return _startCustAnalysCode6;}
			set{_startCustAnalysCode6 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode1
		/// <summary>�I�����Ӑ敪�̓R�[�h�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ敪�̓R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustAnalysCode1
		{
			get{return _endCustAnalysCode1;}
			set{_endCustAnalysCode1 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode2
		/// <summary>�I�����Ӑ敪�̓R�[�h�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ敪�̓R�[�h�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustAnalysCode2
		{
			get{return _endCustAnalysCode2;}
			set{_endCustAnalysCode2 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode3
		/// <summary>�I�����Ӑ敪�̓R�[�h�R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ敪�̓R�[�h�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustAnalysCode3
		{
			get{return _endCustAnalysCode3;}
			set{_endCustAnalysCode3 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode4
		/// <summary>�I�����Ӑ敪�̓R�[�h�S�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ敪�̓R�[�h�S�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustAnalysCode4
		{
			get{return _endCustAnalysCode4;}
			set{_endCustAnalysCode4 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode5
		/// <summary>�I�����Ӑ敪�̓R�[�h�T�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ敪�̓R�[�h�T�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustAnalysCode5
		{
			get{return _endCustAnalysCode5;}
			set{_endCustAnalysCode5 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode6
		/// <summary>�I�����Ӑ敪�̓R�[�h�U�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ敪�̓R�[�h�U�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustAnalysCode6
		{
			get{return _endCustAnalysCode6;}
			set{_endCustAnalysCode6 = value;}
		}


		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SeiKingetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SeiKingetParameter()
		{
			this._addUpSecCodeList = new ArrayList();
			this.StartAddUpDate = DateTime.MinValue;
			this.EndAddUpDate = DateTime.MinValue;
			this._corporateDivCodeList = new ArrayList();
		}

		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">�v�㋒�_�R�[�h���X�g(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI�� false:�e���_�I��)</param>
		/// <param name="startCustomerCode">���Ӑ�R�[�h�i�J�n�j</param>
		/// <param name="endCustomerCode">���Ӑ�R�[�h�i�I���j</param>
		/// <param name="totalDay">����</param>
		/// <param name="startTotalDay">����(�J�n)</param>
		/// <param name="endTotalDay">����(�I��)</param>
		/// <param name="startAddUpDate">�v��N�����i�J�n�j(YYYYMMDD)</param>
		/// <param name="endAddUpDate">�v��N�����i�I���j(YYYYMMDD)</param>
		/// <param name="startAddUpYearMonth">�v��N���i�J�n�j(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">�v��N���i�I���j(YYYYMM)</param>
		/// <param name="isOutputZeroBlance">�c���O�o��(true:�����c�����O�̏ꍇ�ł����z�I�ɏ����쐬����Bfalse;�����c�����O�̏ꍇ�͍쐬���Ȃ�)</param>
		/// <param name="isOutputAllSecRec">�S���_���R�[�h�o��(true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�)</param>
		/// <param name="startKana">���Ӑ�J�i�i�J�n�j</param>
		/// <param name="endKana">���Ӑ�J�i�i�I���j</param>
		/// <param name="isAllCorporateDivCode">�S�l�E�@�l�敪(true:�S�Ă̌l�E�@�l�敪��ΏۂƂ���,false:�l�E�@�l�敪���X�g�Ɋ�Â��Č�������)</param>
		/// <param name="corporateDivCodeList">�l�E�@�l�敪���X�g(���o�ΏۂƂȂ��Ă���l�E�@�l�敪�̃��X�g)</param>
		/// <param name="isJudgeBillOutputCode">�������o�͋敪���f(true:�������o�͋敪�𔻒f����,false:�������o�͋敪�𔻒f���Ȃ�)</param>
		/// <param name="employeeKind">�]�ƈ��敪(0:���Ӑ�,1:�W��)</param>
		/// <param name="startEmployeeCode">�]�ƈ��R�[�h�i�J�n�j</param>
		/// <param name="endEmployeeCode">�]�ƈ��R�[�h�i�I���j</param>		
		/// <param name="startCustAnalysCode1">�J�n���Ӑ敪�̓R�[�h�P</param>
		/// <param name="startCustAnalysCode2">�J�n���Ӑ敪�̓R�[�h�Q</param>
		/// <param name="startCustAnalysCode3">�J�n���Ӑ敪�̓R�[�h�R</param>
		/// <param name="startCustAnalysCode4">�J�n���Ӑ敪�̓R�[�h�S</param>
		/// <param name="startCustAnalysCode5">�J�n���Ӑ敪�̓R�[�h�T</param>
		/// <param name="startCustAnalysCode6">�J�n���Ӑ敪�̓R�[�h�U</param>
		/// <param name="endCustAnalysCode1">�I�����Ӑ敪�̓R�[�h�P</param>
		/// <param name="endCustAnalysCode2">�I�����Ӑ敪�̓R�[�h�Q</param>
		/// <param name="endCustAnalysCode3">�I�����Ӑ敪�̓R�[�h�R</param>
		/// <param name="endCustAnalysCode4">�I�����Ӑ敪�̓R�[�h�S</param>
		/// <param name="endCustAnalysCode5">�I�����Ӑ敪�̓R�[�h�T</param>
		/// <param name="endCustAnalysCode6">�I�����Ӑ敪�̓R�[�h�U</param>
		/// <returns>SeiKingetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SeiKingetParameter(string enterpriseCode,ArrayList addUpSecCodeList,bool isSelectAllSection,Int32 startCustomerCode,Int32 endCustomerCode,Int32 totalDay,Int32 startTotalDay,Int32 endTotalDay,DateTime startAddUpDate,DateTime endAddUpDate,Int32 startAddUpYearMonth,Int32 endAddUpYearMonth,bool isOutputZeroBlance,bool isOutputAllSecRec,
			string startKana,string endKana,bool isAllCorporateDivCode,ArrayList corporateDivCodeList, bool isJudgeBillOutputCode,int employeeKind,string startEmployeeCode,string endEmployeeCode,Int32 startCustAnalysCode1,Int32 startCustAnalysCode2,Int32 startCustAnalysCode3,Int32 startCustAnalysCode4,Int32 startCustAnalysCode5,Int32 startCustAnalysCode6,Int32 endCustAnalysCode1,Int32 endCustAnalysCode2,Int32 endCustAnalysCode3,Int32 endCustAnalysCode4,Int32 endCustAnalysCode5,Int32 endCustAnalysCode6)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCodeList = addUpSecCodeList;
			this._isSelectAllSection = isSelectAllSection;
			this._startCustomerCode = startCustomerCode;
			this._endCustomerCode = endCustomerCode;
			this._totalDay = totalDay;
			this._startTotalDay = startTotalDay;
			this._endTotalDay = endTotalDay;
			this.StartAddUpDate = startAddUpDate;
			this.EndAddUpDate = endAddUpDate;
			this._startAddUpYearMonth = startAddUpYearMonth;
			this._endAddUpYearMonth = endAddUpYearMonth;
			this._isOutputZeroBlance = isOutputZeroBlance;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._startKana = startKana;
			this._endKana = endKana;
			this._isAllCorporateDivCode = isAllCorporateDivCode;
			this._corporateDivCodeList = corporateDivCodeList;
			this._isJudgeBillOutputCode = isJudgeBillOutputCode;
			this._employeeKind = employeeKind;
			this._startEmployeeCode = startEmployeeCode;
			this._endEmployeeCode = endEmployeeCode;
			this._startCustAnalysCode1 = startCustAnalysCode1;
			this._startCustAnalysCode2 = startCustAnalysCode2;
			this._startCustAnalysCode3 = startCustAnalysCode3;
			this._startCustAnalysCode4 = startCustAnalysCode4;
			this._startCustAnalysCode5 = startCustAnalysCode5;
			this._startCustAnalysCode6 = startCustAnalysCode6;
			this._endCustAnalysCode1 = endCustAnalysCode1;
			this._endCustAnalysCode2 = endCustAnalysCode2;
			this._endCustAnalysCode3 = endCustAnalysCode3;
			this._endCustAnalysCode4 = endCustAnalysCode4;
			this._endCustAnalysCode5 = endCustAnalysCode5;
			this._endCustAnalysCode6 = endCustAnalysCode6;
		}

		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X��������
		/// </summary>
		/// <returns>SeiKingetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SeiKingetParameter�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SeiKingetParameter Clone()
		{
			return new SeiKingetParameter(this._enterpriseCode,this._addUpSecCodeList,this._isSelectAllSection,this._startCustomerCode,this._endCustomerCode,this._totalDay,this._startTotalDay,this._endTotalDay,this._startAddUpDate,this._endAddUpDate,this._startAddUpYearMonth,this._endAddUpYearMonth,this._isOutputZeroBlance,this._isOutputAllSecRec,this._startKana,this._endKana,this._isAllCorporateDivCode,this._corporateDivCodeList,this._isJudgeBillOutputCode,this._employeeKind,this._startEmployeeCode,this._endEmployeeCode,this._startCustAnalysCode1,this._startCustAnalysCode2,this._startCustAnalysCode3,this._startCustAnalysCode4,this._startCustAnalysCode5,this._startCustAnalysCode6,this._endCustAnalysCode1,this._endCustAnalysCode2,this._endCustAnalysCode3,this._endCustAnalysCode4,this._endCustAnalysCode5,this._endCustAnalysCode6);
		}

		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�����������܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Clear()
		{
			this._enterpriseCode = "";
			this._addUpSecCodeList = new ArrayList();
			this._isSelectAllSection = false;
			this._startCustomerCode = 0;
			this._endCustomerCode = 0;
			this._totalDay = 0;
			this._startTotalDay = 0;
			this._endTotalDay = 0;
			this.StartAddUpDate = DateTime.MinValue;
			this.EndAddUpDate = DateTime.MinValue;
			this._startAddUpYearMonth = 0;
			this._endAddUpYearMonth = 0;
			this._isOutputZeroBlance = false;
			this._isOutputAllSecRec = false;
			this._startKana = "";
			this._endKana = "";
			this._isAllCorporateDivCode = false;
			this._corporateDivCodeList = new ArrayList();
			this._isJudgeBillOutputCode = false;
			this._employeeKind = 0;
			this._startEmployeeCode = "";
			this._endEmployeeCode = "";
			this._startCustAnalysCode1 = 0;
			this._startCustAnalysCode2 = 0;
			this._startCustAnalysCode3 = 0;
			this._startCustAnalysCode4 = 0;
			this._startCustAnalysCode5 = 0;
			this._startCustAnalysCode6 = 0;
			this._endCustAnalysCode1 = 999;
			this._endCustAnalysCode2 = 999;
			this._endCustAnalysCode3 = 999;
			this._endCustAnalysCode4 = 999;
			this._endCustAnalysCode5 = 999;
			this._endCustAnalysCode6 = 999;
		}

		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SeiKingetParameter�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SeiKingetParameter target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				&& (this._addUpSecCodeList.Equals(target.AddUpSecCodeList))
				&& (this.IsSelectAllSection == target.IsSelectAllSection)
				&& (this.StartCustomerCode == target.StartCustomerCode)
				&& (this.EndCustomerCode == target.EndCustomerCode)
				&& (this.TotalDay == target.TotalDay)
				&& (this.StartTotalDay == target.StartTotalDay)
				&& (this.EndTotalDay == target.EndTotalDay)
				&& (this.StartAddUpDate == target.StartAddUpDate)
				&& (this.EndAddUpDate == target.EndAddUpDate)
				&& (this.StartAddUpYearMonth == target.StartAddUpYearMonth)
				&& (this.EndAddUpYearMonth == target.EndAddUpYearMonth)
				&& (this.IsOutputZeroBlance == target.IsOutputZeroBlance)
				&& (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				&& (this.StartKana == target.StartKana)
				&& (this.EndKana == target.EndKana)
				&& (this.IsAllCorporateDivCode == target.IsAllCorporateDivCode)
				&& (this.CorporateDivCodeList == target.CorporateDivCodeList)
				&& (this.IsJudgeBillOutputCode == target.IsJudgeBillOutputCode)
				&& (this.StartEmployeeCode == target.StartEmployeeCode)
				&& (this.EndEmployeeCode == target.EndEmployeeCode)
				&& (this.StartCustAnalysCode1 == target.StartCustAnalysCode1)
				&& (this.StartCustAnalysCode2 == target.StartCustAnalysCode2)
				&& (this.StartCustAnalysCode3 == target.StartCustAnalysCode3)
				&& (this.StartCustAnalysCode4 == target.StartCustAnalysCode4)
				&& (this.StartCustAnalysCode5 == target.StartCustAnalysCode5)
				&& (this.StartCustAnalysCode6 == target.StartCustAnalysCode6)
				&& (this.EndCustAnalysCode1 == target.EndCustAnalysCode1)
				&& (this.EndCustAnalysCode2 == target.EndCustAnalysCode2)
				&& (this.EndCustAnalysCode3 == target.EndCustAnalysCode3)
				&& (this.EndCustAnalysCode4 == target.EndCustAnalysCode4)
				&& (this.EndCustAnalysCode5 == target.EndCustAnalysCode5)
				&& (this.EndCustAnalysCode6 == target.EndCustAnalysCode6)
				);
		}

		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="para1">��r����SeiKingetParameter�N���X�̃C���X�^���X</param>
		/// <param name="para2">��r����SeiKingetParameter�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SeiKingetParameter para1, SeiKingetParameter para2)
		{
			return ((para1.EnterpriseCode == para2.EnterpriseCode)
				&& (para1.AddUpSecCodeList.Equals(para2.AddUpSecCodeList))
				&& (para1.IsSelectAllSection == para2.IsSelectAllSection)
				&& (para1.StartCustomerCode == para2.StartCustomerCode)
				&& (para1.EndCustomerCode == para2.EndCustomerCode)
				&& (para1.TotalDay == para2.TotalDay)
				&& (para1.StartTotalDay == para2.StartTotalDay)
				&& (para1.EndTotalDay == para2.EndTotalDay)
				&& (para1.StartAddUpDate == para2.StartAddUpDate)
				&& (para1.EndAddUpDate == para2.EndAddUpDate)
				&& (para1.StartAddUpYearMonth == para2.StartAddUpYearMonth)
				&& (para1.EndAddUpYearMonth == para2.EndAddUpYearMonth)
				&& (para1.IsOutputZeroBlance == para2.IsOutputZeroBlance)
				&& (para1.IsOutputAllSecRec == para2.IsOutputAllSecRec)
				&& (para1.StartKana == para2.StartKana)
				&& (para1.EndKana == para2.EndKana)
				&& (para1.IsAllCorporateDivCode == para2.IsAllCorporateDivCode)
				&& (para1.CorporateDivCodeList == para2.CorporateDivCodeList)
				&& (para1.IsJudgeBillOutputCode == para2.IsJudgeBillOutputCode)
				&& (para1.StartEmployeeCode == para2.StartEmployeeCode)
				&& (para1.EndEmployeeCode == para2.EndEmployeeCode)
				&& (para1.StartCustAnalysCode1 == para2.StartCustAnalysCode1)
				&& (para1.StartCustAnalysCode2 == para2.StartCustAnalysCode2)
				&& (para1.StartCustAnalysCode3 == para2.StartCustAnalysCode3)
				&& (para1.StartCustAnalysCode4 == para2.StartCustAnalysCode4)
				&& (para1.StartCustAnalysCode5 == para2.StartCustAnalysCode5)
				&& (para1.StartCustAnalysCode6 == para2.StartCustAnalysCode6)
				&& (para1.EndCustAnalysCode1 == para2.EndCustAnalysCode1)
				&& (para1.EndCustAnalysCode2 == para2.EndCustAnalysCode2)
				&& (para1.EndCustAnalysCode3 == para2.EndCustAnalysCode3)
				&& (para1.EndCustAnalysCode4 == para2.EndCustAnalysCode4)
				&& (para1.EndCustAnalysCode5 == para2.EndCustAnalysCode5)
				&& (para1.EndCustAnalysCode6 == para2.EndCustAnalysCode6)
				);
		}
		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SeiKingetParameter�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SeiKingetParameter target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCodeList != target.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.StartCustomerCode != target.StartCustomerCode)resList.Add("StartCustomerCode");
			if(this.EndCustomerCode != target.EndCustomerCode)resList.Add("EndCustomerCode");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.StartTotalDay != target.StartTotalDay)resList.Add("StartTotalDay");
			if(this.EndTotalDay != target.EndTotalDay)resList.Add("EndTotalDay");
			if(this.StartAddUpDate != target.StartAddUpDate)resList.Add("StartAddUpDate");
			if(this.EndAddUpDate != target.EndAddUpDate)resList.Add("EndAddUpDate");
			if(this.StartAddUpYearMonth != target.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(this.EndAddUpYearMonth != target.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(this.IsOutputZeroBlance != target.IsOutputZeroBlance)resList.Add("IsOutputZeroBlance");
			if(this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(this.StartKana != target.StartKana)resList.Add("StartKana");
			if(this.EndKana != target.EndKana)resList.Add("EndKana");
			if(this.IsAllCorporateDivCode != target.IsAllCorporateDivCode)resList.Add("IsAllCorporateDivCode");
			if(this.CorporateDivCodeList != target.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
			if(this.IsJudgeBillOutputCode != target.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
			if(this.StartEmployeeCode != target.StartEmployeeCode)resList.Add("StartEmployeeCode");
			if(this.EndEmployeeCode != target.EndEmployeeCode)resList.Add("EndEmployeeCode");
			if(this.StartCustAnalysCode1 != target.StartCustAnalysCode1)resList.Add("StartCustAnalysCode1");
			if(this.StartCustAnalysCode2 != target.StartCustAnalysCode2)resList.Add("StartCustAnalysCode2");
			if(this.StartCustAnalysCode3 != target.StartCustAnalysCode3)resList.Add("StartCustAnalysCode3");
			if(this.StartCustAnalysCode4 != target.StartCustAnalysCode4)resList.Add("StartCustAnalysCode4");
			if(this.StartCustAnalysCode5 != target.StartCustAnalysCode5)resList.Add("StartCustAnalysCode5");
			if(this.StartCustAnalysCode6 != target.StartCustAnalysCode6)resList.Add("StartCustAnalysCode6");
			if(this.EndCustAnalysCode1 != target.EndCustAnalysCode1)resList.Add("EndCustAnalysCode1");
			if(this.EndCustAnalysCode2 != target.EndCustAnalysCode2)resList.Add("EndCustAnalysCode2");
			if(this.EndCustAnalysCode3 != target.EndCustAnalysCode3)resList.Add("EndCustAnalysCode3");
			if(this.EndCustAnalysCode4 != target.EndCustAnalysCode4)resList.Add("EndCustAnalysCode4");
			if(this.EndCustAnalysCode5 != target.EndCustAnalysCode5)resList.Add("EndCustAnalysCode5");
			if(this.EndCustAnalysCode6 != target.EndCustAnalysCode6)resList.Add("EndCustAnalysCode6");

			return resList;
		}

		/// <summary>
		/// ����KINGET�p���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="para1">��r����SeiKingetParameter�N���X�̃C���X�^���X</param>
		/// <param name="para2">��r����SeiKingetParameter�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetParameter�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SeiKingetParameter para1, SeiKingetParameter para2)
		{
			ArrayList resList = new ArrayList();
			if(para1.EnterpriseCode != para2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(para1.AddUpSecCodeList != para2.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(para1.IsSelectAllSection != para2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(para1.StartCustomerCode != para2.StartCustomerCode)resList.Add("StartCustomerCode");
			if(para1.EndCustomerCode != para2.EndCustomerCode)resList.Add("EndCustomerCode");
			if(para1.TotalDay != para2.TotalDay)resList.Add("TotalDay");
			if(para1.StartTotalDay != para2.StartTotalDay)resList.Add("StartTotalDay");
			if(para1.EndTotalDay != para2.EndTotalDay)resList.Add("EndTotalDay");
			if(para1.StartAddUpDate != para2.StartAddUpDate)resList.Add("StartAddUpDate");
			if(para1.EndAddUpDate != para2.EndAddUpDate)resList.Add("EndAddUpDate");
			if(para1.StartAddUpYearMonth != para2.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(para1.EndAddUpYearMonth != para2.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(para1.IsOutputZeroBlance != para2.IsOutputZeroBlance)resList.Add("IsOutputZeroBlance");
			if(para1.IsOutputAllSecRec != para2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(para1.StartKana != para2.StartKana)resList.Add("StartKana");
			if(para1.EndKana != para2.EndKana)resList.Add("EndKana");
			if(para1.IsAllCorporateDivCode != para2.IsAllCorporateDivCode)resList.Add("IsAllCorporateDivCode");
			if(para1.CorporateDivCodeList != para2.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
			if(para1.IsJudgeBillOutputCode != para2.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
			if(para1.StartEmployeeCode != para2.StartEmployeeCode)resList.Add("StartEmployeeCode");
			if(para1.EndEmployeeCode != para2.EndEmployeeCode)resList.Add("EndEmployeeCode");
			if(para1.StartCustAnalysCode1 != para2.StartCustAnalysCode1)resList.Add("StartCustAnalysCode1");
			if(para1.StartCustAnalysCode2 != para2.StartCustAnalysCode2)resList.Add("StartCustAnalysCode2");
			if(para1.StartCustAnalysCode3 != para2.StartCustAnalysCode3)resList.Add("StartCustAnalysCode3");
			if(para1.StartCustAnalysCode4 != para2.StartCustAnalysCode4)resList.Add("StartCustAnalysCode4");
			if(para1.StartCustAnalysCode5 != para2.StartCustAnalysCode5)resList.Add("StartCustAnalysCode5");
			if(para1.StartCustAnalysCode6 != para2.StartCustAnalysCode6)resList.Add("StartCustAnalysCode6");
			if(para1.EndCustAnalysCode1 != para2.EndCustAnalysCode1)resList.Add("EndCustAnalysCode1");
			if(para1.EndCustAnalysCode2 != para2.EndCustAnalysCode2)resList.Add("EndCustAnalysCode2");
			if(para1.EndCustAnalysCode3 != para2.EndCustAnalysCode3)resList.Add("EndCustAnalysCode3");
			if(para1.EndCustAnalysCode4 != para2.EndCustAnalysCode4)resList.Add("EndCustAnalysCode4");
			if(para1.EndCustAnalysCode5 != para2.EndCustAnalysCode5)resList.Add("EndCustAnalysCode5");
			if(para1.EndCustAnalysCode6 != para2.EndCustAnalysCode6)resList.Add("EndCustAnalysCode6");

			return resList;
		}
	}
}

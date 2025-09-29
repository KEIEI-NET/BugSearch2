using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �擾�Ώۃf�[�^�萔�i���[�U�[�K�C�h�p�j
	/// </summary>
	/// <br>Note       : ���[�U�[�K�C�h�}�X�^�̎擾�Ώۃf�[�^�i�K�C�h�敪�j�̗񋓌^�ł��B</br>
	/// <br>Programmer : 22024�@����@�_�u</br>
	/// <br>Date       : 2005.06.14</br>
	public enum UserGdGuideDivCodeAcsData
	{
		/// <summary>
		/// ��E�敪
		/// </summary>
		PostCode = 32,
		/// <summary>
		/// �Ɩ��敪
		/// </summary>
		BusinessCode = 31
	}

	/// public class name:   Employee
	/// <summary>
	///                      �]�ƈ��N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �]�ƈ��N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/3/4</br>
	/// <br>Genarated Date   :   2005/03/19  (CSharp File Generated Date)</br>
	/// <br></br>
	/// <br>Update Note		 : 2006.06.20 23001 �H�R�@����</br>
	/// <br>                        1.���o���[�g�����ނ�DD�̕ύX�Ή�</br>
	/// <br>Update Note		 : 2006.07.31 22033 �O��  �M�j</br>
	/// <br>                        1.namespace�ύX�Ή�</br>
	/// <br>Update Note		 : 2012.05.09 30182 ���J�@����</br>
	/// <br>						1.�u����`�[���͋N�������v�u���Ӑ�d�q�����N�������v���ڒǉ�</br>
	/// </remarks>
	public class Employee
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
		private Int32 _logicalDeleteCode;

		/// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>�J�i</summary>
		private string _kana = "";

		/// <summary>�Z�k����</summary>
		private string _shortName = "";

		/// <summary>���ʃR�[�h</summary>
		private Int32 _sexCode;

		/// <summary>���ʖ���</summary>
		/// <remarks>�S�p�ŊǗ�</remarks>
		private string _sexName = "";

		/// <summary>���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _birthday;

		/// <summary>�d�b�ԍ��i��Ёj</summary>
		private string _companyTelNo = "";

		/// <summary>�d�b�ԍ��i�g�сj</summary>
		private string _portableTelNo = "";

		/// <summary>��E�R�[�h</summary>
		private Int32 _postCode;

		/// <summary>�Ɩ��敪</summary>
		private Int32 _businessCode;

		/// <summary>��t�E���J�敪</summary>
		private Int32 _frontMechaCode;

		/// <summary>�Г��O�敪</summary>
		private Int32 _inOutsideCompanyCode;

		/// <summary>�������_�R�[�h</summary>
		private string _belongSectionCode = "";

		/// <summary>���o���[�g�����i��ʁj</summary>
		private Int64 _lvrRtCstGeneral;

		/// <summary>���o���[�g�����i�Ԍ��j</summary>
		private Int64 _lvrRtCstCarInspect;

		/// <summary>���o���[�g�����i�h���j</summary>
		private Int64 _lvrRtCstBodyPaint;

		/// <summary>���o���[�g�����i����j</summary>
		private Int64 _lvrRtCstBodyRepair;

		/// <summary>���O�C��ID</summary>
		private string _loginId = "";

		/// <summary>���O�C���p�X���[�h</summary>
		private string _loginPassword = "";

		/// <summary>���[�U�[�Ǘ��҃t���O</summary>
		private Int32 _userAdminFlag;

		/// <summary>���Г�</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _enterCompanyDate;

		/// <summary>�ސE��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _retirementDate;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>��E����</summary>
		private string _postName = "";

		/// <summary>�Ɩ��敪����</summary>
		private string _businessName = "";

		/// <summary>��t�E���J�敪����</summary>
		private string _frontMechaName = "";

		/// <summary>�������_����</summary>
		private string _belongSectionName = "";

		/// <summary>�Г��O�敪����</summary>
		/// <remarks>�Г�,�ЊO</remarks>
		private string _inOutsideCompanyName = "";

		/// <summary>���[�U�[�Ǘ��ҕ\������</summary>
		private string _userAdminName = "";

        /// <summary>�������x��1(�E��)</summary>
        private int _authorityLevel1;

        /// <summary>�������x��2(�ٗp�`��)</summary>
        private int _authorityLevel2;

		// -- Add St 2012.05.29 30182 R.Tachiya --
		/// <summary>����`�[���͋N������</summary>
		private int _salSlipInpBootCnt;

		/// <summary>���Ӑ�d�q�����N������</summary>
		private int _custLedgerBootCnt;		
		// -- Add Ed 2012.05.29 30182 R.Tachiya --

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
			get
			{
				return _createDateTime;
			}
			set
			{
				_createDateTime = value;
			}
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
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return _updateDateTime;
			}
			set
			{
				_updateDateTime = value;
			}
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
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return _enterpriseCode;
			}
			set
			{
				_enterpriseCode = value;
			}
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
			get
			{
				return _fileHeaderGuid;
			}
			set
			{
				_fileHeaderGuid = value;
			}
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
			get
			{
				return _updEmployeeCode;
			}
			set
			{
				_updEmployeeCode = value;
			}
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
			get
			{
				return _updAssemblyId1;
			}
			set
			{
				_updAssemblyId1 = value;
			}
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
			get
			{
				return _updAssemblyId2;
			}
			set
			{
				_updAssemblyId2 = value;
			}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get
			{
				return _logicalDeleteCode;
			}
			set
			{
				_logicalDeleteCode = value;
			}
		}

		/// public propaty name  :  EmployeeCode
		/// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeCode
		{
			get
			{
				return _employeeCode;
			}
			set
			{
				_employeeCode = value;
			}
		}

		/// public propaty name  :  Name
		/// <summary>���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// public propaty name  :  Kana
		/// <summary>�J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Kana
		{
			get
			{
				return _kana;
			}
			set
			{
				_kana = value;
			}
		}

		/// public propaty name  :  ShortName
		/// <summary>�Z�k���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�k���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ShortName
		{
			get
			{
				return _shortName;
			}
			set
			{
				_shortName = value;
			}
		}

		/// public propaty name  :  SexCode
		/// <summary>���ʃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SexCode
		{
			get
			{
				return _sexCode;
			}
			set
			{
				_sexCode = value;
			}
		}

		/// public propaty name  :  SexName
		/// <summary>���ʖ��̃v���p�e�B</summary>
		/// <value>�S�p�ŊǗ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SexName
		{
			get
			{
				return _sexName;
			}
			set
			{
				_sexName = value;
			}
		}

		/// public propaty name  :  Birthday
		/// <summary>���N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Birthday
		{
			get
			{
				return _birthday;
			}
			set
			{
				_birthday = value;
			}
		}

		/// public propaty name  :  BirthdayJpFormal
		/// <summary>���N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BirthdayJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  BirthdayJpInFormal
		/// <summary>���N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BirthdayJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  BirthdayAdFormal
		/// <summary>���N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BirthdayAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  BirthdayAdInFormal
		/// <summary>���N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BirthdayAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  CompanyTelNo
		/// <summary>�d�b�ԍ��i��Ёj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i��Ёj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo
		{
			get
			{
				return _companyTelNo;
			}
			set
			{
				_companyTelNo = value;
			}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PortableTelNo
		{
			get
			{
				return _portableTelNo;
			}
			set
			{
				_portableTelNo = value;
			}
		}

		/// public propaty name  :  PostCode
		/// <summary>��E�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��E�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PostCode
		{
			get
			{
				return _postCode;
			}
			set
			{
				_postCode = value;
			}
		}

		/// public propaty name  :  BusinessCode
		/// <summary>�Ɩ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ɩ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BusinessCode
		{
			get
			{
				return _businessCode;
			}
			set
			{
				_businessCode = value;
			}
		}

		/// public propaty name  :  FrontMechaCode
		/// <summary>��t�E���J�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�E���J�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FrontMechaCode
		{
			get
			{
				return _frontMechaCode;
			}
			set
			{
				_frontMechaCode = value;
			}
		}

		/// public propaty name  :  InOutsideCompanyCode
		/// <summary>�Г��O�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г��O�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InOutsideCompanyCode
		{
			get
			{
				return _inOutsideCompanyCode;
			}
			set
			{
				_inOutsideCompanyCode = value;
			}
		}

		/// public propaty name  :  BelongSectionCode
		/// <summary>�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BelongSectionCode
		{
			get
			{
				return _belongSectionCode;
			}
			set
			{
				_belongSectionCode = value;
			}
		}

		/// public propaty name  :  LvrRtCstGeneral
		/// <summary>���o���[�g�����i��ʁj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���[�g�����i��ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LvrRtCstGeneral
		{
			get
			{
				return _lvrRtCstGeneral;
			}
			set
			{
				_lvrRtCstGeneral = value;
			}
		}

		/// public propaty name  :  LvrRtCstCarInspect
		/// <summary>���o���[�g�����i�Ԍ��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���[�g�����i�Ԍ��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LvrRtCstCarInspect
		{
			get
			{
				return _lvrRtCstCarInspect;
			}
			set
			{
				_lvrRtCstCarInspect = value;
			}
		}

		/// public propaty name  :  LvrRtCstBodyPaint
		/// <summary>���o���[�g�����i�h���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���[�g�����i�h���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LvrRtCstBodyPaint
		{
			get
			{
				return _lvrRtCstBodyPaint;
			}
			set
			{
				_lvrRtCstBodyPaint = value;
			}
		}

		/// public propaty name  :  LvrRtCstBodyRepair
		/// <summary>���o���[�g�����i����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���[�g�����i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LvrRtCstBodyRepair
		{
			get
			{
				return _lvrRtCstBodyRepair;
			}
			set
			{
				_lvrRtCstBodyRepair = value;
			}
		}

		/// public propaty name  :  LoginId
		/// <summary>���O�C��ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�C��ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LoginId
		{
			get
			{
				return _loginId;
			}
			set
			{
				_loginId = value;
			}
		}

		/// public propaty name  :  LoginPassword
		/// <summary>���O�C���p�X���[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���O�C���p�X���[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LoginPassword
		{
			get
			{
				return _loginPassword;
			}
			set
			{
				_loginPassword = value;
			}
		}

		/// public propaty name  :  UserAdminFlag
		/// <summary>���[�U�[�Ǘ��҃t���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[�Ǘ��҃t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserAdminFlag
		{
			get
			{
				return _userAdminFlag;
			}
			set
			{
				_userAdminFlag = value;
			}
		}

		/// public propaty name  :  EnterCompanyDate
		/// <summary>���Г��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Г��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime EnterCompanyDate
		{
			get
			{
				return _enterCompanyDate;
			}
			set
			{
				_enterCompanyDate = value;
			}
		}

		/// public propaty name  :  EnterCompanyDateJpFormal
		/// <summary>���Г� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Г� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterCompanyDateJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  EnterCompanyDateJpInFormal
		/// <summary>���Г� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Г� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterCompanyDateJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  EnterCompanyDateAdFormal
		/// <summary>���Г� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Г� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterCompanyDateAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  EnterCompanyDateAdInFormal
		/// <summary>���Г� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Г� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterCompanyDateAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDate
		/// <summary>�ސE���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ސE���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime RetirementDate
		{
			get
			{
				return _retirementDate;
			}
			set
			{
				_retirementDate = value;
			}
		}

		/// public propaty name  :  RetirementDateJpFormal
		/// <summary>�ސE�� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ސE�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RetirementDateJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _retirementDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDateJpInFormal
		/// <summary>�ސE�� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ސE�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RetirementDateJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _retirementDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDateAdFormal
		/// <summary>�ސE�� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ސE�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RetirementDateAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _retirementDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDateAdInFormal
		/// <summary>�ސE�� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ސE�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RetirementDateAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _retirementDate);
			}
			set
			{
			}
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
			get
			{
				return _enterpriseName;
			}
			set
			{
				_enterpriseName = value;
			}
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
			get
			{
				return _updEmployeeName;
			}
			set
			{
				_updEmployeeName = value;
			}
		}

		/// public propaty name  :  PostName
		/// <summary>��E���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��E���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PostName
		{
			get
			{
				return _postName;
			}
			set
			{
				_postName = value;
			}
		}

		/// public propaty name  :  BusinessName
		/// <summary>�Ɩ��敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ɩ��敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BusinessName
		{
			get
			{
				return _businessName;
			}
			set
			{
				_businessName = value;
			}
		}

		/// public propaty name  :  FrontMechaName
		/// <summary>��t�E���J�敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�E���J�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontMechaName
		{
			get
			{
				return _frontMechaName;
			}
			set
			{
				_frontMechaName = value;
			}
		}

		/// public propaty name  :  BelongSectionName
		/// <summary>�������_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BelongSectionName
		{
			get
			{
				return _belongSectionName;
			}
			set
			{
				_belongSectionName = value;
			}
		}

		/// public propaty name  :  InOutsideCompanyName
		/// <summary>�Г��O�敪���̃v���p�e�B</summary>
		/// <value>�Г�,�ЊO</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г��O�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InOutsideCompanyName
		{
			get
			{
				return _inOutsideCompanyName;
			}
			set
			{
				_inOutsideCompanyName = value;
			}
		}

		/// public propaty name  :  UserAdminName
		/// <summary>���[�U�[�Ǘ��ҕ\������</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[�Ǘ��ҕ\�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UserAdminName
		{
			get
			{
				return _userAdminName;
			}
			set
			{
				_userAdminName = value;
			}
		}

        /// public propaty name  :  AuthorityLevel1
        /// <summary>�������x��1(�E��)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x��1(�E��)�v���p�e�B</br>
        /// <br>Programer        :   20008 �ɓ��@�L</br>
        /// </remarks>
        public int AuthorityLevel1
        {
            get
            {
                return _authorityLevel1;
            }
            set
            {
                _authorityLevel1 = value;
            }
        }

        /// public propaty name  :  AuthorityLevel2
        /// <summary>�������x��2(�ٗp�`��)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x��2(�ٗp�`��)�v���p�e�B</br>
        /// <br>Programer        :   20008 �ɓ��@�L</br>
        /// </remarks>
        public int AuthorityLevel2
        {
            get
            {
                return _authorityLevel2;
            }
            set
            {
                _authorityLevel2 = value;
            }
        }

		// -- Add St 2012.05.29 30182 R.Tachiya --
		/// public propaty name  :  SalSlipInpBootCnt
		/// <summary>����`�[���͋N������</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���͋N�������v���p�e�B</br>
		/// <br>Programer        :   30182 ���J�@����</br>
		/// </remarks>
		public int SalSlipInpBootCnt
        {
            get
            {
				return _salSlipInpBootCnt;
            }
            set
            {
				_salSlipInpBootCnt = value;
            }
        }

		/// public propaty name  :  CustLedgerBootCnt
		/// <summary>���Ӑ�d�q�����N������</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�d�q�����N�������v���p�e�B</br>
		/// <br>Programer        :   30182 ���J�@����</br>
		/// </remarks>
		public int CustLedgerBootCnt
        {
            get
            {
				return _custLedgerBootCnt;
            }
            set
            {
				_custLedgerBootCnt = value;
            }
        }
		// -- Add Ed 2012.05.29 30182 R.Tachiya --

        /// <summary>
		/// �]�ƈ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>Employee�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Employee�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Employee()
		{
		}

		/// <summary>
		/// �]�ƈ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="name">����</param>
		/// <param name="kana">�J�i</param>
		/// <param name="shortName">�Z�k����</param>
		/// <param name="sexCode">���ʃR�[�h</param>
		/// <param name="sexName">���ʖ���(�S�p�ŊǗ�)</param>
		/// <param name="birthday">���N����(YYYYMMDD)</param>
		/// <param name="companyTelNo">�d�b�ԍ��i��Ёj</param>
		/// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
		/// <param name="postCode">��E�R�[�h</param>
		/// <param name="businessCode">�Ɩ��敪</param>
		/// <param name="frontMechaCode">��t�E���J�敪</param>
		/// <param name="inOutsideCompanyCode">�Г��O�敪</param>
		/// <param name="belongSectionCode">�������_�R�[�h</param>
		/// <param name="lvrRtCstGeneral">���o���[�g�����i��ʁj</param>
		/// <param name="lvrRtCstCarInspect">���o���[�g�����i�Ԍ��j</param>
		/// <param name="lvrRtCstBodyPaint">���o���[�g�����i�h���j</param>
		/// <param name="lvrRtCstBodyRepair">���o���[�g�����i����j</param>
		/// <param name="loginId">���O�C��ID</param>
		/// <param name="loginPassword">���O�C���p�X���[�h</param>
		/// <param name="userAdminFlag">���[�U�[�Ǘ��҃t���O</param>
		/// <param name="enterCompanyDate">���Г�(YYYYMMDD)</param>
		/// <param name="retirementDate">�ސE��(YYYYMMDD)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="postName">��E����</param>
		/// <param name="businessName">�Ɩ��敪����</param>
		/// <param name="frontMechaName">��t�E���J�敪����</param>
		/// <param name="belongSectionName">�������_����</param>
		/// <param name="inOutsideCompanyName">�Г��O�敪����(�Г�,�ЊO)</param>
		/// <param name="userAdminName">���[�U�[�Ǘ��ҕ\������</param>
        /// <param name="authorityLevel1">�������x��1(�E��)</param>
        /// <param name="authorityLevel2">�������x��2(�ٗp�`��)</param>
		/// <param name="salSlipInpBootCnt">����`�[���͋N������</param>
		/// <param name="custLedgerBootCnt">���Ӑ�d�q�����N������</param>
		/// <returns>Employee�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Employee�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Employee(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, string name, string kana, string shortName, Int32 sexCode, string sexName, DateTime birthday, string companyTelNo, string portableTelNo, Int32 postCode, Int32 businessCode, Int32 frontMechaCode, Int32 inOutsideCompanyCode, string belongSectionCode, Int64 lvrRtCstGeneral, Int64 lvrRtCstCarInspect, Int64 lvrRtCstBodyPaint, Int64 lvrRtCstBodyRepair, string loginId, string loginPassword, Int32 userAdminFlag, DateTime enterCompanyDate, DateTime retirementDate, string enterpriseName, string updEmployeeName, string postName, string businessName, string frontMechaName, string belongSectionName, string inOutsideCompanyName, string userAdminName, int authorityLevel1, int authorityLevel2, int salSlipInpBootCnt, int custLedgerBootCnt)// -- Add 2012.05.29 30182 R.Tachiya --
		//public Employee(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, string name, string kana, string shortName, Int32 sexCode, string sexName, DateTime birthday, string companyTelNo, string portableTelNo, Int32 postCode, Int32 businessCode, Int32 frontMechaCode, Int32 inOutsideCompanyCode, string belongSectionCode, Int64 lvrRtCstGeneral, Int64 lvrRtCstCarInspect, Int64 lvrRtCstBodyPaint, Int64 lvrRtCstBodyRepair, string loginId, string loginPassword, Int32 userAdminFlag, DateTime enterCompanyDate, DateTime retirementDate, string enterpriseName, string updEmployeeName, string postName, string businessName, string frontMechaName, string belongSectionName, string inOutsideCompanyName, string userAdminName, int authorityLevel1, int authorityLevel2)// -- Del 2012.05.29 30182 R.Tachiya --
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._employeeCode = employeeCode;
			this._name = name;
			this._kana = kana;
			this._shortName = shortName;
			this._sexCode = sexCode;
			this._sexName = sexName;
			this.Birthday = birthday;
			this._companyTelNo = companyTelNo;
			this._portableTelNo = portableTelNo;
			this._postCode = postCode;
			this._businessCode = businessCode;
			this._frontMechaCode = frontMechaCode;
			this._inOutsideCompanyCode = inOutsideCompanyCode;
			this._belongSectionCode = belongSectionCode;
			this._lvrRtCstGeneral = lvrRtCstGeneral;
			this._lvrRtCstCarInspect = lvrRtCstCarInspect;
			this._lvrRtCstBodyPaint = lvrRtCstBodyPaint;
			this._lvrRtCstBodyRepair = lvrRtCstBodyRepair;
			this._loginId = loginId;
			this._loginPassword = loginPassword;
			this._userAdminFlag = userAdminFlag;
			this.EnterCompanyDate = enterCompanyDate;
			this.RetirementDate = retirementDate;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._postName = postName;
			this._businessName = businessName;
			this._frontMechaName = frontMechaName;
			this._belongSectionName = belongSectionName;
			this._inOutsideCompanyName = inOutsideCompanyName;
			this._userAdminName = userAdminName;
            this._authorityLevel1 = authorityLevel1;
            this._authorityLevel2 = authorityLevel2;
			// -- Add St 2012.05.29 30182 R.Tachiya --
			this._salSlipInpBootCnt = salSlipInpBootCnt;
			this._custLedgerBootCnt = custLedgerBootCnt;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

		}

		/// <summary>
		/// �]�ƈ��}�X�^��������
		/// </summary>
		/// <returns>Employee�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Employee�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Employee Clone()
		{
			return new Employee(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._name, this._kana, this._shortName, this._sexCode, this._sexName, this._birthday, this._companyTelNo, this._portableTelNo, this._postCode, this._businessCode, this._frontMechaCode, this._inOutsideCompanyCode, this._belongSectionCode, this._lvrRtCstGeneral, this._lvrRtCstCarInspect, this._lvrRtCstBodyPaint, this._lvrRtCstBodyRepair, this._loginId, this._loginPassword, this._userAdminFlag, this._enterCompanyDate, this._retirementDate, this._enterpriseName, this._updEmployeeName, this._postName, this._businessName, this._frontMechaName, this._belongSectionName, this._inOutsideCompanyName, this._userAdminName, this._authorityLevel1, this._authorityLevel2, this._salSlipInpBootCnt, this._custLedgerBootCnt);// -- Add 2012.05.29 30182 R.Tachiya --
			//return new Employee(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._name, this._kana, this._shortName, this._sexCode, this._sexName, this._birthday, this._companyTelNo, this._portableTelNo, this._postCode, this._businessCode, this._frontMechaCode, this._inOutsideCompanyCode, this._belongSectionCode, this._lvrRtCstGeneral, this._lvrRtCstCarInspect, this._lvrRtCstBodyPaint, this._lvrRtCstBodyRepair, this._loginId, this._loginPassword, this._userAdminFlag, this._enterCompanyDate, this._retirementDate, this._enterpriseName, this._updEmployeeName, this._postName, this._businessName, this._frontMechaName, this._belongSectionName, this._inOutsideCompanyName, this._userAdminName, this._authorityLevel1, this._authorityLevel2);// -- Del 2012.05.29 30182 R.Tachiya --
		}

		/// <summary>
		/// �]�ƈ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Employee�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Employee�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(Employee target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.EmployeeCode == target.EmployeeCode)
				 && (this.Name == target.Name)
				 && (this.Kana == target.Kana)
				 && (this.ShortName == target.ShortName)
				 && (this.SexCode == target.SexCode)
				 && (this.SexName == target.SexName)
				 && (this.Birthday == target.Birthday)
				 && (this.CompanyTelNo == target.CompanyTelNo)
				 && (this.PortableTelNo == target.PortableTelNo)
				 && (this.PostCode == target.PostCode)
				 && (this.BusinessCode == target.BusinessCode)
				 && (this.FrontMechaCode == target.FrontMechaCode)
				 && (this.InOutsideCompanyCode == target.InOutsideCompanyCode)
				 && (this.BelongSectionCode == target.BelongSectionCode)
				 && (this.LvrRtCstGeneral == target.LvrRtCstGeneral)
				 && (this.LvrRtCstCarInspect == target.LvrRtCstCarInspect)
				 && (this.LvrRtCstBodyPaint == target.LvrRtCstBodyPaint)
				 && (this.LvrRtCstBodyRepair == target.LvrRtCstBodyRepair)
				 && (this.LoginId == target.LoginId)
				 && (this.LoginPassword == target.LoginPassword)
				 && (this.UserAdminFlag == target.UserAdminFlag)
				 && (this.EnterCompanyDate == target.EnterCompanyDate)
				 && (this.RetirementDate == target.RetirementDate)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.PostName == target.PostName)
				 && (this.BusinessName == target.BusinessName)
				 && (this.FrontMechaName == target.FrontMechaName)
				 && (this.BelongSectionName == target.BelongSectionName)
				 && (this.InOutsideCompanyName == target.InOutsideCompanyName)
				 && (this.UserAdminName == target.UserAdminName)
				 && (this.AuthorityLevel1 == target.AuthorityLevel1)
				 && (this.AuthorityLevel2 == target.AuthorityLevel2)// -- Update 2012.05.29 30182 R.Tachiya --
				// -- Add St 2012.05.29 30182 R.Tachiya --
				 && (this.SalSlipInpBootCnt == target.SalSlipInpBootCnt)
				 && (this.CustLedgerBootCnt == target.CustLedgerBootCnt));
				// -- Add Ed 2012.05.29 30182 R.Tachiya --				
		}

		/// <summary>
		/// �]�ƈ��}�X�^��r����
		/// </summary>
		/// <param name="employee1">
		///                    ��r����Employee�N���X�̃C���X�^���X
		/// </param>
		/// <param name="employee2">��r����Employee�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Employee�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(Employee employee1, Employee employee2)
		{
			return ((employee1.CreateDateTime == employee2.CreateDateTime)
				 && (employee1.UpdateDateTime == employee2.UpdateDateTime)
				 && (employee1.EnterpriseCode == employee2.EnterpriseCode)
				 && (employee1.FileHeaderGuid == employee2.FileHeaderGuid)
				 && (employee1.UpdEmployeeCode == employee2.UpdEmployeeCode)
				 && (employee1.UpdAssemblyId1 == employee2.UpdAssemblyId1)
				 && (employee1.UpdAssemblyId2 == employee2.UpdAssemblyId2)
				 && (employee1.LogicalDeleteCode == employee2.LogicalDeleteCode)
				 && (employee1.EmployeeCode == employee2.EmployeeCode)
				 && (employee1.Name == employee2.Name)
				 && (employee1.Kana == employee2.Kana)
				 && (employee1.ShortName == employee2.ShortName)
				 && (employee1.SexCode == employee2.SexCode)
				 && (employee1.SexName == employee2.SexName)
				 && (employee1.Birthday == employee2.Birthday)
				 && (employee1.CompanyTelNo == employee2.CompanyTelNo)
				 && (employee1.PortableTelNo == employee2.PortableTelNo)
				 && (employee1.PostCode == employee2.PostCode)
				 && (employee1.BusinessCode == employee2.BusinessCode)
				 && (employee1.FrontMechaCode == employee2.FrontMechaCode)
				 && (employee1.InOutsideCompanyCode == employee2.InOutsideCompanyCode)
				 && (employee1.BelongSectionCode == employee2.BelongSectionCode)
				 && (employee1.LvrRtCstGeneral == employee2.LvrRtCstGeneral)
				 && (employee1.LvrRtCstCarInspect == employee2.LvrRtCstCarInspect)
				 && (employee1.LvrRtCstBodyPaint == employee2.LvrRtCstBodyPaint)
				 && (employee1.LvrRtCstBodyRepair == employee2.LvrRtCstBodyRepair)
				 && (employee1.LoginId == employee2.LoginId)
				 && (employee1.LoginPassword == employee2.LoginPassword)
				 && (employee1.UserAdminFlag == employee2.UserAdminFlag)
				 && (employee1.EnterCompanyDate == employee2.EnterCompanyDate)
				 && (employee1.RetirementDate == employee2.RetirementDate)
				 && (employee1.EnterpriseName == employee2.EnterpriseName)
				 && (employee1.UpdEmployeeName == employee2.UpdEmployeeName)
				 && (employee1.PostName == employee2.PostName)
				 && (employee1.BusinessName == employee2.BusinessName)
				 && (employee1.FrontMechaName == employee2.FrontMechaName)
				 && (employee1.BelongSectionName == employee2.BelongSectionName)
				 && (employee1.InOutsideCompanyName == employee2.InOutsideCompanyName)
				 && (employee1.UserAdminName == employee2.UserAdminName)
                 && (employee1.AuthorityLevel1 == employee2.AuthorityLevel1)
				 && (employee1.AuthorityLevel2 == employee2.AuthorityLevel2)// -- Update 2012.05.29 30182 R.Tachiya --
				// -- Add St 2012.05.29 30182 R.Tachiya --
				 && (employee1.SalSlipInpBootCnt == employee2.SalSlipInpBootCnt)
				 && (employee1.CustLedgerBootCnt == employee2.CustLedgerBootCnt));
				// -- Add Ed 2012.05.29 30182 R.Tachiya --				
		}
		/// <summary>
		/// �]�ƈ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Employee�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Employee�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(Employee target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime)
				resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (this.EnterpriseCode != target.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (this.FileHeaderGuid != target.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (this.UpdEmployeeCode != target.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (this.UpdAssemblyId1 != target.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (this.UpdAssemblyId2 != target.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (this.EmployeeCode != target.EmployeeCode)
				resList.Add("EmployeeCode");
			if (this.Name != target.Name)
				resList.Add("Name");
			if (this.Kana != target.Kana)
				resList.Add("Kana");
			if (this.ShortName != target.ShortName)
				resList.Add("ShortName");
			if (this.SexCode != target.SexCode)
				resList.Add("SexCode");
			if (this.SexName != target.SexName)
				resList.Add("SexName");
			if (this.Birthday != target.Birthday)
				resList.Add("Birthday");
			if (this.CompanyTelNo != target.CompanyTelNo)
				resList.Add("CompanyTelNo");
			if (this.PortableTelNo != target.PortableTelNo)
				resList.Add("PortableTelNo");
			if (this.PostCode != target.PostCode)
				resList.Add("PostCode");
			if (this.BusinessCode != target.BusinessCode)
				resList.Add("BusinessCode");
			if (this.FrontMechaCode != target.FrontMechaCode)
				resList.Add("FrontMechaCode");
			if (this.InOutsideCompanyCode != target.InOutsideCompanyCode)
				resList.Add("InOutsideCompanyCode");
			if (this.BelongSectionCode != target.BelongSectionCode)
				resList.Add("BelongSectionCode");
			if (this.LvrRtCstGeneral != target.LvrRtCstGeneral)
				resList.Add("LvrRtCstGeneral");
			if (this.LvrRtCstCarInspect != target.LvrRtCstCarInspect)
				resList.Add("LvrRtCstCarInspect");
			if (this.LvrRtCstBodyPaint != target.LvrRtCstBodyPaint)
				resList.Add("LvrRtCstBodyPaint");
			if (this.LvrRtCstBodyRepair != target.LvrRtCstBodyRepair)
				resList.Add("LvrRtCstBodyRepair");
			if (this.LoginId != target.LoginId)
				resList.Add("LoginId");
			if (this.LoginPassword != target.LoginPassword)
				resList.Add("LoginPassword");
			if (this.UserAdminFlag != target.UserAdminFlag)
				resList.Add("UserAdminFlag");
			if (this.EnterCompanyDate != target.EnterCompanyDate)
				resList.Add("EnterCompanyDate");
			if (this.RetirementDate != target.RetirementDate)
				resList.Add("RetirementDate");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (this.PostName != target.PostName)
				resList.Add("PostName");
			if (this.BusinessName != target.BusinessName)
				resList.Add("BusinessName");
			if (this.FrontMechaName != target.FrontMechaName)
				resList.Add("FrontMechaName");
			if (this.BelongSectionName != target.BelongSectionName)
				resList.Add("BelongSectionName");
			if (this.InOutsideCompanyName != target.InOutsideCompanyName)
				resList.Add("InOutsideCompanyName");
			if (this.UserAdminName != target.LoginPassword)
				resList.Add("UserAdminName");
            if (this.AuthorityLevel1 != target.AuthorityLevel1)
                resList.Add("AuthorityLevel1");
            if (this.AuthorityLevel2 != target.AuthorityLevel2)
                resList.Add("AuthorityLevel2");
			// -- Add St 2012.05.29 30182 R.Tachiya --
			if (this.SalSlipInpBootCnt != target.SalSlipInpBootCnt)
				resList.Add("SalSlipInpBootCnt");
			if (this.CustLedgerBootCnt != target.CustLedgerBootCnt)
				resList.Add("CustLedgerBootCnt");
			// -- Add Ed 2012.05.29 30182 R.Tachiya --				

			return resList;
		}

		/// <summary>
		/// �]�ƈ��}�X�^��r����
		/// </summary>
		/// <param name="employee1">��r����Employee�N���X�̃C���X�^���X</param>
		/// <param name="employee2">��r����Employee�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Employee�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(Employee employee1, Employee employee2)
		{
			ArrayList resList = new ArrayList();
			if (employee1.CreateDateTime != employee2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (employee1.UpdateDateTime != employee2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (employee1.EnterpriseCode != employee2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (employee1.FileHeaderGuid != employee2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (employee1.UpdEmployeeCode != employee2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (employee1.UpdAssemblyId1 != employee2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (employee1.UpdAssemblyId2 != employee2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (employee1.LogicalDeleteCode != employee2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (employee1.EmployeeCode != employee2.EmployeeCode)
				resList.Add("EmployeeCode");
			if (employee1.Name != employee2.Name)
				resList.Add("Name");
			if (employee1.Kana != employee2.Kana)
				resList.Add("Kana");
			if (employee1.ShortName != employee2.ShortName)
				resList.Add("ShortName");
			if (employee1.SexCode != employee2.SexCode)
				resList.Add("SexCode");
			if (employee1.SexName != employee2.SexName)
				resList.Add("SexName");
			if (employee1.Birthday != employee2.Birthday)
				resList.Add("Birthday");
			if (employee1.CompanyTelNo != employee2.CompanyTelNo)
				resList.Add("CompanyTelNo");
			if (employee1.PortableTelNo != employee2.PortableTelNo)
				resList.Add("PortableTelNo");
			if (employee1.PostCode != employee2.PostCode)
				resList.Add("PostCode");
			if (employee1.BusinessCode != employee2.BusinessCode)
				resList.Add("BusinessCode");
			if (employee1.FrontMechaCode != employee2.FrontMechaCode)
				resList.Add("FrontMechaCode");
			if (employee1.InOutsideCompanyCode != employee2.InOutsideCompanyCode)
				resList.Add("InOutsideCompanyCode");
			if (employee1.BelongSectionCode != employee2.BelongSectionCode)
				resList.Add("BelongSectionCode");
			if (employee1.LvrRtCstGeneral != employee2.LvrRtCstGeneral)
				resList.Add("LvrRtCstGeneral");
			if (employee1.LvrRtCstCarInspect != employee2.LvrRtCstCarInspect)
				resList.Add("LvrRtCstCarInspect");
			if (employee1.LvrRtCstBodyPaint != employee2.LvrRtCstBodyPaint)
				resList.Add("LvrRtCstBodyPaint");
			if (employee1.LvrRtCstBodyRepair != employee2.LvrRtCstBodyRepair)
				resList.Add("LvrRtCstBodyRepair");
			if (employee1.LoginId != employee2.LoginId)
				resList.Add("LoginId");
			if (employee1.LoginPassword != employee2.LoginPassword)
				resList.Add("LoginPassword");
			if (employee1.UserAdminFlag != employee2.UserAdminFlag)
				resList.Add("UserAdminFlag");
			if (employee1.EnterCompanyDate != employee2.EnterCompanyDate)
				resList.Add("EnterCompanyDate");
			if (employee1.RetirementDate != employee2.RetirementDate)
				resList.Add("RetirementDate");
			if (employee1.EnterpriseName != employee2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (employee1.UpdEmployeeName != employee2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (employee1.PostName != employee2.PostName)
				resList.Add("PostName");
			if (employee1.BusinessName != employee2.BusinessName)
				resList.Add("BusinessName");
			if (employee1.FrontMechaName != employee2.FrontMechaName)
				resList.Add("FrontMechaName");
			if (employee1.BelongSectionName != employee2.BelongSectionName)
				resList.Add("BelongSectionName");
			if (employee1.InOutsideCompanyName != employee2.InOutsideCompanyName)
				resList.Add("InOutsideCompanyName");
			if (employee1.UserAdminName != employee2.UserAdminName)
				resList.Add("UserAdminName");
            if (employee1.AuthorityLevel1 != employee2.AuthorityLevel1)
                resList.Add("AuthorityLevel1");
            if (employee1.AuthorityLevel2 != employee2.AuthorityLevel2)
                resList.Add("AuthorityLevel2");
			// -- Add St 2012.05.29 30182 R.Tachiya --
			if (employee1.SalSlipInpBootCnt != employee2.SalSlipInpBootCnt)
				resList.Add("SalSlipInpBootCnt");
			if (employee1.CustLedgerBootCnt != employee2.CustLedgerBootCnt)
				resList.Add("CustLedgerBootCnt");
			// -- Add Ed 2012.05.29 30182 R.Tachiya --				

			return resList;
		}
	}


    // 2009.03.02 ���������֒u������(�蓮�ύX�ӏ��F1.Equals��EqualsDtl 2.�������喼��(belongSubSectionName)�̒ǉ�) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    #region �폜
    ///// public class name:   EmployeeDtl
    ///// <summary>
    /////                      �]�ƈ��ڍ׃��[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   �]�ƈ��ڍ׃��[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2007/08/29  (CSharp File Generated Date)</br>
    ///// <br>Update Note      : 2008/06/04 30414 �E�@�K�j</br>
    ///// <br>                   �E�u�����ہv�u���������ύX���v�u���������_�v�u����������v�u�������ہv�폜</br>
    ///// <br>Update Note      : UOE���̋敪�ǉ�</br>
    ///// <br>Programmer       : 30009 �a�J ���</br>
    ///// <br>Date             : 2008.11.10</br>
    ///// </remarks>
    //public class EmployeeDtl
    //{
    //    /// <summary>�쐬����</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
    //    private DateTime _createDateTime;

    //    /// <summary>�X�V����</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
    //    private DateTime _updateDateTime;

    //    /// <summary>��ƃR�[�h</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>GUID</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_</remarks>
    //    private Guid _fileHeaderGuid;

    //    /// <summary>�X�V�]�ƈ��R�[�h</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_</remarks>
    //    private string _updEmployeeCode = "";

    //    /// <summary>�X�V�A�Z���u��ID1</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
    //    private string _updAssemblyId1 = "";

    //    /// <summary>�X�V�A�Z���u��ID2</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
    //    private string _updAssemblyId2 = "";

    //    /// <summary>�_���폜�敪</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
    //    private Int32 _logicalDeleteCode;

    //    /// <summary>�]�ƈ��R�[�h</summary>
    //    private string _employeeCode = "";

    //    /// <summary>��������R�[�h</summary>
    //    private Int32 _belongSubSectionCode;

    //    /// <summary>�������喼��</summary>
    //    private string _belongSubSectionName = "";

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// <summary>�����ۃR�[�h</summary>
    //    private Int32 _belongMinSectionCode;

    //    /// <summary>�����ۖ���</summary>
    //    private string _belongMinSectionName = "";
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// <summary>�����̔��G���A�R�[�h</summary>
    //    private Int32 _belongSalesAreaCode;

    //    /// <summary>�����̔��G���A����</summary>
    //    private string _belongSalesAreaName = "";

    //    /// <summary>�]�ƈ����̓R�[�h�P</summary>
    //    /// <remarks>�N��,�O���[�v�����͗p�C�ӃR�[�h��ݒ�</remarks>
    //    private Int32 _employAnalysCode1;

    //    /// <summary>�]�ƈ����̓R�[�h�Q</summary>
    //    /// <remarks>���}�X�^�Ǘ����Ȃ����߁A�R�[�h�̓��[�U�[�Ǘ��ƂȂ�</remarks>
    //    private Int32 _employAnalysCode2;

    //    /// <summary>�]�ƈ����̓R�[�h�R</summary>
    //    private Int32 _employAnalysCode3;

    //    /// <summary>�]�ƈ����̓R�[�h�S</summary>
    //    private Int32 _employAnalysCode4;

    //    /// <summary>�]�ƈ����̓R�[�h�T</summary>
    //    private Int32 _employAnalysCode5;

    //    /// <summary>�]�ƈ����̓R�[�h�U</summary>
    //    private Int32 _employAnalysCode6;

    //    /// <summary>UOE���̋敪</summary>
    //    private string _uOESnmDiv = "";

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// <summary>���������_�R�[�h</summary>
    //    private string _oldBelongSectionCd = "";

    //    /// <summary>�����������_����</summary>
    //    private string _oldBelongSectionNm = "";

    //    /// <summary>����������R�[�h</summary>
    //    private Int32 _oldBelongSubSecCd;

    //    /// <summary>���������喼��</summary>
    //    private string _oldBelongSubSecNm = "";

    //    /// <summary>�������ۃR�[�h</summary>
    //    private Int32 _oldBelongMinSecCd;

    //    /// <summary>�������ۖ���</summary>
    //    private string _oldBelongMinSecNm = "";

    //    /// <summary>���������ύX��</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _sectionChgDate;
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// public propaty name  :  CreateDateTime
    //    /// <summary>�쐬�����v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �쐬�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime CreateDateTime
    //    {
    //        get { return _createDateTime; }
    //        set { _createDateTime = value; }
    //    }

    //    /// public propaty name  :  UpdateDateTime
    //    /// <summary>�X�V�����v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �X�V�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime UpdateDateTime
    //    {
    //        get { return _updateDateTime; }
    //        set { _updateDateTime = value; }
    //    }

    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>��ƃR�[�h�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get { return _enterpriseCode; }
    //        set { _enterpriseCode = value; }
    //    }

    //    /// public propaty name  :  FileHeaderGuid
    //    /// <summary>GUID�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   GUID�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Guid FileHeaderGuid
    //    {
    //        get { return _fileHeaderGuid; }
    //        set { _fileHeaderGuid = value; }
    //    }

    //    /// public propaty name  :  UpdEmployeeCode
    //    /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UpdEmployeeCode
    //    {
    //        get { return _updEmployeeCode; }
    //        set { _updEmployeeCode = value; }
    //    }

    //    /// public propaty name  :  UpdAssemblyId1
    //    /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UpdAssemblyId1
    //    {
    //        get { return _updAssemblyId1; }
    //        set { _updAssemblyId1 = value; }
    //    }

    //    /// public propaty name  :  UpdAssemblyId2
    //    /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UpdAssemblyId2
    //    {
    //        get { return _updAssemblyId2; }
    //        set { _updAssemblyId2 = value; }
    //    }

    //    /// public propaty name  :  LogicalDeleteCode
    //    /// <summary>�_���폜�敪�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �_���폜�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 LogicalDeleteCode
    //    {
    //        get { return _logicalDeleteCode; }
    //        set { _logicalDeleteCode = value; }
    //    }

    //    /// public propaty name  :  EmployeeCode
    //    /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EmployeeCode
    //    {
    //        get { return _employeeCode; }
    //        set { _employeeCode = value; }
    //    }

    //    /// public propaty name  :  BelongSubSectionCode
    //    /// <summary>��������R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��������R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BelongSubSectionCode
    //    {
    //        get { return _belongSubSectionCode; }
    //        set { _belongSubSectionCode = value; }
    //    }

    //    /// public propaty name  :  BelongSubSectionName
    //    /// <summary>�������喼�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������喼�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string BelongSubSectionName
    //    {
    //        get { return _belongSubSectionName; }
    //        set { _belongSubSectionName = value; }
    //    }

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// public propaty name  :  BelongMinSectionCode
    //    /// <summary>�����ۃR�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����ۃR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BelongMinSectionCode
    //    {
    //        get { return _belongMinSectionCode; }
    //        set { _belongMinSectionCode = value; }
    //    }

    //    /// public propaty name  :  BelongMinSectionName
    //    /// <summary>�����ۖ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����ۖ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string BelongMinSectionName
    //    {
    //        get { return _belongMinSectionName; }
    //        set { _belongMinSectionName = value; }
    //    }
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// public propaty name  :  BelongSalesAreaCode
    //    /// <summary>�����̔��G���A�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����̔��G���A�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BelongSalesAreaCode
    //    {
    //        get { return _belongSalesAreaCode; }
    //        set { _belongSalesAreaCode = value; }
    //    }

    //    /// public propaty name  :  BelongSalesAreaName
    //    /// <summary>�����̔��G���A���̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����̔��G���A���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string BelongSalesAreaName
    //    {
    //        get { return _belongSalesAreaName; }
    //        set { _belongSalesAreaName = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode1
    //    /// <summary>�]�ƈ����̓R�[�h�P�v���p�e�B</summary>
    //    /// <value>�N��,�O���[�v�����͗p�C�ӃR�[�h��ݒ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ����̓R�[�h�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode1
    //    {
    //        get { return _employAnalysCode1; }
    //        set { _employAnalysCode1 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode2
    //    /// <summary>�]�ƈ����̓R�[�h�Q�v���p�e�B</summary>
    //    /// <value>���}�X�^�Ǘ����Ȃ����߁A�R�[�h�̓��[�U�[�Ǘ��ƂȂ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ����̓R�[�h�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode2
    //    {
    //        get { return _employAnalysCode2; }
    //        set { _employAnalysCode2 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode3
    //    /// <summary>�]�ƈ����̓R�[�h�R�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ����̓R�[�h�R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode3
    //    {
    //        get { return _employAnalysCode3; }
    //        set { _employAnalysCode3 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode4
    //    /// <summary>�]�ƈ����̓R�[�h�S�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ����̓R�[�h�S�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode4
    //    {
    //        get { return _employAnalysCode4; }
    //        set { _employAnalysCode4 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode5
    //    /// <summary>�]�ƈ����̓R�[�h�T�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ����̓R�[�h�T�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode5
    //    {
    //        get { return _employAnalysCode5; }
    //        set { _employAnalysCode5 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode6
    //    /// <summary>�]�ƈ����̓R�[�h�U�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �]�ƈ����̓R�[�h�U�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode6
    //    {
    //        get { return _employAnalysCode6; }
    //        set { _employAnalysCode6 = value; }
    //    }

    //    /// public propaty name  :  UOESnmDiv
    //    /// <summary>UOE���̋敪�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   UOE���̋敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UOESnmDiv
    //    {
    //        get { return _uOESnmDiv; }
    //        set { _uOESnmDiv = value; }
    //    }

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// public propaty name  :  OldBelongSectionCd
    //    /// <summary>���������_�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���������_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string OldBelongSectionCd
    //    {
    //        get { return _oldBelongSectionCd; }
    //        set { _oldBelongSectionCd = value; }
    //    }

    //    /// public propaty name  :  OldBelongSectionNm
    //    /// <summary>�����������_���̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����������_���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string OldBelongSectionNm
    //    {
    //        get { return _oldBelongSectionNm; }
    //        set { _oldBelongSectionNm = value; }
    //    }

    //    /// public propaty name  :  OldBelongSubSecCd
    //    /// <summary>����������R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����������R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 OldBelongSubSecCd
    //    {
    //        get { return _oldBelongSubSecCd; }
    //        set { _oldBelongSubSecCd = value; }
    //    }

    //    /// public propaty name  :  OldBelongSubSecNm
    //    /// <summary>���������喼�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���������喼�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string OldBelongSubSecNm
    //    {
    //        get { return _oldBelongSubSecNm; }
    //        set { _oldBelongSubSecNm = value; }
    //    }

    //    /// public propaty name  :  OldBelongMinSecCd
    //    /// <summary>�������ۃR�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������ۃR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 OldBelongMinSecCd
    //    {
    //        get { return _oldBelongMinSecCd; }
    //        set { _oldBelongMinSecCd = value; }
    //    }

    //    /// public propaty name  :  OldBelongMinSecNm
    //    /// <summary>�������ۖ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������ۖ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string OldBelongMinSecNm
    //    {
    //        get { return _oldBelongMinSecNm; }
    //        set { _oldBelongMinSecNm = value; }
    //    }

    //    /// public propaty name  :  SectionChgDate
    //    /// <summary>���������ύX���v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���������ύX���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SectionChgDate
    //    {
    //        get { return _sectionChgDate; }
    //        set { _sectionChgDate = value; }
    //    }
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>EmployeeDtl�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public EmployeeDtl()
    //    {
    //    }

    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
    //    /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
    //    /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
    //    /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
    //    /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
    //    /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
    //    /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
    //    /// <param name="employeeCode">�]�ƈ��R�[�h</param>
    //    /// <param name="belongSubSectionCode">��������R�[�h</param>
    //    /// <param name="belongSubSectionName">�������喼��</param>
    //    /// <param name="belongSalesAreaCode">�����̔��G���A�R�[�h</param>
    //    /// <param name="belongSalesAreaName">�����̔��G���A����</param>
    //    /// <param name="employAnalysCode1">�]�ƈ����̓R�[�h�P(�N��,�O���[�v�����͗p�C�ӃR�[�h��ݒ�)</param>
    //    /// <param name="employAnalysCode2">�]�ƈ����̓R�[�h�Q(���}�X�^�Ǘ����Ȃ����߁A�R�[�h�̓��[�U�[�Ǘ��ƂȂ�)</param>
    //    /// <param name="employAnalysCode3">�]�ƈ����̓R�[�h�R</param>
    //    /// <param name="employAnalysCode4">�]�ƈ����̓R�[�h�S</param>
    //    /// <param name="employAnalysCode5">�]�ƈ����̓R�[�h�T</param>
    //    /// <param name="employAnalysCode6">�]�ƈ����̓R�[�h�U</param>
    //    /// <param name="uOESnmDiv">UOE���̋敪</param>
    //    /// <returns>EmployeeDtl�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, string belongSubSectionName, Int32 belongMinSectionCode, string belongMinSectionName, Int32 belongSalesAreaCode, string belongSalesAreaName, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6, string oldBelongSectionCd, string oldBelongSectionNm, Int32 oldBelongSubSecCd, string oldBelongSubSecNm, Int32 oldBelongMinSecCd, string oldBelongMinSecNm, DateTime sectionChgDate)
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    //2008.11.10 del start -------------------------------------------------------------->>
    //    //public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, string belongSubSectionName, Int32 belongSalesAreaCode, string belongSalesAreaName, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6)
    //    //2008.11.10 del end ----------------------------------------------------------------<<
    //    public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, string belongSubSectionName, Int32 belongSalesAreaCode, string belongSalesAreaName, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6, String uOESnmDiv)
    //    {
    //        this.CreateDateTime = createDateTime;
    //        this.UpdateDateTime = updateDateTime;
    //        this._enterpriseCode = enterpriseCode;
    //        this._fileHeaderGuid = fileHeaderGuid;
    //        this._updEmployeeCode = updEmployeeCode;
    //        this._updAssemblyId1 = updAssemblyId1;
    //        this._updAssemblyId2 = updAssemblyId2;
    //        this._logicalDeleteCode = logicalDeleteCode;
    //        this._employeeCode = employeeCode;
    //        this._belongSubSectionCode = belongSubSectionCode;
    //        this._belongSubSectionName = belongSubSectionName;

    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        this._belongMinSectionCode = belongMinSectionCode;
    //        this._belongMinSectionName = belongMinSectionName;
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //        this._belongSalesAreaCode = belongSalesAreaCode;
    //        this._belongSalesAreaName = belongSalesAreaName;
    //        this._employAnalysCode1 = employAnalysCode1;
    //        this._employAnalysCode2 = employAnalysCode2;
    //        this._employAnalysCode3 = employAnalysCode3;
    //        this._employAnalysCode4 = employAnalysCode4;
    //        this._employAnalysCode5 = employAnalysCode5;
    //        this._employAnalysCode6 = employAnalysCode6;

    //        //2008.11.10 add start -------------------------------------------------------------->>
    //        this._uOESnmDiv = uOESnmDiv;
    //        //2008.11.10 add end ----------------------------------------------------------------<<

    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        this._oldBelongSectionCd = oldBelongSectionCd;
    //        this._oldBelongSectionNm = oldBelongSectionNm;
    //        this._oldBelongSubSecCd = oldBelongSubSecCd;
    //        this._oldBelongSubSecNm = oldBelongSubSecNm;
    //        this._oldBelongMinSecCd = oldBelongMinSecCd;
    //        this._oldBelongMinSecNm = oldBelongMinSecNm;
    //        this._sectionChgDate = sectionChgDate;
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    }

    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N��������
    //    /// </summary>
    //    /// <returns>EmployeeDtl�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����EmployeeDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public EmployeeDtl Clone()
    //    {
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._belongSubSectionName, this._belongMinSectionCode, this._belongMinSectionName, this._belongSalesAreaCode, this._belongSalesAreaName, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6, this._oldBelongSectionCd, this._oldBelongSectionNm, this._oldBelongSubSecCd, this._oldBelongSubSecNm, this._oldBelongMinSecCd, this._oldBelongMinSecNm, this._sectionChgDate);
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //        //2008.11.10 del start -------------------------------------------------------------->>
    //        //return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._belongSubSectionName, this._belongSalesAreaCode, this._belongSalesAreaName, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6);
    //        //2008.11.10 del end ----------------------------------------------------------------<<
    //        return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._belongSubSectionName, this._belongSalesAreaCode, this._belongSalesAreaName, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6, this._uOESnmDiv);
    //    }

    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N��r����
    //    /// </summary>
    //    /// <param name="target">��r�Ώۂ�EmployeeDtl�N���X�̃C���X�^���X</param>
    //    /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public bool EqualsDtl(EmployeeDtl target)
    //    {
    //        return ((this.CreateDateTime == target.CreateDateTime)
    //             && (this.UpdateDateTime == target.UpdateDateTime)
    //             && (this.EnterpriseCode == target.EnterpriseCode)
    //             && (this.FileHeaderGuid == target.FileHeaderGuid)
    //             && (this.UpdEmployeeCode == target.UpdEmployeeCode)
    //             && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
    //             && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
    //             && (this.LogicalDeleteCode == target.LogicalDeleteCode)
    //             && (this.EmployeeCode == target.EmployeeCode)
    //             && (this.BelongSubSectionCode == target.BelongSubSectionCode)
    //             && (this.BelongSubSectionName == target.BelongSubSectionName)
    //            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //            && (this.BelongMinSectionCode == target.BelongMinSectionCode)
    //            && (this.BelongMinSectionName == target.BelongMinSectionName)
    //               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //             && (this.BelongSalesAreaCode == target.BelongSalesAreaCode)
    //             && (this.BelongSalesAreaName == target.BelongSalesAreaName)
    //             && (this.EmployAnalysCode1 == target.EmployAnalysCode1)
    //             && (this.EmployAnalysCode2 == target.EmployAnalysCode2)
    //             && (this.EmployAnalysCode3 == target.EmployAnalysCode3)
    //             && (this.EmployAnalysCode4 == target.EmployAnalysCode4)
    //             && (this.EmployAnalysCode5 == target.EmployAnalysCode5)
    //             && (this.EmployAnalysCode6 == target.EmployAnalysCode6)
    //            //2008.11.10 add start -------------------------------------------------------------->>
    //             && (this.UOESnmDiv == target.UOESnmDiv));
    //            //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        && (this.OldBelongSectionCd == target.OldBelongSectionCd)
    //        && (this.OldBelongSectionNm == target.OldBelongSectionNm)
    //        && (this.OldBelongSubSecCd == target.OldBelongSubSecCd)
    //        && (this.OldBelongSubSecNm == target.OldBelongSubSecNm)
    //        && (this.OldBelongMinSecCd == target.OldBelongMinSecCd)
    //        && (this.OldBelongMinSecNm == target.OldBelongMinSecNm)
    //        && (this.SectionChgDate == target.SectionChgDate));
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    }

    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N��r����
    //    /// </summary>
    //    /// <param name="employeeDtl1">
    //    ///                    ��r����EmployeeDtl�N���X�̃C���X�^���X
    //    /// </param>
    //    /// <param name="employeeDtl2">��r����EmployeeDtl�N���X�̃C���X�^���X</param>
    //    /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public static bool EqualsDtl(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
    //    {
    //        return ((employeeDtl1.CreateDateTime == employeeDtl2.CreateDateTime)
    //             && (employeeDtl1.UpdateDateTime == employeeDtl2.UpdateDateTime)
    //             && (employeeDtl1.EnterpriseCode == employeeDtl2.EnterpriseCode)
    //             && (employeeDtl1.FileHeaderGuid == employeeDtl2.FileHeaderGuid)
    //             && (employeeDtl1.UpdEmployeeCode == employeeDtl2.UpdEmployeeCode)
    //             && (employeeDtl1.UpdAssemblyId1 == employeeDtl2.UpdAssemblyId1)
    //             && (employeeDtl1.UpdAssemblyId2 == employeeDtl2.UpdAssemblyId2)
    //             && (employeeDtl1.LogicalDeleteCode == employeeDtl2.LogicalDeleteCode)
    //             && (employeeDtl1.EmployeeCode == employeeDtl2.EmployeeCode)
    //             && (employeeDtl1.BelongSubSectionCode == employeeDtl2.BelongSubSectionCode)
    //             && (employeeDtl1.BelongSubSectionName == employeeDtl2.BelongSubSectionName)
    //            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //            && (employeeDtl1.BelongMinSectionCode == employeeDtl2.BelongMinSectionCode)
    //            && (employeeDtl1.BelongMinSectionName == employeeDtl2.BelongMinSectionName)
    //               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //             && (employeeDtl1.BelongSalesAreaCode == employeeDtl2.BelongSalesAreaCode)
    //             && (employeeDtl1.BelongSalesAreaName == employeeDtl2.BelongSalesAreaName)
    //             && (employeeDtl1.EmployAnalysCode1 == employeeDtl2.EmployAnalysCode1)
    //             && (employeeDtl1.EmployAnalysCode2 == employeeDtl2.EmployAnalysCode2)
    //             && (employeeDtl1.EmployAnalysCode3 == employeeDtl2.EmployAnalysCode3)
    //             && (employeeDtl1.EmployAnalysCode4 == employeeDtl2.EmployAnalysCode4)
    //             && (employeeDtl1.EmployAnalysCode5 == employeeDtl2.EmployAnalysCode5)
    //             && (employeeDtl1.EmployAnalysCode6 == employeeDtl2.EmployAnalysCode6)
    //        //2008.11.10 add start -------------------------------------------------------------->>
    //             && (employeeDtl1.UOESnmDiv == employeeDtl2.UOESnmDiv));
    //        //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        && (employeeDtl1.OldBelongSectionCd == employeeDtl2.OldBelongSectionCd)
    //        && (employeeDtl1.OldBelongSectionNm == employeeDtl2.OldBelongSectionNm)
    //        && (employeeDtl1.OldBelongSubSecCd == employeeDtl2.OldBelongSubSecCd)
    //        && (employeeDtl1.OldBelongSubSecNm == employeeDtl2.OldBelongSubSecNm)
    //        && (employeeDtl1.OldBelongMinSecCd == employeeDtl2.OldBelongMinSecCd)
    //        && (employeeDtl1.OldBelongMinSecNm == employeeDtl2.OldBelongMinSecNm)
    //        && (employeeDtl1.SectionChgDate == employeeDtl2.SectionChgDate));
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    }
    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N��r����
    //    /// </summary>
    //    /// <param name="target">��r�Ώۂ�EmployeeDtl�N���X�̃C���X�^���X</param>
    //    /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public ArrayList Compare(EmployeeDtl target)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
    //        if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
    //        if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
    //        if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
    //        if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
    //        if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
    //        if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
    //        if (this.BelongSubSectionCode != target.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
    //        if (this.BelongSubSectionName != target.BelongSubSectionName) resList.Add("BelongSubSectionName");
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (this.BelongMinSectionCode != target.BelongMinSectionCode) resList.Add("BelongMinSectionCode");
    //        if (this.BelongMinSectionName != target.BelongMinSectionName) resList.Add("BelongMinSectionName");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //        if (this.BelongSalesAreaCode != target.BelongSalesAreaCode) resList.Add("BelongSalesAreaCode");
    //        if (this.BelongSalesAreaName != target.BelongSalesAreaName) resList.Add("BelongSalesAreaName");
    //        if (this.EmployAnalysCode1 != target.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
    //        if (this.EmployAnalysCode2 != target.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
    //        if (this.EmployAnalysCode3 != target.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
    //        if (this.EmployAnalysCode4 != target.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
    //        if (this.EmployAnalysCode5 != target.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
    //        if (this.EmployAnalysCode6 != target.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
    //        //2008.11.10 add start -------------------------------------------------------------->>
    //        if (this.UOESnmDiv != target.UOESnmDiv) resList.Add("UOESnmDiv");
    //        //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (this.OldBelongSectionCd != target.OldBelongSectionCd) resList.Add("OldBelongSectionCd");
    //        if (this.OldBelongSectionNm != target.OldBelongSectionNm) resList.Add("OldBelongSectionNm");
    //        if (this.OldBelongSubSecCd != target.OldBelongSubSecCd) resList.Add("OldBelongSubSecCd");
    //        if (this.OldBelongSubSecNm != target.OldBelongSubSecNm) resList.Add("OldBelongSubSecNm");
    //        if (this.OldBelongMinSecCd != target.OldBelongMinSecCd) resList.Add("OldBelongMinSecCd");
    //        if (this.OldBelongMinSecNm != target.OldBelongMinSecNm) resList.Add("OldBelongMinSecNm");
    //        if (this.SectionChgDate != target.SectionChgDate) resList.Add("SectionChgDate");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //        return resList;
    //    }

    //    /// <summary>
    //    /// �]�ƈ��ڍ׃��[�N��r����
    //    /// </summary>
    //    /// <param name="employeeDtl1">��r����EmployeeDtl�N���X�̃C���X�^���X</param>
    //    /// <param name="employeeDtl2">��r����EmployeeDtl�N���X�̃C���X�^���X</param>
    //    /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public static ArrayList Compare(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (employeeDtl1.CreateDateTime != employeeDtl2.CreateDateTime) resList.Add("CreateDateTime");
    //        if (employeeDtl1.UpdateDateTime != employeeDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
    //        if (employeeDtl1.EnterpriseCode != employeeDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (employeeDtl1.FileHeaderGuid != employeeDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
    //        if (employeeDtl1.UpdEmployeeCode != employeeDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
    //        if (employeeDtl1.UpdAssemblyId1 != employeeDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
    //        if (employeeDtl1.UpdAssemblyId2 != employeeDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
    //        if (employeeDtl1.LogicalDeleteCode != employeeDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (employeeDtl1.EmployeeCode != employeeDtl2.EmployeeCode) resList.Add("EmployeeCode");
    //        if (employeeDtl1.BelongSubSectionCode != employeeDtl2.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
    //        if (employeeDtl1.BelongSubSectionName != employeeDtl2.BelongSubSectionName) resList.Add("BelongSubSectionName");
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (employeeDtl1.BelongMinSectionCode != employeeDtl2.BelongMinSectionCode) resList.Add("BelongMinSectionCode");
    //        if (employeeDtl1.BelongMinSectionName != employeeDtl2.BelongMinSectionName) resList.Add("BelongMinSectionName");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //        if (employeeDtl1.BelongSalesAreaCode != employeeDtl2.BelongSalesAreaCode) resList.Add("BelongSalesAreaCode");
    //        if (employeeDtl1.BelongSalesAreaName != employeeDtl2.BelongSalesAreaName) resList.Add("BelongSalesAreaName");
    //        if (employeeDtl1.EmployAnalysCode1 != employeeDtl2.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
    //        if (employeeDtl1.EmployAnalysCode2 != employeeDtl2.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
    //        if (employeeDtl1.EmployAnalysCode3 != employeeDtl2.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
    //        if (employeeDtl1.EmployAnalysCode4 != employeeDtl2.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
    //        if (employeeDtl1.EmployAnalysCode5 != employeeDtl2.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
    //        if (employeeDtl1.EmployAnalysCode6 != employeeDtl2.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
    //        //2008.11.10 add start -------------------------------------------------------------->>
    //        if (employeeDtl1.UOESnmDiv != employeeDtl2.UOESnmDiv) resList.Add("UOESnmDiv");
    //        //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (employeeDtl1.OldBelongSectionCd != employeeDtl2.OldBelongSectionCd) resList.Add("OldBelongSectionCd");
    //        if (employeeDtl1.OldBelongSectionNm != employeeDtl2.OldBelongSectionNm) resList.Add("OldBelongSectionNm");
    //        if (employeeDtl1.OldBelongSubSecCd != employeeDtl2.OldBelongSubSecCd) resList.Add("OldBelongSubSecCd");
    //        if (employeeDtl1.OldBelongSubSecNm != employeeDtl2.OldBelongSubSecNm) resList.Add("OldBelongSubSecNm");
    //        if (employeeDtl1.OldBelongMinSecCd != employeeDtl2.OldBelongMinSecCd) resList.Add("OldBelongMinSecCd");
    //        if (employeeDtl1.OldBelongMinSecNm != employeeDtl2.OldBelongMinSecNm) resList.Add("OldBelongMinSecNm");
    //        if (employeeDtl1.SectionChgDate != employeeDtl2.SectionChgDate) resList.Add("SectionChgDate");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //        return resList;
    //    }
    //}
    #endregion

    /// public class name:   EmployeeDtl
    /// <summary>
    ///                      �]�ƈ��ڍ׃}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ��ڍ׃}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2009/03/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/4  ����</br>
    /// <br>                 :   �ǉ�����</br>
    /// <br>                 :   UOE���̋敪</br>
    /// <br>Update Note      :   2/3  ����</br>
    /// <br>                 :   �ǉ�����</br>
    /// <br>                 :   ���[���A�h���X��ʃR�[�h1</br>
    /// <br>                 :   ���[���A�h���X��ʖ���1</br>
    /// <br>                 :   ���[���A�h���X1</br>
    /// <br>                 :   ���[�����M�敪�R�[�h1</br>
    /// <br>                 :   ���[���A�h���X��ʃR�[�h2</br>
    /// <br>                 :   ���[���A�h���X��ʖ���2</br>
    /// <br>                 :   ���[���A�h���X2</br>
    /// <br>                 :   ���[�����M�敪�R�[�h2</br>
    /// </remarks>
    public class EmployeeDtl
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

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>��������R�[�h</summary>
        /// <remarks>������Ǘ����Ȃ��ꍇ�́A�g�p���Ȃ�</remarks>
        private Int32 _belongSubSectionCode;

        /// <summary>�]�ƈ����̓R�[�h�P</summary>
        /// <remarks>�N��,�O���[�v�����͗p�C�ӃR�[�h��ݒ�</remarks>
        private Int32 _employAnalysCode1;

        /// <summary>�]�ƈ����̓R�[�h�Q</summary>
        /// <remarks>���}�X�^�Ǘ����Ȃ����߁A�R�[�h�̓��[�U�[�Ǘ��ƂȂ�</remarks>
        private Int32 _employAnalysCode2;

        /// <summary>�]�ƈ����̓R�[�h�R</summary>
        private Int32 _employAnalysCode3;

        /// <summary>�]�ƈ����̓R�[�h�S</summary>
        private Int32 _employAnalysCode4;

        /// <summary>�]�ƈ����̓R�[�h�T</summary>
        private Int32 _employAnalysCode5;

        /// <summary>�]�ƈ����̓R�[�h�U</summary>
        private Int32 _employAnalysCode6;

        /// <summary>UOE���̋敪</summary>
        private string _uOESnmDiv = "";

        /// <summary>���[���A�h���X��ʃR�[�h1</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>���[���A�h���X��ʖ���1</summary>
        private string _mailAddrKindName1 = "";

        /// <summary>���[���A�h���X1</summary>
        private string _mailAddress1 = "";

        /// <summary>���[�����M�敪�R�[�h1</summary>
        /// <remarks>0:�񑗐M,1:���M</remarks>
        private Int32 _mailSendCode1;

        /// <summary>���[���A�h���X��ʃR�[�h2</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>���[���A�h���X��ʖ���2</summary>
        private string _mailAddrKindName2 = "";

        /// <summary>���[���A�h���X2</summary>
        private string _mailAddress2 = "";

        /// <summary>���[�����M�敪�R�[�h2</summary>
        /// <remarks>0:�񑗐M,1:���M</remarks>
        private Int32 _mailSendCode2;

        /// <summary>�������喼��</summary>
        /// <remarks>������Ǘ����Ȃ��ꍇ�́A�g�p���Ȃ�</remarks>
        private string _belongSubSectionName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  BelongSubSectionCode
        /// <summary>��������R�[�h�v���p�e�B</summary>
        /// <value>������Ǘ����Ȃ��ꍇ�́A�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BelongSubSectionCode
        {
            get { return _belongSubSectionCode; }
            set { _belongSubSectionCode = value; }
        }

        /// public propaty name  :  EmployAnalysCode1
        /// <summary>�]�ƈ����̓R�[�h�P�v���p�e�B</summary>
        /// <value>�N��,�O���[�v�����͗p�C�ӃR�[�h��ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̓R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployAnalysCode1
        {
            get { return _employAnalysCode1; }
            set { _employAnalysCode1 = value; }
        }

        /// public propaty name  :  EmployAnalysCode2
        /// <summary>�]�ƈ����̓R�[�h�Q�v���p�e�B</summary>
        /// <value>���}�X�^�Ǘ����Ȃ����߁A�R�[�h�̓��[�U�[�Ǘ��ƂȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̓R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployAnalysCode2
        {
            get { return _employAnalysCode2; }
            set { _employAnalysCode2 = value; }
        }

        /// public propaty name  :  EmployAnalysCode3
        /// <summary>�]�ƈ����̓R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̓R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployAnalysCode3
        {
            get { return _employAnalysCode3; }
            set { _employAnalysCode3 = value; }
        }

        /// public propaty name  :  EmployAnalysCode4
        /// <summary>�]�ƈ����̓R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̓R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployAnalysCode4
        {
            get { return _employAnalysCode4; }
            set { _employAnalysCode4 = value; }
        }

        /// public propaty name  :  EmployAnalysCode5
        /// <summary>�]�ƈ����̓R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̓R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployAnalysCode5
        {
            get { return _employAnalysCode5; }
            set { _employAnalysCode5 = value; }
        }

        /// public propaty name  :  EmployAnalysCode6
        /// <summary>�]�ƈ����̓R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̓R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployAnalysCode6
        {
            get { return _employAnalysCode6; }
            set { _employAnalysCode6 = value; }
        }

        /// public propaty name  :  UOESnmDiv
        /// <summary>UOE���̋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���̋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESnmDiv
        {
            get { return _uOESnmDiv; }
            set { _uOESnmDiv = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>���[���A�h���X��ʃR�[�h1�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>���[���A�h���X��ʖ���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʖ���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>���[���A�h���X1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>���[�����M�敪�R�[�h1�v���p�e�B</summary>
        /// <value>0:�񑗐M,1:���M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>���[���A�h���X��ʃR�[�h2�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>���[���A�h���X��ʖ���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʖ���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>���[���A�h���X2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>���[�����M�敪�R�[�h2�v���p�e�B</summary>
        /// <value>0:�񑗐M,1:���M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }

        /// public propaty name  :  BelongSubSectionName
        /// <summary>�������喼�̃v���p�e�B</summary>
        /// <value>������Ǘ����Ȃ��ꍇ�́A�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BelongSubSectionName
        {
            get { return _belongSubSectionName; }
            set { _belongSubSectionName = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>EmployeeDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeDtl()
        {
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="belongSubSectionCode">��������R�[�h(������Ǘ����Ȃ��ꍇ�́A�g�p���Ȃ�)</param>
        /// <param name="employAnalysCode1">�]�ƈ����̓R�[�h�P(�N��,�O���[�v�����͗p�C�ӃR�[�h��ݒ�)</param>
        /// <param name="employAnalysCode2">�]�ƈ����̓R�[�h�Q(���}�X�^�Ǘ����Ȃ����߁A�R�[�h�̓��[�U�[�Ǘ��ƂȂ�)</param>
        /// <param name="employAnalysCode3">�]�ƈ����̓R�[�h�R</param>
        /// <param name="employAnalysCode4">�]�ƈ����̓R�[�h�S</param>
        /// <param name="employAnalysCode5">�]�ƈ����̓R�[�h�T</param>
        /// <param name="employAnalysCode6">�]�ƈ����̓R�[�h�U</param>
        /// <param name="uOESnmDiv">UOE���̋敪</param>
        /// <param name="mailAddrKindCode1">���[���A�h���X��ʃR�[�h1(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName1">���[���A�h���X��ʖ���1</param>
        /// <param name="mailAddress1">���[���A�h���X1</param>
        /// <param name="mailSendCode1">���[�����M�敪�R�[�h1(0:�񑗐M,1:���M)</param>
        /// <param name="mailAddrKindCode2">���[���A�h���X��ʃR�[�h2(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName2">���[���A�h���X��ʖ���2</param>
        /// <param name="mailAddress2">���[���A�h���X2</param>
        /// <param name="mailSendCode2">���[�����M�敪�R�[�h2(0:�񑗐M,1:���M)</param>
        /// <param name="belongSubSectionName">�������喼��(������Ǘ����Ȃ��ꍇ�́A�g�p���Ȃ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>EmployeeDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6, string uOESnmDiv, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string belongSubSectionName, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._employeeCode = employeeCode;
            this._belongSubSectionCode = belongSubSectionCode;
            this._employAnalysCode1 = employAnalysCode1;
            this._employAnalysCode2 = employAnalysCode2;
            this._employAnalysCode3 = employAnalysCode3;
            this._employAnalysCode4 = employAnalysCode4;
            this._employAnalysCode5 = employAnalysCode5;
            this._employAnalysCode6 = employAnalysCode6;
            this._uOESnmDiv = uOESnmDiv;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailAddress1 = mailAddress1;
            this._mailSendCode1 = mailSendCode1;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddrKindName2 = mailAddrKindName2;
            this._mailAddress2 = mailAddress2;
            this._mailSendCode2 = mailSendCode2;
            this._belongSubSectionName = belongSubSectionName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^��������
        /// </summary>
        /// <returns>EmployeeDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����EmployeeDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeDtl Clone()
        {
            return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6, this._uOESnmDiv, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._belongSubSectionName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�EmployeeDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool EqualsDtl(EmployeeDtl target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.BelongSubSectionCode == target.BelongSubSectionCode)
                 && (this.EmployAnalysCode1 == target.EmployAnalysCode1)
                 && (this.EmployAnalysCode2 == target.EmployAnalysCode2)
                 && (this.EmployAnalysCode3 == target.EmployAnalysCode3)
                 && (this.EmployAnalysCode4 == target.EmployAnalysCode4)
                 && (this.EmployAnalysCode5 == target.EmployAnalysCode5)
                 && (this.EmployAnalysCode6 == target.EmployAnalysCode6)
                 && (this.UOESnmDiv == target.UOESnmDiv)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailAddress1 == target.MailAddress1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailAddrKindCode2 == target.MailAddrKindCode2)
                 && (this.MailAddrKindName2 == target.MailAddrKindName2)
                 && (this.MailAddress2 == target.MailAddress2)
                 && (this.MailSendCode2 == target.MailSendCode2)
                 && (this.BelongSubSectionName == target.BelongSubSectionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^��r����
        /// </summary>
        /// <param name="employeeDtl1">
        ///                    ��r����EmployeeDtl�N���X�̃C���X�^���X
        /// </param>
        /// <param name="employeeDtl2">��r����EmployeeDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool EqualsDtl(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
        {
            return ((employeeDtl1.CreateDateTime == employeeDtl2.CreateDateTime)
                 && (employeeDtl1.UpdateDateTime == employeeDtl2.UpdateDateTime)
                 && (employeeDtl1.EnterpriseCode == employeeDtl2.EnterpriseCode)
                 && (employeeDtl1.FileHeaderGuid == employeeDtl2.FileHeaderGuid)
                 && (employeeDtl1.UpdEmployeeCode == employeeDtl2.UpdEmployeeCode)
                 && (employeeDtl1.UpdAssemblyId1 == employeeDtl2.UpdAssemblyId1)
                 && (employeeDtl1.UpdAssemblyId2 == employeeDtl2.UpdAssemblyId2)
                 && (employeeDtl1.LogicalDeleteCode == employeeDtl2.LogicalDeleteCode)
                 && (employeeDtl1.EmployeeCode == employeeDtl2.EmployeeCode)
                 && (employeeDtl1.BelongSubSectionCode == employeeDtl2.BelongSubSectionCode)
                 && (employeeDtl1.EmployAnalysCode1 == employeeDtl2.EmployAnalysCode1)
                 && (employeeDtl1.EmployAnalysCode2 == employeeDtl2.EmployAnalysCode2)
                 && (employeeDtl1.EmployAnalysCode3 == employeeDtl2.EmployAnalysCode3)
                 && (employeeDtl1.EmployAnalysCode4 == employeeDtl2.EmployAnalysCode4)
                 && (employeeDtl1.EmployAnalysCode5 == employeeDtl2.EmployAnalysCode5)
                 && (employeeDtl1.EmployAnalysCode6 == employeeDtl2.EmployAnalysCode6)
                 && (employeeDtl1.UOESnmDiv == employeeDtl2.UOESnmDiv)
                 && (employeeDtl1.MailAddrKindCode1 == employeeDtl2.MailAddrKindCode1)
                 && (employeeDtl1.MailAddrKindName1 == employeeDtl2.MailAddrKindName1)
                 && (employeeDtl1.MailAddress1 == employeeDtl2.MailAddress1)
                 && (employeeDtl1.MailSendCode1 == employeeDtl2.MailSendCode1)
                 && (employeeDtl1.MailAddrKindCode2 == employeeDtl2.MailAddrKindCode2)
                 && (employeeDtl1.MailAddrKindName2 == employeeDtl2.MailAddrKindName2)
                 && (employeeDtl1.MailAddress2 == employeeDtl2.MailAddress2)
                 && (employeeDtl1.MailSendCode2 == employeeDtl2.MailSendCode2)
                 && (employeeDtl1.BelongSubSectionName == employeeDtl2.BelongSubSectionName)
                 && (employeeDtl1.EnterpriseName == employeeDtl2.EnterpriseName)
                 && (employeeDtl1.UpdEmployeeName == employeeDtl2.UpdEmployeeName));
        }
        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�EmployeeDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(EmployeeDtl target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.BelongSubSectionCode != target.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
            if (this.EmployAnalysCode1 != target.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
            if (this.EmployAnalysCode2 != target.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
            if (this.EmployAnalysCode3 != target.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
            if (this.EmployAnalysCode4 != target.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
            if (this.EmployAnalysCode5 != target.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
            if (this.EmployAnalysCode6 != target.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
            if (this.UOESnmDiv != target.UOESnmDiv) resList.Add("UOESnmDiv");
            if (this.MailAddrKindCode1 != target.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (this.MailAddrKindName1 != target.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (this.MailAddress1 != target.MailAddress1) resList.Add("MailAddress1");
            if (this.MailSendCode1 != target.MailSendCode1) resList.Add("MailSendCode1");
            if (this.MailAddrKindCode2 != target.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (this.MailAddrKindName2 != target.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (this.MailAddress2 != target.MailAddress2) resList.Add("MailAddress2");
            if (this.MailSendCode2 != target.MailSendCode2) resList.Add("MailSendCode2");
            if (this.BelongSubSectionName != target.BelongSubSectionName) resList.Add("BelongSubSectionName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^��r����
        /// </summary>
        /// <param name="employeeDtl1">��r����EmployeeDtl�N���X�̃C���X�^���X</param>
        /// <param name="employeeDtl2">��r����EmployeeDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
        {
            ArrayList resList = new ArrayList();
            if (employeeDtl1.CreateDateTime != employeeDtl2.CreateDateTime) resList.Add("CreateDateTime");
            if (employeeDtl1.UpdateDateTime != employeeDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (employeeDtl1.EnterpriseCode != employeeDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (employeeDtl1.FileHeaderGuid != employeeDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (employeeDtl1.UpdEmployeeCode != employeeDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (employeeDtl1.UpdAssemblyId1 != employeeDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (employeeDtl1.UpdAssemblyId2 != employeeDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (employeeDtl1.LogicalDeleteCode != employeeDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (employeeDtl1.EmployeeCode != employeeDtl2.EmployeeCode) resList.Add("EmployeeCode");
            if (employeeDtl1.BelongSubSectionCode != employeeDtl2.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
            if (employeeDtl1.EmployAnalysCode1 != employeeDtl2.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
            if (employeeDtl1.EmployAnalysCode2 != employeeDtl2.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
            if (employeeDtl1.EmployAnalysCode3 != employeeDtl2.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
            if (employeeDtl1.EmployAnalysCode4 != employeeDtl2.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
            if (employeeDtl1.EmployAnalysCode5 != employeeDtl2.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
            if (employeeDtl1.EmployAnalysCode6 != employeeDtl2.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
            if (employeeDtl1.UOESnmDiv != employeeDtl2.UOESnmDiv) resList.Add("UOESnmDiv");
            if (employeeDtl1.MailAddrKindCode1 != employeeDtl2.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (employeeDtl1.MailAddrKindName1 != employeeDtl2.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (employeeDtl1.MailAddress1 != employeeDtl2.MailAddress1) resList.Add("MailAddress1");
            if (employeeDtl1.MailSendCode1 != employeeDtl2.MailSendCode1) resList.Add("MailSendCode1");
            if (employeeDtl1.MailAddrKindCode2 != employeeDtl2.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (employeeDtl1.MailAddrKindName2 != employeeDtl2.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (employeeDtl1.MailAddress2 != employeeDtl2.MailAddress2) resList.Add("MailAddress2");
            if (employeeDtl1.MailSendCode2 != employeeDtl2.MailSendCode2) resList.Add("MailSendCode2");
            if (employeeDtl1.BelongSubSectionName != employeeDtl2.BelongSubSectionName) resList.Add("BelongSubSectionName");
            if (employeeDtl1.EnterpriseName != employeeDtl2.EnterpriseName) resList.Add("EnterpriseName");
            if (employeeDtl1.UpdEmployeeName != employeeDtl2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
    // 2009.03.02 ���������֒u������(�蓮�ύX�ӏ��F1.Equals��EqualsDtl 2.�������喼��(belongSubSectionName)�̒ǉ�) <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoMngSet
	/// <summary>
	///                      �ԍ��Ǘ��ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �ԍ��Ǘ��ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/8/30</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoMngSet
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

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�ԍ��R�[�h</summary>
		/// <remarks>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</remarks>
		private Int32 _noCode;

		/// <summary>�ԍ����ݒl</summary>
		/// <remarks>�ԍ����ݒl�܂��͘_���폜ں��ތ���(���ڏڍ�)</remarks>
		private Int64 _noPresentVal;

		/// <summary>�ݒ�J�n�ԍ�</summary>
		private Int64 _settingStartNo;

		/// <summary>�ݒ�I���ԍ�</summary>
		private Int64 _settingEndNo;

		/// <summary>�ԍ�������</summary>
		private Int32 _noIncDecWidth;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>�ԍ�����</summary>
		private string _noName = "";


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
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get
			{
				return _sectionCode;
			}
			set
			{
				_sectionCode = value;
			}
		}

		/// public propaty name  :  NoCode
		/// <summary>�ԍ��R�[�h�v���p�e�B</summary>
		/// <value>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoCode
		{
			get
			{
				return _noCode;
			}
			set
			{
				_noCode = value;
			}
		}

		/// public propaty name  :  NoPresentVal
		/// <summary>�ԍ����ݒl�v���p�e�B</summary>
		/// <value>�ԍ����ݒl�܂��͘_���폜ں��ތ���(���ڏڍ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ����ݒl�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 NoPresentVal
		{
			get
			{
				return _noPresentVal;
			}
			set
			{
				_noPresentVal = value;
			}
		}

		/// public propaty name  :  SettingStartNo
		/// <summary>�ݒ�J�n�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݒ�J�n�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SettingStartNo
		{
			get
			{
				return _settingStartNo;
			}
			set
			{
				_settingStartNo = value;
			}
		}

		/// public propaty name  :  SettingEndNo
		/// <summary>�ݒ�I���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݒ�I���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SettingEndNo
		{
			get
			{
				return _settingEndNo;
			}
			set
			{
				_settingEndNo = value;
			}
		}

		/// public propaty name  :  NoIncDecWidth
		/// <summary>�ԍ��������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoIncDecWidth
		{
			get
			{
				return _noIncDecWidth;
			}
			set
			{
				_noIncDecWidth = value;
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

		/// public propaty name  :  NoName
		/// <summary>�ԍ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NoName
		{
			get
			{
				return _noName;
			}
			set
			{
				_noName = value;
			}
		}


		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>NoMngSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoMngSet()
		{
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="noCode">�ԍ��R�[�h(1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�))</param>
		/// <param name="noPresentVal">�ԍ����ݒl(�ԍ����ݒl�܂��͘_���폜ں��ތ���(���ڏڍ�))</param>
		/// <param name="settingStartNo">�ݒ�J�n�ԍ�</param>
		/// <param name="settingEndNo">�ݒ�I���ԍ�</param>
		/// <param name="noIncDecWidth">�ԍ�������</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="noName">�ԍ�����</param>
		/// <returns>NoMngSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoMngSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 noCode, Int64 noPresentVal, Int64 settingStartNo, Int64 settingEndNo, Int32 noIncDecWidth, string enterpriseName, string updEmployeeName, string noName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._noCode = noCode;
			this._noPresentVal = noPresentVal;
			this._settingStartNo = settingStartNo;
			this._settingEndNo = settingEndNo;
			this._noIncDecWidth = noIncDecWidth;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._noName = noName;

		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^��������
		/// </summary>
		/// <returns>NoMngSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����NoMngSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoMngSet Clone()
		{
			return new NoMngSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._noCode, this._noPresentVal, this._settingStartNo, this._settingEndNo, this._noIncDecWidth, this._enterpriseName, this._updEmployeeName, this._noName);
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�NoMngSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(NoMngSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.NoCode == target.NoCode)
				 && (this.NoPresentVal == target.NoPresentVal)
				 && (this.SettingStartNo == target.SettingStartNo)
				 && (this.SettingEndNo == target.SettingEndNo)
				 && (this.NoIncDecWidth == target.NoIncDecWidth)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.NoName == target.NoName));
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^��r����
		/// </summary>
		/// <param name="noMngSet1">
		///                    ��r����NoMngSet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="noMngSet2">��r����NoMngSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(NoMngSet noMngSet1, NoMngSet noMngSet2)
		{
			return ((noMngSet1.CreateDateTime == noMngSet2.CreateDateTime)
				 && (noMngSet1.UpdateDateTime == noMngSet2.UpdateDateTime)
				 && (noMngSet1.EnterpriseCode == noMngSet2.EnterpriseCode)
				 && (noMngSet1.FileHeaderGuid == noMngSet2.FileHeaderGuid)
				 && (noMngSet1.UpdEmployeeCode == noMngSet2.UpdEmployeeCode)
				 && (noMngSet1.UpdAssemblyId1 == noMngSet2.UpdAssemblyId1)
				 && (noMngSet1.UpdAssemblyId2 == noMngSet2.UpdAssemblyId2)
				 && (noMngSet1.LogicalDeleteCode == noMngSet2.LogicalDeleteCode)
				 && (noMngSet1.SectionCode == noMngSet2.SectionCode)
				 && (noMngSet1.NoCode == noMngSet2.NoCode)
				 && (noMngSet1.NoPresentVal == noMngSet2.NoPresentVal)
				 && (noMngSet1.SettingStartNo == noMngSet2.SettingStartNo)
				 && (noMngSet1.SettingEndNo == noMngSet2.SettingEndNo)
				 && (noMngSet1.NoIncDecWidth == noMngSet2.NoIncDecWidth)
				 && (noMngSet1.EnterpriseName == noMngSet2.EnterpriseName)
				 && (noMngSet1.UpdEmployeeName == noMngSet2.UpdEmployeeName)
				 && (noMngSet1.NoName == noMngSet2.NoName));
		}
		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�NoMngSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(NoMngSet target)
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
			if (this.SectionCode != target.SectionCode)
				resList.Add("SectionCode");
			if (this.NoCode != target.NoCode)
				resList.Add("NoCode");
			if (this.NoPresentVal != target.NoPresentVal)
				resList.Add("NoPresentVal");
			if (this.SettingStartNo != target.SettingStartNo)
				resList.Add("SettingStartNo");
			if (this.SettingEndNo != target.SettingEndNo)
				resList.Add("SettingEndNo");
			if (this.NoIncDecWidth != target.NoIncDecWidth)
				resList.Add("NoIncDecWidth");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (this.NoName != target.NoName)
				resList.Add("NoName");

			return resList;
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^��r����
		/// </summary>
		/// <param name="noMngSet1">��r����NoMngSet�N���X�̃C���X�^���X</param>
		/// <param name="noMngSet2">��r����NoMngSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(NoMngSet noMngSet1, NoMngSet noMngSet2)
		{
			ArrayList resList = new ArrayList();
			if (noMngSet1.CreateDateTime != noMngSet2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (noMngSet1.UpdateDateTime != noMngSet2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (noMngSet1.EnterpriseCode != noMngSet2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (noMngSet1.FileHeaderGuid != noMngSet2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (noMngSet1.UpdEmployeeCode != noMngSet2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (noMngSet1.UpdAssemblyId1 != noMngSet2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (noMngSet1.UpdAssemblyId2 != noMngSet2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (noMngSet1.LogicalDeleteCode != noMngSet2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (noMngSet1.SectionCode != noMngSet2.SectionCode)
				resList.Add("SectionCode");
			if (noMngSet1.NoCode != noMngSet2.NoCode)
				resList.Add("NoCode");
			if (noMngSet1.NoPresentVal != noMngSet2.NoPresentVal)
				resList.Add("NoPresentVal");
			if (noMngSet1.SettingStartNo != noMngSet2.SettingStartNo)
				resList.Add("SettingStartNo");
			if (noMngSet1.SettingEndNo != noMngSet2.SettingEndNo)
				resList.Add("SettingEndNo");
			if (noMngSet1.NoIncDecWidth != noMngSet2.NoIncDecWidth)
				resList.Add("NoIncDecWidth");
			if (noMngSet1.EnterpriseName != noMngSet2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (noMngSet1.UpdEmployeeName != noMngSet2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (noMngSet1.NoName != noMngSet2.NoName)
				resList.Add("NoName");

			return resList;
		}
	}
}

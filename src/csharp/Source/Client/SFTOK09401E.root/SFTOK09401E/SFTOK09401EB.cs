using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoteGuidBd
	/// <summary>
	///                      ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/10/06</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoteGuidBd
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

		/// <summary>���l�K�C�h�敪</summary>
        /// <remarks>1�`100:�ڋq���l,201�`205:�q�w�敪1�`5</remarks>
		private Int32 _noteGuideDivCode;

		/// <summary>���l�K�C�h�敪����</summary>
		private string _noteGuideDivName = "";

		/// <summary>���l�K�C�h�R�[�h</summary>
		private Int32 _noteGuideCode;

		/// <summary>���l�K�C�h����</summary>
		private string _noteGuideName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";


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

		/// public propaty name  :  NoteGuideDivCode
		/// <summary>���l�K�C�h�敪�v���p�e�B</summary>
        /// <value>1�`100:�ڋq���l,201�`205:�q�w�敪1�`5</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�K�C�h�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoteGuideDivCode
		{
			get{return _noteGuideDivCode;}
			set{_noteGuideDivCode = value;}
		}

		/// public propaty name  :  NoteGuideDivName
		/// <summary>���l�K�C�h�敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�K�C�h�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NoteGuideDivName
		{
			get{return _noteGuideDivName;}
			set{_noteGuideDivName = value;}
		}

		/// public propaty name  :  NoteGuideCode
		/// <summary>���l�K�C�h�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�K�C�h�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoteGuideCode
		{
			get{return _noteGuideCode;}
			set{_noteGuideCode = value;}
		}

		/// public propaty name  :  NoteGuideName
		/// <summary>���l�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NoteGuideName
		{
			get{return _noteGuideName;}
			set{_noteGuideName = value;}
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


		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>NoteGuidBd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidBd�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoteGuidBd()
		{
		}

		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪(1�`100:�ڋq���l,201�`205:�q�w�敪1�`5)</param>
		/// <param name="noteGuideDivName">���l�K�C�h�敪����</param>
		/// <param name="noteGuideCode">���l�K�C�h�R�[�h</param>
		/// <param name="noteGuideName">���l�K�C�h����</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>NoteGuidBd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidBd�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoteGuidBd(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 noteGuideDivCode,string noteGuideDivName,Int32 noteGuideCode,string noteGuideName,string updEmployeeName,string enterpriseName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._noteGuideDivCode = noteGuideDivCode;
			this._noteGuideDivName = noteGuideDivName;
			this._noteGuideCode = noteGuideCode;
			this._noteGuideName = noteGuideName;
			this._updEmployeeName = updEmployeeName;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X��������
		/// </summary>
		/// <returns>NoteGuidBd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����NoteGuidBd�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoteGuidBd Clone()
		{
			return new NoteGuidBd(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._noteGuideDivCode,this._noteGuideDivName,this._noteGuideCode,this._noteGuideName,this._updEmployeeName,this._enterpriseName);
		}

		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�NoteGuidBd�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidBd�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(NoteGuidBd target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.NoteGuideDivCode == target.NoteGuideDivCode)
				 && (this.NoteGuideDivName == target.NoteGuideDivName)
				 && (this.NoteGuideCode == target.NoteGuideCode)
				 && (this.NoteGuideName == target.NoteGuideName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X��r����
		/// </summary>
		/// <param name="noteGuidBd1">
		///                    ��r����NoteGuidBd�N���X�̃C���X�^���X
		/// </param>
		/// <param name="noteGuidBd2">��r����NoteGuidBd�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidBd�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(NoteGuidBd noteGuidBd1, NoteGuidBd noteGuidBd2)
		{
			return ((noteGuidBd1.CreateDateTime == noteGuidBd2.CreateDateTime)
				 && (noteGuidBd1.UpdateDateTime == noteGuidBd2.UpdateDateTime)
				 && (noteGuidBd1.EnterpriseCode == noteGuidBd2.EnterpriseCode)
				 && (noteGuidBd1.FileHeaderGuid == noteGuidBd2.FileHeaderGuid)
				 && (noteGuidBd1.UpdEmployeeCode == noteGuidBd2.UpdEmployeeCode)
				 && (noteGuidBd1.UpdAssemblyId1 == noteGuidBd2.UpdAssemblyId1)
				 && (noteGuidBd1.UpdAssemblyId2 == noteGuidBd2.UpdAssemblyId2)
				 && (noteGuidBd1.LogicalDeleteCode == noteGuidBd2.LogicalDeleteCode)
				 && (noteGuidBd1.NoteGuideDivCode == noteGuidBd2.NoteGuideDivCode)
				 && (noteGuidBd1.NoteGuideDivName == noteGuidBd2.NoteGuideDivName)
				 && (noteGuidBd1.NoteGuideCode == noteGuidBd2.NoteGuideCode)
				 && (noteGuidBd1.NoteGuideName == noteGuidBd2.NoteGuideName)
				 && (noteGuidBd1.UpdEmployeeName == noteGuidBd2.UpdEmployeeName)
				 && (noteGuidBd1.EnterpriseName == noteGuidBd2.EnterpriseName));
		}
		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�NoteGuidBd�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidBd�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(NoteGuidBd target)
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
			if(this.NoteGuideDivCode != target.NoteGuideDivCode)resList.Add("NoteGuideDivCode");
			if(this.NoteGuideDivName != target.NoteGuideDivName)resList.Add("NoteGuideDivName");
			if(this.NoteGuideCode != target.NoteGuideCode)resList.Add("NoteGuideCode");
			if(this.NoteGuideName != target.NoteGuideName)resList.Add("NoteGuideName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// ���l�K�C�h�}�X�^�i�{�f�B�j�i���[�U�ύX���j�N���X��r����
		/// </summary>
		/// <param name="noteGuidBd1">��r����NoteGuidBd�N���X�̃C���X�^���X</param>
		/// <param name="noteGuidBd2">��r����NoteGuidBd�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidBd�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(NoteGuidBd noteGuidBd1, NoteGuidBd noteGuidBd2)
		{
			ArrayList resList = new ArrayList();
			if(noteGuidBd1.CreateDateTime != noteGuidBd2.CreateDateTime)resList.Add("CreateDateTime");
			if(noteGuidBd1.UpdateDateTime != noteGuidBd2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(noteGuidBd1.EnterpriseCode != noteGuidBd2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(noteGuidBd1.FileHeaderGuid != noteGuidBd2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(noteGuidBd1.UpdEmployeeCode != noteGuidBd2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(noteGuidBd1.UpdAssemblyId1 != noteGuidBd2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(noteGuidBd1.UpdAssemblyId2 != noteGuidBd2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(noteGuidBd1.LogicalDeleteCode != noteGuidBd2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(noteGuidBd1.NoteGuideDivCode != noteGuidBd2.NoteGuideDivCode)resList.Add("NoteGuideDivCode");
			if(noteGuidBd1.NoteGuideDivName != noteGuidBd2.NoteGuideDivName)resList.Add("NoteGuideDivName");
			if(noteGuidBd1.NoteGuideCode != noteGuidBd2.NoteGuideCode)resList.Add("NoteGuideCode");
			if(noteGuidBd1.NoteGuideName != noteGuidBd2.NoteGuideName)resList.Add("NoteGuideName");
			if(noteGuidBd1.UpdEmployeeName != noteGuidBd2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(noteGuidBd1.EnterpriseName != noteGuidBd2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}

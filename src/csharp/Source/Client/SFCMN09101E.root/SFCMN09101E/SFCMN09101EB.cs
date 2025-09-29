using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoTypeMng
	/// <summary>
	///                      �ԍ��^�C�v�Ǘ��}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �ԍ��^�C�v�Ǘ��}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/8/30</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoTypeMng
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

		/// <summary>�ԍ��R�[�h</summary>
		/// <remarks>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</remarks>
		private Int32 _noCode;

		/// <summary>�ԍ�����</summary>
		private string _noName = "";

		/// <summary>�ԍ����ڌ^</summary>
		/// <remarks>0:���l 1:����</remarks>
		private Int32 _noItemPatternCd;

		/// <summary>�ԍ�����</summary>
		private Int32 _noCharcterCount;

		/// <summary>�ԍ��A�Ԍ���</summary>
		private Int32 _consNoCharcterCount;

		/// <summary>�ԍ��\���ʒu�敪</summary>
		/// <remarks>0:�E�l�� 1:���l��</remarks>
		private Int32 _noDispPositionDivCd;

		/// <summary>�ԍ��̔ԋ敪</summary>
		/// <remarks>0:�����̔Ԗ��� 1:�����̔ԗL��</remarks>
		private Int32 _numberingDivCd;

		/// <summary>�ԍ��̔ԃ^�C�v</summary>
		/// <remarks>0:�A�� 1:���X�V����1 2:�N�X�V����1 ��1</remarks>
		private Int32 _numberingTypeDivCd;

		/// <summary>�ԍ��̔Ԕ͈�</summary>
		/// <remarks>0:��ƒʔ�(���_���薳��) 1:��ƒʔ�(���_����L��) 2:���_�ʔ�</remarks>
		private Int32 _numberingAmbitDivCd;

		/// <summary>�ԍ����Z�b�g�^�C�~���O</summary>
		/// <remarks>0:�ݒ�I���ԍ� 1:�N 2:�� 3:��</remarks>
		private Int32 _noResetTimingDivCd;

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

		/// public propaty name  :  NoItemPatternCd
		/// <summary>�ԍ����ڌ^�v���p�e�B</summary>
		/// <value>0:���l 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ����ڌ^�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoItemPatternCd
		{
			get
			{
				return _noItemPatternCd;
			}
			set
			{
				_noItemPatternCd = value;
			}
		}

		/// public propaty name  :  NoCharcterCount
		/// <summary>�ԍ������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoCharcterCount
		{
			get
			{
				return _noCharcterCount;
			}
			set
			{
				_noCharcterCount = value;
			}
		}

		/// public propaty name  :  ConsNoCharcterCount
		/// <summary>�ԍ��A�Ԍ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��A�Ԍ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ConsNoCharcterCount
		{
			get
			{
				return _consNoCharcterCount;
			}
			set
			{
				_consNoCharcterCount = value;
			}
		}

		/// public propaty name  :  NoDispPositionDivCd
		/// <summary>�ԍ��\���ʒu�敪�v���p�e�B</summary>
		/// <value>0:�E�l�� 1:���l��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��\���ʒu�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoDispPositionDivCd
		{
			get
			{
				return _noDispPositionDivCd;
			}
			set
			{
				_noDispPositionDivCd = value;
			}
		}

		/// public propaty name  :  NumberingDivCd
		/// <summary>�ԍ��̔ԋ敪�v���p�e�B</summary>
		/// <value>0:�����̔Ԗ��� 1:�����̔ԗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��̔ԋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberingDivCd
		{
			get
			{
				return _numberingDivCd;
			}
			set
			{
				_numberingDivCd = value;
			}
		}

		/// public propaty name  :  NumberingTypeDivCd
		/// <summary>�ԍ��̔ԃ^�C�v�v���p�e�B</summary>
		/// <value>0:�A�� 1:���X�V����1 2:�N�X�V����1 ��1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��̔ԃ^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberingTypeDivCd
		{
			get
			{
				return _numberingTypeDivCd;
			}
			set
			{
				_numberingTypeDivCd = value;
			}
		}

		/// public propaty name  :  NumberingAmbitDivCd
		/// <summary>�ԍ��̔Ԕ͈̓v���p�e�B</summary>
		/// <value>0:��ƒʔ�(���_���薳��) 1:��ƒʔ�(���_����L��) 2:���_�ʔ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��̔Ԕ͈̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberingAmbitDivCd
		{
			get
			{
				return _numberingAmbitDivCd;
			}
			set
			{
				_numberingAmbitDivCd = value;
			}
		}

		/// public propaty name  :  NoResetTimingDivCd
		/// <summary>�ԍ����Z�b�g�^�C�~���O�v���p�e�B</summary>
		/// <value>0:�ݒ�I���ԍ� 1:�N 2:�� 3:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ����Z�b�g�^�C�~���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoResetTimingDivCd
		{
			get
			{
				return _noResetTimingDivCd;
			}
			set
			{
				_noResetTimingDivCd = value;
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


		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>NoTypeMng�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoTypeMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoTypeMng()
		{
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="noCode">�ԍ��R�[�h(1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�))</param>
		/// <param name="noName">�ԍ�����</param>
		/// <param name="noItemPatternCd">�ԍ����ڌ^(0:���l 1:����)</param>
		/// <param name="noCharcterCount">�ԍ�����</param>
		/// <param name="consNoCharcterCount">�ԍ��A�Ԍ���</param>
		/// <param name="noDispPositionDivCd">�ԍ��\���ʒu�敪(0:�E�l�� 1:���l��)</param>
		/// <param name="numberingDivCd">�ԍ��̔ԋ敪(0:�����̔Ԗ��� 1:�����̔ԗL��)</param>
		/// <param name="numberingTypeDivCd">�ԍ��̔ԃ^�C�v(0:�A�� 1:���X�V����1 2:�N�X�V����1 ��1)</param>
		/// <param name="numberingAmbitDivCd">�ԍ��̔Ԕ͈�(0:��ƒʔ�(���_���薳��) 1:��ƒʔ�(���_����L��) 2:���_�ʔ�)</param>
		/// <param name="noResetTimingDivCd">�ԍ����Z�b�g�^�C�~���O(0:�ݒ�I���ԍ� 1:�N 2:�� 3:��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>NoTypeMng�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoTypeMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoTypeMng(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 noCode, string noName, Int32 noItemPatternCd, Int32 noCharcterCount, Int32 consNoCharcterCount, Int32 noDispPositionDivCd, Int32 numberingDivCd, Int32 numberingTypeDivCd, Int32 numberingAmbitDivCd, Int32 noResetTimingDivCd, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._noCode = noCode;
			this._noName = noName;
			this._noItemPatternCd = noItemPatternCd;
			this._noCharcterCount = noCharcterCount;
			this._consNoCharcterCount = consNoCharcterCount;
			this._noDispPositionDivCd = noDispPositionDivCd;
			this._numberingDivCd = numberingDivCd;
			this._numberingTypeDivCd = numberingTypeDivCd;
			this._numberingAmbitDivCd = numberingAmbitDivCd;
			this._noResetTimingDivCd = noResetTimingDivCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^��������
		/// </summary>
		/// <returns>NoTypeMng�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����NoTypeMng�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoTypeMng Clone()
		{
			return new NoTypeMng(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._noCode, this._noName, this._noItemPatternCd, this._noCharcterCount, this._consNoCharcterCount, this._noDispPositionDivCd, this._numberingDivCd, this._numberingTypeDivCd, this._numberingAmbitDivCd, this._noResetTimingDivCd, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�NoTypeMng�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoTypeMng�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(NoTypeMng target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.NoCode == target.NoCode)
				 && (this.NoName == target.NoName)
				 && (this.NoItemPatternCd == target.NoItemPatternCd)
				 && (this.NoCharcterCount == target.NoCharcterCount)
				 && (this.ConsNoCharcterCount == target.ConsNoCharcterCount)
				 && (this.NoDispPositionDivCd == target.NoDispPositionDivCd)
				 && (this.NumberingDivCd == target.NumberingDivCd)
				 && (this.NumberingTypeDivCd == target.NumberingTypeDivCd)
				 && (this.NumberingAmbitDivCd == target.NumberingAmbitDivCd)
				 && (this.NoResetTimingDivCd == target.NoResetTimingDivCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="noTypeMng1">
		///                    ��r����NoTypeMng�N���X�̃C���X�^���X
		/// </param>
		/// <param name="noTypeMng2">��r����NoTypeMng�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoTypeMng�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(NoTypeMng noTypeMng1, NoTypeMng noTypeMng2)
		{
			return ((noTypeMng1.CreateDateTime == noTypeMng2.CreateDateTime)
				 && (noTypeMng1.UpdateDateTime == noTypeMng2.UpdateDateTime)
				 && (noTypeMng1.EnterpriseCode == noTypeMng2.EnterpriseCode)
				 && (noTypeMng1.FileHeaderGuid == noTypeMng2.FileHeaderGuid)
				 && (noTypeMng1.UpdEmployeeCode == noTypeMng2.UpdEmployeeCode)
				 && (noTypeMng1.UpdAssemblyId1 == noTypeMng2.UpdAssemblyId1)
				 && (noTypeMng1.UpdAssemblyId2 == noTypeMng2.UpdAssemblyId2)
				 && (noTypeMng1.LogicalDeleteCode == noTypeMng2.LogicalDeleteCode)
				 && (noTypeMng1.NoCode == noTypeMng2.NoCode)
				 && (noTypeMng1.NoName == noTypeMng2.NoName)
				 && (noTypeMng1.NoItemPatternCd == noTypeMng2.NoItemPatternCd)
				 && (noTypeMng1.NoCharcterCount == noTypeMng2.NoCharcterCount)
				 && (noTypeMng1.ConsNoCharcterCount == noTypeMng2.ConsNoCharcterCount)
				 && (noTypeMng1.NoDispPositionDivCd == noTypeMng2.NoDispPositionDivCd)
				 && (noTypeMng1.NumberingDivCd == noTypeMng2.NumberingDivCd)
				 && (noTypeMng1.NumberingTypeDivCd == noTypeMng2.NumberingTypeDivCd)
				 && (noTypeMng1.NumberingAmbitDivCd == noTypeMng2.NumberingAmbitDivCd)
				 && (noTypeMng1.NoResetTimingDivCd == noTypeMng2.NoResetTimingDivCd)
				 && (noTypeMng1.EnterpriseName == noTypeMng2.EnterpriseName)
				 && (noTypeMng1.UpdEmployeeName == noTypeMng2.UpdEmployeeName));
		}
		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�NoTypeMng�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoTypeMng�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(NoTypeMng target)
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
			if (this.NoCode != target.NoCode)
				resList.Add("NoCode");
			if (this.NoName != target.NoName)
				resList.Add("NoName");
			if (this.NoItemPatternCd != target.NoItemPatternCd)
				resList.Add("NoItemPatternCd");
			if (this.NoCharcterCount != target.NoCharcterCount)
				resList.Add("NoCharcterCount");
			if (this.ConsNoCharcterCount != target.ConsNoCharcterCount)
				resList.Add("ConsNoCharcterCount");
			if (this.NoDispPositionDivCd != target.NoDispPositionDivCd)
				resList.Add("NoDispPositionDivCd");
			if (this.NumberingDivCd != target.NumberingDivCd)
				resList.Add("NumberingDivCd");
			if (this.NumberingTypeDivCd != target.NumberingTypeDivCd)
				resList.Add("NumberingTypeDivCd");
			if (this.NumberingAmbitDivCd != target.NumberingAmbitDivCd)
				resList.Add("NumberingAmbitDivCd");
			if (this.NoResetTimingDivCd != target.NoResetTimingDivCd)
				resList.Add("NoResetTimingDivCd");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="noTypeMng1">��r����NoTypeMng�N���X�̃C���X�^���X</param>
		/// <param name="noTypeMng2">��r����NoTypeMng�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoTypeMng�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(NoTypeMng noTypeMng1, NoTypeMng noTypeMng2)
		{
			ArrayList resList = new ArrayList();
			if (noTypeMng1.CreateDateTime != noTypeMng2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (noTypeMng1.UpdateDateTime != noTypeMng2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (noTypeMng1.EnterpriseCode != noTypeMng2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (noTypeMng1.FileHeaderGuid != noTypeMng2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (noTypeMng1.UpdEmployeeCode != noTypeMng2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (noTypeMng1.UpdAssemblyId1 != noTypeMng2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (noTypeMng1.UpdAssemblyId2 != noTypeMng2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (noTypeMng1.LogicalDeleteCode != noTypeMng2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (noTypeMng1.NoCode != noTypeMng2.NoCode)
				resList.Add("NoCode");
			if (noTypeMng1.NoName != noTypeMng2.NoName)
				resList.Add("NoName");
			if (noTypeMng1.NoItemPatternCd != noTypeMng2.NoItemPatternCd)
				resList.Add("NoItemPatternCd");
			if (noTypeMng1.NoCharcterCount != noTypeMng2.NoCharcterCount)
				resList.Add("NoCharcterCount");
			if (noTypeMng1.ConsNoCharcterCount != noTypeMng2.ConsNoCharcterCount)
				resList.Add("ConsNoCharcterCount");
			if (noTypeMng1.NoDispPositionDivCd != noTypeMng2.NoDispPositionDivCd)
				resList.Add("NoDispPositionDivCd");
			if (noTypeMng1.NumberingDivCd != noTypeMng2.NumberingDivCd)
				resList.Add("NumberingDivCd");
			if (noTypeMng1.NumberingTypeDivCd != noTypeMng2.NumberingTypeDivCd)
				resList.Add("NumberingTypeDivCd");
			if (noTypeMng1.NumberingAmbitDivCd != noTypeMng2.NumberingAmbitDivCd)
				resList.Add("NumberingAmbitDivCd");
			if (noTypeMng1.NoResetTimingDivCd != noTypeMng2.NoResetTimingDivCd)
				resList.Add("NoResetTimingDivCd");
			if (noTypeMng1.EnterpriseName != noTypeMng2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (noTypeMng1.UpdEmployeeName != noTypeMng2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExMacroDef
	/// <summary>
	///                      �g���}�N��������`�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �g���}�N��������`�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2006/10/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExMacroDef
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

		/// <summary>�g���}�N�������Ǘ��A��</summary>
		private Int32 _exMacroCharMngCnsNo;

		/// <summary>�g���}�N����������</summary>
		private string _exMacroCharName = "";

		/// <summary>�g���}�N������</summary>
		/// <remarks>�}�N�������̍ŏ���`</remarks>
		private string _exMacroCharcter = "";

		/// <summary>�g���}�N�������W�J������</summary>
		/// <remarks>�}�N��������W�J����(�G�f�B�^��)�ۂ̃f�t�H���g������</remarks>
		private Int32 _exMacroCharDvlpCnt;

		/// <summary>�g���}�N�������ϊ�������</summary>
		/// <remarks>�}�N���������f�[�^�l�ϊ����̍ő啶����</remarks>
		private Int32 _exMacroCharChngCnt;

		/// <summary>�g���}�N�������ϊ�DD</summary>
		private string _exMacroCharChngDd = "";

		/// <summary>�g���}�N�������⑫����</summary>
		private string _exMacroCharAddExpla = "";

		/// <summary>�g���}�N�������ϊ���</summary>
		private string _exMacroCharChgSample = "";

		/// <summary>�g���}�N���ϊ��ҏW��`1</summary>
		/// <remarks>�ϊ��f�[�^�������ꍇ�ɒu��������f�t�H���g������</remarks>
		private string _exMacroCharChgEdDef1 = "";

		/// <summary>�g���}�N���ϊ��ҏW��`2</summary>
		/// <remarks>������ҏW�敪0:�ҏW��, 1:���g����, 2:�E�g����, 3:���g����, 12:�E�l�ҏW, 15:�Z���^�����O</remarks>
		private Int32 _exMacroCharChgEdDef2;

		/// <summary>�g���}�N���v���C�o�V�[�|���V�[</summary>
		/// <remarks>0:�`�F�b�N����, 1:�`�F�b�N����</remarks>
        private Int32 _exMacroPrivacyPolicy = 0;

        /// <summary>�g���}�N���^���</summary>
        /// <remarks>0:��������, 1:���l����</remarks>
        private Int32 _exMacroTypeKind = 0;


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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  ExMacroCharMngCnsNo
		/// <summary>�g���}�N�������Ǘ��A�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������Ǘ��A�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExMacroCharMngCnsNo
		{
			get{return _exMacroCharMngCnsNo;}
			set{_exMacroCharMngCnsNo = value;}
		}

		/// public propaty name  :  ExMacroCharName
		/// <summary>�g���}�N���������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N���������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExMacroCharName
		{
			get{return _exMacroCharName;}
			set{_exMacroCharName = value;}
		}

		/// public propaty name  :  ExMacroCharcter
		/// <summary>�g���}�N�������v���p�e�B</summary>
		/// <value>�}�N�������̍ŏ���`</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExMacroCharcter
		{
			get{return _exMacroCharcter;}
			set{_exMacroCharcter = value;}
		}

		/// public propaty name  :  ExMacroCharDvlpCnt
		/// <summary>�g���}�N�������W�J�������v���p�e�B</summary>
		/// <value>�}�N��������W�J����(�G�f�B�^��)�ۂ̃f�t�H���g������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������W�J�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExMacroCharDvlpCnt
		{
			get{return _exMacroCharDvlpCnt;}
			set{_exMacroCharDvlpCnt = value;}
		}

		/// public propaty name  :  ExMacroCharChngCnt
		/// <summary>�g���}�N�������ϊ��������v���p�e�B</summary>
		/// <value>�}�N���������f�[�^�l�ϊ����̍ő啶����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������ϊ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExMacroCharChngCnt
		{
			get{return _exMacroCharChngCnt;}
			set{_exMacroCharChngCnt = value;}
		}

		/// public propaty name  :  ExMacroCharChngDd
		/// <summary>�g���}�N�������ϊ�DD�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������ϊ�DD�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExMacroCharChngDd
		{
			get{return _exMacroCharChngDd;}
			set{_exMacroCharChngDd = value;}
		}

		/// public propaty name  :  ExMacroCharAddExpla
		/// <summary>�g���}�N�������⑫�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������⑫�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExMacroCharAddExpla
		{
			get{return _exMacroCharAddExpla;}
			set{_exMacroCharAddExpla = value;}
		}

		/// public propaty name  :  ExMacroCharChgSample
		/// <summary>�g���}�N�������ϊ���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N�������ϊ���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExMacroCharChgSample
		{
			get{return _exMacroCharChgSample;}
			set{_exMacroCharChgSample = value;}
		}

		/// public propaty name  :  ExMacroCharChgEdDef1
		/// <summary>�g���}�N���ϊ��ҏW��`1�v���p�e�B</summary>
		/// <value>�ϊ��f�[�^�������ꍇ�ɒu��������f�t�H���g������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N���ϊ��ҏW��`1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExMacroCharChgEdDef1
		{
			get{return _exMacroCharChgEdDef1;}
			set{_exMacroCharChgEdDef1 = value;}
		}

		/// public propaty name  :  ExMacroCharChgEdDef2
		/// <summary>�g���}�N���ϊ��ҏW��`2�v���p�e�B</summary>
		/// <value>������ҏW�敪0:�ҏW��, 1:���g����, 2:�E�g����, 3:���g����, 12:�E�l�ҏW, 15:�Z���^�����O</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N���ϊ��ҏW��`2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExMacroCharChgEdDef2
		{
			get{return _exMacroCharChgEdDef2;}
			set{_exMacroCharChgEdDef2 = value;}
		}

		/// public propaty name  :  ExMacroPrivacyPolicy
		/// <summary>�g���}�N���v���C�o�V�[�|���V�[�v���p�e�B</summary>
		/// <value>0:�`�F�b�N����, 1:�`�F�b�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g���}�N���v���C�o�V�[�|���V�[�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExMacroPrivacyPolicy
		{
			get{return _exMacroPrivacyPolicy;}
			set{_exMacroPrivacyPolicy = value;}
		}

        /// public propaty name  :  ExMacroPrivacyPolicy
        /// <summary>�g���}�N���^��ʃv���p�e�B</summary>
        /// <value>0:��������, 1:���l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g���}�N���^��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExMacroTypeKind
        {
            get { return _exMacroTypeKind; }
            set { _exMacroTypeKind = value; }
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


		/// <summary>
		/// �g���}�N��������`�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>ExMacroDef�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExMacroDef�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExMacroDef()
		{
		}

		/// <summary>
		/// �g���}�N��������`�}�X�^�R���X�g���N�^
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
		/// <param name="exMacroCharMngCnsNo">�g���}�N�������Ǘ��A��</param>
		/// <param name="exMacroCharName">�g���}�N����������</param>
		/// <param name="exMacroCharcter">�g���}�N������(�}�N�������̍ŏ���`)</param>
		/// <param name="exMacroCharDvlpCnt">�g���}�N�������W�J������(�}�N��������W�J����(�G�f�B�^��)�ۂ̃f�t�H���g������)</param>
		/// <param name="exMacroCharChngCnt">�g���}�N�������ϊ�������(�}�N���������f�[�^�l�ϊ����̍ő啶����)</param>
		/// <param name="exMacroCharChngDd">�g���}�N�������ϊ�DD</param>
		/// <param name="exMacroCharAddExpla">�g���}�N�������⑫����</param>
		/// <param name="exMacroCharChgSample">�g���}�N�������ϊ���</param>
		/// <param name="exMacroCharChgEdDef1">�g���}�N���ϊ��ҏW��`1(�ϊ��f�[�^�������ꍇ�ɒu��������f�t�H���g������)</param>
		/// <param name="exMacroCharChgEdDef2">�g���}�N���ϊ��ҏW��`2(������ҏW�敪0:�ҏW��, 1:���g����, 2:�E�g����, 3:���g����, 12:�E�l�ҏW, 15:�Z���^�����O)</param>
		/// <param name="exMacroPrivacyPolicy">�g���}�N���v���C�o�V�[�|���V�[(0:�`�F�b�N����, 1:�`�F�b�N����)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>ExMacroDef�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExMacroDef�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExMacroDef(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 exMacroCharMngCnsNo,string exMacroCharName,string exMacroCharcter,Int32 exMacroCharDvlpCnt,Int32 exMacroCharChngCnt,string exMacroCharChngDd,string exMacroCharAddExpla,string exMacroCharChgSample,string exMacroCharChgEdDef1,Int32 exMacroCharChgEdDef2,Int32 exMacroPrivacyPolicy,string enterpriseName,string updEmployeeName)
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
			this._exMacroCharMngCnsNo = exMacroCharMngCnsNo;
			this._exMacroCharName = exMacroCharName;
			this._exMacroCharcter = exMacroCharcter;
			this._exMacroCharDvlpCnt = exMacroCharDvlpCnt;
			this._exMacroCharChngCnt = exMacroCharChngCnt;
			this._exMacroCharChngDd = exMacroCharChngDd;
			this._exMacroCharAddExpla = exMacroCharAddExpla;
			this._exMacroCharChgSample = exMacroCharChgSample;
			this._exMacroCharChgEdDef1 = exMacroCharChgEdDef1;
			this._exMacroCharChgEdDef2 = exMacroCharChgEdDef2;
			this._exMacroPrivacyPolicy = exMacroPrivacyPolicy;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// �g���}�N��������`�}�X�^��������
		/// </summary>
		/// <returns>ExMacroDef�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExMacroDef�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExMacroDef Clone()
		{
			return new ExMacroDef(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._exMacroCharMngCnsNo,this._exMacroCharName,this._exMacroCharcter,this._exMacroCharDvlpCnt,this._exMacroCharChngCnt,this._exMacroCharChngDd,this._exMacroCharAddExpla,this._exMacroCharChgSample,this._exMacroCharChgEdDef1,this._exMacroCharChgEdDef2,this._exMacroPrivacyPolicy,this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// �g���}�N��������`�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExMacroDef�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExMacroDef�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExMacroDef target)
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
				 && (this.ExMacroCharMngCnsNo == target.ExMacroCharMngCnsNo)
				 && (this.ExMacroCharName == target.ExMacroCharName)
				 && (this.ExMacroCharcter == target.ExMacroCharcter)
				 && (this.ExMacroCharDvlpCnt == target.ExMacroCharDvlpCnt)
				 && (this.ExMacroCharChngCnt == target.ExMacroCharChngCnt)
				 && (this.ExMacroCharChngDd == target.ExMacroCharChngDd)
				 && (this.ExMacroCharAddExpla == target.ExMacroCharAddExpla)
				 && (this.ExMacroCharChgSample == target.ExMacroCharChgSample)
				 && (this.ExMacroCharChgEdDef1 == target.ExMacroCharChgEdDef1)
				 && (this.ExMacroCharChgEdDef2 == target.ExMacroCharChgEdDef2)
				 && (this.ExMacroPrivacyPolicy == target.ExMacroPrivacyPolicy)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// �g���}�N��������`�}�X�^��r����
		/// </summary>
		/// <param name="exMacroDef1">
		///                    ��r����ExMacroDef�N���X�̃C���X�^���X
		/// </param>
		/// <param name="exMacroDef2">��r����ExMacroDef�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExMacroDef�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExMacroDef exMacroDef1, ExMacroDef exMacroDef2)
		{
			return ((exMacroDef1.CreateDateTime == exMacroDef2.CreateDateTime)
				 && (exMacroDef1.UpdateDateTime == exMacroDef2.UpdateDateTime)
				 && (exMacroDef1.EnterpriseCode == exMacroDef2.EnterpriseCode)
				 && (exMacroDef1.FileHeaderGuid == exMacroDef2.FileHeaderGuid)
				 && (exMacroDef1.UpdEmployeeCode == exMacroDef2.UpdEmployeeCode)
				 && (exMacroDef1.UpdAssemblyId1 == exMacroDef2.UpdAssemblyId1)
				 && (exMacroDef1.UpdAssemblyId2 == exMacroDef2.UpdAssemblyId2)
				 && (exMacroDef1.LogicalDeleteCode == exMacroDef2.LogicalDeleteCode)
				 && (exMacroDef1.SectionCode == exMacroDef2.SectionCode)
				 && (exMacroDef1.ExMacroCharMngCnsNo == exMacroDef2.ExMacroCharMngCnsNo)
				 && (exMacroDef1.ExMacroCharName == exMacroDef2.ExMacroCharName)
				 && (exMacroDef1.ExMacroCharcter == exMacroDef2.ExMacroCharcter)
				 && (exMacroDef1.ExMacroCharDvlpCnt == exMacroDef2.ExMacroCharDvlpCnt)
				 && (exMacroDef1.ExMacroCharChngCnt == exMacroDef2.ExMacroCharChngCnt)
				 && (exMacroDef1.ExMacroCharChngDd == exMacroDef2.ExMacroCharChngDd)
				 && (exMacroDef1.ExMacroCharAddExpla == exMacroDef2.ExMacroCharAddExpla)
				 && (exMacroDef1.ExMacroCharChgSample == exMacroDef2.ExMacroCharChgSample)
				 && (exMacroDef1.ExMacroCharChgEdDef1 == exMacroDef2.ExMacroCharChgEdDef1)
				 && (exMacroDef1.ExMacroCharChgEdDef2 == exMacroDef2.ExMacroCharChgEdDef2)
				 && (exMacroDef1.ExMacroPrivacyPolicy == exMacroDef2.ExMacroPrivacyPolicy)
				 && (exMacroDef1.EnterpriseName == exMacroDef2.EnterpriseName)
				 && (exMacroDef1.UpdEmployeeName == exMacroDef2.UpdEmployeeName));
		}

		/// <summary>
		/// �g���}�N��������`�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExMacroDef�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExMacroDef�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExMacroDef target)
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
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.ExMacroCharMngCnsNo != target.ExMacroCharMngCnsNo)resList.Add("ExMacroCharMngCnsNo");
			if(this.ExMacroCharName != target.ExMacroCharName)resList.Add("ExMacroCharName");
			if(this.ExMacroCharcter != target.ExMacroCharcter)resList.Add("ExMacroCharcter");
			if(this.ExMacroCharDvlpCnt != target.ExMacroCharDvlpCnt)resList.Add("ExMacroCharDvlpCnt");
			if(this.ExMacroCharChngCnt != target.ExMacroCharChngCnt)resList.Add("ExMacroCharChngCnt");
			if(this.ExMacroCharChngDd != target.ExMacroCharChngDd)resList.Add("ExMacroCharChngDd");
			if(this.ExMacroCharAddExpla != target.ExMacroCharAddExpla)resList.Add("ExMacroCharAddExpla");
			if(this.ExMacroCharChgSample != target.ExMacroCharChgSample)resList.Add("ExMacroCharChgSample");
			if(this.ExMacroCharChgEdDef1 != target.ExMacroCharChgEdDef1)resList.Add("ExMacroCharChgEdDef1");
			if(this.ExMacroCharChgEdDef2 != target.ExMacroCharChgEdDef2)resList.Add("ExMacroCharChgEdDef2");
			if(this.ExMacroPrivacyPolicy != target.ExMacroPrivacyPolicy)resList.Add("ExMacroPrivacyPolicy");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// �g���}�N��������`�}�X�^��r����
		/// </summary>
		/// <param name="exMacroDef1">��r����ExMacroDef�N���X�̃C���X�^���X</param>
		/// <param name="exMacroDef2">��r����ExMacroDef�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExMacroDef�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExMacroDef exMacroDef1, ExMacroDef exMacroDef2)
		{
			ArrayList resList = new ArrayList();
			if(exMacroDef1.CreateDateTime != exMacroDef2.CreateDateTime)resList.Add("CreateDateTime");
			if(exMacroDef1.UpdateDateTime != exMacroDef2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(exMacroDef1.EnterpriseCode != exMacroDef2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(exMacroDef1.FileHeaderGuid != exMacroDef2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(exMacroDef1.UpdEmployeeCode != exMacroDef2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(exMacroDef1.UpdAssemblyId1 != exMacroDef2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(exMacroDef1.UpdAssemblyId2 != exMacroDef2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(exMacroDef1.LogicalDeleteCode != exMacroDef2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(exMacroDef1.SectionCode != exMacroDef2.SectionCode)resList.Add("SectionCode");
			if(exMacroDef1.ExMacroCharMngCnsNo != exMacroDef2.ExMacroCharMngCnsNo)resList.Add("ExMacroCharMngCnsNo");
			if(exMacroDef1.ExMacroCharName != exMacroDef2.ExMacroCharName)resList.Add("ExMacroCharName");
			if(exMacroDef1.ExMacroCharcter != exMacroDef2.ExMacroCharcter)resList.Add("ExMacroCharcter");
			if(exMacroDef1.ExMacroCharDvlpCnt != exMacroDef2.ExMacroCharDvlpCnt)resList.Add("ExMacroCharDvlpCnt");
			if(exMacroDef1.ExMacroCharChngCnt != exMacroDef2.ExMacroCharChngCnt)resList.Add("ExMacroCharChngCnt");
			if(exMacroDef1.ExMacroCharChngDd != exMacroDef2.ExMacroCharChngDd)resList.Add("ExMacroCharChngDd");
			if(exMacroDef1.ExMacroCharAddExpla != exMacroDef2.ExMacroCharAddExpla)resList.Add("ExMacroCharAddExpla");
			if(exMacroDef1.ExMacroCharChgSample != exMacroDef2.ExMacroCharChgSample)resList.Add("ExMacroCharChgSample");
			if(exMacroDef1.ExMacroCharChgEdDef1 != exMacroDef2.ExMacroCharChgEdDef1)resList.Add("ExMacroCharChgEdDef1");
			if(exMacroDef1.ExMacroCharChgEdDef2 != exMacroDef2.ExMacroCharChgEdDef2)resList.Add("ExMacroCharChgEdDef2");
			if(exMacroDef1.ExMacroPrivacyPolicy != exMacroDef2.ExMacroPrivacyPolicy)resList.Add("ExMacroPrivacyPolicy");
			if(exMacroDef1.EnterpriseName != exMacroDef2.EnterpriseName)resList.Add("EnterpriseName");
			if(exMacroDef1.UpdEmployeeName != exMacroDef2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
        }


        //--------------------------------------------------------------------------------------------------
        //
        // �ȉ��̃R�[�h�͎蓮�ō쐬�������̂Ȃ̂ŁA�v���p�e�B���ēx����������������c���悤�ɂ��Ă�������
        //
        //--------------------------------------------------------------------------------------------------


        #region

        /// <summary>
        /// �g���}�N���ϊ��ҏW��`2  0:���ҏW
        /// </summary>
        public static int CharEditDiv_Default = 0; 
        /// <summary>
        /// �g���}�N���ϊ��ҏW��`2  1:���g����
        /// </summary>
        public static int CharEditDiv_Trim = 1; 
        /// <summary>
        /// �g���}�N���ϊ��ҏW��`2  2:�E�g����
        /// </summary>
        public static int CharEditDiv_TrimRight = 2;
        /// <summary>
        /// �g���}�N���ϊ��ҏW��`2  3:���g����
        /// </summary>
        public static int CharEditDiv_TrimLeft = 3; 
        /// <summary>
        /// �g���}�N���ϊ��ҏW��`2  12:�E�l�ҏW
        /// </summary>
        public static int CharEditDiv_HRight = 12;
        /// <summary>
        /// �g���}�N���ϊ��ҏW��`2  15:�Z���^�����O
        /// </summary>
        public static int CharEditDiv_HCenter = 15; 

//        0:�ҏW��, 1:���g����, 2:�E�g����, 3:���g����, 12:�E�l�ҏW, 15:�Z���^�����O

        /// <summary>
        /// �g���}�N���^���  0:��������
        /// </summary>
        public static int TermType_String = 0;

        /// <summary>
        /// �g���}�N���^���  1:���l����
        /// </summary>
        public static int TermType_Number = 1;

        /// <summary>
        /// �g���}�N���^���  10:���t����(GGYYMMDD)
        /// </summary>
        public static int TermType_Date = 10; 


        #endregion


    }
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   FrePprSrtO
	/// <summary>
	///                      ���R���[�\�[�g���ʃ}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[�\�[�g���ʃ}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   ����@�_�u</br>
	/// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePprSrtO
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

		/// <summary>�o�̓t�@�C����</summary>
		/// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
		private string _outputFormFileName = "";

		/// <summary>���[�U�[���[ID�}�ԍ�</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>�\�[�g���ʃR�[�h</summary>
		private Int32 _sortingOrderCode;

		/// <summary>�\�[�g����</summary>
		/// <remarks>���P</remarks>
		private Int32 _sortingOrder;

		/// <summary>���R���[���ږ���</summary>
		private string _freePrtPaperItemNm = "";

		/// <summary>DD����</summary>
		/// <remarks>�������œo�^</remarks>
		private string _dDName = "";

		/// <summary>�t�@�C������</summary>
		/// <remarks>DB�̃e�[�u��ID</remarks>
		private string _fileNm = "";

		/// <summary>�����~���敪</summary>
		/// <remarks>0:�Ȃ�,1:����,2:�~��</remarks>
		private Int32 _sortingOrderDivCd;

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

		/// public propaty name  :  OutputFormFileName
		/// <summary>�o�̓t�@�C�����v���p�e�B</summary>
		/// <value>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputFormFileName
		{
			get { return _outputFormFileName; }
			set { _outputFormFileName = value; }
		}

		/// public propaty name  :  UserPrtPprIdDerivNo
		/// <summary>���[�U�[���[ID�}�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[���[ID�}�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserPrtPprIdDerivNo
		{
			get { return _userPrtPprIdDerivNo; }
			set { _userPrtPprIdDerivNo = value; }
		}

		/// public propaty name  :  SortingOrderCode
		/// <summary>�\�[�g���ʃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�[�g���ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortingOrderCode
		{
			get { return _sortingOrderCode; }
			set { _sortingOrderCode = value; }
		}

		/// public propaty name  :  SortingOrder
		/// <summary>�\�[�g���ʃv���p�e�B</summary>
		/// <value>���P</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�[�g���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortingOrder
		{
			get { return _sortingOrder; }
			set { _sortingOrder = value; }
		}

		/// public propaty name  :  FreePrtPaperItemNm
		/// <summary>���R���[���ږ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ږ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FreePrtPaperItemNm
		{
			get { return _freePrtPaperItemNm; }
			set { _freePrtPaperItemNm = value; }
		}

		/// public propaty name  :  DDName
		/// <summary>DD���̃v���p�e�B</summary>
		/// <value>�������œo�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DDName
		{
			get { return _dDName; }
			set { _dDName = value; }
		}

		/// public propaty name  :  FileNm
		/// <summary>�t�@�C�����̃v���p�e�B</summary>
		/// <value>DB�̃e�[�u��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�@�C�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FileNm
		{
			get { return _fileNm; }
			set { _fileNm = value; }
		}

		/// public propaty name  :  SortingOrderDivCd
		/// <summary>�����~���敪�v���p�e�B</summary>
		/// <value>0:�Ȃ�,1:����,2:�~��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����~���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortingOrderDivCd
		{
			get { return _sortingOrderDivCd; }
			set { _sortingOrderDivCd = value; }
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
		/// ���R���[�\�[�g���ʃ}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>FrePprSrtO�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtO�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprSrtO()
		{
		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����(�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID)</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="sortingOrderCode">�\�[�g���ʃR�[�h</param>
		/// <param name="sortingOrder">�\�[�g����(���P)</param>
		/// <param name="freePrtPaperItemNm">���R���[���ږ���</param>
		/// <param name="dDName">DD����(�������œo�^)</param>
		/// <param name="fileNm">�t�@�C������(DB�̃e�[�u��ID)</param>
		/// <param name="sortingOrderDivCd">�����~���敪(0:�Ȃ�,1:����,2:�~��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>FrePprSrtO�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtO�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprSrtO(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 sortingOrderCode, Int32 sortingOrder, string freePrtPaperItemNm, string dDName, string fileNm, Int32 sortingOrderDivCd, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._outputFormFileName = outputFormFileName;
			this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this._sortingOrderCode = sortingOrderCode;
			this._sortingOrder = sortingOrder;
			this._freePrtPaperItemNm = freePrtPaperItemNm;
			this._dDName = dDName;
			this._fileNm = fileNm;
			this._sortingOrderDivCd = sortingOrderDivCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^��������
		/// </summary>
		/// <returns>FrePprSrtO�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����FrePprSrtO�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprSrtO Clone()
		{
			return new FrePprSrtO(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._sortingOrderCode, this._sortingOrder, this._freePrtPaperItemNm, this._dDName, this._fileNm, this._sortingOrderDivCd, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePprSrtO�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtO�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(FrePprSrtO target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.SortingOrderCode == target.SortingOrderCode)
				 && (this.SortingOrder == target.SortingOrder)
				 && (this.FreePrtPaperItemNm == target.FreePrtPaperItemNm)
				 && (this.DDName == target.DDName)
				 && (this.FileNm == target.FileNm)
				 && (this.SortingOrderDivCd == target.SortingOrderDivCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^��r����
		/// </summary>
		/// <param name="frePprSrtO1">
		///                    ��r����FrePprSrtO�N���X�̃C���X�^���X
		/// </param>
		/// <param name="frePprSrtO2">��r����FrePprSrtO�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtO�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(FrePprSrtO frePprSrtO1, FrePprSrtO frePprSrtO2)
		{
			return ((frePprSrtO1.CreateDateTime == frePprSrtO2.CreateDateTime)
				 && (frePprSrtO1.UpdateDateTime == frePprSrtO2.UpdateDateTime)
				 && (frePprSrtO1.EnterpriseCode == frePprSrtO2.EnterpriseCode)
				 && (frePprSrtO1.FileHeaderGuid == frePprSrtO2.FileHeaderGuid)
				 && (frePprSrtO1.UpdEmployeeCode == frePprSrtO2.UpdEmployeeCode)
				 && (frePprSrtO1.UpdAssemblyId1 == frePprSrtO2.UpdAssemblyId1)
				 && (frePprSrtO1.UpdAssemblyId2 == frePprSrtO2.UpdAssemblyId2)
				 && (frePprSrtO1.LogicalDeleteCode == frePprSrtO2.LogicalDeleteCode)
				 && (frePprSrtO1.OutputFormFileName == frePprSrtO2.OutputFormFileName)
				 && (frePprSrtO1.UserPrtPprIdDerivNo == frePprSrtO2.UserPrtPprIdDerivNo)
				 && (frePprSrtO1.SortingOrderCode == frePprSrtO2.SortingOrderCode)
				 && (frePprSrtO1.SortingOrder == frePprSrtO2.SortingOrder)
				 && (frePprSrtO1.FreePrtPaperItemNm == frePprSrtO2.FreePrtPaperItemNm)
				 && (frePprSrtO1.DDName == frePprSrtO2.DDName)
				 && (frePprSrtO1.FileNm == frePprSrtO2.FileNm)
				 && (frePprSrtO1.SortingOrderDivCd == frePprSrtO2.SortingOrderDivCd)
				 && (frePprSrtO1.EnterpriseName == frePprSrtO2.EnterpriseName)
				 && (frePprSrtO1.UpdEmployeeName == frePprSrtO2.UpdEmployeeName));
		}
		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePprSrtO�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtO�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(FrePprSrtO target)
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
			if (this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
			if (this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (this.SortingOrderCode != target.SortingOrderCode) resList.Add("SortingOrderCode");
			if (this.SortingOrder != target.SortingOrder) resList.Add("SortingOrder");
			if (this.FreePrtPaperItemNm != target.FreePrtPaperItemNm) resList.Add("FreePrtPaperItemNm");
			if (this.DDName != target.DDName) resList.Add("DDName");
			if (this.FileNm != target.FileNm) resList.Add("FileNm");
			if (this.SortingOrderDivCd != target.SortingOrderDivCd) resList.Add("SortingOrderDivCd");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ���R���[�\�[�g���ʃ}�X�^��r����
		/// </summary>
		/// <param name="frePprSrtO1">��r����FrePprSrtO�N���X�̃C���X�^���X</param>
		/// <param name="frePprSrtO2">��r����FrePprSrtO�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtO�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(FrePprSrtO frePprSrtO1, FrePprSrtO frePprSrtO2)
		{
			ArrayList resList = new ArrayList();
			if (frePprSrtO1.CreateDateTime != frePprSrtO2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePprSrtO1.UpdateDateTime != frePprSrtO2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePprSrtO1.EnterpriseCode != frePprSrtO2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePprSrtO1.FileHeaderGuid != frePprSrtO2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePprSrtO1.UpdEmployeeCode != frePprSrtO2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePprSrtO1.UpdAssemblyId1 != frePprSrtO2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePprSrtO1.UpdAssemblyId2 != frePprSrtO2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePprSrtO1.LogicalDeleteCode != frePprSrtO2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePprSrtO1.OutputFormFileName != frePprSrtO2.OutputFormFileName) resList.Add("OutputFormFileName");
			if (frePprSrtO1.UserPrtPprIdDerivNo != frePprSrtO2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (frePprSrtO1.SortingOrderCode != frePprSrtO2.SortingOrderCode) resList.Add("SortingOrderCode");
			if (frePprSrtO1.SortingOrder != frePprSrtO2.SortingOrder) resList.Add("SortingOrder");
			if (frePprSrtO1.FreePrtPaperItemNm != frePprSrtO2.FreePrtPaperItemNm) resList.Add("FreePrtPaperItemNm");
			if (frePprSrtO1.DDName != frePprSrtO2.DDName) resList.Add("DDName");
			if (frePprSrtO1.FileNm != frePprSrtO2.FileNm) resList.Add("FileNm");
			if (frePprSrtO1.SortingOrderDivCd != frePprSrtO2.SortingOrderDivCd) resList.Add("SortingOrderDivCd");
			if (frePprSrtO1.EnterpriseName != frePprSrtO2.EnterpriseName) resList.Add("EnterpriseName");
			if (frePprSrtO1.UpdEmployeeName != frePprSrtO2.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MoneyKind
	/// <summary>
	///                      ���z��ʃ}�X�^�i���[�U�[�o�^�j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���z��ʃ}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Programmer       :   30415 �ēc �ύK</br>
    /// <br>Date             :   2008/06/12</br>
    /// </remarks>
	public class MoneyKind
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

		/// <summary>���z�ݒ�敪</summary>
		/// <remarks>0:����,1:�T�[�r�X,2:���|</remarks>
		private Int32 _priceStCode;

		/// <summary>����R�[�h</summary>
		/// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
		private Int32 _moneyKindCode;

		/// <summary>���햼��</summary>
		private string _moneyKindName = "";

		/// <summary>����敪</summary>
		private Int32 _moneyKindDiv;

        /* --- DEL 2008/06/12 -------------------------------->>>>>
		/// <summary>���W�Ǘ��敪</summary>
		/// <remarks>0:���W�Ǘ����Ȃ�, 1:���W�Ǘ�����</remarks>
		private Int32 _regiMgCd;
           --- DEL 2008/06/12 --------------------------------<<<<< */
        
        /// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>����敪����</summary>
		private string _moneyKindDivName = "";


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

		/// public propaty name  :  PriceStCode
		/// <summary>���z�ݒ�敪�v���p�e�B</summary>
		/// <value>0:����,1:�T�[�r�X,2:���|</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���z�ݒ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceStCode
		{
			get{return _priceStCode;}
			set{_priceStCode = value;}
		}

		/// public propaty name  :  MoneyKindCode
		/// <summary>����R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MoneyKindCode
		{
			get{return _moneyKindCode;}
			set{_moneyKindCode = value;}
		}

		/// public propaty name  :  MoneyKindName
		/// <summary>���햼�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���햼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MoneyKindName
		{
			get{return _moneyKindName;}
			set{_moneyKindName = value;}
		}

		/// public propaty name  :  MoneyKindDiv
		/// <summary>����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MoneyKindDiv
		{
			get{return _moneyKindDiv;}
			set{_moneyKindDiv = value;}
		}

        /* --- DEL 2008/06/12 -------------------------------->>>>>
		/// public propaty name  :  RegiMgCd
		/// <summary>���W�Ǘ��敪�v���p�e�B</summary>
		/// <value>0:���W�Ǘ����Ȃ�, 1:���W�Ǘ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���W�Ǘ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RegiMgCd
		{
			get{return _regiMgCd;}
			set{_regiMgCd = value;}
		}
           --- DEL 2008/06/12 --------------------------------<<<<< */

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

		/// public propaty name  :  MoneyKindDivName
		/// <summary>����敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MoneyKindDivName
		{
			get{return _moneyKindDivName;}
			set{_moneyKindDivName = value;}
		}


		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
		/// </summary>
		/// <returns>MoneyKind�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MoneyKind�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MoneyKind()
		{
		}

		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="priceStCode">���z�ݒ�敪(0:����,1:�T�[�r�X,2:���|)</param>
		/// <param name="moneyKindCode">����R�[�h(1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����)</param>
		/// <param name="moneyKindName">���햼��</param>
		/// <param name="moneyKindDiv">����敪</param>
		/// <param name="regiMgCd">���W�Ǘ��敪(0:���W�Ǘ����Ȃ�, 1:���W�Ǘ�����)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="moneyKindDivName">����敪����</param>
		/// <returns>MoneyKind�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MoneyKind�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		//public MoneyKind(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 priceStCode,Int32 moneyKindCode,string moneyKindName,Int32 moneyKindDiv,Int32 regiMgCd,string enterpriseName,string updEmployeeName,string moneyKindDivName)
		public MoneyKind(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 priceStCode,Int32 moneyKindCode,string moneyKindName,Int32 moneyKindDiv,string enterpriseName,string updEmployeeName,string moneyKindDivName)
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._priceStCode = priceStCode;
			this._moneyKindCode = moneyKindCode;
			this._moneyKindName = moneyKindName;
			this._moneyKindDiv = moneyKindDiv;
			//this._regiMgCd = regiMgCd;  // DEL 2008/06/12
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._moneyKindDivName = moneyKindDivName;

		}

		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j��������
		/// </summary>
		/// <returns>MoneyKind�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MoneyKind�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MoneyKind Clone()
		{
			//return new MoneyKind(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._priceStCode,this._moneyKindCode,this._moneyKindName,this._moneyKindDiv,this._regiMgCd,this._enterpriseName,this._updEmployeeName,this._moneyKindDivName);  // DEL 2008/06/12
            return new MoneyKind(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._priceStCode, this._moneyKindCode, this._moneyKindName, this._moneyKindDiv, this._enterpriseName, this._updEmployeeName, this._moneyKindDivName);  // ADD 2008/06/12
        }

		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MoneyKind�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MoneyKind�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(MoneyKind target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.PriceStCode == target.PriceStCode)
				 && (this.MoneyKindCode == target.MoneyKindCode)
				 && (this.MoneyKindName == target.MoneyKindName)
				 && (this.MoneyKindDiv == target.MoneyKindDiv)
				 //&& (this.RegiMgCd == target.RegiMgCd)  // DEL 2008/06/12
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.MoneyKindDivName == target.MoneyKindDivName));
		}

		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j��r����
		/// </summary>
		/// <param name="moneyKindU1">
		///                    ��r����MoneyKind�N���X�̃C���X�^���X
		/// </param>
		/// <param name="moneyKindU2">��r����MoneyKind�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MoneyKind�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(MoneyKind moneyKindU1, MoneyKind moneyKindU2)
		{
			return ((moneyKindU1.CreateDateTime == moneyKindU2.CreateDateTime)
				 && (moneyKindU1.UpdateDateTime == moneyKindU2.UpdateDateTime)
				 && (moneyKindU1.EnterpriseCode == moneyKindU2.EnterpriseCode)
				 && (moneyKindU1.FileHeaderGuid == moneyKindU2.FileHeaderGuid)
				 && (moneyKindU1.UpdEmployeeCode == moneyKindU2.UpdEmployeeCode)
				 && (moneyKindU1.UpdAssemblyId1 == moneyKindU2.UpdAssemblyId1)
				 && (moneyKindU1.UpdAssemblyId2 == moneyKindU2.UpdAssemblyId2)
				 && (moneyKindU1.LogicalDeleteCode == moneyKindU2.LogicalDeleteCode)
				 && (moneyKindU1.PriceStCode == moneyKindU2.PriceStCode)
				 && (moneyKindU1.MoneyKindCode == moneyKindU2.MoneyKindCode)
				 && (moneyKindU1.MoneyKindName == moneyKindU2.MoneyKindName)
				 && (moneyKindU1.MoneyKindDiv == moneyKindU2.MoneyKindDiv)
				 //&& (moneyKindU1.RegiMgCd == moneyKindU2.RegiMgCd)  // DEL 2008/06/12
				 && (moneyKindU1.EnterpriseName == moneyKindU2.EnterpriseName)
				 && (moneyKindU1.UpdEmployeeName == moneyKindU2.UpdEmployeeName)
				 && (moneyKindU1.MoneyKindDivName == moneyKindU2.MoneyKindDivName));
		}
		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MoneyKind�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MoneyKind�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(MoneyKind target)
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
			if(this.PriceStCode != target.PriceStCode)resList.Add("PriceStCode");
			if(this.MoneyKindCode != target.MoneyKindCode)resList.Add("MoneyKindCode");
			if(this.MoneyKindName != target.MoneyKindName)resList.Add("MoneyKindName");
			if(this.MoneyKindDiv != target.MoneyKindDiv)resList.Add("MoneyKindDiv");
			//if(this.RegiMgCd != target.RegiMgCd)resList.Add("RegiMgCd");  // DEL 2008/06/12
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.MoneyKindDivName != target.MoneyKindDivName)resList.Add("MoneyKindDivName");

			return resList;
		}

		/// <summary>
		/// ���z��ʃ}�X�^�i���[�U�[�o�^�j��r����
		/// </summary>
		/// <param name="moneyKindU1">��r����MoneyKind�N���X�̃C���X�^���X</param>
		/// <param name="moneyKindU2">��r����MoneyKind�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MoneyKind�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(MoneyKind moneyKindU1, MoneyKind moneyKindU2)
		{
			ArrayList resList = new ArrayList();
			if(moneyKindU1.CreateDateTime != moneyKindU2.CreateDateTime)resList.Add("CreateDateTime");
			if(moneyKindU1.UpdateDateTime != moneyKindU2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(moneyKindU1.EnterpriseCode != moneyKindU2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(moneyKindU1.FileHeaderGuid != moneyKindU2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(moneyKindU1.UpdEmployeeCode != moneyKindU2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(moneyKindU1.UpdAssemblyId1 != moneyKindU2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(moneyKindU1.UpdAssemblyId2 != moneyKindU2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(moneyKindU1.LogicalDeleteCode != moneyKindU2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(moneyKindU1.PriceStCode != moneyKindU2.PriceStCode)resList.Add("PriceStCode");
			if(moneyKindU1.MoneyKindCode != moneyKindU2.MoneyKindCode)resList.Add("MoneyKindCode");
			if(moneyKindU1.MoneyKindName != moneyKindU2.MoneyKindName)resList.Add("MoneyKindName");
			if(moneyKindU1.MoneyKindDiv != moneyKindU2.MoneyKindDiv)resList.Add("MoneyKindDiv");
			//if(moneyKindU1.RegiMgCd != moneyKindU2.RegiMgCd)resList.Add("RegiMgCd");  // DEL 2008/06/12
			if(moneyKindU1.EnterpriseName != moneyKindU2.EnterpriseName)resList.Add("EnterpriseName");
			if(moneyKindU1.UpdEmployeeName != moneyKindU2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(moneyKindU1.MoneyKindDivName != moneyKindU2.MoneyKindDivName)resList.Add("MoneyKindDivName");

			return resList;
		}
	}
}

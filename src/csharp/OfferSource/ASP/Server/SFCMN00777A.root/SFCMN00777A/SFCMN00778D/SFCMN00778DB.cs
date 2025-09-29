using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ChangGidncWork
	/// <summary>
	///                      �ύX�ē����[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �ύX�ē����[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/11/12</br>
	/// <br>Genarated Date   :   2007/12/06  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
//	[Serializable]
//	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ChangGidncWork //: IFileHeader
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�z�M�ē� �ē����e�敪</summary>
		/// <remarks>0:����,1:��۸��єz�M,2:���ް����ݽ</remarks>
		private Int32 _mcastGidncCntntsCd;

		/// <summary>�p�b�P�[�W�敪</summary>
		private string _productCode = "";

		/// <summary>�z�M�ē� �o�[�W�����敪</summary>
		private string _mcastGidncVersionCd = "";

		/// <summary>�z�M�񋟋敪</summary>
		/// <remarks>0:�W��,1:��</remarks>
		private Int32 _mcastOfferDivCd;

		/// <summary>�X�V�O���[�v�R�[�h</summary>
		private string _updateGroupCode = "";

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�A��</summary>
		/// <remarks>�ē��敪�A�p�b�P�[�W�敪�A�o�[�W�����敪���ɂ��1�`�A�ԍ̔�</remarks>
		private Int32 _multicastConsNo;

		/// <summary>�z�M��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _multicastDate;

		/// <summary>�T�|�[�g���J����</summary>
		/// <remarks>YYYYMMDDHHmm(������t�{����)</remarks>
		private Int64 _supportOpenTime;

		/// <summary>���[�U�[���J����</summary>
		/// <remarks>YYYYMMDDHHmm(������t�{����)</remarks>
		private Int64 _customerOpenTime;

		/// <summary>�����e�i���X�\������@�J�n</summary>
		/// <remarks>YYYYMMDDHHmm(������t�{����)</remarks>
		private Int64 _serverMainteStScdl;

		/// <summary>�����e�i���X�\������@�I��</summary>
		/// <remarks>YYYYMMDDHHmm(������t�{����)</remarks>
		private Int64 _serverMainteEdScdl;

		/// <summary>�����e�i���X�����@�J�n</summary>
		/// <remarks>YYYYMMDDHHmm(������t�{����)</remarks>
		private Int64 _serverMainteStTime;

		/// <summary>�����e�i���X�����@�I��</summary>
		/// <remarks>YYYYMMDDHHmm(������t�{����)</remarks>
		private Int64 _serverMainteEdTime;

		/// <summary>�z�M�ē� �V�K�E���ǋ敪</summary>
		/// <remarks>1:�V�K,2:����,3:��Q</remarks>
		private Int32 _mcastGidncNewCustmCd;

		/// <summary>�z�M�ē� �����e�敪</summary>
		/// <remarks>1:������,2:�ް����,9:�ً}���</remarks>
		private Int32 _mcastGidncMainteCd;

		/// <summary>�V�X�e���敪</summary>
		/// <remarks>0:����,1:SF,2:BK,3:SH</remarks>
		private Int32 _systemDivCd;

		/// <summary>�ē���1</summary>
		private string _guidance1 = "";

		/// <summary>�n��</summary>
		private string _area = "";


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

		/// public propaty name  :  McastGidncCntntsCd
		/// <summary>�z�M�ē� �ē����e�敪�v���p�e�B</summary>
		/// <value>0:����,1:��۸��єz�M,2:���ް����ݽ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �z�M�ē� �ē����e�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 McastGidncCntntsCd
		{
			get{return _mcastGidncCntntsCd;}
			set{_mcastGidncCntntsCd = value;}
		}

		/// public propaty name  :  ProductCode
		/// <summary>�p�b�P�[�W�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �p�b�P�[�W�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ProductCode
		{
			get{return _productCode;}
			set{_productCode = value;}
		}

		/// public propaty name  :  McastGidncVersionCd
		/// <summary>�z�M�ē� �o�[�W�����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �z�M�ē� �o�[�W�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string McastGidncVersionCd
		{
			get{return _mcastGidncVersionCd;}
			set{_mcastGidncVersionCd = value;}
		}

		/// public propaty name  :  McastOfferDivCd
		/// <summary>�z�M�񋟋敪�v���p�e�B</summary>
		/// <value>0:�W��,1:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �z�M�񋟋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 McastOfferDivCd
		{
			get{return _mcastOfferDivCd;}
			set{_mcastOfferDivCd = value;}
		}

		/// public propaty name  :  UpdateGroupCode
		/// <summary>�X�V�O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateGroupCode
		{
			get{return _updateGroupCode;}
			set{_updateGroupCode = value;}
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

		/// public propaty name  :  MulticastConsNo
		/// <summary>�A�ԃv���p�e�B</summary>
		/// <value>�ē��敪�A�p�b�P�[�W�敪�A�o�[�W�����敪���ɂ��1�`�A�ԍ̔�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MulticastConsNo
		{
			get{return _multicastConsNo;}
			set{_multicastConsNo = value;}
		}

		/// public propaty name  :  MulticastDate
		/// <summary>�z�M���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �z�M���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime MulticastDate
		{
			get{return _multicastDate;}
			set{_multicastDate = value;}
		}

		/// public propaty name  :  SupportOpenTime
		/// <summary>�T�|�[�g���J�����v���p�e�B</summary>
		/// <value>YYYYMMDDHHmm(������t�{����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �T�|�[�g���J�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SupportOpenTime
		{
			get{return _supportOpenTime;}
			set{_supportOpenTime = value;}
		}

		/// public propaty name  :  CustomerOpenTime
		/// <summary>���[�U�[���J�����v���p�e�B</summary>
		/// <value>YYYYMMDDHHmm(������t�{����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[���J�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 CustomerOpenTime
		{
			get{return _customerOpenTime;}
			set{_customerOpenTime = value;}
		}

		/// public propaty name  :  ServerMainteStScdl
		/// <summary>�����e�i���X�\������@�J�n�v���p�e�B</summary>
		/// <value>YYYYMMDDHHmm(������t�{����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����e�i���X�\������@�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ServerMainteStScdl
		{
			get{return _serverMainteStScdl;}
			set{_serverMainteStScdl = value;}
		}

		/// public propaty name  :  ServerMainteEdScdl
		/// <summary>�����e�i���X�\������@�I���v���p�e�B</summary>
		/// <value>YYYYMMDDHHmm(������t�{����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����e�i���X�\������@�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ServerMainteEdScdl
		{
			get{return _serverMainteEdScdl;}
			set{_serverMainteEdScdl = value;}
		}

		/// public propaty name  :  ServerMainteStTime
		/// <summary>�����e�i���X�����@�J�n�v���p�e�B</summary>
		/// <value>YYYYMMDDHHmm(������t�{����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����e�i���X�����@�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ServerMainteStTime
		{
			get{return _serverMainteStTime;}
			set{_serverMainteStTime = value;}
		}

		/// public propaty name  :  ServerMainteEdTime
		/// <summary>�����e�i���X�����@�I���v���p�e�B</summary>
		/// <value>YYYYMMDDHHmm(������t�{����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����e�i���X�����@�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ServerMainteEdTime
		{
			get{return _serverMainteEdTime;}
			set{_serverMainteEdTime = value;}
		}

		/// public propaty name  :  McastGidncNewCustmCd
		/// <summary>�z�M�ē� �V�K�E���ǋ敪�v���p�e�B</summary>
		/// <value>1:�V�K,2:����,3:��Q</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �z�M�ē� �V�K�E���ǋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 McastGidncNewCustmCd
		{
			get{return _mcastGidncNewCustmCd;}
			set{_mcastGidncNewCustmCd = value;}
		}

		/// public propaty name  :  McastGidncMainteCd
		/// <summary>�z�M�ē� �����e�敪�v���p�e�B</summary>
		/// <value>1:������,2:�ް����,9:�ً}���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �z�M�ē� �����e�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 McastGidncMainteCd
		{
			get{return _mcastGidncMainteCd;}
			set{_mcastGidncMainteCd = value;}
		}

		/// public propaty name  :  SystemDivCd
		/// <summary>�V�X�e���敪�v���p�e�B</summary>
		/// <value>0:����,1:SF,2:BK,3:SH</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�X�e���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
		}

		/// public propaty name  :  Guidance1
		/// <summary>�ē���1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ē���1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Guidance1
		{
			get{return _guidance1;}
			set{_guidance1 = value;}
		}

		/// public propaty name  :  Area
		/// <summary>�n��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Area
		{
			get{return _area;}
			set{_area = value;}
		}



        /// public propaty name  :  McastGidncVersionCdZeroSup
        /// <summary>�z�M�ē� �o�[�W�����敪(�[���T�v���X)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �z�M�ē� �o�[�W�����敪(�[���T�v���X)�v���p�e�B</br>
        /// </remarks>
        public string McastGidncVersionCdZeroSup
        {
            get { return VersionStringConverter.ConvertToZeroSuppress( _mcastGidncVersionCd ); }
            set { _mcastGidncVersionCd = VersionStringConverter.ConvertToZeroPadding( value, 5 ); }
        }



		/// <summary>
		/// �ύX�ē����[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ChangGidncWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChangGidncWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ChangGidncWork()
		{
		}






		/// <summary>
		/// �ύX�ē����[�N�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="mcastGidncCntntsCd">�z�M�ē� �ē����e�敪(0:����,1:��۸��єz�M,2:���ް����ݽ)</param>
		/// <param name="productCode">�p�b�P�[�W�敪</param>
		/// <param name="mcastGidncVersionCd">�z�M�ē� �o�[�W�����敪</param>
		/// <param name="mcastOfferDivCd">�z�M�񋟋敪(0:�W��,1:��)</param>
		/// <param name="updateGroupCode">�X�V�O���[�v�R�[�h</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="multicastConsNo">�A��(�ē��敪�A�p�b�P�[�W�敪�A�o�[�W�����敪���ɂ��1�`�A�ԍ̔�)</param>
		/// <param name="multicastDate">�z�M��(YYYYMMDD)</param>
		/// <param name="supportOpenTime">�T�|�[�g���J����(YYYYMMDDHHmm(������t�{����))</param>
		/// <param name="customerOpenTime">���[�U�[���J����(YYYYMMDDHHmm(������t�{����))</param>
		/// <param name="serverMainteStScdl">�����e�i���X�\������@�J�n(YYYYMMDDHHmm(������t�{����))</param>
		/// <param name="serverMainteEdScdl">�����e�i���X�\������@�I��(YYYYMMDDHHmm(������t�{����))</param>
		/// <param name="serverMainteStTime">�����e�i���X�����@�J�n(YYYYMMDDHHmm(������t�{����))</param>
		/// <param name="serverMainteEdTime">�����e�i���X�����@�I��(YYYYMMDDHHmm(������t�{����))</param>
		/// <param name="mcastGidncNewCustmCd">�z�M�ē� �V�K�E���ǋ敪(1:�V�K,2:����,3:��Q)</param>
		/// <param name="mcastGidncMainteCd">�z�M�ē� �����e�敪(1:������,2:�ް����,9:�ً}���)</param>
		/// <param name="systemDivCd">�V�X�e���敪(0:����,1:SF,2:BK,3:SH)</param>
		/// <param name="guidance1">�ē���1</param>
		/// <param name="area">�n��</param>
        /// <returns>ChangGidncWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChangGidncWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public ChangGidncWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int32 mcastGidncCntntsCd, string productCode, string mcastGidncVersionCd, Int32 mcastOfferDivCd, string updateGroupCode, string enterpriseCode, Int32 multicastConsNo, DateTime multicastDate, Int64 supportOpenTime, Int64 customerOpenTime, Int64 serverMainteStScdl, Int64 serverMainteEdScdl, Int64 serverMainteStTime, Int64 serverMainteEdTime, Int32 mcastGidncNewCustmCd, Int32 mcastGidncMainteCd, Int32 systemDivCd, string guidance1, string area)
		{
			this.CreateDateTime = createDateTime; 
			this.UpdateDateTime = updateDateTime; 
			this.LogicalDeleteCode = logicalDeleteCode; 
			this.McastGidncCntntsCd = mcastGidncCntntsCd; 
			this.ProductCode = productCode; 
			this.McastGidncVersionCd = mcastGidncVersionCd; 
			this.McastOfferDivCd = mcastOfferDivCd; 
			this.UpdateGroupCode = updateGroupCode; 
			this.EnterpriseCode = enterpriseCode; 
			this.MulticastConsNo = multicastConsNo; 
			this.MulticastDate = multicastDate; 
			this.SupportOpenTime = supportOpenTime; 
			this.CustomerOpenTime = customerOpenTime; 
			this.ServerMainteStScdl = serverMainteStScdl; 
			this.ServerMainteEdScdl = serverMainteEdScdl; 
			this.ServerMainteStTime = serverMainteStTime; 
			this.ServerMainteEdTime = serverMainteEdTime; 
			this.McastGidncNewCustmCd = mcastGidncNewCustmCd; 
			this.McastGidncMainteCd = mcastGidncMainteCd; 
			this.SystemDivCd = systemDivCd; 
			this.Guidance1 = guidance1; 
			this.Area = area; 

		}

		/// <summary>
		/// �ύX�ē����[�N��������
		/// </summary>
		/// <returns>ChangGidncWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ChangGidncWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public ChangGidncWork Clone()
		{
			return new ChangGidncWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._mcastGidncCntntsCd, this._productCode, this._mcastGidncVersionCd, this._mcastOfferDivCd, this._updateGroupCode, this._enterpriseCode, this._multicastConsNo, this._multicastDate, this._supportOpenTime, this._customerOpenTime, this._serverMainteStScdl, this._serverMainteEdScdl, this._serverMainteStTime, this._serverMainteEdTime, this._mcastGidncNewCustmCd, this._mcastGidncMainteCd, this._systemDivCd, this._guidance1, this._area);
        }

		/// <summary>
		/// �ύX�ē����[�N��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ChangGidncWork�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChangGidncWork�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public bool Equals(ChangGidncWork target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
    			 && (this.UpdateDateTime == target.UpdateDateTime)
	    		 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
	    		 && (this.McastGidncCntntsCd == target.McastGidncCntntsCd)
	    		 && (this.ProductCode == target.ProductCode)
	    		 && (this.McastGidncVersionCd == target.McastGidncVersionCd)
	    		 && (this.McastOfferDivCd == target.McastOfferDivCd)
	    		 && (this.UpdateGroupCode == target.UpdateGroupCode)
	    		 && (this.EnterpriseCode == target.EnterpriseCode)
	    		 && (this.MulticastConsNo == target.MulticastConsNo)
	    		 && (this.MulticastDate == target.MulticastDate)
	    		 && (this.SupportOpenTime == target.SupportOpenTime)
	    		 && (this.CustomerOpenTime == target.CustomerOpenTime)
	    		 && (this.ServerMainteStScdl == target.ServerMainteStScdl)
	    		 && (this.ServerMainteEdScdl == target.ServerMainteEdScdl)
	    		 && (this.ServerMainteStTime == target.ServerMainteStTime)
	    		 && (this.ServerMainteEdTime == target.ServerMainteEdTime)
	    		 && (this.McastGidncNewCustmCd == target.McastGidncNewCustmCd)
	    		 && (this.McastGidncMainteCd == target.McastGidncMainteCd)
	    		 && (this.SystemDivCd == target.SystemDivCd)
	    		 && (this.Guidance1 == target.Guidance1)
	    		 && (this.Area == target.Area)); 
        
        }

		/// <summary>
		/// �ύX�ē����[�N��r����
		/// </summary>
		/// <param name="ChangGidnc1">��r����ChangGidncWork�N���X�̃C���X�^���X</param>
		/// <param name="ChangGidnc2">��r����ChangGidncWork�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChangGidncWork�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public static bool Equals(ChangGidncWork ChangGidnc1, ChangGidncWork ChangGidnc2)
		{
			return ((ChangGidnc1.CreateDateTime == ChangGidnc2.CreateDateTime)
    			 && (ChangGidnc1.UpdateDateTime == ChangGidnc2.UpdateDateTime)
	    		 && (ChangGidnc1.LogicalDeleteCode == ChangGidnc2.LogicalDeleteCode)
	    		 && (ChangGidnc1.McastGidncCntntsCd == ChangGidnc2.McastGidncCntntsCd)
	    		 && (ChangGidnc1.ProductCode == ChangGidnc2.ProductCode)
	    		 && (ChangGidnc1.McastGidncVersionCd == ChangGidnc2.McastGidncVersionCd)
	    		 && (ChangGidnc1.McastOfferDivCd == ChangGidnc2.McastOfferDivCd)
	    		 && (ChangGidnc1.UpdateGroupCode == ChangGidnc2.UpdateGroupCode)
	    		 && (ChangGidnc1.EnterpriseCode == ChangGidnc2.EnterpriseCode)
	    		 && (ChangGidnc1.MulticastConsNo == ChangGidnc2.MulticastConsNo)
	    		 && (ChangGidnc1.MulticastDate == ChangGidnc2.MulticastDate)
	    		 && (ChangGidnc1.SupportOpenTime == ChangGidnc2.SupportOpenTime)
	    		 && (ChangGidnc1.CustomerOpenTime == ChangGidnc2.CustomerOpenTime)
	    		 && (ChangGidnc1.ServerMainteStScdl == ChangGidnc2.ServerMainteStScdl)
	    		 && (ChangGidnc1.ServerMainteEdScdl == ChangGidnc2.ServerMainteEdScdl)
	    		 && (ChangGidnc1.ServerMainteStTime == ChangGidnc2.ServerMainteStTime)
	    		 && (ChangGidnc1.ServerMainteEdTime == ChangGidnc2.ServerMainteEdTime)
	    		 && (ChangGidnc1.McastGidncNewCustmCd == ChangGidnc2.McastGidncNewCustmCd)
	    		 && (ChangGidnc1.McastGidncMainteCd == ChangGidnc2.McastGidncMainteCd)
	    		 && (ChangGidnc1.SystemDivCd == ChangGidnc2.SystemDivCd)
	    		 && (ChangGidnc1.Guidance1 == ChangGidnc2.Guidance1)
	    		 && (ChangGidnc1.Area == ChangGidnc2.Area)); 

		}

        /// <summary>
		/// �ύX�ē����[�N��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ChangGidncWork�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChangGidncWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ChangGidncWork target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
    		if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
	    	if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
	    	if(this.McastGidncCntntsCd != target.McastGidncCntntsCd)resList.Add("McastGidncCntntsCd");
	    	if(this.ProductCode != target.ProductCode)resList.Add("ProductCode");
	    	if(this.McastGidncVersionCd != target.McastGidncVersionCd)resList.Add("McastGidncVersionCd");
	    	if(this.McastOfferDivCd != target.McastOfferDivCd)resList.Add("McastOfferDivCd");
	    	if(this.UpdateGroupCode != target.UpdateGroupCode)resList.Add("UpdateGroupCode");
	    	if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
	    	if(this.MulticastConsNo != target.MulticastConsNo)resList.Add("MulticastConsNo");
	    	if(this.MulticastDate != target.MulticastDate)resList.Add("MulticastDate");
	    	if(this.SupportOpenTime != target.SupportOpenTime)resList.Add("SupportOpenTime");
	    	if(this.CustomerOpenTime != target.CustomerOpenTime)resList.Add("CustomerOpenTime");
	    	if(this.ServerMainteStScdl != target.ServerMainteStScdl)resList.Add("ServerMainteStScdl");
	    	if(this.ServerMainteEdScdl != target.ServerMainteEdScdl)resList.Add("ServerMainteEdScdl");
	    	if(this.ServerMainteStTime != target.ServerMainteStTime)resList.Add("ServerMainteStTime");
	    	if(this.ServerMainteEdTime != target.ServerMainteEdTime)resList.Add("ServerMainteEdTime");
	    	if(this.McastGidncNewCustmCd != target.McastGidncNewCustmCd)resList.Add("McastGidncNewCustmCd");
	    	if(this.McastGidncMainteCd != target.McastGidncMainteCd)resList.Add("McastGidncMainteCd");
	    	if(this.SystemDivCd != target.SystemDivCd)resList.Add("SystemDivCd");
	    	if(this.Guidance1 != target.Guidance1)resList.Add("Guidance1");
	    	if(this.Area != target.Area)resList.Add("Area");

			return resList;
		}

		/// <summary>
		/// �ύX�ē����[�N��r����
		/// </summary>
		/// <param name="changGidnc1">��r����ChangGidncWork�N���X�̃C���X�^���X</param>
		/// <param name="changGidnc2">��r����ChangGidncWork�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChangGidncWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ChangGidncWork ChangGidnc1, ChangGidncWork ChangGidnc2)
		{
			ArrayList resList = new ArrayList();
			if(ChangGidnc1.CreateDateTime != ChangGidnc2.CreateDateTime)resList.Add("CreateDateTime");
    		if(ChangGidnc1.UpdateDateTime != ChangGidnc2.UpdateDateTime)resList.Add("UpdateDateTime");
	    	if(ChangGidnc1.LogicalDeleteCode != ChangGidnc2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
	    	if(ChangGidnc1.McastGidncCntntsCd != ChangGidnc2.McastGidncCntntsCd)resList.Add("McastGidncCntntsCd");
	    	if(ChangGidnc1.ProductCode != ChangGidnc2.ProductCode)resList.Add("ProductCode");
	    	if(ChangGidnc1.McastGidncVersionCd != ChangGidnc2.McastGidncVersionCd)resList.Add("McastGidncVersionCd");
	    	if(ChangGidnc1.McastOfferDivCd != ChangGidnc2.McastOfferDivCd)resList.Add("McastOfferDivCd");
	    	if(ChangGidnc1.UpdateGroupCode != ChangGidnc2.UpdateGroupCode)resList.Add("UpdateGroupCode");
	    	if(ChangGidnc1.EnterpriseCode != ChangGidnc2.EnterpriseCode)resList.Add("EnterpriseCode");
	    	if(ChangGidnc1.MulticastConsNo != ChangGidnc2.MulticastConsNo)resList.Add("MulticastConsNo");
	    	if(ChangGidnc1.MulticastDate != ChangGidnc2.MulticastDate)resList.Add("MulticastDate");
	    	if(ChangGidnc1.SupportOpenTime != ChangGidnc2.SupportOpenTime)resList.Add("SupportOpenTime");
	    	if(ChangGidnc1.CustomerOpenTime != ChangGidnc2.CustomerOpenTime)resList.Add("CustomerOpenTime");
	    	if(ChangGidnc1.ServerMainteStScdl != ChangGidnc2.ServerMainteStScdl)resList.Add("ServerMainteStScdl");
	    	if(ChangGidnc1.ServerMainteEdScdl != ChangGidnc2.ServerMainteEdScdl)resList.Add("ServerMainteEdScdl");
	    	if(ChangGidnc1.ServerMainteStTime != ChangGidnc2.ServerMainteStTime)resList.Add("ServerMainteStTime");
	    	if(ChangGidnc1.ServerMainteEdTime != ChangGidnc2.ServerMainteEdTime)resList.Add("ServerMainteEdTime");
	    	if(ChangGidnc1.McastGidncNewCustmCd != ChangGidnc2.McastGidncNewCustmCd)resList.Add("McastGidncNewCustmCd");
	    	if(ChangGidnc1.McastGidncMainteCd != ChangGidnc2.McastGidncMainteCd)resList.Add("McastGidncMainteCd");
	    	if(ChangGidnc1.SystemDivCd != ChangGidnc2.SystemDivCd)resList.Add("SystemDivCd");
	    	if(ChangGidnc1.Guidance1 != ChangGidnc2.Guidance1)resList.Add("Guidance1");
	    	if(ChangGidnc1.Area != ChangGidnc2.Area)resList.Add("Area");

			return resList;
		}

    
    }

}

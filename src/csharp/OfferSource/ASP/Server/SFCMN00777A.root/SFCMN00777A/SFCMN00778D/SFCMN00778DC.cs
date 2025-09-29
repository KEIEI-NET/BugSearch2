using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ChgGidncDtWork
	/// <summary>
	///                      �ύX�ē����׃��[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �ύX�ē����׃��[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/11/12</br>
	/// <br>Genarated Date   :   2007/12/06  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
//	[Serializable]
//	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ChgGidncDtWork //: IFileHeader
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
		/// <remarks>�ē��敪�A�߯���ދ敪�A�ް�ޮ݋敪���ɂ��1�`�A�ԍ̔�</remarks>
		private Int32 _multicastConsNo;

		/// <summary>�A�ԃT�u�R�[�h</summary>
		/// <remarks>�ē��敪�A�߯���ދ敪�A�ް�ޮ݋敪�A�A�Ԗ��ɂ��1�`�A�ԍ̔�</remarks>
		private Int32 _multicastSubCode;

		/// <summary>�ύX���e</summary>
		/// <remarks>���P</remarks>
		private string _changeContents;

		/// <summary>�ʎ��t�@�C���L���敪</summary>
		/// <remarks>0:����,1:�L��</remarks>
		private Int32 _anothersheetFileExst;

		/// <summary>�ʎ��t�@�C����</summary>
		private string _anothersheetFileName = "";


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
		/// <value>�ē��敪�A�߯���ދ敪�A�ް�ޮ݋敪���ɂ��1�`�A�ԍ̔�</value>
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

		/// public propaty name  :  MulticastSubCode
		/// <summary>�A�ԃT�u�R�[�h�v���p�e�B</summary>
		/// <value>�ē��敪�A�߯���ދ敪�A�ް�ޮ݋敪�A�A�Ԗ��ɂ��1�`�A�ԍ̔�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�ԃT�u�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MulticastSubCode
		{
			get{return _multicastSubCode;}
			set{_multicastSubCode = value;}
		}

		/// public propaty name  :  ChangeContents
		/// <summary>�ύX���e�v���p�e�B</summary>
		/// <value>���P</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX���e�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ChangeContents
		{
			get{return _changeContents;}
			set{_changeContents = value;}
		}

		/// public propaty name  :  AnothersheetFileExst
		/// <summary>�ʎ��t�@�C���L���敪�v���p�e�B</summary>
		/// <value>0:����,1:�L��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʎ��t�@�C���L���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnothersheetFileExst
		{
			get{return _anothersheetFileExst;}
			set{_anothersheetFileExst = value;}
		}

		/// public propaty name  :  AnothersheetFileName
		/// <summary>�ʎ��t�@�C�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʎ��t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnothersheetFileName
		{
			get{return _anothersheetFileName;}
			set{_anothersheetFileName = value;}
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
		/// �ύX�ē����׃��[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ChgGidncDtWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChgGidncDtWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ChgGidncDtWork()
		{
		}





		/// <summary>
		/// �ύX�ē����׃��[�N�R���X�g���N�^
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
		/// <param name="multicastConsNo">�A��(�ē��敪�A�߯���ދ敪�A�ް�ޮ݋敪���ɂ��1�`�A�ԍ̔�)</param>
		/// <param name="multicastSubCode">�A�ԃT�u�R�[�h(�ē��敪�A�߯���ދ敪�A�ް�ޮ݋敪�A�A�Ԗ��ɂ��1�`�A�ԍ̔�)</param>
		/// <param name="changeContents">�ύX���e(���P)</param>
		/// <param name="anothersheetFileExst">�ʎ��t�@�C���L���敪(0:����,1:�L��)</param>
		/// <param name="anothersheetFileName">�ʎ��t�@�C����</param>
        /// <returns>ChgGidncDtWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChgGidncDtWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public ChgGidncDtWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int32 mcastGidncCntntsCd, string productCode, string mcastGidncVersionCd, Int32 mcastOfferDivCd, string updateGroupCode, string enterpriseCode, Int32 multicastConsNo, Int32 multicastSubCode, string changeContents, Int32 anothersheetFileExst, string anothersheetFileName)
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
			this.MulticastSubCode = multicastSubCode;
			this.ChangeContents = changeContents;
			this.AnothersheetFileExst = anothersheetFileExst;
			this.AnothersheetFileName = anothersheetFileName;

		}

		/// <summary>
		/// �ύX�ē����׃��[�N��������
		/// </summary>
		/// <returns>ChgGidncDtWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ChgGidncDtWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public ChgGidncDtWork Clone()
		{
    		return new ChgGidncDtWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._mcastGidncCntntsCd, this._productCode, this._mcastGidncVersionCd, this._mcastOfferDivCd, this._updateGroupCode, this._enterpriseCode, this._multicastConsNo, this._multicastSubCode, this._changeContents, this._anothersheetFileExst, this._anothersheetFileName);

        }

		/// <summary>
		/// �ύX�ē����׃��[�N��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ChgGidncDtWork�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChgGidncDtWork�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public bool Equals(ChgGidncDtWork target)
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
				 && (this.MulticastSubCode == target.MulticastSubCode)
				 && (this.ChangeContents == target.ChangeContents)
				 && (this.AnothersheetFileExst == target.AnothersheetFileExst)
				 && (this.AnothersheetFileName == target.AnothersheetFileName));

		}

		/// <summary>
		/// �ύX�ē����׃��[�N��r����
		/// </summary>
		/// <param name="chgGidncDt1">��r����ChgGidncDtWork�N���X�̃C���X�^���X</param>
		/// <param name="chgGidncDt2">��r����ChgGidncDtWork�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChgGidncDtWork�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public static bool Equals(ChgGidncDtWork chgGidncDt1, ChgGidncDtWork chgGidncDt2)
		{
			return ((chgGidncDt1.CreateDateTime == chgGidncDt2.CreateDateTime)
				 && (chgGidncDt1.UpdateDateTime == chgGidncDt2.UpdateDateTime)
				 && (chgGidncDt1.LogicalDeleteCode == chgGidncDt2.LogicalDeleteCode)
				 && (chgGidncDt1.McastGidncCntntsCd == chgGidncDt2.McastGidncCntntsCd)
				 && (chgGidncDt1.ProductCode == chgGidncDt2.ProductCode)
                 && (chgGidncDt1.McastGidncVersionCd == chgGidncDt2.McastGidncVersionCd)
				 && (chgGidncDt1.McastOfferDivCd == chgGidncDt2.McastOfferDivCd)
				 && (chgGidncDt1.UpdateGroupCode == chgGidncDt2.UpdateGroupCode)
				 && (chgGidncDt1.EnterpriseCode == chgGidncDt2.EnterpriseCode)
				 && (chgGidncDt1.MulticastConsNo == chgGidncDt2.MulticastConsNo)
				 && (chgGidncDt1.MulticastSubCode == chgGidncDt2.MulticastSubCode)
				 && (chgGidncDt1.ChangeContents == chgGidncDt2.ChangeContents)
				 && (chgGidncDt1.AnothersheetFileExst == chgGidncDt2.AnothersheetFileExst)
				 && (chgGidncDt1.AnothersheetFileName == chgGidncDt2.AnothersheetFileName));

		}
		/// <summary>
		/// �ύX�ē����׃��[�N��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ChgGidncDtWork�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChgGidncDtWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ChgGidncDtWork target)
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
			if(this.MulticastSubCode != target.MulticastSubCode)resList.Add("MulticastSubCode");
			if(this.ChangeContents != target.ChangeContents)resList.Add("ChangeContents");
			if(this.AnothersheetFileExst != target.AnothersheetFileExst)resList.Add("AnothersheetFileExst");
			if(this.AnothersheetFileName != target.AnothersheetFileName)resList.Add("AnothersheetFileName");

			return resList;
		}

		/// <summary>
		/// �ύX�ē����׃��[�N��r����
		/// </summary>
		/// <param name="chgGidncDt1">��r����ChgGidncDtWork�N���X�̃C���X�^���X</param>
		/// <param name="chgGidncDt2">��r����ChgGidncDtWork�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ChgGidncDtWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ChgGidncDtWork chgGidncDt1, ChgGidncDtWork chgGidncDt2)
		{
			ArrayList resList = new ArrayList();
			if(chgGidncDt1.CreateDateTime != chgGidncDt2.CreateDateTime)resList.Add("CreateDateTime");
			if(chgGidncDt1.UpdateDateTime != chgGidncDt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(chgGidncDt1.LogicalDeleteCode != chgGidncDt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(chgGidncDt1.McastGidncCntntsCd != chgGidncDt2.McastGidncCntntsCd)resList.Add("McastGidncCntntsCd");
			if(chgGidncDt1.ProductCode != chgGidncDt2.ProductCode)resList.Add("ProductCode");
            if(chgGidncDt1.McastGidncVersionCd != chgGidncDt2.McastGidncVersionCd)resList.Add("McastGidncVersionCd");
			if(chgGidncDt1.McastOfferDivCd != chgGidncDt2.McastOfferDivCd)resList.Add("McastOfferDivCd");
			if(chgGidncDt1.UpdateGroupCode != chgGidncDt2.UpdateGroupCode)resList.Add("UpdateGroupCode");
			if(chgGidncDt1.EnterpriseCode != chgGidncDt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(chgGidncDt1.MulticastConsNo != chgGidncDt2.MulticastConsNo)resList.Add("MulticastConsNo");
			if(chgGidncDt1.MulticastSubCode != chgGidncDt2.MulticastSubCode)resList.Add("MulticastSubCode");
			if(chgGidncDt1.ChangeContents != chgGidncDt2.ChangeContents)resList.Add("ChangeContents");
			if(chgGidncDt1.AnothersheetFileExst != chgGidncDt2.AnothersheetFileExst)resList.Add("AnothersheetFileExst");
			if(chgGidncDt1.AnothersheetFileName != chgGidncDt2.AnothersheetFileName)resList.Add("AnothersheetFileName");

			return resList;
		}

    
    }

}

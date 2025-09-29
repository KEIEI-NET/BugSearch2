using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Propose_Para_Maker
	/// <summary>
	///                      ��ď��i�N���p�����[�^�N���X�i���[�J�[�j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ��ď��i�N���p�����[�^�N���X�i���[�J�[�j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/05/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Propose_Para_Maker
	{
		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���[�J�[�J�i����</summary>
		private string _makerKanaName = "";

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>�񋟃f�[�^�敪</summary>
		/// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
		private Int32 _offerDataDiv;


		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerKanaName
		{
			get{return _makerKanaName;}
			set{_makerKanaName = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  OfferDataDiv
		/// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
		/// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDataDiv
		{
			get{return _offerDataDiv;}
			set{_offerDataDiv = value;}
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j�R���X�g���N�^
		/// </summary>
		/// <returns>Propose_Para_Maker�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Maker�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Maker()
		{
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j�R���X�g���N�^
		/// </summary>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="makerKanaName">���[�J�[�J�i����</param>
		/// <param name="displayOrder">�\������</param>
		/// <param name="offerDataDiv">�񋟃f�[�^�敪(0:���[�U�f�[�^,1:�񋟃f�[�^)</param>
		/// <param name="goodsMakerNm">���i���[�J�[����</param>
		/// <returns>Propose_Para_Maker�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Maker�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Maker(Int32 goodsMakerCd,string makerName,string makerKanaName,Int32 displayOrder,Int32 offerDataDiv)
		{
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._makerKanaName = makerKanaName;
			this._displayOrder = displayOrder;
			this._offerDataDiv = offerDataDiv;

		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j��������
		/// </summary>
		/// <returns>Propose_Para_Maker�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Propose_Para_Maker�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Maker Clone()
		{
			return new Propose_Para_Maker(this._goodsMakerCd,this._makerName,this._makerKanaName,this._displayOrder,this._offerDataDiv);
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Propose_Para_Maker�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Maker�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(Propose_Para_Maker target)
		{
            return ((this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.OfferDataDiv == target.OfferDataDiv));
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j��r����
		/// </summary>
		/// <param name="propose_Para_Maker1">
		///                    ��r����Propose_Para_Maker�N���X�̃C���X�^���X
		/// </param>
		/// <param name="propose_Para_Maker2">��r����Propose_Para_Maker�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Maker�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(Propose_Para_Maker propose_Para_Maker1, Propose_Para_Maker propose_Para_Maker2)
		{
            return ((propose_Para_Maker1.GoodsMakerCd == propose_Para_Maker2.GoodsMakerCd)
                 && (propose_Para_Maker1.MakerName == propose_Para_Maker2.MakerName)
                 && (propose_Para_Maker1.MakerKanaName == propose_Para_Maker2.MakerKanaName)
                 && (propose_Para_Maker1.DisplayOrder == propose_Para_Maker2.DisplayOrder)
                 && (propose_Para_Maker1.OfferDataDiv == propose_Para_Maker2.OfferDataDiv));
		}
		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Propose_Para_Maker�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Maker�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(Propose_Para_Maker target)
		{
			ArrayList resList = new ArrayList();
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.MakerKanaName != target.MakerKanaName)resList.Add("MakerKanaName");
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.OfferDataDiv != target.OfferDataDiv)resList.Add("OfferDataDiv");

			return resList;
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���[�J�[�j��r����
		/// </summary>
		/// <param name="propose_Para_Maker1">��r����Propose_Para_Maker�N���X�̃C���X�^���X</param>
		/// <param name="propose_Para_Maker2">��r����Propose_Para_Maker�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Maker�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(Propose_Para_Maker propose_Para_Maker1, Propose_Para_Maker propose_Para_Maker2)
		{
			ArrayList resList = new ArrayList();
			if(propose_Para_Maker1.GoodsMakerCd != propose_Para_Maker2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(propose_Para_Maker1.MakerName != propose_Para_Maker2.MakerName)resList.Add("MakerName");
			if(propose_Para_Maker1.MakerKanaName != propose_Para_Maker2.MakerKanaName)resList.Add("MakerKanaName");
			if(propose_Para_Maker1.DisplayOrder != propose_Para_Maker2.DisplayOrder)resList.Add("DisplayOrder");
			if(propose_Para_Maker1.OfferDataDiv != propose_Para_Maker2.OfferDataDiv)resList.Add("OfferDataDiv");

			return resList;
		}
	}
}

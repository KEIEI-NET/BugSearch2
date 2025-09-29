using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandDetail
	/// <summary>
	///                      ������(���׏����)���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������(���׏����)���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DemandDetail
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>���o�Ώیv���(�J�n)</summary>
		/// <remarks>"YYYYMMDD"  ������J�n�v����ƂȂ�N����</remarks>
		private Int32 _addUpADateSt;

		/// <summary>���o�Ώیv���(�I��)</summary>
		/// <remarks>"YYYYMMDD"  ������I���v����ƂȂ�N����</remarks>
		private Int32 _addUpADateEd;

		/// <summary>������R�[�h</summary>
		private Int32 _claimCode;

		/// <summary>�������ג��o�L��</summary>
		private bool _isExtractDepo;

		/// <summary>���גP��</summary>
		/// <remarks>0:�ڍגP�� 1:���גP�� 2:�`�[�P��</remarks>
		private Int32 _detailsUnit;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";


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

		/// public propaty name  :  AddUpSecCode
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpADateSt
		/// <summary>���o�Ώیv���(�J�n)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  ������J�n�v����ƂȂ�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώیv���(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddUpADateSt
		{
			get{return _addUpADateSt;}
			set{_addUpADateSt = value;}
		}

		/// public propaty name  :  AddUpADateEd
		/// <summary>���o�Ώیv���(�I��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  ������I���v����ƂȂ�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώیv���(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddUpADateEd
		{
			get{return _addUpADateEd;}
			set{_addUpADateEd = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  IsExtractDepo
		/// <summary>�������ג��o�L���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ג��o�L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsExtractDepo
		{
			get{return _isExtractDepo;}
			set{_isExtractDepo = value;}
		}

		/// public propaty name  :  DetailsUnit
		/// <summary>���גP�ʃv���p�e�B</summary>
		/// <value>0:�ڍגP�� 1:���גP�� 2:�`�[�P��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���גP�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DetailsUnit
		{
			get{return _detailsUnit;}
			set{_detailsUnit = value;}
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

		/// public propaty name  :  AddUpSecName
		/// <summary>�v�㋒�_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}


		/// <summary>
		/// ������(���׏����)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_DemandDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandDetail()
		{
		}

		/// <summary>
		/// ������(���׏����)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="addUpADateSt">���o�Ώیv���(�J�n)("YYYYMMDD"  ������J�n�v����ƂȂ�N����)</param>
		/// <param name="addUpADateEd">���o�Ώیv���(�I��)("YYYYMMDD"  ������I���v����ƂȂ�N����)</param>
		/// <param name="claimCode">������R�[�h</param>
		/// <param name="isExtractDepo">�������ג��o�L��</param>
		/// <param name="detailsUnit">���גP��(0:�ڍגP�� 1:�`�[�P��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="addUpSecName">�v�㋒�_����</param>
		/// <returns>ExtrInfo_DemandDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ExtrInfo_DemandDetail(string enterpriseCode, string addUpSecCode, Int32 addUpADateSt, Int32 addUpADateEd, Int32 claimCode, bool isExtractDepo, Int32 detailsUnit, string enterpriseName, string addUpSecName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCode = addUpSecCode;
			this._addUpADateSt = addUpADateSt;
			this._addUpADateEd = addUpADateEd;
			this._claimCode = claimCode;
			this._isExtractDepo = isExtractDepo;
			this._detailsUnit = detailsUnit;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// ������(���׏����)���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_DemandDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_DemandDetail�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandDetail Clone()
		{
			return new ExtrInfo_DemandDetail(this._enterpriseCode,this._addUpSecCode,this._addUpADateSt,this._addUpADateEd,this._claimCode,this._isExtractDepo,this._detailsUnit,this._enterpriseName,this._addUpSecName);
		}

		/// <summary>
		/// ������(���׏����)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DemandDetail�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetail�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandDetail target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.AddUpADateSt == target.AddUpADateSt)
				 && (this.AddUpADateEd == target.AddUpADateEd)
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.IsExtractDepo == target.IsExtractDepo)
				 && (this.DetailsUnit == target.DetailsUnit)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// ������(���׏����)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandDetail1">
		///                    ��r����ExtrInfo_DemandDetail�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_DemandDetail2">��r����ExtrInfo_DemandDetail�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetail�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandDetail extrInfo_DemandDetail1, ExtrInfo_DemandDetail extrInfo_DemandDetail2)
		{
			return ((extrInfo_DemandDetail1.EnterpriseCode == extrInfo_DemandDetail2.EnterpriseCode)
				 && (extrInfo_DemandDetail1.AddUpSecCode == extrInfo_DemandDetail2.AddUpSecCode)
				 && (extrInfo_DemandDetail1.AddUpADateSt == extrInfo_DemandDetail2.AddUpADateSt)
				 && (extrInfo_DemandDetail1.AddUpADateEd == extrInfo_DemandDetail2.AddUpADateEd)
				 && (extrInfo_DemandDetail1.ClaimCode == extrInfo_DemandDetail2.ClaimCode)
				 && (extrInfo_DemandDetail1.IsExtractDepo == extrInfo_DemandDetail2.IsExtractDepo)
				 && (extrInfo_DemandDetail1.DetailsUnit == extrInfo_DemandDetail2.DetailsUnit)
				 && (extrInfo_DemandDetail1.EnterpriseName == extrInfo_DemandDetail2.EnterpriseName)
				 && (extrInfo_DemandDetail1.AddUpSecName == extrInfo_DemandDetail2.AddUpSecName));
		}
		/// <summary>
		/// ������(���׏����)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DemandDetail�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetail�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandDetail target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.AddUpADateSt != target.AddUpADateSt)resList.Add("AddUpADateSt");
			if(this.AddUpADateEd != target.AddUpADateEd)resList.Add("AddUpADateEd");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.IsExtractDepo != target.IsExtractDepo)resList.Add("IsExtractDepo");
			if(this.DetailsUnit != target.DetailsUnit)resList.Add("DetailsUnit");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// ������(���׏����)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandDetail1">��r����ExtrInfo_DemandDetail�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DemandDetail2">��r����ExtrInfo_DemandDetail�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetail�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandDetail extrInfo_DemandDetail1, ExtrInfo_DemandDetail extrInfo_DemandDetail2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandDetail1.EnterpriseCode != extrInfo_DemandDetail2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandDetail1.AddUpSecCode != extrInfo_DemandDetail2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(extrInfo_DemandDetail1.AddUpADateSt != extrInfo_DemandDetail2.AddUpADateSt)resList.Add("AddUpADateSt");
			if(extrInfo_DemandDetail1.AddUpADateEd != extrInfo_DemandDetail2.AddUpADateEd)resList.Add("AddUpADateEd");
			if(extrInfo_DemandDetail1.ClaimCode != extrInfo_DemandDetail2.ClaimCode)resList.Add("ClaimCode");
			if(extrInfo_DemandDetail1.IsExtractDepo != extrInfo_DemandDetail2.IsExtractDepo)resList.Add("IsExtractDepo");
			if(extrInfo_DemandDetail1.DetailsUnit != extrInfo_DemandDetail2.DetailsUnit)resList.Add("DetailsUnit");
			if(extrInfo_DemandDetail1.EnterpriseName != extrInfo_DemandDetail2.EnterpriseName)resList.Add("EnterpriseName");
			if(extrInfo_DemandDetail1.AddUpSecName != extrInfo_DemandDetail2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}

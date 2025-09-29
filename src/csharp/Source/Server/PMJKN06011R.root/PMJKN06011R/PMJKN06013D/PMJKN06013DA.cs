using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FreeSearchPartsSParaWork
	/// <summary>
	///                      ���R�������i���o�������[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R�������i���o�������[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2010/04/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FreeSearchPartsSParaWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���R�������i�ŗL�ԍ�</summary>
		private string[] _freSrchPrtPropNos = new string[0];

		/// <summary>�a�k�R�[�h</summary>
		private Int32 _tbsPartsCode;

		/// <summary>�a�k�R�[�h�}��</summary>
		/// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
		private Int32 _tbsPartsCdDerivedNo;

		/// <summary>���i�J�n��</summary>
		/// <remarks>YYYYMMDD �w��l�ȑO�𒊏o</remarks>
		private DateTime _priceStartDate;

		/// <summary>���o����(���q)</summary>
		/// <remarks>���o����(���q)�̔z��</remarks>
        private FreeSearchPartsSMdlParaWork[] _fSPartsSModels = new FreeSearchPartsSMdlParaWork[0];

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

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

		/// public propaty name  :  FreSrchPrtPropNos
		/// <summary>���R�������i�ŗL�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R�������i�ŗL�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] FreSrchPrtPropNos
		{
			get{return _freSrchPrtPropNos;}
			set{_freSrchPrtPropNos = value;}
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>�a�k�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get{return _tbsPartsCode;}
			set{_tbsPartsCode = value;}
		}

		/// public propaty name  :  TbsPartsCdDerivedNo
		/// <summary>�a�k�R�[�h�}�ԃv���p�e�B</summary>
		/// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k�R�[�h�}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TbsPartsCdDerivedNo
		{
			get{return _tbsPartsCdDerivedNo;}
			set{_tbsPartsCdDerivedNo = value;}
		}

		/// public propaty name  :  PriceStartDate
		/// <summary>���i�J�n���v���p�e�B</summary>
		/// <value>YYYYMMDD �w��l�ȑO�𒊏o</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PriceStartDate
		{
			get{return _priceStartDate;}
			set{_priceStartDate = value;}
		}

		/// public propaty name  :  FSPartsSModels
		/// <summary>���o����(���q)�v���p�e�B</summary>
		/// <value>���o����(���q)�̔z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o����(���q)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FreeSearchPartsSMdlParaWork[] FSPartsSModels
		{
			get{return _fSPartsSModels;}
			set{_fSPartsSModels = value;}
		}

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

		/// <summary>
		/// ���R�������i���o�������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>FreeSearchPartsSParaWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FreeSearchPartsSParaWork()
		{
		}
	}
}

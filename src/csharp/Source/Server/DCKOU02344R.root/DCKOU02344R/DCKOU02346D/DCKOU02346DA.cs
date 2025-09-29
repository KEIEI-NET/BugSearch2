using System;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ArrivalListParamWork
	/// <summary>
	///                      ���׊m�F�\���o�����N���X���[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���׊m�F�\���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ArrivalListParamWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _supplierCdSt;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _supplierCdEd;

		/// <summary>�J�n�d���S���҃R�[�h</summary>
		private string _stockAgentCodeSt = "";

		/// <summary>�I���d���S���҃R�[�h</summary>
		private string _stockAgentCodeEd = "";

		/// <summary>�J�n�d���`�[�ԍ�</summary>
		private Int32 _supplierSlipNoSt;

		/// <summary>�I���d���`�[�ԍ�</summary>
		private Int32 _supplierSlipNoEd;

		/// <summary>�J�n�d�����t</summary>
		/// <remarks>YYYYMMDD (�����͂�0)</remarks>
		private Int32 _stockDateSt;

		/// <summary>�I���d�����t</summary>
		/// <remarks>YYYYMMDD (�����͂�0)</remarks>
		private Int32 _stockDateEd;

		/// <summary>�J�n���ד��t</summary>
		/// <remarks>YYYYMMDD (�����͂�0)</remarks>
		private Int32 _arrivalGoodsDaySt;

		/// <summary>�I�����ד��t</summary>
		/// <remarks>YYYYMMDD (�����͂�0)</remarks>
		private Int32 _arrivalGoodsDayEd;

		/// <summary>�J�n���͓��t</summary>
		/// <remarks>YYYYMMDD (�����͂�0)</remarks>
		private Int32 _inputDaySt;

		/// <summary>�I�����͓��t</summary>
		/// <remarks>YYYYMMDD (�����͂�0)</remarks>
		private Int32 _inputDayEd;

		/// <summary>��\�敪</summary>
		/// <remarks>0:�S�Ĉ��,1:�c�̂�   �����g�p</remarks>
		private Int32 _makeShowDiv;

		/// <summary>�`�[�敪</summary>
		/// <remarks>0:����,1:�ԕi,2:���ׁ{�ԕi</remarks>
		private Int32 _slipDiv;

		/// <summary>�o�͏�</summary>
		/// <remarks>0:�d���恨���ד����`�[�ԍ��A1:���ד����d���恨�`�[�ԍ��A2:�S���ҁ��d���恨���ד����`�[�ԍ��A3:���ד����`�[�ԍ��A4:�`�[�ԍ�</remarks>
		private Int32 _sortOrder;

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>0:���`,1:�ԓ`,2:����,3:�S��</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>�J�n�����`�[�ԍ�</summary>
		private string _st_PartySaleSlipNum = "";

		/// <summary>�I�������`�[�ԍ�</summary>
		private string _ed_PartySaleSlipNum = "";


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

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  SupplierCdSt
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  StockAgentCodeSt
		/// <summary>�J�n�d���S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d���S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCodeSt
		{
			get{return _stockAgentCodeSt;}
			set{_stockAgentCodeSt = value;}
		}

		/// public propaty name  :  StockAgentCodeEd
		/// <summary>�I���d���S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d���S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCodeEd
		{
			get{return _stockAgentCodeEd;}
			set{_stockAgentCodeEd = value;}
		}

		/// public propaty name  :  SupplierSlipNoSt
		/// <summary>�J�n�d���`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d���`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNoSt
		{
			get{return _supplierSlipNoSt;}
			set{_supplierSlipNoSt = value;}
		}

		/// public propaty name  :  SupplierSlipNoEd
		/// <summary>�I���d���`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d���`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNoEd
		{
			get{return _supplierSlipNoEd;}
			set{_supplierSlipNoEd = value;}
		}

		/// public propaty name  :  StockDateSt
		/// <summary>�J�n�d�����t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d�����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get{return _stockDateSt;}
			set{_stockDateSt = value;}
		}

		/// public propaty name  :  StockDateEd
		/// <summary>�I���d�����t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d�����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get{return _stockDateEd;}
			set{_stockDateEd = value;}
		}

		/// public propaty name  :  ArrivalGoodsDaySt
		/// <summary>�J�n���ד��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���ד��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ArrivalGoodsDaySt
		{
			get{return _arrivalGoodsDaySt;}
			set{_arrivalGoodsDaySt = value;}
		}

		/// public propaty name  :  ArrivalGoodsDayEd
		/// <summary>�I�����ד��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����ד��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ArrivalGoodsDayEd
		{
			get{return _arrivalGoodsDayEd;}
			set{_arrivalGoodsDayEd = value;}
		}

		/// public propaty name  :  InputDaySt
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get{return _inputDaySt;}
			set{_inputDaySt = value;}
		}

		/// public propaty name  :  InputDayEd
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get{return _inputDayEd;}
			set{_inputDayEd = value;}
		}

		/// public propaty name  :  MakeShowDiv
		/// <summary>��\�敪�v���p�e�B</summary>
		/// <value>0:�S�Ĉ��,1:�c�̂�   �����g�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��\�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get{return _makeShowDiv;}
			set{_makeShowDiv = value;}
		}

		/// public propaty name  :  SlipDiv
		/// <summary>�`�[�敪�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi,2:���ׁ{�ԕi</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get{return _slipDiv;}
			set{_slipDiv = value;}
		}

		/// public propaty name  :  SortOrder
		/// <summary>�o�͏��v���p�e�B</summary>
		/// <value>0:�d���恨���ד����`�[�ԍ��A1:���ד����d���恨�`�[�ԍ��A2:�S���ҁ��d���恨���ד����`�[�ԍ��A3:���ד����`�[�ԍ��A4:�`�[�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͏��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortOrder
		{
			get{return _sortOrder;}
			set{_sortOrder = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>�ԓ`�敪�v���p�e�B</summary>
		/// <value>0:���`,1:�ԓ`,2:����,3:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԓ`�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  St_PartySaleSlipNum
		/// <summary>�J�n�����`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_PartySaleSlipNum
		{
			get{return _st_PartySaleSlipNum;}
			set{_st_PartySaleSlipNum = value;}
		}

		/// public propaty name  :  Ed_PartySaleSlipNum
		/// <summary>�I�������`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_PartySaleSlipNum
		{
			get{return _ed_PartySaleSlipNum;}
			set{_ed_PartySaleSlipNum = value;}
		}


		/// <summary>
		/// ���׊m�F�\���o�����N���X���[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ArrivalListParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ArrivalListParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrivalListParamWork()
		{
		}

	}

}

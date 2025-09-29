using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OrderConfShWork
	/// <summary>
	///                      �󒍑ݏo�m�F�\���o�����N���X���[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �󒍑ݏo�m�F�\���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OrderConfShWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _resultsAddUpSecList;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�󒍃X�e�[�^�X</summary>
		private Int32 _acptAnOdrStatus;

		/// <summary>������t(�J�n)</summary>
		private Int32 _salesDateSt;

		/// <summary>������t(�I��)</summary>
		private Int32 _salesDateEd;

		/// <summary>�o�ד��t(�J�n)</summary>
		private Int32 _shipmentDaySt;

		/// <summary>�o�ד��t(�I��)</summary>
		private Int32 _shipmentDayEd;

		/// <summary>���͓��t(�J�n)</summary>
		private Int32 _searchSlipDateSt;

		/// <summary>���͓��t(�I��)</summary>
		private Int32 _searchSlipDateEd;

		/// <summary>���Ӑ�R�[�h(�J�n)</summary>
		private Int32 _customerCodeSt;

		/// <summary>���Ӑ�R�[�h(�I��)</summary>
		private Int32 _customerCodeEd;

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>0:���`,1:�ԓ`,2:�����@�@���S�Ă�-1</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>����`�[�敪</summary>
		/// <remarks>0:����,1:�ԕi�@���S�Ă�-1</remarks>
		private Int32 _salesSlipCd;

		/// <summary>����`�[�ԍ�(�J�n)</summary>
		private string _salesSlipNumSt = "";

		/// <summary>����`�[�ԍ�(�I��)</summary>
		private string _salesSlipNumEd = "";

		/// <summary>�̔��]�ƈ��R�[�h(�J�n)</summary>
		private string _salesEmployeeCdSt = "";

		/// <summary>�̔��]�ƈ��R�[�h(�I��)</summary>
		private string _salesEmployeeCdEd = "";

		/// <summary>��t�]�ƈ��R�[�h(�J�n)</summary>
		private string _frontEmployeeCdSt = "";

		/// <summary>��t�]�ƈ��R�[�h(�I��)</summary>
		private string _frontEmployeeCdEd = "";

		/// <summary>���͒S���҃R�[�h(�J�n)</summary>
		private string _salesInputCodeSt = "";

		/// <summary>���͒S���҃R�[�h(�I��)</summary>
		private string _salesInputCodeEd = "";

		/// <summary>�e���`�F�b�N����</summary>
		/// <remarks>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckLower;

		/// <summary>�e���`�F�b�N�K��</summary>
		/// <remarks>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>�e���`�F�b�N���</summary>
		/// <remarks>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>�e���`�F�b�N1(�}�[�N)</summary>
		private string _grossMargin1Mark = "";

		/// <summary>�e���`�F�b�N2(�}�[�N)</summary>
		private string _grossMargin2Mark = "";

		/// <summary>�e���`�F�b�N3(�}�[�N)</summary>
		private string _grossMargin3Mark = "";

		/// <summary>�e���`�F�b�N4(�}�[�N)</summary>
		private string _grossMargin4Mark = "";

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:��,1:�󒍌v��ς�,2:�ݏo,3:�ݏo�v��ς�,4:��(UOE��M),5:�󒍌v��ς�(UOE��M)</remarks>
		private Int32 _printDiv;


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

		/// public propaty name  :  ResultsAddUpSecList
		/// <summary>���ьv�㋒�_�R�[�h���X�g�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ьv�㋒�_�R�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string[] ResultsAddUpSecList
		{
			get{return _resultsAddUpSecList;}
			set{_resultsAddUpSecList = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜</value>
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

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesDateSt
		/// <summary>������t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesDateSt
		{
			get{return _salesDateSt;}
			set{_salesDateSt = value;}
		}

		/// public propaty name  :  SalesDateEd
		/// <summary>������t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesDateEd
		{
			get{return _salesDateEd;}
			set{_salesDateEd = value;}
		}

		/// public propaty name  :  ShipmentDaySt
		/// <summary>�o�ד��t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד��t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmentDaySt
		{
			get{return _shipmentDaySt;}
			set{_shipmentDaySt = value;}
		}

		/// public propaty name  :  ShipmentDayEd
		/// <summary>�o�ד��t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד��t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmentDayEd
		{
			get{return _shipmentDayEd;}
			set{_shipmentDayEd = value;}
		}

		/// public propaty name  :  SearchSlipDateSt
		/// <summary>���͓��t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchSlipDateSt
		{
			get{return _searchSlipDateSt;}
			set{_searchSlipDateSt = value;}
		}

		/// public propaty name  :  SearchSlipDateEd
		/// <summary>���͓��t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchSlipDateEd
		{
			get{return _searchSlipDateEd;}
			set{_searchSlipDateEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>�ԓ`�敪�v���p�e�B</summary>
		/// <value>0:���`,1:�ԓ`,2:�����@�@���S�Ă�-1</value>
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

		/// public propaty name  :  SalesSlipCd
		/// <summary>����`�[�敪�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi�@���S�Ă�-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
		}

		/// public propaty name  :  SalesSlipNumSt
		/// <summary>����`�[�ԍ�(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNumSt
		{
			get{return _salesSlipNumSt;}
			set{_salesSlipNumSt = value;}
		}

		/// public propaty name  :  SalesSlipNumEd
		/// <summary>����`�[�ԍ�(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNumEd
		{
			get{return _salesSlipNumEd;}
			set{_salesSlipNumEd = value;}
		}

		/// public propaty name  :  SalesEmployeeCdSt
		/// <summary>�̔��]�ƈ��R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��]�ƈ��R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeCdSt
		{
			get{return _salesEmployeeCdSt;}
			set{_salesEmployeeCdSt = value;}
		}

		/// public propaty name  :  SalesEmployeeCdEd
		/// <summary>�̔��]�ƈ��R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��]�ƈ��R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeCdEd
		{
			get{return _salesEmployeeCdEd;}
			set{_salesEmployeeCdEd = value;}
		}

		/// public propaty name  :  FrontEmployeeCdSt
		/// <summary>��t�]�ƈ��R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ��R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeCdSt
		{
			get{return _frontEmployeeCdSt;}
			set{_frontEmployeeCdSt = value;}
		}

		/// public propaty name  :  FrontEmployeeCdEd
		/// <summary>��t�]�ƈ��R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ��R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeCdEd
		{
			get{return _frontEmployeeCdEd;}
			set{_frontEmployeeCdEd = value;}
		}

		/// public propaty name  :  SalesInputCodeSt
		/// <summary>���͒S���҃R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͒S���҃R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputCodeSt
		{
			get{return _salesInputCodeSt;}
			set{_salesInputCodeSt = value;}
		}

		/// public propaty name  :  SalesInputCodeEd
		/// <summary>���͒S���҃R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͒S���҃R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputCodeEd
		{
			get{return _salesInputCodeEd;}
			set{_salesInputCodeEd = value;}
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>�e���`�F�b�N�����v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckLower
		{
			get{return _grsProfitCheckLower;}
			set{_grsProfitCheckLower = value;}
		}

		/// public propaty name  :  GrsProfitCheckBest
		/// <summary>�e���`�F�b�N�K���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�K���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckBest
		{
			get{return _grsProfitCheckBest;}
			set{_grsProfitCheckBest = value;}
		}

		/// public propaty name  :  GrsProfitCheckUpper
		/// <summary>�e���`�F�b�N����v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckUpper
		{
			get{return _grsProfitCheckUpper;}
			set{_grsProfitCheckUpper = value;}
		}

		/// public propaty name  :  GrossMargin1Mark
		/// <summary>�e���`�F�b�N1(�}�[�N)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N1(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin1Mark
		{
			get{return _grossMargin1Mark;}
			set{_grossMargin1Mark = value;}
		}

		/// public propaty name  :  GrossMargin2Mark
		/// <summary>�e���`�F�b�N2(�}�[�N)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N2(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin2Mark
		{
			get{return _grossMargin2Mark;}
			set{_grossMargin2Mark = value;}
		}

		/// public propaty name  :  GrossMargin3Mark
		/// <summary>�e���`�F�b�N3(�}�[�N)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N3(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin3Mark
		{
			get{return _grossMargin3Mark;}
			set{_grossMargin3Mark = value;}
		}

		/// public propaty name  :  GrossMargin4Mark
		/// <summary>�e���`�F�b�N4(�}�[�N)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N4(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin4Mark
		{
			get{return _grossMargin4Mark;}
			set{_grossMargin4Mark = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:��,1:�󒍌v��ς�,2:�ݏo,3:�ݏo�v��ς�,4:��(UOE��M),5:�󒍌v��ς�(UOE��M)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}


		/// <summary>
		/// �󒍑ݏo�m�F�\���o�����N���X���[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>OrderConfShWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderConfShWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderConfShWork()
		{
		}

	}

}

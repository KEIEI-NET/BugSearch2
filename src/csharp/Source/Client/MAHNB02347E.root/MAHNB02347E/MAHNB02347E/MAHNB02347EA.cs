//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ����m�F�\
// �v���O�����T�v   : ����m�F�\��������
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2008/07/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : ��Q�Ή�10247,11302,10743,11402
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10806793-00  �쐬�S�� : �c����
// �C �� ��  2013/01/04  �C�����e : 2013/03/13�z�M�� Redmine#34098
//                                  �r���󎚐���̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11570208-00  �쐬�S�� : 3H ����
// �C �� ��  2020/02/27  �C�����e : �y���ŗ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_MAHNB02347E
	/// <summary>
	///                      ����m�F�\��������
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����m�F�\���������w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/04/13 30452 ��� �r��</br>
    /// <br>                     �E��Q�Ή�10247,11302,10743,11402</br>
    /// <br>Update Note      :   2013/01/04 �c����</br>
    /// <br>�Ǘ��ԍ�         :   10806793-00 2013/03/13�z�M��</br>
    /// <br>                     Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
    /// <br>Update Note      :   2020/02/27 3H ����</br>
    /// <br>�Ǘ��ԍ�         :   11570208-00 �y���ŗ��Ή�</br>
	/// </remarks>
	public class ExtrInfo_MAHNB02347E
	{

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�S�БI��</summary>
		/// <remarks>true:�S�БI�� false:�e���_�I��</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
		/// <remarks>�����^�@���z�񍀖� �S�Ўw���{""}</remarks>
		private string[] _resultsAddUpSecList;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>������t(�J�n)</summary>
		private Int32 _salesDateSt;

		/// <summary>������t(�I��)</summary>
		private Int32 _salesDateEd;

		/// <summary>�`�[�������t(�J�n)</summary>
		private Int32 _searchSlipDateSt;

		/// <summary>�`�[�������t(�I��)</summary>
		private Int32 _searchSlipDateEd;

		/// <summary>�o�ד��t�i�J�n�j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _shipmentDaySt;

		/// <summary>�o�ד��t�i�I���j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _shipmentDayEd;

		/// <summary>���Ӑ�R�[�h(�J�n)</summary>
		private Int32 _customerCodeSt;

		/// <summary>���Ӑ�R�[�h(�I��)</summary>
		private Int32 _customerCodeEd;

		/// <summary>�d����R�[�h(�J�n)</summary>
		private Int32 _supplierCdSt;

		/// <summary>�d����R�[�h(�I��)</summary>
		private Int32 _supplierCdEd;

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>0:���`,1:�ԓ`,2:�����@�@���S�Ă�-1</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>����`�[�敪</summary>
		/// <remarks>0:����,1:�ԕi,2:�ԕi�{�s�l���@���S�Ă�-1</remarks>
		private Int32 _salesSlipCd;

		/// <summary>����`�[�ԍ�(�J�n)</summary>
		private string _salesSlipNumSt = "";

		/// <summary>����`�[�ԍ�(�I��)</summary>
		private string _salesSlipNumEd = "";

		/// <summary>������͎҃R�[�h(�J�n)</summary>
		/// <remarks>���͒S���ҁi���s�ҁj</remarks>
		private string _salesInputCodeSt = "";

		/// <summary>������͎҃R�[�h(�I��)</summary>
		/// <remarks>���͒S���ҁi���s�ҁj</remarks>
		private string _salesInputCodeEd = "";

		/// <summary>�̔��]�ƈ��R�[�h(�J�n)</summary>
		/// <remarks>�v��S���ҁi�S���ҁj</remarks>
		private string _salesEmployeeCdSt = "";

		/// <summary>�̔��]�ƈ��R�[�h(�I��)</summary>
		/// <remarks>�v��S���ҁi�S���ҁj</remarks>
		private string _salesEmployeeCdEd = "";

		/// <summary>��t�]�ƈ��R�[�h�i�J�n�j</summary>
		/// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
		private string _frontEmployeeCdSt = "";

		/// <summary>��t�]�ƈ��R�[�h�i�I���j</summary>
		/// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
		private string _frontEmployeeCdEd = "";

		/// <summary>�̔��G���A�R�[�h(�J�n)</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _salesAreaCodeSt;

		/// <summary>�̔��G���A�R�[�h(�I��)</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _salesAreaCodeEd;

		/// <summary>�Ǝ�R�[�h(�J�n)</summary>
		private Int32 _businessTypeCodeSt;

		/// <summary>�Ǝ�R�[�h(�I��)</summary>
		private Int32 _businessTypeCodeEd;

		/// <summary>����`�[�X�V�敪</summary>
		/// <remarks>0:���X�V,1:�X�V����@���S�Ă�-1</remarks>
		private Int32 _salesSlipUpdateCd;

		/// <summary>����݌Ɏ�񂹋敪</summary>
		/// <remarks>0:��񂹁C1:�݌Ɂ@�@���S�Ă�-1�@���j����m�F�\�Œ������@���u2:��ײݔ����v�w�莞��-1���Z�b�g</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>�������@</summary>
		/// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^�@���S�Ă�-1</remarks>
		private Int32 _wayToOrder;

		/// <summary>�e���`�F�b�N����</summary>
		/// <remarks>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckLower;

        /// <summary>�e���`�F�b�N2</summary>
        private Double _grossMarginSt;

        /// <summary>�e���`�F�b�N3</summary>
        private Double _grossMargin2Ed;

        /// <summary>�e���`�F�b�N4</summary>
        private Double _grossMargin3Ed;

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

		/// <summary>�����[���݈̂�</summary>
		/// <remarks>0:�w��Ȃ�,1:�w�肠��</remarks>
		private Int32 _zeroSalesPrint;

		/// <summary>�����[���݈̂�</summary>
		/// <remarks>0:�w��Ȃ�,1:�w�肠��</remarks>
		private Int32 _zeroCostPrint;

		/// <summary>�e���[���݈̂�</summary>
		/// <remarks>0:�w��Ȃ�,1:�w�肠��</remarks>
		private Int32 _zeroGrsProfitPrint;

		/// <summary>�e���[���ȉ��݈̂�</summary>
		/// <remarks>0:�w��Ȃ�,1:�w�肠��</remarks>
		private Int32 _zeroUdrGrsProfitPrint;

		/// <summary>�e������</summary>
		/// <remarks>0:�w��Ȃ�,1:�w�肠��</remarks>
		private Int32 _grsProfitRatePrint;

		/// <summary>�e�����󎚒l</summary>
		private Double _grsProfitRatePrintVal;

		/// <summary>�e�����󎚋敪</summary>
		/// <remarks>0:�ȉ�,1:�ȏ�</remarks>
		private Int32 _grsProfitRatePrintDiv;

        /// <summary>�o�͏�</summary>
        private Int32 _sortOrder;

        /// <summary>�����E�e���o��</summary>
        private Int32 _costOut;

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>���v��</summary>
        private Int32 _printDailyFooter;
        // --- ADD 2009/04/13 --------------------------------<<<<<

        /// <summary>����</summary>
        private Int32 _newPageType;

        //----- ADD 2013/01/04 �c���� Redmine#34098 ----->>>>>
        /// <summary>�r���󎚐���</summary>
        private Int32 _linePrintDiv;
        //----- ADD 2013/01/04 �c���� Redmine#34098 -----<<<<<
        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ��P</summary>
        private string _taxRate1;

        /// <summary>�ŗ��Q</summary>
        private string _taxRate2;
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        /// <summary>���[�^�C�v�敪</summary>
        /// <remarks>�p�r�Ɠ���</remarks>
        private int _printDiv;

        /// <summary>���[�^�C�v�敪����</summary>
        private string _printDivName = string.Empty;

        // ���[�^�C�v�敪
        /// <summary>���[�^�C�v�敪 �`�[�`��</summary>
        public const string ct_PrintDiv_Slipform = "�`�[�^�C�v";
        /// <summary>���[�^�C�v�敪 ���׌`��</summary>
        public const string ct_PrintDiv_Detailsform = "���׃^�C�v";

        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>�S�БI���v���p�e�B</summary>
		/// <value>true:�S�БI�� false:�e���_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S�БI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsSelectAllSection
		{
			get{return _isSelectAllSection;}
			set{_isSelectAllSection = value;}
		}

		/// public propaty name  :  ResultsAddUpSecList
		/// <summary>���ьv�㋒�_�R�[�h���X�g�v���p�e�B</summary>
		/// <value>�����^�@���z�񍀖� �S�Ўw���{""}</value>
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

		/// public propaty name  :  SearchSlipDateSt
		/// <summary>�`�[�������t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchSlipDateSt
		{
			get{return _searchSlipDateSt;}
			set{_searchSlipDateSt = value;}
		}

		/// public propaty name  :  SearchSlipDateEd
		/// <summary>�`�[�������t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchSlipDateEd
		{
			get{return _searchSlipDateEd;}
			set{_searchSlipDateEd = value;}
		}

		/// public propaty name  :  ShipmentDaySt
		/// <summary>�o�ד��t�i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד��t�i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmentDaySt
		{
			get{return _shipmentDaySt;}
			set{_shipmentDaySt = value;}
		}

		/// public propaty name  :  ShipmentDayEd
		/// <summary>�o�ד��t�i�I���j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד��t�i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmentDayEd
		{
			get{return _shipmentDayEd;}
			set{_shipmentDayEd = value;}
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

		/// public propaty name  :  SupplierCdSt
		/// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
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
		/// <value>0:����,1:�ԕi,2:�ԕi�{�s�l���@���S�Ă�-1</value>
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

		/// public propaty name  :  SalesInputCodeSt
		/// <summary>������͎҃R�[�h(�J�n)�v���p�e�B</summary>
		/// <value>���͒S���ҁi���s�ҁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������͎҃R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputCodeSt
		{
			get{return _salesInputCodeSt;}
			set{_salesInputCodeSt = value;}
		}

		/// public propaty name  :  SalesInputCodeEd
		/// <summary>������͎҃R�[�h(�I��)�v���p�e�B</summary>
		/// <value>���͒S���ҁi���s�ҁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������͎҃R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputCodeEd
		{
			get{return _salesInputCodeEd;}
			set{_salesInputCodeEd = value;}
		}

		/// public propaty name  :  SalesEmployeeCdSt
		/// <summary>�̔��]�ƈ��R�[�h(�J�n)�v���p�e�B</summary>
		/// <value>�v��S���ҁi�S���ҁj</value>
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
		/// <value>�v��S���ҁi�S���ҁj</value>
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
		/// <summary>��t�]�ƈ��R�[�h�i�J�n�j�v���p�e�B</summary>
		/// <value>��t�S���ҁi�󒍎ҁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ��R�[�h�i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeCdSt
		{
			get{return _frontEmployeeCdSt;}
			set{_frontEmployeeCdSt = value;}
		}

		/// public propaty name  :  FrontEmployeeCdEd
		/// <summary>��t�]�ƈ��R�[�h�i�I���j�v���p�e�B</summary>
		/// <value>��t�S���ҁi�󒍎ҁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ��R�[�h�i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeCdEd
		{
			get{return _frontEmployeeCdEd;}
			set{_frontEmployeeCdEd = value;}
		}

		/// public propaty name  :  SalesAreaCodeSt
		/// <summary>�̔��G���A�R�[�h(�J�n)�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesAreaCodeSt
		{
			get{return _salesAreaCodeSt;}
			set{_salesAreaCodeSt = value;}
		}

		/// public propaty name  :  SalesAreaCodeEd
		/// <summary>�̔��G���A�R�[�h(�I��)�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesAreaCodeEd
		{
			get{return _salesAreaCodeEd;}
			set{_salesAreaCodeEd = value;}
		}

		/// public propaty name  :  BusinessTypeCodeSt
		/// <summary>�Ǝ�R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ǝ�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BusinessTypeCodeSt
		{
			get{return _businessTypeCodeSt;}
			set{_businessTypeCodeSt = value;}
		}

		/// public propaty name  :  BusinessTypeCodeEd
		/// <summary>�Ǝ�R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ǝ�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BusinessTypeCodeEd
		{
			get{return _businessTypeCodeEd;}
			set{_businessTypeCodeEd = value;}
		}

		/// public propaty name  :  SalesSlipUpdateCd
		/// <summary>����`�[�X�V�敪�v���p�e�B</summary>
		/// <value>0:���X�V,1:�X�V����@���S�Ă�-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�X�V�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipUpdateCd
		{
			get{return _salesSlipUpdateCd;}
			set{_salesSlipUpdateCd = value;}
		}

		/// public propaty name  :  SalesOrderDivCd
		/// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
		/// <value>0:��񂹁C1:�݌Ɂ@�@���S�Ă�-1�@���j����m�F�\�Œ������@���u2:��ײݔ����v�w�莞��-1���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesOrderDivCd
		{
			get{return _salesOrderDivCd;}
			set{_salesOrderDivCd = value;}
		}

		/// public propaty name  :  WayToOrder
		/// <summary>�������@�v���p�e�B</summary>
		/// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^�@���S�Ă�-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
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

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double GrossMarginSt
        {
            get { return _grossMarginSt; }
            set { _grossMarginSt = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double GrossMargin2Ed
        {
            get { return _grossMargin2Ed; }
            set { _grossMargin2Ed = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double GrossMargin3Ed
        {
            get { return _grossMargin3Ed; }
            set { _grossMargin3Ed = value; }
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

		/// public propaty name  :  ZeroSalesPrint
		/// <summary>�����[���݈̂󎚃v���p�e�B</summary>
		/// <value>0:�w��Ȃ�,1:�w�肠��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����[���݈̂󎚃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ZeroSalesPrint
		{
			get{return _zeroSalesPrint;}
			set{_zeroSalesPrint = value;}
		}

		/// public propaty name  :  ZeroCostPrint
		/// <summary>�����[���݈̂󎚃v���p�e�B</summary>
		/// <value>0:�w��Ȃ�,1:�w�肠��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����[���݈̂󎚃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ZeroCostPrint
		{
			get{return _zeroCostPrint;}
			set{_zeroCostPrint = value;}
		}

		/// public propaty name  :  ZeroGrsProfitPrint
		/// <summary>�e���[���݈̂󎚃v���p�e�B</summary>
		/// <value>0:�w��Ȃ�,1:�w�肠��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���[���݈̂󎚃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ZeroGrsProfitPrint
		{
			get{return _zeroGrsProfitPrint;}
			set{_zeroGrsProfitPrint = value;}
		}

		/// public propaty name  :  ZeroUdrGrsProfitPrint
		/// <summary>�e���[���ȉ��݈̂󎚃v���p�e�B</summary>
		/// <value>0:�w��Ȃ�,1:�w�肠��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���[���ȉ��݈̂󎚃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ZeroUdrGrsProfitPrint
		{
			get{return _zeroUdrGrsProfitPrint;}
			set{_zeroUdrGrsProfitPrint = value;}
		}

		/// public propaty name  :  GrsProfitRatePrint
		/// <summary>�e�����󎚃v���p�e�B</summary>
		/// <value>0:�w��Ȃ�,1:�w�肠��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�����󎚃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GrsProfitRatePrint
		{
			get{return _grsProfitRatePrint;}
			set{_grsProfitRatePrint = value;}
		}

		/// public propaty name  :  GrsProfitRatePrintVal
		/// <summary>�e�����󎚒l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�����󎚒l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitRatePrintVal
		{
			get{return _grsProfitRatePrintVal;}
			set{_grsProfitRatePrintVal = value;}
		}

		/// public propaty name  :  GrsProfitRatePrintDiv
		/// <summary>�e�����󎚋敪�v���p�e�B</summary>
		/// <value>0:�ȉ�,1:�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�����󎚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GrsProfitRatePrintDiv
		{
			get{return _grsProfitRatePrintDiv;}
			set{_grsProfitRatePrintDiv = value;}
		}

        /// public propaty name  :  SortOrder
        /// <summary>�o�͏��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͏��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        /// public propaty name  :  CostOut
        /// <summary>�����E�e���o�̓v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����E�e���o�̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CostOut
        {
            get { return _costOut; }
            set { _costOut = value; }
        }

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// public propaty name  :  PrintDailyFooter
        /// <summary>���v�󎚃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�󎚃v���p�e�B</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<

        /// public propaty name  :  NewPageType
        /// <summary>���Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }
        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// public propaty name  :  TaxPrintDiv
        /// <summary>�ŕʓ���󎚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŕʓ���󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>�ŗ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ��Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

        //----- ADD 2013/01/04 �c���� Redmine#34098 ----->>>>>
        /// public propaty name  :  LinePrintDiv
        /// <summary>�r���󎚐���</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���󎚐���v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date	         :   2013/01/04</br>
        /// </remarks>
        public Int32 LinePrintDiv
        {
            get { return _linePrintDiv; }
            set { _linePrintDiv = value; }
        }
        //----- ADD 2013/01/04 �c���� Redmine#34098 -----<<<<<

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

        //���[�ݒ� ---------------------------------------------------------------
        /// public propaty name  :  PrintDiv
        /// <summary>���[�^�C�v�敪�v���p�e�B</summary>
        /// <value>�ݒ�̗p�r�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>���[�^�C�v�敪�v���p�e�B����(�ǂݎ���p)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
        }

        /// <summary> ���[�^�C�v�敪�񋓑� </summary>
        public enum PrintDivState
        {
            /// <summary> �`�[�^�C�v </summary>
            Slipform = 1,
            /// <summary> ���׃^�C�v </summary>
            Detailsform = 2,
        }

		/// <summary>
		/// ����m�F�\���������R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAHNB02347E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_MAHNB02347E()
		{
		}

		/// <summary>
		/// ����m�F�\���������R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI�� false:�e���_�I��)</param>
		/// <param name="resultsAddUpSecList">���ьv�㋒�_�R�[�h���X�g(�����^�@���z�񍀖� �S�Ўw���{""})</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
		/// <param name="salesDateSt">������t(�J�n)</param>
		/// <param name="salesDateEd">������t(�I��)</param>
		/// <param name="searchSlipDateSt">�`�[�������t(�J�n)</param>
		/// <param name="searchSlipDateEd">�`�[�������t(�I��)</param>
		/// <param name="shipmentDaySt">�o�ד��t�i�J�n�j(YYYYMMDD)</param>
		/// <param name="shipmentDayEd">�o�ד��t�i�I���j(YYYYMMDD)</param>
		/// <param name="customerCodeSt">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="customerCodeEd">���Ӑ�R�[�h(�I��)</param>
		/// <param name="supplierCdSt">�d����R�[�h(�J�n)</param>
		/// <param name="supplierCdEd">�d����R�[�h(�I��)</param>
		/// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:�����@�@���S�Ă�-1)</param>
		/// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi,2:�ԕi�{�s�l���@���S�Ă�-1)</param>
		/// <param name="salesSlipNumSt">����`�[�ԍ�(�J�n)</param>
		/// <param name="salesSlipNumEd">����`�[�ԍ�(�I��)</param>
		/// <param name="salesInputCodeSt">������͎҃R�[�h(�J�n)(���͒S���ҁi���s�ҁj)</param>
		/// <param name="salesInputCodeEd">������͎҃R�[�h(�I��)(���͒S���ҁi���s�ҁj)</param>
		/// <param name="salesEmployeeCdSt">�̔��]�ƈ��R�[�h(�J�n)(�v��S���ҁi�S���ҁj)</param>
		/// <param name="salesEmployeeCdEd">�̔��]�ƈ��R�[�h(�I��)(�v��S���ҁi�S���ҁj)</param>
		/// <param name="frontEmployeeCdSt">��t�]�ƈ��R�[�h�i�J�n�j(��t�S���ҁi�󒍎ҁj)</param>
		/// <param name="frontEmployeeCdEd">��t�]�ƈ��R�[�h�i�I���j(��t�S���ҁi�󒍎ҁj)</param>
		/// <param name="salesAreaCodeSt">�̔��G���A�R�[�h(�J�n)(�n��R�[�h)</param>
		/// <param name="salesAreaCodeEd">�̔��G���A�R�[�h(�I��)(�n��R�[�h)</param>
		/// <param name="businessTypeCodeSt">�Ǝ�R�[�h(�J�n)</param>
		/// <param name="businessTypeCodeEd">�Ǝ�R�[�h(�I��)</param>
		/// <param name="salesSlipUpdateCd">����`�[�X�V�敪(0:���X�V,1:�X�V����@���S�Ă�-1)</param>
		/// <param name="salesOrderDivCd">����݌Ɏ�񂹋敪(0:��񂹁C1:�݌Ɂ@�@���S�Ă�-1�@���j����m�F�\�Œ������@���u2:��ײݔ����v�w�莞��-1���Z�b�g)</param>
		/// <param name="wayToOrder">�������@(0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^�@���S�Ă�-1)</param>
		/// <param name="grsProfitCheckLower">�e���`�F�b�N����(�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�)</param>
        /// <param name="grossMarginSt">�e���`�F�b�N2</param>
        /// <param name="grossMargin2Ed">�e���`�F�b�N3</param>
        /// <param name="grossMargin3Ed">�e���`�F�b�N4</param>
        /// <param name="grsProfitCheckBest">�e���`�F�b�N�K��(�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grsProfitCheckUpper">�e���`�F�b�N���(�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grossMargin1Mark">�e���`�F�b�N1(�}�[�N)</param>
		/// <param name="grossMargin2Mark">�e���`�F�b�N2(�}�[�N)</param>
		/// <param name="grossMargin3Mark">�e���`�F�b�N3(�}�[�N)</param>
		/// <param name="grossMargin4Mark">�e���`�F�b�N4(�}�[�N)</param>
		/// <param name="zeroSalesPrint">�����[���݈̂�(0:�w��Ȃ�,1:�w�肠��)</param>
		/// <param name="zeroCostPrint">�����[���݈̂�(0:�w��Ȃ�,1:�w�肠��)</param>
		/// <param name="zeroGrsProfitPrint">�e���[���݈̂�(0:�w��Ȃ�,1:�w�肠��)</param>
		/// <param name="zeroUdrGrsProfitPrint">�e���[���ȉ��݈̂�(0:�w��Ȃ�,1:�w�肠��)</param>
		/// <param name="grsProfitRatePrint">�e������(0:�w��Ȃ�,1:�w�肠��)</param>
		/// <param name="grsProfitRatePrintVal">�e�����󎚒l</param>
		/// <param name="grsProfitRatePrintDiv">�e�����󎚋敪(0:�ȉ�,1:�ȏ�)</param>
        /// <param name="sortOrder">�o�͏�</param>
        /// <param name="costOut">�����E�e���o��</param>
        /// <param name="printDailyFooter">���v��</param>
        /// <param name="newPageType">����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="taxPrintDiv">�ŕʓ����</param>
        /// <param name="taxRate1">XML�̐ŗ��P</param>
        /// <param name="taxRate2">XML�̐ŗ��Q</param>
		/// <returns>ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAHNB02347E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note             :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
		/// </remarks>
        //public ExtrInfo_MAHNB02347E(string enterpriseCode, Boolean isSelectAllSection, string[] resultsAddUpSecList, Int32 logicalDeleteCode, Int32 salesDateSt, Int32 salesDateEd, Int32 searchSlipDateSt, Int32 searchSlipDateEd, Int32 shipmentDaySt, Int32 shipmentDayEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 debitNoteDiv, Int32 salesSlipCd, string salesSlipNumSt, string salesSlipNumEd, string salesInputCodeSt, string salesInputCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, string frontEmployeeCdSt, string frontEmployeeCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 businessTypeCodeSt, Int32 businessTypeCodeEd, Int32 salesSlipUpdateCd, Int32 salesOrderDivCd, Int32 wayToOrder, Double grsProfitCheckLower, Double grossMarginSt, Double grossMargin2Ed, Double grossMargin3Ed, Double grsProfitCheckBest, Double grsProfitCheckUpper, string grossMargin1Mark, string grossMargin2Mark, string grossMargin3Mark, string grossMargin4Mark, Int32 zeroSalesPrint, Int32 zeroCostPrint, Int32 zeroGrsProfitPrint, Int32 zeroUdrGrsProfitPrint, Int32 grsProfitRatePrint, Double grsProfitRatePrintVal, Int32 grsProfitRatePrintDiv, Int32 sortOrder, Int32 costOut, Int32 printDailyFooter, Int32 newPageType, string enterpriseName)                  // --- DEL 3H ���� 2020/02/27
        public ExtrInfo_MAHNB02347E(string enterpriseCode, Boolean isSelectAllSection, string[] resultsAddUpSecList, Int32 logicalDeleteCode, Int32 salesDateSt, Int32 salesDateEd, Int32 searchSlipDateSt, Int32 searchSlipDateEd, Int32 shipmentDaySt, Int32 shipmentDayEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 debitNoteDiv, Int32 salesSlipCd, string salesSlipNumSt, string salesSlipNumEd, string salesInputCodeSt, string salesInputCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, string frontEmployeeCdSt, string frontEmployeeCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 businessTypeCodeSt, Int32 businessTypeCodeEd, Int32 salesSlipUpdateCd, Int32 salesOrderDivCd, Int32 wayToOrder, Double grsProfitCheckLower, Double grossMarginSt, Double grossMargin2Ed, Double grossMargin3Ed, Double grsProfitCheckBest, Double grsProfitCheckUpper, string grossMargin1Mark, string grossMargin2Mark, string grossMargin3Mark, string grossMargin4Mark, Int32 zeroSalesPrint, Int32 zeroCostPrint, Int32 zeroGrsProfitPrint, Int32 zeroUdrGrsProfitPrint, Int32 grsProfitRatePrint, Double grsProfitRatePrintVal, Int32 grsProfitRatePrintDiv, Int32 sortOrder, Int32 costOut, Int32 printDailyFooter, Int32 newPageType, string enterpriseName, Int32 taxPrintDiv,string taxRate1, string taxRate2) // --- ADD 3H ���� 2020/02/27
		{
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._logicalDeleteCode = logicalDeleteCode;
			this._salesDateSt = salesDateSt;
			this._salesDateEd = salesDateEd;
			this._searchSlipDateSt = searchSlipDateSt;
			this._searchSlipDateEd = searchSlipDateEd;
			this._shipmentDaySt = shipmentDaySt;
			this._shipmentDayEd = shipmentDayEd;
			this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
			this._supplierCdSt = supplierCdSt;
			this._supplierCdEd = supplierCdEd;
			this._debitNoteDiv = debitNoteDiv;
			this._salesSlipCd = salesSlipCd;
			this._salesSlipNumSt = salesSlipNumSt;
			this._salesSlipNumEd = salesSlipNumEd;
			this._salesInputCodeSt = salesInputCodeSt;
			this._salesInputCodeEd = salesInputCodeEd;
			this._salesEmployeeCdSt = salesEmployeeCdSt;
			this._salesEmployeeCdEd = salesEmployeeCdEd;
			this._frontEmployeeCdSt = frontEmployeeCdSt;
			this._frontEmployeeCdEd = frontEmployeeCdEd;
			this._salesAreaCodeSt = salesAreaCodeSt;
			this._salesAreaCodeEd = salesAreaCodeEd;
			this._businessTypeCodeSt = businessTypeCodeSt;
			this._businessTypeCodeEd = businessTypeCodeEd;
			this._salesSlipUpdateCd = salesSlipUpdateCd;
			this._salesOrderDivCd = salesOrderDivCd;
			this._wayToOrder = wayToOrder;
			this._grsProfitCheckLower = grsProfitCheckLower;
            this._grossMarginSt = grossMarginSt;
            this._grossMargin2Ed = grossMargin2Ed;
            this._grossMargin3Ed = grossMargin3Ed;
            this._grsProfitCheckBest = grsProfitCheckBest;
			this._grsProfitCheckUpper = grsProfitCheckUpper;
			this._grossMargin1Mark = grossMargin1Mark;
			this._grossMargin2Mark = grossMargin2Mark;
			this._grossMargin3Mark = grossMargin3Mark;
			this._grossMargin4Mark = grossMargin4Mark;
			this._zeroSalesPrint = zeroSalesPrint;
			this._zeroCostPrint = zeroCostPrint;
			this._zeroGrsProfitPrint = zeroGrsProfitPrint;
			this._zeroUdrGrsProfitPrint = zeroUdrGrsProfitPrint;
			this._grsProfitRatePrint = grsProfitRatePrint;
			this._grsProfitRatePrintVal = grsProfitRatePrintVal;
			this._grsProfitRatePrintDiv = grsProfitRatePrintDiv;
            this._sortOrder = sortOrder;
            this._costOut = costOut;
            this._printDailyFooter = printDailyFooter; // ADD 2009/04/13
            this._newPageType = newPageType;
            this._enterpriseName = enterpriseName;
            // ADD START 3H ���� 2020/02/27 ------>>>>>
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;
            // ADD END 3H ���� 2020/02/27 ------<<<<<

		}

		/// <summary>
		/// ����m�F�\����������������
		/// </summary>
		/// <returns>ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note             :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
		/// </remarks>
        public ExtrInfo_MAHNB02347E Clone()
		{
            // return new ExtrInfo_MAHNB02347E(this._enterpriseCode, this._isSelectAllSection, this._resultsAddUpSecList, this._logicalDeleteCode, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._shipmentDaySt, this._shipmentDayEd, this._customerCodeSt, this._customerCodeEd, this._supplierCdSt, this._supplierCdEd, this._debitNoteDiv, this._salesSlipCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesInputCodeSt, this._salesInputCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._frontEmployeeCdSt, this._frontEmployeeCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._businessTypeCodeSt, this._businessTypeCodeEd, this._salesSlipUpdateCd, this._salesOrderDivCd, this._wayToOrder, this._grsProfitCheckLower, this._grossMarginSt, this._grossMargin2Ed, this._grossMargin3Ed, this._grsProfitCheckBest, this._grsProfitCheckUpper, this._grossMargin1Mark, this._grossMargin2Mark, this._grossMargin3Mark, this._grossMargin4Mark, this._zeroSalesPrint, this._zeroCostPrint, this._zeroGrsProfitPrint, this._zeroUdrGrsProfitPrint, this._grsProfitRatePrint, this._grsProfitRatePrintVal, this._grsProfitRatePrintDiv, this._sortOrder, this._costOut, this._printDailyFooter, this._newPageType, this._enterpriseName);  // DEL 3H ���� 2020/02/27
            return new ExtrInfo_MAHNB02347E(this._enterpriseCode, this._isSelectAllSection, this._resultsAddUpSecList, this._logicalDeleteCode, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._shipmentDaySt, this._shipmentDayEd, this._customerCodeSt, this._customerCodeEd, this._supplierCdSt, this._supplierCdEd, this._debitNoteDiv, this._salesSlipCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesInputCodeSt, this._salesInputCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._frontEmployeeCdSt, this._frontEmployeeCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._businessTypeCodeSt, this._businessTypeCodeEd, this._salesSlipUpdateCd, this._salesOrderDivCd, this._wayToOrder, this._grsProfitCheckLower, this._grossMarginSt, this._grossMargin2Ed, this._grossMargin3Ed, this._grsProfitCheckBest, this._grsProfitCheckUpper, this._grossMargin1Mark, this._grossMargin2Mark, this._grossMargin3Mark, this._grossMargin4Mark, this._zeroSalesPrint, this._zeroCostPrint, this._zeroGrsProfitPrint, this._zeroUdrGrsProfitPrint, this._grsProfitRatePrint, this._grsProfitRatePrintVal, this._grsProfitRatePrintDiv, this._sortOrder, this._costOut, this._printDailyFooter, this._newPageType, this._enterpriseName,this._taxPrintDiv,this._taxRate1,this._taxRate2);  // ADD 3H ���� 2020/02/27
		}

		/// <summary>
		/// ����m�F�\����������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAHNB02347E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note             :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
		/// </remarks>
        public bool Equals(ExtrInfo_MAHNB02347E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.ResultsAddUpSecList == target.ResultsAddUpSecList)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SalesDateSt == target.SalesDateSt)
				 && (this.SalesDateEd == target.SalesDateEd)
				 && (this.SearchSlipDateSt == target.SearchSlipDateSt)
				 && (this.SearchSlipDateEd == target.SearchSlipDateEd)
				 && (this.ShipmentDaySt == target.ShipmentDaySt)
				 && (this.ShipmentDayEd == target.ShipmentDayEd)
				 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
				 && (this.SupplierCdSt == target.SupplierCdSt)
				 && (this.SupplierCdEd == target.SupplierCdEd)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.SalesSlipCd == target.SalesSlipCd)
				 && (this.SalesSlipNumSt == target.SalesSlipNumSt)
				 && (this.SalesSlipNumEd == target.SalesSlipNumEd)
				 && (this.SalesInputCodeSt == target.SalesInputCodeSt)
				 && (this.SalesInputCodeEd == target.SalesInputCodeEd)
				 && (this.SalesEmployeeCdSt == target.SalesEmployeeCdSt)
				 && (this.SalesEmployeeCdEd == target.SalesEmployeeCdEd)
				 && (this.FrontEmployeeCdSt == target.FrontEmployeeCdSt)
				 && (this.FrontEmployeeCdEd == target.FrontEmployeeCdEd)
				 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
				 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
				 && (this.BusinessTypeCodeSt == target.BusinessTypeCodeSt)
				 && (this.BusinessTypeCodeEd == target.BusinessTypeCodeEd)
				 && (this.SalesSlipUpdateCd == target.SalesSlipUpdateCd)
				 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
				 && (this.WayToOrder == target.WayToOrder)
				 && (this.GrsProfitCheckLower == target.GrsProfitCheckLower)
                 && (this.GrossMarginSt == target.GrossMarginSt)
                 && (this.GrossMargin2Ed == target.GrossMargin2Ed)
                 && (this.GrossMargin3Ed == target.GrossMargin3Ed)
                 && (this.GrsProfitCheckBest == target.GrsProfitCheckBest)
				 && (this.GrsProfitCheckUpper == target.GrsProfitCheckUpper)
				 && (this.GrossMargin1Mark == target.GrossMargin1Mark)
				 && (this.GrossMargin2Mark == target.GrossMargin2Mark)
				 && (this.GrossMargin3Mark == target.GrossMargin3Mark)
				 && (this.GrossMargin4Mark == target.GrossMargin4Mark)
				 && (this.ZeroSalesPrint == target.ZeroSalesPrint)
				 && (this.ZeroCostPrint == target.ZeroCostPrint)
				 && (this.ZeroGrsProfitPrint == target.ZeroGrsProfitPrint)
				 && (this.ZeroUdrGrsProfitPrint == target.ZeroUdrGrsProfitPrint)
				 && (this.GrsProfitRatePrint == target.GrsProfitRatePrint)
				 && (this.GrsProfitRatePrintVal == target.GrsProfitRatePrintVal)
				 && (this.GrsProfitRatePrintDiv == target.GrsProfitRatePrintDiv)
                 && (this.SortOrder == target.SortOrder)
                 && (this.CostOut == target.CostOut)
                 && (this.PrintDailyFooter == target.PrintDailyFooter) // ADD 2009/04/13
                 && (this.NewPageType == target.NewPageType)
                 // ADD START 3H ���� 2020/02/27 ---->>>>>
                 && (this.TaxPrintDiv == target.TaxPrintDiv)
                 && (this.TaxRate1 == target.TaxRate1)
                 && (this.TaxRate2 == target.TaxRate2)
                // ADD END 3H ���� 2020/02/27 ----<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// ����m�F�\����������r����
		/// </summary>
        /// <param name="extrInfo_MAHNB02347E1">
		///                    ��r����ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X
		/// </param>
        /// <param name="extrInfo_MAHNB02347E2">��r����ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAHNB02347E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note             :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
		/// </remarks>
        public static bool Equals(ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E1, ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E2)
		{
			return ((extrInfo_MAHNB02347E1.EnterpriseCode == extrInfo_MAHNB02347E2.EnterpriseCode)
				 && (extrInfo_MAHNB02347E1.IsSelectAllSection == extrInfo_MAHNB02347E2.IsSelectAllSection)
				 && (extrInfo_MAHNB02347E1.ResultsAddUpSecList == extrInfo_MAHNB02347E2.ResultsAddUpSecList)
				 && (extrInfo_MAHNB02347E1.LogicalDeleteCode == extrInfo_MAHNB02347E2.LogicalDeleteCode)
				 && (extrInfo_MAHNB02347E1.SalesDateSt == extrInfo_MAHNB02347E2.SalesDateSt)
				 && (extrInfo_MAHNB02347E1.SalesDateEd == extrInfo_MAHNB02347E2.SalesDateEd)
				 && (extrInfo_MAHNB02347E1.SearchSlipDateSt == extrInfo_MAHNB02347E2.SearchSlipDateSt)
				 && (extrInfo_MAHNB02347E1.SearchSlipDateEd == extrInfo_MAHNB02347E2.SearchSlipDateEd)
				 && (extrInfo_MAHNB02347E1.ShipmentDaySt == extrInfo_MAHNB02347E2.ShipmentDaySt)
				 && (extrInfo_MAHNB02347E1.ShipmentDayEd == extrInfo_MAHNB02347E2.ShipmentDayEd)
				 && (extrInfo_MAHNB02347E1.CustomerCodeSt == extrInfo_MAHNB02347E2.CustomerCodeSt)
				 && (extrInfo_MAHNB02347E1.CustomerCodeEd == extrInfo_MAHNB02347E2.CustomerCodeEd)
				 && (extrInfo_MAHNB02347E1.SupplierCdSt == extrInfo_MAHNB02347E2.SupplierCdSt)
				 && (extrInfo_MAHNB02347E1.SupplierCdEd == extrInfo_MAHNB02347E2.SupplierCdEd)
				 && (extrInfo_MAHNB02347E1.DebitNoteDiv == extrInfo_MAHNB02347E2.DebitNoteDiv)
				 && (extrInfo_MAHNB02347E1.SalesSlipCd == extrInfo_MAHNB02347E2.SalesSlipCd)
				 && (extrInfo_MAHNB02347E1.SalesSlipNumSt == extrInfo_MAHNB02347E2.SalesSlipNumSt)
				 && (extrInfo_MAHNB02347E1.SalesSlipNumEd == extrInfo_MAHNB02347E2.SalesSlipNumEd)
				 && (extrInfo_MAHNB02347E1.SalesInputCodeSt == extrInfo_MAHNB02347E2.SalesInputCodeSt)
				 && (extrInfo_MAHNB02347E1.SalesInputCodeEd == extrInfo_MAHNB02347E2.SalesInputCodeEd)
				 && (extrInfo_MAHNB02347E1.SalesEmployeeCdSt == extrInfo_MAHNB02347E2.SalesEmployeeCdSt)
				 && (extrInfo_MAHNB02347E1.SalesEmployeeCdEd == extrInfo_MAHNB02347E2.SalesEmployeeCdEd)
				 && (extrInfo_MAHNB02347E1.FrontEmployeeCdSt == extrInfo_MAHNB02347E2.FrontEmployeeCdSt)
				 && (extrInfo_MAHNB02347E1.FrontEmployeeCdEd == extrInfo_MAHNB02347E2.FrontEmployeeCdEd)
				 && (extrInfo_MAHNB02347E1.SalesAreaCodeSt == extrInfo_MAHNB02347E2.SalesAreaCodeSt)
				 && (extrInfo_MAHNB02347E1.SalesAreaCodeEd == extrInfo_MAHNB02347E2.SalesAreaCodeEd)
				 && (extrInfo_MAHNB02347E1.BusinessTypeCodeSt == extrInfo_MAHNB02347E2.BusinessTypeCodeSt)
				 && (extrInfo_MAHNB02347E1.BusinessTypeCodeEd == extrInfo_MAHNB02347E2.BusinessTypeCodeEd)
				 && (extrInfo_MAHNB02347E1.SalesSlipUpdateCd == extrInfo_MAHNB02347E2.SalesSlipUpdateCd)
				 && (extrInfo_MAHNB02347E1.SalesOrderDivCd == extrInfo_MAHNB02347E2.SalesOrderDivCd)
				 && (extrInfo_MAHNB02347E1.WayToOrder == extrInfo_MAHNB02347E2.WayToOrder)
				 && (extrInfo_MAHNB02347E1.GrsProfitCheckLower == extrInfo_MAHNB02347E2.GrsProfitCheckLower)
                 && (extrInfo_MAHNB02347E1.GrossMarginSt == extrInfo_MAHNB02347E2.GrossMarginSt)
                 && (extrInfo_MAHNB02347E1.GrossMargin2Ed == extrInfo_MAHNB02347E2.GrossMargin2Ed)
                 && (extrInfo_MAHNB02347E1.GrossMargin3Ed == extrInfo_MAHNB02347E2.GrossMargin3Ed)
                 && (extrInfo_MAHNB02347E1.GrsProfitCheckBest == extrInfo_MAHNB02347E2.GrsProfitCheckBest)
				 && (extrInfo_MAHNB02347E1.GrsProfitCheckUpper == extrInfo_MAHNB02347E2.GrsProfitCheckUpper)
				 && (extrInfo_MAHNB02347E1.GrossMargin1Mark == extrInfo_MAHNB02347E2.GrossMargin1Mark)
				 && (extrInfo_MAHNB02347E1.GrossMargin2Mark == extrInfo_MAHNB02347E2.GrossMargin2Mark)
				 && (extrInfo_MAHNB02347E1.GrossMargin3Mark == extrInfo_MAHNB02347E2.GrossMargin3Mark)
				 && (extrInfo_MAHNB02347E1.GrossMargin4Mark == extrInfo_MAHNB02347E2.GrossMargin4Mark)
				 && (extrInfo_MAHNB02347E1.ZeroSalesPrint == extrInfo_MAHNB02347E2.ZeroSalesPrint)
				 && (extrInfo_MAHNB02347E1.ZeroCostPrint == extrInfo_MAHNB02347E2.ZeroCostPrint)
				 && (extrInfo_MAHNB02347E1.ZeroGrsProfitPrint == extrInfo_MAHNB02347E2.ZeroGrsProfitPrint)
				 && (extrInfo_MAHNB02347E1.ZeroUdrGrsProfitPrint == extrInfo_MAHNB02347E2.ZeroUdrGrsProfitPrint)
				 && (extrInfo_MAHNB02347E1.GrsProfitRatePrint == extrInfo_MAHNB02347E2.GrsProfitRatePrint)
				 && (extrInfo_MAHNB02347E1.GrsProfitRatePrintVal == extrInfo_MAHNB02347E2.GrsProfitRatePrintVal)
				 && (extrInfo_MAHNB02347E1.GrsProfitRatePrintDiv == extrInfo_MAHNB02347E2.GrsProfitRatePrintDiv)
                 && (extrInfo_MAHNB02347E1.SortOrder == extrInfo_MAHNB02347E2.SortOrder)
                 && (extrInfo_MAHNB02347E1.CostOut == extrInfo_MAHNB02347E2.CostOut)
                 && (extrInfo_MAHNB02347E1.PrintDailyFooter == extrInfo_MAHNB02347E2.PrintDailyFooter) // ADD 2009/04/13
                 && (extrInfo_MAHNB02347E1.NewPageType == extrInfo_MAHNB02347E2.NewPageType)                 
                 // ADD START 3H ���� 2020/02/27 ---->>>>>
                 && (extrInfo_MAHNB02347E1.TaxPrintDiv == extrInfo_MAHNB02347E2.TaxPrintDiv)
                 && (extrInfo_MAHNB02347E1.TaxRate1 == extrInfo_MAHNB02347E2.TaxRate1)
                 && (extrInfo_MAHNB02347E1.TaxRate2 == extrInfo_MAHNB02347E2.TaxRate2)
                // ADD END 3H ���� 2020/02/27 ----<<<<<

                 && (extrInfo_MAHNB02347E1.EnterpriseName == extrInfo_MAHNB02347E2.EnterpriseName));
		}
		/// <summary>
		/// ����m�F�\����������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAHNB02347E�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note             :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
		/// </remarks>
        public ArrayList Compare(ExtrInfo_MAHNB02347E target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SalesDateSt != target.SalesDateSt)resList.Add("SalesDateSt");
			if(this.SalesDateEd != target.SalesDateEd)resList.Add("SalesDateEd");
			if(this.SearchSlipDateSt != target.SearchSlipDateSt)resList.Add("SearchSlipDateSt");
			if(this.SearchSlipDateEd != target.SearchSlipDateEd)resList.Add("SearchSlipDateEd");
			if(this.ShipmentDaySt != target.ShipmentDaySt)resList.Add("ShipmentDaySt");
			if(this.ShipmentDayEd != target.ShipmentDayEd)resList.Add("ShipmentDayEd");
			if(this.CustomerCodeSt != target.CustomerCodeSt)resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
			if(this.SupplierCdSt != target.SupplierCdSt)resList.Add("SupplierCdSt");
			if(this.SupplierCdEd != target.SupplierCdEd)resList.Add("SupplierCdEd");
			if(this.DebitNoteDiv != target.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(this.SalesSlipCd != target.SalesSlipCd)resList.Add("SalesSlipCd");
			if(this.SalesSlipNumSt != target.SalesSlipNumSt)resList.Add("SalesSlipNumSt");
			if(this.SalesSlipNumEd != target.SalesSlipNumEd)resList.Add("SalesSlipNumEd");
			if(this.SalesInputCodeSt != target.SalesInputCodeSt)resList.Add("SalesInputCodeSt");
			if(this.SalesInputCodeEd != target.SalesInputCodeEd)resList.Add("SalesInputCodeEd");
			if(this.SalesEmployeeCdSt != target.SalesEmployeeCdSt)resList.Add("SalesEmployeeCdSt");
			if(this.SalesEmployeeCdEd != target.SalesEmployeeCdEd)resList.Add("SalesEmployeeCdEd");
			if(this.FrontEmployeeCdSt != target.FrontEmployeeCdSt)resList.Add("FrontEmployeeCdSt");
			if(this.FrontEmployeeCdEd != target.FrontEmployeeCdEd)resList.Add("FrontEmployeeCdEd");
			if(this.SalesAreaCodeSt != target.SalesAreaCodeSt)resList.Add("SalesAreaCodeSt");
			if(this.SalesAreaCodeEd != target.SalesAreaCodeEd)resList.Add("SalesAreaCodeEd");
			if(this.BusinessTypeCodeSt != target.BusinessTypeCodeSt)resList.Add("BusinessTypeCodeSt");
			if(this.BusinessTypeCodeEd != target.BusinessTypeCodeEd)resList.Add("BusinessTypeCodeEd");
			if(this.SalesSlipUpdateCd != target.SalesSlipUpdateCd)resList.Add("SalesSlipUpdateCd");
			if(this.SalesOrderDivCd != target.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(this.WayToOrder != target.WayToOrder)resList.Add("WayToOrder");
			if(this.GrsProfitCheckLower != target.GrsProfitCheckLower)resList.Add("GrsProfitCheckLower");
            if (this.GrossMarginSt != target.GrossMarginSt) resList.Add("GrossMarginSt");
            if (this.GrossMargin2Ed != target.GrossMargin2Ed) resList.Add("GrossMargin2Ed");
            if (this.GrossMargin3Ed != target.GrossMargin3Ed) resList.Add("GrossMargin3Ed");
            if (this.GrsProfitCheckBest != target.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if(this.GrsProfitCheckUpper != target.GrsProfitCheckUpper)resList.Add("GrsProfitCheckUpper");
			if(this.GrossMargin1Mark != target.GrossMargin1Mark)resList.Add("GrossMargin1Mark");
			if(this.GrossMargin2Mark != target.GrossMargin2Mark)resList.Add("GrossMargin2Mark");
			if(this.GrossMargin3Mark != target.GrossMargin3Mark)resList.Add("GrossMargin3Mark");
			if(this.GrossMargin4Mark != target.GrossMargin4Mark)resList.Add("GrossMargin4Mark");
			if(this.ZeroSalesPrint != target.ZeroSalesPrint)resList.Add("ZeroSalesPrint");
			if(this.ZeroCostPrint != target.ZeroCostPrint)resList.Add("ZeroCostPrint");
			if(this.ZeroGrsProfitPrint != target.ZeroGrsProfitPrint)resList.Add("ZeroGrsProfitPrint");
			if(this.ZeroUdrGrsProfitPrint != target.ZeroUdrGrsProfitPrint)resList.Add("ZeroUdrGrsProfitPrint");
			if(this.GrsProfitRatePrint != target.GrsProfitRatePrint)resList.Add("GrsProfitRatePrint");
			if(this.GrsProfitRatePrintVal != target.GrsProfitRatePrintVal)resList.Add("GrsProfitRatePrintVal");
			if(this.GrsProfitRatePrintDiv != target.GrsProfitRatePrintDiv)resList.Add("GrsProfitRatePrintDiv");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
            if (this.CostOut != target.CostOut) resList.Add("CostOut");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/13
            if (this.NewPageType != target.NewPageType) resList.Add("NewPageType");
            // ADD START 3H ���� 2020/02/27 ---->>>>>
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
            // ADD END 3H ���� 2020/02/27 ----<<<<<
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// ����m�F�\����������r����
		/// </summary>
        /// <param name="extrInfo_MAHNB02347E1">��r����ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</param>
        /// <param name="extrInfo_MAHNB02347E2">��r����ExtrInfo_MAHNB02347E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAHNB02347E�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note             :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
		/// </remarks>
        public static ArrayList Compare(ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E1, ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_MAHNB02347E1.EnterpriseCode != extrInfo_MAHNB02347E2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_MAHNB02347E1.IsSelectAllSection != extrInfo_MAHNB02347E2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(extrInfo_MAHNB02347E1.ResultsAddUpSecList != extrInfo_MAHNB02347E2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(extrInfo_MAHNB02347E1.LogicalDeleteCode != extrInfo_MAHNB02347E2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(extrInfo_MAHNB02347E1.SalesDateSt != extrInfo_MAHNB02347E2.SalesDateSt)resList.Add("SalesDateSt");
			if(extrInfo_MAHNB02347E1.SalesDateEd != extrInfo_MAHNB02347E2.SalesDateEd)resList.Add("SalesDateEd");
			if(extrInfo_MAHNB02347E1.SearchSlipDateSt != extrInfo_MAHNB02347E2.SearchSlipDateSt)resList.Add("SearchSlipDateSt");
			if(extrInfo_MAHNB02347E1.SearchSlipDateEd != extrInfo_MAHNB02347E2.SearchSlipDateEd)resList.Add("SearchSlipDateEd");
			if(extrInfo_MAHNB02347E1.ShipmentDaySt != extrInfo_MAHNB02347E2.ShipmentDaySt)resList.Add("ShipmentDaySt");
			if(extrInfo_MAHNB02347E1.ShipmentDayEd != extrInfo_MAHNB02347E2.ShipmentDayEd)resList.Add("ShipmentDayEd");
			if(extrInfo_MAHNB02347E1.CustomerCodeSt != extrInfo_MAHNB02347E2.CustomerCodeSt)resList.Add("CustomerCodeSt");
			if(extrInfo_MAHNB02347E1.CustomerCodeEd != extrInfo_MAHNB02347E2.CustomerCodeEd)resList.Add("CustomerCodeEd");
			if(extrInfo_MAHNB02347E1.SupplierCdSt != extrInfo_MAHNB02347E2.SupplierCdSt)resList.Add("SupplierCdSt");
			if(extrInfo_MAHNB02347E1.SupplierCdEd != extrInfo_MAHNB02347E2.SupplierCdEd)resList.Add("SupplierCdEd");
			if(extrInfo_MAHNB02347E1.DebitNoteDiv != extrInfo_MAHNB02347E2.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(extrInfo_MAHNB02347E1.SalesSlipCd != extrInfo_MAHNB02347E2.SalesSlipCd)resList.Add("SalesSlipCd");
			if(extrInfo_MAHNB02347E1.SalesSlipNumSt != extrInfo_MAHNB02347E2.SalesSlipNumSt)resList.Add("SalesSlipNumSt");
			if(extrInfo_MAHNB02347E1.SalesSlipNumEd != extrInfo_MAHNB02347E2.SalesSlipNumEd)resList.Add("SalesSlipNumEd");
			if(extrInfo_MAHNB02347E1.SalesInputCodeSt != extrInfo_MAHNB02347E2.SalesInputCodeSt)resList.Add("SalesInputCodeSt");
			if(extrInfo_MAHNB02347E1.SalesInputCodeEd != extrInfo_MAHNB02347E2.SalesInputCodeEd)resList.Add("SalesInputCodeEd");
			if(extrInfo_MAHNB02347E1.SalesEmployeeCdSt != extrInfo_MAHNB02347E2.SalesEmployeeCdSt)resList.Add("SalesEmployeeCdSt");
			if(extrInfo_MAHNB02347E1.SalesEmployeeCdEd != extrInfo_MAHNB02347E2.SalesEmployeeCdEd)resList.Add("SalesEmployeeCdEd");
			if(extrInfo_MAHNB02347E1.FrontEmployeeCdSt != extrInfo_MAHNB02347E2.FrontEmployeeCdSt)resList.Add("FrontEmployeeCdSt");
			if(extrInfo_MAHNB02347E1.FrontEmployeeCdEd != extrInfo_MAHNB02347E2.FrontEmployeeCdEd)resList.Add("FrontEmployeeCdEd");
			if(extrInfo_MAHNB02347E1.SalesAreaCodeSt != extrInfo_MAHNB02347E2.SalesAreaCodeSt)resList.Add("SalesAreaCodeSt");
			if(extrInfo_MAHNB02347E1.SalesAreaCodeEd != extrInfo_MAHNB02347E2.SalesAreaCodeEd)resList.Add("SalesAreaCodeEd");
			if(extrInfo_MAHNB02347E1.BusinessTypeCodeSt != extrInfo_MAHNB02347E2.BusinessTypeCodeSt)resList.Add("BusinessTypeCodeSt");
			if(extrInfo_MAHNB02347E1.BusinessTypeCodeEd != extrInfo_MAHNB02347E2.BusinessTypeCodeEd)resList.Add("BusinessTypeCodeEd");
			if(extrInfo_MAHNB02347E1.SalesSlipUpdateCd != extrInfo_MAHNB02347E2.SalesSlipUpdateCd)resList.Add("SalesSlipUpdateCd");
			if(extrInfo_MAHNB02347E1.SalesOrderDivCd != extrInfo_MAHNB02347E2.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(extrInfo_MAHNB02347E1.WayToOrder != extrInfo_MAHNB02347E2.WayToOrder)resList.Add("WayToOrder");
			if(extrInfo_MAHNB02347E1.GrsProfitCheckLower != extrInfo_MAHNB02347E2.GrsProfitCheckLower)resList.Add("GrsProfitCheckLower");
            if (extrInfo_MAHNB02347E1.GrossMarginSt != extrInfo_MAHNB02347E2.GrossMarginSt) resList.Add("GrossMarginSt");
            if (extrInfo_MAHNB02347E1.GrossMargin2Ed != extrInfo_MAHNB02347E2.GrossMargin2Ed) resList.Add("GrossMargin2Ed");
            if (extrInfo_MAHNB02347E1.GrossMargin3Ed != extrInfo_MAHNB02347E2.GrossMargin3Ed) resList.Add("GrossMargin3Ed");
            if (extrInfo_MAHNB02347E1.GrsProfitCheckBest != extrInfo_MAHNB02347E2.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if(extrInfo_MAHNB02347E1.GrsProfitCheckUpper != extrInfo_MAHNB02347E2.GrsProfitCheckUpper)resList.Add("GrsProfitCheckUpper");
			if(extrInfo_MAHNB02347E1.GrossMargin1Mark != extrInfo_MAHNB02347E2.GrossMargin1Mark)resList.Add("GrossMargin1Mark");
			if(extrInfo_MAHNB02347E1.GrossMargin2Mark != extrInfo_MAHNB02347E2.GrossMargin2Mark)resList.Add("GrossMargin2Mark");
			if(extrInfo_MAHNB02347E1.GrossMargin3Mark != extrInfo_MAHNB02347E2.GrossMargin3Mark)resList.Add("GrossMargin3Mark");
			if(extrInfo_MAHNB02347E1.GrossMargin4Mark != extrInfo_MAHNB02347E2.GrossMargin4Mark)resList.Add("GrossMargin4Mark");
			if(extrInfo_MAHNB02347E1.ZeroSalesPrint != extrInfo_MAHNB02347E2.ZeroSalesPrint)resList.Add("ZeroSalesPrint");
			if(extrInfo_MAHNB02347E1.ZeroCostPrint != extrInfo_MAHNB02347E2.ZeroCostPrint)resList.Add("ZeroCostPrint");
			if(extrInfo_MAHNB02347E1.ZeroGrsProfitPrint != extrInfo_MAHNB02347E2.ZeroGrsProfitPrint)resList.Add("ZeroGrsProfitPrint");
			if(extrInfo_MAHNB02347E1.ZeroUdrGrsProfitPrint != extrInfo_MAHNB02347E2.ZeroUdrGrsProfitPrint)resList.Add("ZeroUdrGrsProfitPrint");
			if(extrInfo_MAHNB02347E1.GrsProfitRatePrint != extrInfo_MAHNB02347E2.GrsProfitRatePrint)resList.Add("GrsProfitRatePrint");
			if(extrInfo_MAHNB02347E1.GrsProfitRatePrintVal != extrInfo_MAHNB02347E2.GrsProfitRatePrintVal)resList.Add("GrsProfitRatePrintVal");
			if(extrInfo_MAHNB02347E1.GrsProfitRatePrintDiv != extrInfo_MAHNB02347E2.GrsProfitRatePrintDiv)resList.Add("GrsProfitRatePrintDiv");
            if (extrInfo_MAHNB02347E1.SortOrder != extrInfo_MAHNB02347E2.SortOrder) resList.Add("SortOrder");
            if (extrInfo_MAHNB02347E1.CostOut != extrInfo_MAHNB02347E2.CostOut) resList.Add("CostOut");
            if (extrInfo_MAHNB02347E1.PrintDailyFooter != extrInfo_MAHNB02347E2.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/13
            if (extrInfo_MAHNB02347E1.NewPageType != extrInfo_MAHNB02347E2.NewPageType) resList.Add("NewPageType");
            // ADD START 3H ���� 2020/02/27 ---->>>>>
            if (extrInfo_MAHNB02347E1.TaxPrintDiv != extrInfo_MAHNB02347E2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (extrInfo_MAHNB02347E1.TaxRate1 != extrInfo_MAHNB02347E2.TaxRate1) resList.Add("TaxRate1");
            if (extrInfo_MAHNB02347E1.TaxRate2 != extrInfo_MAHNB02347E2.TaxRate2) resList.Add("TaxRate2");
            // ADD END 3H ���� 2020/02/27 ----<<<<<            
            if (extrInfo_MAHNB02347E1.EnterpriseName != extrInfo_MAHNB02347E2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}
	}
}

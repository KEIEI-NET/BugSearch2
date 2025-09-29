//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���m�F�\
// �v���O�����T�v   : �d���m�F�\���o�����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2008/01/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �C �� ��  2008/07/16  �C�����e : �f�[�^���ڂ̒ǉ�/�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/14  �C�����e : ��Q�Ή�12394,12396,12401
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : cheq
// �C �� ��  2012/12/26  �C�����e : 2013/03/13�z�M�� Redmine#34098
//                                  �r���󎚐���̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11570208-00  �쐬�S�� : 3H ����
// �C �� ��  2020/02/27  �C�����e : �y���ŗ��Ή�
//                                  �ŕʓ���󎚐���̒ǉ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_MAKON02247E
	/// <summary>
	///                      �d���m�F�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���m�F�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/01/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	     :   �E�f�[�^���ڂ̒ǉ�/�C��</br>
    /// <br>Programmer	     :   30415 �ēc �ύK</br>
    /// <br>Date		     :   2008/07/16</br>
    /// -----------------------------------------------------------------------------------	
    /// <br>UpdateNote	     :   �E��Q�Ή�12394,12396,12401</br>
    /// <br>Programmer	     :   30452 ��� �r��</br>
    /// <br>Date		     :   2009/04/14</br>
    /// -----------------------------------------------------------------------------------	
    /// <br>Update Note      :   2012/12/26 cheq</br>
    /// <br>�Ǘ��ԍ�         :   10806793-00 2013/03/13�z�M��</br>
    /// <br>                     Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
    /// -----------------------------------------------------------------------------------	
    /// <br>Update Note      :  11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :  3H ���� </br>
    /// <br>Date		     :  2020/02/27</br>
    /// -----------------------------------------------------------------------------------	
    /// </remarks>
	public class ExtrInfo_MAKON02247E
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�S�БI��</summary>
		/// <remarks>true:�S�БI���@false:�e���_�I��</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>�S���_���R�[�h�o��</summary>
		/// <remarks>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</remarks>
		private Boolean _isOutputAllSecRec;

		/// <summary>�d�����_�R�[�h</summary>
		/// <remarks>�����^�@���z�񍀖�</remarks>
		private string[] _stockSectionCd;

		/// <summary>�d����(�J�n)</summary>
		/// <remarks>YYYYMMDD �����͎��� 0</remarks>
		private Int32 _stockDateSt;

		/// <summary>�d����(�I��)</summary>
		/// <remarks>YYYYMMDD �����͎��� 0</remarks>
		private Int32 _stockDateEd;

		/// <summary>���ד�(�J�n)</summary>
		/// <remarks>YYYYMMDD �����͎��� 0</remarks>
		private Int32 _arrivalGoodsDaySt;

		/// <summary>���ד�(�I��)</summary>
		/// <remarks>YYYYMMDD �����͎��� 0</remarks>
		private Int32 _arrivalGoodsDayEd;

		/// <summary>���͓�(�J�n)</summary>
		/// <remarks>YYYYMMDD �����͎��� 0</remarks>
		private Int32 _inputDaySt;

		/// <summary>���͓�(�I��)</summary>
		/// <remarks>YYYYMMDD �����͎��� 0</remarks>
		private Int32 _inputDayEd;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:�ʏ� 1:���� 2:�폜 3:����+�폜</remarks>
		private Int32 _printType;

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>-1:�S�� 0:���` 1:�ԓ` 2:����</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>�d���`��</summary>
		/// <remarks>0:���� 1:�d�� 2:���d��</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d���`�[�ԍ�(�J�n)</summary>
		/// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���d���`�[�ԍ������˂�</remarks>
		private Int32 _supplierSlipNoSt;

		/// <summary>�d���`�[�ԍ�(�I��)</summary>
		/// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���d���`�[�ԍ������˂�</remarks>
		private Int32 _supplierSlipNoEd;

		/// <summary>�d���S���҃R�[�h(�J�n)</summary>
		/// <remarks>�����͎��͋󕶎�("")</remarks>
		private string _stockAgentCodeSt = "";

		/// <summary>�d���S���҃R�[�h(�I��)</summary>
		/// <remarks>�����͎��͋󕶎�("")</remarks>
		private string _stockAgentCodeEd = "";

		/// <summary>�d���`�[�敪</summary>
		/// <remarks>0:�S�� 10:�d�� 20:�ԕi</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>�����`�[�ԍ�(�J�n)</summary>
		/// <remarks>�����͎��͋󕶎�("")</remarks>
		private string _partySaleSlipNumSt = "";

		/// <summary>�����`�[�ԍ�(�I��)</summary>
		/// <remarks>�����͎��͋󕶎�("")</remarks>
		private string _partySaleSlipNumEd = "";

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h(�J�n)</summary>
        //private Int32 _customerCodeSt;

        ///// <summary>���Ӑ�R�[�h(�I��)</summary>
        //private Int32 _customerCodeEd;
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�d����R�[�h(�J�n)</summary>
        private Int32 _supplierCdSt;

        /// <summary>�d����R�[�h(�I��)</summary>
        private Int32 _supplierCdEd;

        /// <summary>�̔��G���A�R�[�h(�J�n)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>�̔��G���A�R�[�h(�I��)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>�o�͎w��</summary>
        private Int32 _outputDesignated;

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        private Int32 _stockOrderDivCd;

        /// <summary>���ŋ敪</summary>
        private Int32 _newPageKind;
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>�o�͏�</summary>
		private Int32 _sortOrder;

		/// <summary>���[�^�C�v����</summary>
		private Int32 _printDiv;

		/// <summary>���[�^�C�v�̎��ʖ���</summary>
		private string _printDivName = "";

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�d���v�㋒�_����</summary>
		private string _stockAddUpSectionNm = "";

        // --- ADD 2009/04/14 -------------------------------->>>>>
        private Int32 _printDailyFooter;
        // --- ADD 2009/04/14 --------------------------------<<<<<

        //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>
        /// <summary>�r����</summary>
        private Int32 _linePrintDiv;
        //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        private Int32 _taxPrintDiv;

        /// <summary>XML�̐ŗ��P</summary>
        private string _taxRate1;

        /// <summary>XML�̐ŗ��P</summary>
        private string _taxRate2;

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
        /// <summary>XML�̐ŗ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   XML�̐ŗ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>XML�̐ŗ��Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   XML�̐ŗ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>�S�БI���v���p�e�B</summary>
		/// <value>true:�S�БI���@false:�e���_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S�БI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsSelectAllSection
		{
			get { return _isSelectAllSection; }
			set { _isSelectAllSection = value; }
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
		/// <value>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���_���R�[�h�o�̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsOutputAllSecRec
		{
			get { return _isOutputAllSecRec; }
			set { _isOutputAllSecRec = value; }
		}

		/// public propaty name  :  StockSectionCd
		/// <summary>�d�����_�R�[�h�v���p�e�B</summary>
		/// <value>�����^�@���z�񍀖�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] StockSectionCd
		{
			get { return _stockSectionCd; }
			set { _stockSectionCd = value; }
		}

		/// public propaty name  :  StockDateSt
		/// <summary>�d����(�J�n)�v���p�e�B</summary>
		/// <value>YYYYMMDD �����͎��� 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get { return _stockDateSt; }
			set { _stockDateSt = value; }
		}

		/// public propaty name  :  StockDateEd
		/// <summary>�d����(�I��)�v���p�e�B</summary>
		/// <value>YYYYMMDD �����͎��� 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get { return _stockDateEd; }
			set { _stockDateEd = value; }
		}

		/// public propaty name  :  ArrivalGoodsDaySt
		/// <summary>���ד�(�J�n)�v���p�e�B</summary>
		/// <value>YYYYMMDD �����͎��� 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ד�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ArrivalGoodsDaySt
		{
			get { return _arrivalGoodsDaySt; }
			set { _arrivalGoodsDaySt = value; }
		}

		/// public propaty name  :  ArrivalGoodsDayEd
		/// <summary>���ד�(�I��)�v���p�e�B</summary>
		/// <value>YYYYMMDD �����͎��� 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ד�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ArrivalGoodsDayEd
		{
			get { return _arrivalGoodsDayEd; }
			set { _arrivalGoodsDayEd = value; }
		}

		/// public propaty name  :  InputDaySt
		/// <summary>���͓�(�J�n)�v���p�e�B</summary>
		/// <value>YYYYMMDD �����͎��� 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get { return _inputDaySt; }
			set { _inputDaySt = value; }
		}

		/// public propaty name  :  InputDayEd
		/// <summary>���͓�(�I��)�v���p�e�B</summary>
		/// <value>YYYYMMDD �����͎��� 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get { return _inputDayEd; }
			set { _inputDayEd = value; }
		}

		/// public propaty name  :  PrintType
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:�ʏ� 1:���� 2:�폜 3:����+�폜</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintType
		{
			get { return _printType; }
			set { _printType = value; }
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>�ԓ`�敪�v���p�e�B</summary>
		/// <value>-1:�S�� 0:���` 1:�ԓ` 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԓ`�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get { return _debitNoteDiv; }
			set { _debitNoteDiv = value; }
		}

		/// public propaty name  :  SupplierFormal
		/// <summary>�d���`���v���p�e�B</summary>
		/// <value>0:���� 1:�d�� 2:���d��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormal
		{
			get { return _supplierFormal; }
			set { _supplierFormal = value; }
		}

		/// public propaty name  :  SupplierSlipNoSt
		/// <summary>�d���`�[�ԍ�(�J�n)�v���p�e�B</summary>
		/// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���d���`�[�ԍ������˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�ԍ�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNoSt
		{
			get { return _supplierSlipNoSt; }
			set { _supplierSlipNoSt = value; }
		}

		/// public propaty name  :  SupplierSlipNoEd
		/// <summary>�d���`�[�ԍ�(�I��)�v���p�e�B</summary>
		/// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���d���`�[�ԍ������˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�ԍ�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNoEd
		{
			get { return _supplierSlipNoEd; }
			set { _supplierSlipNoEd = value; }
		}

		/// public propaty name  :  StockAgentCodeSt
		/// <summary>�d���S���҃R�[�h(�J�n)�v���p�e�B</summary>
		/// <value>�����͎��͋󕶎�("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���҃R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCodeSt
		{
			get { return _stockAgentCodeSt; }
			set { _stockAgentCodeSt = value; }
		}

		/// public propaty name  :  StockAgentCodeEd
		/// <summary>�d���S���҃R�[�h(�I��)�v���p�e�B</summary>
		/// <value>�����͎��͋󕶎�("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���҃R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCodeEd
		{
			get { return _stockAgentCodeEd; }
			set { _stockAgentCodeEd = value; }
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>�d���`�[�敪�v���p�e�B</summary>
		/// <value>0:�S�� 10:�d�� 20:�ԕi</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get { return _supplierSlipCd; }
			set { _supplierSlipCd = value; }
		}

		/// public propaty name  :  PartySaleSlipNumSt
		/// <summary>�����`�[�ԍ�(�J�n)�v���p�e�B</summary>
		/// <value>�����͎��͋󕶎�("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySaleSlipNumSt
		{
			get { return _partySaleSlipNumSt; }
			set { _partySaleSlipNumSt = value; }
		}

		/// public propaty name  :  PartySaleSlipNumEd
		/// <summary>�����`�[�ԍ�(�I��)�v���p�e�B</summary>
		/// <value>�����͎��͋󕶎�("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySaleSlipNumEd
		{
			get { return _partySaleSlipNumEd; }
			set { _partySaleSlipNumEd = value; }
		}

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// public propaty name  :  CustomerCodeSt
        ///// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustomerCodeSt
        //{
        //    get { return _customerCodeSt; }
        //    set { _customerCodeSt = value; }
        //}

        ///// public propaty name  :  CustomerCodeEd
        ///// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustomerCodeEd
        //{
        //    get { return _customerCodeEd; }
        //    set { _customerCodeEd = value; }
        //}
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// public propaty name  :  SupplierCdSt
        /// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>�̔��G���A�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>�̔��G���A�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  OutputDesignated
        /// <summary>�o�͎w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w��v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 OutputDesignated
        {
            get { return _outputDesignated; }
            set { _outputDesignated = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  NewPageKind
        /// <summary>���ŋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ŋ敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 NewPageKind
        {
            get { return _newPageKind; }
            set { _newPageKind = value; }
        }
        // --- ADD 2008/07/16 --------------------------------<<<<< 

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

		/// public propaty name  :  PrintDiv
		/// <summary>���[�^�C�v���ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�^�C�v���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get { return _printDiv; }
			set { _printDiv = value; }
		}

		/// public propaty name  :  PrintDivName
		/// <summary>���[�^�C�v�̎��ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�^�C�v�̎��ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrintDivName
		{
			get { return _printDivName; }
			set { _printDivName = value; }
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

		/// public propaty name  :  StockAddUpSectionNm
		/// <summary>�d���v�㋒�_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���v�㋒�_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAddUpSectionNm
		{
			get { return _stockAddUpSectionNm; }
			set { _stockAddUpSectionNm = value; }
		}

        // --- ADD 2009/04/14 -------------------------------->>>>>
        /// public propaty name  :  PrintDailyFooter
        /// <summary>���v�󎚃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�󎚃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }
        // --- ADD 2009/04/14 --------------------------------<<<<<

        //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>
        /// public propaty name  :  LinePrintDiv
        /// <summary>�r���󎚃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���󎚃v���p�e�B</br>
        /// <br>Programer        :   cheq</br>
        /// <br>Date	         :   2012/12/26</br>
        /// </remarks>
        public Int32 LinePrintDiv
        {
            get { return _linePrintDiv; }
            set { _linePrintDiv = value; }
        }
        //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<

		/// <summary>
		/// �d���m�F�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAKON02247E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_MAKON02247E()
		{
		}

		/// <summary>
		/// �d���m�F�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI���@false:�e���_�I��)</param>
		/// <param name="isOutputAllSecRec">�S���_���R�[�h�o��(true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�)</param>
		/// <param name="stockSectionCd">�d�����_�R�[�h(�����^�@���z�񍀖�)</param>
		/// <param name="stockDateSt">�d����(�J�n)(YYYYMMDD �����͎��� 0)</param>
		/// <param name="stockDateEd">�d����(�I��)(YYYYMMDD �����͎��� 0)</param>
		/// <param name="arrivalGoodsDaySt">���ד�(�J�n)(YYYYMMDD �����͎��� 0)</param>
		/// <param name="arrivalGoodsDayEd">���ד�(�I��)(YYYYMMDD �����͎��� 0)</param>
		/// <param name="inputDaySt">���͓�(�J�n)(YYYYMMDD �����͎��� 0)</param>
		/// <param name="inputDayEd">���͓�(�I��)(YYYYMMDD �����͎��� 0)</param>
		/// <param name="printType">���s�^�C�v(0:�ʏ� 1:���� 2:�폜 3:����+�폜)</param>
		/// <param name="debitNoteDiv">�ԓ`�敪(-1:�S�� 0:���` 1:�ԓ` 2:����)</param>
		/// <param name="supplierFormal">�d���`��(0:���� 1:�d�� 2:���d��)</param>
		/// <param name="supplierSlipNoSt">�d���`�[�ԍ�(�J�n)(�����`�[�ԍ��A�d���`�[�ԍ��A���d���`�[�ԍ������˂�)</param>
		/// <param name="supplierSlipNoEd">�d���`�[�ԍ�(�I��)(�����`�[�ԍ��A�d���`�[�ԍ��A���d���`�[�ԍ������˂�)</param>
		/// <param name="stockAgentCodeSt">�d���S���҃R�[�h(�J�n)(�����͎��͋󕶎�(""))</param>
		/// <param name="stockAgentCodeEd">�d���S���҃R�[�h(�I��)(�����͎��͋󕶎�(""))</param>
		/// <param name="supplierSlipCd">�d���`�[�敪(0:�S�� 10:�d�� 20:�ԕi)</param>
		/// <param name="partySaleSlipNumSt">�����`�[�ԍ�(�J�n)(�����͎��͋󕶎�(""))</param>
		/// <param name="partySaleSlipNumEd">�����`�[�ԍ�(�I��)(�����͎��͋󕶎�(""))</param>
        /// <param name="customerCodeSt">�d����R�[�h(�J�n)</param>
        /// <param name="customerCodeEd">�d����R�[�h(�I��)</param>
        /// <param name="SalesAreaCodeSt">�̔��G���A�R�[�h(�J�n)</param>
        /// <param name="SalesAreaCodeEd">�̔��G���A�R�[�h(�I��)</param>		
        /// <param name="SalesAreaCodeSt">�o�͎w��</param>
        /// <param name="SalesAreaCodeEd">�d���݌Ɏ�񂹋敪</param>	        
        /// <param name="sortOrder">�o�͏�</param>
		/// <param name="printDiv">���[�^�C�v����</param>
		/// <param name="printDivName">���[�^�C�v�̎��ʖ���</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="stockAddUpSectionNm">�d���v�㋒�_����</param>
        /// <param name="printDailyFooter">���v��</param>
		/// <returns>ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAKON02247E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        //public ExtrInfo_MAKON02247E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] stockSectionCd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 inputDaySt, Int32 inputDayEd, Int32 printType, Int32 debitNoteDiv, Int32 supplierFormal, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipCd, string partySaleSlipNumSt, string partySaleSlipNumEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 sortOrder, Int32 printDiv, string printDivName, string enterpriseName, string stockAddUpSectionNm)  // DEL 2008/07/16
        //public ExtrInfo_MAKON02247E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] stockSectionCd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 inputDaySt, Int32 inputDayEd, Int32 printType, Int32 debitNoteDiv, Int32 supplierFormal, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipCd, string partySaleSlipNumSt, string partySaleSlipNumEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 outputDesignated, Int32 stockOrderDivCd, Int32 sortOrder, Int32 printDiv, string printDivName, string enterpriseName, string stockAddUpSectionNm) // ADD 2008/07/16 // DEL 2009/04/14
        public ExtrInfo_MAKON02247E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] stockSectionCd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 inputDaySt, Int32 inputDayEd, Int32 printType, Int32 debitNoteDiv, Int32 supplierFormal, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipCd, string partySaleSlipNumSt, string partySaleSlipNumEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 outputDesignated, Int32 stockOrderDivCd, Int32 sortOrder, Int32 printDiv, string printDivName, string enterpriseName, string stockAddUpSectionNm, Int32 printDailyFooter)  // ADD 2009/04/14
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._stockSectionCd = stockSectionCd;
			this._stockDateSt = stockDateSt;
			this._stockDateEd = stockDateEd;
			this._arrivalGoodsDaySt = arrivalGoodsDaySt;
			this._arrivalGoodsDayEd = arrivalGoodsDayEd;
			this._inputDaySt = inputDaySt;
			this._inputDayEd = inputDayEd;
			this._printType = printType;
			this._debitNoteDiv = debitNoteDiv;
			this._supplierFormal = supplierFormal;
			this._supplierSlipNoSt = supplierSlipNoSt;
			this._supplierSlipNoEd = supplierSlipNoEd;
			this._stockAgentCodeSt = stockAgentCodeSt;
			this._stockAgentCodeEd = stockAgentCodeEd;
			this._supplierSlipCd = supplierSlipCd;
			this._partySaleSlipNumSt = partySaleSlipNumSt;
			this._partySaleSlipNumEd = partySaleSlipNumEd;

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //this._customerCodeSt = customerCodeSt;
            //this._customerCodeEd = customerCodeEd;
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            this._supplierCdSt = supplierCdSt;          // �d����R�[�h(�J�n)
            this._supplierCdEd = supplierCdEd;          // �d����R�[�h(�I��)
            this._salesAreaCodeSt = salesAreaCodeSt;    // �̔��G���A�R�[�h(�J�n)
            this._salesAreaCodeEd = salesAreaCodeEd;    // �̔��G���A�R�[�h(�I��)
            this._outputDesignated = outputDesignated;  // �o�͎w��
            this._stockOrderDivCd = stockOrderDivCd;    // �d���݌Ɏ�񂹋敪
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			this._sortOrder = sortOrder;
			this._printDiv = printDiv;
			this._printDivName = printDivName;
			this._enterpriseName = enterpriseName;
			this._stockAddUpSectionNm = stockAddUpSectionNm;

            this._printDailyFooter = printDailyFooter; // ADD 2009/04/14
		}

		/// <summary>
		/// �d���m�F�\���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_MAKON02247E�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_MAKON02247E Clone()
		{
			//return new ExtrInfo_MAKON02247E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._stockSectionCd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._inputDaySt, this._inputDayEd, this._printType, this._debitNoteDiv, this._supplierFormal, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipCd, this._partySaleSlipNumSt, this._partySaleSlipNumEd, this._customerCodeSt, this._customerCodeEd, this._sortOrder, this._printDiv, this._printDivName, this._enterpriseName, this._stockAddUpSectionNm);  // DEL 2008/07/16
            //return new ExtrInfo_MAKON02247E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._stockSectionCd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._inputDaySt, this._inputDayEd, this._printType, this._debitNoteDiv, this._supplierFormal, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipCd, this._partySaleSlipNumSt, this._partySaleSlipNumEd, this._supplierCdSt, this._supplierCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._outputDesignated, this._stockOrderDivCd, this._sortOrder, this._printDiv, this._printDivName, this._enterpriseName, this._stockAddUpSectionNm); // ADD 2008/07/16 // DEL 2009/04/14
            return new ExtrInfo_MAKON02247E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._stockSectionCd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._inputDaySt, this._inputDayEd, this._printType, this._debitNoteDiv, this._supplierFormal, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipCd, this._partySaleSlipNumSt, this._partySaleSlipNumEd, this._supplierCdSt, this._supplierCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._outputDesignated, this._stockOrderDivCd, this._sortOrder, this._printDiv, this._printDivName, this._enterpriseName, this._stockAddUpSectionNm, this._printDailyFooter); // ADD 2009/04/14
        }

		/// <summary>
		/// �d���m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAKON02247E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_MAKON02247E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				 && (this.StockSectionCd == target.StockSectionCd)
				 && (this.StockDateSt == target.StockDateSt)
				 && (this.StockDateEd == target.StockDateEd)
				 && (this.ArrivalGoodsDaySt == target.ArrivalGoodsDaySt)
				 && (this.ArrivalGoodsDayEd == target.ArrivalGoodsDayEd)
				 && (this.InputDaySt == target.InputDaySt)
				 && (this.InputDayEd == target.InputDayEd)
				 && (this.PrintType == target.PrintType)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.SupplierFormal == target.SupplierFormal)
				 && (this.SupplierSlipNoSt == target.SupplierSlipNoSt)
				 && (this.SupplierSlipNoEd == target.SupplierSlipNoEd)
				 && (this.StockAgentCodeSt == target.StockAgentCodeSt)
				 && (this.StockAgentCodeEd == target.StockAgentCodeEd)
				 && (this.SupplierSlipCd == target.SupplierSlipCd)
				 && (this.PartySaleSlipNumSt == target.PartySaleSlipNumSt)
				 && (this.PartySaleSlipNumEd == target.PartySaleSlipNumEd)

                 // --- DEL 2008/07/16 -------------------------------->>>>>
                 //&& (this.CustomerCodeSt == target.CustomerCodeSt)
                 //&& (this.CustomerCodeEd == target.CustomerCodeEd)
                 // --- DEL 2008/07/16 --------------------------------<<<<< 

                 // --- ADD 2008/07/16 -------------------------------->>>>>
                 && (this.SupplierCdSt == target.SupplierCdSt)          // �d����R�[�h(�J�n)
                 && (this.SupplierCdEd == target.SupplierCdEd)          // �d����R�[�h(�I��)
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)    // �̔��G���A�R�[�h(�J�n)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)    // �̔��G���A�R�[�h(�I��)
                 && (this.OutputDesignated == target.OutputDesignated)  // �o�͎w��
                 && (this.StockOrderDivCd == target.StockOrderDivCd)    // �d���݌Ɏ�񂹋敪
                 // --- ADD 2008/07/16 --------------------------------<<<<< 

				 && (this.SortOrder == target.SortOrder)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.PrintDivName == target.PrintDivName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.StockAddUpSectionNm == target.StockAddUpSectionNm)
                 && (this.PrintDailyFooter == target.PrintDailyFooter) // ADD 2009/04/14
                 );
		}

		/// <summary>
		/// �d���m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_MAKON02247E1">
		///                    ��r����ExtrInfo_MAKON02247E�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_MAKON02247E2">��r����ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAKON02247E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_MAKON02247E extrInfo_MAKON02247E1, ExtrInfo_MAKON02247E extrInfo_MAKON02247E2)
		{
			return ((extrInfo_MAKON02247E1.EnterpriseCode == extrInfo_MAKON02247E2.EnterpriseCode)
				 && (extrInfo_MAKON02247E1.IsSelectAllSection == extrInfo_MAKON02247E2.IsSelectAllSection)
				 && (extrInfo_MAKON02247E1.IsOutputAllSecRec == extrInfo_MAKON02247E2.IsOutputAllSecRec)
				 && (extrInfo_MAKON02247E1.StockSectionCd == extrInfo_MAKON02247E2.StockSectionCd)
				 && (extrInfo_MAKON02247E1.StockDateSt == extrInfo_MAKON02247E2.StockDateSt)
				 && (extrInfo_MAKON02247E1.StockDateEd == extrInfo_MAKON02247E2.StockDateEd)
				 && (extrInfo_MAKON02247E1.ArrivalGoodsDaySt == extrInfo_MAKON02247E2.ArrivalGoodsDaySt)
				 && (extrInfo_MAKON02247E1.ArrivalGoodsDayEd == extrInfo_MAKON02247E2.ArrivalGoodsDayEd)
				 && (extrInfo_MAKON02247E1.InputDaySt == extrInfo_MAKON02247E2.InputDaySt)
				 && (extrInfo_MAKON02247E1.InputDayEd == extrInfo_MAKON02247E2.InputDayEd)
				 && (extrInfo_MAKON02247E1.PrintType == extrInfo_MAKON02247E2.PrintType)
				 && (extrInfo_MAKON02247E1.DebitNoteDiv == extrInfo_MAKON02247E2.DebitNoteDiv)
				 && (extrInfo_MAKON02247E1.SupplierFormal == extrInfo_MAKON02247E2.SupplierFormal)
				 && (extrInfo_MAKON02247E1.SupplierSlipNoSt == extrInfo_MAKON02247E2.SupplierSlipNoSt)
				 && (extrInfo_MAKON02247E1.SupplierSlipNoEd == extrInfo_MAKON02247E2.SupplierSlipNoEd)
				 && (extrInfo_MAKON02247E1.StockAgentCodeSt == extrInfo_MAKON02247E2.StockAgentCodeSt)
				 && (extrInfo_MAKON02247E1.StockAgentCodeEd == extrInfo_MAKON02247E2.StockAgentCodeEd)
				 && (extrInfo_MAKON02247E1.SupplierSlipCd == extrInfo_MAKON02247E2.SupplierSlipCd)
				 && (extrInfo_MAKON02247E1.PartySaleSlipNumSt == extrInfo_MAKON02247E2.PartySaleSlipNumSt)
				 && (extrInfo_MAKON02247E1.PartySaleSlipNumEd == extrInfo_MAKON02247E2.PartySaleSlipNumEd)

                 // --- DEL 2008/07/16 -------------------------------->>>>>
                 //&& (extrInfo_MAKON02247E1.CustomerCodeSt == extrInfo_MAKON02247E2.CustomerCodeSt)
                 //&& (extrInfo_MAKON02247E1.CustomerCodeEd == extrInfo_MAKON02247E2.CustomerCodeEd)
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                 && (extrInfo_MAKON02247E1.SupplierCdSt == extrInfo_MAKON02247E2.SupplierCdSt)          // �d����R�[�h(�J�n)
                 && (extrInfo_MAKON02247E1.SupplierCdEd == extrInfo_MAKON02247E2.SupplierCdEd)          // �d����R�[�h(�I��) 
                 && (extrInfo_MAKON02247E1.SalesAreaCodeSt == extrInfo_MAKON02247E2.SalesAreaCodeSt)    // �̔��G���A�R�[�h(�J�n)
                 && (extrInfo_MAKON02247E1.SalesAreaCodeEd == extrInfo_MAKON02247E2.SalesAreaCodeEd)    // �̔��G���A�R�[�h(�I��)
                 && (extrInfo_MAKON02247E1.OutputDesignated == extrInfo_MAKON02247E2.OutputDesignated)  // �o�͎w��
                 && (extrInfo_MAKON02247E1.StockOrderDivCd == extrInfo_MAKON02247E2.StockOrderDivCd)    // �d���݌Ɏ�񂹋敪 
                // --- ADD 2008/07/16 --------------------------------<<<<< 

				 && (extrInfo_MAKON02247E1.SortOrder == extrInfo_MAKON02247E2.SortOrder)
				 && (extrInfo_MAKON02247E1.PrintDiv == extrInfo_MAKON02247E2.PrintDiv)
				 && (extrInfo_MAKON02247E1.PrintDivName == extrInfo_MAKON02247E2.PrintDivName)
				 && (extrInfo_MAKON02247E1.EnterpriseName == extrInfo_MAKON02247E2.EnterpriseName)
				 && (extrInfo_MAKON02247E1.StockAddUpSectionNm == extrInfo_MAKON02247E2.StockAddUpSectionNm)
                 && (extrInfo_MAKON02247E1.PrintDailyFooter == extrInfo_MAKON02247E2.PrintDailyFooter) // ADD 2009/04/14
                 );
		}
		/// <summary>
		/// �d���m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAKON02247E�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_MAKON02247E target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (this.StockSectionCd != target.StockSectionCd) resList.Add("StockSectionCd");
			if (this.StockDateSt != target.StockDateSt) resList.Add("StockDateSt");
			if (this.StockDateEd != target.StockDateEd) resList.Add("StockDateEd");
			if (this.ArrivalGoodsDaySt != target.ArrivalGoodsDaySt) resList.Add("ArrivalGoodsDaySt");
			if (this.ArrivalGoodsDayEd != target.ArrivalGoodsDayEd) resList.Add("ArrivalGoodsDayEd");
			if (this.InputDaySt != target.InputDaySt) resList.Add("InputDaySt");
			if (this.InputDayEd != target.InputDayEd) resList.Add("InputDayEd");
			if (this.PrintType != target.PrintType) resList.Add("PrintType");
			if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
			if (this.SupplierSlipNoSt != target.SupplierSlipNoSt) resList.Add("SupplierSlipNoSt");
			if (this.SupplierSlipNoEd != target.SupplierSlipNoEd) resList.Add("SupplierSlipNoEd");
			if (this.StockAgentCodeSt != target.StockAgentCodeSt) resList.Add("StockAgentCodeSt");
			if (this.StockAgentCodeEd != target.StockAgentCodeEd) resList.Add("StockAgentCodeEd");
			if (this.SupplierSlipCd != target.SupplierSlipCd) resList.Add("SupplierSlipCd");
			if (this.PartySaleSlipNumSt != target.PartySaleSlipNumSt) resList.Add("PartySaleSlipNumSt");
			if (this.PartySaleSlipNumEd != target.PartySaleSlipNumEd) resList.Add("PartySaleSlipNumEd");

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            //if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.OutputDesignated != target.OutputDesignated) resList.Add("OutputDesignated");
            if (this.StockOrderDivCd != target.StockOrderDivCd) resList.Add("StockOrderDivCd");
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			if (this.PrintDiv != target.PrintDiv) resList.Add("PrintDiv");
			if (this.PrintDivName != target.PrintDivName) resList.Add("PrintDivName");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.StockAddUpSectionNm != target.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");

            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/14

			return resList;
		}

		/// <summary>
		/// �d���m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_MAKON02247E1">��r����ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_MAKON02247E2">��r����ExtrInfo_MAKON02247E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_MAKON02247E�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_MAKON02247E extrInfo_MAKON02247E1, ExtrInfo_MAKON02247E extrInfo_MAKON02247E2)
		{
			ArrayList resList = new ArrayList();
			if (extrInfo_MAKON02247E1.EnterpriseCode != extrInfo_MAKON02247E2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (extrInfo_MAKON02247E1.IsSelectAllSection != extrInfo_MAKON02247E2.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (extrInfo_MAKON02247E1.IsOutputAllSecRec != extrInfo_MAKON02247E2.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (extrInfo_MAKON02247E1.StockSectionCd != extrInfo_MAKON02247E2.StockSectionCd) resList.Add("StockSectionCd");
			if (extrInfo_MAKON02247E1.StockDateSt != extrInfo_MAKON02247E2.StockDateSt) resList.Add("StockDateSt");
			if (extrInfo_MAKON02247E1.StockDateEd != extrInfo_MAKON02247E2.StockDateEd) resList.Add("StockDateEd");
			if (extrInfo_MAKON02247E1.ArrivalGoodsDaySt != extrInfo_MAKON02247E2.ArrivalGoodsDaySt) resList.Add("ArrivalGoodsDaySt");
			if (extrInfo_MAKON02247E1.ArrivalGoodsDayEd != extrInfo_MAKON02247E2.ArrivalGoodsDayEd) resList.Add("ArrivalGoodsDayEd");
			if (extrInfo_MAKON02247E1.InputDaySt != extrInfo_MAKON02247E2.InputDaySt) resList.Add("InputDaySt");
			if (extrInfo_MAKON02247E1.InputDayEd != extrInfo_MAKON02247E2.InputDayEd) resList.Add("InputDayEd");
			if (extrInfo_MAKON02247E1.PrintType != extrInfo_MAKON02247E2.PrintType) resList.Add("PrintType");
			if (extrInfo_MAKON02247E1.DebitNoteDiv != extrInfo_MAKON02247E2.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (extrInfo_MAKON02247E1.SupplierFormal != extrInfo_MAKON02247E2.SupplierFormal) resList.Add("SupplierFormal");
			if (extrInfo_MAKON02247E1.SupplierSlipNoSt != extrInfo_MAKON02247E2.SupplierSlipNoSt) resList.Add("SupplierSlipNoSt");
			if (extrInfo_MAKON02247E1.SupplierSlipNoEd != extrInfo_MAKON02247E2.SupplierSlipNoEd) resList.Add("SupplierSlipNoEd");
			if (extrInfo_MAKON02247E1.StockAgentCodeSt != extrInfo_MAKON02247E2.StockAgentCodeSt) resList.Add("StockAgentCodeSt");
			if (extrInfo_MAKON02247E1.StockAgentCodeEd != extrInfo_MAKON02247E2.StockAgentCodeEd) resList.Add("StockAgentCodeEd");
			if (extrInfo_MAKON02247E1.SupplierSlipCd != extrInfo_MAKON02247E2.SupplierSlipCd) resList.Add("SupplierSlipCd");
			if (extrInfo_MAKON02247E1.PartySaleSlipNumSt != extrInfo_MAKON02247E2.PartySaleSlipNumSt) resList.Add("PartySaleSlipNumSt");
			if (extrInfo_MAKON02247E1.PartySaleSlipNumEd != extrInfo_MAKON02247E2.PartySaleSlipNumEd) resList.Add("PartySaleSlipNumEd");

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //if (extrInfo_MAKON02247E1.CustomerCodeSt != extrInfo_MAKON02247E2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            //if (extrInfo_MAKON02247E1.CustomerCodeEd != extrInfo_MAKON02247E2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            if (extrInfo_MAKON02247E1.SupplierCdSt != extrInfo_MAKON02247E2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (extrInfo_MAKON02247E1.SupplierCdEd != extrInfo_MAKON02247E2.SupplierCdEd) resList.Add("SupplierCdEd");
            if (extrInfo_MAKON02247E1.SalesAreaCodeSt != extrInfo_MAKON02247E2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (extrInfo_MAKON02247E1.SalesAreaCodeEd != extrInfo_MAKON02247E2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (extrInfo_MAKON02247E1.OutputDesignated != extrInfo_MAKON02247E2.OutputDesignated) resList.Add("OutputDesignated");
            if (extrInfo_MAKON02247E1.StockOrderDivCd != extrInfo_MAKON02247E2.StockOrderDivCd) resList.Add("StockOrderDivCd");
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            
            if (extrInfo_MAKON02247E1.SortOrder != extrInfo_MAKON02247E2.SortOrder) resList.Add("SortOrder");
			if (extrInfo_MAKON02247E1.PrintDiv != extrInfo_MAKON02247E2.PrintDiv) resList.Add("PrintDiv");
			if (extrInfo_MAKON02247E1.PrintDivName != extrInfo_MAKON02247E2.PrintDivName) resList.Add("PrintDivName");
			if (extrInfo_MAKON02247E1.EnterpriseName != extrInfo_MAKON02247E2.EnterpriseName) resList.Add("EnterpriseName");
			if (extrInfo_MAKON02247E1.StockAddUpSectionNm != extrInfo_MAKON02247E2.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");

            if (extrInfo_MAKON02247E1.PrintDailyFooter != extrInfo_MAKON02247E2.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/14

			return resList;
		}
	}
}

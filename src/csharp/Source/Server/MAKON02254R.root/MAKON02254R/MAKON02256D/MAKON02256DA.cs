using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockConfShWork
    /// <summary>
    ///                      �d���m�F�\���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���m�F�\���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/06/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   6/30  �c��</br>
    /// <br>                 :   Partsman.NS�Ή�</br>
    /// <br>                 :   �E�d���`���A�d���`�[�ԍ��̕⑫������PM.NS�̈Ӗ������ɕύX</br>
    /// <br>                 :   �E���Ӑ�R�[�h���d����R�[�h�ɕύX�i���Ӑ敪���Ή��j</br>
    /// <br>                 :   �E�n��R�[�h�A�o�͎w��A�d���݌Ɏ�񂹋敪�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockConfShWork
    //public class StockConfShWork : IFileHeader
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
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�(�J�n)</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�@���d��SEQ</remarks>
        private Int32 _supplierSlipNoSt;

        /// <summary>�d���`�[�ԍ�(�I��)</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</remarks>
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
        /// <remarks>�����͎��͋󕶎�("") ���d����`�[�ԍ�</remarks>
        private string _partySaleSlipNumSt = "";

        /// <summary>�����`�[�ԍ�(�I��)</summary>
        /// <remarks>�����͎��͋󕶎�("")</remarks>
        private string _partySaleSlipNumEd = "";

        /// <summary>�d����R�[�h(�J�n)</summary>
        private Int32 _supplierCdSt;

        /// <summary>�d����R�[�h(�I��)</summary>
        private Int32 _supplierCdEd;

        /// <summary>�̔��G���A�R�[�h(�J�n)</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCodeSt;

        /// <summary>�̔��G���A�R�[�h(�I��)</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCodeEd;

        /// <summary>�o�͎w��</summary>
        /// <remarks>0:�S�� 1:�d������ 2:UOE�� 3:�������͕� 4:UOE�A���}�b�`</remarks>
        private Int32 _outputDesignated;

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>-1:�S��,0:���,1:�݌�</remarks>
        private Int32 _stockOrderDivCd;


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
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
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
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�@���d��SEQ</value>
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
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</value>
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
        /// <value>�����͎��͋󕶎�("") ���d����`�[�ԍ�</value>
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

        /// public propaty name  :  SupplierCdSt
        /// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
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
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
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
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  OutputDesignated
        /// <summary>�o�͎w��v���p�e�B</summary>
        /// <value>0:�S�� 1:�d������ 2:UOE�� 3:�������͕� 4:UOE�A���}�b�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputDesignated
        {
            get { return _outputDesignated; }
            set { _outputDesignated = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>-1:�S��,0:���,1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }


        /// <summary>
        /// �d���m�F�\���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockConfShWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfShWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockConfShWork()
        {
        }

    }
}

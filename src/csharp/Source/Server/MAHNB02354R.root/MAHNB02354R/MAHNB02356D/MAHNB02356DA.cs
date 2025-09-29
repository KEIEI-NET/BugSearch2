using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesConfShWork
    /// <summary>
    ///                      ����m�F�\�����������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����m�F�\�����������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesConfShWork
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
        /// <value>true:�S�БI�� false:�e���_�I��</value>
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
            get { return _resultsAddUpSecList; }
            set { _resultsAddUpSecList = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
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
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
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
            get { return _searchSlipDateSt; }
            set { _searchSlipDateSt = value; }
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
            get { return _searchSlipDateEd; }
            set { _searchSlipDateEd = value; }
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
            get { return _shipmentDaySt; }
            set { _shipmentDaySt = value; }
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
            get { return _shipmentDayEd; }
            set { _shipmentDayEd = value; }
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
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
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
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
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
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
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
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
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
            get { return _salesSlipNumSt; }
            set { _salesSlipNumSt = value; }
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
            get { return _salesSlipNumEd; }
            set { _salesSlipNumEd = value; }
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
            get { return _salesInputCodeSt; }
            set { _salesInputCodeSt = value; }
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
            get { return _salesInputCodeEd; }
            set { _salesInputCodeEd = value; }
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
            get { return _salesEmployeeCdSt; }
            set { _salesEmployeeCdSt = value; }
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
            get { return _salesEmployeeCdEd; }
            set { _salesEmployeeCdEd = value; }
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
            get { return _frontEmployeeCdSt; }
            set { _frontEmployeeCdSt = value; }
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
            get { return _frontEmployeeCdEd; }
            set { _frontEmployeeCdEd = value; }
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

        /// public propaty name  :  BusinessTypeCodeSt
        /// <summary>�Ǝ�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCodeSt
        {
            get { return _businessTypeCodeSt; }
            set { _businessTypeCodeSt = value; }
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
            get { return _businessTypeCodeEd; }
            set { _businessTypeCodeEd = value; }
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
            get { return _salesSlipUpdateCd; }
            set { _salesSlipUpdateCd = value; }
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
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
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
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
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
            get { return _grsProfitCheckLower; }
            set { _grsProfitCheckLower = value; }
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
            get { return _grsProfitCheckBest; }
            set { _grsProfitCheckBest = value; }
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
            get { return _grsProfitCheckUpper; }
            set { _grsProfitCheckUpper = value; }
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
            get { return _grossMargin1Mark; }
            set { _grossMargin1Mark = value; }
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
            get { return _grossMargin2Mark; }
            set { _grossMargin2Mark = value; }
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
            get { return _grossMargin3Mark; }
            set { _grossMargin3Mark = value; }
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
            get { return _grossMargin4Mark; }
            set { _grossMargin4Mark = value; }
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
            get { return _zeroSalesPrint; }
            set { _zeroSalesPrint = value; }
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
            get { return _zeroCostPrint; }
            set { _zeroCostPrint = value; }
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
            get { return _zeroGrsProfitPrint; }
            set { _zeroGrsProfitPrint = value; }
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
            get { return _zeroUdrGrsProfitPrint; }
            set { _zeroUdrGrsProfitPrint = value; }
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
            get { return _grsProfitRatePrint; }
            set { _grsProfitRatePrint = value; }
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
            get { return _grsProfitRatePrintVal; }
            set { _grsProfitRatePrintVal = value; }
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
            get { return _grsProfitRatePrintDiv; }
            set { _grsProfitRatePrintDiv = value; }
        }


        /// <summary>
        /// ����m�F�\�����������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesConfShWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesConfShWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesConfShWork()
        {
        }

    }

}

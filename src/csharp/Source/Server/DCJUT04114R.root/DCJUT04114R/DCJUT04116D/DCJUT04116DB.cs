using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AcptAnOdrRemainRefDataWork
    /// <summary>
    ///                      �󒍎c�Ɖ�o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󒍎c�Ɖ�o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AcptAnOdrRemainRefDataWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>�`�[��</remarks>
        private string _salesSlipNum = "";

        /// <summary>�󒍔ԍ�</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>���㖾�גʔ�</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        /// <remarks>���Ӑ於</remarks>
        private string _customerSnm = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��]�ƈ�����</summary>
        /// <remarks>�S���Җ�</remarks>
        private string _salesEmployeeNm = "";

        /// <summary>�[�i�於��</summary>
        /// <remarks>�[����</remarks>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
        /// <remarks>�[����Q</remarks>
        private string _addresseeName2 = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        /// <remarks>�󒍎Җ�</remarks>
        private string _frontEmployeeNm = "";

        /// <summary>������t</summary>
        /// <remarks>�󒍓�</remarks>
        private DateTime _salesDate;

        /// <summary>���i�ԍ�</summary>
        /// <remarks>���i�R�[�h</remarks>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        /// <remarks>���i��</remarks>
        private string _goodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�[��</remarks>
        private string _makerName = "";

        /// <summary>�󒍐���</summary>
        /// <remarks>�󒍐�</remarks>
        private Double _acceptAnOrderCnt;

        /// <summary>�󒍎c��</summary>
        /// <remarks>�󒍎c��</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        /// <remarks>�󒍒P��</remarks>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>�����`�[�ԍ��i���ׁj</summary>
        /// <remarks>���Ӑ撍��</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>��P���i����P���j</summary>
        /// <remarks>��P��</remarks>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>�����P��</summary>
        /// <remarks>�����P��</remarks>
        private Double _salesUnitCost;

        /// <summary>���ה��l</summary>
        /// <remarks>���ה��l</remarks>
        private string _dtlNote = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        /// <remarks>�d���於</remarks>
        private string _supplierSnm = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ�</summary>
        private string _warehouseName = "";

        /// <summary>�`�[�����P</summary>
        /// <remarks>����</remarks>
        private string _slipMemo1 = "";

        /// <summary>�`�[�����Q</summary>
        /// <remarks>����</remarks>
        private string _slipMemo2 = "";

        /// <summary>�`�[�����R</summary>
        /// <remarks>����</remarks>
        private string _slipMemo3 = "";

        /// <summary>�Г������P</summary>
        /// <remarks>����</remarks>
        private string _insideMemo1 = "";

        /// <summary>�Г������Q</summary>
        /// <remarks>����</remarks>
        private string _insideMemo2 = "";

        /// <summary>�Г������R</summary>
        /// <remarks>����</remarks>
        private string _insideMemo3 = "";

        /// <summary>����`�[�敪�i���ׁj</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        private Double _listPriceTaxExcFl;

        /// <summary>�o�א�</summary>
        /// <remarks>���㐔</remarks>
        private Double _shipmentCnt;

        /// <summary>���q�Ǘ��R�[�h</summary>
        private string _carMngCode = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�`�[�������t</summary>
        /// <remarks>���͓�</remarks>
        private DateTime _searchSlipDate;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>������z����Ŋz</summary>
        private Int64 _salesPriceConsTax;

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������͎҃R�[�h</summary>
        private string _salesInputCode = "";

        /// <summary>������͎Җ���</summary>
        private string _salesInputName = "";

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;


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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>���ʒʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʒʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>���㖾�גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// <value>���Ӑ於</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// <value>�S���Җ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// <value>�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2�v���p�e�B</summary>
        /// <value>�[����Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// <value>�󒍎Җ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>�󒍓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>���i�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>���i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>���[�J�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// <value>�󒍐�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>�󒍎c���v���p�e�B</summary>
        /// <value>�󒍎c��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�󒍒P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>�����`�[�ԍ��i���ׁj�v���p�e�B</summary>
        /// <value>���Ӑ撍��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>��P���i����P���j�v���p�e�B</summary>
        /// <value>��P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>���ה��l�v���p�e�B</summary>
        /// <value>���ה��l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ה��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�d���於</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>�`�[�����P�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set { _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>�`�[�����Q�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set { _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>�`�[�����R�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set { _slipMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>�Г������P�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set { _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>�Г������Q�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set { _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>�Г������R�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set { _insideMemo3 = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>���㐔</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>�`�[�������t�v���p�e�B</summary>
        /// <value>���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
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
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>������z����Ŋz�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>�o�ד��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }


        /// <summary>
        /// �󒍎c�Ɖ�o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcptAnOdrRemainRefDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AcptAnOdrRemainRefDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AcptAnOdrRemainRefDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AcptAnOdrRemainRefDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AcptAnOdrRemainRefDataWork || graph is ArrayList || graph is AcptAnOdrRemainRefDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AcptAnOdrRemainRefDataWork).FullName));

            if (graph != null && graph is AcptAnOdrRemainRefDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AcptAnOdrRemainRefDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AcptAnOdrRemainRefDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AcptAnOdrRemainRefDataWork[])graph).Length;
            }
            else if (graph is AcptAnOdrRemainRefDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //���ʒʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //���㖾�גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //�[�i�於��
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //�[�i�於��2
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //�󒍎c��
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //�����`�[�ԍ��i���ׁj
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //��P���i����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //���ה��l
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ�
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�`�[�����P
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //�`�[�����Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //�`�[�����R
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //�Г������P
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //�Г������Q
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //�Г������R
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //���q�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�`�[�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //������z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //�o�ד��t
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //���z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo


            serInfo.Serialize(writer, serInfo);
            if (graph is AcptAnOdrRemainRefDataWork)
            {
                AcptAnOdrRemainRefDataWork temp = (AcptAnOdrRemainRefDataWork)graph;

                SetAcptAnOdrRemainRefDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AcptAnOdrRemainRefDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AcptAnOdrRemainRefDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AcptAnOdrRemainRefDataWork temp in lst)
                {
                    SetAcptAnOdrRemainRefDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AcptAnOdrRemainRefDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 59;

        /// <summary>
        ///  AcptAnOdrRemainRefDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetAcptAnOdrRemainRefDataWork(System.IO.BinaryWriter writer, AcptAnOdrRemainRefDataWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //�󒍔ԍ�
            writer.Write(temp.AcceptAnOrderNo);
            //���ʒʔ�
            writer.Write(temp.CommonSeqNo);
            //���㖾�גʔ�
            writer.Write(temp.SalesSlipDtlNum);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //�[�i�於��
            writer.Write(temp.AddresseeName);
            //�[�i�於��2
            writer.Write(temp.AddresseeName2);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //��t�]�ƈ�����
            writer.Write(temp.FrontEmployeeNm);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //�󒍎c��
            writer.Write(temp.AcptAnOdrRemainCnt);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //�����`�[�ԍ��i���ׁj
            writer.Write(temp.PartySlipNumDtl);
            //��P���i����P���j
            writer.Write(temp.StdUnPrcSalUnPrc);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //���ה��l
            writer.Write(temp.DtlNote);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ�
            writer.Write(temp.WarehouseName);
            //�`�[�����P
            writer.Write(temp.SlipMemo1);
            //�`�[�����Q
            writer.Write(temp.SlipMemo2);
            //�`�[�����R
            writer.Write(temp.SlipMemo3);
            //�Г������P
            writer.Write(temp.InsideMemo1);
            //�Г������Q
            writer.Write(temp.InsideMemo2);
            //�Г������R
            writer.Write(temp.InsideMemo3);
            //����`�[�敪�i���ׁj
            writer.Write(temp.SalesSlipCdDtl);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //���q�Ǘ��R�[�h
            writer.Write(temp.CarMngCode);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //�Ԏ�S�p����
            writer.Write(temp.ModelFullName);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�`�[�������t
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //���ьv�㋒�_�R�[�h
            writer.Write(temp.ResultsAddUpSecCd);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //������z����Ŋz
            writer.Write(temp.SalesPriceConsTax);
            //�o�ד��t
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //������͎҃R�[�h
            writer.Write(temp.SalesInputCode);
            //������͎Җ���
            writer.Write(temp.SalesInputName);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //���z�\�����@�敪
            writer.Write(temp.TotalAmountDispWayCd);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);

        }

        /// <summary>
        ///  AcptAnOdrRemainRefDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private AcptAnOdrRemainRefDataWork GetAcptAnOdrRemainRefDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AcptAnOdrRemainRefDataWork temp = new AcptAnOdrRemainRefDataWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //���ʒʔ�
            temp.CommonSeqNo = reader.ReadInt64();
            //���㖾�גʔ�
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //�[�i�於��
            temp.AddresseeName = reader.ReadString();
            //�[�i�於��2
            temp.AddresseeName2 = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //�󒍎c��
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //�����`�[�ԍ��i���ׁj
            temp.PartySlipNumDtl = reader.ReadString();
            //��P���i����P���j
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //���ה��l
            temp.DtlNote = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ�
            temp.WarehouseName = reader.ReadString();
            //�`�[�����P
            temp.SlipMemo1 = reader.ReadString();
            //�`�[�����Q
            temp.SlipMemo2 = reader.ReadString();
            //�`�[�����R
            temp.SlipMemo3 = reader.ReadString();
            //�Г������P
            temp.InsideMemo1 = reader.ReadString();
            //�Г������Q
            temp.InsideMemo2 = reader.ReadString();
            //�Г������R
            temp.InsideMemo3 = reader.ReadString();
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //���q�Ǘ��R�[�h
            temp.CarMngCode = reader.ReadString();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //�Ԏ�S�p����
            temp.ModelFullName = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�`�[�������t
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //���ьv�㋒�_�R�[�h
            temp.ResultsAddUpSecCd = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //������z����Ŋz
            temp.SalesPriceConsTax = reader.ReadInt64();
            //�o�ד��t
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //������͎Җ���
            temp.SalesInputName = reader.ReadString();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //���z�\�����@�敪
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AcptAnOdrRemainRefDataWork temp = GetAcptAnOdrRemainRefDataWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (AcptAnOdrRemainRefDataWork[])lst.ToArray(typeof(AcptAnOdrRemainRefDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
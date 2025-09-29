using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderConfWork
    /// <summary>
    ///                      �󒍑ݏo�m�F�\���o���ʃN���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󒍑ݏo�m�F�\���o���ʃN���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OrderConfWork
    {
        /// <summary>���_�R�[�h[����]</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����[����]</summary>
        /// <remarks>���_���ݒ�}�X�^���擾</remarks>
        private string _sectionGuideNm = "";

        /// <summary>����R�[�h[����]</summary>
        private Int32 _subSectionCode;

        /// <summary>���喼��[����]</summary>
        private string _subSectionName = "";

        /// <summary>���Ӑ�R�[�h[����]</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��[����]</summary>
        private string _customerSnm = "";

        /// <summary>�̔��G���A�R�[�h(�n��)[����]</summary>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����(�n��)[����]</summary>
        private string _salesAreaName = "";

        /// <summary>������R�[�h[����]</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��[����]</summary>
        private string _claimSnm = "";

        /// <summary>�[�i��R�[�h(�[����)[����]</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��(�[����)[����]</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2(�[���ꏊ)[����]</summary>
        /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
        private string _addresseeName2 = "";

        /// <summary>������͎҃R�[�h[����]</summary>
        private string _salesInputCode = "";

        /// <summary>������͎Җ���[����]</summary>
        private string _salesInputName = "";

        /// <summary>��t�]�ƈ��R�[�h[����]</summary>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����[����]</summary>
        private string _frontEmployeeNm = "";

        /// <summary>�̔��]�ƈ��R�[�h[����]</summary>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��]�ƈ�����[����]</summary>
        private string _salesEmployeeNm = "";

        /// <summary>�󒍃X�e�[�^�X[����]</summary>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�[�`�[]</summary>
        private string _salesSlipNum = "";

        /// <summary>�ԓ`�敪[����]</summary>
        private Int32 _debitNoteDiv;

        /// <summary>����`�[�敪[�`�[]</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���㏤�i�敪[����]</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������</remarks>
        private Int32 _salesGoodsCd;

        /// <summary>���|�敪[����]</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>����敪��[�`�[]</summary>
        /// <remarks>�����[�g���ŎZ�o(����`�[�敪�E���|�敪���g�p)</remarks>
        private string _transactionName = "";

        /// <summary>�`�[�������t(���͓��t)[����]</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _searchSlipDate;

        /// <summary>�o�ד��t[����]</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������t[����]</summary>
        private DateTime _salesDate;

        /// <summary>�v����t(������)[����]</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>�����敪[����]</summary>
        private Int32 _delayPaymentDiv;

        /// <summary>�����`�[�ԍ�[����]</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>����`�[���v(�Ŕ�)[�`�[]</summary>
        /// <remarks>(�l�����܂�)</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>����`�[���v(�ō�)[�`�[]</summary>
        /// <remarks>(�l�����܂�)</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>����l�����z�v(�Ŕ�)[�`�[]</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>����l������Ŋz�i���Łj[�`�[]</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>�������z�v[�`�[]</summary>
        private Int64 _totalCost;

        /// <summary>�e����[�`�[]</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private Double _grossMarginRate;

        /// <summary>�e���`�F�b�N�}�[�N[�`�[]</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private string _grossMarginMarkSlip = "";

        /// <summary>�`�[���l[�`�[]</summary>
        private string _slipNote = "";

        /// <summary>����s�ԍ�[����]</summary>
        private Int32 _salesRowNo;

        /// <summary>����`�[�敪[����]</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,9:�ꎮ</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>���i���[�J�[�R�[�h[����]</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����[����]</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�[����]</summary>
        private string _goodsNo = "";

        /// <summary>���i����[����]</summary>
        private string _goodsName = "";

        /// <summary>�o�א�[����]</summary>
        private Double _shipmentCnt;

        /// <summary>��P��(����P��)[����]</summary>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>����P��(�ō�)[����]</summary>
        private Double _salesUnPrcTaxIncFl;

        /// <summary>����P��(�Ŕ�)[����]</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>������z(�ō�)[����]</summary>
        private Int64 _salesMoneyTaxInc;

        /// <summary>������z(�Ŕ�)[����]</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�����P��[����]</summary>
        private Double _salesUnitCost;

        /// <summary>�������z[����]</summary>
        private Int64 _cost;

        /// <summary>�e����[����]</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private Double _grossMarginRateDtl;

        /// <summary>�e���`�F�b�N�}�[�N[����]</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private string _grossMarginMarkDtl = "";

        /// <summary>�d����R�[�h[����]</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��[����]</summary>
        private string _supplierSnm = "";

        /// <summary>�����`�[�ԍ�[����]</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`No�j</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>���ה��l[����]</summary>
        private string _dtlNote = "";

        /// <summary>�q�ɃR�[�h[����]</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���[����]</summary>
        private string _warehouseName = "";

        /// <summary>�Ǝ�R�[�h[����]</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��[����]</summary>
        private string _businessTypeName = "";

        /// <summary>�̔��敪�R�[�h[����]</summary>
        private Int32 _salesCode;

        /// <summary>�̔��敪����[����]</summary>
        private string _salesCdNm = "";

        /// <summary>�Ԏ�S�p����[����]</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�^���i�t���^�j[����]</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�^���w��ԍ�[����]</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�[����]</summary>
        private Int32 _categoryNo;

        /// <summary>���q�Ǘ��R�[�h[����]</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

        /// <summary>���N�x[����]</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>�`�[���l�Q[����]</summary>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R[����]</summary>
        private string _slipNote3 = "";

        /// <summary>BL���i�R�[�h[����]</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j[����]</summary>
        private string _bLGoodsFullName = "";

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�t�n�d���}�[�N�P[����]</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q[����]</summary>
        private string _uoeRemark2 = "";

        /// <summary>�d�����גʔԁi�����j</summary>
        /// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
        private Int64 _stockSlipDtlNumSync;

        /// <summary>�d���`�[�ԍ�(����)</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>����œ]�ŕ���[�`�[]</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>���z�\�����@�敪[�`�[]</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>�ېŋ敪[����]</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>������z����Ŋz�i���Łj[�`�[] </summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>�艿�i�Ŕ��C�����j[����]</summary>
        private Double _listPriceTaxExcFl;

        /// <summary>����l������Ŋz�i�O�Łj[�`�[]</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>�������z(�l��)</summary>
        private Int64 _disCost;

        /// <summary>�󒍎c��</summary>
        /// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>�󒍐���</summary>
        /// <remarks>��,�o�ׂŎg�p</remarks>
        private Double _acceptAnOrderCnt;

        /// <summary>�󒍒�����</summary>
        /// <remarks>���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o</remarks>
        private Double _acptAnOdrAdjustCnt;


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h����[����]�v���p�e�B</summary>
        /// <value>���_���ݒ�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>���喼��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���喼��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h(�n��)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�n��)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A����(�n��)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A����(�n��)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h(�[����)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h(�[����)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於��(�[����)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��(�[����)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2(�[���ꏊ)[����]�v���p�e�B</summary>
        /// <value>�ǉ�(�o�^�R��) ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2(�[���ꏊ)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ���[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ���[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ�����[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ�����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ�����[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ�����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ�[�`�[]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ�[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪[�`�[]�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>���㏤�i�敪[����]�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪[����]�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  TransactionName
        /// <summary>����敪��[�`�[]�v���p�e�B</summary>
        /// <value>�����[�g���ŎZ�o(����`�[�敪�E���|�敪���g�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪��[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransactionName
        {
            get { return _transactionName; }
            set { _transactionName = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>�`�[�������t(���͓��t)[����]�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t(���͓��t)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>�o�ד��t[����]�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t(������)[����]�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t(������)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>�����敪[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ�[����]�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`�ԍ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v(�Ŕ�)[�`�[]�v���p�e�B</summary>
        /// <value>(�l�����܂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v(�Ŕ�)[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v(�ō�)[�`�[]�v���p�e�B</summary>
        /// <value>(�l�����܂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v(�ō�)[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxExc
        /// <summary>����l�����z�v(�Ŕ�)[�`�[]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����z�v(�Ŕ�)[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxExc
        {
            get { return _salesDisTtlTaxExc; }
            set { _salesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxInclu
        /// <summary>����l������Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i���Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxInclu
        {
            get { return _salesDisTtlTaxInclu; }
            set { _salesDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v[�`�[]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  GrossMarginRate
        /// <summary>�e����[�`�[]�v���p�e�B</summary>
        /// <value>�����[�g���ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e����[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrossMarginRate
        {
            get { return _grossMarginRate; }
            set { _grossMarginRate = value; }
        }

        /// public propaty name  :  GrossMarginMarkSlip
        /// <summary>�e���`�F�b�N�}�[�N[�`�[]�v���p�e�B</summary>
        /// <value>�����[�g���ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�}�[�N[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GrossMarginMarkSlip
        {
            get { return _grossMarginMarkSlip; }
            set { _grossMarginMarkSlip = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l[�`�[]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ�[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪[����]�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,9:�ꎮ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[����[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ�[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i����[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א�[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>��P��(����P��)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P��(����P��)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxIncFl
        /// <summary>����P��(�ō�)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P��(�ō�)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFl
        {
            get { return _salesUnPrcTaxIncFl; }
            set { _salesUnPrcTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P��(�Ŕ�)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P��(�Ŕ�)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>������z(�ō�)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�ō�)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z(�Ŕ�)[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�Ŕ�)[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>�������z[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  GrossMarginRateDtl
        /// <summary>�e����[����]�v���p�e�B</summary>
        /// <value>�����[�g���ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrossMarginRateDtl
        {
            get { return _grossMarginRateDtl; }
            set { _grossMarginRateDtl = value; }
        }

        /// public propaty name  :  GrossMarginMarkDtl
        /// <summary>�e���`�F�b�N�}�[�N[����]�v���p�e�B</summary>
        /// <value>�����[�g���ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�}�[�N[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GrossMarginMarkDtl
        {
            get { return _grossMarginMarkDtl; }
            set { _grossMarginMarkDtl = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>�����`�[�ԍ�[����]�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`No�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>���ה��l[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ה��l[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ���[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCdNm
        /// <summary>�̔��敪����[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCdNm
        {
            get { return _salesCdNm; }
            set { _salesCdNm = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ�S�p����[����]�v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�S�p����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j[����]�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ�[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ�[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ�[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>���q�Ǘ��R�[�h[����]�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x[����]�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>�`�[���l�Q[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>�`�[���l�R[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
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

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSync
        /// <summary>�d�����גʔԁi�����j�v���p�e�B</summary>
        /// <value>�����v�㎞�̎d�����גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSync
        {
            get { return _stockSlipDtlNumSync; }
            set { _stockSlipDtlNumSync = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ�(����)�v���p�e�B</summary>
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ�(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ���[�`�[]�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ���[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪[�`�[]�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪[����]�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  SalAmntConsTaxInclu
        /// <summary>������z����Ŋz�i���Łj[�`�[] �v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i���Łj[�`�[] �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  SalesDisOutTax
        /// <summary>����l������Ŋz�i�O�Łj[�`�[]�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i�O�Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisOutTax
        {
            get { return _salesDisOutTax; }
            set { _salesDisOutTax = value; }
        }

        /// public propaty name  :  DisCost
        /// <summary>�������z(�l��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z(�l��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DisCost
        {
            get { return _disCost; }
            set { _disCost = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>�󒍎c���v���p�e�B</summary>
        /// <value>�󒍐��ʁ{�󒍒������|�o�א�</value>
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

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// <value>��,�o�ׂŎg�p</value>
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

        /// public propaty name  :  AcptAnOdrAdjustCnt
        /// <summary>�󒍒������v���p�e�B</summary>
        /// <value>���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍒������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcptAnOdrAdjustCnt
        {
            get { return _acptAnOdrAdjustCnt; }
            set { _acptAnOdrAdjustCnt = value; }
        }


        /// <summary>
        /// �󒍑ݏo�m�F�\���o���ʃN���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OrderConfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderConfWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderConfWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OrderConfWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OrderConfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OrderConfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderConfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OrderConfWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OrderConfWork || graph is ArrayList || graph is OrderConfWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OrderConfWork).FullName));

            if (graph != null && graph is OrderConfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OrderConfWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OrderConfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OrderConfWork[])graph).Length;
            }
            else if (graph is OrderConfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h[����]
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����[����]
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //����R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���喼��[����]
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //���Ӑ�R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��[����]
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�̔��G���A�R�[�h(�n��)[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����(�n��)[����]
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //������R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����旪��[����]
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //�[�i��R�[�h(�[����)[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //�[�i�於��(�[����)[����]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //�[�i�於��2(�[���ꏊ)[����]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //������͎҃R�[�h[����]
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //������͎Җ���[����]
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //��t�]�ƈ��R�[�h[����]
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //��t�]�ƈ�����[����]
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //�̔��]�ƈ��R�[�h[����]
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��]�ƈ�����[����]
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //�󒍃X�e�[�^�X[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�[�`�[]
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�ԓ`�敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //����`�[�敪[�`�[]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //���㏤�i�敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //���|�敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //����敪��[�`�[]
            serInfo.MemberInfo.Add(typeof(string)); //TransactionName
            //�`�[�������t(���͓��t)[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //�o�ד��t[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //������t[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�v����t(������)[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�����敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //DelayPaymentDiv
            //�����`�[�ԍ�[����]
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //����`�[���v(�Ŕ�)[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //����`�[���v(�ō�)[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //����l�����z�v(�Ŕ�)[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxExc
            //����l������Ŋz�i���Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxInclu
            //�������z�v[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //�e����[�`�[]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRate
            //�e���`�F�b�N�}�[�N[�`�[]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkSlip
            //�`�[���l[�`�[]
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //����s�ԍ�[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //����`�[�敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //���i���[�J�[�R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����[����]
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�[����]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����[����]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�o�א�[����]
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //��P��(����P��)[����]
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //����P��(�ō�)[����]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //����P��(�Ŕ�)[����]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //������z(�ō�)[����]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //������z(�Ŕ�)[����]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�����P��[����]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //�������z[����]
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //�e����[����]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRateDtl
            //�e���`�F�b�N�}�[�N[����]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkDtl
            //�d����R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��[����]
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�����`�[�ԍ�[����]
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //���ה��l[����]
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //�q�ɃR�[�h[����]
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���[����]
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�Ǝ�R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��[����]
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //�̔��敪�R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�̔��敪����[����]
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //�Ԏ�S�p����[����]
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //�^���i�t���^�j[����]
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�^���w��ԍ�[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //���q�Ǘ��R�[�h[����]
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //���N�x[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //�`�[���l�Q[����]
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote2
            //�`�[���l�R[����]
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote3
            //BL���i�R�[�h[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j[����]
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //�t�n�d���}�[�N�P[����]
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q[����]
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�d�����גʔԁi�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSync
            //�d���`�[�ԍ�(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //����œ]�ŕ���[�`�[]
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //���z�\�����@�敪[�`�[]
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //�ېŋ敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //������z����Ŋz�i���Łj[�`�[] 
            serInfo.MemberInfo.Add(typeof(Int64)); //SalAmntConsTaxInclu
            //�艿�i�Ŕ��C�����j[����]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //����l������Ŋz�i�O�Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisOutTax
            //�������z(�l��)
            serInfo.MemberInfo.Add(typeof(Int64)); //DisCost
            //�󒍎c��
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //�󒍒�����
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrAdjustCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is OrderConfWork)
            {
                OrderConfWork temp = (OrderConfWork)graph;

                SetOrderConfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OrderConfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OrderConfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OrderConfWork temp in lst)
                {
                    SetOrderConfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OrderConfWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 91;

        /// <summary>
        ///  OrderConfWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderConfWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOrderConfWork(System.IO.BinaryWriter writer, OrderConfWork temp)
        {
            //���_�R�[�h[����]
            writer.Write(temp.SectionCode);
            //���_�K�C�h����[����]
            writer.Write(temp.SectionGuideNm);
            //����R�[�h[����]
            writer.Write(temp.SubSectionCode);
            //���喼��[����]
            writer.Write(temp.SubSectionName);
            //���Ӑ�R�[�h[����]
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��[����]
            writer.Write(temp.CustomerSnm);
            //�̔��G���A�R�[�h(�n��)[����]
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����(�n��)[����]
            writer.Write(temp.SalesAreaName);
            //������R�[�h[����]
            writer.Write(temp.ClaimCode);
            //�����旪��[����]
            writer.Write(temp.ClaimSnm);
            //�[�i��R�[�h(�[����)[����]
            writer.Write(temp.AddresseeCode);
            //�[�i�於��(�[����)[����]
            writer.Write(temp.AddresseeName);
            //�[�i�於��2(�[���ꏊ)[����]
            writer.Write(temp.AddresseeName2);
            //������͎҃R�[�h[����]
            writer.Write(temp.SalesInputCode);
            //������͎Җ���[����]
            writer.Write(temp.SalesInputName);
            //��t�]�ƈ��R�[�h[����]
            writer.Write(temp.FrontEmployeeCd);
            //��t�]�ƈ�����[����]
            writer.Write(temp.FrontEmployeeNm);
            //�̔��]�ƈ��R�[�h[����]
            writer.Write(temp.SalesEmployeeCd);
            //�̔��]�ƈ�����[����]
            writer.Write(temp.SalesEmployeeNm);
            //�󒍃X�e�[�^�X[����]
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�[�`�[]
            writer.Write(temp.SalesSlipNum);
            //�ԓ`�敪[����]
            writer.Write(temp.DebitNoteDiv);
            //����`�[�敪[�`�[]
            writer.Write(temp.SalesSlipCd);
            //���㏤�i�敪[����]
            writer.Write(temp.SalesGoodsCd);
            //���|�敪[����]
            writer.Write(temp.AccRecDivCd);
            //����敪��[�`�[]
            writer.Write(temp.TransactionName);
            //�`�[�������t(���͓��t)[����]
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //�o�ד��t[����]
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //������t[����]
            writer.Write((Int64)temp.SalesDate.Ticks);
            //�v����t(������)[����]
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�����敪[����]
            writer.Write(temp.DelayPaymentDiv);
            //�����`�[�ԍ�[����]
            writer.Write(temp.PartySaleSlipNum);
            //����`�[���v(�Ŕ�)[�`�[]
            writer.Write(temp.SalesTotalTaxExc);
            //����`�[���v(�ō�)[�`�[]
            writer.Write(temp.SalesTotalTaxInc);
            //����l�����z�v(�Ŕ�)[�`�[]
            writer.Write(temp.SalesDisTtlTaxExc);
            //����l������Ŋz�i���Łj[�`�[]
            writer.Write(temp.SalesDisTtlTaxInclu);
            //�������z�v[�`�[]
            writer.Write(temp.TotalCost);
            //�e����[�`�[]
            writer.Write(temp.GrossMarginRate);
            //�e���`�F�b�N�}�[�N[�`�[]
            writer.Write(temp.GrossMarginMarkSlip);
            //�`�[���l[�`�[]
            writer.Write(temp.SlipNote);
            //����s�ԍ�[����]
            writer.Write(temp.SalesRowNo);
            //����`�[�敪[����]
            writer.Write(temp.SalesSlipCdDtl);
            //���i���[�J�[�R�[�h[����]
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����[����]
            writer.Write(temp.MakerName);
            //���i�ԍ�[����]
            writer.Write(temp.GoodsNo);
            //���i����[����]
            writer.Write(temp.GoodsName);
            //�o�א�[����]
            writer.Write(temp.ShipmentCnt);
            //��P��(����P��)[����]
            writer.Write(temp.StdUnPrcSalUnPrc);
            //����P��(�ō�)[����]
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //����P��(�Ŕ�)[����]
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //������z(�ō�)[����]
            writer.Write(temp.SalesMoneyTaxInc);
            //������z(�Ŕ�)[����]
            writer.Write(temp.SalesMoneyTaxExc);
            //�����P��[����]
            writer.Write(temp.SalesUnitCost);
            //�������z[����]
            writer.Write(temp.Cost);
            //�e����[����]
            writer.Write(temp.GrossMarginRateDtl);
            //�e���`�F�b�N�}�[�N[����]
            writer.Write(temp.GrossMarginMarkDtl);
            //�d����R�[�h[����]
            writer.Write(temp.SupplierCd);
            //�d���旪��[����]
            writer.Write(temp.SupplierSnm);
            //�����`�[�ԍ�[����]
            writer.Write(temp.PartySlipNumDtl);
            //���ה��l[����]
            writer.Write(temp.DtlNote);
            //�q�ɃR�[�h[����]
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���[����]
            writer.Write(temp.WarehouseName);
            //�Ǝ�R�[�h[����]
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��[����]
            writer.Write(temp.BusinessTypeName);
            //�̔��敪�R�[�h[����]
            writer.Write(temp.SalesCode);
            //�̔��敪����[����]
            writer.Write(temp.SalesCdNm);
            //�Ԏ�S�p����[����]
            writer.Write(temp.ModelFullName);
            //�^���i�t���^�j[����]
            writer.Write(temp.FullModel);
            //�^���w��ԍ�[����]
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�[����]
            writer.Write(temp.CategoryNo);
            //���q�Ǘ��R�[�h[����]
            writer.Write(temp.CarMngCode);
            //���N�x[����]
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //�`�[���l�Q[����]
            writer.Write(temp.SlipNote2);
            //�`�[���l�R[����]
            writer.Write(temp.SlipNote3);
            //BL���i�R�[�h[����]
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j[����]
            writer.Write(temp.BLGoodsFullName);
            //����݌Ɏ�񂹋敪
            writer.Write(temp.SalesOrderDivCd);
            //�t�n�d���}�[�N�P[����]
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q[����]
            writer.Write(temp.UoeRemark2);
            //�d�����גʔԁi�����j
            writer.Write(temp.StockSlipDtlNumSync);
            //�d���`�[�ԍ�(����)
            writer.Write(temp.SupplierSlipNo);
            //����œ]�ŕ���[�`�[]
            writer.Write(temp.ConsTaxLayMethod);
            //���z�\�����@�敪[�`�[]
            writer.Write(temp.TotalAmountDispWayCd);
            //�ېŋ敪[����]
            writer.Write(temp.TaxationDivCd);
            //������z����Ŋz�i���Łj[�`�[] 
            writer.Write(temp.SalAmntConsTaxInclu);
            //�艿�i�Ŕ��C�����j[����]
            writer.Write(temp.ListPriceTaxExcFl);
            //����l������Ŋz�i�O�Łj[�`�[]
            writer.Write(temp.SalesDisOutTax);
            //�������z(�l��)
            writer.Write(temp.DisCost);
            //�󒍎c��
            writer.Write(temp.AcptAnOdrRemainCnt);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //�󒍒�����
            writer.Write(temp.AcptAnOdrAdjustCnt);

        }

        /// <summary>
        ///  OrderConfWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OrderConfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderConfWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OrderConfWork GetOrderConfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OrderConfWork temp = new OrderConfWork();

            //���_�R�[�h[����]
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����[����]
            temp.SectionGuideNm = reader.ReadString();
            //����R�[�h[����]
            temp.SubSectionCode = reader.ReadInt32();
            //���喼��[����]
            temp.SubSectionName = reader.ReadString();
            //���Ӑ�R�[�h[����]
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��[����]
            temp.CustomerSnm = reader.ReadString();
            //�̔��G���A�R�[�h(�n��)[����]
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����(�n��)[����]
            temp.SalesAreaName = reader.ReadString();
            //������R�[�h[����]
            temp.ClaimCode = reader.ReadInt32();
            //�����旪��[����]
            temp.ClaimSnm = reader.ReadString();
            //�[�i��R�[�h(�[����)[����]
            temp.AddresseeCode = reader.ReadInt32();
            //�[�i�於��(�[����)[����]
            temp.AddresseeName = reader.ReadString();
            //�[�i�於��2(�[���ꏊ)[����]
            temp.AddresseeName2 = reader.ReadString();
            //������͎҃R�[�h[����]
            temp.SalesInputCode = reader.ReadString();
            //������͎Җ���[����]
            temp.SalesInputName = reader.ReadString();
            //��t�]�ƈ��R�[�h[����]
            temp.FrontEmployeeCd = reader.ReadString();
            //��t�]�ƈ�����[����]
            temp.FrontEmployeeNm = reader.ReadString();
            //�̔��]�ƈ��R�[�h[����]
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��]�ƈ�����[����]
            temp.SalesEmployeeNm = reader.ReadString();
            //�󒍃X�e�[�^�X[����]
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�[�`�[]
            temp.SalesSlipNum = reader.ReadString();
            //�ԓ`�敪[����]
            temp.DebitNoteDiv = reader.ReadInt32();
            //����`�[�敪[�`�[]
            temp.SalesSlipCd = reader.ReadInt32();
            //���㏤�i�敪[����]
            temp.SalesGoodsCd = reader.ReadInt32();
            //���|�敪[����]
            temp.AccRecDivCd = reader.ReadInt32();
            //����敪��[�`�[]
            temp.TransactionName = reader.ReadString();
            //�`�[�������t(���͓��t)[����]
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //�o�ד��t[����]
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //������t[����]
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //�v����t(������)[����]
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�����敪[����]
            temp.DelayPaymentDiv = reader.ReadInt32();
            //�����`�[�ԍ�[����]
            temp.PartySaleSlipNum = reader.ReadString();
            //����`�[���v(�Ŕ�)[�`�[]
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //����`�[���v(�ō�)[�`�[]
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //����l�����z�v(�Ŕ�)[�`�[]
            temp.SalesDisTtlTaxExc = reader.ReadInt64();
            //����l������Ŋz�i���Łj[�`�[]
            temp.SalesDisTtlTaxInclu = reader.ReadInt64();
            //�������z�v[�`�[]
            temp.TotalCost = reader.ReadInt64();
            //�e����[�`�[]
            temp.GrossMarginRate = reader.ReadDouble();
            //�e���`�F�b�N�}�[�N[�`�[]
            temp.GrossMarginMarkSlip = reader.ReadString();
            //�`�[���l[�`�[]
            temp.SlipNote = reader.ReadString();
            //����s�ԍ�[����]
            temp.SalesRowNo = reader.ReadInt32();
            //����`�[�敪[����]
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //���i���[�J�[�R�[�h[����]
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����[����]
            temp.MakerName = reader.ReadString();
            //���i�ԍ�[����]
            temp.GoodsNo = reader.ReadString();
            //���i����[����]
            temp.GoodsName = reader.ReadString();
            //�o�א�[����]
            temp.ShipmentCnt = reader.ReadDouble();
            //��P��(����P��)[����]
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //����P��(�ō�)[����]
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //����P��(�Ŕ�)[����]
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //������z(�ō�)[����]
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //������z(�Ŕ�)[����]
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�����P��[����]
            temp.SalesUnitCost = reader.ReadDouble();
            //�������z[����]
            temp.Cost = reader.ReadInt64();
            //�e����[����]
            temp.GrossMarginRateDtl = reader.ReadDouble();
            //�e���`�F�b�N�}�[�N[����]
            temp.GrossMarginMarkDtl = reader.ReadString();
            //�d����R�[�h[����]
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��[����]
            temp.SupplierSnm = reader.ReadString();
            //�����`�[�ԍ�[����]
            temp.PartySlipNumDtl = reader.ReadString();
            //���ה��l[����]
            temp.DtlNote = reader.ReadString();
            //�q�ɃR�[�h[����]
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���[����]
            temp.WarehouseName = reader.ReadString();
            //�Ǝ�R�[�h[����]
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��[����]
            temp.BusinessTypeName = reader.ReadString();
            //�̔��敪�R�[�h[����]
            temp.SalesCode = reader.ReadInt32();
            //�̔��敪����[����]
            temp.SalesCdNm = reader.ReadString();
            //�Ԏ�S�p����[����]
            temp.ModelFullName = reader.ReadString();
            //�^���i�t���^�j[����]
            temp.FullModel = reader.ReadString();
            //�^���w��ԍ�[����]
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�[����]
            temp.CategoryNo = reader.ReadInt32();
            //���q�Ǘ��R�[�h[����]
            temp.CarMngCode = reader.ReadString();
            //���N�x[����]
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //�`�[���l�Q[����]
            temp.SlipNote2 = reader.ReadString();
            //�`�[���l�R[����]
            temp.SlipNote3 = reader.ReadString();
            //BL���i�R�[�h[����]
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j[����]
            temp.BLGoodsFullName = reader.ReadString();
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
            //�t�n�d���}�[�N�P[����]
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q[����]
            temp.UoeRemark2 = reader.ReadString();
            //�d�����גʔԁi�����j
            temp.StockSlipDtlNumSync = reader.ReadInt64();
            //�d���`�[�ԍ�(����)
            temp.SupplierSlipNo = reader.ReadInt32();
            //����œ]�ŕ���[�`�[]
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //���z�\�����@�敪[�`�[]
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //�ېŋ敪[����]
            temp.TaxationDivCd = reader.ReadInt32();
            //������z����Ŋz�i���Łj[�`�[] 
            temp.SalAmntConsTaxInclu = reader.ReadInt64();
            //�艿�i�Ŕ��C�����j[����]
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //����l������Ŋz�i�O�Łj[�`�[]
            temp.SalesDisOutTax = reader.ReadInt64();
            //�������z(�l��)
            temp.DisCost = reader.ReadInt64();
            //�󒍎c��
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //�󒍒�����
            temp.AcptAnOdrAdjustCnt = reader.ReadDouble();


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
        /// <returns>OrderConfWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderConfWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OrderConfWork temp = GetOrderConfWork(reader, serInfo);
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
                    retValue = (OrderConfWork[])lst.ToArray(typeof(OrderConfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

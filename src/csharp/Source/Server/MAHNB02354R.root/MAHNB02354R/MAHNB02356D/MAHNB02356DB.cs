using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesConfWork
    /// <summary>
    ///                      ����m�F�\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����m�F�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/31  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2010/06/29 30517 �Ė� �x��</br>
    /// <br>                     Mantis.15691�@�Ԏ햼�̈󎚂��Ԏ�S�p���̂���Ԏ피�p���̂֕ύX����B</br>
    /// <br></br>
    /// <br>Update Note      :   2010/07/14 30531 ��� �r��</br>
    /// <br>                 :   Mantis�y15806�z  �i���ɕi���J�i���Z�b�g����悤�ɏC��</br>
    /// <br>Update Note      :   2011/07/18 �{��</br>
    /// <br>                 :   �uSCM�񓚃}�[�N�󎚋敪�v�A�u�ʏ픭�s�}�[�N�v�A�uSCM�蓮�񓚃}�[�N�v�A�uSCM�����񓚃}�[�N�v�A�u�����񓚋敪(SCM)�v��ǉ�����</br>
    /// <br>Update Note      :   2011/11/29 ����</br>
    /// <br>                 :   ��Q�� #8076����m�F�\/�����`�[�ƍ폜�`�[�̋�ʂɂ��Ă̑Ή�</br>
    /// <br>Update Note      :   2020/02/27 3H ����</br>
    /// <br>�Ǘ��ԍ�         :   11570208-00 </br>
    /// <br>                 :   �y���ŗ��Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesConfWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���喼��</summary>
        private string _subSectionName = "";

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ�������</remarks>
        private string _salesSlipNum = "";

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>������͎Җ���</summary>
        private string _salesInputName = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>�������z�v</summary>
        private Int64 _totalCost;

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>�ԕi���R</summary>
        private string _retGoodsReason = "";

        /// <summary>���Ӑ�`�[�ԍ�</summary>
        private Int32 _custSlipNo;

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        private string _slipNote3 = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>������</summary>
        private Double _salesRate;

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>�����P��</summary>
        private Double _salesUnitCost;

        /// <summary>����P���i�ō��C�����j</summary>
        private Double _salesUnPrcTaxIncFl;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>����</summary>
        private Int64 _cost;

        /// <summary>������z�i�ō��݁j</summary>
        private Int64 _salesMoneyTaxInc;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

        /// <summary>�̔��敪����</summary>
        private string _salesCdNm = "";

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

        /// <summary>���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>����敪��[�`�[]</summary>
        private string _transactionName = "";

        /// <summary>�e����[�`�[]</summary>
        private Double _grossMarginRate;

        /// <summary>�e���`�F�b�N�}�[�N[�`�[]</summary>
        private string _grossMarginMarkSlip = "";

        /// <summary>�e����[����]</summary>
        private Double _grossMarginRateDtl;

        /// <summary>�e���`�F�b�N�}�[�N[����]</summary>
        private string _grossMarginMarkDtl = "";

        /// <summary>����`�[�敪�i���ׁj</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>����l�����z�v�i�Ŕ����j</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _searchSlipDate;

        /// <summary>����œ]�ŕ���[�`�[]</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>���z�\�����@�敪[�`�[]</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>�ېŋ敪[����]</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>������z����Ŋz�i���Łj[�`�[]</summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>����l������Ŋz�i���Łj[�`�[]</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>����l������Ŋz�i�O�Łj[�`�[]</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>�������z(�l��)</summary>
        private Int64 _disCost;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _partySaleSlipNumStock = "";

        // 2010/06/29 Add >>>
        /// <summary>�Ԏ피�p����</summary>
        private string _modelHalfName = "";
        // 2010/06/29 Add <<<
        // --- ADD  ���r��  2010/07/14 ---------->>>>>
        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";
        // --- ADD  ���r��  2010/07/14 ----------<<<<<

        // --- ADD  �{��  2011/07/18 ---------->>>>>
        /// <summary>SCM�񓚃}�[�N�󎚋敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _sCMAnsMarkPrtDiv;

        /// <summary>�ʏ픭�s�}�[�N</summary>
        private string _normalPrtMark = "";

        /// <summary>SCM�蓮�񓚃}�[�N</summary>
        private string _sCMManualAnsMark = "";

        /// <summary>SCM�����񓚃}�[�N</summary>
        private string _sCMAutoAnsMark = "";

        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;
        // --- ADD  �{��  2011/07/18 ----------<<<<<

        // --- ADD  ����  2010/11/29--------->>>>>>
        /// <summary>�폜�敪</summary>
        /// <remarks>0:���폜�A1:�폜</remarks>
        private Int32 _logicalDeleteCode;

        // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        /// <summary>������z��ې�</summary>
        private Int64 _salesMoneyTaxFreeCdrf;

        /// <summary>���㖾�׉ېő��݃t���O</summary>
        private bool _taxRateExistFlag;

        /// <summary>���㖾�ה�ېő��݃t���O</summary>
        private bool _taxFreeExistFlag;
        // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

        
        // --- ADD  ����  2010/11/29---------<<<<<<
        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary>����Őŗ�</summary>
        private Double _consTaxRate;

        /// public propaty name  :  SectionCode
        /// <summary>����Őŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>���喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ�������</value>
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

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
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

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
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

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
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

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S���ҁi�󒍎ҁj</value>
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

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
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

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`�ԍ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  RetGoodsReasonDiv
        /// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetGoodsReasonDiv
        {
            get { return _retGoodsReasonDiv; }
            set { _retGoodsReasonDiv = value; }
        }

        /// public propaty name  :  RetGoodsReason
        /// <summary>�ԕi���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RetGoodsReason
        {
            get { return _retGoodsReason; }
            set { _retGoodsReason = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>�`�[���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>�`�[���l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
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

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
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

        /// public propaty name  :  SalesRate
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
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

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
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

        /// public propaty name  :  SalesUnPrcTaxIncFl
        /// <summary>����P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFl
        {
            get { return _salesUnPrcTaxIncFl; }
            set { _salesUnPrcTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
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

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>������z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
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
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCdNm
        /// <summary>�̔��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCdNm
        {
            get { return _salesCdNm; }
            set { _salesCdNm = value; }
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

        /// public propaty name  :  CarMngCode
        /// <summary>���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
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

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  TransactionName
        /// <summary>����敪��[�`�[]�v���p�e�B</summary>
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

        /// public propaty name  :  GrossMarginRate
        /// <summary>�e����[�`�[]�v���p�e�B</summary>
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

        /// public propaty name  :  GrossMarginRateDtl
        /// <summary>�e����[����]�v���p�e�B</summary>
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

        /// public propaty name  :  SalesDisTtlTaxExc
        /// <summary>����l�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxExc
        {
            get { return _salesDisTtlTaxExc; }
            set { _salesDisTtlTaxExc = value; }
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

        /// public propaty name  :  SearchSlipDate
        /// <summary>�`�[�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
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
        /// <summary>������z����Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i���Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
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

        /// public propaty name  :  PartySaleSlipNumStock
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNumStock
        {
            get { return _partySaleSlipNumStock; }
            set { _partySaleSlipNumStock = value; }
        }

        // 2010/06/29 Add >>>
        /// public propaty name  :  ModelHalfName
        /// <summary>�Ԏ피�p���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ피�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }
        // 2010/06/29 Add <<<

        // --- ADD  ���r��  2010/07/14 ---------->>>>>
        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }
        // --- ADD  ���r��  2010/07/14 ----------<<<<<

        // --- ADD  �{��  2011/07/18 ---------->>>>>
        /// public propaty name  :  SCMAnsMarkPrtDiv
        /// <summary>SCM�񓚃}�[�N�󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�񓚃}�[�N�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SCMAnsMarkPrtDiv
        {
            get { return _sCMAnsMarkPrtDiv; }
            set { _sCMAnsMarkPrtDiv = value; }
        }

        /// public propaty name  :  NormalPrtMark
        /// <summary>�ʏ픭�s�}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʏ픭�s�}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NormalPrtMark
        {
            get { return _normalPrtMark; }
            set { _normalPrtMark = value; }
        }

        /// public propaty name  :  SCMManualAnsMark
        /// <summary>SCM�蓮�񓚃}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�蓮�񓚃}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SCMManualAnsMark
        {
            get { return _sCMManualAnsMark; }
            set { _sCMManualAnsMark = value; }
        }

        /// public propaty name  :  SCMAutoAnsMark
        /// <summary>SCM�����񓚃}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�����񓚃}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SCMAutoAnsMark
        {
            get { return _sCMAutoAnsMark; }
            set { _sCMAutoAnsMark = value; }
        }

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪(SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        // --- ADD  �{��  2011/07/18 ----------<<<<<

        // --- ADD  ����  2010/11/29--------->>>>>>
        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�폜�敪</summary>
        /// <value>0:���폜�A1:�폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }
        // --- ADD  ����  2010/11/29---------<<<<<<<

        // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        /// public propaty name  :  SalesMoneyTaxFreeCdrf
        /// <summary>������z��ې�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z��ېŃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxFreeCdrf
        {
            get { return _salesMoneyTaxFreeCdrf; }
            set { _salesMoneyTaxFreeCdrf = value; }
        }

        /// public propaty name  :  TaxRateExistFlag
        /// <summary>���㖾�׉ېő��݃t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���㖾�׉ېő��݃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TaxRateExistFlag
        {
            get { return _taxRateExistFlag; }
            set { _taxRateExistFlag = value; }
        }

        /// public propaty name  :  TaxFreeExistFlag
        /// <summary>���㖾�ה�ېő��݃t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���㖾�ה�ېő��݃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TaxFreeExistFlag
        {
            get { return _taxFreeExistFlag; }
            set { _taxFreeExistFlag = value; }
        }
        // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

        /// <summary>
        /// ����m�F�\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesConfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesConfWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesConfWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesConfWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesConfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesConfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesConfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesConfWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesConfWork || graph is ArrayList || graph is SalesConfWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesConfWork).FullName));

            if (graph != null && graph is SalesConfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesConfWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesConfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesConfWork[])graph).Length;
            }
            else if (graph is SalesConfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���喼��
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�o�ד��t
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //����`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //�������z�v
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //�ԕi���R
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //���Ӑ�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNo
            //�`�[���l
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //�`�[���l�Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote2
            //�`�[���l�R
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote3
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //����P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //������z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�̔��敪����
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //���q�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //���N�x
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //����敪��[�`�[]
            serInfo.MemberInfo.Add(typeof(string)); //TransactionName
            //�e����[�`�[]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRate
            //�e���`�F�b�N�}�[�N[�`�[]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkSlip
            //�e����[����]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRateDtl
            //�e���`�F�b�N�}�[�N[����]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkDtl
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //����l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxExc
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //�`�[�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //����œ]�ŕ���[�`�[]
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //���z�\�����@�敪[�`�[]
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //�ېŋ敪[����]
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //������z����Ŋz�i���Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalAmntConsTaxInclu
            //����l������Ŋz�i���Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxInclu
            //����l������Ŋz�i�O�Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisOutTax
            //�������z(�l��)
            serInfo.MemberInfo.Add(typeof(Int64)); //DisCost
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNumStock
            //�Ԏ피�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            // --- ADD  ���r��  2010/07/14 ---------->>>>>
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            // --- ADD  ���r��  2010/07/14 ----------<<<<<
            // --- ADD  �{��  2011/07/18 ---------->>>>>
            //SCM�񓚃}�[�N�󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SCMAnsMarkPrtDiv
            //�ʏ픭�s�}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //NormalPrtMark
            //SCM�蓮�񓚃}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //SCMManualAnsMark
            //SCM�����񓚃}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //SCMAutoAnsMark
            //�����񓚋敪(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            // --- ADD  �{��  2011/07/18 ----------<<<<<
            // --- ADD  ����  2010/11/29--------->>>>>>
            //�폜�敪�}�[�N
            serInfo.MemberInfo.Add(typeof(Int32));
            // --- ADD  ����  2010/11/29---------<<<<<<
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // ����Őŗ�
            serInfo.MemberInfo.Add(typeof(Double));
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is SalesConfWork)
            {
                SalesConfWork temp = (SalesConfWork)graph;

                SetSalesConfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesConfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesConfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesConfWork temp in lst)
                {
                    SetSalesConfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesConfWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD  �{��  2011/07/18 ---------->>>>>
        // --- UPD  ���r��  2010/07/14 ---------->>>>>
        // 2010/06/29 >>>
        //private const int currentMemberCount = 82;
        //private const int currentMemberCount = 83;
        //private const int currentMemberCount = 84;
        //private const int currentMemberCount = 89;// --- DEL  ����  2010/11/29
        //private const int currentMemberCount = 90;// --- ADD  ����  2010/11/29  // --- DEL 3H ���� 2020/02/27
        private const int currentMemberCount = 91;  // --- ADD 3H ���� 2020/02/27
        // 2010/06/29 <<<
        // --- UPD  ���r��  2010/07/14 ----------<<<<<
        // --- UPD  �{��  2011/07/18 ----------<<<<<
        /// <summary>
        ///  SalesConfWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesConfWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesConfWork(System.IO.BinaryWriter writer, SalesConfWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���喼��
            writer.Write(temp.SubSectionName);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�o�ד��t
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //����`�[�敪
            writer.Write(temp.SalesSlipCd);
            //���|�敪
            writer.Write(temp.AccRecDivCd);
            //������͎҃R�[�h
            writer.Write(temp.SalesInputCode);
            //������͎Җ���
            writer.Write(temp.SalesInputName);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //��t�]�ƈ�����
            writer.Write(temp.FrontEmployeeNm);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //����`�[���v�i�ō��݁j
            writer.Write(temp.SalesTotalTaxInc);
            //����`�[���v�i�Ŕ����j
            writer.Write(temp.SalesTotalTaxExc);
            //�������z�v
            writer.Write(temp.TotalCost);
            //�ԕi���R�R�[�h
            writer.Write(temp.RetGoodsReasonDiv);
            //�ԕi���R
            writer.Write(temp.RetGoodsReason);
            //���Ӑ�`�[�ԍ�
            writer.Write(temp.CustSlipNo);
            //�`�[���l
            writer.Write(temp.SlipNote);
            //�`�[���l�Q
            writer.Write(temp.SlipNote2);
            //�`�[���l�R
            writer.Write(temp.SlipNote3);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��
            writer.Write(temp.BusinessTypeName);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //����݌Ɏ�񂹋敪
            writer.Write(temp.SalesOrderDivCd);
            //�艿�i�ō��C�����j
            writer.Write(temp.ListPriceTaxIncFl);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //������
            writer.Write(temp.SalesRate);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //����P���i�ō��C�����j
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //����
            writer.Write(temp.Cost);
            //������z�i�ō��݁j
            writer.Write(temp.SalesMoneyTaxInc);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //�̔��敪����
            writer.Write(temp.SalesCdNm);
            //�Ԏ�S�p����
            writer.Write(temp.ModelFullName);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //���q�Ǘ��R�[�h
            writer.Write(temp.CarMngCode);
            //���N�x
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //����敪��[�`�[]
            writer.Write(temp.TransactionName);
            //�e����[�`�[]
            writer.Write(temp.GrossMarginRate);
            //�e���`�F�b�N�}�[�N[�`�[]
            writer.Write(temp.GrossMarginMarkSlip);
            //�e����[����]
            writer.Write(temp.GrossMarginRateDtl);
            //�e���`�F�b�N�}�[�N[����]
            writer.Write(temp.GrossMarginMarkDtl);
            //����`�[�敪�i���ׁj
            writer.Write(temp.SalesSlipCdDtl);
            //����l�����z�v�i�Ŕ����j
            writer.Write(temp.SalesDisTtlTaxExc);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //�`�[�������t
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //����œ]�ŕ���[�`�[]
            writer.Write(temp.ConsTaxLayMethod);
            //���z�\�����@�敪[�`�[]
            writer.Write(temp.TotalAmountDispWayCd);
            //�ېŋ敪[����]
            writer.Write(temp.TaxationDivCd);
            //������z����Ŋz�i���Łj[�`�[]
            writer.Write(temp.SalAmntConsTaxInclu);
            //����l������Ŋz�i���Łj[�`�[]
            writer.Write(temp.SalesDisTtlTaxInclu);
            //����l������Ŋz�i�O�Łj[�`�[]
            writer.Write(temp.SalesDisOutTax);
            //�������z(�l��)
            writer.Write(temp.DisCost);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNumStock);
            //�Ԏ피�p����
            writer.Write(temp.ModelHalfName);
            // --- ADD  ���r��  2010/07/14 ---------->>>>>
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            // --- ADD  ���r��  2010/07/14 ----------<<<<<
            // --- ADD  �{��  2011/07/18 ---------->>>>>
            //SCM�񓚃}�[�N�󎚋敪
            writer.Write(temp.SCMAnsMarkPrtDiv);
            //�ʏ픭�s�}�[�N
            writer.Write(temp.NormalPrtMark);
            //SCM�蓮�񓚃}�[�N
            writer.Write(temp.SCMManualAnsMark);
            //SCM�����񓚃}�[�N
            writer.Write(temp.SCMAutoAnsMark);
            //�����񓚋敪(SCM)
            writer.Write(temp.AutoAnswerDivSCM);
            // --- ADD  �{��  2011/07/18 ----------<<<<<
            // --- ADD  ����  2010/11/29--------->>>>>>
            //�폜�敪�}�[�N
            writer.Write(temp.LogicalDeleteCode);
            // --- ADD  ����  2010/11/29---------<<<<<<
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // ����Őŗ�
            writer.Write(temp.ConsTaxRate);
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--------->>>>>>
            // ������z��ې�
            writer.Write(temp.SalesMoneyTaxFreeCdrf);
            // ���㖾�׉ېő��݃t���O
            writer.Write(temp.TaxRateExistFlag);
            // ���㖾�ה�ېő��݃t���O
            writer.Write(temp.TaxFreeExistFlag);
            // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---------<<<<<<
        }

        /// <summary>
        ///  SalesConfWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesConfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesConfWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesConfWork GetSalesConfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesConfWork temp = new SalesConfWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���喼��
            temp.SubSectionName = reader.ReadString();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�o�ד��t
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //����`�[�敪
            temp.SalesSlipCd = reader.ReadInt32();
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //������͎Җ���
            temp.SalesInputName = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //����`�[���v�i�ō��݁j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //����`�[���v�i�Ŕ����j
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //�������z�v
            temp.TotalCost = reader.ReadInt64();
            //�ԕi���R�R�[�h
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //�ԕi���R
            temp.RetGoodsReason = reader.ReadString();
            //���Ӑ�`�[�ԍ�
            temp.CustSlipNo = reader.ReadInt32();
            //�`�[���l
            temp.SlipNote = reader.ReadString();
            //�`�[���l�Q
            temp.SlipNote2 = reader.ReadString();
            //�`�[���l�R
            temp.SlipNote3 = reader.ReadString();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��
            temp.BusinessTypeName = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
            //�艿�i�ō��C�����j
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //������
            temp.SalesRate = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //����P���i�ō��C�����j
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //����
            temp.Cost = reader.ReadInt64();
            //������z�i�ō��݁j
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //�̔��敪����
            temp.SalesCdNm = reader.ReadString();
            //�Ԏ�S�p����
            temp.ModelFullName = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //���q�Ǘ��R�[�h
            temp.CarMngCode = reader.ReadString();
            //���N�x
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //����敪��[�`�[]
            temp.TransactionName = reader.ReadString();
            //�e����[�`�[]
            temp.GrossMarginRate = reader.ReadDouble();
            //�e���`�F�b�N�}�[�N[�`�[]
            temp.GrossMarginMarkSlip = reader.ReadString();
            //�e����[����]
            temp.GrossMarginRateDtl = reader.ReadDouble();
            //�e���`�F�b�N�}�[�N[����]
            temp.GrossMarginMarkDtl = reader.ReadString();
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //����l�����z�v�i�Ŕ����j
            temp.SalesDisTtlTaxExc = reader.ReadInt64();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //�`�[�������t
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //����œ]�ŕ���[�`�[]
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //���z�\�����@�敪[�`�[]
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //�ېŋ敪[����]
            temp.TaxationDivCd = reader.ReadInt32();
            //������z����Ŋz�i���Łj[�`�[]
            temp.SalAmntConsTaxInclu = reader.ReadInt64();
            //����l������Ŋz�i���Łj[�`�[]
            temp.SalesDisTtlTaxInclu = reader.ReadInt64();
            //����l������Ŋz�i�O�Łj[�`�[]
            temp.SalesDisOutTax = reader.ReadInt64();
            //�������z(�l��)
            temp.DisCost = reader.ReadInt64();
            //�����`�[�ԍ�
            temp.PartySaleSlipNumStock = reader.ReadString();
            //�Ԏ피�p����
            temp.ModelHalfName = reader.ReadString();
            // --- ADD  ���r��  2010/07/14 ---------->>>>>
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            // --- ADD  ���r��  2010/07/14 ----------<<<<<
            // --- ADD  �{��  2011/07/18 ---------->>>>>
            //SCM�񓚃}�[�N�󎚋敪
            temp.SCMAnsMarkPrtDiv = reader.ReadInt32();
            //�ʏ픭�s�}�[�N
            temp.NormalPrtMark = reader.ReadString();
            //SCM�蓮�񓚃}�[�N
            temp.SCMManualAnsMark = reader.ReadString();
            //SCM�����񓚃}�[�N
            temp.SCMAutoAnsMark = reader.ReadString();
            //�����񓚋敪(SCM)
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            // --- ADD  �{��  2011/07/18 ----------<<<<<
            // --- ADD  ����  2010/11/29--------->>>>>>
            //�폜�敪�}�[�N
            temp.LogicalDeleteCode = reader.ReadInt32();
            // --- ADD  ����  2010/11/29---------<<<<<<
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // ����Őŗ�
            temp.ConsTaxRate = reader.ReadDouble();
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<

            // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--------->>>>>>
            temp.SalesMoneyTaxFreeCdrf = reader.ReadInt64();
            temp.TaxRateExistFlag = reader.ReadBoolean();
            temp.TaxFreeExistFlag = reader.ReadBoolean();
            // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---------<<<<<
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
        /// <returns>SalesConfWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesConfWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesConfWork temp = GetSalesConfWork(reader, serInfo);
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
                    retValue = (SalesConfWork[])lst.ToArray(typeof(SalesConfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

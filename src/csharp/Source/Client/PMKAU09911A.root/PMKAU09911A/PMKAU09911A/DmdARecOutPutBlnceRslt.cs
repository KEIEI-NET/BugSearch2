using System;
using System.Collections;

namespace Broadleaf.Application.Controller
{       
    /// <summary>
    /// �����c�E���|�c�e�L�X�g�o�́@���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����c�E���|�c�e�L�X�g�o�́@���ʃN���X</br>
    /// <br>Programmer       :   30521 �{�R�@�M��</br>
    /// <br>Date             :   2014/08/25</br>
    /// </remarks>
    public class DmdARecOutPutBlnceRslt
    {
        /// <summary>�������</summary>
        /// <remarks>���������+1���Z�b�g</remarks>
        private Int64 _searchCnt;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�J�n������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_SalesDate;

        /// <summary>�I��������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_SalesDate;

        /// <summary>�J�n���͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_AddUpADate;

        /// <summary>�I�����͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_AddUpADate;

        /// <summary>�v��N��</summary>
        /// <remarks>���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private Int32[] _acptAnOdrStatus;

        /// <summary>����`�[�敪</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private Int32[] _salesSlipCd;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>����`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>�S����</summary>
        /// <remarks>�̔��]�ƈ��R�[�h</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�󒍎�</summary>
        /// <remarks>��t�]�ƈ��R�[�h</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>���s��</summary>
        /// <remarks>������͎҃R�[�h</remarks>
        private string _salesInputCode = "";

        /// <summary>�Ǘ��ԍ�</summary>
        /// <remarks>���q�Ǘ��R�[�h</remarks>
        private string _carMngCode = "";

        /// <summary>�Ԏ햼��</summary>
        /// <remarks>�Ԏ�S�p����</remarks>
        private string _modelFullName = "";

        /// <summary>�^��</summary>
        /// <remarks>�^���i�t���^�j</remarks>
        private string _fullModel = "";

        /// <summary>�ԑ䇂</summary>
        /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
        private Int32 _searchFrameNo;

        // -------ADD 2010/08/05-------->>>>>
        /// <summary>�ԑ䇂</summary>
        /// <remarks>�ԑ�ԍ�</remarks>
        private string _frameNo;
        // -------ADD 2010/08/05--------<<<<<

        /// <summary>���Ӑ撍��</summary>
        /// <remarks>�����`�[�ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�J���[����</summary>
        /// <remarks>�J���[����1</remarks>
        private string _colorName1 = "";

        /// <summary>�g��������</summary>
        /// <remarks>�g��������</remarks>
        private string _trimName = "";

        /// <summary>�t�n�d���M</summary>
        /// <remarks>UOE�����f�[�^�̃f�[�^���M�敪</remarks>
        private Int32 _dataSendCode;

        /// <summary>���l�P</summary>
        /// <remarks>�`�[���l</remarks>
        private string _slipNote = "";

        /// <summary>���l�Q</summary>
        /// <remarks>�`�[���l�Q</remarks>
        private string _slipNote2 = "";

        /// <summary>���l�R</summary>
        /// <remarks>�`�[���l�R</remarks>
        private string _slipNote3 = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>�t�n�d���}�[�N�P</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        /// <remarks>�t�n�d���}�[�N�Q</remarks>
        private string _uoeRemark2 = "";

        /// <summary>�a�k�O���[�v</summary>
        /// <remarks>BL�O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>�a�k�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>�i��</summary>
        /// <remarks>���i����</remarks>
        private string _goodsName = "";

        /// <summary>�i��</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>�̔��敪�R�[�h</summary>
        /// <remarks>�̔��敪�R�[�h</remarks>
        private Int32 _salesCode;

        /// <summary>���Е��ރR�[�h</summary>
        /// <remarks>���Е��ރR�[�h</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>�݌Ɏ��敪</summary>
        /// <remarks>����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _warehouseCode = "";

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���f�[�^�̑����`�[�ԍ�</remarks>
        private string _supplierSlipNo = "";

        /// <summary>�d����</summary>
        /// <remarks>�d����R�[�h</remarks>
        private Int32 _supplierCd;

        /// <summary>������</summary>
        /// <remarks>UOE�����f�[�^�̎d����R�[�h</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>���ה��l</summary>
        /// <remarks>���ה��l</remarks>
        private string _dtlNote = "";

        /// <summary>�`�[�����敪</summary>
        /// <remarks>0:�S�� 1:����̂� 2:�����̂�</remarks>
        private Int32 _searchType;

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>���i����[����]</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private Int32 _goodsKindCode;

        /// <summary>���i�啪�ރR�[�h[����]</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h[����]</summary>
        /// <remarks>�������ރR�[�h</remarks>
        private Int32 _goodsMGroup;

        /// <summary>�q�ɒI��[����]</summary>
        private string _warehouseShelfNo = "";

        /// <summary>����`�[�敪�i���ׁj[����]</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>����`�[�ԍ�</summary>
        private string _hisDtlSlipNum = "";

        /// <remarks>�󒍃X�e�[�^�X�i���j</remarks>
        private Int32 _acptAnOdrStatusSrc;
        // --- ADD 2010/12/20 ----------<<<<<
        // ---------------------- ADD START 2011/07/18 ���R ----------------->>>>>
        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>1:�ʏ�(PCC�A�g�Ȃ�)�A2:�蓮�񓚁A3:������</value>
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

        /// <summary>
        /// �⍇���ԍ�
        /// </summary>
        private Int64 _inquiryNumber;

        /// <summary>
        /// �⍇���ԍ�
        /// </summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   �k�m</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  SearchCnt
        /// <summary>��������v���p�e�B</summary>
        /// <value>���������+1���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SearchCnt
        {
            get { return _searchCnt; }
            set { _searchCnt = value; }
        }

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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>(�z��)�@�S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /// public propaty name  :  St_SalesDate
        /// <summary>�J�n������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>�I��������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>�J�n���͓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>�I�����͓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }
               

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�S���҃v���p�e�B</summary>
        /// <value>�̔��]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>�󒍎҃v���p�e�B</summary>
        /// <value>��t�]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>���s�҃v���p�e�B</summary>
        /// <value>������͎҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>�Ǘ��ԍ��v���p�e�B</summary>
        /// <value>���q�Ǘ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ햼�̃v���p�e�B</summary>
        /// <value>�Ԏ�S�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���v���p�e�B</summary>
        /// <value>�^���i�t���^�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SearchFrameNo
        /// <summary>�ԑ䇂�v���p�e�B</summary>
        /// <value>�ԑ�ԍ��i�����p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ䇂�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ䇂�v���p�e�B</summary>
        /// <value>�ԑ�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ䇂�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>���Ӑ撍�ԃv���p�e�B</summary>
        /// <value>�����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ撍�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>�J���[���̃v���p�e�B</summary>
        /// <value>�J���[����1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>�g�������̃v���p�e�B</summary>
        /// <value>�g��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  DataSendCode
        /// <summary>�t�n�d���M�v���p�e�B</summary>
        /// <value>UOE�����f�[�^�̃f�[�^���M�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���M�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>���l�P�v���p�e�B</summary>
        /// <value>�`�[���l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>���l�Q�v���p�e�B</summary>
        /// <value>�`�[���l�Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>���l�R�v���p�e�B</summary>
        /// <value>�`�[���l�R</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>�t�n�d���}�[�N�P</value>
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
        /// <value>�t�n�d���}�[�N�Q</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>�a�k�O���[�v�v���p�e�B</summary>
        /// <value>BL�O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�O���[�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>�a�k�R�[�h�v���p�e�B</summary>
        /// <value>BL���i�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
        /// <value>���i����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// <value>���i�ԍ�</value>
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
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>���i���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// <value>�̔��敪�R�[�h</value>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// <value>���Е��ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>�݌Ɏ��敪�v���p�e�B</summary>
        /// <value>����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q�ɃR�[�h</value>
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���f�[�^�̑����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����v���p�e�B</summary>
        /// <value>�d����R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>������v���p�e�B</summary>
        /// <value>UOE�����f�[�^�̎d����R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
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

        /// public propaty name  :  SearchType
        /// <summary>�`�[�����敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:����̂� 2:�����̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i����[����]�v���p�e�B</summary>
        /// <value>0:���� 1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i����[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h[����]�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h[����]�v���p�e�B</summary>
        /// <value>�������ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI��[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI��[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�i���ׁj[����]�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
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

        // --- ADD 2010/12/20 ---------->>>>>
        /// public propaty name  :  HisDtlSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HisDtlSlipNum
        {
            get { return _hisDtlSlipNum; }
            set { _hisDtlSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSrc
        /// <summary>�󒍃X�e�[�^�X�i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSrc
        {
            get { return _acptAnOdrStatusSrc; }
            set { _acptAnOdrStatusSrc = value; }
        }

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)�R���X�g���N�^
        /// </summary>
        /// <returns>CustPrtPpr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPpr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DmdARecOutPutBlnceRslt()
        {
            // �݌Ɏ��敪(-1:�S��)
            SalesOrderDivCd = -1;
            // ���i����(-1:�S��)
            GoodsKindCode = -1;
        }

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)�R���X�g���N�^
        /// </summary>
        /// <param name="searchCnt">�������(���������+1���Z�b�g)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h((�z��)�@�S�Ўw���{""})</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="st_SalesDate">�J�n������t(YYYYMMDD)</param>
        /// <param name="ed_SalesDate">�I��������t(YYYYMMDD)</param>
        /// <param name="st_AddUpADate">�J�n���͓��t(YYYYMMDD)</param>
        /// <param name="ed_AddUpADate">�I�����͓��t(YYYYMMDD)</param>
        /// <param name="addUpYearMonth">�v��N��(���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM)</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X((�z��)�@�S�w��̏ꍇ��{""})</param>
        /// <param name="salesSlipCd">����`�[�敪((�z��)�@�S�w��̏ꍇ��{""})</param>
        /// <param name="salesSlipNum">�`�[�ԍ�(����`�[�ԍ�)</param>
        /// <param name="salesEmployeeCd">�S����(�̔��]�ƈ��R�[�h)</param>
        /// <param name="frontEmployeeCd">�󒍎�(��t�]�ƈ��R�[�h)</param>
        /// <param name="salesInputCode">���s��(������͎҃R�[�h)</param>
        /// <param name="carMngCode">�Ǘ��ԍ�(���q�Ǘ��R�[�h)</param>
        /// <param name="modelFullName">�Ԏ햼��(�Ԏ�S�p����)</param>
        /// <param name="fullModel">�^��(�^���i�t���^�j)</param>
        /// <param name="searchFrameNo">�ԑ䇂(�ԑ�ԍ��i�����p�j)</param>
        /// <param name="frameNo">�ԑ䇂(�ԑ�ԍ�)</param>
        /// <param name="partySaleSlipNum">���Ӑ撍��(�����`�[�ԍ�)</param>
        /// <param name="colorName1">�J���[����(�J���[����1)</param>
        /// <param name="trimName">�g��������(�g��������)</param>
        /// <param name="dataSendCode">�t�n�d���M(UOE�����f�[�^�̃f�[�^���M�敪)</param>
        /// <param name="slipNote">���l�P(�`�[���l)</param>
        /// <param name="slipNote2">���l�Q(�`�[���l�Q)</param>
        /// <param name="slipNote3">���l�R(�`�[���l�R)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P(�t�n�d���}�[�N�P)</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q(�t�n�d���}�[�N�Q)</param>
        /// <param name="bLGroupCode">�a�k�O���[�v(BL�O���[�v�R�[�h)</param>
        /// <param name="bLGoodsCode">�a�k�R�[�h(BL���i�R�[�h)</param>
        /// <param name="goodsName">�i��(���i����)</param>
        /// <param name="goodsNo">�i��(���i�ԍ�)</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h(���i���[�J�[�R�[�h)</param>
        /// <param name="salesCode">�̔��敪�R�[�h(�̔��敪�R�[�h)</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h(���Е��ރR�[�h)</param>
        /// <param name="salesOrderDivCd">�݌Ɏ��敪(����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�))</param>
        /// <param name="warehouseCode">�q�ɃR�[�h(�q�ɃR�[�h)</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�(�d���f�[�^�̑����`�[�ԍ�)</param>
        /// <param name="supplierCd">�d����(�d����R�[�h)</param>
        /// <param name="uOESupplierCd">������(UOE�����f�[�^�̎d����R�[�h)</param>
        /// <param name="dtlNote">���ה��l(���ה��l)</param>
        /// <param name="searchType">�`�[�����敪(0:�S�� 1:����̂� 2:�����̂�)</param>
        /// <param name="addresseeCode">�[�i��R�[�h</param>
        /// <param name="goodsKindCode">���i����[����](0:���� 1:�D��)</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h[����](���啪�ށi���[�U�[�K�C�h�j)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h[����](�������ރR�[�h)</param>
        /// <param name="warehouseShelfNo">�q�ɒI��[����]</param>
        /// <param name="salesSlipCdDtl">����`�[�敪�i���ׁj[����](0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="autoAnswerDivSCM">�����񓚋敪(SCM)</param>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <returns>CustPrtPpr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPpr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public DmdARecOutPutBlnceRslt(Int64 searchCnt, string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_SalesDate, DateTime ed_SalesDate, DateTime st_AddUpADate, DateTime ed_AddUpADate, DateTime addUpYearMonth, Int32[] acptAnOdrStatus, Int32[] salesSlipCd, string salesSlipNum, string salesEmployeeCd, string frontEmployeeCd, string salesInputCode, string carMngCode, string modelFullName, string fullModel, Int32 searchFrameNo, string frameNo, string partySaleSlipNum, string colorName1, string trimName, Int32 dataSendCode, string slipNote, string slipNote2, string slipNote3, string uoeRemark1, string uoeRemark2, Int32 bLGroupCode, Int32 bLGoodsCode, string goodsName, string goodsNo, Int32 goodsMakerCd, Int32 salesCode, Int32 enterpriseGanreCode, Int32 salesOrderDivCd, string warehouseCode, string supplierSlipNo, Int32 supplierCd, Int32 uOESupplierCd, string dtlNote, Int32 searchType, Int32 addresseeCode, Int32 goodsKindCode, Int32 goodsLGroup, Int32 goodsMGroup, string warehouseShelfNo, Int32 salesSlipCdDtl, string enterpriseName, string salesEmployeeNm, string bLGoodsName, string warehouseName, string hisDtlSlipNum, Int32 acptAnOdrStatusSrc, Int32 autoAnswerDivSCM, Int64 inquiryNumber)	// ADD 2011/11/28 �k�m
        {
            this._searchCnt = searchCnt;
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._claimCode = claimCode;
            this._st_SalesDate = st_SalesDate;
            this._ed_SalesDate = ed_SalesDate;
            this._st_AddUpADate = st_AddUpADate;
            this._ed_AddUpADate = ed_AddUpADate;
            this.AddUpYearMonth = addUpYearMonth;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipCd = salesSlipCd;
            this._salesSlipNum = salesSlipNum;
            this._salesEmployeeCd = salesEmployeeCd;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesInputCode = salesInputCode;
            this._carMngCode = carMngCode;
            this._modelFullName = modelFullName;
            this._fullModel = fullModel;
            this._searchFrameNo = searchFrameNo;
            this._frameNo = frameNo;// ADD 2010/08/05
            this._partySaleSlipNum = partySaleSlipNum;
            this._colorName1 = colorName1;
            this._trimName = trimName;
            this._dataSendCode = dataSendCode;
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsName = goodsName;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._salesCode = salesCode;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._salesOrderDivCd = salesOrderDivCd;
            this._warehouseCode = warehouseCode;
            this._supplierSlipNo = supplierSlipNo;
            this._supplierCd = supplierCd;
            this._uOESupplierCd = uOESupplierCd;
            this._dtlNote = dtlNote;
            this._searchType = searchType;
            this._addresseeCode = addresseeCode;
            this._goodsKindCode = goodsKindCode;
            this._goodsLGroup = goodsLGroup;
            this._goodsMGroup = goodsMGroup;
            this._warehouseShelfNo = warehouseShelfNo;
            this._salesSlipCdDtl = salesSlipCdDtl;
            this._enterpriseName = enterpriseName;
            this._salesEmployeeNm = salesEmployeeNm;
            this._bLGoodsName = bLGoodsName;
            this._warehouseName = warehouseName;
            this._hisDtlSlipNum = hisDtlSlipNum;
            this.AcptAnOdrStatusSrc = AcptAnOdrStatusSrc;
            this._autoAnswerDivSCM = autoAnswerDivSCM;
            this._inquiryNumber = inquiryNumber;

        }

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)��������
        /// </summary>
        /// <returns>CustPrtPpr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustPrtPpr�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public DmdARecOutPutBlnceRslt Clone()
        {
            return new DmdARecOutPutBlnceRslt(this._searchCnt, this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._st_SalesDate, this._ed_SalesDate, this._st_AddUpADate, this._ed_AddUpADate, this._addUpYearMonth, this._acptAnOdrStatus, this._salesSlipCd, this._salesSlipNum, this._salesEmployeeCd, this._frontEmployeeCd, this._salesInputCode, this._carMngCode, this._modelFullName, this._fullModel, this._searchFrameNo, this._frameNo, this._partySaleSlipNum, this._colorName1, this._trimName, this._dataSendCode, this._slipNote, this._slipNote2, this._slipNote3, this._uoeRemark1, this._uoeRemark2, this._bLGroupCode, this._bLGoodsCode, this._goodsName, this._goodsNo, this._goodsMakerCd, this._salesCode, this._enterpriseGanreCode, this._salesOrderDivCd, this._warehouseCode, this._supplierSlipNo, this._supplierCd, this._uOESupplierCd, this._dtlNote, this._searchType, this._addresseeCode, this._goodsKindCode, this._goodsLGroup, this._goodsMGroup, this._warehouseShelfNo, this._salesSlipCdDtl, this._enterpriseName, this._salesEmployeeNm, this._bLGoodsName, this._warehouseName, this._hisDtlSlipNum, this._acptAnOdrStatusSrc, this._autoAnswerDivSCM, this._inquiryNumber);// ADD 2011/11/28 �k�m
        }

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPpr�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/28 �k�m �⍇���ԍ��̒ǉ�</br>
        /// </remarks>
        public bool Equals(DmdARecOutPutBlnceRslt target)
        {
            return ((this.SearchCnt == target.SearchCnt)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.St_SalesDate == target.St_SalesDate)
                 && (this.Ed_SalesDate == target.Ed_SalesDate)
                 && (this.St_AddUpADate == target.St_AddUpADate)
                 && (this.Ed_AddUpADate == target.Ed_AddUpADate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.FullModel == target.FullModel)
                 && (this.SearchFrameNo == target.SearchFrameNo)
                 && (this.FrameNo == target.FrameNo)// ADD 2010/08/05
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.ColorName1 == target.ColorName1)
                 && (this.TrimName == target.TrimName)
                 && (this.DataSendCode == target.DataSendCode)
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.SalesCode == target.SalesCode)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.DtlNote == target.DtlNote)
                 && (this.SearchType == target.SearchType)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.HisDtlSlipNum == target.HisDtlSlipNum)
                 && (this.AcptAnOdrStatusSrc == target.AcptAnOdrStatusSrc)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM)
                 && (this.InquiryNumber == target.InquiryNumber));
        }

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="custPrtPpr1">
        ///                    ��r����CustPrtPpr�N���X�̃C���X�^���X
        /// </param>
        /// <param name="custPrtPpr2">��r����CustPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPpr�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/28 �k�m �⍇���ԍ��̒ǉ�</br>
        /// </remarks>
        public static bool Equals(DmdARecOutPutBlnceRslt custPrtPpr1, DmdARecOutPutBlnceRslt custPrtPpr2)
        {
            return ((custPrtPpr1.SearchCnt == custPrtPpr2.SearchCnt)
                 && (custPrtPpr1.EnterpriseCode == custPrtPpr2.EnterpriseCode)
                 && (custPrtPpr1.SectionCode == custPrtPpr2.SectionCode)
                 && (custPrtPpr1.CustomerCode == custPrtPpr2.CustomerCode)
                 && (custPrtPpr1.ClaimCode == custPrtPpr2.ClaimCode)
                 && (custPrtPpr1.St_SalesDate == custPrtPpr2.St_SalesDate)
                 && (custPrtPpr1.Ed_SalesDate == custPrtPpr2.Ed_SalesDate)
                 && (custPrtPpr1.St_AddUpADate == custPrtPpr2.St_AddUpADate)
                 && (custPrtPpr1.Ed_AddUpADate == custPrtPpr2.Ed_AddUpADate)
                 && (custPrtPpr1.AddUpYearMonth == custPrtPpr2.AddUpYearMonth)
                 && (custPrtPpr1.AcptAnOdrStatus == custPrtPpr2.AcptAnOdrStatus)
                 && (custPrtPpr1.SalesSlipCd == custPrtPpr2.SalesSlipCd)
                 && (custPrtPpr1.SalesSlipNum == custPrtPpr2.SalesSlipNum)
                 && (custPrtPpr1.SalesEmployeeCd == custPrtPpr2.SalesEmployeeCd)
                 && (custPrtPpr1.FrontEmployeeCd == custPrtPpr2.FrontEmployeeCd)
                 && (custPrtPpr1.SalesInputCode == custPrtPpr2.SalesInputCode)
                 && (custPrtPpr1.CarMngCode == custPrtPpr2.CarMngCode)
                 && (custPrtPpr1.ModelFullName == custPrtPpr2.ModelFullName)
                 && (custPrtPpr1.FullModel == custPrtPpr2.FullModel)
                 && (custPrtPpr1.SearchFrameNo == custPrtPpr2.SearchFrameNo)
                 && (custPrtPpr1.FrameNo == custPrtPpr2.FrameNo)// ADD 2010/08/05
                 && (custPrtPpr1.PartySaleSlipNum == custPrtPpr2.PartySaleSlipNum)
                 && (custPrtPpr1.ColorName1 == custPrtPpr2.ColorName1)
                 && (custPrtPpr1.TrimName == custPrtPpr2.TrimName)
                 && (custPrtPpr1.DataSendCode == custPrtPpr2.DataSendCode)
                 && (custPrtPpr1.SlipNote == custPrtPpr2.SlipNote)
                 && (custPrtPpr1.SlipNote2 == custPrtPpr2.SlipNote2)
                 && (custPrtPpr1.SlipNote3 == custPrtPpr2.SlipNote3)
                 && (custPrtPpr1.UoeRemark1 == custPrtPpr2.UoeRemark1)
                 && (custPrtPpr1.UoeRemark2 == custPrtPpr2.UoeRemark2)
                 && (custPrtPpr1.BLGroupCode == custPrtPpr2.BLGroupCode)
                 && (custPrtPpr1.BLGoodsCode == custPrtPpr2.BLGoodsCode)
                 && (custPrtPpr1.GoodsName == custPrtPpr2.GoodsName)
                 && (custPrtPpr1.GoodsNo == custPrtPpr2.GoodsNo)
                 && (custPrtPpr1.GoodsMakerCd == custPrtPpr2.GoodsMakerCd)
                 && (custPrtPpr1.SalesCode == custPrtPpr2.SalesCode)
                 && (custPrtPpr1.EnterpriseGanreCode == custPrtPpr2.EnterpriseGanreCode)
                 && (custPrtPpr1.SalesOrderDivCd == custPrtPpr2.SalesOrderDivCd)
                 && (custPrtPpr1.WarehouseCode == custPrtPpr2.WarehouseCode)
                 && (custPrtPpr1.SupplierSlipNo == custPrtPpr2.SupplierSlipNo)
                 && (custPrtPpr1.SupplierCd == custPrtPpr2.SupplierCd)
                 && (custPrtPpr1.UOESupplierCd == custPrtPpr2.UOESupplierCd)
                 && (custPrtPpr1.DtlNote == custPrtPpr2.DtlNote)
                 && (custPrtPpr1.SearchType == custPrtPpr2.SearchType)
                 && (custPrtPpr1.AddresseeCode == custPrtPpr2.AddresseeCode)
                 && (custPrtPpr1.GoodsKindCode == custPrtPpr2.GoodsKindCode)
                 && (custPrtPpr1.GoodsLGroup == custPrtPpr2.GoodsLGroup)
                 && (custPrtPpr1.GoodsMGroup == custPrtPpr2.GoodsMGroup)
                 && (custPrtPpr1.WarehouseShelfNo == custPrtPpr2.WarehouseShelfNo)
                 && (custPrtPpr1.SalesSlipCdDtl == custPrtPpr2.SalesSlipCdDtl)
                 && (custPrtPpr1.EnterpriseName == custPrtPpr2.EnterpriseName)
                 && (custPrtPpr1.SalesEmployeeNm == custPrtPpr2.SalesEmployeeNm)
                 && (custPrtPpr1.BLGoodsName == custPrtPpr2.BLGoodsName)
                 && (custPrtPpr1.HisDtlSlipNum == custPrtPpr2.HisDtlSlipNum)
                 && (custPrtPpr1.AcptAnOdrStatusSrc == custPrtPpr2.AcptAnOdrStatusSrc)
                 && (custPrtPpr1.WarehouseName == custPrtPpr2.WarehouseName)
                 && (custPrtPpr1.AutoAnswerDivSCM == custPrtPpr2.AutoAnswerDivSCM)
                 && (custPrtPpr1.InquiryNumber == custPrtPpr2.InquiryNumber));

        }
        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPpr�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public ArrayList Compare(DmdARecOutPutBlnceRslt target)
        {
            ArrayList resList = new ArrayList();
            if (this.SearchCnt != target.SearchCnt) resList.Add("SearchCnt");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.St_SalesDate != target.St_SalesDate) resList.Add("St_SalesDate");
            if (this.Ed_SalesDate != target.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (this.St_AddUpADate != target.St_AddUpADate) resList.Add("St_AddUpADate");
            if (this.Ed_AddUpADate != target.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.SearchFrameNo != target.SearchFrameNo) resList.Add("SearchFrameNo");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");// ADD 2010/08/05
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.DataSendCode != target.DataSendCode) resList.Add("DataSendCode");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.SalesOrderDivCd != target.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.DtlNote != target.DtlNote) resList.Add("DtlNote");
            if (this.SearchType != target.SearchType) resList.Add("SearchType");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.HisDtlSlipNum != target.HisDtlSlipNum) resList.Add("HisDtlSlipNum");
            if (this.AcptAnOdrStatusSrc != target.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="custPrtPpr1">��r����CustPrtPpr�N���X�̃C���X�^���X</param>
        /// <param name="custPrtPpr2">��r����CustPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPpr�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public static ArrayList Compare(DmdARecOutPutBlnceRslt custPrtPpr1, DmdARecOutPutBlnceRslt custPrtPpr2)
        {
            ArrayList resList = new ArrayList();
            if (custPrtPpr1.SearchCnt != custPrtPpr2.SearchCnt) resList.Add("SearchCnt");
            if (custPrtPpr1.EnterpriseCode != custPrtPpr2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custPrtPpr1.SectionCode != custPrtPpr2.SectionCode) resList.Add("SectionCode");
            if (custPrtPpr1.CustomerCode != custPrtPpr2.CustomerCode) resList.Add("CustomerCode");
            if (custPrtPpr1.ClaimCode != custPrtPpr2.ClaimCode) resList.Add("ClaimCode");
            if (custPrtPpr1.St_SalesDate != custPrtPpr2.St_SalesDate) resList.Add("St_SalesDate");
            if (custPrtPpr1.Ed_SalesDate != custPrtPpr2.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (custPrtPpr1.St_AddUpADate != custPrtPpr2.St_AddUpADate) resList.Add("St_AddUpADate");
            if (custPrtPpr1.Ed_AddUpADate != custPrtPpr2.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (custPrtPpr1.AddUpYearMonth != custPrtPpr2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (custPrtPpr1.AcptAnOdrStatus != custPrtPpr2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (custPrtPpr1.SalesSlipCd != custPrtPpr2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (custPrtPpr1.SalesSlipNum != custPrtPpr2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (custPrtPpr1.SalesEmployeeCd != custPrtPpr2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (custPrtPpr1.FrontEmployeeCd != custPrtPpr2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (custPrtPpr1.SalesInputCode != custPrtPpr2.SalesInputCode) resList.Add("SalesInputCode");
            if (custPrtPpr1.CarMngCode != custPrtPpr2.CarMngCode) resList.Add("CarMngCode");
            if (custPrtPpr1.ModelFullName != custPrtPpr2.ModelFullName) resList.Add("ModelFullName");
            if (custPrtPpr1.FullModel != custPrtPpr2.FullModel) resList.Add("FullModel");
            if (custPrtPpr1.SearchFrameNo != custPrtPpr2.SearchFrameNo) resList.Add("SearchFrameNo");
            if (custPrtPpr1.FrameNo != custPrtPpr2.FrameNo) resList.Add("FrameNo");// ADD 2010/08/05
            if (custPrtPpr1.PartySaleSlipNum != custPrtPpr2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (custPrtPpr1.ColorName1 != custPrtPpr2.ColorName1) resList.Add("ColorName1");
            if (custPrtPpr1.TrimName != custPrtPpr2.TrimName) resList.Add("TrimName");
            if (custPrtPpr1.DataSendCode != custPrtPpr2.DataSendCode) resList.Add("DataSendCode");
            if (custPrtPpr1.SlipNote != custPrtPpr2.SlipNote) resList.Add("SlipNote");
            if (custPrtPpr1.SlipNote2 != custPrtPpr2.SlipNote2) resList.Add("SlipNote2");
            if (custPrtPpr1.SlipNote3 != custPrtPpr2.SlipNote3) resList.Add("SlipNote3");
            if (custPrtPpr1.UoeRemark1 != custPrtPpr2.UoeRemark1) resList.Add("UoeRemark1");
            if (custPrtPpr1.UoeRemark2 != custPrtPpr2.UoeRemark2) resList.Add("UoeRemark2");
            if (custPrtPpr1.BLGroupCode != custPrtPpr2.BLGroupCode) resList.Add("BLGroupCode");
            if (custPrtPpr1.BLGoodsCode != custPrtPpr2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (custPrtPpr1.GoodsName != custPrtPpr2.GoodsName) resList.Add("GoodsName");
            if (custPrtPpr1.GoodsNo != custPrtPpr2.GoodsNo) resList.Add("GoodsNo");
            if (custPrtPpr1.GoodsMakerCd != custPrtPpr2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (custPrtPpr1.SalesCode != custPrtPpr2.SalesCode) resList.Add("SalesCode");
            if (custPrtPpr1.EnterpriseGanreCode != custPrtPpr2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (custPrtPpr1.SalesOrderDivCd != custPrtPpr2.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (custPrtPpr1.WarehouseCode != custPrtPpr2.WarehouseCode) resList.Add("WarehouseCode");
            if (custPrtPpr1.SupplierSlipNo != custPrtPpr2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (custPrtPpr1.SupplierCd != custPrtPpr2.SupplierCd) resList.Add("SupplierCd");
            if (custPrtPpr1.UOESupplierCd != custPrtPpr2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (custPrtPpr1.DtlNote != custPrtPpr2.DtlNote) resList.Add("DtlNote");
            if (custPrtPpr1.SearchType != custPrtPpr2.SearchType) resList.Add("SearchType");
            if (custPrtPpr1.AddresseeCode != custPrtPpr2.AddresseeCode) resList.Add("AddresseeCode");
            if (custPrtPpr1.GoodsKindCode != custPrtPpr2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (custPrtPpr1.GoodsLGroup != custPrtPpr2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (custPrtPpr1.GoodsMGroup != custPrtPpr2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (custPrtPpr1.WarehouseShelfNo != custPrtPpr2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (custPrtPpr1.SalesSlipCdDtl != custPrtPpr2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (custPrtPpr1.EnterpriseName != custPrtPpr2.EnterpriseName) resList.Add("EnterpriseName");
            if (custPrtPpr1.SalesEmployeeNm != custPrtPpr2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (custPrtPpr1.BLGoodsName != custPrtPpr2.BLGoodsName) resList.Add("BLGoodsName");
            if (custPrtPpr1.WarehouseName != custPrtPpr2.WarehouseName) resList.Add("WarehouseName");
            if (custPrtPpr1.HisDtlSlipNum != custPrtPpr2.HisDtlSlipNum) resList.Add("HisDtlSlipNum");
            if (custPrtPpr1.AcptAnOdrStatusSrc != custPrtPpr2.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (custPrtPpr1.AutoAnswerDivSCM != custPrtPpr2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            if (custPrtPpr1.InquiryNumber != custPrtPpr2.InquiryNumber) resList.Add("InquiryNumber");
            return resList;
        }
    }
}

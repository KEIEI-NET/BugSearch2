using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region --- DEL 2011/05/26 ---
    /*
    /// public class name:   SCMInquiryDtlAnsResultWork
    /// <summary>
    ///                      SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2010/06/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryDtlAnsResultWork
    {
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>�X�V����</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>�⍇���s�ԍ�</summary>
        private Int32 _inqRowNumber;

        /// <summary>�⍇���s�ԍ��}��</summary>
        private Int32 _inqRowNumDerivedNo;

        /// <summary>�⍇�������׎���GUID</summary>
        private Guid _inqOrgDtlDiscGuid;

        /// <summary>�⍇���斾�׎���GUID</summary>
        /// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
        private Guid _inqOthDtlDiscGuid;

        /// <summary>���i���</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
        private Int32 _goodsDivCd;

        /// <summary>�[�i�敪</summary>
        /// <remarks>0:�z��,1:����</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�戵�敪</summary>
        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
        private Int32 _handleDivCode;

        /// <summary>���i�`��</summary>
        /// <remarks>1:���i,2:�p�i</remarks>
        private Int32 _goodsShape;

        /// <summary>�[�i�m�F�敪</summary>
        /// <remarks>0:���m�F,1:�m�F</remarks>
        private Int32 _delivrdGdsConfCd;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h�}��</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�[�i��</summary>
        private Double _deliveredGoodsCount;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�������i���[�J�[�R�[�h</summary>
        private Int32 _pureGoodsMakerCd;

        /// <summary>�������i�ԍ�</summary>
        private string _pureGoodsNo = "";

        /// <summary>�艿</summary>
        /// <remarks>0:�I�[�v�����i</remarks>
        private Int64 _listPrice;

        /// <summary>�P��</summary>
        private Int64 _unitPrice;

        /// <summary>���׎捞�敪</summary>
        /// <remarks>0:���捞 1:�捞��</remarks>
        private Int32 _dtlTakeinDivCd;

        /// <summary>���i�⑫���</summary>
        private string _goodsAddInfo = "";

        /// <summary>�e���z</summary>
        private Int64 _roughRrofit;

        /// <summary>�e����</summary>
        private Double _roughRate;

        /// <summary>�񓚊���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _answerLimitDate;

        /// <summary>���l(����)</summary>
        private string _commentDtl = "";

        /// <summary>�I��</summary>
        private string _shelfNo = "";

        /// <summary>�ǉ��敪</summary>
        private Int32 _additionalDivCd;

        /// <summary>�����敪</summary>
        private Int32 _correctDivCD;

        /// <summary>�⍇���E�������</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>������z����Ŋz</summary>
        /// <remarks>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
        private Int32 _campaignCode;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</remarks>
        private Int32 _stockDiv;

        /// <summary>�񓚔[��</summary>
        private string _answerDelivDate = "";

        /// <summary>���T�C�N�����i���</summary>
        /// <remarks>1:���r���h 2:����</remarks>
        private Int32 _recyclePrtKindCode;

        /// <summary>���T�C�N�����i��ʖ���</summary>
        private string _recyclePrtKindName = "";

        /// <summary>�┭���i��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _inqGoodsName = "";

        /// <summary>�񓚏��i��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _ansGoodsName = "";

        /// <summary>�┭�������i�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _inqPureGoodsNo = "";

        /// <summary>�񓚏������i�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _ansPureGoodsNo = "";

        /// <summary>�L�����Z����ԋ敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
        private Int16 _cancelCndtinDiv;


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

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
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
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>�X�V���ԃv���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqRowNumber
        /// <summary>�⍇���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqRowNumber
        {
            get { return _inqRowNumber; }
            set { _inqRowNumber = value; }
        }

        /// public propaty name  :  InqRowNumDerivedNo
        /// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqRowNumDerivedNo
        {
            get { return _inqRowNumDerivedNo; }
            set { _inqRowNumDerivedNo = value; }
        }

        /// public propaty name  :  InqOrgDtlDiscGuid
        /// <summary>�⍇�������׎���GUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������׎���GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid InqOrgDtlDiscGuid
        {
            get { return _inqOrgDtlDiscGuid; }
            set { _inqOrgDtlDiscGuid = value; }
        }

        /// public propaty name  :  InqOthDtlDiscGuid
        /// <summary>�⍇���斾�׎���GUID�v���p�e�B</summary>
        /// <value>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���斾�׎���GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid InqOthDtlDiscGuid
        {
            get { return _inqOthDtlDiscGuid; }
            set { _inqOthDtlDiscGuid = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>���i��ʃv���p�e�B</summary>
        /// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDivCd
        {
            get { return _goodsDivCd; }
            set { _goodsDivCd = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>0:�z��,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  HandleDivCode
        /// <summary>�戵�敪�v���p�e�B</summary>
        /// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �戵�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HandleDivCode
        {
            get { return _handleDivCode; }
            set { _handleDivCode = value; }
        }

        /// public propaty name  :  GoodsShape
        /// <summary>���i�`�ԃv���p�e�B</summary>
        /// <value>1:���i,2:�p�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�`�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsShape
        {
            get { return _goodsShape; }
            set { _goodsShape = value; }
        }

        /// public propaty name  :  DelivrdGdsConfCd
        /// <summary>�[�i�m�F�敪�v���p�e�B</summary>
        /// <value>0:���m�F,1:�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelivrdGdsConfCd
        {
            get { return _delivrdGdsConfCd; }
            set { _delivrdGdsConfCd = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
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

        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
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

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  DeliveredGoodsCount
        /// <summary>�[�i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DeliveredGoodsCount
        {
            get { return _deliveredGoodsCount; }
            set { _deliveredGoodsCount = value; }
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

        /// public propaty name  :  PureGoodsMakerCd
        /// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureGoodsMakerCd
        {
            get { return _pureGoodsMakerCd; }
            set { _pureGoodsMakerCd = value; }
        }

        /// public propaty name  :  PureGoodsNo
        /// <summary>�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PureGoodsNo
        {
            get { return _pureGoodsNo; }
            set { _pureGoodsNo = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// <value>0:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>�P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  DtlTakeinDivCd
        /// <summary>���׎捞�敪�v���p�e�B</summary>
        /// <value>0:���捞 1:�捞��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׎捞�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlTakeinDivCd
        {
            get { return _dtlTakeinDivCd; }
            set { _dtlTakeinDivCd = value; }
        }

        /// public propaty name  :  GoodsAddInfo
        /// <summary>���i�⑫���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�⑫���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsAddInfo
        {
            get { return _goodsAddInfo; }
            set { _goodsAddInfo = value; }
        }

        /// public propaty name  :  RoughRrofit
        /// <summary>�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RoughRrofit
        {
            get { return _roughRrofit; }
            set { _roughRrofit = value; }
        }

        /// public propaty name  :  RoughRate
        /// <summary>�e�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RoughRate
        {
            get { return _roughRate; }
            set { _roughRate = value; }
        }

        /// public propaty name  :  AnswerLimitDate
        /// <summary>�񓚊����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚊����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerLimitDate
        {
            get { return _answerLimitDate; }
            set { _answerLimitDate = value; }
        }

        /// public propaty name  :  CommentDtl
        /// <summary>���l(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommentDtl
        {
            get { return _commentDtl; }
            set { _commentDtl = value; }
        }

        /// public propaty name  :  ShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfNo
        {
            get { return _shelfNo; }
            set { _shelfNo = value; }
        }

        /// public propaty name  :  AdditionalDivCd
        /// <summary>�ǉ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AdditionalDivCd
        {
            get { return _additionalDivCd; }
            set { _additionalDivCd = value; }
        }

        /// public propaty name  :  CorrectDivCD
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CorrectDivCD
        {
            get { return _correctDivCD; }
            set { _correctDivCD = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// <value>1:�⍇�� 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>������z����Ŋz�v���p�e�B</summary>
        /// <value>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</value>
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

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  AnswerDelivDate
        /// <summary>�񓚔[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate
        {
            get { return _answerDelivDate; }
            set { _answerDelivDate = value; }
        }

        /// public propaty name  :  RecyclePrtKindCode
        /// <summary>���T�C�N�����i��ʃv���p�e�B</summary>
        /// <value>1:���r���h 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���T�C�N�����i��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecyclePrtKindCode
        {
            get { return _recyclePrtKindCode; }
            set { _recyclePrtKindCode = value; }
        }

        /// public propaty name  :  RecyclePrtKindName
        /// <summary>���T�C�N�����i��ʖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���T�C�N�����i��ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RecyclePrtKindName
        {
            get { return _recyclePrtKindName; }
            set { _recyclePrtKindName = value; }
        }

        /// public propaty name  :  InqGoodsName
        /// <summary>�┭���i���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqGoodsName
        {
            get { return _inqGoodsName; }
            set { _inqGoodsName = value; }
        }

        /// public propaty name  :  AnsGoodsName
        /// <summary>�񓚏��i���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏��i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsGoodsName
        {
            get { return _ansGoodsName; }
            set { _ansGoodsName = value; }
        }

        /// public propaty name  :  InqPureGoodsNo
        /// <summary>�┭�������i�ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqPureGoodsNo
        {
            get { return _inqPureGoodsNo; }
            set { _inqPureGoodsNo = value; }
        }

        /// public propaty name  :  AnsPureGoodsNo
        /// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsPureGoodsNo
        {
            get { return _ansPureGoodsNo; }
            set { _ansPureGoodsNo = value; }
        }

        /// public propaty name  :  CancelCndtinDiv
        /// <summary>�L�����Z����ԋ敪�v���p�e�B</summary>
        /// <value>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����Z����ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CancelCndtinDiv
        {
            get { return _cancelCndtinDiv; }
            set { _cancelCndtinDiv = value; }
        }


        /// <summary>
        /// SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMInquiryDtlAnsResultWork()
        {
        }

    }
    */
    # endregion

    /// public class name:   SCMInquiryDtlAnsResultWork
    /// <summary>
    ///                      SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2011/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/5/26  �v�ۓc</br>
    /// <br>                 :   �q�ɃR�[�h ��ǉ�</br>
    /// <br>                 :   �q�ɖ��� ��ǉ�</br>
    /// <br>                 :   �q�ɒI�� ��ǉ�</br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh</br>
    /// <br>                 :   2013/06/18�z�M Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή� </br>
    /// <br>Update Note      :   2015/02/20 �g��  �Ǘ��ԍ� 11070266-00  </br>
    /// <br>                 :   SCM������ C������ʓ��L�Ή� </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryDtlAnsResultWork
    {
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>�X�V����</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>�⍇���s�ԍ�</summary>
        private Int32 _inqRowNumber;

        /// <summary>�⍇���s�ԍ��}��</summary>
        private Int32 _inqRowNumDerivedNo;

        /// <summary>�⍇�������׎���GUID</summary>
        private Guid _inqOrgDtlDiscGuid;

        /// <summary>�⍇���斾�׎���GUID</summary>
        /// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
        private Guid _inqOthDtlDiscGuid;

        /// <summary>���i���</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
        private Int32 _goodsDivCd;

        /// <summary>�[�i�敪</summary>
        /// <remarks>0:�z��,1:����</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�戵�敪</summary>
        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
        private Int32 _handleDivCode;

        /// <summary>���i�`��</summary>
        /// <remarks>1:���i,2:�p�i</remarks>
        private Int32 _goodsShape;

        /// <summary>�[�i�m�F�敪</summary>
        /// <remarks>0:���m�F,1:�m�F</remarks>
        private Int32 _delivrdGdsConfCd;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h�}��</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�[�i��</summary>
        private Double _deliveredGoodsCount;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�������i���[�J�[�R�[�h</summary>
        private Int32 _pureGoodsMakerCd;

        /// <summary>�������i�ԍ�</summary>
        private string _pureGoodsNo = "";

        /// <summary>�艿</summary>
        /// <remarks>0:�I�[�v�����i</remarks>
        private Int64 _listPrice;

        /// <summary>�P��</summary>
        private Int64 _unitPrice;

        /// <summary>���׎捞�敪</summary>
        /// <remarks>0:���捞 1:�捞��</remarks>
        private Int32 _dtlTakeinDivCd;

        /// <summary>���i�⑫���</summary>
        private string _goodsAddInfo = "";

        /// <summary>�e���z</summary>
        private Int64 _roughRrofit;

        /// <summary>�e����</summary>
        private Double _roughRate;

        /// <summary>�񓚊���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _answerLimitDate;

        /// <summary>���l(����)</summary>
        private string _commentDtl = "";

        /// <summary>�I��</summary>
        private string _shelfNo = "";

        /// <summary>�ǉ��敪</summary>
        private Int32 _additionalDivCd;

        /// <summary>�����敪</summary>
        private Int32 _correctDivCD;

        /// <summary>�⍇���E�������</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>������z����Ŋz</summary>
        /// <remarks>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
        private Int32 _campaignCode;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</remarks>
        private Int32 _stockDiv;

        /// <summary>�񓚔[��</summary>
        private string _answerDelivDate = "";

        /// <summary>���T�C�N�����i���</summary>
        /// <remarks>1:���r���h 2:����</remarks>
        private Int32 _recyclePrtKindCode;

        /// <summary>���T�C�N�����i��ʖ���</summary>
        private string _recyclePrtKindName = "";

        /// <summary>�┭���i��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _inqGoodsName = "";

        /// <summary>�񓚏��i��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _ansGoodsName = "";

        /// <summary>�┭�������i�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _inqPureGoodsNo = "";

        /// <summary>�񓚏������i�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _ansPureGoodsNo = "";

        /// <summary>�L�����Z����ԋ敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
        private Int16 _cancelCndtinDiv;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>PM��Ǒq�ɃR�[�h</summary>
        private string _pmMainMngWarehouseCd = "";

        /// <summary>PM��Ǒq�ɖ���</summary>
        private string _pmMainMngWarehouseName = "";

        /// <summary>PM��ǒI��</summary>
        private string _pmMainMngShelfNo = "";

        /// <summary>PM��ǌ��݌�</summary>
        private Double _pmMainMngPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
        /// <summary> ���i�K�i�E���L����(�H�����) </summary>
        private string _goodsSpecialNtForFac;

        /// <summary> ���i�K�i�E���L����(�J�[�I�[�i�[����) </summary>
        private string _goodsSpecialNtForCOw;

        /// <summary> �D�ǐݒ�ڍז��̂Q(�H�����) </summary>
        private string _prmSetDtlName2ForFac;

        /// <summary> �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����) </summary>
        private string _prmSetDtlName2ForCOw;
        // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
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
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>�X�V���ԃv���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqRowNumber
        /// <summary>�⍇���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqRowNumber
        {
            get { return _inqRowNumber; }
            set { _inqRowNumber = value; }
        }

        /// public propaty name  :  InqRowNumDerivedNo
        /// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqRowNumDerivedNo
        {
            get { return _inqRowNumDerivedNo; }
            set { _inqRowNumDerivedNo = value; }
        }

        /// public propaty name  :  InqOrgDtlDiscGuid
        /// <summary>�⍇�������׎���GUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������׎���GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid InqOrgDtlDiscGuid
        {
            get { return _inqOrgDtlDiscGuid; }
            set { _inqOrgDtlDiscGuid = value; }
        }

        /// public propaty name  :  InqOthDtlDiscGuid
        /// <summary>�⍇���斾�׎���GUID�v���p�e�B</summary>
        /// <value>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���斾�׎���GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid InqOthDtlDiscGuid
        {
            get { return _inqOthDtlDiscGuid; }
            set { _inqOthDtlDiscGuid = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>���i��ʃv���p�e�B</summary>
        /// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDivCd
        {
            get { return _goodsDivCd; }
            set { _goodsDivCd = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>0:�z��,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  HandleDivCode
        /// <summary>�戵�敪�v���p�e�B</summary>
        /// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �戵�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HandleDivCode
        {
            get { return _handleDivCode; }
            set { _handleDivCode = value; }
        }

        /// public propaty name  :  GoodsShape
        /// <summary>���i�`�ԃv���p�e�B</summary>
        /// <value>1:���i,2:�p�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�`�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsShape
        {
            get { return _goodsShape; }
            set { _goodsShape = value; }
        }

        /// public propaty name  :  DelivrdGdsConfCd
        /// <summary>�[�i�m�F�敪�v���p�e�B</summary>
        /// <value>0:���m�F,1:�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelivrdGdsConfCd
        {
            get { return _delivrdGdsConfCd; }
            set { _delivrdGdsConfCd = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
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

        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
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

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  DeliveredGoodsCount
        /// <summary>�[�i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DeliveredGoodsCount
        {
            get { return _deliveredGoodsCount; }
            set { _deliveredGoodsCount = value; }
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

        /// public propaty name  :  PureGoodsMakerCd
        /// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureGoodsMakerCd
        {
            get { return _pureGoodsMakerCd; }
            set { _pureGoodsMakerCd = value; }
        }

        /// public propaty name  :  PureGoodsNo
        /// <summary>�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PureGoodsNo
        {
            get { return _pureGoodsNo; }
            set { _pureGoodsNo = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// <value>0:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>�P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  DtlTakeinDivCd
        /// <summary>���׎捞�敪�v���p�e�B</summary>
        /// <value>0:���捞 1:�捞��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׎捞�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlTakeinDivCd
        {
            get { return _dtlTakeinDivCd; }
            set { _dtlTakeinDivCd = value; }
        }

        /// public propaty name  :  GoodsAddInfo
        /// <summary>���i�⑫���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�⑫���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsAddInfo
        {
            get { return _goodsAddInfo; }
            set { _goodsAddInfo = value; }
        }

        /// public propaty name  :  RoughRrofit
        /// <summary>�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RoughRrofit
        {
            get { return _roughRrofit; }
            set { _roughRrofit = value; }
        }

        /// public propaty name  :  RoughRate
        /// <summary>�e�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RoughRate
        {
            get { return _roughRate; }
            set { _roughRate = value; }
        }

        /// public propaty name  :  AnswerLimitDate
        /// <summary>�񓚊����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚊����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerLimitDate
        {
            get { return _answerLimitDate; }
            set { _answerLimitDate = value; }
        }

        /// public propaty name  :  CommentDtl
        /// <summary>���l(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommentDtl
        {
            get { return _commentDtl; }
            set { _commentDtl = value; }
        }

        /// public propaty name  :  ShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfNo
        {
            get { return _shelfNo; }
            set { _shelfNo = value; }
        }

        /// public propaty name  :  AdditionalDivCd
        /// <summary>�ǉ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AdditionalDivCd
        {
            get { return _additionalDivCd; }
            set { _additionalDivCd = value; }
        }

        /// public propaty name  :  CorrectDivCD
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CorrectDivCD
        {
            get { return _correctDivCD; }
            set { _correctDivCD = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// <value>1:�⍇�� 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>������z����Ŋz�v���p�e�B</summary>
        /// <value>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</value>
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

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  AnswerDelivDate
        /// <summary>�񓚔[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate
        {
            get { return _answerDelivDate; }
            set { _answerDelivDate = value; }
        }

        /// public propaty name  :  RecyclePrtKindCode
        /// <summary>���T�C�N�����i��ʃv���p�e�B</summary>
        /// <value>1:���r���h 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���T�C�N�����i��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecyclePrtKindCode
        {
            get { return _recyclePrtKindCode; }
            set { _recyclePrtKindCode = value; }
        }

        /// public propaty name  :  RecyclePrtKindName
        /// <summary>���T�C�N�����i��ʖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���T�C�N�����i��ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RecyclePrtKindName
        {
            get { return _recyclePrtKindName; }
            set { _recyclePrtKindName = value; }
        }

        /// public propaty name  :  InqGoodsName
        /// <summary>�┭���i���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqGoodsName
        {
            get { return _inqGoodsName; }
            set { _inqGoodsName = value; }
        }

        /// public propaty name  :  AnsGoodsName
        /// <summary>�񓚏��i���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏��i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsGoodsName
        {
            get { return _ansGoodsName; }
            set { _ansGoodsName = value; }
        }

        /// public propaty name  :  InqPureGoodsNo
        /// <summary>�┭�������i�ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqPureGoodsNo
        {
            get { return _inqPureGoodsNo; }
            set { _inqPureGoodsNo = value; }
        }

        /// public propaty name  :  AnsPureGoodsNo
        /// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsPureGoodsNo
        {
            get { return _ansPureGoodsNo; }
            set { _ansPureGoodsNo = value; }
        }

        /// public propaty name  :  CancelCndtinDiv
        /// <summary>�L�����Z����ԋ敪�v���p�e�B</summary>
        /// <value>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����Z����ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CancelCndtinDiv
        {
            get { return _cancelCndtinDiv; }
            set { _cancelCndtinDiv = value; }
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

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  PmMainMngWarehouseCd
        /// <summary>PM��Ǒq�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��Ǒq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmMainMngWarehouseCd
        {
            get { return _pmMainMngWarehouseCd; }
            set { _pmMainMngWarehouseCd = value; }
        }

        /// public propaty name  :  PmMainMngWarehouseName
        /// <summary>PM��Ǒq�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��Ǒq�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmMainMngWarehouseName
        {
            get { return _pmMainMngWarehouseName; }
            set { _pmMainMngWarehouseName = value; }
        }

        /// public propaty name  :  PmMainMngShelfNo
        /// <summary>PM��ǒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ǒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmMainMngShelfNo
        {
            get { return _pmMainMngShelfNo; }
            set { _pmMainMngShelfNo = value; }
        }

        /// public propaty name  :  PmMainMngPrsntCount
        /// <summary>PM��ǌ��݌��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ǌ��݌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PmMainMngPrsntCount
        {
            get { return _pmMainMngPrsntCount; }
            set { _pmMainMngPrsntCount = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  GoodsSpecialNtForFac
        /// <summary>���i�K�i�E���L����(�H�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L����(�H�����)�v���p�e�B</br>
        /// </remarks>
        public string GoodsSpecialNtForFac
        {
            get { return _goodsSpecialNtForFac; }
            set { _goodsSpecialNtForFac = value; }
        }

        /// public propaty name  :  GoodsSpecialNtForCOw
        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string GoodsSpecialNtForCOw
        {
            get { return _goodsSpecialNtForCOw; }
            set { _goodsSpecialNtForCOw = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForCOw
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMInquiryDtlAnsResultWork()
        {
        }

    }

    # region --- DEL 2011/05/26 ---
    /*
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMInquiryDtlAnsResultWork || graph is ArrayList || graph is SCMInquiryDtlAnsResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMInquiryDtlAnsResultWork).FullName));

            if (graph != null && graph is SCMInquiryDtlAnsResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryDtlAnsResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMInquiryDtlAnsResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMInquiryDtlAnsResultWork[])graph).Length;
            }
            else if (graph is SCMInquiryDtlAnsResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //�⍇���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //�⍇���s�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //�⍇�������׎���GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
            //�⍇���斾�׎���GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
            //���i���
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //�戵�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //���i�`��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //�[�i�m�F�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�[�i��
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�������i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsNo
            //�艿
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //�P��
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //���׎捞�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
            //���i�⑫���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //�e����
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //�񓚊���
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //���l(����)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //�ǉ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //������z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //���T�C�N�����i���
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //���T�C�N�����i��ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //�┭���i��
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //�񓚏��i��
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //�┭�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //�񓚏������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //�L�����Z����ԋ敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelCndtinDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is SCMInquiryDtlAnsResultWork)
            {
                SCMInquiryDtlAnsResultWork temp = (SCMInquiryDtlAnsResultWork)graph;

                SetSCMInquiryDtlAnsResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMInquiryDtlAnsResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMInquiryDtlAnsResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMInquiryDtlAnsResultWork temp in lst)
                {
                    SetSCMInquiryDtlAnsResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMInquiryDtlAnsResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 57;

        /// <summary>
        ///  SCMInquiryDtlAnsResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMInquiryDtlAnsResultWork(System.IO.BinaryWriter writer, SCMInquiryDtlAnsResultWork temp)
        {
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd);
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�X�V����
            writer.Write(temp.UpdateTime);
            //�⍇���s�ԍ�
            writer.Write(temp.InqRowNumber);
            //�⍇���s�ԍ��}��
            writer.Write(temp.InqRowNumDerivedNo);
            //�⍇�������׎���GUID
            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
            writer.Write(inqOrgDtlDiscGuidArray.Length);
            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
            //�⍇���斾�׎���GUID
            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
            writer.Write(inqOthDtlDiscGuidArray.Length);
            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
            //���i���
            writer.Write(temp.GoodsDivCd);
            //�[�i�敪
            writer.Write(temp.DeliveredGoodsDiv);
            //�戵�敪
            writer.Write(temp.HandleDivCode);
            //���i�`��
            writer.Write(temp.GoodsShape);
            //�[�i�m�F�敪
            writer.Write(temp.DelivrdGdsConfCd);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h�}��
            writer.Write(temp.BLGoodsDrCode);
            //���i����
            writer.Write(temp.GoodsName);
            //������
            writer.Write(temp.SalesOrderCount);
            //�[�i��
            writer.Write(temp.DeliveredGoodsCount);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�������i���[�J�[�R�[�h
            writer.Write(temp.PureGoodsMakerCd);
            //�������i�ԍ�
            writer.Write(temp.PureGoodsNo);
            //�艿
            writer.Write(temp.ListPrice);
            //�P��
            writer.Write(temp.UnitPrice);
            //���׎捞�敪
            writer.Write(temp.DtlTakeinDivCd);
            //���i�⑫���
            writer.Write(temp.GoodsAddInfo);
            //�e���z
            writer.Write(temp.RoughRrofit);
            //�e����
            writer.Write(temp.RoughRate);
            //�񓚊���
            writer.Write(temp.AnswerLimitDate);
            //���l(����)
            writer.Write(temp.CommentDtl);
            //�I��
            writer.Write(temp.ShelfNo);
            //�ǉ��敪
            writer.Write(temp.AdditionalDivCd);
            //�����敪
            writer.Write(temp.CorrectDivCD);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //������z����Ŋz
            writer.Write(temp.SalesPriceConsTax);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�񓚔[��
            writer.Write(temp.AnswerDelivDate);
            //���T�C�N�����i���
            writer.Write(temp.RecyclePrtKindCode);
            //���T�C�N�����i��ʖ���
            writer.Write(temp.RecyclePrtKindName);
            //�┭���i��
            writer.Write(temp.InqGoodsName);
            //�񓚏��i��
            writer.Write(temp.AnsGoodsName);
            //�┭�������i�ԍ�
            writer.Write(temp.InqPureGoodsNo);
            //�񓚏������i�ԍ�
            writer.Write(temp.AnsPureGoodsNo);
            //�L�����Z����ԋ敪
            writer.Write(temp.CancelCndtinDiv);

        }

        /// <summary>
        ///  SCMInquiryDtlAnsResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMInquiryDtlAnsResultWork GetSCMInquiryDtlAnsResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMInquiryDtlAnsResultWork temp = new SCMInquiryDtlAnsResultWork();

            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString();
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateTime = reader.ReadInt32();
            //�⍇���s�ԍ�
            temp.InqRowNumber = reader.ReadInt32();
            //�⍇���s�ԍ��}��
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //�⍇�������׎���GUID
            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
            //�⍇���斾�׎���GUID
            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
            //���i���
            temp.GoodsDivCd = reader.ReadInt32();
            //�[�i�敪
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //�戵�敪
            temp.HandleDivCode = reader.ReadInt32();
            //���i�`��
            temp.GoodsShape = reader.ReadInt32();
            //�[�i�m�F�敪
            temp.DelivrdGdsConfCd = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h�}��
            temp.BLGoodsDrCode = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�[�i��
            temp.DeliveredGoodsCount = reader.ReadDouble();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�������i���[�J�[�R�[�h
            temp.PureGoodsMakerCd = reader.ReadInt32();
            //�������i�ԍ�
            temp.PureGoodsNo = reader.ReadString();
            //�艿
            temp.ListPrice = reader.ReadInt64();
            //�P��
            temp.UnitPrice = reader.ReadInt64();
            //���׎捞�敪
            temp.DtlTakeinDivCd = reader.ReadInt32();
            //���i�⑫���
            temp.GoodsAddInfo = reader.ReadString();
            //�e���z
            temp.RoughRrofit = reader.ReadInt64();
            //�e����
            temp.RoughRate = reader.ReadDouble();
            //�񓚊���
            temp.AnswerLimitDate = reader.ReadInt32();
            //���l(����)
            temp.CommentDtl = reader.ReadString();
            //�I��
            temp.ShelfNo = reader.ReadString();
            //�ǉ��敪
            temp.AdditionalDivCd = reader.ReadInt32();
            //�����敪
            temp.CorrectDivCD = reader.ReadInt32();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //������z����Ŋz
            temp.SalesPriceConsTax = reader.ReadInt64();
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�񓚔[��
            temp.AnswerDelivDate = reader.ReadString();
            //���T�C�N�����i���
            temp.RecyclePrtKindCode = reader.ReadInt32();
            //���T�C�N�����i��ʖ���
            temp.RecyclePrtKindName = reader.ReadString();
            //�┭���i��
            temp.InqGoodsName = reader.ReadString();
            //�񓚏��i��
            temp.AnsGoodsName = reader.ReadString();
            //�┭�������i�ԍ�
            temp.InqPureGoodsNo = reader.ReadString();
            //�񓚏������i�ԍ�
            temp.AnsPureGoodsNo = reader.ReadString();
            //�L�����Z����ԋ敪
            temp.CancelCndtinDiv = reader.ReadInt16();


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
        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMInquiryDtlAnsResultWork temp = GetSCMInquiryDtlAnsResultWork(reader, serInfo);
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
                    retValue = (SCMInquiryDtlAnsResultWork[])lst.ToArray(typeof(SCMInquiryDtlAnsResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    */
    # endregion

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMInquiryDtlAnsResultWork || graph is ArrayList || graph is SCMInquiryDtlAnsResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMInquiryDtlAnsResultWork).FullName));

            if (graph != null && graph is SCMInquiryDtlAnsResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryDtlAnsResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMInquiryDtlAnsResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMInquiryDtlAnsResultWork[])graph).Length;
            }
            else if (graph is SCMInquiryDtlAnsResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //�⍇���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //�⍇���s�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //�⍇�������׎���GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
            //�⍇���斾�׎���GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
            //���i���
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //�戵�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //���i�`��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //�[�i�m�F�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�[�i��
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�������i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsNo
            //�艿
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //�P��
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //���׎捞�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
            //���i�⑫���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //�e����
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //�񓚊���
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //���l(����)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //�ǉ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //������z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //���T�C�N�����i���
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //���T�C�N�����i��ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //�┭���i��
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //�񓚏��i��
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //�┭�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //�񓚏������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //�L�����Z����ԋ敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelCndtinDiv
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //PM��Ǒq�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseCd 
            //PM��Ǒq�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseName
            //PM��ǒI��
            serInfo.MemberInfo.Add(typeof(string)); //PmMainMngShelfNo
            //PM��ǌ��݌�
            serInfo.MemberInfo.Add(typeof(Double)); //PmMainMngPrsntCount
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
            // ���i�K�i�E���L����(�H�����)
            serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForFac 
            // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForCOw 
            // �D�ǐݒ�ڍז��̂Q(�H�����)
            serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForFac
            // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForCOw 
            // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is SCMInquiryDtlAnsResultWork)
            {
                SCMInquiryDtlAnsResultWork temp = (SCMInquiryDtlAnsResultWork)graph;

                SetSCMInquiryDtlAnsResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMInquiryDtlAnsResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMInquiryDtlAnsResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMInquiryDtlAnsResultWork temp in lst)
                {
                    SetSCMInquiryDtlAnsResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMInquiryDtlAnsResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        ////private const int currentMemberCount = 60;// DEL 2013/02/27 qijh #34752
        // private const int currentMemberCount = 64;// ADD 2013/02/27 qijh #34752 // DEL 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�
        private const int currentMemberCount = 68;// ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�

        /// <summary>
        ///  SCMInquiryDtlAnsResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMInquiryDtlAnsResultWork(System.IO.BinaryWriter writer, SCMInquiryDtlAnsResultWork temp)
        {
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�X�V����
            writer.Write(temp.UpdateTime);
            //�⍇���s�ԍ�
            writer.Write(temp.InqRowNumber);
            //�⍇���s�ԍ��}��
            writer.Write(temp.InqRowNumDerivedNo);
            //�⍇�������׎���GUID
            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
            writer.Write(inqOrgDtlDiscGuidArray.Length);
            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
            //�⍇���斾�׎���GUID
            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
            writer.Write(inqOthDtlDiscGuidArray.Length);
            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
            //���i���
            writer.Write(temp.GoodsDivCd);
            //�[�i�敪
            writer.Write(temp.DeliveredGoodsDiv);
            //�戵�敪
            writer.Write(temp.HandleDivCode);
            //���i�`��
            writer.Write(temp.GoodsShape);
            //�[�i�m�F�敪
            writer.Write(temp.DelivrdGdsConfCd);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h�}��
            writer.Write(temp.BLGoodsDrCode);
            //���i����
            writer.Write(temp.GoodsName);
            //������
            writer.Write(temp.SalesOrderCount);
            //�[�i��
            writer.Write(temp.DeliveredGoodsCount);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�������i���[�J�[�R�[�h
            writer.Write(temp.PureGoodsMakerCd);
            //�������i�ԍ�
            writer.Write(temp.PureGoodsNo);
            //�艿
            writer.Write(temp.ListPrice);
            //�P��
            writer.Write(temp.UnitPrice);
            //���׎捞�敪
            writer.Write(temp.DtlTakeinDivCd);
            //���i�⑫���
            writer.Write(temp.GoodsAddInfo);
            //�e���z
            writer.Write(temp.RoughRrofit);
            //�e����
            writer.Write(temp.RoughRate);
            //�񓚊���
            writer.Write(temp.AnswerLimitDate);
            //���l(����)
            writer.Write(temp.CommentDtl);
            //�I��
            writer.Write(temp.ShelfNo);
            //�ǉ��敪
            writer.Write(temp.AdditionalDivCd);
            //�����敪
            writer.Write(temp.CorrectDivCD);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //������z����Ŋz
            writer.Write(temp.SalesPriceConsTax);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�񓚔[��
            writer.Write(temp.AnswerDelivDate);
            //���T�C�N�����i���
            writer.Write(temp.RecyclePrtKindCode);
            //���T�C�N�����i��ʖ���
            writer.Write(temp.RecyclePrtKindName);
            //�┭���i��
            writer.Write(temp.InqGoodsName);
            //�񓚏��i��
            writer.Write(temp.AnsGoodsName);
            //�┭�������i�ԍ�
            writer.Write(temp.InqPureGoodsNo);
            //�񓚏������i�ԍ�
            writer.Write(temp.AnsPureGoodsNo);
            //�L�����Z����ԋ敪
            writer.Write(temp.CancelCndtinDiv);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //PM��Ǒq�ɃR�[�h
            writer.Write(temp.PmMainMngWarehouseCd);
            //PM��Ǒq�ɖ���
            writer.Write(temp.PmMainMngWarehouseName);
            //PM��ǒI��
            writer.Write(temp.PmMainMngShelfNo);
            //PM��ǌ��݌�
            writer.Write(temp.PmMainMngPrsntCount);
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
            // ���i�K�i�E���L����(�H�����)
            writer.Write(temp.GoodsSpecialNtForFac);
            // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            writer.Write(temp.GoodsSpecialNtForCOw);
            // �D�ǐݒ�ڍז��̂Q(�H�����)
            writer.Write(temp.PrmSetDtlName2ForFac);
            // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            writer.Write(temp.PrmSetDtlName2ForCOw);
            // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        ///  SCMInquiryDtlAnsResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMInquiryDtlAnsResultWork GetSCMInquiryDtlAnsResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMInquiryDtlAnsResultWork temp = new SCMInquiryDtlAnsResultWork();

            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateTime = reader.ReadInt32();
            //�⍇���s�ԍ�
            temp.InqRowNumber = reader.ReadInt32();
            //�⍇���s�ԍ��}��
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //�⍇�������׎���GUID
            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
            //�⍇���斾�׎���GUID
            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
            //���i���
            temp.GoodsDivCd = reader.ReadInt32();
            //�[�i�敪
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //�戵�敪
            temp.HandleDivCode = reader.ReadInt32();
            //���i�`��
            temp.GoodsShape = reader.ReadInt32();
            //�[�i�m�F�敪
            temp.DelivrdGdsConfCd = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h�}��
            temp.BLGoodsDrCode = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�[�i��
            temp.DeliveredGoodsCount = reader.ReadDouble();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�������i���[�J�[�R�[�h
            temp.PureGoodsMakerCd = reader.ReadInt32();
            //�������i�ԍ�
            temp.PureGoodsNo = reader.ReadString();
            //�艿
            temp.ListPrice = reader.ReadInt64();
            //�P��
            temp.UnitPrice = reader.ReadInt64();
            //���׎捞�敪
            temp.DtlTakeinDivCd = reader.ReadInt32();
            //���i�⑫���
            temp.GoodsAddInfo = reader.ReadString();
            //�e���z
            temp.RoughRrofit = reader.ReadInt64();
            //�e����
            temp.RoughRate = reader.ReadDouble();
            //�񓚊���
            temp.AnswerLimitDate = reader.ReadInt32();
            //���l(����)
            temp.CommentDtl = reader.ReadString();
            //�I��
            temp.ShelfNo = reader.ReadString();
            //�ǉ��敪
            temp.AdditionalDivCd = reader.ReadInt32();
            //�����敪
            temp.CorrectDivCD = reader.ReadInt32();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //������z����Ŋz
            temp.SalesPriceConsTax = reader.ReadInt64();
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�񓚔[��
            temp.AnswerDelivDate = reader.ReadString();
            //���T�C�N�����i���
            temp.RecyclePrtKindCode = reader.ReadInt32();
            //���T�C�N�����i��ʖ���
            temp.RecyclePrtKindName = reader.ReadString();
            //�┭���i��
            temp.InqGoodsName = reader.ReadString();
            //�񓚏��i��
            temp.AnsGoodsName = reader.ReadString();
            //�┭�������i�ԍ�
            temp.InqPureGoodsNo = reader.ReadString();
            //�񓚏������i�ԍ�
            temp.AnsPureGoodsNo = reader.ReadString();
            //�L�����Z����ԋ敪
            temp.CancelCndtinDiv = reader.ReadInt16();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //PM��Ǒq�ɃR�[�h
            temp.PmMainMngWarehouseCd = reader.ReadString();
            //PM��Ǒq�ɖ���
            temp.PmMainMngWarehouseName = reader.ReadString();
            //PM��ǒI��
            temp.PmMainMngShelfNo = reader.ReadString();
            //PM��ǌ��݌�
            temp.PmMainMngPrsntCount = reader.ReadDouble();
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
            // ���i�K�i�E���L����(�H�����)
            temp.GoodsSpecialNtForFac = reader.ReadString();
            // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            temp.GoodsSpecialNtForCOw = reader.ReadString();
            // �D�ǐݒ�ڍז��̂Q(�H�����)
            temp.PrmSetDtlName2ForFac = reader.ReadString();
            // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            temp.PrmSetDtlName2ForCOw = reader.ReadString();
            // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<

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
        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMInquiryDtlAnsResultWork temp = GetSCMInquiryDtlAnsResultWork(reader, serInfo);
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
                    retValue = (SCMInquiryDtlAnsResultWork[])lst.ToArray(typeof(SCMInquiryDtlAnsResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
#region �폜
//using System;
//using System.Collections;
//using Broadleaf.Library.Data;
//using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Resources;

//namespace Broadleaf.Application.Remoting.ParamData
//{
//    /// public class name:   SCMInquiryDtlAnsResultWork
//    /// <summary>
//    ///                      SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N
//    /// </summary>
//    /// <remarks>
//    /// <br>note             :   SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N�w�b�_�t�@�C��</br>
//    /// <br>Programmer       :   ��������</br>
//    /// <br>Date             :    2009/4/13</br>
//    /// <br>Genarated Date   :   2009/06/19  (CSharp File Generated Date)</br>
//    /// <br>Update Note      :   </br>
//    /// </remarks>
//    [Serializable]
//    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
//    public class SCMInquiryDtlAnsResultWork 
//    {
//        /// <summary>���Ӑ�R�[�h</summary>
//        private Int32 _customerCode;

//        /// <summary>���Ӑ於��</summary>
//        private string _customerName = "";

//        /// <summary>������t</summary>
//        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
//        private DateTime _salesDate;

//        /// <summary>�󒍃X�e�[�^�X</summary>
//        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
//        private Int32 _acptAnOdrStatus;

//        /// <summary>����`�[�ԍ�</summary>
//        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
//        private string _salesSlipNum = "";

//        /// <summary>������z�i�Ŕ����j</summary>
//        private Int64 _salesMoneyTaxExc;

//        /// <summary>�⍇������ƃR�[�h</summary>
//        private string _inqOriginalEpCd = "";

//        /// <summary>�⍇�������_�R�[�h</summary>
//        private string _inqOriginalSecCd = "";

//        /// <summary>�⍇�����ƃR�[�h</summary>
//        private string _inqOtherEpCd = "";

//        /// <summary>�⍇���拒�_�R�[�h</summary>
//        private string _inqOtherSecCd = "";

//        /// <summary>�⍇���ԍ�</summary>
//        private Int64 _inquiryNumber;

//        /// <summary>�X�V�N����</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private DateTime _updateDate;

//        /// <summary>�X�V����</summary>
//        /// <remarks>HHMMSSXXX</remarks>
//        private Int32 _updateTime;

//        /// <summary>�⍇���s�ԍ�</summary>
//        private Int32 _inqRowNumber;

//        /// <summary>�⍇���s�ԍ��}��</summary>
//        private Int32 _inqRowNumDerivedNo;

//        /// <summary>�⍇�������׎���GUID</summary>
//        private Guid _inqOrgDtlDiscGuid;

//        /// <summary>�⍇���斾�׎���GUID</summary>
//        /// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
//        private Guid _inqOthDtlDiscGuid;

//        /// <summary>���i���</summary>
//        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
//        private Int32 _goodsDivCd;

//        /// <summary>�[�i�敪</summary>
//        /// <remarks>0:�z��,1:����</remarks>
//        private Int32 _deliveredGoodsDiv;

//        /// <summary>�戵�敪</summary>
//        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
//        private Int32 _handleDivCode;

//        /// <summary>���i�`��</summary>
//        /// <remarks>1:���i,2:�p�i</remarks>
//        private Int32 _goodsShape;

//        /// <summary>�[�i�m�F�敪</summary>
//        /// <remarks>0:���m�F,1:�m�F</remarks>
//        private Int32 _delivrdGdsConfCd;

//        /// <summary>�[�i�����\���</summary>
//        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
//        private DateTime _deliGdsCmpltDueDate;

//        /// <summary>BL���i�R�[�h</summary>
//        private Int32 _bLGoodsCode;

//        /// <summary>BL���i�R�[�h�}��</summary>
//        private Int32 _bLGoodsDrCode;

//        /// <summary>�┭���i��</summary>
//        /// <remarks>(���p�S�p����)</remarks>
//        private string _inqGoodsName = "";

//        /// <summary>�񓚏��i��</summary>
//        /// <remarks>(���p�S�p����)</remarks>
//        private string _ansGoodsName = "";

//        /// <summary>������</summary>
//        private Double _salesOrderCount;

//        /// <summary>�[�i��</summary>
//        private Double _deliveredGoodsCount;

//        /// <summary>���i�ԍ�</summary>
//        private string _goodsNo = "";

//        /// <summary>���i���[�J�[�R�[�h</summary>
//        private Int32 _goodsMakerCd;

//        /// <summary>�������i���[�J�[�R�[�h</summary>
//        private Int32 _pureGoodsMakerCd;

//        /// <summary>�┭�������i�ԍ�</summary>
//        /// <remarks>(���p�̂�)</remarks>
//        private string _inqPureGoodsNo = "";

//        /// <summary>�񓚏������i�ԍ�</summary>
//        /// <remarks>(���p�̂�)</remarks>
//        private string _ansPureGoodsNo = "";

//        /// <summary>�艿</summary>
//        /// <remarks>0:�I�[�v�����i</remarks>
//        private Int64 _listPrice;

//        /// <summary>�P��</summary>
//        private Int64 _unitPrice;

//        /// <summary>���׎捞�敪</summary>
//        /// <remarks>0:���捞 1:�捞��</remarks>
//        private Int32 _dtlTakeinDivCd;

//        /// <summary>���i�⑫���</summary>
//        private string _goodsAddInfo = "";

//        /// <summary>�e���z</summary>
//        private Int64 _roughRrofit;

//        /// <summary>�e����</summary>
//        private Double _roughRate;

//        /// <summary>�񓚊���</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private Int32 _answerLimitDate;

//        /// <summary>���l(����)</summary>
//        private string _commentDtl = "";

//        /// <summary>�I��</summary>
//        private string _shelfNo = "";

//        /// <summary>�ǉ��敪</summary>
//        private Int32 _additionalDivCd;

//        /// <summary>�����敪</summary>
//        private Int32 _correctDivCD;

//        /// <summary>�⍇���E�������</summary>
//        /// <remarks>1:�⍇�� 2:����</remarks>
//        private Int32 _inqOrdDivCd;

//        /// <summary>������z����Ŋz</summary>
//        /// <remarks>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</remarks>
//        private Int64 _salesPriceConsTax;

//        /// <summary>��ƃR�[�h</summary>
//        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
//        private string _enterpriseCode = "";

//        /// <summary>����s�ԍ�</summary>
//        private Int32 _salesRowNo;

//        /// <summary>�L�����y�[���R�[�h</summary>
//        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
//        private Int32 _campaignCode;

//        /// <summary>�݌ɋ敪</summary>
//        /// <remarks>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</remarks>
//        private Int32 _stockDiv;

//        /// <summary>�񓚔[��</summary>
//        private string _answerDelivDate = "";


//        /// public propaty name  :  CustomerCode
//        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CustomerCode
//        {
//            get { return _customerCode; }
//            set { _customerCode = value; }
//        }

//        /// public propaty name  :  CustomerName
//        /// <summary>���Ӑ於�̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CustomerName
//        {
//            get { return _customerName; }
//            set { _customerName = value; }
//        }

//        /// public propaty name  :  SalesDate
//        /// <summary>������t�v���p�e�B</summary>
//        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ������t�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public DateTime SalesDate
//        {
//            get { return _salesDate; }
//            set { _salesDate = value; }
//        }

//        /// public propaty name  :  AcptAnOdrStatus
//        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
//        /// <value>10:����,20:��,30:����,40:�o��</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AcptAnOdrStatus
//        {
//            get { return _acptAnOdrStatus; }
//            set { _acptAnOdrStatus = value; }
//        }

//        /// public propaty name  :  SalesSlipNum
//        /// <summary>����`�[�ԍ��v���p�e�B</summary>
//        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string SalesSlipNum
//        {
//            get { return _salesSlipNum; }
//            set { _salesSlipNum = value; }
//        }

//        /// public propaty name  :  SalesMoneyTaxExc
//        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 SalesMoneyTaxExc
//        {
//            get { return _salesMoneyTaxExc; }
//            set { _salesMoneyTaxExc = value; }
//        }

//        /// public propaty name  :  InqOriginalEpCd
//        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOriginalEpCd
//        {
//            get { return _inqOriginalEpCd; }
//            set { _inqOriginalEpCd = value; }
//        }

//        /// public propaty name  :  InqOriginalSecCd
//        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOriginalSecCd
//        {
//            get { return _inqOriginalSecCd; }
//            set { _inqOriginalSecCd = value; }
//        }

//        /// public propaty name  :  InqOtherEpCd
//        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOtherEpCd
//        {
//            get { return _inqOtherEpCd; }
//            set { _inqOtherEpCd = value; }
//        }

//        /// public propaty name  :  InqOtherSecCd
//        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqOtherSecCd
//        {
//            get { return _inqOtherSecCd; }
//            set { _inqOtherSecCd = value; }
//        }

//        /// public propaty name  :  InquiryNumber
//        /// <summary>�⍇���ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 InquiryNumber
//        {
//            get { return _inquiryNumber; }
//            set { _inquiryNumber = value; }
//        }

//        /// public propaty name  :  UpdateDate
//        /// <summary>�X�V�N�����v���p�e�B</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �X�V�N�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public DateTime UpdateDate
//        {
//            get { return _updateDate; }
//            set { _updateDate = value; }
//        }

//        /// public propaty name  :  UpdateTime
//        /// <summary>�X�V���ԃv���p�e�B</summary>
//        /// <value>HHMMSSXXX</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �X�V���ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 UpdateTime
//        {
//            get { return _updateTime; }
//            set { _updateTime = value; }
//        }

//        /// public propaty name  :  InqRowNumber
//        /// <summary>�⍇���s�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqRowNumber
//        {
//            get { return _inqRowNumber; }
//            set { _inqRowNumber = value; }
//        }

//        /// public propaty name  :  InqRowNumDerivedNo
//        /// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqRowNumDerivedNo
//        {
//            get { return _inqRowNumDerivedNo; }
//            set { _inqRowNumDerivedNo = value; }
//        }

//        /// public propaty name  :  InqOrgDtlDiscGuid
//        /// <summary>�⍇�������׎���GUID�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇�������׎���GUID�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Guid InqOrgDtlDiscGuid
//        {
//            get { return _inqOrgDtlDiscGuid; }
//            set { _inqOrgDtlDiscGuid = value; }
//        }

//        /// public propaty name  :  InqOthDtlDiscGuid
//        /// <summary>�⍇���斾�׎���GUID�v���p�e�B</summary>
//        /// <value>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���斾�׎���GUID�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Guid InqOthDtlDiscGuid
//        {
//            get { return _inqOthDtlDiscGuid; }
//            set { _inqOthDtlDiscGuid = value; }
//        }

//        /// public propaty name  :  GoodsDivCd
//        /// <summary>���i��ʃv���p�e�B</summary>
//        /// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i��ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsDivCd
//        {
//            get { return _goodsDivCd; }
//            set { _goodsDivCd = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsDiv
//        /// <summary>�[�i�敪�v���p�e�B</summary>
//        /// <value>0:�z��,1:����</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 DeliveredGoodsDiv
//        {
//            get { return _deliveredGoodsDiv; }
//            set { _deliveredGoodsDiv = value; }
//        }

//        /// public propaty name  :  HandleDivCode
//        /// <summary>�戵�敪�v���p�e�B</summary>
//        /// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �戵�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 HandleDivCode
//        {
//            get { return _handleDivCode; }
//            set { _handleDivCode = value; }
//        }

//        /// public propaty name  :  GoodsShape
//        /// <summary>���i�`�ԃv���p�e�B</summary>
//        /// <value>1:���i,2:�p�i</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�`�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsShape
//        {
//            get { return _goodsShape; }
//            set { _goodsShape = value; }
//        }

//        /// public propaty name  :  DelivrdGdsConfCd
//        /// <summary>�[�i�m�F�敪�v���p�e�B</summary>
//        /// <value>0:���m�F,1:�m�F</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 DelivrdGdsConfCd
//        {
//            get { return _delivrdGdsConfCd; }
//            set { _delivrdGdsConfCd = value; }
//        }

//        /// public propaty name  :  DeliGdsCmpltDueDate
//        /// <summary>�[�i�����\����v���p�e�B</summary>
//        /// <value>�[�i�\����t YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i�����\����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public DateTime DeliGdsCmpltDueDate
//        {
//            get { return _deliGdsCmpltDueDate; }
//            set { _deliGdsCmpltDueDate = value; }
//        }

//        /// public propaty name  :  BLGoodsCode
//        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 BLGoodsCode
//        {
//            get { return _bLGoodsCode; }
//            set { _bLGoodsCode = value; }
//        }

//        /// public propaty name  :  BLGoodsDrCode
//        /// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 BLGoodsDrCode
//        {
//            get { return _bLGoodsDrCode; }
//            set { _bLGoodsDrCode = value; }
//        }

//        /// public propaty name  :  InqGoodsName
//        /// <summary>�┭���i���v���p�e�B</summary>
//        /// <value>(���p�S�p����)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �┭���i���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqGoodsName
//        {
//            get { return _inqGoodsName; }
//            set { _inqGoodsName = value; }
//        }

//        /// public propaty name  :  AnsGoodsName
//        /// <summary>�񓚏��i���v���p�e�B</summary>
//        /// <value>(���p�S�p����)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏��i���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsGoodsName
//        {
//            get { return _ansGoodsName; }
//            set { _ansGoodsName = value; }
//        }

//        /// public propaty name  :  SalesOrderCount
//        /// <summary>�������v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �������v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Double SalesOrderCount
//        {
//            get { return _salesOrderCount; }
//            set { _salesOrderCount = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsCount
//        /// <summary>�[�i���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[�i���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Double DeliveredGoodsCount
//        {
//            get { return _deliveredGoodsCount; }
//            set { _deliveredGoodsCount = value; }
//        }

//        /// public propaty name  :  GoodsNo
//        /// <summary>���i�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsNo
//        {
//            get { return _goodsNo; }
//            set { _goodsNo = value; }
//        }

//        /// public propaty name  :  GoodsMakerCd
//        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsMakerCd
//        {
//            get { return _goodsMakerCd; }
//            set { _goodsMakerCd = value; }
//        }

//        /// public propaty name  :  PureGoodsMakerCd
//        /// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 PureGoodsMakerCd
//        {
//            get { return _pureGoodsMakerCd; }
//            set { _pureGoodsMakerCd = value; }
//        }

//        /// public propaty name  :  InqPureGoodsNo
//        /// <summary>�┭�������i�ԍ��v���p�e�B</summary>
//        /// <value>(���p�̂�)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string InqPureGoodsNo
//        {
//            get { return _inqPureGoodsNo; }
//            set { _inqPureGoodsNo = value; }
//        }

//        /// public propaty name  :  AnsPureGoodsNo
//        /// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
//        /// <value>(���p�̂�)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnsPureGoodsNo
//        {
//            get { return _ansPureGoodsNo; }
//            set { _ansPureGoodsNo = value; }
//        }

//        /// public propaty name  :  ListPrice
//        /// <summary>�艿�v���p�e�B</summary>
//        /// <value>0:�I�[�v�����i</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �艿�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 ListPrice
//        {
//            get { return _listPrice; }
//            set { _listPrice = value; }
//        }

//        /// public propaty name  :  UnitPrice
//        /// <summary>�P���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �P���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 UnitPrice
//        {
//            get { return _unitPrice; }
//            set { _unitPrice = value; }
//        }

//        /// public propaty name  :  DtlTakeinDivCd
//        /// <summary>���׎捞�敪�v���p�e�B</summary>
//        /// <value>0:���捞 1:�捞��</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���׎捞�敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 DtlTakeinDivCd
//        {
//            get { return _dtlTakeinDivCd; }
//            set { _dtlTakeinDivCd = value; }
//        }

//        /// public propaty name  :  GoodsAddInfo
//        /// <summary>���i�⑫���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�⑫���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsAddInfo
//        {
//            get { return _goodsAddInfo; }
//            set { _goodsAddInfo = value; }
//        }

//        /// public propaty name  :  RoughRrofit
//        /// <summary>�e���z�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �e���z�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 RoughRrofit
//        {
//            get { return _roughRrofit; }
//            set { _roughRrofit = value; }
//        }

//        /// public propaty name  :  RoughRate
//        /// <summary>�e�����v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �e�����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Double RoughRate
//        {
//            get { return _roughRate; }
//            set { _roughRate = value; }
//        }

//        /// public propaty name  :  AnswerLimitDate
//        /// <summary>�񓚊����v���p�e�B</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚊����v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AnswerLimitDate
//        {
//            get { return _answerLimitDate; }
//            set { _answerLimitDate = value; }
//        }

//        /// public propaty name  :  CommentDtl
//        /// <summary>���l(����)�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���l(����)�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CommentDtl
//        {
//            get { return _commentDtl; }
//            set { _commentDtl = value; }
//        }

//        /// public propaty name  :  ShelfNo
//        /// <summary>�I�ԃv���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �I�ԃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string ShelfNo
//        {
//            get { return _shelfNo; }
//            set { _shelfNo = value; }
//        }

//        /// public propaty name  :  AdditionalDivCd
//        /// <summary>�ǉ��敪�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �ǉ��敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 AdditionalDivCd
//        {
//            get { return _additionalDivCd; }
//            set { _additionalDivCd = value; }
//        }

//        /// public propaty name  :  CorrectDivCD
//        /// <summary>�����敪�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �����敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CorrectDivCD
//        {
//            get { return _correctDivCD; }
//            set { _correctDivCD = value; }
//        }

//        /// public propaty name  :  InqOrdDivCd
//        /// <summary>�⍇���E������ʃv���p�e�B</summary>
//        /// <value>1:�⍇�� 2:����</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 InqOrdDivCd
//        {
//            get { return _inqOrdDivCd; }
//            set { _inqOrdDivCd = value; }
//        }

//        /// public propaty name  :  SalesPriceConsTax
//        /// <summary>������z����Ŋz�v���p�e�B</summary>
//        /// <value>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ������z����Ŋz�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int64 SalesPriceConsTax
//        {
//            get { return _salesPriceConsTax; }
//            set { _salesPriceConsTax = value; }
//        }

//        /// public propaty name  :  EnterpriseCode
//        /// <summary>��ƃR�[�h�v���p�e�B</summary>
//        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string EnterpriseCode
//        {
//            get { return _enterpriseCode; }
//            set { _enterpriseCode = value; }
//        }

//        /// public propaty name  :  SalesRowNo
//        /// <summary>����s�ԍ��v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 SalesRowNo
//        {
//            get { return _salesRowNo; }
//            set { _salesRowNo = value; }
//        }

//        /// public propaty name  :  CampaignCode
//        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
//        /// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CampaignCode
//        {
//            get { return _campaignCode; }
//            set { _campaignCode = value; }
//        }

//        /// public propaty name  :  StockDiv
//        /// <summary>�݌ɋ敪�v���p�e�B</summary>
//        /// <value>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 StockDiv
//        {
//            get { return _stockDiv; }
//            set { _stockDiv = value; }
//        }

//        /// public propaty name  :  AnswerDelivDate
//        /// <summary>�񓚔[���v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �񓚔[���v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string AnswerDelivDate
//        {
//            get { return _answerDelivDate; }
//            set { _answerDelivDate = value; }
//        }


//        /// <summary>
//        /// SCM�₢���킹�ꗗ���o����(���׉�)�N���X���[�N�R���X�g���N�^
//        /// </summary>
//        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public SCMInquiryDtlAnsResultWork()
//        {
//        }

//    }

//    /// <summary>
//    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
//    /// </summary>
//    /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X(object)</returns>
//    /// <remarks>
//    /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
//    /// <br>Programer        :   ��������</br>
//    /// </remarks>
//    public class SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
//    {
//        #region ICustomSerializationSurrogate �����o

//        /// <summary>
//        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
//        /// </summary>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public void Serialize(System.IO.BinaryWriter writer, object graph)
//        {
//            // TODO:  SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
//            if (writer == null)
//                throw new ArgumentNullException();

//            if (graph != null && !(graph is SCMInquiryDtlAnsResultWork || graph is ArrayList || graph is SCMInquiryDtlAnsResultWork[]))
//                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMInquiryDtlAnsResultWork).FullName));

//            if (graph != null && graph is SCMInquiryDtlAnsResultWork)
//            {
//                Type t = graph.GetType();
//                if (!CustomFormatterServices.NeedCustomSerialization(t))
//                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
//            }

//            //SerializationTypeInfo
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryDtlAnsResultWork");

//            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
//            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
//            if (graph is ArrayList)
//            {
//                serInfo.RetTypeInfo = 0;
//                occurrence = ((ArrayList)graph).Count;
//            }
//            else if (graph is SCMInquiryDtlAnsResultWork[])
//            {
//                serInfo.RetTypeInfo = 2;
//                occurrence = ((SCMInquiryDtlAnsResultWork[])graph).Length;
//            }
//            else if (graph is SCMInquiryDtlAnsResultWork)
//            {
//                serInfo.RetTypeInfo = 1;
//                occurrence = 1;
//            }

//            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

//            //���Ӑ�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
//            //���Ӑ於��
//            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
//            //������t
//            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
//            //�󒍃X�e�[�^�X
//            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
//            //����`�[�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
//            //������z�i�Ŕ����j
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
//            //�⍇������ƃR�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
//            //�⍇�������_�R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
//            //�⍇�����ƃR�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
//            //�⍇���拒�_�R�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
//            //�⍇���ԍ�
//            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
//            //�X�V�N����
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
//            //�X�V����
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
//            //�⍇���s�ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
//            //�⍇���s�ԍ��}��
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
//            //�⍇�������׎���GUID
//            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
//            //�⍇���斾�׎���GUID
//            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
//            //���i���
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
//            //�[�i�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
//            //�戵�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
//            //���i�`��
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
//            //�[�i�m�F�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
//            //�[�i�����\���
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
//            //BL���i�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
//            //BL���i�R�[�h�}��
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
//            //�┭���i��
//            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
//            //�񓚏��i��
//            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
//            //������
//            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
//            //�[�i��
//            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
//            //���i�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
//            //���i���[�J�[�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
//            //�������i���[�J�[�R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
//            //�┭�������i�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
//            //�񓚏������i�ԍ�
//            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
//            //�艿
//            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
//            //�P��
//            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
//            //���׎捞�敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
//            //���i�⑫���
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
//            //�e���z
//            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
//            //�e����
//            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
//            //�񓚊���
//            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
//            //���l(����)
//            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
//            //�I��
//            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
//            //�ǉ��敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
//            //�����敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
//            //�⍇���E�������
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
//            //������z����Ŋz
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
//            //��ƃR�[�h
//            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
//            //����s�ԍ�
//            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
//            //�L�����y�[���R�[�h
//            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
//            //�݌ɋ敪
//            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
//            //�񓚔[��
//            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate


//            serInfo.Serialize(writer, serInfo);
//            if (graph is SCMInquiryDtlAnsResultWork)
//            {
//                SCMInquiryDtlAnsResultWork temp = (SCMInquiryDtlAnsResultWork)graph;

//                SetSCMInquiryDtlAnsResultWork(writer, temp);
//            }
//            else
//            {
//                ArrayList lst = null;
//                if (graph is SCMInquiryDtlAnsResultWork[])
//                {
//                    lst = new ArrayList();
//                    lst.AddRange((SCMInquiryDtlAnsResultWork[])graph);
//                }
//                else
//                {
//                    lst = (ArrayList)graph;
//                }

//                foreach (SCMInquiryDtlAnsResultWork temp in lst)
//                {
//                    SetSCMInquiryDtlAnsResultWork(writer, temp);
//                }

//            }


//        }


//        /// <summary>
//        /// SCMInquiryDtlAnsResultWork�����o��(public�v���p�e�B��)
//        /// </summary>
//        private const int currentMemberCount = 52;

//        /// <summary>
//        ///  SCMInquiryDtlAnsResultWork�C���X�^���X��������
//        /// </summary>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�̃C���X�^���X����������</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        private void SetSCMInquiryDtlAnsResultWork(System.IO.BinaryWriter writer, SCMInquiryDtlAnsResultWork temp)
//        {
//            //���Ӑ�R�[�h
//            writer.Write(temp.CustomerCode);
//            //���Ӑ於��
//            writer.Write(temp.CustomerName);
//            //������t
//            writer.Write((Int64)temp.SalesDate.Ticks);
//            //�󒍃X�e�[�^�X
//            writer.Write(temp.AcptAnOdrStatus);
//            //����`�[�ԍ�
//            writer.Write(temp.SalesSlipNum);
//            //������z�i�Ŕ����j
//            writer.Write(temp.SalesMoneyTaxExc);
//            //�⍇������ƃR�[�h
//            writer.Write(temp.InqOriginalEpCd);
//            //�⍇�������_�R�[�h
//            writer.Write(temp.InqOriginalSecCd);
//            //�⍇�����ƃR�[�h
//            writer.Write(temp.InqOtherEpCd);
//            //�⍇���拒�_�R�[�h
//            writer.Write(temp.InqOtherSecCd);
//            //�⍇���ԍ�
//            writer.Write(temp.InquiryNumber);
//            //�X�V�N����
//            writer.Write((Int64)temp.UpdateDate.Ticks);
//            //�X�V����
//            writer.Write(temp.UpdateTime);
//            //�⍇���s�ԍ�
//            writer.Write(temp.InqRowNumber);
//            //�⍇���s�ԍ��}��
//            writer.Write(temp.InqRowNumDerivedNo);
//            //�⍇�������׎���GUID
//            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
//            writer.Write(inqOrgDtlDiscGuidArray.Length);
//            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
//            //�⍇���斾�׎���GUID
//            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
//            writer.Write(inqOthDtlDiscGuidArray.Length);
//            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
//            //���i���
//            writer.Write(temp.GoodsDivCd);
//            //�[�i�敪
//            writer.Write(temp.DeliveredGoodsDiv);
//            //�戵�敪
//            writer.Write(temp.HandleDivCode);
//            //���i�`��
//            writer.Write(temp.GoodsShape);
//            //�[�i�m�F�敪
//            writer.Write(temp.DelivrdGdsConfCd);
//            //�[�i�����\���
//            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
//            //BL���i�R�[�h
//            writer.Write(temp.BLGoodsCode);
//            //BL���i�R�[�h�}��
//            writer.Write(temp.BLGoodsDrCode);
//            //�┭���i��
//            writer.Write(temp.InqGoodsName);
//            //�񓚏��i��
//            writer.Write(temp.AnsGoodsName);
//            //������
//            writer.Write(temp.SalesOrderCount);
//            //�[�i��
//            writer.Write(temp.DeliveredGoodsCount);
//            //���i�ԍ�
//            writer.Write(temp.GoodsNo);
//            //���i���[�J�[�R�[�h
//            writer.Write(temp.GoodsMakerCd);
//            //�������i���[�J�[�R�[�h
//            writer.Write(temp.PureGoodsMakerCd);
//            //�┭�������i�ԍ�
//            writer.Write(temp.InqPureGoodsNo);
//            //�񓚏������i�ԍ�
//            writer.Write(temp.AnsPureGoodsNo);
//            //�艿
//            writer.Write(temp.ListPrice);
//            //�P��
//            writer.Write(temp.UnitPrice);
//            //���׎捞�敪
//            writer.Write(temp.DtlTakeinDivCd);
//            //���i�⑫���
//            writer.Write(temp.GoodsAddInfo);
//            //�e���z
//            writer.Write(temp.RoughRrofit);
//            //�e����
//            writer.Write(temp.RoughRate);
//            //�񓚊���
//            writer.Write(temp.AnswerLimitDate);
//            //���l(����)
//            writer.Write(temp.CommentDtl);
//            //�I��
//            writer.Write(temp.ShelfNo);
//            //�ǉ��敪
//            writer.Write(temp.AdditionalDivCd);
//            //�����敪
//            writer.Write(temp.CorrectDivCD);
//            //�⍇���E�������
//            writer.Write(temp.InqOrdDivCd);
//            //������z����Ŋz
//            writer.Write(temp.SalesPriceConsTax);
//            //��ƃR�[�h
//            writer.Write(temp.EnterpriseCode);
//            //����s�ԍ�
//            writer.Write(temp.SalesRowNo);
//            //�L�����y�[���R�[�h
//            writer.Write(temp.CampaignCode);
//            //�݌ɋ敪
//            writer.Write(temp.StockDiv);
//            //�񓚔[��
//            writer.Write(temp.AnswerDelivDate);

//        }

//        /// <summary>
//        ///  SCMInquiryDtlAnsResultWork�C���X�^���X�擾
//        /// </summary>
//        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�̃C���X�^���X���擾���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        private SCMInquiryDtlAnsResultWork GetSCMInquiryDtlAnsResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
//        {
//            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
//            // serInfo.MemberInfo.Count < currentMemberCount
//            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

//            SCMInquiryDtlAnsResultWork temp = new SCMInquiryDtlAnsResultWork();

//            //���Ӑ�R�[�h
//            temp.CustomerCode = reader.ReadInt32();
//            //���Ӑ於��
//            temp.CustomerName = reader.ReadString();
//            //������t
//            temp.SalesDate = new DateTime(reader.ReadInt64());
//            //�󒍃X�e�[�^�X
//            temp.AcptAnOdrStatus = reader.ReadInt32();
//            //����`�[�ԍ�
//            temp.SalesSlipNum = reader.ReadString();
//            //������z�i�Ŕ����j
//            temp.SalesMoneyTaxExc = reader.ReadInt64();
//            //�⍇������ƃR�[�h
//            temp.InqOriginalEpCd = reader.ReadString();
//            //�⍇�������_�R�[�h
//            temp.InqOriginalSecCd = reader.ReadString();
//            //�⍇�����ƃR�[�h
//            temp.InqOtherEpCd = reader.ReadString();
//            //�⍇���拒�_�R�[�h
//            temp.InqOtherSecCd = reader.ReadString();
//            //�⍇���ԍ�
//            temp.InquiryNumber = reader.ReadInt64();
//            //�X�V�N����
//            temp.UpdateDate = new DateTime(reader.ReadInt64());
//            //�X�V����
//            temp.UpdateTime = reader.ReadInt32();
//            //�⍇���s�ԍ�
//            temp.InqRowNumber = reader.ReadInt32();
//            //�⍇���s�ԍ��}��
//            temp.InqRowNumDerivedNo = reader.ReadInt32();
//            //�⍇�������׎���GUID
//            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
//            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
//            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
//            //�⍇���斾�׎���GUID
//            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
//            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
//            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
//            //���i���
//            temp.GoodsDivCd = reader.ReadInt32();
//            //�[�i�敪
//            temp.DeliveredGoodsDiv = reader.ReadInt32();
//            //�戵�敪
//            temp.HandleDivCode = reader.ReadInt32();
//            //���i�`��
//            temp.GoodsShape = reader.ReadInt32();
//            //�[�i�m�F�敪
//            temp.DelivrdGdsConfCd = reader.ReadInt32();
//            //�[�i�����\���
//            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
//            //BL���i�R�[�h
//            temp.BLGoodsCode = reader.ReadInt32();
//            //BL���i�R�[�h�}��
//            temp.BLGoodsDrCode = reader.ReadInt32();
//            //�┭���i��
//            temp.InqGoodsName = reader.ReadString();
//            //�񓚏��i��
//            temp.AnsGoodsName = reader.ReadString();
//            //������
//            temp.SalesOrderCount = reader.ReadDouble();
//            //�[�i��
//            temp.DeliveredGoodsCount = reader.ReadDouble();
//            //���i�ԍ�
//            temp.GoodsNo = reader.ReadString();
//            //���i���[�J�[�R�[�h
//            temp.GoodsMakerCd = reader.ReadInt32();
//            //�������i���[�J�[�R�[�h
//            temp.PureGoodsMakerCd = reader.ReadInt32();
//            //�┭�������i�ԍ�
//            temp.InqPureGoodsNo = reader.ReadString();
//            //�񓚏������i�ԍ�
//            temp.AnsPureGoodsNo = reader.ReadString();
//            //�艿
//            temp.ListPrice = reader.ReadInt64();
//            //�P��
//            temp.UnitPrice = reader.ReadInt64();
//            //���׎捞�敪
//            temp.DtlTakeinDivCd = reader.ReadInt32();
//            //���i�⑫���
//            temp.GoodsAddInfo = reader.ReadString();
//            //�e���z
//            temp.RoughRrofit = reader.ReadInt64();
//            //�e����
//            temp.RoughRate = reader.ReadDouble();
//            //�񓚊���
//            temp.AnswerLimitDate = reader.ReadInt32();
//            //���l(����)
//            temp.CommentDtl = reader.ReadString();
//            //�I��
//            temp.ShelfNo = reader.ReadString();
//            //�ǉ��敪
//            temp.AdditionalDivCd = reader.ReadInt32();
//            //�����敪
//            temp.CorrectDivCD = reader.ReadInt32();
//            //�⍇���E�������
//            temp.InqOrdDivCd = reader.ReadInt32();
//            //������z����Ŋz
//            temp.SalesPriceConsTax = reader.ReadInt64();
//            //��ƃR�[�h
//            temp.EnterpriseCode = reader.ReadString();
//            //����s�ԍ�
//            temp.SalesRowNo = reader.ReadInt32();
//            //�L�����y�[���R�[�h
//            temp.CampaignCode = reader.ReadInt32();
//            //�݌ɋ敪
//            temp.StockDiv = reader.ReadInt32();
//            //�񓚔[��
//            temp.AnswerDelivDate = reader.ReadString();


//            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
//            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
//            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
//            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
//            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
//            {
//                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
//                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
//                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
//                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
//                int optCount = 0;
//                object oMemberType = serInfo.MemberInfo[k];
//                if (oMemberType is Type)
//                {
//                    Type t = (Type)oMemberType;
//                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
//                    if (t.Equals(typeof(int)))
//                    {
//                        optCount = Convert.ToInt32(oData);
//                    }
//                    else
//                    {
//                        optCount = 0;
//                    }
//                }
//                else if (oMemberType is string)
//                {
//                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
//                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
//                }
//            }
//            return temp;
//        }

//        /// <summary>
//        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
//        /// </summary>
//        /// <returns>SCMInquiryDtlAnsResultWork�N���X�̃C���X�^���X(object)</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryDtlAnsResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public object Deserialize(System.IO.BinaryReader reader)
//        {
//            object retValue = null;
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
//            ArrayList lst = new ArrayList();
//            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
//            {
//                SCMInquiryDtlAnsResultWork temp = GetSCMInquiryDtlAnsResultWork(reader, serInfo);
//                lst.Add(temp);
//            }
//            switch (serInfo.RetTypeInfo)
//            {
//                case 0:
//                    retValue = lst;
//                    break;
//                case 1:
//                    retValue = lst[0];
//                    break;
//                case 2:
//                    retValue = (SCMInquiryDtlAnsResultWork[])lst.ToArray(typeof(SCMInquiryDtlAnsResultWork));
//                    break;
//            }
//            return retValue;
//        }

//        #endregion
//    }

//}
#endregion
// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

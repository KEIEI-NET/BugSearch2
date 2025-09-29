using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ScmOdSetDt
    /// <summary>
    ///                      SCM�󔭒��Z�b�g���i�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�󔭒��Z�b�g���i�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/8/1</br>
    /// <br>Genarated Date   :   2011/08/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ScmOdSetDt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

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

        /// <summary>�Z�b�g���i���[�J�[�R�[�h</summary>
        private Int32 _setPartsMkrCd;

        /// <summary>�Z�b�g���i�ԍ�</summary>
        private string _setPartsNumber = "";

        /// <summary>�Z�b�g���i�e�q�ԍ�</summary>
        /// <remarks>0:�e,1-*:�q</remarks>
        private Int32 _setPartsMainSubNo;

        /// <summary>���i���</summary>
        /// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����</remarks>
        private Int32 _goodsDivCd;

        /// <summary>���T�C�N�����i���</summary>
        /// <remarks>1:���r���h 2:����</remarks>
        private Int32 _recyclePrtKindCode;

        /// <summary>���T�C�N�����i��ʖ���</summary>
        private string _recyclePrtKindName = "";

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

        /// <summary>�񓚔[��</summary>
        private string _answerDeliveryDate = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h�}��</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>�┭���i��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _inqGoodsName = "";

        /// <summary>�񓚏��i��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _ansGoodsName = "";

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�[�i��</summary>
        private Double _deliveredGoodsCount;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i���[�J�[����</summary>
        private string _goodsMakerNm = "";

        /// <summary>�������i���[�J�[�R�[�h</summary>
        private Int32 _pureGoodsMakerCd;

        /// <summary>�┭�������i�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _inqPureGoodsNo = "";

        /// <summary>�񓚏������i�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _ansPureGoodsNo = "";

        /// <summary>�艿</summary>
        private Int64 _listPrice;

        /// <summary>�P��</summary>
        private Int64 _unitPrice;

        /// <summary>���i�⑫���</summary>
        private string _goodsAddInfo = "";

        /// <summary>�e���z</summary>
        private Int64 _roughRrofit;

        /// <summary>�e����</summary>
        private Double _roughRate;

        /// <summary>�񓚊���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _answerLimitDate;

        /// <summary>���l(����)</summary>
        private string _commentDtl = "";

        /// <summary>�I��</summary>
        private string _shelfNo = "";

        /// <summary>PM�󒍃X�e�[�^�X</summary>
        /// <remarks>10�F���� 20:�� 30:���� 40:�o��</remarks>
        private Int32 _pMAcptAnOdrStatus;

        /// <summary>PM����`�[�ԍ�</summary>
        /// <remarks>PM�̔���`�[�ԍ�</remarks>
        private Int32 _pMSalesSlipNum;

        /// <summary>PM����s�ԍ�</summary>
        private Int32 _pMSalesRowNo;

        /// <summary>PM�q�ɃR�[�h</summary>
        private string _pmWarehouseCd = "";

        /// <summary>PM�q�ɖ���</summary>
        private string _pmWarehouseName = "";

        /// <summary>PM�I��</summary>
        private string _pmShelfNo = "";

        /// <summary>PM���݌�</summary>
        private Double _pmPrsntCount;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
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

        /// public propaty name  :  SetPartsMkrCd
        /// <summary>�Z�b�g���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPartsMkrCd
        {
            get { return _setPartsMkrCd; }
            set { _setPartsMkrCd = value; }
        }

        /// public propaty name  :  SetPartsNumber
        /// <summary>�Z�b�g���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetPartsNumber
        {
            get { return _setPartsNumber; }
            set { _setPartsNumber = value; }
        }

        /// public propaty name  :  SetPartsMainSubNo
        /// <summary>�Z�b�g���i�e�q�ԍ��v���p�e�B</summary>
        /// <value>0:�e,1-*:�q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���i�e�q�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPartsMainSubNo
        {
            get { return _setPartsMainSubNo; }
            set { _setPartsMainSubNo = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>���i��ʃv���p�e�B</summary>
        /// <value>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����</value>
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

        /// public propaty name  :  DeliGdsCmpltDueDateJpFormal
        /// <summary>�[�i�����\��� �a��v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
        /// <summary>�[�i�����\��� �a��(��)�v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdFormal
        /// <summary>�[�i�����\��� ����v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
        /// <summary>�[�i�����\��� ����(��)�v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  AnswerDeliveryDate
        /// <summary>�񓚔[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDeliveryDate
        {
            get { return _answerDeliveryDate; }
            set { _answerDeliveryDate = value; }
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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>���i���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
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
        public DateTime AnswerLimitDate
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

        /// public propaty name  :  PMAcptAnOdrStatus
        /// <summary>PM�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10�F���� 20:�� 30:���� 40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMAcptAnOdrStatus
        {
            get { return _pMAcptAnOdrStatus; }
            set { _pMAcptAnOdrStatus = value; }
        }

        /// public propaty name  :  PMSalesSlipNum
        /// <summary>PM����`�[�ԍ��v���p�e�B</summary>
        /// <value>PM�̔���`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMSalesSlipNum
        {
            get { return _pMSalesSlipNum; }
            set { _pMSalesSlipNum = value; }
        }

        /// public propaty name  :  PMSalesRowNo
        /// <summary>PM����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMSalesRowNo
        {
            get { return _pMSalesRowNo; }
            set { _pMSalesRowNo = value; }
        }

        /// public propaty name  :  PmWarehouseCd
        /// <summary>PM�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmWarehouseCd
        {
            get { return _pmWarehouseCd; }
            set { _pmWarehouseCd = value; }
        }

        /// public propaty name  :  PmWarehouseName
        /// <summary>PM�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmWarehouseName
        {
            get { return _pmWarehouseName; }
            set { _pmWarehouseName = value; }
        }

        /// public propaty name  :  PmShelfNo
        /// <summary>PM�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmShelfNo
        {
            get { return _pmShelfNo; }
            set { _pmShelfNo = value; }
        }

        /// public propaty name  :  PmPrsntCount
        /// <summary>PM���݌��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���݌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PmPrsntCount
        {
            get { return _pmPrsntCount; }
            set { _pmPrsntCount = value; }
        }


        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>ScmOdSetDt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdSetDt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmOdSetDt()
        {
        }

        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="setPartsMkrCd">�Z�b�g���i���[�J�[�R�[�h</param>
        /// <param name="setPartsNumber">�Z�b�g���i�ԍ�</param>
        /// <param name="setPartsMainSubNo">�Z�b�g���i�e�q�ԍ�(0:�e,1-*:�q)</param>
        /// <param name="goodsDivCd">���i���(0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����)</param>
        /// <param name="recyclePrtKindCode">���T�C�N�����i���(1:���r���h 2:����)</param>
        /// <param name="recyclePrtKindName">���T�C�N�����i��ʖ���</param>
        /// <param name="deliveredGoodsDiv">�[�i�敪(0:�z��,1:����)</param>
        /// <param name="handleDivCode">�戵�敪(0:��舵���i,1:�[���m�F��,2:����舵���i)</param>
        /// <param name="goodsShape">���i�`��(1:���i,2:�p�i)</param>
        /// <param name="delivrdGdsConfCd">�[�i�m�F�敪(0:���m�F,1:�m�F)</param>
        /// <param name="deliGdsCmpltDueDate">�[�i�����\���(�[�i�\����t YYYYMMDD)</param>
        /// <param name="answerDeliveryDate">�񓚔[��</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsDrCode">BL���i�R�[�h�}��</param>
        /// <param name="inqGoodsName">�┭���i��((���p�S�p����))</param>
        /// <param name="ansGoodsName">�񓚏��i��((���p�S�p����))</param>
        /// <param name="salesOrderCount">������</param>
        /// <param name="deliveredGoodsCount">�[�i��</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsMakerNm">���i���[�J�[����</param>
        /// <param name="pureGoodsMakerCd">�������i���[�J�[�R�[�h</param>
        /// <param name="inqPureGoodsNo">�┭�������i�ԍ�((���p�̂�))</param>
        /// <param name="ansPureGoodsNo">�񓚏������i�ԍ�((���p�̂�))</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="unitPrice">�P��</param>
        /// <param name="goodsAddInfo">���i�⑫���</param>
        /// <param name="roughRrofit">�e���z</param>
        /// <param name="roughRate">�e����</param>
        /// <param name="answerLimitDate">�񓚊���(YYYYMMDD)</param>
        /// <param name="commentDtl">���l(����)</param>
        /// <param name="shelfNo">�I��</param>
        /// <param name="pMAcptAnOdrStatus">PM�󒍃X�e�[�^�X(10�F���� 20:�� 30:���� 40:�o��)</param>
        /// <param name="pMSalesSlipNum">PM����`�[�ԍ�(PM�̔���`�[�ԍ�)</param>
        /// <param name="pMSalesRowNo">PM����s�ԍ�</param>
        /// <param name="pmWarehouseCd">PM�q�ɃR�[�h</param>
        /// <param name="pmWarehouseName">PM�q�ɖ���</param>
        /// <param name="pmShelfNo">PM�I��</param>
        /// <param name="pmPrsntCount">PM���݌�</param>
        /// <returns>ScmOdSetDt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdSetDt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmOdSetDt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int32 setPartsMkrCd, string setPartsNumber, Int32 setPartsMainSubNo, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 pMAcptAnOdrStatus, Int32 pMSalesSlipNum, Int32 pMSalesRowNo, string pmWarehouseCd, string pmWarehouseName, string pmShelfNo, Double pmPrsntCount)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inquiryNumber = inquiryNumber;
            this._setPartsMkrCd = setPartsMkrCd;
            this._setPartsNumber = setPartsNumber;
            this._setPartsMainSubNo = setPartsMainSubNo;
            this._goodsDivCd = goodsDivCd;
            this._recyclePrtKindCode = recyclePrtKindCode;
            this._recyclePrtKindName = recyclePrtKindName;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._handleDivCode = handleDivCode;
            this._goodsShape = goodsShape;
            this._delivrdGdsConfCd = delivrdGdsConfCd;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this._answerDeliveryDate = answerDeliveryDate;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsDrCode = bLGoodsDrCode;
            this._inqGoodsName = inqGoodsName;
            this._ansGoodsName = ansGoodsName;
            this._salesOrderCount = salesOrderCount;
            this._deliveredGoodsCount = deliveredGoodsCount;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMakerNm = goodsMakerNm;
            this._pureGoodsMakerCd = pureGoodsMakerCd;
            this._inqPureGoodsNo = inqPureGoodsNo;
            this._ansPureGoodsNo = ansPureGoodsNo;
            this._listPrice = listPrice;
            this._unitPrice = unitPrice;
            this._goodsAddInfo = goodsAddInfo;
            this._roughRrofit = roughRrofit;
            this._roughRate = roughRate;
            this._answerLimitDate = answerLimitDate;
            this._commentDtl = commentDtl;
            this._shelfNo = shelfNo;
            this._pMAcptAnOdrStatus = pMAcptAnOdrStatus;
            this._pMSalesSlipNum = pMSalesSlipNum;
            this._pMSalesRowNo = pMSalesRowNo;
            this._pmWarehouseCd = pmWarehouseCd;
            this._pmWarehouseName = pmWarehouseName;
            this._pmShelfNo = pmShelfNo;
            this._pmPrsntCount = pmPrsntCount;

        }

        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^��������
        /// </summary>
        /// <returns>ScmOdSetDt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdSetDt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmOdSetDt Clone()
        {
            return new ScmOdSetDt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._setPartsMkrCd, this._setPartsNumber, this._setPartsMainSubNo, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._pMAcptAnOdrStatus, this._pMSalesSlipNum, this._pMSalesRowNo, this._pmWarehouseCd, this._pmWarehouseName, this._pmShelfNo, this._pmPrsntCount);
        }

        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmOdSetDt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdSetDt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(ScmOdSetDt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InquiryNumber == target.InquiryNumber)
                 && (this.SetPartsMkrCd == target.SetPartsMkrCd)
                 && (this.SetPartsNumber == target.SetPartsNumber)
                 && (this.SetPartsMainSubNo == target.SetPartsMainSubNo)
                 && (this.GoodsDivCd == target.GoodsDivCd)
                 && (this.RecyclePrtKindCode == target.RecyclePrtKindCode)
                 && (this.RecyclePrtKindName == target.RecyclePrtKindName)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.HandleDivCode == target.HandleDivCode)
                 && (this.GoodsShape == target.GoodsShape)
                 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.AnswerDeliveryDate == target.AnswerDeliveryDate)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode)
                 && (this.InqGoodsName == target.InqGoodsName)
                 && (this.AnsGoodsName == target.AnsGoodsName)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMakerNm == target.GoodsMakerNm)
                 && (this.PureGoodsMakerCd == target.PureGoodsMakerCd)
                 && (this.InqPureGoodsNo == target.InqPureGoodsNo)
                 && (this.AnsPureGoodsNo == target.AnsPureGoodsNo)
                 && (this.ListPrice == target.ListPrice)
                 && (this.UnitPrice == target.UnitPrice)
                 && (this.GoodsAddInfo == target.GoodsAddInfo)
                 && (this.RoughRrofit == target.RoughRrofit)
                 && (this.RoughRate == target.RoughRate)
                 && (this.AnswerLimitDate == target.AnswerLimitDate)
                 && (this.CommentDtl == target.CommentDtl)
                 && (this.ShelfNo == target.ShelfNo)
                 && (this.PMAcptAnOdrStatus == target.PMAcptAnOdrStatus)
                 && (this.PMSalesSlipNum == target.PMSalesSlipNum)
                 && (this.PMSalesRowNo == target.PMSalesRowNo)
                 && (this.PmWarehouseCd == target.PmWarehouseCd)
                 && (this.PmWarehouseName == target.PmWarehouseName)
                 && (this.PmShelfNo == target.PmShelfNo)
                 && (this.PmPrsntCount == target.PmPrsntCount));
        }

        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^��r����
        /// </summary>
        /// <param name="scmOdSetDt1">
        ///                    ��r����ScmOdSetDt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="scmOdSetDt2">��r����ScmOdSetDt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdSetDt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(ScmOdSetDt scmOdSetDt1, ScmOdSetDt scmOdSetDt2)
        {
            return ((scmOdSetDt1.CreateDateTime == scmOdSetDt2.CreateDateTime)
                 && (scmOdSetDt1.UpdateDateTime == scmOdSetDt2.UpdateDateTime)
                 && (scmOdSetDt1.LogicalDeleteCode == scmOdSetDt2.LogicalDeleteCode)
                 && (scmOdSetDt1.InqOriginalEpCd == scmOdSetDt2.InqOriginalEpCd)
                 && (scmOdSetDt1.InqOriginalSecCd == scmOdSetDt2.InqOriginalSecCd)
                 && (scmOdSetDt1.InqOtherEpCd == scmOdSetDt2.InqOtherEpCd)
                 && (scmOdSetDt1.InqOtherSecCd == scmOdSetDt2.InqOtherSecCd)
                 && (scmOdSetDt1.InquiryNumber == scmOdSetDt2.InquiryNumber)
                 && (scmOdSetDt1.SetPartsMkrCd == scmOdSetDt2.SetPartsMkrCd)
                 && (scmOdSetDt1.SetPartsNumber == scmOdSetDt2.SetPartsNumber)
                 && (scmOdSetDt1.SetPartsMainSubNo == scmOdSetDt2.SetPartsMainSubNo)
                 && (scmOdSetDt1.GoodsDivCd == scmOdSetDt2.GoodsDivCd)
                 && (scmOdSetDt1.RecyclePrtKindCode == scmOdSetDt2.RecyclePrtKindCode)
                 && (scmOdSetDt1.RecyclePrtKindName == scmOdSetDt2.RecyclePrtKindName)
                 && (scmOdSetDt1.DeliveredGoodsDiv == scmOdSetDt2.DeliveredGoodsDiv)
                 && (scmOdSetDt1.HandleDivCode == scmOdSetDt2.HandleDivCode)
                 && (scmOdSetDt1.GoodsShape == scmOdSetDt2.GoodsShape)
                 && (scmOdSetDt1.DelivrdGdsConfCd == scmOdSetDt2.DelivrdGdsConfCd)
                 && (scmOdSetDt1.DeliGdsCmpltDueDate == scmOdSetDt2.DeliGdsCmpltDueDate)
                 && (scmOdSetDt1.AnswerDeliveryDate == scmOdSetDt2.AnswerDeliveryDate)
                 && (scmOdSetDt1.BLGoodsCode == scmOdSetDt2.BLGoodsCode)
                 && (scmOdSetDt1.BLGoodsDrCode == scmOdSetDt2.BLGoodsDrCode)
                 && (scmOdSetDt1.InqGoodsName == scmOdSetDt2.InqGoodsName)
                 && (scmOdSetDt1.AnsGoodsName == scmOdSetDt2.AnsGoodsName)
                 && (scmOdSetDt1.SalesOrderCount == scmOdSetDt2.SalesOrderCount)
                 && (scmOdSetDt1.DeliveredGoodsCount == scmOdSetDt2.DeliveredGoodsCount)
                 && (scmOdSetDt1.GoodsNo == scmOdSetDt2.GoodsNo)
                 && (scmOdSetDt1.GoodsMakerCd == scmOdSetDt2.GoodsMakerCd)
                 && (scmOdSetDt1.GoodsMakerNm == scmOdSetDt2.GoodsMakerNm)
                 && (scmOdSetDt1.PureGoodsMakerCd == scmOdSetDt2.PureGoodsMakerCd)
                 && (scmOdSetDt1.InqPureGoodsNo == scmOdSetDt2.InqPureGoodsNo)
                 && (scmOdSetDt1.AnsPureGoodsNo == scmOdSetDt2.AnsPureGoodsNo)
                 && (scmOdSetDt1.ListPrice == scmOdSetDt2.ListPrice)
                 && (scmOdSetDt1.UnitPrice == scmOdSetDt2.UnitPrice)
                 && (scmOdSetDt1.GoodsAddInfo == scmOdSetDt2.GoodsAddInfo)
                 && (scmOdSetDt1.RoughRrofit == scmOdSetDt2.RoughRrofit)
                 && (scmOdSetDt1.RoughRate == scmOdSetDt2.RoughRate)
                 && (scmOdSetDt1.AnswerLimitDate == scmOdSetDt2.AnswerLimitDate)
                 && (scmOdSetDt1.CommentDtl == scmOdSetDt2.CommentDtl)
                 && (scmOdSetDt1.ShelfNo == scmOdSetDt2.ShelfNo)
                 && (scmOdSetDt1.PMAcptAnOdrStatus == scmOdSetDt2.PMAcptAnOdrStatus)
                 && (scmOdSetDt1.PMSalesSlipNum == scmOdSetDt2.PMSalesSlipNum)
                 && (scmOdSetDt1.PMSalesRowNo == scmOdSetDt2.PMSalesRowNo)
                 && (scmOdSetDt1.PmWarehouseCd == scmOdSetDt2.PmWarehouseCd)
                 && (scmOdSetDt1.PmWarehouseName == scmOdSetDt2.PmWarehouseName)
                 && (scmOdSetDt1.PmShelfNo == scmOdSetDt2.PmShelfNo)
                 && (scmOdSetDt1.PmPrsntCount == scmOdSetDt2.PmPrsntCount));
        }
        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmOdSetDt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdSetDt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(ScmOdSetDt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            if (this.SetPartsMkrCd != target.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (this.SetPartsNumber != target.SetPartsNumber) resList.Add("SetPartsNumber");
            if (this.SetPartsMainSubNo != target.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
            if (this.RecyclePrtKindCode != target.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (this.RecyclePrtKindName != target.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.HandleDivCode != target.HandleDivCode) resList.Add("HandleDivCode");
            if (this.GoodsShape != target.GoodsShape) resList.Add("GoodsShape");
            if (this.DelivrdGdsConfCd != target.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.AnswerDeliveryDate != target.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (this.InqGoodsName != target.InqGoodsName) resList.Add("InqGoodsName");
            if (this.AnsGoodsName != target.AnsGoodsName) resList.Add("AnsGoodsName");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.DeliveredGoodsCount != target.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (this.PureGoodsMakerCd != target.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (this.InqPureGoodsNo != target.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (this.AnsPureGoodsNo != target.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.UnitPrice != target.UnitPrice) resList.Add("UnitPrice");
            if (this.GoodsAddInfo != target.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (this.RoughRrofit != target.RoughRrofit) resList.Add("RoughRrofit");
            if (this.RoughRate != target.RoughRate) resList.Add("RoughRate");
            if (this.AnswerLimitDate != target.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (this.CommentDtl != target.CommentDtl) resList.Add("CommentDtl");
            if (this.ShelfNo != target.ShelfNo) resList.Add("ShelfNo");
            if (this.PMAcptAnOdrStatus != target.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (this.PMSalesSlipNum != target.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (this.PMSalesRowNo != target.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (this.PmWarehouseCd != target.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (this.PmWarehouseName != target.PmWarehouseName) resList.Add("PmWarehouseName");
            if (this.PmShelfNo != target.PmShelfNo) resList.Add("PmShelfNo");
            if (this.PmPrsntCount != target.PmPrsntCount) resList.Add("PmPrsntCount");

            return resList;
        }

        /// <summary>
        /// SCM�󔭒��Z�b�g���i�f�[�^��r����
        /// </summary>
        /// <param name="scmOdSetDt1">��r����ScmOdSetDt�N���X�̃C���X�^���X</param>
        /// <param name="scmOdSetDt2">��r����ScmOdSetDt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmOdSetDt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(ScmOdSetDt scmOdSetDt1, ScmOdSetDt scmOdSetDt2)
        {
            ArrayList resList = new ArrayList();
            if (scmOdSetDt1.CreateDateTime != scmOdSetDt2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmOdSetDt1.UpdateDateTime != scmOdSetDt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmOdSetDt1.LogicalDeleteCode != scmOdSetDt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmOdSetDt1.InqOriginalEpCd != scmOdSetDt2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (scmOdSetDt1.InqOriginalSecCd != scmOdSetDt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (scmOdSetDt1.InqOtherEpCd != scmOdSetDt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (scmOdSetDt1.InqOtherSecCd != scmOdSetDt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (scmOdSetDt1.InquiryNumber != scmOdSetDt2.InquiryNumber) resList.Add("InquiryNumber");
            if (scmOdSetDt1.SetPartsMkrCd != scmOdSetDt2.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (scmOdSetDt1.SetPartsNumber != scmOdSetDt2.SetPartsNumber) resList.Add("SetPartsNumber");
            if (scmOdSetDt1.SetPartsMainSubNo != scmOdSetDt2.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (scmOdSetDt1.GoodsDivCd != scmOdSetDt2.GoodsDivCd) resList.Add("GoodsDivCd");
            if (scmOdSetDt1.RecyclePrtKindCode != scmOdSetDt2.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (scmOdSetDt1.RecyclePrtKindName != scmOdSetDt2.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (scmOdSetDt1.DeliveredGoodsDiv != scmOdSetDt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (scmOdSetDt1.HandleDivCode != scmOdSetDt2.HandleDivCode) resList.Add("HandleDivCode");
            if (scmOdSetDt1.GoodsShape != scmOdSetDt2.GoodsShape) resList.Add("GoodsShape");
            if (scmOdSetDt1.DelivrdGdsConfCd != scmOdSetDt2.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (scmOdSetDt1.DeliGdsCmpltDueDate != scmOdSetDt2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (scmOdSetDt1.AnswerDeliveryDate != scmOdSetDt2.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (scmOdSetDt1.BLGoodsCode != scmOdSetDt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (scmOdSetDt1.BLGoodsDrCode != scmOdSetDt2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (scmOdSetDt1.InqGoodsName != scmOdSetDt2.InqGoodsName) resList.Add("InqGoodsName");
            if (scmOdSetDt1.AnsGoodsName != scmOdSetDt2.AnsGoodsName) resList.Add("AnsGoodsName");
            if (scmOdSetDt1.SalesOrderCount != scmOdSetDt2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (scmOdSetDt1.DeliveredGoodsCount != scmOdSetDt2.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (scmOdSetDt1.GoodsNo != scmOdSetDt2.GoodsNo) resList.Add("GoodsNo");
            if (scmOdSetDt1.GoodsMakerCd != scmOdSetDt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (scmOdSetDt1.GoodsMakerNm != scmOdSetDt2.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (scmOdSetDt1.PureGoodsMakerCd != scmOdSetDt2.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (scmOdSetDt1.InqPureGoodsNo != scmOdSetDt2.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (scmOdSetDt1.AnsPureGoodsNo != scmOdSetDt2.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (scmOdSetDt1.ListPrice != scmOdSetDt2.ListPrice) resList.Add("ListPrice");
            if (scmOdSetDt1.UnitPrice != scmOdSetDt2.UnitPrice) resList.Add("UnitPrice");
            if (scmOdSetDt1.GoodsAddInfo != scmOdSetDt2.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (scmOdSetDt1.RoughRrofit != scmOdSetDt2.RoughRrofit) resList.Add("RoughRrofit");
            if (scmOdSetDt1.RoughRate != scmOdSetDt2.RoughRate) resList.Add("RoughRate");
            if (scmOdSetDt1.AnswerLimitDate != scmOdSetDt2.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (scmOdSetDt1.CommentDtl != scmOdSetDt2.CommentDtl) resList.Add("CommentDtl");
            if (scmOdSetDt1.ShelfNo != scmOdSetDt2.ShelfNo) resList.Add("ShelfNo");
            if (scmOdSetDt1.PMAcptAnOdrStatus != scmOdSetDt2.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (scmOdSetDt1.PMSalesSlipNum != scmOdSetDt2.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (scmOdSetDt1.PMSalesRowNo != scmOdSetDt2.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (scmOdSetDt1.PmWarehouseCd != scmOdSetDt2.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (scmOdSetDt1.PmWarehouseName != scmOdSetDt2.PmWarehouseName) resList.Add("PmWarehouseName");
            if (scmOdSetDt1.PmShelfNo != scmOdSetDt2.PmShelfNo) resList.Add("PmShelfNo");
            if (scmOdSetDt1.PmPrsntCount != scmOdSetDt2.PmPrsntCount) resList.Add("PmPrsntCount");

            return resList;
        }
    }
}

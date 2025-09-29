//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�͌��ʃ��[�N
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�͌��ʃ��[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EDISalesResultWork
    /// <summary>
    ///                      ���㗚���f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㗚���f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/11/20</br>
    /// <br>Genarated Date   :   2017/11/20  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EDISalesResultWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>30:����</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>������t</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _salesDate;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>����s�ԍ�</summary>
        /// <remarks>�ꎮ�`�[:�[���A�Z�b�g�i�̎q���i:�e���i�Ɠ����s�ԍ�</remarks>
        private Int32 _salesRowNo;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�Ԏ피�p����</summary>
        /// <remarks>�������́i���p�ŊǗ��j</remarks>
        private string _modelHalfName = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _eDIEnterpriseCode = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _eDIAcptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _eDISalesSlipNum = "";

        /// <summary>����f�[�^�쐬����</summary>
        /// <remarks>����f�[�^�̍쐬�����iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _eDISalesCreateDateTime;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _eDICustomerCode;

        /// <summary>�A�g���Ə��R�[�h</summary>
        private string _cooperatOfficeCode = "";

        /// <summary>�A�g���Ӑ�R�[�h</summary>
        private string _cooperatCustCode = "";

        /// <summary>���i���R�[�h</summary>
        private string _tradCompCd = "";

        /// <summary>���i������</summary>
        private string _tradCompName = "";

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>�l��BL���i�R�[�h</summary>
        private Int32 _increaseBLGoodsCode;

        /// <summary>�l��BL���i�R�[�h</summary>
        private Int32 _discountBLGoodsCode;


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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>30:����</value>
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

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
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

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
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

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// <value>�ꎮ�`�[:�[���A�Z�b�g�i�̎q���i:�e���i�Ɠ����s�ԍ�</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

        /// public propaty name  :  ModelHalfName
        /// <summary>�Ԏ피�p���̃v���p�e�B</summary>
        /// <value>�������́i���p�ŊǗ��j</value>
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

        /// public propaty name  :  EDIEnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EDIEnterpriseCode
        {
            get { return _eDIEnterpriseCode; }
            set { _eDIEnterpriseCode = value; }
        }

        /// public propaty name  :  EDIAcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EDIAcptAnOdrStatus
        {
            get { return _eDIAcptAnOdrStatus; }
            set { _eDIAcptAnOdrStatus = value; }
        }

        /// public propaty name  :  EDISalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EDISalesSlipNum
        {
            get { return _eDISalesSlipNum; }
            set { _eDISalesSlipNum = value; }
        }

        /// public propaty name  :  EDISalesCreateDateTime
        /// <summary>����f�[�^�쐬�����v���p�e�B</summary>
        /// <value>����f�[�^�̍쐬�����iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����f�[�^�쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EDISalesCreateDateTime
        {
            get { return _eDISalesCreateDateTime; }
            set { _eDISalesCreateDateTime = value; }
        }

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

        /// public propaty name  :  EDICustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EDICustomerCode
        {
            get { return _eDICustomerCode; }
            set { _eDICustomerCode = value; }
        }

        /// public propaty name  :  CooperatOfficeCode
        /// <summary>�A�g���Ə��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g���Ə��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CooperatOfficeCode
        {
            get { return _cooperatOfficeCode; }
            set { _cooperatOfficeCode = value; }
        }

        /// public propaty name  :  CooperatCustCode
        /// <summary>�A�g���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CooperatCustCode
        {
            get { return _cooperatCustCode; }
            set { _cooperatCustCode = value; }
        }

        /// public propaty name  :  TradCompCd
        /// <summary>���i���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TradCompCd
        {
            get { return _tradCompCd; }
            set { _tradCompCd = value; }
        }

        /// public propaty name  :  TradCompName
        /// <summary>���i�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TradCompName
        {
            get { return _tradCompName; }
            set { _tradCompName = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  IncreaseBLGoodsCode
        /// <summary>�l��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IncreaseBLGoodsCode
        {
            get { return _increaseBLGoodsCode; }
            set { _increaseBLGoodsCode = value; }
        }

        /// public propaty name  :  DiscountBLGoodsCode
        /// <summary>�l��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DiscountBLGoodsCode
        {
            get { return _discountBLGoodsCode; }
            set { _discountBLGoodsCode = value; }
        }


        /// <summary>
        /// ���㗚���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EDISalesResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDISalesResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EDISalesResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>EDISalesResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EDISalesResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class EDISalesResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDISalesResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EDISalesResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EDISalesResultWork || graph is ArrayList || graph is EDISalesResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(EDISalesResultWork).FullName));

            if (graph != null && graph is EDISalesResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EDISalesResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EDISalesResultWork[])graph).Length;
            }
            else if (graph is EDISalesResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //�`�[���l
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�Ԏ피�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EDIEnterpriseCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //EDIAcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //EDISalesSlipNum
            //����f�[�^�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //EDISalesCreateDateTime
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EDICustomerCode
            //�A�g���Ə��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CooperatOfficeCode
            //�A�g���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CooperatCustCode
            //���i���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TradCompCd
            //���i������
            serInfo.MemberInfo.Add(typeof(string)); //TradCompName
            //���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsCode
            //�l��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //IncreaseBLGoodsCode
            //�l��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //DiscountBLGoodsCode


            serInfo.Serialize(writer, serInfo);
            if (graph is EDISalesResultWork)
            {
                EDISalesResultWork temp = (EDISalesResultWork)graph;

                SetEDISalesResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EDISalesResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EDISalesResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EDISalesResultWork temp in lst)
                {
                    SetEDISalesResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EDISalesResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  EDISalesResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDISalesResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEDISalesResultWork(System.IO.BinaryWriter writer, EDISalesResultWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����`�[�敪
            writer.Write(temp.SalesSlipCd);
            //���ьv�㋒�_�R�[�h
            writer.Write(temp.ResultsAddUpSecCd);
            //������t
            writer.Write(temp.SalesDate);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //�`�[���l
            writer.Write(temp.SlipNote);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�Ԏ피�p����
            writer.Write(temp.ModelHalfName);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //��ƃR�[�h
            writer.Write(temp.EDIEnterpriseCode);
            //�󒍃X�e�[�^�X
            writer.Write(temp.EDIAcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.EDISalesSlipNum);
            //����f�[�^�쐬����
            writer.Write((Int64)temp.EDISalesCreateDateTime.Ticks);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.EDICustomerCode);
            //�A�g���Ə��R�[�h
            writer.Write(temp.CooperatOfficeCode);
            //�A�g���Ӑ�R�[�h
            writer.Write(temp.CooperatCustCode);
            //���i���R�[�h
            writer.Write(temp.TradCompCd);
            //���i������
            writer.Write(temp.TradCompName);
            //���i�R�[�h
            writer.Write(temp.GoodsCode);
            //�l��BL���i�R�[�h
            writer.Write(temp.IncreaseBLGoodsCode);
            //�l��BL���i�R�[�h
            writer.Write(temp.DiscountBLGoodsCode);

        }

        /// <summary>
        ///  EDISalesResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EDISalesResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDISalesResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private EDISalesResultWork GetEDISalesResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EDISalesResultWork temp = new EDISalesResultWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����`�[�敪
            temp.SalesSlipCd = reader.ReadInt32();
            //���ьv�㋒�_�R�[�h
            temp.ResultsAddUpSecCd = reader.ReadString();
            //������t
            temp.SalesDate = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //�`�[���l
            temp.SlipNote = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�Ԏ피�p����
            temp.ModelHalfName = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //��ƃR�[�h
            temp.EDIEnterpriseCode = reader.ReadString();
            //�󒍃X�e�[�^�X
            temp.EDIAcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.EDISalesSlipNum = reader.ReadString();
            //����f�[�^�쐬����
            temp.EDISalesCreateDateTime = new DateTime(reader.ReadInt64());
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.EDICustomerCode = reader.ReadInt32();
            //�A�g���Ə��R�[�h
            temp.CooperatOfficeCode = reader.ReadString();
            //�A�g���Ӑ�R�[�h
            temp.CooperatCustCode = reader.ReadString();
            //���i���R�[�h
            temp.TradCompCd = reader.ReadString();
            //���i������
            temp.TradCompName = reader.ReadString();
            //���i�R�[�h
            temp.GoodsCode = reader.ReadString();
            //�l��BL���i�R�[�h
            temp.IncreaseBLGoodsCode = reader.ReadInt32();
            //�l��BL���i�R�[�h
            temp.DiscountBLGoodsCode = reader.ReadInt32();


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
        /// <returns>EDISalesResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDISalesResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EDISalesResultWork temp = GetEDISalesResultWork(reader, serInfo);
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
                    retValue = (EDISalesResultWork[])lst.ToArray(typeof(EDISalesResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

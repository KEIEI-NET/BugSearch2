//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o��
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesHistoryJoinWork
    /// <summary>
    ///                      ���㗚���f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㗚���f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/08/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���X�y���~�X�C��</br>
    /// <br>                 :   ����l����ېőΏۊz���v</br>
    /// <br>                 :   ���㐳�����z</br>
    /// <br>                 :   ������z����Ŋz�i�O�Łj</br>
    /// <br>Update Note      :   2008/7/29  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���Ӑ�`�[�ԍ�</br>
    /// <br>Update Note      :   2013/02/25 zhuhh</br>
    /// <br>                 :   �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesHistoryJoinWork : IFileHeader
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

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _searchSlipDate;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

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

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>BL���i�R�[�h�i����j</summary>
        private Int32 _prtBLGoodsCode;

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
        /// <summary>�艿�i�Ŕ��C�����j</summary>
        private Double _listPriceTaxExc;
        // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<
        
        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���i�R�[�h�ϊ�AB���i�R�[�h</summary>
        private string _aBGoodsCode = "";

        /// <summary>�[�i��X�܃R�[�h</summary>
        private string _addresseeShopCd = "";

        /// <summary>�Z�d�Ǘ��R�[�h</summary>
        private string _sAndEMngCode = "";

        /// <summary>�o��敪</summary>
        private Int32 _expenseDivCd;

        /// <summary>���i���R�[�h�i�����j</summary>
        private string _pureTradCompCd = "";

        /// <summary>���i���d�ؗ��i�����j</summary>
        private Double _pureTradCompRate;

        /// <summary>���i���R�[�h�i�D�ǁj</summary>
        private string _priTradCompCd = "";

        /// <summary>���i���d�ؗ��i�D�ǁj</summary>
        private Double _priTradCompRate;

        /// <summary>�ݒ�AB���i�R�[�h</summary>
        private string _setABGoodsCode = "";

        /// <summary>���i���[�J�[�R�[�h�P</summary>
        private Int32 _goodsMakerCd1;

        /// <summary>���i���[�J�[�R�[�h�Q</summary>
        private Int32 _goodsMakerCd2;

        /// <summary>���i���[�J�[�R�[�h�R</summary>
        private Int32 _goodsMakerCd3;

        /// <summary>���i���[�J�[�R�[�h�S</summary>
        private Int32 _goodsMakerCd4;

        /// <summary>���i���[�J�[�R�[�h�T</summary>
        private Int32 _goodsMakerCd5;

        /// <summary>���i���[�J�[�R�[�h�U</summary>
        private Int32 _goodsMakerCd6;

        /// <summary>���i���[�J�[�R�[�h�V</summary>
        private Int32 _goodsMakerCd7;

        /// <summary>���i���[�J�[�R�[�h�W</summary>
        private Int32 _goodsMakerCd8;

        /// <summary>���i���[�J�[�R�[�h�X</summary>
        private Int32 _goodsMakerCd9;

        /// <summary>���i���[�J�[�R�[�h�P�O</summary>
        private Int32 _goodsMakerCd10;

        /// <summary>���i���[�J�[�R�[�h�P�P</summary>
        private Int32 _goodsMakerCd11;

        /// <summary>���i���[�J�[�R�[�h�P�Q</summary>
        private Int32 _goodsMakerCd12;

        /// <summary>���i���[�J�[�R�[�h�P�R</summary>
        private Int32 _goodsMakerCd13;

        /// <summary>���i���[�J�[�R�[�h�P�S</summary>
        private Int32 _goodsMakerCd14;

        /// <summary>���i���[�J�[�R�[�h�P�T</summary>
        private Int32 _goodsMakerCd15;

        /// <summary>SE��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _sEEnterpriseCode = "";

        /// <summary>SE�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _sEAcptAnOdrStatus;

        /// <summary>SE����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _sESalesSlipNum = "";

        /// <summary>SE����f�[�^�쐬����</summary>
        /// <remarks>����f�[�^�̍쐬�����iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _sESalesCreateDateTime;


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

        /// public propaty name  :  PrtBLGoodsCode
        /// <summary>BL���i�R�[�h�i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtBLGoodsCode
        {
            get { return _prtBLGoodsCode; }
            set { _prtBLGoodsCode = value; }
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

        // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExc; }
            set { _listPriceTaxExc = value; }
        }
        // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<

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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  ABGoodsCode
        /// <summary>���i�R�[�h�ϊ�AB���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�[�h�ϊ�AB���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ABGoodsCode
        {
            get { return _aBGoodsCode; }
            set { _aBGoodsCode = value; }
        }

        /// public propaty name  :  AddresseeShopCd
        /// <summary>�[�i��X�܃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�܃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeShopCd
        {
            get { return _addresseeShopCd; }
            set { _addresseeShopCd = value; }
        }

        /// public propaty name  :  SAndEMngCode
        /// <summary>�Z�d�Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�d�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SAndEMngCode
        {
            get { return _sAndEMngCode; }
            set { _sAndEMngCode = value; }
        }

        /// public propaty name  :  ExpenseDivCd
        /// <summary>�o��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExpenseDivCd
        {
            get { return _expenseDivCd; }
            set { _expenseDivCd = value; }
        }

        /// public propaty name  :  PureTradCompCd
        /// <summary>���i���R�[�h�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PureTradCompCd
        {
            get { return _pureTradCompCd; }
            set { _pureTradCompCd = value; }
        }

        /// public propaty name  :  PureTradCompRate
        /// <summary>���i���d�ؗ��i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���d�ؗ��i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PureTradCompRate
        {
            get { return _pureTradCompRate; }
            set { _pureTradCompRate = value; }
        }

        /// public propaty name  :  PriTradCompCd
        /// <summary>���i���R�[�h�i�D�ǁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�i�D�ǁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriTradCompCd
        {
            get { return _priTradCompCd; }
            set { _priTradCompCd = value; }
        }

        /// public propaty name  :  PriTradCompRate
        /// <summary>���i���d�ؗ��i�D�ǁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���d�ؗ��i�D�ǁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriTradCompRate
        {
            get { return _priTradCompRate; }
            set { _priTradCompRate = value; }
        }

        /// public propaty name  :  SetABGoodsCode
        /// <summary>�ݒ�AB���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݒ�AB���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetABGoodsCode
        {
            get { return _setABGoodsCode; }
            set { _setABGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd1
        /// <summary>���i���[�J�[�R�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd1
        {
            get { return _goodsMakerCd1; }
            set { _goodsMakerCd1 = value; }
        }

        /// public propaty name  :  GoodsMakerCd2
        /// <summary>���i���[�J�[�R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd2
        {
            get { return _goodsMakerCd2; }
            set { _goodsMakerCd2 = value; }
        }

        /// public propaty name  :  GoodsMakerCd3
        /// <summary>���i���[�J�[�R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd3
        {
            get { return _goodsMakerCd3; }
            set { _goodsMakerCd3 = value; }
        }

        /// public propaty name  :  GoodsMakerCd4
        /// <summary>���i���[�J�[�R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd4
        {
            get { return _goodsMakerCd4; }
            set { _goodsMakerCd4 = value; }
        }

        /// public propaty name  :  GoodsMakerCd5
        /// <summary>���i���[�J�[�R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd5
        {
            get { return _goodsMakerCd5; }
            set { _goodsMakerCd5 = value; }
        }

        /// public propaty name  :  GoodsMakerCd6
        /// <summary>���i���[�J�[�R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd6
        {
            get { return _goodsMakerCd6; }
            set { _goodsMakerCd6 = value; }
        }

        /// public propaty name  :  GoodsMakerCd7
        /// <summary>���i���[�J�[�R�[�h�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd7
        {
            get { return _goodsMakerCd7; }
            set { _goodsMakerCd7 = value; }
        }

        /// public propaty name  :  GoodsMakerCd8
        /// <summary>���i���[�J�[�R�[�h�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd8
        {
            get { return _goodsMakerCd8; }
            set { _goodsMakerCd8 = value; }
        }

        /// public propaty name  :  GoodsMakerCd9
        /// <summary>���i���[�J�[�R�[�h�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd9
        {
            get { return _goodsMakerCd9; }
            set { _goodsMakerCd9 = value; }
        }

        /// public propaty name  :  GoodsMakerCd10
        /// <summary>���i���[�J�[�R�[�h�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd10
        {
            get { return _goodsMakerCd10; }
            set { _goodsMakerCd10 = value; }
        }

        /// public propaty name  :  GoodsMakerCd11
        /// <summary>���i���[�J�[�R�[�h�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd11
        {
            get { return _goodsMakerCd11; }
            set { _goodsMakerCd11 = value; }
        }

        /// public propaty name  :  GoodsMakerCd12
        /// <summary>���i���[�J�[�R�[�h�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd12
        {
            get { return _goodsMakerCd12; }
            set { _goodsMakerCd12 = value; }
        }

        /// public propaty name  :  GoodsMakerCd13
        /// <summary>���i���[�J�[�R�[�h�P�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd13
        {
            get { return _goodsMakerCd13; }
            set { _goodsMakerCd13 = value; }
        }

        /// public propaty name  :  GoodsMakerCd14
        /// <summary>���i���[�J�[�R�[�h�P�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd14
        {
            get { return _goodsMakerCd14; }
            set { _goodsMakerCd14 = value; }
        }

        /// public propaty name  :  GoodsMakerCd15
        /// <summary>���i���[�J�[�R�[�h�P�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd15
        {
            get { return _goodsMakerCd15; }
            set { _goodsMakerCd15 = value; }
        }

        /// public propaty name  :  SEEnterpriseCode
        /// <summary>SE��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SEEnterpriseCode
        {
            get { return _sEEnterpriseCode; }
            set { _sEEnterpriseCode = value; }
        }

        /// public propaty name  :  SEAcptAnOdrStatus
        /// <summary>SE�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE�󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SEAcptAnOdrStatus
        {
            get { return _sEAcptAnOdrStatus; }
            set { _sEAcptAnOdrStatus = value; }
        }

        /// public propaty name  :  SESalesSlipNum
        /// <summary>SE����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SESalesSlipNum
        {
            get { return _sESalesSlipNum; }
            set { _sESalesSlipNum = value; }
        }

        /// public propaty name  :  SESalesCreateDateTime
        /// <summary>SE����f�[�^�쐬�����v���p�e�B</summary>
        /// <value>����f�[�^�̍쐬�����iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SE����f�[�^�쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SESalesCreateDateTime
        {
            get { return _sESalesCreateDateTime; }
            set { _sESalesCreateDateTime = value; }
        }


        /// <summary>
        /// ���㗚���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesHistoryJoinWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryJoinWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesHistoryJoinWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesHistoryJoinWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesHistoryJoinWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesHistoryJoinWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryJoinWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/02/25 zhuhh</br>
        /// <br>                 :   �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesHistoryJoinWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesHistoryJoinWork || graph is ArrayList || graph is SalesHistoryJoinWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesHistoryJoinWork).FullName));

            if (graph != null && graph is SalesHistoryJoinWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesHistoryJoinWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesHistoryJoinWork[])graph).Length;
            }
            else if (graph is SalesHistoryJoinWork)
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
            //�`�[�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
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
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //BL���i�R�[�h�i����j
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCode
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //���i�R�[�h�ϊ�AB���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ABGoodsCode
            //�[�i��X�܃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeShopCd
            //�Z�d�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndEMngCode
            //�o��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpenseDivCd
            //���i���R�[�h�i�����j
            serInfo.MemberInfo.Add(typeof(string)); //PureTradCompCd
            //���i���d�ؗ��i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //PureTradCompRate
            //���i���R�[�h�i�D�ǁj
            serInfo.MemberInfo.Add(typeof(string)); //PriTradCompCd
            //���i���d�ؗ��i�D�ǁj
            serInfo.MemberInfo.Add(typeof(Double)); //PriTradCompRate
            //�ݒ�AB���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SetABGoodsCode
            //���i���[�J�[�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd1
            //���i���[�J�[�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd2
            //���i���[�J�[�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd3
            //���i���[�J�[�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd4
            //���i���[�J�[�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd5
            //���i���[�J�[�R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd6
            //���i���[�J�[�R�[�h�V
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd7
            //���i���[�J�[�R�[�h�W
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd8
            //���i���[�J�[�R�[�h�X
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd9
            //���i���[�J�[�R�[�h�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd10
            //���i���[�J�[�R�[�h�P�P
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd11
            //���i���[�J�[�R�[�h�P�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd12
            //���i���[�J�[�R�[�h�P�R
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd13
            //���i���[�J�[�R�[�h�P�S
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd14
            //���i���[�J�[�R�[�h�P�T
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd15
            //SE��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SEEnterpriseCode
            //SE�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //SEAcptAnOdrStatus
            //SE����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SESalesSlipNum
            //SE����f�[�^�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //SESalesCreateDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesHistoryJoinWork)
            {
                SalesHistoryJoinWork temp = (SalesHistoryJoinWork)graph;

                SetSalesHistoryJoinWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesHistoryJoinWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesHistoryJoinWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesHistoryJoinWork temp in lst)
                {
                    SetSalesHistoryJoinWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesHistoryJoinWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 55;// DEL zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
        private const int currentMemberCount = 56;// ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX

        /// <summary>
        ///  SalesHistoryJoinWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryJoinWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/02/25 zhuhh</br>
        /// <br>                 :   �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
        /// </remarks>
        private void SetSalesHistoryJoinWork(System.IO.BinaryWriter writer, SalesHistoryJoinWork temp)
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
            //�`�[�������t
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
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
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //BL���i�R�[�h�i����j
            writer.Write(temp.PrtBLGoodsCode);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //���i�R�[�h�ϊ�AB���i�R�[�h
            writer.Write(temp.ABGoodsCode);
            //�[�i��X�܃R�[�h
            writer.Write(temp.AddresseeShopCd);
            //�Z�d�Ǘ��R�[�h
            writer.Write(temp.SAndEMngCode);
            //�o��敪
            writer.Write(temp.ExpenseDivCd);
            //���i���R�[�h�i�����j
            writer.Write(temp.PureTradCompCd);
            //���i���d�ؗ��i�����j
            writer.Write(temp.PureTradCompRate);
            //���i���R�[�h�i�D�ǁj
            writer.Write(temp.PriTradCompCd);
            //���i���d�ؗ��i�D�ǁj
            writer.Write(temp.PriTradCompRate);
            //�ݒ�AB���i�R�[�h
            writer.Write(temp.SetABGoodsCode);
            //���i���[�J�[�R�[�h�P
            writer.Write(temp.GoodsMakerCd1);
            //���i���[�J�[�R�[�h�Q
            writer.Write(temp.GoodsMakerCd2);
            //���i���[�J�[�R�[�h�R
            writer.Write(temp.GoodsMakerCd3);
            //���i���[�J�[�R�[�h�S
            writer.Write(temp.GoodsMakerCd4);
            //���i���[�J�[�R�[�h�T
            writer.Write(temp.GoodsMakerCd5);
            //���i���[�J�[�R�[�h�U
            writer.Write(temp.GoodsMakerCd6);
            //���i���[�J�[�R�[�h�V
            writer.Write(temp.GoodsMakerCd7);
            //���i���[�J�[�R�[�h�W
            writer.Write(temp.GoodsMakerCd8);
            //���i���[�J�[�R�[�h�X
            writer.Write(temp.GoodsMakerCd9);
            //���i���[�J�[�R�[�h�P�O
            writer.Write(temp.GoodsMakerCd10);
            //���i���[�J�[�R�[�h�P�P
            writer.Write(temp.GoodsMakerCd11);
            //���i���[�J�[�R�[�h�P�Q
            writer.Write(temp.GoodsMakerCd12);
            //���i���[�J�[�R�[�h�P�R
            writer.Write(temp.GoodsMakerCd13);
            //���i���[�J�[�R�[�h�P�S
            writer.Write(temp.GoodsMakerCd14);
            //���i���[�J�[�R�[�h�P�T
            writer.Write(temp.GoodsMakerCd15);
            //SE��ƃR�[�h
            writer.Write(temp.SEEnterpriseCode);
            //SE�󒍃X�e�[�^�X
            writer.Write(temp.SEAcptAnOdrStatus);
            //SE����`�[�ԍ�
            writer.Write(temp.SESalesSlipNum);
            //SE����f�[�^�쐬����
            writer.Write(temp.SESalesCreateDateTime);

        }

        /// <summary>
        ///  SalesHistoryJoinWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesHistoryJoinWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryJoinWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   2013/02/25 zhuhh</br>
        /// <br>                 :   �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
        /// </remarks>
        private SalesHistoryJoinWork GetSalesHistoryJoinWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesHistoryJoinWork temp = new SalesHistoryJoinWork();

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
            //�`�[�������t
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
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
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //BL���i�R�[�h�i����j
            temp.PrtBLGoodsCode = reader.ReadInt32();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //���i�R�[�h�ϊ�AB���i�R�[�h
            temp.ABGoodsCode = reader.ReadString();
            //�[�i��X�܃R�[�h
            temp.AddresseeShopCd = reader.ReadString();
            //�Z�d�Ǘ��R�[�h
            temp.SAndEMngCode = reader.ReadString();
            //�o��敪
            temp.ExpenseDivCd = reader.ReadInt32();
            //���i���R�[�h�i�����j
            temp.PureTradCompCd = reader.ReadString();
            //���i���d�ؗ��i�����j
            temp.PureTradCompRate = reader.ReadDouble();
            //���i���R�[�h�i�D�ǁj
            temp.PriTradCompCd = reader.ReadString();
            //���i���d�ؗ��i�D�ǁj
            temp.PriTradCompRate = reader.ReadDouble();
            //�ݒ�AB���i�R�[�h
            temp.SetABGoodsCode = reader.ReadString();
            //���i���[�J�[�R�[�h�P
            temp.GoodsMakerCd1 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�Q
            temp.GoodsMakerCd2 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�R
            temp.GoodsMakerCd3 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�S
            temp.GoodsMakerCd4 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�T
            temp.GoodsMakerCd5 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�U
            temp.GoodsMakerCd6 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�V
            temp.GoodsMakerCd7 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�W
            temp.GoodsMakerCd8 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�X
            temp.GoodsMakerCd9 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�O
            temp.GoodsMakerCd10 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�P
            temp.GoodsMakerCd11 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�Q
            temp.GoodsMakerCd12 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�R
            temp.GoodsMakerCd13 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�S
            temp.GoodsMakerCd14 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�T
            temp.GoodsMakerCd15 = reader.ReadInt32();
            //SE��ƃR�[�h
            temp.SEEnterpriseCode = reader.ReadString();
            //SE�󒍃X�e�[�^�X
            temp.SEAcptAnOdrStatus = reader.ReadInt32();
            //SE����`�[�ԍ�
            temp.SESalesSlipNum = reader.ReadString();
            //SE����f�[�^�쐬����
            temp.SESalesCreateDateTime = reader.ReadInt64();


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
        /// <returns>SalesHistoryJoinWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryJoinWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesHistoryJoinWork temp = GetSalesHistoryJoinWork(reader, serInfo);
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
                    retValue = (SalesHistoryJoinWork[])lst.ToArray(typeof(SalesHistoryJoinWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

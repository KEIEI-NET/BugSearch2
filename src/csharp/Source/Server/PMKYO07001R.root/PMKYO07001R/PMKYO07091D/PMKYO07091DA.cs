//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���o�E�X�VDB����N���X
//                  :   PMKYO07091D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   杍^
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockSlipHistWork
    /// <summary>
    ///                      �d�������f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�������f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/04/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APStockSlipHistWork : IFileHeader
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

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d���@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�ԍ��A���d���`�[�ԍ�</summary>
        private Int32 _debitNLnkSuppSlipNo;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>10:�d��,20:�ԕi</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accPayDivCd;

        /// <summary>�d�����_�R�[�h</summary>
        private string _stockSectionCd = "";

        /// <summary>�d���v�㋒�_�R�[�h</summary>
        /// <remarks>�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���)</remarks>
        private string _stockAddUpSectionCd = "";

        /// <summary>�d���`�[�X�V�敪</summary>
        /// <remarks>0:���X�V,1:�X�V����</remarks>
        private Int32 _stockSlipUpdateCd;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>���ד�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>�d����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>�d���v����t</summary>
        /// <remarks>�d���v���</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>�����敪</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>�d�����͎҃R�[�h</summary>
        private string _stockInputCode = "";

        /// <summary>�d�����͎Җ���</summary>
        private string _stockInputName = "";

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>���z�\���|���K�p�敪</summary>
        /// <remarks>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</remarks>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>�d�����z���v</summary>
        /// <remarks>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�d�����z���v</summary>
        /// <remarks>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
        private Int64 _stockSubttlPrice;

        /// <summary>�d�����z�v�i�ō��݁j</summary>
        /// <remarks>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</remarks>
        private Int64 _stockTtlPricTaxInc;

        /// <summary>�d�����z�v�i�Ŕ����j</summary>
        /// <remarks>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>�d���������z</summary>
        /// <remarks>�l���O�̐Ŕ��d�����z</remarks>
        private Int64 _stockNetPrice;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>�d���O�őΏۊz���v</summary>
        /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
        private Int64 _ttlItdedStcOutTax;

        /// <summary>�d�����őΏۊz���v</summary>
        /// <remarks>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </remarks>
        private Int64 _ttlItdedStcInTax;

        /// <summary>�d����ېőΏۊz���v</summary>
        /// <remarks>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</remarks>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>�d�����z����Ŋz�i�O�Łj</summary>
        /// <remarks>�l���O�̊O�ŏ��i�̏����</remarks>
        private Int64 _stockOutTax;

        /// <summary>�d�����z����Ŋz�i���Łj</summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>�d���l�����z�v�i�Ŕ����j</summary>
        /// <remarks>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</remarks>
        private Int64 _stckDisTtlTaxExc;

        /// <summary>�d���l���O�őΏۊz���v</summary>
        /// <remarks>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedStockDisOutTax;

        /// <summary>�d���l�����őΏۊz���v</summary>
        /// <remarks>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedStockDisInTax;

        /// <summary>�d���l����ېőΏۊz���v</summary>
        /// <remarks>��ېŏ��i�l���̔�ېőΏۊz</remarks>
        private Int64 _itdedStockDisTaxFre;

        /// <summary>�d���l������Ŋz�i�O�Łj</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _stockDisOutTax;

        /// <summary>�d���l������Ŋz�i���Łj</summary>
        /// <remarks>���ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _stckDisTtlTaxInclu;

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d�������Őŗ�</summary>
        private Double _supplierConsTaxRate;

        /// <summary>���|�����</summary>
        private Int64 _accPayConsTax;

        /// <summary>�d���[�������敪</summary>
        /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
        private Int32 _stockFractionProcCd;

        /// <summary>�����x���敪</summary>
        /// <remarks>0:�ʏ�x��,1:�����x��</remarks>
        private Int32 _autoPayment;

        /// <summary>�����x���`�[�ԍ�</summary>
        /// <remarks>�����x�����̎x���`�[�ԍ�</remarks>
        private Int32 _autoPaySlipNum;

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>�ԕi���R</summary>
        private string _retGoodsReason = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�d���`�[���l1</summary>
        private string _supplierSlipNote1 = "";

        /// <summary>�d���`�[���l2</summary>
        private string _supplierSlipNote2 = "";

        /// <summary>���׍s��</summary>
        /// <remarks>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</remarks>
        private Int32 _detailRowCount;

        /// <summary>�d�c�h���M��</summary>
        /// <remarks>YYYYMMDD �iErectricDataInterface�j</remarks>
        private DateTime _ediSendDate;

        /// <summary>�d�c�h�捞��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ediTakeInDate;

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>�`�[���s�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _slipPrintDivCd;

        /// <summary>�`�[���s�ϋ敪</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>�d���`�[���s��</summary>
        /// <remarks>���ׂł͓��ד`�[���s��</remarks>
        private DateTime _stockSlipPrintDate;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�d���`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q�Ɓ@�i���חp�j</remarks>
        private string _slipPrtSetPaperId = "";


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

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d���@�i�󒍃X�e�[�^�X�j</value>
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
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

        /// public propaty name  :  DebitNLnkSuppSlipNo
        /// <summary>�ԍ��A���d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��A���d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNLnkSuppSlipNo
        {
            get { return _debitNLnkSuppSlipNo; }
            set { _debitNLnkSuppSlipNo = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,20:�ԕi</value>
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

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  AccPayDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>�d�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>�d���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  StockSlipUpdateCd
        /// <summary>�d���`�[�X�V�敪�v���p�e�B</summary>
        /// <value>0:���X�V,1:�X�V����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipUpdateCd
        {
            get { return _stockSlipUpdateCd; }
            set { _stockSlipUpdateCd = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockAddUpADate
        /// <summary>�d���v����t�v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
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

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
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

        /// public propaty name  :  StockInputCode
        /// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  StockInputName
        /// <summary>�d�����͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDispRateApy
        /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
        /// <value>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlAmntDispRateApy
        {
            get { return _ttlAmntDispRateApy; }
            set { _ttlAmntDispRateApy = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>�d�����z���v�v���p�e�B</summary>
        /// <value>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockSubttlPrice
        /// <summary>�d�����z���v�v���p�e�B</summary>
        /// <value>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSubttlPrice
        {
            get { return _stockSubttlPrice; }
            set { _stockSubttlPrice = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>�d�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  StockNetPrice
        /// <summary>�d���������z�v���p�e�B</summary>
        /// <value>�l���O�̐Ŕ��d�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockNetPrice
        {
            get { return _stockNetPrice; }
            set { _stockNetPrice = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  TtlItdedStcOutTax
        /// <summary>�d���O�őΏۊz���v�v���p�e�B</summary>
        /// <value>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTax
        {
            get { return _ttlItdedStcOutTax; }
            set { _ttlItdedStcOutTax = value; }
        }

        /// public propaty name  :  TtlItdedStcInTax
        /// <summary>�d�����őΏۊz���v�v���p�e�B</summary>
        /// <value>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcInTax
        {
            get { return _ttlItdedStcInTax; }
            set { _ttlItdedStcInTax = value; }
        }

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>�d����ېőΏۊz���v�v���p�e�B</summary>
        /// <value>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcTaxFree
        {
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
        }

        /// public propaty name  :  StockOutTax
        /// <summary>�d�����z����Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�l���O�̊O�ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockOutTax
        {
            get { return _stockOutTax; }
            set { _stockOutTax = value; }
        }

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>�d�����z����Ŋz�i���Łj�v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckPrcConsTaxInclu
        {
            get { return _stckPrcConsTaxInclu; }
            set { _stckPrcConsTaxInclu = value; }
        }

        /// public propaty name  :  StckDisTtlTaxExc
        /// <summary>�d���l�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxExc
        {
            get { return _stckDisTtlTaxExc; }
            set { _stckDisTtlTaxExc = value; }
        }

        /// public propaty name  :  ItdedStockDisOutTax
        /// <summary>�d���l���O�őΏۊz���v�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedStockDisOutTax
        {
            get { return _itdedStockDisOutTax; }
            set { _itdedStockDisOutTax = value; }
        }

        /// public propaty name  :  ItdedStockDisInTax
        /// <summary>�d���l�����őΏۊz���v�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedStockDisInTax
        {
            get { return _itdedStockDisInTax; }
            set { _itdedStockDisInTax = value; }
        }

        /// public propaty name  :  ItdedStockDisTaxFre
        /// <summary>�d���l����ېőΏۊz���v�v���p�e�B</summary>
        /// <value>��ېŏ��i�l���̔�ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedStockDisTaxFre
        {
            get { return _itdedStockDisTaxFre; }
            set { _itdedStockDisTaxFre = value; }
        }

        /// public propaty name  :  StockDisOutTax
        /// <summary>�d���l������Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l������Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockDisOutTax
        {
            get { return _stockDisOutTax; }
            set { _stockDisOutTax = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>�d���l������Ŋz�i���Łj�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l������Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>�d�������Őŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }

        /// public propaty name  :  AccPayConsTax
        /// <summary>���|����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AccPayConsTax
        {
            get { return _accPayConsTax; }
            set { _accPayConsTax = value; }
        }

        /// public propaty name  :  StockFractionProcCd
        /// <summary>�d���[�������敪�v���p�e�B</summary>
        /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockFractionProcCd
        {
            get { return _stockFractionProcCd; }
            set { _stockFractionProcCd = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>�����x���敪�v���p�e�B</summary>
        /// <value>0:�ʏ�x��,1:�����x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  AutoPaySlipNum
        /// <summary>�����x���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����x�����̎x���`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPaySlipNum
        {
            get { return _autoPaySlipNum; }
            set { _autoPaySlipNum = value; }
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

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
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

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>�d���`�[���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>�d���`�[���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  DetailRowCount
        /// <summary>���׍s���v���p�e�B</summary>
        /// <value>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׍s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailRowCount
        {
            get { return _detailRowCount; }
            set { _detailRowCount = value; }
        }

        /// public propaty name  :  EdiSendDate
        /// <summary>�d�c�h���M���v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdiSendDate
        {
            get { return _ediSendDate; }
            set { _ediSendDate = value; }
        }

        /// public propaty name  :  EdiTakeInDate
        /// <summary>�d�c�h�捞���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
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

        /// public propaty name  :  SlipPrintDivCd
        /// <summary>�`�[���s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrintDivCd
        {
            get { return _slipPrintDivCd; }
            set { _slipPrintDivCd = value; }
        }

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  StockSlipPrintDate
        /// <summary>�d���`�[���s���v���p�e�B</summary>
        /// <value>���ׂł͓��ד`�[���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockSlipPrintDate
        {
            get { return _stockSlipPrintDate; }
            set { _stockSlipPrintDate = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�d���`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q�Ɓ@�i���חp�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }


        /// <summary>
        /// �d�������f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockSlipHistWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipHistWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APStockSlipHistWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockSlipHistWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockSlipHistWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class APStockSlipHistWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipHistWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockSlipHistWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APStockSlipHistWork || graph is ArrayList || graph is APStockSlipHistWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(APStockSlipHistWork).FullName));

            if (graph != null && graph is APStockSlipHistWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSlipHistWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APStockSlipHistWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APStockSlipHistWork[])graph).Length;
            }
            else if (graph is APStockSlipHistWork)
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
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�ԍ��A���d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkSuppSlipNo
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //�d���v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //�d���`�[�X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipUpdateCd
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DelayPaymentDiv
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //�d�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //�d�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //���z�\���|���K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDispRateApy
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //�d�����z�v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //�d�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�d���������z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockNetPrice
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�d���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcOutTax
            //�d�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcInTax
            //�d����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcTaxFree
            //�d�����z����Ŋz�i�O�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StockOutTax
            //�d�����z����Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
            //�d���l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc
            //�d���l���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedStockDisOutTax
            //�d���l�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedStockDisInTax
            //�d���l����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedStockDisTaxFre
            //�d���l������Ŋz�i�O�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDisOutTax
            //�d���l������Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d�������Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //���|�����
            serInfo.MemberInfo.Add(typeof(Int64)); //AccPayConsTax
            //�d���[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockFractionProcCd
            //�����x���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //�����x���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPaySlipNum
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //�ԕi���R
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d���`�[���l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //�d���`�[���l2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //���׍s��
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailRowCount
            //�d�c�h���M��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiSendDate
            //�d�c�h�捞��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiTakeInDate
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintDivCd
            //�`�[���s�ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintFinishCd
            //�d���`�[���s��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipPrintDate
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId


            serInfo.Serialize(writer, serInfo);
            if (graph is APStockSlipHistWork)
            {
                APStockSlipHistWork temp = (APStockSlipHistWork)graph;

                SetStockSlipHistWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APStockSlipHistWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APStockSlipHistWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APStockSlipHistWork temp in lst)
                {
                    SetStockSlipHistWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockSlipHistWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 80;

        /// <summary>
        ///  StockSlipHistWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipHistWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockSlipHistWork(System.IO.BinaryWriter writer, APStockSlipHistWork temp)
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
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�ԍ��A���d���`�[�ԍ�
            writer.Write(temp.DebitNLnkSuppSlipNo);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //���|�敪
            writer.Write(temp.AccPayDivCd);
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);
            //�d���v�㋒�_�R�[�h
            writer.Write(temp.StockAddUpSectionCd);
            //�d���`�[�X�V�敪
            writer.Write(temp.StockSlipUpdateCd);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //���ד�
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���v����t
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //�����敪
            writer.Write(temp.DelayPaymentDiv);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��
            writer.Write(temp.BusinessTypeName);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //�d�����͎҃R�[�h
            writer.Write(temp.StockInputCode);
            //�d�����͎Җ���
            writer.Write(temp.StockInputName);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //���z�\���|���K�p�敪
            writer.Write(temp.TtlAmntDispRateApy);
            //�d�����z���v
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v
            writer.Write(temp.StockSubttlPrice);
            //�d�����z�v�i�ō��݁j
            writer.Write(temp.StockTtlPricTaxInc);
            //�d�����z�v�i�Ŕ����j
            writer.Write(temp.StockTtlPricTaxExc);
            //�d���������z
            writer.Write(temp.StockNetPrice);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�d���O�őΏۊz���v
            writer.Write(temp.TtlItdedStcOutTax);
            //�d�����őΏۊz���v
            writer.Write(temp.TtlItdedStcInTax);
            //�d����ېőΏۊz���v
            writer.Write(temp.TtlItdedStcTaxFree);
            //�d�����z����Ŋz�i�O�Łj
            writer.Write(temp.StockOutTax);
            //�d�����z����Ŋz�i���Łj
            writer.Write(temp.StckPrcConsTaxInclu);
            //�d���l�����z�v�i�Ŕ����j
            writer.Write(temp.StckDisTtlTaxExc);
            //�d���l���O�őΏۊz���v
            writer.Write(temp.ItdedStockDisOutTax);
            //�d���l�����őΏۊz���v
            writer.Write(temp.ItdedStockDisInTax);
            //�d���l����ېőΏۊz���v
            writer.Write(temp.ItdedStockDisTaxFre);
            //�d���l������Ŋz�i�O�Łj
            writer.Write(temp.StockDisOutTax);
            //�d���l������Ŋz�i���Łj
            writer.Write(temp.StckDisTtlTaxInclu);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d�������Őŗ�
            writer.Write(temp.SupplierConsTaxRate);
            //���|�����
            writer.Write(temp.AccPayConsTax);
            //�d���[�������敪
            writer.Write(temp.StockFractionProcCd);
            //�����x���敪
            writer.Write(temp.AutoPayment);
            //�����x���`�[�ԍ�
            writer.Write(temp.AutoPaySlipNum);
            //�ԕi���R�R�[�h
            writer.Write(temp.RetGoodsReasonDiv);
            //�ԕi���R
            writer.Write(temp.RetGoodsReason);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d���`�[���l1
            writer.Write(temp.SupplierSlipNote1);
            //�d���`�[���l2
            writer.Write(temp.SupplierSlipNote2);
            //���׍s��
            writer.Write(temp.DetailRowCount);
            //�d�c�h���M��
            writer.Write((Int64)temp.EdiSendDate.Ticks);
            //�d�c�h�捞��
            writer.Write((Int64)temp.EdiTakeInDate.Ticks);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //�`�[���s�敪
            writer.Write(temp.SlipPrintDivCd);
            //�`�[���s�ϋ敪
            writer.Write(temp.SlipPrintFinishCd);
            //�d���`�[���s��
            writer.Write((Int64)temp.StockSlipPrintDate.Ticks);
            //�`�[����ݒ�p���[ID
            writer.Write(temp.SlipPrtSetPaperId);

        }

        /// <summary>
        ///  StockSlipHistWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockSlipHistWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipHistWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private APStockSlipHistWork GetStockSlipHistWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            APStockSlipHistWork temp = new APStockSlipHistWork();

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
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�ԍ��A���d���`�[�ԍ�
            temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //���|�敪
            temp.AccPayDivCd = reader.ReadInt32();
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //�d���v�㋒�_�R�[�h
            temp.StockAddUpSectionCd = reader.ReadString();
            //�d���`�[�X�V�敪
            temp.StockSlipUpdateCd = reader.ReadInt32();
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //���ד�
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���v����t
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //�����敪
            temp.DelayPaymentDiv = reader.ReadInt32();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��
            temp.BusinessTypeName = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //�d�����͎҃R�[�h
            temp.StockInputCode = reader.ReadString();
            //�d�����͎Җ���
            temp.StockInputName = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //���z�\���|���K�p�敪
            temp.TtlAmntDispRateApy = reader.ReadInt32();
            //�d�����z���v
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v
            temp.StockSubttlPrice = reader.ReadInt64();
            //�d�����z�v�i�ō��݁j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //�d�����z�v�i�Ŕ����j
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�d���������z
            temp.StockNetPrice = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�d���O�őΏۊz���v
            temp.TtlItdedStcOutTax = reader.ReadInt64();
            //�d�����őΏۊz���v
            temp.TtlItdedStcInTax = reader.ReadInt64();
            //�d����ېőΏۊz���v
            temp.TtlItdedStcTaxFree = reader.ReadInt64();
            //�d�����z����Ŋz�i�O�Łj
            temp.StockOutTax = reader.ReadInt64();
            //�d�����z����Ŋz�i���Łj
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //�d���l�����z�v�i�Ŕ����j
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            //�d���l���O�őΏۊz���v
            temp.ItdedStockDisOutTax = reader.ReadInt64();
            //�d���l�����őΏۊz���v
            temp.ItdedStockDisInTax = reader.ReadInt64();
            //�d���l����ېőΏۊz���v
            temp.ItdedStockDisTaxFre = reader.ReadInt64();
            //�d���l������Ŋz�i�O�Łj
            temp.StockDisOutTax = reader.ReadInt64();
            //�d���l������Ŋz�i���Łj
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d�������Őŗ�
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //���|�����
            temp.AccPayConsTax = reader.ReadInt64();
            //�d���[�������敪
            temp.StockFractionProcCd = reader.ReadInt32();
            //�����x���敪
            temp.AutoPayment = reader.ReadInt32();
            //�����x���`�[�ԍ�
            temp.AutoPaySlipNum = reader.ReadInt32();
            //�ԕi���R�R�[�h
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //�ԕi���R
            temp.RetGoodsReason = reader.ReadString();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d���`�[���l1
            temp.SupplierSlipNote1 = reader.ReadString();
            //�d���`�[���l2
            temp.SupplierSlipNote2 = reader.ReadString();
            //���׍s��
            temp.DetailRowCount = reader.ReadInt32();
            //�d�c�h���M��
            temp.EdiSendDate = new DateTime(reader.ReadInt64());
            //�d�c�h�捞��
            temp.EdiTakeInDate = new DateTime(reader.ReadInt64());
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�`�[���s�敪
            temp.SlipPrintDivCd = reader.ReadInt32();
            //�`�[���s�ϋ敪
            temp.SlipPrintFinishCd = reader.ReadInt32();
            //�d���`�[���s��
            temp.StockSlipPrintDate = new DateTime(reader.ReadInt64());
            //�`�[����ݒ�p���[ID
            temp.SlipPrtSetPaperId = reader.ReadString();


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
        /// <returns>StockSlipHistWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlipHistWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APStockSlipHistWork temp = GetStockSlipHistWork(reader, serInfo);
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
                    retValue = (APStockSlipHistWork[])lst.ToArray(typeof(APStockSlipHistWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

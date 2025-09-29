using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockTemp
    /// <summary>
    ///                      �d�����i���d���������́j
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����i���d���������́j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/9  ���n</br>
    /// <br>                 :   ���d���������͗p�f�[�^�N���X�B</br>
    /// <br>                 :   �d���f�[�^����юd�����׃f�[�^�������B</br>
    /// <br>                 :   �d�����ڂ́A�d�����׃f�[�^�ɑ��݂��鍀�ڂ̖����ɁuDetail�v��t���B</br>
    /// <br>                 :   �ȉ���ǉ��B</br>
    /// <br>                 :   �����@���񊨒�J�n��</br>
    /// <br>                 :   �x���於�́@�x���於�̂Q</br>
    /// <br>                 :   �v��\���ʁ@�v��ϐ���</br>
    /// <br>                 :   �G�f�B�b�g�X�e�[�^�X</br>
    /// </remarks>
    public class StockTemp
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
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</remarks>
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
        /// <remarks>�����҂��Z�b�g</remarks>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        /// <remarks>�����҂��Z�b�g</remarks>
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
        /// <remarks>���ׂł͓��ד`�[���s���i���������s�����������g�p�j</remarks>
        private DateTime _stockSlipPrintDate;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�d���`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q�Ɓ@�i����,���חp�j</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�`�[�Z���敪</summary>
        /// <remarks>1:���Ӑ�,2:�[����</remarks>
        private Int32 _slipAddressDiv;

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
        /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
        private string _addresseeName2 = "";

        /// <summary>�[�i��X�֔ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseePostNo = "";

        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr1 = "";

        /// <summary>�[�i��Z��3(�Ԓn)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr3 = "";

        /// <summary>�[�i��Z��4(�A�p�[�g����)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr4 = "";

        /// <summary>�[�i��d�b�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeTelNo = "";

        /// <summary>�[�i��FAX�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeFaxNo = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j</remarks>
        private Int32 _directSendingCd;

        /// <summary>�󒍔ԍ�</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormalDetail;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</remarks>
        private Int32 _supplierSlipNoDetail;

        /// <summary>�d���s�ԍ�</summary>
        private Int32 _stockRowNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCodeDetail = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCodeDetail;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>�d���`���i���j</summary>
        /// <remarks>0:�d��,1:����,2:����</remarks>
        private Int32 _supplierFormalSrc;

        /// <summary>�d�����גʔԁi���j</summary>
        /// <remarks>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</remarks>
        private Int64 _stockSlipDtlNumSrc;

        /// <summary>�󒍃X�e�[�^�X�i�����j</summary>
        /// <remarks>30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatusSync;

        /// <summary>���㖾�גʔԁi�����j</summary>
        /// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
        private Int64 _salesSlipDtlNumSync;

        /// <summary>�d���`�[�敪�i���ׁj</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>�d�����͎҃R�[�h</summary>
        private string _stockInputCodeDetail = "";

        /// <summary>�d�����͎Җ���</summary>
        private string _stockInputNameDetail = "";

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCodeDetail = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentNameDetail = "";

        /// <summary>���i����</summary>
        private Int32 _goodsKindCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���[�J�[�J�i����</summary>
        private string _makerKanaName = "";

        /// <summary>���[�J�[�J�i���́i�ꎮ�j</summary>
        private string _cmpltMakerKanaName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ރR�[�h</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        private string _enterpriseGanreName = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>0:���,1:�݌�</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>���i�|�������N</summary>
        /// <remarks>���i�̊|���p�����N</remarks>
        private string _goodsRateRank = "";

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�d����|���O���[�v�R�[�h</summary>
        private Int32 _suppRateGrpCode;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>�d����</summary>
        private Double _stockRate;

        /// <summary>�|���ݒ苒�_�i�d���P���j</summary>
        /// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
        private string _rateSectStckUnPrc = "";

        /// <summary>�|���ݒ�敪�i�d���P���j</summary>
        /// <remarks>A7,A8,�c</remarks>
        private string _rateDivStckUnPrc = "";

        /// <summary>�P���Z�o�敪�i�d���P���j</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unPrcCalcCdStckUnPrc;

        /// <summary>���i�敪�i�d���P���j</summary>
        /// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
        private Int32 _priceCdStckUnPrc;

        /// <summary>��P���i�d���P���j</summary>
        private Double _stdUnPrcStckUnPrc;

        /// <summary>�[�������P�ʁi�d���P���j</summary>
        private Double _fracProcUnitStcUnPrc;

        /// <summary>�[�������i�d���P���j</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _fracProcStckUnPrc;

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���P���i�ō��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _stockUnitTaxPriceFl;

        /// <summary>�d���P���ύX�敪</summary>
        /// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�d���P������́j</remarks>
        private Int32 _stockUnitChngDiv;

        /// <summary>�ύX�O�d���P���i�����j</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>�ύX�O�艿</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfListPrice;

        /// <summary>BL���i�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
        private string _rateBLGoodsName = "";

        /// <summary>���i�|���O���[�v�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateGoodsRateGrpCd;

        /// <summary>���i�|���O���[�v���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj</remarks>
        private string _rateGoodsRateGrpNm = "";

        /// <summary>BL�O���[�v�R�[�h�i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj</remarks>
        private Int32 _rateBLGroupCode;

        /// <summary>BL�O���[�v���́i�|���j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj</remarks>
        private string _rateBLGroupName = "";

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>��������</summary>
        /// <remarks>����,���ׂŎg�p</remarks>
        private Double _orderCnt;

        /// <summary>����������</summary>
        /// <remarks>���݂̔������́u�������ʁ{�����������v�ŎZ�o</remarks>
        private Double _orderAdjustCnt;

        /// <summary>�����c��</summary>
        /// <remarks>�������ʁ{�����������|�d����</remarks>
        private Double _orderRemainCnt;

        /// <summary>�c���X�V��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _remainCntUpdDate;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z�i�ō��݁j</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</remarks>
        private Int32 _stockGoodsCdDetail;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _stockPriceConsTaxDetail;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationCode;

        /// <summary>�d���`�[���ה��l1</summary>
        private string _stockDtiSlipNote1 = "";

        /// <summary>�̔���R�[�h</summary>
        private Int32 _salesCustomerCode;

        /// <summary>�̔��旪��</summary>
        private string _salesCustomerSnm = "";

        /// <summary>�`�[�����P</summary>
        private string _slipMemo1 = "";

        /// <summary>�`�[�����Q</summary>
        private string _slipMemo2 = "";

        /// <summary>�`�[�����R</summary>
        private string _slipMemo3 = "";

        /// <summary>�Г������P</summary>
        private string _insideMemo1 = "";

        /// <summary>�Г������Q</summary>
        private string _insideMemo2 = "";

        /// <summary>�Г������R</summary>
        private string _insideMemo3 = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�����p</remarks>
        private Int32 _supplierCdDetail;

        /// <summary>�d���旪��</summary>
        /// <remarks>�����p</remarks>
        private string _supplierSnmDetail = "";

        /// <summary>�[�i��R�[�h</summary>
        /// <remarks>�����p</remarks>
        private Int32 _addresseeCodeDetail;

        /// <summary>�[�i�於��</summary>
        /// <remarks>�����p</remarks>
        private string _addresseeNameDetail = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j</remarks>
        private Int32 _directSendingCdDetail;

        /// <summary>�����ԍ�</summary>
        /// <remarks>�����p</remarks>
        private string _orderNumber = "";

        /// <summary>�������@</summary>
        /// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</remarks>
        private Int32 _wayToOrder;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�����p�@�i�����񓚔[���j</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>��]�[��</summary>
        /// <remarks>�����p</remarks>
        private DateTime _expectDeliveryDate;

        /// <summary>�����f�[�^�쐬�敪</summary>
        /// <remarks>1:�󔭒��������,2:��������,3:�݌ɕ�[����,4:�����_����@�i�������j</remarks>
        private Int32 _orderDataCreateDiv;

        /// <summary>�����f�[�^�쐬��</summary>
        /// <remarks>�����p</remarks>
        private DateTime _orderDataCreateDate;

        /// <summary>���������s�ϋ敪</summary>
        /// <remarks>0:�����s,1:���s��</remarks>
        private Int32 _orderFormIssuedDiv;

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>���񊨒�J�n��</summary>
        /// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於�̂Q</summary>
        private string _payeeName2 = "";

        /// <summary>�v��\����</summary>
        private Double _addUpEnableCnt;

        /// <summary>�v��ϐ���</summary>
        private Double _alreadyAddUpCnt;

        /// <summary>�G�f�B�b�g�X�e�[�^�X</summary>
        private Int32 _editStatus;

        /// <summary>���ʃL�[</summary>
        private Guid _dtlRelationGuid;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�d�����_����</summary>
        private string _stockSectionNm = "";

        /// <summary>�d���v�㋒�_����</summary>
        private string _stockAddUpSectionNm = "";

        /// <summary>�d�������œ]�ŕ�������</summary>
        /// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
        private string _suppCTaxLayMethodNm = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";


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
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
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
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</value>
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

        /// public propaty name  :  InputDayJpFormal
        /// <summary>���͓� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayJpInFormal
        /// <summary>���͓� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdFormal
        /// <summary>���͓� ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdInFormal
        /// <summary>���͓� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inputDay); }
            set { }
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

        /// public propaty name  :  ArrivalGoodsDayJpFormal
        /// <summary>���ד� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ArrivalGoodsDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayJpInFormal
        /// <summary>���ד� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ArrivalGoodsDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdFormal
        /// <summary>���ד� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ArrivalGoodsDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdInFormal
        /// <summary>���ד� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ArrivalGoodsDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _arrivalGoodsDay); }
            set { }
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

        /// public propaty name  :  StockDateJpFormal
        /// <summary>�d���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateJpInFormal
        /// <summary>�d���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdFormal
        /// <summary>�d���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdInFormal
        /// <summary>�d���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockDate); }
            set { }
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

        /// public propaty name  :  StockAddUpADateJpFormal
        /// <summary>�d���v����t �a��v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADateJpInFormal
        /// <summary>�d���v����t �a��(��)�v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADateAdFormal
        /// <summary>�d���v����t ����v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADateAdInFormal
        /// <summary>�d���v����t ����(��)�v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockAddUpADate); }
            set { }
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
        /// <value>�����҂��Z�b�g</value>
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
        /// <value>�����҂��Z�b�g</value>
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

        /// public propaty name  :  EdiSendDateJpFormal
        /// <summary>�d�c�h���M�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateJpInFormal
        /// <summary>�d�c�h���M�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdFormal
        /// <summary>�d�c�h���M�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdInFormal
        /// <summary>�d�c�h���M�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate); }
            set { }
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

        /// public propaty name  :  EdiTakeInDateJpFormal
        /// <summary>�d�c�h�捞�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateJpInFormal
        /// <summary>�d�c�h�捞�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdFormal
        /// <summary>�d�c�h�捞�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdInFormal
        /// <summary>�d�c�h�捞�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate); }
            set { }
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
        /// <value>���ׂł͓��ד`�[���s���i���������s�����������g�p�j</value>
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

        /// public propaty name  :  StockSlipPrintDateJpFormal
        /// <summary>�d���`�[���s�� �a��v���p�e�B</summary>
        /// <value>���ׂł͓��ד`�[���s���i���������s�����������g�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���s�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSlipPrintDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  StockSlipPrintDateJpInFormal
        /// <summary>�d���`�[���s�� �a��(��)�v���p�e�B</summary>
        /// <value>���ׂł͓��ד`�[���s���i���������s�����������g�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���s�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSlipPrintDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  StockSlipPrintDateAdFormal
        /// <summary>�d���`�[���s�� ����v���p�e�B</summary>
        /// <value>���ׂł͓��ד`�[���s���i���������s�����������g�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���s�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSlipPrintDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  StockSlipPrintDateAdInFormal
        /// <summary>�d���`�[���s�� ����(��)�v���p�e�B</summary>
        /// <value>���ׂł͓��ד`�[���s���i���������s�����������g�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���s�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSlipPrintDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�d���`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q�Ɓ@�i����,���חp�j</value>
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

        /// public propaty name  :  SlipAddressDiv
        /// <summary>�`�[�Z���敪�v���p�e�B</summary>
        /// <value>1:���Ӑ�,2:�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Z���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
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

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
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
        /// <value>�ǉ�(�o�^�R��) ����</value>
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

        /// public propaty name  :  AddresseePostNo
        /// <summary>�[�i��X�֔ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>�[�i��Z��3(�Ԓn)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��3(�Ԓn)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>�[�i��Z��4(�A�p�[�g����)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��4(�A�p�[�g����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>�[�i��d�b�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>�[�i��FAX�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
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

        /// public propaty name  :  SupplierFormalDetail
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormalDetail
        {
            get { return _supplierFormalDetail; }
            set { _supplierFormalDetail = value; }
        }

        /// public propaty name  :  SupplierSlipNoDetail
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNoDetail
        {
            get { return _supplierSlipNoDetail; }
            set { _supplierSlipNoDetail = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>�d���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  SectionCodeDetail
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeDetail
        {
            get { return _sectionCodeDetail; }
            set { _sectionCodeDetail = value; }
        }

        /// public propaty name  :  SubSectionCodeDetail
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCodeDetail
        {
            get { return _subSectionCodeDetail; }
            set { _subSectionCodeDetail = value; }
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

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SupplierFormalSrc
        /// <summary>�d���`���i���j�v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormalSrc
        {
            get { return _supplierFormalSrc; }
            set { _supplierFormalSrc = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSrc
        /// <summary>�d�����גʔԁi���j�v���p�e�B</summary>
        /// <value>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԁi���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSrc
        {
            get { return _stockSlipDtlNumSrc; }
            set { _stockSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSync
        /// <summary>�󒍃X�e�[�^�X�i�����j�v���p�e�B</summary>
        /// <value>30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSync
        {
            get { return _acptAnOdrStatusSync; }
            set { _acptAnOdrStatusSync = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSync
        /// <summary>���㖾�גʔԁi�����j�v���p�e�B</summary>
        /// <value>�����v�㎞�̎d�����גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSync
        {
            get { return _salesSlipDtlNumSync; }
            set { _salesSlipDtlNumSync = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockInputCodeDetail
        /// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputCodeDetail
        {
            get { return _stockInputCodeDetail; }
            set { _stockInputCodeDetail = value; }
        }

        /// public propaty name  :  StockInputNameDetail
        /// <summary>�d�����͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputNameDetail
        {
            get { return _stockInputNameDetail; }
            set { _stockInputNameDetail = value; }
        }

        /// public propaty name  :  StockAgentCodeDetail
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCodeDetail
        {
            get { return _stockAgentCodeDetail; }
            set { _stockAgentCodeDetail = value; }
        }

        /// public propaty name  :  StockAgentNameDetail
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentNameDetail
        {
            get { return _stockAgentNameDetail; }
            set { _stockAgentNameDetail = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
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

        /// public propaty name  :  MakerKanaName
        /// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set { _makerKanaName = value; }
        }

        /// public propaty name  :  CmpltMakerKanaName
        /// <summary>���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltMakerKanaName
        {
            get { return _cmpltMakerKanaName; }
            set { _cmpltMakerKanaName = value; }
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

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
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

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:���,1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>���i�̊|���p�����N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  SuppRateGrpCode
        /// <summary>�d����|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppRateGrpCode
        {
            get { return _suppRateGrpCode; }
            set { _suppRateGrpCode = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
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

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
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

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  RateSectStckUnPrc
        /// <summary>�|���ݒ苒�_�i�d���P���j�v���p�e�B</summary>
        /// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ苒�_�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSectStckUnPrc
        {
            get { return _rateSectStckUnPrc; }
            set { _rateSectStckUnPrc = value; }
        }

        /// public propaty name  :  RateDivStckUnPrc
        /// <summary>�|���ݒ�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>A7,A8,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateDivStckUnPrc
        {
            get { return _rateDivStckUnPrc; }
            set { _rateDivStckUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdStckUnPrc
        /// <summary>�P���Z�o�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcCalcCdStckUnPrc
        {
            get { return _unPrcCalcCdStckUnPrc; }
            set { _unPrcCalcCdStckUnPrc = value; }
        }

        /// public propaty name  :  PriceCdStckUnPrc
        /// <summary>���i�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCdStckUnPrc
        {
            get { return _priceCdStckUnPrc; }
            set { _priceCdStckUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcStckUnPrc
        /// <summary>��P���i�d���P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcStckUnPrc
        {
            get { return _stdUnPrcStckUnPrc; }
            set { _stdUnPrcStckUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitStcUnPrc
        /// <summary>�[�������P�ʁi�d���P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʁi�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FracProcUnitStcUnPrc
        {
            get { return _fracProcUnitStcUnPrc; }
            set { _fracProcUnitStcUnPrc = value; }
        }

        /// public propaty name  :  FracProcStckUnPrc
        /// <summary>�[�������i�d���P���j�v���p�e�B</summary>
        /// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FracProcStckUnPrc
        {
            get { return _fracProcStckUnPrc; }
            set { _fracProcStckUnPrc = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>�d���P���i�ō��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockUnitChngDiv
        /// <summary>�d���P���ύX�敪�v���p�e�B</summary>
        /// <value>0:�ύX�Ȃ�,1:�ύX����@�i�d���P������́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnitChngDiv
        {
            get { return _stockUnitChngDiv; }
            set { _stockUnitChngDiv = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�d���P���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfListPrice
        /// <summary>�ύX�O�艿�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }

        /// public propaty name  :  RateBLGoodsCode
        /// <summary>BL���i�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateBLGoodsCode
        {
            get { return _rateBLGoodsCode; }
            set { _rateBLGoodsCode = value; }
        }

        /// public propaty name  :  RateBLGoodsName
        /// <summary>BL���i�R�[�h���́i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateBLGoodsName
        {
            get { return _rateBLGoodsName; }
            set { _rateBLGoodsName = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpCd
        /// <summary>���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateGoodsRateGrpCd
        {
            get { return _rateGoodsRateGrpCd; }
            set { _rateGoodsRateGrpCd = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpNm
        /// <summary>���i�|���O���[�v���́i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateGoodsRateGrpNm
        {
            get { return _rateGoodsRateGrpNm; }
            set { _rateGoodsRateGrpNm = value; }
        }

        /// public propaty name  :  RateBLGroupCode
        /// <summary>BL�O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateBLGroupCode
        {
            get { return _rateBLGroupCode; }
            set { _rateBLGroupCode = value; }
        }

        /// public propaty name  :  RateBLGroupName
        /// <summary>BL�O���[�v���́i�|���j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateBLGroupName
        {
            get { return _rateBLGroupName; }
            set { _rateBLGroupName = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  OrderCnt
        /// <summary>�������ʃv���p�e�B</summary>
        /// <value>����,���ׂŎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderCnt
        {
            get { return _orderCnt; }
            set { _orderCnt = value; }
        }

        /// public propaty name  :  OrderAdjustCnt
        /// <summary>�����������v���p�e�B</summary>
        /// <value>���݂̔������́u�������ʁ{�����������v�ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderAdjustCnt
        {
            get { return _orderAdjustCnt; }
            set { _orderAdjustCnt = value; }
        }

        /// public propaty name  :  OrderRemainCnt
        /// <summary>�����c���v���p�e�B</summary>
        /// <value>�������ʁ{�����������|�d����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderRemainCnt
        {
            get { return _orderRemainCnt; }
            set { _orderRemainCnt = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>�c���X�V���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set { _remainCntUpdDate = value; }
        }

        /// public propaty name  :  RemainCntUpdDateJpFormal
        /// <summary>�c���X�V�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateJpInFormal
        /// <summary>�c���X�V�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateAdFormal
        /// <summary>�c���X�V�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateAdInFormal
        /// <summary>�c���X�V�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RemainCntUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>�d�����z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockGoodsCdDetail
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCdDetail
        {
            get { return _stockGoodsCdDetail; }
            set { _stockGoodsCdDetail = value; }
        }

        /// public propaty name  :  StockPriceConsTaxDetail
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTaxDetail
        {
            get { return _stockPriceConsTaxDetail; }
            set { _stockPriceConsTaxDetail = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>�d���`�[���ה��l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���ה��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set { _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>�̔���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set { _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerSnm
        /// <summary>�̔��旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCustomerSnm
        {
            get { return _salesCustomerSnm; }
            set { _salesCustomerSnm = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>�`�[�����P�v���p�e�B</summary>
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

        /// public propaty name  :  SupplierCdDetail
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdDetail
        {
            get { return _supplierCdDetail; }
            set { _supplierCdDetail = value; }
        }

        /// public propaty name  :  SupplierSnmDetail
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnmDetail
        {
            get { return _supplierSnmDetail; }
            set { _supplierSnmDetail = value; }
        }

        /// public propaty name  :  AddresseeCodeDetail
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCodeDetail
        {
            get { return _addresseeCodeDetail; }
            set { _addresseeCodeDetail = value; }
        }

        /// public propaty name  :  AddresseeNameDetail
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeNameDetail
        {
            get { return _addresseeNameDetail; }
            set { _addresseeNameDetail = value; }
        }

        /// public propaty name  :  DirectSendingCdDetail
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DirectSendingCdDetail
        {
            get { return _directSendingCdDetail; }
            set { _directSendingCdDetail = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>�������@�v���p�e�B</summary>
        /// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</value>
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

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�����p�@�i�����񓚔[���j</value>
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
        /// <value>�����p�@�i�����񓚔[���j</value>
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
        /// <value>�����p�@�i�����񓚔[���j</value>
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
        /// <value>�����p�@�i�����񓚔[���j</value>
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
        /// <value>�����p�@�i�����񓚔[���j</value>
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

        /// public propaty name  :  ExpectDeliveryDate
        /// <summary>��]�[���v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExpectDeliveryDate
        {
            get { return _expectDeliveryDate; }
            set { _expectDeliveryDate = value; }
        }

        /// public propaty name  :  ExpectDeliveryDateJpFormal
        /// <summary>��]�[�� �a��v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectDeliveryDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  ExpectDeliveryDateJpInFormal
        /// <summary>��]�[�� �a��(��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectDeliveryDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  ExpectDeliveryDateAdFormal
        /// <summary>��]�[�� ����v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectDeliveryDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  ExpectDeliveryDateAdInFormal
        /// <summary>��]�[�� ����(��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectDeliveryDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDiv
        /// <summary>�����f�[�^�쐬�敪�v���p�e�B</summary>
        /// <value>1:�󔭒��������,2:��������,3:�݌ɕ�[����,4:�����_����@�i�������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderDataCreateDiv
        {
            get { return _orderDataCreateDiv; }
            set { _orderDataCreateDiv = value; }
        }

        /// public propaty name  :  OrderDataCreateDate
        /// <summary>�����f�[�^�쐬���v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OrderDataCreateDate
        {
            get { return _orderDataCreateDate; }
            set { _orderDataCreateDate = value; }
        }

        /// public propaty name  :  OrderDataCreateDateJpFormal
        /// <summary>�����f�[�^�쐬�� �a��v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderDataCreateDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDateJpInFormal
        /// <summary>�����f�[�^�쐬�� �a��(��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderDataCreateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDateAdFormal
        /// <summary>�����f�[�^�쐬�� ����v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderDataCreateDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDateAdInFormal
        /// <summary>�����f�[�^�쐬�� ����(��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderDataCreateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderFormIssuedDiv
        /// <summary>���������s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s,1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderFormIssuedDiv
        {
            get { return _orderFormIssuedDiv; }
            set { _orderFormIssuedDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>���񊨒�J�n���v���p�e�B</summary>
        /// <value>01�`31�܂Łi�ȗ��\�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  AddUpEnableCnt
        /// <summary>�v��\���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��\���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AddUpEnableCnt
        {
            get { return _addUpEnableCnt; }
            set { _addUpEnableCnt = value; }
        }

        /// public propaty name  :  AlreadyAddUpCnt
        /// <summary>�v��ϐ��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��ϐ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AlreadyAddUpCnt
        {
            get { return _alreadyAddUpCnt; }
            set { _alreadyAddUpCnt = value; }
        }

        /// public propaty name  :  EditStatus
        /// <summary>�G�f�B�b�g�X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G�f�B�b�g�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EditStatus
        {
            get { return _editStatus; }
            set { _editStatus = value; }
        }

        /// public propaty name  :  DtlRelationGuid
        /// <summary>���ʃL�[�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃL�[�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  StockSectionNm
        /// <summary>�d�����_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionNm
        {
            get { return _stockSectionNm; }
            set { _stockSectionNm = value; }
        }

        /// public propaty name  :  StockAddUpSectionNm
        /// <summary>�d���v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpSectionNm
        {
            get { return _stockAddUpSectionNm; }
            set { _stockAddUpSectionNm = value; }
        }

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>�d�������œ]�ŕ������̃v���p�e�B</summary>
        /// <value>�`�[�P�ʁA���גP�ʁA�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
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


        /// <summary>
        /// �d�����i���d���������́j�R���X�g���N�^
        /// </summary>
        /// <returns>StockTemp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTemp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTemp()
        {
        }

        /// <summary>
        /// �d�����i���d���������́j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="supplierFormal">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�(�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
        /// <param name="debitNLnkSuppSlipNo">�ԍ��A���d���`�[�ԍ�</param>
        /// <param name="supplierSlipCd">�d���`�[�敪(10:�d��,20:�ԕi)</param>
        /// <param name="stockGoodsCd">�d�����i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����))</param>
        /// <param name="accPayDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="stockSectionCd">�d�����_�R�[�h</param>
        /// <param name="stockAddUpSectionCd">�d���v�㋒�_�R�[�h(�����^ �d���v��Ώۂ̋��_�R�[�h(���_����̎x���v�㋒�_�̂���))</param>
        /// <param name="stockSlipUpdateCd">�d���`�[�X�V�敪(0:���X�V,1:�X�V����)</param>
        /// <param name="inputDay">���͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="arrivalGoodsDay">���ד�(YYYYMMDD)</param>
        /// <param name="stockDate">�d����(YYYYMMDD)</param>
        /// <param name="stockAddUpADate">�d���v����t(�d���v���)</param>
        /// <param name="delayPaymentDiv">�����敪(0:����(�����Ȃ�),1:����,2:�ė����c9:9������)</param>
        /// <param name="payeeCode">�x����R�[�h(�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B)</param>
        /// <param name="payeeSnm">�x���旪��</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierNm1">�d���於1</param>
        /// <param name="supplierNm2">�d���於2</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
        /// <param name="salesAreaName">�̔��G���A����</param>
        /// <param name="stockInputCode">�d�����͎҃R�[�h</param>
        /// <param name="stockInputName">�d�����͎Җ���</param>
        /// <param name="stockAgentCode">�d���S���҃R�[�h(�����҂��Z�b�g)</param>
        /// <param name="stockAgentName">�d���S���Җ���(�����҂��Z�b�g)</param>
        /// <param name="suppTtlAmntDspWayCd">�d���摍�z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="ttlAmntDispRateApy">���z�\���|���K�p�敪(0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��)</param>
        /// <param name="stockTotalPrice">�d�����z���v(�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v)</param>
        /// <param name="stockSubttlPrice">�d�����z���v(�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v)</param>
        /// <param name="stockTtlPricTaxInc">�d�����z�v�i�ō��݁j(�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v)</param>
        /// <param name="stockTtlPricTaxExc">�d�����z�v�i�Ŕ����j(�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����)</param>
        /// <param name="stockNetPrice">�d���������z(�l���O�̐Ŕ��d�����z)</param>
        /// <param name="stockPriceConsTax">�d�����z����Ŋz(�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj)</param>
        /// <param name="ttlItdedStcOutTax">�d���O�őΏۊz���v(�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j)</param>
        /// <param name="ttlItdedStcInTax">�d�����őΏۊz���v(���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j )</param>
        /// <param name="ttlItdedStcTaxFree">�d����ېőΏۊz���v(��ېőΏۋ��z�̏W�v�i�l���܂܂��j)</param>
        /// <param name="stockOutTax">�d�����z����Ŋz�i�O�Łj(�l���O�̊O�ŏ��i�̏����)</param>
        /// <param name="stckPrcConsTaxInclu">�d�����z����Ŋz�i���Łj(�l���O�̓��ŏ��i�̏����)</param>
        /// <param name="stckDisTtlTaxExc">�d���l�����z�v�i�Ŕ����j(�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v)</param>
        /// <param name="itdedStockDisOutTax">�d���l���O�őΏۊz���v(�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j)</param>
        /// <param name="itdedStockDisInTax">�d���l�����őΏۊz���v(���ŏ��i�l���̓��őΏۊz�i�Ŕ��j)</param>
        /// <param name="itdedStockDisTaxFre">�d���l����ېőΏۊz���v(��ېŏ��i�l���̔�ېőΏۊz)</param>
        /// <param name="stockDisOutTax">�d���l������Ŋz�i�O�Łj(�O�ŏ��i�l���̏���Ŋz)</param>
        /// <param name="stckDisTtlTaxInclu">�d���l������Ŋz�i���Łj(���ŏ��i�l���̏���Ŋz)</param>
        /// <param name="taxAdjust">����Œ����z</param>
        /// <param name="balanceAdjust">�c�������z</param>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h(0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�)</param>
        /// <param name="supplierConsTaxRate">�d�������Őŗ�</param>
        /// <param name="accPayConsTax">���|�����</param>
        /// <param name="stockFractionProcCd">�d���[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj)</param>
        /// <param name="autoPayment">�����x���敪(0:�ʏ�x��,1:�����x��)</param>
        /// <param name="autoPaySlipNum">�����x���`�[�ԍ�(�����x�����̎x���`�[�ԍ�)</param>
        /// <param name="retGoodsReasonDiv">�ԕi���R�R�[�h</param>
        /// <param name="retGoodsReason">�ԕi���R</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�(�d����`�[�ԍ��Ɏg�p����)</param>
        /// <param name="supplierSlipNote1">�d���`�[���l1</param>
        /// <param name="supplierSlipNote2">�d���`�[���l2</param>
        /// <param name="detailRowCount">���׍s��(�`�[���̖��ׂ̍s���i����p���ׂ͏����j)</param>
        /// <param name="ediSendDate">�d�c�h���M��(YYYYMMDD �iErectricDataInterface�j)</param>
        /// <param name="ediTakeInDate">�d�c�h�捞��(YYYYMMDD)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P(UserOrderEntory)</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="slipPrintDivCd">�`�[���s�敪(0:���Ȃ� 1:����)</param>
        /// <param name="slipPrintFinishCd">�`�[���s�ϋ敪(0:�����s 1:���s��)</param>
        /// <param name="stockSlipPrintDate">�d���`�[���s��(���ׂł͓��ד`�[���s���i���������s�����������g�p�j)</param>
        /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(�d���`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q�Ɓ@�i����,���חp�j)</param>
        /// <param name="slipAddressDiv">�`�[�Z���敪(1:���Ӑ�,2:�[����)</param>
        /// <param name="addresseeCode">�[�i��R�[�h</param>
        /// <param name="addresseeName">�[�i�於��</param>
        /// <param name="addresseeName2">�[�i�於��2(�ǉ�(�o�^�R��) ����)</param>
        /// <param name="addresseePostNo">�[�i��X�֔ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr1">�[�i��Z��1(�s���{���s��S�E�����E��)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr3">�[�i��Z��3(�Ԓn)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr4">�[�i��Z��4(�A�p�[�g����)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeTelNo">�[�i��d�b�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeFaxNo">�[�i��FAX�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="directSendingCd">�����敪(0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j)</param>
        /// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
        /// <param name="supplierFormalDetail">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="supplierSlipNoDetail">�d���`�[�ԍ�(�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�B�i�������̓[���j)</param>
        /// <param name="stockRowNo">�d���s�ԍ�</param>
        /// <param name="sectionCodeDetail">���_�R�[�h</param>
        /// <param name="subSectionCodeDetail">����R�[�h</param>
        /// <param name="commonSeqNo">���ʒʔ�</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <param name="supplierFormalSrc">�d���`���i���j(0:�d��,1:����,2:����)</param>
        /// <param name="stockSlipDtlNumSrc">�d�����גʔԁi���j(�v�㎞�̌��f�[�^���גʔԂ��Z�b�g)</param>
        /// <param name="acptAnOdrStatusSync">�󒍃X�e�[�^�X�i�����j(30:����,40:�o��)</param>
        /// <param name="salesSlipDtlNumSync">���㖾�גʔԁi�����j(�����v�㎞�̎d�����גʔԂ��Z�b�g)</param>
        /// <param name="stockSlipCdDtl">�d���`�[�敪�i���ׁj(0:�d��,1:�ԕi,2:�l��)</param>
        /// <param name="stockInputCodeDetail">�d�����͎҃R�[�h</param>
        /// <param name="stockInputNameDetail">�d�����͎Җ���</param>
        /// <param name="stockAgentCodeDetail">�d���S���҃R�[�h</param>
        /// <param name="stockAgentNameDetail">�d���S���Җ���</param>
        /// <param name="goodsKindCode">���i����</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h(�߯���ޖ���հ�ް�o�^�͈͂��قȂ�)</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="makerKanaName">���[�J�[�J�i����</param>
        /// <param name="cmpltMakerKanaName">���[�J�[�J�i���́i�ꎮ�j</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsNameKana">���i���̃J�i</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h(���啪�ށi���[�U�[�K�C�h�j)</param>
        /// <param name="goodsLGroupName">���i�啪�ޖ���</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h(�������ރR�[�h)</param>
        /// <param name="goodsMGroupName">���i�����ޖ���</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <param name="enterpriseGanreName">���Е��ޖ���</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="warehouseShelfNo">�q�ɒI��</param>
        /// <param name="stockOrderDivCd">�d���݌Ɏ�񂹋敪(0:���,1:�݌�)</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
        /// <param name="goodsRateRank">���i�|�������N(���i�̊|���p�����N)</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="suppRateGrpCode">�d����|���O���[�v�R�[�h</param>
        /// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�Ŕ���)</param>
        /// <param name="listPriceTaxIncFl">�艿�i�ō��C�����j(�ō���)</param>
        /// <param name="stockRate">�d����</param>
        /// <param name="rateSectStckUnPrc">�|���ݒ苒�_�i�d���P���j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
        /// <param name="rateDivStckUnPrc">�|���ݒ�敪�i�d���P���j(A7,A8,�c)</param>
        /// <param name="unPrcCalcCdStckUnPrc">�P���Z�o�敪�i�d���P���j(1:�|��,2:�����t�o��,3:�e����)</param>
        /// <param name="priceCdStckUnPrc">���i�敪�i�d���P���j(0:�艿,1:�o�^�̔��X���i,�c)</param>
        /// <param name="stdUnPrcStckUnPrc">��P���i�d���P���j</param>
        /// <param name="fracProcUnitStcUnPrc">�[�������P�ʁi�d���P���j</param>
        /// <param name="fracProcStckUnPrc">�[�������i�d���P���j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
        /// <param name="stockUnitPriceFl">�d���P���i�Ŕ��C�����j(�Ŕ���)</param>
        /// <param name="stockUnitTaxPriceFl">�d���P���i�ō��C�����j(�ō���)</param>
        /// <param name="stockUnitChngDiv">�d���P���ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i�d���P������́j)</param>
        /// <param name="bfStockUnitPriceFl">�ύX�O�d���P���i�����j(�Ŕ����A�|���Z�o����)</param>
        /// <param name="bfListPrice">�ύX�O�艿(�Ŕ����A�|���Z�o����)</param>
        /// <param name="rateBLGoodsCode">BL���i�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj)</param>
        /// <param name="rateBLGoodsName">BL���i�R�[�h���́i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj)</param>
        /// <param name="rateGoodsRateGrpCd">���i�|���O���[�v�R�[�h�i�|���j(�|���Z�o���Ɏg�p�������i�|���R�[�h�i���i�������ʁj)</param>
        /// <param name="rateGoodsRateGrpNm">���i�|���O���[�v���́i�|���j(�|���Z�o���Ɏg�p�������i�|�����́i���i�������ʁj)</param>
        /// <param name="rateBLGroupCode">BL�O���[�v�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�O���[�v�R�[�h�i���i�������ʁj)</param>
        /// <param name="rateBLGroupName">BL�O���[�v���́i�|���j(�|���Z�o���Ɏg�p����BL�O���[�v���́i���i�������ʁj)</param>
        /// <param name="stockCount">�d����</param>
        /// <param name="orderCnt">��������(����,���ׂŎg�p)</param>
        /// <param name="orderAdjustCnt">����������(���݂̔������́u�������ʁ{�����������v�ŎZ�o)</param>
        /// <param name="orderRemainCnt">�����c��(�������ʁ{�����������|�d����)</param>
        /// <param name="remainCntUpdDate">�c���X�V��(YYYYMMDD)</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockGoodsCdDetail">�d�����i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����))</param>
        /// <param name="stockPriceConsTaxDetail">�d�����z����Ŋz(�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�)</param>
        /// <param name="taxationCode">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="stockDtiSlipNote1">�d���`�[���ה��l1</param>
        /// <param name="salesCustomerCode">�̔���R�[�h</param>
        /// <param name="salesCustomerSnm">�̔��旪��</param>
        /// <param name="slipMemo1">�`�[�����P</param>
        /// <param name="slipMemo2">�`�[�����Q</param>
        /// <param name="slipMemo3">�`�[�����R</param>
        /// <param name="insideMemo1">�Г������P</param>
        /// <param name="insideMemo2">�Г������Q</param>
        /// <param name="insideMemo3">�Г������R</param>
        /// <param name="supplierCdDetail">�d����R�[�h(�����p)</param>
        /// <param name="supplierSnmDetail">�d���旪��(�����p)</param>
        /// <param name="addresseeCodeDetail">�[�i��R�[�h(�����p)</param>
        /// <param name="addresseeNameDetail">�[�i�於��(�����p)</param>
        /// <param name="directSendingCdDetail">�����敪(0:�����Ȃ�,1:��������@�i�������̒�����󎚐���j)</param>
        /// <param name="orderNumber">�����ԍ�(�����p)</param>
        /// <param name="wayToOrder">�������@(0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^)</param>
        /// <param name="deliGdsCmpltDueDate">�[�i�����\���(�����p�@�i�����񓚔[���j)</param>
        /// <param name="expectDeliveryDate">��]�[��(�����p)</param>
        /// <param name="orderDataCreateDiv">�����f�[�^�쐬�敪(1:�󔭒��������,2:��������,3:�݌ɕ�[����,4:�����_����@�i�������j)</param>
        /// <param name="orderDataCreateDate">�����f�[�^�쐬��(�����p)</param>
        /// <param name="orderFormIssuedDiv">���������s�ϋ敪(0:�����s,1:���s��)</param>
        /// <param name="totalDay">����(DD)</param>
        /// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
        /// <param name="payeeName">�x���於��</param>
        /// <param name="payeeName2">�x���於�̂Q</param>
        /// <param name="addUpEnableCnt">�v��\����</param>
        /// <param name="alreadyAddUpCnt">�v��ϐ���</param>
        /// <param name="editStatus">�G�f�B�b�g�X�e�[�^�X</param>
        /// <param name="dtlRelationGuid">���ʃL�[</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="stockSectionNm">�d�����_����</param>
        /// <param name="stockAddUpSectionNm">�d���v�㋒�_����</param>
        /// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <returns>StockTemp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTemp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTemp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierFormal, Int32 supplierSlipNo, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, Int32 debitNLnkSuppSlipNo, Int32 supplierSlipCd, Int32 stockGoodsCd, Int32 accPayDivCd, string stockSectionCd, string stockAddUpSectionCd, Int32 stockSlipUpdateCd, DateTime inputDay, DateTime arrivalGoodsDay, DateTime stockDate, DateTime stockAddUpADate, Int32 delayPaymentDiv, Int32 payeeCode, string payeeSnm, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 businessTypeCode, string businessTypeName, Int32 salesAreaCode, string salesAreaName, string stockInputCode, string stockInputName, string stockAgentCode, string stockAgentName, Int32 suppTtlAmntDspWayCd, Int32 ttlAmntDispRateApy, Int64 stockTotalPrice, Int64 stockSubttlPrice, Int64 stockTtlPricTaxInc, Int64 stockTtlPricTaxExc, Int64 stockNetPrice, Int64 stockPriceConsTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 stockOutTax, Int64 stckPrcConsTaxInclu, Int64 stckDisTtlTaxExc, Int64 itdedStockDisOutTax, Int64 itdedStockDisInTax, Int64 itdedStockDisTaxFre, Int64 stockDisOutTax, Int64 stckDisTtlTaxInclu, Int64 taxAdjust, Int64 balanceAdjust, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int64 accPayConsTax, Int32 stockFractionProcCd, Int32 autoPayment, Int32 autoPaySlipNum, Int32 retGoodsReasonDiv, string retGoodsReason, string partySaleSlipNum, string supplierSlipNote1, string supplierSlipNote2, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime stockSlipPrintDate, string slipPrtSetPaperId, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, Int32 directSendingCd, Int32 acceptAnOrderNo, Int32 supplierFormalDetail, Int32 supplierSlipNoDetail, Int32 stockRowNo, string sectionCodeDetail, Int32 subSectionCodeDetail, Int64 commonSeqNo, Int64 stockSlipDtlNum, Int32 supplierFormalSrc, Int64 stockSlipDtlNumSrc, Int32 acptAnOdrStatusSync, Int64 salesSlipDtlNumSync, Int32 stockSlipCdDtl, string stockInputCodeDetail, string stockInputNameDetail, string stockAgentCodeDetail, string stockAgentNameDetail, Int32 goodsKindCode, Int32 goodsMakerCd, string makerName, string makerKanaName, string cmpltMakerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 stockOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Int32 suppRateGrpCode, Double listPriceTaxExcFl, Double listPriceTaxIncFl, Double stockRate, string rateSectStckUnPrc, string rateDivStckUnPrc, Int32 unPrcCalcCdStckUnPrc, Int32 priceCdStckUnPrc, Double stdUnPrcStckUnPrc, Double fracProcUnitStcUnPrc, Int32 fracProcStckUnPrc, Double stockUnitPriceFl, Double stockUnitTaxPriceFl, Int32 stockUnitChngDiv, Double bfStockUnitPriceFl, Double bfListPrice, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Double stockCount, Double orderCnt, Double orderAdjustCnt, Double orderRemainCnt, DateTime remainCntUpdDate, Int64 stockPriceTaxExc, Int64 stockPriceTaxInc, Int32 stockGoodsCdDetail, Int64 stockPriceConsTaxDetail, Int32 taxationCode, string stockDtiSlipNote1, Int32 salesCustomerCode, string salesCustomerSnm, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Int32 supplierCdDetail, string supplierSnmDetail, Int32 addresseeCodeDetail, string addresseeNameDetail, Int32 directSendingCdDetail, string orderNumber, Int32 wayToOrder, DateTime deliGdsCmpltDueDate, DateTime expectDeliveryDate, Int32 orderDataCreateDiv, DateTime orderDataCreateDate, Int32 orderFormIssuedDiv, Int32 totalDay, Int32 nTimeCalcStDate, string payeeName, string payeeName2, Double addUpEnableCnt, Double alreadyAddUpCnt, Int32 editStatus, Guid dtlRelationGuid, string enterpriseName, string updEmployeeName, string stockSectionNm, string stockAddUpSectionNm, string suppCTaxLayMethodNm, string bLGoodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierFormal = supplierFormal;
            this._supplierSlipNo = supplierSlipNo;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._debitNoteDiv = debitNoteDiv;
            this._debitNLnkSuppSlipNo = debitNLnkSuppSlipNo;
            this._supplierSlipCd = supplierSlipCd;
            this._stockGoodsCd = stockGoodsCd;
            this._accPayDivCd = accPayDivCd;
            this._stockSectionCd = stockSectionCd;
            this._stockAddUpSectionCd = stockAddUpSectionCd;
            this._stockSlipUpdateCd = stockSlipUpdateCd;
            this.InputDay = inputDay;
            this.ArrivalGoodsDay = arrivalGoodsDay;
            this.StockDate = stockDate;
            this.StockAddUpADate = stockAddUpADate;
            this._delayPaymentDiv = delayPaymentDiv;
            this._payeeCode = payeeCode;
            this._payeeSnm = payeeSnm;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._supplierSnm = supplierSnm;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._stockInputCode = stockInputCode;
            this._stockInputName = stockInputName;
            this._stockAgentCode = stockAgentCode;
            this._stockAgentName = stockAgentName;
            this._suppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
            this._ttlAmntDispRateApy = ttlAmntDispRateApy;
            this._stockTotalPrice = stockTotalPrice;
            this._stockSubttlPrice = stockSubttlPrice;
            this._stockTtlPricTaxInc = stockTtlPricTaxInc;
            this._stockTtlPricTaxExc = stockTtlPricTaxExc;
            this._stockNetPrice = stockNetPrice;
            this._stockPriceConsTax = stockPriceConsTax;
            this._ttlItdedStcOutTax = ttlItdedStcOutTax;
            this._ttlItdedStcInTax = ttlItdedStcInTax;
            this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
            this._stockOutTax = stockOutTax;
            this._stckPrcConsTaxInclu = stckPrcConsTaxInclu;
            this._stckDisTtlTaxExc = stckDisTtlTaxExc;
            this._itdedStockDisOutTax = itdedStockDisOutTax;
            this._itdedStockDisInTax = itdedStockDisInTax;
            this._itdedStockDisTaxFre = itdedStockDisTaxFre;
            this._stockDisOutTax = stockDisOutTax;
            this._stckDisTtlTaxInclu = stckDisTtlTaxInclu;
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
            this._suppCTaxLayCd = suppCTaxLayCd;
            this._supplierConsTaxRate = supplierConsTaxRate;
            this._accPayConsTax = accPayConsTax;
            this._stockFractionProcCd = stockFractionProcCd;
            this._autoPayment = autoPayment;
            this._autoPaySlipNum = autoPaySlipNum;
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this._partySaleSlipNum = partySaleSlipNum;
            this._supplierSlipNote1 = supplierSlipNote1;
            this._supplierSlipNote2 = supplierSlipNote2;
            this._detailRowCount = detailRowCount;
            this.EdiSendDate = ediSendDate;
            this.EdiTakeInDate = ediTakeInDate;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._slipPrintDivCd = slipPrintDivCd;
            this._slipPrintFinishCd = slipPrintFinishCd;
            this.StockSlipPrintDate = stockSlipPrintDate;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._slipAddressDiv = slipAddressDiv;
            this._addresseeCode = addresseeCode;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._addresseePostNo = addresseePostNo;
            this._addresseeAddr1 = addresseeAddr1;
            this._addresseeAddr3 = addresseeAddr3;
            this._addresseeAddr4 = addresseeAddr4;
            this._addresseeTelNo = addresseeTelNo;
            this._addresseeFaxNo = addresseeFaxNo;
            this._directSendingCd = directSendingCd;
            this._acceptAnOrderNo = acceptAnOrderNo;
            this._supplierFormalDetail = supplierFormalDetail;
            this._supplierSlipNoDetail = supplierSlipNoDetail;
            this._stockRowNo = stockRowNo;
            this._sectionCodeDetail = sectionCodeDetail;
            this._subSectionCodeDetail = subSectionCodeDetail;
            this._commonSeqNo = commonSeqNo;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._supplierFormalSrc = supplierFormalSrc;
            this._stockSlipDtlNumSrc = stockSlipDtlNumSrc;
            this._acptAnOdrStatusSync = acptAnOdrStatusSync;
            this._salesSlipDtlNumSync = salesSlipDtlNumSync;
            this._stockSlipCdDtl = stockSlipCdDtl;
            this._stockInputCodeDetail = stockInputCodeDetail;
            this._stockInputNameDetail = stockInputNameDetail;
            this._stockAgentCodeDetail = stockAgentCodeDetail;
            this._stockAgentNameDetail = stockAgentNameDetail;
            this._goodsKindCode = goodsKindCode;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._makerKanaName = makerKanaName;
            this._cmpltMakerKanaName = cmpltMakerKanaName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._goodsLGroup = goodsLGroup;
            this._goodsLGroupName = goodsLGroupName;
            this._goodsMGroup = goodsMGroup;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._stockOrderDivCd = stockOrderDivCd;
            this._openPriceDiv = openPriceDiv;
            this._goodsRateRank = goodsRateRank;
            this._custRateGrpCode = custRateGrpCode;
            this._suppRateGrpCode = suppRateGrpCode;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._listPriceTaxIncFl = listPriceTaxIncFl;
            this._stockRate = stockRate;
            this._rateSectStckUnPrc = rateSectStckUnPrc;
            this._rateDivStckUnPrc = rateDivStckUnPrc;
            this._unPrcCalcCdStckUnPrc = unPrcCalcCdStckUnPrc;
            this._priceCdStckUnPrc = priceCdStckUnPrc;
            this._stdUnPrcStckUnPrc = stdUnPrcStckUnPrc;
            this._fracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
            this._fracProcStckUnPrc = fracProcStckUnPrc;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._stockUnitTaxPriceFl = stockUnitTaxPriceFl;
            this._stockUnitChngDiv = stockUnitChngDiv;
            this._bfStockUnitPriceFl = bfStockUnitPriceFl;
            this._bfListPrice = bfListPrice;
            this._rateBLGoodsCode = rateBLGoodsCode;
            this._rateBLGoodsName = rateBLGoodsName;
            this._rateGoodsRateGrpCd = rateGoodsRateGrpCd;
            this._rateGoodsRateGrpNm = rateGoodsRateGrpNm;
            this._rateBLGroupCode = rateBLGroupCode;
            this._rateBLGroupName = rateBLGroupName;
            this._stockCount = stockCount;
            this._orderCnt = orderCnt;
            this._orderAdjustCnt = orderAdjustCnt;
            this._orderRemainCnt = orderRemainCnt;
            this.RemainCntUpdDate = remainCntUpdDate;
            this._stockPriceTaxExc = stockPriceTaxExc;
            this._stockPriceTaxInc = stockPriceTaxInc;
            this._stockGoodsCdDetail = stockGoodsCdDetail;
            this._stockPriceConsTaxDetail = stockPriceConsTaxDetail;
            this._taxationCode = taxationCode;
            this._stockDtiSlipNote1 = stockDtiSlipNote1;
            this._salesCustomerCode = salesCustomerCode;
            this._salesCustomerSnm = salesCustomerSnm;
            this._slipMemo1 = slipMemo1;
            this._slipMemo2 = slipMemo2;
            this._slipMemo3 = slipMemo3;
            this._insideMemo1 = insideMemo1;
            this._insideMemo2 = insideMemo2;
            this._insideMemo3 = insideMemo3;
            this._supplierCdDetail = supplierCdDetail;
            this._supplierSnmDetail = supplierSnmDetail;
            this._addresseeCodeDetail = addresseeCodeDetail;
            this._addresseeNameDetail = addresseeNameDetail;
            this._directSendingCdDetail = directSendingCdDetail;
            this._orderNumber = orderNumber;
            this._wayToOrder = wayToOrder;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this.ExpectDeliveryDate = expectDeliveryDate;
            this._orderDataCreateDiv = orderDataCreateDiv;
            this.OrderDataCreateDate = orderDataCreateDate;
            this._orderFormIssuedDiv = orderFormIssuedDiv;
            this._totalDay = totalDay;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._addUpEnableCnt = addUpEnableCnt;
            this._alreadyAddUpCnt = alreadyAddUpCnt;
            this._editStatus = editStatus;
            this._dtlRelationGuid = dtlRelationGuid;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._stockSectionNm = stockSectionNm;
            this._stockAddUpSectionNm = stockAddUpSectionNm;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// �d�����i���d���������́j��������
        /// </summary>
        /// <returns>StockTemp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockTemp�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTemp Clone()
        {
            return new StockTemp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierFormal, this._supplierSlipNo, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSuppSlipNo, this._supplierSlipCd, this._stockGoodsCd, this._accPayDivCd, this._stockSectionCd, this._stockAddUpSectionCd, this._stockSlipUpdateCd, this._inputDay, this._arrivalGoodsDay, this._stockDate, this._stockAddUpADate, this._delayPaymentDiv, this._payeeCode, this._payeeSnm, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._businessTypeCode, this._businessTypeName, this._salesAreaCode, this._salesAreaName, this._stockInputCode, this._stockInputName, this._stockAgentCode, this._stockAgentName, this._suppTtlAmntDspWayCd, this._ttlAmntDispRateApy, this._stockTotalPrice, this._stockSubttlPrice, this._stockTtlPricTaxInc, this._stockTtlPricTaxExc, this._stockNetPrice, this._stockPriceConsTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._stockOutTax, this._stckPrcConsTaxInclu, this._stckDisTtlTaxExc, this._itdedStockDisOutTax, this._itdedStockDisInTax, this._itdedStockDisTaxFre, this._stockDisOutTax, this._stckDisTtlTaxInclu, this._taxAdjust, this._balanceAdjust, this._suppCTaxLayCd, this._supplierConsTaxRate, this._accPayConsTax, this._stockFractionProcCd, this._autoPayment, this._autoPaySlipNum, this._retGoodsReasonDiv, this._retGoodsReason, this._partySaleSlipNum, this._supplierSlipNote1, this._supplierSlipNote2, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._stockSlipPrintDate, this._slipPrtSetPaperId, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._directSendingCd, this._acceptAnOrderNo, this._supplierFormalDetail, this._supplierSlipNoDetail, this._stockRowNo, this._sectionCodeDetail, this._subSectionCodeDetail, this._commonSeqNo, this._stockSlipDtlNum, this._supplierFormalSrc, this._stockSlipDtlNumSrc, this._acptAnOdrStatusSync, this._salesSlipDtlNumSync, this._stockSlipCdDtl, this._stockInputCodeDetail, this._stockInputNameDetail, this._stockAgentCodeDetail, this._stockAgentNameDetail, this._goodsKindCode, this._goodsMakerCd, this._makerName, this._makerKanaName, this._cmpltMakerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._stockOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._suppRateGrpCode, this._listPriceTaxExcFl, this._listPriceTaxIncFl, this._stockRate, this._rateSectStckUnPrc, this._rateDivStckUnPrc, this._unPrcCalcCdStckUnPrc, this._priceCdStckUnPrc, this._stdUnPrcStckUnPrc, this._fracProcUnitStcUnPrc, this._fracProcStckUnPrc, this._stockUnitPriceFl, this._stockUnitTaxPriceFl, this._stockUnitChngDiv, this._bfStockUnitPriceFl, this._bfListPrice, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._stockCount, this._orderCnt, this._orderAdjustCnt, this._orderRemainCnt, this._remainCntUpdDate, this._stockPriceTaxExc, this._stockPriceTaxInc, this._stockGoodsCdDetail, this._stockPriceConsTaxDetail, this._taxationCode, this._stockDtiSlipNote1, this._salesCustomerCode, this._salesCustomerSnm, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._supplierCdDetail, this._supplierSnmDetail, this._addresseeCodeDetail, this._addresseeNameDetail, this._directSendingCdDetail, this._orderNumber, this._wayToOrder, this._deliGdsCmpltDueDate, this._expectDeliveryDate, this._orderDataCreateDiv, this._orderDataCreateDate, this._orderFormIssuedDiv, this._totalDay, this._nTimeCalcStDate, this._payeeName, this._payeeName2, this._addUpEnableCnt, this._alreadyAddUpCnt, this._editStatus, this._dtlRelationGuid, this._enterpriseName, this._updEmployeeName, this._stockSectionNm, this._stockAddUpSectionNm, this._suppCTaxLayMethodNm, this._bLGoodsName);
        }

        /// <summary>
        /// �d�����i���d���������́j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockTemp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTemp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockTemp target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                 && (this.DebitNLnkSuppSlipNo == target.DebitNLnkSuppSlipNo)
                 && (this.SupplierSlipCd == target.SupplierSlipCd)
                 && (this.StockGoodsCd == target.StockGoodsCd)
                 && (this.AccPayDivCd == target.AccPayDivCd)
                 && (this.StockSectionCd == target.StockSectionCd)
                 && (this.StockAddUpSectionCd == target.StockAddUpSectionCd)
                 && (this.StockSlipUpdateCd == target.StockSlipUpdateCd)
                 && (this.InputDay == target.InputDay)
                 && (this.ArrivalGoodsDay == target.ArrivalGoodsDay)
                 && (this.StockDate == target.StockDate)
                 && (this.StockAddUpADate == target.StockAddUpADate)
                 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.PayeeSnm == target.PayeeSnm)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierNm2 == target.SupplierNm2)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.StockInputCode == target.StockInputCode)
                 && (this.StockInputName == target.StockInputName)
                 && (this.StockAgentCode == target.StockAgentCode)
                 && (this.StockAgentName == target.StockAgentName)
                 && (this.SuppTtlAmntDspWayCd == target.SuppTtlAmntDspWayCd)
                 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
                 && (this.StockTotalPrice == target.StockTotalPrice)
                 && (this.StockSubttlPrice == target.StockSubttlPrice)
                 && (this.StockTtlPricTaxInc == target.StockTtlPricTaxInc)
                 && (this.StockTtlPricTaxExc == target.StockTtlPricTaxExc)
                 && (this.StockNetPrice == target.StockNetPrice)
                 && (this.StockPriceConsTax == target.StockPriceConsTax)
                 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
                 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
                 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
                 && (this.StockOutTax == target.StockOutTax)
                 && (this.StckPrcConsTaxInclu == target.StckPrcConsTaxInclu)
                 && (this.StckDisTtlTaxExc == target.StckDisTtlTaxExc)
                 && (this.ItdedStockDisOutTax == target.ItdedStockDisOutTax)
                 && (this.ItdedStockDisInTax == target.ItdedStockDisInTax)
                 && (this.ItdedStockDisTaxFre == target.ItdedStockDisTaxFre)
                 && (this.StockDisOutTax == target.StockDisOutTax)
                 && (this.StckDisTtlTaxInclu == target.StckDisTtlTaxInclu)
                 && (this.TaxAdjust == target.TaxAdjust)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
                 && (this.AccPayConsTax == target.AccPayConsTax)
                 && (this.StockFractionProcCd == target.StockFractionProcCd)
                 && (this.AutoPayment == target.AutoPayment)
                 && (this.AutoPaySlipNum == target.AutoPaySlipNum)
                 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
                 && (this.RetGoodsReason == target.RetGoodsReason)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.SupplierSlipNote1 == target.SupplierSlipNote1)
                 && (this.SupplierSlipNote2 == target.SupplierSlipNote2)
                 && (this.DetailRowCount == target.DetailRowCount)
                 && (this.EdiSendDate == target.EdiSendDate)
                 && (this.EdiTakeInDate == target.EdiTakeInDate)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SlipPrintDivCd == target.SlipPrintDivCd)
                 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
                 && (this.StockSlipPrintDate == target.StockSlipPrintDate)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.SlipAddressDiv == target.SlipAddressDiv)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.AddresseeName == target.AddresseeName)
                 && (this.AddresseeName2 == target.AddresseeName2)
                 && (this.AddresseePostNo == target.AddresseePostNo)
                 && (this.AddresseeAddr1 == target.AddresseeAddr1)
                 && (this.AddresseeAddr3 == target.AddresseeAddr3)
                 && (this.AddresseeAddr4 == target.AddresseeAddr4)
                 && (this.AddresseeTelNo == target.AddresseeTelNo)
                 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
                 && (this.DirectSendingCd == target.DirectSendingCd)
                 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
                 && (this.SupplierFormalDetail == target.SupplierFormalDetail)
                 && (this.SupplierSlipNoDetail == target.SupplierSlipNoDetail)
                 && (this.StockRowNo == target.StockRowNo)
                 && (this.SectionCodeDetail == target.SectionCodeDetail)
                 && (this.SubSectionCodeDetail == target.SubSectionCodeDetail)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.SupplierFormalSrc == target.SupplierFormalSrc)
                 && (this.StockSlipDtlNumSrc == target.StockSlipDtlNumSrc)
                 && (this.AcptAnOdrStatusSync == target.AcptAnOdrStatusSync)
                 && (this.SalesSlipDtlNumSync == target.SalesSlipDtlNumSync)
                 && (this.StockSlipCdDtl == target.StockSlipCdDtl)
                 && (this.StockInputCodeDetail == target.StockInputCodeDetail)
                 && (this.StockInputNameDetail == target.StockInputNameDetail)
                 && (this.StockAgentCodeDetail == target.StockAgentCodeDetail)
                 && (this.StockAgentNameDetail == target.StockAgentNameDetail)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.CmpltMakerKanaName == target.CmpltMakerKanaName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsLGroupName == target.GoodsLGroupName)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.StockOrderDivCd == target.StockOrderDivCd)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
                 && (this.StockRate == target.StockRate)
                 && (this.RateSectStckUnPrc == target.RateSectStckUnPrc)
                 && (this.RateDivStckUnPrc == target.RateDivStckUnPrc)
                 && (this.UnPrcCalcCdStckUnPrc == target.UnPrcCalcCdStckUnPrc)
                 && (this.PriceCdStckUnPrc == target.PriceCdStckUnPrc)
                 && (this.StdUnPrcStckUnPrc == target.StdUnPrcStckUnPrc)
                 && (this.FracProcUnitStcUnPrc == target.FracProcUnitStcUnPrc)
                 && (this.FracProcStckUnPrc == target.FracProcStckUnPrc)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.StockUnitTaxPriceFl == target.StockUnitTaxPriceFl)
                 && (this.StockUnitChngDiv == target.StockUnitChngDiv)
                 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
                 && (this.BfListPrice == target.BfListPrice)
                 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
                 && (this.RateBLGoodsName == target.RateBLGoodsName)
                 && (this.RateGoodsRateGrpCd == target.RateGoodsRateGrpCd)
                 && (this.RateGoodsRateGrpNm == target.RateGoodsRateGrpNm)
                 && (this.RateBLGroupCode == target.RateBLGroupCode)
                 && (this.RateBLGroupName == target.RateBLGroupName)
                 && (this.StockCount == target.StockCount)
                 && (this.OrderCnt == target.OrderCnt)
                 && (this.OrderAdjustCnt == target.OrderAdjustCnt)
                 && (this.OrderRemainCnt == target.OrderRemainCnt)
                 && (this.RemainCntUpdDate == target.RemainCntUpdDate)
                 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
                 && (this.StockPriceTaxInc == target.StockPriceTaxInc)
                 && (this.StockGoodsCdDetail == target.StockGoodsCdDetail)
                 && (this.StockPriceConsTaxDetail == target.StockPriceConsTaxDetail)
                 && (this.TaxationCode == target.TaxationCode)
                 && (this.StockDtiSlipNote1 == target.StockDtiSlipNote1)
                 && (this.SalesCustomerCode == target.SalesCustomerCode)
                 && (this.SalesCustomerSnm == target.SalesCustomerSnm)
                 && (this.SlipMemo1 == target.SlipMemo1)
                 && (this.SlipMemo2 == target.SlipMemo2)
                 && (this.SlipMemo3 == target.SlipMemo3)
                 && (this.InsideMemo1 == target.InsideMemo1)
                 && (this.InsideMemo2 == target.InsideMemo2)
                 && (this.InsideMemo3 == target.InsideMemo3)
                 && (this.SupplierCdDetail == target.SupplierCdDetail)
                 && (this.SupplierSnmDetail == target.SupplierSnmDetail)
                 && (this.AddresseeCodeDetail == target.AddresseeCodeDetail)
                 && (this.AddresseeNameDetail == target.AddresseeNameDetail)
                 && (this.DirectSendingCdDetail == target.DirectSendingCdDetail)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.WayToOrder == target.WayToOrder)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.ExpectDeliveryDate == target.ExpectDeliveryDate)
                 && (this.OrderDataCreateDiv == target.OrderDataCreateDiv)
                 && (this.OrderDataCreateDate == target.OrderDataCreateDate)
                 && (this.OrderFormIssuedDiv == target.OrderFormIssuedDiv)
                 && (this.TotalDay == target.TotalDay)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.PayeeName == target.PayeeName)
                 && (this.PayeeName2 == target.PayeeName2)
                 && (this.AddUpEnableCnt == target.AddUpEnableCnt)
                 && (this.AlreadyAddUpCnt == target.AlreadyAddUpCnt)
                 && (this.EditStatus == target.EditStatus)
                 && (this.DtlRelationGuid == target.DtlRelationGuid)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.StockSectionNm == target.StockSectionNm)
                 && (this.StockAddUpSectionNm == target.StockAddUpSectionNm)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// �d�����i���d���������́j��r����
        /// </summary>
        /// <param name="stockTemp1">
        ///                    ��r����StockTemp�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockTemp2">��r����StockTemp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTemp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockTemp stockTemp1, StockTemp stockTemp2)
        {
            return ((stockTemp1.CreateDateTime == stockTemp2.CreateDateTime)
                 && (stockTemp1.UpdateDateTime == stockTemp2.UpdateDateTime)
                 && (stockTemp1.EnterpriseCode == stockTemp2.EnterpriseCode)
                 && (stockTemp1.FileHeaderGuid == stockTemp2.FileHeaderGuid)
                 && (stockTemp1.UpdEmployeeCode == stockTemp2.UpdEmployeeCode)
                 && (stockTemp1.UpdAssemblyId1 == stockTemp2.UpdAssemblyId1)
                 && (stockTemp1.UpdAssemblyId2 == stockTemp2.UpdAssemblyId2)
                 && (stockTemp1.LogicalDeleteCode == stockTemp2.LogicalDeleteCode)
                 && (stockTemp1.SupplierFormal == stockTemp2.SupplierFormal)
                 && (stockTemp1.SupplierSlipNo == stockTemp2.SupplierSlipNo)
                 && (stockTemp1.SectionCode == stockTemp2.SectionCode)
                 && (stockTemp1.SubSectionCode == stockTemp2.SubSectionCode)
                 && (stockTemp1.DebitNoteDiv == stockTemp2.DebitNoteDiv)
                 && (stockTemp1.DebitNLnkSuppSlipNo == stockTemp2.DebitNLnkSuppSlipNo)
                 && (stockTemp1.SupplierSlipCd == stockTemp2.SupplierSlipCd)
                 && (stockTemp1.StockGoodsCd == stockTemp2.StockGoodsCd)
                 && (stockTemp1.AccPayDivCd == stockTemp2.AccPayDivCd)
                 && (stockTemp1.StockSectionCd == stockTemp2.StockSectionCd)
                 && (stockTemp1.StockAddUpSectionCd == stockTemp2.StockAddUpSectionCd)
                 && (stockTemp1.StockSlipUpdateCd == stockTemp2.StockSlipUpdateCd)
                 && (stockTemp1.InputDay == stockTemp2.InputDay)
                 && (stockTemp1.ArrivalGoodsDay == stockTemp2.ArrivalGoodsDay)
                 && (stockTemp1.StockDate == stockTemp2.StockDate)
                 && (stockTemp1.StockAddUpADate == stockTemp2.StockAddUpADate)
                 && (stockTemp1.DelayPaymentDiv == stockTemp2.DelayPaymentDiv)
                 && (stockTemp1.PayeeCode == stockTemp2.PayeeCode)
                 && (stockTemp1.PayeeSnm == stockTemp2.PayeeSnm)
                 && (stockTemp1.SupplierCd == stockTemp2.SupplierCd)
                 && (stockTemp1.SupplierNm1 == stockTemp2.SupplierNm1)
                 && (stockTemp1.SupplierNm2 == stockTemp2.SupplierNm2)
                 && (stockTemp1.SupplierSnm == stockTemp2.SupplierSnm)
                 && (stockTemp1.BusinessTypeCode == stockTemp2.BusinessTypeCode)
                 && (stockTemp1.BusinessTypeName == stockTemp2.BusinessTypeName)
                 && (stockTemp1.SalesAreaCode == stockTemp2.SalesAreaCode)
                 && (stockTemp1.SalesAreaName == stockTemp2.SalesAreaName)
                 && (stockTemp1.StockInputCode == stockTemp2.StockInputCode)
                 && (stockTemp1.StockInputName == stockTemp2.StockInputName)
                 && (stockTemp1.StockAgentCode == stockTemp2.StockAgentCode)
                 && (stockTemp1.StockAgentName == stockTemp2.StockAgentName)
                 && (stockTemp1.SuppTtlAmntDspWayCd == stockTemp2.SuppTtlAmntDspWayCd)
                 && (stockTemp1.TtlAmntDispRateApy == stockTemp2.TtlAmntDispRateApy)
                 && (stockTemp1.StockTotalPrice == stockTemp2.StockTotalPrice)
                 && (stockTemp1.StockSubttlPrice == stockTemp2.StockSubttlPrice)
                 && (stockTemp1.StockTtlPricTaxInc == stockTemp2.StockTtlPricTaxInc)
                 && (stockTemp1.StockTtlPricTaxExc == stockTemp2.StockTtlPricTaxExc)
                 && (stockTemp1.StockNetPrice == stockTemp2.StockNetPrice)
                 && (stockTemp1.StockPriceConsTax == stockTemp2.StockPriceConsTax)
                 && (stockTemp1.TtlItdedStcOutTax == stockTemp2.TtlItdedStcOutTax)
                 && (stockTemp1.TtlItdedStcInTax == stockTemp2.TtlItdedStcInTax)
                 && (stockTemp1.TtlItdedStcTaxFree == stockTemp2.TtlItdedStcTaxFree)
                 && (stockTemp1.StockOutTax == stockTemp2.StockOutTax)
                 && (stockTemp1.StckPrcConsTaxInclu == stockTemp2.StckPrcConsTaxInclu)
                 && (stockTemp1.StckDisTtlTaxExc == stockTemp2.StckDisTtlTaxExc)
                 && (stockTemp1.ItdedStockDisOutTax == stockTemp2.ItdedStockDisOutTax)
                 && (stockTemp1.ItdedStockDisInTax == stockTemp2.ItdedStockDisInTax)
                 && (stockTemp1.ItdedStockDisTaxFre == stockTemp2.ItdedStockDisTaxFre)
                 && (stockTemp1.StockDisOutTax == stockTemp2.StockDisOutTax)
                 && (stockTemp1.StckDisTtlTaxInclu == stockTemp2.StckDisTtlTaxInclu)
                 && (stockTemp1.TaxAdjust == stockTemp2.TaxAdjust)
                 && (stockTemp1.BalanceAdjust == stockTemp2.BalanceAdjust)
                 && (stockTemp1.SuppCTaxLayCd == stockTemp2.SuppCTaxLayCd)
                 && (stockTemp1.SupplierConsTaxRate == stockTemp2.SupplierConsTaxRate)
                 && (stockTemp1.AccPayConsTax == stockTemp2.AccPayConsTax)
                 && (stockTemp1.StockFractionProcCd == stockTemp2.StockFractionProcCd)
                 && (stockTemp1.AutoPayment == stockTemp2.AutoPayment)
                 && (stockTemp1.AutoPaySlipNum == stockTemp2.AutoPaySlipNum)
                 && (stockTemp1.RetGoodsReasonDiv == stockTemp2.RetGoodsReasonDiv)
                 && (stockTemp1.RetGoodsReason == stockTemp2.RetGoodsReason)
                 && (stockTemp1.PartySaleSlipNum == stockTemp2.PartySaleSlipNum)
                 && (stockTemp1.SupplierSlipNote1 == stockTemp2.SupplierSlipNote1)
                 && (stockTemp1.SupplierSlipNote2 == stockTemp2.SupplierSlipNote2)
                 && (stockTemp1.DetailRowCount == stockTemp2.DetailRowCount)
                 && (stockTemp1.EdiSendDate == stockTemp2.EdiSendDate)
                 && (stockTemp1.EdiTakeInDate == stockTemp2.EdiTakeInDate)
                 && (stockTemp1.UoeRemark1 == stockTemp2.UoeRemark1)
                 && (stockTemp1.UoeRemark2 == stockTemp2.UoeRemark2)
                 && (stockTemp1.SlipPrintDivCd == stockTemp2.SlipPrintDivCd)
                 && (stockTemp1.SlipPrintFinishCd == stockTemp2.SlipPrintFinishCd)
                 && (stockTemp1.StockSlipPrintDate == stockTemp2.StockSlipPrintDate)
                 && (stockTemp1.SlipPrtSetPaperId == stockTemp2.SlipPrtSetPaperId)
                 && (stockTemp1.SlipAddressDiv == stockTemp2.SlipAddressDiv)
                 && (stockTemp1.AddresseeCode == stockTemp2.AddresseeCode)
                 && (stockTemp1.AddresseeName == stockTemp2.AddresseeName)
                 && (stockTemp1.AddresseeName2 == stockTemp2.AddresseeName2)
                 && (stockTemp1.AddresseePostNo == stockTemp2.AddresseePostNo)
                 && (stockTemp1.AddresseeAddr1 == stockTemp2.AddresseeAddr1)
                 && (stockTemp1.AddresseeAddr3 == stockTemp2.AddresseeAddr3)
                 && (stockTemp1.AddresseeAddr4 == stockTemp2.AddresseeAddr4)
                 && (stockTemp1.AddresseeTelNo == stockTemp2.AddresseeTelNo)
                 && (stockTemp1.AddresseeFaxNo == stockTemp2.AddresseeFaxNo)
                 && (stockTemp1.DirectSendingCd == stockTemp2.DirectSendingCd)
                 && (stockTemp1.AcceptAnOrderNo == stockTemp2.AcceptAnOrderNo)
                 && (stockTemp1.SupplierFormalDetail == stockTemp2.SupplierFormalDetail)
                 && (stockTemp1.SupplierSlipNoDetail == stockTemp2.SupplierSlipNoDetail)
                 && (stockTemp1.StockRowNo == stockTemp2.StockRowNo)
                 && (stockTemp1.SectionCodeDetail == stockTemp2.SectionCodeDetail)
                 && (stockTemp1.SubSectionCodeDetail == stockTemp2.SubSectionCodeDetail)
                 && (stockTemp1.CommonSeqNo == stockTemp2.CommonSeqNo)
                 && (stockTemp1.StockSlipDtlNum == stockTemp2.StockSlipDtlNum)
                 && (stockTemp1.SupplierFormalSrc == stockTemp2.SupplierFormalSrc)
                 && (stockTemp1.StockSlipDtlNumSrc == stockTemp2.StockSlipDtlNumSrc)
                 && (stockTemp1.AcptAnOdrStatusSync == stockTemp2.AcptAnOdrStatusSync)
                 && (stockTemp1.SalesSlipDtlNumSync == stockTemp2.SalesSlipDtlNumSync)
                 && (stockTemp1.StockSlipCdDtl == stockTemp2.StockSlipCdDtl)
                 && (stockTemp1.StockInputCodeDetail == stockTemp2.StockInputCodeDetail)
                 && (stockTemp1.StockInputNameDetail == stockTemp2.StockInputNameDetail)
                 && (stockTemp1.StockAgentCodeDetail == stockTemp2.StockAgentCodeDetail)
                 && (stockTemp1.StockAgentNameDetail == stockTemp2.StockAgentNameDetail)
                 && (stockTemp1.GoodsKindCode == stockTemp2.GoodsKindCode)
                 && (stockTemp1.GoodsMakerCd == stockTemp2.GoodsMakerCd)
                 && (stockTemp1.MakerName == stockTemp2.MakerName)
                 && (stockTemp1.MakerKanaName == stockTemp2.MakerKanaName)
                 && (stockTemp1.CmpltMakerKanaName == stockTemp2.CmpltMakerKanaName)
                 && (stockTemp1.GoodsNo == stockTemp2.GoodsNo)
                 && (stockTemp1.GoodsName == stockTemp2.GoodsName)
                 && (stockTemp1.GoodsNameKana == stockTemp2.GoodsNameKana)
                 && (stockTemp1.GoodsLGroup == stockTemp2.GoodsLGroup)
                 && (stockTemp1.GoodsLGroupName == stockTemp2.GoodsLGroupName)
                 && (stockTemp1.GoodsMGroup == stockTemp2.GoodsMGroup)
                 && (stockTemp1.GoodsMGroupName == stockTemp2.GoodsMGroupName)
                 && (stockTemp1.BLGroupCode == stockTemp2.BLGroupCode)
                 && (stockTemp1.BLGroupName == stockTemp2.BLGroupName)
                 && (stockTemp1.BLGoodsCode == stockTemp2.BLGoodsCode)
                 && (stockTemp1.BLGoodsFullName == stockTemp2.BLGoodsFullName)
                 && (stockTemp1.EnterpriseGanreCode == stockTemp2.EnterpriseGanreCode)
                 && (stockTemp1.EnterpriseGanreName == stockTemp2.EnterpriseGanreName)
                 && (stockTemp1.WarehouseCode == stockTemp2.WarehouseCode)
                 && (stockTemp1.WarehouseName == stockTemp2.WarehouseName)
                 && (stockTemp1.WarehouseShelfNo == stockTemp2.WarehouseShelfNo)
                 && (stockTemp1.StockOrderDivCd == stockTemp2.StockOrderDivCd)
                 && (stockTemp1.OpenPriceDiv == stockTemp2.OpenPriceDiv)
                 && (stockTemp1.GoodsRateRank == stockTemp2.GoodsRateRank)
                 && (stockTemp1.CustRateGrpCode == stockTemp2.CustRateGrpCode)
                 && (stockTemp1.SuppRateGrpCode == stockTemp2.SuppRateGrpCode)
                 && (stockTemp1.ListPriceTaxExcFl == stockTemp2.ListPriceTaxExcFl)
                 && (stockTemp1.ListPriceTaxIncFl == stockTemp2.ListPriceTaxIncFl)
                 && (stockTemp1.StockRate == stockTemp2.StockRate)
                 && (stockTemp1.RateSectStckUnPrc == stockTemp2.RateSectStckUnPrc)
                 && (stockTemp1.RateDivStckUnPrc == stockTemp2.RateDivStckUnPrc)
                 && (stockTemp1.UnPrcCalcCdStckUnPrc == stockTemp2.UnPrcCalcCdStckUnPrc)
                 && (stockTemp1.PriceCdStckUnPrc == stockTemp2.PriceCdStckUnPrc)
                 && (stockTemp1.StdUnPrcStckUnPrc == stockTemp2.StdUnPrcStckUnPrc)
                 && (stockTemp1.FracProcUnitStcUnPrc == stockTemp2.FracProcUnitStcUnPrc)
                 && (stockTemp1.FracProcStckUnPrc == stockTemp2.FracProcStckUnPrc)
                 && (stockTemp1.StockUnitPriceFl == stockTemp2.StockUnitPriceFl)
                 && (stockTemp1.StockUnitTaxPriceFl == stockTemp2.StockUnitTaxPriceFl)
                 && (stockTemp1.StockUnitChngDiv == stockTemp2.StockUnitChngDiv)
                 && (stockTemp1.BfStockUnitPriceFl == stockTemp2.BfStockUnitPriceFl)
                 && (stockTemp1.BfListPrice == stockTemp2.BfListPrice)
                 && (stockTemp1.RateBLGoodsCode == stockTemp2.RateBLGoodsCode)
                 && (stockTemp1.RateBLGoodsName == stockTemp2.RateBLGoodsName)
                 && (stockTemp1.RateGoodsRateGrpCd == stockTemp2.RateGoodsRateGrpCd)
                 && (stockTemp1.RateGoodsRateGrpNm == stockTemp2.RateGoodsRateGrpNm)
                 && (stockTemp1.RateBLGroupCode == stockTemp2.RateBLGroupCode)
                 && (stockTemp1.RateBLGroupName == stockTemp2.RateBLGroupName)
                 && (stockTemp1.StockCount == stockTemp2.StockCount)
                 && (stockTemp1.OrderCnt == stockTemp2.OrderCnt)
                 && (stockTemp1.OrderAdjustCnt == stockTemp2.OrderAdjustCnt)
                 && (stockTemp1.OrderRemainCnt == stockTemp2.OrderRemainCnt)
                 && (stockTemp1.RemainCntUpdDate == stockTemp2.RemainCntUpdDate)
                 && (stockTemp1.StockPriceTaxExc == stockTemp2.StockPriceTaxExc)
                 && (stockTemp1.StockPriceTaxInc == stockTemp2.StockPriceTaxInc)
                 && (stockTemp1.StockGoodsCdDetail == stockTemp2.StockGoodsCdDetail)
                 && (stockTemp1.StockPriceConsTaxDetail == stockTemp2.StockPriceConsTaxDetail)
                 && (stockTemp1.TaxationCode == stockTemp2.TaxationCode)
                 && (stockTemp1.StockDtiSlipNote1 == stockTemp2.StockDtiSlipNote1)
                 && (stockTemp1.SalesCustomerCode == stockTemp2.SalesCustomerCode)
                 && (stockTemp1.SalesCustomerSnm == stockTemp2.SalesCustomerSnm)
                 && (stockTemp1.SlipMemo1 == stockTemp2.SlipMemo1)
                 && (stockTemp1.SlipMemo2 == stockTemp2.SlipMemo2)
                 && (stockTemp1.SlipMemo3 == stockTemp2.SlipMemo3)
                 && (stockTemp1.InsideMemo1 == stockTemp2.InsideMemo1)
                 && (stockTemp1.InsideMemo2 == stockTemp2.InsideMemo2)
                 && (stockTemp1.InsideMemo3 == stockTemp2.InsideMemo3)
                 && (stockTemp1.SupplierCdDetail == stockTemp2.SupplierCdDetail)
                 && (stockTemp1.SupplierSnmDetail == stockTemp2.SupplierSnmDetail)
                 && (stockTemp1.AddresseeCodeDetail == stockTemp2.AddresseeCodeDetail)
                 && (stockTemp1.AddresseeNameDetail == stockTemp2.AddresseeNameDetail)
                 && (stockTemp1.DirectSendingCdDetail == stockTemp2.DirectSendingCdDetail)
                 && (stockTemp1.OrderNumber == stockTemp2.OrderNumber)
                 && (stockTemp1.WayToOrder == stockTemp2.WayToOrder)
                 && (stockTemp1.DeliGdsCmpltDueDate == stockTemp2.DeliGdsCmpltDueDate)
                 && (stockTemp1.ExpectDeliveryDate == stockTemp2.ExpectDeliveryDate)
                 && (stockTemp1.OrderDataCreateDiv == stockTemp2.OrderDataCreateDiv)
                 && (stockTemp1.OrderDataCreateDate == stockTemp2.OrderDataCreateDate)
                 && (stockTemp1.OrderFormIssuedDiv == stockTemp2.OrderFormIssuedDiv)
                 && (stockTemp1.TotalDay == stockTemp2.TotalDay)
                 && (stockTemp1.NTimeCalcStDate == stockTemp2.NTimeCalcStDate)
                 && (stockTemp1.PayeeName == stockTemp2.PayeeName)
                 && (stockTemp1.PayeeName2 == stockTemp2.PayeeName2)
                 && (stockTemp1.AddUpEnableCnt == stockTemp2.AddUpEnableCnt)
                 && (stockTemp1.AlreadyAddUpCnt == stockTemp2.AlreadyAddUpCnt)
                 && (stockTemp1.EditStatus == stockTemp2.EditStatus)
                 && (stockTemp1.DtlRelationGuid == stockTemp2.DtlRelationGuid)
                 && (stockTemp1.EnterpriseName == stockTemp2.EnterpriseName)
                 && (stockTemp1.UpdEmployeeName == stockTemp2.UpdEmployeeName)
                 && (stockTemp1.StockSectionNm == stockTemp2.StockSectionNm)
                 && (stockTemp1.StockAddUpSectionNm == stockTemp2.StockAddUpSectionNm)
                 && (stockTemp1.SuppCTaxLayMethodNm == stockTemp2.SuppCTaxLayMethodNm)
                 && (stockTemp1.BLGoodsName == stockTemp2.BLGoodsName));
        }
        /// <summary>
        /// �d�����i���d���������́j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockTemp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTemp�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockTemp target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.DebitNLnkSuppSlipNo != target.DebitNLnkSuppSlipNo) resList.Add("DebitNLnkSuppSlipNo");
            if (this.SupplierSlipCd != target.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (this.StockGoodsCd != target.StockGoodsCd) resList.Add("StockGoodsCd");
            if (this.AccPayDivCd != target.AccPayDivCd) resList.Add("AccPayDivCd");
            if (this.StockSectionCd != target.StockSectionCd) resList.Add("StockSectionCd");
            if (this.StockAddUpSectionCd != target.StockAddUpSectionCd) resList.Add("StockAddUpSectionCd");
            if (this.StockSlipUpdateCd != target.StockSlipUpdateCd) resList.Add("StockSlipUpdateCd");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.ArrivalGoodsDay != target.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (this.StockDate != target.StockDate) resList.Add("StockDate");
            if (this.StockAddUpADate != target.StockAddUpADate) resList.Add("StockAddUpADate");
            if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.StockInputCode != target.StockInputCode) resList.Add("StockInputCode");
            if (this.StockInputName != target.StockInputName) resList.Add("StockInputName");
            if (this.StockAgentCode != target.StockAgentCode) resList.Add("StockAgentCode");
            if (this.StockAgentName != target.StockAgentName) resList.Add("StockAgentName");
            if (this.SuppTtlAmntDspWayCd != target.SuppTtlAmntDspWayCd) resList.Add("SuppTtlAmntDspWayCd");
            if (this.TtlAmntDispRateApy != target.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (this.StockTotalPrice != target.StockTotalPrice) resList.Add("StockTotalPrice");
            if (this.StockSubttlPrice != target.StockSubttlPrice) resList.Add("StockSubttlPrice");
            if (this.StockTtlPricTaxInc != target.StockTtlPricTaxInc) resList.Add("StockTtlPricTaxInc");
            if (this.StockTtlPricTaxExc != target.StockTtlPricTaxExc) resList.Add("StockTtlPricTaxExc");
            if (this.StockNetPrice != target.StockNetPrice) resList.Add("StockNetPrice");
            if (this.StockPriceConsTax != target.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (this.TtlItdedStcOutTax != target.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (this.TtlItdedStcInTax != target.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (this.StockOutTax != target.StockOutTax) resList.Add("StockOutTax");
            if (this.StckPrcConsTaxInclu != target.StckPrcConsTaxInclu) resList.Add("StckPrcConsTaxInclu");
            if (this.StckDisTtlTaxExc != target.StckDisTtlTaxExc) resList.Add("StckDisTtlTaxExc");
            if (this.ItdedStockDisOutTax != target.ItdedStockDisOutTax) resList.Add("ItdedStockDisOutTax");
            if (this.ItdedStockDisInTax != target.ItdedStockDisInTax) resList.Add("ItdedStockDisInTax");
            if (this.ItdedStockDisTaxFre != target.ItdedStockDisTaxFre) resList.Add("ItdedStockDisTaxFre");
            if (this.StockDisOutTax != target.StockDisOutTax) resList.Add("StockDisOutTax");
            if (this.StckDisTtlTaxInclu != target.StckDisTtlTaxInclu) resList.Add("StckDisTtlTaxInclu");
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (this.SupplierConsTaxRate != target.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (this.AccPayConsTax != target.AccPayConsTax) resList.Add("AccPayConsTax");
            if (this.StockFractionProcCd != target.StockFractionProcCd) resList.Add("StockFractionProcCd");
            if (this.AutoPayment != target.AutoPayment) resList.Add("AutoPayment");
            if (this.AutoPaySlipNum != target.AutoPaySlipNum) resList.Add("AutoPaySlipNum");
            if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.SupplierSlipNote1 != target.SupplierSlipNote1) resList.Add("SupplierSlipNote1");
            if (this.SupplierSlipNote2 != target.SupplierSlipNote2) resList.Add("SupplierSlipNote2");
            if (this.DetailRowCount != target.DetailRowCount) resList.Add("DetailRowCount");
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.SlipPrintDivCd != target.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (this.StockSlipPrintDate != target.StockSlipPrintDate) resList.Add("StockSlipPrintDate");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
            if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (this.DirectSendingCd != target.DirectSendingCd) resList.Add("DirectSendingCd");
            if (this.AcceptAnOrderNo != target.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (this.SupplierFormalDetail != target.SupplierFormalDetail) resList.Add("SupplierFormalDetail");
            if (this.SupplierSlipNoDetail != target.SupplierSlipNoDetail) resList.Add("SupplierSlipNoDetail");
            if (this.StockRowNo != target.StockRowNo) resList.Add("StockRowNo");
            if (this.SectionCodeDetail != target.SectionCodeDetail) resList.Add("SectionCodeDetail");
            if (this.SubSectionCodeDetail != target.SubSectionCodeDetail) resList.Add("SubSectionCodeDetail");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.SupplierFormalSrc != target.SupplierFormalSrc) resList.Add("SupplierFormalSrc");
            if (this.StockSlipDtlNumSrc != target.StockSlipDtlNumSrc) resList.Add("StockSlipDtlNumSrc");
            if (this.AcptAnOdrStatusSync != target.AcptAnOdrStatusSync) resList.Add("AcptAnOdrStatusSync");
            if (this.SalesSlipDtlNumSync != target.SalesSlipDtlNumSync) resList.Add("SalesSlipDtlNumSync");
            if (this.StockSlipCdDtl != target.StockSlipCdDtl) resList.Add("StockSlipCdDtl");
            if (this.StockInputCodeDetail != target.StockInputCodeDetail) resList.Add("StockInputCodeDetail");
            if (this.StockInputNameDetail != target.StockInputNameDetail) resList.Add("StockInputNameDetail");
            if (this.StockAgentCodeDetail != target.StockAgentCodeDetail) resList.Add("StockAgentCodeDetail");
            if (this.StockAgentNameDetail != target.StockAgentNameDetail) resList.Add("StockAgentNameDetail");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.MakerKanaName != target.MakerKanaName) resList.Add("MakerKanaName");
            if (this.CmpltMakerKanaName != target.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsLGroupName != target.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.StockOrderDivCd != target.StockOrderDivCd) resList.Add("StockOrderDivCd");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SuppRateGrpCode != target.SuppRateGrpCode) resList.Add("SuppRateGrpCode");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.ListPriceTaxIncFl != target.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (this.StockRate != target.StockRate) resList.Add("StockRate");
            if (this.RateSectStckUnPrc != target.RateSectStckUnPrc) resList.Add("RateSectStckUnPrc");
            if (this.RateDivStckUnPrc != target.RateDivStckUnPrc) resList.Add("RateDivStckUnPrc");
            if (this.UnPrcCalcCdStckUnPrc != target.UnPrcCalcCdStckUnPrc) resList.Add("UnPrcCalcCdStckUnPrc");
            if (this.PriceCdStckUnPrc != target.PriceCdStckUnPrc) resList.Add("PriceCdStckUnPrc");
            if (this.StdUnPrcStckUnPrc != target.StdUnPrcStckUnPrc) resList.Add("StdUnPrcStckUnPrc");
            if (this.FracProcUnitStcUnPrc != target.FracProcUnitStcUnPrc) resList.Add("FracProcUnitStcUnPrc");
            if (this.FracProcStckUnPrc != target.FracProcStckUnPrc) resList.Add("FracProcStckUnPrc");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.StockUnitTaxPriceFl != target.StockUnitTaxPriceFl) resList.Add("StockUnitTaxPriceFl");
            if (this.StockUnitChngDiv != target.StockUnitChngDiv) resList.Add("StockUnitChngDiv");
            if (this.BfStockUnitPriceFl != target.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (this.BfListPrice != target.BfListPrice) resList.Add("BfListPrice");
            if (this.RateBLGoodsCode != target.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (this.RateBLGoodsName != target.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (this.RateGoodsRateGrpCd != target.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (this.RateGoodsRateGrpNm != target.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (this.RateBLGroupCode != target.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (this.RateBLGroupName != target.RateBLGroupName) resList.Add("RateBLGroupName");
            if (this.StockCount != target.StockCount) resList.Add("StockCount");
            if (this.OrderCnt != target.OrderCnt) resList.Add("OrderCnt");
            if (this.OrderAdjustCnt != target.OrderAdjustCnt) resList.Add("OrderAdjustCnt");
            if (this.OrderRemainCnt != target.OrderRemainCnt) resList.Add("OrderRemainCnt");
            if (this.RemainCntUpdDate != target.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (this.StockPriceTaxExc != target.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (this.StockPriceTaxInc != target.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (this.StockGoodsCdDetail != target.StockGoodsCdDetail) resList.Add("StockGoodsCdDetail");
            if (this.StockPriceConsTaxDetail != target.StockPriceConsTaxDetail) resList.Add("StockPriceConsTaxDetail");
            if (this.TaxationCode != target.TaxationCode) resList.Add("TaxationCode");
            if (this.StockDtiSlipNote1 != target.StockDtiSlipNote1) resList.Add("StockDtiSlipNote1");
            if (this.SalesCustomerCode != target.SalesCustomerCode) resList.Add("SalesCustomerCode");
            if (this.SalesCustomerSnm != target.SalesCustomerSnm) resList.Add("SalesCustomerSnm");
            if (this.SlipMemo1 != target.SlipMemo1) resList.Add("SlipMemo1");
            if (this.SlipMemo2 != target.SlipMemo2) resList.Add("SlipMemo2");
            if (this.SlipMemo3 != target.SlipMemo3) resList.Add("SlipMemo3");
            if (this.InsideMemo1 != target.InsideMemo1) resList.Add("InsideMemo1");
            if (this.InsideMemo2 != target.InsideMemo2) resList.Add("InsideMemo2");
            if (this.InsideMemo3 != target.InsideMemo3) resList.Add("InsideMemo3");
            if (this.SupplierCdDetail != target.SupplierCdDetail) resList.Add("SupplierCdDetail");
            if (this.SupplierSnmDetail != target.SupplierSnmDetail) resList.Add("SupplierSnmDetail");
            if (this.AddresseeCodeDetail != target.AddresseeCodeDetail) resList.Add("AddresseeCodeDetail");
            if (this.AddresseeNameDetail != target.AddresseeNameDetail) resList.Add("AddresseeNameDetail");
            if (this.DirectSendingCdDetail != target.DirectSendingCdDetail) resList.Add("DirectSendingCdDetail");
            if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
            if (this.WayToOrder != target.WayToOrder) resList.Add("WayToOrder");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.ExpectDeliveryDate != target.ExpectDeliveryDate) resList.Add("ExpectDeliveryDate");
            if (this.OrderDataCreateDiv != target.OrderDataCreateDiv) resList.Add("OrderDataCreateDiv");
            if (this.OrderDataCreateDate != target.OrderDataCreateDate) resList.Add("OrderDataCreateDate");
            if (this.OrderFormIssuedDiv != target.OrderFormIssuedDiv) resList.Add("OrderFormIssuedDiv");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.AddUpEnableCnt != target.AddUpEnableCnt) resList.Add("AddUpEnableCnt");
            if (this.AlreadyAddUpCnt != target.AlreadyAddUpCnt) resList.Add("AlreadyAddUpCnt");
            if (this.EditStatus != target.EditStatus) resList.Add("EditStatus");
            if (this.DtlRelationGuid != target.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.StockSectionNm != target.StockSectionNm) resList.Add("StockSectionNm");
            if (this.StockAddUpSectionNm != target.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// �d�����i���d���������́j��r����
        /// </summary>
        /// <param name="stockTemp1">��r����StockTemp�N���X�̃C���X�^���X</param>
        /// <param name="stockTemp2">��r����StockTemp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTemp�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockTemp stockTemp1, StockTemp stockTemp2)
        {
            ArrayList resList = new ArrayList();
            if (stockTemp1.CreateDateTime != stockTemp2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockTemp1.UpdateDateTime != stockTemp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockTemp1.EnterpriseCode != stockTemp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockTemp1.FileHeaderGuid != stockTemp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockTemp1.UpdEmployeeCode != stockTemp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockTemp1.UpdAssemblyId1 != stockTemp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockTemp1.UpdAssemblyId2 != stockTemp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockTemp1.LogicalDeleteCode != stockTemp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockTemp1.SupplierFormal != stockTemp2.SupplierFormal) resList.Add("SupplierFormal");
            if (stockTemp1.SupplierSlipNo != stockTemp2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (stockTemp1.SectionCode != stockTemp2.SectionCode) resList.Add("SectionCode");
            if (stockTemp1.SubSectionCode != stockTemp2.SubSectionCode) resList.Add("SubSectionCode");
            if (stockTemp1.DebitNoteDiv != stockTemp2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (stockTemp1.DebitNLnkSuppSlipNo != stockTemp2.DebitNLnkSuppSlipNo) resList.Add("DebitNLnkSuppSlipNo");
            if (stockTemp1.SupplierSlipCd != stockTemp2.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (stockTemp1.StockGoodsCd != stockTemp2.StockGoodsCd) resList.Add("StockGoodsCd");
            if (stockTemp1.AccPayDivCd != stockTemp2.AccPayDivCd) resList.Add("AccPayDivCd");
            if (stockTemp1.StockSectionCd != stockTemp2.StockSectionCd) resList.Add("StockSectionCd");
            if (stockTemp1.StockAddUpSectionCd != stockTemp2.StockAddUpSectionCd) resList.Add("StockAddUpSectionCd");
            if (stockTemp1.StockSlipUpdateCd != stockTemp2.StockSlipUpdateCd) resList.Add("StockSlipUpdateCd");
            if (stockTemp1.InputDay != stockTemp2.InputDay) resList.Add("InputDay");
            if (stockTemp1.ArrivalGoodsDay != stockTemp2.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (stockTemp1.StockDate != stockTemp2.StockDate) resList.Add("StockDate");
            if (stockTemp1.StockAddUpADate != stockTemp2.StockAddUpADate) resList.Add("StockAddUpADate");
            if (stockTemp1.DelayPaymentDiv != stockTemp2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (stockTemp1.PayeeCode != stockTemp2.PayeeCode) resList.Add("PayeeCode");
            if (stockTemp1.PayeeSnm != stockTemp2.PayeeSnm) resList.Add("PayeeSnm");
            if (stockTemp1.SupplierCd != stockTemp2.SupplierCd) resList.Add("SupplierCd");
            if (stockTemp1.SupplierNm1 != stockTemp2.SupplierNm1) resList.Add("SupplierNm1");
            if (stockTemp1.SupplierNm2 != stockTemp2.SupplierNm2) resList.Add("SupplierNm2");
            if (stockTemp1.SupplierSnm != stockTemp2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockTemp1.BusinessTypeCode != stockTemp2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (stockTemp1.BusinessTypeName != stockTemp2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (stockTemp1.SalesAreaCode != stockTemp2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (stockTemp1.SalesAreaName != stockTemp2.SalesAreaName) resList.Add("SalesAreaName");
            if (stockTemp1.StockInputCode != stockTemp2.StockInputCode) resList.Add("StockInputCode");
            if (stockTemp1.StockInputName != stockTemp2.StockInputName) resList.Add("StockInputName");
            if (stockTemp1.StockAgentCode != stockTemp2.StockAgentCode) resList.Add("StockAgentCode");
            if (stockTemp1.StockAgentName != stockTemp2.StockAgentName) resList.Add("StockAgentName");
            if (stockTemp1.SuppTtlAmntDspWayCd != stockTemp2.SuppTtlAmntDspWayCd) resList.Add("SuppTtlAmntDspWayCd");
            if (stockTemp1.TtlAmntDispRateApy != stockTemp2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (stockTemp1.StockTotalPrice != stockTemp2.StockTotalPrice) resList.Add("StockTotalPrice");
            if (stockTemp1.StockSubttlPrice != stockTemp2.StockSubttlPrice) resList.Add("StockSubttlPrice");
            if (stockTemp1.StockTtlPricTaxInc != stockTemp2.StockTtlPricTaxInc) resList.Add("StockTtlPricTaxInc");
            if (stockTemp1.StockTtlPricTaxExc != stockTemp2.StockTtlPricTaxExc) resList.Add("StockTtlPricTaxExc");
            if (stockTemp1.StockNetPrice != stockTemp2.StockNetPrice) resList.Add("StockNetPrice");
            if (stockTemp1.StockPriceConsTax != stockTemp2.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (stockTemp1.TtlItdedStcOutTax != stockTemp2.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (stockTemp1.TtlItdedStcInTax != stockTemp2.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (stockTemp1.TtlItdedStcTaxFree != stockTemp2.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (stockTemp1.StockOutTax != stockTemp2.StockOutTax) resList.Add("StockOutTax");
            if (stockTemp1.StckPrcConsTaxInclu != stockTemp2.StckPrcConsTaxInclu) resList.Add("StckPrcConsTaxInclu");
            if (stockTemp1.StckDisTtlTaxExc != stockTemp2.StckDisTtlTaxExc) resList.Add("StckDisTtlTaxExc");
            if (stockTemp1.ItdedStockDisOutTax != stockTemp2.ItdedStockDisOutTax) resList.Add("ItdedStockDisOutTax");
            if (stockTemp1.ItdedStockDisInTax != stockTemp2.ItdedStockDisInTax) resList.Add("ItdedStockDisInTax");
            if (stockTemp1.ItdedStockDisTaxFre != stockTemp2.ItdedStockDisTaxFre) resList.Add("ItdedStockDisTaxFre");
            if (stockTemp1.StockDisOutTax != stockTemp2.StockDisOutTax) resList.Add("StockDisOutTax");
            if (stockTemp1.StckDisTtlTaxInclu != stockTemp2.StckDisTtlTaxInclu) resList.Add("StckDisTtlTaxInclu");
            if (stockTemp1.TaxAdjust != stockTemp2.TaxAdjust) resList.Add("TaxAdjust");
            if (stockTemp1.BalanceAdjust != stockTemp2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (stockTemp1.SuppCTaxLayCd != stockTemp2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (stockTemp1.SupplierConsTaxRate != stockTemp2.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (stockTemp1.AccPayConsTax != stockTemp2.AccPayConsTax) resList.Add("AccPayConsTax");
            if (stockTemp1.StockFractionProcCd != stockTemp2.StockFractionProcCd) resList.Add("StockFractionProcCd");
            if (stockTemp1.AutoPayment != stockTemp2.AutoPayment) resList.Add("AutoPayment");
            if (stockTemp1.AutoPaySlipNum != stockTemp2.AutoPaySlipNum) resList.Add("AutoPaySlipNum");
            if (stockTemp1.RetGoodsReasonDiv != stockTemp2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (stockTemp1.RetGoodsReason != stockTemp2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (stockTemp1.PartySaleSlipNum != stockTemp2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (stockTemp1.SupplierSlipNote1 != stockTemp2.SupplierSlipNote1) resList.Add("SupplierSlipNote1");
            if (stockTemp1.SupplierSlipNote2 != stockTemp2.SupplierSlipNote2) resList.Add("SupplierSlipNote2");
            if (stockTemp1.DetailRowCount != stockTemp2.DetailRowCount) resList.Add("DetailRowCount");
            if (stockTemp1.EdiSendDate != stockTemp2.EdiSendDate) resList.Add("EdiSendDate");
            if (stockTemp1.EdiTakeInDate != stockTemp2.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (stockTemp1.UoeRemark1 != stockTemp2.UoeRemark1) resList.Add("UoeRemark1");
            if (stockTemp1.UoeRemark2 != stockTemp2.UoeRemark2) resList.Add("UoeRemark2");
            if (stockTemp1.SlipPrintDivCd != stockTemp2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (stockTemp1.SlipPrintFinishCd != stockTemp2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (stockTemp1.StockSlipPrintDate != stockTemp2.StockSlipPrintDate) resList.Add("StockSlipPrintDate");
            if (stockTemp1.SlipPrtSetPaperId != stockTemp2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (stockTemp1.SlipAddressDiv != stockTemp2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (stockTemp1.AddresseeCode != stockTemp2.AddresseeCode) resList.Add("AddresseeCode");
            if (stockTemp1.AddresseeName != stockTemp2.AddresseeName) resList.Add("AddresseeName");
            if (stockTemp1.AddresseeName2 != stockTemp2.AddresseeName2) resList.Add("AddresseeName2");
            if (stockTemp1.AddresseePostNo != stockTemp2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (stockTemp1.AddresseeAddr1 != stockTemp2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (stockTemp1.AddresseeAddr3 != stockTemp2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (stockTemp1.AddresseeAddr4 != stockTemp2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (stockTemp1.AddresseeTelNo != stockTemp2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (stockTemp1.AddresseeFaxNo != stockTemp2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (stockTemp1.DirectSendingCd != stockTemp2.DirectSendingCd) resList.Add("DirectSendingCd");
            if (stockTemp1.AcceptAnOrderNo != stockTemp2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (stockTemp1.SupplierFormalDetail != stockTemp2.SupplierFormalDetail) resList.Add("SupplierFormalDetail");
            if (stockTemp1.SupplierSlipNoDetail != stockTemp2.SupplierSlipNoDetail) resList.Add("SupplierSlipNoDetail");
            if (stockTemp1.StockRowNo != stockTemp2.StockRowNo) resList.Add("StockRowNo");
            if (stockTemp1.SectionCodeDetail != stockTemp2.SectionCodeDetail) resList.Add("SectionCodeDetail");
            if (stockTemp1.SubSectionCodeDetail != stockTemp2.SubSectionCodeDetail) resList.Add("SubSectionCodeDetail");
            if (stockTemp1.CommonSeqNo != stockTemp2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (stockTemp1.StockSlipDtlNum != stockTemp2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (stockTemp1.SupplierFormalSrc != stockTemp2.SupplierFormalSrc) resList.Add("SupplierFormalSrc");
            if (stockTemp1.StockSlipDtlNumSrc != stockTemp2.StockSlipDtlNumSrc) resList.Add("StockSlipDtlNumSrc");
            if (stockTemp1.AcptAnOdrStatusSync != stockTemp2.AcptAnOdrStatusSync) resList.Add("AcptAnOdrStatusSync");
            if (stockTemp1.SalesSlipDtlNumSync != stockTemp2.SalesSlipDtlNumSync) resList.Add("SalesSlipDtlNumSync");
            if (stockTemp1.StockSlipCdDtl != stockTemp2.StockSlipCdDtl) resList.Add("StockSlipCdDtl");
            if (stockTemp1.StockInputCodeDetail != stockTemp2.StockInputCodeDetail) resList.Add("StockInputCodeDetail");
            if (stockTemp1.StockInputNameDetail != stockTemp2.StockInputNameDetail) resList.Add("StockInputNameDetail");
            if (stockTemp1.StockAgentCodeDetail != stockTemp2.StockAgentCodeDetail) resList.Add("StockAgentCodeDetail");
            if (stockTemp1.StockAgentNameDetail != stockTemp2.StockAgentNameDetail) resList.Add("StockAgentNameDetail");
            if (stockTemp1.GoodsKindCode != stockTemp2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (stockTemp1.GoodsMakerCd != stockTemp2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockTemp1.MakerName != stockTemp2.MakerName) resList.Add("MakerName");
            if (stockTemp1.MakerKanaName != stockTemp2.MakerKanaName) resList.Add("MakerKanaName");
            if (stockTemp1.CmpltMakerKanaName != stockTemp2.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (stockTemp1.GoodsNo != stockTemp2.GoodsNo) resList.Add("GoodsNo");
            if (stockTemp1.GoodsName != stockTemp2.GoodsName) resList.Add("GoodsName");
            if (stockTemp1.GoodsNameKana != stockTemp2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (stockTemp1.GoodsLGroup != stockTemp2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (stockTemp1.GoodsLGroupName != stockTemp2.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (stockTemp1.GoodsMGroup != stockTemp2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (stockTemp1.GoodsMGroupName != stockTemp2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (stockTemp1.BLGroupCode != stockTemp2.BLGroupCode) resList.Add("BLGroupCode");
            if (stockTemp1.BLGroupName != stockTemp2.BLGroupName) resList.Add("BLGroupName");
            if (stockTemp1.BLGoodsCode != stockTemp2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockTemp1.BLGoodsFullName != stockTemp2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (stockTemp1.EnterpriseGanreCode != stockTemp2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (stockTemp1.EnterpriseGanreName != stockTemp2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (stockTemp1.WarehouseCode != stockTemp2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockTemp1.WarehouseName != stockTemp2.WarehouseName) resList.Add("WarehouseName");
            if (stockTemp1.WarehouseShelfNo != stockTemp2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockTemp1.StockOrderDivCd != stockTemp2.StockOrderDivCd) resList.Add("StockOrderDivCd");
            if (stockTemp1.OpenPriceDiv != stockTemp2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (stockTemp1.GoodsRateRank != stockTemp2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (stockTemp1.CustRateGrpCode != stockTemp2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (stockTemp1.SuppRateGrpCode != stockTemp2.SuppRateGrpCode) resList.Add("SuppRateGrpCode");
            if (stockTemp1.ListPriceTaxExcFl != stockTemp2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (stockTemp1.ListPriceTaxIncFl != stockTemp2.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (stockTemp1.StockRate != stockTemp2.StockRate) resList.Add("StockRate");
            if (stockTemp1.RateSectStckUnPrc != stockTemp2.RateSectStckUnPrc) resList.Add("RateSectStckUnPrc");
            if (stockTemp1.RateDivStckUnPrc != stockTemp2.RateDivStckUnPrc) resList.Add("RateDivStckUnPrc");
            if (stockTemp1.UnPrcCalcCdStckUnPrc != stockTemp2.UnPrcCalcCdStckUnPrc) resList.Add("UnPrcCalcCdStckUnPrc");
            if (stockTemp1.PriceCdStckUnPrc != stockTemp2.PriceCdStckUnPrc) resList.Add("PriceCdStckUnPrc");
            if (stockTemp1.StdUnPrcStckUnPrc != stockTemp2.StdUnPrcStckUnPrc) resList.Add("StdUnPrcStckUnPrc");
            if (stockTemp1.FracProcUnitStcUnPrc != stockTemp2.FracProcUnitStcUnPrc) resList.Add("FracProcUnitStcUnPrc");
            if (stockTemp1.FracProcStckUnPrc != stockTemp2.FracProcStckUnPrc) resList.Add("FracProcStckUnPrc");
            if (stockTemp1.StockUnitPriceFl != stockTemp2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stockTemp1.StockUnitTaxPriceFl != stockTemp2.StockUnitTaxPriceFl) resList.Add("StockUnitTaxPriceFl");
            if (stockTemp1.StockUnitChngDiv != stockTemp2.StockUnitChngDiv) resList.Add("StockUnitChngDiv");
            if (stockTemp1.BfStockUnitPriceFl != stockTemp2.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (stockTemp1.BfListPrice != stockTemp2.BfListPrice) resList.Add("BfListPrice");
            if (stockTemp1.RateBLGoodsCode != stockTemp2.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (stockTemp1.RateBLGoodsName != stockTemp2.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (stockTemp1.RateGoodsRateGrpCd != stockTemp2.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (stockTemp1.RateGoodsRateGrpNm != stockTemp2.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (stockTemp1.RateBLGroupCode != stockTemp2.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (stockTemp1.RateBLGroupName != stockTemp2.RateBLGroupName) resList.Add("RateBLGroupName");
            if (stockTemp1.StockCount != stockTemp2.StockCount) resList.Add("StockCount");
            if (stockTemp1.OrderCnt != stockTemp2.OrderCnt) resList.Add("OrderCnt");
            if (stockTemp1.OrderAdjustCnt != stockTemp2.OrderAdjustCnt) resList.Add("OrderAdjustCnt");
            if (stockTemp1.OrderRemainCnt != stockTemp2.OrderRemainCnt) resList.Add("OrderRemainCnt");
            if (stockTemp1.RemainCntUpdDate != stockTemp2.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (stockTemp1.StockPriceTaxExc != stockTemp2.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (stockTemp1.StockPriceTaxInc != stockTemp2.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (stockTemp1.StockGoodsCdDetail != stockTemp2.StockGoodsCdDetail) resList.Add("StockGoodsCdDetail");
            if (stockTemp1.StockPriceConsTaxDetail != stockTemp2.StockPriceConsTaxDetail) resList.Add("StockPriceConsTaxDetail");
            if (stockTemp1.TaxationCode != stockTemp2.TaxationCode) resList.Add("TaxationCode");
            if (stockTemp1.StockDtiSlipNote1 != stockTemp2.StockDtiSlipNote1) resList.Add("StockDtiSlipNote1");
            if (stockTemp1.SalesCustomerCode != stockTemp2.SalesCustomerCode) resList.Add("SalesCustomerCode");
            if (stockTemp1.SalesCustomerSnm != stockTemp2.SalesCustomerSnm) resList.Add("SalesCustomerSnm");
            if (stockTemp1.SlipMemo1 != stockTemp2.SlipMemo1) resList.Add("SlipMemo1");
            if (stockTemp1.SlipMemo2 != stockTemp2.SlipMemo2) resList.Add("SlipMemo2");
            if (stockTemp1.SlipMemo3 != stockTemp2.SlipMemo3) resList.Add("SlipMemo3");
            if (stockTemp1.InsideMemo1 != stockTemp2.InsideMemo1) resList.Add("InsideMemo1");
            if (stockTemp1.InsideMemo2 != stockTemp2.InsideMemo2) resList.Add("InsideMemo2");
            if (stockTemp1.InsideMemo3 != stockTemp2.InsideMemo3) resList.Add("InsideMemo3");
            if (stockTemp1.SupplierCdDetail != stockTemp2.SupplierCdDetail) resList.Add("SupplierCdDetail");
            if (stockTemp1.SupplierSnmDetail != stockTemp2.SupplierSnmDetail) resList.Add("SupplierSnmDetail");
            if (stockTemp1.AddresseeCodeDetail != stockTemp2.AddresseeCodeDetail) resList.Add("AddresseeCodeDetail");
            if (stockTemp1.AddresseeNameDetail != stockTemp2.AddresseeNameDetail) resList.Add("AddresseeNameDetail");
            if (stockTemp1.DirectSendingCdDetail != stockTemp2.DirectSendingCdDetail) resList.Add("DirectSendingCdDetail");
            if (stockTemp1.OrderNumber != stockTemp2.OrderNumber) resList.Add("OrderNumber");
            if (stockTemp1.WayToOrder != stockTemp2.WayToOrder) resList.Add("WayToOrder");
            if (stockTemp1.DeliGdsCmpltDueDate != stockTemp2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (stockTemp1.ExpectDeliveryDate != stockTemp2.ExpectDeliveryDate) resList.Add("ExpectDeliveryDate");
            if (stockTemp1.OrderDataCreateDiv != stockTemp2.OrderDataCreateDiv) resList.Add("OrderDataCreateDiv");
            if (stockTemp1.OrderDataCreateDate != stockTemp2.OrderDataCreateDate) resList.Add("OrderDataCreateDate");
            if (stockTemp1.OrderFormIssuedDiv != stockTemp2.OrderFormIssuedDiv) resList.Add("OrderFormIssuedDiv");
            if (stockTemp1.TotalDay != stockTemp2.TotalDay) resList.Add("TotalDay");
            if (stockTemp1.NTimeCalcStDate != stockTemp2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (stockTemp1.PayeeName != stockTemp2.PayeeName) resList.Add("PayeeName");
            if (stockTemp1.PayeeName2 != stockTemp2.PayeeName2) resList.Add("PayeeName2");
            if (stockTemp1.AddUpEnableCnt != stockTemp2.AddUpEnableCnt) resList.Add("AddUpEnableCnt");
            if (stockTemp1.AlreadyAddUpCnt != stockTemp2.AlreadyAddUpCnt) resList.Add("AlreadyAddUpCnt");
            if (stockTemp1.EditStatus != stockTemp2.EditStatus) resList.Add("EditStatus");
            if (stockTemp1.DtlRelationGuid != stockTemp2.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (stockTemp1.EnterpriseName != stockTemp2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockTemp1.UpdEmployeeName != stockTemp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockTemp1.StockSectionNm != stockTemp2.StockSectionNm) resList.Add("StockSectionNm");
            if (stockTemp1.StockAddUpSectionNm != stockTemp2.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");
            if (stockTemp1.SuppCTaxLayMethodNm != stockTemp2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (stockTemp1.BLGoodsName != stockTemp2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
    # region // DEL
    ///// public class name:   SalesSlipSearchResult
    ///// <summary>
    /////                      ����`�[�������o����
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   ����`�[�������o���ʃw�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/07/09  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //public class SalesSlipSearchResult
    //{
    //    /// <summary>��ƃR�[�h</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>�_���폜�敪</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
    //    private Int32 _logicalDeleteCode;

    //    /// <summary>�󒍃X�e�[�^�X</summary>
    //    /// <remarks>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </remarks>
    //    private Int32 _acptAnOdrStatus;

    //    /// <summary>����`�[�ԍ�</summary>
    //    /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>���_�R�[�h</summary>
    //    private string _sectionCode = "";

    //    /// <summary>���_�K�C�h����</summary>
    //    private string _sectionGuideNm = "";

    //    /// <summary>����R�[�h</summary>
    //    private Int32 _subSectionCode;

    //    /// <summary>���喼��</summary>
    //    private string _subSectionName = "";

    //    /// <summary>�ԓ`�敪</summary>
    //    /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>�ԍ��A������`�[�ԍ�</summary>
    //    /// <remarks>�ԍ��̑��������`�[�ԍ�</remarks>
    //    private string _debitNLnkSalesSlNum = "";

    //    /// <summary>����`�[�敪</summary>
    //    /// <remarks>0:����,1:�ԕi</remarks>
    //    private Int32 _salesSlipCd;

    //    /// <summary>���㏤�i�敪</summary>
    //    /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</remarks>
    //    private Int32 _salesGoodsCd;

    //    /// <summary>���|�敪</summary>
    //    /// <remarks>0:���|�Ȃ�,1:���|</remarks>
    //    private Int32 _accRecDivCd;

    //    /// <summary>������͋��_�R�[�h</summary>
    //    /// <remarks>�����^ �������͂������_�R�[�h</remarks>
    //    private string _salesInpSecCd = "";

    //    /// <summary>�����v�㋒�_�R�[�h</summary>
    //    /// <remarks>�����^</remarks>
    //    private string _demandAddUpSecCd = "";

    //    /// <summary>���ьv�㋒�_�R�[�h</summary>
    //    /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
    //    private string _resultsAddUpSecCd = "";

    //    /// <summary>�X�V���_�R�[�h</summary>
    //    /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
    //    private string _updateSecCd = "";

    //    /// <summary>�`�[�������t</summary>
    //    /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
    //    private DateTime _searchSlipDate;

    //    /// <summary>�o�ד��t</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _shipmentDay;

    //    /// <summary>������t</summary>
    //    /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>�v����t</summary>
    //    /// <remarks>�������@(YYYYMMDD)</remarks>
    //    private DateTime _addUpADate;

    //    /// <summary>�����敪</summary>
    //    /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
    //    private Int32 _delayPaymentDiv;

    //    /// <summary>���Ϗ��ԍ�</summary>
    //    private string _estimateFormNo = "";

    //    /// <summary>���ϋ敪</summary>
    //    /// <remarks>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</remarks>
    //    private Int32 _estimateDivide;

    //    /// <summary>���͒S���҃R�[�h</summary>
    //    /// <remarks>���O�C���S���ҁi�t�r�a�j</remarks>
    //    private string _inputAgenCd = "";

    //    /// <summary>���͒S���Җ���</summary>
    //    private string _inputAgenNm = "";

    //    /// <summary>������͎҃R�[�h</summary>
    //    /// <remarks>���͒S���ҁi���s�ҁj</remarks>
    //    private string _salesInputCode = "";

    //    /// <summary>������͎Җ���</summary>
    //    private string _salesInputName = "";

    //    /// <summary>��t�]�ƈ��R�[�h</summary>
    //    /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
    //    private string _frontEmployeeCd = "";

    //    /// <summary>��t�]�ƈ�����</summary>
    //    private string _frontEmployeeNm = "";

    //    /// <summary>�̔��]�ƈ��R�[�h</summary>
    //    /// <remarks>�v��S���ҁi�S���ҁj</remarks>
    //    private string _salesEmployeeCd = "";

    //    /// <summary>�̔��]�ƈ�����</summary>
    //    private string _salesEmployeeNm = "";

    //    /// <summary>���z�\�����@�敪</summary>
    //    /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
    //    private Int32 _totalAmountDispWayCd;

    //    /// <summary>���z�\���|���K�p�敪</summary>
    //    /// <remarks>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</remarks>
    //    private Int32 _ttlAmntDispRateApy;

    //    /// <summary>����`�[���v�i�ō��݁j</summary>
    //    /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
    //    private Int64 _salesTotalTaxInc;

    //    /// <summary>����`�[���v�i�Ŕ����j</summary>
    //    /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
    //    private Int64 _salesTotalTaxExc;

    //    /// <summary>���㕔�i���v�i�ō��݁j</summary>
    //    /// <remarks>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</remarks>
    //    private Int64 _salesPrtTotalTaxInc;

    //    /// <summary>���㕔�i���v�i�Ŕ����j</summary>
    //    /// <remarks>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</remarks>
    //    private Int64 _salesPrtTotalTaxExc;

    //    /// <summary>�����ƍ��v�i�ō��݁j</summary>
    //    /// <remarks>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</remarks>
    //    private Int64 _salesWorkTotalTaxInc;

    //    /// <summary>�����ƍ��v�i�Ŕ����j</summary>
    //    /// <remarks>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</remarks>
    //    private Int64 _salesWorkTotalTaxExc;

    //    /// <summary>���㏬�v�i�ō��݁j</summary>
    //    /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
    //    private Int64 _salesSubtotalTaxInc;

    //    /// <summary>���㏬�v�i�Ŕ����j</summary>
    //    /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
    //    private Int64 _salesSubtotalTaxExc;

    //    /// <summary>���㕔�i���v�i�ō��݁j</summary>
    //    /// <remarks>���i���׋��z�̐ō����v</remarks>
    //    private Int64 _salesPrtSubttlInc;

    //    /// <summary>���㕔�i���v�i�Ŕ����j</summary>
    //    /// <remarks>���i���׋��z�̐Ŕ����v</remarks>
    //    private Int64 _salesPrtSubttlExc;

    //    /// <summary>�����Ə��v�i�ō��݁j</summary>
    //    /// <remarks>��Ɩ��׋��z�̐ō����v</remarks>
    //    private Int64 _salesWorkSubttlInc;

    //    /// <summary>�����Ə��v�i�Ŕ����j</summary>
    //    /// <remarks>��Ɩ��׋��z�̐Ŕ����v</remarks>
    //    private Int64 _salesWorkSubttlExc;

    //    /// <summary>���㐳�����z</summary>
    //    /// <remarks>�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j</remarks>
    //    private Int64 _salesNetPrice;

    //    /// <summary>���㏬�v�i�Łj</summary>
    //    /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
    //    private Int64 _salesSubtotalTax;

    //    /// <summary>����O�őΏۊz</summary>
    //    /// <remarks>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </remarks>
    //    private Int64 _itdedSalesOutTax;

    //    /// <summary>������őΏۊz</summary>
    //    /// <remarks>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</remarks>
    //    private Int64 _itdedSalesInTax;

    //    /// <summary>���㏬�v��ېőΏۊz</summary>
    //    /// <remarks>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</remarks>
    //    private Int64 _salSubttlSubToTaxFre;

    //    /// <summary>������z����Ŋz�i�O�Łj</summary>
    //    /// <remarks>�l���O�̊O�ŏ��i�̏����</remarks>
    //    private Int64 _salesOutTax;

    //    /// <summary>������z����Ŋz�i���Łj</summary>
    //    /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
    //    private Int64 _salAmntConsTaxInclu;

    //    /// <summary>����l�����z�v�i�Ŕ����j</summary>
    //    private Int64 _salesDisTtlTaxExc;

    //    /// <summary>����l���O�őΏۊz���v</summary>
    //    /// <remarks>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</remarks>
    //    private Int64 _itdedSalesDisOutTax;

    //    /// <summary>����l�����őΏۊz���v</summary>
    //    /// <remarks>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</remarks>
    //    private Int64 _itdedSalesDisInTax;

    //    /// <summary>���i�l���Ώۊz���v�i�Ŕ����j</summary>
    //    /// <remarks>���i�l���z�i�Ŕ����j</remarks>
    //    private Int64 _itdedPartsDisOutTax;

    //    /// <summary>���i�l���Ώۊz���v�i�ō��݁j</summary>
    //    /// <remarks>���i�l���z�i�ō��݁j</remarks>
    //    private Int64 _itdedPartsDisInTax;

    //    /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j</summary>
    //    /// <remarks>��ƒl���z�i�Ŕ����j</remarks>
    //    private Int64 _itdedWorkDisOutTax;

    //    /// <summary>��ƒl���Ώۊz���v�i�ō��݁j</summary>
    //    /// <remarks>��ƒl���z�i�ō��݁j</remarks>
    //    private Int64 _itdedWorkDisInTax;

    //    /// <summary>����l����ېőΏۊz���v</summary>
    //    /// <remarks>��ېŏ��i�l���̔�ېőΏۊz</remarks>
    //    private Int64 _itdedSalesDisTaxFre;

    //    /// <summary>����l������Ŋz�i�O�Łj</summary>
    //    /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
    //    private Int64 _salesDisOutTax;

    //    /// <summary>����l������Ŋz�i���Łj</summary>
    //    private Int64 _salesDisTtlTaxInclu;

    //    /// <summary>���i�l����</summary>
    //    /// <remarks>���v�ɑ΂��Ă̕��i�l����</remarks>
    //    private Double _partsDiscountRate;

    //    /// <summary>�H���l����</summary>
    //    /// <remarks>���v�ɑ΂��Ă̍H���l����</remarks>
    //    private Double _ravorDiscountRate;

    //    /// <summary>�������z�v</summary>
    //    private Int64 _totalCost;

    //    /// <summary>����œ]�ŕ���</summary>
    //    /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
    //    private Int32 _consTaxLayMethod;

    //    /// <summary>����Őŗ�</summary>
    //    /// <remarks>�ύX2007/8/22(�^,��) ����</remarks>
    //    private Double _consTaxRate;

    //    /// <summary>�[�������敪</summary>
    //    /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
    //    private Int32 _fractionProcCd;

    //    /// <summary>���|�����</summary>
    //    private Int64 _accRecConsTax;

    //    /// <summary>���������敪</summary>
    //    /// <remarks>0:�ʏ����,1:��������</remarks>
    //    private Int32 _autoDepositCd;

    //    /// <summary>���������`�[�ԍ�</summary>
    //    /// <remarks>�����������̓����`�[�ԍ�</remarks>
    //    private Int32 _autoDepositSlipNo;

    //    /// <summary>�����������v�z</summary>
    //    /// <remarks>�a����������v�z���܂�</remarks>
    //    private Int64 _depositAllowanceTtl;

    //    /// <summary>���������c��</summary>
    //    private Int64 _depositAlwcBlnce;

    //    /// <summary>������R�[�h</summary>
    //    private Int32 _claimCode;

    //    /// <summary>�����旪��</summary>
    //    private string _claimSnm = "";

    //    /// <summary>���Ӑ�R�[�h</summary>
    //    private Int32 _customerCode;

    //    /// <summary>���Ӑ於��</summary>
    //    private string _customerName = "";

    //    /// <summary>���Ӑ於��2</summary>
    //    private string _customerName2 = "";

    //    /// <summary>���Ӑ旪��</summary>
    //    private string _customerSnm = "";

    //    /// <summary>�h��</summary>
    //    private string _honorificTitle = "";

    //    /// <summary>��������</summary>
    //    private string _outputName = "";

    //    /// <summary>���Ӑ�`�[�ԍ�</summary>
    //    private Int32 _custSlipNo;

    //    /// <summary>�`�[�Z���敪</summary>
    //    /// <remarks>1:���Ӑ�,2:�[����</remarks>
    //    private Int32 _slipAddressDiv;

    //    /// <summary>�[�i��R�[�h</summary>
    //    private Int32 _addresseeCode;

    //    /// <summary>�[�i�於��</summary>
    //    private string _addresseeName = "";

    //    /// <summary>�[�i�於��2</summary>
    //    /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
    //    private string _addresseeName2 = "";

    //    /// <summary>�[�i��X�֔ԍ�</summary>
    //    /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
    //    private string _addresseePostNo = "";

    //    /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)</summary>
    //    /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
    //    private string _addresseeAddr1 = "";

    //    /// <summary>�[�i��Z��3(�Ԓn)</summary>
    //    /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
    //    private string _addresseeAddr3 = "";

    //    /// <summary>�[�i��Z��4(�A�p�[�g����)</summary>
    //    /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
    //    private string _addresseeAddr4 = "";

    //    /// <summary>�[�i��d�b�ԍ�</summary>
    //    /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
    //    private string _addresseeTelNo = "";

    //    /// <summary>�[�i��FAX�ԍ�</summary>
    //    /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
    //    private string _addresseeFaxNo = "";

    //    /// <summary>�����`�[�ԍ�</summary>
    //    /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>�`�[���l</summary>
    //    private string _slipNote = "";

    //    /// <summary>�`�[���l�Q</summary>
    //    private string _slipNote2 = "";

    //    /// <summary>�`�[���l�R</summary>
    //    private string _slipNote3 = "";

    //    /// <summary>�ԕi���R�R�[�h</summary>
    //    private Int32 _retGoodsReasonDiv;

    //    /// <summary>�ԕi���R</summary>
    //    private string _retGoodsReason = "";

    //    /// <summary>���W������</summary>
    //    /// <remarks>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
    //    private DateTime _regiProcDate;

    //    /// <summary>���W�ԍ�</summary>
    //    /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
    //    private Int32 _cashRegisterNo;

    //    /// <summary>POS���V�[�g�ԍ�</summary>
    //    /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
    //    private Int32 _posReceiptNo;

    //    /// <summary>���׍s��</summary>
    //    /// <remarks>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</remarks>
    //    private Int32 _detailRowCount;

    //    /// <summary>�d�c�h���M��</summary>
    //    /// <remarks>YYYYMMDD �iErectricDataInterface�j</remarks>
    //    private DateTime _ediSendDate;

    //    /// <summary>�d�c�h�捞��</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _ediTakeInDate;

    //    /// <summary>�t�n�d���}�[�N�P</summary>
    //    /// <remarks>UserOrderEntory</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>�t�n�d���}�[�N�Q</summary>
    //    private string _uoeRemark2 = "";

    //    /// <summary>�`�[���s�敪</summary>
    //    /// <remarks>0:���Ȃ� 1:����</remarks>
    //    private Int32 _slipPrintDivCd;

    //    /// <summary>�`�[���s�ϋ敪</summary>
    //    /// <remarks>0:�����s 1:���s��</remarks>
    //    private Int32 _slipPrintFinishCd;

    //    /// <summary>����`�[���s��</summary>
    //    private DateTime _salesSlipPrintDate;

    //    /// <summary>�Ǝ�R�[�h</summary>
    //    private Int32 _businessTypeCode;

    //    /// <summary>�Ǝ햼��</summary>
    //    private string _businessTypeName = "";

    //    /// <summary>�����ԍ�</summary>
    //    /// <remarks>����`����"��"�̎��ɃZ�b�g</remarks>
    //    private string _orderNumber = "";

    //    /// <summary>�[�i�敪</summary>
    //    /// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
    //    private Int32 _deliveredGoodsDiv;

    //    /// <summary>�[�i�敪����</summary>
    //    private string _deliveredGoodsDivNm = "";

    //    /// <summary>�̔��G���A�R�[�h</summary>
    //    /// <remarks>�n��R�[�h</remarks>
    //    private Int32 _salesAreaCode;

    //    /// <summary>�̔��G���A����</summary>
    //    private string _salesAreaName = "";

    //    /// <summary>�����t���O</summary>
    //    /// <remarks>0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</remarks>
    //    private Int32 _reconcileFlag;

    //    /// <summary>�`�[����ݒ�p���[ID</summary>
    //    /// <remarks>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</remarks>
    //    private string _slipPrtSetPaperId = "";

    //    /// <summary>�ꎮ�`�[�敪</summary>
    //    /// <remarks>0:�ʏ�`�[,1:�ꎮ�`�[</remarks>
    //    private Int32 _completeCd;

    //    /// <summary>������z�[�������敪</summary>
    //    /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</remarks>
    //    private Int32 _salesPriceFracProcCd;

    //    /// <summary>�݌ɏ��i���v���z�i�Ŕ��j</summary>
    //    /// <remarks>�݌Ɏ��敪���O�̖��׋��z�̏W�v</remarks>
    //    private Int64 _stockGoodsTtlTaxExc;

    //    /// <summary>�������i���v���z�i�Ŕ��j</summary>
    //    /// <remarks>���i�������O�̖��׋��z�̏W�v</remarks>
    //    private Int64 _pureGoodsTtlTaxExc;

    //    /// <summary>�艿����敪</summary>
    //    private Int32 _listPricePrintDiv;

    //    /// <summary>�����\���敪�P</summary>
    //    /// <remarks>�ʏ�@�@0:����@1:�a��</remarks>
    //    private Int32 _eraNameDispCd1;

    //    /// <summary>���Ϗ���ŋ敪</summary>
    //    /// <remarks>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</remarks>
    //    private Int32 _estimaTaxDivCd;

    //    /// <summary>���Ϗ�����敪</summary>
    //    private Int32 _estimateFormPrtCd;

    //    /// <summary>���ό���</summary>
    //    private string _estimateSubject = "";

    //    /// <summary>�r���P</summary>
    //    private string _footnotes1 = "";

    //    /// <summary>�r���Q</summary>
    //    private string _footnotes2 = "";

    //    /// <summary>���σ^�C�g���P</summary>
    //    private string _estimateTitle1 = "";

    //    /// <summary>���σ^�C�g���Q</summary>
    //    private string _estimateTitle2 = "";

    //    /// <summary>���σ^�C�g���R</summary>
    //    private string _estimateTitle3 = "";

    //    /// <summary>���σ^�C�g���S</summary>
    //    private string _estimateTitle4 = "";

    //    /// <summary>���σ^�C�g���T</summary>
    //    private string _estimateTitle5 = "";

    //    /// <summary>���ϔ��l�P</summary>
    //    private string _estimateNote1 = "";

    //    /// <summary>���ϔ��l�Q</summary>
    //    private string _estimateNote2 = "";

    //    /// <summary>���ϔ��l�R</summary>
    //    private string _estimateNote3 = "";

    //    /// <summary>���ϔ��l�S</summary>
    //    private string _estimateNote4 = "";

    //    /// <summary>���ϔ��l�T</summary>
    //    private string _estimateNote5 = "";

    //    /// <summary>���ϗL������</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _estimateValidityDate;

    //    /// <summary>�i�Ԉ󎚋敪</summary>
    //    /// <remarks>0:���Ȃ�,1:����</remarks>
    //    private Int32 _partsNoPrtCd;

    //    /// <summary>�I�v�V�����󎚋敪</summary>
    //    /// <remarks>0:���Ȃ�,1:����</remarks>
    //    private Int32 _optionPringDivCd;

    //    /// <summary>�|���g�p�敪</summary>
    //    /// <remarks>0:�������艿 1:�|���w��,2:�|���ݒ�</remarks>
    //    private Int32 _rateUseCode;

    //    /// <summary>�ԗ��Ǘ��ԍ�</summary>
    //    /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
    //    private String _carMngCode;

    //    /// <summary>�^���w��ԍ�</summary>
    //    private Int32 _modelDesignationNo;

    //    /// <summary>�ޕʔԍ�</summary>
    //    private Int32 _categoryNo;

    //    /// <summary>���[�J�[�S�p����</summary>
    //    /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
    //    private string _makerFullName = "";

    //    /// <summary>�^���i�t���^�j</summary>
    //    /// <remarks>�t���^��(44���p)</remarks>
    //    private string _fullModel = "";

    //    /// <summary>��Ɩ���</summary>
    //    private string _enterpriseName = "";

    //    /// <summary>���ьv�㋒�_����</summary>
    //    private string _resultsAddUpSecNm = "";


    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>��ƃR�[�h�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get { return _enterpriseCode; }
    //        set { _enterpriseCode = value; }
    //    }

    //    /// public propaty name  :  LogicalDeleteCode
    //    /// <summary>�_���폜�敪�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �_���폜�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 LogicalDeleteCode
    //    {
    //        get { return _logicalDeleteCode; }
    //        set { _logicalDeleteCode = value; }
    //    }

    //    /// public propaty name  :  AcptAnOdrStatus
    //    /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
    //    /// <value>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AcptAnOdrStatus
    //    {
    //        get { return _acptAnOdrStatus; }
    //        set { _acptAnOdrStatus = value; }
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>����`�[�ԍ��v���p�e�B</summary>
    //    /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>���_�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>���_�K�C�h���̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  SubSectionCode
    //    /// <summary>����R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SubSectionCode
    //    {
    //        get { return _subSectionCode; }
    //        set { _subSectionCode = value; }
    //    }

    //    /// public propaty name  :  SubSectionName
    //    /// <summary>���喼�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���喼�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SubSectionName
    //    {
    //        get { return _subSectionName; }
    //        set { _subSectionName = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>�ԓ`�敪�v���p�e�B</summary>
    //    /// <value>0:���`,1:�ԓ`,2:����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DebitNoteDiv
    //    {
    //        get { return _debitNoteDiv; }
    //        set { _debitNoteDiv = value; }
    //    }

    //    /// public propaty name  :  DebitNLnkSalesSlNum
    //    /// <summary>�ԍ��A������`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�ԍ��̑��������`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԍ��A������`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string DebitNLnkSalesSlNum
    //    {
    //        get { return _debitNLnkSalesSlNum; }
    //        set { _debitNLnkSalesSlNum = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCd
    //    /// <summary>����`�[�敪�v���p�e�B</summary>
    //    /// <value>0:����,1:�ԕi</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCd
    //    {
    //        get { return _salesSlipCd; }
    //        set { _salesSlipCd = value; }
    //    }

    //    /// public propaty name  :  SalesGoodsCd
    //    /// <summary>���㏤�i�敪�v���p�e�B</summary>
    //    /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesGoodsCd
    //    {
    //        get { return _salesGoodsCd; }
    //        set { _salesGoodsCd = value; }
    //    }

    //    /// public propaty name  :  AccRecDivCd
    //    /// <summary>���|�敪�v���p�e�B</summary>
    //    /// <value>0:���|�Ȃ�,1:���|</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���|�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AccRecDivCd
    //    {
    //        get { return _accRecDivCd; }
    //        set { _accRecDivCd = value; }
    //    }

    //    /// public propaty name  :  SalesInpSecCd
    //    /// <summary>������͋��_�R�[�h�v���p�e�B</summary>
    //    /// <value>�����^ �������͂������_�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������͋��_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesInpSecCd
    //    {
    //        get { return _salesInpSecCd; }
    //        set { _salesInpSecCd = value; }
    //    }

    //    /// public propaty name  :  DemandAddUpSecCd
    //    /// <summary>�����v�㋒�_�R�[�h�v���p�e�B</summary>
    //    /// <value>�����^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����v�㋒�_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string DemandAddUpSecCd
    //    {
    //        get { return _demandAddUpSecCd; }
    //        set { _demandAddUpSecCd = value; }
    //    }

    //    /// public propaty name  :  ResultsAddUpSecCd
    //    /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
    //    /// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ResultsAddUpSecCd
    //    {
    //        get { return _resultsAddUpSecCd; }
    //        set { _resultsAddUpSecCd = value; }
    //    }

    //    /// public propaty name  :  UpdateSecCd
    //    /// <summary>�X�V���_�R�[�h�v���p�e�B</summary>
    //    /// <value>�����^ �f�[�^�̓o�^�X�V���_</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �X�V���_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UpdateSecCd
    //    {
    //        get { return _updateSecCd; }
    //        set { _updateSecCd = value; }
    //    }

    //    /// public propaty name  :  SearchSlipDate
    //    /// <summary>�`�[�������t�v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�������t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SearchSlipDate
    //    {
    //        get { return _searchSlipDate; }
    //        set { _searchSlipDate = value; }
    //    }

    //    /// public propaty name  :  SearchSlipDateJpFormal
    //    /// <summary>�`�[�������t �a��v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�������t �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SearchSlipDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SearchSlipDateJpInFormal
    //    /// <summary>�`�[�������t �a��(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�������t �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SearchSlipDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SearchSlipDateAdFormal
    //    /// <summary>�`�[�������t ����v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�������t ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SearchSlipDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SearchSlipDateAdInFormal
    //    /// <summary>�`�[�������t ����(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�������t ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SearchSlipDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDay
    //    /// <summary>�o�ד��t�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �o�ד��t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime ShipmentDay
    //    {
    //        get { return _shipmentDay; }
    //        set { _shipmentDay = value; }
    //    }

    //    /// public propaty name  :  ShipmentDayJpFormal
    //    /// <summary>�o�ד��t �a��v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �o�ד��t �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ShipmentDayJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDayJpInFormal
    //    /// <summary>�o�ד��t �a��(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �o�ד��t �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ShipmentDayJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDayAdFormal
    //    /// <summary>�o�ד��t ����v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �o�ד��t ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ShipmentDayAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDayAdInFormal
    //    /// <summary>�o�ד��t ����(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �o�ד��t ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ShipmentDayAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>������t�v���p�e�B</summary>
    //    /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  SalesDateJpFormal
    //    /// <summary>������t �a��v���p�e�B</summary>
    //    /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������t �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDateJpInFormal
    //    /// <summary>������t �a��(��)�v���p�e�B</summary>
    //    /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������t �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDateAdFormal
    //    /// <summary>������t ����v���p�e�B</summary>
    //    /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������t ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDateAdInFormal
    //    /// <summary>������t ����(��)�v���p�e�B</summary>
    //    /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������t ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADate
    //    /// <summary>�v����t�v���p�e�B</summary>
    //    /// <value>�������@(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime AddUpADate
    //    {
    //        get { return _addUpADate; }
    //        set { _addUpADate = value; }
    //    }

    //    /// public propaty name  :  AddUpADateJpFormal
    //    /// <summary>�v����t �a��v���p�e�B</summary>
    //    /// <value>�������@(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����t �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddUpADateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADateJpInFormal
    //    /// <summary>�v����t �a��(��)�v���p�e�B</summary>
    //    /// <value>�������@(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����t �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddUpADateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADateAdFormal
    //    /// <summary>�v����t ����v���p�e�B</summary>
    //    /// <value>�������@(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����t ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddUpADateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADateAdInFormal
    //    /// <summary>�v����t ����(��)�v���p�e�B</summary>
    //    /// <value>�������@(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����t ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddUpADateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  DelayPaymentDiv
    //    /// <summary>�����敪�v���p�e�B</summary>
    //    /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DelayPaymentDiv
    //    {
    //        get { return _delayPaymentDiv; }
    //        set { _delayPaymentDiv = value; }
    //    }

    //    /// public propaty name  :  EstimateFormNo
    //    /// <summary>���Ϗ��ԍ��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ϗ��ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateFormNo
    //    {
    //        get { return _estimateFormNo; }
    //        set { _estimateFormNo = value; }
    //    }

    //    /// public propaty name  :  EstimateDivide
    //    /// <summary>���ϋ敪�v���p�e�B</summary>
    //    /// <value>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϋ敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EstimateDivide
    //    {
    //        get { return _estimateDivide; }
    //        set { _estimateDivide = value; }
    //    }

    //    /// public propaty name  :  InputAgenCd
    //    /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
    //    /// <value>���O�C���S���ҁi�t�r�a�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string InputAgenCd
    //    {
    //        get { return _inputAgenCd; }
    //        set { _inputAgenCd = value; }
    //    }

    //    /// public propaty name  :  InputAgenNm
    //    /// <summary>���͒S���Җ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string InputAgenNm
    //    {
    //        get { return _inputAgenNm; }
    //        set { _inputAgenNm = value; }
    //    }

    //    /// public propaty name  :  SalesInputCode
    //    /// <summary>������͎҃R�[�h�v���p�e�B</summary>
    //    /// <value>���͒S���ҁi���s�ҁj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesInputCode
    //    {
    //        get { return _salesInputCode; }
    //        set { _salesInputCode = value; }
    //    }

    //    /// public propaty name  :  SalesInputName
    //    /// <summary>������͎Җ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesInputName
    //    {
    //        get { return _salesInputName; }
    //        set { _salesInputName = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeCd
    //    /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
    //    /// <value>��t�S���ҁi�󒍎ҁj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FrontEmployeeCd
    //    {
    //        get { return _frontEmployeeCd; }
    //        set { _frontEmployeeCd = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeNm
    //    /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FrontEmployeeNm
    //    {
    //        get { return _frontEmployeeNm; }
    //        set { _frontEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  SalesEmployeeCd
    //    /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
    //    /// <value>�v��S���ҁi�S���ҁj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesEmployeeCd
    //    {
    //        get { return _salesEmployeeCd; }
    //        set { _salesEmployeeCd = value; }
    //    }

    //    /// public propaty name  :  SalesEmployeeNm
    //    /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesEmployeeNm
    //    {
    //        get { return _salesEmployeeNm; }
    //        set { _salesEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  TotalAmountDispWayCd
    //    /// <summary>���z�\�����@�敪�v���p�e�B</summary>
    //    /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 TotalAmountDispWayCd
    //    {
    //        get { return _totalAmountDispWayCd; }
    //        set { _totalAmountDispWayCd = value; }
    //    }

    //    /// public propaty name  :  TtlAmntDispRateApy
    //    /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
    //    /// <value>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 TtlAmntDispRateApy
    //    {
    //        get { return _ttlAmntDispRateApy; }
    //        set { _ttlAmntDispRateApy = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxInc
    //    /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxInc
    //    {
    //        get { return _salesTotalTaxInc; }
    //        set { _salesTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxExc
    //    /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxExc
    //    {
    //        get { return _salesTotalTaxExc; }
    //        set { _salesTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtTotalTaxInc
    //    /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesPrtTotalTaxInc
    //    {
    //        get { return _salesPrtTotalTaxInc; }
    //        set { _salesPrtTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtTotalTaxExc
    //    /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesPrtTotalTaxExc
    //    {
    //        get { return _salesPrtTotalTaxExc; }
    //        set { _salesPrtTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkTotalTaxInc
    //    /// <summary>�����ƍ��v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����ƍ��v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesWorkTotalTaxInc
    //    {
    //        get { return _salesWorkTotalTaxInc; }
    //        set { _salesWorkTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkTotalTaxExc
    //    /// <summary>�����ƍ��v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����ƍ��v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesWorkTotalTaxExc
    //    {
    //        get { return _salesWorkTotalTaxExc; }
    //        set { _salesWorkTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesSubtotalTaxInc
    //    /// <summary>���㏬�v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㏬�v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesSubtotalTaxInc
    //    {
    //        get { return _salesSubtotalTaxInc; }
    //        set { _salesSubtotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesSubtotalTaxExc
    //    /// <summary>���㏬�v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㏬�v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesSubtotalTaxExc
    //    {
    //        get { return _salesSubtotalTaxExc; }
    //        set { _salesSubtotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtSubttlInc
    //    /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>���i���׋��z�̐ō����v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesPrtSubttlInc
    //    {
    //        get { return _salesPrtSubttlInc; }
    //        set { _salesPrtSubttlInc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtSubttlExc
    //    /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>���i���׋��z�̐Ŕ����v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesPrtSubttlExc
    //    {
    //        get { return _salesPrtSubttlExc; }
    //        set { _salesPrtSubttlExc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkSubttlInc
    //    /// <summary>�����Ə��v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>��Ɩ��׋��z�̐ō����v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����Ə��v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesWorkSubttlInc
    //    {
    //        get { return _salesWorkSubttlInc; }
    //        set { _salesWorkSubttlInc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkSubttlExc
    //    /// <summary>�����Ə��v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>��Ɩ��׋��z�̐Ŕ����v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����Ə��v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesWorkSubttlExc
    //    {
    //        get { return _salesWorkSubttlExc; }
    //        set { _salesWorkSubttlExc = value; }
    //    }

    //    /// public propaty name  :  SalesNetPrice
    //    /// <summary>���㐳�����z�v���p�e�B</summary>
    //    /// <value>�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㐳�����z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesNetPrice
    //    {
    //        get { return _salesNetPrice; }
    //        set { _salesNetPrice = value; }
    //    }

    //    /// public propaty name  :  SalesSubtotalTax
    //    /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
    //    /// <value>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesSubtotalTax
    //    {
    //        get { return _salesSubtotalTax; }
    //        set { _salesSubtotalTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesOutTax
    //    /// <summary>����O�őΏۊz�v���p�e�B</summary>
    //    /// <value>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesOutTax
    //    {
    //        get { return _itdedSalesOutTax; }
    //        set { _itdedSalesOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesInTax
    //    /// <summary>������őΏۊz�v���p�e�B</summary>
    //    /// <value>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������őΏۊz�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesInTax
    //    {
    //        get { return _itdedSalesInTax; }
    //        set { _itdedSalesInTax = value; }
    //    }

    //    /// public propaty name  :  SalSubttlSubToTaxFre
    //    /// <summary>���㏬�v��ېőΏۊz�v���p�e�B</summary>
    //    /// <value>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���㏬�v��ېőΏۊz�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalSubttlSubToTaxFre
    //    {
    //        get { return _salSubttlSubToTaxFre; }
    //        set { _salSubttlSubToTaxFre = value; }
    //    }

    //    /// public propaty name  :  SalesOutTax
    //    /// <summary>������z����Ŋz�i�O�Łj�v���p�e�B</summary>
    //    /// <value>�l���O�̊O�ŏ��i�̏����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������z����Ŋz�i�O�Łj�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesOutTax
    //    {
    //        get { return _salesOutTax; }
    //        set { _salesOutTax = value; }
    //    }

    //    /// public propaty name  :  SalAmntConsTaxInclu
    //    /// <summary>������z����Ŋz�i���Łj�v���p�e�B</summary>
    //    /// <value>�l���O�̓��ŏ��i�̏����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������z����Ŋz�i���Łj�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalAmntConsTaxInclu
    //    {
    //        get { return _salAmntConsTaxInclu; }
    //        set { _salAmntConsTaxInclu = value; }
    //    }

    //    /// public propaty name  :  SalesDisTtlTaxExc
    //    /// <summary>����l�����z�v�i�Ŕ����j�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����l�����z�v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesDisTtlTaxExc
    //    {
    //        get { return _salesDisTtlTaxExc; }
    //        set { _salesDisTtlTaxExc = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesDisOutTax
    //    /// <summary>����l���O�őΏۊz���v�v���p�e�B</summary>
    //    /// <value>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����l���O�őΏۊz���v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesDisOutTax
    //    {
    //        get { return _itdedSalesDisOutTax; }
    //        set { _itdedSalesDisOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesDisInTax
    //    /// <summary>����l�����őΏۊz���v�v���p�e�B</summary>
    //    /// <value>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����l�����őΏۊz���v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesDisInTax
    //    {
    //        get { return _itdedSalesDisInTax; }
    //        set { _itdedSalesDisInTax = value; }
    //    }

    //    /// public propaty name  :  ItdedPartsDisOutTax
    //    /// <summary>���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>���i�l���z�i�Ŕ����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedPartsDisOutTax
    //    {
    //        get { return _itdedPartsDisOutTax; }
    //        set { _itdedPartsDisOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedPartsDisInTax
    //    /// <summary>���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>���i�l���z�i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedPartsDisInTax
    //    {
    //        get { return _itdedPartsDisInTax; }
    //        set { _itdedPartsDisInTax = value; }
    //    }

    //    /// public propaty name  :  ItdedWorkDisOutTax
    //    /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>��ƒl���z�i�Ŕ����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedWorkDisOutTax
    //    {
    //        get { return _itdedWorkDisOutTax; }
    //        set { _itdedWorkDisOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedWorkDisInTax
    //    /// <summary>��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>��ƒl���z�i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedWorkDisInTax
    //    {
    //        get { return _itdedWorkDisInTax; }
    //        set { _itdedWorkDisInTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesDisTaxFre
    //    /// <summary>����l����ېőΏۊz���v�v���p�e�B</summary>
    //    /// <value>��ېŏ��i�l���̔�ېőΏۊz</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����l����ېőΏۊz���v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesDisTaxFre
    //    {
    //        get { return _itdedSalesDisTaxFre; }
    //        set { _itdedSalesDisTaxFre = value; }
    //    }

    //    /// public propaty name  :  SalesDisOutTax
    //    /// <summary>����l������Ŋz�i�O�Łj�v���p�e�B</summary>
    //    /// <value>�O�ŏ��i�l���̏���Ŋz</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����l������Ŋz�i�O�Łj�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesDisOutTax
    //    {
    //        get { return _salesDisOutTax; }
    //        set { _salesDisOutTax = value; }
    //    }

    //    /// public propaty name  :  SalesDisTtlTaxInclu
    //    /// <summary>����l������Ŋz�i���Łj�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����l������Ŋz�i���Łj�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesDisTtlTaxInclu
    //    {
    //        get { return _salesDisTtlTaxInclu; }
    //        set { _salesDisTtlTaxInclu = value; }
    //    }

    //    /// public propaty name  :  PartsDiscountRate
    //    /// <summary>���i�l�����v���p�e�B</summary>
    //    /// <value>���v�ɑ΂��Ă̕��i�l����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�l�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double PartsDiscountRate
    //    {
    //        get { return _partsDiscountRate; }
    //        set { _partsDiscountRate = value; }
    //    }

    //    /// public propaty name  :  RavorDiscountRate
    //    /// <summary>�H���l�����v���p�e�B</summary>
    //    /// <value>���v�ɑ΂��Ă̍H���l����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �H���l�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double RavorDiscountRate
    //    {
    //        get { return _ravorDiscountRate; }
    //        set { _ravorDiscountRate = value; }
    //    }

    //    /// public propaty name  :  TotalCost
    //    /// <summary>�������z�v�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������z�v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 TotalCost
    //    {
    //        get { return _totalCost; }
    //        set { _totalCost = value; }
    //    }

    //    /// public propaty name  :  ConsTaxLayMethod
    //    /// <summary>����œ]�ŕ����v���p�e�B</summary>
    //    /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ConsTaxLayMethod
    //    {
    //        get { return _consTaxLayMethod; }
    //        set { _consTaxLayMethod = value; }
    //    }

    //    /// public propaty name  :  ConsTaxRate
    //    /// <summary>����Őŗ��v���p�e�B</summary>
    //    /// <value>�ύX2007/8/22(�^,��) ����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����Őŗ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double ConsTaxRate
    //    {
    //        get { return _consTaxRate; }
    //        set { _consTaxRate = value; }
    //    }

    //    /// public propaty name  :  FractionProcCd
    //    /// <summary>�[�������敪�v���p�e�B</summary>
    //    /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�������敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 FractionProcCd
    //    {
    //        get { return _fractionProcCd; }
    //        set { _fractionProcCd = value; }
    //    }

    //    /// public propaty name  :  AccRecConsTax
    //    /// <summary>���|����Ńv���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���|����Ńv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 AccRecConsTax
    //    {
    //        get { return _accRecConsTax; }
    //        set { _accRecConsTax = value; }
    //    }

    //    /// public propaty name  :  AutoDepositCd
    //    /// <summary>���������敪�v���p�e�B</summary>
    //    /// <value>0:�ʏ����,1:��������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���������敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AutoDepositCd
    //    {
    //        get { return _autoDepositCd; }
    //        set { _autoDepositCd = value; }
    //    }

    //    /// public propaty name  :  AutoDepositSlipNo
    //    /// <summary>���������`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�����������̓����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���������`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AutoDepositSlipNo
    //    {
    //        get { return _autoDepositSlipNo; }
    //        set { _autoDepositSlipNo = value; }
    //    }

    //    /// public propaty name  :  DepositAllowanceTtl
    //    /// <summary>�����������v�z�v���p�e�B</summary>
    //    /// <value>�a����������v�z���܂�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����������v�z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 DepositAllowanceTtl
    //    {
    //        get { return _depositAllowanceTtl; }
    //        set { _depositAllowanceTtl = value; }
    //    }

    //    /// public propaty name  :  DepositAlwcBlnce
    //    /// <summary>���������c���v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���������c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 DepositAlwcBlnce
    //    {
    //        get { return _depositAlwcBlnce; }
    //        set { _depositAlwcBlnce = value; }
    //    }

    //    /// public propaty name  :  ClaimCode
    //    /// <summary>������R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ClaimCode
    //    {
    //        get { return _claimCode; }
    //        set { _claimCode = value; }
    //    }

    //    /// public propaty name  :  ClaimSnm
    //    /// <summary>�����旪�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����旪�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ClaimSnm
    //    {
    //        get { return _claimSnm; }
    //        set { _claimSnm = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerName
    //    /// <summary>���Ӑ於�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CustomerName
    //    {
    //        get { return _customerName; }
    //        set { _customerName = value; }
    //    }

    //    /// public propaty name  :  CustomerName2
    //    /// <summary>���Ӑ於��2�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CustomerName2
    //    {
    //        get { return _customerName2; }
    //        set { _customerName2 = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>���Ӑ旪�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
    //    }

    //    /// public propaty name  :  HonorificTitle
    //    /// <summary>�h�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �h�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string HonorificTitle
    //    {
    //        get { return _honorificTitle; }
    //        set { _honorificTitle = value; }
    //    }

    //    /// public propaty name  :  OutputName
    //    /// <summary>�������̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string OutputName
    //    {
    //        get { return _outputName; }
    //        set { _outputName = value; }
    //    }

    //    /// public propaty name  :  CustSlipNo
    //    /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustSlipNo
    //    {
    //        get { return _custSlipNo; }
    //        set { _custSlipNo = value; }
    //    }

    //    /// public propaty name  :  SlipAddressDiv
    //    /// <summary>�`�[�Z���敪�v���p�e�B</summary>
    //    /// <value>1:���Ӑ�,2:�[����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�Z���敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SlipAddressDiv
    //    {
    //        get { return _slipAddressDiv; }
    //        set { _slipAddressDiv = value; }
    //    }

    //    /// public propaty name  :  AddresseeCode
    //    /// <summary>�[�i��R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AddresseeCode
    //    {
    //        get { return _addresseeCode; }
    //        set { _addresseeCode = value; }
    //    }

    //    /// public propaty name  :  AddresseeName
    //    /// <summary>�[�i�於�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�於�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeName
    //    {
    //        get { return _addresseeName; }
    //        set { _addresseeName = value; }
    //    }

    //    /// public propaty name  :  AddresseeName2
    //    /// <summary>�[�i�於��2�v���p�e�B</summary>
    //    /// <value>�ǉ�(�o�^�R��) ����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�於��2�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeName2
    //    {
    //        get { return _addresseeName2; }
    //        set { _addresseeName2 = value; }
    //    }

    //    /// public propaty name  :  AddresseePostNo
    //    /// <summary>�[�i��X�֔ԍ��v���p�e�B</summary>
    //    /// <value>�`�[�Z���敪�ɏ]�����e</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��X�֔ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseePostNo
    //    {
    //        get { return _addresseePostNo; }
    //        set { _addresseePostNo = value; }
    //    }

    //    /// public propaty name  :  AddresseeAddr1
    //    /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</summary>
    //    /// <value>�`�[�Z���敪�ɏ]�����e</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeAddr1
    //    {
    //        get { return _addresseeAddr1; }
    //        set { _addresseeAddr1 = value; }
    //    }

    //    /// public propaty name  :  AddresseeAddr3
    //    /// <summary>�[�i��Z��3(�Ԓn)�v���p�e�B</summary>
    //    /// <value>�`�[�Z���敪�ɏ]�����e</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��Z��3(�Ԓn)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeAddr3
    //    {
    //        get { return _addresseeAddr3; }
    //        set { _addresseeAddr3 = value; }
    //    }

    //    /// public propaty name  :  AddresseeAddr4
    //    /// <summary>�[�i��Z��4(�A�p�[�g����)�v���p�e�B</summary>
    //    /// <value>�`�[�Z���敪�ɏ]�����e</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��Z��4(�A�p�[�g����)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeAddr4
    //    {
    //        get { return _addresseeAddr4; }
    //        set { _addresseeAddr4 = value; }
    //    }

    //    /// public propaty name  :  AddresseeTelNo
    //    /// <summary>�[�i��d�b�ԍ��v���p�e�B</summary>
    //    /// <value>�`�[�Z���敪�ɏ]�����e</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��d�b�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeTelNo
    //    {
    //        get { return _addresseeTelNo; }
    //        set { _addresseeTelNo = value; }
    //    }

    //    /// public propaty name  :  AddresseeFaxNo
    //    /// <summary>�[�i��FAX�ԍ��v���p�e�B</summary>
    //    /// <value>�`�[�Z���敪�ɏ]�����e</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��FAX�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeFaxNo
    //    {
    //        get { return _addresseeFaxNo; }
    //        set { _addresseeFaxNo = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>�����`�[�ԍ��v���p�e�B</summary>
    //    /// <value>���Ӑ撍���ԍ��i���`�ԍ��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  SlipNote
    //    /// <summary>�`�[���l�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���l�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote
    //    {
    //        get { return _slipNote; }
    //        set { _slipNote = value; }
    //    }

    //    /// public propaty name  :  SlipNote2
    //    /// <summary>�`�[���l�Q�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote2
    //    {
    //        get { return _slipNote2; }
    //        set { _slipNote2 = value; }
    //    }

    //    /// public propaty name  :  SlipNote3
    //    /// <summary>�`�[���l�R�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���l�R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote3
    //    {
    //        get { return _slipNote3; }
    //        set { _slipNote3 = value; }
    //    }

    //    /// public propaty name  :  RetGoodsReasonDiv
    //    /// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 RetGoodsReasonDiv
    //    {
    //        get { return _retGoodsReasonDiv; }
    //        set { _retGoodsReasonDiv = value; }
    //    }

    //    /// public propaty name  :  RetGoodsReason
    //    /// <summary>�ԕi���R�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԕi���R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string RetGoodsReason
    //    {
    //        get { return _retGoodsReason; }
    //        set { _retGoodsReason = value; }
    //    }

    //    /// public propaty name  :  RegiProcDate
    //    /// <summary>���W�������v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���W�������v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime RegiProcDate
    //    {
    //        get { return _regiProcDate; }
    //        set { _regiProcDate = value; }
    //    }

    //    /// public propaty name  :  RegiProcDateJpFormal
    //    /// <summary>���W������ �a��v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���W������ �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string RegiProcDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  RegiProcDateJpInFormal
    //    /// <summary>���W������ �a��(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���W������ �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string RegiProcDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  RegiProcDateAdFormal
    //    /// <summary>���W������ ����v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���W������ ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string RegiProcDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  RegiProcDateAdInFormal
    //    /// <summary>���W������ ����(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���W������ ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string RegiProcDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  CashRegisterNo
    //    /// <summary>���W�ԍ��v���p�e�B</summary>
    //    /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���W�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CashRegisterNo
    //    {
    //        get { return _cashRegisterNo; }
    //        set { _cashRegisterNo = value; }
    //    }

    //    /// public propaty name  :  PosReceiptNo
    //    /// <summary>POS���V�[�g�ԍ��v���p�e�B</summary>
    //    /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   POS���V�[�g�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 PosReceiptNo
    //    {
    //        get { return _posReceiptNo; }
    //        set { _posReceiptNo = value; }
    //    }

    //    /// public propaty name  :  DetailRowCount
    //    /// <summary>���׍s���v���p�e�B</summary>
    //    /// <value>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���׍s���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DetailRowCount
    //    {
    //        get { return _detailRowCount; }
    //        set { _detailRowCount = value; }
    //    }

    //    /// public propaty name  :  EdiSendDate
    //    /// <summary>�d�c�h���M���v���p�e�B</summary>
    //    /// <value>YYYYMMDD �iErectricDataInterface�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h���M���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime EdiSendDate
    //    {
    //        get { return _ediSendDate; }
    //        set { _ediSendDate = value; }
    //    }

    //    /// public propaty name  :  EdiSendDateJpFormal
    //    /// <summary>�d�c�h���M�� �a��v���p�e�B</summary>
    //    /// <value>YYYYMMDD �iErectricDataInterface�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h���M�� �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiSendDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiSendDateJpInFormal
    //    /// <summary>�d�c�h���M�� �a��(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD �iErectricDataInterface�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h���M�� �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiSendDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiSendDateAdFormal
    //    /// <summary>�d�c�h���M�� ����v���p�e�B</summary>
    //    /// <value>YYYYMMDD �iErectricDataInterface�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h���M�� ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiSendDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiSendDateAdInFormal
    //    /// <summary>�d�c�h���M�� ����(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD �iErectricDataInterface�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h���M�� ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiSendDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDate
    //    /// <summary>�d�c�h�捞���v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h�捞���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime EdiTakeInDate
    //    {
    //        get { return _ediTakeInDate; }
    //        set { _ediTakeInDate = value; }
    //    }

    //    /// public propaty name  :  EdiTakeInDateJpFormal
    //    /// <summary>�d�c�h�捞�� �a��v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h�捞�� �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiTakeInDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDateJpInFormal
    //    /// <summary>�d�c�h�捞�� �a��(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h�捞�� �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiTakeInDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDateAdFormal
    //    /// <summary>�d�c�h�捞�� ����v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h�捞�� ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiTakeInDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDateAdInFormal
    //    /// <summary>�d�c�h�捞�� ����(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�c�h�捞�� ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EdiTakeInDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
    //    /// <value>UserOrderEntory</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get { return _uoeRemark1; }
    //        set { _uoeRemark1 = value; }
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get { return _uoeRemark2; }
    //        set { _uoeRemark2 = value; }
    //    }

    //    /// public propaty name  :  SlipPrintDivCd
    //    /// <summary>�`�[���s�敪�v���p�e�B</summary>
    //    /// <value>0:���Ȃ� 1:����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���s�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SlipPrintDivCd
    //    {
    //        get { return _slipPrintDivCd; }
    //        set { _slipPrintDivCd = value; }
    //    }

    //    /// public propaty name  :  SlipPrintFinishCd
    //    /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
    //    /// <value>0:�����s 1:���s��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SlipPrintFinishCd
    //    {
    //        get { return _slipPrintFinishCd; }
    //        set { _slipPrintFinishCd = value; }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDate
    //    /// <summary>����`�[���s���v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���s���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SalesSlipPrintDate
    //    {
    //        get { return _salesSlipPrintDate; }
    //        set { _salesSlipPrintDate = value; }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateJpFormal
    //    /// <summary>����`�[���s�� �a��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���s�� �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateJpInFormal
    //    /// <summary>����`�[���s�� �a��(��)�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���s�� �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateAdFormal
    //    /// <summary>����`�[���s�� ����v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���s�� ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateAdInFormal
    //    /// <summary>����`�[���s�� ����(��)�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���s�� ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  BusinessTypeCode
    //    /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BusinessTypeCode
    //    {
    //        get { return _businessTypeCode; }
    //        set { _businessTypeCode = value; }
    //    }

    //    /// public propaty name  :  BusinessTypeName
    //    /// <summary>�Ǝ햼�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string BusinessTypeName
    //    {
    //        get { return _businessTypeName; }
    //        set { _businessTypeName = value; }
    //    }

    //    /// public propaty name  :  OrderNumber
    //    /// <summary>�����ԍ��v���p�e�B</summary>
    //    /// <value>����`����"��"�̎��ɃZ�b�g</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string OrderNumber
    //    {
    //        get { return _orderNumber; }
    //        set { _orderNumber = value; }
    //    }

    //    /// public propaty name  :  DeliveredGoodsDiv
    //    /// <summary>�[�i�敪�v���p�e�B</summary>
    //    /// <value>��) 1:�z�B,2:�X���n��,3:����,�c</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DeliveredGoodsDiv
    //    {
    //        get { return _deliveredGoodsDiv; }
    //        set { _deliveredGoodsDiv = value; }
    //    }

    //    /// public propaty name  :  DeliveredGoodsDivNm
    //    /// <summary>�[�i�敪���̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string DeliveredGoodsDivNm
    //    {
    //        get { return _deliveredGoodsDivNm; }
    //        set { _deliveredGoodsDivNm = value; }
    //    }

    //    /// public propaty name  :  SalesAreaCode
    //    /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
    //    /// <value>�n��R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesAreaCode
    //    {
    //        get { return _salesAreaCode; }
    //        set { _salesAreaCode = value; }
    //    }

    //    /// public propaty name  :  SalesAreaName
    //    /// <summary>�̔��G���A���̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesAreaName
    //    {
    //        get { return _salesAreaName; }
    //        set { _salesAreaName = value; }
    //    }

    //    /// public propaty name  :  ReconcileFlag
    //    /// <summary>�����t���O�v���p�e�B</summary>
    //    /// <value>0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����t���O�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ReconcileFlag
    //    {
    //        get { return _reconcileFlag; }
    //        set { _reconcileFlag = value; }
    //    }

    //    /// public propaty name  :  SlipPrtSetPaperId
    //    /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
    //    /// <value>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipPrtSetPaperId
    //    {
    //        get { return _slipPrtSetPaperId; }
    //        set { _slipPrtSetPaperId = value; }
    //    }

    //    /// public propaty name  :  CompleteCd
    //    /// <summary>�ꎮ�`�[�敪�v���p�e�B</summary>
    //    /// <value>0:�ʏ�`�[,1:�ꎮ�`�[</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ꎮ�`�[�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CompleteCd
    //    {
    //        get { return _completeCd; }
    //        set { _completeCd = value; }
    //    }

    //    /// public propaty name  :  SalesPriceFracProcCd
    //    /// <summary>������z�[�������敪�v���p�e�B</summary>
    //    /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������z�[�������敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesPriceFracProcCd
    //    {
    //        get { return _salesPriceFracProcCd; }
    //        set { _salesPriceFracProcCd = value; }
    //    }

    //    /// public propaty name  :  StockGoodsTtlTaxExc
    //    /// <summary>�݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</summary>
    //    /// <value>�݌Ɏ��敪���O�̖��׋��z�̏W�v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockGoodsTtlTaxExc
    //    {
    //        get { return _stockGoodsTtlTaxExc; }
    //        set { _stockGoodsTtlTaxExc = value; }
    //    }

    //    /// public propaty name  :  PureGoodsTtlTaxExc
    //    /// <summary>�������i���v���z�i�Ŕ��j�v���p�e�B</summary>
    //    /// <value>���i�������O�̖��׋��z�̏W�v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������i���v���z�i�Ŕ��j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 PureGoodsTtlTaxExc
    //    {
    //        get { return _pureGoodsTtlTaxExc; }
    //        set { _pureGoodsTtlTaxExc = value; }
    //    }

    //    /// public propaty name  :  ListPricePrintDiv
    //    /// <summary>�艿����敪�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �艿����敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ListPricePrintDiv
    //    {
    //        get { return _listPricePrintDiv; }
    //        set { _listPricePrintDiv = value; }
    //    }

    //    /// public propaty name  :  EraNameDispCd1
    //    /// <summary>�����\���敪�P�v���p�e�B</summary>
    //    /// <value>�ʏ�@�@0:����@1:�a��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����\���敪�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EraNameDispCd1
    //    {
    //        get { return _eraNameDispCd1; }
    //        set { _eraNameDispCd1 = value; }
    //    }

    //    /// public propaty name  :  EstimaTaxDivCd
    //    /// <summary>���Ϗ���ŋ敪�v���p�e�B</summary>
    //    /// <value>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ϗ���ŋ敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EstimaTaxDivCd
    //    {
    //        get { return _estimaTaxDivCd; }
    //        set { _estimaTaxDivCd = value; }
    //    }

    //    /// public propaty name  :  EstimateFormPrtCd
    //    /// <summary>���Ϗ�����敪�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ϗ�����敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EstimateFormPrtCd
    //    {
    //        get { return _estimateFormPrtCd; }
    //        set { _estimateFormPrtCd = value; }
    //    }

    //    /// public propaty name  :  EstimateSubject
    //    /// <summary>���ό����v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ό����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateSubject
    //    {
    //        get { return _estimateSubject; }
    //        set { _estimateSubject = value; }
    //    }

    //    /// public propaty name  :  Footnotes1
    //    /// <summary>�r���P�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �r���P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string Footnotes1
    //    {
    //        get { return _footnotes1; }
    //        set { _footnotes1 = value; }
    //    }

    //    /// public propaty name  :  Footnotes2
    //    /// <summary>�r���Q�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �r���Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string Footnotes2
    //    {
    //        get { return _footnotes2; }
    //        set { _footnotes2 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle1
    //    /// <summary>���σ^�C�g���P�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���σ^�C�g���P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateTitle1
    //    {
    //        get { return _estimateTitle1; }
    //        set { _estimateTitle1 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle2
    //    /// <summary>���σ^�C�g���Q�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���σ^�C�g���Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateTitle2
    //    {
    //        get { return _estimateTitle2; }
    //        set { _estimateTitle2 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle3
    //    /// <summary>���σ^�C�g���R�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���σ^�C�g���R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateTitle3
    //    {
    //        get { return _estimateTitle3; }
    //        set { _estimateTitle3 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle4
    //    /// <summary>���σ^�C�g���S�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���σ^�C�g���S�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateTitle4
    //    {
    //        get { return _estimateTitle4; }
    //        set { _estimateTitle4 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle5
    //    /// <summary>���σ^�C�g���T�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���σ^�C�g���T�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateTitle5
    //    {
    //        get { return _estimateTitle5; }
    //        set { _estimateTitle5 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote1
    //    /// <summary>���ϔ��l�P�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϔ��l�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateNote1
    //    {
    //        get { return _estimateNote1; }
    //        set { _estimateNote1 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote2
    //    /// <summary>���ϔ��l�Q�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϔ��l�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateNote2
    //    {
    //        get { return _estimateNote2; }
    //        set { _estimateNote2 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote3
    //    /// <summary>���ϔ��l�R�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϔ��l�R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateNote3
    //    {
    //        get { return _estimateNote3; }
    //        set { _estimateNote3 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote4
    //    /// <summary>���ϔ��l�S�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϔ��l�S�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateNote4
    //    {
    //        get { return _estimateNote4; }
    //        set { _estimateNote4 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote5
    //    /// <summary>���ϔ��l�T�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϔ��l�T�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateNote5
    //    {
    //        get { return _estimateNote5; }
    //        set { _estimateNote5 = value; }
    //    }

    //    /// public propaty name  :  EstimateValidityDate
    //    /// <summary>���ϗL�������v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϗL�������v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime EstimateValidityDate
    //    {
    //        get { return _estimateValidityDate; }
    //        set { _estimateValidityDate = value; }
    //    }

    //    /// public propaty name  :  EstimateValidityDateJpFormal
    //    /// <summary>���ϗL������ �a��v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϗL������ �a��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateValidityDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EstimateValidityDateJpInFormal
    //    /// <summary>���ϗL������ �a��(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϗL������ �a��(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateValidityDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EstimateValidityDateAdFormal
    //    /// <summary>���ϗL������ ����v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϗL������ ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateValidityDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EstimateValidityDateAdInFormal
    //    /// <summary>���ϗL������ ����(��)�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ϗL������ ����(��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EstimateValidityDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  PartsNoPrtCd
    //    /// <summary>�i�Ԉ󎚋敪�v���p�e�B</summary>
    //    /// <value>0:���Ȃ�,1:����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i�Ԉ󎚋敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 PartsNoPrtCd
    //    {
    //        get { return _partsNoPrtCd; }
    //        set { _partsNoPrtCd = value; }
    //    }

    //    /// public propaty name  :  OptionPringDivCd
    //    /// <summary>�I�v�V�����󎚋敪�v���p�e�B</summary>
    //    /// <value>0:���Ȃ�,1:����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I�v�V�����󎚋敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 OptionPringDivCd
    //    {
    //        get { return _optionPringDivCd; }
    //        set { _optionPringDivCd = value; }
    //    }

    //    /// public propaty name  :  RateUseCode
    //    /// <summary>�|���g�p�敪�v���p�e�B</summary>
    //    /// <value>0:�������艿 1:�|���w��,2:�|���ݒ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �|���g�p�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 RateUseCode
    //    {
    //        get { return _rateUseCode; }
    //        set { _rateUseCode = value; }
    //    }

    //    /// public propaty name  :  CarMngCode
    //    /// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
    //    /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CarMngCode
    //    {
    //        get { return _carMngCode; }
    //        set { _carMngCode = value; }
    //    }

    //    /// public propaty name  :  ModelDesignationNo
    //    /// <summary>�^���w��ԍ��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ModelDesignationNo
    //    {
    //        get { return _modelDesignationNo; }
    //        set { _modelDesignationNo = value; }
    //    }

    //    /// public propaty name  :  CategoryNo
    //    /// <summary>�ޕʔԍ��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CategoryNo
    //    {
    //        get { return _categoryNo; }
    //        set { _categoryNo = value; }
    //    }

    //    /// public propaty name  :  MakerFullName
    //    /// <summary>���[�J�[�S�p���̃v���p�e�B</summary>
    //    /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���[�J�[�S�p���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string MakerFullName
    //    {
    //        get { return _makerFullName; }
    //        set { _makerFullName = value; }
    //    }

    //    /// public propaty name  :  FullModel
    //    /// <summary>�^���i�t���^�j�v���p�e�B</summary>
    //    /// <value>�t���^��(44���p)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FullModel
    //    {
    //        get { return _fullModel; }
    //        set { _fullModel = value; }
    //    }

    //    /// public propaty name  :  EnterpriseName
    //    /// <summary>��Ɩ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EnterpriseName
    //    {
    //        get { return _enterpriseName; }
    //        set { _enterpriseName = value; }
    //    }

    //    /// public propaty name  :  ResultsAddUpSecNm
    //    /// <summary>���ьv�㋒�_���̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ьv�㋒�_���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ResultsAddUpSecNm
    //    {
    //        get { return _resultsAddUpSecNm; }
    //        set { _resultsAddUpSecNm = value; }
    //    }


    //    /// <summary>
    //    /// ����`�[�������o���ʃR���X�g���N�^
    //    /// </summary>
    //    /// <returns>SalesSlipSearchResult�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SalesSlipSearchResult()
    //    {
    //    }

    //    /// <summary>
    //    /// ����`�[�������o���ʃR���X�g���N�^
    //    /// </summary>
    //    /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
    //    /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
    //    /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  )</param>
    //    /// <param name="salesSlipNum">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
    //    /// <param name="sectionCode">���_�R�[�h</param>
    //    /// <param name="sectionGuideNm">���_�K�C�h����</param>
    //    /// <param name="subSectionCode">����R�[�h</param>
    //    /// <param name="subSectionName">���喼��</param>
    //    /// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
    //    /// <param name="debitNLnkSalesSlNum">�ԍ��A������`�[�ԍ�(�ԍ��̑��������`�[�ԍ�)</param>
    //    /// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi)</param>
    //    /// <param name="salesGoodsCd">���㏤�i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����))</param>
    //    /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
    //    /// <param name="salesInpSecCd">������͋��_�R�[�h(�����^ �������͂������_�R�[�h)</param>
    //    /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h(�����^)</param>
    //    /// <param name="resultsAddUpSecCd">���ьv�㋒�_�R�[�h(���ьv����s����Ɠ��̋��_�R�[�h)</param>
    //    /// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
    //    /// <param name="searchSlipDate">�`�[�������t(YYYYMMDD�@�i�X�V�N�����j)</param>
    //    /// <param name="shipmentDay">�o�ד��t(YYYYMMDD)</param>
    //    /// <param name="salesDate">������t(���ϓ��A�󒍓��A����������˂�B(YYYYMMDD))</param>
    //    /// <param name="addUpADate">�v����t(�������@(YYYYMMDD))</param>
    //    /// <param name="delayPaymentDiv">�����敪(0:����(�����Ȃ�),1:����,2:�ė����c9:9������)</param>
    //    /// <param name="estimateFormNo">���Ϗ��ԍ�</param>
    //    /// <param name="estimateDivide">���ϋ敪(1:�ʏ팩�ρ@2:�P�����ρ@3:��������)</param>
    //    /// <param name="inputAgenCd">���͒S���҃R�[�h(���O�C���S���ҁi�t�r�a�j)</param>
    //    /// <param name="inputAgenNm">���͒S���Җ���</param>
    //    /// <param name="salesInputCode">������͎҃R�[�h(���͒S���ҁi���s�ҁj)</param>
    //    /// <param name="salesInputName">������͎Җ���</param>
    //    /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(��t�S���ҁi�󒍎ҁj)</param>
    //    /// <param name="frontEmployeeNm">��t�]�ƈ�����</param>
    //    /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(�v��S���ҁi�S���ҁj)</param>
    //    /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
    //    /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
    //    /// <param name="ttlAmntDispRateApy">���z�\���|���K�p�敪(0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��)</param>
    //    /// <param name="salesTotalTaxInc">����`�[���v�i�ō��݁j(���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz)</param>
    //    /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ����j(���㐳�����z�{����l�����z�v�i�Ŕ����j)</param>
    //    /// <param name="salesPrtTotalTaxInc">���㕔�i���v�i�ō��݁j(���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j)</param>
    //    /// <param name="salesPrtTotalTaxExc">���㕔�i���v�i�Ŕ����j(���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j)</param>
    //    /// <param name="salesWorkTotalTaxInc">�����ƍ��v�i�ō��݁j(�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j)</param>
    //    /// <param name="salesWorkTotalTaxExc">�����ƍ��v�i�Ŕ����j(�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j)</param>
    //    /// <param name="salesSubtotalTaxInc">���㏬�v�i�ō��݁j(�l����̖��׋��z�̍��v�i��ېŊ܂܂��j)</param>
    //    /// <param name="salesSubtotalTaxExc">���㏬�v�i�Ŕ����j(�l����̖��׋��z�̍��v�i��ېŊ܂܂��j)</param>
    //    /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��݁j(���i���׋��z�̐ō����v)</param>
    //    /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ����j(���i���׋��z�̐Ŕ����v)</param>
    //    /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��݁j(��Ɩ��׋��z�̐ō����v)</param>
    //    /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ����j(��Ɩ��׋��z�̐Ŕ����v)</param>
    //    /// <param name="salesNetPrice">���㐳�����z(�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j)</param>
    //    /// <param name="salesSubtotalTax">���㏬�v�i�Łj(�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j)</param>
    //    /// <param name="itdedSalesOutTax">����O�őΏۊz(���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j )</param>
    //    /// <param name="itdedSalesInTax">������őΏۊz(��ېőΏۋ��z�̏W�v�i�l���܂܂��j)</param>
    //    /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz(������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�)</param>
    //    /// <param name="salesOutTax">������z����Ŋz�i�O�Łj(�l���O�̊O�ŏ��i�̏����)</param>
    //    /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj(�l���O�̓��ŏ��i�̏����)</param>
    //    /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ����j</param>
    //    /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v(�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j)</param>
    //    /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v(���ŏ��i�l���̓��őΏۊz�i�Ŕ��j)</param>
    //    /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ����j(���i�l���z�i�Ŕ����j)</param>
    //    /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��݁j(���i�l���z�i�ō��݁j)</param>
    //    /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ����j(��ƒl���z�i�Ŕ����j)</param>
    //    /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��݁j(��ƒl���z�i�ō��݁j)</param>
    //    /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v(��ېŏ��i�l���̔�ېőΏۊz)</param>
    //    /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj(�O�ŏ��i�l���̏���Ŋz)</param>
    //    /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
    //    /// <param name="partsDiscountRate">���i�l����(���v�ɑ΂��Ă̕��i�l����)</param>
    //    /// <param name="ravorDiscountRate">�H���l����(���v�ɑ΂��Ă̍H���l����)</param>
    //    /// <param name="totalCost">�������z�v</param>
    //    /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�)</param>
    //    /// <param name="consTaxRate">����Őŗ�(�ύX2007/8/22(�^,��) ����)</param>
    //    /// <param name="fractionProcCd">�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj)</param>
    //    /// <param name="accRecConsTax">���|�����</param>
    //    /// <param name="autoDepositCd">���������敪(0:�ʏ����,1:��������)</param>
    //    /// <param name="autoDepositSlipNo">���������`�[�ԍ�(�����������̓����`�[�ԍ�)</param>
    //    /// <param name="depositAllowanceTtl">�����������v�z(�a����������v�z���܂�)</param>
    //    /// <param name="depositAlwcBlnce">���������c��</param>
    //    /// <param name="claimCode">������R�[�h</param>
    //    /// <param name="claimSnm">�����旪��</param>
    //    /// <param name="customerCode">���Ӑ�R�[�h</param>
    //    /// <param name="customerName">���Ӑ於��</param>
    //    /// <param name="customerName2">���Ӑ於��2</param>
    //    /// <param name="customerSnm">���Ӑ旪��</param>
    //    /// <param name="honorificTitle">�h��</param>
    //    /// <param name="outputName">��������</param>
    //    /// <param name="custSlipNo">���Ӑ�`�[�ԍ�</param>
    //    /// <param name="slipAddressDiv">�`�[�Z���敪(1:���Ӑ�,2:�[����)</param>
    //    /// <param name="addresseeCode">�[�i��R�[�h</param>
    //    /// <param name="addresseeName">�[�i�於��</param>
    //    /// <param name="addresseeName2">�[�i�於��2(�ǉ�(�o�^�R��) ����)</param>
    //    /// <param name="addresseePostNo">�[�i��X�֔ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
    //    /// <param name="addresseeAddr1">�[�i��Z��1(�s���{���s��S�E�����E��)(�`�[�Z���敪�ɏ]�����e)</param>
    //    /// <param name="addresseeAddr3">�[�i��Z��3(�Ԓn)(�`�[�Z���敪�ɏ]�����e)</param>
    //    /// <param name="addresseeAddr4">�[�i��Z��4(�A�p�[�g����)(�`�[�Z���敪�ɏ]�����e)</param>
    //    /// <param name="addresseeTelNo">�[�i��d�b�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
    //    /// <param name="addresseeFaxNo">�[�i��FAX�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
    //    /// <param name="partySaleSlipNum">�����`�[�ԍ�(���Ӑ撍���ԍ��i���`�ԍ��j)</param>
    //    /// <param name="slipNote">�`�[���l</param>
    //    /// <param name="slipNote2">�`�[���l�Q</param>
    //    /// <param name="slipNote3">�`�[���l�R</param>
    //    /// <param name="retGoodsReasonDiv">�ԕi���R�R�[�h</param>
    //    /// <param name="retGoodsReason">�ԕi���R</param>
    //    /// <param name="regiProcDate">���W������(YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
    //    /// <param name="cashRegisterNo">���W�ԍ�(�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
    //    /// <param name="posReceiptNo">POS���V�[�g�ԍ�(�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
    //    /// <param name="detailRowCount">���׍s��(�`�[���̖��ׂ̍s���i����p���ׂ͏����j)</param>
    //    /// <param name="ediSendDate">�d�c�h���M��(YYYYMMDD �iErectricDataInterface�j)</param>
    //    /// <param name="ediTakeInDate">�d�c�h�捞��(YYYYMMDD)</param>
    //    /// <param name="uoeRemark1">�t�n�d���}�[�N�P(UserOrderEntory)</param>
    //    /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
    //    /// <param name="slipPrintDivCd">�`�[���s�敪(0:���Ȃ� 1:����)</param>
    //    /// <param name="slipPrintFinishCd">�`�[���s�ϋ敪(0:�����s 1:���s��)</param>
    //    /// <param name="salesSlipPrintDate">����`�[���s��</param>
    //    /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
    //    /// <param name="businessTypeName">�Ǝ햼��</param>
    //    /// <param name="orderNumber">�����ԍ�(����`����"��"�̎��ɃZ�b�g)</param>
    //    /// <param name="deliveredGoodsDiv">�[�i�敪(��) 1:�z�B,2:�X���n��,3:����,�c)</param>
    //    /// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
    //    /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
    //    /// <param name="salesAreaName">�̔��G���A����</param>
    //    /// <param name="reconcileFlag">�����t���O(0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j)</param>
    //    /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��)</param>
    //    /// <param name="completeCd">�ꎮ�`�[�敪(0:�ʏ�`�[,1:�ꎮ�`�[)</param>
    //    /// <param name="salesPriceFracProcCd">������z�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j)</param>
    //    /// <param name="stockGoodsTtlTaxExc">�݌ɏ��i���v���z�i�Ŕ��j(�݌Ɏ��敪���O�̖��׋��z�̏W�v)</param>
    //    /// <param name="pureGoodsTtlTaxExc">�������i���v���z�i�Ŕ��j(���i�������O�̖��׋��z�̏W�v)</param>
    //    /// <param name="listPricePrintDiv">�艿����敪</param>
    //    /// <param name="eraNameDispCd1">�����\���敪�P(�ʏ�@�@0:����@1:�a��)</param>
    //    /// <param name="estimaTaxDivCd">���Ϗ���ŋ敪(0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j)</param>
    //    /// <param name="estimateFormPrtCd">���Ϗ�����敪</param>
    //    /// <param name="estimateSubject">���ό���</param>
    //    /// <param name="footnotes1">�r���P</param>
    //    /// <param name="footnotes2">�r���Q</param>
    //    /// <param name="estimateTitle1">���σ^�C�g���P</param>
    //    /// <param name="estimateTitle2">���σ^�C�g���Q</param>
    //    /// <param name="estimateTitle3">���σ^�C�g���R</param>
    //    /// <param name="estimateTitle4">���σ^�C�g���S</param>
    //    /// <param name="estimateTitle5">���σ^�C�g���T</param>
    //    /// <param name="estimateNote1">���ϔ��l�P</param>
    //    /// <param name="estimateNote2">���ϔ��l�Q</param>
    //    /// <param name="estimateNote3">���ϔ��l�R</param>
    //    /// <param name="estimateNote4">���ϔ��l�S</param>
    //    /// <param name="estimateNote5">���ϔ��l�T</param>
    //    /// <param name="estimateValidityDate">���ϗL������(YYYYMMDD)</param>
    //    /// <param name="partsNoPrtCd">�i�Ԉ󎚋敪(0:���Ȃ�,1:����)</param>
    //    /// <param name="optionPringDivCd">�I�v�V�����󎚋敪(0:���Ȃ�,1:����)</param>
    //    /// <param name="rateUseCode">�|���g�p�敪(0:�������艿 1:�|���w��,2:�|���ݒ�)</param>
    //    /// <param name="carMngCode">�ԗ��Ǘ��ԍ�(�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ)</param>
    //    /// <param name="modelDesignationNo">�^���w��ԍ�</param>
    //    /// <param name="categoryNo">�ޕʔԍ�</param>
    //    /// <param name="makerFullName">���[�J�[�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
    //    /// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
    //    /// <param name="enterpriseName">��Ɩ���</param>
    //    /// <param name="resultsAddUpSecNm">���ьv�㋒�_����</param>
    //    /// <returns>SalesSlipSearchResult�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SalesSlipSearchResult(string enterpriseCode, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, string sectionGuideNm, Int32 subSectionCode, string subSectionName, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, string carMngCode, Int32 modelDesignationNo, Int32 categoryNo, string makerFullName, string fullModel, string enterpriseName, string resultsAddUpSecNm)
    //    {
    //        this._enterpriseCode = enterpriseCode;
    //        this._logicalDeleteCode = logicalDeleteCode;
    //        this._acptAnOdrStatus = acptAnOdrStatus;
    //        this._salesSlipNum = salesSlipNum;
    //        this._sectionCode = sectionCode;
    //        this._sectionGuideNm = sectionGuideNm;
    //        this._subSectionCode = subSectionCode;
    //        this._subSectionName = subSectionName;
    //        this._debitNoteDiv = debitNoteDiv;
    //        this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
    //        this._salesSlipCd = salesSlipCd;
    //        this._salesGoodsCd = salesGoodsCd;
    //        this._accRecDivCd = accRecDivCd;
    //        this._salesInpSecCd = salesInpSecCd;
    //        this._demandAddUpSecCd = demandAddUpSecCd;
    //        this._resultsAddUpSecCd = resultsAddUpSecCd;
    //        this._updateSecCd = updateSecCd;
    //        this.SearchSlipDate = searchSlipDate;
    //        this.ShipmentDay = shipmentDay;
    //        this.SalesDate = salesDate;
    //        this.AddUpADate = addUpADate;
    //        this._delayPaymentDiv = delayPaymentDiv;
    //        this._estimateFormNo = estimateFormNo;
    //        this._estimateDivide = estimateDivide;
    //        this._inputAgenCd = inputAgenCd;
    //        this._inputAgenNm = inputAgenNm;
    //        this._salesInputCode = salesInputCode;
    //        this._salesInputName = salesInputName;
    //        this._frontEmployeeCd = frontEmployeeCd;
    //        this._frontEmployeeNm = frontEmployeeNm;
    //        this._salesEmployeeCd = salesEmployeeCd;
    //        this._salesEmployeeNm = salesEmployeeNm;
    //        this._totalAmountDispWayCd = totalAmountDispWayCd;
    //        this._ttlAmntDispRateApy = ttlAmntDispRateApy;
    //        this._salesTotalTaxInc = salesTotalTaxInc;
    //        this._salesTotalTaxExc = salesTotalTaxExc;
    //        this._salesPrtTotalTaxInc = salesPrtTotalTaxInc;
    //        this._salesPrtTotalTaxExc = salesPrtTotalTaxExc;
    //        this._salesWorkTotalTaxInc = salesWorkTotalTaxInc;
    //        this._salesWorkTotalTaxExc = salesWorkTotalTaxExc;
    //        this._salesSubtotalTaxInc = salesSubtotalTaxInc;
    //        this._salesSubtotalTaxExc = salesSubtotalTaxExc;
    //        this._salesPrtSubttlInc = salesPrtSubttlInc;
    //        this._salesPrtSubttlExc = salesPrtSubttlExc;
    //        this._salesWorkSubttlInc = salesWorkSubttlInc;
    //        this._salesWorkSubttlExc = salesWorkSubttlExc;
    //        this._salesNetPrice = salesNetPrice;
    //        this._salesSubtotalTax = salesSubtotalTax;
    //        this._itdedSalesOutTax = itdedSalesOutTax;
    //        this._itdedSalesInTax = itdedSalesInTax;
    //        this._salSubttlSubToTaxFre = salSubttlSubToTaxFre;
    //        this._salesOutTax = salesOutTax;
    //        this._salAmntConsTaxInclu = salAmntConsTaxInclu;
    //        this._salesDisTtlTaxExc = salesDisTtlTaxExc;
    //        this._itdedSalesDisOutTax = itdedSalesDisOutTax;
    //        this._itdedSalesDisInTax = itdedSalesDisInTax;
    //        this._itdedPartsDisOutTax = itdedPartsDisOutTax;
    //        this._itdedPartsDisInTax = itdedPartsDisInTax;
    //        this._itdedWorkDisOutTax = itdedWorkDisOutTax;
    //        this._itdedWorkDisInTax = itdedWorkDisInTax;
    //        this._itdedSalesDisTaxFre = itdedSalesDisTaxFre;
    //        this._salesDisOutTax = salesDisOutTax;
    //        this._salesDisTtlTaxInclu = salesDisTtlTaxInclu;
    //        this._partsDiscountRate = partsDiscountRate;
    //        this._ravorDiscountRate = ravorDiscountRate;
    //        this._totalCost = totalCost;
    //        this._consTaxLayMethod = consTaxLayMethod;
    //        this._consTaxRate = consTaxRate;
    //        this._fractionProcCd = fractionProcCd;
    //        this._accRecConsTax = accRecConsTax;
    //        this._autoDepositCd = autoDepositCd;
    //        this._autoDepositSlipNo = autoDepositSlipNo;
    //        this._depositAllowanceTtl = depositAllowanceTtl;
    //        this._depositAlwcBlnce = depositAlwcBlnce;
    //        this._claimCode = claimCode;
    //        this._claimSnm = claimSnm;
    //        this._customerCode = customerCode;
    //        this._customerName = customerName;
    //        this._customerName2 = customerName2;
    //        this._customerSnm = customerSnm;
    //        this._honorificTitle = honorificTitle;
    //        this._outputName = outputName;
    //        this._custSlipNo = custSlipNo;
    //        this._slipAddressDiv = slipAddressDiv;
    //        this._addresseeCode = addresseeCode;
    //        this._addresseeName = addresseeName;
    //        this._addresseeName2 = addresseeName2;
    //        this._addresseePostNo = addresseePostNo;
    //        this._addresseeAddr1 = addresseeAddr1;
    //        this._addresseeAddr3 = addresseeAddr3;
    //        this._addresseeAddr4 = addresseeAddr4;
    //        this._addresseeTelNo = addresseeTelNo;
    //        this._addresseeFaxNo = addresseeFaxNo;
    //        this._partySaleSlipNum = partySaleSlipNum;
    //        this._slipNote = slipNote;
    //        this._slipNote2 = slipNote2;
    //        this._slipNote3 = slipNote3;
    //        this._retGoodsReasonDiv = retGoodsReasonDiv;
    //        this._retGoodsReason = retGoodsReason;
    //        this.RegiProcDate = regiProcDate;
    //        this._cashRegisterNo = cashRegisterNo;
    //        this._posReceiptNo = posReceiptNo;
    //        this._detailRowCount = detailRowCount;
    //        this.EdiSendDate = ediSendDate;
    //        this.EdiTakeInDate = ediTakeInDate;
    //        this._uoeRemark1 = uoeRemark1;
    //        this._uoeRemark2 = uoeRemark2;
    //        this._slipPrintDivCd = slipPrintDivCd;
    //        this._slipPrintFinishCd = slipPrintFinishCd;
    //        this.SalesSlipPrintDate = salesSlipPrintDate;
    //        this._businessTypeCode = businessTypeCode;
    //        this._businessTypeName = businessTypeName;
    //        this._orderNumber = orderNumber;
    //        this._deliveredGoodsDiv = deliveredGoodsDiv;
    //        this._deliveredGoodsDivNm = deliveredGoodsDivNm;
    //        this._salesAreaCode = salesAreaCode;
    //        this._salesAreaName = salesAreaName;
    //        this._reconcileFlag = reconcileFlag;
    //        this._slipPrtSetPaperId = slipPrtSetPaperId;
    //        this._completeCd = completeCd;
    //        this._salesPriceFracProcCd = salesPriceFracProcCd;
    //        this._stockGoodsTtlTaxExc = stockGoodsTtlTaxExc;
    //        this._pureGoodsTtlTaxExc = pureGoodsTtlTaxExc;
    //        this._listPricePrintDiv = listPricePrintDiv;
    //        this._eraNameDispCd1 = eraNameDispCd1;
    //        this._estimaTaxDivCd = estimaTaxDivCd;
    //        this._estimateFormPrtCd = estimateFormPrtCd;
    //        this._estimateSubject = estimateSubject;
    //        this._footnotes1 = footnotes1;
    //        this._footnotes2 = footnotes2;
    //        this._estimateTitle1 = estimateTitle1;
    //        this._estimateTitle2 = estimateTitle2;
    //        this._estimateTitle3 = estimateTitle3;
    //        this._estimateTitle4 = estimateTitle4;
    //        this._estimateTitle5 = estimateTitle5;
    //        this._estimateNote1 = estimateNote1;
    //        this._estimateNote2 = estimateNote2;
    //        this._estimateNote3 = estimateNote3;
    //        this._estimateNote4 = estimateNote4;
    //        this._estimateNote5 = estimateNote5;
    //        this.EstimateValidityDate = estimateValidityDate;
    //        this._partsNoPrtCd = partsNoPrtCd;
    //        this._optionPringDivCd = optionPringDivCd;
    //        this._rateUseCode = rateUseCode;
    //        this._carMngCode = carMngCode;
    //        this._modelDesignationNo = modelDesignationNo;
    //        this._categoryNo = categoryNo;
    //        this._makerFullName = makerFullName;
    //        this._fullModel = fullModel;
    //        this._enterpriseName = enterpriseName;
    //        this._resultsAddUpSecNm = resultsAddUpSecNm;

    //    }

    //    /// <summary>
    //    /// ����`�[�������o���ʕ�������
    //    /// </summary>
    //    /// <returns>SalesSlipSearchResult�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesSlipSearchResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SalesSlipSearchResult Clone()
    //    {
    //        return new SalesSlipSearchResult(this._enterpriseCode, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._sectionGuideNm, this._subSectionCode, this._subSectionName, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._carMngCode, this._modelDesignationNo, this._categoryNo, this._makerFullName, this._fullModel, this._enterpriseName, this._resultsAddUpSecNm);
    //    }

    //    /// <summary>
    //    /// ����`�[�������o���ʔ�r����
    //    /// </summary>
    //    /// <param name="target">��r�Ώۂ�SalesSlipSearchResult�N���X�̃C���X�^���X</param>
    //    /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public bool Equals(SalesSlipSearchResult target)
    //    {
    //        return ((this.EnterpriseCode == target.EnterpriseCode)
    //             && (this.LogicalDeleteCode == target.LogicalDeleteCode)
    //             && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
    //             && (this.SalesSlipNum == target.SalesSlipNum)
    //             && (this.SectionCode == target.SectionCode)
    //             && (this.SectionGuideNm == target.SectionGuideNm)
    //             && (this.SubSectionCode == target.SubSectionCode)
    //             && (this.SubSectionName == target.SubSectionName)
    //             && (this.DebitNoteDiv == target.DebitNoteDiv)
    //             && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
    //             && (this.SalesSlipCd == target.SalesSlipCd)
    //             && (this.SalesGoodsCd == target.SalesGoodsCd)
    //             && (this.AccRecDivCd == target.AccRecDivCd)
    //             && (this.SalesInpSecCd == target.SalesInpSecCd)
    //             && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
    //             && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
    //             && (this.UpdateSecCd == target.UpdateSecCd)
    //             && (this.SearchSlipDate == target.SearchSlipDate)
    //             && (this.ShipmentDay == target.ShipmentDay)
    //             && (this.SalesDate == target.SalesDate)
    //             && (this.AddUpADate == target.AddUpADate)
    //             && (this.DelayPaymentDiv == target.DelayPaymentDiv)
    //             && (this.EstimateFormNo == target.EstimateFormNo)
    //             && (this.EstimateDivide == target.EstimateDivide)
    //             && (this.InputAgenCd == target.InputAgenCd)
    //             && (this.InputAgenNm == target.InputAgenNm)
    //             && (this.SalesInputCode == target.SalesInputCode)
    //             && (this.SalesInputName == target.SalesInputName)
    //             && (this.FrontEmployeeCd == target.FrontEmployeeCd)
    //             && (this.FrontEmployeeNm == target.FrontEmployeeNm)
    //             && (this.SalesEmployeeCd == target.SalesEmployeeCd)
    //             && (this.SalesEmployeeNm == target.SalesEmployeeNm)
    //             && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
    //             && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
    //             && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
    //             && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
    //             && (this.SalesPrtTotalTaxInc == target.SalesPrtTotalTaxInc)
    //             && (this.SalesPrtTotalTaxExc == target.SalesPrtTotalTaxExc)
    //             && (this.SalesWorkTotalTaxInc == target.SalesWorkTotalTaxInc)
    //             && (this.SalesWorkTotalTaxExc == target.SalesWorkTotalTaxExc)
    //             && (this.SalesSubtotalTaxInc == target.SalesSubtotalTaxInc)
    //             && (this.SalesSubtotalTaxExc == target.SalesSubtotalTaxExc)
    //             && (this.SalesPrtSubttlInc == target.SalesPrtSubttlInc)
    //             && (this.SalesPrtSubttlExc == target.SalesPrtSubttlExc)
    //             && (this.SalesWorkSubttlInc == target.SalesWorkSubttlInc)
    //             && (this.SalesWorkSubttlExc == target.SalesWorkSubttlExc)
    //             && (this.SalesNetPrice == target.SalesNetPrice)
    //             && (this.SalesSubtotalTax == target.SalesSubtotalTax)
    //             && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
    //             && (this.ItdedSalesInTax == target.ItdedSalesInTax)
    //             && (this.SalSubttlSubToTaxFre == target.SalSubttlSubToTaxFre)
    //             && (this.SalesOutTax == target.SalesOutTax)
    //             && (this.SalAmntConsTaxInclu == target.SalAmntConsTaxInclu)
    //             && (this.SalesDisTtlTaxExc == target.SalesDisTtlTaxExc)
    //             && (this.ItdedSalesDisOutTax == target.ItdedSalesDisOutTax)
    //             && (this.ItdedSalesDisInTax == target.ItdedSalesDisInTax)
    //             && (this.ItdedPartsDisOutTax == target.ItdedPartsDisOutTax)
    //             && (this.ItdedPartsDisInTax == target.ItdedPartsDisInTax)
    //             && (this.ItdedWorkDisOutTax == target.ItdedWorkDisOutTax)
    //             && (this.ItdedWorkDisInTax == target.ItdedWorkDisInTax)
    //             && (this.ItdedSalesDisTaxFre == target.ItdedSalesDisTaxFre)
    //             && (this.SalesDisOutTax == target.SalesDisOutTax)
    //             && (this.SalesDisTtlTaxInclu == target.SalesDisTtlTaxInclu)
    //             && (this.PartsDiscountRate == target.PartsDiscountRate)
    //             && (this.RavorDiscountRate == target.RavorDiscountRate)
    //             && (this.TotalCost == target.TotalCost)
    //             && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
    //             && (this.ConsTaxRate == target.ConsTaxRate)
    //             && (this.FractionProcCd == target.FractionProcCd)
    //             && (this.AccRecConsTax == target.AccRecConsTax)
    //             && (this.AutoDepositCd == target.AutoDepositCd)
    //             && (this.AutoDepositSlipNo == target.AutoDepositSlipNo)
    //             && (this.DepositAllowanceTtl == target.DepositAllowanceTtl)
    //             && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
    //             && (this.ClaimCode == target.ClaimCode)
    //             && (this.ClaimSnm == target.ClaimSnm)
    //             && (this.CustomerCode == target.CustomerCode)
    //             && (this.CustomerName == target.CustomerName)
    //             && (this.CustomerName2 == target.CustomerName2)
    //             && (this.CustomerSnm == target.CustomerSnm)
    //             && (this.HonorificTitle == target.HonorificTitle)
    //             && (this.OutputName == target.OutputName)
    //             && (this.CustSlipNo == target.CustSlipNo)
    //             && (this.SlipAddressDiv == target.SlipAddressDiv)
    //             && (this.AddresseeCode == target.AddresseeCode)
    //             && (this.AddresseeName == target.AddresseeName)
    //             && (this.AddresseeName2 == target.AddresseeName2)
    //             && (this.AddresseePostNo == target.AddresseePostNo)
    //             && (this.AddresseeAddr1 == target.AddresseeAddr1)
    //             && (this.AddresseeAddr3 == target.AddresseeAddr3)
    //             && (this.AddresseeAddr4 == target.AddresseeAddr4)
    //             && (this.AddresseeTelNo == target.AddresseeTelNo)
    //             && (this.AddresseeFaxNo == target.AddresseeFaxNo)
    //             && (this.PartySaleSlipNum == target.PartySaleSlipNum)
    //             && (this.SlipNote == target.SlipNote)
    //             && (this.SlipNote2 == target.SlipNote2)
    //             && (this.SlipNote3 == target.SlipNote3)
    //             && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
    //             && (this.RetGoodsReason == target.RetGoodsReason)
    //             && (this.RegiProcDate == target.RegiProcDate)
    //             && (this.CashRegisterNo == target.CashRegisterNo)
    //             && (this.PosReceiptNo == target.PosReceiptNo)
    //             && (this.DetailRowCount == target.DetailRowCount)
    //             && (this.EdiSendDate == target.EdiSendDate)
    //             && (this.EdiTakeInDate == target.EdiTakeInDate)
    //             && (this.UoeRemark1 == target.UoeRemark1)
    //             && (this.UoeRemark2 == target.UoeRemark2)
    //             && (this.SlipPrintDivCd == target.SlipPrintDivCd)
    //             && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
    //             && (this.SalesSlipPrintDate == target.SalesSlipPrintDate)
    //             && (this.BusinessTypeCode == target.BusinessTypeCode)
    //             && (this.BusinessTypeName == target.BusinessTypeName)
    //             && (this.OrderNumber == target.OrderNumber)
    //             && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
    //             && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
    //             && (this.SalesAreaCode == target.SalesAreaCode)
    //             && (this.SalesAreaName == target.SalesAreaName)
    //             && (this.ReconcileFlag == target.ReconcileFlag)
    //             && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
    //             && (this.CompleteCd == target.CompleteCd)
    //             && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
    //             && (this.StockGoodsTtlTaxExc == target.StockGoodsTtlTaxExc)
    //             && (this.PureGoodsTtlTaxExc == target.PureGoodsTtlTaxExc)
    //             && (this.ListPricePrintDiv == target.ListPricePrintDiv)
    //             && (this.EraNameDispCd1 == target.EraNameDispCd1)
    //             && (this.EstimaTaxDivCd == target.EstimaTaxDivCd)
    //             && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
    //             && (this.EstimateSubject == target.EstimateSubject)
    //             && (this.Footnotes1 == target.Footnotes1)
    //             && (this.Footnotes2 == target.Footnotes2)
    //             && (this.EstimateTitle1 == target.EstimateTitle1)
    //             && (this.EstimateTitle2 == target.EstimateTitle2)
    //             && (this.EstimateTitle3 == target.EstimateTitle3)
    //             && (this.EstimateTitle4 == target.EstimateTitle4)
    //             && (this.EstimateTitle5 == target.EstimateTitle5)
    //             && (this.EstimateNote1 == target.EstimateNote1)
    //             && (this.EstimateNote2 == target.EstimateNote2)
    //             && (this.EstimateNote3 == target.EstimateNote3)
    //             && (this.EstimateNote4 == target.EstimateNote4)
    //             && (this.EstimateNote5 == target.EstimateNote5)
    //             && (this.EstimateValidityDate == target.EstimateValidityDate)
    //             && (this.PartsNoPrtCd == target.PartsNoPrtCd)
    //             && (this.OptionPringDivCd == target.OptionPringDivCd)
    //             && (this.RateUseCode == target.RateUseCode)
    //             && (this.CarMngCode == target.CarMngCode)
    //             && (this.ModelDesignationNo == target.ModelDesignationNo)
    //             && (this.CategoryNo == target.CategoryNo)
    //             && (this.MakerFullName == target.MakerFullName)
    //             && (this.FullModel == target.FullModel)
    //             && (this.EnterpriseName == target.EnterpriseName)
    //             && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm));
    //    }

    //    /// <summary>
    //    /// ����`�[�������o���ʔ�r����
    //    /// </summary>
    //    /// <param name="salesSlipSearchResult1">
    //    ///                    ��r����SalesSlipSearchResult�N���X�̃C���X�^���X
    //    /// </param>
    //    /// <param name="salesSlipSearchResult2">��r����SalesSlipSearchResult�N���X�̃C���X�^���X</param>
    //    /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public static bool Equals(SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2)
    //    {
    //        return ((salesSlipSearchResult1.EnterpriseCode == salesSlipSearchResult2.EnterpriseCode)
    //             && (salesSlipSearchResult1.LogicalDeleteCode == salesSlipSearchResult2.LogicalDeleteCode)
    //             && (salesSlipSearchResult1.AcptAnOdrStatus == salesSlipSearchResult2.AcptAnOdrStatus)
    //             && (salesSlipSearchResult1.SalesSlipNum == salesSlipSearchResult2.SalesSlipNum)
    //             && (salesSlipSearchResult1.SectionCode == salesSlipSearchResult2.SectionCode)
    //             && (salesSlipSearchResult1.SectionGuideNm == salesSlipSearchResult2.SectionGuideNm)
    //             && (salesSlipSearchResult1.SubSectionCode == salesSlipSearchResult2.SubSectionCode)
    //             && (salesSlipSearchResult1.SubSectionName == salesSlipSearchResult2.SubSectionName)
    //             && (salesSlipSearchResult1.DebitNoteDiv == salesSlipSearchResult2.DebitNoteDiv)
    //             && (salesSlipSearchResult1.DebitNLnkSalesSlNum == salesSlipSearchResult2.DebitNLnkSalesSlNum)
    //             && (salesSlipSearchResult1.SalesSlipCd == salesSlipSearchResult2.SalesSlipCd)
    //             && (salesSlipSearchResult1.SalesGoodsCd == salesSlipSearchResult2.SalesGoodsCd)
    //             && (salesSlipSearchResult1.AccRecDivCd == salesSlipSearchResult2.AccRecDivCd)
    //             && (salesSlipSearchResult1.SalesInpSecCd == salesSlipSearchResult2.SalesInpSecCd)
    //             && (salesSlipSearchResult1.DemandAddUpSecCd == salesSlipSearchResult2.DemandAddUpSecCd)
    //             && (salesSlipSearchResult1.ResultsAddUpSecCd == salesSlipSearchResult2.ResultsAddUpSecCd)
    //             && (salesSlipSearchResult1.UpdateSecCd == salesSlipSearchResult2.UpdateSecCd)
    //             && (salesSlipSearchResult1.SearchSlipDate == salesSlipSearchResult2.SearchSlipDate)
    //             && (salesSlipSearchResult1.ShipmentDay == salesSlipSearchResult2.ShipmentDay)
    //             && (salesSlipSearchResult1.SalesDate == salesSlipSearchResult2.SalesDate)
    //             && (salesSlipSearchResult1.AddUpADate == salesSlipSearchResult2.AddUpADate)
    //             && (salesSlipSearchResult1.DelayPaymentDiv == salesSlipSearchResult2.DelayPaymentDiv)
    //             && (salesSlipSearchResult1.EstimateFormNo == salesSlipSearchResult2.EstimateFormNo)
    //             && (salesSlipSearchResult1.EstimateDivide == salesSlipSearchResult2.EstimateDivide)
    //             && (salesSlipSearchResult1.InputAgenCd == salesSlipSearchResult2.InputAgenCd)
    //             && (salesSlipSearchResult1.InputAgenNm == salesSlipSearchResult2.InputAgenNm)
    //             && (salesSlipSearchResult1.SalesInputCode == salesSlipSearchResult2.SalesInputCode)
    //             && (salesSlipSearchResult1.SalesInputName == salesSlipSearchResult2.SalesInputName)
    //             && (salesSlipSearchResult1.FrontEmployeeCd == salesSlipSearchResult2.FrontEmployeeCd)
    //             && (salesSlipSearchResult1.FrontEmployeeNm == salesSlipSearchResult2.FrontEmployeeNm)
    //             && (salesSlipSearchResult1.SalesEmployeeCd == salesSlipSearchResult2.SalesEmployeeCd)
    //             && (salesSlipSearchResult1.SalesEmployeeNm == salesSlipSearchResult2.SalesEmployeeNm)
    //             && (salesSlipSearchResult1.TotalAmountDispWayCd == salesSlipSearchResult2.TotalAmountDispWayCd)
    //             && (salesSlipSearchResult1.TtlAmntDispRateApy == salesSlipSearchResult2.TtlAmntDispRateApy)
    //             && (salesSlipSearchResult1.SalesTotalTaxInc == salesSlipSearchResult2.SalesTotalTaxInc)
    //             && (salesSlipSearchResult1.SalesTotalTaxExc == salesSlipSearchResult2.SalesTotalTaxExc)
    //             && (salesSlipSearchResult1.SalesPrtTotalTaxInc == salesSlipSearchResult2.SalesPrtTotalTaxInc)
    //             && (salesSlipSearchResult1.SalesPrtTotalTaxExc == salesSlipSearchResult2.SalesPrtTotalTaxExc)
    //             && (salesSlipSearchResult1.SalesWorkTotalTaxInc == salesSlipSearchResult2.SalesWorkTotalTaxInc)
    //             && (salesSlipSearchResult1.SalesWorkTotalTaxExc == salesSlipSearchResult2.SalesWorkTotalTaxExc)
    //             && (salesSlipSearchResult1.SalesSubtotalTaxInc == salesSlipSearchResult2.SalesSubtotalTaxInc)
    //             && (salesSlipSearchResult1.SalesSubtotalTaxExc == salesSlipSearchResult2.SalesSubtotalTaxExc)
    //             && (salesSlipSearchResult1.SalesPrtSubttlInc == salesSlipSearchResult2.SalesPrtSubttlInc)
    //             && (salesSlipSearchResult1.SalesPrtSubttlExc == salesSlipSearchResult2.SalesPrtSubttlExc)
    //             && (salesSlipSearchResult1.SalesWorkSubttlInc == salesSlipSearchResult2.SalesWorkSubttlInc)
    //             && (salesSlipSearchResult1.SalesWorkSubttlExc == salesSlipSearchResult2.SalesWorkSubttlExc)
    //             && (salesSlipSearchResult1.SalesNetPrice == salesSlipSearchResult2.SalesNetPrice)
    //             && (salesSlipSearchResult1.SalesSubtotalTax == salesSlipSearchResult2.SalesSubtotalTax)
    //             && (salesSlipSearchResult1.ItdedSalesOutTax == salesSlipSearchResult2.ItdedSalesOutTax)
    //             && (salesSlipSearchResult1.ItdedSalesInTax == salesSlipSearchResult2.ItdedSalesInTax)
    //             && (salesSlipSearchResult1.SalSubttlSubToTaxFre == salesSlipSearchResult2.SalSubttlSubToTaxFre)
    //             && (salesSlipSearchResult1.SalesOutTax == salesSlipSearchResult2.SalesOutTax)
    //             && (salesSlipSearchResult1.SalAmntConsTaxInclu == salesSlipSearchResult2.SalAmntConsTaxInclu)
    //             && (salesSlipSearchResult1.SalesDisTtlTaxExc == salesSlipSearchResult2.SalesDisTtlTaxExc)
    //             && (salesSlipSearchResult1.ItdedSalesDisOutTax == salesSlipSearchResult2.ItdedSalesDisOutTax)
    //             && (salesSlipSearchResult1.ItdedSalesDisInTax == salesSlipSearchResult2.ItdedSalesDisInTax)
    //             && (salesSlipSearchResult1.ItdedPartsDisOutTax == salesSlipSearchResult2.ItdedPartsDisOutTax)
    //             && (salesSlipSearchResult1.ItdedPartsDisInTax == salesSlipSearchResult2.ItdedPartsDisInTax)
    //             && (salesSlipSearchResult1.ItdedWorkDisOutTax == salesSlipSearchResult2.ItdedWorkDisOutTax)
    //             && (salesSlipSearchResult1.ItdedWorkDisInTax == salesSlipSearchResult2.ItdedWorkDisInTax)
    //             && (salesSlipSearchResult1.ItdedSalesDisTaxFre == salesSlipSearchResult2.ItdedSalesDisTaxFre)
    //             && (salesSlipSearchResult1.SalesDisOutTax == salesSlipSearchResult2.SalesDisOutTax)
    //             && (salesSlipSearchResult1.SalesDisTtlTaxInclu == salesSlipSearchResult2.SalesDisTtlTaxInclu)
    //             && (salesSlipSearchResult1.PartsDiscountRate == salesSlipSearchResult2.PartsDiscountRate)
    //             && (salesSlipSearchResult1.RavorDiscountRate == salesSlipSearchResult2.RavorDiscountRate)
    //             && (salesSlipSearchResult1.TotalCost == salesSlipSearchResult2.TotalCost)
    //             && (salesSlipSearchResult1.ConsTaxLayMethod == salesSlipSearchResult2.ConsTaxLayMethod)
    //             && (salesSlipSearchResult1.ConsTaxRate == salesSlipSearchResult2.ConsTaxRate)
    //             && (salesSlipSearchResult1.FractionProcCd == salesSlipSearchResult2.FractionProcCd)
    //             && (salesSlipSearchResult1.AccRecConsTax == salesSlipSearchResult2.AccRecConsTax)
    //             && (salesSlipSearchResult1.AutoDepositCd == salesSlipSearchResult2.AutoDepositCd)
    //             && (salesSlipSearchResult1.AutoDepositSlipNo == salesSlipSearchResult2.AutoDepositSlipNo)
    //             && (salesSlipSearchResult1.DepositAllowanceTtl == salesSlipSearchResult2.DepositAllowanceTtl)
    //             && (salesSlipSearchResult1.DepositAlwcBlnce == salesSlipSearchResult2.DepositAlwcBlnce)
    //             && (salesSlipSearchResult1.ClaimCode == salesSlipSearchResult2.ClaimCode)
    //             && (salesSlipSearchResult1.ClaimSnm == salesSlipSearchResult2.ClaimSnm)
    //             && (salesSlipSearchResult1.CustomerCode == salesSlipSearchResult2.CustomerCode)
    //             && (salesSlipSearchResult1.CustomerName == salesSlipSearchResult2.CustomerName)
    //             && (salesSlipSearchResult1.CustomerName2 == salesSlipSearchResult2.CustomerName2)
    //             && (salesSlipSearchResult1.CustomerSnm == salesSlipSearchResult2.CustomerSnm)
    //             && (salesSlipSearchResult1.HonorificTitle == salesSlipSearchResult2.HonorificTitle)
    //             && (salesSlipSearchResult1.OutputName == salesSlipSearchResult2.OutputName)
    //             && (salesSlipSearchResult1.CustSlipNo == salesSlipSearchResult2.CustSlipNo)
    //             && (salesSlipSearchResult1.SlipAddressDiv == salesSlipSearchResult2.SlipAddressDiv)
    //             && (salesSlipSearchResult1.AddresseeCode == salesSlipSearchResult2.AddresseeCode)
    //             && (salesSlipSearchResult1.AddresseeName == salesSlipSearchResult2.AddresseeName)
    //             && (salesSlipSearchResult1.AddresseeName2 == salesSlipSearchResult2.AddresseeName2)
    //             && (salesSlipSearchResult1.AddresseePostNo == salesSlipSearchResult2.AddresseePostNo)
    //             && (salesSlipSearchResult1.AddresseeAddr1 == salesSlipSearchResult2.AddresseeAddr1)
    //             && (salesSlipSearchResult1.AddresseeAddr3 == salesSlipSearchResult2.AddresseeAddr3)
    //             && (salesSlipSearchResult1.AddresseeAddr4 == salesSlipSearchResult2.AddresseeAddr4)
    //             && (salesSlipSearchResult1.AddresseeTelNo == salesSlipSearchResult2.AddresseeTelNo)
    //             && (salesSlipSearchResult1.AddresseeFaxNo == salesSlipSearchResult2.AddresseeFaxNo)
    //             && (salesSlipSearchResult1.PartySaleSlipNum == salesSlipSearchResult2.PartySaleSlipNum)
    //             && (salesSlipSearchResult1.SlipNote == salesSlipSearchResult2.SlipNote)
    //             && (salesSlipSearchResult1.SlipNote2 == salesSlipSearchResult2.SlipNote2)
    //             && (salesSlipSearchResult1.SlipNote3 == salesSlipSearchResult2.SlipNote3)
    //             && (salesSlipSearchResult1.RetGoodsReasonDiv == salesSlipSearchResult2.RetGoodsReasonDiv)
    //             && (salesSlipSearchResult1.RetGoodsReason == salesSlipSearchResult2.RetGoodsReason)
    //             && (salesSlipSearchResult1.RegiProcDate == salesSlipSearchResult2.RegiProcDate)
    //             && (salesSlipSearchResult1.CashRegisterNo == salesSlipSearchResult2.CashRegisterNo)
    //             && (salesSlipSearchResult1.PosReceiptNo == salesSlipSearchResult2.PosReceiptNo)
    //             && (salesSlipSearchResult1.DetailRowCount == salesSlipSearchResult2.DetailRowCount)
    //             && (salesSlipSearchResult1.EdiSendDate == salesSlipSearchResult2.EdiSendDate)
    //             && (salesSlipSearchResult1.EdiTakeInDate == salesSlipSearchResult2.EdiTakeInDate)
    //             && (salesSlipSearchResult1.UoeRemark1 == salesSlipSearchResult2.UoeRemark1)
    //             && (salesSlipSearchResult1.UoeRemark2 == salesSlipSearchResult2.UoeRemark2)
    //             && (salesSlipSearchResult1.SlipPrintDivCd == salesSlipSearchResult2.SlipPrintDivCd)
    //             && (salesSlipSearchResult1.SlipPrintFinishCd == salesSlipSearchResult2.SlipPrintFinishCd)
    //             && (salesSlipSearchResult1.SalesSlipPrintDate == salesSlipSearchResult2.SalesSlipPrintDate)
    //             && (salesSlipSearchResult1.BusinessTypeCode == salesSlipSearchResult2.BusinessTypeCode)
    //             && (salesSlipSearchResult1.BusinessTypeName == salesSlipSearchResult2.BusinessTypeName)
    //             && (salesSlipSearchResult1.OrderNumber == salesSlipSearchResult2.OrderNumber)
    //             && (salesSlipSearchResult1.DeliveredGoodsDiv == salesSlipSearchResult2.DeliveredGoodsDiv)
    //             && (salesSlipSearchResult1.DeliveredGoodsDivNm == salesSlipSearchResult2.DeliveredGoodsDivNm)
    //             && (salesSlipSearchResult1.SalesAreaCode == salesSlipSearchResult2.SalesAreaCode)
    //             && (salesSlipSearchResult1.SalesAreaName == salesSlipSearchResult2.SalesAreaName)
    //             && (salesSlipSearchResult1.ReconcileFlag == salesSlipSearchResult2.ReconcileFlag)
    //             && (salesSlipSearchResult1.SlipPrtSetPaperId == salesSlipSearchResult2.SlipPrtSetPaperId)
    //             && (salesSlipSearchResult1.CompleteCd == salesSlipSearchResult2.CompleteCd)
    //             && (salesSlipSearchResult1.SalesPriceFracProcCd == salesSlipSearchResult2.SalesPriceFracProcCd)
    //             && (salesSlipSearchResult1.StockGoodsTtlTaxExc == salesSlipSearchResult2.StockGoodsTtlTaxExc)
    //             && (salesSlipSearchResult1.PureGoodsTtlTaxExc == salesSlipSearchResult2.PureGoodsTtlTaxExc)
    //             && (salesSlipSearchResult1.ListPricePrintDiv == salesSlipSearchResult2.ListPricePrintDiv)
    //             && (salesSlipSearchResult1.EraNameDispCd1 == salesSlipSearchResult2.EraNameDispCd1)
    //             && (salesSlipSearchResult1.EstimaTaxDivCd == salesSlipSearchResult2.EstimaTaxDivCd)
    //             && (salesSlipSearchResult1.EstimateFormPrtCd == salesSlipSearchResult2.EstimateFormPrtCd)
    //             && (salesSlipSearchResult1.EstimateSubject == salesSlipSearchResult2.EstimateSubject)
    //             && (salesSlipSearchResult1.Footnotes1 == salesSlipSearchResult2.Footnotes1)
    //             && (salesSlipSearchResult1.Footnotes2 == salesSlipSearchResult2.Footnotes2)
    //             && (salesSlipSearchResult1.EstimateTitle1 == salesSlipSearchResult2.EstimateTitle1)
    //             && (salesSlipSearchResult1.EstimateTitle2 == salesSlipSearchResult2.EstimateTitle2)
    //             && (salesSlipSearchResult1.EstimateTitle3 == salesSlipSearchResult2.EstimateTitle3)
    //             && (salesSlipSearchResult1.EstimateTitle4 == salesSlipSearchResult2.EstimateTitle4)
    //             && (salesSlipSearchResult1.EstimateTitle5 == salesSlipSearchResult2.EstimateTitle5)
    //             && (salesSlipSearchResult1.EstimateNote1 == salesSlipSearchResult2.EstimateNote1)
    //             && (salesSlipSearchResult1.EstimateNote2 == salesSlipSearchResult2.EstimateNote2)
    //             && (salesSlipSearchResult1.EstimateNote3 == salesSlipSearchResult2.EstimateNote3)
    //             && (salesSlipSearchResult1.EstimateNote4 == salesSlipSearchResult2.EstimateNote4)
    //             && (salesSlipSearchResult1.EstimateNote5 == salesSlipSearchResult2.EstimateNote5)
    //             && (salesSlipSearchResult1.EstimateValidityDate == salesSlipSearchResult2.EstimateValidityDate)
    //             && (salesSlipSearchResult1.PartsNoPrtCd == salesSlipSearchResult2.PartsNoPrtCd)
    //             && (salesSlipSearchResult1.OptionPringDivCd == salesSlipSearchResult2.OptionPringDivCd)
    //             && (salesSlipSearchResult1.RateUseCode == salesSlipSearchResult2.RateUseCode)
    //             && (salesSlipSearchResult1.CarMngCode == salesSlipSearchResult2.CarMngCode)
    //             && (salesSlipSearchResult1.ModelDesignationNo == salesSlipSearchResult2.ModelDesignationNo)
    //             && (salesSlipSearchResult1.CategoryNo == salesSlipSearchResult2.CategoryNo)
    //             && (salesSlipSearchResult1.MakerFullName == salesSlipSearchResult2.MakerFullName)
    //             && (salesSlipSearchResult1.FullModel == salesSlipSearchResult2.FullModel)
    //             && (salesSlipSearchResult1.EnterpriseName == salesSlipSearchResult2.EnterpriseName)
    //             && (salesSlipSearchResult1.ResultsAddUpSecNm == salesSlipSearchResult2.ResultsAddUpSecNm));
    //    }
    //    /// <summary>
    //    /// ����`�[�������o���ʔ�r����
    //    /// </summary>
    //    /// <param name="target">��r�Ώۂ�SalesSlipSearchResult�N���X�̃C���X�^���X</param>
    //    /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public ArrayList Compare(SalesSlipSearchResult target)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
    //        if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
    //        if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
    //        if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
    //        if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
    //        if (this.SubSectionName != target.SubSectionName) resList.Add("SubSectionName");
    //        if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
    //        if (this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
    //        if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
    //        if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
    //        if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
    //        if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
    //        if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
    //        if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
    //        if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
    //        if (this.SearchSlipDate != target.SearchSlipDate) resList.Add("SearchSlipDate");
    //        if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
    //        if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
    //        if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
    //        if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
    //        if (this.EstimateFormNo != target.EstimateFormNo) resList.Add("EstimateFormNo");
    //        if (this.EstimateDivide != target.EstimateDivide) resList.Add("EstimateDivide");
    //        if (this.InputAgenCd != target.InputAgenCd) resList.Add("InputAgenCd");
    //        if (this.InputAgenNm != target.InputAgenNm) resList.Add("InputAgenNm");
    //        if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
    //        if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
    //        if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
    //        if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
    //        if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
    //        if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
    //        if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
    //        if (this.TtlAmntDispRateApy != target.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
    //        if (this.SalesTotalTaxInc != target.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
    //        if (this.SalesTotalTaxExc != target.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
    //        if (this.SalesPrtTotalTaxInc != target.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
    //        if (this.SalesPrtTotalTaxExc != target.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
    //        if (this.SalesWorkTotalTaxInc != target.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
    //        if (this.SalesWorkTotalTaxExc != target.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
    //        if (this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
    //        if (this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
    //        if (this.SalesPrtSubttlInc != target.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
    //        if (this.SalesPrtSubttlExc != target.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
    //        if (this.SalesWorkSubttlInc != target.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
    //        if (this.SalesWorkSubttlExc != target.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
    //        if (this.SalesNetPrice != target.SalesNetPrice) resList.Add("SalesNetPrice");
    //        if (this.SalesSubtotalTax != target.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
    //        if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
    //        if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
    //        if (this.SalSubttlSubToTaxFre != target.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
    //        if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
    //        if (this.SalAmntConsTaxInclu != target.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
    //        if (this.SalesDisTtlTaxExc != target.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
    //        if (this.ItdedSalesDisOutTax != target.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
    //        if (this.ItdedSalesDisInTax != target.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
    //        if (this.ItdedPartsDisOutTax != target.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
    //        if (this.ItdedPartsDisInTax != target.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
    //        if (this.ItdedWorkDisOutTax != target.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
    //        if (this.ItdedWorkDisInTax != target.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
    //        if (this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
    //        if (this.SalesDisOutTax != target.SalesDisOutTax) resList.Add("SalesDisOutTax");
    //        if (this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
    //        if (this.PartsDiscountRate != target.PartsDiscountRate) resList.Add("PartsDiscountRate");
    //        if (this.RavorDiscountRate != target.RavorDiscountRate) resList.Add("RavorDiscountRate");
    //        if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
    //        if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
    //        if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
    //        if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
    //        if (this.AccRecConsTax != target.AccRecConsTax) resList.Add("AccRecConsTax");
    //        if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
    //        if (this.AutoDepositSlipNo != target.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
    //        if (this.DepositAllowanceTtl != target.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
    //        if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
    //        if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
    //        if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
    //        if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
    //        if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
    //        if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
    //        if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
    //        if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
    //        if (this.OutputName != target.OutputName) resList.Add("OutputName");
    //        if (this.CustSlipNo != target.CustSlipNo) resList.Add("CustSlipNo");
    //        if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
    //        if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
    //        if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
    //        if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
    //        if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
    //        if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
    //        if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
    //        if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
    //        if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
    //        if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
    //        if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
    //        if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
    //        if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
    //        if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
    //        if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
    //        if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
    //        if (this.RegiProcDate != target.RegiProcDate) resList.Add("RegiProcDate");
    //        if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
    //        if (this.PosReceiptNo != target.PosReceiptNo) resList.Add("PosReceiptNo");
    //        if (this.DetailRowCount != target.DetailRowCount) resList.Add("DetailRowCount");
    //        if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
    //        if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
    //        if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
    //        if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
    //        if (this.SlipPrintDivCd != target.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
    //        if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
    //        if (this.SalesSlipPrintDate != target.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
    //        if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
    //        if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
    //        if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
    //        if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
    //        if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
    //        if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
    //        if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
    //        if (this.ReconcileFlag != target.ReconcileFlag) resList.Add("ReconcileFlag");
    //        if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
    //        if (this.CompleteCd != target.CompleteCd) resList.Add("CompleteCd");
    //        if (this.SalesPriceFracProcCd != target.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
    //        if (this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
    //        if (this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
    //        if (this.ListPricePrintDiv != target.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
    //        if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
    //        if (this.EstimaTaxDivCd != target.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
    //        if (this.EstimateFormPrtCd != target.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
    //        if (this.EstimateSubject != target.EstimateSubject) resList.Add("EstimateSubject");
    //        if (this.Footnotes1 != target.Footnotes1) resList.Add("Footnotes1");
    //        if (this.Footnotes2 != target.Footnotes2) resList.Add("Footnotes2");
    //        if (this.EstimateTitle1 != target.EstimateTitle1) resList.Add("EstimateTitle1");
    //        if (this.EstimateTitle2 != target.EstimateTitle2) resList.Add("EstimateTitle2");
    //        if (this.EstimateTitle3 != target.EstimateTitle3) resList.Add("EstimateTitle3");
    //        if (this.EstimateTitle4 != target.EstimateTitle4) resList.Add("EstimateTitle4");
    //        if (this.EstimateTitle5 != target.EstimateTitle5) resList.Add("EstimateTitle5");
    //        if (this.EstimateNote1 != target.EstimateNote1) resList.Add("EstimateNote1");
    //        if (this.EstimateNote2 != target.EstimateNote2) resList.Add("EstimateNote2");
    //        if (this.EstimateNote3 != target.EstimateNote3) resList.Add("EstimateNote3");
    //        if (this.EstimateNote4 != target.EstimateNote4) resList.Add("EstimateNote4");
    //        if (this.EstimateNote5 != target.EstimateNote5) resList.Add("EstimateNote5");
    //        if (this.EstimateValidityDate != target.EstimateValidityDate) resList.Add("EstimateValidityDate");
    //        if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
    //        if (this.OptionPringDivCd != target.OptionPringDivCd) resList.Add("OptionPringDivCd");
    //        if (this.RateUseCode != target.RateUseCode) resList.Add("RateUseCode");
    //        if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngNo");
    //        if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
    //        if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
    //        if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
    //        if (this.FullModel != target.FullModel) resList.Add("FullModel");
    //        if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
    //        if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");

    //        return resList;
    //    }

    //    /// <summary>
    //    /// ����`�[�������o���ʔ�r����
    //    /// </summary>
    //    /// <param name="salesSlipSearchResult1">��r����SalesSlipSearchResult�N���X�̃C���X�^���X</param>
    //    /// <param name="salesSlipSearchResult2">��r����SalesSlipSearchResult�N���X�̃C���X�^���X</param>
    //    /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public static ArrayList Compare(SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (salesSlipSearchResult1.EnterpriseCode != salesSlipSearchResult2.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (salesSlipSearchResult1.LogicalDeleteCode != salesSlipSearchResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (salesSlipSearchResult1.AcptAnOdrStatus != salesSlipSearchResult2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
    //        if (salesSlipSearchResult1.SalesSlipNum != salesSlipSearchResult2.SalesSlipNum) resList.Add("SalesSlipNum");
    //        if (salesSlipSearchResult1.SectionCode != salesSlipSearchResult2.SectionCode) resList.Add("SectionCode");
    //        if (salesSlipSearchResult1.SectionGuideNm != salesSlipSearchResult2.SectionGuideNm) resList.Add("SectionGuideNm");
    //        if (salesSlipSearchResult1.SubSectionCode != salesSlipSearchResult2.SubSectionCode) resList.Add("SubSectionCode");
    //        if (salesSlipSearchResult1.SubSectionName != salesSlipSearchResult2.SubSectionName) resList.Add("SubSectionName");
    //        if (salesSlipSearchResult1.DebitNoteDiv != salesSlipSearchResult2.DebitNoteDiv) resList.Add("DebitNoteDiv");
    //        if (salesSlipSearchResult1.DebitNLnkSalesSlNum != salesSlipSearchResult2.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
    //        if (salesSlipSearchResult1.SalesSlipCd != salesSlipSearchResult2.SalesSlipCd) resList.Add("SalesSlipCd");
    //        if (salesSlipSearchResult1.SalesGoodsCd != salesSlipSearchResult2.SalesGoodsCd) resList.Add("SalesGoodsCd");
    //        if (salesSlipSearchResult1.AccRecDivCd != salesSlipSearchResult2.AccRecDivCd) resList.Add("AccRecDivCd");
    //        if (salesSlipSearchResult1.SalesInpSecCd != salesSlipSearchResult2.SalesInpSecCd) resList.Add("SalesInpSecCd");
    //        if (salesSlipSearchResult1.DemandAddUpSecCd != salesSlipSearchResult2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
    //        if (salesSlipSearchResult1.ResultsAddUpSecCd != salesSlipSearchResult2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
    //        if (salesSlipSearchResult1.UpdateSecCd != salesSlipSearchResult2.UpdateSecCd) resList.Add("UpdateSecCd");
    //        if (salesSlipSearchResult1.SearchSlipDate != salesSlipSearchResult2.SearchSlipDate) resList.Add("SearchSlipDate");
    //        if (salesSlipSearchResult1.ShipmentDay != salesSlipSearchResult2.ShipmentDay) resList.Add("ShipmentDay");
    //        if (salesSlipSearchResult1.SalesDate != salesSlipSearchResult2.SalesDate) resList.Add("SalesDate");
    //        if (salesSlipSearchResult1.AddUpADate != salesSlipSearchResult2.AddUpADate) resList.Add("AddUpADate");
    //        if (salesSlipSearchResult1.DelayPaymentDiv != salesSlipSearchResult2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
    //        if (salesSlipSearchResult1.EstimateFormNo != salesSlipSearchResult2.EstimateFormNo) resList.Add("EstimateFormNo");
    //        if (salesSlipSearchResult1.EstimateDivide != salesSlipSearchResult2.EstimateDivide) resList.Add("EstimateDivide");
    //        if (salesSlipSearchResult1.InputAgenCd != salesSlipSearchResult2.InputAgenCd) resList.Add("InputAgenCd");
    //        if (salesSlipSearchResult1.InputAgenNm != salesSlipSearchResult2.InputAgenNm) resList.Add("InputAgenNm");
    //        if (salesSlipSearchResult1.SalesInputCode != salesSlipSearchResult2.SalesInputCode) resList.Add("SalesInputCode");
    //        if (salesSlipSearchResult1.SalesInputName != salesSlipSearchResult2.SalesInputName) resList.Add("SalesInputName");
    //        if (salesSlipSearchResult1.FrontEmployeeCd != salesSlipSearchResult2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
    //        if (salesSlipSearchResult1.FrontEmployeeNm != salesSlipSearchResult2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
    //        if (salesSlipSearchResult1.SalesEmployeeCd != salesSlipSearchResult2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
    //        if (salesSlipSearchResult1.SalesEmployeeNm != salesSlipSearchResult2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
    //        if (salesSlipSearchResult1.TotalAmountDispWayCd != salesSlipSearchResult2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
    //        if (salesSlipSearchResult1.TtlAmntDispRateApy != salesSlipSearchResult2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
    //        if (salesSlipSearchResult1.SalesTotalTaxInc != salesSlipSearchResult2.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
    //        if (salesSlipSearchResult1.SalesTotalTaxExc != salesSlipSearchResult2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
    //        if (salesSlipSearchResult1.SalesPrtTotalTaxInc != salesSlipSearchResult2.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
    //        if (salesSlipSearchResult1.SalesPrtTotalTaxExc != salesSlipSearchResult2.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
    //        if (salesSlipSearchResult1.SalesWorkTotalTaxInc != salesSlipSearchResult2.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
    //        if (salesSlipSearchResult1.SalesWorkTotalTaxExc != salesSlipSearchResult2.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
    //        if (salesSlipSearchResult1.SalesSubtotalTaxInc != salesSlipSearchResult2.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
    //        if (salesSlipSearchResult1.SalesSubtotalTaxExc != salesSlipSearchResult2.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
    //        if (salesSlipSearchResult1.SalesPrtSubttlInc != salesSlipSearchResult2.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
    //        if (salesSlipSearchResult1.SalesPrtSubttlExc != salesSlipSearchResult2.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
    //        if (salesSlipSearchResult1.SalesWorkSubttlInc != salesSlipSearchResult2.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
    //        if (salesSlipSearchResult1.SalesWorkSubttlExc != salesSlipSearchResult2.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
    //        if (salesSlipSearchResult1.SalesNetPrice != salesSlipSearchResult2.SalesNetPrice) resList.Add("SalesNetPrice");
    //        if (salesSlipSearchResult1.SalesSubtotalTax != salesSlipSearchResult2.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
    //        if (salesSlipSearchResult1.ItdedSalesOutTax != salesSlipSearchResult2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
    //        if (salesSlipSearchResult1.ItdedSalesInTax != salesSlipSearchResult2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
    //        if (salesSlipSearchResult1.SalSubttlSubToTaxFre != salesSlipSearchResult2.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
    //        if (salesSlipSearchResult1.SalesOutTax != salesSlipSearchResult2.SalesOutTax) resList.Add("SalesOutTax");
    //        if (salesSlipSearchResult1.SalAmntConsTaxInclu != salesSlipSearchResult2.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
    //        if (salesSlipSearchResult1.SalesDisTtlTaxExc != salesSlipSearchResult2.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
    //        if (salesSlipSearchResult1.ItdedSalesDisOutTax != salesSlipSearchResult2.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
    //        if (salesSlipSearchResult1.ItdedSalesDisInTax != salesSlipSearchResult2.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
    //        if (salesSlipSearchResult1.ItdedPartsDisOutTax != salesSlipSearchResult2.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
    //        if (salesSlipSearchResult1.ItdedPartsDisInTax != salesSlipSearchResult2.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
    //        if (salesSlipSearchResult1.ItdedWorkDisOutTax != salesSlipSearchResult2.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
    //        if (salesSlipSearchResult1.ItdedWorkDisInTax != salesSlipSearchResult2.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
    //        if (salesSlipSearchResult1.ItdedSalesDisTaxFre != salesSlipSearchResult2.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
    //        if (salesSlipSearchResult1.SalesDisOutTax != salesSlipSearchResult2.SalesDisOutTax) resList.Add("SalesDisOutTax");
    //        if (salesSlipSearchResult1.SalesDisTtlTaxInclu != salesSlipSearchResult2.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
    //        if (salesSlipSearchResult1.PartsDiscountRate != salesSlipSearchResult2.PartsDiscountRate) resList.Add("PartsDiscountRate");
    //        if (salesSlipSearchResult1.RavorDiscountRate != salesSlipSearchResult2.RavorDiscountRate) resList.Add("RavorDiscountRate");
    //        if (salesSlipSearchResult1.TotalCost != salesSlipSearchResult2.TotalCost) resList.Add("TotalCost");
    //        if (salesSlipSearchResult1.ConsTaxLayMethod != salesSlipSearchResult2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
    //        if (salesSlipSearchResult1.ConsTaxRate != salesSlipSearchResult2.ConsTaxRate) resList.Add("ConsTaxRate");
    //        if (salesSlipSearchResult1.FractionProcCd != salesSlipSearchResult2.FractionProcCd) resList.Add("FractionProcCd");
    //        if (salesSlipSearchResult1.AccRecConsTax != salesSlipSearchResult2.AccRecConsTax) resList.Add("AccRecConsTax");
    //        if (salesSlipSearchResult1.AutoDepositCd != salesSlipSearchResult2.AutoDepositCd) resList.Add("AutoDepositCd");
    //        if (salesSlipSearchResult1.AutoDepositSlipNo != salesSlipSearchResult2.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
    //        if (salesSlipSearchResult1.DepositAllowanceTtl != salesSlipSearchResult2.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
    //        if (salesSlipSearchResult1.DepositAlwcBlnce != salesSlipSearchResult2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
    //        if (salesSlipSearchResult1.ClaimCode != salesSlipSearchResult2.ClaimCode) resList.Add("ClaimCode");
    //        if (salesSlipSearchResult1.ClaimSnm != salesSlipSearchResult2.ClaimSnm) resList.Add("ClaimSnm");
    //        if (salesSlipSearchResult1.CustomerCode != salesSlipSearchResult2.CustomerCode) resList.Add("CustomerCode");
    //        if (salesSlipSearchResult1.CustomerName != salesSlipSearchResult2.CustomerName) resList.Add("CustomerName");
    //        if (salesSlipSearchResult1.CustomerName2 != salesSlipSearchResult2.CustomerName2) resList.Add("CustomerName2");
    //        if (salesSlipSearchResult1.CustomerSnm != salesSlipSearchResult2.CustomerSnm) resList.Add("CustomerSnm");
    //        if (salesSlipSearchResult1.HonorificTitle != salesSlipSearchResult2.HonorificTitle) resList.Add("HonorificTitle");
    //        if (salesSlipSearchResult1.OutputName != salesSlipSearchResult2.OutputName) resList.Add("OutputName");
    //        if (salesSlipSearchResult1.CustSlipNo != salesSlipSearchResult2.CustSlipNo) resList.Add("CustSlipNo");
    //        if (salesSlipSearchResult1.SlipAddressDiv != salesSlipSearchResult2.SlipAddressDiv) resList.Add("SlipAddressDiv");
    //        if (salesSlipSearchResult1.AddresseeCode != salesSlipSearchResult2.AddresseeCode) resList.Add("AddresseeCode");
    //        if (salesSlipSearchResult1.AddresseeName != salesSlipSearchResult2.AddresseeName) resList.Add("AddresseeName");
    //        if (salesSlipSearchResult1.AddresseeName2 != salesSlipSearchResult2.AddresseeName2) resList.Add("AddresseeName2");
    //        if (salesSlipSearchResult1.AddresseePostNo != salesSlipSearchResult2.AddresseePostNo) resList.Add("AddresseePostNo");
    //        if (salesSlipSearchResult1.AddresseeAddr1 != salesSlipSearchResult2.AddresseeAddr1) resList.Add("AddresseeAddr1");
    //        if (salesSlipSearchResult1.AddresseeAddr3 != salesSlipSearchResult2.AddresseeAddr3) resList.Add("AddresseeAddr3");
    //        if (salesSlipSearchResult1.AddresseeAddr4 != salesSlipSearchResult2.AddresseeAddr4) resList.Add("AddresseeAddr4");
    //        if (salesSlipSearchResult1.AddresseeTelNo != salesSlipSearchResult2.AddresseeTelNo) resList.Add("AddresseeTelNo");
    //        if (salesSlipSearchResult1.AddresseeFaxNo != salesSlipSearchResult2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
    //        if (salesSlipSearchResult1.PartySaleSlipNum != salesSlipSearchResult2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
    //        if (salesSlipSearchResult1.SlipNote != salesSlipSearchResult2.SlipNote) resList.Add("SlipNote");
    //        if (salesSlipSearchResult1.SlipNote2 != salesSlipSearchResult2.SlipNote2) resList.Add("SlipNote2");
    //        if (salesSlipSearchResult1.SlipNote3 != salesSlipSearchResult2.SlipNote3) resList.Add("SlipNote3");
    //        if (salesSlipSearchResult1.RetGoodsReasonDiv != salesSlipSearchResult2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
    //        if (salesSlipSearchResult1.RetGoodsReason != salesSlipSearchResult2.RetGoodsReason) resList.Add("RetGoodsReason");
    //        if (salesSlipSearchResult1.RegiProcDate != salesSlipSearchResult2.RegiProcDate) resList.Add("RegiProcDate");
    //        if (salesSlipSearchResult1.CashRegisterNo != salesSlipSearchResult2.CashRegisterNo) resList.Add("CashRegisterNo");
    //        if (salesSlipSearchResult1.PosReceiptNo != salesSlipSearchResult2.PosReceiptNo) resList.Add("PosReceiptNo");
    //        if (salesSlipSearchResult1.DetailRowCount != salesSlipSearchResult2.DetailRowCount) resList.Add("DetailRowCount");
    //        if (salesSlipSearchResult1.EdiSendDate != salesSlipSearchResult2.EdiSendDate) resList.Add("EdiSendDate");
    //        if (salesSlipSearchResult1.EdiTakeInDate != salesSlipSearchResult2.EdiTakeInDate) resList.Add("EdiTakeInDate");
    //        if (salesSlipSearchResult1.UoeRemark1 != salesSlipSearchResult2.UoeRemark1) resList.Add("UoeRemark1");
    //        if (salesSlipSearchResult1.UoeRemark2 != salesSlipSearchResult2.UoeRemark2) resList.Add("UoeRemark2");
    //        if (salesSlipSearchResult1.SlipPrintDivCd != salesSlipSearchResult2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
    //        if (salesSlipSearchResult1.SlipPrintFinishCd != salesSlipSearchResult2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
    //        if (salesSlipSearchResult1.SalesSlipPrintDate != salesSlipSearchResult2.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
    //        if (salesSlipSearchResult1.BusinessTypeCode != salesSlipSearchResult2.BusinessTypeCode) resList.Add("BusinessTypeCode");
    //        if (salesSlipSearchResult1.BusinessTypeName != salesSlipSearchResult2.BusinessTypeName) resList.Add("BusinessTypeName");
    //        if (salesSlipSearchResult1.OrderNumber != salesSlipSearchResult2.OrderNumber) resList.Add("OrderNumber");
    //        if (salesSlipSearchResult1.DeliveredGoodsDiv != salesSlipSearchResult2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
    //        if (salesSlipSearchResult1.DeliveredGoodsDivNm != salesSlipSearchResult2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
    //        if (salesSlipSearchResult1.SalesAreaCode != salesSlipSearchResult2.SalesAreaCode) resList.Add("SalesAreaCode");
    //        if (salesSlipSearchResult1.SalesAreaName != salesSlipSearchResult2.SalesAreaName) resList.Add("SalesAreaName");
    //        if (salesSlipSearchResult1.ReconcileFlag != salesSlipSearchResult2.ReconcileFlag) resList.Add("ReconcileFlag");
    //        if (salesSlipSearchResult1.SlipPrtSetPaperId != salesSlipSearchResult2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
    //        if (salesSlipSearchResult1.CompleteCd != salesSlipSearchResult2.CompleteCd) resList.Add("CompleteCd");
    //        if (salesSlipSearchResult1.SalesPriceFracProcCd != salesSlipSearchResult2.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
    //        if (salesSlipSearchResult1.StockGoodsTtlTaxExc != salesSlipSearchResult2.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
    //        if (salesSlipSearchResult1.PureGoodsTtlTaxExc != salesSlipSearchResult2.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
    //        if (salesSlipSearchResult1.ListPricePrintDiv != salesSlipSearchResult2.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
    //        if (salesSlipSearchResult1.EraNameDispCd1 != salesSlipSearchResult2.EraNameDispCd1) resList.Add("EraNameDispCd1");
    //        if (salesSlipSearchResult1.EstimaTaxDivCd != salesSlipSearchResult2.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
    //        if (salesSlipSearchResult1.EstimateFormPrtCd != salesSlipSearchResult2.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
    //        if (salesSlipSearchResult1.EstimateSubject != salesSlipSearchResult2.EstimateSubject) resList.Add("EstimateSubject");
    //        if (salesSlipSearchResult1.Footnotes1 != salesSlipSearchResult2.Footnotes1) resList.Add("Footnotes1");
    //        if (salesSlipSearchResult1.Footnotes2 != salesSlipSearchResult2.Footnotes2) resList.Add("Footnotes2");
    //        if (salesSlipSearchResult1.EstimateTitle1 != salesSlipSearchResult2.EstimateTitle1) resList.Add("EstimateTitle1");
    //        if (salesSlipSearchResult1.EstimateTitle2 != salesSlipSearchResult2.EstimateTitle2) resList.Add("EstimateTitle2");
    //        if (salesSlipSearchResult1.EstimateTitle3 != salesSlipSearchResult2.EstimateTitle3) resList.Add("EstimateTitle3");
    //        if (salesSlipSearchResult1.EstimateTitle4 != salesSlipSearchResult2.EstimateTitle4) resList.Add("EstimateTitle4");
    //        if (salesSlipSearchResult1.EstimateTitle5 != salesSlipSearchResult2.EstimateTitle5) resList.Add("EstimateTitle5");
    //        if (salesSlipSearchResult1.EstimateNote1 != salesSlipSearchResult2.EstimateNote1) resList.Add("EstimateNote1");
    //        if (salesSlipSearchResult1.EstimateNote2 != salesSlipSearchResult2.EstimateNote2) resList.Add("EstimateNote2");
    //        if (salesSlipSearchResult1.EstimateNote3 != salesSlipSearchResult2.EstimateNote3) resList.Add("EstimateNote3");
    //        if (salesSlipSearchResult1.EstimateNote4 != salesSlipSearchResult2.EstimateNote4) resList.Add("EstimateNote4");
    //        if (salesSlipSearchResult1.EstimateNote5 != salesSlipSearchResult2.EstimateNote5) resList.Add("EstimateNote5");
    //        if (salesSlipSearchResult1.EstimateValidityDate != salesSlipSearchResult2.EstimateValidityDate) resList.Add("EstimateValidityDate");
    //        if (salesSlipSearchResult1.PartsNoPrtCd != salesSlipSearchResult2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
    //        if (salesSlipSearchResult1.OptionPringDivCd != salesSlipSearchResult2.OptionPringDivCd) resList.Add("OptionPringDivCd");
    //        if (salesSlipSearchResult1.RateUseCode != salesSlipSearchResult2.RateUseCode) resList.Add("RateUseCode");
    //        if (salesSlipSearchResult1.CarMngCode != salesSlipSearchResult2.CarMngCode) resList.Add("CarMngNo");
    //        if (salesSlipSearchResult1.ModelDesignationNo != salesSlipSearchResult2.ModelDesignationNo) resList.Add("ModelDesignationNo");
    //        if (salesSlipSearchResult1.CategoryNo != salesSlipSearchResult2.CategoryNo) resList.Add("CategoryNo");
    //        if (salesSlipSearchResult1.MakerFullName != salesSlipSearchResult2.MakerFullName) resList.Add("MakerFullName");
    //        if (salesSlipSearchResult1.FullModel != salesSlipSearchResult2.FullModel) resList.Add("FullModel");
    //        if (salesSlipSearchResult1.EnterpriseName != salesSlipSearchResult2.EnterpriseName) resList.Add("EnterpriseName");
    //        if (salesSlipSearchResult1.ResultsAddUpSecNm != salesSlipSearchResult2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");

    //        return resList;
    //    }
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

    /// public class name:   SalesSlipSearchResult
    /// <summary>
    ///                      ����`�[�������o����
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����`�[�������o���ʃw�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesSlipSearchResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���喼��</summary>
        private string _subSectionName = "";

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�ԍ��A������`�[�ԍ�</summary>
        /// <remarks>�ԍ��̑��������`�[�ԍ�</remarks>
        private string _debitNLnkSalesSlNum = "";

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���㏤�i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</remarks>
        private Int32 _salesGoodsCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>������͋��_�R�[�h</summary>
        /// <remarks>�����^ �������͂������_�R�[�h</remarks>
        private string _salesInpSecCd = "";

        /// <summary>�����v�㋒�_�R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _demandAddUpSecCd = "";

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _searchSlipDate;

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>�����敪</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>���Ϗ��ԍ�</summary>
        private string _estimateFormNo = "";

        /// <summary>���ϋ敪</summary>
        /// <remarks>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</remarks>
        private Int32 _estimateDivide;

        /// <summary>���͒S���҃R�[�h</summary>
        /// <remarks>���O�C���S���ҁi�t�r�a�j</remarks>
        private string _inputAgenCd = "";

        /// <summary>���͒S���Җ���</summary>
        private string _inputAgenNm = "";

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

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���z�\���|���K�p�敪</summary>
        /// <remarks>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</remarks>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>���㕔�i���v�i�ō��݁j</summary>
        /// <remarks>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</remarks>
        private Int64 _salesPrtTotalTaxInc;

        /// <summary>���㕔�i���v�i�Ŕ����j</summary>
        /// <remarks>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</remarks>
        private Int64 _salesPrtTotalTaxExc;

        /// <summary>�����ƍ��v�i�ō��݁j</summary>
        /// <remarks>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</remarks>
        private Int64 _salesWorkTotalTaxInc;

        /// <summary>�����ƍ��v�i�Ŕ����j</summary>
        /// <remarks>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</remarks>
        private Int64 _salesWorkTotalTaxExc;

        /// <summary>���㏬�v�i�ō��݁j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _salesSubtotalTaxInc;

        /// <summary>���㏬�v�i�Ŕ����j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _salesSubtotalTaxExc;

        /// <summary>���㕔�i���v�i�ō��݁j</summary>
        /// <remarks>���i���׋��z�̐ō����v</remarks>
        private Int64 _salesPrtSubttlInc;

        /// <summary>���㕔�i���v�i�Ŕ����j</summary>
        /// <remarks>���i���׋��z�̐Ŕ����v</remarks>
        private Int64 _salesPrtSubttlExc;

        /// <summary>�����Ə��v�i�ō��݁j</summary>
        /// <remarks>��Ɩ��׋��z�̐ō����v</remarks>
        private Int64 _salesWorkSubttlInc;

        /// <summary>�����Ə��v�i�Ŕ����j</summary>
        /// <remarks>��Ɩ��׋��z�̐Ŕ����v</remarks>
        private Int64 _salesWorkSubttlExc;

        /// <summary>���㐳�����z</summary>
        /// <remarks>�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j</remarks>
        private Int64 _salesNetPrice;

        /// <summary>���㏬�v�i�Łj</summary>
        /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
        private Int64 _salesSubtotalTax;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>������őΏۊz</summary>
        /// <remarks>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>���㏬�v��ېőΏۊz</summary>
        /// <remarks>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</remarks>
        private Int64 _salSubttlSubToTaxFre;

        /// <summary>������z����Ŋz�i�O�Łj</summary>
        /// <remarks>�l���O�̊O�ŏ��i�̏����</remarks>
        private Int64 _salesOutTax;

        /// <summary>������z����Ŋz�i���Łj</summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>����l�����z�v�i�Ŕ����j</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>����l���O�őΏۊz���v</summary>
        /// <remarks>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedSalesDisOutTax;

        /// <summary>����l�����őΏۊz���v</summary>
        /// <remarks>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedSalesDisInTax;

        /// <summary>���i�l���Ώۊz���v�i�Ŕ����j</summary>
        /// <remarks>���i�l���z�i�Ŕ����j</remarks>
        private Int64 _itdedPartsDisOutTax;

        /// <summary>���i�l���Ώۊz���v�i�ō��݁j</summary>
        /// <remarks>���i�l���z�i�ō��݁j</remarks>
        private Int64 _itdedPartsDisInTax;

        /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j</summary>
        /// <remarks>��ƒl���z�i�Ŕ����j</remarks>
        private Int64 _itdedWorkDisOutTax;

        /// <summary>��ƒl���Ώۊz���v�i�ō��݁j</summary>
        /// <remarks>��ƒl���z�i�ō��݁j</remarks>
        private Int64 _itdedWorkDisInTax;

        /// <summary>����l����ېőΏۊz���v</summary>
        /// <remarks>��ېŏ��i�l���̔�ېőΏۊz</remarks>
        private Int64 _itdedSalesDisTaxFre;

        /// <summary>����l������Ŋz�i�O�Łj</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>����l������Ŋz�i���Łj</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>���i�l����</summary>
        /// <remarks>���v�ɑ΂��Ă̕��i�l����</remarks>
        private Double _partsDiscountRate;

        /// <summary>�H���l����</summary>
        /// <remarks>���v�ɑ΂��Ă̍H���l����</remarks>
        private Double _ravorDiscountRate;

        /// <summary>�������z�v</summary>
        private Int64 _totalCost;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����Őŗ�</summary>
        private Double _consTaxRate;

        /// <summary>�[�������敪</summary>
        /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
        private Int32 _fractionProcCd;

        /// <summary>���|�����</summary>
        private Int64 _accRecConsTax;

        /// <summary>���������敪</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _autoDepositCd;

        /// <summary>���������`�[�ԍ�</summary>
        /// <remarks>�����������̓����`�[�ԍ�</remarks>
        private Int32 _autoDepositSlipNo;

        /// <summary>�����������v�z</summary>
        /// <remarks>�a����������v�z���܂�</remarks>
        private Int64 _depositAllowanceTtl;

        /// <summary>���������c��</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>��������</summary>
        private string _outputName = "";

        /// <summary>���Ӑ�`�[�ԍ�</summary>
        private Int32 _custSlipNo;

        /// <summary>�`�[�Z���敪</summary>
        /// <remarks>1:���Ӑ�,2:�[����</remarks>
        private Int32 _slipAddressDiv;

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
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

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        private string _slipNote3 = "";

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>�ԕi���R</summary>
        private string _retGoodsReason = "";

        /// <summary>���W������</summary>
        /// <remarks>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private DateTime _regiProcDate;

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>POS���V�[�g�ԍ�</summary>
        /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _posReceiptNo;

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

        /// <summary>����`�[���s��</summary>
        private DateTime _salesSlipPrintDate;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>�����ԍ�</summary>
        /// <remarks>����`����"��"�̎��ɃZ�b�g</remarks>
        private string _orderNumber = "";

        /// <summary>�[�i�敪</summary>
        /// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>�����t���O</summary>
        /// <remarks>0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</remarks>
        private Int32 _reconcileFlag;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�ꎮ�`�[�敪</summary>
        /// <remarks>0:�ʏ�`�[,1:�ꎮ�`�[</remarks>
        private Int32 _completeCd;

        /// <summary>������z�[�������敪</summary>
        /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</remarks>
        private Int32 _salesPriceFracProcCd;

        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j</summary>
        /// <remarks>�݌Ɏ��敪���O�̖��׋��z�̏W�v</remarks>
        private Int64 _stockGoodsTtlTaxExc;

        /// <summary>�������i���v���z�i�Ŕ��j</summary>
        /// <remarks>���i�������O�̖��׋��z�̏W�v</remarks>
        private Int64 _pureGoodsTtlTaxExc;

        /// <summary>�艿����敪</summary>
        private Int32 _listPricePrintDiv;

        /// <summary>�����\���敪�P</summary>
        /// <remarks>�ʏ�@�@0:����@1:�a��</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>���Ϗ���ŋ敪</summary>
        /// <remarks>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</remarks>
        private Int32 _estimaTaxDivCd;

        /// <summary>���Ϗ�����敪</summary>
        private Int32 _estimateFormPrtCd;

        /// <summary>���ό���</summary>
        private string _estimateSubject = "";

        /// <summary>�r���P</summary>
        private string _footnotes1 = "";

        /// <summary>�r���Q</summary>
        private string _footnotes2 = "";

        /// <summary>���σ^�C�g���P</summary>
        private string _estimateTitle1 = "";

        /// <summary>���σ^�C�g���Q</summary>
        private string _estimateTitle2 = "";

        /// <summary>���σ^�C�g���R</summary>
        private string _estimateTitle3 = "";

        /// <summary>���σ^�C�g���S</summary>
        private string _estimateTitle4 = "";

        /// <summary>���σ^�C�g���T</summary>
        private string _estimateTitle5 = "";

        /// <summary>���ϔ��l�P</summary>
        private string _estimateNote1 = "";

        /// <summary>���ϔ��l�Q</summary>
        private string _estimateNote2 = "";

        /// <summary>���ϔ��l�R</summary>
        private string _estimateNote3 = "";

        /// <summary>���ϔ��l�S</summary>
        private string _estimateNote4 = "";

        /// <summary>���ϔ��l�T</summary>
        private string _estimateNote5 = "";

        /// <summary>���ϗL������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _estimateValidityDate;

        /// <summary>�i�Ԉ󎚋敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _partsNoPrtCd;

        /// <summary>�I�v�V�����󎚋敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _optionPringDivCd;

        /// <summary>�|���g�p�敪</summary>
        /// <remarks>0:�������艿 1:�|���w��,2:�|���ݒ�</remarks>
        private Int32 _rateUseCode;

        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>���[�J�[�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _makerFullName = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>���ьv�㋒�_����</summary>
        private string _resultsAddUpSecNm = "";


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
        /// <value>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </value>
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

        /// public propaty name  :  DebitNLnkSalesSlNum
        /// <summary>�ԍ��A������`�[�ԍ��v���p�e�B</summary>
        /// <value>�ԍ��̑��������`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��A������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DebitNLnkSalesSlNum
        {
            get { return _debitNLnkSalesSlNum; }
            set { _debitNLnkSalesSlNum = value; }
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

        /// public propaty name  :  SalesGoodsCd
        /// <summary>���㏤�i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
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

        /// public propaty name  :  SalesInpSecCd
        /// <summary>������͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �������͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInpSecCd
        {
            get { return _salesInpSecCd; }
            set { _salesInpSecCd = value; }
        }

        /// public propaty name  :  DemandAddUpSecCd
        /// <summary>�����v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DemandAddUpSecCd
        {
            get { return _demandAddUpSecCd; }
            set { _demandAddUpSecCd = value; }
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

        /// public propaty name  :  UpdateSecCd
        /// <summary>�X�V���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �f�[�^�̓o�^�X�V���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
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

        /// public propaty name  :  SearchSlipDateJpFormal
        /// <summary>�`�[�������t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _searchSlipDate ); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateJpInFormal
        /// <summary>�`�[�������t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _searchSlipDate ); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateAdFormal
        /// <summary>�`�[�������t ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _searchSlipDate ); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateAdInFormal
        /// <summary>�`�[�������t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _searchSlipDate ); }
            set { }
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

        /// public propaty name  :  ShipmentDayJpFormal
        /// <summary>�o�ד��t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _shipmentDay ); }
            set { }
        }

        /// public propaty name  :  ShipmentDayJpInFormal
        /// <summary>�o�ד��t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _shipmentDay ); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdFormal
        /// <summary>�o�ד��t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _shipmentDay ); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdInFormal
        /// <summary>�o�ד��t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _shipmentDay ); }
            set { }
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

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>������t �a��v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _salesDate ); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>������t �a��(��)�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _salesDate ); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>������t ����v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _salesDate ); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>������t ����(��)�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _salesDate ); }
            set { }
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

        /// public propaty name  :  AddUpADateJpFormal
        /// <summary>�v����t �a��v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _addUpADate ); }
            set { }
        }

        /// public propaty name  :  AddUpADateJpInFormal
        /// <summary>�v����t �a��(��)�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _addUpADate ); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdFormal
        /// <summary>�v����t ����v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _addUpADate ); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdInFormal
        /// <summary>�v����t ����(��)�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _addUpADate ); }
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

        /// public propaty name  :  EstimateFormNo
        /// <summary>���Ϗ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateFormNo
        {
            get { return _estimateFormNo; }
            set { _estimateFormNo = value; }
        }

        /// public propaty name  :  EstimateDivide
        /// <summary>���ϋ敪�v���p�e�B</summary>
        /// <value>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateDivide
        {
            get { return _estimateDivide; }
            set { _estimateDivide = value; }
        }

        /// public propaty name  :  InputAgenCd
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// <value>���O�C���S���ҁi�t�r�a�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  InputAgenNm
        /// <summary>���͒S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenNm
        {
            get { return _inputAgenNm; }
            set { _inputAgenNm = value; }
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

        /// public propaty name  :  SalesPrtTotalTaxInc
        /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtTotalTaxInc
        {
            get { return _salesPrtTotalTaxInc; }
            set { _salesPrtTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPrtTotalTaxExc
        /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtTotalTaxExc
        {
            get { return _salesPrtTotalTaxExc; }
            set { _salesPrtTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesWorkTotalTaxInc
        /// <summary>�����ƍ��v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ƍ��v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkTotalTaxInc
        {
            get { return _salesWorkTotalTaxInc; }
            set { _salesWorkTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesWorkTotalTaxExc
        /// <summary>�����ƍ��v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ƍ��v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkTotalTaxExc
        {
            get { return _salesWorkTotalTaxExc; }
            set { _salesWorkTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxInc
        /// <summary>���㏬�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTaxInc
        {
            get { return _salesSubtotalTaxInc; }
            set { _salesSubtotalTaxInc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxExc
        /// <summary>���㏬�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTaxExc
        {
            get { return _salesSubtotalTaxExc; }
            set { _salesSubtotalTaxExc = value; }
        }

        /// public propaty name  :  SalesPrtSubttlInc
        /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���i���׋��z�̐ō����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtSubttlInc
        {
            get { return _salesPrtSubttlInc; }
            set { _salesPrtSubttlInc = value; }
        }

        /// public propaty name  :  SalesPrtSubttlExc
        /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���i���׋��z�̐Ŕ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtSubttlExc
        {
            get { return _salesPrtSubttlExc; }
            set { _salesPrtSubttlExc = value; }
        }

        /// public propaty name  :  SalesWorkSubttlInc
        /// <summary>�����Ə��v�i�ō��݁j�v���p�e�B</summary>
        /// <value>��Ɩ��׋��z�̐ō����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ə��v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkSubttlInc
        {
            get { return _salesWorkSubttlInc; }
            set { _salesWorkSubttlInc = value; }
        }

        /// public propaty name  :  SalesWorkSubttlExc
        /// <summary>�����Ə��v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>��Ɩ��׋��z�̐Ŕ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ə��v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkSubttlExc
        {
            get { return _salesWorkSubttlExc; }
            set { _salesWorkSubttlExc = value; }
        }

        /// public propaty name  :  SalesNetPrice
        /// <summary>���㐳�����z�v���p�e�B</summary>
        /// <value>�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐳�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesNetPrice
        {
            get { return _salesNetPrice; }
            set { _salesNetPrice = value; }
        }

        /// public propaty name  :  SalesSubtotalTax
        /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
        /// <value>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTax
        {
            get { return _salesSubtotalTax; }
            set { _salesSubtotalTax = value; }
        }

        /// public propaty name  :  ItdedSalesOutTax
        /// <summary>����O�őΏۊz�v���p�e�B</summary>
        /// <value>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesOutTax
        {
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesInTax
        /// <summary>������őΏۊz�v���p�e�B</summary>
        /// <value>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesInTax
        {
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
        }

        /// public propaty name  :  SalSubttlSubToTaxFre
        /// <summary>���㏬�v��ېőΏۊz�v���p�e�B</summary>
        /// <value>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v��ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalSubttlSubToTaxFre
        {
            get { return _salSubttlSubToTaxFre; }
            set { _salSubttlSubToTaxFre = value; }
        }

        /// public propaty name  :  SalesOutTax
        /// <summary>������z����Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�l���O�̊O�ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesOutTax
        {
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
        }

        /// public propaty name  :  SalAmntConsTaxInclu
        /// <summary>������z����Ŋz�i���Łj�v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
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

        /// public propaty name  :  ItdedSalesDisOutTax
        /// <summary>����l���O�őΏۊz���v�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesDisOutTax
        {
            get { return _itdedSalesDisOutTax; }
            set { _itdedSalesDisOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesDisInTax
        /// <summary>����l�����őΏۊz���v�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesDisInTax
        {
            get { return _itdedSalesDisInTax; }
            set { _itdedSalesDisInTax = value; }
        }

        /// public propaty name  :  ItdedPartsDisOutTax
        /// <summary>���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���i�l���z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedPartsDisOutTax
        {
            get { return _itdedPartsDisOutTax; }
            set { _itdedPartsDisOutTax = value; }
        }

        /// public propaty name  :  ItdedPartsDisInTax
        /// <summary>���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���i�l���z�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedPartsDisInTax
        {
            get { return _itdedPartsDisInTax; }
            set { _itdedPartsDisInTax = value; }
        }

        /// public propaty name  :  ItdedWorkDisOutTax
        /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>��ƒl���z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedWorkDisOutTax
        {
            get { return _itdedWorkDisOutTax; }
            set { _itdedWorkDisOutTax = value; }
        }

        /// public propaty name  :  ItdedWorkDisInTax
        /// <summary>��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>��ƒl���z�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedWorkDisInTax
        {
            get { return _itdedWorkDisInTax; }
            set { _itdedWorkDisInTax = value; }
        }

        /// public propaty name  :  ItdedSalesDisTaxFre
        /// <summary>����l����ېőΏۊz���v�v���p�e�B</summary>
        /// <value>��ېŏ��i�l���̔�ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesDisTaxFre
        {
            get { return _itdedSalesDisTaxFre; }
            set { _itdedSalesDisTaxFre = value; }
        }

        /// public propaty name  :  SalesDisOutTax
        /// <summary>����l������Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisOutTax
        {
            get { return _salesDisOutTax; }
            set { _salesDisOutTax = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxInclu
        /// <summary>����l������Ŋz�i���Łj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxInclu
        {
            get { return _salesDisTtlTaxInclu; }
            set { _salesDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  PartsDiscountRate
        /// <summary>���i�l�����v���p�e�B</summary>
        /// <value>���v�ɑ΂��Ă̕��i�l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PartsDiscountRate
        {
            get { return _partsDiscountRate; }
            set { _partsDiscountRate = value; }
        }

        /// public propaty name  :  RavorDiscountRate
        /// <summary>�H���l�����v���p�e�B</summary>
        /// <value>���v�ɑ΂��Ă̍H���l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �H���l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RavorDiscountRate
        {
            get { return _ravorDiscountRate; }
            set { _ravorDiscountRate = value; }
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

        /// public propaty name  :  ConsTaxRate
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

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  AccRecConsTax
        /// <summary>���|����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AccRecConsTax
        {
            get { return _accRecConsTax; }
            set { _accRecConsTax = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        /// public propaty name  :  AutoDepositSlipNo
        /// <summary>���������`�[�ԍ��v���p�e�B</summary>
        /// <value>�����������̓����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositSlipNo
        {
            get { return _autoDepositSlipNo; }
            set { _autoDepositSlipNo = value; }
        }

        /// public propaty name  :  DepositAllowanceTtl
        /// <summary>�����������v�z�v���p�e�B</summary>
        /// <value>�a����������v�z���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAllowanceTtl
        {
            get { return _depositAllowanceTtl; }
            set { _depositAllowanceTtl = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>���������c���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
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

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
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

        /// public propaty name  :  HonorificTitle
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
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

        /// public propaty name  :  RegiProcDate
        /// <summary>���W�������v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime RegiProcDate
        {
            get { return _regiProcDate; }
            set { _regiProcDate = value; }
        }

        /// public propaty name  :  RegiProcDateJpFormal
        /// <summary>���W������ �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _regiProcDate ); }
            set { }
        }

        /// public propaty name  :  RegiProcDateJpInFormal
        /// <summary>���W������ �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _regiProcDate ); }
            set { }
        }

        /// public propaty name  :  RegiProcDateAdFormal
        /// <summary>���W������ ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _regiProcDate ); }
            set { }
        }

        /// public propaty name  :  RegiProcDateAdInFormal
        /// <summary>���W������ ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _regiProcDate ); }
            set { }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  PosReceiptNo
        /// <summary>POS���V�[�g�ԍ��v���p�e�B</summary>
        /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POS���V�[�g�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PosReceiptNo
        {
            get { return _posReceiptNo; }
            set { _posReceiptNo = value; }
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

        /// public propaty name  :  SalesSlipPrintDate
        /// <summary>����`�[���s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesSlipPrintDate
        {
            get { return _salesSlipPrintDate; }
            set { _salesSlipPrintDate = value; }
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

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>����`����"��"�̎��ɃZ�b�g</value>
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

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>��) 1:�z�B,2:�X���n��,3:����,�c</value>
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

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
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

        /// public propaty name  :  ReconcileFlag
        /// <summary>�����t���O�v���p�e�B</summary>
        /// <value>0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReconcileFlag
        {
            get { return _reconcileFlag; }
            set { _reconcileFlag = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</value>
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

        /// public propaty name  :  CompleteCd
        /// <summary>�ꎮ�`�[�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�`�[,1:�ꎮ�`�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ�`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompleteCd
        {
            get { return _completeCd; }
            set { _completeCd = value; }
        }

        /// public propaty name  :  SalesPriceFracProcCd
        /// <summary>������z�[�������敪�v���p�e�B</summary>
        /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesPriceFracProcCd
        {
            get { return _salesPriceFracProcCd; }
            set { _salesPriceFracProcCd = value; }
        }

        /// public propaty name  :  StockGoodsTtlTaxExc
        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>�݌Ɏ��敪���O�̖��׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockGoodsTtlTaxExc
        {
            get { return _stockGoodsTtlTaxExc; }
            set { _stockGoodsTtlTaxExc = value; }
        }

        /// public propaty name  :  PureGoodsTtlTaxExc
        /// <summary>�������i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>���i�������O�̖��׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PureGoodsTtlTaxExc
        {
            get { return _pureGoodsTtlTaxExc; }
            set { _pureGoodsTtlTaxExc = value; }
        }

        /// public propaty name  :  ListPricePrintDiv
        /// <summary>�艿����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPricePrintDiv
        {
            get { return _listPricePrintDiv; }
            set { _listPricePrintDiv = value; }
        }

        /// public propaty name  :  EraNameDispCd1
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>�ʏ�@�@0:����@1:�a��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// public propaty name  :  EstimaTaxDivCd
        /// <summary>���Ϗ���ŋ敪�v���p�e�B</summary>
        /// <value>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ���ŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimaTaxDivCd
        {
            get { return _estimaTaxDivCd; }
            set { _estimaTaxDivCd = value; }
        }

        /// public propaty name  :  EstimateFormPrtCd
        /// <summary>���Ϗ�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateFormPrtCd
        {
            get { return _estimateFormPrtCd; }
            set { _estimateFormPrtCd = value; }
        }

        /// public propaty name  :  EstimateSubject
        /// <summary>���ό����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ό����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateSubject
        {
            get { return _estimateSubject; }
            set { _estimateSubject = value; }
        }

        /// public propaty name  :  Footnotes1
        /// <summary>�r���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Footnotes1
        {
            get { return _footnotes1; }
            set { _footnotes1 = value; }
        }

        /// public propaty name  :  Footnotes2
        /// <summary>�r���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Footnotes2
        {
            get { return _footnotes2; }
            set { _footnotes2 = value; }
        }

        /// public propaty name  :  EstimateTitle1
        /// <summary>���σ^�C�g���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle1
        {
            get { return _estimateTitle1; }
            set { _estimateTitle1 = value; }
        }

        /// public propaty name  :  EstimateTitle2
        /// <summary>���σ^�C�g���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle2
        {
            get { return _estimateTitle2; }
            set { _estimateTitle2 = value; }
        }

        /// public propaty name  :  EstimateTitle3
        /// <summary>���σ^�C�g���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle3
        {
            get { return _estimateTitle3; }
            set { _estimateTitle3 = value; }
        }

        /// public propaty name  :  EstimateTitle4
        /// <summary>���σ^�C�g���S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle4
        {
            get { return _estimateTitle4; }
            set { _estimateTitle4 = value; }
        }

        /// public propaty name  :  EstimateTitle5
        /// <summary>���σ^�C�g���T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle5
        {
            get { return _estimateTitle5; }
            set { _estimateTitle5 = value; }
        }

        /// public propaty name  :  EstimateNote1
        /// <summary>���ϔ��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote1
        {
            get { return _estimateNote1; }
            set { _estimateNote1 = value; }
        }

        /// public propaty name  :  EstimateNote2
        /// <summary>���ϔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote2
        {
            get { return _estimateNote2; }
            set { _estimateNote2 = value; }
        }

        /// public propaty name  :  EstimateNote3
        /// <summary>���ϔ��l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote3
        {
            get { return _estimateNote3; }
            set { _estimateNote3 = value; }
        }

        /// public propaty name  :  EstimateNote4
        /// <summary>���ϔ��l�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote4
        {
            get { return _estimateNote4; }
            set { _estimateNote4 = value; }
        }

        /// public propaty name  :  EstimateNote5
        /// <summary>���ϔ��l�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote5
        {
            get { return _estimateNote5; }
            set { _estimateNote5 = value; }
        }

        /// public propaty name  :  EstimateValidityDate
        /// <summary>���ϗL�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EstimateValidityDate
        {
            get { return _estimateValidityDate; }
            set { _estimateValidityDate = value; }
        }

        /// public propaty name  :  EstimateValidityDateJpFormal
        /// <summary>���ϗL������ �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _estimateValidityDate ); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateJpInFormal
        /// <summary>���ϗL������ �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _estimateValidityDate ); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateAdFormal
        /// <summary>���ϗL������ ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _estimateValidityDate ); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateAdInFormal
        /// <summary>���ϗL������ ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _estimateValidityDate ); }
            set { }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  OptionPringDivCd
        /// <summary>�I�v�V�����󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�v�V�����󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OptionPringDivCd
        {
            get { return _optionPringDivCd; }
            set { _optionPringDivCd = value; }
        }

        /// public propaty name  :  RateUseCode
        /// <summary>�|���g�p�敪�v���p�e�B</summary>
        /// <value>0:�������艿 1:�|���w��,2:�|���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateUseCode
        {
            get { return _rateUseCode; }
            set { _rateUseCode = value; }
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

        /// public propaty name  :  MakerFullName
        /// <summary>���[�J�[�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerFullName
        {
            get { return _makerFullName; }
            set { _makerFullName = value; }
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

        /// public propaty name  :  ResultsAddUpSecNm
        /// <summary>���ьv�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecNm
        {
            get { return _resultsAddUpSecNm; }
            set { _resultsAddUpSecNm = value; }
        }


        /// <summary>
        /// ����`�[�������o���ʃR���X�g���N�^
        /// </summary>
        /// <returns>SalesSlipSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlipSearchResult()
        {
        }

        /// <summary>
        /// ����`�[�������o���ʃR���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  )</param>
        /// <param name="salesSlipNum">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionGuideNm">���_�K�C�h����</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="subSectionName">���喼��</param>
        /// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
        /// <param name="debitNLnkSalesSlNum">�ԍ��A������`�[�ԍ�(�ԍ��̑��������`�[�ԍ�)</param>
        /// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi)</param>
        /// <param name="salesGoodsCd">���㏤�i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����))</param>
        /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="salesInpSecCd">������͋��_�R�[�h(�����^ �������͂������_�R�[�h)</param>
        /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h(�����^)</param>
        /// <param name="resultsAddUpSecCd">���ьv�㋒�_�R�[�h(���ьv����s����Ɠ��̋��_�R�[�h)</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
        /// <param name="searchSlipDate">�`�[�������t(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="shipmentDay">�o�ד��t(YYYYMMDD)</param>
        /// <param name="salesDate">������t(���ϓ��A�󒍓��A����������˂�B(YYYYMMDD))</param>
        /// <param name="addUpADate">�v����t(�������@(YYYYMMDD))</param>
        /// <param name="delayPaymentDiv">�����敪(0:����(�����Ȃ�),1:����,2:�ė����c9:9������)</param>
        /// <param name="estimateFormNo">���Ϗ��ԍ�</param>
        /// <param name="estimateDivide">���ϋ敪(1:�ʏ팩�ρ@2:�P�����ρ@3:��������)</param>
        /// <param name="inputAgenCd">���͒S���҃R�[�h(���O�C���S���ҁi�t�r�a�j)</param>
        /// <param name="inputAgenNm">���͒S���Җ���</param>
        /// <param name="salesInputCode">������͎҃R�[�h(���͒S���ҁi���s�ҁj)</param>
        /// <param name="salesInputName">������͎Җ���</param>
        /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(��t�S���ҁi�󒍎ҁj)</param>
        /// <param name="frontEmployeeNm">��t�]�ƈ�����</param>
        /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(�v��S���ҁi�S���ҁj)</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="ttlAmntDispRateApy">���z�\���|���K�p�敪(0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��)</param>
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��݁j(���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz)</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ����j(���㐳�����z�{����l�����z�v�i�Ŕ����j)</param>
        /// <param name="salesPrtTotalTaxInc">���㕔�i���v�i�ō��݁j(���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j)</param>
        /// <param name="salesPrtTotalTaxExc">���㕔�i���v�i�Ŕ����j(���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j)</param>
        /// <param name="salesWorkTotalTaxInc">�����ƍ��v�i�ō��݁j(�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j)</param>
        /// <param name="salesWorkTotalTaxExc">�����ƍ��v�i�Ŕ����j(�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j)</param>
        /// <param name="salesSubtotalTaxInc">���㏬�v�i�ō��݁j(�l����̖��׋��z�̍��v�i��ېŊ܂܂��j)</param>
        /// <param name="salesSubtotalTaxExc">���㏬�v�i�Ŕ����j(�l����̖��׋��z�̍��v�i��ېŊ܂܂��j)</param>
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��݁j(���i���׋��z�̐ō����v)</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ����j(���i���׋��z�̐Ŕ����v)</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��݁j(��Ɩ��׋��z�̐ō����v)</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ����j(��Ɩ��׋��z�̐Ŕ����v)</param>
        /// <param name="salesNetPrice">���㐳�����z(�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j)</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj(�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j)</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz(���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j )</param>
        /// <param name="itdedSalesInTax">������őΏۊz(��ېőΏۋ��z�̏W�v�i�l���܂܂��j)</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz(������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�)</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj(�l���O�̊O�ŏ��i�̏����)</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj(�l���O�̓��ŏ��i�̏����)</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ����j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v(�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j)</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v(���ŏ��i�l���̓��őΏۊz�i�Ŕ��j)</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ����j(���i�l���z�i�Ŕ����j)</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��݁j(���i�l���z�i�ō��݁j)</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ����j(��ƒl���z�i�Ŕ����j)</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��݁j(��ƒl���z�i�ō��݁j)</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v(��ېŏ��i�l���̔�ېőΏۊz)</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj(�O�ŏ��i�l���̏���Ŋz)</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="partsDiscountRate">���i�l����(���v�ɑ΂��Ă̕��i�l����)</param>
        /// <param name="ravorDiscountRate">�H���l����(���v�ɑ΂��Ă̍H���l����)</param>
        /// <param name="totalCost">�������z�v</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�)</param>
        /// <param name="consTaxRate">����Őŗ�</param>
        /// <param name="fractionProcCd">�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj)</param>
        /// <param name="accRecConsTax">���|�����</param>
        /// <param name="autoDepositCd">���������敪(0:�ʏ����,1:��������)</param>
        /// <param name="autoDepositSlipNo">���������`�[�ԍ�(�����������̓����`�[�ԍ�)</param>
        /// <param name="depositAllowanceTtl">�����������v�z(�a����������v�z���܂�)</param>
        /// <param name="depositAlwcBlnce">���������c��</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="outputName">��������</param>
        /// <param name="custSlipNo">���Ӑ�`�[�ԍ�</param>
        /// <param name="slipAddressDiv">�`�[�Z���敪(1:���Ӑ�,2:�[����)</param>
        /// <param name="addresseeCode">�[�i��R�[�h</param>
        /// <param name="addresseeName">�[�i�於��</param>
        /// <param name="addresseeName2">�[�i�於��2</param>
        /// <param name="addresseePostNo">�[�i��X�֔ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr1">�[�i��Z��1(�s���{���s��S�E�����E��)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr3">�[�i��Z��3(�Ԓn)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr4">�[�i��Z��4(�A�p�[�g����)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeTelNo">�[�i��d�b�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeFaxNo">�[�i��FAX�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�(���Ӑ撍���ԍ��i���`�ԍ��j)</param>
        /// <param name="slipNote">�`�[���l</param>
        /// <param name="slipNote2">�`�[���l�Q</param>
        /// <param name="slipNote3">�`�[���l�R</param>
        /// <param name="retGoodsReasonDiv">�ԕi���R�R�[�h</param>
        /// <param name="retGoodsReason">�ԕi���R</param>
        /// <param name="regiProcDate">���W������(YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
        /// <param name="cashRegisterNo">���W�ԍ�(�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
        /// <param name="posReceiptNo">POS���V�[�g�ԍ�(�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
        /// <param name="detailRowCount">���׍s��(�`�[���̖��ׂ̍s���i����p���ׂ͏����j)</param>
        /// <param name="ediSendDate">�d�c�h���M��(YYYYMMDD �iErectricDataInterface�j)</param>
        /// <param name="ediTakeInDate">�d�c�h�捞��(YYYYMMDD)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P(UserOrderEntory)</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="slipPrintDivCd">�`�[���s�敪(0:���Ȃ� 1:����)</param>
        /// <param name="slipPrintFinishCd">�`�[���s�ϋ敪(0:�����s 1:���s��)</param>
        /// <param name="salesSlipPrintDate">����`�[���s��</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <param name="orderNumber">�����ԍ�(����`����"��"�̎��ɃZ�b�g)</param>
        /// <param name="deliveredGoodsDiv">�[�i�敪(��) 1:�z�B,2:�X���n��,3:����,�c)</param>
        /// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
        /// <param name="salesAreaName">�̔��G���A����</param>
        /// <param name="reconcileFlag">�����t���O(0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j)</param>
        /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��)</param>
        /// <param name="completeCd">�ꎮ�`�[�敪(0:�ʏ�`�[,1:�ꎮ�`�[)</param>
        /// <param name="salesPriceFracProcCd">������z�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j)</param>
        /// <param name="stockGoodsTtlTaxExc">�݌ɏ��i���v���z�i�Ŕ��j(�݌Ɏ��敪���O�̖��׋��z�̏W�v)</param>
        /// <param name="pureGoodsTtlTaxExc">�������i���v���z�i�Ŕ��j(���i�������O�̖��׋��z�̏W�v)</param>
        /// <param name="listPricePrintDiv">�艿����敪</param>
        /// <param name="eraNameDispCd1">�����\���敪�P(�ʏ�@�@0:����@1:�a��)</param>
        /// <param name="estimaTaxDivCd">���Ϗ���ŋ敪(0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j)</param>
        /// <param name="estimateFormPrtCd">���Ϗ�����敪</param>
        /// <param name="estimateSubject">���ό���</param>
        /// <param name="footnotes1">�r���P</param>
        /// <param name="footnotes2">�r���Q</param>
        /// <param name="estimateTitle1">���σ^�C�g���P</param>
        /// <param name="estimateTitle2">���σ^�C�g���Q</param>
        /// <param name="estimateTitle3">���σ^�C�g���R</param>
        /// <param name="estimateTitle4">���σ^�C�g���S</param>
        /// <param name="estimateTitle5">���σ^�C�g���T</param>
        /// <param name="estimateNote1">���ϔ��l�P</param>
        /// <param name="estimateNote2">���ϔ��l�Q</param>
        /// <param name="estimateNote3">���ϔ��l�R</param>
        /// <param name="estimateNote4">���ϔ��l�S</param>
        /// <param name="estimateNote5">���ϔ��l�T</param>
        /// <param name="estimateValidityDate">���ϗL������(YYYYMMDD)</param>
        /// <param name="partsNoPrtCd">�i�Ԉ󎚋敪(0:���Ȃ�,1:����)</param>
        /// <param name="optionPringDivCd">�I�v�V�����󎚋敪(0:���Ȃ�,1:����)</param>
        /// <param name="rateUseCode">�|���g�p�敪(0:�������艿 1:�|���w��,2:�|���ݒ�)</param>
        /// <param name="carMngCode">���q�Ǘ��R�[�h(��PM7�ł̎ԗ��Ǘ��ԍ�)</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʔԍ�</param>
        /// <param name="makerFullName">���[�J�[�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
        /// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
        /// <param name="modelFullName">�Ԏ�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="resultsAddUpSecNm">���ьv�㋒�_����</param>
        /// <returns>SalesSlipSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlipSearchResult( string enterpriseCode, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, string sectionGuideNm, Int32 subSectionCode, string subSectionName, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, string carMngCode, Int32 modelDesignationNo, Int32 categoryNo, string makerFullName, string fullModel, string modelFullName, string enterpriseName, string resultsAddUpSecNm )
        {
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._sectionCode = sectionCode;
            this._sectionGuideNm = sectionGuideNm;
            this._subSectionCode = subSectionCode;
            this._subSectionName = subSectionName;
            this._debitNoteDiv = debitNoteDiv;
            this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
            this._salesSlipCd = salesSlipCd;
            this._salesGoodsCd = salesGoodsCd;
            this._accRecDivCd = accRecDivCd;
            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this.SearchSlipDate = searchSlipDate;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
            this.AddUpADate = addUpADate;
            this._delayPaymentDiv = delayPaymentDiv;
            this._estimateFormNo = estimateFormNo;
            this._estimateDivide = estimateDivide;
            this._inputAgenCd = inputAgenCd;
            this._inputAgenNm = inputAgenNm;
            this._salesInputCode = salesInputCode;
            this._salesInputName = salesInputName;
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this._salesEmployeeCd = salesEmployeeCd;
            this._salesEmployeeNm = salesEmployeeNm;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDispRateApy = ttlAmntDispRateApy;
            this._salesTotalTaxInc = salesTotalTaxInc;
            this._salesTotalTaxExc = salesTotalTaxExc;
            this._salesPrtTotalTaxInc = salesPrtTotalTaxInc;
            this._salesPrtTotalTaxExc = salesPrtTotalTaxExc;
            this._salesWorkTotalTaxInc = salesWorkTotalTaxInc;
            this._salesWorkTotalTaxExc = salesWorkTotalTaxExc;
            this._salesSubtotalTaxInc = salesSubtotalTaxInc;
            this._salesSubtotalTaxExc = salesSubtotalTaxExc;
            this._salesPrtSubttlInc = salesPrtSubttlInc;
            this._salesPrtSubttlExc = salesPrtSubttlExc;
            this._salesWorkSubttlInc = salesWorkSubttlInc;
            this._salesWorkSubttlExc = salesWorkSubttlExc;
            this._salesNetPrice = salesNetPrice;
            this._salesSubtotalTax = salesSubtotalTax;
            this._itdedSalesOutTax = itdedSalesOutTax;
            this._itdedSalesInTax = itdedSalesInTax;
            this._salSubttlSubToTaxFre = salSubttlSubToTaxFre;
            this._salesOutTax = salesOutTax;
            this._salAmntConsTaxInclu = salAmntConsTaxInclu;
            this._salesDisTtlTaxExc = salesDisTtlTaxExc;
            this._itdedSalesDisOutTax = itdedSalesDisOutTax;
            this._itdedSalesDisInTax = itdedSalesDisInTax;
            this._itdedPartsDisOutTax = itdedPartsDisOutTax;
            this._itdedPartsDisInTax = itdedPartsDisInTax;
            this._itdedWorkDisOutTax = itdedWorkDisOutTax;
            this._itdedWorkDisInTax = itdedWorkDisInTax;
            this._itdedSalesDisTaxFre = itdedSalesDisTaxFre;
            this._salesDisOutTax = salesDisOutTax;
            this._salesDisTtlTaxInclu = salesDisTtlTaxInclu;
            this._partsDiscountRate = partsDiscountRate;
            this._ravorDiscountRate = ravorDiscountRate;
            this._totalCost = totalCost;
            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._accRecConsTax = accRecConsTax;
            this._autoDepositCd = autoDepositCd;
            this._autoDepositSlipNo = autoDepositSlipNo;
            this._depositAllowanceTtl = depositAllowanceTtl;
            this._depositAlwcBlnce = depositAlwcBlnce;
            this._claimCode = claimCode;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._honorificTitle = honorificTitle;
            this._outputName = outputName;
            this._custSlipNo = custSlipNo;
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
            this._partySaleSlipNum = partySaleSlipNum;
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this.RegiProcDate = regiProcDate;
            this._cashRegisterNo = cashRegisterNo;
            this._posReceiptNo = posReceiptNo;
            this._detailRowCount = detailRowCount;
            this._ediSendDate = ediSendDate;
            this._ediTakeInDate = ediTakeInDate;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._slipPrintDivCd = slipPrintDivCd;
            this._slipPrintFinishCd = slipPrintFinishCd;
            this._salesSlipPrintDate = salesSlipPrintDate;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._orderNumber = orderNumber;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._reconcileFlag = reconcileFlag;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._completeCd = completeCd;
            this._salesPriceFracProcCd = salesPriceFracProcCd;
            this._stockGoodsTtlTaxExc = stockGoodsTtlTaxExc;
            this._pureGoodsTtlTaxExc = pureGoodsTtlTaxExc;
            this._listPricePrintDiv = listPricePrintDiv;
            this._eraNameDispCd1 = eraNameDispCd1;
            this._estimaTaxDivCd = estimaTaxDivCd;
            this._estimateFormPrtCd = estimateFormPrtCd;
            this._estimateSubject = estimateSubject;
            this._footnotes1 = footnotes1;
            this._footnotes2 = footnotes2;
            this._estimateTitle1 = estimateTitle1;
            this._estimateTitle2 = estimateTitle2;
            this._estimateTitle3 = estimateTitle3;
            this._estimateTitle4 = estimateTitle4;
            this._estimateTitle5 = estimateTitle5;
            this._estimateNote1 = estimateNote1;
            this._estimateNote2 = estimateNote2;
            this._estimateNote3 = estimateNote3;
            this._estimateNote4 = estimateNote4;
            this._estimateNote5 = estimateNote5;
            this.EstimateValidityDate = estimateValidityDate;
            this._partsNoPrtCd = partsNoPrtCd;
            this._optionPringDivCd = optionPringDivCd;
            this._rateUseCode = rateUseCode;
            this._carMngCode = carMngCode;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._makerFullName = makerFullName;
            this._fullModel = fullModel;
            this._modelFullName = modelFullName;
            this._enterpriseName = enterpriseName;
            this._resultsAddUpSecNm = resultsAddUpSecNm;

        }

        /// <summary>
        /// ����`�[�������o���ʕ�������
        /// </summary>
        /// <returns>SalesSlipSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesSlipSearchResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlipSearchResult Clone()
        {
            return new SalesSlipSearchResult( this._enterpriseCode, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._sectionGuideNm, this._subSectionCode, this._subSectionName, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._carMngCode, this._modelDesignationNo, this._categoryNo, this._makerFullName, this._fullModel, this._modelFullName, this._enterpriseName, this._resultsAddUpSecNm );
        }

        /// <summary>
        /// ����`�[�������o���ʔ�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesSlipSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( SalesSlipSearchResult target )
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.SubSectionName == target.SubSectionName)
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                 && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.SalesInpSecCd == target.SalesInpSecCd)
                 && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
                 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.SearchSlipDate == target.SearchSlipDate)
                 && (this.ShipmentDay == target.ShipmentDay)
                 && (this.SalesDate == target.SalesDate)
                 && (this.AddUpADate == target.AddUpADate)
                 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
                 && (this.EstimateFormNo == target.EstimateFormNo)
                 && (this.EstimateDivide == target.EstimateDivide)
                 && (this.InputAgenCd == target.InputAgenCd)
                 && (this.InputAgenNm == target.InputAgenNm)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
                 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
                 && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
                 && (this.SalesPrtTotalTaxInc == target.SalesPrtTotalTaxInc)
                 && (this.SalesPrtTotalTaxExc == target.SalesPrtTotalTaxExc)
                 && (this.SalesWorkTotalTaxInc == target.SalesWorkTotalTaxInc)
                 && (this.SalesWorkTotalTaxExc == target.SalesWorkTotalTaxExc)
                 && (this.SalesSubtotalTaxInc == target.SalesSubtotalTaxInc)
                 && (this.SalesSubtotalTaxExc == target.SalesSubtotalTaxExc)
                 && (this.SalesPrtSubttlInc == target.SalesPrtSubttlInc)
                 && (this.SalesPrtSubttlExc == target.SalesPrtSubttlExc)
                 && (this.SalesWorkSubttlInc == target.SalesWorkSubttlInc)
                 && (this.SalesWorkSubttlExc == target.SalesWorkSubttlExc)
                 && (this.SalesNetPrice == target.SalesNetPrice)
                 && (this.SalesSubtotalTax == target.SalesSubtotalTax)
                 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
                 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
                 && (this.SalSubttlSubToTaxFre == target.SalSubttlSubToTaxFre)
                 && (this.SalesOutTax == target.SalesOutTax)
                 && (this.SalAmntConsTaxInclu == target.SalAmntConsTaxInclu)
                 && (this.SalesDisTtlTaxExc == target.SalesDisTtlTaxExc)
                 && (this.ItdedSalesDisOutTax == target.ItdedSalesDisOutTax)
                 && (this.ItdedSalesDisInTax == target.ItdedSalesDisInTax)
                 && (this.ItdedPartsDisOutTax == target.ItdedPartsDisOutTax)
                 && (this.ItdedPartsDisInTax == target.ItdedPartsDisInTax)
                 && (this.ItdedWorkDisOutTax == target.ItdedWorkDisOutTax)
                 && (this.ItdedWorkDisInTax == target.ItdedWorkDisInTax)
                 && (this.ItdedSalesDisTaxFre == target.ItdedSalesDisTaxFre)
                 && (this.SalesDisOutTax == target.SalesDisOutTax)
                 && (this.SalesDisTtlTaxInclu == target.SalesDisTtlTaxInclu)
                 && (this.PartsDiscountRate == target.PartsDiscountRate)
                 && (this.RavorDiscountRate == target.RavorDiscountRate)
                 && (this.TotalCost == target.TotalCost)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.AccRecConsTax == target.AccRecConsTax)
                 && (this.AutoDepositCd == target.AutoDepositCd)
                 && (this.AutoDepositSlipNo == target.AutoDepositSlipNo)
                 && (this.DepositAllowanceTtl == target.DepositAllowanceTtl)
                 && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.OutputName == target.OutputName)
                 && (this.CustSlipNo == target.CustSlipNo)
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
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
                 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
                 && (this.RetGoodsReason == target.RetGoodsReason)
                 && (this.RegiProcDate == target.RegiProcDate)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.PosReceiptNo == target.PosReceiptNo)
                 && (this.DetailRowCount == target.DetailRowCount)
                 && (this.EdiSendDate == target.EdiSendDate)
                 && (this.EdiTakeInDate == target.EdiTakeInDate)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SlipPrintDivCd == target.SlipPrintDivCd)
                 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
                 && (this.SalesSlipPrintDate == target.SalesSlipPrintDate)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.ReconcileFlag == target.ReconcileFlag)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.CompleteCd == target.CompleteCd)
                 && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
                 && (this.StockGoodsTtlTaxExc == target.StockGoodsTtlTaxExc)
                 && (this.PureGoodsTtlTaxExc == target.PureGoodsTtlTaxExc)
                 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EstimaTaxDivCd == target.EstimaTaxDivCd)
                 && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
                 && (this.EstimateSubject == target.EstimateSubject)
                 && (this.Footnotes1 == target.Footnotes1)
                 && (this.Footnotes2 == target.Footnotes2)
                 && (this.EstimateTitle1 == target.EstimateTitle1)
                 && (this.EstimateTitle2 == target.EstimateTitle2)
                 && (this.EstimateTitle3 == target.EstimateTitle3)
                 && (this.EstimateTitle4 == target.EstimateTitle4)
                 && (this.EstimateTitle5 == target.EstimateTitle5)
                 && (this.EstimateNote1 == target.EstimateNote1)
                 && (this.EstimateNote2 == target.EstimateNote2)
                 && (this.EstimateNote3 == target.EstimateNote3)
                 && (this.EstimateNote4 == target.EstimateNote4)
                 && (this.EstimateNote5 == target.EstimateNote5)
                 && (this.EstimateValidityDate == target.EstimateValidityDate)
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.OptionPringDivCd == target.OptionPringDivCd)
                 && (this.RateUseCode == target.RateUseCode)
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.MakerFullName == target.MakerFullName)
                 && (this.FullModel == target.FullModel)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm));
        }

        /// <summary>
        /// ����`�[�������o���ʔ�r����
        /// </summary>
        /// <param name="salesSlipSearchResult1">
        ///                    ��r����SalesSlipSearchResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesSlipSearchResult2">��r����SalesSlipSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2 )
        {
            return ((salesSlipSearchResult1.EnterpriseCode == salesSlipSearchResult2.EnterpriseCode)
                 && (salesSlipSearchResult1.LogicalDeleteCode == salesSlipSearchResult2.LogicalDeleteCode)
                 && (salesSlipSearchResult1.AcptAnOdrStatus == salesSlipSearchResult2.AcptAnOdrStatus)
                 && (salesSlipSearchResult1.SalesSlipNum == salesSlipSearchResult2.SalesSlipNum)
                 && (salesSlipSearchResult1.SectionCode == salesSlipSearchResult2.SectionCode)
                 && (salesSlipSearchResult1.SectionGuideNm == salesSlipSearchResult2.SectionGuideNm)
                 && (salesSlipSearchResult1.SubSectionCode == salesSlipSearchResult2.SubSectionCode)
                 && (salesSlipSearchResult1.SubSectionName == salesSlipSearchResult2.SubSectionName)
                 && (salesSlipSearchResult1.DebitNoteDiv == salesSlipSearchResult2.DebitNoteDiv)
                 && (salesSlipSearchResult1.DebitNLnkSalesSlNum == salesSlipSearchResult2.DebitNLnkSalesSlNum)
                 && (salesSlipSearchResult1.SalesSlipCd == salesSlipSearchResult2.SalesSlipCd)
                 && (salesSlipSearchResult1.SalesGoodsCd == salesSlipSearchResult2.SalesGoodsCd)
                 && (salesSlipSearchResult1.AccRecDivCd == salesSlipSearchResult2.AccRecDivCd)
                 && (salesSlipSearchResult1.SalesInpSecCd == salesSlipSearchResult2.SalesInpSecCd)
                 && (salesSlipSearchResult1.DemandAddUpSecCd == salesSlipSearchResult2.DemandAddUpSecCd)
                 && (salesSlipSearchResult1.ResultsAddUpSecCd == salesSlipSearchResult2.ResultsAddUpSecCd)
                 && (salesSlipSearchResult1.UpdateSecCd == salesSlipSearchResult2.UpdateSecCd)
                 && (salesSlipSearchResult1.SearchSlipDate == salesSlipSearchResult2.SearchSlipDate)
                 && (salesSlipSearchResult1.ShipmentDay == salesSlipSearchResult2.ShipmentDay)
                 && (salesSlipSearchResult1.SalesDate == salesSlipSearchResult2.SalesDate)
                 && (salesSlipSearchResult1.AddUpADate == salesSlipSearchResult2.AddUpADate)
                 && (salesSlipSearchResult1.DelayPaymentDiv == salesSlipSearchResult2.DelayPaymentDiv)
                 && (salesSlipSearchResult1.EstimateFormNo == salesSlipSearchResult2.EstimateFormNo)
                 && (salesSlipSearchResult1.EstimateDivide == salesSlipSearchResult2.EstimateDivide)
                 && (salesSlipSearchResult1.InputAgenCd == salesSlipSearchResult2.InputAgenCd)
                 && (salesSlipSearchResult1.InputAgenNm == salesSlipSearchResult2.InputAgenNm)
                 && (salesSlipSearchResult1.SalesInputCode == salesSlipSearchResult2.SalesInputCode)
                 && (salesSlipSearchResult1.SalesInputName == salesSlipSearchResult2.SalesInputName)
                 && (salesSlipSearchResult1.FrontEmployeeCd == salesSlipSearchResult2.FrontEmployeeCd)
                 && (salesSlipSearchResult1.FrontEmployeeNm == salesSlipSearchResult2.FrontEmployeeNm)
                 && (salesSlipSearchResult1.SalesEmployeeCd == salesSlipSearchResult2.SalesEmployeeCd)
                 && (salesSlipSearchResult1.SalesEmployeeNm == salesSlipSearchResult2.SalesEmployeeNm)
                 && (salesSlipSearchResult1.TotalAmountDispWayCd == salesSlipSearchResult2.TotalAmountDispWayCd)
                 && (salesSlipSearchResult1.TtlAmntDispRateApy == salesSlipSearchResult2.TtlAmntDispRateApy)
                 && (salesSlipSearchResult1.SalesTotalTaxInc == salesSlipSearchResult2.SalesTotalTaxInc)
                 && (salesSlipSearchResult1.SalesTotalTaxExc == salesSlipSearchResult2.SalesTotalTaxExc)
                 && (salesSlipSearchResult1.SalesPrtTotalTaxInc == salesSlipSearchResult2.SalesPrtTotalTaxInc)
                 && (salesSlipSearchResult1.SalesPrtTotalTaxExc == salesSlipSearchResult2.SalesPrtTotalTaxExc)
                 && (salesSlipSearchResult1.SalesWorkTotalTaxInc == salesSlipSearchResult2.SalesWorkTotalTaxInc)
                 && (salesSlipSearchResult1.SalesWorkTotalTaxExc == salesSlipSearchResult2.SalesWorkTotalTaxExc)
                 && (salesSlipSearchResult1.SalesSubtotalTaxInc == salesSlipSearchResult2.SalesSubtotalTaxInc)
                 && (salesSlipSearchResult1.SalesSubtotalTaxExc == salesSlipSearchResult2.SalesSubtotalTaxExc)
                 && (salesSlipSearchResult1.SalesPrtSubttlInc == salesSlipSearchResult2.SalesPrtSubttlInc)
                 && (salesSlipSearchResult1.SalesPrtSubttlExc == salesSlipSearchResult2.SalesPrtSubttlExc)
                 && (salesSlipSearchResult1.SalesWorkSubttlInc == salesSlipSearchResult2.SalesWorkSubttlInc)
                 && (salesSlipSearchResult1.SalesWorkSubttlExc == salesSlipSearchResult2.SalesWorkSubttlExc)
                 && (salesSlipSearchResult1.SalesNetPrice == salesSlipSearchResult2.SalesNetPrice)
                 && (salesSlipSearchResult1.SalesSubtotalTax == salesSlipSearchResult2.SalesSubtotalTax)
                 && (salesSlipSearchResult1.ItdedSalesOutTax == salesSlipSearchResult2.ItdedSalesOutTax)
                 && (salesSlipSearchResult1.ItdedSalesInTax == salesSlipSearchResult2.ItdedSalesInTax)
                 && (salesSlipSearchResult1.SalSubttlSubToTaxFre == salesSlipSearchResult2.SalSubttlSubToTaxFre)
                 && (salesSlipSearchResult1.SalesOutTax == salesSlipSearchResult2.SalesOutTax)
                 && (salesSlipSearchResult1.SalAmntConsTaxInclu == salesSlipSearchResult2.SalAmntConsTaxInclu)
                 && (salesSlipSearchResult1.SalesDisTtlTaxExc == salesSlipSearchResult2.SalesDisTtlTaxExc)
                 && (salesSlipSearchResult1.ItdedSalesDisOutTax == salesSlipSearchResult2.ItdedSalesDisOutTax)
                 && (salesSlipSearchResult1.ItdedSalesDisInTax == salesSlipSearchResult2.ItdedSalesDisInTax)
                 && (salesSlipSearchResult1.ItdedPartsDisOutTax == salesSlipSearchResult2.ItdedPartsDisOutTax)
                 && (salesSlipSearchResult1.ItdedPartsDisInTax == salesSlipSearchResult2.ItdedPartsDisInTax)
                 && (salesSlipSearchResult1.ItdedWorkDisOutTax == salesSlipSearchResult2.ItdedWorkDisOutTax)
                 && (salesSlipSearchResult1.ItdedWorkDisInTax == salesSlipSearchResult2.ItdedWorkDisInTax)
                 && (salesSlipSearchResult1.ItdedSalesDisTaxFre == salesSlipSearchResult2.ItdedSalesDisTaxFre)
                 && (salesSlipSearchResult1.SalesDisOutTax == salesSlipSearchResult2.SalesDisOutTax)
                 && (salesSlipSearchResult1.SalesDisTtlTaxInclu == salesSlipSearchResult2.SalesDisTtlTaxInclu)
                 && (salesSlipSearchResult1.PartsDiscountRate == salesSlipSearchResult2.PartsDiscountRate)
                 && (salesSlipSearchResult1.RavorDiscountRate == salesSlipSearchResult2.RavorDiscountRate)
                 && (salesSlipSearchResult1.TotalCost == salesSlipSearchResult2.TotalCost)
                 && (salesSlipSearchResult1.ConsTaxLayMethod == salesSlipSearchResult2.ConsTaxLayMethod)
                 && (salesSlipSearchResult1.ConsTaxRate == salesSlipSearchResult2.ConsTaxRate)
                 && (salesSlipSearchResult1.FractionProcCd == salesSlipSearchResult2.FractionProcCd)
                 && (salesSlipSearchResult1.AccRecConsTax == salesSlipSearchResult2.AccRecConsTax)
                 && (salesSlipSearchResult1.AutoDepositCd == salesSlipSearchResult2.AutoDepositCd)
                 && (salesSlipSearchResult1.AutoDepositSlipNo == salesSlipSearchResult2.AutoDepositSlipNo)
                 && (salesSlipSearchResult1.DepositAllowanceTtl == salesSlipSearchResult2.DepositAllowanceTtl)
                 && (salesSlipSearchResult1.DepositAlwcBlnce == salesSlipSearchResult2.DepositAlwcBlnce)
                 && (salesSlipSearchResult1.ClaimCode == salesSlipSearchResult2.ClaimCode)
                 && (salesSlipSearchResult1.ClaimSnm == salesSlipSearchResult2.ClaimSnm)
                 && (salesSlipSearchResult1.CustomerCode == salesSlipSearchResult2.CustomerCode)
                 && (salesSlipSearchResult1.CustomerName == salesSlipSearchResult2.CustomerName)
                 && (salesSlipSearchResult1.CustomerName2 == salesSlipSearchResult2.CustomerName2)
                 && (salesSlipSearchResult1.CustomerSnm == salesSlipSearchResult2.CustomerSnm)
                 && (salesSlipSearchResult1.HonorificTitle == salesSlipSearchResult2.HonorificTitle)
                 && (salesSlipSearchResult1.OutputName == salesSlipSearchResult2.OutputName)
                 && (salesSlipSearchResult1.CustSlipNo == salesSlipSearchResult2.CustSlipNo)
                 && (salesSlipSearchResult1.SlipAddressDiv == salesSlipSearchResult2.SlipAddressDiv)
                 && (salesSlipSearchResult1.AddresseeCode == salesSlipSearchResult2.AddresseeCode)
                 && (salesSlipSearchResult1.AddresseeName == salesSlipSearchResult2.AddresseeName)
                 && (salesSlipSearchResult1.AddresseeName2 == salesSlipSearchResult2.AddresseeName2)
                 && (salesSlipSearchResult1.AddresseePostNo == salesSlipSearchResult2.AddresseePostNo)
                 && (salesSlipSearchResult1.AddresseeAddr1 == salesSlipSearchResult2.AddresseeAddr1)
                 && (salesSlipSearchResult1.AddresseeAddr3 == salesSlipSearchResult2.AddresseeAddr3)
                 && (salesSlipSearchResult1.AddresseeAddr4 == salesSlipSearchResult2.AddresseeAddr4)
                 && (salesSlipSearchResult1.AddresseeTelNo == salesSlipSearchResult2.AddresseeTelNo)
                 && (salesSlipSearchResult1.AddresseeFaxNo == salesSlipSearchResult2.AddresseeFaxNo)
                 && (salesSlipSearchResult1.PartySaleSlipNum == salesSlipSearchResult2.PartySaleSlipNum)
                 && (salesSlipSearchResult1.SlipNote == salesSlipSearchResult2.SlipNote)
                 && (salesSlipSearchResult1.SlipNote2 == salesSlipSearchResult2.SlipNote2)
                 && (salesSlipSearchResult1.SlipNote3 == salesSlipSearchResult2.SlipNote3)
                 && (salesSlipSearchResult1.RetGoodsReasonDiv == salesSlipSearchResult2.RetGoodsReasonDiv)
                 && (salesSlipSearchResult1.RetGoodsReason == salesSlipSearchResult2.RetGoodsReason)
                 && (salesSlipSearchResult1.RegiProcDate == salesSlipSearchResult2.RegiProcDate)
                 && (salesSlipSearchResult1.CashRegisterNo == salesSlipSearchResult2.CashRegisterNo)
                 && (salesSlipSearchResult1.PosReceiptNo == salesSlipSearchResult2.PosReceiptNo)
                 && (salesSlipSearchResult1.DetailRowCount == salesSlipSearchResult2.DetailRowCount)
                 && (salesSlipSearchResult1.EdiSendDate == salesSlipSearchResult2.EdiSendDate)
                 && (salesSlipSearchResult1.EdiTakeInDate == salesSlipSearchResult2.EdiTakeInDate)
                 && (salesSlipSearchResult1.UoeRemark1 == salesSlipSearchResult2.UoeRemark1)
                 && (salesSlipSearchResult1.UoeRemark2 == salesSlipSearchResult2.UoeRemark2)
                 && (salesSlipSearchResult1.SlipPrintDivCd == salesSlipSearchResult2.SlipPrintDivCd)
                 && (salesSlipSearchResult1.SlipPrintFinishCd == salesSlipSearchResult2.SlipPrintFinishCd)
                 && (salesSlipSearchResult1.SalesSlipPrintDate == salesSlipSearchResult2.SalesSlipPrintDate)
                 && (salesSlipSearchResult1.BusinessTypeCode == salesSlipSearchResult2.BusinessTypeCode)
                 && (salesSlipSearchResult1.BusinessTypeName == salesSlipSearchResult2.BusinessTypeName)
                 && (salesSlipSearchResult1.OrderNumber == salesSlipSearchResult2.OrderNumber)
                 && (salesSlipSearchResult1.DeliveredGoodsDiv == salesSlipSearchResult2.DeliveredGoodsDiv)
                 && (salesSlipSearchResult1.DeliveredGoodsDivNm == salesSlipSearchResult2.DeliveredGoodsDivNm)
                 && (salesSlipSearchResult1.SalesAreaCode == salesSlipSearchResult2.SalesAreaCode)
                 && (salesSlipSearchResult1.SalesAreaName == salesSlipSearchResult2.SalesAreaName)
                 && (salesSlipSearchResult1.ReconcileFlag == salesSlipSearchResult2.ReconcileFlag)
                 && (salesSlipSearchResult1.SlipPrtSetPaperId == salesSlipSearchResult2.SlipPrtSetPaperId)
                 && (salesSlipSearchResult1.CompleteCd == salesSlipSearchResult2.CompleteCd)
                 && (salesSlipSearchResult1.SalesPriceFracProcCd == salesSlipSearchResult2.SalesPriceFracProcCd)
                 && (salesSlipSearchResult1.StockGoodsTtlTaxExc == salesSlipSearchResult2.StockGoodsTtlTaxExc)
                 && (salesSlipSearchResult1.PureGoodsTtlTaxExc == salesSlipSearchResult2.PureGoodsTtlTaxExc)
                 && (salesSlipSearchResult1.ListPricePrintDiv == salesSlipSearchResult2.ListPricePrintDiv)
                 && (salesSlipSearchResult1.EraNameDispCd1 == salesSlipSearchResult2.EraNameDispCd1)
                 && (salesSlipSearchResult1.EstimaTaxDivCd == salesSlipSearchResult2.EstimaTaxDivCd)
                 && (salesSlipSearchResult1.EstimateFormPrtCd == salesSlipSearchResult2.EstimateFormPrtCd)
                 && (salesSlipSearchResult1.EstimateSubject == salesSlipSearchResult2.EstimateSubject)
                 && (salesSlipSearchResult1.Footnotes1 == salesSlipSearchResult2.Footnotes1)
                 && (salesSlipSearchResult1.Footnotes2 == salesSlipSearchResult2.Footnotes2)
                 && (salesSlipSearchResult1.EstimateTitle1 == salesSlipSearchResult2.EstimateTitle1)
                 && (salesSlipSearchResult1.EstimateTitle2 == salesSlipSearchResult2.EstimateTitle2)
                 && (salesSlipSearchResult1.EstimateTitle3 == salesSlipSearchResult2.EstimateTitle3)
                 && (salesSlipSearchResult1.EstimateTitle4 == salesSlipSearchResult2.EstimateTitle4)
                 && (salesSlipSearchResult1.EstimateTitle5 == salesSlipSearchResult2.EstimateTitle5)
                 && (salesSlipSearchResult1.EstimateNote1 == salesSlipSearchResult2.EstimateNote1)
                 && (salesSlipSearchResult1.EstimateNote2 == salesSlipSearchResult2.EstimateNote2)
                 && (salesSlipSearchResult1.EstimateNote3 == salesSlipSearchResult2.EstimateNote3)
                 && (salesSlipSearchResult1.EstimateNote4 == salesSlipSearchResult2.EstimateNote4)
                 && (salesSlipSearchResult1.EstimateNote5 == salesSlipSearchResult2.EstimateNote5)
                 && (salesSlipSearchResult1.EstimateValidityDate == salesSlipSearchResult2.EstimateValidityDate)
                 && (salesSlipSearchResult1.PartsNoPrtCd == salesSlipSearchResult2.PartsNoPrtCd)
                 && (salesSlipSearchResult1.OptionPringDivCd == salesSlipSearchResult2.OptionPringDivCd)
                 && (salesSlipSearchResult1.RateUseCode == salesSlipSearchResult2.RateUseCode)
                 && (salesSlipSearchResult1.CarMngCode == salesSlipSearchResult2.CarMngCode)
                 && (salesSlipSearchResult1.ModelDesignationNo == salesSlipSearchResult2.ModelDesignationNo)
                 && (salesSlipSearchResult1.CategoryNo == salesSlipSearchResult2.CategoryNo)
                 && (salesSlipSearchResult1.MakerFullName == salesSlipSearchResult2.MakerFullName)
                 && (salesSlipSearchResult1.FullModel == salesSlipSearchResult2.FullModel)
                 && (salesSlipSearchResult1.ModelFullName == salesSlipSearchResult2.ModelFullName)
                 && (salesSlipSearchResult1.EnterpriseName == salesSlipSearchResult2.EnterpriseName)
                 && (salesSlipSearchResult1.ResultsAddUpSecNm == salesSlipSearchResult2.ResultsAddUpSecNm));
        }
        /// <summary>
        /// ����`�[�������o���ʔ�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesSlipSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( SalesSlipSearchResult target )
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.LogicalDeleteCode != target.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( this.AcptAnOdrStatus != target.AcptAnOdrStatus ) resList.Add( "AcptAnOdrStatus" );
            if ( this.SalesSlipNum != target.SalesSlipNum ) resList.Add( "SalesSlipNum" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.SectionGuideNm != target.SectionGuideNm ) resList.Add( "SectionGuideNm" );
            if ( this.SubSectionCode != target.SubSectionCode ) resList.Add( "SubSectionCode" );
            if ( this.SubSectionName != target.SubSectionName ) resList.Add( "SubSectionName" );
            if ( this.DebitNoteDiv != target.DebitNoteDiv ) resList.Add( "DebitNoteDiv" );
            if ( this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum ) resList.Add( "DebitNLnkSalesSlNum" );
            if ( this.SalesSlipCd != target.SalesSlipCd ) resList.Add( "SalesSlipCd" );
            if ( this.SalesGoodsCd != target.SalesGoodsCd ) resList.Add( "SalesGoodsCd" );
            if ( this.AccRecDivCd != target.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( this.SalesInpSecCd != target.SalesInpSecCd ) resList.Add( "SalesInpSecCd" );
            if ( this.DemandAddUpSecCd != target.DemandAddUpSecCd ) resList.Add( "DemandAddUpSecCd" );
            if ( this.ResultsAddUpSecCd != target.ResultsAddUpSecCd ) resList.Add( "ResultsAddUpSecCd" );
            if ( this.UpdateSecCd != target.UpdateSecCd ) resList.Add( "UpdateSecCd" );
            if ( this.SearchSlipDate != target.SearchSlipDate ) resList.Add( "SearchSlipDate" );
            if ( this.ShipmentDay != target.ShipmentDay ) resList.Add( "ShipmentDay" );
            if ( this.SalesDate != target.SalesDate ) resList.Add( "SalesDate" );
            if ( this.AddUpADate != target.AddUpADate ) resList.Add( "AddUpADate" );
            if ( this.DelayPaymentDiv != target.DelayPaymentDiv ) resList.Add( "DelayPaymentDiv" );
            if ( this.EstimateFormNo != target.EstimateFormNo ) resList.Add( "EstimateFormNo" );
            if ( this.EstimateDivide != target.EstimateDivide ) resList.Add( "EstimateDivide" );
            if ( this.InputAgenCd != target.InputAgenCd ) resList.Add( "InputAgenCd" );
            if ( this.InputAgenNm != target.InputAgenNm ) resList.Add( "InputAgenNm" );
            if ( this.SalesInputCode != target.SalesInputCode ) resList.Add( "SalesInputCode" );
            if ( this.SalesInputName != target.SalesInputName ) resList.Add( "SalesInputName" );
            if ( this.FrontEmployeeCd != target.FrontEmployeeCd ) resList.Add( "FrontEmployeeCd" );
            if ( this.FrontEmployeeNm != target.FrontEmployeeNm ) resList.Add( "FrontEmployeeNm" );
            if ( this.SalesEmployeeCd != target.SalesEmployeeCd ) resList.Add( "SalesEmployeeCd" );
            if ( this.SalesEmployeeNm != target.SalesEmployeeNm ) resList.Add( "SalesEmployeeNm" );
            if ( this.TotalAmountDispWayCd != target.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( this.TtlAmntDispRateApy != target.TtlAmntDispRateApy ) resList.Add( "TtlAmntDispRateApy" );
            if ( this.SalesTotalTaxInc != target.SalesTotalTaxInc ) resList.Add( "SalesTotalTaxInc" );
            if ( this.SalesTotalTaxExc != target.SalesTotalTaxExc ) resList.Add( "SalesTotalTaxExc" );
            if ( this.SalesPrtTotalTaxInc != target.SalesPrtTotalTaxInc ) resList.Add( "SalesPrtTotalTaxInc" );
            if ( this.SalesPrtTotalTaxExc != target.SalesPrtTotalTaxExc ) resList.Add( "SalesPrtTotalTaxExc" );
            if ( this.SalesWorkTotalTaxInc != target.SalesWorkTotalTaxInc ) resList.Add( "SalesWorkTotalTaxInc" );
            if ( this.SalesWorkTotalTaxExc != target.SalesWorkTotalTaxExc ) resList.Add( "SalesWorkTotalTaxExc" );
            if ( this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc ) resList.Add( "SalesSubtotalTaxInc" );
            if ( this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc ) resList.Add( "SalesSubtotalTaxExc" );
            if ( this.SalesPrtSubttlInc != target.SalesPrtSubttlInc ) resList.Add( "SalesPrtSubttlInc" );
            if ( this.SalesPrtSubttlExc != target.SalesPrtSubttlExc ) resList.Add( "SalesPrtSubttlExc" );
            if ( this.SalesWorkSubttlInc != target.SalesWorkSubttlInc ) resList.Add( "SalesWorkSubttlInc" );
            if ( this.SalesWorkSubttlExc != target.SalesWorkSubttlExc ) resList.Add( "SalesWorkSubttlExc" );
            if ( this.SalesNetPrice != target.SalesNetPrice ) resList.Add( "SalesNetPrice" );
            if ( this.SalesSubtotalTax != target.SalesSubtotalTax ) resList.Add( "SalesSubtotalTax" );
            if ( this.ItdedSalesOutTax != target.ItdedSalesOutTax ) resList.Add( "ItdedSalesOutTax" );
            if ( this.ItdedSalesInTax != target.ItdedSalesInTax ) resList.Add( "ItdedSalesInTax" );
            if ( this.SalSubttlSubToTaxFre != target.SalSubttlSubToTaxFre ) resList.Add( "SalSubttlSubToTaxFre" );
            if ( this.SalesOutTax != target.SalesOutTax ) resList.Add( "SalesOutTax" );
            if ( this.SalAmntConsTaxInclu != target.SalAmntConsTaxInclu ) resList.Add( "SalAmntConsTaxInclu" );
            if ( this.SalesDisTtlTaxExc != target.SalesDisTtlTaxExc ) resList.Add( "SalesDisTtlTaxExc" );
            if ( this.ItdedSalesDisOutTax != target.ItdedSalesDisOutTax ) resList.Add( "ItdedSalesDisOutTax" );
            if ( this.ItdedSalesDisInTax != target.ItdedSalesDisInTax ) resList.Add( "ItdedSalesDisInTax" );
            if ( this.ItdedPartsDisOutTax != target.ItdedPartsDisOutTax ) resList.Add( "ItdedPartsDisOutTax" );
            if ( this.ItdedPartsDisInTax != target.ItdedPartsDisInTax ) resList.Add( "ItdedPartsDisInTax" );
            if ( this.ItdedWorkDisOutTax != target.ItdedWorkDisOutTax ) resList.Add( "ItdedWorkDisOutTax" );
            if ( this.ItdedWorkDisInTax != target.ItdedWorkDisInTax ) resList.Add( "ItdedWorkDisInTax" );
            if ( this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre ) resList.Add( "ItdedSalesDisTaxFre" );
            if ( this.SalesDisOutTax != target.SalesDisOutTax ) resList.Add( "SalesDisOutTax" );
            if ( this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu ) resList.Add( "SalesDisTtlTaxInclu" );
            if ( this.PartsDiscountRate != target.PartsDiscountRate ) resList.Add( "PartsDiscountRate" );
            if ( this.RavorDiscountRate != target.RavorDiscountRate ) resList.Add( "RavorDiscountRate" );
            if ( this.TotalCost != target.TotalCost ) resList.Add( "TotalCost" );
            if ( this.ConsTaxLayMethod != target.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( this.ConsTaxRate != target.ConsTaxRate ) resList.Add( "ConsTaxRate" );
            if ( this.FractionProcCd != target.FractionProcCd ) resList.Add( "FractionProcCd" );
            if ( this.AccRecConsTax != target.AccRecConsTax ) resList.Add( "AccRecConsTax" );
            if ( this.AutoDepositCd != target.AutoDepositCd ) resList.Add( "AutoDepositCd" );
            if ( this.AutoDepositSlipNo != target.AutoDepositSlipNo ) resList.Add( "AutoDepositSlipNo" );
            if ( this.DepositAllowanceTtl != target.DepositAllowanceTtl ) resList.Add( "DepositAllowanceTtl" );
            if ( this.DepositAlwcBlnce != target.DepositAlwcBlnce ) resList.Add( "DepositAlwcBlnce" );
            if ( this.ClaimCode != target.ClaimCode ) resList.Add( "ClaimCode" );
            if ( this.ClaimSnm != target.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( this.CustomerCode != target.CustomerCode ) resList.Add( "CustomerCode" );
            if ( this.CustomerName != target.CustomerName ) resList.Add( "CustomerName" );
            if ( this.CustomerName2 != target.CustomerName2 ) resList.Add( "CustomerName2" );
            if ( this.CustomerSnm != target.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( this.HonorificTitle != target.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( this.OutputName != target.OutputName ) resList.Add( "OutputName" );
            if ( this.CustSlipNo != target.CustSlipNo ) resList.Add( "CustSlipNo" );
            if ( this.SlipAddressDiv != target.SlipAddressDiv ) resList.Add( "SlipAddressDiv" );
            if ( this.AddresseeCode != target.AddresseeCode ) resList.Add( "AddresseeCode" );
            if ( this.AddresseeName != target.AddresseeName ) resList.Add( "AddresseeName" );
            if ( this.AddresseeName2 != target.AddresseeName2 ) resList.Add( "AddresseeName2" );
            if ( this.AddresseePostNo != target.AddresseePostNo ) resList.Add( "AddresseePostNo" );
            if ( this.AddresseeAddr1 != target.AddresseeAddr1 ) resList.Add( "AddresseeAddr1" );
            if ( this.AddresseeAddr3 != target.AddresseeAddr3 ) resList.Add( "AddresseeAddr3" );
            if ( this.AddresseeAddr4 != target.AddresseeAddr4 ) resList.Add( "AddresseeAddr4" );
            if ( this.AddresseeTelNo != target.AddresseeTelNo ) resList.Add( "AddresseeTelNo" );
            if ( this.AddresseeFaxNo != target.AddresseeFaxNo ) resList.Add( "AddresseeFaxNo" );
            if ( this.PartySaleSlipNum != target.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( this.SlipNote != target.SlipNote ) resList.Add( "SlipNote" );
            if ( this.SlipNote2 != target.SlipNote2 ) resList.Add( "SlipNote2" );
            if ( this.SlipNote3 != target.SlipNote3 ) resList.Add( "SlipNote3" );
            if ( this.RetGoodsReasonDiv != target.RetGoodsReasonDiv ) resList.Add( "RetGoodsReasonDiv" );
            if ( this.RetGoodsReason != target.RetGoodsReason ) resList.Add( "RetGoodsReason" );
            if ( this.RegiProcDate != target.RegiProcDate ) resList.Add( "RegiProcDate" );
            if ( this.CashRegisterNo != target.CashRegisterNo ) resList.Add( "CashRegisterNo" );
            if ( this.PosReceiptNo != target.PosReceiptNo ) resList.Add( "PosReceiptNo" );
            if ( this.DetailRowCount != target.DetailRowCount ) resList.Add( "DetailRowCount" );
            if ( this.EdiSendDate != target.EdiSendDate ) resList.Add( "EdiSendDate" );
            if ( this.EdiTakeInDate != target.EdiTakeInDate ) resList.Add( "EdiTakeInDate" );
            if ( this.UoeRemark1 != target.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( this.UoeRemark2 != target.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( this.SlipPrintDivCd != target.SlipPrintDivCd ) resList.Add( "SlipPrintDivCd" );
            if ( this.SlipPrintFinishCd != target.SlipPrintFinishCd ) resList.Add( "SlipPrintFinishCd" );
            if ( this.SalesSlipPrintDate != target.SalesSlipPrintDate ) resList.Add( "SalesSlipPrintDate" );
            if ( this.BusinessTypeCode != target.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( this.BusinessTypeName != target.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( this.OrderNumber != target.OrderNumber ) resList.Add( "OrderNumber" );
            if ( this.DeliveredGoodsDiv != target.DeliveredGoodsDiv ) resList.Add( "DeliveredGoodsDiv" );
            if ( this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm ) resList.Add( "DeliveredGoodsDivNm" );
            if ( this.SalesAreaCode != target.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( this.SalesAreaName != target.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( this.ReconcileFlag != target.ReconcileFlag ) resList.Add( "ReconcileFlag" );
            if ( this.SlipPrtSetPaperId != target.SlipPrtSetPaperId ) resList.Add( "SlipPrtSetPaperId" );
            if ( this.CompleteCd != target.CompleteCd ) resList.Add( "CompleteCd" );
            if ( this.SalesPriceFracProcCd != target.SalesPriceFracProcCd ) resList.Add( "SalesPriceFracProcCd" );
            if ( this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc ) resList.Add( "StockGoodsTtlTaxExc" );
            if ( this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc ) resList.Add( "PureGoodsTtlTaxExc" );
            if ( this.ListPricePrintDiv != target.ListPricePrintDiv ) resList.Add( "ListPricePrintDiv" );
            if ( this.EraNameDispCd1 != target.EraNameDispCd1 ) resList.Add( "EraNameDispCd1" );
            if ( this.EstimaTaxDivCd != target.EstimaTaxDivCd ) resList.Add( "EstimaTaxDivCd" );
            if ( this.EstimateFormPrtCd != target.EstimateFormPrtCd ) resList.Add( "EstimateFormPrtCd" );
            if ( this.EstimateSubject != target.EstimateSubject ) resList.Add( "EstimateSubject" );
            if ( this.Footnotes1 != target.Footnotes1 ) resList.Add( "Footnotes1" );
            if ( this.Footnotes2 != target.Footnotes2 ) resList.Add( "Footnotes2" );
            if ( this.EstimateTitle1 != target.EstimateTitle1 ) resList.Add( "EstimateTitle1" );
            if ( this.EstimateTitle2 != target.EstimateTitle2 ) resList.Add( "EstimateTitle2" );
            if ( this.EstimateTitle3 != target.EstimateTitle3 ) resList.Add( "EstimateTitle3" );
            if ( this.EstimateTitle4 != target.EstimateTitle4 ) resList.Add( "EstimateTitle4" );
            if ( this.EstimateTitle5 != target.EstimateTitle5 ) resList.Add( "EstimateTitle5" );
            if ( this.EstimateNote1 != target.EstimateNote1 ) resList.Add( "EstimateNote1" );
            if ( this.EstimateNote2 != target.EstimateNote2 ) resList.Add( "EstimateNote2" );
            if ( this.EstimateNote3 != target.EstimateNote3 ) resList.Add( "EstimateNote3" );
            if ( this.EstimateNote4 != target.EstimateNote4 ) resList.Add( "EstimateNote4" );
            if ( this.EstimateNote5 != target.EstimateNote5 ) resList.Add( "EstimateNote5" );
            if ( this.EstimateValidityDate != target.EstimateValidityDate ) resList.Add( "EstimateValidityDate" );
            if ( this.PartsNoPrtCd != target.PartsNoPrtCd ) resList.Add( "PartsNoPrtCd" );
            if ( this.OptionPringDivCd != target.OptionPringDivCd ) resList.Add( "OptionPringDivCd" );
            if ( this.RateUseCode != target.RateUseCode ) resList.Add( "RateUseCode" );
            if ( this.CarMngCode != target.CarMngCode ) resList.Add( "CarMngCode" );
            if ( this.ModelDesignationNo != target.ModelDesignationNo ) resList.Add( "ModelDesignationNo" );
            if ( this.CategoryNo != target.CategoryNo ) resList.Add( "CategoryNo" );
            if ( this.MakerFullName != target.MakerFullName ) resList.Add( "MakerFullName" );
            if ( this.FullModel != target.FullModel ) resList.Add( "FullModel" );
            if ( this.ModelFullName != target.ModelFullName ) resList.Add( "ModelFullName" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( this.ResultsAddUpSecNm != target.ResultsAddUpSecNm ) resList.Add( "ResultsAddUpSecNm" );

            return resList;
        }

        /// <summary>
        /// ����`�[�������o���ʔ�r����
        /// </summary>
        /// <param name="salesSlipSearchResult1">��r����SalesSlipSearchResult�N���X�̃C���X�^���X</param>
        /// <param name="salesSlipSearchResult2">��r����SalesSlipSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearchResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2 )
        {
            ArrayList resList = new ArrayList();
            if ( salesSlipSearchResult1.EnterpriseCode != salesSlipSearchResult2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( salesSlipSearchResult1.LogicalDeleteCode != salesSlipSearchResult2.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( salesSlipSearchResult1.AcptAnOdrStatus != salesSlipSearchResult2.AcptAnOdrStatus ) resList.Add( "AcptAnOdrStatus" );
            if ( salesSlipSearchResult1.SalesSlipNum != salesSlipSearchResult2.SalesSlipNum ) resList.Add( "SalesSlipNum" );
            if ( salesSlipSearchResult1.SectionCode != salesSlipSearchResult2.SectionCode ) resList.Add( "SectionCode" );
            if ( salesSlipSearchResult1.SectionGuideNm != salesSlipSearchResult2.SectionGuideNm ) resList.Add( "SectionGuideNm" );
            if ( salesSlipSearchResult1.SubSectionCode != salesSlipSearchResult2.SubSectionCode ) resList.Add( "SubSectionCode" );
            if ( salesSlipSearchResult1.SubSectionName != salesSlipSearchResult2.SubSectionName ) resList.Add( "SubSectionName" );
            if ( salesSlipSearchResult1.DebitNoteDiv != salesSlipSearchResult2.DebitNoteDiv ) resList.Add( "DebitNoteDiv" );
            if ( salesSlipSearchResult1.DebitNLnkSalesSlNum != salesSlipSearchResult2.DebitNLnkSalesSlNum ) resList.Add( "DebitNLnkSalesSlNum" );
            if ( salesSlipSearchResult1.SalesSlipCd != salesSlipSearchResult2.SalesSlipCd ) resList.Add( "SalesSlipCd" );
            if ( salesSlipSearchResult1.SalesGoodsCd != salesSlipSearchResult2.SalesGoodsCd ) resList.Add( "SalesGoodsCd" );
            if ( salesSlipSearchResult1.AccRecDivCd != salesSlipSearchResult2.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( salesSlipSearchResult1.SalesInpSecCd != salesSlipSearchResult2.SalesInpSecCd ) resList.Add( "SalesInpSecCd" );
            if ( salesSlipSearchResult1.DemandAddUpSecCd != salesSlipSearchResult2.DemandAddUpSecCd ) resList.Add( "DemandAddUpSecCd" );
            if ( salesSlipSearchResult1.ResultsAddUpSecCd != salesSlipSearchResult2.ResultsAddUpSecCd ) resList.Add( "ResultsAddUpSecCd" );
            if ( salesSlipSearchResult1.UpdateSecCd != salesSlipSearchResult2.UpdateSecCd ) resList.Add( "UpdateSecCd" );
            if ( salesSlipSearchResult1.SearchSlipDate != salesSlipSearchResult2.SearchSlipDate ) resList.Add( "SearchSlipDate" );
            if ( salesSlipSearchResult1.ShipmentDay != salesSlipSearchResult2.ShipmentDay ) resList.Add( "ShipmentDay" );
            if ( salesSlipSearchResult1.SalesDate != salesSlipSearchResult2.SalesDate ) resList.Add( "SalesDate" );
            if ( salesSlipSearchResult1.AddUpADate != salesSlipSearchResult2.AddUpADate ) resList.Add( "AddUpADate" );
            if ( salesSlipSearchResult1.DelayPaymentDiv != salesSlipSearchResult2.DelayPaymentDiv ) resList.Add( "DelayPaymentDiv" );
            if ( salesSlipSearchResult1.EstimateFormNo != salesSlipSearchResult2.EstimateFormNo ) resList.Add( "EstimateFormNo" );
            if ( salesSlipSearchResult1.EstimateDivide != salesSlipSearchResult2.EstimateDivide ) resList.Add( "EstimateDivide" );
            if ( salesSlipSearchResult1.InputAgenCd != salesSlipSearchResult2.InputAgenCd ) resList.Add( "InputAgenCd" );
            if ( salesSlipSearchResult1.InputAgenNm != salesSlipSearchResult2.InputAgenNm ) resList.Add( "InputAgenNm" );
            if ( salesSlipSearchResult1.SalesInputCode != salesSlipSearchResult2.SalesInputCode ) resList.Add( "SalesInputCode" );
            if ( salesSlipSearchResult1.SalesInputName != salesSlipSearchResult2.SalesInputName ) resList.Add( "SalesInputName" );
            if ( salesSlipSearchResult1.FrontEmployeeCd != salesSlipSearchResult2.FrontEmployeeCd ) resList.Add( "FrontEmployeeCd" );
            if ( salesSlipSearchResult1.FrontEmployeeNm != salesSlipSearchResult2.FrontEmployeeNm ) resList.Add( "FrontEmployeeNm" );
            if ( salesSlipSearchResult1.SalesEmployeeCd != salesSlipSearchResult2.SalesEmployeeCd ) resList.Add( "SalesEmployeeCd" );
            if ( salesSlipSearchResult1.SalesEmployeeNm != salesSlipSearchResult2.SalesEmployeeNm ) resList.Add( "SalesEmployeeNm" );
            if ( salesSlipSearchResult1.TotalAmountDispWayCd != salesSlipSearchResult2.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( salesSlipSearchResult1.TtlAmntDispRateApy != salesSlipSearchResult2.TtlAmntDispRateApy ) resList.Add( "TtlAmntDispRateApy" );
            if ( salesSlipSearchResult1.SalesTotalTaxInc != salesSlipSearchResult2.SalesTotalTaxInc ) resList.Add( "SalesTotalTaxInc" );
            if ( salesSlipSearchResult1.SalesTotalTaxExc != salesSlipSearchResult2.SalesTotalTaxExc ) resList.Add( "SalesTotalTaxExc" );
            if ( salesSlipSearchResult1.SalesPrtTotalTaxInc != salesSlipSearchResult2.SalesPrtTotalTaxInc ) resList.Add( "SalesPrtTotalTaxInc" );
            if ( salesSlipSearchResult1.SalesPrtTotalTaxExc != salesSlipSearchResult2.SalesPrtTotalTaxExc ) resList.Add( "SalesPrtTotalTaxExc" );
            if ( salesSlipSearchResult1.SalesWorkTotalTaxInc != salesSlipSearchResult2.SalesWorkTotalTaxInc ) resList.Add( "SalesWorkTotalTaxInc" );
            if ( salesSlipSearchResult1.SalesWorkTotalTaxExc != salesSlipSearchResult2.SalesWorkTotalTaxExc ) resList.Add( "SalesWorkTotalTaxExc" );
            if ( salesSlipSearchResult1.SalesSubtotalTaxInc != salesSlipSearchResult2.SalesSubtotalTaxInc ) resList.Add( "SalesSubtotalTaxInc" );
            if ( salesSlipSearchResult1.SalesSubtotalTaxExc != salesSlipSearchResult2.SalesSubtotalTaxExc ) resList.Add( "SalesSubtotalTaxExc" );
            if ( salesSlipSearchResult1.SalesPrtSubttlInc != salesSlipSearchResult2.SalesPrtSubttlInc ) resList.Add( "SalesPrtSubttlInc" );
            if ( salesSlipSearchResult1.SalesPrtSubttlExc != salesSlipSearchResult2.SalesPrtSubttlExc ) resList.Add( "SalesPrtSubttlExc" );
            if ( salesSlipSearchResult1.SalesWorkSubttlInc != salesSlipSearchResult2.SalesWorkSubttlInc ) resList.Add( "SalesWorkSubttlInc" );
            if ( salesSlipSearchResult1.SalesWorkSubttlExc != salesSlipSearchResult2.SalesWorkSubttlExc ) resList.Add( "SalesWorkSubttlExc" );
            if ( salesSlipSearchResult1.SalesNetPrice != salesSlipSearchResult2.SalesNetPrice ) resList.Add( "SalesNetPrice" );
            if ( salesSlipSearchResult1.SalesSubtotalTax != salesSlipSearchResult2.SalesSubtotalTax ) resList.Add( "SalesSubtotalTax" );
            if ( salesSlipSearchResult1.ItdedSalesOutTax != salesSlipSearchResult2.ItdedSalesOutTax ) resList.Add( "ItdedSalesOutTax" );
            if ( salesSlipSearchResult1.ItdedSalesInTax != salesSlipSearchResult2.ItdedSalesInTax ) resList.Add( "ItdedSalesInTax" );
            if ( salesSlipSearchResult1.SalSubttlSubToTaxFre != salesSlipSearchResult2.SalSubttlSubToTaxFre ) resList.Add( "SalSubttlSubToTaxFre" );
            if ( salesSlipSearchResult1.SalesOutTax != salesSlipSearchResult2.SalesOutTax ) resList.Add( "SalesOutTax" );
            if ( salesSlipSearchResult1.SalAmntConsTaxInclu != salesSlipSearchResult2.SalAmntConsTaxInclu ) resList.Add( "SalAmntConsTaxInclu" );
            if ( salesSlipSearchResult1.SalesDisTtlTaxExc != salesSlipSearchResult2.SalesDisTtlTaxExc ) resList.Add( "SalesDisTtlTaxExc" );
            if ( salesSlipSearchResult1.ItdedSalesDisOutTax != salesSlipSearchResult2.ItdedSalesDisOutTax ) resList.Add( "ItdedSalesDisOutTax" );
            if ( salesSlipSearchResult1.ItdedSalesDisInTax != salesSlipSearchResult2.ItdedSalesDisInTax ) resList.Add( "ItdedSalesDisInTax" );
            if ( salesSlipSearchResult1.ItdedPartsDisOutTax != salesSlipSearchResult2.ItdedPartsDisOutTax ) resList.Add( "ItdedPartsDisOutTax" );
            if ( salesSlipSearchResult1.ItdedPartsDisInTax != salesSlipSearchResult2.ItdedPartsDisInTax ) resList.Add( "ItdedPartsDisInTax" );
            if ( salesSlipSearchResult1.ItdedWorkDisOutTax != salesSlipSearchResult2.ItdedWorkDisOutTax ) resList.Add( "ItdedWorkDisOutTax" );
            if ( salesSlipSearchResult1.ItdedWorkDisInTax != salesSlipSearchResult2.ItdedWorkDisInTax ) resList.Add( "ItdedWorkDisInTax" );
            if ( salesSlipSearchResult1.ItdedSalesDisTaxFre != salesSlipSearchResult2.ItdedSalesDisTaxFre ) resList.Add( "ItdedSalesDisTaxFre" );
            if ( salesSlipSearchResult1.SalesDisOutTax != salesSlipSearchResult2.SalesDisOutTax ) resList.Add( "SalesDisOutTax" );
            if ( salesSlipSearchResult1.SalesDisTtlTaxInclu != salesSlipSearchResult2.SalesDisTtlTaxInclu ) resList.Add( "SalesDisTtlTaxInclu" );
            if ( salesSlipSearchResult1.PartsDiscountRate != salesSlipSearchResult2.PartsDiscountRate ) resList.Add( "PartsDiscountRate" );
            if ( salesSlipSearchResult1.RavorDiscountRate != salesSlipSearchResult2.RavorDiscountRate ) resList.Add( "RavorDiscountRate" );
            if ( salesSlipSearchResult1.TotalCost != salesSlipSearchResult2.TotalCost ) resList.Add( "TotalCost" );
            if ( salesSlipSearchResult1.ConsTaxLayMethod != salesSlipSearchResult2.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( salesSlipSearchResult1.ConsTaxRate != salesSlipSearchResult2.ConsTaxRate ) resList.Add( "ConsTaxRate" );
            if ( salesSlipSearchResult1.FractionProcCd != salesSlipSearchResult2.FractionProcCd ) resList.Add( "FractionProcCd" );
            if ( salesSlipSearchResult1.AccRecConsTax != salesSlipSearchResult2.AccRecConsTax ) resList.Add( "AccRecConsTax" );
            if ( salesSlipSearchResult1.AutoDepositCd != salesSlipSearchResult2.AutoDepositCd ) resList.Add( "AutoDepositCd" );
            if ( salesSlipSearchResult1.AutoDepositSlipNo != salesSlipSearchResult2.AutoDepositSlipNo ) resList.Add( "AutoDepositSlipNo" );
            if ( salesSlipSearchResult1.DepositAllowanceTtl != salesSlipSearchResult2.DepositAllowanceTtl ) resList.Add( "DepositAllowanceTtl" );
            if ( salesSlipSearchResult1.DepositAlwcBlnce != salesSlipSearchResult2.DepositAlwcBlnce ) resList.Add( "DepositAlwcBlnce" );
            if ( salesSlipSearchResult1.ClaimCode != salesSlipSearchResult2.ClaimCode ) resList.Add( "ClaimCode" );
            if ( salesSlipSearchResult1.ClaimSnm != salesSlipSearchResult2.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( salesSlipSearchResult1.CustomerCode != salesSlipSearchResult2.CustomerCode ) resList.Add( "CustomerCode" );
            if ( salesSlipSearchResult1.CustomerName != salesSlipSearchResult2.CustomerName ) resList.Add( "CustomerName" );
            if ( salesSlipSearchResult1.CustomerName2 != salesSlipSearchResult2.CustomerName2 ) resList.Add( "CustomerName2" );
            if ( salesSlipSearchResult1.CustomerSnm != salesSlipSearchResult2.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( salesSlipSearchResult1.HonorificTitle != salesSlipSearchResult2.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( salesSlipSearchResult1.OutputName != salesSlipSearchResult2.OutputName ) resList.Add( "OutputName" );
            if ( salesSlipSearchResult1.CustSlipNo != salesSlipSearchResult2.CustSlipNo ) resList.Add( "CustSlipNo" );
            if ( salesSlipSearchResult1.SlipAddressDiv != salesSlipSearchResult2.SlipAddressDiv ) resList.Add( "SlipAddressDiv" );
            if ( salesSlipSearchResult1.AddresseeCode != salesSlipSearchResult2.AddresseeCode ) resList.Add( "AddresseeCode" );
            if ( salesSlipSearchResult1.AddresseeName != salesSlipSearchResult2.AddresseeName ) resList.Add( "AddresseeName" );
            if ( salesSlipSearchResult1.AddresseeName2 != salesSlipSearchResult2.AddresseeName2 ) resList.Add( "AddresseeName2" );
            if ( salesSlipSearchResult1.AddresseePostNo != salesSlipSearchResult2.AddresseePostNo ) resList.Add( "AddresseePostNo" );
            if ( salesSlipSearchResult1.AddresseeAddr1 != salesSlipSearchResult2.AddresseeAddr1 ) resList.Add( "AddresseeAddr1" );
            if ( salesSlipSearchResult1.AddresseeAddr3 != salesSlipSearchResult2.AddresseeAddr3 ) resList.Add( "AddresseeAddr3" );
            if ( salesSlipSearchResult1.AddresseeAddr4 != salesSlipSearchResult2.AddresseeAddr4 ) resList.Add( "AddresseeAddr4" );
            if ( salesSlipSearchResult1.AddresseeTelNo != salesSlipSearchResult2.AddresseeTelNo ) resList.Add( "AddresseeTelNo" );
            if ( salesSlipSearchResult1.AddresseeFaxNo != salesSlipSearchResult2.AddresseeFaxNo ) resList.Add( "AddresseeFaxNo" );
            if ( salesSlipSearchResult1.PartySaleSlipNum != salesSlipSearchResult2.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( salesSlipSearchResult1.SlipNote != salesSlipSearchResult2.SlipNote ) resList.Add( "SlipNote" );
            if ( salesSlipSearchResult1.SlipNote2 != salesSlipSearchResult2.SlipNote2 ) resList.Add( "SlipNote2" );
            if ( salesSlipSearchResult1.SlipNote3 != salesSlipSearchResult2.SlipNote3 ) resList.Add( "SlipNote3" );
            if ( salesSlipSearchResult1.RetGoodsReasonDiv != salesSlipSearchResult2.RetGoodsReasonDiv ) resList.Add( "RetGoodsReasonDiv" );
            if ( salesSlipSearchResult1.RetGoodsReason != salesSlipSearchResult2.RetGoodsReason ) resList.Add( "RetGoodsReason" );
            if ( salesSlipSearchResult1.RegiProcDate != salesSlipSearchResult2.RegiProcDate ) resList.Add( "RegiProcDate" );
            if ( salesSlipSearchResult1.CashRegisterNo != salesSlipSearchResult2.CashRegisterNo ) resList.Add( "CashRegisterNo" );
            if ( salesSlipSearchResult1.PosReceiptNo != salesSlipSearchResult2.PosReceiptNo ) resList.Add( "PosReceiptNo" );
            if ( salesSlipSearchResult1.DetailRowCount != salesSlipSearchResult2.DetailRowCount ) resList.Add( "DetailRowCount" );
            if ( salesSlipSearchResult1.EdiSendDate != salesSlipSearchResult2.EdiSendDate ) resList.Add( "EdiSendDate" );
            if ( salesSlipSearchResult1.EdiTakeInDate != salesSlipSearchResult2.EdiTakeInDate ) resList.Add( "EdiTakeInDate" );
            if ( salesSlipSearchResult1.UoeRemark1 != salesSlipSearchResult2.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( salesSlipSearchResult1.UoeRemark2 != salesSlipSearchResult2.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( salesSlipSearchResult1.SlipPrintDivCd != salesSlipSearchResult2.SlipPrintDivCd ) resList.Add( "SlipPrintDivCd" );
            if ( salesSlipSearchResult1.SlipPrintFinishCd != salesSlipSearchResult2.SlipPrintFinishCd ) resList.Add( "SlipPrintFinishCd" );
            if ( salesSlipSearchResult1.SalesSlipPrintDate != salesSlipSearchResult2.SalesSlipPrintDate ) resList.Add( "SalesSlipPrintDate" );
            if ( salesSlipSearchResult1.BusinessTypeCode != salesSlipSearchResult2.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( salesSlipSearchResult1.BusinessTypeName != salesSlipSearchResult2.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( salesSlipSearchResult1.OrderNumber != salesSlipSearchResult2.OrderNumber ) resList.Add( "OrderNumber" );
            if ( salesSlipSearchResult1.DeliveredGoodsDiv != salesSlipSearchResult2.DeliveredGoodsDiv ) resList.Add( "DeliveredGoodsDiv" );
            if ( salesSlipSearchResult1.DeliveredGoodsDivNm != salesSlipSearchResult2.DeliveredGoodsDivNm ) resList.Add( "DeliveredGoodsDivNm" );
            if ( salesSlipSearchResult1.SalesAreaCode != salesSlipSearchResult2.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( salesSlipSearchResult1.SalesAreaName != salesSlipSearchResult2.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( salesSlipSearchResult1.ReconcileFlag != salesSlipSearchResult2.ReconcileFlag ) resList.Add( "ReconcileFlag" );
            if ( salesSlipSearchResult1.SlipPrtSetPaperId != salesSlipSearchResult2.SlipPrtSetPaperId ) resList.Add( "SlipPrtSetPaperId" );
            if ( salesSlipSearchResult1.CompleteCd != salesSlipSearchResult2.CompleteCd ) resList.Add( "CompleteCd" );
            if ( salesSlipSearchResult1.SalesPriceFracProcCd != salesSlipSearchResult2.SalesPriceFracProcCd ) resList.Add( "SalesPriceFracProcCd" );
            if ( salesSlipSearchResult1.StockGoodsTtlTaxExc != salesSlipSearchResult2.StockGoodsTtlTaxExc ) resList.Add( "StockGoodsTtlTaxExc" );
            if ( salesSlipSearchResult1.PureGoodsTtlTaxExc != salesSlipSearchResult2.PureGoodsTtlTaxExc ) resList.Add( "PureGoodsTtlTaxExc" );
            if ( salesSlipSearchResult1.ListPricePrintDiv != salesSlipSearchResult2.ListPricePrintDiv ) resList.Add( "ListPricePrintDiv" );
            if ( salesSlipSearchResult1.EraNameDispCd1 != salesSlipSearchResult2.EraNameDispCd1 ) resList.Add( "EraNameDispCd1" );
            if ( salesSlipSearchResult1.EstimaTaxDivCd != salesSlipSearchResult2.EstimaTaxDivCd ) resList.Add( "EstimaTaxDivCd" );
            if ( salesSlipSearchResult1.EstimateFormPrtCd != salesSlipSearchResult2.EstimateFormPrtCd ) resList.Add( "EstimateFormPrtCd" );
            if ( salesSlipSearchResult1.EstimateSubject != salesSlipSearchResult2.EstimateSubject ) resList.Add( "EstimateSubject" );
            if ( salesSlipSearchResult1.Footnotes1 != salesSlipSearchResult2.Footnotes1 ) resList.Add( "Footnotes1" );
            if ( salesSlipSearchResult1.Footnotes2 != salesSlipSearchResult2.Footnotes2 ) resList.Add( "Footnotes2" );
            if ( salesSlipSearchResult1.EstimateTitle1 != salesSlipSearchResult2.EstimateTitle1 ) resList.Add( "EstimateTitle1" );
            if ( salesSlipSearchResult1.EstimateTitle2 != salesSlipSearchResult2.EstimateTitle2 ) resList.Add( "EstimateTitle2" );
            if ( salesSlipSearchResult1.EstimateTitle3 != salesSlipSearchResult2.EstimateTitle3 ) resList.Add( "EstimateTitle3" );
            if ( salesSlipSearchResult1.EstimateTitle4 != salesSlipSearchResult2.EstimateTitle4 ) resList.Add( "EstimateTitle4" );
            if ( salesSlipSearchResult1.EstimateTitle5 != salesSlipSearchResult2.EstimateTitle5 ) resList.Add( "EstimateTitle5" );
            if ( salesSlipSearchResult1.EstimateNote1 != salesSlipSearchResult2.EstimateNote1 ) resList.Add( "EstimateNote1" );
            if ( salesSlipSearchResult1.EstimateNote2 != salesSlipSearchResult2.EstimateNote2 ) resList.Add( "EstimateNote2" );
            if ( salesSlipSearchResult1.EstimateNote3 != salesSlipSearchResult2.EstimateNote3 ) resList.Add( "EstimateNote3" );
            if ( salesSlipSearchResult1.EstimateNote4 != salesSlipSearchResult2.EstimateNote4 ) resList.Add( "EstimateNote4" );
            if ( salesSlipSearchResult1.EstimateNote5 != salesSlipSearchResult2.EstimateNote5 ) resList.Add( "EstimateNote5" );
            if ( salesSlipSearchResult1.EstimateValidityDate != salesSlipSearchResult2.EstimateValidityDate ) resList.Add( "EstimateValidityDate" );
            if ( salesSlipSearchResult1.PartsNoPrtCd != salesSlipSearchResult2.PartsNoPrtCd ) resList.Add( "PartsNoPrtCd" );
            if ( salesSlipSearchResult1.OptionPringDivCd != salesSlipSearchResult2.OptionPringDivCd ) resList.Add( "OptionPringDivCd" );
            if ( salesSlipSearchResult1.RateUseCode != salesSlipSearchResult2.RateUseCode ) resList.Add( "RateUseCode" );
            if ( salesSlipSearchResult1.CarMngCode != salesSlipSearchResult2.CarMngCode ) resList.Add( "CarMngCode" );
            if ( salesSlipSearchResult1.ModelDesignationNo != salesSlipSearchResult2.ModelDesignationNo ) resList.Add( "ModelDesignationNo" );
            if ( salesSlipSearchResult1.CategoryNo != salesSlipSearchResult2.CategoryNo ) resList.Add( "CategoryNo" );
            if ( salesSlipSearchResult1.MakerFullName != salesSlipSearchResult2.MakerFullName ) resList.Add( "MakerFullName" );
            if ( salesSlipSearchResult1.FullModel != salesSlipSearchResult2.FullModel ) resList.Add( "FullModel" );
            if ( salesSlipSearchResult1.ModelFullName != salesSlipSearchResult2.ModelFullName ) resList.Add( "ModelFullName" );
            if ( salesSlipSearchResult1.EnterpriseName != salesSlipSearchResult2.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( salesSlipSearchResult1.ResultsAddUpSecNm != salesSlipSearchResult2.ResultsAddUpSecNm ) resList.Add( "ResultsAddUpSecNm" );

            return resList;
        }
    }

}

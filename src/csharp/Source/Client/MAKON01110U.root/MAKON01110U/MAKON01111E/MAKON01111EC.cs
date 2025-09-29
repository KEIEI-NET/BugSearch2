using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesTemp
	/// <summary>
	///                      ����f�[�^�i�d�������v��j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����f�[�^�i�d�������v��j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/03/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalesTemp
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
		/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>����R�[�h</summary>
		private Int32 _subSectionCode;

		/// <summary>�ۃR�[�h</summary>
		private Int32 _minSectionCode;

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>0:���`,1:�ԓ`,2:����</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>�ԍ��A���󒍔ԍ�</summary>
		/// <remarks>�ԍ��̑�����󒍔ԍ�</remarks>
		private Int32 _debitNLnkAcptAnOdr;

		/// <summary>����`�[�敪</summary>
		/// <remarks>0:����,1:�ԕi</remarks>
		private Int32 _salesSlipCd;

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
		/// <remarks>YYYYMMDD</remarks>
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

		/// <summary>�����R�[�h</summary>
		/// <remarks>0:�������Ӑ�,1:�������Ӑ�</remarks>
		private Int32 _outputNameCode;

		/// <summary>�Ǝ�R�[�h</summary>
		private Int32 _businessTypeCode;

		/// <summary>�Ǝ햼��</summary>
		private string _businessTypeName = "";

		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _salesAreaCode;

		/// <summary>�̔��G���A����</summary>
		private string _salesAreaName = "";

		/// <summary>������͎҃R�[�h</summary>
		/// <remarks>���͒S����</remarks>
		private string _salesInputCode = "";

		/// <summary>������͎Җ���</summary>
		private string _salesInputName = "";

		/// <summary>��t�]�ƈ��R�[�h</summary>
		/// <remarks>��t�S����</remarks>
		private string _frontEmployeeCd = "";

		/// <summary>��t�]�ƈ�����</summary>
		private string _frontEmployeeNm = "";

		/// <summary>�̔��]�ƈ��R�[�h</summary>
		/// <remarks>�v��S����</remarks>
		private string _salesEmployeeCd = "";

		/// <summary>�̔��]�ƈ�����</summary>
		private string _salesEmployeeNm = "";

		/// <summary>����œ]�ŕ���</summary>
		/// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>����Őŗ�</summary>
		/// <remarks>�ύX2007/8/22(�^,��) ����</remarks>
		private Double _consTaxRate;

		/// <summary>�[�������敪</summary>
		/// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
		private Int32 _fractionProcCd;

		/// <summary>���������敪</summary>
		/// <remarks>0:�ʏ����,1:��������</remarks>
		private Int32 _autoDepositCd;

		/// <summary>���������`�[�ԍ�</summary>
		/// <remarks>�����������̓����`�[�ԍ�</remarks>
		private Int32 _autoDepoSlipNum;

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

		/// <summary>�[�i��Z��2(����)</summary>
		/// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
		private Int32 _addresseeAddr2;

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
		/// <remarks>���Ӑ撍���ԍ�</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>�`�[���l</summary>
		private string _slipNote = "";

		/// <summary>�`�[���l�Q</summary>
		private string _slipNote2 = "";

		/// <summary>�ԕi���R�R�[�h</summary>
		private Int32 _retGoodsReasonDiv;

		/// <summary>�ԕi���R</summary>
		private string _retGoodsReason = "";

		/// <summary>���׍s��</summary>
		/// <remarks>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</remarks>
		private Int32 _detailRowCount;

		/// <summary>�[�i�敪</summary>
		/// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>�[�i�敪����</summary>
		private string _deliveredGoodsDivNm = "";

		/// <summary>�����t���O</summary>
		/// <remarks>0:�c���� 1:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</remarks>
		private Int32 _reconcileFlag;

		/// <summary>�`�[����ݒ�p���[ID</summary>
		/// <remarks>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>�ꎮ�`�[�敪</summary>
		/// <remarks>0:�ʏ�`�[,1:�ꎮ�`�[</remarks>
		private Int32 _completeCd;

		/// <summary>������敪</summary>
		/// <remarks>���������敪�i0:��ʁ@1:�����W���@2:�����`�[�j</remarks>
		private Int32 _claimType;

		/// <summary>������z�[�������敪</summary>
		/// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</remarks>
		private Int32 _salesPriceFracProcCd;

		/// <summary>�艿����敪</summary>
		private Int32 _listPricePrintDiv;

		/// <summary>�����\���敪�P</summary>
		/// <remarks>�ʏ�@�@0:����@1:�a��</remarks>
		private Int32 _eraNameDispCd1;

		/// <summary>�󒍔ԍ�</summary>
		private Int32 _acceptAnOrderNo;

		/// <summary>���ʒʔ�</summary>
		private Int64 _commonSeqNo;

		/// <summary>���㖾�גʔ�</summary>
		private Int64 _salesSlipDtlNum;

		/// <summary>�󒍃X�e�[�^�X�i���j</summary>
		/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
		private Int32 _acptAnOdrStatusSrc;

		/// <summary>���㖾�גʔԁi���j</summary>
		/// <remarks>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</remarks>
		private Int64 _salesSlipDtlNumSrc;

		/// <summary>�d���`���i�����j</summary>
		/// <remarks>0:�d��,1:����</remarks>
		private Int32 _supplierFormalSync;

		/// <summary>�d�����גʔԁi�����j</summary>
		/// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
		private Int64 _stockSlipDtlNumSync;

		/// <summary>����`�[�敪�i���ׁj</summary>
		/// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>�����ԍ�</summary>
		/// <remarks>����`����"�o��"�̎��ɃZ�b�g�i�����̌v��j</remarks>
		private string _orderNumber = "";

		/// <summary>�݌ɊǗ��L���敪</summary>
		/// <remarks>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</remarks>
		private Int32 _stockMngExistCd;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>���i����</summary>
		/// <remarks>0:���� 1:���̑�</remarks>
		private Int32 _goodsKindCode;

		/// <summary>���i���[�J�[�R�[�h</summary>
		/// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>���i������</summary>
		private string _goodsShortName = "";

		/// <summary>�Z�b�g���i�敪</summary>
		/// <remarks>0:�ʏ�,1:�e���i,2:�q���i</remarks>
		private Int32 _goodsSetDivCd;

		/// <summary>���i�敪�O���[�v�R�[�h</summary>
		/// <remarks>���F���i�啪�ރR�[�h</remarks>
		private string _largeGoodsGanreCode = "";

		/// <summary>���i�敪�O���[�v����</summary>
		/// <remarks>���F���i�啪�ޖ���</remarks>
		private string _largeGoodsGanreName = "";

		/// <summary>���i�敪�R�[�h</summary>
		/// <remarks>���F���i�����ރR�[�h</remarks>
		private string _mediumGoodsGanreCode = "";

		/// <summary>���i�敪����</summary>
		/// <remarks>���F���i�����ޖ���</remarks>
		private string _mediumGoodsGanreName = "";

		/// <summary>���i�敪�ڍ׃R�[�h</summary>
		private string _detailGoodsGanreCode = "";

		/// <summary>���i�敪�ڍז���</summary>
		private string _detailGoodsGanreName = "";

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

		/// <summary>����݌Ɏ�񂹋敪</summary>
		/// <remarks>0:���,1:�݌�</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>�I�[�v�����i�敪</summary>
		/// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
		private Int32 _openPriceDiv;

		/// <summary>�P�ʃR�[�h</summary>
		private Int32 _unitCode;

		/// <summary>�P�ʖ���</summary>
		private string _unitName = "";

		/// <summary>���i�|�������N</summary>
		/// <remarks>���i�̊|���p�����N</remarks>
		private string _goodsRateRank = "";

		/// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
		private Int32 _custRateGrpCode;

		/// <summary>�d����|���O���[�v�R�[�h</summary>
		private Int32 _suppRateGrpCode;

		/// <summary>�艿��</summary>
		private Double _listPriceRate;

		/// <summary>�|���ݒ苒�_�i�艿�j</summary>
		/// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
		private string _rateSectPriceUnPrc = "";

		/// <summary>�|���ݒ�敪�i�艿�j</summary>
		/// <remarks>A1,A2,�c</remarks>
		private string _rateDivLPrice = "";

		/// <summary>�P���Z�o�敪�i�艿�j</summary>
		/// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
		private Int32 _unPrcCalcCdLPrice;

		/// <summary>���i�敪�i�艿�j</summary>
		/// <remarks>0:�艿,1:�o�^�̔��X���i,�c 9:���[�U�[�艿</remarks>
		private Int32 _priceCdLPrice;

		/// <summary>��P���i�艿�j</summary>
		private Double _stdUnPrcLPrice;

		/// <summary>�[�������P�ʁi�艿�j</summary>
		private Double _fracProcUnitLPrice;

		/// <summary>�[�������i�艿�j</summary>
		/// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
		private Int32 _fracProcLPrice;

		/// <summary>�艿�i�ō��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _listPriceTaxIncFl;

		/// <summary>�艿�i�Ŕ��C�����j</summary>
		/// <remarks>�ō���</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>�艿�ύX�敪</summary>
		/// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j</remarks>
		private Int32 _listPriceChngCd;

		/// <summary>������</summary>
		private Double _salesRate;

		/// <summary>�|���ݒ苒�_�i����P���j</summary>
		/// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
		private string _rateSectSalUnPrc = "";

		/// <summary>�|���ݒ�敪�i����P���j</summary>
		/// <remarks>A1,A2,�c</remarks>
		private string _rateDivSalUnPrc = "";

		/// <summary>�P���Z�o�敪�i����P���j</summary>
		/// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
		private Int32 _unPrcCalcCdSalUnPrc;

		/// <summary>���i�敪�i����P���j</summary>
		/// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
		private Int32 _priceCdSalUnPrc;

		/// <summary>��P���i����P���j</summary>
		private Double _stdUnPrcSalUnPrc;

		/// <summary>�[�������P�ʁi����P���j</summary>
		private Double _fracProcUnitSalUnPrc;

		/// <summary>�[�������i����P���j</summary>
		/// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
		private Int32 _fracProcSalUnPrc;

		/// <summary>����P���i�ō��C�����j</summary>
		private Double _salesUnPrcTaxIncFl;

		/// <summary>����P���i�Ŕ��C�����j</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>����P���ύX�敪</summary>
		/// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i����P������́j</remarks>
		private Int32 _salesUnPrcChngCd;

		/// <summary>������</summary>
		private Double _costRate;

		/// <summary>�|���ݒ苒�_�i�����P���j</summary>
		/// <remarks>0:�S�Аݒ�, ���̑�:���_�R�[�h</remarks>
		private string _rateSectCstUnPrc = "";

		/// <summary>�|���ݒ�敪�i�����P���j</summary>
		/// <remarks>A7,A8,�c</remarks>
		private string _rateDivUnCst = "";

		/// <summary>�P���Z�o�敪�i�����P���j</summary>
		/// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
		private Int32 _unPrcCalcCdUnCst;

		/// <summary>���i�敪�i�����P���j</summary>
		/// <remarks>0:�艿,1:�o�^�̔��X���i,�c</remarks>
		private Int32 _priceCdUnCst;

		/// <summary>��P���i�����P���j</summary>
		private Double _stdUnPrcUnCst;

		/// <summary>�[�������P�ʁi�����P���j</summary>
		private Double _fracProcUnitUnCst;

		/// <summary>�[�������i�����P���j</summary>
		/// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
		private Int32 _fracProcUnCst;

		/// <summary>�����P��</summary>
		private Double _salesUnitCost;

		/// <summary>�����P���ύX�敪</summary>
		/// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�����P������́j</remarks>
		private Int32 _salesUnitCostChngDiv;

		/// <summary>BL���i�R�[�h�i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
		private Int32 _rateBLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�|���j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
		private string _rateBLGoodsName = "";

		/// <summary>�����敪�R�[�h</summary>
		private Int32 _bargainCd;

		/// <summary>�����敪����</summary>
		private string _bargainNm = "";

		/// <summary>�o�א�</summary>
		/// <remarks>����F���㐔�A�󒍁F�󒍐��A�o�ׁF�o�א��A���ρF���ϐ�</remarks>
		private Double _shipmentCnt;

		/// <summary>������z�i�ō��݁j</summary>
		private Int64 _salesMoneyTaxInc;

		/// <summary>������z�i�Ŕ����j</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>����</summary>
		private Int64 _cost;

		/// <summary>�e���`�F�b�N�敪</summary>
		/// <remarks>0:����,1:��������,2:���v�̏グ�߂�</remarks>
		private Int32 _grsProfitChkDiv;

		/// <summary>���㏤�i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</remarks>
		private Int32 _salesGoodsCd;

		/// <summary>������z����Ŋz</summary>
		/// <remarks>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</remarks>
		private Int64 _salsePriceConsTax;

		/// <summary>�ېŋ敪</summary>
		/// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
		private Int32 _taxationDivCd;

		/// <summary>�����`�[�ԍ��i���ׁj</summary>
		/// <remarks>���Ӑ撍���ԍ�</remarks>
		private string _partySlipNumDtl = "";

		/// <summary>���ה��l</summary>
		private string _dtlNote = "";

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�`�[�����P</summary>
		private string _slipMemo1 = "";

		/// <summary>�`�[�����Q</summary>
		private string _slipMemo2 = "";

		/// <summary>�`�[�����R</summary>
		private string _slipMemo3 = "";

		/// <summary>�`�[�����S</summary>
		private string _slipMemo4 = "";

		/// <summary>�`�[�����T</summary>
		private string _slipMemo5 = "";

		/// <summary>�`�[�����U</summary>
		private string _slipMemo6 = "";

		/// <summary>�Г������P</summary>
		private string _insideMemo1 = "";

		/// <summary>�Г������Q</summary>
		private string _insideMemo2 = "";

		/// <summary>�Г������R</summary>
		private string _insideMemo3 = "";

		/// <summary>�Г������S</summary>
		private string _insideMemo4 = "";

		/// <summary>�Г������T</summary>
		private string _insideMemo5 = "";

		/// <summary>�Г������U</summary>
		private string _insideMemo6 = "";

		/// <summary>�ύX�O�艿</summary>
		/// <remarks>�Ŕ����A�|���Z�o����</remarks>
		private Double _bfListPrice;

		/// <summary>�ύX�O����</summary>
		/// <remarks>�Ŕ����A�|���Z�o����</remarks>
		private Double _bfSalesUnitPrice;

		/// <summary>�ύX�O����</summary>
		/// <remarks>�Ŕ����A�|���Z�o����</remarks>
		private Double _bfUnitCost;

		/// <summary>����p���i�ԍ�</summary>
		private string _prtGoodsNo = "";

		/// <summary>����p���i����</summary>
		private string _prtGoodsName = "";

		/// <summary>����p���i���[�J�[�R�[�h</summary>
		private Int32 _prtGoodsMakerCd;

		/// <summary>����p���i���[�J�[����</summary>
		private string _prtGoodsMakerNm = "";

		/// <summary>�d���`�[�敪</summary>
		private Int32 _supplierSlipCd;

		/// <summary>���z�\�����@�敪</summary>
		/// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>���z�\���|���K�p�敪</summary>
		/// <remarks>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</remarks>
		private Int32 _ttlAmntDispRateApy;

		/// <summary>�m�F�敪</summary>
		private bool _confirmedDiv;

		/// <summary>���񊨒�J�n��</summary>
		/// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
		private Int32 _nTimeCalcStDate;

		/// <summary>����</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>���׊֘A�t��GUID</summary>
		private Guid _dtlRelationGuid;

		/// <summary>�󒍎c��</summary>
		/// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
		private Double _acptAnOdrRemainCnt;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>���ьv�㋒�_����</summary>
		private string _resultsAddUpSecNm = "";

		/// <summary>��������</summary>
		private string _outputName = "";

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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
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
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
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
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
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
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
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
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
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
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _subSectionCode;}
			set{_subSectionCode = value;}
		}

		/// public propaty name  :  MinSectionCode
		/// <summary>�ۃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ۃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MinSectionCode
		{
			get{return _minSectionCode;}
			set{_minSectionCode = value;}
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
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  DebitNLnkAcptAnOdr
		/// <summary>�ԍ��A���󒍔ԍ��v���p�e�B</summary>
		/// <value>�ԍ��̑�����󒍔ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��A���󒍔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNLnkAcptAnOdr
		{
			get{return _debitNLnkAcptAnOdr;}
			set{_debitNLnkAcptAnOdr = value;}
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
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
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
			get{return _accRecDivCd;}
			set{_accRecDivCd = value;}
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
			get{return _salesInpSecCd;}
			set{_salesInpSecCd = value;}
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
			get{return _demandAddUpSecCd;}
			set{_demandAddUpSecCd = value;}
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
			get{return _resultsAddUpSecCd;}
			set{_resultsAddUpSecCd = value;}
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
			get{return _updateSecCd;}
			set{_updateSecCd = value;}
		}

		/// public propaty name  :  SearchSlipDate
		/// <summary>�`�[�������t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime SearchSlipDate
		{
			get{return _searchSlipDate;}
			set{_searchSlipDate = value;}
		}

		/// public propaty name  :  SearchSlipDateJpFormal
		/// <summary>�`�[�������t �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SearchSlipDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  SearchSlipDateJpInFormal
		/// <summary>�`�[�������t �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SearchSlipDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  SearchSlipDateAdFormal
		/// <summary>�`�[�������t ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SearchSlipDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  SearchSlipDateAdInFormal
		/// <summary>�`�[�������t ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�������t ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SearchSlipDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _searchSlipDate);}
			set{}
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
			get{return _shipmentDay;}
			set{_shipmentDay = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay);}
			set{}
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
			get{return _salesDate;}
			set{_salesDate = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _salesDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _salesDate);}
			set{}
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
			get{return _addUpADate;}
			set{_addUpADate = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate);}
			set{}
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
			get{return _delayPaymentDiv;}
			set{_delayPaymentDiv = value;}
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
			get{return _claimCode;}
			set{_claimCode = value;}
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
			get{return _claimSnm;}
			set{_claimSnm = value;}
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
			get{return _customerCode;}
			set{_customerCode = value;}
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
			get{return _customerName;}
			set{_customerName = value;}
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
			get{return _customerName2;}
			set{_customerName2 = value;}
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
			get{return _customerSnm;}
			set{_customerSnm = value;}
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
			get{return _honorificTitle;}
			set{_honorificTitle = value;}
		}

		/// public propaty name  :  OutputNameCode
		/// <summary>�����R�[�h�v���p�e�B</summary>
		/// <value>0:�������Ӑ�,1:�������Ӑ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutputNameCode
		{
			get{return _outputNameCode;}
			set{_outputNameCode = value;}
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
			get{return _businessTypeCode;}
			set{_businessTypeCode = value;}
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
			get{return _businessTypeName;}
			set{_businessTypeName = value;}
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
			get{return _salesAreaCode;}
			set{_salesAreaCode = value;}
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
			get{return _salesAreaName;}
			set{_salesAreaName = value;}
		}

		/// public propaty name  :  SalesInputCode
		/// <summary>������͎҃R�[�h�v���p�e�B</summary>
		/// <value>���͒S����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputCode
		{
			get{return _salesInputCode;}
			set{_salesInputCode = value;}
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
			get{return _salesInputName;}
			set{_salesInputName = value;}
		}

		/// public propaty name  :  FrontEmployeeCd
		/// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>��t�S����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeCd
		{
			get{return _frontEmployeeCd;}
			set{_frontEmployeeCd = value;}
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
			get{return _frontEmployeeNm;}
			set{_frontEmployeeNm = value;}
		}

		/// public propaty name  :  SalesEmployeeCd
		/// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�v��S����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeCd
		{
			get{return _salesEmployeeCd;}
			set{_salesEmployeeCd = value;}
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
			get{return _salesEmployeeNm;}
			set{_salesEmployeeNm = value;}
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
			get{return _consTaxLayMethod;}
			set{_consTaxLayMethod = value;}
		}

		/// public propaty name  :  ConsTaxRate
		/// <summary>����Őŗ��v���p�e�B</summary>
		/// <value>�ύX2007/8/22(�^,��) ����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����Őŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ConsTaxRate
		{
			get{return _consTaxRate;}
			set{_consTaxRate = value;}
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
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
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
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		/// public propaty name  :  AutoDepoSlipNum
		/// <summary>���������`�[�ԍ��v���p�e�B</summary>
		/// <value>�����������̓����`�[�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoDepoSlipNum
		{
			get{return _autoDepoSlipNum;}
			set{_autoDepoSlipNum = value;}
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
			get{return _slipAddressDiv;}
			set{_slipAddressDiv = value;}
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
			get{return _addresseeCode;}
			set{_addresseeCode = value;}
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
			get{return _addresseeName;}
			set{_addresseeName = value;}
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
			get{return _addresseeName2;}
			set{_addresseeName2 = value;}
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
			get{return _addresseePostNo;}
			set{_addresseePostNo = value;}
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
			get{return _addresseeAddr1;}
			set{_addresseeAddr1 = value;}
		}

		/// public propaty name  :  AddresseeAddr2
		/// <summary>�[�i��Z��2(����)�v���p�e�B</summary>
		/// <value>�`�[�Z���敪�ɏ]�����e</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i��Z��2(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddresseeAddr2
		{
			get{return _addresseeAddr2;}
			set{_addresseeAddr2 = value;}
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
			get{return _addresseeAddr3;}
			set{_addresseeAddr3 = value;}
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
			get{return _addresseeAddr4;}
			set{_addresseeAddr4 = value;}
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
			get{return _addresseeTelNo;}
			set{_addresseeTelNo = value;}
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
			get{return _addresseeFaxNo;}
			set{_addresseeFaxNo = value;}
		}

		/// public propaty name  :  PartySaleSlipNum
		/// <summary>�����`�[�ԍ��v���p�e�B</summary>
		/// <value>���Ӑ撍���ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySaleSlipNum
		{
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
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
			get{return _slipNote;}
			set{_slipNote = value;}
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
			get{return _slipNote2;}
			set{_slipNote2 = value;}
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
			get{return _retGoodsReasonDiv;}
			set{_retGoodsReasonDiv = value;}
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
			get{return _retGoodsReason;}
			set{_retGoodsReason = value;}
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
			get{return _detailRowCount;}
			set{_detailRowCount = value;}
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
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
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
			get{return _deliveredGoodsDivNm;}
			set{_deliveredGoodsDivNm = value;}
		}

		/// public propaty name  :  ReconcileFlag
		/// <summary>�����t���O�v���p�e�B</summary>
		/// <value>0:�c���� 1:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ReconcileFlag
		{
			get{return _reconcileFlag;}
			set{_reconcileFlag = value;}
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
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
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
			get{return _completeCd;}
			set{_completeCd = value;}
		}

		/// public propaty name  :  ClaimType
		/// <summary>������敪�v���p�e�B</summary>
		/// <value>���������敪�i0:��ʁ@1:�����W���@2:�����`�[�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClaimType
		{
			get{return _claimType;}
			set{_claimType = value;}
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
			get{return _salesPriceFracProcCd;}
			set{_salesPriceFracProcCd = value;}
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
			get{return _listPricePrintDiv;}
			set{_listPricePrintDiv = value;}
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
			get{return _eraNameDispCd1;}
			set{_eraNameDispCd1 = value;}
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
			get{return _acceptAnOrderNo;}
			set{_acceptAnOrderNo = value;}
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
			get{return _commonSeqNo;}
			set{_commonSeqNo = value;}
		}

		/// public propaty name  :  SalesSlipDtlNum
		/// <summary>���㖾�גʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSlipDtlNum
		{
			get{return _salesSlipDtlNum;}
			set{_salesSlipDtlNum = value;}
		}

		/// public propaty name  :  AcptAnOdrStatusSrc
		/// <summary>�󒍃X�e�[�^�X�i���j�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����,40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�i���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatusSrc
		{
			get{return _acptAnOdrStatusSrc;}
			set{_acptAnOdrStatusSrc = value;}
		}

		/// public propaty name  :  SalesSlipDtlNumSrc
		/// <summary>���㖾�גʔԁi���j�v���p�e�B</summary>
		/// <value>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㖾�גʔԁi���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSlipDtlNumSrc
		{
			get{return _salesSlipDtlNumSrc;}
			set{_salesSlipDtlNumSrc = value;}
		}

		/// public propaty name  :  SupplierFormalSync
		/// <summary>�d���`���i�����j�v���p�e�B</summary>
		/// <value>0:�d��,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`���i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormalSync
		{
			get{return _supplierFormalSync;}
			set{_supplierFormalSync = value;}
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
			get{return _stockSlipDtlNumSync;}
			set{_stockSlipDtlNumSync = value;}
		}

		/// public propaty name  :  SalesSlipCdDtl
		/// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCdDtl
		{
			get{return _salesSlipCdDtl;}
			set{_salesSlipCdDtl = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>�����ԍ��v���p�e�B</summary>
		/// <value>����`����"�o��"�̎��ɃZ�b�g�i�����̌v��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  StockMngExistCd
		/// <summary>�݌ɊǗ��L���敪�v���p�e�B</summary>
		/// <value>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɊǗ��L���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockMngExistCd
		{
			get{return _stockMngExistCd;}
			set{_stockMngExistCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>�[�i�����\��� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>�[�i�����\��� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>�[�i�����\��� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>�[�i�����\��� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>���i�����v���p�e�B</summary>
		/// <value>0:���� 1:���̑�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
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
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
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
			get{return _makerName;}
			set{_makerName = value;}
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
			get{return _goodsNo;}
			set{_goodsNo = value;}
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
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  GoodsShortName
		/// <summary>���i�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsShortName
		{
			get{return _goodsShortName;}
			set{_goodsShortName = value;}
		}

		/// public propaty name  :  GoodsSetDivCd
		/// <summary>�Z�b�g���i�敪�v���p�e�B</summary>
		/// <value>0:�ʏ�,1:�e���i,2:�q���i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsSetDivCd
		{
			get{return _goodsSetDivCd;}
			set{_goodsSetDivCd = value;}
		}

		/// public propaty name  :  LargeGoodsGanreCode
		/// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���F���i�啪�ރR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LargeGoodsGanreCode
		{
			get{return _largeGoodsGanreCode;}
			set{_largeGoodsGanreCode = value;}
		}

		/// public propaty name  :  LargeGoodsGanreName
		/// <summary>���i�敪�O���[�v���̃v���p�e�B</summary>
		/// <value>���F���i�啪�ޖ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�O���[�v���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LargeGoodsGanreName
		{
			get{return _largeGoodsGanreName;}
			set{_largeGoodsGanreName = value;}
		}

		/// public propaty name  :  MediumGoodsGanreCode
		/// <summary>���i�敪�R�[�h�v���p�e�B</summary>
		/// <value>���F���i�����ރR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MediumGoodsGanreCode
		{
			get{return _mediumGoodsGanreCode;}
			set{_mediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  MediumGoodsGanreName
		/// <summary>���i�敪���̃v���p�e�B</summary>
		/// <value>���F���i�����ޖ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MediumGoodsGanreName
		{
			get{return _mediumGoodsGanreName;}
			set{_mediumGoodsGanreName = value;}
		}

		/// public propaty name  :  DetailGoodsGanreCode
		/// <summary>���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�ڍ׃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DetailGoodsGanreCode
		{
			get{return _detailGoodsGanreCode;}
			set{_detailGoodsGanreCode = value;}
		}

		/// public propaty name  :  DetailGoodsGanreName
		/// <summary>���i�敪�ڍז��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�ڍז��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DetailGoodsGanreName
		{
			get{return _detailGoodsGanreName;}
			set{_detailGoodsGanreName = value;}
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
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
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
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
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
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
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
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
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
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
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
			get{return _warehouseName;}
			set{_warehouseName = value;}
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
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  SalesOrderDivCd
		/// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
		/// <value>0:���,1:�݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesOrderDivCd
		{
			get{return _salesOrderDivCd;}
			set{_salesOrderDivCd = value;}
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
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  UnitCode
		/// <summary>�P�ʃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P�ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnitCode
		{
			get{return _unitCode;}
			set{_unitCode = value;}
		}

		/// public propaty name  :  UnitName
		/// <summary>�P�ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P�ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UnitName
		{
			get{return _unitName;}
			set{_unitName = value;}
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
			get{return _goodsRateRank;}
			set{_goodsRateRank = value;}
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
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
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
			get{return _suppRateGrpCode;}
			set{_suppRateGrpCode = value;}
		}

		/// public propaty name  :  ListPriceRate
		/// <summary>�艿���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceRate
		{
			get{return _listPriceRate;}
			set{_listPriceRate = value;}
		}

		/// public propaty name  :  RateSectPriceUnPrc
		/// <summary>�|���ݒ苒�_�i�艿�j�v���p�e�B</summary>
		/// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ苒�_�i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateSectPriceUnPrc
		{
			get{return _rateSectPriceUnPrc;}
			set{_rateSectPriceUnPrc = value;}
		}

		/// public propaty name  :  RateDivLPrice
		/// <summary>�|���ݒ�敪�i�艿�j�v���p�e�B</summary>
		/// <value>A1,A2,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ�敪�i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateDivLPrice
		{
			get{return _rateDivLPrice;}
			set{_rateDivLPrice = value;}
		}

		/// public propaty name  :  UnPrcCalcCdLPrice
		/// <summary>�P���Z�o�敪�i�艿�j�v���p�e�B</summary>
		/// <value>1:�|��,2:�����t�o��,3:�e����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���Z�o�敪�i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnPrcCalcCdLPrice
		{
			get{return _unPrcCalcCdLPrice;}
			set{_unPrcCalcCdLPrice = value;}
		}

		/// public propaty name  :  PriceCdLPrice
		/// <summary>���i�敪�i�艿�j�v���p�e�B</summary>
		/// <value>0:�艿,1:�o�^�̔��X���i,�c 9:���[�U�[�艿</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceCdLPrice
		{
			get{return _priceCdLPrice;}
			set{_priceCdLPrice = value;}
		}

		/// public propaty name  :  StdUnPrcLPrice
		/// <summary>��P���i�艿�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��P���i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StdUnPrcLPrice
		{
			get{return _stdUnPrcLPrice;}
			set{_stdUnPrcLPrice = value;}
		}

		/// public propaty name  :  FracProcUnitLPrice
		/// <summary>�[�������P�ʁi�艿�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������P�ʁi�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double FracProcUnitLPrice
		{
			get{return _fracProcUnitLPrice;}
			set{_fracProcUnitLPrice = value;}
		}

		/// public propaty name  :  FracProcLPrice
		/// <summary>�[�������i�艿�j�v���p�e�B</summary>
		/// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FracProcLPrice
		{
			get{return _fracProcLPrice;}
			set{_fracProcLPrice = value;}
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
			get{return _listPriceTaxIncFl;}
			set{_listPriceTaxIncFl = value;}
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
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  ListPriceChngCd
		/// <summary>�艿�ύX�敪�v���p�e�B</summary>
		/// <value>0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�ύX�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ListPriceChngCd
		{
			get{return _listPriceChngCd;}
			set{_listPriceChngCd = value;}
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
			get{return _salesRate;}
			set{_salesRate = value;}
		}

		/// public propaty name  :  RateSectSalUnPrc
		/// <summary>�|���ݒ苒�_�i����P���j�v���p�e�B</summary>
		/// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ苒�_�i����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateSectSalUnPrc
		{
			get{return _rateSectSalUnPrc;}
			set{_rateSectSalUnPrc = value;}
		}

		/// public propaty name  :  RateDivSalUnPrc
		/// <summary>�|���ݒ�敪�i����P���j�v���p�e�B</summary>
		/// <value>A1,A2,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ�敪�i����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateDivSalUnPrc
		{
			get{return _rateDivSalUnPrc;}
			set{_rateDivSalUnPrc = value;}
		}

		/// public propaty name  :  UnPrcCalcCdSalUnPrc
		/// <summary>�P���Z�o�敪�i����P���j�v���p�e�B</summary>
		/// <value>1:�|��,2:�����t�o��,3:�e����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���Z�o�敪�i����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnPrcCalcCdSalUnPrc
		{
			get{return _unPrcCalcCdSalUnPrc;}
			set{_unPrcCalcCdSalUnPrc = value;}
		}

		/// public propaty name  :  PriceCdSalUnPrc
		/// <summary>���i�敪�i����P���j�v���p�e�B</summary>
		/// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�i����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceCdSalUnPrc
		{
			get{return _priceCdSalUnPrc;}
			set{_priceCdSalUnPrc = value;}
		}

		/// public propaty name  :  StdUnPrcSalUnPrc
		/// <summary>��P���i����P���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��P���i����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StdUnPrcSalUnPrc
		{
			get{return _stdUnPrcSalUnPrc;}
			set{_stdUnPrcSalUnPrc = value;}
		}

		/// public propaty name  :  FracProcUnitSalUnPrc
		/// <summary>�[�������P�ʁi����P���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������P�ʁi����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double FracProcUnitSalUnPrc
		{
			get{return _fracProcUnitSalUnPrc;}
			set{_fracProcUnitSalUnPrc = value;}
		}

		/// public propaty name  :  FracProcSalUnPrc
		/// <summary>�[�������i����P���j�v���p�e�B</summary>
		/// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������i����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FracProcSalUnPrc
		{
			get{return _fracProcSalUnPrc;}
			set{_fracProcSalUnPrc = value;}
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
			get{return _salesUnPrcTaxIncFl;}
			set{_salesUnPrcTaxIncFl = value;}
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
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
		}

		/// public propaty name  :  SalesUnPrcChngCd
		/// <summary>����P���ύX�敪�v���p�e�B</summary>
		/// <value>0:�ύX�Ȃ�,1:�ύX����@�i����P������́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����P���ύX�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesUnPrcChngCd
		{
			get{return _salesUnPrcChngCd;}
			set{_salesUnPrcChngCd = value;}
		}

		/// public propaty name  :  CostRate
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double CostRate
		{
			get{return _costRate;}
			set{_costRate = value;}
		}

		/// public propaty name  :  RateSectCstUnPrc
		/// <summary>�|���ݒ苒�_�i�����P���j�v���p�e�B</summary>
		/// <value>0:�S�Аݒ�, ���̑�:���_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ苒�_�i�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateSectCstUnPrc
		{
			get{return _rateSectCstUnPrc;}
			set{_rateSectCstUnPrc = value;}
		}

		/// public propaty name  :  RateDivUnCst
		/// <summary>�|���ݒ�敪�i�����P���j�v���p�e�B</summary>
		/// <value>A7,A8,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���ݒ�敪�i�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateDivUnCst
		{
			get{return _rateDivUnCst;}
			set{_rateDivUnCst = value;}
		}

		/// public propaty name  :  UnPrcCalcCdUnCst
		/// <summary>�P���Z�o�敪�i�����P���j�v���p�e�B</summary>
		/// <value>1:�|��,2:�����t�o��,3:�e����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���Z�o�敪�i�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnPrcCalcCdUnCst
		{
			get{return _unPrcCalcCdUnCst;}
			set{_unPrcCalcCdUnCst = value;}
		}

		/// public propaty name  :  PriceCdUnCst
		/// <summary>���i�敪�i�����P���j�v���p�e�B</summary>
		/// <value>0:�艿,1:�o�^�̔��X���i,�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�i�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceCdUnCst
		{
			get{return _priceCdUnCst;}
			set{_priceCdUnCst = value;}
		}

		/// public propaty name  :  StdUnPrcUnCst
		/// <summary>��P���i�����P���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��P���i�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StdUnPrcUnCst
		{
			get{return _stdUnPrcUnCst;}
			set{_stdUnPrcUnCst = value;}
		}

		/// public propaty name  :  FracProcUnitUnCst
		/// <summary>�[�������P�ʁi�����P���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������P�ʁi�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double FracProcUnitUnCst
		{
			get{return _fracProcUnitUnCst;}
			set{_fracProcUnitUnCst = value;}
		}

		/// public propaty name  :  FracProcUnCst
		/// <summary>�[�������i�����P���j�v���p�e�B</summary>
		/// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������i�����P���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FracProcUnCst
		{
			get{return _fracProcUnCst;}
			set{_fracProcUnCst = value;}
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
			get{return _salesUnitCost;}
			set{_salesUnitCost = value;}
		}

		/// public propaty name  :  SalesUnitCostChngDiv
		/// <summary>�����P���ύX�敪�v���p�e�B</summary>
		/// <value>0:�ύX�Ȃ�,1:�ύX����@�i�����P������́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P���ύX�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesUnitCostChngDiv
		{
			get{return _salesUnitCostChngDiv;}
			set{_salesUnitCostChngDiv = value;}
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
			get{return _rateBLGoodsCode;}
			set{_rateBLGoodsCode = value;}
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
			get{return _rateBLGoodsName;}
			set{_rateBLGoodsName = value;}
		}

		/// public propaty name  :  BargainCd
		/// <summary>�����敪�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BargainCd
		{
			get{return _bargainCd;}
			set{_bargainCd = value;}
		}

		/// public propaty name  :  BargainNm
		/// <summary>�����敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BargainNm
		{
			get{return _bargainNm;}
			set{_bargainNm = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>�o�א��v���p�e�B</summary>
		/// <value>����F���㐔�A�󒍁F�󒍐��A�o�ׁF�o�א��A���ρF���ϐ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
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
			get{return _salesMoneyTaxInc;}
			set{_salesMoneyTaxInc = value;}
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
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
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
			get{return _cost;}
			set{_cost = value;}
		}

		/// public propaty name  :  GrsProfitChkDiv
		/// <summary>�e���`�F�b�N�敪�v���p�e�B</summary>
		/// <value>0:����,1:��������,2:���v�̏グ�߂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GrsProfitChkDiv
		{
			get{return _grsProfitChkDiv;}
			set{_grsProfitChkDiv = value;}
		}

		/// public propaty name  :  SalesGoodsCd
		/// <summary>���㏤�i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesGoodsCd
		{
			get{return _salesGoodsCd;}
			set{_salesGoodsCd = value;}
		}

		/// public propaty name  :  SalsePriceConsTax
		/// <summary>������z����Ŋz�v���p�e�B</summary>
		/// <value>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z����Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalsePriceConsTax
		{
			get{return _salsePriceConsTax;}
			set{_salsePriceConsTax = value;}
		}

		/// public propaty name  :  TaxationDivCd
		/// <summary>�ېŋ敪�v���p�e�B</summary>
		/// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ېŋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  PartySlipNumDtl
		/// <summary>�����`�[�ԍ��i���ׁj�v���p�e�B</summary>
		/// <value>���Ӑ撍���ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��i���ׁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySlipNumDtl
		{
			get{return _partySlipNumDtl;}
			set{_partySlipNumDtl = value;}
		}

		/// public propaty name  :  DtlNote
		/// <summary>���ה��l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ה��l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DtlNote
		{
			get{return _dtlNote;}
			set{_dtlNote = value;}
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
			get{return _supplierCd;}
			set{_supplierCd = value;}
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
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
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
			get{return _slipMemo1;}
			set{_slipMemo1 = value;}
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
			get{return _slipMemo2;}
			set{_slipMemo2 = value;}
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
			get{return _slipMemo3;}
			set{_slipMemo3 = value;}
		}

		/// public propaty name  :  SlipMemo4
		/// <summary>�`�[�����S�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����S�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipMemo4
		{
			get{return _slipMemo4;}
			set{_slipMemo4 = value;}
		}

		/// public propaty name  :  SlipMemo5
		/// <summary>�`�[�����T�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����T�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipMemo5
		{
			get{return _slipMemo5;}
			set{_slipMemo5 = value;}
		}

		/// public propaty name  :  SlipMemo6
		/// <summary>�`�[�����U�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����U�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipMemo6
		{
			get{return _slipMemo6;}
			set{_slipMemo6 = value;}
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
			get{return _insideMemo1;}
			set{_insideMemo1 = value;}
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
			get{return _insideMemo2;}
			set{_insideMemo2 = value;}
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
			get{return _insideMemo3;}
			set{_insideMemo3 = value;}
		}

		/// public propaty name  :  InsideMemo4
		/// <summary>�Г������S�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г������S�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InsideMemo4
		{
			get{return _insideMemo4;}
			set{_insideMemo4 = value;}
		}

		/// public propaty name  :  InsideMemo5
		/// <summary>�Г������T�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г������T�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InsideMemo5
		{
			get{return _insideMemo5;}
			set{_insideMemo5 = value;}
		}

		/// public propaty name  :  InsideMemo6
		/// <summary>�Г������U�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Г������U�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InsideMemo6
		{
			get{return _insideMemo6;}
			set{_insideMemo6 = value;}
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
			get{return _bfListPrice;}
			set{_bfListPrice = value;}
		}

		/// public propaty name  :  BfSalesUnitPrice
		/// <summary>�ύX�O�����v���p�e�B</summary>
		/// <value>�Ŕ����A�|���Z�o����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX�O�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BfSalesUnitPrice
		{
			get{return _bfSalesUnitPrice;}
			set{_bfSalesUnitPrice = value;}
		}

		/// public propaty name  :  BfUnitCost
		/// <summary>�ύX�O�����v���p�e�B</summary>
		/// <value>�Ŕ����A�|���Z�o����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX�O�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BfUnitCost
		{
			get{return _bfUnitCost;}
			set{_bfUnitCost = value;}
		}

		/// public propaty name  :  PrtGoodsNo
		/// <summary>����p���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtGoodsNo
		{
			get{return _prtGoodsNo;}
			set{_prtGoodsNo = value;}
		}

		/// public propaty name  :  PrtGoodsName
		/// <summary>����p���i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p���i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtGoodsName
		{
			get{return _prtGoodsName;}
			set{_prtGoodsName = value;}
		}

		/// public propaty name  :  PrtGoodsMakerCd
		/// <summary>����p���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrtGoodsMakerCd
		{
			get{return _prtGoodsMakerCd;}
			set{_prtGoodsMakerCd = value;}
		}

		/// public propaty name  :  PrtGoodsMakerNm
		/// <summary>����p���i���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p���i���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtGoodsMakerNm
		{
			get{return _prtGoodsMakerNm;}
			set{_prtGoodsMakerNm = value;}
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>�d���`�[�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
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
			get{return _totalAmountDispWayCd;}
			set{_totalAmountDispWayCd = value;}
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
			get{return _ttlAmntDispRateApy;}
			set{_ttlAmntDispRateApy = value;}
		}

		/// public propaty name  :  ConfirmedDiv
		/// <summary>�m�F�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m�F�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool ConfirmedDiv
		{
			get{return _confirmedDiv;}
			set{_confirmedDiv = value;}
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
			get{return _nTimeCalcStDate;}
			set{_nTimeCalcStDate = value;}
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
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  DtlRelationGuid
		/// <summary>���׊֘A�t��GUID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���׊֘A�t��GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid DtlRelationGuid
		{
			get{return _dtlRelationGuid;}
			set{_dtlRelationGuid = value;}
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
			get{return _acptAnOdrRemainCnt;}
			set{_acptAnOdrRemainCnt = value;}
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
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
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
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
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
			get{return _resultsAddUpSecNm;}
			set{_resultsAddUpSecNm = value;}
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
			get{return _outputName;}
			set{_outputName = value;}
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
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}


		/// <summary>
		/// ����f�[�^�i�d�������v��j�R���X�g���N�^
		/// </summary>
		/// <returns>SalesTemp�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTemp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesTemp()
		{
		}

		/// <summary>
		/// ����f�[�^�i�d�������v��j�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <param name="minSectionCode">�ۃR�[�h</param>
		/// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
		/// <param name="debitNLnkAcptAnOdr">�ԍ��A���󒍔ԍ�(�ԍ��̑�����󒍔ԍ�)</param>
		/// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi)</param>
		/// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
		/// <param name="salesInpSecCd">������͋��_�R�[�h(�����^ �������͂������_�R�[�h)</param>
		/// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h(�����^)</param>
		/// <param name="resultsAddUpSecCd">���ьv�㋒�_�R�[�h(���ьv����s����Ɠ��̋��_�R�[�h)</param>
		/// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
		/// <param name="searchSlipDate">�`�[�������t(YYYYMMDD)</param>
		/// <param name="shipmentDay">�o�ד��t(YYYYMMDD)</param>
		/// <param name="salesDate">������t(���ϓ��A�󒍓��A����������˂�B(YYYYMMDD))</param>
		/// <param name="addUpADate">�v����t(�������@(YYYYMMDD))</param>
		/// <param name="delayPaymentDiv">�����敪(0:����(�����Ȃ�),1:����,2:�ė����c9:9������)</param>
		/// <param name="claimCode">������R�[�h</param>
		/// <param name="claimSnm">�����旪��</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerName">���Ӑ於��</param>
		/// <param name="customerName2">���Ӑ於��2</param>
		/// <param name="customerSnm">���Ӑ旪��</param>
		/// <param name="honorificTitle">�h��</param>
		/// <param name="outputNameCode">�����R�[�h(0:�������Ӑ�,1:�������Ӑ�)</param>
		/// <param name="businessTypeCode">�Ǝ�R�[�h</param>
		/// <param name="businessTypeName">�Ǝ햼��</param>
		/// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
		/// <param name="salesAreaName">�̔��G���A����</param>
		/// <param name="salesInputCode">������͎҃R�[�h(���͒S����)</param>
		/// <param name="salesInputName">������͎Җ���</param>
		/// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(��t�S����)</param>
		/// <param name="frontEmployeeNm">��t�]�ƈ�����</param>
		/// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(�v��S����)</param>
		/// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
		/// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�)</param>
		/// <param name="consTaxRate">����Őŗ�(�ύX2007/8/22(�^,��) ����)</param>
		/// <param name="fractionProcCd">�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj)</param>
		/// <param name="autoDepositCd">���������敪(0:�ʏ����,1:��������)</param>
		/// <param name="autoDepoSlipNum">���������`�[�ԍ�(�����������̓����`�[�ԍ�)</param>
		/// <param name="slipAddressDiv">�`�[�Z���敪(1:���Ӑ�,2:�[����)</param>
		/// <param name="addresseeCode">�[�i��R�[�h</param>
		/// <param name="addresseeName">�[�i�於��</param>
		/// <param name="addresseeName2">�[�i�於��2(�ǉ�(�o�^�R��) ����)</param>
		/// <param name="addresseePostNo">�[�i��X�֔ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="addresseeAddr1">�[�i��Z��1(�s���{���s��S�E�����E��)(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="addresseeAddr2">�[�i��Z��2(����)(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="addresseeAddr3">�[�i��Z��3(�Ԓn)(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="addresseeAddr4">�[�i��Z��4(�A�p�[�g����)(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="addresseeTelNo">�[�i��d�b�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="addresseeFaxNo">�[�i��FAX�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
		/// <param name="partySaleSlipNum">�����`�[�ԍ�(���Ӑ撍���ԍ�)</param>
		/// <param name="slipNote">�`�[���l</param>
		/// <param name="slipNote2">�`�[���l�Q</param>
		/// <param name="retGoodsReasonDiv">�ԕi���R�R�[�h</param>
		/// <param name="retGoodsReason">�ԕi���R</param>
		/// <param name="detailRowCount">���׍s��(�`�[���̖��ׂ̍s���i����p���ׂ͏����j)</param>
		/// <param name="deliveredGoodsDiv">�[�i�敪(��) 1:�z�B,2:�X���n��,3:����,�c)</param>
		/// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
		/// <param name="reconcileFlag">�����t���O(0:�c���� 1:�c�����@�i�󒍁A�o�ׂɂĎg�p�j)</param>
		/// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��)</param>
		/// <param name="completeCd">�ꎮ�`�[�敪(0:�ʏ�`�[,1:�ꎮ�`�[)</param>
		/// <param name="claimType">������敪(���������敪�i0:��ʁ@1:�����W���@2:�����`�[�j)</param>
		/// <param name="salesPriceFracProcCd">������z�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j)</param>
		/// <param name="listPricePrintDiv">�艿����敪</param>
		/// <param name="eraNameDispCd1">�����\���敪�P(�ʏ�@�@0:����@1:�a��)</param>
		/// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
		/// <param name="commonSeqNo">���ʒʔ�</param>
		/// <param name="salesSlipDtlNum">���㖾�גʔ�</param>
		/// <param name="acptAnOdrStatusSrc">�󒍃X�e�[�^�X�i���j(10:����,20:��,30:����,40:�o��)</param>
		/// <param name="salesSlipDtlNumSrc">���㖾�גʔԁi���j(�v�㎞�̌��f�[�^���גʔԂ��Z�b�g)</param>
		/// <param name="supplierFormalSync">�d���`���i�����j(0:�d��,1:����)</param>
		/// <param name="stockSlipDtlNumSync">�d�����גʔԁi�����j(�����v�㎞�̎d�����גʔԂ��Z�b�g)</param>
		/// <param name="salesSlipCdDtl">����`�[�敪�i���ׁj(0:����,1:�ԕi,2:�l��,3:����,4:���v)</param>
		/// <param name="orderNumber">�����ԍ�(����`����"�o��"�̎��ɃZ�b�g�i�����̌v��j)</param>
		/// <param name="stockMngExistCd">�݌ɊǗ��L���敪(0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����)</param>
		/// <param name="deliGdsCmpltDueDate">�[�i�����\���(YYYYMMDD)</param>
		/// <param name="goodsKindCode">���i����(0:���� 1:���̑�)</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h(�߯���ޖ���հ�ް�o�^�͈͂��قȂ�)</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="goodsShortName">���i������</param>
		/// <param name="goodsSetDivCd">�Z�b�g���i�敪(0:�ʏ�,1:�e���i,2:�q���i)</param>
		/// <param name="largeGoodsGanreCode">���i�敪�O���[�v�R�[�h(���F���i�啪�ރR�[�h)</param>
		/// <param name="largeGoodsGanreName">���i�敪�O���[�v����(���F���i�啪�ޖ���)</param>
		/// <param name="mediumGoodsGanreCode">���i�敪�R�[�h(���F���i�����ރR�[�h)</param>
		/// <param name="mediumGoodsGanreName">���i�敪����(���F���i�����ޖ���)</param>
		/// <param name="detailGoodsGanreCode">���i�敪�ڍ׃R�[�h</param>
		/// <param name="detailGoodsGanreName">���i�敪�ڍז���</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
		/// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
		/// <param name="enterpriseGanreName">���Е��ޖ���</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		/// <param name="warehouseShelfNo">�q�ɒI��</param>
		/// <param name="salesOrderDivCd">����݌Ɏ�񂹋敪(0:���,1:�݌�)</param>
		/// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
		/// <param name="unitCode">�P�ʃR�[�h</param>
		/// <param name="unitName">�P�ʖ���</param>
		/// <param name="goodsRateRank">���i�|�������N(���i�̊|���p�����N)</param>
		/// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
		/// <param name="suppRateGrpCode">�d����|���O���[�v�R�[�h</param>
		/// <param name="listPriceRate">�艿��</param>
		/// <param name="rateSectPriceUnPrc">�|���ݒ苒�_�i�艿�j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
		/// <param name="rateDivLPrice">�|���ݒ�敪�i�艿�j(A1,A2,�c)</param>
		/// <param name="unPrcCalcCdLPrice">�P���Z�o�敪�i�艿�j(1:�|��,2:�����t�o��,3:�e����)</param>
		/// <param name="priceCdLPrice">���i�敪�i�艿�j(0:�艿,1:�o�^�̔��X���i,�c 9:���[�U�[�艿)</param>
		/// <param name="stdUnPrcLPrice">��P���i�艿�j</param>
		/// <param name="fracProcUnitLPrice">�[�������P�ʁi�艿�j</param>
		/// <param name="fracProcLPrice">�[�������i�艿�j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
		/// <param name="listPriceTaxIncFl">�艿�i�ō��C�����j(�Ŕ���)</param>
		/// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�ō���)</param>
		/// <param name="listPriceChngCd">�艿�ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j)</param>
		/// <param name="salesRate">������</param>
		/// <param name="rateSectSalUnPrc">�|���ݒ苒�_�i����P���j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
		/// <param name="rateDivSalUnPrc">�|���ݒ�敪�i����P���j(A1,A2,�c)</param>
		/// <param name="unPrcCalcCdSalUnPrc">�P���Z�o�敪�i����P���j(1:�|��,2:�����t�o��,3:�e����)</param>
		/// <param name="priceCdSalUnPrc">���i�敪�i����P���j(0:�艿,1:�o�^�̔��X���i,�c)</param>
		/// <param name="stdUnPrcSalUnPrc">��P���i����P���j</param>
		/// <param name="fracProcUnitSalUnPrc">�[�������P�ʁi����P���j</param>
		/// <param name="fracProcSalUnPrc">�[�������i����P���j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
		/// <param name="salesUnPrcTaxIncFl">����P���i�ō��C�����j</param>
		/// <param name="salesUnPrcTaxExcFl">����P���i�Ŕ��C�����j</param>
		/// <param name="salesUnPrcChngCd">����P���ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i����P������́j)</param>
		/// <param name="costRate">������</param>
		/// <param name="rateSectCstUnPrc">�|���ݒ苒�_�i�����P���j(0:�S�Аݒ�, ���̑�:���_�R�[�h)</param>
		/// <param name="rateDivUnCst">�|���ݒ�敪�i�����P���j(A7,A8,�c)</param>
		/// <param name="unPrcCalcCdUnCst">�P���Z�o�敪�i�����P���j(1:�|��,2:�����t�o��,3:�e����)</param>
		/// <param name="priceCdUnCst">���i�敪�i�����P���j(0:�艿,1:�o�^�̔��X���i,�c)</param>
		/// <param name="stdUnPrcUnCst">��P���i�����P���j</param>
		/// <param name="fracProcUnitUnCst">�[�������P�ʁi�����P���j</param>
		/// <param name="fracProcUnCst">�[�������i�����P���j(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
		/// <param name="salesUnitCost">�����P��</param>
		/// <param name="salesUnitCostChngDiv">�����P���ύX�敪(0:�ύX�Ȃ�,1:�ύX����@�i�����P������́j)</param>
		/// <param name="rateBLGoodsCode">BL���i�R�[�h�i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj)</param>
		/// <param name="rateBLGoodsName">BL���i�R�[�h���́i�|���j(�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj)</param>
		/// <param name="bargainCd">�����敪�R�[�h</param>
		/// <param name="bargainNm">�����敪����</param>
		/// <param name="shipmentCnt">�o�א�(����F���㐔�A�󒍁F�󒍐��A�o�ׁF�o�א��A���ρF���ϐ�)</param>
		/// <param name="salesMoneyTaxInc">������z�i�ō��݁j</param>
		/// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
		/// <param name="cost">����</param>
		/// <param name="grsProfitChkDiv">�e���`�F�b�N�敪(0:����,1:��������,2:���v�̏グ�߂�)</param>
		/// <param name="salesGoodsCd">���㏤�i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����))</param>
		/// <param name="salsePriceConsTax">������z����Ŋz(������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�)</param>
		/// <param name="taxationDivCd">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
		/// <param name="partySlipNumDtl">�����`�[�ԍ��i���ׁj(���Ӑ撍���ԍ�)</param>
		/// <param name="dtlNote">���ה��l</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="supplierSnm">�d���旪��</param>
		/// <param name="slipMemo1">�`�[�����P</param>
		/// <param name="slipMemo2">�`�[�����Q</param>
		/// <param name="slipMemo3">�`�[�����R</param>
		/// <param name="slipMemo4">�`�[�����S</param>
		/// <param name="slipMemo5">�`�[�����T</param>
		/// <param name="slipMemo6">�`�[�����U</param>
		/// <param name="insideMemo1">�Г������P</param>
		/// <param name="insideMemo2">�Г������Q</param>
		/// <param name="insideMemo3">�Г������R</param>
		/// <param name="insideMemo4">�Г������S</param>
		/// <param name="insideMemo5">�Г������T</param>
		/// <param name="insideMemo6">�Г������U</param>
		/// <param name="bfListPrice">�ύX�O�艿(�Ŕ����A�|���Z�o����)</param>
		/// <param name="bfSalesUnitPrice">�ύX�O����(�Ŕ����A�|���Z�o����)</param>
		/// <param name="bfUnitCost">�ύX�O����(�Ŕ����A�|���Z�o����)</param>
		/// <param name="prtGoodsNo">����p���i�ԍ�</param>
		/// <param name="prtGoodsName">����p���i����</param>
		/// <param name="prtGoodsMakerCd">����p���i���[�J�[�R�[�h</param>
		/// <param name="prtGoodsMakerNm">����p���i���[�J�[����</param>
		/// <param name="supplierSlipCd">�d���`�[�敪</param>
		/// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
		/// <param name="ttlAmntDispRateApy">���z�\���|���K�p�敪(0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��)</param>
		/// <param name="confirmedDiv">�m�F�敪</param>
		/// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
		/// <param name="totalDay">����(DD)</param>
		/// <param name="dtlRelationGuid">���׊֘A�t��GUID</param>
		/// <param name="acptAnOdrRemainCnt">�󒍎c��(�󒍐��ʁ{�󒍒������|�o�א�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="resultsAddUpSecNm">���ьv�㋒�_����</param>
		/// <param name="outputName">��������</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <returns>SalesTemp�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTemp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesTemp(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 acptAnOdrStatus,string sectionCode,Int32 subSectionCode,Int32 minSectionCode,Int32 debitNoteDiv,Int32 debitNLnkAcptAnOdr,Int32 salesSlipCd,Int32 accRecDivCd,string salesInpSecCd,string demandAddUpSecCd,string resultsAddUpSecCd,string updateSecCd,DateTime searchSlipDate,DateTime shipmentDay,DateTime salesDate,DateTime addUpADate,Int32 delayPaymentDiv,Int32 claimCode,string claimSnm,Int32 customerCode,string customerName,string customerName2,string customerSnm,string honorificTitle,Int32 outputNameCode,Int32 businessTypeCode,string businessTypeName,Int32 salesAreaCode,string salesAreaName,string salesInputCode,string salesInputName,string frontEmployeeCd,string frontEmployeeNm,string salesEmployeeCd,string salesEmployeeNm,Int32 consTaxLayMethod,Double consTaxRate,Int32 fractionProcCd,Int32 autoDepositCd,Int32 autoDepoSlipNum,Int32 slipAddressDiv,Int32 addresseeCode,string addresseeName,string addresseeName2,string addresseePostNo,string addresseeAddr1,Int32 addresseeAddr2,string addresseeAddr3,string addresseeAddr4,string addresseeTelNo,string addresseeFaxNo,string partySaleSlipNum,string slipNote,string slipNote2,Int32 retGoodsReasonDiv,string retGoodsReason,Int32 detailRowCount,Int32 deliveredGoodsDiv,string deliveredGoodsDivNm,Int32 reconcileFlag,string slipPrtSetPaperId,Int32 completeCd,Int32 claimType,Int32 salesPriceFracProcCd,Int32 listPricePrintDiv,Int32 eraNameDispCd1,Int32 acceptAnOrderNo,Int64 commonSeqNo,Int64 salesSlipDtlNum,Int32 acptAnOdrStatusSrc,Int64 salesSlipDtlNumSrc,Int32 supplierFormalSync,Int64 stockSlipDtlNumSync,Int32 salesSlipCdDtl,string orderNumber,Int32 stockMngExistCd,DateTime deliGdsCmpltDueDate,Int32 goodsKindCode,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,string goodsShortName,Int32 goodsSetDivCd,string largeGoodsGanreCode,string largeGoodsGanreName,string mediumGoodsGanreCode,string mediumGoodsGanreName,string detailGoodsGanreCode,string detailGoodsGanreName,Int32 bLGoodsCode,string bLGoodsFullName,Int32 enterpriseGanreCode,string enterpriseGanreName,string warehouseCode,string warehouseName,string warehouseShelfNo,Int32 salesOrderDivCd,Int32 openPriceDiv,Int32 unitCode,string unitName,string goodsRateRank,Int32 custRateGrpCode,Int32 suppRateGrpCode,Double listPriceRate,string rateSectPriceUnPrc,string rateDivLPrice,Int32 unPrcCalcCdLPrice,Int32 priceCdLPrice,Double stdUnPrcLPrice,Double fracProcUnitLPrice,Int32 fracProcLPrice,Double listPriceTaxIncFl,Double listPriceTaxExcFl,Int32 listPriceChngCd,Double salesRate,string rateSectSalUnPrc,string rateDivSalUnPrc,Int32 unPrcCalcCdSalUnPrc,Int32 priceCdSalUnPrc,Double stdUnPrcSalUnPrc,Double fracProcUnitSalUnPrc,Int32 fracProcSalUnPrc,Double salesUnPrcTaxIncFl,Double salesUnPrcTaxExcFl,Int32 salesUnPrcChngCd,Double costRate,string rateSectCstUnPrc,string rateDivUnCst,Int32 unPrcCalcCdUnCst,Int32 priceCdUnCst,Double stdUnPrcUnCst,Double fracProcUnitUnCst,Int32 fracProcUnCst,Double salesUnitCost,Int32 salesUnitCostChngDiv,Int32 rateBLGoodsCode,string rateBLGoodsName,Int32 bargainCd,string bargainNm,Double shipmentCnt,Int64 salesMoneyTaxInc,Int64 salesMoneyTaxExc,Int64 cost,Int32 grsProfitChkDiv,Int32 salesGoodsCd,Int64 salsePriceConsTax,Int32 taxationDivCd,string partySlipNumDtl,string dtlNote,Int32 supplierCd,string supplierSnm,string slipMemo1,string slipMemo2,string slipMemo3,string slipMemo4,string slipMemo5,string slipMemo6,string insideMemo1,string insideMemo2,string insideMemo3,string insideMemo4,string insideMemo5,string insideMemo6,Double bfListPrice,Double bfSalesUnitPrice,Double bfUnitCost,string prtGoodsNo,string prtGoodsName,Int32 prtGoodsMakerCd,string prtGoodsMakerNm,Int32 supplierSlipCd,Int32 totalAmountDispWayCd,Int32 ttlAmntDispRateApy,bool confirmedDiv,Int32 nTimeCalcStDate,Int32 totalDay,Guid dtlRelationGuid,Double acptAnOdrRemainCnt,string enterpriseName,string updEmployeeName,string resultsAddUpSecNm,string outputName,string bLGoodsName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._sectionCode = sectionCode;
			this._subSectionCode = subSectionCode;
			this._minSectionCode = minSectionCode;
			this._debitNoteDiv = debitNoteDiv;
			this._debitNLnkAcptAnOdr = debitNLnkAcptAnOdr;
			this._salesSlipCd = salesSlipCd;
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
			this._claimCode = claimCode;
			this._claimSnm = claimSnm;
			this._customerCode = customerCode;
			this._customerName = customerName;
			this._customerName2 = customerName2;
			this._customerSnm = customerSnm;
			this._honorificTitle = honorificTitle;
			this._outputNameCode = outputNameCode;
			this._businessTypeCode = businessTypeCode;
			this._businessTypeName = businessTypeName;
			this._salesAreaCode = salesAreaCode;
			this._salesAreaName = salesAreaName;
			this._salesInputCode = salesInputCode;
			this._salesInputName = salesInputName;
			this._frontEmployeeCd = frontEmployeeCd;
			this._frontEmployeeNm = frontEmployeeNm;
			this._salesEmployeeCd = salesEmployeeCd;
			this._salesEmployeeNm = salesEmployeeNm;
			this._consTaxLayMethod = consTaxLayMethod;
			this._consTaxRate = consTaxRate;
			this._fractionProcCd = fractionProcCd;
			this._autoDepositCd = autoDepositCd;
			this._autoDepoSlipNum = autoDepoSlipNum;
			this._slipAddressDiv = slipAddressDiv;
			this._addresseeCode = addresseeCode;
			this._addresseeName = addresseeName;
			this._addresseeName2 = addresseeName2;
			this._addresseePostNo = addresseePostNo;
			this._addresseeAddr1 = addresseeAddr1;
			this._addresseeAddr2 = addresseeAddr2;
			this._addresseeAddr3 = addresseeAddr3;
			this._addresseeAddr4 = addresseeAddr4;
			this._addresseeTelNo = addresseeTelNo;
			this._addresseeFaxNo = addresseeFaxNo;
			this._partySaleSlipNum = partySaleSlipNum;
			this._slipNote = slipNote;
			this._slipNote2 = slipNote2;
			this._retGoodsReasonDiv = retGoodsReasonDiv;
			this._retGoodsReason = retGoodsReason;
			this._detailRowCount = detailRowCount;
			this._deliveredGoodsDiv = deliveredGoodsDiv;
			this._deliveredGoodsDivNm = deliveredGoodsDivNm;
			this._reconcileFlag = reconcileFlag;
			this._slipPrtSetPaperId = slipPrtSetPaperId;
			this._completeCd = completeCd;
			this._claimType = claimType;
			this._salesPriceFracProcCd = salesPriceFracProcCd;
			this._listPricePrintDiv = listPricePrintDiv;
			this._eraNameDispCd1 = eraNameDispCd1;
			this._acceptAnOrderNo = acceptAnOrderNo;
			this._commonSeqNo = commonSeqNo;
			this._salesSlipDtlNum = salesSlipDtlNum;
			this._acptAnOdrStatusSrc = acptAnOdrStatusSrc;
			this._salesSlipDtlNumSrc = salesSlipDtlNumSrc;
			this._supplierFormalSync = supplierFormalSync;
			this._stockSlipDtlNumSync = stockSlipDtlNumSync;
			this._salesSlipCdDtl = salesSlipCdDtl;
			this._orderNumber = orderNumber;
			this._stockMngExistCd = stockMngExistCd;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._goodsKindCode = goodsKindCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._goodsShortName = goodsShortName;
			this._goodsSetDivCd = goodsSetDivCd;
			this._largeGoodsGanreCode = largeGoodsGanreCode;
			this._largeGoodsGanreName = largeGoodsGanreName;
			this._mediumGoodsGanreCode = mediumGoodsGanreCode;
			this._mediumGoodsGanreName = mediumGoodsGanreName;
			this._detailGoodsGanreCode = detailGoodsGanreCode;
			this._detailGoodsGanreName = detailGoodsGanreName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._salesOrderDivCd = salesOrderDivCd;
			this._openPriceDiv = openPriceDiv;
			this._unitCode = unitCode;
			this._unitName = unitName;
			this._goodsRateRank = goodsRateRank;
			this._custRateGrpCode = custRateGrpCode;
			this._suppRateGrpCode = suppRateGrpCode;
			this._listPriceRate = listPriceRate;
			this._rateSectPriceUnPrc = rateSectPriceUnPrc;
			this._rateDivLPrice = rateDivLPrice;
			this._unPrcCalcCdLPrice = unPrcCalcCdLPrice;
			this._priceCdLPrice = priceCdLPrice;
			this._stdUnPrcLPrice = stdUnPrcLPrice;
			this._fracProcUnitLPrice = fracProcUnitLPrice;
			this._fracProcLPrice = fracProcLPrice;
			this._listPriceTaxIncFl = listPriceTaxIncFl;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._listPriceChngCd = listPriceChngCd;
			this._salesRate = salesRate;
			this._rateSectSalUnPrc = rateSectSalUnPrc;
			this._rateDivSalUnPrc = rateDivSalUnPrc;
			this._unPrcCalcCdSalUnPrc = unPrcCalcCdSalUnPrc;
			this._priceCdSalUnPrc = priceCdSalUnPrc;
			this._stdUnPrcSalUnPrc = stdUnPrcSalUnPrc;
			this._fracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
			this._fracProcSalUnPrc = fracProcSalUnPrc;
			this._salesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
			this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			this._salesUnPrcChngCd = salesUnPrcChngCd;
			this._costRate = costRate;
			this._rateSectCstUnPrc = rateSectCstUnPrc;
			this._rateDivUnCst = rateDivUnCst;
			this._unPrcCalcCdUnCst = unPrcCalcCdUnCst;
			this._priceCdUnCst = priceCdUnCst;
			this._stdUnPrcUnCst = stdUnPrcUnCst;
			this._fracProcUnitUnCst = fracProcUnitUnCst;
			this._fracProcUnCst = fracProcUnCst;
			this._salesUnitCost = salesUnitCost;
			this._salesUnitCostChngDiv = salesUnitCostChngDiv;
			this._rateBLGoodsCode = rateBLGoodsCode;
			this._rateBLGoodsName = rateBLGoodsName;
			this._bargainCd = bargainCd;
			this._bargainNm = bargainNm;
			this._shipmentCnt = shipmentCnt;
			this._salesMoneyTaxInc = salesMoneyTaxInc;
			this._salesMoneyTaxExc = salesMoneyTaxExc;
			this._cost = cost;
			this._grsProfitChkDiv = grsProfitChkDiv;
			this._salesGoodsCd = salesGoodsCd;
			this._salsePriceConsTax = salsePriceConsTax;
			this._taxationDivCd = taxationDivCd;
			this._partySlipNumDtl = partySlipNumDtl;
			this._dtlNote = dtlNote;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._slipMemo1 = slipMemo1;
			this._slipMemo2 = slipMemo2;
			this._slipMemo3 = slipMemo3;
			this._slipMemo4 = slipMemo4;
			this._slipMemo5 = slipMemo5;
			this._slipMemo6 = slipMemo6;
			this._insideMemo1 = insideMemo1;
			this._insideMemo2 = insideMemo2;
			this._insideMemo3 = insideMemo3;
			this._insideMemo4 = insideMemo4;
			this._insideMemo5 = insideMemo5;
			this._insideMemo6 = insideMemo6;
			this._bfListPrice = bfListPrice;
			this._bfSalesUnitPrice = bfSalesUnitPrice;
			this._bfUnitCost = bfUnitCost;
			this._prtGoodsNo = prtGoodsNo;
			this._prtGoodsName = prtGoodsName;
			this._prtGoodsMakerCd = prtGoodsMakerCd;
			this._prtGoodsMakerNm = prtGoodsMakerNm;
			this._supplierSlipCd = supplierSlipCd;
			this._totalAmountDispWayCd = totalAmountDispWayCd;
			this._ttlAmntDispRateApy = ttlAmntDispRateApy;
			this._confirmedDiv = confirmedDiv;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._totalDay = totalDay;
			this._dtlRelationGuid = dtlRelationGuid;
			this._acptAnOdrRemainCnt = acptAnOdrRemainCnt;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._resultsAddUpSecNm = resultsAddUpSecNm;
			this._outputName = outputName;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// ����f�[�^�i�d�������v��j��������
		/// </summary>
		/// <returns>SalesTemp�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesTemp�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesTemp Clone()
		{
			return new SalesTemp(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._acptAnOdrStatus,this._sectionCode,this._subSectionCode,this._minSectionCode,this._debitNoteDiv,this._debitNLnkAcptAnOdr,this._salesSlipCd,this._accRecDivCd,this._salesInpSecCd,this._demandAddUpSecCd,this._resultsAddUpSecCd,this._updateSecCd,this._searchSlipDate,this._shipmentDay,this._salesDate,this._addUpADate,this._delayPaymentDiv,this._claimCode,this._claimSnm,this._customerCode,this._customerName,this._customerName2,this._customerSnm,this._honorificTitle,this._outputNameCode,this._businessTypeCode,this._businessTypeName,this._salesAreaCode,this._salesAreaName,this._salesInputCode,this._salesInputName,this._frontEmployeeCd,this._frontEmployeeNm,this._salesEmployeeCd,this._salesEmployeeNm,this._consTaxLayMethod,this._consTaxRate,this._fractionProcCd,this._autoDepositCd,this._autoDepoSlipNum,this._slipAddressDiv,this._addresseeCode,this._addresseeName,this._addresseeName2,this._addresseePostNo,this._addresseeAddr1,this._addresseeAddr2,this._addresseeAddr3,this._addresseeAddr4,this._addresseeTelNo,this._addresseeFaxNo,this._partySaleSlipNum,this._slipNote,this._slipNote2,this._retGoodsReasonDiv,this._retGoodsReason,this._detailRowCount,this._deliveredGoodsDiv,this._deliveredGoodsDivNm,this._reconcileFlag,this._slipPrtSetPaperId,this._completeCd,this._claimType,this._salesPriceFracProcCd,this._listPricePrintDiv,this._eraNameDispCd1,this._acceptAnOrderNo,this._commonSeqNo,this._salesSlipDtlNum,this._acptAnOdrStatusSrc,this._salesSlipDtlNumSrc,this._supplierFormalSync,this._stockSlipDtlNumSync,this._salesSlipCdDtl,this._orderNumber,this._stockMngExistCd,this._deliGdsCmpltDueDate,this._goodsKindCode,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._goodsShortName,this._goodsSetDivCd,this._largeGoodsGanreCode,this._largeGoodsGanreName,this._mediumGoodsGanreCode,this._mediumGoodsGanreName,this._detailGoodsGanreCode,this._detailGoodsGanreName,this._bLGoodsCode,this._bLGoodsFullName,this._enterpriseGanreCode,this._enterpriseGanreName,this._warehouseCode,this._warehouseName,this._warehouseShelfNo,this._salesOrderDivCd,this._openPriceDiv,this._unitCode,this._unitName,this._goodsRateRank,this._custRateGrpCode,this._suppRateGrpCode,this._listPriceRate,this._rateSectPriceUnPrc,this._rateDivLPrice,this._unPrcCalcCdLPrice,this._priceCdLPrice,this._stdUnPrcLPrice,this._fracProcUnitLPrice,this._fracProcLPrice,this._listPriceTaxIncFl,this._listPriceTaxExcFl,this._listPriceChngCd,this._salesRate,this._rateSectSalUnPrc,this._rateDivSalUnPrc,this._unPrcCalcCdSalUnPrc,this._priceCdSalUnPrc,this._stdUnPrcSalUnPrc,this._fracProcUnitSalUnPrc,this._fracProcSalUnPrc,this._salesUnPrcTaxIncFl,this._salesUnPrcTaxExcFl,this._salesUnPrcChngCd,this._costRate,this._rateSectCstUnPrc,this._rateDivUnCst,this._unPrcCalcCdUnCst,this._priceCdUnCst,this._stdUnPrcUnCst,this._fracProcUnitUnCst,this._fracProcUnCst,this._salesUnitCost,this._salesUnitCostChngDiv,this._rateBLGoodsCode,this._rateBLGoodsName,this._bargainCd,this._bargainNm,this._shipmentCnt,this._salesMoneyTaxInc,this._salesMoneyTaxExc,this._cost,this._grsProfitChkDiv,this._salesGoodsCd,this._salsePriceConsTax,this._taxationDivCd,this._partySlipNumDtl,this._dtlNote,this._supplierCd,this._supplierSnm,this._slipMemo1,this._slipMemo2,this._slipMemo3,this._slipMemo4,this._slipMemo5,this._slipMemo6,this._insideMemo1,this._insideMemo2,this._insideMemo3,this._insideMemo4,this._insideMemo5,this._insideMemo6,this._bfListPrice,this._bfSalesUnitPrice,this._bfUnitCost,this._prtGoodsNo,this._prtGoodsName,this._prtGoodsMakerCd,this._prtGoodsMakerNm,this._supplierSlipCd,this._totalAmountDispWayCd,this._ttlAmntDispRateApy,this._confirmedDiv,this._nTimeCalcStDate,this._totalDay,this._dtlRelationGuid,this._acptAnOdrRemainCnt,this._enterpriseName,this._updEmployeeName,this._resultsAddUpSecNm,this._outputName,this._bLGoodsName);
		}

		/// <summary>
		/// ����f�[�^�i�d�������v��j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesTemp�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTemp�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SalesTemp target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.MinSectionCode == target.MinSectionCode)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.DebitNLnkAcptAnOdr == target.DebitNLnkAcptAnOdr)
				 && (this.SalesSlipCd == target.SalesSlipCd)
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
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.ClaimSnm == target.ClaimSnm)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerName == target.CustomerName)
				 && (this.CustomerName2 == target.CustomerName2)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.HonorificTitle == target.HonorificTitle)
				 && (this.OutputNameCode == target.OutputNameCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.BusinessTypeName == target.BusinessTypeName)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.SalesAreaName == target.SalesAreaName)
				 && (this.SalesInputCode == target.SalesInputCode)
				 && (this.SalesInputName == target.SalesInputName)
				 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
				 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
				 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
				 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
				 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				 && (this.ConsTaxRate == target.ConsTaxRate)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.AutoDepositCd == target.AutoDepositCd)
				 && (this.AutoDepoSlipNum == target.AutoDepoSlipNum)
				 && (this.SlipAddressDiv == target.SlipAddressDiv)
				 && (this.AddresseeCode == target.AddresseeCode)
				 && (this.AddresseeName == target.AddresseeName)
				 && (this.AddresseeName2 == target.AddresseeName2)
				 && (this.AddresseePostNo == target.AddresseePostNo)
				 && (this.AddresseeAddr1 == target.AddresseeAddr1)
				 && (this.AddresseeAddr2 == target.AddresseeAddr2)
				 && (this.AddresseeAddr3 == target.AddresseeAddr3)
				 && (this.AddresseeAddr4 == target.AddresseeAddr4)
				 && (this.AddresseeTelNo == target.AddresseeTelNo)
				 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
				 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
				 && (this.SlipNote == target.SlipNote)
				 && (this.SlipNote2 == target.SlipNote2)
				 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
				 && (this.RetGoodsReason == target.RetGoodsReason)
				 && (this.DetailRowCount == target.DetailRowCount)
				 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
				 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
				 && (this.ReconcileFlag == target.ReconcileFlag)
				 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
				 && (this.CompleteCd == target.CompleteCd)
				 && (this.ClaimType == target.ClaimType)
				 && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
				 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
				 && (this.EraNameDispCd1 == target.EraNameDispCd1)
				 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
				 && (this.CommonSeqNo == target.CommonSeqNo)
				 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
				 && (this.AcptAnOdrStatusSrc == target.AcptAnOdrStatusSrc)
				 && (this.SalesSlipDtlNumSrc == target.SalesSlipDtlNumSrc)
				 && (this.SupplierFormalSync == target.SupplierFormalSync)
				 && (this.StockSlipDtlNumSync == target.StockSlipDtlNumSync)
				 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
				 && (this.OrderNumber == target.OrderNumber)
				 && (this.StockMngExistCd == target.StockMngExistCd)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsShortName == target.GoodsShortName)
				 && (this.GoodsSetDivCd == target.GoodsSetDivCd)
				 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
				 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
				 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
				 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
				 && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
				 && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.UnitCode == target.UnitCode)
				 && (this.UnitName == target.UnitName)
				 && (this.GoodsRateRank == target.GoodsRateRank)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
				 && (this.ListPriceRate == target.ListPriceRate)
				 && (this.RateSectPriceUnPrc == target.RateSectPriceUnPrc)
				 && (this.RateDivLPrice == target.RateDivLPrice)
				 && (this.UnPrcCalcCdLPrice == target.UnPrcCalcCdLPrice)
				 && (this.PriceCdLPrice == target.PriceCdLPrice)
				 && (this.StdUnPrcLPrice == target.StdUnPrcLPrice)
				 && (this.FracProcUnitLPrice == target.FracProcUnitLPrice)
				 && (this.FracProcLPrice == target.FracProcLPrice)
				 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.ListPriceChngCd == target.ListPriceChngCd)
				 && (this.SalesRate == target.SalesRate)
				 && (this.RateSectSalUnPrc == target.RateSectSalUnPrc)
				 && (this.RateDivSalUnPrc == target.RateDivSalUnPrc)
				 && (this.UnPrcCalcCdSalUnPrc == target.UnPrcCalcCdSalUnPrc)
				 && (this.PriceCdSalUnPrc == target.PriceCdSalUnPrc)
				 && (this.StdUnPrcSalUnPrc == target.StdUnPrcSalUnPrc)
				 && (this.FracProcUnitSalUnPrc == target.FracProcUnitSalUnPrc)
				 && (this.FracProcSalUnPrc == target.FracProcSalUnPrc)
				 && (this.SalesUnPrcTaxIncFl == target.SalesUnPrcTaxIncFl)
				 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
				 && (this.SalesUnPrcChngCd == target.SalesUnPrcChngCd)
				 && (this.CostRate == target.CostRate)
				 && (this.RateSectCstUnPrc == target.RateSectCstUnPrc)
				 && (this.RateDivUnCst == target.RateDivUnCst)
				 && (this.UnPrcCalcCdUnCst == target.UnPrcCalcCdUnCst)
				 && (this.PriceCdUnCst == target.PriceCdUnCst)
				 && (this.StdUnPrcUnCst == target.StdUnPrcUnCst)
				 && (this.FracProcUnitUnCst == target.FracProcUnitUnCst)
				 && (this.FracProcUnCst == target.FracProcUnCst)
				 && (this.SalesUnitCost == target.SalesUnitCost)
				 && (this.SalesUnitCostChngDiv == target.SalesUnitCostChngDiv)
				 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
				 && (this.RateBLGoodsName == target.RateBLGoodsName)
				 && (this.BargainCd == target.BargainCd)
				 && (this.BargainNm == target.BargainNm)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.SalesMoneyTaxInc == target.SalesMoneyTaxInc)
				 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
				 && (this.Cost == target.Cost)
				 && (this.GrsProfitChkDiv == target.GrsProfitChkDiv)
				 && (this.SalesGoodsCd == target.SalesGoodsCd)
				 && (this.SalsePriceConsTax == target.SalsePriceConsTax)
				 && (this.TaxationDivCd == target.TaxationDivCd)
				 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
				 && (this.DtlNote == target.DtlNote)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.SlipMemo1 == target.SlipMemo1)
				 && (this.SlipMemo2 == target.SlipMemo2)
				 && (this.SlipMemo3 == target.SlipMemo3)
				 && (this.SlipMemo4 == target.SlipMemo4)
				 && (this.SlipMemo5 == target.SlipMemo5)
				 && (this.SlipMemo6 == target.SlipMemo6)
				 && (this.InsideMemo1 == target.InsideMemo1)
				 && (this.InsideMemo2 == target.InsideMemo2)
				 && (this.InsideMemo3 == target.InsideMemo3)
				 && (this.InsideMemo4 == target.InsideMemo4)
				 && (this.InsideMemo5 == target.InsideMemo5)
				 && (this.InsideMemo6 == target.InsideMemo6)
				 && (this.BfListPrice == target.BfListPrice)
				 && (this.BfSalesUnitPrice == target.BfSalesUnitPrice)
				 && (this.BfUnitCost == target.BfUnitCost)
				 && (this.PrtGoodsNo == target.PrtGoodsNo)
				 && (this.PrtGoodsName == target.PrtGoodsName)
				 && (this.PrtGoodsMakerCd == target.PrtGoodsMakerCd)
				 && (this.PrtGoodsMakerNm == target.PrtGoodsMakerNm)
				 && (this.SupplierSlipCd == target.SupplierSlipCd)
				 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
				 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
				 && (this.ConfirmedDiv == target.ConfirmedDiv)
				 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
				 && (this.TotalDay == target.TotalDay)
				 && (this.DtlRelationGuid == target.DtlRelationGuid)
				 && (this.AcptAnOdrRemainCnt == target.AcptAnOdrRemainCnt)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm)
				 && (this.OutputName == target.OutputName)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// ����f�[�^�i�d�������v��j��r����
		/// </summary>
		/// <param name="salesTemp1">
		///                    ��r����SalesTemp�N���X�̃C���X�^���X
		/// </param>
		/// <param name="salesTemp2">��r����SalesTemp�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTemp�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SalesTemp salesTemp1, SalesTemp salesTemp2)
		{
			return ((salesTemp1.CreateDateTime == salesTemp2.CreateDateTime)
				 && (salesTemp1.UpdateDateTime == salesTemp2.UpdateDateTime)
				 && (salesTemp1.EnterpriseCode == salesTemp2.EnterpriseCode)
				 && (salesTemp1.FileHeaderGuid == salesTemp2.FileHeaderGuid)
				 && (salesTemp1.UpdEmployeeCode == salesTemp2.UpdEmployeeCode)
				 && (salesTemp1.UpdAssemblyId1 == salesTemp2.UpdAssemblyId1)
				 && (salesTemp1.UpdAssemblyId2 == salesTemp2.UpdAssemblyId2)
				 && (salesTemp1.LogicalDeleteCode == salesTemp2.LogicalDeleteCode)
				 && (salesTemp1.AcptAnOdrStatus == salesTemp2.AcptAnOdrStatus)
				 && (salesTemp1.SectionCode == salesTemp2.SectionCode)
				 && (salesTemp1.SubSectionCode == salesTemp2.SubSectionCode)
				 && (salesTemp1.MinSectionCode == salesTemp2.MinSectionCode)
				 && (salesTemp1.DebitNoteDiv == salesTemp2.DebitNoteDiv)
				 && (salesTemp1.DebitNLnkAcptAnOdr == salesTemp2.DebitNLnkAcptAnOdr)
				 && (salesTemp1.SalesSlipCd == salesTemp2.SalesSlipCd)
				 && (salesTemp1.AccRecDivCd == salesTemp2.AccRecDivCd)
				 && (salesTemp1.SalesInpSecCd == salesTemp2.SalesInpSecCd)
				 && (salesTemp1.DemandAddUpSecCd == salesTemp2.DemandAddUpSecCd)
				 && (salesTemp1.ResultsAddUpSecCd == salesTemp2.ResultsAddUpSecCd)
				 && (salesTemp1.UpdateSecCd == salesTemp2.UpdateSecCd)
				 && (salesTemp1.SearchSlipDate == salesTemp2.SearchSlipDate)
				 && (salesTemp1.ShipmentDay == salesTemp2.ShipmentDay)
				 && (salesTemp1.SalesDate == salesTemp2.SalesDate)
				 && (salesTemp1.AddUpADate == salesTemp2.AddUpADate)
				 && (salesTemp1.DelayPaymentDiv == salesTemp2.DelayPaymentDiv)
				 && (salesTemp1.ClaimCode == salesTemp2.ClaimCode)
				 && (salesTemp1.ClaimSnm == salesTemp2.ClaimSnm)
				 && (salesTemp1.CustomerCode == salesTemp2.CustomerCode)
				 && (salesTemp1.CustomerName == salesTemp2.CustomerName)
				 && (salesTemp1.CustomerName2 == salesTemp2.CustomerName2)
				 && (salesTemp1.CustomerSnm == salesTemp2.CustomerSnm)
				 && (salesTemp1.HonorificTitle == salesTemp2.HonorificTitle)
				 && (salesTemp1.OutputNameCode == salesTemp2.OutputNameCode)
				 && (salesTemp1.BusinessTypeCode == salesTemp2.BusinessTypeCode)
				 && (salesTemp1.BusinessTypeName == salesTemp2.BusinessTypeName)
				 && (salesTemp1.SalesAreaCode == salesTemp2.SalesAreaCode)
				 && (salesTemp1.SalesAreaName == salesTemp2.SalesAreaName)
				 && (salesTemp1.SalesInputCode == salesTemp2.SalesInputCode)
				 && (salesTemp1.SalesInputName == salesTemp2.SalesInputName)
				 && (salesTemp1.FrontEmployeeCd == salesTemp2.FrontEmployeeCd)
				 && (salesTemp1.FrontEmployeeNm == salesTemp2.FrontEmployeeNm)
				 && (salesTemp1.SalesEmployeeCd == salesTemp2.SalesEmployeeCd)
				 && (salesTemp1.SalesEmployeeNm == salesTemp2.SalesEmployeeNm)
				 && (salesTemp1.ConsTaxLayMethod == salesTemp2.ConsTaxLayMethod)
				 && (salesTemp1.ConsTaxRate == salesTemp2.ConsTaxRate)
				 && (salesTemp1.FractionProcCd == salesTemp2.FractionProcCd)
				 && (salesTemp1.AutoDepositCd == salesTemp2.AutoDepositCd)
				 && (salesTemp1.AutoDepoSlipNum == salesTemp2.AutoDepoSlipNum)
				 && (salesTemp1.SlipAddressDiv == salesTemp2.SlipAddressDiv)
				 && (salesTemp1.AddresseeCode == salesTemp2.AddresseeCode)
				 && (salesTemp1.AddresseeName == salesTemp2.AddresseeName)
				 && (salesTemp1.AddresseeName2 == salesTemp2.AddresseeName2)
				 && (salesTemp1.AddresseePostNo == salesTemp2.AddresseePostNo)
				 && (salesTemp1.AddresseeAddr1 == salesTemp2.AddresseeAddr1)
				 && (salesTemp1.AddresseeAddr2 == salesTemp2.AddresseeAddr2)
				 && (salesTemp1.AddresseeAddr3 == salesTemp2.AddresseeAddr3)
				 && (salesTemp1.AddresseeAddr4 == salesTemp2.AddresseeAddr4)
				 && (salesTemp1.AddresseeTelNo == salesTemp2.AddresseeTelNo)
				 && (salesTemp1.AddresseeFaxNo == salesTemp2.AddresseeFaxNo)
				 && (salesTemp1.PartySaleSlipNum == salesTemp2.PartySaleSlipNum)
				 && (salesTemp1.SlipNote == salesTemp2.SlipNote)
				 && (salesTemp1.SlipNote2 == salesTemp2.SlipNote2)
				 && (salesTemp1.RetGoodsReasonDiv == salesTemp2.RetGoodsReasonDiv)
				 && (salesTemp1.RetGoodsReason == salesTemp2.RetGoodsReason)
				 && (salesTemp1.DetailRowCount == salesTemp2.DetailRowCount)
				 && (salesTemp1.DeliveredGoodsDiv == salesTemp2.DeliveredGoodsDiv)
				 && (salesTemp1.DeliveredGoodsDivNm == salesTemp2.DeliveredGoodsDivNm)
				 && (salesTemp1.ReconcileFlag == salesTemp2.ReconcileFlag)
				 && (salesTemp1.SlipPrtSetPaperId == salesTemp2.SlipPrtSetPaperId)
				 && (salesTemp1.CompleteCd == salesTemp2.CompleteCd)
				 && (salesTemp1.ClaimType == salesTemp2.ClaimType)
				 && (salesTemp1.SalesPriceFracProcCd == salesTemp2.SalesPriceFracProcCd)
				 && (salesTemp1.ListPricePrintDiv == salesTemp2.ListPricePrintDiv)
				 && (salesTemp1.EraNameDispCd1 == salesTemp2.EraNameDispCd1)
				 && (salesTemp1.AcceptAnOrderNo == salesTemp2.AcceptAnOrderNo)
				 && (salesTemp1.CommonSeqNo == salesTemp2.CommonSeqNo)
				 && (salesTemp1.SalesSlipDtlNum == salesTemp2.SalesSlipDtlNum)
				 && (salesTemp1.AcptAnOdrStatusSrc == salesTemp2.AcptAnOdrStatusSrc)
				 && (salesTemp1.SalesSlipDtlNumSrc == salesTemp2.SalesSlipDtlNumSrc)
				 && (salesTemp1.SupplierFormalSync == salesTemp2.SupplierFormalSync)
				 && (salesTemp1.StockSlipDtlNumSync == salesTemp2.StockSlipDtlNumSync)
				 && (salesTemp1.SalesSlipCdDtl == salesTemp2.SalesSlipCdDtl)
				 && (salesTemp1.OrderNumber == salesTemp2.OrderNumber)
				 && (salesTemp1.StockMngExistCd == salesTemp2.StockMngExistCd)
				 && (salesTemp1.DeliGdsCmpltDueDate == salesTemp2.DeliGdsCmpltDueDate)
				 && (salesTemp1.GoodsKindCode == salesTemp2.GoodsKindCode)
				 && (salesTemp1.GoodsMakerCd == salesTemp2.GoodsMakerCd)
				 && (salesTemp1.MakerName == salesTemp2.MakerName)
				 && (salesTemp1.GoodsNo == salesTemp2.GoodsNo)
				 && (salesTemp1.GoodsName == salesTemp2.GoodsName)
				 && (salesTemp1.GoodsShortName == salesTemp2.GoodsShortName)
				 && (salesTemp1.GoodsSetDivCd == salesTemp2.GoodsSetDivCd)
				 && (salesTemp1.LargeGoodsGanreCode == salesTemp2.LargeGoodsGanreCode)
				 && (salesTemp1.LargeGoodsGanreName == salesTemp2.LargeGoodsGanreName)
				 && (salesTemp1.MediumGoodsGanreCode == salesTemp2.MediumGoodsGanreCode)
				 && (salesTemp1.MediumGoodsGanreName == salesTemp2.MediumGoodsGanreName)
				 && (salesTemp1.DetailGoodsGanreCode == salesTemp2.DetailGoodsGanreCode)
				 && (salesTemp1.DetailGoodsGanreName == salesTemp2.DetailGoodsGanreName)
				 && (salesTemp1.BLGoodsCode == salesTemp2.BLGoodsCode)
				 && (salesTemp1.BLGoodsFullName == salesTemp2.BLGoodsFullName)
				 && (salesTemp1.EnterpriseGanreCode == salesTemp2.EnterpriseGanreCode)
				 && (salesTemp1.EnterpriseGanreName == salesTemp2.EnterpriseGanreName)
				 && (salesTemp1.WarehouseCode == salesTemp2.WarehouseCode)
				 && (salesTemp1.WarehouseName == salesTemp2.WarehouseName)
				 && (salesTemp1.WarehouseShelfNo == salesTemp2.WarehouseShelfNo)
				 && (salesTemp1.SalesOrderDivCd == salesTemp2.SalesOrderDivCd)
				 && (salesTemp1.OpenPriceDiv == salesTemp2.OpenPriceDiv)
				 && (salesTemp1.UnitCode == salesTemp2.UnitCode)
				 && (salesTemp1.UnitName == salesTemp2.UnitName)
				 && (salesTemp1.GoodsRateRank == salesTemp2.GoodsRateRank)
				 && (salesTemp1.CustRateGrpCode == salesTemp2.CustRateGrpCode)
				 && (salesTemp1.SuppRateGrpCode == salesTemp2.SuppRateGrpCode)
				 && (salesTemp1.ListPriceRate == salesTemp2.ListPriceRate)
				 && (salesTemp1.RateSectPriceUnPrc == salesTemp2.RateSectPriceUnPrc)
				 && (salesTemp1.RateDivLPrice == salesTemp2.RateDivLPrice)
				 && (salesTemp1.UnPrcCalcCdLPrice == salesTemp2.UnPrcCalcCdLPrice)
				 && (salesTemp1.PriceCdLPrice == salesTemp2.PriceCdLPrice)
				 && (salesTemp1.StdUnPrcLPrice == salesTemp2.StdUnPrcLPrice)
				 && (salesTemp1.FracProcUnitLPrice == salesTemp2.FracProcUnitLPrice)
				 && (salesTemp1.FracProcLPrice == salesTemp2.FracProcLPrice)
				 && (salesTemp1.ListPriceTaxIncFl == salesTemp2.ListPriceTaxIncFl)
				 && (salesTemp1.ListPriceTaxExcFl == salesTemp2.ListPriceTaxExcFl)
				 && (salesTemp1.ListPriceChngCd == salesTemp2.ListPriceChngCd)
				 && (salesTemp1.SalesRate == salesTemp2.SalesRate)
				 && (salesTemp1.RateSectSalUnPrc == salesTemp2.RateSectSalUnPrc)
				 && (salesTemp1.RateDivSalUnPrc == salesTemp2.RateDivSalUnPrc)
				 && (salesTemp1.UnPrcCalcCdSalUnPrc == salesTemp2.UnPrcCalcCdSalUnPrc)
				 && (salesTemp1.PriceCdSalUnPrc == salesTemp2.PriceCdSalUnPrc)
				 && (salesTemp1.StdUnPrcSalUnPrc == salesTemp2.StdUnPrcSalUnPrc)
				 && (salesTemp1.FracProcUnitSalUnPrc == salesTemp2.FracProcUnitSalUnPrc)
				 && (salesTemp1.FracProcSalUnPrc == salesTemp2.FracProcSalUnPrc)
				 && (salesTemp1.SalesUnPrcTaxIncFl == salesTemp2.SalesUnPrcTaxIncFl)
				 && (salesTemp1.SalesUnPrcTaxExcFl == salesTemp2.SalesUnPrcTaxExcFl)
				 && (salesTemp1.SalesUnPrcChngCd == salesTemp2.SalesUnPrcChngCd)
				 && (salesTemp1.CostRate == salesTemp2.CostRate)
				 && (salesTemp1.RateSectCstUnPrc == salesTemp2.RateSectCstUnPrc)
				 && (salesTemp1.RateDivUnCst == salesTemp2.RateDivUnCst)
				 && (salesTemp1.UnPrcCalcCdUnCst == salesTemp2.UnPrcCalcCdUnCst)
				 && (salesTemp1.PriceCdUnCst == salesTemp2.PriceCdUnCst)
				 && (salesTemp1.StdUnPrcUnCst == salesTemp2.StdUnPrcUnCst)
				 && (salesTemp1.FracProcUnitUnCst == salesTemp2.FracProcUnitUnCst)
				 && (salesTemp1.FracProcUnCst == salesTemp2.FracProcUnCst)
				 && (salesTemp1.SalesUnitCost == salesTemp2.SalesUnitCost)
				 && (salesTemp1.SalesUnitCostChngDiv == salesTemp2.SalesUnitCostChngDiv)
				 && (salesTemp1.RateBLGoodsCode == salesTemp2.RateBLGoodsCode)
				 && (salesTemp1.RateBLGoodsName == salesTemp2.RateBLGoodsName)
				 && (salesTemp1.BargainCd == salesTemp2.BargainCd)
				 && (salesTemp1.BargainNm == salesTemp2.BargainNm)
				 && (salesTemp1.ShipmentCnt == salesTemp2.ShipmentCnt)
				 && (salesTemp1.SalesMoneyTaxInc == salesTemp2.SalesMoneyTaxInc)
				 && (salesTemp1.SalesMoneyTaxExc == salesTemp2.SalesMoneyTaxExc)
				 && (salesTemp1.Cost == salesTemp2.Cost)
				 && (salesTemp1.GrsProfitChkDiv == salesTemp2.GrsProfitChkDiv)
				 && (salesTemp1.SalesGoodsCd == salesTemp2.SalesGoodsCd)
				 && (salesTemp1.SalsePriceConsTax == salesTemp2.SalsePriceConsTax)
				 && (salesTemp1.TaxationDivCd == salesTemp2.TaxationDivCd)
				 && (salesTemp1.PartySlipNumDtl == salesTemp2.PartySlipNumDtl)
				 && (salesTemp1.DtlNote == salesTemp2.DtlNote)
				 && (salesTemp1.SupplierCd == salesTemp2.SupplierCd)
				 && (salesTemp1.SupplierSnm == salesTemp2.SupplierSnm)
				 && (salesTemp1.SlipMemo1 == salesTemp2.SlipMemo1)
				 && (salesTemp1.SlipMemo2 == salesTemp2.SlipMemo2)
				 && (salesTemp1.SlipMemo3 == salesTemp2.SlipMemo3)
				 && (salesTemp1.SlipMemo4 == salesTemp2.SlipMemo4)
				 && (salesTemp1.SlipMemo5 == salesTemp2.SlipMemo5)
				 && (salesTemp1.SlipMemo6 == salesTemp2.SlipMemo6)
				 && (salesTemp1.InsideMemo1 == salesTemp2.InsideMemo1)
				 && (salesTemp1.InsideMemo2 == salesTemp2.InsideMemo2)
				 && (salesTemp1.InsideMemo3 == salesTemp2.InsideMemo3)
				 && (salesTemp1.InsideMemo4 == salesTemp2.InsideMemo4)
				 && (salesTemp1.InsideMemo5 == salesTemp2.InsideMemo5)
				 && (salesTemp1.InsideMemo6 == salesTemp2.InsideMemo6)
				 && (salesTemp1.BfListPrice == salesTemp2.BfListPrice)
				 && (salesTemp1.BfSalesUnitPrice == salesTemp2.BfSalesUnitPrice)
				 && (salesTemp1.BfUnitCost == salesTemp2.BfUnitCost)
				 && (salesTemp1.PrtGoodsNo == salesTemp2.PrtGoodsNo)
				 && (salesTemp1.PrtGoodsName == salesTemp2.PrtGoodsName)
				 && (salesTemp1.PrtGoodsMakerCd == salesTemp2.PrtGoodsMakerCd)
				 && (salesTemp1.PrtGoodsMakerNm == salesTemp2.PrtGoodsMakerNm)
				 && (salesTemp1.SupplierSlipCd == salesTemp2.SupplierSlipCd)
				 && (salesTemp1.TotalAmountDispWayCd == salesTemp2.TotalAmountDispWayCd)
				 && (salesTemp1.TtlAmntDispRateApy == salesTemp2.TtlAmntDispRateApy)
				 && (salesTemp1.ConfirmedDiv == salesTemp2.ConfirmedDiv)
				 && (salesTemp1.NTimeCalcStDate == salesTemp2.NTimeCalcStDate)
				 && (salesTemp1.TotalDay == salesTemp2.TotalDay)
				 && (salesTemp1.DtlRelationGuid == salesTemp2.DtlRelationGuid)
				 && (salesTemp1.AcptAnOdrRemainCnt == salesTemp2.AcptAnOdrRemainCnt)
				 && (salesTemp1.EnterpriseName == salesTemp2.EnterpriseName)
				 && (salesTemp1.UpdEmployeeName == salesTemp2.UpdEmployeeName)
				 && (salesTemp1.ResultsAddUpSecNm == salesTemp2.ResultsAddUpSecNm)
				 && (salesTemp1.OutputName == salesTemp2.OutputName)
				 && (salesTemp1.BLGoodsName == salesTemp2.BLGoodsName));
		}
		/// <summary>
		/// ����f�[�^�i�d�������v��j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesTemp�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTemp�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SalesTemp target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SubSectionCode != target.SubSectionCode)resList.Add("SubSectionCode");
			if(this.MinSectionCode != target.MinSectionCode)resList.Add("MinSectionCode");
			if(this.DebitNoteDiv != target.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(this.DebitNLnkAcptAnOdr != target.DebitNLnkAcptAnOdr)resList.Add("DebitNLnkAcptAnOdr");
			if(this.SalesSlipCd != target.SalesSlipCd)resList.Add("SalesSlipCd");
			if(this.AccRecDivCd != target.AccRecDivCd)resList.Add("AccRecDivCd");
			if(this.SalesInpSecCd != target.SalesInpSecCd)resList.Add("SalesInpSecCd");
			if(this.DemandAddUpSecCd != target.DemandAddUpSecCd)resList.Add("DemandAddUpSecCd");
			if(this.ResultsAddUpSecCd != target.ResultsAddUpSecCd)resList.Add("ResultsAddUpSecCd");
			if(this.UpdateSecCd != target.UpdateSecCd)resList.Add("UpdateSecCd");
			if(this.SearchSlipDate != target.SearchSlipDate)resList.Add("SearchSlipDate");
			if(this.ShipmentDay != target.ShipmentDay)resList.Add("ShipmentDay");
			if(this.SalesDate != target.SalesDate)resList.Add("SalesDate");
			if(this.AddUpADate != target.AddUpADate)resList.Add("AddUpADate");
			if(this.DelayPaymentDiv != target.DelayPaymentDiv)resList.Add("DelayPaymentDiv");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.ClaimSnm != target.ClaimSnm)resList.Add("ClaimSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerName != target.CustomerName)resList.Add("CustomerName");
			if(this.CustomerName2 != target.CustomerName2)resList.Add("CustomerName2");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.HonorificTitle != target.HonorificTitle)resList.Add("HonorificTitle");
			if(this.OutputNameCode != target.OutputNameCode)resList.Add("OutputNameCode");
			if(this.BusinessTypeCode != target.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(this.BusinessTypeName != target.BusinessTypeName)resList.Add("BusinessTypeName");
			if(this.SalesAreaCode != target.SalesAreaCode)resList.Add("SalesAreaCode");
			if(this.SalesAreaName != target.SalesAreaName)resList.Add("SalesAreaName");
			if(this.SalesInputCode != target.SalesInputCode)resList.Add("SalesInputCode");
			if(this.SalesInputName != target.SalesInputName)resList.Add("SalesInputName");
			if(this.FrontEmployeeCd != target.FrontEmployeeCd)resList.Add("FrontEmployeeCd");
			if(this.FrontEmployeeNm != target.FrontEmployeeNm)resList.Add("FrontEmployeeNm");
			if(this.SalesEmployeeCd != target.SalesEmployeeCd)resList.Add("SalesEmployeeCd");
			if(this.SalesEmployeeNm != target.SalesEmployeeNm)resList.Add("SalesEmployeeNm");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.ConsTaxRate != target.ConsTaxRate)resList.Add("ConsTaxRate");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.AutoDepositCd != target.AutoDepositCd)resList.Add("AutoDepositCd");
			if(this.AutoDepoSlipNum != target.AutoDepoSlipNum)resList.Add("AutoDepoSlipNum");
			if(this.SlipAddressDiv != target.SlipAddressDiv)resList.Add("SlipAddressDiv");
			if(this.AddresseeCode != target.AddresseeCode)resList.Add("AddresseeCode");
			if(this.AddresseeName != target.AddresseeName)resList.Add("AddresseeName");
			if(this.AddresseeName2 != target.AddresseeName2)resList.Add("AddresseeName2");
			if(this.AddresseePostNo != target.AddresseePostNo)resList.Add("AddresseePostNo");
			if(this.AddresseeAddr1 != target.AddresseeAddr1)resList.Add("AddresseeAddr1");
			if(this.AddresseeAddr2 != target.AddresseeAddr2)resList.Add("AddresseeAddr2");
			if(this.AddresseeAddr3 != target.AddresseeAddr3)resList.Add("AddresseeAddr3");
			if(this.AddresseeAddr4 != target.AddresseeAddr4)resList.Add("AddresseeAddr4");
			if(this.AddresseeTelNo != target.AddresseeTelNo)resList.Add("AddresseeTelNo");
			if(this.AddresseeFaxNo != target.AddresseeFaxNo)resList.Add("AddresseeFaxNo");
			if(this.PartySaleSlipNum != target.PartySaleSlipNum)resList.Add("PartySaleSlipNum");
			if(this.SlipNote != target.SlipNote)resList.Add("SlipNote");
			if(this.SlipNote2 != target.SlipNote2)resList.Add("SlipNote2");
			if(this.RetGoodsReasonDiv != target.RetGoodsReasonDiv)resList.Add("RetGoodsReasonDiv");
			if(this.RetGoodsReason != target.RetGoodsReason)resList.Add("RetGoodsReason");
			if(this.DetailRowCount != target.DetailRowCount)resList.Add("DetailRowCount");
			if(this.DeliveredGoodsDiv != target.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm)resList.Add("DeliveredGoodsDivNm");
			if(this.ReconcileFlag != target.ReconcileFlag)resList.Add("ReconcileFlag");
			if(this.SlipPrtSetPaperId != target.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(this.CompleteCd != target.CompleteCd)resList.Add("CompleteCd");
			if(this.ClaimType != target.ClaimType)resList.Add("ClaimType");
			if(this.SalesPriceFracProcCd != target.SalesPriceFracProcCd)resList.Add("SalesPriceFracProcCd");
			if(this.ListPricePrintDiv != target.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
			if(this.EraNameDispCd1 != target.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(this.AcceptAnOrderNo != target.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(this.CommonSeqNo != target.CommonSeqNo)resList.Add("CommonSeqNo");
			if(this.SalesSlipDtlNum != target.SalesSlipDtlNum)resList.Add("SalesSlipDtlNum");
			if(this.AcptAnOdrStatusSrc != target.AcptAnOdrStatusSrc)resList.Add("AcptAnOdrStatusSrc");
			if(this.SalesSlipDtlNumSrc != target.SalesSlipDtlNumSrc)resList.Add("SalesSlipDtlNumSrc");
			if(this.SupplierFormalSync != target.SupplierFormalSync)resList.Add("SupplierFormalSync");
			if(this.StockSlipDtlNumSync != target.StockSlipDtlNumSync)resList.Add("StockSlipDtlNumSync");
			if(this.SalesSlipCdDtl != target.SalesSlipCdDtl)resList.Add("SalesSlipCdDtl");
			if(this.OrderNumber != target.OrderNumber)resList.Add("OrderNumber");
			if(this.StockMngExistCd != target.StockMngExistCd)resList.Add("StockMngExistCd");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsShortName != target.GoodsShortName)resList.Add("GoodsShortName");
			if(this.GoodsSetDivCd != target.GoodsSetDivCd)resList.Add("GoodsSetDivCd");
			if(this.LargeGoodsGanreCode != target.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(this.LargeGoodsGanreName != target.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(this.MediumGoodsGanreCode != target.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(this.MediumGoodsGanreName != target.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");
			if(this.DetailGoodsGanreCode != target.DetailGoodsGanreCode)resList.Add("DetailGoodsGanreCode");
			if(this.DetailGoodsGanreName != target.DetailGoodsGanreName)resList.Add("DetailGoodsGanreName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.SalesOrderDivCd != target.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.UnitCode != target.UnitCode)resList.Add("UnitCode");
			if(this.UnitName != target.UnitName)resList.Add("UnitName");
			if(this.GoodsRateRank != target.GoodsRateRank)resList.Add("GoodsRateRank");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(this.SuppRateGrpCode != target.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(this.ListPriceRate != target.ListPriceRate)resList.Add("ListPriceRate");
			if(this.RateSectPriceUnPrc != target.RateSectPriceUnPrc)resList.Add("RateSectPriceUnPrc");
			if(this.RateDivLPrice != target.RateDivLPrice)resList.Add("RateDivLPrice");
			if(this.UnPrcCalcCdLPrice != target.UnPrcCalcCdLPrice)resList.Add("UnPrcCalcCdLPrice");
			if(this.PriceCdLPrice != target.PriceCdLPrice)resList.Add("PriceCdLPrice");
			if(this.StdUnPrcLPrice != target.StdUnPrcLPrice)resList.Add("StdUnPrcLPrice");
			if(this.FracProcUnitLPrice != target.FracProcUnitLPrice)resList.Add("FracProcUnitLPrice");
			if(this.FracProcLPrice != target.FracProcLPrice)resList.Add("FracProcLPrice");
			if(this.ListPriceTaxIncFl != target.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.ListPriceChngCd != target.ListPriceChngCd)resList.Add("ListPriceChngCd");
			if(this.SalesRate != target.SalesRate)resList.Add("SalesRate");
			if(this.RateSectSalUnPrc != target.RateSectSalUnPrc)resList.Add("RateSectSalUnPrc");
			if(this.RateDivSalUnPrc != target.RateDivSalUnPrc)resList.Add("RateDivSalUnPrc");
			if(this.UnPrcCalcCdSalUnPrc != target.UnPrcCalcCdSalUnPrc)resList.Add("UnPrcCalcCdSalUnPrc");
			if(this.PriceCdSalUnPrc != target.PriceCdSalUnPrc)resList.Add("PriceCdSalUnPrc");
			if(this.StdUnPrcSalUnPrc != target.StdUnPrcSalUnPrc)resList.Add("StdUnPrcSalUnPrc");
			if(this.FracProcUnitSalUnPrc != target.FracProcUnitSalUnPrc)resList.Add("FracProcUnitSalUnPrc");
			if(this.FracProcSalUnPrc != target.FracProcSalUnPrc)resList.Add("FracProcSalUnPrc");
			if(this.SalesUnPrcTaxIncFl != target.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(this.SalesUnPrcChngCd != target.SalesUnPrcChngCd)resList.Add("SalesUnPrcChngCd");
			if(this.CostRate != target.CostRate)resList.Add("CostRate");
			if(this.RateSectCstUnPrc != target.RateSectCstUnPrc)resList.Add("RateSectCstUnPrc");
			if(this.RateDivUnCst != target.RateDivUnCst)resList.Add("RateDivUnCst");
			if(this.UnPrcCalcCdUnCst != target.UnPrcCalcCdUnCst)resList.Add("UnPrcCalcCdUnCst");
			if(this.PriceCdUnCst != target.PriceCdUnCst)resList.Add("PriceCdUnCst");
			if(this.StdUnPrcUnCst != target.StdUnPrcUnCst)resList.Add("StdUnPrcUnCst");
			if(this.FracProcUnitUnCst != target.FracProcUnitUnCst)resList.Add("FracProcUnitUnCst");
			if(this.FracProcUnCst != target.FracProcUnCst)resList.Add("FracProcUnCst");
			if(this.SalesUnitCost != target.SalesUnitCost)resList.Add("SalesUnitCost");
			if(this.SalesUnitCostChngDiv != target.SalesUnitCostChngDiv)resList.Add("SalesUnitCostChngDiv");
			if(this.RateBLGoodsCode != target.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(this.RateBLGoodsName != target.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(this.BargainCd != target.BargainCd)resList.Add("BargainCd");
			if(this.BargainNm != target.BargainNm)resList.Add("BargainNm");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.SalesMoneyTaxInc != target.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(this.SalesMoneyTaxExc != target.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(this.Cost != target.Cost)resList.Add("Cost");
			if(this.GrsProfitChkDiv != target.GrsProfitChkDiv)resList.Add("GrsProfitChkDiv");
			if(this.SalesGoodsCd != target.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(this.SalsePriceConsTax != target.SalsePriceConsTax)resList.Add("SalsePriceConsTax");
			if(this.TaxationDivCd != target.TaxationDivCd)resList.Add("TaxationDivCd");
			if(this.PartySlipNumDtl != target.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(this.DtlNote != target.DtlNote)resList.Add("DtlNote");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.SlipMemo1 != target.SlipMemo1)resList.Add("SlipMemo1");
			if(this.SlipMemo2 != target.SlipMemo2)resList.Add("SlipMemo2");
			if(this.SlipMemo3 != target.SlipMemo3)resList.Add("SlipMemo3");
			if(this.SlipMemo4 != target.SlipMemo4)resList.Add("SlipMemo4");
			if(this.SlipMemo5 != target.SlipMemo5)resList.Add("SlipMemo5");
			if(this.SlipMemo6 != target.SlipMemo6)resList.Add("SlipMemo6");
			if(this.InsideMemo1 != target.InsideMemo1)resList.Add("InsideMemo1");
			if(this.InsideMemo2 != target.InsideMemo2)resList.Add("InsideMemo2");
			if(this.InsideMemo3 != target.InsideMemo3)resList.Add("InsideMemo3");
			if(this.InsideMemo4 != target.InsideMemo4)resList.Add("InsideMemo4");
			if(this.InsideMemo5 != target.InsideMemo5)resList.Add("InsideMemo5");
			if(this.InsideMemo6 != target.InsideMemo6)resList.Add("InsideMemo6");
			if(this.BfListPrice != target.BfListPrice)resList.Add("BfListPrice");
			if(this.BfSalesUnitPrice != target.BfSalesUnitPrice)resList.Add("BfSalesUnitPrice");
			if(this.BfUnitCost != target.BfUnitCost)resList.Add("BfUnitCost");
			if(this.PrtGoodsNo != target.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(this.PrtGoodsName != target.PrtGoodsName)resList.Add("PrtGoodsName");
			if(this.PrtGoodsMakerCd != target.PrtGoodsMakerCd)resList.Add("PrtGoodsMakerCd");
			if(this.PrtGoodsMakerNm != target.PrtGoodsMakerNm)resList.Add("PrtGoodsMakerNm");
			if(this.SupplierSlipCd != target.SupplierSlipCd)resList.Add("SupplierSlipCd");
			if(this.TotalAmountDispWayCd != target.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(this.TtlAmntDispRateApy != target.TtlAmntDispRateApy)resList.Add("TtlAmntDispRateApy");
			if(this.ConfirmedDiv != target.ConfirmedDiv)resList.Add("ConfirmedDiv");
			if(this.NTimeCalcStDate != target.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.DtlRelationGuid != target.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(this.AcptAnOdrRemainCnt != target.AcptAnOdrRemainCnt)resList.Add("AcptAnOdrRemainCnt");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.ResultsAddUpSecNm != target.ResultsAddUpSecNm)resList.Add("ResultsAddUpSecNm");
			if(this.OutputName != target.OutputName)resList.Add("OutputName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// ����f�[�^�i�d�������v��j��r����
		/// </summary>
		/// <param name="salesTemp1">��r����SalesTemp�N���X�̃C���X�^���X</param>
		/// <param name="salesTemp2">��r����SalesTemp�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTemp�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SalesTemp salesTemp1, SalesTemp salesTemp2)
		{
			ArrayList resList = new ArrayList();
			if(salesTemp1.CreateDateTime != salesTemp2.CreateDateTime)resList.Add("CreateDateTime");
			if(salesTemp1.UpdateDateTime != salesTemp2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(salesTemp1.EnterpriseCode != salesTemp2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesTemp1.FileHeaderGuid != salesTemp2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(salesTemp1.UpdEmployeeCode != salesTemp2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(salesTemp1.UpdAssemblyId1 != salesTemp2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(salesTemp1.UpdAssemblyId2 != salesTemp2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(salesTemp1.LogicalDeleteCode != salesTemp2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(salesTemp1.AcptAnOdrStatus != salesTemp2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(salesTemp1.SectionCode != salesTemp2.SectionCode)resList.Add("SectionCode");
			if(salesTemp1.SubSectionCode != salesTemp2.SubSectionCode)resList.Add("SubSectionCode");
			if(salesTemp1.MinSectionCode != salesTemp2.MinSectionCode)resList.Add("MinSectionCode");
			if(salesTemp1.DebitNoteDiv != salesTemp2.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(salesTemp1.DebitNLnkAcptAnOdr != salesTemp2.DebitNLnkAcptAnOdr)resList.Add("DebitNLnkAcptAnOdr");
			if(salesTemp1.SalesSlipCd != salesTemp2.SalesSlipCd)resList.Add("SalesSlipCd");
			if(salesTemp1.AccRecDivCd != salesTemp2.AccRecDivCd)resList.Add("AccRecDivCd");
			if(salesTemp1.SalesInpSecCd != salesTemp2.SalesInpSecCd)resList.Add("SalesInpSecCd");
			if(salesTemp1.DemandAddUpSecCd != salesTemp2.DemandAddUpSecCd)resList.Add("DemandAddUpSecCd");
			if(salesTemp1.ResultsAddUpSecCd != salesTemp2.ResultsAddUpSecCd)resList.Add("ResultsAddUpSecCd");
			if(salesTemp1.UpdateSecCd != salesTemp2.UpdateSecCd)resList.Add("UpdateSecCd");
			if(salesTemp1.SearchSlipDate != salesTemp2.SearchSlipDate)resList.Add("SearchSlipDate");
			if(salesTemp1.ShipmentDay != salesTemp2.ShipmentDay)resList.Add("ShipmentDay");
			if(salesTemp1.SalesDate != salesTemp2.SalesDate)resList.Add("SalesDate");
			if(salesTemp1.AddUpADate != salesTemp2.AddUpADate)resList.Add("AddUpADate");
			if(salesTemp1.DelayPaymentDiv != salesTemp2.DelayPaymentDiv)resList.Add("DelayPaymentDiv");
			if(salesTemp1.ClaimCode != salesTemp2.ClaimCode)resList.Add("ClaimCode");
			if(salesTemp1.ClaimSnm != salesTemp2.ClaimSnm)resList.Add("ClaimSnm");
			if(salesTemp1.CustomerCode != salesTemp2.CustomerCode)resList.Add("CustomerCode");
			if(salesTemp1.CustomerName != salesTemp2.CustomerName)resList.Add("CustomerName");
			if(salesTemp1.CustomerName2 != salesTemp2.CustomerName2)resList.Add("CustomerName2");
			if(salesTemp1.CustomerSnm != salesTemp2.CustomerSnm)resList.Add("CustomerSnm");
			if(salesTemp1.HonorificTitle != salesTemp2.HonorificTitle)resList.Add("HonorificTitle");
			if(salesTemp1.OutputNameCode != salesTemp2.OutputNameCode)resList.Add("OutputNameCode");
			if(salesTemp1.BusinessTypeCode != salesTemp2.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(salesTemp1.BusinessTypeName != salesTemp2.BusinessTypeName)resList.Add("BusinessTypeName");
			if(salesTemp1.SalesAreaCode != salesTemp2.SalesAreaCode)resList.Add("SalesAreaCode");
			if(salesTemp1.SalesAreaName != salesTemp2.SalesAreaName)resList.Add("SalesAreaName");
			if(salesTemp1.SalesInputCode != salesTemp2.SalesInputCode)resList.Add("SalesInputCode");
			if(salesTemp1.SalesInputName != salesTemp2.SalesInputName)resList.Add("SalesInputName");
			if(salesTemp1.FrontEmployeeCd != salesTemp2.FrontEmployeeCd)resList.Add("FrontEmployeeCd");
			if(salesTemp1.FrontEmployeeNm != salesTemp2.FrontEmployeeNm)resList.Add("FrontEmployeeNm");
			if(salesTemp1.SalesEmployeeCd != salesTemp2.SalesEmployeeCd)resList.Add("SalesEmployeeCd");
			if(salesTemp1.SalesEmployeeNm != salesTemp2.SalesEmployeeNm)resList.Add("SalesEmployeeNm");
			if(salesTemp1.ConsTaxLayMethod != salesTemp2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(salesTemp1.ConsTaxRate != salesTemp2.ConsTaxRate)resList.Add("ConsTaxRate");
			if(salesTemp1.FractionProcCd != salesTemp2.FractionProcCd)resList.Add("FractionProcCd");
			if(salesTemp1.AutoDepositCd != salesTemp2.AutoDepositCd)resList.Add("AutoDepositCd");
			if(salesTemp1.AutoDepoSlipNum != salesTemp2.AutoDepoSlipNum)resList.Add("AutoDepoSlipNum");
			if(salesTemp1.SlipAddressDiv != salesTemp2.SlipAddressDiv)resList.Add("SlipAddressDiv");
			if(salesTemp1.AddresseeCode != salesTemp2.AddresseeCode)resList.Add("AddresseeCode");
			if(salesTemp1.AddresseeName != salesTemp2.AddresseeName)resList.Add("AddresseeName");
			if(salesTemp1.AddresseeName2 != salesTemp2.AddresseeName2)resList.Add("AddresseeName2");
			if(salesTemp1.AddresseePostNo != salesTemp2.AddresseePostNo)resList.Add("AddresseePostNo");
			if(salesTemp1.AddresseeAddr1 != salesTemp2.AddresseeAddr1)resList.Add("AddresseeAddr1");
			if(salesTemp1.AddresseeAddr2 != salesTemp2.AddresseeAddr2)resList.Add("AddresseeAddr2");
			if(salesTemp1.AddresseeAddr3 != salesTemp2.AddresseeAddr3)resList.Add("AddresseeAddr3");
			if(salesTemp1.AddresseeAddr4 != salesTemp2.AddresseeAddr4)resList.Add("AddresseeAddr4");
			if(salesTemp1.AddresseeTelNo != salesTemp2.AddresseeTelNo)resList.Add("AddresseeTelNo");
			if(salesTemp1.AddresseeFaxNo != salesTemp2.AddresseeFaxNo)resList.Add("AddresseeFaxNo");
			if(salesTemp1.PartySaleSlipNum != salesTemp2.PartySaleSlipNum)resList.Add("PartySaleSlipNum");
			if(salesTemp1.SlipNote != salesTemp2.SlipNote)resList.Add("SlipNote");
			if(salesTemp1.SlipNote2 != salesTemp2.SlipNote2)resList.Add("SlipNote2");
			if(salesTemp1.RetGoodsReasonDiv != salesTemp2.RetGoodsReasonDiv)resList.Add("RetGoodsReasonDiv");
			if(salesTemp1.RetGoodsReason != salesTemp2.RetGoodsReason)resList.Add("RetGoodsReason");
			if(salesTemp1.DetailRowCount != salesTemp2.DetailRowCount)resList.Add("DetailRowCount");
			if(salesTemp1.DeliveredGoodsDiv != salesTemp2.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(salesTemp1.DeliveredGoodsDivNm != salesTemp2.DeliveredGoodsDivNm)resList.Add("DeliveredGoodsDivNm");
			if(salesTemp1.ReconcileFlag != salesTemp2.ReconcileFlag)resList.Add("ReconcileFlag");
			if(salesTemp1.SlipPrtSetPaperId != salesTemp2.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(salesTemp1.CompleteCd != salesTemp2.CompleteCd)resList.Add("CompleteCd");
			if(salesTemp1.ClaimType != salesTemp2.ClaimType)resList.Add("ClaimType");
			if(salesTemp1.SalesPriceFracProcCd != salesTemp2.SalesPriceFracProcCd)resList.Add("SalesPriceFracProcCd");
			if(salesTemp1.ListPricePrintDiv != salesTemp2.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
			if(salesTemp1.EraNameDispCd1 != salesTemp2.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(salesTemp1.AcceptAnOrderNo != salesTemp2.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(salesTemp1.CommonSeqNo != salesTemp2.CommonSeqNo)resList.Add("CommonSeqNo");
			if(salesTemp1.SalesSlipDtlNum != salesTemp2.SalesSlipDtlNum)resList.Add("SalesSlipDtlNum");
			if(salesTemp1.AcptAnOdrStatusSrc != salesTemp2.AcptAnOdrStatusSrc)resList.Add("AcptAnOdrStatusSrc");
			if(salesTemp1.SalesSlipDtlNumSrc != salesTemp2.SalesSlipDtlNumSrc)resList.Add("SalesSlipDtlNumSrc");
			if(salesTemp1.SupplierFormalSync != salesTemp2.SupplierFormalSync)resList.Add("SupplierFormalSync");
			if(salesTemp1.StockSlipDtlNumSync != salesTemp2.StockSlipDtlNumSync)resList.Add("StockSlipDtlNumSync");
			if(salesTemp1.SalesSlipCdDtl != salesTemp2.SalesSlipCdDtl)resList.Add("SalesSlipCdDtl");
			if(salesTemp1.OrderNumber != salesTemp2.OrderNumber)resList.Add("OrderNumber");
			if(salesTemp1.StockMngExistCd != salesTemp2.StockMngExistCd)resList.Add("StockMngExistCd");
			if(salesTemp1.DeliGdsCmpltDueDate != salesTemp2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(salesTemp1.GoodsKindCode != salesTemp2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(salesTemp1.GoodsMakerCd != salesTemp2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(salesTemp1.MakerName != salesTemp2.MakerName)resList.Add("MakerName");
			if(salesTemp1.GoodsNo != salesTemp2.GoodsNo)resList.Add("GoodsNo");
			if(salesTemp1.GoodsName != salesTemp2.GoodsName)resList.Add("GoodsName");
			if(salesTemp1.GoodsShortName != salesTemp2.GoodsShortName)resList.Add("GoodsShortName");
			if(salesTemp1.GoodsSetDivCd != salesTemp2.GoodsSetDivCd)resList.Add("GoodsSetDivCd");
			if(salesTemp1.LargeGoodsGanreCode != salesTemp2.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(salesTemp1.LargeGoodsGanreName != salesTemp2.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(salesTemp1.MediumGoodsGanreCode != salesTemp2.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(salesTemp1.MediumGoodsGanreName != salesTemp2.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");
			if(salesTemp1.DetailGoodsGanreCode != salesTemp2.DetailGoodsGanreCode)resList.Add("DetailGoodsGanreCode");
			if(salesTemp1.DetailGoodsGanreName != salesTemp2.DetailGoodsGanreName)resList.Add("DetailGoodsGanreName");
			if(salesTemp1.BLGoodsCode != salesTemp2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(salesTemp1.BLGoodsFullName != salesTemp2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(salesTemp1.EnterpriseGanreCode != salesTemp2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(salesTemp1.EnterpriseGanreName != salesTemp2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(salesTemp1.WarehouseCode != salesTemp2.WarehouseCode)resList.Add("WarehouseCode");
			if(salesTemp1.WarehouseName != salesTemp2.WarehouseName)resList.Add("WarehouseName");
			if(salesTemp1.WarehouseShelfNo != salesTemp2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(salesTemp1.SalesOrderDivCd != salesTemp2.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(salesTemp1.OpenPriceDiv != salesTemp2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(salesTemp1.UnitCode != salesTemp2.UnitCode)resList.Add("UnitCode");
			if(salesTemp1.UnitName != salesTemp2.UnitName)resList.Add("UnitName");
			if(salesTemp1.GoodsRateRank != salesTemp2.GoodsRateRank)resList.Add("GoodsRateRank");
			if(salesTemp1.CustRateGrpCode != salesTemp2.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(salesTemp1.SuppRateGrpCode != salesTemp2.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(salesTemp1.ListPriceRate != salesTemp2.ListPriceRate)resList.Add("ListPriceRate");
			if(salesTemp1.RateSectPriceUnPrc != salesTemp2.RateSectPriceUnPrc)resList.Add("RateSectPriceUnPrc");
			if(salesTemp1.RateDivLPrice != salesTemp2.RateDivLPrice)resList.Add("RateDivLPrice");
			if(salesTemp1.UnPrcCalcCdLPrice != salesTemp2.UnPrcCalcCdLPrice)resList.Add("UnPrcCalcCdLPrice");
			if(salesTemp1.PriceCdLPrice != salesTemp2.PriceCdLPrice)resList.Add("PriceCdLPrice");
			if(salesTemp1.StdUnPrcLPrice != salesTemp2.StdUnPrcLPrice)resList.Add("StdUnPrcLPrice");
			if(salesTemp1.FracProcUnitLPrice != salesTemp2.FracProcUnitLPrice)resList.Add("FracProcUnitLPrice");
			if(salesTemp1.FracProcLPrice != salesTemp2.FracProcLPrice)resList.Add("FracProcLPrice");
			if(salesTemp1.ListPriceTaxIncFl != salesTemp2.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(salesTemp1.ListPriceTaxExcFl != salesTemp2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(salesTemp1.ListPriceChngCd != salesTemp2.ListPriceChngCd)resList.Add("ListPriceChngCd");
			if(salesTemp1.SalesRate != salesTemp2.SalesRate)resList.Add("SalesRate");
			if(salesTemp1.RateSectSalUnPrc != salesTemp2.RateSectSalUnPrc)resList.Add("RateSectSalUnPrc");
			if(salesTemp1.RateDivSalUnPrc != salesTemp2.RateDivSalUnPrc)resList.Add("RateDivSalUnPrc");
			if(salesTemp1.UnPrcCalcCdSalUnPrc != salesTemp2.UnPrcCalcCdSalUnPrc)resList.Add("UnPrcCalcCdSalUnPrc");
			if(salesTemp1.PriceCdSalUnPrc != salesTemp2.PriceCdSalUnPrc)resList.Add("PriceCdSalUnPrc");
			if(salesTemp1.StdUnPrcSalUnPrc != salesTemp2.StdUnPrcSalUnPrc)resList.Add("StdUnPrcSalUnPrc");
			if(salesTemp1.FracProcUnitSalUnPrc != salesTemp2.FracProcUnitSalUnPrc)resList.Add("FracProcUnitSalUnPrc");
			if(salesTemp1.FracProcSalUnPrc != salesTemp2.FracProcSalUnPrc)resList.Add("FracProcSalUnPrc");
			if(salesTemp1.SalesUnPrcTaxIncFl != salesTemp2.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(salesTemp1.SalesUnPrcTaxExcFl != salesTemp2.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(salesTemp1.SalesUnPrcChngCd != salesTemp2.SalesUnPrcChngCd)resList.Add("SalesUnPrcChngCd");
			if(salesTemp1.CostRate != salesTemp2.CostRate)resList.Add("CostRate");
			if(salesTemp1.RateSectCstUnPrc != salesTemp2.RateSectCstUnPrc)resList.Add("RateSectCstUnPrc");
			if(salesTemp1.RateDivUnCst != salesTemp2.RateDivUnCst)resList.Add("RateDivUnCst");
			if(salesTemp1.UnPrcCalcCdUnCst != salesTemp2.UnPrcCalcCdUnCst)resList.Add("UnPrcCalcCdUnCst");
			if(salesTemp1.PriceCdUnCst != salesTemp2.PriceCdUnCst)resList.Add("PriceCdUnCst");
			if(salesTemp1.StdUnPrcUnCst != salesTemp2.StdUnPrcUnCst)resList.Add("StdUnPrcUnCst");
			if(salesTemp1.FracProcUnitUnCst != salesTemp2.FracProcUnitUnCst)resList.Add("FracProcUnitUnCst");
			if(salesTemp1.FracProcUnCst != salesTemp2.FracProcUnCst)resList.Add("FracProcUnCst");
			if(salesTemp1.SalesUnitCost != salesTemp2.SalesUnitCost)resList.Add("SalesUnitCost");
			if(salesTemp1.SalesUnitCostChngDiv != salesTemp2.SalesUnitCostChngDiv)resList.Add("SalesUnitCostChngDiv");
			if(salesTemp1.RateBLGoodsCode != salesTemp2.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(salesTemp1.RateBLGoodsName != salesTemp2.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(salesTemp1.BargainCd != salesTemp2.BargainCd)resList.Add("BargainCd");
			if(salesTemp1.BargainNm != salesTemp2.BargainNm)resList.Add("BargainNm");
			if(salesTemp1.ShipmentCnt != salesTemp2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(salesTemp1.SalesMoneyTaxInc != salesTemp2.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(salesTemp1.SalesMoneyTaxExc != salesTemp2.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(salesTemp1.Cost != salesTemp2.Cost)resList.Add("Cost");
			if(salesTemp1.GrsProfitChkDiv != salesTemp2.GrsProfitChkDiv)resList.Add("GrsProfitChkDiv");
			if(salesTemp1.SalesGoodsCd != salesTemp2.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(salesTemp1.SalsePriceConsTax != salesTemp2.SalsePriceConsTax)resList.Add("SalsePriceConsTax");
			if(salesTemp1.TaxationDivCd != salesTemp2.TaxationDivCd)resList.Add("TaxationDivCd");
			if(salesTemp1.PartySlipNumDtl != salesTemp2.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(salesTemp1.DtlNote != salesTemp2.DtlNote)resList.Add("DtlNote");
			if(salesTemp1.SupplierCd != salesTemp2.SupplierCd)resList.Add("SupplierCd");
			if(salesTemp1.SupplierSnm != salesTemp2.SupplierSnm)resList.Add("SupplierSnm");
			if(salesTemp1.SlipMemo1 != salesTemp2.SlipMemo1)resList.Add("SlipMemo1");
			if(salesTemp1.SlipMemo2 != salesTemp2.SlipMemo2)resList.Add("SlipMemo2");
			if(salesTemp1.SlipMemo3 != salesTemp2.SlipMemo3)resList.Add("SlipMemo3");
			if(salesTemp1.SlipMemo4 != salesTemp2.SlipMemo4)resList.Add("SlipMemo4");
			if(salesTemp1.SlipMemo5 != salesTemp2.SlipMemo5)resList.Add("SlipMemo5");
			if(salesTemp1.SlipMemo6 != salesTemp2.SlipMemo6)resList.Add("SlipMemo6");
			if(salesTemp1.InsideMemo1 != salesTemp2.InsideMemo1)resList.Add("InsideMemo1");
			if(salesTemp1.InsideMemo2 != salesTemp2.InsideMemo2)resList.Add("InsideMemo2");
			if(salesTemp1.InsideMemo3 != salesTemp2.InsideMemo3)resList.Add("InsideMemo3");
			if(salesTemp1.InsideMemo4 != salesTemp2.InsideMemo4)resList.Add("InsideMemo4");
			if(salesTemp1.InsideMemo5 != salesTemp2.InsideMemo5)resList.Add("InsideMemo5");
			if(salesTemp1.InsideMemo6 != salesTemp2.InsideMemo6)resList.Add("InsideMemo6");
			if(salesTemp1.BfListPrice != salesTemp2.BfListPrice)resList.Add("BfListPrice");
			if(salesTemp1.BfSalesUnitPrice != salesTemp2.BfSalesUnitPrice)resList.Add("BfSalesUnitPrice");
			if(salesTemp1.BfUnitCost != salesTemp2.BfUnitCost)resList.Add("BfUnitCost");
			if(salesTemp1.PrtGoodsNo != salesTemp2.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(salesTemp1.PrtGoodsName != salesTemp2.PrtGoodsName)resList.Add("PrtGoodsName");
			if(salesTemp1.PrtGoodsMakerCd != salesTemp2.PrtGoodsMakerCd)resList.Add("PrtGoodsMakerCd");
			if(salesTemp1.PrtGoodsMakerNm != salesTemp2.PrtGoodsMakerNm)resList.Add("PrtGoodsMakerNm");
			if(salesTemp1.SupplierSlipCd != salesTemp2.SupplierSlipCd)resList.Add("SupplierSlipCd");
			if(salesTemp1.TotalAmountDispWayCd != salesTemp2.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(salesTemp1.TtlAmntDispRateApy != salesTemp2.TtlAmntDispRateApy)resList.Add("TtlAmntDispRateApy");
			if(salesTemp1.ConfirmedDiv != salesTemp2.ConfirmedDiv)resList.Add("ConfirmedDiv");
			if(salesTemp1.NTimeCalcStDate != salesTemp2.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(salesTemp1.TotalDay != salesTemp2.TotalDay)resList.Add("TotalDay");
			if(salesTemp1.DtlRelationGuid != salesTemp2.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(salesTemp1.AcptAnOdrRemainCnt != salesTemp2.AcptAnOdrRemainCnt)resList.Add("AcptAnOdrRemainCnt");
			if(salesTemp1.EnterpriseName != salesTemp2.EnterpriseName)resList.Add("EnterpriseName");
			if(salesTemp1.UpdEmployeeName != salesTemp2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(salesTemp1.ResultsAddUpSecNm != salesTemp2.ResultsAddUpSecNm)resList.Add("ResultsAddUpSecNm");
			if(salesTemp1.OutputName != salesTemp2.OutputName)resList.Add("OutputName");
			if(salesTemp1.BLGoodsName != salesTemp2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}
	}
}

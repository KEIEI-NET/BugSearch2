using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RsltInfo_EBooksDemandTotalWork
	/// <summary>
	///                      ������(�ӕ�)���o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������(�ӕ�)���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer       :   3H ����</br>
    /// <br>Date             :   2022/10/27</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RsltInfo_EBooksDemandTotalWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>�v�㋒�_����</summary>
		/// <remarks>���_���ݒ�}�X�^����擾</remarks>
		private string _addUpSecName = "";

		/// <summary>������R�[�h</summary>
		/// <remarks>������̐e�R�[�h</remarks>
		private Int32 _claimCode;

		/// <summary>�����於��</summary>
		private string _claimName = "";

		/// <summary>�����於��2</summary>
		private string _claimName2 = "";

		/// <summary>�����旪��</summary>
		private string _claimSnm = "";

		/// <summary>�����於�̃J�i</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _claimNameKana = "";

		/// <summary>�X�֔ԍ�</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _postNo = "";

		/// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _address1 = "";

		/// <summary>�Z��2�i���ځj</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private Int32 _address2;

		/// <summary>�Z��3�i�Ԓn�j</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _address3 = "";

		/// <summary>�Z��4�i�A�p�[�g���́j</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _address4 = "";

		/// <summary>�W�����敪�R�[�h</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0:����,1:����,2:���X��</remarks>
		private Int32 _collectMoneyCode;

		/// <summary>�W�����敪����</summary>
		/// <remarks>���Ӑ�}�X�^����擾 ����,����,���X��</remarks>
		private string _collectMoneyName = "";

		/// <summary>�W����</summary>
		/// <remarks>���Ӑ�}�X�^����擾 DD</remarks>
		private Int32 _collectMoneyDay;

		/// <summary>�h��</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _honorificTitle = "";

		/// <summary>�d�b�ԍ��i����j</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _homeTelNo = "";

		/// <summary>�d�b�ԍ��i�Ζ���j</summary>
		/// <remarks>���Ӑ�}�X�^����擾 �[����̏ꍇ�̎g�p�\����</remarks>
		private string _officeTelNo = "";

		/// <summary>�d�b�ԍ��i�g�сj</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _portableTelNo = "";

		/// <summary>FAX�ԍ��i����j</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _homeFaxNo = "";

		/// <summary>FAX�ԍ��i�Ζ���j</summary>
		/// <remarks>���Ӑ�}�X�^����擾 �[����̏ꍇ�̎g�p�\����</remarks>
		private string _officeFaxNo = "";

		/// <summary>�d�b�ԍ��i���̑��j</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _othersTelNo = "";

		/// <summary>��A����敪</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</remarks>
		private Int32 _mainContactCode;

		/// <summary>����</summary>
		/// <remarks>���Ӑ�}�X�^����擾 DD</remarks>
		private Int32 _totalDay;

		/// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _customerAgentCd = "";

		/// <summary>�ڋq�S���]�ƈ�����</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _customerAgentNm = "";

		/// <summary>�W���S���]�ƈ��R�[�h</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _billCollecterCd = "";

		/// <summary>�W���S���]�ƈ�����</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _billCollecterNm = "";

		/// <summary>����œ]�ŕ���</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>���z�\�����@�敪</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>���z�\�����@�Q�Ƌ敪</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0:�S�̐ݒ�Q�� 1:���Ӑ�Q��</remarks>
		private Int32 _totalAmntDspWayRef;

		/// <summary>�������Œ[�������R�[�h</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
		private Int32 _salesCnsTaxFrcProcCd;

		/// <summary>��s����1</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _accountNoInfo1 = "";

		/// <summary>��s����2</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _accountNoInfo2 = "";

		/// <summary>��s����3</summary>
		/// <remarks>���Ӑ�}�X�^����擾</remarks>
		private string _accountNoInfo3 = "";

		/// <summary>�l�E�@�l�敪</summary>
		/// <remarks>���Ӑ�}�X�^����擾 0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</remarks>
		private Int32 _corporateDivCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ於��</summary>
		private string _customerName = "";

		/// <summary>���Ӑ於��2</summary>
		private string _customerName2 = "";

		/// <summary>���Ӑ旪��</summary>
		private string _customerSnm = "";

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
		private DateTime _addUpDate;

		/// <summary>�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�O�񐿋����z</summary>
		private Int64 _lastTimeDemand;

		/// <summary>����萔���z�i�ʏ�����j</summary>
		private Int64 _thisTimeFeeDmdNrml;

		/// <summary>����l���z�i�ʏ�����j</summary>
		private Int64 _thisTimeDisDmdNrml;

		/// <summary>����������z�i�ʏ�����j</summary>
		/// <remarks>�����z�̍��v���z</remarks>
		private Int64 _thisTimeDmdNrml;

		/// <summary>����J�z�c���i�����v�j</summary>
		/// <remarks>����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j</remarks>
		private Int64 _thisTimeTtlBlcDmd;

		/// <summary>���E�㍡�񔄏���z</summary>
		private Int64 _ofsThisTimeSales;

		/// <summary>���E�㍡�񔄏�����</summary>
		private Int64 _ofsThisSalesTax;

		/// <summary>���E��O�őΏۊz</summary>
		/// <remarks>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedOffsetOutTax;

		/// <summary>���E����őΏۊz</summary>
		/// <remarks>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedOffsetInTax;

		/// <summary>���E���ېőΏۊz</summary>
		/// <remarks>���E�p�F��ېŊz�̏W�v</remarks>
		private Int64 _itdedOffsetTaxFree;

		/// <summary>���E��O�ŏ����</summary>
		/// <remarks>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
		private Int64 _offsetOutTax;

		/// <summary>���E����ŏ����</summary>
		/// <remarks>���E�p�F���ŏ���ł̏W�v</remarks>
		private Int64 _offsetInTax;

		/// <summary>���񔄏���z</summary>
		/// <remarks>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
		private Int64 _thisTimeSales;

		/// <summary>���񔄏�����</summary>
		private Int64 _thisSalesTax;

		/// <summary>����O�őΏۊz</summary>
		/// <remarks>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedSalesOutTax;

		/// <summary>������őΏۊz</summary>
		/// <remarks>�����p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedSalesInTax;

		/// <summary>�����ېőΏۊz</summary>
		/// <remarks>�����p�F��ېŊz�̏W�v</remarks>
		private Int64 _itdedSalesTaxFree;

		/// <summary>����O�Ŋz</summary>
		/// <remarks>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
		private Int64 _salesOutTax;

		/// <summary>������Ŋz</summary>
		/// <remarks>�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</remarks>
		private Int64 _salesInTax;

		/// <summary>���񔄏�ԕi���z</summary>
		/// <remarks>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
		private Int64 _thisSalesPricRgds;

		/// <summary>���񔄏�ԕi�����</summary>
		/// <remarks>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
		private Int64 _thisSalesPrcTaxRgds;

		/// <summary>�ԕi�O�őΏۊz���v</summary>
		private Int64 _ttlItdedRetOutTax;

		/// <summary>�ԕi���őΏۊz���v</summary>
		private Int64 _ttlItdedRetInTax;

		/// <summary>�ԕi��ېőΏۊz���v</summary>
		private Int64 _ttlItdedRetTaxFree;

		/// <summary>�ԕi�O�Ŋz���v</summary>
		private Int64 _ttlRetOuterTax;

		/// <summary>�ԕi���Ŋz���v</summary>
		/// <remarks>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>���񔄏�l�����z</summary>
		/// <remarks>�|���F�Ŕ����̔���l�����z</remarks>
		private Int64 _thisSalesPricDis;

		/// <summary>���񔄏�l�������</summary>
		/// <remarks>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
		private Int64 _thisSalesPrcTaxDis;

		/// <summary>�l���O�őΏۊz���v</summary>
		private Int64 _ttlItdedDisOutTax;

		/// <summary>�l�����őΏۊz���v</summary>
		private Int64 _ttlItdedDisInTax;

		/// <summary>�l����ېőΏۊz���v</summary>
		private Int64 _ttlItdedDisTaxFree;

		/// <summary>�l���O�Ŋz���v</summary>
		private Int64 _ttlDisOuterTax;

		/// <summary>�l�����Ŋz���v</summary>
		/// <remarks>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>����x�����E���z</summary>
		/// <remarks>���E�p�`�[�F���E�p����`�[�v�i���E�Ώۊz�j</remarks>
		private Int64 _thisPayOffset;

		/// <summary>����x�����E�����</summary>
		/// <remarks>���E�p�`�[�F���E�p�������ō��v</remarks>
		private Int64 _thisPayOffsetTax;

		/// <summary>�x���O�őΏۊz</summary>
		/// <remarks>���E�p�`�[�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedPaymOutTax;

		/// <summary>�x�����őΏۊz</summary>
		/// <remarks>���E�p�`�[�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
		private Int64 _itdedPaymInTax;

		/// <summary>�x����ېőΏۊz</summary>
		/// <remarks>���E�p�`�[�F��ېŊz�̏W�v</remarks>
		private Int64 _itdedPaymTaxFree;

		/// <summary>�x���O�ŏ����</summary>
		/// <remarks>���E�p�`�[�F�O�ŏ���ł̏W�v</remarks>
		private Int64 _paymentOutTax;

		/// <summary>�x�����ŏ����</summary>
		/// <remarks>���E�p�`�[�F���ŏ���ł̏W�v</remarks>
		private Int64 _paymentInTax;

		/// <summary>����Œ����z</summary>
		private Int64 _taxAdjust;

		/// <summary>�c�������z</summary>
		private Int64 _balanceAdjust;

		/// <summary>�v�Z�㐿�����z</summary>
		/// <remarks>���񐿋����z</remarks>
		private Int64 _afCalDemandPrice;

		/// <summary>��2��O�c���i�����v�j</summary>
		private Int64 _acpOdrTtl2TmBfBlDmd;

		/// <summary>��3��O�c���i�����v�j</summary>
		private Int64 _acpOdrTtl3TmBfBlDmd;

		/// <summary>�����X�V���s�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>�����X�V�J�n�N����</summary>
		/// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
		private DateTime _startCAddUpUpdDate;

		/// <summary>�O������X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>����`�[����</summary>
		/// <remarks>�|���̓`�[����</remarks>
		private Int32 _salesSlipCount;

		/// <summary>���������s��</summary>
		/// <remarks>"YYYYMMDD"  �������𔭍s�����N����</remarks>
		private DateTime _billPrintDate;

		/// <summary>�����\���</summary>
		private DateTime _expectedDepositDate;

		/// <summary>�������</summary>
		/// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
		private Int32 _collectCond;

		/// <summary>����ŗ�</summary>
		/// <remarks>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</remarks>
		private Double _consTaxRate;

		/// <summary>�[�������敪</summary>
		private Int32 _fractionProcCd;

		/// <summary>����R�[�h���X�g</summary>
		/// <remarks>(����R�[�h�A���햼�́A����敪�A�������z�j</remarks>
		private ArrayList _moneyKindList;

		/// <summary>�`�[����ݒ�p���[ID</summary>
		/// <remarks>�`�[����ݒ�p</remarks>
		private string _slipPrtSetPaperId = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>���Ӑ�}�X�^����擾</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        /// <remarks>�K�C�h�}�X�^����擾</remarks>
        private string _salesAreaName = "";

        /// <summary>�������_�R�[�h</summary>
        /// <remarks>���Ӑ�}�X�^����擾</remarks>
        private string _claimSectionCode = "";

        /// <summary>���ы��_�R�[�h</summary>
        /// <remarks>���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _resultsSectCd = "";

        /// <summary>�������o�͋敪�R�[�h</summary>
        /// <remarks>0:���������s����,1:���Ȃ�</remarks>
        private Int32 _billOutputCode;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>�̎����o�͋敪�R�[�h</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _receiptOutputCode;

        /// <summary>���v�������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>���א������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>�`�[���v�������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _slipTtlBillOutputDiv;

        /// <summary>�ŗ�1�^�C�g��</summary>
        /// <remarks>�ŗ�1�^�C�g��</remarks>
        private string _titleTaxRate1 = string.Empty;

        /// <summary>�ŗ�2�^�C�g��</summary>
        /// <remarks>�ŗ�2�^�C�g��</remarks>
        private string _titleTaxRate2 = string.Empty;

        /// <summary>����z(�v�ŗ�1)</summary>
        /// <remarks>����z(�v�ŗ�1)</remarks>
        private Int64 _totalThisTimeSalesTaxRate1;

        /// <summary>����z(�v�ŗ�2)</summary>
        /// <remarks>����z(�v�ŗ�2)</remarks>
        private Int64 _totalThisTimeSalesTaxRate2;

        /// <summary>����z(�v���̑�)</summary>
        /// <remarks>����z(�v���̑�)</remarks>
        private Int64 _totalThisTimeSalesOther;

        /// <summary>�ԕi�l��(�v�ŗ�1)</summary>
        /// <remarks>�ԕi�l��(�v�ŗ�1)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate1;

        /// <summary>�ԕi�l��(�v�ŗ�2)</summary>
        /// <remarks>�ԕi�l��(�v�ŗ�2)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate2;

        /// <summary>�ԕi�l��(�v���̑�)</summary>
        /// <remarks>�ԕi�l��(�v���̑�)</remarks>
        private Int64 _totalThisRgdsDisPricOther;

        /// <summary>������z(�v�ŗ�1)</summary>
        /// <remarks>������z(�v�ŗ�1)</remarks>
        private Int64 _totalPureSalesTaxRate1;

        /// <summary>������z(�v�ŗ�2)</summary>
        /// <remarks>������z(�v�ŗ�2)</remarks>
        private Int64 _totalPureSalesTaxRate2;

        /// <summary>������z(�v���̑�)</summary>
        /// <remarks>������z(�v���̑�)</remarks>
        private Int64 _totalPureSalesOther;

        /// <summary>�����(�v�ŗ�1)</summary>
        /// <remarks>�����(�v�ŗ�1)</remarks>
        private Int64 _totalSalesPricTaxTaxRate1;

        /// <summary>�����(�v�ŗ�2)</summary>
        /// <remarks>�����(�v�ŗ�2)</remarks>
        private Int64 _totalSalesPricTaxTaxRate2;

        /// <summary>�����(�v���̑�)</summary>
        /// <remarks>�����(�v���̑�)</remarks>
        private Int64 _totalSalesPricTaxOther;

        /// <summary>���񍇌v(�v�ŗ�1)</summary>
        /// <remarks>���񍇌v(�v�ŗ�1)</remarks>
        private Int64 _totalThisSalesSumTaxRate1;

        /// <summary>���񍇌v(�v�ŗ�2)</summary>
        /// <remarks>���񍇌v(�v�ŗ�2)</remarks>
        private Int64 _totalThisSalesSumTaxRate2;

        /// <summary>���񍇌v(�v���̑�)</summary>
        /// <remarks>���񍇌v(�v���̑�)</remarks>
        private Int64 _totalThisSalesSumTaxOther;

        /// <summary>����(�v�ŗ�1)</summary>
        /// <remarks>����(�v�ŗ�1)</remarks>
        private Int32 _totalSalesSlipCountTaxRate1;

        /// <summary>����(�v�ŗ�2)</summary>
        /// <remarks>����(�v�ŗ�2)</remarks>
        private Int32 _totalSalesSlipCountTaxRate2;

        /// <summary>����(�v���̑�)</summary>
        /// <remarks>����(�v���̑�)</remarks>
        private Int32 _totalSalesSlipCountOther;

        // --- ADD START 3H ���� 2022/10/27 ----->>>>>
        /// <summary>����z(��ې�)</summary>
        /// <remarks>����z(��ې�)</remarks>
        private Int64 _totalThisTimeSalesTaxFree;

        /// <summary>�ԕi�l��(��ې�)</summary>
        /// <remarks>�ԕi�l��(��ې�)</remarks>
        private Int64 _totalThisRgdsDisPricTaxFree;

        /// <summary>������z(��ې�)</summary>
        /// <remarks>������z(��ې�)</remarks>
        private Int64 _totalPureSalesTaxFree;

        /// <summary>�����(��ې�)</summary>
        /// <remarks>�����(��ې�)</remarks>
        private Int64 _totalSalesPricTaxTaxFree;

        /// <summary>���񍇌v(��ې�)</summary>
        /// <remarks>���񍇌v(��ې�)</remarks>
        private Int64 _totalThisSalesSumTaxFree;

        /// <summary>����(��ې�)</summary>
        /// <remarks>����(��ې�)</remarks>
        private Int32 _totalSalesSlipCountTaxFree;
        // --- ADD END 3H ���� 2022/10/27 -----<<<<<

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

		/// public propaty name  :  AddUpSecCode
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>�v�㋒�_���̃v���p�e�B</summary>
		/// <value>���_���ݒ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// <value>������̐e�R�[�h</value>
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

		/// public propaty name  :  ClaimName
		/// <summary>�����於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ClaimName
		{
			get{return _claimName;}
			set{_claimName = value;}
		}

		/// public propaty name  :  ClaimName2
		/// <summary>�����於��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����於��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ClaimName2
		{
			get{return _claimName2;}
			set{_claimName2 = value;}
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

		/// public propaty name  :  ClaimNameKana
		/// <summary>�����於�̃J�i�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����於�̃J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ClaimNameKana
		{
			get{return _claimNameKana;}
			set{_claimNameKana = value;}
		}

		/// public propaty name  :  PostNo
		/// <summary>�X�֔ԍ��v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�֔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PostNo
		{
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  Address1
		/// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address1
		{
			get{return _address1;}
			set{_address1 = value;}
		}

		/// public propaty name  :  Address2
		/// <summary>�Z��2�i���ځj�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��2�i���ځj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Address2
		{
			get{return _address2;}
			set{_address2 = value;}
		}

		/// public propaty name  :  Address3
		/// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address3
		{
			get{return _address3;}
			set{_address3 = value;}
		}

		/// public propaty name  :  Address4
		/// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address4
		{
			get{return _address4;}
			set{_address4 = value;}
		}

		/// public propaty name  :  CollectMoneyCode
		/// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0:����,1:����,2:���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�����敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectMoneyCode
		{
			get{return _collectMoneyCode;}
			set{_collectMoneyCode = value;}
		}

		/// public propaty name  :  CollectMoneyName
		/// <summary>�W�����敪���̃v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 ����,����,���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�����敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CollectMoneyName
		{
			get{return _collectMoneyName;}
			set{_collectMoneyName = value;}
		}

		/// public propaty name  :  CollectMoneyDay
		/// <summary>�W�����v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectMoneyDay
		{
			get{return _collectMoneyDay;}
			set{_collectMoneyDay = value;}
		}

		/// public propaty name  :  HonorificTitle
		/// <summary>�h�̃v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
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

		/// public propaty name  :  HomeTelNo
		/// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HomeTelNo
		{
			get{return _homeTelNo;}
			set{_homeTelNo = value;}
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 �[����̏ꍇ�̎g�p�\����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get{return _officeTelNo;}
			set{_officeTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  HomeFaxNo
		/// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HomeFaxNo
		{
			get{return _homeFaxNo;}
			set{_homeFaxNo = value;}
		}

		/// public propaty name  :  OfficeFaxNo
		/// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 �[����̏ꍇ�̎g�p�\����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeFaxNo
		{
			get{return _officeFaxNo;}
			set{_officeFaxNo = value;}
		}

		/// public propaty name  :  OthersTelNo
		/// <summary>�d�b�ԍ��i���̑��j�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i���̑��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OthersTelNo
		{
			get{return _othersTelNo;}
			set{_othersTelNo = value;}
		}

		/// public propaty name  :  MainContactCode
		/// <summary>��A����敪�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��A����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MainContactCode
		{
			get{return _mainContactCode;}
			set{_mainContactCode = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>�����v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 DD</value>
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

		/// public propaty name  :  CustomerAgentCd
		/// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerAgentCd
		{
			get{return _customerAgentCd;}
			set{_customerAgentCd = value;}
		}

		/// public propaty name  :  CustomerAgentNm
		/// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerAgentNm
		{
			get{return _customerAgentNm;}
			set{_customerAgentNm = value;}
		}

		/// public propaty name  :  BillCollecterCd
		/// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterCd
		{
			get{return _billCollecterCd;}
			set{_billCollecterCd = value;}
		}

		/// public propaty name  :  BillCollecterNm
		/// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterNm
		{
			get{return _billCollecterNm;}
			set{_billCollecterNm = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>����œ]�ŕ����v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
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

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>���z�\�����@�敪�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
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

		/// public propaty name  :  TotalAmntDspWayRef
		/// <summary>���z�\�����@�Q�Ƌ敪�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0:�S�̐ݒ�Q�� 1:���Ӑ�Q��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���z�\�����@�Q�Ƌ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalAmntDspWayRef
		{
			get{return _totalAmntDspWayRef;}
			set{_totalAmntDspWayRef = value;}
		}

		/// public propaty name  :  SalesCnsTaxFrcProcCd
		/// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesCnsTaxFrcProcCd
		{
			get{return _salesCnsTaxFrcProcCd;}
			set{_salesCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  AccountNoInfo1
		/// <summary>��s����1�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s����1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AccountNoInfo1
		{
			get{return _accountNoInfo1;}
			set{_accountNoInfo1 = value;}
		}

		/// public propaty name  :  AccountNoInfo2
		/// <summary>��s����2�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AccountNoInfo2
		{
			get{return _accountNoInfo2;}
			set{_accountNoInfo2 = value;}
		}

		/// public propaty name  :  AccountNoInfo3
		/// <summary>��s����3�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s����3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AccountNoInfo3
		{
			get{return _accountNoInfo3;}
			set{_accountNoInfo3 = value;}
		}

		/// public propaty name  :  CorporateDivCode
		/// <summary>�l�E�@�l�敪�v���p�e�B</summary>
		/// <value>���Ӑ�}�X�^����擾 0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�E�@�l�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CorporateDivCode
		{
			get{return _corporateDivCode;}
			set{_corporateDivCode = value;}
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

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>�v��N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  LastTimeDemand
		/// <summary>�O�񐿋����z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�񐿋����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 LastTimeDemand
		{
			get{return _lastTimeDemand;}
			set{_lastTimeDemand = value;}
		}

		/// public propaty name  :  ThisTimeFeeDmdNrml
		/// <summary>����萔���z�i�ʏ�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����萔���z�i�ʏ�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeFeeDmdNrml
		{
			get{return _thisTimeFeeDmdNrml;}
			set{_thisTimeFeeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDisDmdNrml
		/// <summary>����l���z�i�ʏ�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l���z�i�ʏ�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeDisDmdNrml
		{
			get{return _thisTimeDisDmdNrml;}
			set{_thisTimeDisDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDmdNrml
		/// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
		/// <value>�����z�̍��v���z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeDmdNrml
		{
			get{return _thisTimeDmdNrml;}
			set{_thisTimeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcDmd
		/// <summary>����J�z�c���i�����v�j�v���p�e�B</summary>
		/// <value>����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����J�z�c���i�����v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcDmd
		{
			get{return _thisTimeTtlBlcDmd;}
			set{_thisTimeTtlBlcDmd = value;}
		}

		/// public propaty name  :  OfsThisTimeSales
		/// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisTimeSales
		{
			get{return _ofsThisTimeSales;}
			set{_ofsThisTimeSales = value;}
		}

		/// public propaty name  :  OfsThisSalesTax
		/// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OfsThisSalesTax
		{
			get{return _ofsThisSalesTax;}
			set{_ofsThisSalesTax = value;}
		}

		/// public propaty name  :  ItdedOffsetOutTax
		/// <summary>���E��O�őΏۊz�v���p�e�B</summary>
		/// <value>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E��O�őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedOffsetOutTax
		{
			get{return _itdedOffsetOutTax;}
			set{_itdedOffsetOutTax = value;}
		}

		/// public propaty name  :  ItdedOffsetInTax
		/// <summary>���E����őΏۊz�v���p�e�B</summary>
		/// <value>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E����őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedOffsetInTax
		{
			get{return _itdedOffsetInTax;}
			set{_itdedOffsetInTax = value;}
		}

		/// public propaty name  :  ItdedOffsetTaxFree
		/// <summary>���E���ېőΏۊz�v���p�e�B</summary>
		/// <value>���E�p�F��ېŊz�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E���ېőΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedOffsetTaxFree
		{
			get{return _itdedOffsetTaxFree;}
			set{_itdedOffsetTaxFree = value;}
		}

		/// public propaty name  :  OffsetOutTax
		/// <summary>���E��O�ŏ���Ńv���p�e�B</summary>
		/// <value>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E��O�ŏ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OffsetOutTax
		{
			get{return _offsetOutTax;}
			set{_offsetOutTax = value;}
		}

		/// public propaty name  :  OffsetInTax
		/// <summary>���E����ŏ���Ńv���p�e�B</summary>
		/// <value>���E�p�F���ŏ���ł̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���E����ŏ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 OffsetInTax
		{
			get{return _offsetInTax;}
			set{_offsetInTax = value;}
		}

		/// public propaty name  :  ThisTimeSales
		/// <summary>���񔄏���z�v���p�e�B</summary>
		/// <value>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisTimeSales
		{
			get{return _thisTimeSales;}
			set{_thisTimeSales = value;}
		}

		/// public propaty name  :  ThisSalesTax
		/// <summary>���񔄏����Ńv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesTax
		{
			get{return _thisSalesTax;}
			set{_thisSalesTax = value;}
		}

		/// public propaty name  :  ItdedSalesOutTax
		/// <summary>����O�őΏۊz�v���p�e�B</summary>
		/// <value>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedSalesOutTax
		{
			get{return _itdedSalesOutTax;}
			set{_itdedSalesOutTax = value;}
		}

		/// public propaty name  :  ItdedSalesInTax
		/// <summary>������őΏۊz�v���p�e�B</summary>
		/// <value>�����p�F���Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedSalesInTax
		{
			get{return _itdedSalesInTax;}
			set{_itdedSalesInTax = value;}
		}

		/// public propaty name  :  ItdedSalesTaxFree
		/// <summary>�����ېőΏۊz�v���p�e�B</summary>
		/// <value>�����p�F��ېŊz�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ېőΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedSalesTaxFree
		{
			get{return _itdedSalesTaxFree;}
			set{_itdedSalesTaxFree = value;}
		}

		/// public propaty name  :  SalesOutTax
		/// <summary>����O�Ŋz�v���p�e�B</summary>
		/// <value>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����O�Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesOutTax
		{
			get{return _salesOutTax;}
			set{_salesOutTax = value;}
		}

		/// public propaty name  :  SalesInTax
		/// <summary>������Ŋz�v���p�e�B</summary>
		/// <value>�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesInTax
		{
			get{return _salesInTax;}
			set{_salesInTax = value;}
		}

		/// public propaty name  :  ThisSalesPricRgds
		/// <summary>���񔄏�ԕi���z�v���p�e�B</summary>
		/// <value>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�ԕi���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPricRgds
		{
			get{return _thisSalesPricRgds;}
			set{_thisSalesPricRgds = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxRgds
		/// <summary>���񔄏�ԕi����Ńv���p�e�B</summary>
		/// <value>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�ԕi����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxRgds
		{
			get{return _thisSalesPrcTaxRgds;}
			set{_thisSalesPrcTaxRgds = value;}
		}

		/// public propaty name  :  TtlItdedRetOutTax
		/// <summary>�ԕi�O�őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi�O�őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedRetOutTax
		{
			get{return _ttlItdedRetOutTax;}
			set{_ttlItdedRetOutTax = value;}
		}

		/// public propaty name  :  TtlItdedRetInTax
		/// <summary>�ԕi���őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedRetInTax
		{
			get{return _ttlItdedRetInTax;}
			set{_ttlItdedRetInTax = value;}
		}

		/// public propaty name  :  TtlItdedRetTaxFree
		/// <summary>�ԕi��ېőΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi��ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedRetTaxFree
		{
			get{return _ttlItdedRetTaxFree;}
			set{_ttlItdedRetTaxFree = value;}
		}

		/// public propaty name  :  TtlRetOuterTax
		/// <summary>�ԕi�O�Ŋz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi�O�Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlRetOuterTax
		{
			get{return _ttlRetOuterTax;}
			set{_ttlRetOuterTax = value;}
		}

		/// public propaty name  :  TtlRetInnerTax
		/// <summary>�ԕi���Ŋz���v�v���p�e�B</summary>
		/// <value>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlRetInnerTax
		{
			get{return _ttlRetInnerTax;}
			set{_ttlRetInnerTax = value;}
		}

		/// public propaty name  :  ThisSalesPricDis
		/// <summary>���񔄏�l�����z�v���p�e�B</summary>
		/// <value>�|���F�Ŕ����̔���l�����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�l�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPricDis
		{
			get{return _thisSalesPricDis;}
			set{_thisSalesPricDis = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxDis
		/// <summary>���񔄏�l������Ńv���p�e�B</summary>
		/// <value>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񔄏�l������Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxDis
		{
			get{return _thisSalesPrcTaxDis;}
			set{_thisSalesPrcTaxDis = value;}
		}

		/// public propaty name  :  TtlItdedDisOutTax
		/// <summary>�l���O�őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l���O�őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedDisOutTax
		{
			get{return _ttlItdedDisOutTax;}
			set{_ttlItdedDisOutTax = value;}
		}

		/// public propaty name  :  TtlItdedDisInTax
		/// <summary>�l�����őΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�����őΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedDisInTax
		{
			get{return _ttlItdedDisInTax;}
			set{_ttlItdedDisInTax = value;}
		}

		/// public propaty name  :  TtlItdedDisTaxFree
		/// <summary>�l����ېőΏۊz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l����ېőΏۊz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlItdedDisTaxFree
		{
			get{return _ttlItdedDisTaxFree;}
			set{_ttlItdedDisTaxFree = value;}
		}

		/// public propaty name  :  TtlDisOuterTax
		/// <summary>�l���O�Ŋz���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l���O�Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlDisOuterTax
		{
			get{return _ttlDisOuterTax;}
			set{_ttlDisOuterTax = value;}
		}

		/// public propaty name  :  TtlDisInnerTax
		/// <summary>�l�����Ŋz���v�v���p�e�B</summary>
		/// <value>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�����Ŋz���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TtlDisInnerTax
		{
			get{return _ttlDisInnerTax;}
			set{_ttlDisInnerTax = value;}
		}

		/// public propaty name  :  ThisPayOffset
		/// <summary>����x�����E���z�v���p�e�B</summary>
		/// <value>���E�p�`�[�F���E�p����`�[�v�i���E�Ώۊz�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����x�����E���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisPayOffset
		{
			get{return _thisPayOffset;}
			set{_thisPayOffset = value;}
		}

		/// public propaty name  :  ThisPayOffsetTax
		/// <summary>����x�����E����Ńv���p�e�B</summary>
		/// <value>���E�p�`�[�F���E�p�������ō��v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����x�����E����Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ThisPayOffsetTax
		{
			get{return _thisPayOffsetTax;}
			set{_thisPayOffsetTax = value;}
		}

		/// public propaty name  :  ItdedPaymOutTax
		/// <summary>�x���O�őΏۊz�v���p�e�B</summary>
		/// <value>���E�p�`�[�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���O�őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedPaymOutTax
		{
			get{return _itdedPaymOutTax;}
			set{_itdedPaymOutTax = value;}
		}

		/// public propaty name  :  ItdedPaymInTax
		/// <summary>�x�����őΏۊz�v���p�e�B</summary>
		/// <value>���E�p�`�[�F���Ŋz�i�Ŕ����j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����őΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedPaymInTax
		{
			get{return _itdedPaymInTax;}
			set{_itdedPaymInTax = value;}
		}

		/// public propaty name  :  ItdedPaymTaxFree
		/// <summary>�x����ېőΏۊz�v���p�e�B</summary>
		/// <value>���E�p�`�[�F��ېŊz�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����ېőΏۊz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ItdedPaymTaxFree
		{
			get{return _itdedPaymTaxFree;}
			set{_itdedPaymTaxFree = value;}
		}

		/// public propaty name  :  PaymentOutTax
		/// <summary>�x���O�ŏ���Ńv���p�e�B</summary>
		/// <value>���E�p�`�[�F�O�ŏ���ł̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���O�ŏ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 PaymentOutTax
		{
			get{return _paymentOutTax;}
			set{_paymentOutTax = value;}
		}

		/// public propaty name  :  PaymentInTax
		/// <summary>�x�����ŏ���Ńv���p�e�B</summary>
		/// <value>���E�p�`�[�F���ŏ���ł̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����ŏ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 PaymentInTax
		{
			get{return _paymentInTax;}
			set{_paymentInTax = value;}
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
			get{return _taxAdjust;}
			set{_taxAdjust = value;}
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
			get{return _balanceAdjust;}
			set{_balanceAdjust = value;}
		}

		/// public propaty name  :  AfCalDemandPrice
		/// <summary>�v�Z�㐿�����z�v���p�e�B</summary>
		/// <value>���񐿋����z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�Z�㐿�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 AfCalDemandPrice
		{
			get{return _afCalDemandPrice;}
			set{_afCalDemandPrice = value;}
		}

		/// public propaty name  :  AcpOdrTtl2TmBfBlDmd
		/// <summary>��2��O�c���i�����v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��2��O�c���i�����v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 AcpOdrTtl2TmBfBlDmd
		{
			get{return _acpOdrTtl2TmBfBlDmd;}
			set{_acpOdrTtl2TmBfBlDmd = value;}
		}

		/// public propaty name  :  AcpOdrTtl3TmBfBlDmd
		/// <summary>��3��O�c���i�����v�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��3��O�c���i�����v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 AcpOdrTtl3TmBfBlDmd
		{
			get{return _acpOdrTtl3TmBfBlDmd;}
			set{_acpOdrTtl3TmBfBlDmd = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>�����X�V���s�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  StartCAddUpUpdDate
		/// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StartCAddUpUpdDate
		{
			get{return _startCAddUpUpdDate;}
			set{_startCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>�O������X�V�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get{return _lastCAddUpUpdDate;}
			set{_lastCAddUpUpdDate = value;}
		}

		/// public propaty name  :  SalesSlipCount
		/// <summary>����`�[�����v���p�e�B</summary>
		/// <value>�|���̓`�[����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCount
		{
			get{return _salesSlipCount;}
			set{_salesSlipCount = value;}
		}

		/// public propaty name  :  BillPrintDate
		/// <summary>���������s���v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �������𔭍s�����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������s���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime BillPrintDate
		{
			get{return _billPrintDate;}
			set{_billPrintDate = value;}
		}

		/// public propaty name  :  ExpectedDepositDate
		/// <summary>�����\����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ExpectedDepositDate
		{
			get{return _expectedDepositDate;}
			set{_expectedDepositDate = value;}
		}

		/// public propaty name  :  CollectCond
		/// <summary>��������v���p�e�B</summary>
		/// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectCond
		{
			get{return _collectCond;}
			set{_collectCond = value;}
		}

		/// public propaty name  :  ConsTaxRate
		/// <summary>����ŗ��v���p�e�B</summary>
		/// <value>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ConsTaxRate
		{
			get{return _consTaxRate;}
			set{_consTaxRate = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>�[�������敪�v���p�e�B</summary>
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

		/// public propaty name  :  MoneyKindList
		/// <summary>����R�[�h���X�g�v���p�e�B</summary>
		/// <value>(����R�[�h�A���햼�́A�������z�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����R�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList MoneyKindList
		{
			get{return _moneyKindList;}
			set{_moneyKindList = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
		/// <value>�`�[����ݒ�p</value>
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  ClaimSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  ResultsSectCd
        /// <summary>���ы��_�R�[�h�v���p�e�B</summary>
        /// <value>���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ы��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsSectCd
        {
            get { return _resultsSectCd; }
            set { _resultsSectCd = value; }
        }

        /// public propaty name  :  BillOutputCode
        /// <summary>�������o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���������s����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillOutputCode
        {
            get { return _billOutputCode; }
            set { _billOutputCode = value; }
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

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>�̎����o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����o�͋敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiptOutputCode
        {
            get { return _receiptOutputCode; }
            set { _receiptOutputCode = value; }
        }

        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>���א������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>�`�[���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }

        /// public propaty name  :  TitleTaxRate1
        /// <summary>�ŗ�1�^�C�g��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleTaxRate1
        {
            get { return _titleTaxRate1; }
            set { _titleTaxRate1 = value; }
        }

        /// public propaty name  :  TitleTaxRate2
        /// <summary>�ŗ�2�^�C�g��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleTaxRate2
        {
            get { return _titleTaxRate2; }
            set { _titleTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxRate1
        /// <summary>����z(�v�ŗ�1) </summary>
        /// <value>����z(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate1
        {
            get { return _totalThisTimeSalesTaxRate1; }
            set { _totalThisTimeSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxRate2
        /// <summary>����z(�v�ŗ�2) </summary>
        /// <value>����z(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate2
        {
            get { return _totalThisTimeSalesTaxRate2; }
            set { _totalThisTimeSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesOther
        /// <summary>����z(�v���̑�) </summary>
        /// <value>����z(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesOther
        {
            get { return _totalThisTimeSalesOther; }
            set { _totalThisTimeSalesOther = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate1
        /// <summary>�ԕi�l��(�v�ŗ�1) </summary>
        /// <value>�ԕi�l��(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate1
        {
            get { return _totalThisRgdsDisPricTaxRate1; }
            set { _totalThisRgdsDisPricTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate2
        /// <summary>�ԕi�l��(�v�ŗ�2) </summary>
        /// <value>�ԕi�l��(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate2
        {
            get { return _totalThisRgdsDisPricTaxRate2; }
            set { _totalThisRgdsDisPricTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricOther
        /// <summary>�ԕi�l��(�v���̑�) </summary>
        /// <value>�ԕi�l��(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricOther
        {
            get { return _totalThisRgdsDisPricOther; }
            set { _totalThisRgdsDisPricOther = value; }
        }

        /// public propaty name  :  TotalPureSalesTaxRate1
        /// <summary>������z(�v�ŗ�1) </summary>
        /// <value>������z(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate1
        {
            get { return _totalPureSalesTaxRate1; }
            set { _totalPureSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalPureSalesTaxRate2
        /// <summary>������z(�v�ŗ�2) </summary>
        /// <value>������z(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate2
        {
            get { return _totalPureSalesTaxRate2; }
            set { _totalPureSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalPureSalesOther
        /// <summary>������z(�v���̑�) </summary>
        /// <value>������z(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesOther
        {
            get { return _totalPureSalesOther; }
            set { _totalPureSalesOther = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate1
        /// <summary>�����(�v�ŗ�1) </summary>
        /// <value>�����(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate1
        {
            get { return _totalSalesPricTaxTaxRate1; }
            set { _totalSalesPricTaxTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate2
        /// <summary>�����(�v�ŗ�2) </summary>
        /// <value>�����(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate2
        {
            get { return _totalSalesPricTaxTaxRate2; }
            set { _totalSalesPricTaxTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxOther
        /// <summary>�����(�v���̑�) </summary>
        /// <value>�����(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxOther
        {
            get { return _totalSalesPricTaxOther; }
            set { _totalSalesPricTaxOther = value; }
        }

        /// public propaty name  :  TotalThisSalesSumTaxRate1
        /// <summary>�������v(�v�ŗ�1) </summary>
        /// <value>�������v(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxRate1
        {
            get { return _totalThisSalesSumTaxRate1; }
            set { _totalThisSalesSumTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisSalesSumTaxRate2
        /// <summary>�������v(�v�ŗ�2) </summary>
        /// <value>�������v(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxRate2
        {
            get { return _totalThisSalesSumTaxRate2; }
            set { _totalThisSalesSumTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisSalesSumTaxOther
        /// <summary>�������v(�v���̑�) </summary>
        /// <value>�������v(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxOther
        {
            get { return _totalThisSalesSumTaxOther; }
            set { _totalThisSalesSumTaxOther = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate1
        /// <summary>����(�v�ŗ�1) </summary>
        /// <value>����(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate1
        {
            get { return _totalSalesSlipCountTaxRate1; }
            set { _totalSalesSlipCountTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate2
        /// <summary>����(�v�ŗ�2) </summary>
        /// <value>����(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate2
        {
            get { return _totalSalesSlipCountTaxRate2; }
            set { _totalSalesSlipCountTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountOther
        /// <summary>����(�v���̑�) </summary>
        /// <value>����(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountOther
        {
            get { return _totalSalesSlipCountOther; }
            set { _totalSalesSlipCountOther = value; }
        }

        // --- ADD START 3H ���� 2022/10/27 ----->>>>>
        /// public propaty name  :  TotalThisTimeSalesTaxFree
        /// <summary>����z(��ې�)�v���p�e�B</summary>
        /// <value>����z(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxFree
        {
            get { return _totalThisTimeSalesTaxFree; }
            set { _totalThisTimeSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalThisRgdsDisPricTaxFree
        /// <summary>�ԕi�l��(��ې�)�v���p�e�B</summary>
        /// <value>�ԕi�l��(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxFree
        {
            get { return _totalThisRgdsDisPricTaxFree; }
            set { _totalThisRgdsDisPricTaxFree = value; }
        }
        /// public propaty name  :  TotalPureSalesTaxFree
        /// <summary>������z(��ې�)�v���p�e�B</summary>
        /// <value>������z(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ������z(��ې�)�v���p�e�B</br>
        /// <br>Programer        :  ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxFree
        {
            get { return _totalPureSalesTaxFree; }
            set { _totalPureSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalSalesPricTaxTaxFree
        /// <summary>�����(��ې�)�v���p�e�B</summary>
        /// <value>�����(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �����(��ې�)�v���p�e�B</br>
        /// <br>Programer        :  ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxFree
        {
            get { return _totalSalesPricTaxTaxFree; }
            set { _totalSalesPricTaxTaxFree = value; }
        }

        /// public propaty name  :  TtotalThisSalesSumTaxFree
        /// <summary>���񍇌v(��ې�)�v���p�e�B</summary>
        /// <value>���񍇌v(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���񍇌v(��ې�)�v���p�e�B</br>
        /// <br>Programer        :  ��������</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxFree
        {
            get { return _totalThisSalesSumTaxFree; }
            set { _totalThisSalesSumTaxFree = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxFree
        /// <summary>����(��ې�)�v���p�e�B</summary>
        /// <value>����(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ����(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxFree
        {
            get { return _totalSalesSlipCountTaxFree; }
            set { _totalSalesSlipCountTaxFree = value; }
        }
        // --- ADD END 3H ���� 2022/10/27 -----<<<<<

		/// <summary>
		/// ������(�ӕ�)���o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>RsltInfo_EBooksDemandTotalWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RsltInfo_EBooksDemandTotalWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RsltInfo_EBooksDemandTotalWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_EBooksDemandTotalWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_EBooksDemandTotalWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer       :   3H ����</br>
    /// <br>Date             :   2022/10/27</br>
    /// </remarks>
    public class RsltInfo_EBooksDemandTotalWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate �����o
    	
	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_EBooksDemandTotalWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer       :   3H ����</br>
        /// <br>Date             :   2022/10/27</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  RsltInfo_EBooksDemandTotalWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is RsltInfo_EBooksDemandTotalWork || graph is ArrayList || graph is RsltInfo_EBooksDemandTotalWork[]) )
			    throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_EBooksDemandTotalWork).FullName ) );

		    if( graph != null && graph is RsltInfo_EBooksDemandTotalWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_EBooksDemandTotalWork" );

		    //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		    int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is RsltInfo_EBooksDemandTotalWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((RsltInfo_EBooksDemandTotalWork[])graph).Length;
		    }
		    else if( graph is RsltInfo_EBooksDemandTotalWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		    //��ƃR�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		    //�v�㋒�_�R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //AddUpSecCode
		    //�v�㋒�_����
		    serInfo.MemberInfo.Add( typeof(string) ); //AddUpSecName
		    //������R�[�h
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ClaimCode
		    //�����於��
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimName
		    //�����於��2
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimName2
		    //�����旪��
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimSnm
		    //�����於�̃J�i
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimNameKana
		    //�X�֔ԍ�
		    serInfo.MemberInfo.Add( typeof(string) ); //PostNo
		    //�Z��1�i�s���{���s��S�E�����E���j
		    serInfo.MemberInfo.Add( typeof(string) ); //Address1
		    //�Z��2�i���ځj
		    serInfo.MemberInfo.Add( typeof(Int32) ); //Address2
		    //�Z��3�i�Ԓn�j
		    serInfo.MemberInfo.Add( typeof(string) ); //Address3
		    //�Z��4�i�A�p�[�g���́j
		    serInfo.MemberInfo.Add( typeof(string) ); //Address4
		    //�W�����敪�R�[�h
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CollectMoneyCode
		    //�W�����敪����
		    serInfo.MemberInfo.Add( typeof(string) ); //CollectMoneyName
		    //�W����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CollectMoneyDay
		    //�h��
		    serInfo.MemberInfo.Add( typeof(string) ); //HonorificTitle
		    //�d�b�ԍ��i����j
		    serInfo.MemberInfo.Add( typeof(string) ); //HomeTelNo
		    //�d�b�ԍ��i�Ζ���j
		    serInfo.MemberInfo.Add( typeof(string) ); //OfficeTelNo
		    //�d�b�ԍ��i�g�сj
		    serInfo.MemberInfo.Add( typeof(string) ); //PortableTelNo
		    //FAX�ԍ��i����j
		    serInfo.MemberInfo.Add( typeof(string) ); //HomeFaxNo
		    //FAX�ԍ��i�Ζ���j
		    serInfo.MemberInfo.Add( typeof(string) ); //OfficeFaxNo
		    //�d�b�ԍ��i���̑��j
		    serInfo.MemberInfo.Add( typeof(string) ); //OthersTelNo
		    //��A����敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //MainContactCode
		    //����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //TotalDay
		    //�ڋq�S���]�ƈ��R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerAgentCd
		    //�ڋq�S���]�ƈ�����
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerAgentNm
		    //�W���S���]�ƈ��R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //BillCollecterCd
		    //�W���S���]�ƈ�����
		    serInfo.MemberInfo.Add( typeof(string) ); //BillCollecterNm
		    //����œ]�ŕ���
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ConsTaxLayMethod
		    //���z�\�����@�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //TotalAmountDispWayCd
		    //���z�\�����@�Q�Ƌ敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //TotalAmntDspWayRef
		    //�������Œ[�������R�[�h
		    serInfo.MemberInfo.Add( typeof(Int32) ); //SalesCnsTaxFrcProcCd
		    //��s����1
		    serInfo.MemberInfo.Add( typeof(string) ); //AccountNoInfo1
		    //��s����2
		    serInfo.MemberInfo.Add( typeof(string) ); //AccountNoInfo2
		    //��s����3
		    serInfo.MemberInfo.Add( typeof(string) ); //AccountNoInfo3
		    //�l�E�@�l�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CorporateDivCode
		    //���Ӑ�R�[�h
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		    //���Ӑ於��
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerName
		    //���Ӑ於��2
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerName2
		    //���Ӑ旪��
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerSnm
		    //�v��N����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AddUpDate
		    //�v��N��
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AddUpYearMonth
		    //�O�񐿋����z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //LastTimeDemand
		    //����萔���z�i�ʏ�����j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeFeeDmdNrml
		    //����l���z�i�ʏ�����j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeDisDmdNrml
		    //����������z�i�ʏ�����j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeDmdNrml
		    //����J�z�c���i�����v�j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeTtlBlcDmd
		    //���E�㍡�񔄏���z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OfsThisTimeSales
		    //���E�㍡�񔄏�����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OfsThisSalesTax
		    //���E��O�őΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedOffsetOutTax
		    //���E����őΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedOffsetInTax
		    //���E���ېőΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedOffsetTaxFree
		    //���E��O�ŏ����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OffsetOutTax
		    //���E����ŏ����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OffsetInTax
		    //���񔄏���z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeSales
		    //���񔄏�����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesTax
		    //����O�őΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedSalesOutTax
		    //������őΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedSalesInTax
		    //�����ېőΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedSalesTaxFree
		    //����O�Ŋz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesOutTax
		    //������Ŋz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesInTax
		    //���񔄏�ԕi���z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPricRgds
		    //���񔄏�ԕi�����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPrcTaxRgds
		    //�ԕi�O�őΏۊz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedRetOutTax
		    //�ԕi���őΏۊz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedRetInTax
		    //�ԕi��ېőΏۊz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedRetTaxFree
		    //�ԕi�O�Ŋz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlRetOuterTax
		    //�ԕi���Ŋz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlRetInnerTax
		    //���񔄏�l�����z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPricDis
		    //���񔄏�l�������
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPrcTaxDis
		    //�l���O�őΏۊz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedDisOutTax
		    //�l�����őΏۊz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedDisInTax
		    //�l����ېőΏۊz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedDisTaxFree
		    //�l���O�Ŋz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlDisOuterTax
		    //�l�����Ŋz���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlDisInnerTax
		    //����x�����E���z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisPayOffset
		    //����x�����E�����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisPayOffsetTax
		    //�x���O�őΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedPaymOutTax
		    //�x�����őΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedPaymInTax
		    //�x����ېőΏۊz
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedPaymTaxFree
		    //�x���O�ŏ����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //PaymentOutTax
		    //�x�����ŏ����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //PaymentInTax
		    //����Œ����z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TaxAdjust
		    //�c�������z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //BalanceAdjust
		    //�v�Z�㐿�����z
		    serInfo.MemberInfo.Add( typeof(Int64) ); //AfCalDemandPrice
		    //��2��O�c���i�����v�j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //AcpOdrTtl2TmBfBlDmd
		    //��3��O�c���i�����v�j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //AcpOdrTtl3TmBfBlDmd
		    //�����X�V���s�N����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CAddUpUpdExecDate
		    //�����X�V�J�n�N����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //StartCAddUpUpdDate
		    //�O������X�V�N����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //LastCAddUpUpdDate
		    //����`�[����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //SalesSlipCount
		    //���������s��
		    serInfo.MemberInfo.Add( typeof(Int32) ); //BillPrintDate
		    //�����\���
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ExpectedDepositDate
		    //�������
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CollectCond
		    //����ŗ�
		    serInfo.MemberInfo.Add( typeof(Double) ); //ConsTaxRate
		    //�[�������敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //FractionProcCd            
		    //����R�[�h���X�g
		    serInfo.MemberInfo.Add( typeof(ArrayList) ); //MoneyKindList
		    //�`�[����ݒ�p���[ID
		    serInfo.MemberInfo.Add( typeof(string) ); //SlipPrtSetPaperId
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSectionCode
            //���ы��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
            //�������o�͋敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BillOutputCode
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //�̎����o�͋敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiptOutputCode
            //���v�������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalBillOutputDiv
            //���א������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailBillOutputCode
            //�`�[���v�������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlBillOutputDiv
            // ����z(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate1
            // ����z(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate2
            // ����z(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesOther
            // �ԕi�l��(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate1
            // �ԕi�l��(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate2
            // �ԕi�l��(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricOther
            // ������z(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate1
            // ������z(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate2
            // ������z(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesOther
            // �����(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate1
            // �����(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate2
            // �����(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTax_Other
            // �������v(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxRate1
            // �������v(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxRate2
            // �������v(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxOther
            // ����(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate1
            // ����(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate2
            // ����(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountOther
            // �ŗ�1�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // �ŗ�2�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // --- ADD START 3H ���� 2022/10/27 ----->>>>>
            // ����z(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxFree
            // �ԕi�l��(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxFree
            // ������z(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxFree
            // �����(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxFree
            // ���񍇌v(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxFree
            // ����(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxFree
            // --- ADD END 3H ���� 2022/10/27 -----<<<<<

		    serInfo.Serialize( writer, serInfo );
		    if( graph is RsltInfo_EBooksDemandTotalWork )
		    {
			    RsltInfo_EBooksDemandTotalWork temp = (RsltInfo_EBooksDemandTotalWork)graph;

			    SetRsltInfo_EBooksDemandTotalWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is RsltInfo_EBooksDemandTotalWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((RsltInfo_EBooksDemandTotalWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(RsltInfo_EBooksDemandTotalWork temp in lst)
			    {
				    SetRsltInfo_EBooksDemandTotalWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// RsltInfo_EBooksDemandTotalWork�����o��(public�v���p�e�B��)
	    /// </summary>
        //private const int currentMemberCount = 129; // DEL 3H ���� 2022/10/27
        private const int currentMemberCount = 135; // ADD 3H ���� 2022/10/27

	    /// <summary>
	    ///  RsltInfo_EBooksDemandTotalWork�C���X�^���X��������
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_EBooksDemandTotalWork�̃C���X�^���X����������</br>
	    /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer       :   3H ����</br>
        /// <br>Date             :   2022/10/27</br>
	    /// </remarks>
	    private void SetRsltInfo_EBooksDemandTotalWork( System.IO.BinaryWriter writer, RsltInfo_EBooksDemandTotalWork temp )
	    {
		    //��ƃR�[�h
		    writer.Write( temp.EnterpriseCode );
		    //�v�㋒�_�R�[�h
		    writer.Write( temp.AddUpSecCode );
		    //�v�㋒�_����
		    writer.Write( temp.AddUpSecName );
		    //������R�[�h
		    writer.Write( temp.ClaimCode );
		    //�����於��
		    writer.Write( temp.ClaimName );
		    //�����於��2
		    writer.Write( temp.ClaimName2 );
		    //�����旪��
		    writer.Write( temp.ClaimSnm );
		    //�����於�̃J�i
		    writer.Write( temp.ClaimNameKana );
		    //�X�֔ԍ�
		    writer.Write( temp.PostNo );
		    //�Z��1�i�s���{���s��S�E�����E���j
		    writer.Write( temp.Address1 );
		    //�Z��2�i���ځj
		    writer.Write( temp.Address2 );
		    //�Z��3�i�Ԓn�j
		    writer.Write( temp.Address3 );
		    //�Z��4�i�A�p�[�g���́j
		    writer.Write( temp.Address4 );
		    //�W�����敪�R�[�h
		    writer.Write( temp.CollectMoneyCode );
		    //�W�����敪����
		    writer.Write( temp.CollectMoneyName );
		    //�W����
		    writer.Write( temp.CollectMoneyDay );
		    //�h��
		    writer.Write( temp.HonorificTitle );
		    //�d�b�ԍ��i����j
		    writer.Write( temp.HomeTelNo );
		    //�d�b�ԍ��i�Ζ���j
		    writer.Write( temp.OfficeTelNo );
		    //�d�b�ԍ��i�g�сj
		    writer.Write( temp.PortableTelNo );
		    //FAX�ԍ��i����j
		    writer.Write( temp.HomeFaxNo );
		    //FAX�ԍ��i�Ζ���j
		    writer.Write( temp.OfficeFaxNo );
		    //�d�b�ԍ��i���̑��j
		    writer.Write( temp.OthersTelNo );
		    //��A����敪
		    writer.Write( temp.MainContactCode );
		    //����
		    writer.Write( temp.TotalDay );
		    //�ڋq�S���]�ƈ��R�[�h
		    writer.Write( temp.CustomerAgentCd );
		    //�ڋq�S���]�ƈ�����
		    writer.Write( temp.CustomerAgentNm );
		    //�W���S���]�ƈ��R�[�h
		    writer.Write( temp.BillCollecterCd );
		    //�W���S���]�ƈ�����
		    writer.Write( temp.BillCollecterNm );
		    //����œ]�ŕ���
		    writer.Write( temp.ConsTaxLayMethod );
		    //���z�\�����@�敪
		    writer.Write( temp.TotalAmountDispWayCd );
		    //���z�\�����@�Q�Ƌ敪
		    writer.Write( temp.TotalAmntDspWayRef );
		    //�������Œ[�������R�[�h
		    writer.Write( temp.SalesCnsTaxFrcProcCd );
		    //��s����1
		    writer.Write( temp.AccountNoInfo1 );
		    //��s����2
		    writer.Write( temp.AccountNoInfo2 );
		    //��s����3
		    writer.Write( temp.AccountNoInfo3 );
		    //�l�E�@�l�敪
		    writer.Write( temp.CorporateDivCode );
		    //���Ӑ�R�[�h
		    writer.Write( temp.CustomerCode );
		    //���Ӑ於��
		    writer.Write( temp.CustomerName );
		    //���Ӑ於��2
		    writer.Write( temp.CustomerName2 );
		    //���Ӑ旪��
		    writer.Write( temp.CustomerSnm );
		    //�v��N����
		    writer.Write( (Int64)temp.AddUpDate.Ticks );
		    //�v��N��
		    writer.Write( (Int64)temp.AddUpYearMonth.Ticks );
		    //�O�񐿋����z
		    writer.Write( temp.LastTimeDemand );
		    //����萔���z�i�ʏ�����j
		    writer.Write( temp.ThisTimeFeeDmdNrml );
		    //����l���z�i�ʏ�����j
		    writer.Write( temp.ThisTimeDisDmdNrml );
		    //����������z�i�ʏ�����j
		    writer.Write( temp.ThisTimeDmdNrml );
		    //����J�z�c���i�����v�j
		    writer.Write( temp.ThisTimeTtlBlcDmd );
		    //���E�㍡�񔄏���z
		    writer.Write( temp.OfsThisTimeSales );
		    //���E�㍡�񔄏�����
		    writer.Write( temp.OfsThisSalesTax );
		    //���E��O�őΏۊz
		    writer.Write( temp.ItdedOffsetOutTax );
		    //���E����őΏۊz
		    writer.Write( temp.ItdedOffsetInTax );
		    //���E���ېőΏۊz
		    writer.Write( temp.ItdedOffsetTaxFree );
		    //���E��O�ŏ����
		    writer.Write( temp.OffsetOutTax );
		    //���E����ŏ����
		    writer.Write( temp.OffsetInTax );
		    //���񔄏���z
		    writer.Write( temp.ThisTimeSales );
		    //���񔄏�����
		    writer.Write( temp.ThisSalesTax );
		    //����O�őΏۊz
		    writer.Write( temp.ItdedSalesOutTax );
		    //������őΏۊz
		    writer.Write( temp.ItdedSalesInTax );
		    //�����ېőΏۊz
		    writer.Write( temp.ItdedSalesTaxFree );
		    //����O�Ŋz
		    writer.Write( temp.SalesOutTax );
		    //������Ŋz
		    writer.Write( temp.SalesInTax );
		    //���񔄏�ԕi���z
		    writer.Write( temp.ThisSalesPricRgds );
		    //���񔄏�ԕi�����
		    writer.Write( temp.ThisSalesPrcTaxRgds );
		    //�ԕi�O�őΏۊz���v
		    writer.Write( temp.TtlItdedRetOutTax );
		    //�ԕi���őΏۊz���v
		    writer.Write( temp.TtlItdedRetInTax );
		    //�ԕi��ېőΏۊz���v
		    writer.Write( temp.TtlItdedRetTaxFree );
		    //�ԕi�O�Ŋz���v
		    writer.Write( temp.TtlRetOuterTax );
		    //�ԕi���Ŋz���v
		    writer.Write( temp.TtlRetInnerTax );
		    //���񔄏�l�����z
		    writer.Write( temp.ThisSalesPricDis );
		    //���񔄏�l�������
		    writer.Write( temp.ThisSalesPrcTaxDis );
		    //�l���O�őΏۊz���v
		    writer.Write( temp.TtlItdedDisOutTax );
		    //�l�����őΏۊz���v
		    writer.Write( temp.TtlItdedDisInTax );
		    //�l����ېőΏۊz���v
		    writer.Write( temp.TtlItdedDisTaxFree );
		    //�l���O�Ŋz���v
		    writer.Write( temp.TtlDisOuterTax );
		    //�l�����Ŋz���v
		    writer.Write( temp.TtlDisInnerTax );
		    //����x�����E���z
		    writer.Write( temp.ThisPayOffset );
		    //����x�����E�����
		    writer.Write( temp.ThisPayOffsetTax );
		    //�x���O�őΏۊz
		    writer.Write( temp.ItdedPaymOutTax );
		    //�x�����őΏۊz
		    writer.Write( temp.ItdedPaymInTax );
		    //�x����ېőΏۊz
		    writer.Write( temp.ItdedPaymTaxFree );
		    //�x���O�ŏ����
		    writer.Write( temp.PaymentOutTax );
		    //�x�����ŏ����
		    writer.Write( temp.PaymentInTax );
		    //����Œ����z
		    writer.Write( temp.TaxAdjust );
		    //�c�������z
		    writer.Write( temp.BalanceAdjust );
		    //�v�Z�㐿�����z
		    writer.Write( temp.AfCalDemandPrice );
		    //��2��O�c���i�����v�j
		    writer.Write( temp.AcpOdrTtl2TmBfBlDmd );
		    //��3��O�c���i�����v�j
		    writer.Write( temp.AcpOdrTtl3TmBfBlDmd );
		    //�����X�V���s�N����
		    writer.Write( (Int64)temp.CAddUpUpdExecDate.Ticks );
		    //�����X�V�J�n�N����
		    writer.Write( (Int64)temp.StartCAddUpUpdDate.Ticks );
		    //�O������X�V�N����
		    writer.Write( (Int64)temp.LastCAddUpUpdDate.Ticks );
		    //����`�[����
		    writer.Write( temp.SalesSlipCount );
		    //���������s��
		    writer.Write( (Int64)temp.BillPrintDate.Ticks );
		    //�����\���
		    writer.Write( (Int64)temp.ExpectedDepositDate.Ticks );
		    //�������
		    writer.Write( temp.CollectCond );
		    //����ŗ�
		    writer.Write( temp.ConsTaxRate );
		    //�[�������敪
		    writer.Write( temp.FractionProcCd ); 

            writer.Write(temp.MoneyKindList.Count);
            for (int cnt = 0; cnt < temp.MoneyKindList.Count; cnt++)
            {
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).MoneyKindCode);
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).MoneyKindName);
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).MoneyKindDiv);
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).Deposit);
            }
            
           
            //�`�[����ݒ�p���[ID
		    writer.Write( temp.SlipPrtSetPaperId );
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //�������_�R�[�h
            writer.Write(temp.ClaimSectionCode);
            //���ы��_�R�[�h
            writer.Write(temp.ResultsSectCd);
            //�������o�͋敪�R�[�h
            writer.Write(temp.BillOutputCode);
            //���|�敪
            writer.Write(temp.AccRecDivCd);

            //�̎����o�͋敪�R�[�h
            writer.Write(temp.ReceiptOutputCode);
            //���v�������o�͋敪
            writer.Write(temp.TotalBillOutputDiv);
            //���א������o�͋敪
            writer.Write(temp.DetailBillOutputCode);
            //�`�[���v�������o�͋敪
            writer.Write(temp.SlipTtlBillOutputDiv);

            //����z(�v�ŗ�1)
            writer.Write(temp.TotalThisTimeSalesTaxRate1);
            //����z(�v�ŗ�2)
            writer.Write(temp.TotalThisTimeSalesTaxRate2);
            //����z(�v���̑�)
            writer.Write(temp.TotalThisTimeSalesOther);
            //�ԕi�l��(�v�ŗ�1)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate1);
            //�ԕi�l��(�v�ŗ�2)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate2);
            //�ԕi�l��(�v���̑�)
            writer.Write(temp.TotalThisRgdsDisPricOther);
            //������z(�v�ŗ�1)
            writer.Write(temp.TotalPureSalesTaxRate1);
            //������z(�v�ŗ�2)
            writer.Write(temp.TotalPureSalesTaxRate2);
            //������z(�v���̑�)
            writer.Write(temp.TotalPureSalesOther);
            //�����(�v�ŗ�1)
            writer.Write(temp.TotalSalesPricTaxTaxRate1);
            //�����(�v�ŗ�2)
            writer.Write(temp.TotalSalesPricTaxTaxRate2);
            //�����(�v���̑�)
            writer.Write(temp.TotalSalesPricTaxOther);
            //�������v(�v�ŗ�1)
            writer.Write(temp.TotalThisSalesSumTaxRate1);
            //�������v(�v�ŗ�2)
            writer.Write(temp.TotalThisSalesSumTaxRate2);
            //�������v(�v���̑�)
            writer.Write(temp.TotalThisSalesSumTaxOther);
            //����(�v�ŗ�1)
            writer.Write(temp.TotalSalesSlipCountTaxRate1);
            //����(�v�ŗ�2)
            writer.Write(temp.TotalSalesSlipCountTaxRate2);
            //����(�v���̑�)
            writer.Write(temp.TotalSalesSlipCountOther);
            //�ŗ�1�^�C�g��
            writer.Write(temp.TitleTaxRate1);
            //�ŗ�2�^�C�g��
            writer.Write(temp.TitleTaxRate2);
            // --- ADD START 3H ���� 2022/10/27 ----->>>>>
            // ����z(�v��ې�)
            writer.Write(temp.TotalThisTimeSalesTaxFree);
            // �ԕi�l��(�v��ې�)
            writer.Write(temp.TotalThisRgdsDisPricTaxFree);
            // ���d���z(�v��ې�)
            writer.Write(temp.TotalPureSalesTaxFree);
            // �����(�v��ې�)
            writer.Write(temp.TotalSalesPricTaxTaxFree);
            // ���񍇌v(�v��ې�)
            writer.Write(temp.TotalThisSalesSumTaxFree);
            // ����(�v��ې�)
            writer.Write(temp.TotalSalesSlipCountTaxFree);
            // --- ADD END 3H ���� 2022/10/27 -----<<<<<
	    }

	    /// <summary>
	    ///  RsltInfo_EBooksDemandTotalWork�C���X�^���X�擾
	    /// </summary>
	    /// <returns>RsltInfo_EBooksDemandTotalWork�N���X�̃C���X�^���X</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_EBooksDemandTotalWork�̃C���X�^���X���擾���܂�</br>
	    /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer       :   3H ����</br>
        /// <br>Date             :   2022/10/27</br>
	    /// </remarks>
	    private RsltInfo_EBooksDemandTotalWork GetRsltInfo_EBooksDemandTotalWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		    RsltInfo_EBooksDemandTotalWork temp = new RsltInfo_EBooksDemandTotalWork();

		    //��ƃR�[�h
		    temp.EnterpriseCode = reader.ReadString();
		    //�v�㋒�_�R�[�h
		    temp.AddUpSecCode = reader.ReadString();
		    //�v�㋒�_����
		    temp.AddUpSecName = reader.ReadString();
		    //������R�[�h
		    temp.ClaimCode = reader.ReadInt32();
		    //�����於��
		    temp.ClaimName = reader.ReadString();
		    //�����於��2
		    temp.ClaimName2 = reader.ReadString();
		    //�����旪��
		    temp.ClaimSnm = reader.ReadString();
		    //�����於�̃J�i
		    temp.ClaimNameKana = reader.ReadString();
		    //�X�֔ԍ�
		    temp.PostNo = reader.ReadString();
		    //�Z��1�i�s���{���s��S�E�����E���j
		    temp.Address1 = reader.ReadString();
		    //�Z��2�i���ځj
		    temp.Address2 = reader.ReadInt32();
		    //�Z��3�i�Ԓn�j
		    temp.Address3 = reader.ReadString();
		    //�Z��4�i�A�p�[�g���́j
		    temp.Address4 = reader.ReadString();
		    //�W�����敪�R�[�h
		    temp.CollectMoneyCode = reader.ReadInt32();
		    //�W�����敪����
		    temp.CollectMoneyName = reader.ReadString();
		    //�W����
		    temp.CollectMoneyDay = reader.ReadInt32();
		    //�h��
		    temp.HonorificTitle = reader.ReadString();
		    //�d�b�ԍ��i����j
		    temp.HomeTelNo = reader.ReadString();
		    //�d�b�ԍ��i�Ζ���j
		    temp.OfficeTelNo = reader.ReadString();
		    //�d�b�ԍ��i�g�сj
		    temp.PortableTelNo = reader.ReadString();
		    //FAX�ԍ��i����j
		    temp.HomeFaxNo = reader.ReadString();
		    //FAX�ԍ��i�Ζ���j
		    temp.OfficeFaxNo = reader.ReadString();
		    //�d�b�ԍ��i���̑��j
		    temp.OthersTelNo = reader.ReadString();
		    //��A����敪
		    temp.MainContactCode = reader.ReadInt32();
		    //����
		    temp.TotalDay = reader.ReadInt32();
		    //�ڋq�S���]�ƈ��R�[�h
		    temp.CustomerAgentCd = reader.ReadString();
		    //�ڋq�S���]�ƈ�����
		    temp.CustomerAgentNm = reader.ReadString();
		    //�W���S���]�ƈ��R�[�h
		    temp.BillCollecterCd = reader.ReadString();
		    //�W���S���]�ƈ�����
		    temp.BillCollecterNm = reader.ReadString();
		    //����œ]�ŕ���
		    temp.ConsTaxLayMethod = reader.ReadInt32();
		    //���z�\�����@�敪
		    temp.TotalAmountDispWayCd = reader.ReadInt32();
		    //���z�\�����@�Q�Ƌ敪
		    temp.TotalAmntDspWayRef = reader.ReadInt32();
		    //�������Œ[�������R�[�h
		    temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
		    //��s����1
		    temp.AccountNoInfo1 = reader.ReadString();
		    //��s����2
		    temp.AccountNoInfo2 = reader.ReadString();
		    //��s����3
		    temp.AccountNoInfo3 = reader.ReadString();
		    //�l�E�@�l�敪
		    temp.CorporateDivCode = reader.ReadInt32();
		    //���Ӑ�R�[�h
		    temp.CustomerCode = reader.ReadInt32();
		    //���Ӑ於��
		    temp.CustomerName = reader.ReadString();
		    //���Ӑ於��2
		    temp.CustomerName2 = reader.ReadString();
		    //���Ӑ旪��
		    temp.CustomerSnm = reader.ReadString();
		    //�v��N����
		    temp.AddUpDate = new DateTime(reader.ReadInt64());
		    //�v��N��
		    temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
		    //�O�񐿋����z
		    temp.LastTimeDemand = reader.ReadInt64();
		    //����萔���z�i�ʏ�����j
		    temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
		    //����l���z�i�ʏ�����j
		    temp.ThisTimeDisDmdNrml = reader.ReadInt64();
		    //����������z�i�ʏ�����j
		    temp.ThisTimeDmdNrml = reader.ReadInt64();
		    //����J�z�c���i�����v�j
		    temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
		    //���E�㍡�񔄏���z
		    temp.OfsThisTimeSales = reader.ReadInt64();
		    //���E�㍡�񔄏�����
		    temp.OfsThisSalesTax = reader.ReadInt64();
		    //���E��O�őΏۊz
		    temp.ItdedOffsetOutTax = reader.ReadInt64();
		    //���E����őΏۊz
		    temp.ItdedOffsetInTax = reader.ReadInt64();
		    //���E���ېőΏۊz
		    temp.ItdedOffsetTaxFree = reader.ReadInt64();
		    //���E��O�ŏ����
		    temp.OffsetOutTax = reader.ReadInt64();
		    //���E����ŏ����
		    temp.OffsetInTax = reader.ReadInt64();
		    //���񔄏���z
		    temp.ThisTimeSales = reader.ReadInt64();
		    //���񔄏�����
		    temp.ThisSalesTax = reader.ReadInt64();
		    //����O�őΏۊz
		    temp.ItdedSalesOutTax = reader.ReadInt64();
		    //������őΏۊz
		    temp.ItdedSalesInTax = reader.ReadInt64();
		    //�����ېőΏۊz
		    temp.ItdedSalesTaxFree = reader.ReadInt64();
		    //����O�Ŋz
		    temp.SalesOutTax = reader.ReadInt64();
		    //������Ŋz
		    temp.SalesInTax = reader.ReadInt64();
		    //���񔄏�ԕi���z
		    temp.ThisSalesPricRgds = reader.ReadInt64();
		    //���񔄏�ԕi�����
		    temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
		    //�ԕi�O�őΏۊz���v
		    temp.TtlItdedRetOutTax = reader.ReadInt64();
		    //�ԕi���őΏۊz���v
		    temp.TtlItdedRetInTax = reader.ReadInt64();
		    //�ԕi��ېőΏۊz���v
		    temp.TtlItdedRetTaxFree = reader.ReadInt64();
		    //�ԕi�O�Ŋz���v
		    temp.TtlRetOuterTax = reader.ReadInt64();
		    //�ԕi���Ŋz���v
		    temp.TtlRetInnerTax = reader.ReadInt64();
		    //���񔄏�l�����z
		    temp.ThisSalesPricDis = reader.ReadInt64();
		    //���񔄏�l�������
		    temp.ThisSalesPrcTaxDis = reader.ReadInt64();
		    //�l���O�őΏۊz���v
		    temp.TtlItdedDisOutTax = reader.ReadInt64();
		    //�l�����őΏۊz���v
		    temp.TtlItdedDisInTax = reader.ReadInt64();
		    //�l����ېőΏۊz���v
		    temp.TtlItdedDisTaxFree = reader.ReadInt64();
		    //�l���O�Ŋz���v
		    temp.TtlDisOuterTax = reader.ReadInt64();
		    //�l�����Ŋz���v
		    temp.TtlDisInnerTax = reader.ReadInt64();
		    //����x�����E���z
		    temp.ThisPayOffset = reader.ReadInt64();
		    //����x�����E�����
		    temp.ThisPayOffsetTax = reader.ReadInt64();
		    //�x���O�őΏۊz
		    temp.ItdedPaymOutTax = reader.ReadInt64();
		    //�x�����őΏۊz
		    temp.ItdedPaymInTax = reader.ReadInt64();
		    //�x����ېőΏۊz
		    temp.ItdedPaymTaxFree = reader.ReadInt64();
		    //�x���O�ŏ����
		    temp.PaymentOutTax = reader.ReadInt64();
		    //�x�����ŏ����
		    temp.PaymentInTax = reader.ReadInt64();
		    //����Œ����z
		    temp.TaxAdjust = reader.ReadInt64();
		    //�c�������z
		    temp.BalanceAdjust = reader.ReadInt64();
		    //�v�Z�㐿�����z
		    temp.AfCalDemandPrice = reader.ReadInt64();
		    //��2��O�c���i�����v�j
		    temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
		    //��3��O�c���i�����v�j
		    temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
		    //�����X�V���s�N����
		    temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
		    //�����X�V�J�n�N����
		    temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
		    //�O������X�V�N����
		    temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
		    //����`�[����
		    temp.SalesSlipCount = reader.ReadInt32();
		    //���������s��
		    temp.BillPrintDate = new DateTime(reader.ReadInt64());
		    //�����\���
		    temp.ExpectedDepositDate = new DateTime(reader.ReadInt64());
		    //�������
		    temp.CollectCond = reader.ReadInt32();
		    //����ŗ�
		    temp.ConsTaxRate = reader.ReadDouble();
		    //�[�������敪
		    temp.FractionProcCd = reader.ReadInt32();            
		    //����R�[�h���X�g
            int ReadCnt = reader.ReadInt32();
            temp.MoneyKindList = new ArrayList();
            for (int cnt = 0; cnt < ReadCnt; cnt++)
            {
                RsltInfo_EBooksDepsitTotalWork rsltInfo_DepsitTotalWork = new RsltInfo_EBooksDepsitTotalWork();
                rsltInfo_DepsitTotalWork.MoneyKindCode = reader.ReadInt32();
                rsltInfo_DepsitTotalWork.MoneyKindName = reader.ReadString();
                rsltInfo_DepsitTotalWork.MoneyKindDiv = reader.ReadInt32();
                rsltInfo_DepsitTotalWork.Deposit = reader.ReadInt64();
                temp.MoneyKindList.Add(rsltInfo_DepsitTotalWork);
            }
            //�`�[����ݒ�p���[ID
		    temp.SlipPrtSetPaperId = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //�������_�R�[�h	
            temp.ClaimSectionCode = reader.ReadString();
            //���ы��_�R�[�h
            temp.ResultsSectCd = reader.ReadString();
            //�������o�͋敪�R�[�h
            temp.BillOutputCode = reader.ReadInt32();
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //�̎����o�͋敪�R�[�h
            temp.ReceiptOutputCode = reader.ReadInt32();
            //���v�������o�͋敪
            temp.TotalBillOutputDiv = reader.ReadInt32();
            //���א������o�͋敪
            temp.DetailBillOutputCode = reader.ReadInt32();
            //�`�[���v�������o�͋敪
            temp.SlipTtlBillOutputDiv = reader.ReadInt32();
            //����z(�v�ŗ�1)
            temp.TotalThisTimeSalesTaxRate1 = reader.ReadInt64();
            //����z(�v�ŗ�2)
            temp.TotalThisTimeSalesTaxRate2 = reader.ReadInt64();
            //����z(�v���̑�)
            temp.TotalThisTimeSalesOther = reader.ReadInt64();
            //�ԕi�l��(�v�ŗ�1)
            temp.TotalThisRgdsDisPricTaxRate1 = reader.ReadInt64();
            //�ԕi�l��(�v�ŗ�2)
            temp.TotalThisRgdsDisPricTaxRate2 = reader.ReadInt64();
            //�ԕi�l��(�v���̑�)
            temp.TotalThisRgdsDisPricOther = reader.ReadInt64();
            //������z(�v�ŗ�1)
            temp.TotalPureSalesTaxRate1 = reader.ReadInt64();
            //������z(�v�ŗ�2)
            temp.TotalPureSalesTaxRate2 = reader.ReadInt64();
            //������z(�v���̑�)
            temp.TotalPureSalesOther = reader.ReadInt64();
            //�����(�v�ŗ�1)
            temp.TotalSalesPricTaxTaxRate1 = reader.ReadInt64();
            //�����(�v�ŗ�2)
            temp.TotalSalesPricTaxTaxRate2 = reader.ReadInt64();
            //�����(�v���̑�)
            temp.TotalSalesPricTaxOther = reader.ReadInt64();
            //�������v(�v�ŗ�1)
            temp.TotalThisSalesSumTaxRate1 = reader.ReadInt64();
            //�������v(�v�ŗ�2)
            temp.TotalThisSalesSumTaxRate2 = reader.ReadInt64();
            //�������v(�v���̑�)
            temp.TotalThisSalesSumTaxOther = reader.ReadInt64();
            //����(�v�ŗ�1)
            temp.TotalSalesSlipCountTaxRate1 = reader.ReadInt32();
            //����(�v�ŗ�2)
            temp.TotalSalesSlipCountTaxRate2 = reader.ReadInt32();
            //����(�v���̑�)
            temp.TotalSalesSlipCountOther = reader.ReadInt32();
            //�ŗ�1�^�C�g��
            temp.TitleTaxRate1 = reader.ReadString();
            //�ŗ�2�^�C�g��
            temp.TitleTaxRate2 = reader.ReadString();
            // --- ADD START 3H ���� 2022/10/27 ----->>>>>
            // ����z(�v��ې�)
            temp.TotalThisTimeSalesTaxFree = reader.ReadInt64();
            // �ԕi�l��(�v��ې�)
            temp.TotalThisRgdsDisPricTaxFree = reader.ReadInt64();
            // ���d���z(�v��ې�)
            temp.TotalPureSalesTaxFree = reader.ReadInt64();
            // �����(�v��ې�)
            temp.TotalSalesPricTaxTaxFree = reader.ReadInt64();
            // ���񍇌v(�v��ې�)
            temp.TotalThisSalesSumTaxFree = reader.ReadInt64();
            // ����(�v��ې�)
            temp.TotalSalesSlipCountTaxFree = reader.ReadInt32();
            // --- ADD END 3H ���� 2022/10/27 -----<<<<<

		    //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		    //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		    //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		    //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		    for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		    {
			    //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			    //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			    //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			    //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			    int optCount = 0;   
			    object oMemberType = serInfo.MemberInfo[k];
			    if( oMemberType is Type )
			    {
				    Type t = (Type)oMemberType;
				    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				    if( t.Equals( typeof(int) ) )
				    {
					    optCount = Convert.ToInt32(oData);
				    }
				    else
				    {
					    optCount = 0;
				    }
			    }
			    else if( oMemberType is string )
			    {
				    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
			    }
		    }
		    return temp;
	    }

	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
	    /// </summary>
	    /// <returns>RsltInfo_EBooksDemandTotalWork�N���X�̃C���X�^���X(object)</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_EBooksDemandTotalWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    RsltInfo_EBooksDemandTotalWork temp = GetRsltInfo_EBooksDemandTotalWork( reader, serInfo );
			    lst.Add( temp );
		    }
		    switch(serInfo.RetTypeInfo)
		    {
			    case 0:
				    retValue = lst;
				    break;
			    case 1:
				    retValue = lst[0];
				    break;
			    case 2:
				    retValue = (RsltInfo_EBooksDemandTotalWork[])lst.ToArray(typeof(RsltInfo_EBooksDemandTotalWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d���f�[�^�I�u�W�F�N�g�R���o�[�g�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���֘A�N���X�̍��ڃR���o�[�g������s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// </remarks>
	public class ConvertStockSlip
	{
		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
		/// <returns>�d���f�[�^�I�u�W�F�N�g</returns>
		public static StockSlip UIDataFromParamData( StockSlipWork stockSlipWork )
		{
			StockSlip stockSlip = new StockSlip();

			#region �����ڃZ�b�g

			stockSlip.CreateDateTime = stockSlipWork.CreateDateTime;			// �쐬����
			stockSlip.UpdateDateTime = stockSlipWork.UpdateDateTime;			// �X�V����
			stockSlip.EnterpriseCode = stockSlipWork.EnterpriseCode;			// ��ƃR�[�h
			stockSlip.FileHeaderGuid = stockSlipWork.FileHeaderGuid;			// GUID
			stockSlip.UpdEmployeeCode = stockSlipWork.UpdEmployeeCode;			// �X�V�]�ƈ��R�[�h
			stockSlip.UpdAssemblyId1 = stockSlipWork.UpdAssemblyId1;			// �X�V�A�Z���u��ID1
			stockSlip.UpdAssemblyId2 = stockSlipWork.UpdAssemblyId2;			// �X�V�A�Z���u��ID2
			stockSlip.LogicalDeleteCode = stockSlipWork.LogicalDeleteCode;		// �_���폜�敪
			stockSlip.SupplierFormal = stockSlipWork.SupplierFormal;			// �d���`��
			stockSlip.SupplierSlipNo = stockSlipWork.SupplierSlipNo;			// �d���`�[�ԍ�
			stockSlip.SectionCode = stockSlipWork.SectionCode;					// ���_�R�[�h
			stockSlip.SubSectionCode = stockSlipWork.SubSectionCode;			// ����R�[�h
			stockSlip.DebitNoteDiv = stockSlipWork.DebitNoteDiv;				// �ԓ`�敪
			stockSlip.DebitNLnkSuppSlipNo = stockSlipWork.DebitNLnkSuppSlipNo;	// �ԍ��A���d���`�[�ԍ�
			stockSlip.SupplierSlipCd = stockSlipWork.SupplierSlipCd;			// �d���`�[�敪
			stockSlip.StockGoodsCd = stockSlipWork.StockGoodsCd;				// �d�����i�敪
			stockSlip.AccPayDivCd = stockSlipWork.AccPayDivCd;					// ���|�敪
			stockSlip.StockSectionCd = stockSlipWork.StockSectionCd;			// �d�����_�R�[�h
			stockSlip.StockAddUpSectionCd = stockSlipWork.StockAddUpSectionCd;	// �d���v�㋒�_�R�[�h
			stockSlip.StockSlipUpdateCd = stockSlipWork.StockSlipUpdateCd;		// �d���`�[�X�V�敪
			stockSlip.InputDay = stockSlipWork.InputDay;						// ���͓�
			stockSlip.ArrivalGoodsDay = stockSlipWork.ArrivalGoodsDay;			// ���ד�
			stockSlip.StockDate = stockSlipWork.StockDate;						// �d����
			stockSlip.StockAddUpADate = stockSlipWork.StockAddUpADate;			// �d���v����t
			stockSlip.DelayPaymentDiv = stockSlipWork.DelayPaymentDiv;			// �����敪
			stockSlip.PayeeCode = stockSlipWork.PayeeCode;						// �x����R�[�h
			stockSlip.PayeeSnm = stockSlipWork.PayeeSnm;						// �x���旪��
			stockSlip.SupplierCd = stockSlipWork.SupplierCd;					// �d����R�[�h
			stockSlip.SupplierNm1 = stockSlipWork.SupplierNm1;					// �d���於1
			stockSlip.SupplierNm2 = stockSlipWork.SupplierNm2;					// �d���於2
			stockSlip.SupplierSnm = stockSlipWork.SupplierSnm;					// �d���旪��
			stockSlip.BusinessTypeCode = stockSlipWork.BusinessTypeCode;		// �Ǝ�R�[�h
			stockSlip.BusinessTypeName = stockSlipWork.BusinessTypeName;		// �Ǝ햼��
			stockSlip.SalesAreaCode = stockSlipWork.SalesAreaCode;				// �̔��G���A�R�[�h
			stockSlip.SalesAreaName = stockSlipWork.SalesAreaName;				// �̔��G���A����
			stockSlip.StockInputCode = stockSlipWork.StockInputCode;			// �d�����͎҃R�[�h
			stockSlip.StockInputName = stockSlipWork.StockInputName;			// �d�����͎Җ���
			stockSlip.StockAgentCode = stockSlipWork.StockAgentCode;			// �d���S���҃R�[�h
			stockSlip.StockAgentName = stockSlipWork.StockAgentName;			// �d���S���Җ���
			stockSlip.SuppTtlAmntDspWayCd = stockSlipWork.SuppTtlAmntDspWayCd;	// �d���摍�z�\�����@�敪
			stockSlip.TtlAmntDispRateApy = stockSlipWork.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
			stockSlip.StockTotalPrice = stockSlipWork.StockTotalPrice;			// �d�����z���v
			stockSlip.StockSubttlPrice = stockSlipWork.StockSubttlPrice;		// �d�����z���v
			stockSlip.StockTtlPricTaxInc = stockSlipWork.StockTtlPricTaxInc;	// �d�����z�v�i�ō��݁j
			stockSlip.StockTtlPricTaxExc = stockSlipWork.StockTtlPricTaxExc;	// �d�����z�v�i�Ŕ����j
			stockSlip.StockNetPrice = stockSlipWork.StockNetPrice;				// �d���������z
			stockSlip.StockPriceConsTax = stockSlipWork.StockPriceConsTax;		// �d�����z����Ŋz
			stockSlip.TtlItdedStcOutTax = stockSlipWork.TtlItdedStcOutTax;		// �d���O�őΏۊz���v
			stockSlip.TtlItdedStcInTax = stockSlipWork.TtlItdedStcInTax;		// �d�����őΏۊz���v
			stockSlip.TtlItdedStcTaxFree = stockSlipWork.TtlItdedStcTaxFree;	// �d����ېőΏۊz���v
			stockSlip.StockOutTax = stockSlipWork.StockOutTax;					// �d�����z����Ŋz�i�O�Łj
			stockSlip.StckPrcConsTaxInclu = stockSlipWork.StckPrcConsTaxInclu;	// �d�����z����Ŋz�i���Łj
			stockSlip.StckDisTtlTaxExc = stockSlipWork.StckDisTtlTaxExc;		// �d���l�����z�v�i�Ŕ����j
			stockSlip.ItdedStockDisOutTax = stockSlipWork.ItdedStockDisOutTax;	// �d���l���O�őΏۊz���v
			stockSlip.ItdedStockDisInTax = stockSlipWork.ItdedStockDisInTax;	// �d���l�����őΏۊz���v
			stockSlip.ItdedStockDisTaxFre = stockSlipWork.ItdedStockDisTaxFre;	// �d���l����ېőΏۊz���v
			stockSlip.StockDisOutTax = stockSlipWork.StockDisOutTax;			// �d���l������Ŋz�i�O�Łj
			stockSlip.StckDisTtlTaxInclu = stockSlipWork.StckDisTtlTaxInclu;	// �d���l������Ŋz�i���Łj
			stockSlip.TaxAdjust = stockSlipWork.TaxAdjust;						// ����Œ����z
			stockSlip.BalanceAdjust = stockSlipWork.BalanceAdjust;				// �c�������z
			stockSlip.SuppCTaxLayCd = stockSlipWork.SuppCTaxLayCd;				// �d�������œ]�ŕ����R�[�h
			stockSlip.SupplierConsTaxRate = stockSlipWork.SupplierConsTaxRate;	// �d�������Őŗ�
			stockSlip.AccPayConsTax = stockSlipWork.AccPayConsTax;				// ���|�����
			stockSlip.StockFractionProcCd = stockSlipWork.StockFractionProcCd;	// �d���[�������敪
			stockSlip.AutoPayment = stockSlipWork.AutoPayment;					// �����x���敪
			stockSlip.AutoPaySlipNum = stockSlipWork.AutoPaySlipNum;			// �����x���`�[�ԍ�
			stockSlip.RetGoodsReasonDiv = stockSlipWork.RetGoodsReasonDiv;		// �ԕi���R�R�[�h
			stockSlip.RetGoodsReason = stockSlipWork.RetGoodsReason;			// �ԕi���R
			stockSlip.PartySaleSlipNum = stockSlipWork.PartySaleSlipNum;		// �����`�[�ԍ�
			stockSlip.SupplierSlipNote1 = stockSlipWork.SupplierSlipNote1;		// �d���`�[���l1
			stockSlip.SupplierSlipNote2 = stockSlipWork.SupplierSlipNote2;		// �d���`�[���l2
			stockSlip.DetailRowCount = stockSlipWork.DetailRowCount;			// ���׍s��
			stockSlip.EdiSendDate = stockSlipWork.EdiSendDate;					// �d�c�h���M��
			stockSlip.EdiTakeInDate = stockSlipWork.EdiTakeInDate;				// �d�c�h�捞��
			stockSlip.UoeRemark1 = stockSlipWork.UoeRemark1;					// �t�n�d���}�[�N�P
			stockSlip.UoeRemark2 = stockSlipWork.UoeRemark2;					// �t�n�d���}�[�N�Q
			stockSlip.SlipPrintDivCd = stockSlipWork.SlipPrintDivCd;			// �`�[���s�敪
			stockSlip.SlipPrintFinishCd = stockSlipWork.SlipPrintFinishCd;		// �`�[���s�ϋ敪
			stockSlip.StockSlipPrintDate = stockSlipWork.StockSlipPrintDate;	// �d���`�[���s��
			stockSlip.SlipPrtSetPaperId = stockSlipWork.SlipPrtSetPaperId;		// �`�[����ݒ�p���[ID
			stockSlip.SlipAddressDiv = stockSlipWork.SlipAddressDiv;			// �`�[�Z���敪
			stockSlip.AddresseeCode = stockSlipWork.AddresseeCode;				// �[�i��R�[�h
			stockSlip.AddresseeName = stockSlipWork.AddresseeName;				// �[�i�於��
			stockSlip.AddresseeName2 = stockSlipWork.AddresseeName2;			// �[�i�於��2
			stockSlip.AddresseePostNo = stockSlipWork.AddresseePostNo;			// �[�i��X�֔ԍ�
			stockSlip.AddresseeAddr1 = stockSlipWork.AddresseeAddr1;			// �[�i��Z��1(�s���{���s��S�E�����E��)
			stockSlip.AddresseeAddr3 = stockSlipWork.AddresseeAddr3;			// �[�i��Z��3(�Ԓn)
			stockSlip.AddresseeAddr4 = stockSlipWork.AddresseeAddr4;			// �[�i��Z��4(�A�p�[�g����)
			stockSlip.AddresseeTelNo = stockSlipWork.AddresseeTelNo;			// �[�i��d�b�ԍ�
			stockSlip.AddresseeFaxNo = stockSlipWork.AddresseeFaxNo;			// �[�i��FAX�ԍ�
			stockSlip.DirectSendingCd = stockSlipWork.DirectSendingCd;			// �����敪

			#endregion

			return stockSlip;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
		/// <returns>�d�����׃f�[�^�I�u�W�F�N�g���X�g</returns>
		public static List<StockDetail> UIDataFromParamData( StockDetailWork[] stockDetailWorkArray )
		{
			if (stockDetailWorkArray == null) return null;

			List<StockDetail> stockDetailList = new List<StockDetail>();

			foreach (StockDetailWork stockDetailWork in stockDetailWorkArray)
			{
				stockDetailList.Add(UIDataFromParamData(stockDetailWork));
			}

			return stockDetailList;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="addUpSrcStockDetailWorkList">�v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
		/// <returns>�d�����׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<StockDetail> UIDataFromParamData( AddUpOrgStockDetailWork[] addUpSrcStockDetailWorkList )
		{
			if (addUpSrcStockDetailWorkList == null) return null;

			List<StockDetail> addUppOrgStockDetailList = new List<StockDetail>();

            foreach (AddUpOrgStockDetailWork addUpOrgStockDetailWork in addUpSrcStockDetailWorkList)
			{
				addUppOrgStockDetailList.Add(UIDataFromParamData((StockDetailWork)addUpOrgStockDetailWork));
			}

			return addUppOrgStockDetailList;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="stockDetailWork">�d�����׃f�[�^���[�N�I�u�W�F�N�g</param>
		/// <returns>�d�����׃f�[�^�I�u�W�F�N�g</returns>
		public static StockDetail UIDataFromParamData( StockDetailWork stockDetailWork )
		{
			StockDetail stockDetail = new StockDetail();

			#region �����ڃZ�b�g

			// ���q�ɃR�[�h�̓g�������ăZ�b�g

            stockDetail.CreateDateTime = stockDetailWork.CreateDateTime;                // �쐬����
            stockDetail.UpdateDateTime = stockDetailWork.UpdateDateTime;                // �X�V����
            stockDetail.EnterpriseCode = stockDetailWork.EnterpriseCode;                // ��ƃR�[�h
            stockDetail.FileHeaderGuid = stockDetailWork.FileHeaderGuid;                // GUID
            stockDetail.UpdEmployeeCode = stockDetailWork.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            stockDetail.UpdAssemblyId1 = stockDetailWork.UpdAssemblyId1;                // �X�V�A�Z���u��ID1
            stockDetail.UpdAssemblyId2 = stockDetailWork.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            stockDetail.LogicalDeleteCode = stockDetailWork.LogicalDeleteCode;          // �_���폜�敪
            stockDetail.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo;              // �󒍔ԍ�
            stockDetail.SupplierFormal = stockDetailWork.SupplierFormal;                // �d���`��
            stockDetail.SupplierSlipNo = stockDetailWork.SupplierSlipNo;                // �d���`�[�ԍ�
            stockDetail.StockRowNo = stockDetailWork.StockRowNo;                        // �d���s�ԍ�
            stockDetail.SectionCode = stockDetailWork.SectionCode;                      // ���_�R�[�h
            stockDetail.SubSectionCode = stockDetailWork.SubSectionCode;                // ����R�[�h
            stockDetail.CommonSeqNo = stockDetailWork.CommonSeqNo;                      // ���ʒʔ�
            stockDetail.StockSlipDtlNum = stockDetailWork.StockSlipDtlNum;              // �d�����גʔ�
            stockDetail.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc;          // �d���`���i���j
            stockDetail.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc;        // �d�����גʔԁi���j
            stockDetail.AcptAnOdrStatusSync = stockDetailWork.AcptAnOdrStatusSync;      // �󒍃X�e�[�^�X�i�����j
            stockDetail.SalesSlipDtlNumSync = stockDetailWork.SalesSlipDtlNumSync;      // ���㖾�גʔԁi�����j
            stockDetail.StockSlipCdDtl = stockDetailWork.StockSlipCdDtl;                // �d���`�[�敪�i���ׁj
            stockDetail.StockInputCode = stockDetailWork.StockInputCode;                // �d�����͎҃R�[�h
            stockDetail.StockInputName = stockDetailWork.StockInputName;                // �d�����͎Җ���
            stockDetail.StockAgentCode = stockDetailWork.StockAgentCode;                // �d���S���҃R�[�h
            stockDetail.StockAgentName = stockDetailWork.StockAgentName;                // �d���S���Җ���
            stockDetail.GoodsKindCode = stockDetailWork.GoodsKindCode;                  // ���i����
            stockDetail.GoodsMakerCd = stockDetailWork.GoodsMakerCd;                    // ���i���[�J�[�R�[�h
            stockDetail.MakerName = stockDetailWork.MakerName;                          // ���[�J�[����
            stockDetail.MakerKanaName = stockDetailWork.MakerKanaName;                  // ���[�J�[�J�i����
            stockDetail.CmpltMakerKanaName = stockDetailWork.CmpltMakerKanaName;        // ���[�J�[�J�i���́i�ꎮ�j
            stockDetail.GoodsNo = stockDetailWork.GoodsNo;                              // ���i�ԍ�
            stockDetail.GoodsName = stockDetailWork.GoodsName;                          // ���i����
            stockDetail.GoodsNameKana = stockDetailWork.GoodsNameKana;                  // ���i���̃J�i
            stockDetail.GoodsLGroup = stockDetailWork.GoodsLGroup;                      // ���i�啪�ރR�[�h
            stockDetail.GoodsLGroupName = stockDetailWork.GoodsLGroupName;              // ���i�啪�ޖ���
            stockDetail.GoodsMGroup = stockDetailWork.GoodsMGroup;                      // ���i�����ރR�[�h
            stockDetail.GoodsMGroupName = stockDetailWork.GoodsMGroupName;              // ���i�����ޖ���
            stockDetail.BLGroupCode = stockDetailWork.BLGroupCode;                      // BL�O���[�v�R�[�h
            stockDetail.BLGroupName = stockDetailWork.BLGroupName;                      // BL�O���[�v�R�[�h����
            stockDetail.BLGoodsCode = stockDetailWork.BLGoodsCode;                      // BL���i�R�[�h
            stockDetail.BLGoodsFullName = stockDetailWork.BLGoodsFullName;              // BL���i�R�[�h���́i�S�p�j
            stockDetail.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode;      // ���Е��ރR�[�h
            stockDetail.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName;      // ���Е��ޖ���
            stockDetail.WarehouseCode = stockDetailWork.WarehouseCode.Trim();           // �q�ɃR�[�h
            stockDetail.WarehouseName = stockDetailWork.WarehouseName;                  // �q�ɖ���
            stockDetail.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;            // �q�ɒI��
            stockDetail.StockOrderDivCd = stockDetailWork.StockOrderDivCd;              // �d���݌Ɏ�񂹋敪
            stockDetail.OpenPriceDiv = stockDetailWork.OpenPriceDiv;                    // �I�[�v�����i�敪
            stockDetail.GoodsRateRank = stockDetailWork.GoodsRateRank;                  // ���i�|�������N
            stockDetail.CustRateGrpCode = stockDetailWork.CustRateGrpCode;              // ���Ӑ�|���O���[�v�R�[�h
            stockDetail.SuppRateGrpCode = stockDetailWork.SuppRateGrpCode;              // �d����|���O���[�v�R�[�h
            stockDetail.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl;          // �艿�i�Ŕ��C�����j
            stockDetail.ListPriceTaxIncFl = stockDetailWork.ListPriceTaxIncFl;          // �艿�i�ō��C�����j
            stockDetail.StockRate = stockDetailWork.StockRate;                          // �d����
            stockDetail.RateSectStckUnPrc = stockDetailWork.RateSectStckUnPrc;          // �|���ݒ苒�_�i�d���P���j
            stockDetail.RateDivStckUnPrc = stockDetailWork.RateDivStckUnPrc;            // �|���ݒ�敪�i�d���P���j
            stockDetail.UnPrcCalcCdStckUnPrc = stockDetailWork.UnPrcCalcCdStckUnPrc;    // �P���Z�o�敪�i�d���P���j
            stockDetail.PriceCdStckUnPrc = stockDetailWork.PriceCdStckUnPrc;            // ���i�敪�i�d���P���j
            stockDetail.StdUnPrcStckUnPrc = stockDetailWork.StdUnPrcStckUnPrc;          // ��P���i�d���P���j
            stockDetail.FracProcUnitStcUnPrc = stockDetailWork.FracProcUnitStcUnPrc;    // �[�������P�ʁi�d���P���j
            stockDetail.FracProcStckUnPrc = stockDetailWork.FracProcStckUnPrc;          // �[�������i�d���P���j
            stockDetail.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;            // �d���P���i�Ŕ��C�����j
            stockDetail.StockUnitTaxPriceFl = stockDetailWork.StockUnitTaxPriceFl;      // �d���P���i�ō��C�����j
            stockDetail.StockUnitChngDiv = stockDetailWork.StockUnitChngDiv;            // �d���P���ύX�敪
            stockDetail.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;        // �ύX�O�d���P���i�����j
            stockDetail.BfListPrice = stockDetailWork.BfListPrice;                      // �ύX�O�艿
            stockDetail.RateBLGoodsCode = stockDetailWork.RateBLGoodsCode;              // BL���i�R�[�h�i�|���j
            stockDetail.RateBLGoodsName = stockDetailWork.RateBLGoodsName;              // BL���i�R�[�h���́i�|���j
            stockDetail.RateGoodsRateGrpCd = stockDetailWork.RateGoodsRateGrpCd;        // ���i�|���O���[�v�R�[�h�i�|���j
            stockDetail.RateGoodsRateGrpNm = stockDetailWork.RateGoodsRateGrpNm;        // ���i�|���O���[�v���́i�|���j
            stockDetail.RateBLGroupCode = stockDetailWork.RateBLGroupCode;              // BL�O���[�v�R�[�h�i�|���j
            stockDetail.RateBLGroupName = stockDetailWork.RateBLGroupName;              // BL�O���[�v���́i�|���j
            stockDetail.StockCount = stockDetailWork.StockCount;                        // �d����
            stockDetail.OrderCnt = stockDetailWork.OrderCnt;                            // ��������
            stockDetail.OrderAdjustCnt = stockDetailWork.OrderAdjustCnt;                // ����������
            stockDetail.OrderRemainCnt = stockDetailWork.OrderRemainCnt;                // �����c��
            stockDetail.RemainCntUpdDate = stockDetailWork.RemainCntUpdDate;            // �c���X�V��
            stockDetail.StockPriceTaxExc = stockDetailWork.StockPriceTaxExc;            // �d�����z�i�Ŕ����j
            stockDetail.StockPriceTaxInc = stockDetailWork.StockPriceTaxInc;            // �d�����z�i�ō��݁j
            stockDetail.StockGoodsCd = stockDetailWork.StockGoodsCd;                    // �d�����i�敪
            stockDetail.StockPriceConsTax = stockDetailWork.StockPriceConsTax;          // �d�����z����Ŋz
            stockDetail.TaxationCode = stockDetailWork.TaxationCode;                    // �ېŋ敪
            stockDetail.StockDtiSlipNote1 = stockDetailWork.StockDtiSlipNote1;          // �d���`�[���ה��l1
            stockDetail.SalesCustomerCode = stockDetailWork.SalesCustomerCode;          // �̔���R�[�h
            stockDetail.SalesCustomerSnm = stockDetailWork.SalesCustomerSnm;            // �̔��旪��
            stockDetail.SlipMemo1 = stockDetailWork.SlipMemo1;                          // �`�[�����P
            stockDetail.SlipMemo2 = stockDetailWork.SlipMemo2;                          // �`�[�����Q
            stockDetail.SlipMemo3 = stockDetailWork.SlipMemo3;                          // �`�[�����R
            stockDetail.InsideMemo1 = stockDetailWork.InsideMemo1;                      // �Г������P
            stockDetail.InsideMemo2 = stockDetailWork.InsideMemo2;                      // �Г������Q
            stockDetail.InsideMemo3 = stockDetailWork.InsideMemo3;                      // �Г������R
            stockDetail.SupplierCd = stockDetailWork.SupplierCd;                        // �d����R�[�h
            stockDetail.SupplierSnm = stockDetailWork.SupplierSnm;                      // �d���旪��
            stockDetail.AddresseeCode = stockDetailWork.AddresseeCode;                  // �[�i��R�[�h
            stockDetail.AddresseeName = stockDetailWork.AddresseeName;                  // �[�i�於��
            stockDetail.DirectSendingCd = stockDetailWork.DirectSendingCd;              // �����敪
            stockDetail.OrderNumber = stockDetailWork.OrderNumber;                      // �����ԍ�
            stockDetail.WayToOrder = stockDetailWork.WayToOrder;                        // �������@
            stockDetail.DeliGdsCmpltDueDate = stockDetailWork.DeliGdsCmpltDueDate;      // �[�i�����\���
            stockDetail.ExpectDeliveryDate = stockDetailWork.ExpectDeliveryDate;        // ��]�[��
            stockDetail.OrderDataCreateDiv = stockDetailWork.OrderDataCreateDiv;        // �����f�[�^�쐬�敪
            stockDetail.OrderDataCreateDate = stockDetailWork.OrderDataCreateDate;      // �����f�[�^�쐬��
            stockDetail.OrderFormIssuedDiv = stockDetailWork.OrderFormIssuedDiv;        // ���������s�ϋ敪


			#endregion

			return stockDetail;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="salesTempWorkList">����f�[�^(�d�������v��)���[�N�I�u�W�F�N�g�z��</param>
		/// <returns>����f�[�^(�d�������v��)�f�[�^�I�u�W�F�N�g���X�g</returns>
		public static List<SalesTemp> UIDataFromParamData( SalesTempWork[] salesTempWorkList )
		{
			if (salesTempWorkList == null) return null;

			List<SalesTemp> salesTempList = new List<SalesTemp>();

			foreach (SalesTempWork salesTempWork in salesTempWorkList)
			{
				salesTempList.Add(UIDataFromParamData((SalesTempWork)salesTempWork));
			}

			return salesTempList;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="salesTempWork">����f�[�^(�d�������v��)���[�N�I�u�W�F�N�g</param>
		/// <returns>����f�[�^(�d�������v��)�I�u�W�F�N�g</returns>
		public static SalesTemp UIDataFromParamData( SalesTempWork salesTempWork )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region �����ڃZ�b�g

			// ���q�ɃR�[�h�̓g�������ăZ�b�g

			salesTemp.CreateDateTime = salesTempWork.CreateDateTime;
			salesTemp.UpdateDateTime = salesTempWork.UpdateDateTime;
			salesTemp.EnterpriseCode = salesTempWork.EnterpriseCode;
			salesTemp.FileHeaderGuid = salesTempWork.FileHeaderGuid;
			salesTemp.UpdEmployeeCode = salesTempWork.UpdEmployeeCode;
			salesTemp.UpdAssemblyId1 = salesTempWork.UpdAssemblyId1;
			salesTemp.UpdAssemblyId2 = salesTempWork.UpdAssemblyId2;
			salesTemp.LogicalDeleteCode = salesTempWork.LogicalDeleteCode;
			salesTemp.AcptAnOdrStatus = salesTempWork.AcptAnOdrStatus;
			salesTemp.SectionCode = salesTempWork.SectionCode;
			salesTemp.SubSectionCode = salesTempWork.SubSectionCode;
			salesTemp.MinSectionCode = salesTempWork.MinSectionCode;
			salesTemp.DebitNoteDiv = salesTempWork.DebitNoteDiv;
			salesTemp.DebitNLnkAcptAnOdr = salesTempWork.DebitNLnkAcptAnOdr;
			salesTemp.SalesSlipCd = salesTempWork.SalesSlipCd;
			salesTemp.AccRecDivCd = salesTempWork.AccRecDivCd;
			salesTemp.SalesInpSecCd = salesTempWork.SalesInpSecCd;
			salesTemp.DemandAddUpSecCd = salesTempWork.DemandAddUpSecCd;
			salesTemp.ResultsAddUpSecCd = salesTempWork.ResultsAddUpSecCd;
			salesTemp.UpdateSecCd = salesTempWork.UpdateSecCd;
			salesTemp.SearchSlipDate = salesTempWork.SearchSlipDate;
			salesTemp.ShipmentDay = salesTempWork.ShipmentDay;
			salesTemp.SalesDate = salesTempWork.SalesDate;
			salesTemp.AddUpADate = salesTempWork.AddUpADate;
			salesTemp.DelayPaymentDiv = salesTempWork.DelayPaymentDiv;
			salesTemp.ClaimCode = salesTempWork.ClaimCode;
			salesTemp.ClaimSnm = salesTempWork.ClaimSnm;
			salesTemp.CustomerCode = salesTempWork.CustomerCode;
			salesTemp.CustomerName = salesTempWork.CustomerName;
			salesTemp.CustomerName2 = salesTempWork.CustomerName2;
			salesTemp.CustomerSnm = salesTempWork.CustomerSnm;
			salesTemp.HonorificTitle = salesTempWork.HonorificTitle;
			salesTemp.OutputNameCode = salesTempWork.OutputNameCode;
			salesTemp.BusinessTypeCode = salesTempWork.BusinessTypeCode;
			salesTemp.BusinessTypeName = salesTempWork.BusinessTypeName;
			salesTemp.SalesAreaCode = salesTempWork.SalesAreaCode;
			salesTemp.SalesAreaName = salesTempWork.SalesAreaName;
			salesTemp.SalesInputCode = salesTempWork.SalesInputCode;
			salesTemp.SalesInputName = salesTempWork.SalesInputName;
			salesTemp.FrontEmployeeCd = salesTempWork.FrontEmployeeCd;
			salesTemp.FrontEmployeeNm = salesTempWork.FrontEmployeeNm;
			salesTemp.SalesEmployeeCd = salesTempWork.SalesEmployeeCd;
			salesTemp.SalesEmployeeNm = salesTempWork.SalesEmployeeNm;
			salesTemp.ConsTaxLayMethod = salesTempWork.ConsTaxLayMethod;
			salesTemp.ConsTaxRate = salesTempWork.ConsTaxRate;
			salesTemp.FractionProcCd = salesTempWork.FractionProcCd;
			salesTemp.AutoDepositCd = salesTempWork.AutoDepositCd;
			salesTemp.AutoDepoSlipNum = salesTempWork.AutoDepoSlipNum;
			salesTemp.SlipAddressDiv = salesTempWork.SlipAddressDiv;
			salesTemp.AddresseeCode = salesTempWork.AddresseeCode;
			salesTemp.AddresseeName = salesTempWork.AddresseeName;
			salesTemp.AddresseeName2 = salesTempWork.AddresseeName2;
			salesTemp.AddresseePostNo = salesTempWork.AddresseePostNo;
			salesTemp.AddresseeAddr1 = salesTempWork.AddresseeAddr1;
			salesTemp.AddresseeAddr2 = salesTempWork.AddresseeAddr2;
			salesTemp.AddresseeAddr3 = salesTempWork.AddresseeAddr3;
			salesTemp.AddresseeAddr4 = salesTempWork.AddresseeAddr4;
			salesTemp.AddresseeTelNo = salesTempWork.AddresseeTelNo;
			salesTemp.AddresseeFaxNo = salesTempWork.AddresseeFaxNo;
			salesTemp.PartySaleSlipNum = salesTempWork.PartySaleSlipNum;
			salesTemp.SlipNote = salesTempWork.SlipNote;
			salesTemp.SlipNote2 = salesTempWork.SlipNote2;
			salesTemp.RetGoodsReasonDiv = salesTempWork.RetGoodsReasonDiv;
			salesTemp.RetGoodsReason = salesTempWork.RetGoodsReason;
			salesTemp.DetailRowCount = salesTempWork.DetailRowCount;
			salesTemp.DeliveredGoodsDiv = salesTempWork.DeliveredGoodsDiv;
			salesTemp.DeliveredGoodsDivNm = salesTempWork.DeliveredGoodsDivNm;
			salesTemp.ReconcileFlag = salesTempWork.ReconcileFlag;
			salesTemp.SlipPrtSetPaperId = salesTempWork.SlipPrtSetPaperId;
			salesTemp.CompleteCd = salesTempWork.CompleteCd;
			salesTemp.ClaimType = salesTempWork.ClaimType;
			salesTemp.SalesPriceFracProcCd = salesTempWork.SalesPriceFracProcCd;
			salesTemp.ListPricePrintDiv = salesTempWork.ListPricePrintDiv;
			salesTemp.EraNameDispCd1 = salesTempWork.EraNameDispCd1;
			salesTemp.AcceptAnOrderNo = salesTempWork.AcceptAnOrderNo;
			salesTemp.CommonSeqNo = salesTempWork.CommonSeqNo;
			salesTemp.SalesSlipDtlNum = salesTempWork.SalesSlipDtlNum;
			salesTemp.AcptAnOdrStatusSrc = salesTempWork.AcptAnOdrStatusSrc;
			salesTemp.SalesSlipDtlNumSrc = salesTempWork.SalesSlipDtlNumSrc;
			salesTemp.SupplierFormalSync = salesTempWork.SupplierFormalSync;
			salesTemp.StockSlipDtlNumSync = salesTempWork.StockSlipDtlNumSync;
			salesTemp.SalesSlipCdDtl = salesTempWork.SalesSlipCdDtl;
			salesTemp.OrderNumber = salesTempWork.OrderNumber;
			salesTemp.StockMngExistCd = salesTempWork.StockMngExistCd;
			salesTemp.DeliGdsCmpltDueDate = salesTempWork.DeliGdsCmpltDueDate;
			salesTemp.GoodsKindCode = salesTempWork.GoodsKindCode;
			salesTemp.GoodsMakerCd = salesTempWork.GoodsMakerCd;
			salesTemp.MakerName = salesTempWork.MakerName;
			salesTemp.GoodsNo = salesTempWork.GoodsNo;
			salesTemp.GoodsName = salesTempWork.GoodsName;
			salesTemp.GoodsShortName = salesTempWork.GoodsShortName;
			salesTemp.GoodsSetDivCd = salesTempWork.GoodsSetDivCd;
			salesTemp.LargeGoodsGanreCode = salesTempWork.LargeGoodsGanreCode;
			salesTemp.LargeGoodsGanreName = salesTempWork.LargeGoodsGanreName;
			salesTemp.MediumGoodsGanreCode = salesTempWork.MediumGoodsGanreCode;
			salesTemp.MediumGoodsGanreName = salesTempWork.MediumGoodsGanreName;
			salesTemp.DetailGoodsGanreCode = salesTempWork.DetailGoodsGanreCode;
			salesTemp.DetailGoodsGanreName = salesTempWork.DetailGoodsGanreName;
			salesTemp.BLGoodsCode = salesTempWork.BLGoodsCode;
			salesTemp.BLGoodsFullName = salesTempWork.BLGoodsFullName;
			salesTemp.EnterpriseGanreCode = salesTempWork.EnterpriseGanreCode;
			salesTemp.EnterpriseGanreName = salesTempWork.EnterpriseGanreName;
			salesTemp.WarehouseCode = salesTempWork.WarehouseCode.Trim();
			salesTemp.WarehouseName = salesTempWork.WarehouseName;
			salesTemp.WarehouseShelfNo = salesTempWork.WarehouseShelfNo;
			salesTemp.SalesOrderDivCd = salesTempWork.SalesOrderDivCd;
			salesTemp.OpenPriceDiv = salesTempWork.OpenPriceDiv;
			salesTemp.UnitCode = salesTempWork.UnitCode;
			salesTemp.UnitName = salesTempWork.UnitName;
			salesTemp.GoodsRateRank = salesTempWork.GoodsRateRank;
			salesTemp.CustRateGrpCode = salesTempWork.CustRateGrpCode;
			salesTemp.SuppRateGrpCode = salesTempWork.SuppRateGrpCode;
			salesTemp.ListPriceRate = salesTempWork.ListPriceRate;
			salesTemp.RateSectPriceUnPrc = salesTempWork.RateSectPriceUnPrc;
			salesTemp.RateDivLPrice = salesTempWork.RateDivLPrice;
			salesTemp.UnPrcCalcCdLPrice = salesTempWork.UnPrcCalcCdLPrice;
			salesTemp.PriceCdLPrice = salesTempWork.PriceCdLPrice;
			salesTemp.StdUnPrcLPrice = salesTempWork.StdUnPrcLPrice;
			salesTemp.FracProcUnitLPrice = salesTempWork.FracProcUnitLPrice;
			salesTemp.FracProcLPrice = salesTempWork.FracProcLPrice;
			salesTemp.ListPriceTaxIncFl = salesTempWork.ListPriceTaxIncFl;
			salesTemp.ListPriceTaxExcFl = salesTempWork.ListPriceTaxExcFl;
			salesTemp.ListPriceChngCd = salesTempWork.ListPriceChngCd;
			salesTemp.SalesRate = salesTempWork.SalesRate;
			salesTemp.RateSectSalUnPrc = salesTempWork.RateSectSalUnPrc;
			salesTemp.RateDivSalUnPrc = salesTempWork.RateDivSalUnPrc;
			salesTemp.UnPrcCalcCdSalUnPrc = salesTempWork.UnPrcCalcCdSalUnPrc;
			salesTemp.PriceCdSalUnPrc = salesTempWork.PriceCdSalUnPrc;
			salesTemp.StdUnPrcSalUnPrc = salesTempWork.StdUnPrcSalUnPrc;
			salesTemp.FracProcUnitSalUnPrc = salesTempWork.FracProcUnitSalUnPrc;
			salesTemp.FracProcSalUnPrc = salesTempWork.FracProcSalUnPrc;
			salesTemp.SalesUnPrcTaxIncFl = salesTempWork.SalesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcTaxExcFl = salesTempWork.SalesUnPrcTaxExcFl;
			salesTemp.SalesUnPrcChngCd = salesTempWork.SalesUnPrcChngCd;
			salesTemp.CostRate = salesTempWork.CostRate;
			salesTemp.RateSectCstUnPrc = salesTempWork.RateSectCstUnPrc;
			salesTemp.RateDivUnCst = salesTempWork.RateDivUnCst;
			salesTemp.UnPrcCalcCdUnCst = salesTempWork.UnPrcCalcCdUnCst;
			salesTemp.PriceCdUnCst = salesTempWork.PriceCdUnCst;
			salesTemp.StdUnPrcUnCst = salesTempWork.StdUnPrcUnCst;
			salesTemp.FracProcUnitUnCst = salesTempWork.FracProcUnitUnCst;
			salesTemp.FracProcUnCst = salesTempWork.FracProcUnCst;
			salesTemp.SalesUnitCost = salesTempWork.SalesUnitCost;
			salesTemp.SalesUnitCostChngDiv = salesTempWork.SalesUnitCostChngDiv;
			salesTemp.RateBLGoodsCode = salesTempWork.RateBLGoodsCode;
			salesTemp.RateBLGoodsName = salesTempWork.RateBLGoodsName;
			salesTemp.BargainCd = salesTempWork.BargainCd;
			salesTemp.BargainNm = salesTempWork.BargainNm;
			salesTemp.ShipmentCnt = salesTempWork.ShipmentCnt;
			salesTemp.SalesMoneyTaxInc = salesTempWork.SalesMoneyTaxInc;
			salesTemp.SalesMoneyTaxExc = salesTempWork.SalesMoneyTaxExc;
			salesTemp.Cost = salesTempWork.Cost;
			salesTemp.GrsProfitChkDiv = salesTempWork.GrsProfitChkDiv;
			salesTemp.SalesGoodsCd = salesTempWork.SalesGoodsCd;
			salesTemp.SalsePriceConsTax = salesTempWork.SalsePriceConsTax;
			salesTemp.TaxationDivCd = salesTempWork.TaxationDivCd;
			salesTemp.PartySlipNumDtl = salesTempWork.PartySlipNumDtl;
			salesTemp.DtlNote = salesTempWork.DtlNote;
			salesTemp.SupplierCd = salesTempWork.SupplierCd;
			salesTemp.SupplierSnm = salesTempWork.SupplierSnm;
			salesTemp.SlipMemo1 = salesTempWork.SlipMemo1;
			salesTemp.SlipMemo2 = salesTempWork.SlipMemo2;
			salesTemp.SlipMemo3 = salesTempWork.SlipMemo3;
			salesTemp.SlipMemo4 = salesTempWork.SlipMemo4;
			salesTemp.SlipMemo5 = salesTempWork.SlipMemo5;
			salesTemp.SlipMemo6 = salesTempWork.SlipMemo6;
			salesTemp.InsideMemo1 = salesTempWork.InsideMemo1;
			salesTemp.InsideMemo2 = salesTempWork.InsideMemo2;
			salesTemp.InsideMemo3 = salesTempWork.InsideMemo3;
			salesTemp.InsideMemo4 = salesTempWork.InsideMemo4;
			salesTemp.InsideMemo5 = salesTempWork.InsideMemo5;
			salesTemp.InsideMemo6 = salesTempWork.InsideMemo6;
			salesTemp.BfListPrice = salesTempWork.BfListPrice;
			salesTemp.BfSalesUnitPrice = salesTempWork.BfSalesUnitPrice;
			salesTemp.BfUnitCost = salesTempWork.BfUnitCost;
			salesTemp.PrtGoodsNo = salesTempWork.PrtGoodsNo;
			salesTemp.PrtGoodsName = salesTempWork.PrtGoodsName;
			salesTemp.PrtGoodsMakerCd = salesTempWork.PrtGoodsMakerCd;
			salesTemp.PrtGoodsMakerNm = salesTempWork.PrtGoodsMakerNm;
			//salesTempRow.SupplierSlipCd = salesTempWork.SupplierSlipCd;
			//salesTempRow.TotalAmountDispWayCd = salesTempWork.TotalAmountDispWayCd;
			//salesTempRow.TtlAmntDispRateApy = salesTempWork.TtlAmntDispRateApy;
			//salesTempRow.ConfirmedDiv = salesTempWork.ConfirmedDiv;
			//salesTempRow.NTimeCalcStDate = salesTempWork.NTimeCalcStDate;
			//salesTempRow.TotalDay = salesTempWork.TotalDay;
			salesTemp.DtlRelationGuid = salesTempWork.DtlRelationGuid;

			#endregion

			return salesTemp;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="stockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesSlipWorkList">����f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="salesDetailWorkList">���㖾�׃f�[�^�I�u�W�F�N�g���X�g</param>
		/// <returns>����f�[�^(�d�������v��)�I�u�W�F�N�g���X�g</returns>
		public static List<SalesTemp> UIDataFromParamData( List<StockDetail> stockDetailList, List<SalesSlipWork> salesSlipWorkList, List<SalesDetailWork> salesDetailWorkList )
		{
			if (( salesSlipWorkList == null ) || ( salesDetailWorkList == null )) return null;

			List<SalesTemp> salesTempList = new List<SalesTemp>();

			foreach (SalesDetailWork salesDetailWork in salesDetailWorkList)
			{
				// �`�[���̎擾
				SalesSlipWork salesSlipWork = null;
				foreach (SalesSlipWork salesSlipWorkTemp in salesSlipWorkList)
				{
					if (( salesDetailWork.AcptAnOdrStatus == salesSlipWorkTemp.AcptAnOdrStatus ) &&
						( salesDetailWork.SalesSlipNum == salesSlipWorkTemp.SalesSlipNum ))
					{
						salesSlipWork = salesSlipWorkTemp;
						break;
					}
				}

				if (salesSlipWork ==null)continue;

				// �����d�����̎擾
				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (( stockDetail.AcptAnOdrStatusSync == salesDetailWork.AcptAnOdrStatus ) &&
						( stockDetail.SalesSlipDtlNumSync == salesDetailWork.SalesSlipDtlNum ) &&
						( stockDetail.StockSlipDtlNum == salesDetailWork.StockSlipDtlNumSync ) &&
						( stockDetail.SupplierFormal == salesDetailWork.SupplierFormalSync ))
					{
						salesTempList.Add((SalesTemp)UIDataFromParamData(salesSlipWork, salesDetailWork));
					}
				}
			}

			return salesTempList;
		}

		/// <summary>
		/// PramData��UIData�ڍ�����
		/// </summary>
		/// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
		/// <param name="salesDetailWork">���㖾�׃f�[�^���[�N�I�u�W�F�N�g</param>
		/// <returns>����f�[�^(�d�������v��)�I�u�W�F�N�g</returns>
		public static SalesTemp UIDataFromParamData( SalesSlipWork salesSlipWork, SalesDetailWork salesDetailWork )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region �����ڃZ�b�g

			#region ������f�[�^����Z�b�g���鍀��

			salesTemp.CreateDateTime = salesSlipWork.CreateDateTime;
			salesTemp.UpdateDateTime = salesSlipWork.UpdateDateTime;
			salesTemp.EnterpriseCode = salesSlipWork.EnterpriseCode;
			salesTemp.FileHeaderGuid = salesSlipWork.FileHeaderGuid;
			salesTemp.UpdEmployeeCode = salesSlipWork.UpdEmployeeCode;
			salesTemp.UpdAssemblyId1 = salesSlipWork.UpdAssemblyId1;
			salesTemp.UpdAssemblyId2 = salesSlipWork.UpdAssemblyId2;
			salesTemp.LogicalDeleteCode = salesSlipWork.LogicalDeleteCode;
			salesTemp.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus;
			salesTemp.SectionCode = salesSlipWork.SectionCode;
			salesTemp.SubSectionCode = salesSlipWork.SubSectionCode;
			salesTemp.DebitNoteDiv = salesSlipWork.DebitNoteDiv;
			salesTemp.SalesSlipCd = salesSlipWork.SalesSlipCd;
			salesTemp.AccRecDivCd = salesSlipWork.AccRecDivCd;
			salesTemp.SalesInpSecCd = salesSlipWork.SalesInpSecCd;
			salesTemp.DemandAddUpSecCd = salesSlipWork.DemandAddUpSecCd;
			salesTemp.ResultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd;
			salesTemp.UpdateSecCd = salesSlipWork.UpdateSecCd;
			salesTemp.SearchSlipDate = salesSlipWork.SearchSlipDate;
			salesTemp.ShipmentDay = salesSlipWork.ShipmentDay;
			salesTemp.SalesDate = salesSlipWork.SalesDate;
			salesTemp.AddUpADate = salesSlipWork.AddUpADate;
			salesTemp.DelayPaymentDiv = salesSlipWork.DelayPaymentDiv;
			salesTemp.ClaimCode = salesSlipWork.ClaimCode;
			salesTemp.ClaimSnm = salesSlipWork.ClaimSnm;
			salesTemp.CustomerCode = salesSlipWork.CustomerCode;
			salesTemp.CustomerName = salesSlipWork.CustomerName;
			salesTemp.CustomerName2 = salesSlipWork.CustomerName2;
			salesTemp.CustomerSnm = salesSlipWork.CustomerSnm;
			salesTemp.HonorificTitle = salesSlipWork.HonorificTitle;
			salesTemp.OutputNameCode = salesSlipWork.OutputNameCode;
			salesTemp.BusinessTypeCode = salesSlipWork.BusinessTypeCode;
			salesTemp.BusinessTypeName = salesSlipWork.BusinessTypeName;
			salesTemp.SalesAreaCode = salesSlipWork.SalesAreaCode;
			salesTemp.SalesAreaName = salesSlipWork.SalesAreaName;
			salesTemp.SalesInputCode = salesSlipWork.SalesInputCode;
			salesTemp.SalesInputName = salesSlipWork.SalesInputName;
			salesTemp.FrontEmployeeCd = salesSlipWork.FrontEmployeeCd;
			salesTemp.FrontEmployeeNm = salesSlipWork.FrontEmployeeNm;
			salesTemp.SalesEmployeeCd = salesSlipWork.SalesEmployeeCd;
			salesTemp.SalesEmployeeNm = salesSlipWork.SalesEmployeeNm;
			salesTemp.ConsTaxLayMethod = salesSlipWork.ConsTaxLayMethod;
			salesTemp.ConsTaxRate = salesSlipWork.ConsTaxRate;
			salesTemp.FractionProcCd = salesSlipWork.FractionProcCd;
			salesTemp.AutoDepositCd = salesSlipWork.AutoDepositCd;
			//salesTempRow.AutoDepoSlipNum = salesSlipWork.AutoDepoSlipNum;
			salesTemp.SlipAddressDiv = salesSlipWork.SlipAddressDiv;
			salesTemp.AddresseeCode = salesSlipWork.AddresseeCode;
			salesTemp.AddresseeName = salesSlipWork.AddresseeName;
			salesTemp.AddresseeName2 = salesSlipWork.AddresseeName2;
			salesTemp.AddresseePostNo = salesSlipWork.AddresseePostNo;
			salesTemp.AddresseeAddr1 = salesSlipWork.AddresseeAddr1;
			salesTemp.AddresseeAddr3 = salesSlipWork.AddresseeAddr3;
			salesTemp.AddresseeAddr4 = salesSlipWork.AddresseeAddr4;
			salesTemp.AddresseeTelNo = salesSlipWork.AddresseeTelNo;
			salesTemp.AddresseeFaxNo = salesSlipWork.AddresseeFaxNo;
			salesTemp.PartySaleSlipNum = salesSlipWork.PartySaleSlipNum;
			salesTemp.SlipNote = salesSlipWork.SlipNote;
			salesTemp.SlipNote2 = salesSlipWork.SlipNote2;
			salesTemp.RetGoodsReasonDiv = salesSlipWork.RetGoodsReasonDiv;
			salesTemp.RetGoodsReason = salesSlipWork.RetGoodsReason;
			salesTemp.DetailRowCount = salesSlipWork.DetailRowCount;
			salesTemp.DeliveredGoodsDiv = salesSlipWork.DeliveredGoodsDiv;
			salesTemp.DeliveredGoodsDivNm = salesSlipWork.DeliveredGoodsDivNm;
			salesTemp.ReconcileFlag = salesSlipWork.ReconcileFlag;
			salesTemp.SlipPrtSetPaperId = salesSlipWork.SlipPrtSetPaperId;
			salesTemp.CompleteCd = salesSlipWork.CompleteCd;
			salesTemp.SalesPriceFracProcCd = salesSlipWork.SalesPriceFracProcCd;
			salesTemp.ListPricePrintDiv = salesSlipWork.ListPricePrintDiv;
			salesTemp.EraNameDispCd1 = salesSlipWork.EraNameDispCd1;
			//salesTempRow.AcceptAnOrderNo = salesSlipWork.AcceptAnOrderNo;
			//salesTempRow.CommonSeqNo = salesSlipWork.CommonSeqNo;
			//salesTempRow.SalesSlipDtlNum = salesSlipWork.SalesSlipDtlNum;
			//salesTempRow.AcptAnOdrStatusSrc = salesSlipWork.AcptAnOdrStatusSrc;
			//salesTempRow.SalesSlipDtlNumSrc = salesSlipWork.SalesSlipDtlNumSrc;
			//salesTempRow.SupplierFormalSync = salesSlipWork.SupplierFormalSync;
			//salesTempRow.StockSlipDtlNumSync = salesSlipWork.StockSlipDtlNumSync;
			//salesTempRow.SalesSlipCdDtl = salesSlipWork.SalesSlipCdDtl;
			salesTemp.OrderNumber = salesSlipWork.OrderNumber;
			//salesTempRow.StockMngExistCd = salesSlipWork.StockMngExistCd;
			//salesTempRow.DeliGdsCmpltDueDate = salesSlipWork.DeliGdsCmpltDueDate;
			//salesTempRow.GoodsKindCode = salesSlipWork.GoodsKindCode;
			//salesTempRow.GoodsMakerCd = salesSlipWork.GoodsMakerCd;
			//salesTempRow.MakerName = salesSlipWork.MakerName;
			//salesTempRow.GoodsNo = salesSlipWork.GoodsNo;
			//salesTempRow.GoodsName = salesSlipWork.GoodsName;
			//salesTempRow.GoodsShortName = salesSlipWork.GoodsShortName;
			//salesTempRow.GoodsSetDivCd = salesSlipWork.GoodsSetDivCd;
			//salesTempRow.LargeGoodsGanreCode = salesSlipWork.LargeGoodsGanreCode;
			//salesTempRow.LargeGoodsGanreName = salesSlipWork.LargeGoodsGanreName;
			//salesTempRow.MediumGoodsGanreCode = salesSlipWork.MediumGoodsGanreCode;
			//salesTempRow.MediumGoodsGanreName = salesSlipWork.MediumGoodsGanreName;
			//salesTempRow.DetailGoodsGanreCode = salesSlipWork.DetailGoodsGanreCode;
			//salesTempRow.DetailGoodsGanreName = salesSlipWork.DetailGoodsGanreName;
			//salesTempRow.BLGoodsCode = salesSlipWork.BLGoodsCode;
			//salesTempRow.BLGoodsFullName = salesSlipWork.BLGoodsFullName;
			//salesTempRow.EnterpriseGanreCode = salesSlipWork.EnterpriseGanreCode;
			//salesTempRow.EnterpriseGanreName = salesSlipWork.EnterpriseGanreName;
			//salesTempRow.WarehouseCode = salesSlipWork.WarehouseCode;
			//salesTempRow.WarehouseName = salesSlipWork.WarehouseName;
			//salesTempRow.WarehouseShelfNo = salesSlipWork.WarehouseShelfNo;
			//salesTempRow.SalesOrderDivCd = salesSlipWork.SalesOrderDivCd;
			//salesTempRow.OpenPriceDiv = salesSlipWork.OpenPriceDiv;
			//salesTempRow.UnitCode = salesSlipWork.UnitCode;
			//salesTempRow.UnitName = salesSlipWork.UnitName;
			//salesTempRow.GoodsRateRank = salesSlipWork.GoodsRateRank;
			//salesTempRow.CustRateGrpCode = salesSlipWork.CustRateGrpCode;
			//salesTempRow.SuppRateGrpCode = salesSlipWork.SuppRateGrpCode;
			//salesTempRow.ListPriceRate = salesSlipWork.ListPriceRate;
			//salesTempRow.RateSectPriceUnPrc = salesSlipWork.RateSectPriceUnPrc;
			//salesTempRow.RateDivLPrice = salesSlipWork.RateDivLPrice;
			//salesTempRow.UnPrcCalcCdLPrice = salesSlipWork.UnPrcCalcCdLPrice;
			//salesTempRow.PriceCdLPrice = salesSlipWork.PriceCdLPrice;
			//salesTempRow.StdUnPrcLPrice = salesSlipWork.StdUnPrcLPrice;
			//salesTempRow.FracProcUnitLPrice = salesSlipWork.FracProcUnitLPrice;
			//salesTempRow.FracProcLPrice = salesSlipWork.FracProcLPrice;
			//salesTempRow.ListPriceTaxIncFl = salesSlipWork.ListPriceTaxIncFl;
			//salesTempRow.ListPriceTaxExcFl = salesSlipWork.ListPriceTaxExcFl;
			//salesTempRow.ListPriceChngCd = salesSlipWork.ListPriceChngCd;
			//salesTempRow.SalesRate = salesSlipWork.SalesRate;
			//salesTempRow.RateSectSalUnPrc = salesSlipWork.RateSectSalUnPrc;
			//salesTempRow.RateDivSalUnPrc = salesSlipWork.RateDivSalUnPrc;
			//salesTempRow.UnPrcCalcCdSalUnPrc = salesSlipWork.UnPrcCalcCdSalUnPrc;
			//salesTempRow.PriceCdSalUnPrc = salesSlipWork.PriceCdSalUnPrc;
			//salesTempRow.StdUnPrcSalUnPrc = salesSlipWork.StdUnPrcSalUnPrc;
			//salesTempRow.FracProcUnitSalUnPrc = salesSlipWork.FracProcUnitSalUnPrc;
			//salesTempRow.FracProcSalUnPrc = salesSlipWork.FracProcSalUnPrc;
			//salesTempRow.SalesUnPrcTaxIncFl = salesSlipWork.SalesUnPrcTaxIncFl;
			//salesTempRow.SalesUnPrcTaxExcFl = salesSlipWork.SalesUnPrcTaxExcFl;
			//salesTempRow.SalesUnPrcChngCd = salesSlipWork.SalesUnPrcChngCd;
			//salesTempRow.CostRate = salesSlipWork.CostRate;
			//salesTempRow.RateSectCstUnPrc = salesSlipWork.RateSectCstUnPrc;
			//salesTempRow.RateDivUnCst = salesSlipWork.RateDivUnCst;
			//salesTempRow.UnPrcCalcCdUnCst = salesSlipWork.UnPrcCalcCdUnCst;
			//salesTempRow.PriceCdUnCst = salesSlipWork.PriceCdUnCst;
			//salesTempRow.StdUnPrcUnCst = salesSlipWork.StdUnPrcUnCst;
			//salesTempRow.FracProcUnitUnCst = salesSlipWork.FracProcUnitUnCst;
			//salesTempRow.FracProcUnCst = salesSlipWork.FracProcUnCst;
			//salesTempRow.SalesUnitCost = salesSlipWork.SalesUnitCost;
			//salesTempRow.SalesUnitCostChngDiv = salesSlipWork.SalesUnitCostChngDiv;
			//salesTempRow.RateBLGoodsCode = salesSlipWork.RateBLGoodsCode;
			//salesTempRow.RateBLGoodsName = salesSlipWork.RateBLGoodsName;
			//salesTempRow.BargainCd = salesSlipWork.BargainCd;
			//salesTempRow.BargainNm = salesSlipWork.BargainNm;
			//salesTempRow.ShipmentCnt = salesSlipWork.ShipmentCnt;
			//salesTempRow.SalesMoneyTaxInc = salesSlipWork.SalesMoneyTaxInc;
			//salesTempRow.SalesMoneyTaxExc = salesSlipWork.SalesMoneyTaxExc;
			//salesTempRow.Cost = salesSlipWork.Cost;
			//salesTempRow.GrsProfitChkDiv = salesSlipWork.GrsProfitChkDiv;
			//salesTempRow.SalesGoodsCd = salesSlipWork.SalesGoodsCd;
			//salesTempRow.SalsePriceConsTax = salesSlipWork.SalsePriceConsTax;
			//salesTempRow.TaxationDivCd = salesSlipWork.TaxationDivCd;
			//salesTempRow.PartySlipNumDtl = salesSlipWork.PartySlipNumDtl;
			//salesTempRow.DtlNote = salesSlipWork.DtlNote;
			//salesTempRow.SupplierCd = salesSlipWork.SupplierCd;
			//salesTempRow.SupplierSnm = salesSlipWork.SupplierSnm;
			//salesTempRow.SlipMemo1 = salesSlipWork.SlipMemo1;
			//salesTempRow.SlipMemo2 = salesSlipWork.SlipMemo2;
			//salesTempRow.SlipMemo3 = salesSlipWork.SlipMemo3;
			//salesTempRow.SlipMemo4 = salesSlipWork.SlipMemo4;
			//salesTempRow.SlipMemo5 = salesSlipWork.SlipMemo5;
			//salesTempRow.SlipMemo6 = salesSlipWork.SlipMemo6;
			//salesTempRow.InsideMemo1 = salesSlipWork.InsideMemo1;
			//salesTempRow.InsideMemo2 = salesSlipWork.InsideMemo2;
			//salesTempRow.InsideMemo3 = salesSlipWork.InsideMemo3;
			//salesTempRow.InsideMemo4 = salesSlipWork.InsideMemo4;
			//salesTempRow.InsideMemo5 = salesSlipWork.InsideMemo5;
			//salesTempRow.InsideMemo6 = salesSlipWork.InsideMemo6;
			//salesTempRow.BfListPrice = salesSlipWork.BfListPrice;
			//salesTempRow.BfSalesUnitPrice = salesSlipWork.BfSalesUnitPrice;
			//salesTempRow.BfUnitCost = salesSlipWork.BfUnitCost;
			//salesTempRow.PrtGoodsNo = salesSlipWork.PrtGoodsNo;
			//salesTempRow.PrtGoodsName = salesSlipWork.PrtGoodsName;
			//salesTempRow.PrtGoodsMakerCd = salesSlipWork.PrtGoodsMakerCd;
			//salesTempRow.PrtGoodsMakerNm = salesSlipWork.PrtGoodsMakerNm;
			//salesTempRow.SupplierSlipCd = salesSlipWork.SupplierSlipCd;
			//salesTempRow.TotalAmountDispWayCd = salesSlipWork.TotalAmountDispWayCd;
			//salesTempRow.TtlAmntDispRateApy = salesSlipWork.TtlAmntDispRateApy;
			//salesTempRow.ConfirmedDiv = salesSlipWork.ConfirmedDiv;
			//salesTempRow.NTimeCalcStDate = salesSlipWork.NTimeCalcStDate;
			//salesTempRow.TotalDay = salesSlipWork.TotalDay;
			//salesTempRow.DtlRelationGuid = salesSlipWork.DtlRelationGuid;


			#endregion

			#region �����㖾�׃f�[�^����Z�b�g���鍀��

			// ���q�ɃR�[�h�̓g�������ăZ�b�g

			//salesTempRow.CreateDateTime = salesDetailWork.CreateDateTime;
			//salesTempRow.UpdateDateTime = salesDetailWork.UpdateDateTime;
			//salesTempRow.EnterpriseCode = salesDetailWork.EnterpriseCode;
			//salesTempRow.FileHeaderGuid = salesDetailWork.FileHeaderGuid;
			//salesTempRow.UpdEmployeeCode = salesDetailWork.UpdEmployeeCode;
			//salesTempRow.UpdAssemblyId1 = salesDetailWork.UpdAssemblyId1;
			//salesTempRow.UpdAssemblyId2 = salesDetailWork.UpdAssemblyId2;
			//salesTempRow.LogicalDeleteCode = salesDetailWork.LogicalDeleteCode;
			//salesTempRow.AcptAnOdrStatus = salesDetailWork.AcptAnOdrStatus;
			//salesTempRow.SectionCode = salesDetailWork.SectionCode;
			//salesTempRow.SubSectionCode = salesDetailWork.SubSectionCode;
			//salesTempRow.MinSectionCode = salesDetailWork.MinSectionCode;
			//salesTempRow.DebitNoteDiv = salesDetailWork.DebitNoteDiv;
			//salesTempRow.DebitNLnkAcptAnOdr = salesDetailWork.DebitNLnkAcptAnOdr;
			//salesTempRow.SalesSlipCd = salesDetailWork.SalesSlipCd;
			//salesTempRow.AccRecDivCd = salesDetailWork.AccRecDivCd;
			//salesTempRow.SalesInpSecCd = salesDetailWork.SalesInpSecCd;
			//salesTempRow.DemandAddUpSecCd = salesDetailWork.DemandAddUpSecCd;
			//salesTempRow.ResultsAddUpSecCd = salesDetailWork.ResultsAddUpSecCd;
			//salesTempRow.UpdateSecCd = salesDetailWork.UpdateSecCd;
			//salesTempRow.SearchSlipDate = salesDetailWork.SearchSlipDate;
			//salesTempRow.ShipmentDay = salesDetailWork.ShipmentDay;
			//salesTempRow.SalesDate = salesDetailWork.SalesDate;
			//salesTempRow.AddUpADate = salesDetailWork.AddUpADate;
			//salesTempRow.DelayPaymentDiv = salesDetailWork.DelayPaymentDiv;
			//salesTempRow.ClaimCode = salesDetailWork.ClaimCode;
			//salesTempRow.ClaimSnm = salesDetailWork.ClaimSnm;
			//salesTempRow.CustomerCode = salesDetailWork.CustomerCode;
			//salesTempRow.CustomerName = salesDetailWork.CustomerName;
			//salesTempRow.CustomerName2 = salesDetailWork.CustomerName2;
			//salesTempRow.CustomerSnm = salesDetailWork.CustomerSnm;
			//salesTempRow.HonorificTitle = salesDetailWork.HonorificTitle;
			//salesTempRow.OutputNameCode = salesDetailWork.OutputNameCode;
			//salesTempRow.BusinessTypeCode = salesDetailWork.BusinessTypeCode;
			//salesTempRow.BusinessTypeName = salesDetailWork.BusinessTypeName;
			//salesTempRow.SalesAreaCode = salesDetailWork.SalesAreaCode;
			//salesTempRow.SalesAreaName = salesDetailWork.SalesAreaName;
			//salesTempRow.SalesInputCode = salesDetailWork.SalesInputCode;
			//salesTempRow.SalesInputName = salesDetailWork.SalesInputName;
			//salesTempRow.FrontEmployeeCd = salesDetailWork.FrontEmployeeCd;
			//salesTempRow.FrontEmployeeNm = salesDetailWork.FrontEmployeeNm;
			//salesTempRow.SalesEmployeeCd = salesDetailWork.SalesEmployeeCd;
			//salesTempRow.SalesEmployeeNm = salesDetailWork.SalesEmployeeNm;
			//salesTempRow.ConsTaxLayMethod = salesDetailWork.ConsTaxLayMethod;
			//salesTempRow.ConsTaxRate = salesDetailWork.ConsTaxRate;
			//salesTempRow.FractionProcCd = salesDetailWork.FractionProcCd;
			//salesTempRow.AutoDepositCd = salesDetailWork.AutoDepositCd;
			//salesTempRow.AutoDepoSlipNum = salesDetailWork.AutoDepoSlipNum;
			//salesTempRow.SlipAddressDiv = salesDetailWork.SlipAddressDiv;
			//salesTempRow.AddresseeCode = salesDetailWork.AddresseeCode;
			//salesTempRow.AddresseeName = salesDetailWork.AddresseeName;
			//salesTempRow.AddresseeName2 = salesDetailWork.AddresseeName2;
			//salesTempRow.AddresseePostNo = salesDetailWork.AddresseePostNo;
			//salesTempRow.AddresseeAddr1 = salesDetailWork.AddresseeAddr1;
			//salesTempRow.AddresseeAddr2 = salesDetailWork.AddresseeAddr2;
			//salesTempRow.AddresseeAddr3 = salesDetailWork.AddresseeAddr3;
			//salesTempRow.AddresseeAddr4 = salesDetailWork.AddresseeAddr4;
			//salesTempRow.AddresseeTelNo = salesDetailWork.AddresseeTelNo;
			//salesTempRow.AddresseeFaxNo = salesDetailWork.AddresseeFaxNo;
			//salesTempRow.PartySaleSlipNum = salesDetailWork.PartySaleSlipNum;
			//salesTempRow.SlipNote = salesDetailWork.SlipNote;
			//salesTempRow.SlipNote2 = salesDetailWork.SlipNote2;
			//salesTempRow.RetGoodsReasonDiv = salesDetailWork.RetGoodsReasonDiv;
			//salesTempRow.RetGoodsReason = salesDetailWork.RetGoodsReason;
			//salesTempRow.DetailRowCount = salesDetailWork.DetailRowCount;
			//salesTempRow.DeliveredGoodsDiv = salesDetailWork.DeliveredGoodsDiv;
			//salesTempRow.DeliveredGoodsDivNm = salesDetailWork.DeliveredGoodsDivNm;
			//salesTempRow.ReconcileFlag = salesDetailWork.ReconcileFlag;
			//salesTempRow.SlipPrtSetPaperId = salesDetailWork.SlipPrtSetPaperId;
			//salesTempRow.CompleteCd = salesDetailWork.CompleteCd;
			//salesTempRow.ClaimType = salesDetailWork.ClaimType;
			//salesTempRow.SalesPriceFracProcCd = salesDetailWork.SalesPriceFracProcCd;
			//salesTempRow.ListPricePrintDiv = salesDetailWork.ListPricePrintDiv;
			//salesTempRow.EraNameDispCd1 = salesDetailWork.EraNameDispCd1;
			salesTemp.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo;
			salesTemp.CommonSeqNo = salesDetailWork.CommonSeqNo;
			salesTemp.SalesSlipDtlNum = salesDetailWork.SalesSlipDtlNum;
			salesTemp.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatusSrc;
			salesTemp.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNumSrc;
			salesTemp.SupplierFormalSync = salesDetailWork.SupplierFormalSync;
			salesTemp.StockSlipDtlNumSync = salesDetailWork.StockSlipDtlNumSync;
			salesTemp.SalesSlipCdDtl = salesDetailWork.SalesSlipCdDtl;
			salesTemp.OrderNumber = salesDetailWork.OrderNumber;
			salesTemp.DeliGdsCmpltDueDate = salesDetailWork.DeliGdsCmpltDueDate;
			salesTemp.GoodsKindCode = salesDetailWork.GoodsKindCode;
			salesTemp.GoodsMakerCd = salesDetailWork.GoodsMakerCd;
			salesTemp.MakerName = salesDetailWork.MakerName;
			salesTemp.GoodsNo = salesDetailWork.GoodsNo;
			salesTemp.GoodsName = salesDetailWork.GoodsName;
			//salesTemp.GoodsShortName = salesDetailWork.GoodsShortName;
			salesTemp.BLGoodsCode = salesDetailWork.BLGoodsCode;
			salesTemp.BLGoodsFullName = salesDetailWork.BLGoodsFullName;
			salesTemp.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode;
			salesTemp.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName;
			salesTemp.WarehouseCode = salesDetailWork.WarehouseCode.Trim();
			salesTemp.WarehouseName = salesDetailWork.WarehouseName;
			salesTemp.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo;
			salesTemp.SalesOrderDivCd = salesDetailWork.SalesOrderDivCd;
			salesTemp.OpenPriceDiv = salesDetailWork.OpenPriceDiv;
			salesTemp.GoodsRateRank = salesDetailWork.GoodsRateRank;
			salesTemp.CustRateGrpCode = salesDetailWork.CustRateGrpCode;
			salesTemp.ListPriceRate = salesDetailWork.ListPriceRate;
			salesTemp.RateSectPriceUnPrc = salesDetailWork.RateSectPriceUnPrc;
			salesTemp.RateDivLPrice = salesDetailWork.RateDivLPrice;
			salesTemp.UnPrcCalcCdLPrice = salesDetailWork.UnPrcCalcCdLPrice;
			salesTemp.PriceCdLPrice = salesDetailWork.PriceCdLPrice;
			salesTemp.StdUnPrcLPrice = salesDetailWork.StdUnPrcLPrice;
			salesTemp.FracProcUnitLPrice = salesDetailWork.FracProcUnitLPrice;
			salesTemp.FracProcLPrice = salesDetailWork.FracProcLPrice;
			salesTemp.ListPriceTaxIncFl = salesDetailWork.ListPriceTaxIncFl;
			salesTemp.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl;
			salesTemp.ListPriceChngCd = salesDetailWork.ListPriceChngCd;
			salesTemp.SalesRate = salesDetailWork.SalesRate;
			salesTemp.RateSectSalUnPrc = salesDetailWork.RateSectSalUnPrc;
			salesTemp.RateDivSalUnPrc = salesDetailWork.RateDivSalUnPrc;
			salesTemp.UnPrcCalcCdSalUnPrc = salesDetailWork.UnPrcCalcCdSalUnPrc;
			salesTemp.PriceCdSalUnPrc = salesDetailWork.PriceCdSalUnPrc;
			salesTemp.StdUnPrcSalUnPrc = salesDetailWork.StdUnPrcSalUnPrc;
			salesTemp.FracProcUnitSalUnPrc = salesDetailWork.FracProcUnitSalUnPrc;
			salesTemp.FracProcSalUnPrc = salesDetailWork.FracProcSalUnPrc;
			salesTemp.SalesUnPrcTaxIncFl = salesDetailWork.SalesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl;
			salesTemp.SalesUnPrcChngCd = salesDetailWork.SalesUnPrcChngCd;
			salesTemp.CostRate = salesDetailWork.CostRate;
			salesTemp.RateSectCstUnPrc = salesDetailWork.RateSectCstUnPrc;
			salesTemp.RateDivUnCst = salesDetailWork.RateDivUnCst;
			salesTemp.UnPrcCalcCdUnCst = salesDetailWork.UnPrcCalcCdUnCst;
			salesTemp.PriceCdUnCst = salesDetailWork.PriceCdUnCst;
			salesTemp.StdUnPrcUnCst = salesDetailWork.StdUnPrcUnCst;
			salesTemp.FracProcUnitUnCst = salesDetailWork.FracProcUnitUnCst;
			salesTemp.FracProcUnCst = salesDetailWork.FracProcUnCst;
			salesTemp.SalesUnitCost = salesDetailWork.SalesUnitCost;
			salesTemp.SalesUnitCostChngDiv = salesDetailWork.SalesUnitCostChngDiv;
			salesTemp.RateBLGoodsCode = salesDetailWork.RateBLGoodsCode;
			salesTemp.RateBLGoodsName = salesDetailWork.RateBLGoodsName;
			salesTemp.ShipmentCnt = salesDetailWork.ShipmentCnt;
			salesTemp.SalesMoneyTaxInc = salesDetailWork.SalesMoneyTaxInc;
			salesTemp.SalesMoneyTaxExc = salesDetailWork.SalesMoneyTaxExc;
			salesTemp.Cost = salesDetailWork.Cost;
			salesTemp.GrsProfitChkDiv = salesDetailWork.GrsProfitChkDiv;
			salesTemp.SalesGoodsCd = salesDetailWork.SalesGoodsCd;
			salesTemp.TaxationDivCd = salesDetailWork.TaxationDivCd;
			salesTemp.PartySlipNumDtl = salesDetailWork.PartySlipNumDtl;
			salesTemp.DtlNote = salesDetailWork.DtlNote;
			salesTemp.SupplierCd = salesDetailWork.SupplierCd;
			salesTemp.SupplierSnm = salesDetailWork.SupplierSnm;
			salesTemp.SlipMemo1 = salesDetailWork.SlipMemo1;
			salesTemp.SlipMemo2 = salesDetailWork.SlipMemo2;
			salesTemp.SlipMemo3 = salesDetailWork.SlipMemo3;
			salesTemp.InsideMemo1 = salesDetailWork.InsideMemo1;
			salesTemp.InsideMemo2 = salesDetailWork.InsideMemo2;
			salesTemp.InsideMemo3 = salesDetailWork.InsideMemo3;
			salesTemp.BfListPrice = salesDetailWork.BfListPrice;
			salesTemp.BfSalesUnitPrice = salesDetailWork.BfSalesUnitPrice;
			salesTemp.BfUnitCost = salesDetailWork.BfUnitCost;
			//salesTempRow.SupplierSlipCd = salesDetailWork.SupplierSlipCd;
			//salesTempRow.TotalAmountDispWayCd = salesDetailWork.TotalAmountDispWayCd;
			//salesTempRow.TtlAmntDispRateApy = salesDetailWork.TtlAmntDispRateApy;
			//salesTempRow.ConfirmedDiv = salesDetailWork.ConfirmedDiv;
			//salesTempRow.NTimeCalcStDate = salesDetailWork.NTimeCalcStDate;
			//salesTempRow.TotalDay = salesDetailWork.TotalDay;
			salesTemp.DtlRelationGuid = salesDetailWork.DtlRelationGuid;


			#endregion

			#endregion

			return salesTemp;
		}



		/// <summary>
		/// UIData��PramData�ڍ�����
		/// </summary>
		/// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <returns>�d���f�[�^���[�N�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
		public static StockSlipWork ParamDataFromUIData( StockSlip stockSlip )
		{
			StockSlipWork stockSlipWork = new StockSlipWork();

			#region �����ڃZ�b�g

			stockSlipWork.CreateDateTime = stockSlip.CreateDateTime;			// �쐬����
			stockSlipWork.UpdateDateTime = stockSlip.UpdateDateTime;			// �X�V����
			stockSlipWork.EnterpriseCode = stockSlip.EnterpriseCode;			// ��ƃR�[�h
			stockSlipWork.FileHeaderGuid = stockSlip.FileHeaderGuid;			// GUID
			stockSlipWork.UpdEmployeeCode = stockSlip.UpdEmployeeCode;			// �X�V�]�ƈ��R�[�h
			stockSlipWork.UpdAssemblyId1 = stockSlip.UpdAssemblyId1;			// �X�V�A�Z���u��ID1
			stockSlipWork.UpdAssemblyId2 = stockSlip.UpdAssemblyId2;			// �X�V�A�Z���u��ID2
			stockSlipWork.LogicalDeleteCode = stockSlip.LogicalDeleteCode;		// �_���폜�敪
			stockSlipWork.SupplierFormal = stockSlip.SupplierFormal;			// �d���`��
			stockSlipWork.SupplierSlipNo = stockSlip.SupplierSlipNo;			// �d���`�[�ԍ�
			stockSlipWork.SectionCode = stockSlip.SectionCode;					// ���_�R�[�h
			stockSlipWork.SubSectionCode = stockSlip.SubSectionCode;			// ����R�[�h
			stockSlipWork.DebitNoteDiv = stockSlip.DebitNoteDiv;				// �ԓ`�敪
			stockSlipWork.DebitNLnkSuppSlipNo = stockSlip.DebitNLnkSuppSlipNo;	// �ԍ��A���d���`�[�ԍ�
			stockSlipWork.SupplierSlipCd = stockSlip.SupplierSlipCd;			// �d���`�[�敪
			stockSlipWork.StockGoodsCd = stockSlip.StockGoodsCd;				// �d�����i�敪
			stockSlipWork.AccPayDivCd = stockSlip.AccPayDivCd;					// ���|�敪
			stockSlipWork.StockSectionCd = stockSlip.StockSectionCd;			// �d�����_�R�[�h
			stockSlipWork.StockAddUpSectionCd = stockSlip.StockAddUpSectionCd;	// �d���v�㋒�_�R�[�h
			stockSlipWork.StockSlipUpdateCd = stockSlip.StockSlipUpdateCd;		// �d���`�[�X�V�敪
			stockSlipWork.InputDay = stockSlip.InputDay;						// ���͓�
			stockSlipWork.ArrivalGoodsDay = stockSlip.ArrivalGoodsDay;			// ���ד�
			stockSlipWork.StockDate = stockSlip.StockDate;						// �d����
            stockSlipWork.PreStockDate = stockSlip.PreStockDate;				// �O��d���� // ADD 2011/12/15
			stockSlipWork.StockAddUpADate = stockSlip.StockAddUpADate;			// �d���v����t
			stockSlipWork.DelayPaymentDiv = stockSlip.DelayPaymentDiv;			// �����敪
			stockSlipWork.PayeeCode = stockSlip.PayeeCode;						// �x����R�[�h
			stockSlipWork.PayeeSnm = stockSlip.PayeeSnm;						// �x���旪��
			stockSlipWork.SupplierCd = stockSlip.SupplierCd;					// �d����R�[�h
			stockSlipWork.SupplierNm1 = stockSlip.SupplierNm1;					// �d���於1
			stockSlipWork.SupplierNm2 = stockSlip.SupplierNm2;					// �d���於2
			stockSlipWork.SupplierSnm = stockSlip.SupplierSnm;					// �d���旪��
			stockSlipWork.BusinessTypeCode = stockSlip.BusinessTypeCode;		// �Ǝ�R�[�h
			stockSlipWork.BusinessTypeName = stockSlip.BusinessTypeName;		// �Ǝ햼��
			stockSlipWork.SalesAreaCode = stockSlip.SalesAreaCode;				// �̔��G���A�R�[�h
			stockSlipWork.SalesAreaName = stockSlip.SalesAreaName;				// �̔��G���A����
			stockSlipWork.StockInputCode = stockSlip.StockInputCode;			// �d�����͎҃R�[�h
			stockSlipWork.StockInputName = stockSlip.StockInputName;			// �d�����͎Җ���
			stockSlipWork.StockAgentCode = stockSlip.StockAgentCode;			// �d���S���҃R�[�h
			stockSlipWork.StockAgentName = stockSlip.StockAgentName;			// �d���S���Җ���
			stockSlipWork.SuppTtlAmntDspWayCd = stockSlip.SuppTtlAmntDspWayCd;	// �d���摍�z�\�����@�敪
			stockSlipWork.TtlAmntDispRateApy = stockSlip.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
			stockSlipWork.StockTotalPrice = stockSlip.StockTotalPrice;			// �d�����z���v
			stockSlipWork.StockSubttlPrice = stockSlip.StockSubttlPrice;		// �d�����z���v
			stockSlipWork.StockTtlPricTaxInc = stockSlip.StockTtlPricTaxInc;	// �d�����z�v�i�ō��݁j
			stockSlipWork.StockTtlPricTaxExc = stockSlip.StockTtlPricTaxExc;	// �d�����z�v�i�Ŕ����j
			stockSlipWork.StockNetPrice = stockSlip.StockNetPrice;				// �d���������z
			stockSlipWork.StockPriceConsTax = stockSlip.StockPriceConsTax;		// �d�����z����Ŋz
			stockSlipWork.TtlItdedStcOutTax = stockSlip.TtlItdedStcOutTax;		// �d���O�őΏۊz���v
			stockSlipWork.TtlItdedStcInTax = stockSlip.TtlItdedStcInTax;		// �d�����őΏۊz���v
			stockSlipWork.TtlItdedStcTaxFree = stockSlip.TtlItdedStcTaxFree;	// �d����ېőΏۊz���v
			stockSlipWork.StockOutTax = stockSlip.StockOutTax;					// �d�����z����Ŋz�i�O�Łj
			stockSlipWork.StckPrcConsTaxInclu = stockSlip.StckPrcConsTaxInclu;	// �d�����z����Ŋz�i���Łj
			stockSlipWork.StckDisTtlTaxExc = stockSlip.StckDisTtlTaxExc;		// �d���l�����z�v�i�Ŕ����j
			stockSlipWork.ItdedStockDisOutTax = stockSlip.ItdedStockDisOutTax;	// �d���l���O�őΏۊz���v
			stockSlipWork.ItdedStockDisInTax = stockSlip.ItdedStockDisInTax;	// �d���l�����őΏۊz���v
			stockSlipWork.ItdedStockDisTaxFre = stockSlip.ItdedStockDisTaxFre;	// �d���l����ېőΏۊz���v
			stockSlipWork.StockDisOutTax = stockSlip.StockDisOutTax;			// �d���l������Ŋz�i�O�Łj
			stockSlipWork.StckDisTtlTaxInclu = stockSlip.StckDisTtlTaxInclu;	// �d���l������Ŋz�i���Łj
			stockSlipWork.TaxAdjust = stockSlip.TaxAdjust;						// ����Œ����z
			stockSlipWork.BalanceAdjust = stockSlip.BalanceAdjust;				// �c�������z
			stockSlipWork.SuppCTaxLayCd = stockSlip.SuppCTaxLayCd;				// �d�������œ]�ŕ����R�[�h
			stockSlipWork.SupplierConsTaxRate = stockSlip.SupplierConsTaxRate;	// �d�������Őŗ�
			stockSlipWork.AccPayConsTax = stockSlip.AccPayConsTax;				// ���|�����
			stockSlipWork.StockFractionProcCd = stockSlip.StockFractionProcCd;	// �d���[�������敪
			stockSlipWork.AutoPayment = stockSlip.AutoPayment;					// �����x���敪
			stockSlipWork.AutoPaySlipNum = stockSlip.AutoPaySlipNum;			// �����x���`�[�ԍ�
			stockSlipWork.RetGoodsReasonDiv = stockSlip.RetGoodsReasonDiv;		// �ԕi���R�R�[�h
			stockSlipWork.RetGoodsReason = stockSlip.RetGoodsReason;			// �ԕi���R
			stockSlipWork.PartySaleSlipNum = stockSlip.PartySaleSlipNum;		// �����`�[�ԍ�
			stockSlipWork.SupplierSlipNote1 = stockSlip.SupplierSlipNote1;		// �d���`�[���l1
			stockSlipWork.SupplierSlipNote2 = stockSlip.SupplierSlipNote2;		// �d���`�[���l2
			stockSlipWork.DetailRowCount = stockSlip.DetailRowCount;			// ���׍s��
			stockSlipWork.EdiSendDate = stockSlip.EdiSendDate;					// �d�c�h���M��
			stockSlipWork.EdiTakeInDate = stockSlip.EdiTakeInDate;				// �d�c�h�捞��
			stockSlipWork.UoeRemark1 = stockSlip.UoeRemark1;					// �t�n�d���}�[�N�P
			stockSlipWork.UoeRemark2 = stockSlip.UoeRemark2;					// �t�n�d���}�[�N�Q
			stockSlipWork.SlipPrintDivCd = stockSlip.SlipPrintDivCd;			// �`�[���s�敪
			stockSlipWork.SlipPrintFinishCd = stockSlip.SlipPrintFinishCd;		// �`�[���s�ϋ敪
			stockSlipWork.StockSlipPrintDate = stockSlip.StockSlipPrintDate;	// �d���`�[���s��
			stockSlipWork.SlipPrtSetPaperId = stockSlip.SlipPrtSetPaperId;		// �`�[����ݒ�p���[ID
			stockSlipWork.SlipAddressDiv = stockSlip.SlipAddressDiv;			// �`�[�Z���敪
			stockSlipWork.AddresseeCode = stockSlip.AddresseeCode;				// �[�i��R�[�h
			stockSlipWork.AddresseeName = stockSlip.AddresseeName;				// �[�i�於��
			stockSlipWork.AddresseeName2 = stockSlip.AddresseeName2;			// �[�i�於��2
			stockSlipWork.AddresseePostNo = stockSlip.AddresseePostNo;			// �[�i��X�֔ԍ�
			stockSlipWork.AddresseeAddr1 = stockSlip.AddresseeAddr1;			// �[�i��Z��1(�s���{���s��S�E�����E��)
			stockSlipWork.AddresseeAddr3 = stockSlip.AddresseeAddr3;			// �[�i��Z��3(�Ԓn)
			stockSlipWork.AddresseeAddr4 = stockSlip.AddresseeAddr4;			// �[�i��Z��4(�A�p�[�g����)
			stockSlipWork.AddresseeTelNo = stockSlip.AddresseeTelNo;			// �[�i��d�b�ԍ�
			stockSlipWork.AddresseeFaxNo = stockSlip.AddresseeFaxNo;			// �[�i��FAX�ԍ�
			stockSlipWork.DirectSendingCd = stockSlip.DirectSendingCd;			// �����敪

			#endregion


            // �␳
            // �d���S���Җ���
            if (stockSlipWork.StockAgentName.Length > 16)
            {
                stockSlipWork.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
            }
            // �d�����͎Җ���
            if (stockSlipWork.StockInputName.Length > 16)
            {
                stockSlipWork.StockInputName = stockSlip.StockInputName.Substring(0, 16);
            }

			return stockSlipWork;
		}
		/// <summary>
		/// UIData��PramData�ڍ�����
		/// </summary>
		/// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
		/// <returns>�d�����׃f�[�^���[�N�I�u�W�F�N�g</returns>
		public static StockDetailWork ParamDataFromUIData( StockDetail stockDetail )
		{
			StockDetailWork stockDetailWork = new StockDetailWork();

			#region �����ڃZ�b�g

            stockDetailWork.CreateDateTime = stockDetail.CreateDateTime;                // �쐬����
            stockDetailWork.UpdateDateTime = stockDetail.UpdateDateTime;                // �X�V����
            stockDetailWork.EnterpriseCode = stockDetail.EnterpriseCode;                // ��ƃR�[�h
            stockDetailWork.FileHeaderGuid = stockDetail.FileHeaderGuid;                // GUID
            stockDetailWork.UpdEmployeeCode = stockDetail.UpdEmployeeCode;              // �X�V�]�ƈ��R�[�h
            stockDetailWork.UpdAssemblyId1 = stockDetail.UpdAssemblyId1;                // �X�V�A�Z���u��ID1
            stockDetailWork.UpdAssemblyId2 = stockDetail.UpdAssemblyId2;                // �X�V�A�Z���u��ID2
            stockDetailWork.LogicalDeleteCode = stockDetail.LogicalDeleteCode;          // �_���폜�敪
            stockDetailWork.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;              // �󒍔ԍ�
            stockDetailWork.SupplierFormal = stockDetail.SupplierFormal;                // �d���`��
            stockDetailWork.SupplierSlipNo = stockDetail.SupplierSlipNo;                // �d���`�[�ԍ�
            stockDetailWork.StockRowNo = stockDetail.StockRowNo;                        // �d���s�ԍ�
            stockDetailWork.SectionCode = stockDetail.SectionCode;                      // ���_�R�[�h
            stockDetailWork.SubSectionCode = stockDetail.SubSectionCode;                // ����R�[�h
            stockDetailWork.CommonSeqNo = stockDetail.CommonSeqNo;                      // ���ʒʔ�
            stockDetailWork.StockSlipDtlNum = stockDetail.StockSlipDtlNum;              // �d�����גʔ�
            stockDetailWork.SupplierFormalSrc = stockDetail.SupplierFormalSrc;          // �d���`���i���j
            stockDetailWork.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNumSrc;        // �d�����גʔԁi���j
            stockDetailWork.AcptAnOdrStatusSync = stockDetail.AcptAnOdrStatusSync;      // �󒍃X�e�[�^�X�i�����j
            stockDetailWork.SalesSlipDtlNumSync = stockDetail.SalesSlipDtlNumSync;      // ���㖾�גʔԁi�����j
            stockDetailWork.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                // �d���`�[�敪�i���ׁj
            stockDetailWork.StockInputCode = stockDetail.StockInputCode;                // �d�����͎҃R�[�h
            stockDetailWork.StockInputName = stockDetail.StockInputName;                // �d�����͎Җ���
            stockDetailWork.StockAgentCode = stockDetail.StockAgentCode;                // �d���S���҃R�[�h
            stockDetailWork.StockAgentName = stockDetail.StockAgentName;                // �d���S���Җ���
            stockDetailWork.GoodsKindCode = stockDetail.GoodsKindCode;                  // ���i����
            stockDetailWork.GoodsMakerCd = stockDetail.GoodsMakerCd;                    // ���i���[�J�[�R�[�h
            stockDetailWork.MakerName = stockDetail.MakerName;                          // ���[�J�[����
            stockDetailWork.MakerKanaName = stockDetail.MakerKanaName;                  // ���[�J�[�J�i����
            stockDetailWork.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;        // ���[�J�[�J�i���́i�ꎮ�j
            stockDetailWork.GoodsNo = stockDetail.GoodsNo;                              // ���i�ԍ�
            stockDetailWork.GoodsName = stockDetail.GoodsName;                          // ���i����
            stockDetailWork.GoodsNameKana = stockDetail.GoodsNameKana;                  // ���i���̃J�i
            stockDetailWork.GoodsLGroup = stockDetail.GoodsLGroup;                      // ���i�啪�ރR�[�h
            stockDetailWork.GoodsLGroupName = stockDetail.GoodsLGroupName;              // ���i�啪�ޖ���
            stockDetailWork.GoodsMGroup = stockDetail.GoodsMGroup;                      // ���i�����ރR�[�h
            stockDetailWork.GoodsMGroupName = stockDetail.GoodsMGroupName;              // ���i�����ޖ���
            stockDetailWork.BLGroupCode = stockDetail.BLGroupCode;                      // BL�O���[�v�R�[�h
            stockDetailWork.BLGroupName = stockDetail.BLGroupName;                      // BL�O���[�v�R�[�h����
            stockDetailWork.BLGoodsCode = stockDetail.BLGoodsCode;                      // BL���i�R�[�h
            stockDetailWork.BLGoodsFullName = stockDetail.BLGoodsFullName;              // BL���i�R�[�h���́i�S�p�j
            stockDetailWork.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;      // ���Е��ރR�[�h
            stockDetailWork.EnterpriseGanreName = stockDetail.EnterpriseGanreName;      // ���Е��ޖ���
            stockDetailWork.WarehouseCode = stockDetail.WarehouseCode;                  // �q�ɃR�[�h
            stockDetailWork.WarehouseName = stockDetail.WarehouseName;                  // �q�ɖ���
            stockDetailWork.WarehouseShelfNo = stockDetail.WarehouseShelfNo;            // �q�ɒI��
            stockDetailWork.StockOrderDivCd = stockDetail.StockOrderDivCd;              // �d���݌Ɏ�񂹋敪
            stockDetailWork.OpenPriceDiv = stockDetail.OpenPriceDiv;                    // �I�[�v�����i�敪
            stockDetailWork.GoodsRateRank = stockDetail.GoodsRateRank;                  // ���i�|�������N
            stockDetailWork.CustRateGrpCode = stockDetail.CustRateGrpCode;              // ���Ӑ�|���O���[�v�R�[�h
            stockDetailWork.SuppRateGrpCode = stockDetail.SuppRateGrpCode;              // �d����|���O���[�v�R�[�h
            stockDetailWork.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;          // �艿�i�Ŕ��C�����j
            stockDetailWork.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;          // �艿�i�ō��C�����j
            stockDetailWork.StockRate = stockDetail.StockRate;                          // �d����
            stockDetailWork.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;          // �|���ݒ苒�_�i�d���P���j
            stockDetailWork.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;            // �|���ݒ�敪�i�d���P���j
            stockDetailWork.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;    // �P���Z�o�敪�i�d���P���j
            stockDetailWork.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;            // ���i�敪�i�d���P���j
            stockDetailWork.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;          // ��P���i�d���P���j
            stockDetailWork.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;    // �[�������P�ʁi�d���P���j
            stockDetailWork.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;          // �[�������i�d���P���j
            stockDetailWork.StockUnitPriceFl = stockDetail.StockUnitPriceFl;            // �d���P���i�Ŕ��C�����j
            stockDetailWork.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;      // �d���P���i�ō��C�����j
            stockDetailWork.StockUnitChngDiv = stockDetail.StockUnitChngDiv;            // �d���P���ύX�敪
            stockDetailWork.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;        // �ύX�O�d���P���i�����j
            stockDetailWork.BfListPrice = stockDetail.BfListPrice;                      // �ύX�O�艿
            stockDetailWork.RateBLGoodsCode = stockDetail.RateBLGoodsCode;              // BL���i�R�[�h�i�|���j
            stockDetailWork.RateBLGoodsName = stockDetail.RateBLGoodsName;              // BL���i�R�[�h���́i�|���j
            stockDetailWork.RateGoodsRateGrpCd = stockDetail.RateGoodsRateGrpCd;        // ���i�|���O���[�v�R�[�h�i�|���j
            stockDetailWork.RateGoodsRateGrpNm = stockDetail.RateGoodsRateGrpNm;        // ���i�|���O���[�v���́i�|���j
            stockDetailWork.RateBLGroupCode = stockDetail.RateBLGroupCode;              // BL�O���[�v�R�[�h�i�|���j
            stockDetailWork.RateBLGroupName = stockDetail.RateBLGroupName;              // BL�O���[�v���́i�|���j
            stockDetailWork.StockCount = stockDetail.StockCount;                        // �d����
            stockDetailWork.OrderCnt = stockDetail.OrderCnt;                            // ��������
            stockDetailWork.OrderAdjustCnt = stockDetail.OrderAdjustCnt;                // ����������
            stockDetailWork.OrderRemainCnt = stockDetail.OrderRemainCnt;                // �����c��
            stockDetailWork.RemainCntUpdDate = stockDetail.RemainCntUpdDate;            // �c���X�V��
            stockDetailWork.StockPriceTaxExc = stockDetail.StockPriceTaxExc;            // �d�����z�i�Ŕ����j
            stockDetailWork.StockPriceTaxInc = stockDetail.StockPriceTaxInc;            // �d�����z�i�ō��݁j
            stockDetailWork.StockGoodsCd = stockDetail.StockGoodsCd;                    // �d�����i�敪
            stockDetailWork.StockPriceConsTax = stockDetail.StockPriceConsTax;          // �d�����z����Ŋz
            stockDetailWork.TaxationCode = stockDetail.TaxationCode;                    // �ېŋ敪
            stockDetailWork.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;          // �d���`�[���ה��l1
            stockDetailWork.SalesCustomerCode = stockDetail.SalesCustomerCode;          // �̔���R�[�h
            stockDetailWork.SalesCustomerSnm = stockDetail.SalesCustomerSnm;            // �̔��旪��
            stockDetailWork.SlipMemo1 = stockDetail.SlipMemo1;                          // �`�[�����P
            stockDetailWork.SlipMemo2 = stockDetail.SlipMemo2;                          // �`�[�����Q
            stockDetailWork.SlipMemo3 = stockDetail.SlipMemo3;                          // �`�[�����R
            stockDetailWork.InsideMemo1 = stockDetail.InsideMemo1;                      // �Г������P
            stockDetailWork.InsideMemo2 = stockDetail.InsideMemo2;                      // �Г������Q
            stockDetailWork.InsideMemo3 = stockDetail.InsideMemo3;                      // �Г������R
            stockDetailWork.SupplierCd = stockDetail.SupplierCd;                        // �d����R�[�h
            stockDetailWork.SupplierSnm = stockDetail.SupplierSnm;                      // �d���旪��
            stockDetailWork.AddresseeCode = stockDetail.AddresseeCode;                  // �[�i��R�[�h
            stockDetailWork.AddresseeName = stockDetail.AddresseeName;                  // �[�i�於��
            stockDetailWork.DirectSendingCd = stockDetail.DirectSendingCd;              // �����敪
            stockDetailWork.OrderNumber = stockDetail.OrderNumber;                      // �����ԍ�
            stockDetailWork.WayToOrder = stockDetail.WayToOrder;                        // �������@
            stockDetailWork.DeliGdsCmpltDueDate = stockDetail.DeliGdsCmpltDueDate;      // �[�i�����\���
            stockDetailWork.ExpectDeliveryDate = stockDetail.ExpectDeliveryDate;        // ��]�[��
            stockDetailWork.OrderDataCreateDiv = stockDetail.OrderDataCreateDiv;        // �����f�[�^�쐬�敪
            stockDetailWork.OrderDataCreateDate = stockDetail.OrderDataCreateDate;      // �����f�[�^�쐬��
            stockDetailWork.OrderFormIssuedDiv = stockDetail.OrderFormIssuedDiv;        // ���������s�ϋ敪


			#endregion

            stockDetailWork.DtlRelationGuid = stockDetail.DtlRelationGuid;				// ���׊֘A�t��GUID

            // �␳
            // �d���S���Җ���
            if (stockDetailWork.StockAgentName.Length > 16)
            {
                stockDetailWork.StockAgentName = stockDetailWork.StockAgentName.Substring(0, 16);
            }
            // �d�����͎Җ���
            if (stockDetailWork.StockInputName.Length > 16)
            {
                stockDetailWork.StockInputName = stockDetailWork.StockInputName.Substring(0, 16);
            }

			return stockDetailWork;
		}


		/// <summary>
		/// UIData��PramData�ڍ�����
		/// </summary>
		/// <param name="salesTemp">����f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		/// <returns>����f�[�^(�d�������v��)���[�N�I�u�W�F�N�g</returns>
		public static SalesTempWork ParamDataFromUIData( SalesTemp salesTemp )
		{
			SalesTempWork salesTempWork = new SalesTempWork();

			#region �����ڃZ�b�g

			salesTempWork.CreateDateTime = salesTemp.CreateDateTime;
			salesTempWork.UpdateDateTime = salesTemp.UpdateDateTime;
			salesTempWork.EnterpriseCode = salesTemp.EnterpriseCode;
			salesTempWork.FileHeaderGuid = salesTemp.FileHeaderGuid;
			salesTempWork.UpdEmployeeCode = salesTemp.UpdEmployeeCode;
			salesTempWork.UpdAssemblyId1 = salesTemp.UpdAssemblyId1;
			salesTempWork.UpdAssemblyId2 = salesTemp.UpdAssemblyId2;
			salesTempWork.LogicalDeleteCode = salesTemp.LogicalDeleteCode;
			salesTempWork.AcptAnOdrStatus = salesTemp.AcptAnOdrStatus;
			salesTempWork.SectionCode = salesTemp.SectionCode;
			salesTempWork.SubSectionCode = salesTemp.SubSectionCode;
			salesTempWork.MinSectionCode = salesTemp.MinSectionCode;
			salesTempWork.DebitNoteDiv = salesTemp.DebitNoteDiv;
			salesTempWork.DebitNLnkAcptAnOdr = salesTemp.DebitNLnkAcptAnOdr;
			salesTempWork.SalesSlipCd = salesTemp.SalesSlipCd;
			salesTempWork.AccRecDivCd = salesTemp.AccRecDivCd;
			salesTempWork.SalesInpSecCd = salesTemp.SalesInpSecCd;
			salesTempWork.DemandAddUpSecCd = salesTemp.DemandAddUpSecCd;
			salesTempWork.ResultsAddUpSecCd = salesTemp.ResultsAddUpSecCd;
			salesTempWork.UpdateSecCd = salesTemp.UpdateSecCd;
			salesTempWork.SearchSlipDate = salesTemp.SearchSlipDate;
			salesTempWork.ShipmentDay = salesTemp.ShipmentDay;
			salesTempWork.SalesDate = salesTemp.SalesDate;
			salesTempWork.AddUpADate = salesTemp.AddUpADate;
			salesTempWork.DelayPaymentDiv = salesTemp.DelayPaymentDiv;
			salesTempWork.ClaimCode = salesTemp.ClaimCode;
			salesTempWork.ClaimSnm = salesTemp.ClaimSnm;
			salesTempWork.CustomerCode = salesTemp.CustomerCode;
			salesTempWork.CustomerName = salesTemp.CustomerName;
			salesTempWork.CustomerName2 = salesTemp.CustomerName2;
			salesTempWork.CustomerSnm = salesTemp.CustomerSnm;
			salesTempWork.HonorificTitle = salesTemp.HonorificTitle;
			salesTempWork.OutputNameCode = salesTemp.OutputNameCode;
			salesTempWork.BusinessTypeCode = salesTemp.BusinessTypeCode;
			salesTempWork.BusinessTypeName = salesTemp.BusinessTypeName;
			salesTempWork.SalesAreaCode = salesTemp.SalesAreaCode;
			salesTempWork.SalesAreaName = salesTemp.SalesAreaName;
			salesTempWork.SalesInputCode = salesTemp.SalesInputCode;
			salesTempWork.SalesInputName = salesTemp.SalesInputName;
			salesTempWork.FrontEmployeeCd = salesTemp.FrontEmployeeCd;
			salesTempWork.FrontEmployeeNm = salesTemp.FrontEmployeeNm;
			salesTempWork.SalesEmployeeCd = salesTemp.SalesEmployeeCd;
			salesTempWork.SalesEmployeeNm = salesTemp.SalesEmployeeNm;
			salesTempWork.ConsTaxLayMethod = salesTemp.ConsTaxLayMethod;
			salesTempWork.ConsTaxRate = salesTemp.ConsTaxRate;
			salesTempWork.FractionProcCd = salesTemp.FractionProcCd;
			salesTempWork.AutoDepositCd = salesTemp.AutoDepositCd;
			salesTempWork.AutoDepoSlipNum = salesTemp.AutoDepoSlipNum;
			salesTempWork.SlipAddressDiv = salesTemp.SlipAddressDiv;
			salesTempWork.AddresseeCode = salesTemp.AddresseeCode;
			salesTempWork.AddresseeName = salesTemp.AddresseeName;
			salesTempWork.AddresseeName2 = salesTemp.AddresseeName2;
			salesTempWork.AddresseePostNo = salesTemp.AddresseePostNo;
			salesTempWork.AddresseeAddr1 = salesTemp.AddresseeAddr1;
			salesTempWork.AddresseeAddr2 = salesTemp.AddresseeAddr2;
			salesTempWork.AddresseeAddr3 = salesTemp.AddresseeAddr3;
			salesTempWork.AddresseeAddr4 = salesTemp.AddresseeAddr4;
			salesTempWork.AddresseeTelNo = salesTemp.AddresseeTelNo;
			salesTempWork.AddresseeFaxNo = salesTemp.AddresseeFaxNo;
			salesTempWork.PartySaleSlipNum = salesTemp.PartySaleSlipNum;
			salesTempWork.SlipNote = salesTemp.SlipNote;
			salesTempWork.SlipNote2 = salesTemp.SlipNote2;
			salesTempWork.RetGoodsReasonDiv = salesTemp.RetGoodsReasonDiv;
			salesTempWork.RetGoodsReason = salesTemp.RetGoodsReason;
			salesTempWork.DetailRowCount = salesTemp.DetailRowCount;
			salesTempWork.DeliveredGoodsDiv = salesTemp.DeliveredGoodsDiv;
			salesTempWork.DeliveredGoodsDivNm = salesTemp.DeliveredGoodsDivNm;
			salesTempWork.ReconcileFlag = salesTemp.ReconcileFlag;
			salesTempWork.SlipPrtSetPaperId = salesTemp.SlipPrtSetPaperId;
			salesTempWork.CompleteCd = salesTemp.CompleteCd;
			salesTempWork.ClaimType = salesTemp.ClaimType;
			salesTempWork.SalesPriceFracProcCd = salesTemp.SalesPriceFracProcCd;
			salesTempWork.ListPricePrintDiv = salesTemp.ListPricePrintDiv;
			salesTempWork.EraNameDispCd1 = salesTemp.EraNameDispCd1;
			salesTempWork.AcceptAnOrderNo = salesTemp.AcceptAnOrderNo;
			salesTempWork.CommonSeqNo = salesTemp.CommonSeqNo;
			salesTempWork.SalesSlipDtlNum = salesTemp.SalesSlipDtlNum;
			salesTempWork.AcptAnOdrStatusSrc = salesTemp.AcptAnOdrStatusSrc;
			salesTempWork.SalesSlipDtlNumSrc = salesTemp.SalesSlipDtlNumSrc;
			salesTempWork.SupplierFormalSync = salesTemp.SupplierFormalSync;
			salesTempWork.StockSlipDtlNumSync = salesTemp.StockSlipDtlNumSync;
			salesTempWork.SalesSlipCdDtl = salesTemp.SalesSlipCdDtl;
			salesTempWork.OrderNumber = salesTemp.OrderNumber;
			salesTempWork.StockMngExistCd = salesTemp.StockMngExistCd;
			salesTempWork.DeliGdsCmpltDueDate = salesTemp.DeliGdsCmpltDueDate;
			salesTempWork.GoodsKindCode = salesTemp.GoodsKindCode;
			salesTempWork.GoodsMakerCd = salesTemp.GoodsMakerCd;
			salesTempWork.MakerName = salesTemp.MakerName;
			salesTempWork.GoodsNo = salesTemp.GoodsNo;
			salesTempWork.GoodsName = salesTemp.GoodsName;
			salesTempWork.GoodsShortName = salesTemp.GoodsShortName;
			salesTempWork.GoodsSetDivCd = salesTemp.GoodsSetDivCd;
			salesTempWork.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;
			salesTempWork.LargeGoodsGanreName = salesTemp.LargeGoodsGanreName;
			salesTempWork.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;
			salesTempWork.MediumGoodsGanreName = salesTemp.MediumGoodsGanreName;
			salesTempWork.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;
			salesTempWork.DetailGoodsGanreName = salesTemp.DetailGoodsGanreName;
			salesTempWork.BLGoodsCode = salesTemp.BLGoodsCode;
			salesTempWork.BLGoodsFullName = salesTemp.BLGoodsFullName;
			salesTempWork.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;
			salesTempWork.EnterpriseGanreName = salesTemp.EnterpriseGanreName;
			salesTempWork.WarehouseCode = salesTemp.WarehouseCode;
			salesTempWork.WarehouseName = salesTemp.WarehouseName;
			salesTempWork.WarehouseShelfNo = salesTemp.WarehouseShelfNo;
			salesTempWork.SalesOrderDivCd = salesTemp.SalesOrderDivCd;
			salesTempWork.OpenPriceDiv = salesTemp.OpenPriceDiv;
			salesTempWork.UnitCode = salesTemp.UnitCode;
			salesTempWork.UnitName = salesTemp.UnitName;
			salesTempWork.GoodsRateRank = salesTemp.GoodsRateRank;
			salesTempWork.CustRateGrpCode = salesTemp.CustRateGrpCode;
			salesTempWork.SuppRateGrpCode = salesTemp.SuppRateGrpCode;
			salesTempWork.ListPriceRate = salesTemp.ListPriceRate;
			salesTempWork.RateSectPriceUnPrc = salesTemp.RateSectPriceUnPrc;
			salesTempWork.RateDivLPrice = salesTemp.RateDivLPrice;
			salesTempWork.UnPrcCalcCdLPrice = salesTemp.UnPrcCalcCdLPrice;
			salesTempWork.PriceCdLPrice = salesTemp.PriceCdLPrice;
			salesTempWork.StdUnPrcLPrice = salesTemp.StdUnPrcLPrice;
			salesTempWork.FracProcUnitLPrice = salesTemp.FracProcUnitLPrice;
			salesTempWork.FracProcLPrice = salesTemp.FracProcLPrice;
			salesTempWork.ListPriceTaxIncFl = salesTemp.ListPriceTaxIncFl;
			salesTempWork.ListPriceTaxExcFl = salesTemp.ListPriceTaxExcFl;
			salesTempWork.ListPriceChngCd = salesTemp.ListPriceChngCd;
			salesTempWork.SalesRate = salesTemp.SalesRate;
			salesTempWork.RateSectSalUnPrc = salesTemp.RateSectSalUnPrc;
			salesTempWork.RateDivSalUnPrc = salesTemp.RateDivSalUnPrc;
			salesTempWork.UnPrcCalcCdSalUnPrc = salesTemp.UnPrcCalcCdSalUnPrc;
			salesTempWork.PriceCdSalUnPrc = salesTemp.PriceCdSalUnPrc;
			salesTempWork.StdUnPrcSalUnPrc = salesTemp.StdUnPrcSalUnPrc;
			salesTempWork.FracProcUnitSalUnPrc = salesTemp.FracProcUnitSalUnPrc;
			salesTempWork.FracProcSalUnPrc = salesTemp.FracProcSalUnPrc;
			salesTempWork.SalesUnPrcTaxIncFl = salesTemp.SalesUnPrcTaxIncFl;
			salesTempWork.SalesUnPrcTaxExcFl = salesTemp.SalesUnPrcTaxExcFl;
			salesTempWork.SalesUnPrcChngCd = salesTemp.SalesUnPrcChngCd;
			salesTempWork.CostRate = salesTemp.CostRate;
			salesTempWork.RateSectCstUnPrc = salesTemp.RateSectCstUnPrc;
			salesTempWork.RateDivUnCst = salesTemp.RateDivUnCst;
			salesTempWork.UnPrcCalcCdUnCst = salesTemp.UnPrcCalcCdUnCst;
			salesTempWork.PriceCdUnCst = salesTemp.PriceCdUnCst;
			salesTempWork.StdUnPrcUnCst = salesTemp.StdUnPrcUnCst;
			salesTempWork.FracProcUnitUnCst = salesTemp.FracProcUnitUnCst;
			salesTempWork.FracProcUnCst = salesTemp.FracProcUnCst;
			salesTempWork.SalesUnitCost = salesTemp.SalesUnitCost;
			salesTempWork.SalesUnitCostChngDiv = salesTemp.SalesUnitCostChngDiv;
			salesTempWork.RateBLGoodsCode = salesTemp.RateBLGoodsCode;
			salesTempWork.RateBLGoodsName = salesTemp.RateBLGoodsName;
			salesTempWork.BargainCd = salesTemp.BargainCd;
			salesTempWork.BargainNm = salesTemp.BargainNm;
			salesTempWork.ShipmentCnt = salesTemp.ShipmentCnt;
			salesTempWork.SalesMoneyTaxInc = salesTemp.SalesMoneyTaxInc;
			salesTempWork.SalesMoneyTaxExc = salesTemp.SalesMoneyTaxExc;
			salesTempWork.Cost = salesTemp.Cost;
			salesTempWork.GrsProfitChkDiv = salesTemp.GrsProfitChkDiv;
			salesTempWork.SalesGoodsCd = salesTemp.SalesGoodsCd;
			salesTempWork.SalsePriceConsTax = salesTemp.SalsePriceConsTax;
			salesTempWork.TaxationDivCd = salesTemp.TaxationDivCd;
			salesTempWork.PartySlipNumDtl = salesTemp.PartySlipNumDtl;
			salesTempWork.DtlNote = salesTemp.DtlNote;
			salesTempWork.SupplierCd = salesTemp.SupplierCd;
			salesTempWork.SupplierSnm = salesTemp.SupplierSnm;
			salesTempWork.SlipMemo1 = salesTemp.SlipMemo1;
			salesTempWork.SlipMemo2 = salesTemp.SlipMemo2;
			salesTempWork.SlipMemo3 = salesTemp.SlipMemo3;
			salesTempWork.SlipMemo4 = salesTemp.SlipMemo4;
			salesTempWork.SlipMemo5 = salesTemp.SlipMemo5;
			salesTempWork.SlipMemo6 = salesTemp.SlipMemo6;
			salesTempWork.InsideMemo1 = salesTemp.InsideMemo1;
			salesTempWork.InsideMemo2 = salesTemp.InsideMemo2;
			salesTempWork.InsideMemo3 = salesTemp.InsideMemo3;
			salesTempWork.InsideMemo4 = salesTemp.InsideMemo4;
			salesTempWork.InsideMemo5 = salesTemp.InsideMemo5;
			salesTempWork.InsideMemo6 = salesTemp.InsideMemo6;
			salesTempWork.BfListPrice = salesTemp.BfListPrice;
			salesTempWork.BfSalesUnitPrice = salesTemp.BfSalesUnitPrice;
			salesTempWork.BfUnitCost = salesTemp.BfUnitCost;
			salesTempWork.PrtGoodsNo = salesTemp.PrtGoodsNo;
			salesTempWork.PrtGoodsName = salesTemp.PrtGoodsName;
			salesTempWork.PrtGoodsMakerCd = salesTemp.PrtGoodsMakerCd;
			salesTempWork.PrtGoodsMakerNm = salesTemp.PrtGoodsMakerNm;
			//salesTempWork.SupplierSlipCd = salesTempRow.SupplierSlipCd;
			//salesTempWork.TotalAmountDispWayCd = salesTempRow.TotalAmountDispWayCd;
			//salesTempWork.TtlAmntDispRateApy = salesTempRow.TtlAmntDispRateApy;
			//salesTempWork.ConfirmedDiv = salesTempRow.ConfirmedDiv;
			//salesTempWork.NTimeCalcStDate = salesTempRow.NTimeCalcStDate;
			//salesTempWork.TotalDay = salesTempRow.TotalDay;
			salesTempWork.DtlRelationGuid = salesTemp.DtlRelationGuid;

			#endregion

			return salesTempWork;
		}

		/// <summary>
		/// ���ڃR�s�[����
		/// </summary>
		/// <param name="source">�R�s�[���d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="target">�R�s�[��d���f�[�^�I�u�W�F�N�g</param>
		public static void CopyItem( StockSlip source, ref StockSlip target )
		{
			#region �����ڃZ�b�g

			//target.CreateDateTime = source.CreateDateTime;				// �쐬����
			//target.UpdateDateTime = source.UpdateDateTime;				// �X�V����
			//target.EnterpriseCode = source.EnterpriseCode;				// ��ƃR�[�h
			//target.FileHeaderGuid = source.FileHeaderGuid;				// GUID
			//target.UpdEmployeeCode = source.UpdEmployeeCode;			// �X�V�]�ƈ��R�[�h
			//target.UpdAssemblyId1 = source.UpdAssemblyId1;				// �X�V�A�Z���u��ID1
			//target.UpdAssemblyId2 = source.UpdAssemblyId2;				// �X�V�A�Z���u��ID2
			//target.LogicalDeleteCode = source.LogicalDeleteCode;		// �_���폜�敪
			target.SupplierFormal = source.SupplierFormal;				// �d���`��
			target.SupplierSlipNo = source.SupplierSlipNo;				// �d���`�[�ԍ�
			target.SectionCode = source.SectionCode;					// ���_�R�[�h
			target.SubSectionCode = source.SubSectionCode;				// ����R�[�h
			target.DebitNoteDiv = source.DebitNoteDiv;					// �ԓ`�敪
			target.DebitNLnkSuppSlipNo = source.DebitNLnkSuppSlipNo;	// �ԍ��A���d���`�[�ԍ�
			target.SupplierSlipCd = source.SupplierSlipCd;				// �d���`�[�敪
			target.StockGoodsCd = source.StockGoodsCd;					// �d�����i�敪
			target.AccPayDivCd = source.AccPayDivCd;					// ���|�敪
			target.StockSectionCd = source.StockSectionCd;				// �d�����_�R�[�h
			target.StockAddUpSectionCd = source.StockAddUpSectionCd;	// �d���v�㋒�_�R�[�h
			target.StockSlipUpdateCd = source.StockSlipUpdateCd;		// �d���`�[�X�V�敪
			target.InputDay = source.InputDay;							// ���͓�
			target.ArrivalGoodsDay = source.ArrivalGoodsDay;			// ���ד�
			target.StockDate = source.StockDate;						// �d����
			target.StockAddUpADate = source.StockAddUpADate;			// �d���v����t
			target.DelayPaymentDiv = source.DelayPaymentDiv;			// �����敪
			target.PayeeCode = source.PayeeCode;						// �x����R�[�h
			target.PayeeSnm = source.PayeeSnm;							// �x���旪��
			target.SupplierCd = source.SupplierCd;						// �d����R�[�h
			target.SupplierNm1 = source.SupplierNm1;					// �d���於1
			target.SupplierNm2 = source.SupplierNm2;					// �d���於2
			target.SupplierSnm = source.SupplierSnm;					// �d���旪��
			target.BusinessTypeCode = source.BusinessTypeCode;			// �Ǝ�R�[�h
			target.BusinessTypeName = source.BusinessTypeName;			// �Ǝ햼��
			target.SalesAreaCode = source.SalesAreaCode;				// �̔��G���A�R�[�h
			target.SalesAreaName = source.SalesAreaName;				// �̔��G���A����
			target.StockInputCode = source.StockInputCode;				// �d�����͎҃R�[�h
			target.StockInputName = source.StockInputName;				// �d�����͎Җ���
			target.StockAgentCode = source.StockAgentCode;				// �d���S���҃R�[�h
			target.StockAgentName = source.StockAgentName;				// �d���S���Җ���
			target.SuppTtlAmntDspWayCd = source.SuppTtlAmntDspWayCd;	// �d���摍�z�\�����@�敪
			target.TtlAmntDispRateApy = source.TtlAmntDispRateApy;		// ���z�\���|���K�p�敪
			target.StockTotalPrice = source.StockTotalPrice;			// �d�����z���v
			target.StockSubttlPrice = source.StockSubttlPrice;			// �d�����z���v
			target.StockTtlPricTaxInc = source.StockTtlPricTaxInc;		// �d�����z�v�i�ō��݁j
			target.StockTtlPricTaxExc = source.StockTtlPricTaxExc;		// �d�����z�v�i�Ŕ����j
			target.StockNetPrice = source.StockNetPrice;				// �d���������z
			target.StockPriceConsTax = source.StockPriceConsTax;		// �d�����z����Ŋz
			target.TtlItdedStcOutTax = source.TtlItdedStcOutTax;		// �d���O�őΏۊz���v
			target.TtlItdedStcInTax = source.TtlItdedStcInTax;			// �d�����őΏۊz���v
			target.TtlItdedStcTaxFree = source.TtlItdedStcTaxFree;		// �d����ېőΏۊz���v
			target.StockOutTax = source.StockOutTax;					// �d�����z����Ŋz�i�O�Łj
			target.StckPrcConsTaxInclu = source.StckPrcConsTaxInclu;	// �d�����z����Ŋz�i���Łj
			target.StckDisTtlTaxExc = source.StckDisTtlTaxExc;			// �d���l�����z�v�i�Ŕ����j
			target.ItdedStockDisOutTax = source.ItdedStockDisOutTax;	// �d���l���O�őΏۊz���v
			target.ItdedStockDisInTax = source.ItdedStockDisInTax;		// �d���l�����őΏۊz���v
			target.ItdedStockDisTaxFre = source.ItdedStockDisTaxFre;	// �d���l����ېőΏۊz���v
			target.StockDisOutTax = source.StockDisOutTax;				// �d���l������Ŋz�i�O�Łj
			target.StckDisTtlTaxInclu = source.StckDisTtlTaxInclu;		// �d���l������Ŋz�i���Łj
			target.TaxAdjust = source.TaxAdjust;						// ����Œ����z
			target.BalanceAdjust = source.BalanceAdjust;				// �c�������z
			target.SuppCTaxLayCd = source.SuppCTaxLayCd;				// �d�������œ]�ŕ����R�[�h
			target.SupplierConsTaxRate = source.SupplierConsTaxRate;	// �d�������Őŗ�
			target.AccPayConsTax = source.AccPayConsTax;				// ���|�����
			target.StockFractionProcCd = source.StockFractionProcCd;	// �d���[�������敪
			target.AutoPayment = source.AutoPayment;					// �����x���敪
			target.AutoPaySlipNum = source.AutoPaySlipNum;				// �����x���`�[�ԍ�
			target.RetGoodsReasonDiv = source.RetGoodsReasonDiv;		// �ԕi���R�R�[�h
			target.RetGoodsReason = source.RetGoodsReason;				// �ԕi���R
			target.PartySaleSlipNum = source.PartySaleSlipNum;			// �����`�[�ԍ�
			target.SupplierSlipNote1 = source.SupplierSlipNote1;		// �d���`�[���l1
			target.SupplierSlipNote2 = source.SupplierSlipNote2;		// �d���`�[���l2
			target.DetailRowCount = source.DetailRowCount;				// ���׍s��
			target.EdiSendDate = source.EdiSendDate;					// �d�c�h���M��
			target.EdiTakeInDate = source.EdiTakeInDate;				// �d�c�h�捞��
			target.UoeRemark1 = source.UoeRemark1;						// �t�n�d���}�[�N�P
			target.UoeRemark2 = source.UoeRemark2;						// �t�n�d���}�[�N�Q
			target.SlipPrintDivCd = source.SlipPrintDivCd;				// �`�[���s�敪
			target.SlipPrintFinishCd = source.SlipPrintFinishCd;		// �`�[���s�ϋ敪
			target.StockSlipPrintDate = source.StockSlipPrintDate;		// �d���`�[���s��
			target.SlipPrtSetPaperId = source.SlipPrtSetPaperId;		// �`�[����ݒ�p���[ID
			target.SlipAddressDiv = source.SlipAddressDiv;				// �`�[�Z���敪
			target.AddresseeCode = source.AddresseeCode;				// �[�i��R�[�h
			target.AddresseeName = source.AddresseeName;				// �[�i�於��
			target.AddresseeName2 = source.AddresseeName2;				// �[�i�於��2
			target.AddresseePostNo = source.AddresseePostNo;			// �[�i��X�֔ԍ�
			target.AddresseeAddr1 = source.AddresseeAddr1;				// �[�i��Z��1(�s���{���s��S�E�����E��)
			target.AddresseeAddr3 = source.AddresseeAddr3;				// �[�i��Z��3(�Ԓn)
			target.AddresseeAddr4 = source.AddresseeAddr4;				// �[�i��Z��4(�A�p�[�g����)
			target.AddresseeTelNo = source.AddresseeTelNo;				// �[�i��d�b�ԍ�
			target.AddresseeFaxNo = source.AddresseeFaxNo;				// �[�i��FAX�ԍ�
			target.DirectSendingCd = source.DirectSendingCd;			// �����敪
			target.SupplierSlipDisplay = source.SupplierSlipDisplay;	// �d���`�[�敪(��ʕ\���p)
			target.SuppRateGrpCode = source.SuppRateGrpCode;			// �d����|���O���[�v�R�[�h
			target.WarehouseCode = source.WarehouseCode;				// �q�ɃR�[�h
			target.WarehouseName = source.WarehouseName;				// �q�ɖ���
			target.InputMode = source.InputMode;						// ���̓��[�h
			target.PayeeName = source.PayeeName;						// �x���於��
			target.PayeeName2 = source.PayeeName2;						// �x���於��2
			target.NTimeCalcStDate = source.NTimeCalcStDate;			// ���񊨒�J�n��
			target.PaymentTotalDay = source.PaymentTotalDay;			// �x������

			#endregion
		}

		/// <summary>
		/// ���ڃR�s�[����
		/// </summary>
		/// <param name="source">�R�s�[���d���f�[�^�I�u�W�F�N�g</param>
		/// <param name="target">�R�s�[��d���f�[�^�I�u�W�F�N�g</param>
		public static void CopyItem( StockDetail source, ref StockDetail target )
		{
			#region �����ڃZ�b�g

            target.CreateDateTime = source.CreateDateTime;                  // �쐬����
            target.UpdateDateTime = source.UpdateDateTime;                  // �X�V����
            target.EnterpriseCode = source.EnterpriseCode;                  // ��ƃR�[�h
            target.FileHeaderGuid = source.FileHeaderGuid;                  // GUID
            target.UpdEmployeeCode = source.UpdEmployeeCode;                // �X�V�]�ƈ��R�[�h
            target.UpdAssemblyId1 = source.UpdAssemblyId1;                  // �X�V�A�Z���u��ID1
            target.UpdAssemblyId2 = source.UpdAssemblyId2;                  // �X�V�A�Z���u��ID2
            target.LogicalDeleteCode = source.LogicalDeleteCode;            // �_���폜�敪
            target.AcceptAnOrderNo = source.AcceptAnOrderNo;                // �󒍔ԍ�
            target.SupplierFormal = source.SupplierFormal;                  // �d���`��
            target.SupplierSlipNo = source.SupplierSlipNo;                  // �d���`�[�ԍ�
            target.StockRowNo = source.StockRowNo;                          // �d���s�ԍ�
            target.SectionCode = source.SectionCode;                        // ���_�R�[�h
            target.SubSectionCode = source.SubSectionCode;                  // ����R�[�h
            target.CommonSeqNo = source.CommonSeqNo;                        // ���ʒʔ�
            target.StockSlipDtlNum = source.StockSlipDtlNum;                // �d�����גʔ�
            target.SupplierFormalSrc = source.SupplierFormalSrc;            // �d���`���i���j
            target.StockSlipDtlNumSrc = source.StockSlipDtlNumSrc;          // �d�����גʔԁi���j
            target.AcptAnOdrStatusSync = source.AcptAnOdrStatusSync;        // �󒍃X�e�[�^�X�i�����j
            target.SalesSlipDtlNumSync = source.SalesSlipDtlNumSync;        // ���㖾�גʔԁi�����j
            target.StockSlipCdDtl = source.StockSlipCdDtl;                  // �d���`�[�敪�i���ׁj
            target.StockInputCode = source.StockInputCode;                  // �d�����͎҃R�[�h
            target.StockInputName = source.StockInputName;                  // �d�����͎Җ���
            target.StockAgentCode = source.StockAgentCode;                  // �d���S���҃R�[�h
            target.StockAgentName = source.StockAgentName;                  // �d���S���Җ���
            target.GoodsKindCode = source.GoodsKindCode;                    // ���i����
            target.GoodsMakerCd = source.GoodsMakerCd;                      // ���i���[�J�[�R�[�h
            target.MakerName = source.MakerName;                            // ���[�J�[����
            target.MakerKanaName = source.MakerKanaName;                    // ���[�J�[�J�i����
            target.CmpltMakerKanaName = source.CmpltMakerKanaName;          // ���[�J�[�J�i���́i�ꎮ�j
            target.GoodsNo = source.GoodsNo;                                // ���i�ԍ�
            target.GoodsName = source.GoodsName;                            // ���i����
            target.GoodsNameKana = source.GoodsNameKana;                    // ���i���̃J�i
            target.GoodsLGroup = source.GoodsLGroup;                        // ���i�啪�ރR�[�h
            target.GoodsLGroupName = source.GoodsLGroupName;                // ���i�啪�ޖ���
            target.GoodsMGroup = source.GoodsMGroup;                        // ���i�����ރR�[�h
            target.GoodsMGroupName = source.GoodsMGroupName;                // ���i�����ޖ���
            target.BLGroupCode = source.BLGroupCode;                        // BL�O���[�v�R�[�h
            target.BLGroupName = source.BLGroupName;                        // BL�O���[�v�R�[�h����
            target.BLGoodsCode = source.BLGoodsCode;                        // BL���i�R�[�h
            target.BLGoodsFullName = source.BLGoodsFullName;                // BL���i�R�[�h���́i�S�p�j
            target.EnterpriseGanreCode = source.EnterpriseGanreCode;        // ���Е��ރR�[�h
            target.EnterpriseGanreName = source.EnterpriseGanreName;        // ���Е��ޖ���
            target.WarehouseCode = source.WarehouseCode;                    // �q�ɃR�[�h
            target.WarehouseName = source.WarehouseName;                    // �q�ɖ���
            target.WarehouseShelfNo = source.WarehouseShelfNo;              // �q�ɒI��
            target.StockOrderDivCd = source.StockOrderDivCd;                // �d���݌Ɏ�񂹋敪
            target.OpenPriceDiv = source.OpenPriceDiv;                      // �I�[�v�����i�敪
            target.GoodsRateRank = source.GoodsRateRank;                    // ���i�|�������N
            target.CustRateGrpCode = source.CustRateGrpCode;                // ���Ӑ�|���O���[�v�R�[�h
            target.SuppRateGrpCode = source.SuppRateGrpCode;                // �d����|���O���[�v�R�[�h
            target.ListPriceTaxExcFl = source.ListPriceTaxExcFl;            // �艿�i�Ŕ��C�����j
            target.ListPriceTaxIncFl = source.ListPriceTaxIncFl;            // �艿�i�ō��C�����j
            target.StockRate = source.StockRate;                            // �d����
            target.RateSectStckUnPrc = source.RateSectStckUnPrc;            // �|���ݒ苒�_�i�d���P���j
            target.RateDivStckUnPrc = source.RateDivStckUnPrc;              // �|���ݒ�敪�i�d���P���j
            target.UnPrcCalcCdStckUnPrc = source.UnPrcCalcCdStckUnPrc;      // �P���Z�o�敪�i�d���P���j
            target.PriceCdStckUnPrc = source.PriceCdStckUnPrc;              // ���i�敪�i�d���P���j
            target.StdUnPrcStckUnPrc = source.StdUnPrcStckUnPrc;            // ��P���i�d���P���j
            target.FracProcUnitStcUnPrc = source.FracProcUnitStcUnPrc;      // �[�������P�ʁi�d���P���j
            target.FracProcStckUnPrc = source.FracProcStckUnPrc;            // �[�������i�d���P���j
            target.StockUnitPriceFl = source.StockUnitPriceFl;              // �d���P���i�Ŕ��C�����j
            target.StockUnitTaxPriceFl = source.StockUnitTaxPriceFl;        // �d���P���i�ō��C�����j
            target.StockUnitChngDiv = source.StockUnitChngDiv;              // �d���P���ύX�敪
            target.BfStockUnitPriceFl = source.BfStockUnitPriceFl;          // �ύX�O�d���P���i�����j
            target.BfListPrice = source.BfListPrice;                        // �ύX�O�艿
            target.RateBLGoodsCode = source.RateBLGoodsCode;                // BL���i�R�[�h�i�|���j
            target.RateBLGoodsName = source.RateBLGoodsName;                // BL���i�R�[�h���́i�|���j
            target.RateGoodsRateGrpCd = source.RateGoodsRateGrpCd;          // ���i�|���O���[�v�R�[�h�i�|���j
            target.RateGoodsRateGrpNm = source.RateGoodsRateGrpNm;          // ���i�|���O���[�v���́i�|���j
            target.RateBLGroupCode = source.RateBLGroupCode;                // BL�O���[�v�R�[�h�i�|���j
            target.RateBLGroupName = source.RateBLGroupName;                // BL�O���[�v���́i�|���j
            target.StockCount = source.StockCount;                          // �d����
            target.OrderCnt = source.OrderCnt;                              // ��������
            target.OrderAdjustCnt = source.OrderAdjustCnt;                  // ����������
            target.OrderRemainCnt = source.OrderRemainCnt;                  // �����c��
            target.RemainCntUpdDate = source.RemainCntUpdDate;              // �c���X�V��
            target.StockPriceTaxExc = source.StockPriceTaxExc;              // �d�����z�i�Ŕ����j
            target.StockPriceTaxInc = source.StockPriceTaxInc;              // �d�����z�i�ō��݁j
            target.StockGoodsCd = source.StockGoodsCd;                      // �d�����i�敪
            target.StockPriceConsTax = source.StockPriceConsTax;            // �d�����z����Ŋz
            target.TaxationCode = source.TaxationCode;                      // �ېŋ敪
            target.StockDtiSlipNote1 = source.StockDtiSlipNote1;            // �d���`�[���ה��l1
            target.SalesCustomerCode = source.SalesCustomerCode;            // �̔���R�[�h
            target.SalesCustomerSnm = source.SalesCustomerSnm;              // �̔��旪��
            target.SlipMemo1 = source.SlipMemo1;                            // �`�[�����P
            target.SlipMemo2 = source.SlipMemo2;                            // �`�[�����Q
            target.SlipMemo3 = source.SlipMemo3;                            // �`�[�����R
            target.InsideMemo1 = source.InsideMemo1;                        // �Г������P
            target.InsideMemo2 = source.InsideMemo2;                        // �Г������Q
            target.InsideMemo3 = source.InsideMemo3;                        // �Г������R
            target.SupplierCd = source.SupplierCd;                          // �d����R�[�h
            target.SupplierSnm = source.SupplierSnm;                        // �d���旪��
            target.AddresseeCode = source.AddresseeCode;                    // �[�i��R�[�h
            target.AddresseeName = source.AddresseeName;                    // �[�i�於��
            target.DirectSendingCd = source.DirectSendingCd;                // �����敪
            target.OrderNumber = source.OrderNumber;                        // �����ԍ�
            target.WayToOrder = source.WayToOrder;                          // �������@
            target.DeliGdsCmpltDueDate = source.DeliGdsCmpltDueDate;        // �[�i�����\���
            target.ExpectDeliveryDate = source.ExpectDeliveryDate;          // ��]�[��
            target.OrderDataCreateDiv = source.OrderDataCreateDiv;          // �����f�[�^�쐬�敪
            target.OrderDataCreateDate = source.OrderDataCreateDate;        // �����f�[�^�쐬��
            target.OrderFormIssuedDiv = source.OrderFormIssuedDiv;          // ���������s�ϋ敪
            target.DtlRelationGuid = source.DtlRelationGuid;                // ���׊֘A�t��GUID
            target.GoodsOfferDate = source.GoodsOfferDate;                  // ���i�񋟓��t
            target.PriceStartDate = source.PriceStartDate;                  // ���i�J�n���t
            target.PriceOfferDate = source.PriceOfferDate;                  // ���i�񋟓��t

			#endregion
		}

		/// <summary>
		/// ���ڃR�s�[����
		/// </summary>
		/// <param name="source">�R�s�[������f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		/// <param name="target">�R�s�[�攄��f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		public static void CopyItem( SalesTemp source, ref SalesTemp target )
		{
			#region �����ڃR�s�[

			//target.CreateDateTime = source.CreateDateTime;
			//target.UpdateDateTime = source.UpdateDateTime;
			//target.EnterpriseCode = source.EnterpriseCode;
			//target.FileHeaderGuid = source.FileHeaderGuid;
			//target.UpdEmployeeCode = source.UpdEmployeeCode;
			//target.UpdAssemblyId1 = source.UpdAssemblyId1;
			//target.UpdAssemblyId2 = source.UpdAssemblyId2;
			//target.LogicalDeleteCode = source.LogicalDeleteCode;
			target.AcptAnOdrStatus = source.AcptAnOdrStatus;
			target.SectionCode = source.SectionCode;
			target.SubSectionCode = source.SubSectionCode;
			target.MinSectionCode = source.MinSectionCode;
			target.DebitNoteDiv = source.DebitNoteDiv;
			target.DebitNLnkAcptAnOdr = source.DebitNLnkAcptAnOdr;
			target.SalesSlipCd = source.SalesSlipCd;
			target.AccRecDivCd = source.AccRecDivCd;
			target.SalesInpSecCd = source.SalesInpSecCd;
			target.DemandAddUpSecCd = source.DemandAddUpSecCd;
			target.ResultsAddUpSecCd = source.ResultsAddUpSecCd;
			target.UpdateSecCd = source.UpdateSecCd;
			target.SearchSlipDate = source.SearchSlipDate;
			target.ShipmentDay = source.ShipmentDay;
			target.SalesDate = source.SalesDate;
			target.AddUpADate = source.AddUpADate;
			target.DelayPaymentDiv = source.DelayPaymentDiv;
			target.ClaimCode = source.ClaimCode;
			target.ClaimSnm = source.ClaimSnm;
			target.CustomerCode = source.CustomerCode;
			target.CustomerName = source.CustomerName;
			target.CustomerName2 = source.CustomerName2;
			target.CustomerSnm = source.CustomerSnm;
			target.HonorificTitle = source.HonorificTitle;
			target.OutputNameCode = source.OutputNameCode;
			target.BusinessTypeCode = source.BusinessTypeCode;
			target.BusinessTypeName = source.BusinessTypeName;
			target.SalesAreaCode = source.SalesAreaCode;
			target.SalesAreaName = source.SalesAreaName;
			target.SalesInputCode = source.SalesInputCode;
			target.SalesInputName = source.SalesInputName;
			target.FrontEmployeeCd = source.FrontEmployeeCd;
			target.FrontEmployeeNm = source.FrontEmployeeNm;
			target.SalesEmployeeCd = source.SalesEmployeeCd;
			target.SalesEmployeeNm = source.SalesEmployeeNm;
			target.ConsTaxLayMethod = source.ConsTaxLayMethod;
			target.ConsTaxRate = source.ConsTaxRate;
			target.FractionProcCd = source.FractionProcCd;
			target.AutoDepositCd = source.AutoDepositCd;
			target.AutoDepoSlipNum = source.AutoDepoSlipNum;
			target.SlipAddressDiv = source.SlipAddressDiv;
			target.AddresseeCode = source.AddresseeCode;
			target.AddresseeName = source.AddresseeName;
			target.AddresseeName2 = source.AddresseeName2;
			target.AddresseePostNo = source.AddresseePostNo;
			target.AddresseeAddr1 = source.AddresseeAddr1;
			target.AddresseeAddr2 = source.AddresseeAddr2;
			target.AddresseeAddr3 = source.AddresseeAddr3;
			target.AddresseeAddr4 = source.AddresseeAddr4;
			target.AddresseeTelNo = source.AddresseeTelNo;
			target.AddresseeFaxNo = source.AddresseeFaxNo;
			target.PartySaleSlipNum = source.PartySaleSlipNum;
			target.SlipNote = source.SlipNote;
			target.SlipNote2 = source.SlipNote2;
			target.RetGoodsReasonDiv = source.RetGoodsReasonDiv;
			target.RetGoodsReason = source.RetGoodsReason;
			target.DetailRowCount = source.DetailRowCount;
			target.DeliveredGoodsDiv = source.DeliveredGoodsDiv;
			target.DeliveredGoodsDivNm = source.DeliveredGoodsDivNm;
			target.ReconcileFlag = source.ReconcileFlag;
			target.SlipPrtSetPaperId = source.SlipPrtSetPaperId;
			target.CompleteCd = source.CompleteCd;
			target.ClaimType = source.ClaimType;
			target.SalesPriceFracProcCd = source.SalesPriceFracProcCd;
			target.ListPricePrintDiv = source.ListPricePrintDiv;
			target.EraNameDispCd1 = source.EraNameDispCd1;
			target.AcceptAnOrderNo = source.AcceptAnOrderNo;
			target.CommonSeqNo = source.CommonSeqNo;
			target.SalesSlipDtlNum = source.SalesSlipDtlNum;
			target.AcptAnOdrStatusSrc = source.AcptAnOdrStatusSrc;
			target.SalesSlipDtlNumSrc = source.SalesSlipDtlNumSrc;
			target.SupplierFormalSync = source.SupplierFormalSync;
			target.StockSlipDtlNumSync = source.StockSlipDtlNumSync;
			target.SalesSlipCdDtl = source.SalesSlipCdDtl;
			target.OrderNumber = source.OrderNumber;
			target.StockMngExistCd = source.StockMngExistCd;
			target.DeliGdsCmpltDueDate = source.DeliGdsCmpltDueDate;
			target.GoodsKindCode = source.GoodsKindCode;
			target.GoodsMakerCd = source.GoodsMakerCd;
			target.MakerName = source.MakerName;
			target.GoodsNo = source.GoodsNo;
			target.GoodsName = source.GoodsName;
			target.GoodsShortName = source.GoodsShortName;
			target.GoodsSetDivCd = source.GoodsSetDivCd;
			target.LargeGoodsGanreCode = source.LargeGoodsGanreCode;
			target.LargeGoodsGanreName = source.LargeGoodsGanreName;
			target.MediumGoodsGanreCode = source.MediumGoodsGanreCode;
			target.MediumGoodsGanreName = source.MediumGoodsGanreName;
			target.DetailGoodsGanreCode = source.DetailGoodsGanreCode;
			target.DetailGoodsGanreName = source.DetailGoodsGanreName;
			target.BLGoodsCode = source.BLGoodsCode;
			target.BLGoodsFullName = source.BLGoodsFullName;
			target.EnterpriseGanreCode = source.EnterpriseGanreCode;
			target.EnterpriseGanreName = source.EnterpriseGanreName;
			target.WarehouseCode = source.WarehouseCode;
			target.WarehouseName = source.WarehouseName;
			target.WarehouseShelfNo = source.WarehouseShelfNo;
			target.SalesOrderDivCd = source.SalesOrderDivCd;
			target.OpenPriceDiv = source.OpenPriceDiv;
			target.UnitCode = source.UnitCode;
			target.UnitName = source.UnitName;
			target.GoodsRateRank = source.GoodsRateRank;
			target.CustRateGrpCode = source.CustRateGrpCode;
			target.SuppRateGrpCode = source.SuppRateGrpCode;
			target.ListPriceRate = source.ListPriceRate;
			target.RateSectPriceUnPrc = source.RateSectPriceUnPrc;
			target.RateDivLPrice = source.RateDivLPrice;
			target.UnPrcCalcCdLPrice = source.UnPrcCalcCdLPrice;
			target.PriceCdLPrice = source.PriceCdLPrice;
			target.StdUnPrcLPrice = source.StdUnPrcLPrice;
			target.FracProcUnitLPrice = source.FracProcUnitLPrice;
			target.FracProcLPrice = source.FracProcLPrice;
			target.ListPriceTaxIncFl = source.ListPriceTaxIncFl;
			target.ListPriceTaxExcFl = source.ListPriceTaxExcFl;
			target.ListPriceChngCd = source.ListPriceChngCd;
			target.SalesRate = source.SalesRate;
			target.RateSectSalUnPrc = source.RateSectSalUnPrc;
			target.RateDivSalUnPrc = source.RateDivSalUnPrc;
			target.UnPrcCalcCdSalUnPrc = source.UnPrcCalcCdSalUnPrc;
			target.PriceCdSalUnPrc = source.PriceCdSalUnPrc;
			target.StdUnPrcSalUnPrc = source.StdUnPrcSalUnPrc;
			target.FracProcUnitSalUnPrc = source.FracProcUnitSalUnPrc;
			target.FracProcSalUnPrc = source.FracProcSalUnPrc;
			target.SalesUnPrcTaxIncFl = source.SalesUnPrcTaxIncFl;
			target.SalesUnPrcTaxExcFl = source.SalesUnPrcTaxExcFl;
			target.SalesUnPrcChngCd = source.SalesUnPrcChngCd;
			target.CostRate = source.CostRate;
			target.RateSectCstUnPrc = source.RateSectCstUnPrc;
			target.RateDivUnCst = source.RateDivUnCst;
			target.UnPrcCalcCdUnCst = source.UnPrcCalcCdUnCst;
			target.PriceCdUnCst = source.PriceCdUnCst;
			target.StdUnPrcUnCst = source.StdUnPrcUnCst;
			target.FracProcUnitUnCst = source.FracProcUnitUnCst;
			target.FracProcUnCst = source.FracProcUnCst;
			target.SalesUnitCost = source.SalesUnitCost;
			target.SalesUnitCostChngDiv = source.SalesUnitCostChngDiv;
			target.RateBLGoodsCode = source.RateBLGoodsCode;
			target.RateBLGoodsName = source.RateBLGoodsName;
			target.BargainCd = source.BargainCd;
			target.BargainNm = source.BargainNm;
			target.ShipmentCnt = source.ShipmentCnt;
			target.SalesMoneyTaxInc = source.SalesMoneyTaxInc;
			target.SalesMoneyTaxExc = source.SalesMoneyTaxExc;
			target.Cost = source.Cost;
			target.GrsProfitChkDiv = source.GrsProfitChkDiv;
			target.SalesGoodsCd = source.SalesGoodsCd;
			target.SalsePriceConsTax = source.SalsePriceConsTax;
			target.TaxationDivCd = source.TaxationDivCd;
			target.PartySlipNumDtl = source.PartySlipNumDtl;
			target.DtlNote = source.DtlNote;
			target.SupplierCd = source.SupplierCd;
			target.SupplierSnm = source.SupplierSnm;
			target.SlipMemo1 = source.SlipMemo1;
			target.SlipMemo2 = source.SlipMemo2;
			target.SlipMemo3 = source.SlipMemo3;
			target.SlipMemo4 = source.SlipMemo4;
			target.SlipMemo5 = source.SlipMemo5;
			target.SlipMemo6 = source.SlipMemo6;
			target.InsideMemo1 = source.InsideMemo1;
			target.InsideMemo2 = source.InsideMemo2;
			target.InsideMemo3 = source.InsideMemo3;
			target.InsideMemo4 = source.InsideMemo4;
			target.InsideMemo5 = source.InsideMemo5;
			target.InsideMemo6 = source.InsideMemo6;
			target.BfListPrice = source.BfListPrice;
			target.BfSalesUnitPrice = source.BfSalesUnitPrice;
			target.BfUnitCost = source.BfUnitCost;
			target.PrtGoodsNo = source.PrtGoodsNo;
			target.PrtGoodsName = source.PrtGoodsName;
			target.PrtGoodsMakerCd = source.PrtGoodsMakerCd;
			target.PrtGoodsMakerNm = source.PrtGoodsMakerNm;
			target.SupplierSlipCd = source.SupplierSlipCd;
			target.TotalAmountDispWayCd = source.TotalAmountDispWayCd;
			target.TtlAmntDispRateApy = source.TtlAmntDispRateApy;
			//target.ConfirmedDiv = source.ConfirmedDiv;
			target.NTimeCalcStDate = source.NTimeCalcStDate;
			target.TotalDay = source.TotalDay;
			//target.DtlRelationGuid = source.DtlRelationGuid;

			#endregion
		}
	}

    /// <summary>
    /// �d���֘A��CustomSerializeArrayList�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : IOWrite���d�����[�h�Ŏg�p�����ꍇ��CustomSerializeArrayList�̕����������s���܂��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.09.25</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.09.25�@���X�� ��  �V�K�쐬</br>
    /// </remarks>
    public class DivisionStockSlipCustomSerializeArrayList
    {
        #region ��Public Static Methods

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�������ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWork">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="paymentDataWork">�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesTempWorkArray">����f�[�^(�d�������v��)���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForWritingResult( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWork, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out SalesTempWork[] salesTempWorkArray )
        {
            DivisionCustomSerializeArrayListForAfterWritingResultProc(paraList, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWork, out paymentDataWork, out stockWorkArray, out salesTempWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�ǂݍ��ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="paymentDataWork">�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="salesSlipWorkList">����f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="salesDetailWorkList">���㖾�׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="salesTempWorkArray">����f�[�^(����)���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForReadingResult( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out List<SalesSlipWork> salesSlipWorkList, out List<SalesDetailWork> salesDetailWorkList, out SalesTempWork[] salesTempWorkArray )
        {
            DivisionCustomSerializeArrayListForReadingResultProc(paraList, paraList2, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWorkArray, out paymentDataWork, out stockWorkArray, out salesSlipWorkList, out salesDetailWorkList, out salesTempWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayList���d�����׃f�[�^�I�u�W�F�N�g�A����f�[�^�I�u�W�F�N�g�A���㖾�׃f�[�^�I�u�W�F�N�g�ɕ������܂��B�i���דǂݍ��ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="salesSlipWorkArray">����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForDetailsReadingResult( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockDetailWork[] stockDetailWorkArray, out SalesSlipWork[] salesSlipWorkArray, out SalesDetailWork[] salesDetailWorkArray )
        {
            DivisionCustomSerializeArrayListForDetailsReadingResultProc(paraList, paraList2, out stockDetailWorkArray, out salesSlipWorkArray, out salesDetailWorkArray);
        }

        #endregion

        #region ��Private Static Methods

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�������ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWork">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="paymentDataWork">�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesTempWorkArray">����f�[�^(�d�������v��)���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForAfterWritingResultProc( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWork, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out SalesTempWork[] salesTempWorkArray )
        {
            //------------------------------------------------------------------------------------
            // �������݌��CustomSerializeArrayList�̍\���i�������ݎ��Ɠ����j
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList					�������݃p�����[�^���X�g
            //      --IOWriteCtrlOptWork					IOWrite���䃏�[�N�I�u�W�F�N�g
            //      --CustomSerializeArrayList				�d�����X�g
            //          --StockSlipWork						�d���f�[�^�I�u�W�F�N�g
            //          --ArrayList							�d�����׃��X�g
            //              --StockDetailWork				�d�����׃f�[�^�I�u�W�F�N�g
            //          --ArrayList							�v�㌳���׃��X�g
            //              --AddUppOrgStockDetailWork		�v�㌳�d�����׃f�[�^�I�u�W�F�N�g
            //          --ArrayList							�݌Ƀ��X�g
            //              --StockWork						�݌Ƀf�[�^�I�u�W�F�N�g
            //          --PaymentSlpWork					�x���f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList				����������
            //          --SalesTempWork						�������͔���f�[�^�I�u�W�F�N�g
            //------------------------------------------------------------------------------------

            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWork = null;
            paymentDataWork = null;
            stockWorkArray = null;
            salesTempWorkArray = null;

            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList slipArrayList = (CustomSerializeArrayList)paraList[i];

                    for (int cnt = 0; cnt < slipArrayList.Count; cnt++)
                    {
                        if (slipArrayList[cnt] is StockSlipWork)
                        {
                            stockSlipWork = (StockSlipWork)slipArrayList[cnt];
                        }
                        else if (slipArrayList[cnt] is PaymentDataWork)
                        {
                            paymentDataWork = (PaymentDataWork)slipArrayList[cnt];
                        }
                        else if (slipArrayList[cnt] is ArrayList)
                        {
                            ArrayList list = (ArrayList)slipArrayList[cnt];

                            if (list.Count == 0) continue;

                            if (list[0] is AddUpOrgStockDetailWork)
                            {
                                addUpOrgStockDetailWork = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                            }
                            else if (list[0] is StockDetailWork)
                            {
                                stockDetailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                            }
                            else if (list[0] is StockWork)
                            {
                                stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                            }
                        }
                        if (slipArrayList[cnt] is SalesTempWork)
                        {
                            salesTempWorkArray = (SalesTempWork[])slipArrayList.ToArray(typeof(SalesTempWork));
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�ǂݍ��ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="paymentDataWork">�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="salesSlipWorkList">����f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="salesDetailWorkList">���㖾�׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="salesTempWorkArray">����f�[�^(����)���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForReadingResultProc( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out List<SalesSlipWork> salesSlipWorkList, out List<SalesDetailWork> salesDetailWorkList, out SalesTempWork[] salesTempWorkArray )
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // �ǂݍ��݌��CustomSerializeArrayList�̍\��
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                �d����񃊃X�g                                      
            //      --StockSlipWork                     �d���f�[�^�I�u�W�F�N�g
            //      --ArrayList							�d�����׃��X�g
            //      --StockDetailWork                   �d�����׃f�[�^�I�u�W�F�N�g
            //      --PaymentDataWork                   �x���f�[�^
            //      --ArrayList                         �v�㌳�d�����׃��X�g
            //      --AddUpOrgStockDetailWork           �v�㌳�d�����׃f�[�^�I�u�W�F�N�g
            //
            //-----------------------------------------------------------------------------------------------------------------------
            //
            //  CustomSerializeArrayList                �v��^�����񃊃X�g
            //      --CustomSerializeArrayList          �v�㌳�`�[�f�[�^
            //          --StockSlipWork                 �v�㌳�d���f�[�^�I�u�W�F�N�g
            //          --ArrayList                     �v�㌳�d�����׃��X�g
            //              --StockDetailWork           �v�㌳�d�����׃f�[�^�I�u�W�F�N�g
            //          --PaymentDataWork               �v�㌳�̎x���f�[�^
            //          --ArrayList                     �v�㌳�̌v�㌳�d�����׃��X�g
            //              --AddUpOrgStockDetailWork   �v�㌳�̌v�㌳�d�����׃f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList          �������͔���f�[�^
            //          --SalesSlipWork                 �������͔���f�[�^�I�u�W�F�N�g
            //          --ArrayList                     �������͔��㖾�׃��X�g
            //              --SalesDetailWork           �������͔��㖾�׃f�[�^�I�u�W�F�N�g
            //          --ArrayList                     �������͂̌v�㌳���㖾�׃��X�g
            //              --AddUpOrgSalesDetailWork   �������͂̌v�㌳���㖾�׃f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList          �������͌v�㌳����f�[�^
            //          --SalesSlipWork                 �������͌v�㌳����f�[�^�I�u�W�F�N�g
            //          --ArrayList                     �������͌v�㌳���㖾�׃��X�g
            //              --SalesDetailWork           �������͌v�㌳���㖾�׃f�[�^�I�u�W�F�N�g
            //          --ArrayList                     �������͂̌v�㌳���㖾�׃��X�g
            //              --AddUpOrgSalesDetailWork   �������͂̌v�㌳���㖾�׃f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList          �������͔���f�[�^(�d�������v��)
            //          --SalesTempWork[]               �������͔���f�[�^(�d�������v��)�f�[�^�z��
            //-----------------------------------------------------------------------------------------------------------------------

            // �d�����̎擾
            DivisionCustomSerializeArrayListForStockSlipInfo(paraList, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWorkArray, out paymentDataWork, out stockWorkArray);

            salesTempWorkArray = null;
            salesSlipWorkList = new List<SalesSlipWork>();
            salesDetailWorkList = new List<SalesDetailWork>();

            for (int i = 0; i < paraList2.Count; i++)
            {
                if (paraList2[i] is CustomSerializeArrayList)
                {
                    object objSlipWork;
                    object objDetailWorkArray;
                    object objAddUpOrgDetailWorkArray;
                    object objDepsitMainWork;
                    object objDepositAlwWork;
                    StockWork[] stockWorkArray2;

                    DivisionCustomSerializeArrayListProc((CustomSerializeArrayList)paraList2[i], out objSlipWork, out objDetailWorkArray, out objAddUpOrgDetailWorkArray, out objDepsitMainWork, out objDepositAlwWork, out stockWorkArray2);

                    if (objDetailWorkArray != null)
                    {
                        if (objDetailWorkArray is SalesTempWork[])
                        {
                            salesTempWorkArray = (SalesTempWork[])objDetailWorkArray;
                        }
                        else if (objDetailWorkArray is SalesDetailWork[])
                        {
                            if (objSlipWork is SalesSlipWork)
                            {
                                salesSlipWorkList.Add((SalesSlipWork)objSlipWork);
                            }
                            salesDetailWorkList.AddRange((SalesDetailWork[])objDetailWorkArray);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayList���d�����׃f�[�^�I�u�W�F�N�g�A����f�[�^�I�u�W�F�N�g�A���㖾�׃f�[�^�I�u�W�F�N�g�ɕ������܂��B�i���דǂݍ��ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="salesSlipWorkArray">����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForDetailsReadingResultProc( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockDetailWork[] stockDetailWorkArray, out SalesSlipWork[] salesSlipWorkArray, out SalesDetailWork[] salesDetailWorkArray )
        {
            stockDetailWorkArray = null;
            salesSlipWorkArray = null;
            salesDetailWorkArray = null;

            ArrayList retStockDetailWorkList = new ArrayList();
            for (int x = 0; x < paraList.Count; x++)
            {
                if (paraList[x] is ArrayList)
                {
                    ArrayList retList = (ArrayList)paraList[x];
                    for (int i = 0; i < retList.Count; i++)
                    {
                        if (retList[i] is StockDetailWork)
                        {
                            retStockDetailWorkList.Add((StockDetailWork)retList[i]);
                        }
                    }
                }
            }

            stockDetailWorkArray = (StockDetailWork[])retStockDetailWorkList.ToArray(typeof(StockDetailWork));

            if (paraList2 != null)
            {
                ArrayList retSalesSlipWorkList = new ArrayList();
                ArrayList retSalesDetailWorkList = new ArrayList();

                for (int i = 0; i < paraList2.Count; i++)
                {
                    if (paraList2[i] is CustomSerializeArrayList)
                    {
                        SalesSlipWork readSalesSlipWork;
                        SalesDetailWork[] readSalesDetailWorkArray;

                        DivisionCustomSerializeArrayListForSalesSlipInfo((CustomSerializeArrayList)paraList2[i], out readSalesSlipWork, out readSalesDetailWorkArray);

                        if (readSalesSlipWork != null) retSalesSlipWorkList.Add(readSalesSlipWork);

                        if (readSalesDetailWorkArray != null) retSalesDetailWorkList.AddRange(readSalesDetailWorkArray);
                    }
                }

                salesSlipWorkArray = (SalesSlipWork[])retSalesSlipWorkList.ToArray(typeof(SalesSlipWork));
                salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
            }
        }

        #region ���d���`�[���p

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�d���`�[���p�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="paymentDataWork">�x���f�[�^���[�N�I�u�W�F�N�g</param>
        private static void DivisionCustomSerializeArrayListForStockSlipInfo( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray )
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            paymentDataWork = null;
            stockWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;

            DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray);

            if (( objStockSlipWork != null ) && ( objStockSlipWork is StockSlipWork )) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if (( objStockDetailWorkArray != null ) && ( objStockDetailWorkArray is StockDetailWork[] )) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if (( objAddUpOrgStockDetailWorkArray != null ) && ( objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[] )) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;

            if (( objPaymentWork != null ) && ( objPaymentWork is PaymentDataWork )) paymentDataWork = (PaymentDataWork)objPaymentWork;
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�d���`�[���p�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForStockSlipInfo( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray )
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objAddUpOrgStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            StockWork[] stockWorkArray;

            DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray);

            if (( objStockSlipWork != null ) && ( objStockSlipWork is StockSlipWork )) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if (( objStockDetailWorkArray != null ) && ( objStockDetailWorkArray is StockDetailWork[] )) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;
        }
        #endregion

        #region ������`�[���p

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i����`�[���p�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitMainWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForSalesSlipInfo( CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUppOrgSalesDetailWorkArray, out DepsitMainWork depsitMainWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray )
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUppOrgSalesDetailWorkArray = null;
            depsitMainWork = null;
            depositAlwWork = null;
            stockWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitMainWork;
            object objDepositAlwWork;

            DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitMainWork, out objDepositAlwWork, out stockWorkArray);

            if (( objSalesSlipWork != null ) && ( objSalesSlipWork is SalesSlipWork )) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if (( objSalesDetailWorkArray != null ) && ( objSalesDetailWorkArray is SalesDetailWork[] )) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if (( objAddUpOrgSalesDetailWorkArray != null ) && ( objAddUpOrgSalesDetailWorkArray is AddUpOrgSalesDetailWork[] )) objAddUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if (( objDepsitMainWork != null ) && ( objDepsitMainWork is DepsitMainWork )) depsitMainWork = (DepsitMainWork)objDepsitMainWork;

            if (( objDepositAlwWork != null ) && ( objDepositAlwWork is DepositAlwWork )) depositAlwWork = (DepositAlwWork)objDepositAlwWork;
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i������p�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForSalesSlipInfo( CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray )
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitMainWork;
            object objDepositAlwWork;
            StockWork[] stockWorkArray;

            DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitMainWork, out objDepositAlwWork, out stockWorkArray);

            if (( objSalesSlipWork != null ) && ( objSalesSlipWork is SalesSlipWork )) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if (( objSalesDetailWorkArray != null ) && ( objSalesDetailWorkArray is SalesDetailWork[] )) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;
        }

        #endregion

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="slipWork">�`�[�f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="detailWorkArray">���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitMainWork">�����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">�����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListProc( CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitMainWork, out object depositAlwWork, out StockWork[] stockWorkArray )
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitMainWork = null;
            depositAlwWork = null;
            stockWorkArray = null;

            for (int i = 0; i < paraList.Count; i++)
            {
                if (( paraList[i] is StockSlipWork ) || ( paraList[i] is SalesSlipWork ))
                {
                    slipWork = paraList[i];
                }
                else if (( paraList[i] is PaymentDataWork ) || ( paraList[i] is DepsitMainWork ))
                {
                    depsitMainWork = paraList[i];
                }
                else if (paraList[i] is DepositAlwWork)
                {
                    depositAlwWork = paraList[i];
                }
                else if (paraList[i] is SalesTempWork)
                {
                    detailWorkArray = (SalesTempWork[])paraList.ToArray(typeof(SalesTempWork));
                    break;
                }
                else if (paraList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is AddUpOrgStockDetailWork)
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                    }
                    else if (list[0] is AddUpOrgSalesDetailWork)
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray(typeof(AddUpOrgSalesDetailWork));
                    }
                    else if (list[0] is StockDetailWork)
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                    }
                    else if (list[0] is SalesDetailWork)
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray(typeof(SalesDetailWork));
                    }
                    else if (list[0] is StockWork)
                    {
                        stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayList���d�����׃f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayList( CustomSerializeArrayList paraList, out StockDetailWork[] stockDetailWorkArray )
        {
            stockDetailWorkArray = null;

            ArrayList retStockDetailWorkList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is StockDetailWork)
                {
                    retStockDetailWorkList.Add((StockDetailWork)paraList[i]);
                }
            }
            stockDetailWorkArray = (StockDetailWork[])retStockDetailWorkList.ToArray(typeof(StockDetailWork));
        }

        #endregion


    }
}

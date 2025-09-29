//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上伝票入力
// プログラム概要   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : LDNS
// 作 成 日  2010/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2010/05/30  修正内容 : 成果物統合
//----------------------------------------------------------------------------//
// 管理番号				 作成担当 : 朱宝軍
// 作 成 日  2011/07/18  修正内容 : 回答区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハン
// 作 成 日  2012/03/12  修正内容 : Redmine#28288
//                                  行を追加して更新を行うと、送信済みのチェックがかかるについての修正
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI今野 利裕
// 作 成 日  2013/03/21  修正内容 : SPK車台番号文字列対応
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本　利明
// 作 成 日  2014/05/19  修正内容 : 仕掛一覧№2218 車輌備考欄にコード入力項目を追加
//----------------------------------------------------------------------------//
#pragma once
#include<windows.h>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::Controller;
using namespace Broadleaf::Application::Common;
using namespace Broadleaf::Application::UIData;
namespace Broadleaf{
	namespace Application{
		namespace Remoting{
			namespace ParamData{
				// C++/CLI構造体宣言
#pragma pack(push, 1)

struct StructSalesSlipSearchResult{
                    BSTR EnterpriseCode;
                    int LogicalDeleteCode;
                    BSTR SalesSlipNum;
                };

                struct StructColorInfo{
                    BSTR ColorCode;
                    BSTR ColorName;
                    int MakerCode;
                    int ModelCode;
                    int ModelSubCode;
                    bool SelectionState;
                };

                struct StructTrimInfo{
                    int MakerCode;
                    int ModelCode;
                    int ModelSubCode;
                    BSTR TrimCode;
                    BSTR TrimName;
                    bool SelectionState;
                };

                struct StructCEqpDefDspInfo{
                    int EquipmentCode;
                    int EquipmentDispOrder;
                    int EquipmentGenreCd;
                    BSTR EquipmentGenreNm;
                    int EquipmentIconCode;
                    BSTR EquipmentName;
                    BSTR EquipmentShortName;
                    int MakerCode;
                    int ModelCode;
                    int ModelSubCode;
                    bool SelectionState;
                    int SystematicCode;
                };

                struct StructCarSpecInfo{
                    BSTR ModelGradeNm;
                    BSTR BodyName;
                    int DoorCount;
                    BSTR EDivNm;
                    BSTR EngineDisplaceNm;
                    BSTR EngineModelNm;
                    BSTR ShiftNm;
                    BSTR TransmissionNm;
                    BSTR WheelDriveMethodNm;
                    BSTR AddiCarSpec1;
                    BSTR AddiCarSpec2;
                    BSTR AddiCarSpec3;
                    BSTR AddiCarSpec4;
                    BSTR AddiCarSpec5;
                    BSTR AddiCarSpec6;
                };

                struct StructCarInfo{
                    BSTR CarRelationGuid;
                    int CustomerCode;
                    int CarMngNo;
                    BSTR CarMngCode;
                    int NumberPlate1Code;
                    BSTR NumberPlate1Name;
                    BSTR NumberPlate2;
                    BSTR NumberPlate3;
                    int NumberPlate4;
                    long long EntryDate;
                    int FirstEntryDate;
                    int MakerCode;
                    BSTR MakerFullName;
                    BSTR MakerHalfName;
                    int ModelCode;
                    int ModelSubCode;
                    BSTR ModelFullName;
                    BSTR ModelHalfName;
                    int SystematicCode;
                    BSTR SystematicName;
                    int ProduceTypeOfYearCd;
                    BSTR ProduceTypeOfYearNm;
                    long long StProduceTypeOfYear;
                    long long EdProduceTypeOfYear;
                    int DoorCount;
                    int BodyNameCode;
                    BSTR BodyName;
                    BSTR ExhaustGasSign;
                    BSTR SeriesModel;
                    BSTR CategorySignModel;
                    BSTR FullModel;
                    int ModelDesignationNo;
                    int CategoryNo;
                    BSTR FrameModel;
                    BSTR FrameNo;
                    int SearchFrameNo;
                    int StProduceFrameNo;
                    int EdProduceFrameNo;
                    BSTR ModelGradeNm;
                    BSTR EngineModelNm;
                    BSTR EngineDisplaceNm;
                    BSTR EDivNm;
                    BSTR TransmissionNm;
                    BSTR ShiftNm;
                    BSTR WheelDriveMethodNm;
                    BSTR AddiCarSpec1;
                    BSTR AddiCarSpec2;
                    BSTR AddiCarSpec3;
                    BSTR AddiCarSpec4;
                    BSTR AddiCarSpec5;
                    BSTR AddiCarSpec6;
                    BSTR AddiCarSpecTitle1;
                    BSTR AddiCarSpecTitle2;
                    BSTR AddiCarSpecTitle3;
                    BSTR AddiCarSpecTitle4;
                    BSTR AddiCarSpecTitle5;
                    BSTR AddiCarSpecTitle6;
                    BSTR RelevanceModel;
                    int SubCarNmCd;
                    BSTR ModelGradeSname;
                    int BlockIllustrationCd;
                    int ThreeDIllustNo;
                    int PartsDataOfferFlag;
                    long long InspectMaturityDate;
                    long long LTimeCiMatDate;
                    int CarInspectYear;
                    int Mileage;
                    BSTR CarNo;
                    BSTR FullModelFixedNoAry;
                    BSTR CategoryObjAry;
                    int ProduceTypeOfYearInput;
                    BSTR ColorCode;
                    BSTR ColorName1;
                    BSTR TrimCode;
                    BSTR TrimName;
                    int AcceptAnOrderNo;
                    BSTR CarNote;
                    BSTR CarAddInfo1;
                    BSTR CarAddInfo2;
                    BSTR EngineModel;
                    BSTR ProduceTypeOfYearRange;
                    BSTR ProduceFrameNoRange;
                    int DomesticForeignCode; // ADD 2013/03/21
                    int CarNoteCode; // ADD 2014/05/19 T.Miyamoto 仕掛一覧_№2218
                };

                struct StructCarModel{
                    BSTR CategorySign;
                    BSTR ExhaustGasSign;
                    BSTR FullModel;
                    bool IsFullModel;
                    BSTR SeriesModel;
                };

                struct StructEngineModel{
                    BSTR FullModel;
                    BSTR Model;
                    BSTR ModelNm;
                };

                struct StructCarSearchCondition{
                    StructCarModel CarModel;
                    int CategoryNo;
                    StructEngineModel EngineModel;
                    int EraNameDispCd1;
                    bool IsReady;
                    int MakerCode;
                    int ModelCode;
                    int ModelDesignationNo;
                    BSTR ModelPlate;
                    int ModelSubCode;
                };
                
                struct StructCustomArrayB4{
                    StructCEqpDefDspInfo* Csafield1;
                    int Csafield1Count;
                };

                struct StructCustomArrayB3{
                    StructTrimInfo* Csafield1;
                    int Csafield1Count;
                };

                struct StructCustomArrayB2{
                    StructColorInfo* Csafield1;
                    int Csafield1Count;
                };

                
                // add by gaofeng start
                struct StructCustomerSearchRet{
                    int AcceptWholeSale;
                    BSTR Address1;
                    BSTR Address3;
                    BSTR Address4;
                    int CustomerCode;
                    BSTR CustomerEpCode;
                    BSTR CustomerSecCode;
                    int CustomerSlipNoDiv;
                    BSTR CustomerSubCode;
                    BSTR EnterpriseCode;
                    BSTR EnterpriseName;
                    BSTR HomeTelNo;
                    BSTR HonorificTitle;
                    BSTR Kana;
                    int LogicalDeleteCode;
                    BSTR MngSectionCode;
                    BSTR Name;
                    BSTR Name2;
                    BSTR OfficeTelNo;
                    BSTR PortableTelNo;
                    BSTR PostNo;
                    BSTR SearchTelNo;
                    BSTR Snm;
                    int TotalDay;
                    long long UpdateDate;
                };

				struct StructSalesSlip{
                    int AcptAnOdrStatus;
                    BSTR SalesSlipNum;
                    BSTR SectionCode;
					int InputMode;
					int SalesSlipDisplay;
					int AcptAnOdrStatusDisplay;
					int CarMngDivCd;
                    int SubSectionCode;
					BSTR SubSectionName;
                    int DebitNoteDiv;
                    BSTR DebitNLnkSalesSlNum;
                    int SalesSlipCd;
                    int SalesGoodsCd;
                    int AccRecDivCd;
                    BSTR SalesInpSecCd;
                    BSTR DemandAddUpSecCd;
                    BSTR ResultsAddUpSecCd;
					BSTR ResultsAddUpSecNm;
                    BSTR UpdateSecCd;
                    int SalesSlipUpdateCd;
                    long long SearchSlipDate;
                    long long ShipmentDay;
                    long long SalesDate;
                    long long AddUpADate;
                    int DelayPaymentDiv;
                    BSTR EstimateFormNo;
                    int EstimateDivide;
                    BSTR InputAgenCd;
                    BSTR InputAgenNm;
                    BSTR SalesInputCode;
                    BSTR SalesInputName;
                    BSTR FrontEmployeeCd;
                    BSTR FrontEmployeeNm;
                    BSTR SalesEmployeeCd;
                    BSTR SalesEmployeeNm;
                    int TotalAmountDispWayCd;
                    int TtlAmntDispRateApy;
                    long long SalesTotalTaxInc;
                    long long SalesTotalTaxExc;
                    long long SalesPrtTotalTaxInc;
                    long long SalesPrtTotalTaxExc;
                    long long SalesWorkTotalTaxInc;
                    long long SalesWorkTotalTaxExc;
                    long long SalesSubtotalTaxInc;
                    long long SalesSubtotalTaxExc;
                    long long SalesPrtSubttlInc;
                    long long SalesPrtSubttlExc;
                    long long SalesWorkSubttlInc;
                    long long SalesWorkSubttlExc;
                    long long SalesNetPrice;
                    long long SalesSubtotalTax;
                    long long ItdedSalesOutTax;
                    long long ItdedSalesInTax;
                    long long SalSubttlSubToTaxFre;
                    long long SalesOutTax;
                    long long SalAmntConsTaxInclu;
                    long long SalesDisTtlTaxExc;
                    long long ItdedSalesDisOutTax;
                    long long ItdedSalesDisInTax;
                    long long ItdedPartsDisOutTax;
                    long long ItdedPartsDisInTax;
                    long long ItdedWorkDisOutTax;
                    long long ItdedWorkDisInTax;
                    long long ItdedSalesDisTaxFre;
                    long long SalesDisOutTax;
                    long long SalesDisTtlTaxInclu;
                    double PartsDiscountRate;
                    double RavorDiscountRate;
                    long long TotalCost;
                    int ConsTaxLayMethod;
                    double ConsTaxRate;
                    int FractionProcCd;
                    long long AccRecConsTax;
                    int AutoDepositCd;
                    int AutoDepositSlipNo;
                    long long DepositAllowanceTtl;
                    long long DepositAlwcBlnce;
                    int ClaimCode;
                    BSTR ClaimSnm;
                    int CustomerCode;
                    BSTR CustomerName;
                    BSTR CustomerName2;
                    BSTR CustomerSnm;
                    BSTR HonorificTitle;
                    int OutputNameCode;
                    BSTR OutputName;
                    int CustSlipNo;
                    int SlipAddressDiv;
                    int AddresseeCode;
                    BSTR AddresseeName;
                    BSTR AddresseeName2;
                    BSTR AddresseePostNo;
                    BSTR AddresseeAddr1;
                    BSTR AddresseeAddr3;
                    BSTR AddresseeAddr4;
                    BSTR AddresseeTelNo;
                    BSTR AddresseeFaxNo;
                    BSTR PartySaleSlipNum;
                    BSTR SlipNote;
                    BSTR SlipNote2;
                    BSTR SlipNote3;
					int SlipNoteCode;
					int SlipNote2Code;
					int SlipNote3Code;
                    int RetGoodsReasonDiv;
                    BSTR RetGoodsReason;
                    long long RegiProcDate;
                    int CashRegisterNo;
                    int PosReceiptNo;
                    int DetailRowCount;
                    long long EdiSendDate;
                    long long EdiTakeInDate;
                    BSTR UoeRemark1;
                    BSTR UoeRemark2;
                    int SlipPrintDivCd;
                    int SlipPrintFinishCd;
                    long long SalesSlipPrintDate;
                    int BusinessTypeCode;
                    BSTR BusinessTypeName;
                    BSTR OrderNumber;
                    int DeliveredGoodsDiv;
                    BSTR DeliveredGoodsDivNm;
                    int SalesAreaCode;
                    BSTR SalesAreaName;
                    int ReconcileFlag;
                    BSTR SlipPrtSetPaperId;
                    int CompleteCd;
                    int SalesPriceFracProcCd;
                    long long StockGoodsTtlTaxExc;
                    long long PureGoodsTtlTaxExc;
                    int ListPricePrintDiv;
                    int EraNameDispCd1;
                    int EstimaTaxDivCd;
                    int EstimateFormPrtCd;
                    BSTR EstimateSubject;
                    BSTR Footnotes1;
                    BSTR Footnotes2;
                    BSTR EstimateTitle1;
                    BSTR EstimateTitle2;
                    BSTR EstimateTitle3;
                    BSTR EstimateTitle4;
                    BSTR EstimateTitle5;
                    BSTR EstimateNote1;
                    BSTR EstimateNote2;
                    BSTR EstimateNote3;
                    BSTR EstimateNote4;
                    BSTR EstimateNote5;
                    long long EstimateValidityDate;
                    int PartsNoPrtCd;
                    int OptionPringDivCd;
                    int RateUseCode;
                    long long CreateDateTime;
                    long long UpdateDateTime;
                    BSTR EnterpriseCode;
                    unsigned char FileHeaderGuid[16];
                    BSTR UpdEmployeeCode;
                    BSTR UpdAssemblyId1;
                    BSTR UpdAssemblyId2;
					int CustOrderNoDispDiv;
					BSTR CustWarehouseCd;
					int CreditMngCode;
					int DetailRowCountForReadSlip;
                    //>>>2010/05/30
                    int OnlineKindDiv;
					BSTR InqOriginalEpCd;
					BSTR InqOriginalSecCd;
			        int AnswerDiv;
					long long InquiryNumber;
					int InqOrdDivCd;
					//<<<2010/05/30
					int AutoAnswerDivSCM;// add 2011/07/18 朱宝軍 
					long long PreSalesDate;//ADD 鄧潘ハン 2012/03/12 Redmine#28288
                };

				struct StructCarMangInputExtraInfo{
                    BSTR AddiCarSpec1;
                    BSTR AddiCarSpec2;
                    BSTR AddiCarSpec3;
                    BSTR AddiCarSpec4;
                    BSTR AddiCarSpec5;
                    BSTR AddiCarSpec6;
                    BSTR AddiCarSpecTitle1;
                    BSTR AddiCarSpecTitle2;
                    BSTR AddiCarSpecTitle3;
                    BSTR AddiCarSpecTitle4;
                    BSTR AddiCarSpecTitle5;
                    BSTR AddiCarSpecTitle6;
                    int BlockIllustrationCd;
                    BSTR BodyName;
                    int BodyNameCode;
                    BSTR CarAddInfo1;
                    BSTR CarAddInfo2;
                    int CarInspectYear;
                    BSTR CarMngCode;
                    int CarMngNo;
                    BSTR CarNo;
                    BSTR CarNote;
                    unsigned char CarRelationGuid[16];
                    int CategoryNo;
                    //BSTR CategoryObjAry;
                    BSTR CategorySignModel;
                    BSTR ColorCode;
                    BSTR ColorName1;
                    long long CreateDateTime;
                    int CustomerCode;
                    BSTR CustomerCodeForGuide;
                    BSTR CustomerName;
                    int DoorCount;
                    BSTR EDivNm;
                    int EdProduceFrameNo;
                    long long EdProduceTypeOfYear;
                    BSTR EngineDisplaceNm;
                    BSTR EngineModel;
                    BSTR EngineModelNm;
                    BSTR EnterpriseCode;
                    long long EntryDate;
                    BSTR ExhaustGasSign;
                    unsigned char FileHeaderGuid[16];
                    int FirstEntryDate;
                    BSTR FrameModel;
                    BSTR FrameNo;
                    BSTR FullModel;
                    //BSTR FullModelFixedNoAry;
                    long long InspectMaturityDate;
                    int LogicalDeleteCode;
                    long long LTimeCiMatDate;
                    int MakerCode;
                    BSTR MakerFullName;
                    BSTR MakerHalfName;
                    int Mileage;
                    int ModelCode;
                    int ModelDesignationNo;
                    BSTR ModelFullName;
                    BSTR ModelGradeNm;
                    BSTR ModelGradeSname;
                    BSTR ModelHalfName;
                    int ModelSubCode;
                    int NumberPlate1Code;
                    BSTR NumberPlate1Name;
                    BSTR NumberPlate2;
                    BSTR NumberPlate3;
                    int NumberPlate4;
                    BSTR NumberPlateForGuide;
                    int PartsDataOfferFlag;
                    int ProduceTypeOfYearCd;
                    int ProduceTypeOfYearInput;
                    BSTR ProduceTypeOfYearNm;
                    BSTR RelevanceModel;
                    int SearchFrameNo;
                    BSTR SeriesModel;
                    BSTR ShiftNm;
                    int StProduceFrameNo;
                    long long StProduceTypeOfYear;
                    int SubCarNmCd;
                    int SystematicCode;
                    BSTR SystematicName;
                    int ThreeDIllustNo;
                    BSTR TransmissionNm;
                    BSTR TrimCode;
                    BSTR TrimName;
                    long long UpdateDateTime;
                    BSTR WheelDriveMethodNm;
                    int DomesticForeignCode; // ADD 2013/03/21
                };

				struct StructModelNameU{
                    long long CreateDateTime;
                    BSTR CreateDateTimeAdFormal;
                    BSTR CreateDateTimeAdInFormal;
                    BSTR CreateDateTimeJpFormal;
                    BSTR CreateDateTimeJpInFormal;
                    int Division;
                    BSTR DivisionName;
                    BSTR EnterpriseCode;
                    BSTR EnterpriseName;
                    unsigned char FileHeaderGuid[16];
                    int LogicalDeleteCode;
                    int MakerCode;
                    BSTR ModelAliasName;
                    int ModelCode;
                    BSTR ModelFullName;
                    BSTR ModelHalfName;
                    int ModelSubCode;
                    int ModelUniqueCode;
                    int OfferDataDiv;
                    long long OfferDate;
                    BSTR UpdAssemblyId1;
                    BSTR UpdAssemblyId2;
                    long long UpdateDateTime;
                    BSTR UpdateDateTimeAdFormal;
                    BSTR UpdateDateTimeAdInFormal;
                    BSTR UpdateDateTimeJpFormal;
                    BSTR UpdateDateTimeJpInFormal;
                    BSTR UpdEmployeeCode;
                    BSTR UpdEmployeeName;
                };
                // add by gaofeng end

				// add by Zhangkai start
				struct StructSalesDetail{
                    int AcptAnOdrStatus;
                    BSTR SalesSlipNum;
                    int SalesRowNo;
                    int SalesRowDerivNo;
                    BSTR SectionCode;
                    int SubSectionCode;
                    int SalesDate;
                    long long CommonSeqNo;
                    long long SalesSlipDtlNum;
                    int AcptAnOdrStatusSrc;
                    long long SalesSlipDtlNumSrc;
                    int SupplierFormalSync;
                    long long StockSlipDtlNumSync;
                    int SalesSlipCdDtl;
                    long long DeliGdsCmpltDueDate;
                    int GoodsKindCode;
                    int GoodsSearchDivCd;
                    int GoodsMakerCd;
                    BSTR MakerName;
                    BSTR MakerKanaName;
                    BSTR GoodsNo;
                    BSTR GoodsName;
                    BSTR GoodsNameKana;
                    int GoodsLGroup;
                    BSTR GoodsLGroupName;
                    int GoodsMGroup;
                    BSTR GoodsMGroupName;
                    int BLGroupCode;
                    BSTR BLGroupName;
                    int BLGoodsCode;
                    BSTR BLGoodsFullName;
                    int EnterpriseGanreCode;
                    BSTR EnterpriseGanreName;
                    BSTR WarehouseCode;
                    BSTR WarehouseName;
                    BSTR WarehouseShelfNo;
                    int SalesOrderDivCd;
                    int OpenPriceDiv;
                    BSTR GoodsRateRank;
                    int CustRateGrpCode;
                    double ListPriceRate;
                    BSTR RateSectPriceUnPrc;
                    BSTR RateDivLPrice;
                    int UnPrcCalcCdLPrice;
                    int PriceCdLPrice;
                    double StdUnPrcLPrice;
                    double FracProcUnitLPrice;
                    int FracProcLPrice;
                    double ListPriceTaxIncFl;
                    double ListPriceTaxExcFl;
                    int ListPriceChngCd;
                    double SalesRate;
                    BSTR RateSectSalUnPrc;
                    BSTR RateDivSalUnPrc;
                    int UnPrcCalcCdSalUnPrc;
                    int PriceCdSalUnPrc;
                    double StdUnPrcSalUnPrc;
                    double FracProcUnitSalUnPrc;
                    int FracProcSalUnPrc;
                    double SalesUnPrcTaxIncFl;
                    double SalesUnPrcTaxExcFl;
                    int SalesUnPrcChngCd;
                    double CostRate;
                    BSTR RateSectCstUnPrc;
                    BSTR RateDivUnCst;
                    int UnPrcCalcCdUnCst;
                    int PriceCdUnCst;
                    double StdUnPrcUnCst;
                    double FracProcUnitUnCst;
                    int FracProcUnCst;
                    double SalesUnitCost;
                    int SalesUnitCostChngDiv;
                    int RateBLGoodsCode;
                    BSTR RateBLGoodsName;
                    int RateGoodsRateGrpCd;
                    BSTR RateGoodsRateGrpNm;
                    int RateBLGroupCode;
                    BSTR RateBLGroupName;
                    int PrtBLGoodsCode;
                    BSTR PrtBLGoodsName;
                    int SalesCode;
                    BSTR SalesCdNm;
                    double WorkManHour;
                    double ShipmentCnt;
                    double AcceptAnOrderCnt;
                    double AcptAnOdrAdjustCnt;
                    double AcptAnOdrRemainCnt;
                    int RemainCntUpdDate;
                    long long SalesMoneyTaxInc;
                    long long SalesMoneyTaxExc;
                    long long Cost;
                    int GrsProfitChkDiv;
                    int SalesGoodsCd;
                    long long SalesPriceConsTax;
                    int TaxationDivCd;
                    BSTR PartySlipNumDtl;
                    BSTR DtlNote;
                    int SupplierCd;
                    BSTR SupplierSnm;
                    BSTR OrderNumber;
                    int WayToOrder;
                    BSTR SlipMemo1;
                    BSTR SlipMemo2;
                    BSTR SlipMemo3;
                    BSTR InsideMemo1;
                    BSTR InsideMemo2;
                    BSTR InsideMemo3;
                    double BfListPrice;
                    double BfSalesUnitPrice;
                    double BfUnitCost;
                    int CmpltSalesRowNo;
                    int CmpltGoodsMakerCd;
                    BSTR CmpltMakerName;
                    BSTR CmpltMakerKanaName;
                    BSTR CmpltGoodsName;
                    double CmpltShipmentCnt;
                    double CmpltSalesUnPrcFl;
                    long long CmpltSalesMoney;
                    double CmpltSalesUnitCost;
                    long long CmpltCost;
                    BSTR CmpltPartySalSlNum;
                    BSTR CmpltNote;
                    BSTR PrtGoodsNo;
                    int PrtMakerCode;
                    BSTR PrtMakerName;
					int EditStatus;
                    int RowStatus;
					int SalesMoneyInputDiv;
					double ShipmentCntDisplay;
					double SupplierStockDisplay;
					double ListPriceDisplay;
					long long StockDate;
					BSTR BoCode;
					int SupplierCdForOrder;
					BSTR SupplierSnmForOrder;
					BSTR DeliveredGoodsDivNm;
                    BSTR FollowDeliGoodsDivNm;
					BSTR UOEResvdSectionNm;
					BSTR UOEDeliGoodsDiv;
                    BSTR FollowDeliGoodsDiv;
					BSTR UOEResvdSection;
					BSTR PartySalesSlipNum;
					int AcceptAnOrderNo;
					int SearchPartsModeState;
			        //>>>2010/05/30
					//int CampaignCode;
					//BSTR CampaignName;
					//int GoodsDivCd;
					//BSTR AnswerDelivDate;
					int RecycleDiv;
					BSTR RecycleDivNm;
					//int WayToAcptOdr;
					int GoodsMngNo;
					//int InqRowNumber;
					//int InqRowNumDerivedNo;
					//<<<2010/05/30
                };

				struct StructCustomArrayA2{
                    StructSalesDetail* Csafield1;
                    int Csafield1Count;
                };

				// add by Zhangkai end

				// add by Lizc start
				 struct StructCustomerInfo{
                    int AcceptWholeSale;
                    BSTR AccountNoInfo1;
                    BSTR AccountNoInfo2;
                    BSTR AccountNoInfo3;
                    int AccRecDivCd;
                    int AcpOdrrSlipPrtDiv;
                    BSTR Address1;
                    BSTR Address3;
                    BSTR Address4;
                    BSTR BillCollecterCd;
                    BSTR BillCollecterNm;
                    BSTR BillHonorificTtl;
                    int BillHonorTtlPrtDiv;
                    int BillOutputCode;
                    BSTR BillOutPutCodeNm;
                    BSTR BillOutputName;
                    int BillPartsNoPrtCd;
                    int BusinessTypeCode;
                    BSTR BusinessTypeName;
                    int CarMngDivCd;
                    int ClaimCode;
                    BSTR ClaimName;
                    BSTR ClaimName2;
                    BSTR ClaimSectionCode;
                    BSTR ClaimSectionName;
                    BSTR ClaimSnm;
                    int CollectCond;
                    int CollectMoneyCode;
                    int CollectMoneyDay;
                    BSTR CollectMoneyName;
                    int CollectSight;
                    int ConsTaxLayMethod;
                    int CorporateDivCode;
                    long long CreateDateTime;
                    BSTR CreateDateTimeAdFormal;
                    BSTR CreateDateTimeAdInFormal;
                    BSTR CreateDateTimeJpFormal;
                    BSTR CreateDateTimeJpInFormal;
                    int CreditMngCode;
                    long long CustAgentChgDate;
                    int CustAnalysCode1;
                    int CustAnalysCode2;
                    int CustAnalysCode3;
                    int CustAnalysCode4;
                    int CustAnalysCode5;
                    int CustAnalysCode6;
                    int CustCTaXLayRefCd;
                    BSTR CustomerAgent;
                    BSTR CustomerAgentCd;
                    BSTR CustomerAgentNm;
                    int CustomerAttributeDiv;
                    int CustomerCode;
                    BSTR CustomerEpCode;
                    BSTR CustomerSecCode;
                    int CustomerSlipNoDiv;
                    BSTR CustomerSnm;
                    BSTR CustomerSubCode;
                    int CustSlipNoMngCd;
                    BSTR CustWarehouseCd;
                    BSTR CustWarehouseName;
                    int DefSalesSlipCd;
                    BSTR DeliHonorificTtl;
                    int DeliHonorTtlPrtDiv;
                    int DeliPartsNoPrtCd;
                    int DepoBankCode;
                    BSTR DepoBankName;
                    int DepoDelCode;
                    int DmOutCode;
                    BSTR DmOutName;
                    BSTR EnterpriseCode;
                    BSTR EnterpriseName;
                    int EstimatePrtDiv;
                    BSTR EstmHonorificTtl;
                    int EstmHonorTtlPrtDiv;
                    unsigned char GuidFileHeaderGuid[16];
                    BSTR HomeFaxNo;
                    BSTR HomeFaxNoDspName;
                    BSTR HomeTelNo;
                    BSTR HomeTelNoDspName;
                    BSTR HonorificTitle;
                    BSTR InpSectionCode;
                    BSTR InpSectionName;
                    bool IsCustomer;
                    bool IsReceiver;
                    int JobTypeCode;
                    BSTR JobTypeName;
                    BSTR Kana;
                    int LavorRateRank;
                    int LogicalDeleteCode;
                    BSTR MailAddress1;
                    BSTR MailAddress2;
                    int MailAddrKindCode1;
                    int MailAddrKindCode2;
                    BSTR MailAddrKindName1;
                    BSTR MailAddrKindName2;
                    int MailSendCode1;
                    int MailSendCode2;
                    BSTR MailSendName1;
                    BSTR MailSendName2;
                    int MainContactCode;
                    BSTR MainContactName;
                    int MainSendMailAddrCd;
                    BSTR MngSectionCode;
                    BSTR MngSectionName;
                    BSTR MobileTelNoDspName;
                    BSTR Name;
                    BSTR Name2;
                    BSTR Note1;
                    BSTR Note10;
                    BSTR Note2;
                    BSTR Note3;
                    BSTR Note4;
                    BSTR Note5;
                    BSTR Note6;
                    BSTR Note7;
                    BSTR Note8;
                    BSTR Note9;
                    int NTimeCalcStDate;
                    BSTR OfficeFaxNo;
                    BSTR OfficeFaxNoDspName;
                    BSTR OfficeTelNo;
                    BSTR OfficeTelNoDspName;
                    BSTR OldCustomerAgentCd;
                    BSTR OldCustomerAgentNm;
                    int OnlineKindDiv;
                    BSTR OthersTelNo;
                    BSTR OtherTelNoDspName;
                    BSTR OutputName;
                    int OutputNameCode;
                    BSTR PortableTelNo;
                    BSTR PostNo;
                    BSTR PrslOrCorpDivNm;
                    int PureCode;
                    int QrcodePrtCd;
                    int ReceiptOutputCode;
                    BSTR RectHonorificTtl;
                    int RectHonorTtlPrtDiv;
                    int SalesAreaCode;
                    BSTR SalesAreaName;
                    int SalesCnsTaxFrcProcCd;
                    int SalesMoneyFrcProcCd;
                    int SalesSlipPrtDiv;
                    int SalesUnPrcFrcProcCd;
                    BSTR SearchTelNo;
                    int ShipmSlipPrtDiv;
                    int SlipTtlPrn;
                    int TotalAmntDspWayRef;
                    int TotalAmountDispWayCd;
                    int TotalDay;
                    long long TransStopDate;
                    int UOESlipPrtDiv;
                    BSTR UpdAssemblyId1;
                    BSTR UpdAssemblyId2;
                    long long UpdateDateTime;
                    BSTR UpdateDateTimeAdFormal;
                    BSTR UpdateDateTimeAdInFormal;
                    BSTR UpdateDateTimeJpFormal;
                    BSTR UpdateDateTimeJpInFormal;
                    BSTR UpdEmployeeCode;
                    BSTR UpdEmployeeName;
                };
                
                struct StructHeaderFocusConstruction{
                    BSTR Key;
                    BSTR Caption;
                    bool EnterStop;
                };

                struct StructFooterFocusConstruction{
                    BSTR Key;
                    BSTR Caption;
                    bool EnterStop;
                };

                struct StructCustomArrayB6{
                    StructFooterFocusConstruction* Csafield1;
                    int Csafield1Count;
                };

                struct StructCustomArrayB5{
                    StructHeaderFocusConstruction* Csafield1;
                    int Csafield1Count;
                };
				// add by Lizc end

				// add by Yangmj start

				// add by Yangmj end

				// add by Tanhong start

				// add by Tanhong end

#pragma pack(pop)
				// C++構造体→.NETクラスコピー処理

                void CopyStructToClass_SalesSlipSearchResult(StructSalesSlipSearchResult *structWork, SalesSlipSearchResult ^classWork){
                    classWork->EnterpriseCode = gcnew String(structWork->EnterpriseCode);
                    classWork->LogicalDeleteCode = structWork->LogicalDeleteCode;
                    classWork->SalesSlipNum = gcnew String(structWork->SalesSlipNum);
                }

				void CopyStructToClass_ColorInfo(StructColorInfo *structWork, Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo ^classWork){
                    classWork->ColorCode = gcnew String(structWork->ColorCode);
                    classWork->ColorName = gcnew String(structWork->ColorName);
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelSubCode = structWork->ModelSubCode;
                    classWork->SelectionState = structWork->SelectionState;
                }

                void CopyStructToClass_TrimInfo(StructTrimInfo *structWork, Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo ^classWork){
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelSubCode = structWork->ModelSubCode;
                    classWork->TrimCode = gcnew String(structWork->TrimCode);
                    classWork->TrimName = gcnew String(structWork->TrimName);
                    classWork->SelectionState = structWork->SelectionState;
                }

                void CopyStructToClass_CEqpDefDspInfo(StructCEqpDefDspInfo *structWork, Broadleaf::Application::Controller::SalesSlipInputAcs::CEqpDefDspInfo ^classWork){
                    classWork->EquipmentCode = structWork->EquipmentCode;
                    classWork->EquipmentDispOrder = structWork->EquipmentDispOrder;
                    classWork->EquipmentGenreCd = structWork->EquipmentGenreCd;
                    classWork->EquipmentGenreNm = gcnew String(structWork->EquipmentGenreNm);
                    classWork->EquipmentIconCode = structWork->EquipmentIconCode;
                    classWork->EquipmentName = gcnew String(structWork->EquipmentName);
                    classWork->EquipmentShortName = gcnew String(structWork->EquipmentShortName);
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelSubCode = structWork->ModelSubCode;
                    classWork->SelectionState = structWork->SelectionState;
                    classWork->SystematicCode = structWork->SystematicCode;
                }

                void CopyStructToClass_CarSpecInfo(StructCarSpecInfo *structWork, Broadleaf::Application::Controller::SalesSlipInputAcs::CarSpecInfo ^classWork){
                    classWork->ModelGradeNm = gcnew String(structWork->ModelGradeNm);
                    classWork->BodyName = gcnew String(structWork->BodyName);
                    classWork->DoorCount = structWork->DoorCount;
                    classWork->EDivNm = gcnew String(structWork->EDivNm);
                    classWork->EngineDisplaceNm = gcnew String(structWork->EngineDisplaceNm);
                    classWork->EngineModelNm = gcnew String(structWork->EngineModelNm);
                    classWork->ShiftNm = gcnew String(structWork->ShiftNm);
                    classWork->TransmissionNm = gcnew String(structWork->TransmissionNm);
                    classWork->WheelDriveMethodNm = gcnew String(structWork->WheelDriveMethodNm);
                    classWork->AddiCarSpec1 = gcnew String(structWork->AddiCarSpec1);
                    classWork->AddiCarSpec2 = gcnew String(structWork->AddiCarSpec2);
                    classWork->AddiCarSpec3 = gcnew String(structWork->AddiCarSpec3);
                    classWork->AddiCarSpec4 = gcnew String(structWork->AddiCarSpec4);
                    classWork->AddiCarSpec5 = gcnew String(structWork->AddiCarSpec5);
                    classWork->AddiCarSpec6 = gcnew String(structWork->AddiCarSpec6);
                }

                void CopyStructToClass_CarInfo(StructCarInfo *structWork, Broadleaf::Application::Controller::SalesSlipInputAcs::CarInfo ^classWork){
                    classWork->CarRelationGuid = gcnew String(structWork->CarRelationGuid);
                    classWork->CustomerCode = structWork->CustomerCode;
                    classWork->CarMngNo = structWork->CarMngNo;
                    classWork->CarMngCode = gcnew String(structWork->CarMngCode);
                    classWork->NumberPlate1Code = structWork->NumberPlate1Code;
                    classWork->NumberPlate1Name = gcnew String(structWork->NumberPlate1Name);
                    classWork->NumberPlate2 = gcnew String(structWork->NumberPlate2);
                    classWork->NumberPlate3 = gcnew String(structWork->NumberPlate3);
                    classWork->NumberPlate4 = structWork->NumberPlate4;
                    classWork->EntryDate = DateTime(structWork->EntryDate);
                    classWork->FirstEntryDate = structWork->FirstEntryDate;
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->MakerFullName = gcnew String(structWork->MakerFullName);
                    classWork->MakerHalfName = gcnew String(structWork->MakerHalfName);
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelSubCode = structWork->ModelSubCode;
                    classWork->ModelFullName = gcnew String(structWork->ModelFullName);
                    classWork->ModelHalfName = gcnew String(structWork->ModelHalfName);
                    classWork->SystematicCode = structWork->SystematicCode;
                    classWork->SystematicName = gcnew String(structWork->SystematicName);
                    classWork->ProduceTypeOfYearCd = structWork->ProduceTypeOfYearCd;
                    classWork->ProduceTypeOfYearNm = gcnew String(structWork->ProduceTypeOfYearNm);
                    classWork->StProduceTypeOfYear = DateTime(structWork->StProduceTypeOfYear);
                    classWork->EdProduceTypeOfYear = DateTime(structWork->EdProduceTypeOfYear);
                    classWork->DoorCount = structWork->DoorCount;
                    classWork->BodyNameCode = structWork->BodyNameCode;
                    classWork->BodyName = gcnew String(structWork->BodyName);
                    classWork->ExhaustGasSign = gcnew String(structWork->ExhaustGasSign);
                    classWork->SeriesModel = gcnew String(structWork->SeriesModel);
                    classWork->CategorySignModel = gcnew String(structWork->CategorySignModel);
                    classWork->FullModel = gcnew String(structWork->FullModel);
                    classWork->ModelDesignationNo = structWork->ModelDesignationNo;
                    classWork->CategoryNo = structWork->CategoryNo;
                    classWork->FrameModel = gcnew String(structWork->FrameModel);
                    classWork->FrameNo = gcnew String(structWork->FrameNo);
                    classWork->SearchFrameNo = structWork->SearchFrameNo;
                    classWork->StProduceFrameNo = structWork->StProduceFrameNo;
                    classWork->EdProduceFrameNo = structWork->EdProduceFrameNo;
                    classWork->ModelGradeNm = gcnew String(structWork->ModelGradeNm);
                    classWork->EngineModelNm = gcnew String(structWork->EngineModelNm);
                    classWork->EngineDisplaceNm = gcnew String(structWork->EngineDisplaceNm);
                    classWork->EDivNm = gcnew String(structWork->EDivNm);
                    classWork->TransmissionNm = gcnew String(structWork->TransmissionNm);
                    classWork->ShiftNm = gcnew String(structWork->ShiftNm);
                    classWork->WheelDriveMethodNm = gcnew String(structWork->WheelDriveMethodNm);
                    classWork->AddiCarSpec1 = gcnew String(structWork->AddiCarSpec1);
                    classWork->AddiCarSpec2 = gcnew String(structWork->AddiCarSpec2);
                    classWork->AddiCarSpec3 = gcnew String(structWork->AddiCarSpec3);
                    classWork->AddiCarSpec4 = gcnew String(structWork->AddiCarSpec4);
                    classWork->AddiCarSpec5 = gcnew String(structWork->AddiCarSpec5);
                    classWork->AddiCarSpec6 = gcnew String(structWork->AddiCarSpec6);
                    classWork->AddiCarSpecTitle1 = gcnew String(structWork->AddiCarSpecTitle1);
                    classWork->AddiCarSpecTitle2 = gcnew String(structWork->AddiCarSpecTitle2);
                    classWork->AddiCarSpecTitle3 = gcnew String(structWork->AddiCarSpecTitle3);
                    classWork->AddiCarSpecTitle4 = gcnew String(structWork->AddiCarSpecTitle4);
                    classWork->AddiCarSpecTitle5 = gcnew String(structWork->AddiCarSpecTitle5);
                    classWork->AddiCarSpecTitle6 = gcnew String(structWork->AddiCarSpecTitle6);
                    classWork->RelevanceModel = gcnew String(structWork->RelevanceModel);
                    classWork->SubCarNmCd = structWork->SubCarNmCd;
                    classWork->ModelGradeSname = gcnew String(structWork->ModelGradeSname);
                    classWork->BlockIllustrationCd = structWork->BlockIllustrationCd;
                    classWork->ThreeDIllustNo = structWork->ThreeDIllustNo;
                    classWork->PartsDataOfferFlag = structWork->PartsDataOfferFlag;
                    classWork->InspectMaturityDate = DateTime(structWork->InspectMaturityDate);
                    classWork->LTimeCiMatDate = DateTime(structWork->LTimeCiMatDate);
                    classWork->CarInspectYear = structWork->CarInspectYear;
                    classWork->Mileage = structWork->Mileage;
                    classWork->CarNo = gcnew String(structWork->CarNo);
                    //classWork->FullModelFixedNoAry = gcnew String(structWork->FullModelFixedNoAry);
                    //classWork->CategoryObjAry = gcnew String(structWork->CategoryObjAry);
                    classWork->ProduceTypeOfYearInput = structWork->ProduceTypeOfYearInput;
                    classWork->ColorCode = gcnew String(structWork->ColorCode);
                    classWork->ColorName1 = gcnew String(structWork->ColorName1);
                    classWork->TrimCode = gcnew String(structWork->TrimCode);
                    classWork->TrimName = gcnew String(structWork->TrimName);
                    classWork->AcceptAnOrderNo = structWork->AcceptAnOrderNo;
                    classWork->CarNote = gcnew String(structWork->CarNote);
                    classWork->CarAddInfo1 = gcnew String(structWork->CarAddInfo1);
                    classWork->CarAddInfo2 = gcnew String(structWork->CarAddInfo2);
                    classWork->EngineModel = gcnew String(structWork->EngineModel);
                    classWork->ProduceTypeOfYearRange = gcnew String(structWork->ProduceTypeOfYearRange);
                    classWork->ProduceFrameNoRange = gcnew String(structWork->ProduceFrameNoRange);
                    classWork->DomesticForeignCode = structWork->DomesticForeignCode; // ADD 2013/03/21
                    classWork->CarNoteCode = structWork->CarNoteCode; // ADD 2014/05/19 T.Miyamoto 仕掛一覧_№2218
                }

                void CopyStructToClass_CarModel(StructCarModel structWork, CarModel ^classWork){
                    //classWork->CategorySign = gcnew String(structWork.CategorySign);
                    //classWork->ExhaustGasSign = gcnew String(structWork.ExhaustGasSign);
                    classWork->FullModel = gcnew String(structWork.FullModel);
                    //structWork.IsFullModel;
                    //classWork->SeriesModel = gcnew String(structWork.SeriesModel);
                }

                void CopyStructToClass_EngineModel(StructEngineModel structWork, EngineModel ^classWork){
                    classWork->FullModel = gcnew String(structWork.FullModel);
                    //classWork->Model = gcnew String(structWork.Model);
                    //classWork->ModelNm = gcnew String(structWork.ModelNm);
                }

                void CopyStructToClass_CarSearchCondition(StructCarSearchCondition *structWork, CarSearchCondition ^classWork){
					CopyStructToClass_CarModel(structWork->CarModel, classWork->CarModel);
                    classWork->CategoryNo = structWork->CategoryNo;
					CopyStructToClass_EngineModel(structWork->EngineModel, classWork->EngineModel);
                    classWork->EraNameDispCd1 = structWork->EraNameDispCd1;
                    //classWork->IsReady = structWork->IsReady;
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelDesignationNo = structWork->ModelDesignationNo;
                    classWork->ModelPlate = gcnew String(structWork->ModelPlate);
					if (structWork->ModelSubCode == 0)
					{
						classWork->ModelSubCode = -1;
					}
					else
					{
						classWork->ModelSubCode = structWork->ModelSubCode;
					}
                }

                void CopyStructToClass_CustomArrayB4(StructCustomArrayB4 *structWork, ArrayList ^arrayWork){
                    Broadleaf::Application::Controller::SalesSlipInputAcs::CEqpDefDspInfo^ csafield1;
                    for (int i = 0; i < structWork->Csafield1Count; i++){
                        csafield1 = gcnew Broadleaf::Application::Controller::SalesSlipInputAcs::CEqpDefDspInfo();
                        CopyStructToClass_CEqpDefDspInfo(&(structWork->Csafield1[i]), csafield1);
                        arrayWork->Add(csafield1);
                    }
                }

                void CopyStructToClass_CustomArrayB3(StructCustomArrayB3 *structWork, ArrayList ^arrayWork){
                    Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo^ csafield1;
                    for (int i = 0; i < structWork->Csafield1Count; i++){
                        csafield1 = gcnew Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo();
                        CopyStructToClass_TrimInfo(&(structWork->Csafield1[i]), csafield1);
                        arrayWork->Add(csafield1);
                    }
                }

                void CopyStructToClass_CustomArrayB2(StructCustomArrayB2 *structWork, ArrayList ^arrayWork){
                    Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo^ csafield1;
                    for (int i = 0; i < structWork->Csafield1Count; i++){
                        csafield1 = gcnew Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo();
                        CopyStructToClass_ColorInfo(&(structWork->Csafield1[i]), csafield1);
                        arrayWork->Add(csafield1);
                    }
                }

				// .NETクラス→C++構造体コピー処理

                void CopyClassToStruct_SalesSlipSearchResult(SalesSlipSearchResult ^classWork, StructSalesSlipSearchResult *structWork){
                    structWork->EnterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseCode).ToPointer());
                    structWork->LogicalDeleteCode = classWork->LogicalDeleteCode;
                    structWork->SalesSlipNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesSlipNum).ToPointer());
                }

                void CopyClassToStruct_ColorInfo(Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo ^classWork, StructColorInfo *structWork){
                    structWork->ColorCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ColorCode).ToPointer());
                    structWork->ColorName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ColorName).ToPointer());
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelSubCode = classWork->ModelSubCode;
                    structWork->SelectionState = classWork->SelectionState;
                }

                void CopyClassToStruct_TrimInfo(Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo ^classWork, StructTrimInfo *structWork){
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelSubCode = classWork->ModelSubCode;
                    structWork->TrimCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TrimCode).ToPointer());
                    structWork->TrimName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TrimName).ToPointer());
                    structWork->SelectionState = classWork->SelectionState;
                }

                void CopyClassToStruct_CEqpDefDspInfo(Broadleaf::Application::Controller::SalesSlipInputAcs::CEqpDefDspInfo ^classWork, StructCEqpDefDspInfo *structWork){
                    structWork->EquipmentCode = classWork->EquipmentCode;
                    structWork->EquipmentDispOrder = classWork->EquipmentDispOrder;
                    structWork->EquipmentGenreCd = classWork->EquipmentGenreCd;
                    structWork->EquipmentGenreNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EquipmentGenreNm).ToPointer());
                    structWork->EquipmentIconCode = classWork->EquipmentIconCode;
                    structWork->EquipmentName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EquipmentName).ToPointer());
                    structWork->EquipmentShortName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EquipmentShortName).ToPointer());
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelSubCode = classWork->ModelSubCode;
                    structWork->SelectionState = classWork->SelectionState;
                    structWork->SystematicCode = classWork->SystematicCode;
                }

                void CopyClassToStruct_CarSpecInfo(Broadleaf::Application::Controller::SalesSlipInputAcs::CarSpecInfo ^classWork, StructCarSpecInfo *structWork){
                    structWork->ModelGradeNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelGradeNm).ToPointer());
                    structWork->BodyName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BodyName).ToPointer());
                    structWork->DoorCount = classWork->DoorCount;
                    structWork->EDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EDivNm).ToPointer());
                    structWork->EngineDisplaceNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineDisplaceNm).ToPointer());
                    structWork->EngineModelNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineModelNm).ToPointer());
                    structWork->ShiftNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ShiftNm).ToPointer());
                    structWork->TransmissionNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TransmissionNm).ToPointer());
                    structWork->WheelDriveMethodNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->WheelDriveMethodNm).ToPointer());
                    structWork->AddiCarSpec1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec1).ToPointer());
                    structWork->AddiCarSpec2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec2).ToPointer());
                    structWork->AddiCarSpec3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec3).ToPointer());
                    structWork->AddiCarSpec4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec4).ToPointer());
                    structWork->AddiCarSpec5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec5).ToPointer());
                    structWork->AddiCarSpec6 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec6).ToPointer());
                }

                void CopyClassToStruct_CarInfo(Broadleaf::Application::Controller::SalesSlipInputAcs::CarInfo ^classWork, StructCarInfo *structWork){
                    structWork->CarRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarRelationGuid).ToPointer());
                    structWork->CustomerCode = classWork->CustomerCode;
                    structWork->CarMngNo = classWork->CarMngNo;
                    structWork->CarMngCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarMngCode).ToPointer());
                    structWork->NumberPlate1Code = classWork->NumberPlate1Code;
                    structWork->NumberPlate1Name = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlate1Name).ToPointer());
                    structWork->NumberPlate2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlate2).ToPointer());
                    structWork->NumberPlate3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlate3).ToPointer());
                    structWork->NumberPlate4 = classWork->NumberPlate4;
					structWork->EntryDate = classWork->EntryDate.Ticks;
                    structWork->FirstEntryDate = classWork->FirstEntryDate;
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->MakerFullName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MakerFullName).ToPointer());
                    structWork->MakerHalfName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MakerHalfName).ToPointer());
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelSubCode = classWork->ModelSubCode;
                    structWork->ModelFullName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelFullName).ToPointer());
                    structWork->ModelHalfName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelHalfName).ToPointer());
                    structWork->SystematicCode = classWork->SystematicCode;
                    structWork->SystematicName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SystematicName).ToPointer());
                    structWork->ProduceTypeOfYearCd = classWork->ProduceTypeOfYearCd;
                    structWork->ProduceTypeOfYearNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ProduceTypeOfYearNm).ToPointer());
                    structWork->StProduceTypeOfYear = classWork->StProduceTypeOfYear.Ticks;
                    structWork->EdProduceTypeOfYear = classWork->EdProduceTypeOfYear.Ticks;
                    structWork->DoorCount = classWork->DoorCount;
                    structWork->BodyNameCode = classWork->BodyNameCode;
                    structWork->BodyName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BodyName).ToPointer());
                    structWork->ExhaustGasSign = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ExhaustGasSign).ToPointer());
                    structWork->SeriesModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SeriesModel).ToPointer());
                    structWork->CategorySignModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CategorySignModel).ToPointer());
                    structWork->FullModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FullModel).ToPointer());
                    structWork->ModelDesignationNo = classWork->ModelDesignationNo;
                    structWork->CategoryNo = classWork->CategoryNo;
                    structWork->FrameModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FrameModel).ToPointer());
                    structWork->FrameNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FrameNo).ToPointer());
                    structWork->SearchFrameNo = classWork->SearchFrameNo;
                    structWork->StProduceFrameNo = classWork->StProduceFrameNo;
                    structWork->EdProduceFrameNo = classWork->EdProduceFrameNo;
                    structWork->ModelGradeNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelGradeNm).ToPointer());
                    structWork->EngineModelNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineModelNm).ToPointer());
                    structWork->EngineDisplaceNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineDisplaceNm).ToPointer());
                    structWork->EDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EDivNm).ToPointer());
                    structWork->TransmissionNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TransmissionNm).ToPointer());
                    structWork->ShiftNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ShiftNm).ToPointer());
                    structWork->WheelDriveMethodNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->WheelDriveMethodNm).ToPointer());
                    structWork->AddiCarSpec1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec1).ToPointer());
                    structWork->AddiCarSpec2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec2).ToPointer());
                    structWork->AddiCarSpec3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec3).ToPointer());
                    structWork->AddiCarSpec4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec4).ToPointer());
                    structWork->AddiCarSpec5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec5).ToPointer());
                    structWork->AddiCarSpec6 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec6).ToPointer());
                    structWork->AddiCarSpecTitle1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle1).ToPointer());
                    structWork->AddiCarSpecTitle2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle2).ToPointer());
                    structWork->AddiCarSpecTitle3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle3).ToPointer());
                    structWork->AddiCarSpecTitle4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle4).ToPointer());
                    structWork->AddiCarSpecTitle5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle5).ToPointer());
                    structWork->AddiCarSpecTitle6 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle6).ToPointer());
                    structWork->RelevanceModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RelevanceModel).ToPointer());
                    structWork->SubCarNmCd = classWork->SubCarNmCd;
                    structWork->ModelGradeSname = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelGradeSname).ToPointer());
                    structWork->BlockIllustrationCd = classWork->BlockIllustrationCd;
                    structWork->ThreeDIllustNo = classWork->ThreeDIllustNo;
                    structWork->PartsDataOfferFlag = classWork->PartsDataOfferFlag;
                    structWork->InspectMaturityDate = classWork->InspectMaturityDate.Ticks;
                    structWork->LTimeCiMatDate = classWork->LTimeCiMatDate.Ticks;
                    structWork->CarInspectYear = classWork->CarInspectYear;
                    structWork->Mileage = classWork->Mileage;
                    structWork->CarNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarNo).ToPointer());
                    //structWork->FullModelFixedNoAry = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FullModelFixedNoAry).ToPointer());
                    //structWork->CategoryObjAry = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CategoryObjAry).ToPointer());
                    structWork->ProduceTypeOfYearInput = classWork->ProduceTypeOfYearInput;
                    structWork->ColorCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ColorCode).ToPointer());
                    structWork->ColorName1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ColorName1).ToPointer());
                    structWork->TrimCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TrimCode).ToPointer());
                    structWork->TrimName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TrimName).ToPointer());
                    structWork->AcceptAnOrderNo = classWork->AcceptAnOrderNo;
                    structWork->CarNote = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarNote).ToPointer());
                    structWork->CarAddInfo1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarAddInfo1).ToPointer());
                    structWork->CarAddInfo2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarAddInfo2).ToPointer());
                    structWork->EngineModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineModel).ToPointer());
                    structWork->ProduceTypeOfYearRange = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ProduceTypeOfYearRange).ToPointer());
                    structWork->ProduceFrameNoRange = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ProduceFrameNoRange).ToPointer());
                    structWork->DomesticForeignCode = classWork->DomesticForeignCode; // ADD 2013/03/21
                    structWork->CarNoteCode = classWork->CarNoteCode; // ADD 2014/05/19 T.Miyamoto 仕掛一覧_№2218
                }

                void CopyClassToStruct_CarModel(CarModel ^classWork, StructCarModel structWork){
                    structWork.CategorySign = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CategorySign).ToPointer());
                    structWork.ExhaustGasSign = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ExhaustGasSign).ToPointer());
                    structWork.FullModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FullModel).ToPointer());
                    structWork.IsFullModel = classWork->IsFullModel;
                    structWork.SeriesModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SeriesModel).ToPointer());
                }

                void CopyClassToStruct_EngineModel(EngineModel ^classWork, StructEngineModel structWork){
                    structWork.FullModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FullModel).ToPointer());
                    structWork.Model = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Model).ToPointer());
                    structWork.ModelNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelNm).ToPointer());
                }

                void CopyClassToStruct_CarSearchCondition(CarSearchCondition ^classWork, StructCarSearchCondition *structWork){
                    //structWork->CarModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarModel).ToPointer());
					CopyClassToStruct_CarModel(classWork->CarModel, structWork->CarModel);
                    structWork->CategoryNo = classWork->CategoryNo;
                    //structWork->EngineModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineModel).ToPointer());
					CopyClassToStruct_EngineModel(classWork->EngineModel, structWork->EngineModel);
                    structWork->EraNameDispCd1 = classWork->EraNameDispCd1;
                    structWork->IsReady = classWork->IsReady;
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelDesignationNo = classWork->ModelDesignationNo;
                    structWork->ModelPlate = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelPlate).ToPointer());
                    structWork->ModelSubCode = classWork->ModelSubCode;
                }

                void CopyClassToStruct_CustomArrayB4(ArrayList^ arrayWork, StructCustomArrayB4 *structWork){
                    if (arrayWork->Count > 0){
                        StructCEqpDefDspInfo* csafield1 = new StructCEqpDefDspInfo[arrayWork->Count];
                        for (int i = 0; i < arrayWork->Count; i++){
                            CopyClassToStruct_CEqpDefDspInfo((Broadleaf::Application::Controller::SalesSlipInputAcs::CEqpDefDspInfo^)arrayWork[i], &csafield1[i]);
                        }
                        structWork->Csafield1 = csafield1;
                        structWork->Csafield1Count = arrayWork->Count - 0;
                    } else {
                        structWork->Csafield1 = nullptr;
                        structWork->Csafield1Count = 0;
                    }
                }

                void CopyClassToStruct_CustomArrayB3(ArrayList^ arrayWork, StructCustomArrayB3 *structWork){
                    if (arrayWork->Count > 0){
                        StructTrimInfo* csafield1 = new StructTrimInfo[arrayWork->Count];
                        for (int i = 0; i < arrayWork->Count; i++){
                            CopyClassToStruct_TrimInfo((Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo^)arrayWork[i], &csafield1[i]);
                        }
                        structWork->Csafield1 = csafield1;
                        structWork->Csafield1Count = arrayWork->Count - 0;
                    } else {
                        structWork->Csafield1 = nullptr;
                        structWork->Csafield1Count = 0;
                    }
                }

                void CopyClassToStruct_CustomArrayB2(ArrayList^ arrayWork, StructCustomArrayB2 *structWork){
                    if (arrayWork->Count > 0){
                        StructColorInfo* csafield1 = new StructColorInfo[arrayWork->Count];
                        for (int i = 0; i < arrayWork->Count; i++){
                            CopyClassToStruct_ColorInfo((Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo^)arrayWork[i], &csafield1[i]);
                        }
                        structWork->Csafield1 = csafield1;
                        structWork->Csafield1Count = arrayWork->Count - 0;
                    } else {
                        structWork->Csafield1 = nullptr;
                        structWork->Csafield1Count = 0;
                    }
                }

				// C++メモリ開放処理

               __declspec(dllexport) void __stdcall FreeSalesSlipSearchResult(StructSalesSlipSearchResult *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesSlipNum));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeColorInfo(StructColorInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].ColorCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ColorName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SelectionState));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeTrimInfo(StructTrimInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].TrimCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TrimName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SelectionState));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCEqpDefDspInfo(StructCEqpDefDspInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].EquipmentGenreNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EquipmentName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EquipmentShortName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SelectionState));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCarSpecInfo(StructCarSpecInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelGradeNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BodyName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EDivNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineDisplaceNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineModelNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ShiftNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TransmissionNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].WheelDriveMethodNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec6));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCarInfo(StructCarInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].CarRelationGuid));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarMngCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlate1Name));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlate2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlate3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MakerFullName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MakerHalfName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelFullName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelHalfName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SystematicName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ProduceTypeOfYearNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BodyName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ExhaustGasSign));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SeriesModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CategorySignModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FullModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FrameModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FrameNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelGradeNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineModelNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineDisplaceNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EDivNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TransmissionNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ShiftNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].WheelDriveMethodNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec6));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle6));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RelevanceModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelGradeSname));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FullModelFixedNoAry));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CategoryObjAry));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ColorCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ColorName1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TrimCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TrimName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarNote));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarAddInfo1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarAddInfo2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ProduceTypeOfYearRange));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ProduceFrameNoRange));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarNoteCode)); // ADD 2014/05/19 T.Miyamoto 仕掛一覧_№2218
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCarModel(StructCarModel *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].CategorySign));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ExhaustGasSign));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FullModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].IsFullModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SeriesModel));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeEngineModel(StructEngineModel *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].FullModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Model));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelNm));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCarSearchCondition(StructCarSearchCondition *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        FreeCarModel(&(resultList[i].CarModel), resultCount);
                        FreeEngineModel(&(resultList[i].EngineModel), resultCount);
                        Marshal::FreeBSTR(IntPtr(resultList[i].IsReady));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelPlate));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCustomArrayB4(StructCustomArrayB4 *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){
                        FreeCEqpDefDspInfo(resultList[i].Csafield1, resultList[i].Csafield1Count);
                    }
                }

                __declspec(dllexport) void __stdcall FreeCustomArrayB3(StructCustomArrayB3 *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){
                        FreeTrimInfo(resultList[i].Csafield1, resultList[i].Csafield1Count);
                    }
                }

                __declspec(dllexport) void __stdcall FreeCustomArrayB2(StructCustomArrayB2 *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){
                        FreeColorInfo(resultList[i].Csafield1, resultList[i].Csafield1Count);
                    }
                }

				__declspec(dllexport) void __stdcall FreeMessage(BSTR message){
					if(message == NULL){
						return;
					}

					Marshal::FreeBSTR(IntPtr(message));
				}
				
				// add by gaofeng start
				// C++構造体→.NETクラスコピー処理

                void CopyStructToClass_CustomerSearchRet(StructCustomerSearchRet *structWork, CustomerSearchRet ^classWork){
                    classWork->AcceptWholeSale = structWork->AcceptWholeSale;
                    classWork->Address1 = gcnew String(structWork->Address1);
                    classWork->Address3 = gcnew String(structWork->Address3);
                    classWork->Address4 = gcnew String(structWork->Address4);
                    classWork->CustomerCode = structWork->CustomerCode;
                    classWork->CustomerEpCode = gcnew String(structWork->CustomerEpCode);
                    classWork->CustomerSecCode = gcnew String(structWork->CustomerSecCode);
                    classWork->CustomerSlipNoDiv = structWork->CustomerSlipNoDiv;
                    classWork->CustomerSubCode = gcnew String(structWork->CustomerSubCode);
                    classWork->EnterpriseCode = gcnew String(structWork->EnterpriseCode);
                    classWork->EnterpriseName = gcnew String(structWork->EnterpriseName);
                    classWork->HomeTelNo = gcnew String(structWork->HomeTelNo);
                    classWork->HonorificTitle = gcnew String(structWork->HonorificTitle);
                    classWork->Kana = gcnew String(structWork->Kana);
                    classWork->LogicalDeleteCode = structWork->LogicalDeleteCode;
                    classWork->MngSectionCode = gcnew String(structWork->MngSectionCode);
                    classWork->Name = gcnew String(structWork->Name);
                    classWork->Name2 = gcnew String(structWork->Name2);
                    classWork->OfficeTelNo = gcnew String(structWork->OfficeTelNo);
                    classWork->PortableTelNo = gcnew String(structWork->PortableTelNo);
                    classWork->PostNo = gcnew String(structWork->PostNo);
                    classWork->SearchTelNo = gcnew String(structWork->SearchTelNo);
                    classWork->Snm = gcnew String(structWork->Snm);
                    classWork->TotalDay = structWork->TotalDay;
					classWork->UpdateDate = DateTime(structWork->UpdateDate);
                }

				// .NETクラス→C++構造体コピー処理

                void CopyClassToStruct_CustomerSearchRet(CustomerSearchRet ^classWork, StructCustomerSearchRet *structWork){
                    structWork->AcceptWholeSale = classWork->AcceptWholeSale;
                    structWork->Address1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Address1).ToPointer());
                    structWork->Address3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Address3).ToPointer());
                    structWork->Address4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Address4).ToPointer());
                    structWork->CustomerCode = classWork->CustomerCode;
                    structWork->CustomerEpCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerEpCode).ToPointer());
                    structWork->CustomerSecCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerSecCode).ToPointer());
                    structWork->CustomerSlipNoDiv = classWork->CustomerSlipNoDiv;
                    structWork->CustomerSubCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerSubCode).ToPointer());
                    structWork->EnterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseCode).ToPointer());
                    structWork->EnterpriseName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseName).ToPointer());
                    structWork->HomeTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HomeTelNo).ToPointer());
                    structWork->HonorificTitle = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HonorificTitle).ToPointer());
                    structWork->Kana = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Kana).ToPointer());
                    structWork->LogicalDeleteCode = classWork->LogicalDeleteCode;
                    structWork->MngSectionCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MngSectionCode).ToPointer());
                    structWork->Name = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Name).ToPointer());
                    structWork->Name2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Name2).ToPointer());
                    structWork->OfficeTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OfficeTelNo).ToPointer());
                    structWork->PortableTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PortableTelNo).ToPointer());
                    structWork->PostNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PostNo).ToPointer());
                    structWork->SearchTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SearchTelNo).ToPointer());
                    structWork->Snm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Snm).ToPointer());
                    structWork->TotalDay = classWork->TotalDay;
					structWork->UpdateDate = classWork->UpdateDate.Ticks;
                }

				void CopyStructToClass_SalesSlip(StructSalesSlip *structWork, SalesSlip ^classWork){
                    classWork->AcptAnOdrStatus = structWork->AcptAnOdrStatus;
                    classWork->SalesSlipNum = gcnew String(structWork->SalesSlipNum);
                    classWork->SectionCode = gcnew String(structWork->SectionCode);
					classWork->InputMode = structWork->InputMode;
					classWork->SalesSlipDisplay = structWork->SalesSlipDisplay;
					classWork->AcptAnOdrStatusDisplay = structWork->AcptAnOdrStatusDisplay;
					classWork->CarMngDivCd = structWork->CarMngDivCd;
                    classWork->SubSectionCode = structWork->SubSectionCode;
					classWork->SubSectionName = gcnew String(structWork->SubSectionName);
                    classWork->DebitNoteDiv = structWork->DebitNoteDiv;
                    classWork->DebitNLnkSalesSlNum = gcnew String(structWork->DebitNLnkSalesSlNum);
                    classWork->SalesSlipCd = structWork->SalesSlipCd;
                    classWork->SalesGoodsCd = structWork->SalesGoodsCd;
                    classWork->AccRecDivCd = structWork->AccRecDivCd;
                    classWork->SalesInpSecCd = gcnew String(structWork->SalesInpSecCd);
                    classWork->DemandAddUpSecCd = gcnew String(structWork->DemandAddUpSecCd);
                    classWork->ResultsAddUpSecCd = gcnew String(structWork->ResultsAddUpSecCd);
					classWork->ResultsAddUpSecNm = gcnew String(structWork->ResultsAddUpSecNm);
                    classWork->UpdateSecCd = gcnew String(structWork->UpdateSecCd);
                    classWork->SalesSlipUpdateCd = structWork->SalesSlipUpdateCd;
					classWork->SearchSlipDate = DateTime(structWork->SearchSlipDate);
                    classWork->ShipmentDay = DateTime(structWork->ShipmentDay);
                    classWork->SalesDate = DateTime(structWork->SalesDate);
                    classWork->AddUpADate = DateTime(structWork->AddUpADate);
                    classWork->DelayPaymentDiv = structWork->DelayPaymentDiv;
                    classWork->EstimateFormNo = gcnew String(structWork->EstimateFormNo);
                    classWork->EstimateDivide = structWork->EstimateDivide;
                    classWork->InputAgenCd = gcnew String(structWork->InputAgenCd);
                    classWork->InputAgenNm = gcnew String(structWork->InputAgenNm);
                    classWork->SalesInputCode = gcnew String(structWork->SalesInputCode);
                    classWork->SalesInputName = gcnew String(structWork->SalesInputName);
                    classWork->FrontEmployeeCd = gcnew String(structWork->FrontEmployeeCd);
                    classWork->FrontEmployeeNm = gcnew String(structWork->FrontEmployeeNm);
                    classWork->SalesEmployeeCd = gcnew String(structWork->SalesEmployeeCd);
                    classWork->SalesEmployeeNm = gcnew String(structWork->SalesEmployeeNm);
                    classWork->TotalAmountDispWayCd = structWork->TotalAmountDispWayCd;
                    classWork->TtlAmntDispRateApy = structWork->TtlAmntDispRateApy;
                    classWork->SalesTotalTaxInc = structWork->SalesTotalTaxInc;
                    classWork->SalesTotalTaxExc = structWork->SalesTotalTaxExc;
                    classWork->SalesPrtTotalTaxInc = structWork->SalesPrtTotalTaxInc;
                    classWork->SalesPrtTotalTaxExc = structWork->SalesPrtTotalTaxExc;
                    classWork->SalesWorkTotalTaxInc = structWork->SalesWorkTotalTaxInc;
                    classWork->SalesWorkTotalTaxExc = structWork->SalesWorkTotalTaxExc;
                    classWork->SalesSubtotalTaxInc = structWork->SalesSubtotalTaxInc;
                    classWork->SalesSubtotalTaxExc = structWork->SalesSubtotalTaxExc;
                    classWork->SalesPrtSubttlInc = structWork->SalesPrtSubttlInc;
                    classWork->SalesPrtSubttlExc = structWork->SalesPrtSubttlExc;
                    classWork->SalesWorkSubttlInc = structWork->SalesWorkSubttlInc;
                    classWork->SalesWorkSubttlExc = structWork->SalesWorkSubttlExc;
                    classWork->SalesNetPrice = structWork->SalesNetPrice;
                    classWork->SalesSubtotalTax = structWork->SalesSubtotalTax;
                    classWork->ItdedSalesOutTax = structWork->ItdedSalesOutTax;
                    classWork->ItdedSalesInTax = structWork->ItdedSalesInTax;
                    classWork->SalSubttlSubToTaxFre = structWork->SalSubttlSubToTaxFre;
                    classWork->SalesOutTax = structWork->SalesOutTax;
                    classWork->SalAmntConsTaxInclu = structWork->SalAmntConsTaxInclu;
                    classWork->SalesDisTtlTaxExc = structWork->SalesDisTtlTaxExc;
                    classWork->ItdedSalesDisOutTax = structWork->ItdedSalesDisOutTax;
                    classWork->ItdedSalesDisInTax = structWork->ItdedSalesDisInTax;
                    classWork->ItdedPartsDisOutTax = structWork->ItdedPartsDisOutTax;
                    classWork->ItdedPartsDisInTax = structWork->ItdedPartsDisInTax;
                    classWork->ItdedWorkDisOutTax = structWork->ItdedWorkDisOutTax;
                    classWork->ItdedWorkDisInTax = structWork->ItdedWorkDisInTax;
                    classWork->ItdedSalesDisTaxFre = structWork->ItdedSalesDisTaxFre;
                    classWork->SalesDisOutTax = structWork->SalesDisOutTax;
                    classWork->SalesDisTtlTaxInclu = structWork->SalesDisTtlTaxInclu;
                    classWork->PartsDiscountRate = structWork->PartsDiscountRate;
                    classWork->RavorDiscountRate = structWork->RavorDiscountRate;
                    classWork->TotalCost = structWork->TotalCost;
                    classWork->ConsTaxLayMethod = structWork->ConsTaxLayMethod;
                    classWork->ConsTaxRate = structWork->ConsTaxRate;
                    classWork->FractionProcCd = structWork->FractionProcCd;
                    classWork->AccRecConsTax = structWork->AccRecConsTax;
                    classWork->AutoDepositCd = structWork->AutoDepositCd;
                    classWork->AutoDepositSlipNo = structWork->AutoDepositSlipNo;
                    classWork->DepositAllowanceTtl = structWork->DepositAllowanceTtl;
                    classWork->DepositAlwcBlnce = structWork->DepositAlwcBlnce;
                    classWork->ClaimCode = structWork->ClaimCode;
                    classWork->ClaimSnm = gcnew String(structWork->ClaimSnm);
                    classWork->CustomerCode = structWork->CustomerCode;
                    classWork->CustomerName = gcnew String(structWork->CustomerName);
                    classWork->CustomerName2 = gcnew String(structWork->CustomerName2);
                    classWork->CustomerSnm = gcnew String(structWork->CustomerSnm);
                    classWork->HonorificTitle = gcnew String(structWork->HonorificTitle);
                    classWork->OutputNameCode = structWork->OutputNameCode;
                    classWork->OutputName = gcnew String(structWork->OutputName);
                    classWork->CustSlipNo = structWork->CustSlipNo;
                    classWork->SlipAddressDiv = structWork->SlipAddressDiv;
                    classWork->AddresseeCode = structWork->AddresseeCode;
                    classWork->AddresseeName = gcnew String(structWork->AddresseeName);
                    classWork->AddresseeName2 = gcnew String(structWork->AddresseeName2);
                    classWork->AddresseePostNo = gcnew String(structWork->AddresseePostNo);
                    classWork->AddresseeAddr1 = gcnew String(structWork->AddresseeAddr1);
                    classWork->AddresseeAddr3 = gcnew String(structWork->AddresseeAddr3);
                    classWork->AddresseeAddr4 = gcnew String(structWork->AddresseeAddr4);
                    classWork->AddresseeTelNo = gcnew String(structWork->AddresseeTelNo);
                    classWork->AddresseeFaxNo = gcnew String(structWork->AddresseeFaxNo);
                    classWork->PartySaleSlipNum = gcnew String(structWork->PartySaleSlipNum);
                    classWork->SlipNote = gcnew String(structWork->SlipNote);
                    classWork->SlipNote2 = gcnew String(structWork->SlipNote2);
                    classWork->SlipNote3 = gcnew String(structWork->SlipNote3);
					classWork->SlipNoteCode = structWork->SlipNoteCode;
					classWork->SlipNote2Code = structWork->SlipNote2Code;
					classWork->SlipNote3Code = structWork->SlipNote3Code;
                    classWork->RetGoodsReasonDiv = structWork->RetGoodsReasonDiv;
                    classWork->RetGoodsReason = gcnew String(structWork->RetGoodsReason);
                    classWork->RegiProcDate = DateTime(structWork->RegiProcDate);
                    classWork->CashRegisterNo = structWork->CashRegisterNo;
                    classWork->PosReceiptNo = structWork->PosReceiptNo;
                    classWork->DetailRowCount = structWork->DetailRowCount;
                    classWork->EdiSendDate = DateTime(structWork->EdiSendDate);
                    classWork->EdiTakeInDate = DateTime(structWork->EdiTakeInDate);
                    classWork->UoeRemark1 = gcnew String(structWork->UoeRemark1);
                    classWork->UoeRemark2 = gcnew String(structWork->UoeRemark2);
                    classWork->SlipPrintDivCd = structWork->SlipPrintDivCd;
                    classWork->SlipPrintFinishCd = structWork->SlipPrintFinishCd;
                    classWork->SalesSlipPrintDate = DateTime(structWork->SalesSlipPrintDate);
                    classWork->BusinessTypeCode = structWork->BusinessTypeCode;
                    classWork->BusinessTypeName = gcnew String(structWork->BusinessTypeName);
                    classWork->OrderNumber = gcnew String(structWork->OrderNumber);
                    classWork->DeliveredGoodsDiv = structWork->DeliveredGoodsDiv;
                    classWork->DeliveredGoodsDivNm = gcnew String(structWork->DeliveredGoodsDivNm);
                    classWork->SalesAreaCode = structWork->SalesAreaCode;
                    classWork->SalesAreaName = gcnew String(structWork->SalesAreaName);
                    classWork->ReconcileFlag = structWork->ReconcileFlag;
                    classWork->SlipPrtSetPaperId = gcnew String(structWork->SlipPrtSetPaperId);
                    classWork->CompleteCd = structWork->CompleteCd;
                    classWork->SalesPriceFracProcCd = structWork->SalesPriceFracProcCd;
                    classWork->StockGoodsTtlTaxExc = structWork->StockGoodsTtlTaxExc;
                    classWork->PureGoodsTtlTaxExc = structWork->PureGoodsTtlTaxExc;
                    classWork->ListPricePrintDiv = structWork->ListPricePrintDiv;
                    classWork->EraNameDispCd1 = structWork->EraNameDispCd1;
                    classWork->EstimaTaxDivCd = structWork->EstimaTaxDivCd;
                    classWork->EstimateFormPrtCd = structWork->EstimateFormPrtCd;
                    classWork->EstimateSubject = gcnew String(structWork->EstimateSubject);
                    classWork->Footnotes1 = gcnew String(structWork->Footnotes1);
                    classWork->Footnotes2 = gcnew String(structWork->Footnotes2);
                    classWork->EstimateTitle1 = gcnew String(structWork->EstimateTitle1);
                    classWork->EstimateTitle2 = gcnew String(structWork->EstimateTitle2);
                    classWork->EstimateTitle3 = gcnew String(structWork->EstimateTitle3);
                    classWork->EstimateTitle4 = gcnew String(structWork->EstimateTitle4);
                    classWork->EstimateTitle5 = gcnew String(structWork->EstimateTitle5);
                    classWork->EstimateNote1 = gcnew String(structWork->EstimateNote1);
                    classWork->EstimateNote2 = gcnew String(structWork->EstimateNote2);
                    classWork->EstimateNote3 = gcnew String(structWork->EstimateNote3);
                    classWork->EstimateNote4 = gcnew String(structWork->EstimateNote4);
                    classWork->EstimateNote5 = gcnew String(structWork->EstimateNote5);
                    classWork->EstimateValidityDate = DateTime(structWork->EstimateValidityDate);
                    classWork->PartsNoPrtCd = structWork->PartsNoPrtCd;
                    classWork->OptionPringDivCd = structWork->OptionPringDivCd;
                    classWork->RateUseCode = structWork->RateUseCode;
                    classWork->CreateDateTime = DateTime(structWork->CreateDateTime);
                    classWork->UpdateDateTime = DateTime(structWork->UpdateDateTime);
                    classWork->EnterpriseCode = gcnew String(structWork->EnterpriseCode);
                    array<Byte> ^FileHeaderGuidByteArray = gcnew array<Byte>(16);
                    Marshal::Copy(IntPtr(&structWork->FileHeaderGuid), FileHeaderGuidByteArray, 0, 16);
                    classWork->FileHeaderGuid = Guid(FileHeaderGuidByteArray);
                    classWork->UpdEmployeeCode = gcnew String(structWork->UpdEmployeeCode);
                    classWork->UpdAssemblyId1 = gcnew String(structWork->UpdAssemblyId1);
                    classWork->UpdAssemblyId2 = gcnew String(structWork->UpdAssemblyId2);
					classWork->CustOrderNoDispDiv = structWork->CustOrderNoDispDiv;
					classWork->CustWarehouseCd = gcnew String(structWork->CustWarehouseCd);
					classWork->CreditMngCode = structWork->CreditMngCode;
					classWork->DetailRowCountForReadSlip = structWork->DetailRowCountForReadSlip;
					//>>>2010/05/30
					classWork->OnlineKindDiv = structWork->OnlineKindDiv;
					classWork->InqOriginalEpCd = gcnew String(structWork->InqOriginalEpCd);
					classWork->InqOriginalSecCd = gcnew String(structWork->InqOriginalSecCd);
			        classWork->AnswerDiv = structWork->AnswerDiv;
					classWork->InquiryNumber = structWork->InquiryNumber;
					classWork->InqOrdDivCd = structWork->InqOrdDivCd;
					//<<<2010/05/30
					classWork->AutoAnswerDivSCM = structWork->AutoAnswerDivSCM;//add 2011/07/18 朱宝軍
					classWork->PreSalesDate = DateTime(structWork->PreSalesDate);//ADD 鄧潘ハン 2012/03/12 Redmine#28288
                }

				// .NETクラス→C++構造体コピー処理

                void CopyClassToStruct_SalesSlip(SalesSlip ^classWork, StructSalesSlip *structWork){
                    structWork->AcptAnOdrStatus = classWork->AcptAnOdrStatus;
                    structWork->SalesSlipNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesSlipNum).ToPointer());
                    structWork->SectionCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SectionCode).ToPointer());
					structWork->InputMode = classWork->InputMode;
					structWork->SalesSlipDisplay = classWork->SalesSlipDisplay;
					structWork->AcptAnOdrStatusDisplay = classWork->AcptAnOdrStatusDisplay;
					structWork->CarMngDivCd = classWork->CarMngDivCd;
					structWork->SubSectionCode = classWork->SubSectionCode;
                    structWork->SubSectionName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SubSectionName).ToPointer());
                    structWork->DebitNoteDiv = classWork->DebitNoteDiv;
                    structWork->DebitNLnkSalesSlNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DebitNLnkSalesSlNum).ToPointer());
                    structWork->SalesSlipCd = classWork->SalesSlipCd;
                    structWork->SalesGoodsCd = classWork->SalesGoodsCd;
                    structWork->AccRecDivCd = classWork->AccRecDivCd;
                    structWork->SalesInpSecCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesInpSecCd).ToPointer());
                    structWork->DemandAddUpSecCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DemandAddUpSecCd).ToPointer());
                    structWork->ResultsAddUpSecCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ResultsAddUpSecCd).ToPointer());
					structWork->ResultsAddUpSecNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ResultsAddUpSecNm).ToPointer());
                    structWork->UpdateSecCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateSecCd).ToPointer());
                    structWork->SalesSlipUpdateCd = classWork->SalesSlipUpdateCd;
					structWork->SearchSlipDate = classWork->SearchSlipDate.Ticks;
                    structWork->ShipmentDay = classWork->ShipmentDay.Ticks;
                    structWork->SalesDate = classWork->SalesDate.Ticks;
                    structWork->AddUpADate = classWork->AddUpADate.Ticks;
                    structWork->DelayPaymentDiv = classWork->DelayPaymentDiv;
                    structWork->EstimateFormNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateFormNo).ToPointer());
                    structWork->EstimateDivide = classWork->EstimateDivide;
                    structWork->InputAgenCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InputAgenCd).ToPointer());
                    structWork->InputAgenNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InputAgenNm).ToPointer());
                    structWork->SalesInputCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesInputCode).ToPointer());
                    structWork->SalesInputName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesInputName).ToPointer());
                    structWork->FrontEmployeeCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FrontEmployeeCd).ToPointer());
                    structWork->FrontEmployeeNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FrontEmployeeNm).ToPointer());
                    structWork->SalesEmployeeCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesEmployeeCd).ToPointer());
                    structWork->SalesEmployeeNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesEmployeeNm).ToPointer());
                    structWork->TotalAmountDispWayCd = classWork->TotalAmountDispWayCd;
                    structWork->TtlAmntDispRateApy = classWork->TtlAmntDispRateApy;
                    structWork->SalesTotalTaxInc = classWork->SalesTotalTaxInc;
                    structWork->SalesTotalTaxExc = classWork->SalesTotalTaxExc;
                    structWork->SalesPrtTotalTaxInc = classWork->SalesPrtTotalTaxInc;
                    structWork->SalesPrtTotalTaxExc = classWork->SalesPrtTotalTaxExc;
                    structWork->SalesWorkTotalTaxInc = classWork->SalesWorkTotalTaxInc;
                    structWork->SalesWorkTotalTaxExc = classWork->SalesWorkTotalTaxExc;
                    structWork->SalesSubtotalTaxInc = classWork->SalesSubtotalTaxInc;
                    structWork->SalesSubtotalTaxExc = classWork->SalesSubtotalTaxExc;
                    structWork->SalesPrtSubttlInc = classWork->SalesPrtSubttlInc;
                    structWork->SalesPrtSubttlExc = classWork->SalesPrtSubttlExc;
                    structWork->SalesWorkSubttlInc = classWork->SalesWorkSubttlInc;
                    structWork->SalesWorkSubttlExc = classWork->SalesWorkSubttlExc;
                    structWork->SalesNetPrice = classWork->SalesNetPrice;
                    structWork->SalesSubtotalTax = classWork->SalesSubtotalTax;
                    structWork->ItdedSalesOutTax = classWork->ItdedSalesOutTax;
                    structWork->ItdedSalesInTax = classWork->ItdedSalesInTax;
                    structWork->SalSubttlSubToTaxFre = classWork->SalSubttlSubToTaxFre;
                    structWork->SalesOutTax = classWork->SalesOutTax;
                    structWork->SalAmntConsTaxInclu = classWork->SalAmntConsTaxInclu;
                    structWork->SalesDisTtlTaxExc = classWork->SalesDisTtlTaxExc;
                    structWork->ItdedSalesDisOutTax = classWork->ItdedSalesDisOutTax;
                    structWork->ItdedSalesDisInTax = classWork->ItdedSalesDisInTax;
                    structWork->ItdedPartsDisOutTax = classWork->ItdedPartsDisOutTax;
                    structWork->ItdedPartsDisInTax = classWork->ItdedPartsDisInTax;
                    structWork->ItdedWorkDisOutTax = classWork->ItdedWorkDisOutTax;
                    structWork->ItdedWorkDisInTax = classWork->ItdedWorkDisInTax;
                    structWork->ItdedSalesDisTaxFre = classWork->ItdedSalesDisTaxFre;
                    structWork->SalesDisOutTax = classWork->SalesDisOutTax;
                    structWork->SalesDisTtlTaxInclu = classWork->SalesDisTtlTaxInclu;
                    structWork->PartsDiscountRate = classWork->PartsDiscountRate;
                    structWork->RavorDiscountRate = classWork->RavorDiscountRate;
                    structWork->TotalCost = classWork->TotalCost;
                    structWork->ConsTaxLayMethod = classWork->ConsTaxLayMethod;
                    structWork->ConsTaxRate = classWork->ConsTaxRate;
                    structWork->FractionProcCd = classWork->FractionProcCd;
                    structWork->AccRecConsTax = classWork->AccRecConsTax;
                    structWork->AutoDepositCd = classWork->AutoDepositCd;
                    structWork->AutoDepositSlipNo = classWork->AutoDepositSlipNo;
                    structWork->DepositAllowanceTtl = classWork->DepositAllowanceTtl;
                    structWork->DepositAlwcBlnce = classWork->DepositAlwcBlnce;
                    structWork->ClaimCode = classWork->ClaimCode;
                    structWork->ClaimSnm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ClaimSnm).ToPointer());
                    structWork->CustomerCode = classWork->CustomerCode;
                    structWork->CustomerName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerName).ToPointer());
                    structWork->CustomerName2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerName2).ToPointer());
                    structWork->CustomerSnm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerSnm).ToPointer());
                    structWork->HonorificTitle = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HonorificTitle).ToPointer());
                    structWork->OutputNameCode = classWork->OutputNameCode;
                    structWork->OutputName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OutputName).ToPointer());
                    structWork->CustSlipNo = classWork->CustSlipNo;
                    structWork->SlipAddressDiv = classWork->SlipAddressDiv;
                    structWork->AddresseeCode = classWork->AddresseeCode;
                    structWork->AddresseeName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeName).ToPointer());
                    structWork->AddresseeName2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeName2).ToPointer());
                    structWork->AddresseePostNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseePostNo).ToPointer());
                    structWork->AddresseeAddr1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeAddr1).ToPointer());
                    structWork->AddresseeAddr3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeAddr3).ToPointer());
                    structWork->AddresseeAddr4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeAddr4).ToPointer());
                    structWork->AddresseeTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeTelNo).ToPointer());
                    structWork->AddresseeFaxNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddresseeFaxNo).ToPointer());
                    structWork->PartySaleSlipNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PartySaleSlipNum).ToPointer());
                    structWork->SlipNote = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipNote).ToPointer());
                    structWork->SlipNote2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipNote2).ToPointer());
                    structWork->SlipNote3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipNote3).ToPointer());
					structWork->SlipNoteCode = classWork->SlipNoteCode;
					structWork->SlipNote2Code = classWork->SlipNote2Code;
					structWork->SlipNote3Code = classWork->SlipNote3Code;
                    structWork->RetGoodsReasonDiv = classWork->RetGoodsReasonDiv;
                    structWork->RetGoodsReason = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RetGoodsReason).ToPointer());
                    structWork->RegiProcDate = classWork->RegiProcDate.Ticks;
                    structWork->CashRegisterNo = classWork->CashRegisterNo;
                    structWork->PosReceiptNo = classWork->PosReceiptNo;
                    structWork->DetailRowCount = classWork->DetailRowCount;
                    structWork->EdiSendDate = classWork->EdiSendDate.Ticks;
                    structWork->EdiTakeInDate = classWork->EdiTakeInDate.Ticks;
                    structWork->UoeRemark1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UoeRemark1).ToPointer());
                    structWork->UoeRemark2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UoeRemark2).ToPointer());
                    structWork->SlipPrintDivCd = classWork->SlipPrintDivCd;
                    structWork->SlipPrintFinishCd = classWork->SlipPrintFinishCd;
                    structWork->SalesSlipPrintDate = classWork->SalesSlipPrintDate.Ticks;
                    structWork->BusinessTypeCode = classWork->BusinessTypeCode;
                    structWork->BusinessTypeName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BusinessTypeName).ToPointer());
                    structWork->OrderNumber = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OrderNumber).ToPointer());
                    structWork->DeliveredGoodsDiv = classWork->DeliveredGoodsDiv;
                    structWork->DeliveredGoodsDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DeliveredGoodsDivNm).ToPointer());
                    structWork->SalesAreaCode = classWork->SalesAreaCode;
                    structWork->SalesAreaName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesAreaName).ToPointer());
                    structWork->ReconcileFlag = classWork->ReconcileFlag;
                    structWork->SlipPrtSetPaperId = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipPrtSetPaperId).ToPointer());
                    structWork->CompleteCd = classWork->CompleteCd;
                    structWork->SalesPriceFracProcCd = classWork->SalesPriceFracProcCd;
                    structWork->StockGoodsTtlTaxExc = classWork->StockGoodsTtlTaxExc;
                    structWork->PureGoodsTtlTaxExc = classWork->PureGoodsTtlTaxExc;
                    structWork->ListPricePrintDiv = classWork->ListPricePrintDiv;
                    structWork->EraNameDispCd1 = classWork->EraNameDispCd1;
                    structWork->EstimaTaxDivCd = classWork->EstimaTaxDivCd;
                    structWork->EstimateFormPrtCd = classWork->EstimateFormPrtCd;
                    structWork->EstimateSubject = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateSubject).ToPointer());
                    structWork->Footnotes1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Footnotes1).ToPointer());
                    structWork->Footnotes2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Footnotes2).ToPointer());
                    structWork->EstimateTitle1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateTitle1).ToPointer());
                    structWork->EstimateTitle2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateTitle2).ToPointer());
                    structWork->EstimateTitle3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateTitle3).ToPointer());
                    structWork->EstimateTitle4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateTitle4).ToPointer());
                    structWork->EstimateTitle5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateTitle5).ToPointer());
                    structWork->EstimateNote1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateNote1).ToPointer());
                    structWork->EstimateNote2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateNote2).ToPointer());
                    structWork->EstimateNote3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateNote3).ToPointer());
                    structWork->EstimateNote4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateNote4).ToPointer());
                    structWork->EstimateNote5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstimateNote5).ToPointer());
                    structWork->EstimateValidityDate = classWork->EstimateValidityDate.Ticks;
                    structWork->PartsNoPrtCd = classWork->PartsNoPrtCd;
                    structWork->OptionPringDivCd = classWork->OptionPringDivCd;
                    structWork->RateUseCode = classWork->RateUseCode;
                    structWork->CreateDateTime = classWork->CreateDateTime.Ticks;
                    structWork->UpdateDateTime = classWork->UpdateDateTime.Ticks;
                    structWork->EnterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseCode).ToPointer());
                    Marshal::Copy(classWork->FileHeaderGuid.ToByteArray(), 0, IntPtr(&structWork->FileHeaderGuid), 16);
                    structWork->UpdEmployeeCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdEmployeeCode).ToPointer());
                    structWork->UpdAssemblyId1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdAssemblyId1).ToPointer());
                    structWork->UpdAssemblyId2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdAssemblyId2).ToPointer());
					structWork->CustOrderNoDispDiv = classWork->CustOrderNoDispDiv;
					structWork->CustWarehouseCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustWarehouseCd).ToPointer());
					structWork->CreditMngCode = classWork->CreditMngCode;
					structWork->DetailRowCountForReadSlip = classWork->DetailRowCountForReadSlip;
					//>>>2010/05/30
					structWork->OnlineKindDiv = classWork->OnlineKindDiv;
					structWork->InqOriginalEpCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InqOriginalEpCd).ToPointer());
					structWork->InqOriginalSecCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InqOriginalSecCd).ToPointer());
			        structWork->AnswerDiv = classWork->AnswerDiv;
					structWork->InquiryNumber = classWork->InquiryNumber;
					structWork->InqOrdDivCd = classWork->InqOrdDivCd;
					//<<<2010/05/30
					structWork->AutoAnswerDivSCM = classWork->AutoAnswerDivSCM;// add 2011/07/18 朱宝軍
				    structWork->PreSalesDate = classWork->PreSalesDate.Ticks;//ADD 鄧潘ハン 2012/03/12 Redmine#28288
                }

				void CopyStructToClass_CarMangInputExtraInfo(StructCarMangInputExtraInfo *structWork, Broadleaf::Application::UIData::CarMangInputExtraInfo ^classWork){
                    classWork->AddiCarSpec1 = gcnew String(structWork->AddiCarSpec1);
                    classWork->AddiCarSpec2 = gcnew String(structWork->AddiCarSpec2);
                    classWork->AddiCarSpec3 = gcnew String(structWork->AddiCarSpec3);
                    classWork->AddiCarSpec4 = gcnew String(structWork->AddiCarSpec4);
                    classWork->AddiCarSpec5 = gcnew String(structWork->AddiCarSpec5);
                    classWork->AddiCarSpec6 = gcnew String(structWork->AddiCarSpec6);
                    classWork->AddiCarSpecTitle1 = gcnew String(structWork->AddiCarSpecTitle1);
                    classWork->AddiCarSpecTitle2 = gcnew String(structWork->AddiCarSpecTitle2);
                    classWork->AddiCarSpecTitle3 = gcnew String(structWork->AddiCarSpecTitle3);
                    classWork->AddiCarSpecTitle4 = gcnew String(structWork->AddiCarSpecTitle4);
                    classWork->AddiCarSpecTitle5 = gcnew String(structWork->AddiCarSpecTitle5);
                    classWork->AddiCarSpecTitle6 = gcnew String(structWork->AddiCarSpecTitle6);
                    classWork->BlockIllustrationCd = structWork->BlockIllustrationCd;
                    classWork->BodyName = gcnew String(structWork->BodyName);
                    classWork->BodyNameCode = structWork->BodyNameCode;
                    classWork->CarAddInfo1 = gcnew String(structWork->CarAddInfo1);
                    classWork->CarAddInfo2 = gcnew String(structWork->CarAddInfo2);
                    classWork->CarInspectYear = structWork->CarInspectYear;
                    classWork->CarMngCode = gcnew String(structWork->CarMngCode);
                    classWork->CarMngNo = structWork->CarMngNo;
                    classWork->CarNo = gcnew String(structWork->CarNo);
                    classWork->CarNote = gcnew String(structWork->CarNote);
                    array<Byte> ^CarRelationGuidByteArray = gcnew array<Byte>(16);
                    Marshal::Copy(IntPtr(&structWork->CarRelationGuid), CarRelationGuidByteArray, 0, 16);
                    classWork->CarRelationGuid = Guid(CarRelationGuidByteArray);
                    classWork->CategoryNo = structWork->CategoryNo;
                    //classWork->CategoryObjAry = gcnew String(structWork->CategoryObjAry);
                    classWork->CategorySignModel = gcnew String(structWork->CategorySignModel);
                    classWork->ColorCode = gcnew String(structWork->ColorCode);
                    classWork->ColorName1 = gcnew String(structWork->ColorName1);
                    classWork->CreateDateTime = DateTime(structWork->CreateDateTime);
                    classWork->CustomerCode = structWork->CustomerCode;
                    classWork->CustomerCodeForGuide = gcnew String(structWork->CustomerCodeForGuide);
                    classWork->CustomerName = gcnew String(structWork->CustomerName);
                    classWork->DoorCount = structWork->DoorCount;
                    classWork->EDivNm = gcnew String(structWork->EDivNm);
                    classWork->EdProduceFrameNo = structWork->EdProduceFrameNo;
                    classWork->EdProduceTypeOfYear = DateTime(structWork->EdProduceTypeOfYear);
                    classWork->EngineDisplaceNm = gcnew String(structWork->EngineDisplaceNm);
                    classWork->EngineModel = gcnew String(structWork->EngineModel);
                    classWork->EngineModelNm = gcnew String(structWork->EngineModelNm);
                    classWork->EnterpriseCode = gcnew String(structWork->EnterpriseCode);
					classWork->EntryDate = DateTime(structWork->EntryDate);
                    classWork->ExhaustGasSign = gcnew String(structWork->ExhaustGasSign);
                    array<Byte> ^FileHeaderGuidByteArray = gcnew array<Byte>(16);
                    Marshal::Copy(IntPtr(&structWork->FileHeaderGuid), FileHeaderGuidByteArray, 0, 16);
                    classWork->FileHeaderGuid = Guid(FileHeaderGuidByteArray);
                    classWork->FirstEntryDate = structWork->FirstEntryDate;
                    classWork->FrameModel = gcnew String(structWork->FrameModel);
                    classWork->FrameNo = gcnew String(structWork->FrameNo);
                    classWork->FullModel = gcnew String(structWork->FullModel);
                    //classWork->FullModelFixedNoAry = gcnew String(structWork->FullModelFixedNoAry);
                    classWork->InspectMaturityDate = DateTime(structWork->InspectMaturityDate);
                    classWork->LogicalDeleteCode = structWork->LogicalDeleteCode;
                    classWork->LTimeCiMatDate = DateTime(structWork->LTimeCiMatDate);
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->MakerFullName = gcnew String(structWork->MakerFullName);
                    classWork->MakerHalfName = gcnew String(structWork->MakerHalfName);
                    classWork->Mileage = structWork->Mileage;
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelDesignationNo = structWork->ModelDesignationNo;
                    classWork->ModelFullName = gcnew String(structWork->ModelFullName);
                    classWork->ModelGradeNm = gcnew String(structWork->ModelGradeNm);
                    classWork->ModelGradeSname = gcnew String(structWork->ModelGradeSname);
                    classWork->ModelHalfName = gcnew String(structWork->ModelHalfName);
                    classWork->ModelSubCode = structWork->ModelSubCode;
                    classWork->NumberPlate1Code = structWork->NumberPlate1Code;
                    classWork->NumberPlate1Name = gcnew String(structWork->NumberPlate1Name);
                    classWork->NumberPlate2 = gcnew String(structWork->NumberPlate2);
                    classWork->NumberPlate3 = gcnew String(structWork->NumberPlate3);
                    classWork->NumberPlate4 = structWork->NumberPlate4;
                    classWork->NumberPlateForGuide = gcnew String(structWork->NumberPlateForGuide);
                    classWork->PartsDataOfferFlag = structWork->PartsDataOfferFlag;
                    classWork->ProduceTypeOfYearCd = structWork->ProduceTypeOfYearCd;
                    classWork->ProduceTypeOfYearInput = structWork->ProduceTypeOfYearInput;
                    classWork->ProduceTypeOfYearNm = gcnew String(structWork->ProduceTypeOfYearNm);
                    classWork->RelevanceModel = gcnew String(structWork->RelevanceModel);
                    classWork->SearchFrameNo = structWork->SearchFrameNo;
                    classWork->SeriesModel = gcnew String(structWork->SeriesModel);
                    classWork->ShiftNm = gcnew String(structWork->ShiftNm);
                    classWork->StProduceFrameNo = structWork->StProduceFrameNo;
                    classWork->StProduceTypeOfYear = DateTime(structWork->StProduceTypeOfYear);
                    classWork->SubCarNmCd = structWork->SubCarNmCd;
                    classWork->SystematicCode = structWork->SystematicCode;
                    classWork->SystematicName = gcnew String(structWork->SystematicName);
                    classWork->ThreeDIllustNo = structWork->ThreeDIllustNo;
                    classWork->TransmissionNm = gcnew String(structWork->TransmissionNm);
                    classWork->TrimCode = gcnew String(structWork->TrimCode);
                    classWork->TrimName = gcnew String(structWork->TrimName);
                    classWork->UpdateDateTime = DateTime(structWork->UpdateDateTime);
                    classWork->WheelDriveMethodNm = gcnew String(structWork->WheelDriveMethodNm);
					classWork->DomesticForeignCode = structWork->DomesticForeignCode; // ADD 2013/03/21
                }

				void CopyClassToStruct_CarMangInputExtraInfo(Broadleaf::Application::UIData::CarMangInputExtraInfo ^classWork, StructCarMangInputExtraInfo *structWork){
                    structWork->AddiCarSpec1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec1).ToPointer());
                    structWork->AddiCarSpec2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec2).ToPointer());
                    structWork->AddiCarSpec3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec3).ToPointer());
                    structWork->AddiCarSpec4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec4).ToPointer());
                    structWork->AddiCarSpec5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec5).ToPointer());
                    structWork->AddiCarSpec6 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpec6).ToPointer());
                    structWork->AddiCarSpecTitle1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle1).ToPointer());
                    structWork->AddiCarSpecTitle2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle2).ToPointer());
                    structWork->AddiCarSpecTitle3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle3).ToPointer());
                    structWork->AddiCarSpecTitle4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle4).ToPointer());
                    structWork->AddiCarSpecTitle5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle5).ToPointer());
                    structWork->AddiCarSpecTitle6 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AddiCarSpecTitle6).ToPointer());
                    structWork->BlockIllustrationCd = classWork->BlockIllustrationCd;
                    structWork->BodyName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BodyName).ToPointer());
                    structWork->BodyNameCode = classWork->BodyNameCode;
                    structWork->CarAddInfo1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarAddInfo1).ToPointer());
                    structWork->CarAddInfo2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarAddInfo2).ToPointer());
                    structWork->CarInspectYear = classWork->CarInspectYear;
                    structWork->CarMngCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarMngCode).ToPointer());
                    structWork->CarMngNo = classWork->CarMngNo;
                    structWork->CarNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarNo).ToPointer());
                    structWork->CarNote = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CarNote).ToPointer());
                    Marshal::Copy(classWork->CarRelationGuid.ToByteArray(), 0, IntPtr(&structWork->CarRelationGuid), 16);
                    structWork->CategoryNo = classWork->CategoryNo;
                    //structWork->CategoryObjAry = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CategoryObjAry).ToPointer());
                    structWork->CategorySignModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CategorySignModel).ToPointer());
                    structWork->ColorCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ColorCode).ToPointer());
                    structWork->ColorName1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ColorName1).ToPointer());
                    structWork->CreateDateTime = classWork->CreateDateTime.Ticks;
                    structWork->CustomerCode = classWork->CustomerCode;
                    structWork->CustomerCodeForGuide = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerCodeForGuide).ToPointer());
                    structWork->CustomerName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerName).ToPointer());
                    structWork->DoorCount = classWork->DoorCount;
                    structWork->EDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EDivNm).ToPointer());
                    structWork->EdProduceFrameNo = classWork->EdProduceFrameNo;
					structWork->EdProduceTypeOfYear = classWork->EdProduceTypeOfYear.Ticks;
                    structWork->EngineDisplaceNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineDisplaceNm).ToPointer());
                    structWork->EngineModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineModel).ToPointer());
                    structWork->EngineModelNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EngineModelNm).ToPointer());
                    structWork->EnterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseCode).ToPointer());
					structWork->EntryDate = classWork->EntryDate.Ticks;
                    structWork->ExhaustGasSign = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ExhaustGasSign).ToPointer());
                    Marshal::Copy(classWork->FileHeaderGuid.ToByteArray(), 0, IntPtr(&structWork->FileHeaderGuid), 16);
                    structWork->FirstEntryDate = classWork->FirstEntryDate;
                    structWork->FrameModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FrameModel).ToPointer());
                    structWork->FrameNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FrameNo).ToPointer());
                    structWork->FullModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FullModel).ToPointer());
                    //structWork->FullModelFixedNoAry = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FullModelFixedNoAry).ToPointer());
					structWork->InspectMaturityDate = classWork->InspectMaturityDate.Ticks;
                    structWork->LogicalDeleteCode = classWork->LogicalDeleteCode;
					structWork->LTimeCiMatDate = classWork->LTimeCiMatDate.Ticks;
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->MakerFullName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MakerFullName).ToPointer());
                    structWork->MakerHalfName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MakerHalfName).ToPointer());
                    structWork->Mileage = classWork->Mileage;
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelDesignationNo = classWork->ModelDesignationNo;
                    structWork->ModelFullName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelFullName).ToPointer());
                    structWork->ModelGradeNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelGradeNm).ToPointer());
                    structWork->ModelGradeSname = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelGradeSname).ToPointer());
                    structWork->ModelHalfName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelHalfName).ToPointer());
                    structWork->ModelSubCode = classWork->ModelSubCode;
                    structWork->NumberPlate1Code = classWork->NumberPlate1Code;
                    structWork->NumberPlate1Name = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlate1Name).ToPointer());
                    structWork->NumberPlate2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlate2).ToPointer());
                    structWork->NumberPlate3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlate3).ToPointer());
                    structWork->NumberPlate4 = classWork->NumberPlate4;
                    structWork->NumberPlateForGuide = static_cast<BSTR>(Marshal::StringToBSTR(classWork->NumberPlateForGuide).ToPointer());
                    structWork->PartsDataOfferFlag = classWork->PartsDataOfferFlag;
                    structWork->ProduceTypeOfYearCd = classWork->ProduceTypeOfYearCd;
                    structWork->ProduceTypeOfYearInput = classWork->ProduceTypeOfYearInput;
                    structWork->ProduceTypeOfYearNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ProduceTypeOfYearNm).ToPointer());
                    structWork->RelevanceModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RelevanceModel).ToPointer());
                    structWork->SearchFrameNo = classWork->SearchFrameNo;
                    structWork->SeriesModel = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SeriesModel).ToPointer());
                    structWork->ShiftNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ShiftNm).ToPointer());
                    structWork->StProduceFrameNo = classWork->StProduceFrameNo;
					structWork->StProduceTypeOfYear = classWork->StProduceTypeOfYear.Ticks;
                    structWork->SubCarNmCd = classWork->SubCarNmCd;
                    structWork->SystematicCode = classWork->SystematicCode;
                    structWork->SystematicName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SystematicName).ToPointer());
                    structWork->ThreeDIllustNo = classWork->ThreeDIllustNo;
                    structWork->TransmissionNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TransmissionNm).ToPointer());
                    structWork->TrimCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TrimCode).ToPointer());
                    structWork->TrimName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->TrimName).ToPointer());
                    structWork->UpdateDateTime = classWork->UpdateDateTime.Ticks;
                    structWork->WheelDriveMethodNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->WheelDriveMethodNm).ToPointer());
					structWork->DomesticForeignCode = classWork->DomesticForeignCode; // ADD 2013/03/21
                }

				// C++構造体→.NETクラスコピー処理

                void CopyStructToClass_ModelNameU(StructModelNameU *structWork, Broadleaf::Application::UIData::ModelNameU ^classWork){
                    classWork->CreateDateTime = DateTime(structWork->CreateDateTime);
                    classWork->CreateDateTimeAdFormal = gcnew String(structWork->CreateDateTimeAdFormal);
                    classWork->CreateDateTimeAdInFormal = gcnew String(structWork->CreateDateTimeAdInFormal);
                    classWork->CreateDateTimeJpFormal = gcnew String(structWork->CreateDateTimeJpFormal);
                    classWork->CreateDateTimeJpInFormal = gcnew String(structWork->CreateDateTimeJpInFormal);
                    classWork->Division = structWork->Division;
                    classWork->DivisionName = gcnew String(structWork->DivisionName);
                    classWork->EnterpriseCode = gcnew String(structWork->EnterpriseCode);
                    classWork->EnterpriseName = gcnew String(structWork->EnterpriseName);
                    array<Byte> ^FileHeaderGuidByteArray = gcnew array<Byte>(16);
                    Marshal::Copy(IntPtr(&structWork->FileHeaderGuid), FileHeaderGuidByteArray, 0, 16);
                    classWork->FileHeaderGuid = Guid(FileHeaderGuidByteArray);
                    classWork->LogicalDeleteCode = structWork->LogicalDeleteCode;
                    classWork->MakerCode = structWork->MakerCode;
                    classWork->ModelAliasName = gcnew String(structWork->ModelAliasName);
                    classWork->ModelCode = structWork->ModelCode;
                    classWork->ModelFullName = gcnew String(structWork->ModelFullName);
                    classWork->ModelHalfName = gcnew String(structWork->ModelHalfName);
                    classWork->ModelSubCode = structWork->ModelSubCode;
                    classWork->ModelUniqueCode = structWork->ModelUniqueCode;
                    classWork->OfferDataDiv = structWork->OfferDataDiv;
					classWork->OfferDate = DateTime(structWork->OfferDate);
                    classWork->UpdAssemblyId1 = gcnew String(structWork->UpdAssemblyId1);
                    classWork->UpdAssemblyId2 = gcnew String(structWork->UpdAssemblyId2);
                    classWork->UpdateDateTime = DateTime(structWork->UpdateDateTime);
                    classWork->UpdateDateTimeAdFormal = gcnew String(structWork->UpdateDateTimeAdFormal);
                    classWork->UpdateDateTimeAdInFormal = gcnew String(structWork->UpdateDateTimeAdInFormal);
                    classWork->UpdateDateTimeJpFormal = gcnew String(structWork->UpdateDateTimeJpFormal);
                    classWork->UpdateDateTimeJpInFormal = gcnew String(structWork->UpdateDateTimeJpInFormal);
                    classWork->UpdEmployeeCode = gcnew String(structWork->UpdEmployeeCode);
                    classWork->UpdEmployeeName = gcnew String(structWork->UpdEmployeeName);
                }

				// .NETクラス→C++構造体コピー処理

                void CopyClassToStruct_ModelNameU(Broadleaf::Application::UIData::ModelNameU ^classWork, StructModelNameU *structWork){
                    structWork->CreateDateTime = classWork->CreateDateTime.Ticks;
                    structWork->CreateDateTimeAdFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeAdFormal).ToPointer());
                    structWork->CreateDateTimeAdInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeAdInFormal).ToPointer());
                    structWork->CreateDateTimeJpFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeJpFormal).ToPointer());
                    structWork->CreateDateTimeJpInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeJpInFormal).ToPointer());
                    structWork->Division = classWork->Division;
                    structWork->DivisionName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DivisionName).ToPointer());
                    structWork->EnterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseCode).ToPointer());
                    structWork->EnterpriseName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseName).ToPointer());
                    Marshal::Copy(classWork->FileHeaderGuid.ToByteArray(), 0, IntPtr(&structWork->FileHeaderGuid), 16);
                    structWork->LogicalDeleteCode = classWork->LogicalDeleteCode;
                    structWork->MakerCode = classWork->MakerCode;
                    structWork->ModelAliasName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelAliasName).ToPointer());
                    structWork->ModelCode = classWork->ModelCode;
                    structWork->ModelFullName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelFullName).ToPointer());
                    structWork->ModelHalfName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ModelHalfName).ToPointer());
                    structWork->ModelSubCode = classWork->ModelSubCode;
                    structWork->ModelUniqueCode = classWork->ModelUniqueCode;
                    structWork->OfferDataDiv = classWork->OfferDataDiv;
					structWork->OfferDate = classWork->OfferDate.Ticks;
                    structWork->UpdAssemblyId1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdAssemblyId1).ToPointer());
                    structWork->UpdAssemblyId2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdAssemblyId2).ToPointer());
                    structWork->UpdateDateTime = classWork->UpdateDateTime.Ticks;
                    structWork->UpdateDateTimeAdFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeAdFormal).ToPointer());
                    structWork->UpdateDateTimeAdInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeAdInFormal).ToPointer());
                    structWork->UpdateDateTimeJpFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeJpFormal).ToPointer());
                    structWork->UpdateDateTimeJpInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeJpInFormal).ToPointer());
                    structWork->UpdEmployeeCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdEmployeeCode).ToPointer());
                    structWork->UpdEmployeeName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdEmployeeName).ToPointer());
                }

				// C++メモリ開放処理

                __declspec(dllexport) void __stdcall FreeModelNameU(StructModelNameU *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeAdFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeAdInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeJpFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeJpInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DivisionName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelAliasName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelFullName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelHalfName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdAssemblyId1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdAssemblyId2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeAdFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeAdInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeJpFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeJpInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdEmployeeCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdEmployeeName));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

				// add by gaofeng end

				// add by Zhangkai start
				// C++構造体→.NETクラスコピー処理

                void CopyStructToClass_SalesDetail(StructSalesDetail *structWork, SalesDetail ^classWork){
                    classWork->AcptAnOdrStatus = structWork->AcptAnOdrStatus;
                    classWork->SalesSlipNum = gcnew String(structWork->SalesSlipNum);
                    classWork->SalesRowNo = structWork->SalesRowNo;
                    classWork->SalesRowDerivNo = structWork->SalesRowDerivNo;
                    classWork->SectionCode = gcnew String(structWork->SectionCode);
                    classWork->SubSectionCode = structWork->SubSectionCode;
                    classWork->SalesDate = DateTime(structWork->SalesDate);
                    classWork->CommonSeqNo = structWork->CommonSeqNo;
                    classWork->SalesSlipDtlNum = structWork->SalesSlipDtlNum;
                    classWork->AcptAnOdrStatusSrc = structWork->AcptAnOdrStatusSrc;
                    classWork->SalesSlipDtlNumSrc = structWork->SalesSlipDtlNumSrc;
                    classWork->SupplierFormalSync = structWork->SupplierFormalSync;
                    classWork->StockSlipDtlNumSync = structWork->StockSlipDtlNumSync;
                    classWork->SalesSlipCdDtl = structWork->SalesSlipCdDtl;
                    classWork->DeliGdsCmpltDueDate = DateTime(structWork->DeliGdsCmpltDueDate);
                    classWork->GoodsKindCode = structWork->GoodsKindCode;
                    classWork->GoodsSearchDivCd = structWork->GoodsSearchDivCd;
                    classWork->GoodsMakerCd = structWork->GoodsMakerCd;
                    classWork->MakerName = gcnew String(structWork->MakerName);
                    classWork->MakerKanaName = gcnew String(structWork->MakerKanaName);
                    classWork->GoodsNo = gcnew String(structWork->GoodsNo);
                    classWork->GoodsName = gcnew String(structWork->GoodsName);
                    classWork->GoodsNameKana = gcnew String(structWork->GoodsNameKana);
                    classWork->GoodsLGroup = structWork->GoodsLGroup;
                    classWork->GoodsLGroupName = gcnew String(structWork->GoodsLGroupName);
                    classWork->GoodsMGroup = structWork->GoodsMGroup;
                    classWork->GoodsMGroupName = gcnew String(structWork->GoodsMGroupName);
                    classWork->BLGroupCode = structWork->BLGroupCode;
                    classWork->BLGroupName = gcnew String(structWork->BLGroupName);
                    classWork->BLGoodsCode = structWork->BLGoodsCode;
                    classWork->BLGoodsFullName = gcnew String(structWork->BLGoodsFullName);
                    classWork->EnterpriseGanreCode = structWork->EnterpriseGanreCode;
                    classWork->EnterpriseGanreName = gcnew String(structWork->EnterpriseGanreName);
                    classWork->WarehouseCode = gcnew String(structWork->WarehouseCode);
                    classWork->WarehouseName = gcnew String(structWork->WarehouseName);
                    classWork->WarehouseShelfNo = gcnew String(structWork->WarehouseShelfNo);
                    classWork->SalesOrderDivCd = structWork->SalesOrderDivCd;
                    classWork->OpenPriceDiv = structWork->OpenPriceDiv;
                    classWork->GoodsRateRank = gcnew String(structWork->GoodsRateRank);
                    classWork->CustRateGrpCode = structWork->CustRateGrpCode;
                    classWork->ListPriceRate = structWork->ListPriceRate;
                    classWork->RateSectPriceUnPrc = gcnew String(structWork->RateSectPriceUnPrc);
                    classWork->RateDivLPrice = gcnew String(structWork->RateDivLPrice);
                    classWork->UnPrcCalcCdLPrice = structWork->UnPrcCalcCdLPrice;
                    classWork->PriceCdLPrice = structWork->PriceCdLPrice;
                    classWork->StdUnPrcLPrice = structWork->StdUnPrcLPrice;
                    classWork->FracProcUnitLPrice = structWork->FracProcUnitLPrice;
                    classWork->FracProcLPrice = structWork->FracProcLPrice;
                    classWork->ListPriceTaxIncFl = structWork->ListPriceTaxIncFl;
                    classWork->ListPriceTaxExcFl = structWork->ListPriceTaxExcFl;
                    classWork->ListPriceChngCd = structWork->ListPriceChngCd;
                    classWork->SalesRate = structWork->SalesRate;
                    classWork->RateSectSalUnPrc = gcnew String(structWork->RateSectSalUnPrc);
                    classWork->RateDivSalUnPrc = gcnew String(structWork->RateDivSalUnPrc);
                    classWork->UnPrcCalcCdSalUnPrc = structWork->UnPrcCalcCdSalUnPrc;
                    classWork->PriceCdSalUnPrc = structWork->PriceCdSalUnPrc;
                    classWork->StdUnPrcSalUnPrc = structWork->StdUnPrcSalUnPrc;
                    classWork->FracProcUnitSalUnPrc = structWork->FracProcUnitSalUnPrc;
                    classWork->FracProcSalUnPrc = structWork->FracProcSalUnPrc;
                    classWork->SalesUnPrcTaxIncFl = structWork->SalesUnPrcTaxIncFl;
                    classWork->SalesUnPrcTaxExcFl = structWork->SalesUnPrcTaxExcFl;
                    classWork->SalesUnPrcChngCd = structWork->SalesUnPrcChngCd;
                    classWork->CostRate = structWork->CostRate;
                    classWork->RateSectCstUnPrc = gcnew String(structWork->RateSectCstUnPrc);
                    classWork->RateDivUnCst = gcnew String(structWork->RateDivUnCst);
                    classWork->UnPrcCalcCdUnCst = structWork->UnPrcCalcCdUnCst;
                    classWork->PriceCdUnCst = structWork->PriceCdUnCst;
                    classWork->StdUnPrcUnCst = structWork->StdUnPrcUnCst;
                    classWork->FracProcUnitUnCst = structWork->FracProcUnitUnCst;
                    classWork->FracProcUnCst = structWork->FracProcUnCst;
                    classWork->SalesUnitCost = structWork->SalesUnitCost;
                    classWork->SalesUnitCostChngDiv = structWork->SalesUnitCostChngDiv;
                    classWork->RateBLGoodsCode = structWork->RateBLGoodsCode;
                    classWork->RateBLGoodsName = gcnew String(structWork->RateBLGoodsName);
                    classWork->RateGoodsRateGrpCd = structWork->RateGoodsRateGrpCd;
                    classWork->RateGoodsRateGrpNm = gcnew String(structWork->RateGoodsRateGrpNm);
                    classWork->RateBLGroupCode = structWork->RateBLGroupCode;
                    classWork->RateBLGroupName = gcnew String(structWork->RateBLGroupName);
                    classWork->PrtBLGoodsCode = structWork->PrtBLGoodsCode;
                    classWork->PrtBLGoodsName = gcnew String(structWork->PrtBLGoodsName);
                    classWork->SalesCode = structWork->SalesCode;
                    classWork->SalesCdNm = gcnew String(structWork->SalesCdNm);
                    classWork->WorkManHour = structWork->WorkManHour;
                    classWork->ShipmentCnt = structWork->ShipmentCnt;
                    classWork->AcceptAnOrderCnt = structWork->AcceptAnOrderCnt;
                    classWork->AcptAnOdrAdjustCnt = structWork->AcptAnOdrAdjustCnt;
                    classWork->AcptAnOdrRemainCnt = structWork->AcptAnOdrRemainCnt;
                    classWork->RemainCntUpdDate = DateTime(structWork->RemainCntUpdDate);
                    classWork->SalesMoneyTaxInc = structWork->SalesMoneyTaxInc;
                    classWork->SalesMoneyTaxExc = structWork->SalesMoneyTaxExc;
                    classWork->Cost = structWork->Cost;
                    classWork->GrsProfitChkDiv = structWork->GrsProfitChkDiv;
                    classWork->SalesGoodsCd = structWork->SalesGoodsCd;
                    classWork->SalesPriceConsTax = structWork->SalesPriceConsTax;
                    classWork->TaxationDivCd = structWork->TaxationDivCd;
                    classWork->PartySlipNumDtl = gcnew String(structWork->PartySlipNumDtl);
                    classWork->DtlNote = gcnew String(structWork->DtlNote);
                    classWork->SupplierCd = structWork->SupplierCd;
                    classWork->SupplierSnm = gcnew String(structWork->SupplierSnm);
                    classWork->OrderNumber = gcnew String(structWork->OrderNumber);
                    classWork->WayToOrder = structWork->WayToOrder;
                    classWork->SlipMemo1 = gcnew String(structWork->SlipMemo1);
                    classWork->SlipMemo2 = gcnew String(structWork->SlipMemo2);
                    classWork->SlipMemo3 = gcnew String(structWork->SlipMemo3);
                    classWork->InsideMemo1 = gcnew String(structWork->InsideMemo1);
                    classWork->InsideMemo2 = gcnew String(structWork->InsideMemo2);
                    classWork->InsideMemo3 = gcnew String(structWork->InsideMemo3);
                    classWork->BfListPrice = structWork->BfListPrice;
                    classWork->BfSalesUnitPrice = structWork->BfSalesUnitPrice;
                    classWork->BfUnitCost = structWork->BfUnitCost;
                    classWork->CmpltSalesRowNo = structWork->CmpltSalesRowNo;
                    classWork->CmpltGoodsMakerCd = structWork->CmpltGoodsMakerCd;
                    classWork->CmpltMakerName = gcnew String(structWork->CmpltMakerName);
                    classWork->CmpltMakerKanaName = gcnew String(structWork->CmpltMakerKanaName);
                    classWork->CmpltGoodsName = gcnew String(structWork->CmpltGoodsName);
                    classWork->CmpltShipmentCnt = structWork->CmpltShipmentCnt;
                    classWork->CmpltSalesUnPrcFl = structWork->CmpltSalesUnPrcFl;
                    classWork->CmpltSalesMoney = structWork->CmpltSalesMoney;
                    classWork->CmpltSalesUnitCost = structWork->CmpltSalesUnitCost;
                    classWork->CmpltCost = structWork->CmpltCost;
                    classWork->CmpltPartySalSlNum = gcnew String(structWork->CmpltPartySalSlNum);
                    classWork->CmpltNote = gcnew String(structWork->CmpltNote);
                    classWork->PrtGoodsNo = gcnew String(structWork->PrtGoodsNo);
                    classWork->PrtMakerCode = structWork->PrtMakerCode;
                    classWork->PrtMakerName = gcnew String(structWork->PrtMakerName);
					classWork->EditStatus = structWork->EditStatus;
					classWork->RowStatus = structWork->RowStatus;
					classWork->SalesMoneyInputDiv = structWork->SalesMoneyInputDiv;
					classWork->ShipmentCntDisplay = structWork->ShipmentCntDisplay;
					classWork->SupplierStockDisplay = structWork->SupplierStockDisplay;
					classWork->ListPriceDisplay = structWork->ListPriceDisplay;
					classWork->StockDate = DateTime(structWork->StockDate);
					classWork->BoCode = gcnew String(structWork->BoCode);
					classWork->SupplierCdForOrder = structWork->SupplierCdForOrder;
					classWork->SupplierSnmForOrder = gcnew String(structWork->SupplierSnmForOrder);
					classWork->DeliveredGoodsDivNm = gcnew String(structWork->DeliveredGoodsDivNm);
					classWork->FollowDeliGoodsDivNm = gcnew String(structWork->FollowDeliGoodsDivNm);
					classWork->UOEResvdSectionNm = gcnew String(structWork->UOEResvdSectionNm);
					classWork->UOEDeliGoodsDiv = gcnew String(structWork->UOEDeliGoodsDiv);
					classWork->FollowDeliGoodsDiv = gcnew String(structWork->FollowDeliGoodsDiv);
					classWork->UOEResvdSection = gcnew String(structWork->UOEResvdSection);
					classWork->PartySalesSlipNum = gcnew String(structWork->PartySalesSlipNum);
					classWork->AcceptAnOrderNo = structWork->AcceptAnOrderNo;
					classWork->SearchPartsModeState = structWork->SearchPartsModeState;
			        //>>>2010/05/30
					//classWork->CampaignCode = structWork->CampaignCode;
					//classWork->CampaignName = gcnew String(structWork->CampaignName);
					//classWork->GoodsDivCd = structWork->GoodsDivCd;
					//classWork->AnswerDelivDate = gcnew String(structWork->AnswerDelivDate);
					classWork->RecycleDiv = structWork->RecycleDiv;
					classWork->RecycleDivNm = gcnew String(structWork->RecycleDivNm);
					//classWork->WayToAcptOdr = structWork->WayToAcptOdr;
					classWork->GoodsMngNo = structWork->GoodsMngNo;
					//classWork->InqRowNumber = structWork->InqRowNumber;
					//classWork->InqRowNumDerivedNo = structWork->InqRowNumDerivedNo;
					//<<<2010/05/30
                }

				void CopyStructToClass_CustomArrayA2(StructCustomArrayA2 *structWork, ArrayList ^arrayWork){
                    SalesDetail^ csafield1;
                    for (int i = 0; i < structWork->Csafield1Count; i++){
                        csafield1 = gcnew SalesDetail();
                        CopyStructToClass_SalesDetail(&(structWork->Csafield1[i]), csafield1);
                        arrayWork->Add(csafield1);
                    }
                }

				// .NETクラス→C++構造体コピー処理

                void CopyClassToStruct_SalesDetail(SalesDetail ^classWork, StructSalesDetail *structWork){
                    structWork->AcptAnOdrStatus = classWork->AcptAnOdrStatus;
                    structWork->SalesSlipNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesSlipNum).ToPointer());
                    structWork->SalesRowNo = classWork->SalesRowNo;
                    structWork->SalesRowDerivNo = classWork->SalesRowDerivNo;
                    structWork->SectionCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SectionCode).ToPointer());
                    structWork->SubSectionCode = classWork->SubSectionCode;
					structWork->SalesDate = classWork->SalesDate.Ticks;
                    structWork->CommonSeqNo = classWork->CommonSeqNo;
                    structWork->SalesSlipDtlNum = classWork->SalesSlipDtlNum;
                    structWork->AcptAnOdrStatusSrc = classWork->AcptAnOdrStatusSrc;
                    structWork->SalesSlipDtlNumSrc = classWork->SalesSlipDtlNumSrc;
                    structWork->SupplierFormalSync = classWork->SupplierFormalSync;
                    structWork->StockSlipDtlNumSync = classWork->StockSlipDtlNumSync;
                    structWork->SalesSlipCdDtl = classWork->SalesSlipCdDtl;
                    structWork->DeliGdsCmpltDueDate = classWork->DeliGdsCmpltDueDate.Ticks;
                    structWork->GoodsKindCode = classWork->GoodsKindCode;
                    structWork->GoodsSearchDivCd = classWork->GoodsSearchDivCd;
                    structWork->GoodsMakerCd = classWork->GoodsMakerCd;
                    structWork->MakerName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MakerName).ToPointer());
                    structWork->MakerKanaName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MakerKanaName).ToPointer());
                    structWork->GoodsNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->GoodsNo).ToPointer());
                    structWork->GoodsName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->GoodsName).ToPointer());
                    structWork->GoodsNameKana = static_cast<BSTR>(Marshal::StringToBSTR(classWork->GoodsNameKana).ToPointer());
                    structWork->GoodsLGroup = classWork->GoodsLGroup;
                    structWork->GoodsLGroupName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->GoodsLGroupName).ToPointer());
                    structWork->GoodsMGroup = classWork->GoodsMGroup;
                    structWork->GoodsMGroupName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->GoodsMGroupName).ToPointer());
                    structWork->BLGroupCode = classWork->BLGroupCode;
                    structWork->BLGroupName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BLGroupName).ToPointer());
                    structWork->BLGoodsCode = classWork->BLGoodsCode;
                    structWork->BLGoodsFullName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BLGoodsFullName).ToPointer());
                    structWork->EnterpriseGanreCode = classWork->EnterpriseGanreCode;
                    structWork->EnterpriseGanreName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseGanreName).ToPointer());
                    structWork->WarehouseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->WarehouseCode).ToPointer());
                    structWork->WarehouseName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->WarehouseName).ToPointer());
                    structWork->WarehouseShelfNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->WarehouseShelfNo).ToPointer());
                    structWork->SalesOrderDivCd = classWork->SalesOrderDivCd;
                    structWork->OpenPriceDiv = classWork->OpenPriceDiv;
                    structWork->GoodsRateRank = static_cast<BSTR>(Marshal::StringToBSTR(classWork->GoodsRateRank).ToPointer());
                    structWork->CustRateGrpCode = classWork->CustRateGrpCode;
                    structWork->ListPriceRate = classWork->ListPriceRate;
                    structWork->RateSectPriceUnPrc = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateSectPriceUnPrc).ToPointer());
                    structWork->RateDivLPrice = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateDivLPrice).ToPointer());
                    structWork->UnPrcCalcCdLPrice = classWork->UnPrcCalcCdLPrice;
                    structWork->PriceCdLPrice = classWork->PriceCdLPrice;
                    structWork->StdUnPrcLPrice = classWork->StdUnPrcLPrice;
                    structWork->FracProcUnitLPrice = classWork->FracProcUnitLPrice;
                    structWork->FracProcLPrice = classWork->FracProcLPrice;
                    structWork->ListPriceTaxIncFl = classWork->ListPriceTaxIncFl;
                    structWork->ListPriceTaxExcFl = classWork->ListPriceTaxExcFl;
                    structWork->ListPriceChngCd = classWork->ListPriceChngCd;
                    structWork->SalesRate = classWork->SalesRate;
                    structWork->RateSectSalUnPrc = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateSectSalUnPrc).ToPointer());
                    structWork->RateDivSalUnPrc = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateDivSalUnPrc).ToPointer());
                    structWork->UnPrcCalcCdSalUnPrc = classWork->UnPrcCalcCdSalUnPrc;
                    structWork->PriceCdSalUnPrc = classWork->PriceCdSalUnPrc;
                    structWork->StdUnPrcSalUnPrc = classWork->StdUnPrcSalUnPrc;
                    structWork->FracProcUnitSalUnPrc = classWork->FracProcUnitSalUnPrc;
                    structWork->FracProcSalUnPrc = classWork->FracProcSalUnPrc;
                    structWork->SalesUnPrcTaxIncFl = classWork->SalesUnPrcTaxIncFl;
                    structWork->SalesUnPrcTaxExcFl = classWork->SalesUnPrcTaxExcFl;
                    structWork->SalesUnPrcChngCd = classWork->SalesUnPrcChngCd;
                    structWork->CostRate = classWork->CostRate;
                    structWork->RateSectCstUnPrc = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateSectCstUnPrc).ToPointer());
                    structWork->RateDivUnCst = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateDivUnCst).ToPointer());
                    structWork->UnPrcCalcCdUnCst = classWork->UnPrcCalcCdUnCst;
                    structWork->PriceCdUnCst = classWork->PriceCdUnCst;
                    structWork->StdUnPrcUnCst = classWork->StdUnPrcUnCst;
                    structWork->FracProcUnitUnCst = classWork->FracProcUnitUnCst;
                    structWork->FracProcUnCst = classWork->FracProcUnCst;
                    structWork->SalesUnitCost = classWork->SalesUnitCost;
                    structWork->SalesUnitCostChngDiv = classWork->SalesUnitCostChngDiv;
                    structWork->RateBLGoodsCode = classWork->RateBLGoodsCode;
                    structWork->RateBLGoodsName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateBLGoodsName).ToPointer());
                    structWork->RateGoodsRateGrpCd = classWork->RateGoodsRateGrpCd;
                    structWork->RateGoodsRateGrpNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateGoodsRateGrpNm).ToPointer());
                    structWork->RateBLGroupCode = classWork->RateBLGroupCode;
                    structWork->RateBLGroupName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RateBLGroupName).ToPointer());
                    structWork->PrtBLGoodsCode = classWork->PrtBLGoodsCode;
                    structWork->PrtBLGoodsName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PrtBLGoodsName).ToPointer());
                    structWork->SalesCode = classWork->SalesCode;
                    structWork->SalesCdNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesCdNm).ToPointer());
                    structWork->WorkManHour = classWork->WorkManHour;
                    structWork->ShipmentCnt = classWork->ShipmentCnt;
                    structWork->AcceptAnOrderCnt = classWork->AcceptAnOrderCnt;
                    structWork->AcptAnOdrAdjustCnt = classWork->AcptAnOdrAdjustCnt;
                    structWork->AcptAnOdrRemainCnt = classWork->AcptAnOdrRemainCnt;
                    structWork->RemainCntUpdDate = classWork->RemainCntUpdDate.Ticks;
                    structWork->SalesMoneyTaxInc = classWork->SalesMoneyTaxInc;
                    structWork->SalesMoneyTaxExc = classWork->SalesMoneyTaxExc;
                    structWork->Cost = classWork->Cost;
                    structWork->GrsProfitChkDiv = classWork->GrsProfitChkDiv;
                    structWork->SalesGoodsCd = classWork->SalesGoodsCd;
                    structWork->SalesPriceConsTax = classWork->SalesPriceConsTax;
                    structWork->TaxationDivCd = classWork->TaxationDivCd;
                    structWork->PartySlipNumDtl = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PartySlipNumDtl).ToPointer());
                    structWork->DtlNote = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DtlNote).ToPointer());
                    structWork->SupplierCd = classWork->SupplierCd;
                    structWork->SupplierSnm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SupplierSnm).ToPointer());
                    structWork->OrderNumber = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OrderNumber).ToPointer());
                    structWork->WayToOrder = classWork->WayToOrder;
                    structWork->SlipMemo1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipMemo1).ToPointer());
                    structWork->SlipMemo2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipMemo2).ToPointer());
                    structWork->SlipMemo3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SlipMemo3).ToPointer());
                    structWork->InsideMemo1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InsideMemo1).ToPointer());
                    structWork->InsideMemo2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InsideMemo2).ToPointer());
                    structWork->InsideMemo3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InsideMemo3).ToPointer());
                    structWork->BfListPrice = classWork->BfListPrice;
                    structWork->BfSalesUnitPrice = classWork->BfSalesUnitPrice;
                    structWork->BfUnitCost = classWork->BfUnitCost;
                    structWork->CmpltSalesRowNo = classWork->CmpltSalesRowNo;
                    structWork->CmpltGoodsMakerCd = classWork->CmpltGoodsMakerCd;
                    structWork->CmpltMakerName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CmpltMakerName).ToPointer());
                    structWork->CmpltMakerKanaName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CmpltMakerKanaName).ToPointer());
                    structWork->CmpltGoodsName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CmpltGoodsName).ToPointer());
                    structWork->CmpltShipmentCnt = classWork->CmpltShipmentCnt;
                    structWork->CmpltSalesUnPrcFl = classWork->CmpltSalesUnPrcFl;
                    structWork->CmpltSalesMoney = classWork->CmpltSalesMoney;
                    structWork->CmpltSalesUnitCost = classWork->CmpltSalesUnitCost;
                    structWork->CmpltCost = classWork->CmpltCost;
                    structWork->CmpltPartySalSlNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CmpltPartySalSlNum).ToPointer());
                    structWork->CmpltNote = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CmpltNote).ToPointer());
                    structWork->PrtGoodsNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PrtGoodsNo).ToPointer());
                    structWork->PrtMakerCode = classWork->PrtMakerCode;
                    structWork->PrtMakerName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PrtMakerName).ToPointer());
					structWork->EditStatus = classWork->EditStatus;
					structWork->RowStatus = classWork->RowStatus;
					structWork->SalesMoneyInputDiv = classWork->SalesMoneyInputDiv;
					structWork->ShipmentCntDisplay = classWork->ShipmentCntDisplay;
					structWork->SupplierStockDisplay = classWork->SupplierStockDisplay;
					structWork->ListPriceDisplay = classWork->ListPriceDisplay;
					structWork->StockDate = classWork->StockDate.Ticks;

					structWork->BoCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BoCode).ToPointer());
					structWork->SupplierCdForOrder = classWork->SupplierCdForOrder;
					structWork->SupplierSnmForOrder = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SupplierSnmForOrder).ToPointer());

					structWork->DeliveredGoodsDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DeliveredGoodsDivNm).ToPointer());
					structWork->FollowDeliGoodsDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FollowDeliGoodsDivNm).ToPointer());
					structWork->UOEResvdSectionNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UOEResvdSectionNm).ToPointer());

					structWork->UOEDeliGoodsDiv = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UOEDeliGoodsDiv).ToPointer());
					structWork->FollowDeliGoodsDiv = static_cast<BSTR>(Marshal::StringToBSTR(classWork->FollowDeliGoodsDiv).ToPointer());
					structWork->UOEResvdSection = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UOEResvdSection).ToPointer());
					structWork->PartySalesSlipNum = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PartySalesSlipNum).ToPointer());
					structWork->AcceptAnOrderNo = classWork->AcceptAnOrderNo;
					structWork->SearchPartsModeState = classWork->SearchPartsModeState;

				    //>>>2010/05/30
					//structWork->CampaignCode = classWork->CampaignCode;
					//structWork->CampaignName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CampaignName).ToPointer());
					//structWork->GoodsDivCd = classWork->GoodsDivCd;
					//structWork->AnswerDelivDate = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AnswerDelivDate).ToPointer());
					structWork->RecycleDiv = classWork->RecycleDiv;
					structWork->RecycleDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RecycleDivNm).ToPointer());
					//structWork->WayToAcptOdr = classWork->WayToAcptOdr;
					structWork->GoodsMngNo = classWork->GoodsMngNo;
					//structWork->InqRowNumber = classWork->InqRowNumber;
					//structWork->InqRowNumDerivedNo = classWork->InqRowNumDerivedNo;
					//<<<2010/05/30
                }

				void CopyClassToStruct_CustomArrayA2(ArrayList^ arrayWork, StructCustomArrayA2 *structWork){
                    if (arrayWork->Count > 0){
                        StructSalesDetail* csafield1 = new StructSalesDetail[arrayWork->Count];
                        for (int i = 0; i < arrayWork->Count; i++){
                            CopyClassToStruct_SalesDetail((SalesDetail^)arrayWork[i], &csafield1[i]);
                        }
                        structWork->Csafield1 = csafield1;
                        structWork->Csafield1Count = arrayWork->Count - 0;
                    } else {
                        structWork->Csafield1 = nullptr;
                        structWork->Csafield1Count = 0;
                    }
                }

				// add by Zhangkai end

				// add by Lizc start
				void CopyClassToStruct_HeaderFocusConstruction(Broadleaf::Windows::Forms::HeaderFocusConstruction ^classWork, StructHeaderFocusConstruction *structWork){
                    structWork->Key = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Key).ToPointer());
                    structWork->Caption = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Caption).ToPointer());
                    structWork->EnterStop = classWork->EnterStop;
                }

                void CopyClassToStruct_FooterFocusConstruction(Broadleaf::Windows::Forms::FooterFocusConstruction ^classWork, StructFooterFocusConstruction *structWork){
                    structWork->Key = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Key).ToPointer());
                    structWork->Caption = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Caption).ToPointer());
                    structWork->EnterStop = classWork->EnterStop;
                }

                void CopyClassToStruct_CustomArrayB6(ArrayList^ arrayWork, StructCustomArrayB6 *structWork){
                    if (arrayWork->Count > 0){
                        StructFooterFocusConstruction* csafield1 = new StructFooterFocusConstruction[arrayWork->Count];
                        for (int i = 0; i < arrayWork->Count; i++){
							CopyClassToStruct_FooterFocusConstruction((Broadleaf::Windows::Forms::FooterFocusConstruction^)arrayWork[i], &csafield1[i]);
                        }
                        structWork->Csafield1 = csafield1;
                        structWork->Csafield1Count = arrayWork->Count - 0;
                    } else {
                        structWork->Csafield1 = nullptr;
                        structWork->Csafield1Count = 0;
                    }
                }

                void CopyClassToStruct_CustomArrayB5(ArrayList^ arrayWork, StructCustomArrayB5 *structWork){
                    if (arrayWork->Count > 0){
                        StructHeaderFocusConstruction* csafield1 = new StructHeaderFocusConstruction[arrayWork->Count];
                        for (int i = 0; i < arrayWork->Count; i++){
                            CopyClassToStruct_HeaderFocusConstruction((Broadleaf::Windows::Forms::HeaderFocusConstruction^)arrayWork[i], &csafield1[i]);
                        }
                        structWork->Csafield1 = csafield1;
                        structWork->Csafield1Count = arrayWork->Count - 0;
                    } else {
                        structWork->Csafield1 = nullptr;
                        structWork->Csafield1Count = 0;
                    }
                }
				// add by Lizc end

				// add by Yangmj start

				// add by Yangmj end

				// add by Tanhong start

				// add by Tanhong end

				// C++メモリ開放処理

				// add by gaofeng start
                __declspec(dllexport) void __stdcall FreeCustomerSearchRet(StructCustomerSearchRet *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].Address1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Address3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Address4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerEpCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerSecCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerSubCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HomeTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HonorificTitle));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Kana));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MngSectionCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Name));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Name2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OfficeTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PortableTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PostNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SearchTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Snm));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

				// C++メモリ開放処理

                __declspec(dllexport) void __stdcall FreeSalesSlip(StructSalesSlip *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesSlipNum));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SectionCode));
						Marshal::FreeBSTR(IntPtr(resultList[i].SubSectionName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DebitNLnkSalesSlNum));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesInpSecCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DemandAddUpSecCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ResultsAddUpSecCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateSecCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateFormNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InputAgenCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InputAgenNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesInputCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesInputName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FrontEmployeeCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FrontEmployeeNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesEmployeeCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesEmployeeNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ClaimSnm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerName2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerSnm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HonorificTitle));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OutputName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeName2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseePostNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeAddr1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeAddr3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeAddr4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddresseeFaxNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PartySaleSlipNum));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipNote));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipNote2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipNote3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RetGoodsReason));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UoeRemark1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UoeRemark2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BusinessTypeName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OrderNumber));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DeliveredGoodsDivNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesAreaName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipPrtSetPaperId));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateSubject));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Footnotes1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Footnotes2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateTitle1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateTitle2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateTitle3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateTitle4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateTitle5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateNote1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateNote2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateNote3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateNote4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstimateNote5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdEmployeeCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdAssemblyId1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdAssemblyId2));
						Marshal::FreeBSTR(IntPtr(resultList[i].CustWarehouseCd));
						//>>>2010/05/30
						////Marshal::FreeBSTR(IntPtr(resultList[i].OnlineKindDiv));
						Marshal::FreeBSTR(IntPtr(resultList[i].InqOriginalEpCd));
						Marshal::FreeBSTR(IntPtr(resultList[i].InqOriginalSecCd));
						////Marshal::FreeBSTR(IntPtr(resultList[i].AnswerDiv));
						////Marshal::FreeBSTR(IntPtr(resultList[i].InquiryNumber));
						////Marshal::FreeBSTR(IntPtr(resultList[i].InqOrdDivCd));
						//<<<2010/05/30
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

				__declspec(dllexport) void __stdcall FreeCarMangInputExtraInfo(StructCarMangInputExtraInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpec6));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AddiCarSpecTitle6));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BodyName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarAddInfo1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarAddInfo2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarMngCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CarNote));
                        //Marshal::FreeBSTR(IntPtr(resultList[i].CategoryObjAry));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CategorySignModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ColorCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ColorName1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerCodeForGuide));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EDivNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineDisplaceNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EngineModelNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ExhaustGasSign));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FrameModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FrameNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].FullModel));
                        //Marshal::FreeBSTR(IntPtr(resultList[i].FullModelFixedNoAry));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MakerFullName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MakerHalfName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelFullName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelGradeNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelGradeSname));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ModelHalfName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlate1Name));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlate2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlate3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].NumberPlateForGuide));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ProduceTypeOfYearNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RelevanceModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SeriesModel));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ShiftNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SystematicName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TransmissionNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TrimCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TrimName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].WheelDriveMethodNm));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }
                // add by gaofeng end

				// add by Zhangkai start
				__declspec(dllexport) void __stdcall FreeSalesDetail(StructSalesDetail *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesSlipNum));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SectionCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MakerName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MakerKanaName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].GoodsNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].GoodsName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].GoodsNameKana));
                        Marshal::FreeBSTR(IntPtr(resultList[i].GoodsLGroupName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].GoodsMGroupName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BLGroupName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BLGoodsFullName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseGanreName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].WarehouseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].WarehouseName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].WarehouseShelfNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].GoodsRateRank));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateSectPriceUnPrc));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateDivLPrice));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateSectSalUnPrc));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateDivSalUnPrc));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateSectCstUnPrc));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateDivUnCst));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateBLGoodsName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateGoodsRateGrpNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RateBLGroupName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PrtBLGoodsName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesCdNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PartySlipNumDtl));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DtlNote));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SupplierSnm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OrderNumber));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipMemo1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipMemo2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SlipMemo3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InsideMemo1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InsideMemo2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InsideMemo3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CmpltMakerName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CmpltMakerKanaName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CmpltGoodsName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CmpltPartySalSlNum));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CmpltNote));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PrtGoodsNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PrtMakerName));
						Marshal::FreeBSTR(IntPtr(resultList[i].BoCode));
						Marshal::FreeBSTR(IntPtr(resultList[i].SupplierSnmForOrder));
						Marshal::FreeBSTR(IntPtr(resultList[i].DeliveredGoodsDivNm));
						Marshal::FreeBSTR(IntPtr(resultList[i].FollowDeliGoodsDivNm));
						Marshal::FreeBSTR(IntPtr(resultList[i].UOEResvdSectionNm));
						Marshal::FreeBSTR(IntPtr(resultList[i].UOEDeliGoodsDiv));
						Marshal::FreeBSTR(IntPtr(resultList[i].FollowDeliGoodsDiv));
						Marshal::FreeBSTR(IntPtr(resultList[i].UOEResvdSection));
						Marshal::FreeBSTR(IntPtr(resultList[i].PartySalesSlipNum));
						//>>>2010/05/30
						////Marshal::FreeBSTR(IntPtr(resultList[i].CampaignCode));
						//Marshal::FreeBSTR(IntPtr(resultList[i].CampaignName));
						////Marshal::FreeBSTR(IntPtr(resultList[i].GoodsDivCd));
						//Marshal::FreeBSTR(IntPtr(resultList[i].AnswerDelivDate));
						////Marshal::FreeBSTR(IntPtr(resultList[i].RecycleDiv));
						Marshal::FreeBSTR(IntPtr(resultList[i].RecycleDivNm));
						////Marshal::FreeBSTR(IntPtr(resultList[i].WayToAcptOdr));
						////Marshal::FreeBSTR(IntPtr(resultList[i].GoodsMngNo));
						////Marshal::FreeBSTR(IntPtr(resultList[i].InqRowNumber));
						////Marshal::FreeBSTR(IntPtr(resultList[i].InqRowNumDerivedNo));
						//<<<2010/05/30
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

				__declspec(dllexport) void __stdcall FreeCustomArrayA2(StructCustomArrayA2 *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){
                        FreeSalesDetail(resultList[i].Csafield1, resultList[i].Csafield1Count);
                    }
                }

				// add by Zhangkai end

				// add by Lizc start
				void CopyStructToClass_CustomerInfo(StructCustomerInfo *structWork, CustomerInfo ^classWork){
                    classWork->AcceptWholeSale = structWork->AcceptWholeSale;
                    classWork->AccountNoInfo1 = gcnew String(structWork->AccountNoInfo1);
                    classWork->AccountNoInfo2 = gcnew String(structWork->AccountNoInfo2);
                    classWork->AccountNoInfo3 = gcnew String(structWork->AccountNoInfo3);
                    classWork->AccRecDivCd = structWork->AccRecDivCd;
                    classWork->AcpOdrrSlipPrtDiv = structWork->AcpOdrrSlipPrtDiv;
                    classWork->Address1 = gcnew String(structWork->Address1);
                    classWork->Address3 = gcnew String(structWork->Address3);
                    classWork->Address4 = gcnew String(structWork->Address4);
                    classWork->BillCollecterCd = gcnew String(structWork->BillCollecterCd);
                    classWork->BillCollecterNm = gcnew String(structWork->BillCollecterNm);
                    classWork->BillHonorificTtl = gcnew String(structWork->BillHonorificTtl);
                    classWork->BillHonorTtlPrtDiv = structWork->BillHonorTtlPrtDiv;
                    classWork->BillOutputCode = structWork->BillOutputCode;
                    classWork->BillOutPutCodeNm = gcnew String(structWork->BillOutPutCodeNm);
                    classWork->BillOutputName = gcnew String(structWork->BillOutputName);
                    classWork->BillPartsNoPrtCd = structWork->BillPartsNoPrtCd;
                    classWork->BusinessTypeCode = structWork->BusinessTypeCode;
                    classWork->BusinessTypeName = gcnew String(structWork->BusinessTypeName);
                    classWork->CarMngDivCd = structWork->CarMngDivCd;
                    classWork->ClaimCode = structWork->ClaimCode;
                    classWork->ClaimName = gcnew String(structWork->ClaimName);
                    classWork->ClaimName2 = gcnew String(structWork->ClaimName2);
                    classWork->ClaimSectionCode = gcnew String(structWork->ClaimSectionCode);
                    classWork->ClaimSectionName = gcnew String(structWork->ClaimSectionName);
                    classWork->ClaimSnm = gcnew String(structWork->ClaimSnm);
                    classWork->CollectCond = structWork->CollectCond;
                    classWork->CollectMoneyCode = structWork->CollectMoneyCode;
                    classWork->CollectMoneyDay = structWork->CollectMoneyDay;
                    classWork->CollectMoneyName = gcnew String(structWork->CollectMoneyName);
                    classWork->CollectSight = structWork->CollectSight;
                    classWork->ConsTaxLayMethod = structWork->ConsTaxLayMethod;
                    classWork->CorporateDivCode = structWork->CorporateDivCode;
                    classWork->CreateDateTime = DateTime(structWork->CreateDateTime);
                    classWork->CreateDateTimeAdFormal = gcnew String(structWork->CreateDateTimeAdFormal);
                    classWork->CreateDateTimeAdInFormal = gcnew String(structWork->CreateDateTimeAdInFormal);
                    classWork->CreateDateTimeJpFormal = gcnew String(structWork->CreateDateTimeJpFormal);
                    classWork->CreateDateTimeJpInFormal = gcnew String(structWork->CreateDateTimeJpInFormal);
                    classWork->CreditMngCode = structWork->CreditMngCode;
                    classWork->CustAgentChgDate = DateTime(structWork->CustAgentChgDate);
                    classWork->CustAnalysCode1 = structWork->CustAnalysCode1;
                    classWork->CustAnalysCode2 = structWork->CustAnalysCode2;
                    classWork->CustAnalysCode3 = structWork->CustAnalysCode3;
                    classWork->CustAnalysCode4 = structWork->CustAnalysCode4;
                    classWork->CustAnalysCode5 = structWork->CustAnalysCode5;
                    classWork->CustAnalysCode6 = structWork->CustAnalysCode6;
                    classWork->CustCTaXLayRefCd = structWork->CustCTaXLayRefCd;
                    classWork->CustomerAgent = gcnew String(structWork->CustomerAgent);
                    classWork->CustomerAgentCd = gcnew String(structWork->CustomerAgentCd);
                    classWork->CustomerAgentNm = gcnew String(structWork->CustomerAgentNm);
                    classWork->CustomerAttributeDiv = structWork->CustomerAttributeDiv;
                    classWork->CustomerCode = structWork->CustomerCode;
                    classWork->CustomerEpCode = gcnew String(structWork->CustomerEpCode);
                    classWork->CustomerSecCode = gcnew String(structWork->CustomerSecCode);
                    classWork->CustomerSlipNoDiv = structWork->CustomerSlipNoDiv;
                    classWork->CustomerSnm = gcnew String(structWork->CustomerSnm);
                    classWork->CustomerSubCode = gcnew String(structWork->CustomerSubCode);
                    classWork->CustSlipNoMngCd = structWork->CustSlipNoMngCd;
                    classWork->CustWarehouseCd = gcnew String(structWork->CustWarehouseCd);
                    classWork->CustWarehouseName = gcnew String(structWork->CustWarehouseName);
                    classWork->DefSalesSlipCd = structWork->DefSalesSlipCd;
                    classWork->DeliHonorificTtl = gcnew String(structWork->DeliHonorificTtl);
                    classWork->DeliHonorTtlPrtDiv = structWork->DeliHonorTtlPrtDiv;
                    classWork->DeliPartsNoPrtCd = structWork->DeliPartsNoPrtCd;
                    classWork->DepoBankCode = structWork->DepoBankCode;
                    classWork->DepoBankName = gcnew String(structWork->DepoBankName);
                    classWork->DepoDelCode = structWork->DepoDelCode;
                    classWork->DmOutCode = structWork->DmOutCode;
                    classWork->DmOutName = gcnew String(structWork->DmOutName);
                    classWork->EnterpriseCode = gcnew String(structWork->EnterpriseCode);
                    classWork->EnterpriseName = gcnew String(structWork->EnterpriseName);
                    classWork->EstimatePrtDiv = structWork->EstimatePrtDiv;
                    classWork->EstmHonorificTtl = gcnew String(structWork->EstmHonorificTtl);
                    classWork->EstmHonorTtlPrtDiv = structWork->EstmHonorTtlPrtDiv;
                    array<Byte> ^GuidFileHeaderGuidByteArray = gcnew array<Byte>(16);
                    Marshal::Copy(IntPtr(&structWork->GuidFileHeaderGuid), GuidFileHeaderGuidByteArray, 0, 16);
                    //classWork->GuidFileHeaderGuid = Guid(GuidFileHeaderGuidByteArray);
                    classWork->HomeFaxNo = gcnew String(structWork->HomeFaxNo);
                    classWork->HomeFaxNoDspName = gcnew String(structWork->HomeFaxNoDspName);
                    classWork->HomeTelNo = gcnew String(structWork->HomeTelNo);
                    classWork->HomeTelNoDspName = gcnew String(structWork->HomeTelNoDspName);
                    classWork->HonorificTitle = gcnew String(structWork->HonorificTitle);
                    classWork->InpSectionCode = gcnew String(structWork->InpSectionCode);
                    classWork->InpSectionName = gcnew String(structWork->InpSectionName);
                    //classWork->IsCustomer = structWork->IsCustomer;
                    //classWork->IsReceiver = structWork->IsReceiver;
                    classWork->JobTypeCode = structWork->JobTypeCode;
                    classWork->JobTypeName = gcnew String(structWork->JobTypeName);
                    classWork->Kana = gcnew String(structWork->Kana);
                    classWork->LavorRateRank = structWork->LavorRateRank;
                    classWork->LogicalDeleteCode = structWork->LogicalDeleteCode;
                    classWork->MailAddress1 = gcnew String(structWork->MailAddress1);
                    classWork->MailAddress2 = gcnew String(structWork->MailAddress2);
                    classWork->MailAddrKindCode1 = structWork->MailAddrKindCode1;
                    classWork->MailAddrKindCode2 = structWork->MailAddrKindCode2;
                    classWork->MailAddrKindName1 = gcnew String(structWork->MailAddrKindName1);
                    classWork->MailAddrKindName2 = gcnew String(structWork->MailAddrKindName2);
                    classWork->MailSendCode1 = structWork->MailSendCode1;
                    classWork->MailSendCode2 = structWork->MailSendCode2;
                    classWork->MailSendName1 = gcnew String(structWork->MailSendName1);
                    classWork->MailSendName2 = gcnew String(structWork->MailSendName2);
                    classWork->MainContactCode = structWork->MainContactCode;
                    classWork->MainContactName = gcnew String(structWork->MainContactName);
                    classWork->MainSendMailAddrCd = structWork->MainSendMailAddrCd;
                    classWork->MngSectionCode = gcnew String(structWork->MngSectionCode);
                    classWork->MngSectionName = gcnew String(structWork->MngSectionName);
                    classWork->MobileTelNoDspName = gcnew String(structWork->MobileTelNoDspName);
                    classWork->Name = gcnew String(structWork->Name);
                    classWork->Name2 = gcnew String(structWork->Name2);
                    classWork->Note1 = gcnew String(structWork->Note1);
                    classWork->Note10 = gcnew String(structWork->Note10);
                    classWork->Note2 = gcnew String(structWork->Note2);
                    classWork->Note3 = gcnew String(structWork->Note3);
                    classWork->Note4 = gcnew String(structWork->Note4);
                    classWork->Note5 = gcnew String(structWork->Note5);
                    classWork->Note6 = gcnew String(structWork->Note6);
                    classWork->Note7 = gcnew String(structWork->Note7);
                    classWork->Note8 = gcnew String(structWork->Note8);
                    classWork->Note9 = gcnew String(structWork->Note9);
                    classWork->NTimeCalcStDate = structWork->NTimeCalcStDate;
                    classWork->OfficeFaxNo = gcnew String(structWork->OfficeFaxNo);
                    classWork->OfficeFaxNoDspName = gcnew String(structWork->OfficeFaxNoDspName);
                    classWork->OfficeTelNo = gcnew String(structWork->OfficeTelNo);
                    classWork->OfficeTelNoDspName = gcnew String(structWork->OfficeTelNoDspName);
                    classWork->OldCustomerAgentCd = gcnew String(structWork->OldCustomerAgentCd);
                    classWork->OldCustomerAgentNm = gcnew String(structWork->OldCustomerAgentNm);
                    classWork->OnlineKindDiv = structWork->OnlineKindDiv;
                    classWork->OthersTelNo = gcnew String(structWork->OthersTelNo);
                    classWork->OtherTelNoDspName = gcnew String(structWork->OtherTelNoDspName);
                    classWork->OutputName = gcnew String(structWork->OutputName);
                    classWork->OutputNameCode = structWork->OutputNameCode;
                    classWork->PortableTelNo = gcnew String(structWork->PortableTelNo);
                    classWork->PostNo = gcnew String(structWork->PostNo);
                    classWork->PrslOrCorpDivNm = gcnew String(structWork->PrslOrCorpDivNm);
                    classWork->PureCode = structWork->PureCode;
                    classWork->QrcodePrtCd = structWork->QrcodePrtCd;
                    classWork->ReceiptOutputCode = structWork->ReceiptOutputCode;
                    classWork->RectHonorificTtl = gcnew String(structWork->RectHonorificTtl);
                    classWork->RectHonorTtlPrtDiv = structWork->RectHonorTtlPrtDiv;
                    classWork->SalesAreaCode = structWork->SalesAreaCode;
                    classWork->SalesAreaName = gcnew String(structWork->SalesAreaName);
                    classWork->SalesCnsTaxFrcProcCd = structWork->SalesCnsTaxFrcProcCd;
                    classWork->SalesMoneyFrcProcCd = structWork->SalesMoneyFrcProcCd;
                    classWork->SalesSlipPrtDiv = structWork->SalesSlipPrtDiv;
                    classWork->SalesUnPrcFrcProcCd = structWork->SalesUnPrcFrcProcCd;
                    classWork->SearchTelNo = gcnew String(structWork->SearchTelNo);
                    classWork->ShipmSlipPrtDiv = structWork->ShipmSlipPrtDiv;
                    classWork->SlipTtlPrn = structWork->SlipTtlPrn;
                    classWork->TotalAmntDspWayRef = structWork->TotalAmntDspWayRef;
                    classWork->TotalAmountDispWayCd = structWork->TotalAmountDispWayCd;
                    classWork->TotalDay = structWork->TotalDay;
                    classWork->TransStopDate = DateTime(structWork->TransStopDate);
                    classWork->UOESlipPrtDiv = structWork->UOESlipPrtDiv;
                    classWork->UpdAssemblyId1 = gcnew String(structWork->UpdAssemblyId1);
                    classWork->UpdAssemblyId2 = gcnew String(structWork->UpdAssemblyId2);
                    classWork->UpdateDateTime = DateTime(structWork->UpdateDateTime);
                    classWork->UpdateDateTimeAdFormal = gcnew String(structWork->UpdateDateTimeAdFormal);
                    classWork->UpdateDateTimeAdInFormal = gcnew String(structWork->UpdateDateTimeAdInFormal);
                    classWork->UpdateDateTimeJpFormal = gcnew String(structWork->UpdateDateTimeJpFormal);
                    classWork->UpdateDateTimeJpInFormal = gcnew String(structWork->UpdateDateTimeJpInFormal);
                    classWork->UpdEmployeeCode = gcnew String(structWork->UpdEmployeeCode);
                    classWork->UpdEmployeeName = gcnew String(structWork->UpdEmployeeName);
                }

				void CopyClassToStruct_CustomerInfo(CustomerInfo ^classWork, StructCustomerInfo *structWork){
                    structWork->AcceptWholeSale = classWork->AcceptWholeSale;
                    structWork->AccountNoInfo1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AccountNoInfo1).ToPointer());
                    structWork->AccountNoInfo2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AccountNoInfo2).ToPointer());
                    structWork->AccountNoInfo3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->AccountNoInfo3).ToPointer());
                    structWork->AccRecDivCd = classWork->AccRecDivCd;
                    structWork->AcpOdrrSlipPrtDiv = classWork->AcpOdrrSlipPrtDiv;
                    structWork->Address1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Address1).ToPointer());
                    structWork->Address3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Address3).ToPointer());
                    structWork->Address4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Address4).ToPointer());
                    structWork->BillCollecterCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BillCollecterCd).ToPointer());
                    structWork->BillCollecterNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BillCollecterNm).ToPointer());
                    structWork->BillHonorificTtl = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BillHonorificTtl).ToPointer());
                    structWork->BillHonorTtlPrtDiv = classWork->BillHonorTtlPrtDiv;
                    structWork->BillOutputCode = classWork->BillOutputCode;
                    structWork->BillOutPutCodeNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BillOutPutCodeNm).ToPointer());
                    structWork->BillOutputName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BillOutputName).ToPointer());
                    structWork->BillPartsNoPrtCd = classWork->BillPartsNoPrtCd;
                    structWork->BusinessTypeCode = classWork->BusinessTypeCode;
                    structWork->BusinessTypeName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->BusinessTypeName).ToPointer());
                    structWork->CarMngDivCd = classWork->CarMngDivCd;
                    structWork->ClaimCode = classWork->ClaimCode;
                    structWork->ClaimName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ClaimName).ToPointer());
                    structWork->ClaimName2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ClaimName2).ToPointer());
                    structWork->ClaimSectionCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ClaimSectionCode).ToPointer());
                    structWork->ClaimSectionName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ClaimSectionName).ToPointer());
                    structWork->ClaimSnm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->ClaimSnm).ToPointer());
                    structWork->CollectCond = classWork->CollectCond;
                    structWork->CollectMoneyCode = classWork->CollectMoneyCode;
                    structWork->CollectMoneyDay = classWork->CollectMoneyDay;
                    structWork->CollectMoneyName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CollectMoneyName).ToPointer());
                    structWork->CollectSight = classWork->CollectSight;
                    structWork->ConsTaxLayMethod = classWork->ConsTaxLayMethod;
                    structWork->CorporateDivCode = classWork->CorporateDivCode;
                    structWork->CreateDateTime = classWork->CreateDateTime.Ticks;
                    structWork->CreateDateTimeAdFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeAdFormal).ToPointer());
                    structWork->CreateDateTimeAdInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeAdInFormal).ToPointer());
                    structWork->CreateDateTimeJpFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeJpFormal).ToPointer());
                    structWork->CreateDateTimeJpInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CreateDateTimeJpInFormal).ToPointer());
                    structWork->CreditMngCode = classWork->CreditMngCode;
					structWork->CustAgentChgDate = classWork->CustAgentChgDate.Ticks;
                    structWork->CustAnalysCode1 = classWork->CustAnalysCode1;
                    structWork->CustAnalysCode2 = classWork->CustAnalysCode2;
                    structWork->CustAnalysCode3 = classWork->CustAnalysCode3;
                    structWork->CustAnalysCode4 = classWork->CustAnalysCode4;
                    structWork->CustAnalysCode5 = classWork->CustAnalysCode5;
                    structWork->CustAnalysCode6 = classWork->CustAnalysCode6;
                    structWork->CustCTaXLayRefCd = classWork->CustCTaXLayRefCd;
                    structWork->CustomerAgent = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerAgent).ToPointer());
                    structWork->CustomerAgentCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerAgentCd).ToPointer());
                    structWork->CustomerAgentNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerAgentNm).ToPointer());
                    structWork->CustomerAttributeDiv = classWork->CustomerAttributeDiv;
                    structWork->CustomerCode = classWork->CustomerCode;
                    structWork->CustomerEpCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerEpCode).ToPointer());
                    structWork->CustomerSecCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerSecCode).ToPointer());
                    structWork->CustomerSlipNoDiv = classWork->CustomerSlipNoDiv;
                    structWork->CustomerSnm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerSnm).ToPointer());
                    structWork->CustomerSubCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustomerSubCode).ToPointer());
                    structWork->CustSlipNoMngCd = classWork->CustSlipNoMngCd;
                    structWork->CustWarehouseCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustWarehouseCd).ToPointer());
                    structWork->CustWarehouseName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->CustWarehouseName).ToPointer());
                    structWork->DefSalesSlipCd = classWork->DefSalesSlipCd;
                    structWork->DeliHonorificTtl = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DeliHonorificTtl).ToPointer());
                    structWork->DeliHonorTtlPrtDiv = classWork->DeliHonorTtlPrtDiv;
                    structWork->DeliPartsNoPrtCd = classWork->DeliPartsNoPrtCd;
                    structWork->DepoBankCode = classWork->DepoBankCode;
                    structWork->DepoBankName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DepoBankName).ToPointer());
                    structWork->DepoDelCode = classWork->DepoDelCode;
                    structWork->DmOutCode = classWork->DmOutCode;
                    structWork->DmOutName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->DmOutName).ToPointer());
                    structWork->EnterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseCode).ToPointer());
                    structWork->EnterpriseName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EnterpriseName).ToPointer());
                    structWork->EstimatePrtDiv = classWork->EstimatePrtDiv;
                    structWork->EstmHonorificTtl = static_cast<BSTR>(Marshal::StringToBSTR(classWork->EstmHonorificTtl).ToPointer());
                    structWork->EstmHonorTtlPrtDiv = classWork->EstmHonorTtlPrtDiv;
                    //Marshal::Copy(classWork->GuidFileHeaderGuid.ToByteArray(), 0, IntPtr(&structWork->GuidFileHeaderGuid), 16);
                    structWork->HomeFaxNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HomeFaxNo).ToPointer());
                    structWork->HomeFaxNoDspName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HomeFaxNoDspName).ToPointer());
                    structWork->HomeTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HomeTelNo).ToPointer());
                    structWork->HomeTelNoDspName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HomeTelNoDspName).ToPointer());
                    structWork->HonorificTitle = static_cast<BSTR>(Marshal::StringToBSTR(classWork->HonorificTitle).ToPointer());
                    structWork->InpSectionCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InpSectionCode).ToPointer());
                    structWork->InpSectionName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->InpSectionName).ToPointer());
                    structWork->IsCustomer = classWork->IsCustomer;
                    structWork->IsReceiver = classWork->IsReceiver;
                    structWork->JobTypeCode = classWork->JobTypeCode;
                    structWork->JobTypeName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->JobTypeName).ToPointer());
                    structWork->Kana = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Kana).ToPointer());
                    structWork->LavorRateRank = classWork->LavorRateRank;
                    structWork->LogicalDeleteCode = classWork->LogicalDeleteCode;
                    structWork->MailAddress1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MailAddress1).ToPointer());
                    structWork->MailAddress2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MailAddress2).ToPointer());
                    structWork->MailAddrKindCode1 = classWork->MailAddrKindCode1;
                    structWork->MailAddrKindCode2 = classWork->MailAddrKindCode2;
                    structWork->MailAddrKindName1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MailAddrKindName1).ToPointer());
                    structWork->MailAddrKindName2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MailAddrKindName2).ToPointer());
                    structWork->MailSendCode1 = classWork->MailSendCode1;
                    structWork->MailSendCode2 = classWork->MailSendCode2;
                    structWork->MailSendName1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MailSendName1).ToPointer());
                    structWork->MailSendName2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MailSendName2).ToPointer());
                    structWork->MainContactCode = classWork->MainContactCode;
                    structWork->MainContactName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MainContactName).ToPointer());
                    structWork->MainSendMailAddrCd = classWork->MainSendMailAddrCd;
                    structWork->MngSectionCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MngSectionCode).ToPointer());
                    structWork->MngSectionName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MngSectionName).ToPointer());
                    structWork->MobileTelNoDspName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->MobileTelNoDspName).ToPointer());
                    structWork->Name = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Name).ToPointer());
                    structWork->Name2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Name2).ToPointer());
                    structWork->Note1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note1).ToPointer());
                    structWork->Note10 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note10).ToPointer());
                    structWork->Note2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note2).ToPointer());
                    structWork->Note3 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note3).ToPointer());
                    structWork->Note4 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note4).ToPointer());
                    structWork->Note5 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note5).ToPointer());
                    structWork->Note6 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note6).ToPointer());
                    structWork->Note7 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note7).ToPointer());
                    structWork->Note8 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note8).ToPointer());
                    structWork->Note9 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->Note9).ToPointer());
                    structWork->NTimeCalcStDate = classWork->NTimeCalcStDate;
                    structWork->OfficeFaxNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OfficeFaxNo).ToPointer());
                    structWork->OfficeFaxNoDspName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OfficeFaxNoDspName).ToPointer());
                    structWork->OfficeTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OfficeTelNo).ToPointer());
                    structWork->OfficeTelNoDspName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OfficeTelNoDspName).ToPointer());
                    structWork->OldCustomerAgentCd = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OldCustomerAgentCd).ToPointer());
                    structWork->OldCustomerAgentNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OldCustomerAgentNm).ToPointer());
                    structWork->OnlineKindDiv = classWork->OnlineKindDiv;
                    structWork->OthersTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OthersTelNo).ToPointer());
                    structWork->OtherTelNoDspName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OtherTelNoDspName).ToPointer());
                    structWork->OutputName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->OutputName).ToPointer());
                    structWork->OutputNameCode = classWork->OutputNameCode;
                    structWork->PortableTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PortableTelNo).ToPointer());
                    structWork->PostNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PostNo).ToPointer());
                    structWork->PrslOrCorpDivNm = static_cast<BSTR>(Marshal::StringToBSTR(classWork->PrslOrCorpDivNm).ToPointer());
                    structWork->PureCode = classWork->PureCode;
                    structWork->QrcodePrtCd = classWork->QrcodePrtCd;
                    structWork->ReceiptOutputCode = classWork->ReceiptOutputCode;
                    structWork->RectHonorificTtl = static_cast<BSTR>(Marshal::StringToBSTR(classWork->RectHonorificTtl).ToPointer());
                    structWork->RectHonorTtlPrtDiv = classWork->RectHonorTtlPrtDiv;
                    structWork->SalesAreaCode = classWork->SalesAreaCode;
                    structWork->SalesAreaName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SalesAreaName).ToPointer());
                    structWork->SalesCnsTaxFrcProcCd = classWork->SalesCnsTaxFrcProcCd;
                    structWork->SalesMoneyFrcProcCd = classWork->SalesMoneyFrcProcCd;
                    structWork->SalesSlipPrtDiv = classWork->SalesSlipPrtDiv;
                    structWork->SalesUnPrcFrcProcCd = classWork->SalesUnPrcFrcProcCd;
                    structWork->SearchTelNo = static_cast<BSTR>(Marshal::StringToBSTR(classWork->SearchTelNo).ToPointer());
                    structWork->ShipmSlipPrtDiv = classWork->ShipmSlipPrtDiv;
                    structWork->SlipTtlPrn = classWork->SlipTtlPrn;
                    structWork->TotalAmntDspWayRef = classWork->TotalAmntDspWayRef;
                    structWork->TotalAmountDispWayCd = classWork->TotalAmountDispWayCd;
                    structWork->TotalDay = classWork->TotalDay;
					structWork->TransStopDate = classWork->TransStopDate.Ticks;
                    structWork->UOESlipPrtDiv = classWork->UOESlipPrtDiv;
                    structWork->UpdAssemblyId1 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdAssemblyId1).ToPointer());
                    structWork->UpdAssemblyId2 = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdAssemblyId2).ToPointer());
                    structWork->UpdateDateTime = classWork->UpdateDateTime.Ticks;
                    structWork->UpdateDateTimeAdFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeAdFormal).ToPointer());
                    structWork->UpdateDateTimeAdInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeAdInFormal).ToPointer());
                    structWork->UpdateDateTimeJpFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeJpFormal).ToPointer());
                    structWork->UpdateDateTimeJpInFormal = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdateDateTimeJpInFormal).ToPointer());
                    structWork->UpdEmployeeCode = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdEmployeeCode).ToPointer());
                    structWork->UpdEmployeeName = static_cast<BSTR>(Marshal::StringToBSTR(classWork->UpdEmployeeName).ToPointer());
                }

				__declspec(dllexport) void __stdcall FreeCustomerInfo(StructCustomerInfo *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].AccountNoInfo1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AccountNoInfo2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].AccountNoInfo3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Address1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Address3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Address4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BillCollecterCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BillCollecterNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BillHonorificTtl));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BillOutPutCodeNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BillOutputName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].BusinessTypeName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ClaimName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ClaimName2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ClaimSectionCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ClaimSectionName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].ClaimSnm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CollectMoneyName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTime));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeAdFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeAdInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeJpFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CreateDateTimeJpInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustAgentChgDate));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerAgent));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerAgentCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerAgentNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerEpCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerSecCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerSnm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustomerSubCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustWarehouseCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].CustWarehouseName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DeliHonorificTtl));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DepoBankName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].DmOutName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterpriseName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EstmHonorificTtl));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HomeFaxNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HomeFaxNoDspName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HomeTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HomeTelNoDspName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].HonorificTitle));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InpSectionCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].InpSectionName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].IsCustomer));
                        Marshal::FreeBSTR(IntPtr(resultList[i].IsReceiver));
                        Marshal::FreeBSTR(IntPtr(resultList[i].JobTypeName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Kana));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MailAddress1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MailAddress2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MailAddrKindName1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MailAddrKindName2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MailSendName1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MailSendName2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MainContactName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MngSectionCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MngSectionName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].MobileTelNoDspName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Name));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Name2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note10));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note3));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note4));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note5));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note6));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note7));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note8));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Note9));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OfficeFaxNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OfficeFaxNoDspName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OfficeTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OfficeTelNoDspName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OldCustomerAgentCd));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OldCustomerAgentNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OthersTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OtherTelNoDspName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].OutputName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PortableTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PostNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].PrslOrCorpDivNm));
                        Marshal::FreeBSTR(IntPtr(resultList[i].RectHonorificTtl));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SalesAreaName));
                        Marshal::FreeBSTR(IntPtr(resultList[i].SearchTelNo));
                        Marshal::FreeBSTR(IntPtr(resultList[i].TransStopDate));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdAssemblyId1));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdAssemblyId2));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTime));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeAdFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeAdInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeJpFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdateDateTimeJpInFormal));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdEmployeeCode));
                        Marshal::FreeBSTR(IntPtr(resultList[i].UpdEmployeeName));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }
                
                __declspec(dllexport) void __stdcall FreeHeaderFocusConstruction(StructHeaderFocusConstruction *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].Key));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Caption));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterStop));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeFooterFocusConstruction(StructFooterFocusConstruction *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                        Marshal::FreeBSTR(IntPtr(resultList[i].Key));
                        Marshal::FreeBSTR(IntPtr(resultList[i].Caption));
                        Marshal::FreeBSTR(IntPtr(resultList[i].EnterStop));
                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCustomArrayB6(StructCustomArrayB6 *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){
                        FreeFooterFocusConstruction(resultList[i].Csafield1, resultList[i].Csafield1Count);
                    }
                }

                __declspec(dllexport) void __stdcall FreeCustomArrayB5(StructCustomArrayB5 *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){
                        FreeHeaderFocusConstruction(resultList[i].Csafield1, resultList[i].Csafield1Count);
                    }
                }
				// add by Lizc end

				// add by Yangmj start

				// add by Yangmj end

				// add by Tanhong start

				// add by Tanhong end
			}
		}
	}
}
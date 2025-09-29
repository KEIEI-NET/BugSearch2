#pragma once
#include<windows.h>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::UIData;
using namespace Broadleaf::Application::Controller;
namespace Broadleaf{
	namespace Application{
		namespace Remoting{
			namespace ParamData{
				// C++/CLI構造体宣言
#pragma pack(push, 1)

                struct StructPosTerminalMg{
                    int PosPCTermCd;
                };

				// -- Add St 2012.07.23 30182 R.Tachiya --
                struct StructAcptAnOdrTtlSt{
                    int EstmCountReflectDiv;
                    int AcpOdrrSlipPrtDiv;
                    int FaxOrderDiv;
                };
				// -- Add St 2012.07.23 30182 R.Tachiya --

                struct StructSalesTtlSt{
                    int AcpOdrAgentDispDiv;
                    int AcpOdrInputDiv;
                    int AutoEntryGoodsDivCd;
                    int BLGoodsCdInpDiv;
                    int BrSlipNote2DispDiv;
                    int BrSlipNote3DispDiv;
                    int CarMngNoDispDiv;
                    int CostDspDivCd;
                    int CustGuideDispDiv;
                    int DtlNoteDispDiv;
                    int GrsProfitDspCd;
                    int InpAgentDispDiv;
                    int InpGrsProfChkLowDiv;
                    int MakerInpDiv;
                    int PartsSearchDivCd;
                    int RetGoodsStockEtyDiv;
                    int RetSlipChngDivCost;
                    int RetSlipChngDivUnPrc;
                    int SalesAgentChngDiv;
                    int SalesStockDiv;
                    int SectDspDivCd;
                    int SlipChngDivCost;
                    int SlipChngDivDate;
                    int SlipChngDivLPrice;
                    int SlipDateClrDivCd;
                    int SupplierInpDiv;
                    int SupplierSlipDelDiv;
                    int UnPrcNonSettingDiv;
					int SlipChngDivUnPrc;
					int InpGrsProfChkUppDiv;
					int DwnPLCdSpDivCd;
					int SalesCdDspDivCd;
					int RentStockDiv;
                };

                struct StructAllDefSet{
                    int EraNameDispCd1;
                    int RemCntAutoDspDiv;
					int GoodsNoInpDiv;
                };

                struct StructCompanyInf{
                    int SecMngDiv;
                };

#pragma pack(pop)
				// C++構造体→.NETクラスコピー処理

                void CopyStructToClass_PosTerminalMg(StructPosTerminalMg *structWork, PosTerminalMg ^classWork){
                    classWork->PosPCTermCd = structWork->PosPCTermCd;
                }

				// -- Add St 2012.07.23 30182 R.Tachiya --
                void CopyStructToClass_AcptAnOdrTtlSt(StructAcptAnOdrTtlSt *structWork, AcptAnOdrTtlSt ^classWork){
					classWork->EstmCountReflectDiv = structWork->EstmCountReflectDiv;
					classWork->AcpOdrrSlipPrtDiv = structWork->AcpOdrrSlipPrtDiv;
					classWork->FaxOrderDiv = structWork->FaxOrderDiv;
                }
				// -- Add Ed 2012.07.23 30182 R.Tachiya --

                void CopyStructToClass_SalesTtlSt(StructSalesTtlSt *structWork, SalesTtlSt ^classWork){
                    classWork->AcpOdrAgentDispDiv = structWork->AcpOdrAgentDispDiv;
                    classWork->AcpOdrInputDiv = structWork->AcpOdrInputDiv;
                    classWork->AutoEntryGoodsDivCd = structWork->AutoEntryGoodsDivCd;
                    classWork->BLGoodsCdInpDiv = structWork->BLGoodsCdInpDiv;
                    classWork->BrSlipNote2DispDiv = structWork->BrSlipNote2DispDiv;
                    classWork->BrSlipNote3DispDiv = structWork->BrSlipNote3DispDiv;
                    classWork->CarMngNoDispDiv = structWork->CarMngNoDispDiv;
                    classWork->CostDspDivCd = structWork->CostDspDivCd;
                    classWork->CustGuideDispDiv = structWork->CustGuideDispDiv;
                    classWork->DtlNoteDispDiv = structWork->DtlNoteDispDiv;
                    array<Byte> ^FileHeaderGuidByteArray = gcnew array<Byte>(16);
                    classWork->FileHeaderGuid = Guid(FileHeaderGuidByteArray);
                    classWork->GrsProfitDspCd = structWork->GrsProfitDspCd;
                    classWork->InpAgentDispDiv = structWork->InpAgentDispDiv;
                    classWork->InpGrsProfChkLowDiv = structWork->InpGrsProfChkLowDiv;
                    classWork->MakerInpDiv = structWork->MakerInpDiv;
                    classWork->PartsSearchDivCd = structWork->PartsSearchDivCd;
                    classWork->RetGoodsStockEtyDiv = structWork->RetGoodsStockEtyDiv;
                    classWork->RetSlipChngDivCost = structWork->RetSlipChngDivCost;
                    classWork->RetSlipChngDivUnPrc = structWork->RetSlipChngDivUnPrc;
                    classWork->SalesAgentChngDiv = structWork->SalesAgentChngDiv;
                    classWork->SalesStockDiv = structWork->SalesStockDiv;
                    classWork->SectDspDivCd = structWork->SectDspDivCd;
                    classWork->SlipChngDivCost = structWork->SlipChngDivCost;
                    classWork->SlipChngDivDate = structWork->SlipChngDivDate;
                    classWork->SlipChngDivLPrice = structWork->SlipChngDivLPrice;
                    classWork->SlipDateClrDivCd = structWork->SlipDateClrDivCd;
                    classWork->SupplierInpDiv = structWork->SupplierInpDiv;
                    classWork->SupplierSlipDelDiv = structWork->SupplierSlipDelDiv;
                    classWork->UnPrcNonSettingDiv = structWork->UnPrcNonSettingDiv;
					classWork->SlipChngDivUnPrc = structWork->SlipChngDivUnPrc;
					classWork->InpGrsProfChkUppDiv = structWork->InpGrsProfChkUppDiv;
					classWork->DwnPLCdSpDivCd = structWork->DwnPLCdSpDivCd;
					classWork->SalesCdDspDivCd = structWork->SalesCdDspDivCd;
                    classWork->RentStockDiv = structWork->RentStockDiv;
                }

                void CopyStructToClass_AllDefSet(StructAllDefSet *structWork, AllDefSet ^classWork){
                    classWork->EraNameDispCd1 = structWork->EraNameDispCd1;
                    classWork->RemCntAutoDspDiv = structWork->RemCntAutoDspDiv;
					classWork->GoodsNoInpDiv = structWork->GoodsNoInpDiv;
                }

                void CopyStructToClass_CompanyInf(StructCompanyInf *structWork, CompanyInf ^classWork){
                    classWork->SecMngDiv = structWork->SecMngDiv;
                }



				// .NETクラス→C++構造体コピー処理

                void CopyClassToStruct_PosTerminalMg(PosTerminalMg ^classWork, StructPosTerminalMg *structWork){
                    structWork->PosPCTermCd = classWork->PosPCTermCd;
                }

				// -- Add St 2012.07.23 30182 R.Tachiya --
                void CopyClassToStruct_AcptAnOdrTtlSt(AcptAnOdrTtlSt ^classWork, StructAcptAnOdrTtlSt *structWork){
					structWork->EstmCountReflectDiv = classWork->EstmCountReflectDiv;
					structWork->AcpOdrrSlipPrtDiv = classWork->AcpOdrrSlipPrtDiv;
					structWork->FaxOrderDiv = classWork->FaxOrderDiv;
                }
				// -- Add Ed 2012.07.23 30182 R.Tachiya --

                void CopyClassToStruct_SalesTtlSt(SalesTtlSt ^classWork, StructSalesTtlSt *structWork){
                    structWork->AcpOdrAgentDispDiv = classWork->AcpOdrAgentDispDiv;
                    structWork->AcpOdrInputDiv = classWork->AcpOdrInputDiv;
                    structWork->AutoEntryGoodsDivCd = classWork->AutoEntryGoodsDivCd;
                    structWork->BLGoodsCdInpDiv = classWork->BLGoodsCdInpDiv;
                    structWork->BrSlipNote2DispDiv = classWork->BrSlipNote2DispDiv;
                    structWork->BrSlipNote3DispDiv = classWork->BrSlipNote3DispDiv;
                    structWork->CarMngNoDispDiv = classWork->CarMngNoDispDiv;
                    structWork->CostDspDivCd = classWork->CostDspDivCd;
                    structWork->CustGuideDispDiv = classWork->CustGuideDispDiv;
                    structWork->DtlNoteDispDiv = classWork->DtlNoteDispDiv;
                    structWork->GrsProfitDspCd = classWork->GrsProfitDspCd;
                    structWork->InpAgentDispDiv = classWork->InpAgentDispDiv;
                    structWork->InpGrsProfChkLowDiv = classWork->InpGrsProfChkLowDiv;
                    structWork->MakerInpDiv = classWork->MakerInpDiv;
                    structWork->PartsSearchDivCd = classWork->PartsSearchDivCd;
                    structWork->RetGoodsStockEtyDiv = classWork->RetGoodsStockEtyDiv;
                    structWork->RetSlipChngDivCost = classWork->RetSlipChngDivCost;
                    structWork->RetSlipChngDivUnPrc = classWork->RetSlipChngDivUnPrc;
                    structWork->SalesAgentChngDiv = classWork->SalesAgentChngDiv;
                    structWork->SalesStockDiv = classWork->SalesStockDiv;
                    structWork->SectDspDivCd = classWork->SectDspDivCd;
                    structWork->SlipChngDivCost = classWork->SlipChngDivCost;
                    structWork->SlipChngDivDate = classWork->SlipChngDivDate;
                    structWork->SlipChngDivLPrice = classWork->SlipChngDivLPrice;
                    structWork->SlipDateClrDivCd = classWork->SlipDateClrDivCd;
                    structWork->SupplierInpDiv = classWork->SupplierInpDiv;
                    structWork->SupplierSlipDelDiv = classWork->SupplierSlipDelDiv;
                    structWork->UnPrcNonSettingDiv = classWork->UnPrcNonSettingDiv;
					structWork->SlipChngDivUnPrc = classWork->SlipChngDivUnPrc;
					structWork->InpGrsProfChkUppDiv = classWork->InpGrsProfChkUppDiv;
					structWork->DwnPLCdSpDivCd = classWork->DwnPLCdSpDivCd;
					structWork->SalesCdDspDivCd = classWork->SalesCdDspDivCd;
                    structWork->RentStockDiv = classWork->RentStockDiv;
                }

                void CopyClassToStruct_AllDefSet(AllDefSet ^classWork, StructAllDefSet *structWork){
                    structWork->EraNameDispCd1 = classWork->EraNameDispCd1;
                    structWork->RemCntAutoDspDiv = classWork->RemCntAutoDspDiv;
					structWork->GoodsNoInpDiv = classWork->GoodsNoInpDiv;
                }

                void CopyClassToStruct_CompanyInf(CompanyInf ^classWork, StructCompanyInf *structWork){
                    structWork->SecMngDiv = classWork->SecMngDiv;
                }


				// C++メモリ開放処理

                __declspec(dllexport) void __stdcall FreePosTerminalMg(StructPosTerminalMg *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

				// -- Add St 2012.07.23 30182 R.Tachiya --
				__declspec(dllexport) void __stdcall FreeAcptAnOdrTtlSt(StructAcptAnOdrTtlSt *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }
				// -- Add Ed 2012.07.23 30182 R.Tachiya --

                __declspec(dllexport) void __stdcall FreeSalesTtlSt(StructSalesTtlSt *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeAllDefSet(StructAllDefSet *resultList, int resultCount){
                    if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }

                __declspec(dllexport) void __stdcall FreeCompanyInf(StructCompanyInf *resultList, int resultCount){
					if(resultList == NULL || resultCount < 0){
                        return;
                    }
                    for( int i = 0 ; i < resultCount ; i++){

                    }
                    delete [] resultList;//配列自体のメモリ領域を開放
                }
				__declspec(dllexport) void __stdcall FreeMessage(BSTR message){
					if(message == NULL){
						return;
					}

					Marshal::FreeBSTR(IntPtr(message));
				}

			}
		}
	}
}
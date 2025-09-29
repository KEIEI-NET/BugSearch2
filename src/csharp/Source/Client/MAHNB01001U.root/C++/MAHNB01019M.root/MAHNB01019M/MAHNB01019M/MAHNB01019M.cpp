// これは メイン DLL ファイルです。

#include "stdafx.h"

#include "MAHNB01019C.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Collections;
using namespace System::Collections::Generic;

using namespace Broadleaf::Library::Resources;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::Controller;

//初期化アクセスクラスラッパー

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitData(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputInitDataAcs^ delphiSalesSlipInputInitDataAcs = DelphiSalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataAcs->ReadInitData(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataSecond(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataSecondAcs^ delphiSalesSlipInputInitDataSecondAcs = DelphiSalesSlipInputInitDataSecondAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataSecondAcs->ReadInitDataSecond(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataThird(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputInitDataThirdAcs^ delphiSalesSlipInputInitDataThirdAcs = DelphiSalesSlipInputInitDataThirdAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataThirdAcs->ReadInitDataThird(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataFourth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataFourthAcs^ delphiSalesSlipInputInitDataFourthAcs = DelphiSalesSlipInputInitDataFourthAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataFourthAcs->ReadInitDataFourth(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataFifth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataFifthAcs^ delphiSalesSlipInputInitDataFifthAcs = DelphiSalesSlipInputInitDataFifthAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataFifthAcs->ReadInitDataFifth(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataSixth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataSixthAcs^ delphiSalesSlipInputInitDataSixthAcs = DelphiSalesSlipInputInitDataSixthAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataSixthAcs->ReadInitDataSixth(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataSeventh(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataSeventhAcs^ delphiSalesSlipInputInitDataSeventhAcs = DelphiSalesSlipInputInitDataSeventhAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataSeventhAcs->ReadInitDataSeventh(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataEighth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataEighthAcs^ delphiSalesSlipInputInitDataEighthAcs = DelphiSalesSlipInputInitDataEighthAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataEighthAcs->ReadInitDataEighth(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataNinth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataNinthAcs^ delphiSalesSlipInputInitDataNinthAcs = DelphiSalesSlipInputInitDataNinthAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataNinthAcs->ReadInitDataNinth(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上入力で使用する初期データをＤＢより取得
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataTenth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataTenthAcs^ delphiSalesSlipInputInitDataTenthAcs = DelphiSalesSlipInputInitDataTenthAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputInitDataTenthAcs->ReadInitDataTenth(enterpriseCodeResult, sectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//端末管理マスタ
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetPosTerminalMg(
    StructPosTerminalMg &posTerminalMg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            PosTerminalMg^ paraPosTerminalMg;


            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->GetPosTerminalMg(paraPosTerminalMg);

            //.NETクラス→構造体変換
            if(paraPosTerminalMg != nullptr){
                CopyClassToStruct_PosTerminalMg(paraPosTerminalMg, &posTerminalMg);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//オプション情報処理
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetOptInfo(
    int &optCarMng, 
    int &optFreeSearch, 
    int &optPcc, 
    int &optRCLink, 
    int &optUoe, 
    int &optStockingPayment, 
    int &optScm, 
    int &opt_QRMail,
    int &opt_DateCtrl, // ADD T.Miyamoto 2012/11/13
	int &opt_NoBuTo // ADD 譚洪 K2014/01/22
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        optCarMng = 0;
        optFreeSearch = 0;
        optPcc = 0;
        optRCLink = 0;
        optUoe = 0;
        optStockingPayment = 0;
        optScm = 0;
        opt_QRMail = 0;
        opt_DateCtrl = 0; // ADD T.Miyamoto 2012/11/13
		opt_NoBuTo = 0; // ADD 譚洪 K2014/01/22

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int optCarMngResult;
            int optFreeSearchResult;
            int optPccResult;
            int optRCLinkResult;
            int optUoeResult;
            int optStockingPaymentResult;
            int optScmResult;
            int opt_QRMailResult;
            int opt_DateCtrlResult; // ADD T.Miyamoto 2012/11/13
			int opt_NoBuToResult; // ADD 譚洪 K2014/01/22

            //アクセスクラスメソッド呼出し
			// --- UPD T.Miyamoto 2012/11/13 ------------------------------>>>>>
            //salesSlipInputInitDataAcs->GetOptInfo(optCarMngResult, optFreeSearchResult, optPccResult, optRCLinkResult, optUoeResult, optStockingPaymentResult, optScmResult, opt_QRMailResult);
            //salesSlipInputInitDataAcs->GetOptInfo(optCarMngResult, optFreeSearchResult, optPccResult, optRCLinkResult, optUoeResult, optStockingPaymentResult, optScmResult, opt_QRMailResult, opt_DateCtrlResult); // DEL 譚洪 K2014/01/22
			salesSlipInputInitDataAcs->GetOptInfo(optCarMngResult, optFreeSearchResult, optPccResult, optRCLinkResult, optUoeResult, optStockingPaymentResult, optScmResult, opt_QRMailResult, opt_DateCtrlResult, opt_NoBuToResult); // ADD 譚洪 K2014/01/22
			// --- UPD T.Miyamoto 2012/11/13 ------------------------------<<<<<

            //.NETクラス→構造体変換
            optCarMng = optCarMngResult;
            optFreeSearch = optFreeSearchResult;
            optPcc = optPccResult;
            optRCLink = optRCLinkResult;
            optUoe = optUoeResult;
            optStockingPayment = optStockingPaymentResult;
            optScm = optScmResult;
            opt_QRMail = opt_QRMailResult;
            opt_DateCtrl = opt_DateCtrlResult; // ADD T.Miyamoto 2012/11/13
			opt_NoBuTo = opt_NoBuToResult; // ADD 譚洪 K2014/01/22
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ---- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
//山形部品オプション情報処理
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetYamagataOptInfo(
    int &optStockEntCtrl
   ,int &optStockDateCtrl
   ,int &optSalesCostCtrl
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
		optStockEntCtrl = 0;  
		optStockDateCtrl = 0; 
		optSalesCostCtrl = 0; 

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			int optStockEntCtrlResult;
			int optStockDateCtrlResult;
			int optSalesCostCtrlResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->GetYamagataOptInfo(optStockEntCtrlResult  
                                                        , optStockDateCtrlResult 
														, optSalesCostCtrlResult 
														 );

			//.NETクラス→構造体変換
			optStockEntCtrl = optStockEntCtrlResult;   
			optStockDateCtrl = optStockDateCtrlResult; 
			optSalesCostCtrl = optSalesCostCtrlResult; 
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ---- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

// -- Add St 2012.07.23 30182 R.Tachiya --
//受発注管理全体設定マスタ
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt(
    StructAcptAnOdrTtlSt &acptAnOdrTtlSt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            AcptAnOdrTtlSt^ paraAcptAnOdrTtlSt;


            //アクセスクラスメソッド呼出し
			salesSlipInputInitDataAcs->GetAcptAnOdrTtlSt(paraAcptAnOdrTtlSt);

            //.NETクラス→構造体変換
            if(paraAcptAnOdrTtlSt != nullptr){
                CopyClassToStruct_AcptAnOdrTtlSt(paraAcptAnOdrTtlSt, &acptAnOdrTtlSt);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// -- Add Ed 2012.07.23 30182 R.Tachiya --

//売上全体設定マスタ
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetSalesTtlSt(
    StructSalesTtlSt &salesTtlSt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesTtlSt^ paraSalesTtlSt;


            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->GetSalesTtlSt(paraSalesTtlSt);

            //.NETクラス→構造体変換
            if(paraSalesTtlSt != nullptr){
                CopyClassToStruct_SalesTtlSt(paraSalesTtlSt, &salesTtlSt);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//全体初期値設定マスタ
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetAllDefSet(
    StructAllDefSet &allDefSet
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            AllDefSet^ paraAllDefSet;


            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->GetAllDefSet(paraAllDefSet);

            //.NETクラス→構造体変換
            if(paraAllDefSet != nullptr){
                CopyClassToStruct_AllDefSet(paraAllDefSet, &allDefSet);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//自社情報設定マスタ
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetCompanyInf(
    StructCompanyInf &companyInf
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            CompanyInf^ paraCompanyInf;


            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->GetCompanyInf(paraCompanyInf);

            //.NETクラス→構造体変換
            if(paraCompanyInf != nullptr){
                CopyClassToStruct_CompanyInf(paraCompanyInf, &companyInf);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//売上金額処理区分設定マスタ制御処理
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->CacheSalesProcMoneyListCall();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//仕入金額処理区分設定マスタ制御処理
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_CacheStockProcMoneyListCall(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->CacheStockProcMoneyListCall();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//掛率優先管理マスタ制御処理
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_CacheRateProtyMngListCall(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->CacheRateProtyMngListCall();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//処理区分マスタリスト設定処理
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_SettingProcMoney(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputInitDataAcs->SettingProcMoney();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreePosTerminalMg(StructPosTerminalMg *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreePosTerminalMg(deleteStructList, deleteStructListCount);
}

// -- Add St 2012.07.23 30182 R.Tachiya --
//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt(StructAcptAnOdrTtlSt *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeAcptAnOdrTtlSt(deleteStructList, deleteStructListCount);
}
// -- Add Ed 2012.07.23 30182 R.Tachiya --

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeSalesTtlSt(StructSalesTtlSt *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeSalesTtlSt(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeAllDefSet(StructAllDefSet *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeAllDefSet(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeCompanyInf(StructCompanyInf *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCompanyInf(deleteStructList, deleteStructListCount);
}

//文字列解放
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeMessage(BSTR message){
	//文字列解放メソッド呼び出し
	FreeMessage(message);
}
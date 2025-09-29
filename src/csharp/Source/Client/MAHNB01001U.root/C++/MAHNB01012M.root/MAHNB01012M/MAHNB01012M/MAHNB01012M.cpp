//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上伝票入力
// プログラム概要   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣 
// 作 成 日  2010/06/12  修正内容 : 携帯メール機能の組込
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/08/12 修正内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 李占川
// 作 成 日  2012/02/09  修正内容 : Redmine#28289の対応
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI今野 利裕
// 作 成 日  2013/03/21  修正内容 : SPK車台番号文字列対応
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本　利明
// 作 成 日  2014/05/19  修正内容 : 仕掛一覧№2218 車輌備考欄にコード入力項目を追加
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本　利明
// 作 成 日  2014/06/02  修正内容 : システムテスト障害№87 管理番号ガイド処理のパラメータ設定を修正
//----------------------------------------------------------------------------//
// これは メイン DLL ファイルです。

#include "stdafx.h"

#include "MAHNB01012C.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Collections;
using namespace System::Collections::Generic;

using namespace Broadleaf::Library::Resources;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::Controller;

//車両検索アクセスクラスラッパー

//車両検索処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CarSearch(
    StructCarSearchCondition condition, 
    int salesRowNo, 
    int conditionType
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            CarSearchCondition^ paraCondition = gcnew CarSearchCondition();

            CopyStructToClass_CarSearchCondition(&condition, paraCondition);
            int salesRowNoResult = salesRowNo;
            int conditionTypeResult = conditionType;

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->CarSearch(paraCondition, salesRowNoResult, conditionTypeResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            conditionType = conditionTypeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報行オブジェクト取得
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetCarInfoRow(
    int salesRowNo, 
    int getCarInfoMode, 
    StructCarInfo &carInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int getCarInfoModeResult = getCarInfoMode;
            Broadleaf::Application::Controller::SalesSlipInputAcs::CarInfo^ paraCarInfo;


            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->GetCarInfoRow(salesRowNoResult, getCarInfoModeResult, paraCarInfo);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            getCarInfoMode = getCarInfoModeResult;
            if(paraCarInfo != nullptr){
                CopyClassToStruct_CarInfo(paraCarInfo, &carInfo);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//カラー情報取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetColorInfo(
    BSTR carRelationGuid, 
    StructCustomArrayB2 &colorInfoList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            ArrayList^ paraColorInfoList;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetColorInfo(carRelationGuidResult, paraColorInfoList);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraColorInfoList != nullptr){
                CopyClassToStruct_CustomArrayB2(paraColorInfoList, &colorInfoList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//選択カラー情報取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSelectColorInfo(
    BSTR carRelationGuid, 
    StructColorInfo &colorInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo^ paraColorInfo;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetSelectColorInfo(carRelationGuidResult, paraColorInfo);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraColorInfo != nullptr){
                CopyClassToStruct_ColorInfo(paraColorInfo, &colorInfo);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//トリム情報取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetTrimInfo(
    BSTR carRelationGuid, 
    StructCustomArrayB3 &trimInfoList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            ArrayList^ paraTrimInfoList;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetTrimInfo(carRelationGuidResult, paraTrimInfoList);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraTrimInfoList != nullptr){
                CopyClassToStruct_CustomArrayB3(paraTrimInfoList, &trimInfoList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//選択トリム情報取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSelectTrimInfo(
    BSTR carRelationGuid, 
    StructTrimInfo &trimInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo^ paraTrimInfo;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetSelectTrimInfo(carRelationGuidResult, paraTrimInfo);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraTrimInfo != nullptr){
                CopyClassToStruct_TrimInfo(paraTrimInfo, &trimInfo);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//装備情報取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetEquipInfo(
    BSTR carRelationGuid, 
    StructCustomArrayB4 &cEqpDefDspInfoList
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            ArrayList^ paraCEqpDefDspInfoList;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetEquipInfo(carRelationGuidResult, paraCEqpDefDspInfoList);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraCEqpDefDspInfoList != nullptr){
                CopyClassToStruct_CustomArrayB4(paraCEqpDefDspInfoList, &cEqpDefDspInfoList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//カラー情報選択処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SelectColorInfo(
    BSTR carRelationGuid, 
    BSTR colorCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ colorCodeResult = gcnew String(colorCode);

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->SelectColorInfo(carRelationGuidResult, colorCodeResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            colorCode = static_cast<BSTR>(Marshal::StringToBSTR(colorCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//トリム情報選択処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SelectTrimInfo(
    BSTR carRelationGuid, 
    BSTR trimCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ trimCodeResult = gcnew String(trimCode);

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->SelectTrimInfo(carRelationGuidResult, trimCodeResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            trimCode = static_cast<BSTR>(Marshal::StringToBSTR(trimCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//生産年式範囲チェック
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CheckProduceTypeOfYearRange(
    BSTR carRelationGuid, 
    int firstEntryDate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            int firstEntryDateResult = firstEntryDate;

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->CheckProduceTypeOfYearRange(carRelationGuidResult, firstEntryDateResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            firstEntryDate = firstEntryDateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両検索データテーブル年式設定処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate(
    BSTR carRelationGuid, 
    int firstEntryDate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            int firstEntryDateResult = firstEntryDate;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarModelUIDataFromFirstEntryDate(carRelationGuidResult, firstEntryDateResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            firstEntryDate = firstEntryDateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車台番号範囲チェック
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CheckProduceFrameNo(
    BSTR carRelationGuid, 
    BSTR inputFrameNo, 
    int searchFrameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ inputFrameNoResult = gcnew String(inputFrameNo);
            int searchFrameNoResult = searchFrameNo;

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->CheckProduceFrameNo(carRelationGuidResult, inputFrameNoResult, searchFrameNoResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            inputFrameNo = static_cast<BSTR>(Marshal::StringToBSTR(inputFrameNoResult).ToPointer());
            searchFrameNo = searchFrameNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両検索データテーブル車台番号設定処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo(
    BSTR carRelationGuid, 
    BSTR frameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ frameNoResult = gcnew String(frameNo);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarModelUIDataFromProduceFrameNo(carRelationGuidResult, frameNoResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            frameNo = static_cast<BSTR>(Marshal::StringToBSTR(frameNoResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//対象年式取得処理(車台番号より取得)
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetProduceTypeOfYear(
    BSTR carRelationGuid, 
    int frameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            int frameNoResult = frameNo;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetProduceTypeOfYear(gcnew String(carRelationGuidResult), frameNoResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            frameNo = frameNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブルのクリア
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ClearCarInfoRow(
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ClearCarInfoRow(salesRowNoResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の年式セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate(
    int salesRowNo, 
    int firstEntryDate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int firstEntryDateResult = firstEntryDate;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromFirstEntryDate(salesRowNoResult, firstEntryDateResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            firstEntryDate = firstEntryDateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の車台番号セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromFrameNo(
    int salesRowNo, 
    BSTR frameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            String^ frameNoResult = gcnew String(frameNo);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromFrameNo(salesRowNoResult, frameNoResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            frameNo = static_cast<BSTR>(Marshal::StringToBSTR(frameNoResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の車種情報セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromModelInfo(
    int salesRowNo, 
    int makerCode, 
    BSTR makerFullName, 
    BSTR makerHalfName, 
    int modelCode, 
    int modelSubCode, 
    BSTR modelFullName, 
    BSTR modelHalfName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int makerCodeResult = makerCode;
            String^ makerFullNameResult = gcnew String(makerFullName);
            String^ makerHalfNameResult = gcnew String(makerHalfName);
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            String^ modelFullNameResult = gcnew String(modelFullName);
            String^ modelHalfNameResult = gcnew String(modelHalfName);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromModelInfo(salesRowNoResult, makerCodeResult, makerFullNameResult, makerHalfNameResult, modelCodeResult, modelSubCodeResult, modelFullNameResult, modelHalfNameResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            makerCode = makerCodeResult;
            makerFullName = static_cast<BSTR>(Marshal::StringToBSTR(makerFullNameResult).ToPointer());
            makerHalfName = static_cast<BSTR>(Marshal::StringToBSTR(makerHalfNameResult).ToPointer());
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
            modelHalfName = static_cast<BSTR>(Marshal::StringToBSTR(modelHalfNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車種名称取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetModelFullName(
    int makerCode, 
    int modelCode, 
    int modelSubCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetModelFullName(makerCodeResult, modelCodeResult, modelSubCodeResult);

            //.NETクラス→構造体変換
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車種半角名称取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetModelHalfName(
    int makerCode, 
    int modelCode, 
    int modelSubCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetModelHalfName(makerCodeResult, modelCodeResult, modelSubCodeResult);

            //.NETクラス→構造体変換
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の管理番号セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCarMngCode(
    int salesRowNo, 
    BSTR carMngCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            String^ carMngCodeResult = gcnew String(carMngCode);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromCarMngCode(salesRowNoResult, carMngCodeResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の型式指定番号および類別区分番号セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo(
    int salesRowNo, 
    int modelDesignationNo, 
    int categoryNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int modelDesignationNoResult = modelDesignationNo;
            int categoryNoResult = categoryNo;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNoResult, modelDesignationNoResult, categoryNoResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            modelDesignationNo = modelDesignationNoResult;
            categoryNo = categoryNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の型式セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromFullModel(
    int salesRowNo, 
    BSTR fullModel
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            String^ fullModelResult = gcnew String(fullModel);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromFullModel(salesRowNoResult, fullModelResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            fullModel = static_cast<BSTR>(Marshal::StringToBSTR(fullModelResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行のエンジン型式セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm(
    int salesRowNo, 
    BSTR engineModelNm
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            String^ engineModelNmResult = gcnew String(engineModelNm);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromEngineModelNm(salesRowNoResult, engineModelNmResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            engineModelNm = static_cast<BSTR>(Marshal::StringToBSTR(engineModelNmResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報存在チェック
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ExistCarInfo(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->ExistCarInfo();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
//車両情報テーブル行の車輌備考コードセット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode(
    int salesRowNo, 
    int carNoteCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int carNoteCodeResult = carNoteCode;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromCarNoteCode(salesRowNoResult, carNoteCodeResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            carNoteCode = carNoteCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

//車両情報テーブル行の車輌備考セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCarNote(
    int salesRowNo, 
    BSTR carNote
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            String^ carNoteResult = gcnew String(carNote);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromCarNote(salesRowNoResult, carNoteResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            carNote = static_cast<BSTR>(Marshal::StringToBSTR(carNoteResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報テーブル行の車輌走行距離セット
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromMileage(
    int salesRowNo, 
    int mileage
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int mileageResult = mileage;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingCarInfoRowFromMileage(salesRowNoResult, mileageResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            mileage = mileageResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
// add by Zhangkai start

//オプション情報処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSettingOptionInfo(
    int &optCarMng, 
    int &optStockingPayment
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        optCarMng = 0;
        optStockingPayment = 0;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int optCarMngResult;
            int optStockingPaymentResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetSettingOptionInfo(optCarMngResult, optStockingPaymentResult);

            //.NETクラス→構造体変換
            optCarMng = optCarMngResult;
            optStockingPayment = optStockingPaymentResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


// add by Zhangkai end

// add by Lizc start
//カーメーカーコードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterMakerCodeFocus(
    int makerCode, 
    int salesRowNo, 
    BSTR &makerName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        makerName = NULL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCodeResult = makerCode;
            int salesRowNoResult = salesRowNo;
            String^ makerNameResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterMakerCodeFocus(makerCodeResult, salesRowNoResult, makerNameResult);

            //.NETクラス→構造体変換
            makerCode = makerCodeResult;
            salesRowNo = salesRowNoResult;
            makerName = static_cast<BSTR>(Marshal::StringToBSTR(makerNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車種コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterModelCodeFocus(
    int makerCode, 
    int modelCode, 
    int modelSubCode, 
    int salesRowNo, 
    BSTR &modelFullName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        modelFullName = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            int salesRowNoResult = salesRowNo;
            String^ modelFullNameResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterModelCodeFocus(makerCodeResult, modelCodeResult, modelSubCodeResult, salesRowNoResult, modelFullNameResult);

            //.NETクラス→構造体変換
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            salesRowNo = salesRowNoResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車種呼称コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterModelSubCodeFocus(
    int makerCode, 
    int modelCode, 
    int modelSubCode, 
    int salesRowNo, 
    BSTR &modelFullName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        modelFullName = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            int salesRowNoResult = salesRowNo;
            String^ modelFullNameResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterModelSubCodeFocus(makerCodeResult, modelCodeResult, modelSubCodeResult, salesRowNoResult, modelFullNameResult);

            //.NETクラス→構造体変換
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            salesRowNo = salesRowNoResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車種名称のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterModelFullNameFocus(
    int makerCode, 
    int modelCode, 
    int modelSubCode, 
    BSTR modelFullName, 
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            String^ modelFullNameResult = gcnew String(modelFullName);
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterModelFullNameFocus(makerCodeResult, modelCodeResult, modelSubCodeResult, modelFullNameResult, salesRowNoResult);

            //.NETクラス→構造体変換
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//年式のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterFirstEntryDateFocus(
    int firstEntryDate, 
    int salesRowNo, 
    bool &boolRet
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int firstEntryDateResult = firstEntryDate;
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterFirstEntryDateFocus(firstEntryDateResult, salesRowNoResult, boolRet);

            //.NETクラス→構造体変換
            firstEntryDate = firstEntryDateResult;
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//車台番号のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterProduceFrameNoFocus(
    BSTR produceFrameNo, 
    int salesRowNo, 
    bool &boolRet,
	int mode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ produceFrameNoResult = gcnew String(produceFrameNo);
            int salesRowNoResult = salesRowNo;
            bool paraBoolRet;
			int modeResult = mode;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterProduceFrameNoFocus(produceFrameNoResult, salesRowNoResult, paraBoolRet, modeResult);

            //.NETクラス→構造体変換
            produceFrameNo = static_cast<BSTR>(Marshal::StringToBSTR(produceFrameNoResult).ToPointer());
            salesRowNo = salesRowNoResult;
            boolRet = paraBoolRet;
			mode = modeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //追加情報タブ項目Visible設定
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingAddInfoVisible(
    int customerCode, 
    BSTR carMngCode, 
    int salesRowNo, 
    bool &boolRet
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int customerCodeResult = customerCode;
            String^ carMngCodeResult = gcnew String(carMngCode);
            int salesRowNoResult = salesRowNo;
            bool paraBoolRet;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SettingAddInfoVisible(customerCodeResult, carMngCodeResult, salesRowNoResult, paraBoolRet);

            //.NETクラス→構造体変換
            customerCode = customerCodeResult;
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
            salesRowNo = salesRowNoResult;
            boolRet = paraBoolRet;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //車種変更ボタンVisible
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetChangeCarInfoVisible(
    int customerCode, 
    BSTR carMngCode, 
    int &visibleFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        visibleFlag = 0;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int customerCodeResult = customerCode;
            String^ carMngCodeResult = gcnew String(carMngCode);
            int visibleFlagResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetChangeCarInfoVisible(customerCodeResult, carMngCodeResult, visibleFlagResult);

            //.NETクラス→構造体変換
            customerCode = customerCodeResult;
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
            visibleFlag = visibleFlagResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //管理番号のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterCarMngCodeFocus(
    BSTR carMngCode, 
    int customerCode, 
    BSTR enterpriseCode,
	int salesRowNo,
    StructCarMangInputExtraInfo &selectedInfo, 
    bool &returnFlag,
	bool &clearCarInfoFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carMngCodeResult = gcnew String(carMngCode);
            int customerCodeResult = customerCode;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
			int salesRowNoResult = salesRowNo;
            CarMangInputExtraInfo^ paraSelectedInfo;

            bool paraReturnFlag;
			bool paraClearCarInfoFlag;


            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->AfterCarMngCodeFocus(carMngCodeResult, customerCodeResult, enterpriseCodeResult, salesRowNoResult,  paraSelectedInfo, paraReturnFlag, paraClearCarInfoFlag);

            //.NETクラス→構造体変換
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
            customerCode = customerCodeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
			salesRowNo = salesRowNoResult;
            if(paraSelectedInfo != nullptr){
                CopyClassToStruct_CarMangInputExtraInfo(paraSelectedInfo, &selectedInfo);
            }
			returnFlag = paraReturnFlag;
			clearCarInfoFlag = paraClearCarInfoFlag;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
	//拠点コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSectionCodeFocus(
    BSTR sectionCode, 
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ sectionCodeResult = gcnew String(sectionCode);
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->AfterSectionCodeFocus(sectionCodeResult, paraSalesSlip);

            //.NETクラス→構造体変換
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    
//部門名称取得処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetNameFromSubSection(
    int subSectionCode, 
    BSTR &subSectionNm
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        subSectionNm = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int subSectionCodeResult = subSectionCode;
            String^ subSectionNmResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetNameFromSubSection(subSectionCodeResult, subSectionNmResult);

            //.NETクラス→構造体変換
            subSectionCode = subSectionCodeResult;
            subSectionNm = static_cast<BSTR>(Marshal::StringToBSTR(subSectionNmResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //担当者変更処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesEmployee(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR code, 
    bool canChangeFocus,
    bool &refCanChangeFocus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);
            bool paraCanChangeFocus = canChangeFocus;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeSalesEmployee(paraSalesSlip, paraSalesSlipCurrent, codeResult, paraCanChangeFocus);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
			refCanChangeFocus = paraCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //受注者変更処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeFrontEmployee(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR code, 
    bool canChangeFocus,
    bool &refCanChangeFocus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);
            bool paraCanChangeFocus = canChangeFocus;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeFrontEmployee(paraSalesSlip, paraSalesSlipCurrent, codeResult, paraCanChangeFocus);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
            refCanChangeFocus = paraCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//発行者変更処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesInput(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR code, 
    bool canChangeFocus,
    bool &refCanChangeFocus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);
            bool paraCanChangeFocus = canChangeFocus;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeSalesInput(paraSalesSlip, paraSalesSlipCurrent, codeResult, paraCanChangeFocus);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
            refCanChangeFocus = paraCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//伝票区分変更処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesSlip(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    bool isCache, 
    int code, 
    bool changeSalesSlipDisplay,
    bool &refChangeSalesSlipDisplay, 
    bool &clearDetailInput, 
    bool &clearCarInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            bool paraIsCache = isCache;

            int codeResult = code;
            bool paraChangeSalesSlipDisplay = changeSalesSlipDisplay;

            bool paraClearDetailInput;

            bool paraClearCarInfo;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeSalesSlip(paraSalesSlip, paraIsCache, codeResult, paraChangeSalesSlipDisplay, paraClearDetailInput, paraClearCarInfo);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = codeResult;
			refChangeSalesSlipDisplay = paraChangeSalesSlipDisplay;
			clearDetailInput = paraClearDetailInput;
			clearCarInfo = paraClearCarInfo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//商品区分変更処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesGoodsCd(
    StructSalesSlip salesSlipCurrent, 
    int code, 
    bool changeSalesGoodsCd,
    bool &refChangeSalesGoodsCd, 
    bool &clearDetailInput, 
    bool &clearCarInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            int codeResult = code;
            bool paraChangeSalesGoodsCd = changeSalesGoodsCd;

            bool paraClearDetailInput;

            bool paraClearCarInfo;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeSalesGoodsCd(paraSalesSlipCurrent, codeResult, paraChangeSalesGoodsCd, paraClearDetailInput, paraClearCarInfo);

            //.NETクラス→構造体変換
            code = codeResult;
			refChangeSalesGoodsCd = paraChangeSalesGoodsCd;
			clearDetailInput = paraClearDetailInput;
			clearCarInfo = paraClearCarInfo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//得意先コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterCustomerCodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int code, 
    StructCustomerInfo customerInfo,
    StructCustomerInfo &refCustomerInfo, 
    bool &clearAddCarInfo, 
    bool canChangeFocus,
    bool &refCanChangeFocus, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice, 
    bool guideStart,
    bool &refGuideStart, 
    bool &clearDetailInput, 
    bool &clearCarInfo, 
    bool reCalcSalesUnitPrice,
    bool &refReCalcSalesUnitPrice, 
    bool clearRateInfo,
    bool &refClearRateInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int codeResult = code;
            CustomerInfo^ paraCustomerInfo = gcnew CustomerInfo();

            CopyStructToClass_CustomerInfo(&customerInfo, paraCustomerInfo);
            bool paraClearAddCarInfo;

            bool paraCanChangeFocus = canChangeFocus;

            //CopyStructToClass_bool(&canChangeFocus, paraCanChangeFocus);
            bool paraReCalcSalesPrice = reCalcSalesPrice;

            //CopyStructToClass_bool(&reCalcSalesPrice, paraReCalcSalesPrice);
            bool paraGuideStart = guideStart;

            //CopyStructToClass_bool(&guideStart, paraGuideStart);
            bool paraClearDetailInput;

            bool paraClearCarInfo;

            bool paraReCalcSalesUnitPrice = reCalcSalesUnitPrice;

            //CopyStructToClass_bool(&reCalcSalesUnitPrice, paraReCalcSalesUnitPrice);
            bool paraClearRateInfo = clearRateInfo;

            //CopyStructToClass_bool(&clearRateInfo, paraClearRateInfo);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterCustomerCodeFocus(paraSalesSlip, codeResult, paraCustomerInfo, paraClearAddCarInfo, paraCanChangeFocus, paraReCalcSalesPrice, paraGuideStart, paraClearDetailInput, paraClearCarInfo, paraReCalcSalesUnitPrice, paraClearRateInfo);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = codeResult;
            if(paraCustomerInfo != nullptr){
                CopyClassToStruct_CustomerInfo(paraCustomerInfo, &refCustomerInfo);
            }
			clearAddCarInfo = paraClearAddCarInfo;
			refCanChangeFocus = paraCanChangeFocus;
			refReCalcSalesPrice = paraReCalcSalesPrice;
			refGuideStart = paraGuideStart;
			clearDetailInput = paraClearDetailInput;
			clearCarInfo = paraClearCarInfo;
			refReCalcSalesUnitPrice = paraReCalcSalesUnitPrice;
			refClearRateInfo = paraClearRateInfo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//伝票番号のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSalesSlipNumFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent,
    StructSalesSlip &refSalesSlipCurrent, 
    BSTR code, 
    BSTR enterpriseCode, 
    bool &equelFlag, 
    int &readDBDatStatus, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice, 
    bool &deleteEmptyRow,
	bool &findDataFlg  // ADD 2010/07/01
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        readDBDatStatus = 0;

		//SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();
		DelphiSalesSlipInputAcs^ salesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();
            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);

            String^ enterpriseCodeResult = gcnew String(enterpriseCode);

            int readDBDatStatusResult;
            bool paraReCalcSalesPrice = reCalcSalesPrice;

            //アクセスクラスメソッド呼出し
			// --- UPD 2010/07/01 --------->>>>>
            //salesSlipInputAcs->AfterSalesSlipNumFocus(paraSalesSlip, paraSalesSlipCurrent, codeResult, enterpriseCodeResult, equelFlag, readDBDatStatusResult, paraReCalcSalesPrice, deleteEmptyRow);
			salesSlipInputAcs->AfterSalesSlipNumFocus(paraSalesSlip, paraSalesSlipCurrent, codeResult, enterpriseCodeResult, equelFlag, readDBDatStatusResult, paraReCalcSalesPrice, deleteEmptyRow, findDataFlg);
			// --- UPD 2010/07/01 ---------<<<<<

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            if(paraSalesSlipCurrent != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlipCurrent, &refSalesSlipCurrent);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            readDBDatStatus = readDBDatStatusResult;
			refReCalcSalesPrice = paraReCalcSalesPrice;

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//受注ステータスリスト作成
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetStateList(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SetStateList();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //売上日のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSalesDateFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    long long salesDate, 
    BSTR salesDateText, 
    bool reCalcSalesUnitPrice,
    bool &refReCalcSalesUnitPrice, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice, 
    double &taxRate,
	bool &refReCanChangeFocus // ADD K2011/08/12
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            DateTime salesDateResult = DateTime(salesDate);
            String^ salesDateTextResult = gcnew String(salesDateText);
            bool paraReCalcSalesUnitPrice = reCalcSalesUnitPrice;

            bool paraReCalcSalesPrice = reCalcSalesPrice;

            double taxRateResult = taxRate;
			bool paraReCanChangeFocus = true; // ADD K2011/08/12

            //アクセスクラスメソッド呼出し
            //salesSlipInputAcs->AfterSalesDateFocus(paraSalesSlip, paraSalesSlipCurrent, salesDateResult, salesDateTextResult, paraReCalcSalesUnitPrice, paraReCalcSalesPrice, taxRateResult); // DEL K2011/08/12
			salesSlipInputAcs->AfterSalesDateFocus(paraSalesSlip, paraSalesSlipCurrent, salesDateResult, salesDateTextResult, paraReCalcSalesUnitPrice, paraReCalcSalesPrice, taxRateResult, paraReCanChangeFocus); // ADD K2011/08/12

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
			salesDate = salesDateResult.Ticks;
            salesDateText = static_cast<BSTR>(Marshal::StringToBSTR(salesDateTextResult).ToPointer());
			refReCalcSalesUnitPrice = paraReCalcSalesUnitPrice;
			refReCalcSalesPrice = paraReCalcSalesPrice;
            taxRate = taxRateResult;
			refReCanChangeFocus = paraReCanChangeFocus; // ADD K2011/08/12
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//納入先コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterAddresseeCodeFocue(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int code, 
    BSTR enterpriseCode, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int codeResult = code;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            bool paraReCalcSalesPrice = reCalcSalesPrice;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterAddresseeCodeFocue(paraSalesSlip, codeResult, enterpriseCodeResult, paraReCalcSalesPrice);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = codeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
			refReCalcSalesPrice = paraReCalcSalesPrice;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //売上データオブジェクトをインスタンス変数にキャッシュします。
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CacheForChange(
    StructSalesSlip salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs =SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->CacheForChange(paraSalesSlip);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //メモリ上の内容と比較
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CompareSalesSlip(
    StructSalesSlip salesSlip, 
    StructSalesSlip salesSlipCurrent, 
    bool &compareRes
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            //bool^ paraCompareRes;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->CompareSalesSlip(paraSalesSlip, paraSalesSlipCurrent, compareRes);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //売上単価再計算
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ReCalcSalesUnitPrice(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ReCalcSalesUnitPrice(paraSalesSlip);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//掛率情報クリア処理（全て）
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ClearAllRateInfo(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ClearAllRateInfo();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//備考１コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNoteCodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int value
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int valueResult = value;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterSlipNoteCodeFocus(paraSalesSlip, valueResult);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = valueResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//備考２コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNote2CodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int value,
	bool &refCanChangeFocus // ADD K2011/08/12
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int valueResult = value;
			bool paraReCanChangeFocus = true; // ADD K2011/08/12

            //アクセスクラスメソッド呼出し
            //salesSlipInputAcs->AfterSlipNote2CodeFocus(paraSalesSlip, valueResult); // DEL K2011/08/12
            salesSlipInputAcs->AfterSlipNote2CodeFocus(paraSalesSlip, valueResult, paraReCanChangeFocus); // ADD K2011/08/12

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = valueResult;
			refCanChangeFocus = paraReCanChangeFocus; // ADD K2011/08/12
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// ----- ADD K2011/08/12 --------------------------->>>>>
//備考２のフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNote2Focus(
    StructSalesSlip salesSlip,
    BSTR slipNote2,
	bool &refCanChangeFocus // ADD K2011/08/12
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            String^ slipNote2Result = gcnew String(slipNote2);
			bool paraReCanChangeFocus = true;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterSlipNote2Focus(paraSalesSlip, slipNote2Result, paraReCanChangeFocus);

            //.NETクラス→構造体変換
			refCanChangeFocus = paraReCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ----- ADD K2011/08/12 ---------------------------<<<<<

//備考３コードのフォーカス処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNote3CodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int value
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int valueResult = value;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AfterSlipNote3CodeFocus(paraSalesSlip, valueResult);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = valueResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //売上データ処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSalesSlip(
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetSalesSlip(paraSalesSlip);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //請求先確認ボタンクリック
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CustomerClaimConfirmationClick(
    long long salesDate, 
    BSTR &focus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        focus = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            DateTime salesDateResult = DateTime(salesDate);
            String^ focusResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->CustomerClaimConfirmationClick(salesDateResult, focusResult);

            //.NETクラス→構造体変換
            salesDate = salesDateResult.Ticks;
            focus = static_cast<BSTR>(Marshal::StringToBSTR(focusResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//納入先確認ボタンクリック
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AddresseeConfirmationClick(
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->AddresseeConfirmationClick(paraSalesSlip);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //売上明細データの存在チェック
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ExistSalesDetail(
    bool &exist
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ExistSalesDetail(exist);

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上形式変更可能チェック処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeCheckAcptAnOdrStatus(
    int code, 
    StructSalesSlip salesSlip, 
    bool &clearDisplayCarInfo, 
    bool &clearAddUpInfo, 
    bool &result
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int codeResult = code;
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            bool paraClearDisplayCarInfo;

            bool paraClearAddUpInfo;

            bool paraResult;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeCheckAcptAnOdrStatus(codeResult, paraSalesSlip, paraClearDisplayCarInfo, paraClearAddUpInfo, paraResult);

            //.NETクラス→構造体変換
            code = codeResult;
			clearDisplayCarInfo = paraClearDisplayCarInfo;
			clearAddUpInfo = paraClearAddUpInfo;
			result = paraResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上形式変更可能処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeAcptAnOdrStatus(
    int code, 
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int svCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int codeResult = code;
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int svCodeResult = svCode;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->ChangeAcptAnOdrStatus(codeResult, paraSalesSlip, svCodeResult);

            //.NETクラス→構造体変換
            code = codeResult;
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            svCode = svCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上データキャッシュ処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_Cache(
    StructSalesSlip salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->Cache(paraSalesSlip);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //表示用伝票区分より、データ用の伝票区分、売掛区分をセットします
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SetSlipCdAndAccRecDivCdFromDisplay(paraSalesSlip);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //装備情報選択処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SelectEquipInfo(
    BSTR carRelationGuid, 
    BSTR equipmentGenreCd, 
    BSTR equipmentName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ equipmentGenreCdResult = gcnew String(equipmentGenreCd);
            String^ equipmentNameResult = gcnew String(equipmentName);

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SelectEquipInfo(carRelationGuidResult, equipmentGenreCdResult, equipmentNameResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            equipmentGenreCd = static_cast<BSTR>(Marshal::StringToBSTR(equipmentGenreCdResult).ToPointer());
            equipmentName = static_cast<BSTR>(Marshal::StringToBSTR(equipmentNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //データ変更フラグの設定処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetGetIsDataChanged(
    int flag, 
    bool isDataChanged,
    bool &refIsDataChanged
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int flagResult = flag;
            bool paraIsDataChanged = refIsDataChanged;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SetGetIsDataChanged(flagResult, paraIsDataChanged);

            //.NETクラス→構造体変換
            flag = flagResult;
            refIsDataChanged = paraIsDataChanged;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//ヘッダフォーカス設定リストの取込処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetHeaderFocusConstructionListValue(
    StructCustomArrayB5 &headerFocusConstructionList, 
    StructCustomArrayB6 &footerFocusConstructionList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            ArrayList^ paraHeaderFocusConstructionList;

            ArrayList^ paraFooterFocusConstructionList;


            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetHeaderFocusConstructionListValue(paraHeaderFocusConstructionList, paraFooterFocusConstructionList);

            //.NETクラス→構造体変換
            if(paraHeaderFocusConstructionList != nullptr){
                CopyClassToStruct_CustomArrayB5(paraHeaderFocusConstructionList, &headerFocusConstructionList);
            }
            if(paraFooterFocusConstructionList != nullptr){
                CopyClassToStruct_CustomArrayB6(paraFooterFocusConstructionList, &footerFocusConstructionList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//フォーカス設定リストの取込処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetFocusConstructionValue(
    BSTR &headerList, 
    BSTR &footerList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        headerList = NULL;
        footerList = NULL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ headerListResult;
            String^ footerListResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetFocusConstructionValue(headerListResult, footerListResult);

            //.NETクラス→構造体変換
            headerList = static_cast<BSTR>(Marshal::StringToBSTR(headerListResult).ToPointer());
            footerList = static_cast<BSTR>(Marshal::StringToBSTR(footerListResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //拠点名称の取込処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSectionNm(
    BSTR section, 
    BSTR &sectionName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        sectionName = NULL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ sectionResult = gcnew String(section);
            String^ sectionNameResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetSectionNm(sectionResult, sectionNameResult);

            //.NETクラス→構造体変換
            section = static_cast<BSTR>(Marshal::StringToBSTR(sectionResult).ToPointer());
            sectionName = static_cast<BSTR>(Marshal::StringToBSTR(sectionNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2010/07/16 ---------->>>>>    
    //車両検索区分の取込処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetGetSearchCarDiv(
    int flag, 
    bool searchCarDiv,
    bool &refSearchCarDiv
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int flagResult = flag;
            bool paraSearchCarDiv = searchCarDiv;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->SetGetSearchCarDiv(flagResult, paraSearchCarDiv);

            //.NETクラス→構造体変換
            flag = flagResult;
            refSearchCarDiv = paraSearchCarDiv;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/07/16 ----------<<<<<
// add by Lizc end

// add by gaofeng start
//拠点ガイド処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_sectionGuide(
    BSTR enterpriseCode, 
    BSTR formName, 
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ formNameResult = gcnew String(formName);
            SalesSlip^ paraSalesSlip;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->sectionGuide(enterpriseCodeResult, formNameResult, paraSalesSlip);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            formName = static_cast<BSTR>(Marshal::StringToBSTR(formNameResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//部門ガイド処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_subSectionGuide(
    BSTR enterpriseCode, 
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            SalesSlip^ paraSalesSlip;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->subSectionGuide(enterpriseCodeResult, paraSalesSlip);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//従業員ガイド処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_employeeGuide(
    BSTR sender, 
    BSTR enterpriseCode, 
	BSTR salesInputNm, 
    BSTR salesInputCode, 
    StructSalesSlip &salesSlip,
	bool &isReInputErr
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ senderResult = gcnew String(sender);
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
			String^ salesInputNmResult = gcnew String(salesInputNm);
            String^ salesInputCodeResult = gcnew String(salesInputCode);

            SalesSlip^ paraSalesSlip;
			bool paraIsReInputErr = isReInputErr;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->employeeGuide(senderResult, enterpriseCodeResult, salesInputNmResult, salesInputCodeResult, paraSalesSlip, paraIsReInputErr);

            //.NETクラス→構造体変換
            sender = static_cast<BSTR>(Marshal::StringToBSTR(senderResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
			isReInputErr = paraIsReInputErr;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//管理番号ガイド処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_carMngNoGuide(
    int customerCode, 
    BSTR enterpriseCode, 
    StructCarMangInputExtraInfo &selectedInfo,
	int &resultStatus,
	int salesRowNo,
	BSTR carMngCode
	
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int customerCodeResult = customerCode;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            CarMangInputExtraInfo^ paraSelectedInfo;
			int paraResultStatus;
			// --- UPD 2014/06/02 T.Miyamoto システムテスト障害№87 ------------------------------>>>>>
			//int paraSalesRowNo;
			int paraSalesRowNo = salesRowNo;
			// --- UPD 2014/06/02 T.Miyamoto システムテスト障害№87 ------------------------------<<<<<
			String^ carMngCodeResult = gcnew String(carMngCode);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->carMngNoGuide(customerCodeResult, enterpriseCodeResult, paraSelectedInfo, paraResultStatus, paraSalesRowNo, carMngCodeResult);

            //.NETクラス→構造体変換
            customerCode = customerCodeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSelectedInfo != nullptr){
                CopyClassToStruct_CarMangInputExtraInfo(paraSelectedInfo, &selectedInfo);
            }
            resultStatus = paraResultStatus;
			carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
			salesRowNo = paraSalesRowNo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車種ガイド処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_modelFullGuide(
	int makerCode,
    int modelCode, 
    int modelSubCode, 
    BSTR enterpriseCode,
    int salesRowNo, 
    StructModelNameU &modelNameU
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            int salesRowNoResult = salesRowNo;
            Broadleaf::Application::UIData::ModelNameU^ paraModelNameU;


            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->modelFullGuide(makerCodeResult, modelCodeResult, modelSubCodeResult, enterpriseCodeResult, salesRowNoResult, paraModelNameU);

            //.NETクラス→構造体変換
			makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            salesRowNo = salesRowNoResult;
            if(paraModelNameU != nullptr){
                CopyClassToStruct_ModelNameU(paraModelNameU, &modelNameU);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//備考ガイドボボタン処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_slipNote(
    BSTR sender, 
    BSTR enterpriseCode, 
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ senderResult = gcnew String(sender);
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            SalesSlip^ paraSalesSlip;


            //アクセスクラスメソッド呼出し
			// --- UPD 2010/07/12 ---------->>>>>
            //delphiSalesSlipInputAcs->slipNote(senderResult, enterpriseCodeResult, paraSalesSlip);
			status = delphiSalesSlipInputAcs->slipNote(senderResult, enterpriseCodeResult, paraSalesSlip);
			// --- UPD 2010/07/12 ----------<<<<<

            //.NETクラス→構造体変換
            sender = static_cast<BSTR>(Marshal::StringToBSTR(senderResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//率算定処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetRate(
    double numerator, 
    double denominator, 
    double &rate
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        rate = 0;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            double numeratorResult = numerator;
            double denominatorResult = denominator;
            double rateResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetRate(numeratorResult, denominatorResult, rateResult);

            //.NETクラス→構造体変換
            numerator = numeratorResult;
            denominator = denominatorResult;
            rate = rateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2010/05/31 ---------->>>>>
//売上金額計算処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CalculationSalesPrice(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->CalculationSalesPrice();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/05/31 ----------<<<<<

// add by gaofeng end

// add by Yangmj start
//ツールチップ生成処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CreateStockCountInfoString(
    int salesRowNo,
	BSTR &StockCountInfo
    ){
		int status = 0;
        BSTR str;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            StockCountInfo = static_cast<BSTR>(Marshal::StringToBSTR(salesSlipInputAcs->CreateStockCountInfoString(salesRowNoResult)).ToPointer());

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// add by Yangmj end

// add by Tanhong start

// add by Tanhong end

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CopyToRC(
    int salesRowNo
    ){

		int status = 0;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int    salesRowNoResult = salesRowNo   ;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->CopyToRC(salesRowNoResult);

            salesRowNo = salesRowNoResult ;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeColorInfo(StructColorInfo *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeColorInfo(deleteStructList, deleteStructListCount);
}

__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeTrimInfo(StructTrimInfo *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeTrimInfo(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCEqpDefDspInfo(StructCEqpDefDspInfo *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCEqpDefDspInfo(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarSpecInfo(StructCarSpecInfo *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCarSpecInfo(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarInfo(StructCarInfo *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCarInfo(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarModel(StructCarModel *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCarModel(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeEngineModel(StructEngineModel *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeEngineModel(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarSearchCondition(StructCarSearchCondition *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCarSearchCondition(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB4(StructCustomArrayB4 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayB4(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB3(StructCustomArrayB3 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayB3(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB2(StructCustomArrayB2 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayB2(deleteStructList, deleteStructListCount);
}

////文字列解放
//__declspec(dllexport) void __stdcall ShowUAcs_FreeMessage(BSTR message){
//	//文字列解放メソッド呼び出し
//	FreeMessage(message);
//}

__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeMessage(BSTR message){
	//文字列解放メソッド呼び出し
	FreeMessage(message);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayA2(StructCustomArrayA2 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayA2(deleteStructList, deleteStructListCount);
}

// add by gaofeng start

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarMangInputExtraInfo(StructCarMangInputExtraInfo *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCarMangInputExtraInfo(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeModelNameU(StructModelNameU *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeModelNameU(deleteStructList, deleteStructListCount);
}
// add by gaofeng end

// add by Zhangkai start
//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeSalesDetail(StructSalesDetail *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeSalesDetail(deleteStructList, deleteStructListCount);
}

// add by gaofeng start
//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeSalesSlip(StructSalesSlip *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeSalesSlip(deleteStructList, deleteStructListCount);
}

// add by gaofeng end

// add by Zhangkai end

// add by Lizc start
//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeHeaderFocusConstruction(StructHeaderFocusConstruction *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeHeaderFocusConstruction(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeFooterFocusConstruction(StructFooterFocusConstruction *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeFooterFocusConstruction(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB6(StructCustomArrayB6 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayB6(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB5(StructCustomArrayB5 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayB5(deleteStructList, deleteStructListCount);
}
// add by Lizc end

// add by Yangmj start

// add by Yangmj end

// add by Tanhong start

// add by Tanhong end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//**************************************************
// メールデフォルトデータ作成
//**************************************************
__declspec(dllexport) void __stdcall SalesSlipInputAcs_MakeMailDefaultData(
    BSTR &fileName 
    ){
        fileName = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			String^ fileNameResult;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->MakeMailDefaultData(fileNameResult);

            //.NETクラス→構造体変換
			fileName = static_cast<BSTR>(Marshal::StringToBSTR(fileNameResult).ToPointer());
		}
        catch(Exception ^ex){
        }

    }
// --- ADD m.suzuki 2010/06/12 ----------<<<<<

// ADD 2012/02/09 李占川 Redmine#28289 --- >>>>>
//印刷中フラグの取込処理
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetPrintThreadOverFlag(
    bool &printThreadOverFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraPrintThreadOverFlag;

            //アクセスクラスメソッド呼出し
            salesSlipInputAcs->GetPrintThreadOverFlag(paraPrintThreadOverFlag);

            //.NETクラス→構造体変換

			printThreadOverFlag = paraPrintThreadOverFlag;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ADD 2012/02/09 李占川 Redmine#28289 --- <<<<

// --- ADD 2013/03/21 ---------->>>>>
//ハンドル位置チェック処理
__declspec(dllexport) bool __stdcall SalesSlipInputAcs_CheckHandlePosition(
    BSTR carRelationGuid, 
    BSTR vinCode
    ){
        // デフォルトでtrueを返す
        bool status = true;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ vinCodeResult = gcnew String(vinCode);

            //アクセスクラスメソッド呼出し
            status = salesSlipInputAcs->CheckHandlePosition(carRelationGuidResult, vinCodeResult);

            //.NETクラス→構造体変換
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            vinCode = static_cast<BSTR>(Marshal::StringToBSTR(vinCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            //status = true;
        }

        return status;
    }
// --- ADD 2013/03/21 ----------<<<<<

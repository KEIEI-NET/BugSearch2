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
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/12  修正内容 : 携帯メール機能の組込
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/16  修正内容 : オフライン対応の組込
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/08/13  修正内容 : 障害・改良対応(８月リリース案件)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/08/30  修正内容 : 税率設定範囲チェック追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/01/31  修正内容 : ①起動パラメータ設定処理のパラメータ変更
//                                 ②Save,AfterSaveのパラメータ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/02/01  修正内容 : SCM情報存在チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/03/04  修正内容 : 従業員情報設定処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/02/12  修正内容 : 伝票内容が差し替わる件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/04/13  修正内容 : 明細複数選択行を削除可能とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/05/30  修正内容 : 画面の拠点コード変化時（キャンペーン情報取得用）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑 連番1028,Redmine#22936
// 作 成 日  2011/07/18  修正内容 : MANTIS[17500]仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/08/12 修正内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 許雁波
// 作 成 日  2011/08/18  修正内容 : 連番729 明細貼付ファンクションボタンを追加
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/09/01 修正内容 : Redmine24294対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/09/17  修正内容 : Redmine#25217 登録、データ送信されることもあるが、いずれにしろ時間がかかりすぎるの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/11/18  修正内容 : redmine#26532 登録、BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票を修正呼出しした場合、メッセージを表示し、参照モードで画面に表示するの仕様変更の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉思遠 
// 作 成 日  2011/11/22  修正内容 : Redmine#8037 BLﾊﾟｰﾂｵｰﾀﾞｰ　在庫確認→発注時のデータセットの仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 福田 康夫
// 作 成 日  2012/05/31  修正内容 : 障害No.282
//                                  発注選択の時に「ESC」キーを押下することで発注扱いを解除する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 譚洪
// 作 成 日  2012/10/15  修正内容 : Redmine#31582
//                                  仕入日のエラーメッセージを表示処理する
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 鄧潘ハン
// 作 成 日  2013/01/24  修正内容 : 2013/03/13配信分 Redmine#34141
//                                  一括値引功能を追加についての対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/03/28  修正内容 : SCM障害№192対応
//----------------------------------------------------------------------------//
// 管理番号  11070100-00 作成担当 : 宮本 利明
// 作 成 日  2014/07/15  修正内容 : 仕掛一覧 №1912
//----------------------------------------------------------------------------//
// 管理番号  11100713-00 作成担当 : 高騁
// 作 成 日  K2015/04/01 修正内容 : 森川部品個別依頼
//----------------------------------------------------------------------------//
// 管理番号  11100543-00 作成担当 : 黄興貴
// 作 成 日  K2015/04/21 修正内容 : 富士ジーワイ商事㈱ UOE取込対応
//----------------------------------------------------------------------------//
// 管理番号  11101427-00 作成担当 : 紀飛
// 作 成 日  K2015/06/18 修正内容 : ㈱メイゴ　WebUOE発注回答取込対応
//----------------------------------------------------------------------------//
// 管理番号  11170204-00 作成担当 : 宮本 利明
// 作 成 日  2015/12/09  修正内容 : リモ伝障害対応 Redmine#47670
//----------------------------------------------------------------------------//
// 管理番号  11202099-00  作成担当 : 譚洪
// 作 成 日  K2016/11/01  修正内容 : 売上伝票入力から外部PGを起動して売単価を算出の対応
//----------------------------------------------------------------------------//
// 管理番号  11202452-00  作成担当 : 譚洪
// 作 成 日  K2016/12/30  修正内容 : 水野商工様個別変更内容をPM.NSにて実現するため、第二売価の対応行います。
//----------------------------------------------------------------------------//
// 管理番号  11470152-00  作成担当 : 譚洪
// 作 成 日  2018/09/04   修正内容 : 履歴自動表示機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11570208-00  作成担当 : 譚洪
// 作 成 日  2020/02/24   修正内容 : 消費税税率機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11870080-00  作成担当 : 陳艶丹
// 作 成 日  2022/04/26   修正内容 : PMKOBETSU-4208 電子帳簿対応
//----------------------------------------------------------------------------//

// これは メイン DLL ファイルです。

#include "stdafx.h"

#include "MAHNB01013C.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Collections;
using namespace System::Collections::Generic;

using namespace Broadleaf::Library::Resources;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::Controller;

//得意先アクセスクラスラッパー

// add by tanh
//得意先ガイド処理
//>>>2010/05/30
//__declspec(dllexport) bool __stdcall DelphiSalesSlipInputAcs_Clear(
//    bool isConfirm, 
//    bool keepAcptAnOdrStatus, 
//    bool keepDate, 
//    bool keepFooterInfo, 
//    bool keepCustomer,
//	bool keepSalesDate
__declspec(dllexport) bool __stdcall DelphiSalesSlipInputAcs_Clear(
    bool isConfirm, 
    bool keepAcptAnOdrStatus, 
    bool keepDate, 
    bool keepFooterInfo, 
    bool keepCustomer,
	bool keepSalesDate,
	bool keepDetailRowCount,
	int customerCode
//<<<2010/05/30
    ){
        //int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
		bool paraDialogResultFlg = true;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            paraDialogResultFlg = delphiSalesSlipInputAcs->Clear(isConfirm, keepAcptAnOdrStatus, keepDate, keepFooterInfo, keepCustomer, keepSalesDate,keepDetailRowCount, customerCode);
            
            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            //status = -1;
			//paraDialogResultFlg = 
        }

        return paraDialogResultFlg;
    }

// --- ADD 2011/02/12 ---- >>>>>
//調査用ログ出力クラス処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_DoAddLine(
    int logNo, 
    int slipNo, 
    int acptAnOdrStatus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int logNoResult = logNo;
            int slipNoResult = slipNo;
            int acptAnOdrStatusResult = acptAnOdrStatus;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->DoAddLine(logNoResult, slipNoResult, acptAnOdrStatusResult);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//各種起動データ
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetInitData(
    bool &existFlg  //ADD 連番729 2011/08/18
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraExistFlg;

            //アクセスクラスメソッド呼出し
            //delphiSalesSlipInputAcs->SetInitData();  //DEL 連番729 2011/08/18
			delphiSalesSlipInputAcs->SetInitData(paraExistFlg);  //ADD 連番729 2011/08/18

            //.NETクラス→構造体変換
            existFlg = paraExistFlg;   //ADD 連番729 2011/08/18
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// ADD 2011/09/17 ---- >>>>>
//保存用設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetAfterSaveData(
    int result, 
    BSTR carMngCode, 
    bool printSlipFlag, 
    bool isMakeQR, 
    bool scmFlg, 
    bool cmtFlag,
	// ----- ADD K2011/12/09 --------->>>>>
	bool slipNote2ErrFlag,
	// UPD 2013/03/28 SCM障害№192対応 --------------------->>>>>
	//bool salesDateErrFlag
	bool salesDateErrFlag,
	int isScmSave
	// UPD 2013/03/28 SCM障害№192対応 ---------------------<<<<<
	// ----- ADD K2011/12/09 ---------<<<<< 
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

	    //構造体→.NETクラスへ変換
        String^ carMngCodeResult = gcnew String(carMngCode);

        try{
            //アクセスクラスメソッド呼出し
            //delphiSalesSlipInputAcs->SetAfterSaveData(result, carMngCodeResult, printSlipFlag, isMakeQR, scmFlg, cmtFlag); //DEL K2011/12/09
			// UPD 2013/03/28 SCM障害№192対応 --------------------->>>>>
			//delphiSalesSlipInputAcs->SetAfterSaveData(result, carMngCodeResult, printSlipFlag, isMakeQR, scmFlg, cmtFlag, slipNote2ErrFlag, salesDateErrFlag); //ADD K2011/12/09
			delphiSalesSlipInputAcs->SetAfterSaveData(result, carMngCodeResult, printSlipFlag, isMakeQR, scmFlg, cmtFlag, slipNote2ErrFlag, salesDateErrFlag, isScmSave); //ADD K2011/12/09
			// UPD 2013/03/28 SCM障害№192対応 ---------------------<<<<<
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
//第二売価ガイドの位置を設定します。
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation(
    int locationLeft, 
    int locationTop
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //アクセスクラスメソッド呼出し
			delphiSalesSlipInputAcs->SetSecondSalesUnPrcGideLocation(locationLeft, locationTop);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//水野商工㈱ オプション判定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl(
    bool &optPermitForMizuno2ndSellPriceCtl
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
        try{
            //構造体→.NETクラスへ変換
            bool paraOptPermitForMizuno2ndSellPriceCtlResult;
            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->OptPermitForMizuno2ndSellPriceCtl(paraOptPermitForMizuno2ndSellPriceCtlResult);
			//.NETクラス→構造体変換
			optPermitForMizuno2ndSellPriceCtl = paraOptPermitForMizuno2ndSellPriceCtlResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

//保存用設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetAfterSaveData(
    int &result, 
    bool &isMakeQR, 
    bool &scmFlg, 
    bool &cmtFlag,
	// ----- ADD K2011/12/09 --------->>>>>
	bool &slipNote2ErrFlag,
	// UPD 2013/03/28 SCM障害№192対応 --------------------->>>>>
	//bool &salesDateErrFlag
	bool &salesDateErrFlag,
	int &isScmSave
	// UPD 2013/03/28 SCM障害№192対応 ---------------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        result = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int resultResult;
            bool paraIsMakeQR;

            bool paraScmFlg;

            bool paraCmtFlag;
			// ----- ADD K2011/12/09 --------->>>>>
			bool paraSlipNote2ErrFlag;
			bool paraSalesDateErrFlag;
			// ----- ADD K2011/12/09 ---------<<<<<
			// ADD 2013/03/28 SCM障害№192対応 --------------------->>>>>
			int paraisSCMSave;
			// ADD 2013/03/28 SCM障害№192対応 ---------------------<<<<<


            //アクセスクラスメソッド呼出し
            //delphiSalesSlipInputAcs->GetAfterSaveData(resultResult, paraIsMakeQR, paraScmFlg, paraCmtFlag);// DEL K2011/12/09 
			// UPD 2013/03/28 SCM障害№192対応 --------------------->>>>>
            //delphiSalesSlipInputAcs->GetAfterSaveData(resultResult, paraIsMakeQR, paraScmFlg, paraCmtFlag, paraSlipNote2ErrFlag, paraSalesDateErrFlag);// ADD K2011/12/09 
            delphiSalesSlipInputAcs->GetAfterSaveData(resultResult, paraIsMakeQR, paraScmFlg, paraCmtFlag, paraSlipNote2ErrFlag, paraSalesDateErrFlag, paraisSCMSave);// ADD K2011/12/09 
			// UPD 2013/03/28 SCM障害№192対応 ---------------------<<<<<
            //.NETクラス→構造体変換
            result = resultResult;
            isMakeQR = paraIsMakeQR;
			scmFlg = paraScmFlg;
			cmtFlag = paraCmtFlag;
			// ----- ADD K2011/12/09 --------->>>>>
			slipNote2ErrFlag = paraSlipNote2ErrFlag;
			salesDateErrFlag = paraSalesDateErrFlag;
			// ----- ADD K2011/12/09 ---------<<<<<
			// ADD 2013/03/28 SCM障害№192対応 --------------------->>>>>
			isScmSave = paraisSCMSave;
			// ADD 2013/03/28 SCM障害№192対応 ---------------------<<<<<

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//保存用設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_DoAfterSave(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->DoAfterSave();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ADD 2011/09/17 ---- <<<<<

// ADD 2012/10/15 ---- >>>>>
//仕入日のエラーメッセージを表示処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ShowStockDateMsg(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->ShowStockDateMsg();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ADD 2012/10/15 ---- <<<<<

//調査用ログImage出力処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_DoCacheImage(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->DoCacheImage();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//調査用ログチェック
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetErrorFlag(
    bool &errorFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraErrorFlag;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetErrorFlag(paraErrorFlag);

            //.NETクラス→構造体変換
            errorFlag = paraErrorFlag;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2011/02/12 ---- <<<<<

// --- ADD 2011/04/13 ---- <<<<<
//選択済み売上行番号削除処理（多行削除場合用）
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_DetailDeleteActionTable(
    int startRowNo, 
    int endRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int startRowNoResult = startRowNo;
            int endRowNoResult = endRowNo;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->DetailDeleteActionTable(startRowNoResult, endRowNoResult);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2011/04/13 ---- <<<<<

// --- ADD 2011/05/30 ---- >>>>>
//画面の拠点コード変化時（キャンペーン情報取得用）
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetSectionCode(
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ sectionCodeResult = gcnew String(sectionCode);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SetSectionCode(sectionCodeResult);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2011/05/30 ---- <<<<<

// --- ADD 2011/07/18 ---- >>>>>
//現在庫数を調整します
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_StockInfoAdjust(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->StockInfoAdjust();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2011/07/18 ---- <<<<<

//小数点表示区分処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SmallPointProc(
    int rowIndexParm
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowIndexParmResult = rowIndexParm;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->SmallPointProc(rowIndexParmResult);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//元に戻す処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_Retry(
    bool isConfirm, 
    bool &dialogResultFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraDialogResultFlg;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->Retry(isConfirm, paraDialogResultFlg);

            dialogResultFlg = paraDialogResultFlg;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//元に戻す処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_RetryResult(
    bool &statusFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraStatusFlg;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->RetryResult(paraStatusFlg);
 
			statusFlg = paraStatusFlg;
            
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//備考設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetNoteGuidList(
    BSTR enterpriseCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetNoteGuidList(enterpriseCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//終了設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_Close(
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//   bool isConfirmFlg, 
//   bool &canCloseFlg
	bool isConfirmFlg, 
    bool &canCloseFlg,
	bool &isMakeQR
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
	){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraCanCloseFlg;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			bool paraIsMakeQR = isMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<

            //アクセスクラスメソッド呼出し
			// --- UPD m.suzuki 2010/06/12 ---------->>>>>
            //delphiSalesSlipInputAcs->Close(isConfirmFlg, paraCanCloseFlg);
            delphiSalesSlipInputAcs->Close(isConfirmFlg, paraCanCloseFlg,paraIsMakeQR);
			// --- UPD m.suzuki 2010/06/12 ----------<<<<<

            //.NETクラス→構造体変換
            canCloseFlg = paraCanCloseFlg;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			isMakeQR = paraIsMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//伝票区分コンボエディタアイテム設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetItemtSalesSlipCd(
    int &setItemtSalesSlipCdDisp, 
    int &setItemtSalesSlipCdFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        setItemtSalesSlipCdDisp = 0;
        setItemtSalesSlipCdFlg = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int setItemtSalesSlipCdDispResult;
            int setItemtSalesSlipCdFlgResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetItemtSalesSlipCd(setItemtSalesSlipCdDispResult, setItemtSalesSlipCdFlgResult);

            //.NETクラス→構造体変換
            setItemtSalesSlipCdDisp = setItemtSalesSlipCdDispResult;
            setItemtSalesSlipCdFlg = setItemtSalesSlipCdFlgResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//オプション情報処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_FormPosSerialize(
    int topInt, 
    int leftInt, 
    int heightInt, 
    int widthInt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int topIntResult = topInt;
            int leftIntResult = leftInt;
            int heightIntResult = heightInt;
            int widthIntResult = widthInt;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->FormPosSerialize(topIntResult, leftIntResult, heightIntResult, widthIntResult);

            //.NETクラス→構造体変換
            topInt = topIntResult;
            leftInt = leftIntResult;
            heightInt = heightIntResult;
            widthInt = widthIntResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//オプション情報処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_FormPosDeserialize(
    int &topInt, 
    int &leftInt, 
    int &heightInt, 
    int &widthInt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        topInt = 0;
        leftInt = 0;
        heightInt = 0;
        widthInt = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int topIntResult;
            int leftIntResult;
            int heightIntResult;
            int widthIntResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->FormPosDeserialize(topIntResult, leftIntResult, heightIntResult, widthIntResult);

            //.NETクラス→構造体変換
            topInt = topIntResult;
            leftInt = leftIntResult;
            heightInt = heightIntResult;
            widthInt = widthIntResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//各種マスタチェック
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_InitMstCheck(
    bool &mstCheckFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraMstCheckFlg;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->InitMstCheck(paraMstCheckFlg);

			mstCheckFlg = paraMstCheckFlg;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//追加情報タブ項目Visible設定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetAddInfoVisible(
    int &ctTabKeyAddInfo, 
    int &settingAddInfoVisibleFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        ctTabKeyAddInfo = 0;
        settingAddInfoVisibleFlg = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int ctTabKeyAddInfoResult;
            int settingAddInfoVisibleFlgResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetAddInfoVisible(ctTabKeyAddInfoResult, settingAddInfoVisibleFlgResult);

            //.NETクラス→構造体変換
            ctTabKeyAddInfo = ctTabKeyAddInfoResult;
            settingAddInfoVisibleFlg = settingAddInfoVisibleFlgResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//伝票区分コンボエディタアイテム設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo(
    BSTR &inputModeTitle, 
    BSTR &defaultSalesSlipNumDf, 
    int &searchPartsModeFlg, 
    int &operationCodeFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        inputModeTitle = NULL;
        defaultSalesSlipNumDf = NULL;
        searchPartsModeFlg = 0;
        operationCodeFlg = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            String^ inputModeTitleResult;
            String^ defaultSalesSlipNumDfResult;
            int searchPartsModeFlgResult;
            int operationCodeFlgResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetDisplayHeaderFooterInfo(inputModeTitleResult, defaultSalesSlipNumDfResult, searchPartsModeFlgResult, operationCodeFlgResult);

            //.NETクラス→構造体変換
            inputModeTitle = static_cast<BSTR>(Marshal::StringToBSTR(inputModeTitleResult).ToPointer());
            defaultSalesSlipNumDf = static_cast<BSTR>(Marshal::StringToBSTR(defaultSalesSlipNumDfResult).ToPointer());
            searchPartsModeFlg = searchPartsModeFlgResult;
            operationCodeFlg = operationCodeFlgResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//得意先情報画面格納処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetDisplayCustomerInfo(
    int &customerNameFlg, 
    BSTR &totalDayDf, 
    BSTR &collectMoneyDf
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        customerNameFlg = 0;
        totalDayDf = NULL;
        collectMoneyDf = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int customerNameFlgResult;
            String^ totalDayDfResult;
            String^ collectMoneyDfResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetDisplayCustomerInfo(customerNameFlgResult, totalDayDfResult, collectMoneyDfResult);

            //.NETクラス→構造体変換
            customerNameFlg = customerNameFlgResult;
            totalDayDf = static_cast<BSTR>(Marshal::StringToBSTR(totalDayDfResult).ToPointer());
            collectMoneyDf = static_cast<BSTR>(Marshal::StringToBSTR(collectMoneyDfResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//明細データ取得
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetUserGdBdComboEditor(
    BSTR *&guideCodeList,
    int &guideCodeListCount, 
    BSTR *&guideNameList,
    int &guideNameListCount
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        guideCodeList = NULL;
        guideCodeListCount = 0;
        guideNameList = NULL;
        guideNameListCount = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            List<String^>^ guideCodeListResultList;
            List<String^>^ guideNameListResultList;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SetUserGdBdComboEditor(guideCodeListResultList, guideNameListResultList);

            //.NETクラス→構造体変換
            if(guideCodeListResultList != nullptr
                && guideCodeListResultList->Count > 0){

                    //構造体用の領域確保
                    BSTR *resultStructList = new BSTR[guideCodeListResultList->Count];
                    ZeroMemory(resultStructList, guideCodeListResultList->Count * sizeof(int));

                    for( int i = 0 ; i < guideCodeListResultList->Count ; i++){
                        //CopyClassToStruct_XXXX(guideCodeListResultList[i], &resultStructList[i]);
						resultStructList[i] = static_cast<BSTR>(Marshal::StringToBSTR(guideCodeListResultList[i]).ToPointer());

                    }

                    //結果を戻す
                    guideCodeList = resultStructList;
                    guideCodeListCount = guideCodeListResultList->Count;
            }

            if(guideNameListResultList != nullptr
                && guideNameListResultList->Count > 0){

                    //構造体用の領域確保
                    BSTR *resultStructList = new BSTR[guideNameListResultList->Count];
                    ZeroMemory(resultStructList, guideNameListResultList->Count * sizeof(BSTR));

                    for( int i = 0 ; i < guideNameListResultList->Count ; i++){
                        //CopyClassToStruct_XXXX(guideNameListResultList[i], &resultStructList[i]);
						resultStructList[i] = static_cast<BSTR>(Marshal::StringToBSTR(guideNameListResultList[i]).ToPointer());
                    }

                    //結果を戻す
                    guideNameList = resultStructList;
                    guideNameListCount = guideNameListResultList->Count;
            }

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//セルEnabled設定取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetCellEnabled(
    BSTR keyName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ keyNameResult = gcnew String(keyName);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->GetCellEnabled(keyNameResult);

            //.NETクラス→構造体変換
            keyName = static_cast<BSTR>(Marshal::StringToBSTR(keyNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//行値引き処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonLineDiscountClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonLineDiscountClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//商品値引き処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonGoodsDiscountClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonGoodsDiscountClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//注釈処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonAnnotationClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonAnnotationClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//倉庫切替処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonChangeWarehouseClick(
    int parmSalesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmSalesRowNoResult = parmSalesRowNo;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonChangeWarehouseClick(parmSalesRowNoResult);

            //.NETクラス→構造体変換
            parmSalesRowNo = parmSalesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//在庫検索処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonStockSearchClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonStockSearchClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//ＴＢＯ処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonTBOClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonTBOClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//前行複写処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonCopyStockBefLineClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//一括複写処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick(
    int parmRowIndex
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int parmRowIndexResult = parmRowIndex;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonCopyStockAllLineClick(parmRowIndexResult);

            //.NETクラス→構造体変換
            parmRowIndex = parmRowIndexResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//グリッドセルアップデート後処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate(
    int rowIndexParm, 
    BSTR cellValue, 
    BSTR beforeCellValue, 
    BSTR columnName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowIndexParmResult = rowIndexParm;
            String^ cellValueResult = gcnew String(cellValue);
            String^ beforeCellValueResult = gcnew String(beforeCellValue);
            String^ columnNameResult = gcnew String(columnName);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uGridDetailsAfterCellUpdate(rowIndexParmResult, cellValueResult, beforeCellValueResult, columnNameResult);

            //.NETクラス→構造体変換
            rowIndexParm = rowIndexParmResult;
            cellValue = static_cast<BSTR>(Marshal::StringToBSTR(cellValueResult).ToPointer());
            beforeCellValue = static_cast<BSTR>(Marshal::StringToBSTR(beforeCellValueResult).ToPointer());
            columnName = static_cast<BSTR>(Marshal::StringToBSTR(columnNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// ADD 2010/09/13 --- >>>>
//グリッドセルアップデート後処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc(
    int rowIndexParm, 
    BSTR cellValue, 
    BSTR beforeCellValue, 
    BSTR columnName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowIndexParmResult = rowIndexParm;
            String^ cellValueResult = gcnew String(cellValue);
            String^ beforeCellValueResult = gcnew String(beforeCellValue);
            String^ columnNameResult = gcnew String(columnName);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uGridDetailsAfterCellUpdateProc(rowIndexParmResult, cellValueResult, beforeCellValueResult, columnNameResult);

            //.NETクラス→構造体変換
            rowIndexParm = rowIndexParmResult;
            cellValue = static_cast<BSTR>(Marshal::StringToBSTR(cellValueResult).ToPointer());
            beforeCellValue = static_cast<BSTR>(Marshal::StringToBSTR(beforeCellValueResult).ToPointer());
            columnName = static_cast<BSTR>(Marshal::StringToBSTR(columnNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ADD 2010/09/13 --- <<<<

//HOMEキー設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetHomeKeyFlg(
    bool homeKeyFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SetHomeKeyFlg(homeKeyFlg);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//Table処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_DeatilActionTable(
    int salesRowNo, 
    BSTR actionType
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            String^ actionTypeResult = gcnew String(actionType);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->DeatilActionTable(salesRowNoResult, actionTypeResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            actionType = static_cast<BSTR>(Marshal::StringToBSTR(actionTypeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//グリッド関連チェック処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GridJoinCheck(
    int salesRowNo, 
    int rowIndex, 
    int operationCode, 
    int mode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            int rowIndexResult = rowIndex;
            int operationCodeResult = operationCode;
            int modeResult = mode;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->GridJoinCheck(salesRowNoResult, rowIndexResult, operationCodeResult, modeResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
            rowIndex = rowIndexResult;
            operationCode = operationCodeResult;
            mode = modeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//チェック処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CheckDetailAction(
    int beforeRowIndex, 
    int parmRowIndex, 
    int checkType
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int beforeRowIndexResult = beforeRowIndex;
            int parmRowIndexResult = parmRowIndex;
            int checkTypeResult = checkType;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->CheckDetailAction(beforeRowIndexResult, parmRowIndexResult, checkTypeResult);

            //.NETクラス→構造体変換
            beforeRowIndex = beforeRowIndexResult;
            parmRowIndex = parmRowIndexResult;
            checkType = checkTypeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//ユーザー設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData(
    int &data, 
    int inputType
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        data = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int dataResult;
            int inputTypeResult = inputType;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->GetSalesSlipInputConstructionData(dataResult, inputTypeResult);

            //.NETクラス→構造体変換
            data = dataResult;
            inputType = inputTypeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//得意先注番のフォーカス処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR value,
	bool &dialogFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ valueResult = gcnew String(value);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->AfterPartySaleSlipNumFocus(paraSalesSlip, paraSalesSlipCurrent, valueResult, dialogFlag);

            //.NETクラス→構造体変換
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = static_cast<BSTR>(Marshal::StringToBSTR(valueResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// end add by tanh

// add by zhangkai

//ガイドボタンクリックイベント処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonGuideClick(
    int rowIndexParm, 
    BSTR columnName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowIndexParmResult = rowIndexParm;
            String^ columnNameResult = gcnew String(columnName);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->uButtonGuideClick(rowIndexParmResult, columnNameResult);

            //.NETクラス→構造体変換
            rowIndexParm = rowIndexParmResult;
            columnName = static_cast<BSTR>(Marshal::StringToBSTR(columnNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//移動位置取得処理(Enterキー移動時)
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetNextMovePosition(
    BSTR p, 
    BSTR &afterColKeyName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        afterColKeyName = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ pResult = gcnew String(p);
            String^ afterColKeyNameResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetNextMovePosition(pResult, afterColKeyNameResult);

            //.NETクラス→構造体変換
            p = static_cast<BSTR>(Marshal::StringToBSTR(pResult).ToPointer());
            afterColKeyName = static_cast<BSTR>(Marshal::StringToBSTR(afterColKeyNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2010/06/02 ---------->>>>>
//移動位置取得処理(Enterキー移動時)
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetPreMovePosition(
    BSTR p, 
    BSTR &afterColKeyName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        afterColKeyName = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ pResult = gcnew String(p);
            String^ afterColKeyNameResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetPreMovePosition(pResult, afterColKeyNameResult);

            //.NETクラス→構造体変換
            p = static_cast<BSTR>(Marshal::StringToBSTR(pResult).ToPointer());
            afterColKeyName = static_cast<BSTR>(Marshal::StringToBSTR(afterColKeyNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/06/02 ----------<<<<<

//Param取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetParam(
    BSTR &startKeyName, 
    BSTR &endKeyNameList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        startKeyName = NULL;
        endKeyNameList = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ startKeyNameResult;
            String^ endKeyNameListResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetParam(startKeyNameResult, endKeyNameListResult);

            //.NETクラス→構造体変換
            startKeyName = static_cast<BSTR>(Marshal::StringToBSTR(startKeyNameResult).ToPointer());
            endKeyNameList = static_cast<BSTR>(Marshal::StringToBSTR(endKeyNameListResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//フォーカス移動対象判定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetEffectiveJudgment(
    BSTR keyName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ keyNameResult = gcnew String(keyName);

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->GetEffectiveJudgment(keyNameResult);

            //.NETクラス→構造体変換
            keyName = static_cast<BSTR>(Marshal::StringToBSTR(keyNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// end add by zhangkai

// add by yangmj
//出荷計上処理
//出荷計上処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ShipmentAddUp(
    bool isDataChanged, 
    int &isSave
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(IsDataChanged, paraIsDataChanged);
            //SalesSlip^ paraSalesSlip;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->ShipmentAddUp(isDataChanged, isSave);

            //.NETクラス→構造体変換
            //if(paraSalesSlip != nullptr){
            //    CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//出荷照会ボタンクリック処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSalesHisGuide(
    int count,
	BSTR customerCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();


        try{
            //構造体→.NETクラスへ変換
            int countResult = count;
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetSalesHisGuide(countResult, gcnew String(customerCode));

            //.NETクラス→構造体変換
            count = countResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//受注照会(明細選択)
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch(
    int rowCount,
	BSTR customerCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowCountResult = rowCount;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->AcceptAnOrderReferenceSearch(rowCountResult, gcnew String(customerCode));

            //.NETクラス→構造体変換
            rowCount = rowCountResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//受注計上処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_AcceptAnOrderAddup(
    bool IsDataChanged, 
    int &IsResult
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->AcceptAnOrderAddup(IsDataChanged, IsResult);

            //.NETクラス→構造体変換

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//見積計上(明細選択)
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_EstimateReferenceSearch(
    int rowCount,
	BSTR customerCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
        try{
            //構造体→.NETクラスへ変換
            int rowCountResult = rowCount;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->EstimateReferenceSearch(rowCountResult, gcnew String(customerCode));

            //.NETクラス→構造体変換
            rowCount = rowCountResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//見積照会(伝票選択)
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_EstimateAddup(
    bool IsDataChanged, 
    int &IsResult
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(&IsDataChanged, paraIsDataChanged);
            //bool^ paraIsResult;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->EstimateAddup(IsDataChanged, IsResult);

            //.NETクラス→構造体変換
            //if(paraIsResult != nullptr){
            //    CopyClassToStruct_bool(paraIsResult, &IsResult);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//履歴照会(売上履歴データから明細選択) 
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SalesReferenceSearch(
    int rowCount,
	BSTR customerCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowCountResult = rowCount;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SalesReferenceSearch(rowCountResult, gcnew String(customerCode));

            //.NETクラス→構造体変換
            rowCount = rowCountResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//伝票複写
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CopySlip(
    bool IsDataChanged, 
    int &IsResult
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(&IsDataChanged, paraIsDataChanged);
            //bool^ paraIsResult;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->CopySlip(IsDataChanged, IsResult);

            //.NETクラス→構造体変換
            //if(paraIsResult != nullptr){
            //    CopyClassToStruct_bool(paraIsResult, &IsResult);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両管理オプション取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetOptCarMng(
    int &optCarMng
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        optCarMng = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int optCarMngResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetOptCarMng(optCarMngResult);

            //.NETクラス→構造体変換
            optCarMng = optCarMngResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//伝票備考、伝票備考２、伝票備考３の入力桁数設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetNoteCharCnt(
    int &slipNoteCharCnt, 
    int &slipNote2CharCnt, 
    int &slipNote3CharCnt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        slipNoteCharCnt = 0;
        slipNote2CharCnt = 0;
        slipNote3CharCnt = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int slipNoteCharCntResult;
            int slipNote2CharCntResult;
            int slipNote3CharCntResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SetNoteCharCnt(slipNoteCharCntResult, slipNote2CharCntResult, slipNote3CharCntResult);

            //.NETクラス→構造体変換
            slipNoteCharCnt = slipNoteCharCntResult;
            slipNote2CharCnt = slipNote2CharCntResult;
            slipNote3CharCnt = slipNote3CharCntResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//返品処理関係
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ReturnSlip(
    bool isDataChanged, 
    int &isResult
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        isResult = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(&isDataChanged, paraIsDataChanged);
            int isResultResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->ReturnSlip(isDataChanged, isResultResult);

            //.NETクラス→構造体変換
            isResult = isResultResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//保存確認ダイアログ表示処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ShowSaveCheckDialog(
// --- UPD m.suzuki 2010/06/12 ---------->>>>>    
//    bool isConfirm, 
//    int &resultNum,
//    BSTR carMngCode
	bool isConfirm, 
    int &resultNum,
	BSTR carMngCode,
	bool &isMakeQR
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        resultNum = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsConfirm = gcnew bool();

            //CopyStructToClass_bool(&isConfirm, paraIsConfirm);
            int resultNumResult;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			bool resultIsMakeQR = isMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<

            //アクセスクラスメソッド呼出し
			// --- UPD m.suzuki 2010/06/12 ---------->>>>>
            //delphiSalesSlipInputAcs->ShowSaveCheckDialog(isConfirm, resultNumResult, gcnew String(carMngCode));
            delphiSalesSlipInputAcs->ShowSaveCheckDialog(isConfirm, resultNumResult, gcnew String(carMngCode), resultIsMakeQR );
			// --- UPD m.suzuki 2010/06/12 ----------<<<<<

            //.NETクラス→構造体変換
            resultNum = resultNumResult;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			isMakeQR = resultIsMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//保存処理
__declspec(dllexport) bool __stdcall DelphiSalesSlipInputAcs_Save(
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//    bool isShowSaveCompletionDialog, 
//    bool isConfirm
    bool isShowSaveCompletionDialog, 
    bool isConfirm,
	bool &isMakeQR
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
    ){
        bool status = false;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			bool paraIsMakeQR = isMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<

            //アクセスクラスメソッド呼出し
			// 2011/01/31 >>>
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
            //status = delphiSalesSlipInputAcs->Save(isShowSaveCompletionDialog, isConfirm);
            //status = delphiSalesSlipInputAcs->Save(isShowSaveCompletionDialog, isConfirm, paraIsMakeQR, false);
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
			status = delphiSalesSlipInputAcs->Save(isShowSaveCompletionDialog, isConfirm, paraIsMakeQR);
			// 2011/01/31 <<<

            //.NETクラス→構造体変換
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			isMakeQR = paraIsMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
        }
        catch(Exception ^ex){
            status = false;
        }

        return status;
    }

//保存後処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_AfterSave(
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//    int &result,
//    BSTR carMngCode,
//    bool printSlipFlag
	int &result,
	BSTR carMngCode,
	bool printSlipFlag,
	bool &isMakeQR,
// 2011/01/31 >>>
	//bool scmFlg
	bool &scmFlg,
	bool &cmtFlg,
// 2011/01/31 <<<
    bool &slipNote2ErrFlag, // ADD K2011/08/12
// UPD 2013/03/28 SCM障害№192対応 ----------------->>>>>
	//bool &salesDateErrFlag // ADD K2011/09/01
	bool &salesDateErrFlag, // ADD K2011/09/01
    int &isScmSave
// UPD 2013/03/28 SCM障害№192対応 -----------------<<<<<
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        result = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int resultResult;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			bool resultIsMakeQR = isMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
			// 2011/01/31 >>>
			bool resultScmFlg = scmFlg;
			bool resultCmtFlg;
			bool resultSlipNote2ErrFlag; // ADD K2011/08/12
			bool resultSalesDateErrFlag; // ADD K2011/09/01
			// 2011/01/31 <<<
			// ADD 2013/03/28 SCM障害№192対応 -------------------->>>>>
			int resultisSCMSave;
			// ADD 2013/03/28 SCM障害№192対応 --------------------<<<<<
			
            //アクセスクラスメソッド呼出し
			// 2011/01/31 >>>
			//// --- UPD m.suzuki 2010/06/12 ---------->>>>>
            ////delphiSalesSlipInputAcs->AfterSave(resultResult, gcnew String(carMngCode), printSlipFlag);
            //delphiSalesSlipInputAcs->AfterSave( resultResult, gcnew String(carMngCode), printSlipFlag, resultIsMakeQR, scmFlg );
			//// --- UPD m.suzuki 2010/06/12 ----------<<<<<

			// ----- DEL K2011/09/01 --------------------------->>>>>
			//delphiSalesSlipInputAcs->AfterSave( resultResult, gcnew String(carMngCode), printSlipFlag, resultIsMakeQR, resultScmFlg, resultCmtFlg ,resultSlipNote2ErrFlag); // UPD K2011/08/12
			// ----- DEL K2011/09/01 ---------------------------<<<<<
			// ----- ADD K2011/09/01 --------------------------->>>>>
			// UPD 2013/03/28 SCM障害№192対応 ----------------------->>>>>
			//delphiSalesSlipInputAcs->AfterSave( resultResult, gcnew String(carMngCode), printSlipFlag, resultIsMakeQR, resultScmFlg, resultCmtFlg ,resultSlipNote2ErrFlag ,resultSalesDateErrFlag); 
			delphiSalesSlipInputAcs->AfterSave( resultResult, gcnew String(carMngCode), printSlipFlag, resultIsMakeQR, resultScmFlg, resultCmtFlg ,resultSlipNote2ErrFlag ,resultSalesDateErrFlag , resultisSCMSave); 
			// UPD 2013/03/28 SCM障害№192対応 -----------------------<<<<<
			// ----- ADD K2011/09/01 ---------------------------<<<<<
			
			// 2011/01/31 <<<

            //.NETクラス→構造体変換
            result = resultResult;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			isMakeQR = resultIsMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
			// 2011/01/31 >>>
			scmFlg = resultScmFlg;
			cmtFlg = resultCmtFlg;
			// 2011/01/31 <<<
			slipNote2ErrFlag = resultSlipNote2ErrFlag; // ADD K2011/08/12
			salesDateErrFlag = resultSalesDateErrFlag; // ADD K2011/09/01
			// ADD 2013/03/28 SCM障害№192対応 -------------------->>>>>
			isScmSave = resultisSCMSave;
			// ADD 2013/03/28 SCM障害№192対応 --------------------<<<<<
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//保存状態取得
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSaveStatus(
    int &saveStatus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        status = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int saveStatusResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetSaveStatus(saveStatusResult);

            //.NETクラス→構造体変換
            saveStatus = saveStatusResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
//オンライン種別取得
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetOnlineKindDiv(
    int &onlineKindDiv
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        status = 0;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int onlineKindDivResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetOnlineKindDiv(onlineKindDivResult);

            //.NETクラス→構造体変換
            onlineKindDiv = onlineKindDivResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

//部品検索切替処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ChangeSearchMode(
    int clearCarFlag, 
    bool CheckRowEffectiveFlg, 
    int salesRowNo, 
    bool ContainsFocusFlg, 
    bool &carMngCodeMode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->ChangeSearchMode(clearCarFlag, CheckRowEffectiveFlg, salesRowNo, ContainsFocusFlg, carMngCodeMode);

            //.NETクラス→構造体変換
            //clearCarFlag = clearCarFlagResult;
            //salesRowNo = salesRowNoResult;
            //if(paraCarMngCodeMode != nullptr){
            //    CopyClassToStruct_bool(paraCarMngCodeMode, &carMngCodeMode);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//部品検索モード取得
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSearchPartsModeProperty(
    int &searchPartsModeProperty
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        searchPartsModeProperty = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int searchPartsModePropertyResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetSearchPartsModeProperty(searchPartsModePropertyResult);

            //.NETクラス→構造体変換
            searchPartsModeProperty = searchPartsModePropertyResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//----ADD 2010/06/17----->>>>>
//売上データ設定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetSalesSlip(
    StructSalesSlip Salesslip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesslip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&Salesslip, paraSalesslip);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SetSalesSlip(paraSalesslip);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//----ADD 2010/06/17-----<<<<<
// end add by yangmj
//----ADD 2010/11/02----->>>>>
//売上データ設定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetSalesSlipByObj(
    StructSalesSlip Salesslip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            SalesSlip^ paraSalesslip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&Salesslip, paraSalesslip);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SetSalesSlipByObj(paraSalesslip);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
 //----ADD 2010/11/02-----<<<<<
// add by gaofeng start
//初期データをＤＢより取得の処理
__declspec(dllexport) int __stdcall DelphiGetSalesSlipInputInitDataAcs_GetInitData(

    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		DelphiGetSalesSlipInputInitDataAcs^ delphiGetSalesSlipInputInitDataAcs = DelphiGetSalesSlipInputInitDataAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiGetSalesSlipInputInitDataAcs->GetInitData();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上伝票ガイド処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_salesSlipGuide(
	BSTR formName,
    BSTR enterpriseCode, 
    int acptAnOdrStatusDisplay, 
    int &acptAnOdrStatus, 
    int &estimateDivide, 
    StructSalesSlipSearchResult &searchResult,
	StructSalesSlip &salesSlip,
	bool &outDialogResult,
	bool &outStatus,
	bool &consTaxLayMethodChangedFlg
	, bool &isPCCUOESaleSlip  // ADD 2011/11/18
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        estimateDivide = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			String^ formNameResult = gcnew String(formName);
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            int acptAnOdrStatusDisplayResult = acptAnOdrStatusDisplay;
            int acptAnOdrStatusResult = acptAnOdrStatus;
            int estimateDivideResult;
            SalesSlipSearchResult^ paraSearchResult;
			SalesSlip^ salesSlipResult;
			bool paraOutDialogResult = outDialogResult;
			bool paraOutStatus = outStatus;
			bool paraConsTaxLayMethodChangedFlg = consTaxLayMethodChangedFlg;
			bool paraIsPCCUOESaleSlip = isPCCUOESaleSlip;  // ADD 2011/11/18

            //アクセスクラスメソッド呼出し
			// --- UPD 2011/11/18---------->>>>>
    //        delphiSalesSlipInputAcs->salesSlipGuide(formNameResult, enterpriseCodeResult, acptAnOdrStatusDisplayResult, 
				//acptAnOdrStatusResult, estimateDivideResult, paraSearchResult, salesSlipResult, paraOutDialogResult, paraOutStatus, paraConsTaxLayMethodChangedFlg);
			            delphiSalesSlipInputAcs->salesSlipGuide(formNameResult, enterpriseCodeResult, acptAnOdrStatusDisplayResult, 
				acptAnOdrStatusResult, estimateDivideResult, paraSearchResult, salesSlipResult, paraOutDialogResult, paraOutStatus, paraConsTaxLayMethodChangedFlg, paraIsPCCUOESaleSlip);
			// --- UPD 2011/11/18----------<<<<<

            //.NETクラス→構造体変換
			formName = static_cast<BSTR>(Marshal::StringToBSTR(formNameResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            acptAnOdrStatusDisplay = acptAnOdrStatusDisplayResult;
            acptAnOdrStatus = acptAnOdrStatusResult;
            estimateDivide = estimateDivideResult;
            if(paraSearchResult != nullptr){
                CopyClassToStruct_SalesSlipSearchResult(paraSearchResult, &searchResult);
            }
			if(salesSlipResult != nullptr){
                CopyClassToStruct_SalesSlip(salesSlipResult, &salesSlip);
            }
			outDialogResult = paraOutDialogResult;
			outStatus = paraOutStatus;
			consTaxLayMethodChangedFlg = paraConsTaxLayMethodChangedFlg;
			isPCCUOESaleSlip = paraIsPCCUOESaleSlip; // ADD 2011/11/18
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//得意先ガイド処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_customerGuide(
	bool customerFlag,
	int addresseeCode,
    int customerCode, 
    StructCustomerSearchRet &customerSearchRet,
	int &dialogResultFlag,
	bool &customerCodeChangedFlg,
	bool &optCarMngFlg
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
        try{
            //構造体→.NETクラスへ変換
            CustomerSearchRet^ paraCustomerSearchRet;
			int dialogResultFlagResult;
			bool customerCodeChangedFlgResult;
			bool optCarMngFlgResult;

			//アクセスクラスメソッド呼出し
			delphiSalesSlipInputAcs->customerGuide(customerFlag, addresseeCode, customerCode, paraCustomerSearchRet, dialogResultFlagResult, customerCodeChangedFlgResult, optCarMngFlgResult);

            //.NETクラス→構造体変換
            if(paraCustomerSearchRet != nullptr){
                CopyClassToStruct_CustomerSearchRet(paraCustomerSearchRet, &customerSearchRet);
            }
			dialogResultFlag = dialogResultFlagResult;
			customerCodeChangedFlg = customerCodeChangedFlgResult;
			optCarMngFlg = optCarMngFlgResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ShowSalesSlipInputSetup(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->ShowSalesSlipInputSetup();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//画面項目名称取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetDisplayName(
	// UPD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
    /*BSTR &rateName*/
	BSTR &rateName,
    bool &taxFlg
	// UPD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        rateName = NULL;
        taxFlg = false;// ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ rateNameResult;
            bool taxFlgResult; // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応
            //アクセスクラスメソッド呼出し
			// UPD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
			//delphiSalesSlipInputAcs->GetDisplayName(rateNameResult);
            delphiSalesSlipInputAcs->GetDisplayName(rateNameResult, taxFlgResult);
			// UPD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<

            //.NETクラス→構造体変換
            rateName = static_cast<BSTR>(Marshal::StringToBSTR(rateNameResult).ToPointer());
            taxFlg = taxFlgResult;// ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//明細粗利率取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetDetailGrossProfitRate(
	int rowNo,
    BSTR &detailGrossProfitRate, 
    BSTR &addDetailGrossProfitRate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        detailGrossProfitRate = NULL;
        addDetailGrossProfitRate = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ detailGrossProfitRateResult;
            String^ addDetailGrossProfitRateResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetDetailGrossProfitRate(rowNo, detailGrossProfitRateResult, addDetailGrossProfitRateResult);

            //.NETクラス→構造体変換
            detailGrossProfitRate = static_cast<BSTR>(Marshal::StringToBSTR(detailGrossProfitRateResult).ToPointer());
            addDetailGrossProfitRate = static_cast<BSTR>(Marshal::StringToBSTR(addDetailGrossProfitRateResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//削除処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_Delete(
    bool &outCheck, 
    int &outDialogResult, 
    int &outStatus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
		outCheck = false;
        outDialogResult = 0;
        outStatus = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			bool outCheckResult;
            int outDialogResultResult;
            int outStatusResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->Delete(outCheckResult, outDialogResultResult, outStatusResult);

            //.NETクラス→構造体変換
            outDialogResult = outDialogResultResult;
            outStatus = outStatusResult;
			outCheck = outCheckResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//アイテム名の取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetItemName(
    BSTR &itemName, 
    BSTR &tableName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        itemName = NULL;
        tableName = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ itemNameResult;
            String^ tableNameResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetItemName(itemNameResult, tableNameResult);

            //.NETクラス→構造体変換
            itemName = static_cast<BSTR>(Marshal::StringToBSTR(itemNameResult).ToPointer());
            tableName = static_cast<BSTR>(Marshal::StringToBSTR(tableNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//状態の取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetStatus(
    int &outStatus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        status = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int statusResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetStatus(statusResult);

            //.NETクラス→構造体変換
            outStatus = statusResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//名称の取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText(
    BSTR &beforeSalesSlipNumText
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        beforeSalesSlipNumText = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ beforeSalesSlipNumTextResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetBeforeSalesSlipNumText(beforeSalesSlipNumTextResult);

            //.NETクラス→構造体変換
            beforeSalesSlipNumText = static_cast<BSTR>(Marshal::StringToBSTR(beforeSalesSlipNumTextResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//オプション情報処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetGrossProfitRateFlg(
    bool &grossProfitRateFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraGrossProfitRateFlg;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetGrossProfitRateFlg(paraGrossProfitRateFlg);

            //.NETクラス→構造体変換
            grossProfitRateFlg = paraGrossProfitRateFlg;

			}
			catch(Exception ^ex){
				status = -1;
			}

        return status;
    }

//フォーカス位置の取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetFocusPositionValue(
    int &focusPositionValue
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        focusPositionValue = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int focusPositionValueResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetFocusPositionValue(focusPositionValueResult);

            //.NETクラス→構造体変換
            focusPositionValue = focusPositionValueResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//赤伝処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_RedSlip(
    bool isConfirm,
	bool canRed
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
			
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->RedSlip(isConfirm, canRed);

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//赤伝できるかどうかフラグの取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetCanRed(
    bool &canRed
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraCanRed;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetCanRed(paraCanRed);

			canRed = paraCanRed;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetRedDialogResult(
    int &redDialogResult
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int paraRedDialogResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetRedDialogResult(paraRedDialogResult);

			redDialogResult = paraRedDialogResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//見出貼付
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CopySlipHeader(
	bool carInfoEnabledFlg,
	int salesRowNo,
	BSTR addresseeName,
	bool &existSalesDetail, 
    bool &clearDetailFlg, 
    int &searchPartsModeProperty, 
    bool &fullModelFixedNoAryFlg, 
	bool &errorFlg, 
    StructSalesSlipHeaderCopyData &outSalesSlipHeaderCopyData,
	bool &copySlipHeaderClearFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
			bool paraExistSalesDetail;
			bool paraClearDetailFlg;
			int paraSearchPartsModeProperty;
			bool paraFullModelFixedNoAryFlg;
			bool paraErrorFlg;
			SalesSlipHeaderCopyData^ paraSalesSlipHeaderCopyData;
			bool paraCopySlipHeaderClearFlg;
			String^ paraAddresseeName = gcnew String(addresseeName);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->CopySlipHeader(carInfoEnabledFlg, salesRowNo, paraAddresseeName, paraExistSalesDetail, 
				paraClearDetailFlg, paraSearchPartsModeProperty, paraFullModelFixedNoAryFlg, paraErrorFlg, paraSalesSlipHeaderCopyData, paraCopySlipHeaderClearFlg);

            //.NETクラス→構造体変換
			existSalesDetail = paraExistSalesDetail;
			clearDetailFlg = paraClearDetailFlg;
			searchPartsModeProperty = paraSearchPartsModeProperty;
			fullModelFixedNoAryFlg = paraFullModelFixedNoAryFlg;
			errorFlg = paraErrorFlg;
			copySlipHeaderClearFlg = paraCopySlipHeaderClearFlg;
			if(paraSalesSlipHeaderCopyData != nullptr){
                CopyClassToStruct_SalesSlipHeaderCopyData(paraSalesSlipHeaderCopyData, &outSalesSlipHeaderCopyData);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//-------------- ADD 連番729 2011/08/18 ----------------->>>>>
//詳細貼付
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CopySlipDetail(
	int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->CopySlipDetail(salesRowNo);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//-------------- ADD 連番729 2011/08/18 -----------------<<<<<

//管理番号ガイド表示後の処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn(
    int paraStatus, 
    StructCarMangInputExtraInfo selectedInfo, 
    int inputflag, 
    int salesRowNo, 
    BSTR carMngCode, 
    bool &returnFlag, 
    bool &clearCarInfoFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            CarMangInputExtraInfo^ paraSelectedInfo = gcnew CarMangInputExtraInfo();

            CopyStructToClass_CarMangInputExtraInfo(&selectedInfo, paraSelectedInfo);

            String^ carMngCodeResult = gcnew String(carMngCode);
            bool paraReturnFlag;

            bool paraClearCarInfoFlag;


            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->AfterCarMngNoGuideReturn(paraStatus, paraSelectedInfo, inputflag, salesRowNo, carMngCodeResult, paraReturnFlag, paraClearCarInfoFlag);

            //.NETクラス→構造体変換
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());

			returnFlag = paraReturnFlag;
			clearCarInfoFlag = paraClearCarInfoFlag;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//xxxx
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_setToolMenuCustomizeSetting(
    BSTR key
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();;

        try{
            //構造体→.NETクラスへ変換
            String^ keyResult = gcnew String(key);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->setToolMenuCustomizeSetting(keyResult);

            //.NETクラス→構造体変換
            key = static_cast<BSTR>(Marshal::StringToBSTR(keyResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//xxxx
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_getToolMenuCustomizeSetting(
    bool &toolMenuCustomizeSettingNotNull, 
    bool &toolBarVisible, 
    int &toolBarDockedRow, 
    int &toolBarDockedColumn, 
    int &toolBarDockedPosition
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        toolBarDockedRow = 0;
        toolBarDockedColumn = 0;
        toolBarDockedPosition = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraToolMenuCustomizeSettingNotNull;

            bool paraToolBarVisible;

            int toolBarDockedRowResult;
            int toolBarDockedColumnResult;
            int toolBarDockedPositionResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->getToolMenuCustomizeSetting(paraToolMenuCustomizeSettingNotNull, paraToolBarVisible, toolBarDockedRowResult, toolBarDockedColumnResult, toolBarDockedPositionResult);

            //.NETクラス→構造体変換
			toolMenuCustomizeSettingNotNull = paraToolMenuCustomizeSettingNotNull;
			toolBarVisible = paraToolBarVisible;
            toolBarDockedRow = toolBarDockedRowResult;
            toolBarDockedColumn = toolBarDockedColumnResult;
            toolBarDockedPosition = toolBarDockedPositionResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//xxxx
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_setToolButtonCustomizeSetting(
    BSTR key
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ keyResult = gcnew String(key);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->setToolButtonCustomizeSetting(keyResult);

            //.NETクラス→構造体変換
            key = static_cast<BSTR>(Marshal::StringToBSTR(keyResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//xxxx
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_getToolButtonCustomizeSetting(
    bool &toolButtonCustomizeSettingNotNull, 
    int &toolBarCustomizedVisible
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        toolBarCustomizedVisible = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraToolButtonCustomizeSettingNotNull;

            int toolBarCustomizedVisibleResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->getToolButtonCustomizeSetting(paraToolButtonCustomizeSettingNotNull, toolBarCustomizedVisibleResult);

            toolButtonCustomizeSettingNotNull = paraToolButtonCustomizeSettingNotNull;
            toolBarCustomizedVisible = toolBarCustomizedVisibleResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//SaveToolbarCustomizeSetting
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting(
    BSTR key, 
    bool visible
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ keyResult = gcnew String(key);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SaveToolbarCustomizeSetting(keyResult, visible);

            //.NETクラス→構造体変換
            key = static_cast<BSTR>(Marshal::StringToBSTR(keyResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//SaveToolManagerCustomizeInfo
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo(
    BSTR key, 
    bool visible, 
    int dockedRow, 
    int dockedColumn, 
    int dockedPosition
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ keyResult = gcnew String(key);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SaveToolManagerCustomizeInfo(keyResult, visible, dockedRow, dockedColumn, dockedPosition);

            //.NETクラス→構造体変換
            key = static_cast<BSTR>(Marshal::StringToBSTR(keyResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//SaveCustomizeXml
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SaveCustomizeXml(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SaveCustomizeXml();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetUltraOptionSetValue(
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->GetUltraOptionSetValue();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    } 

__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SlipNoteGuide(
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->SlipNoteGuide(salesRowNoResult);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//売上金額変更後発生イベント処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SalesPriceChanged(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SalesPriceChanged();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//車両情報設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CarInfoFormSetting(
    int salesRowNo, 
    bool &isGoodsFlg, 
    bool &carInfoRowFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            bool paraIsGoodsFlg;

            bool paraCarInfoRowFlg;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->CarInfoFormSetting(salesRowNoResult, paraIsGoodsFlg, paraCarInfoRowFlg);

            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
			isGoodsFlg = paraIsGoodsFlg;
			carInfoRowFlg = paraCarInfoRowFlg;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//保存確認ダイアログ表示処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ShowRedSaveCheckDialog(
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//    bool isConfirm, 
//    bool &afterSaveClearFlg
    bool isConfirm, 
    bool &afterSaveClearFlg,
	bool &isMakeQR
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraAfterSaveClearFlg;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			bool paraIsMakeQR = isMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<

            //アクセスクラスメソッド呼出し
			// --- UPD m.suzuki 2010/06/12 ---------->>>>>
            //delphiSalesSlipInputAcs->ShowRedSaveCheckDialog(isConfirm, paraAfterSaveClearFlg);
            delphiSalesSlipInputAcs->ShowRedSaveCheckDialog(isConfirm, paraAfterSaveClearFlg,paraIsMakeQR);
			// --- UPD m.suzuki 2010/06/12 ----------<<<<<

            //.NETクラス→構造体変換
            afterSaveClearFlg = paraAfterSaveClearFlg;
			// --- ADD m.suzuki 2010/06/12 ---------->>>>>
			isMakeQR = paraIsMakeQR;
			// --- ADD m.suzuki 2010/06/12 ----------<<<<<
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//SetHeaderItemsDictionary
//---UPD 2010/07/06---------->>>>>
//__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetItemsDictionary(
//    BSTR headControlNames,
//	BSTR footControlNames
//    ){
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetItemsDictionary(
    BSTR headControlNames,
	BSTR footControlNames,
	BSTR functionControlNames,
	BSTR functionDetailControlNames // ADD 2010/08/13
    ){
//---UPD 2010/07/06----------<<<<<
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ headControlNamesResult = gcnew String(headControlNames);
			String^ footControlNamesResult = gcnew String(footControlNames);
			String^ functionControlNamesResult = gcnew String(functionControlNames);// ADD 2010/07/06
			String^ functionDetailControlNamesResult = gcnew String(functionDetailControlNames);// ADD 2010/08/13

            //アクセスクラスメソッド呼出し
			//---UPD 2010/07/06---------->>>>>
            //delphiSalesSlipInputAcs->SetItemsDictionary(headControlNamesResult, footControlNamesResult);
			delphiSalesSlipInputAcs->SetItemsDictionary(headControlNamesResult, footControlNamesResult, functionControlNamesResult, functionDetailControlNamesResult);
			//---UPD 2010/07/06----------<<<<<

            //.NETクラス→構造体変換
            headControlNames = static_cast<BSTR>(Marshal::StringToBSTR(headControlNamesResult).ToPointer());
			footControlNames = static_cast<BSTR>(Marshal::StringToBSTR(footControlNamesResult).ToPointer());
			functionControlNames = static_cast<BSTR>(Marshal::StringToBSTR(functionControlNamesResult).ToPointer());// ADD 2010/07/06
			functionDetailControlNames = static_cast<BSTR>(Marshal::StringToBSTR(functionDetailControlNamesResult).ToPointer());// ADD 2010/08/13
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// ADD 2010/08/13 ---- >>>>>
//ファンクション明細制御取得処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting(
    BSTR key, 
    int &bitButtonCustomizedVisible
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        bitButtonCustomizedVisible = 0;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ keyResult = gcnew String(key);
            int bitButtonCustomizedVisibleResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetBitButtonCustomizeSetting(keyResult, bitButtonCustomizedVisibleResult);

            //.NETクラス→構造体変換
            bitButtonCustomizedVisible = bitButtonCustomizedVisibleResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ADD 2010/08/13 ---- <<<<<

//setColDisplayStatusList
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_setColDisplayStatusList(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->setColDisplayStatusList();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//返品理由ガイド処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_retGoodsReason(
    BSTR enterpriseCode, 
    StructUserGdHd &userGdHd, 
    StructUserGdBd &userGdBd, 
	StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
			UserGdHd^ paraUserGdHd;
            UserGdBd^ paraUserGdBd;
			SalesSlip^ paraSalesSlip;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->retGoodsReason(enterpriseCodeResult, paraUserGdHd, paraUserGdBd, paraSalesSlip);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraUserGdHd != nullptr){
                CopyClassToStruct_UserGdHd(paraUserGdHd, &userGdHd);
            }
            if(paraUserGdBd != nullptr){
                CopyClassToStruct_UserGdBd(paraUserGdBd, &userGdBd);
            }
			if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/05/31 ---------->>>>>
//ESC処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonEscClick(
    bool &escFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraEscFlg;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->uButtonEscClick(paraEscFlg);

            //.NETクラス→構造体変換
            escFlg = paraEscFlg;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/05/31 ----------<<<<<

// --- ADD 2012/05/31 No.282---------->>>>>
//ESC処理2（発注解除）
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_uButtonEscClick2(
    bool &escFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraEscFlg;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->uButtonEscClick2(paraEscFlg);

            //.NETクラス→構造体変換
            escFlg = paraEscFlg;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//発注退避処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SaveOrderInfo(
    bool &escFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraEscFlg;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SaveOrderInfo(paraEscFlg);

            //.NETクラス→構造体変換
            escFlg = paraEscFlg;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2012/05/31 No.282----------<<<<<
//伝票メモ情報設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetSlipMemo(
    BSTR slipMemo1, 
    BSTR slipMemo2, 
    BSTR slipMemo3, 
    BSTR insideMemo1, 
    BSTR insideMemo2, 
    BSTR insideMemo3, 
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ slipMemo1Result = gcnew String(slipMemo1);
            String^ slipMemo2Result = gcnew String(slipMemo2);
            String^ slipMemo3Result = gcnew String(slipMemo3);
            String^ insideMemo1Result = gcnew String(insideMemo1);
            String^ insideMemo2Result = gcnew String(insideMemo2);
            String^ insideMemo3Result = gcnew String(insideMemo3);
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->SetSlipMemo(slipMemo1Result, slipMemo2Result, slipMemo3Result, insideMemo1Result, insideMemo2Result, insideMemo3Result, salesRowNoResult);

            //.NETクラス→構造体変換
            slipMemo1 = static_cast<BSTR>(Marshal::StringToBSTR(slipMemo1Result).ToPointer());
            slipMemo2 = static_cast<BSTR>(Marshal::StringToBSTR(slipMemo2Result).ToPointer());
            slipMemo3 = static_cast<BSTR>(Marshal::StringToBSTR(slipMemo3Result).ToPointer());
            insideMemo1 = static_cast<BSTR>(Marshal::StringToBSTR(insideMemo1Result).ToPointer());
            insideMemo2 = static_cast<BSTR>(Marshal::StringToBSTR(insideMemo2Result).ToPointer());
            insideMemo3 = static_cast<BSTR>(Marshal::StringToBSTR(insideMemo3Result).ToPointer());
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//数値入力チェック処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_KeyPressNumCheck(
    int keta, 
    int priod, 
    BSTR prevVal, 
    BSTR key, 
    int selstart, 
    int sellength, 
    bool minusFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int ketaResult = keta;
            int priodResult = priod;
            String^ prevValResult = gcnew String(prevVal);
            String^ keyResult = gcnew String(key);
            int selstartResult = selstart;
            int sellengthResult = sellength;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->KeyPressNumCheck(ketaResult, priodResult, prevValResult, keyResult, selstartResult, sellengthResult, minusFlg);

            //.NETクラス→構造体変換
            keta = ketaResult;
            priod = priodResult;
            prevVal = static_cast<BSTR>(Marshal::StringToBSTR(prevValResult).ToPointer());
            key = static_cast<BSTR>(Marshal::StringToBSTR(keyResult).ToPointer());
            selstart = selstartResult;
            sellength = sellengthResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//CSV出力先が設定され、フォルダが存在しているかチェック処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CsvPassCheck(
    BSTR &linkDir
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        linkDir = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
        try{
            //構造体→.NETクラスへ変換
            String^ linkDirResult;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->CsvPassCheck(linkDirResult);

            //.NETクラス→構造体変換
            linkDir = static_cast<BSTR>(Marshal::StringToBSTR(linkDirResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


// --- ADD 2010/06/02 ---------->>>>>
//GetReadSlipFlg
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetReadSlipFlg(
    bool &readSlipFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraReadSlipFlg;


            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetReadSlipFlg(paraReadSlipFlg);

            //.NETクラス→構造体変換
			readSlipFlg = paraReadSlipFlg;

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/06/02----------<<<<<

// --- ADD 2010/07/08 ---------->>>>>
//操作権限の制御
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_BeginControllingByOperationAuthority(
    bool &RevisionVisible, 
    bool &DeleteVisible, 
    bool &RedSlipVisible,
	bool &DiscountVisible// ADD 2013/01/24 鄧潘ハン REDMINE#34141
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraRevisionVisible;

            bool paraDeleteVisible;

            bool paraRedSlipVisible;

			bool paraSlipDiscountVisible;// ADD 2013/01/24 鄧潘ハン REDMINE#34141


            //アクセスクラスメソッド呼出し
            //delphiSalesSlipInputAcs->BeginControllingByOperationAuthority(paraRevisionVisible, paraDeleteVisible, paraRedSlipVisible);//DEL 2013/01/24 鄧潘ハン REDMINE#34141
            delphiSalesSlipInputAcs->BeginControllingByOperationAuthority(paraRevisionVisible, paraDeleteVisible, paraRedSlipVisible, paraSlipDiscountVisible);//ADD 2013/01/24 鄧潘ハン REDMINE#34141

            //.NETクラス→構造体変換
            RevisionVisible = paraRevisionVisible;
            DeleteVisible = paraDeleteVisible;
			RedSlipVisible = paraRedSlipVisible;
			DiscountVisible = paraSlipDiscountVisible; // ADD 2013/01/24 鄧潘ハン REDMINE#34141
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/07/08 ----------<<<<<

// --- ADD 黄興貴 2015/03/26 ---------------->>>>>
//UOEデータ取込
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ReadUoeData(    int salesRowNo    )
{
	int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
	DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
	try
	{            
		//構造体→.NETクラスへ変換            
		int parmSalesRowNo = salesRowNo;            
		//アクセスクラスメソッド呼出し            
		status = delphiSalesSlipInputAcs->ReadUoeData(parmSalesRowNo);            
		//.NETクラス→構造体変換            
		salesRowNo = parmSalesRowNo;        
	}        
	catch(Exception ^ex)
	{ 
		status = -1;        
	}       
	return status;    
}
//富士ジーワイ商事㈱ オプション判定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OptPermitForFuJi(
    bool &optPermitForFuJi
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraOptPermitForFuJiFlagResult;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->OptPermitForFuJi(paraOptPermitForFuJiFlagResult);
			
			optPermitForFuJi = paraOptPermitForFuJiFlagResult;

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 黄興貴 2015/03/26 ----------------<<<<<

// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
//㈱コーエイオプション判定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OptPermitForKoei(
    bool &optPermitForKoei
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool paraOptPermitForKoeiResult;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->OptPermitForKoei(paraOptPermitForKoeiResult);
			
			optPermitForKoei = paraOptPermitForKoeiResult;

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

// --- ADD 紀飛 2015/06/18 ---------------->>>>>
//㈱メイゴ オプション判定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OptPermitForMeiGo(
    bool &optPermitForMeiGo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
        try{
            //構造体→.NETクラスへ変換
            bool paraOptPermitForMeiGoFlagResult;
            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->OptPermitForMeiGo(paraOptPermitForMeiGoFlagResult);
			//.NETクラス→構造体変換
			optPermitForMeiGo = paraOptPermitForMeiGoFlagResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 紀飛 2015/06/18 ----------------<<<<<
// add by gaofeng end

// --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
//操作権限の判定
__declspec(dllexport) bool __stdcall DelphiSalesSlipInputAcs_GetOperationSt(int iOperationCode)
{
	DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
	try{
		//アクセスクラスメソッド呼出し
		return delphiSalesSlipInputAcs->GetOperationSt(iOperationCode);
	}
	catch(Exception ^ex){
	}
}
// --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
//最新情報処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ReNewalBtnClick(
    BSTR enterpriseCode, 
    BSTR loginSectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ loginSectionCodeResult = gcnew String(loginSectionCode);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->ReNewalBtnClick(enterpriseCodeResult, loginSectionCodeResult);

            //.NETクラス→構造体変換
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            loginSectionCode = static_cast<BSTR>(Marshal::StringToBSTR(loginSectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//xxxxx
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ProcessingDialogDispose(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->ProcessingDialogDispose();

            //.NETクラス→構造体変換
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// add by lizc end

// add by tanh begin
//明細データ取得
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSalesDetailDataTable(
    StructCustomArrayA2 salesDetailList,
    StructCustomArrayA2 &refSalesDetailList, 
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            ArrayList^ paraSalesDetailList = gcnew ArrayList();

            CopyStructToClass_CustomArrayA2(&salesDetailList, paraSalesDetailList);
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetSalesDetailDataTable(paraSalesDetailList, salesRowNoResult);

            //.NETクラス→構造体変換
            if(paraSalesDetailList != nullptr){
                CopyClassToStruct_CustomArrayA2(paraSalesDetailList, &refSalesDetailList);
            }
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//明細データ取得
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSalesAllDetailDataTable(
    StructCustomArrayA2 salesDetailList,
    StructCustomArrayA2 &refSalesDetailList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            ArrayList^ paraSalesDetailList = gcnew ArrayList();

            CopyStructToClass_CustomArrayA2(&salesDetailList, paraSalesDetailList);

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetSalesAllDetailDataTable(paraSalesDetailList);

            //.NETクラス→構造体変換
            if(paraSalesDetailList != nullptr){
                CopyClassToStruct_CustomArrayA2(paraSalesDetailList, &refSalesDetailList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SetSalesDetailData(
    BSTR inputdata, 
    int inputType
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ inputdataResult = gcnew String(inputdata);
            int inputTypeResult = inputType;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->SetSalesDetailData(inputdataResult, inputTypeResult);

            //.NETクラス→構造体変換
            inputdata = static_cast<BSTR>(Marshal::StringToBSTR(inputdataResult).ToPointer());
            inputType = inputTypeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//品番検索処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_AfterGoodsNoUpdate(
    int rowIndex, 
    BSTR cellValue, 
	int makerCd,  // ADD 連番729 2011/08/18
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int rowIndexResult = rowIndex;
            String^ cellValueResult = gcnew String(cellValue);
            int salesRowNoResult = salesRowNo;

            //アクセスクラスメソッド呼出し
            //status = delphiSalesSlipInputAcs->AfterGoodsNoUpdate(rowIndexResult, cellValueResult, salesRowNoResult);  //DEL 連番729 2011/08/18
			status = delphiSalesSlipInputAcs->AfterGoodsNoUpdate(rowIndexResult, cellValueResult, makerCd, salesRowNoResult); // ADD 連番729 2011/08/18

            //.NETクラス→構造体変換
            rowIndex = rowIndexResult;
            cellValue = static_cast<BSTR>(Marshal::StringToBSTR(cellValueResult).ToPointer());
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// add by tanh end

//>>>2010/05/30
// SCM問合せ一覧起動処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ReferenceList(
    bool isDataChanged, 
    int &isSave
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(IsDataChanged, paraIsDataChanged);
            //SalesSlip^ paraSalesSlip;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->SCMReferenceSearch(isDataChanged, isSave);

            //.NETクラス→構造体変換
            //if(paraSalesSlip != nullptr){
            //    CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>   
// 履歴検索の押下処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_HisSearch(
	int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
        	//構造体→.NETクラスへ変換
            int salesRowNoResult = salesRowNo;
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->CustomerProcess(salesRowNoResult);
            //.NETクラス→構造体変換
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
//----- ADD　ADD 譚洪  2020/02/24 PMKOBETSU-2912の対応------->>>>>   
// 税率入力の押下処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetTaxRate(
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetTaxRate();
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetTaxRateDialogResult(
	int &taxRateDialogResult
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
			//構造体→.NETクラスへ変換
            int paraTaxRateDialogResult;
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->GetTaxRateDialogResult(paraTaxRateDialogResult);
			taxRateDialogResult = paraTaxRateDialogResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
 __declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OrderCheck(
    int mode,
	bool &orderFlg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
			//構造体→.NETクラスへ変換
            bool retFlgResult;
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->OrderCheck(mode, retFlgResult);
			orderFlg = retFlgResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//----- ADD　ADD 譚洪  2020/02/24 PMKOBETSU-2912の対応-------<<<<<
//----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応------->>>>>
// 電帳DXの押下処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_StartEBooks(
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->StartEBooks();
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//電子帳簿連携オプション判定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OptPermitForEBooks(
    bool &optPermitForEBooks
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();
        try{
            //構造体→.NETクラスへ変換
            bool paraOptPermitForEBooksFlagResult;
            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->OptPermitForEBooks(paraOptPermitForEBooksFlagResult);
			//.NETクラス→構造体変換
			optPermitForEBooks = paraOptPermitForEBooksFlagResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応-------<<<<<
// 起動パラメータ設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SettingParameter(
    BSTR param1,
    // 2011/01/31 >>>
	//BSTR param2
	BSTR param2,
	BSTR param3
	// 2011/01/31 <<<
	){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(IsDataChanged, paraIsDataChanged);
            //SalesSlip^ paraSalesSlip;

            String^ param1str = gcnew String(param1);
			String^ param2str = gcnew String(param2);
		    // 2011/01/31 >>>
			String^ param3str = gcnew String(param3);
	        // 2011/01/31 <<<


			//アクセスクラスメソッド呼出し
		    // 2011/01/31 >>>
            //delphiSalesSlipInputAcs->SettingParameter(param1str, param2str);
			delphiSalesSlipInputAcs->SettingParameter(param1str, param2str, param3str);
	        // 2011/01/31 <<<

            //.NETクラス→構造体変換
            //if(paraSalesSlip != nullptr){
            //    CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// SCM情報読込タイマー起動イベント処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_TimerSCMReadTick(bool &ret, int &customerCode)
	{
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            //bool^ paraIsDataChanged = gcnew bool();

            //CopyStructToClass_bool(IsDataChanged, paraIsDataChanged);
            //SalesSlip^ paraSalesSlip;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->TimerSCMReadTick(ret, customerCode);

            //.NETクラス→構造体変換
            //if(paraSalesSlip != nullptr){
            //    CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            //}
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// 相場種別情報処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_GetSobaInfo()
	{
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //アクセスクラスメソッド呼出し
			delphiSalesSlipInputAcs->GetSobaInfo();
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//<<<2010/05/30

//>>>2010/08/30
// 起動パラメータ設定処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ExistTaxRateRangeMethod(int salesdate){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
			//アクセスクラスメソッド呼出し
			status = delphiSalesSlipInputAcs->ExistTaxRateRangeMethod(salesdate);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//<<<2010/08/30

//>>>2011/02/01
// SCM情報存在チェック
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ExistSCMInfo(bool &ret, BSTR salesSlipNum, int salesRowNo)
	{
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
			String^ num = gcnew String(salesSlipNum);

            //アクセスクラスメソッド呼出し
			delphiSalesSlipInputAcs->ExistSCMInfo(ret, num, salesRowNo);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//<<<2011/02/01

//>>>2011/03/04
// SCM情報存在チェック
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_SettingEmpInfo()
	{
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //アクセスクラスメソッド呼出し
			delphiSalesSlipInputAcs->SettingEmpInfo();
        }
        catch(Exception ^ex){
        }
    }
//<<<2011/03/04

// --- ADD K2015/04/01 高騁 森川部品個別依頼---------->>>>>
//全拠点在庫情報一覧
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_ReadAllSecStockInfo(
    int makerCd, 
    BSTR goodsNo, 
    BSTR goodsName, 
	bool isButtonPressed,
	bool isClose,
    BSTR &message
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        message = NULL;
		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            int makerCdResult = makerCd;
            String^ goodsNoResult = gcnew String(goodsNo);
            String^ goodsNameResult = gcnew String(goodsName);
            String^ messageResult;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->ReadAllSecStockInfo(makerCdResult, goodsNoResult, goodsNameResult, isButtonPressed, isClose, messageResult);

            //.NETクラス→構造体変換
            makerCd = makerCdResult;
            goodsNo = static_cast<BSTR>(Marshal::StringToBSTR(goodsNoResult).ToPointer());
            goodsName = static_cast<BSTR>(Marshal::StringToBSTR(goodsNameResult).ToPointer());
            message = static_cast<BSTR>(Marshal::StringToBSTR(messageResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
            message = static_cast<BSTR>(Marshal::StringToBSTR(ex->Message).ToPointer());
        }

        return status;
    }

//森川個別オプション判定
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_OptPermitForMoriKawa(
    bool &optPermitForMoriKawa
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
           
			bool paraOptPermitForMoriKawaFlagResult;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->OptPermitForMoriKawa(paraOptPermitForMoriKawaFlagResult);
			
			optPermitForMoriKawa = paraOptPermitForMoriKawaFlagResult;

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD K2015/04/01 高騁 森川部品個別依頼----------<<<<<


//メモリ解放
// add by yangmj
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeSalesSlip(StructSalesSlip *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeSalesSlip(deleteStructList, deleteStructListCount);
}
// end add by yangmj

// add by gaofeng start
//文字列解放
__declspec(dllexport) void __stdcall DelphiGetSalesSlipInputInitDataAcs_FreeMessage(BSTR message){
	//文字列解放メソッド呼び出し
	FreeMessage(message);
}

//メモリ解放
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeUserGdHd(StructUserGdHd *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeUserGdHd(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeUserGdBd(StructUserGdBd *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeUserGdBd(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeCustomArrayA2(StructCustomArrayA2 *deleteStructList, int deleteStructListCount){
    //解放メャbド呼び出し
    FreeCustomArrayA2(deleteStructList, deleteStructListCount);
}

__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeSalesSlipSearchResult(StructSalesSlipSearchResult *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeSalesSlipSearchResult(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeCustomerSearchRet(StructCustomerSearchRet *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeCustomerSearchRet(deleteStructList, deleteStructListCount);
}

//メモリ解放
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeSalesSlipHeaderCopyData(StructSalesSlipHeaderCopyData *deleteStructList, int deleteStructListCount){
    //解放メソッド呼び出し
    FreeSalesSlipHeaderCopyData(deleteStructList, deleteStructListCount);
}
// add by gaofeng end

//文字列解放
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_FreeMessage(BSTR message){
	//文字列解放メソッド呼び出し
	FreeMessage(message);
}
// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//************************************************************
// ＱＲコード作成処理
//************************************************************
__declspec(dllexport) void __stdcall DelphiSalesSlipInputAcs_MakeQR(BSTR parameter)
{
    DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

	try{
		//構造体→.NETクラスへ変換
		String^ parameterResult = gcnew String(parameter);

        //アクセスクラスメソッド呼出し
        delphiSalesSlipInputAcs->MakeQR(parameterResult);

        //.NETクラス→構造体変換
		parameter = static_cast<BSTR>(Marshal::StringToBSTR(parameterResult).ToPointer());
	}
    catch(Exception ^ex){
	}
}
// --- ADD m.suzuki 2010/06/12 ----------<<<<<
// --- ADD m.suzuki 2010/06/16 ---------->>>>>
//************************************************************
// オンラインフラグ取得処理
//************************************************************
__declspec(dllexport) bool __stdcall DelphiSalesSlipInputAcs_GetOnlineFlag()
{
	DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

	try{
		//アクセスクラスメソッド呼出し
		return delphiSalesSlipInputAcs->GetOnlineFlag();
	}
	catch(Exception ^ex){
	}
}
// --- ADD m.suzuki 2010/06/16 ----------<<<<<
// --- ADD 2011/11/22 ---- >>>>>
//連携判断処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_CooprtKindDiv(
    bool &cooprtFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            bool CooprtFlagResult;

            //アクセスクラスメソッド呼出し
            delphiSalesSlipInputAcs->CooprtKindDiv(CooprtFlagResult);

			cooprtFlag = CooprtFlagResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2011/11/22 ---- <<<<<

// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
//売価算出処理
__declspec(dllexport) int __stdcall DelphiSalesSlipInputAcs_SalesUnPrcCalc(
	int salesRowNo,
    BSTR &salesUnPrice
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        salesUnPrice = NULL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //構造体→.NETクラスへ変換
            String^ salesUnPriceResult;

            //アクセスクラスメソッド呼出し
            status = delphiSalesSlipInputAcs->SalesUnPrcCalc(salesRowNo, salesUnPriceResult);

            //.NETクラス→構造体変換
            salesUnPrice = static_cast<BSTR>(Marshal::StringToBSTR(salesUnPriceResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

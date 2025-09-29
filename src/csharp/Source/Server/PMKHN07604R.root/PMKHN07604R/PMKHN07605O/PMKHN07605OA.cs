//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（インポート）
// プログラム概要   : 在庫マスタ（インポート）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangy3
// 作 成 日  2012/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10801804-00  作成担当 : zhangy3 
// 修 正 日 2012/07/03   修正内容 : Redmine#30387 商品マスタインボートチェックの追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタ（インポート）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ（インポート）DBインターフェースです。</br>
    /// <br>Programmer : zhangy3</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/03 zhangy3 </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
    /// <br>Update Note: 2012/07/20 zhangy3 </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockImportDB
    {
        /// <summary>
        /// 在庫マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="importStockWorkList">在庫マスタリスト</param>
        /// <param name="importStockWorkCheckList">在庫マスタチェックリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="loginSectionCode">ログイン拠点コード</param>
        /// <param name="loginSectionGuideNm">ログイン拠点名称</param>
        /// <param name="employeeCode">ログイン従業員コード</param>
        /// <param name="employeeName">ログイン従業員名称</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errStockCheckWorks">エラー在庫マスタチェックリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            int dataCheckKbn,//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            ref object importStockWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN07606D", "Broadleaf.Application.Remoting.ParamData.StockCheckWork")]
            ref object importStockWorkCheckList,
            string enterpriseCode,
            string loginSectionCode,
            string loginSectionGuideNm,
            string employeeCode,
            string employeeName,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt, 
            out int errCnt, 
            //out DataTable errTable,
           [CustomSerializationMethodParameterAttribute("PMKHN07606D", "Broadleaf.Application.Remoting.ParamData.StockCheckWork")]
            out object errStockCheckWorks,
            out string errMsg);
    }
}

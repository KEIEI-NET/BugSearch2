//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/03/31  修正内容 : Mantis.15256 商品マスタインポートの対象項目設定対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/12  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/03  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品マスタ（インポート）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（インポート）DBインターフェースです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsUImportDB
    {
        /// <summary>
        /// 商品マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="importGoodsWorkList">商品マスタインポートデータリスト</param>
        /// <param name="importGoodsPriceWorkList">価格マスタインポートデータリスト</param>
        /// <param name="importGoodsUGoodsPriceUWorkList">商品・価格インポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="importSetUpInfoList">インポート対象設定リスト</param>
        /// <param name="paraPriceStartDate">価格開始年月日</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（インポート）のインポート処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/03 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        [MustCustomSerialization]
        // 2010/03/31 >>>
        //int Import(
        //    Int32 processKbn,
        //    [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
        //    ref object importGoodsWorkList,
        //    [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
        //    ref object importGoodsPriceWorkList,
        //    out Int32 readCnt,
        //    out Int32 addCnt,
        //    out Int32 updCnt,
        //    out string errMsg);
        int Import(
            Int32 processKbn,
            Int32 dataCheckKbn, // ADD wangf 2012/07/20 FOR Redmine#30387
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
            ref object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object importGoodsPriceWorkList,
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            [CustomSerializationMethodParameterAttribute("PMKHN07636D", "Broadleaf.Application.Remoting.ParamData.GoodsUGoodsPriceUWork")]
            ref object importGoodsUGoodsPriceUWorkList,
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<<
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            out string errMsg,
            //object importSetUpInfoList); // DEL wangf 2012/06/12 FOR Redmine#30387
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            object importSetUpInfoList,
            //ref DataTable table, // DEL wangf 2012/07/03 FOR Redmine#30387
            DateTime paraPriceStartDate);
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<<
        // 2010/03/31 <<<

    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 田建委
// 修 正 日  2012/12/13  修正内容 : 2013/03/13配信分  Redmine#33835
//                                  出荷回数を追加する対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタ処理用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ処理用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2012/12/13 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33835 出荷回数を追加する対応</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMstDB
    {
        /// <summary>
        /// 在庫マスタ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">ﾒｰｶｰ</param>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <br>Note       : 在庫マスタ検索処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchStockInfo(string enterpriseCode, string goodsNo, Int32 goodsMakerCd,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList stockList, out string retMessage);

        /// <summary>
        /// 出荷回数を戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWork">検索結果</param>
        /// <param name="stockHistoryDspSearchParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 出荷回数検索処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockHisDsp(
            [CustomSerializationMethodParameterAttribute("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork")]
            out object stockHistoryDspSearchResultWork,
            object stockHistoryDspSearchParamWork);

        /// <summary>
        /// 在庫マスタ情報を登録、更新します
        /// </summary>
        /// <param name="StockWork">在庫リスト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を登録、更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int Write(
			ArrayList StockWork,
            out string retMessage);

        /// <summary>
        /// 在庫マスタ情報を論理削除します
        /// </summary>
        /// <param name="StockWork">在庫リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を論理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int LogicalDelete(ref ArrayList StockWork);

        /// <summary>
        /// 論理削除在庫マスタ情報を復活します
        /// </summary>
        /// <param name="StockWork">在庫リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫マスタ情報を復活します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(ref ArrayList StockWork);

        /// <summary>
        /// 在庫マスタ情報を物理削除します
        /// </summary>
        /// <param name="StockWork">在庫マスタ情報オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を物理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        [MustCustomSerialization]
        int Delete(ArrayList StockWork);
    }
}

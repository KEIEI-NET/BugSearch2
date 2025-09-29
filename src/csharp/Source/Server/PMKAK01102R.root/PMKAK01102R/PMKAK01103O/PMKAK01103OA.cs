//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品計上更新部品
// プログラム概要   : 仕入返品計上更新部品 RemoteObject Interface 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI斎藤 和宏
// 作 成 日  2013/01/22  修正内容 : 仕入返品予定機能追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入返品計上更新部品リモートオブジェクトDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品計上更新部品リモートオブジェクトDBインターフェースです。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/01/22</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockSlipRetPlnDB
    {
        /// <summary>
        /// エントリ更新
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// 売上明細情報読込
        /// </summary>
        /// <param name="salesDetailWork">売上明細データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNumList">売上伝票番号リスト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票番号から売上明細情報を取得します</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/24</br>
        [MustCustomSerialization]
        int SearchSalesDetail(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object salesDetailWork,
            string enterpriseCode,
            object salesSlipNumList,
            string sectionCode
            );

        /// <summary>
        /// 論理削除します
        /// </summary>
        /// <param name="stockSlipWork">オブジェクト</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 情報を論理削除します</br>
        /// <br>Programmer : FSI福原 一樹</br>
        /// <br>Date       : 2013/01/23</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockSlipWork")]
            ref object stockSlipWork
          , out string retMsg
            );

        /// <summary>
        /// エントリ更新
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int AddUp([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);
    }
}

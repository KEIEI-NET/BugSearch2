using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入データDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入データDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IStockSlipDB
    {
        /// <summary>
        /// 明細情報読込
        /// </summary>
        /// <param name="paraList">仕入明細抽出条件リスト</param>
        /// <param name="retList">仕入明細データリスト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int ReadStockDetailWork(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retList);

        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="retStockSlipList">検索結果を格納する CustomSerializeArrayList を指定します。</param>
        /// <param name="paraStockSlip">検索条件を格納した StockSlip を指定します。</param>
        /// <param name="mode">0:完全一致 1:前方一致 2:完全一致＋仕入明細取得</param>
        /// <returns>STATUS</returns>
        int SearchPartySaleSlipNum(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retStockSlipList,
            object paraStockSlip,
            int mode);

        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="paraAryobj">検索条件を格納した StockSlipWorkのリストを指定します。</param>
        /// <param name="stockSlipAryObj">仕入データ検索結果(ArrayList)</param>
        /// <param name="stockDetailAryObj">仕入明細データ検索結果(ArrayList)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int StockSlipPartySaleSlipNumReadAll(object paraAryobj,
          [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockSlipWork")]
            out object stockSlipAryObj,
          [CustomSerializationMethodParameterAttribute("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockDetailWork")]
            out object stockDetailAryObj);

    }
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 提供マージ対象検索DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供マージ対象検索RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br>Update Note: 11370006-00 ハンディターミナル対応</br>
    /// <br>             バーコードマスタ更新追加対応</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2017/08/01</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IMergeDataGet
    {
        /// <summary>
        /// 提供のマージデータ取得
        /// </summary>
        /// <param name="offerDate">取得する提供データの提供日付</param>
        /// <param name="cond">取得条件</param>
        /// <param name="retList">取得結果のリスト（CustomSerializeArrayList）</param>
        /// <param name="bigCarOfferDiv">大型区分</param>
        /// <param name="searchPartsType">検索タイプ</param>
        /// <returns>処理結果</returns>
        [MustCustomSerialization]
        int GetMergeData(int offerDate,
            MergeInfoGetCond cond,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList,
            int searchPartsType,
            int bigCarOfferDiv
            );

        /// <summary>
        /// 提供の部品情報取得
        /// </summary>
        /// <param name="offerDate">取得する提供データの提供日付</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">(純正部品,優良部品用)品番</param>
        /// <param name="goodsPriceNo">(優良価格用)品番</param>
        /// <param name="retList">取得結果のリスト（CustomSerializeArrayList）</param>
        /// <returns>処理結果</returns>
        [MustCustomSerialization]
        int GetGoodsInfo(int offerDate,
            int makerCode,
            string goodsNo,
            string goodsPriceNo,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);

        /// <summary>
        /// 価格改正の最新提供日付取得
        /// </summary>
        /// <param name="blDate">BLコード</param>
        /// <param name="goodsMDate">中分類</param>
        /// <param name="groupDate">BLグループ</param>
        /// <param name="makerDate">部品メーカー</param>
        /// <param name="modelNmDate">車種</param>
        /// <param name="partsPosDate">部位</param>
        /// <param name="ptmkpriceDate">部品価格</param>
        /// <param name="primPartsDate">優良価格</param>
        /// <param name="prmSetChgDate">優良設定変更</param>
        /// <param name="prmSetDate">優良</param>
        /// <param name="offerDateList">提供日付リスト</param>
        /// <param name="bigCarOfferDiv">大型区分</param>
        /// <param name="searchPartsType">検索タイプ</param>
        /// <returns></returns>
        //[MustCustomSerialization]
        int GetOfferDate(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int ptmkpriceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int searchPartsType, int bigCarOfferDiv,
            //[CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object offerDateList);


        /// <summary>
        /// 価格改正用更新メーカー取得
        /// </summary>
        /// <param name="offerDate">提供日付</param>
        /// <param name="makerObj">メーカーリスト</param>
        /// <returns></returns>
        int GetMakerInfo(int offerDate,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object makerObj);

        // -- DEL 2010/06/14 ---------------------------->>>
        ///// <summary>
        ///// 価格改正用更新メーカー取得
        ///// </summary>
        ///// <param name="instalOfferDate">インストール日付取得</param>
        ///// <returns></returns>
        //int GetInstalDate(ref DateTime instalOfferDate);
        // -- DEL 2010/06/14 ----------------------------<<<


        // --- ADD 2017/08/01 Y.Wakita ---------->>>>>
        /// <summary>
        /// 価格改正の最新提供日付取得
        /// </summary>
        /// <param name="blDate">BLコード</param>
        /// <param name="goodsMDate">中分類</param>
        /// <param name="groupDate">BLグループ</param>
        /// <param name="makerDate">部品メーカー</param>
        /// <param name="modelNmDate">車種</param>
        /// <param name="partsPosDate">部位</param>
        /// <param name="ptmkpriceDate">部品価格</param>
        /// <param name="primPartsDate">優良価格</param>
        /// <param name="prmSetChgDate">優良設定変更</param>
        /// <param name="prmSetDate">優良</param>
        /// <param name="goodsBarcodeRevnDate">優良部品バーコード</param>
        /// <param name="offerDateList">提供日付リスト</param>
        /// <param name="bigCarOfferDiv">大型区分</param>
        /// <param name="searchPartsType">検索タイプ</param>
        /// <returns></returns>
        //[MustCustomSerialization]
        int GetOfferDate(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int ptmkpriceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int goodsBarcodeRevnDate, int searchPartsType, int bigCarOfferDiv,
            out object offerDateList);

        /// <summary>
        /// バーコード改正用更新メーカー取得
        /// </summary>
        /// <param name="offerDate">提供日付</param>
        /// <param name="partsMakerObj">部品メーカーリスト</param>
        /// <returns></returns>
        int GetPartsMakerInfo(int offerDate,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object partsMakerObj);

        /// <summary>
        /// 提供の部品情報取得
        /// </summary>
        /// <param name="offerDate">取得する提供データの提供日付</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="retList">取得結果のリスト（CustomSerializeArrayList）</param>
        /// <returns>処理結果</returns>
        [MustCustomSerialization]
        int GetPrmPrtBrcdInfo(int offerDate,
            int makerCode,
            string goodsNo,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);
        // --- ADD 2017/08/01 Y.Wakita ----------<<<<<


    }
}

using System;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良部品情報取得 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良部品情報検索 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/09　吉岡</br>
    /// <br>           : 速度改善フェーズ２№11,№12 絞込タイミング変更</br>
    /// <br></br>
    /// <br>Update Note: 2014/06/12　30744 湯上 千加子</br>
    /// <br>           : 速度改善フェーズ２障害対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IPrimePartsInfo
    {
        /// <summary>
        /// 優良品番検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="inRetInf"></param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPartsInf(
            GetPrimePartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
            out ArrayList inRetInf,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList inPrimePrice,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
            out ArrayList inRetSetParts,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList SetPrice);

        /// <summary>
        /// 純正品番→結合検索[BL検索]
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg">代替フラグ[true:する/false:しない]</param>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="inPara">検索パラメータ</param>		
        /// <param name="inRetInf">部品情報</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPartsInfByCtlgPtNo(
            bool substFlg,
            int carMakerCd,
            ArrayList inPara,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
            out ArrayList inRetInf,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList inPrimePrice,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork")]
            out ArrayList inRetSetParts,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList SetPrice);

        // DEL 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //// // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 自動回答専用 各種プロパティ キャッシュ処理
        ///// </summary>
        ///// <param name="obAutoAnsItemStList">自動回答品目設定マスタリスト</param>
        ///// <param name="obPrmSettingList">優先設定マスタリスト</param>
        ///// <param name="sectionCodeWk">拠点コード</param>
        ///// <param name="customerCodeWk">得意先コード</param>
        ///// <returns></returns>
        //void CacheAutoAnswer(
        //    string sectionCodeWk,
        //    int customerCodeWk,
        //    System.Collections.Generic.List<object> obAutoAnsItemStList,
        //    System.Collections.Generic.List<object> obPrmSettingList
        //    );
        //
        ///// <summary>
        ///// 自動回答専用 各種プロパティ キャッシュクリア
        ///// </summary>
        ///// <returns></returns>
        //void CacheClearAutoAnswer();
        //// // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // DEL 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応 ---------------------------------->>>>>
        /// <summary>
        /// 自動回答専用 純正品番→結合検索[BL検索]
        /// </summary>
        /// <param name="substFlg">代替フラグ[true:する/false:しない]</param>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="inPara">検索パラメータ</param>		
        /// <param name="inRetInf">部品情報</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPartsInfByCtlgPtNoAutoAnswer(
            // DEL 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
            string sectionCodeWk, 
            int customerCodeWk,
            System.Collections.Generic.List<object> obAutoAnsItemStList,
            System.Collections.Generic.List<object> obPrmSettingList,
            // DEL 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
            bool substFlg,
            int carMakerCd,
            ArrayList inPara,
            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ---------------------------->>>>>
            //out ArrayList inRetInf,
            //out ArrayList inPrimePrice,
            //out ArrayList inRetSetParts,
            //out ArrayList SetPrice);
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object inRetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object inPrimePrice,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object inRetSetParts,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object SetPrice);
        // UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ----------------------------<<<<<
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応 ----------------------------------<<<<<

        /// <summary>
        /// 品名取得(全角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        int GetPartsName(int makerCd, string partsNo, out string name);

        /// <summary>
        /// 品名取得(半角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        int GetPartsNameKana(int makerCd, string partsNo, out string name);

#if Kill0618
        /// <summary>
        /// 優良・セット代替検索
        /// </summary>
        /// <param name="inPara">検索条件リスト</param>
        /// <param name="retSubstParts">代替部品リスト</param>
        /// <param name="retSubstPrice">代替部品価格リスト</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetJoinSubst(
            ArrayList inPara,
            [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsSubstWork")]
            out ArrayList retSubstParts,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList retSubstPrice
            );
#endif
    }
}

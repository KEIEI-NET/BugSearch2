using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 部品取得DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品取得 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 99033　岩本　勇</br>
    /// <br>Date       : 2005.05.19</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/28  22018 鈴木 正臣</br>
    /// <br>           : 自由検索オプション対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/04  22018 鈴木 正臣</br>
    /// <br>           : 成果物統合</br>
    /// <br>           : 　自由検索 2010/04/28 の組込</br>
    /// <br></br>
    /// <br>Update Note: 商品マスタ更新処理でセレクトコードを無視して更新される不具合の対応</br>
    /// <br>             商品マスタ更新処理以外のPGでも問題が発生しているが、取り急ぎ、商品マスタ更新処理のみから</br>
    /// <br>             呼ばれるメソッドを新規作成して対応。別途恒久対応を行う</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2015/04/08</br>
    /// <br></br>
    /// <br>Update Note: 2015/04/08の暫定対応版のメソッドを削除し、既存メソッド（GetPrimePartsInfProc）に対して、</br>
    /// <br>             正式対応を行う。</br>
    /// <br>             商品マスタ更新処理でセレクトコードを無視して更新される不具合対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2015/04/10</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IOfferPartsInfo
    {

        /// <summary>
        /// 純正部品取得メソッド
        /// </summary>
        /// <param name="InPara">パラメータ</param>
        /// <param name="RetInf">部品情報戻り</param>
        /// <param name="ColorWork">カラー情報戻り</param>
        /// <param name="TrimWork">トリム情報戻り</param>
        /// <param name="EquipWork">装備情報戻り</param>
        /// <param name="prtSubstWork">部品代替情報戻り</param>
        /// <param name="partsModelLnkWork">部品ー型式リンク情報戻り</param>
        /// <param name="RetCnt">RetInfの個数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 99033　岩本　勇</br>
        /// <br>Date       : 2005.04.14</br>
        /// <br>Date       : 2007.03.27 iwa partsModelLnkWork追加</br>
        [MustCustomSerialization]
        int GetPartsInf(GetPartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork, out long RetCnt);

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// 純正部品取得メソッド
        /// </summary>
        /// <param name="InPara">パラメータ</param>
        /// <param name="RetInf">部品情報戻り</param>
        /// <param name="ColorWork">カラー情報戻り</param>
        /// <param name="TrimWork">トリム情報戻り</param>
        /// <param name="EquipWork">装備情報戻り</param>
        /// <param name="prtSubstWork">部品代替情報戻り</param>
        /// <param name="partsModelLnkWork">部品ー型式リンク情報戻り</param>
        /// <param name="RetInfFreeSearch">部品情報戻り（自由検索用）</param>
        /// <param name="prtSubstWorkFreeSearch">部品代替情報戻り（自由検索用）</param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt">RetInfの個数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2010/04/27</br>
        [MustCustomSerialization]
        int GetPartsInf( GetPartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object RetInfFreeSearch,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object prtSubstWorkFreeSearch,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimParts,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimPrice,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimSet,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                ref object retPrimSetPrice,
            out long RetCnt );

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ---------------------------------->>>>>
        /// <summary>
        /// 純正部品取得メソッド
        /// </summary>
        /// <param name="InParaList">パラメータ</param>
        /// <param name="RetInf">部品情報戻り</param>
        /// <param name="ColorWork">カラー情報戻り</param>
        /// <param name="TrimWork">トリム情報戻り</param>
        /// <param name="EquipWork">装備情報戻り</param>
        /// <param name="prtSubstWork">部品代替情報戻り</param>
        /// <param name="partsModelLnkWork">部品ー型式リンク情報戻り</param>
        /// <param name="RetInfFreeSearch">部品情報戻り（自由検索用）</param>
        /// <param name="prtSubstWorkFreeSearch">部品代替情報戻り（自由検索用）</param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt">RetInfの個数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        [MustCustomSerialization]
        int GetPartsInf(ArrayList InParaList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInfFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWorkFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimParts,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimPrice,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSet,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSetPrice,
            out long RetCnt);
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ----------------------------------<<<<<

        // 速度改善テスト -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 純正部品取得メソッド
        /// </summary>
        /// <param name="InPara">パラメータ</param>
        /// <param name="RetInf">部品情報戻り</param>
        /// <param name="ColorWork">カラー情報戻り</param>
        /// <param name="TrimWork">トリム情報戻り</param>
        /// <param name="EquipWork">装備情報戻り</param>
        /// <param name="prtSubstWork">部品代替情報戻り</param>
        /// <param name="partsModelLnkWork">部品ー型式リンク情報戻り</param>
        /// <param name="RetInfFreeSearch">部品情報戻り（自由検索用）</param>
        /// <param name="prtSubstWorkFreeSearch">部品代替情報戻り（自由検索用）</param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt">RetInfの個数</param>
        /// <param name="obFoundAutoAnsItemStList"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int GetPartsInfYYYY(GetPartsInfPara InPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object ColorWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object TrimWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object EquipWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWork,
            out List<PartsModelLnkWork> partsModelLnkWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInfFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object prtSubstWorkFreeSearch,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimParts,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimPrice,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSet,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object retPrimSetPrice,
            out long RetCnt,
            List<object> obFoundAutoAnsItemStList
            );
        // 速度改善テスト --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchTbsCodeInfo(
            int[] FullModelFixedNos,
            int blCode,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            ref object PartsNameWorks );
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ---------------------------------->>>>>
        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="paraList"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchTbsCodeInfo(
            int[] FullModelFixedNos,
            ArrayList paraList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object PartsNameWorks);
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ----------------------------------<<<<<

        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchTbsCodeInfo(int[] FullModelFixedNos,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object PartsNameWorks);

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

        /// <summary>
        /// 優良から純正検索
        /// </summary>
        /// <param name="makerCd">優良メーカコード</param>
        /// <param name="partsNo">優良品番(ハイフン付)</param>
        /// <param name="RetInf">純正部品リスト</param>
        /// <returns></returns>
        int GetGenuineParts(int makerCd, string partsNo,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                out object RetInf);

        /// <summary>
        /// 品番複数検索処理
        /// </summary>
        /// <param name="lstSrchCond">条件リスト</param>
        /// <param name="lstRst">純正部品情報リスト</param>
        /// <param name="lstRstPrm">優良部品情報リスト</param>
        /// <param name="lstPrmPrice">優良価格リスト</param>
        /// <returns></returns>
        int GetOfrPartsInf(ArrayList lstSrchCond,
            [CustomSerializationMethodParameterAttribute("PMTKD06163D", "Broadleaf.Application.Remoting.ParamData.RetPartsInf")]
            out ArrayList lstRst,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
            out ArrayList lstRstPrm,
            [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
            out ArrayList lstPrmPrice);

        // DEL osanai 2015/04/10------------------------------------>>>>>
        #region [2015/04/10 暫定対応版メソッド削除]
        //// -- ADD osanai 2015/04/08 ------------------------------------------->>>
        ////下記メソッドは、商品マスタ更新処理用の暫定メソッドのため、恒久対応時に削除する。

        ///// <summary>
        ///// 品番複数検索処理
        ///// </summary>
        ///// <param name="lstSrchCond">条件リスト</param>
        ///// <param name="lstRst">純正部品情報リスト</param>
        ///// <param name="lstRstPrm">優良部品情報リスト</param>
        ///// <param name="lstPrmPrice">優良価格リスト</param>
        ///// <returns></returns>
        //int GetOfrPartsInfGoodsUpdateOnly(ArrayList lstSrchCond,
        //    [CustomSerializationMethodParameterAttribute("PMTKD06163D", "Broadleaf.Application.Remoting.ParamData.RetPartsInf")]
        //    out ArrayList lstRst,
        //    [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork")]
        //    out ArrayList lstRstPrm,
        //    [CustomSerializationMethodParameterAttribute("PMTKD09063D", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork")]
        //    out ArrayList lstPrmPrice);
        //// -- ADD osanai 2015/04/08 -------------------------------------------<<<
        #endregion
        // DEL osanai 2015/04/10------------------------------------<<<<<

        /// <summary>
        /// 商品一括登録用メソッド
        /// </summary>
        /// <param name="InPara">パラメータ</param>
        /// <param name="RetInf">部品情報戻り</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2009.01.16</br>
        [MustCustomSerialization]
        int SearchParts(PrtsSrchCndWork InPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                ref object RetInf);

#if NoUse
		/// <summary>
		/// 指定された部品コードに対して部品情報を取得します。
		/// </summary>
		/// <param name="InPara">部品取得パラメータ</param>
		/// <param name="RetCnt">取得件数</param>		
		/// <param name="RetInf">部品検索結果</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 99033　岩本　勇</br>
		/// <br>Date       : 2005.04.14</br>
		[MustCustomSerialization]
		int GetPartsInf(GetPartsInfPara InPara  , ref object RetInf ,ref object EquipWork ,out long RetCnt);
		
		/// <summary>
		/// 指定されたパラメータで部品情報一括取得します
		/// </summary>
		/// <param name="InPara">検索パラメータ</param>
		/// <param name="RetInf">取得した作業情報</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 99033　岩本　勇</br>
		/// <br>Date       : 2005.04.14</br>
		[MustCustomSerialization]
        int SeachPartsInf(SerchPartsInfPara InPara, [CustomSerializationMethodParameterAttribute("PMTKD06163D", "Broadleaf.Application.Remoting.ParamData.RetPartsInf")]ref object RetInf, [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsColorWork")]ref object ColorWork, [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsTrimWork")]ref object TrimWork, [CustomSerializationMethodParameterAttribute("SFTKD00434D", "Broadleaf.Application.Remoting.ParamData.PartsEquipWork")]ref object EquipWork, out long RetCnt);		

		/// <summary>
		/// 車検証型式をリードします。
		/// </summary>
		/// <param name="InPara">パラメータ</param>
		/// <param name="CarInspectCertModel">車検証型式</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 99033　岩本　勇</br>
		/// <br>Date       : 2005.04.14</br>
		int GetCarInspectCertModel(GetCarInspectCertModelPara InPara ,ref string CarInspectCertModel );
#endif

    }
}

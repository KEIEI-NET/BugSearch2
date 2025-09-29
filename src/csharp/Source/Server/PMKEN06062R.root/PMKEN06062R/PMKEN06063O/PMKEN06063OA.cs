using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ユーザー部品検索 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザー部品検索 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.19 20056 對馬 大輔 MAX件数指定可能Searchメソッド追加</br>
    /// <br>Update Note: 2009.02.19 20056 對馬 大輔 MANTIS[0012224] LogicalMode指定のSearchメソッド追加</br>
    /// <br>Update Note: 2013/02/08 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
    /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// <br>Update Note: K2013/03/18 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
    /// <br>           : Redmine#35071 商品在庫マスタ・山形部品様個別組み込み（#34640残留）</br>
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#34962 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2014/02/06 湯上 千加子</br>
    /// <br>管理番号   : </br>
    /// <br>           : SCM仕掛一覧№10632対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUsrJoinPartsSearchDB
    {
#if SpecChange
        /// <summary>
        /// ユーザー部品検索[代替・結合・セット]
        /// </summary>
        /// <param name="searchFlg">検索フラグ</param>
        /// <param name="searchCond">検索条件</param>
        /// <param name="usrPartsSubstRetWork">代替検索結果</param>	
        /// <param name="usrJoinPartsRetWork">結合検索結果</param>
        /// <param name="usrGoodsRetWork">部品検索結果</param>
        /// <param name="usrSetPartsRetWork">セット検索結果</param>
        /// <param name="usrGoodsPrice">部品価格情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            UsrSearchFlg searchFlg,
            object searchCond,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrPartsSubstRetWork")]
			out ArrayList usrPartsSubstRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrJoinPartsRetWork")]
			out ArrayList usrJoinPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrSetPartsRetWork")]
			out ArrayList usrSetPartsRetWork,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsPriceWork")]
            out ArrayList usrGoodsPrice);
#endif
        /// <summary>
        /// ユーザー部品検索[代替・結合・セット]
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg">検索フラグ</param>
        /// <param name="searchType"></param>
        /// <param name="searchCond">検索条件</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            UsrSearchFlg searchFlg,
            int searchType, 
            object searchCond);

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ユーザー部品検索[代替・結合・セット]
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="searchCond"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            UsrSearchFlg searchFlg,
            int searchType,
            ConstantManagement.LogicalMode logicalMode,
            object searchCond);
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー部品検索[代替・結合・セット]
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="listSearchFlg"></param>
        /// <param name="listSearchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="listSearchCond"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsJoinSearch(
            out ArrayList retObj,
            ArrayList listSearchFlg,
            ArrayList listSearchType,
            ConstantManagement.LogicalMode logicalMode,
            ArrayList listSearchCond
            );
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// ユーザー商品検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork">検索条件[1件：曖昧検索　ArrayList：検索]</param>
        /// <param name="searchType">0:完全一致/1:前方一致/2:後方一致/3:曖昧/4:ハイフン無し完全一致/5:[特殊]結合元検索</param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsSearch(
            object partsNoSearchCondWork,
            int searchType, 
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out ArrayList usrGoodsPrice,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList usrGoodsStock
            );

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ユーザー商品検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsSearch(
            object partsNoSearchCondWork,
            int searchType,
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out ArrayList usrGoodsPrice,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList usrGoodsStock
            );
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー商品検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int UserGoodsSearch(
            ArrayList partsNoSearchCondWork,
            ArrayList searchType,
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("PMKEN06064D", "Broadleaf.Application.Remoting.ParamData.UsrGoodsRetWork")]
			out ArrayList usrGoodsRetWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out ArrayList usrGoodsPrice,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out ArrayList usrGoodsStock
            );
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

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

        // -- ADD 2011/03/17 ------------------------->>>
        /// <summary>
        /// ユーザー商品マスタと価格マスタのみを取得します。
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int UsrGoodsOnlySearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            int maxCount,
            ConstantManagement.LogicalMode logicalMode);
        // -- ADD 2011/03/17 -------------------------<<<

        //-------- ADD 田建委 2013/02/08 Redmine#34640 ------->>>>>
        /// <summary>
        /// 商品情報によって税率情報LISTを戻ります
        /// </summary>
        /// <param name="work">商品情報</param>
        /// <param name="rateList">戻りリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品情報によって税率情報LISTを戻ります</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        [MustCustomSerialization]
        int GetRateWorkByGood(
            GoodsUnitDataWork work,
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            out ArrayList rateList
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parmWork">検索条件</param>
        /// <param name="readMode">検索モード（０：前頁；１：次頁）</param>
        /// <param name="retObj">検索結果</param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetPrevNextGoods(
            GoodsUnitDataWork parmWork,
            int readMode,
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			out ArrayList retObj
            );
        //-------- ADD 田建委 2013/02/08 Redmine#34640 -------<<<<<
        //-------- ADD 田建委 K2013/03/18 Redmine#35071 ------->>>>>
        /// <summary>
        /// 従業員管理情報を読込します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="unCstChngDiv">原単価修正区分</param>
        /// <param name="stckCntChngDiv">在庫数修正区分</param>
        /// <returns>STATUS</returns>
        int ReadMng(string enterpriseCode, string employeeCode, out int unCstChngDiv, out int stckCntChngDiv);
        //-------- ADD 田建委 K2013/03/18 Redmine#35071 -------<<<<<

        #region [ 商品構成取得DB RemoteObjectインターフェースから統合したメソッド ]
        /// <summary>
        /// 商品構成取得LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 商品構成取得LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            int maxCount,
            ConstantManagement.LogicalMode logicalMode);
        // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        /// <summary>
        /// 商品構成取得LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        [MustCustomSerialization]
        int SearchMultiCondition(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.12</br>
        [MustCustomSerialization]
        int ReadNewWriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        #region 商品系マスタを一括で処理する為のメソッド
        ///// <summary>
        ///// 商品マスタ（ユーザー登録分）LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        ///// </summary>
        ///// <param name="goodsUWork">検索結果</param>
        ///// <param name="paragoodsUWork">検索パラメータ</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2007.01.24</br>
        //[MustCustomSerialization]
        //int SearchRelation(
        //    [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
        //    out object goodsUWork,
        //    object paragoodsUWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品・価格・在庫／代替／結合／セットの登録・更新を行います。
        /// 代替などでは元や先の2商品情報を格納するため
        /// （商品・価格・在庫）情報のみArrayListに設定し、他の情報は直接CustomSerializeArrayListにAddする。
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int WriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
        /// <summary>
        /// 商品・価格・在庫／代替／結合／セットの登録・更新を行います。
        /// 代替などでは元や先の2商品情報を格納するため
        /// （商品・価格・在庫）情報のみArrayListに設定し、他の情報は直接CustomSerializeArrayListにAddする。
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2014/01/15</br>
        [MustCustomSerialization]
        int WriteRelationForShipmentCnt(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<

        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を論理削除します
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int LogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// 論理削除商品マスタ（ユーザー登録分）情報を復活します
        /// </summary>
        /// <param name="goodsUWork">GoodsUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品マスタ（ユーザー登録分）情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// 商品マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">商品マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品マスタ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        int DeleteRelation(object paraobj);
        #endregion
        #endregion

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>
        /// 商品構成取得LISTを全て戻します（論理削除除く）:カスタムシリアライズ(商品在庫一括登録修正用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="targetDiv">対象区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            int maxCount,
            int targetDiv,
            ConstantManagement.LogicalMode logicalMode);
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
    }
}

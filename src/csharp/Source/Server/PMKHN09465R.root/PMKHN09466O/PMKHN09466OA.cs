using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface ISingleGoodsRateDB
    {  
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateWork")]
			ref object SingleGoodsRateWork
            );


        /// <summary>
        /// 掛率設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 掛率設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int SearchRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 掛率設定
        /// </summary>
        /// <param name="delparaObj">削除データリスト</param>
        /// <param name="updparaObj">更新データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        [MustCustomSerialization]
        int Save(object delparaObj, object updparaObj, ref string message);

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int WriteCustomer(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
			ref object SingleGoodsRateWork
            );

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int WriteCustomerGrp(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
			out object retList, 
            ref object SingleGoodsRateWork
            );

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int CustomerAllDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
            ref object SingleGoodsRateWork
            );


    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付け  DB RemoteObjectインターフェース
// プログラム概要   : 商品バーコード関連付けテーブルに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11770181-00 作成担当 : 呉元嘯
// 修 正 日  2021/11/18  修正内容 : PJMIT-1499 OUT OF MEMORY対応(4GB対応) 恒久対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品バーコード関連付けマスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けマスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note: 2021/11/18 呉元嘯</br>
    /// <br>管理番号   : 11770181-00</br>
    /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応) 恒久対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsBarCodeRevnDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 商品バーコード関連付けマスタLISTを全て戻します
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWork">検索結果</param>
        /// <param name="objGoodsBarCodeRevnSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>検索処理結果 0:正常</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
			out object objGoodsBarCodeRevnWork,
           object objGoodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品バーコード関連付情報を取込します
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWorkList">GoodsBarCodeRevnWorkオブジェクトLIST</param>
        /// <returns>取込処理結果 0:正常</returns>
        /// <br>Note       : 商品バーコード関連付情報を登録、更新します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        [MustCustomSerialization]
        int WriteByInput(
            [CustomSerializationMethodParameterAttribute("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
		    ref object objGoodsBarCodeRevnWorkList
            );

        /// <summary>
        /// 商品バーコード関連付を保存します
        /// </summary>
        /// <param name="objSaveWorkList">保存用データList</param>
        /// <param name="objDeleteWorkList">削除用データList</param>
        /// <returns>保存処理結果 0:正常</returns>
        /// <br>Note       : 商品バーコード関連付情報を保存します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        [MustCustomSerialization]
        int WriteBySave(
            [CustomSerializationMethodParameterAttribute("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
			ref object objSaveWorkList, ref object objDeleteWorkList
            );

        // --- ADD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------>>>>>
        /// <summary>
        /// ユーザー在庫商品検索処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="condObj">検索パラメータ</param>
        /// <returns>検索処理結果  0:正常</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ検索処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2021/11/18</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockGoods(out object retObj, object condObj);
        // --- ADD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------<<<<<
        #endregion
    }
}

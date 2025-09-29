using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品セットマスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品セットマスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br>Update Note: 20081 疋田 勇人</br>
    /// <br>           : 2007.09.26 DC.NS用に変更</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsSetDB
    {

        /// <summary>
        /// 指定された商品セットマスタGuidの商品セットマスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された商品セットマスタGuidの商品セットマスタを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 商品セットマスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を物理削除します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 商品セットマスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="goodsSetWork">検索結果</param>
        /// <param name="paragoodsSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            out object goodsSetWork,
            object paragoodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品セットマスタ情報を登録、更新します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を登録、更新します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork
            );

        /// <summary>
        /// <br>商品セットマスタ情報を登録、更新します</br>
        /// <br>同一商品セットコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsNo">親商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を登録、更新します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D", "Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork,
//            string enterpriseCode, string goodsSetCode                           // 2007.09.26 hikita del
            string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo  // 2007.09.26 hikita add
            );

        /// <summary>
        /// 商品セットマスタ情報を論理削除します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を論理削除します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork
            );

        /// <summary>
        /// 論理削除商品セットマスタ情報を復活します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品セットマスタ情報を復活します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork
            );
        #endregion
    }
}

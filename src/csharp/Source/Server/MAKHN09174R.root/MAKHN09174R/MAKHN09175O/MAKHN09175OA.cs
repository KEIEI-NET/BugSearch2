using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品価格マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品価格マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 18322  木村 武正</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS対応</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 22008 長内 PM.NS対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsPriceUDB
    {

        /// <summary>
        /// 指定された商品価格マスタGuidの商品価格マスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsPriceUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された商品価格マスタGuidの商品価格マスタを戻します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 商品価格マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">GoodsPriceUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を物理削除します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 商品価格マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="GoodsPriceUWork">検索結果</param>
        /// <param name="paraGoodsPriceUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026  湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out object GoodsPriceUWork,
            object paraGoodsPriceUWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 商品価格マスタ情報を登録、更新します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <param name="writeError">更新エラー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します</br>
        /// <br>Programmer : 19026  湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object GoodsPriceUWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWriteErrorWork")]
            out object writeError
            );

        /// <summary>
        /// 商品価格マスタ情報を論理削除します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を論理削除します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object GoodsPriceUWork
            );

        /// <summary>
        /// 論理削除商品価格マスタ情報を復活します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品価格マスタ情報を復活します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object GoodsPriceUWork
            );
        #endregion
    }
}

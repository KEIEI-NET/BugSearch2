using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上全体設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上全体設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 980081  山田 明友</br>
    /// <br>Date       : 2007.12.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesTtlStDB
    {
        /// <summary>
        /// 指定された売上全体設定マスタGuidの売上全体設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">SalesTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された売上全体設定マスタGuidの売上全体設定マスタを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 売上全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 売上全体設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="salesTtlStWork">検索結果</param>
        /// <param name="parasalesTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09226D","Broadleaf.Application.Remoting.ParamData.SalesTtlStWork")]
            out object salesTtlStWork,
            object parasalesTtlStWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 売上全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09226D","Broadleaf.Application.Remoting.ParamData.SalesTtlStWork")]
            ref object salesTtlStWork
            );

        /// <summary>
        /// 売上全体設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09226D","Broadleaf.Application.Remoting.ParamData.SalesTtlStWork")]
            ref object salesTtlStWork
            );

        /// <summary>
        /// 論理削除売上全体設定マスタ情報を復活します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除売上全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09226D","Broadleaf.Application.Remoting.ParamData.SalesTtlStWork")]
            ref object salesTtlStWork
            );
        #endregion
    }
}

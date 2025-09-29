using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// CustomerChangeDB リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustomerChangeDB リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface ICustomerChangeDB
    {
        /// <summary>
        /// 指定された得意先(変動情報)マスタの情報を返します。
        /// </summary>
        /// <param name="paraByte">シリアライズされた CustomerChangeWork オブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先(変動情報)マスタの情報を返します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        int Read(ref byte[] paraByte, int readMode);

        /// <summary>
        /// 指定された得意先(変動情報)マスタの情報を物理削除します。
        /// </summary>
        /// <param name="paraByte">シリアライズされた CustomerChangeWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先(変動情報)マスタの情報を物理削除します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        int Delete(byte[] paraByte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 検索パラメータに適合する得意先(変動情報)マスタの全情報を返します。
        /// </summary>
        /// <param name="objCustomerChangeWork">検索結果</param>
        /// <param name="paraCustomerChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
			out object objCustomerChangeWork,
            object paraCustomerChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 得意先(変動情報)マスタに情報を追加又は更新します。
        /// </summary>
        /// <param name="objCustomerChangeWork">RateProtyMngWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタに情報を追加又は更新します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
			ref object objCustomerChangeWork
            );

        /// <summary>
        /// 指定された得意先(変動情報)マスタの情報を論理削除します。
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeMngWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先(変動情報)マスタの情報を論理削除します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
			ref object objCustomerChangeWork
            );

        /// <summary>
        /// 論理削除されている得意先(変動情報)マスタの情報を復活させます。
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除されている得意先(変動情報)マスタの情報を復活させます。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
			ref object objCustomerChangeWork
            );

        // 2008.05.26 add start ----------------------------->>
        /// <summary>
        /// 指定された得意先の現在売掛残高を更新します。
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeWork オブジェクト</param>
        /// <param name="differenceValue">差額(更新額をセット:マイナスの場合はマイナス値でセット)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先の現在売掛残高を更新します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.05.26</br>
        [MustCustomSerialization]
        int PrsntAccRecBalanceUpdate(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
			ref object objCustomerChangeWork,
            Int64 differenceValue
            );
        // 2008.05.26 add end -------------------------------<<
        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先一括修正DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先一括修正DBインターフェースです。</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomerCustomerChangeDB
    {
        /// <summary>
        /// 単一の得意先マスタ情報を取得します。
        /// </summary>
        /// <param name="customerCustomerChangeObj">customerCustomerChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタのキー値が一致する得意先マスタ情報を取得します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.11.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09357D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork")]
            ref object customerCustomerChangeResultObj,
            int readMode);
        /// <summary>
        /// 得意先一括修正情報のリストを取得します。
        /// </summary>
        /// <param name="customerCustomerChangeObjList">検索結果</param>
        /// <param name="customerCustomerChangeObjObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先一括修正のキー値が一致する、全ての得意先一括修正情報を取得します。</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.11.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09357D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork")]
            ref object customerCustomerChangeResultObjList,
            object customerCustomerChangeParamObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // DEL 2009/04/10 >>>
        ///// <summary>
        ///// 得意先一括修正情報を追加・更新します。
        ///// </summary>
        ///// <param name="customerCustomerChangeObjList">追加・更新する得意先一括修正情報を含む CustomSerializeArrayList</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : customerCustomerChangeObjList に格納されている得意先一括修正情報を追加・更新します。</br>
        ///// <br>Programmer : 23012　畠中 啓次朗</br>
        ///// <br>Date       : 2008.11.10</br>
        //[MustCustomSerialization]
        //int Write(
        //    [CustomSerializationMethodParameterAttribute("PMKHN09357D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork")]
        //    ref object customerCustomerChangeResultObjList);
        // DEL 2009/04/10 <<<


    }
}

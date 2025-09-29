using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先別売上目標設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別売上目標設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>             障害改良対応１２月</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustSalesTargetDB
    {
        /// <summary>
        /// 指定された得意先別売上目標設定マスタGuidの得意先別売上目標設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">CustSalesTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先別売上目標設定マスタGuidの得意先別売上目標設定マスタを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 得意先別売上目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 得意先別売上目標設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="custSalesTargetWork">検索結果</param>
        /// <param name="paracustSalesTargetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			out object custSalesTargetWork,
            object paracustSalesTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 得意先別売上目標設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			ref object custSalesTargetWork
            );

        /// <summary>
        /// 得意先別売上目標設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			ref object custSalesTargetWork
            );

        /// <summary>
        /// 論理削除得意先別売上目標設定マスタ情報を復活します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除得意先別売上目標設定マスタ情報を復活します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			ref object custSalesTargetWork
            );
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// 得意先別売上目標設定マスタ情報を更新します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト(write用)</param>
        /// <param name="parabyte">CustSalesTargetWorkオブジェクト(delete用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を更新します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        [MustCustomSerialization]
        int WriteProc(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
            ref object custSalesTargetWork,
            byte[] parabyte
            );
        #endregion
        // ---ADD 2010/12/20---------<<<<<
    }
}

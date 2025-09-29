using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// SCM問い合わせ一覧DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM問い合わせ一覧DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350 櫻井 亮太</br>
	/// <br>Date       : 2009.05.14</br>
	/// <br></br>
    /// <br>Update Note: SCMリリース対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/04/13</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMInquiryDB
	{
        
        /// <summary>
        /// SCM問い合わせ一覧LISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="scmInquiryResultWork">検索結果</param>
        /// <param name="scmInquiryOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object scmInquiryResultWork,
            object scmInquiryOrderWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// SCM問い合わせ一覧LISTを全て戻します（キャンセル以外、キャンセル分のいずれか）
		/// </summary>
        /// <param name="scmInquiryResultWork">検索結果</param>
        /// <param name="scmInquiryOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object scmInquiryResultWork,
            object objscmInquiryResultWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // -- ADD 2010/04/13 ----------------------------------->>>
        /// <summary>
        /// SCM問い合わせ一覧LISTを全て戻します（キャンセル以外分、キャンセル分の両方）
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        /// <param name="scmInquiryResultWorkCancel"></param>
        /// <param name="objscmInquiryResultWork"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchDetailAll(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object scmInquiryResultWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object scmInquiryResultWorkCancel,
            object objscmInquiryResultWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        // -- ADD 2010/04/13 -----------------------------------<<<


        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧の件数を戻します（論理削除除く）
        /// </summary>
        /// <param name="readCnt">抽出件数</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧件数を戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        int SearchCnt(out int readCnt, object objscmInquiryOrderWork);
    }

}

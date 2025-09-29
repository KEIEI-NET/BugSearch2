using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 発注送信エラーリストDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 発注送信エラーリストDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350 櫻井 亮太</br>
	/// <br>Date       : 2008.9.22</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISupplierSendErOrderWorkDB
	{
        
        /// <summary>
        /// 発注送信エラーリストLISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="supplierSendErResultWork">検索結果</param>
        /// <param name="supplierSendErOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 櫻井 亮太</br>
		/// <br>Date       : 2008.9.22</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE02088D", "Broadleaf.Application.Remoting.ParamData.SupplierSendErResultWork")]
			out object supplierSendErResultWork,
           object supplierSendErOrderCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 支払READDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払READDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 99033 岩本　勇</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IPaymentReadDB
	{
		#region カスタムシリアライズ

        /// <summary>
        /// 支払READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="paymentDataWork">検索結果</param>
        /// <param name="searchParaPaymentRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 99033 岩本　勇</br>
        /// <br>Date       : 2005.08.16</br>
        int Search(
            //[CustomSerializationMethodParameterAttribute("SFSIR02140D","Broadleaf.Application.Remoting.ParamData.PaymentSlpWork")]  //DEL 2008/04/24 M.Kubota
            [CustomSerializationMethodParameterAttribute("SFSIR02140D", "Broadleaf.Application.Remoting.ParamData.PaymentDataWork")]  //ADD 2008/04/24 M.Kubota
            //out object paymentMainWork,  //DEL 2008/04/24 M.Kubota
            out object paymentDataWork,    //ADD 2008/04/24 M.Kubota
            object searchParaPaymentRead,
            int readMode,ConstantManagement.LogicalMode logicalMode);

		#endregion
	}
}

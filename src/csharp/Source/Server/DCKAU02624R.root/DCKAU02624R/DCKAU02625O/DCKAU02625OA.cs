using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 売掛消費税差異表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売掛消費税差異表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 980081　山田 明友</br>
	/// <br>Date       : 2007.11.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IAccRecConsTaxDiffDB
	{

		#region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 売掛消費税差異表LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="accRecConsTaxDiffWork">検索結果</param>
        /// <param name="paraAccRecConsTaxDiffWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        [MustCustomSerialization]
        int SearchAccRecConsTaxDiffProc(
            [CustomSerializationMethodParameterAttribute("DCKAU02626D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecConsTaxDiffWork")]
			out object accRecConsTaxDiffWork,
            object paraAccRecConsTaxDiffWork);
        #endregion
	}
}

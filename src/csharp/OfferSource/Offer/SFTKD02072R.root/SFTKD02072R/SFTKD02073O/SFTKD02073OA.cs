using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 部品メーカー名称設定（提供）DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 部品メーカー名称設定（提供）DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22027　橋本　将樹</br>
	/// <br>Date       : 2006.06.08</br>
	/// <br></br>
	/// <br>Update Note: 30290 2008/06/03</br>
    /// <br>             テーブルレイアウト変更による修正</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
	public interface IPMakerNmDB
	{
		/// <summary>
		/// 部品メーカー名称設定（提供）LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2006.06.08</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFTKD02074D","Broadleaf.Application.Remoting.ParamData.PMakerNmWork")]
			out object retobj,
            int readMode);
					
		/// <summary>
		/// 指定された部品メーカー名称設定（提供）Guidの部品メーカー名称設定（提供）を戻します
		/// </summary>
		/// <param name="parabyte">PMakerNmWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された部品メーカー名称設定（提供）Guidの部品メーカー名称設定（提供）を戻します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2006.06.08</br>
		int Read(ref byte[] parabyte , int readMode);
	}
}

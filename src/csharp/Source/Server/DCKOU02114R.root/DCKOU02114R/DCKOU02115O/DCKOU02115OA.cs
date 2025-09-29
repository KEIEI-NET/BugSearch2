using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 仕入日報月報DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入日報月報DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21112　久保田　誠</br>
	/// <br>Date       : 2007.09.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockDayMonthReportDB
	{
		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 仕入日報月報LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockDayMonthReportDataWork">検索結果</param>
		/// <param name="parastockDayMonthReportWork">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21112　久保田　誠</br>
		/// <br>Date       : 2007.09.06</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU02116D", "Broadleaf.Application.Remoting.ParamData.StockDayMonthReportDataWork")]
			out object stockDayMonthReportDataWork,
			object parastockDayMonthReportWork);
		#endregion
	}
}

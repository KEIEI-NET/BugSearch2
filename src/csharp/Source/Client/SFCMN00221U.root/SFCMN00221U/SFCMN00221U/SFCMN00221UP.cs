using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	internal class SliderCommonLib
	{
		public SliderCommonLib(Encoding sjisEnc)
		{
			_sjisEnc = sjisEnc;
		}

		private Encoding _sjisEnc;

		/// <summary>
		/// 文字列右埋処理
		/// </summary>
		/// <param name="totalLength">最大レングス</param>
		/// <param name="sourceString">元文字列</param>
		/// <param name="paddingChar">追加文字</param>
		/// <returns>編集後文字列</returns>
		internal string PadRight(int totalLength, string sourceString, char paddingChar)
		{
			int currentLength = this._sjisEnc.GetByteCount(sourceString.Trim());

			StringBuilder builder = new StringBuilder(sourceString);

			for (int i = currentLength; i < totalLength; i++)
			{
				builder.Append(paddingChar);
			}

			return builder.ToString();
		}

		/// <summary>
		/// 仕入形式名称取得処理
		/// </summary>
		/// <param name="searchRetStockSlip">仕入検索戻り値クラス</param>
		/// <returns>仕入形式名称</returns>
		internal static string GetSupplierFormalName(SearchRetStockSlip searchRetStockSlip)
		{
			// 仕入形式名称
			string supplierFormalName = "";
			if (searchRetStockSlip.SupplierFormal == 1)
			{
				supplierFormalName = "入荷";
			}
			else
			{
				supplierFormalName = "仕入";
			}
			if (searchRetStockSlip.SupplierSlipCd == 20)
			{
				supplierFormalName += "(返品)";
			}

			return supplierFormalName;
		}
	}
}

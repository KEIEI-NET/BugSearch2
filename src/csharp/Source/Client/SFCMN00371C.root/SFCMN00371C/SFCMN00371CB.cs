using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 在庫部品用バーコード編集部品
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫部品用にバーコード編集の関数を提供します。</br>
	/// <br>Programer  : 21027 須川  程志郎</br>
	/// <br>Date       : 2007.01.15</br>
	/// </remarks>
	public class StockPartsBarcodeEditor
	{
		/// <summary>
		/// バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="stockPartsMakerCd">在庫部品用メーカーコード</param>
		/// <param name="stckWithHyphenPartNo">在庫部品用ハイフン付品番</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		public static bool CreateBarcode(out string barcode, int stockPartsMakerCd, string stckWithHyphenPartNo)
		{
			barcode = "";

			barcode =
				String.Format("{0}{1:d2}{2:d4}{3:d4}{4}",
					TBarcodeEditor.BarcodeNoticeCode,
					TBarcodeEditor.BarcodeInputSys_ALL,
					TBarcodeEditor.BarcodeFuncDiv_StockParts,
					stockPartsMakerCd,
					stckWithHyphenPartNo);

			return true;
		}

#if false	// 2007.01.15 今のところ不要の為,未実装
		/// <summary>
		/// バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="dispBarCode">表示用バーコード文字列</param>
		/// <param name="stockPartsMakerCd">在庫部品用メーカーコード</param>
		/// <param name="stckWithHyphenPartNo">在庫部品用ハイフン付品番</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		public static bool CreateBarcode(out string barcode, out string dispBarCode, int stockPartsMakerCd, string stckWithHyphenPartNo)
		{
			barcode = "";
			dispBarCode = "";

			barcode =
				String.Format("{0}{1:d2}{2:d4}{3:d4}{4}",
					TBarcodeEditor.BarcodeNoticeCode,
					TBarcodeEditor.BarcodeInputSys_ALL,
					TBarcodeEditor.BarcodeFuncDiv_StockParts,
					stockPartsMakerCd,
					stckWithHyphenPartNo);

			dispBarCode =
				String.Format("{1:d2}{2:d4}{3:d4}{4}",
					TBarcodeEditor.BarcodeNoticeCode,
					TBarcodeEditor.BarcodeInputSys_ALL,
					TBarcodeEditor.BarcodeFuncDiv_StockParts,
					stockPartsMakerCd,
					stckWithHyphenPartNo);

			return true;
		}
#endif

		/// <summary>
		/// バーコード解析処理（数値コード）
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <param name="stockPartsMakerCd">仕入在庫用部品メーカーコード</param>
		/// <param name="stckWithHyphenPartNo">仕入在庫用ハイフン付部品品番</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、在庫部品用にメーカーコードと部品品番を取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int stockPartsMakerCd, out string stckWithHyphenPartNo)
		{
			string codeStr;
			int inputSys = -1;
			int funcDiv = -1;

			stockPartsMakerCd = 0;
			stckWithHyphenPartNo = "";

			try
			{
				if (TBarcodeEditor.AnalyzeBarcode(barcode, out inputSys, out funcDiv, out codeStr))
				{
					if (funcDiv != TBarcodeEditor.BarcodeFuncDiv_StockParts)
					{
						// 機能区分が在庫部品以外は失敗
						return false;
					}
					else
					{
						// メーカーコード取得
						if (!Int32.TryParse(codeStr.Substring(0, 4), out stockPartsMakerCd))
						{
							return false;
						}

						// 品番取得
						stckWithHyphenPartNo = codeStr.Substring(4);
					}
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}

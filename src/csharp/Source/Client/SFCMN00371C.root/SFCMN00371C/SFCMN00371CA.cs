using System;
using System.Collections;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// バーコート編集部品
	/// </summary>
	/// <remarks>
	/// <br>Note       : バーコード編集の関数を提供します。</br>
	/// <br>Programer  : 21027 須川  程志郎</br>
	/// <br>Date       : 2005.12.20</br>
	/// <br></br>
	/// <br>Update Note: 2006.02.07  21027 須川  程志郎</br>
	/// <br>           : 在庫車両管理番号を追加</br>
	/// <br>Update Note: 2006.09.22  21027 須川  程志郎</br>
	/// <br>           : 1.TSP機能区分削除, TSP機能区分グループ追加</br>
	/// <br>           : 2.NSQRコード判定処理追加</br>
	/// <br>           : 2006.11.30  20015 小田　義昭</br>
	/// <br>           : 1.伝票QRコード印刷対応(定義の追加)</br>
	/// <br>Update Note: 2006.12.21  21027 須川  程志郎</br>
	/// <br>           : 在庫部品番号を追加</br>
	/// <br>Update Note: 2007.08.16  21027 須川  程志郎</br>
	/// <br>           : </br>
	/// </remarks>
	public class TBarcodeEditor
	{
		#region Public Members
		/* 新規にコードを追加した場合は静的コンストラクタも要変更!! */
		/// <summary>バーコード通知コード文字</summary>
		public static readonly char BarcodeNoticeCode			= '^';
		/// <summary>バーコードデータ入力システム：共通</summary>
		public static readonly int BarcodeInputSys_ALL			= 0;
		/// <summary>バーコードデータ入力システム：整備</summary>
		public static readonly int BarcodeInputSys_SF			= 1;
		/// <summary>バーコードデータ入力システム：鈑金</summary>
		public static readonly int BarcodeInputSys_BK			= 2;
		/// <summary>バーコードデータ入力システム：車販</summary>
		public static readonly int BarcodeInputSys_CS			= 3;

		/// <summary>バーコード機能区分：伝票(伝票番号)</summary>
		public static readonly int BarcodeFuncDiv_SlipNo		= 101;
		/// <summary>バーコード機能区分：伝票(受注番号)</summary>
		public static readonly int BarcodeFuncDiv_AcceptNo		= 102;
		/// <summary>バーコード機能区分：セット作業</summary>
		public static readonly int BarcodeFuncDiv_SetWork		= 201;
		/// <summary>バーコード機能区分：作業</summary>
		public static readonly int BarcodeFuncDiv_Work			= 202;
		/// <summary>バーコード機能区分：部品</summary>
		public static readonly int BarcodeFuncDiv_Parts			= 203;
		/// <summary>バーコード機能区分：在庫部品</summary>
		public static readonly int BarcodeFuncDiv_StockParts	= 210;
		/// <summary>バーコード機能区分：諸費用</summary>
		public static readonly int BarcodeFuncDiv_VarCost		= 301;
		/// <summary>バーコード機能区分：得意先</summary>
		public static readonly int BarcodeFuncDiv_Customer		= 401;
		/// <summary>バーコード機能区分：車両管理番号</summary>
		public static readonly int BarcodeFuncDiv_CarMng		= 501;
		/// <summary>バーコード機能区分：車両管理番号</summary>
		public static readonly int BarcodeFuncDiv_StockCarMng	= 502;
		/// <summary>バーコード機能区分：WEB共有在庫車両</summary>
		public static readonly int BarcodeFuncDiv_WebStockCar	= 503;		// 2007.08.16 Add T.Sugawa
		/// <summary>バーコード機能区分：従業員</summary>
		public static readonly int BarcodeFuncDiv_Employee		= 601;
//		/// <summary>バーコード機能区分：TSPオフライン</summary>
//		public static readonly int BarcodeFuncDiv_TSP			= 1001;

		/// <summary>バーコード機能区分グループ：TSPオフライン</summary>
		public static readonly int BarcodeFuncDivGrp_TSP		= 10;
		/// <summary>バーコード機能区分グループ：伝票QR印刷</summary>
		public static readonly int BarcodeFuncDivGrp_SlipPrt	= 20;


		/// <summary>バーコード機能区分：制御コード</summary>
		public static readonly int BarcodeFuncDiv_Ctrl			= 9901;
		#endregion

		#region Private Members
		// バーコードデータ入力システム用テーブル
		private static Hashtable inputSysTable;
		// バーコード機能区分用テーブル
		private static Hashtable funcDivTable;
		// バーコード機能区分(グループ用)テーブル
		private static Hashtable funcDivGrpTable;				// 2006.11.30 小田 Add

		// バーコード最小文字列長
		private const int ctCodeMinLength = 6;
		#endregion

		#region Constructor
		/// <summary>
		/// 静的コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : バーコート編集部品クラスの静的初期化を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		static TBarcodeEditor()
		{
			// バーコードデータ入力システム用テーブル作成
			inputSysTable = new Hashtable(4);
			inputSysTable.Add(BarcodeInputSys_ALL, null);
			inputSysTable.Add(BarcodeInputSys_SF, null);
			inputSysTable.Add(BarcodeInputSys_BK, null);
			inputSysTable.Add(BarcodeInputSys_CS, null);

			// バーコード機能区分用テーブル作成
			funcDivTable = new Hashtable(13);
			funcDivTable.Add(BarcodeFuncDiv_SlipNo, null);
			funcDivTable.Add(BarcodeFuncDiv_AcceptNo, null);
			funcDivTable.Add(BarcodeFuncDiv_SetWork, null);
			funcDivTable.Add(BarcodeFuncDiv_Work, null);
			funcDivTable.Add(BarcodeFuncDiv_Parts, null);
			funcDivTable.Add(BarcodeFuncDiv_StockParts, null);			// 2006.12.21 Add T.Sugawa
			funcDivTable.Add(BarcodeFuncDiv_VarCost, null);
			funcDivTable.Add(BarcodeFuncDiv_Customer, null);
			funcDivTable.Add(BarcodeFuncDiv_CarMng, null);
			funcDivTable.Add(BarcodeFuncDiv_StockCarMng, null);
			funcDivTable.Add(BarcodeFuncDiv_WebStockCar, null);			// 2007.08.16 Add T.Sugawa
			funcDivTable.Add(BarcodeFuncDiv_Employee, null);
//			funcDivTable.Add(BarcodeFuncDiv_TSP, null);
			funcDivTable.Add(BarcodeFuncDiv_Ctrl, null);

// >>>> 2006.11.30 小田 Add ここから >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			// バーコード機能区分(グループ用)テーブル作成
			funcDivGrpTable = new Hashtable(2);
			funcDivGrpTable.Add(BarcodeFuncDivGrp_TSP, null);
			funcDivGrpTable.Add(BarcodeFuncDivGrp_SlipPrt, null);
// <<<< 2006.11.30 小田 Add ここまで <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : バーコート編集部品クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public TBarcodeEditor()
		{
			// 
			// TODO: コンストラクタ ロジックをここに追加してください。
			//
		}
		#endregion

		#region Properties
		/// <summary>
		/// 確定処理バーコード
		/// </summary>
		public static string EnterBarcode
		{
			get
			{
				string retStr, dmyStr = "";
				CreateBarcode(out dmyStr, out retStr, BarcodeInputSys_ALL, BarcodeFuncDiv_Ctrl, "{0:d3}", 0);
				return retStr;
			}
		}

		/// <summary>
		/// キャンセル処理バーコード
		/// </summary>
		public static string CancelBarcode
		{
			get
			{
				string retStr, dmyStr = "";
				CreateBarcode(out dmyStr, out retStr, BarcodeInputSys_ALL, BarcodeFuncDiv_Ctrl, "{0:d3}", 1);
				return retStr;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <param name="code">バーコード要素文字列</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : バーコード通知コード付のバーコード文字列を作成します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, int inputSys, int funcDiv, string code)
		{
			barcode = "";

			if (!inputSysTable.Contains(inputSys) || !(funcDivTable.Contains(funcDiv)))
			{
				return false;
			}

			barcode = String.Format("{0}{1:d2}{2:d4}{3}", BarcodeNoticeCode, inputSys, funcDiv, code);

			return true;
		}

		/// <summary>
		/// バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="dispBarCode">表示用バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <param name="code">バーコード要素文字列</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : バーコード通知コード付のバーコード文字列を作成します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, out string dispBarCode, int inputSys, int funcDiv, string code)
		{
			barcode = "";
			dispBarCode = "";

			if (!inputSysTable.Contains(inputSys) || !(funcDivTable.Contains(funcDiv)))
			{
				return false;
			}

			barcode = String.Format("{0}{1:d2}{2:d4}{3}", BarcodeNoticeCode, inputSys, funcDiv, code);
			dispBarCode = String.Format("{1:d2}{2:d4}{3}", BarcodeNoticeCode, inputSys, funcDiv, code);

			return true;
		}
		
		/// <summary>
		/// バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <param name="format">書式文字列</param>
		/// <param name="code">バーコード要素</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : 書式付でバーコード通知コード付のバーコード文字列を作成します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, int inputSys, int funcDiv, string format, object code)
		{
			string wkCodeStr = "";
			barcode = "";
			try
			{
				wkCodeStr = String.Format(format, code);
			}
			catch (Exception)
			{
				return false;
			}

			return CreateBarcode(out barcode, inputSys, funcDiv, wkCodeStr);
		}

		/// <summary>
		/// バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="dispBarCode">表示用バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <param name="format">書式文字列</param>
		/// <param name="code">バーコード要素</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : 書式付でバーコード通知コード付のバーコード文字列を作成します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool CreateBarcode(out string barcode, out string dispBarCode, int inputSys, int funcDiv, string format, object code)
		{
			string wkCodeStr = "";
			barcode = "";
			dispBarCode = "";

			try
			{
				wkCodeStr = String.Format(format, code);
			}
			catch (Exception)
			{
				return false;
			}

			return CreateBarcode(out barcode, out dispBarCode, inputSys, funcDiv, wkCodeStr);
		}

		/// <summary>
		/// QRコード用バーコード作成処理
		/// </summary>
		/// <param name="barcode">作成バーコード文字列</param>
		/// <param name="inputSys">データ入力システム</param>
		/// <param name="funcDivGrp">バーコードグループコード</param>
		/// <param name="funcDivSubCd">バーコードグループサブコード</param>
		/// <param name="code">バーコード要素</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : QRコード用のバーコード文字列を生成します。</br>
		/// <br>Programmer : 21027 須川  程志郎 AND 20015 小田　義昭</br>
		/// <br>Date       : 2006.11.30</br>
		/// </remarks>
		public static bool CreateNSQRCode(out string barcode, int inputSys, int funcDivGrp, int funcDivSubCd, string code)
		{
			barcode = "";

			if (!inputSysTable.Contains(inputSys) || !(funcDivGrpTable.Contains(funcDivGrp)) || (funcDivSubCd >= 100))
			{
				return false;
			}

			barcode = String.Format("{0}{1:d2}{2:d2}{3:d2}{4}", BarcodeNoticeCode, inputSys, funcDivGrp, funcDivSubCd, code);

			return true;
		}

		/// <summary>
		/// バーコード解析処理（入力システムと機能区分）
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、バーコード情報を取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int inputSys, out int funcDiv)
		{
			inputSys = -1;
			funcDiv = -1;

			// 最小文字列チェック
			if (barcode.Length <= ctCodeMinLength) return false;

			try
			{
				string wkInputSysStr = barcode.Substring(0, 2);
				string wkFuncDivStr = barcode.Substring(2, 4);

				inputSys = Convert.ToInt32(wkInputSysStr);
				funcDiv = Convert.ToInt32(wkFuncDivStr);

				// 定義済みコード判定
				if (!inputSysTable.Contains(inputSys) || !(funcDivTable.Contains(funcDiv)))
				{
//-- 2006.09.21 Add Start by T.Sugawa ------------------------------------------------------------//
					if (IsNSQRCode(barcode) > 0)
					{
						return true;
					}
//-- 2006.09.21 Add End by T.Sugawa --------------------------------------------------------------//

					inputSys = -1;
					funcDiv = -1;
					return false;
				}
			}
			catch (Exception)
			{
				inputSys = -1;
				funcDiv = -1;
				return false;
			}

			return true;
		}

		/// <summary>
		/// バーコード解析処理（文字列コード）
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <param name="code">バーコード要素文字列</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、バーコード情報を取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int inputSys, out int funcDiv, out string code)
		{
			inputSys = -1;
			funcDiv = -1;
			code = "";

			try
			{
				if (AnalyzeBarcode(barcode, out inputSys, out funcDiv))
				{
					code = barcode.Substring(6, barcode.Length - 6);
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				inputSys = -1;
				funcDiv = -1;
				code = "";
				return false;
			}

			return true;
		}

		/// <summary>
		/// バーコード解析処理（数値コード）
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <param name="inputSys">バーコードデータ入力システム</param>
		/// <param name="funcDiv">バーコード機能区分</param>
		/// <param name="code">バーコード要素数値</param>
		/// <returns>ステータス(true:成功, false:失敗)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、バーコード情報を取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static bool AnalyzeBarcode(string barcode, out int inputSys, out int funcDiv, out int code)
		{
			string codeStr;
			inputSys = -1;
			funcDiv = -1;
			code = 0;

			try
			{
				if (AnalyzeBarcode(barcode, out inputSys, out funcDiv, out codeStr))
				{
					code = Convert.ToInt32(codeStr.Trim());
				}
				else
				{
					code = 0;
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// バーコード入力システム取得処理
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <returns>バーコード入力システム(取得失敗は-1)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、バーコード入力システムを取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static int GetInputSys(string barcode)
		{
			int inputSys = -1, funcDiv = -1;

			if (!AnalyzeBarcode(barcode, out inputSys, out funcDiv))
			{
				return -1;
			}

			return inputSys;
		}

		/// <summary>
		/// バーコード機能区分取得処理
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <returns>バーコード機能区分(取得失敗は-1)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、バーコード機能区分を取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public static int GetFunkDiv(string barcode)
		{
			int inputSys = -1, funcDiv = -1;

			if (!AnalyzeBarcode(barcode, out inputSys, out funcDiv))
			{
				return -1;
			}

			return funcDiv;
		}

		/// <summary>
		/// NSQRコード判定処理
		/// </summary>
		/// <param name="barcode">解析バーコード文字列</param>
		/// <returns>NSQRコード機能区分グループ(-1:取得失敗, 0:NSQRコード以外)</returns>
		/// <remarks>
		/// <br>Note       : バーコート文字列を解析して、NSQRコードの場合は機能区分グループコードを返します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2006.09.22</br>
		/// </remarks>
		public static int IsNSQRCode(string barcode)
		{
			try
			{
				// 最小文字列チェック
				if (barcode.Length > ctCodeMinLength)
				{
					int inputSys = Convert.ToInt32(barcode.Substring(0, 2));
					int funcDiv = Convert.ToInt32(barcode.Substring(2, 4));

					// TSPオフライン用QRコードチェック(1000～1012までが有効)
					if ((funcDiv >= 1000) && (funcDiv <= 1012))
					{
						return funcDiv / 100;
					}
// >>>> 2006.11.30 小田 Add ここから >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					if ((funcDiv >= 2000) && (funcDiv <= 2012))
					{
						return funcDiv / 100;
					}
// <<<< 2006.11.30 小田 Add ここまで <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				}
			}
			catch (Exception)
			{
				return -1;
			}

			return 0;
		}
		#endregion
	}
}

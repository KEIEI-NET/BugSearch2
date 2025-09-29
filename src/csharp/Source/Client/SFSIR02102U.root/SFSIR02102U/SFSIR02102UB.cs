using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class SFSIR02102UA
	{
		/// <summary>
		/// 支払金額情報取得クラス
		/// </summary>
		/// <remarks>
		/// <br>Note		: 支払金額情報を取得するクラスです。</br>
		///	<br>			: 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// <br></br>
		/// <br>UpdateNote	: </br>
		/// </remarks>
		private class GetCustPaymentPrc
		{
			#region Delegate
			/// <summary>結果を返すためのコールバックデリゲート</summary>
			public delegate void Callback(SearchSuplierPayRet searchSuplierPayRet);
			#endregion

			#region PrivateMember
			// デリゲートオブジェクト
			private Callback callbackDelegate;
			// 支払検索アクセスクラス
			private PaymentSlpSearch paymentSlpSearch;
			// 仕入先情報/支払金額情報取得用パラメータ
			private SearchPaymentParameter parameter;
			#endregion

			#region Constructor
			/// <summary>
			/// 支払金額情報取得クラス(別スレッド用)
			/// </summary>
			/// <param name="searchPaymentParameter">仕入先情報/支払金額情報取得用パラメータ</param>
			/// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
			/// <remarks>
			/// <br>Note		: 使用するメンバの初期化を行います。</br>
			/// <br>Programmer	: 22024 寺坂　誉志</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public GetCustPaymentPrc(SearchPaymentParameter searchPaymentParameter, Callback callback)
			{
				// 支払検索アクセスクラス
				paymentSlpSearch = new PaymentSlpSearch();

				// 得意先情報/得意先金額情報取得用パラメータ
				parameter = searchPaymentParameter;

				// コールバックメソッドのデリゲート登録
				callbackDelegate = callback;
			}
			#endregion

			#region PublicMethod
			/// <summary>
			/// メイン処理
			/// </summary>
			/// <remarks>
			/// <br>Note		: 支払金額情報の取得を行います。</br>
			/// <br>Programmer	: 22024 寺坂　誉志</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public void GetPaymentInfo()
			{
				try
				{
					// 支払関連データ取得処理（仕入先コード指定）
					SearchSuplierPayRet searchSuplierPayRet;
					int st = paymentSlpSearch.ReadCustomPaymentInfo(parameter, out searchSuplierPayRet);
					if (st == 0)
					{
						// コールバックデリゲートを実行して結果を返す
						if (callbackDelegate != null)
							callbackDelegate(searchSuplierPayRet);
					}
				}
				catch (ThreadAbortException)
				{
					// スレッド中断時
				}
				catch (Exception)
				{
					// その他エラー時  たいした処理ではないので、エラーがおきても無視
				}
			}
			#endregion
		}
	}
}

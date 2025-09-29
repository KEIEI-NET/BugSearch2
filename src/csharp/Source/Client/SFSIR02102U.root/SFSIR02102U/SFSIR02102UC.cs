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
		/// クレジット会社名称取得クラス
		/// </summary>
		/// <remarks>
		/// <br>Note		: クレジット会社名称を取得するクラスです。</br>
		/// <br>			: 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// <br></br>
        /// <br>UpdateNote	: 2007.09.05 疋田 勇人 DC.NS用にレイアウト変更 銀行名称取得クラスに変更する</br>
		/// </remarks>
        // 2007.09.05 hikita upd start ------------------------------------------------->>
        /*
        private class GetCreditCompanyNamePrc  
   		{
			#region Delegate
			/// <summary>結果を返すためのコールバックデリゲート</summary>
			public delegate void Callback(string creditCompanyCode, string creditCompanyName);
   			#endregion

			#region PrivateMember
			// デリゲートオブジェクト
			private Callback callbackDelegate;
			// クレジット会社テーブルアクセスクラス
			private CreditCmpAcs creditCmpAcs;
			// 情報取得用パラメータ 企業コード
			private string _enterpriseCode;
			// 情報取得用パラメータ クレジット会社コード
			private string _creditCompanyCode;
			#endregion

			#region Constructor
			/// <summary>
			/// クレジット会社名称取得クラス
			/// </summary>
			/// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
			/// <param name="creditCompanyCode">情報取得用パラメータ クレジット会社コード</param>
			/// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
			/// <remarks>
			/// <br>Note		: 使用するメンバの初期化を行います。</br>
			/// <br>Programmer	: 22024 寺坂　誉志</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public GetCreditCompanyNamePrc(string enterpriseCode, string creditCompanyCode, Callback callback)
			{
				// クレジット会社テーブルアクセスクラス
				this.creditCmpAcs = new CreditCmpAcs();

				// 情報取得用パラメータ
				_enterpriseCode = enterpriseCode;
				_creditCompanyCode = creditCompanyCode;

				// コールバックメソッドのデリゲート登録
				callbackDelegate = callback;
			}
			#endregion

			#region PublicMethod
			/// <summary>
			/// メイン処理
			/// </summary>
			/// <remarks>
			/// <br>Note		: クレジット会社名称の取得を行います。</br>
			/// <br>Programmer	: 22024 寺坂　誉志</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public void GetCreditCmpNm()
			{
				try
				{
					// クレジット会社取得
					CreditCmp creditCmp = new CreditCmp();
					int st = creditCmpAcs.Read(out creditCmp, _enterpriseCode, _creditCompanyCode);
					if (st == 0)
					{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
						if (callbackDelegate != null)
							callbackDelegate(_creditCompanyCode, creditCmp.CreditCompanyName);
					}
					else
					{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
						if (callbackDelegate != null)
							callbackDelegate("", "");
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
        */
        private class GetBankNamePrc
        {
            #region Delegate
            /// <summary>結果を返すためのコールバックデリゲート</summary>
            public delegate void Callback(Int32 bankCode, string bankName);
            #endregion

            #region PrivateMember
            // デリゲートオブジェクト
            private Callback callbackDelegate;
            // ユーザーガイドテーブルアクセスクラス
            private UserGuideAcs userGuideAcs;
            // 情報取得用パラメータ 企業コード
            private string _enterpriseCode;
            // 情報取得用パラメータ 銀行コード
            private Int32 _bankCode;
            #endregion

            #region Constructor
            /// <summary>
            /// 銀行名称取得クラス
            /// </summary>
            /// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
            /// <param name="bankCode">情報取得用パラメータ 銀行コード</param>
            /// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
            /// <remarks>
            /// <br>Note		: 使用するメンバの初期化を行います。</br>
            /// <br>Programmer	: 20081 疋田　勇人</br>
            /// <br>Date		: 2007.09.05</br>
            /// </remarks>
            public GetBankNamePrc(string enterpriseCode, Int32 bankCode, Callback callback)
            {
                // ユーザーガイドテーブルアクセスクラス
                this.userGuideAcs = new UserGuideAcs();

                // 情報取得用パラメータ
                _enterpriseCode = enterpriseCode;
                _bankCode = bankCode;

                // コールバックメソッドのデリゲート登録
                callbackDelegate = callback;
            }
            #endregion

            #region PublicMethod
            /// <summary>
            /// メイン処理
            /// </summary>
            /// <remarks>
            /// <br>Note		: 銀行名称の取得を行います。</br>
            /// <br>Programmer	: 20081 疋田　勇人</br>
            /// <br>Date		: 2007.09.05</br>
            /// </remarks>
            public void GetBankName()
            {
                try
                {
                    // 銀行名取得
                    string guideName = "";

                    int st = userGuideAcs.GetGuideName(out guideName, _enterpriseCode, 46, _bankCode);
                    
                    if (st == 0)
                    {
                        // コールバックデリゲートを実行して結果を返す → メソッドコールバック
                        if (callbackDelegate != null)
                            callbackDelegate(_bankCode, guideName);
                    }
                    else
                    {
                        // コールバックデリゲートを実行して結果を返す → メソッドコールバック
                        if (callbackDelegate != null)
                            callbackDelegate(0, "");
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
        // 2007.09.05 hikita upd end ---------------------------------------------------<<
	}
}

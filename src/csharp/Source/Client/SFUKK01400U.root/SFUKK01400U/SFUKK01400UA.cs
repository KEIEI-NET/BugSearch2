using System;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 入金入力起動フレームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金入力フレームクラスを起動します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/03  22018  鈴木正臣</br>
    /// <br>             未入金一覧表を追加する為、ActiveReportsのライセンス情報を付加。(licenses.licx)</br>
    /// <br>Update Note: 2013/02/05 田建委</br>
    /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33735 画面を閉じるとき、例外が起こる対応</br>
	/// </remarks>
	public class SFUKK01400UA : ApplicationContext
	{
		private static ApplicationContext _apli = null;
		private static string[] _parameter = null;

		/// <summary>
		/// 入金入力起動フレームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01400UA()
		{
			// 起動パラメータの取得
			SFUKK01401UA.StartingParameter startingParameter = new SFUKK01401UA.StartingParameter();
			if (_parameter.Length >= (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE + 1)
				startingParameter.CustomerCode		= Convert.ToInt32(_parameter[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE]);

			if (_parameter.Length >= (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ACCEPTANORDERNO + 1)
				startingParameter.AcceptAnOrderNo	= Convert.ToInt32(_parameter[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ACCEPTANORDERNO]);

            // ↓ 20070130 18322 a MA.NS用に変更
			if (_parameter.Length >= (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ACCEPTANORDERNO + 1)
            {
                // 売伝
				startingParameter.SalesSlipNum = _parameter[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOM1];
            }
            // ↑ 20070130 18322 a

			// 起動モードの決定
			SFUKK01401UA.StartingMode startingMode = new SFUKK01401UA.StartingMode();
			if (startingParameter.AcceptAnOrderNo != 0)
			{
				startingMode = SFUKK01401UA.StartingMode.AcceptAnOrderNo;
			}
            // ↓ 20070130 18322 a MA.NS用に変更
			else if (startingParameter.SalesSlipNum != "")
			{
				startingMode = SFUKK01401UA.StartingMode.SalesSlipNum;
			}
            // ↑ 20070130 18322 a
			else if (startingParameter.CustomerCode != 0)
			{
				startingMode = SFUKK01401UA.StartingMode.CustomerCode;
			}
			else
			{
				startingMode = SFUKK01401UA.StartingMode.Normal;
			}

			// 起動フォームの呼出
			SFUKK01401UA frm = new SFUKK01401UA();
			frm.Closed += new EventHandler(OnFormClosed);
			frm.Show(startingMode, startingParameter);
		}
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				string msg = "";
				_parameter = args;

				// VisualStyleを有効 ※XPのスタイルになる
				System.Windows.Forms.Application.EnableVisualStyles();

				//アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					// オンライン状態判断
					if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFUKK01400U",
							"オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
					}
					else
					{
                        // 起動可能か判定
                        if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry("SFUKK01400U", true))
                        {
                            return;
                        }

						// アプリケーション開始
						_apli = new SFUKK01400UA();
                        System.Windows.Forms.Application.ApplicationExit += new EventHandler(Application_ApplicationExit); // ADD 2013/02/05 田建委 Redmine#33735
						System.Windows.Forms.Application.Run(_apli);
					}
				}
				
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFUKK01400U", msg, 0, MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01400U", ex.Message, -1, MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

        //----- ADD 2013/02/05 田建委 Redmine#33735 ------------------->>>>>
        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //----- ADD 2013/02/05 田建委 Redmine#33735 -------------------<<<<<
		
		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();

			//従業員ログオフのメッセージを表示
			TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFUKK01400U", e.ToString(), 0, MessageBoxButtons.OK);

			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		
        /// <summary>
        /// 起動フォームのクローズイベントハンドラです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/02/05 田建委</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33735 画面を閉じるとき、例外が起こる対応</br>
        /// </remarks>
		private void OnFormClosed(object sender, EventArgs e) 
		{
			// スレッドのメッセージループ終了の呼出
			ExitThread();
            //Environment.Exit(0); // DEL 2013/02/05 田建委 Redmine#33735
		}

		/// <summary>
		/// スレッドの終了です。
		/// </summary>
		protected override void ExitThreadCore()
		{
			// Applicationオブジェクトにてスレッド終了
			base.ExitThreadCore ();
		}
	}
}

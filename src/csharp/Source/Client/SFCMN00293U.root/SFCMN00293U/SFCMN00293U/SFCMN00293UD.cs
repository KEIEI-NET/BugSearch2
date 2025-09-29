using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ActiveReport共通レポート印刷制御クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveRepotr印刷時の印刷制御クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.02</br>
	/// </remarks>
	public class ARptPrintCtrl
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// ActiveReport共通レポート印刷制御クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
		public ARptPrintCtrl()
		{
			// 共通関数部品インスタンス作成
			this._commonLib = new SFCMN00293UZ();

			// 印字位置調整部品インスタンス作成
			this._positionAdjPrtLib = new SFCMN00294CA();
		}
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region Private Member
		private SFCMN00293UZ _commonLib;
		private SFCMN00293UC _commonInfo;
		private SFCMN00294CA _positionAdjPrtLib;				// 印字位置調整部品(印刷用)
		#endregion

		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region Public Property
		
		/// <summary>共通画面条件プロパティ</summary>
		public SFCMN00293UC CommonInfo
		{
			get { return this._commonInfo; }
			set { this._commonInfo = value; }
		}
		
		#endregion

		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region Public Methods
		
		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <param name="IsPrint">印刷有無[T:印刷する,F:ドキュメント作成のみ]</param>
		/// <param name="msg">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt, bool IsPrint, out string msg)
		{
			msg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			try
			{
				// 印字位置調整
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref rpt, this._commonInfo, false);

				// 印刷情報設定
				if (this._commonLib.SetPrinterInfo(ref rpt, this._commonInfo, out msg) != 0)
				{
					return status;
				}

				// 印刷開始
				rpt.Run();

				if (rpt.Document != null && rpt.Document.Pages.Count != 0)
				{
					// 印刷する場合のみ
					if (IsPrint)
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                        //rpt.Document.Print(false, false, false);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                        this._commonLib.PrintDocument( false, rpt, _commonInfo.PrinterName );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
					}

					// 戻りSTATUS設定
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
				else
				{
					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}
			catch (Exception ex)
			{
				msg = "印刷処理処理にて例外が発生しました。"
					+ "\n\r" + ex.Message;
			}
			finally
			{
				this._commonInfo.Status = status;

				// 印字位置調整部品破棄
				if (this._positionAdjPrtLib != null)
				{
					this._positionAdjPrtLib.Dispose();
				}
			}

			return status;
		}

		#endregion

	}
}

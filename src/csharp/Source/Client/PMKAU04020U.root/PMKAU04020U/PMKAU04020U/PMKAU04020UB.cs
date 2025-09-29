using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// アプリケーション待機クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 初期化後、待機にしようされる処理をサポートします。<br />
    /// <br>Programmer : 30182 R.Tachiya<br />
    /// <br>Date       : 2012.06.18<br />
    /// <br>Update Note: 2012/09/12 西 毅</br>
    /// <br>             ファイルの存在チェック追加</br>
	/// </remarks>
	public class ApplicationWaiter
	{
		#region // -- Public Methods --

		/// <summary>
		/// アプリケーション待機処理
		/// </summary>
		/// <param name="targetProcessID">ターゲットプロセスID</param>
		/// <remarks>
		/// Note       : 復活指示があるまでアプリケーションを待機させます。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public void SleepUpToFormReView(int targetProcessID)
		{
			int sleepTime = 50;//ms
			int status = -1;

			#region //コントロールファイル確認

			// コントロールアプリケーションにより特定のファイルが作成される仕様	//
			// ファイルが存在するか確認し										//
			// ファイルが存在しない場合常駐待機させない							//

			//コントロールアプリケーションから開始されたこと確認
			status = ControlFileStream.Reader(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.ProcessStart);

			if (status == 4)
			{
				//常駐待機処理を行なわず処理終了
				//ファイルが見つからない場合、ループ終了
				return;
			}
			else if (status == 0 || status == 999 || status == 800)
			{
				//常駐待機処理を行い処理続行
				//読込文字列が見つかった場合、ループ終了処理続行
				//読込文字列が見つからない場合、ループ終了処理続行
				//別スレッドへのアクセス制限の場合、ループ終了処理続行
			}
			else
			{
				//例外
				return;
			}

			#endregion

			#region //コントロールファイル書込み

            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            string filename = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\"
                             + ApplicationController.TARGET_PGID + "_" + targetProcessID;
            if (System.IO.File.Exists(filename))
            {
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
                // コントロールアプリケーションへ常駐待機中であることを通知	//
                status = ControlFileStream.Writer(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.InitializeEnd);
                if (status == 810) return;//タイムアウトの場合終了させる
            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            }
            else
            {
                return;  //ファイルが存在しない場合終了
            }
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
            
			#endregion

			#region //コントロールファイル読込

			// コントロールアプリケーションにより特定のファイルが更新される仕様	//
			// 一定間隔でファイルアクセスを行い									//
			// ファイルが更新されている場合常駐待機から抜ける					//
			// 常駐待機から抜けると画面は復活表示される							//

			do
			{
				//コントロールアプリケーションから復活表示指示確認
				status = ControlFileStream.Reader(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.ReViewForm);

				if (status == 0)
				{
					//コントロールアプリケーションから復活表示指示がある
					//読込文字列が見つかった場合、ループ終了
					break;
				}
				else if (status == 999 || status == 800)
				{
					//読込文字列が見つからない場合、スリープさせる
					//別スレッドへのアクセス制限の場合、スリープさせる
					Thread.Sleep(sleepTime);
				}
				else if (status == 4)
				{
					//ファイルが見つからない場合、ループ終了
					return;
				}
				else
				{
					//例外
					return;
				}

				// ループ処理中にもイベントを流す				//
				// ログオフ処理が流れるようにするための対応		//
				System.Windows.Forms.Application.DoEvents();

			} while (true);

			#endregion

			return;
		}

		/// <summary>
		/// アプリケーション設定終了通知処理
		/// </summary>
		/// <param name="targetProcessID">ターゲットプロセスID</param>
		/// <remarks>
		/// Note       : アプリケーションが復活指示後、復活設定が終了したことを通知します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public void ReViewForm(int targetProcessID)
		{
			#region //コントロールファイル書込み

            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            string filename = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" 
                             + ApplicationController.TARGET_PGID + "_" + targetProcessID;
            if (System.IO.File.Exists(filename))
            {
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
                // コントロールアプリケーションへ表示準備完了であることを通知	//
                ControlFileStream.Writer(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.SettingEnd);
            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            }
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
            #endregion
		}

		#endregion
	}
}

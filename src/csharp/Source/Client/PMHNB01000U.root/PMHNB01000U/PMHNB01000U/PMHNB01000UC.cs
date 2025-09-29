using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 制御ファイルアクセスクラス
	/// </summary>
	/// <remarks>
	/// Note       : 制御ファイルにアクセスするためのクラスです。<br />
	/// Programmer : 30182 R.Tachiya<br />
	/// Date       : 2012.06.18<br />
	/// Update Note: 2012.07.06 30182 立谷 亮介 R.Tachiya<br />
	///            :  高速起動常駐化対応の追加修正、従業員ログイン確認の実装。<br />
    /// Update Note: 2012/11/15 20073 西 毅 T.Nishi<br />
    ///            : ログオフ時に売伝の再起動を行おうとする障害の修正<br />
    /// Update Note: 2013/05/23 宮本 利明<br />
    ///            : ①売上伝票入力での最新情報取得時にバックグラウンドのプロセスを再起動する<br />
    /// </remarks>
	internal class ControlFileStream
	{
		#region // -- Private Members --

		/// <summary>
		/// ロックオブジェクト
		/// </summary>
		/// <remarks>排他ロックオブジェクト。</remarks>
		private static object _filelock = new object();

		#endregion

		#region // -- Public Methods --

		/// <summary>
		/// 書込み処理
		/// </summary>
		/// <param name="writeFileName">ファイル名称</param>
		/// <param name="writeId">プロセスID</param>
		/// <param name="controlText">制御文字列</param>
		/// <returns>0:正常終了、810:TimeOut</returns>
		/// <remarks>
		/// Note       : 制御ファイルに書込みを行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static int Writer(string writeFileName, int writeId, ControlText controlText)
		{
			string strId = writeId.ToString();
			string fileName = writeFileName + "_";

			lock (ControlFileStream._filelock)
			{
				int outTime = 60 * 1000;//ms
				int sleepTime = 50;//ms
				int maxLoopCount = outTime / sleepTime;//回

				for (int count = 0; count < maxLoopCount; count++)
				{
					//ファイル書込み
					StreamWriter sw = null;

					try
					{
						sw = new StreamWriter(
                            System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
							false,
							Encoding.GetEncoding("Shift_JIS")
						);

						sw.Write(controlText.ToString());

						//正常終了
						return 0;
					}
					catch (IOException)
					{
						//別スレッドへのアクセス制限でエクセプションが発生
						//既定の時間スリープさせ、もう一度書き込みする
						Thread.Sleep(sleepTime);
					}
					finally
					{
						if (sw != null)
							sw.Close();
					}
				}
			}

			//TimeOut
			return 810;
		}

		// -- Add Ed 2012.07.06 30182 R.Tachiya --
		/// <summary>
		/// 従業員コードファイル書込み処理
		/// </summary>
		/// <param name="writeFileName">ファイル名称</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>0:正常終了、810:TimeOut</returns>
		/// <remarks>
		/// Note       : 従業員コードファイルに書込みを行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.07.06<br />
		/// </remarks>
		public static int EmployeeWriter(string writeFileName, string employeeCode)
		{
			string strId = "0";//Idが0の場合は従業員コードファイルとなる
			string fileName = writeFileName + "_";

			lock (ControlFileStream._filelock)
			{
				int outTime = 60 * 1000;//ms
				int sleepTime = 50;//ms
				int maxLoopCount = outTime / sleepTime;//回

				for (int count = 0; count < maxLoopCount; count++)
				{
					//ファイル書込み
					StreamWriter sw = null;

					try
					{
						sw = new StreamWriter(
							System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
							false,
							Encoding.GetEncoding("Shift_JIS")
						);

						sw.Write(employeeCode);

						//正常終了
						return 0;
					}
					catch (IOException)
					{
						//別スレッドへのアクセス制限でエクセプションが発生
						//既定の時間スリープさせ、もう一度書き込みする
						Thread.Sleep(sleepTime);
					}
					finally
					{
						if (sw != null)
							sw.Close();
					}
				}
			}

			//TimeOut
			return 810;
		}
		// -- Add Ed 2012.07.06 30182 R.Tachiya --

		/// <summary>
		/// 読込み処理
		/// </summary>
		/// <param name="readFileName">ファイル名称</param>
		/// <param name="readId">プロセスID</param>
		/// <param name="controlText">制御文字列</param>
		/// <returns>0:対象読込-読込文字あり、999:対象読込-読込文字なし、4:対象ファイルなし、800:別スレッドへのアクセス制限</returns>
		/// <remarks>
		/// Note       : 制御ファイルに読込みを行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static int Reader(string readFileName, int readId, ControlText controlText)
		{
			string strId = readId.ToString();
			string fileName = readFileName + "_";

			lock (ControlFileStream._filelock)
			{
				//ファイル読込
				StreamReader sr = null;

				try
				{
					sr = new StreamReader(
                        System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
						Encoding.GetEncoding("Shift_JIS")
						);

					string text = sr.ReadToEnd();

					//コントロール対象の初期化が終わったことを確認
					if (text.Contains(controlText.ToString()))
					{
						//対象読込-読込文字あり
						return 0;
					}
					else
					{
						//対象読込-読込文字なし
						return 999;
					}
				}
				catch (FileNotFoundException)
				{
					//対象ファイルなし
					return 4;
				}
				catch (IOException)
				{
					//別スレッドへのアクセス制限
					return 800;
				}
				finally
				{
					if (sr != null)
						sr.Close();
				}
			}
		}

		// -- Add St 2012.07.06 30182 R.Tachiya --
		/// <summary>
		/// 従業員コードファイル読込み処理
		/// </summary>
		/// <param name="readFileName">ファイル名称</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>0:対象読込-読込文字あり、999:対象読込-読込文字なし、4:対象ファイルなし、800:別スレッドへのアクセス制限</returns>
		/// <remarks>
		/// Note       : 従業員コードファイルに読込みを行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.07.06<br />
		/// </remarks>
		public static int EmployeeReader(string readFileName, out string employeeCode)
		{
			string strId = "0";//Idが0の場合は従業員コードファイルとなる
			string fileName = readFileName + "_";
			employeeCode = "";

			lock (ControlFileStream._filelock)
			{
				//ファイル読込
				StreamReader sr = null;

				try
				{
					sr = new StreamReader(
						System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
						Encoding.GetEncoding("Shift_JIS")
						);

					//string Text = sr.ReadToEnd();
					employeeCode = sr.ReadToEnd();

					//コントロール対象の初期化が終わったことを確認
					if (employeeCode.Trim() != "")
					{
						//対象読込-読込文字あり
						return 0;
					}
					else
					{
						//対象読込-読込文字なし
						return 999;
					}
				}
				catch (FileNotFoundException)
				{
					//対象ファイルなし
					return 4;
				}
				catch (IOException)
				{
					//別スレッドへのアクセス制限
					return 800;
				}
				finally
				{
					if (sr != null)
						sr.Close();
				}
			}
		}
		// -- Add Ed 2012.07.06 30182 R.Tachiya --

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="deleteFileName">ファイル名称</param>
		/// <param name="deleteId">プロセスID ※0:従業員コードファイル</param>
		/// <returns>0:正常終了</returns>
		/// <remarks>
		/// Note       : 制御ファイルの削除を行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static int Deleter(string deleteFileName, int deleteId)
		{
			string strId = deleteId.ToString();
			string fileName = deleteFileName + "_";

            lock (ControlFileStream._filelock)
			{
                File.Delete(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId);
			}

			return 0;
		}

		// -- Add St 2012.07.06 30182 R.Tachiya --
		/// <summary>
		/// 従業員コードファイル削除処理
		/// </summary>
		/// <param name="deleteFileName">ファイル名称</param>
		/// <remarks>
		/// Note       : 従業員コードファイルの削除を行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.07.06<br />
		/// </remarks>
		public static void EmployeeDeleter(string deleteFileName)
		{
			//Idが0の場合は従業員コードファイルとなる
			ControlFileStream.Deleter(deleteFileName, 0);
			return;
		}
		// -- Add Ed 2012.07.06 30182 R.Tachiya --

		/// <summary>
		/// 確認処理
		/// </summary>
		/// <param name="checkFileName">ファイル名称</param>
		/// <param name="checkId">プロセスID</param>
		/// <returns>ファイル存在:ture、ファイル無し・異常:false</returns>
		/// <remarks>
		/// Note       : 制御ファイルの確認を行います。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static bool Checker(string checkFileName, int checkId)
		{
			string strId = checkId.ToString();
			string fileName = checkFileName + "_";

			lock (ControlFileStream._filelock)
			{
                if (File.Exists(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		#endregion

		#region // -- Public Enum --

		/// <summary>
		/// ファイル制御文字列
		/// </summary>
		public enum ControlText
		{
			ProcessStart = 0,	//プロセス開始
			InitializeEnd = 1,	//初期化終了
			ReViewForm = 2,		//復活指示
			SettingEnd = 3,		//（復活）設定終了
            // --- ADD 2012/11/15 T.Nishi ---------->>>>>
            ProcessEnd = 4,		//（復活）設定終了
            // --- ADD 2012/11/15 T.Nishi ----------<<<<<
            // --- ADD 2013/05/23 ① T.Miyamoto ---------->>>>>
            Reboot = 5,		    //再起動
            // --- ADD 2013/05/23 ① T.Miyamoto ----------<<<<<
		}

		#endregion
	}
}

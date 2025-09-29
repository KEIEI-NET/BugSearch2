using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

using DataDynamics.ActiveReports;

// ADD 2024/08/01 田村顕成 帳票IDログ出力対応 ----->>>>>
using Broadleaf.Library.Diagnostics;
using System.Diagnostics;
using Broadleaf.Application.Controller;
// ADD 2024/08/01 田村顕成 帳票IDログ出力対応 -----<<<<<

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 自由帳票共通制御クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票全体で使用する共通処理クラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.08.21</br>
	/// <br>Note		: 帳票IDログ出力対応</br>
	/// <br>Programmer	: 32427 田村顕成</br>
	/// <br>UpdateDate	: 2024.08.01</br>
	/// </remarks>
	public class FrePrtSettingController
	{

        // ADD 2024/08/01 田村顕成 帳票IDログ出力対応 ----->>>>>
        private static OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
        // ADD 2024/08/01 田村顕成 帳票IDログ出力対応 -----<<<<<

		#region PublicMethod(static)
		/// <summary>
		/// 印字位置設定データ暗号化処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票印字位置設定マスタの印字位置設定データを暗号化します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static void EncryptPrintPosClassData(FrePrtPSet frePrtPSet)
		{
			if (frePrtPSet != null)
			{
				string[] key = CreateEncryptKey(frePrtPSet);
				if (frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0)
					frePrtPSet.PrintPosClassData = UserSettingController.EncryptionBytes(frePrtPSet.PrintPosClassData, key);
			}
		}
		/// <summary>
		/// 印字位置設定データ復号化処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票印字位置設定マスタの印字位置設定データを復号化します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static void DecryptPrintPosClassData(FrePrtPSet frePrtPSet)
		{
			if (frePrtPSet != null)
			{
				string[] key = CreateEncryptKey(frePrtPSet);
				if (frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0)
					frePrtPSet.PrintPosClassData = UserSettingController.DecryptionBytes(frePrtPSet.PrintPosClassData, key);
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
        /// <summary>
        /// 印字位置設定データ暗号化処理
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <remarks>
        /// <br>Note         : 自由帳票印字位置設定マスタの印字位置設定データを暗号化します。</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        public static void EncryptPrintPosClassData( FrePrtPSetWork frePrtPSet )
        {
            if ( frePrtPSet != null )
            {
                string[] key = CreateEncryptKey( frePrtPSet );
                if ( frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0 )
                    frePrtPSet.PrintPosClassData = UserSettingController.EncryptionBytes( frePrtPSet.PrintPosClassData, key );
            }
        }
        /// <summary>
        /// 印字位置設定データ復号化処理
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <remarks>
        /// <br>Note         : 自由帳票印字位置設定マスタの印字位置設定データを復号化します。</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2008.06.04</br>
        /// <br>Note         : 帳票IDログ出力対応</br>
        /// <br>Programmer   : 32427 田村顕成</br>
        /// <br>UpdateDate   : 2024.08.01</br>
        /// </remarks>
        public static void DecryptPrintPosClassData( FrePrtPSetWork frePrtPSet )
        {
            // ADD 2024/08/01 田村顕成 帳票IDログ出力対応 ----->>>>>
            // 帳票IDを操作履歴ログに出力する（印刷に使用される帳票IDを出力するためだが、PKG対応としたいため帳票データが復号されるこのメソッドにて代用する）
            try
            {
                string msg = string.Format("{0}:{1}", frePrtPSet.FreePrtPprSpPrpseCd, frePrtPSet.OutputFormFileName);
                WriteOperationLog(frePrtPSet, 1, msg); // 1:帳票出力
            }
            catch
            {
                //処理を継続させるため、無視する
            }
            // ADD 2024/08/01 田村顕成 帳票IDログ出力対応 -----<<<<<

            if (frePrtPSet != null)
            {
                string[] key = CreateEncryptKey( frePrtPSet );
                if ( frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0 )
                    frePrtPSet.PrintPosClassData = UserSettingController.DecryptionBytes( frePrtPSet.PrintPosClassData, key );
            }
        }
        
        // ADD 2024/08/01 田村顕成 帳票IDログ出力対応 ----->>>>>
        /// <summary>
        /// 操作履歴ログ出力
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="opecode">オペレーションコード</param>
        /// <param name="msg">出力メッセージ</param>
        /// <remarks>
        /// <br>Note         : 帳票IDログ出力対応</br>
        /// <br>Programmer   : 32427 田村顕成</br>
        /// <br>Date         : 2024.08.01</br>
        /// </remarks>
         private static void WriteOperationLog(FrePrtPSetWork frePrtPSet, int opecode, string msg)
        {
            //伝票印刷種別が請求書(合計：50,明細：60,伝票合計：70)、領収書(80)の場合にログ出力する
            if (frePrtPSet.FreePrtPprSpPrpseCd == 50 || frePrtPSet.FreePrtPprSpPrpseCd == 60 || frePrtPSet.FreePrtPprSpPrpseCd == 70 || frePrtPSet.FreePrtPprSpPrpseCd == 80)
            {
                operationHistoryLog.WriteOperationLog(null, DateTime.Now, (LogDataKind)0,　//LogDataKind 0:操作履歴ログ
                    "SFANL08132CI", "自由帳票復号処理", "", opecode, (int)0, msg, string.Empty); //
            }
        }
        // ADD 2024/08/01 田村顕成 帳票IDログ出力対応 -----<<<<<
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD

		/// <summary>
		/// 端数処理（四捨五入）
		/// </summary>
		/// <param name="dValue">値</param>
		/// <param name="iDigits">最小小数桁</param>
		/// <returns>処理結果</returns>
		/// <remarks>
		/// <br>Note		: 指定桁数になるように端数処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static double ToHalfAdjust(double dValue, int iDigits)
		{
			double dCoef = Math.Pow(10, iDigits);

			if (dValue > 0)
				return Math.Floor((dValue * dCoef) + 0.5) / dCoef;
			else
				return Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
		}

		/// <summary>
		/// ARControlタグ情報取得処理
		/// </summary>
		/// <param name="prtItemSet">印字項目設定</param>
		/// <returns>Tag情報</returns>
		/// <remarks>
		/// <br>Note		: ActiveReportオブジェクトのTag情報を印字項目設定より取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static string GetARControlTagInfo(PrtItemSetWork prtItemSet)
		{
			return string.Format("{0},{1},{2},{3},{4}"
				, prtItemSet.FreePrtPaperItemCd
				, prtItemSet.PrintPageCtrlDivCd
				, prtItemSet.GroupSuppressCd
				, prtItemSet.DtlColorChangeCd
				, prtItemSet.HeightAdjustDivCd);
		}

		/// <summary>
		/// 印字項目設定取得処理
		/// </summary>
		/// <param name="aRControl">ActiveReportオブジェクト</param>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <returns>印字項目設定マスタ</returns>
		/// <remarks>
		/// <br>Note		: ActiveReportオブジェクトのTag情報をKeyに印字項目設定を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static PrtItemSetWork GetPrtItemSet(ARControl aRControl, List<PrtItemSetWork> prtItemSetList)
		{
			PrtItemSetWork prtItemSetWork = null;

			if (aRControl != null && aRControl.Tag != null && prtItemSetList != null && prtItemSetList.Count > 0)
			{
				string[] keyArray = aRControl.Tag.ToString().Split(',');

				if (keyArray.Length > 0)
				{
					// 自由帳票項目コード
					int freePrtPaperItemCd = TStrConv.StrToIntDef(keyArray[0], 0);
					// 印字項目設定LISTよりKeyが一致するデータを取得
					prtItemSetWork = prtItemSetList.Find(
						delegate(PrtItemSetWork wkPrtItemSetWork)
						{
							if (wkPrtItemSetWork.FreePrtPaperItemCd == freePrtPaperItemCd)
								return true;
							else
								return false;
						}
					);

					if (prtItemSetWork != null)
					{
						if (keyArray.Length > 1)
							prtItemSetWork.PrintPageCtrlDivCd = TStrConv.StrToIntDef(keyArray[1], 0);
						if (keyArray.Length > 2)
							prtItemSetWork.GroupSuppressCd = TStrConv.StrToIntDef(keyArray[2], 0);
						if (keyArray.Length > 3)
							prtItemSetWork.DtlColorChangeCd = TStrConv.StrToIntDef(keyArray[3], 0);
						if (keyArray.Length > 4)
							prtItemSetWork.HeightAdjustDivCd = TStrConv.StrToIntDef(keyArray[4], 0);
					}
				}
			}

			return prtItemSetWork;
		}

		/// <summary>
		/// データフィールドデータ作成処理
		/// </summary>
		/// <param name="prtItemSetWork">印字項目設定マスタ</param>
		/// <returns>データフィールドデータ</returns>
		/// <remarks>
		/// <br>Note		: 印字項目設定マスタを元にデータフィールドに</br>
		/// <br>			: 設定するデータを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public static string CreateDataField(PrtItemSetWork prtItemSetWork)
		{
			if (prtItemSetWork == null) return string.Empty;

			if (!string.IsNullOrEmpty(prtItemSetWork.FileNm) &&
				!string.IsNullOrEmpty(prtItemSetWork.DDName))
				return prtItemSetWork.FileNm + "." + prtItemSetWork.DDName;
			else if (!string.IsNullOrEmpty(prtItemSetWork.FileNm))
				return prtItemSetWork.FileNm;
			else if (!string.IsNullOrEmpty(prtItemSetWork.DDName))
				return prtItemSetWork.DDName;
			else
				return string.Empty;
		}

		/// <summary>
		/// 文字列幅取得処理
		/// </summary>
		/// <param name="control">対象コントロール</param>
		/// <returns>文字列の幅</returns>
		/// <remarks>
		/// <br>Note		: ControlのTextのサイズを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		public static int GetStringWidth(Control control)
		{
			int textWidth = 0;

			Graphics graphics = null;
			try
			{
				graphics = control.CreateGraphics();
				SizeF sizeF = graphics.MeasureString(control.Text, control.Font);

				textWidth = (int)sizeF.Width;
			}
			finally
			{
				graphics.Dispose();
			}

			return textWidth;
		}
		#endregion

		#region InternalMethod(static)
		/// <summary>
		/// フォントサイズ調整処理
		/// </summary>
		/// <param name="control">対象コントロール</param>
		/// <param name="baseFontSize">基準フォントサイズ</param>
		/// <remarks>
		/// <br>Note		: ControlのTextが一行に収まるようにFontサイズを調整します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		internal static void AdjustControlFontSize(Control control, float baseFontSize)
		{
			control.Font = new Font(control.Font.Name, baseFontSize, control.Font.Style);
			control.Font = PrintCommonLibrary.AdjustFontForHorizontal(control.Font, control.Width, control.Text);
		}
		#endregion

		#region PrivateMethod(static)
		/// <summary>
		/// 暗号化キー作成処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票印字位置設定マスタの印字位置設定データ用暗号化キーを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		private static string[] CreateEncryptKey(FrePrtPSet frePrtPSet)
		{
			if (frePrtPSet != null)
				return new string[] { frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo, "0ecb06d9-4f46-4274-a4cb-d358f0357482" };
			else
				throw new Exception("自由帳票印字位置設定マスタが存在しません。");
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
        /// <summary>
        /// 暗号化キー作成処理
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <remarks>
        /// <br>Note         : 自由帳票印字位置設定マスタの印字位置設定データ用暗号化キーを作成します。</br>
        /// <br>               ( FrePrtPSet用メソッドと同じGUIDをセットする必要が有ります。 )</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        private static string[] CreateEncryptKey( FrePrtPSetWork frePrtPSet )
        {
            if ( frePrtPSet != null )
                return new string[] { frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo, "0ecb06d9-4f46-4274-a4cb-d358f0357482" };
            else
                throw new Exception( "自由帳票印字位置設定マスタが存在しません。" );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD
		#endregion
	}
}

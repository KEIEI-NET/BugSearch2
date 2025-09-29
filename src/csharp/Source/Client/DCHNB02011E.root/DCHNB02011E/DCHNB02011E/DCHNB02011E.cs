using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.UIData
{
	public class DCHNB02011EA : IExtrProc
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public DCHNB02011EA()
		{
        }

		public DCHNB02011EA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as ExtrInfo_DCHNB02013E;
            this._saleConfListAcs = new SaleConfAcs();

            this._lastTimeExtraInfo = new ExtrInfo_DCHNB02013E();

			//帳票タイプ区分を取得
			this._extraInfo.PrintDiv = this._printInfo.frycd;
			//帳票タイプ区分名称を取得
			this._extraInfo.PrintDivName = this._printInfo.prpnm;

	     }
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		private SFCMN06002C _printInfo = null;

        private SaleConfAcs _saleConfListAcs = null;        // 受注貸出確認表アクセスクラス
        private ExtrInfo_DCHNB02013E _extraInfo = null;     // 抽出条件クラス

        private ExtrInfo_DCHNB02013E _lastTimeExtraInfo = null;    // 前回抽出条件クラス

        private string _PGID = "DCHNB02011EA";

		#endregion
		
		// ===============================================================================
		// IExtrProc 実装部
		// ===============================================================================
		#region IExtrProc メンバ

		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value; }
		}

		/// <summary>
		/// 抽出処理
		/// </summary>
		public int ExtrPrintData()
		{
			int status = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;

			// 抽出中画面インスタンス作成
			Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
			pd.Title = "抽出中";
			pd.Message = "現在、データ抽出中です。";

			try
			{
				pd.Show();
				status = this.ExtraProc();
			}
			finally
			{
				pd.Close();
				this._printInfo.status = status;
			}

			return status;
		}
		#endregion

		// ===============================================================================
		// 内部使用関数
		// ===============================================================================
		#region private methods
		/// <summary>
		/// 抽出メイン処理
		/// </summary>
        /// <remarks>
        /// <br>前回と条件が変わっているときはリモートからデータを取得する</br>
        /// </remarks>
		private int ExtraProc()
		{
            int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            string message = "";

			try
			{
				if (this._lastTimeExtraInfo.Equals(this._extraInfo))
				{
					// 前回と同じ条件のとき
					status = this._saleConfListAcs.Search(this._extraInfo, out message, 1);
				}
				else
				{
					// 前回と違う条件のとき、リモートから再取得
					status = this._saleConfListAcs.Search(this._extraInfo, out message, 0);
				}

				if (status == 0)
				{
					this._printInfo.rdData = this._saleConfListAcs._printDataSet;

					this._lastTimeExtraInfo = this._extraInfo.Clone();
				}
			}
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
					MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                }
            }
            return result;
		}


		#endregion


		/// <summary>
		/// エラーメッセージ表示
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">エラーメッセージ</param>
		/// <param name="iSt">エラーステータス</param>
		/// <param name="iButton">表示ボタン</param>
		/// <param name="iDefButton">初期フォーカスボタン</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : エラーメッセージを表示します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.25</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
            // 2008.08.02 30413 犬飼 出荷→貸出に変更 >>>>>>START
            //return TMsgDisp.Show(iLevel, "受注出荷確認表抽出処理", iMsg, iSt, iButton, iDefButton);
            return TMsgDisp.Show(iLevel, "受注貸出確認表抽出処理", iMsg, iSt, iButton, iDefButton);
            // 2008.08.02 30413 犬飼 出荷→貸出に変更 <<<<<<END
        }
	}
}

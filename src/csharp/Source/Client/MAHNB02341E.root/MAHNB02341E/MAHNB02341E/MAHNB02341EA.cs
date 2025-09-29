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
    /// <summary>
    /// 売上確認表 条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上確認表の条件クラスです</br>
    /// <br>Programer  : 30413 犬飼</br>
    /// <br>Date       : 2008.07.04</br>
    /// </remarks>
    public class MAHNB02341EA : IExtrProc
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
        /// <summary>
        /// 売上確認表 条件クラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクター</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2008.07.04</br>
        /// </remarks>
        public MAHNB02341EA()
		{
        }

        /// <summary>
        /// 売上確認表 条件クラス静的コンストラクター
        /// </summary>
        /// <param name="printInfo">印刷情報</param>
        /// <remarks>
        /// <br>Note       : コンストラクター</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2008.07.04</br>
        /// </remarks>
        public MAHNB02341EA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C; 
            this._extraInfo = this._printInfo.jyoken as ExtrInfo_MAHNB02347E;

            // ↓ 2007.11.08 Keigo Yata Add //////////////////////////////
            // 帳票タイプの識別を取得
            this._extraInfo.PrintDiv = this._printInfo.frycd;
            // 帳票タイプの識別を名称取得
            this._extraInfo.PrintDivName = this._printInfo.prpnm;
            // ↑ 2007.11.08 Keigo Yata Add //////////////////////////////

            this._saleConfListAcs = new SaleConfAcs();
        }
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		private SFCMN06002C _printInfo = null;

        private SaleConfAcs _saleConfListAcs = null;        // 売上確認表アクセスクラス
        private ExtrInfo_MAHNB02347E _extraInfo = null;     // 抽出条件クラス

        private string _PGID = "MAHNB02341EA";

		#endregion
		
		// ===============================================================================
		// IExtrProc 実装部
		// ===============================================================================
		#region IExtrProc メンバ

        /// <summary>印刷情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note       : 印刷情報プロパティ</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2008.07.04</br>
        /// </remarks>
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
		private int ExtraProc()
		{
            int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            string message = "";

			try
            {
                
                // ↓ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////
                // 印刷帳票により取得データを変更する
                switch (this._extraInfo.PrintDiv)
                {

                    case (int)ExtrInfo_MAHNB02347E.PrintDivState.Slipform:              // 伝票形式
                        status = this._saleConfListAcs.SearchSlipform(this._extraInfo, out message);
                        break;
                    case (int)ExtrInfo_MAHNB02347E.PrintDivState.Detailsform:	        // 明細形式
                        status = this._saleConfListAcs.SearchDetailform(this._extraInfo, out message);
                        break;
                    // 2008.07.04 30413 犬飼 詳細形式は不使用なのでコメント化 >>>>>>START
                    //case (int)ExtrInfo_MAHNB02347E.PrintDivState.Detailedform:	        // 詳細形式
                    //    status = this._saleConfListAcs.SearchDetailform(this._extraInfo, out message);
                    //    break;
                    // 2008.07.04 30413 犬飼 詳細形式は不使用なのでコメント化 <<<<<<END
                }
                // ↑ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////

                // ↓ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////
                //status = this._saleConfListAcs.Search(this._extraInfo, out message, 1);
                // ↑ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////

                if (status == 0)
                {
                    this._printInfo.rdData = this._saleConfListAcs._printDataSet;
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
			return TMsgDisp.Show(iLevel, "売上確認表抽出処理", iMsg, iSt, iButton, iDefButton);
		}
	}
}

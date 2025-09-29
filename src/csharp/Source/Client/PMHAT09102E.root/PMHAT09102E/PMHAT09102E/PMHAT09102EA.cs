//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理抽出クラスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Data;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 発注点設定処理抽出クラスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定処理UIフォームクラス</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHAT09102EA : IExtrProc
    {
        #region [private フィールド]
        private SFCMN06002C _printInfo = null;                  // 印刷情報クラス
        private OrderPointStSimulationAcs _orderPointStSimulationAcs = null;    // 発注点設定処理アクセスクラス
        #endregion

        #region [private const フィールド]
        /// <summary>プログラムID (アセンブリ名)</summary>
        private const string ct_PGID = "PMHAT09102E";
        #endregion

        #region [コンストラクタ]
		/// <summary>
		/// 発注点設定処理抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注点設定処理UIクラス</br>
		/// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
		/// <br></br>
		/// </remarks>
        public PMHAT09102EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._orderPointStSimulationAcs = new OrderPointStSimulationAcs();
        }
        #endregion

        #region ■ IExtrProc メンバ
		#region ◆ Public Property
		/// <summary>
		/// 印刷情報クラスプロパティ
		/// </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
		}
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 抽出処理
		/// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";

            try
            {
                form.Show();			// ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
		}
		#endregion
		#endregion ◆ Public Method
		#endregion ■ IExtrProc メンバ

		#region ■ Private Method
		#region ◆ 抽出メイン処理
		/// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                ExtrInfo_OrderPointStSimulationWorkTbl paramWork = this._printInfo.jyoken as ExtrInfo_OrderPointStSimulationWorkTbl;
                // 発注点設定処理データ取得
                status = this._orderPointStSimulationAcs.Search(paramWork, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
					// 印刷データ取得
                    this._printInfo.rdData = this._orderPointStSimulationAcs.DataSet;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
							// ステータスが以上のときはメッセージを表示
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
            }
            return status;
		}
		#endregion ◆ 抽出メイン処理

		#region ◆ エラーメッセージ表示
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}

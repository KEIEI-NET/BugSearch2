using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 得意先元帳抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先元帳抽出クラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br>Programmer : 30009 渋谷 大輔</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br>Note       : PM.NS用に修正</br>
    /// <br>Note       : ※DC→PMで変更が必要な部分のみ修正しました。※</br>
    /// <br>Note       : ※PMで不要な処理があっても問題がなければそのままにしてあります※</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB02194EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
        /// 得意先元帳抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先元帳UIクラス</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.12</br>
		/// <br></br>
		/// </remarks>
        public PMHNB02194EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as LedgerCmnCndtn;
            this._csLedgerDmdAcs = new CsLedgerDmdAcs();
        }
        #endregion ■ Constructor

        #region ■ private member

        private SFCMN06002C _printInfo = null;			       // 印刷情報クラス
        private CsLedgerDmdAcs _csLedgerDmdAcs = null;         // 得意先元帳照会アクセスクラス
        private LedgerCmnCndtn _extraInfo = null;	           // 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMHNB02194E";
        #endregion ■ private const

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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.12</br>
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
                form.Show();			    // ダイアログ表示
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.12</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 出力区分(請求残・売掛残)
                int mode = this._extraInfo.ListDivCode;
                
   				status = this._csLedgerDmdAcs.Read(
				    mode, 
                    this._extraInfo.EnterpriseCode,
                    0,
                    this._extraInfo.StartCustomerCode,
                    this._extraInfo.EndCustomerCode,
                    this._extraInfo.StartTargetYearMonth,
                    this._extraInfo.EndTargetYearMonth,
                    this._extraInfo.AddupSecCodeList[0].ToString(),
                    this._extraInfo.AddupSecCodeList,
					true,
                    out errMsg,
                    (int)this._extraInfo.OutMoneyDiv);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // 印刷データ取得
                    this._printInfo.rdData = this._csLedgerDmdAcs.CustDmdPrcDataView;
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
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}

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
    /// 仕入先元帳抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先元帳抽出クラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>Update Note: 2014/02/26 田建委</br>
    /// <br>           : Redmine#42188 出力金額区分追加</br>
    /// <br></br>
    /// </remarks>
    public class PMKOU02031EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
        /// 仕入先元帳抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入先元帳UIクラス</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// <br></br>
		/// </remarks>
        public PMKOU02031EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as LedgerCmnCndtn;
            this._supplierLedgerAcs = new SupplierLedgerAcs();
        }
        #endregion ■ Constructor

        #region ■ private member

        private SFCMN06002C _printInfo = null;			       // 印刷情報クラス
        private SupplierLedgerAcs _supplierLedgerAcs = null;   // 仕入先元帳照会アクセスクラス
        private LedgerCmnCndtn _extraInfo = null;	           // 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMKOU02031E";
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
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 出力区分(0:支払,1:買掛)
                int mode = this._extraInfo.ListDivCode;
                
                // 出力金額区分
                int outMoneyDiv = (int)this._extraInfo.OutMoneyDiv; // ADD 2014/02/26 田建委 Redmine#42188
                
   				status = this._supplierLedgerAcs.Read(
				    mode,
                    this._printInfo.frycd,
                    this._extraInfo.EnterpriseCode,
                    0, 
                    this._extraInfo.StartCustomerCode,
                    this._extraInfo.EndCustomerCode,
                    this._extraInfo.StartTargetYearMonth,
                    this._extraInfo.EndTargetYearMonth,
                    this._extraInfo.AddupSecCodeList[0].ToString(),
                    this._extraInfo.AddupSecCodeList,
					true,
                    outMoneyDiv, // ADD 2014/02/26 田建委 Redmine#42188
                    out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // 印刷データ取得
                    this._printInfo.rdData = this._supplierLedgerAcs.SuplierPayDataView;
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
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}

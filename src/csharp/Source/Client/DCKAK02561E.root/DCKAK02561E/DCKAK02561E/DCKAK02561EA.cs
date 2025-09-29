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
    /// 支払残高元帳抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払残高元帳抽出クラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br>Update Note: 2008/12/10 30414 忍 幸史 Partsman用に変更</br>
    /// </remarks>
    public class DCKAK02561EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
        /// 支払残高元帳抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払残高元帳UIクラス</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
		/// <br></br>
		/// </remarks>
        public DCKAK02561EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as ExtrInfo_PaymentBalance;

            /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
			this._extraInfo.PrintDiv = this._printInfo.frycd;
			this._extraInfo.PrintDivName = this._printInfo.prpnm;
               --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
            this._paymentBalanceAcs = new PaymentBalanceAcs();
        }
        #endregion ■ Constructor

        #region ■ private member

        private SFCMN06002C _printInfo = null;			       // 印刷情報クラス
        private PaymentBalanceAcs _paymentBalanceAcs = null;   // 支払残高元帳アクセスクラス
        private ExtrInfo_PaymentBalance _extraInfo = null;	   // 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "DCKAK02561E";
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
        /// <br>Date       : 2007.10.03</br>
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
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._paymentBalanceAcs.SearchPaymentBalance(this._extraInfo, out errMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                    //// 印刷データ取得
                    //this._printInfo.rdData = this._paymentBalanceAcs.PayBalanceDs;

                    // フィルター文字列
                    string strFilter = "";
                    // ソート文字列を取得
                    string strSort = MakeSortingOrderString();

                    // 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
                    DataView dv = new DataView(this._paymentBalanceAcs.PayBalanceDs.Tables[DCKAK02564EA.Col_Tbl_PaymentBalance], strFilter, strSort, DataViewRowState.CurrentRows);
                    if (dv.Count > 0)
                    {
                        // データをセット
                        this._printInfo.rdData = dv;
                    }
                    // 該当データ無し
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
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

        // --- ADD 2008/12/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ソート文字列作成処理
        /// </summary>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       : ソート文字列を作成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/12/10</br>
        /// </remarks>
        public static string MakeSortingOrderString()
        {
            string sortStr = "";

            // 拠点
            MakeSortQuery(ref sortStr, DCKAK02564EA.Col_AddUpSecCode, 0);

            // 支払先
            MakeSortQuery(ref sortStr, DCKAK02564EA.Col_PayeeCode, 0);

            // 支払日付
            MakeSortQuery(ref sortStr, DCKAK02564EA.Col_AddUpDate, 0);

            return sortStr;
        }

        /// <summary>
        /// ソート用文字列作成処理
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="ascDescDiv">昇順・降順区分[0:昇順, 1:降順]</param>
        /// <param name="strQuery">ソート用文字列</param>
        /// <remarks>
        /// <br>Note       : ソート用の文字列の作成を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/12/10</br>
        /// </remarks>
        private static void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
        {
            if (strQuery == null)
            {
                strQuery = "";
            }

            if (strQuery == "")
            {
                strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
            else
            {
                strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
        }
        // --- ADD 2008/12/10 ---------------------------------------------------------------------<<<<<

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
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}

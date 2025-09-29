//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリスト条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
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
    /// 売価原価アンマッチリスト条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価原価アンマッチリスト条件クラス</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB02201EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
        /// 売価原価アンマッチリスト抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売価原価アンマッチリストUIクラス</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// <br></br>
		/// </remarks>
        public PMHNB02201EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as RateUnMatchCndtn;

            this._extraInfo.PrintDiv = this._printInfo.frycd;
            this._extraInfo.PrintDivName = this._printInfo.prpnm;
            this._rateUnMatchAcs = new RateUnMatchAcs();
        }
        #endregion ■ Constructor

        #region ■ private member

        private SFCMN06002C _printInfo = null;			        // 印刷情報クラス
        private RateUnMatchAcs _rateUnMatchAcs = null;	        // 売価原価アンマッチリストアクセスクラス
        private RateUnMatchCndtn _extraInfo = null;	            // 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMHNB02201E";
        private const string ct_PGNM = "売価原価アンマッチリスト";
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
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
                // ダイアログ表示
                form.Show();

                // 抽出処理実行
                status = this.ExtraProc();

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    DataView dv = new DataView(this._rateUnMatchAcs.RateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch], "", "", DataViewRowState.CurrentRows);

                    // 印刷データ取得
                    this._printInfo.rdData = dv;

                    if (dv.Table.Rows.Count == 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                }
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
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;
            // 検索処理
            int status = this._rateUnMatchAcs.Search(this._extraInfo, out errMsg);
            // 戻り値を設定。異常の場合はメッセージを表示
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        // ステータスが以上のときはメッセージを表示
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                    MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;
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
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
    }
}

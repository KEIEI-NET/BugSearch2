using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入分析表抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入分析表抽出クラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKOU02021EA
    {
        #region ■ コンストラクタ
        /// <summary>
        /// 仕入分析表抽出クラスコンストラクタ
        /// </summary>
        public PMKOU02021EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._slipHistAnalyzeAcs = new SlipHistAnalyzeAcs();
            this._slipHistAnalyzeParam = this._printInfo.jyoken as SlipHistAnalyzeParam;
        }
        #endregion

        #region ■ private変数
        private SFCMN06002C _printInfo = null;			           // 印刷情報クラス
        private SlipHistAnalyzeAcs _slipHistAnalyzeAcs = null;	   // 仕入分析表アクセスクラス
        private SlipHistAnalyzeParam _slipHistAnalyzeParam = null; // 仕入分析表抽出条件クラス
        #endregion

        #region ■ private定数
        private const string ct_PGID = "PMKOU02021E";
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
        #endregion

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.10</br>
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
        #endregion
        #endregion

        #region ■ Privateメソッド
        #region ◆ 抽出メイン処理
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._slipHistAnalyzeAcs.SearchMain(this._slipHistAnalyzeParam, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 印刷データ取得
                    this._printInfo.rdData = this._slipHistAnalyzeAcs.SlipHistAnalyzeDataView;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
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
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
            }
            return status;
        }
        #endregion

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
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion

    }
}

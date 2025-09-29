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
    /// 売上月報年報抽出抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月報年報UIフォームクラス</br>
    /// <br>Programmer : 980035 金沢 貞義</br>
    /// <br>Date       : 2007.12.07</br>
    /// <br></br>
    /// </remarks>
    public class DCHNB02071EA : IExtrProc
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 売上月報年報抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上月報年報UIクラス</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// <br></br>
        /// </remarks>
        public DCHNB02071EA()
        {
        }

        /// <summary>
        /// 売上月報年報抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上月報年報UIクラス</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// <br></br>
        /// </remarks>
        public DCHNB02071EA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as SalesMonthYearReportCndtn;
            this._salesTableListAcs = new SalesTableAcs();
        }
        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;

        private SalesTableAcs _salesTableListAcs = null;        // 売上月報年報アクセスクラス
        private SalesMonthYearReportCndtn _extraInfo = null;    // 抽出条件クラス

        private string _PGID = "DCHNB02071EA";

        #endregion

        // ===============================================================================
        // IExtrProc 実装部
        // ===============================================================================
        #region IExtrProc メンバ

        /// <summary> 印刷情報クラスプロパティ </summary>
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
                status = this._salesTableListAcs.Search(this._extraInfo, out message, 0);
                if (status == 0)
                {
                    this._printInfo.rdData = this._salesTableListAcs._printDataSet;
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
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "売上月報年報抽出処理", iMsg, iSt, iButton, iDefButton);
        }
    }
}

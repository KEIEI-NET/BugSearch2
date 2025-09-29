//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表 データクラス
// プログラム概要   : 入荷差異表 データクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00   作成担当 : 譚洪
// 作 成 日  K2019/08/14   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 入荷差異表 データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 入荷差異表UIフォームクラス</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : K2019/08/14</br>
    /// </remarks>
    public class PMKOU02351EA : IExtrProc
    {
        #region ■ Constructor
        /// <summary>
        /// 入荷差異表一覧抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 入荷差異表一覧UIクラス</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/08/14</br>
        /// </remarks>
        public PMKOU02351EA(object printInfo)
        {
            // 印刷情報
            this.PrintIf = printInfo as SFCMN06002C;
            this.arrGoodsDiffAccess = new ArrGoodsDiffAcs();
            this.ArrGoodsDiffCndWork = this.PrintIf.jyoken as ArrGoodsDiffCndtnWork;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C PrintIf = null;                            // 印刷情報クラス
        private ArrGoodsDiffAcs arrGoodsDiffAccess = null;              // 入荷差異表アクセスクラス
        private ArrGoodsDiffCndtnWork ArrGoodsDiffCndWork = null;// 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        // クラスID
        private const string PgId = "PMKOU02351E";
        #endregion ■ private const

        #region ■ IExtrProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// 印刷情報クラスプロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
           get { return this.PrintIf; }
           set { this.PrintIf = value; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public int ExtrPrintData()
        {
           int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
           // 抽出中画面部品のインスタンスを作成
           Broadleaf.Windows.Forms.SFCMN00299CA form = new SFCMN00299CA();
           // 表示文字を設定
           form.Title = "抽出中";
           form.Message = "現在、データを抽出中です。";

           try
           {
               form.Show();                 // ダイアログ表示
               status = this.ExtraProc();   // 抽出処理実行
           }
           finally
           {
               // ダイアログを閉じる
               form.Close();
               this.PrintIf.status = status;
           }

           return status;
       }

        #endregion ◎ 抽出処理
        #endregion ◆ Public Method
        #endregion ■ IExtrProc メンバ

        #region ■ Private Method
        #region ◆ 抽出メイン処理
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
       /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this.arrGoodsDiffAccess.SearchArrGoodsDiffProcMain(this.ArrGoodsDiffCndWork, out errMsg);
                if(status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 印刷データを設定処理
                    this.PrintIf.rdData = this.arrGoodsDiffAccess.DataSet;
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
                            // ステータスが異常のときはメッセージを表示
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PgId, errMsg, status,
                                       MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, PgId, iMsg, iSt, iButton, iDefButton);
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}

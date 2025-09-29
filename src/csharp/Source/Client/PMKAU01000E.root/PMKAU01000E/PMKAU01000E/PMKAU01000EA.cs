//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由帳票（請求書）抽出クラスクラス
// プログラム概要   : 自由帳票（請求書）抽出クラスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00  作成担当 : 陳艶丹
// 作 成 日  2022/03/07   修正内容 : 請求書発行(電子帳簿連携)新規作成
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
    /// 自由帳票（請求書）抽出クラスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 自由帳票（請求書）UIフォームクラス</br>
    /// <br>Programmer   : 陳艶丹</br>
    /// <br>Date         : 2022/03/07</br>
    /// </remarks>
    public class PMKAU01000EA : IExtrProc
    {
        #region [private フィールド]
        private SFCMN06002C _printInfo = null;      // 印刷情報クラス
        private EBooksFrePBillAcs _frePBillAcs = null;    // 自由帳票（請求書）アクセスクラス
        #endregion

        #region [private const フィールド]
        /// <summary>プログラムID (アセンブリ名)</summary>
        private const string ct_PGID = "PMKAU01000E";
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// 自由帳票（請求書）抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由帳票（請求書）UIクラス</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/07</br>
        /// <br></br>
        /// </remarks>
        public PMKAU01000EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._frePBillAcs = new EBooksFrePBillAcs();
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
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/07</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                this._printInfo.status = status;
            }

            return status;
        }
        /// <summary>
        /// 抽出キャンセル処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出キャンセル処理。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/03/07</br>
        /// </remarks>
        public void Cancel()
        {
            // アクセスクラスの抽出キャンセル処理を呼び出す
            this._frePBillAcs.CancelButtonClick(this, new EventArgs());
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IExtrProc メンバ

        #region ■ Private Method
        #region ◆ 抽出メイン処理
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 抽出のメイン処理を行います。</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // Todo:Search Method Call
                status = this._frePBillAcs.SearchMain(this._printInfo.jyoken, (DataView)this._printInfo.rdData, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 印刷データ取得
                    this._printInfo.rdData = this._frePBillAcs.PrintDataSet;
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
                            Form form = new Form();
                            form.TopMost = true;
                            // ステータスが以上のときはメッセージを表示
                            TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            form.TopMost = false;
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
        /// <br>Note         : エラーメッセージを表示します。</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult rst = TMsgDisp.Show(form, iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return rst;
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}

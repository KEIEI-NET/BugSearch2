//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表 データクラス
// プログラム概要   : 仕入先総括マスタ一覧表 データクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : FSI菅原　要
// 作 成 日  2012/09/07   修正内容 : 新規作成
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

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入先総括マスタ一覧表 データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 仕入先総括マスタ一覧表UIフォームクラス</br>
    /// <br>Programmer  : FSI菅原　要</br>
    /// <br>Date        : 2012/09/07</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class PMKAK09011EA : IExtrProc
    {
        #region ■ Constructor
        /// <summary>
        /// 仕入先総括マスタ一覧表一覧抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 仕入先総括マスタ一覧表一覧UIクラス</br>
        /// <br>Programmer  : FSI菅原　要</br>
        /// <br>Date        : 2012/09/07</br>
        /// <br></br>
        /// </remarks>
        public PMKAK09011EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._sumSuppStPrintAcs = new SumSuppStPrintAcs();
            this._sumSuppStPrintUIParaWork = this._printInfo.jyoken as SumSuppStPrintUIParaWork;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;                            // 印刷情報クラス
        private SumSuppStPrintAcs _sumSuppStPrintAcs = null;              // 仕入先総括マスタ一覧表アクセスクラス
        private SumSuppStPrintUIParaWork _sumSuppStPrintUIParaWork = null;// 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        // クラスID
        private const string ct_PGID = "PMKAK09011E";
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
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
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
               this._printInfo.status = status;
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
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._sumSuppStPrintAcs.SearchSumSuppStPrintProcMain(this._sumSuppStPrintUIParaWork, out errMsg);
                if(status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 印刷データを設定処理
                    this._printInfo.rdData = this._sumSuppStPrintAcs.DataSet;
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
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
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
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}

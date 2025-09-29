//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリスト データクラス
// プログラム概要   : 発注点設定マスタリストデータを保存する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using System.Net.NetworkInformation;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 発注点設定マスタリスト データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : なし</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class PMHAT02021EA : IExtrProc
    {
        #region ■ Private Members
        private SFCMN06002C _printInfo = null;			       // 印刷情報クラス
        private OrderSetMasListPara _extraInfo = null;		   // 抽出条件クラス
        private OrderSetMasListReportAcs _aControlAcs = null;
        #endregion

        #region ■ Private Const Members
        private const string ct_PGID = "PMHAT02021E";
        #endregion ■ private const

        #region ■ コンストラクタ
        /// <summary>
        /// 発注点設定マスタリスト 抽出クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo"></param>
        public PMHAT02021EA(object printInfo)
        {
            _printInfo = printInfo as SFCMN06002C;
            _extraInfo = _printInfo.jyoken as OrderSetMasListPara;
            _aControlAcs = new OrderSetMasListReportAcs();
        }
        #endregion

        #region ■ IExtrProc メンバ
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA form = new SFCMN00299CA();
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";

            try
            {
                form.Show();                // ダイアログ表示
                status = this.ExtraProc();  // 抽出処理実行
            }
            finally
            {
                form.Close();
                this._printInfo.status = status;
            }
            return status;
        }
        #endregion

        #region ◎ Public Members
        /// <summary>
        /// 印刷情報クラスプロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion

        #endregion

        #region ■ 抽出メイン処理
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = string.Empty;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if(!CheckOnlineStatus("PDFのデータ出力処理"))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    return status;
                }

                // データテーブルから、データを検索します
                status = this._aControlAcs.Search(this._extraInfo, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 印刷データを設定処理
                    _printInfo.rdData = this._aControlAcs.DataSet;
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
                    case (int)ConstantManagement.DB_Status.ctDB_OFFLINE:
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
            }

            return status;
        }
        #endregion

        #region ■ エラーメッセージ表示
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        #region ■ オフライン状態チェック処理
        /// <summary>
        /// オフラインチェックログ出力する処理
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: オフラインチェックログ出力する処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnlineStatus(String msg)
        {
            bool succFlg = true;

            // オフライン状態チェック									
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    "発注点設定マスタ",
                    "発注点設定マスタ" + msg + "が失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                succFlg = false;
            }

            return succFlg;
        }
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            // ローカルエリア接続状態によるオンライン判定
            if (CheckRemoteOn() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// リモート接続可能判定処理
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note		: リモート接続可能判定処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {

            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

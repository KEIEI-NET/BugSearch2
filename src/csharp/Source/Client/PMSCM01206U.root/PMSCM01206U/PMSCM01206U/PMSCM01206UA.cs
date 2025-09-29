//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 自動送受信バッチポップアップ                            //
// プログラム概要   : ポップアップ処理を行います。                            //
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : qianl                                     //
// 作 成 日  2011/08/01  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
// 管理番号  履歴 NO.1   作成担当 : gaoy                                      //
// 修 正 日  2011/08/20  修正内容 : 自動送受信処理の該当データなし時の処理変更(Redmine#23839)
//----------------------------------------------------------------------------//
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using System.Collections;
using Broadleaf.Application.UIData;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自動送受信バッチポップアップUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自動送受信バッチポップアップUIクラス。</br>
    /// <br>Programmer	: qianl</br>
    /// <br>Date		: 2007/07/21</br>
    /// </remarks>
    public partial class PMSCM01206UA : Form
    {
        #region privateMEMBER
        /// <summary>デフォルトx座標</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>デフォルトy座標</summary>
        private const int DEFAULT_Y = 100000;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>拠点コード</summary>
        private string _sectionCode;

        private const double ctFormOpacity = 0.92;
        private bool _hasErrorInfo;

        private string snd_Msg = "";

        private string rcv_Msg = "";
        /// <summary>フォームを閉じる判定フラグ</summary>
        private bool _canClose;
        /// <summary>フォームを閉じる判定フラグのアクセサ</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion

        #region <初期情報の取得>
        /// <summary>
        /// 初期情報の取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: 初期情報の取得。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        public PMSCM01206UA()
        {
            InitializeComponent();

            //企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //拠点コード取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._hasErrorInfo = false;

        }
        #endregion

        /// <summary>
        /// 表示状態を設定します。
        /// </summary>
        /// <param name="visible">表示フラグ</param>
        /// <remarks>
        /// <br>Note		:表示状態を設定します。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                Visible = true;
                TopMost = true;
                Activate();
                TopMost = false;
            }
            else
            {
                Visible = false;
            }
        }

        /// <summary>
        /// 初期化設定
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 初期化設定。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void PMSCM01206UA_Load(object sender, EventArgs e)
        {
            // 初期表示は隠し
            SetVisibleState(false);

            // 初期位置を設定（ちらつき防止の為、10000にしています）
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);


            Snd_timer.Enabled = true;
            Snd_timer.Interval = 10000;
            Snd_timer.Start();
            this.snd_Msg = "";

            Rcv_timer.Enabled = true;
            Rcv_timer.Interval = 15000;
            Rcv_timer.Start();
            this.rcv_Msg = "";

            this.sndErrMsg_Label.Text = "";

            this.Opacity=0.92;
        }

        /// <summary>
        /// 初期起動位置を設定します
        /// </summary>
        /// <remarks>
        /// <br>Note		: 初期起動位置を設定します。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void SetInitialPosition()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 終了処理。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "PM7連携自動送受信バッチ処理中です。\r\n" +
                    "終了してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.No) return;

            CanClose = true;
            Close();
        }


        /// <summary>
        /// 売上データ抽出処理(常駐バッチ起動)
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 売上データ抽出処理(常駐バッチ起動)。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void Snd_timer_Tick(object sender, EventArgs e)
        {
            Refresh();
            this.snd_Msg = "";
            Int32 outSalesTotal = 0;
            string errMsg = "";
            //売上連携全体設定マスタ検索処理
            PM7RkSetting pm7RkSetting = new PM7RkSetting();

            pm7RkSetting.EnterpriseCode = this._enterpriseCode;
            pm7RkSetting.SectionCode = this._sectionCode;

            PM7RkSettingAcs pM7RkSettingAcs = new PM7RkSettingAcs();
            int status = pM7RkSettingAcs.Read(ref pm7RkSetting);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    Snd_timer.Interval = 5 * 60 * 1000;
                    _hasErrorInfo = true;
                    return;
                }
                else
                {
                    _hasErrorInfo = true;
                    snd_Msg = "売上データ抽出処理:売上連携全体設定マスタの検索処理に失敗しました。\r\n";
                    this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;
                    this.SetVisibleState(true);
                    return;
                }
            }

            if (pm7RkSetting.SalesRkAutoCode == 0)
            {
                Snd_timer.Interval = 5 * 60 * 1000;
                _hasErrorInfo = true;
                return;
            }

            long salesRkAutoSndTime = pm7RkSetting.SalesRkAutoSndTime;
            Snd_timer.Interval = Int32.Parse(pm7RkSetting.SalesRkAutoSndTime.ToString()) * 60 * 1000;

            //テキスト格納フォルダ存在性チェック
            bool returnBl = SaveFoldCheck(pm7RkSetting.TextSaveFolder.Trim());

            if (returnBl == false)
            {
                _hasErrorInfo = true;
                snd_Msg = "売上データ抽出処理:テキスト格納フォルダが存在しません。\r\n";
                this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;
                this.SetVisibleState(true);
                return;
            }
            else
            {
                _hasErrorInfo = false;
            }

            SndAndRcvProcAcs pMSCM01201A = new SndAndRcvProcAcs();
            int stauts = pMSCM01201A.SearchAndTextout(pm7RkSetting.SalesRkAutoCode, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, pm7RkSetting.TextSaveFolder.Trim(), ref outSalesTotal, ref errMsg);


            if (stauts != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    _hasErrorInfo = true;
                    //snd_Msg = "売上データ抽出処理:対象データがありません。\r\n";         //DEL 履歴 NO.1
                    this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;

                    //this.SetVisibleState(true);                             //DEL 履歴 NO.1
                    this.SetVisibleState(false);                              //ADD 履歴 NO.1
                }
                else
                {
                    _hasErrorInfo = true;
                    snd_Msg = "売上データ抽出処理:" + errMsg + "\r\n";
                    this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg; 

                    this.SetVisibleState(true);
                }
            }

            Refresh();
        }
            

        /// <summary>
        /// マスタ取込処理(常駐バッチ起動)
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: マスタ取込処理(常駐バッチ起動)。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void Rcv_timer_Tick(object sender, EventArgs e)
        {
            Refresh();
            this.rcv_Msg = "";
            string errMsg = "";
            //売上連携全体設定マスタ検索処理
            PM7RkSetting pm7RkSetting = new PM7RkSetting();

            pm7RkSetting.EnterpriseCode = this._enterpriseCode;
            pm7RkSetting.SectionCode = this._sectionCode;

            PM7RkSettingAcs pM7RkSettingAcs = new PM7RkSettingAcs();
            int status = pM7RkSettingAcs.Read(ref pm7RkSetting);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    Rcv_timer.Interval = 5 * 60 * 1000;
                    _hasErrorInfo = true;
                    return;
                }
                else
                {
                    _hasErrorInfo = true;
                    rcv_Msg = "マスタ取込処理:売上連携全体設定マスタの検索処理に失敗しました。\r\n";
                    this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;
                    this.SetVisibleState(true);
                    return;
                }
            }

            if (pm7RkSetting.MasterRkAutoCode == 0)
            {
                Rcv_timer.Interval = 5 * 60 * 1000;
                _hasErrorInfo = true;
                return;
            }


            long masterRkAutoRcvTime = pm7RkSetting.MasterRkAutoRcvTime;
            Rcv_timer.Interval = Int32.Parse(pm7RkSetting.MasterRkAutoRcvTime.ToString()) * 60 * 1000;

            //テキスト格納フォルダ存在性チェック
            bool returnBl = SaveFoldCheck(pm7RkSetting.TextSaveFolder.Trim());

            if (returnBl == false)
            {
                _hasErrorInfo = true;
                rcv_Msg = "マスタ取込処理:テキスト格納フォルダが存在しません。\r\n";
                this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;
                this.SetVisibleState(true);
                return;
            }
            else
            {
                _hasErrorInfo = false;
            }

            SndAndRcvProcAcs pMSCM01201A = new SndAndRcvProcAcs();
            int stauts = pMSCM01201A.TimeSearchAndTextin(pm7RkSetting.MasterRkAutoCode, pm7RkSetting.TextSaveFolder.Trim(), this._enterpriseCode, ref errMsg);

            if (stauts != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    _hasErrorInfo = true;
                    //rcv_Msg = "マスタ取込処理:対象CSVファイルが存在しません。\r\n";         //DEL 履歴 NO.1
                    this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;

                    //this.SetVisibleState(true);                             //DEL 履歴 NO.1
                    this.SetVisibleState(false);                              //ADD 履歴 NO.1
                }
                else
                {
                    _hasErrorInfo = true;
                    rcv_Msg = "マスタ取込処理:" + errMsg + "\r\n";
                    this.sndErrMsg_Label.Text = snd_Msg + rcv_Msg;

                    this.SetVisibleState(true);
                }
            }

            Refresh();
        }

        /// <summary>
        /// テキスト格納フォルダ存在性チェック
        /// </summary>
        /// <param name="SaveFolder">テキスト格納フォルダ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: テキスト格納フォルダ存在性チェック。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private bool SaveFoldCheck(string SaveFolder)
        {
            bool result = false;

            //テキスト格納フォルダ存在性チェック
            if (!Directory.Exists(SaveFolder))
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		:  終了処理。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void PMSCM01206UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // 意図的な終了以外はキャンセルしてアイコン化（フォームを非表示にする）
                    e.Cancel = true; // 終了処理のキャンセル
                    this.close_Snd_Timer.Enabled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		:  終了処理。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void ultraButton_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        /// <summary>
        /// タイマー終了処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: タイマー終了処理。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private void close_Snd_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = this.Opacity - 0.02;
            }
            catch (Exception)
            {
                this.Opacity = 0.0;
            }
            finally
            {
                if (this.Opacity <= 0.0)
                {
                    this.Visible = false;

                    // 透過率を元に戻しておく
                    this.Opacity = ctFormOpacity;

                    this.close_Snd_Timer.Enabled = false;

                    this.sndErrMsg_Label.Text = "";

                    this.snd_Msg = "";
                    this.rcv_Msg = "";

                    this._hasErrorInfo = false;
                }
            }
        }
    }
}
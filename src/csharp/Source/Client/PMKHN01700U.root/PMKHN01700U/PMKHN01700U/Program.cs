//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 品番変換処理
// プログラム概要   : 品番変換処理フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 田建委
// 作 成 日  2015/04/06   修正内容 : Redmine#44209 メニュー起動制御対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 起動処理
    /// </summary>
    /// <remarks>
    /// Note       : 起動処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009/12/24<br />
    /// <br>UpdateNote : 2015/04/06 田建委 </br>
    /// <br>           : Redmine#44209 メニュー起動制御対応</br>
    /// </remarks>
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;

        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 ----->>>>>
        /// <summary> メニュー起動制御設定ファイル </summary>
        private const string XML_FILE_START = "GoodsNoChange_Config.xml";
        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 -----<<<<<

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// Note       : アプリケーションのメイン エントリ ポイントです。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009/12/24<br />
        /// <br>UpdateNote : 2015/04/06 田建委 </br>
        /// <br>           : Redmine#44209 メニュー起動制御対応</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // オンライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN01700U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        //----- DEL 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 ----->>>>>
                        //_form = new PMKHN01700UA();

                        //System.Windows.Forms.Application.Run(_form);
                        //----- DEL 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 -----<<<<<
                        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 ----->>>>>
                        /*
                        * メニューの起動可否制御
                        *    外部ファイルの利用可能日 ≦ システム日付                               => メニューの起動を許可する
                        *    外部ファイルが存在しない ＯＲ 外部ファイルの利用可能日 ＞ システム日付 => メニューの起動を許可しない
                        */
                        if (BeforeRunDateCheck())
                        {
                        _form = new PMKHN01700UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                        else
                        {
                            _form = new PMKHN01700UA(0);
                            MessageBox.Show(_form, "現在ご利用頂けません。", "情報 - ＜" + _form.Text + "＞", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _form = null;
                        }
                        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 -----<<<<<
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN01700U", msg, 0, MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMKHN01700U", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 ----->>>>>
        /// <summary>
        /// プログラマを実行する前に、日付をチェックする
        /// </summary>
        /// <returns></returns>
        public static bool BeforeRunDateCheck()
        {
            Config xmlSetting = null;
            bool checkFlag = false;
            int checkResult = 0;

            try
            {
                if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(Environment.CurrentDirectory, XML_FILE_START)))
                {
                    try
                    {
                        xmlSetting = UserSettingController.DeserializeUserSetting<Config>(System.IO.Path.Combine(Environment.CurrentDirectory, XML_FILE_START));
                    }
                    catch
                    {
                        xmlSetting = new Config();
                    }
                }

                /*
                 * メニューの起動可否制御
                 *    外部ファイルの利用可能日 ≦ システム日付                               => メニューの起動を許可する
                 *    外部ファイルが存在しない ＯＲ 外部ファイルの利用可能日 ＞ システム日付 => メニューの起動を許可しない
                 */
                if (xmlSetting != null && xmlSetting.Common != null && !string.IsNullOrEmpty(xmlSetting.Common.AvailableDate))
                {
                    string checkDate = xmlSetting.Common.AvailableDate;
                    DateTime checkDateTime = Convert.ToDateTime(checkDate);
                    checkResult = DateTime.Compare(checkDateTime, DateTime.Now);

                    if (checkResult <= 0)
                    {
                        checkFlag = true;
                    }
                }
                else
                {
                    checkFlag = false;
                }
            }
            catch
            {
                checkFlag = false;
            }

            return checkFlag;
        }
        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 -----<<<<<

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// Note       : アプリケーション終了処理です。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009/12/24<br />
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKHN01700U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN01700U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }

    //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 ----->>>>>
    /// <summary>
    /// 日付の情報
    /// </summary>
    public class CheckDate
    {
        /// <summary> チェック用日付 </summary>
        private string _availableDate;

        /// <summary>
        /// チェック用日付
        /// </summary>
        public string AvailableDate
        {
            get { return _availableDate; }
            set { _availableDate = value; }
        }
    }

    /// <summary>
    /// テーブルデータの設定
    /// </summary>
    public class Config
    {
        /// <summary> テーブル情報設定 </summary>
        private CheckDate _common;

        /// <summary>
        /// テーブル情報設定
        /// </summary>
        public CheckDate Common
        {
            get { return _common; }
            set
            {
                if (_common == null)
                {
                    _common = new CheckDate();
                }
                _common = value;
            }
        }
    }
    //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 -----<<<<<
}
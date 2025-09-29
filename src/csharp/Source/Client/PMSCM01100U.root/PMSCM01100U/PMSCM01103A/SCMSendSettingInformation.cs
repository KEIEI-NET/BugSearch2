//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/10/10  修正内容 : 新規作成：ＴＳＰ送受信処理【ＰＭ側】(SFMIT02851A)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : SCM用にアレンジ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田 誠
// 作 成 日  2011/06/01  修正内容 : ログ表示オプションの追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/03/25  修正内容 : 2013/04/10配信分 SCM障害№10493対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/09  修正内容 : SCM仕掛一覧№10641対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/30  修正内容 : SCM仕掛一覧№10707
//                                  ①回答送信リトライ制御の実行判定(福田部品企業コード)を削除
//                                  ③DB更新リトライ回数・待機時間の初期登録を追加
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common; // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 設定情報クラス
    /// </summary>
    [Serializable]
    public class SCMSendSettingInformation
    {
        /// <summary>コンフィグファイル名</summary>
        private const string CONFIG_FILE_NAME = "PMSCM01103A.config";
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
        #region <福田部品用デフォルト値>
        // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        ///// <summary>福田部品企業コード</summary>
        //private string ENTERPRISE_CODE_FUKUDA = "0101130064003200";
        // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
        /// <summary>福田部品企業 送信リトライ数</summary>
        private const int DEFAULT_SEND_RETRY = 60;
        /// <summary>福田部品企業 送信リトライの待機時間</summary>
        private const int DEFAULT_SEND_SLEEP_SEC = 5;
        /// <summary>福田部品企業 読込みリトライ数</summary>
        private const int DEFAULT_READ_RETRY = 30;
        /// <summary>福田部品企業 読込みリトライの待機時間</summary>
        private const int DEFAULT_READ_SLEEP_SEC = 3;
        /// <summary>データ未設定値</summary>
        private const int VALUE_NO_SET = -1;
        // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        /// <summary>DB更新リトライ数</summary>
        private const int DEFAULT_DB_RETRY = 5;
        /// <summary>DB更新リトライの待機時間</summary>
        private const int DEFAULT_DB_SLEEP_SEC = 5;
        // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
        #endregion
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<


        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMSendSettingInformation() { }

        #endregion // </Constructor>

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~SCMSendSettingInformation()
        {
            Save(false);
        }

        #region <送信データフォルダ>

        /// <summary>SCM送信データフォルダパス</summary>
        private string _scmDataPath;
        /// <summary>SCM送信データフォルダパスを取得または設定します。</summary>
        public string SCMDataPath
        {
            get { return _scmDataPath; }
            set { _scmDataPath = value; }
        }
        /// <summary>SCM送信データフォルダパスの初回値</summary>
        private string _initialSCMDataPath;

        #endregion // </送信データフォルダ>

        #region <保存期間>

        /// <summary>保存期間種別</summary>
        private int _savePeriodType;
        /// <summary>保存期間種別を取得または設定します。</summary>
        public int SavePeriodType
        {
            get { return _savePeriodType; }
            set { _savePeriodType = value; }
        }
        /// <summary>保存期間種別の初回値</summary>
        private int _initialSavePeriodType;

        #endregion // </保存期間>

        // ※未使用
        #region <前回処理>

        /// <summary>前回処理日</summary>
        private DateTime _lastDate = DateTime.MinValue;
        /// <summary>前回処理日を取得または設定します。</summary>
        public DateTime LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }
        /// <summary>前回処理日の初回値</summary>
        private DateTime _initialLastDate = DateTime.MinValue;

        #endregion // </前回処理>

        # region <ログ表示>
        //--- ADD 2011/06/01 ------------------------------------------>>>
        private int _logDisplay;

        /// <summary>
        /// ログ表示
        /// </summary>
        public int LogDisplay
        {
            get { return _logDisplay; }
            set { _logDisplay = value; }
        }

        private int _initialLogDisplay;

        //--- ADD 2011/06/01 ------------------------------------------<<<
        # endregion

        // --- ADD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 --------->>>>>>>>>>>>>>>>>>>>>>>>
        # region <ＤＢ更新リトライ回数>
        // --- UPD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        //private int _dbRetry;
        private int _dbRetry = VALUE_NO_SET;
        // --- UPD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
        /// <summary>
        /// ＤＢ更新リトライ回数
        /// </summary>
        public int DbRetry
        {
            get { return _dbRetry; }
            set { _dbRetry = value; }
        }
        # endregion

        # region <リトライ時の待機秒数>
        // --- UPD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        //private int _sleepSec;
        private int _sleepSec = VALUE_NO_SET;
        // --- UPD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
        /// <summary>
        /// リトライ時の待機秒数
        /// </summary>
        public int SleepSec
        {
            get { return _sleepSec; }
            set { _sleepSec = value; }
        }
        # endregion
        // --- ADD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------->>>>>
        # region <単体起動送信可能フラグ>
        private int _aloneStartSend;

        /// <summary>
        /// 単体起動送信可能フラグ
        /// </summary>
        public int AloneStartSend
        {
            get { return _aloneStartSend; }
            set { _aloneStartSend = value; }
        }
        # endregion
        // ADD 2014/04/09 SCM仕掛一覧№10641対応 -----------------------------------<<<<<

        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
        #region <送信リトライ回数>
        /// <summary>送信リトライ回数</summary>
        private int _sendRetry = VALUE_NO_SET;

        /// <summary>送信リトライ回数</summary>
        public int SendRetry
        {
            get { return _sendRetry; }
            set { _sendRetry = value; }
        }
        #endregion

        #region <送信リトライ待機時間>
        /// <summary>送信リトライ待機時間</summary>
        private int _sendSleepSec = VALUE_NO_SET;

        /// <summary>送信リトライ待機時間</summary>
        public int SendSleepSec
        {
            get { return _sendSleepSec; }
            set { _sendSleepSec = value; }
        }
        #endregion

        #region <読込みリトライ回数>
        /// <summary>読込みリトライ回数</summary>
        private int _readRetry = VALUE_NO_SET;

        /// <summary>送信リトライ回数</summary>
        public int ReadRetry
        {
            get { return _readRetry; }
            set { _readRetry = value; }
        }
        #endregion

        #region <読込みリトライ待機時間>
        /// <summary>読込みリトライ待機時間</summary>
        private int _readSleepSec = VALUE_NO_SET;

        /// <summary>読込みリトライ待機時間</summary>
        public int ReadSleepSec
        {
            get { return _readSleepSec; }
            set { _readSleepSec = value; }
        }
        #endregion
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

        /// <summary>
        /// 画面情報をコンフィグファイルから読み込みます。
        /// </summary>
        public int Load()
        {
            SCMSendSettingInformation info = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SCMSendSettingInformation));

                string filePath = CONFIG_FILE_NAME;
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    info = (SCMSendSettingInformation)serializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            if (info == null)
            {
                // 読み取りに失敗した場合は何もしない
                // ADD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------->>>>>
                // 読込失敗時、初期値設定
                SCMDataPath = SCMConfig.GetSCMDefaultLogPath("");
                _initialSCMDataPath = SCMDataPath;
                // ADD 2014/04/09 SCM仕掛一覧№10641対応 -----------------------------------<<<<<
                // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                // DB更新リトライ回数にデフォルト(5回)を設定
                DbRetry = DEFAULT_DB_RETRY;
                // DB更新リトライ時の待機秒数にデフォルト(5秒)を設定
                SleepSec = DEFAULT_DB_SLEEP_SEC;
                // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                //// 企業コードチェック
                //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                //{
                //    // 企業コードが福田部品の場合
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                    // 送信リトライ回数にデフォルト(60回)を設定
                    SendRetry = DEFAULT_SEND_RETRY;
                    // 送信リトライ時の待機秒数にデフォルト(5秒)を設定
                    SendSleepSec = DEFAULT_SEND_SLEEP_SEC;
                    // 読込みリトライ回数にデフォルト(60回)を設定
                    ReadRetry = DEFAULT_SEND_RETRY;
                    // 読込みリトライ時の待機秒数にデフォルト(5秒)を設定
                    ReadSleepSec = DEFAULT_SEND_SLEEP_SEC;
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                //}
                //else
                //{
                //    // 福田部品以外はリトライしないので0を設定
                //    SendRetry = 0;
                //    SendSleepSec = 0;
                //    ReadRetry = 0;
                //    ReadSleepSec = 0;
                //}
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

                return (int)ResultUtil.ResultCode.Error;
            }
            else
            {
                SavePeriodType = info.SavePeriodType;
                SCMDataPath = SCMConfig.GetSCMDefaultLogPath(info.SCMDataPath);
                LastDate = info.LastDate;

                _initialSCMDataPath = SCMDataPath;
                _initialSavePeriodType = info.SavePeriodType;
                _initialLastDate = info.LastDate;

                //--- ADD 2011/06/01 ------------------>>>
                LogDisplay = info.LogDisplay;
                _initialLogDisplay = info.LogDisplay;
                //--- ADD 2011/06/01 ------------------<<<

                // --- DEL 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                // saveFlag定義後に移動↓
                //// --- ADD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //DbRetry = info.DbRetry;
                //SleepSec = info.SleepSec;
                //// --- ADD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                // --- DEL 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<

                // ADD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------->>>>>
                AloneStartSend = info.AloneStartSend;
                // ADD 2014/04/09 SCM仕掛一覧№10641対応 -----------------------------------<<<<<

                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                string enterpriceCode = LoginInfoAcquisition.EnterpriseCode.Trim();
                bool saveFlag = false;
                // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                // コンフィグファイルにDB更新リトライ回数が設定されているかチェック
                if (info.DbRetry == VALUE_NO_SET)
                {
                    // 未設定の場合
                    // デフォルト(5回)を設定
                    DbRetry = DEFAULT_DB_RETRY;
                    saveFlag = true;
                }
                else
                {
                    // 設定済みの場合
                    DbRetry = info.DbRetry;
                }
                //SleepSec = info.SleepSec;
                // コンフィグファイルにDB更新リトライ時の待機秒数が設定されているかチェック
                if (info.SleepSec == VALUE_NO_SET)
                {
                    // 未設定の場合
                    // デフォルト(5秒)を設定
                    SleepSec = DEFAULT_DB_SLEEP_SEC;
                    saveFlag = true;
                }
                else
                {
                    // 設定済みの場合
                    SleepSec = info.SleepSec;
                }
                // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<

                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                //// 企業コードチェック
                //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                //{
                //    // 企業コードが福田部品以外の場合
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                    // コンフィグファイルに送信リトライ回数が設定されているかチェック
                    if (info.SendRetry == VALUE_NO_SET)
                    {
                        // 未設定の場合
                        // デフォルト(60回)を設定
                        SendRetry = DEFAULT_SEND_RETRY;
                        saveFlag = true;
                    }
                    else
                    {
                        // 設定済みの場合
                        SendRetry = info.SendRetry;
                    }

                    // コンフィグファイルに送信リトライ時の待機秒数が設定されているかチェック
                    if (info.SendSleepSec == VALUE_NO_SET)
                    {
                        // 未設定の場合
                        // デフォルト(5秒)を設定
                        SendSleepSec = DEFAULT_SEND_SLEEP_SEC;
                        saveFlag = true;
                    }
                    else
                    {
                        // 設定済みの場合
                        SendSleepSec = info.SendSleepSec;
                    }

                    // コンフィグファイルに読込みリトライ回数が設定されているかチェック
                    if (info.ReadRetry == VALUE_NO_SET)
                    {
                        // 未設定の場合
                        // デフォルト(60回)を設定
                        ReadRetry = DEFAULT_READ_RETRY;
                        saveFlag = true;
                    }
                    else
                    {
                        // 設定済みの場合
                        ReadRetry = info.ReadRetry;
                    }

                    // コンフィグファイルに読込みリトライ時の待機秒数が設定されているかチェック
                    if (info.ReadSleepSec == VALUE_NO_SET)
                    {
                        // 未設定の場合
                        // デフォルト(5秒)を設定
                        ReadSleepSec = DEFAULT_READ_SLEEP_SEC;
                        saveFlag = true;
                    }
                    else
                    {
                        // 設定済みの場合
                        ReadSleepSec = info.ReadSleepSec;
                    }
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                //}
                //else
                //{
                //    // 企業コードが福田部品以外の場合
                //    // コンフィグファイルに送信リトライ回数が設定されているかチェック
                //    if (info.SendRetry == VALUE_NO_SET)
                //    {
                //        // 未設定の場合
                //        // 福田部品以外はリトライしないので0を設定
                //        SendRetry = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // 設定済みの場合
                //        SendRetry = info.SendRetry;
                //    }

                //    // コンフィグファイルに送信リトライ時の待機秒数が設定されているかチェック
                //    if (info.SendSleepSec == VALUE_NO_SET)
                //    {
                //        // 未設定の場合
                //        // 福田部品以外はリトライしないので0を設定
                //        SendSleepSec = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // 設定済みの場合
                //        SendSleepSec = info.SendSleepSec;
                //    }

                //    // コンフィグファイルに読込みリトライ回数が設定されているかチェック
                //    if (info.ReadRetry == VALUE_NO_SET)
                //    {
                //        // 未設定の場合
                //        // 福田部品以外はリトライしないので0を設定
                //        ReadRetry = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // 設定済みの場合
                //        ReadRetry = info.ReadRetry;
                //    }

                //    // コンフィグファイルに読込みリトライ時の待機秒数が設定されているかチェック
                //    if (info.ReadSleepSec == VALUE_NO_SET)
                //    {
                //        // 未設定の場合
                //        // 福田部品以外はリトライしないので0を設定
                //        ReadSleepSec = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // 設定済みの場合
                //        ReadSleepSec = info.ReadSleepSec;
                //    }
                //}
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<

                // 送信リトライ回数、送信リトライ時の待機秒数に未設定があった場合、コンフィグファイルを更新する
                // 読込みリトライ回数、読込みリトライ時の待機秒数に未設定があった場合も同様に保存する
                if (saveFlag) this.Save(true);
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

                return (int)ResultUtil.ResultCode.Normal;
            }
        }

        /// <summary>
        /// 設定をコンフィグファイルに保存します。
        /// </summary>
        /// <param name="overwriting">上書きフラグ</param>
        public void Save(bool overwriting)
        {
            if (
                !SavePeriodType.Equals(_initialSavePeriodType)
                    ||
                !SCMDataPath.Equals(_initialSCMDataPath)
                    ||
                !LastDate.Equals(_initialLastDate)
                    ||
                !LogDisplay.Equals(_initialLogDisplay)  //ADD 2011/06/01
                    ||
                overwriting
            )
            {
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                // LoadされずにSaveされた場合の対応
                string enterpriceCode = LoginInfoAcquisition.EnterpriseCode.Trim();
                // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                // コンフィグファイルにDB更新リトライ回数が設定されているかチェック
                if (DbRetry == VALUE_NO_SET)
                {
                    // 未設定の場合、デフォルト(5回)を設定
                    DbRetry = DEFAULT_DB_RETRY;
                }
                // コンフィグファイルにDB更新リトライ時の待機秒数が設定されているかチェック
                if (SleepSec == VALUE_NO_SET)
                {
                    // 未設定の場合、デフォルト(5秒)を設定
                    SleepSec = DEFAULT_DB_SLEEP_SEC;
                }
                // --- ADD 2015/06/30③ T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                //// 企業コードチェック
                //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                //{
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                    // 企業コードが福田部品の場合
                    // 送信リトライ回数が設定されているかチェック
                    if (SendRetry == VALUE_NO_SET)
                    {
                        // 送信リトライ回数が未設定の場合、デフォルト(60回)を設定
                        SendRetry = DEFAULT_SEND_RETRY;
                    }

                    // 送信リトライ時の待機秒数が設定されているかチェック
                    if (SendSleepSec == VALUE_NO_SET)
                    {
                        // デフォルト(5秒)を設定
                        SendSleepSec = DEFAULT_SEND_SLEEP_SEC;
                    }

                    // 読込みリトライ回数が設定されているかチェック
                    if (ReadRetry == VALUE_NO_SET)
                    {
                        // 読込みリトライ回数が未設定の場合、デフォルト(60回)を設定
                        ReadRetry = DEFAULT_READ_RETRY;
                    }

                    // 読込みリトライ時の待機秒数が設定されているかチェック
                    if (ReadSleepSec == VALUE_NO_SET)
                    {
                        // デフォルト(5秒)を設定
                        ReadSleepSec = DEFAULT_READ_SLEEP_SEC;
                    }
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                //}
                //else
                //{
                //    // 企業コードが福田部品以外の場合
                //    // 送信リトライ回数が設定されているかチェック
                //    if (SendRetry == VALUE_NO_SET)
                //    {
                //        // 福田部品以外はリトライしないので0を設定
                //        SendRetry = 0;
                //    }

                //    // コリトライ時の待機秒数が設定されているかチェック
                //    if (SendSleepSec == VALUE_NO_SET)
                //    {
                //        // 福田部品以外はリトライしないので0を設定
                //        SendSleepSec = 0;
                //    }

                //    // 読込みリトライ回数が設定されているかチェック
                //    if (ReadRetry == VALUE_NO_SET)
                //    {
                //        // 福田部品以外はリトライしないので0を設定
                //        ReadRetry = 0;
                //    }

                //    // 読込みリトライ時の待機秒数が設定されているかチェック
                //    if (ReadSleepSec == VALUE_NO_SET)
                //    {
                //        // 福田部品以外はリトライしないので0を設定
                //        ReadSleepSec = 0;
                //    }
                //}
                // --- DEL 2015/06/30① T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SCMSendSettingInformation));

                    string filePath = CONFIG_FILE_NAME;
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        serializer.Serialize(stream, this);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// 設定画面を表示します。
        /// </summary>
        public void ShowDialog()
        {
            PMSCM01103AC settingForm = new PMSCM01103AC(SCMDataPath, SavePeriodType);
            settingForm.ShowDialog();
            if (settingForm.DialogResult.Equals(DialogResult.OK))
            {
                SCMDataPath = settingForm.SCMDataPath;
                SavePeriodType = settingForm.SavePeriodType;
                this.Save(true);
            }
        }
    }
}

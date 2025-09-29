//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限取得部品
// プログラム概要   : 以下のクラスのFacade(窓口)となります。
//                  : ・操作履歴リモート
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/16  修正内容 : Mantis【13188】対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Log;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    using DBAccessType      = IOprtnHisLogDB;
    using DBRecordType      = OprtnHisLogWork;
    using DBConditionType   = OprtnHisLogSrchWork;

    #region <列挙型/>

    /// <summary>
    /// ログ種別
    /// </summary>
    public enum LogDataKind : int
    {
        /// <summary>操作ログ</summary>
        OperationLog = 0,
        /// <summary>エラーログ</summary>
        ErrorLog = 1,
        /// <summary>システムログ</summary>
        SystemLog = 9,
        /// <summary>UOE(DSP)ログ</summary>
        UoeDspLog = 10,
        /// <summary>UOE(通信)ログ</summary>
        UoeCommLog = 11
    }

    #endregion  // <列挙型/>

    /// <summary>
    /// 操作履歴ログ部品クラス
    /// </summary>
    public class OperationHistoryLog
    {
        #region <Const/>

        /// <summary>文字列の最大長</summary>
        private const int MAX_STRING_LENGTH = 80;

        /// <summary>メッセージの最大長</summary>
        private const int MAX_MESSAGE_LENGTH = 500;     // ADD 2009/04/16

        /// <summary>
        /// 呼び出し元オブジェクトのアセンブリ情報インデックス列挙体
        /// </summary>
        private enum SenderInfoIdx : int
        {
            /// <summary>ログデータ対象アセンブリID</summary>
            LogDataObjAssemblyID,
            /// <summary>ログデータ対象クラスID</summary>
            LogDataObjClassID,
            /// <summary>ログデータシステムバージョン</summary>
            LogDataSystemVersion
        }

        /// <summary>最大処理レベル</summary>
        private const int MAX_LEVEL = 99;

        #endregion  // <Const/>

        #region <操作履歴データDB/>

        /// <summary>操作履歴データDBのアクセサ</summary>
        private readonly DBAccessType _oprtnHisLogDBAccesser;
        /// <summary>
        /// 操作履歴データDBのアクセサを取得します。
        /// </summary>
        /// <value>操作履歴データDBのアクセサ</value>
        protected DBAccessType OprtnHisLogDBAccesser { get { return _oprtnHisLogDBAccesser; } }

        #endregion  // <操作履歴データDB/>

        #region <アクセサ/>

        /// <summary>オフライン時の出力フォルダパス</summary>
        private readonly string _folderPath;
        /// <summary>
        /// オフライン時の出力フォルダパスを取得します。
        /// </summary>
        /// <value>オフライン時の出力フォルダパス</value>
        private string FolderPath { get { return _folderPath; } }

        /// <summary>
        /// 作成日時を取得します。
        /// </summary>
        /// <value>作成日時</value>
        public static DateTime LogDataCreateDateTime
        {
            get { return TDateTime.GetSFDateNow(); }
        }

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;
        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        /// <remarks>国2桁 + 県2桁 + 業種2桁 + ユーザーコード10桁</remarks>
        /// <value>企業コード</value>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
        }

        /// <summary>
        /// ログイン拠点コードを取得します。
        /// </summary>
        /// <value>ログイン拠点コード</value>
        public string LoginSectionCd
        {
            get
            {
                if (LoginEmployee != null) return LoginEmployee.BelongSectionCode;
                return string.Empty;
            }
        }

        /// <summary>ログデータ端末名</summary>
        private readonly string _logDataMachineName;
        /// <summary>
        /// ログデータ端末名を取得します。
        /// </summary>
        /// <value>ログデータ端末名</value>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
        }

        /// <summary>
        /// ログデータ担当者コードを取得します。
        /// </summary>
        /// <value>ログデータ担当者コード</value>
        public string LogDataAgentCd
        {
            get
            {
                if (LoginEmployee != null) return LoginEmployee.EmployeeCode;
                return string.Empty;
            }
        }

        /// <summary>
        /// ログデータ担当者名を取得します。
        /// </summary>
        /// <value>ログデータ担当者名</value>
        public string LogDataAgentNm
        {
            get
            {
                if (LoginEmployee != null) return LoginEmployee.Name;
                return string.Empty;
            }
        }

        /// <summary>ログイン従業員</summary>
        private readonly Employee _loginEmployee;
        /// <summary>
        /// ログイン従業員を取得します。
        /// </summary>
        /// <value>ログイン従業員</value>
        public Employee LoginEmployee
        {
            get { return _loginEmployee; }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>
        
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OperationHistoryLog() : this(OfflineLogger.DEFAULT_FOLDER_PATH) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="folderPath">オフライン時の出力フォルダパス</param>
        public OperationHistoryLog(string folderPath)
        {
            _folderPath = folderPath;

            try
            {
                _oprtnHisLogDBAccesser = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                // 
                //_oprtnHisLogDBAccesser = new NullOnlineLogger();
                _oprtnHisLogDBAccesser = null;
            }

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _logDataMachineName = Environment.MachineName;

            if (LoginInfoAcquisition.Employee != null)
            {
                _loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 書き込み処理を行います。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="logDataKind">ログ種別</param>
        /// <param name="programId">プログラムID(※オペレーションマスタの登録内容と整合性が取れている必要があります)</param>
        /// <param name="programName">プログラム名(※オペレーションマスタの登録内容と整合性が取れている必要があります)</param>
        /// <param name="methodName">メソッド名</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="status">ステータス</param>
        /// <param name="message">メッセージ</param>
        /// <param name="data">データ</param>
        public void WriteOperationLog(
            object sender,
            LogDataKind logDataKind,
            string programId,
            string programName,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            WriteOperationLog(
                sender,
                LogDataCreateDateTime,  // デフォルトのログデータ作成日時
                logDataKind,
                programId,
                programName,
                methodName,
                operationCode,
                status,
                message,
                data
            );
        }

        /// <summary>
        /// 書き込み処理を行います。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="logDataCreateDateTime">ログデータ作成日時</param>
        /// <param name="logDataKind">ログ種別</param>
        /// <param name="programId">プログラムID(※オペレーションマスタの登録内容と整合性が取れている必要があります)</param>
        /// <param name="programName">プログラム名(※オペレーションマスタの登録内容と整合性が取れている必要があります)</param>
        /// <param name="methodName">メソッド名</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="status">ステータス</param>
        /// <param name="message">メッセージ</param>
        /// <param name="data">データ</param>
        public void WriteOperationLog(
            object sender,
            DateTime logDataCreateDateTime,
            LogDataKind logDataKind,
            string programId,
            string programName,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            DBRecordType writingLog = new DBRecordType();
            {
                // 作成日時
                // 更新日時
                // 企業コード
                writingLog.EnterpriseCode = EnterpriseCode;
                // GUID
                // 更新従業員コード
                // 更新アセンブリID1
                // 更新アセンブリID2
                // 論理削除区分
                // ログデータ作成日時
                writingLog.LogDataCreateDateTime = logDataCreateDateTime;
                // ログデータGUID
                //
                // ログイン拠点コード
                writingLog.LoginSectionCd = LoginSectionCd.Trim();
                // ログデータ種別区分コード
                writingLog.LogDataKindCd = (int)logDataKind;
                // ログデータ端末名
                writingLog.LogDataMachineName = LogDataMachineName;
                // ログデータ担当者コード
                writingLog.LogDataAgentCd = LogDataAgentCd.Trim();
                // ログデータ担当者名
                writingLog.LogDataAgentNm = LogDataAgentNm;
                // ログデータ対象起動プログラム名称
                writingLog.LogDataObjBootProgramNm = programName;

                string[] senderInfos = GetSenderInfo(sender);
                {
                    // ログデータ対象アセンブリID
                    writingLog.LogDataObjAssemblyID = programId;
                    // ログデータ対象アセンブリ名称
                    writingLog.LogDataObjAssemblyNm = programName;
                    // ログデータ対象クラスID
                    writingLog.LogDataObjClassID = senderInfos[(int)SenderInfoIdx.LogDataObjClassID];
                    // ログデータ対象処理名
                    writingLog.LogDataObjProcNm = methodName;
                    // ログデータオペレーションコード
                    writingLog.LogDataOperationCd = operationCode;
                    // ログデータオペレーターデータ処理レベル
                    if (LoginEmployee.AuthorityLevel1 <= MAX_LEVEL)
                    {
                        writingLog.LogOperaterDtProcLvl = LoginEmployee.AuthorityLevel1.ToString();
                    }
                    else
                    {
                        writingLog.LogOperaterDtProcLvl = MAX_LEVEL.ToString();
                    }
                    // ログデータオペレーター機能処理レベル
                    if (LoginEmployee.AuthorityLevel2 <= MAX_LEVEL)
                    {
                        writingLog.LogOperaterFuncLvl = LoginEmployee.AuthorityLevel2.ToString();
                    }
                    else
                    {
                        writingLog.LogOperaterFuncLvl = MAX_LEVEL.ToString();
                    }
                    // ログデータシステムバージョン
                    writingLog.LogDataSystemVersion = senderInfos[(int)SenderInfoIdx.LogDataSystemVersion];
                }
                // ログオペレーションステータス
                writingLog.LogOperationStatus = status;
                // ログデータメッセージ
                //if (message.Length > MAX_STRING_LENGTH)   // DEL 2009/04/16
                if (message.Length > MAX_MESSAGE_LENGTH)    // ADD 2009/04/16
                {
                    //writingLog.LogDataMassage = message.Substring(0, MAX_STRING_LENGTH);      // DEL 2009/04/16
                    writingLog.LogDataMassage = message.Substring(0, MAX_MESSAGE_LENGTH);       // ADD 2009/04/16
                }
                else
                {
                    writingLog.LogDataMassage = message;
                }
                // ログオペレーションデータ
                if (data.Length > MAX_STRING_LENGTH)
                {
                    writingLog.LogOperationData = data.Substring(0, MAX_STRING_LENGTH);
                }
                else
                {
                    writingLog.LogOperationData = data;
                }
            }

            LogRemoteHelper writer = new LogRemoteHelper(OprtnHisLogDBAccesser, writingLog);
            //writer.LogAccesserList.Add(new OfflineLogger(FolderPath));
            writer.SetOfflineLogger(FolderPath);
            // DEL 2009/02/25 不具合対応[11961]↓ マルチスレッドの廃止
            //Thread writeThread = new Thread(writer.TryToWrite);

            writer.TryToWrite();    // ADD 2009/02/25 不具合対応[11961] マルチスレッドの廃止

            // DEL 2009/02/25 不具合対応[11961]↓ マルチスレッドの廃止
            //writeThread.Start();
        }

        /// <summary>
        /// 呼び出し元オブジェクト情報を取得します。
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <returns>
        /// 呼び出し元オブジェクト情報<br/>
        /// [0]:ログデータ対象アセンブリID<br/>
        /// [1]:ログデータ対象クラスID<br/>
        /// [2]:ログデータシステムバージョン
        /// </returns>
        private static string[] GetSenderInfo(object sender)
        {
            string[] senderInfoArray = new string[3] { string.Empty, string.Empty, string.Empty };

            if (sender != null)
            {
                Type senderType = sender.GetType();
                AssemblyName assemblyName = senderType.Assembly.GetName();

                if (assemblyName != null)
                {
                    senderInfoArray[(int)SenderInfoIdx.LogDataObjAssemblyID] = assemblyName.Name;
                    senderInfoArray[(int)SenderInfoIdx.LogDataSystemVersion] = assemblyName.Version.ToString();
                }

                if (senderType != null) senderInfoArray[(int)SenderInfoIdx.LogDataObjClassID] = senderType.Name;
            }

            return senderInfoArray;
        }

        #region <実験/>

        /// <summary>
        /// 操作ログを書く実験
        /// </summary>
        [Conditional("DEBUG")]
        public void TestWriteOperationLog()
        {
            OprtnHisLogWork writingLog = new OprtnHisLogWork();
            {
                // 作成日時
                // 更新日時
                // 企業コード
                writingLog.EnterpriseCode = "0101150842020000";
                // GUID
                // 更新従業員コード
                // 更新アセンブリID1
                // 更新アセンブリID2
                // 論理削除区分
                // ログデータ作成日時
                writingLog.LogDataCreateDateTime = DateTime.Now;
                // ログデータGUID
                //writingLog.LogDataGuid = Guid.NewGuid();
                // ログイン拠点コード
                writingLog.LoginSectionCd = "01";
                // ログデータ種別区分コード
                writingLog.LogDataKindCd = 1;   // エラー
                // ログデータ端末名
                writingLog.LogDataMachineName = "91405A6";
                // ログデータ担当者コード
                writingLog.LogDataAgentCd = "9999";
                // ログデータ担当者名
                writingLog.LogDataAgentNm = "メンテ担当";
                // ログデータ対象起動プログラム名称
                writingLog.LogDataObjBootProgramNm = "セキュリティ管理";

                string[] senderInfos = GetSenderInfo(this);
                {
                    // ログデータ対象アセンブリID
                    writingLog.LogDataObjAssemblyID = "MAHNB01010U"; // ←プログラムID
                    // ログデータ対象アセンブリ名称
                    writingLog.LogDataObjAssemblyNm = "売上伝票入力";
                    // ログデータ対象クラスID
                    writingLog.LogDataObjClassID = "OperationHistoryLog";
                    // ログデータ対象処理名
                    writingLog.LogDataObjProcNm = "TestWriteOperationLog";
                    // ログデータオペレーション
                    writingLog.LogDataOperationCd = 10; // 赤伝
                    // ログデータオペレーターデータ処理レベル
                    writingLog.LogOperaterDtProcLvl = "10"; // 2桁まで！
                    // ログデータオペレーター機能処理レベル
                    writingLog.LogOperaterFuncLvl = "50";
                    // ログデータシステムバージョン
                    writingLog.LogDataSystemVersion = "8.10.1.0";
                }

                // ログオペレーションステータス
                writingLog.LogOperationStatus = 1;
                // ログデータメッセージ
                writingLog.LogDataMassage = "ログデータメッセージ";
                // ログオペレーションデータ
                writingLog.LogOperationData = "ログオペレーションデータ";
            }

            object objWritingLog = writingLog;

            IOprtnHisLogDB accesser = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            int ret = accesser.Write(ref objWritingLog);
            if (!ret.Equals(0))
            {
                Debug.Assert(false, MsgUtil.GetMsg(ret, ""));
            }
        }

        #endregion  // <実験/>
    }

    #region <Helper/>

    /// <summary>
    /// 操作履歴ログデータのリモートのヘルパクラス
    /// </summary>
    internal sealed class LogRemoteHelper
    {
        #region <Const/>

        /// <summary>最大リトライ回数</summary>
        private const int MAX_RETRY_COUNT = 3;

        /// <summary>待ち時間[msec]</summary>
        private const int SLEEP_MSEC = 500;

        #endregion  // <Const/>

        #region <アクセサ/>

        /// <summary>操作履歴ログデータのリモートのリスト</summary>
        private readonly List<IOprtnHisLogDB> _logAccesserList;
        /// <summary>
        /// 操作履歴ログデータのリモートのリストを取得します。
        /// </summary>
        /// <value>操作履歴ログデータのリモートのリスト</value>
        public List<IOprtnHisLogDB> LogAccesserList
        {
            get { return _logAccesserList; }
        }

        /// <summary>内容のレコード</summary>
        private OprtnHisLogWork _doingRecord;
        /// <summary>
        /// 内容のレコードを取得します。
        /// </summary>
        /// <value>内容のレコード</value>
        public OprtnHisLogWork DoingRecord
        {
            get { return _doingRecord; }
        }

        /// <summary>リトライのカウンタ</summary>
        private int _reTryCounter;
        /// <summary>
        /// リトライのカウンタを取得します。
        /// </summary>
        /// <value>リトライのカウンタ</value>
        public int ReTryCounter
        {
            get { return _reTryCounter; }
        }

        #endregion  // <アクセサ/>

        #region <オフライン用のロガー/>

        /// <summary>
        /// オフライン用のロガー
        /// </summary>
        private OfflineLogger _offlineLogger;
        /// <summary>
        /// オフライン用のロガーを取得します。
        /// </summary>
        /// <value>オフライン用のロガー</value>
        internal OfflineLogger OfflineLogger { get { return _offlineLogger; } }

        /// <summary>
        /// オフライン用ロガーを設定します。
        /// </summary>
        /// <param name="folderPath"></param>
        public void SetOfflineLogger(string folderPath)
        {
            _offlineLogger = new OfflineLogger(folderPath);
        }

        #endregion  // <オフライン用のロガー/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="accesser">操作履歴ログデータのリモート</param>
        /// <param name="doingRecord">内容レコード</param>
        public LogRemoteHelper(
            IOprtnHisLogDB accesser,
            OprtnHisLogWork doingRecord
        )
        {
            _logAccesserList = new List<IOprtnHisLogDB>();
            _logAccesserList.Add(accesser);
            _doingRecord = doingRecord;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ログを書き込みます。（リトライ付）
        /// </summary>
        public void TryToWrite()
        {
            object objDoingRecord = DoingRecord;

            foreach (IOprtnHisLogDB writer in LogAccesserList)
            {
                if (writer == null) continue;

                try
                {
                    Debug.WriteLine("ログを書き込みます。");

                    int status = writer.Write(ref objDoingRecord);
                    if (!status.Equals((int)DBAccessStatus.Normal) && !status.Equals((int)DBAccessStatus.RecordIsExisted))
                    {
                        if (CanNotReTry)
                        {
                            Debug.WriteLine("ログの書き込みに失敗しました。");
                            return;
                        }
                        Thread.Sleep(SLEEP_MSEC);

                        Debug.WriteLine("異常発生：" + ReTryCounter.ToString() + "回目のリトライです。");
                        TryToWrite();
                    }

                    if (OfflineLogger != null)
                    {
                        OfflineLogger.Write(ref objDoingRecord);
                    }

                    Debug.WriteLine("ログの書き込みに成功しました。");
                }
                catch (Exception)
                {
                    if (CanNotReTry)
                    {
                        Debug.WriteLine("ログの書き込みに失敗しました。");
                        return;
                    }
                    Thread.Sleep(SLEEP_MSEC);

                    Debug.WriteLine("例外発生：" + ReTryCounter.ToString() + "回目のリトライです。");
                    TryToWrite();
                }
            }
        }

        /// <summary>
        /// リトライできないか判定します。
        /// </summary>
        /// <value>true :できない。<br/>false:できる。</value>
        private bool CanNotReTry
        {
            get { return (++_reTryCounter) > MAX_RETRY_COUNT; }
        }
    }

    #endregion  // <Helper/>
}

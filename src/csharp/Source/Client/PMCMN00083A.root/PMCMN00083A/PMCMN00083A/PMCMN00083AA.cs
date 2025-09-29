//****************************************************************************//
// システム         : LSMログチェック
// プログラム名称   : LSMログチェックアクセスクラス
// プログラム概要   : LSMログチェックアクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2015/09/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015/10/08  修正内容 : ①文字列チェックリモートの追加
//                                  ②LSMチェックリモートの戻り値から最新レコードのみを
//                                    取得して拠点管理リモートに渡すように変更
//                                  ③改行コードが入っている場合、データ側は削除、
//                                    画面側はそのまま渡す。
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// ログアップロードログ部品クラス
    /// </summary>
    public class LsmHistoryLog
    {
        #region <Const/>

        /// <summary>検索文字</summary>
        //--- DEL 2015/10/08 20073 T.Nishi ----->>>>>
        //private string[] LOGMSG_ERROR = { "エラー", "失敗", "読み込めません", "見つかりません" };
        //private string LOGMSG_NORMAL = "製品サービスのアップデートが完了";
        //--- DEL 2015/10/08 20073 T.Nishi -----<<<<<

        /// <summary>メッセージの最大長</summary>
        private const int MAX_MESSAGE_LENGTH = 500;

        #endregion  // <Const/>

        #region <リモート定義/>

        /// <summary>ログアップロードデータリモート</summary>
        private readonly ILsmHisLogDB _lsmHisLogDB;
        /// <summary>LSMログチェックリモート</summary>
        private readonly ILSMLogCheckDB _lsmLogCheckDB;
        //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
        private readonly ILsmChkWordDB _lsmChkWordDB;
        //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<

        #endregion  // <リモート定義/>

        #region <アクセサ/>
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

        /// <summary>ログデータ端末名</summary>
        private string _logDataMachineName;
        /// <summary>
        /// ログデータ端末名を取得します。
        /// </summary>
        /// <value>ログデータ端末名</value>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
            set { _logDataMachineName = value; }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>
        
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        public LsmHistoryLog()
        {
            try
            {
                _lsmHisLogDB = (ILsmHisLogDB)MediationLsmHisLogDB.GetLsmHisLogDB();
                _lsmLogCheckDB = (ILSMLogCheckDB)MediationLSMLogCheckDB.GetLSMLogCheckDB();
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                _lsmChkWordDB = (ILsmChkWordDB)MediationLsmChkWordDB.GetLsmChkWordDB();
                //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                // 
                _lsmHisLogDB = null;
                _lsmLogCheckDB = null;
            }

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //_logDataMachineName = Environment.MachineName;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 書き込み処理を行います。
        /// </summary>
        /// <param name="retList">リスト</param>
        public int WriteLsmLog(out object retList, bool LogWriteFlg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int status2 = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            object retWorkList = null;
            //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
            object chkParaList = null;
            //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
            LsmHisLogWork writingLog;
            ArrayList list = new ArrayList();

            retList = null;
            try
            {

                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                status = _lsmChkWordDB.Search(out chkParaList);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<

                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    // LSMログチェックリモート
                    //status = _lsmLogCheckDB.CheckLSMLog(out retWorkList);
                    status = _lsmLogCheckDB.CheckLSMLog(out retWorkList, out _logDataMachineName, chkParaList);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<

                    ArrayList msgList = (ArrayList)retWorkList;
                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    //for (int i = 0; i < msgList.Count; i++)
                    //{
                    //    // LSMログデータ設定
                    //    this.SetWritingLog(msgList[i].ToString(), out writingLog);
                    //    // リストに設定
                    //    list.Add(writingLog);
                    //}
                    this.SetWritingLog(msgList[msgList.Count - 1].ToString(), chkParaList, status, out writingLog);
                    //データ側のメッセージに改行コードが含まれている場合は削除
                    //writingLog.LogDataMassage = writingLog.LogDataMassage.Replace("\r\n", "");
                    list.Add(writingLog);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                    if (LogWriteFlg == true)
                    {
                        // LSMログデータ登録
                        status2 = this.Write(ref list);
                    }
                    else
                    {
                        status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (status2.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                    }
                    else
                    {
                        status = status2;
                    }
                    //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                }
                else
                {
                    // LSMログデータ設定
                    string message = "チェック対象の文字列の取得に失敗しました。status=" + status.ToString();
                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    //this.SetWritingLog(message, out writingLog);
                    this.SetWritingLog(message, chkParaList, (int)ConstantManagement.MethodResult.ctFNC_ERROR, out writingLog);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                    list.Add(writingLog);
                }
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
            }
            catch (Exception ex)
            {
                // LSMログデータ設定
                //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                //this.SetWritingLog(ex.Message + "(WriteLsmLog)", out writingLog);
                this.SetWritingLog(ex.Message + "(WriteLsmLog)", chkParaList, (int)ConstantManagement.MethodResult.ctFNC_ERROR, out writingLog);
                //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                list.Add(writingLog);
            }
            finally
            {
                retList = list;
            }

            return status;
        }

        /// <summary>
        /// 書き込み処理を行います。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="writingLog">LSMログデータ</param>
        //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
        //private void SetWritingLog(string message, out LsmHisLogWork writingLog)
        private void SetWritingLog(string message, object chkParaList, int Retstatus, out LsmHisLogWork writingLog)
        //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
        {
            int logDataKindCd = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
            //// 文字列検索
            //if (0 <= message.IndexOf(LOGMSG_NORMAL))
            //{
            //    // 正常チェック
            //    logDataKindCd = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //}
            int status = Retstatus;
            int operationcode = 0;
            if (chkParaList != null)
            {
                ArrayList _lsmChkWordWorkList = new ArrayList();
                _lsmChkWordWorkList = (ArrayList)chkParaList;
                foreach (LsmChkWordWork lsmChkWordWork in _lsmChkWordWorkList)
                {
                    if (0 <= message.IndexOf(lsmChkWordWork.Massage))
                    {
                        status = lsmChkWordWork.Status;
                        operationcode = lsmChkWordWork.OperationCode;
                        message = message + "\r\n" + lsmChkWordWork.LogDataMessage;
                        break;
                    }
                }
            }
            logDataKindCd = status;
            //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<

            writingLog = new LsmHisLogWork();
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
                writingLog.LogDataCreateDateTime = LogDataCreateDateTime;
                // ログデータGUID
                // ログイン拠点コード
                writingLog.LoginSectionCd = "";
                // ログデータ種別区分コード
                writingLog.LogDataKindCd = logDataKindCd;
                // ログデータ端末名
                writingLog.LogDataMachineName = LogDataMachineName;
                // ログデータ担当者コード
                writingLog.LogDataAgentCd = "";
                // ログデータ担当者名
                writingLog.LogDataAgentNm = "";
                // ログデータ対象起動プログラム名称
                writingLog.LogDataObjBootProgramNm = "配信チェックツール";
                // ログデータ対象アセンブリID
                writingLog.LogDataObjAssemblyID = "PMCMN00083A";
                // ログデータ対象アセンブリ名称
                writingLog.LogDataObjAssemblyNm = "LSMチェックアクセスクラス";
                // ログデータ対象クラスID
                writingLog.LogDataObjClassID = "";
                // ログデータ対象処理名
                writingLog.LogDataObjProcNm = "";
                // ログデータオペレーションコード
                writingLog.LogDataOperationCd = operationcode;
                // ログデータオペレーターデータ処理レベル
                writingLog.LogOperaterDtProcLvl = "";
                // ログデータオペレーター機能処理レベル
                writingLog.LogOperaterFuncLvl = "";
                // ログデータシステムバージョン
                writingLog.LogDataSystemVersion = "";
                // ログオペレーションステータス
                writingLog.LogOperationStatus = 0;

                // ログデータメッセージ
                if (message.Length > MAX_MESSAGE_LENGTH)
                {
                    writingLog.LogDataMassage = message.Substring(0, MAX_MESSAGE_LENGTH);
                }
                else
                {
                    writingLog.LogDataMassage = message;
                }
                // ログオペレーションデータ
                writingLog.LogOperationData = "USB番号：";
            }
        }

        /// <summary>
        /// ログを書き込みます。
        /// </summary>
        /// <param name="logList">リスト</param>
        public int Write(ref ArrayList logList)
        {
            LsmHisLogWork writingLog;
            ArrayList list = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object objDoingRecord = logList;

            try
            {
                status = _lsmHisLogDB.Write(ref objDoingRecord);

                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    // ログの書き込みに成功
                    list = logList;
                }
                else
                {
                    // ログの書き込みに失敗
                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    //this.SetWritingLog("ログの書き込みに失敗", out writingLog);
                    this.SetWritingLog("ログの書き込みに失敗", null, status, out writingLog);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                    list.Add(writingLog);
                }
            }
            catch (Exception ex)
            {
                // LSMログデータ設定
                //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                //this.SetWritingLog(ex.Message + "(Write)", out writingLog);
                this.SetWritingLog(ex.Message + "(Write)", null, status, out writingLog);
                //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                list.Add(writingLog);
            }
            finally
            {
                logList = list;
            }

            return status;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
//using System.Net;
//using System.Net.NetworkInformation;
using System.Runtime.Remoting;
using Microsoft.Win32;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
//using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 起動有無の設定対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/05/19</br>
    /// <br>Update     : 2015/05/25 30809 佐々木 11101069-00 LSM配信改良 </br>
    /// <br>           : ・ファイルクローズ追加</br>
    /// <br>           : ・ログ出力部品をCLCログ出力部品呼出に変更</br>
    /// </remarks>
    public partial class NSTaskScheduler : ServiceBase
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new NSTaskScheduler() };

            //string msg = "";
            //string[] _parameter = new string[0];
            //int status = ServerApplicationMethodCallControl.StartApplication(
            //            out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);
            ServiceBase.Run(ServicesToRun);
        }

        #region [ Private Member ]
#if SyncEnabled
        private SyncProcessAcs _SyncProcessAcs = null;
        private SyncInfoAcs _SyncInfoAcs = null;
        private ConfigInfo conf = new ConfigInfo();
        private System.Threading.Thread syncThread;
        private string uniqueCode = string.Empty;

        private int hour;
        private int min;
        private string enterpriseCode = string.Empty;
#endif
        private System.Timers.Timer timer = null;
        private const string ct_cfgFile = "PMCMN06200S.XML";
        private conf _dtHist;

        // ADD 2009/06/08 ------>>>
        // ユーザー設定ファイル
        private const string ct_cfgUsrFile = "PMCMN06200S.USR.XML";
        private conf _dtHistUsr;

        // 実行プロセス
        private Process execProcess;
        private List<CheckCondWork> stackExecList = new List<CheckCondWork>();
        // ADD 2009/06/08 ------<<<

        private List<CheckCondWork> lstChk = new List<CheckCondWork>();
        private string workDir; // 実行ファイルのあるディレクトリ
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public NSTaskScheduler()
        {
            InitializeComponent();

#if SyncEnabled
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            _SyncProcessAcs = new SyncProcessAcs();
            _SyncInfoAcs = new SyncInfoAcs();
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            uniqueCode = string.Format("{0}.{1}", computerProperties.HostName, computerProperties.DomainName);
            syncThread = new System.Threading.Thread(CheckAndGetSyncData);

            string[] syncTime = conf.SyncTime.Split(new char[] { ':' });
            if (syncTime.Length == 2)
            {
                hour = Convert.ToInt32(syncTime[0]);
                min = Convert.ToInt32(syncTime[1]);
            }
            else
            {
                hour = 22;
                min = 30;
            }
            enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
#endif
            timer = new System.Timers.Timer();
            timer.Enabled = false;
            timer.Interval = 60000; // 1分間隔
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // あってはいけないケース
            {
                WriteErrorLog(this.ServiceName, "Constructor", "レジストリ情報なし", null, -1);
                workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int chkTime = dt.Hour * 100 + dt.Minute;

            for (int i = 0; i < lstChk.Count; i++)
            {
                if (lstChk[i].ProcessExecuteDiv == 1) continue;    // 2010/05/19 Add
                if (lstChk[i].ChkStTime1 <= chkTime && lstChk[i].ChkEdTime1 >= chkTime
                    && lstChk[i].ChkStTime2 <= chkTime && lstChk[i].ChkEdTime2 >= chkTime) // チェック時間帯か
                {
                    //lstChk[i].HourCnt++;  // DEL 2009/06/08

                    //foreach (CheckCondWork chkWork in lstChk)
                    //{
                    
                    // 価格改正用
                        //if (chkWork.PgId == workDir + "\\PMKHN09210U.exe")
                        //{
                            // DEL 2009/06/08 ------>>>
                            //if (lstChk[i].HourCnt == 60) // １時間経過
                            //{
                            //    lstChk[i].HourCnt = 0;
                            // DEL 2009/06/08 ------<<<
                                // 
                                lstChk[i].RemainedTm--; // 残り時間を1時間減らす。
                                if (lstChk[i].RemainedTm == 0) // チェック間隔に達した？
                                {
                                    lstChk[i].RemainedTm = lstChk[i].ChkInterval;
                                    //Process.Start(lstChk[i].PgId, lstChk[i].PgParam);     // DEL 2009/06/08
                                    // ADD 2009/06/08 ------>>>
                                    if (!stackExecList.Contains(lstChk[i]))
                                    {
                                        // 自プロセスの２重起動防止
                                        stackExecList.Add(lstChk[i]);
                                    }
                                    // ADD 2009/06/08 ------<<<
                                }
                            // DEL 2009/06/08 ------>>>
                            //}
                            // DEL 2009/06/08 ------<<<
                        //}
                        // 拠点管理用(未実装)
                        //else if (chkWork.PgId == workDir + "\\     .exe")
                        //{
                        //    if (lstChk[i].HourCnt == 2) // １時間経過
                        //    {
                        //        lstChk[i].HourCnt = 0;

                        //        lstChk[i].RemainedTm--; // 残り時間を1時間減らす。
                        //        if (lstChk[i].RemainedTm == 0) // チェック間隔に達した？
                        //        {
                        //            lstChk[i].RemainedTm = lstChk[i].ChkInterval;
                        //            Process.Start(lstChk[i].PgId, lstChk[i].PgParam);
                        //            //timer.Enabled = false;
                        //            //lstChk.Clear();
                        //        }
                        //    }
                        //}
                    //}
                }
            }

            // ADD 2009/06/08 ------>>>
#if _DEBUG
            FileStream fs = new FileStream(Path.Combine(workDir, "DEBUG.txt"), FileMode.Append, FileAccess.Write, FileShare.Write);
            byte[] tmp = new byte[1000];
#endif
            if ((execProcess == null) || (execProcess.HasExited == true))
            {
                // 前回起動したプロセスが終了していること
                if (stackExecList.Count == 0)
                {
                    // 実行予定プロセスが無ければ処理終了
                    return;
                }

                // プロセス実行
                execProcess = Process.Start(stackExecList[0].PgId, stackExecList[0].PgParam);
                // 実行予定リストから削除
                stackExecList.Remove(stackExecList[0]);
#if _DEBUG
                if (execProcess == null)
                {
                    tmp = Encoding.ASCII.GetBytes(stackExecList[0].PgId + "= down!!\r\n");

                }
                else
                {
                    tmp = Encoding.ASCII.GetBytes(stackExecList[0].PgId + "= ok!!\r\n");
                }
#endif
            }
#if _DEBUG
            else
            {
                tmp = Encoding.ASCII.GetBytes("exec!!");
            }
            fs.Write(tmp, 0, tmp.Length);
            fs.Close();
#endif
            // ADD 2009/06/08 ------<<<

#if SyncEnabled
            if (dt.Hour == hour && dt.Minute == min)
            {
                CheckAndGetSyncData();
            }
#endif
        }

        #region [ Sync Process ]
#if SyncEnabled
        private void CheckAndGetSyncData()
        {
            int offerDate;
            string ver = Microsoft.Win32.Registry.GetValue(
                        conf.RegistryKey, "CurrentVersion", "8.10.1.0").ToString();

            _SyncInfoAcs.GetLastOfferDate(out offerDate);

            bool ret = _SyncProcessAcs.CheckSyncData(offerDate, ver);
            if (ret)
            {
                byte[] syncData;
                bool retGetSync;
                do
                {
                    int prevOfferDate;
                    UpdateInfo updateInfoGWork;
                    ArrayList lstTableUpdateInfo;
                    retGetSync = _SyncProcessAcs.GetSyncData(enterpriseCode, uniqueCode, ref offerDate, out syncData);
                    ArrayList lstQuery = GetQueryList(syncData, out prevOfferDate, out updateInfoGWork, out lstTableUpdateInfo);
                    updateInfoGWork.UpdateDataSrc = "DataCenter";
                    int status = _SyncInfoAcs.WriteSyncData(lstQuery);
                    if (status == 0)
                    {
                        _SyncInfoAcs.SetUpdateInfo(updateInfoGWork, lstTableUpdateInfo);
                    }
                    else
                    {
                        EventLog.WriteEntry("Sync", "シンクデータのアップデートに失敗しました。", EventLogEntryType.Error);
                        break;
                    }
                } while (retGetSync);
            }
        }

        /// <summary>
        /// シンクデータファイルからシンクデータ処理用クエリを作成する。
        /// </summary>
        /// <param name="syncData"></param>
        /// <param name="prevOfferDate"></param>
        /// <param name="updateInfoWork"></param>
        /// <param name="lstTableUpdateInfo"></param>
        /// <returns></returns>
        public static ArrayList GetQueryList(byte[] syncData, out int prevOfferDate, out UpdateInfo updateInfoWork,
            out ArrayList lstTableUpdateInfo)
        {
            int offerDate;
            prevOfferDate = 0;
            string ver;
            ArrayList lstQuery = new ArrayList();
            char[] splitChar1 = new char[] { ',' };
            char[] splitChar2 = new char[] { '\t' };

        #region [ 圧縮解凍処理 ]
            MemoryStream mStream = new MemoryStream(syncData);
            mStream.Position = 0;
            System.IO.Compression.GZipStream gzipStream = new System.IO.Compression.GZipStream(mStream, System.IO.Compression.CompressionMode.Decompress);

            byte[] decompressed = new byte[syncData.Length * 2];
            //int bytesRead = gzipStream.Read(decompressed, 0, 100);
            gzipStream.Flush();
            int offset = 0;
            int totalCount = 0;
            gzipStream.ReadByte();
            while (true)
            {
                int bytesRead = gzipStream.Read(decompressed, offset, 1);
                if (bytesRead == 0)
                {
                    break;
                }
                offset += bytesRead;
                totalCount += bytesRead;
            }
            Array.Resize<byte>(ref decompressed, totalCount);

            //gzipStream.Flush();
            gzipStream.Dispose();
            MemoryStream memStream = new MemoryStream(decompressed);
        #endregion

            StreamReader sreader = new StreamReader(memStream);
            string readBuffer;

        #region [ ヘッダ　読込み ]
            readBuffer = sreader.ReadLine(); // 前回提供日付
            prevOfferDate = Convert.ToInt32(readBuffer);

            readBuffer = sreader.ReadLine(); // 提供日付
            offerDate = Convert.ToInt32(readBuffer);

            readBuffer = sreader.ReadLine(); // ターゲットバージョン
            ver = readBuffer;
        #endregion

            //readBuffer = sreader.ReadLine(); // 区分行

            updateInfoWork = new UpdateInfo();
            updateInfoWork.ProgramID = ConstantManagement_SF_PRO.ProductCode;
            updateInfoWork.OfferDate = offerDate;
            updateInfoWork.SyncExecuteDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            //updateInfoWork.UpdateDataSrc = "DataCenter";
            updateInfoWork.UpdateDataSize = syncData.Length;

            Dictionary<string, TableUpdateInfo> dTableUpdateInfo = new Dictionary<string, TableUpdateInfo>();

        #region [ 削除データ 読込み ]
            // 削除データ 読込み
            string tableID = string.Empty;
            string whereCond;
            TableUpdateInfo tableUpdateInfo;
            do
            {
                readBuffer = sreader.ReadLine();
                if (readBuffer == string.Empty) // 改行か？
                {
                    readBuffer = sreader.ReadLine(); // テーブルID
                    if (readBuffer == string.Empty)
                        break;
                    tableID = readBuffer;

                    // 更新テーブル情報設定
                    tableUpdateInfo = new TableUpdateInfo();
                    tableUpdateInfo.ProgramID = ConstantManagement_SF_PRO.ProductCode;
                    tableUpdateInfo.OfferDate = offerDate;
                    tableUpdateInfo.TableID = tableID;
                    tableUpdateInfo.DeletedRowsNo = 0;
                    tableUpdateInfo.AddUpdateRowsNo = 0;
                    dTableUpdateInfo.Add(tableID, tableUpdateInfo);
                }
                else if (readBuffer != null)
                {
                    //readBuffer = sreader.ReadLine(); // 削除条件文
                    whereCond = readBuffer;

                    string query = string.Format("DELETE FROM [{0}] WHERE ({1});", tableID, whereCond);

                    lstQuery.Add(query);

                    dTableUpdateInfo[tableID].DeletedRowsNo++; //////////
                }
            } while (sreader.EndOfStream == false); // 削除データはない場合も最少2行の改行はあるので必ず1回実行
        #endregion

        # region [ 追加データ　読込み ]
            Dictionary<string, string> queryTemplate = new Dictionary<string, string>(200); // とりあえず200テーブル対応とする。
            while (sreader.EndOfStream == false) // 追加・更新データはない場合があるかもしれませんのでEOFかのチェックが優先
            {
                readBuffer = sreader.ReadLine(); // テーブルID
                tableID = readBuffer;

                readBuffer = sreader.ReadLine(); // カラム情報  
                string template = string.Empty;
                if (queryTemplate.ContainsKey(tableID) == false)
                {
                    string[] columns = readBuffer.Split(splitChar1);
                    template = string.Format("INSERT INTO [{0}] (", tableID);
                    for (int i = 0; i < columns.Length; i++)
                    {
                        template += string.Format("[{0}], ", columns[i]);
                    }
                    template = template.Remove(template.Length - 2);
                    template += ") VALUES (";
                    queryTemplate.Add(tableID, template);

                    if (dTableUpdateInfo.ContainsKey(tableID) == false)
                    {
                        tableUpdateInfo = new TableUpdateInfo();
                        tableUpdateInfo.ProgramID = ConstantManagement_SF_PRO.ProductCode;
                        tableUpdateInfo.OfferDate = offerDate;
                        tableUpdateInfo.TableID = tableID;
                        tableUpdateInfo.DeletedRowsNo = 0;
                        tableUpdateInfo.AddUpdateRowsNo = 0;
                        dTableUpdateInfo.Add(tableID, tableUpdateInfo);
                    }
                }
                else
                {
                    template = queryTemplate[tableID];
                }

                do // テーブルID,カラム情報があったら最少1個の追加・更新データはある
                {
                    readBuffer = sreader.ReadLine(); // 追加・更新データ
                    if (readBuffer == string.Empty)
                        break;
                    string query = template;
                    string[] columns = readBuffer.Split(splitChar2);
                    for (int i = 0; i < columns.Length; i++)
                    {
                        query += string.Format("{0}, ", columns[i]);
                    }
                    query = query.Remove(query.Length - 2);
                    query += ");";
                    lstQuery.Add(query);

                    // 更新テーブル情報設定[Insert行数更新]
                    dTableUpdateInfo[tableID].AddUpdateRowsNo++; //////////
                } while (sreader.EndOfStream == false);
            }
        #endregion

            lstTableUpdateInfo = new ArrayList();
            foreach (TableUpdateInfo tblInfo in dTableUpdateInfo.Values)
            {
                lstTableUpdateInfo.Add(tblInfo);
            }
            updateInfoWork.UpdateTableNo = lstTableUpdateInfo.Count;

            return lstQuery;
        }
#endif
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
#if SyncEnabled
                GetMachineInfo();
                _SyncProcessAcs.StartService(enterpriseCode, uniqueCode);
#endif
                //if (ReadCfgFile() == 0) // 設定ファイル読み込みOK     // DEL 2009/06/08
                if ((ReadCfgFile() == 0) && (ReadCfgUsrFile() == 0)) // 設定ファイル読み込みOK  // ADD 2009/06/08
                {
                    // ADD 2009/06/08 ------>>>
                    // ユーザー設定ファイル
                    List<string> pfIdList = new List<string>();
                    List<CheckCondWork> usrListChk = new List<CheckCondWork>();
                    for (int i = 0; i < _dtHistUsr.Conf.Count; i++)
                    {
                        CheckCondWork cond = new CheckCondWork();
                        cond.ChkStTime1 = _dtHistUsr.Conf[i].ChkStTime;
                        if (_dtHistUsr.Conf[i].ChkStTime < _dtHistUsr.Conf[i].ChkEdTime) // 例 1800 ~ 2300
                        {
                            cond.ChkEdTime1 = _dtHistUsr.Conf[i].ChkEdTime;
                            cond.ChkStTime2 = 0;     // 第2チェック条件は常にTrueになるようにする。
                            cond.ChkEdTime2 = 2400;  // 第2チェック条件は常にTrueになるようにする。
                        }
                        else                                                       // 例 2100 ~ 0300
                        {
                            cond.ChkEdTime1 = 2400;
                            cond.ChkStTime2 = 0;
                            cond.ChkEdTime2 = _dtHistUsr.Conf[i].ChkEdTime;
                        }
                        cond.ChkInterval = _dtHistUsr.Conf[i].ChkInterval;
                        cond.RemainedTm = _dtHistUsr.Conf[i].ChkInterval;
                        cond.PgId = Path.Combine(workDir, _dtHistUsr.Conf[i].PgId);
                        cond.PgParam = _dtHistUsr.Conf[i].RunParam;
                        cond.ProcessExecuteDiv = _dtHistUsr.Conf[i].ProcessExecuteDiv;    // 2010/05/19 Add

                        pfIdList.Add(cond.PgId);
                        usrListChk.Add(cond);
                    }
                    // ADD 2009/06/08 ------<<<
                    
                    // PGリスト
                    for (int i = 0; i < _dtHist.Conf.Count; i++)
                    {
                        if (pfIdList.Contains(Path.Combine(workDir, _dtHist.Conf[i].PgId)))
                        {
                            // ユーザー設定ファイルを優先のためSkip
                            continue;
                        }

                        CheckCondWork cond = new CheckCondWork();
                        cond.ChkStTime1 = _dtHist.Conf[i].ChkStTime;
                        if (_dtHist.Conf[i].ChkStTime < _dtHist.Conf[i].ChkEdTime) // 例 1800 ~ 2300
                        {
                            cond.ChkEdTime1 = _dtHist.Conf[i].ChkEdTime;
                            cond.ChkStTime2 = 0;     // 第2チェック条件は常にTrueになるようにする。
                            cond.ChkEdTime2 = 2400;  // 第2チェック条件は常にTrueになるようにする。
                        }
                        else                                                       // 例 2100 ~ 0300
                        {
                            cond.ChkEdTime1 = 2400;
                            cond.ChkStTime2 = 0;
                            cond.ChkEdTime2 = _dtHist.Conf[i].ChkEdTime;
                        }
                        cond.ChkInterval = _dtHist.Conf[i].ChkInterval;
                        cond.RemainedTm = _dtHist.Conf[i].ChkInterval;
                        cond.PgId = Path.Combine(workDir, _dtHist.Conf[i].PgId);
                        cond.PgParam = _dtHist.Conf[i].RunParam;
                        cond.ProcessExecuteDiv = _dtHist.Conf[i].ProcessExecuteDiv;    // 2010/05/19 Add
                        lstChk.Add(cond);
                    }

                    // ADD 2009/06/08 ------>>>
                    for (int i = 0; i < usrListChk.Count; i++)
                    {
                        // ユーザー設定分を追加
                        lstChk.Add(usrListChk[i]);
                    }
                    // ADD 2009/06/08 ------<<<
                    
                    if (lstChk.Count > 0)
                        timer.Enabled = true;
                }

#if SyncEnabled
                if (conf.SyncOnStart.Equals("True"))
                {
                    syncThread.Start();
                }
#endif
            }
            catch (Exception ex)
            {
                WriteErrorLog(this.ServiceName, "OnStart", ex.Message, ex, -1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnStop()
        {
            timer.Enabled = false;
#if SyncEnabled
            _SyncProcessAcs.StopService(enterpriseCode, uniqueCode);
#endif
        }

        /// <summary>
        /// 設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        private int ReadCfgFile()
        {
            int status = 0;
            _dtHist = new conf();

            //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
            FileStream fs = null;
            //--- ADD 2015/05/25 30809 佐々木 -----<<<<<
            try
            {
                string fileNm = Path.Combine(workDir, ct_cfgFile);

                //--- DEL 2015/05/25 30809 佐々木 ----->>>>>
                //FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                //--- DEL 2015/05/25 30809 佐々木 -----<<<<<
                //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
                fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                //--- ADD 2015/05/25 30809 佐々木 -----<<<<<
                byte[] tmp = new byte[fs.Length];
                int cnt = fs.Read(tmp, 0, (int)fs.Length);
                for (int i = 0; i < cnt; i++)
                {
                    tmp[i] += 8;
                }
                MemoryStream ms = new MemoryStream(tmp);
                _dtHist.ReadXml(ms);
            }
            catch
            {
                status = -1;
            }
            //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            //--- ADD 2015/05/25 30809 佐々木 -----<<<<<

            return status;
        }

        // ADD 2009/06/08 ------>>>
        /// <summary>
        /// ユーザー設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        private int ReadCfgUsrFile()
        {
            int status = 0;
            _dtHistUsr = new conf();

            //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
            FileStream fs = null;
            //--- ADD 2015/05/25 30809 佐々木 -----<<<<<
            try
            {
                string fileNm = Path.Combine(workDir, ct_cfgUsrFile);

                //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
                //FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                //--- ADD 2015/05/25 30809 佐々木 -----<<<<<
                //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
                fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                //--- ADD 2015/05/25 30809 佐々木 -----<<<<<

                if (fs.Length == 0)
                {
                    return status;
                }

                byte[] tmp = new byte[fs.Length];
                int cnt = fs.Read(tmp, 0, (int)fs.Length);
                for (int i = 0; i < cnt; i++)
                {
                    tmp[i] += 8;
                }
                MemoryStream ms = new MemoryStream(tmp);
                _dtHistUsr.ReadXml(ms);
            }
            catch (System.IO.FileNotFoundException)
            {
                // ユーザー設定ファイルが存在しない場合はエラーとしない
                status = 0;
            }
            catch
            {
                status = -1;
            }
            //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            //--- ADD 2015/05/25 30809 佐々木 -----<<<<<

            return status;
        }
        // ADD 2009/06/08 ------<<<
        
        /// <summary>
        /// エラーLog生成
        /// </summary>
        /// <param name="pgId"></param>
        /// <param name="method"></param>
        /// <param name="Msg"></param>
        /// <param name="ex"></param>
        /// <param name="status"></param>
        private void WriteErrorLog(string pgId, string method, string Msg, Exception ex, int status)
        {
            string exceptionMsg = "無し";
            if (ex != null)
                exceptionMsg = ex.Message;
            string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}", method, Msg, exceptionMsg);
            LogTextOut logTextOut = new LogTextOut();
            logTextOut.Output(pgId, msg, status);
            //--- ADD 2015/05/25 30809 佐々木 ----->>>>>
            // CLCログ出力部品呼出追加
            CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
            clcLogTextOut.OutputClcLog(pgId, null, msg, status, ex);
            //--- ADD 2015/05/25 30809 佐々木 -----<<<<<
            this.Stop();
        }
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期状況確認 アクセスクラス
// プログラム概要   : 同期状況確認 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/08/01   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/09/03   修正内容 : Redmine#43408
//                                   ステータスが2、またMaxErrorCountまで到達していないものも取得する対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 同期状況確認 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 同期状況確認 アクセス制御を行います。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/01</br>
    /// <br>Update Note : 2014/09/03 田建委</br>
    /// <br>管理番号    : 11070136-00 Redmine#43408</br>
    /// <br>            : ステータスが2、またMaxErrorCountまで到達していないものも取得する対応</br>
    /// </remarks>
    public class SynchConfirmAcs
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ISynchConfirmDB _iSynchConfirmDB;
        /// <summary>同期要求管理 アクセスクラス</summary>
        private SynchExecuteAcs _synchExecuteAcs;

        /// <summary>画面に関連する情報</summary>
        private SynchConfirmDataSet.SynchConfirmDataTable _synchConfirmDataTable;
        /// <summary>XMLからの関連するマスタ情報</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOn;
        /// <summary>XMLからの関連するマスタ情報</summary>
        private Dictionary<string, List<ReferenceTable>> _tableIDDicForCheckOff;
        /// <summary>同期モード（0：手動モード　1：再同期モード）</summary>
        private int _syncMode;
        /// <summary>同期エラー有無（true：エラーあり　false：エラーなし）</summary>
        private bool _isError;
        /// <summary>エラー発生する一番古い時間（画面で表示用）</summary>
        private DateTime _errStTime;
        /// <summary>エラーステータス（画面で表示用）</summary>
        private int _errStatus;
        /// <summary>エラー内容（画面で表示用）</summary>
        private string _errMessage;
        /// <summary>同期要求データ情報</summary>
        private Dictionary<string, SyncReqDataWork> _syncReqDataDic;
        /// <summary>同期要求データに各状態のデータ件数</summary>
        private Dictionary<string, int> _syncReqDataCntDic;
        /// <summary>最大試行回数</summary>
        private int _maxRetryCount;
        /// <summary>同期要求データにテーブルリスト</summary>
        private List<string> _syncTalbeList;
        /// <summary>画面左下に表示用同期要求データ</summary>
        private SyncReqDataWork _syncDataForDisplay;

        /// <summary>関連マスタ設定のXML</summary>
        private const string XML_FILE_NAME = "SyncAssociatedDataList.xml";
        /// <summary>同期の状態(2:送受信完了)</summary>
        private const string SYNC_STATUS_FINISHED = "送信済";
        /// <summary>同期の状態(1:送受信中)</summary>
        private const string SYNC_STATUS_EXECUTING = "送信中...";
        /// <summary>同期の状態(0:送受信待機中)</summary>
        private const string SYNC_STATUS_WAITING = "送信待機中";

        /// <summary>データ件数計算用キー(未同期/再試行回数＜最大値)</summary>
        private const string DATACALC_NOSYNC = "-0";
        /// <summary>データ件数計算用キー(送受信中)</summary>
        private const string DATACALC_SYNCING = "-1"; 
        /// <summary>データ件数計算用キー(再試行回数が最大値になる)</summary>
        private const string DATACALC_SYNCERROR = "-2";
        # endregion

        #region プロパティ
        /// <summary>
        /// 画面に関連する情報
        /// </summary>
        public SynchConfirmDataSet.SynchConfirmDataTable SynchConfirmDataTable
        {
            get { return _synchConfirmDataTable; }
            set { this._synchConfirmDataTable = value; }
        }

        /// <summary>
        /// XMLからの関連するマスタ情報
        /// </summary>
        public Dictionary<string, List<ReferenceTable>> TableIDDicForCheckOn
        {
            get { return _tableIDDicForCheckOn; }
        }

        /// <summary>
        /// XMLからの関連するマスタ情報
        /// </summary>
        public Dictionary<string, List<ReferenceTable>> TableIDDicForCheckOff
        {
            get { return _tableIDDicForCheckOff; }
            set { _tableIDDicForCheckOff = value; }
        }

        /// <summary>
        /// 同期モード（0：手動モード　1：再同期モード）
        /// </summary>
        public int SyncMode
        {
            get { return _syncMode; }
        }

        /// <summary>
        /// 同期エラー有無（true：エラーあり　false：エラーなし）
        /// </summary>
        public bool IsError
        {
            get { return _isError; }
        }

        /// <summary>
        /// エラー発生する一番古い時間（画面で表示用）
        /// </summary>
        public DateTime ErrStTime
        {
            get { return _errStTime; }
        }

        /// <summary>
        /// エラーステータス（画面で表示用）
        /// </summary>
        public int ErrStatus
        {
            get { return _errStatus; }
        }

        /// <summary>
        /// エラー内容（画面で表示用）
        /// </summary>
        public string ErrMessage
        {
            get { return _errMessage; }
        }
        #endregion

        # region ■Constracter
        /// <summary>
        /// 同期状況確認 アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 同期状況確認アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchConfirmAcs()
        {
            try
            {
                // リモートオブジェクト取得
                _iSynchConfirmDB = (ISynchConfirmDB)MediationSynchConfirmDB.GetSynchConfirmDB();
                /// <summary>同期要求管理 アクセスクラス</summary>
                _synchExecuteAcs = new SynchExecuteAcs();

                //画面に関連する情報
                _synchConfirmDataTable = new SynchConfirmDataSet.SynchConfirmDataTable();
                //XMLからの関連するマスタ情報
                _tableIDDicForCheckOn = new Dictionary<string, List<ReferenceTable>>();
                //XMLからの関連するマスタ情報
                _tableIDDicForCheckOff = new Dictionary<string, List<ReferenceTable>>();
                //同期要求データ情報
                _syncReqDataDic = new Dictionary<string, SyncReqDataWork>();
                //同期要求データに各状態のデータ件数
                _syncReqDataCntDic = new Dictionary<string, int>();
                //同期要求データにテーブルリスト
                _syncTalbeList = new List<string>();

                //最大試行回数の取得
                _synchExecuteAcs.GetMaxRetryCount(out _maxRetryCount);
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                _iSynchConfirmDB = null;
            }
        }
        #endregion

        #region 同期要求データの検索
        /// <summary>
        /// 同期要求データの検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="maxRetryCount">最大試行回数</param>
        /// <param name="list">検索結果</param>
        /// <param name="err">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 同期要求データの検索の検索を行います。</br>
        /// <br>Programmer	: chenyk</br>
        /// <br>Date		: 2014/08/14</br>
        /// <br>Update Note : 2014/09/03 田建委</br>
        /// <br>管理番号    : 11070136-00 Redmine#43408</br>
        /// <br>            : ステータスが2、またMaxErrorCountまで到達していないものも取得する対応</br>
        /// </remarks>
        public int SerachErr(string enterpriseCode, int maxRetryCount, DateTime requireDateTime, ref ArrayList list, out string err)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            err = string.Empty;
            list = new ArrayList();

            try
            {
                SyncReqDataWork syncReqDataWork = new SyncReqDataWork();
                syncReqDataWork.EnterpriseCode = enterpriseCode;
                syncReqDataWork.CreateDateTime = requireDateTime;

                object syncReqDataParam = (object)syncReqDataWork;
                object syncReqDataOutObj1 = null;
                err = string.Empty;

                //同期要求エラー情報の取得
                status = _iSynchConfirmDB.SearchSyncReqErrData(out syncReqDataOutObj1, out err, syncReqDataParam, maxRetryCount);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    ArrayList list1 = (ArrayList)syncReqDataOutObj1;
                    if (list1 != null)
                    {
                        list.AddRange(list1);
                    }

                    /*
                    object syncReqDataOutObj2 = null;
                    status = _iSynchConfirmDB.SearchSyncReqErrDataByCreateDateTime(out syncReqDataOutObj2, out err, maxRetryCount, syncReqDataParam); // ADD 2014/09/03 田建委 Redmine#43408

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        ArrayList list2 = (ArrayList)syncReqDataOutObj2;

                        if (list2 != null)
                        {
                            list.AddRange(list2);
                        }

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    */
                }

                //作成日時によりソート
                if (list != null && list.Count > 0)
                {
                    SortSyncReqDataCompare sortSyncReqDataCompare = new SortSyncReqDataCompare();
                    list.Sort(sortSyncReqDataCompare);
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                list = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                err = ex.Message;
            }

            return status;
        }
        #endregion

        #region 同期状況確認の検索
        /// <summary>
        /// 同期状況確認の検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="errMessaage"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 同期状況確認の検索を行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        public int Search(string enterpriseCode, out string errMessaage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMessaage = string.Empty;

            try
            {
                _synchConfirmDataTable.Clear();

                SyncMngWork syncMngParamWork = new SyncMngWork();
                syncMngParamWork.EnterpriseCode = enterpriseCode;

                object param = (object)syncMngParamWork;
                object outObj = null;

                status = _iSynchConfirmDB.SearchSyncMngData(out outObj, out errMessaage, param, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //同期要求データの検索
                    status = SerachSyncReqData(enterpriseCode, ref errMessaage);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        ArrayList resultList = (ArrayList)outObj;

                        //DataTableへデータの格納
                        SetDataToDataTable(resultList);

                        //関連するマスタのXMLの読み込み
                        GetTableIDFromXML();
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //無し
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessaage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 同期要求データの検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="errMessaage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 同期要求データの検索を行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private int SerachSyncReqData(string enterpriseCode, ref string errMessaage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMessaage = string.Empty;

            try
            {
                //同期モード（0：手動モード　1：再同期モード）
                _syncMode = 0;
                //同期エラー有無（true：エラーあり　false：エラーなし）
                _isError = false;
                //同期要求データDictionary
                _syncReqDataDic = new Dictionary<string, SyncReqDataWork>();
                //同期要求データに各状態のデータ件数
                _syncReqDataCntDic = new Dictionary<string, int>();
                //同期要求データにテーブルリスト
                _syncTalbeList = new List<string>();

                #region 同期情報概略取得(各状態の件数を取得する)
                SyncReqDataWork syncReqDataWork = new SyncReqDataWork();
                syncReqDataWork.EnterpriseCode = enterpriseCode;

                object syncReqDataParam = (object)syncReqDataWork;
                object syncReqDataCountOutObj = null;

                status = _iSynchConfirmDB.GetSyncReqDataCount(out syncReqDataCountOutObj, out errMessaage, syncReqDataParam);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList syncReqDataCountList = (ArrayList)syncReqDataCountOutObj;

                    foreach (SyncReqDataWork work in syncReqDataCountList)
                    {
                        //同期要求データにテーブルを格納する(送受信完了の状態の判断用)
                        if (!_syncTalbeList.Contains(work.SyncTableID))
                        {
                            _syncTalbeList.Add(work.SyncTableID);
                        }

                        //同期要求データに各状態のデータ件数Dictionaryの構成：
                        //テーブルID-実行結果状態
                        // └データ件数
                        string dicKey = string.Empty;
                        if ((work.SyncExecRslt == 0) || (work.SyncExecRslt == 2 && work.RetryCount < _maxRetryCount))
                        {
                            dicKey = DATACALC_NOSYNC;
                        }
                        else if (work.SyncExecRslt == 1)
                        {
                            dicKey = DATACALC_SYNCING;
                        }
                        else if ((work.SyncExecRslt == 2 && work.RetryCount >= _maxRetryCount))
                        {
                            dicKey = DATACALC_SYNCERROR;
                        }

                        string key = work.SyncTableID + dicKey;
                        if (!_syncReqDataCntDic.ContainsKey(key))
                        {
                            _syncReqDataCntDic.Add(key, work.SyncDataCount);
                        }
                        else
                        {
                            _syncReqDataCntDic[key] += work.SyncDataCount;
                        }
                    }

                    //同期要求エラー情報の取得
                    object syncReqErrDataOutObj = null;
                    status = _iSynchConfirmDB.SearchSyncReqErrData(out syncReqErrDataOutObj, out errMessaage, syncReqDataParam, _maxRetryCount);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList syncReqErrDataList = (ArrayList)syncReqErrDataOutObj;

                        int index = 0;
                        foreach (SyncReqDataWork work in syncReqErrDataList)
                        {
                            if (index == 0)
                            {
                                _syncDataForDisplay = work;
                            }
                            index++;

                            if (!_syncReqDataDic.ContainsKey(work.SyncTableID))
                            {
                                _syncReqDataDic.Add(work.SyncTableID, work);
                            }
                        }
                    }

                }
                #endregion
            }
            catch(Exception ex)
            {
                errMessaage = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //同期モード（0：手動モード　1：再同期モード）
                _syncMode = 0;
                //同期エラー有無（true：エラーあり　false：エラーなし）
                _isError = false;
                //同期要求データDictionary
                _syncReqDataDic = new Dictionary<string, SyncReqDataWork>();
                //同期要求データに各状態のデータ件数
                _syncReqDataCntDic = new Dictionary<string, int>();
                //同期要求データにテーブルリスト
                _syncTalbeList = new List<string>();
            }

            return status;
 
        }

        /// <summary>
        /// DataTableへ同期管理マスタの格納
        /// </summary>
        /// <param name="resultList"></param>
        /// <remarks>
        /// <br>Note		: DataTableへ同期管理マスタの格納を行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private void SetDataToDataTable(ArrayList resultList)
        {
            if (resultList.Count > 0)
            {
                //同期モードの判断
                foreach (SyncMngWork syncMngWork in resultList)
                {
                    string SyncErrorKey = syncMngWork.SyncTableID + DATACALC_SYNCERROR; //エラー、再試行回数≧最大値

                    if (_syncReqDataCntDic.ContainsKey(SyncErrorKey))
                    {
                        //同期モード（0：手動モード　1：再同期モード）
                        _syncMode = 1;

                        _isError = true;

                        if (_syncDataForDisplay != null)
                        {
                            _errStTime = _syncDataForDisplay.CreateDateTime;
                            _errStatus = _syncDataForDisplay.ErrorStatus;
                            _errMessage = _syncDataForDisplay.ErrorContents;
                        }
                        break;
                    }
                }


                DataRow row;

                foreach (SyncMngWork syncMngWork in resultList)
                {
                    row = _synchConfirmDataTable.NewRow();

                    row[_synchConfirmDataTable.TableIDColumn.ColumnName] = syncMngWork.SyncTableID;
                    row[_synchConfirmDataTable.TableNameColumn.ColumnName] = syncMngWork.SyncTableName;

                    string lastSyncUpdDtTm = string.Empty;
                    if (syncMngWork.LastSyncUpdDtTm.ToString().Length == 14) // YYYYMMDDHHMMSS => yyyy年MM月dd日　xx:xx:xx
                    {
                        lastSyncUpdDtTm = syncMngWork.LastSyncUpdDtTm.ToString().Substring(0, 4) + "年" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(4, 2) + "月" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(6, 2) + "日　" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(8, 2) + ":" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(10, 2) + ":" +
                                     syncMngWork.LastSyncUpdDtTm.ToString().Substring(12, 2);
                    }

                    row[_synchConfirmDataTable.LastSyncUpdDtTmColumn.ColumnName] = lastSyncUpdDtTm;

                    int syncCndtinSta = 2;
                    string syncCndtinDiv = SYNC_STATUS_FINISHED;

                    //同期情報概略により、各送受信状態を判断する
                    if (_syncTalbeList == null || !_syncTalbeList.Contains(syncMngWork.SyncTableID))
                    {
                        //同期の状態(2:送受信完了)
                        syncCndtinSta = 2;
                        syncCndtinDiv = SYNC_STATUS_FINISHED;
                    }
                    else
                    {
                        string syncNormalKey = syncMngWork.SyncTableID + DATACALC_NOSYNC;  //未同期/再試行回数<最大値
                        string syncErrorKey = syncMngWork.SyncTableID + DATACALC_SYNCERROR; //エラー、再試行回数≧最大値
                        string syncIngKey = syncMngWork.SyncTableID + DATACALC_SYNCING; //送受信中

                        if (!_syncReqDataCntDic.ContainsKey(syncErrorKey) && _syncReqDataCntDic.ContainsKey(syncIngKey))
                        {
                            //同期の状態(1:送受信中)
                            syncCndtinSta = 1;
                            syncCndtinDiv = SYNC_STATUS_EXECUTING;
                        }
                        else
                        { 
                            //同期の状態(0:送受信待機中)
                            syncCndtinSta = 0;
                            syncCndtinDiv = SYNC_STATUS_WAITING;

                            if (_syncReqDataCntDic.ContainsKey(syncErrorKey))
                            {
                                int dataTotalCount = _syncReqDataCntDic[syncErrorKey]; //総件数
                                int errDataCount = _syncReqDataCntDic[syncErrorKey]; //エラー件数
                                string errorMeaage = string.Empty; //エラーメッセージ

                                if (_syncReqDataCntDic.ContainsKey(syncNormalKey))
                                {
                                    dataTotalCount += _syncReqDataCntDic[syncNormalKey];
                                }

                                if (_syncReqDataCntDic.ContainsKey(syncIngKey))
                                {
                                    dataTotalCount += _syncReqDataCntDic[syncIngKey];
                                }

                                //エラーメッセージ
                                if (_syncReqDataDic.ContainsKey(syncMngWork.SyncTableID))
                                {
                                    errorMeaage = _syncReqDataDic[syncMngWork.SyncTableID].ErrorContents;
                                }

                                string addMessage = "(データ件数：" + dataTotalCount + "件、エラー件数：" + errDataCount + "件、エラーメッセージ：" + errorMeaage + ")";
                                syncCndtinDiv += addMessage;
                            }
                        }
                    }

                    row[_synchConfirmDataTable.SyncCndtinStaColumn.ColumnName] = syncCndtinSta;
                    row[_synchConfirmDataTable.SyncCndtinDivColumn.ColumnName] = syncCndtinDiv;

                    row[_synchConfirmDataTable.SelectionColumn.ColumnName] = false;

                    _synchConfirmDataTable.Rows.Add(row);
                }

                _synchConfirmDataTable.DefaultView.Sort = string.Format("{0}", _synchConfirmDataTable.SyncCndtinStaColumn.ColumnName);
            }
        }

        /// <summary>
        /// 作成日時により同期要求データのソート
        /// </summary>
        /// <param name="obj1">同期要求データ1</param>
        /// <param name="obj2">同期要求データ2</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 作成日時により同期要求データのソートを行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private int SortSyncReqDataCompare(SyncReqDataWork obj1, SyncReqDataWork obj2)
        {
            int res = 0;

            if ((obj1 == null) && (obj2 == null))
            {
                return 0;
            }
            else if ((obj1 != null) && (obj2 == null))
            {
                return 1;
            }
            else if ((obj1 == null) && (obj2 != null))
            {
                return -1;
            }

            //作成日時により判断
            if (obj1.CreateDateTime > obj2.CreateDateTime)
            {
                res = 1;
            }
            else if (obj1.CreateDateTime < obj2.CreateDateTime)
            {
                res = -1;
            }

            return res;
        }

        /// <summary>
        /// XMLから関連するテーブルの取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: XMLから関連するテーブルを取得する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        private void GetTableIDFromXML()
        {
            _tableIDDicForCheckOn = new Dictionary<string, List<ReferenceTable>>();
            _tableIDDicForCheckOff = new Dictionary<string, List<ReferenceTable>>();
            string XMLFileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

            if (UserSettingController.ExistUserSetting(XMLFileName))
            {
                TableInfo tableInfo = UserSettingController.DeserializeUserSetting<TableInfo>(XMLFileName);

                if (tableInfo != null && tableInfo.TableList != null && tableInfo.TableList.Count > 0)
                {
                    foreach (TableItem tableItem in tableInfo.TableList)
                    {
                        //XMLからの関連するマスタFOR　CHECKON
                        if (!_tableIDDicForCheckOn.ContainsKey(tableItem.TableID))
                        {
                            _tableIDDicForCheckOn.Add(tableItem.TableID, tableItem.ReferenceTableList);
                        }

                        //XMLからの関連するマスタFOR　CHECKOFF
                        if (tableItem.ReferenceTableList.Count > 0)
                        {
                            foreach (ReferenceTable subTableID in tableItem.ReferenceTableList)
                            {
                                if (!_tableIDDicForCheckOff.ContainsKey(subTableID.ReferenceTableID))
                                {
                                    List<ReferenceTable> list = new List<ReferenceTable>();
                                    ReferenceTable referenceTable = new ReferenceTable();
                                    referenceTable.ReferenceTableID = tableItem.TableID;

                                    list.Add(referenceTable);
                                    _tableIDDicForCheckOff.Add(subTableID.ReferenceTableID, list);
                                }
                                else
                                {
                                    ReferenceTable referenceTable = new ReferenceTable();
                                    referenceTable.ReferenceTableID = tableItem.TableID;

                                    if (!_tableIDDicForCheckOff[subTableID.ReferenceTableID].Contains(referenceTable))
                                    {
                                        _tableIDDicForCheckOff[subTableID.ReferenceTableID].Add(referenceTable);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        # endregion
    }

    #region 比較用クラス

    /// <summary>
    ///作成日時により同期要求データのソート
    /// </summary>
    /// <remarks>
    /// <br>Note        : 作成日時により同期要求データのソートを行います。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class SortSyncReqDataCompare : IComparer
    {
        #region IComparer メンバ

        /// <summary>
        /// 比較用メソッド
        /// </summary>
        /// <param name="x">比較対象オブジェクト</param>
        /// <param name="y">比較対象オブジェクト</param>
        /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)オブジェクトの比較を行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2014/08/01</br>
        /// </remarks>
        public int Compare(object x, object y)
        {
            SyncReqDataWork obj1 = x as SyncReqDataWork;
            SyncReqDataWork obj2 = y as SyncReqDataWork;

            // 伝票印刷種別で比較
            return obj1.CreateDateTime.CompareTo(obj2.CreateDateTime);
        }

        #endregion
    }

    #endregion

    #region XML構成
    /// <summary>
    /// XML構成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: XML構成クラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class TableInfo
    {
        private List<TableItem> _tableList;

        public List<TableItem> TableList
        {
            get
            {
                if (_tableList == null)
                {
                    _tableList = new List<TableItem>();
                }
                return _tableList;
            }
            set
            {
                _tableList = value;
                if (_tableList == null)
                {
                    _tableList = new List<TableItem>();
                }
            }
        }
    }

    /// <summary>
    /// XML構成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: XML構成クラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class TableItem
    {
        private string _tableID;
        private List<ReferenceTable> _referenceTableList;

        public string TableID
        {
            get
            {
                return _tableID;
            }
            set
            {
                _tableID = value;
            }
        }

        public List<ReferenceTable> ReferenceTableList
        {
            get
            {
                if (_referenceTableList == null)
                {
                    _referenceTableList = new List<ReferenceTable>();
                }
                return _referenceTableList;
            }
            set
            {
                _referenceTableList = value;
                if (_referenceTableList == null)
                {
                    _referenceTableList = new List<ReferenceTable>();
                }
            }
        }
    }

    /// <summary>
    /// XML構成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: XML構成クラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class ReferenceTable
    {
        private string _referenceTableID;

        public string ReferenceTableID
        {
            get
            {
                return _referenceTableID;
            }
            set
            {
                _referenceTableID = value;
            }
        }
    }
    #endregion
}

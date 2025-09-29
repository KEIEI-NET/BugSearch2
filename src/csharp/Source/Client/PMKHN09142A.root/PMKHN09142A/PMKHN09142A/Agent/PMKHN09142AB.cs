//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作履歴アクセス
// プログラム概要   : 操作履歴リモートのアクセス結果を保持します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType      = IOprtnHisLogDB;
    using DBRecordType      = OprtnHisLogWork;
    using DBConditionType   = OprtnHisLogSrchWork;
    using DataSetType       = OperationHistoryLogDataSet;
    using DataTableType     = OperationHistoryLogDataSet.OperationHistoryLogDataTable;
    using DataRowType       = OperationHistoryLogDataSet.OperationHistoryLogRow;

    /// <summary>
    /// 操作履歴リモートクラスの代理人クラス
    /// </summary>
    public sealed class OperationHistoryLogAgent : OperationHistoryLog, IDisposable
    {
        #region <IDisposable Member/>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>
        /// 処分済みフラグを取得します。
        /// </summary>
        /// <value>処分済みフラグ</value>
        public bool Disposed { get { return _disposed; } }

        /// <summary>
        /// 処分します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトの処分フラグ</param>
        private void Dispose(bool disposing)
        {
            #region <Guard Phrase/>
            
            if (Disposed) return;

            #endregion  // <Guard Phrase/>

            // マネージオブジェクト
            if (disposing)
            {
                Reset();
            }
            // アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~OperationHistoryLogAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <アクセサ/>

        /// <summary>
        /// 操作履歴データDBのアクセサを取得します。
        /// </summary>
        /// <value>操作履歴データDBのアクセサ</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DBAccessType RealAccesser
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OprtnHisLogDBAccesser;
            }
        }

        /// <summary>操作履歴データDBのレコードリスト</summary>
        private List<DBRecordType> _recordList;
        /// <summary>
        /// 操作履歴データDBのレコードリストを取得します。
        /// </summary>
        /// <value>操作履歴データDBのレコードリスト</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public List<DBRecordType> RecordList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_recordList == null)
                {
                    _recordList = new List<DBRecordType>();
                }
                return _recordList;
            }
        }

        /// <summary>操作履歴データDBのデータセット</summary>
        private DataSetType _db;
        /// <summary>
        /// 操作履歴データDBのデータセットを取得します。
        /// </summary>
        /// <value>操作履歴データDBのデータセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataSetType DB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_db == null)
                {
                    _db = new DataSetType();
                }
                return _db;
            }
        }

        /// <summary>
        /// 操作履歴データDBのデータテーブルを取得します。
        /// </summary>
        /// <value>操作履歴データDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.OperationHistoryLog;
            }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OperationHistoryLogAgent() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 保持しているログをリセットします。
        /// </summary>
        public void Reset()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
            if (_recordList != null)
            {
                _recordList.Clear();
                _recordList = null;
            }
        }

        /// <summary>
        /// ログを更新します。
        /// </summary>
        /// <param name="searchingCondition">更新する条件</param>
        /// <returns>更新した操作履歴ログデータテーブル</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType RefreshLog(DBConditionType searchingCondition)
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            Reset();

            DBConditionType condition = null;
            if (searchingCondition is LogCondition)
            {
                condition = ((LogCondition)searchingCondition).CreateOprtnHisLogSrchWork();
            }
            else
            {
                condition = searchingCondition;
            }

            // アクセス結果（戻り値）を設定
            ArrayList searchedRecordList = new ArrayList();

            // 検索用パラメータを設定
            object objSearchedRecordList = searchedRecordList;
            object objSearchingCondition = condition;

            // 検索
            int status = RealAccesser.Search(
                ref objSearchedRecordList,
                objSearchingCondition,
                (int)DBAccessParameterNumber.Default,   // TODO:必要に応じて
                ConstantManagement.LogicalMode.GetData0 // TODO:必要に応じて
            );
            if (status.Equals((int)DBAccessStatus.NoRecord))        return Tbl; // 該当データなし
            if (status.Equals((int)DBAccessStatus.RecordNotFound))  return Tbl; // 該当データなし

            #region <Debug/>

            Debug.Assert(status.Equals(0), MsgUtil.GetMsg(status, ""));
            if (status.Equals(0)) Debug.WriteLine("DB件数：" + ((ArrayList)objSearchedRecordList).Count.ToString());

            #endregion  // <Debug/>

            // 該当データあり
            searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:リモートアクセス側で新たにnewしている
            foreach (object objSearchedRecord in searchedRecordList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;

                RecordList.Add(searchedRecord);

                Tbl.AddOperationHistoryLogRow(
                    searchedRecord.CreateDateTime,
                    searchedRecord.UpdateDateTime,
                    searchedRecord.EnterpriseCode,
                    searchedRecord.FileHeaderGuid,
                    searchedRecord.UpdEmployeeCode,
                    searchedRecord.UpdAssemblyId1,
                    searchedRecord.UpdAssemblyId2,
                    searchedRecord.LogicalDeleteCode,
                    searchedRecord.LogDataCreateDateTime,
                    searchedRecord.LogDataGuid,
                    searchedRecord.LoginSectionCd,
                    searchedRecord.LogDataKindCd,
                    searchedRecord.LogDataMachineName,
                    searchedRecord.LogDataAgentCd,
                    searchedRecord.LogDataAgentNm,
                    searchedRecord.LogDataObjBootProgramNm,
                    searchedRecord.LogDataObjAssemblyID,
                    searchedRecord.LogDataObjAssemblyNm,
                    searchedRecord.LogDataObjClassID,
                    searchedRecord.LogDataObjProcNm,
                    searchedRecord.LogDataOperationCd,
                    searchedRecord.LogOperaterDtProcLvl,
                    searchedRecord.LogOperaterFuncLvl,
                    searchedRecord.LogDataSystemVersion,
                    searchedRecord.LogOperationStatus,
                    searchedRecord.LogDataMassage,
                    searchedRecord.LogOperationData
                );
            }

            return Tbl;
        }

        #region <実験/>

        /// <summary>
        /// 探す実験
        /// </summary>
        [Conditional("DEBUG")]
        public void TestSearch()
        {
            OprtnHisLogSrchWork searchingCondition = new OprtnHisLogSrchWork();
            searchingCondition.EnterpriseCode = "0101150842020000";
            searchingCondition.St_LogDataCreateDateTime = new DateTime(2008, 8, 1, 0, 0, 0);
            searchingCondition.Ed_LogDataCreateDateTime = new DateTime(2008, 8, 31, 23, 59, 59);
            searchingCondition.LogDataKindCd = (int)LogDataKind.OperationLog;

            // アクセス結果（戻り値）を設定
            ArrayList searchedRecordList = new ArrayList();

            // 検索用パラメータを設定
            object objSearchedRecordList = searchedRecordList;
            object objSearchingCondition = searchingCondition;
            // 検索
            IOprtnHisLogDB accesser = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            int status = accesser.Search(
                ref objSearchedRecordList,
                objSearchingCondition,
                0,
                0
            );
            if (status.Equals(9))
            {
                Debug.WriteLine("ログ件数：0");
                return;
            }

            #region <Debug/>

            Debug.Assert(status.Equals(0), MsgUtil.GetMsg(status, ""));

            #endregion  // <Debug/>

            // 該当データあり
            searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:リモートアクセス側で新たにnewしている

            Debug.WriteLine("ログ件数：" + searchedRecordList.Count.ToString());
            
        }

        #endregion  // <実験/>
    }
}

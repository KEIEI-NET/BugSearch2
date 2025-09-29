//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : 従業員テーブルアクセスのアクセス結果を保持します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = EmployeeAcs;
    using DBRecordType  = Employee;
    using DataSetType   = EmployeeMasterDataSet;
    using DataTableType = EmployeeMasterDataSet.EmployeeMasterDataTable;
    using DataRowType   = EmployeeMasterDataSet.EmployeeMasterRow;

    /// <summary>
    /// 従業員テーブルアクセスクラスの代理人クラス
    /// </summary>
    public sealed class EmployeeAcsAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
    {
        #region <IDisposable Member/>

        /// <summary>
        /// 処分します。
        /// </summary>
        void IDisposable.Dispose()
        {
            base.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトの処分フラグ</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            // マネージオブジェクト
            if (disposing)
            {
            }
            // アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~EmployeeAcsAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>論理削除区分：有効</summary>
        private const int ENABLED_RECORD = 0;   // HACK:共通ファイルヘッダ（0：有効）

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public EmployeeAcsAgent() : base() { }

        /// <summary>
        /// 従業員マスタDBのデータテーブルを取得します。
        /// </summary>
        /// <value>従業員マスタDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.EmployeeMaster;
            }
        }

        /// <summary>従業員レコードマップ</summary>
        private Dictionary<string, Employee> _recordMap;
        /// <summary>
        /// 従業員レコードマップを取得します。
        /// </summary>
        /// <value>従業員レコードマップ</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public Dictionary<string, Employee> RecordMap
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_recordMap == null)
                {
                    _recordMap = new Dictionary<string, Employee>();
                }
                return _recordMap;
            }
        }

        /// <summary>
        /// 従業員レコードを取得します。
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public Employee FindRecord(string employeeCode)
        {
            return ( this._recordMap.ContainsKey(employeeCode) ) ? this._recordMap[employeeCode] : null;
        }

        /// <summary>
        /// DBの従業員コードのフォーマットに変換します。
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>9文字（右スペース詰）</returns>
        public static string ConvertEmployeeCodeInDBFormat(string employeeCode)
        {
            const int LENGTH_OF_DB_CODE = 9;
            const char PADDING_CHAR = ' ';
            return employeeCode.PadRight(LENGTH_OF_DB_CODE, PADDING_CHAR);
        }

        /// <summary>
        /// 従業員マスタDBのレコードリストを初期化します。
        /// </summary>
        /// <remarks>
        /// 権限レベルマスタDBより全従業員のレコードを取得します。
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();
            RecordMap.Clear();

            ArrayList searchedRecordArrayList = null;
            ArrayList searchedRecordDetailedArrayList = null;
            // 2008.12.09 modify start [8657]
            int status = RealAccesser.Search(//SearchAll(
                out searchedRecordArrayList,
                out searchedRecordDetailedArrayList,
                LoginInfoAcquisition.EnterpriseCode
            );
            // 2008.12.09 modify end [8657]

            // 該当データなし
            if (status.Equals((int)DBAccessStatus.NoRecord)) return;

            #region <Debug/>

            Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, LoginInfoAcquisition.EnterpriseCode));

            #endregion  // <Debug/>

            // 拠点情報
            SecInfoSetAcsAgent sectionDB = new SecInfoSetAcsAgent();

            // 該当データあり
            foreach (object objSearchedRecord in searchedRecordArrayList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                RecordList.Add(searchedRecord);
                RecordMap.Add(searchedRecord.EmployeeCode, searchedRecord);

                if (!searchedRecord.LogicalDeleteCode.Equals(ENABLED_RECORD)) continue;

                // 所属拠点名が設定されないため、拠点名称を取得し、設定
                searchedRecord.BelongSectionName = sectionDB.GetSectionName(searchedRecord.BelongSectionCode);

                Tbl.AddEmployeeMasterRow(
                    searchedRecord.EmployeeCode,
                    searchedRecord.Name,
                    searchedRecord.BelongSectionCode,
                    searchedRecord.BelongSectionName,
                    searchedRecord.AuthorityLevel1,
                    searchedRecord.AuthorityLevel2
                );
            }
        }
    }
}

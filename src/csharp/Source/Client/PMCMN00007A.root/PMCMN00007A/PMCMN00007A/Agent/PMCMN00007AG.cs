//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : オペレーションマスタローカルアクセスのアクセス結果を保持します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/04/02  修正内容 : セキュリティ管理部品の高速化改良対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
//using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = OperationLcDB;
    using DBRecordType  = Operation;
    using DataSetType   = OperationMasterDataSet;
    using DataTableType = OperationMasterDataSet.OperationMasterDataTable;
    using DataRowType   = OperationMasterDataSet.OperationMasterRow;

    /// <summary>
    /// オペレーションマスタローカルアクセスクラスの代理人クラス
    /// </summary>
    /// <br>Update Note: 2010/04/02 呉元嘯 セキュリティ管理部品の高速化改良対応</br>
    public sealed class OperationLcDBAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
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
        ~OperationLcDBAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>全てのアイテムを意味する数値</summary>
        private const int ALL_ITEM = -1;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OperationLcDBAgent() : base() { }

        /// <summary>
        /// オペレーションマスタDBのデータテーブルを取得します。
        /// </summary>
        /// <value>オペレーションマスタDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.OperationMaster;
            }
        }

        #region <カテゴリ/>

        /// <summary>カテゴリをまとめたデータテーブル</summary>
        private DataTableType _categoryTbl;
        /// <summary>
        /// カテゴリをまとめたデータテーブルを取得します。
        /// </summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType CategoryTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_categoryTbl == null)
                {
                    _categoryTbl = new DataTableType();

                    Dictionary<int, DataRowType> entryRowMap = new Dictionary<int, DataRowType>();
                    foreach (DataRowType opeRow in Tbl)
                    {
                        if (!entryRowMap.ContainsKey(opeRow.CategoryCode))
                        {
                            entryRowMap.Add(opeRow.CategoryCode, opeRow);
                            _categoryTbl.AddOperationMasterRow(
                                opeRow.OfferDate,
                                opeRow.CategoryCode,
                                opeRow.CategoryName,
                                opeRow.CategoryDspOdr,
                                opeRow.PgId,
                                opeRow.PgName,
                                opeRow.PgDspOdr,
                                opeRow.OperationCode,
                                opeRow.OperationName,
                                opeRow.OperationDspOdr
                            );
                        }
                    }
                }
                return _categoryTbl;
            }
        }

        /// <summary>
        /// カテゴリを取得します。
        /// </summary>
        /// <param name="pgId">プログラムID</param>
        /// <returns>カテゴリ</returns>
        public CodeNamePair<int> GetCategory(string pgId)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return new CodeNamePair<int>(
                    ((DataRowType)foundRows[0]).CategoryCode,
                    ((DataRowType)foundRows[0]).CategoryName
                );
            }
            else
            {
                return new CodeNamePair<int>(
                    ALL_ITEM,   // HACK:
                    string.Empty
                );
            }
        }

        #endregion  // <カテゴリ/>

        #region <機能/>

        /// <summary>機能をまとめたデータテーブル</summary>
        private DataTableType _pgTbl;
        /// <summary>
        /// 機能をまとめたデータテーブルを取得します。
        /// </summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType PgTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_pgTbl == null)
                {
                    _pgTbl = GetPgTblWhere(ALL_ITEM);
                }
                return _pgTbl;
            }
        }

        /// <summary>
        /// 機能データテーブルを取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <returns>機能データテーブル</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType GetPgTblWhere(int categoryCode)
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataTableType pgTbl = new DataTableType();
            Dictionary<string, DataRowType> entryRowMap = new Dictionary<string, DataRowType>();

            StringBuilder sqlWhere = new StringBuilder();
            if (categoryCode >= 0)
            {
                sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(categoryCode);
            }

            DataRow[] foundDataRows = Tbl.Select(sqlWhere.ToString());
            foreach (DataRow foundDataRow in foundDataRows)
            {
                DataRowType opeRow = (DataRowType)foundDataRow;
                if (!entryRowMap.ContainsKey(opeRow.PgId))
                {
                    entryRowMap.Add(opeRow.PgId, opeRow);
                    pgTbl.AddOperationMasterRow(
                        opeRow.OfferDate,
                        opeRow.CategoryCode,
                        opeRow.CategoryName,
                        opeRow.CategoryDspOdr,
                        opeRow.PgId,
                        opeRow.PgName,
                        opeRow.PgDspOdr,
                        opeRow.OperationCode,
                        opeRow.OperationName,
                        opeRow.OperationDspOdr
                    );
                }
            }
            return pgTbl;
        }

        /// <summary>
        /// プログラム名称を取得します。
        /// </summary>
        /// <param name="pgId">プログラムID</param>
        /// <returns>プログラム名称</returns>
        public string GetProgramName(string pgId)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return ((DataRowType)foundRows[0]).PgName;
            }
            else
            {
                return pgId;
            }
        }

        #endregion  // <機能/>

        #region <操作/>

        #region <廃止予定/>

        /// <summary>操作をまとめたデータテーブル</summary>
        private DataTableType _operationTbl;
        /// <summary>
        /// 操作をまとめたデータテーブルを取得します。
        /// </summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        [Obsolete("オペレーションコードは各機能で任意であるため、ユニークなテーブルにはなりません。")]
        public DataTableType OperationTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationTbl == null)
                {
                    _operationTbl = new DataTableType();

                    Dictionary<int, DataRowType> entryRowMap = new Dictionary<int, DataRowType>();
                    foreach (DataRowType opeRow in Tbl)
                    {
                        if (!entryRowMap.ContainsKey(opeRow.OperationCode))
                        {
                            entryRowMap.Add(opeRow.OperationCode, opeRow);
                            _operationTbl.AddOperationMasterRow(
                                opeRow.OfferDate,
                                opeRow.CategoryCode,
                                opeRow.CategoryName,
                                opeRow.CategoryDspOdr,
                                opeRow.PgId,
                                opeRow.PgName,
                                opeRow.PgDspOdr,
                                opeRow.OperationCode,
                                opeRow.OperationName,
                                opeRow.OperationDspOdr
                            );
                        }
                    }
                }
                return _operationTbl;
            }
        }

        /// <summary>
        /// 操作データテーブルを取得します。
        /// </summary>
        /// <param name="pgId">プログラムID</param>
        /// <returns>操作データテーブル</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        [Obsolete("カテゴリコードを指定した方が安全です。")]
        public DataTableType GetOperationTblWhere(string pgId)
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataTableType opeTbl = new DataTableType();
            Dictionary<int, DataRowType> entryRowMap = new Dictionary<int, DataRowType>();

            StringBuilder sqlWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(pgId))
            {
                sqlWhere.Append(DataSetType.ClmIdx.PgId);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(pgId));
            }

            DataRow[] foundDataRows = Tbl.Select(sqlWhere.ToString());
            foreach (DataRow foundDataRow in foundDataRows)
            {
                DataRowType opeRow = (DataRowType)foundDataRow;
                if (!entryRowMap.ContainsKey(opeRow.OperationCode))
                {
                    entryRowMap.Add(opeRow.OperationCode, opeRow);
                    opeTbl.AddOperationMasterRow(
                        opeRow.OfferDate,
                        opeRow.CategoryCode,
                        opeRow.CategoryName,
                        opeRow.CategoryDspOdr,
                        opeRow.PgId,
                        opeRow.PgName,
                        opeRow.PgDspOdr,
                        opeRow.OperationCode,
                        opeRow.OperationName,
                        opeRow.OperationDspOdr
                    );
                }
            }
            return opeTbl;
        }

        #endregion  // <廃止予定/>

        /// <summary>
        /// 設定対象のオペレーションコードかチェックします。
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>True:設定対象</returns>
        public bool IsTargetOperation(int categoryCode, string pgId, int operationCode)
        {
            DataRowType pgSettingRow = this.GetOperationSetting(categoryCode, pgId, operationCode);
            if (pgSettingRow != null) return true;

            DataRowType categorySettingRow = this.GetOperationSetting(categoryCode, OperationLimitation.ALL_CATEGORY_ID, operationCode);

            if (categorySettingRow != null) return true;

            return false;
        }

        /// <summary>
        /// 操作テーブル
        /// </summary>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>操作テーブル行</returns>
        private DataRowType GetOperationSetting(int categoryCode, string pgId, int operationCode)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(categoryCode);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationCode);

            DataRowType[] foundRows = (DataRowType[])Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return foundRows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 操作データテーブルを取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <returns>操作データテーブル</returns>
        public DataTableType GetOperationTblWhere(
            int categoryCode,
            string pgId
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataTableType opeTbl = new DataTableType();

            StringBuilder sqlWhere = new StringBuilder();
            if (categoryCode >= 0)
            {
                sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(categoryCode);
                sqlWhere.Append(ADOUtil.AND);
            }
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            DataRow[] foundDataRows = Tbl.Select(sqlWhere.ToString());
            foreach (DataRow foundDataRow in foundDataRows)
            {
                DataRowType opeRow = (DataRowType)foundDataRow;
                opeTbl.AddOperationMasterRow(
                    opeRow.OfferDate,
                    opeRow.CategoryCode,
                    opeRow.CategoryName,
                    opeRow.CategoryDspOdr,
                    opeRow.PgId,
                    opeRow.PgName,
                    opeRow.PgDspOdr,
                    opeRow.OperationCode,
                    opeRow.OperationName,
                    opeRow.OperationDspOdr
                );
            }

            return opeTbl;
        }

        /// <summary>
        /// オペレーション名称を取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>オペレーション名称</returns>
        public string GetOperationName(
            int categoryCode,
            string pgId,
            int operationCode
        )
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(categoryCode);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationCode);

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return ((DataRowType)foundRows[0]).OperationName;
            }
            else
            {
                return operationCode.ToString();
            }
        }

        #endregion  // <操作/>

        /// <summary>
        /// オペレーションマスタDBのレコードリストを初期化します。
        /// </summary>
        /// <remarks>
        /// オペレーションマスタDBのレコードを全件取得します。
        /// <br>Update Note: 2010/04/02 呉元嘯 セキュリティ管理部品の高速化改良対応</br>
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();

            // --------UPD 2010/04/02-------->>>>>
            #region [DEL]
            //// アクセス条件を設定
            //List<DBRecordType> searchingConditionList = new List<DBRecordType>();
            //{
            //    // TODO:▼条件に合わせて修正
            //    DBRecordType condition1 = new DBRecordType();
            //    condition1.CategoryCode = (int)EntityUtil.CategoryCode.Part;
            //    condition1.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition1);

            //    DBRecordType condition2 = new DBRecordType();
            //    condition2.CategoryCode = (int)EntityUtil.CategoryCode.Entry;
            //    condition2.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition2);

            //    DBRecordType condition3 = new DBRecordType();
            //    condition3.CategoryCode = (int)EntityUtil.CategoryCode.Update;
            //    condition3.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition3);

            //    DBRecordType condition4 = new DBRecordType();
            //    condition4.CategoryCode = (int)EntityUtil.CategoryCode.Reference;
            //    condition4.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition4);

            //    DBRecordType condition5 = new DBRecordType();
            //    condition5.CategoryCode = (int)EntityUtil.CategoryCode.Report;
            //    condition5.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition5);

            //    DBRecordType condition6 = new DBRecordType();
            //    condition6.CategoryCode = (int)EntityUtil.CategoryCode.MasterMaintenance;
            //    condition6.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition6);

            //    DBRecordType condition7 = new DBRecordType();
            //    condition7.CategoryCode = (int)EntityUtil.CategoryCode.Others;
            //    condition7.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition7);

            //    DBRecordType condition8 = new DBRecordType();
            //    condition8.CategoryCode = (int)EntityUtil.CategoryCode.AllSetting;
            //    condition8.OperationCode = ALL_ITEM;
            //    searchingConditionList.Add(condition8);
            //    // ▲
            //}
            //#region <ほぼお約束/>

            //foreach (DBRecordType searchingCondition in searchingConditionList)
            //{
            //    // アクセス結果（戻り値）を設定
            //    ArrayList searchedRecordList = new ArrayList();

            //    // 検索用パラメータを設定
            //    object objSearchedRecordList = searchedRecordList;
            //    object objSearchingCondition = searchingCondition;
            //    // 検索
            //    int status = RealAccesser.Search(
            //        ref objSearchedRecordList,
            //        objSearchingCondition,
            //        (int)DBAccessParameterNumber.Default,   // TODO:必要に応じて
            //        ConstantManagement.LogicalMode.GetData0 // TODO:必要に応じて
            //    );
            //    if (status.Equals((int)DBAccessStatus.NoRecord)) continue;  // 該当データなし

            //    #region <Debug/>

            //    Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, searchingCondition.CategoryCode));

            //    #endregion  // <Debug/>

            //    // 該当データあり
            //    searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:ローカルアクセス側で新たにnewしている
            //    foreach (object objSearchedRecord in searchedRecordList)
            //    {
            //        DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
            //        RecordList.Add(searchedRecord);

            //        Tbl.AddOperationMasterRow(
            //            DateTimeUtil.ToDateTime(searchedRecord.OfferDate),
            //            searchedRecord.CategoryCode,
            //            searchedRecord.CategoryName,
            //            searchedRecord.CategoryDspOdr,
            //            searchedRecord.PgId,
            //            searchedRecord.PgName,
            //            searchedRecord.PgDspOdr,
            //            searchedRecord.OperationCode,
            //            searchedRecord.OperationName,
            //            searchedRecord.OperationDspOdr
            //        );
            //    }
            //}

            //#endregion  // <ほぼお約束/>
            #endregion

            // アクセス結果（戻り値）を設定
            ArrayList searchedRecordList = new ArrayList();
            // 検索用パラメータを設定
            object objSearchedRecordList = searchedRecordList;
            // 検索
            int status = RealAccesser.SearchAll(
                ref objSearchedRecordList,
                (int)DBAccessParameterNumber.Default,
                ConstantManagement.LogicalMode.GetData0
            );
            searchedRecordList = (ArrayList)objSearchedRecordList;
            foreach (object objSearchedRecord in searchedRecordList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                RecordList.Add(searchedRecord);

                Tbl.AddOperationMasterRow(
                    DateTimeUtil.ToDateTime(searchedRecord.OfferDate),
                    searchedRecord.CategoryCode,
                    searchedRecord.CategoryName,
                    searchedRecord.CategoryDspOdr,
                    searchedRecord.PgId,
                    searchedRecord.PgName,
                    searchedRecord.PgDspOdr,
                    searchedRecord.OperationCode,
                    searchedRecord.OperationName,
                    searchedRecord.OperationDspOdr
                );
            }
            // --------UPD 2010/04/02--------<<<<<

        }
    }
}

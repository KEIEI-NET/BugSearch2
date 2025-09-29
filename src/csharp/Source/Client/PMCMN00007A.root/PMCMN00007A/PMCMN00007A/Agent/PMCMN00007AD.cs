//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : 権限レベルマスタローカルアクセスのアクセス結果を保持します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = AuthorityLevelLcDB;
    using DBRecordType  = AuthorityLevel;
    using DataSetType   = AuthorityLevelMasterDataSet;
    using DataTableType = AuthorityLevelMasterDataSet.AuthorityLevelMasterDataTable;
    using DataRowType   = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;

    using JobTypeDataSet    = AuthorityLevelMasterDataSet;
    using JobTypeDataTable  = AuthorityLevelMasterDataSet.AuthorityLevelMasterDataTable;

    using EmploymentFormDataSet     = AuthorityLevelMasterDataSet;
    using EmploymentFormDataTable   = AuthorityLevelMasterDataSet.AuthorityLevelMasterDataTable;

    /// <summary>
    /// 権限レベルマスタローカルアクセスクラスの代理人クラス
    /// </summary>
    public sealed class AuthorityLevelLcDBAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
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
                if (_jobTypeTbl != null)
                {
                    _jobTypeTbl.Dispose();
                    _jobTypeTbl = null;
                }
                if (_employmentFormTbl != null)
                {
                    _employmentFormTbl.Dispose();
                    _employmentFormTbl = null;
                }
            }
            // アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~AuthorityLevelLcDBAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <職種/>

        /// <summary>職種データテーブル</summary>
        private DataTableType _jobTypeTbl;
        /// <summary>
        /// 職種データテーブルを取得します。
        /// </summary>
        /// <value>職種データテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType JobTypeTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_jobTypeTbl == null)
                {
                    string sqlWhere = JobTypeDataSet.ClmIdx.AuthorityLevelDiv.ToString();
                    sqlWhere += ADOUtil.EQ;
                    sqlWhere += ((int)JobTypeDataSet.AuthorityLevelDiv.JobType).ToString();

                    _jobTypeTbl = ADOUtil.CreateDataTable<JobTypeDataTable>(Tbl.Select(sqlWhere));
                }
                return _jobTypeTbl;
            }
        }

        /// <summary>
        /// 職種名を取得します。
        /// </summary>
        /// <remarks>
        /// 該当名がない場合、<code>string.Empty</code>を返します。
        /// </remarks>
        /// <param name="authorityLivelCd">権限レベルコード</param>
        /// <returns>職種名</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public string GetJobTypeName(int authorityLivelCd)
        {
            #region <Guard Phrase/>
            
            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
            
            #endregion  // <Guard Phrase/>
            
            return GetAuthorityLevelName(JobTypeTbl, authorityLivelCd);
        }

        #endregion  // <職種/>

        #region <雇用形態/>

        /// <summary>雇用形態データテーブル</summary>
        private EmploymentFormDataTable _employmentFormTbl;
        /// <summary>
        /// 雇用形態データテーブルを取得します。
        /// </summary>
        /// <value>雇用形態データテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public EmploymentFormDataTable EmploymentFormTbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_employmentFormTbl == null)
                {
                    string sqlWhere = EmploymentFormDataSet.ClmIdx.AuthorityLevelDiv.ToString();
                    sqlWhere += ADOUtil.EQ;
                    sqlWhere += ((int)EmploymentFormDataSet.AuthorityLevelDiv.EmploymentForm).ToString();

                    _employmentFormTbl = ADOUtil.CreateDataTable<EmploymentFormDataTable>(Tbl.Select(sqlWhere));
                }
                return _employmentFormTbl;
            }
        }

        /// <summary>
        /// 雇用形態名を取得します。
        /// </summary>
        /// <remarks>
        /// 該当名がない場合、<code>string.Empty</code>を返します。
        /// </remarks>
        /// <param name="authorityLivelCd">権限レベルコード</param>
        /// <returns>雇用形態名</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public string GetEmploymentFormName(int authorityLivelCd)
        {
            #region <Guard Phrase/>
            
            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
            
            #endregion  // <Guard Phrase/>
            
            return GetAuthorityLevelName(EmploymentFormTbl, authorityLivelCd);
        }

        #endregion  // <雇用形態/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public AuthorityLevelLcDBAgent() : base() { }

        /// <summary>
        /// 権限レベルマスタDBのデータテーブルを取得します。
        /// </summary>
        /// <value>権限レベルマスタDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>
                
                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
                
                #endregion  // <Guard Phrase/>

                return base.DB.AuthorityLevelMaster;
            }
        }

        /// <summary>
        /// 権限レベルマスタDBのレコードリストを初期化します。
        /// </summary>
        /// <remarks>
        /// 権限レベルマスタDBより以下の条件のレコードを取得します。<br/>
        /// ・権限レベル区分 = 0：職種<br/>
        /// ・権限レベル区分 = 1：雇用形態
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();

            // アクセス条件を設定
            List<DBRecordType> searchingConditionList = new List<DBRecordType>();
            {
                // TODO:▼条件に合わせて修正
                DBRecordType condition1 = new DBRecordType();
                condition1.AuthorityLevelDiv = (int)DataSetType.AuthorityLevelDiv.JobType;
                searchingConditionList.Add(condition1);

                DBRecordType condition2 = new DBRecordType();
                condition2.AuthorityLevelDiv = (int)DataSetType.AuthorityLevelDiv.EmploymentForm;
                searchingConditionList.Add(condition2);
                // ▲
            }

            #region <ほぼお約束/>

            foreach (DBRecordType searchingCondition in searchingConditionList)
            {
                // アクセス結果（戻り値）を設定
                ArrayList searchedRecordList = new ArrayList();

                // 検索用パラメータを設定
                object objSearchedRecordList = searchedRecordList;
                object objSearchingCondition = searchingCondition;
                // 検索
                int status = RealAccesser.Search(
                    ref objSearchedRecordList,
                    objSearchingCondition,
                    (int)DBAccessParameterNumber.Default,   // TODO:必要に応じて
                    ConstantManagement.LogicalMode.GetData0 // TODO:必要に応じて
                );
                if (status.Equals((int)DBAccessStatus.NoRecord)) continue;   // 該当データなし

                #region <Debug/>

                Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, searchingCondition.AuthorityLevelDiv));

                #endregion  // <Debug/>

                // 該当データあり
                searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:ローカルアクセス側で新たにnewしている
                foreach (object objSearchedRecord in searchedRecordList)
                {
                    DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                    RecordList.Add(searchedRecord);

                    Tbl.AddAuthorityLevelMasterRow(
                        DateTimeUtil.ToDateTime(searchedRecord.OfferDate),
                        searchedRecord.AuthorityLevelDiv,
                        searchedRecord.AuthorityLevelCd,
                        searchedRecord.AuthorityLevelNm
                    );
                }
            }

            #endregion  // <ほぼお約束/>
        }

        /// <summary>
        /// 権限レベル名称を取得します。
        /// </summary>
        /// <remarks>
        /// 該当名がない場合、<code>string.Empty</code>を返します。
        /// </remarks>
        /// <param name="table">権限レベルマスタDBのデータテーブル</param>
        /// <param name="authorityLivelCd">権限レベルコード</param>
        /// <returns>権限レベル名称</returns>
        private static string GetAuthorityLevelName(
            DataTableType table,
            int authorityLivelCd
        )
        {
            string sqlWhere = DataSetType.ClmIdx.AuthorityLevelCd.ToString();
            sqlWhere += ADOUtil.EQ + authorityLivelCd.ToString();

            DataRow[] foundRows = table.Select(sqlWhere);
            if (foundRows.Length > 0)
            {
                const int SINGLE_ROW = 0;   // 単一行
                return ((DataRowType)foundRows[SINGLE_ROW]).AuthorityLevelNm;
            }
            return string.Empty;
        }
    }
}

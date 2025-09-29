//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限取得部品
// プログラム概要   : 以下のクラスのFacade(窓口)となります。
//                  : ・オペレーション設定マスタリモート
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
//#define ASSERTION

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    using DBAccessType  = IOperationStDB;
    using DBRecordType  = OperationStWork;
    using DataSetType   = OperationSettingMasterDataSet;
    using DataTableType = OperationSettingMasterDataSet.OperationSettingMasterDataTable;
    using DataRowType   = OperationSettingMasterDataSet.OperationSettingMasterRow;

    #region <列挙型/>

    /// <summary>
    /// オペレーション権限（列挙体）
    /// </summary>
    public enum OperationLimit : int
    {
        /// <summary>可。オペレーション可能でログ書き込み不要。</summary>
        Enable = 0,
        /// <summary>可(ログ記録)。オペレーション可能で、ログ書き込み必要。</summary>
        EnableWithLog = 1,
        /// <summary>不可。オペレーションは不可。</summary>
        Disable = 2
    }

    /// <summary>
    /// DBアクセスが返すステータス値の列挙体
    /// </summary>
    public enum DBAccessStatus : int
    {
        /// <summary>正常状態の値</summary>
        Normal = (int)ConstantManagement.DB_Status.ctDB_NORMAL,// = 0;
        /// <summary>該当レコードなし</summary>
        RecordNotFound = 4,
        /// <summary>レコードが既に存在する</summary>
        RecordIsExisted = 5,
        /// <summary>該当レコードなし</summary>
        NoRecord = 9,
        /// <summary>異常状態の値</summary>
        Error = 99,
        /// <summary>リモートエラー</summary>
        RemoteError = 1000
    }

    /// <summary>
    /// DBアクセスのパラメータ数値の列挙体
    /// </summary>
    public enum DBAccessParameterNumber
    {
        /// <summary>デフォルト値</summary>
        Default = 0
    }

    /// <summary>
    /// カテゴリ属性
    /// </summary>
    public enum CategoryAttribute : int
    {
        /// <summary>ロール（業務）</summary>
        Activity = 0,
        /// <summary>ロール（権限）</summary>
        Authority = 1,
        /// <summary>その他</summary>
        Other = 2
    }

    #endregion  // <列挙型/>

    /// <summary>
    /// 操作権限取得部品クラス
    /// </summary>
    public class OperationLimitation : IDisposable
    {
        #region <IDisposable Member/>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>
        /// 処分済みフラグを取得します。
        /// </summary>
        /// <value>後始末済みフラグ</value>
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
        protected virtual void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (Disposed) return;

            #endregion  // <Guard Phrase/>

            // ↓マネージオブジェクト
            if (disposing)
            {
                Reset();
            }
            // ↓アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~OperationLimitation()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <オペレーション設定マスタDB/>

        /// <summary>オペレーション設定マスタDBのアクセサ</summary>
        private DBAccessType _operationStDBAccesser;
        /// <summary>
        /// オペレーション設定マスタDBのアクセサを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのアクセサ</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected DBAccessType OperationStDBAccesser
        {
            get
            {
                #region <Guard Phrase/>
                
                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationStDBAccesser == null)
                {
                    _operationStDBAccesser = MediationOperationStDB.GetOperationStDB();
                }
                return _operationStDBAccesser;
            }
        }

        #endregion  // <オペレーション設定マスタDB/>

        /// <summary>全カテゴリを表すプログラムID</summary>
        public const string ALL_CATEGORY_ID = "";

        #region <アクセサ/>

        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        /// <remarks>国2桁 + 県2桁 + 業種2桁 + ユーザーコード10桁</remarks>
        /// <value>企業コード</value>
        protected static string EnterpriseCode
        {
            get { return LoginInfoAcquisition.EnterpriseCode; }
        }

        /// <summary>オペレーション設定マスタDBのデータセット</summary>
        private DataSetType _operationSettingMasterDB;
        /// <summary>
        /// オペレーション設定マスタDBのデータセットを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのデータセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected DataSetType OperationSettingMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationSettingMasterDB == null)
                {
                    _operationSettingMasterDB = new DataSetType();
                }
                return _operationSettingMasterDB;
            }
        }

        /// <summary>
        /// オペレーション設定マスタDBのデータテーブルを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected DataTableType MainTbl
        {
            get
            {             
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationSettingMasterDB.OperationSettingMaster;
            }
        }

        /// <summary>オペレーション設定マスタDBレコードのリスト</summary>
        private List<DBRecordType> _operationStWorkList;
        /// <summary>
        /// オペレーション設定マスタDBレコードのリストを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBレコードのリスト</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected List<DBRecordType> OperationStWorkList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationStWorkList == null)
                {
                    _operationStWorkList = new List<DBRecordType>();
                    foreach (DataRowType row in MainTbl)
                    {
                        DBRecordType record = new DBRecordType();

                        record.CreateDateTime = row.CreateDateTime;
                        record.UpdateDateTime = row.UpdateDateTime;
                        record.EnterpriseCode = row.EnterpriseCode;
                        record.FileHeaderGuid = row.FileHeaderGuid;
                        record.UpdEmployeeCode = row.UpdEmployeeCode;
                        record.UpdAssemblyId1 = row.UpdAssemblyId1;
                        record.UpdAssemblyId2 = row.UpdAssemblyId2;
                        record.LogicalDeleteCode = row.LogicalDeleteCode;
                        record.OperationStDiv = row.OperationStDiv;
                        record.CategoryCode = row.CategoryCode;
                        record.PgId = row.PgId;
                        record.OperationCode = row.OperationCode;
                        record.AuthorityLevel1 = row.AuthorityLevel1;
                        record.AuthorityLevel2 = row.AuthorityLevel2;
                        record.EmployeeCode = row.EmployeeCode;
                        record.LimitDiv = row.LimitDiv;
                        record.LimitDiv = row.ApplyStartDate;
                        record.ApplyEndDate = row.ApplyEndDate;

                        _operationStWorkList.Add(record);
                    }
                }
                return _operationStWorkList;
            }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OperationLimitation() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// オペレーション権限を取得します。
        /// </summary>
        /// <param name="limitDivOfOperationSettingMaster">オペレーション設定マスタの制限区分(0:ログ 1:制限)</param>
        /// <returns>オペレーション設定マスタの制限区分 + 1</returns>
        /// <exception cref="InvalidCastException">0:ログ または 1:制限 以外の制限区分を指定しました。</exception>
        protected static OperationLimit GetOperationLimit(int limitDivOfOperationSettingMaster)
        {
            #region <Guard Phrase/>

            switch ((DataSetType.LimitDiv)limitDivOfOperationSettingMaster)
            {
                case DataSetType.LimitDiv.WithLog:
                    break;
                case DataSetType.LimitDiv.Limitation:
                    break;
            }

            #endregion // <Guard Phrase/>

            return (OperationLimit)(limitDivOfOperationSettingMaster + 1);
        }

        #region <初期化処理/>

        /// <summary>
        /// 初期読み込み処理を行います。
        /// </summary>
        /// <remarks>
        /// 起動元プログラムから渡されたカテゴリーコード、プログラムODを元に、
        /// そのプログラムと、そのプログラムの属するカテゴリーに関する全オペレーションの全設定を取得します。
        /// </remarks>
        /// <param name="categoryCode">起動元プログラムのカテゴリコード</param>
        /// <param name="pgId">起動元プログラムのプログラムID</param>
        /// <returns>初期読み込みに成功したらtrue</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public bool SearchInitial(
            int categoryCode,
            string pgId
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            Reset();

            try
            {
                // アクセス条件を設定
                DBRecordType searchingCondition = new DBRecordType();
                searchingCondition.EnterpriseCode = EnterpriseCode;

                if (categoryCode >= 0)  // TODO:企業コードのみのスイッチ
                {
                    // TODO:企業コード以外を指定するとエラーとなる？
                    //searchingCondition.CategoryCode = categoryCode;
                    //searchingCondition.PgId = pgId;
                }

                // アクセス結果（戻り値）を設定
                ArrayList searchedRecordList = new ArrayList();

                // 検索用パラメータを設定
                object objSearchedRecordList = searchedRecordList;
                object objSearchingCondition = searchingCondition;
                // 検索
                int status = OperationStDBAccesser.Search(
                    ref objSearchedRecordList,
                    objSearchingCondition,
                    (int)DBAccessParameterNumber.Default,   // TODO:必要に応じて
                    ConstantManagement.LogicalMode.GetData0 // TODO:必要に応じて
                );
                if (status.Equals((int)DBAccessStatus.NoRecord)) return true;   // 該当データなし

                #region <Debug/>

                #if ASSERTION
                    Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, categoryCode, pgId));
                #endif

                #endregion  // <Debug/>

                // 該当データあり
                searchedRecordList = (ArrayList)objSearchedRecordList;  // TODO:リモートアクセス側で新たにnewしている
                foreach (object objSearchedRecord in searchedRecordList)
                {
                    DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;

                    MainTbl.AddOperationSettingMasterRow(
                        searchedRecord.CreateDateTime,
                        searchedRecord.UpdateDateTime,
                        searchedRecord.EnterpriseCode,
                        searchedRecord.FileHeaderGuid,
                        searchedRecord.UpdEmployeeCode,
                        searchedRecord.UpdAssemblyId1,
                        searchedRecord.UpdAssemblyId2,
                        searchedRecord.LogicalDeleteCode,
                        searchedRecord.OperationStDiv,
                        searchedRecord.CategoryCode,
                        searchedRecord.PgId,
                        searchedRecord.OperationCode,
                        searchedRecord.AuthorityLevel1,
                        searchedRecord.AuthorityLevel2,
                        searchedRecord.EmployeeCode,
                        searchedRecord.LimitDiv,
                        searchedRecord.ApplyStartDate,
                        searchedRecord.ApplyEndDate
                    );
                }

                return true;
            }
            catch (Exception ex) // HACK:IOperationStDB.Search()が投げる例外は？
            {
                #region <Debug/>

                #if ASSERTION
                    Debug.Assert(false, ex.ToString());
                #endif
                Debug.WriteLine(ex.ToString());

                #endregion  // <Debug/>

                return false;
            }
        }

        /// <summary>
        /// リセットします。
        /// </summary>
        private void Reset()
        {
            if (_operationSettingMasterDB != null) _operationSettingMasterDB.Dispose();
            _operationSettingMasterDB = null;

            if (_operationStWorkList != null) _operationStWorkList.Clear();
            _operationStWorkList = null;
        }

        #endregion  // <初期化処理/>

        #region <操作権限取得処理/>

        /// <summary>
        /// 操作権限取得処理を行います。
        /// </summary>
        /// <remarks>
        /// ①起動元プログラムから渡されたカテゴリーコード、プログラムID、オペレーションコード、従業員データを元に、
        /// 初期読み込み処理で取得したデータから該当データを検索します。<br/>
        /// ②カテゴリ全体設定である場合、カテゴリ全体の操作権限を返します。
        /// </remarks>
        /// <param name="categoryCode">起動元のカテゴリコード</param>
        /// <param name="pgId">起動元のプログラムID</param>
        /// <param name="operationCode">対象のオペレーションコード</param>
        /// <param name="employee">対象の従業員（起動元はログイン担当者を指定する）</param>
        /// <returns>
        /// ・Enable：可。オペレーション可能でログ書き込み不要。…該当レコード無し<br/>
        /// ・EnableWithLog：可(ログ記録)。オペレーション可能で、ログ書き込み必要。…制限区分=0:ログ<br/>
        /// ・Disable：不可。オペレーションは不可。…制限区分=1:制限
        /// </returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <exception cref="ArgumentNullException">対象の従業員がnullです。</exception>
        public OperationLimit GetOperationLimit(
            int categoryCode,
            string pgId,
            int operationCode,
            Employee employee
        )
        {
            #region <Guard Pharse/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");
            if (employee == null) throw new ArgumentNullException("employee is null.");

            #endregion  // <Guard Pharse/>

            DataRowType[] categorySettingRows = GetCategorySettingRows(categoryCode, operationCode, employee.EmployeeCode);
            if (categorySettingRows.Length > 0)
            {
                // カテゴリ全体設定あり（を優先）
                const int SINGLE_ROW = 0;   // 単一行
                return GetOperationLimit(categorySettingRows[SINGLE_ROW].LimitDiv);
                //
            }   // カテゴリ全体設定なし

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));
            // OperationStDiv=2 AND EmployeeCode='employeeCode'
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv).Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.EmployeeCode).Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.EmployeeCode).Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(employee.EmployeeCode));

            // 従業員コードで取得
            OperationLimit employeeLimit = GetOperationLimitWhere(sqlWhere.ToString());

            // 職種で取得
            OperationLimit jobTypeLimit = GetOperationLimitWhereAuthorityLevel1(
                categoryCode,
                pgId,
                operationCode,
                employee.AuthorityLevel1
            );

            // 雇用形態で取得
            OperationLimit employmentFormLimit = GetOperationLimitWhereAuthorityLevel2(
                categoryCode,
                pgId,
                operationCode,
                employee.AuthorityLevel2
            );

            // なし < ログ < 制限 の順に最も重たい制限を有効にする
            return (OperationLimit)Math.Max(
                Math.Max((int)jobTypeLimit, (int)employmentFormLimit),
                (int)employeeLimit
            );
        }

        /// <summary>
        /// オペレーション権限の値を取得します。
        /// </summary>
        /// <param name="filterExpression">オペレーション設定マスタDBを検索する条件</param>
        /// <returns>
        /// オペレーション権限の値<br/>
        /// ・Enable：可。オペレーション可能でログ書き込み不要。…該当レコード無し<br/>
        /// ・EnableWithLog：可(ログ記録)。オペレーション可能で、ログ書き込み必要。…制限区分=0:ログ<br/>
        /// ・Disable：不可。オペレーションは不可。…制限区分=1:制限
        /// </returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <exception cref="InvalidCastException">オペレーション設定マスタ.制限区分の値が不正です。</exception>
        protected OperationLimit GetOperationLimitWhere(string filterExpression)
        {
            #region <Guard Pharse/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Pharse/>

            DataRow[] foundRows = MainTbl.Select(filterExpression);
            // 該当レコード無し
            if (foundRows.Length.Equals(0)) return OperationLimit.EnableWithLog;

            // 該当レコードあり
            // 権限レベル1(職種)、権限レベル2(雇用形態)、従業員コードは3者択一のため、単一行となる
            const int SINGLE_ROW = 0;
            DataRowType foundRow = (DataRowType)foundRows[SINGLE_ROW];

            switch (foundRow.LimitDiv)
            {
                case (int)DataSetType.LimitDiv.WithLog:
                    return OperationLimit.EnableWithLog;

                case (int)DataSetType.LimitDiv.Limitation:
                    return OperationLimit.Disable;

                default:
                    throw new InvalidCastException(
                        "オペレーション設定マスタ.制限区分の値が不正です。(=" + foundRow.LimitDiv.ToString() + ")"  // LITERAL:
                    );
            }
        }

        /// <summary>
        /// 権限レベル1(職種)の条件で操作権限を取得します。
        /// </summary>
        /// <remarks>
        /// カテゴリ全体設定である場合、カテゴリ全体の操作権限を返します。
        /// </remarks>
        /// <param name="categoryCode">起動元のカテゴリコード</param>
        /// <param name="pgId">起動元のプログラムID</param>
        /// <param name="operationCode">対象のオペレーションコード</param>
        /// <param name="jobType">対象の権限レベル1(職種)</param>
        /// <returns>
        /// ・Enable：可。オペレーション可能でログ書き込み不要。…該当レコード無し<br/>
        /// ・EnableWithLog：可(ログ記録)。オペレーション可能で、ログ書き込み必要。…制限区分=0:ログ<br/>
        /// ・Disable：不可。オペレーションは不可。…制限区分=1:制限
        /// </returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected OperationLimit GetOperationLimitWhereAuthorityLevel1(
            int categoryCode,
            string pgId,
            int operationCode,
            int jobType
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataRowType[] categorySettingRows = GetCategorySettingRowsWhatAuthorityLevel1(categoryCode, operationCode, jobType);
            if (categorySettingRows.Length > 0)
            {
                // カテゴリ全体設定あり（を優先）
                const int SINGLE_ROW = 0;   // 単一行
                return GetOperationLimit(categorySettingRows[SINGLE_ROW].LimitDiv);
                //
            }   // カテゴリ全体設定なし

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));
            // OperationStDiv=0 AND AuthorityLevel1=jobType
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(jobType);

            return GetOperationLimitWhere(sqlWhere.ToString());
        }

        /// <summary>
        /// 権限レベル2(雇用形態)の条件で操作権限を取得します。
        /// </summary>
        /// <remarks>
        /// カテゴリ全体設定である場合、カテゴリ全体の操作権限を返します。
        /// </remarks>
        /// <param name="categoryCode">起動元のカテゴリコード</param>
        /// <param name="pgId">起動元のプログラムID</param>
        /// <param name="operationCode">対象のオペレーションコード</param>
        /// <param name="employmentForm">対象の権限レベル2(雇用形態)</param>
        /// <returns>
        /// ・Enable：可。オペレーション可能でログ書き込み不要。…該当レコード無し<br/>
        /// ・EnableWithLog：可(ログ記録)。オペレーション可能で、ログ書き込み必要。…制限区分=0:ログ<br/>
        /// ・Disable：不可。オペレーションは不可。…制限区分=1:制限
        /// </returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected OperationLimit GetOperationLimitWhereAuthorityLevel2(
            int categoryCode,
            string pgId,
            int operationCode,
            int employmentForm
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            DataRowType[] categorySettingRows = GetCategorySettingRowsWhatAuthorityLevel2(categoryCode, operationCode, employmentForm);
            if (categorySettingRows.Length > 0)
            {
                // カテゴリ全体設定あり（を優先）
                const int SINGLE_ROW = 0;   // 単一行
                return GetOperationLimit(categorySettingRows[SINGLE_ROW].LimitDiv);
                //
            }   // カテゴリ全体設定なし

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));
            // OperationStDiv=1 AND AuthorityLevel2=employmentForm
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(employmentForm);

            return GetOperationLimitWhere(sqlWhere.ToString());
        }

        #endregion  // <操作権限取得処理/>

        #region <カテゴリ全体設定のデータ行の取得/>

        /// <summary>
        /// カテゴリ全体設定のデータ行を取得します。
        /// </summary>
        /// <remarks>
        /// 指定したカテゴリコードのレコードにプログラムIDの値が<code>string.Empty</code>のものがあれば、
        /// カテゴリ全体設定となります。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="jobType">権限レベル1(職種)</param>
        /// <returns>カテゴリ全体設定のデータ行配列</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected DataRowType[] GetCategorySettingRowsWhatAuthorityLevel1(
            int categoryCode,
            int operationCode,
            int jobType
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, ALL_CATEGORY_ID, operationCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(jobType);

            return ADOUtil.ConvertAll<DataRowType>(MainTbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// カテゴリ全体設定のデータ行を取得します。
        /// </summary>
        /// <remarks>
        /// 指定したカテゴリコードのレコードにプログラムIDの値が<code>string.Empty</code>のものがあれば、
        /// カテゴリ全体設定となります。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employmentForm">権限レベル2(雇用形態)</param>
        /// <returns>カテゴリ全体設定のデータ行配列</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected DataRowType[] GetCategorySettingRowsWhatAuthorityLevel2(
            int categoryCode,
            int operationCode,
            int employmentForm
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, ALL_CATEGORY_ID, operationCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(employmentForm);

            return ADOUtil.ConvertAll<DataRowType>(MainTbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// カテゴリ全体設定のデータ行を取得します。
        /// </summary>
        /// <remarks>
        /// 指定したカテゴリコードのレコードにプログラムIDの値が<code>string.Empty</code>のものがあれば、
        /// カテゴリ全体設定となります。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>カテゴリ全体設定のデータ行配列</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected DataRowType[] GetCategorySettingRows(
            int categoryCode,
            int operationCode,
            string employeeCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, ALL_CATEGORY_ID, operationCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)DataSetType.OperationStDiv.EmployeeCode);
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.EmployeeCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(employeeCode));

            return ADOUtil.ConvertAll<DataRowType>(MainTbl.Select(sqlWhere.ToString()));
        }

        #endregion  // <カテゴリ全体設定のデータ行の取得/>

        #region <SQLのwhere句/>

        /// <summary>
        /// 基本where句を取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <returns>企業コード AND カテゴリーコード AND プログラムID</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected string GetBaseWherePhrase(
            int categoryCode,
            string pgId
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder();

            sqlWhere.Append(DataSetType.ClmIdx.EnterpriseCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(EnterpriseCode));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.CategoryCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(categoryCode.ToString());
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.PgId);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(pgId));

            return sqlWhere.ToString();
        }

        /// <summary>
        /// 基本where句を取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>企業コード AND カテゴリーコード AND 'プログラムID' AND オペレーションコード</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        protected string GetBaseWherePhrase(
            int categoryCode,
            string pgId,
            int operationCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId));

            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationCode.ToString());

            return sqlWhere.ToString();
        }

        #endregion  // <SQLのwhere句/>

        #region <実験/>

        /// <summary>
        /// 探す実験
        /// </summary>
        [Conditional("DEBUG")]
        public void TestSearch()
        {
            OperationStWork searchingCondition = new OperationStWork();
            searchingCondition.EnterpriseCode = "0101150842020000";
            //searchingCondition.CategoryCode = 1;
            //searchingCondition.PgId = "";

            object objSearchingConditionList = searchingCondition;
            object objSearchedRecordList = null;

            IOperationStDB accesser = MediationOperationStDB.GetOperationStDB();
            int status = accesser.Search(ref objSearchedRecordList, objSearchingConditionList, 0, 0);
            if (!status.Equals(0))
            {
                Debug.Assert(false, (status.Equals(9) ? "レコードなし" : "失敗：" + status.ToString()));
            }

            ArrayList searchedRecordList = (ArrayList)objSearchedRecordList;

            Debug.WriteLine("件数：" + searchedRecordList.Count.ToString());
        }

        /// <summary>
        /// 書く実験
        /// </summary>
        [Conditional("DEBUG")]
        public void TestWrite()
        {
            OperationStWork writingCondition = new OperationStWork();
            {
                writingCondition.EnterpriseCode = "0101150842020000";
                writingCondition.CategoryCode = 1;
                writingCondition.PgId = "MAHNB01010U";
                writingCondition.OperationCode = 0;

                writingCondition.OperationStDiv = 0;

                writingCondition.AuthorityLevel1 = 100;
                writingCondition.AuthorityLevel2 = -1;
                writingCondition.EmployeeCode = "0002";

                writingCondition.LimitDiv = 0;

                writingCondition.ApplyStartDate = 20080807;
                writingCondition.ApplyEndDate = 20081231;
            }

            ArrayList writingConditionList = new ArrayList();
            writingConditionList.Add(writingCondition);

            object objWritingConditionList = writingConditionList;

            IOperationStDB accesser = MediationOperationStDB.GetOperationStDB();
            int status = accesser.Write(ref objWritingConditionList);
            if (status.Equals(5))
            {
                Debug.WriteLine("既に書き込み済みです。");
            }
            else if (!status.Equals(0))  // 5は既に書いてあるという意味
            {
                Debug.Assert(false, "失敗：" + status.ToString());
            }

            Debug.WriteLine("\nオペ設DBに書き込みOK!\n");
        }

        #endregion  // <実験/>

        #region <Public Static Methods/>

        /// <summary>
        /// カテゴリー属性取得
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public static CategoryAttribute GetCategoryAttribute(int categoryCode)
        {
            if (( 0 < categoryCode ) && ( categoryCode < 50 ))
            {
                return CategoryAttribute.Activity;
            }
            else if (( 50 <= categoryCode ) && ( categoryCode < 90 ))
            {
                return CategoryAttribute.Authority;
            }
            else
            {
                return CategoryAttribute.Other;
            }
        }

        #endregion
    }
}

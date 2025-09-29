//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : オペレーション設定マスタリモートのアクセス結果を保持します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = IOperationStDB;
    using DBRecordType  = OperationStWork;
    using DataSetType   = OperationSettingMasterDataSet;
    using DataTableType = OperationSettingMasterDataSet.OperationSettingMasterDataTable;
    using DataRowType   = OperationSettingMasterDataSet.OperationSettingMasterRow;

    /// <summary>
    /// オペレーション設定マスタリモートクラスの代理人クラス
    /// </summary>
    public sealed class OperationStDBAgent : OperationLimitation, IDisposable
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
            #region <Guard Phrase/>
            
            if (Disposed) return;

            #endregion  // <Guard Phrase/>

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
        ~OperationStDBAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// 全カテゴリを取得します。
        /// </remarks>
        public OperationStDBAgent() : base()
        {
            SearchAllCategory();
        }

        /// <summary>
        /// 全カテゴリを検索します。
        /// </summary>
        public void SearchAllCategory()
        {
            const int ALL_CATEGORY = -1;
            base.SearchInitial(ALL_CATEGORY, string.Empty);
            return;
        }

        #endregion  // <Constructor/>

        #region <アクセサ/>

        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        /// <value>企業コード</value>
        public new string EnterpriseCode
        {
            get { return OperationLimitation.EnterpriseCode; }
        }

        /// <summary>
        /// オペレーション設定マスタDBのアクセサを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのアクセサ</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DBAccessType RealAccesser
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OperationStDBAccesser;
            }
        }

        /// <summary>
        /// オペレーション設定マスタDBのレコードリストを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのレコードリスト</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public List<DBRecordType> RecordList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OperationStWorkList;
            }
        }

        /// <summary>
        /// オペレーション設定マスタDBのデータセットを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのデータセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataSetType DB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.OperationSettingMasterDB;
            }
        }

        /// <summary>
        /// オペレーション設定マスタDBのデータテーブルを取得します。
        /// </summary>
        /// <value>オペレーション設定マスタDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return base.MainTbl;
            }
        }

        #endregion  // <アクセサ/>

        #region <操作権限取得処理/>

        /// <summary>
        /// 職種(権限レベル1)の条件で操作権限を取得します。
        /// </summary>
        /// <remarks>
        /// カテゴリ全体設定である場合、カテゴリ全体の操作権限を返します。
        /// </remarks>
        /// <param name="categoryCode">起動元のカテゴリコード</param>
        /// <param name="pgId">起動元のプログラムID</param>
        /// <param name="operationCode">対象のオペレーションコード</param>
        /// <param name="authorityLevel1">対象の権限レベル1(職種)</param>
        /// <returns>
        /// ・Enable：可。オペレーション可能でログ書き込み不要。…該当レコード無し<br/>
        /// ・EnableWithLog：可(ログ記録)。オペレーション可能で、ログ書き込み必要。…制限区分=0:ログ<br/>
        /// ・Disable：不可。オペレーションは不可。…制限区分=1:制限
        /// </returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public OperationLimit GetOperationLimitFromJobType(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel1
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return base.GetOperationLimitWhereAuthorityLevel1(categoryCode, pgId, operationCode, authorityLevel1);
        }

        /// <summary>
        /// 雇用形態(権限レベル2)の条件で操作権限を取得します。
        /// </summary>
        /// <remarks>
        /// カテゴリ全体設定である場合、カテゴリ全体の操作権限を返します。
        /// </remarks>
        /// <param name="categoryCode">起動元のカテゴリコード</param>
        /// <param name="pgId">起動元のプログラムID</param>
        /// <param name="operationCode">対象のオペレーションコード</param>
        /// <param name="authorityLevel2">対象の権限レベル2(雇用形態)</param>
        /// <returns>
        /// ・Enable：可。オペレーション可能でログ書き込み不要。…該当レコード無し<br/>
        /// ・EnableWithLog：可(ログ記録)。オペレーション可能で、ログ書き込み必要。…制限区分=0:ログ<br/>
        /// ・Disable：不可。オペレーションは不可。…制限区分=1:制限
        /// </returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public OperationLimit GetOperationLimitFromEmploymentForm(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel2
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return base.GetOperationLimitWhereAuthorityLevel2(categoryCode, pgId, operationCode, authorityLevel2);
        }

        #endregion  // <操作権限取得処理/>

        #region <条件に合うレコードの取得/>

        /// <summary>
        /// 条件に合う職種のレコードを取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="authorityLevel1">権限レベル1(職種)</param>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataRowType[] GetRowsWhatIsJobType(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel1
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(
                categoryCode,
                pgId,
                operationCode,
                (int)DataSetType.OperationStDiv.AuthorityLevel1
            ));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel1);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(authorityLevel1);

            return ADOUtil.ConvertAll<DataRowType>(Tbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// 条件に合う職種のレコードを取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="authorityLevel2">権限レベル2(雇用形態)</param>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataRowType[] GetRowsWhatIsEmploymentForm(
            int categoryCode,
            string pgId,
            int operationCode,
            int authorityLevel2
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(
                categoryCode,
                pgId,
                operationCode,
                (int)DataSetType.OperationStDiv.AuthorityLevel2
            ));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.AuthorityLevel2);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(authorityLevel2);

            return ADOUtil.ConvertAll<DataRowType>(Tbl.Select(sqlWhere.ToString()));
        }

        /// <summary>
        /// 条件に合う職種のレコードを取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataRowType[] GetRowsWhatIsEmployeeCode(
            int categoryCode,
            string pgId,
            int operationCode,
            string employeeCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(
                categoryCode,
                pgId,
                operationCode,
                (int)DataSetType.OperationStDiv.EmployeeCode
            ));
            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.EmployeeCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(employeeCode));

            return ADOUtil.ConvertAll<DataRowType>(Tbl.Select(sqlWhere.ToString()));
        }

        #endregion  // <条件に合うレコードの取得/>

        #region <カテゴリ全体設定であるかの判定/>

        /// <summary>
        /// カテゴリ全体設定であるか判定します。
        /// </summary>
        /// <remarks>
        /// 指定したカテゴリコードのレコードにプログラムIDの値が<code>string.Empty</code>のものがあれば、
        /// カテゴリ全体設定となります。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="authorityLevel1">権限レベル1(職種)</param>
        /// <returns>true :カテゴリ全体設定である。<br/>false:カテゴリ全体設定ではない。</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public bool IsCategorySettingWhatJobType(
            int categoryCode,
            int operationCode,
            int authorityLevel1
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return GetCategorySettingRowsWhatAuthorityLevel1(categoryCode, operationCode, authorityLevel1).Length > 0;
        }

        /// <summary>
        /// カテゴリ全体設定であるか判定します。
        /// </summary>
        /// <remarks>
        /// 指定したカテゴリコードのレコードにプログラムIDの値が<code>string.Empty</code>のものがあれば、
        /// カテゴリ全体設定となります。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="authorityLevel2">権限レベル2(雇用形態)</param>
        /// <returns>true :カテゴリ全体設定である。<br/>false:カテゴリ全体設定ではない。</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public bool IsCategorySettingWhatEmploymentForm(
            int categoryCode,
            int operationCode,
            int authorityLevel2
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return GetCategorySettingRowsWhatAuthorityLevel2(categoryCode, operationCode, authorityLevel2).Length > 0;
        }

        /// <summary>
        /// カテゴリ全体設定であるか判定します。
        /// </summary>
        /// <remarks>
        /// 指定したカテゴリコードのレコードにプログラムIDの値が<code>string.Empty</code>のものがあれば、
        /// カテゴリ全体設定となります。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>true :カテゴリ全体設定である。<br/>false:カテゴリ全体設定ではない。</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public bool IsCategorySettingWhatEmployeeCode(
            int categoryCode,
            int operationCode,
            string employeeCode
        )
        {
            #region <Guard Phrase/>

            if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

            #endregion  // <Guard Phrase/>

            return GetCategorySettingRows(categoryCode, operationCode, employeeCode).Length > 0;
        }

        #endregion  // <カテゴリ全体設定であるかの判定/>

        #region <SQLのwhere句/>

        /// <summary>
        /// 基本where句を取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="operationStDiv">オペレーション設定区分</param>
        /// <returns>企業コード AND カテゴリーコード AND 'プログラムID' AND オペレーションコード</returns>
        private string GetBaseWherePhrase(
            int categoryCode,
            string pgId,
            int operationCode,
            int operationStDiv
        )
        {
            StringBuilder sqlWhere = new StringBuilder(GetBaseWherePhrase(categoryCode, pgId, operationCode));

            sqlWhere.Append(ADOUtil.AND);
            sqlWhere.Append(DataSetType.ClmIdx.OperationStDiv);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(operationStDiv);

            return sqlWhere.ToString();
        }

        #endregion  // <SQLのwhere句/>
    }
}

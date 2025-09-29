//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作履歴アクセス
// プログラム概要   : 拠点マスタテーブルアクセスのアクセス結果を保持します。
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
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using DBAccessType  = SecInfoSetAcs;
    using DBRecordType  = SecInfoSet;
    using DataSetType   = SectionInfoDataSet;
    using DataTableType = SectionInfoDataSet.SectionInfoDataTable;
    using DataRowType   = SectionInfoDataSet.SectionInfoRow;

    /// <summary>
    /// 拠点マスタテーブルアクセスクラスの代理人クラス
    /// </summary>
    public sealed class SecInfoSetAcsAgent : DBAccessAgent<DBAccessType, DBRecordType, DataSetType>, IDisposable
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
        ~SecInfoSetAcsAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SecInfoSetAcsAgent() : base() { }

        /// <summary>
        /// 拠点マスタDBのデータテーブルを取得します。
        /// </summary>
        /// <value>拠点マスタDBのデータテーブル</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataTableType Tbl
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return DB.SectionInfo;
            }
        }

        /// <summary>
        /// 拠点マスタDBのレコードリストを初期化します。
        /// </summary>
        /// <remarks>
        /// 拠点マスタDBより全拠点のレコードを取得します。
        /// </remarks>
        protected override void Initialize()
        {
            RecordList.Clear();

            ArrayList searchedRecordArrayList = null;
            int status = RealAccesser.SearchAll(out searchedRecordArrayList, LoginInfoAcquisition.EnterpriseCode);

            // 該当データなし
            if (status.Equals((int)DBAccessStatus.NoRecord)) return;

            #region <Debug/>

            Debug.Assert(status.Equals((int)DBAccessStatus.Normal), MsgUtil.GetMsg(status, LoginInfoAcquisition.EnterpriseCode));

            #endregion  // <Debug/>

            // 該当データあり
            foreach (object objSearchedRecord in searchedRecordArrayList)
            {
                DBRecordType searchedRecord = (DBRecordType)objSearchedRecord;
                RecordList.Add(searchedRecord);

                Tbl.AddSectionInfoRow(
                    searchedRecord.SectionCode,
                    searchedRecord.SectionGuideNm
                );
            }
        }

        /// <summary>
        /// 拠点名称を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        public string GetSectionName(string sectionCode)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(SectionInfoDataSet.ClmIdx.SectionCode);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append(ADOUtil.GetString(sectionCode));

            DataRow[] foundRows = Tbl.Select(sqlWhere.ToString());
            if (foundRows.Length > 0)
            {
                return ((SectionInfoDataSet.SectionInfoRow)foundRows[0]).SectionGuideNm;
            }
            else
            {
                return sectionCode;
            }
        }
    }
}

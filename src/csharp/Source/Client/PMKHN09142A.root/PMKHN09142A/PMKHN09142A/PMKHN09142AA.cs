//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作履歴アクセス
// プログラム概要   : 以下のクラスのFacade(窓口)となります。
//                  : ・オペレーションマスタローカルアクセス
//                  : ・権限レベルマスタローカルアクセスクラス
//                  : ・操作履歴リモートクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/11/18  修正内容 : マスメン、帳票の場合の履歴表示方変更。
// 管理番号  10607734-01 作成担当 : 曹文傑
// 作 成 日  2011/03/22  修正内容 : 照会プログラムの抽出開始・終了の履歴表示に対応。
// 管理番号  10607734-01 作成担当 : 曹文傑
// 作 成 日  2011/04/06  修正内容 : Redmine#20388の対応。
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 操作履歴アクセスクラス
    /// </summary>
    /// <remarks>
    /// 以下のクラスのFacade(窓口)となります。<br/>
    /// ・オペレーションマスタローカルアクセス<br/>
    /// ・権限レベルマスタローカルアクセスクラス<br/>
    /// ・操作履歴リモートクラス<br/>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムの抽出開始・終了の履歴表示に対応。</br>
    /// <br>Update Note: 2011/04/06  曹文傑</br>
    /// <br>           : Redmine#20388の対応。</br>
    /// </remarks>
    public sealed class OperationHistoryAcs : IDisposable
    {
        #region <Singleton Idiom/>

        /// <summary>同期オブジェクト</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>シングルトンインスタンス</summary>
        private static OperationHistoryAcs _instance;
        /// <summary>
        /// シングルトンインスタンスを取得します。
        /// </summary>
        /// <value>操作権限設定アクセスクラスのシングルトンインスタンス</value>
        public static OperationHistoryAcs Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new OperationHistoryAcs();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private OperationHistoryAcs() { }

        #endregion  // <Singleton Idiom/>

        #region <IDisposable Member/>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>
        /// 処分済みフラグを取得します。
        /// </summary>
        /// <value>true :処分済み<br/>false:処分していない</value>
        private bool Disposed { get { return _disposed; } }

        /// <summary>
        /// 処分します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            this._disposed = true;
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトの処分フラグ</param>
        private void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (this.Disposed) return;

            #endregion  // <Guard Phrase/>

            // マネージオブジェクト
            if (disposing)
            {
                ResetDataSet();
            }
            // アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~OperationHistoryAcs()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <DBアクセス代理人/>

        #region <拠点アクセス/>

        /// <summary>拠点マスタDB</summary>
        private SecInfoSetAcsAgent _sectionInfoDB;
        /// <summary>
        /// 拠点マスタDBを取得します。
        /// </summary>
        /// <value>拠点マスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public SecInfoSetAcsAgent SectionInfoDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_sectionInfoDB == null)
                {
                    _sectionInfoDB = new SecInfoSetAcsAgent();
                }
                return _sectionInfoDB;
            }
        }

        #endregion // <拠点アクセス/>

        #region <権限レベルマスタローカルアクセス/>

        /// <summary>
        /// 権限レベルマスタDBを取得します。
        /// </summary>
        /// <value>権限レベルマスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public AuthorityLevelLcDBAgent AuthorityLevelMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationAuthoritySettingAcs.Instance.AuthorityLevelMasterDB;
            }
        }

        #endregion  // <権限レベルマスタローカルアクセス/>

        #region <オペレーションマスタローカルアクセス/>

        /// <summary>
        /// オペレーションマスタDBを取得します。
        /// </summary>
        /// <value>オペレーションマスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public OperationLcDBAgent OperationMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationAuthoritySettingAcs.Instance.OperationMasterDB;
            }
        }

        # endregion // <オペレーションマスタローカルアクセス/>

        #region <従業員テーブルアクセス/>

        /// <summary>
        /// 従業員マスタDBを取得します。
        /// </summary>
        /// <value>従業員マスタDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public EmployeeAcsAgent EmployeeMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationAuthoritySettingAcs.Instance.EmployeeMasterDB;
            }
        }

        #endregion  // <従業員テーブルアクセス/>

        #region <操作履歴リモート>

        /// <summary>操作履歴ログデータDB</summary>
        private OperationHistoryLogAgent _operationHistoryLogDB;
        /// <summary>
        /// 操作履歴ログデータDBを取得します。
        /// </summary>
        /// <value>操作履歴ログデータDB</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public OperationHistoryLogAgent OperationHistoryLogDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationHistoryLogDB == null)
                {
                    _operationHistoryLogDB = new OperationHistoryLogAgent();
                }
                return _operationHistoryLogDB;
            }
        }

        #endregion  // <操作履歴リモート>

        #endregion  // <DBアクセス代理人/>

        /// <summary>表示用ログデータセット</summary>
        private LogDataSet _logSet;
        /// <summary>
        /// 表示用ログデータセットを取得します。
        /// </summary>
        /// <value>表示用ログデータセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public LogDataSet LogSet
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_logSet == null)
                {
                    _logSet = new LogDataSet();
                    InitializeLogDataSet();
                }
                return _logSet;
            }
        }

        /// <summary>
        /// 表示用ログデータセットを更新します。
        /// </summary>
        /// <param name="condition">更新条件</param>
        /// <returns>更新した表示用ログデータセット</returns>
        public LogDataSet RefreshLogSet(LogCondition condition)
        {
            OperationHistoryLogDB.RefreshLog(condition);

            if (_logSet != null)
            {
                _logSet.Clear();
                _logSet.Dispose();
                _logSet = null;
            }

            return LogSet;
        }

        /// <summary>
        /// 表示用ログデータセットを初期化します。
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムの抽出開始・終了の履歴表示に対応。</br>
        /// <br>Update Note: 2011/04/06 曹文傑</br>
        /// <br>             得意先電子元帳の仕様変更後、"操作"="検索"を表示可能にする為。</br>
        /// </remarks>
        private void InitializeLogDataSet()
        {
            Dictionary<string, string> sectionNameMap       = new Dictionary<string,string>();
            Dictionary<int, string> jobTypeNameMap          = new Dictionary<int, string>();
            Dictionary<int, string> employmentFormNameMap   = new Dictionary<int, string>();
            Dictionary<int, string> categoryNameMap         = new Dictionary<int,string>();
            Dictionary<string, string> pgNameMap            = new Dictionary<string,string>();
            Dictionary<string, string> operationNameMap     = new Dictionary<string,string>();

            foreach (OperationHistoryLogDataSet.OperationHistoryLogRow opeRow in OperationHistoryLogDB.Tbl)
            {
                // 日付、時刻
                string date = opeRow.LogDataCreateDateTime.ToString("yyyy/MM/dd");
                string time = opeRow.LogDataCreateDateTime.ToString("HH:mm:ss");

                // 拠点
                string sectionCode = opeRow.LoginSectionCd;
                if (!sectionNameMap.ContainsKey(sectionCode))
                {
                    sectionNameMap.Add(sectionCode, SectionInfoDB.GetSectionName(sectionCode));
                }
                string sectionName = sectionNameMap[sectionCode];

                // 職種
                int jobTypeLevel = -1;  // string.Emptyが登録されていることがある
                try
                {
                    jobTypeLevel = int.Parse(opeRow.LogOperaterDtProcLvl);
                }
                catch (FormatException)
                {
                    // -1のまま
                }
                if (!jobTypeNameMap.ContainsKey(jobTypeLevel))
                {
                    jobTypeNameMap.Add(
                        jobTypeLevel,
                        AuthorityLevelMasterDB.GetJobTypeName(jobTypeLevel)
                    );
                }
                string jobTypeName = jobTypeNameMap[jobTypeLevel];

                // 雇用形態
                int employmentFormLevel = -1;  // string.Emptyが登録されていることがある
                try
                {
                    employmentFormLevel = int.Parse(opeRow.LogOperaterFuncLvl);
                }
                catch (FormatException)
                {
                    // -1のまま
                }
                if (!employmentFormNameMap.ContainsKey(employmentFormLevel))
                {
                    employmentFormNameMap.Add(
                        employmentFormLevel,
                        AuthorityLevelMasterDB.GetEmploymentFormName(employmentFormLevel)
                    );
                }
                string employmentFormName = employmentFormNameMap[employmentFormLevel];

                // カテゴリ名称、機能名称
                string pgId = opeRow.LogDataObjAssemblyID;
                CodeNamePair<int> categoryPair;
                // --- ADD 2008/11/18 -------------------------------->>>>>
                // マスメン、帳票の場合は直接設定
                if (pgId == "SFCMN09000U")
                {
                    categoryPair = new CodeNamePair<int>(50, "マスメン");

                }
                else if (pgId == "SFANL07200U")
                {
                    categoryPair = new CodeNamePair<int>(4, "帳票");
                }
                // --- ADD 2008/11/18 --------------------------------<<<<<
                // ---ADD 2011/03/22--------------->>>>>
                else if (pgId == "DCCMN04000U")
                {
                    categoryPair = new CodeNamePair<int>(3, "照会");
                }
                // ---ADD 2011/03/22---------------<<<<<
                else
                {
                    categoryPair = OperationMasterDB.GetCategory(pgId);
                    if (!pgNameMap.ContainsKey(pgId))
                    {
                        if (!categoryNameMap.ContainsKey(categoryPair.Code))
                        {
                            categoryNameMap.Add(categoryPair.Code, categoryPair.Name);
                        }
                        pgNameMap.Add(pgId, OperationMasterDB.GetProgramName(pgId));
                    }
                }
                //string pgName = pgNameMap[pgId];
                // TODO:↓ロガーが正しく使用されていれば、opeRow.LogDataObjAssemblyNmがpgIdに対応する名称
                string pgName = opeRow.LogDataObjAssemblyNm;

                // 操作
                int categoryCode = categoryPair.Code;
                int operationCode = opeRow.LogDataOperationCd;
                
                string operationKey = categoryCode.ToString() + pgId + operationCode.ToString();
                
                if (!operationNameMap.ContainsKey(operationKey))
                {
                    // --- ADD 2008/11/18 -------------------------------->>>>>
                    // マスメン、帳票の場合、カテゴリの全体設定(PGID = "")から操作名称を取得
                    if (pgId == "SFCMN09000U" || pgId == "SFANL07200U")
                    {
                        operationNameMap.Add(
                            operationKey,
                            OperationMasterDB.GetOperationName(categoryCode, "", operationCode)
                        );
                    }
                    // --- ADD 2008/11/18 --------------------------------<<<<<
                    // ---ADD 2011/03/22------------->>>>>
                    else if (pgId == "DCCMN04000U")
                    {
                        if (operationCode == 0)
                        {
                            operationNameMap.Add(operationKey, "検索");
                        }
                        else
                        {
                            operationNameMap.Add(operationKey, string.Empty);
                        }
                    }
                    // ---ADD 2011/03/22-------------<<<<<
                    // ---ADD 2011/04/06------------->>>>>
                    else if (pgId == "PMKAU04000U")
                    {
                        if (operationCode == 0)
                        {
                            operationNameMap.Add(operationKey, "検索");
                        }
                        else
                        {
                            operationNameMap.Add(
                                operationKey,
                                OperationMasterDB.GetOperationName(categoryCode, pgId, operationCode)
                            );
                        }
                    }
                    // ---ADD 2011/04/06-------------<<<<<
                    else
                    {
                        operationNameMap.Add(
                            operationKey,
                            OperationMasterDB.GetOperationName(categoryCode, pgId, operationCode)
                        );
                    }
                }
                string operationName = operationNameMap[operationKey];

                // データセットに追加
                LogSet.Log.AddLogRow(
                    date,
                    time,
                    opeRow.LogDataKindCd,
                    OperationHistoryLogDataSet.GetLogKingName(opeRow.LogDataKindCd),
                    sectionCode,
                    sectionName,
                    opeRow.LogDataMachineName,
                    jobTypeLevel,
                    jobTypeName,
                    employmentFormLevel,
                    employmentFormName,
                    opeRow.LogDataAgentCd,
                    opeRow.LogDataAgentNm,
                    categoryPair.Code,
                    categoryPair.Name,
                    pgId,
                    pgName,
                    operationCode,
                    operationName,
                    opeRow.LogDataMassage,
                    opeRow.LogDataCreateDateTime
                );
            }
        }

        /// <summary>
        /// 保持しているデータセットをリセットします。
        /// </summary>
        public void ResetDataSet()
        {
            if (_sectionInfoDB != null)
            {
                _sectionInfoDB.Dispose();
                _sectionInfoDB = null;
            }
            if (_operationHistoryLogDB != null)
            {
                _operationHistoryLogDB.Dispose();
                _operationHistoryLogDB = null;
            }
            if (_logSet != null)
            {
                _logSet.Dispose();
                _logSet = null;
            }
        }
    }
}

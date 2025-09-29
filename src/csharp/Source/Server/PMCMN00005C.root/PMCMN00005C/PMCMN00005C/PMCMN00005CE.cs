using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// アプリケーション リソースに対するロック機能を有した RemoteDB クラスです。
    /// </summary>
    /// <remarks>
    /// 本クラスはアプリケーション リソースロックを行う際にインスタンス化して該当メソッドを
    /// 実行しても構いませんし、RemoteDB の替わりに継承元として指定して該当メソッドを実行
    /// しても構いません。
    /// <br></br>
    /// <br>Update Note: 2010/08/16  22018 鈴木 正臣  締次ロック機能の追加に伴う変更。</br>
    /// <br></br>
    /// </remarks>
    public partial class RemoteWithAppLockDB : RemoteDB
    {
        # region [シェアチェック関連]

        /// <summary>
        /// シェアチェックを行います。
        /// </summary>
        /// <param name="info">ShareCheckInfo を指定します</param>
        /// <param name="mode">シェアチェックのロック or リリースを指定します</param>
        /// <param name="connection">DB接続情報を指定します</param>
        /// <param name="transaction">トランザクション情報を指定します</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// ShareCheckKey をリスト化して渡す事によって、複数の拠点コードや倉庫コードで同時にロック処理を行えます。
        /// 但し重複したデータや矛盾している組み合わせの ShareCheckKey をセットした場合の動作は保障していません。
        /// 例：同一企業コードにおける企業ロックと拠点ロックの組み合わせ → ＮＧ
        /// 　　同一企業コードにおける拠点ロックと倉庫ロックの組み合わせ → ＯＫ etc.
        /// </remarks>
        public int ShareCheck(ShareCheckInfo info, LockControl mode, SqlConnection connection, SqlTransaction transaction)
        {
            return this.ShareCheckProc(info, mode, connection, transaction);
        }

        /// <summary>
        /// シェアチェックを行います
        /// </summary>
        /// <param name="info">複数の ShareCheckKey を格納する ShareCheckKeyList を指定します</param>
        /// <param name="mode">シェアチェックのロック or リリースを指定します</param>
        /// <param name="connection">DB接続情報を指定します</param>
        /// <param name="transaction">トランザクション情報を指定します</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        private int ShareCheckProc(ShareCheckInfo info, LockControl mode, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // シェアチェック結果を全て"失敗"で初期化する
            info.Keys.SetKeyResult(ShareCheckResult.Failure, delegate(ShareCheckKey item) { return true; });

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            bool errflg = false;

            # region [パラメータチェック]

            if (info.Keys.Count == 0)
            {
                errmsg += ": シェアチェックキーが未設定です.";
                errflg = true;
            }
            else
            {
                info.Keys.Sort();  // 企業＞拠点＞倉庫ロックの順に並び変える(詳細は ShareCheckKey.CompareTo を参照)

                # region [未設定項目のチェック]

                // 企業コードが未設定の項目を検索
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     { return string.IsNullOrEmpty(item.EnterpriseCode); }))
                {
                    errmsg += ": 企業コードが未設定の物があります.";
                    errflg = true;
                }

                // シェアチェックタイプが未設定の項目を検索
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     { return item.Type == ShareCheckType.None; }))
                {
                    errmsg += ": シェアチェックタイプが未設定の物があります.";
                    errflg = true;
                }

                // 拠点ロック時に拠点コードが未設定の項目を検索
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     {
                                         return item.Type == ShareCheckType.Section &&
                                                string.IsNullOrEmpty(item.SectionCode);
                                     }))
                {
                    errmsg += ": 拠点コードが未設定の物があります.";
                    errflg = true;
                }

                // 倉庫ロック時に倉庫コードが未設定の項目を検索
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     {
                                         return item.Type == ShareCheckType.WareHouse &&
                                                string.IsNullOrEmpty(item.WarehouseCode);
                                     }))
                {
                    errmsg += ": 倉庫コードが未設定の物があります.";
                    errflg = true;
                }

                // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                if ( info.Keys.Exists( delegate( ShareCheckKey item )
                                        {
                                            //return ((item.Type == ShareCheckType.AddUpSlip || item.Type == ShareCheckType.AddUpUpdate) &&//DEL yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正
                                            //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                                            return ((item.Type == ShareCheckType.AddUpSlip || item.Type == ShareCheckType.AddUpUpdate
                                                || item.Type == ShareCheckType.SupUpSlip || item.Type == ShareCheckType.SupUpUpdate) &&
                                            //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
                                                    (item.TotalDay == 0 || item.AddUpUpdDate == 0)); //拠点はALLの可能性が有るのでチェックしない。
                                        } ) )
                {
                    errmsg += ": 締次集計ロック条件が未設定の物があります.";
                    errflg = true;
                }
                // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                # endregion

                # region [組み合わせチェック]

                // 企業ロックが指定されているキーの一覧を取得する
                List<ShareCheckKey> EnterpriseLocks = info.Keys.FindAll(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; });

                foreach (ShareCheckKey key in EnterpriseLocks)
                {
                    // 企業ロックが指定されている、同一の企業コードを持つ拠点・倉庫ロックの一覧を取得する
                    List<ShareCheckKey> illegals = info.Keys.FindAll(delegate(ShareCheckKey item)
                                                                     {
                                                                         return item.EnterpriseCode == key.EnterpriseCode &&
                                                                                item.Type != ShareCheckType.Enterprise;
                                                                     });

                    foreach (ShareCheckKey illegal in illegals)
                    {
                        // 矛盾した組み合わせなので削除する(エラーとはしない)
                        info.Keys.Remove(illegal);
                    }
                }

                # endregion
            }

            if (connection == null)
            {
                errmsg += ": DB接続情報が未設定です.";
                errflg = true;
            }

            if (transaction == null)
            {
                errmsg += ": トランザクション情報が未設定です.";
                errflg = true;
            }

            # endregion

            if (errflg)
            {
                // パラメータミスが有った場合はログに落して終了(ST = 1000)
                this.WriteErrorLog(errmsg, status);
            }
            else
            {
                SqlCommand command = null;
                SqlDataReader reader = null;

                try
                {
                    // ロック時のみロック状態の確認を行う
                    if (mode == LockControl.Locke)
                    {
                        # region [企業コードを全て取得する → WHERE句生成に必要]

                        List<string> EnterpriseCodes = new List<string>();

                        foreach (ShareCheckKey key in info.Keys)
                        {
                            if (!EnterpriseCodes.Exists(delegate(string EnterpriseCode) { return EnterpriseCode == key.EnterpriseCode; }))
                            {
                                EnterpriseCodes.Add(key.EnterpriseCode);
                            }
                        }

                        # endregion

                        # region [ロック状態を取得するSELECT文]

                        string sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        // --- UPD m.suzuki 2010/08/16 ---------->>>>>
                        //sqlText += "  SUBSTRING(locks.resource_description,  4,16) AS ENTERPRISE" + Environment.NewLine;
                        //sqlText += " ,SUBSTRING(locks.resource_description, 20, 3) AS TYPE" + Environment.NewLine;
                        //sqlText += " ,SUBSTRING(locks.resource_description, 23, 6) AS CODE" + Environment.NewLine;
                        sqlText += "  SUBSTRING(locks.resource_description,  4,16) AS ENTERPRISE" + Environment.NewLine;
                        sqlText += " ,SUBSTRING(locks.resource_description, 20, 2) AS TYPE" + Environment.NewLine;
                        sqlText += " ,SUBSTRING(locks.resource_description, 22, 4) AS CODE" + Environment.NewLine;
                        // --- UPD m.suzuki 2010/08/16 ----------<<<<<
                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                        sqlText += " ,SUBSTRING(locks.resource_description, 26, 2) AS TOTALDAY" + Environment.NewLine;
                        sqlText += " ,SUBSTRING(locks.resource_description, 28, 8) AS ADDUPUPDDATE" + Environment.NewLine;
                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  sys.dm_tran_locks AS locks" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  locks.resource_type = 'APPLICATION'" + Environment.NewLine;

                        foreach (string EnterpriseCode in EnterpriseCodes)
                        {
                            sqlText += "  AND locks.resource_description LIKE '0:$[" + EnterpriseCode + "%' escape '$'" + Environment.NewLine;
                        }

                        command = new SqlCommand(sqlText, connection, transaction);

# if DEBUG
                        //Console.Clear();
                        //Console.WriteLine(NSDebug.GetSqlCommand(command));
# endif

                        # endregion

                        for (int cnt = 0; cnt < info.RetryCount; cnt++)
                        {
                            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                            bool breakThroughFlag = false;
                            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                            reader = command.ExecuteReader();

                            # region [ロック状態を格納]

                            List<ShareCheckKey> lockState = new List<ShareCheckKey>();

                            try
                            {
                                while (reader.Read())
                                {
                                    ShareCheckKey wrkKey = new ShareCheckKey();

                                    wrkKey.EnterpriseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ENTERPRISE"));  // 企業コード
                                    wrkKey.TypeText = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("TYPE"));              // シェアチェックタイプ

                                    if (wrkKey.Type == ShareCheckType.Section)
                                    {
                                        wrkKey.SectionCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("CODE"));      // 拠点コード

                                    }
                                    else if (wrkKey.Type == ShareCheckType.WareHouse)
                                    {
                                        wrkKey.WarehouseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("CODE"));     // 倉庫コード
                                    }
                                    // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                                    //else if ( wrkKey.Type == ShareCheckType.AddUpSlip || wrkKey.Type == ShareCheckType.AddUpUpdate )//DEL yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
                                    //--- ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正----->>>>>
                                    else if (wrkKey.Type == ShareCheckType.AddUpSlip || wrkKey.Type == ShareCheckType.AddUpUpdate
                                    || wrkKey.Type == ShareCheckType.SupUpSlip || wrkKey.Type == ShareCheckType.SupUpUpdate)
                                    //--- ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正-----<<<<<
                                    {
                                        wrkKey.SectionCode = SqlDataMediator.SqlGetString( reader, reader.GetOrdinal( "CODE" ) );      // 拠点コード
                                        wrkKey.TotalDay = ToInt( SqlDataMediator.SqlGetString( reader, reader.GetOrdinal( "TOTALDAY" ) ) );      // 締日
                                        wrkKey.AddUpUpdDate = ToInt( SqlDataMediator.SqlGetString( reader, reader.GetOrdinal( "ADDUPUPDDATE" ) ) );      // 締次更新日
                                    }
                                    // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                                    lockState.Add(wrkKey);
                                }
                            }
                            finally
                            {
                                if (reader != null)
                                {
                                    if (!reader.IsClosed)
                                    {
                                        reader.Close();
                                    }

                                    reader.Dispose();
                                    reader = null;
                                }
                            }
                            # endregion

                            # region [シェアチェックタイプに応じたチェック処理]

                            if (lockState.Count > 0)
                            {
                                foreach (ShareCheckKey key in info.Keys)
                                {
                                    switch (key.Type)
                                    {
                                        # region [■企業ロック チェック]
                                        case ShareCheckType.Enterprise:
                                            {
                                                // 何れかのロックが掛っている場合はロック不可とする
                                                if (lockState.Count > 0)
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }

                                                break;
                                            }
                                        # endregion

                                        # region [■拠点ロック チェック]
                                        case ShareCheckType.Section:
                                            {
                                                // 企業ロックが掛っている場合はロック不可とする
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 同一拠点ロックが掛っている場合はロック不可とする
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                          {
                                                                              return item.Type == ShareCheckType.Section &&
                                                                                     item.SectionCode == key.SectionCode;
                                                                          }))
                                                {
                                                    key.Result = ShareCheckResult.SectionLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }

                                                break;
                                            }
                                        # endregion

                                        # region [■倉庫ロック チェック]
                                        case ShareCheckType.WareHouse:
                                            {
                                                // 企業ロックが掛っている場合はロック不可とする
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 同一倉庫ロックが掛っている場合はロック不可とする
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                          {
                                                                              return item.Type == ShareCheckType.WareHouse &&
                                                                                     item.WarehouseCode == key.WarehouseCode;
                                                                          }))
                                                {
                                                    key.Result = ShareCheckResult.WareHouseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }

                                                break;
                                            }
                                        # endregion

                                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                                        # region [■締次ロック チェック]
                                        // ※締次ロック（伝票側）
                                        case ShareCheckType.AddUpSlip:
                                            {
                                                // 企業ロックが掛っている場合はロック不可とする
                                                if ( lockState.Exists( delegate( ShareCheckKey item ) { return item.Type == ShareCheckType.Enterprise; } ) )
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 対応する締次ロック（集計側）が掛っている場合はロック不可とする
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpUpdate &&
                                                                                    (item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" || item.SectionCode == key.SectionCode) &&
                                                                                    (item.TotalDay == 99 || item.TotalDay == key.TotalDay) &&
                                                                                    item.AddUpUpdDate >= key.AddUpUpdDate);
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;

                                                    // ※対象期間が集計中なのでリトライせずにbreakさせる
                                                    breakThroughFlag = true;
                                                }
                                                // 同一条件で締次ロック（伝票側）が掛っている場合はロック不可とする（statusをTimeOutにする事でリトライさせる。但し通常は伝票発行同士は拠点ロックが掛るはずなので不要。）
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpSlip &&
                                                                                    item.SectionCode == key.SectionCode &&
                                                                                    item.TotalDay == key.TotalDay &&
                                                                                    item.AddUpUpdDate == key.AddUpUpdDate);
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        // ※締次ロック（集計側）
                                        case ShareCheckType.AddUpUpdate:
                                            {
                                                // 企業ロックが掛っている場合はロック不可とする
                                                if ( lockState.Exists( delegate( ShareCheckKey item ) { return item.Type == ShareCheckType.Enterprise; } ) )
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 同一拠点で締次ロック（集計側）が掛っている場合はロック不可とする
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpUpdate &&
                                                                                    (item.SectionCode == key.SectionCode ||
                                                                                     item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" ||
                                                                                     key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000"));
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 対応する締次ロック（伝票側）が掛っている場合はロック不可とする
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpSlip &&
                                                                                    (item.SectionCode == key.SectionCode || key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000") &&
                                                                                    (item.TotalDay == key.TotalDay || key.TotalDay == 99) &&
                                                                                    item.AddUpUpdDate <= key.AddUpUpdDate);
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                                        // ※締次ロック（伝票側）
                                        case ShareCheckType.SupUpSlip:
                                            {
                                                // 企業ロックが掛っている場合はロック不可とする
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 対応する締次ロック（集計側）が掛っている場合はロック不可とする
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpUpdate &&
                                                                                    (item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" || item.SectionCode == key.SectionCode) &&
                                                                                    (item.TotalDay == 99 || item.TotalDay == key.TotalDay) &&
                                                                                    item.AddUpUpdDate >= key.AddUpUpdDate);
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;

                                                    // ※対象期間が集計中なのでリトライせずにbreakさせる
                                                    breakThroughFlag = true;
                                                }
                                                // 同一条件で締次ロック（伝票側）が掛っている場合はロック不可とする（statusをTimeOutにする事でリトライさせる。但し通常は伝票発行同士は拠点ロックが掛るはずなので不要。）
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpSlip &&
                                                                                    item.SectionCode == key.SectionCode &&
                                                                                    item.TotalDay == key.TotalDay &&
                                                                                    item.AddUpUpdDate == key.AddUpUpdDate);
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        // ※締次ロック（集計側）
                                        case ShareCheckType.SupUpUpdate:
                                            {
                                                // 企業ロックが掛っている場合はロック不可とする
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 同一拠点で締次ロック（集計側）が掛っている場合はロック不可とする
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpUpdate &&
                                                                                    (item.SectionCode == key.SectionCode ||
                                                                                     item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" ||
                                                                                     key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000"));
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // 対応する締次ロック（伝票側）が掛っている場合はロック不可とする
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpSlip &&
                                                                                    (item.SectionCode == key.SectionCode || key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000") &&
                                                                                    (item.TotalDay == key.TotalDay || key.TotalDay == 99) &&
                                                                                    item.AddUpUpdDate <= key.AddUpUpdDate);
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
                                        # endregion
                                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                                    }

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                                    {
                                        break;  // チェックに問題が有った場合は即リトライ処理に移行する
                                    }
                                }
                            }

                            # endregion

                            if (status != (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                            {
                                // チェックに問題が無ければリトライ用のループから抜ける
                                break;
                            }
                            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                            // リトライ不要と判断した場合
                            if ( breakThroughFlag == true )
                            {
                                break;
                            }
                            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                            System.Threading.Thread.Sleep(info.TimeOut);  // 指定㍉秒待機する
                        }
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        int timeout = (mode == LockControl.Locke) ? info.TimeOut : 0;

                        foreach (ShareCheckKey key in info.Keys)
                        {
                            // ロック・リリースを行う
                            // ※複数同時ロックに失敗した場合は、呼び出し元にてトランザクションをロールバックして貰う
                            status = this.ExclusiveLockControl(mode, connection, transaction, key.ResourceName, timeout);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // シェアチェック成功
                                key.Result = ShareCheckResult.Success;
                            }
                            else
                            {
                                // シェアチェックタイムアウト
                                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                                {
                                    # region [タイプに応じた結果を設定]
                                    switch (key.Type)
                                    {
                                        case ShareCheckType.Enterprise:
                                            {
                                                // 企業ロックによる失敗
                                                key.Result = ShareCheckResult.EnterpriseLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.Section:
                                            {
                                                // 拠点ロックによる失敗
                                                key.Result = ShareCheckResult.SectionLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.WareHouse:
                                            {
                                                // 倉庫ロックによる失敗
                                                key.Result = ShareCheckResult.WareHouseLockFailure;
                                                break;
                                            }
                                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                                        case ShareCheckType.AddUpSlip:
                                            {
                                                // 締次ロックによる失敗
                                                key.Result = ShareCheckResult.AddUpSlipLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.AddUpUpdate:
                                            {
                                                // 締次ロックによる失敗
                                                key.Result = ShareCheckResult.AddUpUpdateLockFailure;
                                                break;
                                            }
                                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                                        case ShareCheckType.SupUpSlip:
                                            {
                                                // 締次ロックによる失敗
                                                key.Result = ShareCheckResult.SupUpSlipLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.SupUpUpdate:
                                            {
                                                // 締次ロックによる失敗
                                                key.Result = ShareCheckResult.SupUpUpdateLockFailure;
                                                break;
                                            }
                                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                                    }
                                    # endregion
                                }

                                // １つでもロックに失敗した場合はその時点で終了する
                                break;
                            }
                        }
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // シェアチェック結果が"未設定"もしくは"成功"となっている物のみ"失敗"にする
                        info.Keys.SetKeyResult(ShareCheckResult.Failure, delegate(ShareCheckKey item)
                                                                         {
                                                                             return item.Result == ShareCheckResult.None ||
                                                                                    item.Result == ShareCheckResult.Success;
                                                                         });
                    }
                }
                catch (SqlException ex)
                {
                    status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    this.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                        reader.Dispose();
                    }

                    if (command != null)
                    {
                        command.Cancel();
                        command.Dispose();
                    }
                }
            }

            // 総合結果を参考に、戻り値を変更する
            ShareCheckKey tmpKey = null;
            info.Keys.GetIntegratedResult(out tmpKey);

            if (tmpKey != null)
            {
                switch (tmpKey.Result)
                {
                    case ShareCheckResult.EnterpriseLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.SectionLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.WareHouseLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT;
                            break;
                        }
                    // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                    case ShareCheckResult.AddUpUpdateLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.AddUpSlipLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT;
                            break;
                        }
                    // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                    //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                    case ShareCheckResult.SupUpUpdateLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.SupUpSlipLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT;
                            break;
                        }
                    //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
                }
            }

            return status;
        }
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>
        /// 文字列から数値変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
        # endregion
    }
}

namespace Broadleaf.Application.Remoting.ParamData
{
    # region [シェアチェックタイプ]

    /// <summary>
    /// シェアチェックタイプを定義します。
    /// </summary>
    public enum ShareCheckType : int
    {
        /// <summary>未指定</summary>
        None = 0,
        /// <summary>企業単位</summary>
        Enterprise,
        /// <summary>拠点単位</summary>
        Section,
        /// <summary>倉庫単位</summary>
        // --- UPD m.suzuki 2010/08/16 ---------->>>>>
        //WareHouse
        WareHouse,
        // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>締次集計(伝票側)</summary>
        AddUpSlip,
        /// <summary>締次集計(集計側)</summary>
        AddUpUpdate,
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
        // --- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正 ---------->>>>>
        /// <summary>締次集計(仕入側)</summary>
        SupUpSlip,
        /// <summary>締次集計(集計側)</summary>
        SupUpUpdate,
        // --- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正 ----------<<<<<
    }

    # endregion

    # region [シェアチェック結果]
    
    /// <summary>
    /// シェアチェック結果を定義します。
    /// </summary>
    public enum ShareCheckResult : int
    {
        /// <summary>未指定</summary>
        None = 0,
        /// <summary>成功</summary>        
        Success = 1,
        /// <summary>失敗</summary>
        Failure = -1,
        /// <summary>倉庫ロックによる失敗</summary>
        WareHouseLockFailure = -2,
        /// <summary>拠点ロックによる失敗</summary>
        SectionLockFailure = -3,
        /// <summary>企業ロックによる失敗</summary>
        // --- UPD m.suzuki 2010/08/16 ---------->>>>>
        //EnterpriseLockFailure = -4
        EnterpriseLockFailure = -4,
        // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>締次集計ロックによる失敗(集計側が掛けたロック)</summary>
        AddUpUpdateLockFailure = -5,
        /// <summary>締次集計ロックによる失敗(伝票側が掛けたロック)</summary>
        AddUpSlipLockFailure = -6,
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<

        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
        /// <summary>締次集計ロックによる失敗(集計側が掛けたロック)</summary>
        SupUpUpdateLockFailure = -7,
        /// <summary>締次集計ロックによる失敗(伝票側が掛けたロック)</summary>
        SupUpSlipLockFailure = -8,
        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
    }

    # endregion

    # region [シェアチェック情報]

    /// <summary>
    /// シェアチェックに関わるキー項目を定義します
    /// </summary>
    [Serializable]
    public class ShareCheckKey : IComparable<ShareCheckKey>
    {
        private string _EnterpriseCode = string.Empty;
        private string _SectionCode = string.Empty;
        private string _WarehouseCode = string.Empty;
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        private int _TotalDay = 0;
        private int _AddUpUpdDate = 0;
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
        private ShareCheckType _Type = ShareCheckType.None;
        private ShareCheckResult _Result = ShareCheckResult.None;
        private Dictionary<ShareCheckType, string> TypeTextDic = null;

        /// <summary>企業コード</summary>
        public string EnterpriseCode
        {
            get { return this._EnterpriseCode; }
            set { this._EnterpriseCode = value.Trim().PadLeft(16, '0'); }
        }

        /// <summary>拠点コード</summary>
        public string SectionCode
        {
            get { return this._SectionCode; }
            // --- UPD m.suzuki 2010/08/16 ---------->>>>>
            //set { this._SectionCode = value.Trim().PadLeft(6, '0'); }
            set { this._SectionCode = value.Trim().PadLeft(4, '0'); }
            // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        }

        /// <summary>倉庫コード</summary>
        public string WarehouseCode
        {
            get { return this._WarehouseCode; }
            // --- UPD m.suzuki 2010/08/16 ---------->>>>>
            //set { this._WarehouseCode = value.Trim().PadLeft(6, '0'); }
            set { this._WarehouseCode = value.Trim().PadLeft(4, '0'); }
            // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        }

        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>締日(DD)</summary>
        public int TotalDay
        {
            get { return _TotalDay; }
            set { _TotalDay = value; }
        }
        /// <summary>締次更新日(YYYYMMDD)</summary>
        public int AddUpUpdDate
        {
            get { return _AddUpUpdDate; }
            set { _AddUpUpdDate = value; }
        }
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<

        /// <summary>シェアチェックタイプ</summary>
        public ShareCheckType Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }
       
        /// <summary>シェアチェック結果</summary>
        public ShareCheckResult Result
        {
            get { return this._Result; }
            internal set { this._Result = value; }
        }

        /// <summary>コンストラクタ</summary>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public ShareCheckKey()
        {
            this.TypeTextDic = new Dictionary<ShareCheckType, string>();

            // --- UPD m.suzuki 2010/08/16 ---------->>>>>
            //this.TypeTextDic.Add(ShareCheckType.None, "NON");
            //this.TypeTextDic.Add(ShareCheckType.Enterprise, "ENT");
            //this.TypeTextDic.Add(ShareCheckType.Section, "SEC");
            //this.TypeTextDic.Add(ShareCheckType.WareHouse, "WAR");
            this.TypeTextDic.Add( ShareCheckType.None, "NO" );
            this.TypeTextDic.Add( ShareCheckType.Enterprise, "EN" );
            this.TypeTextDic.Add( ShareCheckType.Section, "SE" );
            this.TypeTextDic.Add( ShareCheckType.WareHouse, "WA" );
            // --- UPD m.suzuki 2010/08/16 ----------<<<<<
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            this.TypeTextDic.Add( ShareCheckType.AddUpSlip, "AS" );
            this.TypeTextDic.Add( ShareCheckType.AddUpUpdate, "AU" );
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

            // --- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正 ---------->>>>>
            this.TypeTextDic.Add(ShareCheckType.SupUpSlip, "SS");
            this.TypeTextDic.Add(ShareCheckType.SupUpUpdate, "SU");
            // --- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正 ----------<<<<<
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="type">シェアチェックタイプ</param>
        /// <param name="sectioncode">拠点コード</param>
        /// <param name="warehousecode">倉庫コード</param>
        public ShareCheckKey(string enterprisecode, ShareCheckType type, string sectioncode, string warehousecode)
            : this()
        {
            this.EnterpriseCode = enterprisecode;
            this.Type = type;
            this.SectionCode = (this.Type == ShareCheckType.Section) ? sectioncode : string.Empty;
            this.WarehouseCode = (this.Type == ShareCheckType.WareHouse) ? warehousecode : string.Empty;
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            this.TotalDay = 0;
            this.AddUpUpdDate = 0;
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<
            this.Result = ShareCheckResult.None;
        }
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterprisecode"></param>
        /// <param name="type"></param>
        /// <param name="sectioncode"></param>
        /// <param name="warehousecode"></param>
        /// <param name="totalDay"></param>
        /// <param name="addUpUpdDate"></param>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public ShareCheckKey(string enterprisecode, ShareCheckType type, string sectioncode, string warehousecode, int totalDay, int addUpUpdDate)
            : this()
        {
            this.EnterpriseCode = enterprisecode;
            this.Type = type;
            //this.SectionCode = (this.Type == ShareCheckType.Section || this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate) ? sectioncode : string.Empty;//DEL yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
            this.SectionCode = (this.Type == ShareCheckType.Section || this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate) ? sectioncode : string.Empty;//ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
            this.WarehouseCode = (this.Type == ShareCheckType.WareHouse) ? warehousecode : string.Empty;
            //this.TotalDay = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate) ? totalDay : 0;//DEL yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
            this.TotalDay = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate) ? totalDay : 0;//ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
            //this.AddUpUpdDate = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate) ? addUpUpdDate : 0;//DEL yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
            this.AddUpUpdDate = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate) ? addUpUpdDate : 0;//ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
            this.Result = ShareCheckResult.None;
        }
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<

        /// <summary>
        /// シェアチェックタイプ名
        /// </summary>
        internal string TypeText
        {
            set
            {
                this.Type = ShareCheckType.None;
                try
                {
                    foreach (ShareCheckType type in this.TypeTextDic.Keys)
                    {
                        if (this.TypeTextDic[type].CompareTo(value) == 0)
                        {
                            this.Type = type;
                            break;
                        }
                    }
                }
                catch
                {
                    // 黙殺
                }
            }

            get
            {
                return this.TypeTextDic[this.Type];
            }
        }

        /// <summary>
        /// シェアチェック用リソース名
        /// </summary>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        internal string ResourceName
        {
            get
            {
                string rNm = string.Empty;

                if (this.Type != ShareCheckType.None)
                {
                    // --- UPD m.suzuki 2010/08/16 ---------->>>>>
                    //// 企業コード(16桁)＋分類(3桁)＋拠点・倉庫コード(6桁)
                    // 企業コード(16桁)＋分類(2桁)＋拠点・倉庫コード(4桁)＋[ 締日(2桁)＋日付(8桁) ]
                    // --- UPD m.suzuki 2010/08/16 ----------<<<<<
                    rNm = this.EnterpriseCode + this.TypeText;

                    switch (this.Type)
                    {
                        case ShareCheckType.Enterprise:
                            {
                                // --- UPD m.suzuki 2010/08/16 ---------->>>>>
                                //rNm += "000000";
                                rNm += "0000";
                                // --- UPD m.suzuki 2010/08/16 ----------<<<<<
                                break;
                            }
                        case ShareCheckType.Section:
                            {
                                rNm += this.SectionCode;
                                break;
                            }
                        case ShareCheckType.WareHouse:
                            {
                                rNm += this.WarehouseCode;
                                break;
                            }
                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                        case ShareCheckType.AddUpSlip:
                        case ShareCheckType.AddUpUpdate:
                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                        case ShareCheckType.SupUpSlip:
                        case ShareCheckType.SupUpUpdate:
                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
                            {
                                rNm += this.SectionCode + this.TotalDay.ToString( "00" ) + this.AddUpUpdDate.ToString( "00000000" );
                                break;
                            }
                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                    }
                }

                return rNm;
            }
        }

        /// <summary>
        /// 現在のオブジェクトを同じ型の別のオブジェクトと比較します。
        /// </summary>
        /// <param name="other">このオブジェクトと比較するオブジェクト。</param>
        /// <returns>int</returns>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public int CompareTo(ShareCheckKey other)
        {
            // 企業コードで比較
            int ret = this.EnterpriseCode.CompareTo(other.EnterpriseCode);

            if (ret == 0)
            {
                // シェアチェックタイプで比較
                ret = this.Type.CompareTo(other.Type);
            }

            if (ret == 0)
            {
                if (this.Type == ShareCheckType.Section)
                {
                    // 拠点コードで比較
                    ret = this.SectionCode.CompareTo(other.SectionCode);
                }
                else if (this.Type == ShareCheckType.WareHouse)
                {
                    // 倉庫コードで比較
                    ret = this.WarehouseCode.CompareTo(other.WarehouseCode);
                }
                // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                //else if ( this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate )//DEL yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
                else if (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate)//ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
                {
                    // 拠点コード・締日・締次更新日で比較
                    ret = this.SectionCode.CompareTo( other.SectionCode );
                    if ( ret == 0 )
                    {
                        ret = this.TotalDay.CompareTo( other.TotalDay );
                        if ( ret == 0 )
                        {
                            ret = this.AddUpUpdDate.CompareTo( other.AddUpUpdDate );
                        }
                    }
                }
                // --- ADD m.suzuki 2010/08/16 ----------<<<<<
            }

            return ret;
        }
    }

    /// <summary>
    /// シェアチェックキーを格納するジェネリック・クラス
    /// </summary>
    public class ShareCheckKeyList : List<ShareCheckKey>
    {
        /// <summary>
        /// ShareCheckKeyList の末尾に、指定した値を持つ ShareCheckKey を追加します。
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="type">シェアチェックタイプ</param>
        /// <param name="sectioncode">拠点コード</param>
        /// <param name="warehousecode">倉庫コード</param>
        public void Add(string enterprisecode, ShareCheckType type, string sectioncode, string warehousecode)
        {
            base.Add(new ShareCheckKey(enterprisecode, type, sectioncode, warehousecode));
        }

        /// <summary>
        /// 条件に合致するシェアチェックキーのシェアチェック結果を、指定された値に設定します
        /// </summary>
        /// <param name="value">シェアチェック結果</param>
        /// <param name="match">検索条件</param>
        internal void SetKeyResult(ShareCheckResult value, Predicate<ShareCheckKey> match)
        {
            foreach (ShareCheckKey key in this.FindAll(match))
            {
                key.Result = value;
            }
        }

        /// <summary>
        /// 其々のシェアチェック結果を比較し、総合結果を取得する
        /// </summary>
        /// <param name="key">総合結果と同じ結果を持つ最初のShareCheckKey</param>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public void GetIntegratedResult(out ShareCheckKey key)
        {
            key = null;

            List<ShareCheckResult> order = new List<ShareCheckResult>();
            order.Add(ShareCheckResult.None);                   // ↑(低い) 未設定
            order.Add(ShareCheckResult.Success);                //          成功
            order.Add(ShareCheckResult.Failure);                //          失敗
            order.Add(ShareCheckResult.WareHouseLockFailure);   //          倉庫ロックによる失敗
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            order.Add( ShareCheckResult.AddUpSlipLockFailure );   //        締次集計ロックによる失敗
            order.Add( ShareCheckResult.AddUpUpdateLockFailure ); //        締次集計ロックによる失敗
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<
            //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
            order.Add(ShareCheckResult.SupUpUpdateLockFailure);   //        締次集計ロックによる失敗
            order.Add(ShareCheckResult.SupUpSlipLockFailure); //            締次集計ロックによる失敗
            //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
            order.Add(ShareCheckResult.SectionLockFailure);     //          拠点ロックによる失敗
            order.Add(ShareCheckResult.EnterpriseLockFailure);  // ↓(高い) 企業ロックによる失敗

            foreach (ShareCheckResult value in order)
            {
                ShareCheckKey tmpKey = this.Find(delegate(ShareCheckKey item) { return item.Result == value; });

                if (tmpKey != null)
                {
                    key = tmpKey;
                }
            }
        }
    }

    /// <summary>
    /// シェアチェックに関する付随情報を定義します
    /// </summary>
    public class ShareCheckInfo
    {
        // デフォルトのシェアチェックタイムアウト時間を㍉秒で指定する
        private const int DEFAULT_SHARECHECK_TIMEOUT = 1000;  // 1秒

        // デフォルトのシェアチェック確認リトライ回数を指定する
        private const int DEFAULT_SHARECHECK_RETRY = 5;       // 5回

        private ShareCheckKeyList _Keys = null;
        private int _RetryCount = 0;
        private int _TimeOut = 0;

        /// <summary>
        /// シェアチェックキーを指定します
        /// </summary>
        public ShareCheckKeyList Keys
        {
            get
            {
                if (this._Keys == null)
                {
                    this._Keys = new ShareCheckKeyList();
                }

                return this._Keys;
            }
        }

        /// <summary>
        /// リトライ数を指定します
        /// </summary>
        public int RetryCount
        {
            get { return this._RetryCount; }
            set { this._RetryCount = value; }
        }

        /// <summary>
        /// タイムアウト時間をミリ秒で指定します
        /// </summary>
        public int TimeOut
        {
            get { return this._TimeOut; }
            set { this._TimeOut = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShareCheckInfo()
        {
            this._RetryCount = DEFAULT_SHARECHECK_RETRY;
            this._TimeOut = DEFAULT_SHARECHECK_TIMEOUT;
        }
    }

    # endregion
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス設定マスタメンテナンス
// プログラム概要   : オートバックス設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/08/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// オートバックス設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : オートバックス設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndESettingDB : RemoteDB, ISAndESettingDB
    {
        /// <summary>
        /// オートバックス設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public SAndESettingDB()
            : base("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork", "SANDESETTING")
        {

        }

        # region [Delete]
        /// <summary>
        /// オートバックス設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SAndESettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        public int Delete(ref object parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {

                SAndESettingWork sAndESettingWork = parabyte as SAndESettingWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(ref sAndESettingWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "SAndESettingDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.Delete", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// オートバックス設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="sAndESettingWork">オートバックス設定マスタ情報 ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        private int DeleteProc(ref SAndESettingWork sAndESettingWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndESettingWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText = "SELECT UPDATEDATETIMERF FROM SANDESETTINGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndESettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE文]
                        sqlText = "DELETE FROM SANDESETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.DeleteProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// オートバックス設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSAndESettingList">検索結果</param>
        /// <param name="paraSAndESettingWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        public int Search(out object outSAndESettingList, object paraSAndESettingWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _sAndESettingList = null;
            SAndESettingWork sAndESettingWork = null;

            outSAndESettingList = new CustomSerializeArrayList();

            try
            {
                sAndESettingWork = paraSAndESettingWork as SAndESettingWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchProc(out _sAndESettingList, sAndESettingWork, readMode, logicalMode, ref sqlConnection);

                if (_sAndESettingList != null)
                {
                    (outSAndESettingList as CustomSerializeArrayList).AddRange(_sAndESettingList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// オートバックス設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="sAndESettingList">検索結果</param>
        /// <param name="sAndESettingWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        private int SearchProc(out ArrayList sAndESettingList, SAndESettingWork sAndESettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                // コネクション生成
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append(" SELECT ");
                sqlText.Append(" A.CREATEDATETIMERF, ");      // 作成日時
                sqlText.Append(" A.ENTERPRISECODERF, ");      // 企業コード
                sqlText.Append(" A.FILEHEADERGUIDRF, ");      // GUID
                sqlText.Append(" A.UPDEMPLOYEECODERF, ");     // 更新従業員コード
                sqlText.Append(" A.UPDASSEMBLYID1RF, ");      // 更新アセンブリID1
                sqlText.Append(" A.UPDASSEMBLYID2RF, ");      // 更新アセンブリID2
                sqlText.Append(" A.UPDATEDATETIMERF, ");      // 更新日時
                sqlText.Append(" A.LOGICALDELETECODERF, ");   // 論理削除区分
                sqlText.Append(" A.SECTIONCODERF, ");         // 拠点コード
                sqlText.Append(" A.CUSTOMERCODERF, ");        // 得意先コード
                sqlText.Append(" A.ADDRESSEESHOPCDRF, ");     // 納品先店舗コード
                sqlText.Append(" A.SANDEMNGCODERF, ");        // 住電管理コード
                sqlText.Append(" A.EXPENSEDIVCDRF,");         // 経費区分
                sqlText.Append(" A.DIRECTSENDINGCDRF, ");     // 直送区分
                sqlText.Append(" A.ACPTANORDERDIVRF, ");      // 受注区分
                sqlText.Append(" A.DELIVERERCDRF, ");         // 納品者コード
                sqlText.Append(" A.DELIVERERNMRF, ");         // 納品者名
                sqlText.Append(" A.DELIVERERADDRESSRF, ");    // 納品者住所
                sqlText.Append(" A.DELIVERERPHONENUMRF, ");   // 納品者ＴＥＬ
                sqlText.Append(" A.TRADCOMPNAMERF, ");        // 部品商名
                sqlText.Append(" A.TRADCOMPSECTNAMERF, ");    // 部品商拠点名
                sqlText.Append(" A.PURETRADCOMPCDRF, ");      // 部品商コード（純正）
                sqlText.Append(" A.PURETRADCOMPRATERF, ");    // 部品商仕切率（純正）
                sqlText.Append(" A.PRITRADCOMPCDRF, ");       // 部品商コード（優良）
                sqlText.Append(" A.PRITRADCOMPRATERF, ");     // 部品商仕切率（優良）
                sqlText.Append(" A.ABGOODSCODERF, ");         // AB商品コード
                sqlText.Append(" A.COMMENTRESERVEDDIVRF, ");  // コメント指定区分
                sqlText.Append(" A.GOODSMAKERCD1RF, ");       // 商品メーカーコード１
                sqlText.Append(" A.GOODSMAKERCD2RF, ");       // 商品メーカーコード２
                sqlText.Append(" A.GOODSMAKERCD3RF, ");       // 商品メーカーコード３
                sqlText.Append(" A.GOODSMAKERCD4RF, ");       // 商品メーカーコード４
                sqlText.Append(" A.GOODSMAKERCD5RF, ");       // 商品メーカーコード５
                sqlText.Append(" A.GOODSMAKERCD6RF, ");       // 商品メーカーコード６
                sqlText.Append(" A.GOODSMAKERCD7RF, ");       // 商品メーカーコード７
                sqlText.Append(" A.GOODSMAKERCD8RF, ");       // 商品メーカーコード８
                sqlText.Append(" A.GOODSMAKERCD9RF, ");       // 商品メーカーコード９
                sqlText.Append(" A.GOODSMAKERCD10RF, ");      // 商品メーカーコード１０
                sqlText.Append(" A.GOODSMAKERCD11RF, ");      // 商品メーカーコード１１
                sqlText.Append(" A.GOODSMAKERCD12RF, ");      // 商品メーカーコード１２
                sqlText.Append(" A.GOODSMAKERCD13RF, ");      // 商品メーカーコード１３
                sqlText.Append(" A.GOODSMAKERCD14RF, ");      // 商品メーカーコード１４
                sqlText.Append(" A.GOODSMAKERCD15RF, ");      // 商品メーカーコード１５
                sqlText.Append(" A.PARTSOEMDIVRF, ");         // 部品ＯＥＭ区分
                sqlText.Append(" B.SECTIONGUIDENMRF, ");      // 拠点ガイド名称
                sqlText.Append(" C.CUSTOMERSNMRF ");          // 得意先略称
                sqlText.Append(" FROM SANDESETTINGRF A WITH (READUNCOMMITTED) ");        // オートバックス設定マスタ
                sqlText.Append(" LEFT JOIN  SECINFOSETRF B WITH (READUNCOMMITTED) ON "); // 拠点情報設定マスタ
                sqlText.Append(" (A.ENTERPRISECODERF= B.ENTERPRISECODERF ");
                sqlText.Append(" AND B.LOGICALDELETECODERF = 0 ");
                sqlText.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF) ");
                sqlText.Append(" LEFT JOIN  CUSTOMERRF C WITH (READUNCOMMITTED) ON ");
                sqlText.Append(" (A.ENTERPRISECODERF= C.ENTERPRISECODERF ");
                sqlText.Append(" AND A.CUSTOMERCODERF = C.CUSTOMERCODERF ");
                sqlText.Append(" AND C.LOGICALDELETECODERF = 0) ");
                sqlCommand.CommandText += sqlText.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndESettingWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSAndESettingWorkFromReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.SearchProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            sAndESettingList = al;

            return status;

        }

        # endregion

        #region [write]
        /// <summary>
        /// オートバックス設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="sAndESettingWork">オートバックス設定マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        public int Write(ref object sAndESettingWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                SAndESettingWork wksAndESettingWork = sAndESettingWork as SAndESettingWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = WriteProc(ref wksAndESettingWork, ref sqlConnection, ref sqlTransaction);

                // 戻り値セット
                sAndESettingWork = wksAndESettingWork;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndESettingDB.Write", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// オートバックス設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="sAndESettingWork">追加・更新するオートバックス設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sAndESettingWork に格納されているオートバックス設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        private int WriteProc(ref SAndESettingWork sAndESettingWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SAndESettingWork al = new SAndESettingWork();

            try
            {
                if (sAndESettingWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText = "SELECT UPDATEDATETIMERF FROM SANDESETTINGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndESettingWork.UpdateDateTime)
                        {
                            if (sAndESettingWork.UpdateDateTime == DateTime.MinValue)
                            {
                                // 新規登録で該当データ有りの場合には重複
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                // 既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            return status;
                        }

                        # region [UPDATE文]
                        sqlText = "UPDATE SANDESETTINGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CUSTOMERCODERF=@CUSTOMERCODE , ADDRESSEESHOPCDRF=@ADDRESSEESHOPCD , SANDEMNGCODERF=@SANDEMNGCODE , EXPENSEDIVCDRF=@EXPENSEDIVCD , DIRECTSENDINGCDRF=@DIRECTSENDINGCD , ACPTANORDERDIVRF=@ACPTANORDERDIV , DELIVERERCDRF=@DELIVERERCD , DELIVERERNMRF=@DELIVERERNM , DELIVERERADDRESSRF=@DELIVERERADDRESS , DELIVERERPHONENUMRF=@DELIVERERPHONENUM , TRADCOMPNAMERF=@TRADCOMPNAME , TRADCOMPSECTNAMERF=@TRADCOMPSECTNAME , PURETRADCOMPCDRF=@PURETRADCOMPCD , PURETRADCOMPRATERF=@PURETRADCOMPRATE , PRITRADCOMPCDRF=@PRITRADCOMPCD , PRITRADCOMPRATERF=@PRITRADCOMPRATE , ABGOODSCODERF=@ABGOODSCODE , COMMENTRESERVEDDIVRF=@COMMENTRESERVEDDIV , GOODSMAKERCD1RF=@GOODSMAKERCD1 , GOODSMAKERCD2RF=@GOODSMAKERCD2 , GOODSMAKERCD3RF=@GOODSMAKERCD3 , GOODSMAKERCD4RF=@GOODSMAKERCD4 , GOODSMAKERCD5RF=@GOODSMAKERCD5 , GOODSMAKERCD6RF=@GOODSMAKERCD6 , GOODSMAKERCD7RF=@GOODSMAKERCD7 , GOODSMAKERCD8RF=@GOODSMAKERCD8 , GOODSMAKERCD9RF=@GOODSMAKERCD9 , GOODSMAKERCD10RF=@GOODSMAKERCD10 , GOODSMAKERCD11RF=@GOODSMAKERCD11 , GOODSMAKERCD12RF=@GOODSMAKERCD12 , GOODSMAKERCD13RF=@GOODSMAKERCD13 , GOODSMAKERCD14RF=@GOODSMAKERCD14 , GOODSMAKERCD15RF=@GOODSMAKERCD15 , PARTSOEMDIVRF=@PARTSOEMDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (sAndESettingWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        sqlText = "INSERT INTO SANDESETTINGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, ADDRESSEESHOPCDRF, SANDEMNGCODERF, EXPENSEDIVCDRF, DIRECTSENDINGCDRF, ACPTANORDERDIVRF, DELIVERERCDRF, DELIVERERNMRF, DELIVERERADDRESSRF, DELIVERERPHONENUMRF, TRADCOMPNAMERF, TRADCOMPSECTNAMERF, PURETRADCOMPCDRF, PURETRADCOMPRATERF, PRITRADCOMPCDRF, PRITRADCOMPRATERF, ABGOODSCODERF, COMMENTRESERVEDDIVRF, GOODSMAKERCD1RF, GOODSMAKERCD2RF, GOODSMAKERCD3RF, GOODSMAKERCD4RF, GOODSMAKERCD5RF, GOODSMAKERCD6RF, GOODSMAKERCD7RF, GOODSMAKERCD8RF, GOODSMAKERCD9RF, GOODSMAKERCD10RF, GOODSMAKERCD11RF, GOODSMAKERCD12RF, GOODSMAKERCD13RF, GOODSMAKERCD14RF, GOODSMAKERCD15RF, PARTSOEMDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CUSTOMERCODE, @ADDRESSEESHOPCD, @SANDEMNGCODE, @EXPENSEDIVCD, @DIRECTSENDINGCD, @ACPTANORDERDIV, @DELIVERERCD, @DELIVERERNM, @DELIVERERADDRESS, @DELIVERERPHONENUM, @TRADCOMPNAME, @TRADCOMPSECTNAME, @PURETRADCOMPCD, @PURETRADCOMPRATE, @PRITRADCOMPCD, @PRITRADCOMPRATE, @ABGOODSCODE, @COMMENTRESERVEDDIV, @GOODSMAKERCD1, @GOODSMAKERCD2, @GOODSMAKERCD3, @GOODSMAKERCD4, @GOODSMAKERCD5, @GOODSMAKERCD6, @GOODSMAKERCD7, @GOODSMAKERCD8, @GOODSMAKERCD9, @GOODSMAKERCD10, @GOODSMAKERCD11, @GOODSMAKERCD12, @GOODSMAKERCD13, @GOODSMAKERCD14, @GOODSMAKERCD15, @PARTSOEMDIV)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraAddresseeShopCd = sqlCommand.Parameters.Add("@ADDRESSEESHOPCD", SqlDbType.NVarChar);
                    SqlParameter paraSAndEMngCode = sqlCommand.Parameters.Add("@SANDEMNGCODE", SqlDbType.NVarChar);
                    SqlParameter paraExpenseDivCd = sqlCommand.Parameters.Add("@EXPENSEDIVCD", SqlDbType.Int);
                    SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);
                    SqlParameter paraAcptAnOrderDiv = sqlCommand.Parameters.Add("@ACPTANORDERDIV", SqlDbType.Int);
                    SqlParameter paraDelivererCd = sqlCommand.Parameters.Add("@DELIVERERCD", SqlDbType.NVarChar);
                    SqlParameter paraDelivererNm = sqlCommand.Parameters.Add("@DELIVERERNM", SqlDbType.NVarChar);
                    SqlParameter paraDelivererAddress = sqlCommand.Parameters.Add("@DELIVERERADDRESS", SqlDbType.NVarChar);
                    SqlParameter paraDelivererPhoneNum = sqlCommand.Parameters.Add("@DELIVERERPHONENUM", SqlDbType.NVarChar);
                    SqlParameter paraTradCompName = sqlCommand.Parameters.Add("@TRADCOMPNAME", SqlDbType.NVarChar);
                    SqlParameter paraTradCompSectName = sqlCommand.Parameters.Add("@TRADCOMPSECTNAME", SqlDbType.NVarChar);
                    SqlParameter paraPureTradCompCd = sqlCommand.Parameters.Add("@PURETRADCOMPCD", SqlDbType.NVarChar);
                    SqlParameter paraPureTradCompRate = sqlCommand.Parameters.Add("@PURETRADCOMPRATE", SqlDbType.Float);
                    SqlParameter paraPriTradCompCd = sqlCommand.Parameters.Add("@PRITRADCOMPCD", SqlDbType.NVarChar);
                    SqlParameter paraPriTradCompRate = sqlCommand.Parameters.Add("@PRITRADCOMPRATE", SqlDbType.Float);
                    SqlParameter paraABGoodsCode = sqlCommand.Parameters.Add("@ABGOODSCODE", SqlDbType.NVarChar);
                    SqlParameter paraCommentReservedDiv = sqlCommand.Parameters.Add("@COMMENTRESERVEDDIV", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd1 = sqlCommand.Parameters.Add("@GOODSMAKERCD1", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd2 = sqlCommand.Parameters.Add("@GOODSMAKERCD2", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd3 = sqlCommand.Parameters.Add("@GOODSMAKERCD3", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd4 = sqlCommand.Parameters.Add("@GOODSMAKERCD4", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd5 = sqlCommand.Parameters.Add("@GOODSMAKERCD5", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd6 = sqlCommand.Parameters.Add("@GOODSMAKERCD6", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd7 = sqlCommand.Parameters.Add("@GOODSMAKERCD7", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd8 = sqlCommand.Parameters.Add("@GOODSMAKERCD8", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd9 = sqlCommand.Parameters.Add("@GOODSMAKERCD9", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd10 = sqlCommand.Parameters.Add("@GOODSMAKERCD10", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd11 = sqlCommand.Parameters.Add("@GOODSMAKERCD11", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd12 = sqlCommand.Parameters.Add("@GOODSMAKERCD12", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd13 = sqlCommand.Parameters.Add("@GOODSMAKERCD13", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd14 = sqlCommand.Parameters.Add("@GOODSMAKERCD14", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd15 = sqlCommand.Parameters.Add("@GOODSMAKERCD15", SqlDbType.Int);
                    SqlParameter paraPartsOEMDiv = sqlCommand.Parameters.Add("@PARTSOEMDIV", SqlDbType.Int);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESettingWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESettingWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndESettingWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);
                    paraAddresseeShopCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.AddresseeShopCd);
                    paraSAndEMngCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SAndEMngCode);
                    paraExpenseDivCd.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.ExpenseDivCd);
                    paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.DirectSendingCd);
                    paraAcptAnOrderDiv.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.AcptAnOrderDiv);
                    paraDelivererCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererCd);
                    paraDelivererNm.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererNm);
                    paraDelivererAddress.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererAddress);
                    paraDelivererPhoneNum.Value = SqlDataMediator.SqlSetString(sAndESettingWork.DelivererPhoneNum);
                    paraTradCompName.Value = SqlDataMediator.SqlSetString(sAndESettingWork.TradCompName);
                    paraTradCompSectName.Value = SqlDataMediator.SqlSetString(sAndESettingWork.TradCompSectName);
                    paraPureTradCompCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.PureTradCompCd);
                    paraPureTradCompRate.Value = SqlDataMediator.SqlSetDouble(sAndESettingWork.PureTradCompRate);
                    paraPriTradCompCd.Value = SqlDataMediator.SqlSetString(sAndESettingWork.PriTradCompCd);
                    paraPriTradCompRate.Value = SqlDataMediator.SqlSetDouble(sAndESettingWork.PriTradCompRate);
                    paraABGoodsCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.ABGoodsCode);
                    paraCommentReservedDiv.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CommentReservedDiv);
                    paraGoodsMakerCd1.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd1);
                    paraGoodsMakerCd2.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd2);
                    paraGoodsMakerCd3.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd3);
                    paraGoodsMakerCd4.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd4);
                    paraGoodsMakerCd5.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd5);
                    paraGoodsMakerCd6.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd6);
                    paraGoodsMakerCd7.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd7);
                    paraGoodsMakerCd8.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd8);
                    paraGoodsMakerCd9.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd9);
                    paraGoodsMakerCd10.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd10);
                    paraGoodsMakerCd11.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd11);
                    paraGoodsMakerCd12.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd12);
                    paraGoodsMakerCd13.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd13);
                    paraGoodsMakerCd14.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd14);
                    paraGoodsMakerCd15.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.GoodsMakerCd15);
                    paraPartsOEMDiv.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.PartsOEMDiv);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al = sAndESettingWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndESettingDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.WriteProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            sAndESettingWork = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// オートバックス設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="sAndESettingWork">論理削除するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        public int LogicalDelete(ref object sAndESettingWork)
        {
            return this.LogicalDeleteProc(ref sAndESettingWork, 0);
        }

        /// <summary>
        /// オートバックス設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="sAndESettingWork">論理削除を解除するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        public int RevivalLogicalDelete(ref object sAndESettingWork)
        {
            return this.LogicalDeleteProc(ref sAndESettingWork, 1);
        }

        /// <summary>
        /// オートバックス設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="sAndESettingWork">論理削除を操作するオートバックス設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        private int LogicalDeleteProc(ref object sAndESettingWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SAndESettingWork paraList = sAndESettingWork as SAndESettingWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                sAndESettingWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "SAndESettingDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndESettingDB.LogicalDeleteProc", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;

        }

        /// <summary>
        /// オートバックス設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="sAndESettingWork">論理削除を操作するオートバックス設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        private int LogicalDeleteProc(ref SAndESettingWork sAndESettingWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sAndESettingWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText = "SELECT UPDATEDATETIMERF,LOGICALDELETECODERF FROM SANDESETTINGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);


                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndESettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        sqlText = "UPDATE SANDESETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) sAndESettingWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else sAndESettingWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            sAndESettingWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                            }

                            return status;
                        }
                    }

                    // Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESettingWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndESettingWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndESettingWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sAndESettingWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqex, "SAndESettingDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndESettingDB.DeleteProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="sAndESettingWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndESettingWork sAndESettingWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += " A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESettingWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND A.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND A.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY " + Environment.NewLine;
            retstring += " A.SECTIONCODERF," + Environment.NewLine;
            retstring += " A.CUSTOMERCODERF" + Environment.NewLine;
            return retstring;
        }

        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SAndESettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SAndESettingWork CopyToSAndESettingWorkFromReader(ref SqlDataReader myReader)
        {
            SAndESettingWork sAndESettingWork = new SAndESettingWork();

            this.CopyToSAndESettingWorkFromReader(ref myReader, ref sAndESettingWork);

            return sAndESettingWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → SAndESettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sAndESettingWork">sAndESettingWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void CopyToSAndESettingWorkFromReader(ref SqlDataReader myReader, ref SAndESettingWork sAndESettingWork)
        {
            if (myReader != null && sAndESettingWork != null)
            {
                # region クラスへ格納
                sAndESettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sAndESettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sAndESettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sAndESettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sAndESettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sAndESettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sAndESettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sAndESettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sAndESettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                sAndESettingWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                sAndESettingWork.AddresseeShopCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));
                sAndESettingWork.SAndEMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));
                sAndESettingWork.ExpenseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));
                sAndESettingWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
                sAndESettingWork.AcptAnOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANORDERDIVRF"));
                sAndESettingWork.DelivererCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERCDRF"));
                sAndESettingWork.DelivererNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERNMRF"));
                sAndESettingWork.DelivererAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERADDRESSRF"));
                sAndESettingWork.DelivererPhoneNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERPHONENUMRF"));
                sAndESettingWork.TradCompName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                sAndESettingWork.TradCompSectName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPSECTNAMERF"));
                sAndESettingWork.PureTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));
                sAndESettingWork.PureTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));
                sAndESettingWork.PriTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));
                sAndESettingWork.PriTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));
                sAndESettingWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                sAndESettingWork.CommentReservedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMENTRESERVEDDIVRF"));
                sAndESettingWork.GoodsMakerCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));
                sAndESettingWork.GoodsMakerCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));
                sAndESettingWork.GoodsMakerCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));
                sAndESettingWork.GoodsMakerCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));
                sAndESettingWork.GoodsMakerCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));
                sAndESettingWork.GoodsMakerCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));
                sAndESettingWork.GoodsMakerCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));
                sAndESettingWork.GoodsMakerCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));
                sAndESettingWork.GoodsMakerCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));
                sAndESettingWork.GoodsMakerCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));
                sAndESettingWork.GoodsMakerCd11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));
                sAndESettingWork.GoodsMakerCd12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));
                sAndESettingWork.GoodsMakerCd13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));
                sAndESettingWork.GoodsMakerCd14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));
                sAndESettingWork.GoodsMakerCd15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));
                sAndESettingWork.PartsOEMDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSOEMDIVRF")); 
                sAndESettingWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                sAndESettingWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
               # endregion
            }
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        # endregion
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   :表示区分マスタメンテナンス
// プログラム概要   :表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/16  修正内容 : 新規作成
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
    ///表示区分マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       :表示区分マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PriceSelectSetDB : RemoteDB, IPriceSelectSetDB
    {
        /// <summary>
        ///表示区分マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        public PriceSelectSetDB()
            : base("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork", "PRICESELECTSET")
        {

        }

        # region [Delete]
        /// <summary>
        ///表示区分マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">PriceSelectSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報を物理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        public int Delete(ref object parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {

                PriceSelectSetWork priceSelectSetWork = parabyte as PriceSelectSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(ref priceSelectSetWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "PriceSelectSetDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.Delete", status);
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
        ///表示区分マスタ情報を物理削除します
        /// </summary>
        /// <param name="priceSelectSetWork">オートバックス設定マスタ情報 ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報を物理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        private int DeleteProc(ref PriceSelectSetWork priceSelectSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (priceSelectSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != priceSelectSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE文]
                        sqlText = "DELETE FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

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
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.DeleteProc", status);
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
        ///表示区分マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outPriceSelectSetList">検索結果</param>
        /// <param name="paraPriceSelectSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        public int Search(out object outPriceSelectSetList, object paraPriceSelectSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _priceSelectSetgList = null;
            PriceSelectSetWork priceSelectSetWork = null;

            outPriceSelectSetList = new CustomSerializeArrayList();

            try
            {
                priceSelectSetWork = paraPriceSelectSetWork as PriceSelectSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchProc(out _priceSelectSetgList, priceSelectSetWork, readMode, logicalMode, ref sqlConnection);

                if (_priceSelectSetgList != null)
                {
                    (outPriceSelectSetList as CustomSerializeArrayList).AddRange(_priceSelectSetgList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.Search", status);
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
        ///表示区分マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="priceSelectSetList">検索結果</param>
        /// <param name="priceSelectSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        private int SearchProc(out ArrayList priceSelectSetList, PriceSelectSetWork priceSelectSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText.Append(" A.PRICESELECTPTNRF, ");      // 入力パターン
                sqlText.Append(" A.GOODSMAKERCDRF, ");        // メーカーコード
                sqlText.Append(" A.BLGOODSCODERF, ");         // BLコード
                sqlText.Append(" A.CUSTRATEGRPCODERF, ");     // 得意先掛率グループ
                sqlText.Append(" A.CUSTOMERCODERF, ");        // 得意先コード
                sqlText.Append(" A.PRICESELECTDIVRF,");       // 価格表示区分
                sqlText.Append(" B.CUSTOMERSNMRF, ");         // 得意先略称
                sqlText.Append(" C.BLGOODSFULLNAMERF, ");     // BL全角名称
                sqlText.Append(" D.MAKERNAMERF  ");           // メーカー名
                sqlText.Append(" FROM PRICESELECTSETRF  A WITH (READUNCOMMITTED) ");        //表示区分マスタ
                sqlText.Append(" LEFT JOIN  CUSTOMERRF B WITH (READUNCOMMITTED) ON ");// 得意先マスタ
                sqlText.Append(" (A.ENTERPRISECODERF= B.ENTERPRISECODERF ");
                sqlText.Append(" AND A.CUSTOMERCODERF = B.CUSTOMERCODERF ");
                sqlText.Append(" AND B.LOGICALDELETECODERF = 0) ");
                sqlText.Append(" LEFT JOIN  BLGOODSCDURF C WITH (READUNCOMMITTED) ON ");// BLコードマスタ
                sqlText.Append(" (A.ENTERPRISECODERF= C.ENTERPRISECODERF ");
                sqlText.Append(" AND A.BLGOODSCODERF = C.BLGOODSCODERF ");
                sqlText.Append(" AND C.LOGICALDELETECODERF = 0) ");
                sqlText.Append(" LEFT JOIN  MAKERURF D WITH (READUNCOMMITTED) ON ");// メーカーマスタ
                sqlText.Append(" (A.ENTERPRISECODERF= D.ENTERPRISECODERF ");
                sqlText.Append(" AND A.GOODSMAKERCDRF = D.GOODSMAKERCDRF ");
                sqlText.Append(" AND D.LOGICALDELETECODERF = 0) ");
                sqlCommand.CommandText += sqlText.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, priceSelectSetWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToPriceSelectSetWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.SearchProc", status);
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

            priceSelectSetList = al;

            return status;

        }

        # endregion

        #region [write]
        /// <summary>
        ///表示区分マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="priceSelectSetWork">オートバックス設定マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        public int Write(ref object priceSelectSetWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                PriceSelectSetWork wkPriceSelectSetWork = priceSelectSetWork as PriceSelectSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = WriteProc(ref wkPriceSelectSetWork, ref sqlConnection, ref sqlTransaction);

                // 戻り値セット
                priceSelectSetWork = wkPriceSelectSetWork;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetDB.Write", status);
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
        ///表示区分マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="priceSelectSetWork">追加・更新するオートバックス設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PriceSelectSetWork に格納されているオートバックス設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        private int WriteProc(ref PriceSelectSetWork priceSelectSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PriceSelectSetWork al = new PriceSelectSetWork();

            try
            {
                if (priceSelectSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != priceSelectSetWork.UpdateDateTime)
                        {
                            if (priceSelectSetWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText = "UPDATE PRICESELECTSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PRICESELECTPTNRF=@PRICESELECTPTN , GOODSMAKERCDRF=@GOODSMAKERCD , BLGOODSCODERF=@BLGOODSCODE , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE , CUSTOMERCODERF=@CUSTOMERCODE , PRICESELECTDIVRF=@PRICESELECTDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)priceSelectSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (priceSelectSetWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        sqlText = "INSERT INTO PRICESELECTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PRICESELECTPTN, @GOODSMAKERCD, @BLGOODSCODE, @CUSTRATEGRPCODE, @CUSTOMERCODE, @PRICESELECTDIV)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)priceSelectSetWork;
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
                    SqlParameter paraPriceSelectPtn = sqlCommand.Parameters.Add("@PRICESELECTPTN", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraPriceSelectDiv = sqlCommand.Parameters.Add("@PRICESELECTDIV", SqlDbType.Int);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(priceSelectSetWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(priceSelectSetWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(priceSelectSetWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.LogicalDeleteCode);
                    paraPriceSelectPtn.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.PriceSelectPtn);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);
                    paraPriceSelectDiv.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.PriceSelectDiv);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al = priceSelectSetWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.WriteProc", status);
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

            priceSelectSetWork = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        ///表示区分マスタ情報を論理削除します。
        /// </summary>
        /// <param name="priceSelectSetWork">論理削除するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報を論理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        public int LogicalDelete(ref object priceSelectSetWork)
        {
            return this.LogicalDeleteProc(ref priceSelectSetWork, 0);
        }

        /// <summary>
        ///表示区分マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="priceSelectSetWork">論理削除を解除するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        public int RevivalLogicalDelete(ref object priceSelectSetWork)
        {
            return this.LogicalDeleteProc(ref priceSelectSetWork, 1);
        }

        /// <summary>
        ///表示区分マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="priceSelectSetWork">論理削除を操作するオートバックス設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        private int LogicalDeleteProc(ref object priceSelectSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PriceSelectSetWork paraList = priceSelectSetWork as PriceSelectSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                priceSelectSetWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "PriceSelectSetDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetDB.LogicalDeleteProc", status);
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
        ///表示区分マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="priceSelectSetWork">論理削除を操作するオートバックス設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :表示区分マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        private int LogicalDeleteProc(ref PriceSelectSetWork priceSelectSetWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (priceSelectSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);


                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != priceSelectSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        sqlText = "UPDATE PRICESELECTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)priceSelectSetWork;
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
                        else if (logicalDelCd == 0) priceSelectSetWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else priceSelectSetWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            priceSelectSetWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(priceSelectSetWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(priceSelectSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqex, "PriceSelectSetDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.DeleteProc", status);
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
        /// <param name="priceSelectSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PriceSelectSetWork priceSelectSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += " A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);

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
            retstring += " A.PRICESELECTPTNRF," + Environment.NewLine;
            retstring += " A.GOODSMAKERCDRF," + Environment.NewLine;
            retstring += " A.BLGOODSCODERF," + Environment.NewLine;
            retstring += " A.CUSTRATEGRPCODERF," + Environment.NewLine;
            retstring += " A.CUSTOMERCODERF" + Environment.NewLine;
            return retstring;
        }

        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PriceSelectSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        private PriceSelectSetWork CopyToPriceSelectSetWorkFromReader(ref SqlDataReader myReader)
        {
            PriceSelectSetWork priceSelectSetWork = new PriceSelectSetWork();

            this.CopyToPriceSelectSetWorkFromReader(ref myReader, ref priceSelectSetWork);

            return priceSelectSetWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PriceSelectSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="priceSelectSetWork">PriceSelectSetWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        private void CopyToPriceSelectSetWorkFromReader(ref SqlDataReader myReader, ref PriceSelectSetWork priceSelectSetWork)
        {
            if (myReader != null && priceSelectSetWork != null)
            {
                # region クラスへ格納
                priceSelectSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                priceSelectSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                priceSelectSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                priceSelectSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                priceSelectSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                priceSelectSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                priceSelectSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                priceSelectSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                priceSelectSetWork.PriceSelectPtn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTPTNRF"));
                priceSelectSetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                priceSelectSetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                priceSelectSetWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                priceSelectSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                priceSelectSetWork.PriceSelectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTDIVRF"));
                priceSelectSetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                priceSelectSetWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                priceSelectSetWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
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
        /// <br>Date       : 2009.10.16</br>
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
        /// <br>Date       : 2009.10.16</br>
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

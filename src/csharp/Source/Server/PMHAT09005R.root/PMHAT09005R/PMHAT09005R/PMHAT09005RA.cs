//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタメンテナンス
// プログラム概要   : 発注点設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注点設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.04.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class OrderPointStDB : RemoteDB, IOrderPointStDB
    {
        /// <summary>
        /// 発注点設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public OrderPointStDB()
            : base("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork", "OrderPointStRF")
        {

        }

        # region [Search]
        /// <summary>
        /// 発注点設定マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outOrderPointStList">検索結果</param>
        /// <param name="paraOrderPointStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタのキー値が一致する、全ての発注点設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public int Search(out object outOrderPointStList, object paraOrderPointStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _orderPointStList = null;
            OrderPointStWork orderPointStWork = null;

            outOrderPointStList = new CustomSerializeArrayList();

            try
            {
                orderPointStWork = paraOrderPointStWork as OrderPointStWork;
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(out _orderPointStList, orderPointStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointStDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            outOrderPointStList = _orderPointStList;

            return status;
        }

        /// <summary>
        /// 発注点設定マスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outOrderPointStList">検索結果</param>
        /// <param name="orderPointStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタのキー値が一致する、全ての発注点設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int SearchProc(out ArrayList outOrderPointStList, OrderPointStWork orderPointStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PATTERNORF, PATTERNNODERIVEDNORF, WAREHOUSECODERF, SUPPLIERCDRF, GOODSMAKERCDRF, GOODSMGROUPRF, BLGROUPCODERF, BLGOODSCODERF, STCKSHIPMONTHSTRF, STCKSHIPMONTHEDRF, ORDERAPPLYDIVRF, STOCKCREATEDATERF, SHIPSCOPEMORERF, SHIPSCOPELESSRF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, SALESORDERUNITRF, ORDERPPROCUPDFLGRF" + Environment.NewLine;
                sqlText += "FROM ORDERPOINTSTRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO" + Environment.NewLine;
                sqlText += "ORDER BY PATTERNNODERIVEDNORF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                findParaPatterNo.Value = orderPointStWork.PatterNo;

                sqlCommand.CommandText += sqlText;

                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToOrderPointStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OrderPointStDB.SearchProc" + status);
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

            outOrderPointStList = al;

            return status;
        }
        # endregion

        # region [Write]

        /// <summary>
        /// 発注点設定マスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStWorkList">OrderPointStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタを追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public int Write(ref object objOrderPointStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList orderPointStWorkList = objOrderPointStWorkList as ArrayList;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteProc(ref orderPointStWorkList, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointStDB.Write", status);
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

            //戻り値セット
            objOrderPointStWorkList = orderPointStWorkList;

            return status;
        }

        /// <summary>
        /// 発注点設定マスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStWorkList">発注点設定マスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int WriteProc(ref ArrayList orderPointStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList ayList= new ArrayList();

            try
            {
                string sqlText = string.Empty;

                // 画面の入力データの処理
                for (int index = 0; index < orderPointStWorkList.Count; index++)
                {
                    OrderPointStWork orderPointStWork = orderPointStWorkList[index] as OrderPointStWork;

                    using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM ORDERPOINTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO  AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);
                        SqlParameter findPatternNoDerivedNo = sqlCommand.Parameters.Add("@FINDPATTERNNODERIVEDNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                        findParaPatterNo.Value = orderPointStWork.PatterNo;
                        findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            DateTime comUpDateTime = orderPointStWork.UpdateDateTime;

                            // 排他チェック
                            if (_updateDateTime != comUpDateTime)
                            {
                                //既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }
                                return status;
                            }

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ORDERPOINTSTRF " + Environment.NewLine;
                            sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PATTERNORF=@PATTERNO , PATTERNNODERIVEDNORF=@PATTERNNODERIVEDNO , WAREHOUSECODERF=@WAREHOUSECODE , SUPPLIERCDRF=@SUPPLIERCD , GOODSMAKERCDRF=@GOODSMAKERCD , GOODSMGROUPRF=@GOODSMGROUP , BLGROUPCODERF=@BLGROUPCODE , BLGOODSCODERF=@BLGOODSCODE , STCKSHIPMONTHSTRF=@STCKSHIPMONTHST , STCKSHIPMONTHEDRF=@STCKSHIPMONTHED , ORDERAPPLYDIVRF=@ORDERAPPLYDIV , STOCKCREATEDATERF=@STOCKCREATEDATE , SHIPSCOPEMORERF=@SHIPSCOPEMORE , SHIPSCOPELESSRF=@SHIPSCOPELESS , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT , SALESORDERUNITRF=@SALESORDERUNIT , ORDERPPROCUPDFLGRF=@ORDERPPROCUPDFLG " + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                            findParaPatterNo.Value = orderPointStWork.PatterNo;
                            findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)orderPointStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (orderPointStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //　画面のデータ、insert処理
                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO ORDERPOINTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PATTERNORF, PATTERNNODERIVEDNORF, WAREHOUSECODERF, SUPPLIERCDRF, GOODSMAKERCDRF, GOODSMGROUPRF, BLGROUPCODERF, BLGOODSCODERF, STCKSHIPMONTHSTRF, STCKSHIPMONTHEDRF, ORDERAPPLYDIVRF, STOCKCREATEDATERF, SHIPSCOPEMORERF, SHIPSCOPELESSRF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, SALESORDERUNITRF, ORDERPPROCUPDFLGRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PATTERNO, @PATTERNNODERIVEDNO, @WAREHOUSECODE, @SUPPLIERCD, @GOODSMAKERCD, @GOODSMGROUP, @BLGROUPCODE, @BLGOODSCODE, @STCKSHIPMONTHST, @STCKSHIPMONTHED, @ORDERAPPLYDIV, @STOCKCREATEDATE, @SHIPSCOPEMORE, @SHIPSCOPELESS, @MINIMUMSTOCKCNT, @MAXIMUMSTOCKCNT, @SALESORDERUNIT, @ORDERPPROCUPDFLG)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)orderPointStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (myReader.IsClosed == false) myReader.Close();

                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraPatterNo = sqlCommand.Parameters.Add("@PATTERNO", SqlDbType.Int);
                        SqlParameter paraPatternNoDerivedNo = sqlCommand.Parameters.Add("@PATTERNNODERIVEDNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraStckShipMonthSt = sqlCommand.Parameters.Add("@STCKSHIPMONTHST", SqlDbType.Int);
                        SqlParameter paraStckShipMonthEd = sqlCommand.Parameters.Add("@STCKSHIPMONTHED", SqlDbType.Int);
                        SqlParameter paraOrderApplyDiv = sqlCommand.Parameters.Add("@ORDERAPPLYDIV", SqlDbType.Int);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraShipScopeMore = sqlCommand.Parameters.Add("@SHIPSCOPEMORE", SqlDbType.Float);
                        SqlParameter paraShipScopeLess = sqlCommand.Parameters.Add("@SHIPSCOPELESS", SqlDbType.Float);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraOrderPProcUpdFlg = sqlCommand.Parameters.Add("@ORDERPPROCUPDFLG", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orderPointStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orderPointStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(orderPointStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.LogicalDeleteCode);
                        paraPatterNo.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.PatterNo);
                        paraPatternNoDerivedNo.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.PatternNoDerivedNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.WarehouseCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.SupplierCd);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.GoodsMakerCd);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.BLGoodsCode);
                        paraStckShipMonthSt.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.StckShipMonthSt);
                        paraStckShipMonthEd.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.StckShipMonthEd);
                        paraOrderApplyDiv.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.OrderApplyDiv);
                        paraStockCreateDate.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.StockCreateDate);
                        paraShipScopeMore.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.ShipScopeMore);
                        paraShipScopeLess.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.ShipScopeLess);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.MaximumStockCnt);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.SalesOrderUnit);
                        paraOrderPProcUpdFlg.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.OrderPProcUpdFlg);

                        sqlCommand.ExecuteNonQuery();

                        ayList.Add(orderPointStWork);
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OrderPointStDB.Write" + status);
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

            orderPointStWorkList = ayList;

            return status;
        }
        # endregion

        #region [LogicalDelete]
        /// <summary>
        /// 発注点設定マスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">OrderPointWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int LogicalDelete(ref object objOrderPointStList)
        {
            return LogicalDelete(ref objOrderPointStList, 1);
        }

        /// <summary>
        /// 論理削除発注点設定マスタ情報情報を復活します
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除発注点設定マスタ情報情報を復活します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object objOrderPointStList)
        {
            return LogicalDelete(ref objOrderPointStList, 0);
        }

        /// <summary>
        /// 発注点設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">OrderPointStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int LogicalDelete(ref object objOrderPointStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList orderPointStWorkList = objOrderPointStList as ArrayList;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = LogicalDeleteProc(ref orderPointStWorkList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 1)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "EmpSalesTargetDB.LogicalDeleteEmpSalesTarget :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 発注点設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStWorkList">orderPointStWorkオブジェクト</param>
        /// <param name="deleteMode">関数区分 1:論理削除 0:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int LogicalDeleteProc(ref ArrayList orderPointStWorkList, int deleteMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < orderPointStWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    OrderPointStWork orderPointStWork = orderPointStWorkList[i] as OrderPointStWork;

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM ORDERPOINTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO  AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);
                    SqlParameter findPatternNoDerivedNo = sqlCommand.Parameters.Add("@FINDPATTERNNODERIVEDNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                    findParaPatterNo.Value = orderPointStWork.PatterNo;
                    findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != orderPointStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        //現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE ORDERPOINTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                        findParaPatterNo.Value = orderPointStWork.PatterNo;
                        findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)orderPointStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();

                    //論理削除モードの場合
                    if (deleteMode == 1)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            sqlCommand.Cancel();
                            return status;
                        }
                        else if (logicalDelCd == 0) orderPointStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else orderPointStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1) orderPointStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                            sqlCommand.Cancel();
                            return status;
                        }
                    }

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orderPointStWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OrderPointStDB.Write" + status);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        #region [Delete]
        /// <summary>
        /// 発注点設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="objOrderPointStList">OrderPointStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Delete(ref object objOrderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                ArrayList orderPointStWorkList = objOrderPointStList as ArrayList;

                status = DeleteProc(orderPointStWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 発注点設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="orderPointStWorkList">発注点設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int DeleteProc(ArrayList orderPointStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {
                for (int i = 0; i < orderPointStWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    OrderPointStWork orderPointStWork = orderPointStWorkList[i] as OrderPointStWork;

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM ORDERPOINTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO  AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);
                    SqlParameter findPatternNoDerivedNo = sqlCommand.Parameters.Add("@FINDPATTERNNODERIVEDNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                    findParaPatterNo.Value = orderPointStWork.PatterNo;
                    findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != orderPointStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // データは全て削除
                        # region [DELETE文]
                        sqlText = string.Empty;
                        sqlText += "DELETE FROM ORDERPOINTSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                        findParaPatterNo.Value = orderPointStWork.PatterNo;
                        findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SecMngSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private OrderPointStWork CopyToOrderPointStWorkFromReader(ref SqlDataReader myReader)
        {
            OrderPointStWork orderPointStWork = new OrderPointStWork();

            if (myReader != null && orderPointStWork != null)
            {
                # region クラスへ格納
                orderPointStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                orderPointStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                orderPointStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                orderPointStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                orderPointStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                orderPointStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                orderPointStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                orderPointStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                orderPointStWork.PatterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNORF"));
                orderPointStWork.PatternNoDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNNODERIVEDNORF"));
                orderPointStWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                orderPointStWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                orderPointStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                orderPointStWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                orderPointStWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                orderPointStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                orderPointStWork.StckShipMonthSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHSTRF"));
                orderPointStWork.StckShipMonthEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHEDRF"));
                orderPointStWork.OrderApplyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERAPPLYDIVRF"));
                orderPointStWork.StockCreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                orderPointStWork.ShipScopeMore = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPEMORERF"));
                orderPointStWork.ShipScopeLess = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPELESSRF"));
                orderPointStWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                orderPointStWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                orderPointStWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                orderPointStWork.OrderPProcUpdFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERPPROCUPDFLGRF"));
                # endregion
            }
            return orderPointStWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
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
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}

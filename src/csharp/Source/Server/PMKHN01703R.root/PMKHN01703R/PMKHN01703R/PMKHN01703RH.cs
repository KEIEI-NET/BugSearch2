//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業商品セットマスタ変換処理
// プログラム概要   : ＣＳＶファイルより、画面抽出条件を満たしたデータをテキストファイルへ出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00   作成担当 : 陳永康
// 作 成 日  2015/01/26  　修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/02/26  修正内容 : Redmine#44209 メッセージの文言対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/07  修正内容 : Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/04/13  修正内容 : Redmine#45436 表示順位重複の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業商品セットマスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品セットマスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsSetChgDB : RemoteDB
    {

        private GoodsSetDB _goodsSetDB;
        private GoodsNoChgCommonDB _goodsNoChgCommonDB;

        #region GoodsSetChgDB
        /// <summary>
        /// 商品セットマスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsSetChgDB()
        {
            // 商品セットマスタ
            if (this._goodsSetDB == null)
            {
                this._goodsSetDB = new GoodsSetDB();
            }

            if (this._goodsNoChgCommonDB == null)
            {
                this._goodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region ReadIn
        /// <summary>
        /// 指定された企業コードの商品セットマスタに変換成功の全て戻る処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの商品セットマスタに変換成功LISTを全て戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int ReadIn(out object goodsSuccessResultWork, out object errorResultWork, out int count, int mode, string enterpriseCode)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;


            #region 商品セットマスタ
            // 商品セットマスタログ
            goodsSuccessResultWork = null;
            errorResultWork = null;
            count = 0;
            ArrayList goodsSuccessResultWorkList = new ArrayList();
            ArrayList errorList = new ArrayList();


            #endregion
            try
            {
                // コネクション生成
                sqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = _goodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 商品セットマスタ変換処理
                status = ReadInProc(out goodsSuccessResultWorkList, out errorList, out count, mode, enterpriseCode, ref sqlConnection, ref sqlTransaction);

                goodsSuccessResultWork = goodsSuccessResultWorkList;
                errorResultWork = errorList;

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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.ReadIn");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        /// <summary>
        /// 指定された企業コードの商品セットマスタに変換成功を全て戻る処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int ReadInProc(out ArrayList goodsSuccessResultWorkList, out ArrayList errorList, out int count, int mode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            count = 0;

            // 商品セットマスタ
            goodsSuccessResultWorkList = new ArrayList();
            errorList = new ArrayList();
            try
            {
                // 商品セットマスタの更新
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = goodSetReadInProc(out goodsSuccessResultWorkList, out errorList, out count, mode, enterpriseCode, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    goodsSuccessResultWorkList.Clear();
                    errorList.Clear();
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.ReadInProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }



        /// <summary>
        /// 商品セットマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="goodsSetArray"></param>
        /// <param name="goodsSetChgCtnList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="mode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="strMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int SearchgoodsSet(ref ArrayList goodsSetArray, out ArrayList goodsSetChgCtnList, string enterpriseCode, int mode, ref SqlConnection sqlConnection, out string strMsg)
        {
            return this.SearchProc(ref goodsSetArray, out goodsSetChgCtnList, enterpriseCode, mode, ref sqlConnection, out strMsg);
        }

        /// <summary>
        /// 商品セットマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="goodsSetArray"></param>
        /// <param name="goodsSetChgCtnList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="mode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="strMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        private int SearchProc(ref ArrayList goodsSetArray, out ArrayList goodsSetChgCtnList, string enterpriseCode, int mode, ref SqlConnection sqlConnection, out string strMsg)
        {
            Dictionary<string, string> _goodsSetChgWorkDic = new Dictionary<string, string>();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsSetChgCtnList = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            strMsg = "";
            try
            {
                string sqlText = "SELECT A.CREATEDATETIMERF , A.UPDATEDATETIMERF, A.ENTERPRISECODERF , A.FILEHEADERGUIDRF , A.UPDEMPLOYEECODERF , A.UPDASSEMBLYID1RF , A.UPDASSEMBLYID2RF , A.LOGICALDELETECODERF ,A.PARENTGOODSMAKERCDRF , A.PARENTGOODSNORF , A.SUBGOODSMAKERCDRF , A.SUBGOODSNORF , A.CNTFLRF , A.DISPLAYORDERRF, A.SETSPECIALNOTERF , A.CATALOGSHAPENORF," + Environment.NewLine;
                sqlText += "B.GOODSMAKERCDRF, B.CHGSRCGOODSNORF, B.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlText += "FROM GOODSSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;

                if (mode == 0)
                {
                    sqlText += "INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON (A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) OR (A.SUBGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.SUBGOODSNORF = B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) " + Environment.NewLine;
                }
                if (mode == 1)
                {
                    sqlText += "INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "ON (A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) OR (A.SUBGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.SUBGOODSNORF = B.CHGSRCGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF) " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, mode, enterpriseCode);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GoodsSetChgWork goodsSetChgWork = this.CopyToGoodsSetWorkFromReader(ref myReader);
                    string key = goodsSetChgWork.ParentGoodsMakerCd.ToString() + goodsSetChgWork.ParentGoodsNo + goodsSetChgWork.SubGoodsMakerCd.ToString() + goodsSetChgWork.SubGoodsNo;
                    //条件
                    GoodsSetChgWork goodsSetChgCtn = new GoodsSetChgWork();
                    goodsSetChgCtn.OldPrmSetDtlName = goodsSetChgWork.OldPrmSetDtlName;
                    goodsSetChgCtn.NewPrmSetDtlName = goodsSetChgWork.NewPrmSetDtlName;
                    goodsSetChgCtn.GoodsMakerCd = goodsSetChgWork.GoodsMakerCd;
                    goodsSetChgCtnList.Add(goodsSetChgCtn);

                    if (!_goodsSetChgWorkDic.ContainsKey(key))
                    {
                        _goodsSetChgWorkDic.Add(key, string.Empty);
                        goodsSetArray.Add(goodsSetChgWork);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (goodsSetArray.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                strMsg = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                strMsg = ex.Message;
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

        #region 表示順位を検索する
        /// <summary>
        /// 商品セットマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="mode">モード</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrder(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション
            SqlConnection sqlConnection = null;

            Dictionary<string,int> displayOrder = new Dictionary<string,int>();
            try
            {
                // コネクション生成
                sqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);
                // 商品セットマスタ検索処理
                status = SearchDisplayOrderProc(out displayOrder, enterpriseCode, mode, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.SearchDisplayOrder");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            displayOrderDic = displayOrder;

            return status;
        }

        /// <summary>
        /// 商品セットマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="mode">モード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrderProc(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            displayOrderDic = new Dictionary<string, int>();
            try
            {
                string sqlText = "SELECT A.PARENTGOODSMAKERCDRF , A.PARENTGOODSNORF , MAX(A.DISPLAYORDERRF) AS DISPLAYORDERRF " + Environment.NewLine;
                sqlText += "FROM GOODSSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;

                if (mode == 0)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }
                if (mode == 1)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.PARENTGOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.PARENTGOODSNORF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereStringDisplayOrder(ref sqlCommand, mode, enterpriseCode);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GoodsSetChgWork goodsSetWork = new GoodsSetChgWork();
                    if (myReader != null && goodsSetWork != null)
                    {
                        # region クラスへ格納
                        goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                        goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                        goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                        # endregion
                    }
                    string key = goodsSetWork.ParentGoodsMakerCd.ToString().Trim().PadLeft(4, '0') + ":" + goodsSetWork.ParentGoodsNo.Trim();
                    if (!displayOrderDic.ContainsKey(key))
                    {
                        displayOrderDic.Add(key, goodsSetWork.DisplayOrder);
                    }
                    else
                    {
                        continue;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.SearchDisplayOrderProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="mode">モード</param>
        /// <param name="enterpriseCode">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/04/13</br>
        private string MakeWhereStringDisplayOrder(ref SqlCommand sqlCommand, int mode, string enterpriseCode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //企業コード
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            retstring.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //マスタ区分
            if (mode == 1)
            {
                retstring.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(6);
            }

            //GROUP BY
            retstring.Append(" GROUP BY A.PARENTGOODSMAKERCDRF, A.PARENTGOODSNORF ");

            return retstring.ToString();
        }
        #endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsSetChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>goodsSetChgWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsSetChgWork CopyToGoodsSetWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsSetChgWork goodsSetWork = new GoodsSetChgWork();

            this.CopyToGoodsSetWorkFromReader(ref myReader, ref goodsSetWork);

            return goodsSetWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → GoodsSetChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>goodsSetChgWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsSetChgWork NewNoCopyToGoodsSetWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsSetChgWork goodsSetWork = new GoodsSetChgWork();

            this.NewNoCopyToGoodsSetWorkFromReader(ref myReader, ref goodsSetWork);

            return goodsSetWork;
        }
        #endregion

        #region
        /// <summary>
        /// クラス格納処理 Reader → GoodsSetChgWork
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="goodsSetWork"></param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void CopyToGoodsSetWorkFromReader(ref SqlDataReader myReader, ref GoodsSetChgWork goodsSetWork)
        {
            if (myReader != null && goodsSetWork != null)
            {
                # region クラスへ格納
                goodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                goodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                goodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                goodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                goodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                goodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                goodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                goodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                goodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                goodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                goodsSetWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                goodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                goodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
                goodsSetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                goodsSetWork.OldPrmSetDtlName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                goodsSetWork.NewPrmSetDtlName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));

                # endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → GoodsSetChgWork
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="goodsSetWork"></param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void NewNoCopyToGoodsSetWorkFromReader(ref SqlDataReader myReader, ref GoodsSetChgWork goodsSetWork)
        {
            if (myReader != null && goodsSetWork != null)
            {
                # region クラスへ格納
                goodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                goodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                goodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                goodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                goodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                goodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                goodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                goodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                goodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                goodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                goodsSetWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                goodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                goodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
                # endregion
            }
        }
        # endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="mode">モード</param>
        /// <param name="enterpriseCode">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, int mode, string enterpriseCode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //企業コード
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            retstring.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //マスタ区分
            if (mode == 1)
            {
                retstring.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(6);
            }

            //ORDER BY
            retstring.Append(" ORDER BY A.ENTERPRISECODERF, A.PARENTGOODSMAKERCDRF, A.PARENTGOODSNORF, A.SUBGOODSMAKERCDRF, A.SUBGOODSNORF");

            return retstring.ToString();
        }
        #endregion

        /// <summary>
        /// 指定された企業コードの商品セットマスタの取込処理
        /// </summary>
        /// <param name="goodSetSuccessResultWork"></param>
        /// <param name="errorResultWork"></param>
        /// <param name="count"></param>
        /// <param name="mode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/17</br>
        /// <br>Note        : Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/29</br>
        /// </remarks>
        private int goodSetReadInProc(out ArrayList goodSetSuccessResultWork, out ArrayList errorResultWork, out int count, int mode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // 戻される結果リスト
            goodSetSuccessResultWork = new ArrayList();
            // エラーメッセージ
            string message = string.Empty;
            string strMsg;
            count = 0;
            errorResultWork = new ArrayList();
            Dictionary<string, string> _goodsSetSuccessDic = new Dictionary<string, string>();
            Dictionary<string, string> _ctnDic = new Dictionary<string, string>();
            Dictionary<string, string> _logicalDeleteDic = new Dictionary<string, string>();
            Dictionary<string, GoodsSetChgWork> _DelErrorOrSusDic = new Dictionary<string, GoodsSetChgWork>();
            Dictionary<string, string> _insertDic = new Dictionary<string, string>();
            Dictionary<string, int> _displayOrderDic = new Dictionary<string, int>(); // ADD 陳永康 2015/04/13 表示順位重複の対応
            // 親リスト
            ArrayList parentgoodSetSuccessList = new ArrayList();
            // 検索した戻されろリスト
            ArrayList selectWorkList = new ArrayList();
            // 削除リスト
            ArrayList deleteWorkList = new ArrayList();
            ArrayList FinalDeleteWorkList = new ArrayList();
            // 追加リスト
            ArrayList insertWorkList = new ArrayList();
            // 論理削除リスト
            ArrayList logicalDeleteList = new ArrayList();
            // 条件リスト
            ArrayList CtnList = new ArrayList();
            // Errorリスト
            ArrayList ErrorList = new ArrayList();

            ArrayList NewNoExistList = new ArrayList();
            ArrayList ExistList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection SearchSubNoSqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);
            SqlConnection SearchNewNoSqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);

            try
            {
                // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------>>>>>
                // 表示順位を検索する
                status = this.SearchDisplayOrder(out _displayOrderDic, enterpriseCode, mode);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------<<<<<
                // 商品セットマスタで検索する
                status = this.SearchgoodsSet(ref deleteWorkList, out CtnList, enterpriseCode, mode, ref SearchSubNoSqlConnection, out strMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && deleteWorkList.Count > 0)
                {
                    count = deleteWorkList.Count;

                    status = _goodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterpriseCode, GoodsNoChgCommonDB.SETMST, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (GoodsSetChgWork ctnWork in CtnList)
                        {
                            string ctnKey = ctnWork.OldPrmSetDtlName + ctnWork.GoodsMakerCd.ToString();
                            if (!_ctnDic.ContainsKey(ctnKey))
                            {
                                _ctnDic.Add(ctnKey, ctnWork.NewPrmSetDtlName);
                            }
                        }
                        foreach (GoodsSetChgWork goodsSetChgWork in deleteWorkList)
                        {
                            string errorkey = goodsSetChgWork.ParentGoodsMakerCd.ToString() + goodsSetChgWork.ParentGoodsNo + goodsSetChgWork.SubGoodsMakerCd.ToString() + goodsSetChgWork.SubGoodsNo;
                            //対象保留
                            if (!_DelErrorOrSusDic.ContainsKey(errorkey))
                            {
                                _DelErrorOrSusDic.Add(errorkey, goodsSetChgWork);
                            }
                            //GoodsSetChgWork --> GoodsSetWork
                            GoodsSetWork goodsSetWork = GoodsSetChgWorkToGoodsSetWork(goodsSetChgWork);
                            FinalDeleteWorkList.Add(goodsSetWork);
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    return status;
                }

                // 新旧品番を変換する
                if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                {
                    for (int i = 0; i < FinalDeleteWorkList.Count; i++)
                    {
                        sqlTransaction.Save("GoodsSetSavePoint");
                        //GoodsSetWork copyGoodsSetWork = CloneSetWork((GoodsSetWork)FinalDeleteWorkList[i]);// DEL 2015/04/29 時シン リストのNULL、とcountは判断する対応
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        GoodsSetWork copyGoodsSetWork = null;
                        if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                        {
                            copyGoodsSetWork = CloneSetWork((GoodsSetWork)FinalDeleteWorkList[i]);
                        }
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<

                        bool parflag = false;
                        bool subflag = false;
                        GoodsNoChangeErrorDataWork errorWork1 = new GoodsNoChangeErrorDataWork();
                        GoodsNoChangeErrorDataWork errorWork2 = new GoodsNoChangeErrorDataWork();
                        // ログファイルデータの作成
                        GoodsSetChgWork SuccessGoodsSetChgWork = new GoodsSetChgWork();
                        SuccessGoodsSetChgWork.ParentGoodsMakerCd = copyGoodsSetWork.ParentGoodsMakerCd;
                        SuccessGoodsSetChgWork.ParentGoodsNo = copyGoodsSetWork.ParentGoodsNo;
                        SuccessGoodsSetChgWork.SubGoodsMakerCd = copyGoodsSetWork.SubGoodsMakerCd;
                        SuccessGoodsSetChgWork.SubGoodsNo = copyGoodsSetWork.SubGoodsNo;
                        SuccessGoodsSetChgWork.AfChgParentGoodsNo = copyGoodsSetWork.ParentGoodsNo;
                        SuccessGoodsSetChgWork.AfChgSubGoodsNo = copyGoodsSetWork.SubGoodsNo;

                        foreach (GoodsSetChgWork goodsSetCtn in CtnList)
                        {
                            if (goodsSetCtn.OldPrmSetDtlName.Equals(copyGoodsSetWork.ParentGoodsNo) && goodsSetCtn.GoodsMakerCd == copyGoodsSetWork.ParentGoodsMakerCd)
                            {
                                errorWork1.GoodsMakerCd = copyGoodsSetWork.ParentGoodsMakerCd;
                                errorWork1.ChgSrcGoodsNo = copyGoodsSetWork.ParentGoodsNo;
                                errorWork1.ChgDestGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                errorWork1.MasterDivCd = GoodsNoChgCommonDB.SETMST;
                                parflag = true;
                                copyGoodsSetWork.ParentGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                SuccessGoodsSetChgWork.AfChgParentGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                            }
                            if (goodsSetCtn.OldPrmSetDtlName.Equals(copyGoodsSetWork.SubGoodsNo) && goodsSetCtn.GoodsMakerCd == copyGoodsSetWork.SubGoodsMakerCd)
                            {
                                errorWork2.GoodsMakerCd = copyGoodsSetWork.SubGoodsMakerCd;
                                errorWork2.ChgSrcGoodsNo = copyGoodsSetWork.SubGoodsNo;
                                errorWork2.ChgDestGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                errorWork2.MasterDivCd = GoodsNoChgCommonDB.SETMST;
                                subflag = true;
                                copyGoodsSetWork.SubGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                                SuccessGoodsSetChgWork.AfChgSubGoodsNo = goodsSetCtn.NewPrmSetDtlName;
                            }
                        }
                        //GoodsSetWork goodsSetWork = (GoodsSetWork)FinalDeleteWorkList[i];// DEL 2015/04/29 時シン リストのNULL、とcountは判断する対応
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        GoodsSetWork goodsSetWork = null;
                        if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                        {
                            goodsSetWork = (GoodsSetWork)FinalDeleteWorkList[i];
                        }
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                        string errKey = goodsSetWork.ParentGoodsMakerCd.ToString() + goodsSetWork.ParentGoodsNo + goodsSetWork.SubGoodsMakerCd.ToString() + goodsSetWork.SubGoodsNo;

                        ArrayList finalDelList = new ArrayList();
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        if (FinalDeleteWorkList != null && FinalDeleteWorkList.Count > 0)
                        {
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                            finalDelList.Add(FinalDeleteWorkList[i]);
                        }// ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応

                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                        try
                        {
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                            status = this._goodsSetDB.DeleteGoodsSetProc(finalDelList, ref sqlConnection, ref sqlTransaction);
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "DeleteGoodsSetProc");
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                        finalDelList.Clear();
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------>>>>>
                            if (!string.IsNullOrEmpty(copyGoodsSetWork.ParentGoodsNo.Trim())
                                && copyGoodsSetWork.ParentGoodsNo.Trim().Equals(copyGoodsSetWork.SubGoodsNo.Trim())
                                && copyGoodsSetWork.ParentGoodsMakerCd == copyGoodsSetWork.SubGoodsMakerCd)
                            {
                                SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.REPEATSETMSG;
                                errorResultWork.Add(SuccessGoodsSetChgWork);
                                if (parflag)
                                {
                                    ErrorList.Add(errorWork1);
                                }
                                if (subflag)
                                {
                                    ErrorList.Add(errorWork2);
                                }

                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------<<<<<
                                selectWorkList.Add(copyGoodsSetWork);
                                //旧品番ーーー＞新品番
                                foreach (GoodsSetWork goodsSetChgWork in selectWorkList)
                                {
                                    if (goodsSetChgWork.LogicalDeleteCode == 1)
                                    {
                                        //SuccessGoodsSetChgWork.AfContentExplain = "論理削除データ"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    }
                                    goodsSetChgWork.UpdateDateTime = DateTime.MinValue;
                                    // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------>>>>>
                                    string displayOrderKey = goodsSetChgWork.ParentGoodsMakerCd.ToString().Trim().PadLeft(4, '0') + ":" + goodsSetChgWork.ParentGoodsNo.Trim();
                                    if (_displayOrderDic.ContainsKey(displayOrderKey))
                                    {
                                        goodsSetChgWork.DisplayOrder = _displayOrderDic[displayOrderKey] + 1;
                                    }
                                    //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------>>>>>
                                    if (goodsSetChgWork.DisplayOrder > 50)
                                    {
                                        SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.DISPORDEROVERNUMBER;
                                        errorResultWork.Add(SuccessGoodsSetChgWork);
                                        if (parflag)
                                        {
                                            ErrorList.Add(errorWork1);
                                        }
                                        if (subflag)
                                        {
                                            ErrorList.Add(errorWork2);
                                        }

                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    else
                                    {
                                    //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------<<<<<
                                        // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------<<<<<
                                        insertWorkList.Add(goodsSetChgWork);
                                    } // ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応
                                }
                                selectWorkList.Clear();

                                //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------<<<<<
                                    //論理削除dic作成
                                    foreach (GoodsSetWork goodsSetChgWork in insertWorkList)
                                    {
                                        if (goodsSetChgWork.LogicalDeleteCode == 1)
                                        {
                                            string LogicalDeleteKey = goodsSetChgWork.ParentGoodsMakerCd.ToString() + goodsSetChgWork.ParentGoodsNo + goodsSetChgWork.SubGoodsMakerCd.ToString() + goodsSetChgWork.SubGoodsNo;
                                            if (!_logicalDeleteDic.ContainsKey(LogicalDeleteKey))
                                            {
                                                _logicalDeleteDic.Add(LogicalDeleteKey, string.Empty);
                                            }
                                        }

                                    }
                                    //追加処理
                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                    try
                                    {
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                        status = this._goodsSetDB.WriteGoodsSetProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                    }
                                    catch (Exception ex)
                                    {
                                        base.WriteErrorLog(ex, "WriteGoodsSetProc");
                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------>>>>>
                                        foreach (GoodsSetWork goodsSetWork3 in insertWorkList)
                                        {
                                            string displayOrderKey = goodsSetWork3.ParentGoodsMakerCd.ToString().Trim().PadLeft(4, '0') + ":" + goodsSetWork3.ParentGoodsNo.Trim();
                                            if (_displayOrderDic.ContainsKey(displayOrderKey))
                                            {
                                                _displayOrderDic[displayOrderKey] = _displayOrderDic[displayOrderKey] + 1;
                                            }
                                        }
                                        // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------<<<<<
                                        foreach (GoodsSetWork goodsSetWork2 in insertWorkList)
                                        {
                                            string logicalDeleteKey = goodsSetWork2.ParentGoodsMakerCd.ToString() + goodsSetWork2.ParentGoodsNo + goodsSetWork2.SubGoodsMakerCd.ToString() + goodsSetWork2.SubGoodsNo;
                                            if (_logicalDeleteDic.ContainsKey(logicalDeleteKey))
                                            {
                                                logicalDeleteList.Add(goodsSetWork2);
                                            }
                                        }
                                        insertWorkList.Clear();
                                        if (logicalDeleteList != null && logicalDeleteList.Count > 0)
                                        {
                                            //論理削除状態保つ
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                            try
                                            {
                                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                                status = this._goodsSetDB.LogicalDeleteGoodsSetProc(ref logicalDeleteList, 0, ref sqlConnection, ref sqlTransaction);
                                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                            }
                                            catch (Exception ex)
                                            {
                                                base.WriteErrorLog(ex, "LogicalDeleteGoodsSetProc");
                                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                            }
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                            logicalDeleteList.Clear();
                                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                parentgoodSetSuccessList.Add(SuccessGoodsSetChgWork);
                                                logicalDeleteList.Clear();
                                            }
                                            else
                                            {
                                                //SuccessGoodsSetChgWork.AfContentExplain = "登録エラー、変換先品番の登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                errorResultWork.Add(SuccessGoodsSetChgWork);
                                                if (parflag)
                                                {
                                                    ErrorList.Add(errorWork1);
                                                }
                                                if (subflag)
                                                {
                                                    ErrorList.Add(errorWork2);
                                                }
                                                logicalDeleteList.Clear();
                                            }
                                        }
                                        else
                                        {
                                            parentgoodSetSuccessList.Add(SuccessGoodsSetChgWork);
                                            logicalDeleteList.Clear();
                                        }
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                    {
                                        insertWorkList.Clear();
                                        //SuccessGoodsSetChgWork.AfContentExplain = "変換先品番が既に登録されました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        SuccessGoodsSetChgWork.AfContentExplain = string.Format(GoodsNoChgCommonDB.EXISTMSG, "セットマスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        errorResultWork.Add(SuccessGoodsSetChgWork);
                                        if (parflag)
                                        {
                                            ErrorList.Add(errorWork1);
                                        }
                                        if (subflag)
                                        {
                                            ErrorList.Add(errorWork2);
                                        }
                                    }
                                    else
                                    {
                                        insertWorkList.Clear();
                                        //SuccessGoodsSetChgWork.AfContentExplain = "登録エラー、変換先品番の登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        errorResultWork.Add(SuccessGoodsSetChgWork);
                                        if (parflag)
                                        {
                                            ErrorList.Add(errorWork1);
                                        }
                                        if (subflag)
                                        {
                                            ErrorList.Add(errorWork2);
                                        }
                                    }
                                }// ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応
                            }// ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応

                        }
                        //errorList作成
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            GoodsSetChgWork errorGoodsSetChgWork = _DelErrorOrSusDic[errKey];

                            //errorGoodsSetChgWork.AfContentExplain = "排他エラー、変換元品番の削除に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            errorGoodsSetChgWork.AfContentExplain = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "セットマスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            string parentkey = errorGoodsSetChgWork.ParentGoodsNo + errorGoodsSetChgWork.ParentGoodsMakerCd.ToString();
                            string subkey = errorGoodsSetChgWork.SubGoodsNo + errorGoodsSetChgWork.SubGoodsMakerCd.ToString();
                            if (_ctnDic.ContainsKey(parentkey))
                            {
                                errorGoodsSetChgWork.AfChgParentGoodsNo = _ctnDic[parentkey];
                                errorGoodsSetChgWork.AfChgSubGoodsNo = errorGoodsSetChgWork.SubGoodsNo;
                                GoodsNoChangeErrorDataWork errorWork3 = GoodsSetChgWorkToErrorWork(errorGoodsSetChgWork, errorGoodsSetChgWork.ParentGoodsMakerCd, errorGoodsSetChgWork.ParentGoodsNo);
                                ErrorList.Add(errorWork3);
                            }
                            if (_ctnDic.ContainsKey(subkey))
                            {
                                errorGoodsSetChgWork.AfChgSubGoodsNo = _ctnDic[subkey];
                                errorGoodsSetChgWork.AfChgParentGoodsNo = errorGoodsSetChgWork.ParentGoodsNo;
                                GoodsNoChangeErrorDataWork errorWork4 = GoodsSetChgWorkToErrorWork(errorGoodsSetChgWork, errorGoodsSetChgWork.SubGoodsMakerCd, errorGoodsSetChgWork.SubGoodsNo);
                                ErrorList.Add(errorWork4);
                            }
                            errorResultWork.Add(errorGoodsSetChgWork);
                            continue;

                        }
                        else
                        {
                            //SuccessGoodsSetChgWork.AfContentExplain = "削除エラー、変換元品番の削除に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            SuccessGoodsSetChgWork.AfContentExplain = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            errorResultWork.Add(SuccessGoodsSetChgWork);
                            if (parflag)
                            {
                                ErrorList.Add(errorWork1);
                            }
                            if (subflag)
                            {
                                ErrorList.Add(errorWork2);
                            }
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback("GoodsSetSavePoint");
                        }
                    }
                }

                goodSetSuccessResultWork = parentgoodSetSuccessList;

                if (ErrorList != null && ErrorList.Count > 0)
                {
                    Dictionary<string, GoodsNoChangeErrorDataWork> repeatDate = new Dictionary<string, GoodsNoChangeErrorDataWork>();
                    string repeatDateKey = "";
                    for (int i = 0; i < ErrorList.Count; i++)
                    {
                        //GoodsNoChangeErrorDataWork errorDataWork = ErrorList[i] as GoodsNoChangeErrorDataWork;// DEL 2015/04/29 時シン リストのNULL、とcountは判断する対応
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        GoodsNoChangeErrorDataWork errorDataWork = null;
                        if (ErrorList != null && ErrorList.Count > 0)
                        {
                            errorDataWork = ErrorList[i] as GoodsNoChangeErrorDataWork;
                        }
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                        repeatDateKey = errorDataWork.GoodsMakerCd.ToString() + "-" + errorDataWork.ChgSrcGoodsNo.Trim();

                        if (!repeatDate.ContainsKey(repeatDateKey))
                        {
                            repeatDate.Add(repeatDateKey, errorDataWork);
                        }
                    }
                    // 品番変換エラーデータを登録
                    status = _goodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(repeatDate, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ErrorList.Clear();
                    }
                    else
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                return status;
            }

            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetChgDB.goodSetReadInProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (SearchNewNoSqlConnection != null)
                {
                    SearchNewNoSqlConnection.Close();
                    SearchNewNoSqlConnection.Dispose();
                }
                if (SearchSubNoSqlConnection != null)
                {
                    SearchSubNoSqlConnection.Close();
                    SearchSubNoSqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// ワークのClone
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private GoodsSetWork CloneSetWork(GoodsSetWork work)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();

            goodsSetWork.CreateDateTime = work.CreateDateTime;
            goodsSetWork.UpdateDateTime = work.UpdateDateTime;
            goodsSetWork.EnterpriseCode = work.EnterpriseCode;
            goodsSetWork.FileHeaderGuid = work.FileHeaderGuid;
            goodsSetWork.UpdEmployeeCode = work.UpdEmployeeCode;
            goodsSetWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            goodsSetWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            goodsSetWork.LogicalDeleteCode = work.LogicalDeleteCode;
            goodsSetWork.ParentGoodsMakerCd = work.ParentGoodsMakerCd;
            goodsSetWork.ParentGoodsNo = work.ParentGoodsNo;
            goodsSetWork.SubGoodsMakerCd = work.SubGoodsMakerCd;
            goodsSetWork.SubGoodsNo = work.SubGoodsNo;
            goodsSetWork.CntFl = work.CntFl;
            goodsSetWork.DisplayOrder = work.DisplayOrder;
            goodsSetWork.SetSpecialNote = work.SetSpecialNote;
            goodsSetWork.CatalogShapeNo = work.CatalogShapeNo;

            return goodsSetWork;
        }

        /// <summary>
        /// クラス格納処理 GoodsSetChgWork → GoodsSetWork
        /// </summary>
        /// <param name="goodsSetChgWork">GoodsSetChgWork オブジェクト</param>
        /// <returns>GoodsSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsSetWork GoodsSetChgWorkToGoodsSetWork(GoodsSetChgWork goodsSetChgWork)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            goodsSetWork.CreateDateTime = goodsSetChgWork.CreateDateTime;
            goodsSetWork.UpdateDateTime = goodsSetChgWork.UpdateDateTime;
            goodsSetWork.EnterpriseCode = goodsSetChgWork.EnterpriseCode;
            goodsSetWork.FileHeaderGuid = goodsSetChgWork.FileHeaderGuid;
            goodsSetWork.UpdEmployeeCode = goodsSetChgWork.UpdEmployeeCode;
            goodsSetWork.UpdAssemblyId1 = goodsSetChgWork.UpdAssemblyId1;
            goodsSetWork.UpdAssemblyId2 = goodsSetChgWork.UpdAssemblyId2;
            goodsSetWork.LogicalDeleteCode = goodsSetChgWork.LogicalDeleteCode;
            goodsSetWork.ParentGoodsMakerCd = goodsSetChgWork.ParentGoodsMakerCd;
            goodsSetWork.ParentGoodsNo = goodsSetChgWork.ParentGoodsNo;
            goodsSetWork.SubGoodsMakerCd = goodsSetChgWork.SubGoodsMakerCd;
            goodsSetWork.SubGoodsNo = goodsSetChgWork.SubGoodsNo;
            goodsSetWork.CntFl = goodsSetChgWork.CntFl;
            goodsSetWork.DisplayOrder = goodsSetChgWork.DisplayOrder;
            goodsSetWork.SetSpecialNote = goodsSetChgWork.SetSpecialNote;
            goodsSetWork.CatalogShapeNo = goodsSetChgWork.CatalogShapeNo;
            return goodsSetWork;
        }

        /// <summary>
        /// クラス格納処理 GoodsSetChgWork → GoodsSetWork
        /// </summary>
        /// <param name="goodsSetChgWork">GoodsSetChgWork オブジェクト</param>
        /// <param name="makercd"></param>
        /// <param name="goodNo"></param>
        /// <returns>GoodsSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private GoodsNoChangeErrorDataWork GoodsSetChgWorkToErrorWork(GoodsSetChgWork goodsSetChgWork, int makercd, string goodNo)
        {
            GoodsNoChangeErrorDataWork errorDataWork = new GoodsNoChangeErrorDataWork();
            errorDataWork.CreateDateTime = goodsSetChgWork.CreateDateTime;
            errorDataWork.UpdateDateTime = DateTime.MinValue;
            errorDataWork.EnterpriseCode = goodsSetChgWork.EnterpriseCode;
            errorDataWork.FileHeaderGuid = goodsSetChgWork.FileHeaderGuid;
            errorDataWork.UpdEmployeeCode = goodsSetChgWork.UpdEmployeeCode;
            errorDataWork.UpdAssemblyId1 = goodsSetChgWork.UpdAssemblyId1;
            errorDataWork.UpdAssemblyId2 = goodsSetChgWork.UpdAssemblyId2;
            errorDataWork.LogicalDeleteCode = goodsSetChgWork.LogicalDeleteCode;
            errorDataWork.GoodsMakerCd = makercd;
            errorDataWork.ChgSrcGoodsNo = goodNo;
            errorDataWork.ChgDestGoodsNo = goodsSetChgWork.NewPrmSetDtlName;
            errorDataWork.MasterDivCd = GoodsNoChgCommonDB.SETMST;

            return errorDataWork;
        }
    }
}





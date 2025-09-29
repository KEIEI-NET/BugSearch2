//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 表示区分マスタ印刷DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタ印刷の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// </remarks>
    [Serializable]
    public class PriceSelectSetWorkDB : RemoteDB, IPriceSelectSetWorkDB
    {
        /// <summary>
        /// 表示区分マスタ印刷DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public PriceSelectSetWorkDB()
            :
        base("PMKHN08727D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetCndtnWork", "PriceSelectSetRF") //基底クラスのコンストラクタ
        {
        }

        #region IPriceSelectSetWorkDB メンバ
        /// <summary>
        /// 指定された企業コードの表示区分マスタ印刷LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="priceSelectSetResultWork">検索結果</param>
        /// <param name="priceSelectSetCndtnWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの表示区分マスタ印刷LISTを全て戻します（論理削除除く）。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public int Search(out object priceSelectSetResultWork, object priceSelectSetCndtnWork, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            priceSelectSetResultWork = null;

            try
            {
                status = SearchProc(out priceSelectSetResultWork, priceSelectSetCndtnWork, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetWorkDB.Search Exception=" + ex.Message);
                priceSelectSetResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの表示区分マスタ印刷LISTを全て戻します
        /// </summary>
        /// <param name="priceSelectSetResultWork">検索結果</param>
        /// <param name="priceSelectSetCndtnWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの商品管理マスタ（エクスポート）LISTを全て戻します。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private int SearchProc(out object priceSelectSetResultWork, object priceSelectSetCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            priceSelectSetResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchOrderProc(ref al, ref sqlConnection, priceSelectSetCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            priceSelectSetResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="paramObj">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, object paramObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                PriceSelectSetCndtnWork priceSelectSetCndtnWork = (PriceSelectSetCndtnWork)paramObj;
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";
                sqlCommand.Parameters.Clear();
                #region Select文作成

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "   PRI.CUSTOMERCODERF" + Environment.NewLine;             // 得意先
                selectTxt += "  ,CUS.NAMERF" + Environment.NewLine;                     // 得意先名
                selectTxt += "  ,PRI.CUSTRATEGRPCODERF" + Environment.NewLine;          // 得意先掛率グループ
                selectTxt += "	,PRI.GOODSMAKERCDRF" + Environment.NewLine;             // メーカー
                selectTxt += "  ,MAKER.MAKERNAMERF" + Environment.NewLine;              // メーカー名
                selectTxt += "  ,PRI.BLGOODSCODERF" + Environment.NewLine;              // BLコード
                selectTxt += "  ,BLGOOD.BLGOODSHALFNAMERF" + Environment.NewLine;       // BLコード名=
                selectTxt += "  ,PRI.PRICESELECTDIVRF" + Environment.NewLine;           // 標準価格選択区分
                selectTxt += "  ,PRI.LOGICALDELETECODERF" + Environment.NewLine;        // 論理削除区分
                selectTxt += "  ,PRI.UPDATEDATETIMERF" + Environment.NewLine;           // 更新日時
                selectTxt += "  ,PRI.PRICESELECTPTNRF" + Environment.NewLine;           // 標準価格選択設定パターン
                selectTxt += " FROM PRICESELECTSETRF AS PRI WITH(READUNCOMMITTED)" + Environment.NewLine;

                #region [LEFT JION文作成]
                // 得意先名
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUS WITH(READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "	ON  CUS.CUSTOMERCODERF = PRI.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "	AND  CUS.ENTERPRISECODERF = PRI.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND  CUS.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                // メーカー名
                selectTxt += "LEFT JOIN MAKERURF AS MAKER WITH(READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "	ON  MAKER.GOODSMAKERCDRF = PRI.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	AND  MAKER.ENTERPRISECODERF = PRI.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND  MAKER.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                // ＢＬ商品コード名
                selectTxt += "LEFT JOIN BLGOODSCDURF AS BLGOOD WITH(READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "	ON  BLGOOD.BLGOODSCODERF = PRI.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "	AND  BLGOOD.ENTERPRISECODERF = PRI.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND  BLGOOD.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                #endregion

                #endregion

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, priceSelectSetCndtnWork, logicalMode);

                //ORDER BYの作成
                #region [ORDER BY文作成]
                selectTxt += " ORDER BY " + Environment.NewLine;
                selectTxt += " PRI.PRICESELECTPTNRF, " + Environment.NewLine;
                selectTxt += " PRI.CUSTOMERCODERF, " + Environment.NewLine;
                selectTxt += " PRI.CUSTRATEGRPCODERF, " + Environment.NewLine;
                selectTxt += " PRI.GOODSMAKERCDRF, " + Environment.NewLine;
                selectTxt += " PRI.BLGOODSCODERF " + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    PriceSelectSetResultWork priceSelectSetResultWork = new PriceSelectSetResultWork();

                    //格納項目
                    priceSelectSetResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    priceSelectSetResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    priceSelectSetResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    priceSelectSetResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    priceSelectSetResultWork.GoodsMakerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    priceSelectSetResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    priceSelectSetResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    priceSelectSetResultWork.PriceSelectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTDIVRF"));
                    priceSelectSetResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    priceSelectSetResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    priceSelectSetResultWork.PriceSelectPtn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTPTNRF"));
                    #endregion

                    al.Add(priceSelectSetResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ)</param>
        /// <returns>WHERE句</returns>
        /// <remarks>
        /// <br>Note       : WHERE句 生成処理。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, PriceSelectSetCndtnWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE ";

            //企業コード
            retstring += " PRI.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //商品メーカーコード
            if (CndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND PRI.GOODSMAKERCDRF >= @ST_GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_GOODSMAKERCD", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.St_GoodsMakerCd);
            }
            if (CndtnWork.Ed_GoodsMakerCd != 0)
            {
                retstring += " AND PRI.GOODSMAKERCDRF <= @ED_GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_GOODSMAKERCD", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.Ed_GoodsMakerCd);
            }

            //BL商品コード
            if (CndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND PRI.BLGOODSCODERF >= @ST_BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_BLGOODSCODE", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.St_BLGoodsCode);
            }
            if (CndtnWork.Ed_BLGoodsCode != 0)
            {
                retstring += " AND PRI.BLGOODSCODERF <= @ED_BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_BLGOODSCODE", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.Ed_BLGoodsCode);
            }

            //得意先
            if (CndtnWork.St_CustomerCode != 0)
            {
                retstring += " AND PRI.CUSTOMERCODERF >= @ST_CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.St_CustomerCode);
            }
            if (CndtnWork.Ed_CustomerCode != 0)
            {
                retstring += " AND PRI.CUSTOMERCODERF <= @ED_CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.Ed_CustomerCode);
            }

            //得意先掛率グループコード
            if (!string.IsNullOrEmpty(CndtnWork.St_BLGroupCode))
            {
                retstring += " AND PRI.CUSTRATEGRPCODERF >= @ST_BLGROUPCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@ST_BLGROUPCODE", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.St_BLGroupCode);
            }
            if (!string.IsNullOrEmpty(CndtnWork.Ed_BLGroupCode))
            {
                retstring += " AND PRI.CUSTRATEGRPCODERF <= @ED_BLGROUPCODE" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@ED_BLGROUPCODE", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.Ed_BLGroupCode);
            }

            // 論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0))
            {
                retstring += " AND PRI.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);
            }
            else
            {
                retstring += " AND PRI.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)1);
            }

            // 標準価格選択区分
            if (CndtnWork.PriceSelectPtn != 9)
            {
                retstring += " AND PRI.PRICESELECTPTNRF = @PRICESELECTPTN" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@PRICESELECTPTN", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PriceSelectPtn);
            }
            else
            {
                if (CndtnWork.St_BLGroupCode.Equals("0000"))
                {
                    retstring += " AND PRI.PRICESELECTPTNRF <= 5 " + Environment.NewLine;
                    retstring += " AND PRI.PRICESELECTPTNRF >= 3 " + Environment.NewLine;
                }
            }

            // 削除日付
            if (CndtnWork.LogicalDeleteCode == 1)
            {
                if (CndtnWork.DeleteDateTimeSt != DateTime.MinValue && CndtnWork.DeleteDateTimeEd != DateTime.MinValue)
                {
                    retstring += " AND PRI.UPDATEDATETIMERF >= @DELETEDATETIMEST" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeSt = sqlCommand.Parameters.Add("@DELETEDATETIMEST", SqlDbType.BigInt);
                    paraDeleteDateTimeSt.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeSt.Ticks);
                    retstring += " AND PRI.UPDATEDATETIMERF <= @DELETEDATETIMEED" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeEd = sqlCommand.Parameters.Add("@DELETEDATETIMEED", SqlDbType.BigInt);
                    paraDeleteDateTimeEd.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeEd.AddDays(1).Ticks);

                }
                else if (CndtnWork.DeleteDateTimeSt != DateTime.MinValue && CndtnWork.DeleteDateTimeEd == DateTime.MinValue)
                {
                    retstring += " AND PRI.UPDATEDATETIMERF >= @DELETEDATETIMEST" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeSt = sqlCommand.Parameters.Add("@DELETEDATETIMEST", SqlDbType.BigInt);
                    paraDeleteDateTimeSt.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeSt.Ticks);
                }
                else if (CndtnWork.DeleteDateTimeSt == DateTime.MinValue && CndtnWork.DeleteDateTimeEd != DateTime.MinValue)
                {
                    retstring += " AND PRI.UPDATEDATETIMERF <= @DELETEDATETIMEED" + Environment.NewLine;
                    SqlParameter paraDeleteDateTimeEd = sqlCommand.Parameters.Add("@DELETEDATETIMEED", SqlDbType.BigInt);
                    paraDeleteDateTimeEd.Value = SqlDataMediator.SqlSetLong(CndtnWork.DeleteDateTimeEd.AddDays(1).Ticks);
                }

            }
            return retstring;
        }
        #endregion
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理マスタ
// プログラム概要   : 商品管理マスタのエクスポートを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱宝軍
// 作 成 日  2012/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : liusy
// 更 新 日  2012/09/24　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/11/13  修正内容 : 2012/10/17配信分、Redmine#32367
//                                  商品マスタエクスポートで不具合現象の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品管理マスタ（エクスポート）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理マスタ（エクスポート）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br>Note       : 商品管理情報マスタ改修対応。(#32367)</br>
    /// <br>Programmer : liusy</br>
    /// <br>Date       : 2012/09/24</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>Note       : 商品マスタエクスポートで不具合現象の対応。(#32367)</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2012/11/13</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsMngExportDB : RemoteDB, IGoodsMngExportDB
    {
        // --- ADD 李亜博 2012/11/13 for Redmine#32367---------->>>>>
        #region  ■ Private cost
        //設定種別
        private const int SETKIND_1_VALUE = 0;
        private const int SETKIND_2_VALUE = 1;
        private const int SETKIND_3_VALUE = 2;
        private const int SETKIND_4_VALUE = 3;
        private const int SETKIND_5_VALUE = 4;
        #endregion
        // --- ADD 李亜博 2012/11/13 for Redmine#32367----------<<<<<
        /// <summary>
        /// 商品管理マスタ（エクスポート）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>Note       : 商品管理情報マスタ改修対応。(#32367)</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2012/09/24</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public GoodsMngExportDB()
            :
        base("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork", "GOODSMNGRF") //基底クラスのコンストラクタ
        {
        }

        #region 商品管理マスタのみ取得処理
        /// <summary>
        /// 指定された企業コードの商品管理マスタ（エクスポート）LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの商品管理マスタ（エクスポート）LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        public int SearchGoodsMng(out object retObj, object paraObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;

            GoodsMngExportParamWork goodsMngExportParamWork = paraObj as GoodsMngExportParamWork;

            try
            {
                status = SearchGoodsMngProc(out retObj, goodsMngExportParamWork, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngExportDB.SearchGoodsMng Exception=" + ex.Message);
                retObj = new ArrayList();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの商品管理マスタ（エクスポート）LISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果（商品管理マスタ）</param>
        /// <param name="goodsMngExportParamWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの商品管理マスタ（エクスポート）LISTを全て戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        private int SearchGoodsMngProc(out object retObj, GoodsMngExportParamWork goodsMngExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            retObj = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //商品管理マスタデータ取得実行部
                status = SearchGoodsMngAction(ref al, ref sqlConnection, goodsMngExportParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngExportDB.SearchGoodsMngProc Exception=" + ex.Message);
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

            retObj = (object)al;

            return status;
        }
        #endregion

        #region 商品管理マスタデータ取得処理（実行部）
        /// <summary>
        /// 商品管理マスタ（エクスポート）LIST取得処理
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="goodsMngExportParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品管理マスタ（エクスポート）LIST取得処理を行い。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// </remarks>
        private int SearchGoodsMngAction(ref ArrayList al, ref SqlConnection sqlConnection, GoodsMngExportParamWork goodsMngExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder selectTxt = new StringBuilder();

                sqlCommand = new SqlCommand("", sqlConnection);

                selectTxt.Append( "SELECT CREATEDATETIMERF" + 
                            ",     UPDATEDATETIMERF" + 
                            ",     ENTERPRISECODERF" + 
                            ",     FILEHEADERGUIDRF" + 
                            ",     UPDEMPLOYEECODERF" + 
                            ",     UPDASSEMBLYID1RF" + 
                            ",     UPDASSEMBLYID2RF" + 
                            ",     LOGICALDELETECODERF" + 
                            ",     SECTIONCODERF" + 
                            ",     GOODSMGROUPRF" + 
                            ",     GOODSMAKERCDRF" + 
                            ",     BLGOODSCODERF" + 
                            ",     GOODSNORF" + 
                            ",     SUPPLIERCDRF" + 
                            ",     SUPPLIERLOTRF" + 
                            " FROM" +
                            " GOODSMNGRF WITH (READUNCOMMITTED)");

                selectTxt.Append(MakeWhereString(ref sqlCommand, goodsMngExportParamWork, logicalMode));
                sqlCommand.CommandText = selectTxt.ToString();
                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    #endregion

                    al.Add(goodsMngWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngExportDB.SearchGoodsMngAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsMngExportParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定処理を行い。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>Update Note: 2012/11/13 李亜博</br>
        ///	<br>			 Redmine#32367 商品マスタエクスポートで不具合現象の対応</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsMngExportParamWork goodsMngExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            StringBuilder retstring = new StringBuilder(" WHERE ");

            //企業コード
            retstring.Append(" ENTERPRISECODERF=@FINDENTERPRISECODE");
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring.Append( " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring.Append(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }
            /* --- DEL liusy 2012/09/24 for Redmine#32367---------->>>>>
            //商品中分類コード
            retstring.Append(" AND GOODSMGROUPRF=@FINDGOODSMGROUP");
            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroup);

            //BL商品コード
            retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCode);
            */
            // --- DEL liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD 李亜博 2012/11/13 for Redmine#32367---------->>>>>
            if (goodsMngExportParamWork.SetKind != SETKIND_5_VALUE)
            {
                //拠点＋品番
                if (goodsMngExportParamWork.SetKind == SETKIND_1_VALUE)
                {

                    //拠点コード設定
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //商品メーカーコード設定
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //商品番号設定
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoSt))
                    {
                        retstring.Append(" AND GOODSNORF>=@FINDSTGOODSNO");
                        SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@FINDSTGOODSNO", SqlDbType.NChar);
                        paraStGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoEd))
                    {
                        retstring.Append(" AND GOODSNORF<=@FINDEDGOODSNO");
                        SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@FINDEDGOODSNO", SqlDbType.NChar);
                        paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoEd);
                    }

                    //商品番号設定
                    retstring.Append(" AND GOODSNORF<>@FINDGOODSNO");
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = string.Empty;

                    //商品メーカーコード設定
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BLコード
                    retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //中分類
                    retstring.Append(" AND GOODSMGROUPRF=@FINDGOODSMGROUP");
                    SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                }
                //拠点＋中分類＋メーカー＋BLコード
                else if (goodsMngExportParamWork.SetKind == SETKIND_2_VALUE)
                {

                    //拠点コード設定
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //商品メーカーコード設定
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //BLコード
                    if (goodsMngExportParamWork.BLGoodsCodeSt != 0)
                    {
                        retstring.Append(" AND BLGOODSCODERF>=@FINDSTBLGOODSCODE");
                        SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                        paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeSt);
                    }
                    if (goodsMngExportParamWork.BLGoodsCodeEd != 0)
                    {
                        retstring.Append(" AND BLGOODSCODERF<=@FINDEDBLGOODSCODE");
                        SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                        paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeEd);
                    }

                    //中分類
                    if (goodsMngExportParamWork.GoodsMGroupSt != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF>=@FINDSTGOODSMGROUP");
                        SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                        paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupSt);
                    }
                    if (goodsMngExportParamWork.GoodsMGroupEd != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF<=@FINDEDGOODSMGROUP");
                        SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                        paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupEd);
                    }

                    //商品番号設定
                    retstring.Append(" AND GOODSNORF=@FINDGOODSNO");
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = string.Empty;

                    //商品メーカーコード設定
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BLコード
                    retstring.Append(" AND BLGOODSCODERF<>@FINDBLGOODSCODE");
                    SqlParameter paraStGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraStGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //中分類
                    retstring.Append(" AND GOODSMGROUPRF<>@FINDGOODSMGROUP");
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                }
                //拠点＋中分類＋メーカー
                else if (goodsMngExportParamWork.SetKind == SETKIND_3_VALUE)
                {
                    //拠点コード設定
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //商品メーカーコード設定
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //中分類
                    if (goodsMngExportParamWork.GoodsMGroupSt != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF>=@FINDSTGOODSMGROUP");
                        SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                        paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupSt);
                    }
                    if (goodsMngExportParamWork.GoodsMGroupEd != 0)
                    {
                        retstring.Append(" AND GOODSMGROUPRF<=@FINDEDGOODSMGROUP");
                        SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                        paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupEd);
                    }

                    //商品番号設定
                    retstring.Append(" AND GOODSNORF=@FINDGOODSNO");
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = string.Empty;

                    //商品メーカーコード設定
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BLコード
                    retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //中分類
                    retstring.Append(" AND GOODSMGROUPRF<>@FINDGOODSMGROUP");
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);

                }
                //拠点＋メーカー
                else if (goodsMngExportParamWork.SetKind == SETKIND_4_VALUE)
                {

                    //拠点コード設定
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                    {
                        retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                    }
                    if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                    {
                        retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                    }

                    //商品メーカーコード設定
                    if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                        SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                        paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                    }
                    if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                    {
                        retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                        SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                        paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                    }

                    //商品番号設定
                    retstring.Append(" AND GOODSNORF=@FINDGOODSNO");
                    SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                    paraStGoodsNo.Value = string.Empty;

                    //商品メーカーコード設定
                    retstring.Append(" AND GOODSMAKERCDRF<>@FINDGOODSMAKERCD");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(0);

                    //BLコード
                    retstring.Append(" AND BLGOODSCODERF=@FINDBLGOODSCODE");
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);

                    //中分類
                    retstring.Append(" AND GOODSMGROUPRF=@FINDGOODSMGROUP");
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                }
            }
            else
            {
                // --- ADD 李亜博 2012/11/13 for Redmine#32367----------<<<<<
                //拠点コード設定
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdSt))
                {
                    retstring.Append(" AND SECTIONCODERF>=@FINDSTSECTIONCODE");
                    SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@FINDSTSECTIONCODE", SqlDbType.NChar);
                    paraStSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdSt);
                }
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.SectionCdEd))
                {
                    retstring.Append(" AND SECTIONCODERF<=@FINDEDSECTIONCODE");
                    SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@FINDEDSECTIONCODE", SqlDbType.NChar);
                    paraEdSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.SectionCdEd);
                }

                //商品メーカーコード設定
                if (goodsMngExportParamWork.GoodsMakerCdSt != 0)
                {
                    retstring.Append(" AND GOODSMAKERCDRF>=@FINDSTGOODSMAKERCD");
                    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdSt);
                }
                if (goodsMngExportParamWork.GoodsMakerCdEd != 0)
                {
                    retstring.Append(" AND GOODSMAKERCDRF<=@FINDEDGOODSMAKERCD");
                    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMakerCdEd);
                }

                //商品番号設定
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoSt))
                {
                    retstring.Append(" AND GOODSNORF>=@FINDSTGOODSNO");
                    SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@FINDSTGOODSNO", SqlDbType.NChar);
                    paraStGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoSt);
                }
                if (!String.IsNullOrEmpty(goodsMngExportParamWork.GoodsNoEd))
                {
                    retstring.Append(" AND GOODSNORF<=@FINDEDGOODSNO");
                    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@FINDEDGOODSNO", SqlDbType.NChar);
                    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngExportParamWork.GoodsNoEd);
                }
                // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
                //BLコード
                if (goodsMngExportParamWork.BLGoodsCodeSt != 0)
                {
                    retstring.Append(" AND BLGOODSCODERF>=@FINDSTBLGOODSCODE");
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeSt);
                }
                if (goodsMngExportParamWork.BLGoodsCodeEd != 0)
                {
                    retstring.Append(" AND BLGOODSCODERF<=@FINDEDBLGOODSCODE");
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.BLGoodsCodeEd);
                }

                //中分類
                if (goodsMngExportParamWork.GoodsMGroupSt != 0)
                {
                    retstring.Append(" AND GOODSMGROUPRF>=@FINDSTGOODSMGROUP");
                    SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                    paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupSt);
                }
                if (goodsMngExportParamWork.GoodsMGroupEd != 0)
                {
                    retstring.Append(" AND GOODSMGROUPRF<=@FINDEDGOODSMGROUP");
                    SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                    paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngExportParamWork.GoodsMGroupEd);
                }
                // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD 李亜博 2012/11/13 for Redmine#32367---------->>>>>
            }
            retstring.Append(" ORDER BY ENTERPRISECODERF,SECTIONCODERF,GOODSMGROUPRF, GOODSMAKERCDRF,BLGOODSCODERF,GOODSNORF");
            // --- ADD 李亜博 2012/11/13 for Redmine#32367----------<<<<<
            #endregion
            return retstring.ToString();
        }
    }
}

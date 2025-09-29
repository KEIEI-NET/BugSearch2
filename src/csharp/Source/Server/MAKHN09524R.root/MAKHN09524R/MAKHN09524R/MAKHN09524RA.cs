using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using System.Xml;
using System.IO;
using Microsoft.Win32;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品管理情報マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理情報マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.01.25</br>
    /// <br></br>
    /// <br>Update Note: 2007.05.08 村瀬　シンク処理追加 </br>
    /// <br>Update Note: 2007.08.20 長内　DC.NS用に修正 </br>
    /// <br></br>
    /// <br>Update Note: 2010/11/05 22018  鈴木 正臣  PM.NS用 外部Rから呼び出し可能なメソッドを一部変更。(ReadProc)</br>
    /// <br>UpDateNote : 2010/12/03 曹文傑 拠点＋メーカーのレコードを論理削除する場合の不具合を修正</br>
    /// <br>UpDateNote : 2012/05/29 宮津　タイムアウトエラー対応</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
    /// <br>UpDateNote : 2021/02/26 32470　小原　山形部品障害対応　タイムアウトエラー対応（負荷軽減のためREADUNCOMMITTED追加）　ログ出力対応 </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsMngDB : RemoteDB, IGoodsMngDB, IGetSyncdataList
    {
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
        private OutLogCommon _outLogCommon = null;                // ログ出力
        private const string PGID = "MAKHN09524R";
        // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<

        /// <summary>
        /// 商品管理情報マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        public GoodsMngDB()
            :
            base("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork", "GOODSMNGRF")
        {
            // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
            _outLogCommon = new OutLogCommon();
            // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsMngWork">検索結果</param>
        /// <param name="paragoodsMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int Search(out object goodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsMngWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsMngProc(out goodsMngWork, paragoodsMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Search");
                goodsMngWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsMngWork">検索結果</param>
        /// <param name="paragoodsMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchGoodsMngProc(out object objgoodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsMngWork goodsmngWork = null;

            ArrayList goodsmngWorkList = paragoodsMngWork as ArrayList;
            if (goodsmngWorkList == null)
            {
                goodsmngWork = paragoodsMngWork as GoodsMngWork;
            }
            else
            {
                if (goodsmngWorkList.Count > 0)
                    goodsmngWork = goodsmngWorkList[0] as GoodsMngWork;
            }

            int status = SearchGoodsMngProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
            objgoodsMngWork = goodsmngWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">検索結果</param>
        /// <param name="goodsmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int SearchGoodsMngProc(out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchGoodsMngProcProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">検索結果</param>
        /// <param name="goodsmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        /// <br>UpDateNote : 2021/02/26 小原　山形部品障害対応　タイムアウトエラー対応（負荷軽減のためREADUNCOMMITTED追加）</br>
        private int SearchGoodsMngProcProc( out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                //sqlTxt += "SELECT" + Environment.NewLine;
                //sqlTxt += "   GDM.CREATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.BLGOODSCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSNORF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                //sqlTxt += " FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------>>>>>
                //sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM WITH(READUNCOMMITTED)" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------>>>>>
                //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------>>>>>
                //sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                sqlTxt += "LEFT JOIN MAKERURF AS MAK WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------>>>>>
                //sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
                sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------>>>>>
                //sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------>>>>>
                //sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSURF AS GOO WITH(READUNCOMMITTED)" + Environment.NewLine;
                // --- UPD 小原 2021/02/26 タイムアウトエラー対応 ------<<<<<
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;



                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //企業コード
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);

                //拠点コード
                if (string.IsNullOrEmpty(goodsmngWork.SectionCode) == false)
                {
                    sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                    {
                        paraSectionCode.Value = "";
                    }
                    else
                    {
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                    }
                }

                //商品メーカーコード
                if (goodsmngWork.GoodsMakerCd != 0)
                {
                    sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                }

                //BLコード
                if (goodsmngWork.BLGoodsCode != 0)
                {
                    sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                }

                //商品番号
                if (string.IsNullOrEmpty(goodsmngWork.GoodsNo) == false)
                {
                    sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                    {
                        paraGoodsNo.Value = "";
                    }
                    else
                    {
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                    }
                }

                // 商品中分類
                if (goodsmngWork.GoodsMGroup != 0)
                {
                    sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);
                }

                string wkstring = "";
                //論理削除区分
                if (( logicalMode == ConstantManagement.LogicalMode.GetData0 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData1 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData2 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData3 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if (( logicalMode == ConstantManagement.LogicalMode.GetData01 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData012 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += sqlTxt;

                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/29

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsMngWorkFromReader(ref myReader, 0));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsmngWorkList = al;

            return status;
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsMngWork">検索結果</param>
        /// <param name="paragoodsMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchNoneGoodsNo(out object goodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsMngWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchNoneGoodsNoProc(out goodsMngWork, paragoodsMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Search");
                goodsMngWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsMngWork">検索結果</param>
        /// <param name="paragoodsMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchNoneGoodsNoProc(out object objgoodsMngWork, object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsMngWork goodsmngWork = null;

            ArrayList goodsmngWorkList = paragoodsMngWork as ArrayList;
            if (goodsmngWorkList == null)
            {
                goodsmngWork = paragoodsMngWork as GoodsMngWork;
            }
            else
            {
                if (goodsmngWorkList.Count > 0)
                    goodsmngWork = goodsmngWorkList[0] as GoodsMngWork;
            }

            int status = SearchNoneGoodsNoProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
            objgoodsMngWork = goodsmngWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">検索結果</param>
        /// <param name="goodsmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int SearchNoneGoodsNoProc(out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchNoneGoodsNoProcProc(out goodsmngWorkList, goodsmngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">検索結果</param>
        /// <param name="goodsmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        private int SearchNoneGoodsNoProcProc( out ArrayList goodsmngWorkList, GoodsMngWork goodsmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                //sqlTxt += "SELECT" + Environment.NewLine;
                //sqlTxt += "   GDM.CREATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.BLGOODSCODERF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.GOODSNORF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERCDRF" + Environment.NewLine;
                //sqlTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                //sqlTxt += "  ,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                //sqlTxt += " FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                //sqlTxt += "ON " + Environment.NewLine;
                //sqlTxt += "     GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                //sqlTxt += " AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;




                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //企業コード
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);

                //商品番号
                sqlTxt += " AND GDM.GOODSNORF=''" + Environment.NewLine;

                string wkstring = "";
                //論理削除区分
                if (( logicalMode == ConstantManagement.LogicalMode.GetData0 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData1 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData2 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData3 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if (( logicalMode == ConstantManagement.LogicalMode.GetData01 ) ||
                    ( logicalMode == ConstantManagement.LogicalMode.GetData012 ))
                {
                    wkstring = " AND GDM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsMngWorkFromReader(ref myReader, 0));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsmngWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品管理情報マスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsMngWork goodsmngWork = new GoodsMngWork();

                // XMLの読み込み
                goodsmngWork = (GoodsMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsMngWork));
                if (goodsmngWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsmngWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(goodsmngWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Read");
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
        /// 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWork">GoodsMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int ReadProc(ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref goodsmngWork, readMode, ref sqlConnection);
        }
        // --- UPD m.suzuki 2010/11/05 ---------->>>>>
        # region // DEL
        ///// <summary>
        ///// 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)
        ///// </summary>
        ///// <param name="goodsmngWork">GoodsMngWorkオブジェクト</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)</br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2007.01.25</br>
        ///// <br></br>
        ///// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        //private int ReadProcProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection )
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;

        //    try
        //    {
        //        string sqlTxt = "";
        //        //sqlTxt += "SELECT" + Environment.NewLine;
        //        //sqlTxt += "   GDM.CREATEDATETIMERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDATEDATETIMERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.SECTIONCODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.BLGOODSCODERF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.GOODSNORF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.SUPPLIERCDRF" + Environment.NewLine;
        //        //sqlTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
        //        //sqlTxt += "  ,GDM.SUPPLIERLOTRF" + Environment.NewLine;
        //        //sqlTxt += " FROM GOODSMNGRF AS GDM" + Environment.NewLine;
        //        //sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
        //        //sqlTxt += "ON " + Environment.NewLine;
        //        //sqlTxt += "     GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
        //        //sqlTxt += " AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
        //        //sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
        //        //sqlTxt += "ON " + Environment.NewLine;
        //        //sqlTxt += "     GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
        //        //sqlTxt += " AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;

        //        sqlTxt += "SELECT" + Environment.NewLine;
        //        sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
        //        sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
        //        sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
        //        sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
        //        sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
        //        sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
        //        sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
        //        sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
        //        sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
        //        sqlTxt += "ON" + Environment.NewLine;
        //        sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
        //        sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
        //        sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;

        //        sqlTxt += "WHERE" + Environment.NewLine;
        //        sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
        //        sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
        //        sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
        //        sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
        //        sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
        //        sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;


        //        //Selectコマンドの生成
        //        using ( SqlCommand sqlCommand = new SqlCommand( sqlTxt, sqlConnection ) )
        //        {

        //            //Prameterオブジェクトの作成
        //            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

        //            //Parameterオブジェクトへ値設定
        //            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
        //            if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
        //            {
        //                findParaSectionCode.Value = "";
        //            }
        //            else
        //            {
        //                findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
        //            }

        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
        //            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
        //            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

        //            if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
        //            {
        //                findParaGoodsNo.Value = "";
        //            }
        //            else
        //            {
        //                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
        //            }

        //            myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //            if (myReader.Read())
        //            {
        //                goodsmngWork = CopyToGoodsMngWorkFromReader(ref myReader, 0);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();
        //    }

        //    return status;
        //}
        # endregion

        /// <summary>
        /// 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWork"></param>
        /// <param name="readMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int ReadProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            return ReadProcProc( ref goodsmngWork, readMode, ref sqlConnection, ref sqlTransaction );
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWork">GoodsMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2010/11/05</br>
        /// <br></br>
        private int ReadProcProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();

                //Selectコマンドの生成
                SqlCommand sqlCommand = null;
                try
                {
                    // 変更点①：トランザクションを渡す
                    sqlCommand = new SqlCommand( sqlTxt, sqlConnection, sqlTransaction );

                    // SetParam
                    SetParamForRead( ref sqlCommand, goodsmngWork );

                    // 変更点②：コネクションをクローズしない
                    myReader = sqlCommand.ExecuteReader();
                    if ( myReader.Read() )
                    {
                        goodsmngWork = CopyToGoodsMngWorkFromReader( ref myReader, 0 );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                finally
                {
                    if ( sqlCommand != null )
                    {
                        sqlCommand.Dispose();
                    }
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            finally
            {
                if ( myReader != null )
                    if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWork">GoodsMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        private int ReadProcProc( ref GoodsMngWork goodsmngWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();


                //Selectコマンドの生成
                SqlCommand sqlCommand = null;
                try
                {
                    sqlCommand = new SqlCommand( sqlTxt, sqlConnection );

                    // SetParam
                    SetParamForRead( ref sqlCommand, goodsmngWork );

                    myReader = sqlCommand.ExecuteReader( CommandBehavior.CloseConnection );
                    if ( myReader.Read() )
                    {
                        goodsmngWork = CopyToGoodsMngWorkFromReader( ref myReader, 0 );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                finally
                {
                    if ( sqlCommand != null )
                    {
                        sqlCommand.Dispose();
                    }
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            finally
            {
                if ( myReader != null )
                    if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// クエリ生成処理(Read用)
        /// </summary>
        /// <returns></returns>
        private string GetSqlTextForRead()
        {
            string sqlTxt = string.Empty;

            sqlTxt += "SELECT" + Environment.NewLine;
            sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
            sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
            sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
            sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
            sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
            sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
            sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
            sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
            sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
            sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
            sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
            sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
            sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
            sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
            sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
            sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
            sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
            sqlTxt += "ON" + Environment.NewLine;
            sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
            sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;

            sqlTxt += "WHERE" + Environment.NewLine;
            sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

            return sqlTxt;
        }
        /// <summary>
        /// パラメータ設定処理(Read用)
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="goodsmngWork"></param>
        private void SetParamForRead( ref SqlCommand sqlCommand, GoodsMngWork goodsmngWork )
        {
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSECTIONCODE", SqlDbType.NChar );
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add( "@FINDBLGOODSCODE", SqlDbType.Int );
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NVarChar );
            SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add( "@FINDGOODSMGROUP", SqlDbType.Int );

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( goodsmngWork.EnterpriseCode );
            if ( SqlDataMediator.SqlSetString( goodsmngWork.SectionCode ) == DBNull.Value )
            {
                findParaSectionCode.Value = "";
            }
            else
            {
                findParaSectionCode.Value = SqlDataMediator.SqlSetString( goodsmngWork.SectionCode );
            }

            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( goodsmngWork.GoodsMakerCd );
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32( goodsmngWork.BLGoodsCode );
            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32( goodsmngWork.GoodsMGroup );

            if ( SqlDataMediator.SqlSetString( goodsmngWork.GoodsNo ) == DBNull.Value )
            {
                findParaGoodsNo.Value = "";
            }
            else
            {
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString( goodsmngWork.GoodsNo );
            }
        }
        // --- ADD m.suzuki 2010/11/05 ----------<<<<<
        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br>GetSyncdataListProc</br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += " FROM GOODSMNGRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsMngWorkFromReader(ref myReader, 1));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 商品管理情報マスタ情報を登録、更新します
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int Write(ref object goodsMngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(goodsMngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteGoodsMngProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                goodsMngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMngDB.Write(ref object goodsMngWork)");
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
        /// 商品管理情報マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int WriteGoodsMngProc(ref ArrayList goodsMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsMngProcProc(ref goodsMngWorkList,ref sqlConnection,ref sqlTransaction);
        }
        
        /// <summary>
        /// 商品管理情報マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        private int WriteGoodsMngProcProc(ref ArrayList goodsMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
            try
            {
                string sqlTxt = "";
            
                if (goodsMngWorkList != null)
                {
                    for (int i = 0; i < goodsMngWorkList.Count; i++)
                    {
                        GoodsMngWork goodsmngWork = goodsMngWorkList[i] as GoodsMngWork;

                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "  GDM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += " ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                          findParaSectionCode.Value = "";
                        }
                        else
                        {
                          findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }

                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                          findParaGoodsNo.Value = "";
                        }
                        else
                        {
                          findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }

                        sqlCommand.CommandTimeout = dbCommandTimeout;  //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != goodsmngWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (goodsmngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSMNGRF SET" + Environment.NewLine;
                            sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlTxt += " , SUPPLIERLOTRF=@SUPPLIERLOT" + Environment.NewLine;
                            sqlTxt += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlTxt += "  AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            
                            sqlCommand.CommandText = sqlTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                            if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                            {
                              findParaSectionCode.Value = "";
                            }
                            else
                            {
                              findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                            }

                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                            if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                            {
                              findParaGoodsNo.Value = "";
                            }
                            else
                            {
                              findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                            }

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (goodsmngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            sqlTxt = "";
                            sqlTxt += "INSERT INTO GOODSMNGRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                            sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                            sqlTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlTxt += "  ,@SUPPLIERLOT" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSMGROUP" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = sqlTxt;
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierLot = sqlCommand.Parameters.Add("@SUPPLIERLOT", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                          paraSectionCode.Value = "";
                        }
                        else
                        {
                          paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }
                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                          paraGoodsNo.Value = "";

                        }
                        else
                        {
                          paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsmngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsmngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsmngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.SupplierCd);
                        paraSupplierLot.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.SupplierLot);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsmngWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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

            goodsMngWorkList = al;

            return status;
        }

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 商品管理情報マスタ情報を論理削除します
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int LogicalDelete(ref object goodsMngWork)
        {
            return LogicalDeleteGoodsMng(ref goodsMngWork, 0);
        }

        /// <summary>
        /// 論理削除商品管理情報マスタ情報を復活します
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品管理情報マスタ情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int RevivalLogicalDelete(ref object goodsMngWork)
        {
            return LogicalDeleteGoodsMng(ref goodsMngWork, 1);
        }

        /// <summary>
        /// 商品管理情報マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        private int LogicalDeleteGoodsMng(ref object goodsMngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(goodsMngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsMngProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "GoodsMngDB.LogicalDeleteGoodsMng :" + procModestr);

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
        /// 商品管理情報マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int LogicalDeleteGoodsMngProc(ref ArrayList goodsMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsMngProcProc(ref goodsMngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品管理情報マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        /// <br>UpDateNote : 2010/12/03 曹文傑 拠点＋メーカーのレコードを論理削除する場合の不具合を修正</br>
        private int LogicalDeleteGoodsMngProcProc( ref ArrayList goodsMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string sqlTxt = "";

                if (goodsMngWorkList != null)
                {
                    for (int i = 0; i < goodsMngWorkList.Count; i++)
                    {
                        GoodsMngWork goodsmngWork = goodsMngWorkList[i] as GoodsMngWork;

                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "  GOODSMNG.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += " ,GOODSMNG.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " ,GOODSMNG.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSMNGRF AS GOODSMNG" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     GOODSMNG.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlTxt += " AND GOODSMNG.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                            findParaSectionCode.Value = "";
                        }
                        else
                        {
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }

                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                            findParaGoodsNo.Value = "";
                        }
                        else
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != goodsmngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSMNGRF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            // ---ADD 2010/12/03----------->>>>>
                            sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            // ---ADD 2010/12/03-----------<<<<<

                            sqlCommand.CommandText = sqlTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                            if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                            {
                                findParaSectionCode.Value = "";
                            }
                            else
                            {
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                            }

                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                            if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                            {
                                findParaGoodsNo.Value = "";
                            }
                            else
                            {
                                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                            }

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsmngWork;
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
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) goodsmngWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else goodsmngWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsmngWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsmngWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsmngWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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

            goodsMngWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 商品管理情報マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">商品管理情報マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品管理情報マスタ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteGoodsMngProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsMngDB.Delete");
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
        /// 商品管理情報マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">商品管理情報マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品管理情報マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int DeleteGoodsMngProc(ArrayList goodsmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsMngProcProc(goodsmngWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品管理情報マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">商品管理情報マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品管理情報マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        private int DeleteGoodsMngProcProc( ArrayList goodsmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";

                for (int i = 0; i < goodsmngWorkList.Count; i++)
                {
                    sqlTxt = "";
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "  GOODSMNG.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += " ,GOODSMNG.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += " ,GOODSMNG.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "FROM GOODSMNGRF AS GOODSMNG" + Environment.NewLine;
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "     GOODSMNG.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlTxt += " AND GOODSMNG.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                    GoodsMngWork goodsmngWork = goodsmngWorkList[i] as GoodsMngWork;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                    if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                    {
                        findParaSectionCode.Value = "";
                    }
                    else
                    {
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                    }

                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                    if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                    {
                        findParaGoodsNo.Value = "";
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                    }

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != goodsmngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt = "";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM GOODSMNGRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine; 

                        sqlCommand.CommandText = sqlTxt;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.EnterpriseCode);
                        if (SqlDataMediator.SqlSetString(goodsmngWork.SectionCode) == DBNull.Value)
                        {
                            findParaSectionCode.Value = "";
                        }
                        else
                        {
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(goodsmngWork.SectionCode);
                        }

                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.BLGoodsCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsmngWork.GoodsMGroup);

                        if (SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo) == DBNull.Value)
                        {
                            findParaGoodsNo.Value = "";
                        }
                        else
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsmngWork.GoodsNo);
                        }
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
        #endregion


        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">格納項目切り替え</param>
        /// <returns>GoodsMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        /// <br>UpDateNote : 2021/02/26 小原 山形部品障害対応　ログ出力対応</br>
        /// </remarks>
        private GoodsMngWork CopyToGoodsMngWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            GoodsMngWork wkGoodsMngWork = new GoodsMngWork();
            // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
            string getRead = string.Empty;
            string enterpriseCode = string.Empty;
            string updEmployeeCode = string.Empty;
            string goodsMakerCd = string.Empty;
            string goodsNo = string.Empty;
            try
            {
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                #region クラスへ格納
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "CREATEDATETIMERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "UPDATEDATETIMERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "ENTERPRISECODERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    enterpriseCode = wkGoodsMngWork.EnterpriseCode;
                    getRead = "FILEHEADERGUIDRF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "UPDEMPLOYEECODERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    updEmployeeCode = wkGoodsMngWork.UpdEmployeeCode;
                    getRead = "UPDASSEMBLYID1RF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "UPDASSEMBLYID2RF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "LOGICALDELETECODERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "SECTIONCODERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "GOODSMAKERCDRF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    goodsMakerCd = string.Format("GMC={0};", wkGoodsMngWork.GoodsMakerCd.ToString());
                    getRead = "BLGOODSCODERF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "GOODSNORF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    goodsNo = string.Format("GN={0};", wkGoodsMngWork.GoodsNo.ToString());
                    getRead = "SUPPLIERCDRF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "SUPPLIERLOTRF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                try
                {
                    getRead = "GOODSMGROUPRF";
                }
                catch
                {
                }
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                wkGoodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));

                if (mode == 0)
                {
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                    try
                    {
                        getRead = "SECTIONGUIDENMRF";
                    }
                    catch
                    {
                    }
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                    wkGoodsMngWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                    try
                    {
                        getRead = "SUPPLIERSNMRF";
                    }
                    catch
                    {
                    }
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                    wkGoodsMngWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                    try
                    {
                        getRead = "MAKERNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                    wkGoodsMngWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                    try
                    {
                        getRead = "BLGOODSFULLNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                    wkGoodsMngWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                    try
                    {
                        getRead = "GOODSNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                    wkGoodsMngWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
                    try
                    {
                        getRead = "GOODSMGROUPNAMERF";
                    }
                    catch
                    {
                    }
                    // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<
                    wkGoodsMngWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));

                }
                #endregion
                // --- ADD 小原 2021/02/26 例外時ログ出力対応 --->>>>>
            }
            catch(Exception ex)
            {
                // 例外時CLC、クライアントログ出力
                _outLogCommon.OutputServerLog(PGID, goodsMakerCd + goodsNo + getRead, enterpriseCode, updEmployeeCode, ex);

                throw;
            }
            // --- ADD 小原 2021/02/26 例外時ログ出力対応 ---<<<<<


            return wkGoodsMngWork;
        }

        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsMngWork[] GoodsMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is GoodsMngWork)
                    {
                        GoodsMngWork wkGoodsMngWork = paraobj as GoodsMngWork;
                        if (wkGoodsMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsMngWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsMngWorkArray = (GoodsMngWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsMngWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsMngWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsMngWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsMngWork wkGoodsMngWork = (GoodsMngWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsMngWork));
                                if (wkGoodsMngWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsMngWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
